using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SimatSoft.Data.MessageScreen;
using System.Windows.Forms;
using Wilson.ORMapper;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;
using SimatSoft.ReportManagerWinForm;
  

namespace SimatSoft.FixAsset
{
    //public enum Enum_Mode { Search,PreAdd, Add,PreEdit, Edit, Delete, Cancel, ShowData, CellClick,Import,Export,SaveOnly,SetDefault};
    //Edit 13-12-08
    public enum Enum_Mode { Search, PreAdd, Add, PreEdit, Edit, Delete, Cancel, ShowData, CellClick, Import, Export, SaveOnly, SetDefault, ShowData_search,PreSearch};
    public enum Enum_TypeSearch { PO, InTransfer, ExTransfer, TransferSerial, PODT, AssetTransferDT, Area, Floor, ExTransferSerial,TransferOrder };
    
    class Global
    {
        public static string[] str_FeildName = null;
        public static string STR_State = "";
        public static string STR_FormID = "";
        public static bool Bool_CheckComplete = false;

        /// <summary>
        /// Class Global
        /// Name :
        /// Date :
        /// </summary>
        public class ConfigDatabase
        {
            public static String Str_UserID = "";//UserID when Login
            public static String Str_UserName = "";//UserName when Config
            public static String Str_Database = Manager.Str_databasename;
            public static String Str_ServerName = Manager.Str_servername;
            public static String Str_UserServerName = Manager.Str_username;
            public static String Str_Password = Manager.Str_password;
            public static String Str_Company = "";
            public static bool Bool_FlagConnection = true;
        }
        public class IndexArray
        {
            public static Object Add(int int_State)
            {
                string[] temp = new string[((str_FeildName == null ? 1 : str_FeildName.Length))];
                temp = str_FeildName;

                str_FeildName = new string[((str_FeildName == null ? 1 : str_FeildName.Length + 1))];
                if (temp != null)
                {
                    for (int i = 0; i < temp.Length; i++)
                    {
                        str_FeildName.SetValue(temp.GetValue(i), i);
                    }
                }
                str_FeildName.SetValue(int_State.ToString(), str_FeildName.Length - 1);
                return str_FeildName.Length - 1;
            }
            public static int Get(int indexForm)
            {
                return int.Parse( str_FeildName.GetValue(indexForm).ToString());
            }
            public static void Edit(int indexForm, int State)
            {
                str_FeildName.SetValue(State.ToString(), indexForm);
            }
        }
        /// <summary>
        /// กำหนด path เริ่มต้น ,กำหนด path สำหรับอ่านไฟล์ XML
        /// </summary>
        public class ConfigPath
        {
            public static string Str_AppPath = Application.StartupPath;
            public static string Str_AppPathXml = Application.StartupPath + "\\XML";
            public static string Str_AppPathValidate = Application.StartupPath + "\\Data\\Validate";
            //public static string Str_ImagePath;
        }
       
        public class ReturnValue
        {
            public static string Str_FormSearch = "";
            public static string Str_AssetNo = "";
            public static string Str_AssetName = "";
            public static string Str_SerialNo = "";
            public static string Str_BuildID = "";
            public static string Str_FloorID = "";
            public static string Str_AreaID = "";
            public static string Str_CustodianID = "";
            public static string Str_ModelID = "";
            
        }

        /// <summary>
        /// config path mapping
        /// </summary>
        public class Mapping
        {
            public static string Str_ProjectFileMapping = "\\Config\\Mapping.Config";
            public static string projectPath = Application.StartupPath;
            // public static string connectString = "Server=" + ConfigDatabase.Str_ServerName + ";Database=" + ConfigDatabase.Str_Database + ";UID=" + ConfigDatabase.Str_UserID + ";PWD=" + ConfigDatabase.Str_Password + ";";
            public static string connectString = SimatSoft.DB.ORM.Manager.Function_getConfig();
            public static ObjectSpace Manager = new ObjectSpace(projectPath + Str_ProjectFileMapping, connectString, Provider.MsSql);
        }

        public class ConfigForm
        {
            
            public static string Str_Font = "";
            //public static Color Colr_BackColor = System.Drawing.Color.FromArgb(180, 210, 238);
            public static Color Colr_BackColor = Color.CornflowerBlue;
            public static ToolStripButton MDIToolStrip_Save;
            public static ToolStripButton MDIToolStrip_Edit;
            public static ToolStripButton MDIToolStrip_Add;
            public static ToolStripButton MDIToolStrip_Delete;
            public static ToolStripButton MDIToolStrip_Export;
            public static ToolStripButton MDIToolStrip_Cancel;
            public static ToolStripButton MDIToolStrip_Import;
            public static ToolStripButton MDIToolStrip_Find;
            public static Enum_Mode Enum_FlagTransaction;
            public static int Int_IDForm = 0;
            public static SS_TabStrip MDITabStrip;
        }

        /// <summary>
        /// Set Language Default(English)
        /// </summary>
        public class Lang
        {
            public static string Str_Language = "EN";
        }

