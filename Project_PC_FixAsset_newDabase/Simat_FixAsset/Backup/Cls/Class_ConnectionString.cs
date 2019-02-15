using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.FixAsset
{
    public class Class_ConnectionString
    {
        private string Str_ServerConn;
        private String Str_DatabaseConn;
        private string Str_UserID;
        private string Str_Password;
        private string Str_ProviderType;
        private string Str_Language;

        public Class_ConnectionString()
        {
            Str_ServerConn = string.Empty;
            Str_DatabaseConn = string.Empty;
            Str_UserID = string.Empty;
            Str_Password = string.Empty;
            Str_ProviderType = string.Empty;
            Str_Language = string.Empty;
        }

        public string ServerConnectString
        {
            get { return Str_ServerConn; }
            set { Str_ServerConn = value; }
        }

        public String DatabaseConnectString
        {
            get { return Str_DatabaseConn; }
            set { Str_DatabaseConn = value; }
        }      

        public string UserIDConnectString
        {
            get { return Str_UserID; }
            set { Str_UserID = value; }
        }

        public string PasswordConnectString
        {
            get { return Str_Password; }
            set { Str_Password = value; }
        }

        public string ProviderTypeConnectString
        {
            get { return Str_ProviderType; }
            set { Str_ProviderType = value; }
        }

        public string LanguageConnectString
        {
            get { return Str_Language; }
            set { Str_Language = value; }
        }

        public Class_ConnectionString Function_SaveConnectString(string Str_Server, string Str_Database, string Str_UserID, string Str_Password, string Str_Language, string Str_Provider)
        {
            Class_ConnectionString TempConnectString = new Class_ConnectionString();
            TempConnectString.ServerConnectString = Str_Server;
            TempConnectString.DatabaseConnectString = Str_Database;
            TempConnectString.UserIDConnectString = Str_UserID;
            TempConnectString.PasswordConnectString = Str_Password;
            TempConnectString.ProviderTypeConnectString = Str_Provider;
            TempConnectString.LanguageConnectString = Str_Language;


            return TempConnectString;
        }
    }
}
