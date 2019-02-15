using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;
using System.Xml;
using Wilson.ORMapper;
using System.IO;
using OpenNETCF.Desktop.Communication;
using System.Threading;
using System.Globalization;
using SimatSoft.FixAsset.Cls;

namespace SimatSoft.FixAsset
{
    public partial class Form_001007_Upload_Download_HH : SS_PaintGradientForm
    {
        //Import=0,Export=1

        public object ind = Global.IndexArray.Add(0);
        System.Collections.ArrayList Arry_TempFileName = new System.Collections.ArrayList();
        string STR_PathExport = "C:\\Export\\";
        string STR_PathDowloadFromHH = "C:\\Import\\";
        bool Bool_CheckComplete = false;

        RAPI m_rapi;
        string RapiErr = "";
        int imgID = 1;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        // This thread is used to demonstrate both thread-safe and
        // unsafe ways to call a Windows Forms control.
        //private Thread demoThread = null;

        // This BackgroundWorker is used to demonstrate the 
        // preferred way of performing asynchronous operations.
        //private BackgroundWorker backgroundWorker1;

        private string[] iniConfig = new string[3];
        private string[] iniConfigImport = new string[3];

        public Form_001007_Upload_Download_HH()
        {
            InitializeComponent();
            m_rapi = new RAPI();
            //Set Color statusBar//
            // statusStrip1.BackColor = Global.ConfigForm.Colr_ColorStatus;
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Import);

            m_rapi = new RAPI();

