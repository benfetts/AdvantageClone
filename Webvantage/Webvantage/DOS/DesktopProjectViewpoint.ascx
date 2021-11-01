<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopProjectViewpoint.ascx.vb"
    Inherits="Webvantage.DesktopProjectViewpoint" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<telerik:RadScriptBlock ID="RadScriptBlock" runat="server">  

    <script type="text/javascript">

        function RadGridProjectViewpointMainColumnHeaderMenu(ev) {
            var gridRadGridProjectViewpointMain = $find("<%= RadGridProjectViewpointMain.ClientID %>");
            gridRadGridProjectViewpointMain.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 10, 10);
        }

        function PrintContent() {
            var MyDiv = document.getElementById('DivAllTooltipInfo');
            var content = MyDiv.innerHTML;
            var pwin = window.open('', 'print_content', 'width=300,height=300');
            pwin.document.open();
            pwin.document.write('<html>');
            pwin.document.write('<head>');
            pwin.document.write('<link rel="stylesheet" href="CSS/Print.css" type="text/css" />');
            pwin.document.write('</head>');
            pwin.document.write('<body onload="window.print()">');
            pwin.document.write(content);
            pwin.document.write('</body>');
            pwin.document.write('</html>');
            pwin.document.close();
            setTimeout(function () { pwin.close(); }, 1000);
        }

        var scrollPosition;
        function RadAjaxPanelOnRequestStart(sender, args) {
            scrollPosition = $(window).scrollTop();
        }
        function RadAjaxPanelOnResponseEnd(sender, args) {
            if (scrollPosition) {
                $(window).scrollTop(scrollPosition);
                scrollPosition = null;
            }
        }

    </script>