        /// <summary>
        /// Set valiable for Function SetLocation
        /// </summary>
        public class Location
        {
            public static int Int_CountForm;
            public static int Int_LocX;
            public static int Int_LocY;
        }

        /// <summary>
        /// Set Location of Form when Double Click Form on TreeViewMenu
        /// Form is display เรียงต่อเนื่องกัน
        /// </summary>
        public static Point SetLocation(int Int_X, int Int_Width, int Int_Y)
        {
            try
            {
                Point Location;
                if ((Global.Location.Int_CountForm <= 0) || (Global.Location.Int_CountForm % 5 <= 0))
                {
                    Location = new Point((Int_X + Int_Width), Int_Y);
                }
                else
                {
                    Location = new Point((Global.Location.Int_LocX + 55), (Global.Location.Int_LocY + 25));
                }
                if (Global.Location.Int_CountForm <= 0)
                {
                    Global.Location.Int_CountForm = 0;
                }
                Global.Location.Int_CountForm = Global.Location.Int_CountForm + 1;
                Global.Location.Int_LocX = Location.X;
                Global.Location.Int_LocY = Location.Y;
                return Location;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("SetLocation: " + Err.Message, "Error On Menu SetLocation", DialogMode.Error_Cancel, Err);
                return new Point();
            }
        }

        public static  void Function_ShowFormReport(string Str_TempID,Form Frm_Temp)
        {
            SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm clsreport = new SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm();
            clsreport.Engine = SimatSoft.DB.ORM.Manager.Engine;
            clsreport.Dbname = Global.ConfigDatabase.Str_Database;
            clsreport.Username = Global.ConfigDatabase.Str_UserName;
            clsreport.UserPassword = Global.ConfigDatabase.Str_Password;

            Form_MainReport Frm = new Form_MainReport();

            Frm = (Form_MainReport)Frm_Temp;

            clsreport.Reportid = Str_TempID;
            Frm.ShowReport(clsreport.Reportid, clsreport.Engine);

            Frm.Dbname = clsreport.Dbname;
            Frm.UserName = clsreport.Username;
            Frm.UserPassword = clsreport.UserPassword;

           // clsreport.DisplayScreen1(Frm_Temp);  
        }

