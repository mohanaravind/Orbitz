using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Code.Entity;
using Orbitz.Utility;

namespace Orbitz.Code.DAL
{
    public class ConfirmDAC
    {

        /// <summary>
        /// Reserves the booking for the user
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public static Booking Reserve(Booking booking)
        {
            //Declaratoins
            String procedure = "sp_reserve";
            Queue<Object> input = new Queue<object>();
            Int32 bookingID = Int32.MinValue;

            //Create the input
            input.Enqueue(booking.FlightID);
            input.Enqueue(booking.User.UserID);

            //Make the call to DB
            bookingID = OracleDBUtility.GetInstance().GetOutput(procedure, input);

            //Update the user ID
            booking.BookingID = bookingID;

            return booking;
        }

        /// <summary>
        /// Add a passengers
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        public static void AddPassengers(Booking booking)
        {
            //Declaratoins
            String procedure = "sp_addPassenger";
            Queue<Object> input;
 
            //Add the passenger
            foreach (Passenger passenger in booking.Passengers)
            {
                input = new Queue<object>();

                input.Enqueue(passenger.PassengerName);
                input.Enqueue(passenger.Age);
                input.Enqueue(passenger.PassportNumber);
                input.Enqueue(passenger.Nationality);
                input.Enqueue(booking.BookingID);

                //Make the call to DB
                OracleDBUtility.GetInstance().GetOutput(procedure, input);
            }
        }

        /// <summary>
        /// Make the payment
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public static Booking Pay(Booking booking)
        {
            //Declaratoins
            String procedure = "sp_pay";
            Queue<Object> input = new Queue<object>();
            Int32 bookingID = Int32.MinValue;

            //Create the input
            input.Enqueue(booking.BookingID);
            input.Enqueue(booking.CardDetails.CardNumber);
            input.Enqueue(booking.CardDetails.ExpiryMonth);
            input.Enqueue(booking.CardDetails.ExpiryYear);
            input.Enqueue(booking.CardDetails.CVVNumber);
            input.Enqueue(booking.CardDetails.NameOnCard);
            input.Enqueue(booking.CardDetails.CardType);
            input.Enqueue(booking.CardDetails.BillingAddress);
            input.Enqueue(booking.CardDetails.PhoneNumber);    

            //Make the call to DB
            bookingID = OracleDBUtility.GetInstance().GetOutput(procedure, input);

            //Update the user ID
            booking.ReservationNumber = bookingID;

            return booking;

        }

    }
}