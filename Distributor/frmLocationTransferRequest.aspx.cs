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

public partial class Distributor_frmLocationTransferRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowTransferRequests(); 
        }
    }
    clsDistributor objDist = new clsDistributor();
    public void ShowTransferRequests()
    {
        objDist.UserId = Convert.ToInt32(Session["UserId"]);
        DataSet ds = objDist.TransferRequest();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvTransferRequests.DataSource = ds.Tables[0];
            gvTransferRequests.DataBind();
        }
        else
        {
            gvTransferRequests.EmptyDataText = "No Requests Found";
            gvTransferRequests.DataBind();  
        }
    }
    protected void gvTransferRequests_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int SNO =Convert.ToInt32(gvTransferRequests.Rows[e.NewEditIndex].Cells[0].Text);
        objDist.SNO = SNO;
        int a = objDist.SendToAdminTransferRequest();
        if (a > 0)
        {
            lblMsg.Text = "Request Send to Admin";
            ShowTransferRequests(); 
        }
    }
}
