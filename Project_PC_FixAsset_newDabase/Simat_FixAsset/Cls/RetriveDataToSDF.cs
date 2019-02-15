using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;
using System.Threading;
using System.Globalization;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlServerCe;



namespace SimatSoft.FixAsset.Cls
{
    class RetriveDataToSDF
    {
       public static string STR_PathExport = "C:\\Export\\";
       public static string STR_DBCEfile = STR_PathExport + "DBCE.sdf";
       public string Str_Qry;

        public void Function_RetriveDataToSDF(string STR_Table)
        {
            int i;

            if (STR_Table == "Company")
                STR_Table = "Facility";
            if (STR_Table == "User")
                STR_Table = "Whuser";

            DataSet Ds = new DataSet();

            if (Directory.Exists(STR_PathExport) == false)
            {
                DirectoryInfo DirPathExport = Directory.CreateDirectory(STR_PathExport);
            }
            switch (STR_Table)
            {
                case "Asset":
                    {
                        string[] Str_ColumnPO = { "AssetID", "AssetName", "SerialNo", "modelID", "deptID", "buildID", "floorID", "areaID", "ReasonCode", "typeID", "StatusID", "vendorID"
                        , "AssetPrice", "WarrantyStartDate", "WarrantyEndDate","CustodianID","PreviosCustodian","CreatedDate","UserName","UpdateDate","Remark","FacCode" };
                        Ds = Manager.Engine.GetDataSet<Asset>("", Str_ColumnPO);
                        break;
                    }
                case "Building":
                    {
                        Ds = Manager.Engine.GetDataSet<Building>("");
                        break;
                    }
                case "Model":
                    {
                        Ds = Manager.Engine.GetDataSet<Model>("");
                        break;
                    }
                case "Whuser":
                    {
                        Ds = Manager.Engine.GetDataSet<Whuser>("");
                        break;
                    }
                case "Area":
                    {
                        Ds = Manager.Engine.GetDataSet<Area>("");
                        break;
                    }
                case "Floor":
                    {
                        Ds = Manager.Engine.GetDataSet<Floor>("");
                        break;
                    }
                case "Facility":
                    {
                        Ds = Manager.Engine.GetDataSet<Facility>("");
                        break;
                    }
               

            }
            if (Ds != null)
            {
                if (System.IO.File.Exists(STR_DBCEfile))
                {
                    SqlCeConnection conn = new SqlCeConnection("Data Source = " + STR_PathExport + "DBCE.sdf");
                    SqlCeCommand cmd = conn.CreateCommand();
                    SqlCeCommand cmdDelete = conn.CreateCommand();

                    //string connStringCI = "Data Source= " + STR_PathExport + "DBCE.sdf; LCID= 1033";

                    //string connStringCS = "Data Source= " + STR_PathExport + "DBCE.sdf; LCID= 1033; Case Sensitive=true";

                    //SqlCeEngine engine = new SqlCeEngine(connStringCI);
                    //engine.Upgrade(connStringCS);


                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        //////////////////////////
                        cmdDelete.CommandText = "DELETE FROM "+STR_Table+ " ";
                        cmdDelete.ExecuteNonQuery();
                        
                        ////////////////// Set Column
                                Str_Qry = "Insert INTO [" + STR_Table + "] (";
                                for (int c = 0; c <= Ds.Tables[0].Columns.Count - 1; c++)
                                {
                                    Str_Qry += "["+Ds.Tables[0].Columns[c].ColumnName.ToString()+"]";

                                    if (c != Ds.Tables[0].Columns.Count - 1)
                                        Str_Qry += ",";
                                }
                                Str_Qry += ") Values ("  ;

                       
                             //////////// Set Value and Insert
                switch (STR_Table)
                {
                    case "Asset":
                        {
                           for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                string str_Date13 = "";
                                string str_Date14 = "";
                                string str_Date17 = "";
                                string str_Date19 = "";

                                DateTime dt13 = new DateTime();
                                dt13 = (DateTime)Ds.Tables[0].Rows[y][13];
                                str_Date13 = dt13.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                                
                                DateTime dt14 = new DateTime();
                                dt14 = (DateTime)Ds.Tables[0].Rows[y][14];
                                str_Date14 = dt14.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

                                DateTime dt17 = new DateTime();
                                dt17 = (DateTime)Ds.Tables[0].Rows[y][17];
                                str_Date17 = dt17.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);

                                DateTime dt19 = new DateTime();
                                dt19 = (DateTime)Ds.Tables[0].Rows[y][19];
                                str_Date19 = dt19.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);


                                Ds.Tables[0].Rows[y][1] = Ds.Tables[0].Rows[y][1].ToString().Replace("'", "''");
                                Ds.Tables[0].Rows[y][2] = Ds.Tables[0].Rows[y][2].ToString().Replace("'", "''");
                                Ds.Tables[0].Rows[y][3] = Ds.Tables[0].Rows[y][3].ToString().Replace("'", "''");
                                Ds.Tables[0].Rows[y][15] = Ds.Tables[0].Rows[y][15].ToString().Replace("'", "''");
                                Ds.Tables[0].Rows[y][16] = Ds.Tables[0].Rows[y][16].ToString().Replace("'", "''");
                                Ds.Tables[0].Rows[y][20] = Ds.Tables[0].Rows[y][20].ToString().Replace("'", "''");
                               
                               try
                                {
                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , '" + Ds.Tables[0].Rows[y][3] + "' , '" + Ds.Tables[0].Rows[y][4] + "' , " +
                                   " '" + Ds.Tables[0].Rows[y][5] + "' , '" + Ds.Tables[0].Rows[y][6] + "' , '" + Ds.Tables[0].Rows[y][7] + "' , '" + Ds.Tables[0].Rows[y][8] + "' , '" + Ds.Tables[0].Rows[y][9] + "' , '" + Ds.Tables[0].Rows[y][10] + "' , '" + Ds.Tables[0].Rows[y][11] + "' , " +
                                   " " + Convert.ToDecimal(Ds.Tables[0].Rows[y][12]) + " , '" + str_Date13 + "' , '" + str_Date14 + "' ,  '" + Ds.Tables[0].Rows[y][15] + "' , '" + Ds.Tables[0].Rows[y][16] + "' , '" + str_Date17 + "' , '" + Ds.Tables[0].Rows[y][18] + "' , '" + str_Date19 + "'  , " +
                                   " '" + Ds.Tables[0].Rows[y][20] + "' , '" + Ds.Tables[0].Rows[y][21] + "' )";

                                    cmd.ExecuteNonQuery();

                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error AssetNo:\r\n" + Ds.Tables[0].Rows[y][0] + "\r\n" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Building":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                try
                                {
                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' )";

                                    cmd.ExecuteNonQuery();

                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Model":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                try
                                {
                                    Ds.Tables[0].Rows[y][0] = Ds.Tables[0].Rows[y][0].ToString().Replace("'", "''");
                                    Ds.Tables[0].Rows[y][1] = Ds.Tables[0].Rows[y][1].ToString().Replace("'", "''");
                                    Ds.Tables[0].Rows[y][2] = Ds.Tables[0].Rows[y][2].ToString().Replace("'", "''");


                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , " + Convert.ToDecimal(Ds.Tables[0].Rows[y][3]) + " )";
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Whuser":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {  
                                string str_Date ="" ;
                                
                                DateTime dt = new DateTime();
                                         dt = (DateTime)Ds.Tables[0].Rows[y][6] ;

                                str_Date = dt.ToString("dd/MM/yyyy", DateTimeFormatInfo.InvariantInfo);
                               
                                int Flag;
                                if (Ds.Tables[0].Rows[y][7].ToString() == "True")
                                {
                                    Flag = 1;
                                }
                                else
                                {
                                    Flag = 0;
                                }

                                try
                                {
                                    cmd.CommandText = "Insert INTO " + STR_Table + " (usID,deptID,usFirstName,usLastName,usPass,CreatedDate,ActiveFlag,FacCode,usGroupID) values (" +
                                        "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , '" + Ds.Tables[0].Rows[y][3] + "' , '" + Ds.Tables[0].Rows[y][4] + "' ,'" + str_Date + "', " + Flag + " , '" + Ds.Tables[0].Rows[y][8] + "' , '" + Ds.Tables[0].Rows[y][5] + "')";
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Area":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                try
                                {
                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , '" + Ds.Tables[0].Rows[y][3] + "' , '" + Ds.Tables[0].Rows[y][4] + "')";
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Floor":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                try
                                {
                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , '" + Ds.Tables[0].Rows[y][3] + "' )";
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                    case "Facility":
                        {
                            for (int y = 0; y <= Ds.Tables[0].Rows.Count - 1; y++)
                            {
                                try
                                {
                                    cmd.CommandText = Str_Qry + "'" + Ds.Tables[0].Rows[y][0] + "' , '" + Ds.Tables[0].Rows[y][1] + "' , '" + Ds.Tables[0].Rows[y][2] + "' , '" + Ds.Tables[0].Rows[y][3] + "' , '" + Ds.Tables[0].Rows[y][4] + "' , '" + Ds.Tables[0].Rows[y][5] + "')";
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception er)
                                {
                                    SS_MyMessageBox.ShowBox("RetriveDataTosdf Error:" + er.Message);
                                }

                            }
                            break;
                        }
                }
                        }
                        conn.Close();
                        Ds.Dispose();  
                }
                else
                {
                    SS_MyMessageBox.ShowBox("Can't found DBCE.sdf file at " + STR_PathExport);
                }
                
            }
            
        }
    }
}
