<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditProvider.aspx.cs" Inherits="Activity.Pages.EditProvider" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="code" CssClass="col-md-2 control-label">Provider Name</asp:Label>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="code" runat="server" Width="200px" Theme="Mulberry" ReadOnly="false" />
                        </div>
                    </div>

                     <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="LocationID" CssClass="col-md-2 control-label" Height="30px">Location Name</asp:Label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="LocationID" runat="server" Width="200px" Height="32px"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="LocationID"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>

                    

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="download" CssClass="col-md-2 control-label">Download Speed</asp:Label>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="downSpeed" runat="server" Width="150px" Theme="Mulberry" DisplayFormatString="n0" />
                        </div>
                        <div class="col-md-1">
                            <dx:ASPxComboBox ID="download" runat="server" Width="80px" Theme="Mulberry" />
                        </div>
                        <div class="col-md-3 control-label">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="downSpeed"
                                CssClass="text-danger" ErrorMessage="This field is required" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="upload" CssClass="col-md-2 control-label">Upload Speed</asp:Label>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="upSpeed" runat="server" Width="150px" Theme="Mulberry" DisplayFormatString="n0" />
                        </div>
                        <div class="col-md-1">
                            <dx:ASPxComboBox ID="upload" runat="server" Width="80px" Theme="Mulberry" />
                        </div>
                        <div class="col-md-3 control-label">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="upSpeed"
                                CssClass="text-danger" ErrorMessage="This field is required" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="cost" CssClass="col-md-2 control-label">Monthly Cost</asp:Label>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="cost" runat="server" Width="200px" Theme="Mulberry" DisplayFormatString="n0" />
                        </div>
                        <div class="col-md-4 control-label">
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="cost"
                                CssClass="text-danger" ErrorMessage="This field is required" />
                        </div>
                    </div>
                      <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="contractdateTime" CssClass="col-md-2 control-label">Contract Start Date</asp:Label>
                    <div class="col-md-10">
                        <dx:ASPxDateEdit ID="contractdateTime" runat="server" Width="200px" Theme="Mulberry" EditFormatString="yyyy-MM-dd HH:mm:ss" />
                    </div>
                </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="isActive" CssClass="col-md-2 control-label">Active</asp:Label>
                        <div class="col-md-6">
                            <dx:ASPxCheckBox ID="isActive" runat="server" Theme="Mulberry">
                            </dx:ASPxCheckBox>
                        </div>
                    </div>            

                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <asp:Label runat="server" AssociatedControlID="FailureText" CssClass="col-md-1"></asp:Label>
                        <div class="col-md-10">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </div>
                    </asp:PlaceHolder>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <dx:ASPxButton ID="btnSave" runat="server" Text="Update Provider" Theme="Mulberry" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
