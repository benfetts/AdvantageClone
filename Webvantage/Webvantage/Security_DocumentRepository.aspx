<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Security_DocumentRepository.aspx.vb"
    Inherits="Webvantage.Security_DocumentRepository" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div style="width: 600px;">
        <style>
            .code-description-container {
                padding: 4px 0px 6px 0px;
            }
        </style>
        <fieldset style="padding: 40px 0px 30px 0px;">
            <div class="code-description-container">
                <div class="code-description-label">
                    Path
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="UNCPathTextBox" runat="server" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UNCPathTextBox"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Domain
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="DomainTextBox" runat="server" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DomainTextBox"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label">
                    Username
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="UserNameTextBox" runat="server" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="UserNameTextBox"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="code-description-container">
                <div class="code-description-label" style="vertical-align: top!important;">
                    Password
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PasswordTextBox"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><br />
                    <small>For security reasons you must re-enter the password.</small>
                </div>
            </div>
            <div id="TrFileSizeLimit" runat="server" class="code-description-container">
                <div class="code-description-label">
                    File Size Limit
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtFileSizeLimit" runat="server" TextMode="SingleLine" MaxLength="4"
                        Style="text-align: right;" SkinID="TextBoxCodeMedium"></asp:TextBox>&nbsp;<span style="line-height: 24px;">MB&nbsp;(0-<asp:Label
                            ID="LblFileSizeMax" runat="server" Text=""></asp:Label>)</span>
                </div>
            </div>
            <div id="TrRepositorySizeLimit" runat="server" class="code-description-container">
                <div class="code-description-label">
                    Total Repository<br />
                    Size Limit
                </div>
                <div class="code-description-description">
                    <asp:TextBox ID="TxtRepositorySizeLimit" runat="server" TextMode="SingleLine" Style="text-align: right;"
                        MaxLength="6" SkinID="TextBoxCodeMedium"></asp:TextBox>&nbsp;<span style="line-height: 24px;">GB</span>
                </div>
            </div>
            <div style="float: right; display: inline-block; margin-top: 30px; margin-right:0px; margin-bottom: 4px;">
                <div id="buttonsContainer" class="k-button-group">
                    <asp:Button ID="CanceButton" runat="server" Text="Cancel" CausesValidation="False" CssClass="k-button" ToolTip="Cancel"/>
                    <asp:Button ID="SaveButton" runat="server" Text="Save"  CssClass="k-button k-primary" ToolTip="Save"/>&nbsp;
                </div>
            </div>
        </fieldset>
        <div id ="DivFixThumbnails" runat="server" style="margin: 20px; padding: 10px; border: 1px solid red; width: 50%">
            <div >
                Missing Expense Thumbnails: <asp:Label ID="LabelMissingExpenseThumbnailCount" runat="server" Text="0"></asp:Label>
            </div>
            <div style="margin: 10px 0;">
                <asp:Button ID="ButtonFixThumbnails" runat="server" Text="Fix Thumbnails" CausesValidation="False" ToolTip="Click to fix the latest 250 missing thumbnails" />
            </div>
        </div>
        <div style="margin:0px 0px 0px 160px; width: 100%; text-align: center;">
            <telerik:RadRadialGauge runat="server" ID="RadRadialGaugeRepositoryUsed" Width="270" Height="270">
                <Pointer>
                    <Cap Size=".1" />
                </Pointer>
                <Scale Min="0" MajorUnit="250">
                    <Labels Format="{0}" />
                    <Ranges>
                    </Ranges>
                </Scale>
            </telerik:RadRadialGauge>
            <div id="TrRepositorySize" runat="server" style="font-weight:bold;font-size:large;width:270px;text-align:center;margin: -20px 0px 0px 0px;">
                    Currently Using&nbsp;&nbsp;<asp:Label ID="LblRepositorySize" runat="server" Text="0"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
