using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using SimatSoft.CustomControl;

namespace SimatSoft.FixAsset
{
    class Prints
    {
        
        private string FiletxtName = "WriteText.txt";
       // private string PathFile = @"C:\Program Files\FixedAssetFile\";
       // Edit on 18-03-09 Change path File for label printing 
        private string PathFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\FixedAssetFile\\";
        public bool isComplet;

        public bool PrintCustomer(string Codes, string CustodianNo, string CustodianName, string UserName)
        {
            try
            {
                /////////// Write text to file ////////////////////
                 string text = "<STX><ESC>C0<ETX>\r\n" +  //1
                   "<STX><ESC>k<ETX>\r\n" +             //2
                   "<STX><SI>L200<ETX>\r\n" +           //3
                   "<STX><SI>S40<ETX>\r\n" +           //4
                   "<STX><SI>d6<ETX>\r\n" +            //5
                   "<STX><SI>h0,0;<ETX>\r\n" +         //6
                   "<STX><SI>l8<ETX>\r\n" +
                   "<STX><SI>F6<ETX>\r\n" +
                   "<STX><SI>D0<ETX>\r\n" +
                   "<STX><SI>t0<ETX>\r\n" +            //10
                   "<STX><SI>W480<ETX>\r\n" +
                   "<STX><SI>g1,450<ETX>\r\n" +
                   "<STX><ESC>P<ETX>\r\n" +
                   "<STX>E*;F*;<ETX>\r\n" +
                   "<STX>L1;<ETX>\r\n" +          //15
                   "<STX>D0;<ETX>\r\n" +
                   //"<STX>B0;o180,101;f3;c6,0;h62;w2;r0;i0;d3," + Codes + ";<ETX>\r\n" +
                   "<STX>B0;o133,76;f3;c6,0;h59;w2;r0;i0;d3," + Codes + ";<ETX>\r\n" +
                   "<STX>D1;<ETX>\r\n" +
                   "<STX>H1;o71,80;f3;c26;h7;w8;d3," + CustodianNo + ";<ETX>\r\n" +
                   "<STX>H2;o70,231;f3;c26;h7;w8;d3," + Codes + ";<ETX>\r\n" +             //20
                   "<STX>H3;o49,80;f3;c26;h7;w8;d3," + CustodianName + ";<ETX>\r\n" +
                   "<STX>H4;o48,230;f3;c26;h7;w8;d3," + UserName + ";<ETX>\r\n" +
                   "<STX>R<ETX>\r\n" +
                   "<STX><ESC>E*<CAN><ETX>\r\n" +
                   "<STX><RS>1<US>1<ETB><ETX>\r\n";      //25

                ///////////////////////////////////////////////////
                 if (System.IO.Directory.Exists(PathFile))
                 {
                     if (System.IO.File.Exists(PathFile+FiletxtName))
                     {

                         try
                         {
                             // Write text
                             System.IO.File.WriteAllText(PathFile + FiletxtName , text);
                             isComplet = true;
                         }
                         catch (Exception ex)
                         {
                             SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                             isComplet = false;
                             
                         }
                     }
                     else
                     {
                         System.IO.File.Create(PathFile + FiletxtName);

                         if (System.IO.File.Exists(PathFile+ FiletxtName))
                         {
                             try
                             {
                                 // Write text
                                 System.IO.File.WriteAllText(PathFile+FiletxtName, text);
                                 isComplet = true;
                             }
                             catch (Exception ex)
                             {
                                 SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                                 isComplet = false;
                             }
                         }
                     }
                 }
                 else  // if Folder and File not found , create it
                 {
                     System.IO.Directory.CreateDirectory(PathFile);
                     System.IO.File.Create(PathFile + FiletxtName);

                     if (System.IO.File.Exists(PathFile + FiletxtName))
                     {
                      
                         try
                         {
                             // Write text
                             System.IO.File.WriteAllText(PathFile + FiletxtName, text);
                             isComplet = true;
                         }
                         catch (Exception ex)
                         {
                             SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                             isComplet = false;
                         }
                     }
                 }
               /////////////////////////////////////////////////////////////////////////////

                 if (isComplet == true)
                 {
                     ShowPrinterDialog();
                 }
                 else
                 {
                     isComplet = false;
                 }

            }
            catch (Exception exx)
            {
                isComplet = false;
            }

            return isComplet;
        }

