<%@ Page Title="Preview Theme" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="AgencySettings_Preview.aspx.vb" Inherits="Webvantage.AgencySettings_Preview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="Jscripts/common.js"></script>
    <script type="text/javascript" src="Jscripts/UIHelper.js"></script>
    <script type="text/javascript" src="Scripts/jquery-3.6.0.min.js"></script>
    <telerik:RadCodeBlock ID="RadScriptBlockCSS" runat="server">
        <style type="text/css">
        html, body, form, #wrapper {
            height: 100%;
            width: 100%;
            font-size: 14px;
            font-family: Calibri, Verdana, Arial
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin: 0px;
            padding: 0px;
            border: none;
            <%= Me.BackgroundCSS %>
        }
        Body, th, td {
            font-size: 14px;
            font-family: Calibri, Verdana, Arial
       }
        #wrapper {
            margin: 0 auto;
            height:100%;
            width:100%;
        }
        table.full-height {
            height:100%;
            width:100%;
        }
        #page-background {
            position:fixed; 
            top:0; 
            left:0; 
            width:100%; 
            height:100%;
            z-index:-9000;
        }
        .pad-sidebar {
            padding-left: 13px;
        }
   </style>
    </telerik:RadCodeBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadWindow ID="RadWindowPreview" runat="server" Width="270" Height="145" IconUrl="~/Images/blank.ico"
        Visible="true" Title="Application Window" VisibleOnPageLoad="true" Behaviors="Move, Minimize"
        VisibleStatusbar="false" RestrictionZoneID="TdPreview">
        <ContentTemplate>
            <telerik:RadToolBar ID="RadToolBarPreview" runat="server" Width="100%">
                <Items>
                    <telerik:RadToolBarButton Text="Toolbar" ImageUrl="Images/star_yellow.png">
                    </telerik:RadToolBarButton>
                </Items>
            </telerik:RadToolBar>
        </ContentTemplate>
    </telerik:RadWindow>
    <div id="wrapper" class="full-height">
        <telerik:RadMenu ID="RadMenuPreview" runat="server" Width="100%">
            <Items>
                <telerik:RadMenuItem Text="Menu">
                    <Items>
                        <telerik:RadMenuItem Text="This is">
                        </telerik:RadMenuItem>
                        <telerik:RadMenuItem Text="an">
                            <Items>
                                <telerik:RadMenuItem Text="example!">
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenuItem>
                    </Items>
                </telerik:RadMenuItem>
                <telerik:RadMenuItem Text="Refresh this preview" Value="refresh" Visible="true">
                </telerik:RadMenuItem>
            </Items>
        </telerik:RadMenu>
        <div style="float: left; padding: 8px 0px 0px 8px;">
            <asp:Image ID="ImageLogo" runat="server" ImageUrl="Images/Logos/aqualogo_white.png" />
        </div>
        <div id="DivPreviewSidebar" runat="server" class="pad-sidebar">
            <asp:Image ID="ImagePreview1" runat="server" ImageUrl="~/Images/Icons/Color/256/arrow_right.png" CssClass="main-icons-simple-home" />
            <asp:Image ID="ImagePreview2" runat="server" ImageUrl="~/Images/Icons/Color/256/arrow_left.png" CssClass="main-icons-simple-home" />
            <asp:Image ID="ImagePreview3" runat="server" ImageUrl="~/Images/Icons/Color/256/book_bookmark.png" CssClass="main-icons-simple-home" />
        </div>
    </div>
</asp:Content>
