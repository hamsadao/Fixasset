using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
namespace SimatSoft.ControlBasic
{
    public class ClassComboBox : System.Windows.Forms.ComboBox   
    {
        public DataRow dataconfig;
        public DataSet datasource ;
        public  void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClassComboBox
            // 
            this.Click += new System.EventHandler(this.ClassComboBox_Click);
            this.ResumeLayout(false);
            loaddata();
          
        }
        private void loaddata()
        {
            
            
            if (datasource != null) 
            {
                
                for (int i = 0; i < datasource.Tables[0].Rows.Count; i++) {
                        this.Items.Add(datasource.Tables[0].Rows[i][0]);
                }   
            }
        }
        private void ClassComboBox_Click(object sender, EventArgs e)
        {

        }
    }
}
