<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopAlerts.ascx.vb"
    Inherits="Webvantage.DesktopAlerts" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<%@ Register Src="InOutBoard.ascx" TagName="InOutBoard" TagPrefix="custom" %>
<telerik:RadScriptBlock ID="RadScriptBlock" runat="server">
    <script type="text/javascript">
        function RadGridMyAlertsColumnPreferences(event) {
            var grid = $find("<%= RadGridMyAlerts.ClientID %>");
            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);
        };
        function FilterPanel() {
            __doPostBack('onclick#FilterPanel', 'FilterPanel');
        };
        function RadGridMyAlertsGridCreated(sender, args) {
            try {
                //resizeGridScroll(false);
            } catch (e) {
            }
        }
        function setGridHeight() {
            try {
                var win = GetRadWindow();
                if (win) {
                    var grid = $find("<%=RadGridMyAlerts.ClientID %>");
                    if (grid) {
                        var windowHeight = $(window).height() - 55;
                        var scrollArea = grid.GridDataDiv;
                        if (scrollArea) {
                            scrollArea.style.height = windowHeight + "px";
                        }
                    }
                }
            } catch (e) {
            }
        }
        $(document).ready(function () {
            setGridHeight();
            $(window).resize(function () {
                setGridHeight();
            });
        });
    </script>
