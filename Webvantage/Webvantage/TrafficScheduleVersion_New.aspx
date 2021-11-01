<%@ Page Title="New Project Schedule Version Details" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="TrafficScheduleVersion_New.aspx.vb" Inherits="Webvantage.TrafficScheduleVersion_New" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <telerik:RadToolBar ID="RadToolbarJobTrafficVersion" runat="server" AutoPostBack="false" Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonSave"
                Visible="True" Text="" Value="save" ToolTip="Save the current Schedule as a new Version" />
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton SkinID="RadToolBarButtonCopy" Visible="True" Text="Copy" Value="copy" ToolTip="Make a copy of this version" />
            <telerik:RadToolBarButton IsSeparator="true" value="RadToolBarSeparatorCopy" />
        </Items>
    </telerik:RadToolBar>
    <div id="main" style="padding-right: 30px;">
        <asp:HiddenField ID="HiddenFieldLoadedVersionId" runat="server" Value="0" />
        <table width="100%" border="0" cellspacing="2" cellpadding="0">
            <tr>
                <td align="right" valign="middle">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td width="175" align="right" valign="middle" style="padding-bottom: 5px">Version Name:&nbsp;</td>
                <td style="padding-bottom: 5px">
                    <asp:TextBox ID="TextBoxVersionName" runat="server" CssClass="RequiredInput" Width="275px" SkinID="TextBoxStandard"
                        ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorVersionName" runat="server" ControlToValidate="TextBoxVersionName"
                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                        ErrorMessage="<br />Version Name is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">Version Description:&nbsp;</td>
                <td align="left" valign="top">
                    <asp:TextBox ID="TextBoxVersionDescription" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                        Width="283px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorVersionDescription" runat="server" ControlToValidate="TextBoxVersionDescription"
                        CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                        ErrorMessage="<br />Version Description is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="middle" style="padding-bottom: 5px">Created on:&nbsp;</td>
                <td style="padding-bottom: 5px">
                    <asp:Label ID="LabelCreatedDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr id="TrLastApplied" runat="server">
                <td align="right" valign="middle">Last applied:&nbsp;</td>
                <td>
                    <asp:Label ID="LabelLastApplied" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">Created Comment:&nbsp;</td>
                <td align="left" valign="top">
                    <asp:TextBox ID="TextBoxCreatedComment" runat="server" SkinID="TextBoxStandard"
                        Width="283px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="middle">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div id="DivCopy" runat="server">
            <h4>
                Copy
            </h4>
            <table id="TableCopy" runat="server" width="100%" border="0" cellspacing="2" cellpadding="0">
                <tr>
                    <td align="right" valign="middle">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td width="175" align="right" valign="middle">Version Name:</td>
                    <td>
                        <asp:TextBox ID="TextBoxCopyVersionName" runat="server" CssClass="RequiredInput"
                            SkinID="TextBoxCodeSingleLineDescription"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCopyVersionName"
                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                            ErrorMessage="<br />Version Name is required."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">Version Description:</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="TextBoxCopyVersionDescription" runat="server" CssClass="RequiredInput" SkinID="TextBoxStandard"
                            Width="275px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxCopyVersionDescription"
                            CssClass="required" Display="Dynamic" EnableClientScript="true" Enabled="true"
                            ErrorMessage="<br />Version Description is required."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="top">Created Comment:</td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="TextBoxCopyCreatedComment" runat="server" SkinID="TextBoxStandard"
                            Width="275px" TextMode="MultiLine" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" valign="middle">&nbsp;</td>
                    <td>
                        <asp:Button ID="ButtonSaveCopy" runat="server" Text="Save" />
                        <asp:Button ID="ButtonCancelCopy" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script>
        function closeWindow() {
            window.close();
        }
    </script>
</asp:Content>
