<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Reporting_InitialLoadingSaveDynamicReportTemplate.aspx.vb"
    Inherits="Webvantage.Reporting_InitialLoadingSaveDynamicReportTemplate" Title="Save Report Template"
    MasterPageFile="~/ChildPage.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
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
                        <telerik:RadToolBarButton ID="RadToolBarButtonYes" runat="server" Text="Yes" Value="Yes"
                            CommandName="Yes" ToolTip="Save Report Template" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton ID="RadToolBarSeparatorSecondSeparator" runat="server"
                            IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolBarButtonNo" runat="server" Text="No" Value="No"
                            CommandName="No" ToolTip="No" SkinID="RadToolBarButtonCancel" />
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
                <asp:Label ID="LabelQuestion" runat="server" Text="" Width="100%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td width="1%">
                &nbsp;
            </td>
            <td>
                <table id="TableDescription" runat="server" width="100%" border="0" cellspacing="2"
                    cellpadding="0">
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelReportType" runat="server" Text="Report Type: " Font-Bold="True"
                                Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <telerik:RadComboBox ID="RadComboBoxReportType" runat="server" AutoPostBack="false" Width="97%" Enabled="False">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="40%">
                            <asp:Label ID="LabelDescription" runat="server" Text="Enter Report Template Description: "
                                Font-Bold="True" Width="100%"></asp:Label>
                        </td>
                        <td width="60%">
                            <asp:TextBox ID="TextBoxDescription" runat="server" Text="" CssClass="CssTextBox" SkinID="TextBoxStandard"
                                Width="97%">
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
