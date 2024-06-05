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

public partial class frmAboutUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
