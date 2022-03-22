@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel
@Code       ViewData("Title") = "Timesheet"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = False
End Code
<script>
</script>
<link href="~/CSS/timesheet.mvc.min.css" rel="stylesheet" />
<div style="display: block !important; margin: 0 auto !important; min-width: 1020px;">
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable"
         style="width: 100%; background-color: #E5E5E5; padding: 5px 0px 8px 0px; border-bottom: 1px solid #CCC;
         box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px auto; overflow: hidden; height: 52px; ">
        <div style="height:50px; width: 100%;">
            <div style="display: inline-block; width: 50%; vertical-align: middle; padding: 10px 0px 0px 0px;">
                <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px !important;">
                    <li style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-add-new" onclick="openNewEntryDialog()" title="Add time"><span class='glyphicon wvi wvi-navigate-plus'></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button id="saveButton" class="k-button wv-icon-button wv-save" onclick="saveClick()" title="Save changes"><span class='wvi wvi-floppy-disk'></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button id="cancelButton" class="wv-icon-button k-button wv-cancel k-state-disabled" onclick="cancelClick()" title="Cancel"><span class='wvi wvi-sign-forbidden'></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button id="deleteButton" class="k-button wv-icon-button wv-cancel k-state-disabled" onclick="deleteClick()" title="Delete selected rows"><span class='wvi wvi-delete'></span></button>
                    </li>
                    <li id="copyToListItem" style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-neutral " onclick="copyToOptionsClick()" style="width: 80px !important;" title="Copy this timesheet to another"><span style="font-size: 12px;">Copy To</span></button>
                    </li>
                    <li id="copyFromListItem" style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-neutral " onclick="copyFromOptionsClick()" style="width: 80px !important;" title="Copy to this timesheet"><span style="font-size: 12px;">Copy From</span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-neutral" onclick="bookmark()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-neutral" onclick="refreshTimesheet()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-neutral" onclick="openPrintSettingsPage()"><span class='wvi wvi-printer2' title="Print timesheet"></span></button>
                    </li>
                    <li style="padding-right: 1px !important;">
                        <button class="k-button wv-icon-button wv-settings" onclick="settingsClick()"><span class='glyphicon glyphicon-cog' title="Settings" style="font-size: 18px;"></span></button>
                    </li>
                </ul>
            </div>
            <div style="display: inline-block; width:50%; text-align: right; padding: 9px 8px 0px 0px;">
                <div id="datePickerCell" style="display: inline-block; width: 200px; border: 0px solid green;">
                    <div style="display: inline-block;">
                        <span style="margin-right: 4px; font-weight:bold;">Week of</span>
                    </div>
                    <div style="display: inline-block;">
                        <span id="WeekOfLabel" style="margin-right: 4px; font-weight:bold;width: 130px; display: none;"></span>
                        <div id="DatePickerContainer" style="vertical-align:middle !important; height: 53px;">
                            @(Html.Kendo.DatePickerFor(Function(Model) Model.StartDate).Format("d").Name("DatePicker").Events(Sub(evt)
                                                                                                                                  evt.Change("navigateToDate")
                                                                                                                              End Sub).HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                        </div>
                    </div>
                </div>
                <div style="display: inline-block; width: 100px; vertical-align:middle !important; border: 0px solid hotpink;">
                    @Html.Kendo().ButtonGroup().Name("Navigator").Selection("single").Items(Sub(i)
                                                                                                i.Add().Text("").HtmlAttributes(New With {.direction = "previous", .title = "Go to previous"}).IconClass("wvi wvi-navigate-left nav-button")
                                                                                                i.Add().Text("").HtmlAttributes(New With {.direction = "today", .title = "Go to today"}).IconClass("wvi wvi-star nav-button")
                                                                                                i.Add().Text("").HtmlAttributes(New With {.direction = "next", .title = "Go to next"}).IconClass("wvi wvi-navigate-right nav-button")
                                                                                            End Sub).Events(Sub(e)
                                                                                                                e.Select("navigatorClicked")
                                                                                                            End Sub).HtmlAttributes(New With {.class = "nav-buttons"})
                </div>
                <div style="display: inline-block; border: 0px solid blue;">
                    @Html.Kendo().ButtonGroup().Name("DayOrWeek").Selection("single").Items(Sub(i)
                                                                                                i.Add().Text("").HtmlAttributes(New With {.view = "Day", .title = "Day view"}).IconClass("wvi wvi-calendar-1 nav-button")
                                                                                                i.Add().Text("").HtmlAttributes(New With {.view = "Week", .title = "Week view"}).IconClass("wvi wvi-calendar-7 nav-button")
                                                                                                'i.Add().Text("").HtmlAttributes(New With {.view = "Grid", .title = "Grid view"}).IconClass("wvi wvi-solar-panel nav-button")
                                                                                                'i.Add().Text("Day").HtmlAttributes(New With {.view = "Day", .title = "Day view"})
                                                                                                'i.Add().Text("Week").HtmlAttributes(New With {.view = "Week", .title = "Week view"})
                                                                                                'i.Add().Text("Grid").HtmlAttributes(New With {.view = "Grid", .title = "Grid view"})
                                                                                            End Sub).Events(Sub(e)
                                                                                                                e.Select("dayOrWeekSelect")
                                                                                                            End Sub).Index(1)
                </div>
            </div>
        </div>
    </div>
    <table class="index-container-table">
        <tr>
            <td>
                <div id="employee-selector" name="employee-selector" style="padding-left: 10px; display:none; height: 40px; margin-top: 8px;">
                    <div class="wv-employee-box">
                        <div class="image-container">
                            <img id="employeeImage" src='@Url.Action("EmployeePicture", "Utilities")/@Model.EmployeeCode' />
                        </div>
                        <div class="name">
                            <span id="employeeName" class="name-span" title="@Model.FullName">@Model.FullName</span>
                        </div>
                        <div class="button" title="Click to change employee">
                            <span id="selectEmployee" class="wvi wvi-magnifying-glass" style="display:none;"></span>
                        </div>
                    </div>
                </div>
            </td>
            <td id="dayViewNavRow" style="text-align: center !important; padding: 8px 0px 0px 8px;">
                <div id="dayViewNav" style="border: 1px solid #ddd; border-radius: 4px; width: 775px; display: none; text-align: center;">
                    <table class="day-view-nav-table" style="width: 100%; text-align: center;">
                        <tr class="day-view-nav-row">
                            <td id="day-0-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-0-text"></div>
                                <div id="day-0-hours"></div>
                            </td>
                            <td id="day-1-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-1-text"></div>
                                <div id="day-1-hours"></div>
                            </td>
                            <td id="day-2-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-2-text"></div>
                                <div id="day-2-hours"></div>
                            </td>
                            <td id="day-3-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-3-text"></div>
                                <div id="day-3-hours"></div>
                            </td>
                            <td id="day-4-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-4-text"></div>
                                <div id="day-4-hours"></div>
                            </td>
                            <td id="day-5-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-5-text"></div>
                                <div id="day-5-hours"></div>
                            </td>
                            <td id="day-6-cell" class="day-view-day-cell" style="width: 12%;">
                                <div id="day-6-text"></div>
                                <div id="day-6-hours"></div>
                            </td>
                            <td class="day-view-day-cell" style="font-weight: bold;" onclick="backToWeekView()">
                                Total: <span id="day-nav-total-hours"></span>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="timesheet-control" style="margin-top: 15px; margin-bottom: 34px;">
                    @Html.Partial("_Timesheet", Model)
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="approvalCommentDialog"></div>
<!--    Scripts      -->
<script>
    //  Variables
    var employeeCode = "";
    var daysToDisplay = 5;
    var userDaysToDisplay = 5;
    var settingsDaysToDisplay = 5;
    var employeePictureURL = "";
    var isViewingSingleDay = false;
    var savedGroup = '';
    var startOfWeekDate = kendo.toString($("#DatePicker")[0].value, "d");
    var endOfWeekDate;
    var startDate = kendo.toString($("#DatePicker")[0].value, "d");
    var tsDate = new Date();
    var navUrl = "";
    var navType = 0; // 0 = Default, 1 = Today, 2 = Previous, 3 = Next
    var copyPanelVisible = false;
    var dayOrWeekView = "Week";
    var activeDateString = "";
    var manualSingleDayDateString = "";
    var functionChangeRowInfo;
    var allowNavigate = false;
    var agencyTimesheetSettings;
    var agencyCommentsRequired = false;
    var useCopyTimesheetFeature = false;
    var sortValue = "";
    var groupValue = "";
    var progressShowing = false;
    var isBackspace = false;

    var sortOptions = [
        { text: "Client", value: "clientAsc", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Client ascending" },
        { text: "Client", value: "clientDesc", icon: "glyphicon glyphicon-sort-by-attributes-alt", tooltip: "Client descending" },
        { text: "Job", value: "jobAsc", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Job ascending" },
        { text: "Job", value: "jobDesc", icon: "glyphicon glyphicon-sort-by-attributes-alt", tooltip: "Job descending" }
    ];
    var groupOptions = [
        { text: "No Grouping", value: "", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Do not group rows" },
        { text: "Client", value: "Client", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Group by client name" },
        { text: "Client/Division", value: "ClientDivision", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Group by client name and division name" },
        { text: "Client/Division/Product", value: "ClientDivisionProduct", icon: "glyphicon glyphicon-sort-by-attributes-alt", tooltip: "Group by client name, division name, and product description" },
        { text: "Client/Job", value: "ClientJob", icon: "glyphicon glyphicon-sort-by-attributes", tooltip: "Group by client name and job number" },
        { text: "Client/Division/Job", value: "ClientDivisionJob", icon: "glyphicon glyphicon-sort-by-attributes-alt", tooltip: "Group by client name, division name, and job number" },
        { text: "Client/Division/Product/Job", value: "ClientDivisionProductJob", icon: "glyphicon glyphicon-sort-by-attributes-alt", tooltip: "Group by client name, division name, product name, and job number" }
    ];
    var currentRowContextRowId = 0;
    var assignmentChangeRowInfo;
    var stopWatchRowInfo;
    var copyRowRowInfo;
    var updates = new Array;
    var inserts = new Array;
    var deletes = new Array;
    var startDateString = "";
    var entryDate = new Date();
    var hours = 0.00;
    var comment = "";
    var functionCategoryCode = "";
    var departmentTeamCode = "";
    var jobNumber = 0;
    var jobComponentNumber = 0;
    var alertId = 0;
    var currentCopyType = -1; //-1 = Panel hiddng, 0 = Panel showing, but nothing selected, 1 = copy from project, 2 = copy from template, 3 = copy from calendar
    var insertsCount = 0;
    var updatesCount = 0;
    var deletesCount = 0;
    var userLimited = false;
    var sunGoal = 0;
    var monGoal = 0;
    var tueGoal = 0;
    var wedGoal = 0;
    var thuGoal = 0;
    var friGoal = 0;
    var satGoal = 0;
    var insertedCount = 0;
    var insertedFailedCount = 0;
    var updatedCount = 0;
    var updatedFailedCount = 0;
    var deletedCount = 0;
    var deletedFailedCount = 0;
    var hasInserts = false;
    var hasUpdates = false;
    var hasDeletes = false;
    var userSearchString = "";
    var copyPageSize = 5;
    var copyProjectsDataSource = null;
    var copyRecentAssignmentsDataSource = null;
    var copyRecentJobsDataSource = null;
    var copyFromMyTimeTemplatesDataSource = null;
    var copyFromMyCalendarDataSource = null;
    var selectedRows = new Array;
    var expandedRows = [];
    var hasCollapsedRows = false;
    var isAllCollapsed = false;
    var getCommentUrl = window.appBase + "Employee/Timesheet/GetTimeEntryCommentText?etid={0}&etdid={1}&tt={2}";

    //  Init from server
    employeeCode = "@Html.Raw(Model.EmployeeCode)";
    daysToDisplay = @Html.Raw(Model.DaysToDisplay) * 1;
    userDaysToDisplay = "@Html.Raw(Model.DaysToDisplay)" * 1;
    settingsDaysToDisplay = @Html.ViewData("SettingsDaysToDisplay") * 1;
    employeePictureURL = "@Url.Action("EmployeePicture", "Utilities")/";
    isViewingSingleDay = @Html.Raw(Model.IsViewingSingleDay.ToString.ToLower);
    savedGroup = '@Html.Raw(ViewData("GroupValue"))';

    //  Init
    function initSortDropDownList() {
        $("#sortDropDownList").kendoDropDownList({
            dataTextField: "text",
            dataValueField: "value",
            dataSource: sortOptions,
            valueTemplate: '<span class="#:data.icon#" title="#:data.tooltip#"></span><span class="selected-value" style="margin-left: 6px;" title="#:data.tooltip#">#:data.text#</span>',
            template: '<span class="#:data.icon#" title="#:data.tooltip#"></span><span class="k-state-default" style="margin-left: 6px;" title="#:data.tooltip#">#:data.text#</span>',
            change: sortDropDownListChanged
        });
    }
    function initGroupDropDownList() {
        $("#groupDropDownList").kendoDropDownList({
            dataTextField: "text",
            dataValueField: "value",
            dataSource: groupOptions,
            valueTemplate: '<span class="selected-value" style="margin-left: 6px;" title="#:data.tooltip#">#:data.text#</span>',
            template: '<span class="k-state-default" style="margin-left: 6px;" title="#:data.tooltip#">#:data.text#</span>',
            change: groupDropDownListChanged,
            value: savedGroup
        });
    }
    function initTimesheetIndexView() {
        $("#copyFrom").kendoDropDownList({ open: adjustDropDownWidth });
        initSortDropDownList();
        initGroupDropDownList();
        $("#copyToDialogCalendar").kendoCalendar();
        $("#selectFunctionsListBox").kendoListBox({
            dataTextField: "Description",
            dataValueField: "Code",
            valueTemplate: '<span class="selected-value" style="margin-left: 6px;" title="#:data.Description#">#:data.Description# (#:data.Code#)</span>',
            template: '<span class="k-state-default" style="margin-left: 6px;" title="#:data.Description#">#:data.Description# (#:data.Code#)</span>',
            selectable: "single"
        });
        $("#selectFunctionDialogFunction").on("input", function (e) {
            var listBox = $("#selectFunctionsListBox").getKendoListBox();
            if (listBox) {
                var searchString = $(this).val();
                if (searchString && searchString != "") {
                    var filter = { logic: "or", filters: [] };
                    filter.filters.push({ field: "Description", operator: "contains", value: searchString });
                    filter.filters.push({ field: "Code", operator: "contains", value: searchString });
                    if (filter.filters.length > 0) {
                        //console.log("filtering");
                        listBox.dataSource.query({ filter: filter });
                    } else {
                        listBox.dataSource.filter({});
                    }
                    //listBox.dataSource.filter([
                    //    { field: "Description", operator: "contains", value: searchString },
                    //    { field: "Code", operator: "contains", value: searchString }
                    //]);
                } else {
                    listBox.dataSource.filter({});
                }
            }
        });
        $("#changeAssignmentDialogListBox").kendoListBox({
            dataTextField: "Description",
            dataValueField: "AlertID",
            selectable: "single"
        });
        $("#changeAssignmentDialogAssignmentInput").on("input", function (e) {
            var listBox = $("#changeAssignmentDialogListBox").getKendoListBox();
            if (listBox) {
                var searchString = $(this).val();
                if (searchString && searchString != "") {
                    listBox.dataSource.filter({ field: "Description", operator: "contains", value: searchString });
                }
            }
        });
        //initEmployees();
        //$("#selectEmployeeDialogEmployeeListBox").kendoListBox({
        //    dataTextField: "Description",
        //    dataValueField: "Code",
        //    selectable: "single",
        //    template: kendo.template($("#employeeLookupTemplate").html())
        //});
        //$("#selectEmployeeDialogEmployeeName").on("input", function (e) {
        //    var listBox = $("#selectEmployeeDialogEmployeeListBox").getKendoListBox();
        //    var sarchString = $(this).val();
        //    listBox.dataSource.filter({ field: "Description", operator: "contains", value: sarchString });
        //});
        initAgencySettings();
        window.setTimeout(function () {
            try {
                if (isViewingSingleDay == true) {
                    activeDateString = startDate;
                    manualSingleDayDateString = startDate;
                    loadDayNav();
                    var buttongroup = $("#DayOrWeek").kendoButtonGroup({}).data("kendoButtonGroup");
                    if (buttongroup) {
                        buttongroup.select(0);
                        //console.log("buttongroup", buttongroup.element[0]);
                        //console.log("agencyCommentsRequired", agencyCommentsRequired);
                        //if (agencyCommentsRequired == true) {
                        //    buttongroup.disable(1);
                        //}
                    }
                    navType = 0;
                    daysToDisplay = 1;
                    allowNavigate = true;
                    //navigate();
                    //console.log("initTimesheetIndexView")
                } else {
                    allowNavigate = true;
                }
            } catch (e) {
                allowNavigate = true;
                navigate();
            }
        }, 10);
    }

    $(document).ready(function () {
        setSaveCancelButtons();
        initTimesheetIndexView();
        initTimesheetPartialView(false);
        //$("#TopToolBar").sticky({ zIndex: 420 });
        $('html').keydown(function (e) {
            if (e.keyCode === 8) {
                isBackspace = true;
            } else {
                isBackspace = false;
            }
        });
    });
</script>
@Scripts.Render("~/JScripts/timesheet.mvc.min.js")

<!--    Templates    -->
<div style="display: none;">
 <script id="commentTemplate" type="text/x-kendo-template">
    <div style="min-width: 225px; max-width: 400px; max-height: 500px; overflow-x: hidden; overflow-y: auto; text-align: left !important;">
        <span id="commentSpan"></span>
    </div>
</script>
 <script id="employeeLookupTemplate" type="text/x-kendo-tmpl">
    <div id="employeeItem" style="height: 40px; vertical-align: middle;" title="#:Description#">
        <div style="margin-top: 9px;">
            <div style="display: inline-block;"><img class="wv-employee-img-thumbnail" src='@Url.Action("EmployeePicture", "Utilities")/#:Code#' /></div>
            <div style="display: inline-block; padding-top: 2px;">#:Description#</div>
        </div>
    </div>
 </script>
<script id="copyFromMyProjectsItemTemplate" type="text/x-kendo-tmpl">
    <div id="draggableCopyItem" class="copy-item" title="Hold down your mouse button, drag over the time sheet, and release the mouse button to add">
        <div style="font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:JobDescription# (#:JobAndComponentNumbers#)">#:JobDescription# (#:JobAndComponentNumbers#)</div>
        <div>
            <div style="display:inline-block;" title="#:Subject#">#:Subject#</div>
        </div>
        <div title="#:ClientName#">#:ClientName#</div>
    </div>
</script>
<script id="copyRecentItemTemplate" type="text/x-kendo-tmpl">
    <div id="draggableCopyItem" class="copy-item" title="Hold down your mouse button, drag over the time sheet, and release the mouse button to add">
        <div style="font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:Title#">#:Title#</div>
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:JobDisplay#">#:JobDisplay#</div>
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:ClientName#|#:DivisionName#|#:ProductName#">#:CDPDisplay#</div>
    </div>
</script>
<script id="copyFromMyTimeTemplatesItemTemplate" type="text/x-kendo-tmpl">
    <div id="draggableCopyItem" class="copy-item" title="Hold down your mouse button, drag over the time sheet, and release the mouse button to add">
        # if (IsTimeCategory == false) { #
        <div style="font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:JobDescription# #:JobAndComponentNumbers#">#:JobDescription# #:JobAndComponentNumbers#</div>
        @*<div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:JobDisplay#">#:JobDisplay#</div>*@
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:FunctionCategoryDescription# (#:FunctionCode#)">#:FunctionCategoryDescription#</div>
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:ClientName#|#:DivisionName#|#:ProductName#">#:CDPDisplay#</div>
        # } else { #
        <div style="font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:FunctionCategoryDescription# (#:CategoryCode#)">#:FunctionCategoryDescription#</div>
        # } #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="Hours for entry.">Hours: #:Hours#</div>
        # if (ApplyToDays != null && ApplyToDays != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="Apply to days: #:ApplyToDaysAbbrev#">#:ApplyToDaysAbbrev#</div>
        # } #
        # if (Comment != null && Comment != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:Comment#">Comment: #:Comment#</div>
        # } #
    </div>
</script>
<script id="copyFromMyCalendarTemplate" type="text/x-kendo-tmpl">
    <div id="draggableCopyItem" class="copy-item" title="Hold down your mouse button, drag over the time sheet, and release the mouse button to add">
        # if (DateDisplay != null && DateDisplay != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:DateDisplay#">#:DateDisplay#</div>
        # } #
        # if (JobNumber > 0 && JobComponentNumber > 0) { #
        <div style="font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:JobDescription# #:JobAndComponentNumbers#">#:JobDescription# #:JobAndComponentNumbers#</div>
        # } #
        # if (CDPDisplay != null && CDPDisplay != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:ClientName#|#:DivisionName#|#:ProductName#">#:CDPDisplay#</div>
        # } #
        # if (FunctionName != null && FunctionName != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:FunctionName#">#:FunctionName#</div>
        # } #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="Hours for entry.">Hours: #:Hours#</div>
        # if (Comments != null && Comments != '') { #
        <div style="white-space: nowrap; overflow: hidden; text-overflow: ellipsis;" title="#:Comments#">Comment: #:Comments#</div>
        # } #
    </div>
</script>

<script id="entryDialogFooter" type="text/x-kendo-tmpl">
    <div style="text-align: right;">
        <div class="k-button-group">
            <button id="newEntryDialogCancel" class="k-button">Cancel</button>
            <button id="newEntryDialogSave" class="k-button k-primary">Start Stopwatch</button>
        </div>
    </div>
</script>

</div>
<!--    Dialogs      -->
<div style="display: none;">

@Code
    Dim SelectEmployeeDialog = Html.EJ().Dialog("selectEmployeeDialog")
    SelectEmployeeDialog.Title("Select a different employee")
    SelectEmployeeDialog.ShowHeader(True)
    SelectEmployeeDialog.ShowFooter(False)
    SelectEmployeeDialog.ShowOnInit(False)
    SelectEmployeeDialog.ContentTemplate(Sub(c)
                                            @<div>
                                                <div class="form-group">
                                                    <div style="padding-right: 4px;">
                                                        <input placeholder="Employee name" type="text" id="selectEmployeeDialogEmployeeName" name="selectEmployeeDialogEmployeeName" maxlength="100" style="width: 100%;" onfocus="this.select();" autocomplete="off" tabindex="997" />
                                                    </div>
                                                    <div style="margin-top: 4px;">
                                                        <select id="selectEmployeeDialogEmployeeListBox" style="width: 100%;" tabindex="998"></select>
                                                    </div>
                                                </div>
                                                <div style="text-align: right;">
                                                    <div class="k-button-group">
                                                        <button id="selectEmployeeCancelButton" onclick="selectEmployeeCancelButtonClick();" class="k-button" tabindex="1000">Cancel</button>
                                                        <button id="selectEmployeeSelectButton" onclick="selectEmployeeSelectButtonClick();" class="k-button k-primary" tabindex="999">Select</button>
                                                    </div>
                                                </div>
                                            </div>
                                                 End Sub)
    SelectEmployeeDialog.Render()
    Dim SelectFunctionDialog = Html.EJ().Dialog("selectFunctionDialog")
    SelectFunctionDialog.Title("Available Functions")
    SelectFunctionDialog.ShowHeader(True)
    SelectFunctionDialog.ShowFooter(False)
    SelectFunctionDialog.ShowOnInit(False)
    SelectFunctionDialog.ClientSideEvents(Sub(evt)
                                              evt.Close("rowDialogClosed")
                                          End Sub)
    SelectFunctionDialog.ContentTemplate(Sub(c)
                                           @<div>
                                                <div Class="form-group">
                                                    <div style = "padding-right: 4px;" >
                                                        <input placeholder="Select a function" type="text" id="selectFunctionDialogFunction" name="selectFunctionDialogFunction" maxlength="100" style="width: 100%;" onfocus="this.select();"/>
                                                    </div>
                                                    <div style = "margin-top: 4px;" >
                                                        <select id="selectFunctionsListBox" style="width: 100%;"></select>
                                                    </div>
                                                </div>
                                                <div style = "text-align: right;" >
                                                    <div class="k-button-group">
                                                        <button id="selectFunctionCancelButton" onclick="selectFunctionCancelButtonClick();" class="k-button">Cancel</button>
                                                        <button id="selectFunctionSelectButton" onclick="selectFunctionSelectButtonClick();" class="k-button k-primary">Save</button>
                                                    </div>
                                                </div>
                                            </div>
                                         End Sub)
    SelectFunctionDialog.Render()
    Dim ChangeAssignmentDialog = Html.EJ().Dialog("changeAssignmentDialog")
    ChangeAssignmentDialog.Title("Available Assignments")
    ChangeAssignmentDialog.ShowHeader(True)
    ChangeAssignmentDialog.ShowFooter(False)
    ChangeAssignmentDialog.ShowOnInit(False)
    ChangeAssignmentDialog.ClientSideEvents(Sub(evt)
                                                evt.Close("rowDialogClosed")
                                            End Sub)
    ChangeAssignmentDialog.ContentTemplate(Sub(c)
                                            @<div>
                                                <div class="form-group">
                                                    <div style="padding-right: 4px;">
                                                        <input placeholder="Select an assignment" type="text" id="changeAssignmentDialogAssignmentInput" name="changeAssignmentDialogAssignment" maxlength="100" style="width: 100%;" onfocus="this.select();" />
                                                    </div>
                                                    <div style="margin-top: 4px;">
                                                        <select id="changeAssignmentDialogListBox" style="width: 100%;"></select>
                                                    </div>
                                                </div>
                                                <div style="text-align: right;">
                                                    <div class="k-button-group">
                                                       <button id="changeAssignmentDialogCancelButton" onclick="changeAssignmentDialogCancelButtonClick();" class="k-button">Cancel</button>
                                                       <button id="changeAssignmentDialogSaveButton" onclick="changeAssignmentDialogSaveButtonClick();" class="k-button k-primary">Save</button>
                                                    </div>
                                                </div>
                                            </div>
                                           End Sub)
    ChangeAssignmentDialog.Render()
    Dim LineViewDialog = Html.EJ().Dialog("lineViewDialog")
    LineViewDialog.Title("Row View")
    LineViewDialog.ShowHeader(False)
    LineViewDialog.ShowFooter(False)
    LineViewDialog.ShowOnInit(False)
    LineViewDialog.ContentType("iframe")
    LineViewDialog.Height("600px")
    LineViewDialog.Render()
    Dim SettingsDialog = Html.EJ().Dialog("settingsDialog")
    SettingsDialog.Title("Time Settings")
    SettingsDialog.ShowOnInit(False)
    SettingsDialog.ContentType("iframe")
    SettingsDialog.Render()
    Dim DetailsDialog = Html.EJ().Dialog("detailsDialog")
    DetailsDialog.Title("Details")
    DetailsDialog.ShowHeader(False)
    DetailsDialog.ShowFooter(False)
    DetailsDialog.ShowOnInit(False)
    DetailsDialog.ContentType("iframe")
    DetailsDialog.Render()
    Dim CopyToDialog = Html.EJ().Dialog("copyToDialog")
    CopyToDialog.Title("Copy")
    CopyToDialog.ShowHeader(True)
    CopyToDialog.ShowFooter(False)
    CopyToDialog.ShowOnInit(False)
    CopyToDialog.Width("300px")
    CopyToDialog.ContentTemplate(Sub(c)
                                    @<div style="margin-left: 15px; margin-bottom: 8px;">
                                        <div style="margin-top: 8px;" title="Select whether you want to copy the entire timesheet or only selected rows">
                                            @Html.Kendo().ButtonGroup().Name("copyToDialogCopyItemsButtonGroup").Selection("single").Items(Sub(i)
                                                                                                                                               i.Add().Text("Entire timesheet").HtmlAttributes(New With {.copy_items = "entireTimesheet", .title = "Copy this entire timesheet to the week selected below"}).Selected(True)
                                                                                                                                               i.Add().Text("Selected rows").HtmlAttributes(New With {.copy_items = "selectedRows", .title = "Copy the selected rows from this timesheet to the week selected below"}).Enabled(True)
                                                                                                                                           End Sub)
                                        </div>
                                        <div style="margin-top: 8px" title="Select any day to copy time to that week">
                                            <span>To Week Of:</span>
                                        </div>
                                        <div>
                                            <div id="copyToDialogCalendar" />
                                        </div>
                                        <div>
                                            <div id="copyToDialogIncludeHoursDiv" title="Include hours when copying entries">
                                                @(Html.Kendo.CheckBox().Name("copyToDialogIncludeHoursCheckBox").Label("").Checked(False))Include hours
                                            </div>
                                            <div title="Include comments when copying entries" style="display: none;">
                                                @(Html.Kendo.CheckBox().Name("copyToDialogIncludeCommentsCheckBox").Label("").Checked(False))Include comments
                                            </div>
                                        </div>
                                        <div style="text-align: right;margin-top: 15px;">
                                            <div class="k-button-group">
                                                <button id="copyToDialogCancelButton" onclick="copyToDialogCancelButtonClick();" class="k-button">Cancel</button>
                                                <button id="copyToDialogSelectButton" onclick="copyToDialogSelectButtonClick();" class="k-button k-primary">Copy</button>
                                            </div>
                                        </div>
                                    </div>
                                 End Sub)
    CopyToDialog.Render()
    Dim EntryDialog = Html.EJ().Dialog("entryDialog")
    EntryDialog.Title("Time Entry")
    EntryDialog.ShowOnInit(False)
    EntryDialog.ContentType("iframe")
    EntryDialog.FooterTemplateId("entryDialogFooter")
    EntryDialog.ShowFooter(True)
    EntryDialog.Render()
End Code
</div>