</telerik:RadScriptBlock>
<asp:Label ID="lblMsg" runat="server" CssClass="warning"></asp:Label>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader" style="margin-bottom: 35px;">
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;">
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
        </div>
        <div style="float: left; text-align: left; vertical-align: middle; display: inline-block;" id="DivUserControlInOutBoard" runat="server">
            <custom:InOutBoard ID="UserControlInOutBoard" runat="server" />
        </div>
        <div style="float: right; text-align: right; display: inline-block;">
            <asp:ImageButton ID="butRefreshAlerts" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />
        </div>
    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterAlert" border="0" cellspacing="2"
                cellpadding="0">
                <tr>
                    <td align="left">Type:
                    </td>
                    <td align="left">Group/Filter:
                    </td>
                    <asp:Panel ID="pnlShow" runat="server">
                        <td align="left">Show:
                        </td>
                    </asp:Panel>
                </tr>
                <tr>
                    <td align="left">
                        <telerik:RadComboBox ID="DropType" runat="server" AutoPostBack="True" Width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="RadComboBoxSortOptions" runat="server" AutoPostBack="True" Width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <telerik:RadComboBox ID="DropDownListShowAssignmentType" runat="server" AutoPostBack="True" Width="220">
                            <Items>
                                <telerik:RadComboBoxItem Text="My Alerts & Assignments" Value="myalertsandassignments"
                                    Selected="True"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="My Alerts" Value="myalerts"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Text="My Assignments" Value="myalertassignments"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td align="left">Category:
                    </td>
                    <td align="left">Search:
                    </td>
                    <td align="left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <telerik:RadComboBox ID="DropCategory" runat="server" AutoPostBack="True" Width="220">
                        </telerik:RadComboBox>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="TxtSearch" runat="server">
                        </asp:TextBox>
                        <asp:ImageButton ID="imgbtnSearch" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
                    </td>
                    <td align="left">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
        <telerik:RadGrid ID="RadGridMyAlerts" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" enableajax="false" GridLines="None" EnableEmbeddedSkins="True" Width="100%"
            EnableHeaderContextMenu="true">
            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
            <ClientSettings AllowRowsDragDrop="true">
                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnGridCreated="RadGridMyAlertsGridCreated" />
                <Selecting AllowRowSelect="True" EnableDragToSelectRows="False" />
                <Scrolling AllowScroll="True" />
            </ClientSettings>
            <MasterTableView DataKeyNames="ALERT_ID, JOB_NUMBER, JOB_COMPONENT_NBR, SPRINT_ID, CATEGORY, TASK_SEQ_NBR" Width="100%">
                <Columns>
                    <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="true">
                    </telerik:GridDragDropColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False"
                        SortExpression="" UniqueName="ViewColumn" HeaderAbbr="FIXED">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <HeaderTemplate>
                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridMyAlertsColumnPreferences(event);" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonViewAlert" runat="server" CommandName="ViewAlert" CssClass="icon-image"
                                    CommandArgument='<%#Eval("ALERT_ID") %>' ImageUrl="~/Images/Icons/White/256/mail.png" ToolTip="View Alert" />
                                <asp:HiddenField ID="HiddenFieldIsAssignment" runat="server" Value="0" />
                                <asp:HiddenField ID="HiddenFieldIsTask" runat="server" Value="0" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False"
                        SortExpression="" UniqueName="DismissColumn" HeaderAbbr="FIXED">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div id="DivDismissComplete" runat="server" class="icon-background background-color-sidebar">
                                <asp:ImageButton ID="ImageButtonDismiss" runat="server" CommandName="Dismiss" CommandArgument='<%#Eval("ALERT_ID") %>' CssClass="icon-image"
                                    ImageUrl="~/Images/Icons/White/256/garbage.png" ToolTip="Dismiss Alert" />
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="False"
                        SortExpression="PRIORITY" UniqueName="PriorityColumn" HeaderAbbr="FIXED">
                        <HeaderStyle CssClass="radgrid-icon-column" />
                        <ItemStyle CssClass="radgrid-icon-column" />
                        <FooterStyle CssClass="radgrid-icon-column" />
                        <ItemTemplate>
                            <div id="DivPriority" runat="server" class="icon-background background-color-sidebar">
                                <asp:Label ID="LabelPriority" runat="server" Text="" CssClass="icon-text-two"></asp:Label>
                            </div>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="SPRINT_ID" HeaderText="Sprint ID" SortExpression="SPRINT_ID" Visible="false"
                        UniqueName="GridBoundColumnSPRINT_ID">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn GroupByExpression="SUBJECT Subject Group By SUBJECT"
                        HeaderText="Subject" SortExpression="SUBJECT" UniqueName="SubjectColumn" Visible="true">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemTemplate>
                            <asp:LinkButton ID="LBtnViewAlert" runat="server" Visible="true"></asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Start" SortExpression="START_DATE" DataFormatString="{0:d}"
                        UniqueName="GridBoundColumnStartDate">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DUE_DATE" HeaderText="Due" SortExpression="DUE_DATE" DataFormatString="{0:d}"
                        UniqueName="GridBoundColumnDueDate">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn UniqueName="GridBoundColumnTimeDue" DataField="TIME_DUE" HeaderText="Time Due" SortExpression="TIME_DUE">
                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="TYPE" HeaderText="Type" SortExpression="TYPE"
                        UniqueName="AlertTYPE">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="75" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" SortExpression="CL_NAME"
                        UniqueName="colClient">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="GRP_COMPONENT" HeaderText="Project" SortExpression="GRP_COMPONENT"
                        UniqueName="colProject">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Generated" HeaderText="Last Updated" UniqueName="GridBoundColumnLastUpdated" DataFormatString="{0:g}">
                        <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" CssClass="radgrid-datetime-column" />
                        <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" CssClass="radgrid-datetime-column" />
                        <FooterStyle HorizontalAlign="Right" VerticalAlign="Top" CssClass="radgrid-datetime-column" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="USER_NAME" HeaderText="Last Updated By" UniqueName="colLastUpdatedBy">
                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                        <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="120" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="READ_ALERT" HeaderText="" Visible="false" UniqueName="READ_ALERT"
                        HeaderAbbr="FIXED">
                    </telerik:GridBoundColumn>
                </Columns>
                <ExpandCollapseColumn Visible="False">
                    <HeaderStyle Width="19px" />
                </ExpandCollapseColumn>
                <RowIndicatorColumn Visible="False">
                    <HeaderStyle Width="20px" />
                </RowIndicatorColumn>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</div>

<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
