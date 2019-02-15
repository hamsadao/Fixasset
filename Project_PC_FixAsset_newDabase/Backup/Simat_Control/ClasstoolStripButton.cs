using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using SimatSoft.BusinessObjects;
using System.Windows.Forms;  
namespace SimatSoft.ControlBasic
{
    public class ClasstoolStripButton:ToolStripButton 
    {
        public string id;
        public string name="";
        public DataSet private_dataset=null ;
        public TreeView folderTreeView;
        public ToolStripLabel label1;
        public ToolStripLabel label2;
        public string menutype="";
        public Boolean SelectedButton = false;
        public ClasstoolStripButton()
        {
            InitializeComponent();

        }

        private void set_Query()
        {
            DataSet ds = new DataSet();
         
            try
            {
                ds.ReadXml(Application.StartupPath + "\\Data\\Query-Menu.XML");
                private_dataset = ds;
               folderTreeView.Nodes.Clear();
               folderTreeView.Nodes.Add("All", "All");
               if (private_dataset.Tables.Count > 0)
               {
                   for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                       folderTreeView.Nodes["All"].Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), private_dataset.Tables[0].Rows[i][1].ToString());
               }
               folderTreeView.ExpandAll();  
            }
            catch (Exception) {
            } 
        }
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
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);   
            }
        }
        private void set_TreeReport()
        {
            try
            {
                TreeNode   node;
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
                        node.Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), "ID" + private_dataset.Tables[0].Rows[i][0].ToString() + ":" +  private_dataset.Tables[0].Rows[i][1].ToString());
                    }
                    folderTreeView.ExpandAll();  
                }
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);
            }
        }
        private void set_TreeMenunew()
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
                        if (submenu != private_dataset.Tables[0].Rows[i][2].ToString())
                        {
                            submenu = private_dataset.Tables[0].Rows[i][2].ToString();
                            node = folderTreeView.Nodes["All"].Nodes.Add("G-" + private_dataset.Tables[0].Rows[i][2].ToString(), private_dataset.Tables[0].Rows[i][3].ToString());
                        }
                        node.Nodes.Add(private_dataset.Tables[0].Rows[i][0].ToString(), "ID" + private_dataset.Tables[0].Rows[i][0].ToString() + ":" + private_dataset.Tables[0].Rows[i][1].ToString());
                    }
                    folderTreeView.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);
            }
        }
        public  void InitializeComponent()
        {
            // 
            // ClasstoolStripButton
            // 
            this.Click += new System.EventHandler(this.ClasstoolStripButton_Click);

        }

        private void ClasstoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelectedButton  = true;  
                name = this.Text;
                label1.Text = name;
                label2.Text = name;
                switch (menutype)
                {
                    case "Report" :
                        set_TreeReport();
                        break;
                    case "MENUNEW":
                        set_TreeMenunew();
                        break;

                    default :
                        set_TreeProfile();
                        break;
                }
                folderTreeView.ExpandAll();  
             }
            catch (Exception ex) 
            {
            }
            
        }
    }
     
}
