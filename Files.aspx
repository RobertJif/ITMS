<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="Activity.Pages.Files" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-10">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div>&nbsp;</div>
                
                    <asp:PlaceHolder runat="server" ID="Panel1" Visible="false">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="memoBox" CssClass="col-md-2 control-label">Notes</asp:Label>
                            <div class="col-md-2">
                                <dx:ASPxMemo ID="memoBox" runat="server" Height="71px" Width="330px"></dx:ASPxMemo>
                                    </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="uploadControl" CssClass="col-md-2 control-label">Select File</asp:Label>
                            <div class="col-md-2">
                                <asp:FileUpload ID="uploadControl" runat="server" UploadMode="Auto" Width="280px"></asp:FileUpload>
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
                                <dx:ASPxButton ID="btnSave" runat="server" Text="Add File" Theme="Mulberry" OnClick="btnSave_Click" />
                            </div>
                        </div>
                

                    <div>&nbsp;</div>
                    <div>&nbsp;</div>
                 </asp:PlaceHolder>
                    <%--<asp:PlaceHolder runat="server" ID="Panel2">--%>
                        <div class="form-group">
                            <div class="col-md-10">
                              
                            <dx:ASPxButton ID="btnRefresh" runat="server" Text="Refresh List" Theme="Mulberry" OnClick="btnRefresh_Click" CausesValidation="false"/>
                            <dx:ASPxButton ID="btnAdd" runat="server" Text="Add Document" Theme="Mulberry" OnClick="btnAdd_Click" CausesValidation="false"/>
                            <dx:ASPxButton ID="btnEdit" runat="server" Text="Delete Document" Theme="Mulberry" OnClick="btnEdit_Click" CausesValidation="false" AutoPostBack="true">
                                <ClientSideEvents Click="function(s, e){ e.processOnServer = confirm('Are you sure ?');}" />  </dx:ASPxButton>
                                   
                            <dx:ASPxButton ID="btnDownload" runat="server" Text="Download File" Theme="Mulberry" OnClick="btnDownload_Click" CausesValidation="false"/>
                            
                            </div>
                        </div>
                        <div class="col-md-10">
                            <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="DocumentID" Settings-GridLines="Both" Theme="Mulberry"
                                Width="1137px" AutoGenerateColumns="False">
                                <SettingsPager NumericButtonCount="15" PageSize="15">
                                </SettingsPager>
                                <Settings ShowGroupPanel="True" ShowFilterRow="True" />
                                <SettingsBehavior AllowFocusedRow="True" />
                                <SettingsSearchPanel Visible="True" />

                                <Columns>
                                    <dx:GridViewDataTextColumn FieldName="#" VisibleIndex="0" Visible="false">
                                        <DataItemTemplate>
                                            <a href="Download.aspx?fileId=<%# Container.KeyValue %>">Download</a>
                                            <a href="DeleteFiles.aspx?fileId=<%# Container.KeyValue %>">  Delete</a>
                                        </DataItemTemplate>
                                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="DocumentID" VisibleIndex="1" />
                                    <dx:GridViewDataTextColumn FieldName="DocumentName" VisibleIndex="2" />
                                    <dx:GridViewDataTextColumn FieldName="Extension" VisibleIndex="3" />
                                    <dx:GridViewDataTextColumn FieldName="FileSize" VisibleIndex="4" />
                                    <dx:GridViewDataTextColumn FieldName="Notes" VisibleIndex="5" />
                                    <dx:GridViewDataTextColumn FieldName="Uploader" VisibleIndex="6" />

                                    <dx:GridViewDataTextColumn FieldName="UploadDate" VisibleIndex="7"
                                        PropertiesTextEdit-DisplayFormatString="dd-MMM-yyy HH:mm" />
                                </Columns>
                            </dx:ASPxGridView>

                        </div>
              <%--      </asp:PlaceHolder>--%>

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
