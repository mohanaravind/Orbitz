<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Payment.aspx.cs" Inherits="Orbitz.ASPX.Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Payment
    </h2>
    <p>
        Please enter your card details.
    </p>
    <div class="ASPXInfo">
        <fieldset class="login">
            <legend>Card Information</legend>
            <table class="style1">
                <tr>
                    <td>
                        <span>Mode of Payment</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="drpPaymentMode" runat="server">
                            <asp:ListItem Value="Credit">Credit Card</asp:ListItem>
                            <asp:ListItem Value="Debit">Debit Card</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Card Type</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="drpCardType" runat="server">
                            <asp:ListItem>Visa</asp:ListItem>
                            <asp:ListItem>Master</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Card Holder&#39;s Name</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                       <span>Card Number</span></td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtNumber" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        CVV Number</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCVV" runat="server" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Expires On</td>
                </tr>
                <tr>
                    <td>
                        Month
                        <asp:TextBox ID="txtMonth" runat="server" Width="53px" required="required"></asp:TextBox>
                    &nbsp;Year
                        <asp:TextBox ID="txtYear" runat="server" Width="53px" required="required"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Billing Address</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="183px" required="required" 
                            TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        Phone Number</td>
                </tr>
                <tr>
                    <td>
                         <asp:TextBox ID="txtPhoneNumber" runat="server" Width="125px" TextMode="Phone"></asp:TextBox></td>
                </tr>
            </table>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="ContinueButton" runat="server" CommandName="Pay" Text="Continue" ValidationGroup="LoginUserValidationGroup"
                OnClick="ConfirmAndPay_Click" />
        </p>
    </div>
</asp:Content>
