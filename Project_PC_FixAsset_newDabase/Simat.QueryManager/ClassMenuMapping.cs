using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.QueryManager
{
  public   class ClassMenuMapping
    {
        private System.Data.DataSet DatasetMenu;

        public ClassMenuMapping()
        {
            PresentData present = new PresentData();
            DatasetMenu = present.loaddata(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\Menu.Xml");  
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
