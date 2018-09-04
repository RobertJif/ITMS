<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEvaluation.aspx.cs" Inherits="Activity.Pages.EmployeeEvaluation" %>
<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <div class="form-group">
               
                        <div class="col-md-2">
                            <dx:ASPxComboBox ID="id" runat="server" Width="160px" Theme="Mulberry"/>                            
                        </div>
                         <div class="col-md-2">
                            <dx:ASPxComboBox ID="id3" runat="server" Width="160px" Theme="Mulberry">
                                <Items>
                                    <dx:ListEditItem Text="Month" Value="1" Selected="true"/>
                                    <dx:ListEditItem Text="January" Value="Jan" />
                                    <dx:ListEditItem Text="February" Value="Feb" />
                                    <dx:ListEditItem Text="March" Value="Mar" />
                                    <dx:ListEditItem Text="April" Value="Apr" />
                                    <dx:ListEditItem Text="May" Value="May" />
                                    <dx:ListEditItem Text="June" Value="Jun" />
                                    <dx:ListEditItem Text="July" Value="Jul" />
                                    <dx:ListEditItem Text="August" Value="Aug" />
                                    <dx:ListEditItem Text="September" Value="Sep" />
                                    <dx:ListEditItem Text="October" Value="Oct" />
                                    <dx:ListEditItem Text="November" Value="Nov" />
                                    <dx:ListEditItem Text="December" Value="Dec" />
                                </Items>
                            </dx:ASPxComboBox>
                                                    
                        </div>
                         <div class="col-md-2" style="width:11%">
                            <dx:ASPxComboBox ID="id2" runat="server" ValueType="System.String" Width="100px" Theme="Mulberry"/>                             
                        </div>
                         <div class="col-md-3">
            
                            <dx:ASPxButton ID="btnLoad" runat="server" Text="Load Data" Theme="Mulberry" OnClick="btnLoad_Click" CausesValidation="false"/>
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
                        <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="ID" Settings-GridLines="Both"
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
                                <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="0" Width="50px" Caption="ID" PropertiesTextEdit-NullDisplayText="0" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="MemoID" VisibleIndex="1" Caption="Memo Description" PropertiesTextEdit-NullDisplayText="Tanpa Memo" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="total" VisibleIndex="2" Caption="Activity Number" PropertiesTextEdit-NullDisplayText="0" Width="50px" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Equals" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="3" Visible="true" Width="60px" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                                    <DataItemTemplate>                                        
                                        <a href="EmployeeEvaluation.aspx?ID=<%# Container.KeyValue %>">View</a>                                        
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                            </Columns>                          
                        </dx:ASPxGridView>
                        
                    </div>
                        </asp:Panel>
                    <div class="form-group">
               
                         <div class="col-md-3">
                            <dx:ASPxButton ID="btnbacktop" runat="server" Text="Back" Theme="Mulberry" CausesValidation="false" Visible="false" OnClick="btnbacktop_Click"/>
                        </div>
                     
                    </div>
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <div class="col-md-10">
                        <dx:ASPxGridView ID="grid2" runat="server" KeyFieldName="ActivityDescription" Settings-GridLines="Both"
                             Theme="Mulberry" Width="1137px" AutoGenerateColumns="False" >
                            <StylesContextMenu>
                                <Column>
                                    <Item HorizontalAlign="Center">
                                    </Item>
                                </Column>
                            </StylesContextMenu>
                            <SettingsPager NumericButtonCount="10" PageSize="10">
                            </SettingsPager>
                            <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                            <SettingsBehavior AllowFocusedRow="True" />
                            <SettingsSearchPanel Visible="True" />

                            <Columns>                       
                                <dx:GridViewDataTextColumn FieldName="ProjectName" VisibleIndex="0" Width="60px" Caption="Project" PropertiesTextEdit-NullDisplayText="Kosong" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="1" Width="60px" Caption="Module" PropertiesTextEdit-NullDisplayText="Kosong" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>  
                                <dx:GridViewDataTextColumn FieldName="ActivityDescription" VisibleIndex="2" Caption="Activity" PropertiesTextEdit-NullDisplayText="0" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="InputDateTime" VisibleIndex="3" Width="170px" Caption="Date" PropertiesTextEdit-NullDisplayText="Kosong" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                                    <Settings AutoFilterCondition="Contains" />
                                </dx:GridViewDataTextColumn>
                            </Columns>                          
                        </dx:ASPxGridView>
                        
                    </div>
                        <br />
                         <div class="form-group">
                         <div class="col-md-3">
                            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Back" Theme="Mulberry" CausesValidation="false" Visible="false" OnClick="btnbacktop_Click"/>
                        </div>
                     
                    </div>
                              <div class="form-group">
                         <div class="col-md-3">
                            <dx:ASPxButton ID="btnbackbot" runat="server" Text="Back" Theme="Mulberry" CausesValidation="false" Visible="false" OnClick="btnbacktop_Click"/>
                        </div>
                     
                    </div>
                        </asp:Panel>
                        <br />
                    </div>                    

            </section>
        </div>
    </div>
</asp:Content>

