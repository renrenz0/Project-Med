namespace Prot_MedProj
{
    partial class Signin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Signin));
            cmbuser = new ComboBox();
            txtuser = new TextBox();
            btnlogin = new Button();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            txtpassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // cmbuser
            // 
            cmbuser.BackColor = Color.White;
            cmbuser.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbuser.FlatStyle = FlatStyle.System;
            cmbuser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbuser.FormattingEnabled = true;
            cmbuser.Items.AddRange(new object[] { "Admin", "Doctor", "Front-desk" });
            cmbuser.Location = new Point(185, 317);
            cmbuser.Name = "cmbuser";
            cmbuser.Size = new Size(155, 29);
            cmbuser.Sorted = true;
            cmbuser.TabIndex = 0;
            cmbuser.SelectedIndexChanged += cmbuser_SelectedIndexChanged;
            // 
            // txtuser
            // 
            txtuser.Location = new Point(212, 261);
            txtuser.Name = "txtuser";
            txtuser.Size = new Size(100, 23);
            txtuser.TabIndex = 1;
            txtuser.Visible = false;
            // 
            // btnlogin
            // 
            btnlogin.FlatAppearance.BorderColor = Color.White;
            btnlogin.FlatStyle = FlatStyle.Popup;
            btnlogin.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnlogin.Location = new Point(185, 432);
            btnlogin.Name = "btnlogin";
            btnlogin.Size = new Size(155, 36);
            btnlogin.TabIndex = 3;
            btnlogin.Text = "Login";
            btnlogin.UseVisualStyleBackColor = true;
            btnlogin.Click += btnlogin_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(38, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(438, 404);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(183, 380);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 6;
            label1.Text = "______________________________";
            // 
            // txtpassword
            // 
            txtpassword.BorderStyle = BorderStyle.None;
            txtpassword.Location = new Point(185, 372);
            txtpassword.Name = "txtpassword";
            txtpassword.Size = new Size(155, 16);
            txtpassword.TabIndex = 7;
            txtpassword.TextAlign = HorizontalAlignment.Center;
            txtpassword.UseSystemPasswordChar = true;
            // 
            // Signin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(509, 491);
            Controls.Add(txtpassword);
            Controls.Add(btnlogin);
            Controls.Add(cmbuser);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(txtuser);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Signin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RURAL-HEALTH";
            FormClosing += Signin_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbuser;
        private TextBox txtuser;
        private Button btnlogin;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txtpassword;
    }
}