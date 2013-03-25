<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Passengers.aspx.cs" Inherits="Orbitz.ASPX.Passengers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>
            Passengers</h2>
        <p>
            Please enter the passenger informations.
        </p>
        <div class="ASPXInfo">
            <fieldset class="login">
                <legend>Flight Information</legend>
                <asp:DataList ID="dlFlightInformation" runat="server" CellPadding="10" ForeColor="#333333"
                    RepeatColumns="3">
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <HeaderTemplate>
                        <span>Airline:&nbsp;<span style="font-weight: normal;"><%# GetInformation("Airline") %></span></span>
                        <span>&nbsp;Arrival Time:&nbsp;<span style="font-weight: normal;"><%# GetInformation("ArrivalTime") %></span></span>
                        <span>&nbsp;Departure Time:&nbsp;<span style="font-weight: normal;"><%# GetInformation("DepartureTime") %></span></span>
                        <span>&nbsp;Fare:&nbsp;<span style="font-weight: normal;"><%# GetInformation("BaggageAllowance") %></span></span>
                        <span>&nbsp;Flight Class:&nbsp;<span style="font-weight: normal;"><%# GetInformation("Fare") %></span></span>
                        <span>&nbsp;From:&nbsp;<span style="font-weight: normal;"><%# GetInformation("FlightClass") %></span></span>
                        <span>&nbsp;To:&nbsp;<span style="font-weight: normal;"><%# GetInformation("From") %></span></span>
                        <span>&nbsp;Baggage Allowance:&nbsp;<span style="font-weight: normal;"><%# GetInformation("To") %></span></span>
                        <span>&nbsp;Travel Day:&nbsp;<span style="font-weight: normal;"><%# GetInformation("TravelDay") %></span></span>
                        <span>&nbsp;Travel Duration:&nbsp;<span style="font-weight: normal;"><%# GetInformation("TravelDuration") %></span></span>
                    </HeaderTemplate>
                </asp:DataList>
            </fieldset>
        </div>
        <div class="ASPXInfo">
            <fieldset class="login">
                <legend>Passenger Details</legend>
                <table class="style1" id="passengerDetails" runat="server">
                    <tr>
                        <td>
                            No.
                        </td>
                        <td>
                            Passenger Name
                        </td>
                        <td>
                            Age
                        </td>
                        <td>
                            Passport Number
                        </td>
                        <td>
                            Nationality
                        </td>
                    </tr>
                    <tr>
                        <td>
                            1
                        </td>
                        <td>
                            <asp:TextBox ID="txtName1" runat="server" required="required"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAge1" runat="server" required="required"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport1" runat="server" required="required"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNationality1" runat="server" required="required"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            2
                        </td>
                        <td>
                            <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAge2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport2" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNationality2" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            3
                        </td>
                        <td>
                            <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAge3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport3" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNationality3" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            4
                        </td>
                        <td>
                            <asp:TextBox ID="txtName4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAge4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport4" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNationality4" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            5
                        </td>
                        <td>
                            <asp:TextBox ID="txtName5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtAge5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassport5" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txtNationality5" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <p class="submitButton">
                <asp:Button ID="btnProceedToPayment" runat="server" CommandName="Login" Text="Proceed to Payment"
                    ValidationGroup="LoginUserValidationGroup" OnClick="ProceedToPayment_Click" />
            </p>
        </div>
    </div>
</asp:Content>
