using Pen_and_Paper_Visualator.Class.Interfaces;
using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class.Create
{
    class Possessed : ITemplateCreate
    {
        private CreateCharacter _formCreation;
        private XPathDocument cvVestmentXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Vestments.xml");
        private string _Vestment_Img_Folder = Properties.Settings.Default.DataLocation + @"Discipline_Images\";

        private int _vestmentTotal;
        private int _viceTotal;

        private const int _vestmentCost = 10;
        private const int _viceCost = 10;

        public Possessed(CreateCharacter createChar)
        {
            _formCreation = createChar;

            //_formCreation.tblEnvy.BackColor = Color.Transparent;
            //_formCreation.tblEnvy.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Envy_Image.jpg"), 0.25F);
            //_formCreation.tblGluttony.BackColor = Color.Transparent;
            //_formCreation.tblGluttony.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Gluttony_Image.jpg"), 0.25F);
            //_formCreation.tblGreed.BackColor = Color.Transparent;
            //_formCreation.tblGreed.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Greed_Image.jpg"), 0.25F);
            //_formCreation.tblLust.BackColor = Color.Transparent;
            //_formCreation.tblLust.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Lust_Image.jpg"), 0.25F);
            //_formCreation.tblPride.BackColor = Color.Transparent;
            //_formCreation.tblPride.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Pride_Image.jpg"), 0.25F);
            //_formCreation.tblSloth.BackColor = Color.Transparent;
            //_formCreation.tblSloth.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Sloth_Image.jpg"), 0.25F);
            //_formCreation.tblWrath.BackColor = Color.Transparent;
            //_formCreation.tblWrath.BackgroundImage = Global.SetImageOpacity(new Bitmap(_Vestment_Img_Folder + "Wrath_Image.jpg"), 0.25F);
        }

        public void ExperienceCount()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Populate()
        {
            throw new NotImplementedException();
        }

        public void Save(XmlTextWriter xmlTextWriter)
        {
            throw new NotImplementedException();
        }

        public void Screen()
        {
            _formCreation.lblClan.Text = "Cabal";
            _formCreation.lblCovenant.Text = "Order";
            _formCreation.lblDiscText.Text = "Vestment:";
            _formCreation.lblHumanity.Text = "Morality";
            _formCreation.lblPrimDisc.Text = "3";
            _formCreation.lblSecDisc.Text = "0";
            _formCreation.lblTertDisc.Text = "0";
            _formCreation.lblRotesText.Visible = false;
            _formCreation.lblRotes.Visible = false;
            _formCreation.ShowControls(true);
        }
    }
}
