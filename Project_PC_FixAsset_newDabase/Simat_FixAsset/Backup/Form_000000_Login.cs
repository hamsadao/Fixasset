using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.Data.MessageScreen;
using System.Xml;
using SimatSoft.DB.ORM;

namespace SimatSoft.FixAsset
{
    public partial class Form_000000_LOGIN : Form
    {
        private bool m_showing = true;
        DataView dtV_Fac = new DataView();
        public Form_000000_LOGIN()
        {
            InitializeComponent();
            Function_IntitialControl();
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001000(Login)");
            LBL_UserID.Text = Global.Function_Language(this, LBL_UserID, " User ID:");
            LBL_Password.Text = Global.Function_Language(this, LBL_Password, "Password:");
            LBL_Language.Text = Global.Function_Language(this, LBL_Language, "Language:");
            LBL_Company.Text = Global.Function_Language(this, LBL_Company, "Company:");
            Button_Login.Text = Global.Function_Language(this, Button_Login, "    Login");
            Button_Exit.Text = Global.Function_Language(this, Button_Exit, "      Exit");
            Button_Config.Text = Global.Function_Language(this, Button_Config, "Config");
            Function_setLanguage();
             
            // Edit on 04-06-09 to fix company name for 'CEVA' and 'FM' (FM is another dept of CEVA Company)
            // Get FacCode
            //DataSet ds = (DataSet)Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Facility>("");
            //dtV_Fac = new DataView(ds.Tables[0]);
            //sS_ComboBox_Company.DataSource = dtV_Fac;
            //sS_ComboBox_Company.ValueMember = "FacCode";
            //sS_ComboBox_Company.DisplayMember = "Name";
        }

        private void Button_Login_Click(object sender , EventArgs e)
        {
            // Fucntion for TrialVersion
            // ValidateDateTrial();

            ////////////////

            ValidateUser();

        }

