using System;
using Wilson.ORMapper;
using System.Xml;
using SimatSoft.CustomControl;


namespace SimatSoft.DB.ORM
{
	sealed public class Manager
	{
		private static ObjectSpace engine;
        public static string Str_servername;
        public static string Str_databasename;
        public static string Str_username;
        public static string Str_password;
        public static string Str_DB_Type;
        public static string Str_language;
        public static string Str_configfilename = AppDomain.CurrentDomain.BaseDirectory + "Data\\Server\\DB-Server.Xml";
        //private static string Str_plainText = "";    // original plaintext
        private static string Str_passPhrase = "SIMAT";        // can be any string
        private static string Str_saltValue = "SOFT";        // can be any string
        private static string Str_hashAlgorithm = "MD5";             // can be "MD5"
        private static int Int_passwordIterations = 2;                  // can be any number
        private static string Str_initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private static int Int_keySize = 128;                // can be 192 or 128

		public static ObjectSpace Engine {
			get { return Manager.engine; }
		}
        static  Manager()
        {
            try
            {
                string mappingFile = AppDomain.CurrentDomain.BaseDirectory
                    + "ORM\\Config\\Mappings.config";
                //string connectString = "Server=Ngohjung;DataBase=simatDB;UID=sa;PWD=;";
                string connectString = Function_getConfig();
                string providerType = "MsSql";

                Provider provider;
                try { provider = (Provider)System.Enum.Parse(typeof(Provider), providerType, true); }
                catch { provider = Provider.MsSql; }
                
                // Note: Non-Zero Session may be desirable for Server Applications
                engine = new ObjectSpace(mappingFile, connectString, Provider.MsSql);
                
            }

            catch (ORMapperException Ex)
            {
                throw Ex;
            }
            catch (Exception e)
            {
                throw e;
            }
           
        }

        public static void Function_TestConnect()
        {
            try
            {
                string mappingFile = AppDomain.CurrentDomain.BaseDirectory
                    + "ORM\\Config\\Mappings.config";
                //string connectString = "Server=Ngohjung;DataBase=simatDB;UID=sa;PWD=;";
                string connectString = Function_getConfig();
                string providerType = "MsSql";

                Provider provider;
                try { provider = (Provider)System.Enum.Parse(typeof(Provider), providerType, true); }
                catch { provider = Provider.MsSql; }

                // Note: Non-Zero Session may be desirable for Server Applications
                engine = new ObjectSpace(mappingFile, connectString, Provider.MsSql);

            }

            catch (ORMapperException Ex)
            {
                throw Ex;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public static void Function_SaveConfig()
        {
            XmlTextWriter tw;
            //int i = ;

            try
            {
               SimatSoft.DB.Encrypt.ClassEncrypt SimatE = new SimatSoft.DB.Encrypt.ClassEncrypt();
                Str_username = SimatE.Encrypt(Str_username,
                                          Str_passPhrase,
                                          Str_saltValue,
                                          Str_hashAlgorithm,
                                          Int_passwordIterations,
                                          Str_initVector,
                                          Int_keySize);
                Str_password = SimatE.Encrypt(Str_password,
                                      Str_passPhrase,
                                      Str_saltValue,
                                      Str_hashAlgorithm,
                                      Int_passwordIterations,
                                      Str_initVector,
                                      Int_keySize);
                tw = new XmlTextWriter(Str_configfilename, new System.Text.UTF8Encoding());
                tw.Formatting = Formatting.Indented;
                tw.Indentation = 4;
                tw.WriteStartDocument();
                tw.WriteStartElement("Server", "Controls", "http://www.simat.co.th");
                tw.WriteStartElement("Server");
                tw.WriteStartElement("Name");
                tw.WriteString(Str_servername);
                tw.WriteEndElement();
                tw.WriteStartElement("Databasename");
                tw.WriteString(Str_databasename);
                tw.WriteEndElement();

                tw.WriteStartElement("USER");
                tw.WriteString(Str_username);
                tw.WriteEndElement();

                tw.WriteStartElement("PASSWORD");
                tw.WriteString(Str_password);
                tw.WriteEndElement();

                tw.WriteStartElement("Type");
                tw.WriteString(Str_DB_Type);
                tw.WriteEndElement();

                tw.WriteStartElement("Language");
                tw.WriteString(Str_language);
                tw.WriteEndElement();

                tw.WriteEndElement();
                tw.WriteEndDocument();
                tw.Flush();
                tw.Close();
                tw = null;

            }
            catch (Exception Err)
            {
                SS_MyMessageBox.ShowBox(Err.Message, "Error", DialogMode.Error_Cancel, Err);
            }
        }
        public static string  Function_getConfig() 
        {
            System.Data.DataSet ds;  
            PresentData present = new PresentData();
            ds= present.loaddata(Str_configfilename);
            if (ds.Tables.Count > 0) 
            {
                    
                Str_servername = ds.Tables[0].Rows[0]["Name"].ToString() ;
                Str_databasename = ds.Tables[0].Rows[0]["Databasename"].ToString();
                SimatSoft.DB.Encrypt.ClassEncrypt SimatE = new SimatSoft.DB.Encrypt.ClassEncrypt();

            
                Str_username = ds.Tables[0].Rows[0]["USER"].ToString();
                Str_username = SimatE.Decrypt(Str_username,
                                            Str_passPhrase,
                                            Str_saltValue,
                                            Str_hashAlgorithm,
                                            Int_passwordIterations,
                                            Str_initVector,
                                            Int_keySize);
                Str_password = ds.Tables[0].Rows[0]["PASSWORD"].ToString();
                Str_password = SimatE.Decrypt(Str_password,
                                           Str_passPhrase,
                                           Str_saltValue,
                                           Str_hashAlgorithm,
                                           Int_passwordIterations,
                                           Str_initVector,
                                           Int_keySize);
                Str_DB_Type = ds.Tables[0].Rows[0]["Type"].ToString();
                Str_language = ds.Tables[0].Rows[0]["Language"].ToString();
                //menuconfigfilename = ds.Tables[0].Rows[0]["File-Config-Menu"].ToString(); 
                return "Server=" + Str_servername + ";DataBase=" + Str_databasename + ";UID=" + Str_username + ";PWD=" + Str_password + ";";
            }
            return "";
        }
		private Manager() {
			// Note: Static Class -- All Members are Static
		}

    }
}