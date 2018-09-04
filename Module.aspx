<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Module.aspx.cs" Inherits="Activity.Pages.Module" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">        
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh List" Theme="Mulberry" OnClick="btnRefresh_Click" />
                            <dx:ASPxButton ID="btnNew" runat="server" Text="New Module" Theme="Mulberry" OnClick="btnNew_Click" />
                            <dx:ASPxButton ID="btnEdit" runat="server" Text="Edit Module" Theme="Mulberry" OnClick="btnEdit_Click" />
                            <dx:ASPxButton ID="btnDelete" runat="server" Text="Delete Module" Theme="Mulberry" OnClick="btnDelete_Click">
                                <ClientSideEvents Click="function(s, e){ e.processOnServer = confirm('Are you sure ?');}" />
                            </dx:ASPxButton>
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

                    <div class="col-md-10">
                        <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ModuleID" Settings-GridLines="Both" Theme="Mulberry" Width="1137px" AutoGenerateColumns="False" >
                            <SettingsPager NumericButtonCount="15" PageSize="15">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ModuleID" VisibleIndex="0" Visible="false" />
                                <dx:GridViewDataTextColumn FieldName="ProjectName" VisibleIndex="2" />
                                <dx:GridViewDataCheckColumn FieldName="IsActive" VisibleIndex="3" />                                
                                <dx:GridViewDataDateColumn FieldName="FirstBuildDateTime" VisibleIndex="4" >
                                    <PropertiesDateEdit DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>                                
                                <dx:GridViewDataDateColumn FieldName="LastBuildDateTime" VisibleIndex="5" >
                                    <PropertiesDateEdit DisplayFormatString="dd-MMM-yyyy" EditFormatString="dd-MMM-yyyy"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="TaskTotal" VisibleIndex="7" />
                                <dx:GridViewDataTextColumn FieldName="TaskCompleted" VisibleIndex="8" />
                                <dx:GridViewDataTextColumn FieldName="ModuleName" Name="ModuleName" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ProjectID" Name="ProjectID" Visible="False" VisibleIndex="9">
                                </dx:GridViewDataTextColumn>
                            </Columns>                          
                        </dx:ASPxGridView>                        
                    </div>
                </div>
            </section>
        </div>
    </div>

    <style type="text/css">
        a.disabled {
            pointer-events: none;
            color: #808080;
            cursor: default;
        }

        a.enabled {
        }
    </style>

</asp:Content>
