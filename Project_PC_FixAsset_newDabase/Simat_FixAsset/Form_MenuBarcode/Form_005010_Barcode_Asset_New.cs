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
using System.Drawing.Printing;

namespace SimatSoft.FixAsset
{
    public partial class Form_005010_Barcode_Asset_New : Form
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.ShowData;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        string AssetNo;
        string AssetName;
        string BU;
        string Date;
        string Dept;
        public static PrintDialog pd = null;

        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;
                
        public Form_005010_Barcode_Asset_New()
        {
            InitializeComponent();
        }

        private void Form_005001_Barcode_Asset_New_Load(object sender, EventArgs e)
        {
            try
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
                sS_MaskedTextBox_AssetID.Focus();


                AddHeaderCheckBox();
                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                dgvAssetList.CellValueChanged += new DataGridViewCellEventHandler(dgvAssetList_CellValueChanged);
                dgvAssetList.CurrentCellDirtyStateChanged += new EventHandler(dgvAssetList_CurrentCellDirtyStateChanged);
                dgvAssetList.CellPainting += new DataGridViewCellPaintingEventHandler(dgvAssetList_CellPainting);
                
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Form_005001_Barcode_Asset_New_Load: " + Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void Function_ClearData()
        {
            sS_MaskedTextBox_AssetID.Text = "";
            sS_MaskedTextBox_AssetIDTo.Text = "";
            this.dgvAssetList.DataSource = null;
        }

        private void sS_ButtonGlass1_Click(object sender, EventArgs e)
        {
            Function_ShowData();
            //TotalCheckBoxes = dgvAssetList.Rows.Count;
            TotalCheckBoxes = dgvAssetList.RowCount;
            TotalCheckedCheckBoxes = 0;
        }
        private void SetDatagridAssetList()
        {
            dgvAssetList.Columns[0].Width = 50;
            dgvAssetList.Columns[1].Width = 50;
            dgvAssetList.Columns[1].ReadOnly = true;
            dgvAssetList.Columns[2].Width = 150;
            dgvAssetList.Columns[2].ReadOnly = true;
            dgvAssetList.Columns[3].Width = 180;
            dgvAssetList.Columns[3].ReadOnly = true;
            dgvAssetList.Columns[4].Width = 120;
            dgvAssetList.Columns[4].ReadOnly = true;
            dgvAssetList.Columns[5].Width = 100;
            dgvAssetList.Columns[5].ReadOnly = true;

        }
        private void Function_ShowData()
        {
            try
            {
                DataSet Ds = new DataSet ();
                string strAssetB = sS_MaskedTextBox_AssetID.Text.ToString().Trim();
                string strAssetF = sS_MaskedTextBox_AssetIDTo.Text.ToString().Trim();

                string SQL = "SELECT RANK() OVER (ORDER BY Asset.AssetID) as 'No.', Asset.AssetID,Asset.AssetName,Asset.ModelID,Model.Modelname,Asset.WarrantyEndDate" +
                            " FROM Asset INNER JOIN Model ON Asset.ModelID = Model.ModelID " +
                            " WHERE Asset.AssetID >= '" + strAssetB + "' AND Asset.AssetID <= '" + strAssetF + "'" +
                            " ORDER BY 'No.'";

                Ds = Manager.Engine.GetDataSet(SQL);

                if (Ds.Tables[0].Rows.Count > 0)
                {                                       
                    dgvAssetList.DataSource = Ds;
                    dgvAssetList.DataMember = "Table";
                    SetDatagridAssetList(); 
                }
                else
                {
                    SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                }
                Ds.Dispose();
                Ds = null;
           }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        #region old ButtonPrint_Click  by Aot
        /*private void sS_ButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintDialog printDialog = new PrintDialog();
                //printDialog.UseEXDialog = true;
                //printDialog.ShowDialog();

                    pd = new PrintDialog();
                    pd.UseEXDialog = true;
                    pd.PrinterSettings = new PrinterSettings();
                    if (DialogResult.OK == pd.ShowDialog())
                    {                      
                        for (int i = 0; i < dgvAssetList.Rows.Count; i++)
                        {
                            DataGridViewCell cell = dgvAssetList.Rows[i].Cells[0];
                            bool isChecked = (bool)cell.EditedFormattedValue;

                            if (isChecked)
                            {
                                //Checkbox is being checked 

                                string AssetNo, AssetName, BU, Date, Dept;
                                // *************Asset Info******************
                                AssetNo = dgvAssetList.Rows[i].Cells[2].Value.ToString();
                                string str_qry = "SELECT Customfiled9 FROM Asset WHERE AssetID = '" + AssetNo + "' ";
                                DataSet dsSname = Manager.Engine.GetDataSet(str_qry);
                                if (dsSname.Tables[0].Rows.Count > 0 && dsSname.Tables[0].Rows[0][0].ToString() != "" && dsSname.Tables[0].Rows[0][0].ToString() != "NULL")
                                {
                                    AssetName = dsSname.Tables[0].Rows[0][0].ToString().Trim();
                                }
                                else
                                {
                                    AssetName = dgvAssetList.Rows[i].Cells[3].Value.ToString();
                                }
                                //***************************************

                                // *************AssetNo Info******************
                                Asset TempObj = new Asset();
                                TempObj = Manager.Engine.GetObject<Asset>(AssetNo);

                                // BU Info
                                string bId = Convert.ToString(TempObj.BuildID);
                                Building BUObj = new Building();
                                BUObj = Manager.Engine.GetObject<Building>(bId);
                                BU = Convert.ToString(BUObj.BuildName);
                                //***************************************

                                //*************Department Info*************
                                string dId = Convert.ToString(TempObj.DeptID);
                                Department DepObj = new Department();
                                DepObj = Manager.Engine.GetObject<Department>(dId);
                                Dept = Convert.ToString(DepObj.DeptName);
                                //***************************************

                                //*************Invoice Info*************               
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
                                //***************************************

                                Prints cmdPrint = new Prints();
                                bool Printresult = cmdPrint.PrintInform(AssetNo, Dept, Date, AssetNo, AssetName);

                                //Amended by Aun on 14.12.2009
                                //if (Printresult == true)
                                if (Printresult == false)
                                {
                                    //SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " Complete. ", "Print Data Information", DialogMode.OkOnly);
                                    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                                }
                                //else
                                //{
                                //    SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
                                //}

                            }//End if 

                        }//End for loop
                        SS_MyMessageBox.ShowBox("Printing Complete!. ", "Print Data Information", DialogMode.OkOnly);
                }//End if for show dialog
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }*/
        #endregion end old ButtonPrint_Click  by Aot

        //New ButtonPrint_Click by Aot
        private void sS_ButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //PrintDialog printDialog = new PrintDialog();
                //printDialog.UseEXDialog = true;
                //printDialog.ShowDialog();
                /*pd = new PrintDialog();
                pd.UseEXDialog = true;
                pd.PrinterSettings = new PrinterSettings();*/

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

                    for (int i = 0; i < dgvAssetList.Rows.Count; i++)
                    {
                        DataGridViewCell cell = dgvAssetList.Rows[i].Cells[0];
                        bool isChecked = (bool)cell.EditedFormattedValue;

                        if (isChecked)
                        {
                            //Checkbox is being checked 

                           
                            // *************Asset Info******************
                            AssetNo = dgvAssetList.Rows[i].Cells[2].Value.ToString();
                            string str_qry = "SELECT Customfiled9 FROM Asset WHERE AssetID = '" + AssetNo + "' ";
                            DataSet dsSname = Manager.Engine.GetDataSet(str_qry);
                            if (dsSname.Tables[0].Rows.Count > 0 && dsSname.Tables[0].Rows[0][0].ToString() != "" && dsSname.Tables[0].Rows[0][0].ToString() != "NULL")
                            {
                                AssetName = dsSname.Tables[0].Rows[0][0].ToString().Trim();
                            }
                            else
                            {
                                AssetName = dgvAssetList.Rows[i].Cells[3].Value.ToString();
                            }
                            //***************************************

                            // *************AssetNo Info******************
                            Asset TempObj = new Asset();
                            TempObj = Manager.Engine.GetObject<Asset>(AssetNo);

                            // BU Info
                            string bId = Convert.ToString(TempObj.BuildID);
                            Building BUObj = new Building();
                            BUObj = Manager.Engine.GetObject<Building>(bId);
                            BU = Convert.ToString(BUObj.BuildName);
                            //***************************************

                            //*************Department Info*************
                            string dId = Convert.ToString(TempObj.DeptID);
                            Department DepObj = new Department();
                            DepObj = Manager.Engine.GetObject<Department>(dId);
                            Dept = Convert.ToString(DepObj.DeptName);
                            //***************************************

                            //*************Invoice Info*************               
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
                            
                        pd.Print();
                        }//End if 
                        
                    
                    }//End for loop
                    
                    SS_MyMessageBox.ShowBox("Printing Complete!. ", "Print Data Information", DialogMode.OkOnly);
                }//End if for show dialog
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("Printing Asset Barcode : " + AssetNo + " incomplet !! ", "Print Data Information", DialogMode.OkOnly);
            }
        }

        private void sS_ButtonExit_Click(object sender, EventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
            this.Dispose();
            this.Close();
        }
        private void AddHeaderCheckBox()
        {
            try
            {
                HeaderCheckBox = new CheckBox();
                HeaderCheckBox.Size = new Size(15, 15);

                //Add the CheckBox into the DataGridView
                this.dgvAssetList.Controls.Add(HeaderCheckBox);
            }
            catch (Exception Err)
            {
                throw new Exception("AddHeaderCheckBox(): " + Err.Message);
            }
        }


        //******************************AOT*****************************************************
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
                ////
                System.Drawing.Image bar = b.Encode(BarcodeLib.TYPE.CODE128, AssetNo, 150, 25);

                e.Graphics.DrawString(Date, printFont4, br, 135, std + 5);
                e.Graphics.DrawString(AssetName, printFont4, br, 25  , std + 30);
                e.Graphics.DrawString(Dept, printFont4, br, 25, std + 43);
                //e.Graphics.DrawString(Dept, printFont4, br, 75 + BU.Length* 3 , std + 43 );

                e.Graphics.DrawString(AssetNo, printFont2, br, 40 + AssetNo.Length * 3, std + 50);
                e.Graphics.DrawImage(bar, 1, std + 65);//270);
                



            }
            catch (Exception Err)
            {
                
                throw new Exception("pd_PrintPage(): " + Err.Message);
            }
        }


        //******************************AOT*****************************************************
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                HeaderCheckBoxClick((CheckBox)sender);
            }
            catch (Exception Err)
            {
                throw new Exception("HeaderCheckBox_MouseClick: " + Err.Message);
            }
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                    HeaderCheckBoxClick((CheckBox)sender);
            }
            catch (Exception Err)
            {
                throw new Exception("HeaderCheckBox_KeyUp: " + Err.Message);
            }
        }

        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            try
            {
                IsHeaderCheckBoxClicked = true;

                foreach (DataGridViewRow Row in dgvAssetList.Rows)
                    ((DataGridViewCheckBoxCell)Row.Cells["ColChk"]).Value = HCheckBox.Checked;

                dgvAssetList.RefreshEdit();

                //TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;           

                IsHeaderCheckBoxClicked = false;
            }
            catch (Exception Err)
            {
                throw new Exception("HeaderCheckBoxClick: " + Err.Message);
            }
        }
        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            try
            {
                //Get the column header cell bounds
                Rectangle oRectangle = this.dgvAssetList.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

                Point oPoint = new Point();

                oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
                oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

                //Change the location of the CheckBox to make it stay on the header
                HeaderCheckBox.Location = oPoint;
            }
            catch (Exception Err)
            {
                throw new Exception("ResetHeaderCheckBoxLocation: " + Err.Message);
            }
        }
        private void RowCheckBoxClick(DataGridViewCheckBoxCell RCheckBox)
        {
            try
            {
                if (RCheckBox != null)
                {
                    //TotalCheckedCheckBoxes = RCheckBox.Value.ToString().
                    //Modifiy Counter;            
                    if ((bool)RCheckBox.Value && TotalCheckedCheckBoxes < TotalCheckBoxes)
                        TotalCheckedCheckBoxes++;
                    else if (TotalCheckedCheckBoxes > 0)
                        TotalCheckedCheckBoxes--;

                    //Change state of the header CheckBox.
                    if (TotalCheckedCheckBoxes < TotalCheckBoxes)
                        HeaderCheckBox.Checked = false;
                    else if (TotalCheckedCheckBoxes == TotalCheckBoxes)
                        HeaderCheckBox.Checked = true;
                }
            }
            catch (Exception Err)
            {
                throw new Exception("RowCheckBoxClick: " + Err.Message);
            }
        }

        private void dgvAssetList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0)
                    ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
            }
            catch (Exception Err)
            {
                throw new Exception("dgvAssetList_CellPainting: " + Err.Message);
            }
        }

        private void dgvAssetList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!IsHeaderCheckBoxClicked)
                    RowCheckBoxClick((DataGridViewCheckBoxCell)dgvAssetList[e.ColumnIndex, e.RowIndex]);
            }
            catch (Exception Err)
            {
                throw new Exception("dgvAssetList_CellValueChanged: " + Err.Message);
            }
        }

        private void dgvAssetList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvAssetList.CurrentCell is DataGridViewCheckBoxCell)
                    dgvAssetList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception Err)
            {
                throw new Exception("dgvAssetList_CurrentCellDirtyStateChanged: " + Err.Message);
            }
        }

        private void sS_MaskedTextBox_AssetID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetID;
                    //Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;
                    Frm_Present.Show_Data("Screen", "005001_01");

                    Frm_Present.ShowDialog();
                    Frm_Present.Dispose();
                }
            }
            catch (Exception Err)
            {
                throw new Exception("sS_MaskedTextBox_AssetID_KeyDown: " + Err.Message);
            }
        }

        private void sS_MaskedTextBox_AssetIDTo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetIDTo;
                    //Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;
                    Frm_Present.Show_Data("Screen", "005001_01");

                    Frm_Present.ShowDialog();
                    Frm_Present.Dispose();
                }
            }
            catch (Exception Err)
            {
                throw new Exception("sS_MaskedTextBox_AssetIDTo_KeyDown: " + Err.Message);
            }
        }

        private void Form_005010_Barcode_Asset_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_005010_Barcode_Asset_New_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_005010_Barcode_Asset_New_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }
    }
}