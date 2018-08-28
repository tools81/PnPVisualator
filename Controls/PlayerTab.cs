using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Configuration;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator
{
    public partial class PlayerTab : UserControl
    {
        XPathDocument pvItemDoc = new XPathDocument(Global.ItemXml);
        public PlayerTab()
        {
            InitializeComponent();

            lblName.Text = Player.Name;
            lblPlayer.Text = Player.PlayerName;
            lblClan.Text = Player.Clan;
            lblChronicle.Text = Player.Chronicle;
            lblConcept.Text = Player.Concept;
            lblCovenant.Text = Player.Covenant;
            lblCoterie.Text = Player.Coterie;
            lblVice.Text = Player.Vice;
            lblVirtue.Text = Player.Virtue;

            switch (Player.Template)
            {
                case Global.Template.Human:
                    Global.Human.SetPlayerTabControlStyle(this);
                    break;
                case Global.Template.Vampire:
                    Global.Vampire.SetPlayerTabControlStyle(this);
                    break;
                case Global.Template.Werewolf:
                    Global.Werewolf.SetPlayerTabControlStyle(this);
                    break;
                case Global.Template.Mage:
                    Global.Mage.SetPlayerTabControlStyle(this);
                    break;
                case Global.Template.Hunter:
                    Global.Hunter.SetPlayerTabControlStyle(this);
                    break;
                default:
                    break;
            }

            if (Player.Image != "none")
            {
                imgChar.ImageLocation = Global.CharacterImageFolder + Player.Image;
            }

            XPathDocument xDoc = new XPathDocument(Global.CharacterFolder + Player.Name + ".xml");
            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Character/Equipment");
            XPathNodeIterator xArmorIter = xNav.Select("Armors/Armor[@Equipped='true']");
            while(xArmorIter.MoveNext())
            {
                XPathNavigator xItemNav = pvItemDoc.CreateNavigator().SelectSingleNode(String.Format("Items/Item[@Name='{0}']", xArmorIter.Current.SelectSingleNode("@Name").Value));

                this.gridArmor.Rows.Add(xItemNav.SelectSingleNode("@Name").Value, xItemNav.SelectSingleNode("General").Value, xItemNav.SelectSingleNode("Ballistic").Value);
            }

            XPathNodeIterator xWeapIter = xNav.Select("Weapons/Weapon[@Equipped='true']");
            while (xWeapIter.MoveNext())
            {
                XPathNavigator xItemNav = pvItemDoc.CreateNavigator().SelectSingleNode(String.Format("Items/Item[@Name='{0}']", xWeapIter.Current.SelectSingleNode("@Name").Value));

                string lvAmmo = String.Empty;
                if (xWeapIter.Current.SelectSingleNode("Capacity") != null)
                    lvAmmo = xWeapIter.Current.SelectSingleNode("Capacity/Current").Value + "/" + xWeapIter.Current.SelectSingleNode("Capacity/Max").Value;

                this.gridWeapon.Rows.Add(xWeapIter.Current.SelectSingleNode("@ID").Value, xItemNav.SelectSingleNode("@Name").Value, "...", xItemNav.SelectSingleNode("Primary/Damage").Value, lvAmmo);
            }
        }

        private void gridWeapon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;
                pt.X += 0;
                pt.Y += 1;

                Image image = (Image)(new Bitmap(Properties.Resources.bullet, new Size(20,19)));
                e.Graphics.DrawImage(image, pt);
                e.Handled = true;
            }
        }

        private void gridWeapon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0 && gridWeapon.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                string id = gridWeapon.Rows[e.RowIndex].Cells["ID"].Value.ToString();

                if (String.IsNullOrEmpty(id))
                    return;

                XPathDocument xDoc = new XPathDocument(Global.CharacterFolder + Player.Name + ".xml");
                XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode(String.Format("Character/Equipment/Weapons/Weapon[@ID='{0}']/Capacity", id));

                if (xNav != null)
                {
                    int ammoToFull = xNav.SelectSingleNode("Max").ValueAsInt - xNav.SelectSingleNode("Current").ValueAsInt;
                    CharacterUpdate.ManageAmmo(Global.CharacterFolder + Player.Name + ".xml", id, ammoToFull);

                    gridWeapon.Refresh();
                }                
            }            
        }
    }
}
