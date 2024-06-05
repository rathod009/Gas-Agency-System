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

public partial class Consumer_frmFeedBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    clsUser objUser = new clsUser(); 
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objUser.UserId = Convert.ToInt32(Session["ConsumerId"]);
        objUser.Subject = txtSubject.Text;
        objUser.Description = txtDescription.Text;
       int a= objUser.InserFeedBack();
       if (a > 0)
       {
           Label1.Text = "Feed Back Send  To Admin";
            txtSubject.Text="";
           txtDescription.Text="";
  
       }

    }
}
