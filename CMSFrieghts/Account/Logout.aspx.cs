using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSFrieghts.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Session["EmailAdress"] = "";
            Session["Credentials"] = "";
            Session["LoggedIn"] = false;
            Response.Redirect("/Account/Login", false);
        }
    }
}