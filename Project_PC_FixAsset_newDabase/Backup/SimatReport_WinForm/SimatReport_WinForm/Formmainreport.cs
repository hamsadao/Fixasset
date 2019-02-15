using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.ControlBasic;

namespace SimatSoft.ReportManagerWinForm
{
    public partial class Form_MainReport : Form
    { 
       
        cls_main clsmain = new cls_main();   
        public  String Dbname;
        public String UserName;
        public String UserPassword;
        public int int_count_report;
        public int Int_CountForm;
        public SimatSoft.CustomControl.SS_TabStrip  MDITabStrip;
     

        public Form_MainReport()
        {
            InitializeComponent();
        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ShowReport(string id , Wilson.ORMapper.ObjectSpace EngineRef)
        {
            try
            {
                crystalReportViewer1.Visible = true;
                clsmain.ReportMG = new ClassReportMG();
                clsmain.profilename = "";
                clsmain.profilename = clsmain.reportmapping.FindMenu(id);

                if (clsmain.profilename != "")
                {
                    clsmain.ReportMG.search(System.Windows.Forms.Application.StartupPath, clsmain.profilename);
                    clsmain.cls_list.dataheader = clsmain.ReportMG.dsheader;
                    clsmain.cls_list.datasqlcommand = clsmain.ReportMG.dsquery;
                    loadreportmember(clsmain.ReportMG.dsquery);
                    clsmain.cls_list.datasearchmember = clsmain.ReportMG.dssearchmember;
                    clsmain.cls_list.Engine = EngineRef;
                    clsmain.cls_list.showsearchmember(splitContainer4.Panel1, splitContainer4);

                }
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile (e );     
            }
        }
        private void loadreportmember(DataSet ds) 
        {
            if (ds != null) 
            {
                   for (int i = 0; i < ds.Tables[0].Rows.Count; i++) 
                        Reportname.Items.Add(ds.Tables[0].Rows[i][1]);
                    Reportname.SelectedIndex = 0;   
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
         
            this.Close();
  
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
        
        }
        private void showreport()
        {

            try
            {
                string Reporttype = clsmain.cls_list.datasqlcommand.Tables[0].Rows[0]["Reporttype"].ToString();
                string sqlwhere = "";
        
                string operation = "";
                string prefix = "";
                string sufix = "";
                string nextoperation = "";
                string entity = "";
                Control Controltemp;
                ClassTextbox Controltempds;
                ClassComboBox Controltempcombobox;
                ClassSimatDateSelect ControlSimatDate;
                SimatDateTimeSelect ControlSimatDatetime;
                string userinputvalue = "";
                string Reportfilename="";
                string Sql_DefaultSelect = "";
                DateTime dt_user;
                try
                {
                    Reportfilename = clsmain.cls_list.datasqlcommand.Tables[0].Rows[Reportname.SelectedIndex][0].ToString();
                    Sql_DefaultSelect = clsmain.cls_list.datasqlcommand.Tables[0].Rows[Reportname.SelectedIndex]["Query"].ToString();      
                }
                catch { } 
                switch (Reporttype)
                {
                    #region ODBC

                    case "ODBC":
                        for (int i = 0; i < splitContainer4.Panel1.Controls.Count; i++)
                        {
                            userinputvalue = "";
                            Controltemp = splitContainer4.Panel1.Controls[i];

                            if (Controltemp.Name.IndexOf("entity") == 0)
                            {
                                if (Controltemp.Name.IndexOf("Textbox") > 0)
                                {
                                    userinputvalue = Controltemp.Text.ToString();
                                    Controltempds = (ClassTextbox)splitContainer4.Panel1.Controls[i];
                                    //Find Query for search  
                                    entity = Controltempds.dataconfig["entity"].ToString();
                                    operation = Controltempds.dataconfig["operation"].ToString();
                                    prefix = Controltempds.dataconfig["prefix"].ToString();
                                    sufix = Controltempds.dataconfig["sufix"].ToString();
                                    nextoperation = Controltempds.dataconfig["nextoperation"].ToString();

                                }
                                if (Controltemp.Name.IndexOf("Combobox") > 0)
                                {
                                    userinputvalue = Controltemp.Text.ToString();
                                    Controltempcombobox = (ClassComboBox)splitContainer4.Panel1.Controls[i];
                                    entity = Controltempcombobox.dataconfig["entity"].ToString();
                                    operation = Controltempcombobox.dataconfig["operation"].ToString();
                                    prefix = Controltempcombobox.dataconfig["prefix"].ToString();
                                    sufix = Controltempcombobox.dataconfig["sufix"].ToString();
                                    nextoperation = Controltempcombobox.dataconfig["nextoperation"].ToString();
                                }
                                if (Controltemp.Name.IndexOf("simatdate") > 0)
                                {
                                    ControlSimatDate = (ClassSimatDateSelect)splitContainer4.Panel1.Controls[i];
                                    userinputvalue = ControlSimatDate.Datevalue().ToString();
                                    if (userinputvalue.Length == 10)
                                    {
                                        string tempdate = userinputvalue.Substring(6, 4) + userinputvalue.Substring(3, 2) + userinputvalue.Substring(0, 2);
                                        //userinputvalue = " DateTime( " + userinputvalue.Substring(6, 4) + "," + userinputvalue.Substring(3, 2) + "," + userinputvalue.Substring(0, 2) +  ",00,00,01)"; // tempdate;
                                        userinputvalue = " Date( " + userinputvalue.Substring(6, 4) + "," + userinputvalue.Substring(3, 2) + "," + userinputvalue.Substring(0, 2) +")"; // tempdate;
                                        Controltemp.Text = userinputvalue; 
                                    }

                                    entity = ControlSimatDate.dataconfig["entity"].ToString();
                                    operation =  ControlSimatDate.dataconfig["operation"].ToString();
                                    prefix = ControlSimatDate.dataconfig["prefix"].ToString();
                                    sufix = ControlSimatDate.dataconfig["sufix"].ToString();
                                    nextoperation = ControlSimatDate.dataconfig["nextoperation"].ToString();
                                }
                                if (Controltemp.Name.IndexOf("simattimedate") > 0)
                                {
                                    ControlSimatDatetime  = (SimatDateTimeSelect )splitContainer4.Panel1.Controls[i];
                                    dt_user = ControlSimatDatetime.textvalue() ;
                                    if (dt_user.ToString()  != "")
                                    {
                                        //string tempdate = userinputvalue.Substring(6, 4) + userinputvalue.Substring(3, 2) + userinputvalue.Substring(0, 2);
                                        //userinputvalue = " DateTime( " + userinputvalue.Substring(6, 4) + "," + userinputvalue.Substring(3, 2) + "," + userinputvalue.Substring(0, 2) +  ",00,00,01)"; // tempdate;
                                        userinputvalue = " DateTime( " + dt_user.Year + "," + cutstring_right("00" + dt_user.Month.ToString(), 2) + "," + cutstring_right("00" + dt_user.Day.ToString(), 2) + "," + cutstring_right("00" + dt_user.Hour.ToString(), 2) + "," + cutstring_right("00" + dt_user.Minute.ToString(), 2) + "," + cutstring_right("00" + dt_user.Second.ToString(), 2) + ")"; // tempdate;
                                        Controltemp.Text = userinputvalue;
                                    }

                                    entity = ControlSimatDatetime.dataconfig["entity"].ToString();
                                    operation = ControlSimatDatetime.dataconfig["operation"].ToString();
                                    prefix = ControlSimatDatetime.dataconfig["prefix"].ToString();
                                    sufix = ControlSimatDatetime.dataconfig["sufix"].ToString();
                                    nextoperation = ControlSimatDatetime.dataconfig["nextoperation"].ToString();
                                }


                                if ((entity != "") && (userinputvalue != ""))
                                {
                                    if( (Controltemp.Name.IndexOf("simatdate") > 0) ||(Controltemp.Name.IndexOf("simattimedate") > 0) )
                                    {
                                        sqlwhere = sqlwhere + " " + entity + " " + operation  + Controltemp.Text +"  "  ;
                                    }
                                    else 
                                    {
                                    sqlwhere = sqlwhere + " " + entity + " " + operation + " '" + prefix + Controltemp.Text + "" + sufix + "'  ";
                                    }

                                    if (nextoperation != "")
                                        sqlwhere = sqlwhere + nextoperation;
                                    else
                                        sqlwhere = sqlwhere + "   ";
                                }
                            }

                        }

                        if (sqlwhere != "")
                        {
                           
                            if (Reportfilename == "File\\\\Report_CheckStock.rpt")
                            {
                                sqlwhere = sqlwhere + "or isnull({VW_CheckStockAll2.FacCode})   ";
                            }

                            sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 3);
                            clsmain.cls_list.PrintReport(crystalReportViewer1,Dbname ,UserName ,UserPassword ,Reportfilename );
                            if (Sql_DefaultSelect != "")
                                sqlwhere = Sql_DefaultSelect + sqlwhere;
                         
                            crystalReportViewer1.SelectionFormula = sqlwhere;
                        }
                        else
                        {
                            if (Sql_DefaultSelect != "")
                                sqlwhere = Sql_DefaultSelect.Substring(0,Sql_DefaultSelect.Length -4 )  ;
                                
                            crystalReportViewer1.SelectionFormula = "";
                            clsmain.cls_list.PrintReport(crystalReportViewer1,Dbname ,UserName ,UserPassword,Reportfilename ) ;
                        }
                        break;
                    #endregion

                    #region datasource
                    case "DATASOURCE":
                        string sqlwherereport = "";
                        for (int i = 0; i < clsmain.cls_list.dataheader.Tables[0].Rows.Count; i++)
                        {
                            sqlwherereport = "";
                            String[] controlname;
                            String tempp;
                            tempp = clsmain.cls_list.dataheader.Tables[0].Rows[i]["ControlArray"].ToString();
                            controlname = tempp.Split(',');
                            for (int j = 0; j < controlname.Length; j++)
                            {
                                if (sqlwherereport != "")
                                    sqlwherereport = sqlwherereport + " and";
                                sqlwherereport = sqlwherereport + Find_Sqlwhere(controlname[j]);
                            }

                            if (sqlwherereport.IndexOf("and", sqlwherereport.Length - 5) > 0)
                                sqlwherereport = sqlwherereport.Substring(1, sqlwherereport.Length - 5);
                            // add subfix control
                            //sqlwherereport = sqlwherereport + cls_main.cls_list.dataheader.Tables[0].Rows[i]["Sufix"].ToString();
                            clsmain.cls_list.dataheader.Tables[0].Rows[i]["Sqlwhere"] = sqlwherereport;
                        }

                        clsmain.cls_list.PrintReport(crystalReportViewer1,Dbname ,UserName ,UserPassword ,Reportfilename );
                        break;
                    #endregion
                }
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            }
        }
        private string cutstring_left(string dataline, int lendata) 
        {
            if (dataline.Length >= lendata) 
            {
                return dataline.Substring(0, lendata);  
            }
            return "";
        }
        private string cutstring_right(string dataline, int lendata)
        {
            if (dataline.Length >= lendata)
            {
                return dataline.Substring(dataline.Length - lendata, lendata);
            }
            return "";
        }
        private string Find_Sqlwhere(string Controlname)
        {
            string sqlwhere = "";
        
            string operation = "";
            string prefix = "";
            string sufix = "";
            string nextoperation = "";
            string entity = "";
            Control Controltemp;
            ClassTextbox Controltempds;
            ClassComboBox Controltempcombobox;
            ClassSimatDateSelect ControlSimatDate;
            string userinputvalue = "";
            for (int i = 0; i < splitContainer4.Panel1.Controls.Count; i++)
            {
                userinputvalue = "";
                Controltemp = splitContainer4.Panel1.Controls[i];

                if (Controltemp.Name.IndexOf("entity") == 0)
                {
                    if (Controltemp.Name.IndexOf(Controlname) > 0)
                    {
                        if (Controltemp.Name.IndexOf("Textbox") > 0)
                        {
                            userinputvalue = Controltemp.Text.ToString();
                            Controltempds = (ClassTextbox)splitContainer4.Panel1.Controls[i];
                            //Find Query for search  
                            entity = Controltempds.dataconfig["entity"].ToString();
                            operation = Controltempds.dataconfig["operation"].ToString();
                            prefix = Controltempds.dataconfig["prefix"].ToString();
                            sufix = Controltempds.dataconfig["sufix"].ToString();
                            nextoperation = Controltempds.dataconfig["nextoperation"].ToString();

                        }
                        if (Controltemp.Name.IndexOf("Combobox") > 0)
                        {
                            userinputvalue = Controltemp.Text.ToString();
                            Controltempcombobox = (ClassComboBox)splitContainer4.Panel1.Controls[i];
                            entity = Controltempcombobox.dataconfig["entity"].ToString();
                            operation = Controltempcombobox.dataconfig["operation"].ToString();
                            prefix = Controltempcombobox.dataconfig["prefix"].ToString();
                            sufix = Controltempcombobox.dataconfig["sufix"].ToString();
                            nextoperation = Controltempcombobox.dataconfig["nextoperation"].ToString();
                        }
                        if (Controltemp.Name.IndexOf("simatdate") > 0)
                        {
                            ControlSimatDate = (ClassSimatDateSelect)splitContainer4.Panel1.Controls[i];
                            userinputvalue = ControlSimatDate.Datevalue().ToString();
                            if (userinputvalue.Length == 10)
                            {
                                string tempdate = userinputvalue.Substring(6, 4) + userinputvalue.Substring(3, 2) + userinputvalue.Substring(0, 2);
                                userinputvalue = tempdate;
                            }

                            entity = ControlSimatDate.dataconfig["entity"].ToString();
                            operation = ControlSimatDate.dataconfig["operation"].ToString();
                            prefix = ControlSimatDate.dataconfig["prefix"].ToString();
                            sufix = ControlSimatDate.dataconfig["sufix"].ToString();
                            nextoperation = ControlSimatDate.dataconfig["nextoperation"].ToString();
                        }


                        if ((entity != "") && (userinputvalue != ""))
                        {
                            sqlwhere = sqlwhere + " " + entity + " " + operation + " '" + prefix + Controltemp.Text + "" + sufix + "'  ";
                            if (nextoperation != "")
                                sqlwhere = sqlwhere + nextoperation;
                            else
                                sqlwhere = sqlwhere + "   ";
                        }
                    }
                }
            }

            if (sqlwhere != "")
            {

                sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 3);

            }

            return sqlwhere;

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
         
        }

        private void toolStripButton_PreviewReport_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor ;   
            showreport();
            this.Cursor =Cursors.Default ;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
 
        }

        private void Form_MainReport_Load(object sender, EventArgs e)
        {


        }

        private void Form_MainReport_Deactivate(object sender, EventArgs e)
        {
        }

        private void Function_RemoveTabStripBottom(object Int_FormTag)
        {
            if (MDITabStrip.Items.Count != 0)
            {
                foreach(SimatSoft.CustomControl.TabStripButton Tab in MDITabStrip.Items)
                {
                    if (Tab.Tag.Equals(Int_FormTag))
                    {
                        MDITabStrip.Items.Remove(Tab);
                        break;
                    }
                }
                Int_CountForm--;
            }
        }

        private void Form_MainReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Function_RemoveTabStripBottom(this.Tag);
        }

        private void Form_MainReport_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

          

      
    }
}