            // wire in some ActiveSync events
            m_rapi.ActiveSync.Active += new ActiveHandler(ActiveSync_Active);
            m_rapi.ActiveSync.Disconnect += new DisconnectHandler(ActiveSync_Disconnect);
            m_rapi.ActiveSync.Listen += new ListenHandler(ActiveSync_Listen);
            m_rapi.ActiveSync.Answer += new AnswerHandler(ActiveSync_Answer);
        }


        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001007(Upload/Download with Handheld)");
            groupBox_Download.Text = Global.Function_Language(this, groupBox_Download, " Download_From_Handheld:");
            groupBox_Upload.Text = Global.Function_Language(this, groupBox_Upload, "Upload_To_Handheld");
            checkBox_DownloadAsset.Text = Global.Function_Language(this, checkBox_DownloadAsset, "Asset");
            checkBox_DownloadCheckStock.Text = Global.Function_Language(this, checkBox_DownloadCheckStock, "CheckStock");
            checkBox_UploadAsset.Text = Global.Function_Language(this, checkBox_UploadAsset, "Asset");
            checkBox_UploadPurchaseOrder.Text = Global.Function_Language(this, checkBox_UploadPurchaseOrder, "Purchase Order");
            checkBox_UploadBuilding.Text = Global.Function_Language(this, checkBox_UploadBuilding, "Building");
            checkBox_UploadSuplier.Text = Global.Function_Language(this, checkBox_UploadSuplier, "Supplier");
            checkBox_UploadFloor.Text = Global.Function_Language(this, checkBox_UploadFloor, "Floor");
            checkBox_UploadCompany.Text = Global.Function_Language(this, checkBox_UploadCompany, "Company");
            checkBox_UploadArea.Text = Global.Function_Language(this, checkBox_UploadArea, "Area");
            LBL_UploadSelected.Text = Global.Function_Language(this, LBL_UploadSelected, "Table Selected:");
            lbl_StatusSync.Text = Global.Function_Language(this, lbl_StatusSync, "StatusSync");
        }
        void Conn()
        {
            m_rapi.RAPIConnected += new RAPIConnectedHandler(m_rapi_RAPIConnected);
            m_rapi.RAPIDisconnected += new RAPIConnectedHandler(m_rapi_RAPIDisconnected);
            m_rapi.Connect(false, -1);
        }
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lbl_StatusSync.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                // SetTextCallback i = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
                //this.Invoke(i, new object[] { imgID.ToString() });
            }
            else
            {
                this.lbl_StatusSync.Text = text;
            }
            try
            {
                switch (imgID)
                {
                    case 0: picBoxSync.Image = imgLst_SelectFile.Images[1]; break;
                    case 1: picBoxSync.Image = imgLst_SelectFile.Images[2]; break;
                    case 2: picBoxSync.Image = imgLst_SelectFile.Images[3]; break;
                    default: picBoxSync.Image = imgLst_SelectFile.Images[1]; break;
                }
            }
            catch
            {
            }
        }

        private void m_rapi_RAPIConnected()
        {
            imgID = 2;
            SetText("Connected...");
            //connectStatus.Text = "Connected";
            //bt_Connect.Enabled = false;
            //connectSync.Enabled = false;
        }

        private void m_rapi_RAPIDisconnected()
        {
            //connectStatus.Text = "Not Connected";
            imgID = 1;
            SetText("Not Connected...");

            //bt_Connect.Enabled = true;
            // connectSync.Enabled = true;
        }
        private void ActiveSync_Active()
        {
            //status.Text = "Connected";
            imgID = 2;
            SetText("Connected...");
            Conn();
        }

        private void ActiveSync_Disconnect()
        {
            // status.Text = "Disconnected";
            imgID = 0;
            SetText("Disconnected...");

        }

        private void ActiveSync_Listen()
        {
            //status.Text = "Not connected";
            imgID = 1;
            SetText("Not Connected...");

        }

        private void ActiveSync_Answer()
        {
            //status.Text = "Connecting...";
            imgID = 0;
            SetText("Connecting...");
        }

        private void Form_001003_Upload_Download_HH_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
            m_rapi.Dispose();
        }

        private string Table = "CheckStock";
        

        private void checkBox_UploadAsset_CheckStateChanged(object sender, EventArgs e)
        {
            Table = "";
            CheckBox TempCheckBox = (CheckBox)sender;
            if (TempCheckBox.CheckState ==CheckState.Checked)
            {

                if (groupBox_Download.Controls.Contains(TempCheckBox))
                {
                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        if (checkTemp != TempCheckBox)
                        {
                            checkTemp.Checked = false;
                            
                        }
                    }
                    foreach (CheckBox checkTemp in groupBox_Upload.Controls)
                    {
                        checkTemp.Checked = false;
                        
                    }
                   
                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 0);
                    Global.Function_ToolStripSetUP(Enum_Mode.Import);
                   
                }
                else if(groupBox_Upload.Controls.Contains(TempCheckBox))
                {
          
                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        checkTemp.Checked = false;
                        
                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 1);
                    Global.Function_ToolStripSetUP(Enum_Mode.Export);

                }
                this.Table = TempCheckBox.Text;
                this.LBL_UploadSelected.Text = string.Format(" Table selected : {0}", this.Table);
                
            }
          }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                Arry_TempFileName.Clear();
               

                    switch (mode)
                    {
                        case Enum_Mode.Import:
                            {
                                if (m_rapi.Connected)
                                {
                                    ind = Global.IndexArray.Add(1);
                                    Cursor.Current = Cursors.WaitCursor;
                                    if (CopyFileFromDevice() == false)
                                    {
                                        SS_MyMessageBox.ShowBox("You can't connect to device", "Error", DialogMode.Error_Cancel, this.Name, "000001", Global.Lang.Str_Language);
                                    }
                                    else
                                    {
                                        foreach (CheckBox TempCheckBox in groupBox_Download.Controls)
                                        {
                                            if (TempCheckBox.CheckState == CheckState.Checked)
                                            {

                                                string Str_TempFile = TempCheckBox.Text + ".XML";
                                               
                                                Arry_TempFileName.Add(Str_TempFile);
                                                Function_ReadXMLtoDatabase(TempCheckBox.Text);
                                                Cursor.Current = Cursors.Default;
                                                SS_MyMessageBox.ShowBox("Import Data Complete", "Information", DialogMode.OkOnly, this.Name, "000002", Global.Lang.Str_Language);
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("You can't connect to device", "Error", DialogMode.Error_Cancel, this.Name, "000001", Global.Lang.Str_Language);
                                }
                               // Function_ClearData(groupBox_Download.Controls);
                               
                            }
                            break;

                        case Enum_Mode.Export:
                            {
                                if (m_rapi.Connected)
                                {
                                    foreach (CheckBox TempCheckBox in groupBox_Upload.Controls)
                                    {
                                        if (TempCheckBox.CheckState == CheckState.Checked)
                                        {
                                            if (TempCheckBox.Text != "Asset Picture")
                                            {
                                                // Edit for CEVA on 12-02-09
                                               // Function_RetriveDataToXML(TempCheckBox.Text);
                                                RetriveDataToSDF rtSDF = new RetriveDataToSDF();
                                                rtSDF.Function_RetriveDataToSDF(TempCheckBox.Text);
                                                ////////////
                                                string Str_TempFile = TempCheckBox.Text + ".XML";
                                                if (TempCheckBox.Text == "Company")
                                                    Str_TempFile = "Facility.XML";
                                                if (TempCheckBox.Text == "User")
                                                    Str_TempFile = "Whuser.XML";
                                                Arry_TempFileName.Add(Str_TempFile);
                                            }
                                            else
                                            { 
                                                
                                              Function_RetriveDataToXML(TempCheckBox.Text);
                                                
                                            }
                                        }

                                    }
                                    Cursor.Current = Cursors.WaitCursor;

                                    CopyFileToDevice();
                                    SS_MyMessageBox.ShowBox("Export File To Device Complete", "Information", DialogMode.OkOnly, this.Name, "000003", Global.Lang.Str_Language);
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("You can't connect to device", "Error", DialogMode.Error_Cancel, this.Name, "000001", Global.Lang.Str_Language);
                                }
                                //Function_ClearData(groupBox_Upload.Controls);
                       }
                            break;
                    }
                
              

            }
            catch (OpenNETCF.Desktop.Communication.RAPIException)
            {
                SS_MyMessageBox.ShowBox("File not found in device", "Error", DialogMode.Error_Cancel, this.Name, "000004", Global.Lang.Str_Language);
            }
            catch (ArgumentException)
            {
                SS_MyMessageBox.ShowBox("File does not create,Please choose new table again", "Error", DialogMode.Error_Cancel, this.Name, "000005", Global.Lang.Str_Language);
              
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Function_ClearData(GroupBox.ControlCollection TempGroupBox)
        {
            foreach (CheckBox TempChecBox in TempGroupBox)
            {
                if (TempChecBox.CheckState == CheckState.Checked)
                {
                    TempChecBox.Checked = false;
                }
            }
            listView_Complete.Items.Clear();
            listView_Error.Items.Clear();
            progressBar1.Value = 0;
            lbl_ShowStatus.Text = "...";
            LBL_TotalError.Text = "...";

            Cursor.Current = Cursors.Default;
        }
        public static string ConvertDatetime(System.DateTime dt, int formatid)
        {
            String[] format = {
            "d", "D",
            "f", "F",
            "g", "G",
            "m",
            "r",
            "s",
            "t", "T",
            "u", "U",
            "y",
            "dddd, MMMM dd yyyy",
            "ddd, MMM d \"'\"yy",
            "dddd, MMMM dd",
            "M/yy",
            "dd-MM-yy",
            };
            /** Output.
           *
           * d :08/17/2000
           * D :Thursday, August 17, 2000
           * f :Thursday, August 17, 2000 16:32
           * F :Thursday, August 17, 2000 16:32:32
           * g :08/17/2000 16:32
           * G :08/17/2000 16:32:32
           * m :August 17
           * r :Thu, 17 Aug 2000 23:32:32 GMT
           * s :2000-08-17T16:32:32
           * t :16:32
           * T :16:32:32
           * u :2000-08-17 23:32:32Z
           * U :Thursday, August 17, 2000 23:32:32
           * y :August, 2000
           * dddd, MMMM dd yyyy :Thursday, August 17 2000
           * ddd, MMM d "'"yy :Thu, Aug 17 '00
           * dddd, MMMM dd :Thursday, August 17
           * M/yy :8/00
           * dd-MM-yy :17-08-00
           */
            try
            {
                return dt.ToString(format[formatid], DateTimeFormatInfo.InvariantInfo);
            }
            catch (Exception ex)
            {
                return "00000000";
            }
        }
        private void Function_RetriveDataToXML(string STR_Table)
        {
            int i;
            if (STR_Table == "Company")
                STR_Table = "Facility";
            if (STR_Table == "User")
                STR_Table = "Whuser";
            string STR_TempFileXML = STR_PathExport + STR_Table + ".XML";
            XmlDocument XmlDoc = new XmlDocument();
            DataSet DS = new DataSet();
        
            if (Directory.Exists(STR_PathExport) == false)
            {
                DirectoryInfo DirPathExport = Directory.CreateDirectory(STR_PathExport);
            }
            DataTable DT = new DataTable(STR_TempFileXML);
           
                switch(STR_Table)
                    {
                        case "Asset":
                            {
                                string[] Str_ColumnPO = { "AssetID", "AssetName", "SerialNo", "modelID", "deptID", "buildID", "floorID", "areaID", "ReasonCode", "typeID", "StatusID", "vendorID"
                        , "AssetPrice", "WarrantyStartDate", "WarrantyEndDate","CustodianID","PreviosCustodian","CreatedDate","UserName","UpdateDate","Remark","FacCode" };
                                DS = Manager.Engine.GetDataSet<Asset>("", Str_ColumnPO);
                                break;
                            }
                        case "Building":
                            {
                                DS = Manager.Engine.GetDataSet<Building>("");
                                break;
                            }
                        case "Model":
                            {
                                DS = Manager.Engine.GetDataSet<Model >("");
                                break;
                            }
                        case "Whuser":
                            {
                                DS = Manager.Engine.GetDataSet<Whuser >("");
                                break;
                            }
                        case "Area":
                            {
                                DS = Manager.Engine.GetDataSet<Area>("");
                                break;
                            }
                        case "Floor":
                            {
                                DS = Manager.Engine.GetDataSet<Floor>("");
                                break;
                            }
                        case "Facility":
                            {
                                DS = Manager.Engine.GetDataSet<Facility>("");
                                break;
                            }
                        case "Asset Picture":
                            {
                                ClassAssetPictoFile cls = new ClassAssetPictoFile();
                                cls.Extract_Assetpic(STR_PathExport,ref  Arry_TempFileName );
                                cls = null;
                                DS.Dispose();
                                DS = null;
                                break;
                            }

                    }
                    if (DS != null)
                    {
                        dataGridView_Data.DataSource = DS;
                        dataGridView_Data.DataMember = "Table";
                        for (i = 0; i <= dataGridView_Data.Columns.Count - 1; i++)
                        {
                            DataColumn DataCol = new DataColumn(dataGridView_Data.Columns[i].HeaderText);
                         
                            
                            DT.Columns.Add(DataCol);
                        }
                        for (i = 0; i <= dataGridView_Data.Rows.Count - 2; i++)
                        {
                            DataRow DataRow = DT.NewRow();
                            DT.Rows.Add(DataRow);
                            for (int y = 0; y <= DT.Columns.Count - 1; y++)
                            {
                                if ((dataGridView_Data.Rows[i].Cells[y].Value == System.DBNull.Value) || (dataGridView_Data.Rows[i].Cells[y].Value.ToString() == "null"))
                                {
                                    DT.Rows[i][y] = "";
                                }
                                else
                                {
                                    if (dataGridView_Data.Rows[i].Cells[y].ValueType.Name.ToString() == "DateTime")
                                    {
                                        DateTime dt = new DateTime();
                                        dt = (DateTime)dataGridView_Data.Rows[i].Cells[y].Value;
                                        //Edit on 10-02-09
                                        //DT.Rows[i][y] = dt.ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
                                        DT.Rows[i][y] = dt.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                                    }
                                    else if (dataGridView_Data.Rows[i].Cells[y].ValueType.Name.ToString() == "Boolean")
                                    {
                                        if (dataGridView_Data.Rows[i].Cells[y].Value.ToString() == "True")
                                            DT.Rows[i][y] = 1;
                                        else
                                            DT.Rows[i][y] = 0;
                                    
                                    }
                                    else
                                        DT.Rows[i][y] = dataGridView_Data.Rows[i].Cells[y].Value;
                                }
                            }
                        }
                        DataSet DSnew = new DataSet();

                        DSnew.Tables.Add(DT);
                        DSnew.DataSetName = STR_TempFileXML;
                        DSnew.Namespace = "http://www.simat.co.th";
                        DSnew.Prefix = "Datarows";

                        if (System.IO.File.Exists(STR_TempFileXML))
                        {
                            if (System.IO.File.Exists(STR_PathExport + Table + "._BK"))
                                System.IO.File.Delete(STR_PathExport + Table + "._BK");
                            System.IO.File.Copy(STR_TempFileXML, STR_PathExport + Table + "._BK");
                        }
                        DSnew.WriteXml(STR_TempFileXML);

                        //SS_MyMessageBox.ShowBox("Export File Complete", "Information", DialogMode.OkOnly);
                        DSnew.Dispose();
                        DS.Dispose();
                    }
        }

        private void Function_ReadXMLtoDatabase(string Table)
        {
            try
            {
                string STR_TempXml = STR_PathDowloadFromHH + Table + ".XML";
                XmlDocument Doc = new XmlDocument();
                DataSet ds = new DataSet();
                string[] STR_FieldName = null;
                string[] STR_FiledValue = null;
                
                progressBar1.Value = 0;
                listView_Complete.Items.Clear();
                listView_Error.Items.Clear();

                progressBar1.Maximum = Arry_TempFileName.Count;
                Bool_CheckComplete = false;

                if (Directory.Exists(STR_PathDowloadFromHH) == false)
                {
                    SS_MyMessageBox.ShowBox("Path not found", "Error", DialogMode.Error_Cancel, this.Name, "000006", Global.Lang.Str_Language);
                }
                else
                {
                    if (File.Exists(STR_TempXml) == false)
                    {
                        SS_MyMessageBox.ShowBox("File not found ", "Error", DialogMode.Error_Cancel, this.Name, "000007", Global.Lang.Str_Language);
                    }

                    else
                    {
                        ds.ReadXml(STR_TempXml);

                        int Int_ColCount = ds.Tables[0].Columns.Count;
                        STR_FieldName = new string[Int_ColCount];
                        for (int i = 0; i <= Int_ColCount - 1; i++)
                        {
                            STR_FieldName.SetValue(ds.Tables[0].Columns[i].ColumnName, i);
                        }
                        STR_FiledValue = new string[Int_ColCount];

                        for (int y = 0; y < ds.Tables[0].Rows.Count - 1; y++)
                        {
                            for (int c = 0; c <= STR_FieldName.Length - 1; c++)
                            {   
                               STR_FiledValue.SetValue("", c);
                            }
                        }
                        switch (Table)
                        {

                            case "Asset":
                                {
                                    // Edit on 08-0-09
                                    // if Asset_check table has old data,delete it
                                    string sql = "SELECT * FROM Asset_Checkstock";
                                    DataSet ds_sql = Manager.Engine.GetDataSet(sql);
                                    if (ds_sql.Tables[0].Rows.Count > 0)
                                    {
                                        Function_Delete();

                                    }
                                    ////////////////////////////////
                                    AssetCheckstock AssetCheckStockObj = new AssetCheckstock();
                                    try
                                    {
                                        for (int r = 0; r <= ds.Tables[0].Rows.Count - 1; r++)
                                        {
                                            ///////// Edit on 25-02-09 for CEVA ///////////////////
                                            AssetCheckStockObj.AssetID = ds.Tables[0].Rows[r][0].ToString().Trim();
                                            AssetCheckStockObj.AssetName = "";
                                            if (ds.Tables[0].Rows[r][2].ToString() == "")
                                                AssetCheckStockObj.ModelID = "No Model";
                                            else
                                                AssetCheckStockObj.ModelID = ds.Tables[0].Rows[r][2].ToString();
                                           // AssetCheckStockObj.DeptID = ds.Tables[0].Rows[r][4].ToString();
                                            AssetCheckStockObj.BuildID = ds.Tables[0].Rows[r][3].ToString();
                                            AssetCheckStockObj.FloorID = ds.Tables[0].Rows[r][4].ToString();
                                            AssetCheckStockObj.AreaID = ds.Tables[0].Rows[r][5].ToString();

                                            if (ds.Tables[0].Rows[r][1].ToString() == "")
                                                AssetCheckStockObj.SerialNo = "No Serial";
                                            else
                                                AssetCheckStockObj.SerialNo = ds.Tables[0].Rows[r][1].ToString();

                                            AssetCheckStockObj.Remark = "";
                                            AssetCheckStockObj.TypeID = "SCAN";
                                            AssetCheckStockObj.StatusID = "NEW";
                                            AssetCheckStockObj.UserName = ds.Tables[0].Rows[r][9].ToString();
                                            //AssetCheckStockObj.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[r][17].ToString());
                                            // Edit on 20-02-09
                                            ///////////////////////////////////
                                            AssetCheckStockObj.CreatedDate = DateTime.Parse(Convert.ToDateTime(ds.Tables[0].Rows[r][8].ToString()).ToString("dd/MM/yyyy HH:mm:ss tt"));
                                            //////////////////////////////////////
                                            AssetCheckStockObj.FacCode = ds.Tables[0].Rows[r][11].ToString();
                                            AssetCheckStockHome AssetcheckStockHomeObj = new AssetCheckStockHome();
                                            AssetcheckStockHomeObj.AssetCheckStockObj = AssetCheckStockObj;


                                            if (AssetcheckStockHomeObj.Add())
                                            {
                                                if (r == ds.Tables[0].Rows.Count - 1)
                                                {
                                                    Bool_CheckComplete = true;
                                                    Function_ShowListImportInListview();

                                                }
                                            }
                                            else
                                            {
                                                SS_MyMessageBox.ShowBox("Can't Insert Data to Database ", "Error", DialogMode.Error_Cancel, this.Name, "000008", Global.Lang.Str_Language);
                                            }

                                            //////////// Old Version (Before 25-02-09 for CEVA)  //////////////////////
                                            //AssetCheckStockObj.AssetID = ds.Tables[0].Rows[r][0].ToString().Trim();
                                            //AssetCheckStockObj.AssetName = ds.Tables[0].Rows[r][1].ToString();
                                            //if (ds.Tables[0].Rows[r][3].ToString() == "")
                                            //    AssetCheckStockObj.ModelID = "No Model";
                                            //else
                                            //AssetCheckStockObj.ModelID = ds.Tables[0].Rows[r][3].ToString();
                                            //AssetCheckStockObj.DeptID = ds.Tables[0].Rows[r][4].ToString();
                                            //AssetCheckStockObj.BuildID = ds.Tables[0].Rows[r][5].ToString();
                                            //AssetCheckStockObj.FloorID = ds.Tables[0].Rows[r][6].ToString();
                                            //AssetCheckStockObj.AreaID = ds.Tables[0].Rows[r][7].ToString();

                                            //if (ds.Tables[0].Rows[r][2].ToString() == "")
                                            //    AssetCheckStockObj.SerialNo = "No Serial";
                                            //else
                                            //    AssetCheckStockObj.SerialNo = ds.Tables[0].Rows[r][2].ToString();
                                            
                                            //AssetCheckStockObj.Remark = "";
                                            //AssetCheckStockObj.TypeID = "SCAN";
                                            //AssetCheckStockObj.StatusID = "NEW";
                                            //AssetCheckStockObj.UserName = ds.Tables[0].Rows[r][18].ToString();
                                            ////AssetCheckStockObj.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[r][17].ToString());
                                            //// Edit on 20-02-09
                                            /////////////////////////////////////
                                            //AssetCheckStockObj.CreatedDate = DateTime.Parse(Convert.ToDateTime(ds.Tables[0].Rows[r][17].ToString()).ToString("dd/MM/yyyy HH:mm:ss tt"));
                                            ////////////////////////////////////////
                                            //AssetCheckStockObj.FacCode = ds.Tables[0].Rows[r][21].ToString();
                                            //AssetCheckStockHome AssetcheckStockHomeObj = new AssetCheckStockHome();
                                            //AssetcheckStockHomeObj.AssetCheckStockObj = AssetCheckStockObj;

                                           
                                            //if (AssetcheckStockHomeObj.Add())
                                            //{
                                            //    if (r == ds.Tables[0].Rows.Count - 1)
                                            //    {
                                            //        Bool_CheckComplete = true;
                                            //        Function_ShowListImportInListview();
                                                   
                                            //    }
                                            //}
                                            //else
                                            //{
                                            //    SS_MyMessageBox.ShowBox("Can't Insert Data to Database ", "Error", DialogMode.Error_Cancel, this.Name, "000008", Global.Lang.Str_Language);
                                            //}

                                        }
                                    }
                                    catch(Exception ee)
                                    {
                                        SS_MyMessageBox.ShowBox("There is problems at reading Asset.xml file. \r\n"+ee.Message);
                                    }


                                    break;
                                }
                            case "CheckStock":
                                {
                                    DataSet Ds = new DataSet();
                                    Ds = Manager.Engine.GetDataSet<CheckStock>("");
                                    if (Ds.Tables[0].Rows.Count > 0)
                                    {
                                        SS_MyMessageBox.ShowBox("Please clear old data first", "Error", DialogMode.Error_Cancel);
                                        break;
                                    }
                                    CheckStock CheckStockObj = new CheckStock();
                                    try
                                    {
                                        for (int r = 0; r <= ds.Tables[0].Rows.Count - 1; r++)
                                        {
                                            CheckStockObj.AssetID = ds.Tables[0].Rows[r][0].ToString();
                                            CheckStockObj.ModelID = ds.Tables[0].Rows[r][1].ToString();

                                            if (ds.Tables[0].Rows[r][1].ToString() == "")
                                                CheckStockObj.ModelID = "No Model";
                                            else
                                                CheckStockObj.ModelID = ds.Tables[0].Rows[r][1].ToString();

                                            CheckStockObj.BuildID = ds.Tables[0].Rows[r][2].ToString();
                                            CheckStockObj.FloorID = ds.Tables[0].Rows[r][3].ToString();

                                            CheckStockObj.AreaID = ds.Tables[0].Rows[r][4].ToString();
                                            Function_ChkDataInMaster("Area", CheckStockObj);

                                            CheckStockObj.SerialNo = ds.Tables[0].Rows[r][5].ToString();
                                            if (ds.Tables[0].Rows[r][5].ToString() == "")
                                                CheckStockObj.SerialNo = "No Serial";
                                            else
                                                CheckStockObj.SerialNo = ds.Tables[0].Rows[r][5].ToString();

                                            CheckStockObj.Type = ds.Tables[0].Rows[r][7].ToString();
                                            Function_ChkDataInMaster("Type", CheckStockObj);

                                            CheckStockObj.UserName = ds.Tables[0].Rows[r][8].ToString();
                                            CheckStockObj.CreatedDate = DateTime.Parse(ds.Tables[0].Rows[r][9].ToString());
                                            CheckStockObj.Remark = ds.Tables[0].Rows[r][6].ToString();

                                            if (ds.Tables[0].Rows[r][6].ToString() == "")
                                                CheckStockObj.Remark = "No Remark";
                                            else
                                                CheckStockObj.Remark = ds.Tables[0].Rows[r][6].ToString();


                                            CheckStockObj.FacCode = ds.Tables[0].Rows[r][10].ToString();
                                            CheckStockHome checkStockHomeObj = new CheckStockHome();
                                            checkStockHomeObj.CheckStockObj = CheckStockObj;

                                            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                            if (checkStockHomeObj.Add())
                                            {
                                                if (r == ds.Tables[0].Rows.Count - 1)
                                                {
                                                    ORTransaction.Commit();
                                                    Bool_CheckComplete = true;
                                                    Function_ShowListImportInListview();
                                                    //SS_MyMessageBox.ShowBox("Add data complete", "Information", DialogMode.OkOnly);
                                                }
                                            }
                                            else
                                            {
                                                SS_MyMessageBox.ShowBox("Can't insert data to database ", "Error", DialogMode.Error_Cancel, this.Name, "000008", Global.Lang.Str_Language);
                                            }

                                        }
                                    }
                                    catch(Exception ee)
                                    {
                                        SS_MyMessageBox.ShowBox("There is problems at reading CheckStock.xml File \r\n" + ee.Message);
                                    }
                                    break;
                                }
                            }
                      
                         }
                      }
            }
            catch(Exception Err)
            {
               // SS_MyMessageBox.ShowBox("Can't read file.\r\n" + Err.Message, "Error", DialogMode.Error_Cancel, this.Name, "000009", Global.Lang.Str_Language);
                SS_MyMessageBox.ShowBox("Can't read file.\r\n" + Err.Message, "Error");
            }
           
        }
        private void Function_ShowListImportInListview()
        {

            // เมื่อมีการ import ลง table เสร็จสิ้นไม่ว่าจะเป็น table ใดก็ตาม ให้แสดงรายการไฟล์ที่ complete และ error

            for (int i = 0; i < Arry_TempFileName.Count; i++)
            {
                string status = "";
                string Str_FileImports = Arry_TempFileName[i].ToString();
                FileInfo fi = new FileInfo(STR_PathDowloadFromHH + Str_FileImports);

                if (Bool_CheckComplete)
                {
                    Application.DoEvents();
                    string ConvertAsFileName = ConvertFile(STR_PathDowloadFromHH + Str_FileImports, fi.Name);
                    System.Threading.Thread.Sleep(1000);


                    status = "Complete...";
                    AddtoListView("ADD", listView_Complete, fi.Name, fi.Length.ToString("0 KB"), status + RapiErr);
                    if (File.Exists(Application.StartupPath + "\\" + ConvertAsFileName))
                        File.Delete(Application.StartupPath + "\\" + ConvertAsFileName);
                    progressBar1.Value = progressBar1.Value + 1;
                    lbl_ShowStatus.Text = "Total Copy File : " + listView_Complete.Items.Count.ToString();

                }
                else
                {

                    status = "Not Complete...";
                    AddtoListView("ADD", listView_Error, fi.Name, fi.Length.ToString("0 KB"), status + RapiErr);
                    LBL_TotalError.Text = "Total Errors File: " + listView_Error.Items.Count.ToString();
                }
                if (listView_Error.Items.Count == 0)
                    LBL_TotalError.Text = "Total Errors File: " + listView_Error.Items.Count.ToString();
            }
            // จบการแสดงรายการใน listview
        }

        private string Function_TypeName(string STR_TypeID)
        {
            String STR_TempName="";
            switch (STR_TypeID)
            {
                case "I":
                    STR_TempName = "Invalid area";
                    break;
                case"C":
                    STR_TempName = "Complete area";
                    break;
                case"A":
                    STR_TempName = "Already Scan(Repeat Scan)";
                    break;
             }
             return STR_TempName;           
        }

        /// <summary>
        /// Check field In Table CheckStock not allow null and insert data in that field
        /// When import checkstock from handheld 
        /// </summary>
        /// <param name="STR_Table"></param>
        /// <param name="CheckStockObj"></param>
        private void Function_ChkDataInMaster(string STR_Table,CheckStock CheckStockObj)
        {
            switch (STR_Table)
            {
                case "Area":
                    ObjectSet ObjSet_Area = Manager.Engine.GetObjectSet(typeof(Area), String.Empty);
                    Area AreaObj = (Area)ObjSet_Area.GetObject(CheckStockObj.AreaID);
                    if(AreaObj ==null)
                    {
                        AreaObj = new Area();
                        AreaObj.ID = CheckStockObj.AreaID;
                        AreaObj.Name = AreaObj.ID;
                        AreaObj.FloorID = CheckStockObj.FloorID;
                        AreaObj.FacCode = AreaObj.ID;
                        AreaHome AreaHomeObj = new AreaHome();
                        AreaHomeObj.Areaobj = AreaObj;
                        AreaHomeObj.Add();
                        CheckStockObj.AreaID = AreaObj.ID;
                    }
                    break;
                case "Type":
                    ObjectSet ObjSet_Type = Manager.Engine.GetObjectSet(typeof(SimatSoft.DB.ORM.Type), String.Empty);
                    SimatSoft.DB.ORM.Type TypeObj = (SimatSoft.DB.ORM.Type)ObjSet_Type.GetObject(CheckStockObj.Type);
                    if(TypeObj==null)
                    {
                        TypeObj = new SimatSoft.DB.ORM.Type();
                        TypeObj.ID = CheckStockObj.Type;
                        TypeObj.Name = Function_TypeName(TypeObj.ID);
                        TypeObj.Remark = TypeObj.Remark;
                        SimatSoft.DB.ORM.TypeHome TypeHomeObj = new TypeHome();
                        TypeHomeObj.Typeobj = TypeObj;
                        TypeHomeObj.Add();
                        CheckStockObj.Type = TypeObj.ID;
                    }
                    break;
                           
            }
        }



     private void Form_001007_Upload_Download_HH_Enter(object sender, EventArgs e)
        {
            CheckState1();
            Global.STR_FormID = ind.ToString();
            Global.STR_State = Global.IndexArray.Get(int.Parse(ind.ToString())).ToString();
        }

        void CheckState1()
        {//-1=cancel,-2=temp,0=Import,
            int state = Global.IndexArray.Get(int.Parse(ind.ToString()));
            if (state == 0)
                Global.Function_ToolStripSetUP(Enum_Mode.Import);
            else
            {
                Global.Function_ToolStripSetUP(Enum_Mode.Export);
            }
        }

        private void Form_001007_Upload_Download_HH_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            LBL_UploadSelected.Text = "Table seleted: CheckStock";
            if (File.Exists(Application.StartupPath + "\\Config.ini"))
                loadConfig();
            if (File.Exists(Application.StartupPath + "\\ConfigImport.ini"))
                loadConfigImport();
            Conn();
           
            AssemblyInfo ainfo = new AssemblyInfo();            
        }

        void loadConfig()
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "\\Config.ini");
            //string ss = sr.ReadLine();
            iniConfig[0] = sr.ReadLine().Replace("\\", @"\") ;
            sr.Close();
            sr.Dispose();
        }

        void loadConfigImport()
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "\\ConfigImport.ini");
            //string ss = sr.ReadLine();
            iniConfigImport[0] = sr.ReadLine().Replace("\\", @"\");
            sr.Close();
            sr.Dispose();
        }


        bool CopyFileFromDevice()
        {
           
            if (m_rapi.Connected)
            {
                //M_Rapi.CopyFileFromDevice(TextBoxSourcefilename.Text + strDate + "STOCK.CSV", TextBoxDesFilename.Text, true);
                if (Directory.Exists(STR_PathDowloadFromHH) == false)
                {
                    DirectoryInfo DirPathImport = Directory.CreateDirectory(STR_PathDowloadFromHH);
                }
                m_rapi.CopyFileFromDevice(STR_PathDowloadFromHH + Table + ".XML", iniConfig[0] + @"\" + Table + ".XML", true);
                return true;
            }
            else
                return false;
        }

        void CopyFileToDevice()
        {

                if (m_rapi.Connected)
                {
                    progressBar1.Value = 0;
                    listView_Complete.Items.Clear();
                    listView_Error.Items.Clear();

                    progressBar1.Maximum = Arry_TempFileName.Count;

                    for (int i = 0; i < Arry_TempFileName.Count; i++)
                    {
                        Application.DoEvents();
                        // Edit for CEVA copy DBCE.sdf to Device on 12-02-09
                      //  string fileExport = Arry_TempFileName[i].ToString();
                        string fileExport = "DBCE.sdf";
                        FileInfo fi = new FileInfo(STR_PathExport + fileExport);
                        string ConvertAsFileName ;
                        string Despath;
                        Despath = iniConfigImport[0].ToString();
                        // Edit for CEVA copy DBCE.sdf to Device on 12-02-09
                       // fileExport = fileExport.ToUpper();  
                        if (fileExport.LastIndexOf("XML") >= 0)
                            ConvertAsFileName = ConvertFile(STR_PathExport + fileExport, fi.Name);
                        else
                        {
                            // Edit for CEVA copy DBCE.sdf to Device on 12-02-09

                            //ConvertAsFileName = STR_PathExport + fileExport;
                            //Despath = Despath + "\\AssetPic";

                            ConvertAsFileName = STR_PathExport + fileExport;
                            Despath = "\\Storage Card\\SimatSoft\\FixedAsset\\Database";
                        }
                        System.Threading.Thread.Sleep(1000);
                        string status = "";

                        // Edit for CEVA copy DBCE.sdf to Device on 12-02-09
                        // if (Copy_NextFile(ConvertAsFileName, @"" +Despath  + "\\" + fi.Name))
                        if (Copy_NextFile(ConvertAsFileName, @"" + Despath + "\\" + fileExport))
                        {
                            status = "Complete...";
                            // Edit for CEVA copy DBCE.sdf to Device on 12-02-09
                           // AddtoListView("ADD", listView_Complete, fi.Name, fi.Length.ToString("0 KB"), status + RapiErr);
                            AddtoListView("ADD", listView_Complete, Arry_TempFileName[i].ToString().Replace(".XML",""), fi.Length.ToString("0 KB"), status + RapiErr);
                            if (File.Exists(Application.StartupPath + "\\" + ConvertAsFileName))
                                File.Delete(Application.StartupPath + "\\" + ConvertAsFileName);
                            progressBar1.Value = progressBar1.Value + 1;
                            lbl_ShowStatus.Text = "Total Copy File : " + listView_Complete.Items.Count.ToString();
                        }
                        else
                        {
                            status = "Not Complete...";
                            AddtoListView("ADD", listView_Error, fi.Name, fi.Length.ToString("0 KB"), status + RapiErr);
                            LBL_TotalError.Text = "Total Errors File: " + listView_Error.Items.Count.ToString();
                        }
                        if(listView_Error.Items.Count ==0)
                            LBL_TotalError.Text = "Total Errors File: " + listView_Error.Items.Count.ToString();


                    }
                    
                    // Copy file pic
                    //ClassAssetPictoFile cls = new ClassAssetPictoFile();
                    //cls.SendData(m_rapi, @"" + iniConfigImport[0].ToString() );
                    //cls = null;
                    //m_rapi.CopyFileToDevice(STR_PathExport + Table + ".XML", iniConfigImport[0] + @"\" + Table + ".XML", true);
                    //SS_MyMessageBox.ShowBox("Copy file " + Table + ".XML" + " to device complete", "Information", DialogMode.OkOnly);
                    
                }
               
                   
           
        }
        
        string ConvertFile(string filePCPath, string Filename)
        {
            string theString = "";
            StreamReader reader = new System.IO.StreamReader(filePCPath, System.Text.Encoding.UTF8  );
            try
            {
                theString = reader.ReadToEnd();
            }
            finally
            {
                reader.Close();
            }
            string AsFileName = DateTime.Now.Year.ToString("0000") + DateTime.Now.Month.ToString("00") + DateTime.Now.Day.ToString("00") + Filename;
            StreamWriter writer = new System.IO.StreamWriter(Application.StartupPath + "\\" + AsFileName, false, System.Text.Encoding.Unicode);
            try
            {
                writer.WriteLine(theString);
            }
            finally
            {
                writer.Close();
            }
            return AsFileName;
        }

        void AddtoListView(string mode, ListView lstv, string Filename, string FileSize, string FileStatus)
        {
            if (mode.ToUpper() == "ADD")
            {
                //check Duplicate Filename
                for (int i = 0; i < lstv.Items.Count; i++)
                {
                    if (lstv.Items[i].SubItems[1].Text.Trim().ToUpper() == Filename.ToUpper().Trim())
                    {
                        // Edit for CEVA on 12-02-09 , Don't show MSG Box , if there is Duplicate Filename
                        //MessageBox.Show("Already File Name :\r\n" + Filename);
                        //return;
                    }
                }
                string id = Convert.ToString(lstv.Items.Count + 1);
                ListViewItem item = new ListViewItem(id.ToString());
                ListViewItem.ListViewSubItem sub1 = new ListViewItem.ListViewSubItem(item, id);
                ListViewItem.ListViewSubItem sub2 = new ListViewItem.ListViewSubItem(item, id);
                ListViewItem.ListViewSubItem sub3 = new ListViewItem.ListViewSubItem(item, id);
                sub1.Text = Filename;
                sub2.Text = FileSize;
                sub3.Text = FileStatus;
                item.SubItems.Add(sub1);
                item.SubItems.Add(sub2);
                item.SubItems.Add(sub3);
                lstv.Items.Add(item);
            }
            else if (mode.ToUpper() == "READD")
            {
                for (int i = 0; i < lstv.Items.Count; i++)
                {
                    string no = Convert.ToString(i + 1);
                    lstv.Items[i].SubItems[0].Text = no;
                }
            }
            if (listView_Complete.Items.Count <= 0)
            {
                progressBar1.Value = 0;
                lbl_ShowStatus.Text = "...";
            }
        }

        bool Copy_NextFile(string pcP, string hhP)
        {
            try
            {
                //////////// Edit on 12-02-09 for CEVA
                if (m_rapi.DeviceFileExists(hhP))
                {
                    m_rapi.DeleteDeviceFile(hhP);
                }
                ////////
               m_rapi.CopyFileToDevice(pcP, hhP, true);
                return true;
            }
            catch (RAPIException err)
            {
                RapiErr = err.Message;
                return false;
            }
        }

        private void checkBox_UploadAsset_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void picBoxSync_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxAssetpic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form_001007_Upload_Download_HH_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            //AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void checkBoxAssetpic_CheckStateChanged(object sender, EventArgs e)
        {
            Table = "";
            CheckBox TempCheckBox = (CheckBox)sender;
            if (TempCheckBox.CheckState == CheckState.Checked)
            {

                if (groupBox_Download.Controls.Contains(TempCheckBox))
                {
                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        if (checkTemp != TempCheckBox)
                        {
                            checkTemp.Checked = false;

                        }
                    }
                    foreach (CheckBox checkTemp in groupBox_Upload.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 0);
                    Global.Function_ToolStripSetUP(Enum_Mode.Import);

                }
                else if (groupBox_Upload.Controls.Contains(TempCheckBox))
                {

                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 1);
                    Global.Function_ToolStripSetUP(Enum_Mode.Export);

                }
                this.Table = TempCheckBox.Text;
                this.LBL_UploadSelected.Text = string.Format(" Table selected : {0}", this.Table);

            }
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            Table = "";
            CheckBox TempCheckBox = (CheckBox)sender;
            if (TempCheckBox.CheckState == CheckState.Checked)
            {

                if (groupBox_Download.Controls.Contains(TempCheckBox))
                {
                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        if (checkTemp != TempCheckBox)
                        {
                            checkTemp.Checked = false;

                        }
                    }
                    foreach (CheckBox checkTemp in groupBox_Upload.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 0);
                    Global.Function_ToolStripSetUP(Enum_Mode.Import);

                }
                else if (groupBox_Upload.Controls.Contains(TempCheckBox))
                {

                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 1);
                    Global.Function_ToolStripSetUP(Enum_Mode.Export);

                }
                this.Table = TempCheckBox.Text;
                this.LBL_UploadSelected.Text = string.Format(" Table selected : {0}", this.Table);

            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            Table = "";
            CheckBox TempCheckBox = (CheckBox)sender;
            if (TempCheckBox.CheckState == CheckState.Checked)
            {

                if (groupBox_Download.Controls.Contains(TempCheckBox))
                {
                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        if (checkTemp != TempCheckBox)
                        {
                            checkTemp.Checked = false;

                        }
                    }
                    foreach (CheckBox checkTemp in groupBox_Upload.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 0);
                    Global.Function_ToolStripSetUP(Enum_Mode.Import);

                }
                else if (groupBox_Upload.Controls.Contains(TempCheckBox))
                {

                    foreach (CheckBox checkTemp in groupBox_Download.Controls)
                    {
                        checkTemp.Checked = false;

                    }

                    Global.IndexArray.Edit(int.Parse(ind.ToString()), 1);
                    Global.Function_ToolStripSetUP(Enum_Mode.Export);

                }
                this.Table = TempCheckBox.Text;
                this.LBL_UploadSelected.Text = string.Format(" Table selected : {0}", this.Table);

            }

        }
        private void Function_Delete()
        {
            string sql = "DELETE Asset_Checkstock  ";
            Manager.Engine.ExecuteCommand(sql);

        }
    }
 }