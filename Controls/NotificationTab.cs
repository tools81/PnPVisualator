using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Pen_and_Paper_Visualator.Class;
using System.Xml.XPath;
using System.IO;
using System.Threading;

namespace Pen_and_Paper_Visualator.Controls
{
    public partial class NotificationTab : UserControl
    {
        XPathDocument _notificationDoc = new XPathDocument(Global.NotificationXml);
        NumericUpDown numValue;
        private const string _acceptButtonPrefix = "btnAccept";
        private const string _cancelButtonPrefix = "btnCancel";
        private const string _numericPrefix = "num";
        private const string _75ButtonPrefix = "btn75";
        private const string _50ButtonPrefix = "btn50";
        private const string _25ButtonPrefix = "btn25";
        Button btnAccept;
        Button btnCancel;
        Button btn75;
        Button btn50;
        Button btn25;
        FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");

        public NotificationTab()
        {
            InitializeComponent();

            XPathNodeIterator xNodeIter = _notificationDoc.CreateNavigator().Select("Notifications/*");            

            while (xNodeIter.MoveNext())
            {
                switch (xNodeIter.Current.Name)
                {
                    case "RequestPurchase":
                        TextBox txtBuy = new TextBox();
                        txtBuy.Text = xNodeIter.Current.SelectSingleNode("Message").Value;
                        txtBuy.Width = 280;
                        txtBuy.Multiline = true;
                        txtBuy.Height = 50;
                        txtBuy.Enabled = false;
                        txtBuy.BackColor = Color.Beige;
                        pnlNotifications.Controls.Add(txtBuy);

                        numValue = new NumericUpDown();
                        numValue.Minimum = 1;
                        numValue.Maximum = 1000000;
                        numValue.Value = Convert.ToDecimal(xNodeIter.Current.SelectSingleNode("@Cost").ValueAsInt);
                        numValue.Name = _numericPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        numValue.Width = 55;
                        pnlNotifications.Controls.Add(numValue);

                        btn75 = new Button();
                        btn75.Text = "75%";
                        btn75.Name = _75ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn75.BackColor = Color.LightCyan;
                        btn75.Width = 30;
                        btn75.Click += btn75_Clicked;
                        pnlNotifications.Controls.Add(btn75);

                        btn50 = new Button();
                        btn50.Text = "50%";
                        btn50.Name = _50ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn50.BackColor = Color.LightCyan;
                        btn50.Width = 30;
                        btn50.Click += btn50_Clicked;
                        pnlNotifications.Controls.Add(btn50);

                        btn25 = new Button();
                        btn25.Text = "25%";
                        btn25.Name = _25ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn25.BackColor = Color.LightCyan;
                        btn25.Width = 30;
                        btn25.Click += btn25_Clicked;
                        pnlNotifications.Controls.Add(btn25);

                        btnAccept = new Button();
                        btnAccept.Text = "Accept";
                        btnAccept.Name = _acceptButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btnAccept.BackColor = Color.LightBlue;
                        btnAccept.Width = 48;
                        btnAccept.Click += Buy_Clicked;
                        pnlNotifications.Controls.Add(btnAccept);

                        btnCancel = new Button();
                        btnCancel.Text = "Cancel";
                        btnCancel.Name = _cancelButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btnCancel.BackColor = Color.IndianRed;
                        btnCancel.Width = 48;
                        btnCancel.Click += Cancel_Clicked;
                        pnlNotifications.Controls.Add(btnCancel);

                        btn75.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btn50.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btn25.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btnAccept.Font = new Font(fontFamily, 7.0f, FontStyle.Regular);
                        btnCancel.Font = new Font(fontFamily, 7.0f, FontStyle.Regular);
                        break;
                    case "RequestSell":
                        TextBox txtSell = new TextBox();
                        txtSell.Text = xNodeIter.Current.SelectSingleNode("Message").Value;
                        txtSell.Width = 280;
                        txtSell.Multiline = true;
                        txtSell.Height = 50;
                        txtSell.Enabled = false;
                        txtSell.BackColor = Color.Khaki;
                        pnlNotifications.Controls.Add(txtSell);

                        numValue = new NumericUpDown();
                        numValue.Minimum = 1;
                        numValue.Maximum = 1000000;
                        numValue.Value = Convert.ToDecimal(xNodeIter.Current.SelectSingleNode("@Cost").ValueAsInt);
                        numValue.Name = _numericPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        numValue.Width = 60;
                        pnlNotifications.Controls.Add(numValue);

                        btn75 = new Button();
                        btn75.Text = "75%";
                        btn75.Name = _75ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn75.BackColor = Color.LightCyan;
                        btn75.Width = 30;
                        btn75.Click += btn75_Clicked;
                        pnlNotifications.Controls.Add(btn75);

                        btn50 = new Button();
                        btn50.Text = "50%";
                        btn50.Name = _50ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn50.BackColor = Color.LightCyan;
                        btn50.Width = 30;
                        btn50.Click += btn50_Clicked;
                        pnlNotifications.Controls.Add(btn50);

                        btn25 = new Button();
                        btn25.Text = "25%";
                        btn25.Name = _25ButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btn25.BackColor = Color.LightCyan;
                        btn25.Width = 30;
                        btn25.Click += btn25_Clicked;
                        pnlNotifications.Controls.Add(btn25);

                        btnAccept = new Button();
                        btnAccept.Text = "Accept";
                        btnAccept.Name = _acceptButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btnAccept.BackColor = Color.LightBlue;
                        btnAccept.Width = 48;
                        btnAccept.Click += Sell_Clicked;
                        pnlNotifications.Controls.Add(btnAccept);

                        btnCancel = new Button();
                        btnCancel.Text = "Cancel";
                        btnCancel.Name = _cancelButtonPrefix + xNodeIter.Current.SelectSingleNode("@ID").Value;
                        btnCancel.BackColor = Color.IndianRed;
                        btnCancel.Width = 48;
                        btnCancel.Click += Cancel_Clicked;
                        pnlNotifications.Controls.Add(btnCancel);

                        btn75.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btn50.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btn25.Font = new Font(fontFamily, 6.0f, FontStyle.Regular);
                        btnAccept.Font = new Font(fontFamily, 7.0f, FontStyle.Regular);
                        btnCancel.Font = new Font(fontFamily, 7.0f, FontStyle.Regular);
                        break;
                    default:
                        break;
                }
                pnlNotifications.SetFlowBreak(btnCancel, true);
            }
        }

