using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Code.Entity;
using Orbitz.Utility;

namespace Orbitz.Code.DAL
{
    public class RegisterDAC
    {
        /// <summary>
        /// Inserts the user and updates the user's entity with user id
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static User InsertUser(User user)
        {
            //Declaratoins
            String procedure = "sp_createUser";
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