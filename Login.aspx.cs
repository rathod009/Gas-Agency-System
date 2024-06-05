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

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMsg.Text = "";

        string url = Request.Url.ToString();
        string[] split = url.Split('/');
        for (int i = 0; i < split.Length; i++)
        {
            if (split[i] == "Admin")
            {
                lblLogin.Text = "Admin Login";
            }
            else if (split[i] == "Distributor")
            {
                lblLogin.Text = "Distributor Login";
            }
            else if (split[i] == "Consumer")
            {
                lblLogin.Text = "Consumer Login";  
            }

        }
        if (Session["UserName"] != null)
        {
            FormsAuthentication.SignOut();
        }

    }
    protected void ImgBtnEmail_Click(object sender, EventArgs e)
    {
        string str1 = null;
        string[] UserName = null;
        try
        {
            if (txtusername.Text.Contains("@"))
            {
                string str = txtusername.Text;
                UserName = str.Split('@');
                clsLogin.UserName = UserName[0].ToString();
                str1 = UserName[0].ToString();
            }
            else
            {
                clsLogin.UserName = txtusername.Text.Trim();
                str1 = txtusername.Text.Trim();
                Session["Name"] = str1;
            }
            clsLogin.Password = txtpassword.Text.Trim();
            int id;
            string Role = clsLogin.GetUserLogin(out id);

            if (Role == "NoUser")
                lblMsg.Text = "User Name and password mismatch. Try again.";
            else
            {
                Session["UserType"] = Role;

                Session["UserId"] = id;

                if (Role.ToLower() == "admin")
                {
                    Session["AdminId"] = clsLogin.GetAdminIdByUserId(Convert.ToInt32(Session["UserId"]));
                    Session["UserName"] = str1;

                    FormsAuthentication.RedirectFromLoginPage("Admin", false);
                }
                else if (Role.ToLower() == "distributor")
                {
                    Session["DistributorId"] = clsLogin.GetDistributorIdByUserId(Convert.ToInt32(Session["UserId"]));
                    //Session["BranchId"] = clsLogin.GetBranchId(Convert.ToInt32(Session["UserId"]));
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage("Distributor", false);
                }
                else if (Role.ToLower() == "consumer")
                {

                    Session["ConsumerId"] = clsLogin.GetConsumerIdByUserId(Convert.ToInt32(Session["UserId"]));
                    //Session["BranchId"] = clsLogin.GetBranchId(Convert.ToInt32(Session["UserId"]));
                    Session["UserName"] = str1;
                    FormsAuthentication.RedirectFromLoginPage(Role, false);
                }

            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
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
}
