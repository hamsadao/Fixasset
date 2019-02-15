using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SimatSoft.DB.ORM;

namespace SimatSoft.QueryManager
{
   public  class PresentData
    {
        private string sqlcommandshowdata;
        public System.Data.DataSet dsheader = null;
        public System.Data.DataSet dsquery = null;
        public System.Data.DataSet dssource = null;
        public System.Data.DataSet dssearchmember = null;

       
        public void search(string startpath, object obj)
        {
            if (dsheader == null)
            {
                string classname = obj.ToString();
                classname = classname.Replace("SimatSoft.BusinessObjects.", "");
                string queryfilename = startpath + "\\Data\\Present\\" + classname + "-Q.xml";
                string headerfilename = startpath + "\\Data\\Present\\" + classname + "-H.xml";
                string searchfilename = startpath + "\\Data\\Present\\" + classname + "-S.xml";
                PresentData P = new PresentData();
                //load data header 
                dsheader = P.loaddata(headerfilename);
                //load data Query 
                dsquery  = P.loaddata(queryfilename );
                //load data dssearchmember 
                dssearchmember = P.loaddata(searchfilename);
               // dssource = selectdata();
            }
        }
        public void search(string startpath, object obj, string qry)
        {
            if (dsheader == null)
            {
                string classname = obj.ToString();
                classname = classname.Replace("SimatSoft.BusinessObjects.", "");
                string queryfilename = startpath + "\\Data\\Present\\" + classname + "-Q.xml";
                string headerfilename = startpath + "\\Data\\Present\\" + classname + "-H.xml";
                string searchfilename = startpath + "\\Data\\Present\\" + classname + "-S.xml";
                PresentData P = new PresentData();
                //load data header 
                dsheader = P.loaddata(headerfilename);
                //load data Query 
                dsquery = P.loaddata(queryfilename,qry);
                //load data dssearchmember 
                dssearchmember = P.loaddata(searchfilename);
                //dsquery = selectdataforsearch(qry);
            }
        }
        public DataSet selectdata()
        {
           try
           {
               sqlcommandshowdata = dsquery.Tables[0].Rows[0][0].ToString() + " " + dsquery.Tables[0].Rows[0][1].ToString();
               sqlcommandshowdata = sqlcommandshowdata.Replace("\r\n", "");
            
               return Manager.Engine.GetDataSet(sqlcommandshowdata );
           }
           catch (Exception e) 
           {
               SimatSoft.Log.Classlogfile.Writelogfile(e);  
               return null;
           }
       }
        public  DataSet selectdataforsearch(string sqlwhere )
       {
           try
           {
               sqlcommandshowdata = dsquery.Tables[0].Rows[0][0].ToString();
               if (sqlwhere !="")
               {
                   sqlcommandshowdata = sqlcommandshowdata + " where " + sqlwhere ;
               }
               sqlcommandshowdata = sqlcommandshowdata +" " + dsquery.Tables[0].Rows[0][1].ToString();
               return Manager.Engine.GetDataSet(sqlcommandshowdata);
           }
           catch (Exception e)
           {
               SimatSoft.Log.Classlogfile.Writelogfile(e);   
               return null;
           }
       } 
        public   DataSet  loaddata( string filename )
        {
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                ds.ReadXml(filename );
                return ds;
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);   
                ds=null ;
                return null; 
            }
        }
        public DataSet loaddata(string filename, string sqlwhere)
        {
            DataSet ds = new DataSet();
            int i = 0;
            try
            {
                ds.ReadXml(filename);

                string tmp = ds.Tables[0].Rows[i][0].ToString();
                tmp += " where " + sqlwhere;

                ds.Tables[0].Rows[i][0] = tmp;
                return ds;
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);
                ds = null;
                return null;
            }
        }
        public DataSet selectdata(string sqlcommand)
       {
           try
           {
               
               return Manager.Engine.GetDataSet(sqlcommand );
           }
           catch (Exception e)
           {
               return null;
           }
       }
    }
}
