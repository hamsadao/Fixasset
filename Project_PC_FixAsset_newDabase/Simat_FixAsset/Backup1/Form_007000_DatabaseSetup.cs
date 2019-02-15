using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    public partial class Form_007000_DatabaseSetup : SS_PaintGradientForm
    {
        public bool Bool_Connection = true;
        public bool Bool_ConnectionPic = true;
        public bool Bool_CheckSameServer = true;

        public Form_007000_DatabaseSetup()
        {
            InitializeComponent();
            if ((Bool_Connection) && (Bool_ConnectionPic))
            {
                Function_IntitialControl();
            }
        }
        private void Function_IntitialControl()
        {
            DarkColor = Global.ConfigForm.Colr_BackColor;
            this.Text = Global.Function_Language(this, this, "ID:007000(DatabaseSetup)");
            tabPage_DatabaseServer.Text = Global.Function_Language(this, tabPage_DatabaseServer, "Database Setup");
            tabPage_PictureServer.Text = Global.Function_Language(this, tabPage_PictureServer, "Picture Server");
            tabPage_Language.Text = Global.Function_Language(this, tabPage_Language, "Language");
            LBL_ServerName.Text = Global.Function_Language(this, LBL_ServerName, "Server name:");
            LBL_DatabaseName.Text = Global.Function_Language(this, LBL_DatabaseName, "Database name:");
            LBL_UserName.Text = Global.Function_Language(this, LBL_UserName, "User name:");
            LBL_Password.Text = Global.Function_Language(this, LBL_Password, "Password:");
            LBL_DatabaseType.Text = Global.Function_Language(this, LBL_DatabaseType, "Database type:");
            LBL_PictureServerName.Text = Global.Function_Language(this, LBL_PictureServerName, "Server name:");
            LBL_PictureDatabaseName.Text = Global.Function_Language(this, LBL_PictureDatabaseName, "Database name:");
            LBL_PictureUserName.Text = Global.Function_Language(this, LBL_PictureUserName, "User name:");
            LBL_PicturePassword.Text = Global.Function_Language(this, LBL_PicturePassword, "Password:");
            LBL_PictureDatabaseType.Text = Global.Function_Language(this, LBL_PictureDatabaseType, "Database type:");
            LBL_Language.Text = Global.Function_Language(this, LBL_Language, "Language:");
            Button_SaveConfig.Text = Global.Function_Language(this, Button_SaveConfig, "  OK");
            button_Cancel.Text = Global.Function_Language(this, button_Cancel, "   Cancel");
            //Function_SetLanguage();
        }

        private bool Function_CheckEqualConnectString(Class_ConnectionString OldConnectString, Class_ConnectionString NewConnectString)
        {
            if (OldConnectString.ServerConnectString != NewConnectString.ServerConnectString)
                return false;
            else
                if (OldConnectString.DatabaseConnectString != NewConnectString.DatabaseConnectString)
                    return false;
                else
                    if (OldConnectString.UserIDConnectString != NewConnectString.UserIDConnectString)
                        return false;
                    else
                        if (OldConnectString.PasswordConnectString != NewConnectString.PasswordConnectString)
                            return false;
                        else
                            if (OldConnectString.ProviderTypeConnectString != NewConnectString.ProviderTypeConnectString)
                                return false;
                            else
                                if (OldConnectString.LanguageConnectString != NewConnectString.LanguageConnectString)
                                    return false;
            return true;
        }
        private void Form_001001_Server_Load(object sender, EventArgs e)
        {
            if ((Bool_Connection) && (Bool_ConnectionPic))
            {

                Function_GetDatabaseServer();
                Function_GetDatabaseServerPicture();
            }
            else
            {
               // button_Cancel.Enabled = false;
                if ((Bool_Connection) && (Bool_ConnectionPic == false))
                {
                    Function_GetDatabaseServer();
                }
                else
                {
                    if ((Bool_Connection == false) && (Bool_ConnectionPic))
                    {
                        Function_GetDatabaseServerPicture();
                    }
                }
            }

        }
        private void Function_GetDatabaseServer()
        {
            String Str_Temp = Manager.Function_getConfig();
            sS_MaskedTextBox_ServerName.Text = Manager.Str_servername;
            sS_MaskedTextBox_UserName.Text = Manager.Str_username;
            sS_MaskedTextBox_Password.Text = Manager.Str_password;
            sS_MaskedTextBox_DatabaseName.Text = Manager.Str_databasename;
            sS_ComboBox_DatabaseType.Text = Manager.Str_DB_Type;
            Function_SetLanguage();
        }
        private void Function_GetDatabaseServerPicture()
        {
          String Str_Temp = ManagerPic.Function_getConfig();
          sS_MaskedTextBox_PictureServerName.Text = ManagerPic.Str_servername;
          sS_MaskedTextBox_PictureUserName.Text = ManagerPic.Str_username;
          sS_MaskedTextBox_PicturePassword.Text = ManagerPic.Str_password;
          sS_MaskedTextBox_PictureDatabaseName.Text = ManagerPic.Str_databasename;
          sS_ComboBox_PictureDatabaseType.Text = ManagerPic.Str_DB_Type;
        }
        private void button_SaveConfig_Click(object sender, EventArgs e)
        {
            ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
            Class_ConnectionString OldConnectStrDB = new Class_ConnectionString();
            Class_ConnectionString OldConnectStrPicDB = new Class_ConnectionString();
            Class_ConnectionString NewConnectStrDB = new Class_ConnectionString();
            Class_ConnectionString NewConnectStrPicDB = new Class_ConnectionString();

            try
            {
               
                    if ((Bool_Connection) && (Bool_ConnectionPic))
                    {

                        if (Manager.Str_servername != string.Empty)
                            OldConnectStrDB = OldConnectStrDB.Function_SaveConnectString(Manager.Str_servername, Manager.Str_databasename, Manager.Str_username, Manager.Str_password, Manager.Str_DB_Type, Manager.Str_language);

                        Manager.Str_servername = sS_MaskedTextBox_ServerName.Text;
                        Manager.Str_username = sS_MaskedTextBox_UserName.Text;
                        Manager.Str_password = sS_MaskedTextBox_Password.Text;
                        Manager.Str_databasename = sS_MaskedTextBox_DatabaseName.Text;
                        Manager.Str_DB_Type = sS_ComboBox_DatabaseType.Text;
                        Manager.Str_language = Function_ConfigLanguage();

                        NewConnectStrDB = NewConnectStrDB.Function_SaveConnectString(Manager.Str_servername, Manager.Str_databasename, Manager.Str_username, Manager.Str_password, Manager.Str_DB_Type, Manager.Str_language);
                        Manager.Function_SaveConfig();

                        Manager.Function_TestConnect();

                        if (ManagerPic.Str_servername != string.Empty)
                            OldConnectStrPicDB = OldConnectStrPicDB.Function_SaveConnectString(ManagerPic.Str_servername, ManagerPic.Str_databasename, ManagerPic.Str_username, ManagerPic.Str_password, ManagerPic.Str_DB_Type, string.Empty);

                        ManagerPic.Str_servername = sS_MaskedTextBox_PictureServerName.Text;
                        ManagerPic.Str_username = sS_MaskedTextBox_PictureUserName.Text;
                        ManagerPic.Str_password = sS_MaskedTextBox_PicturePassword.Text;
                        ManagerPic.Str_databasename = sS_MaskedTextBox_PictureDatabaseName.Text;
                        ManagerPic.Str_DB_Type = sS_ComboBox_DatabaseType.Text;

                        NewConnectStrPicDB = NewConnectStrPicDB.Function_SaveConnectString(ManagerPic.Str_servername, ManagerPic.Str_databasename, ManagerPic.Str_username, ManagerPic.Str_password, ManagerPic.Str_DB_Type, string.Empty);

                        ManagerPic.Function_SaveConfig();
                        ManagerPic.FunctionTestConnect();

                        Global.Lang.Str_Language = Manager.Str_language;

                        if (Function_CheckEqualConnectString(OldConnectStrDB, NewConnectStrDB) && Function_CheckEqualConnectString(OldConnectStrPicDB, NewConnectStrPicDB))
                        {
                            SS_MyMessageBox.ShowBox("Connect Server Complete", "Information", DialogMode.OkOnly);

                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Cannot connect Server, Please check data already!", "Information", DialogMode.OkOnly);
                        }

                        //SS_NotifyWindow NW = new SS_NotifyWindow("Status", "Connected");
                        //NW.TitleClicked += new EventHandler(titleClick);
                        //NW.TextClicked += new EventHandler(textClick);
                        //NW.SetDimensions(250, 150);
                        //NW.Notify();

                    }

                    else
                    {
                        ManagerCantConnect.Str_Server = sS_MaskedTextBox_ServerName.Text;
                        ManagerCantConnect.Str_UserID = sS_MaskedTextBox_UserName.Text;
                        ManagerCantConnect.Str_Password = sS_MaskedTextBox_Password.Text;
                        ManagerCantConnect.Str_Database = sS_MaskedTextBox_DatabaseName.Text;
                        ManagerCantConnect.Str_DB_Type = sS_ComboBox_DatabaseType.Text;
                        ManagerCantConnect.Str_Language = Function_ConfigLanguage();

                        ManagerCantConnect.Function_StartManager();
                        ManagerCantConnect.Function_SaveConfigFile();

                        ManagerPicCantConnect.Str_Server = sS_MaskedTextBox_PictureServerName.Text;
                        ManagerPicCantConnect.Str_UserID = sS_MaskedTextBox_PictureUserName.Text;
                        ManagerPicCantConnect.Str_Password = sS_MaskedTextBox_PicturePassword.Text;
                        ManagerPicCantConnect.Str_Database = sS_MaskedTextBox_PictureDatabaseName.Text;
                        ManagerPicCantConnect.Str_DB_Type = sS_ComboBox_PictureDatabaseType.Text;

                        ManagerPicCantConnect.Function_StartApplication();
                        ManagerPicCantConnect.Function_SaveConfigFile();

                        SS_MyMessageBox.ShowBox("This Program will be terminate automatically, You must restart a Program.", "Information", DialogMode.OkOnly);
                        Application.Restart();
                    }
                    this.Close();


                }
            
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox("Can not Connect Database Server because " + Ex.Message, "Error", DialogMode.Error_Cancel, Ex);
            }
        }
        protected void titleClick(object sendor, System.EventArgs e)
        {
            MessageBox.Show("XXX");
        }
        protected void textClick(object sendor, System.EventArgs e)
        {
            MessageBox.Show("xxx");
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Function_DBType()
        {
            try
            {
                switch (sS_ComboBox_DatabaseType.SelectedText)
                {
                    case "Access":
                        Manager.Str_DB_Type = "Access";
                        break;
                    case "MsSql":
                        Manager.Str_DB_Type = "MsSql";
                        break;
                    case "Odbc":
                        Manager.Str_DB_Type = "Odbc";
                        break;
                    case "OleDb":
                        Manager.Str_DB_Type = "OleDb";
                        break;
                    case "Oracle":
                        Manager.Str_DB_Type = "Oracle";
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private string Function_ConfigLanguage()
        {
                string Str_TempLanguage = "";
                if (sS_ComboBox_Language.Text != "")
                {
                    switch (sS_ComboBox_Language.SelectedItem.ToString())
                    {
                        case "Thai":
                            Str_TempLanguage = "TH";
                            break;
                        case "English":
                            Str_TempLanguage = "EN";
                            break;
                        default:
                            Str_TempLanguage = "EN";
                            break;
                    }
                }
                else
                    Str_TempLanguage = "EN";
                return Str_TempLanguage;     
         }
        private void Function_SetLanguage()
        {
            switch (Manager.Str_language)
                {
                    case "TH":
                        sS_ComboBox_Language.SelectedIndex = 0;
                        break;
                    case "EN":
                        sS_ComboBox_Language.SelectedIndex = 1;
                        break;
                }
        }

        private void sS_ComboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function_ConfigLanguage();
            Function_IntitialControl();
        }

        private void Form_007000_DatabaseSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);              
        }
       
    }
}