        void ValidateDateTrial()
        {
            DateTime STARTdate = Convert.ToDateTime("01/20/2009 12:00:00 AM"); // Fixed for start date
            DateTime PresentDate = DateTime.Now;
            System.TimeSpan diffResult = PresentDate.Subtract(STARTdate);
            if (diffResult.Days > 30)
            {
                //SS_MyMessageBox.ShowBox("This software is a trial version and it's now expired, please contact SimatSoft Company\r\n         ..Thank You..");
                if (SS_MyMessageBox.ShowBox("This software is a trial version and it's now expired, \r\n please contact SimatSoft Company\r\n                ..Thank You..") == DialogResult.OK || SS_MyMessageBox.ShowBox("The application is expired. \r\n Please contact SimatSoft Company, Thanks.") == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            }

        }

        void ValidateUser()
        {
            try
            {
                SimatSoft.DB.ORM.WhuserHome WhUserHomeobj = new SimatSoft.DB.ORM.WhuserHome();

                object[] Obj_UserID = new object[1] {sS_MaskedTextBox_UserID.Text };

                if (WhUserHomeobj.Function_CheckUserName(sS_MaskedTextBox_UserID.Text))
                {
                    if (WhUserHomeobj.Function_CheckPassword(sS_MaskedTextBox_UserID.Text, sS_MaskedTextBox_Password.Text))
                    {
                        cls_main.clsmainmenu.Dsmainmenu = WhUserHomeobj.getmainmenu();

                        SS_MyMessageBox.ShowBox("User ID : " + sS_MaskedTextBox_UserID.Text + " Login Complete", "Login Information", DialogMode.OkOnly, this.Name, "000001", Obj_UserID, Global.Lang.Str_Language);
                        Global.ConfigDatabase.Str_UserID = sS_MaskedTextBox_UserID.Text;
                        Global.ConfigDatabase.Str_UserName = WhUserHomeobj.GetUserName(sS_MaskedTextBox_UserID.Text);
                        Global.ConfigDatabase.Str_Company = sS_ComboBox_Company.Text;

                        m_showing = false;
                        fadeTimer.Stop();
                        this.Close();
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Invalid User Password", "Login Information", DialogMode.OkOnly, this.Name, "000003", Global.Lang.Str_Language);
                        sS_MaskedTextBox_Password.SelectAll();
                        sS_MaskedTextBox_Password.Focus();
                    }
                }
                else
                {
                    SS_MyMessageBox.ShowBox("Invalid User ID :" + sS_MaskedTextBox_UserID.Text, "Login Information", DialogMode.OkOnly, this.Name, "000002", Obj_UserID, Global.Lang.Str_Language);
                    sS_MaskedTextBox_UserID.SelectAll();
                    sS_MaskedTextBox_UserID.Focus();
                }

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error On Login", DialogMode.Error_Cancel, Err);
            }
            //try
            //{
            //    SimatSoft.DB.ORM.WhuserHome SS_whUserChk = new SimatSoft.DB.ORM.WhuserHome();
            //    Global.ConfigDatabase.Str_UserID = sS_MaskedTextBox_UserID.Text;
            //    Global.ConfigDatabase.Str_Password = sS_MaskedTextBox_Password.Text;
            //    Object[] Obj_UserID = new Object[2]{"001","002"};
            //    if (SS_whUserChk.checkusername_password(sS_MaskedTextBox_UserID.Text, sS_MaskedTextBox_Password.Text))
            //    {
            //        //SS_MyMessageBox.ShowBox(
            //        SS_MyMessageBox.ShowBox("Login Complete", "Information", DialogMode.OkOnly,this.Name,"001",Global.Lang.Str_Language);
            //        cls_main.clsmainmenu.Dsmainmenu = SS_whUserChk.getmainmenu();
            //        this.Close();
            //    }
            //    else
            //    {
            //        //SS_MyMessageBox.ShowBox("Invalid UserName,Password", "Information");
            //        SS_MyMessageBox.ShowBox("Login Complete", "Information", DialogMode.OkOnly, "Form_000000_Login", "002", Obj_UserID, "TH");
            //        sS_MaskedTextBox_UserID.Text = "";
            //        sS_MaskedTextBox_Password.Text = "";
            //        sS_MaskedTextBox_UserID.Focus();
            //    }
            //}

            //catch (XmlException xErr)
            //{
            //    SS_MyMessageBox.ShowBox(xErr.Message, "Error", DialogMode.Error_Cancel, xErr);
            //}
            //catch (Exception Err)
            //{
            //    SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            //}
  
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string Function_LoginLanguage()
        {
            try
            {
                switch (sS_ComboBox_Language.SelectedIndex)
                {
                    case 0:
                        Global.Lang.Str_Language = "TH";
                        break;
                    case 1:
                        Global.Lang.Str_Language = "EN";
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
            return Global.Lang.Str_Language;
        }
        private void Function_setLanguage()
        {
            try
            {
                switch (Global.Lang.Str_Language)
                {
                    case "TH":
                        sS_ComboBox_Language.SelectedIndex = 0;
                        break;
                    case "EN":
                        sS_ComboBox_Language.SelectedIndex = 1;
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void sS_ComboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            Function_LoginLanguage();
            Function_IntitialControl();
        }
        private void Form_001000_LOGIN_Load(object sender, EventArgs e)
        {
            Opacity = 0.0;
            Activate();
            Refresh();
            fadeTimer.Start();
            Refresh();
            sS_MaskedTextBox_UserID.Focus();

        }
        private void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (m_showing)
            {
                double d = 1000.0 / fadeTimer.Interval / 100.0;
                if (Opacity + d >= 1.0)
                {
                    Opacity = 1.0;
                    fadeTimer.Stop();
                }
                else
                {
                    Opacity += d;
                }
            }
        }
        private void Button_Config_Click(object sender, EventArgs e)
        {
            try
            {
                Form_007000_DatabaseSetup Frm_Server = new Form_007000_DatabaseSetup();

                Frm_Server.ShowDialog();

                Function_setLanguage();

                sS_MaskedTextBox_UserID.Focus();
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Login Click Config", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_MaskedTextBox_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (sS_MaskedTextBox_Password.Text.Trim().Length > 0)
                {
                    ValidateUser();
                }
            }
        }

        private void sS_MaskedTextBox_UserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar== 13)
            {
                if (sS_MaskedTextBox_UserID.Text.Trim().Length > 0)
                {
                    sS_MaskedTextBox_Password.Focus();
                    sS_MaskedTextBox_Password.SelectAll();
                }
            }
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            object[] dd = new object[2] { "001", "P001" };
            //newMessageBox.lblMessage.Text = GetMultiLanguage(FormID.ToString(), MsgID.ToString(), Language.ToString(), "", txtMessage,dd);// txtMessage;// +"\r\n" + DescriptionERR;

            //SS_MyMessageBox.ShowBox("dfjkdjf", "DJfkdjf", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "2000", "EN");
            //SS_MyMessageBox.ShowBox("dfjkdjf", "DJfkdjf", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "2000", dd, "TH");
            //SS_MyMessageBox.ShowBox("dfjkdjf", "DJfkdjf", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "1000",dd, "TH");
            ////SS_MyMessageBox.ShowBox("dfjkdjf", "DJfkdjf", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "1000", "EN");
            ////SS_MyMessageBox.ShowBox("dfjkdjf", "DJfkdjf", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "10001", "EN");
            //SS_MyMessageBox.ShowBox("Message Default", "Message Default Title", DialogMode.Error_Cancel, "dfjdlfj", this.Name, "10007", "EN");

            SS_MyMessageBox.ShowBox("M1");
            SS_MyMessageBox.ShowBox("M1", this.Name, "1000", "TH");
            SS_MyMessageBox.ShowBox("M1");
            //
            SS_MyMessageBox.ShowBox("M1", "T1");
            SS_MyMessageBox.ShowBox("M1", "T1", DialogMode.OkCancel);
        }
    }           
}