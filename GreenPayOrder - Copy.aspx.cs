using Founders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudService
{
    class ServiceResponse
    {
        public string server;
        public string status;
        public string message;
        public string time;
    }



    public partial class GreenPayOrder : System.Web.UI.Page
    {
        private string Ones;
        private string Fives;
        private string TwentyFives;
        private string Hundreds;
        private string TwoHundredFifties;
        private string Memo;
        private string TotalCoins;
        private string PricePerCoin;
        private double TotalPriceOfPurchase;

        int iOnes;
        int iFives;
        int iTwentyFives;
        int iHundreds;
        int iTwoHundredFifties;
        int iTotalCoins;

        private int MarkedOnes;
        private int MarkedFives;
        private int MarkedTwentyFives;
        private int MarkedHundreds;
        private int MarkedTwoHundredFifties;

        private int OnesAfterSale;
        private int FivesAfterSale;
        private int TwentyFivesAfterSale;
        private int HundredsAfterSale;
        private int TwoHundredFiftiesAfterSale;


        protected void Page_Load(object sender, EventArgs e)
        {

            ServiceResponse serviceResponse = new ServiceResponse();
            serviceResponse.server = WebConfigurationManager.AppSettings["thisServerName"];
            serviceResponse.time = DateTime.Now.ToString();


            Ones = CheckParameter("Ones");
            Fives = CheckParameter("Fives");
            TwentyFives = CheckParameter("TwentyFives");
            Hundreds = CheckParameter("Hundreds");
            TwoHundredFifties = CheckParameter("TwoHundredFifties");
            Memo = CheckParameter("Memo");

            GetCoinsCurrentlyMarkedForSale();

            int total = 0;
            if (Ones != "")
            {
                int x;
                bool result = int.TryParse(Ones, out x);
                if (result)
                {
                    iOnes = x;
                    total = total + x;
                }
            }
            if (Fives != "")
            {
                int x;
                bool result = int.TryParse(Fives, out x);
                if (result)
                {
                    iFives = x;
                    total = total + (x * 5);
                }
            }
            if (TwentyFives != "")
            {
                int x;
                bool result = int.TryParse(TwentyFives, out x);
                if (result)
                {
                    iTwentyFives = x;
                    total = total + (x * 25);
                }
            }
            if (Hundreds != "")
            {
                int x;
                bool result = int.TryParse(Hundreds, out x);
                if (result)
                {
                    iHundreds = x;
                    total = total + (x * 100);
                }
            }
            if (TwoHundredFifties != "")
            {
                int x;
                bool result = int.TryParse(TwoHundredFifties, out x);
                if (result)
                {
                    iTwoHundredFifties = x;
                    total = total + (x * 250);
                }
            }
            iTotalCoins = total;
            TotalCoins = total.ToString();

            if (iOnes > MarkedOnes || iFives > MarkedFives || iTwentyFives > MarkedTwentyFives || iHundreds > MarkedHundreds || iTwoHundredFifties > MarkedTwoHundredFifties)
            {
                serviceResponse.status = "fail";
                serviceResponse.message = "Coins requested not available for purchase!";
                var serialjson = new JavaScriptSerializer().Serialize(serviceResponse);
                Response.Write(serialjson);
                Response.End();
            }




            if (Ones != "") lblOnes.Text = Ones;
            if (Fives != "") lblFives.Text = Fives;
            if (TwentyFives != "") lblTwentyFives.Text = TwentyFives;
            if (Hundreds != "") lblHundreds.Text = Hundreds;
            if (TwoHundredFifties != "") lblTwoHundredFifties.Text = TwoHundredFifties;
            if (TotalCoins != "") lblTotalCoins.Text = TotalCoins;

            PricePerCoin = WebConfigurationManager.AppSettings["PricePerCoin"];
            double ppc;
            bool b = double.TryParse(PricePerCoin, out ppc);
            
            if (b)
            {
                TotalPriceOfPurchase = ppc * total;
            }
            else
            {
                TotalPriceOfPurchase = 0.01 * total;
            }

            lblTotalPrice.Text = String.Format("{0:0.00}", TotalPriceOfPurchase);
        }

        string CheckParameter(string param)
        {
            if (Request[param] != null)
                return Request[param];
            else
                return "";
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

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            Order NewOrder = new Order();

            NewOrder.AccountingNumber = txtAccountNumber.Value;
            NewOrder.AddressOnCheck = txtAddress.Text;
            NewOrder.BankName = txtBankName.Text;
            NewOrder.CityOnCheck = txtCity.Text;
            NewOrder.EMailAddress = txtEmailAddress.Text;
            NewOrder.NameOnCheck = txtNameOnCheck.Text;
            NewOrder.PhoneNumber = txtPhoneNumber.Text;
            NewOrder.RoutingNumber = txtRoutingNumber.Value;
            NewOrder.StateOnCheck = DropDownListState.Text;
            NewOrder.TotalPrice = double.Parse(lblTotalPrice.Text);
            NewOrder.TwentyFivesOrdered = int.Parse(lblTwentyFives.Text);
            NewOrder.TwoHundredFiftiesOrdered = int.Parse(lblTwoHundredFifties.Text);
            NewOrder.OnesOrdered = int.Parse(lblOnes.Text);
            NewOrder.HundredsOrdered = int.Parse(lblHundreds.Text);
            NewOrder.FivesOrdered = int.Parse(lblFives.Text);
            NewOrder.ZipCodeOnCheck = txtZip.Value;
            NewOrder.TotalCoinsOrdered = int.Parse(lblTotalCoins.Text);
            NewOrder.CheckNumber = txtCheckNumber.Text;
            NewOrder.TimeStamp = DateTime.Now;

            CoinsAvailableAfterSale(NewOrder);

            string ClientID = WebConfigurationManager.AppSettings["GreenPayID"];
            string APIPassword = WebConfigurationManager.AppSettings["GreenPayAPIPassword"];

            //GreenPayECheck.eCheckSoapClient client = new GreenPayECheck.eCheckSoapClient();
            //GreenPayECheck.DraftResult DraftResult = new GreenPayECheck.DraftResult();
            //DraftResult = client.OneTimeDraftRTV(ClientID, APIPassword, NewOrder.NameOnCheck, NewOrder.EMailAddress, NewOrder.PhoneNumber, "", NewOrder.AddressOnCheck, "", NewOrder.CityOnCheck,
            //    NewOrder.StateOnCheck, NewOrder.ZipCodeOnCheck, "US", NewOrder.RoutingNumber, NewOrder.AccountingNumber, NewOrder.BankName, "", NewOrder.TotalPrice.ToString(),
            //    DateTime.Now.ToShortDateString(), NewOrder.CheckNumber, "", "");

            //temp code
            GreenPayECheck.DraftResult DraftResult = new GreenPayECheck.DraftResult();
            if (NewOrder.RoutingNumber == "1")
            {
                DraftResult = testSuccess();
            }
            else
            {
                DraftResult = testFailure();
            }
            //end temp code

            NewOrder.CheckID = DraftResult.Check_ID;
            NewOrder.VerificationResultCode = DraftResult.VerifyResult;
            NewOrder.VerificationResultDesc = DraftResult.VerifyResultDescription;

            OrderEntities oe = new OrderEntities();
            oe.Orders.Add(NewOrder);
            oe.SaveChanges();

            if (DraftResult.VerifyResult == "0")
            {
                FillOrder(NewOrder);
            }

            int x = 0;
        }

        void FillOrder(Order o)
        {
            string pk = WebConfigurationManager.AppSettings["root"];

            FileUtils fileUtils = FileUtils.GetInstance(HttpRuntime.AppDomainAppPath + @"\" + pk + @"\");

            string tag = o.CheckID;

            Exporter exporter = new Exporter(fileUtils);
            Boolean b;
            b = exporter.writeJSONFile(o.OnesOrdered, o.FivesOrdered, o.TwentyFivesOrdered, o.HundredsOrdered, o.TwoHundredFiftiesOrdered, tag);
            if (b)
            {
                string path = fileUtils.exportFolder + Path.DirectorySeparatorChar + o.TotalCoinsOrdered + ".CloudCoins." + tag + ".stack";
            }
        }

        void CoinsAvailableAfterSale(Order o)
        {
            GetCoinsCurrentlyMarkedForSale();

            OnesAfterSale = MarkedOnes - o.OnesOrdered;
            FivesAfterSale = MarkedFives - o.FivesOrdered;
            TwentyFivesAfterSale = MarkedTwentyFives - o.TwentyFivesOrdered;
            HundredsAfterSale = MarkedHundreds - o.HundredsOrdered;
            TwoHundredFiftiesAfterSale = MarkedTwoHundredFifties - o.TwoHundredFiftiesOrdered;
        }

        //temp code
        GreenPayECheck.DraftResult testSuccess()
        {
            GreenPayECheck.DraftResult dr = new GreenPayECheck.DraftResult();
            dr.Check_ID = "1";
            dr.CheckNumber = "1";
            dr.VerifyResult = "0";
            dr.VerifyResultDescription = "Test Description";

            return dr;
        }
        //end temp code

        //temp code
        GreenPayECheck.DraftResult testFailure()
        {
            GreenPayECheck.DraftResult dr = new GreenPayECheck.DraftResult();
            dr.Check_ID = "1";
            dr.CheckNumber = "1";
            dr.VerifyResult = "2";
            dr.VerifyResultDescription = "Test Description";

            return dr;
        }
        //end temp code
    }
}