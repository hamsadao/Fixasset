using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimatSoft.ControlBasic;
using SimatSoft.CustomControl;

using SimatSoft.DB.ORM;

namespace SimatSoft.QueryManager
{
    public partial class Form_Present : Form
    {
        public string  returnvalue="" ;
        public Control Controlreturnvalue =null ;
        public Control Controlreturnvalue2 = null;
        public Control Controlreturnvalue3 = null;
        public Control Controlreturnvalue4 = null;
        public Control Controlreturnvalue5 = null;
        public Control Controlreturnvalue6 = null;
        public Control Controlreturnvalue7 = null;
        public DataGridViewCell CellValue = null;
        public Class_PresentData clsmain = new Class_PresentData(); 
        public Form_Present()
        {
            InitializeComponent();
        }
        public void Show_Data(string datatype ,string id)
        {
            System.Collections.ArrayList col = new System.Collections.ArrayList();
            clsmain.Present = new  PresentData();

            clsmain.profilename = "";
            clsmain.profilename = clsmain.menumapping.FindMenu(id );

            if (clsmain.profilename != "")
            {
                clsmain.Present.search(System.Windows.Forms.Application.StartupPath, clsmain.profilename);
                clsmain.cls_list.dataheader = clsmain.Present.dsheader;
                clsmain.cls_list.datasqlcommand = clsmain.Present.dsquery;
                clsmain.cls_list.datasearchmember = clsmain.Present.dssearchmember;
                clsmain.cls_list.set_header(dataGridView1);

                clsmain.cls_list.DataSet = clsmain.Present.dssource;
                clsmain.cls_list.showdata(dataGridView1);
              //  this.itemCountLabel.Text = dataGridView1.RowCount + "  Items";

                // Edit on 05-01-09 ไม่ทำการเรียก showsearchmember()
              //  clsmain.cls_list.showsearchmember(splitContainer4.Panel1, splitContainer4);
            }
        }
        public void Show_Data(string datatype, string id, string qry)
        {
            System.Collections.ArrayList col = new System.Collections.ArrayList();
            clsmain.Present = new PresentData();

            clsmain.profilename = "";
            clsmain.profilename = clsmain.menumapping.FindMenu(id);

            if (clsmain.profilename != "")
            {
                clsmain.Present.search(System.Windows.Forms.Application.StartupPath, clsmain.profilename, qry);
                clsmain.cls_list.dataheader = clsmain.Present.dsheader;
                clsmain.cls_list.datasqlcommand = clsmain.Present.dsquery;
                clsmain.cls_list.datasearchmember = clsmain.Present.dssearchmember;
                clsmain.cls_list.set_header(dataGridView1);

                clsmain.cls_list.DataSet = clsmain.Present.dssource;
                clsmain.cls_list.showdata(dataGridView1);
                //  this.itemCountLabel.Text = dataGridView1.RowCount + "  Items";

                // Edit on 05-01-09 ไม่ทำการเรียก showsearchmember()
              //  clsmain.cls_list.showsearchmember(splitContainer4.Panel1, splitContainer4);
            }
        }
        public void Searchdata()
        {
            try
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
                            sqlwhere = sqlwhere + " " + entity + " " + operation + " N'" + prefix + Controltemp.Text + "" + sufix + "'  ";
                            if (nextoperation != "")
                                sqlwhere = sqlwhere + nextoperation;
                            else
                                sqlwhere = sqlwhere + "   ";
                        }
                    }

                }

                if (sqlwhere != "")
                {

                    sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 3);
                    clsmain.cls_list.DataSet = clsmain.Present.selectdataforsearch(sqlwhere);
                   
                }
                else 
                clsmain.cls_list.DataSet = clsmain.Present.selectdata();
                clsmain.cls_list.showdata(dataGridView1);
                //this.itemCountLabel.Text = dataGridView1.RowCount + "  Items";
            }
            catch (Exception e)
            {
                SimatSoft.Log.Classlogfile.Writelogfile(e);
            }
        }
        private void splitContainer4_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            if (e.ColumnIndex < 0 && e.RowIndex >= 0 )
            {
                e.PaintBackground(e.ClipBounds, true);
                e.Graphics.DrawString(Convert.ToString((e.RowIndex + 1)), this.Font, Brushes.Black, e.CellBounds, sf);
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                    returnvalue = dataGridView1.SelectedRows[0].Cells[0].FormattedValue.ToString();
                    
                    if (Controlreturnvalue != null)
                        Controlreturnvalue.Text = dataGridView1.SelectedRows[0].Cells[0].FormattedValue.ToString();
                    if (Controlreturnvalue2 != null)
                        Controlreturnvalue2.Text = dataGridView1.SelectedRows[0].Cells[1].FormattedValue.ToString();                
                    if (Controlreturnvalue3 != null)
                        Controlreturnvalue3.Text = dataGridView1.SelectedRows[0].Cells[2].FormattedValue.ToString();
                    if (Controlreturnvalue4 != null)
                        Controlreturnvalue4.Text = dataGridView1.SelectedRows[0].Cells[3].FormattedValue.ToString();
                    if (Controlreturnvalue5 != null)
                        Controlreturnvalue5.Text = dataGridView1.SelectedRows[0].Cells[4].FormattedValue.ToString();
                    if (Controlreturnvalue6 != null)
                        Controlreturnvalue6.Text = dataGridView1.SelectedRows[0].Cells[5].FormattedValue.ToString();
                    if (Controlreturnvalue7 != null)
                        Controlreturnvalue7.Text = dataGridView1.SelectedRows[0].Cells[6].FormattedValue.ToString();
            }
            catch (Exception ex) 
            {
                
            } 
            
        }

        private void Form_Present_Load(object sender, EventArgs e)
        {
            Searchdata();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Function_SelectRows();
            this.Close();
        }
        private void Function_SelectRows()
        {
            try
            {
                returnvalue = dataGridView1.SelectedRows[0].Cells[0].FormattedValue.ToString();
                if (Controlreturnvalue != null)
                    Controlreturnvalue.Text = dataGridView1.SelectedRows[0].Cells[0].FormattedValue.ToString();
                if(Controlreturnvalue2 !=null)
                    Controlreturnvalue2.Text = dataGridView1.SelectedRows[0].Cells[1].FormattedValue.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void btt_search_Click(object sender, EventArgs e)
        {
            GetDataToDataGrid2();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            Function_SelectRows_dataGridView2();
            this.Close();
        }

        private void Function_SelectRows_dataGridView2()
        {
            try
            {      
                returnvalue = dataGridView2[0, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                
                if (Controlreturnvalue != null)
                    Controlreturnvalue.Text = dataGridView2[0, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue2 != null)
                    Controlreturnvalue2.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
            }
            catch (Exception ex)
            {
                SS_MyMessageBox.ShowBox("Error@ Function_SelectRows_dataGridView2()");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                returnvalue = dataGridView2[0, dataGridView2.CurrentRow.Index].FormattedValue.ToString();

                if (Controlreturnvalue != null)
                    Controlreturnvalue.Text = dataGridView2[0, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue2 != null)
                    Controlreturnvalue2.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue3 != null)
                    Controlreturnvalue3.Text = dataGridView2[2, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue4 != null)
                    Controlreturnvalue4.Text = dataGridView2[3, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue5 != null)
                    Controlreturnvalue5.Text = dataGridView2[4, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue6 != null)
                    Controlreturnvalue6.Text = dataGridView2[5, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
                if (Controlreturnvalue7 != null)
                    Controlreturnvalue7.Text = dataGridView2[6, dataGridView2.CurrentRow.Index].FormattedValue.ToString();
            }
            catch (Exception ex)
            {
                SS_MyMessageBox.ShowBox("Error@ dataGridView2_CellClick()");
            } 
            
        }

        private void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetDataToDataGrid2();
            }
        }

        private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                GetDataToDataGrid2();
            }

        }

        void GetDataToDataGrid2()
        { 
        
            string sql = "";
            DataSet Ds = new DataSet();
           
            switch(clsmain.profilename)
            {
                case "BarcodeDepartment":
                case "Department" : // Department
                    try
                    {
                        if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                        {
                            sql = "SELECT deptID AS DepartmentID,deptName AS DepartmentName FROM department WHERE deptID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by deptID ";
                        }
                        if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                        {
                            sql = "SELECT deptID AS DepartmentID,deptName AS DepartmentName FROM department WHERE deptName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by deptID ";
                        }
                        if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                        { 
                            sql = "SELECT deptID AS DepartmentID,deptName AS DepartmentName FROM department ";
                        
                        }
                            Ds = Manager.Engine.GetDataSet(sql);
                            if (Ds.Tables[0].Rows.Count > 0)
                            {

                                dataGridView2.Visible = true;

                                dataGridView2.DataSource = Ds;
                                dataGridView2.DataMember = "Table";
                            }
                            else
                            {
                                SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                            }

                        Ds.Dispose();
                        Ds = null;
                    }
                    catch 
                    {
                        SS_MyMessageBox.ShowBox("Error@ show Department Data");
                    }
                break;
            case "BarcodeAssetAdd":
            case "AssetHome":  // Asset

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT AssetID ,AssetName,modelID,SerialNo,areaID,AssetPrice,Remark FROM Asset WHERE AssetID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by AssetID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT AssetID ,AssetName,modelID,SerialNo,areaID,AssetPrice,Remark FROM Asset WHERE AssetName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by AssetID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT AssetID ,AssetName,modelID,SerialNo,areaID,AssetPrice,Remark FROM Asset ";

                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Asset Data");
                }
                break;
            case "BarcodeModel":
            case "Model":  // Model

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT modelID ,modelName,value FROM Model WHERE modelID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by modelID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT modelID ,modelName,value FROM Model WHERE modelName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by modelID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT modelID ,modelName,value FROM Model ";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Model Data");
                }
                break;
            case "BarcodeCustodian":
            case "Custodian":  //Custodian

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT CustodianID ,FirstName,LastName FROM Custodian WHERE CustodianID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by CustodianID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT CustodianID ,FirstName,LastName FROM Custodian WHERE FirstName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by CustodianID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT CustodianID ,FirstName,LastName FROM Custodian";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Custodian Data");
                }
                break;
            
            case "Supplier":  //Supplier

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT vendorID AS SupplierID ,vendorFirstName AS SupplierName,vendorLastName AS TaggedID FROM Vendor WHERE vendorLastName LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by vendorID ";  // Search from taggedID
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT vendorID AS SupplierID ,vendorFirstName AS SupplierName,vendorLastName AS TaggedID FROM Vendor WHERE vendorFirstName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by vendorID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT vendorID AS SupplierID ,vendorFirstName AS SupplierName,vendorLastName AS TaggedID FROM Vendor ";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Supplier Data");
                }
                break;
            case "BarcodeBuilding":
            case "Building":  // Building

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT buildID,buildName FROM Building WHERE buildID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by buildID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT buildID,buildName FROM Building WHERE buildName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by buildID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT buildID,buildName FROM Building";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Building Data");
                }
                break;

            case "BarcodeArea":
            case "Area":  // Area

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT areaID,areaName FROM Area WHERE areaID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by areaID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT areaID,areaName FROM Area WHERE areaName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by areaID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT areaID,areaName FROM Area";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Area Data");
                }
                break;

            case "BarcodeFloor":
            case "Floor":  // Floor

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT floorID,floorName FROM Floor WHERE floorID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' order by floorID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT floorID,floorName FROM Floor WHERE floorName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' order by floorID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT floorID,floorName FROM Floor";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Floor Data");
                }
                break;

            case "Type":  //Type

                try
                {
                    if (txt_ID.Text.ToString().Trim().Length != 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT typeID,typeName,Remark FROM Type WHERE typeID LIKE '%" + txt_ID.Text.ToString().Trim() + "%' and typeGroup = 'ASSET' order by typeID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length != 0)
                    {
                        sql = "SELECT typeID,typeName,Remark FROM Type WHERE typeName LIKE '%" + txt_Name.Text.ToString().Trim() + "%' and typeGroup = 'ASSET' order by typeID ";
                    }
                    if (txt_ID.Text.ToString().Trim().Length == 0 && txt_Name.Text.ToString().Trim().Length == 0)
                    {
                        sql = "SELECT typeID,typeName,Remark FROM Type WHERE typeGroup = 'ASSET' ";
                    }

                    Ds = Manager.Engine.GetDataSet(sql);
                    if (Ds.Tables[0].Rows.Count > 0)
                    {

                        dataGridView2.Visible = true;

                        dataGridView2.DataSource = Ds;
                        dataGridView2.DataMember = "Table";
                    }
                    else
                    {
                        SS_MyMessageBox.ShowBox("Your searching is not matched any data");
                    }

                    Ds.Dispose();
                    Ds = null;
                }
                catch
                {
                    SS_MyMessageBox.ShowBox("Error@ show Type Data");
                }
                break;
        }
        }
        
        }

       
    
}