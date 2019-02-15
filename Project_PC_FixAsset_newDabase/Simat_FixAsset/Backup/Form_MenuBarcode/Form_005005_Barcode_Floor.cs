using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    public partial class Form_005005_Barcode_Floor : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeFloorHome FormatBarcodeFloorHomeObj = new FormatBarcodeFloorHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;

        public Form_005005_Barcode_Floor()
        {
            InitializeComponent();            
            Function_InitialControl();

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_InitialControl()
        {
            try
            {
                DarkColor = Global.ConfigForm.Colr_BackColor;
                this.Text = Global.Function_Language(this, this, "ID:005005(BarcodeFloor)");
                label_FloorID.Text = Global.Function_Language(this, label_FloorID, "FloorID.");
                label_Remark.Text = Global.Function_Language(this, label_Remark, "Remark:");
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Format Barcode Initialize Control", DialogMode.Error_Cancel, Ex);
            }
        }

        public void Function_ExecuteTransaction(Enum_Mode Enm_mode)
        {
            

            try
            {
                object[] Obj_FloorID = new object[1] { sS_MaskedTextBox_FloorID.Text };
                object[] Obj_FloorRow = new object[1] { sS_DataGridView_BarcodeFloor.SelectedRows.Count };
                switch (Enm_mode)
                {
                    //case Enum_Mode.Search:
                    //    break;

                    //case Enum_Mode.PreAdd:
                    //    Function_ClearData();
                    //    sS_MaskedTextBox_FloorID.Focus();
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    Enm_StateForm = Enum_Mode.PreAdd;
                    //    break;

                    //case Enum_Mode.Add:

                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.FloorID = sS_MaskedTextBox_FloorID.Text;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.BarCode = sS_MaskedTextBox_FloorID.Text;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.Position = 1;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    string SQL ="FloorID = '" + sS_MaskedTextBox_FloorID.Text + "' AND Position ='" + FormatBarcodeFloorHomeObj.BarcodeFloorObj.Position +"'";
                    //    OPathQuery<FormatBarCodeFloor> TempFormatBarCodeFloor = new OPathQuery<FormatBarCodeFloor>(SQL);

                    //    FormatBarCodeFloor FormatBarCodeFloorObj =new FormatBarCodeFloor();
                    //    FormatBarCodeFloorObj =Manager.Engine.GetObject<FormatBarCodeFloor>(TempFormatBarCodeFloor);
                    //    if (FormatBarCodeFloorObj != null)
                    //    {
                    //        SS_MyMessageBox.ShowBox("FloorID : " + sS_MaskedTextBox_FloorID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_FloorID,Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = false;
                    //        sS_MaskedTextBox_FloorID.Focus();
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (FormatBarcodeFloorHomeObj.Add())
                    //        {
                    //            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_FloorID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_FloorID, Global.Lang.Str_Language);
                    //            Global.Bool_CheckComplete = true;

                    //            Enm_StateForm = Enum_Mode.PreAdd;
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            //goto DEFAULT;
                    //        }
                    //        else
                    //        {
                    //            goto ERRORADD;
                    //        }
                    //    }         
                    //   break;
                    //case Enum_Mode.PreEdit:
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    sS_MaskedTextBox_Remark.Focus();
                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    break;
                    //case Enum_Mode.Edit:

                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.FloorID = sS_MaskedTextBox_FloorID.Text;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.BarCode = sS_MaskedTextBox_FloorID.Text;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.Position = 1;
                    //    FormatBarcodeFloorHomeObj.BarcodeFloorObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    if (FormatBarcodeFloorHomeObj.Edit())
                    //    {
                    //        SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_FloorID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_FloorID, Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = true;
                    //        //goto DEFAULT;
                    //    }
                    //    else
                    //        goto ERROREDIT;

                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //    Function_ShowDataInDatagridView();

                    //    break;
                    //case Enum_Mode.Delete:
                    //    if (sS_DataGridView_BarcodeFloor.SelectedRows.Count > 1)
                    //    {
                    //        List<FormatBarCodeFloor> BarCodeFloorCollection = new List<FormatBarCodeFloor>();
                    //        FormatBarCodeFloor TempBarCodeFloor = new FormatBarCodeFloor();
                    //        foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeFloor.SelectedRows)
                    //        {
                    //            string Str_SQL = "FloorID = '" + TempDataGridRow.Cells[0].Value.ToString() + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //            OPathQuery<FormatBarCodeFloor> OpathBarCodeFloor = new OPathQuery<FormatBarCodeFloor>(Str_SQL);
                    //            TempBarCodeFloor = Manager.Engine.GetObject<FormatBarCodeFloor>(OpathBarCodeFloor);
                    //            BarCodeFloorCollection.Add(TempBarCodeFloor);
                    //        }
                    //        if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeFloor.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_FloorRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //        {

                    //            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //            if (FormatBarcodeFloorHomeObj.Delete(ORTransaction, BarCodeFloorCollection))
                    //            {
                    //                ORTransaction.Commit();
                    //                SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000009", Global.Lang.Str_Language);
                    //                Global.Bool_CheckComplete = true;

                    //                Enm_StateForm = Enum_Mode.PreAdd;
                    //                Function_ShowDataInDatagridView();
                    //            }
                    //            else
                    //            {
                    //                SS_MyMessageBox.ShowBox("Can not delete data ", "Warning", DialogMode.OkOnly, this.Name, "000010", Global.Lang.Str_Language);
                    //                Global.Bool_CheckComplete = false;

                    //                Enm_StateForm = Enum_Mode.PreEdit;
                    //            }
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //        }
                    //        else
                    //        {
                    //            Global.Bool_CheckComplete = false;
                    //            Enm_StateForm = Enum_Mode.PreEdit;
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (sS_MaskedTextBox_FloorID.Text != "")
                    //        {

                    //            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_FloorID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_FloorID, Global.Lang.Str_Language) == DialogResult.OK)
                    //            {
                    //                Global.Bool_CheckComplete = true;
                    //                FormatBarcodeFloorHomeObj.BarcodeFloorObj.FloorID = sS_MaskedTextBox_FloorID.Text;

                    //                if (FormatBarcodeFloorHomeObj.Delete())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_FloorID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_FloorID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;

                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ShowDataInDatagridView();
                    //                }
                    //                else
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_FloorID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_FloorID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = false;

                    //                    Enm_StateForm = Enum_Mode.PreEdit;
                    //                }
                    //                Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            }
                    //            else
                    //            {
                    //                Global.Bool_CheckComplete = false;
                    //                Enm_StateForm = Enum_Mode.PreEdit;
                    //                Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            }
                    //            //goto DEFAULT;
                    //        }
                    //        else
                    //            Global.Bool_CheckComplete = false;
                    //    }
                    //        break;
                    case Enum_Mode.ShowData:
                        //if (sS_DataGridView_BarcodeFloor.Rows.Count > 0)
                        //{
                        //    sS_MaskedTextBox_FloorID.ReadOnly = true;
                        //    sS_MaskedTextBox_FloorID.Text = sS_DataGridView_BarcodeFloor[0, sS_DataGridView_BarcodeFloor.CurrentRow.Index].Value.ToString();
                        //    FormatBarCodeFloor FormatBarcodeFloorObj = new FormatBarCodeFloor();
                        //    FormatBarcodeFloorObj = Manager.Engine.GetObject<FormatBarCodeFloor>(sS_MaskedTextBox_FloorID.Text);
                        //    if (FormatBarcodeFloorObj != null)
                        //    {
                        //        sS_MaskedTextBox_FloorName.Text = Global.FormOrder.Function_GetFloorName(sS_MaskedTextBox_FloorID.Text);
                        //        sS_MaskedTextBox_Remark.Text = FormatBarcodeFloorObj.Remark;
                        //    }
                           
                        //    sS_MaskedTextBox_FloorID.Focus();
                        //}
                        sS_MaskedTextBox_FloorID.ReadOnly = true;
                        sS_MaskedTextBox_FloorID.Focus();
                        break;
                    //case Enum_Mode.Cancel:
                    //    if (Enm_StateForm == Enum_Mode.PreEdit)
                    //    {
                    //        Function_ExecuteTransaction(Enum_Mode.ShowData);
                    //        sS_MaskedTextBox_FloorID.Focus();
                    //    }
                    //    if (Enm_StateForm == Enum_Mode.PreAdd)
                    //    {
                    //        Function_ClearData();
                    //        sS_MaskedTextBox_FloorID.Focus();
                    //        Function_ShowDataInDatagridView();
                    //    }
                    //    Function_SetReadOnlyControl(true);
                    //    Enm_StateForm = Enum_Mode.Search;
                    //    break;
                    //DEFAULT:
                    //    Function_ClearData();
                    //    Function_ShowDataInDatagridView();
                    //    sS_MaskedTextBox_FloorID.Focus();
                    //    Enm_StateForm =Enum_Mode.Search;
                    //    break;

                    //ERRORADD:
                    //    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_FloorID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_FloorID, Global.Lang.Str_Language);
                    //    Global.Bool_CheckComplete = false;
                    //    break;
                    //ERROREDIT:
                    //    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_FloorID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_FloorID, Global.Lang.Str_Language);
                    //    Global.Bool_CheckComplete = false;
                    //    break;
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On BarCode Asset Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }

        private void Function_ClearData()
        {
            sS_MaskedTextBox_FloorID.Text = "";
            sS_MaskedTextBox_FloorName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_FloorID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_FloorName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeFloor>("");
            sS_DataGridView_BarcodeFloor.DataSource = Ds;

            sS_DataGridView_BarcodeFloor.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }

        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FloorID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FloorName;
                Frm_Present.Show_Data("Screen", "005005");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();

            }
            //else
            //{
            //    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
            //    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetID;
            //    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;
            //    Frm_Present.Show_Data("Screen", "005001_02");

            //    Frm_Present.ShowDialog();
            //    Frm_Present.Dispose();
            //}
        }

        private void Form_005001_Barcode_Asset_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_005001_Barcode_Asset_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_005001_Barcode_Asset_Load(object sender, EventArgs e)
        {
         //   Function_ShowDataInDatagridView();
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_SetReadOnlyControl(true);
        }

        private void sS_DataGridView_BarcodeFloor_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (this.sS_MaskedTextBox_FloorID.Text != "")
            {
                string StrNo, StrName;
                StrNo = sS_MaskedTextBox_FloorID.Text;
                StrName = sS_MaskedTextBox_FloorName.Text;
               // Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
               // frm.Show();
               // frm.GetFloorforPrint(StrNo, StrName);
                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintCustomer(StrNo, "Floor No:", "Floor Name:", StrName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Floor Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Floor Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }
            }
        }

        private void Form_005005_Barcode_Floor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

       
    }
}