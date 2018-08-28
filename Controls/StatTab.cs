using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class frmStats : UserControl
    {
        public frmStats()
        {
            InitializeComponent();

            rdoIntelligence.AbilityRank = Player.Intelligence;
            rdoWits.AbilityRank = Player.Wits;
            rdoResolve.AbilityRank = Player.Resolve;
            rdoStrength.AbilityRank = Player.Strength;
            rdoDexterity.AbilityRank = Player.Dexterity;
            rdoStamina.AbilityRank = Player.Stamina;
            rdoPresence.AbilityRank = Player.Presence;
            rdoManipulation.AbilityRank = Player.Manipulation;
            rdoComposure.AbilityRank = Player.Composure;
            rdoAcademics.AbilityRank = Player.Academics;
            rdoComputer.AbilityRank = Player.Computer;
            rdoInvestigation.AbilityRank = Player.Investigation;
            rdoMedicine.AbilityRank = Player.Medicine;
            rdoOccult.AbilityRank = Player.Occult;
            rdoPolitics.AbilityRank = Player.Politics;
            rdoScience.AbilityRank = Player.Science;
            rdoAthletics.AbilityRank = Player.Athletics;
            rdoBrawl.AbilityRank = Player.Brawl;
            rdoDrive.AbilityRank = Player.Drive;
            rdoFirearms.AbilityRank = Player.Firearms;
            rdoStealth.AbilityRank = Player.Stealth;
            rdoSurvival.AbilityRank = Player.Survival;
            rdoWeaponry.AbilityRank = Player.Weaponry;
            rdoAnimalKen.AbilityRank = Player.AnimalKen;
            rdoEmpathy.AbilityRank = Player.Empathy;
            rdoIntimidation.AbilityRank = Player.Intimidation;
            rdoPersuasion.AbilityRank = Player.Persuasion;
            rdoSocialize.AbilityRank = Player.Socialize;
            rdoStreetwise.AbilityRank = Player.Streetwise;
            rdoSubterfuge.AbilityRank = Player.Subterfuge;
            rdoExpression.AbilityRank = Player.Expression;
            rdoLarceny.AbilityRank = Player.Larceny;
            rdoCrafts.AbilityRank = Player.Crafts;

            ToolTip tip = new ToolTip();
            string lvSkill = null;
            string lvfullDesc = string.Empty;

            foreach (var pair in Player.Specialize_Skill)
            {
                if (lvSkill == pair.Value)
                {
                    lvfullDesc += Environment.NewLine + pair.Key;
                    tip.SetToolTip(this.Controls.Find("pbx" + lvSkill, true)[0], lvfullDesc);
                }
                else
                {
                    tip = new ToolTip();
                    lvfullDesc = pair.Key;
                    tip.SetToolTip(this.Controls.Find("pbx" + pair.Value, true)[0], pair.Key);
                    lvSkill = pair.Value;
                    this.Controls.Find("pbx" + lvSkill, true)[0].Visible = true;
                }
            }
        }

    }
}
