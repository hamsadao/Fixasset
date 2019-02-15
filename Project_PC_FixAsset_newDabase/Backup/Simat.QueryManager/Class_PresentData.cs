using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.QueryManager
{
   public  class Class_PresentData
    {
            public  Boolean mode = false;
            public  string loginmode = "";
            public  string userid = "";
            public  Class_ListData cls_list = new Class_ListData();
            public  string profilename;
            public  PresentData   Present;
            public   ClassMenuMapping menumapping = new  ClassMenuMapping();
            public  string menutype = "";
            public  string menuid = "";
        
    }
}
