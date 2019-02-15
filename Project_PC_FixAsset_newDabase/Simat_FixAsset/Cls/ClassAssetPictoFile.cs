using System;
using System.Collections.Generic;
using System.Text;
using SimatSoft.DB.ORM;
using Wilson.ORMapper;
using System.IO;
using System.Drawing;
using OpenNETCF.Desktop.Communication;

namespace SimatSoft.FixAsset
{
    public class ClassAssetPictoFile
    {
        public void Extract_Assetpic(string path, ref System.Collections.ArrayList arrayfilename ) 
        {
            ObjectSet<AssetPic> AssetPicObjSet = ManagerPic.Engine.GetObjectSet <AssetPic>("");
            for(int  i =0 ;i < AssetPicObjSet.Count;i++  )
            {
                Function_ShowPicture(AssetPicObjSet[i].Picture, AssetPicObjSet[i].AssetID ,path ,ref arrayfilename );
            } 

        }
        public void SendData(RAPI m_rapi,string Handheldpath) 
        {
             //string Path = "";
             //   Path = AppDomain.CurrentDomain.BaseDirectory + "Pic\\";
             //   DirectoryInfo dir = new DirectoryInfo(Path);
             //   FileInfo[] file= dir.GetFiles();
             //   for (int i = 0; i < file.Length; i++) 
             //   {
             //       m_rapi.CopyFileToDevice(Path + "\\" + file[i].Name, Handheldpath +"\\"+ file[i].Name, true);
             //   }  
            
        }
        private void Function_ShowPicture(byte[] TempPicture, string Assetid, string path, 
            ref  System.Collections.ArrayList arrayfilename)
        {
            byte[] myByteArray = (byte[])TempPicture;
            if (myByteArray.Length > 0)
            {
                // Create a new MemoryStream and write all the information from
                // the byte array into the stream
                MemoryStream myStream = new MemoryStream(myByteArray, true);
                myStream.Write(myByteArray, 0, myByteArray.Length);
                // Use the MemoryStream to create the new BitMap object
                Bitmap FinalImage = new Bitmap(myStream);
                // See if the image stored will fit in the picture box. If it's too big, 
                // resize and create a new BitMap object and assign to the PictureBox control
               //Bitmap AlteredImage = new Bitmap(FinalImage, new Size(600, 600));
                Bitmap AlteredImage = new Bitmap(FinalImage);
                // check Dir Pic
                //string Path = "";
                //Path = AppDomain.CurrentDomain.BaseDirectory + "Pic\\";   
                AlteredImage.Save(path  +  Assetid + ".jpg",System.Drawing.Imaging.ImageFormat.Jpeg     );
                //AlteredImage.Save(path + Assetid + ".png", System.Drawing.Imaging.ImageFormat.Png );
               // AlteredImage.Save(path + Assetid + ".jpg");
                arrayfilename.Add( Assetid + ".jpg");
                

                
            }
        }
    }
}
