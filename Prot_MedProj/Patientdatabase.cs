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
    public partial class Patientdatabase : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;

        public Patientdatabase()
        {
            InitializeComponent();
        }

        public void Getpatientdata()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM PatientDataBase", conn);
            conn.Open();
            adapter.Fill(dt, "PatientDataBase");
            conn.Close();

            dgvpatdata.DataSource = dt.Tables["PatientDataBase"];
        }

        private void Patientdatabase_Load(object sender, EventArgs e)
        {
            Getpatientdata();
        }

        private void dgvpatdata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dgvpatdata.Rows[indexRow];

                lblln.Text = row.Cells["Last Name"].Value?.ToString();
                lblfn.Text = row.Cells["First Name"].Value?.ToString();
                lblage.Text = row.Cells["Age"].Value?.ToString();
                lblgdr.Text = row.Cells["Gender"].Value?.ToString();
                lblbt.Text = row.Cells["Blood Type"].Value?.ToString();
                lblh.Text = row.Cells["Height"].Value?.ToString();
                lblw.Text = row.Cells["Weight"].Value?.ToString();
                lblbmi.Text = row.Cells["BMI"].Value?.ToString();
                lblchiefc.Text = row.Cells["Chief Complaint"].Value?.ToString();
                lbldiag.Text = row.Cells["Diagnosis"].Value?.ToString();
                lblpresil.Text = row.Cells["Present Illnesses"].Value?.ToString();
                lblpastil.Text = row.Cells["Past Illnesses"].Value?.ToString();
                lblpm.Text = row.Cells["Prescribed Medicines"].Value?.ToString();

                byte[] imageData = row.Cells["Picture"].Value as byte[];
                if (imageData != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        pbprof.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pbprof.Image = null;
                }

                lblpatno.Text = row.Cells["Patient Number"].Value?.ToString();

            }
        }

        private void btndeletedata_Click(object sender, EventArgs e)
        {
            if (dgvpatdata.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            DataGridViewRow selectedRow = dgvpatdata.SelectedRows[0];

            int patientId = Convert.ToInt32(selectedRow.Cells["Patient Number"].Value);

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string deleteAppointmentQuery = "DELETE FROM Appointments WHERE [Patient Number] = @patientId";
                        using (cmd = new OleDbCommand(deleteAppointmentQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteMedHistoryQuery = "DELETE FROM MedHistory WHERE [Patient Number] = @patientId";
                        using (cmd = new OleDbCommand(deleteMedHistoryQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deleteMedicalInfoQuery = "DELETE FROM MedicalInfo WHERE [Patient Number] = @patientId";
                        using (cmd = new OleDbCommand(deleteMedicalInfoQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        string deletePatientInfoQuery = "DELETE FROM PatientInfo WHERE [Patient Number] = @patientId";
                        using (cmd = new OleDbCommand(deletePatientInfoQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@patientId", patientId);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Patient and related records deleted successfully.");
                        Getpatientdata();
                    }
                    catch (OleDbException ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error deleting information: " + ex.Message);
                    }
                }
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (dt.Tables.Contains("PatientDataBase"))
            {
                DataView dataViewDB = dt.Tables["PatientDataBase"].DefaultView;
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
    }
}
