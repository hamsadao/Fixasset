using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SimatSoft.ReportManagerWinForm
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }

        public void PrintReport(String ReportProfilename, String ServerName, String DBname, String Userid, String UserPasswod, string SelectionFormula)
        {
            CrystalDecisions.Shared.TableLogOnInfos crtableLogoninfos = new CrystalDecisions.Shared.TableLogOnInfos();
            CrystalDecisions.Shared.TableLogOnInfo crtableLogoninfo = new CrystalDecisions.Shared.TableLogOnInfo();
            CrystalDecisions.Shared.ConnectionInfo crConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
            CrystalDecisions.CrystalReports.Engine.Tables CrTables;// = new CrystalDecisions.CrystalReports.Engine.Tables(); 
            CrystalDecisions.CrystalReports.Engine.Table CrTable;// = new CrystalDecisions.CrystalReports.Engine.Table(); 
            CrystalDecisions.CrystalReports.Engine.ReportDocument crReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            CrystalDecisions.Shared.ParameterField pr;
            CrystalDecisions.Shared.ParameterDiscreteValue dv = new CrystalDecisions.Shared.ParameterDiscreteValue(); 
            try
            {
                string reportfilename = "";
                DataSet ds =  new DataSet() ;
                ds.ReadXml(Application.StartupPath + "\\Data\\Present\\Report\\" + ReportProfilename);
                reportfilename = Application.StartupPath + "\\Data\\" + ds.Tables[0].Rows[0]["ReportFile"].ToString();
                crReportDocument.Load(reportfilename);
                crConnectionInfo.ServerName = ds.Tables[0].Rows[0]["Datasource"].ToString();
                crConnectionInfo.DatabaseName = DBname ;
                crConnectionInfo.UserID = Userid;
                crConnectionInfo.Password = UserPasswod ;
                CrTables = crReportDocument.Database.Tables;
                for (int i = 0; i < CrTables.Count; i++)
                {
                    CrTable = CrTables[i];
                    crtableLogoninfo = (CrystalDecisions.Shared.TableLogOnInfo)CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                crystalReportViewer2.ReportSource = crReportDocument;
                crystalReportViewer2.SelectionFormula = SelectionFormula; 
                //  crview.RefreshReport();   


            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            }
        }

        public void PrintReport(String ReportProfilename, String ServerName, String DBname, String Userid, String UserPasswod, string SelectionFormula, object[] objParam, object[] objValue, ref FormReport rpFrm)
        {
            CrystalDecisions.Shared.TableLogOnInfos crtableLogoninfos = new CrystalDecisions.Shared.TableLogOnInfos();
            CrystalDecisions.Shared.TableLogOnInfo crtableLogoninfo = new CrystalDecisions.Shared.TableLogOnInfo();
            CrystalDecisions.Shared.ConnectionInfo crConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
            CrystalDecisions.CrystalReports.Engine.Tables CrTables;// = new CrystalDecisions.CrystalReports.Engine.Tables(); 
            CrystalDecisions.CrystalReports.Engine.Table CrTable;// = new CrystalDecisions.CrystalReports.Engine.Table(); 
            CrystalDecisions.CrystalReports.Engine.ReportDocument crReportDocument = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            CrystalDecisions.Windows.Forms.CrystalReportViewer crReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            
            CrystalDecisions.Shared.ParameterFields pr;
            CrystalDecisions.Shared.ParameterDiscreteValue dv = new CrystalDecisions.Shared.ParameterDiscreteValue();
            CrystalDecisions.Shared.ParameterValues currentParameterValues = new CrystalDecisions.Shared.ParameterValues();
            CrystalDecisions.Shared.ParameterField prField = new CrystalDecisions.Shared.ParameterField();
            try
            {
                string reportfilename = "";
                DataSet ds = new DataSet();
                ds.ReadXml(Application.StartupPath + "\\Data\\Present\\Report\\" + ReportProfilename);
                reportfilename = Application.StartupPath + "\\Data\\" + ds.Tables[0].Rows[0]["ReportFile"].ToString();
                //crystalReportViewer2.ReportSource = reportfilename;
                crReportDocument.Load(reportfilename);
                crConnectionInfo.ServerName = ds.Tables[0].Rows[0]["Datasource"].ToString();
                crConnectionInfo.DatabaseName = DBname;
                crConnectionInfo.UserID = Userid;
                crConnectionInfo.Password = UserPasswod;

                CrTables = crReportDocument.Database.Tables;
                for (int i = 0; i < CrTables.Count; i++)
                {
                    CrTable = CrTables[i];
                    crtableLogoninfo = (CrystalDecisions.Shared.TableLogOnInfo)CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                crystalReportViewer2.ReportSource = crReportDocument;

                pr = crystalReportViewer2.ParameterFieldInfo;
                for (int i = 0; i < objValue.Length; i++)
                {
                    dv = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    dv.Value = objValue[i].ToString();
                    currentParameterValues = new CrystalDecisions.Shared.ParameterValues();
                    currentParameterValues.Add(dv);

                    prField = pr[objParam[i].ToString()];
                    prField.CurrentValues = currentParameterValues;
                }

                crystalReportViewer2.SelectionFormula = SelectionFormula;
                //  crview.RefreshReport();   

            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            }
        }

        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            crystalReportViewer2.DisplayGroupTree = false;
            crystalReportViewer2.ShowCloseButton = true;
        }
    }
}