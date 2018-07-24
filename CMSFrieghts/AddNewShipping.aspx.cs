using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CMSFrieghts
{
    public partial class AddNewShipping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeparturePort.Items[0].Attributes.Add("disabled", "disabled");
            ArrivalPort.Items[0].Attributes.Add("disabled", "disabled");
            ShipType.Items[0].Attributes.Add("disabled", "disabled");
            ContainerType.Items[0].Attributes.Add("disabled", "disabled");

            
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            var descriptions = description.Text;
            var shipType = ShipType.SelectedItem.ToString();
            var containerType = ContainerType.SelectedItem.ToString();
            DateTime currentdate = DateTime.Now;
            var departurePort = DeparturePort.SelectedItem.ToString();
            var arrivalPort = ArrivalPort.SelectedItem.ToString();
            var Shippingstatus = WebConfigurationManager.AppSettings["Status"];
            float price = float.Parse(estimatedPrice.Text);

            SqlConnection newcon = new SqlConnection();
            newcon.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            string addNewShippingRequest = "INSERT INTO CustomerShipping (shipping_description, ship_type, container_type, request_date, departure_port, arrival_port, status, price)" +
                "VALUES (@shipdes, @shiptype, @containertype, @requestdate, @departureport, @arrivalport, @statuses, @prices);";
            SqlCommand NewShippingRequestCMD = new SqlCommand(addNewShippingRequest, newcon);

            NewShippingRequestCMD.Parameters.Add("@shipdes", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@shipdes"].Value = descriptions;
            NewShippingRequestCMD.Parameters.Add("@shiptype", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@shiptype"].Value = shipType;
            NewShippingRequestCMD.Parameters.Add("@containertype", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@containertype"].Value = containerType;
            NewShippingRequestCMD.Parameters.Add("@requestdate", SqlDbType.DateTime);
            NewShippingRequestCMD.Parameters["@requestdate"].Value = currentdate;
            NewShippingRequestCMD.Parameters.Add("@departureport", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@departureport"].Value = departurePort;
            NewShippingRequestCMD.Parameters.Add("@arrivalport", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@arrivalport"].Value = arrivalPort;
            NewShippingRequestCMD.Parameters.Add("@statuses", SqlDbType.NVarChar);
            NewShippingRequestCMD.Parameters["@statuses"].Value = Shippingstatus;
            NewShippingRequestCMD.Parameters.Add("@prices", SqlDbType.Float);
            NewShippingRequestCMD.Parameters["@prices"].Value = price;

            newcon.Open();
            int addSuccessful = NewShippingRequestCMD.ExecuteNonQuery();
            newcon.Close();

            if(addSuccessful == 0)
            {

            }
            else
            {
                Response.Redirect("/ShippingStatus.aspx", false);
            }

        }

        protected void DeparturePort_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void ArrivalPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void ShipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void ContainerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            double PriceforPort;
            double TotalPrice = 0.00;

            if(!DeparturePort.SelectedIndex.Equals(0) && !ArrivalPort.SelectedIndex.Equals(0) && !ArrivalPort.SelectedIndex.Equals(!DeparturePort.SelectedIndex.Equals(0)))
            {
                var departure_port = DeparturePort.SelectedValue;
                var arrival_port = ArrivalPort.SelectedValue;

                double portD_price = double.Parse(departure_port.Split(',')[0]);
                double portA_price = double.Parse(arrival_port.Split(',')[0]);

                PriceforPort = portD_price + portA_price;
                TotalPrice = TotalPrice + PriceforPort;
            }

            if (!ShipType.SelectedIndex.Equals(0))
            {
                double ship_price = double.Parse(ShipType.SelectedValue.Split(',')[0]);
                TotalPrice = TotalPrice + ship_price;
            }

            if (!ContainerType.SelectedIndex.Equals(0))
            {
                double container_price = double.Parse(ContainerType.SelectedValue.Split(',')[0]);

                TotalPrice = TotalPrice + container_price;
            }

            estimatedPrice.Text = TotalPrice.ToString();

        }
    }
}