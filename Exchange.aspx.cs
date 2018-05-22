﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudService
{
    public partial class Exchange : System.Web.UI.Page
    {

        private int MarkedOnes;
        private int MarkedFives;
        private int MarkedTwentyFives;
        private int MarkedHundreds;
        private int MarkedTwoHundredFifties;



        protected void Page_Load(object sender, EventArgs e)
        {
            pricepercoin.Value = WebConfigurationManager.AppSettings["PricePerCoin"];
            GetCoinsCurrentlyMarkedForSale();
            LBLOnesAvailable.Text = MarkedOnes.ToString() + " in stock";
            LBLFivesAvailable.Text = MarkedFives.ToString() + " in stock";
            LBLTwentyFivesAvailable.Text = MarkedTwentyFives.ToString() + " in stock";
            LBLHundredsAvailable.Text = MarkedHundreds.ToString() + " in stock";
            LBLTwoHundredFiftiesAvailable.Text = MarkedTwoHundredFifties.ToString() + " in stock";

            int x = MarkedOnes;
            ListItem defaultItem = new ListItem("x0 = 0 CloudCoins", "0");
            DDLOnes.Items.Add(defaultItem);
            if (x > 0)
            {
                ListItem li = new ListItem("x1 = 1 CloudCoins", "1");
                DDLOnes.Items.Add(li);
            }
            if (x > 4)
            {
                for (int i = 5; i <= x; i = i + 5)
                {
                    ListItem li = new ListItem("x" + i.ToString() + " = " + i.ToString() + " CloudCoins", i.ToString());
                    DDLOnes.Items.Add(li);
                }
            }

            x = MarkedFives;
            DDLFives.Items.Add(defaultItem);
            if (x > 0)
            {
                ListItem li = new ListItem("x1 = 5 CloudCoins", "5");
                DDLFives.Items.Add(li);
            }
            if (x > 4)
            {
                for (int i = 5; i <= x; i = i + 5)
                {
                    int y = i * 5;
                    ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins", y.ToString());
                    DDLFives.Items.Add(li);
                }
            }

            x = MarkedTwentyFives;
            DDLTwentyFives.Items.Add(defaultItem);
            if (x > 0)
            {
                ListItem li = new ListItem("x1 = 25 CloudCoins", "25");
                DDLTwentyFives.Items.Add(li);
            }
            if (x > 4)
            {
                for (int i = 5; i <= x; i = i + 5)
                {
                    int y = i * 25;
                    ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins", y.ToString());
                    DDLTwentyFives.Items.Add(li);
                }
            }

            x = MarkedHundreds;
            DDLHundreds.Items.Add(defaultItem);
            if (x > 0)
            {
                ListItem li = new ListItem("x1 = 100 CloudCoins", "100");
                DDLHundreds.Items.Add(li);
            }
            if (x > 4)
            {
                for (int i = 5; i <= x; i = i + 5)
                {
                    int y = i * 100;
                    ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins", y.ToString());
                    DDLHundreds.Items.Add(li);
                }
            }

            x = MarkedTwoHundredFifties;
            DDLTwoHundredFifties.Items.Add(defaultItem);
            if (x > 0)
            {
                ListItem li = new ListItem("x1 = 250 CloudCoins", "250");
                DDLTwoHundredFifties.Items.Add(li);
            }
            if (x > 4)
            {
                for (int i = 5; i <= x; i = i + 5)
                {
                    int y = i * 250;
                    ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins", y.ToString());
                    DDLTwoHundredFifties.Items.Add(li);
                }
            }

        }

        void GetCoinsCurrentlyMarkedForSale()
        {
            string path = WebConfigurationManager.AppSettings["root"];
            string dir = HttpRuntime.AppDomainAppPath.ToString() + @"\" + path + @"\bank\";

            string filename;

            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                filename = Path.GetFileName(file);
                if (filename.Contains("forsale"))
                {
                    int index = filename.IndexOf(".");
                    string sub = filename.Substring(0, index);
                    if (sub == "1")
                        MarkedOnes = MarkedOnes + 1;
                    if (sub == "5")
                        MarkedFives = MarkedFives + 1;
                    if (sub == "25")
                        MarkedTwentyFives = MarkedTwentyFives + 1;
                    if (sub == "100")
                        MarkedHundreds = MarkedHundreds + 1;
                    if (sub == "250")
                        MarkedTwoHundredFifties = MarkedTwoHundredFifties + 1;
                }
            }
        }

        protected void BTNSubmitGreenPay_Click(object sender, EventArgs e)
        {
            int Ones = int.Parse(DDLOnes.SelectedValue);
            int Fives = int.Parse(DDLFives.SelectedValue);
            Fives = Fives / 5;
            int TwentyFives = int.Parse(DDLTwentyFives.SelectedValue);
            TwentyFives = TwentyFives / 25;
            int Hundreds = int.Parse(DDLHundreds.SelectedValue);
            Hundreds = Hundreds / 100;
            int TwoHundredFifties = int.Parse(DDLTwoHundredFifties.SelectedValue);
            TwoHundredFifties = TwoHundredFifties / 250;

            Response.Redirect("GreenPayOrder.aspx?Ones=" + Ones + "&Fives=" + Fives + "&TwentyFives=" + TwentyFives + "&Hundreds=" + Hundreds + "&TwoHundredFifties=" + TwoHundredFifties);
        }
    }
}