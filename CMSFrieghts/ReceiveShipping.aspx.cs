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
    public partial class ReceiveShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReceiveShipping_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var Command = e.CommandName;
            if (Command.Equals("ReceiveShipping"))
            {
                int indexRow = int.Parse(e.CommandArgument.ToString());
                int IDselected = int.Parse(ReceiveView.Rows[indexRow].Cells[0].Text);
                var ApproveStatus = WebConfigurationManager.AppSettings["StatusReceive"];

                SqlConnection newcon = new SqlConnection();
                newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                string receiveShippingRequest = "UPDATE CustomerShipping set status = @status where shipping_id = @shipid;";
                SqlCommand receiveShippingCMD = new SqlCommand(receiveShippingRequest, newcon);

                receiveShippingCMD.Parameters.Add("@status", SqlDbType.NVarChar);
                receiveShippingCMD.Parameters["@status"].Value = ApproveStatus;
                receiveShippingCMD.Parameters.Add("@shipid", SqlDbType.Int);
                receiveShippingCMD.Parameters["@shipid"].Value = IDselected;

                newcon.Open();
                int receiveSuccess = receiveShippingCMD.ExecuteNonQuery();
                newcon.Close();

                if (receiveSuccess == 0)
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