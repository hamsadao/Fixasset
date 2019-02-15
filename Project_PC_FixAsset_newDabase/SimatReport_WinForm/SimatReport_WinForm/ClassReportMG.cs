using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SimatSoft.ReportManagerWinForm
{
    
    public class ClassReportMG
    {
        private string sqlcommandshowdata;
        public System.Data.DataSet dsheader = null;
        public System.Data.DataSet dsquery = null;
        public System.Data.DataSet dssource = null;
        public System.Data.DataSet dssearchmember = null;
        public Wilson.ORMapper.ObjectSpace Engine;
        public void search(string startpath, object obj)
        {
            if (dsheader == null)
            {
                string classname = obj.ToString();
                classname = classname.Replace("SimatSoft.RT_WMS_BU.", "");
                string queryfilename = startpath + "\\Data\\Present\\Report\\" + classname + "-Q.xml";
                string headerfilename = startpath + "\\Data\\Present\\Report\\" + classname + "-H.xml";
                string searchfilename = startpath + "\\Data\\Present\\Report\\" + classname + "-S.xml";
              
                //load data header 
                dsheader = loaddata(headerfilename);
                //load data Query 
                dsquery = loaddata(queryfilename);
                //load data dssearchmember 
                dssearchmember = loaddata(searchfilename);
                dssource = selectdata();
            }
        }
        public DataSet selectdata()
        {
            try
            {
                sqlcommandshowdata = dsquery.Tables[0].Rows[0][0].ToString() + " " + dsquery.Tables[0].Rows[0][1].ToString();
                return Engine.GetDataSet(sqlcommandshowdata);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public DataSet selectdataforsearch(string sqlwhere)
        {
            try
            {
                sqlcommandshowdata = dsquery.Tables[0].Rows[0][0].ToString();
                if (sqlwhere != "")
                {
                    sqlcommandshowdata = sqlcommandshowdata + " where " + sqlwhere;
                }
                sqlcommandshowdata = sqlcommandshowdata + " " + dsquery.Tables[0].Rows[0][1].ToString();
                return Engine.GetDataSet(sqlcommandshowdata);
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
                return null;
            }
        }
        public DataSet loaddata(string filename)
        {
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                ds.ReadXml(filename);
                return ds;
            }
            catch (Exception ex)
            {
                ds = null;
                return null;
            }
        }
        public DataSet selectdata(string sqlcommand)
        {
            try
            {

                return Engine.GetDataSet(sqlcommand);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void PrintReport(      ) 
        {

        }
       
    }
}
