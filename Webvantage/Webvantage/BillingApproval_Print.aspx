<%@ Page AutoEventWireup="false" CodeBehind="BillingApproval_Print.aspx.vb" Inherits="Webvantage.BillingApproval_Print"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Billing Print" %>

<asp:Content ID="ContentBillingApprovalPrint" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadToolBar ID="RadToolbarBillingApprovalPrint" runat="server" AutoPostBack="True"
        Width="100%">
        <Items>
            <telerik:RadToolBarButton IsSeparator="true" />
            <telerik:RadToolBarButton Value="Print" Text="Print" SkinID="RadToolBarButtonPrint"
                ToolTip="Print" />
            <telerik:RadToolBarButton IsSeparator="true" />
        </Items>
    </telerik:RadToolBar>
    <table cellpadding="0" cellspacing="0" width="100%" align="center" border="0">
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;Output Options
            </td>
        </tr>
        <tr>
            <td>
            <br />
                <table>
                    <tr>
                        <td style="width: 100px" align="right">
                            Template:
                        </td>
                        <td style="width: 100px">
                            <telerik:RadComboBox ID="dl_Template" runat="server" AutoPostBack="true" TabIndex="6" Width="600" SkinID="RadComboBoxStandard">
                                <Items>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;Company Location
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <table>
                    <tr>
                        <td style="width: 100px" align="right">
                            Location ID:
                        </td>
                        <td>
                            <telerik:RadComboBox ID="dl_location" runat="server" Width="600" SkinID="RadComboBoxStandard">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td class="sub-header sub-header-color">
                &nbsp;&nbsp;Printing Options
            </td>
        </tr>
        <tr>
            <td align="left">
                <br />
                <table width="100%">
                    <tr>
                        <td style="width: 100px" align="right">
                            Report Title:
                        </td>
                        <td style="width: 394px">
                            <asp:TextBox ID="txtReportTitle" runat="server" MaxLength="30" Width="388px" SkinID="TextBoxStandard"></asp:TextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" align="right">
                            &nbsp;
                        </td>
                        <td style="width: 394px">
                            <asp:CheckBox ID="cbPrintZeroLines" runat="server" Text="Print Zero Lines" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" align="right" valign="top">
                            Address Options:
                        </td>
                        <td valign="top" style="width: 394px">
                            <asp:RadioButtonList ID="rbCDPAddress" runat="server">
                                <asp:ListItem Value="Client">Client Address</asp:ListItem>
                                <asp:ListItem Value="Division">Division Address</asp:ListItem>
                                <asp:ListItem Value="Product">Product Address</asp:ListItem>
                                <asp:ListItem Value="Contact">Client Contact Address</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            <asp:CheckBox ID="cbDivisionName" runat="server" Text="Print Division Name" Checked="true" /><br />
                            <asp:CheckBox ID="cbProductName" runat="server" Text="Print Product Description"
                                Checked="true" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td style="width: 394px">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
