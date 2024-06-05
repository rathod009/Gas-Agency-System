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

public partial class Admin_frmUpdateConnectionType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowData(); 
        }

    }
    clsAdmin objAdmin = new clsAdmin(); 
    public void ShowData()
    {
        fs1.Visible = true;   
        DataSet ds = objAdmin.ShowConnectionType();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["ds"] = ds; 
            gvConnectionDetails.DataSource = ds.Tables[0];
            gvConnectionDetails.DataBind();
        }
        else
        {
            gvConnectionDetails.EmptyDataText = "No Data Available";
            gvConnectionDetails.DataBind();
        }
    }

    protected void gvConnectionDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        fs2.Visible = true;
        int CId = Convert.ToInt32(gvConnectionDetails.Rows[e.NewEditIndex].Cells[1].Text);
        DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("ConnectionTypeId=" + CId)[0];
        ViewState["TypeId"] = dr["ConnectionTypeId"].ToString(); 
        txtDescription.Text = dr["Description"].ToString();
        txtConnectionName.Text = dr["ConnectionName"].ToString();
        txtNewPrice.Text  = dr["NewConnectionPrice"].ToString();
        txtRefill.Text = dr["RefillCharge"].ToString(); 
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objAdmin.ConnectionName = txtConnectionName.Text;
            objAdmin.Description = txtDescription.Text;
            objAdmin.NewConnectionCharge = Convert.ToDecimal(txtNewPrice.Text);
            objAdmin.RefillCharge = Convert.ToDecimal(txtRefill.Text);
            objAdmin.ConnectionTypeId = Convert.ToInt32(ViewState["TypeId"]);
            string s = objAdmin.UpdateConnection();
            lblMsg.Text = s;
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();    
        }
        
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs2.Visible = true;   
    }
}
