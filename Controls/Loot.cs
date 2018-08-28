using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using System.IO;
using Pen_and_Paper_Visualator.Class;
using System.Threading;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Loot : UserControl
    {
        private readonly int cvControlHeight = 169;
        private readonly int cvControlWidth = 146;
        private int cvControlTop = 0;
        private int cvControlLeft = 25;
        private int cvControlCount = 0;

        public Loot()
        {
            InitializeComponent();

            string[] files = Directory.GetFiles(Global.LootFolder, "Loot.xml");            
            while (IsFileLocked(files[0]))
                Thread.Sleep(1000);
            XPathDocument lvLootXml = new XPathDocument(Global.LootXml);
            XPathNavigator lvNav = lvLootXml.CreateNavigator();
            XPathNodeIterator lvNodeIter = lvNav.Select("Items/Item");

            while (lvNodeIter.MoveNext())
            {
                LootDisplay.ItemName = lvNodeIter.Current.SelectSingleNode("@Name").Value;
                LootDisplay.ID = lvNodeIter.Current.SelectSingleNode("@ID").Value;
                LootDisplay.ItemSize = lvNodeIter.Current.SelectSingleNode("@Size").ValueAsInt;
                LootDisplay.Value = lvNodeIter.Current.SelectSingleNode("@Value").ValueAsInt;
                LootDisplay.Image = lvNodeIter.Current.SelectSingleNode("@Image").Value;
                LootDisplay.Type = lvNodeIter.Current.SelectSingleNode("@Type").Value;

                LootDisplay lvDisplay = new LootDisplay();

                if (cvControlCount > 0 && cvControlCount % 4 == 0)
                {
                    cvControlTop += cvControlHeight + 2;
                    cvControlLeft = 25;
                }

                lvDisplay.Top = cvControlTop;
                lvDisplay.Left = cvControlLeft;

                this.Controls.Add(lvDisplay);

                cvControlLeft += cvControlWidth + 25;
                cvControlCount++;
            }  
        }

        protected virtual bool IsFileLocked(string file)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
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
    }
}
