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

public partial class Admin_frmAgencyRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState();
            ShowConnectionType();
        }
    }
    clsState objState = new clsState(); 
    clsUser objUser = new clsUser(); 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objUser.UserName = txtUserName.Text;
            objUser.Password = txtPassword.Text;
            objUser.FirstName = txtName.Text;
            objUser.MiddleName = txtMName.Text;
            objUser.LastName = txtLName.Text;
            objUser.Address = txtAddress.Text;
            objUser.PhoneNo = txtPhone.Text;
            objUser.Email = txtEmail.Text;
            objUser.Image = (byte[])Session["Photo"];
            objUser.FileName = Convert.ToString(Session["FileName"]);
            objUser.DOB = Convert.ToDateTime(txtDOB.Text);
            objUser.DOR = Convert.ToDateTime(System.DateTime.Now.ToLongDateString().ToString());
            objUser.Role = ddlRole.SelectedItem.Text;
            objUser.Gender = ddlGender.SelectedItem.Text;
            objUser.Connection =Convert.ToInt32(ddlConnectionType.SelectedItem.Value);  
            objUser.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            objUser.DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            objUser.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            objUser.AgencyName = txtAgencyName.Text;    
            lblMsg.Text = objUser.InsertUserRegistration();
            ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    void ClearData()
    {
        txtName.Text = "";
        txtMName.Text = "";
        txtLName.Text = "";
        txtAddress.Text = "";
        txtEmail.Text = "";
        txtPhone.Text = "";
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtDOB.Text = "";
        ddlDistrict.SelectedIndex = 0;
        ddlStateName.SelectedIndex = 0;
        ddlCity.SelectedIndex = 0; 
        BrowseImage1.Clearimage();

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearData(); 
    }
    public void GetState()
    {
        ddlStateName.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlCity.Items.Clear();
        DataSet ds = objState.ShowState();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlStateName.DataTextField = "StateName";
            ddlStateName.DataValueField = "StateId";
            ddlStateName.DataSource = ds.Tables[0];
            ddlStateName.DataBind();
            ddlStateName.Items.Insert(0, "Select");
        }
    }
    public void GetDistrict()
    {
        ddlDistrict.Items.Clear();
        ddlCity.Items.Clear();
        DataSet ds = objState.ShowDistrictByStateId();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlDistrict.DataTextField = "DistrictName";
            ddlDistrict.DataValueField = "DistrictId";
            ddlDistrict.DataSource = ds.Tables[0];
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, "Select");
        }
    }
    public void GetCity()
    {
        ddlCity.Items.Clear();
        DataSet ds = objState.ShowCityByDistrictId();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityId";
            ddlCity.DataSource = ds.Tables[0];
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, "Select");
       }
    }

    clsAdmin objAdmin = new clsAdmin();
    public void ShowConnectionType()
    {
        DataSet ds = objAdmin.ShowConnectionType();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlConnectionType.DataTextField = "ConnectionName";
            ddlConnectionType.DataValueField = "ConnectionTypeId";
            ddlConnectionType.DataSource = ds;
            ddlConnectionType.DataBind();
            ddlConnectionType.Items.Insert(0, "select");
        }
    }
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateName.SelectedIndex != 0)
        {
            objState.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            GetDistrict();

        }
        else
        {
            lblMsg.Text = "Select State Name";  
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex != 0)
        {
            objState.DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            GetCity();
        }
        else
        {
            lblMsg.Text = "Select District Name";  
        }
    }
}
