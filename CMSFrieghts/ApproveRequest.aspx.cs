using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSFrieghts
{
    public partial class ApproveRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ApproveView_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var Command = e.CommandName;
            if (Command.Equals("ApproveShipping"))
            {
                int indexRow = int.Parse(e.CommandArgument.ToString());
                int IDselected = int.Parse(ApproveView.Rows[indexRow].Cells[0].Text);
                var ApproveStatus = WebConfigurationManager.AppSettings["StatusApproved"];

                SqlConnection newcon = new SqlConnection();
                newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string approveShippingRequest = "UPDATE CustomerShipping set status = @status where shipping_id = @shipid;";
                SqlCommand approveShippingCMD = new SqlCommand(approveShippingRequest, newcon);

                approveShippingCMD.Parameters.Add("@status", SqlDbType.NVarChar);
                approveShippingCMD.Parameters["@status"].Value = ApproveStatus;
                approveShippingCMD.Parameters.Add("@shipid", SqlDbType.Int);
                approveShippingCMD.Parameters["@shipid"].Value = IDselected;

                newcon.Open();
                int approveSuccess = approveShippingCMD.ExecuteNonQuery();
                newcon.Close();

                if (approveSuccess == 0)
                {

                }
                else
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
            else if (Command.Equals("RejectShipping"))
            {
                int indexRow = int.Parse(e.CommandArgument.ToString());
                int IDselected = int.Parse(ApproveView.Rows[indexRow].Cells[0].Text);
                var ApproveStatus = WebConfigurationManager.AppSettings["StatusRejected"];

                SqlConnection newcon = new SqlConnection();
                newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string approveShippingRequest = "UPDATE CustomerShipping set status = @status where shipping_id = @shipid;";
                SqlCommand approveShippingCMD = new SqlCommand(approveShippingRequest, newcon);

                approveShippingCMD.Parameters.Add("@status", SqlDbType.NVarChar);
                approveShippingCMD.Parameters["@status"].Value = ApproveStatus;
                approveShippingCMD.Parameters.Add("@shipid", SqlDbType.Int);
                approveShippingCMD.Parameters["@shipid"].Value = IDselected;

                newcon.Open();
                int approveSuccess = approveShippingCMD.ExecuteNonQuery();
                newcon.Close();

                if (approveSuccess == 0)
                {

                }
                else
                {
                    Response.Redirect(Request.RawUrl);
                }
            }
        }
        
    }
}