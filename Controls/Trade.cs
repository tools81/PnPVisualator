using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Trade : UserControl
    {
        Label lblItemName = new Label();
        XPathDocument lvItemXml = new XPathDocument(Global.ItemXml);
        XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Characters/" + Player.Name + ".xml");

        public Trade()
        {
            InitializeComponent();

            string lvMoney;
            lvMoney = Player.Cash.ToString();

            XPathNavigator nav = lvItemXml.CreateNavigator();
            XPathNavigator charNav = lvCharXml.CreateNavigator();
            int lvImageOffsetLeft = 5;
            int lvImageOffsetTop = 20;

            foreach (string lvEquipment in Player.Equipment)
            {
                if (lvEquipment != null && lvEquipment != "")
                {
                    Item.Name = charNav.SelectSingleNode(String.Format("Character/Equipment/Items/Item[@ID='{0}']/@Name", lvEquipment)).Value;
                    Item.Durability = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Durability").Value);
                    Item.Size = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Size").Value);
                    Item.Cost = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Cost").Value);
                    Item.Structure = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Structure").Value);
                    Item.Image = nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Image").Value;
                    Item.Description = nav.SelectSingleNode("Items/Item[@Name = '" + Item.Name + "']/Description").Value;

                    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Item.Name, Item.Image);
                    //foreach (DataRow lvRow in Item.ItemTable.Rows)
                    //{
                    //    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Item.Name, Item.Image);
                    //}
                }
            }

            foreach (string lvWeapon in Player.Weapon)
            {
                if (lvWeapon != null && lvWeapon != "")
                {
                    Weapon.Name = charNav.SelectSingleNode(String.Format("Character/Equipment/Weapons/Weapon[@ID='{0}']/@Name", lvWeapon)).Value;
                    //Weapon.Durability = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + lvWeapon + "']/Durability").Value);
                    Weapon.Size = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Weapon.Name + "']/Size").Value);
                    Weapon.Cost = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Weapon.Name + "']/Cost").Value);
                    //Weapon.Structure = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + lvWeapon + "']/Structure").Value);
                    Weapon.Image = nav.SelectSingleNode("Items/Item[@Name = '" + Weapon.Name + "']/Image").Value;
                    Weapon.Description = nav.SelectSingleNode("Items/Item[@Name = '" + Weapon.Name + "']/Description").Value;

                    lvImageOffsetTop += 105;
                    lvImageOffsetLeft = 5;

                    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Weapon.Name, Weapon.Image);
                    //foreach (DataRow lvRow in Weapon.WeaponTable.Rows)
                    //{
                    //    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Weapon.Name, Weapon.Image);
                    //}
                }
            }

            foreach (string lvArmor in Player.Armor)
            {
                if (lvArmor != null && lvArmor != "")
                {
                    Armor.Name = charNav.SelectSingleNode(String.Format("Character/Equipment/Armors/Armor[@ID='{0}']/@Name", lvArmor)).Value;
                    Armor.Cost = Convert.ToInt32(nav.SelectSingleNode("Items/Item[@Name = '" + Armor.Name + "']/Cost").Value);
                    Armor.Image = nav.SelectSingleNode("Items/Item[@Name = '" + Armor.Name + "']/Image").Value;
                    Armor.Description = nav.SelectSingleNode("Items/Item[@Name = '" + Armor.Name + "']/Description").Value;

                    lvImageOffsetTop += 105;
                    lvImageOffsetLeft = 5;

                    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Armor.Name, Armor.Image);
                    //foreach (DataRow lvRow in Armor.ArmorTable.Rows)
                    //{
                    //    CreateImage(ref lvImageOffsetLeft, ref lvImageOffsetTop, Armor.Name, Armor.Image);
                    //}
                }
            }                        
        }

        private void CreateImage(ref int lvImageOffsetLeft, ref int lvImageOffsetTop, string lvName, string lvImageLoc)
        {
            PictureBox lvImage = new PictureBox();
            lvImage.Name = lvName;
            lvImage.Height = 100;
            lvImage.Width = 100;
            lvImage.ImageLocation = Properties.Settings.Default.DataLocation + "Item_Images\\" + lvImageLoc;
            lvImage.SizeMode = PictureBoxSizeMode.StretchImage;
            lvImage.Top = lvImageOffsetTop;
            lvImage.Left = lvImageOffsetLeft;
            lvImage.MouseHover += new EventHandler(lvImage_MouseHover);
            lvImage.MouseLeave += new EventHandler(lvImage_MouseLeave);
            lvImage.MouseClick += new MouseEventHandler(lvImage_MouseClick);
            lvImage.MouseDown += new MouseEventHandler(lvImage_MouseDown);
            //lvImage.DragDrop += new DragEventHandler(lvImage_DragDrop);
            this.Controls.Add(lvImage);
            if (lvImageOffsetLeft < 380)
            {
                lvImageOffsetLeft += 105;
            }
            else
            {
                lvImageOffsetLeft = 5;
                lvImageOffsetTop += 105;
            }
        }

        private void lvImage_MouseHover(object Sender, EventArgs e)
        {
            PictureBox pBox = Sender as PictureBox;
            lblItemName.Text = pBox.Name;
            lblItemName.Left = Cursor.Position.X - frmVisualator.ActiveForm.Left - 20;
            lblItemName.Top = Cursor.Position.Y - frmVisualator.ActiveForm.Top - 35;
            this.Controls.Add(lblItemName);
            lblItemName.BringToFront();
        }

        private void lvImage_MouseLeave(object Sender, EventArgs e)
        {
            lblItemName.Text = "";
            lblItemName.SendToBack();
        }

        private void lvImage_MouseClick(object Sender, MouseEventArgs e)
        {
            foreach (Control lvControl in this.Controls)
            {
                if (lvControl is PictureBox)
                {
                    PictureBox lvPBox = lvControl as PictureBox;
                    lvPBox.BorderStyle = BorderStyle.None;
                }
            }

            PictureBox pBox = Sender as PictureBox;
            pBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void lvImage_MouseDown(object Sender, EventArgs e)
        {
            PictureBox pBox = Sender as PictureBox;
            pBox.DoDragDrop(pBox.Name, DragDropEffects.Move);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
