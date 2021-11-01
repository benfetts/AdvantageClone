@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code


<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/scripts/jszip.min.js")"></script>
<script src="~/jscripts/aam.inbox.mvc.min.js"></script>
<script src="~/jscripts/aam.inbox.datagrid.mvc.min.js"></script>
<script src="~/jscripts/aam.inbox.filter.mvc.min.js"></script>

@*<script src="~/jscripts/validator.js" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jszip.min.js")"></script>
    <script src="~/JScripts/aam.inbox.mvc.js"></script>
    <script src="~/JScripts/aam.inbox.datagrid.mvc.js"></script>
    <script src="~/JScripts/aam.inbox.filter.mvc.js"></script>*@

<style>
    .container {
        max-width: none;
        width: 100%;
    }

    /*#TopToolBar input {
            height: 28px !important;
            border: 1px solid #e6e6e6;
            background-color:   #fff;
            border-radius:   4px;
            padding-Left():   5px;
            line-height: normal;
            vertical-align: top;
            padding: 2px 2px 1px;
        }*/

    .sticky {
        position: sticky;
        position: -webkit-sticky;
        left: 28px;
        letter-spacing: 1px;
    }

    /*#ScheduleToolBar {
            border-style: solid !important;
            border-width: 1px !important;
            border-color: #ccc !important;
            font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
            padding: .57142857em .37142857em !important;
            border-radius: 4px !important;
            background: #e5e5e5 !important;
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0,0,0,.05) !important;
            margin-top: 5px !important;
            margin-bottom: 15px !important;
            margin-Left(): auto;
            margin-Right(): auto;
        }

            #ScheduleToolBar .wvi-floppy-disk {
                font-size: 22px;
            }*/

    .k-Button-icon, .k-Split-Button-arrow {
        padding: 2px 4px !important;
    }

    .telerik-aqua-body {
        border: 1px solid #ccc;
        border-radius: 6px;
        padding-Left(): 5px;
        padding-Right(): 5px;
        background: #fff;
        float: none !important;
        display: block;
        margin-Left(): auto;
        margin-Right(): auto;
        margin-top: 8px;
        box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
    }

    /*#JobsThatPrecede, #JobsThatFollow {
            padding: 0;
            margin: 0;
            overflow: auto;
        }

            #JobsThatPrecede Option, #JobsThatFollow Option {
                padding: 5px;
            }*/

    /*.toolbar-custom-drop {
            padding: 5px;
            display: none;
        }

    .toolbar-custom-drop.k-Button {
    width: 100%;
    }

    .toolbar-custom-drop tbody td {
    padding: 2px 8px 2px 8px !important;
    }

    .toolbar-custom-drop tbody td: first-child {
    padding-Left(): 2px !important;
    }

    .toolbar-custom-drop tbody td: last-child {
    padding-Right(): 2px !important;
    }*/

    #myOverlay {
        display: none;
    }

    .dropdown-Header {
        border-width: 0 0 1px 0;
        Text-transform: uppercase;
    }

        .dropdown-Header > span {
            display: inline-block;
            padding: 10px 5px 10px 0px;
        }

    div[id^=EstimateFunction] .k-item > span {
        display: inline-block;
        padding: 0px 5px 0px 0px;
    }

        .dropdown-Header > span:first-child, div[id^=EstimateFunction] .k-item > span:first-child {
            width: 75px;
        }

    #gridToolBarWrap {
        z-index: 999;
        width: 100% !important;
    }

    textarea {
        resize: none !important;
    }

    .wvi .wvi-more_vertical {
        text-decoration: none !important;
    }

    body {
        overflow-x: hidden;
        overflow-y: auto;
    }

    #includeCompleted {
        background-color: #e5e5e5;
        border: none;
    }

    .k-dropdown {
        vertical-align: middle;
    }

    .k-widget.k-dropdown .k-dropdown-wrap .k-input {
        line-height: 32px;
    }

    .k-button {
        /*display: table-cell;*/
        vertical-align: central;
    }

    #AAViewListItem > span.k-widget.k-dropdown.k-header > span.k-state-focused > span.k-input,
    #tdFilter > span.k-widget.k-dropdown.k-header > span.k-state-focused > span.k-input,
    .k-dropdown-wrap.k-state-default.k-state-focused.k-state-active > span.k-input,
    .k-dropdown-wrap.k-state-default.k-state-focused > span.k-input,
    #aagrid_active_cell > a[cust-role="subject_cell"],
    #aagrid_active_cell > a[cust-role="assigned_to_cell"],
    #aagrid_active_cell > a[cust-role="job_cell"] {
        color: white;
    }

    #panelbar {
        border-style: solid;
        border-width: 1px;
        margin-bottom: 5px;
        border-radius: 4px;
        border-color: lightgray;
        /*min-width: 1000px !important;*/
    }

    .filterLabel {
        font-weight: bold;
        color: #767676;
    }

    .k-widget .k-picker {
        width: 161px;
    }

    /*#startdate, #duedate {
            background-color: #FFFFCC;
        }*/

    .noHover {
        pointer-events: none;
        opacity: 0.5 !important;
    }

    .k-picker-wrap .k-input .k-select {
        height: 2em !important;
        line-height: 2em !important;
        min-height: 2em !important;
    }

    .k-i-calendar {
        height: 1em !important;
    }

    .k-i-calendar {
        height: 1em !important;
    }

    .k-picker-wrap {
        height: 2em !important;
    }

        .k-picker-wrap .k-select {
            height: 2em !important;
            min-height: 2em !important;
            line-height: 2em !important;
        }

    .multiselect-filter {
        height: 60px;
    }
