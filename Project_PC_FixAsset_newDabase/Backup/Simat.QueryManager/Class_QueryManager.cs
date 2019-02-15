using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.QueryManager;
using System.Windows.Forms;
using SimatSoft.CustomControl;

namespace SimatSoft.QueryManager
{
    public class Class_QueryManager
    {
        public Class_PresentData clsmain = new Class_PresentData();
        //public void Show_Data(string datatype, string id,System.Windows.Forms.Form  Frm, ref System.Windows.Forms.DataGridView RefdataGridView)
        public void Show_Data(string datatype, string id, System.Windows.Forms.Form Frm, ref SS_DataGridView RefdataGridView)
        {
            System.Collections.ArrayList col = new System.Collections.ArrayList();
            clsmain.Present = new  PresentData();
            clsmain.profilename = "";
            clsmain.profilename = clsmain.menumapping.FindMenu(id);
            if (clsmain.profilename != "")
            {
                clsmain.Present.search(System.Windows.Forms.Application.StartupPath, clsmain.profilename);
                clsmain.cls_list.dataheader = clsmain.Present.dsheader;
                clsmain.cls_list.datasqlcommand = clsmain.Present.dsquery;
                clsmain.cls_list.datasearchmember = clsmain.Present.dssearchmember;
                clsmain.cls_list.set_header(RefdataGridView);
                clsmain.cls_list.DataSet = clsmain.Present.dssource;
                clsmain.cls_list.showdata(RefdataGridView);
                
            }
        }
        //public void Searchdata(System.Windows.Forms.Form  Frm,    ref System.Windows.Forms.DataGridView RefdataGridView)
        public void Searchdata(System.Windows.Forms.Form Frm, ref SS_DataGridView RefdataGridView)
        {
            try
            {
                string sqlwhere = "";
                string operation = "";
                string prefix = "";
                string sufix = "";
                string nextoperation = "";
                string entity = "";
                System.Windows.Forms.Control  Controltemp;
                
                string userinputvalue = "";
                for (int i = 0; i < clsmain.Present.dssearchmember.Tables[0].Rows.Count; i++)
                {
                    string Controlname =clsmain.Present.dssearchmember.Tables[0].Rows[i]["name"].ToString();
                    string[] tempcontrolname = Controlname.Split('.');
                    Controltemp = null;
                    if (tempcontrolname.Length > 0)
                    {
                        // หา control ที่เป็น base ที่สุด
                        Controltemp = Frm.Controls[tempcontrolname[0]];
                        for (int j = 1; j < tempcontrolname.Length; j++)
                            {
                                Controltemp = Controltemp.Controls[tempcontrolname[j]];  
                            }
                        

                    }
                    
                    userinputvalue = Controltemp.Text.ToString();
                    entity = clsmain.Present.dssearchmember.Tables[0].Rows[i]["entity"].ToString();
                    operation = clsmain.Present.dssearchmember.Tables[0].Rows[i]["operation"].ToString();
                    prefix = clsmain.Present.dssearchmember.Tables[0].Rows[i]["prefix"].ToString();
                    sufix = clsmain.Present.dssearchmember.Tables[0].Rows[i]["sufix"].ToString();
                    nextoperation = clsmain.Present.dssearchmember.Tables[0].Rows[i]["nextoperation"].ToString();
                    if ((entity != "") && (userinputvalue != ""))
                    {
                        sqlwhere = sqlwhere + " " + entity + " " + operation + " N'" + prefix + Controltemp.Text + "" + sufix + "'  ";
                        if (nextoperation != "")
                            sqlwhere = sqlwhere + nextoperation;
                        else
                            sqlwhere = sqlwhere + "   ";
                    }
                }  
                //for (int i = 0; i < splitContainer4.Panel1.Controls.Count; i++)
                //{
                //    userinputvalue = "";
                //    Controltemp = splitContainer4.Panel1.Controls[i];

                //    if (Controltemp.Name.IndexOf("entity") == 0)
                //    {
                //        if (Controltemp.Name.IndexOf("Textbox") > 0)
                //        {
                //            userinputvalue = Controltemp.Text.ToString();
                //            Controltempds = (ClassTextbox)splitContainer4.Panel1.Controls[i];
                //            //Find Query for search  
                //            entity = Controltempds.dataconfig["entity"].ToString();
                //            operation = Controltempds.dataconfig["operation"].ToString();
                //            prefix = Controltempds.dataconfig["prefix"].ToString();
                //            sufix = Controltempds.dataconfig["sufix"].ToString();
                //            nextoperation = Controltempds.dataconfig["nextoperation"].ToString();

                //        }
                //        if (Controltemp.Name.IndexOf("Combobox") > 0)
                //        {
                //            userinputvalue = Controltemp.Text.ToString();
                //            Controltempcombobox = (ClassComboBox)splitContainer4.Panel1.Controls[i];
                //            entity = Controltempcombobox.dataconfig["entity"].ToString();
                //            operation = Controltempcombobox.dataconfig["operation"].ToString();
                //            prefix = Controltempcombobox.dataconfig["prefix"].ToString();
                //            sufix = Controltempcombobox.dataconfig["sufix"].ToString();
                //            nextoperation = Controltempcombobox.dataconfig["nextoperation"].ToString();
                //        }
                //        if (Controltemp.Name.IndexOf("simatdate") > 0)
                //        {
                //            ControlSimatDate = (ClassSimatDateSelect)splitContainer4.Panel1.Controls[i];
                //            userinputvalue = ControlSimatDate.Datevalue().ToString();
                //            if (userinputvalue.Length == 10)
                //            {
                //                string tempdate = userinputvalue.Substring(6, 4) + userinputvalue.Substring(3, 2) + userinputvalue.Substring(0, 2);
                //                userinputvalue = tempdate;
                //            }

                //            entity = ControlSimatDate.dataconfig["entity"].ToString();
                //            operation = ControlSimatDate.dataconfig["operation"].ToString();
                //            prefix = ControlSimatDate.dataconfig["prefix"].ToString();
                //            sufix = ControlSimatDate.dataconfig["sufix"].ToString();
                //            nextoperation = ControlSimatDate.dataconfig["nextoperation"].ToString();
                //        }


                //        if ((entity != "") && (userinputvalue != ""))
                //        {
                //            sqlwhere = sqlwhere + " " + entity + " " + operation + " N'" + prefix + Controltemp.Text + "" + sufix + "'  ";
                //            if (nextoperation != "")
                //                sqlwhere = sqlwhere + nextoperation;
                //            else
                //                sqlwhere = sqlwhere + "   ";
                //        }
                //    }

                //}

                if (sqlwhere != "")
                {
                    sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 3);
                    clsmain.cls_list.DataSet = clsmain.Present.selectdataforsearch(sqlwhere);
                }
                else
                    clsmain.cls_list.DataSet = clsmain.Present.selectdata();
                clsmain.cls_list.showdata(RefdataGridView);
                
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            }
        }

    }
}
