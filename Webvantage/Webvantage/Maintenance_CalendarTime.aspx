<%@ Page Title="Calendar Time Settings" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Maintenance_CalendarTime.aspx.vb" Inherits="Webvantage.Maintenance_CalendarTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">    
        <div class="code-description-container">
            <div class="code-description-label">
                Calendar Type:
            </div>
            <div class="code-description-description">
                <telerik:RadComboBox ID="RadComboBoxCalendarType" runat="server" AutoPostBack="true" Width="150" SkinID="RadComboBoxStandard">
                </telerik:RadComboBox>
            </div>
        </div>
        <div id="DivEmail" runat="server" class="code-description-container">
            <div class="code-description-label">
                Email Address:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxEmailAddress" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div id="DivEmailUserName" runat="server" class="code-description-container">
            <div class="code-description-label">
                Email User Name:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxEmailUserName" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div id="DivEmailPassword" runat="server" class="code-description-container">
            <div class="code-description-label">
                Email Password:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxEmailPassword" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50" TextMode="Password"></asp:TextBox>
            </div>
        </div>
        <div id="DivHost" runat="server" class="code-description-container">
            <div class="code-description-label">
                Host:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxHost" runat="server" SkinID="TextBoxCodeSingleLineDescription" MaxLength="50"></asp:TextBox>
            </div>
        </div>
        <div id="DivPort" runat="server" class="code-description-container">
            <div class="code-description-label">
                Port Number:
            </div>
            <div class="code-description-description">
                <asp:TextBox ID="TextBoxPort" runat="server" SkinID="TextBoxCodeSmall" MaxLength="4"></asp:TextBox>
            </div>
        </div>
        <div id="DivSSL" runat="server" class="code-description-container">
            <div class="code-description-label">
                &nbsp;
            </div>
            <div class="code-description-description">
                <asp:CheckBox id="CheckboxSSL" runat="server" Text="Use SSL"/>
            </div>
        </div>
        <div id="DivGoogleServices" runat="server">            
            <div class="bottom-buttons">
                <asp:Label ID="LabelCalendarSync" runat="server"></asp:Label>
                <telerik:RadButton ID="RadButtonDisableCalendarSync" runat="server" ButtonType="LinkButton" Text="Disable" Visible="false"></telerik:RadButton>
                <telerik:RadButton ID="RadButtonEnableCalendarSync" runat="server" ButtonType="LinkButton" Text="Enable" Visible="false"></telerik:RadButton>
            </div>
        </div>
        <div>            
            <div class="bottom-buttons">
                <asp:Button ID="ButtonSave" runat="server" Text="Save Settings" />
            </div>
        </div>
</asp:Content>
