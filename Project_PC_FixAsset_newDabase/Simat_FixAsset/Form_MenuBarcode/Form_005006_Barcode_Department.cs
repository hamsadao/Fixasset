using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    public partial class Form_005006_Barcode_Department : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeDepartmentHome FormatBarcodeDepartmentHomeObj = new FormatBarcodeDepartmentHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;
        string StrNo;
        string StrName;

        public Form_005006_Barcode_Department()
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
                this.Text = Global.Function_Language(this, this, "ID:005006(BarcodeDepartment)");
                label_DeptID.Text = Global.Function_Language(this, label_DeptID, "DepartmentID.");
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
                object[] Obj_DeptID = new object[1] { sS_MaskedTextBox_DeptID.Text };
                object[] Obj_DeptRow = new object[1] { sS_DataGridView_BarcodeDepartment.SelectedRows.Count };
                switch (Enm_mode)
                {
                    #region commet
                    //        case Enum_Mode.Search:
                    //            break;

                    //        case Enum_Mode.PreAdd:
                    //            Function_ClearData();
                    //            sS_MaskedTextBox_DeptID.Focus();
                    //            sS_MaskedTextBox_Remark.ReadOnly = false;
                    //            Enm_StateForm = Enum_Mode.PreAdd;
                    //            break;

                    //        case Enum_Mode.Add:

                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.DeptID = sS_MaskedTextBox_DeptID.Text;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.BarCode = sS_MaskedTextBox_DeptID.Text;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.Position = 1;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //            string SQL = "DeptID = '" + sS_MaskedTextBox_DeptID.Text + "' AND Position = '" + FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.Position + "'";
                    //            OPathQuery<FormatBarCodeDepartment> TempFormatBarCodeDepartment = new OPathQuery<FormatBarCodeDepartment>(SQL);

                    //            FormatBarCodeDepartment FormatBarCodeDepartmentObj = new FormatBarCodeDepartment();
                    //            FormatBarCodeDepartmentObj = Manager.Engine.GetObject<FormatBarCodeDepartment>(TempFormatBarCodeDepartment);
                    //            if (FormatBarCodeDepartmentObj != null)
                    //            {
                    //                SS_MyMessageBox.ShowBox("DepartmentID : " + sS_MaskedTextBox_DeptID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_DeptID,Global.Lang.Str_Language);
                    //                Global.Bool_CheckComplete = false;
                    //                sS_MaskedTextBox_DeptID.Focus();
                    //                break;
                    //            }
                    //            else
                    //            {
                    //                if (FormatBarcodeDepartmentHomeObj.Add())
                    //                {
                    //                    SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_DeptID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_DeptID, Global.Lang.Str_Language);
                    //                    Global.Bool_CheckComplete = true;

                    //                    Enm_StateForm = Enum_Mode.PreAdd;
                    //                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //                    //goto DEFAULT;
                    //                }
                    //                else
                    //                    goto ERRORADD;
                    //            }
                    //            break;

                    //        case Enum_Mode.PreEdit:
                    //            Function_SetReadOnlyControl(false);
                    //            sS_MaskedTextBox_Remark.Focus();
                    //            Enm_StateForm = Enum_Mode.PreEdit;
                    //            break;
                    //        case Enum_Mode.Edit:

                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.DeptID = sS_MaskedTextBox_DeptID.Text;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.BarCode = sS_MaskedTextBox_DeptID.Text;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.Position = 1;
                    //            FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.Remark = sS_MaskedTextBox_Remark.Text;

                    //            if (FormatBarcodeDepartmentHomeObj.Edit())
                    //            {
                    //                SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_DeptID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_DeptID, Global.Lang.Str_Language);
                    //                Global.Bool_CheckComplete = true;
                    //                //goto DEFAULT;
                    //            }
                    //            else
                    //                goto ERROREDIT;

                    //            Enm_StateForm = Enum_Mode.PreEdit;
                    //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //            Function_ShowDataInDatagridView();
                    //            break;
                    //        case Enum_Mode.Delete:
                    //            if (sS_DataGridView_BarcodeDepartment.SelectedRows.Count > 1)
                    //            {
                    //                List<FormatBarCodeDepartment> BarCodeDeptCollection = new List<FormatBarCodeDepartment>();
                    //                FormatBarCodeDepartment TempBarCodeDept = new FormatBarCodeDepartment();
                    //                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeDepartment.SelectedRows)
                    //                {
                    //                    string Str_SQL = "DeptID = '" + TempDataGridRow.Cells[0].Value.ToString() + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                    //                    OPathQuery<FormatBarCodeDepartment> OpathBarCodeDept = new OPathQuery<FormatBarCodeDepartment>(Str_SQL);
                    //                    TempBarCodeDept = Manager.Engine.GetObject<FormatBarCodeDepartment>(OpathBarCodeDept);
                    //                    BarCodeDeptCollection.Add(TempBarCodeDept);
                    //                }
                    //                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeDepartment.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_DeptRow, Global.Lang.Str_Language) == DialogResult.OK)
                    //                {

                    //                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                    //                    if (FormatBarcodeDepartmentHomeObj.Delete(ORTransaction, BarCodeDeptCollection))
                    //                    {
                    //                        ORTransaction.Commit();
                    //                        SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000009", Global.Lang.Str_Language);
                    //                        Global.Bool_CheckComplete = true;

                    //                        Enm_StateForm = Enum_Mode.PreAdd;
                    //                        Function_ShowDataInDatagridView();
                    //                    }
                    //                    else
                    //                    {
                    //                        SS_MyMessageBox.ShowBox("Can not delete data ", "Warning", DialogMode.OkOnly, this.Name, "000010", Global.Lang.Str_Language);
                    //                        Global.Bool_CheckComplete = false;

                    //                        Enm_StateForm = Enum_Mode.PreEdit;
                    //                    }
                    //                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //                }
                    //                else
                    //                {
                    //                    Global.Bool_CheckComplete = false;
                    //                    Enm_StateForm = Enum_Mode.PreEdit;
                    //                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //                }
                    //            }
                    //            else
                    //            {
                    //                if (sS_MaskedTextBox_DeptID.Text != "")
                    //                {

                    //                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_DeptID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_DeptID, Global.Lang.Str_Language) == DialogResult.OK)
                    //                    {
                    //                        Global.Bool_CheckComplete = true;
                    //                        FormatBarcodeDepartmentHomeObj.BarcodeDepartmentObj.DeptID = sS_MaskedTextBox_DeptID.Text;

                    //                        if (FormatBarcodeDepartmentHomeObj.Delete())
                    //                        {
                    //                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_DeptID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_DeptID, Global.Lang.Str_Language);
                    //                            Global.Bool_CheckComplete = true;

                    //                            Enm_StateForm = Enum_Mode.PreAdd;
                    //                            Function_ShowDataInDatagridView();
                    //                        }
                    //                        else
                    //                        {
                    //                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_DeptID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_DeptID, Global.Lang.Str_Language);
                    //                            Enm_StateForm = Enum_Mode.PreEdit;
                    //                        }
                    //                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //                    }
                    //                    else
                    //                    {
                    //                        Global.Bool_CheckComplete = false;
                    //                        Enm_StateForm = Enum_Mode.PreEdit;
                    //                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                    //                    }
                    //                    //goto DEFAULT;
                    //                }
                    //                else
                    //                    Global.Bool_CheckComplete = false;
                    //            }
                    //                break;
                    #endregion
                    case Enum_Mode.ShowData:
                        if (sS_DataGridView_BarcodeDepartment.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_DeptID.ReadOnly = true;
                            #region commet
                            //sS_MaskedTextBox_DeptID.Text = sS_DataGridView_BarcodeDepartment[0, sS_DataGridView_BarcodeDepartment.CurrentRow.Index].Value.ToString();
                            //FormatBarCodeDepartment FormatBarcodeDeptObj = new FormatBarCodeDepartment();
                            //FormatBarcodeDeptObj = Manager.Engine.GetObject<FormatBarCodeDepartment>(sS_MaskedTextBox_DeptID.Text);
                            //if (FormatBarcodeDeptObj != null)
                            //{
                            //    sS_MaskedTextBox_DeptName.Text = Global.FormOrder.Function_GetDeptName(sS_MaskedTextBox_DeptID.Text);
                            //    sS_MaskedTextBox_Remark.Text = FormatBarcodeDeptObj.Remark;
                            //}
                            #endregion
                            sS_MaskedTextBox_DeptID.Focus();
                        }
                        break;
                        #region commet
                        //        case Enum_Mode.Cancel:
                        //            if (Enm_StateForm == Enum_Mode.PreEdit)
                        //            {
                        //                Function_ExecuteTransaction(Enum_Mode.ShowData);
                        //                sS_MaskedTextBox_DeptID.Focus();
                        //            }
                        //            if (Enm_StateForm == Enum_Mode.PreAdd)
                        //            {
                        //                Function_ClearData();
                        //                sS_MaskedTextBox_DeptID.Focus();
                        //                Function_ShowDataInDatagridView();
                        //            }
                        //            Function_SetReadOnlyControl(true);
                        //            Enm_StateForm = Enum_Mode.Search;
                        //            break;

                        //        DEFAULT:
                        //            Function_ClearData();
                        //            Function_ShowDataInDatagridView();
                        //            sS_MaskedTextBox_DeptID.Focus();
                        //            Enm_StateForm =Enum_Mode.Search;
                        //            break;

                        //        ERRORADD:
                        //            SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_DeptID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_DeptID, Global.Lang.Str_Language);
                        //            Global.Bool_CheckComplete = false;
                        //            break;
                        //        ERROREDIT:
                        //            SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_DeptID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_DeptID, Global.Lang.Str_Language);
                        //            Global.Bool_CheckComplete = false;
                        //            break;
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
            sS_MaskedTextBox_DeptID.Text = "";
            sS_MaskedTextBox_DeptName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_DeptID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_DeptName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;
        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeDepartment>("");
            sS_DataGridView_BarcodeDepartment.DataSource = Ds;

            sS_DataGridView_BarcodeDepartment.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }


        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_DeptID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_DeptName;
                Frm_Present.Show_Data("Screen", "005006");

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

        private void sS_DataGridView_BarcodeDepartment_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
        #region Old code by Aot
        /*private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (this.sS_MaskedTextBox_DeptID.Text != "")
            {
                string StrNo, StrName;
                StrNo = sS_MaskedTextBox_DeptID.Text;
                StrName = sS_MaskedTextBox_DeptName.Text;
                //Form_005008_PrintBarcodeAsset frm = new Form_005008_PrintBarcodeAsset();
                //frm.Show();
                //frm.GetDepartmentforPrint(StrNo, StrName);

                Prints cmdPrint = new Prints();
                bool Printresult = cmdPrint.PrintCustomer(StrNo, "Department No:", "Department Name:", StrName);
                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Department Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Department Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
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
                    if (this.sS_MaskedTextBox_DeptID.Text != "")
                    {

                        StrNo = sS_MaskedTextBox_DeptID.Text;
                        StrName = sS_MaskedTextBox_DeptName.Text;
                        pd.Print();

                        SS_MyMessageBox.ShowBox("Printing Department Barcode : " + StrNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);


                    }
                    else {
                        SS_MyMessageBox.ShowBox("Printing Department Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                    }
                }
            }

            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Printing Department Barcode : " + StrNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
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
                e.Graphics.DrawImage(bar, 1, std + 60);
                e.Graphics.DrawString("Department No:", printFont4, br, 5, std + 30);
                e.Graphics.DrawString(StrNo, printFont4, br, 75, std + 30);

                e.Graphics.DrawString("Department Name:", printFont4, br, 5, std + 43);
                e.Graphics.DrawString(StrName, printFont4, br, 90, std + 43);

            }
            catch (Exception Err)
            {

                throw new Exception("pd_PrintPage(): " + Err.Message);
            }
        }


        private void Form_005006_Barcode_Department_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

    
    }
}