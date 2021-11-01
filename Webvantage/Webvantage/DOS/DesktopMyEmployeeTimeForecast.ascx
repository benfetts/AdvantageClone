<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyEmployeeTimeForecast.ascx.vb"
    Inherits="Webvantage.DesktopMyEmployeeTimeForecast" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
    <script type="text/javascript">
             
        function ImageButtonMyETFColumnPreferencesClick(event) {

            var grid = $find("<%= RadGridEmployeeTimeForecastOfficeDetailJobComponents.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

        function ImageButtonMyETFColumnPreferencesDetailClick(event) {

            var grid = $find("<%= RadGridEmployeeTimeForecastOfficeDetailJobComponents.ClientID %>");

            grid.get_masterTableView().get_detailTables().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

        function ImageButtonMyETFColumnPreferencesEUClick(event) {

            var grid = $find("<%= RadGridEmployeeTimeForecastEmployeeutilization.ClientID %>");

           grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

        function ImageButtonMyETFColumnPreferencesClientClick(event) {

            var grid = $find("<%= RadGridEmployeeTimeForecastByClient.ClientID %>");

           grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        }

        function RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnHiding(sender, eventArgs) {
            <%--try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.hideColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }

        function RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnShowing(sender, eventArgs) {
           <%-- try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.showColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }

        function RadGridEmployeeTimeForecastEmployeeutilization_ColumnHiding(sender, eventArgs) {
            <%--try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.hideColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }

        function RadGridEmployeeTimeForecastEmployeeutilization_ColumnShowing(sender, eventArgs) {
           <%-- try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.showColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }
        

        function RadGridEmployeeTimeForecastByClient_ColumnHiding(sender, eventArgs) {
            <%--try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.hideColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }

        function RadGridEmployeeTimeForecastByClient_ColumnShowing(sender, eventArgs) {
           <%-- try {
                var grid = $find("<%= RadGridSupervisedEmployees.ClientID %>");

                grid.get_detailTables().forEach(function (item) { item.showColumn(eventArgs.get_gridColumn().get_element().cellIndex - 1) });
            }
            catch (err) { }--%>
        }
        

    </script>
    <style type="text/css">        
        
        .RadGrid_Metro .rgHeader > a {
            font-size: 16px !important;
        }
        
    </style>
</telerik:RadScriptBlock>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader" style="margin-bottom:10px;">
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
                <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                    OnClientClick="window.open('dtp_MyEmployeeTimeForecast.aspx?DO=My', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=450,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
            <asp:ImageButton ID="ImageButtonExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="ImageButtonDashboard" runat="server" ImageUrl="~/Images/Icons/Grey/256/dashboard.png" CssClass="icon-image" ToolTip="Dashboard" />
            <asp:ImageButton ID="ImageButtonRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" TabIndex="4" />&nbsp;
            <asp:Label ID="LabelView" runat="server" Text="View:"></asp:Label>
            <telerik:RadComboBox ID="RadComboBoxView" runat="server" AutoPostBack="true" Width="300px">
                <Items>
                    <telerik:RadComboBoxItem Text="Employee Time and Forecast" Value="0" Selected="true" />
                    <telerik:RadComboBoxItem Text="Employee Utilization" Value="1" />
                    <telerik:RadComboBoxItem Text="Employee Utilization By Month" Value="2" />
                    <telerik:RadComboBoxItem Text="Employee Time and Forecast By Client" Value="3" />
                    <telerik:RadComboBoxItem Text="Employee Utilization By Client" Value="4" />
                </Items>
            </telerik:RadComboBox>
        </div>
    </div>
    <div style="clear: both;" />

    <div style="clear: both;" />
    <div class="DO-Container">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important; font-weight: bold;">
                Filter
            </div>
            <div style="clear: both;" />
            <div style="clear: both;" />            
            <div style="float: left; padding-left: 10px; padding-top: 5px; width: 50%">
                <table width="100%" border="0" cellspacing="2" cellpadding="0">
                    <tr>
                        <td style="vertical-align: top">
                            <table id="TableFilterETF" border="0" cellspacing="2" cellpadding="0" width="50%">                        
                                <tr>
                                    <td>
                                        <asp:Label ID="LabelFrom" runat="server" Text="From:" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="DropDownListMonth" runat="server" AutoPostBack="false" SkinID="RadComboBoxMonthDisplayName" DataTextField="Value" DataValueField="Key"></telerik:RadComboBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelYear" runat="server" Font-Bold="True">Year:</asp:Label>&nbsp;&nbsp;
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
                                        <asp:Label ID="LabelTo" runat="server" Text="To:" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxMonthTo" runat="server" AutoPostBack="false" SkinID="RadComboBoxMonthDisplayName"
                                            DataTextField="Value" DataValueField="Key">
                                        </telerik:RadComboBox>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True">Year:</asp:Label>&nbsp;&nbsp;
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
                                <tr id="trIncludeJobDetail" runat="server">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        <asp:CheckBox id="CheckboxIncludeJobDetail" runat="server" Text="Include Job Detail" AutoPostBack="false"/>
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
                                <tr><td colspan="5"></td></tr>
                                <tr id="trSummary" runat="server">
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td colspan="4">
                                        <asp:CheckBox id="CheckboxSummary" runat="server" Text="Summarize" AutoPostBack="false"/>
                                    </td>
                                </tr>           
                            </table>
                        </td>
                        <td style="vertical-align: top">
                            <table id="TableFilterETF2" border="0" cellspacing="2" cellpadding="0" width="50%">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="Department:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxDepartment" runat="server" AutoPostBack="false" SkinID="RadComboBoxDepartment"
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
                                <tr><td colspan="5"></td></tr>
                                <tr id="trOfficeGroup" runat="server">
                                    <td width="275px">
                                        <asp:Label ID="Label2" runat="server" Text="Grouping Options:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxOfficeGroup" runat="server" Text="Office" AutoPostBack="false"/>
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
                                <tr><td colspan="5"></td></tr>
                                <tr>
                                    <td width="275px">
                                        <asp:Label ID="Label5" runat="server" Text="Grouping Options:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxDepartmentGroup" runat="server" Text="Department" AutoPostBack="false"/>
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
                                <tr><td colspan="5"></td></tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxEmployeeGroup" runat="server" Text="Employee" AutoPostBack="false"/>
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
                                <tr><td colspan="5"></td></tr>
                                <tr id="trClientGroup" runat="server">
                                    <td width="275px">
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxClientGroup" runat="server" Text="Client" AutoPostBack="false"/>
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
                                <tr><td colspan="5"></td></tr>
                                <tr><td colspan="5"></td></tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="Display Field:" Font-Bold="True"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="RadComboBoxDisplay" runat="server" AutoPostBack="false" SkinID="RadComboBoxDepartment">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="Direct Hours" Value="0" Selected="true" />
                                                <telerik:RadComboBoxItem Text="Direct Percent" Value="1" />
                                                <telerik:RadComboBoxItem Text="Client Hours" Value="2" />
                                                <telerik:RadComboBoxItem Text="Client Percent" Value="3" />
                                            </Items>
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
            </div>
            
        </ew:CollapsablePanel>
        <telerik:RadGrid ID="RadGridEmployeeTimeForecastOfficeDetailJobComponents" runat="server" EnableHierarchyExpandAll="True"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode,IsAlternateEmployee">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="ImageButtonMyETFColumnPreferencesClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnOffice" DataField="OfficeName" SortExpression="OfficeName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Office">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" Font-Size="15px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Department">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Employee">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClient" DataField="ClientName" SortExpression="ClientName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Client">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
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
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedAmount" HeaderText="Forecasted Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ActualAmount" HeaderText="Actual Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="VarianceAmount" HeaderText="Variance Amount">
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
                <DetailTables>
                    <telerik:GridTableView BorderWidth="1" AllowPaging="False" AllowSorting="True" DataKeyNames="ClientCode, JobAndJobComponent, SalesClass, AccountExecutive"
                        Width="100%" ShowFooter="false" AllowFilteringByColumn="true">
                        <ParentTableRelation>
                            <telerik:GridRelationFields DetailKeyField="ClientCode" MasterKeyField="ClientCode" />
                        </ParentTableRelation>
                        <Columns>
                            <%--<telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferencesDetail" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="ImageButtonMyETFColumnPreferencesDetailClick(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnJobAndJobComponent" DataField="JobAndJobComponent" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="JobAndJobComponent" HeaderText="Job/Component">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnSalesClass" DataField="SalesClass" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="SalesClass" HeaderText="Sales Class">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn UniqueName="GridBoundColumnAccountExecutive" DataField="AccountExecutive" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="AccountExecutive" HeaderText="Account Executive">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Actual Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </telerik:GridTableView>
                </DetailTables>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnColumnHiding="RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnHiding" OnColumnShowing="RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnShowing" />
            </ClientSettings>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridEmployeeTimeForcastEmployeeSummary" runat="server" EnableHierarchyExpandAll="True"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode,IsAlternateEmployee">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="ImageButtonMyETFColumnPreferencesClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnOffice" DataField="OfficeName" SortExpression="OfficeName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Office">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" Font-Size="15px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Department">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Employee">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
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
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedAmount" HeaderText="Forecasted Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ActualAmount" HeaderText="Actual Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="VarianceAmount" HeaderText="Variance Amount">
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
                <DetailTables>
                    <telerik:GridTableView BorderWidth="1" AllowPaging="False" AllowSorting="True" DataKeyNames="EmployeeCode, JobAndJobComponent, SalesClass, AccountExecutive"
                        Width="100%" ShowFooter="false" AllowFilteringByColumn="true">
                        <ParentTableRelation>
                            <telerik:GridRelationFields DetailKeyField="EmployeeCode" MasterKeyField="EmployeeCode" />
                        </ParentTableRelation>
                        <Columns>
                            <%--<telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferencesDetail" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="ImageButtonMyETFColumnPreferencesDetailClick(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnJobAndJobComponent" DataField="JobAndJobComponent" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="JobAndJobComponent" HeaderText="Job/Component">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnSalesClass" DataField="SalesClass" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="SalesClass" HeaderText="Sales Class">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn UniqueName="GridBoundColumnAccountExecutive" DataField="AccountExecutive" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="AccountExecutive" HeaderText="Account Executive">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Actual Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </telerik:GridTableView>
                </DetailTables>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnColumnHiding="RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnHiding" OnColumnShowing="RadGridEmployeeTimeForecastOfficeDetailJobComponents_ColumnShowing" />
            </ClientSettings>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridEmployeeTimeForecastEmployeeutilization" runat="server"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="ImageButtonMyETFColumnPreferencesEUClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnOffice" DataField="OfficeName" SortExpression="OfficeName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Office">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" Font-Size="15px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Department">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Employee">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnRequiredHours" DataField="RequiredHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="RequiredHours" HeaderText="Required">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDirectHoursGoal" DataField="DirectHoursGoal" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="DirectHoursGoal" HeaderText="Direct Goal">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ActualHours" HeaderText="Direct">
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
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClientHours" DataField="ClientHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ClientHours" HeaderText="Client">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnNewBusinessHours" DataField="NewBusinessHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="NewBusinessHours" HeaderText="New Business" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnAgencyHours" DataField="AgencyHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="AgencyHours" HeaderText="Agency" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnIndirectHours" DataField="IndirectHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="IndirectHours" HeaderText="Indirect">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnBillableHours" DataField="BillableHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="BillableHours" HeaderText="Billable">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnTotalHours" DataField="TotalHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="TotalHours" HeaderText="Total">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVariance" DataField="Variance" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="Variance" HeaderText="Variance">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHoursPercent" DataField="DirectPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="DirectPercent" HeaderText="Direct %">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClientPercent" DataField="ClientPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="ClientPercent" HeaderText="Client %">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnNewBusinessPercent" DataField="NewBusinessPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="NewBusinessPercent" HeaderText="New Business %" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnAgencyPercent" DataField="AgencyPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="AgencyPercent" HeaderText="Agency %" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnIndirectPercent" DataField="IndirectPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="IndirectPercent" HeaderText="Indirect %">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnBillablePercent" DataField="BillablePercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="BillablePercent" HeaderText="Billable %">
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnRequiredPercent" DataField="RequiredPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                        SortExpression="RequiredPercent" HeaderText="Required %">
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
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnColumnHiding="RadGridEmployeeTimeForecastEmployeeutilization_ColumnHiding" OnColumnShowing="RadGridEmployeeTimeForecastEmployeeutilization_ColumnShowing" />
            </ClientSettings>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridEmployeeTimeForecastEmployeeutilizationByMonth" runat="server"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="true" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView UseAllDataFields="true">            
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn Resizable="False" Visible="False">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>            
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridEmployeeTimeForecastByClientFTE" runat="server" GroupingEnabled="true"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="true" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView UseAllDataFields="true">            
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
                <ExpandCollapseColumn Resizable="False" Visible="False">
                    <HeaderStyle Width="20px" />
                </ExpandCollapseColumn>            
            </MasterTableView>
        </telerik:RadGrid>
        <telerik:RadGrid ID="RadGridEmployeeTimeForecastByClient" runat="server" EnableHierarchyExpandAll="True"
            AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
            ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="true"
            EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
            <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode">
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences"  OnClientClick="ImageButtonMyETFColumnPreferencesClientClick(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnClient" DataField="ClientName" SortExpression="ClientName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Client">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Department">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                        HeaderText="Employee">
                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
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
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ForecastedAmount" HeaderText="Forecasted Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="ActualAmount" HeaderText="Actual Amount" >
                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                        <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                        SortExpression="VarianceAmount" HeaderText="Variance Amount">
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
                <%--<DetailTables>
                    <telerik:GridTableView BorderWidth="1" AllowPaging="False" AllowSorting="True" DataKeyNames="ClientCode, JobAndJobComponent, SalesClass, AccountExecutive"
                        Width="100%" ShowFooter="false" AllowFilteringByColumn="true">
                        <ParentTableRelation>
                            <telerik:GridRelationFields DetailKeyField="ClientCode" MasterKeyField="ClientCode" />
                        </ParentTableRelation>
                        <Columns>                       
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnJobAndJobComponent" DataField="JobAndJobComponent" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="JobAndJobComponent" HeaderText="Job/Component">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnSalesClass" DataField="SalesClass" FilterControlWidth="75"
                                        CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                SortExpression="SalesClass" HeaderText="Sales Class">
                                <ItemStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Actual Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                        </Columns>
                    </telerik:GridTableView>
                </DetailTables>--%>
            </MasterTableView>
            <ClientSettings>
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnColumnHiding="RadGridEmployeeTimeForecastByClient_ColumnHiding" OnColumnShowing="RadGridEmployeeTimeForecastByClient_ColumnShowing" />
            </ClientSettings>
        </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
    </div>
</div>


