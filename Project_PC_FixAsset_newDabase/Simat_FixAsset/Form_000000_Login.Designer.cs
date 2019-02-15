namespace SimatSoft.FixAsset
{
    partial class Form_000000_LOGIN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_000000_LOGIN));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LBL_Company = new System.Windows.Forms.Label();
            this.sS_ComboBox_Company = new SimatSoft.CustomControl.SS_ComboBox();
            this.LBL_Language = new System.Windows.Forms.Label();
            this.sS_ComboBox_Language = new SimatSoft.CustomControl.SS_ComboBox();
            this.Button_Config = new System.Windows.Forms.Button();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.Button_Exit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Button_Login = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LBL_UserID = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.fadeTimer = new System.Windows.Forms.Timer(this.components);
            this.sS_MaskedTextBox_Password = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_UserID = new SimatSoft.CustomControl.SS_MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(657, 84);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.LBL_Company);
            this.panel1.Controls.Add(this.sS_ComboBox_Company);
            this.panel1.Controls.Add(this.LBL_Language);
            this.panel1.Controls.Add(this.sS_ComboBox_Language);
            this.panel1.Controls.Add(this.Button_Config);
            this.panel1.Controls.Add(this.Button_Exit);
            this.panel1.Controls.Add(this.Button_Login);
            this.panel1.Location = new System.Drawing.Point(0, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 60);
            this.panel1.TabIndex = 1;
            // 
            // LBL_Company
            // 
            this.LBL_Company.AutoSize = true;
            this.LBL_Company.BackColor = System.Drawing.Color.Black;
            this.LBL_Company.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_Company.ForeColor = System.Drawing.Color.White;
            this.LBL_Company.Location = new System.Drawing.Point(161, 23);
            this.LBL_Company.Name = "LBL_Company";
            this.LBL_Company.Size = new System.Drawing.Size(62, 13);
            this.LBL_Company.TabIndex = 9;
            this.LBL_Company.Text = "Company:";
            // 
            // sS_ComboBox_Company
            // 
            this.sS_ComboBox_Company.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Company.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Company.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Company.Enabled = false;
            this.sS_ComboBox_Company.FormattingEnabled = true;
            this.sS_ComboBox_Company.Location = new System.Drawing.Point(223, 20);
            this.sS_ComboBox_Company.Name = "sS_ComboBox_Company";
            this.sS_ComboBox_Company.Size = new System.Drawing.Size(92, 21);
            this.sS_ComboBox_Company.TabIndex = 8;
            this.sS_ComboBox_Company.Text = "CEVA";
            // 
            // LBL_Language
            // 
            this.LBL_Language.AutoSize = true;
            this.LBL_Language.BackColor = System.Drawing.Color.Black;
            this.LBL_Language.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.LBL_Language.ForeColor = System.Drawing.Color.White;
            this.LBL_Language.Location = new System.Drawing.Point(3, 23);
            this.LBL_Language.Name = "LBL_Language";
            this.LBL_Language.Size = new System.Drawing.Size(67, 13);
            this.LBL_Language.TabIndex = 5;
            this.LBL_Language.Text = "Language:";
            // 
            // sS_ComboBox_Language
            // 
            this.sS_ComboBox_Language.BackColor = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Language.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Language.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Language.FormattingEnabled = true;
            this.sS_ComboBox_Language.Items.AddRange(new object[] {
            "Thai",
            "English"});
            this.sS_ComboBox_Language.Location = new System.Drawing.Point(71, 20);
            this.sS_ComboBox_Language.Name = "sS_ComboBox_Language";
            this.sS_ComboBox_Language.Size = new System.Drawing.Size(84, 21);
            this.sS_ComboBox_Language.TabIndex = 4;
            this.sS_ComboBox_Language.SelectedIndexChanged += new System.EventHandler(this.sS_ComboBox_Language_SelectedIndexChanged);
            // 
            // Button_Config
            // 
            this.Button_Config.AutoSize = true;
            this.Button_Config.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Button_Config.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Config.ImageIndex = 0;
            this.Button_Config.ImageList = this.imageList2;
            this.Button_Config.Location = new System.Drawing.Point(600, 13);
            this.Button_Config.Name = "Button_Config";
            this.Button_Config.Size = new System.Drawing.Size(54, 34);
            this.Button_Config.TabIndex = 3;
            this.Button_Config.Text = "Server";
            this.Button_Config.UseVisualStyleBackColor = true;
            this.Button_Config.Click += new System.EventHandler(this.Button_Config_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "db.png");
            // 
            // Button_Exit
            // 
            this.Button_Exit.AutoSize = true;
            this.Button_Exit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button_Exit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Exit.ImageIndex = 1;
            this.Button_Exit.ImageList = this.imageList1;
            this.Button_Exit.Location = new System.Drawing.Point(461, 12);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(133, 40);
            this.Button_Exit.TabIndex = 2;
            this.Button_Exit.Text = "          Exit";
            this.Button_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "processlogin.png");
            this.imageList1.Images.SetKeyName(1, "bttExit.png");
            this.imageList1.Images.SetKeyName(2, "login_onclick.png");
            this.imageList1.Images.SetKeyName(3, "bttExit_onclick.png");
            // 
            // Button_Login
            // 
            this.Button_Login.AutoSize = true;
            this.Button_Login.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Button_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Button_Login.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_Login.ImageIndex = 0;
            this.Button_Login.ImageList = this.imageList1;
            this.Button_Login.Location = new System.Drawing.Point(324, 12);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(133, 40);
            this.Button_Login.TabIndex = 1;
            this.Button_Login.Text = "          Login";
            this.Button_Login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Login.UseVisualStyleBackColor = true;
            this.Button_Login.Click += new System.EventHandler(this.Button_Login_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(4, 86);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(98, 52);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // LBL_UserID
            // 
            this.LBL_UserID.AutoSize = true;
            this.LBL_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LBL_UserID.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LBL_UserID.Location = new System.Drawing.Point(265, 228);
            this.LBL_UserID.Name = "LBL_UserID";
            this.LBL_UserID.Size = new System.Drawing.Size(59, 15);
            this.LBL_UserID.TabIndex = 4;
            this.LBL_UserID.Text = "User ID:";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.LBL_Password.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.LBL_Password.Location = new System.Drawing.Point(265, 266);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(73, 15);
            this.LBL_Password.TabIndex = 5;
            this.LBL_Password.Text = "Password:";
            // 
            // fadeTimer
            // 
            this.fadeTimer.Interval = 70;
            this.fadeTimer.Tick += new System.EventHandler(this.fadeTimer_Tick);
            // 
            // sS_MaskedTextBox_Password
            // 
            this.sS_MaskedTextBox_Password.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Password.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_Password.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_Password.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Password.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_Password.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_Password.IconError = null;
            this.sS_MaskedTextBox_Password.IconTrue = null;
            this.sS_MaskedTextBox_Password.Location = new System.Drawing.Point(348, 261);
            this.sS_MaskedTextBox_Password.Masked = SimatSoft.CustomControl.Mask.Password;
            this.sS_MaskedTextBox_Password.Name = "sS_MaskedTextBox_Password";
            this.sS_MaskedTextBox_Password.Size = new System.Drawing.Size(126, 23);
            this.sS_MaskedTextBox_Password.TabIndex = 7;
            this.sS_MaskedTextBox_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_Password_KeyPress);
            // 
            // sS_MaskedTextBox_UserID
            // 
            this.sS_MaskedTextBox_UserID.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserID.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_UserID.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserID.BoolChangeFontOnFocus = false;
            this.sS_MaskedTextBox_UserID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserID.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserID.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_UserID.IconError = null;
            this.sS_MaskedTextBox_UserID.IconTrue = null;
            this.sS_MaskedTextBox_UserID.Location = new System.Drawing.Point(348, 223);
            this.sS_MaskedTextBox_UserID.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_UserID.Name = "sS_MaskedTextBox_UserID";
            this.sS_MaskedTextBox_UserID.Size = new System.Drawing.Size(126, 23);
            this.sS_MaskedTextBox_UserID.TabIndex = 6;
            this.sS_MaskedTextBox_UserID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.sS_MaskedTextBox_UserID_KeyPress);
            // 
            // Form_000000_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(658, 421);
            this.ControlBox = false;
            this.Controls.Add(this.sS_MaskedTextBox_Password);
            this.Controls.Add(this.sS_MaskedTextBox_UserID);
            this.Controls.Add(this.LBL_Password);
            this.Controls.Add(this.LBL_UserID);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_000000_LOGIN";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID:000000(xxx)";
            this.Load += new System.EventHandler(this.Form_001000_LOGIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.Button Button_Login;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label LBL_UserID;
        private System.Windows.Forms.Label LBL_Password;
        
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_UserID;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Password;
        private System.Windows.Forms.Button Button_Config;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label LBL_Language;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Language;
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.Label LBL_Company;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Company;
    }
}