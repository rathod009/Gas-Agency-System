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

public partial class Distributor_frmConsumerNewConnection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowNewConnections(); 
        }
    }
    clsDistributor objDistributor = new clsDistributor();
    public void ShowNewConnections()
    {
        try
        {
            objDistributor.UserId = Convert.ToInt32(Session["DistributorId"]);   
            DataSet ds = objDistributor.GetConsumerConnectionRequests();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ds"] = ds; 
                gvConsumerRequests.DataSource = ds.Tables[0];
                gvConsumerRequests.DataBind();

            }
            else
            {
                gvConsumerRequests.EmptyDataText = "NO Requests Found";
                gvConsumerRequests.DataBind();
            }
        }
        catch (Exception ex)
        {
            
        }
    }


    protected void gvConsumerRequests_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int CNO =Convert.ToInt32(gvConsumerRequests.Rows[e.NewEditIndex].Cells[1].Text);
        fs1.Visible = true;
        DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("ConsumerNo=" + CNO)[0];
        txtConsumerNO.Text = dr["ConsumerNo"].ToString();
        txtConsumerName.Text = dr["Name"].ToString();
        txtAddress.Text = dr["Address"].ToString();
        txtConnection.Text = dr["ConnectionName"].ToString();
        txtReDate.Text = dr["RequestDate"].ToString();
        ViewState["AName"] = dr["AgencyName"].ToString();  

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            InsertConnectionDetails(); 
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();  
  
 
        }
    }
    public void InsertConnectionDetails()
    {
        objDistributor.ConsumerNo =Convert.ToInt32(txtConsumerNO.Text);
        objDistributor.ConsumerName = txtConsumerName.Text;
        objDistributor.ConsumerAddress = txtAddress.Text;
        objDistributor.ConnectionName = txtConnection.Text;
        objDistributor.RequestedDate = Convert.ToDateTime(txtReDate.Text);
        objDistributor.AllotedDate = Convert.ToDateTime(txtAllotedDate.Text);
        objDistributor.CylinderNo = Convert.ToInt32(txtCylinder.Text);
        objDistributor.Regulator = Convert.ToInt32(txtRegulator.Text);
        objDistributor.AgencyName = ViewState["AName"].ToString();
        objDistributor.DepositAmount = Convert.ToDecimal(txtDepositAmount.Text);
        objDistributor.ConnectionCharge = Convert.ToDecimal(txtConnectionCharge.Text);    
        string s = objDistributor.InsertConnectionDetails();
        lblMsg.Text = s;
        ShowNewConnections();
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;   
    }
}
