using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Configuration;
using System.Threading;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Map : UserControl
    {
        private Image mapImage;
        private int zoomIncrement;
        private int prevZoomIncrement = 0;
        private bool doZoom = false;
        private Point imageDrawPoint;
        private int imageWidth;
        private int imageHeight;
        private int squareX;
        private int squareY;
        private int squareUnit = 30;
        private Graphics graphics;
        private bool mouseDown;
        private Point mouseMoveBegin;

        public Image MapImageFile
        {
            get { return mapImage; }
            set { mapImage = value; }
        }

        public Map()
        {
            InitializeComponent();           
            graphics = this.CreateGraphics();

            if (Global._UserState == Global.UserState.GM)
            {
                mapMenuStrip.Visible = true;
            }
            else if (mapImage == null)
            {
                mapMenuStrip.Visible = false;

                string[] files = Directory.GetFiles(Global.MapFolder, "*.jpg, *.gif, *.png, *.bmp, *.jpeg, *.tif");

                if (files.Length > 0)
                {
                    mapImage = Image.FromFile(files[0]);
                    graphics.DrawImage(mapImage, imageDrawPoint.X, imageDrawPoint.Y, imageWidth, imageHeight); 
                }
            }           
        }       

        private void browseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string lvMapLoc;
            string lvFileName;

            ofdMapFile.InitialDirectory = Properties.Settings.Default.DataLocation + @"\Repository_Maps";
            ofdMapFile.RestoreDirectory = true;

            if (ofdMapFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    lvMapLoc = ofdMapFile.FileName;
                    lvFileName = Path.GetFileName(lvMapLoc);
                    string lvMapDestination = Properties.Settings.Default.DataLocation + @"Active\Map\" + lvFileName;

                    Delete_Files();
                    File.Copy(lvMapLoc, lvMapDestination);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Delete_Files()
        {           
            graphics.Clear(Color.Black);

            if (mapImage != null)
            {
                mapImage.Dispose();
            }            

            DirectoryInfo di = new DirectoryInfo(Global.MapFolder);

            foreach (FileInfo file in di.GetFiles())
            {
                while (IsFileLocked(file))
                    Thread.Sleep(1000);
                file.Delete();
            }
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            if (mapImage != null)
            {
                btnCenter.Visible = true;
                btnZoomIn.Visible = true;
                btnZoomOut.Visible = true;

                if (zoomIncrement == 0)
                {
                    imageWidth = mapImage.Width - (imageWidth % squareUnit);
                    imageHeight = mapImage.Height - (imageHeight % squareUnit);
                    squareX = imageWidth / squareUnit;
                    squareY = imageHeight / squareUnit;
                }
                else if (prevZoomIncrement < zoomIncrement)
                {
                    imageWidth += squareX * 10;
                    imageHeight += squareY * 10;
                    prevZoomIncrement = zoomIncrement;
                }
                else if (prevZoomIncrement > zoomIncrement)
                {
                    imageWidth -= squareX * 10;
                    imageHeight -= squareY * 10;
                    prevZoomIncrement = zoomIncrement;
                }

                graphics.DrawImage(mapImage, imageDrawPoint.X, imageDrawPoint.Y, imageWidth, imageHeight);                
            }
            else
            {
                btnCenter.Visible = false;
                btnZoomIn.Visible = false;
                btnZoomOut.Visible = false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_Files();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }

        private void btnZoomIn_Click(object sender, EventArgs e)
        {
            if (squareUnit < 100)
            {
                prevZoomIncrement = zoomIncrement;
                squareUnit += 10;
                zoomIncrement += 10;
                doZoom = true;
                this.Refresh();
            }
        }

        private void btnZoomOut_Click(object sender, EventArgs e)
        {
            if (squareUnit > 10)
            {
                prevZoomIncrement = zoomIncrement;
                squareUnit -= 10;
                zoomIncrement -= 10;
                doZoom = true;
                this.Refresh();
            }
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            mouseMoveBegin = this.PointToClient(Cursor.Position);
            mouseDown = true;
            this.Cursor = Cursors.Hand;
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            this.Cursor = Cursors.Arrow;
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                int x = mouseMoveBegin.X - this.PointToClient(Cursor.Position).X + imageDrawPoint.X;
                int y = mouseMoveBegin.Y - this.PointToClient(Cursor.Position).Y + imageDrawPoint.Y;

                imageDrawPoint = new Point(x, y);
                this.Refresh();
            }
        }

        private void btnCenter_Click(object sender, EventArgs e)
        {
            imageDrawPoint.X = 0;
            imageDrawPoint.Y = 0;
            this.Refresh();
        }
    }
}
