<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopCashBalance.ascx.vb"
    Inherits="Webvantage.DesktopCashBalance" %>
<div class="DO-ButtonHeader">
    <div style="float: left; width: 50%">
        <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint" OnClientClick="window.open('dtp_CashBalance.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;" />
        <asp:ImageButton ID="ImageButtonRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />

    </div>
</div>
<div style="clear: both;" />
<div class="DO-Container">
    <telerik:RadGrid ID="RadGridSummary" runat="server" ShowFooter="false" AutoGenerateColumns="False"
        EnableViewState="false" GridLines="None" EnableEmbeddedSkins="True" ShowHeader="false"
        ShowStatusBar="false" ShowGroupPanel="false">
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="CashType,Amount,Debit,Credit">
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
</div>
<div class="DO-Container">
    <telerik:RadGrid ID="RadGridBankBalance" runat="server" ShowFooter="false" AutoGenerateColumns="False"
        AllowSorting="true" EnableViewState="false" GridLines="None" EnableEmbeddedSkins="True"
        ShowHeader="true" ShowStatusBar="false" ShowGroupPanel="false">
        <MasterTableView AutoGenerateColumns="False">
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn Resizable="False" Visible="False">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridBoundColumn DataField="Bank" ReadOnly="True" SortExpression="Bank" UniqueName="ColBank" HeaderText="Bank">
                    <HeaderStyle HorizontalAlign="left" Width="33%" />
                    <ItemStyle HorizontalAlign="left" Width="33%" />
                    <FooterStyle HorizontalAlign="left" Width="33%" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="Account" ReadOnly="True" SortExpression="Account" HeaderText="Account"
                    UniqueName="ColAccount">
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
</div>
