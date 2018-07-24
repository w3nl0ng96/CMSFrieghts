using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CMSFrieghts
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            var Command = e.CommandName;
            if (Command.Equals("DeleteShipping"))
            {
                int indexRow = int.Parse(e.CommandArgument.ToString());
                int IDselected = int.Parse(GridView1.Rows[indexRow].Cells[0].Text);
                var ShippingStatus = GridView1.Rows[indexRow].Cells[7].Text;

                if(!ShippingStatus.Equals("Pending Approval") && !ShippingStatus.Equals("Rejected"))
                {
                    Type type = this.GetType();
                    ClientScriptManager csm = Page.ClientScript;
                    if (!csm.IsStartupScriptRegistered(type, "PopupScript"))
                    {
                        String errormessage = "alert('Pending Approval or Reject shipping status only can be deleted!');";
                        csm.RegisterStartupScript(type, "PopupScript", errormessage, true);
                    }
                }
                else
                {
                    SqlConnection newcon = new SqlConnection();
                    newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    string deleteShippingRequest = "DELETE FROM CustomerShipping where shipping_id = @ship_id;";
                    SqlCommand deleteShippingCMD = new SqlCommand(deleteShippingRequest, newcon);

                    deleteShippingCMD.Parameters.Add("@ship_id", SqlDbType.Int);
                    deleteShippingCMD.Parameters["@ship_id"].Value = IDselected;

                    newcon.Open();
                    int deleteSuccess = deleteShippingCMD.ExecuteNonQuery();
                    newcon.Close();

                    if(deleteSuccess == 0)
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
}