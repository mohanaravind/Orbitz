using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.BLC;

namespace Orbitz.ASPX
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //Declarations  
            LoginBLC loginBLC = new LoginBLC();
            Orbitz.Code.Entity.User user = new Code.Entity.User();

            //Construct the user
            user.EmailID  = UserName.Text;
            user.Password = Password.Text;
                        
            //Authenticate the user
            if (loginBLC.Authenticate(user))
            {               
                //Add the user to the session
                Session.Add("User", user);
                Response.Redirect("SearchFlights.aspx");
            }


           
        }
    }
}
