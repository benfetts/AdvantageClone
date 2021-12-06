@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code


@*<script src="~/jscripts/validator.js" type="text/javascript"></script>
    <script src="@Url.Content("~/scripts/jszip.min.js")"></script>
    <script src="~/jscripts/utilization.mvc.min.js"></script>
    <script src="~/jscripts/utilization.datagrid.mvc.min.js"></script>
    <script src="~/jscripts/utilization.filter.mvc.min.js"></script>*@

<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jszip.min.js")"></script>
<script src="~/JScripts/financial.dashboard.mvc.js"></script>
@*<script src="~/JScripts/utilization.datagrid.mvc.js"></script>
<script src="~/JScripts/utilization.filter.mvc.js"></script>*@

<style>
    .container {
        max-width: none;
        width: 100%;
    }

    #settings-container {
        /*width: 1455px;
        margin: 5px auto 5px auto;        */
        width: calc(80vw - 50px) !important;
        margin: 5px;
        margin-left: auto;
        margin-right: auto;
        min-width: 760px;
    }

    .k-Button-icon, .k-Split-Button-arrow {
        padding: 2px 4px !important;
    }

    .telerik-aqua-body {
        border: 1px solid #ccc;
        border-radius: 6px;
        padding-left: 5px;
        padding-right: 5px;
        background: #fff;
        float: none !important;
        display: block;
        margin-left: auto;
        margin-right: auto;
        margin-top: 8px;
        box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2), 0 1px 2px rgba(0, 0, 0, 0.05);
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

    .k-dropdown {
        vertical-align: middle;
    }

    .k-widget.k-dropdown .k-dropdown-wrap .k-input {
        line-height: 32px;
    }

    .k-button {
        vertical-align: central;
    }

    .panelbar {
        border-style: solid;
        border-width: 1px;
        border-radius: 4px;
        border-color: lightgray;
        /*min-width: 1000px !important;*/
        display: inline-block;
        position: relative;
        width: calc(50vw - 16px);
        min-width: calc(50vw - 16px);
        margin-top: 5px;
        height: 97%;
    }

    .panelBarSpan {
        position: relative;
        width: calc(100% - 28px) !important;
        font-weight: 600;
        font-size: 14px;
        border-radius: 4px 4px 0px 0px;
        background-color: #ffffff !important;
        color: black !important;
        border-color: #ccc !important;
    }

    .dashboard-listitem {
        position: relative;
        width: calc(50vw - 16px) !important;
        height: 320px;
        border: 1px solid black;
    }

    .dashboard-container-row {
        background-color: white;
        border-radius: 4px;
        overflow: hidden;
        width: calc(100vw - 18px);
        margin-right: 0px !important;
        margin-bottom: 10px;
        padding: 0px !important;
    }

    .k-grid-content {
        overflow: hidden !important;
    }

    .main-toolbar-container {
        width: calc(100vw - 40px);
        min-width: calc(100vw - 40px);
        background-color: #E5E5E5;
        padding: 10px 10px 10px 10px;
        border-bottom: 1px solid #CCC;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);
        margin: 5px 14px 5px 1px;
        overflow: auto;
    }

    /*added to fix style differences in upgraded Kendo version*/
    .k-toolbar > * {
        display: inline-block !important;
        vertical-align: middle !important;
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
            <li style="padding:3px" id="bookmarkListItem">
                <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>
            <li style="padding:3px">
                <button class="k-button wv-icon-button wv-neutral" onclick="refreshPage('')"><span class='wvi wvi-refresh' title="Refresh"></span></button>
            </li>
        </ul>
        <div Class="pull-right">
            <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;"></ul>
        </div>
    </div>

    <div id="FilterWrap" style="display:none">

    </div>
    <div id="FinancialWrap">
        @Html.Partial("_FinancialDashboard", Model)
    </div>
</div>
<div class="k-overlay" id="myOverlay" style="display:none"></div>

<script>

    let myColumns = new Array();

    $(() => {
        let urlParms = new URLSearchParams(window.location.search);

        if (urlParms.has('bm')) {
            _fromBookmarkFlagFD = true;
        }        

        if (urlParms.get("year") != null) {
            EUFilter.FromYear = parseInt(urlParms.get("year"));
        }

        if (urlParms.get("month") != null) {
            EUFilter.FromMonth = parseInt(urlParms.get("month"));
        }
    });

    function LoadDashboardView() {
        
        //$("#payments-dashboard").load('@Url.Action("_FinancialDashboard", "FinancialDashboard")');       
    }

   
   
</script>