</style>
<div>
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width:calc(100vw - 40px);background-color: #E5E5E5;padding: 10px 10px 10px 10px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px 14px 5px 1px; overflow:auto;">
        <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li id="NewAssignment" style="padding:3px">
                <Button Class="k-button wv-icon-button wv-neutral " onclick="onNewAssignmentClick()" style="width: 110px !important;" title="New Assignment"><span style="font-size: 12px;">New Assignment</span></Button>
            </li>
            <li id="NewAlert" style="padding:3px">
                <Button Class="k-button wv-icon-button wv-neutral " onclick="onNewAlertClick()" style="width: 110px !important;" title="New Alert"><span style="font-size: 12px;">New Alert</span></Button>
            </li>
            <li style="padding:3px" id="saveListItem">
                <button id="saveButton" class="k-button wv-icon-button wv-save k-state-disabled" title="Save changes" onclick="saveGridChanges()" disabled><span class='wvi wvi-floppy-disk'></span></button>
            </li>
            <li style="padding:3px" id="cancelListItem">
                <button id="cancelButtonVis" class="wv-icon-button k-button wv-cancel k-state-disabled" onclick="cancelChanges()" title="Cancel" disabled><span class="wvi wvi-sign-forbidden"></span></button>
            </li>
            <li id="ViewListItem" style="padding:3px;">
                <div id="AAViewListItem">
                    <span>View:</span>
                    <input id="AAView" type="text" style="width: 160px;" />
                </div>
            </li>
            <li id="myAlertsAndAssignmentsListItem" style="padding:3px">
                <button id="buttonMyAlertsAndAssignments" class="k-toggle-button k-button k-state-active k-group-start wv-icon-button" data-group="toggleGroup" onclick="onAssignmentTypeClick('myalertsandassignments');" style="width: 160px !important;" title="My Assignments & Alerts"><span style="font-size: 12px;">My Assignments & Alerts</span></button>
            </li>
            <li id="myAlertsListItem" style="padding:3px">
                <button id="buttonMyAlerts" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onAssignmentTypeClick('myalerts');" style="width: 110px !important;" title="My Alerts"><span style="font-size: 12px;">My Alerts</span></button>
            </li>
            <li id="myAssignmentsListItem" style="padding:3px">
                <button id="buttonMyAssignments" class="k-toggle-button k-group-start k-button wv-icon-button" data-group="toggleGroup" onclick="onAssignmentTypeClick('myalertassignments');" style="width: 110px !important;" title="My Assignments"><span style="font-size: 12px;">My Assignments</span></button>
            </li>
            <li id="allAssignmentsListItem" style="padding:3px">
                <button id="buttonAllAssignments" class="k-toggle-button k-group-start k-button wv-icon-button" data-group="toggleGroup" onclick="onAssignmentTypeClick('allalertassignments');" style="width: 110px !important;" title="All Assignments"><span style="font-size: 12px;">All Assignments</span></button>
            </li>
            <li id="unassignedListItem" style="padding:3px">
                <button id="buttonUnassigned" class="k-toggle-button k-button k-group-start k-group-end wv-icon-button" data-group="toggleGroup" onclick="onAssignmentTypeClick('unassigned');" style="width: 110px !important;" title="Unassigned"><span style="font-size: 12px;">Unassigned</span></button>
            </li>
            <li style="padding:3px" id="bookmarkListItem">
                <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>
            <li style="padding:3px">
                <button class="k-button wv-icon-button wv-neutral" onclick="refreshPage('')"><span class='wvi wvi-refresh' title="Refresh"></span></button>
            </li>
            <li style="padding:3px; display: none;" id="includeCompletedListItem">
                <div id="includeCompletedDiv">
                    <input type="checkbox" id="includeCompletedItems" class="k-checkbox" title="Include Completed Assignments" onchange="includeCompleted();">
                    <label class="k-checkbox-label" style="font-weight: normal !important;" for="includeCompletedItems">Include Completed</label>
                </div>
            </li>
            <li id="buttonAllCommentsListItem" style="padding:3px">
                <button id="buttonAllComments" class="k-button wv-icon-button" onclick="allCommentsClick();" style="width: 110px !important;" title="All Comments"><span style="font-size: 12px;">All Comments</span></button>
            </li>
        </ul>
        <div Class="pull-right">
            <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;"></ul>
        </div>
    </div>

    <div id="FilterWrap">
        @Html.Partial("_InboxFilter", Model)
    </div>
    <div id="AlertManagerWrap" style="height: calc(100vh - 425px);">
        @Html.Partial("_InboxGrid", Model)
    </div>
