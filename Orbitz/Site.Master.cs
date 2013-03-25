using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.Entity;

namespace Orbitz
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if its a valid user session
            if (Session["User"] != null)
            {
                User user = (User)Session["User"];
                HeadLoginName.Text = user.EmailID;

                login.Style.Add(HtmlTextWriterStyle.Display, "none");
                logout.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                login.Style.Add(HtmlTextWriterStyle.Display, "block");
                logout.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            
            
        }



        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            //Clear the session
            Session.Clear();

            Response.Redirect("Login.aspx");

        }

    }
}