        private void btn75_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_75ButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);
            num.Value = Math.Round(num.Value * Convert.ToDecimal(0.75));
            num.Refresh();
        }

        private void btn50_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_50ButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);
            num.Value = Math.Round(num.Value * Convert.ToDecimal(0.5));
            num.Refresh();
        }

        private void btn25_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_25ButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);
            num.Value = Math.Round(num.Value * Convert.ToDecimal(0.25));
            num.Refresh();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_cancelButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.NotificationXml);

            XPathNodeIterator xNodeIter = xDoc.CreateNavigator().SelectSingleNode("Notifications").SelectChildren(XPathNodeType.All);

            while (xNodeIter.MoveNext())
            {
                if (xNodeIter.Current.SelectSingleNode("@ID") != null && xNodeIter.Current.SelectSingleNode("@ID").Value == id)
                {
                    xNodeIter.Current.DeleteSelf();
                    break;           
                }
            }            

            while (Global.IsFileLocked(Global.NotificationXml))
                Thread.Sleep(1000);
            FileStream lvFS = new FileStream(Global.NotificationXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private void Buy_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_acceptButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.NotificationXml);

            XPathNavigator xNotifNav = xDoc.CreateNavigator().SelectSingleNode(String.Format("Notifications/RequestPurchase[@ID='{0}']", id));

            CharacterUpdate.AddItemToCharacter(xNotifNav.SelectSingleNode("@Item").Value, xNotifNav.SelectSingleNode("@Type").Value, id, xNotifNav.SelectSingleNode("@Character").Value);
            CharacterUpdate.AddItemToCharacter(null, "Cash", null, xNotifNav.SelectSingleNode("@Character").Value, Convert.ToInt32(num.Value)*-1);

            xNotifNav.DeleteSelf();

            while (Global.IsFileLocked(Global.NotificationXml))
                Thread.Sleep(1000);
            FileStream lvFS = new FileStream(Global.NotificationXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }

        private void Sell_Clicked(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string id = btn.Name.Replace(_acceptButtonPrefix, String.Empty);

            Control ctrl = pnlNotifications.Controls.Find(_numericPrefix + id, true)[0];
            NumericUpDown num = ((NumericUpDown)ctrl);

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Global.NotificationXml);

            XPathNavigator xNotifNav = xDoc.CreateNavigator().SelectSingleNode(String.Format("Notifications/RequestSell[@ID='{0}']", id));

            CharacterUpdate.RemoveItemFromCharacter(xNotifNav.SelectSingleNode("@Item").Value, id, xNotifNav.SelectSingleNode("@Character").Value);
            CharacterUpdate.AddItemToCharacter(null, "Cash", null, xNotifNav.SelectSingleNode("@Character").Value, Convert.ToInt32(num.Value));

            xNotifNav.DeleteSelf();

            while (Global.IsFileLocked(Global.NotificationXml))
                Thread.Sleep(1000);
            FileStream lvFS = new FileStream(Global.NotificationXml, FileMode.Truncate, FileAccess.Write, FileShare.ReadWrite);
            xDoc.Save(lvFS);
            lvFS.Close();
        }
    }
}
