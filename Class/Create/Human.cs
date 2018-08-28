using Pen_and_Paper_Visualator.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Class.Create
{    
    class Human
    {
        private CreateCharacter _formCreation;

        public Human(CreateCharacter createChar)
        {
            _formCreation = createChar;            
        }

        public void Load()
        {
            
        }

        public void Screen()
        {
            _formCreation.lblHumanity.Text = "Morality";
            _formCreation.ShowControls(false);
        }
    }
}
