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

public partial class Consumer_frmShowTransferStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowTransferStatus();
        }
    }
    clsUser objUser = new clsUser();
    public void ShowTransferStatus()
    {
        try
        {
            objUser.UserId = Convert.ToInt32(Session["ConsumerId"]);
            DataSet ds = objUser.GasTransferStatus();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShowTransferStatus.DataSource = ds.Tables[0];
                gvShowTransferStatus.DataBind();
            }
            else
            {
                gvShowTransferStatus.EmptyDataText = "No Data Available";
                gvShowTransferStatus.DataBind();
            }
        }
        catch (Exception ex)
        {

            lblmsg.Text = ex.ToString();
        }
    }
}
