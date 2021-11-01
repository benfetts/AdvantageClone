<%@ Page AspCompat="false" AutoEventWireup="false" CodeBehind="Timesheet_CopyFrom.aspx.vb" Inherits="Webvantage.Timesheet_CopyFrom" Language="vb" MasterPageFile="~/ChildPage.Master" Title="Timesheet - Copy From Selection" %>

<asp:Content ID="ContentMain" runat="server" ContentPlaceHolderID="ContentPlaceHolderMain">
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/timeSheetCopyLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/functionCategoryLookupModal.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">
            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) {
                    return false;
                }
            }
            document.onkeypress = stopRKey;
            function refreshCallBack() {
                __doPostBack('onclick#RefreshMyTemplate', 'RefreshMyTemplate');
                console.log("refreshCallBack:CopyFrom")
            }
            function OnRowClick() {
                return false;
            };
            function RefreshGrid(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function RefreshMyTemplate(radWindowCaller) {
                __doPostBack('onclick#RefreshMyTemplate', 'RefreshMyTemplate');
            };
            function SaveFromPopUp(radWindowCaller) {
                __doPostBack('onclick#Save', 'Save');
            };
            function realPostBack(eventTarget, eventArgument) {
                __doPostBack(eventTarget, eventArgument);
            };
            function HidePopUpWindows(radWindowCaller) {
                __doPostBack('onclick#Refresh', 'HidePopups');
            };
            function OnClientClose(sender, EventArgs) {
                __doPostBack('onclick#Refresh', 'Refresh');
            };
            function RefreshPage() {
                __doPostBack('onclick#Refresh', 'Refresh');
            }        
            function refreshCopyFromTimeTemplatesGridOnPage() {
                console.log("refreshCopyFromTimeTemplatesGrid: on page");
            }
            function enableButton() {
                var signInButton = $("#<%=ButtonGetTime.ClientID %>");
                if (signInButton) {
                    signInButton.prop("value", "Get Selected Days");
                    signInButton.prop("disabled", false);
                }
            }
            $(document).ready(function () {
                var signInButton = $("#<%=ButtonGetTime.ClientID %>");
                if (signInButton) {
                    signInButton.click(function () {
                        signInButton.prop("value", "Please wait...");
                        signInButton.prop("disabled", true);
                        <%=ClientScript.GetPostBackEventReference(ButtonGetTime, "").ToString()%>
                    })
                }

                $("body").css("display", "none");
                $("body").fadeIn(750);

            });
            function JsOnClientButtonClicking(sender, args) {
                var comandName = args.get_item().get_commandName();
                if (comandName == "Delete") {
                    ////args.set_cancel(!confirm('Are you sure you want to delete?'));
                    radToolBarConfirm(sender, args, "Are you sure you want to delete?");
                }
                else if (comandName == "CloseWindow") {
                    window.close();
                }
                else if (comandName == "InsertHours") {
                    return false;
                }
                else if (comandName == "NoPostBack") {
                    args.set_cancel(true);
                }
            }
            $(document).ready(function () {
                $("#TextBox_ProductCategory").dblclick(function () {
                    OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=ts&control='
                            + $("#TextBox_ProductCategory").val() + "&type=productcategory&client="
                            + $("#TextBox_ClientCode").val()
                            + '&division=' + $("#TextBox_DivisionCode").val()
                            + '&product=' + $("#TextBox_ProductCode").val());
                    return false;
                });


            });                       
            function RadGridTimesheetColumnHeaderMenu(ev) {
                var grid = $find("<%= RadGridTimesheetStaging.ClientID %>");
                grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
            }
            function RadGridTimesheetNewOnMasterTableViewCreated() {
                //alert("RadGridTimesheetNewOnMasterTableViewCreated")
            }
            function clientShow(sender, eventArgs) {
                var c = confirm('Must select Calendar Type and related settings before use.  Enter now?');
                if (c == true) {
                    __doPostBack('onclick#CalendarTime', 'CalendarTime');
                } else {
                    return false;
                }
                        
            }
            function clientShowGoogle(sender, eventArgs) {
                var c = confirm('Must enable Google Services before use.  Enter now?');
                if (c == true) {
                    __doPostBack('onclick#CalendarTime', 'CalendarTime');
                } else {
                    return false;
                }

            }
            function clientShowGT() {
                var c = confirm('Must select Calendar Type and related settings before use.  Enter now?');
                if (c == true) {
                    __doPostBack('onclick#CalendarTime', 'CalendarTime');
                } else {
                    return false;
                }

            }
   function ShowToolTip(element) {
        var tooltip = $find("<%=RadToolCopyTo.ClientID%>");
        tooltip.set_targetControl(element);
        tooltip.show();
    }

    function OnClientMouseOver(sender, args) {
        var button = args.get_item();
        var sCommandName = button.get_commandName();
        if (sCommandName == 'NoPostBack') {
            ShowToolTip(button.get_element());
        }
    }
        </script>
    </telerik:RadScriptBlock>
    <div style="width: 99% !important; margin: auto;">
        <telerik:RadToolBar ID="RadToolbarCopyFrom" runat="server" AutoPostBack="true" OnClientButtonClicking="JsOnClientButtonClicking" OnClientMouseOver="OnClientMouseOver"
            Width="98%">
            <Items>
                <telerik:RadToolBarButton SkinID="RadToolBarButtonNew" Text="New Template Item" Value="NewTemplateItem" ToolTip="Create a new Timesheet Template record" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonDelete" Text="Delete selected rows." Value="Delete" CommandName="Delete" ToolTip="Delete checked items" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSave" Text="" Value="UpdateCalendarTimeData" CommandName="UpdateCalendarTimeData" ToolTip="Save calendar time rows." />
                <telerik:RadToolBarButton runat="server" ID="GetCalendarTime" Text="Get Calendar Time" Value="GetCalendarTime" CommandName="NoPostBack" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonSettings" Text="Settings" Value="Settings" CommandName="Settings" />
                <telerik:RadToolBarButton SkinID="RadToolBarButtonRefresh" Value="Refresh" ToolTip="Refresh page / Apply filter" CommandName="Refresh" />
            </Items>
        </telerik:RadToolBar>
        <telerik:RadToolTip ID="RadToolCopyTo" runat="server" SkinID="RadToolTipToolbarContentAreaCT" Width="310" Height="480" TargetControlID="GetCalendarTime" OffsetY="20" RelativeTo="Element" ManualClose="True" HideEvent="FromCode" Modal="True">
            <div>
                <div class="larger-font" style="width: 280px;">
                    Get Calendar Time
                </div>
                <div id="DivCopyHours" runat="server" style="margin: 10px 0px 0px 0px !important;" visible="false">
                    <asp:CheckBox ID="CheckBoxOnlyRT" runat="server" Text="RecordTime Only" />
                </div>
                <div>
                    <div style="width: 275px; float: left; position: relative;">
                        <div>
                            <div style="padding: 0px 0px 0px 0px;">
                                <asp:Button ID="ButtonGetTime" runat="server" Text="Get Selected Days" ToolTip="" Width="276" />
                            </div>
                            <div style="padding: 10px 0px 0px 0px;">
                                <telerik:RadCalendar ID="RadCalendarCopyToSelectedWeek" runat="server" Width="276" EnableKeyboardNavigation="true" EnableMultiSelect="True"
                                    ShowColumnHeaders="true" ShowDayCellToolTips="true" ShowRowHeaders="false" RangeSelectionMode="ConsecutiveClicks" ShowOtherMonthsDays="False" UseColumnHeadersAsSelectors="False">
                                    <FastNavigationSettings EnableTodayButtonSelection="true">
                                    </FastNavigationSettings>
                                </telerik:RadCalendar>
                            </div>
                            <div style="padding: 0px 0px 0px 0px;">
                                <asp:Label ID="LabelInstruction" runat="server" Text="*Click on a start and end date to select a range." Font-Size="Small"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </telerik:RadToolTip>
        <div style="text-align: right;">
            <asp:Label ID="lblNoTimesheetCopy" runat="server" Text="*The Copy From Timesheet feature is disabled in Agency Maintenance.&nbsp;&nbsp;"
                Visible="false"></asp:Label>
        </div>
        <asp:MultiView ID="MultiViewCopyFrom" runat="server" ActiveViewIndex="0">
            <asp:View ID="ViewMyTimesheets" runat="server">
            </asp:View>
            <asp:View ID="ViewMyProjects" runat="server">
            </asp:View>
            <asp:View ID="ViewMyTemplate" runat="server">
            <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <div>
                    <div>
                        Group by:&nbsp;
                            <telerik:RadComboBox ID="DropGroupBy" runat="server" AutoPostBack="True" Width="400">
                                <Items>
                                    <telerik:RadComboBoxItem Value="" Text="None"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client Group By CL_NAME" Text="Client"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client, DIV_NAME Division Group By CL_NAME, DIV_NAME"
                                        Text="Client/Division"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client, DIV_NAME Division, PRD_NAME Product Group By CL_NAME, DIV_NAME, PRD_NAME"
                                        Text="Client/Division/Product"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client, Job Job Group By CL_NAME, Job" Text="Client/Job"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client, DIV_NAME Division, Job Job Group By CL_NAME, DIV_NAME, Job"
                                        Text="Client/Division/Job"></telerik:RadComboBoxItem>
                                    <telerik:RadComboBoxItem Value="CL_NAME Client, DIV_NAME Division, PRD_NAME Product, Job Job Group By CL_NAME, DIV_NAME, PRD_NAME, Job"
                                        Text="Client/Division/Product/Job"></telerik:RadComboBoxItem>
                                </Items>
                            </telerik:RadComboBox>
                    </div>
                    <div style="text-align: center;">
                        <span>Hold down the mouse button and drag to select multiple rows.</span>
                    </div>
                    <telerik:RadGrid ID="RadGridTimesheetTemplate" runat="server" AllowPaging="False"
                        AllowSorting="True" GridLines="None" PageSize="10" EnableEmbeddedSkins="True"
                        AllowMultiRowSelection="true" ShowFooter="False" AutoGenerateColumns="False"
                        Width="99%">
                        <ClientSettings>
                            <Selecting AllowRowSelect="True" EnableDragToSelectRows="True" />
                        </ClientSettings>
                        <MasterTableView NoDetailRecordsText="No Records to Display" DataKeyNames="EMP_TIME_TMPLT_ID,JOB_NUMBER,JOB_COMPONENT_NBR,FNC_CODE" EnableLinqGrouping="false">
                            <Columns>
                                <telerik:GridClientSelectColumn UniqueName="GridClientSelectColumn1" HeaderText="">
                                    <HeaderStyle Width="10px" />
                                    <ItemStyle Width="10px" />
                                    <FooterStyle Width="10px" />
                                </telerik:GridClientSelectColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobAndComponent" HeaderText="Job<br/>Job Comp"
                                    DataField="JOB_AND_COMPONENT" SortExpression="JOB_AND_COMPONENT">
                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" />
                                    <FooterStyle VerticalAlign="Top" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HfJobIsClosed" runat="server" Value='<%# Eval("IS_CLOSED") %>' />
                                        <asp:HiddenField ID="HfHasAccessToFunction" runat="server" Value='<%# Eval("HAS_ACCESS_TO_FUNCTION") %>' />
                                        <div runat="server" id="DivJobAndComponent">
                                            <asp:Label ID="lblJobNo" runat="server" Text='<%# Eval("JOB_NUMBER") %>' Visible="True">
                                            </asp:Label>
                                            &nbsp;-&nbsp;
                                            <asp:Label ID="lblJobDesc" runat="server" Text='<%# Eval("JOB_DESC") %>' Visible="True">
                                            </asp:Label>
                                            <br />
                                            <asp:Label ID="lblJobCompNo" runat="server" Text='<%# Eval("JOB_COMPONENT_NBR") %>'
                                                Visible="True">
                                            </asp:Label>
                                            &nbsp;-&nbsp;
                                            <asp:Label ID="lblJobCompDesc" runat="server" Text='<%# Eval("JOB_COMP_DESC") %>'
                                                Visible="True">
                                            </asp:Label>
                                        </div>
                                        <asp:Image ID="ImageProcessControlWarning" runat="server" ToolTip="Process Control does not allow this to be a template item" Visible="false" SkinID="ImageWarningProcessControl" />
                                        <asp:Image ID="ImageNoAccessToFunction" runat="server" ToolTip="You no longer have access to this function" Visible="false" SkinID="ImageWarningProcessControl" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnFunctionAndDesc"
                                    SortExpression="FNC_CODE">
                                    <HeaderStyle Width="240" VerticalAlign="Bottom" HorizontalAlign="Left" />
                                    <ItemStyle Width="240" VerticalAlign="Top" HorizontalAlign="Left" />
                                    <FooterStyle Width="240" VerticalAlign="Top" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <div style="margin-bottom: 4px;">
                                            <div style="display: inline-block; width: 60px;">
                                                <asp:Label ID="LabelFuncCatAlias" runat="server"></asp:Label>
                                            </div>
                                            <div style="display: inline-block;">
                                                <asp:HiddenField ID="HfFNC_CODE" runat="server" Value='<%# Eval("FNC_CODE") %>' />
                                                <telerik:RadComboBox ID="DropFNC_CODE" runat="server" InputCssClass="no-border" >
                                                </telerik:RadComboBox>
                                            </div>
                                        </div>
                                         <div style="display: none !important;">
                                            <div style="display: inline-block; width: 60px;">
                                                <span>Dept</span>
	                                        </div>
	                                        <div style="display: inline-block;">
                                                <telerik:RadComboBox ID="DropDept" runat="server" InputCssClass="no-border" >
                                                </telerik:RadComboBox>
	                                        </div>
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Prod Cat" UniqueName="GridTemplateColumnProdCat"
                                    SortExpression="PROD_CAT_CODE">
                                    <HeaderStyle Width="200" VerticalAlign="Bottom" HorizontalAlign="Left" />
                                    <ItemStyle Width="200" VerticalAlign="Top" HorizontalAlign="Left" />
                                    <FooterStyle Width="200" VerticalAlign="Top" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="DropProdCat" runat="server" InputCssClass="no-border">
                                        </telerik:RadComboBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDefaultComment" HeaderText="Comment"
                                    SortExpression="DFLT_COMMENT">
                                    <HeaderStyle Width="150" VerticalAlign="Bottom" />
                                    <ItemStyle Width="150" VerticalAlign="Top" />
                                    <FooterStyle Width="150" VerticalAlign="Top" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="TextBoxDefaultComment" runat="server" Text='<%#Eval("DFLT_COMMENT")%>'  SkinID="TextBoxStandard"
                                            TextMode="multiLine" CssClass="radgrid-textarea"></asp:TextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnApply" HeaderText="Hours"
                                    SortExpression="EMP_HOURS">
                                    <HeaderStyle Width="50" VerticalAlign="Bottom" HorizontalAlign="Right" />
                                    <ItemStyle Width="50" VerticalAlign="Top" HorizontalAlign="Right" />
                                    <FooterStyle Width="50" VerticalAlign="Top" HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <telerik:RadNumericTextBox ID="RadNumericTextBoxHours" runat="server" AllowOutOfRangeAutoCorrect="true"
                                            MaxValue="24" MinValue="0" Width="40" Style="text-align: right;">
                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step=".25" />
                                            <NumberFormat DecimalDigits="2" />
                                        </telerik:RadNumericTextBox>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnApplyToDays" HeaderText="Day(s) to apply">
                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" Width="110" />
                                    <ItemStyle VerticalAlign="Top" HorizontalAlign="Left" Width="110" />
                                    <FooterStyle VerticalAlign="Top" HorizontalAlign="Left" Width="110" />
                                    <ItemTemplate>
                                        <asp:CheckBoxList ID="CheckBoxListDays" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CheckBoxListDays_SelectedIndexChanged" 
                                            RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Table">
                                            <asp:ListItem Text="Sun" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="Mon" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Tue" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Wed" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Thu" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Fri" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Sat" Value="6"></asp:ListItem>
                                        </asp:CheckBoxList>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnSave">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <HeaderTemplate>
                                        <asp:ImageButton ID="ImageButtonSaveAll" runat="server" SkinID="ImageButtonSaveAll"
                                            ToolTip="Click to save all rows" CommandName="SaveAll" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <div id="DivSave" runat="server" class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonSave" runat="server" SkinID="ImageButtonSaveWhite"
                                                ToolTip="Click to save this row" CommandName="SaveRow" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div class="icon-background background-color-delete">
                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddToTimesheet" Visible="false">
                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                    <ItemStyle CssClass="radgrid-icon-column" />
                                    <FooterStyle CssClass="radgrid-icon-column" />
                                    <ItemTemplate>
                                        <div id="DivAddToTimesheet" runat="server" class="icon-background background-color-sidebar">
                                            <asp:ImageButton ID="ImageButtonAddToTimesheet" runat="server" SkinID="ImageButtonNewWhite"
                                                ToolTip="Click to add this row to current Timesheet" CommandName="AddToTimesheet" />
                                        </div>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <RowIndicatorColumn>
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn>
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                        </MasterTableView>
                        <ClientSettings>
                        </ClientSettings>
                    </telerik:RadGrid>
                </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="ViewEmployeeTimeStaging" runat="server">
                <div ng-app="webvantageApp">
                    <div id="content" ng-controller="timeSheetCopyLookupController">
                        <table border="0" cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td align="center">
                                    <span>Hold down the mouse button and drag to select multiple rows.</span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <telerik:RadGrid ID="RadGridTimesheetStaging" runat="server" InsertItemDisplay="Top" AllowMultiRowSelection="true" AllowAutomaticInserts="False"
                                        AllowSorting="true" EnableHeaderContextMenu="true" EnableEmbeddedSkins="True"
                                        AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                                        GridLines="None" GroupingSettings-GroupByFieldsSeparator="&nbsp;&nbsp;|&nbsp;&nbsp;"
                                        AllowPaging="True" PageSize="10" ShowFooter="True">
                                        <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                                        <StatusBarSettings LoadingText="Loading Timesheet" ReadyText="Timesheet Loaded." />
                                        <ClientSettings AllowColumnsReorder="False" EnablePostBackOnRowClick="False">
                                            <Selecting AllowRowSelect="True" />
                                            <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" />
                                        </ClientSettings>
                                        <MasterTableView DataKeyNames="ID, Hours, StartDate, FunctionCode, DepartmentCode" AllowMultiColumnSorting="true" EnableLinqGrouping="false">
                                            <Columns>
                                                <telerik:GridClientSelectColumn UniqueName="ColumnClientSelect">
                                                    <HeaderStyle HorizontalAlign="center" />
                                                    <ItemStyle HorizontalAlign="center" />
                                                </telerik:GridClientSelectColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnClient" HeaderText="Client"
                                                    SortExpression="ClientCode" ShowSortIcon="true">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_ClientCode" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("ClientCode") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDivision" HeaderText="Division"
                                                    SortExpression="DivisionCode" ShowSortIcon="true">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_DivisionCode" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("DivisionCode") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProduct" HeaderText="Product"
                                                    SortExpression="ProductCode">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_ProductCode" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("ProductCode") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobNumber" HeaderText="Job" HeaderAbbr="FIXED" DataField="JobNumber" SortExpression="JobNumber" ItemStyle-CssClass="nomaxwidth" HeaderStyle-CssClass="nomaxwidth">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemStyle />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_JobCode" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("JobNumber") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobComponentNumber" HeaderText="Component" DataField="JobComponentNbr" HeaderAbbr="FIXED" SortExpression="JobComponentNumber">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_ComponentCode" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("JobComponentNumber") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderAbbr="FIXED" SortExpression="FunctionCode" HeaderText="Func/Cat" UniqueName="GridTemplateColumnFunctionCategory">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_FunctionCategory" CssClass="RequiredInput" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn DataField="ProductCategory" HeaderStyle-HorizontalAlign="Center" SortExpression="ProductCategoryCode"
                                                    UniqueName="GridBoundColumnProductCategory" HeaderText="Prod Cat">
                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                                    <ItemTemplate>
                                                        <div>
                                                            <asp:TextBox ID="TextBox_ProductCategory" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" Text='<%# Eval("ProductCategoryCode") %>'></asp:TextBox>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDepartment" HeaderText="Department"
                                                    SortExpression="DepartmentName">
                                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" Width="150" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                                                    <ItemTemplate>
                                                        <telerik:RadComboBox ID="DropDept" runat="server" InputCssClass="no-border">
                                                        </telerik:RadComboBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnStartDate" HeaderText="Date"
                                                    SortExpression="StartDate">
                                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left"/>
                                                    <ItemTemplate>
                                                        <div>
                                                            <telerik:RadDatePicker ID="RadDatePickerItemTemplate_StartDate" runat="server" SkinID="RadDatePickerStandard">
                                                                <DateInput ID="DateInput1" runat="server" DateFormat="d" EmptyMessage="Date" CssClass="RequiredInput">
                                                                    <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                                                                </DateInput>
                                                                <Calendar ID="CalendarDueDate" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                                                                    <SpecialDays>
                                                                        <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="radcalendar-today">
                                                                        </telerik:RadCalendarDay>
                                                                    </SpecialDays>
                                                                </Calendar>
                                                            </telerik:RadDatePicker>
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnHours" HeaderText="Hours"
                                                    SortExpression="Hours">
                                                    <HeaderStyle VerticalAlign="Bottom" HorizontalAlign="Left" Width="150" />
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                                                    <FooterStyle VerticalAlign="Middle" HorizontalAlign="Left" Width="150" />
                                                    <ItemTemplate>
                                                        <telerik:RadNumericTextBox ID="RadNumericTextBoxHours" runat="server" AllowOutOfRangeAutoCorrect="true"
                                                            MaxValue="24" MinValue="0" Width="40" Style="text-align: right;">
                                                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" Step=".25" />
                                                            <NumberFormat DecimalDigits="2" />
                                                        </telerik:RadNumericTextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnComment" HeaderText="Comment"
                                                    SortExpression="Comments">
                                                    <HeaderStyle CssClass="radgrid-textarea-column" />
                                                    <ItemStyle CssClass="radgrid-textarea-column" />
                                                    <FooterStyle CssClass="radgrid-textarea-column" />
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="TextBoxDefaultComment" runat="server" Text='<%#Eval("Comments")%>' TextMode="multiLine" CssClass="radgrid-textarea" SkinID="TextBoxStandard"></asp:TextBox>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDelete">
                                                    <HeaderStyle CssClass="radgrid-icon-column" />
                                                    <ItemStyle CssClass="radgrid-icon-column" />
                                                    <FooterStyle CssClass="radgrid-icon-column" />
                                                    <ItemTemplate>
                                                        <div class="icon-background background-color-delete">
                                                            <asp:ImageButton ID="ImageButtonDelete" runat="server" SkinID="ImageButtonDeleteWhite"
                                                                ToolTip="Click to delete this row" CommandName="DeleteRow" />
                                                        </div>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                            </Columns>
                                            <ExpandCollapseColumn Resizable="False" Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </ExpandCollapseColumn>
                                            <RowIndicatorColumn Visible="False">
                                                <HeaderStyle Width="20px" />
                                            </RowIndicatorColumn>
                                            <NoRecordsTemplate>
                                                No timesheet records for the selected week.
                                            </NoRecordsTemplate>
                                        </MasterTableView>
                                    </telerik:RadGrid>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    <script type="text/javascript">
        (function () {
            $('body')                
                .on('dblclick', 'input[adv-lookup]', function () {
                    var lookuptype = $(this).attr('adv-lookup');
                    if ($(this).is(":enabled")) {
                        getCurrentScope($(this)).openFilterDialog($(this));
                    }
                })
                .on('change', 'input[adv-lookup]', function () {
                    var currentScope = getCurrentScope($(this))
                    var newVal = null;
                    var lookupType = $(this).attr('adv-lookup');
                    var jobComponent = {};
                    newVal = currentScope.getInputValue(lookupType);
                    if (lookupType === 'Client' || lookupType === 'Division' || lookupType === 'Product' || lookupType === 'Job' || lookupType === 'JobComponent') {
                        JobComponent = currentScope.getSearchCriteria().JobComponent
                        if (lookupType === 'Client') {
                            JobComponent.ClientName = null;
                            JobComponent.DivisionCode = null;
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Division') {
                            JobComponent.DivisionName = null;
                            JobComponent.ProductCode = null;
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Product') {
                            JobComponent.ProductName = null;
                            JobComponent.JobNumber = null;
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'Job') {
                            JobComponent.JobDescription = null;
                            JobComponent.JobComponentNumber = null;
                            JobComponent.JobComponentDescription = null;
                        } else if (lookupType === 'JobComponent') {
                            JobComponent.JobComponentDescription = null;
                        }
                        currentScope.jobComponentValuesChanged(JobComponent, newVal);
                    }
                    if (lookupType === 'Function') {
                        currentScope.functionValuesChanged(currentScope.getSearchCriteria().Function, newVal);
                    }
                    if (lookupType === 'GeneralLedgerAccount') {
                        currentScope.glAccountValuesChanged(currentScope.getSearchCriteria().GeneralLedgerAccount, newVal);
                    }
                    if (lookupType === 'Employee') {
                        currentScope.employeeValuesChanged(currentScope.getSearchCriteria().Employee, newVal);
                    }
                    if (lookupType === 'Vendor') {
                        currentScope.vendorValuesChanged(currentScope.getSearchCriteria().Vendor, newVal);
                    }
                    if (lookupType === 'VendorContact') {
                        currentScope.vendorContactValuesChanged(currentScope.getSearchCriteria().VendorContact, newVal);
                    }
                })
                .on('focus', 'input[adv-calc]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                })
                .on('focus', '.RadGrid input[adv-lookup]', function () {
                    getCurrentScope($(this)).parentRow = $(this).closest('tr');
                });
        })();
        function getCurrentScope(element) {
            return angular.element(element).scope();
        }
    </script>
</asp:Content>
