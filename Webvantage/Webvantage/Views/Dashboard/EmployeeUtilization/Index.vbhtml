@Code       Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code


@*<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/scripts/jszip.min.js")"></script>
<script src="~/jscripts/utilization.mvc.min.js"></script>
<script src="~/jscripts/utilization.datagrid.mvc.min.js"></script>*@
<script src="~/jscripts/utilization.filter.mvc.min.js"></script>

<script src="~/jscripts/validator.js" type="text/javascript"></script>
    <script src="@Url.Content("~/Scripts/jszip.min.js")"></script>
    <script src="~/JScripts/utilization.mvc.js"></script>
    <script src="~/JScripts/utilization.datagrid.mvc.js"></script>
    <script src="~/JScripts/utilization.filter.mvc.js"></script>

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


    #ScheduleToolBar .wvi-floppy-disk {
        font-size: 22px;
    }

    */

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
    #utilizationgrid_active_cell > a[cust-role="subject_cell"],
    #utilizationgrid_active_cell > a[cust-role="assigned_to_cell"],
    #utilizationgrid_active_cell > a[cust-role="job_cell"] {
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
            <li id="Year1" style="padding:3px">
                <Button id="Year1Button" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleYear" onclick="onYear1Click(@ViewBag.Year1)" style="width: 50px !important;" title="@ViewBag.Year1"><span style="font-size: 12px;">@ViewBag.Year1</span></Button>
            </li>
            <li id="Year2" style="padding:3px">
                <Button id="Year2Button" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleYear" onclick="onYear2Click(@ViewBag.Year2)" style="width: 50px !important;" title="@ViewBag.Year2"><span style="font-size: 12px;">@ViewBag.Year2</span></Button>
            </li>
            <li id="Jan" style="padding:3px">
                <Button id="JanButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(1)" style="width: 50px !important;" title="Jan"><span style="font-size: 12px;">Jan</span></Button>
            </li>
            <li id="Feb" style="padding:3px">
                <Button id="FebButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(2)" style="width: 50px !important;" title="Feb"><span style="font-size: 12px;">Feb</span></Button>
            </li>
            <li id="Mar" style="padding:3px">
                <Button id="MarButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(3)" style="width: 50px !important;" title="Mar"><span style="font-size: 12px;">Mar</span></Button>
            </li>
            <li id="Apr" style="padding:3px">
                <Button id="AprButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(4)" style="width: 50px !important;" title="Apr"><span style="font-size: 12px;">Apr</span></Button>
            </li>
            <li id="May" style="padding:3px">
                <Button id="MayButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(5)" style="width: 50px !important;" title="May"><span style="font-size: 12px;">May</span></Button>
            </li>
            <li id="Jun" style="padding:3px">
                <Button id="JunButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(6)" style="width: 50px !important;" title="Jun"><span style="font-size: 12px;">Jun</span></Button>
            </li>
            <li id="Jul" style="padding:3px">
                <Button id="JulButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(7)" style="width: 50px !important;" title="Jul"><span style="font-size: 12px;">Jul</span></Button>
            </li>
            <li id="Aug" style="padding:3px">
                <Button id="AugButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(8)" style="width: 50px !important;" title="Aug"><span style="font-size: 12px;">Aug</span></Button>
            </li>
            <li id="Sep" style="padding:3px">
                <Button id="SepButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(9)" style="width: 50px !important;" title="Sep"><span style="font-size: 12px;">Sep</span></Button>
            </li>
            <li id="Oct" style="padding:3px">
                <Button id="OctButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(10)" style="width: 50px !important;" title="Oct"><span style="font-size: 12px;">Oct</span></Button>
            </li>
            <li id="Nov" style="padding:3px">
                <Button id="NovButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(11)" style="width: 50px !important;" title="Nov"><span style="font-size: 12px;">Nov</span></Button>
            </li>
            <li id="Dec" style="padding:3px">
                <Button id="DecButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onMonthClick(12)" style="width: 50px !important;" title="Dec"><span style="font-size: 12px;">Dec</span></Button>
            </li>
            <li id="Dec" style="padding:3px">
                <Button id="YTDButton" class="k-toggle-button k-button k-group-start wv-icon-button" data-group="toggleGroup" onclick="onYTDClick()" style="width: 50px !important;" title="YTD"><span style="font-size: 12px;">YTD</span></Button>
            </li>
            <li style="padding:3px" id="bookmarkListItem">
                <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>
        </ul>
            <div Class="pull-right">
                <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;"></ul>
            </div>
        </div>

    <div id="FilterWrap" style="display:none">
        @Html.Partial("_UtilizationFilter", Model)
    </div>
    <div id="AlertManagerWrap" style="height: calc(100vh - 425px);">
        @Html.Partial("_UtilizationGrid", Model)
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
    let gridDirty = false;

    let urlParms = new URLSearchParams(window.location.search);

    if (urlParms.has('bm')) {
        _fromBookmarkFlag = true;
    }

    if (urlParms.get("pg") != null) {

        if (urlParms.get("pg") == "dept") {
            EUFilter.Page = "dept";
         } else {
            EUFilter.Page = "billablegoal";
        }

        if (urlParms.get("year") == "dept") {

        }       
    }
   
    if (urlParms.get("year") != null) {
        EUFilter.FromYear = parseInt(urlParms.get("year"));
    }

    if (urlParms.get("month") != null) {
        EUFilter.FromMonth = parseInt(urlParms.get("month"));
    }

    //EUFilter.Page = "dept";

    GetUserViewSettings(_viewType);
    GetGroupSecuritySettings();

</script>
