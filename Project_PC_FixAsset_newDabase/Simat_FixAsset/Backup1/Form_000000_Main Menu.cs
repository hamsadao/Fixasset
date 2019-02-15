using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using System.Windows.Forms.Samples;

namespace SimatSoft.FixAsset
{
    public partial class Form_000000_MainMenu : Form
    {
        delegate void SetTextCallback(string text);
       // SimatSoft.DB.ORM.PresentData Present;
        public Form_000000_MainMenu()
        {
            InitializeComponent();
        }
        private void Form_003000_MainMenu_Load(object sender, EventArgs e)
        {
                cls_main.clsmainmenu.Createmainmenu(stackStrip, folderTreeView, toolStripLabel4, toolStripLabel3);
                cls_main.clstoolStrip.frm = this;
            //load_Tree();
        }
        public void show_data(string datatype)
        {
            try
            {
                System.Windows.Forms.Form Frm = Global.Function_ShowForm(datatype);
                if (Frm == null)
                {
                    
                }
                else
                {
                    if (Frm.MdiParent == null)
                    {
                        //Frm.IsMdiContainer = true;
                        //Form_002001_MDI Frm1 = new Form_002001_MDI();

                        ////Frm.MdiParent = Frm;
                        //Frm.ActiveMdiChild.Activate();
                        //Frm.MdiParent = Frm.MdiParent;
                        Frm.MdiParent = this.MdiParent;
                        //Frm.MdiParent = this.MdiParent;

                    }
                    else
                    {

                        Frm.MdiParent = this.MdiParent;
                    }
                    Frm.MdiParent = this.MdiParent;
                    Point Loc = Global.SetLocation(this.MdiParent.ActiveMdiChild.Location.X, this.MdiParent.ActiveMdiChild.Width, this.MdiParent.ActiveMdiChild.Location.Y);

                    int Int_TempIDForm = Global.ConfigForm.Int_IDForm++;

                    Frm.Show();
                    Frm.Tag = Int_TempIDForm;
                    Frm.Location = Loc;
                    Global.Function_AddTabStripButton(Int_TempIDForm, Frm.Name);
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox("show_data: " + Err.Message, "Error On Menu show_data", DialogMode.Error_Cancel, Err);
            }
        }
       public void load_Tree()
        {
            try
            {
                if (stackStrip.ItemCount > 0)
                {
                    // stackStrip.Items[0].  .Selected = true;
                    object obj = null;
                    EventArgs ev = null;
                    // string name = "";
                    //string id ="2";
                    cls_main.clstoolStrip.folderTreeView = folderTreeView;
                    cls_main.profilename = "";
                    cls_main.clstoolStrip.label1 = toolStripLabel4;
                    cls_main.clstoolStrip.label2 = toolStripLabel3;
                    cls_main.clstoolStrip.ClasstoolStripButton_Click(obj, ev);
                }
                if (folderTreeView.Nodes.Count > 0)
                {
                    TreeNodeCollection treCol = folderTreeView.Nodes;
                    folderTreeView.ExpandAll();
                    folderTreeView.Nodes["All"].Nodes[0].Index.ToString();
                    folderTreeView.Focus();
                    folderTreeView.SelectedNode = treCol[0].Nodes[0];
                    folderTreeView.Focus();
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }

        private void folderTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((folderTreeView.SelectedNode != null) && (folderTreeView.SelectedNode.Name.ToString() != "All"))
                {
                    show_data(folderTreeView.SelectedNode.Name.ToString());
                    
                }    
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void folderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}