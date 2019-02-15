using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using System.Drawing.Printing;
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    public partial class Form_005004_Barcode_Building : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeBuildingHome FormatBarcodeBuildingHomeObj = new FormatBarcodeBuildingHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;
        string StrNo;
        string StrName;
        public Form_005004_Barcode_Building()
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
                this.Text = Global.Function_Language(this, this, "ID:005004(BarcodeBuilding)");
                label_BuildID.Text = Global.Function_Language(this, label_BuildID, "BuildingID.");
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
                object[] Obj_BuildID = new object[1] { sS_MaskedTextBox_BuildID.Text };
                object[] Obj_BuildRow = new object[1] { sS_DataGridView_BarcodeBuild.SelectedRows.Count };
                switch (Enm_mode)
                {
                    #region commet
                    //case Enum_Mode.Search:
                    //    break;

                    //case Enum_Mode.PreAdd:
                    //    Function_ClearData();
                    //    sS_MaskedTextBox_BuildID.Focus();
                    //    sS_MaskedTextBox_Remark.ReadOnly = false;
                    //    Enm_StateForm = Enum_Mode.PreAdd;
                    //    break;

                    //case Enum_Mode.Add:

                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.BuildID = sS_MaskedTextBox_BuildID.Text;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.BarCode = sS_MaskedTextBox_BuildID.Text;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.Position = 1;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    string SQL = "BuildID = '" + sS_MaskedTextBox_BuildID.Text + "' AND Position = '" + FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.Position + "'";
                    //    OPathQuery<FormatBarCodeBuilding> TempFormatBarCodrBuilding = new OPathQuery<FormatBarCodeBuilding>(SQL);

                    //    FormatBarCodeBuilding FormatBarCodeBuildingObj = new FormatBarCodeBuilding();
                    //    FormatBarCodeBuildingObj = Manager.Engine.GetObject<FormatBarCodeBuilding>(TempFormatBarCodrBuilding);
                    //    if (FormatBarCodeBuildingObj != null)
                    //    {
                    //        SS_MyMessageBox.ShowBox("BuildingID :" + sS_MaskedTextBox_BuildID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_BuildID,Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = false;
                    //        sS_MaskedTextBox_BuildID.Focus();
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        if (FormatBarcodeBuildingHomeObj.Add())
                    //        {
                    //            SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_BuildID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_BuildID, Global.Lang.Str_Language);
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

                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.BuildID = sS_MaskedTextBox_BuildID.Text;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.BarCode = sS_MaskedTextBox_BuildID.Text;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.Position = 1;
                    //    FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //    if (FormatBarcodeBuildingHomeObj.Edit())
                    //    {
                    //        SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_BuildID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_BuildID, Global.Lang.Str_Language);
                    //        Global.Bool_CheckComplete = true;
                    //        goto DEFAULT;
                    //    }
                    //    else
                    //        goto ERROREDIT;

                    //    break;
                    //case Enum_Mode.Delete:
                    //    if (sS_DataGridView_BarcodeBuild.SelectedRows.Count > 1)
                    //    {
                    //        List<FormatBarCodeBuilding> BarCodeBuildingCollection = new List<FormatBarCodeBuilding>();
                    //        FormatBarCodeBuilding TempBarCodeBuilding = new FormatBarCodeBuilding();
                    //        foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeBuild.SelectedRows)
                    //        {
                    //            string Str_SQL = "BuildID = '" + TempDataGridRow.Cells[0].Value.ToString() + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //            OPathQuery<FormatBarCodeBuilding> OpathBarCodeBuilding = new OPathQuery<FormatBarCodeBuilding>(Str_SQL);
                    //            TempBarCodeBuilding = Manager.Engine.GetObject<FormatBarCodeBuilding>(OpathBarCodeBuilding);
                    //            BarCodeBuildingCollection.Add(TempBarCodeBuilding);
                    //        }
                    //        if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeBuild.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_BuildRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //        {

                    //            Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //            if (FormatBarcodeBuildingHomeObj.Delete(ORTransaction, BarCodeBuildingCollection))
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
                    //        if (sS_MaskedTextBox_BuildID.Text != "")
                    //        {

                    //            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_BuildID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_BuildID, Global.Lang.Str_Language) == DialogResult.OK)
                    //            {
                    //                Global.Bool_CheckComplete = true;
                    //                FormatBarcodeBuildingHomeObj.BarcodeBuildingObj.BuildID = sS_MaskedTextBox_BuildID.Text;

                    //                if (FormatBarcodeBuildingHomeObj.Delete())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_BuildID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_BuildID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;

                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ShowDataInDatagridView();
                    //                }
                    //                else
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_BuildID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_BuildID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = false;
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
                    #endregion
                    case Enum_Mode.ShowData:
                        #region commet
                        //if (sS_DataGridView_BarcodeBuild.Rows.Count > 0)
                        //{
                        //    sS_MaskedTextBox_BuildID.ReadOnly = true;
                        //    sS_MaskedTextBox_BuildID.Text = sS_DataGridView_BarcodeBuild[0, sS_DataGridView_BarcodeBuild.CurrentRow.Index].Value.ToString();
                        //    FormatBarCodeBuilding FormatBarcodeBuildingObj = new FormatBarCodeBuilding();
                        //    FormatBarcodeBuildingObj = Manager.Engine.GetObject<FormatBarCodeBuilding>(sS_MaskedTextBox_BuildID.Text);
                        //    if (FormatBarcodeBuildingObj != null)
                        //    {
                        //        sS_MaskedTextBox_BuildName.Text = Global.FormOrder.Function_GetBuildingName(sS_MaskedTextBox_BuildID.Text);
                        //        sS_MaskedTextBox_Remark.Text = FormatBarcodeBuildingObj.Remark;
                        //    }
                        //    sS_MaskedTextBox_BuildID.Focus();
                        //}
                        #endregion
                        sS_MaskedTextBox_BuildID.ReadOnly = true;
                        sS_MaskedTextBox_BuildID.Focus();
                        break;
                        #region commet
                        //case Enum_Mode.Cancel:
                        //    if (Enm_StateForm == Enum_Mode.PreEdit)
                        //    {
                        //        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        //        sS_MaskedTextBox_BuildID.Focus();
                        //    }
                        //    if (Enm_StateForm == Enum_Mode.PreAdd)
                        //    {
                        //        Function_ClearData();
                        //        sS_MaskedTextBox_BuildID.Focus();
                        //        Function_ShowDataInDatagridView();
                        //    }
                        //    Function_SetReadOnlyControl(true);
                        //    Enm_StateForm = Enum_Mode.Search;
                        //    break;

                        //DEFAULT:
                        //    Function_ClearData();
                        //    Function_ShowDataInDatagridView();
                        //    sS_MaskedTextBox_BuildID.Focus();
                        //    Enm_StateForm =Enum_Mode.Search;
                        //    break;

                        //ERRORADD:
                        //    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_BuildID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_BuildID, Global.Lang.Str_Language);
                        //    Global.Bool_CheckComplete = false;
                        //    break;
                        //ERROREDIT:
                        //    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_BuildID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_BuildID, Global.Lang.Str_Language);
                        //    Global.Bool_CheckComplete = false;
                        //    break;
                        #endregion
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On BarCode Asset Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }

        private void Function_ClearData()
        {
            sS_MaskedTextBox_BuildID.Text = "";
            sS_MaskedTextBox_BuildName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_BuildID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_BuildName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeBuilding>("");
            sS_DataGridView_BarcodeBuild.DataSource = Ds;

            sS_DataGridView_BarcodeBuild.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }


        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_BuildID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_BuildName;
                Frm_Present.Show_Data("Screen", "005004");

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

        private void sS_DataGridView_BarcodeBuild_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        #region Old code bt Aot
        /* private void sS_ButtonGlass1_Click(object sender, EventArgs e)
         {
             if (this.sS_MaskedTextBox_BuildID.Text != "")
             {
                 string StrNo, StrName;
                 StrNo = sS_MaskedTextBox_BuildID.Text;
                 StrName = sS_MaskedTextBox_BuildName.Text;

                 //Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
                 //frm.Show();
                 //frm.GetBuildingforPrint(StrNo, StrName);

                 Prints cmdPrint = new Prints();
                 bool Printresult = cmdPrint.PrintCustomer(StrNo, "Building No:", "Building Name:", StrName);
                 if (Printresult == true)
                 {
                     SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                 }
                 else
                 {
                     SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                 }
             }
         }*/

        #endregion

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {

            try
            {
                System.Windows.Forms.PrintDialog printDialog = new System.Windows.Forms.PrintDialog();
                printDialog.UseEXDialog = true;


                if (printDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printDialog.PrinterSettings;

                    //pd.PrinterSettings.PrinterName = printDialog.PrinterSettings.PrinterName;//90 mm//354
                    pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 204, 102); //5cm/1.97 inch -> 3.5cm/1.36 inch
                    pd.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
                    pd.PrinterSettings.DefaultPageSettings.Margins = new Margins(9, 9, 9, 9);
                    //pd.DefaultPageSettings.Margins.Left = 0;
                    //pd.DefaultPageSettings.Margins.Top = 0;//= new Margins(0,0,0,0);
                    pd.DefaultPageSettings.Landscape = false;
                    pd.DocumentName = "RTE";
                    pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                    printDialog.Document = pd;

                    if (this.sS_MaskedTextBox_BuildID.Text != "")
                    {

                        StrNo = sS_MaskedTextBox_BuildID.Text;
                        StrName = sS_MaskedTextBox_BuildName.Text;
                        pd.Print();

                        SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);
                        #region commet 
                        /*Prints cmdPrint = new Prints();
                        bool Printresult = cmdPrint.PrintCustomer(StrNo, "Building No:", "Building Name:", StrName);

                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }*/
                        #endregion

                    }
                    else {
                        SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                    }
                }
            }
            
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Printing Building Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                /*string AssetNo;
                string AssetName;
                string BU;
                string Date;
                string Dept;*/
                //string AssetNo, AssetName, BU, Date, Dept;
                int std = 0;//5;
                Single leftMargin = e.MarginBounds.Left;
                Single topMargin = e.MarginBounds.Top;
                //int wd = e.PageBounds.Width;

                Font printFont1 = new Font("Tahoma", 9, System.Drawing.FontStyle.Regular);
                Font printFont2 = new Font("Tahoma", 9, System.Drawing.FontStyle.Bold);
                Font printFont3 = new Font("Tahoma", 11, System.Drawing.FontStyle.Bold);
                Font printFont4 = new Font("Tahoma", 7, System.Drawing.FontStyle.Regular);

                SolidBrush br = new SolidBrush(System.Drawing.Color.Black);
                BarcodeLib.Barcode b = new BarcodeLib.Barcode();
                b.LabelPosition = BarcodeLib.LabelPositions.TOPRIGHT;
                //
                System.Drawing.Image bar = b.Encode(BarcodeLib.TYPE.CODE128, StrNo, 180, 25);

                //e.Graphics.DrawString(StrNo, printFont4, br, 135, std + 5);
               
                e.Graphics.DrawString("Building No:", printFont4, br, 25, std + 30);
                e.Graphics.DrawString(StrNo, printFont4, br, 85, std + 30);

                e.Graphics.DrawString("Building Name:", printFont4, br, 25, std + 43);
                e.Graphics.DrawString(StrName, printFont4, br, 95, std + 43);
                e.Graphics.DrawImage(bar, 1, std + 60);

            }
            catch (Exception Err)
            {

                throw new Exception("pd_PrintPage(): " + Err.Message);
            }
        }



        private void Form_005004_Barcode_Building_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

      
    }
}