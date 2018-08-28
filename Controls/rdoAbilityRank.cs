using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class rdoAbilityRank : UserControl
    {
        public delegate void rdoAbilityRankClickedHandler();

        public rdoAbilityRank()
        {
            InitializeComponent();           
        }

        private int lvAbilityRank;

        public int AbilityRank
        {
            get { return lvAbilityRank; }
            set { lvAbilityRank = value; }
        }

        private int lvRadioCount;

        public int RadioCount
        {
            get { return lvRadioCount; }
            set { lvRadioCount = value; }
        }

        private bool lvReadOnly;

        public bool ReadOnly
        {
            get { return lvReadOnly; }
            set { lvReadOnly = value; }
        }


        private void rdoAbilityRank_Load(object sender, EventArgs e)
        {
            this.Controls.Clear();

            int lvCount = 1;

            this.Width = 0;

            while (lvCount <= lvRadioCount)
            {
                RadioButton lvRadio = new RadioButton();
                lvRadio.Name = "lvRdo" + lvCount;
                lvRadio.Left = this.Width;
                this.Width += 20;
                lvRadio.Width = 20;
                lvRadio.Height = this.Height;
                lvRadio.AutoCheck = false;
                lvRadio.MouseClick += new MouseEventHandler(lvRadio_MouseClick);
                if (lvCount <= lvAbilityRank) lvRadio.Checked = true;
                this.Controls.Add(lvRadio);
                lvCount++;
            }
        }

        [Category("Action")]
        [Description("Fires when the rank is changed")]
        public event rdoAbilityRankClickedHandler rdoAbilityRankClicked;

        protected virtual void OnrdoAbilityRankClicked()
        {
            if (rdoAbilityRankClicked != null)
            {
                rdoAbilityRankClicked();
            }
        }

        private void lvRadio_MouseClick(object Sender, MouseEventArgs e)
        {
            if (!ReadOnly)
            {
                RadioButton rdo = Sender as RadioButton;

                int rdoIndex = 0;
                if (rdo.Name.Length == 6) rdoIndex = Convert.ToInt32(rdo.Name.Substring(5, 1));
                else rdoIndex = Convert.ToInt32(rdo.Name.Substring(5, 2));

                if (rdo.Checked && AbilityRank == 1) AbilityRank = 0;
                else AbilityRank = rdoIndex;
                rdoAbilityRank_Load(rdo, new EventArgs());

                OnrdoAbilityRankClicked();
            }
        }

        public override void Refresh()
        {
            this.Controls.Clear();

            int lvCount = 1;

            this.Width = 0;

            while (lvCount <= lvRadioCount)
            {
                RadioButton lvRadio = new RadioButton();
                lvRadio.Name = "lvRdo" + lvCount;
                lvRadio.Left = this.Width;
                this.Width += 20;
                lvRadio.Width = 20;
                lvRadio.Height = this.Height;
                lvRadio.AutoCheck = false;
                lvRadio.MouseClick += new MouseEventHandler(lvRadio_MouseClick);
                if (lvCount <= lvAbilityRank) lvRadio.Checked = true;
                this.Controls.Add(lvRadio);
                lvCount++;
            }
        }
    }
}
