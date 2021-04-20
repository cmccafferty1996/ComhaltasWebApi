using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Fleadh_Admin
{
    public partial class Login : System.Web.UI.Page
    {
        //Set database connection string
        static string dbConnString = System.Configuration.ConfigurationManager.ConnectionStrings["CSComhaltasDB"].ToString();
        //Create a SQL Connection
        SqlConnection dbConn = new SqlConnection(dbConnString);

        

                       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
                lblLoginFailure.Text = "";
            }
            else
            {
                txtPassword.Attributes["value"] = txtPassword.Text;
                
                if (txtUserName.Text != "")
                {
                    txtPassword.Focus();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Perform validation
            if ((txtUserName.Text == "") || (txtPassword.Text == ""))
            {
                lblLoginFailure.Text = "Please enter your login credentials";
            }
            else
            {
                lblLoginFailure.Text = "";
                //Create a SQL command to query database with entered credentials
                SqlCommand sqlCheckValidUser = new SqlCommand();

                //Set properties for the SQL command
                sqlCheckValidUser.Connection = dbConn;
                sqlCheckValidUser.CommandType = System.Data.CommandType.Text;
                sqlCheckValidUser.CommandText = "SELECT first_name + ' ' + surname AS 'User_Name' FROM Admin_users " +
                    "WHERE user_name = @username AND password = @password";

                sqlCheckValidUser.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = txtUserName.Text;
                sqlCheckValidUser.Parameters.Add("@password", System.Data.SqlDbType.VarChar).Value = txtPassword.Text;

                //Execute the command and check result
                try
                {
                    dbConn.Open();
                    SqlDataReader sdrUser = sqlCheckValidUser.ExecuteReader();
                    
                    if (!sdrUser.HasRows)
                    {
                        lblLoginFailure.ForeColor = System.Drawing.Color.DarkRed;
                        lblLoginFailure.Text = "Invalid user name or password";
                        txtUserName.Focus();
                    }
                    else
                    {
                        while (sdrUser.Read())
                        {
                            HttpContext.Current.Session["UsersFullName"] = sdrUser.GetString(0);
                            lblLoginFailure.Text = sdrUser.GetString(0);
                            Response.Redirect("~/default.aspx", false);
                        }
                    }
                    sdrUser.Close();
                    dbConn.Close();
                }
                catch (System.Exception ex)
                {
                    dbConn.Close();
                    lblLoginFailure.ForeColor = System.Drawing.Color.DarkRed;
                    lblLoginFailure.Text = ex.ToString();
                }
            }

        }

    }
}