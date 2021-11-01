<%@ Page Title="Contact Customer Support" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Help_ContactCustomerSupport.aspx.vb" Inherits="Webvantage.Help_ContactCustomerSupport" %>

<asp:Content ID="conContactCustomerSupportContent" ContentPlaceHolderID="ContentPlaceHolderMain"
    runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockCSS" runat="server">
    </telerik:RadCodeBlock>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td align="left" valign="top" colspan="2">
                <telerik:RadToolBar ID="RadToolBarContactCustomerSupport" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSend" CssClass="icon2" runat="server" Text="Send" Value="Send"
                            CommandName="Send" ToolTip="Send new customer support message" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="2">
                            <fieldset>
                                <legend>Support Department</legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>&nbsp;
                                            <asp:CheckBox ID="CheckBoxTechnicalSupport" runat="server" Text="Technical Support" AutoPostBack="false" />
                                        </td>
                                        <td>&nbsp;
                                            <asp:CheckBox ID="CheckBoxSoftwareSupport" runat="server" Text="Software Support" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <fieldset>
                                <legend>Client Information</legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="LabelClientInformationName" runat="server" Text="Name: "></asp:Label>
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="TextBoxClientInformationName" runat="server" CssClass="RequiredInput sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="LabelClientInformationEmployeeName" runat="server" Text="Employee Name: "></asp:Label>
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="TextBoxClientInformationEmployeeName" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="LabelClientInformationPhone" runat="server" Text="Phone: "></asp:Label>
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="TextBoxClientInformationPhone" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="LabelClientInformationEmailAddress" runat="server" Text="Email Address: "></asp:Label>
                                        </td>
                                        <td width="75%">
                                            <asp:TextBox ID="TextBoxClientInformationEmailAddress" runat="server" CssClass="RequiredInput sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <fieldset>
                                                <legend>Address</legend>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:Label ID="LabelAddress" runat="server" Text="Address: "></asp:Label>
                                                        </td>
                                                        <td width="75%">
                                                            <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:Label ID="LabelAddress2" runat="server" Text="Address 2: "></asp:Label>
                                                        </td>
                                                        <td width="75%">
                                                            <asp:TextBox ID="TextBoxAddress2" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:Label ID="LabelCity" runat="server" Text="City: "></asp:Label>
                                                        </td>
                                                        <td width="75%">
                                                            <asp:TextBox ID="TextBoxCity" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:Label ID="LabelState" runat="server" Text="State: "></asp:Label>
                                                        </td>
                                                        <td width="75%">
                                                            <asp:TextBox ID="TextBoxState" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="25%">
                                                            <asp:Label ID="LabelZip" runat="server" Text="City: "></asp:Label>
                                                        </td>
                                                        <td width="75%">
                                                            <asp:TextBox ID="TextBoxZip" runat="server" CssClass="sizeFix" width="100%" SkinID="TextBoxStandard"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </fieldset>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <fieldset>
                                <legend>Issue Type</legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonIssueTypeBug" runat="server" Text="Bug" GroupName="IssueType" Checked="true" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonIssueTypeProblem" runat="server" Text="Problem" GroupName="IssueType" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonIssueTypeEnhancement" runat="server" Text="Enhancement" GroupName="IssueType" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td>
                            <fieldset>
                                <legend>Priority</legend>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonPriorityHigh" runat="server" Text="High" GroupName="Priority" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonPriorityMedium" runat="server" Text="Medium" GroupName="Priority" Checked="true" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="RadioButtonPriorityLow" runat="server" Text="Low" GroupName="Priority" AutoPostBack="false" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                    </tr>
                </table>
            </td>
            <td height="100%">
                <fieldset>
                    <legend>Description of Issue</legend>
                    <telerik:RadTextBox ID="RadTextBoxDescriptionOfIssue" runat="server" AutoPostBack="false" TextMode="MultiLine"  height="350" Width="100%" Wrap="False" />
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
