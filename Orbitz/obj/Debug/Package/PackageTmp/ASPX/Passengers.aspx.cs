using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.Entity;
using System.Data;

namespace Orbitz.ASPX
{
    public partial class Passengers : System.Web.UI.Page
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
                BindFlightInformation();
        }

        /// <summary>
        /// Binds the flight information to the data list
        /// </summary>
        private void BindFlightInformation()
        {
            //Declaratoins
            DataTable dtFlightInformation = new DataTable();
            Booking booking = (Booking)Session["Booking"];


            //Add the flight information columns
            dtFlightInformation.Columns.Add("AirlineName", typeof(System.String));
            dtFlightInformation.Columns.Add("ArrivalTime", typeof(System.String));
            dtFlightInformation.Columns.Add("DepartureTime", typeof(System.String));
            dtFlightInformation.Columns.Add("BaggageAllowance", typeof(System.String));
            dtFlightInformation.Columns.Add("Fare", typeof(System.String));
            dtFlightInformation.Columns.Add("FlightClass", typeof(System.String));
            dtFlightInformation.Columns.Add("From", typeof(System.String));
            dtFlightInformation.Columns.Add("To", typeof(System.String));
            dtFlightInformation.Columns.Add("TravelDay", typeof(System.String));
            dtFlightInformation.Columns.Add("TravelDuration", typeof(System.String));

            //Create a new row of information
            DataRow info = dtFlightInformation.NewRow();

            info["AirlineName"] = booking.flightInformation.AirlineName;
            info["ArrivalTime"] = booking.flightInformation.ArrivalTime;
            info["DepartureTime"] = booking.flightInformation.DepartureTime;
            info["BaggageAllowance"] = booking.flightInformation.BaggageAllowance;
            info["Fare"] = booking.flightInformation.Fare;
            info["FlightClass"] = booking.flightInformation.FlightClass;
            info["From"] = booking.flightInformation.From;
            info["To"] = booking.flightInformation.To;
            info["TravelDay"] = booking.flightInformation.TravelDay;
            info["TravelDuration"] = booking.flightInformation.TravelDuration;

            dtFlightInformation.Rows.Add(info);

            //Bind the flight information
            dlFlightInformation.DataSource = dtFlightInformation;
            dlFlightInformation.DataBind();
        }
        
        /// <summary>
        /// Gets triggered when the user clicks on proceed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ProceedToPayment_Click(object sender, EventArgs e)
        {
            PersistPassengerData();

            Response.Redirect("Payment.aspx");
        }

        /// <summary>
        /// Persist the passenger data to session
        /// </summary>
        private void PersistPassengerData()
        {
            //Declarations
            Booking booking;
            List<Passenger> passengers = new List<Passenger>();
            Int32 age;

            //Get the passengers
            for (int index = 1; index < 6; index++)
            {
                TextBox txtName = (TextBox)passengerDetails.FindControl("txtName" + index);
                TextBox txtAge = (TextBox)passengerDetails.FindControl("txtAge" + index);
                TextBox txtPassport = (TextBox)passengerDetails.FindControl("txtPassport" + index);
                TextBox txtNationality = (TextBox)passengerDetails.FindControl("txtNationality" + index);

                //If all the passenger details are present
                if (txtName.Text.ToString().Trim() != String.Empty && txtAge.Text.ToString().Trim() != String.Empty &&
                   txtPassport.Text.ToString().Trim() != String.Empty && txtNationality.Text.ToString().Trim() != String.Empty)
                {
                    Passenger passenger = new Passenger
                    {                        
                        Nationality = txtNationality.Text,
                        PassengerName = txtName.Text,
                        PassportNumber = txtPassport.Text
                    };

                    //Get the age
                    Int32.TryParse(txtAge.Text, out age);

                    passenger.Age = age;

                    //Add the passenger
                    passengers.Add(passenger);
                }

            }

            //Get the booking
            booking = (Booking) Session["Booking"];

            //Add the passengers
            booking.Passengers = passengers;
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


            if(Session["Booking"] != null)
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
                }

            }

            return information;
        }
    }
}

