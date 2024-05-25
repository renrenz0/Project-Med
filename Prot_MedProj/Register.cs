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
    public partial class Fregis : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;

        public Fregis()
        {
            InitializeComponent();

        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();

                string patientQuery = "INSERT INTO PatientInfo ([Last Name], [First Name], [Middle Name], Street, Barangay, Province, " +
                               "Zipcode, [Phone Number], [Email Address], Age, Birthdate, Gender, [Registration Date], Address,[Civil Status],[Employment Status]) VALUES " +
                               "(@lastname, @firstname, @middlename, @addstreet, @addbar, @addprovince, @addzipcode, @phonenum, @emailadd, " +
                               "@age, @birthdate, @gender, @regisdate, @address, @civstat, @empstat)";

                using (cmd = new OleDbCommand(patientQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                    cmd.Parameters.AddWithValue("@middlename", txtmi.Text);
                    cmd.Parameters.AddWithValue("@addstreet", txtaddstreet.Text);
                    cmd.Parameters.AddWithValue("@addbar", cmbBarangay.SelectedItem);
                    if (cmbBarangay.SelectedItem == null)
                    {
                        MessageBox.Show("Select a Barangay");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@addprovince", txtprovince.Text);
                    cmd.Parameters.AddWithValue("@addzipcode", txtzipcode.Text);
                    cmd.Parameters.AddWithValue("@phonenum", txtphonenum.Text);
                    cmd.Parameters.AddWithValue("@emailadd", txtemail.Text);
                    cmd.Parameters.AddWithValue("@age", txtage.Text);
                    cmd.Parameters.Add("@birthdate", OleDbType.Date).Value = dtpbirthdate.Value.Date;
                    cmd.Parameters.AddWithValue("@gender", cbmgender.SelectedItem);
                    if (cbmgender.SelectedItem == null)
                    {
                        MessageBox.Show("Select a Gender");
                        return;
                    }
                    cmd.Parameters.Add("@regisdate", OleDbType.Date).Value = dtpregis.Value.Date;
                    cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                    cmd.Parameters.AddWithValue("@civstat", cmbstat.SelectedItem);
                    if (cmbstat.SelectedItem == null)
                    {
                        MessageBox.Show("Select a Status");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@empstat", cmbemploy.SelectedItem);
                    if (cmbemploy.SelectedItem == null)
                    {
                        MessageBox.Show("Select an Employment Status");
                        return;
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }

                string medicalQuery = "INSERT INTO MedicalInfo (Height, Weight, BMI, [Blood Type]) VALUES" +
                    "(@height, @weight, @bmi, @bldtyp)";

                using (cmd = new OleDbCommand(medicalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@height", txtheight.Text);
                    cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                    cmd.Parameters.AddWithValue("@bmi", txtbmi.Text);
                    cmd.Parameters.AddWithValue("@bldtyp", cmbbldtyp.SelectedItem);
                    if (cmbbldtyp.SelectedItem == null)
                    {
                        MessageBox.Show("Select Bloodtype");
                        return;
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }

                string medhistQuery = "INSERT INTO MedHistory ([Medical Care], [Chief Complaint], [Diagnosis], [Present Illnesses], [Past Illnesses], [Prescribed Medicines], Allergies, Quantity) VALUES " +
                      "(@medcare, @chiefcomp, @diag, @presntill, @pastill, @presmed, @allergies, @quantity)";
                using (cmd = new OleDbCommand(medhistQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@medcare", cmbmedcare.SelectedItem);
                    if (cmbmedcare.SelectedItem == null)
                    {
                        MessageBox.Show("Select Medical Care");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@chiefcomp", txtchfcomp.Text);
                    cmd.Parameters.AddWithValue("@diag", txtdiag.Text);
                    cmd.Parameters.AddWithValue("@presntill", txtpresill.Text);
                    cmd.Parameters.AddWithValue("@pastill", txtpastill.Text);

                    string prescribedMeds = "";
                    foreach (string item in lbpremed.SelectedItems)
                    {
                        prescribedMeds += item + ", ";
                    }
                    prescribedMeds = prescribedMeds.TrimEnd(',', ' ');
                    cmd.Parameters.AddWithValue("@presmed", prescribedMeds);

                    string allergies = "";
                    foreach (string item in lballergies.SelectedItems)
                    {
                        allergies += item + ", ";
                    }
                    allergies = allergies.TrimEnd(',', ' ');
                    cmd.Parameters.AddWithValue("@allergies", allergies);

                    // Concatenate quantities from textboxes 24-29 into a single string separated by commas
                    string quantities = string.Join(",", new string[]
                    {
                    string.IsNullOrEmpty(textBox24.Text) ? "0" : textBox24.Text,
                    string.IsNullOrEmpty(textBox25.Text) ? "0" : textBox25.Text,
                    string.IsNullOrEmpty(textBox26.Text) ? "0" : textBox26.Text,
                    string.IsNullOrEmpty(textBox27.Text) ? "0" : textBox27.Text,
                    string.IsNullOrEmpty(textBox28.Text) ? "0" : textBox28.Text,
                    string.IsNullOrEmpty(textBox29.Text) ? "0" : textBox29.Text
                    });
                    cmd.Parameters.AddWithValue("@quantity", quantities);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Patient Data Added");
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return;
                    }
                }


            }

            for (int i = 24; i <= 29; i++)
            {
                // Get the label and corresponding textbox controls
                Label labelControl = this.Controls.Find("label" + i, true).FirstOrDefault() as Label;
                TextBox textBoxControl = this.Controls.Find("textBox" + i, true).FirstOrDefault() as TextBox;

                // If both label and textbox are found
                if (labelControl != null && textBoxControl != null)
                {
                    // Get the medicine name and quantity to subtract
                    string medicineName = labelControl.Text;

                    // Check if the textbox has a value
                    if (!string.IsNullOrEmpty(textBoxControl.Text))
                    {
                        int quantityToSubtract;
                        if (int.TryParse(textBoxControl.Text, out quantityToSubtract))
                        {
                            // Update the quantity in the MedInventory table
                            UpdateMedicineQuantity(medicineName, quantityToSubtract);
                        }
                        else
                        {
                            // Handle invalid quantity input
                            MessageBox.Show("Invalid quantity for " + medicineName);
                        }
                    }
                }
            }
        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();


                string patientQuery = "UPDATE PatientInfo SET [Last Name]=@lastname, [Middle Name]=@middlename, Gender=@gender, " +
                    "Age=@age, [Civil Status]=@civstat, [Employment Status]=@empstat WHERE [Patient Number]=@patientID";
                using (cmd = new OleDbCommand(patientQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                    cmd.Parameters.AddWithValue("@middlename", txtmi.Text);
                    cmd.Parameters.AddWithValue("@gender", cbmgender.SelectedItem);
                    cmd.Parameters.AddWithValue("@age", txtage.Text);
                    cmd.Parameters.AddWithValue("@civstat", cmbstat.SelectedItem);
                    cmd.Parameters.AddWithValue("@empstat", cmbemploy.SelectedItem);
                    if (string.IsNullOrEmpty(txtpatnum1.Text))
                    {
                        MessageBox.Show("Cannot Update, Patient not registered");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@patientID", Convert.ToInt32(txtpatnum1.Text));
                    }
                    if (cbmgender.SelectedItem == null || cmbstat.SelectedItem == null || cmbemploy.SelectedItem == null)
                    {
                        MessageBox.Show("Please fill all required fields.");
                        return;
                    }
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error updating PatientInfo: " + ex.Message);
                        return;
                    }
                }


                string medicalQuery = "UPDATE MedicalInfo SET Height=@height, Weight=@weight, BMI=@bmi WHERE [Patient Number]=@patientID";
                using (cmd = new OleDbCommand(medicalQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@height", txtheight.Text);
                    cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                    cmd.Parameters.AddWithValue("@bmi", txtbmi.Text);
                    cmd.Parameters.AddWithValue("@patientID", Convert.ToInt32(txtpatnum2.Text));

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error updating MedicalInfo: " + ex.Message);
                        return;
                    }
                }


                string medhistQuery = "UPDATE MedHistory SET [Past Illnesses]=@pastill, [Prescribed Medicines]=@presmed, Allergies=@allergies WHERE [Patient Number]=@patientID";
                using (cmd = new OleDbCommand(medhistQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@pastill", txtpastill.Text);

                    // Concatenate the selected items from txtpresmed (assuming it's a ListBox) into a single string
                    string prescribedMeds = "";
                    foreach (string item in lbpremed.Items)
                    {
                        prescribedMeds += item + ", ";
                    }
                    prescribedMeds = prescribedMeds.TrimEnd(',', ' '); // Remove the trailing comma and space
                    cmd.Parameters.AddWithValue("@presmed", prescribedMeds);

                    // Concatenate the selected items from txtaller (assuming it's a ListBox) into a single string
                    string allergies = "";
                    foreach (string item in lballergies.Items)
                    {
                        allergies += item + ", ";
                    }
                    allergies = allergies.TrimEnd(',', ' '); // Remove the trailing comma and space
                    cmd.Parameters.AddWithValue("@allergies", allergies);

                    cmd.Parameters.AddWithValue("@patientID", Convert.ToInt32(txtpatnum3.Text));

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Patient data updated successfully.");
                        this.Close();
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Error updating MedHistory: " + ex.Message);
                        return;
                    }
                }
            }
        }
        private void Fregis_Load(object sender, EventArgs e)
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

        private void lballergies_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Step 1: Get the unselected data from lballergies
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

            for (int i = 24; i <= 29; i++)
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

        private int GetMedicineQuantity(string medicineName)
        {
            int quantity = 0;

            // Query the database to retrieve the quantity for the selected medicine
            string query = "SELECT Quantity FROM MedInventory WHERE [Medicine Name] = @medicineName";

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                // Add parameter to the query to prevent SQL injection
                cmd.Parameters.AddWithValue("@medicineName", medicineName);

                conn.Open();
                // Execute the query to get the quantity
                object result = cmd.ExecuteScalar();

                // Check if the result is not null and convert it to int
                if (result != null && result != DBNull.Value)
                {
                    quantity = Convert.ToInt32(result);
                }

                conn.Close();
            }

            return quantity;
        }

        private void UpdateMedicineQuantity(string medicineName, int subtractQuantity)
        {
            // Retrieve the current quantity for the selected medicine from the database
            int currentQuantity = GetMedicineQuantity(medicineName);

            // Calculate the new quantity after subtracting the inputted quantity
            int newQuantity = currentQuantity - subtractQuantity;

            // Update the "Quantity" column in the database for the selected medicine
            string query = "UPDATE MedInventory SET Quantity = @newQuantity WHERE [Medicine Name] = @medicineName";

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@newQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@medicineName", medicineName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void lballergies_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Step 1: Get the unselected data from lballergies
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
    }
}
