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

public partial class Distributor_frmUpdateProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetPersonalDetails(); 
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            objUser.RegUserId = Convert.ToInt32(Session["DistributorId"]);
            objUser.PhoneNo = txtPhone.Text;
            objUser.Email = txtEmail.Text;
            objUser.Address = txtAddress.Text;
            objUser.Image = (byte[])Session["Photo"];
            objUser.FileName = Convert.ToString(Session["FileName"]);
            lblMsg.Text = objUser.UpdateProfile();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
    }
    clsLogin objUser=new clsLogin(); 
  
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
    }
    protected void lbChangePassword_Click(object sender, EventArgs e)
    {
        divChangePss.Visible = true;  
    }
    protected void btnUpdatePass_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsg.Text = "";
            objUser.RegUserId = Convert.ToInt32(Session["DistributorId"]);
            //objChange.RegdUserId = objChange.GetUserIdByCustomerId();
            objUser.OldPwd = txtOld.Text;
            objUser.NewPwd = txtNew.Text;
            objUser.ConfirmPwd = txtConfirm.Text;
            lblMsg1.Text = objUser.ChangePassword();
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        
    }
    protected void btnPassCancel_Click(object sender, EventArgs e)
    {
        divChangePss.Visible =false ;  
    }
     void ClearData()
    {
        txtAddress.Text = "";
        txtPhone.Text = "";
        txtEmail.Text = "";
    }
     void GetPersonalDetails()
     {
         objUser.RegUserId =Convert.ToInt32(Session["DistributorId"]);
         DataSet ds = objUser.GetUserDetails();
         DataRow dr = ds.Tables[0].Rows[0];
         if (ds.Tables[0].Rows.Count > 0)
         {
             txtEmail.Text = dr["Email"].ToString();
             txtAddress.Text = dr["Address"].ToString();
             txtPhone.Text = dr["PhoneNo"].ToString();
             BrowseImage1.BindImage(dr["FileName"].ToString(), (byte[])dr["Image"]);

         }
     }
}
