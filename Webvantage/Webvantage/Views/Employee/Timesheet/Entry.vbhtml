@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.NewEntryViewModel
@Code ViewData("Title") = "Time Sheet Entry"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<link href="~/CSS/timesheet.entry.mvc.min.css" rel="stylesheet" />
<style>
/*    body {
      overflow: hidden !important;
    }
*/ 
    .ms-tag {
        text-align: left !important;
        overflow: hidden !important;
        text-overflow: ellipsis !important;
    }
    .k-multiselect-wrap {
        text-align: left !important;
    }
    .k-multiselect-wrap ul {
        text-align: left !important;
    }
    .k-multiselect-wrap li {
        text-align: left !important;
        /*
        white-space: nowrap !important;
        overflow: hidden !important;
        text-overflow: ellipsis !important;
        */
    }
</style>
<div id="postperiod-warning" class="alert alert-warning" role="alert" style="display: none; margin-bottom: 0 !important;">
    <strong>Warning!</strong> Post period for this day is closed.
</div>
<div id="edit-status-warning" class="alert alert-warning" role="alert" style="display: none;margin-bottom: 0 !important;">
    <strong>Warning!</strong> <span id="edit-status-warning-message"></span>
</div>
<table style="margin-left: 0px; width: 100% !important;" border="0">
    <tr>
        <td style="vertical-align: top !important; width: 50%;">
            <div id="client-division-product-container" style="" title="Use this to filter jobs by client, division, and product.">
                <div id="client-filter-container">
                    <div>
                        <label>Client:<span id="client-req-asterisk" style="display: none;">*</span></label>
                    </div>
                    <div id="selectedClientSpanContainer" style="display: none; width: 100%;">
                        <span id="selectedClientSpan" style="width: 100%;"></span>
                    </div>
                    <div id="clientComboBoxContainer" style="display: none;">
                        <select id="clientsMultiSelect" style="width: 100%;" tabindex="1"></select>
                    </div>
                </div>
                <div id="division-filter-container">
                    <div>
                        <label>Division:</label>
                    </div>
                    <div id="selectedDivisionSpanContainer" style="display: none;">
                        <span id="selectedDivisionSpan" style="width: 100%;"></span>
                    </div>
                    <div id="divisionComboBoxContainer" style="display: none;">
                        <select id="divisionsMultiSelect" style="width: 100%;" tabindex="2"></select>
                    </div>
                </div>
                <div id="product-filter-container">
                    <div>
                        <label>Product:</label>
                    </div>
                    <div id="selectedProductSpanContainer" style="display: none;">
                        <span id="selectedProductSpan" style="width: 100%;"></span>
                    </div>
                    <div id="productComboBoxContainer" style="display: none;">
                        <select id="productsMultiSelect" style="width: 100%;" tabindex="3"></select>
                    </div>
                </div>
            </div>
        </td>
        <td style="vertical-align: top !important; width: 50%;">
            <div id="job-assignment-container" style="">
                <div id="jobs-container" style="" title="Job for time entry.  Leave blank to save indirect time.">
                    <div>
                        <label>Job:</label>
                    </div>
                    <div id="selectedJobSpanContainer" style="display: none;">
                        <span id="selectedJobSpan" style="width: 100%;"></span>
                    </div>
                    <div id="jobsComboBoxContainer" style="display: none;">
                        <select id="jobsMultiSelect" style="width: 100%;" tabindex="4"></select>
                        <div id="client-req-msg-container" style="display: none;">
                            <span id="client-req-msg" style="font-style: italic;"></span>
                        </div>
                    </div>
                </div>
                <div id="assignments-container" style="" title="Assignment associated to job.">
                    <div>
                        <label>Assignment:</label>
                    </div>
                    <div id="jobAssignmentsSpanContainer" style="display: none;">
                        <span id="jobAssignmentsSpan" style="width: 100%;"></span>
                    </div>
                    <div id="jobAssignmentsListContainer" style="display: none;">
                        <select id="jobAssignmentsComboBox" style="width: 100%;" tabindex="5"></select>
                        <select id="jobAssignmentsMultiSelect" style="width: 100%; display:none;" tabindex="5"></select>
                    </div>
                </div>
            </div>
            <div id="function-category-container" style="padding: 0px 0px 0px 2px; display:inline-block; width: 100%;" title="Direct time function.">
                <div>
                    <label id="functionCategoryLabel">Function:</label>
                </div>
                <div id="functionCategorySpanContainer" style="display: none;">
                    <span id="functionCategorySpan" style="width: 100%;"></span>
                </div>
                <div id="functionCategoryComboBoxContainer" style="display: none;">
                    <select id="functionCategoryComboBox" style="width: 100%;" tabindex="6" />
                    <select id="functionCategoryMultiSelect" style="width: 100%;" tabindex="6"></select>
                </div>
            </div>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top !important; width: 50%;">
            <div style="padding: 0px 0px 0px 0px; display:inline-block;" title="Time entry date.">
                <div>
                    <label>Date:</label>
                </div>
                <div id="dateSpanContainer" style="display: none;">
                    <span id="dateSpan"></span>
                </div>
                <div id="dateDatePickerContainer">
                    @(Html.Kendo.DatePickerFor(Function(Model) Model.Entry.Date).Format("d").Name("EntryDate").HtmlAttributes(New With {.tabindex = "7", .style = "width: 125px;", .data_shortdate = "", .title = "Select a date for this entry"}).Enable(True).Footer(False))
                </div>
            </div>
        </td>
        <td style="vertical-align: top !important;">
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;" colspan="2">
            <table style="width: 100%;">
                <tr>
                    <td style="vertical-align: top;">
                        <div style="display:inline-block; padding-top: 10px;width:100%" title="Comments for the entry.">
                            <div style="width: 100%;">
                                <label>Comments:</label>
                            </div>
                            <div style="width: 100%;">
                                <textarea id="commentsInput" class="comments-textarea" tabindex="8"></textarea>
                                <textarea id="commentsInputDefault" style="display: none !important;" tabindex="-1"></textarea>
                            </div>
                        </div>

                    </td>
                    <td style="vertical-align: top; width: 40px;">
                        <div style="display:inline-block; padding-top: 10px; padding-left: 8px;" title="Hours for the entry.">
                            <div>
                                <label>Hours:</label>
                            </div>
                            <div>
                                <input id="hoursInput" onfocus="this.select();" class="hours-textbox" tabindex="9" onkeyup="hoursKeyUp(this)" />
                                <input id="hoursInputDefault" style="display: none !important;" tabindex="-1" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="vertical-align: top;" colspan="2">
            <div id="checkBoxSaveAsTemplateContainer" style="float: left; display: inline-block; margin-top: 30px;" title="Check to save as a template item you can reuse later.">
                @Html.EJ().CheckBox("CheckBoxSaveAsTemplate").Value("saveAsTemplate").Size(Size.Medium).ClientSideEvents(Sub(evt)
                                                                                                                             evt.Change("checkBoxSaveAsTemplateChanged")
                                                                                                                         End Sub).HtmlAttributes(New Dictionary(Of String, Object) From {{"tabindex", "-1"}})
                Save to Template
            </div>
            <div style="float: right; display: inline-block; margin-top: 30px; margin-right:0px;" title="Actions.">
                <div id="buttonsContainer" class="k-button-group">
                    <button id="newEntryDialogCancel" class="k-button" tabindex="11" title="Cancel">Cancel</button>
                    <button id="newEntryDialogSave" class="k-button k-primary" tabindex="10">Start Stopwatch</button>
                </div>
                <div id="buttonMessageContainer" class="k-button-group" style="display: none;">
                    <img src="~/CSS/Material/PleaseWait/spinner.gif" />
                </div>
            </div>
        </td>
    </tr>
