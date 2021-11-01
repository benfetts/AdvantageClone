<%@ Page AutoEventWireup="false" EnableEventValidation="false" CodeBehind="Alert_Inbox.aspx.vb" Inherits="Webvantage.Alert_Inbox"
    Title="" Language="vb" MasterPageFile="~/ChildPage.Master" %>
<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <style>
            /*html {
                overflow: hidden;
            }*/
            .fml-column {
                min-width: 100px !important; 
                width: 110px;
            }
            .rcb-z {
                z-index: 1000000000;
            }
            #RadToolbarAlertInboxMain ul li {
                margin: 0 !important;
            }
            #RadToolbarAlertInboxMain .rtbTemplate input {
                height:28px;
                border-radius: 4px;
                padding-left: 5px;
            }
            #RadToolbarAlertInboxMain .rtbBtn a {
                margin: 0 1px!important;
            }
            .card-content td input {
                height: 28px!important;
            }
            #ctl00_ContentPlaceHolderMain_RadToolbarAlertInbox_i13_ChkIncludeCompletedAssignments {
                height: 14px !important;
            }
            #ctl00_ContentPlaceHolderMain_RadToolbarAlertInbox_i6_TxtSearchCriteria {
                height:28px!important;
            }
        </style> 
        <script type="text/javascript">
            function pnlRequestStarted(ajaxPanel, eventArgs) {
                if (eventArgs.EventTarget == "ctl00$ContentPlaceHolderMain$ImgBtnExport") {
                    eventArgs.EnableAjax = false;
                }
            }
            function RadGridAlertInboxColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridAlertInbox.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 10, 10);
            }
            function PaneCollapsed(sender, args) {
                //window.setTimeout(function () {
                //    //alert("panel collapsed");
                //    __doPostBack("SavePaneState", "Collapsed");
                //}, 0);
            }
            function PaneExpanded(sender, args) {
                //window.setTimeout(function () {
                //    //alert("panel expanded");
                //    __doPostBack("SavePaneState", "Expanded");
                //}, 0);
            }
            function refreshGrid() {
                refreshAlertInboxGrid();
            }
            function RefreshPage() {
                refreshAlertInboxGrid();
            }
            function refreshAlertInboxGrid() {
                //console.log("refreshAlertInboxGrid");
                __doPostBack('onclick#RebindGrid', 'RebindGrid');
            }
             function setGridHeight() {
                try {
                    var win = GetRadWindow();
                    if (win) {
                        var grid = $find("<%=RadGridAlertInbox.ClientID %>");
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
            function OnClientDropDownOpening(sender, args) {
                //var button = args.get_item(); 
                //var buttonElem = button.get_element(); 
                //var dropDownContainer = button.get_dropDownElement().offsetParent; 
                ////dropDownContainer.style.top = "20px"
                //console.log(dropDownContainer)
                var drop = sender.get_dropDownElement();
                if (drop) {
                    drop.style.top = "20px"
                }
                //console.log(drop)
            }
                function OnClientLoad(sender, args) {
                    var combo = sender
                    sender.set_offsetY(8)
                }
            $(document).ready(function () {
                setGridHeight();
                $(window).resize(function () {
                    setGridHeight();
                });
            });
        </script>
    </telerik:RadScriptBlock>
    <asp:Button ID="BtnPrint" runat="server" Text="Print" Visible="false" />
    <div style="">
        <asp:CheckBox runat="server" ID="checkBoxNewQuery" Checked ="True" AutoPostBack="true" Text="Use New Query" Visible="False" />
        <div id="RadToolbarAlertInboxMain" style="margin-left: auto; margin-right: auto; left: 0; right: 0; text-align: center;">
            <telerik:RadToolBar ID="RadToolbarAlertInbox" runat="server" AutoPostBack="True" Width="100%" TabIndex="-1">
                <Items>
                    <telerik:RadToolBarButton ImageUrl="~/Images/Icons/Grey/256/navigate_left.png" Value="ShowHideFilter" ToolTip="Hide filter" TabIndex="-1" />
                    <telerik:RadToolBarButton IsSeparator="true" TabIndex="-1" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAlert" Value="NewAlert" TabIndex="-1"
                        ToolTip="New alert" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonNewAssignment" TabIndex="-1"
                        CommandName="NewAlertAssignment" Text="" Value="NewAlertAssignment"
                        ToolTip="New Assignment" />
                    <telerik:RadToolBarButton IsSeparator="true" Value="RadToolBarButtonSeparatorNew" TabIndex="-1" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" TabIndex="-1" CommandName="Refresh"
                        ToolTip="Refresh view" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonSearchCriteria" TabIndex="-1">
                        <ItemTemplate>
                            <asp:TextBox ID="TxtSearchCriteria" runat="server" TabIndex="-1" SkinID="TextBoxStandard"></asp:TextBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonFind" Text="Search" Value="Search" TabIndex="-1"
                        ToolTip="Search" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonClear" TabIndex="-1"
                        Text="Clear" Value="ClearSearch" ToolTip="Clears the search text box" />
                    <telerik:RadToolBarButton IsSeparator="true" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonGroupFilter" TabIndex="-1">
                        <ItemTemplate>
                            Group/Filter:
                            <telerik:RadComboBox ID="RadComboBoxGroupBy" runat="server" AutoPostBack="true" TabIndex="-1" OnClientLoad="OnClientLoad">
                            </telerik:RadComboBox>
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true" TabIndex="-1" />
                    <telerik:RadToolBarButton Value="RadToolBarButtonAssignmentType" TabIndex="-1">
                        <ItemTemplate>
                            &nbsp;&nbsp;Show:
                        <telerik:RadComboBox ID="RadComboBoxAssignments" runat="server" AutoPostBack="true" Width="200" TabIndex="-1" OnClientLoad="OnClientLoad">
                            <Items>
                                <telerik:RadComboBoxItem Text="Alerts & Assignments" Value="myalertsandassignments" Selected="True" />
                                <telerik:RadComboBoxItem Text="Alerts" Value="myalerts" Selected="True" />
                                <telerik:RadComboBoxItem Text="My Assignments" Value="myalertassignments" />
                                <telerik:RadComboBoxItem Text="My Reviews" Value="myreviews" Visible="false" />
                                <telerik:RadComboBoxItem Text="All Assignments" Value="allalertassignments" />
                                <telerik:RadComboBoxItem Text="Unassigned" Value="unassigned" />
                            </Items>
                        </telerik:RadComboBox>
                            &nbsp;
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Value="RadToolBarButtonCompletedAssignments" TabIndex="-1">
                        <ItemTemplate>
                            &nbsp;
                        <asp:CheckBox ID="ChkIncludeCompletedAssignments" runat="server" AutoPostBack="True" TabIndex="-1"
                            Visible="True" Text="Incl. Completed&nbsp;&nbsp;" />
                        </ItemTemplate>
                    </telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="All Comments" Value="ViewComments" TabIndex="-1"
                        ToolTip="View all comments for this Job/Component" />
                    <telerik:RadToolBarButton IsSeparator="true" TabIndex="-1" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonExportExcel" ToolTip="Export to Excel" Value="ExportToExcel" TabIndex="-1" />
                    <telerik:RadToolBarButton SkinID="RadToolBarButtonBookmark" Text="" Value="Bookmark" TabIndex="-1"
                        ToolTip="Bookmark" />
                </Items>
            </telerik:RadToolBar>
        </div>
    </div>
    <div class="telerik-aqua-body">
        <div class="">
                <div id="DivFilter" runat="server" class="two-col-leftcolumn" style="border: 0 solid transparent;">
                    <div class="card-container" style="margin: -5px 0px 0px -15px; padding: 18px 10px;">
                        <asp:Panel ID="PanelFolderAndFilter" runat="server">
                            <div class="card">
                                <div class="card-content" style="margin-bottom:20px;">
                                    <telerik:RadTreeView ID="RadTreeViewFolders" runat="server" AutoPostBack="True" AutoPostBackOnCheck="false"
                                        CheckBoxes="False" ExpandDelay="0" ShowLineImages="False" Width="100%">
                                        <Nodes>
                                            <telerik:RadTreeNode runat="server" Checkable="false" Text="Current" Value="Inbox">
                                            </telerik:RadTreeNode>
                                            <telerik:RadTreeNode runat="server" Checkable="false" Text="Dismissed/Completed" Value="Dismissed">
                                            </telerik:RadTreeNode>
                                            <telerik:RadTreeNode runat="server" Checkable="false" Text="All"
                                                Value="Received">
                                            </telerik:RadTreeNode>
                                            <telerik:RadTreeNode runat="server" Checkable="false" Text="Drafts" Value="Drafts">
                                            </telerik:RadTreeNode>
                                        </Nodes>
                                    </telerik:RadTreeView>
                                </div>
                                <div class="card-action-bar card-bottom-header card-bottom-header-bg">
                                    <div class="card-bottom-header-text">
                                        Folder
                                    </div>
                                </div>
                            </div>
                            <div class="card">
                                <div class="card-content" style="margin-bottom: 20px;">
                                    <div id="TrStartEndDateHeader" runat="server">
                                        <p style="margin: 0; padding: 4px;">Last modified between:</p>
                                    </div>
                                    <div id="TrStartDate" runat="Server">
                                        <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                    </div>
                                    <div id="TrEndDate" runat="Server" style="padding: 4px 0px 10px 0px;">
                                        <telerik:RadDatePicker ID="RadDatePickerEndDate" runat="server"
                                            SkinID="RadDatePickerStandard">
                                            <DateInput DateFormat="d" EmptyMessage="End Date">
                                                <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                            </DateInput>
                                            <Calendar ID="CalendarEndDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                            </Calendar>
                                        </telerik:RadDatePicker>
                                    </div>
                                    <div id="TrEmployee" runat="Server">
                                        <div>
                                            <asp:HyperLink ID="HlEmployee" runat="server" href="">Employee:</asp:HyperLink>
                                        </div>
                                        <div>
                                            <asp:TextBox ID="TxtEmployee" runat="server" SkinID="TextBoxCodeLarge" MaxLength="6"></asp:TextBox>
                                        </div>
                                    </div>                                    
                                </div>
                                <div class="card-action-bar card-bottom-header card-bottom-header-bg">
                                    <div class="card-bottom-header-text">
                                        Filter
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div id="DivDismissAll" runat="server" style="text-align: center; width: 90%; margin: 10px 0px 20px 0px;">
                        <asp:Button ID="btnDismissAll" runat="server" Text="Dismiss All" ToolTip="Dismiss all alerts in the filtered inbox" Width="160px" />
                    </div>
                </div>
                <div id="DivGrid" runat="server" class="two-col-rightcolumn">
                    <table style="width: 99%;">
                        <tr style="width: 99%;">
                            <td style="width: 99%;">
                        <telerik:RadGrid ID="RadGridAlertInbox" runat="server" AllowSorting="True" AutoGenerateColumns="False" Width="100%"
                            EnableAJAX="True" EnableOutsideScripts="True" GridLines="None" AllowPaging="true"
                            PageSize="10" EnableHeaderContextMenu="true" GroupingSettings-GroupByFieldsSeparator="  "
                            EnableViewState="True">
                            <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                            <SortingSettings SortedAscToolTip="Sorted ascending" SortedDescToolTip="Sorted descending" />
                            <AlternatingItemStyle VerticalAlign="Middle" />
                            <FilterItemStyle HorizontalAlign="Left" Wrap="False" />
                            <ClientSettings AllowColumnsReorder="True" AllowRowsDragDrop="true">
                                <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                                <Scrolling AllowScroll="False" />
                                <Selecting AllowRowSelect="True" EnableDragToSelectRows="false" />
                            </ClientSettings>
                            <ExportSettings FileName="AlertInbox" Pdf-AllowPrinting="true" IgnorePaging="true"
                                OpenInNewWindow="true" Pdf-FontType="Embed">
                                <Pdf PageWidth="297mm" PageHeight="210mm" />
                            </ExportSettings>
                            <GroupingSettings GroupByFieldsSeparator=" " />
                            <MasterTableView AllowMultiColumnSorting="False" HorizontalAlign="Left" HeaderStyle-VerticalAlign="Middle" 
                                DataKeyNames="ALERT_ID, JOB_NUMBER, JOB_COMPONENT_NBR, SPRINT_ID, CATEGORY, TASK_SEQ_NBR" Width="100%">
                                <PagerStyle PageSizes="10,20,50,100" />
                                <Columns>
                                    <telerik:GridDragDropColumn HeaderStyle-Width="18px" Visible="true">
                                    </telerik:GridDragDropColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" UniqueName="TemplateColumn1" HeaderAbbr="FIXED">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <HeaderTemplate>
                                            <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon" CausesValidation="false"
                                                ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridAlertInboxColumnHeaderMenu(event);" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenFieldAlertId" runat="server" Value='<%#Eval("ALERT_ID")%>' />
                                            <asp:HiddenField ID="HiddenFieldIsAssignment" runat="server" Value="0" />
                                            <asp:HiddenField ID="HiddenFieldIsTask" runat="server" Value="0" />
                                            <div id="DivView" runat="server" class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="ViewImageButton" runat="server" CausesValidation="false" AlternateText="View alert" ToolTip="View alert" SkinID="ImageButtonViewWhite" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" GroupByExpression=""
                                        HeaderAbbr="FIXED" SortExpression="" UniqueName="TemplateColumn2">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivDismissComplete" runat="server" class="icon-background background-color-sidebar">
                                                <asp:ImageButton ID="DismissImageButton" runat="server" CausesValidation="false" CssClass="icon-image"
                                                    AlternateText="" ToolTip="" CommandName="Dismiss" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" Groupable="False"
                                        HeaderAbbr="FIXED" SortExpression="ATTACHMENTCOUNT" UniqueName="AttachmentColumn">
                                        <HeaderStyle CssClass="radgrid-icon-column" />
                                        <ItemStyle CssClass="radgrid-icon-column" />
                                        <FooterStyle CssClass="radgrid-icon-column" />
                                        <ItemTemplate>
                                            <div id="DivAttachments" runat="server" class="icon-background background-color-sidebar">
                                                <asp:Image ID="AttachmentsImage" runat="server" ImageUrl="Images/Icons/White/256/documents_empty.png" CssClass="icon-image" />
                                            </div>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn GroupByExpression="SUBJECT Subject Group By SUBJECT"
                                        HeaderAbbr="FIXED" HeaderText="Subject" SortExpression="SUBJECT" UniqueName="SubjectColumn"
                                        Visible="true" DataField="SUBJECT">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="left" />
                                        <ItemStyle CssClass="radgrid-description-column" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ViewLinkButton" runat="server" Visible="true" ToolTip="Click to view alert"></asp:LinkButton>
                                            <asp:Label ID="LblSubject" runat="server" Text='<%#Eval("SUBJECT") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="SUBJECT" GroupByExpression="SUBJECT By Group By SUBJECT"
                                        HeaderAbbr="FIXED" HeaderText="Subject" SortExpression="SUBJECT" UniqueName="SUBJECT"
                                        Visible="false">
                                        <ItemStyle CssClass="radgrid-description-column" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="USER_NAME" GroupByExpression="USER_NAME By Group By USER_NAME"
                                        HeaderAbbr="FIXED" HeaderText="By" SortExpression="USER_NAME" UniqueName="USER_NAME">
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="left" CssClass="MinWidth100" />
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="left" CssClass="MinWidth100" />
                                        <ItemTemplate>
                                                <asp:Label ID="LabelUserName" runat="server" Text=""></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn DataField="GENERATED" HeaderText="Last Updated" SortExpression="GENERATED"
                                        HeaderAbbr="FIXED" UniqueName="Sent">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="right" CssClass="radgrid-datetime-column" />
                                        <ItemTemplate>
                                                <asp:Label ID="LabelGenerated" runat="server" Text='<%#Eval("GENERATED")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn DataField="START_DATE" HeaderText="Start Date" SortExpression="START_DATE"
                                        UniqueName="START_DATE">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenFieldStartDate" runat="server" Value='<%#Eval("START_DATE")%>' />
                                            <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" AutoPostBack="true"
                                                OnSelectedDateChanged="RadDatePickerStartDate_SelectedDateChanged"
                                                SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="Start Date">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarStartDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="START_DATE" HeaderText="Start Date" SortExpression="START_DATE"
                                        Visible="false" UniqueName="START_DATE_EXPORT">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>

                                    <telerik:GridTemplateColumn DataField="DUE_DATE" HeaderText="Due Date" SortExpression="DUE_DATE"
                                        UniqueName="DUE_DATE">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenFieldDueDate" runat="server" Value='<%#Eval("DUE_DATE")%>' />
                                            <telerik:RadDatePicker ID="RadDatePickerDueDate" runat="server" AutoPostBack="true"
                                                OnSelectedDateChanged="RadDatePickerDueDate_SelectedDateChanged"
                                                SkinID="RadDatePickerStandard">
                                                <DateInput DateFormat="d" EmptyMessage="Due Date">
                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                </DateInput>
                                                <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                </Calendar>
                                            </telerik:RadDatePicker>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="DUE_DATE" HeaderText="Due Date" SortExpression="DUE_DATE"
                                        Visible="false" UniqueName="DUE_DATE_EXPORT">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="GridBoundColumnTimeDue" DataField="TIME_DUE" HeaderText="Time Due" SortExpression="TIME_DUE">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="right" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="right" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ALERT_STATE_NAME" HeaderText="State" SortExpression="ALERT_STATE_NAME"
                                        UniqueName="ALERT_STATE_NAME">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="center" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="PRIORITY" HeaderText="Priority" SortExpression="PRIORITY"
                                        Visible="false" UniqueName="PRIORITY_EXPORT">
                                        <HeaderStyle Width="55" VerticalAlign="Middle" HorizontalAlign="center" />
                                        <ItemStyle VerticalAlign="Middle" Width="55" HorizontalAlign="center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn AllowFiltering="False" GroupByExpression="PRIORITY Priority Group By Priority" HeaderText="Priority"
                                        SortExpression="PRIORITY" UniqueName="Priority">
                                        <HeaderStyle Width="45" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="45" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenFieldPriority" runat="server" Value='<%#Eval("PRIORITY")%>' />
                                            <telerik:RadComboBox ID="RadComboBoxPriority" runat="server" AutoPostBack="true" InputCssClass="no-border"
                                                DropDownWidth="80" Width="70" OnSelectedIndexChanged="RadComboBoxPriority_SelectedIndexChanged">
                                                <Items>
                                                </Items>
                                            </telerik:RadComboBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="CURRENT_NOTIFY_EMP_FML" GroupByExpression="CURRENT_NOTIFY_EMP_FML By Group By CURRENT_NOTIFY_EMP_FML"
                                        HeaderAbbr="FIXED" HeaderText="Assigned To" SortExpression="CURRENT_NOTIFY_EMP_FML" UniqueName="CURRENT_NOTIFY_EMP_FML_TEXT"
                                        Visible="false">
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="left" />
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn DataField="CURRENT_NOTIFY_EMP_FML" GroupByExpression="CURRENT_NOTIFY_EMP_FML [Assigned To] Group By CURRENT_NOTIFY_EMP_FML"
                                        HeaderText="Assigned To" SortExpression="CURRENT_NOTIFY_EMP_FML" UniqueName="CurrentNotifyEmpFMLColumn">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Left" CssClass="fml-column" />
                                        <ItemStyle VerticalAlign="Middle"  HorizontalAlign="Left" CssClass="fml-column" />
                                        <ItemTemplate>
                                                <asp:LinkButton ID="LinkButtonAssignedTo" runat="server" Text='<%# Eval("CURRENT_NOTIFY_EMP_FML") %>' Width="100" ToolTip="Click to re-assign"></asp:LinkButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn DataField="TYPE" HeaderText="Alert Type" SortExpression="TYPE" HeaderAbbr="FIXED" Visible="false"
                                        UniqueName="AlertTYPE">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CATEGORY" HeaderText="Category" SortExpression="CATEGORY"
                                        UniqueName="CATEGORY">
                                        <HeaderStyle Width="100" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="100" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="CL_NAME" HeaderText="Client" SortExpression="CL_NAME"
                                        UniqueName="CL_NAME">
                                        <HeaderStyle Width="200" VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <ItemStyle VerticalAlign="Middle" Width="200" HorizontalAlign="Left" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ALERT_ID" HeaderText="ALERT_ID" SortExpression="ALERT_ID"
                                        HeaderAbbr="FIXED" Display="false" Visible="True" UniqueName="ColALERT_ID">
                                        <HeaderStyle Width="20" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="20" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="ID" HeaderText="ID" SortExpression="ID" UniqueName="ColID"
                                        HeaderAbbr="FIXED">
                                        <HeaderStyle Width="20" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="20" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="VERSION" HeaderText="Version" SortExpression="VERSION"
                                        UniqueName="GridBoundColumnVER">
                                        <HeaderStyle Width="20" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="20" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="BUILD" HeaderText="Build" SortExpression="BUILD"
                                        UniqueName="GridBoundColumnBUILD">
                                        <HeaderStyle Width="20" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" Width="20" HorizontalAlign="Center" />
                                    </telerik:GridBoundColumn>
                                </Columns>
                                <ExpandCollapseColumn Visible="False">
                                    <HeaderStyle Width="20" />
                                </ExpandCollapseColumn>
                                <RowIndicatorColumn Visible="False">
                                    <HeaderStyle Width="20" />
                                </RowIndicatorColumn>
                            </MasterTableView>
                        </telerik:RadGrid>
                            </td>
                        </tr>
                    </table>
                </div>
        </div>
        <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
    </div>    
</asp:Content>
