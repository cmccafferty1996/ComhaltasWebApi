using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fleadh_Admin
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Redirect if session variable for user's full name has not been set
                if (Session["UsersFullName"] == null)
                {
                    Response.Redirect("~/login.aspx",false);
                }

            }

        }
    }
}
