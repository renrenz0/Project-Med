using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Prot_MedProj
{
    // Define an interface for user management operations
    public interface IUserManagement
    {
        void LoadUsers();
        void UpdateUser(string userId, string username, string password, string userType);
    }

    public partial class UserManagement : Form, IUserManagement
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;

        public UserManagement()
        {
            InitializeComponent();
        }

        public void LoadUsers()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT * FROM Members", conn);
            conn.Open();
            adapter.Fill(dt, "Members");
            conn.Close();

            dgvmembers.DataSource = dt.Tables["Members"];
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvmembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                indexRow = e.RowIndex;
                DataGridViewRow row = dgvmembers.Rows[indexRow];

                txtuser.Text = row.Cells["User"].Value?.ToString();
                txtusertype.Text = row.Cells["Usertype"].Value?.ToString();
                txtpassword.Text = row.Cells["Password"].Value?.ToString();
                txtid.Text = row.Cells["ID"].Value?.ToString();
            }
        }

        public void UpdateUser(string userId, string username, string password, string userType)
        {
            string query = "UPDATE Members SET [Password] = @pass, [User] = @user, [Usertype] = @usertype WHERE [ID] = @id";

            using (conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
            {
                using (cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@usertype", userType);
                    cmd.Parameters.AddWithValue("@id", userId);

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password and user details updated successfully!");
                            LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show("No rows updated. User ID not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating password and user details: " + ex.Message);
                    }
                }
            }
        }

        private void btnchangepass_Click(object sender, EventArgs e)
        {
            UpdateUser(txtid.Text, txtuser.Text, txtnewpass.Text, txtusertype.Text);

            txtnewpass.Text = "";
        }
    }
}
