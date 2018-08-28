using Pen_and_Paper_Visualator.Class.Interfaces;
using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Xml.XPath;
using System.Xml;

namespace Pen_and_Paper_Visualator.Class.Create
{
    class Hunter : ITemplateCreate
    {
        private CreateCharacter _formCreation;        
        private XPathDocument cvProfessionXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Discipline.xml");
        private XPathDocument cvClanXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Clans.xml");
        private XPathDocument cvCovenantXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Covenants.xml");
        private string _Profession_Img_Folder = Properties.Settings.Default.DataLocation + @"Discipline_Images\";

        private int _professionTotal;

        private const int _benedictionCost = 5;

        public Hunter(CreateCharacter createChar)
        {
            _formCreation = createChar;            
        }

        public void Load()
        {
            
        }

        public void Screen()
        {
            _formCreation.ShowControls(false);
        }

        public void Populate()
        {
            throw new NotImplementedException();
        }

        public void Save(XmlTextWriter xmlTextWriter)
        {
            throw new NotImplementedException();
        }

        public void ExperienceCount()
        {
            throw new NotImplementedException();
        }
    }
}
