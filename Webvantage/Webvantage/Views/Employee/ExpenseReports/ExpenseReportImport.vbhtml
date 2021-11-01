@Code ViewData("Title") = "Submit Expense Report Options"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
    ViewData("IsAngular") = True

    Dim Employees As IEnumerable = ViewBag.Employees
End Code
<style>
    .bad-data {
        font-size: 20px;
        color: #d9534f
    }

    table tr td {
        vertical-align: baseline;
    }

    .required-field {
        /*background-color: #fda;*/
    }

    .k-grid td {
        padding: 0px 10px;
        height: 28px;
    }

    label {
        margin: 0;
    }

    table tr td {
        padding-top: 10px;
    }

    .k-combobox > .k-dropdown-wrap > .k-i-close {
        color: black;
    }

    .k-grid-header th.k-state-focused .k-link {
        color: #FFF !important;
    }
</style>
<script src="~/Scripts/ExpenseReports/importExpenseReport.js"></script>
<div ng-app="angExpenseReportImport" ng-controller="ExpenseReportImportController">
    <div class="content padding-x">
        <div class="container-fluid" style="padding-left: 4px; padding-right: 4px;">
            <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width: 100%; background-color: #E5E5E5; padding: 8px 0px 8px 0px; border-bottom: 1px solid #CCC; box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05); margin: 5px auto; overflow: auto;">
                <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                    <li>
                        <button class="k-button " ng-class="{'k-primary': showGridData }" ng-click="saveLoadedDataToReport()" ng-disabled="!showGridData">Save Loaded Data to Report</button>
                    </li>
                    <li style="padding-top: 8px">
                        <span>Select Template:</span>
                    </li>
                    <li>
                        <select id="templateSelector" style="width:241px;"
                                ng-disabled="showMatchingTable || showGridData"
                                kendo-combo-box
                                k-options="templateOptions"
                                ng-model="selectedTemplate"></select>

                    </li>
                    <li style="padding:0">
                        <input ng-disabled="fileContent!=null && fileContent != ''" id="fileImport" style="background-color:#E5E5E5;margin-left:8px" type="file" file-reader="fileContent" class="k-input" accept=".csv" />
                    </li>
                    <li style="padding-right: 8px !important;">
                        <button ng-disabled="!(fileContent!=null && fileContent != '')" class="k-button" ng-click="cleanSelectedFile()">Reset File</button>
                    </li>
                    <li style="padding-top: 5px">
                        <input type="checkbox" id="firsRowColumns" class="k-checkbox" checked="checked" ng-model="firstRowHasColumnsName" ng-disabled="showMatchingTable || showGridData">
                        <label style="font-weight: normal;" class="k-checkbox-label" for="firsRowColumns">First Row Contains Column Names</label>
                    </li>
                </ul>
            </div>
            <div class="row ng-cloak" style="border-style:solid; border-width: 1px;padding:10px;margin:auto;border-radius:3px;border-color:lightgrey">
                <div class="row col-sm-12" style="margin-top:15px;">
                    <div class="col-md-2 ">
                        <div class="wv-employee-box">
                            <div class="body">
                                <div class="row">
                                    <div class="image-container" title="@ViewBag.EmployeeName">
                                        <img id="employeeImage" src='@Url.Action("EmployeePicture", "Utilities")/{{employee.Code}}' />
                                    </div>
                                    <div class="name" title="{{employee.Name}}">
                                        <span class="name-span">{{employee.Name}}</span>
                                    </div>
                                    <div class="button">
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2 ">
                        <div class="row">
                            <span style="font-weight:bold">Invoice Number</span>
                        </div>
                        <div class="row ng-cloak">
                            {{invoiceNumber ? invoiceNumber : 'TBD'}}
                        </div>
                    </div>
                    <div class="col-md-2 ">
                        <div class="row">
                            <span style="font-weight:bold">Report Date</span>
                        </div>
                        <div class="row ng-cloak">
                            {{invoiceDate | date:"MM/dd/yyyy"}}
                        </div>
                    </div>
                    <div class="col-md-2 ">
                        <div class="row">
                            <span style="font-weight:bold">Description</span>
                        </div>
                        <div class="row ng-cloak">
                            {{description}}
                        </div>
                    </div>
                    @*<div class="col-md-6 ">
                            <div class="row">
                                <span style="font-weight:bold">Select template</span>
                            </div>
                            <div class="row ng-cloak">
                                <select id="templateSelector" style="width:241px;"
                                        ng-disabled="showMatchingTable || showGridData"
                                        kendo-combo-box
                                        k-options="templateOptions"
                                        ng-model="selectedTemplate"></select>
                            </div>
                        </div>*@
                </div>
            </div>

            <div class="row" ng-show="showMatchingTable">
                <div id="Button_LoadData_Container" class="col-sm-12" style="padding:15px">
                    <div>
                        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                            <li style="padding:0">
                                <button class="k-button " id="Button_LoadData" ng-click="loadData()">Load Data</button>
                            </li>
                        </ul>
                    </div>
                </div>
                <div id="MatchingGridContainer" class="col-sm-12">
                    <div id="MatchingGrid" kendo-grid="gridMatch" k-options="matchingGridOptions"></div>
                </div>
            </div>

            <div class="row" ng-show="showGridData">
                <div id="buttonRow" class="col-sm-12" style="padding:15px">
                    <div>
                        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                            <li style="padding:0">
                                <label> Auto Fill Column:</label> <select id="columnSelector"
                                                                          kendo-combo-box
                                                                          k-options="columnSelectorOptions"
                                                                          ng-model="selectedColumnForFill"></select>&nbsp;&nbsp;&nbsp;&nbsp;
                            </li>
                            <li>
                                <label>Value:</label>
                            </li>
                            <li ng-show="getVisibleDateField()" style="display:inline-block">
                                <input id="dateTofill" kendo-date-picker k-ng-model="selectedDate"
                                       k-format="'MM/dd/yyyy'" k-parse-formats='["Mddyy", "MMddyy", "Mddyyyy", "MMddyyyy", "MM/dd/yyyy", "MM/d/yy", "M/dd/yy", "M/d/yy", "yyyy-MM-ddTHH:mm:ss"]' />
                            </li>
                            <li ng-show="getVisibleInputField()" style="display:inline-block">
                                <input type="text" class="k-input" id="inputValue" ng-model="valueToFill" />
                            </li>
                            <li ng-show="getVisibleFunctionComboBox()" style="display:inline-block">
                                <select id="cbFillFunction" style="width:280px" kendo-combo-box k-options="functionCodeOptions" ng-model="selectedFunctionCode"></select>
                            </li>
                            <li ng-show="getVisibleJobsComboBox()" style="display:inline-block">
                                <select id="cbJobfun" style="width:280px" kendo-combo-box k-options="jobCodeOptions" ng-model="selectedJobCode"></select>
                            </li>
                            <li ng-show="getVisibleJobsComponentComboBox()" style="display:inline-block">
                                <select id="cbJobComp" style="width:280px" kendo-combo-box k-options="jobComponentCodeOptions" ng-model="selectedJobComponentCode"></select>
                            </li>
                            <li>
                                <button class="k-button " style="margin-left:10px;" ng-click="fillColumn()">Update</button>
                            </li>
                            <li style="padding:0">
                                <input type="checkbox" id="flipSign" class="k-checkbox" ng-click="handleSign()" ng-model="flipSign">
                                <label style="font-weight: normal;" class="k-checkbox-label" for="flipSign">Reverse Sign on All Rows</label>
                            </li>
                            <li>
                                <button class="k-button " ng-click="removeInvalidDataFromGrid()">Clear Invalid Fields</button>
                            </li>
                        </ul>
                    </div>
                </div>
                <div id="ExpenseReportsGridContainer" class="col-sm-12">
                    <div id="ExpenseReportsGrid" kendo-grid="grid" k-options="mainGridOptions" k-on-change="handleChange(data, dataItem, columns)"></div>
                </div>
            </div>

            <div class="row" style="display:none;">

                <div class="col-12">
                    tgd:  {{testGridData}}
                </div>
                <div>
                    hasInvalidData = {{hasInvalidData}}
                </div>
            </div>
        </div>
    </div>
