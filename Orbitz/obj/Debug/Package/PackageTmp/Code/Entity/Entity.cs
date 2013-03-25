using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orbitz.Code.Entity
{
    public class User
    {
        public Int32 UserID {get; set;}
        public String EmailID {get; set;}
        public String Password { get; set;}
    }

    public class TravelDetail
    {
        public Int32 FromAirportID {get; set;}
        public Int32 ToAirportID { get; set; }
        public String FlightClass {get; set;}
        public String TravelDay { get; set; }
    }

    public class Passenger
    {
        public String PassengerName { get; set; }
        public Int32 Age { get; set; }
        public String PassportNumber { get; set; }
        public String Nationality { get; set; }
        public Int32 ReservationID { get; set; }
    }

    public class CreditCardDetails
    {
        public Int32 CreditCardID { get; set; }
        public Int32 CardNumber { get; set; }
        public Int32 ExpiryMonth { get; set; }
        public Int32 ExpiryYear { get; set; }
        public Int32 CVVNumber { get; set; }
        public String NameOnCard { get; set; }
        public String CardType { get; set; }
        public String BillingAddress { get; set; }
        public Int32 PhoneNumber { get; set; }
    }

    public class FlightInformation
    {
        public String AirlineName { get; set; }
        public String BaggageAllowance { get; set; }
        public String Fare { get; set; }
        public String ArrivalTime { get; set; }
        public String DepartureTime { get; set; }
        public String TravelDuration { get; set; }
        public String Manufacturer { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public String FlightClass { get; set; }
        public String TravelDay { get; set; }
    }


    public class Booking
    {
        public FlightInformation flightInformation { get; set; }
        public TravelDetail travelDetail { get; set; }
        public List<Passenger> Passengers { get; set; }
        public CreditCardDetails CardDetails { get; set; }
        public User User { get; set; }
        public Int32 FlightID { get; set; }
        public Int32 BookingID { get; set; }
        public Int32 ReservationNumber { get; set; }
    }


    public class Aircrafts
    {
        public Int32 AircraftID {get; set;}
        public String Manufacturer { get; set;}
        public String ModelNumber { get; set;}
    }

    public class Airlines
    {
        public Int32 AirlineID {get; set;}
        public String AirlineName {get; set;}
    }

    public class Airports
    {
        public Int32 AirportID {get; set;}
        public String AirportName {get; set;}
        public Int32 CityID{get; set;}
    }

    public class Cities
    {
        public Int32 CityID {get; set;}
        public String CityName {get; set;}
        public Int32 CityCode {get; set;}
    }





    public class Payments
    {
        public Int32 PaymentID {get; set;}
        public Int32 PaymentDate {get; set;}
        public Int32 CreditCardID {get;set;}
        public Int32 ReservationID {get; set;}
    }
}