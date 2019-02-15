using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SimatSoft.DB.ORM
{
   public class ReportHome
    {
       public DataSet getreportmenu(string userid, string Sctype, string SCsubType)
       {
           try
           {
               string sqlcommand = "";
               sqlcommand = " SELECT SYSReport.Reportid, SYSReport.ReportDes, sysReportGroup.ReportGroup, sysReportGroup.ReportGroupDes, SYSReport.ReportOrder " +
                                          " FROM SYSReport INNER JOIN " +
                                          " sysReportGroup ON SYSReport.ReportGroup = sysReportGroup.ReportGroup " +
                                          " Where SYSReport.ReportFlag =1" +
                                          " ORDER BY sysReportGroup.ReportGroup, SYSReport.ReportOrder ";
               return Manager.Engine.GetDataSet(sqlcommand);
           }
           catch (Exception ex)
           {
              // SimatSoft.Log.Classlogfile.Writelogfile(ex);
               return null;
           }
       }
    }
}
