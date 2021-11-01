<%@ Page Title="Timesheet" Language="vb" AutoEventWireup="false" MasterPageFile="~/ChildPage.Master"
    CodeBehind="Timesheet.aspx.vb" Inherits="Webvantage.TimesheetPage" %>

<%@ Register Src="UnityUC.ascx" TagName="UnityContextMenu" TagPrefix="custom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="server">
    <script type="text/javascript" src="Jscripts/Timesheet.js"></script>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript">

            function stopRKey(evt) {
                var evt = (evt) ? evt : ((event) ? event : null);
                var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
                if ((evt.keyCode == 13) && (node.type == "text")) {
                    return false;
                    //evt.keyCode = 9;
                }
            }

            document.onkeypress = stopRKey;

            function deleteTimesheetRows() {
                var checkedRows = $(".rgSelectedRow");
                if (checkedRows.length == 0) {
                    ShowMessage("Please select a timesheet(s) to delete.");
                    // e.preventDefault();
                    return false;
                }

                if (confirm("Are you sure you want to delete the selected row(s)?") == false) {
                    return false;
                }

                return true;

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

                //$("input.timesheet-day-hours-textbox").kendoNumericTextBox({ min: -24, max: 24, step: 0.5 });
                //$("input.timesheet-day-hours-textbox").focus(function() {
                //    var input = $(this);
                //    setTimeout(function() {
                //        input.select();
                //    });
                //});

            });      // end of document.ready

            function processLookupSelection(selectedItem) {
                console.log("Proccess")
                console.log(selectedItem)
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                currentScope.processLookupSelection(selectedItem);
                currentScope.$apply();
            }

            function validateNewTimesheetRow() {
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();

                currentScope.validateCurrentTimesheetEntry();
                return false;
            }


            function refreshGridTotals(callingElement) {
                //var clientCodeTextBox = $('#TextBox_ClientCode');
                //var currentScope = angular.element(clientCodeTextBox).scope();

                //currentScope.refreshGridTotals(callingElement);
                //currentScope.$apply();
            }

        </script>
    </telerik:RadScriptBlock>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <style type="text/css">
        .RadGrid_Bootstrap .rgHeader .timesheet-dialog-selector {
            color: -webkit-link;
            text-decoration: underline;
        }

        .rgHeader > a {
            white-space: nowrap;
        }

        input.k-formatted-value.timesheet-day-hours-textbox.k-input.rfdDecorated,
        input#sampleTextBox.timesheet-day-hours-textbox.k-input.rfdDecorated {
            width: 45px;
        }

        span.k-widget.k-numerictextbox.timesheet-day-hours-textbox span.k-numeric-wrap.k-state-default span.k-select span.k-link {
            display: none;
        }

        span.k-icon.k-i-arrow-n, span.k-icon.k-i-arrow-s {
            display: none;
        }



        div.timesheet-day-hours-textbox-container span.k-widget.k-numerictextbox.aspNetDisabled.timesheet-day-hours-textbox span.k-numeric-wrap.k-state-disabled span.k-select {
            display: none;
        }
    </style>
    <%--    
    THIS CSS IS MESSING UP THE TELERIK CSS
    <link rel="stylesheet" href="Content/kendo/2017.2.504/kendo.common.min.css" />
    <link rel="stylesheet" href="Content/kendo/2017.2.504/kendo.bootstrap.min.css" /> 
    <link href="Content/bootstrap.css" rel="stylesheet" />
   
    --%>
    <script type="text/javascript" src="Scripts/bootstrap.js"></script>
    <script type="text/javascript" src="Scripts/angular.min.js"></script>
    <script type="text/javascript" src="Scripts/angular-ui/ui-bootstrap-tpls.min.js"></script>
    <script type="text/javascript" src="Scripts/kendo/current/kendo.all.min.js"></script>
    <script type="text/javascript" src="app/js/app.js"></script>
    <script type="text/javascript" src="app/js/services.js"></script>
    <script type="text/javascript" src="app/js/controllers/timeSheetLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/functionCategoryLookupModal.js"></script>
    <script type="text/javascript" src="app/js/controllers/purchaseOrderLookup.js"></script>
    <script type="text/javascript" src="app/js/controllers/kendoGridLookupModal.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {

            //$('a[adv-lookup]').on('click', function (e) {
            //    var currentScope = getCurrentScope($(this));
            //    var type = $(this).attr('adv-lookup');
            //    currentScope.open(type);
            //    e.preventDefault();
            //});

            $('#txtEmpCode').on('dblclick', function () {
                var currentScope = getCurrentScope($(this));
                currentScope.open('Employee');
            });


            $('#txtEmpCode').change(function () {
                //updateEmployeeFunction();
            });

            $('#txtEmpCode').keyup(function () {
                //updateEmployeeFunction();
            });

            $('#TextBox_Assignment').change(function () {
                //updateEmployeeFunction();
                console.log($('#TextBox_Assignment').val())
            });
            $('#TextBox_Assignment').keyup(function () {
                //updateEmployeeFunction();
                console.log($('#TextBox_Assignment').val())
            });
            $('#TextBox_AlertSubject').change(function () {
                //updateEmployeeFunction();
                console.log($('#TextBox_Assignment').val())
            });
            $('#TextBox_AlertSubject').keyup(function () {
                //updateEmployeeFunction();
                console.log($('#TextBox_Assignment').val())
            });

            function getCurrentScope(element) {
                return angular.element(element).scope();
            };

            function updateEmployeeFunction() {
                var employeeCode = $('#txtEmpCode').val();
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                if (currentScope && employeeCode && clientCodeTextBox) {
                    currentScope.EmployeeCode = employeeCode;
                    currentScope.getEmployeeDefaultFunction();
                }
            }
            updateEmployeeFunction();
            //setTimeout(function () { $('#TextBox_JobCode').focus(); }, 250);
        });

        function cancelNewTimesheetRow() {
            var clientCodeTextBox = $('#TextBox_ClientCode');
            var employeeCode = $('#txtEmpCode').val();
            var currentScope = angular.element(clientCodeTextBox).scope();

            currentScope.EmployeeCode = employeeCode;
            currentScope.getEmployeeDefaultFunction();
            currentScope.ClientCode = '';
            currentScope.SundayComments = '';
            currentScope.MondayComments = '';
            currentScope.TuesdayComments = '';
            currentScope.WednesdayComments = '';
            currentScope.ThursdayComments = '';
            currentScope.FridayComments = '';
            currentScope.SaturdayComments = '';

            currentScope.SundayHours = 0;
            currentScope.MondayHours = 0;
            currentScope.TuesdayHours = 0;
            currentScope.WednesdayHours = 0;
            currentScope.ThursdayHours = 0;
            currentScope.FridayHours = 0;
            currentScope.SaturdayHours = 0;

            currentScope.$apply();

            $("input.timesheet-day-hours-textbox").kendoNumericTextBox().value = 0;

            currentScope.getTimesheetSettings();
            setTimeout(function () { $('#TextBox_JobCode').focus(); }, 250);

        };

        function showTimesheetDetails(url) {
            var browserWindow = GetRadWindow().BrowserWindow;
            setTimeout(function () {
                browserWindow.radopen(url, "Timesheet Details", 960, 610);
            }, 0)

            return false;
        };

        function showFakeSibling(callingElement) {
            var title = $(callingElement).attr('title');
            $(callingElement).parent().next().show();
            $(callingElement).parent().hide();
            if (title == 'Stop Stopwatch') {
                $($(callingElement).parent().next()).addClass('standard-red');
                $($(callingElement).parent().next().children()[0]).attr('src', $(callingElement).attr('src'));
            }
        };

        function disableTimesheetButtons() {
            $('.icon-background').hide();
        };

        function SelectAllRows(checked) {
                    var radgrid = $find('<%= RadGridTimesheetNew.ClientID %>');
                    var masterTableView = radgrid.get_masterTableView()
                    var detailTables = radgrid.get_detailTables();
                    var allTables = new Array();

                    allTables = allTables.concat(detailTables);
                    allTables.splice(0, 0, masterTableView);

                    for (var t = 0; t < allTables.length; t++) {
                        if (checked == true) {
                            allTables[t].selectAllItems();
                        } else {
                            allTables[t].clearSelectedItems();
                        }
                    }
                    var HiddenFieldSelectAll = document.getElementById('<%= HiddenFieldSelectAll.ClientID%>');
                    if (checked == true) {
                        HiddenFieldSelectAll.value = '1';
                    } else {
                        HiddenFieldSelectAll.value = '0';
                    }
                }

        function processAurLookupToAngular(args) {
            if (args) {
                //console.log("processAurLookupToAngular TS", args)
                var clientCodeTextBox = $('#TextBox_ClientCode');
                var currentScope = angular.element(clientCodeTextBox).scope();
                if (currentScope) {
                    currentScope.suppressDefaultDivision = true;
                    currentScope.suppressDefaultProduct = true;
                    if (args.ClientCode) {
                        currentScope.ClientCode = args.ClientCode;
                    }
                    if (args.DivisionCode) {
                        currentScope.DivisionCode = args.DivisionCode;
                    }
                    if (args.ProductCode) {
                        currentScope.ProductCode = args.ProductCode;
                    }
                    if (args.JobNumber) {
                        currentScope.JobNumber = args.JobNumber;
                    }
                    if (args.JobComponentNumber) {
                        currentScope.JobComponentNumber = args.JobComponentNumber;
                    }
                    currentScope.$apply();
                    currentScope.getJobComponentDescription();
                }
            }
        }

    </script>

    <style type="text/css">
        .radgrid-icon-column {
            max-width: none !important;
        }

        .larger-font {
            font-size: larger;
        }
         textarea { 
            resize: both !important; 
        }
   </style>
    <div ng-app="webvantageApp">
        <div id="content" ng-controller="timeSheetLookupController">
            <telerik:RadScriptBlock ID="RadScriptBlock2" runat="server">

                <script type="text/javascript">
                    function RadToolbarTimesheetButtonsOnClientButtonClicking(sender, args) {
                        var commandName = args.get_item().get_commandName();

                        if (commandName == "Delete") {
                            ////args.set_cancel(!confirm('Are you sure you want to delete the selected row?'));
                            radToolBarConfirm(sender, args, "Are you sure you want to delete the selected row?");
                        }
                        else if (commandName == "deleteselected") {
                            var checkedRows = $(".rgSelectedRow");
                            if (checkedRows.length == 0) {
                                ShowMessage("Please select a timesheet(s) to delete.");
                                args.set_cancel(true);
                                return false;
                            }

                            if (confirm("Are you sure you want to delete the selected row(s)?") == false) {
                                args.set_cancel(true);
                                return false;
                            }
                        }
                        else if (commandName == "ColumnPreferences") {
                            RadGridTimesheetColumnHeaderMenu();
                            return false;
                        }
                        else if (commandName == "CloseWindow") {
                            window.close();
                            return false;
                        }
                        else if (commandName == "TimesheetSettings") {
                            OpenRadWindow("", "Maintenance_Timesheet.aspx?my=1", 0, 0, false);
                            return false;
                        }
                        else if (commandName == "Search") {
                            OpenRadWindow("", "Timesheet_Search.aspx", 0, 0, false);
                            return false;
                        }
                        else if (commandName == "NoPostBack") {
                            args.set_cancel(true);
                        }
                    }
                    function RadGridTimesheetColumnHeaderMenu(ev) {
                        var grid = $find("<%= RadGridTimesheetNew.ClientID %>");
                        grid.get_masterTableView().get_columns()[0].showHeaderMenu(ev, 30, 40);
                    }
                    function RadGridTimesheetNewOnMasterTableViewCreated() {
                        //alert("RadGridTimesheetNewOnMasterTableViewCreated")
                    }
                </script>
            </telerik:RadScriptBlock>
            <div >
                <telerik:RadToolBar ID="RadToolbarTimesheetButtons" runat="server" AutoPostBack="false" SingleClick="ToolBar"
                    OnClientButtonClicking="RadToolbarTimesheetButtonsOnClientButtonClicking" Width="100%">
                    <Items>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonAddNewCV" CommandName="addnewcv" Text="New Record (CV)" Value="addnewcv" ToolTip="Add a new record to the timesheet using Comment View" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton Value="RadToolBarButtonCopyFromTooltip" Text="Copy From" CommandName="NoPostBack">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton Value="RadToolBarButtonCopyToTooltip" Text="Copy To" CommandName="NoPostBack">
                        </telerik:RadToolBarButton>
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonSetApproval"
                            Text="Set Approval" Value="SetApproval" ToolTip="Submit/Un-submit time for Supervisor Approval" />
                        <telerik:RadToolBarButton IsSeparator="true" Value="RadToolBarButtonApprovalSeparator" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonPrint" SkinID="RadToolBarButtonPrint"
                            Text="Print" Value="print" ToolTip="Print this timesheet" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonSetting" SkinID="RadToolBarButtonSettings"
                            CommandName="TimesheetSettings" Text="Settings" Value="TimesheetSettings" ToolTip="Set your Timesheet preferences" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonSearch" SkinID="RadToolBarButtonFind"
                            Text="Search" Value="Search" ToolTip="Search" CommandName="Search" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonRefresh" SkinID="RadToolBarButtonRefresh" Value="refresh" ToolTip="Refresh the selected timesheet" />
                        <telerik:RadToolBarButton IsSeparator="true" />
                        <telerik:RadToolBarButton ID="RadToolbarButtonDelete" SkinID="RadToolBarButtonDelete" ToolTip="Delete the selected time sheet records" CommandName="deleteselected" Value="DeleteSelected" />

                    </Items>
                </telerik:RadToolBar>
            </div>
            <telerik:RadToolTip ID="RadToolTipCopyFromOptions" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="200" TargetControlID="RadToolBarButtonCopyFromTooltip">
                <div style="width: 275px; float: left; position: relative;">
                    <div style="font-size: larger;">
                        Copy from
                    </div>
                    <div>
                        <div style="padding: 11px 0px 0px 0px; display: none !important;">
                            <asp:Button ID="ButtonCopyFromMyTimesheets" runat="server" Text="My Other Timesheets" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonCopyFromMyProjects" runat="server" Text="My Projects" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonCopyFromMyTemplates" runat="server" Text="My Time Templates" ToolTip="" Width="250" />
                        </div>
                        <div style="padding: 6px 0px 0px 0px;">
                            <asp:Button ID="ButtonCopyFromTimesheetStaging" runat="server" Text="My Calendar" ToolTip="" Width="250" />
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>
            <telerik:RadToolTip ID="RadToolCopyTo" runat="server" SkinID="RadToolTipToolbarContentArea" Width="290" Height="480" TargetControlID="RadToolBarButtonCopyToTooltip">
                <div>
                    <div class="larger-font" style="width: 280px;">
                        Copy
                    </div>
                    <div style="margin: 10px 0px 0px 0px !important;">
                        <asp:RadioButtonList ID="RadioButtonListCopyType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Entire timesheet" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Selected rows" Value="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="DivCopyHours" runat="server" style="margin: 0px 0px 0px 0px !important;">
                        <asp:CheckBox ID="CheckBoxCopyWithHours" runat="server" Text="with hours" />
                    </div>
                    <div class="larger-font" style="margin: 0px 0px 0px 0px !important;">
                        to:
                    </div>
                    <div>
                        <div style="width: 275px; float: left; position: relative; display: none !important;">
                            <div>
                                <div style="padding: 0px 0px 0px 0px;">
                                    <asp:Button ID="ButtonCopyToCurrentWeek" runat="server" Text="This week" ToolTip="Copy the timesheet you are viewing right now to the current week" Width="252" />
                                </div>
                            </div>
                        </div>
                        <div style="width: 275px; float: left; position: relative;">
                            <div>
                                <div style="padding: 0px 0px 0px 0px;">
                                    <asp:Button ID="ButtonCopyToSelectedWeek" runat="server" Text="Selected week" ToolTip="Copy the timesheet you are viewing right now to the week selected in the calendar below this button" Width="250" />
                                </div>
                                <div style="padding: 10px 0px 0px 0px;">
                                    <telerik:RadCalendar ID="RadCalendarCopyToSelectedWeek" runat="server" Width="276" EnableKeyboardNavigation="true" EnableMultiSelect="false"
                                        ShowColumnHeaders="true" ShowDayCellToolTips="true" ShowRowHeaders="false">
                                        <FastNavigationSettings EnableTodayButtonSelection="true">
                                        </FastNavigationSettings>
                                    </telerik:RadCalendar>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </telerik:RadToolTip>
            <div >
            </div>
            <div class="more-info">
                <div id="DivEmployee" runat="server" style="display: inline-block;">
                    <div style="display: none;">
                        <asp:Literal ID="litEmpCode" runat="server" Text="Emp Code:"></asp:Literal>
                        <asp:LinkButton ID="lbtnEmpCode" runat="server" Text="Employee Code:" TabIndex="-1"></asp:LinkButton>
                    </div>
                    Employee Code:&nbsp;<asp:TextBox ID="txtEmpCode" runat="server" CssClass="RequiredInput" SkinID="TextBoxCodeSmall" ClientIDMode="Static" adv-lookup="Employee"></asp:TextBox>
                    <asp:ImageButton ID="imgbtnRefresh" runat="server" SkinID="ImageButtonRefresh" Visible="false" />
                    <asp:ImageButton ID="butEmpCodeLookup" runat="server" SkinID="ImageButtonFind" Visible="false" />
                </div>
                <div style="display: inline-block;">
                    Week of:&nbsp;
                    <telerik:RadDatePicker ID="RadDatePickerStartDate" runat="server" AutoPostBack="true" ClientIDMode="Static" SkinID="RadDatePickerStandard">
                        <DateInput DateFormat="d" EmptyMessage="Start Date">
                            <IncrementSettings InterceptArrowKeys="true" InterceptMouseWheel="true" />
                        </DateInput>
                        <Calendar ID="CalendarStartDate" ClientIDMode="Static" RangeMinDate="1900-01-01" runat="server" RenderMode="Classic">
                        </Calendar>
                    </telerik:RadDatePicker>
                    <telerik:RadComboBox ID="RadComboBoxDayToShow" runat="server" AutoPostBack="True" Width="135">
                    </telerik:RadComboBox>
                    <asp:ImageButton ID="ImageButtonPreviousWeek" runat="server" SkinID="ImageButtonPrevious" ToolTip="Previous"
                        AlternateText="Previous" />
                    <asp:ImageButton ID="ImageButtonCurrentWeek" runat="server" ImageUrl="~/Images/Icons/Grey/256/star.png" CssClass="icon-image"
                        TabIndex="-1" ImageAlign="AbsMiddle" ToolTip="Current" AlternateText="Current" />
                    <asp:ImageButton ID="ImageButtonNextWeek" runat="server" SkinID="ImageButtonNext" ToolTip="Next" AlternateText="Next" />
                    Group by:&nbsp;
                    <telerik:RadComboBox ID="DropGroupBy" runat="server" AutoPostBack="True" Width="215">
                    </telerik:RadComboBox>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldCurrentSelectedComment" runat="server" Value="" />
            <asp:HiddenField ID="HiddenFieldTimesheetIsMissingComments" runat="server" />
            <asp:HiddenField ID="HiddenField_PerformRowInsert" runat="server" />
            <div>
                <telerik:RadGrid ID="RadGridTimesheetNew" runat="server" InsertItemDisplay="Top" AllowMultiRowSelection="true" AllowAutomaticInserts="False"
                    AllowSorting="true" EnableHeaderContextMenu="true" EnableEmbeddedSkins="True"
                    AutoGenerateColumns="False" EnableAJAX="False" EnableAJAXLoadingTemplate="False"
                    GridLines="None" GroupingSettings-GroupByFieldsSeparator="&nbsp;&nbsp;|&nbsp;&nbsp;"
                    AllowPaging="True" PageSize="10" ShowFooter="True">
                    <PagerStyle Mode="NextPrevAndNumeric" AlwaysVisible="true" Position="Bottom"></PagerStyle>
                    <StatusBarSettings LoadingText="Loading Timesheet" ReadyText="Timesheet Loaded." />
                    <ClientSettings AllowColumnsReorder="False" EnablePostBackOnRowClick="False">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnColumnHidden="OnColumnHidden" OnColumnShown="OnColumnShown" OnMasterTableViewCreated="RadGridTimesheetNewOnMasterTableViewCreated" />
                    </ClientSettings>
                    <MasterTableView DataKeyNames="LineIdentifier, JobNumber, JobComponentNbr" AllowMultiColumnSorting="true" EnableLinqGrouping="false" EditMode="InPlace">
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="ColumnSelect" Visible="true">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="16px" />
                                <HeaderTemplate>
                                    <input id="CheckBoxSelectAllRows" type="checkbox" name="CheckBoxSelectAllRows" onclick="SelectAllRows(this.checked)" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnViewDetails" HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <ItemStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <FooterStyle CssClass="radgrid-icon-column" VerticalAlign="Middle" HorizontalAlign="Left" />
                                <HeaderTemplate>
                                    <asp:ImageButton ID="ImageButtonColumnPreferences" runat="server" ImageAlign="AbsMiddle" CssClass="column-prefs-icon"
                                        ImageUrl="~/Images/Icons/Grey/256/table_selection_column.png" ToolTip="Column Preferences" OnClientClick="RadGridTimesheetColumnHeaderMenu(event);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="RowDatakey" runat="server" Value='<%# Eval("LineIdentifier") %>' />
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonViewDetails" runat="server" CommandName="ViewDetails"
                                            ToolTip="View details" AlternateText="View details" SkinID="ImageButtonViewWhite" Visible="False" />
                                    </div>
                                    <asp:Image ID="ImageProcessControlWarning" runat="server" ToolTip='<%# Eval("NonEditMessage") %>'
                                        Visible="false" SkinID="ImageWarningProcessControl" />
                                    <asp:HiddenField ID="HiddenFieldNonEditMessage" runat="server" Value='<%# Eval("NonEditMessage") %>' />
                                </ItemTemplate>
                                <EditItemTemplate></EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnClient" HeaderText="Client Code"
                                SortExpression="ClientCode" ShowSortIcon="true">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ClientCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="ClientCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false;" ng-dblclick="open('Client')"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelClient" runat="server" Text='<%# Eval("ClientCode") %>' ToolTip='<%# "Client:  " & Eval("ClientName") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDivision" HeaderText="Division Code"
                                SortExpression="DivisionCode" ShowSortIcon="true">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_DivisionCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="DivisionCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false; getDefaultProductCode();" ng-dblclick="open('Division')"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDivision" runat="server" Text='<%# Eval("DivisionCode") %>' ToolTip='<%# "Division:  " & Eval("DivisionName") %>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProduct" HeaderText="Product Code"
                                SortExpression="ProductCode">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ProductCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="ProductCode" ng-keyup="suppressDefaultDivision = false; suppressDefaultProduct = false; searchProductName();" ng-dblclick="open('Product')"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProduct" runat="server" Text='<%# Eval("ProductCode") %>' ToolTip='<%# "Product:  " & Eval("ProductDescription") %>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnClientDesc"
                                SortExpression="ClientName" HeaderText="Client Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Client:  {{ClientName}}">{{ClientName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelClientNameDisplay" runat="server" Text='<%# Eval("ClientName")%>' ToolTip='<%# "Client:  " & Eval("ClientName")%>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnDivisionDesc"
                                SortExpression="DivisionName" HeaderText="Division Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Division:  {{DivisionName}}">{{DivisionName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDivisionNameDisplay" runat="server" Text='<%# Eval("DivisionName")%>' ToolTip='<%# "Division:  " & Eval("DivisionName") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnProductDesc"
                                SortExpression="ProductDescription" HeaderText="Product Name">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <EditItemTemplate>
                                    <div>
                                        <span title="Product:  {{ProductName}}">{{ProductName}}</span>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProductDescriptionDisplay" runat="server" Text='<%# Eval("ProductDescription")%>' ToolTip='<%# "Product:  " & Eval("ProductDescription") %>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobNumber" HeaderText="Job" HeaderAbbr="FIXED" DataField="JobNumber" SortExpression="JobNumber" ItemStyle-CssClass="nomaxwidth" HeaderStyle-CssClass="nomaxwidth">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_JobCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="JobNumber" ng-keyup="getDefaultJobComponentNumber(true)" ng-dblclick="open('Job')"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="LabelJob" runat="server" Text='<%# Eval("JobNumber")%>' Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobComponentNumber" HeaderText="Component" DataField="JobComponentNbr" HeaderAbbr="FIXED" SortExpression="JobComponentNbr">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ComponentCode" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="JobComponentNumber" ng-keyup="getJobComponentDescription()" ng-dblclick="open('JobComponent')"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelComponent" runat="server" Text='<%# Eval("JobComponentNbr")%>' ToolTip='<%# "Component:  " & Eval("JobCompDesc")%>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobDescription"
                                SortExpression="JobDesc" HeaderText="Job Desc">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <EditItemTemplate>
                                    <span title="{{JobDescription}}">{{JobDescription}}
                                    </span>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelJobDescriptionDisplay" runat="server" Text='<%# Eval("JobDesc")%>' ToolTip='<%# Eval("JobDesc")%>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnJobComponentDescription"
                                SortExpression="JobCompDesc" HeaderText="Component Desc">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <EditItemTemplate>
                                    <span title="{{JobComponentDescription}}">{{JobComponentDescription}}
                                    </span>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelJobComponentDescriptionDisplay" runat="server" Text='<%# Eval("JobCompDesc")%>' ToolTip='<%# Eval("JobCompDesc")%>'
                                        Visible="True">                                            
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="ProductCategory" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnProductCategory" HeaderText="Prod Cat">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_ProductCategory" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ng-model="ProductCategory"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelProductCategoryDesc" runat="server" Text='<%# Eval("ProductCategory") %>' ToolTip='<%# Eval("ProductCategory")%>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="FuncCat" HeaderStyle-HorizontalAlign="Center" HeaderAbbr="FIXED" SortExpression="FuncCat" HeaderText="Func/Cat" UniqueName="GridTemplateColumnFunctionCategory">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_FunctionCategory" CssClass="RequiredInput" ClientIDMode="Static" runat="server" ng-model="FunctionCategory" ng-keyup="refreshEmployeeFunctionCategory()" ng-dblclick="open('FunctionCategory')" TabIndex="0" SkinID="TextBoxCodeSmall"></asp:TextBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelFuncCat" runat="server" Text='<%# Eval("FuncCat") %>' ToolTip='<%# Eval("FuncCatDesc") %>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="FuncCatDesc" HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnFunctionCategoryDesc" HeaderText="Func/Cat Desc">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="LabelFuncCatDesc" runat="server" Text='<%# Eval("FuncCatDesc") %>' ToolTip='<%# Eval("FuncCatDesc")%>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div>{{FunctionCategoryDescription}}</div>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn DataField="AlertSubject" HeaderStyle-HorizontalAlign="Center"
                                 UniqueName="GridBoundColumnAlertSubject" HeaderText="Assignment">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle />
                                <ItemTemplate>
                                    <asp:Label ID="LabelAlertSubject" runat="server" Text='<%# Eval("AlertSubject") %>' ToolTip='<%# Eval("AlertSubject")%>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <div>
                                        <asp:TextBox ID="TextBox_Assignment" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ToolTip="Double click to select assignment"
                                            ng-model="AlertID" ng-dblclick="open('Assignment')"></asp:TextBox>
                                        <div style="display: none;">
                                            <asp:TextBox ID="TextBox_AlertSubject" ClientIDMode="Static" runat="server" TabIndex="0" SkinID="TextBoxCodeSmall" ToolTip="Double click to select assignment" Text='{{AlertSubject}}'
                                                ng-model="AlertSubject" ng-dblclick="open('Assignment')"></asp:TextBox>
                                        </div>
                                    </div>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="ProductCategory" Visible="False" HeaderText="Prod Cat" HeaderAbbr="FIXED"
                                SortExpression="ProductCategory" UniqueName="GridBoundColumnProductCategorySortable">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn DataField="Dept" SortExpression="Dept" HeaderText='Dept' HeaderStyle-HorizontalAlign="Center"
                                UniqueName="GridBoundColumnDepartment">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="30" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30" />
                                <EditItemTemplate>
                                    <div>
                                        <telerik:RadComboBox ID="ComboBox_Department" runat="server" TabIndex="0" ClientIDMode="Static" RenderMode="Native" >
                                        </telerik:RadComboBox>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="LabelDept" runat="server" Text='<%# Eval("Dept")%>'
                                        Visible="True">
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" UniqueName="GridBoundColumnQvaProgress" ReadOnly="True" HeaderText="Progress">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" Width="90" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="90" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="90" Font-Bold="true" />
                                <ItemTemplate>
                                    <div runat="server" id="DivRadProgressBarQvaProgress" style="margin-top: 4px;">
                                        <asp:Literal ID="LiteralQvaProgress" runat="server"></asp:Literal>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" UniqueName="GridBoundColumnHoursRemain" ReadOnly="True" HeaderText="Hours<br/>Remaining">
                                <HeaderStyle HorizontalAlign="Right" VerticalAlign="Bottom" Width="40" />
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="40" />
                                <FooterStyle HorizontalAlign="Right" VerticalAlign="Middle" Width="40" Font-Bold="False" />
                                <ItemTemplate>
                                    <asp:Label ID="LabelHoursRemain" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="LabelHoursRemainFooter" runat="server" Text=""></asp:Label>
                                </FooterTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnSunday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelSunApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonSunApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelSunHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageSunPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldSunDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateSunday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="SundayHours" ID="TextBox_NewItemSunday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && SundayHours != 0}]" ID="TextBox_SundayComments" ClientIDMode="Static" TextMode="MultiLine" ng-model="SundayComments" />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="SunDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtSunday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="SunDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="SunImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="SunDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="SunStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Sun" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="SunTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnMonday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelMonApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonMonApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelMonHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageMonPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldMonDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateMonday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="MondayHours" ID="TextBox_NewItemMonday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && MondayHours != 0}]" ID="TextBox_MondayComments" ClientIDMode="Static" TextMode="MultiLine" ng-model="MondayComments" ng-enabled="MondayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="MonDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtMonday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="MonDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="MonStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Mon" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="MonDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="MonImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="MonTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine" Columns="40" Height="20"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnTuesday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelTueApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonTueApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelTueHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageTuePostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldTueDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateTuesday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="TuesdayHours" ID="TextBox_NewItemTuesday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && TuesdayHours != 0}]" ID="TextBox_TuesdayComments" TextMode="MultiLine" ClientIDMode="Static" ng-model="TuesdayComments" ng-enabled="TuesdayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="TueDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtTuesday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="TueDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="TueImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="TueDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="TueStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Tue" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="TueTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnWednesday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelWedApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonWedApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelWedHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageWedPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldWedDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateWednesday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="WednesdayHours" ID="TextBox_NewItemWednesday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && WednesdayHours != 0}]" ID="TextBox_WednesdayComments" ClientIDMode="Static" TextMode="MultiLine" ng-model="WednesdayComments" ng-enabled="WednesdayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="WedDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtWednesday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="WedDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="WedImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="WedDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="WedStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Wed" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="WedTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnThursday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelThuApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonThuApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelThuHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageThuPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldThuDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateThursday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="ThursdayHours" ID="TextBox_NewItemThursday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && ThursdayHours != 0}]" ID="TextBox_ThursdayComments" ClientIDMode="Static" TextMode="MultiLine" ng-model="ThursdayComments" ng-enabled="ThursdayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="ThuDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtThursday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="ThuDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ThuImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="ThuDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="ThuStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Thu" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="ThuTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnFriday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelFriApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonFriApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelFriHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageFriPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldFriDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateFriday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="FridayHours" ID="TextBox_NewItemFriday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && FridayHours != 0}]" ID="TextBox_FridayComments" TextMode="MultiLine" ClientIDMode="Static" ng-model="FridayComments" ng-enabled="FridayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="FriDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtFriday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="FriDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="FriImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="FriDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="FriStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Fri" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="FriTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridBoundColumnSaturday" HeaderAbbr="FIXED">
                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Bold="true" />
                                <HeaderTemplate>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelSatApproval" runat="server" Text=""></asp:Label>
                                        <asp:ImageButton ID="ImageButtonSatApprovalComment" runat="server" SkinID="ImageButtonComment" />
                                    </div>
                                    <div style="display: block; white-space: nowrap;">
                                        <asp:Label ID="LabelSatHeader" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="ImageSatPostPeriodClosed" runat="server" ToolTip="Posting period closed for this day."
                                            Visible="false" SkinID="ImageWarningPostPeriodClosed" />
                                    </div>
                                    <asp:HiddenField ID="HiddenFieldSatDate" runat="server" />
                                </HeaderTemplate>
                                <EditItemTemplate>
                                    <div id="DivEditItemTemplateSaturday" runat="server" class="timesheet-day-edit-item-template-container">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox runat="server" CssClass="timesheet-day-hours-textbox" ClientIDMode="Static" ng-model="SaturdayHours" ID="TextBox_NewItemSaturday" Text="0.00" onfocus="this.select();return false;" />
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container" ng-show="showCommentBoxes()">
                                            <asp:TextBox runat="server" CssClass="timesheet-day-comments-textbox" ng-class="[{RequiredInput: TimesheetSettings.CommentsRequiredForJob && SaturdayHours != 0}]" ID="TextBox_SaturdayComments" TextMode="MultiLine" ClientIDMode="Static" ng-model="SaturdayComments" ng-enabled="SaturdayActive"  />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="SatDatakey" runat="server" Value="" />
                                    <div style="display: block; float: left; white-space: nowrap;">
                                        <div class="timesheet-day-main-container">
                                            <div class="timesheet-day-hours-textbox-container">
                                                <asp:TextBox ID="TxtSaturday" runat="server" onfocus="this.select();return false;" 
                                                    CssClass="timesheet-day-hours-textbox"></asp:TextBox>
                                            </div>
                                            <div class="timesheet-day-buttons-container">
                                                <div class="timesheet-day-grid-button">
                                                    <div id="SatDivComment" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="SatImageButtonComment" runat="server" SkinID="ImageButtonCommentWhite" />
                                                    </div>
                                                </div>
                                                <div class="timesheet-day-grid-button">
                                                    <div id="SatDivStopwatch" runat="server" class="icon-background background-color-sidebar">
                                                        <asp:ImageButton ID="SatStopWatchImageButton" runat="server"
                                                            CommandName="StopStopwatch" CommandArgument="Sat" ImageUrl="~/Images/Icons/White/256/stopwatch2.png" CssClass="icon-image" ToolTip="Stop Stopwatch" OnClientClick="showFakeSibling(this);" />
                                                    </div>
                                                    <div class="icon-background background-color-sidebar" style="display: none;">
                                                        <img src="Images/Icons/White/256/stopwatch.png" class="icon-image" title="Start Stopwatch" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="timesheet-day-comments-textbox-container">
                                            <asp:TextBox ID="SatTextBoxComment" runat="server" CssClass="timesheet-day-comments-textbox" TextMode="multiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Total" UniqueName="colTotalHours" HeaderAbbr="FIXED"
                                SortExpression="TotalHours">
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="true" />
                                <EditItemTemplate>
                                    <div style="width: 100px;">
                                        <div class="icon-background background-color-sidebar" style="display: inline-block;" id="newRowButtons_Add">
                                            <asp:ImageButton ID="ImageButton_SaveNewRow" runat="server" AlternateText="Add new row"
                                                ToolTip="Add new row" ImageAlign="AbsMiddle" SkinID="ImageButtonAddWhite" TabIndex="0" ClientIDMode="Static" CommandName="NewRowCommitInsert" OnClientClick="return validateNewTimesheetRow()" />
                                        </div>
                                        <div class="icon-background background-color-sidebar" style="display: inline-block;">
                                            <asp:ImageButton ID="ImageButton_CancelNewRow" runat="server" AlternateText="Clear add new"
                                                ToolTip="Clear add new" SkinID="ImageButtonCancelWhite" TabIndex="0" CommandName="NewRowCancel" OnClientClick="cancelNewTimesheetRow(); return false;" />
                                        </div>
                                    </div>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalHours" runat="server" Text='<%# Microsoft.VisualBasic.FormatNumber(Eval("TotalHours"),2) %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="CommentsView">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:LinkButton ID="LinkButtonCommentsView" runat="server" CssClass="icon-text-two" CommandName="CommentsView" ToolTip="Show comments view">CV</asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="Delete">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div id="DivDelete" runat="server" class="icon-background background-color-delete">
                                        <asp:ImageButton ID="ImageButtonDelete" runat="server" CommandName="RowDelete" AlternateText="Delete row"
                                            ToolTip="Delete row" SkinID="ImageButtonDeleteWhite" />
                                        <asp:HiddenField ID="HiddenField_RowIsDeleteable" runat="server" />
                                    </div>
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="GridTemplateColumnAddToTemplate" Visible="False"
                                HeaderAbbr="FIXED">
                                <HeaderStyle CssClass="radgrid-icon-column" />
                                <ItemStyle CssClass="radgrid-icon-column" />
                                <FooterStyle CssClass="radgrid-icon-column" />
                                <ItemTemplate>
                                    <div class="icon-background background-color-sidebar">
                                        <asp:ImageButton ID="ImageButtonAddToTemplate" runat="server" SkinID="ImageButtonNewWhite"
                                            ToolTip="Add to my Timesheet Template" CommandName="AddToTimesheetTemplate" />
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
            </div>
            <style>
                .hidden-ts-go {
                    clear: both;
                    position: relative;
                    display: block;
                    width: 100%; 
                    height: 80px; 
                    cursor: pointer;
                    -moz-transition: all .2s ease-in;
                    -o-transition: all .2s ease-in;
                    -webkit-transition: all .2s ease-in;
                    transition: all .2s ease-in;
                }
                .hidden-ts-go:hover {
                    background-color: #fce4ec;
                }
            </style>
            <div class="hidden-ts-go" onclick="window.location = 'Employee/Timesheet'" title="CLICK TO GO TO NEW TIMESHEET!">
            </div>
            <custom:UnityContextMenu ID="MyUnityContextMenu" runat="server" />
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldSelectAll" runat="server" Value="0" />

</asp:Content>
