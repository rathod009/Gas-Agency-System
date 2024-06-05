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

public partial class Distributor_frmConsumerReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowConsumerReports(); 
    }
    clsDistributor objDist = new clsDistributor();
    public void ShowConsumerReports()
    {
        objDist.UserId = Convert.ToInt32(Session["DistributorId"]);
        DataSet ds = objDist.ShowConsumerReports();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvConsumerReports.DataSource = ds.Tables[0];
            gvConsumerReports.DataBind();
        }
        else
        {
            gvConsumerReports.EmptyDataText = "No Data Available";
            gvConsumerReports.DataBind();  
        }
    }
}
