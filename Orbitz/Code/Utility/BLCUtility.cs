using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Orbitz.Code.Utility
{
    public class BLCUtility
    {
        /// <summary>
        /// Returns the number of days
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDays()
        {
            //Declarations
            DataTable days = new DataTable();

            days.Columns.Add("Day", typeof(String));

            //Construct the days
            for (int index = 1; index < 32; index++)
            {
                //Add a new day
                DataRow day = days.NewRow();

                day["Day"] = index.ToString();

                //Add the day
                days.Rows.Add(day);
            }

            return days;

        }

        /// <summary>
        /// Gets the day of week for the selected date
        /// </summary>
        /// <param name="sDay"></param>
        /// <param name="sMonth"></param>
        /// <param name="sYear"></param>
        /// <returns></returns>
        public static String GetDayOfWeek(String sDay, String sMonth, String sYear)
        {
            //Declarations
            String dayOfWeek = String.Empty;
            Int32 day,month,year;

            //Make the conversions
            Int32.TryParse(sDay, out day);
            Int32.TryParse(sMonth, out month);
            Int32.TryParse(sYear, out year);


            DateTime dt = new DateTime(year, month, day);

            //Get the day of week
            dayOfWeek = dt.DayOfWeek.ToString();

            return dayOfWeek;
        }

    }
}