using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.DB.ORM;
using SimatSoft.CustomControl;
using System.IO;
using SimatSoft.ValidateData;

namespace SimatSoft.FixAsset
{
    public partial class Form_002003_Pictures : SS_PaintGradientForm
    {
        //byte[] photo = GetPhoto(photoFilePath);
        OpenFileDialog fdlg = new OpenFileDialog();
        private string Str_PicturePath = "";
        private string Str_OldModelID = "";
            
        Class_AuthorizeState AuthorizeState = new Class_AuthorizeState();
        private Enum_Mode Enm_StateForm = Enum_Mode.Search; 

        public Form_002003_Pictures()
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
            this.Text = Global.Function_Language(this, this, "ID:002003(Pictures)");
            LBL_AssetNo.Text = Global.Function_Language(this, LBL_AssetNo, " Area No:");
            LBL_ModelNo.Text = Global.Function_Language(this, LBL_ModelNo, "Model No:");
            LBL_Picture.Text = Global.Function_Language(this, LBL_Picture, "Picture:");
            
        }
        private void button_Browse_Click(object sender, EventArgs e)
        {
            object[] Obj_AssetNo = new object[1] { sS_MaskedTextBox_AssetNo.Text };
            fdlg.Title = "Browse";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sS_MaskedTextBox_Picture.Text = fdlg.FileName;
                    Str_PicturePath = fdlg.FileName;
                    pictureBox_Picture.Image = Image.FromFile(fdlg.FileName);
                }
                catch (Exception Err)
                {
                    SS_MyMessageBox.ShowBox("Unable to load file: " + Err.Message, "Error", DialogMode.Error_Cancel, this.Name, "000008", Global.Lang.Str_Language);
                }
                fdlg.Dispose();
            }
        }
        public static byte[] GetPhoto(string filePath)
        {
         
                FileStream FileStream_Fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                BinaryReader BinaryReader_Br = new BinaryReader(FileStream_Fs);

                byte[] Photo = BinaryReader_Br.ReadBytes((int)FileStream_Fs.Length);
                BinaryReader_Br.Close();
                FileStream_Fs.Close();
          
                return Photo;
           
        }
        private void Form_002003_Pictures_Load(object sender, EventArgs e)
        {
            Global.Location.Int_CountForm = Global.Location.Int_CountForm + 0;
            Function_ShowDataInDatagridView();
            Function_SetReadOnlyControl(true);
            Function_SetReadOnlyControlSearch(true);
        }
        private void Function_ShowDataInDatagridView()
        {
            try
            {
                //sS_DataGridView_Picture.DataSource = ManagerPic.Engine.GetObjectSet<AssetPic>("");
                DataSet Ds = new DataSet();
                Ds = ManagerPic.Engine.GetDataSet<AssetPic>("");
                sS_DataGridView_Picture.DataSource = Ds;
                sS_DataGridView_Picture.DataMember = "Table";
                Ds.Dispose();
                Ds = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public void Function_ExecuteTransaction(Enum_Mode mode)
        {
            try
            {
                AssetPicHome AssetPicHomeObj = new AssetPicHome();
                ValidateuserinputData ValidateInput = new ValidateuserinputData(Global.ConfigPath.Str_AppPathValidate + "\\" + this.Name + ".xml", this);
                object[] Obj_AssetNo = new object[1] { sS_MaskedTextBox_AssetNo.Text };
                object[] Obj_AssetPicRow = new object[1] { sS_DataGridView_Picture.SelectedRows.Count };
                switch (mode)
                {
                    case Enum_Mode.Search:
                        {
                            break;
                        }
                    case Enum_Mode.PreAdd:
                        Function_ClearData();
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_AssetNo.ReadOnly = true;
                        sS_MaskedTextBox_AssetNo.Focus();
                        Enm_StateForm = Enum_Mode.PreAdd;

                        break;
                    case Enum_Mode.Add:
                        if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                        {
                            AssetPicHomeObj.AssetPicobj.AssetID = sS_MaskedTextBox_AssetNo.Text;
                            AssetPicHomeObj.AssetPicobj.ModelID = sS_MaskedTextBox_ModelNo.Text;
                            AssetPicHomeObj.AssetPicobj.PathPicture = sS_MaskedTextBox_Picture.Text;
                            if (sS_MaskedTextBox_Picture.Text == "")
                            {
                                SS_MyMessageBox.ShowBox("Picture path not found", "Warning", DialogMode.OkOnly,this.Name,"000011",Global.Lang.Str_Language);
                                Global.Bool_CheckComplete = false;
                                button_Browse.Focus();
                                break;
                            }
                            else
                            {
                                AssetPicHomeObj.AssetPicobj.Picture = GetPhoto(sS_MaskedTextBox_Picture.Text);
                                // check Data if duplicate data
                                string SQL = "(AssetID ='" + sS_MaskedTextBox_AssetNo.Text + "')AND (ModelID = '" + sS_MaskedTextBox_ModelNo.Text + "')";
                               
                                Wilson.ORMapper.OPathQuery<AssetPic> TempAssetPicObj = new Wilson.ORMapper.OPathQuery<AssetPic>(SQL);

                                AssetPic AssetPicObj = new AssetPic();
                                AssetPicObj = ManagerPic.Engine.GetObject<AssetPic>(TempAssetPicObj);

                                if (AssetPicObj != null)
                                {
                                  
                                    SS_MyMessageBox.ShowBox("AssetNo : " + sS_MaskedTextBox_AssetNo.Text + "And ModeNo :" + sS_MaskedTextBox_ModelNo.Text + "is duplicate data", "Warning", DialogMode.OkOnly, this.Name, "000010", Obj_AssetNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                    sS_MaskedTextBox_AssetNo.Focus();
                                    break;
                                }
                                else
                                {
                                    if (AssetPicHomeObj.Add())
                                    {
                                        SS_MyMessageBox.ShowBox("Add data : " + sS_MaskedTextBox_AssetNo.Text + " Complete", "Add Data Information", DialogMode.OkOnly, this.Name, "000001", Obj_AssetNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = true;
                                        Enm_StateForm = Enum_Mode.PreAdd;
                                        Function_ExecuteTransaction(Enum_Mode.Cancel);
                                    }
                                    else
                                    {
                                        SS_MyMessageBox.ShowBox("Can not add data: " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000002", Obj_AssetNo, Global.Lang.Str_Language);
                                        Global.Bool_CheckComplete = false;
                                        goto DEFAULT;
                                    }
                                }
                            }
                        }
                        else
                            Global.Bool_CheckComplete = false;
                                break;
                    case Enum_Mode.PreEdit:
                        Function_SetReadOnlyControl(false);
                        sS_MaskedTextBox_AssetNo.ReadOnly = true;
                        Str_OldModelID = this.sS_MaskedTextBox_ModelNo.Text;
                        button_Browse.Focus();
                        Enm_StateForm = Enum_Mode.PreEdit;
                        break;
                    case Enum_Mode.Edit:
                        {
                            if (ValidateInput.ValidateData(Global.Lang.Str_Language))
                            {
                                //InvPicHomeObj.InvPicObj = ManagerPic.Engine.GetObject<InvPic>(sS_MaskedTextBox_ItemID.Text);
                                //InvPicHomeObj.InvPicObj.Picture = Function_GetPhoto(sS_MaskedTextBox_PicturePath.Text);
                                //InvPicHomeObj.InvPicObj.Path = sS_MaskedTextBox_PicturePath.Text;

                                //if (InvPicHomeObj.Edit())
                                //{
                                //    SS_MyMessageBox.ShowBox("Edit Data Complete", "Information", DialogMode.OkOnly);
                                //    Global.Bool_CheckError = false;
                                //}

                                //AssetPicHomeObj.AssetPicobj.AssetID = sS_MaskedTextBox_AssetNo.Text;
                                //AssetPicHomeObj.AssetPicobj.ModelID = sS_MaskedTextBox_ModelNo.Text;
                                //AssetPicHomeObj.AssetPicobj.PathPicture = sS_MaskedTextBox_Picture.Text;
                                //AssetPicHomeObj.AssetPicobj.Picture = GetPhoto(sS_MaskedTextBox_Picture.Text);

                                string StrSQL = "AssetID = '" + sS_MaskedTextBox_AssetNo.Text + "'AND ModelID = '" + Str_OldModelID + "'";
                                Wilson.ORMapper.OPathQuery<AssetPic> OPathAssetPic2 = new Wilson.ORMapper.OPathQuery<AssetPic>(StrSQL);
                                AssetPic TempAssetPic2 = ManagerPic.Engine.GetObject<AssetPic>(OPathAssetPic2);

                                TempAssetPic2.PathPicture = sS_MaskedTextBox_Picture.Text;
                                TempAssetPic2.Picture = GetPhoto(sS_MaskedTextBox_Picture.Text);

                                AssetPicHomeObj.AssetPicobj.AssetID = sS_MaskedTextBox_AssetNo.Text;
                                AssetPicHomeObj.AssetPicobj.ModelID = sS_MaskedTextBox_ModelNo.Text;
                                AssetPicHomeObj.AssetPicobj.PathPicture = TempAssetPic2.PathPicture;
                                AssetPicHomeObj.AssetPicobj.Picture = TempAssetPic2.Picture;


                                if (AssetPicHomeObj.Edit())
                                {
                                    SS_MyMessageBox.ShowBox("Edit data : " + sS_MaskedTextBox_AssetNo.Text + " Complete", "Edit Data Information", DialogMode.OkOnly, this.Name, "000003", Obj_AssetNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = true;
                                }
                                else
                                {
                                    SS_MyMessageBox.ShowBox("Can not edit data : " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000004", Obj_AssetNo, Global.Lang.Str_Language);
                                    Global.Bool_CheckComplete = false;
                                }

                                goto DEFAULT;
                            }
                            else
                                Global.Bool_CheckComplete = false;
                                break;
                        }
                    case Enum_Mode.Delete:
                        if (sS_DataGridView_Picture.SelectedRows.Count > 0)
                        {
                            List<AssetPic> AssetPicCollection = new List<AssetPic>();
                            AssetPic TempAssetPic = new AssetPic();

                            foreach(DataGridViewRow TempDataGridRow in sS_DataGridView_Picture.SelectedRows)
                            {
                                string SQL = "AssetID = '" + TempDataGridRow.Cells[0].Value.ToString() + "'AND ModelID = '" + TempDataGridRow.Cells[1].Value.ToString() + "'";
                                Wilson.ORMapper.OPathQuery<AssetPic>  OPathAssetPic= new Wilson.ORMapper.OPathQuery<AssetPic>(SQL);
                                TempAssetPic = ManagerPic.Engine.GetObject<AssetPic>(OPathAssetPic);
                                AssetPicCollection.Add(TempAssetPic);
                            }
                            if (SS_MyMessageBox.ShowBox("Do you want to delete data" + sS_DataGridView_Picture.SelectedRows.Count + "record ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000014", Obj_AssetPicRow, Global.Lang.Str_Language) == DialogResult.OK)
                            {

                                Wilson.ORMapper.Transaction ORTransaction = ManagerPic.Engine.BeginTransaction();
                                if (AssetPicHomeObj.Delete(ORTransaction, AssetPicCollection))
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
                        //else
                        //{
                        //    if (sS_MaskedTextBox_AssetNo.Text != "")
                        //    {
                        //        if (SS_MyMessageBox.ShowBox("Do you want to delete : " + sS_MaskedTextBox_AssetNo.Text + " ?", "Delete Data Information", DialogMode.OkCancel, this.Name, "000005", Obj_AssetNo, Global.Lang.Str_Language) == DialogResult.OK)
                        //        {
                        //            Global.Bool_CheckComplete = true;
                        //            AssetPicHomeObj.AssetPicobj.AssetID = sS_MaskedTextBox_AssetNo.Text;
                        //            if (AssetPicHomeObj.Delete())
                        //            {
                        //                SS_MyMessageBox.ShowBox("Delete dat: " + sS_MaskedTextBox_AssetNo.Text + "complete", "Delete Data Information", DialogMode.OkOnly, this.Name, "000006", Obj_AssetNo, Global.Lang.Str_Language);
                        //                Global.Bool_CheckComplete = true;

                        //                Enm_StateForm = Enum_Mode.PreAdd;
                        //                Function_ShowDataInDatagridView();
                        //            }
                        //            else
                        //            {
                        //                SS_MyMessageBox.ShowBox("Can not delete data : " + sS_MaskedTextBox_AssetNo.Text + " !", "Warning", DialogMode.OkOnly, this.Name, "000007", Obj_AssetNo, Global.Lang.Str_Language);
                        //                Global.Bool_CheckComplete = false;

                        //                Enm_StateForm = Enum_Mode.PreEdit;
                        //            }

                        //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                        //        }
                        //        else
                        //        {
                        //            Global.Bool_CheckComplete = false;
                        //            Enm_StateForm = Enum_Mode.PreEdit;
                        //            Function_ExecuteTransaction(Enum_Mode.Cancel);
                        //        }
                        //        //goto DEFAULT;
                        //    }
                        //    else
                        //        Global.Bool_CheckComplete = false;
                        //}
                                break;
                    case Enum_Mode.ShowData://
                        
                        if (sS_DataGridView_Picture.Rows.Count > 0)
                        {
                            sS_MaskedTextBox_AssetNo.ReadOnly = true;
                            sS_MaskedTextBox_AssetNo.Text = sS_DataGridView_Picture[0, sS_DataGridView_Picture.CurrentRow.Index].Value.ToString();
                            AssetPic AssetPicObj = new AssetPic();
                            AssetPicObj = ManagerPic.Engine.GetObject<AssetPic>(sS_MaskedTextBox_AssetNo.Text);
                            if(AssetPicObj!=null)
                            {
                                sS_MaskedTextBox_AssetName.Text = Global.FormOrder.Function_GetAssetName(AssetPicObj.AssetID);
                                sS_MaskedTextBox_ModelNo.Text =AssetPicObj.ModelID;
                                sS_MaskedTextBox_ModelName.Text = Global.FormOrder.Function_GetModelName(AssetPicObj.ModelID);
                                sS_MaskedTextBox_Picture.Text =Convert.ToString( AssetPicObj.PathPicture);
                                
                                 byte[] myByteArray = (byte[])AssetPicObj.Picture;
                                if (myByteArray.Length > 0)
                                {
                                    // Create a new MemoryStream and write all the information from
                                    // the byte array into the stream
                                    MemoryStream myStream = new MemoryStream(myByteArray, true);
                                    myStream.Write(myByteArray, 0, myByteArray.Length);
                                    // Use the MemoryStream to create the new BitMap object
                                    Bitmap FinalImage = new Bitmap(myStream);
                                    // See if the image stored will fit in the picture box. If it's too big, 
                                    // resize and create a new BitMap object and assign to the PictureBox control
                                    if (FinalImage.Width > 217 && FinalImage.Height > 151)
                                    {
                                        Bitmap AlteredImage = new Bitmap(FinalImage, new Size(217, 151));
                                        pictureBox_Picture.Image = AlteredImage;
                                    }
                                    else
                                        pictureBox_Picture.Image = FinalImage;

                                    // Close the stream
                                    //myStream.Close();
                                }
                            }
                            sS_MaskedTextBox_AssetNo.Focus();
                         }
                        break;

                    case Enum_Mode.Cancel:
                        if (Enm_StateForm == Enum_Mode.PreEdit)
                        {
                            Function_ExecuteTransaction(Enum_Mode.ShowData);
                            sS_MaskedTextBox_AssetNo.Focus();
                        }
                        if (Enm_StateForm == Enum_Mode.PreAdd)
                        {
                            Function_ClearData();
                            sS_MaskedTextBox_AssetNo.Focus();
                            Function_ShowDataInDatagridView();
                        }
                        Function_SetReadOnlyControl(true);
                        Function_SetReadOnlyControlSearch(true);
                        Enm_StateForm = Enum_Mode.Search;
                        break;
                    DEFAULT:
                        Function_ClearData();
                        sS_MaskedTextBox_AssetNo.ReadOnly = false;
                        sS_MaskedTextBox_AssetNo.Focus();
                        Function_ShowDataInDatagridView();
                        break;
                  }
                  Obj_AssetNo = null;
                  Obj_AssetPicRow = null;
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
                sS_MaskedTextBox_AssetNo.Text = "";
                sS_MaskedTextBox_AssetName.Text = "";
                sS_MaskedTextBox_ModelNo.Text = "";
                sS_MaskedTextBox_ModelName.Text = "";
                sS_MaskedTextBox_Picture.Text = "";

                pictureBox_Picture.Image = null;
            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
  

        private void Form_002003_Pictures_FormClosed(object sender, FormClosedEventArgs e)
        {
            Global.Function_RemoveTabStripButton(this.Tag);
        }

        public void Function_SetReadOnlyControl(bool Bool_StateControl)
        {
            sS_MaskedTextBox_Picture.ReadOnly = Bool_StateControl;
        }

        public void Function_SetReadOnlyControlSearch(bool Bool_StateControl)
        {
            sS_MaskedTextBox_AssetNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_AssetName.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ModelNo.ReadOnly = Bool_StateControl;
            sS_MaskedTextBox_ModelName.ReadOnly = Bool_StateControl;
        }

        private void sS_MaskedTextBox_AssetNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1)&&((Enm_StateForm ==Enum_Mode.PreAdd)))
            {
                Asset AssetObj = new Asset();
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_AssetNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_AssetName;

                Frm_Present.Show_Data("Screen", "002001");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
                AssetObj = Manager.Engine.GetObject<Asset>(sS_MaskedTextBox_AssetNo.Text);
                if (AssetObj != null)
                {
                    sS_MaskedTextBox_AssetName.Text = Global.FormOrder.Function_GetAssetName(AssetObj.ID);
                    sS_MaskedTextBox_ModelNo.Text = AssetObj.ModelID;
                    sS_MaskedTextBox_ModelName.Text = Global.FormOrder.Function_GetModelName(AssetObj.ModelID);
                }
            }
        }

        private void sS_MaskedTextBox_ModelNo_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F1) && ((Enm_StateForm == Enum_Mode.PreAdd) ))
            {
                Str_OldModelID = sS_MaskedTextBox_ModelNo.Text;
                SimatSoft.QueryManager.Form_Present Frm_Present = new SimatSoft.QueryManager.Form_Present();
                Frm_Present.Controlreturnvalue = sS_MaskedTextBox_ModelNo;
                Frm_Present.Controlreturnvalue2 = sS_MaskedTextBox_ModelName;

                Frm_Present.Show_Data("Screen", "002002");

                Frm_Present.ShowDialog();
                Frm_Present.Dispose();
            }
        }
        private void Form_002003_Pictures_Activated(object sender, EventArgs e)
        {
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void sS_DataGridView_Picture_Click(object sender, EventArgs e)
        {
            Function_ExecuteTransaction(Enum_Mode.ShowData);
            Enm_StateForm = Enum_Mode.CellClick;
            //Global.Function_ToolStripSetUP(Enum_Mode.CellClick);
            AuthorizeState.Funtion_SetButtonAuthorize(Enm_StateForm);
        }

        private void Form_002003_Pictures_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Global.Location.Int_CountForm > 0)
            {
                Global.Location.Int_CountForm = Global.Location.Int_CountForm - 1;
            }
            AuthorizeState.Funtion_SetButtonAuthorize(Enum_Mode.SetDefault);
        }
    }
}