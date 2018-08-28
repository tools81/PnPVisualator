using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using Pen_and_Paper_Visualator.Controls;
using System.IO;
using System.Windows.Forms;
using Pen_and_Paper_Visualator.Class;
using System.Xml;
using System.Xml.XPath;
using System.Threading;
using System.Reflection;

namespace Pen_and_Paper_Visualator.Class
{
    class Character_Init
    {
        public Character_Init(string lvCharacterName)
        {
            string characterFile = String.Format("{0}.xml", lvCharacterName);

            FileSystemWatcher charWatcher = new FileSystemWatcher();
            charWatcher.Path = Global.CharacterFolder;
            charWatcher.NotifyFilter = NotifyFilters.LastWrite;
            charWatcher.Filter = characterFile;
            charWatcher.Changed += new FileSystemEventHandler(character_FileChanged);
            charWatcher.EnableRaisingEvents = true;

            var nav = PopulateCharacter(Global.CharacterFolder + characterFile);

            Global.AddActiveCharacter(nav.SelectSingleNode("Character/Background/Name").Value);
        }

        private XPathNavigator PopulateCharacter(string characterFile)
        {
            Player.Merit = new Dictionary<string, int>();
            Player.Flaw = new List<string>();
            Player.Equipment = new List<string>();
            Player.Weapon = new List<string>();
            Player.Armor = new List<string>();
            Player.Discipline = new Dictionary<string, int>();
            Player.Devotion = new List<string>();
            Player.Gift = new List<string>();
            Player.Rite = new List<string>();
            Player.Vehicle = new List<Guid>();
            Player.Specialize_Skill = new Dictionary<string, string>();
            Player.Devotion = new List<string>();
            Player.Arcana = new Dictionary<string, int>();
            Player.Rote = new Dictionary<string, string>();

            Player.Vehicle_Cargo = new List<Cargo>();

            while (IsFileLocked(characterFile))
                Thread.Sleep(1000);

            XPathDocument lvCharXml = new XPathDocument(characterFile);
            XPathNavigator nav = lvCharXml.CreateNavigator();
            XPathNodeIterator nodeIter;

            Player.Name = nav.SelectSingleNode("Character/Background/Name").Value;
            Player.PlayerName = nav.SelectSingleNode("Character/Background/Player").Value;
            Player.Template = (Global.Template)Enum.Parse(typeof(Global.Template), nav.SelectSingleNode("Character/Background/Type").Value);
            Player.Experience = Convert.ToInt32(nav.SelectSingleNode("Character/Background/Experience").Value);
            Player.Concept = nav.SelectSingleNode("Character/Background/Concept").Value;
            Player.Clan = nav.SelectSingleNode("Character/Background/Clan").Value;
            Player.Virtue = nav.SelectSingleNode("Character/Background/Virtue").Value;
            Player.Covenant = nav.SelectSingleNode("Character/Background/Covenant").Value;
            Player.Chronicle = nav.SelectSingleNode("Character/Background/Chronicle").Value;
            Player.Gender = (Global.Gender)Enum.Parse(typeof(Global.Gender), nav.SelectSingleNode("Character/Background/Gender").Value);
            Player.Vice = nav.SelectSingleNode("Character/Background/Vice").Value;
            Player.Coterie = nav.SelectSingleNode("Character/Background/Coterie").Value;
            Player.WillpowerMax = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Willpower/Max").Value);
            Player.WillpowerCurrent = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Willpower/Current").Value);
            Player.Humanity = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Humanity").Value);
            Player.Health = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Health/Max").Value);
            Player.Bash = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Health/Bash").Value);
            Player.Lethal = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Health/Lethal").Value);
            Player.Aggravated = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Health/Aggravated").Value);
            Player.Potency = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/BloodPotency").Value);
            Player.Vitae = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Vitae").Value);
            Player.Size = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Size").Value);
            Player.Defense = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Defense").Value);
            Player.Initiative = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Initiative").Value);
            Player.Speed = Convert.ToInt32(nav.SelectSingleNode("Character/Attributes/Speed").Value);
            Player.Intelligence = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Intelligence").Value);
            Player.Wits = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Wits").Value);
            Player.Resolve = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Resolve").Value);
            Player.Strength = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Strength").Value);
            Player.Dexterity = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Dexterity").Value);
            Player.Stamina = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Stamina").Value);
            Player.Presence = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Presence").Value);
            Player.Manipulation = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Manipulation").Value);
            Player.Composure = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Composure").Value);
            Player.Academics = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Academics").Value);
            Player.Computer = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Computer").Value);
            Player.Investigation = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Investigation").Value);
            Player.Medicine = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Medicine").Value);
            Player.Occult = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Occult").Value);
            Player.Politics = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Politics").Value);
            Player.Science = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Science").Value);
            Player.Athletics = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Athletics").Value);
            Player.Brawl = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Brawl").Value);
            Player.Drive = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Drive").Value);
            Player.Firearms = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Firearms").Value);
            Player.Stealth = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Stealth").Value);
            Player.Survival = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Survival").Value);
            Player.Weaponry = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Weaponry").Value);
            Player.AnimalKen = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/AnimalKen").Value);
            Player.Empathy = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Empathy").Value);
            Player.Intimidation = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Intimidation").Value);
            Player.Persuasion = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Persuasion").Value);
            Player.Socialize = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Socialize").Value);
            Player.Streetwise = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Streetwise").Value);
            Player.Subterfuge = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Subterfuge").Value);
            Player.Expression = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Expression").Value);
            Player.Larceny = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Larceny").Value);
            Player.Crafts = Convert.ToInt32(nav.SelectSingleNode("Character/Stats/Crafts").Value);
            Player.Image = nav.SelectSingleNode("Character/Image").Value;
            Player.Cash = Convert.ToInt32(nav.SelectSingleNode("Character/Equipment/Cash").Value);

            if (nav.SelectSingleNode("Character/Form") != null)
            {
                Player.Form = nav.SelectSingleNode("Character/Form").Value;
            }

            if (nav.SelectSingleNode("Character/Renown") != null)
            {
                Player.RenownPurity = nav.SelectSingleNode("Character/Renown/Purity").ValueAsInt;
                Player.RenownHonor = nav.SelectSingleNode("Character/Renown/Honor").ValueAsInt;
                Player.RenownGlory = nav.SelectSingleNode("Character/Renown/Glory").ValueAsInt;
                Player.RenownWisdom = nav.SelectSingleNode("Character/Renown/Wisdom").ValueAsInt;
                Player.RenownCunning = nav.SelectSingleNode("Character/Renown/Cunning").ValueAsInt;
            }

            nodeIter = nav.Select("Character/Merits/Merit");
            while (nodeIter.MoveNext())
            {
                Player.Merit.Add(nodeIter.Current.SelectSingleNode("@Name").Value, nodeIter.Current.SelectSingleNode("@Level").ValueAsInt);
            }

            nodeIter = nav.Select("Character/Flaws/Flaw/@Name");
            while (nodeIter.MoveNext())
            {
                Player.Flaw.Add(nodeIter.Current.Value);
            }

            nodeIter = nav.Select("Character/Equipment/Armors/Armor/@ID");
            while (nodeIter.MoveNext())
            {
                Player.Armor.Add(nodeIter.Current.Value);
            }

            nodeIter = nav.Select("Character/Equipment/Weapons/Weapon/@ID");
            while (nodeIter.MoveNext())
            {
                Player.Weapon.Add(nodeIter.Current.Value);
            }

            nodeIter = nav.Select("Character/Equipment/Items/Item/@ID");
            while (nodeIter.MoveNext())
            {
                Player.Equipment.Add(nodeIter.Current.Value);
            }

            nodeIter = nav.Select("Character/Disciplines/Discipline");
            while (nodeIter.MoveNext())
            {
                Player.Discipline.Add(nodeIter.Current.SelectSingleNode("@Name").Value, nodeIter.Current.SelectSingleNode("@Level").ValueAsInt);
            }

            nodeIter = nav.Select("Character/Devotions/Devotion");
            while(nodeIter.MoveNext())
            {
                Player.Devotion.Add(nodeIter.Current.Value);
            }

            nodeIter = nav.Select("Character/Gifts/Gift");
            while (nodeIter.MoveNext())
            {
                Player.Gift.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }

            nodeIter = nav.Select("Character/Rites/Rite");
            while (nodeIter.MoveNext())
            {
                Player.Rite.Add(nodeIter.Current.SelectSingleNode("@Name").Value);
            }

            XPathNavigator xNavArcana = nav.SelectSingleNode("Character/Arcana");
            if (xNavArcana != null)
            {
                nodeIter = nav.SelectSingleNode("Character/Arcana").SelectChildren(XPathNodeType.All);
                while (nodeIter.MoveNext())
                {
                    Player.Arcana.Add(nodeIter.Current.Name, nodeIter.Current.ValueAsInt);
                }
            }            

            nodeIter = nav.Select("Character/Rotes/Rote");
            while (nodeIter.MoveNext())
            {
                Player.Rote.Add(nodeIter.Current.SelectSingleNode("@Name").Value, nodeIter.Current.SelectSingleNode("@Arcana").Value);
            }

            nodeIter = nav.Select("Character/Vehicles/Vehicle/@ID");
            while (nodeIter.MoveNext())
            {
                Player.Vehicle.Add(new Guid(nodeIter.Current.Value));

                XPathNodeIterator cargoIter =
                    nav.Select("Character/Vehicles/Vehicle[@ID='" + nodeIter.Current.Value + "']/Cargo/Item");
                while (cargoIter.MoveNext())
                {
                    Cargo cargo = new Cargo(new Guid(nodeIter.Current.Value), new Guid(cargoIter.Current.SelectSingleNode("@ID").Value), cargoIter.Current.SelectSingleNode("@Type").Value, cargoIter.Current.Value);
                    Player.Vehicle_Cargo.Add(cargo);
                }
            }

            XPathNavigator navSpec = nav.SelectSingleNode("Character/Specializations");
            if (navSpec != null)
            {
                nodeIter = navSpec.SelectChildren(XPathNodeType.All);
                while (nodeIter.MoveNext())
                {
                    Player.Specialize_Skill.Add(nodeIter.Current.Value, nodeIter.Current.Name);
                }
            }

            AddBoosts();
            return nav;
        }

        private void AddBoosts()
        {
            XPathDocument xDoc = new XPathDocument(String.Format(Global.CharacterFolder + "{0}.xml", Player.Name));
            XPathNodeIterator xBoostIter = xDoc.CreateNavigator().SelectSingleNode("Character/Boost").SelectChildren(XPathNodeType.All);

            while (xBoostIter.MoveNext())
            {
                if (xBoostIter.Current.SelectSingleNode("@Realm").Value != "Action")
                {
                    foreach (PropertyInfo info in typeof(Player).GetProperties())
                    {
                        if (info.Name == xBoostIter.Current.Name)
                            info.SetValue(typeof(Player), Convert.ChangeType(Convert.ToInt32(info.GetValue(typeof(Player), null)) + xBoostIter.Current.ValueAsInt, info.PropertyType), null);
                    }
                }
            }
        }

        private void character_FileChanged(object sender, FileSystemEventArgs e)
        {
            var nav = PopulateCharacter(String.Format(Global.CharacterFolder + "{0}.xml", Player.Name));
            Global.PlayerForm.PopulateVisualator();
        }

        protected virtual bool IsFileLocked(string file)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }
    }
}
