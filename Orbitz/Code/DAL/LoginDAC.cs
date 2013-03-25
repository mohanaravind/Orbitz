using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Utility;
using Orbitz.Code.Entity;

namespace Orbitz.Code.DAL
{
    public class LoginDAC
    {
        /// <summary>
        /// Updates the user entity from data with database
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if authenticated else false</returns>
        public static User GetUser(User user)
        {
            //Declaratoins
            String procedure = "sp_getUser";
            Queue<Object> input = new Queue<object>();
            Int32 userID = Int32.MinValue;
            
            //Create the input
            input.Enqueue(user.EmailID);
            input.Enqueue(user.Password);          

            //Make the call to DB
            userID = OracleDBUtility.GetInstance().GetOutput(procedure, input);
            
            //Update the user ID
            user.UserID = userID;

            return user;
        }
    }
}