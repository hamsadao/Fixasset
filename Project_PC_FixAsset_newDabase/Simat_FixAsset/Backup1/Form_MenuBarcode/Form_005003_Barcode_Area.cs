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
    public partial class Form_005003_Barcode_Area : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeAreaHome FormatBarcodeAreaHomeObj = new FormatBarcodeAreaHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;

        public Form_005003_Barcode_Area()
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
                this.Text = Global.Function_Language(this, this, "ID:005003(BarcodeArea)");
                label_AreaID.Text = Global.Function_Language(this, label_AreaID, "AreaID.");
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
                object[] Obj_AreaNo = new object[1] { sS_MaskedTextBox_AreaID.Text };
                object[] Obj_AreaRow = new object[1] { sS_DataGridView_BarcodeArea.SelectedRows.Count };
                switch (Enm_mode)
                {
                    //case Enum_Mode.Search:
                    //    break;

                    //case Enum_Mode.PreAdd:
                    //    Function_ClearData();
                    //    sS_MaskedTextBox_AreaID.Focus();
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    Enm_StateForm = Enum_Mode.PreAdd;
                    //    break;

                    //case Enum_Mode.Add:

                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.AreaID = sS_MaskedTextBox_AreaID.Text;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.BarCode = sS_MaskedTextBox_AreaID.Text;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.Position = 1;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    string SQL = "AreaID = '" + sS_MaskedTextBox_AreaID.Text + "' AND Position = '" + FormatBarcodeAreaHomeObj.BarcodeAreaObj.Position + "'";
                    //    OPathQuery<FormatBarCodeArea> TempFormatBarCodeArea = new OPathQuery<FormatBarCodeArea>(SQL);

                    //    FormatBarCodeArea FormatBarCodeAreaObj = new FormatBarCodeArea();
                    //    FormatBarCodeAreaObj = Manager.Engine.GetObject<FormatBarCodeArea>(TempFormatBarCodeArea);
                    //    if (FormatBarCodeAreaObj != null)
                    //    {
                    //        SS_MyMessageBox.ShowBox("AreaNo : " + sS_MaskedTextBox_AreaID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_AreaNo,Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = false;
                    //        sS_MaskedTextBox_AreaID.Focus();
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (FormatBarcodeAreaHomeObj.Add())
                    //        {
                    //            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_AreaID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_AreaNo, Global.Lang.Str_Language);
                    //            Global.Bool_CheckComplete = true;
                    //            Enm_StateForm = Enum_Mode.PreAdd;
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            Function_ShowDataInDatagridView();
                    //        }
                    //        else
                    //        {
                    //            goto ERRORADD;
                    //        }
                    //    }
                    //    break;

                    //case Enum_Mode.PreEdit:
                    //    Function_SetReadOnlyControl(false);
                    //    sS_MaskedTextBox_Remark.Focus();
                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    break;
                    //case Enum_Mode.Edit:

                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.AreaID = sS_MaskedTextBox_AreaID.Text;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.BarCode = sS_MaskedTextBox_AreaID.Text;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.Position = 1;
                    //    FormatBarcodeAreaHomeObj.BarcodeAreaObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    if (FormatBarcodeAreaHomeObj.Edit())
                    //    {
                    //        SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_AreaID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_AreaNo, Global.Lang.Str_Language);
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
                    //    if (sS_DataGridView_BarcodeArea.SelectedRows.Count > 1)
                    //    {
                    //        List<FormatBarCodeArea> BarCodeAreaCollection = new List<FormatBarCodeArea>();
                    //        FormatBarCodeArea TempBarCodeArea = new FormatBarCodeArea();
                    //        foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeArea.SelectedRows)
                    //        {
                    //            string Str_SQL = "AreaID = '" + TempDataGridRow.Cells[0].Value.ToString() + "'AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //            OPathQuery<FormatBarCodeArea> OpathQueryBarCodeArea = new OPathQuery<FormatBarCodeArea>(Str_SQL);
                    //            TempBarCodeArea = Manager.Engine.GetObject<FormatBarCodeArea>(OpathQueryBarCodeArea);
                    //            BarCodeAreaCollection.Add(TempBarCodeArea);
                    //        }

                    //        if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeArea.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_AreaRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //        {

                    //            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //            if (FormatBarcodeAreaHomeObj.Delete(ORTransaction, BarCodeAreaCollection))
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
                    //        if (sS_MaskedTextBox_AreaID.Text != "")
                    //        {

                    //            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_AreaID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_AreaNo, Global.Lang.Str_Language) == DialogResult.OK)
                    //            {
                    //                Global.Bool_CheckComplete = true;
                    //                FormatBarcodeAreaHomeObj.BarcodeAreaObj.AreaID = sS_MaskedTextBox_AreaID.Text;

                    //                if (FormatBarcodeAreaHomeObj.Delete())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_AreaID.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_AreaNo, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;

                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ShowDataInDatagridView();
                    //                }
                    //                else
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AreaID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_AreaNo, Global.Lang.Str_Language);
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
                    //            // goto DEFAULT;
                    //        }
                    //        else
                    //            Global.Bool_CheckComplete = false;
                    //    }
                    //        break;
                    case Enum_Mode.ShowData:
                        //if (sS_DataGridView_BarcodeArea.Rows.Count > 0)
                        //{
                        //    sS_MaskedTextBox_AreaID.ReadOnly = true;
                        //    sS_MaskedTextBox_AreaID.Text = sS_DataGridView_BarcodeArea[0, sS_DataGridView_BarcodeArea.CurrentRow.Index].Value.ToString();
                        //    FormatBarCodeArea FormatBarcodeAreaObj = new FormatBarCodeArea();
                        //    FormatBarcodeAreaObj = Manager.Engine.GetObject<FormatBarCodeArea>(sS_MaskedTextBox_AreaID.Text);
                        //    if (FormatBarcodeAreaObj != null)
                        //    {
                        //        sS_MaskedTextBox_AreaName.Text = Global.FormOrder.Function_GetAreaName(sS_MaskedTextBox_AreaID.Text);
                        //        sS_MaskedTextBox_Remark.Text = FormatBarcodeAreaObj.Remark;
                        //    }
                        //    sS_MaskedTextBox_AreaID.Focus();
                        //}
                        sS_MaskedTextBox_AreaID.ReadOnly = true;
                        sS_MaskedTextBox_AreaID.Focus();
                        break;
                    //case Enum_Mode.Cancel:
                    //    if (Enm_StateForm == Enum_Mode.PreEdit)
                    //    {
                    //        Function_ExecuteTransaction(Enum_Mode.ShowData);
                    //        sS_MaskedTextBox_AreaID.Focus();
                    //    }
                    //    if (Enm_StateForm == Enum_Mode.PreAdd)
                    //    {
                    //        Function_ClearData();
                    //        sS_MaskedTextBox_AreaID.Focus();
                    //    }
                    //    Function_SetReadOnlyControl(true);
                    //    Enm_StateForm = Enum_Mode.Search;
                    //    break;

                    //DEFAULT:
                    //    Function_ClearData();
                    //    Function_ShowDataInDatagridView();
                    //    sS_MaskedTextBox_AreaID.Focus();
                    //    Enm_StateForm =Enum_Mode.Search;
                    //    break;

                    //ERRORADD:
                    //    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_AreaID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_AreaNo, Global.Lang.Str_Language);
                    //    Global.Bool_CheckComplete = false;
                    //    break;
                    //ERROREDIT:
                    //    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_AreaID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_AreaNo, Global.Lang.Str_Language);
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
            sS_MaskedTextBox_AreaID.Text = "";
            sS_MaskedTextBox_AreaName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_AreaID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_AreaName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeArea>("");
            sS_DataGridView_BarcodeArea.DataSource = Ds;

            sS_DataGridView_BarcodeArea.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }


        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AreaID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AreaName;
                Frm_Present.Show_Data("Screen", "005003");

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
          //  Function_ShowDataInDatagridView();
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_SetReadOnlyControl(true);
        }

        private void sS_DataGridView_BarcodeArea_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (this.sS_MaskedTextBox_AreaID.Text != "")
            {
                string StrNo, StrName;
                StrNo = sS_MaskedTextBox_AreaID.Text;
                StrName = sS_MaskedTextBox_AreaName.Text;

               // Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
               //frm.Show();
                //frm.GetLocationforPrint(StrNo, StrName);

                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintCustomer(StrNo, "Location No:", "Location Name:", StrName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Location Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Location Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }
            }
        }

        private void Form_005003_Barcode_Area_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

    }
}