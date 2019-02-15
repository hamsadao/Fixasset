using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms ;
using SimatSoft.CustomControl;


namespace SimatSoft.ValidateData
  
{
    public class ValidateuserinputData
    {
        private string File_config = "";
        private System.Windows.Forms.Form   Form_user;

        public  ValidateuserinputData(string File_configinput, System.Windows.Forms.Form Form_userinput)
        {
            File_config = File_configinput;
            Form_user = Form_userinput;           
        }
        public bool ValidateData(String Str_MessageLanguage) 
        {
            DataSet ds = new DataSet();
            string Controlname;
            int min, max;
            string userinputdata;
            try
            {

                ds.ReadXml(File_config);
                if (ds != null)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Controlname = ds.Tables[0].Rows[i]["controlname"].ToString();
                        string[] temp = Controlname.Split('.');
                        Control Controltemp = null;
                        if (temp.Length > 0)
                        {
                            // หา control ที่เป็น base ที่สุด
                            Controltemp = Form_user.Controls[temp[0]];
                            for (int j = 1; j < temp.Length; j ++)
                            {
                                Controltemp = Controltemp.Controls[temp[j]];  
                            }
                            userinputdata = Controltemp.Text.ToString();
                            switch (ds.Tables[0].Rows[i]["datatype"].ToString().ToUpper())
                            {
                                case "NUMERIC":
                                    try
                                    {
                                        int.Parse(userinputdata);
                                    }
                                    catch(Exception ex)
                                    {
                                        Controltemp.Select();
                                        if(Str_MessageLanguage == "EN")
                                            SS_MyMessageBox.ShowBox("Please Check Data Type(Numeric)", "Warning", DialogMode.Error_Cancel, ex);
                                        else
                                            SS_MyMessageBox.ShowBox("กรุณาตรวจสอบชนิดของข้อมูล(ตัวเลข)", "คำเตือน", DialogMode.Error_Cancel, ex);
                                        return false;
                                    }
                                    break;
                                case "DECIMAL":
                                    try
                                    {
                                        decimal.Parse(userinputdata);
                                    }
                                    catch (Exception ex)
                                    {
                                        Controltemp.Select();
                                        if (Str_MessageLanguage == "EN")
                                            SS_MyMessageBox.ShowBox("Please Check Data Type(Numeric)", "Warning", DialogMode.Error_Cancel, ex);
                                        else
                                            SS_MyMessageBox.ShowBox("กรุณาตรวจสอบชนิดของข้อมูล(ทศนิยม)", "คำเตือน", DialogMode.Error_Cancel, ex);
                                        return false;
                                    }
                                    break;
                                case "CHAR":
                                    min = int.Parse(ds.Tables[0].Rows[i]["min"].ToString());
                                    max = int.Parse(ds.Tables[0].Rows[i]["max"].ToString());

                                    if ((min != 0) || (max != 0))
                                    {
                                        if ((min <= userinputdata.Length) && (max >= userinputdata.Length))
                                        {
                                            // user input data correct

                                        }
                                        else
                                        {
                                            //user input data incorrect
                                            Controltemp.Select();
                                            Exception Ex = null;
                                            if (Str_MessageLanguage == "EN")
                                            {
                                                Ex = new Exception("Invalid Data Length in Control : " + Controltemp.Name + "  Please Check Format of Lenght.");
                                                SS_MyMessageBox.ShowBox("Please Check Data Size (Length)", "Warning", DialogMode.Error_Cancel, Ex);
                                            }
                                            else
                                            {
                                                Ex = new Exception("ความยาวข้อมูลผิดพลาด ใน : " + Controltemp.Name + "  กรุณาตรวจสอบรูปแบบหรือความยาวของข้อมูล");
                                                SS_MyMessageBox.ShowBox("กรุณาตรวจสอบขนาดของข้อมูล (ความยาว)", "คำเตือน", DialogMode.Error_Cancel, Ex);
                                            }
                                            return false;
                                        }
                                    }
                                    break;
                                case "DATE":
                                    string Str_DateFormat = ds.Tables[0].Rows[i]["dateformat"].ToString();
                                    string Str_DateSeparator = ds.Tables[0].Rows[i]["dateseparator"].ToString();

                                    if (userinputdata.Length < Str_DateFormat.Length)
                                    {

                                    }
                                    else
                                    {
                                        Controltemp.Select();
                                        return false;
                                    }

                                    break;
                            }
                        }
                        else // file user config ผิด format 
                        {
                            if (Str_MessageLanguage == "EN")
                                SS_MyMessageBox.ShowBox("Invalid Format Data in Configfile : " + File_config);
                            else
                                SS_MyMessageBox.ShowBox("รูปแบบข้อมูลในไฟล์ : " + File_config + " ผิดพลาด");
                            return false;
                        }
                        
                        //  MessageBox.Show(Form_user.Controls[ds.Tables[0].Rows[i]["controlname"].ToString()].Text.ToString()   );  
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                //SimatSoft.Log.Classlogfile.Writelogfile(ex);
                SS_MyMessageBox.ShowBox(ex.Message, "Error", DialogMode.Error_Cancel, ex);
                ds = null;
                return false;
            }

        }
        //public SS_MyMessageBox Function_MsgValidate(string Language)
        //{
        //    SS_MyMessageBox SS_MyMessgeBox = new SS_MyMessageBox();
        //    if (Language == "EN")
        //    {
        //    SS_MyMessgeBox = SS_MyMessageBox.ShowBox("Invalid data Numberic", "Information", DialogMode.OkOnly);
                
        //    }
        //    else
        //    {
        //      SS_MyMessgeBox=  SS_MyMessageBox.ShowBox("กรุณาตรวจสอบข้อมูล Numberic", "Information", DialogMode.OkOnly);
        //    }
        //    return SS_MyMessgeBox;
            
        //}
    }
}
