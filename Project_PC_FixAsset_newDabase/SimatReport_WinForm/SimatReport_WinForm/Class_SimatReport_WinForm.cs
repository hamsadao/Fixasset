using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SimatSoft.ReportManagerWinForm; 
namespace SimatSoft.ReportManagerWinForm
{
    public class Class_SimatReport_WinForm
    {
        public  string Reportid;
        public Form_MainReport frm;
        public Wilson.ORMapper.ObjectSpace Engine;
        public String Servername;
        public String Dbname;
        public String Username;
        public String UserPassword;
        public String SelectionFormula;

        public void DisplayReport(String ReportProfilename, Form frmmain) 
        {
            System.Drawing.Point Loc = new System.Drawing.Point();
            FormReport frmreport = new FormReport();
            frmreport.MdiParent = frmmain;
            
            Loc.X = frmmain.ActiveMdiChild.Location.X + frmmain.ActiveMdiChild.Width;
            Loc.Y = frmmain.ActiveMdiChild.Location.Y;
            frmreport.PrintReport(ReportProfilename, Servername, Dbname, Username, UserPassword, SelectionFormula);
            frmreport.Show();
            frmreport.Activate();

        }

        public void DisplayReport(String ReportProfilename, Form frmmain, object[] objParam, object[] objValue)
        {
            System.Drawing.Point Loc = new System.Drawing.Point();
            FormReport frmreport = new FormReport();
            frmreport.MdiParent = frmmain;

            Loc.X = frmmain.ActiveMdiChild.Location.X + frmmain.ActiveMdiChild.Width;
            Loc.Y = frmmain.ActiveMdiChild.Location.Y;
            frmreport.PrintReport(ReportProfilename, Servername, Dbname, Username, UserPassword, SelectionFormula, objParam, objValue, ref frmreport);
            frmreport.Show();
            frmreport.Activate();

        }

        public Form DisplayScreen(ref int Int_CountForm,ref SimatSoft.CustomControl.SS_TabStrip MDITabStrip) 
        {
            Int_CountForm = 0;
            System.Drawing.Point    Loc = new System.Drawing.Point() ;
            frm = new Form_MainReport();
            frm.ShowReport(Reportid, Engine);
           
            frm.Dbname = Dbname;
            frm.UserName = Username;
            frm.UserPassword = UserPassword;
            //frm.MdiParent     = frmmain;
            frm.Int_CountForm = Int_CountForm;
            frm.MDITabStrip = MDITabStrip;
            //Loc.X = frmmain.ActiveMdiChild.Location.X + frmmain.ActiveMdiChild.Width;
            //Loc.Y = frmmain.ActiveMdiChild.Location.Y;
            return frm;
        }

        public void DisplayScreen1(Form Frm_TempForm)
        {
            System.Drawing.Point Loc = new System.Drawing.Point();
            frm = (Form_MainReport)Frm_TempForm;
            frm.ShowReport(Reportid, Engine);

            frm.Dbname = Dbname;
            frm.UserName = Username;
            frm.UserPassword = UserPassword;
            //frm.MdiParent = Frm_TempForm;
            //Loc.X = frm.ActiveMdiChild.Location.X + frm.ActiveMdiChild.Width;
            //Loc.Y = frm.ActiveMdiChild.Location.Y;
            //frm.Show();
        }

        //public static Point SetLocation(int Int_X, int Int_Width, int Int_Y)
        //{
        //    Point Location;
        //    if ((Global.Location.Int_CountForm == 0) || (Global.Location.Int_CountForm % 5 == 0))
        //    {
        //        Location = new Point((Int_X + Int_Width), Int_Y);
        //    }
        //    else
        //    {
        //        Location = new Point((Global.Location.Int_LocX + 55), (Global.Location.Int_LocY + 25));
        //    }
        //    Global.Location.Int_CountForm = Global.Location.Int_CountForm + 1;
        //    Global.Location.Int_LocX = Location.X;
        //    Global.Location.Int_LocY = Location.Y;
        //    return Location;
        //}

          
    }
}
