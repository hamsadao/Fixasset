namespace SimatSoft.FixAsset
{
    partial class Form_007000_DatabaseSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_007000_DatabaseSetup));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Button_SaveConfig = new System.Windows.Forms.Button();
            this.tabControl_Server = new System.Windows.Forms.TabControl();
            this.tabPage_DatabaseServer = new System.Windows.Forms.TabPage();
            this.sS_MaskedTextBox_ServerName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_Password = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_UserName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_DatabaseName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_DatabaseType = new SimatSoft.CustomControl.SS_ComboBox();
            this.LBL_DatabaseType = new System.Windows.Forms.Label();
            this.LBL_Password = new System.Windows.Forms.Label();
            this.LBL_UserName = new System.Windows.Forms.Label();
            this.LBL_DatabaseName = new System.Windows.Forms.Label();
            this.LBL_ServerName = new System.Windows.Forms.Label();
            this.tabPage_PictureServer = new System.Windows.Forms.TabPage();
            this.sS_MaskedTextBox_PictureServerName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_PicturePassword = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_PictureUserName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_MaskedTextBox_PictureDatabaseName = new SimatSoft.CustomControl.SS_MaskedTextBox();
            this.sS_ComboBox_PictureDatabaseType = new SimatSoft.CustomControl.SS_ComboBox();
            this.LBL_PictureDatabaseType = new System.Windows.Forms.Label();
            this.LBL_PicturePassword = new System.Windows.Forms.Label();
            this.LBL_PictureUserName = new System.Windows.Forms.Label();
            this.LBL_PictureDatabaseName = new System.Windows.Forms.Label();
            this.LBL_PictureServerName = new System.Windows.Forms.Label();
            this.tabPage_Language = new System.Windows.Forms.TabPage();
            this.sS_ComboBox_Language = new SimatSoft.CustomControl.SS_ComboBox();
            this.LBL_Language = new System.Windows.Forms.Label();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.tabControl_Server.SuspendLayout();
            this.tabPage_DatabaseServer.SuspendLayout();
            this.tabPage_PictureServer.SuspendLayout();
            this.tabPage_Language.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 36);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button_Cancel);
            this.panel1.Controls.Add(this.Button_SaveConfig);
            this.panel1.Controls.Add(this.tabControl_Server);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 293);
            this.panel1.TabIndex = 2;
            // 
            // button_Cancel
            // 
            this.button_Cancel.ImageIndex = 1;
            this.button_Cancel.ImageList = this.imageList1;
            this.button_Cancel.Location = new System.Drawing.Point(367, 223);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(80, 32);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "    Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bttsetupOk.png");
            this.imageList1.Images.SetKeyName(1, "bttsetupCancel.png");
            // 
            // Button_SaveConfig
            // 
            this.Button_SaveConfig.ImageIndex = 0;
            this.Button_SaveConfig.ImageList = this.imageList1;
            this.Button_SaveConfig.Location = new System.Drawing.Point(283, 223);
            this.Button_SaveConfig.Name = "Button_SaveConfig";
            this.Button_SaveConfig.Size = new System.Drawing.Size(78, 33);
            this.Button_SaveConfig.TabIndex = 1;
            this.Button_SaveConfig.Text = "OK";
            this.Button_SaveConfig.UseVisualStyleBackColor = true;
            this.Button_SaveConfig.Click += new System.EventHandler(this.button_SaveConfig_Click);
            // 
            // tabControl_Server
            // 
            this.tabControl_Server.Controls.Add(this.tabPage_DatabaseServer);
            this.tabControl_Server.Controls.Add(this.tabPage_PictureServer);
            this.tabControl_Server.Controls.Add(this.tabPage_Language);
            this.tabControl_Server.Location = new System.Drawing.Point(26, 17);
            this.tabControl_Server.Name = "tabControl_Server";
            this.tabControl_Server.SelectedIndex = 0;
            this.tabControl_Server.Size = new System.Drawing.Size(421, 200);
            this.tabControl_Server.TabIndex = 0;
            // 
            // tabPage_DatabaseServer
            // 
            this.tabPage_DatabaseServer.Controls.Add(this.sS_MaskedTextBox_ServerName);
            this.tabPage_DatabaseServer.Controls.Add(this.sS_MaskedTextBox_Password);
            this.tabPage_DatabaseServer.Controls.Add(this.sS_MaskedTextBox_UserName);
            this.tabPage_DatabaseServer.Controls.Add(this.sS_MaskedTextBox_DatabaseName);
            this.tabPage_DatabaseServer.Controls.Add(this.sS_ComboBox_DatabaseType);
            this.tabPage_DatabaseServer.Controls.Add(this.LBL_DatabaseType);
            this.tabPage_DatabaseServer.Controls.Add(this.LBL_Password);
            this.tabPage_DatabaseServer.Controls.Add(this.LBL_UserName);
            this.tabPage_DatabaseServer.Controls.Add(this.LBL_DatabaseName);
            this.tabPage_DatabaseServer.Controls.Add(this.LBL_ServerName);
            this.tabPage_DatabaseServer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_DatabaseServer.Name = "tabPage_DatabaseServer";
            this.tabPage_DatabaseServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DatabaseServer.Size = new System.Drawing.Size(413, 174);
            this.tabPage_DatabaseServer.TabIndex = 0;
            this.tabPage_DatabaseServer.Text = "Database Server";
            this.tabPage_DatabaseServer.UseVisualStyleBackColor = true;
            // 
            // sS_MaskedTextBox_ServerName
            // 
            this.sS_MaskedTextBox_ServerName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_ServerName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_ServerName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_ServerName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_ServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ServerName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_ServerName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_ServerName.IconError = null;
            this.sS_MaskedTextBox_ServerName.IconTrue = null;
            this.sS_MaskedTextBox_ServerName.Location = new System.Drawing.Point(153, 17);
            this.sS_MaskedTextBox_ServerName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_ServerName.Name = "sS_MaskedTextBox_ServerName";
            this.sS_MaskedTextBox_ServerName.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_ServerName.TabIndex = 28;
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
            this.sS_MaskedTextBox_Password.Location = new System.Drawing.Point(153, 95);
            this.sS_MaskedTextBox_Password.Masked = SimatSoft.CustomControl.Mask.Password;
            this.sS_MaskedTextBox_Password.Name = "sS_MaskedTextBox_Password";
            this.sS_MaskedTextBox_Password.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_Password.TabIndex = 31;
            // 
            // sS_MaskedTextBox_UserName
            // 
            this.sS_MaskedTextBox_UserName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_UserName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_UserName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_UserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_UserName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_UserName.IconError = null;
            this.sS_MaskedTextBox_UserName.IconTrue = null;
            this.sS_MaskedTextBox_UserName.Location = new System.Drawing.Point(153, 69);
            this.sS_MaskedTextBox_UserName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_UserName.Name = "sS_MaskedTextBox_UserName";
            this.sS_MaskedTextBox_UserName.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_UserName.TabIndex = 30;
            // 
            // sS_MaskedTextBox_DatabaseName
            // 
            this.sS_MaskedTextBox_DatabaseName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_DatabaseName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_DatabaseName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_DatabaseName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_DatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DatabaseName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_DatabaseName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_DatabaseName.IconError = null;
            this.sS_MaskedTextBox_DatabaseName.IconTrue = null;
            this.sS_MaskedTextBox_DatabaseName.Location = new System.Drawing.Point(153, 43);
            this.sS_MaskedTextBox_DatabaseName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_DatabaseName.Name = "sS_MaskedTextBox_DatabaseName";
            this.sS_MaskedTextBox_DatabaseName.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_DatabaseName.TabIndex = 29;
            // 
            // sS_ComboBox_DatabaseType
            // 
            this.sS_ComboBox_DatabaseType.BackColor = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_DatabaseType.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_DatabaseType.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_DatabaseType.FormattingEnabled = true;
            this.sS_ComboBox_DatabaseType.Items.AddRange(new object[] {
            "MsSql"});
            this.sS_ComboBox_DatabaseType.Location = new System.Drawing.Point(153, 121);
            this.sS_ComboBox_DatabaseType.Name = "sS_ComboBox_DatabaseType";
            this.sS_ComboBox_DatabaseType.Size = new System.Drawing.Size(214, 21);
            this.sS_ComboBox_DatabaseType.TabIndex = 32;
            // 
            // LBL_DatabaseType
            // 
            this.LBL_DatabaseType.AutoSize = true;
            this.LBL_DatabaseType.Location = new System.Drawing.Point(45, 129);
            this.LBL_DatabaseType.Name = "LBL_DatabaseType";
            this.LBL_DatabaseType.Size = new System.Drawing.Size(76, 13);
            this.LBL_DatabaseType.TabIndex = 26;
            this.LBL_DatabaseType.Text = "Database type";
            // 
            // LBL_Password
            // 
            this.LBL_Password.AutoSize = true;
            this.LBL_Password.Location = new System.Drawing.Point(45, 102);
            this.LBL_Password.Name = "LBL_Password";
            this.LBL_Password.Size = new System.Drawing.Size(53, 13);
            this.LBL_Password.TabIndex = 25;
            this.LBL_Password.Text = "Password";
            // 
            // LBL_UserName
            // 
            this.LBL_UserName.AutoSize = true;
            this.LBL_UserName.Location = new System.Drawing.Point(45, 76);
            this.LBL_UserName.Name = "LBL_UserName";
            this.LBL_UserName.Size = new System.Drawing.Size(58, 13);
            this.LBL_UserName.TabIndex = 24;
            this.LBL_UserName.Text = "User name";
            // 
            // LBL_DatabaseName
            // 
            this.LBL_DatabaseName.AutoSize = true;
            this.LBL_DatabaseName.Location = new System.Drawing.Point(45, 50);
            this.LBL_DatabaseName.Name = "LBL_DatabaseName";
            this.LBL_DatabaseName.Size = new System.Drawing.Size(82, 13);
            this.LBL_DatabaseName.TabIndex = 23;
            this.LBL_DatabaseName.Text = "Database name";
            // 
            // LBL_ServerName
            // 
            this.LBL_ServerName.AutoSize = true;
            this.LBL_ServerName.Location = new System.Drawing.Point(45, 24);
            this.LBL_ServerName.Name = "LBL_ServerName";
            this.LBL_ServerName.Size = new System.Drawing.Size(67, 13);
            this.LBL_ServerName.TabIndex = 22;
            this.LBL_ServerName.Text = "Server name";
            // 
            // tabPage_PictureServer
            // 
            this.tabPage_PictureServer.Controls.Add(this.sS_MaskedTextBox_PictureServerName);
            this.tabPage_PictureServer.Controls.Add(this.sS_MaskedTextBox_PicturePassword);
            this.tabPage_PictureServer.Controls.Add(this.sS_MaskedTextBox_PictureUserName);
            this.tabPage_PictureServer.Controls.Add(this.sS_MaskedTextBox_PictureDatabaseName);
            this.tabPage_PictureServer.Controls.Add(this.sS_ComboBox_PictureDatabaseType);
            this.tabPage_PictureServer.Controls.Add(this.LBL_PictureDatabaseType);
            this.tabPage_PictureServer.Controls.Add(this.LBL_PicturePassword);
            this.tabPage_PictureServer.Controls.Add(this.LBL_PictureUserName);
            this.tabPage_PictureServer.Controls.Add(this.LBL_PictureDatabaseName);
            this.tabPage_PictureServer.Controls.Add(this.LBL_PictureServerName);
            this.tabPage_PictureServer.Location = new System.Drawing.Point(4, 22);
            this.tabPage_PictureServer.Name = "tabPage_PictureServer";
            this.tabPage_PictureServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_PictureServer.Size = new System.Drawing.Size(413, 174);
            this.tabPage_PictureServer.TabIndex = 1;
            this.tabPage_PictureServer.Text = "Picture Server";
            this.tabPage_PictureServer.UseVisualStyleBackColor = true;
            // 
            // sS_MaskedTextBox_PictureServerName
            // 
            this.sS_MaskedTextBox_PictureServerName.BackColor = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PictureServerName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PictureServerName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PictureServerName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PictureServerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PictureServerName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PictureServerName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PictureServerName.IconError = null;
            this.sS_MaskedTextBox_PictureServerName.IconTrue = null;
            this.sS_MaskedTextBox_PictureServerName.Location = new System.Drawing.Point(153, 25);
            this.sS_MaskedTextBox_PictureServerName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PictureServerName.Name = "sS_MaskedTextBox_PictureServerName";
            this.sS_MaskedTextBox_PictureServerName.Size = new System.Drawing.Size(214, 26);
            this.sS_MaskedTextBox_PictureServerName.TabIndex = 38;
            // 
            // sS_MaskedTextBox_PicturePassword
            // 
            this.sS_MaskedTextBox_PicturePassword.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PicturePassword.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PicturePassword.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PicturePassword.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PicturePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PicturePassword.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PicturePassword.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PicturePassword.IconError = null;
            this.sS_MaskedTextBox_PicturePassword.IconTrue = null;
            this.sS_MaskedTextBox_PicturePassword.Location = new System.Drawing.Point(153, 103);
            this.sS_MaskedTextBox_PicturePassword.Masked = SimatSoft.CustomControl.Mask.Password;
            this.sS_MaskedTextBox_PicturePassword.Name = "sS_MaskedTextBox_PicturePassword";
            this.sS_MaskedTextBox_PicturePassword.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_PicturePassword.TabIndex = 41;
            // 
            // sS_MaskedTextBox_PictureUserName
            // 
            this.sS_MaskedTextBox_PictureUserName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PictureUserName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PictureUserName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PictureUserName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PictureUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PictureUserName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PictureUserName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PictureUserName.IconError = null;
            this.sS_MaskedTextBox_PictureUserName.IconTrue = null;
            this.sS_MaskedTextBox_PictureUserName.Location = new System.Drawing.Point(153, 77);
            this.sS_MaskedTextBox_PictureUserName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PictureUserName.Name = "sS_MaskedTextBox_PictureUserName";
            this.sS_MaskedTextBox_PictureUserName.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_PictureUserName.TabIndex = 40;
            // 
            // sS_MaskedTextBox_PictureDatabaseName
            // 
            this.sS_MaskedTextBox_PictureDatabaseName.BackColor = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PictureDatabaseName.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_MaskedTextBox_PictureDatabaseName.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_MaskedTextBox_PictureDatabaseName.BoolChangeFontOnFocus = true;
            this.sS_MaskedTextBox_PictureDatabaseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PictureDatabaseName.FontLostFocus = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.sS_MaskedTextBox_PictureDatabaseName.FontOnFocus = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sS_MaskedTextBox_PictureDatabaseName.IconError = null;
            this.sS_MaskedTextBox_PictureDatabaseName.IconTrue = null;
            this.sS_MaskedTextBox_PictureDatabaseName.Location = new System.Drawing.Point(153, 51);
            this.sS_MaskedTextBox_PictureDatabaseName.Masked = SimatSoft.CustomControl.Mask.None;
            this.sS_MaskedTextBox_PictureDatabaseName.Name = "sS_MaskedTextBox_PictureDatabaseName";
            this.sS_MaskedTextBox_PictureDatabaseName.Size = new System.Drawing.Size(214, 23);
            this.sS_MaskedTextBox_PictureDatabaseName.TabIndex = 39;
            // 
            // sS_ComboBox_PictureDatabaseType
            // 
            this.sS_ComboBox_PictureDatabaseType.BackColor = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_PictureDatabaseType.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_PictureDatabaseType.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_PictureDatabaseType.FormattingEnabled = true;
            this.sS_ComboBox_PictureDatabaseType.Items.AddRange(new object[] {
            "MsSql"});
            this.sS_ComboBox_PictureDatabaseType.Location = new System.Drawing.Point(153, 129);
            this.sS_ComboBox_PictureDatabaseType.Name = "sS_ComboBox_PictureDatabaseType";
            this.sS_ComboBox_PictureDatabaseType.Size = new System.Drawing.Size(214, 21);
            this.sS_ComboBox_PictureDatabaseType.TabIndex = 42;
            // 
            // LBL_PictureDatabaseType
            // 
            this.LBL_PictureDatabaseType.AutoSize = true;
            this.LBL_PictureDatabaseType.Location = new System.Drawing.Point(45, 137);
            this.LBL_PictureDatabaseType.Name = "LBL_PictureDatabaseType";
            this.LBL_PictureDatabaseType.Size = new System.Drawing.Size(76, 13);
            this.LBL_PictureDatabaseType.TabIndex = 37;
            this.LBL_PictureDatabaseType.Text = "Database type";
            // 
            // LBL_PicturePassword
            // 
            this.LBL_PicturePassword.AutoSize = true;
            this.LBL_PicturePassword.Location = new System.Drawing.Point(45, 110);
            this.LBL_PicturePassword.Name = "LBL_PicturePassword";
            this.LBL_PicturePassword.Size = new System.Drawing.Size(53, 13);
            this.LBL_PicturePassword.TabIndex = 36;
            this.LBL_PicturePassword.Text = "Password";
            // 
            // LBL_PictureUserName
            // 
            this.LBL_PictureUserName.AutoSize = true;
            this.LBL_PictureUserName.Location = new System.Drawing.Point(45, 84);
            this.LBL_PictureUserName.Name = "LBL_PictureUserName";
            this.LBL_PictureUserName.Size = new System.Drawing.Size(58, 13);
            this.LBL_PictureUserName.TabIndex = 35;
            this.LBL_PictureUserName.Text = "User name";
            // 
            // LBL_PictureDatabaseName
            // 
            this.LBL_PictureDatabaseName.AutoSize = true;
            this.LBL_PictureDatabaseName.Location = new System.Drawing.Point(45, 58);
            this.LBL_PictureDatabaseName.Name = "LBL_PictureDatabaseName";
            this.LBL_PictureDatabaseName.Size = new System.Drawing.Size(82, 13);
            this.LBL_PictureDatabaseName.TabIndex = 34;
            this.LBL_PictureDatabaseName.Text = "Database name";
            // 
            // LBL_PictureServerName
            // 
            this.LBL_PictureServerName.AutoSize = true;
            this.LBL_PictureServerName.Location = new System.Drawing.Point(45, 32);
            this.LBL_PictureServerName.Name = "LBL_PictureServerName";
            this.LBL_PictureServerName.Size = new System.Drawing.Size(67, 13);
            this.LBL_PictureServerName.TabIndex = 33;
            this.LBL_PictureServerName.Text = "Server name";
            // 
            // tabPage_Language
            // 
            this.tabPage_Language.Controls.Add(this.sS_ComboBox_Language);
            this.tabPage_Language.Controls.Add(this.LBL_Language);
            this.tabPage_Language.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Language.Name = "tabPage_Language";
            this.tabPage_Language.Size = new System.Drawing.Size(413, 174);
            this.tabPage_Language.TabIndex = 2;
            this.tabPage_Language.Text = "Other";
            this.tabPage_Language.UseVisualStyleBackColor = true;
            // 
            // sS_ComboBox_Language
            // 
            this.sS_ComboBox_Language.BackColor = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Language.BackColorOnFocus = System.Drawing.Color.LightBlue;
            this.sS_ComboBox_Language.BackColorOnLeave = System.Drawing.Color.Honeydew;
            this.sS_ComboBox_Language.FormattingEnabled = true;
            this.sS_ComboBox_Language.Items.AddRange(new object[] {
            "Thai",
            "English"});
            this.sS_ComboBox_Language.Location = new System.Drawing.Point(167, 24);
            this.sS_ComboBox_Language.Name = "sS_ComboBox_Language";
            this.sS_ComboBox_Language.Size = new System.Drawing.Size(214, 21);
            this.sS_ComboBox_Language.TabIndex = 29;
            this.sS_ComboBox_Language.SelectedIndexChanged += new System.EventHandler(this.sS_ComboBox_Language_SelectedIndexChanged);
            // 
            // LBL_Language
            // 
            this.LBL_Language.AutoSize = true;
            this.LBL_Language.Location = new System.Drawing.Point(31, 27);
            this.LBL_Language.Name = "LBL_Language";
            this.LBL_Language.Size = new System.Drawing.Size(61, 13);
            this.LBL_Language.TabIndex = 26;
            this.LBL_Language.Text = "Language :";
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "bgsetup.png");
            // 
            // Form_007000_DatabaseSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(471, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form_007000_DatabaseSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ID : 007000(Database Setup)";
            this.Load += new System.EventHandler(this.Form_001001_Server_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_007000_DatabaseSetup_FormClosed);
            this.panel1.ResumeLayout(false);
            this.tabControl_Server.ResumeLayout(false);
            this.tabPage_DatabaseServer.ResumeLayout(false);
            this.tabPage_DatabaseServer.PerformLayout();
            this.tabPage_PictureServer.ResumeLayout(false);
            this.tabPage_PictureServer.PerformLayout();
            this.tabPage_Language.ResumeLayout(false);
            this.tabPage_Language.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl_Server;
        private System.Windows.Forms.TabPage tabPage_DatabaseServer;
        private System.Windows.Forms.TabPage tabPage_PictureServer;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button Button_SaveConfig;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_Password;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_UserName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_DatabaseName;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_DatabaseType;
        private System.Windows.Forms.Label LBL_DatabaseType;
        private System.Windows.Forms.Label LBL_Password;
        private System.Windows.Forms.Label LBL_UserName;
        private System.Windows.Forms.Label LBL_DatabaseName;
        private System.Windows.Forms.Label LBL_ServerName;
        private System.Windows.Forms.TabPage tabPage_Language;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_Language;
        private System.Windows.Forms.Label LBL_Language;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_ServerName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PictureServerName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PicturePassword;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PictureUserName;
        private SimatSoft.CustomControl.SS_MaskedTextBox sS_MaskedTextBox_PictureDatabaseName;
        private SimatSoft.CustomControl.SS_ComboBox sS_ComboBox_PictureDatabaseType;
        private System.Windows.Forms.Label LBL_PictureDatabaseType;
        private System.Windows.Forms.Label LBL_PicturePassword;
        private System.Windows.Forms.Label LBL_PictureUserName;
        private System.Windows.Forms.Label LBL_PictureDatabaseName;
        private System.Windows.Forms.Label LBL_PictureServerName;
    }
}