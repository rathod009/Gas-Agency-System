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

public partial class frmConsumerRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState();
            GetConnection(); 
        }
    }
    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static AjaxControlToolkit.Slide[] GetSlides(string contextKey)
    {
        AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[8];
        slides[0] = new AjaxControlToolkit.Slide("Images/gas1.jpg", "", "First Image");
        slides[1] = new AjaxControlToolkit.Slide("Images/gas2.jpg", "", "Second Image");
        slides[2] = new AjaxControlToolkit.Slide("Images/gas3.jpg", "", "Third Image");
        slides[3] = new AjaxControlToolkit.Slide("Images/gas4.jpg", "", "Fourth Image");
        slides[4] = new AjaxControlToolkit.Slide("Images/gas5.jpg", "", "Fifth Image");
        slides[5] = new AjaxControlToolkit.Slide("Images/gas6.jpg", "", "Fifth Image");
        slides[6] = new AjaxControlToolkit.Slide("Images/gas7.jpg", "", "Fifth Image");
        slides[7] = new AjaxControlToolkit.Slide("Images/gas8.jpg", "", "Fifth Image");

        return (slides); ;
    }
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
            objUser.Role = "Consumer";
            objUser.Connection = Convert.ToInt32(ddlConnection.SelectedItem.Value);    
            objUser.Gender = ddlGender.SelectedItem.Text;
            objUser.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            objUser.DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            objUser.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            objUser.AgencyName = ddlAgencyName.SelectedItem.Text;   
            lblMsg.Text = objUser.InsertUserRegistration();
            ClearData();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClearData();
        lblMsg.Text = "";  
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
        ddlAgencyName.Visible = false;
        ddlCity.Visible = false;
        lblDistrict.Visible = false;
        lblCity.Visible = false;
        lblAgency.Visible = false;
        ddlDistrict.Visible = false;   
    }
    public void GetState()
    {
        ddlStateName.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlCity.Items.Clear();
        ddlAgencyName.Items.Clear();
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
    protected void ddlStateName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStateName.SelectedIndex != 0)
        {
            lblDistrict.Visible = true;
            ddlDistrict.Visible = true;
            objState.StateId = Convert.ToInt32(ddlStateName.SelectedItem.Value);
            GetDistrict();
        }
        else
        {
            ddlAgencyName.Visible = false;
            ddlCity.Visible = false;
            lblDistrict.Visible = false;
            lblCity.Visible = false;
            lblAgency.Visible = false;
            ddlDistrict.Visible = false;   
        }
    }
    clsState objState = new clsState(); 
    public void GetCity()
    {
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
    public void GetDistrict()
    {
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
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDistrict.SelectedIndex != 0)
        {
            ddlCity.Visible = true;
            lblCity.Visible = true;
            objState.DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            GetCity();  
        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex != 0)
        {
            lblAgency.Visible = true;
            ddlAgencyName.Visible = true;
            objState.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            AgencyName(); 
        }
    }
    public void AgencyName()
    {
        DataSet ds = objState.ShowAgencyName();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAgencyName.Items.Clear();   
            ddlAgencyName.DataTextField = "AgencyName";
            ddlAgencyName.DataValueField = "AgencyName";
            ddlAgencyName.DataSource = ds.Tables[0];   
            ddlAgencyName.DataBind();
            ddlAgencyName.Items.Insert(0, "Select");
   
        }
    }
    clsAdmin objAdmin = new clsAdmin(); 
    public void GetConnection()
    {
        DataSet ds = objAdmin.ShowConnectionType();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlConnection.DataTextField = "ConnectionName";
            ddlConnection.DataValueField = "ConnectionTypeId";
            ddlConnection.DataSource = ds.Tables[0];
            ddlConnection.DataBind();
            ddlConnection.Items.Insert(0, "Select");   
        }
    }

}
