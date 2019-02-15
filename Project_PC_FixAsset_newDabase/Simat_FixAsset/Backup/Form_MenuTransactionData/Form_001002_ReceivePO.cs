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
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    public partial class Form_001002_ReceivePurchaseOrder : SS_PaintGradientForm
    {
        private string currentNo = "";
        private string Global_AssetNo = "";
        private string prefix = "";
        private string runID = "";
        private string GlobalNo = "";
        public static int row_count = 0;
        public static string TempRunID = "";

        private int Int_CountObjDTs = 0;
        int Int_OldReceiveQtyValue = 0;
        int Int_POSeq = 0;
        string Str_ModelID = "";
        string Str_BuildID = "";
        string Str_FloorID = "";
        string Str_AreaID = "";
        POHome POHomeObj = new POHome();
        AssetHome AssetHomeObj = new AssetHome();
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();

        struct Detail_Receive
        {
            public int Int_POSeq;
            public string Str_ModelID;
            public int Int_Count;
            public System.Collections.ArrayList Arry_POReceive;
        }
        struct Asset_Receive
        {
            public string Str_AssetNo;
            public string Str_AssetName;
            public string Str_ModelID;
            public string Str_SerialNo;
            public string Str_Floor;
            public string Str_Building;
            public string Str_Area;
            public string Str_CustodianID;
            public string Str_Remark;
            public bool Bool_NewStatus;
        }

        System.Collections.Hashtable AssetReceiveList = new System.Collections.Hashtable();
        System.Collections.Hashtable QtyNewReceivePOReceive = new System.Collections.Hashtable();

        // Edit/Add on 06-01-09
        public static int updateRowcount
        {
            get { return row_count; }

            set { row_count = value; }
        }

        // Edit/Add on 06-01-09
        public static string updateTempRunID
        {
            get { return TempRunID; }

            set { TempRunID = value; }
        }

        public Form_001002_ReceivePurchaseOrder()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.ShowData);
            //Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.SaveOnly;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreEdit;
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001002(Receive Purchase Order)");
            LBL_PONo.Text = Global.Function_Language(this, LBL_PONo, " PO No:");
            LBL_SupplierNo.Text = Global.Function_Language(this, LBL_SupplierNo, "Supplier No:");
            LBL_Date.Text = Global.Function_Language(this, LBL_Date, "Date:");
            LBL_DepartmentNo.Text = Global.Function_Language(this, LBL_DepartmentNo, "Department Name:");
            LBL_Type.Text = Global.Function_Language(this, LBL_Type, "Type:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");
            LBL_CompanyNo.Text = Global.Function_Language(this, LBL_CompanyNo, "Company No:");
            LBL_Detail.Text = Global.Function_Language(this, LBL_Detail, "Detail:");
            LBL_AssetDetail.Text = Global.Function_Language(this, LBL_AssetDetail, "Asset Detail:");
        }
        private void Form_001002_ReceivePurchaseOrder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_PO.Text = "";
                sS_MaskedTextBox_SupplierNo.Text = "";
                sS_MaskedTextBox_SupplierName.Text = "";
                sS_ComboBox_Type.SelectedIndex = 0;
                sS_MaskedTextBox_Remark.Text = "";
                sS_MaskedTextBox_Facility.Text = "";
                sS_DataGridView_ReceivePO.Rows.Clear();
                sS_DataGridView_AssetReceive.Rows.Clear();
                Function_SetReadOnlyControl(true);
                AssetReceiveList.Clear();
                QtyNewReceivePOReceive.Clear();
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Clear Data in Control", DialogMode.Error_Cancel, Ex);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_PO.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Facility.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
        }
        private void Function_SetControlEnable(bool Bool_StateControl)
        {
            sS_MaskedTextBox_SupplierNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_Facility.Enabled = Bool_StateControl;
        }
        private void Function_SetReadOnlyColumnDataGrid()
        {
            sS_DataGridView_ReceivePO.ReadOnly = false;
            sS_DataGridView_ReceivePO.Columns[0].ReadOnly = true;
            sS_DataGridView_ReceivePO.Columns[1].ReadOnly = true;
            sS_DataGridView_ReceivePO.Columns[2].ReadOnly = true;
            sS_DataGridView_ReceivePO.Columns[3].ReadOnly = true;
            sS_DataGridView_ReceivePO.Columns[5].ReadOnly = true;
            sS_DataGridView_ReceivePO.Columns[6].ReadOnly = true;
            //sS_DataGridView_ReceivePO.Columns[7].ReadOnly = true;
        }

        private void Function_SetReadOnlyColumn_DG_AssetReceive()
        {
            sS_DataGridView_AssetReceive.Columns[2].ReadOnly = true;
            //sS_DataGridView_AssetReceive.Columns[4].ReadOnly = true;
            //sS_DataGridView_AssetReceive.Columns[5].ReadOnly = true;
            //sS_DataGridView_AssetReceive.Columns[6].ReadOnly = true;
            
        }

        private void Funtion_ReadOnlyColDatagrid(bool Bool_ChkState)
        {
            sS_DataGridView_ReceivePO.Columns[7].ReadOnly = Bool_ChkState;
            sS_DataGridView_ReceivePO.Columns[8].ReadOnly = Bool_ChkState;
            sS_DataGridView_ReceivePO.Columns[9].ReadOnly = Bool_ChkState;
        }

        private bool Function_CheckReceiveClose()
        {
            int i = 0;
            int Int_TempQty = 0;
            int Int_TempReceive = 0;
            bool Bool_ReturnValue = false;

            for (i = 0; i <= sS_DataGridView_ReceivePO.Rows.Count - 1; i++)
            {
                Int_TempQty = Convert.ToInt32(sS_DataGridView_ReceivePO[3, i].Value);
                Int_TempReceive = Convert.ToInt32(sS_DataGridView_ReceivePO[4, i].Value);
                if (Int_TempQty == Int_TempReceive)
                    Bool_ReturnValue = true;
                else
                {
                    Bool_ReturnValue = false;
                    break;
                }
            }

            return Bool_ReturnValue;
        }
        private bool Function_CheckReceiveClose1()
        {
            int i = 0;
            int Int_TempQty = 0;
            int Int_TempReceive = 0;
            int Int_TempSummaryQty = 0;
            int Int_TempSummaryReceive = 0;

            for (i = 0; i <= sS_DataGridView_ReceivePO.Rows.Count - 1; i++)
            {
                Int_TempQty = Convert.ToInt32(sS_DataGridView_ReceivePO[3, i].Value);
                Int_TempReceive = Convert.ToInt32(sS_DataGridView_ReceivePO[4, i].Value);
                Int_TempSummaryQty = Int_TempSummaryQty + Int_TempQty;
                Int_TempSummaryReceive = Int_TempSummaryReceive + Int_TempReceive;
            }

            if ((Int_TempSummaryQty != Int_TempSummaryReceive) && (Int_TempSummaryReceive != 0))
                return false;
            else
                return true;

        }
        private void CheckDataInStatus(string Table)
        {
            switch (Table)
            {
                case "Status":
                    {
                        ObjectSet ObjSet_Status = Manager.Engine.GetObjectSet(typeof(Status), String.Empty);
                        Status StatusObj = (Status)ObjSet_Status.GetObject(POHomeObj.Pohdobj.StatusID);
                        if (StatusObj == null)
                        {
                            StatusObj = new Status();
                            StatusObj.ID = POHomeObj.Pohdobj.StatusID;
                            StatusObj.Name = StatusObj.ID;
                            StatusHome StatusHomeObj = new StatusHome();
                            StatusHomeObj.Statusobj = StatusObj;
                            StatusHomeObj.Add();
                        }
                        break;
                    }
            }
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                object[] Obj_PONo = new object[1] { sS_MaskedTextBox_PO.Text};
                int i = 0;
                int j = 0;
                switch (mode)
                {
                    case Enum_Mode.Search:

                        break;
                    case Enum_Mode.Edit:
                    case Enum_Mode.PreEdit:
                    

                        if (Function_InsertAssetReceiveToHashTable() == true)
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();

                            POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_PO.Text;
                            POHomeObj.Pohdobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                            //POHomeObj.Pohdobj.PODate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                            POHomeObj.Pohdobj.PODate = Convert.ToDateTime(dateTimePicker_ReceivePODate.Text);
                            POHomeObj.Pohdobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            POHomeObj.Pohdobj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                            POHomeObj.Pohdobj.Remark = sS_MaskedTextBox_Remark.Text;
                            POHomeObj.Pohdobj.FacCode = sS_MaskedTextBox_Facility.Text;
                            POHomeObj.Pohdobj.UserName = Global.ConfigDatabase.Str_UserID;

                            if (Function_CheckReceiveClose())
                                POHomeObj.Pohdobj.StatusID = "CLOSE";
                            else
                                POHomeObj.Pohdobj.StatusID = "RECEIVE";

                            CheckDataInStatus("Status");

                            if (POHomeObj.EditHDTransaction(ORTransaction))
                            {
                                Bool_CheckExecuteComplete = true;
                            }
                            else
                            {
                                Bool_CheckExecuteComplete = false;
                            }

                            for (i = 0; i <= sS_DataGridView_ReceivePO.Rows.Count - 1; i++)
                            {
                                //Str_WhereGetObject = "POID ='" + POHomeObj.POReceiveObj.Poid + "' AND POSeq ='" + POHomeObj.POReceiveObj.POSeq + "'AND modelID ='" + POHomeObj.POReceiveObj.ModelID + "'";
                                //OPathQuery<POReceive> TempOpath = new OPathQuery<POReceive>(Str_WhereGetObject);
                                //POReceive TempInventory = Manager.Engine.GetObject<SimatSoft.DB.ORM.Inventory>(TempOpath);

                                string Str_WhereGetObject = "POID ='" + sS_MaskedTextBox_PO.Text + "'AND POSeq ='" +
                                                                Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value) + "' AND " +
                                                                " modelID = '" + sS_DataGridView_ReceivePO[1, i].Value.ToString() + "'";

                                int IntCheckObject = Manager.Engine.GetObjectCount<POReceive>(Str_WhereGetObject);

                                POHomeObj.POReceiveObj.Poid = sS_MaskedTextBox_PO.Text;
                                POHomeObj.POReceiveObj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                                POHomeObj.POReceiveObj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                                POHomeObj.POReceiveObj.ModelID = sS_DataGridView_ReceivePO[1, i].Value.ToString();
                                POHomeObj.POReceiveObj.POSeq = int.Parse(sS_DataGridView_ReceivePO[0, i].Value.ToString());
                                POHomeObj.POReceiveObj.Qty = Convert.ToInt32(sS_DataGridView_ReceivePO[4, i].Value.ToString());
                                POHomeObj.POReceiveObj.POPrice = Convert.ToDecimal(sS_DataGridView_ReceivePO[5, i].Value.ToString());
                                POHomeObj.POReceiveObj.POCost = Convert.ToDecimal(sS_DataGridView_ReceivePO[6, i].Value.ToString());
                                POHomeObj.POReceiveObj.Remark = Convert.ToString(sS_DataGridView_ReceivePO[10, i].Value);
                                POHomeObj.POReceiveObj.CreatedDate = DateTime.Now.Date;
                                POHomeObj.POReceiveObj.UserName = Global.ConfigDatabase.Str_UserID;
                                POHomeObj.POReceiveObj.FacCode = sS_MaskedTextBox_Facility.Text;

                                if (IntCheckObject == 0)
                                {
                                    if (POHomeObj.AddReceive(ORTransaction))
                                    {
                                        Bool_CheckExecuteComplete = true;
                                    }
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                    }
                                }
                                else
                                {
                                    if (POHomeObj.EditReceive(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                    }
                                }
                                // Update PODT

                                POHomeObj.Podtobj.Poid = sS_MaskedTextBox_PO.Text;
                                POHomeObj.Podtobj.POSeq = int.Parse(sS_DataGridView_ReceivePO[0, i].Value.ToString());
                                POHomeObj.Podtobj.ModelID = sS_DataGridView_ReceivePO[1, i].Value.ToString();
                                POHomeObj.Podtobj.POQty = Convert.ToInt32(sS_DataGridView_ReceivePO[3, i].Value.ToString());
                                POHomeObj.Podtobj.ReceiveQty = Convert.ToInt32(sS_DataGridView_ReceivePO[4, i].Value.ToString());
                                POHomeObj.Podtobj.POPrice = Convert.ToDecimal(sS_DataGridView_ReceivePO[5, i].Value.ToString());
                                POHomeObj.Podtobj.POCost = Convert.ToDecimal(sS_DataGridView_ReceivePO[6, i].Value.ToString());
                                POHomeObj.Podtobj.Remark = sS_MaskedTextBox_Remark.Text;
                                POHomeObj.Podtobj.ReceiveQty = Convert.ToInt32(sS_DataGridView_ReceivePO[4, i].Value.ToString());

                                if (POHomeObj.EditDT(ORTransaction))
                                {
                                    Bool_CheckExecuteComplete = true;
                                }
                                else
                                {
                                    Bool_CheckExecuteComplete = false;
                                }

                                if (AssetReceiveList.ContainsKey(Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value)))
                                {
                                    Detail_Receive TempDetailReceive = (Detail_Receive)AssetReceiveList[Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value)];
                                    for (j = 0; j <= TempDetailReceive.Arry_POReceive.Count - 1; j++)
                                    {
                                        Asset_Receive TempAssetReceive = (Asset_Receive)TempDetailReceive.Arry_POReceive[j];
                                        if (TempAssetReceive.Bool_NewStatus == true)
                                        {
                                            // Add AssetReceive in hashtable to dbo.Asset

                                            AssetHomeObj.Assetobj.ID = TempAssetReceive.Str_AssetNo;
                                            AssetHomeObj.Assetobj.Name = TempAssetReceive.Str_AssetName;
                                            AssetHomeObj.Assetobj.SerialNo = TempAssetReceive.Str_SerialNo;
                                            AssetHomeObj.Assetobj.ModelID = TempAssetReceive.Str_ModelID;
                                            AssetHomeObj.Assetobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                                            AssetHomeObj.Assetobj.FloorID = TempAssetReceive.Str_Floor;
                                            AssetHomeObj.Assetobj.BuildID = TempAssetReceive.Str_Building;
                                            AssetHomeObj.Assetobj.AreaID = TempAssetReceive.Str_Area;
                                            //AssetHomeObj.Assetobj.ReasonCode = "";
                                            AssetHomeObj.Assetobj.TypeID = sS_ComboBox_Type.SelectedItem.ToString();

                                            Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);
                                            //Function_CheckDataInMaster("Type");

                                            AssetHomeObj.Assetobj.StatusID = "NEW";
                                            Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                                            AssetHomeObj.Assetobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                                            //AssetHomeObj.Assetobj.Price = decimal.Parse("");
                                            AssetHomeObj.Assetobj.WarrantyStartDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.WarrantyEndDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.CustodianID = TempAssetReceive.Str_CustodianID;
                                            //AssetHomeObj.Assetobj.PreviosCustodian = "";
                                            AssetHomeObj.Assetobj.CreatedDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                            AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.Remark = TempAssetReceive.Str_Remark;
                                            AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_Facility.Text;

                                            if (AssetHomeObj.AddAsset(ORTransaction))
                                            {
                                               
                                                Bool_CheckExecuteComplete = true;
                                            }
                                            else
                                                Bool_CheckExecuteComplete = false;


                                            POHomeObj.AssetReceiveObj.Poid = sS_MaskedTextBox_PO.Text;
                                            POHomeObj.AssetReceiveObj.POSeq = Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value);
                                            POHomeObj.AssetReceiveObj.ModelID = TempAssetReceive.Str_ModelID;
                                            POHomeObj.AssetReceiveObj.AssetID = TempAssetReceive.Str_AssetNo;
                                            POHomeObj.AssetReceiveObj.SerialID = TempAssetReceive.Str_SerialNo;
                                            POHomeObj.AssetReceiveObj.BuildID = TempAssetReceive.Str_Building;
                                            POHomeObj.AssetReceiveObj.FloorID = TempAssetReceive.Str_Floor;
                                            POHomeObj.AssetReceiveObj.AreaID = TempAssetReceive.Str_Area;
                                            POHomeObj.AssetReceiveObj.CustodianID = TempAssetReceive.Str_CustodianID;
                                            POHomeObj.AssetReceiveObj.ReceiveDate = DateTime.Now.Date;
                                            POHomeObj.AssetReceiveObj.UserName = Global.ConfigDatabase.Str_UserID;
                                            POHomeObj.AssetReceiveObj.Remark = TempAssetReceive.Str_Remark;
                                            POHomeObj.AssetReceiveObj.FacCode = sS_MaskedTextBox_Facility.Text;

                                            if (POHomeObj.AddAssetReceive(ORTransaction))
                                            {
                                                Bool_CheckExecuteComplete = true;
                                            }
                                            else
                                            {
                                                Bool_CheckExecuteComplete = false;
                                            }
                                        }
                                    }
                                }
                            }
                            if (Bool_CheckExecuteComplete)
                            {
                                ORTransaction.Commit();
                                SS_MyMessageBox.ShowBox("Receive data : " + sS_MaskedTextBox_PO.Text + " Complete", "Receive PurchaseOrder Information", DialogMode.OkOnly, this.Name, "000001", Obj_PONo, Global.Lang.Str_Language);
                                string Str_TempPOID = sS_MaskedTextBox_PO.Text;
                                sS_MaskedTextBox_PO.Text = Str_TempPOID;
                                Fucntion_ClearDataInCellDatagrid();
                                QtyNewReceivePOReceive.Clear();

                                 Function_SaveCurrentRunningNo(runID);
                                 updateRowcount = 0;
                                
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not receive data : " + sS_MaskedTextBox_PO.Text + " +", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_PONo, Global.Lang.Str_Language);
                                ORTransaction.Rollback();
                                //Fucntion_ClearDataInCellDatagrid();

                                 Function_SaveCurrentRunningNo(GlobalNo); 
                            }
                        }
                        //else
                        //    SS_MyMessageBox.ShowBox("Please input data ", "Warning", DialogMode.OkOnly, this.Name, "000003", Obj_PONo, Global.Lang.Str_Language);

                        break;
                    case Enum_Mode.ShowData://

                        Manager.Engine.ClearTracking();
                        POHomeObj.Pohdobj = Manager.Engine.GetObject<Pohd>(sS_MaskedTextBox_PO.Text);
                        //DataSet ds=(DataSet) Manager.Engine.GetDataSet<Pohd>(sS_MaskedTextBox_PO.Text);

                        sS_MaskedTextBox_SupplierNo.Text = POHomeObj.Pohdobj.VendorID;
                        sS_MaskedTextBox_SupplierName.Text = Global.FormOrder.Function_GetSupplierName(POHomeObj.Pohdobj.VendorID);
                        //sS_MaskedTextBox_Date.Text = POHomeObj.Pohdobj.PODate.ToShortDateString();
                        dateTimePicker_ReceivePODate.Text = POHomeObj.Pohdobj.PODate.ToShortDateString();
                        sS_MaskedTextBox_DepartmentNo.Text = POHomeObj.Pohdobj.DeptID;
                        sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(POHomeObj.Pohdobj.DeptID);
                        //sS_ComboBox_Type.SelectedIndex = Global.FormOrder.Function_SetType(POHomeObj.Pohdobj.POType);
                        sS_ComboBox_Type.SelectedItem = POHomeObj.Pohdobj.POType;
                        sS_MaskedTextBox_Facility.Text = POHomeObj.Pohdobj.FacCode;
                        sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(POHomeObj.Pohdobj.FacCode);
                        sS_MaskedTextBox_Remark.Text = POHomeObj.Pohdobj.Remark;

                        Int_CountObjDTs = POHomeObj.Pohdobj.Podts.Count;

                        sS_DataGridView_ReceivePO.Rows.Clear();
                        sS_DataGridView_AssetReceive.Rows.Clear();
                        AssetReceiveList.Clear();

                        for (i = 0; i <= POHomeObj.Pohdobj.Podts.Count-1; i++)
                        {
                            POHomeObj.Podtobj = (Podt)POHomeObj.Pohdobj.Podts[i];


                            if (POHomeObj.Podtobj.ReceiveQty > 0)
                            {
                                for (j = 0; j <= POHomeObj.Pohdobj.POReceives.Count - 1; j++)
                                {
                                    POReceive TempPOReceive = (POReceive)POHomeObj.Pohdobj.POReceives[i];
                                    if ((TempPOReceive.Poid == POHomeObj.Podtobj.Poid) && (TempPOReceive.POSeq == POHomeObj.Podtobj.POSeq) && (TempPOReceive.ModelID == POHomeObj.Podtobj.ModelID))
                                    {
                                        POHomeObj.POReceiveObj = TempPOReceive;
                                        break;
                                    }
                                }

                                int Int_Loop = 0;
                                Detail_Receive TempDetailReceive = new Detail_Receive();
                                TempDetailReceive.Arry_POReceive = new System.Collections.ArrayList();

                                TempDetailReceive.Int_POSeq = POHomeObj.POReceiveObj.POSeq;
                                TempDetailReceive.Str_ModelID = POHomeObj.POReceiveObj.ModelID;
                                
                                
                                string Str_SQLAssetReive = "POID ='" + POHomeObj.POReceiveObj.Poid +
                                                            "'AND ModelID ='" + POHomeObj.POReceiveObj.ModelID +
                                                            "'AND POSeq ='" + POHomeObj.POReceiveObj.POSeq + "'";

                                ObjectSet<AssetReceive> AssetReceiveObj = Manager.Engine.GetObjectSet<AssetReceive>(Str_SQLAssetReive);

                                TempDetailReceive.Int_Count = AssetReceiveObj.Count;
                                for (Int_Loop = 0; Int_Loop <= AssetReceiveObj.Count - 1; Int_Loop++)
                                {
                                    Asset_Receive TempAssetReceive = new Asset_Receive();

                                    TempAssetReceive.Str_AssetNo = AssetReceiveObj[Int_Loop].AssetID;
                                    TempAssetReceive.Str_AssetName =Global.FormOrder.Function_GetAssetName(AssetReceiveObj[Int_Loop].AssetID);
                                    TempAssetReceive.Str_ModelID = AssetReceiveObj[Int_Loop].ModelID;
                                    TempAssetReceive.Str_SerialNo = AssetReceiveObj[Int_Loop].SerialID;
                                    TempAssetReceive.Str_Floor = AssetReceiveObj[Int_Loop].FloorID;
                                    TempAssetReceive.Str_Building = AssetReceiveObj[Int_Loop].BuildID;
                                    TempAssetReceive.Str_Area = AssetReceiveObj[Int_Loop].AreaID;
                                    TempAssetReceive.Str_CustodianID = AssetReceiveObj[Int_Loop].CustodianID;
                                    TempAssetReceive.Str_Remark = AssetReceiveObj[Int_Loop].Remark;
                                    TempAssetReceive.Bool_NewStatus = false;
                                    TempDetailReceive.Arry_POReceive.Add(TempAssetReceive);
                                }

                                AssetReceiveList.Add(POHomeObj.POReceiveObj.POSeq, TempDetailReceive);
                                

                            }

                            POHomeObj.Podtobj = (Podt)POHomeObj.Pohdobj.Podts[i];
                            Object[] Rows = new Object[] { POHomeObj.Podtobj.POSeq, POHomeObj.Podtobj.ModelID,Global.FormOrder.Function_GetModelName(POHomeObj.Podtobj.ModelID), POHomeObj.Podtobj.POQty, POHomeObj.Podtobj.ReceiveQty, POHomeObj.Podtobj.POPrice, POHomeObj.Podtobj.POCost, "", "", "", POHomeObj.Podtobj.Remark };

                            sS_DataGridView_ReceivePO.Rows.Add(Rows);
                        }
                        
                        //Global.Function_ToolStripSetUP(Enum_Mode.SaveOnly);
                        Global.Function_ToolStripSetUP(Enum_Mode.PreEdit);
                        Fucntion_ClearDataInCellDatagrid();
                        Function_InsertAssetReceiveToDatagrid();
                        Function_SetReadOnlyColumnDataGrid();
                       
                        break;
                    case Enum_Mode.Cancel:
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        //Funtion_ReadOnlyColDatagrid(false);

                        Function_SaveCurrentRunningNo(GlobalNo);
                        updateRowcount = 0 ;
                        break;
                        //goto DEFAULT;

                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_PO.ReadOnly = false;
                        sS_MaskedTextBox_PO.Focus();
                        break;

                }

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Form_001002_ReceivePurchaseOrder_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            Function_SetReadOnlyControl(true);
            Function_SetControlEnable(false);
            dateTimePicker_ReceivePODate.Enabled = false;
            updateRowcount = 0;
         }

        private void sS_MaskedTextBox_PO_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    //Global.Function_ShowFormSearchOrder();
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.PO);

                    sS_MaskedTextBox_PO.Text = Global.ReturnValue.Str_FormSearch;
                    if (Global.ReturnValue.Str_FormSearch != "")
                    {
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        Funtion_ReadOnlyColDatagrid(false);

                        //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                    }
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_DataGridView_ReceivePO_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            Int_POSeq = Convert.ToInt32(sS_DataGridView_ReceivePO[0, e.RowIndex].Value);
            Str_ModelID = sS_DataGridView_ReceivePO[1, e.RowIndex].Value.ToString();
            

            Int_OldReceiveQtyValue = Convert.ToInt32(sS_DataGridView_ReceivePO[4, e.RowIndex].Value);

            Function_InsertAssetReceiveToDatagrid();

         }

       /// <summary>
       /// เป็นฟังก์ชันสำหรับ....
       /// </summary>
        private void Function_ChkDataInSubDetail()
        {
            if (sS_DataGridView_AssetReceive.Rows.Count != 0)
            {
                Detail_Receive TempDetail_Receive = (Detail_Receive)AssetReceiveList[Int_POSeq];
                int Int_CountNewReceive = sS_DataGridView_AssetReceive.Rows.Count - TempDetail_Receive.Int_Count;

                if (Int_CountNewReceive != 0)
                {
                    for (int i = sS_DataGridView_AssetReceive.Rows.Count - 1; i >= Int_CountNewReceive; i--)
                    {
                        if (sS_DataGridView_AssetReceive[0,i].Value.ToString() != "")
                        {
                            Funtion_ReadOnlyColDatagrid(true);
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Clear Data in FloorID,BuildingID,AreaID in Datagrid
        /// 05/06/07
        /// </summary>
        private void Fucntion_ClearDataInCellDatagrid()
        {
            if (sS_DataGridView_ReceivePO.Rows.Count > 0)
            {
                if (sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString() != "")
                    sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = "";
                if (sS_DataGridView_ReceivePO[8, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString() != "")
                    sS_DataGridView_ReceivePO[8, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = "";
                if (sS_DataGridView_ReceivePO[9, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString() != "")
                    sS_DataGridView_ReceivePO[9, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = "";
                if (sS_DataGridView_ReceivePO[10, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString() != "")
                    sS_DataGridView_ReceivePO[10, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = "";
            }           
        }
        /// <summary>
        /// ตรวจสอบข้อมูลในมาสเตอร์ว่ามีอยู่หรือยัง 
        /// </summary>
        /// <param name="Table"></param>
        private void Function_CheckDataInMaster(string Table)
        {
            switch (Table)
            {
                case "Type":
                    {
                        ObjectSet ObjSet_Type = Manager.Engine.GetObjectSet(typeof(SimatSoft.DB.ORM.Type), String.Empty);
                        SimatSoft.DB.ORM.Type TypeObj = (SimatSoft.DB.ORM.Type)ObjSet_Type.GetObject(AssetHomeObj.Assetobj.TypeID);
                        if (TypeObj == null)
                        {
                            TypeObj = new SimatSoft.DB.ORM.Type();
                            TypeObj.ID = AssetHomeObj.Assetobj.TypeID;
                            TypeObj.Name = TypeObj.ID;
                            TypeObj.Remark = Convert.ToString("");
                            TypeHome TypeHomeObj = new TypeHome();
                            TypeHomeObj.Typeobj = TypeObj;
                            TypeHomeObj.Add();
                        }
                        break;
                    }
            }
        }
        private void Function_InsertAssetReceiveToDatagrid()
        {
            if (AssetReceiveList.ContainsKey(Int_POSeq))
            {
                Detail_Receive TempDetailReceive = new Detail_Receive();
                sS_DataGridView_AssetReceive.Rows.Clear();

                TempDetailReceive = (Detail_Receive)AssetReceiveList[Int_POSeq];
                for (int i = 0; i <= TempDetailReceive.Arry_POReceive.Count - 1; i++)
                {
                    Asset_Receive TempAssetReceive = new Asset_Receive();
                    TempAssetReceive = (Asset_Receive)TempDetailReceive.Arry_POReceive[i];

                    Object[] Rows = new Object[]{TempAssetReceive.Str_AssetNo,TempAssetReceive.Str_AssetName,TempAssetReceive.Str_ModelID,
                                                 TempAssetReceive.Str_SerialNo,TempAssetReceive.Str_Building,TempAssetReceive.Str_Floor,
                                                 TempAssetReceive.Str_Area,TempAssetReceive.Str_CustodianID,TempAssetReceive.Str_Remark};

                    sS_DataGridView_AssetReceive.Rows.Add(Rows);
                    Function_SetReadOnlyColumn_DG_AssetReceive();
                }
            }
            else
                sS_DataGridView_AssetReceive.Rows.Clear();
        }

        private bool Function_CheckDataInDatagrid()
        {
            if ((Str_FloorID != "") && (Str_BuildID != "") && (Str_AreaID != ""))
            {
                return true;
               
            }

            return false ;
        }

        private void Function_PlusReceiveQty(int Int_ColIndex,int Int_RowIndex)
        {
            int Int_NewReceiveQtyValue =Convert.ToInt32(sS_DataGridView_ReceivePO[Int_ColIndex,Int_RowIndex].Value);

            if(QtyNewReceivePOReceive.ContainsKey(Int_POSeq))
            {
                int Int_TempPlusReceiveQty = Convert.ToInt32(QtyNewReceivePOReceive[Int_POSeq]) + Int_NewReceiveQtyValue;
                QtyNewReceivePOReceive.Remove(Int_POSeq);
                QtyNewReceivePOReceive.Add(Int_POSeq, Int_TempPlusReceiveQty);
            }
            else
                QtyNewReceivePOReceive.Add(Int_POSeq, Int_NewReceiveQtyValue);

            int IntPlusValue = Int_OldReceiveQtyValue + Int_NewReceiveQtyValue;
            if (IntPlusValue <= Convert.ToInt32(sS_DataGridView_ReceivePO[Int_ColIndex - 1, Int_RowIndex].Value))
            {
                sS_DataGridView_ReceivePO[Int_ColIndex, Int_RowIndex].Value = IntPlusValue;
            }
            else
            {
                SS_MyMessageBox.ShowBox("Receive quantity more than Quantity ", "Warning", DialogMode.OkOnly, this.Name, "000004", Global.Lang.Str_Language);
                sS_DataGridView_ReceivePO[Int_ColIndex, Int_RowIndex].Value = Int_OldReceiveQtyValue;
            }
        }
      
        private bool Function_InsertAssetReceiveToHashTable()
        {
            int i = 0;

            Detail_Receive TempDetailReceive = new Detail_Receive();

            if (sS_DataGridView_AssetReceive.Rows.Count!=0)
            {
                if (AssetReceiveList.ContainsKey(Int_POSeq))
                {               
                    TempDetailReceive = (Detail_Receive)AssetReceiveList[Int_POSeq];
                    for (i = 0; i <= sS_DataGridView_AssetReceive.Rows.Count - 1; i++)
                    {     
                            Asset_Receive TempAssetReceive = new Asset_Receive();
                            TempAssetReceive.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);

                            if (TempAssetReceive.Str_AssetNo != "")
                             {
                                TempAssetReceive.Str_AssetName = Convert.ToString(sS_DataGridView_AssetReceive[1, i].Value);
                                TempAssetReceive.Str_ModelID = sS_DataGridView_AssetReceive[2, i].Value.ToString();
                                TempAssetReceive.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetReceive[3, i].Value);
                                TempAssetReceive.Str_Building = sS_DataGridView_AssetReceive[4, i].Value.ToString();
                                TempAssetReceive.Str_Floor = sS_DataGridView_AssetReceive[5, i].Value.ToString();
                                TempAssetReceive.Str_Area = sS_DataGridView_AssetReceive[6, i].Value.ToString();
                                TempAssetReceive.Str_CustodianID = sS_DataGridView_AssetReceive[7, i].Value.ToString();
                                TempAssetReceive.Str_Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, i].Value);

                                if (TempDetailReceive.Arry_POReceive.Contains(TempAssetReceive) == false)
                                {
                                    TempAssetReceive.Bool_NewStatus = true;

                                    if (TempDetailReceive.Arry_POReceive.Contains(TempAssetReceive) == false)

                                        TempDetailReceive.Arry_POReceive.Add(TempAssetReceive);
                                }                           
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Please intput data ", "Warning", DialogMode.OkOnly, this.Name, "000003", Global.Lang.Str_Language);
                                return false;
                            }
                    }
                    AssetReceiveList.Remove(Int_POSeq);
                    AssetReceiveList.Add(Int_POSeq, TempDetailReceive);
                }
                else
                {
                    TempDetailReceive.Arry_POReceive = new System.Collections.ArrayList();
                    TempDetailReceive.Int_POSeq = Int_POSeq;
                    TempDetailReceive.Str_ModelID = Str_ModelID;
                    

                    for (i = 0; i <= sS_DataGridView_AssetReceive.Rows.Count - 1; i++)
                    {
                        Asset_Receive TempAssetReceive = new Asset_Receive();

                            TempAssetReceive.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);
                        if ((TempAssetReceive.Str_AssetNo != ""))
                        {
                                TempAssetReceive.Str_AssetName = Convert.ToString(sS_DataGridView_AssetReceive[1, i].Value);
                                TempAssetReceive.Str_ModelID = sS_DataGridView_AssetReceive[2, i].Value.ToString();
                                TempAssetReceive.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetReceive[3, i].Value);
                                TempAssetReceive.Str_Building = sS_DataGridView_AssetReceive[4, i].Value.ToString();
                                TempAssetReceive.Str_Floor = sS_DataGridView_AssetReceive[5, i].Value.ToString();
                                TempAssetReceive.Str_Area = sS_DataGridView_AssetReceive[6, i].Value.ToString();
                                TempAssetReceive.Str_CustodianID = sS_DataGridView_AssetReceive[7, i].Value.ToString();
                                TempAssetReceive.Str_Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, i].Value);
                                TempAssetReceive.Bool_NewStatus = true;
                                TempDetailReceive.Arry_POReceive.Add(TempAssetReceive);
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Please intput data ", "Warning", DialogMode.OkOnly, this.Name, "000003", Global.Lang.Str_Language);
                            return false;
                        }
                    }

                    AssetReceiveList.Add(Int_POSeq, TempDetailReceive);
                }
            }
            return true;
        }
        int Int_CountNewReceive;
        private void sS_DataGridView_ReceivePO_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Int_CountNewReceive = Convert.ToInt32(sS_DataGridView_ReceivePO[4, e.RowIndex].Value);
                Function_PlusReceiveQty(e.ColumnIndex, e.RowIndex);
            }
            
        }

        private void sS_MaskedTextBox_SupplierNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_SupplierNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_SupplierName;
                Frm_Present.Show_Data("Screen", "002005");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_DepartmentNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_DepartmentNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_DeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_Facility_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_Facility;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_ReceivePO_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
           
            SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
            TextBox TempTextBox = new TextBox();


            if (e.ColumnIndex == 7)//building
            {
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 8)//floor
            {
                string build = sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString();
                string qry = " Buildid = '" + build + "'";
                Frm_Present.Show_Data("Screen", "002009" ,qry);
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[8, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 9)//area
            {
                string build = sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString();
                string floor = sS_DataGridView_ReceivePO[8, sS_DataGridView_ReceivePO.CurrentRow.Index].Value.ToString();
                string qry = " Buildid = '" + build + "' and Floorid = '" + floor + "'";
                Frm_Present.Show_Data("Screen", "002007", qry);
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[9, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
           
        }

        private void sS_DataGridView_AssetReceive_Leave(object sender, EventArgs e)
        {
                Function_InsertAssetReceiveToHashTable();
        }

        int Int_TempNewReceive;
        private void sS_DataGridView_ReceivePO_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Funtion_ReadOnlyColDatagrid(false);
            if (sS_DataGridView_ReceivePO.Rows.Count != 0)
            {
                Int_TempNewReceive = Convert.ToInt32(sS_DataGridView_ReceivePO[4, e.RowIndex].Value);

                if ((sS_DataGridView_ReceivePO[7, e.RowIndex].Value.ToString() != "") && (sS_DataGridView_ReceivePO[8, e.RowIndex].Value.ToString() != "") &&
                   (sS_DataGridView_ReceivePO[9, e.RowIndex].Value.ToString() != ""))
                {
                    //if ( Int_TempNewReceive!= Int_OldReceiveQtyValue)
                    for (int i = 0; i <= Int_CountNewReceive - 1; i++)
                    {
                        Str_BuildID = Convert.ToString(sS_DataGridView_ReceivePO[7, e.RowIndex].Value);
                        Str_FloorID = Convert.ToString(sS_DataGridView_ReceivePO[8, e.RowIndex].Value);
                        Str_AreaID = Convert.ToString(sS_DataGridView_ReceivePO[9, e.RowIndex].Value);

                        if (Convert.ToInt32(sS_DataGridView_ReceivePO[4, e.RowIndex].Value) > 0)
                        {
                            POHomeObj.AssetReceiveObj.POSeq = Int_POSeq;
                            Object[] Rows = new Object[] { "", "", Str_ModelID, "", Str_FloorID, Str_BuildID, Str_AreaID, "" };

                            //if (Int_TempNewReceive != sS_DataGridView_AssetReceive.Rows.Count)
                            if (Int_TempNewReceive != sS_DataGridView_AssetReceive.Rows.Count)
                            {
                                if (Int_TempNewReceive == sS_DataGridView_AssetReceive.Rows.Count)

                                    break;
                                else
                                {
                                    sS_DataGridView_AssetReceive.Rows.Add(Rows);
                                    Function_SetReadOnlyColumn_DG_AssetReceive();
                                }
                            }
                        }
                    }
                }
            }
                //Function_ChkDataInSubDetail();
            }
        

       
        private void sS_DataGridView_ReceivePO_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
             int Int_CountNewReceive;
            if ((sS_DataGridView_ReceivePO.Rows.Count != 0)&&(sS_DataGridView_AssetReceive.Rows.Count!=0))
            {

                Str_BuildID = sS_DataGridView_ReceivePO[7, e.RowIndex].Value.ToString();
                Str_FloorID = sS_DataGridView_ReceivePO[8, e.RowIndex].Value.ToString();
                Str_AreaID = sS_DataGridView_ReceivePO[9, e.RowIndex].Value.ToString();            


                if (AssetReceiveList.Count == 0)
                {
                    Int_CountNewReceive = sS_DataGridView_AssetReceive.Rows.Count - AssetReceiveList.Count;

                    for (int i = 0; i <= Int_CountNewReceive - 1; i++)
                    {
                        sS_DataGridView_AssetReceive[4, i].Value = Str_BuildID;
                        sS_DataGridView_AssetReceive[5, i].Value = Str_FloorID;

                        sS_DataGridView_AssetReceive[6, i].Value = Str_AreaID;
                    }
                }
                else
                {
                    Detail_Receive TempDetail_Receive = (Detail_Receive)AssetReceiveList[Int_POSeq];
                    Int_CountNewReceive = sS_DataGridView_AssetReceive.Rows.Count - TempDetail_Receive.Arry_POReceive.Count;

                    for (int j = sS_DataGridView_AssetReceive.Rows.Count - 1; j >= TempDetail_Receive.Arry_POReceive.Count; j--)
                    {
                        sS_DataGridView_AssetReceive[4, j].Value = Str_BuildID;
                        sS_DataGridView_AssetReceive[5, j].Value = Str_FloorID;
                        sS_DataGridView_AssetReceive[6, j].Value = Str_AreaID;
                    }
                   
                }
            }

            
        }

        private void sS_DataGridView_AssetReceive_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
            

            if (e.ColumnIndex == 4)// Building
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                TextBox TempTextBox = new TextBox();

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Show_Data("Screen", "002008");

                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[4, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 5)// Floor
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                TextBox TempTextBox = new TextBox();

                Frm_Present.Controlreturnvalue = TempTextBox;
                string build = sS_DataGridView_AssetReceive[4, sS_DataGridView_AssetReceive.CurrentRow.Index].Value.ToString();
                string qry = " Buildid = '" + build + "'";
                Frm_Present.Show_Data("Screen", "002009",qry);
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[5, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 6)// Area
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                TextBox TempTextBox = new TextBox();

                Frm_Present.Controlreturnvalue = TempTextBox;
                string build = sS_DataGridView_AssetReceive[4, sS_DataGridView_AssetReceive.CurrentRow.Index].Value.ToString();
                string floor = sS_DataGridView_AssetReceive[5, sS_DataGridView_AssetReceive.CurrentRow.Index].Value.ToString();
                string qry = " Buildid = '" + build + "' and FloorId = '" + floor + "'";
                Frm_Present.Show_Data("Screen", "002007",qry);

                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[6, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
                sS_DataGridView_AssetReceive.CurrentCell = sS_DataGridView_AssetReceive[7, sS_DataGridView_AssetReceive.CurrentRow.Index];
            }
            if (e.ColumnIndex == 7)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                TextBox TempTextBox = new TextBox();

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Show_Data("Screen", "002011");

                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[7, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
                sS_DataGridView_AssetReceive.CurrentCell = sS_DataGridView_AssetReceive[8, sS_DataGridView_AssetReceive.CurrentRow.Index];
            }
            if (e.ColumnIndex == 0)
            {
                //        Global_AssetNo = Function_GetNextRunningNo();
                //        sS_DataGridView_AssetReceive[0, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = Global_AssetNo;
                //        runID = Global_AssetNo.Replace(prefix, "");
                //        Function_SaveCurrentRunningNo(runID);

                    row_count++; //
                    updateRowcount = row_count;
                    if (updateRowcount > 1)
                    {
                        string current_AssetNo = Function_GetNextRunningNoTemp(updateTempRunID);
                       sS_DataGridView_AssetReceive[0, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = current_AssetNo;
                       updateTempRunID = current_AssetNo.Replace(prefix, "");
                       runID = updateTempRunID;
                    }
                    else if (updateRowcount == 1)
                    {
                        Global_AssetNo = Function_GetNextRunningNo();
                        sS_DataGridView_AssetReceive[0, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = Global_AssetNo;
                        runID = Global_AssetNo.Replace(prefix, "");
                        updateTempRunID = runID;
                        //Function_SaveCurrentRunningNo(runID);
                    }

             
                
                
            }

        }
        private string Function_GetNextRunningNoTemp(string TempRunID)
        {
            string nextNo = "";
            try
            {
                   
                    int current = Convert.ToInt32(TempRunID);

                    int lenght = TempRunID.Length;
                    current++;
                    string str_current = current.ToString();
                    string runningid = "";
                    if (lenght > str_current.Length)
                    {
                        for (int i = 0; i < lenght - current.ToString().Length; i++)
                            runningid += "0";
                        runningid += str_current;
                    }
                    
                    nextNo = prefix + runningid;
                

            }
            catch { }

            return nextNo;
        
        }
        private void Form_001002_ReceivePurchaseOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            //Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.SetDefault;
            //Enm_StateForm = Enum_Mode.SetDefault;
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_DataGridView_ReceivePO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sS_DataGridView_AssetReceive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    prefix = ds.Tables[0].Rows[0][0].ToString();
                    int current = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                    GlobalNo = ds.Tables[0].Rows[0][1].ToString().Trim();
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
            catch { }

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
            catch { }

        }
       
  }
}