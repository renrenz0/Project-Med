using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Prot_MedProj
{
    public partial class Fmenu : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;

        public Fmenu()
        {
            InitializeComponent();
        }

        public void GetPatientData()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM PatientInfo", conn);
            conn.Open();
            adapter.Fill(dt, "PatientInfo");
            conn.Close();

            dt.Tables["PatientInfo"].DefaultView.Sort = "[Registration Date] DESC";
            dgvPatients.DataSource = dt.Tables["PatientInfo"];

            int recordCount = dt.Tables["PatientInfo"].Rows.Count;
            lblRecordCount.Text = recordCount.ToString();
        }

        private void Fmenu_Load(object sender, EventArgs e)
        {
            timer1.Start();
            labtime.Text = DateTime.Now.ToLongTimeString();
            labdate.Text = DateTime.Now.ToLongDateString();

            GetPatientData();
            dgvPatients.Columns["Patient Number"].Visible = false;
            dgvPatients.Columns["Address"].Visible = false;
            dgvPatients.Columns["Street"].Visible = false;
            dgvPatients.Columns["Province"].Visible = false;
            dgvPatients.Columns["Zipcode"].Visible = false;
            dgvPatients.Columns["Email Address"].Visible = false;
            dgvPatients.Columns["Civil Status"].Visible = false;
            dgvPatients.Columns["Employment Status"].Visible = false;

            int madridejosCount = 0;
            int poblacionCount = 0;
            int compostelaCount = 0;
            int guadalupeCount = 0;
            int legaspiCount = 0;
            int lepantoCount = 0;
            int montpellerCount = 0;
            int staFilomenaCount = 0;
            int valenciaCount = 0;
            int otherCount = 0;

            foreach (DataRow row in dt.Tables["PatientInfo"].Rows)
            {
                string barangay = row["Barangay"].ToString();

                switch (barangay)
                {
                    case "Madridejos":
                        madridejosCount++;
                        break;
                    case "Poblacion":
                        poblacionCount++;
                        break;
                    case "Compostela":
                        compostelaCount++;
                        break;
                    case "Guadalupe":
                        guadalupeCount++;
                        break;
                    case "Legaspi":
                        legaspiCount++;
                        break;
                    case "Lepanto":
                        lepantoCount++;
                        break;
                    case "Montpeller":
                        montpellerCount++;
                        break;
                    case "Sta.Filomena":
                        staFilomenaCount++;
                        break;
                    case "Valencia":
                        valenciaCount++;
                        break;
                    case "Other":
                        otherCount++;
                        break;
                    default:
                        break;
                }
            }

            lblmadcount.Text = madridejosCount.ToString();
            lblpobcount.Text = poblacionCount.ToString();
            lblcompount.Text = compostelaCount.ToString();
            lblguacount.Text = guadalupeCount.ToString();
            lbllegcount.Text = legaspiCount.ToString();
            lbllepcount.Text = lepantoCount.ToString();
            lblmontcount.Text = montpellerCount.ToString();
            lblstacount.Text = staFilomenaCount.ToString();
            lblvalcount.Text = valenciaCount.ToString();
            lblothcount.Text = otherCount.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labtime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
