using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using CMSFrieghts.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Configuration;

namespace CMSFrieghts.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            SqlConnection newcon = new SqlConnection();
            newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string registerNewCustomer = "INSERT INTO UsersAccount (email_address,password,credentials,company_name,person_incharge,contact_number) VALUES (@emailaddress,@password,@credentials,@companyname,@personname,@contactno)";
            SqlCommand registerNewCustomerCMD = new SqlCommand(registerNewCustomer, newcon);
            registerNewCustomerCMD.Parameters.Add("@emailaddress", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@emailaddress"].Value = Email.Text;
            registerNewCustomerCMD.Parameters.Add("@password", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@password"].Value = Password.Text;
            registerNewCustomerCMD.Parameters.Add("@credentials", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@credentials"].Value = WebConfigurationManager.AppSettings["CustomerCredentials"];
            registerNewCustomerCMD.Parameters.Add("@companyname", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@companyname"].Value = CompanyName.Text;
            registerNewCustomerCMD.Parameters.Add("@personname", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@personname"].Value = PersonInCharge.Text;
            registerNewCustomerCMD.Parameters.Add("@contactno", SqlDbType.NVarChar);
            registerNewCustomerCMD.Parameters["@contactno"].Value = ContactNo.Text;

            newcon.Open();
            int successfullyRegister = registerNewCustomerCMD.ExecuteNonQuery();
            newcon.Close();

            if (successfullyRegister == 0)
            {

            }
            else
            {
                Response.Redirect("~/Account/Login", false);
            }

        }
    }
}