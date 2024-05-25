namespace Prot_MedProj
{
    partial class UserManagement
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
            groupBox1 = new GroupBox();
            label3 = new Label();
            txtnewpass = new TextBox();
            dgvmembers = new DataGridView();
            txtusertype = new TextBox();
            txtuser = new TextBox();
            btnchangepass = new Button();
            label1 = new Label();
            txtpassword = new TextBox();
            txtid = new TextBox();
            label2 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvmembers).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(127, 133, 140);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtnewpass);
            groupBox1.Controls.Add(dgvmembers);
            groupBox1.Controls.Add(txtusertype);
            groupBox1.Controls.Add(txtuser);
            groupBox1.Controls.Add(btnchangepass);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtpassword);
            groupBox1.Controls.Add(txtid);
            groupBox1.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(452, 155);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(772, 551);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "User's Center";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(343, 339);
            label3.Name = "label3";
            label3.Size = new Size(104, 16);
            label3.TabIndex = 15;
            label3.Text = "New Password";
            // 
            // txtnewpass
            // 
            txtnewpass.Location = new Point(294, 358);
            txtnewpass.Name = "txtnewpass";
            txtnewpass.Size = new Size(196, 23);
            txtnewpass.TabIndex = 14;
            txtnewpass.TextAlign = HorizontalAlignment.Center;
            // 
            // dgvmembers
            // 
            dgvmembers.AllowUserToAddRows = false;
            dgvmembers.AllowUserToDeleteRows = false;
            dgvmembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvmembers.BackgroundColor = Color.FromArgb(127, 133, 140);
            dgvmembers.BorderStyle = BorderStyle.None;
            dgvmembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvmembers.GridColor = Color.FromArgb(127, 133, 140);
            dgvmembers.Location = new Point(106, 62);
            dgvmembers.Name = "dgvmembers";
            dgvmembers.ReadOnly = true;
            dgvmembers.RowHeadersVisible = false;
            dgvmembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvmembers.Size = new Size(581, 200);
            dgvmembers.TabIndex = 6;
            dgvmembers.CellClick += dgvmembers_CellClick;
            // 
            // txtusertype
            // 
            txtusertype.Location = new Point(294, 120);
            txtusertype.Name = "txtusertype";
            txtusertype.Size = new Size(196, 23);
            txtusertype.TabIndex = 13;
            txtusertype.Visible = false;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(294, 91);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(196, 23);
            txtuser.TabIndex = 12;
            txtuser.Visible = false;
            // 
            // btnchangepass
            // 
            btnchangepass.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnchangepass.ForeColor = Color.Black;
            btnchangepass.Location = new Point(313, 445);
            btnchangepass.Name = "btnchangepass";
            btnchangepass.Size = new Size(164, 43);
            btnchangepass.TabIndex = 9;
            btnchangepass.Text = "Change Password";
            btnchangepass.UseVisualStyleBackColor = true;
            btnchangepass.Click += btnchangepass_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(333, 277);
            label1.Name = "label1";
            label1.Size = new Size(129, 16);
            label1.TabIndex = 8;
            label1.Text = "Current Password";
            // 
            // txtpassword
            // 
            txtpassword.Location = new Point(293, 296);
            txtpassword.Name = "txtpassword";
            txtpassword.ReadOnly = true;
            txtpassword.Size = new Size(196, 23);
            txtpassword.TabIndex = 7;
            txtpassword.TextAlign = HorizontalAlignment.Center;
            // 
            // txtid
            // 
            txtid.Location = new Point(294, 62);
            txtid.Name = "txtid";
            txtid.Size = new Size(196, 23);
            txtid.TabIndex = 10;
            txtid.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("MS UI Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 21);
            label2.Name = "label2";
            label2.Size = new Size(370, 37);
            label2.TabIndex = 7;
            label2.Text = "USER MANAGEMENT";
            // 
            // UserManagement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgbg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1684, 1024);
            Controls.Add(label2);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserManagement";
            Text = "UserManagement";
            Load += UserManagement_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvmembers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnchangepass;
        private Label label1;
        private TextBox txtpassword;
        private DataGridView dgvmembers;
        private TextBox txtid;
        private TextBox txtuser;
        private TextBox txtusertype;
        private Label label2;
        private Label label3;
        private TextBox txtnewpass;
    }
}