        public bool PrintInform(string Codes, string Company, string invDate, string CodeType, string CodeDetail)
        {
            try
            {
                /////////// Write text to file
               string text = "<STX><ESC>C0<ETX>\r\n" +  //1
                    "<STX><ESC>k<ETX>\r\n" +           //2
                    "<STX><SI>L200<ETX>\r\n" +        //3
                    "<STX><SI>S40<ETX>\r\n" +        //4
                    "<STX><SI>d6<ETX>\r\n" +        //5
                    "<STX><SI>h0,0;<ETX>\r\n" +    //6
                    "<STX><SI>l8<ETX>\r\n" +
                    "<STX><SI>F4<ETX>\r\n" +     //f10,f6(from Label Design)
                    "<STX><SI>D0<ETX>\r\n" +
                    "<STX><SI>t0<ETX>\r\n" +    //10
                    "<STX><SI>W480<ETX>\r\n" +
                  //"<STX><SI>g1,567<ETX>\r\n" +
                  "<STX><SI>g1,450<ETX>\r\n" +
                    "<STX><ESC>P<ETX>\r\n" +
                    "<STX>E*;F*;<ETX>\r\n" +
                    "<STX>L1;<ETX>\r\n" +          //15
                    "<STX>D0;<ETX>\r\n" +
                    "<STX>B0;o54,124;f3;c6,0;h62;w2;r0;i0;d3," + Codes + ";<ETX>\r\n" +
                    "<STX>D1;<ETX>\r\n" +
                    "<STX>H1;o147,144;f3;c26;h8;w9;d3," + Company + ";<ETX>\r\n" +
                    "<<STX>H2;o129,171;f3;c26;h8;w9;d3," + invDate + ";<ETX>\r\n" +             //20
                    "<STX>H3;o116,111;f3;c26;h14;w15;d3," + CodeDetail + ";<ETX>\r\n" +
                    "<STX>H4;o82,144;f3;c26;h13;w15;d3," + CodeType + ";<ETX>\r\n" +
                    "<STX>R<ETX>\r\n" +
                    "<STX><ESC>E*<CAN><ETX>\r\n" +
                    "<STX><RS>1<US>1<ETB><ETX>\r\n";      //25  
                    
                // Edit on 25-02-09
               //////////////////////////////////////////////
               if (System.IO.Directory.Exists(PathFile))
               {
                   if (System.IO.File.Exists(PathFile + FiletxtName))
                   {
                       try
                       {
                           // Write text
                           
                           System.IO.File.WriteAllText(PathFile + FiletxtName, text);
                           isComplet = true;
                       }
                       catch (IOException ex)
                       {
                           SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                           isComplet = false;
                       }
                       catch (Exception ex)
                       {
                           SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                           isComplet = false;
                       }
                   }
                   else
                   {
                       System.IO.File.Create(PathFile + FiletxtName);

                       if (System.IO.File.Exists(PathFile + FiletxtName))
                       {
                           try
                           {
                               // Write text
                               System.IO.File.WriteAllText(PathFile + FiletxtName, text);
                               isComplet = true;
                           }
                           catch (Exception ex)
                           {
                               SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                               isComplet = false;
                           }
                       }
                   }
               }
               else  // if Folder and File not found , create it
               {
                   System.IO.Directory.CreateDirectory(PathFile);
                   System.IO.File.Create(PathFile + FiletxtName);

                   if (System.IO.File.Exists(PathFile + FiletxtName))
                   {

                       try
                       {
                           // Write text
                           System.IO.File.WriteAllText(PathFile + FiletxtName, text);
                           isComplet = true;
                       }
                       catch (Exception ex)
                       {
                           SS_MyMessageBox.ShowBox("Can't write all text into the text file.\r\n Please try to print again.");
                           isComplet = false;
                       }
                   }
               }

                if (isComplet == true)
                {
                    //ShowPrinterDialog();
                    ShowPrinterDialogForAssetNew();
                }
                else
                {
                    isComplet = false;
                }
            
            }
            catch (Exception exx)
            {
                isComplet = false;
            }

            return isComplet;
        }
        //**************************************New Function For PrintAssetbarcode ****************************
        void ShowPrinterDialogForAssetNew()
        {
            try
            {
                    // Print the file to the printer.
                RawPrinterHelper.SendFileToPrinter(Form_005010_Barcode_Asset_New.pd.PrinterSettings.PrinterName, PathFile + FiletxtName + " ");
                isComplet = true;

            }
            catch (Exception ex1)
            {
                SS_MyMessageBox.ShowBox("Can't send a file to print.");
                isComplet = false;
            }
        }//*************************************************************************************************

        void ShowPrinterDialog()
        {

                try
                {
                    // Allow the user to select a printer.
                    PrintDialog pd = new PrintDialog();
                    pd.PrinterSettings = new PrinterSettings();

                    if (DialogResult.OK == pd.ShowDialog())
                    {
                        // Print the file to the printer.
                        RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, PathFile + FiletxtName + " ");
                        isComplet = true;
                    }
                    else 
                    {
                        isComplet = false;
                    }

                }
                catch (Exception ex1)
                {
                    SS_MyMessageBox.ShowBox("Can't send a file to print.");
                    isComplet = false;
                }
        }
        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "Fixed Asset Barcode is printing.";
                di.pDataType = "RAW";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                fs.Flush();
                fs.Dispose();                
                fs.Close();
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
                
            }

        }
    }
}
