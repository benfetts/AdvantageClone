<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="dtp_grossincomedetail.aspx.vb" Inherits="Webvantage.dtp_grossincomedetail" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="30%" align="left">
                &nbsp;<asp:Label   ID="lblTitle" runat="server"></asp:Label>
            </td>
            <td width="70%" align="right">
                <asp:Label   ID="lblClient" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <telerik:RadHtmlChart ID="RadHtmlChartGrossIncomeDetail" runat="server" Width="800" Height="300">

                </telerik:RadHtmlChart>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="3">
                <telerik:RadGrid ID="RadGridGrossIncome" runat="server" AllowPaging="false" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true" ShowFooter="true">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                    <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="JobNumber,ComponentNumber,OrderNumber,LineNumber,JobDescription,ComponentDescription">
                        <Columns>
                            <telerik:GridBoundColumn DataField="OfficeDescription" HeaderText="Office" UniqueName="o">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PostingPeriod" HeaderText="Period" UniqueName="pp">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="InvoiceNumber" HeaderText="Invoice Number" UniqueName="invoicenumber">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Media" HeaderText="Type" UniqueName="type">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SalesClassDescription" HeaderText="Sales Class" UniqueName="salesclass">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobNumber" HeaderText="Job/Component" UniqueName="column34">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="OrderNumber" HeaderText="Order/Line" UniqueName="column39">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BilledAmount" HeaderText="Billed Amount" UniqueName="BilledAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BilledCostOfSale" HeaderText="Billed Cost of Sale" UniqueName="BilledCostOfSale" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TotalGrossIncome" HeaderText="Billed Gross Income" UniqueName="BilledGrossIncome" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="GrossIncomePercent" HeaderText="Gross Income Percent" UniqueName="taskcolumn" DataFormatString="{0:#,##0.00}%">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
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
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />
</asp:Content>