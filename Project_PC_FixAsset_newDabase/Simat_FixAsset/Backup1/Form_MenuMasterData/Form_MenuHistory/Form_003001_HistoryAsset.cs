using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wilson.ORMapper;
using SimatSoft.DB.ORM;

namespace SimatSoft.FixAsset
{
    public partial class Form_003001_HistoryAsset : Form
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.SetDefault;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_003001_HistoryAsset()
        {
            InitializeComponent();
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.SetDefault);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:003001(HistoryAsset)");
        }

        private void Form_003001_HistoryAsset_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_003001_HistoryAsset_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowData();
        }
        private void Function_ShowData()
        {
            DataSet DS = new DataSet();
            DS = Manager.Engine.GetDataSet<Asset>("");
            sS_DataGridView_HistoryAsset.DataSource = DS;
            sS_DataGridView_HistoryAsset.DataMember = "Table";
        }

        private void Form_003001_HistoryAsset_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_003001_HistoryAsset_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }
        
    }
}