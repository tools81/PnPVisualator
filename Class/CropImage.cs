using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Drawing.Imaging;

namespace Pen_and_Paper_Visualator.Class
{
    class CropImage
    {
        private static Bitmap[] lvImageSet;

        public static Bitmap[] ImageSet
        {
            get { return lvImageSet; }
            set { lvImageSet = value; }
        }

        private static ArrayList lvImageMatrix;

        public static ArrayList ImageMatrix
        {
            get { return lvImageMatrix; }
            set { lvImageMatrix = value; }
        }

        private static ArrayList lvLocation;

        public static ArrayList Location
        {
            get { return lvLocation; }
            set { lvLocation = value; }
        }

        public CropImage(Image cvImage, int cvCropWidth, int cvCropHeight)
        {
            int lvImageWidth = cvImage.Width;
            int lvImageHeight = cvImage.Height;

            int lvWidthCount = (int)Math.Ceiling((lvImageWidth * 1.00) / (cvCropWidth * 1.00));
            int lvHeightCount = (int)Math.Ceiling((lvImageHeight * 1.00) / (cvCropHeight * 1.00));

            int i = 0;
            for (int iHeight = 0; iHeight < lvHeightCount; iHeight++)
            {
                for (int iWidth = 0; iWidth < lvWidthCount; iWidth++)
                {
                    int pointX = iWidth * cvCropWidth;
                    int pointY = iHeight * cvCropHeight;
                    int areaWidth = ((pointX + cvCropWidth) > lvImageWidth) ? (lvImageWidth - pointX) : cvCropWidth;
                    int areaHeight = ((pointY + cvCropHeight) > lvImageHeight) ? (lvImageHeight - pointY) : cvCropHeight;
                    string s = string.Format("{0};{1};{2};{3}", pointX, pointY, areaWidth, areaHeight);

                    Rectangle rect = new Rectangle(pointX, pointY, areaWidth, areaHeight);
                    lvImageMatrix.Add(rect);
                    lvLocation.Add("[" + iWidth + "," + iHeight + "]");
                    i++;
                }
            }

            //int h = 0;
            //int w = 0;
            for (int iLoop = 0; iLoop < lvImageMatrix.Count; iLoop++)
            {
                Rectangle rect = (Rectangle)lvImageMatrix[iLoop];

                Bitmap newBmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format24bppRgb);
                Graphics newBmpGraphics = Graphics.FromImage(newBmp);
                newBmpGraphics.DrawImage(cvImage, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
                newBmpGraphics.Save();

                //if (iLoop > lvWidthCount)
                //{
                //    h++; 
                //    w = 0;
                //}
                //else w++;

                //lvImageSet.SetValue(newBmp, w, h);
            }

            cvImage.Dispose();
        }
    }
}
