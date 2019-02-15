using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms.Samples;
using SimatSoft.QueryManager;



    class cls_main
    {
        public static Boolean mode = false;
        public static string loginmode = "";
        public  static string userid  ="";
        public static string treeMenu = "";
        public static Class_ListData cls_list = new Class_ListData();
        public static string profilename;
        public static string id;
        public static SimatSoft.DB.ORM.PresentData Present= null;
        public static ClassMenuManage clsmainmenu = new ClassMenuManage();
        public static ClasstoolStripButton clstoolStrip = new ClasstoolStripButton();
        public static SimatSoft.DB.ORM.ClassMenuMapping menumapping = new SimatSoft.DB.ORM.ClassMenuMapping();
        public static SimatSoft.DB.ORM.ClassReportMapping reportmapping = new SimatSoft.DB.ORM.ClassReportMapping();
        public static string menutype = "";
        public static System.Windows.Forms.TextBox texttemp= new System.Windows.Forms.TextBox() ;   
    }
