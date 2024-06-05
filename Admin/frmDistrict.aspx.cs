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

public partial class Admin_frmDistrict : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState(); 
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlState.SelectedItem.Text != "Select")
            {
                objState.DistrictName = txtStateName.Text;
                objState.Description = txtDescription.Text;
                objState.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
                string s = objState.InsertDistrict();
                lblMsg.Text = s;  
            }
            else
            {
                lblMsg.Text = "Select State Name";       
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();    
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        lblMsg.Text = "";  
    }
    void clear()
    {

        txtDescription.Text = "";
        txtStateName.Text = "";
        ddlState.SelectedIndex = 0;  

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;   
            DataSet ds = objState.ShowAllDistrict();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvDistrict.DataSource = ds.Tables[0];
                gvDistrict.DataBind();
            }
            else
            {
                gvDistrict.EmptyDataText = "No Data Available";
                gvDistrict.DataBind();
            }
        }
        catch (Exception ex)
        {
 
        }
    }
    clsState objState = new clsState(); 
    public void GetState()
    {
        DataSet ds = objState.ShowState();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "StateId";
            ddlState.DataSource = ds.Tables[0];
            ddlState.DataBind();
            ddlState.Items.Insert(0, "Select");   
        }
 
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;   
    }
}
