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

public partial class Consumer_frmConsumerHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            call();
            ShowConnectionDetails();
        }
    }

    public void call()
    {
         clsDistributor objDistributor = new clsDistributor();
        objDistributor.UserId = Convert.ToInt32(Session["ConsumerId"]);
        DataSet ds = objDistributor.ShowConnectionDetailsByuser();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            Session["AgentId"] = dr["AgentId"].ToString();
        }
        lblUserName.Text = Session["UserName"].ToString();
    }

    clsDistributor objDistributor = new clsDistributor();
    public void ShowConnectionDetails()
    {
        objDistributor.UserId = Convert.ToInt32(Session["ConsumerId"]);
        DataSet ds = objDistributor.ShowConnectionDetailsByuser();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            //lblConsumerNo.Text = dr["ConsumerNo"].ToString();
            //lblConsumerName.Text = dr["ConsumerName"].ToString();
            //lblConnectionName.Text = dr["ConnectionName"].ToString();
            //lblDate.Text = dr["AppliedDate"].ToString();
            //lblIssuedDate.Text = dr["IssuedDate"].ToString();
            //lblAgencyName.Text = dr["AgencyName"].ToString();
            //lblAddress.Text = dr["Address"].ToString();
            Session["AgentId"] = dr["AgentId"].ToString();
        }
    }

}