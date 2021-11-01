<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dtp_MyEmployeeTimeForecast.aspx.vb"
    MasterPageFile="~/ChildPage.Master" Inherits="Webvantage.dtp_MyEmployeeTimeForecast" %>

<%@ Register Src="Print_Buttons.ascx" TagName="Print_Buttons" TagPrefix="webvantage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <script type="text/javascript">
        function PrintRadGrid() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForecastOfficeDetailJobComponents"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
        function PrintRadGrid2() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForcastEmployeeSummary"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
        function PrintRadGrid3() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForecastEmployeeutilization"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
        function PrintRadGrid4() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForecastEmployeeutilizationByMonth"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
        function PrintRadGrid5() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForecastByClient"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
        function PrintRadGrid6() {

            var styleStr = "<html><head><link href='" +
                "CSS/Material/Bootstrap.Cyan.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/Common.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "CSS/CardLayout.Colors.css" +
                "' rel='stylesheet' type='text/css'></link><link href='" +
                "App_Themes/Metro/Metro.min.css" +
                "' rel='stylesheet' type='text/css'></link>";

            var htmlcontent = styleStr + "<body>" + window["RadGridEmployeeTimeForecastByClientFTE"].outerHTML + "</body></html>";
            htmlcontent = htmlcontent.replace(/<script .*?>(.|\n)*?<\/script>/gi, "");

            //Get the HTML of whole page
            var oldPageHtml = document.body.innerHTML;

            //Reset the page's HTML with div's HTML only
            document.body.innerHTML = htmlcontent;

            //Print Page
            window.print();

            //Restore orignal HTML
            document.body.innerHTML = oldPageHtml;
        }
    </script>
    <table align="center" cellpadding="2" cellspacing="0" width="100%">
        <tr>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" OnClientClick="PrintRadGrid(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />
                <asp:Button ID="Button2" runat="server" OnClientClick="PrintRadGrid2(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />
                <asp:Button ID="Button3" runat="server" OnClientClick="PrintRadGrid3(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />
                <asp:Button ID="Button4" runat="server" OnClientClick="PrintRadGrid4(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />
                <asp:Button ID="Button5" runat="server" OnClientClick="PrintRadGrid5(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />
                <asp:Button ID="Button6" runat="server" OnClientClick="PrintRadGrid6(); return false;" Text="Print" style="left: 20px; text-align: right; background-image: url('Images/printer.png'); background-position: left; background-repeat: no-repeat; cursor:pointer" ToolTip="Print this window" Width="70px" Visible="false" />&nbsp;
                <br/>
                &nbsp;My Employee Time Forcast<br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <telerik:RadGrid ID="RadGridEmployeeTimeForecastOfficeDetailJobComponents" runat="server" ClientIDMode="Static"
                    GridLines="None" ShowFooter="true" AutoGenerateColumns="false" Width="99%" >
                    <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode,IsAlternateEmployee">
                        <Columns>                            
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOffice" DataField="OfficeName" SortExpression="OfficeName"
                                HeaderText="Office">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName"
                                HeaderText="Department">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee"
                                HeaderText="Employee">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnClient" DataField="ClientName" SortExpression="ClientName"
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
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount">
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
                                Width="100%">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="ClientCode" MasterKeyField="ClientCode" />
                                </ParentTableRelation>
                                <Columns>                                    
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnJobAndJobComponent" DataField="JobAndJobComponent" FilterControlWidth="75"
                                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        SortExpression="JobAndJobComponent" HeaderText="Job/Component">
                                        <ItemStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnSalesClass" DataField="SalesClass" FilterControlWidth="75"
                                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                        SortExpression="SalesClass" HeaderText="Sales Class">
                                        <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>                                    
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                        SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                        SortExpression="ActualHours" HeaderText="Actual Hours">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                        SortExpression="VarianceHours" HeaderText="Variance Hours">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                        SortExpression="ForecastedAmount" HeaderText="Forecasted Amount">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false"  DataFormatString="{0:#,##0.00}"
                                        SortExpression="ActualAmount" HeaderText="Actual Amount">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                        SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                        <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                        <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:RadGrid ID="RadGridEmployeeTimeForcastEmployeeSummary" runat="server" EnableHierarchyExpandAll="True" ClientIDMode="Static"
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
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Department">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Employee">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Actual Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
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
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:RadGrid ID="RadGridEmployeeTimeForecastEmployeeutilization" runat="server" ClientIDMode="Static"
                                GridLines="None" ShowFooter="true" AutoGenerateColumns="false" Width="99%">
                    <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode">
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnOffice" DataField="OfficeName" SortExpression="OfficeName" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Office">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" Font-Size="15px" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Department">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Employee">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnRequiredHours" DataField="RequiredHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="RequiredHours" HeaderText="Required">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDirectHoursGoal" DataField="DirectHoursGoal" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="DirectHoursGoal" HeaderText="Direct Goal">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>                           
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Direct">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnClientHours" DataField="ClientHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ClientHours" HeaderText="Client">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnNewBusinessHours" DataField="NewBusinessHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="NewBusinessHours" HeaderText="New Business" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnAgencyHours" DataField="AgencyHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="AgencyHours" HeaderText="Agency" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnIndirectHours" DataField="IndirectHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="IndirectHours" HeaderText="Indirect">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnBillableHours" DataField="BillableHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="BillableHours" HeaderText="Billable">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnTotalHours" DataField="TotalHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="TotalHours" HeaderText="Total">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVariance" DataField="Variance" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="Variance" HeaderText="Variance">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHoursPercent" DataField="DirectPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="DirectPercent" HeaderText="Direct %">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnClientPercent" DataField="ClientPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="ClientPercent" HeaderText="Client %">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnNewBusinessPercent" DataField="NewBusinessPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="NewBusinessPercent" HeaderText="New Business %" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnAgencyPercent" DataField="AgencyPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="AgencyPercent" HeaderText="Agency %" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnIndirectPercent" DataField="IndirectPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="IndirectPercent" HeaderText="Indirect %">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnBillablePercent" DataField="BillablePercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="BillablePercent" HeaderText="Billable %">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnRequiredPercent" DataField="RequiredPercent" AllowFiltering="false" DataFormatString="{0:#,##0.00}"
                                SortExpression="RequiredPercent" HeaderText="Required %">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
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
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:RadGrid ID="RadGridEmployeeTimeForecastEmployeeutilizationByMonth" runat="server" ClientIDMode="Static"
                    AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
                    ShowFooter="true" AutoGenerateColumns="true" Width="99%" PagerStyle-Visible="false" Font-Size="15px">
                    <MasterTableView UseAllDataFields="true">            
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>            
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadGrid ID="RadGridEmployeeTimeForecastByClientFTE" runat="server" ClientIDMode="Static"
                    AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
                    ShowFooter="true" AutoGenerateColumns="true" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="false"
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
                <telerik:RadGrid ID="RadGridEmployeeTimeForecastByClient" runat="server" EnableHierarchyExpandAll="True" ClientIDMode="Static"
                    AllowPaging="false" AllowSorting="true" GridLines="None" PageSize="10" EnableViewState="true"
                    ShowFooter="true" AutoGenerateColumns="false" Width="99%" PagerStyle-Visible="false" AllowFilteringByColumn="false"
                    EnableHeaderContextMenu="true" GroupingSettings-CaseSensitive="false" MasterTableView-ShowGroupFooter="true" Font-Size="15px">
                    <MasterTableView DataKeyNames="EmployeeCode,Employee,ClientCode">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn"  HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="1%" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" Visible="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnClient" DataField="ClientName" SortExpression="ClientName" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Client">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnDepartment" DataField="DepartmentName" SortExpression="DepartmentName" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Department">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnEmployee" DataField="Employee" SortExpression="Employee" FilterControlWidth="75"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false"
                                HeaderText="Employee">
                                <ItemStyle Width="75" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderStyle Font-Bold="True" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedHours" DataField="ForecastedHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedHours" HeaderText="Forecasted Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualHours" DataField="ActualHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualHours" HeaderText="Actual Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceHours" DataField="VarianceHours" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceHours" HeaderText="Variance Hours">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnForecastedAmount" DataField="ForecastedAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ForecastedAmount" HeaderText="Forecasted Amount" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnActualAmount" DataField="ActualAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="ActualAmount" HeaderText="Actual Amount" >
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
                                <FooterStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="GridBoundColumnVarianceAmount" DataField="VarianceAmount" AllowFiltering="false" Aggregate="sum" DataFormatString="{0:#,##0.00}"
                                SortExpression="VarianceAmount" HeaderText="Variance Amount">
                                <ItemStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" />
                                <HeaderStyle Width="50" VerticalAlign="Middle" HorizontalAlign="Right" Font-Bold="True" />
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
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                    </ClientSettings>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    
            <%--<webvantage:Print_Buttons ID="Print_Buttons1" runat="server" />--%>
    
   
</asp:Content>
