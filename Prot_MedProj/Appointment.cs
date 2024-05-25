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
    public partial class Appointment : Form
    {

        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;

        public Appointment()
        {
            InitializeComponent();
        }

        public void GetAppointments()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM AppointSet", conn);
            conn.Open();
            adapter.Fill(dt, "AppointSet");
            conn.Close();

            dgvpatientappnt.DataSource = dt.Tables["AppointSet"];
        }

        public void Upcomingappnts()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM UpcomingAppnts", conn);
            conn.Open();
            adapter.Fill(dt, "UpcomingAppnts");
            conn.Close();

            dgvupcomingappoints.DataSource = dt.Tables["UpcomingAppnts"];
        }

        private void Appointment_Load(object sender, EventArgs e)
        {
            GetAppointments();
            Upcomingappnts();
        }

        private void dgvpatientappnt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dgvpatientappnt.Rows[indexRow];

                txtlastname.Text = row.Cells["Last Name"].Value?.ToString();
                txtfirstname.Text = row.Cells["First Name"].Value?.ToString();
                txtphonenum.Text = row.Cells["Phone Number"].Value?.ToString();
                txtemail.Text = row.Cells["Email Address"].Value?.ToString();
                txtappdesc.Text = row.Cells["Appointment Description"].Value?.ToString();
                txtpatid.Text = row.Cells["Patient Number"].Value?.ToString();


                string appointmentDateString = row.Cells["Appointment Date"].Value?.ToString();
                string appointmentTimeString = row.Cells["Appointment Time"].Value?.ToString();


                DateTime? appointmentDate = null;
                if (!string.IsNullOrEmpty(appointmentDateString))
                {
                    if (DateTime.TryParse(appointmentDateString, out DateTime date))
                    {
                        appointmentDate = date;
                    }
                }

                DateTime? appointmentTime = null;
                if (!string.IsNullOrEmpty(appointmentTimeString))
                {
                    if (DateTime.TryParse(appointmentTimeString, out DateTime time))
                    {
                        appointmentTime = time;
                    }
                }


                if (!appointmentDate.HasValue || !appointmentTime.HasValue)
                {
                    MessageBox.Show("Patient is not appointed");
                    return;
                }


                dtpdate.Value = appointmentDate.Value;
                dtptime.Value = appointmentTime.Value;
            }
        }

        private void btnappoint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpatid.Text))
            {
                MessageBox.Show("Select a patient before updating the appointment.");
                return;
            }

            if (!int.TryParse(txtpatid.Text, out int patientId))
            {
                MessageBox.Show("Invalid Patient ID");
                return;
            }

            DateTime appointmentDate = dtpdate.Value.Date;
            DateTime appointmentTime = dtptime.Value;

            string appointmentTimeStr = appointmentTime.ToShortTimeString();

            string updateQuery = "UPDATE Appointments SET [Appointment Date] = @appdate, [Appointment Time] = @apptime, [Appointment Description] = @appdesc " +
                "WHERE [Patient Number] = @patientId";

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                try
                {
                    conn.Open();

                    using (cmd = new OleDbCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@appdate", appointmentDate);
                        cmd.Parameters.AddWithValue("@apptime", appointmentTimeStr);
                        cmd.Parameters.AddWithValue("@appdesc", txtappdesc.Text);
                        cmd.Parameters.AddWithValue("@patientId", patientId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment updated successfully");
                            GetAppointments();
                            ClearFormFields();
                            Upcomingappnts();
                        }
                        else
                        {
                            MessageBox.Show("No appointment found for the specified patient");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating appointment: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (dt.Tables.Contains("AppointSet"))
            {
                DataView dataViewDB = dt.Tables["AppointSet"].DefaultView;
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

        private void btnappointclear_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtpatid.Text))
            {
                MessageBox.Show("Select a patient before clearing the appointment.");
                return;
            }

            if (!int.TryParse(txtpatid.Text, out int patientId))
            {
                MessageBox.Show("Invalid Patient ID");
                return;
            }

            string clearQuery = "UPDATE Appointments SET [Appointment Date] = NULL, [Appointment Time] = NULL, [Appointment Description] = NULL " +
                                "WHERE [Patient Number] = @patientId";

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                try
                {
                    conn.Open();

                    using (cmd = new OleDbCommand(clearQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Appointment details cleared successfully");
                            ClearFormFields();
                            GetAppointments();
                        }
                        else
                        {
                            MessageBox.Show("No appointment found for the specified patient");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error clearing appointment details: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ClearFormFields()
        {
            txtlastname.Text = "";
            txtfirstname.Text = "";
            txtphonenum.Text = "";
            txtemail.Text = "";
            txtappdesc.Text = "";
            txtpatid.Text = "";
            dtpdate.Value = DateTime.Now;
            dtptime.Value = DateTime.Now;
        }

        private void dtpcalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            dtpcalendar.RemoveAllBoldedDates();

            foreach (DataGridViewRow row in dgvpatientappnt.Rows)
            {
                if (row.Cells["Appointment Date"].Value != null)
                {
                    DateTime appointmentDate;
                    if (DateTime.TryParse(row.Cells["Appointment Date"].Value.ToString(), out appointmentDate))
                    {
                        dtpcalendar.AddBoldedDate(appointmentDate);
                    }
                }
            }
            dtpcalendar.UpdateBoldedDates();
        }
    }
}

