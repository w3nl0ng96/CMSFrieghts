using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CMSFrieghts.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;


namespace CMSFrieghts.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["ID"] = "";
            Session["EmailAddress"] = "";
            Session["Credentials"] = "";
            Session["LoggedIn"] = false;

        }

        protected void LogIn(object sender, EventArgs e)
        {
            SqlConnection newcon = new SqlConnection();
            try
            {
                newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                newcon.Open();

                SqlCommand login = new SqlCommand("SELECT id, email_address, password, credentials from UsersAccount where email_address = @emailAddress and password = @password", newcon);
                login.Parameters.Add(new SqlParameter("@emailAddress", Email.Text));
                login.Parameters.Add(new SqlParameter("@password", Password.Text));
                SqlDataReader dataReader = login.ExecuteReader();

                if (dataReader.Read())
                {
                    var userID = dataReader["id"].ToString();
                    var credential = dataReader["credentials"].ToString();
                    var password = dataReader["password"].ToString();
                    newcon.Close();
                    dataReader.Close();

                    Session["ID"] = userID;
                    Session["EmailAddress"] = Email.Text;
                    Session["Credentials"] = credential;
                    Session["LoggedIn"] = true;

                    if (credential.Equals("Customer"))
                    {
                        Response.Redirect("/ShippingStatus", false);
                    }
                    if (credential.Equals("Staff"))
                    {
                        Response.Redirect("/ApproveRequest", false);
                    }

                }
                else
                {
                    Type type = this.GetType();
                    ClientScriptManager csm = Page.ClientScript;
                    if (!csm.IsStartupScriptRegistered(type, "PopupScript"))
                    {
                        String errormessage = "alert('Incorrect email address or password! Please enter again');";
                        csm.RegisterStartupScript(type, "PopupScript", errormessage, true);
                    }
                }

                if (!dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
            catch
            {

            }
            finally
            {
                if (newcon.State == System.Data.ConnectionState.Open)
                {
                    newcon.Close();
                    newcon.Dispose();
                }
            }
        }
    }
}