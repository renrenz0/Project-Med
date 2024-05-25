using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prot_MedProj
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        public void loadform(object form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        public void logout()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Signin signin = new Signin();
                signin.Show();
                this.Hide();
            }
        }

        private void btnpatientdatabase_Click(object sender, EventArgs e)
        {
            loadform(new Patientdatabase());
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnreturnlogin_Click(object sender, EventArgs e)
        {
            logout();
        }

        private void btnfullscreen_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            TopMost = false;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            loadform(new Fmenu());
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            MainMenu_Load(sender, e);
        }

        private void btnmedinv_Click(object sender, EventArgs e)
        {
            loadform(new Fmedinv());
        }

        private void btnuserdatabase_Click(object sender, EventArgs e)
        {
            loadform (new UserManagement());
        }
    }
}
