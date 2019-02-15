using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.ReportManagerWinForm;
namespace SimatSoft.ReportManagerWinForm
{
    class cls_main
    {
        public Boolean mode = false;
        public string loginmode = "";
        public string userid = "";

        public Class_ListData cls_list = new Class_ListData();
        public string profilename;
        public ClassReportMG ReportMG;
        public ClassReportMapping reportmapping = new ClassReportMapping();
        public string menutype = "";
        public string menuid = "";

       
    }
    
}