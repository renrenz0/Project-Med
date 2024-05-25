namespace Prot_MedProj
{
    partial class Appointment
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
            dgvupcomingappoints = new DataGridView();
            dgvpatientappnt = new DataGridView();
            groupBox1 = new GroupBox();
            label10 = new Label();
            txtphonenum = new TextBox();
            label9 = new Label();
            txtfirstname = new TextBox();
            label8 = new Label();
            dtpcalendar = new MonthCalendar();
            txtemail = new TextBox();
            label7 = new Label();
            txtlastname = new TextBox();
            label6 = new Label();
            txtappdesc = new TextBox();
            dtptime = new DateTimePicker();
            dtpdate = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            txtpatid = new TextBox();
            label1 = new Label();
            label15 = new Label();
            label14 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            btnappoint = new Button();
            label5 = new Label();
            txtsearch = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            btnappointclear = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvupcomingappoints).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvpatientappnt).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvupcomingappoints
            // 
            dgvupcomingappoints.AllowUserToAddRows = false;
            dgvupcomingappoints.AllowUserToDeleteRows = false;
            dgvupcomingappoints.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvupcomingappoints.BackgroundColor = Color.White;
            dgvupcomingappoints.BorderStyle = BorderStyle.None;
            dgvupcomingappoints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvupcomingappoints.GridColor = Color.White;
            dgvupcomingappoints.Location = new Point(879, 725);
            dgvupcomingappoints.Name = "dgvupcomingappoints";
            dgvupcomingappoints.ReadOnly = true;
            dgvupcomingappoints.RowHeadersVisible = false;
            dgvupcomingappoints.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvupcomingappoints.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvupcomingappoints.Size = new Size(794, 275);
            dgvupcomingappoints.TabIndex = 9;
            // 
            // dgvpatientappnt
            // 
            dgvpatientappnt.AllowUserToAddRows = false;
            dgvpatientappnt.AllowUserToDeleteRows = false;
            dgvpatientappnt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvpatientappnt.BackgroundColor = Color.White;
            dgvpatientappnt.BorderStyle = BorderStyle.None;
            dgvpatientappnt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvpatientappnt.GridColor = Color.White;
            dgvpatientappnt.Location = new Point(878, 186);
            dgvpatientappnt.Name = "dgvpatientappnt";
            dgvpatientappnt.ReadOnly = true;
            dgvpatientappnt.RowHeadersVisible = false;
            dgvpatientappnt.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvpatientappnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvpatientappnt.Size = new Size(794, 488);
            dgvpatientappnt.TabIndex = 10;
            dgvpatientappnt.CellClick += dgvpatientappnt_CellClick;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(127, 133, 140);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtphonenum);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(txtfirstname);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(dtpcalendar);
            groupBox1.Controls.Add(txtemail);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(txtlastname);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtappdesc);
            groupBox1.Controls.Add(dtptime);
            groupBox1.Controls.Add(dtpdate);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtpatid);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(label18);
            groupBox1.ForeColor = Color.White;
            groupBox1.Location = new Point(25, 149);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(819, 756);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "Set Appointment";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(92, 280);
            label10.Name = "label10";
            label10.Size = new Size(156, 16);
            label10.TabIndex = 17;
            label10.Text = "Patient Information";
            // 
            // txtphonenum
            // 
            txtphonenum.BackColor = Color.FromArgb(127, 133, 140);
            txtphonenum.BorderStyle = BorderStyle.None;
            txtphonenum.Font = new Font("MS UI Gothic", 12F);
            txtphonenum.ForeColor = Color.White;
            txtphonenum.Location = new Point(568, 306);
            txtphonenum.Name = "txtphonenum";
            txtphonenum.ReadOnly = true;
            txtphonenum.Size = new Size(162, 16);
            txtphonenum.TabIndex = 16;
            txtphonenum.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("MS UI Gothic", 12F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(602, 333);
            label9.Name = "label9";
            label9.Size = new Size(106, 16);
            label9.TabIndex = 15;
            label9.Text = "Phone Number";
            // 
            // txtfirstname
            // 
            txtfirstname.BackColor = Color.FromArgb(127, 133, 140);
            txtfirstname.BorderStyle = BorderStyle.None;
            txtfirstname.Font = new Font("MS UI Gothic", 12F);
            txtfirstname.ForeColor = Color.White;
            txtfirstname.Location = new Point(568, 215);
            txtfirstname.Name = "txtfirstname";
            txtfirstname.ReadOnly = true;
            txtfirstname.Size = new Size(162, 16);
            txtfirstname.TabIndex = 14;
            txtfirstname.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("MS UI Gothic", 12F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(617, 243);
            label8.Name = "label8";
            label8.Size = new Size(74, 16);
            label8.TabIndex = 13;
            label8.Text = "Firstname";
            // 
            // dtpcalendar
            // 
            dtpcalendar.BackColor = SystemColors.Window;
            dtpcalendar.CalendarDimensions = new Size(2, 1);
            dtpcalendar.Location = new Point(87, 28);
            dtpcalendar.Name = "dtpcalendar";
            dtpcalendar.TabIndex = 12;
            dtpcalendar.TitleBackColor = SystemColors.MenuHighlight;
            dtpcalendar.TrailingForeColor = SystemColors.GradientActiveCaption;
            dtpcalendar.DateChanged += dtpcalendar_DateChanged;
            // 
            // txtemail
            // 
            txtemail.BackColor = Color.FromArgb(127, 133, 140);
            txtemail.BorderStyle = BorderStyle.None;
            txtemail.Font = new Font("MS UI Gothic", 12F);
            txtemail.ForeColor = Color.White;
            txtemail.Location = new Point(305, 306);
            txtemail.Name = "txtemail";
            txtemail.ReadOnly = true;
            txtemail.Size = new Size(162, 16);
            txtemail.TabIndex = 11;
            txtemail.TextAlign = HorizontalAlignment.Center;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("MS UI Gothic", 12F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(368, 333);
            label7.Name = "label7";
            label7.Size = new Size(42, 16);
            label7.TabIndex = 10;
            label7.Text = "Email";
            // 
            // txtlastname
            // 
            txtlastname.BackColor = Color.FromArgb(127, 133, 140);
            txtlastname.BorderStyle = BorderStyle.None;
            txtlastname.Font = new Font("MS UI Gothic", 12F);
            txtlastname.ForeColor = Color.White;
            txtlastname.Location = new Point(305, 215);
            txtlastname.Name = "txtlastname";
            txtlastname.ReadOnly = true;
            txtlastname.Size = new Size(162, 16);
            txtlastname.TabIndex = 9;
            txtlastname.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("MS UI Gothic", 12F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(357, 244);
            label6.Name = "label6";
            label6.Size = new Size(73, 16);
            label6.TabIndex = 8;
            label6.Text = "Lastname";
            // 
            // txtappdesc
            // 
            txtappdesc.BackColor = Color.FromArgb(127, 133, 140);
            txtappdesc.BorderStyle = BorderStyle.None;
            txtappdesc.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtappdesc.ForeColor = Color.White;
            txtappdesc.Location = new Point(30, 591);
            txtappdesc.Multiline = true;
            txtappdesc.Name = "txtappdesc";
            txtappdesc.Size = new Size(751, 92);
            txtappdesc.TabIndex = 7;
            // 
            // dtptime
            // 
            dtptime.CalendarFont = new Font("MS UI Gothic", 9F);
            dtptime.Format = DateTimePickerFormat.Time;
            dtptime.Location = new Point(290, 471);
            dtptime.Name = "dtptime";
            dtptime.Size = new Size(473, 23);
            dtptime.TabIndex = 6;
            // 
            // dtpdate
            // 
            dtpdate.CalendarFont = new Font("MS UI Gothic", 9F);
            dtpdate.Location = new Point(290, 399);
            dtpdate.Name = "dtpdate";
            dtpdate.Size = new Size(473, 23);
            dtpdate.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 558);
            label4.Name = "label4";
            label4.Size = new Size(195, 16);
            label4.TabIndex = 4;
            label4.Text = "Appointment Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(90, 477);
            label3.Name = "label3";
            label3.Size = new Size(145, 16);
            label3.TabIndex = 3;
            label3.Text = "Appointment Time";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(92, 405);
            label2.Name = "label2";
            label2.Size = new Size(145, 16);
            label2.TabIndex = 2;
            label2.Text = "Appointment Date";
            // 
            // txtpatid
            // 
            txtpatid.BackColor = Color.FromArgb(127, 133, 140);
            txtpatid.BorderStyle = BorderStyle.None;
            txtpatid.ForeColor = Color.White;
            txtpatid.Location = new Point(728, 31);
            txtpatid.Name = "txtpatid";
            txtpatid.ReadOnly = true;
            txtpatid.Size = new Size(53, 16);
            txtpatid.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(627, 31);
            label1.Name = "label1";
            label1.Size = new Size(82, 16);
            label1.TabIndex = 0;
            label1.Text = "Patient No.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.FromArgb(127, 133, 140);
            label15.ForeColor = Color.White;
            label15.Location = new Point(305, 226);
            label15.Name = "label15";
            label15.Size = new Size(162, 15);
            label15.TabIndex = 23;
            label15.Text = "_______________________________";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.FromArgb(127, 133, 140);
            label14.ForeColor = Color.White;
            label14.Location = new Point(305, 316);
            label14.Name = "label14";
            label14.Size = new Size(162, 15);
            label14.TabIndex = 22;
            label14.Text = "_______________________________";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.FromArgb(127, 133, 140);
            label16.ForeColor = Color.White;
            label16.Location = new Point(568, 225);
            label16.Name = "label16";
            label16.Size = new Size(162, 15);
            label16.TabIndex = 24;
            label16.Text = "_______________________________";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.FromArgb(127, 133, 140);
            label17.ForeColor = Color.White;
            label17.Location = new Point(568, 316);
            label17.Name = "label17";
            label17.Size = new Size(162, 15);
            label17.TabIndex = 25;
            label17.Text = "_______________________________";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.ForeColor = Color.White;
            label18.Location = new Point(30, 678);
            label18.Name = "label18";
            label18.Size = new Size(752, 15);
            label18.TabIndex = 22;
            label18.Text = "_____________________________________________________________________________________________________________________________________________________";
            // 
            // btnappoint
            // 
            btnappoint.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnappoint.BackColor = Color.FromArgb(127, 133, 140);
            btnappoint.FlatAppearance.BorderColor = Color.FromArgb(241, 246, 254);
            btnappoint.FlatStyle = FlatStyle.Flat;
            btnappoint.Font = new Font("MS UI Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnappoint.ForeColor = Color.White;
            btnappoint.Location = new Point(698, 961);
            btnappoint.Name = "btnappoint";
            btnappoint.Size = new Size(146, 39);
            btnappoint.TabIndex = 12;
            btnappoint.Text = "APPOINT";
            btnappoint.UseVisualStyleBackColor = false;
            btnappoint.Click += btnappoint_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(878, 694);
            label5.Name = "label5";
            label5.Size = new Size(225, 19);
            label5.TabIndex = 14;
            label5.Text = "Upcoming Appointments";
            // 
            // txtsearch
            // 
            txtsearch.BackColor = Color.FromArgb(241, 246, 254);
            txtsearch.BorderStyle = BorderStyle.None;
            txtsearch.Font = new Font("MS UI Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtsearch.Location = new Point(966, 152);
            txtsearch.Name = "txtsearch";
            txtsearch.PlaceholderText = "Patient Lastname / Firstname";
            txtsearch.Size = new Size(706, 16);
            txtsearch.TabIndex = 19;
            txtsearch.TextChanged += txtsearch_TextChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("MS UI Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(894, 157);
            label11.Name = "label11";
            label11.Size = new Size(61, 16);
            label11.TabIndex = 18;
            label11.Text = "Search";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("MS UI Gothic", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(25, 21);
            label12.Name = "label12";
            label12.Size = new Size(295, 37);
            label12.TabIndex = 20;
            label12.Text = "APPOINTMENTS";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Location = new Point(966, 161);
            label13.Name = "label13";
            label13.Size = new Size(707, 15);
            label13.TabIndex = 21;
            label13.Text = "____________________________________________________________________________________________________________________________________________";
            // 
            // btnappointclear
            // 
            btnappointclear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnappointclear.BackColor = Color.FromArgb(127, 133, 140);
            btnappointclear.FlatAppearance.BorderColor = Color.FromArgb(241, 246, 254);
            btnappointclear.FlatStyle = FlatStyle.Flat;
            btnappointclear.Font = new Font("MS UI Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnappointclear.ForeColor = Color.White;
            btnappointclear.Location = new Point(520, 961);
            btnappointclear.Name = "btnappointclear";
            btnappointclear.Size = new Size(172, 39);
            btnappointclear.TabIndex = 22;
            btnappointclear.Text = "CLEAR APPOINTMENT";
            btnappointclear.UseVisualStyleBackColor = false;
            btnappointclear.Click += btnappointclear_Click;
            // 
            // Appointment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bgbg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1684, 1024);
            Controls.Add(btnappointclear);
            Controls.Add(label12);
            Controls.Add(txtsearch);
            Controls.Add(label11);
            Controls.Add(label5);
            Controls.Add(btnappoint);
            Controls.Add(groupBox1);
            Controls.Add(dgvpatientappnt);
            Controls.Add(dgvupcomingappoints);
            Controls.Add(label13);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Appointment";
            Text = "Appointment";
            Load += Appointment_Load;
            ((System.ComponentModel.ISupportInitialize)dgvupcomingappoints).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvpatientappnt).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvupcomingappoints;
        private DataGridView dgvpatientappnt;
        private GroupBox groupBox1;
        private TextBox txtpatid;
        private Label label1;
        private TextBox txtappdesc;
        private DateTimePicker dtptime;
        private DateTimePicker dtpdate;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnappoint;
        private Label label5;
        private MonthCalendar dtpcalendar;
        private TextBox txtemail;
        private Label label7;
        private TextBox txtlastname;
        private Label label6;
        private Label label10;
        private TextBox txtphonenum;
        private Label label9;
        private TextBox txtfirstname;
        private Label label8;
        private TextBox txtsearch;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Button btnappointclear;
    }
}