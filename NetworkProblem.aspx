<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NetworkProblem.aspx.cs" Inherits="Activity.Pages.NetworkProblem" %>
<%@ Register assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">        
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>
                    <div class="form-group">
                        <div class="col-md-10">
                           <%-- <asp:Button ID="btnNew" runat="server" Text="Add Network Problem" CssClass="btn btn-default" OnClick="btnNew_Click" />
                            <asp:Button ID="btnRefresh" runat="server" Text="Refresh List" CssClass="btn btn-default" OnClick="btnRefresh_Click" />
                        --%>
                        <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh List" Theme="Mulberry" OnClick="btnRefresh_Click" CausesValidation="false"/>
                            <dx:ASPxButton ID="btnNew" runat="server" Text="Add Network Problem" Theme="Mulberry" OnClick="btnNew_Click" CausesValidation="false"/>
                            <dx:ASPxButton ID="btnEdit" runat="server" Text="Edit Network Problem" Theme="Mulberry" OnClick="btnEdit_Click" CausesValidation="false"/>
                            
                        </div>
                    </div>

                    <div class="col-md-10">
                        <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ID" Settings-GridLines="Both" Theme="Mulberry" Width="1137px" AutoGenerateColumns="False" >
                            <SettingsPager NumericButtonCount="15" PageSize="15">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                            
                            <SettingsBehavior AllowFocusedRow="True" /><SettingsSearchPanel Visible="True" />

                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="0" Visible="false">
                                    <DataItemTemplate>                                        
                                        <a href="EditNetworkProblem.aspx?problemId=<%# Container.KeyValue %>" class='<%= isEdit == 0 ? "disabled" : "enabled" %>'>Edit </a>                                        
                                        <%--<a href="DeleteVisit.aspx?projectId=<%# Container.KeyValue %>" class='<%= isDelete == 0 ? "disabled" : "enabled" %>'> Delete</a>--%>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1" width="80px" Visible="false"/>
                                <dx:GridViewDataTextColumn FieldName="LocationName" VisibleIndex="2" />
                                <dx:GridViewDataTextColumn FieldName="ProviderName" VisibleIndex="3" />
                                <dx:GridViewDataDateColumn FieldName="DownDateTime" VisibleIndex="4" >
                                    <PropertiesDateEdit DisplayFormatString="dd-MMM-yyyy HH:mm" EditFormatString="dd-MMM-yyyy HH:mm"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>                                 
                                <dx:GridViewDataDateColumn FieldName="UpDateTime" VisibleIndex="5" >
                                    <PropertiesDateEdit DisplayFormatString="dd-MMM-yyyy HH:mm" EditFormatString="dd-MMM-yyyy HH:mm"></PropertiesDateEdit>
                                </dx:GridViewDataDateColumn> 
                                <dx:GridViewDataTextColumn FieldName="Memo" VisibleIndex="6" Width="300px" >
                                    <Settings AutoFilterCondition="Contains" /></dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="InputID" VisibleIndex="7" />
                                <dx:GridViewDataDateColumn FieldName="InputDateTime" VisibleIndex="8">                                   
                                     <PropertiesDateEdit DisplayFormatString="dd-MMM-yyyy HH:mm" EditFormatString="dd-MMM-yyyy HH:mm"></PropertiesDateEdit>
                              </dx:GridViewDataDateColumn>
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