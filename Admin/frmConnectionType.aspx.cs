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

public partial class Admin_frmConnectionType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    clsAdmin objAdmin = new clsAdmin(); 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objAdmin.ConnectionName = txtConnectionName.Text;
            objAdmin.Description = txtDescription.Text;
            objAdmin.RefillCharge = Convert.ToDecimal(txtRefill.Text);
            objAdmin.NewConnectionCharge = Convert.ToDecimal(txtNewPrice.Text);
           string s= objAdmin.AddInsertConnection();
           lblMsg.Text = s;  

        }
        catch (Exception ex)
        {

            lblMsg.Text = ex.Message.ToString();  
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtNewPrice.Text = "";
        txtRefill.Text = "";
        txtNewPrice.Text = "";
        txtDescription.Text = "";
  

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            ShowConnectionType(); 
        }
        catch(Exception ex)
        {

        }
      
        
  
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;   

    }
    public void ShowConnectionType()
    {
        fs1.Visible = true;
        DataSet ds = objAdmin.ShowConnectionType();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvConnectionDetails.DataSource = ds.Tables[0];
            gvConnectionDetails.DataBind();
        }
        else
        {
            gvConnectionDetails.EmptyDataText="No Data Available";
            gvConnectionDetails.DataBind();  
        }
    }
}
