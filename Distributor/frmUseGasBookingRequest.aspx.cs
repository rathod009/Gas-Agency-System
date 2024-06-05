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

public partial class Distributor_frmUseGasBookingRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowBookingRequests(); 
        }

    }
    clsDistributor objDisributor = new clsDistributor();

    public void ShowBookingRequests()
    {
        objDisributor.UserId = Convert.ToInt32(Session["UserId"]);  
        DataSet ds = objDisributor.GetGasBookingRequest();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvBookingRequest.DataSource = ds.Tables[0];
            gvBookingRequest.DataBind();
        }
        else
        {
            gvBookingRequest.EmptyDataText = "No Requests Are There";
            gvBookingRequest.DataBind();  
        }
    }
    static int SNo;
    protected void gvBookingRequest_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            Label tb = (Label)(gvBookingRequest.Rows[e.NewEditIndex].FindControl("lblUserId"));
            SNo = Convert.ToInt32(tb.Text);
            objDisributor.GetAcceptGasConnection(SNo);
            Page.RegisterClientScriptBlock("Raghuveer", "<script>alert('Delivered Successfully....')</script>");
            ShowBookingRequests();
        }
        catch (Exception ex)
        {

        }
    }
}