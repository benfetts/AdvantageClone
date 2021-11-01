<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="dtp_CashBalance.aspx.vb" Inherits="Webvantage.dtp_CashBalance" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table id="TableSummaryRadGrid" width="100%" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridSummary" runat="server" ShowFooter="false" AutoGenerateColumns="False"
                    GridLines="None" EnableEmbeddedSkins="True" ShowHeader="false" ShowStatusBar="false"
                    ShowGroupPanel="false">
                    <MasterTableView AutoGenerateColumns="False">
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="CashType" ReadOnly="True" SortExpression="CashType"
                                UniqueName="ColCashType">
                                <HeaderStyle HorizontalAlign="left" Width="50%" />
                                <ItemStyle HorizontalAlign="left" Width="50%" />
                                <FooterStyle HorizontalAlign="left" Width="50%" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Amount" ReadOnly="True" SortExpression="Amount"
                                DataFormatString="{0:#,###.00}" UniqueName="ColAmount">
                                <HeaderStyle HorizontalAlign="right" Width="50%" />
                                <ItemStyle HorizontalAlign="right" Width="50%" />
                                <FooterStyle HorizontalAlign="right" Width="50%" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <table id="TableBankBalance" width="100%" border="0" cellspacing="2" cellpadding="0">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridBankBalance" runat="server" ShowFooter="false" AutoGenerateColumns="False"
                    AllowSorting="true" GridLines="None" EnableEmbeddedSkins="True" ShowHeader="true"
                    ShowStatusBar="false" ShowGroupPanel="false">
                    <MasterTableView AutoGenerateColumns="False">
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridBoundColumn DataField="Bank" ReadOnly="True" SortExpression="Bank" UniqueName="ColBank"
                                HeaderText="Bank">
                                <HeaderStyle HorizontalAlign="left" Width="33%" />
                                <ItemStyle HorizontalAlign="left" Width="33%" />
                                <FooterStyle HorizontalAlign="left" Width="33%" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Account" ReadOnly="True" SortExpression="Account"
                                HeaderText="Account" UniqueName="ColAccount">
                                <HeaderStyle HorizontalAlign="left" Width="33%" />
                                <ItemStyle HorizontalAlign="left" Width="33%" />
                                <FooterStyle HorizontalAlign="left" Width="33%" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Balance" ReadOnly="True" SortExpression="Balance"
                                HeaderText="Balance" DataFormatString="{0:#,###.00}" UniqueName="ColBalance">
                                <HeaderStyle HorizontalAlign="right" Width="34%" />
                                <ItemStyle HorizontalAlign="right" Width="34%" />
                                <FooterStyle HorizontalAlign="right" Width="34%" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>
