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

public partial class Admin_frmManageCylinders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState(); 
        }

    }
    clsState objState = new clsState(); 
    public void GetState()
    {
        ddlState.Items.Clear();
        ddlDistrict.Items.Clear();
        ddlCity.Items.Clear();
        ddlAgencyName.Items.Clear();
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex != 0)
        {
            ddlDistrict.Enabled  = true;
            objState.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            GetDistrict();
        }
        else
        {
            ddlDistrict.Enabled = false;
            ddlCity.Enabled = false;
            ddlAgencyName.Enabled = false;   
        }

    }
    public void GetCity()
    {
        ddlCity.Items.Clear();
        ddlAgencyName.Items.Clear();
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
        ddlAgencyName.Items.Clear();
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
            ddlCity.Enabled = true;
            objState.DistrictId = Convert.ToInt32(ddlDistrict.SelectedItem.Value);
            GetCity();
        }
        else
        {
            ddlCity.Enabled = false;
            ddlAgencyName.Enabled = false;   
        }
    }
    public void AgencyName()
    {
        ddlAgencyName.Items.Clear();
        DataSet ds = objState.ShowAgencyName();
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlAgencyName.Items.Clear();
            ddlAgencyName.DataTextField = "AgencyName";
            ddlAgencyName.DataValueField = "UserId";
            ddlAgencyName.DataSource = ds.Tables[0];
            ddlAgencyName.DataBind();
            ddlAgencyName.Items.Insert(0, "Select");

        }
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex != 0)
        {
            ddlAgencyName.Enabled = true;
            objState.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value);
            AgencyName();
        }
        else
        {
            ddlAgencyName.Enabled = false;   
        }
    }
    clsAdmin objAdmin = new clsAdmin(); 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            objAdmin.CityId =Convert.ToInt32(ddlCity.SelectedItem.Value.ToString());
            objAdmin.UserId = Convert.ToInt32(ddlAgencyName.SelectedItem.Value.ToString());
            objAdmin.AgencyName = ddlAgencyName.SelectedItem.Text;
            objAdmin.AvailableCylinders =Convert.ToInt32(txtAvailableCylinders.Text);
            objAdmin.TotalCylinders = Convert.ToInt32(txtTotalCylinders.Text);
            string s=objAdmin.AddCylinderDetails();
            lblMsg.Text = s;  
   
         
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();   
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DataSet ds = objAdmin.ShowAllCylinders();
        if (ds.Tables[0].Rows.Count > 0)
        {
            fs1.Visible = true;   
            ViewState["ds"] = ds;  
            gvCylinders.DataSource = ds.Tables[0];
            gvCylinders.DataBind();
        }
        else
        {
            gvCylinders.EmptyDataText = "No Data Available";
            gvCylinders.DataBind();  
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            objAdmin.SNO = Convert.ToInt32(ViewState["SNO"]);
            objAdmin.TotalCylinders =Convert.ToInt32(txtTotalCylinders1.Text);
            objAdmin.AvailableCylinders =Convert.ToInt32(txtAvailableCylinders1.Text);
            string s=objAdmin.UpdateCylinders();
            lblMsg1.Text = s;
            btnShow_Click(sender, e); 
        }
        catch (Exception ex)
        {
 
        }
    }
    protected void gvCylinders_RowEditing(object sender, GridViewEditEventArgs e)

    {
        div1.Visible = true;  
        int SNO = Convert.ToInt32(gvCylinders.Rows[e.NewEditIndex].Cells[0].Text);
        DataRow dr = ((DataSet)ViewState["ds"]).Tables[0].Select("SNO=" + SNO)[0];
        txtAgencyName.Text = dr["AgencyName"].ToString();
        ViewState["SNO"] = dr["SNO"].ToString();
        txtAvailableCylinders1.Text = dr["AvailableCylinders"].ToString();
        txtTotalCylinders1.Text = dr["TotalCylinders"].ToString();   
   
    }
}
