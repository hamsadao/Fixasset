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
    public partial class Form_001004_InternalTransfer : SS_PaintGradientForm
    {
        DataView dtV_Type = new DataView();
        int Int_TransferSeq = 0;
        int Int_Qty = 0;
        string Str_ModelID = "";
        string Str_DeptID = "";
        string Str_BuildingID = "";
        string Str_FloorID = "";
        string Str_FacCode = "";
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        AssetTransferHome AssetTransferHomeObj = new AssetTransferHome();
        struct DetailTransfer
        {
            public int Int_TransferSeq;
            public string Str_ModelID;
            public string Str_DeptID;
            public string Str_BuildingID;
            public string Str_FloorID;
            public string Str_FacCode;
            public System.Collections.ArrayList Arry_DetailTransfer;
        }
        struct TransferSerial
        {
            public int Int_TransferSeq;
            public string Str_AssetNo;
            public string Str_AssetName;
            public string Str_SerialNo;
            public string Str_FromBuilding;
            public string Str_ToBuilding;
            public string Str_FromFloor;
            public string Str_ToFloor;
            public string Str_FromArea;
            public string Str_ToArea;
            public string Str_FromCustodian;
            public string Str_ToCustodian;
            public string Str_Remark;
            public bool Bool_NewStatus;
        }

        System.Collections.Hashtable AssetDetailTransferList = new System.Collections.Hashtable();

        public Form_001004_InternalTransfer()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.ShowData);
            //Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.SaveOnly;
            Global.ConfigForm.Enum_FlagTransaction = Enum_Mode.PreEdit;

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Global.ConfigForm.Enum_FlagTransaction);
        }
        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001004(Internal Transfer)");
            LBL_TransferNo.Text = Global.Function_Language(this, LBL_TransferNo, "Transfer No:");
            LBL_Date.Text = Global.Function_Language(this, LBL_Date, "Date:");
            LBL_Type.Text = Global.Function_Language(this, LBL_Type, "Type:");
            LBL_FormDepartment.Text = Global.Function_Language(this, LBL_FormDepartment, "From Department:");
            LBL_ToDepartment.Text = Global.Function_Language(this, LBL_ToDepartment, "To Department:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");

            // Get Type for Internal Transfer
            DataSet ds = (DataSet)Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Type>(" TypeGroup = 'INTT'");
            dtV_Type = new DataView(ds.Tables[0]);
            sS_ComboBox_Type.DataSource = dtV_Type;
            sS_ComboBox_Type.ValueMember = "typeName";
            sS_ComboBox_Type.DisplayMember = "Name";
        }

        private void Form_001004_InternalTransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_TransferNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromDept.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromDeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToDept.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToDeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
            
        }
        public void Function_SetReadOnlyColumnDatagrid()
        {
            sS_DataGridView_AssetTransferDT.ReadOnly = false;
            sS_DataGridView_AssetTransferDT.Columns[0].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[1].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[2].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[3].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[4].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[5].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[6].ReadOnly = true;
            sS_DataGridView_AssetTransferDT.Columns[7].ReadOnly = true;
        }

        public void Function_ReadOnlyColumnDatagridSubDT(bool Bool_StateControl)
        {
            sS_DataGridView_AssetTransferSerial.Columns[0].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[2].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[3].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[4].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[6].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[8].ReadOnly = Bool_StateControl;
            sS_DataGridView_AssetTransferSerial.Columns[10].ReadOnly = Bool_StateControl;
            
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_TransferNo.Text = "";
                sS_MaskedTextBox_FromDept.Text = "";
                sS_MaskedTextBox_FromDeptName.Text = "";
                sS_MaskedTextBox_ToDept.Text = "";
                sS_MaskedTextBox_ToDeptName.Text = "";
                sS_MaskedTextBox_FromFacCode.Text = "";
                sS_MaskedTextBox_FromFacName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_ComboBox_Type.SelectedIndex = 0;
                sS_DataGridView_AssetTransferDT.Rows.Clear();
                Function_SetReadOnlyControl(true);
                AssetDetailTransferList.Clear();
                sS_DataGridView_AssetTransferSerial.Rows.Clear();
                
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On StockControl Clear Data in Control", DialogMode.Error_Cancel, Ex);
            }
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
               Wilson.ORMapper.Transaction ORTransaction = null;
               
               AssetHome AssetHomeObj = new AssetHome();
                bool Bool_CheckExecuteComplete = false;
                object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferNo.Text };
                int i = 0;
                int j = 0;

                switch (mode)
                {
                    case Enum_Mode.Search:

                        break;
                    case Enum_Mode.Edit:
                        //if (Function_CheckCellGridValue() == true)
                        //{
                            Function_InsertTransferSerialToHashTable();
                            ORTransaction = Manager.Engine.BeginTransaction();
                            AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferNo.Text;
                            //AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                            AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                            AssetTransferHomeObj.AssetTransferHDObj.FromDeptID = sS_MaskedTextBox_FromDept.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToDeptID = sS_MaskedTextBox_ToDept.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                            AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_FromFacCode.Text;

                            AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "I";
                            if (Function_CheckTrasferClose())
                                AssetTransferHomeObj.AssetTransferHDObj.StatusID = "CLOSE";
                            else
                                AssetTransferHomeObj.AssetTransferHDObj.StatusID = "RECEIVE";

                            if (AssetTransferHomeObj.EditHD(ORTransaction))
                                Bool_CheckExecuteComplete = true;
                            else
                                goto ERROR;

                            for (i = 0; i <= sS_DataGridView_AssetTransferDT.Rows.Count - 1; i++)
                            {
                                string Str_WhereGetObject = "TransferID ='" + sS_MaskedTextBox_TransferNo.Text + "'AND TransferSeq ='" +
                                                                Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value) + "' AND " +
                                                                " modelID = '" + sS_DataGridView_AssetTransferDT[1, i].Value.ToString() + "'";

                                int IntCheckObject = Manager.Engine.GetObjectCount<AssetTransfer>(Str_WhereGetObject);

                                AssetTransferHomeObj.AssetTransferObj.TransferID = sS_MaskedTextBox_TransferNo.Text;
                                AssetTransferHomeObj.AssetTransferObj.ModelID = sS_DataGridView_AssetTransferDT[1, i].Value.ToString();
                                AssetTransferHomeObj.AssetTransferObj.TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value);
                                AssetTransferHomeObj.AssetTransferObj.TransferQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[4, i].Value);
                                AssetTransferHomeObj.AssetTransferObj.CreatedDate = DateTime.Now.Date;
                                AssetTransferHomeObj.AssetTransferObj.UserName = Global.ConfigDatabase.Str_UserID;
                                AssetTransferHomeObj.AssetTransferObj.TransferType = Funciton_TransferType();
                                AssetTransferHomeObj.AssetTransferObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_AssetTransferDT[5, i].Value);
                                AssetTransferHomeObj.AssetTransferObj.TransferCost = Convert.ToDecimal(sS_DataGridView_AssetTransferDT[6, i].Value);
                                AssetTransferHomeObj.AssetTransferObj.FromDeptID = sS_MaskedTextBox_FromDept.Text;
                                AssetTransferHomeObj.AssetTransferObj.ToDeptID = sS_MaskedTextBox_ToDept.Text;
                                AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                                AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_FromFacCode.Text;

                                if (IntCheckObject == 0)
                                {
                                    if (AssetTransferHomeObj.AddTransfer(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                        goto ERROR;
                                }
                                else
                                {
                                    if (AssetTransferHomeObj.EditTransfer(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                        goto ERROR;
                                }

                                // Update AssetTransferDT when user input TransferQty

                                AssetTransferHomeObj.AssetTransferDTObj.TransferID = sS_MaskedTextBox_TransferNo.Text;
                                AssetTransferHomeObj.AssetTransferDTObj.TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.ModelID = sS_DataGridView_AssetTransferDT[1, i].Value.ToString();
                                AssetTransferHomeObj.AssetTransferDTObj.OrderQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[3, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[4, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferPrice = Convert.ToDecimal(sS_DataGridView_AssetTransferDT[5, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.TransferCost = Convert.ToDecimal(sS_DataGridView_AssetTransferDT[6, i].Value);
                                AssetTransferHomeObj.AssetTransferDTObj.Remark = Convert.ToString(sS_DataGridView_AssetTransferDT[7, i].Value);


                                if (AssetTransferHomeObj.EditDT(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    goto ERROR;



                                if (AssetDetailTransferList.ContainsKey(Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value)))
                                {
                          
                                    DetailTransfer TempDetailTransfer = (DetailTransfer)AssetDetailTransferList[Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value)];
                                    for (j = 0; j <= TempDetailTransfer.Arry_DetailTransfer.Count - 1; j++)
                                    {
                                        TransferSerial TempTransferSerial = (TransferSerial)TempDetailTransfer.Arry_DetailTransfer[j];

                                        if (TempTransferSerial.Bool_NewStatus == true)
                                        {
                                            AssetTransferHomeObj.AssetTransferSerialObj.TransferID = sS_MaskedTextBox_TransferNo.Text;
                                            AssetTransferHomeObj.AssetTransferSerialObj.TransferLine = j+1;
                                            AssetTransferHomeObj.AssetTransferSerialObj.TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value);
                                            AssetTransferHomeObj.AssetTransferSerialObj.AssetID = TempTransferSerial.Str_AssetNo;
                                            AssetTransferHomeObj.AssetTransferSerialObj.ModelID = TempDetailTransfer.Str_ModelID;
                                            AssetTransferHomeObj.AssetTransferSerialObj.FromBuildID = TempTransferSerial.Str_FromBuilding;
                                            AssetTransferHomeObj.AssetTransferSerialObj.BuildID = TempTransferSerial.Str_ToBuilding;
                                            AssetTransferHomeObj.AssetTransferSerialObj.FromFloor = TempTransferSerial.Str_FromFloor;
                                            AssetTransferHomeObj.AssetTransferSerialObj.FloorID = TempTransferSerial.Str_ToFloor ;
                                            AssetTransferHomeObj.AssetTransferSerialObj.FromArea = TempTransferSerial.Str_FromArea;
                                            AssetTransferHomeObj.AssetTransferSerialObj.AreaID = TempTransferSerial.Str_ToArea;
                                            AssetTransferHomeObj.AssetTransferSerialObj.PreviousCustodian = TempTransferSerial.Str_FromCustodian;
                                            AssetTransferHomeObj.AssetTransferSerialObj.CustodianID = TempTransferSerial.Str_ToCustodian;
                                            AssetTransferHomeObj.AssetTransferSerialObj.SerialID = TempTransferSerial.Str_SerialNo;
                                            AssetTransferHomeObj.AssetTransferSerialObj.ReceiveDate = DateTime.Now.Date;
                                            AssetTransferHomeObj.AssetTransferSerialObj.UserName = Global.ConfigDatabase.Str_UserID;
                                            AssetTransferHomeObj.AssetTransferSerialObj.FromDeptID = sS_MaskedTextBox_FromDept.Text;
                                            AssetTransferHomeObj.AssetTransferSerialObj.ToDeptID = sS_MaskedTextBox_ToDept.Text;
                                            AssetTransferHomeObj.AssetTransferSerialObj.Remark = TempTransferSerial.Str_Remark;

                                            string qry = "DELETE FROM AssetTransferSerial WHERE TransferID = '"+sS_MaskedTextBox_TransferNo.Text+
                                                "' AND TransferSeq = "+sS_DataGridView_AssetTransferDT[0, i].Value.ToString()+" AND ModelID = '"+
                                                    TempDetailTransfer.Str_ModelID + "' AND AssetID = '"+TempTransferSerial.Str_AssetNo+
                                                    "' AND (AreaID = '" + TempTransferSerial.Str_ToArea + "' OR AreaID = ' ')";
                                            Manager.Engine.ExecuteCommand(qry);

                                            if (AssetTransferHomeObj.AddTransferSerial(ORTransaction))
                                            //if (AssetTransferHomeObj.EditTransferSerial(ORTransaction))
                                                Bool_CheckExecuteComplete = true;
                                            else
                                                goto ERROR;

                                            //Update Asset 
                                            Asset TempAsset = Manager.Engine.GetObject<Asset>(TempTransferSerial.Str_AssetNo);
                                            if (TempAsset != null)
                                            {
                                                AssetHomeObj.Assetobj.ID = TempTransferSerial.Str_AssetNo;
                                                AssetHomeObj.Assetobj.Name = TempTransferSerial.Str_AssetName;
                                                AssetHomeObj.Assetobj.ModelID = Str_ModelID;
                                                AssetHomeObj.Assetobj.DeptID = sS_MaskedTextBox_ToDept.Text;
                                                AssetHomeObj.Assetobj.SerialNo = TempTransferSerial.Str_SerialNo;
                                                AssetHomeObj.Assetobj.BuildID = TempTransferSerial.Str_ToBuilding ;
                                                AssetHomeObj.Assetobj.FloorID = TempTransferSerial.Str_ToFloor;
                                                AssetHomeObj.Assetobj.AreaID = TempTransferSerial.Str_ToArea;
                                                AssetHomeObj.Assetobj.PreviosCustodian = TempTransferSerial.Str_FromCustodian;
                                                AssetHomeObj.Assetobj.CustodianID = TempTransferSerial.Str_ToCustodian;
                                                AssetHomeObj.Assetobj.Remark = TempTransferSerial.Str_Remark;
                                                AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                                AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                                                //AssetHomeObj.Assetobj.TypeID = Funciton_TransferType();
                                                AssetHomeObj.Assetobj.TypeID = TempAsset.TypeID;
                                                AssetHomeObj.Assetobj.CreatedDate = TempAsset.CreatedDate;
                                                AssetHomeObj.Assetobj.VendorID = TempAsset.VendorID;
                                                AssetHomeObj.Assetobj.WarrantyEndDate = TempAsset.WarrantyEndDate;
                                                AssetHomeObj.Assetobj.WarrantyStartDate = TempAsset.WarrantyStartDate;
                                                Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);
                                                if (Funciton_TransferType() == "WRT")
                                                    AssetHomeObj.Assetobj.StatusID = "CLOSE";
                                                else
                                                    AssetHomeObj.Assetobj.StatusID = TempAsset.StatusID;
                                                Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                                                AssetHomeObj.Assetobj.ReasonCode = TempAsset.ReasonCode;
                                                AssetHomeObj.Assetobj.Price = TempAsset.Price;
                                                AssetHomeObj.Assetobj.FacCode = TempAsset.FacCode;
                                                AssetHomeObj.Assetobj.Customfiled1 = TempAsset.Customfiled1;
                                                AssetHomeObj.Assetobj.Customfiled2 = TempAsset.Customfiled2;
                                                AssetHomeObj.Assetobj.Customfiled3 = TempAsset.Customfiled3;
                                                AssetHomeObj.Assetobj.Customfiled4 = TempAsset.Customfiled4;
                                                AssetHomeObj.Assetobj.Customfiled5 = TempAsset.Customfiled5;
                                                AssetHomeObj.Assetobj.Customfiled6 = TempAsset.Customfiled6;
                                                AssetHomeObj.Assetobj.Customfiled7 = TempAsset.Customfiled7;
                                                AssetHomeObj.Assetobj.Customfiled8 = TempAsset.Customfiled8;
                                                AssetHomeObj.Assetobj.Customfiled9 = TempAsset.Customfiled9;
                                                AssetHomeObj.Assetobj.Customfiled10 = TempAsset.Customfiled10;
                                                AssetHomeObj.Assetobj.Customfiled11 = TempAsset.Customfiled11;

                                                if (AssetHomeObj.EditAsset(ORTransaction))
                                                    Bool_CheckExecuteComplete = true;
                                                else
                                                    Bool_CheckExecuteComplete = false;
                                            }

                                            else
                                            {
                                                SS_MyMessageBox.ShowBox("Can not update asset : Assetno not found", "Error", DialogMode.OkOnly);
                                                goto ERROR;
                                            }
                                            Manager.Engine.EndTracking(AssetHomeObj.Assetobj);

                                        }
                                    }
                                }

                                //}

                            }
                            if (Bool_CheckExecuteComplete)
                            {
                                ORTransaction.Commit();
                                SS_MyMessageBox.ShowBox("Receive data : " + sS_MaskedTextBox_TransferNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_TransferID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = true;
                                string Str_TempTransferID = sS_MaskedTextBox_TransferNo.Text;
                                Function_ClearData();
                                sS_MaskedTextBox_TransferNo.Text = Str_TempTransferID;
                                AssetDetailTransferList.Clear();
                                Function_ExecuteTransaction(Enum_Mode.ShowData);
                            }
                            else
                            {
                                goto ERROR;
                            }
                        //}
                           break;
                    case Enum_Mode.ShowData://
                        Manager.Engine.ClearTracking();

                        AssetTransferHomeObj.AssetTransferHDObj = Manager.Engine.GetObject<AssetTransferHD>(sS_MaskedTextBox_TransferNo.Text);

                        sS_MaskedTextBox_TransferNo.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferID;
                        //sS_MaskedTextBox_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        dateTimePicker_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        sS_ComboBox_Type.SelectedIndex = Function_GetTypeIndex(AssetTransferHomeObj.AssetTransferHDObj.TransferType);
                        sS_MaskedTextBox_FromDept.Text = AssetTransferHomeObj.AssetTransferHDObj.FromDeptID;
                        sS_MaskedTextBox_FromDeptName.Text = Global.FormOrder.Function_GetDeptName(AssetTransferHomeObj.AssetTransferHDObj.FromDeptID);
                        sS_MaskedTextBox_ToDept.Text = AssetTransferHomeObj.AssetTransferHDObj.ToDeptID;
                        sS_MaskedTextBox_ToDeptName.Text = Global.FormOrder.Function_GetDeptName(AssetTransferHomeObj.AssetTransferHDObj.ToDeptID);
                        sS_MaskedTextBox_Remark.Text = AssetTransferHomeObj.AssetTransferHDObj.Remark;
                        sS_MaskedTextBox_FromFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.FromFacCode;
                        sS_MaskedTextBox_FromFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.ToFacCode);

                        sS_DataGridView_AssetTransferDT.Rows.Clear();
                        sS_DataGridView_AssetTransferSerial.Rows.Clear();
                        AssetDetailTransferList.Clear();

                        for (i = 0; i <= AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs.Count - 1; i++)
                        {
                            AssetTransferHomeObj.AssetTransferDTObj = (AssetTransferDT)AssetTransferHomeObj.AssetTransferHDObj.AssetTransferDTs[i];

                            if (AssetTransferHomeObj.AssetTransferHDObj.AssetTransfers.Count != 0)
                            {
                                for (j = 0; j <= AssetTransferHomeObj.AssetTransferHDObj.AssetTransfers.Count - 1; j++)
                                {

                                    AssetTransfer TempAssetTransfer = (AssetTransfer)AssetTransferHomeObj.AssetTransferHDObj.AssetTransfers[j];

                                    if ((TempAssetTransfer.TransferID == AssetTransferHomeObj.AssetTransferDTObj.TransferID) &&
                                        (TempAssetTransfer.TransferSeq == AssetTransferHomeObj.AssetTransferDTObj.TransferSeq) &&
                                        (TempAssetTransfer.ModelID == AssetTransferHomeObj.AssetTransferDTObj.ModelID))
                                    {
                                        AssetTransferHomeObj.AssetTransferObj = TempAssetTransfer;
                                        break;
                                    }
                                }
                                    int Int_Loop = 0;
                                    DetailTransfer TempDetailTransfer = new DetailTransfer();
                                    TempDetailTransfer.Arry_DetailTransfer = new System.Collections.ArrayList();

                                    TempDetailTransfer.Int_TransferSeq = AssetTransferHomeObj.AssetTransferObj.TransferSeq;
                                    TempDetailTransfer.Str_ModelID = AssetTransferHomeObj.AssetTransferObj.ModelID;


                                    ////string Str_SQLTransferSerial = "TransferID ='" + AssetTransferHomeObj.AssetTransferObj.TransferID+
                                    //                         "' AND TransferSeq ='" + AssetTransferHomeObj.AssetTransferObj.TransferSeq +
                                    //                         "' AND modelID ='" + AssetTransferHomeObj.AssetTransferObj.ModelID + "'";

                                    string Str_SQLQuery = "SELECT AssetTransferSerial.TransferID, AssetTransferSerial.modelID, AssetTransferSerial.TransferLine, AssetTransferSerial.TransferSeq, Asset.AssetID, Asset.AssetName, " +
                                                          "AssetTransferSerial.SerialID, AssetTransferSerial.FromFloor, AssetTransferSerial.floorID, AssetTransferSerial.FromBuildID, " +
                                                          "AssetTransferSerial.BuildID, AssetTransferSerial.FromArea, AssetTransferSerial.areaID, AssetTransferSerial.PreviousCustodian, " +
                                                          "AssetTransferSerial.CustodianID, AssetTransferSerial.Remark " +
                                                          "FROM AssetTransferSerial INNER JOIN Asset ON AssetTransferSerial.AssetID = Asset.AssetID " +
                                                          "WHERE (AssetTransferSerial.TransferID = '" + AssetTransferHomeObj.AssetTransferObj.TransferID +
                                                          "') AND (AssetTransferSerial.modelID = '" + AssetTransferHomeObj.AssetTransferObj.ModelID +
                                                          "') AND (AssetTransferSerial.TransferSeq = '" + AssetTransferHomeObj.AssetTransferObj.TransferSeq +"')" +
                                                          "ORDER BY AssetTransferSerial.TransferLine";

                                    DataSet DS = new DataSet();
                                    DS = Manager.Engine.GetDataSet(Str_SQLQuery);
                                    
                                    //ObjectSet<AssetTransferSerial> TempAssetTransferSerial = Manager.Engine.GetObjectSet<AssetTransferSerial>(Str_SQLTransferSerial);

                                    for (Int_Loop = 0; Int_Loop <= DS.Tables[0].Rows.Count - 1; Int_Loop++)
                                    {
                                        TransferSerial TempTransferSerial = new TransferSerial();
                                        TempTransferSerial.Int_TransferSeq = Convert.ToInt32(DS.Tables[0].Rows[Int_Loop]["TransferSeq"]);
                                        //TempTransferSerial.Int_TransferSeq = Convert.ToInt32(DS.Tables[0].Rows[Int_Loop]["TransferLine"]);
                                        TempTransferSerial.Str_AssetNo = DS.Tables[0].Rows[Int_Loop]["AssetID"].ToString();
                                        TempTransferSerial.Str_AssetName = DS.Tables[0].Rows[Int_Loop]["AssetName"].ToString();
                                        TempTransferSerial.Str_SerialNo = Global.FormOrder.Function_GetAssetSerial(TempTransferSerial.Str_AssetNo);
                                        TempTransferSerial.Str_FromBuilding = DS.Tables[0].Rows[Int_Loop]["FromBuildID"].ToString();
                                        TempTransferSerial.Str_ToBuilding = DS.Tables[0].Rows[Int_Loop]["BuildID"].ToString();
                                        TempTransferSerial.Str_FromFloor = DS.Tables[0].Rows[Int_Loop]["FromFloor"].ToString();
                                        TempTransferSerial.Str_ToFloor = DS.Tables[0].Rows[Int_Loop]["floorID"].ToString();
                                        TempTransferSerial.Str_FromArea = DS.Tables[0].Rows[Int_Loop]["FromArea"].ToString();
                                        TempTransferSerial.Str_ToArea = DS.Tables[0].Rows[Int_Loop]["areaID"].ToString();
                                        TempTransferSerial.Str_FromCustodian = DS.Tables[0].Rows[Int_Loop]["PreviousCustodian"].ToString();
                                        TempTransferSerial.Str_ToCustodian = DS.Tables[0].Rows[Int_Loop]["CustodianID"].ToString();
                                        //TempTransferSerial.Str_SerialNo = DS.Tables[0].Rows[Int_Loop]["SerialID"].ToString();
                                        TempTransferSerial.Str_Remark = DS.Tables[0].Rows[Int_Loop]["Remark"].ToString();
                                        TempTransferSerial.Bool_NewStatus = true;
                                        //TempTransferSerial.Bool_NewStatus = false;

                                        TempDetailTransfer.Arry_DetailTransfer.Add(TempTransferSerial);
                                    }

                                    AssetDetailTransferList.Add(AssetTransferHomeObj.AssetTransferObj.TransferSeq, TempDetailTransfer);
                                  
                               
                            }
                            Object[] Rows = new Object[] { AssetTransferHomeObj.AssetTransferDTObj.TransferSeq,
                                AssetTransferHomeObj.AssetTransferDTObj.ModelID, 
                                Global.FormOrder.Function_GetModelName(AssetTransferHomeObj.AssetTransferDTObj.ModelID), 
                                AssetTransferHomeObj.AssetTransferDTObj.OrderQty,
                                AssetTransferHomeObj.AssetTransferDTObj.TransferQty,
                                AssetTransferHomeObj.AssetTransferDTObj.TransferPrice,
                            AssetTransferHomeObj.AssetTransferDTObj.TransferCost,
                            AssetTransferHomeObj.AssetTransferDTObj.Remark};

                            sS_DataGridView_AssetTransferDT.Rows.Add(Rows);
                            sS_DataGridView_AssetTransferDT.Sort(sS_DataGridView_AssetTransferDT.Columns[0], ListSortDirection.Ascending);
                        }
                        Global.Function_ToolStripSetUP(Enum_Mode.PreEdit);

                        Function_InsertTransferSerialToDataGrid();
                        Function_SetReadOnlyControl(true);
                        sS_DataGridView_AssetTransferSerial.Columns[1].ReadOnly = false;
                        Function_SetReadOnlyColumnDatagrid();
                        sS_DataGridView_AssetTransferSerial.ReadOnly = false;
                        break;
                    case Enum_Mode.Cancel:
                        if (Global.ConfigForm.Enum_FlagTransaction == Enum_Mode.SaveOnly)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_DataGridView_AssetTransferSerial.Columns[1].ReadOnly = false;
                            sS_MaskedTextBox_TransferNo.Focus();
                        }
                        else
                            goto DEFAULT;
                        break;
                        //goto DEFAULT;

                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_TransferNo.ReadOnly = false;
                        sS_MaskedTextBox_TransferNo.Focus();
                        break;
                    ERROR:
                        SS_MyMessageBox.ShowBox("Can not Internal Transfer Data", "Information", DialogMode.OkOnly);
                        Global.Bool_CheckComplete = false;
                        ORTransaction.Rollback();
                        break;
                }

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private bool Function_CheckNewReceive()
        {
            int i = 0;
            bool Bool_ReturnValue = false;
            for (i = 0; i <= sS_DataGridView_AssetTransferDT.Rows.Count - 1; i++)
            {
                if (Convert.ToInt32(sS_DataGridView_AssetTransferDT[4, i].Value) != 0)
                    Bool_ReturnValue = true;
                else
                {
                    Bool_ReturnValue = false;
                    break;
                }
            }

            return Bool_ReturnValue;
        }
        private bool Function_CheckTrasferClose()
        {
            int i = 0;
            int Int_TempQty = 0;
            int Int_TempReceive = 0;
            bool Bool_ReturnValue = false;

            for (i = 0; i <= sS_DataGridView_AssetTransferDT.Rows.Count - 1; i++)
            {
                Int_TempQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[3, i].Value);
                Int_TempReceive = Convert.ToInt32(sS_DataGridView_AssetTransferDT[4, i].Value);
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
        private string Funciton_TransferType()
        {
            string Str_TempTransferType = "";
            //switch (sS_ComboBox_Type.SelectedIndex)
            //{
            //    case 0:
            //        Str_TempTransferType = "TRN";
            //        break;
            //    //case 1:
            //    //    Str_TempTransferType = "OUT";
            //    //    break;
            //}

           Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_Type.SelectedItem)).Row.ItemArray[0].ToString();
          // Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_Type.SelectedItem)).Row.ItemArray[1].ToString();
            return Str_TempTransferType;
        }

        private int Function_GetTypeIndex(string Str_TempTransferType)
        {
            for (int i = 0; i < sS_ComboBox_Type.Items.Count; i++)
            {
                string tmp = ((System.Data.DataRowView)sS_ComboBox_Type.Items[i]).Row.ItemArray[0].ToString();
                if (Str_TempTransferType == tmp)
                    return i;
            }

            return 0;
        }

        private void Function_InsertTransferSerialToHashTable()
        {
            int i = 0, j=0;

            DetailTransfer TempDetailTransfer = new DetailTransfer();

            if (sS_DataGridView_AssetTransferSerial.Rows.Count != 1)
            {
                if (AssetDetailTransferList.ContainsKey(Int_TransferSeq))
                {
                    TempDetailTransfer = (DetailTransfer)AssetDetailTransferList[Int_TransferSeq];

                    for (i = 0; i < sS_DataGridView_AssetTransferSerial.Rows.Count - 1; i++)
                    {
                        TransferSerial TempTransferSerial = new TransferSerial();
                        TempTransferSerial.Int_TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferSerial[0, i].Value);
                        TempTransferSerial.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetTransferSerial[1, i].Value);
                        TempTransferSerial.Str_AssetName = Convert.ToString(sS_DataGridView_AssetTransferSerial[2, i].Value);
                        TempTransferSerial.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetTransferSerial[3, i].Value);
                        TempTransferSerial.Str_FromBuilding = Convert.ToString(sS_DataGridView_AssetTransferSerial[4, i].Value);
                        TempTransferSerial.Str_ToBuilding = Convert.ToString(sS_DataGridView_AssetTransferSerial[5, i].Value);
                        TempTransferSerial.Str_FromFloor = Convert.ToString(sS_DataGridView_AssetTransferSerial[6, i].Value);
                        TempTransferSerial.Str_ToFloor = Convert.ToString(sS_DataGridView_AssetTransferSerial[7, i].Value);
                        TempTransferSerial.Str_FromArea = Convert.ToString(sS_DataGridView_AssetTransferSerial[8, i].Value);
                        TempTransferSerial.Str_ToArea = Convert.ToString(sS_DataGridView_AssetTransferSerial[9, i].Value);
                        TempTransferSerial.Str_FromCustodian = Convert.ToString(sS_DataGridView_AssetTransferSerial[10, i].Value);
                        TempTransferSerial.Str_ToCustodian = Convert.ToString(sS_DataGridView_AssetTransferSerial[11, i].Value);
                        TempTransferSerial.Str_Remark = Convert.ToString(sS_DataGridView_AssetTransferSerial[12, i].Value);
                                                


                        if (TempDetailTransfer.Arry_DetailTransfer.Contains(TempTransferSerial) == false)
                        {
                            TempTransferSerial.Bool_NewStatus = true;
                            if (TempDetailTransfer.Arry_DetailTransfer.Contains(TempTransferSerial) == false)
                            {
                                for (j = 0; j < TempDetailTransfer.Arry_DetailTransfer.Count; j++)
                                {
                                    TransferSerial ArrTransferSerial = new TransferSerial();
                                    ArrTransferSerial = (TransferSerial)TempDetailTransfer.Arry_DetailTransfer[j];

                                    if (ArrTransferSerial.Int_TransferSeq == Convert.ToInt32(sS_DataGridView_AssetTransferSerial[0, i].Value) &&
                                        ArrTransferSerial.Str_AssetNo == Convert.ToString(sS_DataGridView_AssetTransferSerial[1, i].Value))
                                    {
                                        TempDetailTransfer.Arry_DetailTransfer.RemoveAt(j);
                                        break;
                                    }
                                }
                                TempDetailTransfer.Arry_DetailTransfer.Add(TempTransferSerial);
                            }
                        }
                    }

                    AssetDetailTransferList.Remove(Int_TransferSeq);
                    AssetDetailTransferList.Add(Int_TransferSeq, TempDetailTransfer);
                }
                else
                {
                    TempDetailTransfer.Arry_DetailTransfer = new System.Collections.ArrayList();

                    TempDetailTransfer.Int_TransferSeq = Int_TransferSeq;
                    TempDetailTransfer.Str_ModelID= Str_ModelID;

                    for (i = 0; i < sS_DataGridView_AssetTransferSerial.Rows.Count - 1; i++)
                    {
                        TransferSerial TempTransferSerial = new TransferSerial();
                        TempTransferSerial.Int_TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferSerial[0, i].Value);
                        TempTransferSerial.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetTransferSerial[1, i].Value);
                        TempTransferSerial.Str_AssetName = Convert.ToString(sS_DataGridView_AssetTransferSerial[2, i].Value);
                        TempTransferSerial.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetTransferSerial[3, i].Value);
                        TempTransferSerial.Str_FromBuilding = Convert.ToString(sS_DataGridView_AssetTransferSerial[4, i].Value);
                        TempTransferSerial.Str_ToBuilding = Convert.ToString(sS_DataGridView_AssetTransferSerial[5, i].Value);
                        TempTransferSerial.Str_FromFloor = Convert.ToString(sS_DataGridView_AssetTransferSerial[6, i].Value);
                        TempTransferSerial.Str_ToFloor = Convert.ToString(sS_DataGridView_AssetTransferSerial[7, i].Value);
                        TempTransferSerial.Str_FromArea = Convert.ToString(sS_DataGridView_AssetTransferSerial[8, i].Value);
                        TempTransferSerial.Str_ToArea = Convert.ToString(sS_DataGridView_AssetTransferSerial[9, i].Value);
                        TempTransferSerial.Str_FromCustodian = Convert.ToString(sS_DataGridView_AssetTransferSerial[10, i].Value);
                        TempTransferSerial.Str_ToCustodian = Convert.ToString(sS_DataGridView_AssetTransferSerial[11, i].Value);
                        TempTransferSerial.Str_Remark = Convert.ToString(sS_DataGridView_AssetTransferSerial[12, i].Value);
                        TempTransferSerial.Bool_NewStatus = true;
                        TempDetailTransfer.Arry_DetailTransfer.Add(TempTransferSerial);
                    }

                    AssetDetailTransferList.Add(Int_TransferSeq, TempDetailTransfer);
                }
            }
        }
        private void Function_InsertTransferSerialToDataGrid()
        {
            if (AssetDetailTransferList.ContainsKey(Int_TransferSeq))
            {
                int i = 0;
                DetailTransfer TempDetailTransfer = new DetailTransfer();
                sS_DataGridView_AssetTransferSerial.Rows.Clear();

                TempDetailTransfer = (DetailTransfer)AssetDetailTransferList[Int_TransferSeq];
                for (i = 0; i <= TempDetailTransfer.Arry_DetailTransfer.Count - 1; i++)
                {
                    TransferSerial TempTransferSerial = new TransferSerial();
                    TempTransferSerial = (TransferSerial)TempDetailTransfer.Arry_DetailTransfer[i];

                    Object[] Rows = new Object[] { TempTransferSerial.Int_TransferSeq,TempTransferSerial.Str_AssetNo,
                                                   TempTransferSerial.Str_AssetName,TempTransferSerial.Str_SerialNo,
                                                   TempTransferSerial.Str_FromBuilding,TempTransferSerial.Str_ToBuilding,
                                                   TempTransferSerial.Str_FromFloor,TempTransferSerial.Str_ToFloor,
                                                   TempTransferSerial.Str_FromArea,TempTransferSerial.Str_ToArea,
                                                   TempTransferSerial.Str_FromCustodian,TempTransferSerial.Str_ToCustodian,
                                                   TempTransferSerial.Str_Remark };

                    sS_DataGridView_AssetTransferSerial.Rows.Add(Rows);
                }
            }
            else
                sS_DataGridView_AssetTransferSerial.Rows.Clear();
        }
        private bool Function_CheckCellGridValue()
        {
            for (int k = 0; k <= sS_DataGridView_AssetTransferSerial.Rows.Count ; k++)
            {
                for (int j = 0; j <= sS_DataGridView_AssetTransferSerial.Columns.Count - 1; j++)
                {
                    if (sS_DataGridView_AssetTransferSerial.Rows[k].Cells[j].Value == null)
                    {
                        SS_MyMessageBox.ShowBox(sS_DataGridView_AssetTransferSerial.Columns[j].HeaderText.ToString() + "  is empty", "Warning", DialogMode.OkOnly);
                        sS_DataGridView_AssetTransferSerial.Rows[k].Cells[j].Selected = true;
                        return false;
                    }
                }
            }
            return true;
        }
        private void sS_MaskedTextBox_TransferNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    //Global.Function_ShowFormSearchOrder();
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.InTransfer);

                    sS_MaskedTextBox_TransferNo.Text = Global.ReturnValue.Str_FormSearch;
                    if (Global.ReturnValue.Str_FormSearch != "")
                    {
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        
                        //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                    }
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_DataGridView_AssetTransferDT_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Str_ModelID = sS_DataGridView_AssetTransferDT[1, e.RowIndex].Value.ToString();
            Int_Qty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[3, e.RowIndex].Value);
            Int_TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, e.RowIndex].Value);
            
            Function_InsertTransferSerialToDataGrid();

        }

        private void sS_DataGridView_AssetTransferSerial_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferNo.Text };
            if (e.ColumnIndex == 12)
            {
                //int Int_TempSumTransferQty = sS_DataGridView_AssetTransferSerial.Rows.Count-1;
                int Int_TempSumTransferQty = 0;
                for (int i = 0; i < sS_DataGridView_AssetTransferSerial.Rows.Count - 1; i++)
                {
                    string ToArea = sS_DataGridView_AssetTransferSerial[9, i].Value.ToString();
                    if (ToArea.Trim() != "")
                    {
                        Int_TempSumTransferQty++;
                    }
                }

                Str_DeptID = sS_MaskedTextBox_FromDept.Text;
                if (Int_TempSumTransferQty <= Int_Qty)
                {
                    sS_DataGridView_AssetTransferSerial[0, e.RowIndex].Value = Int_TransferSeq;
                    sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = Int_TempSumTransferQty;
                    //if ((e.ColumnIndex != 5) && (e.ColumnIndex != 7) && (e.ColumnIndex != 9) && (e.ColumnIndex != 11) && (e.ColumnIndex != 12))
                    //{
                    //    Global.FormOrder.Function_ShowFormSearchnew(Enum_TypeSearch.TransferSerial, Str_ModelID,Str_DeptID);

                    //    sS_DataGridView_AssetTransferSerial[1, e.RowIndex].Value = Global.ReturnValue.Str_AssetNo;
                    //    sS_DataGridView_AssetTransferSerial[2, e.RowIndex].Value = Global.ReturnValue.Str_AssetName;
                    //    sS_DataGridView_AssetTransferSerial[3, e.RowIndex].Value = Global.ReturnValue.Str_SerialNo;
                    //    sS_DataGridView_AssetTransferSerial[4, e.RowIndex].Value = Global.ReturnValue.Str_BuildID;
                    //    sS_DataGridView_AssetTransferSerial[6, e.RowIndex].Value = Global.ReturnValue.Str_FloorID;
                    //    sS_DataGridView_AssetTransferSerial[8, e.RowIndex].Value = Global.ReturnValue.Str_AreaID;
                    //    sS_DataGridView_AssetTransferSerial[10, e.RowIndex].Value = Global.ReturnValue.Str_CustodianID;


                       
                    //    sS_DataGridView_AssetTransferSerial.CurrentCell = sS_DataGridView_AssetTransferSerial[1, sS_DataGridView_AssetTransferSerial.CurrentRow.Index];
                    //    Function_ReadOnlyColumnDatagridSubDT(true);
                    //    sS_DataGridView_AssetTransferSerial.CurrentCell = sS_DataGridView_AssetTransferSerial[0, sS_DataGridView_AssetTransferSerial.CurrentRow.Index];
                        
                    //}
           
                }
                else
                {
                    SS_MyMessageBox.ShowBox("TransferQuantity more than Quantity" , "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                }

                
            }
            
         }

        private void Form_001004_InternalTransfer_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            dateTimePicker_Date.Enabled = false;
            sS_ComboBox_Type.Enabled = false;
            sS_DataGridView_AssetTransferSerial.ReadOnly = true;
        }

        private void sS_DataGridView_AssetTransferSerial_Leave(object sender, EventArgs e)
        {
            Function_InsertTransferSerialToHashTable();
        }

        private void sS_DataGridView_AssetTransferSerial_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int Int_TempTransferQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[4,sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value);

            sS_DataGridView_AssetTransferDT[4,sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value =Int_TempTransferQty - 1;
        }

        private void sS_MaskedTextBox_FromDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FromDept;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FromDeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_MaskedTextBox_ToDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ToDept;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ToDeptName;
                Frm_Present.Show_Data("Screen", "002010");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_AssetTransferSerial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
            TextBox TempTextBox = new TextBox();

            if (e.ColumnIndex == 4 || e.ColumnIndex == 5) // Building
            {

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetTransferSerial[e.ColumnIndex, sS_DataGridView_AssetTransferSerial.CurrentRow.Index].Value = TempTextBox.Text;

                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 6 || e.ColumnIndex == 7) // Floor
            {
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 2, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);
                         
                //Global.FormOrder.Function_ShowFormSearchFloor(Enum_TypeSearch.Floor, Str_BuildingID,Str_FacCode);
                //sS_DataGridView_AssetTransferSerial[e.ColumnIndex, e.RowIndex].Value = Global.ReturnValue.Str_FloorID;

                //Edit on 08-01-09
                Frm_Present.Controlreturnvalue = TempTextBox;


                string qry = "buildid = '" + Str_BuildingID + "' and FacCode = '" + Str_FacCode + "'";
                Frm_Present.Show_Data("Screen", "002009", qry);

                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[e.ColumnIndex, sS_DataGridView_AssetTransferSerial.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
                
            }
            if (e.ColumnIndex == 8 || e.ColumnIndex == 9) // Area
            {   // Edit on 08-01-09
                Frm_Present.Controlreturnvalue = TempTextBox;
                
                Str_FloorID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex-2, e.RowIndex].Value);
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex-4, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);

                string qry = "buildid = '" + Str_BuildingID + "' and floorid = '"
                            + Str_FloorID + "' and FacCode = '" + Str_FacCode + "' ";
                Frm_Present.Show_Data("Screen", "002007", qry);

                //Frm_Present.Show_Data("Screen", "002007");
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[e.ColumnIndex, sS_DataGridView_AssetTransferSerial.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();


                //Str_FloorID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex-2, e.RowIndex].Value);
                //Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex-4, e.RowIndex].Value);
                //Str_FacCode = sS_MaskedTextBox_FromFacCode.Text.ToString();
                //Global.FormOrder.Function_ShowFormSearchArea(Enum_TypeSearch.Area,Str_FloorID, Str_BuildingID, Str_FacCode);
                //sS_DataGridView_AssetTransferSerial[e.ColumnIndex, e.RowIndex].Value = Global.ReturnValue.Str_AreaID;

                object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferNo.Text };
                int Int_TempSumTransferQty = 0;
                for (int i = 0; i < sS_DataGridView_AssetTransferSerial.Rows.Count - 1; i++)
                {
                    string ToArea = sS_DataGridView_AssetTransferSerial[9, i].Value.ToString();
                    if (ToArea.Trim() != "")
                    {
                        Int_TempSumTransferQty++;
                    }
                }

                Str_DeptID = sS_MaskedTextBox_FromDept.Text;
                if (Int_TempSumTransferQty <= Int_Qty)
                {
                    sS_DataGridView_AssetTransferSerial[0, e.RowIndex].Value = Int_TransferSeq;
                    sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = Int_TempSumTransferQty;
                }
                else
                {
                    SS_MyMessageBox.ShowBox("TransferQuantity more than Quantity" , "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                }
            }

            if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
            {
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Show_Data("Screen", "002011");
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[e.ColumnIndex, sS_DataGridView_AssetTransferSerial.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
                
            }
        }

        private void Form_001004_InternalTransfer_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Global.ConfigForm.Enum_FlagTransaction);
        }
        private void Form_001004_InternalTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_DataGridView_AssetTransferSerial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sS_DataGridView_AssetTransferSerial_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        //private bool Function_CheckDataForSave()
        //{ 
        
        //}

      
    }
}