using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Wilson.ORMapper;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    public partial class Form_006002_UserGroupAuthorize : SS_PaintGradientForm
    {
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search; 
        public Form_006002_UserGroupAuthorize()
        {
            InitializeComponent();
            Function_IntitialControl();
            
            //Global.Function_ToolStripSetUP(Enum_Mode.Search);
            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            DarkColor = Global.ConfigForm.Colr_BackColor;
            this.Text = Global.Function_Language(this, this, "ID:006002(UserGroupAutolize)");
            LBL_GroupID.Text = Global.Function_Language(this, LBL_GroupID, "Group ID:");
            LBL_GroupName.Text = Global.Function_Language(this, LBL_GroupName, "Group Name:");
            LBL_Company.Text = Global.Function_Language(this, LBL_Company, "Facility:");
        }

        private void Form_006002_UserGroupAutolize_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_006002_UserGroupAutolize_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowScreenNameInDatagrid();
            sS_DataGridView_UserGroupAutolize.ReadOnly = true;
            Function_ReadOnlyControl(true);
            Function_SetReadOnlyDatagrid();
            
        }
        private void Function_ReadOnlyControl(bool Bool_ReadOnly)
        {
            sS_MaskedTextBox_GroupID.ReadOnly = Bool_ReadOnly;
            sS_MaskedTextBox_GroupName.ReadOnly = Bool_ReadOnly;
          
        }

        private void Function_ShowScreenNameInDatagrid()
        {
            DataSet ds = new DataSet();

            ds = Manager.Engine.GetDataSet<SimatSoft.DB.ORM.Screen>("" );

            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                Object[] Rows = new Object[] {false,ds.Tables[0].Rows[i].ItemArray[0], ds.Tables[0].Rows[i].ItemArray[2], false, false, false };

                sS_DataGridView_UserGroupAutolize.Rows.Add(Rows);
            }
            Function_SetReadOnlyDatagrid();
        }
        private void Function_SetReadOnlyDatagrid()
        {
            sS_DataGridView_UserGroupAutolize.Columns[1].ReadOnly = true;
            sS_DataGridView_UserGroupAutolize.Columns[2].ReadOnly = true;
        }
        public void Function_ExecuteTransaction(Enum_Mode Enum_mode)
        {
            try
            {
                Transaction ORTransaction = null;
                bool Bool_CheckExecuteComplete = false;
                WhGroupHome WhGroupHomeObj = new WhGroupHome();
                object[] Obj_GroupID = new object[1] { sS_MaskedTextBox_GroupID.Text };
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                int i = 0;
                switch (Enum_mode)
                {
                    case Enum_Mode.Search:
                        break;
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_ReadOnlyControl(false);
                        sS_MaskedTextBox_FacCode.ReadOnly = true;
                        sS_MaskedTextBox_FacName.ReadOnly = true;                       
                        sS_MaskedTextBox_GroupID.Focus();
                        sS_DataGridView_UserGroupAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();
                        sS_DataGridView_UserGroupAutolize.ReadOnly = false;
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            ORTransaction = Manager.Engine.BeginTransaction();
                            WhGroupHomeObj.WhGroupObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                            WhGroupHomeObj.WhGroupObj.UsGroupName = sS_MaskedTextBox_GroupName.Text;
                            WhGroupHomeObj.WhGroupObj.FacCode = sS_MaskedTextBox_FacCode.Text;

                            WhGroup TempWhGroup = new WhGroup();
                            TempWhGroup = Manager.Engine.GetObject<WhGroup>(sS_MaskedTextBox_GroupID.Text);
                            if (TempWhGroup != null)
                            {
                                SS_MyMessageBox.ShowBox("UserGroupID : " + sS_MaskedTextBox_GroupID.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000008", Obj_GroupID, Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                sS_MaskedTextBox_GroupID.Focus();
                                break;
                            }
                            else
                            {
                                if (WhGroupHomeObj.AddGroup(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;
                                for (i = 0; i <= sS_DataGridView_UserGroupAutolize.Rows.Count - 1; i++)
                                {
                                    if (Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[0, i].Value) == true)
                                    {
                                        WhGroupHomeObj.WhgroupAccessObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                                        WhGroupHomeObj.WhgroupAccessObj.ScID = Convert.ToString(sS_DataGridView_UserGroupAutolize[1, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.AddR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[3, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.DeleteR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[4, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.EditR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[5, i].Value);


                                        if (WhGroupHomeObj.AddGroupAccess(ORTransaction))
                                            Bool_CheckExecuteComplete = true;
                                        else
                                            Bool_CheckExecuteComplete = false;
                                    }
                                }

                                if (Bool_CheckExecuteComplete)
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_GroupID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;

                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ExecuteTransaction(Enum_Mode.Cancel);
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_GroupID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    ORTransaction.Rollback();
                                    //goto DEFAULT;                               
                                }

                            }
                        }
                        else
                            Global.Bool_CheckComplete = false;
                            break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyDatagrid();
                        sS_DataGridView_UserGroupAutolize.ReadOnly = false;
                        sS_MaskedTextBox_GroupID.ReadOnly = true;
                        sS_MaskedTextBox_FacName.ReadOnly = true;
                        sS_MaskedTextBox_GroupName.ReadOnly = false;
                        sS_MaskedTextBox_GroupName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        ORTransaction = Manager.Engine.BeginTransaction();   
                        WhGroupHomeObj.WhGroupObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                        if (WhGroupHomeObj.Delete())
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                WhGroupHomeObj.WhGroupObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                                WhGroupHomeObj.WhGroupObj.UsGroupName = sS_MaskedTextBox_GroupName.Text;
                                WhGroupHomeObj.WhGroupObj.FacCode = sS_MaskedTextBox_FacCode.Text;

                                if (WhGroupHomeObj.AddGroup(ORTransaction))
                                    Bool_CheckExecuteComplete = true;
                                else
                                    Bool_CheckExecuteComplete = false;
                                for (i = 0; i <= sS_DataGridView_UserGroupAutolize.Rows.Count - 1; i++)
                                {
                                    if (Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[0, i].Value) == true)
                                    {
                                        WhGroupHomeObj.WhgroupAccessObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                                        WhGroupHomeObj.WhgroupAccessObj.ScID = Convert.ToString(sS_DataGridView_UserGroupAutolize[1, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.AddR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[3, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.DeleteR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[4, i].Value);
                                        WhGroupHomeObj.WhgroupAccessObj.EditR = Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[5, i].Value);

                                        if (WhGroupHomeObj.AddGroupAccess(ORTransaction))
                                            Bool_CheckExecuteComplete = true;
                                        else
                                            Bool_CheckExecuteComplete = false;
                                    }
                                }
                                if (Bool_CheckExecuteComplete)
                                {
                                    ORTransaction.Commit();
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_GroupID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                    //goto DEFAULT;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_GroupID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    ORTransaction.Rollback();
                                }                         
                                
                            }
                        }
                        Enm_StateForm = Enum_Mode.PreEdit;
                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                        Function_ShowScreenNameInDatagrid();
                        break;
                    case Enum_Mode.Delete:
                        if (sS_MaskedTextBox_GroupID.Text != "")
                        {
                            if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_GroupID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_GroupID, Global.Lang.Str_Language) == DialogResult.OK)
                            {
                                Global.Bool_CheckComplete = true;
                                WhGroupHomeObj.WhGroupObj.UsGroupID = sS_MaskedTextBox_GroupID.Text;
                                if (WhGroupHomeObj.Delete())
                                {
                                    SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_GroupID.Text + " ?", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;

                                    Enm_StateForm = Enum_Mode.PreAdd;
                                    Function_ShowScreenNameInDatagrid();
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_GroupID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_GroupID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;

                                    Enm_StateForm = Enum_Mode.PreEdit;
                                }
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                            }
                            else
                            {
                                Global.Bool_CheckComplete = false;
                                Enm_StateForm = Enum_Mode.PreEdit;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                            }
                        }
                        else
                            Global.Bool_CheckComplete = false;                
                        break;
                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_DataGridView_UserGroupAutolize.Rows.Clear();
                            Function_ShowScreenNameInDatagrid();
                            sS_MaskedTextBox_GroupID.Focus();
                        }
                        Function_ReadOnlyControl(true);
                        Function_SetReadOnlyDatagrid();
                        sS_DataGridView_UserGroupAutolize.ReadOnly = true;
                        Enm_StateForm = Enum_Mode.Search;
                        break;
                    case Enum_Mode.ShowData:
                        sS_MaskedTextBox_GroupID.Focus();
                        sS_DataGridView_UserGroupAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();
                                           
                        Wilson.ORMapper.ObjectSet<WhgroupAccess> TempWhGroupObj = Manager.Engine.GetObjectSet<WhgroupAccess>("usGroupID ='"+sS_MaskedTextBox_GroupID.Text+"'");
                        WhGroup WhGroupObj = new WhGroup();
                        if (WhGroupObj != null)
                        {
                            WhGroupObj = Manager.Engine.GetObject<WhGroup>(sS_MaskedTextBox_GroupID.Text);
                            sS_MaskedTextBox_GroupName.Text = Global.FormOrder.Function_GetGroupName(WhGroupObj.UsGroupID);
                            sS_MaskedTextBox_FacCode.Text = WhGroupObj.FacCode;
                            sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(sS_MaskedTextBox_FacCode.Text);
                        }
                        if (TempWhGroupObj.Count > 0)
                        {
                            for (i = 0; i <= TempWhGroupObj.Count - 1; i++)
                            {
                                  for (int k = 0; k <= sS_DataGridView_UserGroupAutolize.Rows.Count - 1; k++)
                                {
                                    if (sS_DataGridView_UserGroupAutolize[1, k].Value.ToString() == TempWhGroupObj[i].ScID)
                                    {
                                        sS_DataGridView_UserGroupAutolize[0, k].Value = true;
                                        sS_DataGridView_UserGroupAutolize[3, k].Value = TempWhGroupObj[i].AddR;
                                        sS_DataGridView_UserGroupAutolize[4, k].Value = TempWhGroupObj[i].DeleteR;
                                        sS_DataGridView_UserGroupAutolize[5, k].Value = TempWhGroupObj[i].EditR;
                                    }
                                }
                            }
                        }
                        else // เมื่อตอนทำการเพิ่มแต่ไม่ได้เช็ค screenaccess เลย 
                        {
                            Function_ShowScreenNameInDatagrid();
                            
                        }
                        Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
                        sS_MaskedTextBox_GroupID.ReadOnly = true;
                        Function_SetReadOnlyDatagrid();
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_DataGridView_UserGroupAutolize.Rows.Clear();
                        Function_ShowScreenNameInDatagrid();
                        sS_DataGridView_UserGroupAutolize.ReadOnly = true;
                        sS_MaskedTextBox_GroupID.Focus();
                        Function_ReadOnlyControl(true);                      
                        Function_SetReadOnlyDatagrid();
                        break;
                }
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error on Internal Transfer Order Execute Transaction", DialogMode.Error_Cancel, Ex);
            }
        }
        private void Function_ClearData()
        {
            sS_MaskedTextBox_GroupID.Text = "";
            sS_MaskedTextBox_GroupName.Text = "";
            sS_MaskedTextBox_FacCode.Text = "";
            sS_MaskedTextBox_FacName.Text = "";
        }
        private void Function_ClearCheckboxInDatatgrid()
        {
            for (int i = 0; i <= sS_DataGridView_UserGroupAutolize.Rows.Count - 1; i++)
            {
                for (int k = 0; k <= sS_DataGridView_UserGroupAutolize.Columns.Count - 1; k++)
                {
                    
                    bool isChecked = ((CheckBox)sS_DataGridView_UserGroupAutolize[k, i].Value).Checked;
                    if (isChecked ==true)
                        ((CheckBox)sS_DataGridView_UserGroupAutolize[k, i].Value).Checked = false;

                }
            }
        }


        private void sS_MaskedTextBox_FacCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)||(Enm_StateForm ==Enum_Mode.PreEdit)))
                {
                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_FacCode;
                    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_FacName;
                    Frm_Present.Show_Data("Screen", "002006");

                    Frm_Present.ShowDialog();
                    Frm_Present.Dispose();
                }               
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }

        private void sS_MaskedTextBox_GroupID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {

                    SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                    Frm_Present.Controlreturnvalue = sS_MaskedTextBox_GroupID;
                    Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_GroupName;
                    Frm_Present.Controlreturnvalue3 = sS_MaskedTextBox_FacCode;
                    Frm_Present.Show_Data("Screen", "006002");                   
                    Frm_Present.ShowDialog();
                    
                    Frm_Present.Dispose();

                    if (sS_MaskedTextBox_GroupID.Text != "")
                    {
                        sS_MaskedTextBox_FacName.Text = Global.FormOrder.Function_GetFacName(sS_MaskedTextBox_FacCode.Text);
                        Function_ExecuteTransaction(Enum_Mode.ShowData);
                        sS_DataGridView_UserGroupAutolize.ReadOnly = true;
                        
                    }
                }
                
                
            }
            catch (Exception Ex)
            {
                SS_MyMessageBox.ShowBox(Ex.Message, "Error On Purchase Order Select PO", DialogMode.Error_Cancel, Ex);
            }
        }
      

        private void sS_DataGridView_UserGroupAutolize_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool Bool_Check = false;
            if ((e.ColumnIndex == 0) && ((Enm_StateForm == Enum_Mode.PreAdd) || (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                if (e.RowIndex != -1)
                {
                    sS_DataGridView_UserGroupAutolize[e.ColumnIndex, e.RowIndex].Value = !Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[e.ColumnIndex, e.RowIndex].Value);

                    if (Convert.ToBoolean(sS_DataGridView_UserGroupAutolize[0, e.RowIndex].Value) == true)
                        Bool_Check = true;
                    else
                        Bool_Check = false;
                }

                sS_DataGridView_UserGroupAutolize[3, e.RowIndex].Value = Bool_Check;
                sS_DataGridView_UserGroupAutolize[4, e.RowIndex].Value = Bool_Check;
                sS_DataGridView_UserGroupAutolize[5, e.RowIndex].Value = Bool_Check;
            }
        }

        private void Form_006002_UserGroupAuthorize_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            bool Bool_Check = false;
            if (((Enm_StateForm == Enum_Mode.PreAdd) | (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                for (int i = 0; i <= Convert.ToUInt32(sS_DataGridView_UserGroupAutolize.RowCount.ToString()) - 1; i++)
                {
                    Bool_Check = true;
                    sS_DataGridView_UserGroupAutolize[0, i].Value = Bool_Check;
                    for (int n = 3; n <= 5; n++)
                    {
                        sS_DataGridView_UserGroupAutolize[n, i].Value = Bool_Check;
                    }
                }
            }
        }

        private void btnDiselect_Click(object sender, EventArgs e)
        {
            bool Bool_Check = true;
            if (((Enm_StateForm == Enum_Mode.PreAdd) | (Enm_StateForm == Enum_Mode.PreEdit)))
            {
                for (int i = 0; i <= Convert.ToUInt32(sS_DataGridView_UserGroupAutolize.RowCount.ToString()) - 1; i++)
                {
                    Bool_Check = false;
                    sS_DataGridView_UserGroupAutolize[0, i].Value = Bool_Check;
                    for (int n = 3; n <= 5; n++)
                    {
                        sS_DataGridView_UserGroupAutolize[n, i].Value = Bool_Check;
                    }
                }
            }
        }

        private void Form_006002_UserGroupAuthorize_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
        }

     
       
        
     
    }
}