</telerik:RadScriptBlock>
<div style="width:100%;">
    <div class="no-float-menu">
            <telerik:RadToolBar ID="RadToolbarProjectViewpoint" runat="server" AutoPostBack="true" Width="100%">
                <Items>
                    <telerik:RadToolBarButton CausesValidation="true"
                        CommandName="ProjectViewpoint" CheckOnClick="true" Group="ViewPointView" Value="ProjectViewpoint"
                        ToolTip="Project Viewpoint" Text="Project" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton CausesValidation="true"
                        CommandName="BudgetViewpoint" CheckOnClick="true" Group="ViewPointView" Value="BudgetViewpoint"
                        ToolTip="Budget Viewpoint" Text="Budget" />
                    <telerik:RadToolBarButton Text="Actuals" CausesValidation="true"
                        CommandName="RefreshActuals" Value="RefreshActuals" Enabled="false" ToolTip="Refresh Actuals" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton CausesValidation="true"
                        CommandName="HoursViewpoint" CheckOnClick="true" Group="ViewPointView" Value="HoursViewpoint"
                        ToolTip="Hours Viewpoint" Text="Hours" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New Job"
                        Value="NewJob" ToolTip="New Job" CommandName="NewJob" />
                    <telerik:RadToolBarButton IsSeparator="true" Value="SeparatorNewJob" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonFilter" Text="" CausesValidation="true"
                        Group="ViewPointView" CommandName="FilterView" Value="FilterView"
                        CheckOnClick="true" ToolTip="Filter" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" CausesValidation="true"
                        CommandName="Export" Value="Export" ToolTip="Export" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" ToolTip="Bookmark" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" CausesValidation="true"
                        CommandName="Refresh" Value="Refresh" ToolTip="Refresh" />
                </Items>
            </telerik:RadToolBar>

    </div>
    <div class="telerik-aqua-body">
        <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="ViewMain" runat="server">
            <div style="margin: 8px 0px 0px 0px;">
                <telerik:RadGrid ID="RadGridProjectViewpointMain" runat="server" AllowPaging="True" AllowCustomPaging="true"
                    AllowFilteringByColumn="true" AllowSorting="True" AutoGenerateColumns="False" VirtualItemCount="5000"
                    GridLines="None" EnableEmbeddedSkins="True" Width="100%" EnableHeaderContextMenu="true">
                    <GroupingSettings CaseSensitive="false" />
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                    <ClientSettings>
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="JOB_NUMBER,JOB_COMPONENT_NBR">
                        <PagerStyle PageSizes="10,20,50,100" />
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetail" AllowFiltering="false"
                                HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridProjectViewpointMainColumnHeaderMenu(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image" CommandName="Detail"
                                            SkinID="ImageButtonViewWhite" ToolTip="Details" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnPrint" HeaderText="Print"
                                AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonPrint" runat="server" CommandName="Print" SkinID="ImageButtonPrintWhite" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="CDP" FilterControlWidth="110"
                                CurrentFilterFunction="Contains" ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobAndComp" HeaderText="Project" UniqueName="JobAndComp"
                                HeaderAbbr="FIXED" FilterControlwidth="220" CurrentFilterFunction="Contains"
                                ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"  />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="AcctExec" HeaderText="AE" UniqueName="AcctExec"
                                FilterControlWidth="100" CurrentFilterFunction="Contains" ShowFilterIcon="True"
                                FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle Width="100" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle Width="100" HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle Width="100" HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JC_START_DATE" ItemStyle-Width="65px" HeaderText="Start"
                                AllowFiltering="false" FilterControlWidth="65" CurrentFilterFunction="Contains"
                                ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" UniqueName="openClosed">
                                <HeaderStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_FIRST_USE_DATE" HeaderText="Due Completed"
                                AllowFiltering="false" FilterControlWidth="65" CurrentFilterFunction="Contains"
                                ShowFilterIcon="True" FilterDelay="1250" AutoPostBackOnFilter="false" HeaderStyle-VerticalAlign="Bottom"
                                UniqueName="DueActualDate">
                                <HeaderStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="Status" HeaderText="Status" UniqueName="GridBoundColumnStatus"
                                FilterControlWidth="150" CurrentFilterFunction="Contains" ShowFilterIcon="True"
                                FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="150" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="CL_CODE" UniqueName="CL_CODE" Visible="false"
                                FilterControlWidth="30" CurrentFilterFunction="Contains" ShowFilterIcon="True"
                                FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DIV_CODE" UniqueName="DIV_CODE" Visible="false"
                                FilterControlWidth="30" CurrentFilterFunction="Contains" ShowFilterIcon="True"
                                FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PRD_CODE" UniqueName="PRD_CODE" Visible="false"
                                FilterControlWidth="110" CurrentFilterFunction="Contains" ShowFilterIcon="True"
                                FilterDelay="1250" AutoPostBackOnFilter="false">
                                <HeaderStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="30" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="alerts" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonAlerts" runat="server" CssClass="icon-text" CommandName="alerts">A</asp:LinkButton>
                                    </div>
                                    <telerik:RadToolTip ID="RadToolTipAssignments" runat="server" TargetControlID="LinkButtonAlerts" Width="200px" RenderMode="Classic"
                                        RelativeTo="Element" Position="MiddleRight">
                                        Open Assignments:&nbsp;&nbsp;<%# Eval("OPEN_ASSIGNMENTS")%>
                                    </telerik:RadToolTip>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="documents" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonDocuments" runat="server" CssClass="icon-text" CommandName="documents" ToolTip="Documents">D</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="cb" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonCreativeBrief" runat="server" CssClass="icon-text" CommandName="cb" ToolTip="Creative Brief">C</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="specs" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonSpecifications" runat="server" CssClass="icon-text" CommandName="specs" ToolTip="Specifications">S</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="versions" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonVersions" runat="server" CssClass="icon-text" CommandName="versions" ToolTip="Versions"></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="est" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivEstimate" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonEstimate" runat="server" CssClass="icon-text" CommandName="est" ToolTip="Estimate">E</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="sched" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonSchedule" runat="server" CssClass="icon-text" CommandName="sched">P</asp:LinkButton>
                                    </div>
                                    <telerik:RadToolTip ID="RadToolTipOpenTasks" runat="server" TargetControlID="LinkButtonSchedule" Width="150px" RenderMode="Classic"
                                        RelativeTo="Element" Position="MiddleRight">
                                        Open Tasks:&nbsp;&nbsp;<%# Eval("OPEN_TASKS")%>
                                    </telerik:RadToolTip>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="qva" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivQvA" runat="server" class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonQuoteVsActual" runat="server" CssClass="icon-text" CommandName="qva" ToolTip="Quote Vs Actual">Q</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="summary" HeaderAbbr="FIXED" AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonSummary" runat="server" CssClass="icon-text" CommandName="summary" ToolTip="Summary">&Sigma;</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddTime" HeaderText="Add Time"
                                AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonAddTime" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Icons/White/256/clock.png" CssClass="icon-image"
                                            ToolTip="Add Time" CommandName="AddTime" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStopwatch" HeaderText="Stopwatch"
                                AllowFiltering="false">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonStopwatch" runat="server" ToolTip="Click to start Stopwatch" CssClass="icon-image"
                                            CommandName="StartStopwatch" ImageUrl="~/Images/Icons/White/256/stopwatch.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="JOB_NUMBER" UniqueName="JOB_NUMBER" Visible="False">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMPONENT_NBR" UniqueName="JOB_COMPONENT_NBR"
                                Visible="False">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="PROCESS_DATE" UniqueName="PROCESS_DATE" Visible="false">
                                <HeaderStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="COMPLETED_DATE" UniqueName="COMPLETED_DATE" Visible="false">
                                <HeaderStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <ItemStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                                <FooterStyle Width="65" HorizontalAlign="Right" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_PROCESS_CONTRL" UniqueName="JOB_PROCESS_CONTRL"
                                Visible="false">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                        </Columns>
                        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <telerik:RadToolTipManager ID="RadToolTipManagerSummaryTooltip" runat="server" Animation="None" RenderMode="Classic"
                AutoTooltipify="false" ManualClose="true" Modal="true" OnAjaxUpdate="SummaryTooltipOnAjaxUpdate"
                Position="MiddleLeft" RelativeTo="Element" ShowEvent="OnMouseOver" Sticky="true"
                Height="500" Width="500px">
            </telerik:RadToolTipManager>
        </asp:View>
        <asp:View ID="ViewBudgetView" runat="server">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left" width="50%">
                            <asp:ImageButton ID="ImageButtonPrint" runat="server" SkinID="ImageButtonPrint"
                                OnClientClick="window.open('dtp_BudgetViewpoint.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=600,height=600,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;" />
                    </td>
                    <td align="right" width="50%">
                        <asp:Label ID="LabelLastRefreshed" runat="server" TabIndex="-1"> </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblGroup" runat="server" TabIndex="-1" Text="Group By:"> </asp:Label>
                        <telerik:RadComboBox ID="ddGroupBy" runat="server" AutoPostBack="true" TabIndex="1" Width="200">
                            <Items>
                                <telerik:RadComboBoxItem Value="1" Text="All"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="2" Text="By Type"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="3" Text="By Sales Class"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td align="right">Filtered by:&nbsp;
                        <asp:Label ID="lblFilterOption" runat="server" TabIndex="-1"></asp:Label>
                    </td>
                </tr>
            </table>
            <telerik:RadGrid ID="RadGridBudgetView" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" Width="100%">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px"></PagerStyle>
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="DESCRIPTION" HeaderText="Description" UniqueName="DESCRIPTION">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BUDGET_BILLING" DataFormatString="{0:#,##0.00}"
                            HeaderText="Budget Billing" UniqueName="BUDGET_BILLING">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BUDGET_GI" DataFormatString="{0:#,##0.00}" HeaderText="Budget Gross Income"
                            UniqueName="BUDGET_GI">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_BILLING" DataFormatString="{0:#,##0.00}"
                            HeaderText="Billed" UniqueName="ACTUAL_BILLING">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ACTUAL_GI" DataFormatString="{0:#,##0.00}" HeaderText="Billed Gross Income"
                            UniqueName="ACTUAL_GI">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VARIANCE_BILLING" DataFormatString="{0:#,##0.00}"
                            HeaderText="Variance Billing" UniqueName="VARIANCE_BILLING">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="VARIANCE_GI" DataFormatString="{0:#,##0.00}"
                            HeaderText="Variance Gross Income" UniqueName="VARIANCE_GI">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="120" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <ExpandCollapseColumn Visible="False" Resizable="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:View>
        <asp:View ID="HoursViewpoint" runat="server">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr>
                    <td align="left" width="50%">
                        <asp:Label ID="Label1" runat="server" TabIndex="-1" Text="Group By:"> </asp:Label>
                        <telerik:RadComboBox ID="ddHoursViewpointGrouping" runat="server" AutoPostBack="true" Width="200" TabIndex="1">
                            <Items>
                                <telerik:RadComboBoxItem Value="1" Text="By Function"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="2" Text="By Project"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="3" Text="By Employee"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="0" Text="None"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td align="right" width="50%">
                        <asp:CheckBox ID="cbShowAmounts" runat="server" Text="Show Amounts" AutoPostBack="true"
                            Checked="true" />
                    </td>
                </tr>
            </table>
            <telerik:RadGrid ID="RadGridHoursView" runat="server" AllowPaging="True" AllowSorting="True"
                AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True" Width="100%">
                <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom" Height="20px"></PagerStyle>
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="GROUPING" HeaderText="Description" UniqueName="GROUPING">
                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HOURS_POSTED" DataFormatString="{0:#,##0.00}"
                            HeaderText="Hours Posted" UniqueName="HOURS_POSTED">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BILLED_AMT" DataFormatString="{0:#,##0.00}" HeaderText="Billed Amount"
                            UniqueName="BILLED_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="UNBILLED_AMT" DataFormatString="{0:#,##0.00}"
                            HeaderText="Unbilled Amount" UniqueName="UNBILLED_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="NON_BILLABLE" DataFormatString="{0:#,##0.00}"
                            HeaderText="Non-Billable" UniqueName="NON_BILLABLE">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ADJUSTED_AMT" DataFormatString="{0:#,##0.00}"
                            HeaderText="Adjusted Amount" UniqueName="ADJUSTED_AMT">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="110" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QUOTED_HRS" DataFormatString="{0:#,##0.00}" HeaderText="Quoted Hours"
                            UniqueName="QUOTED_HRS">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QVA_VARIANCE" DataFormatString="{0:#,##0.00}"
                            HeaderText="QvA Variance" UniqueName="QVA_VARIANCE">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HRS_ALLOWED" DataFormatString="{0:#,##0.00}"
                            HeaderText="Hours Allowed" UniqueName="HRS_ALLOWED">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="HRS_VARIANCE" DataFormatString="{0:#,##0.00}"
                            HeaderText="Hours Variance" UniqueName="HRS_VARIANCE">
                            <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                            <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="90" />
                        </telerik:GridBoundColumn>
                    </Columns>
                    <ExpandCollapseColumn Visible="False" Resizable="False">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <RowIndicatorColumn Visible="False">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                </MasterTableView>
            </telerik:RadGrid>
        </asp:View>
        <asp:View ID="ViewFilter" runat="server">
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr style="display: none;">
                    <td>&nbsp;
                    </td>
                    <td align="right" valign="middle">
                        <asp:Button ID="BtnBack" runat="server" CausesValidation="False" Text="Back" />&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="Center" colspan="2">
                        <table align="center" width="100%" cellspacing="0">
                            <tr>
                                <td align="center" valign="top">
                                    <table id="Table3" align="center" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" class="sub-header sub-header-color">&nbsp;&nbsp;General Filter Options
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="LblMSG" runat="server" CssClass="warning" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left" style="width: 25%">Account Executive<br />
                                                            <telerik:RadListBox ID="RadListBoxAccountExecutives" runat="server" TabIndex="10" AutoPostBack="True" Height="100px"
                                                                SelectionMode="Multiple" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">Office<br />
                                                            <telerik:RadListBox ID="RadListBoxOffices" runat="server" AutoPostBack="True" Height="100px"
                                                                SelectionMode="Multiple" TabIndex="51" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">Sales Class<br />
                                                            <telerik:RadListBox ID="RadListBoxSalesClasses" runat="server" AutoPostBack="False" Height="100px"
                                                                SelectionMode="Multiple" TabIndex="52" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                        <td style="width: 25%">
                                                            <asp:Label ID="LabelManager" runat="server" Text="Manager"></asp:Label><br />
                                                            <telerik:RadListBox ID="RadListBoxManager" runat="server" TabIndex="10" AutoPostBack="True"
                                                                Height="100px" SelectionMode="Multiple" Width="100%">
                                                            </telerik:RadListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table align="center" border="0" cellpadding="0" cellspacing="2" width="100%">
                                                    <tr>
                                                        <td align="left">&nbsp;
                                                            <asp:RadioButtonList ID="RadioButtonListSelectionLevel" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                                                                RepeatLayout="Table" TabIndex="59">
                                                                <asp:ListItem Value="CDPC">All</asp:ListItem>
                                                                <asp:ListItem Value="CLIENT">Client</asp:ListItem>
                                                                <asp:ListItem Value="DIVISION">Division</asp:ListItem>
                                                                <asp:ListItem Value="PRODUCT">Product</asp:ListItem>
                                                                <asp:ListItem Value="CAMPAIGN">Campaign</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="LitCDPCSelections" runat="server"></asp:Literal>
                                                            <telerik:RadListBox ID="RadListBoxCDPCSelections" runat="server" AutoPostBack="False" Height="185px"
                                                                SelectionMode="Multiple" TabIndex="60" Width="525px">
                                                            </telerik:RadListBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:CheckBox ID="CheckBoxMyProjects" runat="server" TabIndex="65" Text="Narrow Project List to My Projects" AutoPostBack="true" />
                                                <br />
                                                <asp:CheckBox ID="CheckboxClosedJobs" runat="server" TabIndex="70" Text="Include Closed Jobs" Visible="false" />
                                                <asp:CheckBox ID="CheckBoxExcludeJobsWithCompletedSchedules" runat="server" TabIndex="80" Text="Exclude Jobs with Completed Schedules" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table id="Table4" align="center" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" class="sub-header sub-header-color">&nbsp;&nbsp;Budget Viewpoint and Hours Filter Options
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">&nbsp;Month/Year Range
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="Table5" align="center" cellpadding="2" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td align="right" style="width: 50px">&nbsp;From:
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadComboBox ID="ddlMonth" runat="server" AutoPostBack="False" TabIndex="90"
                                                                SkinID="RadComboBoxMonth">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                            <telerik:RadComboBox ID="ddlYear" runat="server" AutoPostBack="False" TabIndex="100"
                                                                SkinID="RadComboBoxYear">
                                                            </telerik:RadComboBox>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="width: 50px">to:
                                                        </td>
                                                        <td align="left">
                                                            <telerik:RadComboBox ID="ddlMonth2" runat="server" AutoPostBack="False" TabIndex="110"
                                                                SkinID="RadComboBoxMonth">
                                                            </telerik:RadComboBox>
                                                            &nbsp;
                                                            <telerik:RadComboBox ID="ddlYear2" runat="server" AutoPostBack="False" TabIndex="120"
                                                                SkinID="RadComboBoxYear">
                                                            </telerik:RadComboBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="height: 5px">
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr align="left" style="height: 50px; vertical-align: top">
                                            <td>&nbsp;&nbsp;Budget Viewpoint Forecast Option<br />
                                                &nbsp;
                                                <telerik:RadComboBox ID="ddlForecast" runat="server" AutoPostBack="False" Width="521"
                                                    TabIndex="130">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="Actual Billed" Value="Actual Billed"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Text="Actual Posted" Value="Actual Posted"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Text="Forecasted - Approved Billing & Actual Media Posted"
                                                            Value="Forecasted - Approved Billing & Actual Media Posted"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Text="Forecasted - Approved Estimate By Approved Date & Actual Media Posted"
                                                            Value="Forecasted - Approved Estimate By Approved Date & Actual Media Posted"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Text="Forecasted - Approved Estimate By Job Due Date & Actual Media Posted"
                                                            Value="Forecasted - Approved Estimate By Job Due Date & Actual Media Posted"></telerik:RadComboBoxItem>
                                                    </Items>
                                                </telerik:RadComboBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <table id="Table6" align="center" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td align="left" class="sub-header sub-header-color">&nbsp;&nbsp;QvA Filter Options
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="vertical-align: middle; height: 40px">&nbsp;Type:
                                                <telerik:RadComboBox ID="ddQvAType" runat="server" AutoPostBack="false" EnableViewState="true">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Value="False" Text="All"></telerik:RadComboBoxItem>
                                                        <telerik:RadComboBoxItem Value="True" Text="Time Only"></telerik:RadComboBoxItem>
                                                    </Items>
                                                </telerik:RadComboBox>
                                                &nbsp;&nbsp;&nbsp; Threshold:
                                                <asp:TextBox ID="txtThreshold" runat="server" AutoPostBack="false" Width="30px" MaxLength="3">100</asp:TextBox>%
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:Button ID="BtnSave" runat="server" CausesValidation="False" Text="Save" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;
                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
    </div>
    
</div>
<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
