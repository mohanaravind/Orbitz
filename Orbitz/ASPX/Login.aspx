<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Orbitz.ASPX.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Log In
    </h2>
    <p>
        Please enter your username and password.
        <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false" NavigateUrl ="~/ASPX/Register.aspx">Register</asp:HyperLink>
        &nbsp;if you haven't registered yet.
    </p>
    <div class="ASPXInfo">
        <fieldset class="login">
            <legend>Login Information</legend>
            <p>
                <asp:Label ID="EmailIDLabel" runat="server" AssociatedControlID="UserName">Email ID:</asp:Label>
                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry" required="required"
                    type="email"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"
                    required="required" type="password"></asp:TextBox>
            </p>
        </fieldset>
        <p class="submitButton">
            <asp:Button ID="LoginButton" CssClass="button" runat="server" CommandName="Login" Text="Log In" ValidationGroup="LoginUserValidationGroup"
                OnClick="LoginButton_Click" />
        </p>
    </div>
</asp:Content>
