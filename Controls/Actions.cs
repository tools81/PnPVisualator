using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;
using Pen_and_Paper_Visualator.Class;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class Actions : UserControl
    {
        private List<int> cvSelected = new List<int>(); 
        private int cvActionControlHeight = 268;

        public Actions()
        {
            InitializeComponent();

            XPathDocument xDoc = new XPathDocument(Global.ActionsXml);
            XPathNavigator xNav = xDoc.CreateNavigator();
            XPathExpression exp = xNav.Compile("Actions/Action");
            exp.AddSort("@Name", XmlSortOrder.Ascending, XmlCaseOrder.UpperFirst, "en-US", XmlDataType.Text);
            XPathNodeIterator xNodeIter = xNav.Select(exp);
            int xId = 1;
            int xHgt = 2;
            Player p = new Player();

            while (xNodeIter.MoveNext())
            {
                Button xButton = new Button();
                xButton.Name = xId.ToString();
                xButton.Text = xNodeIter.Current.SelectSingleNode("@Name").Value;
                xButton.Width = 268;
                xButton.Top = xHgt;
                xButton.BackColor = Color.DarkSlateBlue;
                xButton.ForeColor = Color.White;

                xButton.Click += ActionButton_Clicked;

                ActionDisplay.Data = new DataTable();
                ActionDisplay.Data.Columns.Add("Origin");
                ActionDisplay.Data.Columns.Add("Parameter");
                ActionDisplay.Data.Columns.Add("Value");                 

                //Attributes
                XPathNodeIterator xAttrIter = xNodeIter.Current.Select("Attribute");
                while (xAttrIter.MoveNext())
                {
                    DataRow dr = ActionDisplay.Data.NewRow();
                    dr[0] = "Attribute";
                    dr[1] = xAttrIter.Current.Value;
                    dr[2] = p[xAttrIter.Current.Value.Replace(" ", "")];

                    ActionDisplay.Data.Rows.Add(dr);
                }

                //Skills
                XPathNodeIterator xSkillIter = xNodeIter.Current.Select("Skill");
                while (xSkillIter.MoveNext())
                {
                    DataRow dr = ActionDisplay.Data.NewRow();
                    dr[0] = "Skill";
                    dr[1] = xSkillIter.Current.Value;
                    dr[2] = p[xSkillIter.Current.Value.Replace(" ", "")];

                    ActionDisplay.Data.Rows.Add(dr);
                }

                //Stats
                XPathNodeIterator xStatIter = xNodeIter.Current.Select("Stats");
                while (xStatIter.MoveNext())
                {
                    DataRow dr = ActionDisplay.Data.NewRow();
                    dr[0] = "Stat";
                    dr[1] = xStatIter.Current.Value;
                    dr[2] = p[xStatIter.Current.Value.Replace(" ", "")];

                    ActionDisplay.Data.Rows.Add(dr);
                }

                //Boosts
                XPathDocument xPlayerDoc = new XPathDocument(Global.CharacterFolder + Player.Name + ".xml");
                XPathNodeIterator xBoostNodeIter = xPlayerDoc.CreateNavigator().Select(String.Format("Character/Boost/{0}", xNodeIter.Current.SelectSingleNode("@Name").Value.Replace(" ", "")));

                if (xBoostNodeIter != null)
                {
                    while (xBoostNodeIter.MoveNext())
                    {
                        DataRow dr = ActionDisplay.Data.NewRow();
                        dr[0] = "Bonus";
                        dr[1] = xBoostNodeIter.Current.SelectSingleNode("@Source").Value;
                        dr[2] = xBoostNodeIter.Current.Value;

                        ActionDisplay.Data.Rows.Add(dr);
                    }
                }

                ActionDisplay.Contested = new DataTable();
                ActionDisplay.Contested.Columns.Add("Contested");
                ActionDisplay.Contested.Columns.Add("Origin");
                ActionDisplay.Contested.Columns.Add("Parameter");

                XPathNavigator xContestNav = xNodeIter.Current.SelectSingleNode("Contest");

                if (xContestNav != null)
                {
                    //Attributes
                    XPathNodeIterator xContAttrIter = xContestNav.Select("Attribute");
                    while (xContAttrIter.MoveNext())
                    {
                        DataRow dr = ActionDisplay.Contested.NewRow();
                        dr[0] = "";
                        dr[1] = "Attribute";
                        dr[2] = xContAttrIter.Current.Value;

                        ActionDisplay.Contested.Rows.Add(dr);
                    }

                    //Skills
                    XPathNodeIterator xContSkillIter = xContestNav.Select("Skill");
                    while (xContSkillIter.MoveNext())
                    {
                        DataRow dr = ActionDisplay.Contested.NewRow();
                        dr[0] = "";
                        dr[1] = "Skill";
                        dr[2] = xContSkillIter.Current.Value;

                        ActionDisplay.Contested.Rows.Add(dr);
                    }

                    //Stats
                    XPathNodeIterator xContStatIter = xContestNav.Select("Stats");
                    while (xContStatIter.MoveNext())
                    {
                        DataRow dr = ActionDisplay.Contested.NewRow();
                        dr[0] = "";
                        dr[1] = "Stat";
                        dr[2] = xContStatIter.Current.Value;

                        ActionDisplay.Contested.Rows.Add(dr);
                    }
                }               

                ActionDisplay.ActionName = xButton.Text;
                ActionDisplay.Extended = xNodeIter.Current.SelectSingleNode("Extended") != null ? xNodeIter.Current.SelectSingleNode("Extended").Value : String.Empty;
                ActionDisplay.Success = xNodeIter.Current.SelectSingleNode("Success") != null ? xNodeIter.Current.SelectSingleNode("Success").Value : String.Empty;
                ActionDisplay aDisplay = new ActionDisplay();
                this.Controls.Add(aDisplay);
                aDisplay.Name = "Action" + xId.ToString();
                aDisplay.Top = xButton.Top + 20;
                aDisplay.Visible = false;

                this.Controls.Add(xButton);
                this.Controls.Add(aDisplay);
                xId++;
                xHgt += 25;
            }
        }

        private void ActionButton_Clicked(object sender, EventArgs e)
        {
            if (cvSelected.Contains(Convert.ToInt32(((Button) sender).Name)))
            {
                this.Controls.Find("Action" + ((Button) sender).Name, true)[0].Visible = false;

                foreach (Control lvControl in this.Controls)
                {
                    if (lvControl is Button && Convert.ToInt32(lvControl.Name) > Convert.ToInt32(((Button)sender).Name))
                    {
                        lvControl.Top -= cvActionControlHeight;
                    }
                    else if (lvControl is ActionDisplay && Convert.ToInt32(lvControl.Name.Replace("Action", "")) >
                             Convert.ToInt32(((Button)sender).Name))
                    {
                        lvControl.Top -= cvActionControlHeight;
                    }
                }

                cvSelected.Remove(Convert.ToInt32(((Button) sender).Name));
            }
            else
            {
                cvSelected.Add(Convert.ToInt32(((Button)sender).Name));

                this.Controls.Find("Action" + ((Button) sender).Name, true)[0].Visible = true;

                foreach (Control lvControl in this.Controls)
                {
                    if (lvControl is Button && Convert.ToInt32(lvControl.Name) > Convert.ToInt32(((Button)sender).Name))
                    {
                        lvControl.Top += cvActionControlHeight;
                    }
                    else if (lvControl is ActionDisplay && Convert.ToInt32(lvControl.Name.Replace("Action", "")) >
                             Convert.ToInt32(((Button)sender).Name))
                    {
                        lvControl.Top += cvActionControlHeight;
                    }
                }
            }                       
        }
    }
}
