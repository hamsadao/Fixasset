using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.DB.ORM;
using Wilson.ORMapper;

namespace SimatSoft.FixAsset
{
    /// <summary>
    /// check Data In MasterData(String Str_Master(TableName),ObjectHome of Class that)
    /// 07/06/07
    /// </summary>
    class Class_CheckMaster
    {
        public static string Str_TempFacCode = "";
        public static string STR_ValueDefault = "NEW";
        public class Function_CheckData
       {
            /// <summary>
            /// Function_TB_AssetImportFile เมื่อทำการ importfile แล้วต้องเช็คข้อมูลในฟิวด์ Type,Status ซึ่งไฟล์ที่ทำการ import ไม่มีข้อมูลของฟิวด์นี้ 
            /// กำหนดค่า เพื่อที่จะทำการ import
            /// </summary>
            /// <param name="STR_Master"></param>
            /// <param name="AssetHomeObj"></param>
            public static void TB_AssetImportFile(string STR_Master, AssetHome AssetHomeObj)
            {
                string Str_TempType = "TMP";
                switch (STR_Master)
                {
                    case "Type":
                        {
                            ObjectSet ObjSet_Type = Manager.Engine.GetObjectSet(typeof(SimatSoft.DB.ORM.Type), String.Empty);
                            SimatSoft.DB.ORM.Type TypeObj = (SimatSoft.DB.ORM.Type)ObjSet_Type.GetObject(Str_TempType);
                            if (TypeObj != null)
                            {
                                AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                            }
                            else
                            {
                                TypeObj = new SimatSoft.DB.ORM.Type();
                                TypeObj.ID = Str_TempType;
                                TypeObj.Name = "IMPORT";
                                TypeHome TypeHomeObj = new TypeHome();
                                TypeHomeObj.Typeobj = TypeObj;
                                TypeHomeObj.Add();
                                AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                            }

                            break;
                        }
                    case "Status":
                        {
                            ObjectSet ObjSet_Status = Manager.Engine.GetObjectSet(typeof(Status), String.Empty);
                            Status StatusObj = (Status)ObjSet_Status.GetObject(STR_ValueDefault);
                            if (StatusObj != null)
                            {
                                AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                            }
                            else
                            {
                                StatusObj = new Status();
                                StatusObj.ID = STR_ValueDefault;
                                StatusObj.Name = StatusObj.ID;
                                StatusHome StatusHomeObj = new StatusHome();
                                StatusHomeObj.Statusobj = StatusObj;
                                StatusHomeObj.Add();
                                AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                            }
                            break;
                        }
                }

            }
            public static void TB_Building(string STR_Master, BuildingHome BuildHomeObj)
            {
                switch (STR_Master)
                {
                    case "Facility":
                        {
                            ObjectSet ObjSet_Facility = Manager.Engine.GetObjectSet(typeof(Facility), String.Empty);
                            Facility FacilityObj = (Facility)ObjSet_Facility.GetObject(BuildHomeObj.BuildingObj.FacCode);
                            if (FacilityObj != null)
                            {
                                BuildHomeObj.BuildingObj.FacCode = FacilityObj.FacCode;
                            }
                            else
                            {
                                Facility Temp_Facility = Manager.Engine.GetObject<Facility>(BuildHomeObj.BuildingObj.FacCode);
                                if (Temp_Facility == null)
                                {
                                    FacilityObj = new Facility();
                                    FacilityObj.FacCode = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityObj.FacName = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityObj.Address1 = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityObj.Address2 = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityObj.FacCity = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityObj.Phone = BuildHomeObj.BuildingObj.FacCode;
                                    FacilityHome FacilityHomeObj = new FacilityHome();
                                    FacilityHomeObj.Facilityobj = FacilityObj;
                                    FacilityHomeObj.Add();
                                }
                                else
                                    break;
                            }
                        }
                        break;
                }
            }

