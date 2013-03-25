using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.Entity;
using Orbitz.Code.BAL;
using System.Data;

namespace Orbitz.ASPX
{
    public partial class Confirm : System.Web.UI.Page
    {
        /// <summary>
        /// Gets triggered when the page gets loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if the session is expired
            if (Session["User"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                DataTable dtInformations = new DataTable();

                dlFlightInformation.DataSource = dtInformations;
                dlFlightInformation.DataBind();
            }
        }

        /// <summary>
        /// Gets triggered when the user clicks on pay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Pay_Click(object sender, EventArgs e)
        {
            //Declarations
            Booking booking;            

            //Get the booking
            booking = (Booking)Session["Booking"];

            //Confirm the booking
            ConfirmBLC.ConfirmBooking(booking);

            Response.Redirect("SearchFlights.aspx");
        }

        /// <summary>
        /// Gets triggered when the user clicks on cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkCancel_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        /// <summary>
        /// Returns the corresponding information
        /// </summary>
        /// <param name="informationField"></param>
        /// <returns></returns>
        public String GetInformation(String informationField)
        {
            //Declaratoins
            String information = String.Empty;


            if (Session["Booking"] != null)
            {
                Booking booking = (Booking)Session["Booking"];
                FlightInformation flightInformation = booking.flightInformation;

                switch (informationField)
                {
                    case "Airline":
                        information = flightInformation.AirlineName;
                        break;
                    case "ArrivalTime":
                        information = flightInformation.ArrivalTime;
                        break;
                    case "DepartureTime":
                        information = flightInformation.DepartureTime;
                        break;
                    case "BaggageAllowance":
                        information = flightInformation.BaggageAllowance;
                        break;
                    case "Fare":
                        information = flightInformation.Fare;
                        break;
                    case "FlightClass":
                        information = flightInformation.FlightClass;
                        break;
                    case "From":
                        information = flightInformation.From;
                        break;
                    case "To":
                        information = flightInformation.To;
                        break;
                    case "TravelDay":
                        information = flightInformation.TravelDay;
                        break;
                    case "TravelDuration":
                        information = flightInformation.TravelDuration;
                        break;
                    case "Passengers":
                        foreach (Passenger passenger in booking.Passengers)
                        {
                            information = information + passenger.PassengerName + " | " + passenger.PassportNumber + " | " + passenger.Nationality 
                                            + " | " + passenger.Age + "   ";
                        }
                        break;
                    case "CardNumber":
                        information = booking.CardDetails.CardNumber.ToString();
                        break;
                }

            }

            return information;
        }
    
    }
}