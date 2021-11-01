<%@ Page Title="Billing Approval Summary" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master" CodeBehind="BillingApproval_Approval_Summary.aspx.vb" Inherits="Webvantage.BillingApproval_Approval_Summary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="no-float-menu">
        <telerik:RadToolBar ID="RadToolBarBillingApprovalSummary" runat="server" Width="100%">
            <Items>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton Value="RadToolBarButtonLiteralDescription">
                    <ItemTemplate>
                        &nbsp;&nbsp;<asp:Literal ID="LiteralDescription" runat="server" Text="Job"></asp:Literal>&nbsp;&nbsp;&nbsp;
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;Rollup By:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonRadioButtonListRollupType">
                    <ItemTemplate>
                        <asp:RadioButtonList ID="RadioButtonListRollupType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="RadioButtonListRollupType_SelectedIndexChanged">
                            <asp:ListItem Text="Job" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Campaign" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton>
                    <ItemTemplate>
                        &nbsp;&nbsp;Group By:
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton Value="RadToolBarButtonRadComboBoxGroupBy">
                    <ItemTemplate>
                        <telerik:RadComboBox ID="RadComboBoxGroupBy" runat="server" AutoPostBack="True" SkinID="RadComboBoxStandard" OnSelectedIndexChanged="RadComboBoxGroupBy_SelectedIndexChanged">
                            <Items>
                                <telerik:RadComboBoxItem Text="Function Code" Value="FunctionCode"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Function Type" Value="FunctionType"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="Function Heading" Value="FunctionHeading"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </ItemTemplate>
                </telerik:RadToolBarButton>
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh" />
                <telerik:RadToolBarButton IsSeparator="true" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="ExportToExcel" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="bookmark" ToolTip="Bookmark" Visible="false" />
                <telerik:RadToolBarButton IsSeparator="true" />
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="telerik-float-menu">
        <telerik:RadGrid ID="RadGridBillingApprovalSummary" runat="server" AllowPaging="False" AllowSorting="false"
                AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False" Width="100%"
                EnableEmbeddedSkins="True" EnableOutsideScripts="true" ShowFooter="True"
                Visible="True">
                <ClientSettings>
                    <Scrolling AllowScroll="false" SaveScrollPosition="false" UseStaticHeaders="false" />
                </ClientSettings>
                <ExportSettings FileName="BillingApproval_ApprovalRollup" Pdf-AllowPrinting="true" IgnorePaging="true"
                    OpenInNewWindow="true" Pdf-FontType="Embed">
                    <Pdf PageWidth="297mm" PageHeight="210mm" />
                </ExportSettings>
                <MasterTableView NoMasterRecordsText="No records found" ShowGroupFooter="true">
                    <ColumnGroups>
                        <telerik:GridColumnGroup HeaderText="Quote" Name="GridColumnGroupQuote" HeaderStyle-HorizontalAlign="Center"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Actual" Name="GridColumnGroupActual" HeaderStyle-HorizontalAlign="Center"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Net" Name="GridColumnGroupNet" HeaderStyle-HorizontalAlign="Center"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Markup" Name="GridColumnGroupMarkup" HeaderStyle-HorizontalAlign="Center"></telerik:GridColumnGroup>
                        <telerik:GridColumnGroup HeaderText="Tax" Name="GridColumnGroupTax" HeaderStyle-HorizontalAlign="Center"></telerik:GridColumnGroup>
                    </ColumnGroups>
                    <Columns>
                        <telerik:GridBoundColumn DataField="FunctionCode" HeaderText="Function Code" UniqueName="GridBoundColumnFunctionCode">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="85px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="85px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="85px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FunctionDescription" HeaderText="Function Description" UniqueName="GridBoundColumnFunctionDescription" FooterText="Grand Total">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="250px" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="250px" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Top" Width="250px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QuoteQuantityHours" HeaderText="Quote Qty/Hrs" UniqueName="GridBoundColumnQuoteQuantityHours" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupQuote">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QuoteAmount" HeaderText="Quote Amount" UniqueName="GridBoundColumnQuoteAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupQuote">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActualQuantityHours" HeaderText="Actual Qty/Hrs" DataFormatString="{0:#,##0.00}" Aggregate="Sum" UniqueName="GridBoundColumnActualQuantityHours" ColumnGroupName="GridColumnGroupActual">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Actuals" HeaderText="Actual Billable Amount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" UniqueName="GridBoundColumnActualBillableAmount" ColumnGroupName="GridColumnGroupActual">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NonBillableFee" HeaderText="Non-Billable/Fee" UniqueName="GridBoundColumnNonBillableFee" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BilledHold" HeaderText="Bill Hold" UniqueName="GridBoundColumnBillHold" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OpenPO" HeaderText="Open PO" UniqueName="GridBoundColumnOpenPO" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BilledReceived" HeaderText="Billed" UniqueName="GridBoundColumnBilled" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Unbilled" HeaderText="Unbilled" UniqueName="GridBoundColumnUnbilled" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Quantity" HeaderText="Quantity" UniqueName="GridBoundColumnQuantity" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ApprovedNet" HeaderText="Net Approved Amount" UniqueName="GridBoundColumnNetApprovedAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupNet">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QuoteNet" HeaderText="Net Quote Amount" UniqueName="GridBoundColumnNetQuoteAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupNet">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UnbilledNet" HeaderText="Net Unbilled Amount" UniqueName="GridBoundColumnNetUnbilledAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupNet">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ApprovedMarkupAmount" HeaderText="Markup Amount" UniqueName="GridBoundColumnMarkupAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupMarkup">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QuoteMarkup" HeaderText="Quote Markup Amount" UniqueName="GridBoundColumnQuoteMarkupAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupMarkup">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UnbilledMarkup" HeaderText="Unbilled Markup Amount" UniqueName="GridBoundColumnUnbilledMarkupAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupMarkup">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ApprovedTax" HeaderText="Approved Tax Amount" UniqueName="GridBoundColumnTaxAmountApproved" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupTax">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UnbilledTax" HeaderText="Unbilled Tax Amount" UniqueName="GridBoundColumnTaxAmountUnbilled" DataFormatString="{0:#,##0.00}" Aggregate="Sum" ColumnGroupName="GridColumnGroupTax">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ApprovedAmount" HeaderText="Approved Amount" UniqueName="GridBoundColumnApprovedAmount" DataFormatString="{0:#,##0.00}" Aggregate="Sum">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="65px" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="65px" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" Width="65px" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Resizable="False" Visible="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                </MasterTableView>
            </telerik:RadGrid>
            <asp:HiddenField ID="HiddenFieldTitle" runat="server" Value="" />
    </div>
    
</asp:Content>
