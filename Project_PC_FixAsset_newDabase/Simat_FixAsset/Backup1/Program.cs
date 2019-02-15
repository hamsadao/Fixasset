using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimatSoft.Secure.Lincense;

namespace SimatSoft.FixAsset
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool result = SimatSoft.Secure.Lincense.Simat_License.SS_License_Validate();
            if (result)
            {
                Application.Run(new Form_000000_MDI());
            }
        }

    
    }
}