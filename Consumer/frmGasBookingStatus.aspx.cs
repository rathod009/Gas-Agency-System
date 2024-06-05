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

public partial class Consumer_frmGasBookingStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowBookingStatus();
        }

    }
    clsUser objUser = new clsUser();
    public void ShowBookingStatus()
    {
        objUser.UserId =Convert.ToInt32(Session["ConsumerId"]);
        DataSet ds = objUser.GasBookingStatus();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvShowBookingStatus.DataSource = ds.Tables[0];
            gvShowBookingStatus.DataBind();
        }
        else
        {
            gvShowBookingStatus.EmptyDataText = "No Data Available";
            gvShowBookingStatus.DataBind();  
        }
    }
}
