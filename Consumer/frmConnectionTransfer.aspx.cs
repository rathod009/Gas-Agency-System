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

public partial class Consumer_frmConnectionTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetState();
            GetUserConnection();
        }
    }


    clsDistributor objDistributor = new clsDistributor();
    public void ShowConnectionDetails()
    {
        objDistributor.UserId = Convert.ToInt32(Session["ConsumerId"]);
        DataSet ds = objDistributor.ShowConnectionDetailsByuser();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            Session["AgentId"] = dr["AgentId"].ToString();
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex != 0)
        {
            ddlDistrict.Enabled = true; 
            objState.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
            GetDistrict();
        }
        else
        {
            ddlAgencyName.Items.Clear();
            ddlCity.Items.Clear();
            ddlDistrict.Items.Clear();
            ddlAgencyName.Enabled = false;   
            ddlCity.Enabled=false;
            ddlDistrict.Enabled  = false;
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
    public void AgencyName()
    {
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
    clsUser objUser = new clsUser();
 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlCity.SelectedIndex != 0)
            {
                objUser.UserId =Convert.ToInt32(Session["ConsumerId"]);
                objUser.CityId = Convert.ToInt32(ViewState["ToCity"] );
                objUser.AgentId =Convert.ToInt32(Session["AgentId"]);
                objUser.AgencyName = txtFromAgency.Text; 
                objUser.ToAgencyName=  ddlAgencyName.SelectedItem.Text;
                objUser.ToAgentId = Convert.ToInt32(ddlAgencyName.SelectedItem.Value);
                objUser.ToCity = Convert.ToInt32(ddlCity.SelectedItem.Value);    
                string s=objUser.InsertTransferRequest();
                lblMsg.Text = s; 
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message.ToString();    
        }
    }
    public void GetUserConnection()
    {
        objUser.UserId =Convert.ToInt32( Session["ConsumerId"]);
        DataSet ds= objUser.GetUserConnection();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow dr = ds.Tables[0].Rows[0];
            txtConsumerNo.Text = dr["ConsumerNo"].ToString();
            txtFromAgency.Text = dr["AgencyName"].ToString();
            txtFromCity.Text = dr["CityName"].ToString();
            ViewState["ToCity"] = dr["City"].ToString();  
        }
    }
}