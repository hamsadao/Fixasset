using System;
using Wilson.ORMapper;
using System.Xml;

namespace SimatSoft.DB.ORM
{
	sealed public class ManagerCantConnect
	{
		private static ObjectSpace engine;
        
        public static String Str_Server;
        public static String Str_Database;
        public static String Str_UserID;
        public static String Str_Password;
        public static String Str_DB_Type;
        public static String Str_Language;

        public static string Str_ConfigFileName = AppDomain.CurrentDomain.BaseDirectory + "Data\\Server\\DB-Server.Xml";
        private static string Str_PassPhrase = "SIMAT";        // can be any string
        private static string Str_SaltValue = "SOFT";        // can be any string
        private static string Str_HashAlgorithm = "MD5";             // can be "MD5"
        private static int Int_PasswordIterations = 2;                  // can be any number
        private static string Str_InitVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private static int Int_KeySize = 128;                // can be 192 or 128

        public static bool Bool_FlagPictureDB = false;
        public static ObjectSpace Engine
        {
            get { return ManagerCantConnect.engine; }
        }

        static ManagerCantConnect()
        {
            
            
		}

        public static void Function_StartManager()
        {
            try
            {
                string mappingFile = AppDomain.CurrentDomain.BaseDirectory + "ORM\\Config\\Mappings.config";
                string Str_ConnectString = "Server=" + Str_Server + ";DataBase=" + Str_Database + ";UID=" + Str_UserID + ";PWD=" + Str_Password + ";";

                Provider provider;
                try { provider = (Provider)System.Enum.Parse(typeof(Provider), Str_DB_Type, true); }
                catch { provider = Provider.MsSql; }

                // Note: Non-Zero Session may be desirable for Server Applications
                engine = new ObjectSpace(mappingFile, Str_ConnectString, provider);
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

        public static void Function_SaveConfigFile()
        {
            XmlTextWriter XmlTxtWrt_XmlWriter;

            try
            {
                SimatSoft.DB.Encrypt.ClassEncrypt SimatE = new SimatSoft.DB.Encrypt.ClassEncrypt();

                Str_UserID = SimatE.Encrypt(Str_UserID,
                                          Str_PassPhrase,
                                          Str_SaltValue,
                                          Str_HashAlgorithm,
                                          Int_PasswordIterations,
                                          Str_InitVector,
                                          Int_KeySize);

                Str_Password = SimatE.Encrypt(Str_Password,
                                      Str_PassPhrase,
                                      Str_SaltValue,
                                      Str_HashAlgorithm,
                                      Int_PasswordIterations,
                                      Str_InitVector,
                                      Int_KeySize);

                XmlTxtWrt_XmlWriter = new XmlTextWriter(Str_ConfigFileName, new System.Text.UTF8Encoding());
                XmlTxtWrt_XmlWriter.Formatting = Formatting.Indented;
                XmlTxtWrt_XmlWriter.Indentation = 4;

                XmlTxtWrt_XmlWriter.WriteStartDocument();
                XmlTxtWrt_XmlWriter.WriteStartElement("Server", "Controls", "http://www.simat.co.th");
                XmlTxtWrt_XmlWriter.WriteStartElement("Server");

                XmlTxtWrt_XmlWriter.WriteStartElement("Name");
                XmlTxtWrt_XmlWriter.WriteString(Str_Server);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteStartElement("Databasename");
                XmlTxtWrt_XmlWriter.WriteString(Str_Database);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteStartElement("USER");
                XmlTxtWrt_XmlWriter.WriteString(Str_UserID);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteStartElement("PASSWORD");
                XmlTxtWrt_XmlWriter.WriteString(Str_Password);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteStartElement("Type");
                XmlTxtWrt_XmlWriter.WriteString(Str_DB_Type);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteStartElement("Language");
                XmlTxtWrt_XmlWriter.WriteString(Str_Language);
                XmlTxtWrt_XmlWriter.WriteEndElement();

                XmlTxtWrt_XmlWriter.WriteEndElement();
                XmlTxtWrt_XmlWriter.WriteEndDocument();
                XmlTxtWrt_XmlWriter.Flush();
                XmlTxtWrt_XmlWriter.Close();
                XmlTxtWrt_XmlWriter = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
	}
}