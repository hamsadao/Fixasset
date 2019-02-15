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
    public partial class Form_001010_WriteOff : SS_PaintGradientForm
    {
        private int Int_CountObjDTs = 0;
        int Int_OldReceiveQtyValue = 0;
        int Int_POSeq = 0;
        string Str_ModelID = "";
        string Str_BuildID = "";
        string Str_FloorID = "";
        string Str_AreaID = "";
        int Int_Qty;
        int Int_TransferSeq;
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
        public Form_001010_WriteOff()
        {
            InitializeComponent();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_InitialControl();
        }

        private void Function_InitialControl()
        {
            DarkColor = Global.ConfigForm.Colr_BackColor;
            this.Text = Global.Function_Language(this, this, "ID:001010(WriteOff)");
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
                            sS_MaskedTextBox_PO.ReadOnly = true;
                            Function_SetReadOnlyControl(true);
                            Function_SetControlEnable(true);
                            sS_DataGridView_ReceivePO.ReadOnly = false;
                            sS_MaskedTextBox_PO.Text = RunControlHomeObj.Function_ExcuteGetrunningCommand("PORun");
                            sS_MaskedTextBox_PO.ReadOnly = true;
                            sS_MaskedTextBox_Remark.ReadOnly = false;
                            dateTimePicker_ReceivePODate.Enabled = true;
                            Enm_StateForm = Enum_Mode.PreAdd;
                            break;
                        }
                    case Enum_Mode.Add:
                        {

                             if (sS_DataGridView_ReceivePO.Rows.Count > 1)
                        {
                            string Str_WhereGetObjectHD = "POID ='" + sS_MaskedTextBox_PO.Text + "'";

                            int IntCheckObjectHD = Manager.Engine.GetObjectCount<Pohd>(Str_WhereGetObjectHD);

                            ORTransaction = Manager.Engine.BeginTransaction();
                            POHomeObj.Pohdobj.Poid = sS_MaskedTextBox_PO.Text;
                            POHomeObj.Pohdobj.PODate = Convert.ToDateTime(dateTimePicker_ReceivePODate.Text);
                            POHomeObj.Pohdobj.DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                            POHomeObj.Pohdobj.POType = sS_ComboBox_Type.SelectedItem.ToString();
                            POHomeObj.Pohdobj.Remark = sS_MaskedTextBox_Remark.Text;
                            POHomeObj.Pohdobj.FacCode = sS_MaskedTextBox_Facility.Text;
                            POHomeObj.Pohdobj.StatusID = "CLOSE";

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
                                string Str_WhereGetObjectDT = "POID ='" + sS_MaskedTextBox_PO.Text + "'AND POSeq ='" +
                                Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value) + "' AND " +
                                " modelID = '" + sS_DataGridView_ReceivePO[1, i].Value.ToString() + "'";

                                int IntCheckObjectDT = Manager.Engine.GetObjectCount<Podt>(Str_WhereGetObjectDT);

                                POHomeObj.Podtobj.Poid = sS_MaskedTextBox_PO.Text;
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

                                string Str_WhereGetObject = "POID ='" + sS_MaskedTextBox_PO.Text + "'AND POSeq ='" +
                                Convert.ToInt32(sS_DataGridView_ReceivePO[0, i].Value) + "' AND " +
                                " modelID = '" + sS_DataGridView_ReceivePO[1, i].Value.ToString() + "'";

                                int IntCheckObject = Manager.Engine.GetObjectCount<POReceive>(Str_WhereGetObject);

                                POHomeObj.POReceiveObj.Poid = sS_MaskedTextBox_PO.Text;
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

                                          
                                            //AssetHomeObj.Assetobj.Price = decimal.Parse("");
                                            AssetHomeObj.Assetobj.WarrantyStartDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.WarrantyEndDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.CustodianID = Convert.ToString(sS_DataGridView_AssetReceive[7, j].Value);
                                            //AssetHomeObj.Assetobj.PreviosCustodian = "";
                                            AssetHomeObj.Assetobj.CreatedDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.UserName = Global.ConfigDatabase.Str_UserID;
                                            AssetHomeObj.Assetobj.UpdateDate = DateTime.Now.Date;
                                            AssetHomeObj.Assetobj.Remark = Convert.ToString(sS_DataGridView_AssetReceive[8, j].Value);
                                            AssetHomeObj.Assetobj.FacCode = Convert.ToString(sS_MaskedTextBox_Facility.Text);

                                            if (AssetHomeObj.AddAsset(ORTransaction))
                                            {
                                                Bool_CheckExecuteComplete = true;
                                            }
                                            else
                                                Bool_CheckExecuteComplete = false;


                                            POHomeObj.AssetReceiveObj.Poid = sS_MaskedTextBox_PO.Text;
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
                                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_PO.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_PONo, Global.Lang.Str_Language);
                                RunControlHomeObj.SaveRunControlID("PORun", sS_MaskedTextBox_PO.Text);
                                Global.Bool_CheckComplete = true;
                                Enm_StateForm = Enum_Mode.PreAdd;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                //goto DEFAULT;
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_PO.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_PONo, Global.Lang.Str_Language);
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
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Form_001010_WriteOff_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_001010_WriteOff_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ClearData();
            Function_SetReadOnlyControl(true);
            Function_SetControlEnable(false);
            dateTimePicker_ReceivePODate.Enabled = false;
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_PO.Text = "";
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
            sS_MaskedTextBox_PO.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DepartmentNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_DeptName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Facility.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_FacName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_StateControl;
        }
        private void Function_SetControlEnable(bool Bool_StateControl)
        {
            sS_MaskedTextBox_DepartmentNo.Enabled = Bool_StateControl;
            sS_MaskedTextBox_Facility.Enabled = Bool_StateControl;
        }

        private void Form_001010_WriteOff_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void Form_001010_WriteOff_Activated(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
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

        private void sS_DataGridView_AssetReceive_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string Str_DeptID;
            object[] Obj_TransferID = new object[1] { sS_MaskedTextBox_PO.Text };
            if (e.ColumnIndex == 1)
            {
                int Int_TempSumTransferQty = sS_DataGridView_AssetReceive.Rows.Count-1;
                Str_DeptID = sS_MaskedTextBox_DepartmentNo.Text;
                Str_ModelID = Convert.ToString(sS_DataGridView_ReceivePO[1, e.RowIndex].Value);
                if (Int_TempSumTransferQty <= Int_Qty)
                {
                    sS_DataGridView_AssetReceive[0, e.RowIndex].Value = Int_TransferSeq + 1;
                        Global.FormOrder.Function_ShowFormSearchnew(Enum_TypeSearch.TransferSerial, Str_ModelID, Str_DeptID);

                        sS_DataGridView_AssetReceive[1, e.RowIndex].Value = Global.ReturnValue.Str_AssetNo;
                        sS_DataGridView_AssetReceive[2, e.RowIndex].Value = Global.ReturnValue.Str_AssetName;
                        sS_DataGridView_AssetReceive[3, e.RowIndex].Value = Global.ReturnValue.Str_ModelID;
                        sS_DataGridView_AssetReceive[4, e.RowIndex].Value = Global.ReturnValue.Str_SerialNo;
                        sS_DataGridView_AssetReceive[5, e.RowIndex].Value = Global.ReturnValue.Str_BuildID;
                        sS_DataGridView_AssetReceive[6, e.RowIndex].Value = Global.ReturnValue.Str_FloorID;
                        sS_DataGridView_AssetReceive[7, e.RowIndex].Value = Global.ReturnValue.Str_AreaID;
                        sS_DataGridView_AssetReceive[8, e.RowIndex].Value = Global.ReturnValue.Str_CustodianID;



                        sS_DataGridView_AssetReceive.CurrentCell = sS_DataGridView_AssetReceive[0, sS_DataGridView_AssetReceive.CurrentRow.Index];
                       

                }
                else
                {
                    SS_MyMessageBox.ShowBox("more than Quantity", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_TransferID, Global.Lang.Str_Language);
                }


            }
        }

        private void sS_DataGridView_ReceivePO_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void sS_DataGridView_AssetReceive_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Global.FormOrder.Function_PlusLineInDataGrid(e, sS_DataGridView_AssetReceive, Enm_StateForm);
        }

    }
}