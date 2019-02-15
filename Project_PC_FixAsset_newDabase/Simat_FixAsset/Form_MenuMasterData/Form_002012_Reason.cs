using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.CustomControl;
using SimatSoft.DB.ORM;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    public partial class Form_002012_Reason : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002012_Reason()
        {
            InitializeComponent();
            DarkColor = Global.ConfigForm.Colr_BackColor;
            Function_IntitialControl();
            Global.Function_ToolStripSetUP(Enum_Mode.Search);

            AuthorizeState.Function_SetAuthorize(this.Name.Substring(5, 6).Replace("0", ""));
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Function_IntitialControl()
        {
            this.Text = Global.Function_Language(this, this, "ID:002012(Reason)");
            LBL_ReasonNo.Text = Global.Function_Language(this, LBL_ReasonNo, " Reason No:");
            LBL_Reason.Text = Global.Function_Language(this, LBL_Reason, "Reason Name:");
        }

        private void Form_002012_Reason_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            sS_MaskedTextBox_ReasonNo.ReadOnly = true;
            Function_SetReadOnlyControl(true);
            Function_ClearData(); 
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                ReasonHome ReasonHomeObj = new ReasonHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_ReasonNo = new object[1] { sS_MaskedTextBox_ReasonNo.Text };
                object[] Obj_ReasonRow = new object[1] { sS_DataGridView_Reason.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_ReasonNo.ReadOnly = false;
                        sS_MaskedTextBox_ReasonNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                ReasonHomeObj.Reasonobj.Code = sS_MaskedTextBox_ReasonNo.Text;
                                ReasonHomeObj.Reasonobj.Name = sS_MaskedTextBox_Reason.Text;

                                Reason ReasonObj = new Reason();
                                ReasonObj = Manager.Engine.GetObject<Reason>(sS_MaskedTextBox_ReasonNo.Text);
                                if (ReasonObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("ReasonNo : " + sS_MaskedTextBox_ReasonNo.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_ReasonNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_ReasonNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (ReasonHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_ReasonNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_ReasonNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;
                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_ReasonNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_ReasonNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        goto DEFAULT;
                                    }
                                }
                            }
                            else
                                Global.Bool_CheckComplete = false;
                                break;
                        }
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_Reason.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                ReasonHomeObj.Reasonobj.Code = sS_MaskedTextBox_ReasonNo.Text;
                                ReasonHomeObj.Reasonobj.Name = sS_MaskedTextBox_Reason.Text;
                                if (ReasonHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_ReasonNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_ReasonNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_ReasonNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_ReasonNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                }
                                Enm_StateForm = Enum_Mode.PreEdit;
                                Function_ExecuteTransaction(Enum_Mode.Cancel);
                                Function_ShowDataInDatagridView();
                                //goto DEFAULT;
                            }
                            else
                                Global.Bool_CheckComplete = false;
                                break;
                        }
                    case Enum_Mode.Delete:
                        {
                            if (sS_DataGridView_Reason.SelectedRows.Count > 1)
                            {
                                List<Reason> ReasonCollection = new List<Reason>();
                                Reason TempReason = new Reason();
                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Reason.SelectedRows)
                                {
                                    TempReason = Manager.Engine.GetObject<Reason>(TempDataGridRow.Cells[0].Value.ToString());
                                    ReasonCollection.Add(TempReason);
                                }

                                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Reason.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_ReasonRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {

                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (ReasonHomeObj.Delete(ORTransaction, ReasonCollection))
                                    {
                                        ORTransaction.Commit();
                                        SS_MyMessageBox.ShowBox("Delete data complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000012", Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ShowDataInDatagridView();
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not delete data ", "Warning", DialogMode.OkOnly, this.Name, "000013", Global.Lang.Str_Language);
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
                            {
                                if (sS_MaskedTextBox_ReasonNo.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_ReasonNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_ReasonNo, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        ReasonHomeObj.Reasonobj.Code = sS_MaskedTextBox_ReasonNo.Text;
                                        if (ReasonHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_ReasonNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_ReasonNo, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_ReasonNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_ReasonNo, Global.Lang.Str_Language);
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

                                    //goto DEFAULT;
                                }
                                else
                                    Global.Bool_CheckComplete = false;
                            }
                                break;
                        }
                 case Enum_Mode.ShowData://
                     if (sS_DataGridView_Reason.Rows.Count > 0)
                     {
                         sS_MaskedTextBox_ReasonNo.ReadOnly = true;
                         sS_MaskedTextBox_ReasonNo.Text = sS_DataGridView_Reason[0, sS_DataGridView_Reason.CurrentRow.Index].Value.ToString();
                         Reason ReasonObj = new Reason();
                         ReasonObj = Manager.Engine.GetObject<Reason>(sS_MaskedTextBox_ReasonNo.Text);
                         if(ReasonObj!=null)
                         {
                            sS_MaskedTextBox_Reason.Text = ReasonObj.Name;
                         }
                         sS_MaskedTextBox_ReasonNo.Focus();
                     }
                     break;
                 case Enum_Mode.ShowData_search://
                     if (sS_DataGridView_Reason.Rows.Count > 0)
                     {
                         sS_MaskedTextBox_ReasonNo.ReadOnly = true;
                         //sS_MaskedTextBox_ReasonNo.Text = sS_DataGridView_Reason[0, sS_DataGridView_Reason.CurrentRow.Index].Value.ToString();
                         Reason ReasonObj = new Reason();
                         ReasonObj = Manager.Engine.GetObject<Reason>(sS_MaskedTextBox_ReasonNo.Text);
                         if (ReasonObj != null)
                         {
                             sS_MaskedTextBox_Reason.Text = ReasonObj.Name;
                         }
                         sS_MaskedTextBox_ReasonNo.Focus();
                     }
                     break;

                 case Enum_Mode.Cancel:
                     if (Enm_StateForm == Enum_Mode.PreEdit)
                     {
                         Function_ExecuteTransaction(Enum_Mode.ShowData);
                         sS_MaskedTextBox_ReasonNo.Focus();
                     }
                     if (Enm_StateForm == Enum_Mode.PreAdd)
                     {
                         Function_ClearData();
                         sS_MaskedTextBox_ReasonNo.Focus();
                         Function_ShowDataInDatagridView();
                     }
                     if (Enm_StateForm == Enum_Mode.PreSearch)
                     {
                         sS_MaskedTextBox_ReasonNo.ReadOnly = true;
                         Function_SetReadOnlyControl(true);
                         Enm_StateForm = Enum_Mode.PreAdd;
                     }
                     else
                     {
                         sS_MaskedTextBox_ReasonNo.ReadOnly = true;
                         Function_SetReadOnlyControl(true);
                         Enm_StateForm = Enum_Mode.Search;
                     }
                     break;
                 DEFAULT:
                     Function_ClearData();
                     sS_MaskedTextBox_ReasonNo.ReadOnly = false;
                     sS_MaskedTextBox_ReasonNo.Focus();
                     Function_ShowDataInDatagridView();
                     break;
                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ClearData()
        {
            try
            {
                sS_MaskedTextBox_ReasonNo.Text = "";
                sS_MaskedTextBox_Reason.Text = "";
                
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ShowDataInDatagridView()
        {
            try
            {
                // sS_DataGridView1.SortOrder = SortOrder.None;
                // this.sS_DataGridView1.SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                //sS_DataGridView_Reason.DataSource = Manager.Engine.GetObjectSet<Reason>("");
                DataSet Ds = new DataSet();
                Ds = Manager.Engine.GetDataSet<Reason>("");
                sS_DataGridView_Reason.DataSource = Ds;
                sS_DataGridView_Reason.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        private void Function_ShowDataInControl()
        {
            try
            {
                if (sS_DataGridView_Reason.Rows.Count > 0)
                {
                    sS_MaskedTextBox_ReasonNo.Text = sS_DataGridView_Reason[0, sS_DataGridView_Reason.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_Reason.Text = sS_DataGridView_Reason[1, sS_DataGridView_Reason.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_ReasonNo.Focus();

                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
           
            sS_MaskedTextBox_Reason.ReadOnly = Bool_StateControl;
        }
        private void sS_ButtonGlass_Cancel_Click(object sender, EventArgs e)
        {
            Global.Function_ToolStripSetUP(Enum_Mode.Search);
            Function_ClearData();
        }

        private void Form_002012_Reason_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_002012_Reason_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Reason_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_002012_Reason_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

        private void sS_MaskedTextBox_ReasonNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Function_ShowDataSerchKey();

            }
        }
        private void Function_ShowDataSerchKey()
        {

            Function_ExecuteTransaction(Enum_Mode.ShowData_search);

        }
    }
}