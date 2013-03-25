using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.BAL;
using Orbitz.Code.Utility;
using Orbitz.Code.Entity;
using System.Data;

namespace Orbitz.ASPX
{
    public partial class SearchFlights : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if its a valid user session
            if (Session["User"] != null)
            {
                //Bind the travel details
                BindTravelDetails();

                //Display the message if required
                DisplayPaymentMessage();
            }
            else
                Response.Redirect("Login.aspx");


        }

        /// <summary>
        /// Display's the payment success message
        /// </summary>
        private void DisplayPaymentMessage()
        {
            //Declarations
            String message = String.Empty;
            Booking booking;

            if(Session["Booking"] != null)
            {
                
                //Get the booking
                booking = (Booking)Session["Booking"];

                if (booking.ReservationNumber > 0)
                {
                    message = @"Your flight has been booked successfully.\nYour reservation number is " + "RESORBTZ" + booking.ReservationNumber;

                    Session.Remove("Booking");

                    //Display the message            
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);

                }

            }
        }

        /// <summary>
        /// Gets triggered when the user clicks on search button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Declarations
            DataTable dtFlights;
            Int32 id = Int32.MinValue;
            TravelDetail travelDetail = new TravelDetail();
            
            //Add the travel details
            Int32.TryParse(drpFlyingFrom.SelectedValue, out id);
            travelDetail.FromAirportID = id;
            Int32.TryParse(drpFlyingTo.SelectedValue, out id);
            travelDetail.ToAirportID = id;

            travelDetail.FlightClass = drpClass.SelectedValue;
            travelDetail.TravelDay = BLCUtility.GetDayOfWeek(drpDay.SelectedValue, drpMonth.SelectedValue, drpYear.SelectedValue);
           
            //Get the flights
            dtFlights = SearchFilghtsBLC.GetFlights(travelDetail);

            Session.Add("Flights", dtFlights);

            grdFlights.DataSource = dtFlights;
            grdFlights.DataBind();
        }


        #region Private Methods

        /// <summary>
        /// Binds the travel details 
        /// </summary>
        private void BindTravelDetails()
        {
            //Bind the source and destination for the flights
            if (!Page.IsPostBack)
            {
                drpFlyingFrom.DataSource = SearchFilghtsBLC.GetAirports();
                drpFlyingTo.DataSource = SearchFilghtsBLC.GetAirports();
                drpDay.DataSource = BLCUtility.GetDays();


                drpFlyingFrom.DataBind();
                drpFlyingTo.DataBind();
                drpDay.DataBind();
            }



        }


        #endregion

        protected void grdFlights_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Declarations
            int index = 0;
            Int32 flightID = int.MinValue;
            FlightInformation flightInformation;
            DataRow drData;

            //Get the flight which is getting booked
            if (e.CommandName == "Select")
            {
                //Get the index
                Int32.TryParse(e.CommandArgument.ToString(), out index);

                DataTable dtFlights = (DataTable)Session["Flights"];

                //Get the data
                drData = dtFlights.Rows[index];

                //Get the flight ID
                Int32.TryParse(drData["FlightID"].ToString(), out flightID);

                Booking booking = new Booking();
                booking.User = (User)Session["User"];

                booking.FlightID = flightID;

                //Get the flight details
                flightInformation = new FlightInformation
                {
                    FlightClass = drpClass.Items[drpClass.SelectedIndex].Text,
                    From = drpFlyingFrom.Items[drpFlyingFrom.SelectedIndex].Text,
                    To = drpFlyingTo.Items[drpFlyingTo.SelectedIndex].Text,
                    TravelDay = drpDay.Items[drpDay.SelectedIndex].Value + " " + drpMonth.Items[drpMonth.SelectedIndex].Value + " " + drpYear.Items[drpYear.SelectedIndex].Value,
                    AirlineName = drData["Airline"].ToString(),
                    ArrivalTime = drData["ArrivalTime"].ToString(),
                    DepartureTime = drData["DepartureTime"].ToString(),
                    BaggageAllowance = drData["BaggageAllowance"].ToString(),
                    Fare = drData["Fare"].ToString(),
                    Manufacturer = drData["Aircraft"].ToString(),
                    TravelDuration = drData["FlightDuration"].ToString()                   
                };

                //Set the flight information
                booking.flightInformation = flightInformation;

                //Add the booking data to session
                Session.Add("Booking", booking);

                //Redirect to the passengers page
                Response.Redirect("Passengers.aspx");
            }
        }
    }
}