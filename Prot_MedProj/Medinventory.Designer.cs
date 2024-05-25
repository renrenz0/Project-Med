namespace Prot_MedProj
{
    partial class Fmedinv
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvmedin = new DataGridView();
            label5 = new Label();
            txtmedid = new TextBox();
            btnremove = new Button();
            btnupdate = new Button();
            btnadd = new Button();
            dtpexpiry = new DateTimePicker();
            label4 = new Label();
            txtquant = new TextBox();
            txtbrandname = new TextBox();
            label2 = new Label();
            txtmedname = new TextBox();
            label1 = new Label();
            label6 = new Label();
            txtsearch = new TextBox();
            label8 = new Label();
            txtmeddesc = new TextBox();
            label3 = new Label();
            groupBox1 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label25 = new Label();
            label37 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvmedin).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvmedin
            // 
            dgvmedin.AllowUserToAddRows = false;
            dgvmedin.AllowUserToDeleteRows = false;
            dgvmedin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvmedin.BackgroundColor = Color.White;
            dgvmedin.BorderStyle = BorderStyle.None;
            dgvmedin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvmedin.GridColor = Color.White;
            dgvmedin.Location = new Point(807, 216);
            dgvmedin.Margin = new Padding(1);
            dgvmedin.Name = "dgvmedin";
            dgvmedin.ReadOnly = true;
            dgvmedin.RowHeadersVisible = false;
            dgvmedin.RowHeadersWidth = 72;
            dgvmedin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmedin.Size = new Size(628, 688);
            dgvmedin.TabIndex = 0;
            dgvmedin.CellClick += dgvmedin_CellClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(434, 18);
            label5.Margin = new Padding(1, 0, 1, 0);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 12;
            label5.Text = "Medicine ID";
            // 
            // txtmedid
            // 
            txtmedid.BackColor = Color.FromArgb(127, 133, 140);
            txtmedid.BorderStyle = BorderStyle.None;
            txtmedid.ForeColor = Color.White;
            txtmedid.Location = new Point(528, 15);
            txtmedid.Margin = new Padding(1);
            txtmedid.Name = "txtmedid";
            txtmedid.Size = new Size(35, 15);
            txtmedid.TabIndex = 11;
            // 
            // btnremove
            // 
            btnremove.BackColor = Color.FromArgb(127, 133, 140);
            btnremove.FlatStyle = FlatStyle.Flat;
            btnremove.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnremove.ForeColor = Color.White;
            btnremove.Location = new Point(621, 865);
            btnremove.Margin = new Padding(1);
            btnremove.Name = "btnremove";
            btnremove.Size = new Size(173, 39);
            btnremove.TabIndex = 10;
            btnremove.Text = "Remove Stock";
            btnremove.UseVisualStyleBackColor = false;
            btnremove.Click += btnremove_Click;
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.FromArgb(127, 133, 140);
            btnupdate.FlatStyle = FlatStyle.Flat;
            btnupdate.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnupdate.ForeColor = Color.White;
            btnupdate.Location = new Point(416, 865);
            btnupdate.Margin = new Padding(1);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(173, 39);
            btnupdate.TabIndex = 9;
            btnupdate.Text = "Update Stock";
            btnupdate.UseVisualStyleBackColor = false;
            btnupdate.Click += btnupdate_Click;
            // 
            // btnadd
            // 
            btnadd.BackColor = Color.FromArgb(127, 133, 140);
            btnadd.FlatStyle = FlatStyle.Flat;
            btnadd.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnadd.ForeColor = Color.White;
            btnadd.Location = new Point(209, 865);
            btnadd.Margin = new Padding(1);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(173, 39);
            btnadd.TabIndex = 8;
            btnadd.Text = "Add Medicine";
            btnadd.UseVisualStyleBackColor = false;
            btnadd.Click += btnadd_Click;
            // 
            // dtpexpiry
            // 
            dtpexpiry.Location = new Point(177, 599);
            dtpexpiry.Margin = new Padding(1);
            dtpexpiry.Name = "dtpexpiry";
            dtpexpiry.Size = new Size(386, 22);
            dtpexpiry.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(54, 599);
            label4.Margin = new Padding(1, 0, 1, 0);
            label4.Name = "label4";
            label4.Size = new Size(105, 15);
            label4.TabIndex = 6;
            label4.Text = "Medicine Expiry";
            // 
            // txtquant
            // 
            txtquant.BackColor = Color.FromArgb(127, 133, 140);
            txtquant.BorderStyle = BorderStyle.None;
            txtquant.ForeColor = Color.White;
            txtquant.Location = new Point(185, 436);
            txtquant.Margin = new Padding(1);
            txtquant.Name = "txtquant";
            txtquant.Size = new Size(312, 15);
            txtquant.TabIndex = 5;
            txtquant.TextAlign = HorizontalAlignment.Center;
            // 
            // txtbrandname
            // 
            txtbrandname.BackColor = Color.FromArgb(127, 133, 140);
            txtbrandname.BorderStyle = BorderStyle.None;
            txtbrandname.ForeColor = Color.White;
            txtbrandname.Location = new Point(185, 202);
            txtbrandname.Margin = new Padding(1);
            txtbrandname.Name = "txtbrandname";
            txtbrandname.Size = new Size(312, 15);
            txtbrandname.TabIndex = 3;
            txtbrandname.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS UI Gothic", 12F);
            label2.Location = new Point(54, 202);
            label2.Margin = new Padding(1, 0, 1, 0);
            label2.Name = "label2";
            label2.Size = new Size(110, 16);
            label2.TabIndex = 2;
            label2.Text = "Medicine Brand";
            // 
            // txtmedname
            // 
            txtmedname.BackColor = Color.FromArgb(127, 133, 140);
            txtmedname.BorderStyle = BorderStyle.None;
            txtmedname.ForeColor = Color.White;
            txtmedname.Location = new Point(185, 98);
            txtmedname.Margin = new Padding(1);
            txtmedname.Name = "txtmedname";
            txtmedname.Size = new Size(312, 15);
            txtmedname.TabIndex = 1;
            txtmedname.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 12F);
            label1.Location = new Point(54, 106);
            label1.Margin = new Padding(1, 0, 1, 0);
            label1.Name = "label1";
            label1.Size = new Size(108, 16);
            label1.TabIndex = 0;
            label1.Text = "Medicine Name";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(807, 189);
            label6.Name = "label6";
            label6.Size = new Size(181, 16);
            label6.TabIndex = 3;
            label6.Text = "Search Medicine Name";
            // 
            // txtsearch
            // 
            txtsearch.BackColor = Color.FromArgb(241, 246, 254);
            txtsearch.BorderStyle = BorderStyle.None;
            txtsearch.Font = new Font("MS UI Gothic", 12F);
            txtsearch.Location = new Point(994, 181);
            txtsearch.Name = "txtsearch";
            txtsearch.PlaceholderText = "Medcine Name / Medicine Brand";
            txtsearch.Size = new Size(441, 16);
            txtsearch.TabIndex = 4;
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("MS UI Gothic", 12F);
            label8.Location = new Point(54, 436);
            label8.Margin = new Padding(1, 0, 1, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 16);
            label8.TabIndex = 4;
            label8.Text = "Quantity";
            // 
            // txtmeddesc
            // 
            txtmeddesc.BackColor = Color.FromArgb(127, 133, 140);
            txtmeddesc.BorderStyle = BorderStyle.None;
            txtmeddesc.ForeColor = Color.White;
            txtmeddesc.Location = new Point(185, 318);
            txtmeddesc.Margin = new Padding(1);
            txtmeddesc.Name = "txtmeddesc";
            txtmeddesc.Size = new Size(312, 15);
            txtmeddesc.TabIndex = 14;
            txtmeddesc.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS UI Gothic", 12F);
            label3.Location = new Point(54, 311);
            label3.Margin = new Padding(1, 0, 1, 0);
            label3.Name = "label3";
            label3.Size = new Size(82, 32);
            label3.TabIndex = 13;
            label3.Text = "Medicine \r\nDescription\r\n";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(127, 133, 140);
            groupBox1.Controls.Add(txtmeddesc);
            groupBox1.Controls.Add(txtmedname);
            groupBox1.Controls.Add(txtbrandname);
            groupBox1.Controls.Add(txtquant);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(txtmedid);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtpexpiry);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(209, 171);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(585, 673);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Medicine Stock Management";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(127, 133, 140);
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(184, 446);
            label11.Name = "label11";
            label11.Size = new Size(312, 15);
            label11.TabIndex = 54;
            label11.Text = "_____________________________________________________________\r\n";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(127, 133, 140);
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(185, 330);
            label10.Name = "label10";
            label10.Size = new Size(312, 15);
            label10.TabIndex = 53;
            label10.Text = "_____________________________________________________________\r\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.FromArgb(127, 133, 140);
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(185, 215);
            label9.Name = "label9";
            label9.Size = new Size(312, 15);
            label9.TabIndex = 52;
            label9.Text = "_____________________________________________________________\r\n";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.FromArgb(127, 133, 140);
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.White;
            label25.Location = new Point(185, 110);
            label25.Name = "label25";
            label25.Size = new Size(312, 15);
            label25.TabIndex = 51;
            label25.Text = "_____________________________________________________________\r\n";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.BackColor = Color.Transparent;
            label37.Font = new Font("MS UI Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label37.Location = new Point(25, 21);
            label37.Name = "label37";
            label37.Size = new Size(388, 37);
            label37.TabIndex = 16;
            label37.Text = "MEDICAL INVENTORY\r\n";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(994, 189);
            label7.Name = "label7";
            label7.Size = new Size(447, 15);
            label7.TabIndex = 55;
            label7.Text = "________________________________________________________________________________________\r\n";
            // 
            // Fmedinv
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgbg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1684, 1024);
            Controls.Add(txtsearch);
            Controls.Add(label7);
            Controls.Add(label37);
            Controls.Add(dgvmedin);
            Controls.Add(groupBox1);
            Controls.Add(btnremove);
            Controls.Add(label6);
            Controls.Add(btnadd);
            Controls.Add(btnupdate);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(1);
            Name = "Fmedinv";
            Text = "Medinventory";
            Load += Fmedinv_Load;
            ((System.ComponentModel.ISupportInitialize)dgvmedin).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvmedin;
        private DateTimePicker dtpexpiry;
        private Label label4;
        private TextBox txtbrandname;
        private Label label2;
        private Label label1;
        private Button btnadd;
        private Button btnremove;
        private Button btnupdate;
        private Label label5;
        private TextBox txtmedid;
        public TextBox txtquant;
        public TextBox txtmedname;
        private Label label6;
        private TextBox txtsearch;
        private Label label8;
        private TextBox txtmeddesc;
        private Label label3;
        private GroupBox groupBox1;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label25;
        private Label label37;
        private Label label7;
    }
}