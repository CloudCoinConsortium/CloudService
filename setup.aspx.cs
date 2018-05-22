using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security.AccessControl;
using System.Configuration;

public partial class setup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSetup_Click(object sender, EventArgs e)
    {
        if (WebConfigurationManager.AppSettings["root"] != "")
        {
            
        }
        else  
        {
            Guid g = Guid.NewGuid();
            string guid = g.ToString();

            string path = AppDomain.CurrentDomain.BaseDirectory + guid;

            Directory.CreateDirectory(path);

            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Bank";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Checks";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Counterfeit";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Danger";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Detected";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Directory";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Export";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Fracked";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Import";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Imported";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Logs";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Lost";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Partial";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Receipts";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Suspect";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Templates";
            Directory.CreateDirectory(path);
            path = AppDomain.CurrentDomain.BaseDirectory + guid + @"\Trash";
            Directory.CreateDirectory(path);


            File.Move(AppDomain.CurrentDomain.BaseDirectory + "billpay.xlsx", AppDomain.CurrentDomain.BaseDirectory + guid + @"\billpay.xlsx");


            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            webConfigApp.AppSettings.Settings["root"].Value = guid;
            webConfigApp.Save();

        }

    }
}