<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_directExpenseAlert.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_directExpenseAlert" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td align="Left">
                &nbsp;<asp:Label   ID="Label1" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Label   ID="lblType" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False">
        <MasterTableView AllowMultiColumnSorting="True" Width="100%" ShowFooter="true">
            <Columns>
                <telerik:GridBoundColumn DataField="GLACODE" HeaderText="GL Code" UniqueName="column1">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="GLADESC" HeaderText="GL Account" UniqueName="column2">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="VN_FRL_EMP_CODE" HeaderText="Vendor Code" UniqueName="column3">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="VN_NAME" HeaderText="Vendor Name" UniqueName="column4">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AP_INV_VCHR" HeaderText="Invoice Number" UniqueName="column5">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="AMT" HeaderText="Net Amount" DataFormatString="{0:#,##0.00}" UniqueName="column6" Aggregate="Sum">
                    <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                    <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                </telerik:GridBoundColumn>
            </Columns>
            <ExpandCollapseColumn Visible="False">
                <HeaderStyle Width="19px" />
            </ExpandCollapseColumn>
            <RowIndicatorColumn Visible="False">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
        </MasterTableView>
        <ClientSettings>
            <Scrolling UseStaticHeaders="False" />
        </ClientSettings>
    </telerik:RadGrid>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>