using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SimatSoft.CustomControl;

namespace SimatSoft.FixAsset
{
    public partial class Form_002001_AssetPicturePreview : SS_PaintGradientForm
    {
        public Form_002001_AssetPicturePreview()
        {
            InitializeComponent();
        }
       
        private void Function_ShowPicture(byte[] TempPicture)
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
                if (FinalImage.Width > 217 && FinalImage.Height > 151)
                {
                    Bitmap AlteredImage = new Bitmap(FinalImage, new Size(217, 151));
                    pictureBox_Preview.Image = AlteredImage;
                }
                else
                    pictureBox_Preview.Image = FinalImage;
                
                // Close the stream
                //myStream.Close();
            }
        }
        private void Form_002001_AssetPicturePreview_Load(object sender, EventArgs e)
        {
            Function_ShowPicture((byte[])this.Tag);
        }

        private void Form_002001_AssetPicturePreview_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}