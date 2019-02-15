using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.CustomControl;

namespace SimatSoft.DB.ORM
{
  public   class ClassMenuMapping
    {
        private System.Data.DataSet DatasetMenu;
      private System.Data.DataSet dsTabMenu;
      private System.Data.DataSet defaultMenu;

        public ClassMenuMapping()
        {
            PresentData present = new PresentData();
            DatasetMenu = present.loaddata(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\Menu.Xml");
            dsTabMenu = present.loaddata(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\tabMenu.Xml");
            defaultMenu = present.loaddata(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Present\\defaultMenu.Xml");
        }
        public string FindMenu(string menuid) 
        {
            try
            {
                if (DatasetMenu.Tables.Count > 0)
                    for (int i = 0; i < DatasetMenu.Tables[0].Rows.Count; i++)
                    {
                        if (DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString() == menuid)
                            return DatasetMenu.Tables[0].Rows[i]["Profilename"].ToString();
                    }
                return "";
            }
            catch (Exception Err)
            {
                
                //Simat_Log.Classlogfile.writelogfile(e);
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
                return "";
            }
        }
      public string FindtabIndex(string tbMenuId)
      {
          try
          {
              if(dsTabMenu.Tables.Count>0)
                  for (int i = 0; i < dsTabMenu.Tables[0].Rows.Count ; i++)
                  {
                      if(dsTabMenu.Tables[0].Rows[i]["tbMenuId"].ToString() == tbMenuId)
                          return dsTabMenu.Tables[0].Rows[i]["tabMenu"].ToString();
                  }
              return "";
          }
          catch (Exception Err)
          {
              //Simat_Log.Classlogfile.writelogfile(e);
              SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              return "";
          }
      }
      public string FindMenuType(string menuid)
      {
          try
          {
              if (DatasetMenu.Tables.Count > 0)
                  for (int i = 0; i < DatasetMenu.Tables[0].Rows.Count; i++)
                  {
                      if (DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString() == menuid)
                          return DatasetMenu.Tables[0].Rows[i]["MenuType"].ToString();
                  }
              return "";
          }
          catch (Exception Err)
          {

              //Simat_Log.Classlogfile.writelogfile(e);
              SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              return "";
          }
      }
      public string findMenuDefault()
      {
          try
          {
              if (defaultMenu.Tables.Count > 0)
                  for (int i = 0; i < defaultMenu.Tables[0].Rows.Count; i++)
                 {
              //        //if (defaultMenu.Tables[0].Rows[i]["defaultMenu"].ToString() == id)
                          return defaultMenu.Tables[0].Rows[i]["defaultMenu"].ToString();
                  }
              return "";
          }
          catch (Exception Err)
          {

             // Simat_Log.Classlogfile.writelogfile(e);
              SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              return "";
          }
      }
      public string findNameMenu(string id)
      {
          try
          {
              if (dsTabMenu.Tables.Count > 0)
                  for (int i = 0; i < dsTabMenu.Tables[0].Rows.Count; i++)
                  {
                      if (dsTabMenu.Tables[0].Rows[i]["tbMenuId"].ToString() == id)
                          return dsTabMenu.Tables[0].Rows[i]["Profilename"].ToString();
              }
              return "";
          }
          catch (Exception Err)
          {

              //Simat_Log.Classlogfile.writelogfile(e);
              SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              return "";
          }
      }
      public string treeMenu(string id)
      {
          try
          {
              if (DatasetMenu.Tables.Count > 0)
                  for (int i = 0; i < DatasetMenu.Tables[0].Rows.Count; i++)
                  {
                     // if (DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString() == id)
                          return DatasetMenu.Tables[0].Rows[i]["Menuid"].ToString();
                  }
              return "";
          }
          catch (Exception Err)
          {

              //Simat_Log.Classlogfile.writelogfile(e);
              SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
              return "";
          }
      }
      private void getTabIndex()
      {
          throw new Exception("The method or operation is not implemented.");
      }

        public string FindMenu()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
