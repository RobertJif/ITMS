<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Activity.Account.Login" Async="true" %>

<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <%-- <h2><%: Title %>.</h2> --%>

    <div class="row">
        <div class="col-md-6">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h1>
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="LOGIN FORM" Theme="Mulberry">
                        </dx:ASPxLabel>
                    </h1>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="user" CssClass="col-md-2 control-label">Username</asp:Label>
                        <div class="col-md-7">
                            <asp:TextBox runat="server" ID="user" CssClass="form-control" />
                        </div>
                        <div class="control-label">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="user"
                                CssClass="text-danger" ErrorMessage="This field is required" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="passwd" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-7" style="align-content:center">
                            <asp:TextBox runat="server" ID="passwd" TextMode="Password" CssClass="form-control" />
                        </div>
                        <div class="control-label">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="passwd" 
                                CssClass="text-danger" ErrorMessage="This field is required" />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
                <p>
                    <%-- %><asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Register as a new user</asp:HyperLink> --%>
                </p>
                <p>
                    <%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
                    --%>
                </p>
            </section>
        </div>

    </div>
</asp:Content>
