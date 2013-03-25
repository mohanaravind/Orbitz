using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Code.Entity;
using Orbitz.Code.DAL;

namespace Orbitz.Code.BAL
{
    public class RegisterBLC
    {
        /// <summary>
        /// Registers the user to the system
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if registered else false</returns>
        public static Boolean Register(User user)
        {
            //Declarations
            Boolean registered = false;

            //Populate the user data
            user = RegisterDAC.InsertUser(user);

            //Check whether the user is authorized
            registered = user.UserID > 0;

            return registered;
        }
    }
}