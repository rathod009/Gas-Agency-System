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

public partial class Admin_frmShowFeedBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowFeedBack(); 
    }
    clsAdmin objAdmin = new clsAdmin();
    public void ShowFeedBack()
    {
        DataSet ds = objAdmin.ShowFeedBack();
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvFeedBack.DataSource = ds.Tables[0];
            gvFeedBack.DataBind();
        }
        else
        {
            gvFeedBack.EmptyDataText = "No Data Available";
            gvFeedBack.DataBind() ;   
        }
    }
}
