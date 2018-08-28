using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Pen_and_Paper_Visualator.Class.Interfaces
{
    public interface ITemplateCreate
    {
        void Load();
        void Populate();
        void Screen();
        void Save(XmlTextWriter xmlTextWriter);
        void ExperienceCount();
    }
}
