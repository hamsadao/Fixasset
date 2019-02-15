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
    public partial class Form_002013_Status : SS_PaintGradientForm
    {
        private Enum_Mode Enm_StateForm = Enum_Mode.Search;
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        public Form_002013_Status()
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
            this.Text = Global.Function_Language(this, this, "ID:002013(Status)");
            LBL_StatusID.Text = Global.Function_Language(this, LBL_StatusID, " Status ID:");
            LBL_StatusName.Text = Global.Function_Language(this, LBL_StatusName, "Status Name:");
        }
        private void Form_002013_Status_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            sS_MaskedTextBox_StatusID.ReadOnly = true;
            Function_SetReadOnlyControl(true);
            Function_ClearData();
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                StatusHome StatusHomeObj = new StatusHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_StatusID = new object[1] { sS_MaskedTextBox_StatusID.Text };
                object[] Obj_StatusRow = new object[1] { sS_DataGridView_Status.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_StatusID.ReadOnly = false;
                        sS_MaskedTextBox_StatusID.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;
                        break;
                    case Enum_Mode.Add:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                StatusHomeObj.Statusobj.ID = sS_MaskedTextBox_StatusID.Text;
                                StatusHomeObj.Statusobj.Name = sS_MaskedTextBox_StatusName.Text;

                                Status StatusObj = new Status();
                                StatusObj = Manager.Engine.GetObject<Status>(sS_MaskedTextBox_StatusID.Text);
                                if (StatusObj != null)
                                {
                                    SS_MyMessageBox.ShowBox("StatusID : " + sS_MaskedTextBox_StatusID.Text + " is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_StatusID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_StatusID.Focus();
                                    break;
                                }
                                else
                                {
                                    if (StatusHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_StatusID.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_StatusID, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;

                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_StatusID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_StatusID, Global.Lang.Str_Language);
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
                        sS_MaskedTextBox_StatusName.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                StatusHomeObj.Statusobj.ID = sS_MaskedTextBox_StatusID.Text;
                                StatusHomeObj.Statusobj.Name = sS_MaskedTextBox_StatusName.Text;
                                if (StatusHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_StatusID.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_StatusID, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_StatusID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_StatusID, Global.Lang.Str_Language);
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
                            if (sS_DataGridView_Status.SelectedRows.Count > 1)
                            {
                                List<Status> StatusCollection = new List<Status>();
                                Status TempStatus = new Status();
                                foreach (DataGridViewRow TempDataGridRow in sS_DataGridView_Status.SelectedRows)
                                {
                                    TempStatus = Manager.Engine.GetObject<Status>(TempDataGridRow.Cells[0].Value.ToString());
                                    StatusCollection.Add(TempStatus);
                                }
                                if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Status.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_StatusRow, Global.Lang.Str_Language) == DialogResult.OK)
                                {

                                    Wilson.ORMapper.Transaction ORTransaction = Manager.Engine.BeginTransaction();

                                    if (StatusHomeObj.Delete(ORTransaction, StatusCollection))
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
                                if (sS_MaskedTextBox_StatusID.Text != "")
                                {
                                    if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_StatusID.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_StatusID, Global.Lang.Str_Language) == DialogResult.OK)
                                    {
                                        Global.Bool_CheckComplete = true;
                                        StatusHomeObj.Statusobj.ID = sS_MaskedTextBox_StatusID.Text;
                                        if (StatusHomeObj.Delete())
                                        {
                                            SS_MyMessageBox.ShowBox("Delete data : " + sS_MaskedTextBox_StatusID.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_StatusID, Global.Lang.Str_Language);
                                            Global.Bool_CheckComplete = true;

                                            Enm_StateForm = Enum_Mode.PreAdd;
                                            Function_ShowDataInDatagridView();
                                        }
                                        else
                                        {
                                            SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_StatusID.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_StatusID, Global.Lang.Str_Language);
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
                      if (sS_DataGridView_Status.Rows.Count > 0)
                      {
                          sS_MaskedTextBox_StatusID.ReadOnly = true;
                          sS_MaskedTextBox_StatusID.Text = sS_DataGridView_Status[0, sS_DataGridView_Status.CurrentRow.Index].Value.ToString();
                          Status StatusObj = new Status();
                          StatusObj = Manager.Engine.GetObject<Status>(sS_MaskedTextBox_StatusID.Text);
                          if (StatusObj != null)
                          {
                              sS_MaskedTextBox_StatusName.Text = StatusObj.Name;
                          }
                          sS_MaskedTextBox_StatusID.Focus();
                      }
                       break;
                 case Enum_Mode.Cancel:
                     if (Enm_StateForm == Enum_Mode.PreEdit)
                     {
                         Function_ExecuteTransaction(Enum_Mode.ShowData);
                         sS_MaskedTextBox_StatusID.Focus();
                     }
                     if (Enm_StateForm == Enum_Mode.PreAdd)
                     {
                         Function_ClearData();
                         sS_MaskedTextBox_StatusID.Focus();
                         Function_ShowDataInDatagridView();
                     }
                     sS_MaskedTextBox_StatusID.ReadOnly = true;
                     Function_SetReadOnlyControl(true);
                     Enm_StateForm = Enum_Mode.Search;
                     break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_StatusID.ReadOnly = false;
                        sS_MaskedTextBox_StatusID.Focus();
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
                sS_MaskedTextBox_StatusID.Text = "";
                sS_MaskedTextBox_StatusName.Text = "";
                
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
               // sS_DataGridView_Status.DataSource = Manager.Engine.GetObjectSet<Status>("");
                DataSet Ds = new DataSet();
                Ds = Manager.Engine.GetDataSet<Status>("");
                sS_DataGridView_Status.DataSource = Ds;
                sS_DataGridView_Status.DataMember = "Table";
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
                if (sS_DataGridView_Status.Rows.Count > 0)
                {
                    sS_MaskedTextBox_StatusID.Text = sS_DataGridView_Status[0, sS_DataGridView_Status.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_StatusName.Text = sS_DataGridView_Status[1, sS_DataGridView_Status.CurrentRow.Index].Value.ToString();
                    sS_MaskedTextBox_StatusID.Focus();

                }
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_StatusName.ReadOnly = Bool_StateControl;
            
        }

        private void Form_002013_Status_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        private void Form_002013_Status_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Status_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_002013_Status_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }

       
      
    }
}