using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CMSFrieghts.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(Session["ID"].ToString());
            var password = "";

            SqlConnection newcon = new SqlConnection();
            newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string getPassword = "SELECT password FROM UsersAccount where id = @userid;";
            SqlCommand getPasswordCMD = new SqlCommand(getPassword, newcon);
            getPasswordCMD.Parameters.Add("@userid", SqlDbType.Int);
            getPasswordCMD.Parameters["@userid"].Value = userID;

            newcon.Open();
            SqlDataReader dataReader = getPasswordCMD.ExecuteReader();
            if (dataReader.Read())
            {
                password = dataReader["password"].ToString();
                dataReader.Close();
            }
            newcon.Close();

            if (password.Equals(ConfirmPassword.Text))
            {
                Type type = this.GetType();
                ClientScriptManager csm = Page.ClientScript;
                if (!csm.IsStartupScriptRegistered(type, "PopupScript"))
                {
                    String errormessage = "alert('New Password cannot be the same as Old Password!');";
                    csm.RegisterStartupScript(type, "PopupScript", errormessage, true);
                }
            }
            else
            {
                string newPassword = "UPDATE UsersAccount SET password = @newpassword where id = @userid;";
                SqlCommand newPasswordCMD = new SqlCommand(newPassword, newcon);
                newPasswordCMD.Parameters.Add("@newpassword", SqlDbType.NVarChar);
                newPasswordCMD.Parameters["@newpassword"].Value = ConfirmPassword.Text;
                newPasswordCMD.Parameters.Add("@userid", SqlDbType.Int);
                newPasswordCMD.Parameters["@userid"].Value = userID;
                newcon.Open();

                int changeSuccessful = newPasswordCMD.ExecuteNonQuery();
                newcon.Close();

                if(changeSuccessful == 0)
                {

                }
                else
                {
                    Response.Redirect("/ShippingStatus.aspx", false);
                }
            }

        }
    }
}