        /// <summary>
        /// ShowForm
        /// </summary>
        /// <param name="Str_FormID"></param>
        /// <returns></returns>
        public static Form Function_ShowForm(string Str_FormID)
        {
            Form Frm_Name = null;
            try
            {
                switch (Str_FormID)
                {
                    case "41":
                    case "42":
                    case "43":
                    case "44":
                    case "45":
                    case "46":
                    case "47":
                    case "48":
                    case "49":
                    case "410":
                    case "411":
                    case "412":
                    case "413":
                        Frm_Name = Function_ShowReportForm(Str_FormID);
                        break;
                    case "21":
                        Form_002001_Asset Frm_Asset = new Form_002001_Asset();
                        Frm_Name = Frm_Asset;
                        break;
                    case "22":
                        Form_002002_Model Frm_Model = new Form_002002_Model();
                        Frm_Name = Frm_Model;
                        break;
                    case "23":
                        Form_002003_Pictures Frm_Picture = new Form_002003_Pictures();
                        Frm_Name = Frm_Picture;
                        break;

                    case "24":
                        Form_002004_Type Frm_Type = new Form_002004_Type();
                        Frm_Name = Frm_Type;
                        break;
                    case "25":
                        Form_002005_Supplier Frm_Vendor = new Form_002005_Supplier();
                        Frm_Name = Frm_Vendor;
                        break;
                    case "26":
                        Form_002006_Company Frm_Company = new Form_002006_Company();
                        Frm_Name = Frm_Company;
                        break;
                    case "27":
                        Form_002007_Area Frm_Area = new Form_002007_Area();
                        Frm_Name = Frm_Area;
                        break;
                    case "28":
                        Form_002008_Building Frm_Building = new Form_002008_Building();
                        Frm_Name = Frm_Building;
                        break;

                    case "29":
                        Form_002009_Floor Frm_Floor = new Form_002009_Floor();
                        Frm_Name = Frm_Floor;
                        break;

                    case "210":
                        Form_002010_Department Frm_Department = new Form_002010_Department();
                        Frm_Name = Frm_Department;
                        break;

                    case "211":
                        Form_002011_Custodian Frm_Customer = new Form_002011_Custodian();
                        Frm_Name = Frm_Customer;
                        break;

                    case "212":
                        Form_002012_Reason Frm_Reason = new Form_002012_Reason();
                        Frm_Name = Frm_Reason;
                        break;
                    case "213":
                        Form_002013_Status Frm_Status = new Form_002013_Status();
                        Frm_Name = Frm_Status;
                        break;
                    case "31":
                        Form_003001_HistoryAsset Frm_HistoryAsset = new Form_003001_HistoryAsset();
                        Frm_Name = Frm_HistoryAsset;
                        break;
                    case "32":
                        Form_003002_HistoryPurchaseOrderHD Frm_HistoryPOHD = new Form_003002_HistoryPurchaseOrderHD();
                        Frm_Name = Frm_HistoryPOHD;
                        break;
                    case "33":
                        Form_003003_HistoryAssetTransferHD Frm_HistoryAssetTransferHD = new Form_003003_HistoryAssetTransferHD();
                        Frm_Name = Frm_HistoryAssetTransferHD;
                        break;
                    case "4":
                        Form_003001_REPORT Frm_Report = new Form_003001_REPORT();
                        Frm_Name = Frm_Report;
                        break;

                    case "51":
                        //Form_005001_Barcode_Asset Frm_BarcodeAsset = new Form_005001_Barcode_Asset();
                        Form_005010_Barcode_Asset_New Frm_BarcodeAsset = new Form_005010_Barcode_Asset_New();
                        Frm_Name = Frm_BarcodeAsset;
                        break;

                    case "52":
                        Form_005002_Barcode_Model Frm_BarcodeModel = new Form_005002_Barcode_Model();
                        Frm_Name = Frm_BarcodeModel;
                        break;

                    case "53":
                        Form_005003_Barcode_Area Frm_BarcodeArea = new Form_005003_Barcode_Area();
                        Frm_Name = Frm_BarcodeArea;
                        break;

                    case "54":
                        Form_005004_Barcode_Building Frm_BarcodeBuilding = new Form_005004_Barcode_Building();
                        Frm_Name = Frm_BarcodeBuilding;
                        break;

                    case "55":
                        Form_005005_Barcode_Floor Frm_BarcodeFloor = new Form_005005_Barcode_Floor();
                        Frm_Name = Frm_BarcodeFloor;
                        break;

                    case "56":
                        Form_005006_Barcode_Department Frm_BarcodeDept = new Form_005006_Barcode_Department();
                        Frm_Name = Frm_BarcodeDept;
                        break;

                    case "57":
                        Form_005007_Barcode_Custodian Frm_Custodian = new Form_005007_Barcode_Custodian();
                        Frm_Name = Frm_Custodian;
                        break;

                    case "58":
                        Form_005010_Barcode_Asset_New Frm_BarcodeAssetNew = new Form_005010_Barcode_Asset_New();
                        Frm_Name = Frm_BarcodeAssetNew;
                        break;

                    case "61":
                        Form_006001_UserAuthorize Frm_UserAutolize = new Form_006001_UserAuthorize();
                        Frm_Name = Frm_UserAutolize;
                        break;
                    case "62":
                        Form_006002_UserGroupAuthorize Frm_UserGroupAutolize = new Form_006002_UserGroupAuthorize();
                        Frm_Name = Frm_UserGroupAutolize;
                        break;

                    case "11":
                        Form_001001_PurchaseOrder Frm_PurchaseOrder = new Form_001001_PurchaseOrder();
                        Frm_Name = Frm_PurchaseOrder;
                        break;
                    case "12":
                        Form_001002_ReceivePurchaseOrder Frm_ReceivePO = new Form_001002_ReceivePurchaseOrder();
                        Frm_Name = Frm_ReceivePO;
                        break;
                    case "13":
                        Form_001003_InternalTransferOrder Frm_InternalTransferOrder = new Form_001003_InternalTransferOrder();
                        Frm_Name = Frm_InternalTransferOrder;
                        break;
                    case "14":
                        Form_001004_InternalTransfer Frm_InternalTransfer = new Form_001004_InternalTransfer();
                        Frm_Name = Frm_InternalTransfer;
                        break;
                    case "15":
                        Form_001005_ExternalTransferOrder Frm_ExternalTransferOrder = new Form_001005_ExternalTransferOrder();
                        Frm_Name = Frm_ExternalTransferOrder;
                        break;
                    case "16":
                        Form_001006_ExternalTransfer Frm_ExternalTransfer = new Form_001006_ExternalTransfer();
                        Frm_Name = Frm_ExternalTransfer;
                        break;
                    case "17":
                        Form_001007_Upload_Download_HH Frm_Upload_Download_HH = new Form_001007_Upload_Download_HH();
                        Frm_Name = Frm_Upload_Download_HH;
                        break;
                    case "18":
                        Form_001008_ImportFile Frm_ImportFile = new Form_001008_ImportFile();
                        Frm_Name = Frm_ImportFile;
                        break;
                    case "19":
                        Form_001010_WriteOff Frm_WriteOff = new Form_001010_WriteOff();
                        Frm_Name = Frm_WriteOff;
                        break;

                    case "20":
                        Form_001012_ReceiveNonePO Frm_ReceiveNonePO = new Form_001012_ReceiveNonePO();
                        Frm_Name = Frm_ReceiveNonePO;
                        break;

                    case "7":
                        Form_007000_DatabaseSetup Frm_DatabaseSetup = new Form_007000_DatabaseSetup();
                        Frm_Name = Frm_DatabaseSetup;
                        break;
                    case "110":
                        Form_001010_CheckStock Frm_CheckStock = new Form_001010_CheckStock();
                        Frm_Name = Frm_CheckStock;
                        break;

                }
                return Frm_Name;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Function_ShowForm: \n" + Err.Message + "\n" + Str_FormID, "Error On Menu Function_ShowForm", DialogMode.Error_Cancel, Err);
                return Frm_Name;
            }
        }
        private static Form Function_ShowReportForm(string Str_ID)
        {
            SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm Cls_Report = new SimatSoft.ReportManagerWinForm.Class_SimatReport_WinForm();
            Cls_Report.Engine = SimatSoft.DB.ORM.Manager.Engine;
            Cls_Report.Dbname = Global.ConfigDatabase.Str_Database;
            Cls_Report.Username = Global.ConfigDatabase.Str_UserServerName;
            Cls_Report.UserPassword = Global.ConfigDatabase.Str_Password;

            Cls_Report.Reportid = Str_ID;
            return Cls_Report.DisplayScreen(ref Global.Location.Int_CountForm, ref Global.ConfigForm.MDITabStrip);
        }
        public static string Function_Language(Form Frm_FrmName, Control Ctrl_Name, string Str_DefaultName)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_DefaultName);
        }
        public static string Function_Language(Form Frm_FrmName, ToolStripMenuItem Ctrl_Name, string Str_DefaultName)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_DefaultName);
        }
        public static string Function_Language(Form Frm_FrmName, ToolStripButton Ctrl_Name, string Str_DefaultName)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_DefaultName);
        }
        public static string Function_Language(Form Frm_FrmName, ToolStripStatusLabel Ctrl_Name, string Str_DefaultName)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_DefaultName);
        }
        public static string Function_Language(Form Frm_FrmName, CheckBox Ctrl_Name, string Str_Default)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_Default);
        }
        public static string Function_Language(Form Frm_FrmName, GroupBox Ctrl_Name, string Str_Default)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_Default);
        }
        public static string Function_Language(Form Frm_FrmName, TabPage Ctrl_Name, string Str_Default)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_Default);
        }
        public static string Function_Language(Form Frm_FrmName, SS_ButtonGlass Ctrl_Name, string Str_Default)
        {
            return Function_SetLanguage(Frm_FrmName.Name, Ctrl_Name.Name, Str_Default);
        }
        public static string Function_SetLanguage(string Frm_FormName, string Ctrl_Name, string Str_Default)
        {
            try
            {
                string Str_ReturnName = SimatSoft.Data.MessageScreen.MSG_Mapping.GetMSG_Mapping(Frm_FormName, Ctrl_Name, Global.Lang.Str_Language, Global.ConfigPath.Str_AppPathXml);
                if ((Str_ReturnName == null) || (Str_ReturnName == "") || (Str_ReturnName == Ctrl_Name))
                {
                    return Str_Default;
                }
                else
                {
                    return Str_ReturnName;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
            return Str_Default;
        }

        public static void Function_ToolStripSetUP(Enum_Mode mode)
        {
                ConfigForm.MDIToolStrip_Save.Enabled = false;
                ConfigForm.MDIToolStrip_Edit.Enabled = false;
                ConfigForm.MDIToolStrip_Add.Enabled = false;
                ConfigForm.MDIToolStrip_Delete.Enabled = false;
                ConfigForm.MDIToolStrip_Export.Enabled = false;
                ConfigForm.MDIToolStrip_Import.Enabled = false;
                ConfigForm.MDIToolStrip_Find.Enabled = false;
                ConfigForm.MDIToolStrip_Cancel.Enabled = false;

            switch (mode)
            {
                case Enum_Mode.SetDefault:
                    ConfigForm.MDIToolStrip_Save.Enabled = false;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = false;
                    break;
                case Enum_Mode.PreSearch:
                case Enum_Mode.Search:
                    ConfigForm.MDIToolStrip_Save.Enabled = false;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = true;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = true;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = true;
                    break;
                case Enum_Mode.PreAdd:
                case Enum_Mode.Add:
                    ConfigForm.MDIToolStrip_Save.Enabled = true;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = true;
                    break;
                case Enum_Mode.PreEdit:
                case Enum_Mode.Edit:
                    ConfigForm.MDIToolStrip_Save.Enabled = true;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = true;
                    break;
                case Enum_Mode.Delete:
                    //ConfigForm.MDIToolStrip_Save.Enabled = true;
                    //ConfigForm.MDIToolStrip_Edit.Enabled = true;
                    //ConfigForm.MDIToolStrip_Add.Enabled = true;
                    break;
                case Enum_Mode.CellClick:
                    ConfigForm.MDIToolStrip_Save.Enabled = false;
                    ConfigForm.MDIToolStrip_Edit.Enabled = true;
                    ConfigForm.MDIToolStrip_Add.Enabled = true;
                    ConfigForm.MDIToolStrip_Delete.Enabled = true;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = true;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = true;
                    break; 
                case Enum_Mode.Import:
                    ConfigForm.MDIToolStrip_Save.Enabled = false;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = true;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = false;
                    break;
                case Enum_Mode.Export:
                    ConfigForm.MDIToolStrip_Save.Enabled = false;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = true;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = false;
                    break;
                case Enum_Mode.SaveOnly:
                    ConfigForm.MDIToolStrip_Save.Enabled = true;
                    ConfigForm.MDIToolStrip_Edit.Enabled = false;
                    ConfigForm.MDIToolStrip_Add.Enabled = false;
                    ConfigForm.MDIToolStrip_Delete.Enabled = false;
                    ConfigForm.MDIToolStrip_Export.Enabled = false;
                    ConfigForm.MDIToolStrip_Import.Enabled = false;
                    ConfigForm.MDIToolStrip_Find.Enabled = false;
                    ConfigForm.MDIToolStrip_Cancel.Enabled = false;
                    break;
            }
        }
        public static void Function_SetButtonScreenAccess(string Str_IDForm)
        {
            WhuserHome WhuserHomeObj = new WhuserHome();
            string Str_WhereGetObj = "UsID ='" + Global.ConfigDatabase.Str_UserID + "' AND ScID ='" + Str_IDForm + "'";

            OPathQuery<WhuserAccess> TempOpath = new OPathQuery<WhuserAccess>(Str_WhereGetObj);

            WhuserHomeObj.WhUserAccessObj = Manager.Engine.GetObject<WhuserAccess>(TempOpath);
            if (WhuserHomeObj.WhUserAccessObj != null)
            {
                    ConfigForm.MDIToolStrip_Edit.Enabled = WhuserHomeObj.WhUserAccessObj.EditR;
                    ConfigForm.MDIToolStrip_Add.Enabled = WhuserHomeObj.WhUserAccessObj.AddR;
                    ConfigForm.MDIToolStrip_Delete.Enabled = WhuserHomeObj.WhUserAccessObj.DeleteR;
            }

        }

        public static void set_header(DataGridView lsv, string FileConfigname)
        {
            try
            {
                // create listview col
                System.Data.DataSet private_dataheader = new System.Data.DataSet();
                
                private_dataheader.ReadXml(FileConfigname); 
                lsv.Columns.Clear();
                HorizontalAlignment colalign;
                for (int i = 0; i < private_dataheader.Tables[0].Rows.Count; i++)
                {
                    string coldesc = private_dataheader.Tables[0].Rows[i]["name"].ToString();
                    string entity = private_dataheader.Tables[0].Rows[i]["entity"].ToString();
                    entity = entity.Trim();
                    int colwidth = int.Parse(private_dataheader.Tables[0].Rows[i]["width"].ToString());

                    switch (private_dataheader.Tables[0].Rows[i]["align"].ToString())
                    {
                        case "left":
                            colalign = HorizontalAlignment.Left;
                            break;
                        case "center":
                            colalign = HorizontalAlignment.Center;
                            break;
                        case "right":
                            colalign = HorizontalAlignment.Right;
                            break;
                        default:
                            colalign = HorizontalAlignment.Left;
                            break;
                    }
                    DataGridViewColumn aa = new DataGridViewColumn();
                    aa.DataPropertyName = entity;
                    aa.Name = entity;
                    aa.HeaderText = coldesc;
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    aa.Width = colwidth;
                    aa.CellTemplate = cell;
                    aa.SortMode = DataGridViewColumnSortMode.Automatic;

                    lsv.Columns.Add(aa);

                }
            }
            catch (Exception ex)
            {
                SS_MyMessageBox.ShowBox(ex.Message, "Error", DialogMode.Error_Cancel);
            }
        }

        public static void Function_AddTabStripButton(int Int_FormTag, string Str_FormName)
        {
            try
            {
                TabStripButton MdiTabStrip = new TabStripButton();
                MdiTabStrip.Name = Str_FormName + Int_FormTag;
                MdiTabStrip.Text = Str_FormName;
                MdiTabStrip.Tag = Int_FormTag;

                ConfigForm.MDITabStrip.Items.Add(MdiTabStrip);
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Function_AddTabStripButton: " + Err.Message, "Error from Function_AddTabStripButton", DialogMode.Error_Cancel);
            }
        }

        public static void Function_RemoveTabStripButton(Object Int_FormTag)
        {
            if (Int_FormTag != null)
            {
                if (ConfigForm.MDITabStrip.Items.Count != 0)
                {
                    foreach (TabStripButton Tab in ConfigForm.MDITabStrip.Items)
                    {
                        if (Tab.Tag.Equals(Int_FormTag))
                        {
                            ConfigForm.MDITabStrip.Items.Remove(Tab);
                            break;
                        }
                    }

                    Global.Location.Int_CountForm--;
                }
            }
        }
        public static void Function_ShowFormSearchOrder()
        {
            Form_001011_Search Frm_SearchPO = new Form_001011_Search();
            Frm_SearchPO.ShowDialog();
        }

        public class FormOrder
        {
            public static void Function_ShowFormDetail(Enum_TypeSearch Type)
            {
                Form_003004_Detail Frm_Detail = new Form_003004_Detail();
                Frm_Detail.Type = Type;
                Frm_Detail.ShowDialog();
            }
            public static void Function_ShowFormSearch(Enum_TypeSearch Type)
            {
                Form_001011_Search Frm_Search = new Form_001011_Search();
                Frm_Search.Type = Type;
                Frm_Search.ShowDialog();
            }
            public static void Function_ShowFormSearch1(Enum_TypeSearch Type, string Str_ModelID)
            {
                Form_001011_Search Frm_Searh = new Form_001011_Search();
                Frm_Searh.Type = Type;
                Frm_Searh.Str_ModelID = Str_ModelID;
                Frm_Searh.ShowDialog();
            }
            public static void Function_ShowFormSearchType(Enum_TypeSearch Type, string Str_ModelID, string Str_FacCode)
            {
                Form_001011_Search Frm_Searh = new Form_001011_Search();
                Frm_Searh.Type = Type;
                Frm_Searh.Str_ModelID = Str_ModelID;
                Frm_Searh.Str_FacCode = Str_FacCode;
                Frm_Searh.ShowDialog();
            }
            public static void Function_ShowFormSearchnew(Enum_TypeSearch Type, string Str_ModelID, string Str_DeptID)
            {
                Form_001011_Search Frm_Searh = new Form_001011_Search();
                Frm_Searh.Type = Type;
                Frm_Searh.Str_ModelID = Str_ModelID;
                Frm_Searh.Str_DeptID = Str_DeptID;
                Frm_Searh.ShowDialog();
            }

            public static void Function_ShowFormSearchFloor(Enum_TypeSearch Type, string Str_BuildID, string Str_FacCode)
            {
                Form_001011_Search Frm_Searh = new Form_001011_Search();
                Frm_Searh.Type = Type;
                Frm_Searh.Str_BuildID = Str_BuildID;
                Frm_Searh.Str_FacCode = Str_FacCode;
                Frm_Searh.ShowDialog();
            }
            public static void Function_ShowFormSearchArea(Enum_TypeSearch Type,string Str_FloorID, string Str_BuildID, string Str_FacCode)
            {
                Form_001011_Search Frm_Searh = new Form_001011_Search();
                Frm_Searh.Type = Type;
                Frm_Searh.Str_BuildID = Str_BuildID;
                Frm_Searh.Str_FacCode = Str_FacCode;
                Frm_Searh.Str_FloorID = Str_FloorID;
                Frm_Searh.ShowDialog();
            }

            public static int Function_SetType(string Str_POType)
            {
                int Int_TempReturn = 0;
                switch (Str_POType)
                {
                    case "PO":
                    case "OUT":
                        Int_TempReturn = 1;
                        break;
                    case "CN":
                    case "IN":
                        Int_TempReturn = 0;
                        break;
                    case "I":
                        Int_TempReturn = 0;
                        break;
                }
                return Int_TempReturn;
            }

            //15/06/2007
            public static string Function_GetSupplierName(string Str_SupplierID)
            {
                string Str_TempVendorName="";
                Vendor TempVendorObj = new Vendor();
                TempVendorObj = Manager.Engine.GetObject<Vendor>(Str_SupplierID);
                if (TempVendorObj != null)
                    Str_TempVendorName = TempVendorObj.FirstName;
                else
                    Str_TempVendorName = "";
                TempVendorObj = null;

                return Str_TempVendorName;
                  
            }

            //15/06/2007
            public static string Function_GetDeptName(string Str_DeptID)
            {
                string Str_TempDeptName = "";
                Department TempDeptObj = new Department();
                TempDeptObj = Manager.Engine.GetObject<Department>(Str_DeptID);
                if (TempDeptObj != null)
                    Str_TempDeptName = TempDeptObj.DeptName;
                else
                    Str_TempDeptName = "";
                TempDeptObj = null;

                return Str_TempDeptName;
            }

            //18/06/2007
            public static string Function_GetFacName(string Str_FacCode)
            {
                string Str_TempFacName = "";
                Facility TempFacilityObj = new Facility();
                TempFacilityObj = Manager.Engine.GetObject<Facility>(Str_FacCode);
                if (TempFacilityObj != null)
                    Str_TempFacName = TempFacilityObj.FacName;
                else
                    Str_TempFacName = "";
                TempFacilityObj = null;
                return Str_TempFacName;
            }

            //20/06/2007
            public static string Function_GetGroupName(string Str_GroupID)
            {
                string Str_TempGroupName = "";
                WhGroup TempGroupObj = new WhGroup();
                TempGroupObj = Manager.Engine.GetObject<WhGroup>(Str_GroupID);
                if (TempGroupObj != null)
                    Str_TempGroupName = TempGroupObj.UsGroupName;
                else
                    Str_TempGroupName = "";
                TempGroupObj = null;
                return Str_TempGroupName;
            }

            //22/06/2007
            public static string Function_GetModelName(string Str_ModelID)
            {
                string Str_TempModelName = "";
                Model TempModelObj = new Model();
                TempModelObj = Manager.Engine.GetObject<Model>(Str_ModelID);
                if (TempModelObj != null)
                    Str_TempModelName = TempModelObj.Name;
                else
                    Str_TempModelName = "";
                TempModelObj = null;
                return Str_TempModelName;
            }

            //22/06/2007
            public static string Function_GetAssetName(string Str_AssetNo)
            {
                string Str_TempAssetName = "";
                Asset TempAssetObj = new Asset();
                TempAssetObj = Manager.Engine.GetObject<Asset>(Str_AssetNo);
                if (TempAssetObj != null)
                    Str_TempAssetName = TempAssetObj.Name;
                else
                    Str_TempAssetName = "";
                TempAssetObj = null;
                return Str_TempAssetName;
            }

            //25/06/2007
            public static string Function_GetTypeName(string Str_TypeNo)
            {
                string Str_TempTypeName = "";
                SimatSoft.DB.ORM.Type TempTypeObj = new SimatSoft.DB.ORM.Type();
                TempTypeObj = Manager.Engine.GetObject<SimatSoft.DB.ORM.Type>(Str_TypeNo);
                if (TempTypeObj != null)
                    Str_TempTypeName = TempTypeObj.Name;
                else
                    Str_TempTypeName = "";
                TempTypeObj = null;
                return Str_TempTypeName;
            }

            //25/06/2007
            public static string Function_GetBuildingName(string Str_BuildID)
            {
                string Str_TempBuildName = "";
                Building TempBuildingObj = new Building();
                TempBuildingObj = Manager.Engine.GetObject<Building>(Str_BuildID);
                if (TempBuildingObj != null)
                    Str_TempBuildName = TempBuildingObj.BuildName;
                else
                    Str_TempBuildName = "";
                TempBuildingObj = null;
                return Str_TempBuildName;
            }

            //25/06/2007
            public static string Function_GetFloorName(string Str_FloorID)
            {
                string Str_TempFloorName = "";
                Floor TempFloorObj = new Floor();
                TempFloorObj = Manager.Engine.GetObject<Floor>(Str_FloorID);
                if (TempFloorObj != null)
                    Str_TempFloorName = TempFloorObj.Name;
                else
                    Str_TempFloorName = "";
                TempFloorObj = null;
                return Str_TempFloorName;
            }

            //25/06/2007
            public static string Function_GetAreaName(string Str_AreaID)
            {
                string Str_TempAreaName = "";
                Area TempAreaObj = new Area();
                TempAreaObj = Manager.Engine.GetObject<Area>(Str_AreaID);
                if (TempAreaObj != null)
                    Str_TempAreaName = TempAreaObj.Name;
                else
                    Str_TempAreaName = "";
                TempAreaObj = null;
                return Str_TempAreaName;
            }

            //25/06/2007
            public static string Function_GetReasonName(string Str_ReasonID)
            {
                string Str_TempReasonName = "";
                Reason TempReasonObj = new Reason();
                TempReasonObj = Manager.Engine.GetObject<Reason>(Str_ReasonID);
                if (TempReasonObj != null)
                    Str_TempReasonName = TempReasonObj.Name;
                else
                    Str_TempReasonName = "";
                TempReasonObj = null;
                return Str_TempReasonName;

            }

            //25/06/2007
            public static string Function_GetCustodianName(string Str_CustodianID)
            {
                string Str_TempCustodianName = "";
                Custodian TempCustodianObj = new Custodian();
                TempCustodianObj = Manager.Engine.GetObject<Custodian>(Str_CustodianID);
                if (TempCustodianObj != null)
                    Str_TempCustodianName = TempCustodianObj.FirstName;
                else
                    Str_TempCustodianName = "";
                TempCustodianObj = null;
                return Str_TempCustodianName;
            }

            //25/06/2007
            public static string Function_GetStatusName(string Str_StatusID)
            {
                string Str_TempStatusName = "";
                Status TempStatusObj = new Status();
                TempStatusObj = Manager.Engine.GetObject<Status>(Str_StatusID);
                if (TempStatusObj != null)
                    Str_TempStatusName = TempStatusObj.Name;
                else
                    Str_TempStatusName = "";
                TempStatusObj = null;
                return Str_TempStatusName;
            }

            //13/07/2008
            public static double Function_GetAssetPrice(string Str_AssetNo)
            {
                double Decimal_TempAssetPrice = 0.0;
                Asset TempAssetObj = new Asset();
                TempAssetObj = Manager.Engine.GetObject<Asset>(Str_AssetNo);
                if (TempAssetObj != null)
                    Decimal_TempAssetPrice = Convert.ToDouble(TempAssetObj.Price);
                else
                    Decimal_TempAssetPrice = 0.0;
                TempAssetObj = null;
                return Decimal_TempAssetPrice;
            }

            //13/07/2008
            public static string Function_GetAssetSerial(string Str_AssetNo)
            {
                string Str_TempStatusName = "";
                Asset TempAssetObj = new Asset();
                TempAssetObj = Manager.Engine.GetObject<Asset>(Str_AssetNo);
                if (TempAssetObj != null)
                    Str_TempStatusName = TempAssetObj.SerialNo;
                else
                    Str_TempStatusName = "";
                TempAssetObj = null;
                return Str_TempStatusName;
            }

            public static void Function_MultiplyPriceAndQty(DataGridViewCellEventArgs e, SS_DataGridView TempDataGridView)
            {
                try
                {
                    //ถ้าใส่ตัวเลขลงในช่อง Qty และ Price ให้นำมาคูนกันแล้วใส่ใน ช่อง Cost
                    if ((e.ColumnIndex == 3))
                    {
                        if ((TempDataGridView[3, e.RowIndex].Value != null) && (TempDataGridView[4, e.RowIndex].Value != null))
                        {
                            int Int_TempQty = Math.Abs(Convert.ToInt32(TempDataGridView[3, e.RowIndex].Value));
                            decimal Int_TempPrice = Convert.ToDecimal(TempDataGridView[4, e.RowIndex].Value);

                            TempDataGridView[3, e.RowIndex].Value = Int_TempQty;
                            TempDataGridView[5, e.RowIndex].Value = Int_TempQty * Int_TempPrice;
                        }
                    }
                }
                catch (FormatException Ex)
                {
                    SS_MyMessageBox.ShowBox("Please insert numeric Data in Price Or Quantity", "Error On Calculate Cost", DialogMode.Error_Cancel, Ex);
                    TempDataGridView[3, e.RowIndex].Value = null;
                    if(TempDataGridView[3,e.RowIndex].Value ==null)
                        TempDataGridView[5,e.RowIndex].Value =null;
                }
                catch (Exception Ex)
                {
                    SS_MyMessageBox.ShowBox(Ex.Message, "Error On Calculate Cost", DialogMode.Error_Cancel, Ex);
                }
            }

            public static void Function_ShiftRowsWhenDelete(DataGridViewRowsRemovedEventArgs e, SS_DataGridView TempDataGridView, Enum_Mode StateForm)
            {
                if (StateForm == Enum_Mode.PreAdd)
                {
                    //ตอน Add ถ้าลบ rows ไหนออกให้ขยับตัวเลขขึ้นมาด้วย
                    int i = 0;
                    for (i = e.RowIndex + 1; i <= TempDataGridView.Rows.Count - 1; i++)
                    {
                        TempDataGridView[0, i - 1].Value = i;
                    }
                }
            }

            public static void Function_PlusLineInDataGrid(DataGridViewRowsAddedEventArgs e, SS_DataGridView TempDataGridView, Enum_Mode StateForm)
            {
                if (e.RowIndex != 0)
                    {
                    switch (StateForm)
                    {
                        case Enum_Mode.PreAdd:
                            //ถ้าเป็น Add ถ้าเพิ่ม Row ให้บวกเลขตามจำนวน rows
                            TempDataGridView[0, e.RowIndex - 1].Value = e.RowIndex;
                            break;
                        case Enum_Mode.PreEdit:
                            if (e.RowIndex == 1)
                                TempDataGridView[0, e.RowIndex - 1].Value = 1;
                            else
                            //ถ้าเป็น Edit ถ้าเพิ่ม Row ให้บวกเลขเพิ่มจากจำนวนมากที่สุดที่มีในดาต้ากริด
                                    TempDataGridView[0, e.RowIndex - 1].Value = Convert.ToInt32(TempDataGridView[0, e.RowIndex - 2].Value) + 1;
                            break;
                    }
                }
            }

            public static int Function_SumQtyBatch(SS_DataGridView TempDataGridView)
            {
                int i = 0;
                int Int_TempSumQty = 0;
                for (i = 0; i <= TempDataGridView.Rows.Count - 2; i++)
                {
                    Int_TempSumQty += Convert.ToInt32(TempDataGridView[1, i].Value);
                }

                return Int_TempSumQty;
            }

            public static int Function_SumQtyBatchReceive(int Int_Key, int Int_Value, System.Collections.Hashtable TempHashTable)
            {
                int Int_SumQtyBatch = 0;
                if (TempHashTable[Int_Key] != null)
                {
                    Int_SumQtyBatch = Convert.ToInt32(TempHashTable[Int_Key]) + Int_Value;

                    TempHashTable.Remove(Int_Key);
                    TempHashTable.Add(Int_Key, Int_SumQtyBatch);
                }
                else
                {
                    TempHashTable.Add(Int_Key, Int_Value);
                    Int_SumQtyBatch = Int_Value;
                }
                return Int_SumQtyBatch;
            }

            public static void Function_MinusQtyBatch(int Int_Key, int Int_Value, System.Collections.Hashtable TempHashTable)
            {
                int Int_MinusQtyBatch = 0;
                if (TempHashTable[Int_Key] != null)
                {
                    Int_MinusQtyBatch = Convert.ToInt32(TempHashTable[Int_Key]) - Int_Value;

                    TempHashTable.Remove(Int_Key);
                    TempHashTable.Add(Int_Key, Int_MinusQtyBatch);
                }
            }
        }  
    }
   }
