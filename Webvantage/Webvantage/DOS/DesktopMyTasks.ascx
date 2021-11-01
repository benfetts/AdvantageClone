<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DesktopMyTasks.ascx.vb" Inherits="Webvantage.DesktopMyTasks" %>
<%@ Register Src="~/UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>

<telerik:RadScriptBlock ID="sbControl_ScriptBlock" runat="server">
    <script type="text/javascript">
        function RadGridMyTasksColumnPreferencesClick(event) {

            var grid = $find("<%= TaskRadGrid.ClientID %>");

            grid.get_masterTableView().get_columns()[0].showHeaderMenu(event, 10, 10);

        };
        // used in document_list2
        function SetTaskDocumentIcon(input, hasDocuments) {
            try {
                var div = $(input).parent('div');
                if (hasDocuments === true) {
                    $(input).attr('title', 'Task Documents');
                    if (!$(div).hasClass('standard-green'))
                        $(div).addClass('standard-green');
                } else {
                    $(input).attr('title', 'No Task Documents');
                    if (!$(div).hasClass('standard-green'))
                        $(div).removeClass('standard-green');
                }
            } catch (err) {

            }
        };
        function TaskRadGridOnRowDropped(sender, args) {
            var node = args.get_destinationHtmlElement();
            if (node) {
                alert(node.id)
            }
        }
         function isChildOf(parentId, element) {
            while (element) {
                if (element.id && element.id.indexOf(parentId) > -1) {
                    return true;
                }
                element = element.parentNode;
            }
            return false;
        }
    </script>
