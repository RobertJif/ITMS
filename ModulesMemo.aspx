<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModulesMemo.aspx.cs" Inherits="Activity.Pages.ModulesMemo" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                          <asp:PlaceHolder runat="server" ID="Panel1">
               <div>&nbsp;</div>
              
                        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ProjectIDList" CssClass="col-md-2 control-label">Project ID</asp:Label>
                            <div class="col-md-2" Height="30px">
                                <asp:DropDownList ID="ProjectIDlist" runat="server" Width="200px" Height="30px" OnSelectedIndexChanged="ProjectIDlist_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-2 control-label">
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="ProjectIDList"
                                    CssClass="text-danger" ErrorMessage="This field is required" />
                            </div>
                        </div>

                        <div class="form-group" Height="30px">
                            <asp:Label runat="server" AssociatedControlID="ModuleIDlist" CssClass="col-md-2 control-label">Module ID</asp:Label>
                            <div class="col-md-2" Height="30px">
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" AutoPostback="true">
                       <ContentTemplate>
                          <asp:DropDownList ID="ModuleIDlist" runat="server" Width="200px" Height="30px" AutoPostBack="true"></asp:DropDownList>
                        </ContentTemplate>
                       <Triggers>
                          <asp:AsyncPostbackTrigger ControlID="ProjectIDlist" EventName="SelectedIndexChanged" />
                       </Triggers>
                    </asp:UpdatePanel>
                                
                                 </div>
                         
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="memoDescription" CssClass="col-md-2 control-label">Memo Description</asp:Label>
                            <div class="col-md-2">
                                <dx:ASPxMemo ID="memoDescription" runat="server" Height="200px" Width="600px" Theme="Mulberry" />
                            </div>
                            <div class="col-md-2 control-label">
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="memoDescription"
                                    CssClass="text-danger" ErrorMessage="This field is required" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="ReleaseTarget" CssClass="col-md-2 control-label">Date Released Target</asp:Label>
                            <div class="col-md-10">
                                <dx:ASPxDateEdit ID="ReleaseTarget" runat="server" Width="400px" Theme="Mulberry" EditFormatString="yyyy-MM-dd HH:mm:ss" EditFormat="DateTime" />
                            </div>
                        </div>
                    
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="FileUpload1" CssClass="col-md-2 control-label">Additional File</asp:Label>
                            <div class="col-md-10">
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </div>
                        </div>
                        <%--<div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="notificationUser" CssClass="col-md-2 control-label">Notification User List</asp:Label>
                            <div class="col-md-2">
                                <dx:ASPxListBox ID="notificationUser" runat="server" ValueType="System.String" Theme="Mulberry" Width="200" />
                            </div>
                        </div>--%>
                        

                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <dx:ASPxButton ID="btnSave" runat="server" Text="Create Memo" Theme="Mulberry" OnClick="btnSave_Click" />
                                <dx:ASPxButton ID="btnReset" runat="server" Text="Reset" CausesValidation="false" Theme="Mulberry" OnClick="btnReset_Click" />
                            </div>
                        </div>
                    </asp:PlaceHolder>

                    <div>&nbsp;</div>

