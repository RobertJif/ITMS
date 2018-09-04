<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Activity.aspx.cs" Inherits="Activity.Pages.Activity" %>
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
                            <dx:ASPxButton ID="btnNew" runat="server" Text="New Activity" Theme="Mulberry" OnClick="btnNew_Click" />
                      <dx:ASPxButton ID="btnEdit" runat="server" Text="Edit Activity" Theme="Mulberry" OnClick="btnEdit_Click" />
                        </div>
                    </div>

                    <div class="col-md-10">
                        <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ActivityID" Settings-GridLines="Both"
                             Theme="Mulberry" Width="1137px" AutoGenerateColumns="False" >
                            <StylesContextMenu>
                                <Column>
                                    <Item HorizontalAlign="Center">
                                    </Item>
                                </Column>
                            </StylesContextMenu>
                            <SettingsPager NumericButtonCount="15" PageSize="15">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsSearchPanel Visible="True" />

                            <Columns>
                                <%--<dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>--%>
                                <dx:GridViewDataTextColumn FieldName="ActivityID" VisibleIndex="0" Width="20px" Visible="false"/>
                                <dx:GridViewDataTextColumn FieldName="ProjectName" VisibleIndex="1" Width="120px"/>
                                <dx:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="2" Width="120px"/> 
                                                               
                                <dx:GridViewDataTextColumn FieldName="MemoID" VisibleIndex="3" Width="300px" Caption="Memo Description">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ActivityDescription" VisibleIndex="4" Width="300px">
                                    <Settings AutoFilterCondition="Contains" /></dx:GridViewDataTextColumn>
                                <dx:GridViewDataDateColumn FieldName="InputDateTime" VisibleIndex="6" Width="120px" >
                                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy HH:mm" EditFormatString="dd-MM-yyyy HH:mm"></PropertiesDateEdit>
                                    
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="EditID" VisibleIndex="7" Width="100px" visible="false"/>
                                <dx:GridViewDataDateColumn FieldName="EditDateTime" VisibleIndex="8" Width="120px" visible="false">
                                    <PropertiesDateEdit DisplayFormatString="dd-MM-yyyy HH:mm" EditFormatString="dd-MM-yyyy HH:mm">
                                    </PropertiesDateEdit>
                                </dx:GridViewDataDateColumn>
                                <dx:GridViewDataTextColumn FieldName="InputID" VisibleIndex="5" Width="100px">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="9" Visible="true" Width="60px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>                                        
                                        <a href="ActivityMemos.aspx?memoid=<%# Container.KeyValue %>">View Memo</a>                                        
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>                          
                        </dx:ASPxGridView>
                        
                    </div>

                </div>
            </section>
        </div>
    </div>
</asp:Content>

