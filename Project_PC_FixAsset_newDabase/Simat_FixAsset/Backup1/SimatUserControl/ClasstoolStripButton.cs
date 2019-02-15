using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using SimatSoft.QueryManager;
namespace System.Windows.Forms.Samples
{
    class ClasstoolStripButton:ToolStripButton 
    {
        public string id;
        public string name="";
        public DataSet private_dataset=null ;
        public TreeView folderTreeView;
        public ToolStripMenuItem toolStripMenuItem = null;
        public TabControl tabCTRL =null;
        public ToolStripLabel label1;
        public ToolStripLabel label2;
        public SimatSoft.FixAsset.Form_000000_MainMenu frm = new SimatSoft.FixAsset.Form_000000_MainMenu();

        public void Showlistdata()
        {
            Class_ListData cls_list = new Class_ListData();
            WhuserHome whuser = new WhuserHome();
            if (id == null || id == "")
                id = cls_main.menumapping.findMenuDefault();
            private_dataset = whuser.getscreen(SimatSoft.FixAsset.Global.ConfigDatabase.Str_UserID, "M", id);
            set_TreeProfile();
            
        }
        
        public void ShowlistMenu(ToolStripMenuItem toolStripMenuItem,string id)
        {
            Class_ListData cls_list = new Class_ListData();
            WhuserHome whuser = new WhuserHome();
            //if (id == null || id == "")
            //    id = cls_main.menumapping.findMenuDefault();
            private_dataset = whuser.getscreen(SimatSoft.FixAsset.Global.ConfigDatabase.Str_UserID, "M", id);
            set_ToolStripMenuItem(toolStripMenuItem);
        }

        public void ShowlistMenuReport()
        {
            Class_ListData cls_list = new Class_ListData();
            ReportHome Report = new ReportHome();
            private_dataset = Report.getreportmenu(SimatSoft.FixAsset.Global.ConfigDatabase.Str_UserID, "M", id);
            set_TreeReport();
        }


        //private void Showlistdata()
        //  {
        //      Class_ListData cls_list = new Class_ListData();
        //      WhuserHome whuser = new WhuserHome();
        //      if (id != "Report")
        //      {
        //          //private_dataset = whuser.getscreen(cls_main.userid, "M", id);
        //          private_dataset = whuser.getscreen("111", "M", id);
        //          set_TreeProfile();
        //         cls_main.menutype = "Screen";
                   
        //      }
        //      else 
        //      {
        //          private_dataset = whuser.getreportmenu (cls_main.userid, "M", id);
        //          set_TreeReport();
        //          cls_main.menutype  = "Report";
        //      }
        //  }
        private void set_TreeProfile()
        {
            try
            {
                folderTreeView.Nodes.Clear();
                folderTreeView.Nodes.Add("All", "All");
                if (private_dataset.Tables.Count > 0)
                {
                    for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                        folderTreeView.Nodes["All"].Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), private_dataset.Tables[0].Rows[i][1].ToString());
                }
                folderTreeView.ExpandAll();
            }
            catch (Exception Err)
            {
                //Simat_Log.Classlogfile.writelogfile(ex);   
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void set_ToolStripMenuItem(ToolStripMenuItem toolStripMenuItem)
        {
            try
            {
                ClasstoolStripButton menu = new ClasstoolStripButton();
                //toolStripMenuItem.DropDownItems.Clear();
                //toolStripMenuItem.DropDownItems.Add( 
                if (private_dataset.Tables.Count > 0)
                {
                    for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                    {
                        //EventArgs ev = null;
                        //object ob = null;
                        ////ToolStripItem y=new ToolStripItem(private_dataset.Tables[0].Rows[i][0].ToString(), private_dataset.Tables[0].Rows[i][1].ToString());
                        //InitializeComponent_1();
                        //toolStripMenuItem.DropDownItems.Add(private_dataset.Tables[0].Rows[i][1].ToString());
                        ////toolStripMenuItem.DropDownItems.Add(private_dataset.Tables[0].Rows[i][0].ToString(), null, ClassMENU_Click(ob, ev));
                        // folderTreeView.Nodes["All"].Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), private_dataset.Tables[0].Rows[i][1].ToString());
                        menu = new ClasstoolStripButton();

                        menu.CheckOnClick = true;
                       // menu = loadIMG(menu, private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString());
                        menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                        menu.ImageScaling = ToolStripItemImageScaling.None;
                        menu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
                        menu.Margin = new System.Windows.Forms.Padding(0);
                        menu.Name = "toolStripButton5";
                        menu.Padding = new System.Windows.Forms.Padding(2);
                        menu.Size = new System.Drawing.Size(126, 18);
                        menu.Tag = private_dataset.Tables[0].Rows[i][0].ToString();
                        menu.Text = private_dataset.Tables[0].Rows[i][1].ToString();
                        menu.id = private_dataset.Tables[0].Rows[i][0].ToString();
                        //InitializeComponent_1();
                        menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

                        menu.Click += new System.EventHandler(menu.ClassMENU_Click);
                        toolStripMenuItem.DropDownItems.Add(menu);
                        //menu.InitializeComponent();
                    }
                }

            }
            catch (Exception Err)
            {
                //Simat_Log.Classlogfile.writelogfile(ex);
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void InitializeComponent_1()
        {
            // 
            // ClasstoolStripButton
            // 
            this.Click += new System.EventHandler(this.ClassMENU_Click);

        }
        public void ClassMENU_Click(object sender, EventArgs e)
        {
            
            //MessageBox.Show(this.Tag.ToString());
            SimatSoft.FixAsset.Form_000000_MainMenu frm = new SimatSoft.FixAsset.Form_000000_MainMenu();
            frm.show_data(this.Tag.ToString());
        }

        private void set_TreeReport()
        {
            try
            {
                TreeNode node;
                string submenu = "";
                folderTreeView.Nodes.Clear();
                node = folderTreeView.Nodes.Add("All", "All");
                if (private_dataset.Tables.Count > 0)
                {

                    for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                    {
                        if (submenu != private_dataset.Tables[0].Rows[i]["ReportGroup"].ToString())
                        {
                            submenu = private_dataset.Tables[0].Rows[i]["ReportGroup"].ToString();
                            node = folderTreeView.Nodes["All"].Nodes.Add("G-" + private_dataset.Tables[0].Rows[i][0].ToString(), private_dataset.Tables[0].Rows[i]["ReportGroupDes"].ToString());
                        }
                        node.Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), "ID" + private_dataset.Tables[0].Rows[i][0].ToString() + ":" + private_dataset.Tables[0].Rows[i][1].ToString());
                    }
                    folderTreeView.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                //SimatSoft.Log.Classlogfile.Writelogfile(ex);
            }
        }

        public  void InitializeComponent()
        {
            // 
            // ClasstoolStripButton
            // 
            this.Click += new System.EventHandler(this.ClasstoolStripButton_Click);

        }

       
        public void ClasstoolStripButton_Click(object sender, EventArgs e)
        {
            Showlistdata();
            if (this.Text == "" || this.Text == null)
            {
                cls_main.id = "";
                cls_main.id = cls_main.menumapping.findMenuDefault();
                name = cls_main.menumapping.findNameMenu(cls_main.id);
            }
            else if (this.Text == "Report")
            {
                name = this.Text;
                ShowlistMenuReport();
            }
            else
            {
                name = this.Text;
            }
            
            label1.Text = name;
            label2.Text = name;
        }

    }
     
}
