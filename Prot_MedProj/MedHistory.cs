using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prot_MedProj
{
    public partial class MedHistory : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;
        public MedHistory()
        {
            InitializeComponent();
        }


        public static class DatabaseUtils
        {
            public static int GetLastInsertedPatientId(OleDbConnection conn, OleDbTransaction transaction)
            {
                int patientId = 0;
                using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", conn, transaction))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        patientId = Convert.ToInt32(result);
                    }
                }
                return patientId;
            }
        }

        private void MedHistory_Load(object sender, EventArgs e)
        {
            MedicalInv();
            Medpicker();
            Displaypatdiag();
        }
        public void MedicalInv()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM MedInventory", conn);
            conn.Open();
            adapter.Fill(dt, "MedInventory");
            conn.Close();

            dgvmedicines.DataSource = dt.Tables["MedInventory"];
        }

        public void Medpicker()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb");
            dt = new DataSet();
            conn.Open();
            adapter = new OleDbDataAdapter("SELECT [Medicine Name] FROM MedInventory", conn);
            adapter.Fill(dt, "MedInventory");
            conn.Close();

            List<string> medicineNames = new List<string>();
            foreach (DataRow row in dt.Tables["MedInventory"].Rows)
            {
                string medicineName = row["Medicine Name"].ToString();
                medicineNames.Add(medicineName);
            }

            lballergies.DataSource = medicineNames;
        }

        public void Displaypatdiag()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM DocDiagnosis", conn);
            conn.Open();
            adapter.Fill(dt, "DocDiagnosis");
            conn.Close();

            dgvpatientdiag.DataSource = dt.Tables["DocDiagnosis"];
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            if (cmbmedcare.SelectedItem == null)
            {
                MessageBox.Show("Select Medical Care");
                return;
            }

            if (string.IsNullOrEmpty(txtpatid.Text))
            {
                MessageBox.Show("Select a patient before adding medical history");
                return;
            }

            int patientId;
            if (!int.TryParse(txtpatid.Text, out patientId))
            {
                MessageBox.Show("Invalid Patient ID");
                return;
            }

            if (!PatientExists(patientId))
            {
                MessageBox.Show("Patient does not exist");
                return;
            }

            string existingAllergies = GetExistingAllergies(patientId);
            string existingPrescribedMeds = GetExistingPrescribedMeds(patientId);

            string updatedAllergies = CombineValues(existingAllergies, lballergies.SelectedItems.Cast<string>());
            string updatedPrescribedMeds = CombineValues(existingPrescribedMeds, lbpremed.SelectedItems.Cast<string>());

            if (!CheckMedicineStock(lbpremed.SelectedItems.Cast<string>()))
            {
                MessageBox.Show("One or more prescribed medicines are out of stock.");
                return;
            }

            string updateQuery = "UPDATE MedHistory SET [Medical Care] = @medcare, [Chief Complaint] = @chiefcomp, [Diagnosis] = @diag, " +
                "[Present Illnesses] = @presntill, [Past Illnesses] = @pastill, [Prescribed Medicines] = @presmed, Allergies = @allergies, Quantity = @quantity " +
                "WHERE [Patient Number] = @patientId";

            using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@medcare", cmbmedcare.SelectedItem);
                    cmd.Parameters.AddWithValue("@chiefcomp", txtchfcomp.Text);
                    cmd.Parameters.AddWithValue("@diag", txtdiag.Text);
                    cmd.Parameters.AddWithValue("@presntill", txtpresill.Text);
                    cmd.Parameters.AddWithValue("@pastill", txtpastill.Text);
                    cmd.Parameters.AddWithValue("@presmed", updatedPrescribedMeds);
                    cmd.Parameters.AddWithValue("@allergies", updatedAllergies);

                    List<string> quantitiesList = new List<string>();
                    for (int i = 24; i <= 31; i++)
                    {
                        TextBox textBoxControl = this.Controls.Find("textBox" + i, true).FirstOrDefault() as TextBox;
                        if (textBoxControl != null && !string.IsNullOrEmpty(textBoxControl.Text))
                        {
                            if (int.TryParse(textBoxControl.Text, out int quantity))
                            {
                                quantitiesList.Add(quantity.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Invalid quantity for " + textBoxControl.Name);
                                return;
                            }
                        }
                    }
                    string quantities = string.Join(",", quantitiesList);
                    cmd.Parameters.AddWithValue("@quantity", quantities);
                    cmd.Parameters.AddWithValue("@patientId", patientId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Data Updated");

                    for (int i = 24; i <= 31; i++)
                    {
                        TextBox textBoxControl = this.Controls.Find("textBox" + i, true).FirstOrDefault() as TextBox;
                        if (textBoxControl != null && !string.IsNullOrEmpty(textBoxControl.Text))
                        {
                            string medicineName = (this.Controls.Find("label" + i, true).FirstOrDefault() as Label)?.Text;
                            int quantityInput;
                            if (int.TryParse(textBoxControl.Text, out quantityInput))
                            {
                                UpdateMedicineQuantity(medicineName, quantityInput);
                            }
                        }
                    }

                    MedicalInv();
                    Displaypatdiag();
                    ClearAllTextBoxes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private string GetExistingAllergies(int patientId)
        {
            string query = "SELECT Allergies FROM MedHistory WHERE [Patient Number] = @patientId";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientId", patientId);
                conn.Open();
                string existingAllergies = cmd.ExecuteScalar()?.ToString();
                conn.Close();
                return existingAllergies ?? "";
            }
        }

        private string GetExistingPrescribedMeds(int patientId)
        {
            string query = "SELECT [Prescribed Medicines] FROM MedHistory WHERE [Patient Number] = @patientId";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientId", patientId);
                conn.Open();
                string existingPrescribedMeds = cmd.ExecuteScalar()?.ToString();
                conn.Close();
                return existingPrescribedMeds ?? "";
            }
        }

        private string CombineValues(string existingValues, IEnumerable<string> newValues)
        {
            List<string> combinedValues = existingValues.Split(',').ToList();
            combinedValues.AddRange(newValues);
            return string.Join(", ", combinedValues.Distinct());
        }

        private bool PatientExists(int patientId)
        {
            string query = "SELECT COUNT(*) FROM PatientInfo WHERE [Patient Number] = @patientId";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientId", patientId);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conn.Close();
                return count > 0;
            }
        }


        private void lballergies_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedMedicineNames = new List<string>();

            foreach (var selectedItem in lballergies.SelectedItems)
            {
                string selectedMedicineName = selectedItem.ToString();
                selectedMedicineNames.Add(selectedMedicineName);
            }

            List<string> allMedicineNames = lballergies.DataSource as List<string>;
            List<string> unselectedMedicineNames = allMedicineNames.Except(selectedMedicineNames).ToList();

            lbpremed.DataSource = unselectedMedicineNames;
        }

        private void lbpremed_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> selectedMedicineNames = new List<string>();

            foreach (var selectedItem in lbpremed.SelectedItems)
            {
                string selectedMedicineName = selectedItem.ToString();
                selectedMedicineNames.Add(selectedMedicineName);
            }

            for (int i = 24; i <= 31; i++)
            {
                Control labelControl = this.Controls.Find("label" + i, true).FirstOrDefault();
                Control textBoxControl = this.Controls.Find("textBox" + i, true).FirstOrDefault();

                if (labelControl != null && labelControl is Label)
                {
                    if (i - 24 < selectedMedicineNames.Count)
                    {
                        (labelControl as Label).Text = selectedMedicineNames[i - 24];
                        (labelControl as Label).Visible = true;
                        (textBoxControl as TextBox).Visible = true;

                        string medicineName = (labelControl as Label).Text;
                        int quantityInput;
                        if (int.TryParse((textBoxControl as TextBox).Text, out quantityInput))
                        {
                            UpdateMedicineQuantity(medicineName, quantityInput);
                        }
                    }
                    else
                    {
                        (labelControl as Label).Visible = false;
                        (textBoxControl as TextBox).Visible = false;
                    }
                }
            }
        }
        private void UpdateMedicineQuantity(string medicineName, int subtractQuantity)
        {
            int currentQuantity = GetMedicineQuantity(medicineName);
            int newQuantity = currentQuantity - subtractQuantity;


            if (newQuantity < 0)
            {
                newQuantity = 0;
                string updateQuery = "UPDATE MedInventory SET Quantity = @newQuantity WHERE [Medicine Name] = @medicineName";

                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd.Parameters.AddWithValue("@medicineName", medicineName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                foreach (DataGridViewRow row in dgvmedicines.Rows)
                {
                    if ((int)row.Cells["Quantity"].Value <= 0)
                    {
                        row.Cells["Quantity"].Value = "Out of Stock";
                        break;
                    }
                }
            }
            else
            {
                string updateQuery = "UPDATE MedInventory SET Quantity = @newQuantity WHERE [Medicine Name] = @medicineName";

                using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                    cmd.Parameters.AddWithValue("@medicineName", medicineName);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private int GetMedicineQuantity(string medicineName)
        {
            int quantity = 0;
            string query = "SELECT Quantity FROM MedInventory WHERE [Medicine Name] = @medicineName";

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@medicineName", medicineName);

                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    quantity = Convert.ToInt32(result);
                }

                conn.Close();
            }

            return quantity;
        }

        private void dgvpatientdiag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dgvpatientdiag.Rows[indexRow];

                txtlastname.Text = row.Cells["Last Name"].Value?.ToString();
                txtfirstname.Text = row.Cells["First Name"].Value?.ToString();
                cmbmedcare.SelectedItem = row.Cells["Medical Care"].Value?.ToString();
                txtchfcomp.Text = row.Cells["Chief Complaint"].Value?.ToString();
                txtdiag.Text = row.Cells["Diagnosis"].Value?.ToString();
                txtpresill.Text = row.Cells["Present Illnesses"].Value?.ToString();
                txtpastill.Text = row.Cells["Past Illnesses"].Value?.ToString();

                SetSelectedItemsFromCell(row.Cells["Prescribed Medicines"].Value?.ToString(), lbpremed);
                SetSelectedItemsFromCell(row.Cells["Allergies"].Value?.ToString(), lballergies);

                txtpatid.Text = row.Cells["Patient Number"].Value?.ToString();

            }
        }
        private void SetSelectedItemsFromCell(string cellValue, ListBox listBox)
        {
            if (!string.IsNullOrEmpty(cellValue))
            {
                string[] items = cellValue.Split(',');
                foreach (string item in items)
                {
                    int index = listBox.FindStringExact(item.Trim());
                    if (index != ListBox.NoMatches)
                    {
                        listBox.SetSelected(index, true);
                    }
                }
            }
        }

        private bool CheckMedicineStock(IEnumerable<string> prescribedMeds)
        {
            foreach (string medName in prescribedMeds)
            {
                int requiredQuantity = 1;
                int availableQuantity = GetMedicineQuantity(medName);
                if (availableQuantity < requiredQuantity)
                {
                    return false;
                }
            }
            return true;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (dt.Tables.Contains("DocDiagnosis"))
            {
                DataView dataViewDB = dt.Tables["DocDiagnosis"].DefaultView;
                if (!string.IsNullOrEmpty(txtsearch.Text))
                {
                    string filterExpressionDB = $"[Last Name] LIKE '%{txtsearch.Text}%' OR [First Name] LIKE '%{txtsearch.Text}%'";
                    dataViewDB.RowFilter = filterExpressionDB;
                }
                else
                {
                    dataViewDB.RowFilter = string.Empty;
                }
            }
        }
        private void ClearAllTextBoxes()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        private void btncleardiag_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpatid.Text))
            {
                MessageBox.Show("Select a patient before clearing diagnosis");
                return;
            }

            int patientId;
            if (!int.TryParse(txtpatid.Text, out patientId))
            {
                MessageBox.Show("Invalid Patient ID");
                return;
            }

            if (!PatientExists(patientId))
            {
                MessageBox.Show("Patient does not exist");
                return;
            }

            try
            {
                conn.Open();
                string updateQuery = @"UPDATE MedHistory 
                               SET [Chief Complaint] = NULL, [Medical Care] = NULL, [Diagnosis] = NULL, [Present Illnesses] = NULL, [Past Illnesses] = NULL, Allergies = NULL, [Prescribed Medicines] = NULL, 
                                   Quantity = NULL 
                               WHERE [Patient Number] = @patientId";

                using (OleDbCommand cmd = new OleDbCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@patientId", patientId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Patient diagnosis cleared successfully.");
                        ClearAllTextBoxes();
                        Displaypatdiag();
                    }
                    else
                    {
                        MessageBox.Show("No changes were made.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
