using System;
using System.Collections.Generic;
using System.Text;

namespace SimatSoft.QueryManager
{
    public class Class_Collist
    {
        private int P_id;
        private string P_name;
        private int P_Width;
        private string P_dbfieldname;

        public Class_Collist(int id, string name, string dbfieldname, int width)
        {
            P_id = id;
            P_name = name;
            P_dbfieldname = dbfieldname;
            P_Width = width; 
        }
        public Class_Collist()
        {
        }
    
        public int id
        {
            get
            {
                return P_id;
            }
            set
            {
                P_id = value;
            }
        }

        public string name
        {
            get
            {
                return P_name;
            }
            set
            {
                P_name = value;
            }
        }

        public int width
        {
            get
            {
                return P_Width;
            }
            set
            {
                P_Width = value;
            }
        }
        public string dbfieldname{
            get 
            {
                return P_dbfieldname; 
            }
            set 
            {
                P_dbfieldname = value; 
            }
        }
    }
}
