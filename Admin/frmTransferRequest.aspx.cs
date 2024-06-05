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

public partial class Admin_frmTransferRequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowTransferRequests(); 
        }
    }
    clsAdmin objAdmin = new clsAdmin();
    public void ShowTransferRequests()
    {
        DataSet ds = objAdmin.ShowUserLocationTransferRequestsToAdmin();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["ds"] = ds; 
            gvTransferRequests.DataSource = ds.Tables[0];
            gvTransferRequests.DataBind();
        }
        else
        {
            gvTransferRequests.EmptyDataText = "NO Requests Found";
            gvTransferRequests.DataBind();  
        }
    }
    protected void gvTransferRequests_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            int SNO = Convert.ToInt32(gvTransferRequests.Rows[e.NewEditIndex].Cells[0].Text);
            DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("SNO=" + SNO)[0];
            objAdmin.SNO = Convert.ToInt32(dr["SNO"].ToString());
            objAdmin.UserId = Convert.ToInt32(dr["ConsumerNo"].ToString());
            objAdmin.CityId = Convert.ToInt32(dr["ToCity"].ToString());
            objAdmin.AgencyName = dr["ToAgencyName"].ToString();
            string s = objAdmin.UpdateUserTransperRequests();
            lblMsg.Text = s;
            ShowTransferRequests();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.ToString();
        }
    }
}