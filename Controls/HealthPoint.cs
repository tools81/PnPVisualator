using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Properties;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class HealthPoint : UserControl
    {
        public HealthPoint()
        {
            InitializeComponent();           
        }

        private StateEnum _State;

        public StateEnum State
        {
            get { return _State; }
            set { _State = value; }
        }

        public enum StateEnum
        {
            Clear,
            Bash,
            Lethal,
            Aggravated
        }

        private void HealthPoint_Load(object sender, EventArgs e)
        {
            SetHealthState();
        }

        public void SetHealthState()
        {
            switch (_State)
            {
                case StateEnum.Bash:
                    this.BackgroundImage = Resources.Bash;
                    break;
                case StateEnum.Lethal:
                    this.BackgroundImage = Resources.Lethal;
                    break;
                case StateEnum.Aggravated:
                    this.BackgroundImage = Resources.Aggravated;
                    break;
                default:
                    this.BackgroundImage = Resources.Clear;
                    break;
            }
        }
    }
}
