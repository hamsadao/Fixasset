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
    public partial class Form_001006_ExternalTransfer : SS_PaintGradientForm
    {
        DataView dtV_Type = new DataView();
        int Int_TransferSeq = 0;
        int Int_Qty = 0;
        string Str_ModelID = "";
        
        string Str_BuildingID = "";
        string Str_FloorID = "";
        string Str_FacCode = "";

        AssetTransferHome AssetTransferHomeObj = new AssetTransferHome();
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();

        struct DetailTransfer
        {
            public int Int_TransferSeq;
            public string Str_ModelID;
            public string Str_FacCode;
            public System.Collections.ArrayList Arry_DetailTransfer;
        }
        struct TransferSerial
        {
            public int Int_TransferSeq;
            public string Str_AssetNo;
            public string Str_AssetName;
            public string Str_SerialNo;
            public string Str_FromFloor;
            public string Str_ToFloor;
            public string Str_FromBuilding;
            public string Str_ToBuilding;
            public string Str_FromArea;
            public string Str_ToArea;
            public string Str_FromCustodian;
            public string Str_ToCustodian;
            public string Str_Remark;
            public bool Bool_NewStatus;
        }

        System.Collections.Hashtable AssetDetailTransferList = new System.Collections.Hashtable();
        public Form_001006_ExternalTransfer()
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
            this.Text = Global.Function_Language(this, this, "ID:001006(External Transfer)");
            LBL_TransferNo.Text = Global.Function_Language(this,LBL_TransferNo, "Transfer No:");
            LBL_Date.Text = Global.Function_Language(this, LBL_Date, "Date:");
            LBL_Type.Text = Global.Function_Language(this, LBL_Type, "Type:");
            LBL_FromFacility.Text = Global.Function_Language(this, LBL_FromFacility, "From Company:");
            LBL_ToFacility.Text = Global.Function_Language(this, LBL_ToFacility, "To Company:");
            LBL_Remark.Text = Global.Function_Language(this, LBL_Remark, "Remark:");

            // Get Type for Internal Transfer
            DataSet ds = (DataSet)Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Type>(" TypeGroup = 'EXTT'");
            dtV_Type = new DataView(ds.Tables[0]);
            sS_ComboBox_ExTransferType.DataSource = dtV_Type;
            sS_ComboBox_ExTransferType.ValueMember = "typeName";
            sS_ComboBox_ExTransferType.DisplayMember = "Name";
        }

        private void Form_001006_ExternalTransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                Wilson.ORMapper.Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                AssetHome AssetHomeObj = new AssetHome();
                object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_TransferNo.Text };
                int i = 0;
                int j = 0;

                switch (mode)
                {
                    case Enum_Mode.Search:

                        break;
                    case Enum_Mode.Edit:

                        Function_InsertTransferSerialToHashTable();
                        ORTransaction = Manager.Engine.BeginTransaction();
                        AssetTransferHomeObj.AssetTransferHDObj.TransferID = sS_MaskedTextBox_TransferNo.Text;
                        //AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(sS_MaskedTextBox_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.TransferDate = Convert.ToDateTime(dateTimePicker_Date.Text);
                        AssetTransferHomeObj.AssetTransferHDObj.TransferType = Funciton_TransferType();
                        AssetTransferHomeObj.AssetTransferHDObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.ToFacCode = sS_MaskedTextBox_ToFacCode.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.Remark = sS_MaskedTextBox_Remark.Text;
                        AssetTransferHomeObj.AssetTransferHDObj.UserName = Global.ConfigDatabase.Str_UserID;
                        AssetTransferHomeObj.AssetTransferHDObj.TransferFlag = "E";

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
                            AssetTransferHomeObj.AssetTransferObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                            AssetTransferHomeObj.AssetTransferObj.ToFacCode = sS_MaskedTextBox_ToFacCode.Text;


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
                                        AssetTransferHomeObj.AssetTransferSerialObj.TransferSeq = Convert.ToInt32(sS_DataGridView_AssetTransferDT[0, i].Value);
                                        AssetTransferHomeObj.AssetTransferSerialObj.AssetID = TempTransferSerial.Str_AssetNo;
                                        AssetTransferHomeObj.AssetTransferSerialObj.ModelID = TempDetailTransfer.Str_ModelID;
                                        AssetTransferHomeObj.AssetTransferSerialObj.BuildID = TempTransferSerial.Str_ToBuilding;
                                        AssetTransferHomeObj.AssetTransferSerialObj.FloorID = TempTransferSerial.Str_ToFloor;
                                        AssetTransferHomeObj.AssetTransferSerialObj.AreaID = TempTransferSerial.Str_ToArea;
                                        AssetTransferHomeObj.AssetTransferSerialObj.SerialID = TempTransferSerial.Str_SerialNo;
                                        AssetTransferHomeObj.AssetTransferSerialObj.ReceiveDate = DateTime.Now.Date;
                                        AssetTransferHomeObj.AssetTransferSerialObj.UserName = Global.ConfigDatabase.Str_UserID;
                                        AssetTransferHomeObj.AssetTransferSerialObj.FromFacCode = sS_MaskedTextBox_FromFacCode.Text;
                                        AssetTransferHomeObj.AssetTransferSerialObj.ToFacCode = sS_MaskedTextBox_ToFacCode.Text;
                                        AssetTransferHomeObj.AssetTransferSerialObj.Remark = TempTransferSerial.Str_Remark;

                                        //if (AssetTransferHomeObj.AddTransferSerial(ORTransaction))
                                        //    Bool_CheckExecuteComplete = true;
                                        //else
                                        //    goto ERROR;

                                        string qry = "DELETE FROM AssetTransferSerial WHERE TransferID = '" + sS_MaskedTextBox_TransferNo.Text +
                                            "' AND TransferSeq = " + sS_DataGridView_AssetTransferDT[0, i].Value.ToString() + " AND ModelID = '" +
                                                TempDetailTransfer.Str_ModelID + "' AND AssetID = '" + TempTransferSerial.Str_AssetNo +
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
                                            AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_ToFacCode.Text;
                                            AssetHomeObj.Assetobj.SerialNo = TempTransferSerial.Str_SerialNo;
                                            AssetHomeObj.Assetobj.FloorID = TempTransferSerial.Str_ToFloor;
                                            AssetHomeObj.Assetobj.BuildID = TempTransferSerial.Str_ToBuilding;
                                            AssetHomeObj.Assetobj.AreaID = TempTransferSerial.Str_ToArea;
                                            AssetHomeObj.Assetobj.CustodianID = TempTransferSerial.Str_ToCustodian;
                                            AssetHomeObj.Assetobj.Remark = TempTransferSerial.Str_Remark;
                                            AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                            AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.CreatedDate = TempAsset.CreatedDate;
                                            AssetHomeObj.Assetobj.WarrantyEndDate = TempAsset.WarrantyEndDate;
                                            AssetHomeObj.Assetobj.WarrantyStartDate = TempAsset.WarrantyStartDate;
                                            AssetHomeObj.Assetobj.VendorID = TempAsset.VendorID;
                                            //AssetHomeObj.Assetobj.TypeID = Funciton_TransferType();
                                            AssetHomeObj.Assetobj.TypeID = TempAsset.TypeID;

                                            Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);
                                            AssetHomeObj.Assetobj.StatusID = "CLOSE";

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
                        }
                        if (Bool_CheckExecuteComplete)
                        {
                            ORTransaction.Commit();
                            SS_MyMessageBox.ShowBox("Receive data : " + sS_MaskedTextBox_TransferNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_TransferID, Global.Lang.Str_Language);
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
                        break;
                    case Enum_Mode.ShowData:
                        Manager.Engine.ClearTracking();

                        AssetTransferHomeObj.AssetTransferHDObj = Manager.Engine.GetObject<AssetTransferHD>(sS_MaskedTextBox_TransferNo.Text);

                        sS_MaskedTextBox_TransferNo.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferID;
                        //sS_MaskedTextBox_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        dateTimePicker_Date.Text = AssetTransferHomeObj.AssetTransferHDObj.TransferDate.ToShortDateString();
                        sS_ComboBox_ExTransferType.SelectedIndex = Function_GetTypeIndex(AssetTransferHomeObj.AssetTransferHDObj.TransferType);
                        sS_MaskedTextBox_FromFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.FromFacCode;
                        sS_MaskedTextBox_FromFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.FromFacCode);
                        sS_MaskedTextBox_ToFacCode.Text = AssetTransferHomeObj.AssetTransferHDObj.ToFacCode;
                        sS_MaskedTextBox_ToFacName.Text = Global.FormOrder.Function_GetFacName(AssetTransferHomeObj.AssetTransferHDObj.ToFacCode);
                        sS_MaskedTextBox_Remark.Text = AssetTransferHomeObj.AssetTransferHDObj.Remark;

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

                                string Str_SQLQuery = " SELECT AssetTransferSerial.TransferID, AssetTransferSerial.modelID, AssetTransferSerial.TransferSeq, AssetTransferSerial.TransferLine,AssetTransferSerial.AssetID, Asset.AssetName, " +
                                                        "Asset.SerialNo, AssetTransferSerial.buildID, AssetTransferSerial.floorID, AssetTransferSerial.areaID, AssetTransferSerial.ReceiveDate, AssetTransferSerial.FromFacCode, " +
                                                        "AssetTransferSerial.ToFacCode, AssetTransferSerial.Remark, Asset.FacCode, AssetTransferSerial.Fromfloor AS FromFloor, AssetTransferSerial.FrombuildID AS FromBuilding, " +
                                                        "AssetTransferSerial.FromArea AS FromArea, Asset.CustodianID, Asset.CustodianID AS FromCustodian " +
                                                        "FROM AssetTransferSerial INNER JOIN Asset ON AssetTransferSerial.AssetID = Asset.AssetID " +
                                                        "WHERE AssetTransferSerial.TransferID ='" + AssetTransferHomeObj.AssetTransferObj.TransferID +
                                                        "' AND AssetTransferSerial.TransferSeq ='" + AssetTransferHomeObj.AssetTransferObj.TransferSeq +
                                                         "' AND AssetTransferSerial.modelID ='" + AssetTransferHomeObj.AssetTransferObj.ModelID + "'";

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
                                    TempTransferSerial.Str_FromFloor = DS.Tables[0].Rows[Int_Loop]["FromFloor"].ToString();
                                    TempTransferSerial.Str_ToFloor = DS.Tables[0].Rows[Int_Loop]["floorID"].ToString();
                                    TempTransferSerial.Str_FromBuilding = DS.Tables[0].Rows[Int_Loop]["FromBuilding"].ToString();
                                    TempTransferSerial.Str_ToBuilding = DS.Tables[0].Rows[Int_Loop]["buildID"].ToString();
                                    TempTransferSerial.Str_FromArea = DS.Tables[0].Rows[Int_Loop]["FromArea"].ToString();
                                    TempTransferSerial.Str_ToArea = DS.Tables[0].Rows[Int_Loop]["areaID"].ToString();
                                    TempTransferSerial.Str_FromCustodian = DS.Tables[0].Rows[Int_Loop]["FromCustodian"].ToString();
                                    TempTransferSerial.Str_ToCustodian = DS.Tables[0].Rows[Int_Loop]["CustodianID"].ToString();
                                    TempTransferSerial.Str_SerialNo = DS.Tables[0].Rows[Int_Loop]["SerialNo"].ToString();
                                    TempTransferSerial.Str_Remark = DS.Tables[0].Rows[Int_Loop]["Remark"].ToString();
                                    TempTransferSerial.Bool_NewStatus = false;

                                    TempDetailTransfer.Arry_DetailTransfer.Add(TempTransferSerial);
                                }

                                AssetDetailTransferList.Add(AssetTransferHomeObj.AssetTransferObj.TransferSeq, TempDetailTransfer);


                            }
                            Object[] Rows = new Object[] { AssetTransferHomeObj.AssetTransferDTObj.TransferSeq,
                                AssetTransferHomeObj.AssetTransferDTObj.ModelID,Global.FormOrder.Function_GetModelName(AssetTransferHomeObj.AssetTransferDTObj.ModelID), 
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
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_TransferNo.ReadOnly = false;
                        sS_MaskedTextBox_TransferNo.Focus();
                        break;
                    ERROR:
                        SS_MyMessageBox.ShowBox("Can not External Transfer Data", "Information", DialogMode.OkOnly);
                        ORTransaction.Rollback();
                        break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_TransferNo.Text = "";
                sS_MaskedTextBox_FromFacCode.Text = "";
                sS_MaskedTextBox_FromFacName.Text = "";
                sS_MaskedTextBox_ToFacCode.Text = "";
                sS_MaskedTextBox_ToFacName.Text = "";
                sS_MaskedTextBox_Remark.Text = "";
                sS_ComboBox_ExTransferType.SelectedIndex = 0;
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
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_TransferNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromFacCode.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FromFacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToFacCode.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ToFacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;

        }
        public void Function_EnableConboBoxControl(bool Bool_StateControl)
        {
            dateTimePicker_Date.Enabled = Bool_StateControl;
            sS_ComboBox_ExTransferType.Enabled = Bool_StateControl;
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
        private string Funciton_TransferType()
        {
            string Str_TempTransferType = "";
            //switch (sS_ComboBox_ExTransferType.SelectedIndex)
            //{
            //    case 0:
            //        Str_TempTransferType = "TRN";
            //        break;
            //    //case 1:
            //    //    Str_TempTransferType = "OUT";
            //    //    break;
            //}

           Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_ExTransferType.SelectedItem)).Row.ItemArray[0].ToString();
          //  Str_TempTransferType = ((System.Data.DataRowView)(sS_ComboBox_ExTransferType.SelectedItem)).Row.ItemArray[1].ToString();
            
            return Str_TempTransferType;
        }
        private int Function_GetTypeIndex(string Str_TempTransferType)
        {
            for (int i = 0; i < sS_ComboBox_ExTransferType.Items.Count; i++)
            {
                string tmp = ((System.Data.DataRowView)sS_ComboBox_ExTransferType.Items[i]).Row.ItemArray[0].ToString();
                if (Str_TempTransferType == tmp)
                    return i;
            }

            return 0;
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
        private void Function_InsertTransferSerialToHashTable()
        {
            int i = 0, j = 0;

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
                            //if (TempDetailTransfer.Arry_DetailTransfer.Contains(TempTransferSerial) == false)
                            //    TempDetailTransfer.Arry_DetailTransfer.Add(TempTransferSerial);
                        }
                    }

                    AssetDetailTransferList.Remove(Int_TransferSeq);
                    AssetDetailTransferList.Add(Int_TransferSeq, TempDetailTransfer);
                }
                else
                {
                    TempDetailTransfer.Arry_DetailTransfer = new System.Collections.ArrayList();

                    TempDetailTransfer.Int_TransferSeq = Int_TransferSeq;
                    TempDetailTransfer.Str_ModelID = Str_ModelID;

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

        private void sS_MaskedTextBox_TransferNo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.ExTransfer);

                    sS_MaskedTextBox_TransferNo.Text = Global.ReturnValue.Str_FormSearch;
                    if (Global.ReturnValue.Str_FormSearch != "")
                    {
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
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
            if (e.ColumnIndex == 1)
            {
                int Int_TempSumTransferQty = sS_DataGridView_AssetTransferSerial.Rows.Count;
                if (Int_TempSumTransferQty <= Int_Qty)
                {
                    sS_DataGridView_AssetTransferSerial[0, e.RowIndex].Value = Int_TransferSeq;
                    sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = Int_TempSumTransferQty;
                    if ((e.ColumnIndex != 5) && (e.ColumnIndex != 7) && (e.ColumnIndex != 9) && (e.ColumnIndex != 11) && (e.ColumnIndex != 12))
                    {
                        Global.FormOrder.Function_ShowFormSearchType(Enum_TypeSearch.ExTransferSerial, Str_ModelID,sS_MaskedTextBox_FromFacCode.Text);

                        sS_DataGridView_AssetTransferSerial[1, e.RowIndex].Value = Global.ReturnValue.Str_AssetNo;
                        sS_DataGridView_AssetTransferSerial[2, e.RowIndex].Value = Global.ReturnValue.Str_AssetName;
                        sS_DataGridView_AssetTransferSerial[3, e.RowIndex].Value = Global.ReturnValue.Str_SerialNo;
                        sS_DataGridView_AssetTransferSerial[4, e.RowIndex].Value = Global.ReturnValue.Str_FloorID;
                        sS_DataGridView_AssetTransferSerial[6, e.RowIndex].Value = Global.ReturnValue.Str_BuildID;
                        sS_DataGridView_AssetTransferSerial[8, e.RowIndex].Value = Global.ReturnValue.Str_AreaID;

                        sS_DataGridView_AssetTransferSerial[10, e.RowIndex].Value = Global.ReturnValue.Str_CustodianID;
                    }
                }
                else
                {
                    SS_MyMessageBox.ShowBox("TransferQuantity more than Quantity", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                }

            }
        }
        private void sS_DataGridView_AssetTransferSerial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TextBox TempTextBox = new TextBox();
            if (e.ColumnIndex == 4) // Building
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[4, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();

            }
            if (e.ColumnIndex == 5) // Building
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[5, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();

            }
            if (e.ColumnIndex == 6) // Floor
            {
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 2, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);

                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                string qry = "buildid = '" + Str_BuildingID + "' and FacCode = '" + Str_FacCode + "'";
                Frm_Present.Show_Data("Screen", "002009", qry);

               
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[6, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 7) // Floor
            {
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 2, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);

                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                string qry = "buildid = '" + Str_BuildingID + "' and FacCode = '" + Str_FacCode + "'";
                Frm_Present.Show_Data("Screen", "002009", qry);

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[7, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 8) // Area
            {
                Str_FloorID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 2, e.RowIndex].Value);
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 4, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);

                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                string qry = "buildid = '" + Str_BuildingID + "' and floorid = '"
                            + Str_FloorID + "' and FacCode = '" + Str_FacCode + "' ";
                Frm_Present.Show_Data("Screen", "002007", qry);

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[8, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            if (e.ColumnIndex == 9) // Area
            {
                Str_FloorID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 2, e.RowIndex].Value);
                Str_BuildingID = Convert.ToString(sS_DataGridView_AssetTransferSerial[e.ColumnIndex - 4, e.RowIndex].Value);
                Str_FacCode = Convert.ToString(sS_MaskedTextBox_FromFacCode.Text);

                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                string qry = "buildid = '" + Str_BuildingID + "' and floorid = '"
                            + Str_FloorID + "' and FacCode = '" + Str_FacCode + "' ";
                Frm_Present.Show_Data("Screen", "002007", qry);

                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[9, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();

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

                if (Int_TempSumTransferQty <= Int_Qty)
                {
                    sS_DataGridView_AssetTransferSerial[0, e.RowIndex].Value = Int_TransferSeq;
                    sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = Int_TempSumTransferQty;
                }
                else
                {
                    SS_MyMessageBox.ShowBox("TransferQuantity more than Quantity", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                }
            }
            if (e.ColumnIndex == 11)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002011");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();
                sS_DataGridView_AssetTransferSerial[11, e.RowIndex].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
        }

        private void sS_DataGridView_AssetTransferSerial_Leave(object sender, EventArgs e)
        {
            Function_InsertTransferSerialToHashTable();
        }

        private void sS_DataGridView_AssetTransferSerial_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int Int_TempTransferQty = Convert.ToInt32(sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value);

            sS_DataGridView_AssetTransferDT[4, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = Int_TempTransferQty - 1;
        }

        private void sS_DataGridView_AssetTransferDT_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Show_Data("Screen", "002002");
                TextBox TempTextBox = new TextBox();
                TextBox TempTextBox2 = new TextBox();
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Controlreturnvalue2 = TempTextBox2;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetTransferDT[1, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = TempTextBox.Text;
                sS_DataGridView_AssetTransferDT[2, sS_DataGridView_AssetTransferDT.CurrentRow.Index].Value = TempTextBox2.Text;
                Frm_Present.Dispose();

                sS_DataGridView_AssetTransferDT.CurrentCell = sS_DataGridView_AssetTransferDT[3, sS_DataGridView_AssetTransferDT.CurrentRow.Index];
            }
        }

        private void Form_001006_ExternalTransfer_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_EnableConboBoxControl(false);
        }

        private void Form_001006_ExternalTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }
    }
}