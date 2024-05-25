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

    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void cmbuser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbuser.SelectedItem != null)
            {
                txtuser.Text = cmbuser.SelectedItem.ToString();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == null || txtpassword.Text == null)
            {
                MessageBox.Show("Please enter both username and password.");
            }
            else
            {
                try
                {
                    using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OleDb.16.0;Data Source=PatientData.accdb"))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM Members WHERE [User] = @user AND [Password] = @password", conn))
                        {
                            cmd.Parameters.AddWithValue("@user", txtuser.Text.Trim());
                            cmd.Parameters.AddWithValue("@password", txtpassword.Text.Trim());

                            using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                            {
                                DataTable dt = new DataTable();
                                adapter.Fill(dt);

                                if (dt.Rows.Count > 0)
                                {
                                    string userType = dt.Rows[0]["Usertype"].ToString();
                                    if (userType == "Admin")
                                    {
                                        Admin mainMenu = new Admin();
                                        mainMenu.Show();
                                        this.Hide();
                                    }
                                    else if (userType == "Doctor")
                                    {
                                        Doctor doctor = new Doctor();
                                        doctor.Show();
                                        this.Hide();
                                    }
                                    else if (userType == "Receptionist")
                                    {
                                        Front_Desk front_Desk = new Front_Desk();
                                        front_Desk.Show();
                                        this.Hide();
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Invalid username or password.");
                                    txtpassword.Text = "";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Signin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }

                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
