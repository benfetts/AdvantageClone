<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BudgetViewpoint.aspx.vb"
    Inherits="Webvantage.BudgetViewpoint" MasterPageFile="~/ChildPage.Master" Title="Budget Viewpoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript">

        function confirmBack() {
            window.close();
            window.opener.focus();
        }

        function CallFunctionOnParentPage(fnName) {
            var oWindow = GetRadWindow();
            if (oWindow.BrowserWindow[fnName] && typeof (oWindow.BrowserWindow[fnName]) == "function") {
                oWindow.BrowserWindow[fnName](oWindow);
                oWindow.Close();
            }
            window.close()
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table id="Table1" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td valign="top">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <table border="0" cellpadding="0" style="vertical-align: top" cellspacing="0" width="97%">
                        <tr valign="top">
                            <td align="left">
                                <a href="" onclick="Javascript:window.open('dtp_BudgetViewpoint.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=600,scrollbars=no,resizable=yes,menubar=no,maximazable=no');return false;">
                                    <asp:Image ID="PrintImage" runat="server" SkinID="ImagePrint" />
                                </a>
                            </td>
                            <td align="right" valign="top">
                                <asp:Label   ID="lblGroup" runat="server"  TabIndex="-1" Text="Choose Group By Category:">
                                </asp:Label>
                                <telerik:RadComboBox ID="ddGroupBy" runat="server" AutoPostBack="true" TabIndex="1" SkinID="RadComboBoxStandard">
                                    <Items>
                                        <telerik:RadComboBoxItem Value="1" Text="All"></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Value="2" Text="By Type"></telerik:RadComboBoxItem>
                                        <telerik:RadComboBoxItem Value="3" Text="By Sales Class"></telerik:RadComboBoxItem>
                                    </Items>
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<br />
                            </td>
                        </tr>
                    </table>
                    <telerik:RadGrid ID="RadGridBudgetViewpoint" runat="server" AllowPaging="True" AllowSorting="True"
                        Enabled="true" AutoGenerateColumns="False" EnableAJAX="False" GridLines="None"
                        Width="97%">
                        <PagerStyle Mode="NextPrevAndNumeric" />
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Description" HeaderStyle-VerticalAlign="Bottom"
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="DESCRIPTION">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BUDGET_BILLING" DataFormatString="{0:#,##0.00}"
                                    ItemStyle-HorizontalAlign="Right" HeaderText="Budget<br/>Billing" HeaderStyle-VerticalAlign="Bottom"
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="BUDGET_BILLING">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="BUDGET_GI" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Budget<br/>Gross Income" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                                    UniqueName="BUDGET_GI">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ACTUAL_APPROVED_BILLING" DataFormatString="{0:#,##0.00}"
                                    ItemStyle-HorizontalAlign="Right" HeaderText="Actual<br/>Approved Billing" HeaderStyle-VerticalAlign="Bottom"
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="ACTUAL_APPROVED_BILLING">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ACTUAL_APPROVED_GI" DataFormatString="{0:#,##0.00}"
                                    ItemStyle-HorizontalAlign="Right" HeaderText="Actual<br/>Approved Gross<br/>Income"
                                    HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center" UniqueName="ACTUAL_APPROVED_GI">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ACTUAL_BILLING" DataFormatString="{0:#,##0.00}"
                                    ItemStyle-HorizontalAlign="Right" HeaderText="Actual<br/>Billing" HeaderStyle-VerticalAlign="Bottom"
                                    HeaderStyle-HorizontalAlign="Center" UniqueName="ACTUAL_BILLING">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="ACTUAL_GI" DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right"
                                    HeaderText="Actual<br/>Gross Income" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center"
                                    UniqueName="ACTUAL_GI">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <ExpandCollapseColumn Visible="False" Resizable="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                        </MasterTableView>
                    </telerik:RadGrid>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table id="table3" style="width: 100%; vertical-align: bottom" border="0" cellpadding="0"
        cellspacing="0">
        <tr align="center">
            <td>
                <br />
                <asp:Button ID="btnBack" runat="server" CommandName="Close" Text="Close" />
            </td>
        </tr>
    </table>
</asp:Content>
