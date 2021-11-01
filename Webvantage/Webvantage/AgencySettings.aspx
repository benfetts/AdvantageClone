<%@ Page Title="Agency Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="AgencySettings.aspx.vb" Inherits="Webvantage.AgencySettings" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">

    <div style="width:900px;">
        <div runat="server" id="TableClientPortalSelect">
            <telerik:RadComboBox ID="RadComboBoxClientPortalClients" runat="server" Width="300" SkinID="RadComboBoxStandard"
                AutoPostBack="true">
            </telerik:RadComboBox>
        </div>
        <div runat="server" id="TableAgencyBranding">
            <div id="TrEnableBranding" runat="server">
                <div style="margin: 4px 0px 0px 4px; font-size: x-large; font-weight: bold;">
                    <asp:CheckBox ID="CheckboxUseAgencyBranding" runat="server" Text="" />
                    <asp:Label ID="LabelUseAgencyBranding" runat="server" Text="Enable Agency Branding"></asp:Label>
                </div>
            </div>
            <div>
                <h4 style="margin-bottom: 10px; margin-top: 10px;">Logo</h4>
                <asp:Label ID="LabelCurrentAgencyLogoFilename" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButtonUploadAgencyLogo" runat="server" Text="Upload"></asp:LinkButton>
                <asp:LinkButton ID="LinkButtonRemoveAgencyLogo" runat="server" Text="Remove"></asp:LinkButton>
                <asp:HiddenField ID="HiddenFieldAgencyLogoFilename" runat="server" />
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                    <div style="margin: 4px 0px 10px 0px;" id="DivLogo" runat="server">
                        <div>
                            <asp:CheckBox ID="CheckBoxShowLogoOnWorkspaces" runat="server" Text="Show logo on workspaces" AutoPostBack="true" />
                        </div>
                        <div>
                            <asp:RadioButtonList ID="RadioButtonListWorkspaceLogoPosition" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="false">
                                <asp:ListItem Text="Top Left" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Top Right" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Center" Value="4"></asp:ListItem>
                                <asp:ListItem Text="Bottom Right" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Bottom Left" Value="3"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            <div style="display: block;margin: 10px 0px 0px 0px;">
                <h4 style="margin-bottom: 10px">Colors&nbsp;&nbsp;<asp:CheckBox ID="CheckboxAllowUsersToSetTheirOwnColors" runat="server" Text="Allow users to set their own" /></h4>
                <div style="display: inline-block;">
                    <div>
                        <asp:Label ID="LabelLogin" runat="server" Text="Workspace color"></asp:Label>
                    </div>
                    <div>
                        <telerik:RadColorPicker ID="RadColorPickerSimpleLayoutBackground" runat="server" AutoPostBack="True">
                        </telerik:RadColorPicker>
                    </div>
                </div>
                <div style="display: inline-block; margin: 0px 0px 0px 20px;">
                    <div>
                        <asp:Label ID="LabelAccent" runat="server" Text="Sidebar color"></asp:Label>
                    </div>
                    <div>
                        <telerik:RadColorPicker ID="RadColorPickerSideBar" runat="server" AutoPostBack="true">
                        </telerik:RadColorPicker>
                    </div>
                </div>
                <div style=" margin-top: 10px; margin-bottom: 10px;">
                    <asp:CheckBox ID="CheckBoxSignInBackground" runat="server" Text="Use workspace color on Sign In page" />
                </div>
                <div id="DivIconStyle" runat="server" style=" margin-top: 10px; margin-bottom: 10px;">
                    Icon Style:
                    <asp:RadioButtonList ID="RadioButtonListIconStyle" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true">
                        <asp:ListItem Text="White" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Dark Grey" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div id="DivTheme" runat="server">
                <h4 style=" margin-top: 6px; margin-bottom: 6px;">Theme
                    <asp:CheckBox ID="CheckboxUsersCanChangeTheme" runat="server" Text="Allow users to set their own" /><br />
                </h4>
                <div style="margin: 6px 0;">
                     <telerik:RadComboBox ID="RadComboBoxTheme" runat="server" AutoPostBack="false" Width="100%" SkinID="RadComboBoxStandard">
                                    </telerik:RadComboBox>
                </div>
               
            </div>
            <div id="DivWorkspace" runat="server">
                <h4 style="margin-bottom: 4px; margin-top: 10px; margin-bottom: 10px;">Workspace Defaults</h4>
                <asp:CheckBox ID="CheckBoxFloatObjects" runat="server" Text="Float Objects" />
                <br />
                <asp:RadioButton ID="RadioButtonMenuSingeNode" runat="server" Text="Short Menu" GroupName="MainMenuType"
                    AutoPostBack="false" />
                <asp:RadioButton ID="RadioButtonMenuFull" runat="server" Text="Full Menu" GroupName="MainMenuType"
                    AutoPostBack="false" />
                <br />
                <asp:CheckBox ID="CheckBoxClickToOpenAppMenu" runat="server" Text="Click To Open App Menu"
                    AutoPostBack="false" />
                <asp:CheckBox ID="CheckBoxClickToOpenUserMenu" runat="server" Text="Click To Open User Menu"
                    AutoPostBack="false" />
            </div>
            <div id="TrEnableWeather" runat="server">
                <asp:CheckBox ID="CheckBoxEnableWeather" runat="server" Text="Enable weather *&nbsp;&dagger;" AutoPostBack="false" />
            </div>
            <div style="padding-top: 25px;">
                <asp:Button ID="ButtonSaveBrandingOptions" runat="server" Text="Save" />
                <asp:Button ID="ButtonOpenPreviewWindow" runat="server" Text="Preview" Visible="false" />
                <asp:Button ID="ButtonCloseAndRefresh" runat="server" Text="Close and Refresh" Visible="true" OnClientClick="ShowMessage('If you do not immediately see your changes.\nSign out and sign back in.');return true;" />
                <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" />
            </div>
            <div id="DivWeatherWarning" runat="server" style="font-size: small; font-style: italic; padding-top: 10px;">
                * If you notice a delay when signing into Webvantage, disable weather!<br />
                &dagger; Users <b>cannot</b> override this setting!
            </div>
        </div>
    </div>
</asp:Content>
