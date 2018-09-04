<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditNetworkProblem.aspx.cs" Inherits="Activity.Pages.EditNetworkProblem" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <section id="loginForm">
            <div class="form-horizontal">
                <div>&nbsp;</div>
                
                 <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="problemname" CssClass="col-md-2 control-label">Problem</asp:Label>
                    <div class="col-md-2">
                        <dx:ASPxTextBox ID="problemname" runat="server" Width="195px" Theme="Mulberry">
                        </dx:ASPxTextBox>
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="problemname"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="networkProviders" CssClass="col-md-2 control-label">Network Provider</asp:Label>
                    <div class="col-md-2">
                        <asp:DropDownList ID="networkProviders" runat="server" Width="200px" Height="30px"></asp:DropDownList>
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="networkProviders"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>                

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="downTime" CssClass="col-md-2 control-label">Down Time</asp:Label>
                    <div class="col-md-2">
                    <dx:ASPxDateEdit ID="downTime" runat="server" Width="200px" Theme="Mulberry" EditFormatString="yyyy-MM-dd HH:mm:ss" EditFormat="DateTime" >
                          <TimeSectionProperties Visible="true" TimeEditProperties-DisplayFormatString="HH:mm:ss"></TimeSectionProperties>
                                    </dx:ASPxDateEdit>
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="downTime"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="upTime" CssClass="col-md-2 control-label">Up Time</asp:Label>
                    <div class="col-md-2">
                        <dx:ASPxDateEdit ID="upTime" runat="server" Width="200px" Theme="Mulberry" EditFormatString="yyyy-MM-dd HH:mm:ss" EditFormat="DateTime" >
                              <TimeSectionProperties Visible="true" TimeEditProperties-DisplayFormatString="HH:mm:ss"></TimeSectionProperties>
                                    </dx:ASPxDateEdit>
                    
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="upTime"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="memo" CssClass="col-md-2 control-label">Problem</asp:Label>
                    <div class="col-md-2">
                        <dx:ASPxMemo ID="memo" runat="server" Height="200px" Width="600px" theme="Mulberry" />                        
                    </div>
                    <div class="col-md-2 control-label">
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="memo"
                            CssClass="text-danger" ErrorMessage="This field is required" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <dx:ASPxButton ID="btnSave" runat="server" Text="Update Problem" Theme="Mulberry" OnClick="btnSave_Click" />
                    </div>
                </div>

            </div>
        </section>
    </div>
</asp:Content>

