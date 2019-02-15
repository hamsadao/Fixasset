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
    public partial class Form_005002_Barcode_Model : SS_PaintGradientForm
    {
        //  New ///
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        //  New ///

        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeModelHome FormatBarcodeModelHomeObj = new FormatBarcodeModelHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;

        public Form_005002_Barcode_Model()
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
                this.Text = Global.Function_Language(this, this, "ID:005002(BarcodeModel)");
                label_ModelID.Text = Global.Function_Language(this, label_ModelID, "ModelID.");
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
                object[] Obj_ModelNo = new object[1] { sS_MaskedTextBox_ModelID.Text };
                object[] Obj_ModelRow = new object[1] { sS_DataGridView_BarcodeModel.SelectedRows.Count };
                switch (Enm_mode)
                {
                    //case Enum_Mode.Search:
                    //    break;

                    //case Enum_Mode.PreAdd:
                    //    Function_ClearData();
                    //    sS_MaskedTextBox_ModelID.Focus();
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    Enm_StateForm = Enum_Mode.PreAdd;
                    //    break;

                    //case Enum_Mode.Add:

                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.ModelID = sS_MaskedTextBox_ModelID.Text;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.BarCode = sS_MaskedTextBox_ModelID.Text;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.Position = 1;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    string SQL = "ModelID = '" + sS_MaskedTextBox_ModelID.Text + "' AND Position = '" + FormatBarcodeModelHomeObj.BarcodeModelObj.Position + "'";
                    //    OPathQuery<FormatBarCodeModel> TempFormatBarCodeModel = new OPathQuery<FormatBarCodeModel>(SQL);

                    //    FormatBarCodeModel FormatBarCodeModelObj = new FormatBarCodeModel();
                    //    FormatBarCodeModelObj = Manager.Engine.GetObject<FormatBarCodeModel>(sS_MaskedTextBox_ModelID.Text);
                    //    if (FormatBarCodeModelObj != null)
                    //    {
                    //        SS_MyMessageBox.ShowBox("ModelNo : " + sS_MaskedTextBox_ModelID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_ModelNo,Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = false;
                    //        sS_MaskedTextBox_ModelID.Focus();
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (FormatBarcodeModelHomeObj.Add())
                    //        {
                    //            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_ModelID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_ModelNo, Global.Lang.Str_Language);
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
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    sS_MaskedTextBox_Remark.Focus();
                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    break;
                    //case Enum_Mode.Edit:

                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.ModelID = sS_MaskedTextBox_ModelID.Text;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.BarCode = sS_MaskedTextBox_ModelID.Text;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.Position = 1;
                    //    FormatBarcodeModelHomeObj.BarcodeModelObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    if (FormatBarcodeModelHomeObj.Edit())
                    //    {
                    //        SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_ModelID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_ModelNo, Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = true;
                            
                    //    }
                    //    else
                    //        goto ERROREDIT;

                    //    Enm_StateForm = Enum_Mode.PreEdit;
                    //    Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //    Function_ShowDataInDatagridView();
                    //    break;
                    //case Enum_Mode.Delete:
                    //    if (sS_DataGridView_BarcodeModel.SelectedRows.Count > 1)
                    //    {
                    //        List<FormatBarCodeModel> BarCodeModelCollection = new List<FormatBarCodeModel>();
                    //        FormatBarCodeModel TempBarCodeModel = new FormatBarCodeModel();
                    //        foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeModel.SelectedRows)
                    //        {
                    //            string Str_SQL = "ModelID ='" + TempDataGridRow.Cells[0].Value + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //            OPathQuery<FormatBarCodeModel> OpathBarCodeModel = new OPathQuery<FormatBarCodeModel>(Str_SQL);
                    //            TempBarCodeModel = Manager.Engine.GetObject<FormatBarCodeModel>(TempDataGridRow.Cells[0].Value.ToString());
                    //            BarCodeModelCollection.Add(TempBarCodeModel);
                    //        }
                    //        if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeModel.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_ModelRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //        {

                    //            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //            if (FormatBarcodeModelHomeObj.Delete(ORTransaction, BarCodeModelCollection))
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
                    //        if (sS_MaskedTextBox_ModelID.Text != "")
                    //        {

                    //            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_ModelID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_ModelNo, Global.Lang.Str_Language) == DialogResult.OK)
                    //            {
                    //                Global.Bool_CheckComplete = true;
                    //                FormatBarcodeModelHomeObj.BarcodeModelObj.ModelID = sS_MaskedTextBox_ModelID.Text;

                    //                if (FormatBarcodeModelHomeObj.Delete())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_ModelID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_ModelNo, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;
                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ShowDataInDatagridView();
                    //                }
                    //                else
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_ModelID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_ModelNo, Global.Lang.Str_Language);
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
                        //if (sS_DataGridView_BarcodeModel.Rows.Count > 0)
                        //{
                        //    sS_MaskedTextBox_ModelID.ReadOnly = true;
                        //    sS_MaskedTextBox_ModelID.Text = sS_DataGridView_BarcodeModel[0, sS_DataGridView_BarcodeModel.CurrentRow.Index].Value.ToString();
                        //    FormatBarCodeModel FormatBarcodeModelObj = new FormatBarCodeModel();
                        //    FormatBarcodeModelObj = Manager.Engine.GetObject<FormatBarCodeModel>(sS_MaskedTextBox_ModelID.Text);
                        //    if (FormatBarcodeModelObj != null)
                        //    {
                        //        sS_MaskedTextBox_ModelName.Text = Global.FormOrder.Function_GetModelName(sS_MaskedTextBox_ModelID.Text);
                        //        sS_MaskedTextBox_Remark.Text = FormatBarcodeModelObj.Remark;
                        //    }
                        //    sS_MaskedTextBox_ModelID.Focus();
                        //}
                        sS_MaskedTextBox_ModelID.ReadOnly = true;
                        sS_MaskedTextBox_ModelID.Focus();
                        break;
                    //case Enum_Mode.Cancel:
                    //    if (Enm_StateForm == Enum_Mode.PreEdit)
                    //    {
                    //        Function_ExecuteTransaction(Enum_Mode.ShowData);
                    //        sS_MaskedTextBox_ModelID.Focus();
                    //    }
                    //    if (Enm_StateForm == Enum_Mode.PreAdd)
                    //    {
                    //        Function_ClearData();
                    //        sS_MaskedTextBox_ModelID.Focus();
                    //        Function_ShowDataInDatagridView();
                    //    }
                    //    Function_SetReadOnlyControl(true);
                    //    Enm_StateForm = Enum_Mode.Search;
                    //    break;

                    //DEFAULT:
                    //    Function_ClearData();
                    //    Function_ShowDataInDatagridView();
                    //    sS_MaskedTextBox_ModelID.Focus();
                    //    Enm_StateForm =Enum_Mode.Search;
                    //    break;

                    //ERRORADD:
                    //    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_ModelID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_ModelNo, Global.Lang.Str_Language);
                    //    Global.Bool_CheckComplete = false;
                    //    break;
                    //ERROREDIT:
                    //    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_ModelID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_ModelNo, Global.Lang.Str_Language);
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
            sS_MaskedTextBox_ModelID.Text = "";
            sS_MaskedTextBox_ModelName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_ModelID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_ModelName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeModel>("");
            sS_DataGridView_BarcodeModel.DataSource = Ds;
            sS_DataGridView_BarcodeModel.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }


        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ModelID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ModelName;
                Frm_Present.Show_Data("Screen", "005002");

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

      
        private void Form_005002_Barcode_Model_Load(object sender, EventArgs e)
        {
           // Function_ShowDataInDatagridView();
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_SetReadOnlyControl(true);
        }

        private void sS_DataGridView_BarcodeModel_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (this.sS_MaskedTextBox_ModelID.Text != "")
            {
                string StrNo, StrName;
                StrNo = sS_MaskedTextBox_ModelID.Text;
                StrName = sS_MaskedTextBox_ModelName.Text;


                // Original //
                // Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
                // frm.Show();
                // frm.GetmodelforPrint(StrNo, StrName);
                // End

                // Call  CaptureScreen()
                // CaptureScreen();
               
                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintCustomer(StrNo, "Model No:", "Model Name:", StrName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Model Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Model Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }
            }

        }

        private void Form_005002_Barcode_Model_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }
        private void CaptureScreen()
        {
            Graphics mygraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }
    }
}