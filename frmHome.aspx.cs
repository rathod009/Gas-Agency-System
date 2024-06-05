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

public partial class frmHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();  
        Session.Abandon();
        FormsAuthentication.SignOut();  
        if (!IsPostBack)
        {
            GetState(); 
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
    public void GetState()
    {
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
    clsState objState = new clsState();
    public void GetCity()
    {
        ddlCity.Items.Clear();
        ddlAgency.Items.Clear();
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
        ddlDistrict.Items.Clear();
        ddlCity.Items.Clear();
        ddlAgency.Items.Clear();
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
            ddlAgency.Visible = false;
            ddlCity.Visible = false;
            lblDistrict.Visible = false;
            lblCity.Visible = false;
            lblAgency.Visible = false;
            ddlDistrict.Visible = false;
            gvCylinders.Visible = false;
            btnSubmit.Enabled = false;  
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
    public void AgencyName()
    {
        DataSet ds = objState.ShowAgencyName();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAgency.Items.Clear();
            ddlAgency.DataTextField = "AgencyName";
            ddlAgency.DataValueField = "UserId";
            ddlAgency.DataSource = ds.Tables[0];
            ddlAgency.DataBind();
            ddlAgency.Items.Insert(0, "Select");

        }
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex != 0)
        {
            lblAgency.Visible = true;
            ddlAgency.Visible = true;
            btnSubmit.Enabled = true;
            objState.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            AgencyName();
        }
        else
        {
            btnSubmit.Enabled = false;  
        }
    }
    clsAdmin objAdmin = new clsAdmin(); 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCity.SelectedIndex != 0 && ddlAgency.SelectedIndex != 0)
            {

                objAdmin.CityId =Convert.ToInt32(ddlCity.SelectedItem.Value);
                objAdmin.AgencyName = ddlAgency.SelectedItem.Text;
                DataSet ds = objAdmin.DispalyCylinderStatus();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCylinders.Visible = true;   
                    gvCylinders.DataSource = ds.Tables[0];
                    gvCylinders.DataBind();
                }
                else
                {
                    gvCylinders.Visible = true;   
                    gvCylinders.EmptyDataText = "No Data Available";
                    gvCylinders.DataBind();  
                }

            }

        }
        catch (Exception ex)
        {
 
        }
    }
}
