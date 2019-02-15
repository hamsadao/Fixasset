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
    public partial class Form_005007_Barcode_Custodian : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeCustodianHome FormatBarcodeCustodianHomeObj = new FormatBarcodeCustodianHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;

        public Form_005007_Barcode_Custodian()
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
                this.Text = Global.Function_Language(this, this, "ID:005007(BarcodeCustodian)");
                label_CustodianID.Text = Global.Function_Language(this, label_CustodianID, "CustodianID.");
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
                object[] Obj_CustodianID = new object[1] { sS_MaskedTextBox_CustodianID.Text };
                object[] Obj_CustodianRow = new object[1] { sS_DataGridView_BarcodeCustodian.SelectedRows.Count };
                switch (Enm_mode)
                {
                    //case Enum_Mode.Search:
                    //    break;

                    //case Enum_Mode.PreAdd:
                    //    Function_ClearData();
                    //    sS_MaskedTextBox_CustodianID.Focus();
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    Enm_StateForm = Enum_Mode.PreAdd;
                    //    break;

                    //case Enum_Mode.Add:

                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.CustodianID = sS_MaskedTextBox_CustodianID.Text;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.BarCode = sS_MaskedTextBox_CustodianID.Text;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.Position = 1;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    string SQL = "CustodianID = '" + sS_MaskedTextBox_CustodianID.Text + "' AND Position = '" + FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.Position + "'";
                    //    OPathQuery<FormatBarCodeCustodian> TempFormatBarCodeCustodian = new OPathQuery<FormatBarCodeCustodian>(SQL);

                    //    FormatBarCodeCustodian FormatBarCodeCustodianObj = new FormatBarCodeCustodian();
                    //    FormatBarCodeCustodianObj = Manager.Engine.GetObject<FormatBarCodeCustodian>(TempFormatBarCodeCustodian);
                    //    if (FormatBarCodeCustodianObj != null)
                    //    {
                    //        SS_MyMessageBox.ShowBox("CustodianID : " + sS_MaskedTextBox_CustodianID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_CustodianID,Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = false;
                    //        sS_MaskedTextBox_CustodianID.Focus();
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (FormatBarcodeCustodianHomeObj.Add())
                    //        {
                    //            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_CustodianID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_CustodianID, Global.Lang.Str_Language);
                    //            Global.Bool_CheckComplete = true;
                    //            Enm_StateForm = Enum_Mode.PreAdd;
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            //goto DEFAULT;
                    //        }
                    //        else
                    //            goto ERRORADD;
                    //    }
                    //    break;

                    //case Enum_Mode.PreEdit:
                    //    Function_SetReadOnlyControl(false);
                    //    sS_MaskedTextBox_Remark.Focus();
                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    break;
                    //case Enum_Mode.Edit:

                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.CustodianID = sS_MaskedTextBox_CustodianID.Text;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.BarCode = sS_MaskedTextBox_CustodianID.Text;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.Position = 1;
                    //    FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    if (FormatBarcodeCustodianHomeObj.Edit())
                    //    {
                    //        SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_CustodianID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_CustodianID, Global.Lang.Str_Language);
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
                    //    if (sS_DataGridView_BarcodeCustodian.SelectedRows.Count > 1)
                    //    {
                    //        List<FormatBarCodeCustodian> BarCodeCustodianCollection = new List<FormatBarCodeCustodian>();
                    //        FormatBarCodeCustodian TempBarCodeCustodian = new FormatBarCodeCustodian();
                    //        foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeCustodian.SelectedRows)
                    //        {
                    //            string Str_SQL = "CustodianID = '" + TempDataGridRow.Cells[0].Value.ToString() + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //            OPathQuery<FormatBarCodeCustodian> OpathBarCodeCustodian = new OPathQuery<FormatBarCodeCustodian>(Str_SQL);
                    //            TempBarCodeCustodian = Manager.Engine.GetObject<FormatBarCodeCustodian>(OpathBarCodeCustodian);
                    //            BarCodeCustodianCollection.Add(TempBarCodeCustodian);
                    //        }
                    //        if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeCustodian.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_CustodianRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //        {

                    //            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //            if (FormatBarcodeCustodianHomeObj.Delete(ORTransaction, BarCodeCustodianCollection))
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
                    //        if (sS_MaskedTextBox_CustodianID.Text != "")
                    //        {

                    //            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_CustodianID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_CustodianID, Global.Lang.Str_Language) == DialogResult.OK)
                    //            {
                    //                Global.Bool_CheckComplete = true;
                    //                FormatBarcodeCustodianHomeObj.BarcodeCustodianObj.CustodianID = sS_MaskedTextBox_CustodianID.Text;

                    //                if (FormatBarcodeCustodianHomeObj.Delete())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_CustodianID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_CustodianID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;

                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ShowDataInDatagridView();
                    //                }
                    //                else
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_CustodianID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_CustodianID, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_CustodianID.ReadOnly = true;
                        sS_MaskedTextBox_CustodianID.Focus();
                        //if (sS_DataGridView_BarcodeCustodian.Rows.Count > 0)
                        //{
                        //    sS_MaskedTextBox_CustodianID.ReadOnly = true;
                        //    sS_MaskedTextBox_CustodianID.Text = sS_DataGridView_BarcodeCustodian[0, sS_DataGridView_BarcodeCustodian.CurrentRow.Index].Value.ToString();
                        //    FormatBarCodeCustodian FormatBarcodeCustodianObj = new FormatBarCodeCustodian();
                        //    FormatBarcodeCustodianObj = Manager.Engine.GetObject<FormatBarCodeCustodian>(sS_MaskedTextBox_CustodianID.Text);
                        //    if (FormatBarcodeCustodianObj != null)
                        //    {
                        //        sS_MaskedTextBox_CustodianName.Text = Global.FormOrder.Function_GetCustodianName(sS_MaskedTextBox_CustodianID.Text);
                        //        sS_MaskedTextBox_Remark.Text = FormatBarcodeCustodianObj.Remark;
                        //    }
                            //sS_MaskedTextBox_CustodianID.Focus();
                        //}
                        break;
                    //case Enum_Mode.Cancel:
                    //    if (Enm_StateForm == Enum_Mode.PreEdit)
                    //    {
                    //        Function_ExecuteTransaction(Enum_Mode.ShowData);
                    //        sS_MaskedTextBox_CustodianID.Focus();
                    //    }
                    //    if (Enm_StateForm == Enum_Mode.PreAdd)
                    //    {
                    //        Function_ClearData();
                    //        sS_MaskedTextBox_CustodianID.Focus();
                    //        Function_ShowDataInDatagridView();
                    //    }
                    //    Function_SetReadOnlyControl(true);
                    //    Enm_StateForm = Enum_Mode.Search;
                    //    break;

                    //DEFAULT:
                    //    Function_ClearData();
                    //    Function_ShowDataInDatagridView();
                    //    sS_MaskedTextBox_CustodianID.Focus();
                    //    Enm_StateForm =Enum_Mode.Search;
                    //    break;

                    //ERRORADD:
                    //    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_CustodianID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_CustodianID, Global.Lang.Str_Language);
                    //    Global.Bool_CheckComplete = false;
                    //    break;
                    //ERROREDIT:
                    //    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_CustodianID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_CustodianID, Global.Lang.Str_Language);
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
            sS_MaskedTextBox_CustodianID.Text = "";
            sS_MaskedTextBox_CustodianName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_CustodianID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_CustodianName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeCustodian>("");
            sS_DataGridView_BarcodeCustodian.DataSource = Ds;

            sS_DataGridView_BarcodeCustodian.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }


        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_CustodianID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_CustodianName;
                Frm_Present.Show_Data("Screen", "005007");

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
            //Function_ShowDataInDatagridView();
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_SetReadOnlyControl(true);
        }

        private void sS_DataGridView_BarcodeCustodian_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (this.sS_MaskedTextBox_CustodianID.Text != "")
            {
                string StrNo, StrName;
                StrNo = sS_MaskedTextBox_CustodianID.Text;
                StrName = sS_MaskedTextBox_CustodianName.Text;
               // Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
                //frm.Show();
               // frm.GetCustodianforPrint(StrNo, StrName);

                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintCustomer(StrNo, "Custodian No:", "Custodian Name:", StrName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Custodian Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Custodian Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }
            }
        }

        private void Form_005007_Barcode_Custodian_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }
    }
}