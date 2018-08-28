using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using Pen_and_Paper_Visualator.Controls;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Pen_and_Paper_Visualator.Class;
using System.Xml;
using System.Xml.XPath;

namespace Pen_and_Paper_Visualator.Class
{
    public class Resource_Init
    {
        public Resource_Init()
        {            
            //Discipline.DisciplineTable = new DataTable();
            //Discipline.DisciplineTable.Columns.Add("Name");
            //Discipline.DisciplineTable.Columns.Add("Level");
            //Discipline.DisciplineTable.Columns.Add("LevelName");
            //Discipline.DisciplineTable.Columns.Add("Action");
            //Discipline.DisciplineTable.Columns.Add("Attribute");
            //Discipline.DisciplineTable.Columns.Add("Skill");
            //Discipline.DisciplineTable.Columns.Add("Willpower_Cost");
            //Discipline.DisciplineTable.Columns.Add("Vitae_Cost");
            //Discipline.DisciplineTable.Columns.Add("Resist_Attribute");
            //Discipline.DisciplineTable.Columns.Add("Resist_Skill");
            //Discipline.DisciplineTable.Columns.Add("Description");
            //Discipline.DisciplineTable.Columns.Add("Image");

            Trait.TraitTable = new DataTable();
            Trait.TraitTable.Columns.Add("Name");
            Trait.TraitTable.Columns.Add("Type");
            Trait.TraitTable.Columns.Add("Cost");
            Trait.TraitTable.Columns.Add("Attribute");
            Trait.TraitTable.Columns.Add("Skill");
            Trait.TraitTable.Columns.Add("Bonus");
            Trait.TraitTable.Columns.Add("Automatic");
            Trait.TraitTable.Columns.Add("Description");

            Item.ItemTable = new DataTable();
            Item.ItemTable.Columns.Add("Name");
            Item.ItemTable.Columns.Add("Durability");
            Item.ItemTable.Columns.Add("Size");
            Item.ItemTable.Columns.Add("Cost");
            Item.ItemTable.Columns.Add("Structure");
            Item.ItemTable.Columns.Add("Image");
            Item.ItemTable.Columns.Add("Description");
            
            Weapon.WeaponTable = new DataTable();
            Weapon.WeaponTable.Columns.Add("Name");
            Weapon.WeaponTable.Columns.Add("Durability");
            Weapon.WeaponTable.Columns.Add("Range");
            Weapon.WeaponTable.Columns.Add("Size");
            Weapon.WeaponTable.Columns.Add("Damage");
            Weapon.WeaponTable.Columns.Add("Threat");
            Weapon.WeaponTable.Columns.Add("Requirement");
            Weapon.WeaponTable.Columns.Add("Material");
            Weapon.WeaponTable.Columns.Add("Cost");
            Weapon.WeaponTable.Columns.Add("Trained");
            Weapon.WeaponTable.Columns.Add("Structure");
            Weapon.WeaponTable.Columns.Add("Image");
            Weapon.WeaponTable.Columns.Add("Description");            

            Armor.ArmorTable = new DataTable();
            Armor.ArmorTable.Columns.Add("Name");
            Armor.ArmorTable.Columns.Add("General");
            Armor.ArmorTable.Columns.Add("Ballistic");
            Armor.ArmorTable.Columns.Add("Threat_Down");
            Armor.ArmorTable.Columns.Add("Requirement");
            Armor.ArmorTable.Columns.Add("Defense_Penalty");
            Armor.ArmorTable.Columns.Add("Speed_Penalty");
            Armor.ArmorTable.Columns.Add("Cost");
            Armor.ArmorTable.Columns.Add("Image");
            Armor.ArmorTable.Columns.Add("Description");

            XPathDocument lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Discipline.xml");
            XPathNavigator nav = lvCharXml.CreateNavigator();
            XPathNodeIterator nodeIter;

            //Populate Discipline table
            //nodeIter = nav.Select("Disciplines/Discipline");
            //while (nodeIter.MoveNext())
            //{
            //    XPathNodeIterator discIter = nav.Select("Disciplines/Discipline[@Name='" + nodeIter.Current.SelectSingleNode("@Name").Value + "']/Sub");
            //    while (discIter.MoveNext())
            //    {
            //        Discipline.DisciplineTable.Rows.Add(nodeIter.Current.SelectSingleNode("@Name").Value,
            //                                            discIter.Current.SelectSingleNode("@Level").Value,
            //                                            discIter.Current.SelectSingleNode("@LevelName").Value,
            //                                            discIter.Current.SelectSingleNode("Action").Value,
            //                                            discIter.Current.SelectSingleNode("Attribute").Value,
            //                                            discIter.Current.SelectSingleNode("Skill").Value,
            //                                            discIter.Current.SelectSingleNode("Willpower_Cost").Value,
            //                                            discIter.Current.SelectSingleNode("Vitae_Cost").Value,
            //                                            discIter.Current.SelectSingleNode("Resist_Attribute").Value,
            //                                            discIter.Current.SelectSingleNode("Resist_Skill").Value,
            //                                            discIter.Current.SelectSingleNode("Description").Value,
            //                                            nodeIter.Current.SelectSingleNode("@Image").Value);
            //    }
            //}

            //TODO
            //Populate Trait table
            //lvCharXml = new XPathDocument(Properties.Settings.Default.DataLocation + "Lists/Trait.xml");
            //nav = lvCharXml.CreateNavigator();
            //nodeIter = nav.Select("Traits/Trait");
            //while (nodeIter.MoveNext())
            //{
            //    Trait.TraitTable.Rows.Add(nodeIter.Current.SelectSingleNode("@Name").Value,
            //                              nodeIter.Current.SelectSingleNode("Type").Value,
            //                              nodeIter.Current.SelectSingleNode("Cost").Value,
            //                              nodeIter.Current.SelectSingleNode("Attributes/Attribute/Name").Value,
            //                              nodeIter.Current.SelectSingleNode("Skills/Skill/Name").Value,
            //                              nodeIter.Current.SelectSingleNode("Bonus").Value,
            //                              nodeIter.Current.SelectSingleNode("Automatic").Value,
            //                              nodeIter.Current.SelectSingleNode("Description").Value);
            //}

            //Populate Item table
            nodeIter = nav.Select("Items/Item[@Type='Item']");
            while (nodeIter.MoveNext())
            {
                Item.ItemTable.Rows.Add(nodeIter.Current.SelectSingleNode("@Name").Value,
                                        nodeIter.Current.SelectSingleNode("Durability").Value,
                                        nodeIter.Current.SelectSingleNode("Size").Value,
                                        nodeIter.Current.SelectSingleNode("Cost").Value,
                                        nodeIter.Current.SelectSingleNode("Structure").Value,
                                        nodeIter.Current.SelectSingleNode("Image").Value,
                                        nodeIter.Current.SelectSingleNode("Description").Value);
            }

            //Populate Weapon table
            nodeIter = nav.Select("Items/Item[@Type='Weapon']");
            while (nodeIter.MoveNext())
            {
                Weapon.WeaponTable.Rows.Add(nodeIter.Current.SelectSingleNode("@Name").Value,
                                            nodeIter.Current.SelectSingleNode("Durability").Value,
                                            nodeIter.Current.SelectSingleNode("Range").Value,
                                            nodeIter.Current.SelectSingleNode("Size").Value,
                                            nodeIter.Current.SelectSingleNode("Damage").Value,
                                            nodeIter.Current.SelectSingleNode("Threat").Value,
                                            nodeIter.Current.SelectSingleNode("Requirement").Value,
                                            nodeIter.Current.SelectSingleNode("Material").Value,
                                            nodeIter.Current.SelectSingleNode("Cost").Value,
                                            nodeIter.Current.SelectSingleNode("Trained").Value,
                                            nodeIter.Current.SelectSingleNode("Structure").Value,
                                            nodeIter.Current.SelectSingleNode("Image").Value,
                                            nodeIter.Current.SelectSingleNode("Description").Value);
            }

            //Populate Armor table
            nodeIter = nav.Select("Items/Item[@Type='Armor']");
            while (nodeIter.MoveNext())
            {
                Armor.ArmorTable.Rows.Add(nodeIter.Current.SelectSingleNode("@Name").Value,
                                          nodeIter.Current.SelectSingleNode("General").Value,
                                          nodeIter.Current.SelectSingleNode("Ballistic").Value,
                                          nodeIter.Current.SelectSingleNode("Threat_Down").Value,
                                          nodeIter.Current.SelectSingleNode("Requirement").Value,
                                          nodeIter.Current.SelectSingleNode("Defense_Penalty").Value,
                                          nodeIter.Current.SelectSingleNode("Speed_Penalty").Value,
                                          nodeIter.Current.SelectSingleNode("Durability").Value,
                                          nodeIter.Current.SelectSingleNode("Cost").Value,
                                          nodeIter.Current.SelectSingleNode("Image").Value,
                                          nodeIter.Current.SelectSingleNode("Description").Value);
            }           
        }
    }
}
