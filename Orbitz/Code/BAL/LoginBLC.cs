using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orbitz.Code.Entity;
using Orbitz.Code.DAL;


namespace Orbitz.Code.BLC
{
    public class LoginBLC
    {
        public User _user;
               
        /// <summary>
        /// Authenticates the user to the system
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>True if authenticated else false</returns>
        public Boolean Authenticate(User user)
        {
            //Declarations
            Boolean authenticated = false;
            
            //Populate the user data
            user = LoginDAC.GetUser(user);

            //Check whether the user is authorized
            authenticated = user.UserID > 0;

            _user = user;
                
            return authenticated;
        }

    }
}