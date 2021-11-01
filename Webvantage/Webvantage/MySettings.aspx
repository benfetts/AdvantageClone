<%@ Page Title="My Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="MySettings.aspx.vb" Inherits="Webvantage.MySettings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <link href="CSS/UI_Simple.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .CssImacContent {
            <%= Me.ImacBackgroundCSS %>
        }
        .pad-sidebar {
            padding-left: 13px;
        }
        .logo-demo {
            width: 260px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolbarMySettings" runat="server" Width="100%" CausesValidation="false">
        <Items>
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="Save" CommandName="Save" ToolTip="Save" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonCancel" Text="" Value="Cancel" CommandName="Cancel" ToolTip="Cancel"  />
            <telerik:RadToolBarButton IsSeparator="true" Value="RadToolBarButtonProfileAdministrationSeparator" />
            <telerik:RadToolBarButton Text="Profile Administration" Value="ProfileAdministration" CommandName="ProfileAdministration" ToolTip="Profile Administration" />
        </Items>
    </telerik:RadToolBar>
    <div style="width:99%;">
        <div style="position: relative; width: 50%; vertical-align: top; float: left;padding:0px 2px 0px 0px;">
            <div id="DivLogo" runat="server">
                <h4>Sign In Logo</h4>
                <telerik:RadComboBox ID="RadComboBoxLogo" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadComboBoxItem Text="Light" Value="Light" />
                        <telerik:RadComboBoxItem Text="Dark" Value="Dark" />
                        <telerik:RadComboBoxItem Text="Sidebar color" Value="Themed" />
                    </Items>
                </telerik:RadComboBox>
            </div>
            <div id="DivBackground" runat="server">
                <h4>Background</h4>
                <div>
                    <div style="display: block;">
                        <div style="display: inline-block;">
                            <div>
                                Workspace color
                            </div>
                            <div>
                                <telerik:RadColorPicker ID="RadColorPickerSimpleLayoutBackground" runat="server" AutoPostBack="True">
                                </telerik:RadColorPicker>
                            </div>
                        </div>
                        <div style="display: inline-block; margin: 0px 0px 0px 20px;">
                            <div>
                                Sidebar color
                            </div>
                            <div>
                                <telerik:RadColorPicker ID="RadColorPickerSideBar" runat="server" AutoPostBack="true">
                                </telerik:RadColorPicker>
                            </div>
                        </div>
                    </div>
                    <div style="display:none !important;">
                        <div>
                            Icon Style
                        </div>
                        <div>
                            <asp:RadioButtonList ID="RadioButtonListIconStyle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true">
                                <asp:ListItem Text="White" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Dark Grey" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <div>
                    <asp:CheckBox ID="CheckBoxSignInBackground" runat="server" Text="Use this background on Sign In page" />
                </div>

            </div>
            <div id="DivLeftSideBar" runat="server">
                <h4>Left Side Bar</h4>
                <asp:CheckBox ID="CheckBoxShowNewMenu" runat="server" Text="Show Aqua Menu" /><asp:CheckBox ID="CheckBoxShowApplicationsMenu" runat="server" Text="Show Modules Menu" />
            </div>
            <div>
                <div id="DivTheme" runat="server">
                    <h4>Theme</h4>
                    <asp:RadioButtonList ID="RadioButtonListTheme" runat="server" RepeatLayout="Table" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Small" Value="Metro"></asp:ListItem>
                        <asp:ListItem Text="Large" Value="Bootstrap"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div id="DivWorkspaceOptions" runat="server">
                <h4>Workspace Options</h4>
                <div style="display: none !important;">
                    <asp:CheckBox ID="CheckBoxLegacyLayout" runat="server" Text="Legacy Layout" AutoPostBack="true" />
                </div>
                <div id="DivFloatObjects" runat="server">
                    <asp:CheckBox ID="CheckBoxFloatObjects" runat="server" Text="Float Objects" />
                </div>
                <div id="DivSingleOrFullMenu" runat="server" style="display: none !important;">
                    <asp:RadioButton ID="RadioButtonMenuSingeNode" runat="server" Text="Short Menu" GroupName="MainMenuType"
                        AutoPostBack="true" />
                    <asp:RadioButton ID="RadioButtonMenuFull" runat="server" Text="Full Menu" GroupName="MainMenuType"
                        AutoPostBack="true" />
                </div>
                <div id="DivClickToOpen" runat="server">
                    <asp:CheckBox ID="CheckBoxClickToOpenAppMenu" runat="server" Text="Click To Open App Menu" AutoPostBack="false" />
                    <asp:CheckBox ID="CheckBoxClickToOpenUserMenu" runat="server" Text="Click To Open User Menu"
                        AutoPostBack="false" />
                </div>
                <div id="DivEnableWeather" runat="server">
                    <asp:CheckBox ID="CheckBoxEnableWeather" runat="server" Text="Enable weather*" AutoPostBack="false" />
                </div>
            </div>
            <div id="DivMyProfile" runat="server">
                <h4>My Profile</h4>
                <dx:ASPxBinaryImage ID="ASPxBinaryImageEmployeePicture" runat="server" BinaryStorageMode="Session" EmptyImage-Url="~/Images/Icons/Color/256/user.png" Width="100px" Height="100px">
                </dx:ASPxBinaryImage>
                <br />
                <asp:LinkButton ID="LinkButtonUploadEmployeePicture" runat="server" Text="Upload Picture"></asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="LinkButtonDeleteEmployeePicture" runat="server" Text="Remove Picture"></asp:LinkButton>
                <br />
                Nickname:
                <br />
                <asp:TextBox ID="TextBoxNickName" runat="server" MaxLength="10" SkinID="TextBoxStandard"></asp:TextBox>
            </div>
            <div>
                <p style="font-size:small;">
                   <asp:Label ID="LabelWeatherWarning" runat="server" Text="* If you notice a delay when signing into Webvantage, disable weather!"></asp:Label>
                </p>
            </div>
        </div>
        <div style="position: relative; width: 49%; vertical-align: top; float: right;padding:0px 0px 0px 2px;">
            <h4>Preview</h4>
            <div style="margin: 15px 4px 20px 10px;">
                <telerik:RadWindow ID="RadWindowImac" runat="server" Width="270" Height="145" Visible="true" Left="90" Top="95" IconUrl="~/Images/blank.ico"
                    Title="Window" VisibleOnPageLoad="true" Behaviors="Minimize, Move" VisibleStatusbar="false"
                    RestrictionZoneID="DivPreview">
                    <ContentTemplate>
                        <telerik:RadToolBar ID="RadToolBarImac" runat="server" Width="100%">
                            <Items>
                                <telerik:RadToolBarButton Text="Toolbar">
                                </telerik:RadToolBarButton>
                            </Items>
                        </telerik:RadToolBar>
                    </ContentTemplate>
                </telerik:RadWindow>
                <div id="DivPreview" style="width: 100%; height: 340px; margin-bottom: 22px; box-shadow: 2px 2px 5px #cecece;border: 1px solid #666666;" class="CssImacContent">
                    <telerik:RadMenu ID="RadMenuImac" runat="server" Width="100%" Visible="True">
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
                        </Items>
                    </telerik:RadMenu>
                    <div style="float:left;padding: 8px 0px 0px 8px;">
                        <asp:Image ID="ImageSignInLogo" runat="server" ImageUrl="Images/Logos/aqualogo_white.png" CssClass="logo-demo" />
                    </div>
                    <div id="DivPreviewSidebar" runat="server" class="pad-sidebar">
                        <asp:Image ID="ImagePreview1" runat="server" ImageUrl="~/Images/Icons/White/256/arrow_right.png" CssClass="main-icons-simple-home" />
                        <asp:Image ID="ImagePreview2" runat="server" ImageUrl="~/Images/Icons/White/256/arrow_left.png" CssClass="main-icons-simple-home" />
                        <asp:Image ID="ImagePreview3" runat="server" ImageUrl="~/Images/Icons/White/256/book_bookmark.png" CssClass="main-icons-simple-home" />
                    </div>
                </div>
            </div>
            <div id="DivTimeZone" runat="server" style="margin: 0px 0px 0px 0px;">
                <h4>My Timezone</h4>
                <telerik:RadComboBox ID="RadComboBoxEmployeeTimeZone" runat="server" Width="300" AutoPostBack="false">
                </telerik:RadComboBox>
            </div>
        </div>
    </div>
</asp:Content>