</telerik:RadScriptBlock>
<div class="telerik-aqua-body" style="margin-top: 5px!important;">
    <div class="DO-ButtonHeader">
    
        <div style="float: left; width: 90%; text-align: left; vertical-align: middle">
            <asp:ImageButton ID="butPrint" runat="server" SkinID="ImageButtonPrint" />
            <asp:ImageButton ID="butExport" runat="server" SkinID="ImageButtonExportExcel" ToolTip="Export to Excel" />
            <asp:ImageButton ID="ImageButtonFilter" runat="server" SkinID="ImageButtonFilter" />
            <asp:ImageButton ID="ImageButtonBookmark" runat="server" ToolTip="Bookmarks" SkinID="ImageButtonBookmark"/>
            <asp:ImageButton ID="butRefresh" runat="server" SkinID="ImageButtonRefresh" ToolTip="Refresh" />

            <div style="display: inline-block; padding: 0px 0px 0px 10px;">
                Search:
            </div>
            <asp:TextBox ID="TextBoxSearchHeader" runat="server"></asp:TextBox>
            <asp:ImageButton ID="ImageButtonSearchHeader" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
        </div>
        <div style="float: right; width: 10%; text-align: right;">
        </div>
    </div>
    <div class="DO-Container">
        <ew:CollapsablePanel ID="CollapsablePanelFilter" runat="server" SkinID="CollapsablePanelDesktopObjectFilter" Collapsed="true" Visible="false">
            <div style="font-size: larger; margin: -7px 0px 0px 0px !important;">
                Filter
            </div>
            <table id="TableFilterTasks" border="0" cellspacing="2" cellpadding="0" width="90%">
                <tr>
                    <td style="width:200px;" width="200px">
                        <asp:Label ID="Label8" runat="server">Task Status</asp:Label>
                    </td>
                    <td style="width: 250px;" width="250px">
                        <asp:Label ID="Label9" runat="server">Tasks</asp:Label>
                    </td>
                    <td align="right" valign="middle">&nbsp;
                    </td>
                    <td align="right" valign="middle" >&nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align:top;">
                        <telerik:RadComboBox ID="ddType" runat="server" AutoPostBack="true" EnableViewState="true"
                            Width="200">
                            <Items>
                                <telerik:RadComboBoxItem Value="A" Text="All"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="Projected" Text="Projected"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="Active" Text="Active"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="H" Text="High Priority"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="L" Text="Low Priority"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td style="vertical-align: top;">
                        <telerik:RadComboBox ID="ddTaskShow" runat="server" AutoPostBack="true" EnableViewState="true" Width="250">
                            <Items>
                                <telerik:RadComboBoxItem Value="Today" Text="Open Tasks to Start as of Today"></telerik:RadComboBoxItem>
                                <telerik:RadComboBoxItem Value="All" Text="All Open Tasks"></telerik:RadComboBoxItem>
                            </Items>
                        </telerik:RadComboBox>
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="CheckBoxTodayOnlyWithStartDue" runat="server" Text="Only Tasks with Start and Due Dates" AutoPostBack="true" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label10" runat="server">Search</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                        <asp:ImageButton ID="imgbtnSearch" runat="server" SkinID="ImageButtonFind" ToolTip="Search" />
                    </td>
                </tr>
            </table>
        </ew:CollapsablePanel>
    </div>
    <div class="DO-Container">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
                <telerik:RadGrid ID="TaskRadGrid" runat="server" AllowPaging="True" AllowSorting="True"
                    Width="100%" AutoGenerateColumns="False" GridLines="None" EnableEmbeddedSkins="True"
                    EnableHeaderContextMenu="true" >
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="True" Position="Bottom"></PagerStyle>
                    <MasterTableView AllowMultiColumnSorting="true" DataKeyNames="JobNo,JobComp,SeqNo,IS_EVENT,EVENT_TASK_ID,TASK_STATUS, ALERT_ID">
                        <Columns>
                            <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="true">
                            </telerik:GridDragDropColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridMyTasksColumnPreferencesClick(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" ImageAlign="AbsMiddle" CssClass="icon-image"
                                            SkinID="ImageButtonViewWhite" ToolTip="View Task" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Mark Complete">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivMarkComplete" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonMarkComplete" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Icons/White/256/check.png" CssClass="icon-image"
                                            ToolTip="Mark temp complete" CommandName="MarkComplete" CommandArgument="Mark" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn3" HeaderText="Add Time">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="butAddTime" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/Icons/White/256/clock.png" CssClass="icon-image"
                                            ToolTip="Add Time" CommandName="AddTime" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStopwatch" HeaderText="Start Stopwatch">
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
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Status">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivPriorityColor" runat="server" class="icon-background background-color-sidebar">
                                        <asp:Image ID="ImagePriority" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/progress_bar.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumnDocuments" HeaderText="">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDocumentsColor" runat="server" class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonDocuments" runat="server" CommandName="Documents" ToolTip="Documents" ImageUrl="~/Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="CDP" HeaderText="Client" UniqueName="cdp">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP" HeaderText="Job/Comp" UniqueName="column36">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_DESC" HeaderText="Job Description" UniqueName="column34">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JOB_COMP_DESC" HeaderText="Comp Description" UniqueName="column35">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="JobNo" HeaderText="Project" UniqueName="column3"
                                SortExpression="JobNo">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" CssClass="radgrid-description-column" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="Task" HeaderText="Task" UniqueName="taskcolumn">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="FNC_COMMENTS" HeaderText="Task Comment" UniqueName="column31">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                <ItemTemplate>
                                    <div style="min-width: 150px; margin: -2px 0px -2px 0px; max-height: 70px; overflow: auto; min-height: 40px;">
                                        <%# If(IsDBNull(Eval("FNC_COMMENTS")), "", Server.HtmlEncode(Eval("FNC_COMMENTS")))%>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="HoursAllowed" HeaderText="Hours" UniqueName="column">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="40" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="40" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="40" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="StartDate" HeaderText="Start" UniqueName="column77" DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueDate" HeaderText="Due" UniqueName="column78" DataFormatString="{0:d}">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="DueTime" HeaderText="Due By" UniqueName="column7">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="80" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn4" HeaderText="Due Indicator">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar" runat="server" id="DivFlagColor">
                                        <asp:Image ID="ImageFlag" runat="server" CssClass="icon-image" ImageUrl="~/Images/Icons/White/256/signal_flag.png" />
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="EmpCode" UniqueName="column8" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobNo" UniqueName="column9" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="JobComp" UniqueName="column10" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="SeqNo" UniqueName="column11" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="IS_EVENT" UniqueName="column12" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="EVENT_TASK_ID" UniqueName="column13" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="TASK_STATUS" UniqueName="column14" Visible="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ALERT_ID" UniqueName="AlertID" Visible="false">
                            </telerik:GridBoundColumn>
                        </Columns>
                        <ExpandCollapseColumn Visible="False">
                            <HeaderStyle Width="19px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                    <ClientSettings AllowRowsDragDrop="true">
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown"  />
                        <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                    </ClientSettings>
                </telerik:RadGrid>
    <%--        </ContentTemplate>
        </asp:UpdatePanel>--%>
    </div>

</div>
<asp:HiddenField ID="HiddenFieldWindowName" Value="" runat="server" />
<telerik:RadScriptBlock ID="ScriptBlockFooter" runat="server">
    <script type="text/javascript">
        function getRadWindowName() {
            try {
                var oWnd = GetRadWindow();
                var id = oWnd.get_name();
                document.getElementById('<%= HiddenFieldWindowName.ClientID %>').value = id;
            } catch (err) {
                var abc = null;
            };
        };
        getRadWindowName();
    </script>
</telerik:RadScriptBlock>
<custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
