using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.BAL;
using Orbitz.Code.Entity;

namespace Orbitz.ASPX
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Declaratoins
            Boolean hasRegistered = false;
            String message = String.Empty;

            //Check for the registration query string
            if (Request.QueryString.HasKeys())
            {
                //Get the status of registration
                Boolean.TryParse(Request.QueryString.Get("HasRegistered"), out hasRegistered);

                //If the user has registered
                if (!hasRegistered)
                {
                    message = "Unable to register";

                    //Display the message
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('" + message + "');", true);
                }
            }
        }


        /// <summary>
        /// Gets triggered when the user clicks on create user button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //Declarations
            User user = new User();

            user.EmailID = Email.Text;
            user.Password = Password.Text;
                      

            //If the user has successfully registered
            if (RegisterBLC.Register(user))
                Response.Redirect("SearchFlights.aspx");
            else
                Response.Redirect(Request.RawUrl + "?HasRegistered=false");

        }

    }
}
