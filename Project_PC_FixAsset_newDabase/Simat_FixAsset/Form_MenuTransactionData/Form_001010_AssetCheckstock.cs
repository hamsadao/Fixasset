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
namespace SimatSoft.FixAsset
{

    public partial class Form_001010_AssetCheckStock : Form
    {
        private string currentNo = "";

        private Enum_Mode Enm_StateForm = Enum_Mode.SetDefault;
        private SimatSoft.CustomControl.SS_DataGridView sS_DataGridView_HistoryAsset;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel_Record;
        private Button CmdAdd;
        private Button button1;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_001010_AssetCheckStock()
        {
            InitializeComponent();
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.SetDefault);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001010(AssetCheckStock)");
        }


        private void Function_ShowData() 
        {

            string sql = "SELECT AssetID, AssetName, SerialNo, modelID, deptID,buildID, floorID," +
                " areaID, ReasonCode,FacCode FROM Asset_CheckStock WHERE AssetID NOT IN (Select AssetID FROM Asset)";
            DataSet ds = new DataSet();
            ds = Manager.Engine.GetDataSet(sql);
            sS_DataGridView_HistoryAsset.DataSource = ds;
            sS_DataGridView_HistoryAsset.DataMember = "Table";

        }





        private void InitializeComponent()
        {
            this.sS_DataGridView_HistoryAsset = new SimatSoft.CustomControl.SS_DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_Record = new System.Windows.Forms.ToolStripStatusLabel();
            this.CmdAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_HistoryAsset)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sS_DataGridView_HistoryAsset
            // 
            this.sS_DataGridView_HistoryAsset.AllowUserToAddRows = false;
            this.sS_DataGridView_HistoryAsset.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sS_DataGridView_HistoryAsset.BackColorCellFocus = System.Drawing.Color.LightBlue;
            this.sS_DataGridView_HistoryAsset.BackColorCellLeave = System.Drawing.Color.Honeydew;
            this.sS_DataGridView_HistoryAsset.BackColorRow = System.Drawing.Color.HotPink;
            this.sS_DataGridView_HistoryAsset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sS_DataGridView_HistoryAsset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sS_DataGridView_HistoryAsset.Location = new System.Drawing.Point(0, 35);
            this.sS_DataGridView_HistoryAsset.Name = "sS_DataGridView_HistoryAsset";
            this.sS_DataGridView_HistoryAsset.Size = new System.Drawing.Size(952, 350);
            this.sS_DataGridView_HistoryAsset.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Record});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(952, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_Record
            // 
            this.toolStripStatusLabel_Record.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel_Record.Name = "toolStripStatusLabel_Record";
            this.toolStripStatusLabel_Record.Size = new System.Drawing.Size(79, 17);
            this.toolStripStatusLabel_Record.Text = "[1/All] records";
            // 
            // CmdAdd
            // 
            this.CmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.CmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAdd.Location = new System.Drawing.Point(4, 6);
            this.CmdAdd.Name = "CmdAdd";
            this.CmdAdd.Size = new System.Drawing.Size(75, 25);
            this.CmdAdd.TabIndex = 20;
            this.CmdAdd.Text = "Add New ";
            this.CmdAdd.UseVisualStyleBackColor = false;
            this.CmdAdd.Click += new System.EventHandler(this.CmdAdd_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(82, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 21;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_001010_AssetCheckStock
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.ClientSize = new System.Drawing.Size(952, 410);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CmdAdd);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.sS_DataGridView_HistoryAsset);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_001010_AssetCheckStock";
            this.Text = "ID:001010(AssetCheckStock)";
            this.Load += new System.EventHandler(this.Form_001010_AssetCheckStockt_Load);
            this.ResizeEnd += new System.EventHandler(this.Form_001010_AssetCheckStock_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.sS_DataGridView_HistoryAsset)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form_001010_AssetCheckStockt_Load(object sender, EventArgs e)
        {
            Function_ShowData();
        }

        private void CmdAdd_Click(object sender, EventArgs e)
        {
            int int_flag = 0;
            for (int i = 0; i <= this.sS_DataGridView_HistoryAsset.Rows.Count - 1; i++)
            {
                AssetHome AssetHomeObj = new AssetHome();
                ///////// Edit to atomatical generate New AssetID for new asset (04-01-09) ////////
                //AssetHomeObj.Assetobj.ID = sS_DataGridView_HistoryAsset[0,i].Value.ToString();
                AssetHomeObj.Assetobj.ID = Function_GetNextRunningNo();  // Get next assetID
                ///////////////////////////
                AssetHomeObj.Assetobj.Name = sS_DataGridView_HistoryAsset[1,i].Value.ToString();
                AssetHomeObj.Assetobj.SerialNo = sS_DataGridView_HistoryAsset[2,i].Value.ToString();
                AssetHomeObj.Assetobj.ModelID = sS_DataGridView_HistoryAsset[3,i].Value.ToString();
                AssetHomeObj.Assetobj.TypeID = "SCAN";

                Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);

                AssetHomeObj.Assetobj.VendorID = "";
                AssetHomeObj.Assetobj.DeptID = sS_DataGridView_HistoryAsset[4, i].Value.ToString(); 
                AssetHomeObj.Assetobj.BuildID = sS_DataGridView_HistoryAsset[5, i].Value.ToString();
                AssetHomeObj.Assetobj.FloorID = sS_DataGridView_HistoryAsset[6, i].Value.ToString();
                AssetHomeObj.Assetobj.AreaID = sS_DataGridView_HistoryAsset[7, i].Value.ToString();

                Class_CheckMaster.Function_CheckData.TB_Asset("Area", AssetHomeObj);

                AssetHomeObj.Assetobj.Remark = "";
                AssetHomeObj.Assetobj.ReasonCode = "";
                AssetHomeObj.Assetobj.CustodianID = "";
                AssetHomeObj.Assetobj.PreviosCustodian = "";
                AssetHomeObj.Assetobj.Price = 0;
                AssetHomeObj.Assetobj.StatusID = "NEW";

                Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                AssetHomeObj.Assetobj.CreatedDate = DateTime.Now.Date;
                AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                AssetHomeObj.Assetobj.WarrantyStartDate = DateTime.Now.Date;
                AssetHomeObj.Assetobj.WarrantyEndDate = DateTime.Now.Date;
                AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                AssetHomeObj.Assetobj.FacCode = sS_DataGridView_HistoryAsset[8, i].Value.ToString();
                ///////// Additional for CEVA on 02-03-09////////
                AssetHomeObj.Assetobj.Customfiled4 = DateTime.Now.Date;
                AssetHomeObj.Assetobj.Customfiled10 = DateTime.Now.Date;
                AssetHomeObj.Assetobj.Customfiled11 = DateTime.Now.Date.ToShortDateString();
                ////////////////////////////////////

                Asset AssetObj = new Asset();
                AssetObj = Manager.Engine.GetObject<Asset>(sS_DataGridView_HistoryAsset[1, i].Value.ToString());

                if (AssetObj != null)
                {
                    int_flag = int_flag + 1;
                    //SS_MyMessageBox.ShowBox("AssetNo : " + sS_DataGridView_HistoryAsset[1, i].Value.ToString() + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010","" , Global.Lang.Str_Language);
                    //Global.Bool_CheckComplete = false;
                }

                if (AssetHomeObj.Add())
                {
                    Function_SaveCurrentRunningNo(currentNo);
                    int_flag = int_flag;
                    //SS_MyMessageBox.ShowBox("Add data : " + sS_DataGridView_HistoryAsset[1, i].Value.ToString() + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001","" , Global.Lang.Str_Language);
                    //Global.Bool_CheckComplete = true;

                }
                else
                {
                    int_flag = int_flag + 100;
                    //SS_MyMessageBox.ShowBox("Can not add data: " + sS_DataGridView_HistoryAsset[1, i].Value.ToString() + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", "", Global.Lang.Str_Language);
                    //Global.Bool_CheckComplete = false;
                }
            }

            if (int_flag == 0)
            {
                
                SS_MyMessageBox.ShowBox("Add data  Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001","" , Global.Lang.Str_Language);
                //Function_Delete();
            }
            else if (int_flag > 100)
            {
                SS_MyMessageBox.ShowBox("Can not add data !", "Warning", DialogMode.OkOnly, this.Name, "000002", "", Global.Lang.Str_Language);
            }
            else
            {
                SS_MyMessageBox.ShowBox("Asset is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", "", Global.Lang.Str_Language);
            }
        }

        private void Function_Delete()
        {
            AssetCheckStockHome AssetCheckStockHomeObj = new AssetCheckStockHome();
            List<AssetCheckstock> AssetCollection = new List<AssetCheckstock>();
            AssetCheckstock TempAssetCheckstock = new AssetCheckstock();

            foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_HistoryAsset.Rows)
            {
                TempAssetCheckstock = Manager.Engine.GetObject<AssetCheckstock>(TempDataGridRow.Cells[0].Value.ToString());

                AssetCollection.Add(TempAssetCheckstock);
            }

            Global.Bool_CheckComplete = true;
            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

            if (AssetCheckStockHomeObj.Delete(ORTransaction, AssetCollection))
            {
                ORTransaction.Commit();
                SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000012", Global.Lang.Str_Language);
                Global.Bool_CheckComplete = true;
            }
            else
            {
                SS_MyMessageBox.ShowBox("Can not delete data !", "Warning", DialogMode.OkOnly, this.Name, "000013", Global.Lang.Str_Language);
                Global.Bool_CheckComplete = false;
                ORTransaction.Rollback();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Function_Delete();
        }

        private void Form_001010_AssetCheckStock_ResizeEnd(object sender, EventArgs e)
        {
            sS_DataGridView_HistoryAsset.Width = this.Width;
            sS_DataGridView_HistoryAsset.Height = this.Height;
        }
        private string Function_GetNextRunningNo()
        {
            string nextNo = "";
            try
            {
                string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE RunID = 1"; // Asset
                //string qry = "SELECT Prefix, CurrentRun FROM SysRunNo WHERE (RunID IN ";
                //qry += "(SELECT RunID FROM SysRunNoAssetMapping WHERE (FacCode = '" + Global.ConfigDatabase.Str_Company + "')))";

                DataSet ds = new DataSet();
                ds = Manager.Engine.GetDataSet(qry);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string prefix = ds.Tables[0].Rows[0][0].ToString();
                    int current = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    int lenght = ds.Tables[0].Rows[0][1].ToString().Length;
                    current++;
                    string str_current = current.ToString();
                    string runningid = "";
                    if (lenght > str_current.Length)
                    {
                        for (int i = 0; i < lenght - current.ToString().Length; i++)
                            runningid += "0";
                        runningid += str_current;
                    }
                    currentNo = runningid;
                    nextNo = prefix + runningid;
                }

            }
            catch 
            {
                SS_MyMessageBox.ShowBox("Error@GetNextRunningNo()"); 
            }

            return nextNo;
        }

        private void Function_SaveCurrentRunningNo(string runid)
        {
            try
            {
                string qry = "UPDATE SysRunNo SET CurrentRun = '" + runid +
                             "' WHERE RunId = 1"; // Asset

                Manager.Engine.ExecuteCommand(qry);
            }
            catch 
            {
                SS_MyMessageBox.ShowBox("Error@SaveCurrentRunningNo()"); 
            }

        }

        
    }
}