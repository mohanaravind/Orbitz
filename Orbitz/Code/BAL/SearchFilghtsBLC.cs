using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Orbitz.Code.DAL;
using Orbitz.Code.Entity;

namespace Orbitz.Code.BAL
{
    public class SearchFilghtsBLC
    {
        public static DataTable GetFlights(TravelDetail travelDetail)
        {
            //Declaratoins
            DataTable dtFlights;           

            //Make the call to DB
            dtFlights = SearchFlightsDAC.GetFlights(travelDetail);

            return dtFlights;
        }

        public static DataTable GetAirports()
        {
            //Declaratoins
            DataTable dtAirports;

            //Make the call to DB
            dtAirports = SearchFlightsDAC.GetAirports();

            return dtAirports;
        }
    }
}