            public static void TB_Area(string STR_Master, AreaHome AreaHomeObj)
            {
                switch (STR_Master)
                {
                    case "Facility":
                        {
                            if (AreaHomeObj.Areaobj.FacCode != "-")
                            {
                                ObjectSet ObjSet_Facility = Manager.Engine.GetObjectSet(typeof(Facility), String.Empty);
                                Facility FacilityObj = (Facility)ObjSet_Facility.GetObject(AreaHomeObj.Areaobj.FacCode);
                                if (FacilityObj != null)
                                {
                                    AreaHomeObj.Areaobj.FacCode = FacilityObj.FacCode;
                                }
                                else
                                {
                                    Facility Temp_Facility = Manager.Engine.GetObject<Facility>(AreaHomeObj.Areaobj.FacCode);
                                    if (Temp_Facility == null)
                                    {
                                        FacilityObj = new Facility();
                                        FacilityObj.FacCode = AreaHomeObj.Areaobj.FacCode;
                                        FacilityObj.FacName = AreaHomeObj.Areaobj.FacCode;
                                        FacilityObj.Address1 = AreaHomeObj.Areaobj.FacCode;
                                        FacilityObj.Address2 = AreaHomeObj.Areaobj.FacCode;
                                        FacilityObj.FacCity = AreaHomeObj.Areaobj.FacCode;
                                        FacilityObj.Phone = AreaHomeObj.Areaobj.FacCode;
                                        FacilityHome FacilityHomeObj = new FacilityHome();
                                        FacilityHomeObj.Facilityobj = FacilityObj;
                                        FacilityHomeObj.Add();
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                        break;
                }
            }
            public static void TB_Floor(string STR_Master, FloorHome FloorHomeObj)
            {
                switch (STR_Master)
                {
                    case "Facility":
                        {
                            if (FloorHomeObj.Floorobj.FacCode != "-")
                            {
                                ObjectSet ObjSet_Facility = Manager.Engine.GetObjectSet(typeof(Facility), String.Empty);
                                Facility FacilityObj = (Facility)ObjSet_Facility.GetObject(FloorHomeObj.Floorobj.FacCode);
                                if (FacilityObj != null)
                                {
                                    FloorHomeObj.Floorobj.FacCode = FacilityObj.FacCode;
                                }
                                else
                                {
                                    Facility Temp_Facility = Manager.Engine.GetObject<Facility>(FloorHomeObj.Floorobj.FacCode);
                                    if (Temp_Facility == null)
                                    {
                                        FacilityObj = new Facility();
                                        FacilityObj.FacCode = FloorHomeObj.Floorobj.FacCode;
                                        FacilityObj.FacName = FloorHomeObj.Floorobj.FacCode;
                                        FacilityObj.Address1 = FloorHomeObj.Floorobj.FacCode;
                                        FacilityObj.Address2 = FloorHomeObj.Floorobj.FacCode;
                                        FacilityObj.FacCity = FloorHomeObj.Floorobj.FacCode;
                                        FacilityObj.Phone = FloorHomeObj.Floorobj.FacCode;
                                        FacilityHome FacilityHomeObj = new FacilityHome();
                                        FacilityHomeObj.Facilityobj = FacilityObj;
                                        FacilityHomeObj.Add();
                                    }
                                    else
                                        break;
                                }
                            }
                        }
                        break;
                }
            }

           public static void TB_Asset(string STR_Master, AssetHome AssetHomeObj)
           {
               
               switch (STR_Master)
               {

                   case "Facility":
                       {
                           ObjectSet ObjSet_Facility = Manager.Engine.GetObjectSet(typeof(Facility), String.Empty);
                           Facility FacilityObj = (Facility)ObjSet_Facility.GetObject(AssetHomeObj.Assetobj.FacCode);
                           if (FacilityObj != null)
                           {
                               AssetHomeObj.Assetobj.FacCode = FacilityObj.FacCode;
                           }
                           else
                           {
                               FacilityObj = new Facility();
                               FacilityObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                               FacilityObj.FacName = AssetHomeObj.Assetobj.FacCode;
                               FacilityObj.Address1 = AssetHomeObj.Assetobj.FacCode;
                               FacilityObj.Address2 = AssetHomeObj.Assetobj.FacCode;
                               FacilityObj.FacCity = AssetHomeObj.Assetobj.FacCode;
                               FacilityObj.Phone = AssetHomeObj.Assetobj.FacCode;
                               FacilityHome FacilityHomeObj = new FacilityHome();
                               FacilityHomeObj.Facilityobj = FacilityObj;
                               FacilityHomeObj.Add();
                           }
                       }
                       break;
                   case "Building":
                       {
                           ObjectSet ObjSet_Building = Manager.Engine.GetObjectSet(typeof(Building), String.Empty);
                           Building BuildingObj = (Building)ObjSet_Building.GetObject(AssetHomeObj.Assetobj.BuildID);
                           if (BuildingObj == null)
                           {
                               BuildingObj = new Building();
                               BuildingObj.BuildID = AssetHomeObj.Assetobj.BuildID;
                               BuildingObj.BuildName = BuildingObj.BuildID;
                               BuildingObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                               BuildingHome BuildingHomeObj = new BuildingHome();
                               BuildingHomeObj.BuildingObj = BuildingObj;
                               BuildingHomeObj.Add();
                           }
                           break;
                       }
                   case "Area":
                       ObjectSet ObjSet_area = Manager.Engine.GetObjectSet(typeof(Area), String.Empty);
                       Area AreaObj = (Area)ObjSet_area.GetObject(AssetHomeObj.Assetobj.AreaID);
                       if (AreaObj == null)
                       {
                           AreaObj = new Area();
                           AreaObj.ID = AssetHomeObj.Assetobj.AreaID;
                           AreaObj.Name = AssetHomeObj.Assetobj.AreaID;
                           AreaObj.BuildID = AssetHomeObj.Assetobj.BuildID;
                           AreaObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                           AreaObj.FloorID = AssetHomeObj.Assetobj.FloorID;
                           AreaHome areahomeobj = new AreaHome();
                           areahomeobj.Areaobj = AreaObj;
                           areahomeobj.Add();
                       }
                       break;

                   case "Floor":
                       {
                           ObjectSet ObjSet_Floor = Manager.Engine.GetObjectSet(typeof(Floor), String.Empty);
                           Floor FloorObj = (Floor)ObjSet_Floor.GetObject(AssetHomeObj.Assetobj.FloorID);
                           if (FloorObj == null)
                           {
                               FloorObj = new Floor();
                               FloorObj.ID = AssetHomeObj.Assetobj.FloorID;
                               FloorObj.Name = FloorObj.ID;
                               FloorObj.BuildID = AssetHomeObj.Assetobj.BuildID;
                               FloorObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                               FloorHome FloorHomeObj = new FloorHome();
                               FloorHomeObj.Floorobj = FloorObj;
                               FloorHomeObj.Add();
                           }
                           break;
                       }
                   case "Reason":
                       {
                           ObjectSet ObjSet_Reason = Manager.Engine.GetObjectSet(typeof(Reason), String.Empty);
                           Reason ReasonObj = (Reason)ObjSet_Reason.GetObject(STR_ValueDefault);
                           if (ReasonObj != null)
                           {
                               AssetHomeObj.Assetobj.ReasonCode = ReasonObj.Code;
                           }
                           else
                           {
                               ReasonObj = new Reason();
                               ReasonObj.Code = STR_ValueDefault;
                               ReasonObj.Name = ReasonObj.Code;
                               ReasonHome ReasonHomeObj = new ReasonHome();
                               ReasonHomeObj.Reasonobj = ReasonObj;
                               ReasonHomeObj.Add();
                               AssetHomeObj.Assetobj.ReasonCode = ReasonObj.Code;
                           }
                           break;
                       }
                   case "Type":
                       {
                           ObjectSet ObjSet_Type = Manager.Engine.GetObjectSet(typeof(SimatSoft.DB.ORM.Type), String.Empty);
                           SimatSoft.DB.ORM.Type TypeObj = (SimatSoft.DB.ORM.Type)ObjSet_Type.GetObject(AssetHomeObj.Assetobj.TypeID);
                           if (TypeObj != null)
                           {
                               AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                           }
                           else
                           {
                               TypeObj = new SimatSoft.DB.ORM.Type();
                               TypeObj.ID = AssetHomeObj.Assetobj.TypeID;
                               TypeObj.Name = TypeObj.ID;
                               TypeHome TypeHomeObj = new TypeHome();
                               TypeHomeObj.Typeobj = TypeObj;
                               TypeHomeObj.Add();
                               AssetHomeObj.Assetobj.TypeID = TypeObj.ID;
                           }

                           break;
                       }
                   case "Status":
                       {
                           ObjectSet ObjSet_Status = Manager.Engine.GetObjectSet(typeof(Status), String.Empty);
                           Status StatusObj = (Status)ObjSet_Status.GetObject(AssetHomeObj.Assetobj.StatusID);
                           if (StatusObj != null)
                           {
                               AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                           }
                           else
                           {
                               StatusObj = new Status();
                               StatusObj.ID = STR_ValueDefault;
                               StatusObj.Name = StatusObj.ID;
                               StatusHome StatusHomeObj = new StatusHome();
                               StatusHomeObj.Statusobj = StatusObj;
                               StatusHomeObj.Add();
                               AssetHomeObj.Assetobj.StatusID = StatusObj.ID;
                           }
                           break;
                       }
                   case "Vendor":
                       {
                           ObjectSet ObjSet_Vendor = Manager.Engine.GetObjectSet(typeof(Vendor), String.Empty);
                           Vendor VendorObj = (Vendor)ObjSet_Vendor.GetObject(STR_ValueDefault);
                           if (VendorObj != null)
                           {
                               AssetHomeObj.Assetobj.VendorID = VendorObj.ID;
                           }
                           else
                           {
                               VendorObj = new Vendor();
                               VendorObj.ID = STR_ValueDefault;
                               VendorObj.FirstName = VendorObj.ID;
                               VendorObj.LastName = VendorObj.ID;
                               VendorObj.Address1 = VendorObj.ID;
                               VendorObj.Address2 = VendorObj.ID;
                               VendorObj.City = VendorObj.ID;
                               VendorObj.Contact = VendorObj.ID;
                               VendorObj.Email = VendorObj.ID;
                               VendorObj.Fax = VendorObj.ID;
                               VendorObj.Flag = "I";
                               VendorHome VendorHomeObj = new VendorHome();
                               VendorHomeObj.Vendorobj = VendorObj;
                               VendorHomeObj.Add();
                               AssetHomeObj.Assetobj.VendorID = VendorObj.ID;
                           }
                           break;
                       }
                   case "Department":
                       {
                           ObjectSet ObjSet_Department = Manager.Engine.GetObjectSet(typeof(Department), String.Empty);
                           Department DepartmentObj = (Department)ObjSet_Department.GetObject(STR_ValueDefault);
                           if (DepartmentObj != null)
                           {
                               AssetHomeObj.Assetobj.DeptID = DepartmentObj.DeptID;
                           }
                           else
                           {
                               DepartmentObj = new Department();
                               DepartmentObj.DeptID = STR_ValueDefault;
                               DepartmentObj.DeptName = DepartmentObj.DeptID;
                               DepartmentObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                               DepartmentHome DeptHomeObj = new DepartmentHome();
                               DeptHomeObj.Departmentobj = DepartmentObj;
                               DeptHomeObj.Add();
                               AssetHomeObj.Assetobj.DeptID = DepartmentObj.DeptID;
                           }
                           break;
                       }
                   case "Custodian":
                       {
                           ObjectSet ObjSet_Custodian = Manager.Engine.GetObjectSet(typeof(Custodian), String.Empty);
                           Custodian CustodianObj = (Custodian)ObjSet_Custodian.GetObject(STR_ValueDefault);
                           if (CustodianObj != null)
                           {
                               AssetHomeObj.Assetobj.CustodianID = CustodianObj.ID;

                           }
                           else
                           {
                               CustodianObj = new Custodian();
                               CustodianObj.ID = STR_ValueDefault;
                               CustodianObj.DeptID = AssetHomeObj.Assetobj.DeptID;
                               CustodianObj.FirstName = CustodianObj.ID;
                               CustodianObj.LastName = CustodianObj.ID;
                               CustodianObj.FacCode = AssetHomeObj.Assetobj.FacCode;
                               CustodianHome CustodainHomeObj = new CustodianHome();
                               CustodainHomeObj.Custodianobj = CustodianObj;
                               CustodainHomeObj.Add();
                               AssetHomeObj.Assetobj.CustodianID = CustodianObj.ID;

                           }
                           break;
                       }
                   case "Model":
                       {
                           ObjectSet ObjSet_Model = Manager.Engine.GetObjectSet(typeof(Model), String.Empty);
                           Model ModelObj = (Model)ObjSet_Model.GetObject(STR_ValueDefault);
                           if (ModelObj != null)
                           {
                               AssetHomeObj.Assetobj.ModelID = ModelObj.ID;
                           }
                           else
                           {
                               ModelObj = new Model();
                               ModelObj.ID = STR_ValueDefault;
                               ModelObj.Name = ModelObj.ID;
                               ModelObj.Value = decimal.Parse("0.00");

                               ModelHome ModelHomeObj = new ModelHome();
                               ModelHomeObj.Modelobj = ModelObj;
                               ModelHomeObj.Add();
                               AssetHomeObj.Assetobj.ModelID = ModelObj.ID;
                           }
                           break;
                       }
               }
           }
       }
    }
}
