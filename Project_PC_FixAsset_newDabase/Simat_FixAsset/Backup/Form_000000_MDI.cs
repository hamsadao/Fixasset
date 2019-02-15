using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;

namespace SimatSoft.FixAsset
{
    public partial class Form_000000_MDI : Form
    {
        public Form_000000_MainMenu frmMenu = new Form_000000_MainMenu();
        private Form_000000_MainMenu Form_Menu;
        //public static Enum_Mode Mode_MDITransaction = new Enum_Mode();
        private bool Bool_CheckCantConnect = false;
        
        public Form_000000_MDI()
        {
            try
            {
                InitializeComponent();
                bool Bool_TempFlagConnection = Function_CheckConnection("DBServer");
                bool Bool_TempFlagConnectionPic = Function_CheckConnection("DBServerPic");

                if ((Bool_TempFlagConnection) && (Bool_TempFlagConnectionPic))
                {
                    Global.Lang.Str_Language = SimatSoft.DB.ORM.Manager.Str_language;
                    Function_IntitialControl();
                    Global.ConfigForm.MDIToolStrip_Save = toolStripButton_Save;
                    Global.ConfigForm.MDIToolStrip_Edit = toolStripButton_Edit;
                    Global.ConfigForm.MDIToolStrip_Add = toolStripButton_Add;
                    Global.ConfigForm.MDIToolStrip_Delete = toolStripButton_Delete;
                    Global.ConfigForm.MDIToolStrip_Export = toolStripButton_Export;
                    Global.ConfigForm.MDIToolStrip_Cancel = toolStripButton_Cancel;
                    Global.ConfigForm.MDIToolStrip_Import = toolStripButton_Import;
                    Global.ConfigForm.MDIToolStrip_Find = toolStripButton_Find;
                    Global.ConfigForm.MDITabStrip = sS_TabStrip_MDITab;
                }
                else
                {
                    Form_007000_DatabaseSetup Frm_TempServer = new Form_007000_DatabaseSetup();
                    Frm_TempServer.Bool_Connection = Bool_TempFlagConnection;
                    Frm_TempServer.Bool_ConnectionPic = Bool_TempFlagConnectionPic;
                    Frm_TempServer.ShowDialog();
                    Bool_CheckCantConnect = true;
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On MDI Change Language", DialogMode.Error_Cancel, Ex);
            }
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001000(MDI)");
            ToolStripMenuItem_File.Text = Global.Function_Language(this, ToolStripMenuItem_File, "File");
            ToolStrip_MainMenu.Text = Global.Function_Language(this, ToolStrip_MainMenu, "Main Menu");
            ToolStrip_Exit.Text = Global.Function_Language(this, ToolStrip_Exit, "Exit");
            ToolStripMenuItem_Edit.Text = Global.Function_Language(this, ToolStripMenuItem_Edit, "Edit");
            ToolStrip_Undo.Text = Global.Function_Language(this, ToolStrip_Undo, "&Undo");
            ToolStrip_Cut.Text = Global.Function_Language(this, ToolStrip_Cut, "Cu&t");
            ToolStrip_Copy.Text = Global.Function_Language(this, ToolStrip_Copy, "&Copy");
            ToolStrip_Paste.Text = Global.Function_Language(this, ToolStrip_Paste, "&Paste");
            ToolStrip_Find.Text = Global.Function_Language(this, ToolStrip_Find, "&Find");
            ToolStrip_SelectAllRecords.Text = Global.Function_Language(this, ToolStrip_SelectAllRecords, "Select &All Records");
            ToolStrip_Replace.Text = Global.Function_Language(this, ToolStrip_Replace, "Replace");
            toolStripMenuItem_Window.Text = Global.Function_Language(this, toolStripMenuItem_Window, "Window");
            ToolStrip_Cascade.Text = Global.Function_Language(this, ToolStrip_Cascade, "Cascade");
            ToolStrip_TileHorizontal.Text = Global.Function_Language(this, ToolStrip_TileHorizontal, "Tile Hirizontal");
            ToolStrip_TileVertical.Text = Global.Function_Language(this, ToolStrip_TileVertical, "Tile Vertical");
            ToolStripMenuItem_About.Text = Global.Function_Language(this, ToolStripMenuItem_About, "About");
            ToolStripMenuItem_Help.Text = Global.Function_Language(this, ToolStripMenuItem_Help, "Help");
            ToolStrip_UserManual.Text = Global.Function_Language(this, ToolStrip_UserManual, "User Manual");
            toolStripButton_Save.Text = Global.Function_Language(this, toolStripButton_Save, "Save");
            toolStripButton_Add.Text = Global.Function_Language(this, toolStripButton_Add, "Add");
            toolStripButton_Edit.Text = Global.Function_Language(this, toolStripButton_Edit, "Edit");
            toolStripButton_Delete.Text = Global.Function_Language(this, toolStripButton_Delete, "Delete");
            toolStripButton_Find.Text = Global.Function_Language(this, toolStripButton_Find, "Find");
            toolStripButton_Export.Text = Global.Function_Language(this, toolStripButton_Export, "Export");
            toolStripButton_Cancel.Text = Global.Function_Language(this, toolStripButton_Cancel, "Cancel");
            toolStripStatusLabel_Server.Text = Global.Function_Language(this, toolStripStatusLabel_Server, "ServerName:");
            toolStripStatusLabel_DB.Text = Global.Function_Language(this, toolStripStatusLabel_DB, "Database:");
            toolStripStatusLabel_LogOn.Text = Global.Function_Language(this, toolStripStatusLabel_LogOn, "Log On As:");
            toolStripStatusLabel_Fac.Text = Global.Function_Language(this, toolStripStatusLabel_Fac, "Company:");
        }
        private void Form_001002_MDI_Load(object sender, EventArgs e)
        {
            try
            {
                this.toolStripStatusLabel_Date.Text = DateTime.Now.ToLongDateString();
                this.toolStripStatusLabel_Time.Text = DateTime.Now.ToLongTimeString();
                if (Bool_CheckCantConnect)
                {
                    Application.Exit();
                }
                else
                {

                    Form_000000_LOGIN frmLogin = new Form_000000_LOGIN();
                    frmLogin.ShowDialog();

                    Function_IntitialControl();

                    this.toolStripStatusLabel_LogOn.Text = Global.Function_Language(this, toolStripStatusLabel_LogOn, "Log On As: ") + Global.ConfigDatabase.Str_UserID;
                    this.toolStripStatusLabel_DB.Text = Global.Function_Language(this, toolStripStatusLabel_DB, "Database:") + Global.ConfigDatabase.Str_Database;
                    this.toolStripStatusLabel_Server.Text = Global.Function_Language(this, toolStripStatusLabel_Server, "ServerName:") + Global.ConfigDatabase.Str_ServerName;
                    this.toolStripStatusLabel_Fac.Text = Global.Function_Language(this, toolStripStatusLabel_Fac, "Company:") + Global.ConfigDatabase.Str_Company;

                    frmMenu.MdiParent = this;
                    frmMenu.Show();
                    Form_Menu = frmMenu;
                    cls_main.clsmainmenu.CreatemainmenuToolStrip(vToolStripMenuItem);
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error On MDI Load", DialogMode.Error_Cancel, Err);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form_Menu.IsMdiContainer = false;
            this.LayoutMdi(MdiLayout.Cascade);
            Form_Menu.Location = new Point(0, -2);
            Form_Menu.BringToFront();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form_Menu.IsMdiContainer = false;
            this.LayoutMdi(MdiLayout.TileVertical);
            Form_Menu.Location = new Point(0, -2);
            Form_Menu.BringToFront();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Menu.IsMdiContainer = false;
            this.LayoutMdi(MdiLayout.TileHorizontal);
            Form_Menu.Location = new Point(0, -2);
            Form_Menu.BringToFront();
        }

        private void ToolStrip_fixAsset_Click(object sender, EventArgs e)
        {
            Form_002006_Company frmFixAsset = new Form_002006_Company();
            frmFixAsset.MdiParent = this;
            frmFixAsset.Show();
        }
       private void ToolStrip_asset_Click(object sender, EventArgs e)
        {
            Form_002001_Asset frmAsset = new Form_002001_Asset();
            frmAsset.MdiParent = this;
            frmAsset.Show();
        }

        private void ToolStrip_building_Click(object sender, EventArgs e)
        {
            Form_002008_Building frmBuilding = new Form_002008_Building();
            frmBuilding.MdiParent = this;
            frmBuilding.Show();
        }

        private void ToolStrip_floor_Click(object sender, EventArgs e)
        {
            Form_002009_Floor frmFloor = new Form_002009_Floor();
            frmFloor.MdiParent = this;
            frmFloor.Show();
        }

        private void ToolStrip_area_Click(object sender, EventArgs e)
        {
            Form_002007_Area frmArea = new Form_002007_Area();
            frmArea.MdiParent = this;
            frmArea.Show();
        }

        private void ToolStrip_department_Click(object sender, EventArgs e)
        {
            Form_002010_Department frmDept = new Form_002010_Department();
            frmDept.MdiParent = this;
            frmDept.Show();
        }

        private void ToolStrip_model_Click(object sender, EventArgs e)
        {
            Form_002002_Model frmModel = new Form_002002_Model();
            frmModel.MdiParent = this;
            frmModel.Show();
        }

        private void ToolStrip_reason_Click(object sender, EventArgs e)
        {
            Form_002012_Reason frmReason = new Form_002012_Reason();
            frmReason.MdiParent = this;
            frmReason.Show();
        }

        private void ToolStrip_assetImage_Click(object sender, EventArgs e)
        {
            Form_002003_Pictures frmAssetImage = new Form_002003_Pictures();
            frmAssetImage.MdiParent = this;
            frmAssetImage.Show();
        }

        private void ToolStrip_custodian_Click(object sender, EventArgs e)
        {
            Form_002011_Custodian frmCustodian = new Form_002011_Custodian();
            frmCustodian.MdiParent = this;
            frmCustodian.Show();
        }

        private void ToolStrip_assetType_Click(object sender, EventArgs e)
        {
            Form_002004_Type frmAssetType = new Form_002004_Type();
            frmAssetType.MdiParent = this;
            frmAssetType.Show();
        }

        private void ToolStrip_vendor_Click(object sender, EventArgs e)
        {
            Form_002005_Supplier frmVendor = new Form_002005_Supplier();
            frmVendor.MdiParent = this;
            frmVendor.Show();
        }

        private void ToolStrip_MainMenu_Click(object sender, EventArgs e)
        {
            Form_000000_MainMenu frmMenu = new Form_000000_MainMenu();
            frmMenu.MdiParent = this;
            frmMenu.Show();
        }

        private void ToolStrip_InventoryHistory_Click(object sender, EventArgs e)
        {
            Form_003001_HistoryAsset frmInventoryHistory = new Form_003001_HistoryAsset();
            frmInventoryHistory.MdiParent = this;
            frmInventoryHistory.Show();
        }

        private void ToolStrip_report_Click(object sender, EventArgs e)
        {
            Form_003001_REPORT frmReport = new Form_003001_REPORT();
            frmReport.MdiParent = this;
            frmReport.Show();
        }

        private void ToolStrip_Barcode_Click(object sender, EventArgs e)
        {
            Form_005001_Barcode_Asset frmBarcode = new Form_005001_Barcode_Asset();
            frmBarcode.MdiParent = this;
            frmBarcode.Show();
        }

        private void ToolStrip_UserStatus_Click(object sender, EventArgs e)
        {
            Form_006001_UserAuthorize frmUserStatus = new Form_006001_UserAuthorize();
            frmUserStatus.MdiParent = this;
            frmUserStatus.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel_Time.Text = DateTime.Now.ToLongTimeString();
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_001000_UserManul frm = new Form_001000_UserManul();
            frm.Show();
        }
        private void ToolStripMenuItem_About_Click(object sender, EventArgs e)
        {
            Form_001000_ABOUT frmAbout = new Form_001000_ABOUT();
            frmAbout.ShowDialog();
        }

        private void ToolStrip_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ToolStripMenuItem_CloseAll_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form Frm_child in charr)
                Frm_child.Close();
        }

        private void ToolStripMenuItem_MaximizeAll_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

        private void ToolStripMenuItem_MinimizeAll_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Minimized;
        }
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            try
            {
                switch (Global.ConfigForm.Enum_FlagTransaction)
                {
                    case Enum_Mode.PreAdd:
                        Function_MDITransaction(Enum_Mode.Add);
                        if (Global.Bool_CheckComplete)
                        {
                            Global.Function_ToolStripSetUP(Enum_Mode.Search);
                        }
                        break;
                    case Enum_Mode.PreEdit:
                        Function_MDITransaction(Enum_Mode.Edit);
                        if (Global.Bool_CheckComplete)
                        {
                           // Global.Function_ToolStripSetUP(Enum_Mode.Search);
                            Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                        }
                        break;
                    case Enum_Mode.SaveOnly:
                        Function_MDITransaction(Enum_Mode.Edit);
                        if (Global.Bool_CheckComplete)
                        {
                            Global.Function_ToolStripSetUP(Enum_Mode.SaveOnly);
                        }
                        break;
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On MDI Button Save Click", DialogMode.Error_Cancel, Ex);
            }
            //if (Mode_MDITransaction == Enum_Mode.PreAdd)
            //{
            //    Function_MDITransaction(Enum_Mode.Add);
            //    Global.Function_ToolStripSetUP(Enum_Mode.Search);
            //}
            //else if (Mode_MDITransaction == Enum_Mode.PreEdit)
            //{
            //    Function_MDITransaction(Enum_Mode.Edit);
            //    Global.Function_ToolStripSetUP(Enum_Mode.Search);

            //}
            //else
            //{
            //    Function_MDITransaction(Enum_Mode.Search);
            //}
        }
        public void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Function_MDITransaction(Enum_Mode.PreAdd);
            Global.Function_ToolStripSetUP(Enum_Mode.Add);
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreAdd;
        }
        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            Function_MDITransaction(Enum_Mode.PreEdit);
            Global.Function_ToolStripSetUP(Enum_Mode.Edit);
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreEdit;
        }
        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Delete);
            Function_MDITransaction(Enum_Mode.Delete);

            if (Global.Bool_CheckComplete == true)
                Global.Function_ToolStripSetUP(Enum_Mode.Search);
            else
                Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
        }
        private void toolStripButton_Import_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Import);
            Function_MDITransaction(Enum_Mode.Import);
           // Global.Function_ToolStripSetUP(Enum_Mode.Import);
           // string state = "0";
           // Global.STR_State = state;
           // if (state == "0")
           // {
           //     Global.Function_ToolStripSetUP(Enum_Mode.Import);
           //     Function_MDITransaction(Enum_Mode.Import);
               
           // }
           //else
           // {
           //     Global.Function_ToolStripSetUP(Enum_Mode.Export);
           //     Function_MDITransaction(Enum_Mode.Export);
           // }           
           // Global.Function_ToolStripSetUP(Enum_Mode.Import);
        }
        private void toolStripButton_Export_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Export);
            Function_MDITransaction(Enum_Mode.Export);
        }
        public void Function_MDITransaction(Enum_Mode mode)
        {
            try
            {
                switch (this.ActiveMdiChild.Name)
                {
                    case "Form_002008_Building":
                        Form_002008_Building Frm_Building = (Form_002008_Building)this.ActiveMdiChild;
                        Frm_Building.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002009_Floor":
                        Form_002009_Floor Frm_Floor = (Form_002009_Floor)this.ActiveMdiChild;
                        Frm_Floor.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002007_Area":
                        Form_002007_Area Frm_Area = (Form_002007_Area)this.ActiveMdiChild;
                        Frm_Area.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002010_Department":
                        Form_002010_Department Frm_Department = (Form_002010_Department)this.ActiveMdiChild;
                        Frm_Department.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002002_Model":
                        Form_002002_Model Frm_Model = (Form_002002_Model)this.ActiveMdiChild;
                        Frm_Model.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002012_Reason":
                        Form_002012_Reason Frm_Reason = (Form_002012_Reason)this.ActiveMdiChild;
                        Frm_Reason.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002004_Type":
                        Form_002004_Type Frm_Type = (Form_002004_Type)this.ActiveMdiChild;
                        Frm_Type.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002005_Supplier":
                        Form_002005_Supplier Frm_Supplier = (Form_002005_Supplier)this.ActiveMdiChild;
                        Frm_Supplier.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002011_Custodian":
                        Form_002011_Custodian Frm_Custodian = (Form_002011_Custodian)this.ActiveMdiChild;
                        Frm_Custodian.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002006_Company":
                        Form_002006_Company Frm_Company = (Form_002006_Company)this.ActiveMdiChild;
                        Frm_Company.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002001_Asset":
                        Form_002001_Asset Frm_Asset = (Form_002001_Asset)this.ActiveMdiChild;
                        Frm_Asset.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002013_Status":
                        Form_002013_Status Frm_Status = (Form_002013_Status)this.ActiveMdiChild;
                        Frm_Status.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_002003_Pictures":
                        Form_002003_Pictures Frm_Picture = (Form_002003_Pictures)this.ActiveMdiChild;
                        Frm_Picture.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001001_PurchaseOrder":
                        Form_001001_PurchaseOrder Frm_PurchaseOrder = (Form_001001_PurchaseOrder)this.ActiveMdiChild;
                        Frm_PurchaseOrder.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001002_ReceivePurchaseOrder":
                        Form_001002_ReceivePurchaseOrder Frm_ReceivePO = (Form_001002_ReceivePurchaseOrder)this.ActiveMdiChild;
                        Frm_ReceivePO.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001008_ImportFile":
                        Form_001008_ImportFile Frm_ImportFile = (Form_001008_ImportFile)this.ActiveMdiChild;
                        object d = Frm_ImportFile.ind;
                        Frm_ImportFile.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001007_Upload_Download_HH":
                        Form_001007_Upload_Download_HH Frm_Upload_Download_HH = (Form_001007_Upload_Download_HH)this.ActiveMdiChild;
                        Frm_Upload_Download_HH.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001003_InternalTransferOrder":
                        Form_001003_InternalTransferOrder Frm_InternalTrasferOrder = (Form_001003_InternalTransferOrder)this.ActiveMdiChild;
                        Frm_InternalTrasferOrder.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001004_InternalTransfer":
                        Form_001004_InternalTransfer Frm_InternalTransfer = (Form_001004_InternalTransfer)this.ActiveMdiChild;
                        Frm_InternalTransfer.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001005_ExternalTransferOrder":
                        Form_001005_ExternalTransferOrder Frm_ExternalTransferOrder = (Form_001005_ExternalTransferOrder)this.ActiveMdiChild;
                        Frm_ExternalTransferOrder.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001006_ExternalTransfer":
                        Form_001006_ExternalTransfer Frm_ExternalTransfer = (Form_001006_ExternalTransfer)this.ActiveMdiChild;
                        Frm_ExternalTransfer.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001010_WriteOff":
                        Form_001010_WriteOff Form_WriteOff = (Form_001010_WriteOff)this.ActiveMdiChild;
                        Form_WriteOff.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_001012_ReceiveNonePO":
                        Form_001012_ReceiveNonePO Frm_ReceiveNonePO = (Form_001012_ReceiveNonePO)this.ActiveMdiChild;
                        Frm_ReceiveNonePO.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005001_Barcode_Asset":
                        Form_005001_Barcode_Asset Frm_BarcodeAsset = (Form_005001_Barcode_Asset)this.ActiveMdiChild;
                        Frm_BarcodeAsset.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005002_Barcode_Model":
                        Form_005002_Barcode_Model Frm_BarcodeModel = (Form_005002_Barcode_Model)this.ActiveMdiChild;
                        Frm_BarcodeModel.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005003_Barcode_Area":
                        Form_005003_Barcode_Area Frm_BarcodeArea = (Form_005003_Barcode_Area)this.ActiveMdiChild;
                        Frm_BarcodeArea.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005004_Barcode_Building":
                        Form_005004_Barcode_Building Frm_BarcodeBuilding = (Form_005004_Barcode_Building)this.ActiveMdiChild;
                        Frm_BarcodeBuilding.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005005_Barcode_Floor":
                        Form_005005_Barcode_Floor Frm_BarcodeFloor = (Form_005005_Barcode_Floor)this.ActiveMdiChild;
                        Frm_BarcodeFloor.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005006_Barcode_Department":
                        Form_005006_Barcode_Department Frm_BarcodeDepartment = (Form_005006_Barcode_Department)this.ActiveMdiChild;
                        Frm_BarcodeDepartment.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_005007_Barcode_Custodian":
                        Form_005007_Barcode_Custodian Frm_BarcodeCustodian = (Form_005007_Barcode_Custodian)this.ActiveMdiChild;
                        Frm_BarcodeCustodian.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_006001_UserAuthorize":
                        Form_006001_UserAuthorize Frm_UserAutolize = (Form_006001_UserAuthorize)this.ActiveMdiChild;
                        Frm_UserAutolize.Function_ExecuteTransaction(mode);
                        break;
                    case "Form_006002_UserGroupAuthorize":
                        Form_006002_UserGroupAuthorize Frm_UserGroupAutolize = (Form_006002_UserGroupAuthorize)this.ActiveMdiChild;
                        Frm_UserGroupAutolize.Function_ExecuteTransaction(mode);
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);

            }
        }

        private void toolStripButton_Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.ConfigForm.Enum_FlagTransaction == Enum_Mode.PreAdd)
                {
                    Function_MDITransaction(Enum_Mode.Cancel);
                    Global.Function_ToolStripSetUP(Enum_Mode.Search);
                }
                else if (Global.ConfigForm.Enum_FlagTransaction == Enum_Mode.PreEdit)
                {
                    //if (Global.ConfigForm.Enum_FlagTransaction == Enum_Mode.PreEdit)
                    //{
                    Function_MDITransaction(Enum_Mode.Cancel);
                    Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                    //}
                }
                else
                {
                    if (Global.ConfigForm.Enum_FlagTransaction == Enum_Mode.SaveOnly)
                    {
                        Function_MDITransaction(Enum_Mode.Cancel);
                        Global.Function_ToolStripSetUP(Enum_Mode.SaveOnly);
                    }
                }
            
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On MDI Button Cancel Click", DialogMode.Error_Cancel, Ex);

            }

        }
        private void sS_TabStrip_MDITab_SelectedTabChanged(object sender, SelectedTabChangedEventArgs e)
        {
            if (sS_TabStrip_MDITab.Items.Count != 0)
            {
                foreach (Form Frm in this.MdiChildren)
                {
                    if (Frm.Name != "Form_000000_MainMenu")
                    {
                        //Check for its corresponding MDI child form
                        if (Frm.Tag.Equals(e.SelectedTab.Tag))
                        {
                            //Activate the MDI child form
                            Frm.Select();
                        }
                    }
                }
            }
        }

        private void Form_000000_MDI_MdiChildActivate(object sender, EventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    if (sS_TabStrip_MDITab.Items.Count != 0)
                    {
                        if (this.ActiveMdiChild.Tag != null)
                        {
                            foreach (TabStripButton Tab in sS_TabStrip_MDITab.Items)
                            {
                                if (Tab.Tag.Equals(this.ActiveMdiChild.Tag))
                                {
                                    sS_TabStrip_MDITab.SelectedTab = Tab;
                                }

                            }
                        }
                    }
                }
                else
                {
                    sS_TabStrip_MDITab.Items.Clear();
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On MDI Selected Tab when select Form", DialogMode.Error_Cancel, Ex);
            }
        }
        private Boolean Function_CheckConnection(string Str_ServerType)
        {
            try
            {
                switch (Str_ServerType)
                {
                    case "DBServer":
                        string Str_TempManager = SimatSoft.DB.ORM.Manager.Str_configfilename;
                        Str_TempManager = null;
                        break;
                    case "DBServerPic":
                        string Str_TempManagerPic = SimatSoft.DB.ORM.ManagerPic.Str_configfilename;
                        Str_TempManagerPic = null;
                        break;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void toolStripButton_Find_Click(object sender, EventArgs e)
        {
            Function_MDITransaction(Enum_Mode.PreSearch);
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreSearch;

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form[] charr = this.MdiChildren;
                foreach (Form Frm_child in charr)
                    Frm_child.Close();

                Form_000000_LOGIN frmLogin = new Form_000000_LOGIN();
                frmLogin.ShowDialog();

                Function_IntitialControl();

                this.toolStripStatusLabel_LogOn.Text = Global.Function_Language(this, toolStripStatusLabel_LogOn, "Log On As: ") + Global.ConfigDatabase.Str_UserID;
                this.toolStripStatusLabel_DB.Text = Global.Function_Language(this, toolStripStatusLabel_DB, "Database:") + Global.ConfigDatabase.Str_Database;
                this.toolStripStatusLabel_Server.Text = Global.Function_Language(this, toolStripStatusLabel_Server, "ServerName:") + Global.ConfigDatabase.Str_ServerName;
                this.toolStripStatusLabel_Fac.Text = Global.Function_Language(this, toolStripStatusLabel_Fac, "Company:") + Global.ConfigDatabase.Str_Company;

                Form_000000_MainMenu frmMenu = new Form_000000_MainMenu();
                frmMenu.MdiParent = this;
                frmMenu.Show();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "logoutToolStripMenuItem_Click", DialogMode.Error_Cancel, Err);
            }
        }

        private void configSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_007000_DatabaseSetup frmDB = new Form_007000_DatabaseSetup();
            frmDB.MdiParent = this;
            frmDB.Show();
        }

       

       
    }
}
