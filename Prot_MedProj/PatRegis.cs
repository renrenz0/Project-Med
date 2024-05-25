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
    public partial class PatRegis : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;

        public PatRegis()
        {
            InitializeComponent();
        }
        public void Getgeninfo()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM GeneralInfo", conn);
            conn.Open();
            adapter.Fill(dt, "GeneralInfo");
            conn.Close();

            dgvgeninfo.DataSource = dt.Tables["GeneralInfo"];
        }

        private void PatRegis_Load(object sender, EventArgs e)
        {
            Getgeninfo();
        }


        private void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                string myPictures = System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                ofd.Filter = "Jpg, Jpeg Images| *.jpg; *.jpeg|PNG Images| *.png|BMP Images|*.bmp|" + "All files (*.*)|*.*";
                ofd.FileName = "";
                ofd.Title = "Choose an image...";
                ofd.AddExtension = true;
                ofd.FilterIndex = 0;
                ofd.Multiselect = false;
                ofd.ValidateNames = true;
                ofd.InitialDirectory = myPictures;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    this.pbprofilepic.Image = Image.FromFile(ofd.FileName);
                }
                else
                {
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error Uploading the image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.pbprofilepic.Image = null;
        }

        public static int GetLastInsertedPatientId(OleDbConnection conn, OleDbTransaction transaction)
        {
            int patientId = 0;
            string query = "SELECT @@IDENTITY";
            using (OleDbCommand cmd = new OleDbCommand(query, conn, transaction))
            {
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    patientId = Convert.ToInt32(result);
                }
            }
            return patientId;
        }


        private void btnregis_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtlastname.Text) || string.IsNullOrWhiteSpace(txtfirstname.Text) || string.IsNullOrWhiteSpace(txtage.Text) ||
                string.IsNullOrWhiteSpace(txtphonenum.Text) || string.IsNullOrWhiteSpace(txtemail.Text) || string.IsNullOrWhiteSpace(txtaddress.Text) ||
                string.IsNullOrWhiteSpace(txtprovince.Text) || string.IsNullOrWhiteSpace(txtzipcode.Text) || cmbstat.SelectedItem == null || cmbemploy.SelectedItem == null ||
                cbmgender.SelectedItem == null || cmbBarangay.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all required fields.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtpatid.Text))
            {
                int patientId;
                if (int.TryParse(txtpatid.Text, out patientId))
                {
                    if (IsPatientAlreadyRegistered(patientId))
                    {
                        MessageBox.Show("Patient already registered.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid patient ID format. Please enter a valid numeric ID.");
                    return;
                }
            }

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string patientQuery = "INSERT INTO PatientInfo ([Last Name], [First Name], [Middle Name], Street, Barangay, Province, " +
                                               "Zipcode, [Phone Number], [Email Address], Age, Birthdate, Gender, [Registration Date], Address,[Civil Status],[Employment Status],Picture) VALUES " +
                                               "(@lastname, @firstname, @middlename, @addstreet, @addbar, @addprovince, @addzipcode, @phonenum, @emailadd, " +
                                               "@age, @birthdate, @gender, @regisdate, @address, @civstat, @empstat, @picture)";
                        using (cmd = new OleDbCommand(patientQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                            cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                            cmd.Parameters.AddWithValue("@middlename", txtmi.Text);
                            cmd.Parameters.AddWithValue("@addstreet", txtaddstreet.Text);
                            cmd.Parameters.AddWithValue("@addbar", cmbBarangay.SelectedItem);
                            cmd.Parameters.AddWithValue("@addprovince", txtprovince.Text);
                            cmd.Parameters.AddWithValue("@addzipcode", txtzipcode.Text);
                            cmd.Parameters.AddWithValue("@phonenum", txtphonenum.Text);
                            cmd.Parameters.AddWithValue("@emailadd", txtemail.Text);
                            cmd.Parameters.AddWithValue("@age", txtage.Text);
                            cmd.Parameters.Add("@birthdate", OleDbType.Date).Value = dtpbirthdate.Value.Date;
                            cmd.Parameters.AddWithValue("@gender", cbmgender.SelectedItem);
                            cmd.Parameters.Add("@regisdate", OleDbType.Date).Value = dtpregis.Value.Date;
                            cmd.Parameters.AddWithValue("@address", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@civstat", cmbstat.SelectedItem);
                            cmd.Parameters.AddWithValue("@empstat", cmbemploy.SelectedItem);

                            if (pbprofilepic.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pbprofilepic.Image.Save(ms, pbprofilepic.Image.RawFormat);
                                    byte[] imageBytes = ms.ToArray();
                                    cmd.Parameters.AddWithValue("@picture", imageBytes);
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@picture", DBNull.Value);
                            }

                            cmd.ExecuteNonQuery();
                        }

                        int patientNumber = GetLastInsertedPatientId(conn, transaction);

                        string medicalInfoQuery = "INSERT INTO MedicalInfo ([Patient Number], Height, Weight, BMI, [Blood Type]) VALUES " +
                                                   "(@patientNumber, @height, @weight, @bmi, @bldtyp)";
                        using (cmd = new OleDbCommand(medicalInfoQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientNumber", patientNumber);
                            cmd.Parameters.AddWithValue("@height", txtheight.Text);
                            cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                            cmd.Parameters.AddWithValue("@bmi", txtbmi.Text);
                            cmd.Parameters.AddWithValue("@bldtyp", cmbbldtyp.SelectedItem);
                            cmd.ExecuteNonQuery();
                        }

                        string medHistoryQuery = "INSERT INTO MedHistory ([Patient Number], [Medical Care], [Chief Complaint], [Diagnosis], [Present Illnesses], [Past Illnesses], [Prescribed Medicines], Allergies, Quantity) VALUES " +
                                                 "(@patientNumber, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)";
                        using (cmd = new OleDbCommand(medHistoryQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientNumber", patientNumber);
                            cmd.ExecuteNonQuery();
                        }

                        string appointmentQuery = "INSERT INTO Appointments ([Patient Number],[Appointment Date],[Appointment Time],[Appointment Description]) VALUES " +
                            "(@patientNumber, NULL, NULL, NULL)";
                        using (cmd = new OleDbCommand(appointmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientNumber", patientNumber);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Patient Data Registered successfully!");
                        Getgeninfo();
                        ClearTextBoxes();
                    }
                    catch (OleDbException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error inserting information: " + ex.Message);
                    }
                }
            }
        }


        private bool IsPatientAlreadyRegistered(int patientNumber)
        {
            bool isRegistered = false;
            string query = "SELECT COUNT(*) FROM PatientInfo WHERE [Patient Number] = @patientNumber";
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@patientNumber", patientNumber);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    isRegistered = count > 0;
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Error checking for duplicate patient: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
            return isRegistered;
        }


        private void dgvgeninfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvgeninfo.Rows[e.RowIndex];


                txtlastname.Text = row.Cells["Last Name"].Value.ToString();
                txtfirstname.Text = row.Cells["First Name"].Value.ToString();
                txtmi.Text = row.Cells["Middle Name"].Value.ToString();
                cmbstat.SelectedItem = row.Cells["Civil Status"].Value?.ToString();
                cmbemploy.SelectedItem = row.Cells["Employment Status"].Value?.ToString();
                cbmgender.SelectedItem = row.Cells["Gender"].Value?.ToString();
                cmbBarangay.SelectedItem = row.Cells["Barangay"].Value?.ToString();
                cmbbldtyp.SelectedItem = row.Cells["Blood Type"].Value?.ToString();
                txtprovince.Text = row.Cells["Province"].Value?.ToString();
                txtzipcode.Text = row.Cells["Zipcode"].Value?.ToString();
                txtemail.Text = row.Cells["Email Address"].Value?.ToString();
                txtage.Text = row.Cells["Age"].Value.ToString();
                txtemail.Text = row.Cells["Email Address"].Value.ToString();
                txtphonenum.Text = row.Cells["Phone Number"].Value.ToString();
                txtheight.Text = row.Cells["Height"].Value.ToString();
                txtweight.Text = row.Cells["Weight"].Value.ToString();
                txtaddress.Text = row.Cells["Address"].Value.ToString();
                txtaddstreet.Text = row.Cells["Street"].Value.ToString();
                txtbmi.Text = row.Cells["BMI"].Value.ToString();
                string birthdateString = row.Cells["Birthdate"].Value?.ToString();
                DateTime birthdate;
                if (DateTime.TryParse(birthdateString, out birthdate))
                {
                    dtpbirthdate.Value = birthdate;
                }
                else
                {
                    MessageBox.Show("Invalid birthdate format.");
                }

                byte[] imageData = row.Cells["Picture"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbprofilepic.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbprofilepic.Image = null;
                }
                txtpatid.Text = row.Cells["PatientInfo.Patient Number"].Value?.ToString();
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvgeninfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            DataGridViewRow selectedRow = dgvgeninfo.SelectedRows[0];

            bool containsPatientNumberColumn = false;
            foreach (DataGridViewColumn column in dgvgeninfo.Columns)
            {
                if (column.Name == "PatientInfo.Patient Number")
                {
                    containsPatientNumberColumn = true;
                    break;
                }
            }

            if (!containsPatientNumberColumn)
            {
                MessageBox.Show("Patient Number not found!");
                return;
            }


            int patientId = Convert.ToInt32(selectedRow.Cells["PatientInfo.Patient Number"].Value);

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string updatePatientQuery = "UPDATE PatientInfo SET [Last Name] = @lastname, [First Name] = @firstname, [Middle Name] = @middlename, " +
                                                    "Street = @addstreet, Barangay = @addbar, Province = @addprovince, " +
                                                    "Zipcode = @addzipcode, [Phone Number] = @phonenum, [Email Address] = @emailadd, " +
                                                    "Age = @age, Birthdate = @birthdate, Gender = @gender, Address = @address, [Civil Status] = @civstat, " +
                                                    "[Employment Status] = @empstat, Picture = @picture " +
                                                    "WHERE [Patient Number] = @patientId";

                        using (cmd = new OleDbCommand(updatePatientQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@lastname", txtlastname.Text);
                            cmd.Parameters.AddWithValue("@firstname", txtfirstname.Text);
                            cmd.Parameters.AddWithValue("@middlename", txtmi.Text);
                            cmd.Parameters.AddWithValue("@addstreet", txtaddress.Text);
                            cmd.Parameters.AddWithValue("@addbar", cmbBarangay.SelectedItem);
                            cmd.Parameters.AddWithValue("@addprovince", txtprovince.Text);
                            cmd.Parameters.AddWithValue("@addzipcode", txtzipcode.Text);
                            cmd.Parameters.AddWithValue("@phonenum", txtphonenum.Text);
                            cmd.Parameters.AddWithValue("@emailadd", txtemail.Text);
                            cmd.Parameters.AddWithValue("@age", txtage.Text);
                            cmd.Parameters.Add("@birthdate", OleDbType.Date).Value = dtpbirthdate.Value.Date;
                            cmd.Parameters.AddWithValue("@gender", cbmgender.SelectedItem);
                            cmd.Parameters.AddWithValue("@address", txtaddstreet.Text);
                            cmd.Parameters.AddWithValue("@civstat", cmbstat.SelectedItem);
                            cmd.Parameters.AddWithValue("@empstat", cmbemploy.SelectedItem);

                            if (pbprofilepic.Image != null)
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    pbprofilepic.Image.Save(ms, pbprofilepic.Image.RawFormat);
                                    byte[] imageBytes = ms.ToArray();
                                    cmd.Parameters.AddWithValue("@picture", imageBytes);
                                }
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@picture", DBNull.Value);
                            }

                            cmd.Parameters.AddWithValue("@patientId", patientId);

                            cmd.ExecuteNonQuery();
                        }
                        string updateMedicalQuery = "UPDATE MedicalInfo SET Height = @height, Weight = @weight, BMI = @bmi, [Blood Type] = @bldtyp " +
                            "WHERE [Patient Number] = @patientId";

                        using (cmd = new OleDbCommand(updateMedicalQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@height", txtheight.Text);
                            cmd.Parameters.AddWithValue("@weight", txtweight.Text);
                            cmd.Parameters.AddWithValue("@bmi", txtbmi.Text);
                            cmd.Parameters.AddWithValue("@bldtyp", cmbbldtyp.SelectedItem);
                            cmd.Parameters.AddWithValue("@patientId", patientId);

                            cmd.ExecuteNonQuery();
                        }


                        transaction.Commit();
                        MessageBox.Show("Patient and medical information updated successfully.");
                        Getgeninfo();
                        ClearTextBoxes();
                    }
                    catch (OleDbException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error updating information: " + ex.Message);
                    }
                }
            }
        }





        private void txtbmi_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtheight_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(txtheight.Text, out double heightCm) && double.TryParse(txtweight.Text, out double weight))
            {

                double heightM = heightCm / 100.0;


                if (heightM != 0)
                {

                    double bmi = weight / (heightM * heightM);

                    txtbmi.Text = bmi.ToString("0.00");
                }
                else
                {

                    txtbmi.Clear();
                }
            }
            else
            {

                txtbmi.Clear();
            }
        }

        private void txtweight_TextChanged(object sender, EventArgs e)
        {

            if (double.TryParse(txtheight.Text, out double heightCm) && double.TryParse(txtweight.Text, out double weight))
            {

                double heightM = heightCm / 100.0;


                if (heightM != 0)
                {

                    double bmi = weight / (heightM * heightM);

                    txtbmi.Text = bmi.ToString("0.00");
                }
                else
                {

                    txtbmi.Clear();
                }
            }
            else
            {

                txtbmi.Clear();
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (dt.Tables.Contains("GeneralInfo"))
            {
                DataView dataViewDB = dt.Tables["GeneralInfo"].DefaultView;
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

        private void ClearTextBoxes()
        {
            txtaddress.Text = "";
            txtlastname.Text = "";
            txtfirstname.Text = "";
            txtmi.Text = "";
            txtaddstreet.Text = "";
            txtprovince.Text = "";
            txtzipcode.Text = "";
            txtphonenum.Text = "";
            txtemail.Text = "";
            txtage.Text = "";
            txtheight.Text = "";
            txtweight.Text = "";
            txtbmi.Text = "";
            txtpatid.Text = "";


            dtpbirthdate.Value = DateTime.Now;
            dtpregis.Value = DateTime.Now;


            cmbstat.SelectedItem = null;
            cmbemploy.SelectedItem = null;
            cbmgender.SelectedItem = null;
            cmbBarangay.SelectedItem = null;
            cmbbldtyp.SelectedItem = null;


            pbprofilepic.Image = null;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvgeninfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DataGridViewRow selectedRow = dgvgeninfo.SelectedRows[0];

            int patientId = Convert.ToInt32(selectedRow.Cells["PatientInfo.Patient Number"].Value);

            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string deleteAppointmentQuery = "DELETE FROM Appointments WHERE [Patient Number] = @patientId";
                        using (OleDbCommand cmd = new OleDbCommand(deleteAppointmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteMedHistoryQuery = "DELETE FROM MedHistory WHERE [Patient Number] = @patientId";
                        using (OleDbCommand cmd = new OleDbCommand(deleteMedHistoryQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteMedicalInfoQuery = "DELETE FROM MedicalInfo WHERE [Patient Number] = @patientId";
                        using (OleDbCommand cmd = new OleDbCommand(deleteMedicalInfoQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deletePatientInfoQuery = "DELETE FROM PatientInfo WHERE [Patient Number] = @patientId";
                        using (OleDbCommand cmd = new OleDbCommand(deletePatientInfoQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Patient and related records deleted successfully.");
                        Getgeninfo();
                    }
                    catch (OleDbException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting information: " + ex.Message);
                    }
                }
            }
        }

        private void txtclear_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }
    }
}

