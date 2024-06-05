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

public partial class Admin_frmCity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDistrict();  
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objState.DistrictId = Convert.ToInt32(ddDistrict.SelectedItem.Value);
            objState.CityName = txtStateName.Text;
            objState.Description = txtDescription.Text;
            string s = objState.InsertCity();
            lblMsg.Text = s; 
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();   
        }
    }
    void Clear()
    {
        txtDescription.Text = "";
        txtStateName.Text = "";
        ddDistrict.SelectedIndex = 0;  
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        lblMsg.Text = "";
 
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;   
            DataSet ds = objState.ShowAllCity();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvShowCity.DataSource = ds.Tables[0];
                gvShowCity.DataBind();
            }
            else
            {
                gvShowCity.EmptyDataText = "No Data Found";
                gvShowCity.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();    
        }

    }
    clsState objState = new clsState(); 
    public void GetDistrict()
    {
        DataSet ds = objState.ShowDistrict();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddDistrict.DataTextField = "DistrictName";
            ddDistrict.DataValueField = "DistrictId";
            ddDistrict.DataSource = ds.Tables[0];  
            ddDistrict.DataBind();
            ddDistrict.Items.Insert(0, "Select");
        }

    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;   
    }
}
