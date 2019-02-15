using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.DB.ORM;

namespace SimatSoft.FixAsset
{
    class Class_AuthorizeState
    {
        private string Str_FormID;
        private bool Bool_Add;
        private bool Bool_Edit;
        private bool Bool_Delete;
        //private Enum_Mode Enm_StateForm;

        public Class_AuthorizeState()
        {
            Str_FormID = "";
            Bool_Add = false;
            Bool_Edit = false;
            Bool_Delete = false;
         //   Enm_StateForm = Enum_Mode.Search;
        }

        public string FormID
        {
            set { this.Str_FormID = value; }
        }

        public bool Author_Add
        {
            set { this.Bool_Add = value; }
        }

        public bool Author_Edit
        {
            set { this.Bool_Edit = value; }
        }

        public bool Author_Delete
        {
            set { this.Bool_Delete = value; }
        }

        public void Function_SetAuthorize(string Str_Form)
        {
            string Str_WhereExpression = "UsID ='"+ Global.ConfigDatabase.Str_UserID + 
                                         "' AND ScID ='"+ Str_Form +"'";
            Wilson.ORMapper.OPathQuery<WhuserAccess> TempOpath = new Wilson.ORMapper.OPathQuery<WhuserAccess>(Str_WhereExpression);
            WhuserAccess TempWhuserAccess = Manager.Engine.GetObject<WhuserAccess>(TempOpath);

            Bool_Add = TempWhuserAccess.AddR;
            Bool_Edit = TempWhuserAccess.EditR;
            Bool_Delete = TempWhuserAccess.DeleteR;
        }

        public void Funtion_SetButtonAuthorize(Enum_Mode TempEnmMode)
        {
            Global.Function_ToolStripSetUP(TempEnmMode);
            switch (TempEnmMode)
            {
                case Enum_Mode.Search :
                    Global.ConfigForm.MDIToolStrip_Add.Enabled = Bool_Add;
                    Global.ConfigForm.MDIToolStrip_Find.Enabled = true;
                    break;
                case Enum_Mode.CellClick :
                    Global.ConfigForm.MDIToolStrip_Add.Enabled = Bool_Add;
                    Global.ConfigForm.MDIToolStrip_Edit.Enabled = Bool_Edit;
                    Global.ConfigForm.MDIToolStrip_Delete.Enabled = Bool_Delete;
                    Global.ConfigForm.MDIToolStrip_Find.Enabled = true;
                    break;

            }
        }
    }
}
