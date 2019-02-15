using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using SimatSoft.ControlBasic;
using System.Data;
namespace SimatSoft.QueryManager
{
    public class Class_ListData
    {
        private DataSet private_dataset;
        private DataSet private_dataheader;
        private DataSet private_datasqlcommand;
        private DataSet private_datasearchmember;
        private string P_Sqlcommmand;
        public System.Data.DataSet DataSet
        {
            get{return private_dataset;      }
            set{private_dataset = value;    }
        }
        public string Sqlcommand
        {
            get
            {
                return P_Sqlcommmand;
            }
            set
            {
                P_Sqlcommmand = value;
            }
        }
        public void set_TreeProfile(TreeView folderTreeView)
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
            }
            catch (Exception ex)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(ex);
            }
        }
        public void set_listview(ListView lsv, System.Collections.ArrayList col)
        {
            // create listview col
            Class_Collist colobj = new Class_Collist();
            lsv.Columns.Clear();
            for (int i = 0; i < col.Count; i++)
            {
                colobj = (Class_Collist)col[i];
                lsv.Columns.Add(colobj.name, colobj.width);
            }
            // Fill data to listviews

            if (private_dataset.Tables.Count > 0)
            {
                for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                {
                    ListViewItem lst = new ListViewItem();
                    for (int j = 0; j < col.Count; j++)
                    {
                        colobj = (Class_Collist)col[j];
                        if (j == 0)
                        {
                            lst.Text = private_dataset.Tables[0].Rows[i][colobj.dbfieldname].ToString();
                        }
                        else
                        {
                            lst.SubItems.Add(private_dataset.Tables[0].Rows[i][colobj.dbfieldname].ToString());
                        }
                    }
                    lsv.Items.Add(lst);
                }

            }
        }
        public DataSet datasource
        {
            get
            {
                return private_dataset;
            }
            set
            {
                private_dataset = value;
            }
        }
        public DataSet dataheader
        {
            get
            {
                return private_dataheader;
            }
            set
            {
                private_dataheader = value;
            }
        }
        public DataSet datasqlcommand
        {
            get
            {
                return private_datasqlcommand;
            }
            set
            {
                private_datasqlcommand = value;
            }
        }
        public DataSet datasearchmember
        {
            get
            {
                return private_datasearchmember;
            }
            set
            {
                private_datasearchmember = value;
            }
        }
        public void set_header(ListView lsv)
        {
            try
            {
                // create listview col
                lsv.Columns.Clear();
                HorizontalAlignment colalign;
                for (int i = 0; i < private_dataheader.Tables[0].Rows.Count; i++)
                {
                    string coldesc = private_dataheader.Tables[0].Rows[i]["name"].ToString();
                    int colwidth = int.Parse(private_dataheader.Tables[0].Rows[i]["width"].ToString());

                    switch (private_dataheader.Tables[0].Rows[i]["align"].ToString())
                    {
                        case "left":
                            colalign = HorizontalAlignment.Left;
                            break;
                        case "center":
                            colalign = HorizontalAlignment.Center;
                            break;
                        case "right":
                            colalign = HorizontalAlignment.Right;
                            break;
                        default:
                            colalign = HorizontalAlignment.Left;
                            break;
                    }
                    lsv.Columns.Add(coldesc, colwidth, colalign);

                }
            }
            catch (Exception e) {
                SimatSoft.Log.Classlogfile.Writelogfile(e);  
            }
        }
        public void set_header(DataGridView lsv)
        {
            try
            {
                // create listview col
                lsv.Columns.Clear();
                HorizontalAlignment colalign;
                for (int i = 0; i < private_dataheader.Tables[0].Rows.Count; i++)
                {
                    string coldesc = private_dataheader.Tables[0].Rows[i]["name"].ToString();
                    string entity = private_dataheader.Tables[0].Rows[i]["entity"].ToString();
                    entity = entity.Trim(); 
                    int colwidth = int.Parse(private_dataheader.Tables[0].Rows[i]["width"].ToString());

                    switch (private_dataheader.Tables[0].Rows[i]["align"].ToString())
                    {
                        case "left":
                            colalign = HorizontalAlignment.Left;
                            break;
                        case "center":
                            colalign = HorizontalAlignment.Center;
                            break;
                        case "right":
                            colalign = HorizontalAlignment.Right;
                            break;
                        default:
                            colalign = HorizontalAlignment.Left;
                            break;
                    }
                    DataGridViewColumn aa = new DataGridViewColumn();
                    aa.DataPropertyName = entity ;
                    aa.Name = entity;
                    aa.HeaderText = coldesc;
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    aa.Width = colwidth;
                   aa.CellTemplate=cell ;
                   aa.SortMode = DataGridViewColumnSortMode.Automatic;
                   
                    lsv.Columns.Add(aa );

                }
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);  
            }
        }
        public void showdata(ListView lsv)
        {
            try
            {
                // Fill data to listviews
                if (private_dataset != null)
                    if (private_dataset.Tables.Count > 0)
                    {
                        lsv.Items.Clear();
                        for (int i = 0; i < private_dataset.Tables[0].Rows.Count; i++)
                        {
                            ListViewItem lst = new ListViewItem();
                            string dataitem;
                            for (int j = 0; j < private_dataheader.Tables[0].Rows.Count; j++)
                            {
                                string colname = private_dataheader.Tables[0].Rows[j]["entity"].ToString();
                                string formatdata = private_dataheader.Tables[0].Rows[j]["format"].ToString();
                                string datatype = private_dataheader.Tables[0].Rows[j]["datatype"].ToString().Trim();
                                if (formatdata != "")

                                    switch (datatype)
                                    {
                                        case "datetime":
                                            DateTime temp;
                                            if (private_dataset.Tables[0].Rows[i][j] != null)
                                            {
                                                temp = DateTime.Parse(private_dataset.Tables[0].Rows[i][j].ToString());
                                                dataitem = temp.ToString(formatdata);
                                            }
                                            else
                                                dataitem = "";
                                            break;
                                        case "numeric":
                                            Double d = 0;
                                            dataitem = private_dataset.Tables[0].Rows[i][j].ToString();
                                            if (IsNumeric(dataitem))
                                            {
                                                d = double.Parse(dataitem);
                                                dataitem = d.ToString("$#,##0.00;($#,##0.00);Zero");
                                            }
                                            break;
                                        default:
                                            if (private_dataset.Tables[0].Rows[i][j] != null)
                                                dataitem = private_dataset.Tables[0].Rows[i][j].ToString();
                                            else
                                                dataitem = "";
                                            break;
                                    }

                                else
                                {
                                    if (private_dataset.Tables[0].Rows[i][j] != null)
                                        dataitem = private_dataset.Tables[0].Rows[i][j].ToString();
                                    else
                                        dataitem = "";
                                }

                                if (j == 0)
                                {

                                    lst.Text = dataitem;
                                }
                                else
                                {
                                    lst.SubItems.Add(dataitem);
                                }
                            }
                            lsv.Items.Add(lst);
                        }

                    }
            }
            catch (Exception e) 
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);  
            } 
        }
        public void showdata(DataGridView dataGridView1)
        {
            try
            {
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.VirtualMode = true;
                //dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
                //dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
                //dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
                //dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                //dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
                //dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                //dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                //dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
               // dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                BindingSource messageBS = new BindingSource();
                dataGridView1.DataSource = messageBS;
                dataGridView1.DataSource = private_dataset;
                dataGridView1.DataMember = "Table";

                messageBS.DataSource = private_dataset;
                //dataGridView1.Rows.Add(   P_Dataset.Tables[0].Rows[0]);  


                //  dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);
                // Fill data to datagrid
                ///test
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            } 
        }
        public void showsearchmember(Panel panel,SplitContainer spliter)
        {
            try
            {
                string controltype = "";
                string controlname = "";
                int width = 0;
                string description;
                Control controltemp;
                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i].Name != "buttonSearch")
                    {

                        controltemp = panel.Controls[i];
                        panel.Controls.Remove(controltemp);
                        i = i - 1;
                    }
                }
                if (private_datasearchmember.Tables.Count >0) 
                if (private_datasearchmember != null)
                    for (int i = 0; i < private_datasearchmember.Tables[0].Rows.Count; i++)
                    {
                        spliter.SplitterDistance = 12 + ((i + 1) * 25);
                        controltype = private_datasearchmember.Tables[0].Rows[i]["controltype"].ToString();
                        controlname = private_datasearchmember.Tables[0].Rows[i]["name"].ToString();
                        width = int.Parse(private_datasearchmember.Tables[0].Rows[i]["width"].ToString());
                        description = private_datasearchmember.Tables[0].Rows[i]["description"].ToString();
                        System.Windows.Forms.Label labeltemp = new System.Windows.Forms.Label();
                        switch (controltype)
                        {
                            #region textbox
                            case "textbox":
                                //Create label
                                labeltemp.AutoSize = true;
                                labeltemp.Location = new System.Drawing.Point(25, 12 + (i * 25));
                                labeltemp.Name = "label" + controlname;
                                labeltemp.Size = new System.Drawing.Size(12, 9);
                                labeltemp.TabIndex = 1;
                                labeltemp.Text = description;
                                panel.Controls.Add(labeltemp);
                                //Create text box 
                                //System.Windows.Forms.TextBox textBoxtemp;
                                ClassTextbox textBoxtemp = new ClassTextbox();

                                //textBoxtemp = new  System.Windows.Forms.TextBox();
                                textBoxtemp.Location = new System.Drawing.Point(120, 6 + (i * 25));
                                textBoxtemp.Name = "entity-Textbox" + controlname;
                                textBoxtemp.Size = new System.Drawing.Size(width, 20);
                                textBoxtemp.dataconfig = private_datasearchmember.Tables[0].Rows[i];
                                textBoxtemp.InitializeComponent();
                                panel.Controls.Add(textBoxtemp);
                                break;
                            #endregion
                            #region ComboBox
                            case "combobox":
                                //Create label
                                Sqlcommand = private_datasearchmember.Tables[0].Rows[i]["sqlshowdata"].ToString();
                                labeltemp.AutoSize = true;
                                labeltemp.Location = new System.Drawing.Point(25, 12 + (i * 25));
                                labeltemp.Name = "label" + controlname;
                                labeltemp.Size = new System.Drawing.Size(12, 9);
                                labeltemp.TabIndex = 1;
                                labeltemp.Text = description;
                                panel.Controls.Add(labeltemp);
                                //Create text box 
                                //System.Windows.Forms.TextBox textBoxtemp;
                                ClassComboBox comboboxtemp = new ClassComboBox();
                                PresentData ptemp = new PresentData();
                                System.Data.DataSet ds;
                                ds = ptemp.selectdata(Sqlcommand);
                                ptemp = null;

                                //textBoxtemp = new  System.Windows.Forms.TextBox();
                                comboboxtemp.Location = new System.Drawing.Point(120, 6 + (i * 25));
                                comboboxtemp.Name = "entity-Combobox" + controlname;
                                comboboxtemp.Size = new System.Drawing.Size(width, 20);
                                comboboxtemp.dataconfig = private_datasearchmember.Tables[0].Rows[i];
                                comboboxtemp.datasource = ds;
                                comboboxtemp.InitializeComponent();
                                panel.Controls.Add(comboboxtemp);
                                break;
                            #endregion
                            #region simatdate
                            case "simatdate":
                                //Create label

                                labeltemp.AutoSize = true;
                                labeltemp.Location = new System.Drawing.Point(25, 12 + (i * 25));
                                labeltemp.Name = "label" + controlname;
                                labeltemp.Size = new System.Drawing.Size(12, 9);
                                labeltemp.TabIndex = 1;
                                labeltemp.Text = description;
                                panel.Controls.Add(labeltemp);
                                ClassSimatDateSelect simatdatetemp = new ClassSimatDateSelect();
                                ptemp = null;
                                simatdatetemp.Location = new System.Drawing.Point(120, 6 + (i * 25));
                                simatdatetemp.Name = "entity-simatdate" + controlname;
                                // simatdatetemp.Size = new System.Drawing.Size(width, 20);
                                simatdatetemp.dataconfig = private_datasearchmember.Tables[0].Rows[i];
                                // comboboxtemp.datasource = ds;
                                //simatdatetemp.InitializeComponent();
                                panel.Controls.Add(simatdatetemp);
                                spliter.SplitterDistance = 175 + ((i + 1) * 25);
                                break;
                            #endregion
                        }

                    }
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            } 
        }
        public string  Findquerysearchmember(string  controlname,ref string operation, ref string prefix, ref string sufix,ref string nextoperation)
        {
            try
            {
                string entity = "";

                for (int i = 0; i < private_datasearchmember.Tables[0].Rows.Count; i++)
                {

                    if (controlname == "entity" + private_datasearchmember.Tables[0].Rows[i]["name"].ToString())
                    {
                        entity = private_datasearchmember.Tables[0].Rows[i]["entity"].ToString();
                        operation = private_datasearchmember.Tables[0].Rows[i]["operation"].ToString();
                        prefix = private_datasearchmember.Tables[0].Rows[i]["prefix"].ToString();
                        sufix = private_datasearchmember.Tables[0].Rows[i]["sufix"].ToString();
                        nextoperation = private_datasearchmember.Tables[0].Rows[i]["nextoperation"].ToString();

                    }

                }
                return entity;
            }
            catch (Exception e)
            {
                
                SimatSoft.Log.Classlogfile.Writelogfile(e);
                return "";
            } 
        }
        public bool IsNumeric(string s)
        {
            try
            {
                Int32.Parse(s);
            }
            catch
            {
                return false;
            }
            return true;
        }
      
       
    }
    
}
