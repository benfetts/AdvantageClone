@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code


<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/scripts/jszip.min.js")"></script>
<script src="~/jscripts/billing.paymentcenter.mvc.js"></script>


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

<div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable main-toolbar-container">
    <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
        <li id="dashboardListItem" style="padding:0">
            <Button id="dashboardButton" Class="k-button wv-icon-button k-state-active " onclick="manageModuleViews('dashboard')" style="width: 160px !important;" title="Dashboards"><span style="font-size: 12px;">Dashboards</span></Button>
        </li>
        <li id="managePaymentsListItem" style="padding:0">
            <Button id="managePaymentsButton" Class="k-button wv-icon-button  " onclick="manageModuleViews('paymentManager')" style="width: 160px !important;" title="Manage Payments"><span style="font-size: 12px;">Manage Payments</span></Button>
        </li>
        <li id="manageVCCsListItem" style="padding:0">
            <Button id="manageVCCsButton" Class="k-button wv-icon-button wv-neutral " onclick="manageModuleViews('vcManager')" style="width: 160px !important;" title="Manage Virtual Credit Cards"><span style="font-size: 12px;">Manage Virtual Cards</span></Button>
        </li>
        <li id="outstandingApprovalsListItem" style="padding:0">
            <Button id="outstandingButton" Class="k-button wv-icon-button wv-neutral " onclick="manageModuleViews('outstanding')" style="width: 160px !important;" title="Approvals"><span style="font-size: 12px;">Outstanding Approvals</span></Button>
        </li>
        <li id="completedButton" style="padding:0">
            <Button id="" Class="k-button wv-icon-button wv-neutral " onclick="manageModuleViews('completed')" style="width: 160px !important;" title="Batches"><span style="font-size: 12px;">Completed Batches</span></Button>
        </li>
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-settings" onclick="openSettings()"><span class='glyphicon glyphicon-cog' title="Settings" style="font-size: 18px;"></span></button>
        </li>
        <li style="padding:0">
            <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
        </li>
    </ul>
    <div Class="pull-right">
        <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;"></ul>
    </div>
</div>



<div class="k-overlay" id="myOverlay" style="display:none"></div>
<div id="payments-dashboard" style="height: calc(100vh - 425px);">
        @*@Html.Partial("_PaymentsDashboard")*@
        
</div>
<div id="manage-payments" style="height: calc(100vh - 425px);">
    @*@Html.Partial("_PaymentManager")*@
</div>
<div id="manage-virtual-cards" style="height: calc(100vh - 425px);">
    @*@Html.Partial("_VirtualCardManager")*@
</div>
<div id="payments-outstanding" style="height: calc(100vh - 425px);">
    @*@Html.Partial("_OutstandingPayments")*@
</div>
<div id="payments-completed" style="height: calc(100vh - 425px);">
    @*@Html.Partial("_CompletedPayments")*@
</div>
<script>
    $(() => {        
        LoadDashboardView();
        //$("#AddNewBatch").empty().hide(); 
    });

    function LoadDashboardView() {
        $("#payments-dashboard").load('@Url.Action("_PaymentsDashboard", "PaymentCenter")');
        $("#manage-payments").empty().hide();
        $("#manage-virtual_cards").empty().hide();
        $("#payments-outstanding").empty().hide();
        $("#payments-completed").empty().hide();
    }

    function LoadManagePaymentsView() {
        $("#manage-payments").load('@Url.Action("_PaymentManager", "PaymentCenter")');
        $("#payments-dashboard").empty().hide();
        $("#manage-virtual_cards").empty().hide();
        $("#payments-outstanding").empty().hide();
        $("#payments-completed").empty().hide();
    }

    function LoadManageVCCView() {
        $("#manage-virtual-cards").load('@Url.Action("_VirtualCardManager", "PaymentCenter")');
        $("#payments-dashboard").empty().hide();
        $("#manage-payments").empty().hide();
        $("#payments-outstanding").empty().hide();
        $("#payments-completed").empty().hide();
    }

    function LoadOutstandingApprovalsView() {
        $("#payments-outstanding").load('@Url.Action("_OutstandingPayments", "PaymentCenter")');
        $("#payments-dashboard").empty().hide();
        $("#manage-virtual_cards").empty().hide();
        $("#manage-payments").empty().hide();
        $("#payments-completed").empty().hide();
    }

    function LoadCompletedBatchesView() {
        $("#payments-completed").load('@Url.Action("_CompletedPayments", "PaymentCenter")');
        $("#payments-dashboard").empty().hide();
        $("#manage-virtual_cards").empty().hide();
        $("#payments-outstanding").empty().hide();
        $("#manage-payments").empty().hide();
    }
</script>
