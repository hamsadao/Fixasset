using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace SimatSoft.ReportManagerWinForm
{
    public class ClassReportMapping
    {
        private System.Data.DataSet DatasetMenu;

        public ClassReportMapping()
        {
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\Report.Xml");
                DatasetMenu = ds;
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);
                DatasetMenu = null;
            }
            
        }
        public string FindMenu(string menuid) 
        {
            try
            {
                if (DatasetMenu.Tables.Count > 0)
                    for (int i = 0; i < DatasetMenu.Tables[0].Rows.Count ; i++)
                    {
                        if (DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString() == menuid)
                            return DatasetMenu.Tables[0].Rows[i]["Profilename"].ToString();
                    }
                return "";
            }
            catch (Exception e)
            {
                
                SimatSoft.Log.Classlogfile.Writelogfile(e);
                return "";
            }
        }

    }
}
