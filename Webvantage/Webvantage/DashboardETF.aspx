<%@ Page AutoEventWireup="false" CodeBehind="DashboardETF.aspx.vb" Inherits="Webvantage.DashboardETF"
    Language="vb" MasterPageFile="~/ChildPage.Master" Title="Dashboard" %>

<asp:Content ID="ContentDashboard" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <div class="telerik-aqua-body" style="margin-top: 5px!important;">
            <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
                <script type="text/javascript">
                    function StopPropagation(e) {
                        if (!e) {
                            e = window.event;
                        }

                        e.cancelBubble = true;
                    }

        </script>
    </telerik:RadScriptBlock>
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <ew:CollapsablePanel ID="CollapsablePanelEstimateTotals" runat="server" TitleText="Filter">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                     
                    <table id="TableFilterETF" border="0" cellspacing="2" cellpadding="0">
                        <tr>
                            <td>
                                <asp:Label ID="LabelFrom" runat="server" Text="From:"></asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="false" SkinID="RadComboBoxMonthDisplayName" DataTextField="Value" DataValueField="Key"></telerik:RadComboBox>&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="LabelYear" runat="server">Year:</asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="DropDownListPostPeriodYear" runat="server" AutoPostBack="false"
                                    SkinID="RadComboBoxYear" DataTextField="Year" DataValueField="Year">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr><td colspan="5"></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="LabelTo" runat="server" Text="To:"></asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxMonthTo" runat="server" AutoPostBack="false" SkinID="RadComboBoxMonthDisplayName"
                                    DataTextField="Value" DataValueField="Key">
                                </telerik:RadComboBox>&nbsp;&nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server">Year:</asp:Label>&nbsp;&nbsp;
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxYearTo" runat="server" AutoPostBack="false"
                                    SkinID="RadComboBoxYear" DataTextField="Year" DataValueField="Year">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr><td colspan="5"></td></tr>    
                        <tr id="trAlternateEmployee" runat="server">
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                <asp:CheckBox id="CheckboxAlternateEmployee" runat="server" Text="Include Alternate Employees" AutoPostBack="false" Font-Size="16px" />
                            </td>
                        </tr>      
                        <tr><td colspan="5"></td></tr>
                        <tr id="trIncludeSupervisorEmployees" runat="server">
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                <asp:CheckBox id="CheckboxIncludeSupervisorEmployees" runat="server" Text="Show Supervised Employees" AutoPostBack="false"/>
                            </td>
                        </tr>          
                        <tr><td colspan="5"></td></tr>
                        <tr id="trForecastOnly" runat="server">
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4">
                                <asp:CheckBox id="CheckboxForecastOnly" runat="server" Text="Include Only Forecasted Jobs" AutoPostBack="false"/>
                            </td>
                        </tr>                      
                    </table>
                </td>
                <td style="vertical-align: top">
                    <table id="TableFilterETF2" border="0" cellspacing="2" cellpadding="0" width="50%">
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Department:"></asp:Label>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="RadComboBoxDepartment" runat="server" AutoPostBack="true" SkinID="RadComboBoxDepartment"
                                    DataTextField="Description" DataValueField="Code">
                                </telerik:RadComboBox>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>    
                    </table>
                </td>
            </tr>         
                <tr><td colspan="2">&nbsp;</td></tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="ButtonApply" runat="server" Text="Apply Filter" />
                    </td>
                </tr>
        </table>
        </ew:CollapsablePanel>
        <style type="text/css">
            .chart-box {
                width: 50%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
            }
            .chart-box > div {
                border: 1px solid #ccc;
                padding: 5px;
                position: relative;
                padding-top: 10px;
            }
            .chart-box .chart-box-label {
                font-weight: bold; 
                position:absolute; 
                top: -10px; 
                left: 10px; 
                background: white; 
                padding-left: 5px; 
                padding-right: 5px;
            }
            .chart-box-filter {
                width: 100%;
                padding: 10px;
                float: left;
                box-sizing: border-box;
                -moz-box-sizing: border-box;
                -webkit-box-sizing: border-box;
            }
        </style>      
        <asp:Panel ID="PanelETF" runat="server">
            <div style="margin-top: 20px; margin-bottom: 20px; width: 100%;">
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="LabelProject" runat="server" Text="Actual Hours"></asp:Label></div>
                        <div>
                            <telerik:RadComboBox runat="server" ID="RadComboBoxHoursChart" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="Hours" Value="Hours" />
                                    <telerik:RadComboBoxItem Text="Dollars" Value="Dollars" />
                                </Items>
                            </telerik:RadComboBox>
                            <telerik:RadHtmlChart ID="RadHtmlChartHoursPieChart" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
                <div class="chart-box">                
                    <div>
                        <div class="chart-box-label"><asp:Label ID="LabelByLevel" runat="server" Text="Actual Dollars"></asp:Label></div>
                        <div>
                            <telerik:RadComboBox runat="server" ID="RadComboBoxByEmployee" AutoPostBack="true" SkinID="RadComboBoxStandard">
                                <Items>
                                    <telerik:RadComboBoxItem Text="All Hours" Value="All" />
                                    <telerik:RadComboBoxItem Text="Direct Hours" Value="DirectHours" />
                                    <telerik:RadComboBoxItem Text="Client Hours" Value="ClientHours" />
                                    <telerik:RadComboBoxItem Text="Agency Hours" Value="AgencyHours" />
                                    <telerik:RadComboBoxItem Text="New Business Hours" Value="NewBusinessHours" />
                                    <telerik:RadComboBoxItem Text="Indirect Hours" Value="IndirectHours" />
                                </Items>
                            </telerik:RadComboBox>
                            <telerik:RadHtmlChart ID="RadHtmlChartLineChart" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
            </div>
            <div style="margin-top: 20px; margin-bottom: 20px; width: 100%;">
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label1" runat="server" Text="Budget Comparison"></asp:Label></div>
                        <div>
                            <telerik:RadHtmlChart ID="RadHtmlChartStackBudgetComparison" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label2" runat="server" Text=""></asp:Label></div>
                        <div>
                            <telerik:RadGrid ID="RadGridEmployeeTimeForecastOfficeDetailJobComponents" runat="server" EnableHierarchyExpandAll="True"
                                AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true" GroupingSettings-CaseSensitive="false"
                                ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
                                EnableHeaderContextMenu="true">
                                <MasterTableView DataKeyNames="ClientCode">
                                    <Columns>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnClient" DataField="ClientName" SortExpression="ClientName" FilterControlWidth="75"
                                            CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                            HeaderText="Client">
                                            <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                            SortExpression="ForecastHours" HeaderText="Forecasted Hours">
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                            SortExpression="ActualHours" HeaderText="Actual Hours">
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                            SortExpression="VarianceHours" HeaderText="Variance Hours">
                                            <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                            <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <RowIndicatorColumn Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn Resizable="False" Visible="False">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>            
                                </MasterTableView>
                                <ClientSettings>
                                    <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                                </ClientSettings>
                            </telerik:RadGrid>
                        </div>
                    </div>
                </div>
            </div>            
        </asp:Panel> 
        <asp:Panel ID="PanelEmployeeUtilization" runat="server">
            <div style="margin-top: 20px; margin-bottom: 20px; width: 100%;">
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label4" runat="server" Text="Direct Hours by Client"></asp:Label></div>
                        <div>
                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursByClient" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
                <div class="chart-box">                
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label5" runat="server" Text="Direct Hours by Type"></asp:Label></div>
                        <div>
                            <telerik:RadHtmlChart ID="RadHtmlChartDirectHoursByType" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
            </div>
            <div style="margin-top: 20px; margin-bottom: 20px; width: 100%;">
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label6" runat="server" Text="Direct vs. Indirect"></asp:Label></div>
                        <div>
                            <telerik:RadHtmlChart ID="RadHtmlChartDirectIndirect" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
                <div class="chart-box">
                    <div>
                        <div class="chart-box-label"><asp:Label ID="Label7" runat="server" Text="Required vs. Actual"></asp:Label></div>
                        <div>
                            <telerik:RadHtmlChart ID="RadHtmlChartRequiredActual" runat="server">
                            </telerik:RadHtmlChart>
                        </div>
                    </div>
                </div>
            </div>        
        </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>
    
            <script type="text/javascript">
                $(window).resize(function () {
                    $('[data-role=chart]').each(function () {
                        $find($(this).attr('id')).get_kendoWidget().resize();
                    });
                });
            </script>
    </div>
   

</asp:Content>
