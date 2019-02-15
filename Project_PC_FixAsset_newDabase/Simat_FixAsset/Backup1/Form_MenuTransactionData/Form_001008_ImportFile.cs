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
using System.IO;
using Wilson.ORMapper;
using System.Text.RegularExpressions;
using System.Collections;

namespace SimatSoft.FixAsset
{
    public partial class Form_001008_ImportFile : SS_PaintGradientForm
    {
        public object ind = Global.IndexArray.Add(0);
        OpenFileDialog fdlg = new OpenFileDialog();
        private string STR_FileType;
        //private bool Bool_CheckImport = false;
        string STR_PathImport;//"C:\\Import\\" 
        private string STR_Path;

        StreamReader tx;
        AssetHome AssetHomeObj = new AssetHome();
        VendorHome VendorHomeObj = new VendorHome();
        BuildingHome BuildingHomeObj = new BuildingHome();
        FloorHome FloorHomeObj = new FloorHome();
        AreaHome AreaHomeObj = new AreaHome();


        private Enum_Mode Enm_StateForm = Enum_Mode.Import;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_001008_ImportFile()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Import);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:001008(ImportFile)");
            LBL_FilePath.Text = Global.Function_Language(this, LBL_FilePath, "File Path:");
            LBL_Company.Text = Global.Function_Language(this, LBL_Company, "Company:");
            LBL_FileType.Text = Global.Function_Language(this, LBL_FileType, "File Type:");
            checkBox_Asset.Text = Global.Function_Language(this, checkBox_Asset, "Asset");
            checkBox_PurchaseOrder.Text = Global.Function_Language(this, checkBox_PurchaseOrder, "Purchase Order");
            checkBox_Supplier.Text = Global.Function_Language(this, checkBox_Supplier, "Supplier");
            checkBox_Building.Text = Global.Function_Language(this, checkBox_Building, "Building");
            checkBox_Area.Text = Global.Function_Language(this, checkBox_Area, "Area");
            checkBox_Floor.Text = Global.Function_Language(this, checkBox_Floor, "Floor");
            sS_ButtonGlass_Browse.Text = Global.Function_Language(this, sS_ButtonGlass_Browse, "Browse");
        }

        private void Form_001004_ImportFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                switch (mode)
                {
                    case Enum_Mode.Import:
                        {
                            if (this.sS_MaskedTextBox_FacCode.Text != "")
                            {
                                Class_CheckMaster.Str_TempFacCode = sS_MaskedTextBox_FacCode.Text;
                                STR_FileType = this.sS_ComboBox_FileType.Text;
                                ind = Global.IndexArray.Add(1);
                                if (STR_PathImport == null)
                                {
                                    SS_MyMessageBox.ShowBox("file does not exists", "Error", DialogMode.OkOnly);
                                    return;
                                }
                                else
                                {
                                    if ((TableOfImport == "") || (TableOfImport == null))
                                    {
                                        SS_MyMessageBox.ShowBox("You does not choose table for import", "Information", DialogMode.OkOnly);
                                        break;
                                    }
                                    if ((STR_FileType != null) && (TableOfImport != ""))
                                    {
                                        readFile1(Function_FileType(STR_FileType));
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("You does not choose file type", "Information", DialogMode.OkOnly);
                                    }
                                }
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Please Key Company No.", "Information", DialogMode.OkOnly);
                            }
                        }
                        break;
                }

            }
            catch (ArgumentNullException)
            {
                SS_MyMessageBox.ShowBox("File type not match file", "Error", DialogMode.Error_Cancel);
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void sS_ButtonGlass_Browse_Click(object sender, EventArgs e)
        {
            fdlg.Title = "Browse";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sS_MaskedTextBox_PathFile.Text = fdlg.FileName;
                    STR_PathImport = sS_MaskedTextBox_PathFile.Text;
                  
                }
                catch (Exception Err)
                {
                    SS_MyMessageBox.ShowBox("Unable to load file: " + Err.Message, "Error", DialogMode.Error_Cancel);
                }
                fdlg.Dispose();
            }
        }

        private void sS_ButtonGlass_Import_Click(object sender, EventArgs e)
        {
            try
            {
                        if (File.Exists(STR_PathImport))
                        {
                            SS_MyMessageBox.ShowBox("file does not exists", "Error", DialogMode.OkOnly);
                            return;
                        }
                        else
                        {
                            if (TableOfImport == null)
                            {
                                
                                SS_MyMessageBox.ShowBox("You does not choose table for import", "Information", DialogMode.OkOnly);

                            }
                            if ((STR_FileType != null) && (TableOfImport != null))
                            {
                                readFile(Function_FileType(STR_FileType));
                            }
                        }
                    
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            { }
        }

        private string Function_FileType(string strFileType)
        {
            string STR_TempPath;
            string STR_TempFileType;

            STR_TempFileType = (STR_PathImport.ToString().Substring(STR_PathImport.Length-3,3)).ToUpper();
            if (strFileType == STR_TempFileType)
            {
                strFileType = STR_TempFileType;
                switch (strFileType)
            {
                case "CSV":
                    STR_Path = STR_PathImport;
                    break;
                case "XLS":
                    STR_Path = STR_PathImport;
                    break;
                case "TXT":
                    STR_Path = STR_PathImport;
                    break;
            }              
            return STR_TempPath = STR_Path;
            }
            else
            {
                return STR_Path = null;
            }
            
          
        }

        private String line="";
        //private void readFile(String filePath)
        //{
        //    tx = new StreamReader(filePath);
        //    while ((line = tx.ReadLine()) != null)
        //    {
        //        Function_Table(TableOfImport);
        //        //parseData(line);
        //    }
        //    SS_MyMessageBox.ShowBox("Insert Data Complete","Information",DialogMode.OkOnly);
        //    tx.Close();
            
       ///}


        /// <summary>
        /// readline of file import
        /// </summary>
        /// <param name="filePath"></param>
        private void readFile1(String filePath)
        {
            String STR_TempInputString = "";
            StreamReader read = File.OpenText(filePath);

            //Int_Index = STR_PathImport.LastIndexOf("\\", STR_PathImport.Length);
            //Int_Temp = STR_PathImport.Length-(Int_Index+1);        
            //Str_TempFileImport = (STR_PathImport.ToString().Substring(Int_Index +1,Int_Temp));
            //Int_Index1 = Str_TempFileImport.LastIndexOf(".", Str_TempFileImport.Length);
            //Str_TempFileImport =(Str_TempFileImport.ToString().Substring(0,Int_Index1));

            //if (Str_TempFileImport != TableOfImport)
            //{
            //    SS_MyMessageBox.ShowBox("File not match Table of choose", "Warning", DialogMode.OkOnly);
            //}
            //else
            //{
            int Int_CountRecord = 0;
            while ((STR_TempInputString = read.ReadLine()) != null)
            {
                String[] strCheckData = STR_TempInputString.Split(',');
                if (strCheckData[0] != "")
                {
                    if (Int_CountRecord > 0)
                    {
                        STR_TempInputString = STR_TempInputString.Replace(",,", ",-,");
                        String[] sepData = STR_TempInputString.Split(',');

                        for (int i = 0; i <= sepData.Length - 1; i++)
                        {
                            if (sepData[i].Trim() == "")
                            {
                                sepData[i] = "-";

                            }
                            if (i == 0)
                            {
                                STR_TempInputString = sepData[i];
                            }
                            else
                            {
                                STR_TempInputString = STR_TempInputString + "," + sepData[i];
                            }

                        }
                        STR_TempInputString = STR_TempInputString + "," + this.sS_MaskedTextBox_FacCode.Text;
                        //STR_TempInputString = STR_TempInputString.Replace(",,", ",null,");
                        ParseCSV(STR_TempInputString);
                        //SS_MyMessageBox.ShowBox("Insert data complete", "Information", DialogMode.OkOnly);
                    }

                }
                else
                {
                    Int_CountRecord = 0;
                    break;
                }
                Int_CountRecord++;
                
            }
            SS_MyMessageBox.ShowBox("Insert data complete", "Information", DialogMode.OkOnly); 
        }

        /// <summary>
        /// real all record of file by read to end of file
        /// </summary>
        /// <param name="filePath"></param>
        private void readFile(String filePath)
        {
            String STR_TempInputString = "";
            
            tx = new StreamReader(filePath);
            
            STR_TempInputString = tx.ReadToEnd();
            tx.Close();
            

            STR_TempInputString = STR_TempInputString.Replace(",,", ",null,");
            ParseCSV(STR_TempInputString);
        }

        private DateTime Function_ConvertYear(string Str_TempYear)
        {
            string Str_Temp="";
            //DateTime DateTime;
            if (Str_TempYear != "-")
            {
                DateTime Temp_DateTime = Convert.ToDateTime(Str_TempYear);
                int Int_Year;
                if (Str_TempYear != "")
                {

                    Int_Year = Convert.ToInt32(Temp_DateTime.Year.ToString());
                    Str_Temp = Temp_DateTime.Day.ToString("00") + "/" + Temp_DateTime.Month.ToString("00") + "/" + Int_Year.ToString("0000");
                }        
            }
            else
            {
                
                //Str_Temp = DBNull.Value.ToString();
               
            }
            return Convert.ToDateTime(Str_Temp);
                
        }
        private DateTime Function_ConvertYearlocal(string Str_TempYear)
        {
            string Str_Temp = "";
             DateTime Temp_DateTime= DateTime.Now  ;
            //DateTime DateTime;
            if (Str_TempYear != "-")
            {
               Temp_DateTime = Convert.ToDateTime(Str_TempYear);
                // Edit on 23-02-09
                //Temp_DateTime = DateTime.Parse(Convert.ToDateTime(Str_TempYear).ToString("dd/MM/yyyy HH:mm:ss tt"));
               
                int Int_Year;
                //if (Str_TempYear != "")
                //{

                    
                //    Str_Temp = Temp_DateTime.Day.ToString("00") + "/" + Temp_DateTime.Month.ToString("00") + "/" + Temp_DateTime.Year.ToString();
                //}
            }
            else
            {
                Temp_DateTime =  new DateTime(1990,1,1) ; 
                //Str_Temp = DBNull.Value.ToString();

            }
            return Temp_DateTime;

        }

        private Decimal Function_ConvertToDecimal(string Str_Temp)
        {
            if (Str_Temp == "-")
            {
               Str_Temp = null;
            }
            return Convert.ToDecimal(Str_Temp);
                
        }

        public void ParseCSV(string inputString)
        {
            
            DataTable dt = new DataTable();
            
            // declare the Regular Expression that will match versus the input string
            Regex re = new Regex("((?<field>[^\",\\r\\n]+)|\"(?<field>([^\"]|\"\")+)\")(,|(?<rowbreak>\\r\\n|\\n|$))");

            ArrayList colArray = new ArrayList();
            ArrayList rowArray = new ArrayList();
            
            int colCount = 0;
            int maxColCount = 0;
            string rowbreak = "";
            string field = "";
            
            
            MatchCollection mc = re.Matches(inputString);

            foreach (Match m in mc)
            {
                
                // retrieve the field and replace two double-quotes with a single double-quote
                field = m.Result("${field}").Replace("\"\"", "\"");

                rowbreak = m.Result("${rowbreak}");

                if (field.Length > 0)
                {
                    colArray.Add(field);
                    colCount++;
                }

                if (rowbreak.Length > 0)
                {

                    // add the column array to the row Array List
                    rowArray.Add(colArray.ToArray());

                    // create a new Array List to hold the field values
                    colArray = new ArrayList();

                    if (colCount > maxColCount)
                        maxColCount = colCount;

                    colCount = 0;
                }
            }
            
            if (rowbreak.Length == 0)
            {
                // this is executed when the last line doesn't
                // end with a line break
                rowArray.Add(colArray.ToArray());
                if (colCount > maxColCount)
                    maxColCount = colCount;
            }

            // create the columns for the table
            for (int i = 0; i < maxColCount; i++)
                dt.Columns.Add(String.Format("col{0:000}", i));

            // convert the row Array List into an Array object for easier access
            Array ra = rowArray.ToArray();
            for (int i = 0; i < ra.Length; i++)
            {
                
                // create a new DataRow
                DataRow dr = dt.NewRow();

               
                // convert the column Array List into an Array object for easier access
                Array ca = (Array)(ra.GetValue(i));

                // add each field into the new DataRow
                for (int j = 0; j < ca.Length; j++)
                    dr[j] = ca.GetValue(j);
                
                // add the new DataRow to the DataTable
                dt.Rows.Add(dr);
                
                
            }
                  
            for (int r = 0; r <= dt.Rows.Count - 1; r++)
            {
   
                  switch(TableOfImport)
                  {   
                      case "Asset":
                          AssetHomeObj.Assetobj.ID = dt.Rows[r][0].ToString().Trim();
                          ObjectSet ObjSet_Asset = Manager.Engine.GetObjectSet(typeof(Asset), String.Empty);
                          Asset AssetObj = (Asset)ObjSet_Asset.GetObject(AssetHomeObj.Assetobj.ID);
                          try
                          {
                              if (dt.Rows[r][9].ToString() == "")
                              {
                                  AssetHomeObj.Assetobj.AreaID = "NoArea";//location
                              }
                              else
                              {
                                  AssetHomeObj.Assetobj.AreaID = dt.Rows[r][9].ToString();//location
                              }
                              AssetHomeObj.Assetobj.Name = dt.Rows[r][1].ToString();//Description
                              AssetHomeObj.Assetobj.FloorID = dt.Rows[r][8].ToString();//Cost Center
                              AssetHomeObj.Assetobj.ModelID = dt.Rows[r][2].ToString();
                              AssetHomeObj.Assetobj.DeptID = dt.Rows[r][3].ToString();
                              AssetHomeObj.Assetobj.VendorID = dt.Rows[r][4].ToString();
                              AssetHomeObj.Assetobj.CustodianID = dt.Rows[r][5].ToString();
                              //AssetHomeObj.Assetobj.CreatedDate = Convert.ToDateTime(dt.Rows[r][13].ToString());
                              AssetHomeObj.Assetobj.CreatedDate = Function_ConvertYearlocal((dt.Rows[r][13].ToString()));

                              /////////////Edit on 23-02-09 Add InvoiceDate to DB //////////////
                              AssetHomeObj.Assetobj.Customfiled4 = Function_ConvertYearlocal((dt.Rows[r][13].ToString()));
                              AssetHomeObj.Assetobj.Customfiled10 = Convert.ToDateTime("01/01/1999 12:00:00 AM");
                              AssetHomeObj.Assetobj.Customfiled11 = Convert.ToDateTime("01/01/1999 12:00:00 AM").ToShortDateString();
                              //////////Edit on 13-05-09 Add InvoiceNo. and PO No. to DB////////////////////
                              AssetHomeObj.Assetobj.Customfiled3 = dt.Rows[r][16].ToString(); // col16 = Po No.
                              AssetHomeObj.Assetobj.Customfiled8 = dt.Rows[r][15].ToString(); // col15 = Inv No.
                              /////////////////////////////////////
                              AssetHomeObj.Assetobj.UpdateDate = DateTime.Now;
                              AssetHomeObj.Assetobj.WarrantyStartDate = Function_ConvertYearlocal(dt.Rows[r][11].ToString());
                              AssetHomeObj.Assetobj.WarrantyEndDate = Function_ConvertYearlocal(dt.Rows[r][12].ToString());
                              
                              //////////Add on 15-12-2009 /////////
                              AssetHomeObj.Assetobj.ReasonCode = dt.Rows[r][17].ToString();
                              AssetHomeObj.Assetobj.TypeID = dt.Rows[r][18].ToString();
                              AssetHomeObj.Assetobj.StatusID = dt.Rows[r][19].ToString();
                              AssetHomeObj.Assetobj.PreviosCustodian = dt.Rows[r][20].ToString();
                              AssetHomeObj.Assetobj.Remark = dt.Rows[r][21].ToString();
                              AssetHomeObj.Assetobj.Customfiled2 = dt.Rows[r][22].ToString(); // Capex No.
                              AssetHomeObj.Assetobj.Customfiled4 = Function_ConvertYearlocal((dt.Rows[r][23].ToString())); //Inv Date
                              AssetHomeObj.Assetobj.Customfiled5 = dt.Rows[r][24].ToString(); // Quatation No.
                              AssetHomeObj.Assetobj.Customfiled6 = dt.Rows[r][25].ToString(); // MA No.
                              AssetHomeObj.Assetobj.Customfiled7 = dt.Rows[r][26].ToString(); // PR No.
                              AssetHomeObj.Assetobj.Customfiled9 = dt.Rows[r][27].ToString(); // Short Name
                              AssetHomeObj.Assetobj.Customfiled10 = Function_ConvertYearlocal((dt.Rows[r][28].ToString())); // MA Start Date

                              if (dt.Rows[r][29].ToString() == "")
                              {
                                  //if datetime = null
                              }
                              else
                              {
                                  DateTime DT = DateTime.Parse(dt.Rows[r][29].ToString());
                                  AssetHomeObj.Assetobj.Customfiled11 = DT.ToString("dd/MM/yyyy") + " 12:00:00 AM" ;
                              }

                          }
                          catch (Exception err)
                          {
                              SS_MyMessageBox.ShowBox("Asset Import file: Asset No." + " " + AssetHomeObj.Assetobj.ID + " " + err.Message );
                          }
                             
                          if (dt.Rows[r][6].ToString() == null)
                              {
                                  AssetHomeObj.Assetobj.SerialNo = "";
                              }
                              else
                              {
                                  AssetHomeObj.Assetobj.SerialNo = dt.Rows[r][6].ToString();//Sub-number
                              }
                              //AssetHomeObj.Assetobj.Price = decimal.Parse(dt.Rows[r][10].ToString());//Acquis.val.
                              AssetHomeObj.Assetobj.Price = Function_ConvertToDecimal(dt.Rows[r][10].ToString());//Acquis.val.
                              if (dt.Rows[r][7].ToString() == null)
                              {
                                  AssetHomeObj.Assetobj.BuildID = "";
                              }
                              else
                              {
                                  AssetHomeObj.Assetobj.BuildID = dt.Rows[r][7].ToString();
                              }
                              if (sS_MaskedTextBox_FacCode.Text != "")
                              {
                                  AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_FacCode.Text;
                                  Class_CheckMaster.Function_CheckData.TB_Asset("Facility", AssetHomeObj);
                              }
                              // JDE Asset
                              AssetHomeObj.Assetobj.Customfiled1 = dt.Rows[r][14].ToString();

                              Class_CheckMaster.Function_CheckData.TB_Asset("Building", AssetHomeObj);
                              Class_CheckMaster.Function_CheckData.TB_Asset("Floor", AssetHomeObj);
                              //Class_CheckMaster.Function_CheckData.TB_Asset("Model", AssetHomeObj);
                              //Class_CheckMaster.Function_CheckData.TB_Asset("Department", AssetHomeObj);
                              //Class_CheckMaster.Function_CheckData.TB_Asset("Vendor", AssetHomeObj);
                              //Class_CheckMaster.Function_CheckData.TB_Asset("Custodian", AssetHomeObj);
                              Class_CheckMaster.Function_CheckData.TB_Asset("Area", AssetHomeObj);
                              Class_CheckMaster.Function_CheckData.TB_AssetImportFile("Type", AssetHomeObj);
                              Class_CheckMaster.Function_CheckData.TB_AssetImportFile("Status", AssetHomeObj);

                              if (AssetObj == null)
                                  AssetHomeObj.Add();
                              else
                                  AssetHomeObj.Edit();
                              break;
                          


                      case "Supplier":
                          VendorHomeObj.Vendorobj.ID = dt.Rows[r][0].ToString();
                          ObjectSet ObjSet_Vendor = Manager.Engine.GetObjectSet(typeof(Vendor),String.Empty);
                          Vendor VendorObj = (Vendor)ObjSet_Vendor.GetObject(VendorHomeObj.Vendorobj.ID);

                          VendorHomeObj.Vendorobj.FirstName = dt.Rows[r][1].ToString();
                          VendorHomeObj.Vendorobj.LastName = dt.Rows[r][2].ToString();
                          VendorHomeObj.Vendorobj.Address1 = dt.Rows[r][3].ToString();
                          VendorHomeObj.Vendorobj.Address2 = dt.Rows[r][4].ToString();
                          VendorHomeObj.Vendorobj.City = dt.Rows[r][5].ToString();
                          //VendorHomeObj.Vendorobj.State = dt.Rows[r][6].ToString();
                          VendorHomeObj.Vendorobj.State = "";
                          VendorHomeObj.Vendorobj.Zip = dt.Rows[r][7].ToString();
                          VendorHomeObj.Vendorobj.Phone = dt.Rows[r][8].ToString();
                          VendorHomeObj.Vendorobj.Fax = dt.Rows[r][9].ToString();
                          VendorHomeObj.Vendorobj.Email = dt.Rows[r][10].ToString();
                          VendorHomeObj.Vendorobj.Contact = dt.Rows[r][11].ToString();
                          VendorHomeObj.Vendorobj.Flag = dt.Rows[r][12].ToString();
                          VendorHomeObj.Vendorobj.Remark = dt.Rows[r][13].ToString();

                          if (VendorObj == null)
                              VendorHomeObj.Add();
                          else
                              VendorHomeObj.Edit();
                              break;

                      case "Building":
                          BuildingHomeObj.BuildingObj.BuildID = dt.Rows[r][0].ToString();
                          ObjectSet ObjSet_Building =Manager.Engine.GetObjectSet(typeof(Building),String.Empty);
                          Building BuildingObj =(Building)ObjSet_Building.GetObject(BuildingHomeObj.BuildingObj.BuildID);

                          BuildingHomeObj.BuildingObj.BuildName = dt.Rows[r][1].ToString();
                          if (dt.Rows[r][2].ToString() != "")
                          {
                              BuildingHomeObj.BuildingObj.FacCode = dt.Rows[r][2].ToString();
                              Class_CheckMaster.Function_CheckData.TB_Building("Facility", BuildingHomeObj);                             
                          }                        
                          if (BuildingObj == null)
                              BuildingHomeObj.Add();
                          else
                              BuildingHomeObj.Edit();
                          break;

                      case "Floor":
                          FloorHomeObj.Floorobj.ID = dt.Rows[r][0].ToString();
                          ObjectSet ObjSet_Floor =Manager.Engine.GetObjectSet(typeof(Floor),String.Empty);
                          Floor FloorObj = (Floor)ObjSet_Floor.GetObject(FloorHomeObj.Floorobj.ID);

                          FloorHomeObj.Floorobj.Name = dt.Rows[r][1].ToString();
                          FloorHomeObj.Floorobj.BuildID = dt.Rows[r][2].ToString();
                          if (dt.Rows[r][3].ToString() != "")
                          {
                              FloorHomeObj.Floorobj.FacCode = dt.Rows[r][3].ToString();
                              Class_CheckMaster.Function_CheckData.TB_Floor("Facility", FloorHomeObj);
                          }

                          if (FloorObj == null)
                              FloorHomeObj.Add();
                          else
                              FloorHomeObj.Edit();
                          break;

                      case "Area":
                          AreaHomeObj.Areaobj.ID = dt.Rows[r][0].ToString();
                          ObjectSet ObjSet_Area =Manager.Engine.GetObjectSet(typeof(Area),String.Empty);
                          Area AreaObj = (Area)ObjSet_Area.GetObject(AreaHomeObj.Areaobj.ID);

                          AreaHomeObj.Areaobj.Name = dt.Rows[r][1].ToString();
                          AreaHomeObj.Areaobj.FloorID = dt.Rows[r][3].ToString();
                          AreaHomeObj.Areaobj.BuildID = dt.Rows[r][2].ToString();
                          if (dt.Rows[r][4].ToString() != "")
                          {
                              AreaHomeObj.Areaobj.FacCode = dt.Rows[r][4].ToString();
                              Class_CheckMaster.Function_CheckData.TB_Area("Facility", AreaHomeObj);
                          }

                          if (AreaObj == null)
                              AreaHomeObj.Add();
                          else
                              AreaHomeObj.Edit();
                          break;

                      case "PurchaseOrder":

                          break;

                  }
                  //if (r == dt.Rows.Count - 1)
                  //{

                  //    //Bool_CheckImport = true;
                  //    SS_MyMessageBox.ShowBox("Insert data complete", "Information", DialogMode.OkOnly);

                  //}
                     
            }
            
            // in case no data was parsed, create a single column
                if (dt.Columns.Count == 0)
                    dt.Columns.Add("NoData");


               
           //return dt;
        }

        private void Function_Table(string STR_Table)
       {

           String[] sepData = line.Split(',');
           switch (STR_Table)
           {
               case "Asset":
                   {
                       
                       AssetHomeObj.Assetobj.ID = sepData[0].Trim();//Asset 
                      
                           //AssetHomeObj.Assetobj.FloorID = sepData[1].Trim();
                           if (sepData[2].Trim() == "")
                           {
                               AssetHomeObj.Assetobj.AreaID = "NoArea";//location
                           }
                           else
                           {
                               AssetHomeObj.Assetobj.AreaID = sepData[2].Trim();//location
                           }

                           AssetHomeObj.Assetobj.Name = sepData[3].Trim();//Description
                           AssetHomeObj.Assetobj.FloorID = sepData[4].Trim();//Cost Center
                           if (sepData[6].Trim() == "")
                           {
                               AssetHomeObj.Assetobj.SerialNo = "";
                           }
                           else
                           {
                               AssetHomeObj.Assetobj.SerialNo = sepData[6].Trim();//Sub-number
                           }
                           AssetHomeObj.Assetobj.Price = decimal.Parse(sepData[8].Trim());//Acquis.val.
                           AssetHomeObj.Assetobj.BuildID = sepData[12].Trim();
                           
                           if (sS_MaskedTextBox_FacCode.Text != "")
                           {
                               //AssetHomeObj.Assetobj.FacCode = sS_MaskedTextBox_FacCode.Text;
                               Function_CheckDataInMaster("Facility", AssetHomeObj);
                           }

                           Function_CheckDataInMaster("Building", AssetHomeObj);
                           Function_CheckDataInMaster("Floor", AssetHomeObj);
                           Function_CheckDataInMaster("Department", AssetHomeObj);
                           Function_CheckDataInMaster("Area", AssetHomeObj);
                           //Function_CheckDataInMaster("Reason", AssetHomeObj);
                           Function_CheckDataInMaster("Type", AssetHomeObj);
                           Function_CheckDataInMaster("Status", AssetHomeObj);
                           //Function_CheckDataInMaster("Vendor", AssetHomeObj);
                           //Function_CheckDataInMaster("Custodian", AssetHomeObj);
                           //Function_CheckDataInMaster("Model", AssetHomeObj);

                           AssetHomeObj.Add();
                           sS_MaskedTextBox_FacCode.Text = "";
                       
                       break;
                   }
               case "Supplier":
                   {
                       break;
                   }
               case "Building":
                   {
                       break;
                   }
           }
       }
        
        private void Function_CheckDataInMaster(string STR_Master, AssetHome  AssetHomeObj)
        {
            string STR_ValueDefault = "222";
            switch(STR_Master)
            {
                
                case "Facility":
                    {
                        ObjectSet ObjSet_Facility = Manager.Engine.GetObjectSet(typeof(Facility), String.Empty);
                        Facility FacilityObj = (Facility)ObjSet_Facility.GetObject(sS_MaskedTextBox_FacCode.Text);
                        if (FacilityObj != null)
                        {
                            AssetHomeObj.Assetobj.FacCode = FacilityObj.FacCode;
                        }
                        else
                        {
                            FacilityObj = new Facility();
                            FacilityObj.FacCode = sS_MaskedTextBox_FacCode.Text;
                            FacilityObj.FacName = AssetHomeObj.Assetobj.FacCode;
                            FacilityObj.Address1 = AssetHomeObj.Assetobj.FacCode;
                            FacilityObj.Address2 = AssetHomeObj.Assetobj.FacCode;
                            FacilityObj.FacCity = AssetHomeObj.Assetobj.FacCode;
                            FacilityObj.Phone = AssetHomeObj.Assetobj.FacCode;
                            FacilityHome FacilityHomeObj = new FacilityHome();
                            FacilityHomeObj.Facilityobj = FacilityObj;
                            FacilityHomeObj.Add();
                        }                                             
                    }
                    break;
                case "Building":
                    {
                        ObjectSet ObjSet_Building = Manager.Engine.GetObjectSet(typeof(Building), String.Empty);
                        Building BuildingObj = (Building)ObjSet_Building.GetObject(AssetHomeObj.Assetobj.BuildID);
                        if(BuildingObj==null)
                        {
                            BuildingObj =new Building();
                            BuildingObj.BuildID =AssetHomeObj.Assetobj.BuildID;
                            BuildingObj.BuildName =BuildingObj.BuildID;
                            BuildingObj.FacCode =AssetHomeObj.Assetobj.FacCode;
                            BuildingHome BuildingHomeObj =new BuildingHome();
                            BuildingHomeObj.BuildingObj= BuildingObj;
                            BuildingHomeObj.Add();
                        }
                        break;
                    }
                case "Area":
                    ObjectSet ObjSet_area = Manager.Engine.GetObjectSet(typeof(Area ), String.Empty);
                    Area AreaObj = (Area)ObjSet_area.GetObject(AssetHomeObj.Assetobj.AreaID  );
                    if (AreaObj == null)
                    {
                         AreaObj = new Area();                       
                        AreaObj.ID = AssetHomeObj.Assetobj.AreaID;
                        AreaObj.Name = AssetHomeObj.Assetobj.AreaID;
                        AreaObj.FacCode = AssetHomeObj.Assetobj.FacCode ;
                        AreaObj.FloorID = AssetHomeObj.Assetobj.FloorID ;
                        AreaHome areahomeobj = new AreaHome();
                        areahomeobj.Areaobj = AreaObj;
                        areahomeobj.Add();  
                    }
                    break; 

                case "Floor":
                    {
                        ObjectSet ObjSet_Floor = Manager.Engine.GetObjectSet(typeof(Floor), String.Empty);
                        Floor FloorObj = (Floor)ObjSet_Floor.GetObject(AssetHomeObj.Assetobj.FloorID);
                        if(FloorObj ==null)
                         {
                            FloorObj = new Floor();
                            FloorObj.ID = AssetHomeObj.Assetobj.FloorID;
                            FloorObj.Name = FloorObj.ID;
                            FloorObj.BuildID = AssetHomeObj.Assetobj.BuildID;
                            FloorObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                            FloorHome FloorHomeObj = new FloorHome();
                            FloorHomeObj.Floorobj = FloorObj;
                            FloorHomeObj.Add();
                        }
                        break;
                    }
                case "Reason":
                    {
                        ObjectSet ObjSet_Reason = Manager.Engine.GetObjectSet(typeof(Reason), String.Empty);
                        Reason ReasonObj = (Reason)ObjSet_Reason.GetObject(STR_ValueDefault);
                        if (ReasonObj != null)
                        {
                            AssetHomeObj.Assetobj.ReasonCode = ReasonObj.Code;
                        }
                        else
                        {
                            ReasonObj = new Reason();
                            ReasonObj.Code = STR_ValueDefault;
                            ReasonObj.Name = ReasonObj.Code;
                            ReasonHome ReasonHomeObj = new ReasonHome();
                            ReasonHomeObj.Reasonobj = ReasonObj;
                            ReasonHomeObj.Add();
                            AssetHomeObj.Assetobj.ReasonCode =ReasonObj.Code;
                        }
                        break;
                    }
                case "Type":
                    {
                        ObjectSet ObjSet_Type = Manager.Engine.GetObjectSet(typeof(SimatSoft.DB.ORM.Type), String.Empty);
                        SimatSoft.DB.ORM.Type TypeObj = (SimatSoft.DB.ORM.Type)ObjSet_Type.GetObject(STR_ValueDefault);
                        if (TypeObj!=null)
                        {
                            AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                        }
                        else
                        {
                            TypeObj = new SimatSoft.DB.ORM.Type();
                            TypeObj.ID = STR_ValueDefault;
                            TypeObj.Name = TypeObj.ID;
                            TypeHome TypeHomeObj = new TypeHome();
                            TypeHomeObj.Typeobj = TypeObj;
                            TypeHomeObj.Add();
                            AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                        }

                        break;
                    }
                case "Status":
                    {
                        ObjectSet ObjSet_Status = Manager.Engine.GetObjectSet(typeof(Status), String.Empty);
                        Status StatusObj = (Status)ObjSet_Status.GetObject(STR_ValueDefault);
                        if (StatusObj!=null)
                        {
                            AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                        }
                        else
                        {
                            StatusObj = new Status();
                            StatusObj.ID = STR_ValueDefault;
                            StatusObj.Name = StatusObj.ID;
                            StatusHome StatusHomeObj = new StatusHome();
                            StatusHomeObj.Statusobj = StatusObj;
                            StatusHomeObj.Add();
                            AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                        }
                        break;
                    }
                case "Vendor":
                    {
                        ObjectSet ObjSet_Vendor = Manager.Engine.GetObjectSet(typeof(Vendor),String.Empty);
                        Vendor VendorObj =(Vendor)ObjSet_Vendor.GetObject(STR_ValueDefault);
                        if(VendorObj!=null)
                        {
                            AssetHomeObj.Assetobj.VendorID =VendorObj.ID;
                        }
                        else
                        {
                            VendorObj = new Vendor();
                            VendorObj.ID = STR_ValueDefault;
                            VendorObj.FirstName = VendorObj.ID;
                            VendorObj.LastName = VendorObj.ID;
                            VendorObj.Address1 = VendorObj.ID;
                            VendorObj.Address2 = VendorObj.ID;
                            VendorObj.City = VendorObj.ID;
                            VendorObj.Contact = VendorObj.ID;
                            VendorObj.Email = VendorObj.ID;
                            VendorObj.Fax = VendorObj.ID;
                            VendorObj.Flag = "I";
                            VendorHome VendorHomeObj = new VendorHome();
                            VendorHomeObj.Vendorobj = VendorObj;
                            VendorHomeObj.Add();
                            AssetHomeObj.Assetobj.VendorID = VendorObj.ID ;
                        }
                        break;
                    }
                case "Department":
                    {
                        ObjectSet ObjSet_Department = Manager.Engine.GetObjectSet(typeof(Department), String.Empty);
                        Department DepartmentObj = (Department)ObjSet_Department.GetObject(STR_ValueDefault);
                        if (DepartmentObj != null)
                        {
                            AssetHomeObj.Assetobj.DeptID = DepartmentObj.DeptID;
                        }
                        else
                        {
                            DepartmentObj = new Department();
                            DepartmentObj.DeptID = STR_ValueDefault;
                            DepartmentObj.DeptName = DepartmentObj.DeptID;
                            DepartmentObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                            DepartmentHome DeptHomeObj = new DepartmentHome();
                            DeptHomeObj.Departmentobj = DepartmentObj;
                            DeptHomeObj.Add();
                            AssetHomeObj.Assetobj.DeptID = DepartmentObj.DeptID;
                        }
                        break;
                    }
                case "Custodian":
                    {
                        ObjectSet ObjSet_Custodian = Manager.Engine.GetObjectSet(typeof(Custodian), String.Empty);
                        Custodian CustodianObj = (Custodian)ObjSet_Custodian.GetObject(STR_ValueDefault);
                        if (CustodianObj!=null)
                        {
                            AssetHomeObj.Assetobj.CustodianID = CustodianObj.ID;

                        }
                        else
                        {
                            CustodianObj = new Custodian();
                            CustodianObj.ID = STR_ValueDefault;
                            CustodianObj.DeptID = AssetHomeObj.Assetobj.DeptID;
                            CustodianObj.FirstName = CustodianObj.ID;
                            CustodianObj.LastName = CustodianObj.ID;
                            CustodianObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                            CustodianHome CustodainHomeObj = new CustodianHome();
                            CustodainHomeObj.Custodianobj = CustodianObj;
                            CustodainHomeObj.Add();
                            AssetHomeObj.Assetobj.CustodianID = CustodianObj.ID ;
                                             
                      }
                        break;
                    }
                case "Model":
                    {
                        ObjectSet ObjSet_Model = Manager.Engine.GetObjectSet(typeof(Model),String.Empty);
                        Model ModelObj =(Model)ObjSet_Model.GetObject(STR_ValueDefault);
                        if (ModelObj!=null)
                        {
                            AssetHomeObj.Assetobj.ModelID = ModelObj.ID;
                        }
                        else
                        {
                            ModelObj = new Model();
                            ModelObj.ID = STR_ValueDefault;
                            ModelObj.Name = ModelObj.ID;
                            ModelObj.Value =decimal.Parse("0.00");

                            ModelHome ModelHomeObj = new ModelHome();
                            ModelHomeObj.Modelobj = ModelObj;
                            ModelHomeObj.Add();
                            AssetHomeObj.Assetobj.ModelID = ModelObj.ID ;
                        }
                        break;
                    }
            }
        }

        private void FileType()
        {
            try
            {
                if (sS_ComboBox_FileType.SelectedIndex == 0)
                {
                    STR_FileType = "Excel";
                }
                else if (sS_ComboBox_FileType.SelectedIndex == 1)
                {
                    STR_FileType = "CSV";
                }
                else if (sS_ComboBox_FileType.SelectedIndex == 2)
                {
                    STR_FileType = "Text";
                }
                else
                {
                    STR_FileType = "Other";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            { }
        }

        private string TableOfImport;

        private void checkBox_Asset_CheckStateChanged(object sender, EventArgs e)
        {
            TableOfImport = "";
            CheckBox TempCheckBox = (CheckBox)sender;

            if(TempCheckBox.CheckState == CheckState.Checked)
            {
                if(groupBox_TableOfImport.Controls.Contains(TempCheckBox))
                {
                    foreach (CheckBox checkTemp in groupBox_TableOfImport.Controls)
                    {
                        if (checkTemp != TempCheckBox)

                            checkTemp.Checked = false;
                    }
                }
            }
            this.TableOfImport = TempCheckBox.Text;
            this.label2.Text = string.Format("selected : {0}", this.TableOfImport);      
        }

        private void sS_ComboBox_FileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sS_ComboBox_FileType.SelectedIndex == 0)
            {
                STR_FileType = "XLS";
            }
            else if (sS_ComboBox_FileType.SelectedIndex == 1)
            {
                STR_FileType = "CSV";
            }
            else if (sS_ComboBox_FileType.SelectedIndex == 2)
            {
                STR_FileType = "TXT";
            }
            else
            {
                STR_FileType = "OTHER";
            }
        }

        void CheckState1()
        {//-1=cancel,-2=temp,0=Import,
            int state =Global.IndexArray.Get(int.Parse(ind.ToString()));
            if(state == 0)
                Global.Function_ToolStripSetUP(Enum_Mode.Import);
       
        }
        private void Form_001008_ImportFile_Enter(object sender, EventArgs e)
        {
            CheckState1();
        }

        private void Form_001008_ImportFile_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            sS_ComboBox_FileType.SelectedIndex = 0;
        }

        private void Form_001008_ImportFile_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_001008_ImportFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

       

    }
 }