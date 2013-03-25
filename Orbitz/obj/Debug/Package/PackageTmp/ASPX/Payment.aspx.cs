using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Orbitz.Code.Entity;

namespace Orbitz.ASPX
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if the session is expired
            if (Session["User"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void ConfirmAndPay_Click(object sender, EventArgs e)
        {
            PersistCardDetails();

            Response.Redirect("Confirm.aspx");
        }

        /// <summary>
        /// Persists the credit card details to booking for this session
        /// </summary>
        private void PersistCardDetails()
        {
            //Declarations
            Booking booking;
            CreditCardDetails creditCardDetails;
            Int32 phoneNumber, cvv, expiryYear, expiryMonth;
                        
            //Get the booking instance from session
            booking = (Booking)Session["Booking"];

            Int32.TryParse(txtMonth.Text, out expiryMonth);
            Int32.TryParse(txtPhoneNumber.Text, out phoneNumber);
            Int32.TryParse(txtCVV.Text, out cvv);
            Int32.TryParse(txtYear.Text, out expiryYear);

            creditCardDetails = new CreditCardDetails
            {
                 BillingAddress = txtAddress.Text,
                 CardType = txtNumber.Text,
                 NameOnCard = txtName.Text,
                 ExpiryMonth = expiryMonth,
                 ExpiryYear = expiryYear,
                 PhoneNumber = phoneNumber,
                 CVVNumber = cvv                
            };

            //Set the card details
            booking.CardDetails = creditCardDetails;            
        }
    }
}