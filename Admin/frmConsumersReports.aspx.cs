using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Admin_frmConsumersReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowConsumerReports(); 

    }
    clsAdmin objAdmin = new clsAdmin();
    public void ShowConsumerReports()
    {
        DataSet ds = objAdmin.ShowConsumersReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvConsumerReports.DataSource = ds.Tables[0];
            gvConsumerReports.DataBind();
        }
        else
        {
            gvConsumerReports.EmptyDataText = "NoDataAvailable";
            gvConsumerReports.DataBind();  
        }
    }
    
}