</table>
<script>
    //  Variables
    var employeeCode = '@Html.Raw(ViewData("EmployeeCode"))';
    var employeeDefaultFunctionCode = '@Html.Raw(ViewData("EmployeeDefaultFunctionCode"))';
    var taskFunctionCode = "";
    var isDirectTime = false;
    var entryDate = new Date();
    var hours = 0.00;
    var comment = "";
    var employeeTimeId = 0;
    var employeeTimeDetailId = 0;
    var clientCode = "";
    var divisionCode = "";
    var productCode = "";
    var jobNumber = 0;
    var jobComponentNumber = 0;
    var taskSequenceNumber = -1;
    var functionCategoryCode = "";
    var departmentTeamCode = "";
    var alertId = 0;
    var isStopwatch = true;
    var isValidInput = true;
    var isDirectTime = false;
    var timeType = "N";
    var timeTypeChanged = false;
    var isEdit = false;
    var isTrueNewEntry = false;
    var editFlag = 0;
    var hasStopwatch = false;
    var assignmentIsRequired = false;
    var commentsRequired = false;
    var agencyCommentsRequired = false;
    var canDelete = true;
    var functionEditSet = false;
    var jobEditSet = false;
    var assignmentEditSet = false;
    var dateEditSet = false;
    var jobAssignmentsSpanContainerVisible = false;
    var functionTypeChanged = false;
    var templateToolTip = "Save this entry as a time template item that can be quickly reused.";
    var saveAsTemplate = false;
    var useCopyTimesheetFeature = false;
    var jobsLoaded = false;
    var jobsList;
    var functionCategoryDataSourceURL = window.appBase + "Employee/Timesheet/GetFunctionsAndCategories";
    var currentCDPKey = "";
    var cdpChangedByJobChange = false;
    var jobCount = 0;
    var jobLimit = 25000;
    var isOverJobLimit = false;
    var hasClient = true;
    var hasDivision = false;
    var hasProduct = false;
    var postPeriodIsClosed = false;
    var dayIsAvailable = true;
    var unlockDateControl = false;
    var last = "";
    var descriptionOnlyTemplate = '<span class="selected-value" style="" title="#:data.Description#">#:data.Description#</span>';
    var isClientReset = false;
    var serverFilterValue = "";
    var isJobInit = true;
    var functionListHasDefault = false;
    //  Init from server
    employeeCode = '@Html.Raw(ViewData("EmployeeCode"))';
    employeeDefaultFunctionCode = '@Html.Raw(ViewData("EmployeeDefaultFunctionCode"))';
    isDirectTime = @Html.Raw(ViewData("IsDirectTime").ToString.ToLower);
    assignmentIsRequired = @Html.Raw(Model.AssignmentIsRequired.ToString.ToLower);
    commentsRequired = @Html.Raw(Model.CommentIsRequired.ToString.ToLower);
    agencyCommentsRequired = @Html.Raw(Model.CommentIsRequired.ToString.ToLower);
    //  Init
    $(document).ready(function () {
        //initControls();
        var qs = getQueryString();
        if (qs) {
            initQueryString(qs);
            if (qs.AlertID && isNaN(qs.AlertID) === false && qs.AlertID * 1 > 0) {
                alertId = qs.AlertID * 1;
                // From link that was going to Aurelia page
                var data = {
                    AlertID: alertId
                };
                $.get({
                    url: window.appBase + "Employee/Timesheet/GetEntryDetailsFromAlertID",
                    dataType: "json",
                    data: data
                }).always(function (response) {
                    if (response) {
                        //console.log(response);
                        jobNumber = response.JobComponentNumber;
                        jobComponentNumber = response.JobComponentNumber;
                        timeType = response.TimeType;
                        functionCategoryCode = response.FunctionCategoryCode;
                    }
                    init();
                });
            } else {
                initQueryString(qs);
                init();
            }
        } else {
            initQueryString(qs);
            init();
        }
        try {
            $("#jobsComboBox").data("kendoComboBox").input.focus();
        } catch (e) {
        }
    });
</script>
@Scripts.Render("~/JScripts/timesheet.entry.mvc.js")
