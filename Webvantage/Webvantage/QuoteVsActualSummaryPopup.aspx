<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="QuoteVsActualSummaryPopup.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Title="Quote Vs Actual Summary" Inherits="Webvantage.QuoteVsActualSummaryPopup"
    EnableViewState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">
        <%--<script type="text/javascript">
            function RadGridQvASummaryColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridQvASummary.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
            }
        </script>--%>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="container-fluid">
    <div class="telerik-aqua-body" style="margin-top: 5px!important; max-width: 96%!important;">
        <telerik:RadTabStrip ID="SummaryTabs" runat="server" AutoPostBack="True" CausesValidation="False"
                Width="100%">
                <Tabs>
                    <telerik:RadTab ID="Tab1" runat="server" Text="Root Tab">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <div style="margin-top: 5px;max-width: 100%!important;width: 100%;margin: auto;float: left;display: inline-block;text-align: center;">
                <telerik:RadToolBar ID="RadToolbarQvA" runat="server" AutoPostBack="true">
                    <Items>
                        <telerik:RadToolBarButton ID="RadToolbarButtonFunction" Text="Function" CommandName="Function" ToolTip="Function Description" Value="Function" Group="Function"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonType" Text="Type" CommandName="Type" ToolTip="Function Type" Value="Type" Group="Function"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonHeading" Text="Heading" CommandName="Heading" ToolTip="Function Heading" Value="Heading" Group="Function"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonConsolidation" Text="Consolidation" CommandName="Consolidation" ToolTip="Function Consolidation" Value="Consolidation" Group="Function"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonIncludeNB" Text="Include Non Billable" CommandName="NonBillable" ToolTip="Include Non Billable" Value="NonBillable" Group="Filter"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonBreakoutAllNB" Text="Breakout All Non Billable" CommandName="BreakoutNonBillable" ToolTip="Breakout All Non Billable" Value="BreakoutNonBillable" Group="Filter"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonBreakoutNBForFT" Text="Breakout Non Billable For Function Types" CommandName="BreakoutNonBillableFT" ToolTip="Breakout Non Billable For Function Types" Value="BreakoutNonBillableFT" Group="Filter"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonEmployeeTime" Text="Employee Time" CommandName="EmployeeTime" ToolTip="Employee Time" Value="EmployeeTime" Group="EmployeeTime"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonIncomeOnly" Text="Income Only" CommandName="IncomeOnly" ToolTip="Income Only" Value="IncomeOnly" Group="IncomeOnly"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonVendor" Text="Vendor" CommandName="Vendor" ToolTip="Vendor" Value="Vendor" Group="Vendor"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonSalesTax" Text="Resale Tax" CommandName="SalesTax" ToolTip="Show Sales Tax" Value="SalesTax" Group="SalesTax"
                            AllowSelfUnCheck="true" CheckOnClick="true" />
                        <%--<telerik:RadToolBarButton IsSeparator="true" Value="Separator2" />      
                        <telerik:RadToolBarButton CausesValidation="true" Text="Job" ID="RadToolbarButtonGroupJob" AllowSelfUnCheck="true" CheckOnClick="true"
                            CommandName="GroupJob" Value="GroupJob" Hidden="False" ToolTip="Job" />--%>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                            CommandName="Export" Value="Export" Hidden="False" ToolTip="Export" />
                    </Items>
                </telerik:RadToolBar>
            </div>
            
            <table border="0" cellspacing="2" cellpadding="0" width="100%">
                <tr>
                    <td>
                        <telerik:RadGrid ID="RadGridQvASummary" runat="server" AllowPaging="True" AutoGenerateColumns="False" EnableHeaderContextMenu="false" Width="100%" EnableOutsideScripts="True">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                            <ExportSettings FileName="QvA_Summary" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf PageTitle="QvA_Summary" Title="QvA_Summary" />
                            </ExportSettings>
                            <AlternatingItemStyle VerticalAlign="Middle" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="false">
                                <Scrolling AllowScroll="False" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                            <FooterStyle />
                            <MasterTableView CommandItemDisplay="Top" HorizontalAlign="Left" Caption="" ShowGroupFooter="true" NoMasterRecordsText="" NoDetailRecordsText=""
                                ShowFooter="true" ShowHeadersWhenNoRecords="true" GridLines="Horizontal" EnableHierarchyExpandAll="True">
                                <CommandItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="left" width="50%">
                                                <asp:Label ID="lblJob" runat="server" Text="Job:"></asp:Label>
                                                <asp:Label ID="lblJobNumber" runat="server"></asp:Label>&nbsp;/&nbsp;
                                                <asp:Label ID="lblJobComp" runat="server" Text="Job Comp:"></asp:Label>
                                                <asp:Label ID="lblJobCompNum" runat="server"></asp:Label>
                                            </td>
                                            <%--<td align="right">
                                                <asp:Button ID="btnExpand" runat="server" CommandName="Expand" Text="Expand" />
                                            </td>--%>
                                        </tr>
                                    </table>
                                </CommandItemTemplate>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="False" Resizable="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn DataField="FNC_DESCRIPTION" FooterText="Grand Total:"
                                        HeaderText="Function Description" HeaderAbbr="FIXED" UniqueName="GridBoundColumnFNC_DESCRIPTION">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle />
                                        <ItemTemplate>
                                            <%# Eval("FNC_DESCRIPTION") %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="QuotedAmount" HeaderText="Quote Amount" UniqueName="GridBoundColumnQuotedAmount"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedMarkup" HeaderText="Quote Markup" UniqueName="GridBoundColumnQuotedMarkup"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTax" HeaderText="Quote Tax" UniqueName="GridBoundColumnQuotedTax"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedQtyHrs" HeaderText="Quote Qty/Hrs" UniqueName="GridBoundColumnQuotedQtyHrs"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTotal" HeaderText="Quote Total" UniqueName="GridBoundColumnQuotedTotal"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualAmount" HeaderText="Actual Amount" UniqueName="GridBoundColumnActualAmount"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualMarkup" HeaderText="Actual Markup" UniqueName="GridBoundColumnActualMarkup"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTax" HeaderText="Actual Tax" UniqueName="GridBoundColumnActualTax"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualHours" HeaderText="Actual Qty/Hrs" UniqueName="GridBoundColumnActualHours"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PercentQuote" HeaderText="% of Quote" UniqueName="GridBoundColumnPercentOfQuote"
                                        DataFormatString="{0:#,##0.00}%">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PercentQuoteAmt" HeaderText="% of Quote Amount" UniqueName="GridBoundColumnPercentOfQuoteAmt"
                                        DataFormatString="{0:#,##0.00}%">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTotal" HeaderText="Actual Total" UniqueName="GridBoundColumnActualTotal"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBHours" HeaderText="Non-Billable Qty/Hrs"
                                        Aggregate="Sum" UniqueName="GridBoundColumnNBActualHours" Display="False" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBTotal" HeaderText="Non-Billable Total"
                                        Aggregate="Sum" UniqueName="GridBoundColumnNBActualTotal" Display="False" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OpenPONetAmt" HeaderText="Open PO Net Amount"
                                        Aggregate="Sum" UniqueName="GridBoundColumnOpenPONetAmount" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APPROVED_AMT" HeaderText="Billing Approved (Pending)"
                                        Aggregate="Sum" UniqueName="GridBoundColumnAPPROVED_AMT" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BilledToDate" HeaderText="Billed To Date" UniqueName="GridBoundColumnBilledToDate"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedvsActualPO" HeaderText="Quote vs Actual/PO"
                                        Aggregate="Sum" UniqueName="GridBoundColumnQuotevsActualPO" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualPOvsBilled" HeaderText="Actual/PO vs Billed"
                                        Aggregate="Sum" UniqueName="GridBoundColumnActualPOvsBilled" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Middle" Wrap="False" />
                                <DetailTables>
                                    <telerik:GridTableView AllowSorting="True" Caption="Functions" Name="FunctionsGrid" EnableHeaderContextMenu="false"
                                        NoDetailRecordsText="" Width="100%" PagerStyle-Visible="false" ShowFooter="true" AllowPaging="False" HeaderStyle-BorderStyle="Solid" GridLines="Horizontal">
                                        <Columns>
                                            <telerik:GridTemplateColumn DataField="FNC_DESCRIPTION" FooterText="Sub Total:"
                                                HeaderText="Function Description" HeaderAbbr="FIXED" UniqueName="GridBoundColumnFNC_DESCRIPTION2">
                                                <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <FooterStyle />
                                                <ItemTemplate>
                                                    <%# Eval("FNC_DESCRIPTION") %>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridBoundColumn DataField="QuotedAmount" HeaderText="Quote Amount" UniqueName="GridBoundColumnQuotedAmount"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotedMarkup" HeaderText="Quote Markup" UniqueName="GridBoundColumnQuotedMarkup2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotedTax" HeaderText="Quote Tax" UniqueName="GridBoundColumnQuotedTax2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotedQtyHrs" HeaderText="Quote Qty/Hrs" UniqueName="GridBoundColumnQuotedQtyHrs"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotedTotal" HeaderText="Quote Total" UniqueName="GridBoundColumnQuotedTotal2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualAmount" HeaderText="Actual Amount" UniqueName="GridBoundColumnActualAmount"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualMarkup" HeaderText="Actual Markup" UniqueName="GridBoundColumnActualMarkup2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualTax" HeaderText="Actual Tax" UniqueName="GridBoundColumnActualTax2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualHours" HeaderText="Actual Qty/Hrs" UniqueName="GridBoundColumnActualHours"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PercentQuote" HeaderText="% of Quote" UniqueName="GridBoundColumnPercentOfQuote"
                                                DataFormatString="{0:#,##0.00}%">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PercentQuoteAmt" HeaderText="% of Quote Amount" UniqueName="GridBoundColumnPercentOfQuoteAmt"
                                                DataFormatString="{0:#,##0.00}%">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualTotal" HeaderText="Actual Total" UniqueName="GridBoundColumnActualTotal2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NBHours" HeaderText="Non-Billable Qty/Hrs"
                                                Aggregate="Sum" UniqueName="GridBoundColumnNBActualHours2" Display="False" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NBTotal" HeaderText="Non-Billable Total"
                                                Aggregate="Sum" UniqueName="GridBoundColumnNBActualTotal2" Display="False" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="OpenPONetAmt" HeaderText="Open PO Net Amount"
                                                Aggregate="Sum" UniqueName="GridBoundColumnOpenPONetAmount2" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="APPROVED_AMT" HeaderText="Billing Approved (Pending)"
                                                Aggregate="Sum" UniqueName="GridBoundColumnAPPROVED_AMT2" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="BilledToDate" HeaderText="Billed To Date" UniqueName="GridBoundColumnBilledToDate2"
                                                Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="QuotedvsActualPO" HeaderText="Quote vs Actual/PO"
                                                Aggregate="Sum" UniqueName="GridBoundColumnQuotevsActualPO2" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ActualPOvsBilled" HeaderText="Actual/PO vs Billed"
                                                Aggregate="Sum" UniqueName="GridBoundColumnActualPOvsBilled2" DataFormatString="{0:#,##0.00}">
                                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                                <FooterStyle HorizontalAlign="Right" />
                                            </telerik:GridBoundColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                            </MasterTableView>
                        </telerik:RadGrid>
                        <telerik:RadGrid ID="RadGridQvaSummaryFunction" runat="server" AllowPaging="True" AutoGenerateColumns="False" EnableHeaderContextMenu="false" Width="100%">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" />
                            <ExportSettings FileName="QvA_Summary" IgnorePaging="True" OpenInNewWindow="True">
                                <Pdf PageTitle="QvA_Summary" Title="QvA_Summary" />
                            </ExportSettings>
                            <AlternatingItemStyle VerticalAlign="Middle" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="false">
                                <Scrolling AllowScroll="False" ScrollHeight="100%" />
                            </ClientSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                            <FooterStyle />
                            <MasterTableView CommandItemDisplay="Top" HorizontalAlign="Left" Caption="" ShowGroupFooter="true"
                                ShowFooter="true" ShowHeadersWhenNoRecords="true" NoMasterRecordsText="" NoDetailRecordsText="">
                                <CommandItemTemplate>
                                    <table width="100%">
                                        <tr>
                                            <td align="left" width="50%">
                                                <asp:Label ID="lblJob" runat="server" Text="Job:"></asp:Label>
                                                <asp:Label ID="lblJobNumber" runat="server"></asp:Label>&nbsp;/&nbsp;
                                                <asp:Label ID="lblJobComp" runat="server" Text="Job Comp:"></asp:Label>
                                                <asp:Label ID="lblJobCompNum" runat="server"></asp:Label>
                                            </td>
                                            <%--<td align="right">
                                                <asp:Button ID="btnExpand" runat="server" CommandName="Expand" Text="Expand" />
                                            </td>--%>
                                        </tr>
                                    </table>                            
                                </CommandItemTemplate>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn Visible="False" Resizable="False">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn DataField="FNC_DESCRIPTION" FooterText="Grand Total:"
                                        HeaderText="Function Description" HeaderAbbr="FIXED" UniqueName="GridBoundColumnFNC_DESCRIPTION">
                                        <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <FooterStyle />
                                        <ItemTemplate>
                                            <%# Eval("FNC_DESCRIPTION") %>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="QuotedAmount" HeaderText="Quote Amount" UniqueName="GridBoundColumnQuotedAmount"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedMarkup" HeaderText="Quote Markup" UniqueName="GridBoundColumnQuotedMarkup"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTax" HeaderText="Quote Tax" UniqueName="GridBoundColumnQuotedTax"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedQtyHrs" HeaderText="Quote Qty/Hrs" UniqueName="GridBoundColumnQuotedQtyHrs"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedTotal" HeaderText="Quote Total" UniqueName="GridBoundColumnQuotedTotal"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualAmount" HeaderText="Actual Amount" UniqueName="GridBoundColumnActualAmount"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualMarkup" HeaderText="Actual Markup" UniqueName="GridBoundColumnActualMarkup"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTax" HeaderText="Actual Tax" UniqueName="GridBoundColumnActualTax"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualHours" HeaderText="Actual Qty/Hrs" UniqueName="GridBoundColumnActualHours"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PercentQuote" HeaderText="% of Quote" UniqueName="GridBoundColumnPercentOfQuote"
                                        DataFormatString="{0:#,##0.00}%">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PercentQuoteAmt" HeaderText="% of Quote Amount" UniqueName="GridBoundColumnPercentOfQuoteAmt"
                                        DataFormatString="{0:#,##0.00}%">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualTotal" HeaderText="Actual Total" UniqueName="GridBoundColumnActualTotal"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBHours" HeaderText="Non-Billable Qty/Hrs"
                                        Aggregate="Sum" UniqueName="GridBoundColumnNBActualHours" Display="False" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="NBTotal" HeaderText="Non-Billable Total"
                                        Aggregate="Sum" UniqueName="GridBoundColumnNBActualTotal" Display="False" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="OpenPONetAmt" HeaderText="Open PO Net Amount"
                                        Aggregate="Sum" UniqueName="GridBoundColumnOpenPONetAmount" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="APPROVED_AMT" HeaderText="Billing Approved (Pending)"
                                        Aggregate="Sum" UniqueName="GridBoundColumnAPPROVED_AMT" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" Width="50px" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="50px" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BilledToDate" HeaderText="Billed To Date" UniqueName="GridBoundColumnBilledToDate"
                                        Aggregate="Sum" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="QuotedvsActualPO" HeaderText="Quote vs Actual/PO"
                                        Aggregate="Sum" UniqueName="GridBoundColumnQuotevsActualPO" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ActualPOvsBilled" HeaderText="Actual/PO vs Billed"
                                        Aggregate="Sum" UniqueName="GridBoundColumnActualPOvsBilled" DataFormatString="{0:#,##0.00}">
                                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" />
                                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                        <FooterStyle HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <FilterItemStyle VerticalAlign="Middle" Wrap="False" />
                            </MasterTableView>
                        </telerik:RadGrid>
                    </td>
                </tr>
            </table>
    </div>
    </div>

    
</asp:Content>
