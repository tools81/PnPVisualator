using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Controls.DisplayTypes;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class ReferenceTab : UserControl
    {
        public ReferenceTab()
        {
            InitializeComponent();

            XPathDocument xDoc = null;
            XPathNodeIterator xIter = null;

            PopulateNode(xDoc, xIter, Global.StatusXml, "Statuses/Status", treeReference.Nodes["nodeCharacterState"].Nodes["nodeStatuses"], "@Text");
            PopulateNode(xDoc, xIter, Global.ActionsXml, "Actions/Action", treeReference.Nodes["nodeActions"], "@Name");
            PopulateNode(xDoc, xIter, Global.DamageXml, "Damages/Damage", treeReference.Nodes["nodeCharacterState"].Nodes["nodeDamageTypes"], "@Name");
            PopulateNode(xDoc, xIter, Global.FormXml, "Forms/Werewolf/Form", treeReference.Nodes["nodeCharacterState"].Nodes["nodeForm"].Nodes["nodeFormWerewolf"], "@Name");
            PopulateNode(xDoc, xIter, Global.DerangementXml, "Derangements/Derangement", treeReference.Nodes["nodeCharacteristics"].Nodes["nodeDerangements"], "@Name");
            PopulateNode(xDoc, xIter, Global.FlawXml, "Flaws/Flaw", treeReference.Nodes["nodeCharacteristics"].Nodes["nodeFlaws"], "@Name");
            PopulateNode(xDoc, xIter, Global.MeritXml, "Merits/Merit", treeReference.Nodes["nodeCharacteristics"].Nodes["nodeMerits"], "@Name");
            PopulateNode(xDoc, xIter, Global.ViceXml, "Vices/Vice", treeReference.Nodes["nodeCharacteristics"].Nodes["nodeVices"], "@Name");
            PopulateNode(xDoc, xIter, Global.VirtueXml, "Virtues/Virtue", treeReference.Nodes["nodeCharacteristics"].Nodes["nodeVirtues"], "@Name");
            PopulateNode(xDoc, xIter, Global.RuleXml, "Rules/Rule", treeReference.Nodes["nodeRules"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='General']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaGeneral"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Death']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaDeath"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Fate']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaFate"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Forces']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaForces"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Life']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaLife"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Matter']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaMatter"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Mind']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaMind"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Prime']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaPrime"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Space']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaSpace"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Spirit']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaSpirit"], "@Name");
            PopulateNode(xDoc, xIter, Arcana.ArcanaXml, "Arcanum/Arcana[@Name='Time']/Rote", treeReference.Nodes["nodeAbilities"].Nodes["nodeArcana"].Nodes["nodeArcanaTime"], "@Name");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Animalism']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineAnimalism"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Auspex']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineAuspex"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Celerity']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineCelerity"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Dominate']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineDominate"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Majesty']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineMajesty"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Nightmare']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineNightmare"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Obfuscate']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineObfuscate"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Protean']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineProtean"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Resilience']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineResilience"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Vigor']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineVigor"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Crúac']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineCrúac"], "@LevelName");
            PopulateNode(xDoc, xIter, Discipline.DisciplineXml, "Disciplines/Discipline[@Name='Theban Sorcery']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeDisciplines"].Nodes["nodeDisciplineThebanSorcery"], "@LevelName");
            PopulateNode(xDoc, xIter, Devotion.DevotionXml, "Devotions/Devotion", treeReference.Nodes["nodeAbilities"].Nodes["nodeDevotions"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Crescent Moon']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftCrescentMoon"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Death']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftDeath"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Dominance']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftDominance"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Elemental']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftElemental"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Evasion']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftEvasion"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Father Wolf']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftFatherWolf"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Full Moon']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftFullMoon"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Gibbous Moon']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftGibbousMoon"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Half Moon']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftHalfMoon"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Insight']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftInsight"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Inspiration']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftInspiration"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Knowledge']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftKnowledge"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Mother Luna']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftMotherLuna"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Nature']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftNature"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='New Moon']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftNewMoon"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Rage']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftRage"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Shaping']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftShaping"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Stealth']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftStealth"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Strength']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftStrength"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Technology']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftTechnology"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Warding']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftWarding"], "@Name");
            PopulateNode(xDoc, xIter, Gift.GiftXml, "Gifts/Gift[@Name='Weather']/Sub", treeReference.Nodes["nodeAbilities"].Nodes["nodeGifts"].Nodes["nodeGiftWeather"], "@Name");
            PopulateNode(xDoc, xIter, Profession.ProfessionXml, "Professions/Profession", treeReference.Nodes["nodeAbilities"].Nodes["nodeProfessions"], "@Name");
            PopulateNode(xDoc, xIter, Rite.RiteXml, "Rites/Rite", treeReference.Nodes["nodeAbilities"].Nodes["nodeRites"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Envy']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentEnvy"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Gluttony']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentGluttony"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Greed']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentGreed"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Lust']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentLust"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Pride']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentPride"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Sloth']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentSloth"], "@Name");
            PopulateNode(xDoc, xIter, Vestment.VestmentXml, "Vestments/Vice[@Name='Wrath']//Vestment", treeReference.Nodes["nodeAbilities"].Nodes["nodeVestments"].Nodes["nodeVestmentWrath"], "@Name");
        }

        private void PopulateNode(XPathDocument xDoc, XPathNodeIterator xIter, string xmlPath, string xmlNav, TreeNode node, string attrName)
        {
            xDoc = new XPathDocument(xmlPath);
            xIter = xDoc.CreateNavigator().Select(xmlNav);

            while (xIter.MoveNext())
            {
                TreeNode tNode = new TreeNode(xIter.Current.SelectSingleNode(attrName).ToString());
                tNode.Name = "node" + tNode.Text.Replace(" ", "");
                node.Nodes.Add(tNode);
            }
        }

        private void treeReference_AfterSelect(object sender, TreeViewEventArgs e)
        {
            XPathDocument xDoc;
            XPathNavigator xNav = null;
            bool descriptionOnly = false;

            if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Name)
                {
                    case "nodeStatuses":
                        xDoc = new XPathDocument(Global.StatusXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Statuses/Status[@Text=\"{e.Node.Text}\"]");
                        break;
                    case "nodeActions":
                        xDoc = new XPathDocument(Global.ActionsXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Actions/Action[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDamageTypes":
                        xDoc = new XPathDocument(Global.DamageXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Damages/Damage[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeFormWerewolf":
                        xDoc = new XPathDocument(Global.FormXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Forms/Werewolf/Form[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDerangements":
                        xDoc = new XPathDocument(Global.DerangementXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Derangements/Derangement[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeFlaws":
                        xDoc = new XPathDocument(Global.FlawXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Flaws/Flaw[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeMerits":
                        xDoc = new XPathDocument(Global.MeritXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Merits/Merit[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVices":
                        xDoc = new XPathDocument(Global.ViceXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vices/Vice[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVirtues":
                        xDoc = new XPathDocument(Global.VirtueXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Virtues/Virtue[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeRules":
                        xDoc = new XPathDocument(Global.RuleXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Rules/Rule[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcana":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name=\"{e.Node.Text}\"]");
                        descriptionOnly = true;
                        break;
                    case "nodeArcanaGeneral":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='General']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaDeath":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Death']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaFate":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Fate']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaForces":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Forces']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaLife":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Life']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaMatter":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Matter']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaMind":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Mind']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaPrime":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Prime']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaSpace":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Space']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaSpirit":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Spirit']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeArcanaTime":
                        xDoc = new XPathDocument(Arcana.ArcanaXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Arcanum/Arcana[@Name='Time']/Rote[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplines":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name=\"{e.Node.Text}\"]");
                        descriptionOnly = true;
                        break;
                    case "nodeDisciplineAnimalism":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Animalism']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineAuspex":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Auspex']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineCelerity":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Celerity']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineDominate":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Dominate']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineMajesty":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Majesty']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineNightmare":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Nightmare']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineObfuscate":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Obfuscate']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineProtean":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Protean']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineResilience":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Resilience']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineVigor":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Vigor']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineCrúac":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Crúac']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDisciplineThebanSorcery":
                        xDoc = new XPathDocument(Discipline.DisciplineXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Disciplines/Discipline[@Name='Theban Sorcery']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeDevotions":
                        xDoc = new XPathDocument(Devotion.DevotionXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Devotions/Devotion[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGifts":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name=\"{e.Node.Text}\"]");
                        descriptionOnly = true;
                        break;
                    case "nodeGiftCrescentMoon":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Crescent Moon']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftDeath":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Death']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftDominance":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Dominance']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftElemental":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Elemental']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftEvasion":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Evasion']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftFatherWolf":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Father Wolf']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftFullMoon":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Full Moon']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftGibbousMoon":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Gibbouls Moon']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftHalfMoon":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Half Moon']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftInsight":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Insight']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftInspiration":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Inspiration']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftKnowledge":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Knowledge']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftMotherLuna":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Mother Luna']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftNature":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Nature']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftNewMoon":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='New Moon']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftRage":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Rage']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftShaping":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Shaping']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftStealth":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Stealth']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftStrength":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Strength']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftTechnology":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Technology']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftWarding":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Warding']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeGiftWeather":
                        xDoc = new XPathDocument(Gift.GiftXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Gifts/Gift[@Name='Weather']/Sub[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeProfessions":
                        xDoc = new XPathDocument(Profession.ProfessionXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Professions/Profession[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeRites":
                        xDoc = new XPathDocument(Rite.RiteXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Rites/Rite[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestments":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vesments/Vice[@Name=\"{e.Node.Text}\"]");
                        descriptionOnly = true;
                        break;
                    case "nodeVestmentEnvy":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Envy']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentGluttony":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Gluttony']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentGreed":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Greed']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentLust":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Lust']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentPride":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Pride']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentSloth":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Sloth']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    case "nodeVestmentWrath":
                        xDoc = new XPathDocument(Vestment.VestmentXml);
                        xNav = xDoc.CreateNavigator().SelectSingleNode($"Vestments/Vice[@Name='Wrath']//Vestment[@Name=\"{e.Node.Text}\"]");
                        break;
                    default:
                        return;
                }
            }
            else
            {
                return;
            }            

            string rtf = RtfHelper.Begin();
            RtfHelper.Bold(ref rtf, xNav.SelectSingleNode("@Name").Value);
            RtfHelper.EndLine(ref rtf);

            XPathNodeIterator nodeIter = xNav.SelectChildren(XPathNodeType.All);

            while(nodeIter.MoveNext())
            {
                if (nodeIter.Current.Name == "Image")
                    continue;

                RtfHelper.EndLine(ref rtf);
                RtfHelper.Bold(ref rtf, nodeIter.Current.Name + ": ");

                XPathNodeIterator xChildIter = nodeIter.Current.SelectChildren(XPathNodeType.Element);

                if (xChildIter.Count > 0)
                {
                    while(xChildIter.MoveNext())
                    {
                        RtfHelper.EndLine(ref rtf);
                        RtfHelper.ConvertText(ref rtf, xChildIter.Current.Name + " | ");
                        RtfHelper.ConvertText(ref rtf, xChildIter.Current.Value);
                        if (xChildIter.Current.SelectSingleNode("@Value") != null)
                        {
                            RtfHelper.ConvertText(ref rtf, $" [{xChildIter.Current.SelectSingleNode("@Value").Value}]");
                        }
                    }
                }
                else if (descriptionOnly)
                {
                    if (nodeIter.Current.SelectSingleNode("Description") != null)
                    {
                        RtfHelper.EndLine(ref rtf);
                        RtfHelper.Bold(ref rtf, "Description: ");
                        RtfHelper.ConvertText(ref rtf, nodeIter.Current.SelectSingleNode("Description").Value);
                    }                   
                }
                else
                {
                    RtfHelper.ConvertText(ref rtf, nodeIter.Current.Value);
                }                
                RtfHelper.EndLine(ref rtf);
            }

            RtfHelper.End(ref rtf);
            RtfDisplay.Description = rtf;


            RtfDisplay iDisplay = new RtfDisplay();
            GMForm.setPanelSelectedItem(iDisplay);
        }
    }
}
