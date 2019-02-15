using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("SimatSoft.FixAsset")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Simat Soft Company Limited")]
[assembly: AssemblyProduct("SimatSoft.FixAsset")]
[assembly: AssemblyCopyright("Copyright © Microsoft Corporation 2007")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("04bbce41-7a3a-48f1-a56b-8a470c8ac44e")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.3.4.*")]
[assembly: AssemblyFileVersion("1.3.4.1")]
public class AssemblyInfo
{
    // Used by Helper Functions to access information from Assembly Attributes

    private Type myType;

    public AssemblyInfo()
    {
        myType = typeof(SimatSoft.FixAsset.Form_000000_MDI);
    }

    public string AsmName
    {

        get
        {

            return myType.Assembly.GetName().Name.ToString();

        }

    }

    public string AsmFQName
    {

        get
        {

            return myType.Assembly.GetName().FullName.ToString();

        }

    }

    public string CodeBase
    {

        get
        {

            return myType.Assembly.CodeBase;

        }

    }

    public string Copyright
    {

        get
        {

            Type at = typeof(AssemblyCopyrightAttribute);

            object[] r = myType.Assembly.GetCustomAttributes(at, false);

            AssemblyCopyrightAttribute ct = (AssemblyCopyrightAttribute)r[0];

            return ct.Copyright;

        }

    }

    public string Company
    {

        get
        {

            Type at = typeof(AssemblyCompanyAttribute);

            object[] r = myType.Assembly.GetCustomAttributes(at, false);

            AssemblyCompanyAttribute ct = (AssemblyCompanyAttribute)r[0];

            return ct.Company;

        }

    }

    public string Description
    {

        get
        {

            Type at = typeof(AssemblyDescriptionAttribute);

            object[] r = myType.Assembly.GetCustomAttributes(at, false);

            AssemblyDescriptionAttribute da = (AssemblyDescriptionAttribute)r[0];

            return da.Description;

        }

    }

    public string Product
    {

        get
        {

            Type at = typeof(AssemblyProductAttribute);

            object[] r = myType.Assembly.GetCustomAttributes(at, false);

            AssemblyProductAttribute pt = (AssemblyProductAttribute)r[0];

            return pt.Product;

        }

    }

    public string Title
    {

        get
        {

            Type at = typeof(AssemblyTitleAttribute);

            object[] r = myType.Assembly.GetCustomAttributes(at, false);

            AssemblyTitleAttribute ta = (AssemblyTitleAttribute)r[0];

            return ta.Title;

        }

    }

    public string Version
    {

        get
        {

            return myType.Assembly.GetName().Version.ToString();

        }

    }

}