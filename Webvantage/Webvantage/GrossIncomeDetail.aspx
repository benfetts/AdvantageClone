<%@ Page AutoEventWireup="false" CodeBehind="GrossIncomeDetail.aspx.vb" Inherits="Webvantage.GrossIncomeDetail"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Gross Income" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">    
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="no-float-menu">
                    <telerik:radtoolbar id="RadToolbarGrossIncomePrint" runat="server" autopostback="true" width="100%">
                        <Items>                
                            <telerik:RadToolBarButton ID="RadToolbarButtonPrint" SkinID="RadToolBarButtonPrint" CausesValidation="true"
                                CommandName="Print" Value="Print" Hidden="False" ToolTip="Print" />
                           <telerik:RadToolBarButton ID="RadToolbarButtonExport" SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                               CommandName="ExportExcel" Value="ExportExcel" Hidden="False" ToolTip="Export to a spreadsheet" />
                        </Items>
                    </telerik:radtoolbar>
                </td>
            </tr>  
            <tr>
                <td valign="top" class="telerik-aqua-body">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                        <tr>
                            <td colspan="4">
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <telerik:RadHtmlChart ID="RadHtmlChartGrossIncome" runat="server">
                                                <ClientEvents OnSeriesClick="RadHtmlChartClientEvents" />
                                            </telerik:RadHtmlChart>
                                        </td>
                                    </tr>
                                    <asp:Panel ID="PanelLevel2" runat="server">                                    
                                    <tr>
                                        <td align="center" valign="top" colspan="2">
                                            <telerik:RadGrid ID="RadGridGrossIncome" runat="server" AllowPaging="True" AllowSorting="True"
                                                Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                                                EnableHeaderContextMenu="true" ShowFooter="true">
                                                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" ></PagerStyle>
                                                <MasterTableView AllowMultiColumnSorting="true" Width="100%" DataKeyNames="JobNumber,ComponentNumber,OrderNumber,LineNumber,JobDescription,ComponentDescription,InvoiceNumber,InvoiceSequence">
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
                                                        <telerik:GridTemplateColumn HeaderText="&nbsp;" UniqueName="GridTemplateColumnDocuments">
                                                            <HeaderStyle CssClass="radgrid-icon-column" />
                                                            <ItemStyle CssClass="radgrid-icon-column" />
                                                            <FooterStyle CssClass="radgrid-icon-column" />
                                                            <ItemTemplate>
                                                                <div id="DivDocuments" runat="server" class="icon-background background-color-sidebar">
                                                                    <asp:LinkButton ID="LinkButtonDocuments" runat="server" CssClass="icon-text" CommandName="documents" ToolTip="Documents">D</asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </telerik:GridTemplateColumn>
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
                                    </asp:Panel>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                </ContentTemplate>
            </asp:UpdatePanel>

    <style type="text/css">
        svg > g, svg > g > g:nth-child(4) > g {
            cursor: pointer;
        }
    </style>

    <telerik:RadScriptBlock ID="RadScriptBlockFooter" runat="server">
        <script type="text/javascript">
            function RadHtmlChartClientEvents(e) {
                var url = e.dataItem.SeriesClickURL;
                if (url) {
                    RefreshWindow(url, true, false);
                }
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
