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
    public partial class Fmedinv : Form
    {
        OleDbConnection conn;
        OleDbDataAdapter adapter;
        DataSet dt;
        OleDbCommand cmd;
        public int indexRow;
        public Fmedinv()
        {
            InitializeComponent();
        }

        public void GetmedicalInventory()
        {
            conn = new OleDbConnection("Provider = Microsoft.ACE.OleDb.16.0; Data Source = PatientData.accdb");
            dt = new DataSet();
            adapter = new OleDbDataAdapter("SELECT *FROM MedInventory", conn);
            conn.Open();
            adapter.Fill(dt, "MedInventory");
            conn.Close();

            dgvmedin.DataSource = dt.Tables["MedInventory"];
        }

        private void Fmedinv_Load(object sender, EventArgs e)
        {
            GetmedicalInventory();

            foreach (DataRow row in dt.Tables["MedInventory"].Rows)
            {
                int quantity = Convert.ToInt32(row["Quantity"]);
                if (quantity <= 0)
                {
                    MessageBox.Show($"The medicine '{row["Medicine Name"]}' is out of stock.", "Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string query = "Insert into MedInventory ([Medicine Name], [Medicine Brand],[Medicine Description], Quantity, [Expiration Date]) " +
                "VALUES (@medname, @medbrand, @meddesc, @quant, @expdate)";

            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@medname", txtmedname.Text);
            cmd.Parameters.AddWithValue("@medbrand", txtbrandname.Text);
            cmd.Parameters.AddWithValue("@meddesc", txtmeddesc.Text);
            cmd.Parameters.AddWithValue("@quant", txtquant.Text);
            cmd.Parameters.Add("@birthdate", OleDbType.Date).Value = dtpexpiry.Value.Date;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            txtmedname.Clear();
            txtbrandname.Clear();
            txtquant.Clear();
            txtmeddesc.Clear();
            dtpexpiry.Value = DateTime.Now;
            GetmedicalInventory();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (indexRow >= 0)
            {
                string query = "UPDATE MedInventory SET [Medicine Name] = @medname, [Medicine Brand] = @medbrand, [Medicine Description] = @meddesc, Quantity = @quant, [Expiration Date] = @expdate WHERE  [Medicine ID] = @id";
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@medname", txtmedname.Text);
                cmd.Parameters.AddWithValue("@medbrand", txtbrandname.Text);
                cmd.Parameters.AddWithValue("@meddesc", txtmeddesc.Text);
                cmd.Parameters.AddWithValue("@quant", txtquant.Text);
                cmd.Parameters.AddWithValue("@expdate", dtpexpiry.Value.Date);
                cmd.Parameters.AddWithValue("@id", dgvmedin.Rows[indexRow].Cells["Medicine ID"].Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                GetmedicalInventory();
            }
            else
            {
                MessageBox.Show("Please select a record to update.");
            }
        }

        private void dgvmedin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            DataGridViewRow row = dgvmedin.Rows[indexRow];

            txtmedname.Text = row.Cells["Medicine Name"].Value.ToString();
            txtbrandname.Text = row.Cells["Medicine Brand"].Value.ToString();
            txtmeddesc.Text = row.Cells["Medicine Description"].Value.ToString();
            txtquant.Text = row.Cells["Quantity"].Value.ToString();
            dtpexpiry.Value = Convert.ToDateTime(row.Cells["Expiration Date"].Value);
            txtmedid.Text = row.Cells["Medicine ID"].Value.ToString();
        }

        private void ResetFields()
        {
            txtmedid.Text = "";
            txtmedname.Text = "";
            txtmeddesc.Text = "";
            txtbrandname.Text = "";
            txtquant.Text = "";
            dtpexpiry.Value = DateTime.Now;
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            if (indexRow >= 0)
            {
                string query = "DELETE FROM MedInventory WHERE [Medicine ID] = @id";
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", dgvmedin.Rows[indexRow].Cells["Medicine ID"].Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                GetmedicalInventory();

                ResetFields();
            }
            else
            {
                MessageBox.Show("Please select a record to delete.");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (dt.Tables.Contains("MedInventory"))
            {
                DataView dataViewDB = dt.Tables["MedInventory"].DefaultView;
                if (!string.IsNullOrEmpty(txtsearch.Text))
                {
                    string filterExpressionDB = $"[Medicine Name] LIKE '%{txtsearch.Text}%' OR [Medicine Brand] LIKE '%{txtsearch.Text}%'";
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
