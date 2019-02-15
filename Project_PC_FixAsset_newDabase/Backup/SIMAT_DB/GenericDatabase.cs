using System;
using System.Data;
using System.Configuration;
using SimatSoft.CustomControl;

/// <summary>
/// Summary description for GenericDatabase
/// </summary>
public  class GenericDB
{
    private string F_Servername;
    private string F_Username;
    private string F_Password;
    private string F_NetworkType;
    private string F_DBname;
    private System.Exception F_ExGenericDB;
    private string F_DBFilename;

    public string Servername
    {
        get
        {
            return F_Servername;
        }
        set
        {
            F_Servername = value;
        }
    }

    public string Username
    {
        get
        {
            return F_Username;
        }
        set
        {
            F_Username = value;
        }
    }

    public string Password
    {
        get
        {
            return F_Password;
        }
        set
        {
            F_Password = value;
        }
    }

    public string NetworkType
    {
        get
        {
            return F_NetworkType;
        }
        set
        {
            F_NetworkType = value;
        }
    }

    public string DBname
    {
        get
        {
            return F_DBname;
        }
        set
        {
            F_DBname = value;
        }
    }

    public Exception ExGenericDB
    {
        get
        {
            return F_ExGenericDB;
        }
        set
        {
            F_ExGenericDB = value;
        }
    }

    public string DBFilename
    {
        get
        {
            return F_DBFilename;
        }
        set
        {
            F_DBFilename = value;
        }
    }

   
    public void Execute(string SqlCommand)
    {
    }

    public void SelectData()
    {
    }

    public void Insert()
    {
    }

    public void Update()
    {
    }

    public void Delete()
    {
    }
    public bool Createconnection()
    {
        string connectionstring;
        try
        {
        
            return true;
        }
        catch (Exception Err)
        {
            
            return false;
        }
        
    }
}
