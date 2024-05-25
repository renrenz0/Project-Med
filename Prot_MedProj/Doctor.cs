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
    public partial class Doctor : Form
    {
        public Doctor()
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

        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Signin signin = new Signin();
                signin.Show();
                this.Hide();
            }
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            loadform(new MedHistory());
        }

        private void btnpatdiag_Click(object sender, EventArgs e)
        {
            Doctor_Load(sender, e);
        }

        private void btnappoint_Click(object sender, EventArgs e)
        {
            loadform(new Appointment());
        }
    }
}
