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
    public partial class Form_005001_Barcode_Asset : SS_PaintGradientForm
    {   
        //  New ///
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;
        //  New ///

        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        FormatBarcodeAssetHome FormatBarcodeAssetHomeObj = new FormatBarcodeAssetHome();
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;

        public Form_005001_Barcode_Asset()
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
                this.Text = Global.Function_Language(this, this, "ID:005001(BarcodeAsset)");
                label_AssetID.Text = Global.Function_Language(this, label_AssetID, "AssetID.");
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
                object[] Obj_AssetNo = new object[1] { sS_MaskedTextBox_AssetID.Text };
                object[] Obj_AssetRow = new object[1] { sS_DataGridView_BarcodeAsset.SelectedRows.Count };
                switch (Enm_mode)
                {
            //        case Enum_Mode.Search:
            //            break;

            //        case Enum_Mode.PreAdd:
            //            Function_ClearData();
            //            sS_MaskedTextBox_AssetID.Focus();
            //            sS_MaskedTextBox_Remark.ReadOnly = false;
            //            Enm_StateForm = Enum_Mode.PreAdd;
            //            break;

            //        case Enum_Mode.Add:

            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.AssetID = sS_MaskedTextBox_AssetID.Text;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.BarCode = sS_MaskedTextBox_AssetID.Text;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.Position = 1;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.Remark = sS_MaskedTextBox_Remark.Text;

            //            string SQL = "AssetID = '" + sS_MaskedTextBox_AssetID.Text + "' AND Position = '" + FormatBarcodeAssetHomeObj.BarcodeAssetObj.Position + "'";
            //            OPathQuery<FormatBarCodeAsset> TempFormatBarCodeAssetObj = new OPathQuery<FormatBarCodeAsset>(SQL);

            //            FormatBarCodeAsset FormatBarCodeAssetObj = new FormatBarCodeAsset();
            //            FormatBarCodeAssetObj = Manager.Engine.GetObject<FormatBarCodeAsset>(TempFormatBarCodeAssetObj);
            //            if(FormatBarCodeAssetObj !=null)
            //            {
            //                SS_MyMessageBox.ShowBox("AssetNo : " + sS_MaskedTextBox_AssetID.Text + " is duplicate data", "Warning", DialogMode.OkOnly,this.Name,"000008",Obj_AssetNo,Global.Lang.Str_Language);
            //                Global.Bool_CheckComplete = false;
            //                sS_MaskedTextBox_AssetID.Focus();
            //                break;
            //            }
            //            if (FormatBarcodeAssetHomeObj.Add())
            //            {
            //                SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_AssetID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_AssetNo, Global.Lang.Str_Language);
            //                Global.Bool_CheckComplete = true;

            //                Enm_StateForm = Enum_Mode.PreAdd;
            //                Function_ExecuteTransaction(Enum_Mode.Cancel);
            //                //goto DEFAULT;
            //            }
            //            else
            //            {
            //                goto ERRORADD;
            //            }
            //            break;
            //        case Enum_Mode.PreEdit:
            //            Function_SetReadOnlyControl(false);
            //            sS_MaskedTextBox_Remark.Focus();
            //            Enm_StateForm = Enum_Mode.PreEdit;
            //            break;
            //        case Enum_Mode.Edit:

            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.AssetID = sS_MaskedTextBox_AssetID.Text;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.BarCode = sS_MaskedTextBox_AssetID.Text;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.Position = 1;
            //            FormatBarcodeAssetHomeObj.BarcodeAssetObj.Remark = sS_MaskedTextBox_Remark.Text;

            //            if (FormatBarcodeAssetHomeObj.Edit())
            //            {
            //                SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_AssetID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_AssetNo, Global.Lang.Str_Language);
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
            //            if (sS_DataGridView_BarcodeAsset.SelectedRows.Count > 1)
            //            {
            //                List<FormatBarCodeAsset> BarCodeAssetCollection = new List<FormatBarCodeAsset>();
            //                FormatBarCodeAsset TempBarCodeAsset = new FormatBarCodeAsset();
            //                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_BarcodeAsset.SelectedRows)
            //                {
            //                    string Str_SQL = "AssetID ='" + TempDataGridRow.Cells[0].Value.ToString() + "' AND Position = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
            //                    OPathQuery<FormatBarCodeAsset> OpathBarCodeAsset = new OPathQuery<FormatBarCodeAsset>(Str_SQL);
            //                    TempBarCodeAsset = Manager.Engine.GetObject<FormatBarCodeAsset>(OpathBarCodeAsset);
            //                    BarCodeAssetCollection.Add(TempBarCodeAsset);
            //                }

            //                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_BarcodeAsset.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000011", Obj_AssetRow, Global.Lang.Str_Language) == DialogResult.OK)
            //                {

            //                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

            //                    if (FormatBarcodeAssetHomeObj.Delete(ORTransaction, BarCodeAssetCollection))
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
            //                if (sS_MaskedTextBox_AssetID.Text != "")
            //                {
            //             //       if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_AssetID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_AssetNo, Global.Lang.Str_Language) == DialogResult.OK)
            //             //       {
            //             //           Global.Bool_CheckComplete = true;
            //             //   //        FormatBarcodeAssetHomeObj.BarcodeAssetObj.AssetID = sS_MaskedTextBox_AssetID.Text;

            //             //  //         if (FormatBarcodeAssetHomeObj.Delete())
            //             //           {
            //             //               SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_AssetID.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_AssetNo, Global.Lang.Str_Language);
            //             //               Global.Bool_CheckComplete = true;
            //             //    //           Enm_StateForm = Enum_Mode.PreAdd;
            //             //               Function_ShowDataInDatagridView();
            //             //           }
            //             ////           else
            //             //           {
            //             //               SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AssetID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_AssetNo, Global.Lang.Str_Language);
            //             //               Global.Bool_CheckComplete = false;

            //             //         //      Enm_StateForm = Enum_Mode.PreEdit;
            //             //           }
            //                        Function_ExecuteTransaction(Enum_Mode.Cancel);
            //                    }
            //                    else
            //                    {
            //                        Global.Bool_CheckComplete = false;
            //                       // Enm_StateForm = Enum_Mode.PreEdit;
            //                        Function_ExecuteTransaction(Enum_Mode.Cancel);
            //                    }
            //                    //goto DEFAULT;
            //                }
            //                else
            //                    Global.Bool_CheckComplete = false;
            //            }
            //                break;
                    case Enum_Mode.ShowData:
                        if (sS_DataGridView_BarcodeAsset.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_AssetID.ReadOnly = true;
                       //     sS_MaskedTextBox_AssetID.Text = sS_DataGridView_BarcodeAsset[0, sS_DataGridView_BarcodeAsset.CurrentRow.Index].Value.ToString();
                       //     FormatBarCodeAsset FormatBarcodeAssetObj = new FormatBarCodeAsset();
                            //FormatBarcodeAssetObj = Manager.Engine.GetObject<FormatBarCodeAsset>(sS_MaskedTextBox_AssetID.Text);
                            //if (FormatBarcodeAssetObj != null)
                            //{
                            //    sS_MaskedTextBox_AssetName.Text = Global.FormOrder.Function_GetAssetName(sS_MaskedTextBox_AssetID.Text);
                            //    sS_MaskedTextBox_Remark.Text = FormatBarcodeAssetObj.Remark;
                            //}
                            sS_MaskedTextBox_AssetID.Focus();
                        }
                        break;
            //        case Enum_Mode.Cancel:
            //            //if (Enm_StateForm == Enum_Mode.PreEdit)
            //            //{
            //            //    Function_ExecuteTransaction(Enum_Mode.ShowData);
            //            //    sS_MaskedTextBox_AssetID.Focus();
            //            //}
            //            //if (Enm_StateForm == Enum_Mode.PreAdd)
            //            //{
            //            //    Function_ClearData();
            //            //    sS_MaskedTextBox_AssetID.Focus();
            //            //    Function_ShowDataInDatagridView();
            //            //}
            //            //Function_SetReadOnlyControl(true);
            //            //Enm_StateForm = Enum_Mode.Search;
            //            //break;

            //        DEFAULT:
            //            Function_ClearData();
            //            Function_ShowDataInDatagridView();
            //            sS_MaskedTextBox_AssetID.Focus();
            //            Enm_StateForm =Enum_Mode.Search;
            //            break;

            //        ERRORADD:
            //            SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_AssetID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_AssetNo, Global.Lang.Str_Language);
            //            Global.Bool_CheckComplete = false;
            //            break;
            //        ERROREDIT:
            //            SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_AssetID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_AssetNo, Global.Lang.Str_Language);
            //            Global.Bool_CheckComplete = false;
            //            break;
                }

            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On BarCode Asset Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }

        private void Function_ClearData()
        {
            sS_MaskedTextBox_AssetID.Text = "";
            sS_MaskedTextBox_AssetName.Text = "";
            sS_MaskedTextBox_Remark.Text = "";
           }

        private void Function_SetReadOnlyControl(bool Bool_CheckStateControl)
        {
            sS_MaskedTextBox_AssetID.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_AssetName.ReadOnly = Bool_CheckStateControl;
            sS_MaskedTextBox_Remark.ReadOnly = Bool_CheckStateControl;

        }

        private void Function_ShowDataInDatagridView()
        {
            DataSet Ds = new DataSet();
            Ds = Manager.Engine.GetDataSet<FormatBarCodeAsset>("");
            sS_DataGridView_BarcodeAsset.DataSource = Ds;
            sS_DataGridView_BarcodeAsset.DataMember = "Table";
            Ds.Dispose();
            Ds = null;
        }

        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            //if ((e.KeyCode ==Keys.F1)&&(Enm_StateForm == Enum_Mode.PreAdd))
            if (e.KeyCode ==Keys.F1)
            {
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetID;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;
                Frm_Present.Show_Data("Screen", "005001_01");

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
            sS_MaskedTextBox_AssetID.ReadOnly = false;
            sS_MaskedTextBox_AssetID.Focus();
        }

        private void sS_DataGridView_BarcodeAsset_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            //Enm_StateForm = Enum_Mode.CellClick;
            //AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            if (sS_MaskedTextBox_AssetID.Text != "")
            {
                string AssetNo, AssetName, BU, Date, Dept;
                // Asset Info
                AssetNo = sS_MaskedTextBox_AssetID.Text;
                // Edit on 19-02-09 for CEVA ,Use short Name of Asset
              //  AssetName = sS_MaskedTextBox_AssetName.Text;
                string str_qry = "SELECT Customfiled9 FROM Asset WHERE AssetID = '" + sS_MaskedTextBox_AssetID.Text.ToString().Trim() + "' ";
                DataSet dsSname = Manager.Engine.GetDataSet(str_qry);
                if (dsSname.Tables[0].Rows.Count > 0 && dsSname.Tables[0].Rows[0][0].ToString() != "" && dsSname.Tables[0].Rows[0][0].ToString() != "NULL")
                 {
                     AssetName = dsSname.Tables[0].Rows[0][0].ToString().Trim();
                 }
                 else
                 {
                     AssetName = sS_MaskedTextBox_AssetName.Text;
                 }
                /////////////////////////////////////////////////
                Asset TempObj = new Asset();
                TempObj = Manager.Engine.GetObject<Asset>(AssetNo);

                // BU Info
                string bId = Convert.ToString(TempObj.BuildID);
                Building BUObj = new Building();
                BUObj = Manager.Engine.GetObject<Building>(bId);
                BU = Convert.ToString(BUObj.BuildName);

                // Edit for CEVA on 12/11/08
                //Department Info
                string dId = Convert.ToString(TempObj.DeptID);
                Department DepObj = new Department();
                DepObj = Manager.Engine.GetObject<Department>(dId);
                Dept = Convert.ToString(DepObj.DeptName);


                // Invoice Info
              //  Date = Convert.ToString(TempObj.CreatedDate).Replace("0:00:00","");
                string sql = "SELECT Customfiled4 From Asset WHERE AssetID = '" + AssetNo + "' ";
                DataSet ds_sql = Manager.Engine.GetDataSet(sql);
                if (ds_sql.Tables[0].Rows.Count > 0)
                {
                    Date = Convert.ToString(ds_sql.Tables[0].Rows[0][0].ToString());
                    Date = Date.Substring(0, 10);
                    ds_sql.Dispose();
                }
                else
                {
                    Date = "-";
                }


              // Date = Convert.ToString(TempObj.CreatedDate.ToShortDateString());
               
               
                // Original Version
               // Form_005009_Barcode frm_new = new Form_005009_Barcode();
               //frm_new.Show();
               //frm_new.GetAsseforPrint(AssetNo, AssetName, BU ,Date);
                //** END 

                // Call  CaptureScreen()
               // CaptureScreen();
               Prints cmdPrint = new Prints();
               // bool Printresult= cmdPrint.PrintInform(AssetNo, BU, Date, AssetNo, AssetName);
               bool Printresult = cmdPrint.PrintInform(AssetNo, Dept, Date, AssetNo, AssetName);

                if (Printresult == true)
                {
                    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                }  
            }
        }

        private void Form_005001_Barcode_Asset_FormClosing(object sender, FormClosingEventArgs e)
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

        
        private void Function_ShowDataSerchKey()
        {
            try
            {
                DataSet Ds = new DataSet();
                string str_val = sS_MaskedTextBox_AssetID.Text.ToString().Trim();

                string SQL = "SELECT AssetID,AssetName FROM Asset WHERE AssetID = '" + str_val + "' ";

                Ds = Manager.Engine.GetDataSet(SQL);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    sS_MaskedTextBox_AssetID.Text = Ds.Tables[0].Rows[0][0].ToString().Trim();
                    sS_MaskedTextBox_AssetName.Text = Ds.Tables[0].Rows[0][1].ToString().Trim();
                    Ds.Dispose();
                    Ds = null;

                }
                else
                {
                    SS_MyMessageBox.ShowBox("Can't found Asset ID:'" + sS_MaskedTextBox_AssetID.Text + "'");
                }

                sS_MaskedTextBox_AssetID.Focus();
                sS_MaskedTextBox_AssetID.SelectAll();
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void sS_MaskedTextBox_AssetID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataSerchKey();

            }

        }

    
    }
}