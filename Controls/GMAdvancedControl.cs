using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class AdvancedGMControl : UserControl
    {
        private string cvXmlFile;

        public AdvancedGMControl()
        {
            InitializeComponent();

            SetXmlFile();
            ddlDamageType.SelectedIndex = 0;

            XPathDocument xCharDoc = new XPathDocument(cvXmlFile);
            XPathNavigator xCharNav = xCharDoc.CreateNavigator();            

            lblEffectedActor.Text = xCharNav.SelectSingleNode("Character/Background/Name").Value;

            XPathDocument xCombatDoc = new XPathDocument(Global.CombatXml);
            XPathNodeIterator entityNodeIter = xCombatDoc.CreateNavigator().Select("Combat/Entity");
            Dictionary<string, string> actorDictionary = new Dictionary<string, string>();

            while (entityNodeIter.MoveNext())
            {
                actorDictionary.Add(entityNodeIter.Current.SelectSingleNode("@ID").Value, entityNodeIter.Current.SelectSingleNode("@Name").Value);
            }

            lstActors.DataSource = new BindingSource(actorDictionary, null);
            lstActors.DisplayMember = "Value";
            lstActors.ValueMember = "Key";
        }

        private void lstActors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedActorKey = ((KeyValuePair<string, string>)lstActors.SelectedItem).Key;
            Guid result;
            XPathDocument xDoc = Guid.TryParse(selectedActorKey, out result) ? new XPathDocument(Global.CombatFolder + "/" + selectedActorKey + ".xml") : new XPathDocument(Global.CharacterFolder + "/" + selectedActorKey + ".xml");

            PopulateWeapons(xDoc);
            PopulateAbilities(xDoc);

            if (lstActors.SelectedItem != null)
                btnConfirm.Enabled = true;
        }        

        public void SetXmlFile()
        {
            if (Global.SelectedActorType == Global.CharType.Character)
                cvXmlFile = Global.CharacterFolder + Global.SelectedActorID + ".xml";
            else if (Global.SelectedActorType == Global.CharType.NPC)
                cvXmlFile = Global.CombatFolder + Global.SelectedActorID + ".xml";
            else
            {
                //TODO: Exception
            }
        }

        private void PopulateWeapons(XPathDocument xDoc)
        {
            lstWeapons.Items.Clear();

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Character/Equipment");
            XPathNodeIterator xWeapIter = xNav.Select("Weapons/Weapon[@Equipped='true']");

            while (xWeapIter.MoveNext())
            {
                lstWeapons.Items.Add(xWeapIter.Current.SelectSingleNode("@Name").Value);
            }
        }

        private void PopulateAbilities(XPathDocument xDoc)
        {
            lstAbilities.Items.Clear();

            XPathNavigator xNav = xDoc.CreateNavigator().SelectSingleNode("Character");

            Global.Vampire.PopulateAdvancedGMControlAbilities(this, xNav);
            Global.Werewolf.PopulateAdvancedGMControlAbilities(this, xNav);
            Global.Mage.PopulateAdvancedGMControlAbilities(this, xNav);         
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Parent.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (chkSuccess.Checked)
            {
                switch (ddlDamageType.Text)
                {
                    case "Bash":
                        CharacterUpdate.Damage(Convert.ToInt32(numDamage.Value), Global.DamageType.Bash, cvXmlFile);
                        break;
                    case "Lethal":
                        CharacterUpdate.Damage(Convert.ToInt32(numDamage.Value), Global.DamageType.Lethal, cvXmlFile);
                        break;
                    case "Aggravated":
                        CharacterUpdate.Damage(Convert.ToInt32(numDamage.Value), Global.DamageType.Aggravated, cvXmlFile);
                        break;
                    default:
                        break;
                }
            }            

            if (lstWeapons.SelectedItem != null)
            {
                ChatboxMessages.CombatDamageWeapon(lstActors.SelectedValue.ToString(), lblEffectedActor.Text, lstWeapons.SelectedItem.ToString(), chkSuccess.Checked, Convert.ToInt32(numDamage.Value));
            }
            else if (lstAbilities.SelectedItem != null)
            {
                ChatboxMessages.CombatDamageAbility(lstActors.SelectedValue.ToString(), lblEffectedActor.Text, lstAbilities.SelectedItem.ToString(), chkSuccess.Checked, Convert.ToInt32(numDamage.Value));
            }
            else
            {
                ChatboxMessages.CombatDamageGeneral(lstActors.SelectedValue.ToString(), lblEffectedActor.Text, chkSuccess.Checked, Convert.ToInt32(numDamage.Value));
            }

            this.Parent.Hide();
        }

        private void lstWeapons_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstAbilities.SelectedIndex = -1;
        }

        private void lstAbilities_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstWeapons.SelectedIndex = -1;
        }
    }
}
