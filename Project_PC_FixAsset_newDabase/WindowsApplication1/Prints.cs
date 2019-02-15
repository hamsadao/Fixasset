using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    class Prints
    {
        //private string SetPort = "COM1";

      /*  public string SetPort1
        {
            get { return SetPort; }
            set { SetPort = value; }
        }*/

         public bool PrintCustomer(string Codes, string CustodianNo, string CustodianName, string UserName)
        {
            bool isComplet;
            try
            {
                //config port "COM1"
                System.IO.Ports.SerialPort inPort = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

               
                
                if (!inPort.IsOpen)
                {
                    inPort.Open();
                }
                
                    inPort.WriteLine("<STX><ESC>C1<ETX>");
                    inPort.WriteLine("<STX><ESC>k<ETX>");
                    inPort.WriteLine("<STX><SI>L630<ETX>");
                    inPort.WriteLine("<STX><SI>S30<ETX>");
                    inPort.WriteLine("<STX><SI>d2<ETX>");
                    inPort.WriteLine("<STX><SI>h0,0;<ETX>");
                    inPort.WriteLine("<STX><SI>l8<ETX>");
                    inPort.WriteLine("<STX><SI>I3<ETX>");
                    inPort.WriteLine("<STX><SI>F0<ETX>");
                    inPort.WriteLine("<STX><SI>D0<ETX>");
                    inPort.WriteLine("<STX><SI>t0<ETX>");
                    inPort.WriteLine("<STX><SI>W835<ETX>");
                    inPort.WriteLine("<STX><SI>g1,567<ETX>");
                    inPort.WriteLine("<STX><ESC>P<ETX>");
                    inPort.WriteLine("<STX>E*;F*;<ETX>");
                    inPort.WriteLine("<STX>L1;<ETX>");
                    inPort.WriteLine("<STX>D0;<ETX>");
                    inPort.WriteLine("<STX>B0;o1116,113;f3;c6,0;h124;w5;r0;i0;d3," + Codes + ";<ETX>"); // Barcode
                    inPort.WriteLine("<STX>D1;<ETX>");
                    inPort.WriteLine("<STX>H1;o960,95;f3;c25;k6;d3," + CustodianNo + ";<ETX>");  // Head No. Text
                    inPort.WriteLine("<STX>H2;o958,400;f3;c25;k6;d3," + Codes + ";<ETX>");  // Barcode value Text
                    inPort.WriteLine("<STX>H3;o903,96;f3;c25;k6;d3," + CustodianName + ";<ETX>"); // Head Name
                    inPort.WriteLine("<STX>H4;o901,398;f3;c25;k6;d3," + UserName + ";<ETX>"); // Name
                    inPort.WriteLine("<STX>R<ETX>");
                    inPort.WriteLine("<STX><ESC>E*<CAN><ETX>");
                    inPort.WriteLine("<STX><RS>1<US>1<ETB><ETX>");
                
                inPort.Close();
                isComplet = true;

            }
            catch (Exception ex)
            {                
                isComplet = false;
                System.Windows.Forms.MessageBox.Show("Error :" + ex.Message, "Warning");
            }

            return isComplet;
        }

        public bool PrintInform(string Codes, string Company,string invDate, string CodeType, string CodeDetail)
        {
            bool isComplet;
            try
            {
                //config port "COM1"
                System.IO.Ports.SerialPort inPort = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                
                if (!inPort.IsOpen)
                {
                    inPort.Open();
                }
                
                inPort.WriteLine("<STX><ESC>C1<ETX>");
                inPort.WriteLine("<STX><ESC>k<ETX>");
                inPort.WriteLine("<STX><SI>L630<ETX>");
                inPort.WriteLine("<STX><SI>S30<ETX>");
                inPort.WriteLine("<STX><SI>d2<ETX>");
                inPort.WriteLine("<STX><SI>h0,0;<ETX>");
                inPort.WriteLine("<STX><SI>l8<ETX>");
                inPort.WriteLine("<STX><SI>I3<ETX>");
                inPort.WriteLine("<STX><SI>F0<ETX>");
                inPort.WriteLine("<STX><SI>D0<ETX>");
                inPort.WriteLine("<STX><SI>t0<ETX>");
                inPort.WriteLine("<STX><SI>W835<ETX>");
                inPort.WriteLine("<STX><SI>g1,567<ETX>");
                inPort.WriteLine("<STX><ESC>P<ETX>");
                inPort.WriteLine("<STX>E*;F*;<ETX>");
                inPort.WriteLine("<STX>L1;<ETX>");
                inPort.WriteLine("<STX>D0;<ETX>");
                inPort.WriteLine("<STX>B4;o1028,96;f3;c6,0;h124;w5;r0;i0;d3," + Codes + ";<ETX>"); // Asset No.BarCode
                inPort.WriteLine("<STX>D1;<ETX>");
                inPort.WriteLine("<STX>H0;o1187,95;f3;c25;k6;d3," + Company + ";<ETX>"); // Bu
                inPort.WriteLine("<STX>H1;o1190,238;f3;c25;k6;d3," + invDate + ";<ETX>"); // Invoice Date
                inPort.WriteLine("<STX>H3;o1140,96;f3;c25;k6;d3," + CodeType + ";<ETX>"); // Barcode Value
                inPort.WriteLine("<STX>H2;o1092,96;f3;c25;k6;d3," + CodeDetail + ";<ETX>"); // Asset Name
                inPort.WriteLine("<STX>R<ETX>");
                inPort.WriteLine("<STX><ESC>E*<CAN><ETX>");
                inPort.WriteLine("<STX><RS>1<US>1<ETB><ETX>");

                inPort.Close();
                isComplet = true;

            }
            catch (Exception ex)
            {
                isComplet = false;
                System.Windows.Forms.MessageBox.Show("Error :"+ex.Message, "Warning");
            }

            return isComplet;
        }

    }
}
