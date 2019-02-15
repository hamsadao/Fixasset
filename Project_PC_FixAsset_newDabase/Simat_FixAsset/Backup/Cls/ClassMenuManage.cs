using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms.Samples;
namespace System.Windows.Forms.Samples
{
    class ClassMenuManage
    {
        private DataSet private_dsmainmenu;
        public DataSet Dsmainmenu
        {
            get { return private_dsmainmenu; }
            set { private_dsmainmenu = value; }
        }
        public void Createmainmenu(StackStrip stack, TreeView folderTreeView, ToolStripLabel label1, ToolStripLabel label2) 
        {
            ClasstoolStripButton menu = new ClasstoolStripButton();
            if (private_dsmainmenu != null) 
            for (int i = 0; i < private_dsmainmenu.Tables[0].Rows.Count; i++)
            {
                menu = new ClasstoolStripButton();
                menu.CheckOnClick = true;
                //menu.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                //menu.TextImageRelation = TextImageRelation.Overlay;
                //menu.AutoSize = false;
                //menu.Image = global::System.Windows.Forms.Samples.Properties.Resources.Archive;
                menu = loadIMG(menu, private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString());
                menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                menu.ImageScaling = ToolStripItemImageScaling.None;
                menu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
                menu.Margin = new System.Windows.Forms.Padding(0);
                menu.Name = "toolStripButton5";
                menu.Padding = new System.Windows.Forms.Padding(2);
                //menu.Size = new System.Drawing.Size(145, 30);
                menu.Size = new System.Drawing.Size(261, 32);
                menu.Tag =private_dsmainmenu.Tables[0].Rows[i]["ScsubTypeDes"].ToString()    ;
                menu.Text = private_dsmainmenu.Tables[0].Rows[i]["ScsubTypeDes"].ToString();
                menu.id = private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString();
                menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                menu.folderTreeView = folderTreeView; 
                menu.label1 =label1 ;
                menu.label2 =label2 ;
                menu.InitializeComponent();
                stack.Items.Add(menu); 
 
            }
        //menu = new ClasstoolStripButton();
        //menu.CheckOnClick = true;
        //menu.Image = global::System.Windows.Forms.Samples.Properties.Resources.Shortcut24;
        //menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //menu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
        //menu.Margin = new System.Windows.Forms.Padding(0);
        //menu.Name = "toolStripButton11";
        //menu.Padding = new System.Windows.Forms.Padding(2);
        //menu.Size = new System.Drawing.Size(261, 32);
        //menu.Tag = "Shortcut";
        //menu.Text = "Shortcuts";
        //menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        //menu.folderTreeView = folderTreeView;
        //menu.label1 = label1;
        //menu.label2 = label2;
        //stack.Items.Add(menu);  

        }
        ClasstoolStripButton loadIMG(ClasstoolStripButton menu, string id)
        {
            string ss = "SUBTYPE";
            if (id + ss == "1" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._1Transaction;
            }
            if (id + ss == "2" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._data;
            }
            if (id + ss == "3" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._3history;
            }
            if (id + ss == "4" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._4Report;
            }
            if (id + ss == "5" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._5barcode;
            }
            if (id + ss == "6" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._6UserSystem;
            }
            if (id + ss == "7" + ss)
            {
                menu.Image = global::SimatSoft.FixAsset.Properties.Resources._databaseSetup;
            }
            return menu;
        }

        public void CreatemainmenuToolStrip(ToolStripMenuItem stack)
        {
            ToolStripMenuItem menu = new ToolStripMenuItem();
            if (private_dsmainmenu != null)
                for (int i = 0; i < private_dsmainmenu.Tables[0].Rows.Count; i++)
                {
                    menu = new ToolStripMenuItem();

                    menu.CheckOnClick = true;
                   // menu = loadIMG(menu, private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString());
                    menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                    menu.ImageScaling = ToolStripItemImageScaling.None;
                    menu.ImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
                    menu.Margin = new System.Windows.Forms.Padding(0);
                    menu.Name = "toolStripButton5";
                    menu.Padding = new System.Windows.Forms.Padding(2);
                    menu.Size = new System.Drawing.Size(126, 18);
                    menu.Tag = private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString();
                    menu.Text = private_dsmainmenu.Tables[0].Rows[i]["ScsubTypeDes"].ToString();
                    //menu.id = private_dsmainmenu.Tables[0].Rows[i]["SCsubType"].ToString();
                    menu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                    //menu.InitializeComponent();
                  //  cls_main.clstoolStrip.toolStripMenuItem = stack;

                    stack.DropDownItems.Add(menu);
                    cls_main.id = menu.Tag.ToString();
                    ClasstoolStripButton cls_tool = new ClasstoolStripButton();
                    cls_tool.ShowlistMenu(menu,menu.Tag.ToString());

                   // name = cls_main.menumapping.findNameMenu(menu.id);

                }
        }
    }
}
