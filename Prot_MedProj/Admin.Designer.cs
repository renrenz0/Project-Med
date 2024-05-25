namespace Prot_MedProj
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            panelside = new Panel();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            btndashboard = new Button();
            btnmedinv = new Button();
            btnreturnlogin = new Button();
            btnpatientdatabase = new Button();
            btnuserdatabase = new Button();
            mainpanel = new Panel();
            panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = Color.FromArgb(3, 76, 129);
            panelside.Controls.Add(pictureBox1);
            panelside.Controls.Add(label1);
            panelside.Controls.Add(btndashboard);
            panelside.Controls.Add(btnmedinv);
            panelside.Controls.Add(btnreturnlogin);
            panelside.Controls.Add(btnpatientdatabase);
            panelside.Controls.Add(btnuserdatabase);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 0);
            panelside.Name = "panelside";
            panelside.Size = new Size(261, 811);
            panelside.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(61, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 134);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(75, 169);
            label1.Name = "label1";
            label1.Size = new Size(105, 27);
            label1.TabIndex = 0;
            label1.Text = "ADMIN ";
            // 
            // btndashboard
            // 
            btndashboard.FlatAppearance.BorderColor = Color.FromArgb(3, 76, 129);
            btndashboard.FlatStyle = FlatStyle.Flat;
            btndashboard.Font = new Font("MS UI Gothic", 9.75F, FontStyle.Bold);
            btndashboard.ForeColor = Color.White;
            btndashboard.Image = (Image)resources.GetObject("btndashboard.Image");
            btndashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btndashboard.Location = new Point(0, 253);
            btndashboard.Name = "btndashboard";
            btndashboard.Padding = new Padding(20, 0, 0, 0);
            btndashboard.Size = new Size(261, 72);
            btndashboard.TabIndex = 5;
            btndashboard.Text = "DashBoard";
            btndashboard.UseVisualStyleBackColor = true;
            btndashboard.Click += btndashboard_Click;
            // 
            // btnmedinv
            // 
            btnmedinv.FlatAppearance.BorderColor = Color.FromArgb(3, 76, 129);
            btnmedinv.FlatStyle = FlatStyle.Flat;
            btnmedinv.Font = new Font("MS UI Gothic", 9.75F, FontStyle.Bold);
            btnmedinv.ForeColor = Color.White;
            btnmedinv.Image = (Image)resources.GetObject("btnmedinv.Image");
            btnmedinv.ImageAlign = ContentAlignment.MiddleLeft;
            btnmedinv.Location = new Point(0, 487);
            btnmedinv.Name = "btnmedinv";
            btnmedinv.Padding = new Padding(20, 0, 0, 0);
            btnmedinv.Size = new Size(261, 72);
            btnmedinv.TabIndex = 4;
            btnmedinv.Text = "Medicine Inventory";
            btnmedinv.UseVisualStyleBackColor = true;
            btnmedinv.Click += btnmedinv_Click;
            // 
            // btnreturnlogin
            // 
            btnreturnlogin.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnreturnlogin.FlatAppearance.BorderColor = Color.FromArgb(3, 76, 129);
            btnreturnlogin.FlatStyle = FlatStyle.Flat;
            btnreturnlogin.Font = new Font("MS UI Gothic", 9.75F, FontStyle.Bold);
            btnreturnlogin.ForeColor = Color.White;
            btnreturnlogin.Image = (Image)resources.GetObject("btnreturnlogin.Image");
            btnreturnlogin.ImageAlign = ContentAlignment.MiddleLeft;
            btnreturnlogin.Location = new Point(0, 738);
            btnreturnlogin.Name = "btnreturnlogin";
            btnreturnlogin.Padding = new Padding(20, 0, 0, 0);
            btnreturnlogin.Size = new Size(261, 72);
            btnreturnlogin.TabIndex = 2;
            btnreturnlogin.Text = "Log Out";
            btnreturnlogin.UseVisualStyleBackColor = true;
            btnreturnlogin.Click += btnreturnlogin_Click;
            // 
            // btnpatientdatabase
            // 
            btnpatientdatabase.FlatAppearance.BorderColor = Color.FromArgb(3, 76, 129);
            btnpatientdatabase.FlatStyle = FlatStyle.Flat;
            btnpatientdatabase.Font = new Font("MS UI Gothic", 9.75F, FontStyle.Bold);
            btnpatientdatabase.ForeColor = Color.White;
            btnpatientdatabase.Image = (Image)resources.GetObject("btnpatientdatabase.Image");
            btnpatientdatabase.ImageAlign = ContentAlignment.MiddleLeft;
            btnpatientdatabase.Location = new Point(0, 409);
            btnpatientdatabase.Name = "btnpatientdatabase";
            btnpatientdatabase.Padding = new Padding(20, 0, 0, 0);
            btnpatientdatabase.Size = new Size(261, 72);
            btnpatientdatabase.TabIndex = 1;
            btnpatientdatabase.Text = "Patient Database";
            btnpatientdatabase.UseVisualStyleBackColor = true;
            btnpatientdatabase.Click += btnpatientdatabase_Click;
            // 
            // btnuserdatabase
            // 
            btnuserdatabase.FlatAppearance.BorderColor = Color.FromArgb(3, 76, 129);
            btnuserdatabase.FlatStyle = FlatStyle.Flat;
            btnuserdatabase.Font = new Font("MS UI Gothic", 9.75F, FontStyle.Bold);
            btnuserdatabase.ForeColor = Color.White;
            btnuserdatabase.Image = (Image)resources.GetObject("btnuserdatabase.Image");
            btnuserdatabase.ImageAlign = ContentAlignment.MiddleLeft;
            btnuserdatabase.Location = new Point(0, 331);
            btnuserdatabase.Name = "btnuserdatabase";
            btnuserdatabase.Padding = new Padding(20, 0, 0, 0);
            btnuserdatabase.Size = new Size(261, 72);
            btnuserdatabase.TabIndex = 0;
            btnuserdatabase.Text = "User Database";
            btnuserdatabase.UseVisualStyleBackColor = true;
            btnuserdatabase.Click += btnuserdatabase_Click;
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(261, 0);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1198, 811);
            mainpanel.TabIndex = 3;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1459, 811);
            Controls.Add(mainpanel);
            Controls.Add(panelside);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Admin";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Admin ";
            WindowState = FormWindowState.Maximized;
            Load += MainMenu_Load;
            panelside.ResumeLayout(false);
            panelside.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelside;
        private Panel mainpanel;
        private Button btnuserdatabase;
        private Button btnreturnlogin;
        private Button btnpatientdatabase;
        private Button btnmedinv;
        private Label label1;
        private Button btndashboard;
        private PictureBox pictureBox1;
    }
}