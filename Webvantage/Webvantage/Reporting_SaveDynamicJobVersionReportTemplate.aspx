<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_SaveDynamicJobVersionReportTemplate.aspx.vb"
     Inherits="Webvantage.Reporting_SaveDynamicJobVersionReportTemplate"
    Title="Save Report Template" MasterPageFile="~/ChildPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" border="0" cellpadding="0" cellspacing="0" 
        width="100%">
        <tr>
            <td runat="server" id="TdRadToolBarDynamicReportTemplates" align="left" valign="top"
                colspan="2">
                <telerik:RadToolBar ID="RadToolBarDynamicReportTemplates" runat="server" AutoPostBack="true"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorFirstSeparator" runat="server" IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonSave" runat="server" Text="" Value="Save"
                            CommandName="Save" ToolTip="Save Report Template" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonCancel" runat="server" Text="Cancel"
                            Value="Cancel" CommandName="Cancel" ToolTip="Cancel" SkinID="RadToolBarButtonCancel" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorThirdSeparator" runat="server" IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table width="100%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelReportType" runat="server" Text="Template: " Font-Bold="True"
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <telerik:RadComboBox ID="RadComboBoxReportTemplate" runat="server" AutoPostBack="false" Width="97%" Enabled="False">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelDescription" runat="server" Text="Report Description: "
                                Font-Bold="True" Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="TextBoxDescription" runat="server" Text="" CssClass="CssTextBox" SkinID="TextBoxStandard"
                                Width="96%">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelReportCategory" runat="server" Text="Report Category: " Font-Bold="True"
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <telerik:RadComboBox ID="RadComboBoxReportCategory" runat="server" AutoPostBack="false"
                                Width="97%" DataTextField="Description" DataValueField="ID">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