<%--                    <asp:PlaceHolder runat="server" ID="Panel2">--%>

                        <div class="form-group">
                            <div class="col-md-10">
                                <dx:ASPxButton ID="btnRefresh" runat="server" Text="Memo List" CausesValidation="false" Theme="Mulberry" OnClick="btnRefresh_Click" />
                                <dx:ASPxButton ID="btnMyMemo" runat="server" Text="My Memo" CausesValidation="false" Theme="Mulberry" OnClick="btnMyMemo_Click" Visible="true"/>
                                
                               <dx:ASPxButton ID="btnAddMemo" runat="server" Text="Add Memo" CausesValidation="false" Theme="Mulberry" OnClick="btnAdd_Click" Visible="false" AutoPostBack="true"/>
                                <dx:ASPxButton ID="btnEditMemo" runat="server" Text="Edit Memo" CausesValidation="false" Theme="Mulberry" OnClick="btnEdit_Click" Visible="false" AutoPostBack="true"/>
                              <dx:ASPxButton ID="btnDeleteMamo" runat="server" Text="Delete Memo" CausesValidation="false" Theme="Mulberry" OnClick="btnDelete_Click" Visible="false" AutoPostBack="true">
                                  <ClientSideEvents Click="function(s, e){ e.processOnServer = confirm('Are you sure ?');}" />  </dx:ASPxButton>
                                 </div>
                             </div>
                        <div class="form-group">
                            <div class="col-md-10">
                              <dx:ASPxButton ID="btnTakeMemo" runat="server" Text="Take Memo" CausesValidation="false" Theme="Mulberry" OnClick="btnTake_Click" Visible="true">
                              <ClientSideEvents Click="function(s, e){ e.processOnServer = confirm('Are you sure ?');}" />    
                              </dx:ASPxButton>
                                <dx:ASPxButton ID="btnRelease" runat="server" Text="Release" CausesValidation="false" Theme="Mulberry" OnClick="btnRelease_Click">
                                    <ClientSideEvents Click="function(s, e){ e.processOnServer = confirm('Are you sure ?');}" />
                                </dx:ASPxButton>
                              <dx:ASPxButton ID="btnDownload" runat="server" Text="Get Attachment" CausesValidation="false" Theme="Mulberry" OnClick="btnDownload_Click" Visible="false"/>
                           
                                 </div>
                                 </div>

                       
                        <div class="col-md-10">
                            <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="MemoID" Settings-GridLines="Both" Theme="Mulberry"
                                Width="1800px" AutoGenerateColumns="False">
                                <SettingsPager NumericButtonCount="15" PageSize="15">
                                </SettingsPager>
                                <Settings ShowGroupPanel="True" ShowFilterRow="True" ShowHeaderFilterBlankItems="False" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsSearchPanel Visible="True" />

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="MemoID" VisibleIndex="1" Width="50px"/>
                                    <dx:GridViewDataTextColumn FieldName="ProjectName" VisibleIndex="2" Width="120px" />
                                    <dx:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="3" Width="250px" />
                                    <dx:GridViewDataTextColumn FieldName="ProjectID" Name="ProjectID" Visible="False" VisibleIndex="4" />
                                    <dx:GridViewDataTextColumn FieldName="ModuleID" Name="ModuleID" Visible="False" VisibleIndex="5"/>    
                                    <dx:GridViewDataTextColumn FieldName="MemoDescription" VisibleIndex="6" Width="300px" >
                                        <Settings AutoFilterCondition="Contains" /></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Status1" VisibleIndex="7" Width="120px" >
                                        <Settings AllowHeaderFilter="True" FilterMode="DisplayText" />
                                    <CellStyle HorizontalAlign="Center">
                                        </CellStyle></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="AssignedUser" VisibleIndex="8" Width="100px">
                                        <Settings AllowHeaderFilter="True" FilterMode="DisplayText" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ReleasedTargetDateTime" VisibleIndex="10" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="170px" >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm"></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                  
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FirstBuildDateTime" VisibleIndex="11" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="170px"  >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm:ss "></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ReleasedRealDateTime" VisibleIndex="12" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="200px" >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm:ss"></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Status2" VisibleIndex="13" Width="100px" >
                                        <Settings AllowHeaderFilter="True" FilterMode="DisplayText" />
                                    <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileName" Name="FileName" VisibleIndex="9">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="0" Visible="false">
                                        <Settings AllowAutoFilter="True" />
                                    <DataItemTemplate>                                        
                                        <a href="EditMemo.aspx?memoid=<%# Container.KeyValue %>">Edit </a>                                        
                                        <%--<a href="DeleteVisit.aspx?projectId=<%# Container.KeyValue %>" class='<%= isDelete == 0 ? "disabled" : "enabled" %>'> Delete</a>--%>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                            <dx:ASPxGridView ID="grid2" runat="server" KeyFieldName="MemoID" Settings-GridLines="Both" Theme="Mulberry"
                                Width="1800px" AutoGenerateColumns="False">
                                <SettingsPager NumericButtonCount="15" PageSize="15">
                                </SettingsPager>
                                <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsSearchPanel Visible="True" />

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="MemoID" VisibleIndex="1" Width="50px"/>
                                    <dx:GridViewDataTextColumn FieldName="ProjectName" VisibleIndex="2" Width="120px" />
                                    <dx:GridViewDataTextColumn FieldName="ModuleName" VisibleIndex="3" Width="250px" />
                                    <dx:GridViewDataTextColumn FieldName="ProjectID" Name="ProjectID" Visible="False" VisibleIndex="4" />
                                    <dx:GridViewDataTextColumn FieldName="ModuleID" Name="ModuleID" Visible="False" VisibleIndex="5"/>    
                                    <dx:GridViewDataTextColumn FieldName="MemoDescription" VisibleIndex="6" Width="300px" />
                                    <dx:GridViewDataTextColumn FieldName="Status1" VisibleIndex="7" Width="120px" >
                                    <CellStyle HorizontalAlign="Center">
                                        </CellStyle></dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="AssignedUser" VisibleIndex="8" Width="100px">
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ReleasedTargetDateTime" VisibleIndex="10" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="170px" >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm"></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                  
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FirstBuildDateTime" VisibleIndex="11" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="170px"  >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm:ss "></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="ReleasedRealDateTime" VisibleIndex="12" PropertiesTextEdit-DisplayFormatString="dd-MMM-yyyy HH:mm" Width="200px" >
<PropertiesTextEdit DisplayFormatString="dd-MMM-yyyy HH:mm:ss"></PropertiesTextEdit>
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="Status2" VisibleIndex="13" Width="100px" >
                                    <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="FileName" Name="FileName" VisibleIndex="9">
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="0" Visible="false">
                                    <DataItemTemplate>                                        
                                        <a href="EditMemo.aspx?memoid=<%# Container.KeyValue %>">Edit </a>                                        
                                        <%--<a href="DeleteVisit.aspx?projectId=<%# Container.KeyValue %>" class='<%= isDelete == 0 ? "disabled" : "enabled" %>'> Delete</a>--%>
                                    </DataItemTemplate>
                                </dx:GridViewDataTextColumn>
                                </Columns>
                            </dx:ASPxGridView>
                        </div>
                  </asp:PlaceHolder>

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
