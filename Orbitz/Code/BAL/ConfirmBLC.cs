using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Code.Entity;
using Orbitz.Code.DAL;

namespace Orbitz.Code.BAL
{
    public class ConfirmBLC
    {

        /// <summary>
        /// Confirms the booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        internal static Booking ConfirmBooking(Booking booking)
        {
            booking = ConfirmDAC.Reserve(booking);
            
            ConfirmDAC.AddPassengers(booking);

            ConfirmDAC.Pay(booking);

            return booking;
        }
    }
}