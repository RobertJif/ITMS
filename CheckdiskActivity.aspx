<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckdiskActivity.aspx.cs" Inherits="Activity.Pages.CheckdiskActivity" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>

                    <div class="form-group">
                        <div class="col-md-10">
                          <%--  <asp:Button ID="btnNew" runat="server" Text="New Activity" CssClass="btn btn-default" OnClick="btnNew_Click" />
                            <asp:Button ID="btnLoad" runat="server" Text="Load Data" CssClass="btn btn-default" OnClick="btnLoad_Click" />
                        --%>
                            <dx:ASPxButton ID="btnNew" runat="server" Text="Add Checkdisk Activity" Theme="Mulberry" OnClick="btnNew_Click" CausesValidation="false"/>
                            <dx:ASPxButton ID="btnLoad" runat="server" Text="Load Data" Theme="Mulberry" OnClick="btnLoad_Click" CausesValidation="false"/>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="id" CssClass="col-md-2 control-label">SELECT ACTIVITY : </asp:Label>
                        <div class="col-md-3">
                            <dx:ASPxComboBox ID="id" runat="server" ValueType="System.String" Width="220px" Theme="Mulberry" DisplayFormatString="yyyy-MM-dd HH:mm:ss"/>                            
                        </div>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="user" runat="server" Width="150px" Theme="Mulberry" HorizontalAlign="Center" ReadOnly="true" Visible="false"/>
                        </div>
                        <div class="col-md-2">
                            <dx:ASPxTextBox ID="now" runat="server" Width="150px" Theme="Mulberry" HorizontalAlign="Center"
                                 DisplayFormatString="dd-MMM-yyyy" ReadOnly="true" Visible="false"/>
                        </div>
                    </div>

                    <div class="col-md-10">
                        <dx:ASPxGridView ID="grid" runat="server" Settings-GridLines="Both"
                            Theme="Mulberry" Width="1137px" AutoGenerateColumns="False">
                            <SettingsPager NumericButtonCount="25" PageSize="25">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="ServerName" VisibleIndex="1" />
                                <dx:GridViewDataCheckColumn FieldName="Status" VisibleIndex="3" >
                                    <PropertiesCheckEdit ValueChecked="1" ValueType="System.String" ValueUnchecked="0">
                              </PropertiesCheckEdit></dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="Memo" VisibleIndex="4" />                                
                                <dx:GridViewDataTextColumn FieldName="LocationName" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="CheckdiskID" VisibleIndex="0" Visible="false">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </div>                    

                </div>
            </section>
        </div>
    </div>
</asp:Content>

