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

public partial class Admin_frmManageState : System.Web.UI.Page
{
    clsState objState = new clsState(); 
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
           objState.StateName = txtStateName.Text;
           objState.Description = txtDescription.Text;
           string s =objState.InsertState();
           lblMsg.Text = s;
           Clear();
   
        }
        catch (Exception ex)
        {
            lblMsg.Text=ex.Message.ToString();  
        }

    }
    public void Clear()
    {
        txtStateName.Text = "";
        txtDescription.Text = "";
  
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
        try
        {
            fs1.Visible = true;   
            DataSet ds = objState.ShowState();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvStateDetails.DataSource = ds.Tables[0];
                gvStateDetails.DataBind();
            }
            else
            {
                gvStateDetails.EmptyDataText = "No Data Available";
                gvStateDetails.DataBind();
            }
        }
        catch(Exception ex)

        {
            lblMsg.Text = ex.Message.ToString();    
        }
    }
    protected void btnClose_Click(object sender, EventArgs e)
    {
        fs1.Visible = false;  
    }
}
