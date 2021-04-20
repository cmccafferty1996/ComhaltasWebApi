using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fleadh_Admin
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Display user's name if logged in
            if (Session["UsersFullName"] == null)
            {
                LoginDiv.Visible = false;
                LogoutDiv.Visible = false;
            }
            else
            {
                LoginDiv.Visible = true;
                LoginDiv.InnerText = "Current logged in user: " + (string)(Session["UsersFullName"]);
                LogoutDiv.Visible = true;
            }
        }

        protected void LB_Logout_Click(object sender, EventArgs e)
        {
            Session["UsersFullname"] = null;
            LoginDiv.Visible = false;
            LogoutDiv.Visible = false;
            Response.Redirect("~/Login.aspx", false);
        }
    }
}
