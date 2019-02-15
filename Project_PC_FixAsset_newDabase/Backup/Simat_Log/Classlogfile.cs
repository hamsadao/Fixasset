using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.Log
{
    public static   class  Classlogfile
    {
    public static void Writelogfile(Exception ex) 
      {
          try
          {
              Writelogfile(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Log\\Log-Simat-" + string.Format("{0:ddMMyyyy}", DateTime.Now) + ".txt", ex.Message);
              //SS_MyMessageBox.ShowBox(ex.ToString());
              FormLogview frm = new FormLogview(ex);
              frm.ShowDialog();
          }
          catch (Exception e) 
          {

          } 
          //FormLogview frm = new FormLogview(ex);
          //frm.ShowDialog();  
      }
         public static void Writelogfile(string  ex)
         {
             Writelogfile(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Log\\Log-Simat-" + string.Format("{0:ddMMyyyy}", DateTime.Now) + ".txt", ex);
             //SS_MyMessageBox.ShowBox(ex);
             FormLogview frm = new FormLogview(ex);
             frm.ShowDialog();
         }
         public static void Writelogfile(string filename, string msg)
         {
             try
             {
                 DateTime Now = new DateTime();
                 System.IO.StreamWriter Filewr;
                 Filewr = new System.IO.StreamWriter(filename, true);
                 Filewr.WriteLine(DateTime.Now + ">>>>> " + msg);
                 Filewr.Flush();
                 Filewr.Close();
             }
             catch (Exception e) 
             {
             }
         }
    }
}
