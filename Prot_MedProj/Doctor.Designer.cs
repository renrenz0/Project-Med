namespace Prot_MedProj
{
    partial class Doctor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doctor));
            panelside = new Panel();
            pictureBox1 = new PictureBox();
            btnpatdiag = new Button();
            btnlogout = new Button();
            btnappoint = new Button();
            label1 = new Label();
            mainpanel = new Panel();
            panelside.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelside
            // 
            panelside.BackColor = Color.FromArgb(44, 163, 250);
            panelside.Controls.Add(pictureBox1);
            panelside.Controls.Add(btnpatdiag);
            panelside.Controls.Add(btnlogout);
            panelside.Controls.Add(btnappoint);
            panelside.Controls.Add(label1);
            panelside.Dock = DockStyle.Left;
            panelside.Location = new Point(0, 0);
            panelside.Name = "panelside";
            panelside.Size = new Size(233, 811);
            panelside.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(45, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 134);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // btnpatdiag
            // 
            btnpatdiag.BackColor = Color.FromArgb(44, 163, 250);
            btnpatdiag.FlatAppearance.BorderColor = Color.FromArgb(44, 163, 250);
            btnpatdiag.FlatStyle = FlatStyle.Flat;
            btnpatdiag.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnpatdiag.ForeColor = Color.White;
            btnpatdiag.Image = (Image)resources.GetObject("btnpatdiag.Image");
            btnpatdiag.ImageAlign = ContentAlignment.MiddleLeft;
            btnpatdiag.Location = new Point(0, 253);
            btnpatdiag.Name = "btnpatdiag";
            btnpatdiag.Padding = new Padding(20, 0, 0, 0);
            btnpatdiag.Size = new Size(274, 72);
            btnpatdiag.TabIndex = 5;
            btnpatdiag.Text = "Patient Diagnosis";
            btnpatdiag.UseVisualStyleBackColor = false;
            btnpatdiag.Click += btnpatdiag_Click;
            // 
            // btnlogout
            // 
            btnlogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnlogout.BackColor = Color.FromArgb(44, 163, 250);
            btnlogout.FlatAppearance.BorderColor = Color.FromArgb(44, 163, 250);
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnlogout.ForeColor = Color.White;
            btnlogout.Image = (Image)resources.GetObject("btnlogout.Image");
            btnlogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnlogout.Location = new Point(0, 736);
            btnlogout.Name = "btnlogout";
            btnlogout.Padding = new Padding(20, 0, 0, 0);
            btnlogout.Size = new Size(274, 72);
            btnlogout.TabIndex = 3;
            btnlogout.Text = "Log Out";
            btnlogout.UseVisualStyleBackColor = false;
            btnlogout.Click += btnlogout_Click;
            // 
            // btnappoint
            // 
            btnappoint.BackColor = Color.FromArgb(44, 163, 250);
            btnappoint.FlatAppearance.BorderColor = Color.FromArgb(44, 163, 250);
            btnappoint.FlatStyle = FlatStyle.Flat;
            btnappoint.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnappoint.ForeColor = Color.White;
            btnappoint.Image = (Image)resources.GetObject("btnappoint.Image");
            btnappoint.ImageAlign = ContentAlignment.MiddleLeft;
            btnappoint.Location = new Point(0, 331);
            btnappoint.Name = "btnappoint";
            btnappoint.Padding = new Padding(20, 0, 0, 0);
            btnappoint.Size = new Size(274, 72);
            btnappoint.TabIndex = 2;
            btnappoint.Text = "Appointments";
            btnappoint.UseVisualStyleBackColor = false;
            btnappoint.Click += btnappoint_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(49, 171);
            label1.Name = "label1";
            label1.Size = new Size(134, 29);
            label1.TabIndex = 0;
            label1.Text = "DOCTOR";
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(233, 0);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1226, 811);
            mainpanel.TabIndex = 1;
            // 
            // Doctor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 811);
            Controls.Add(mainpanel);
            Controls.Add(panelside);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Doctor";
            Text = " Doctor";
            WindowState = FormWindowState.Maximized;
            Load += Doctor_Load;
            panelside.ResumeLayout(false);
            panelside.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelside;
        private Label label1;
        private Panel mainpanel;
        private Button btnappoint;
        private Button btnlogout;
        private Button btnpatdiag;
        private PictureBox pictureBox1;
    }
}