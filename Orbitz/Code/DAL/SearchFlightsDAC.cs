using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Orbitz.Utility;
using Orbitz.Code.Entity;

namespace Orbitz.Code.DAL
{
    public class SearchFlightsDAC
    {
        public static DataTable GetFlights(TravelDetail travelDetail)
        {
            //Declaratoins
            DataTable dtFlights;
            String procedure = "sp_fetchFlights";
            Queue<Object> input = new Queue<object>();

            //Add the input parameters
            input.Enqueue(travelDetail.FromAirportID);
            input.Enqueue(travelDetail.ToAirportID);
            input.Enqueue(travelDetail.FlightClass);
            input.Enqueue(travelDetail.TravelDay);

            //Make the call to DB
            dtFlights = OracleDBUtility.GetInstance().GetData(procedure, input);

            return dtFlights;
        }

        public static DataTable GetAirports()
        {
            //Declaratoins
            DataTable dtAirports;
            String procedure = "sp_fetchAirports";

            //Make the call to DB
            dtAirports = OracleDBUtility.GetInstance().GetData(procedure, null);

            return dtAirports;
        }
    }
}