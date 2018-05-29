using System;
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
            LBLCurrentPrice.Text = "Current Price Per Coin: $" + WebConfigurationManager.AppSettings["PricePerCoin"];
            GetCoinsCurrentlyMarkedForSale();
            LBLOnesAvailable.Text = MarkedOnes.ToString() + " in stock";
            LBLFivesAvailable.Text = MarkedFives.ToString() + " in stock";
            LBLTwentyFivesAvailable.Text = MarkedTwentyFives.ToString() + " in stock";
            LBLHundredsAvailable.Text = MarkedHundreds.ToString() + " in stock";
            LBLTwoHundredFiftiesAvailable.Text = MarkedTwoHundredFifties.ToString() + " in stock";



            double ppc = double.Parse(WebConfigurationManager.AppSettings["PricePerCoin"]);
            double price = 0.00;
            int x = MarkedOnes;
            if (DDLOnes.Items.Count == 0)
            {
                ListItem defaultItem = new ListItem("", "0");

                DDLOnes.Items.Add(defaultItem);
                if (x > 0)
                {
                    price = 1 * ppc;
                    ListItem li = new ListItem("x1 = 1 CloudCoins " + "($" + price.ToString() + ")", "1");
                    DDLOnes.Items.Add(li);
                }
                if (x > 4)
                {
                    for (int i = 5; i <= x; i = i + 5)
                    {
                        price = i * ppc;
                        ListItem li = new ListItem("x" + i.ToString() + " = " + i.ToString() + " CloudCoins " + "($" + price.ToString() + ")", i.ToString());
                        DDLOnes.Items.Add(li);
                    }
                }

                x = MarkedFives;
                DDLFives.Items.Add(defaultItem);
                if (x > 0)
                {
                    price = 5 * ppc;
                    ListItem li = new ListItem("x5 = 5 CloudCoins " + "($" + price.ToString() + ")", "5");
                    DDLFives.Items.Add(li);
                }
                if (x > 4)
                {
                    for (int i = 5; i <= x; i = i + 5)
                    {

                        int y = i * 5;
                        price = y * ppc;
                        ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins " + "($" + price.ToString() + ")", y.ToString());
                        DDLFives.Items.Add(li);
                    }
                }

                x = MarkedTwentyFives;
                DDLTwentyFives.Items.Add(defaultItem);
                if (x > 0)
                {
                    price = 25 * ppc;
                    ListItem li = new ListItem("x1 = 25 CloudCoins " + "($" + price.ToString() + ")", "25");
                    DDLTwentyFives.Items.Add(li);
                }
                if (x > 4)
                {
                    for (int i = 5; i <= x; i = i + 5)
                    {
                        int y = i * 25;
                        price = y * ppc;
                        ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins " + "($" + price.ToString() + ")", y.ToString());
                        DDLTwentyFives.Items.Add(li);
                    }
                }

                x = MarkedHundreds;
                DDLHundreds.Items.Add(defaultItem);
                if (x > 0)
                {
                    price = 100 * ppc;
                    ListItem li = new ListItem("x1 = 100 CloudCoins " + "($" + price.ToString() + ")", "100");
                    DDLHundreds.Items.Add(li);
                }
                if (x > 4)
                {
                    for (int i = 5; i <= x; i = i + 5)
                    {
                        int y = i * 100;
                        price = y * ppc;
                        ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins " + "($" + price.ToString() + ")", y.ToString());
                        DDLHundreds.Items.Add(li);
                    }
                }

                x = MarkedTwoHundredFifties;
                DDLTwoHundredFifties.Items.Add(defaultItem);
                if (x > 0)
                {
                    price = 250 * ppc;
                    ListItem li = new ListItem("x1 = 250 CloudCoins " + "($" + price.ToString() + ")", "250");
                    DDLTwoHundredFifties.Items.Add(li);
                }
                if (x > 4)
                {
                    for (int i = 5; i <= x; i = i + 5)
                    {
                        int y = i * 250;
                        price = y * ppc;
                        ListItem li = new ListItem("x" + i.ToString() + " = " + y.ToString() + " CloudCoins " + "($" + price.ToString() + ")" , y.ToString());
                        DDLTwoHundredFifties.Items.Add(li);
                    }
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

            int totalCoins = Ones + (Fives * 5) + (TwentyFives * 25) + (Hundreds * 100) + (TwoHundredFifties * 250);
            double totalPrice = totalCoins * double.Parse(WebConfigurationManager.AppSettings["PricePerCoin"]);


            if (totalPrice > 4.99)
            {
                Response.Redirect("GreenPayOrder.aspx?Ones=" + Ones + "&Fives=" + Fives + "&TwentyFives=" + TwentyFives + "&Hundreds=" + Hundreds + "&TwoHundredFifties=" + TwoHundredFifties);
            }
            else
            {
                LBLWarning.Text = "Order must be at least $5.00 to process!";
                LBLWarning.ForeColor = System.Drawing.Color.Red;
            }
            
        }
    }
}