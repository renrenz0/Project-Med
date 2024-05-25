namespace Prot_MedProj
{
    partial class Front_Desk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Front_Desk));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnlogout = new Button();
            btninventory = new Button();
            btnappoint = new Button();
            btnregis = new Button();
            label1 = new Label();
            mainpanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(91, 162, 244);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btnlogout);
            panel1.Controls.Add(btninventory);
            panel1.Controls.Add(btnappoint);
            panel1.Controls.Add(btnregis);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.ForeColor = Color.FromArgb(91, 162, 244);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 811);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(52, 21);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(135, 134);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnlogout
            // 
            btnlogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnlogout.FlatAppearance.BorderColor = Color.FromArgb(91, 162, 244);
            btnlogout.FlatStyle = FlatStyle.Flat;
            btnlogout.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnlogout.ForeColor = Color.White;
            btnlogout.Image = (Image)resources.GetObject("btnlogout.Image");
            btnlogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnlogout.Location = new Point(0, 739);
            btnlogout.Name = "btnlogout";
            btnlogout.Padding = new Padding(20, 0, 0, 0);
            btnlogout.Size = new Size(274, 72);
            btnlogout.TabIndex = 3;
            btnlogout.Text = "Log Out";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnlogout_Click;
            // 
            // btninventory
            // 
            btninventory.FlatAppearance.BorderColor = Color.FromArgb(91, 162, 244);
            btninventory.FlatStyle = FlatStyle.Flat;
            btninventory.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btninventory.ForeColor = Color.White;
            btninventory.Image = (Image)resources.GetObject("btninventory.Image");
            btninventory.ImageAlign = ContentAlignment.MiddleLeft;
            btninventory.Location = new Point(0, 409);
            btninventory.Name = "btninventory";
            btninventory.Padding = new Padding(20, 0, 0, 0);
            btninventory.Size = new Size(274, 72);
            btninventory.TabIndex = 2;
            btninventory.Text = "Manage Inventory";
            btninventory.UseVisualStyleBackColor = true;
            btninventory.Click += btninventory_Click;
            // 
            // btnappoint
            // 
            btnappoint.FlatAppearance.BorderColor = Color.FromArgb(91, 162, 244);
            btnappoint.FlatStyle = FlatStyle.Flat;
            btnappoint.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnappoint.ForeColor = Color.White;
            btnappoint.Image = (Image)resources.GetObject("btnappoint.Image");
            btnappoint.ImageAlign = ContentAlignment.MiddleLeft;
            btnappoint.Location = new Point(0, 331);
            btnappoint.Name = "btnappoint";
            btnappoint.Padding = new Padding(20, 0, 0, 0);
            btnappoint.Size = new Size(274, 72);
            btnappoint.TabIndex = 1;
            btnappoint.Text = "Appointments";
            btnappoint.UseVisualStyleBackColor = true;
            btnappoint.Click += btnappoint_Click;
            // 
            // btnregis
            // 
            btnregis.FlatAppearance.BorderColor = Color.FromArgb(91, 162, 244);
            btnregis.FlatStyle = FlatStyle.Flat;
            btnregis.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            btnregis.ForeColor = Color.White;
            btnregis.Image = (Image)resources.GetObject("btnregis.Image");
            btnregis.ImageAlign = ContentAlignment.MiddleLeft;
            btnregis.Location = new Point(0, 253);
            btnregis.Name = "btnregis";
            btnregis.Padding = new Padding(20, 0, 0, 0);
            btnregis.Size = new Size(274, 72);
            btnregis.TabIndex = 0;
            btnregis.Text = "Register Patient";
            btnregis.UseVisualStyleBackColor = true;
            btnregis.Click += btnregis_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(24, 171);
            label1.Name = "label1";
            label1.Size = new Size(192, 29);
            label1.TabIndex = 0;
            label1.Text = "FRONT DESK";
            // 
            // mainpanel
            // 
            mainpanel.Dock = DockStyle.Fill;
            mainpanel.Location = new Point(233, 0);
            mainpanel.Name = "mainpanel";
            mainpanel.Size = new Size(1226, 811);
            mainpanel.TabIndex = 1;
            // 
            // Front_Desk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 811);
            Controls.Add(mainpanel);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Front_Desk";
            Text = "Front Desk";
            WindowState = FormWindowState.Maximized;
            Load += Front_Desk_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel mainpanel;
        private Label label1;
        private Button btnregis;
        private Button btnlogout;
        private Button btninventory;
        private Button btnappoint;
        private PictureBox pictureBox1;
    }
}