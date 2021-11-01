<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" 
    CodeBehind="Media_ATB_Print.aspx.vb" Inherits="Webvantage.Media_ATB_Print" %>
<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td>
                <telerik:RadToolBar ID="RadToolbar_ATBPrint" runat="server" AutoPostBack="True"
                    Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonPrint" Value="Print" ToolTip="Print" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="SendAlert" ToolTip="Send Alert" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" Value="SendAssignment" ToolTip="Send Assignment" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonEmail" Value="SendEmail" ToolTip="Send Email" />
                        <telerik:RadToolBarButton Value="Save" ToolTip="Save Settings" SkinID="RadToolBarButtonSave" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                    </Items>
                </telerik:RadToolBar>
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;&nbsp;Options
            </td>
        </tr>
        <tr>
            <td style="height: 45px">
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td colspan="4" height="5px">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label_ReportFormat" runat="server" Text="Report Format:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<telerik:RadComboBox ID="RadComboBox_ReportFormat" runat="server" AutoPostBack="true"
                                Width="350px" OnSelectedIndexChanged="RadComboBox_ReportFormat_SelectedIndexChanged">
                                <Items>
                                    <telerik:RadComboBoxItem Text="001 - ATB Report" Value="Report"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="002 - ATB Form" Value="Form"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label_SignatureLines" runat="server" Text="Signature Lines:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<telerik:RadComboBox ID="RadComboBox_Signature" runat="server" AutoPostBack="true" Width="350px">
                                <Items>
                                    <telerik:RadComboBoxItem Text="0" Value="0"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="1" Value="1"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="2" Value="2"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="3" Value="3"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Text="4" Value="4"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label_ReportTitle" runat="server" Text="Report Title:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<asp:TextBox ID="TextBox_ReportTitle" runat="server" MaxLength="40" Width="350px" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 159px;" align="right">
                            <asp:Label   ID="Label_Location" runat="server" Text="Location ID:"></asp:Label>
                        </td>
                        <td style="width: 432px;">
                            &nbsp;<telerik:RadComboBox ID="RadComboBox_LocationID" runat="server" AutoPostBack="true" Width="350px">
                                  </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" height="5px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>

</asp:Content>