</div>

<script>
    @code

        Dim employeeJson = ViewBag.EmployeeJson
        Dim functionCodes = ViewBag.FunctionCodes
        Dim paymentTypes = ViewBag.PaymentTypes
        Dim jobs = ViewBag.Jobs
        Dim templates = ViewBag.ImportTemplates
        Dim defaultPaymentType = ViewBag.DefaultPaymentType

        Dim employee = Newtonsoft.Json.JsonConvert.SerializeObject(employeeJson.Data)
        Dim functioncodesList = Newtonsoft.Json.JsonConvert.SerializeObject(functionCodes.Data)
        Dim paymenttypesList = Newtonsoft.Json.JsonConvert.SerializeObject(paymentTypes.Data)
        Dim jobsList = Newtonsoft.Json.JsonConvert.SerializeObject(jobs.Data)
        Dim templatesList = Newtonsoft.Json.JsonConvert.SerializeObject(templates.Data)
        Dim defaultPaymentTypeItem = Newtonsoft.Json.JsonConvert.SerializeObject(defaultPaymentType)
    End Code

    var invoiceNumber = @Html.Raw(ViewBag.InvoiceNumber);
    var initEmployee = @Html.Raw(employee);

    var initFunctionCodes = @Html.Raw(functioncodesList);
    var initPaymentTypes = @Html.Raw(paymenttypesList);
    var initJobs = @Html.Raw(jobsList);
    var initImportTemplates = @Html.Raw(templatesList);
    var initDescription = "@Html.Raw(ViewBag.Description)";
    var initInvoiceDate = "@Html.Raw(ViewBag.InvoiceDate)";
    var intiDefaultPaymentType = @Html.Raw(defaultPaymentType);
    var initColSettings = [];

    var initHeader = {};
    var initData = [];

    $(() => {
        window.onresize = (e) => {
            var el = $("#Button_LoadData_Container");
            var bottom = el.position().top + el.outerHeight(true);

            if (bottom == 0) {
                el = $("#buttonRow");
                bottom = el.position().top + el.outerHeight(true);
            }

            var viewHeight = $(window).height();

            $('#MatchingGridContainer').height(viewHeight - bottom - 10);

            var kendoGrid = $('#MatchingGrid').data("kendoGrid");
            kendoGrid.resize();

            $('#ExpenseReportsGridContainer').height(viewHeight - bottom - 10);

            var mainKendoGrid = $('#ExpenseReportsGrid').data("kendoGrid");
            mainKendoGrid.resize();
        }
    });

    function closeDialog(invoiceNumber, importrows) {

        $("#importwindow").html("");
        window.parent.closeImportDialogAndReloadReport(invoiceNumber, importrows);
    }
    

</script>
<script type="text/x-kendo-template" id="template">
    <div class="refreshBtnContainer" style="float:left;">
        <button tabindex="-1" type="button" class="k-button wv-icon-button wv-cancel btn-sm" ng-click="deleteRecord()" ng-class="{'k-state-disabled': !reportDetailsSelectedRow() || approvedReport() }" ng-disabled="!reportDetailsSelectedRow() || approvedReport()" title="Delete Row"><span class="glyphicon wvi wvi-delete"></span></button>
    </div>
    <div class="clear-fix"></div>
</script>
