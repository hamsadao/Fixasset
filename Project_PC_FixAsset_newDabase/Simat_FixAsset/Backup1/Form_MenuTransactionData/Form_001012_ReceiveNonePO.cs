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
    public partial class Form_001012_ReceiveNonePO : SS_PaintGradientForm
    {
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
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        System.Collections.Hashtable AssetReceiveList = new System.Collections.Hashtable();
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

        public Form_001012_ReceiveNonePO()
        {
            InitializeComponent();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
        }

        private void Form_001012_ReceiveNonePO_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            Function_SetReadOnlyControl(true);
            Function_SetControlEnable(false);
            dateTimePicker_ReceivePODate.Enabled = false;
            sS_MaskedTextBox_DOC.Focus();

        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                RunControlHome RunControlHomeObj = new RunControlHome();
                object[] Obj_PONo = new object[1] { sS_MaskedTextBox_PO.Text };
                int i = 0;
                int j = 0;
                switch (mode)
                {
                    case Enum_Mode.PreAdd:
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_DOC.ReadOnly = true;
                            Function_SetReadOnlyControl(true);
                            Function_SetControlEnable(true);
                            sS_DataGridView_ReceivePO.ReadOnly = false;
                            sS_MaskedTextBox_DOC.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand("PORun");
                            sS_MaskedTextBox_PO.Focus();
                            sS_MaskedTextBox_Remark.ReadOnly = false;
                            sS_MaskedTextBox_PO.ReadOnly = false;
                            //sS_MaskedTextBox_SupplierNo.Focus();
                            dateTimePicker_ReceivePODate.Enabled = true;
                            Enm_StateForm = Enum_Mode.PreAdd;
                            break;
                        }
                    case Enum_Mode.Add:
                
                        if (sS_DataGridView_ReceivePO.Rows.Count > 1)
                        {
                            string Str_WhereGetObjectHD = "POID ='" + sS_MaskedTextBox_DOC.Text + "'";

                            int IntCheckObjectHD = Manager.Engine.GetObjectCount<Pohd>(Str_WhereGetObjectHD);

                            ORTransaction = Manager.Engine.BeginTransaction();
                            POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_DOC.Text;
                            POHomeObj.Pohdobj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                            POHomeObj.Pohdobj.PODate = Convert.ToDateTime(dateTimePicker_ReceivePODate.Text);
                            POHomeObj.Pohdobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            POHomeObj.Pohdobj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                            POHomeObj.Pohdobj.Remark = sS_MaskedTextBox_Remark.Text;
                            POHomeObj.Pohdobj.FacCode = sS_MaskedTextBox_Facility.Text;
                            POHomeObj.Pohdobj.StatusID = "CLOSE";
                            POHomeObj.Pohdobj.Customfiled1 = Convert.ToString(sS_MaskedTextBox_PO.Text);

                            POHomeObj.Pohdobj.UserName = Global.ConfigDatabase.Str_UserID;

                            if (IntCheckObjectHD == 0)
                            {
                                if (POHomeObj.AddHD(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                {
                                    Bool_CheckExecuteComplete = false;
                                    break;
                                }
                            }


                            for (i = 0; i < sS_DataGridView_ReceivePO.Rows.Count - 1; i++)
                            {
                                string Str_WhereGetObjectDT = "POID ='" + sS_MaskedTextBox_DOC.Text + "'AND POSeq ='" +
                                Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value) + "' AND " +
                                " modelID = '" + sS_DataGridView_ReceivePO[1, i].Value.ToString() + "'";

                                int IntCheckObjectDT = Manager.Engine.GetObjectCount<Podt>(Str_WhereGetObjectDT);

                                POHomeObj.Podtobj.Poid = sS_MaskedTextBox_DOC.Text;
                                POHomeObj.Podtobj.POSeq = int.Parse(sS_DataGridView_ReceivePO[0, i].Value.ToString());
                                POHomeObj.Podtobj.ModelID = sS_DataGridView_ReceivePO[1, i].Value.ToString();
                                POHomeObj.Podtobj.POQty = Math.Abs(Convert.ToInt32(sS_DataGridView_ReceivePO[3, i].Value.ToString()));
                                POHomeObj.Podtobj.POPrice = Convert.ToDecimal(sS_DataGridView_ReceivePO[4, i].Value.ToString());
                                POHomeObj.Podtobj.POCost = Convert.ToDecimal(sS_DataGridView_ReceivePO[3, i].Value) * Convert.ToDecimal(sS_DataGridView_ReceivePO[4, i].Value);
                                POHomeObj.Podtobj.Remark = Convert.ToString(sS_DataGridView_ReceivePO[6, i].Value);
                                POHomeObj.Podtobj.ReceiveQty = 0;

                                if (IntCheckObjectDT == 0)
                                {
                                    if (POHomeObj.AddDT(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (POHomeObj.EditDT(ORTransaction))
                                        Bool_CheckExecuteComplete = true;
                                    else
                                    {
                                        Bool_CheckExecuteComplete = false;
                                        break;
                                    }
                                }

                                string Str_WhereGetObject = "POID ='" + sS_MaskedTextBox_DOC.Text + "'AND POSeq ='" +
                                Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value) + "' AND " +
                                " modelID = '" + sS_DataGridView_ReceivePO[1, i].Value.ToString() + "'";

                                int IntCheckObject = Manager.Engine.GetObjectCount<POReceive>(Str_WhereGetObject);

                                POHomeObj.POReceiveObj.Poid = sS_MaskedTextBox_DOC.Text;
                                POHomeObj.POReceiveObj.VendorID = sS_MaskedTextBox_SupplierNo.Text;
                                POHomeObj.POReceiveObj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                                POHomeObj.POReceiveObj.ModelID = sS_DataGridView_ReceivePO[1, i].Value.ToString();
                                POHomeObj.POReceiveObj.POSeq = int.Parse(sS_DataGridView_ReceivePO[0, i].Value.ToString());
                                POHomeObj.POReceiveObj.Qty = Convert.ToInt32(sS_DataGridView_ReceivePO[3, i].Value.ToString());
                                POHomeObj.POReceiveObj.POPrice = Convert.ToDecimal(sS_DataGridView_ReceivePO[4, i].Value.ToString());
                                POHomeObj.POReceiveObj.POCost = Convert.ToDecimal(sS_DataGridView_ReceivePO[3, i].Value) * Convert.ToDecimal(sS_DataGridView_ReceivePO[4, i].Value);
                                POHomeObj.POReceiveObj.Remark = Convert.ToString(sS_DataGridView_ReceivePO[6, i].Value);
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

                                for (j = 0; j <= sS_DataGridView_AssetReceive.Rows.Count - 1; j++)
                                {
                                    if (Convert.ToString(sS_DataGridView_AssetReceive[0, j].Value) != "")
                                    {
                                        if (sS_DataGridView_AssetReceive[2, j].Value.ToString() == sS_DataGridView_ReceivePO[1, i].Value.ToString())
                                        {
                                            AssetHomeObj.Assetobj.ID = sS_DataGridView_AssetReceive[0, j].Value.ToString();
                                            AssetHomeObj.Assetobj.Name = Convert.ToString(sS_DataGridView_AssetReceive[1, j].Value.ToString());
                                            AssetHomeObj.Assetobj.SerialNo = Convert.ToString(sS_DataGridView_AssetReceive[3, j].Value);
                                            AssetHomeObj.Assetobj.ModelID = Convert.ToString(sS_DataGridView_AssetReceive[2, j].Value.ToString());
                                            AssetHomeObj.Assetobj.DeptID = Convert.ToString(sS_MaskedTextBox_DepartmentNo.Text) ;
                                            AssetHomeObj.Assetobj.FloorID = Convert.ToString(sS_DataGridView_AssetReceive[4, j].Value.ToString());
                                            AssetHomeObj.Assetobj.BuildID = Convert.ToString(sS_DataGridView_AssetReceive[5, j].Value.ToString());
                                            AssetHomeObj.Assetobj.AreaID = Convert.ToString(sS_DataGridView_AssetReceive[6, j].Value.ToString());
                                            //AssetHomeObj.Assetobj.ReasonCode = "";
                                            AssetHomeObj.Assetobj.TypeID = Convert.ToString(sS_ComboBox_Type.SelectedItem.ToString());

                                            Class_CheckMaster.Function_CheckData.TB_Asset("Type", AssetHomeObj);
                                            //Function_CheckDataInMaster("Type");

                                            AssetHomeObj.Assetobj.StatusID = "NEW";
                                            Class_CheckMaster.Function_CheckData.TB_Asset("Status", AssetHomeObj);

                                            AssetHomeObj.Assetobj.VendorID = Convert.ToString(sS_MaskedTextBox_SupplierNo.Text);
                                            //AssetHomeObj.Assetobj.Price = decimal.Parse("");
                                            AssetHomeObj.Assetobj.WarrantyStartDate = DateTime.Parse(Convert.ToString(sS_DataGridView_AssetReceive[9, j].Value));
                                            AssetHomeObj.Assetobj.WarrantyEndDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.CustodianID = Convert.ToString(sS_DataGridView_AssetReceive[7, j].Value);
                                            //AssetHomeObj.Assetobj.PreviosCustodian = "";
                                            AssetHomeObj.Assetobj.CreatedDate = DateTime.Parse(Convert.ToString(sS_DataGridView_AssetReceive[10, j].Value));
                                            AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                            AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, j].Value);
                                            AssetHomeObj.Assetobj.FacCode = Convert.ToString(sS_MaskedTextBox_Facility.Text);
                                            AssetHomeObj.Assetobj.Customfiled1 = Convert.ToString(sS_MaskedTextBox_PO.Text);


                                            if (AssetHomeObj.AddAsset(ORTransaction))
                                            {
                                                Bool_CheckExecuteComplete = true;
                                            }
                                            else
                                                Bool_CheckExecuteComplete = false;


                                            POHomeObj.AssetReceiveObj.Poid = sS_MaskedTextBox_DOC.Text;
                                            POHomeObj.AssetReceiveObj.ModelID = Convert.ToString(sS_DataGridView_AssetReceive[2, j].Value);
                                            POHomeObj.AssetReceiveObj.POSeq = int.Parse(sS_DataGridView_ReceivePO[0, i].Value.ToString());
                                            POHomeObj.AssetReceiveObj.AssetID = sS_DataGridView_AssetReceive[0, j].Value.ToString();
                                            POHomeObj.AssetReceiveObj.SerialID = Convert.ToString(sS_DataGridView_AssetReceive[3, j].Value);
                                            POHomeObj.AssetReceiveObj.BuildID = Convert.ToString(sS_DataGridView_AssetReceive[5, j].Value);
                                            POHomeObj.AssetReceiveObj.FloorID = Convert.ToString(sS_DataGridView_AssetReceive[4, j].Value);
                                            POHomeObj.AssetReceiveObj.AreaID = Convert.ToString(sS_DataGridView_AssetReceive[6, j].Value);
                                            POHomeObj.AssetReceiveObj.CustodianID = Convert.ToString(sS_DataGridView_AssetReceive[7, j].Value);
                                            POHomeObj.AssetReceiveObj.ReceiveDate = DateTime.Now.Date;
                                            POHomeObj.AssetReceiveObj.UserName = Global.ConfigDatabase.Str_UserID;
                                            POHomeObj.AssetReceiveObj.Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, j].Value);
                                            POHomeObj.AssetReceiveObj.FacCode = Convert.ToString(sS_MaskedTextBox_Facility.Text);

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
                                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_DOC.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_PONo, Global.Lang.Str_Language);
                                RunControlHomeObj.SaveRunControlID("PORun", sS_MaskedTextBox_DOC.Text);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                //goto DEFAULT;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_DOC.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_PONo, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                ORTransaction.Rollback();
                            }
                        }
                        else
                        {
                            SS_MyMessageBox.ShowBox("Please input Model in cell grid", "Warning", DialogMode.OkOnly, this.Name, "000010", Global.Lang.Str_Language);
                            sS_DataGridView_ReceivePO.Focus();
                            break;
                        }
                        break;
                }

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        //private bool Function_InsertAssetReceiveToHashTable()
        //{
        //    int i = 0;

        //    Detail_Receive TempDetailReceive = new Detail_Receive();

        //    if (sS_DataGridView_AssetReceive.Rows.Count != 0)
        //    {
        //        if (AssetReceiveList.ContainsKey(Int_POSeq))
        //        {
        //            TempDetailReceive = (Detail_Receive)AssetReceiveList[Int_POSeq];
        //            for (i = 0; i <= sS_DataGridView_AssetReceive.Rows.Count - 1; i++)
        //            {
        //                Asset_Receive TempAssetReceive = new Asset_Receive();
        //                TempAssetReceive.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);

        //                if (TempAssetReceive.Str_AssetNo != "")
        //                {
        //                    TempAssetReceive.Str_AssetName = Convert.ToString(sS_DataGridView_AssetReceive[1, i].Value);
        //                    TempAssetReceive.Str_ModelID = sS_DataGridView_AssetReceive[2, i].Value.ToString();
        //                    TempAssetReceive.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetReceive[3, i].Value);
        //                    TempAssetReceive.Str_Floor = sS_DataGridView_AssetReceive[4, i].Value.ToString();
        //                    TempAssetReceive.Str_Building = sS_DataGridView_AssetReceive[5, i].Value.ToString();
        //                    TempAssetReceive.Str_Area = sS_DataGridView_AssetReceive[6, i].Value.ToString();
        //                    TempAssetReceive.Str_CustodianID = sS_DataGridView_AssetReceive[7, i].Value.ToString();
        //                    TempAssetReceive.Str_Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, i].Value);

        //                    if (TempDetailReceive.Arry_POReceive.Contains(TempAssetReceive) == false)
        //                    {
        //                        TempAssetReceive.Bool_NewStatus = true;

        //                        if (TempDetailReceive.Arry_POReceive.Contains(TempAssetReceive) == false)

        //                            TempDetailReceive.Arry_POReceive.Add(TempAssetReceive);
        //                    }
        //                }
        //            }
        //            AssetReceiveList.Remove(Int_POSeq);
        //            AssetReceiveList.Add(Int_POSeq, TempDetailReceive);
        //        }
        //        else
        //        {
        //            TempDetailReceive.Arry_POReceive = new System.Collections.ArrayList();
        //            TempDetailReceive.Int_POSeq = Int_POSeq;
        //            TempDetailReceive.Str_ModelID = Str_ModelID;


        //            for (i = 0; i <= sS_DataGridView_AssetReceive.Rows.Count - 1; i++)
        //            {
        //                Asset_Receive TempAssetReceive = new Asset_Receive();

        //                TempAssetReceive.Str_AssetNo = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);
        //                if ((TempAssetReceive.Str_AssetNo != ""))
        //                {
        //                    TempAssetReceive.Str_AssetName = Convert.ToString(sS_DataGridView_AssetReceive[1, i].Value);
        //                    TempAssetReceive.Str_ModelID = sS_DataGridView_AssetReceive[2, i].Value.ToString();
        //                    TempAssetReceive.Str_SerialNo = Convert.ToString(sS_DataGridView_AssetReceive[3, i].Value);
        //                    TempAssetReceive.Str_Floor = sS_DataGridView_AssetReceive[4, i].Value.ToString();
        //                    TempAssetReceive.Str_Building = sS_DataGridView_AssetReceive[5, i].Value.ToString();
        //                    TempAssetReceive.Str_Area = sS_DataGridView_AssetReceive[6, i].Value.ToString();
        //                    TempAssetReceive.Str_CustodianID = sS_DataGridView_AssetReceive[7, i].Value.ToString();
        //                    TempAssetReceive.Str_Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, i].Value);
        //                    TempAssetReceive.Bool_NewStatus = true;
        //                    TempDetailReceive.Arry_POReceive.Add(TempAssetReceive);
        //                }
        //          }

        //            AssetReceiveList.Add(Int_POSeq, TempDetailReceive);
        //        }
        //    }
        //    return true;
        //}

        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_DOC.Text = "";
                sS_MaskedTextBox_PO.Text = "";
                sS_MaskedTextBox_SupplierNo.Text = "";
                sS_MaskedTextBox_SupplierName.Text = "";
                sS_ComboBox_Type.SelectedIndex = 0;
                sS_MaskedTextBox_Remark.Text = "";
                sS_MaskedTextBox_Facility.Text = "";
                sS_DataGridView_AssetReceive.Rows.Clear();
                Function_SetReadOnlyControl(true);
                //AssetReceiveList.Clear();
                //QtyNewReceivePOReceive.Clear();
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Clear Data in Control", DialogMode.Error_Cancel, Ex);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_DOC.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_PO.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_SupplierName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Facility.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
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
        private void Function_SetControlEnable(bool Bool_StateControl)
        {
            sS_MaskedTextBox_PO.Enabled = Bool_StateControl;
            sS_MaskedTextBox_SupplierNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_Facility.Enabled = Bool_StateControl;
            sS_MaskedTextBox_Remark.Enabled = Bool_StateControl;
        }
        private void Form_001012_ReceiveNonePO_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_001012_ReceiveNonePO_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_SupplierNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
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
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
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
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_Facility;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                Frm_Present.Show_Data("Screen", "002006");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }

        private void Form_001012_ReceiveNonePO_Activated(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
        }

        private void sS_DataGridView_ReceivePO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sS_DataGridView_ReceivePO_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
            TextBox TempTextBox = new TextBox();
            TextBox TempTextBox2 = new TextBox();
            TextBox TempTextBox3 = new TextBox();
            if (e.ColumnIndex == 1)
            {
                Frm_Present.Show_Data("Screen", "002002");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.Controlreturnvalue2 = TempTextBox2;
                Frm_Present.Controlreturnvalue3 = TempTextBox3;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[1, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                sS_DataGridView_ReceivePO[2, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox2.Text;
                sS_DataGridView_ReceivePO[4, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox3.Text;
                Frm_Present.Dispose();

                sS_DataGridView_ReceivePO.CurrentCell = sS_DataGridView_ReceivePO[3, sS_DataGridView_ReceivePO.CurrentRow.Index];

            }
            if (e.ColumnIndex == 6)
            {
                Frm_Present.Show_Data("Screen", "002009");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[6, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 7)
            {
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[7, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 8)
            {
                Frm_Present.Show_Data("Screen", "002007");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_ReceivePO[8, sS_DataGridView_ReceivePO.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            //Function_ReadOnlyColumnDatagrid(true);
        }

        private void sS_DataGridView_ReceivePO_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Global.FormOrder.Function_MultiplyPriceAndQty(e, sS_DataGridView_ReceivePO);
        }

        private void sS_DataGridView_ReceivePO_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Global.FormOrder.Function_PlusLineInDataGrid(e, sS_DataGridView_ReceivePO, Enm_StateForm);
        }

        private void sS_ComboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sS_DataGridView_AssetReceive_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
      


        }

        private void sS_MaskedTextBox_PO_KeyDown(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    if (e.KeyCode == Keys.F1)
            //    {
            //        //Global.Function_ShowFormSearchOrder();
            //        Global.FormOrder.Function_ShowFormSearch(Enum_TypeSearch.PO);

            //        sS_MaskedTextBox_PO.Text = Global.ReturnValue.Str_FormSearch;
            //        if (Global.ReturnValue.Str_FormSearch != "")
            //        {
            //            Function_ExecuteTransaction(Enum_Mode.ShowData);

            //            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            //        }
            //    }
            //}
            //catch (Exception Ex)
            //{
            //    SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            //}
        }

        private void sS_DataGridView_AssetReceive_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
            TextBox TempTextBox = new TextBox();
            TextBox TempTextBox2 = new TextBox();
            TextBox TempTextBox3 = new TextBox();
            if (e.ColumnIndex == 2)
            {
                Frm_Present.Show_Data("Screen", "002002");
                Frm_Present.Controlreturnvalue = TempTextBox;
                //Frm_Present.Controlreturnvalue2 = TempTextBox2;
                //Frm_Present.Controlreturnvalue3 = TempTextBox3;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[2, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                //sS_DataGridView_AssetReceive[2, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox2.Text;
                //sS_DataGridView_AssetReceive[4, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox3.Text;
                Frm_Present.Dispose();

                //sS_DataGridView_AssetReceive.CurrentCell = sS_DataGridView_AssetReceive[3, sS_DataGridView_AssetReceive.CurrentRow.Index];

            }
            else if (e.ColumnIndex == 4)
            {
                Frm_Present.Show_Data("Screen", "002009");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[4, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 5)
            {
                Frm_Present.Show_Data("Screen", "002008");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[5, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 6)
            {
                Frm_Present.Show_Data("Screen", "002007");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[6, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }
            else if (e.ColumnIndex == 7)
            {
                Frm_Present.Show_Data("Screen", "002011");
                Frm_Present.Controlreturnvalue = TempTextBox;
                Frm_Present.ShowDialog();

                sS_DataGridView_AssetReceive[7, sS_DataGridView_AssetReceive.CurrentRow.Index].Value = TempTextBox.Text;
                Frm_Present.Dispose();
            }


        }

        private void sS_ButtonGlass_Generate_Click(object sender, EventArgs e)
        {
            if (sS_DataGridView_AssetReceive.Rows.Count > 0)
            {
                int i;
                for( i = 0 ;i < sS_DataGridView_AssetReceive.Rows.Count - 1;i++)
                {

                    string AssetNo, AssetName, Depart, Date;
                    AssetNo = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);
                    AssetName = Convert.ToString(sS_DataGridView_AssetReceive[0, i].Value);
                    Depart = Convert.ToString(sS_MaskedTextBox_DepartmentNo.Text);
                    Date = Convert.ToString(sS_DataGridView_AssetReceive[9, i].Value);

                    Form_005009_Barcode frm_new = new Form_005009_Barcode();
                    frm_new.Show();
                    frm_new.GetAsseforPrint(AssetNo, AssetName, Depart, Date);
                }

            }
        }

    }
}