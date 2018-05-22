<%@ Page Language="C#" Debug="true"  Async="true"%>
<%@ Import namespace="System.Web.Configuration" %>
<%@ Import namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ Import namespace="System.Data.SqlClient" %>
<%@ Import namespace="System.Web.Configuration" %>
<%@ Import namespace="Founders" %>
<%@ Import namespace="System.Web.Script.Serialization" %>

<script language="c#" runat="server">
    public class ServiceResponse
    {
        public string bank_server;
        public string status;
        public string message;
        public int ones;
        public int fives;
        public int twentyfives;
        public int hundreds;
        public int twohundredfifties;
        public string time;
    }//End Service Response class


    private int MarkedOnes;
    private int MarkedFives;
    private int MarkedTwentyFives;
    private int MarkedHundreds;
    private int MarkedTwoHundredFifties;


    public void Page_Load(object sender, EventArgs e)
    {
        //string path = Request.QueryString["k"];
        string path = Request["pk"];

        ServiceResponse response = new ServiceResponse();
        response.bank_server = WebConfigurationManager.AppSettings["thisServerName"];

        if (path == null)
        {
            //Response.Write("Request Error: Private key not specified");
            response.status = "fail";
            response.message = "Private key not specified";
            var serialjson = new JavaScriptSerializer().Serialize(response);
            Response.Write(serialjson);
            Response.End();
        }
        if (path != WebConfigurationManager.AppSettings["root"])
        {
            response.status = "fail";
            response.message = "Private key not correct";
            var serialjson = new JavaScriptSerializer().Serialize(response);
            Response.Write(serialjson);
            Response.End();
        }

        FileUtils fileUtils = FileUtils.GetInstance(HttpRuntime.AppDomainAppPath.ToString() + @"\" + path + @"\");
        //FileUtils fileUtils = FileUtils.GetInstance(@"H:\Banks\Preston\"+path+@"\");


        response.status = "coins_shown";
        
        response.time = DateTime.Now.ToString("yyyy-MM-dd h:mm:tt");
        //Banker bank = new Banker(fileUtils);
        //int[] bankTotals = bank.countCoins(fileUtils.bankFolder);
        //int[] frackedTotals = bank.countCoins(fileUtils.frackedFolder);
        GetCoinsCurrentlyMarkedForSale();
        response.ones = MarkedOnes;
        response.fives = MarkedFives;
        response.twentyfives = MarkedTwentyFives;
        response.hundreds = MarkedHundreds;
        response.twohundredfifties = MarkedTwoHundredFifties;
        var json = new JavaScriptSerializer().Serialize(response);
        Response.Write(json);
        Response.End();
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

</script>
