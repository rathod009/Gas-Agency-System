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

public partial class Admin_frmAgencyReports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowAgencyReports(); 
    }
    clsAdmin objAdmin = new clsAdmin();
    public void ShowAgencyReports()
    {
        DataSet ds = objAdmin.ShowDitributorsReport();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvAgencyReports.DataSource = ds.Tables[0];
            gvAgencyReports.DataBind();
        }
        else
        {
            gvAgencyReports.EmptyDataText = "No Data Available";
            gvAgencyReports.DataBind();  
        }
    }
}
