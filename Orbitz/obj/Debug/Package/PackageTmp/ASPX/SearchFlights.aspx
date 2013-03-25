<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchFlights.aspx.cs" Inherits="Orbitz.ASPX.SearchFlights" %>

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
            Search Flights
        </h2>
        <p>
            Please enter your flying preference.
        </p>
        <div class="ASPXInfo">
            <fieldset class="login">
                <legend>Travel Details</legend>
                <table class="style1">
                    <tr>
                        <td>
                            <asp:Label ID="lblFrom" runat="server" Text="Flying From"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFlyingTo" runat="server" Text="Flying To"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblClass" runat="server" Text="Class"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDate" runat="server" Text="Flying On"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="drpFlyingFrom" runat="server" DataTextField="Airport" 
                                DataValueField="AirportID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpFlyingTo" runat="server" DataTextField="Airport" 
                                DataValueField="AirportID">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpClass" runat="server">
                                <asp:ListItem Value="ECONOMY">Economy</asp:ListItem>
                                <asp:ListItem Value="BUSINESS">Business</asp:ListItem>
                                <asp:ListItem Value="FIRST">First</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpDay" runat="server" DataTextField="Day">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpMonth" runat="server">
                                <asp:ListItem Value="1">January</asp:ListItem>
                                <asp:ListItem Value="2">February</asp:ListItem>
                                <asp:ListItem Value="3">March</asp:ListItem>
                                <asp:ListItem Value="4">April</asp:ListItem>
                                <asp:ListItem Value="5">May</asp:ListItem>
                                <asp:ListItem Value="6">June</asp:ListItem>
                                <asp:ListItem Value="7">July</asp:ListItem>
                                <asp:ListItem Value="8">August</asp:ListItem>
                                <asp:ListItem Value="9">September</asp:ListItem>
                                <asp:ListItem Value="10">October</asp:ListItem>
                                <asp:ListItem Value="11">November</asp:ListItem>
                                <asp:ListItem Value="12">December</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="drpYear" runat="server">
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2013</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div style="text-align:center;"><asp:Button runat="server" ID="btnSearch" 
                        Text="Search Flights" onclick="btnSearch_Click"/></div>
            </fieldset>
        </div>
        <div style="text-align: center;" class="ASPXInfo">
            <fieldset class="login">
                <legend>Available Flights</legend>
                <asp:GridView ID="grdFlights" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" HorizontalAlign="Center" 
                    onrowcommand="grdFlights_RowCommand" 
                    EmptyDataText="Sorry. Couldn't find any matching flights." DataKeyNames="FlightID">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>       
                        <asp:BoundField DataField="Airline" HeaderText="Airline" />
                        <asp:BoundField DataField="DepartureTime" HeaderText="Departure Time" />
                        <asp:BoundField DataField="ArrivalTime" HeaderText="Arrival Time"></asp:BoundField>
                        <asp:BoundField DataField="FlightDuration" HeaderText="Flight Duration" />
                        <asp:BoundField DataField="Aircraft" HeaderText="Aircraft" />
                        <asp:BoundField DataField="BaggageAllowance" HeaderText="Baggage Allowance" />
                        <asp:BoundField DataField="Fare" HeaderText="Fare" />
                        <asp:BoundField DataField="AvailableSeats" HeaderText="Available Seats" />
                        <asp:CommandField ShowSelectButton="True" SelectText="Book" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </fieldset>
        </div>
    </div>
</asp:Content>
