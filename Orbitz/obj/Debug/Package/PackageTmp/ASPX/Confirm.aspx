<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Confirm.aspx.cs" Inherits="Orbitz.ASPX.Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Confirm booking
    </h2>
    <p>
        Please confirm your booking details.
    </p>
    <div class="ASPXInfo">
        <fieldset class="login">
            <legend>Booking Informatoin</legend>
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
                        <span>&nbsp;Passengers:&nbsp;<span style="font-weight: normal;"><%# GetInformation("Passengers")%></span></span>
                        <span>&nbsp;Card Number:&nbsp;<span style="font-weight: normal;"><%# GetInformation("CardNumber")%></span></span>
                    </HeaderTemplate>
                </asp:DataList>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="PayButton" runat="server" CommandName="Login" Text="Pay" ValidationGroup="LoginUserValidationGroup"
                OnClick="Pay_Click" />&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="lnkCancel" runat="server" onclick="lnkCancel_Click">Cancel</asp:LinkButton>
        </p>
    </div>
</asp:Content>