</div>
<div class="k-overlay" id="myOverlay" style="display:none"></div>

<script>

    let _EmployeeCode = "@ViewBag.DefaultEmpCode";
    let isJobJacketView = false;
    let _viewType = "ALERT_INBOX";
    let _filterSelectedValue = 'employee';
    let _multiselectfiltered = false;
    let parentRefreshFlag = false;
    let saveColumnVisibility = true;
    let myColumns = new Array();
    let columnSettingsReady = false;
    let userViewSettingsReady = false;
    let _isClientPortal = "@ViewBag.IsClientPortal";

    $(() => {
        if (isJobJacketView) {
            $("#AAViewListItem").css("display", "none");
            $("#includeCompletedListItem").show();
            $("#includeCompletedItems").attr("checked", true);
            $("#buttonAllCommentsListItem").show();
            $("#buttonMyAlertsAndAssignments").prop("title", "All Assignments & Alerts");
            $("#buttonMyAlertsAndAssignments span").text("All Assignments & Alerts");
            $("#buttonMyAlerts").prop("title", "My Alerts");
            $("#buttonMyAlerts span").text("My Alerts");
        } else {
            $("#AAViewListItem").css("display", "");
            $("#includeCompletedListItem").hide();
            $("#buttonAllCommentsListItem").hide();
            $("#buttonMyAlertsAndAssignments").prop("title", "My Assignments & Alerts");
            $("#buttonMyAlertsAndAssignments span").text("My Assignments & Alerts");
            $("#buttonMyAlerts").prop("title", "My Alerts");
            $("#buttonMyAlerts span").text("My Alerts");
        }

        //setTimeout(function () {
        //    $("#AAView").data("kendoDropDownList").select(GetViewIndex(AlertFilter.InboxType))
        //}, 250)
        //$("[role='listbox']").each(function () {
        //    var widget = $(this).data("kendoDropDownList");

        //    widget.wrapper.on("keydown", function (e) {
        //        e.stopImmediatePropagation();
        //    });
        //});
    });

    let urlParms = new URLSearchParams(window.location.search);

    if (urlParms.has('bm')) {
        _fromBookmarkFlag = true;
    }

    if (urlParms.has('j') && urlParms.has('jc')) {
        isJobJacketView = true;
    }

    if (isJobJacketView) {
        _viewType = 'JJ_ALERT_INBOX';
    } else {
        _viewType = 'ALERT_INBOX';
    }

    //Set default ShowAssignmentType
    let show = 'myalertsandassignments';

    //map URL Parameters to AlertFilter Object when present (i.e. coming from a bookmark)
    const entries = Object.entries(AlertFilter);
    let gridDirty = false;
    let parmName = '';

    for (const [name, value] of entries) {
        switch (name) {
            case "SearchCriteria":
                parmName = "st";
                break;
            case "InboxType":
                parmName = "aamit";
                break;
            case "ShowAssignmentType":
                parmName = "aamsat";
                break;
            case "StartDate":
                parmName = "sd";
                break;
            case "DueDate":
                parmName = "ed";
                break;
            case "EmployeeCode":
                parmName = "emp";
                break;
            //GridSize and GroupBy aren't needed for the AlertFilter, as it does not affect the datasource criteria
            //and only used for UserViewSettings
            //case "GridSize":
            //    UserViewSettings.GridSize = urlParms.get("aamgs");
            //    break;
            //case "GroupBy":
            //    UserViewSettings.GroupBy = urlParms.get("aamgb");
            //    break;
            case "ShowOnlyTempCompletedTasks":
                parmName = "aamstct";
                break;
            default:
                parmName = name;
                break;
        };

        if (urlParms.get(parmName) != null) {
            if (parmName == "aamstct") {
                if (urlParms.get(parmName) == 1) {
                    AlertFilter.ShowOnlyTempCompletedTasks = true;
                } else {
                    AlertFilter.ShowOnlyTempCompletedTasks = false;
                }

                if (AlertFilter.ShowAssignmentType !== "myalerts" && AlertFilter.ShowAssignmentType !== "unassigned") {
                    $("#ShowOnlyTempCompletedTasks").attr("checked", AlertFilter.ShowOnlyTempCompletedTasks);
                }
            //} else if (parmName == "aamgb") {
            //    AlertFilter.GroupBy = urlParms.get(parmName);
            } else {
                AlertFilter[name] = urlParms.get(parmName);
            }
            //AlertFilter.InitialLoadFlag = true;
        }
        else {
            AlertFilter[name] = AlertFilter[name];
        }
    }

    //coming from Job Jacket
    if (isJobJacketView){
        AlertFilter.JobNumber = urlParms.get('j');
        AlertFilter.JobComponentNumber = urlParms.get('jc');

        //if (urlParms.get('aamsat')) {
        //    AlertFilter.ShowAssignmentType = urlParms.get('aamsat');
        //}


        //console.log("JJ refresh final", AlertFilter.ShowAssignmentType);

        AlertFilter.IncludeCompletedAssignments = true;
        AlertFilter.IncludeBoardLevel = true;
        AlertFilter.IsJobAlertsPage = true;

        AlertFilter.StartDate = null;
        AlertFilter.EndDate = kendo.parseDate(new Date());
        AlertFilter.ShowOnlyTempCompletedTasks = false;

        //$("#NewAlert").hide();
        //$("#NewAssignment").hide();
        $("#bookmarkListItem").hide();
        $("#employeeFilterContainer").hide();
        $("#ShowOnlyTempCompletedTasksDiv").hide();
        //$("#IncludeBacklogItemsDiv").hide();
        $("#tdFilter").hide();

        //$("#FilterWrap").hide();
    }

    if (_isClientPortal == "True") {

        $("#NewAssignment").hide();
        $("#employeeFilterContainer").hide();
        $("#ShowOnlyTempCompletedTasksDiv").hide();
        $("#IncludeBacklogItemsDiv").hide();
        $("#tdFilter").hide();
        $("#tdEmployee").hide();
        $("#saveListItem").hide();
        $("#cancelListItem").hide();
        $("#allAssignmentsListItem").hide();
        $("#unassignedListItem").hide();
        $("#bookmarkListItem").hide();
        $("#completeTempCompleteListItem").hide();
        $("#dismissAllListItem").hide();

    }

    GetUserViewSettings(_viewType);
    GetGroupSecuritySettings();
</script>
