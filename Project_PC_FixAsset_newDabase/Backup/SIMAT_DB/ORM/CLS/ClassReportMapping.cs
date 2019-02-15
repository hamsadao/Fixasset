using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
namespace SimatSoft.DB.ORM
{
    public class ClassReportMapping
    {
        private System.Data.DataSet DatasetMenu;

        public ClassReportMapping()
        {
            PresentData present = new PresentData();
            DatasetMenu = present.loaddata(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\Report.Xml");  
        }
        public string FindMenu(string menuid) 
        {
            try
            {
                if (DatasetMenu.Tables.Count > 0)
                    for (int i = 0; i < DatasetMenu.Tables[0].Rows.Count - 1; i++)
                    {
                        if (DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString() == menuid)
                            return DatasetMenu.Tables[0].Rows[i]["Profilename"].ToString();
                    }
                return "";
            }
            catch (Exception Err)
            {
                
               // Simat_Log.Classlogfile.writelogfile(e);
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                return "";
            }
        }

    }
}
