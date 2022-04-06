@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule
@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<script type="text/javascript" src="~/JScripts/projectschedule.mvc.js"></script>
<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/Scripts/jszip.min.js")"></script>
<script src="@Url.Content("~/JScripts/EstimatedScheduleDlg.js")"></script>

<style>
    .container {
        max-width: none;
        width: 100%
    }

    .sticky {
        position: sticky;
        position: -webkit-sticky;
        left: 28px;
        letter-spacing: 1px;
    }

    .k-content .form-horizontal .form-group {
        margin-left: 0;
        margin-right: 0;
    }

    #ScheduleToolBar {
        border-style: solid !important;
        border-width: 1px !important;
        border-color: #ccc !important;
        font-family: "Open Sans", Calibri, Tahoma, Verdana, Arial, sans-serif !important;
        padding: .57142857em .37142857em !important;
        border-radius: 4px !important;
        background: #e5e5e5 !important;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05) !important;
        margin-top: 5px !important;
        margin-bottom: 15px !important;
        margin-left: auto;
        margin-right: auto;
    }

        #ScheduleToolBar .wvi-floppy-disk {
            font-size: 22px;
        }

    .k-button-icon, .k-split-button-arrow {
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

    #JobsThatPrecede, #JobsThatFollow {
        padding: 0;
        margin: 0;
        overflow: auto;
    }

        #JobsThatPrecede option, #JobsThatFollow option {
            padding: 5px;
        }

    .toolbar-custom-drop {
        padding: 5px;
        display: none;
    }

        .toolbar-custom-drop .k-button {
            width: 100%;
        }

        .toolbar-custom-drop tbody td {
            padding: 2px 8px 2px 8px !important;
        }

            .toolbar-custom-drop tbody td:first-child {
                padding-left: 2px !important;
            }

            .toolbar-custom-drop tbody td:last-child {
                padding-right: 2px !important;
            }

    #myOverlay {
        display: none;
    }

    .dropdown-header {
        border-width: 0 0 1px 0;
        text-transform: uppercase;
    }

        .dropdown-header > span {
            display: inline-block;
            padding: 10px 5px 10px 0px;
        }

    div[id^=EstimateFunction] .k-item > span {
        display: inline-block;
        padding: 0px 5px 0px 0px;
    }

        .dropdown-header > span:first-child, div[id^=EstimateFunction] .k-item > span:first-child {
            width: 75px;
        }

    #gridToolBarWrap {
        z-index: 999;
        width: 100% !important;
    }

    textarea {
        resize: none !important;
    }

    /* The container <div> - needed to position the dropdown content */
    .dropdown {
        position: relative;
        display: inline-block;
    }

    /* Dropdown Content (Hidden by Default) */
    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f1f1f1;
        min-width: 160px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
        z-index: 10000;
    }

        /* Links inside the dropdown */
        .dropdown-content a {
            color: black;
            padding: 12px 16px;
            text-decoration: none;
            display: block;
            font-size: 12px;
        }

            /* Change color of dropdown links on hover */
            .dropdown-content a:hover {
                background-color: #ddd;
            }

    /* Show the dropdown menu on hover */
    .dropdown:hover .showDropdown {
        display: block;
    }

    .k-checkbox-label {
        font-weight: normal;
    }

    .k-widget.k-window .k-window-titlebar {
        border-bottom: #2196f3 3px solid;
    }
</style>

<link href="~/CSS/timesheet.mvc.min.css" rel="stylesheet" />

<div id="mainFrame">
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width:calc(100vw - 40px);background-color: #E5E5E5;padding: 10px 10px 10px 10px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px; overflow:auto;">
        <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
            <li id="Save" style="padding:4px">
                <button id="saveButton" class="k-button wv-icon-button wv-save k-state-disabled" title="Save changes" onclick="setSave()"><span class='wvi wvi-floppy-disk'></span></button>
            </li>
            <li id="Cancel" style="padding:4px">
                <button id="cancelButtonVis" class="wv-icon-button k-button wv-cancel k-state-disabled" onclick="cancleChanges()" title="Cancel"><span class='wvi wvi-sign-forbidden'></span></button>
                <button id="cancelButton" style="display:none" />
            </li>
            <li id="UpdateStatus" style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral " onclick="updateStatus()" style="width: 100px !important;" title="Update Status"><span style="font-size: 12px;">Update Status</span></button>
            </li>
            <li id="Order" style="padding:4px">
                <button id="OrderPredecessor" class="k-button wv-icon-button wv-neutral " onclick="changeCalc()" style="width: 80px !important;font-size: 12px;" title="Order"><span id="OrderPredecessorSpan" style="font-size: 12px;">Order</span></button>
            </li>
            <li id="VersionsItem" style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral " onclick="Versions()" style="width: 80px !important;" title="Versions"><span style="font-size: 12px;">Versions</span></button>
            </li>
            <li id="EstimatedScheduleItem" style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral " onclick="EstimatedScheduleDlg()" style="width: 150px !important;" title="Estimated Schedule"><span style="font-size: 12px;">Estimated Schedule</span></button>
            </li>
            <li id="copyToListItem" style="padding:4px">
                @*@Model.JobTypeCode*@
                <button class="k-button wv-icon-button wv-neutral " onclick="CopyToProjectSchedules(@Model.JobNumber, @Model.JobComponentNumber,null)" style="width: 80px !important;" title="Copy To"><span style="font-size: 12px;">Copy To</span></button>
            </li>
            <li style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral" onclick="print()" style="width: 80px !important;" title="Print"><span style="font-size: 12px;">Print/Send</span></button>
            </li>
            <li style="padding:4px">
                <button class="k-button wv-icon-button wv-settings" onclick="openSettings()"><span class='glyphicon glyphicon-cog' title="Settings" style="font-size: 18px;"></span></button>
            </li>
            <li id="Bookmark" style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>
            <li style="padding:4px">
                <button class="k-button wv-icon-button wv-neutral" onclick="refresPage()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
                <button id="refreshProjectSchedule" style="display:none" />
            </li>
        </ul>
        <div class="pull-right">
            <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;"></ul>
        </div>
    </div>

    <div id="ScheduleContainer" style="background-color: white; border-radius: 6px; overflow: auto; padding: 10px 10px 10px 10px;border: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px;height: calc(100vh - 110px); width: calc(100vw - 40px);">
        <div id="JobInfoContainer">
            @Html.Partial("JobInfo", Model)
        </div>

        <div id="GridToolBar" class="wv-bar k-toolbar k-widget " style="background-color: #E5E5E5;padding: 8px 0px 8px 0px;border-bottom: 1px solid #CCC; overflow:visible;margin-top:5px">
            <div>
                <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                    <li id="AddBlankTask" style="padding:3px">
                        <div class="dropdown">
                            <button class="k-button wv-icon-button wv-add-new" onclick="AddTask()" title="Add Task"><span class='glyphicon wvi wvi-navigate-plus'></span></button>
                            <div id="dropdown-content" class="dropdown-content">
                                <a href="#" onclick="AddTask(0)">Add Above</a>
                                <a href="#" id="AddInto" onclick="AddTask(2)">Add Into</a>
                                <a href="#" onclick="AddTask(1)">Add Below</a>
                            </div>
                        </div>
                    </li>
                    <li id="DeleteTask" style="padding:3px">
                        <button id="deleteTaskBtn" class="k-button wv-icon-button wv-cancel k-state-disabled" onclick="deleteTasks()" title="Delete Task"><span class='wvi wvi-delete'></span></button>
                    </li>
                    <li id="CopyTask" style="padding:3px">
                        <button id="copyButton" class="k-button wv-icon-button k-state-disabled" onclick="CopyTaskButtonClick()" title="Copy Task"><span class='wvi wvi-copy'></span></button>
                    </li>
                    <li id="DetailTask" style="padding:3px">
                        <button id="taskDetailButton" class="k-button wv-icon-button k-state-disabled" onclick="TaskDetailButtonClick()" title="Task Details"><span class='wvi wvi-magnifying-glass'></span></button>
                    </li>
                    <li id="CalculateTask" style="padding:3px">
                        <button id="calculateDatesButton" class="k-button wv-icon-button wv-neutral " onclick="calculateDatesClick()" style="width: 100px !important;" title="Calculate Dates"><span style="font-size: 12px;">Calculate</span></button>
                    </li>
                    <li id="OptionsTask" style="padding:3px">
                        <button id="TaskOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showTaskOptions()" style="width: 100px !important;" title="Tasks"><span style="font-size: 12px;">Tasks</span></button>
                    </li>
                    <li id="ReplaceTask" style="padding:3px">
                        <button id="ReplaceButton" class="k-button wv-icon-button wv-neutral " onclick="searchAndReplaceTasks()" style="width: 100px !important;" title="Replace"><span style="font-size: 12px;">Replace</span></button>
                    </li>
                    <li id="DateOptionsTask" style="padding:3px">
                        <button id="DateOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showDateOptions()" style="width: 80px !important;" title="Dates"><span style="font-size: 12px;">Dates</span></button>
                    </li>
                    <li id="EmployeeOptionsTask" style="padding:3px">
                        <button id="EmployeeOptionsButton" class="k-button wv-icon-button wv-neutral " onclick="showEmployeeOptions()" style="width: 80px !important;" title="Employees"><span style="font-size: 12px;">Employees</span></button>
                    </li>
                    <li style="padding:3px">
                        <button id="ExportButton" class="k-button wv-icon-button wv-neutral " onclick="exportToPDF()" title="Export To Excel"><span class='wvi wvi-spreadsheet-sum'></span></button>
                    </li>
                    <li style="padding:0">
                        <button id="ExportButtonPDF" class="k-button wv-icon-button wv-neutral " onclick="exportToPDF()" title="Export To PDF"><span class='wvi wvi-file-pdf-regular'></span></button>
                    </li>
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="expandCollapse()"><span class='wvi wvi-fit_to_height' title="Expand/Collapse"></span></button>
                    </li>
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="clearFilters()"><span class='wvi wvi-undo' title="Clear Column Filters"></span></button>
                    </li>
                </ul>
            </div>

            <div style="margin-left: auto; margin-right: 3px">
                <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="gridClick()" title="Schedule"><span class='glyphicon wvi wvi-text'></span></button>
                    </li>
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="ganttClick()" title="Gantt"><span class='glyphicon wvi wvi-chart_gantt'></span></button>
                    </li>
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="assignmentsClick()" title="Assignments"><span class='glyphicon wvi wvi-users3'></span></button>
                    </li>
                    <li style="padding:3px">
                        <button class="k-button wv-icon-button wv-neutral" onclick="relatedJobsClick()" title="Related Jobs"><span class='glyphicon wvi wvi-elements_cascade'></span></button>
                    </li>
                </ul>
            </div>
        </div>

        <div id="ScheduleWrap" style="height: calc(100vh - 425px);">
            @Html.Partial("ProjectScheduleGrid", Model)
        </div>
        <div id="GanttWrapper" style="height: calc(100vh - 425px);">
            @Html.Partial("ScheduleGantt", Model)
        </div>
        <div id="Assignments" class="row" style="padding: 10px 10px 10px 10px;display:none">
            @Html.Partial("Assignments", Model)
        </div>
        <div id="RelatedJobs" class="row" style="padding: 10px 0px 10px 0px;display:none">
            @Html.Partial("RelatedJobs", Model)
        </div>
    </div>

    <div class="k-overlay" id="myOverlay" style="display:none"></div>
</div>

<div id="dialog"></div>

<div id="kendoWindowComments" style="display:none">
    <div style="width:100%;height:100%">
        <div style="width:100%;height:30%">
            <span>Task Comments</span>
            <textarea id="taskComment" rows="2" cols="20" style="height: 80%; width:-webkit-fill-available;resize:none !important;"></textarea>
        </div>
        <div style="width:100%;height:30%">
            <span>Due Date Comments</span>
            <textarea id="dueDateComment" rows="2" cols="20" style="height: 80%; width:-webkit-fill-available;resize:none !important;"></textarea>
        </div>
        <div style="width:100%;height:30%">
            <span>Revision Comments</span>
            <textarea id="revisedDateComment" rows="2" cols="20" style="height: 80%; width:-webkit-fill-available;resize:none !important;"></textarea>
        </div>
        <div style="text-align:right; width:-webkit-fill-available;height:10%;padding-top:7px">
            <button id="saveCommentsButton">Save</button>
            <button id="cancelCommentsButton">Cancel</button>
        </div>
    </div>
</div>


<div id="TaskOptions" class="toolbar-custom-drop">
    <table>
        <thead>
            <tr>
                <th>Add Tasks</th>
                @*<th>Other Task Actions</th>*@
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    @(Html.Kendo().Button().Name("AddTasksManually").Content("Manually or from list of tasks").Events(Sub(e)
                                                                                                                                  If Model.CanUserEdit = True Then
                                                                                                                                      e.Click("addTasksFromListOfTasks")
                                                                                                                                  End If
                                                                                                                              End Sub).Enable(Model.CanUserEdit))
                </td>
                @*@(Html.Kendo().CheckBox().Name("AutoStatus").Label("Auto Status Default Override").HtmlAttributes(New With {.onchange = "autoStatus()"}).Enable(Model.CanUserEdit))*@
                @*<td>@(Html.Kendo().Button().Name("DeleteSelectedTasks").Content("Delete selected tasks").Events(Sub(e) e.Click("deleteSelectedTasks")).Enable(Model.CanUserEdit))</td>*@
            </tr>
            <tr>
                <td>
                    @(Html.Kendo().Button().Name("AddTaskFromTemplate").Content("From task templates").Events(Sub(e)
                                                                                                                          If Model.CanUserEdit Then
                                                                                                                              e.Click("addTasksFromTaskTemplates")
                                                                                                                          End If
                                                                                                                      End Sub).Enable(Model.CanUserEdit))
                </td>
                @*<td>@(Html.Kendo().Button().Name("SearchAndReplaceTask").Content("Search and replace").Events(Sub(e) e.Click("searchAndReplaceTasks")).Enable(Model.CanUserEdit))</td>*@
            </tr>
            <tr>
                <td>
                    @(Html.Kendo().Button().Name("AddTaskFromSchedule").Content("From an existing schedule").Events(Sub(e)
                                                                                                                                If Model.CanUserEdit Then
                                                                                                                                    e.Click("addTasksFromExistingSchedule")
                                                                                                                                End If
                                                                                                                            End Sub).Enable(Model.CanUserEdit))
                </td>
                @*<td>@(Html.Kendo().Button().Name("FilterTask").Content("Filter").Events(Sub(e) e.Click("filterTasks")))</td>*@
            </tr>
            <tr>
                <td>
                    @(Html.Kendo().Button().Name("AddTaskFromEstimate").Content("Create from estimate").Events(Sub(e)
                                                                                                                           If Model.HasApprovedEstimate AndAlso Model.CanUserEdit Then
                                                                                                                               e.Click("addTasksFromEstimate")
                                                                                                                           End If
                                                                                                                       End Sub).Enable(Model.HasApprovedEstimate AndAlso Model.CanUserEdit))
                </td>
                @*<td>@(Html.Kendo().CheckBox().Name("AutoStatus").Label("Auto Status").HtmlAttributes(New With {.onchange = "autoStatus()"}).Enable(Model.CanUserEdit))</td>*@
            </tr>

        </tbody>
    </table>
</div>

@If Model.CanUserEdit = True Then

    @<div id="DateOptions" class="toolbar-custom-drop">
        <table>
            <thead>
                <tr>
                    <th>Date Actions</th>
                    <th>Set original due Date</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>@(Html.Kendo().Button().Name("MarkTempComplete").Content("Mark temp complete").Events(Sub(e) e.Click("markTempComplete")).Enable(Model.CanUserEdit))</td>
                    <td>@(Html.Kendo().Button().Name("SetDueDateWhereNotSet").Content("Only for tasks where it is not set").Events(Sub(e) e.Click("setOriginalDueDateWhereNotSet")))</td>
                </tr>
                <tr>
                    <td>@(Html.Kendo().Button().Name("ClearDates").Content("Clear Dates").Events(Sub(e) e.Click("clearDatesClick")).Enable(Model.CanUserEdit))</td>
                    <td>@(Html.Kendo().Button().Name("SetDueDateForSelected").Content("Only selected tasks").Events(Sub(e) e.Click("setOriginalDueDateForSelected")).Enable(Model.CanUserEdit))</td>
                </tr>
                <tr>
                    <td>@(Html.Kendo().Button().Name("ClearDatesIncludingOriginal").Content("Clear Dates including Original Due Date").Events(Sub(e) e.Click("clearDatesIncludingOriginalDueDate")).Enable(Model.CanUserEdit))</td>
                    <td>@(Html.Kendo().Button().Name("SetDueDateForAll").Content("For all tasks").Events(Sub(e) e.Click("setOriginalDueDateForAll")).Enable(Model.CanUserEdit))</td>
                </tr>
            </tbody>
        </table>
    </div>

    @<div id="EmployeeOptions" class="toolbar-custom-drop">
        <table>
            <thead>
                <tr>
                    <th>Employee Actions</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>@(Html.Kendo().Button().Name("SetTeamByFunction").Content("Set team by function").Events(Sub(e) e.Click("setEmployeeTeamByFunction")))</td>
                </tr>
                <tr>
                    <td>@(Html.Kendo().Button().Name("SetTeamByRole").Content("Set team by role").Events(Sub(e) e.Click("setEmployeeTeamByRole")))</td>
                </tr>
                <tr>
                    <td>@(Html.Kendo().Button().Name("FindEmployees").Content("Find employees").Events(Sub(e) e.Click("findEmployees")))</td>
                </tr>
                <tr>
                    <td>@(Html.Kendo().Button().Name("ClearAllAssignments").Content("Clear all assignments").Events(Sub(e) e.Click("clearEmployeeAssignments")))</td>
                </tr>
            </tbody>
        </table>
    </div>
End If

@functions
    Private Function AllowPageEdit() As Boolean
        Return Model.CanUserEdit
    End Function

    Private Sub ColumnHelper(ColumnFactory As Fluent.TreeListColumnFactory(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask))

        ColumnFactory.Add().Template("<div></div>") 'used as a filler

    End Sub
End Functions

@Code

    Dim UnityMenuModel As Webvantage.ViewModels.UnityMenuModel = Nothing

    UnityMenuModel = New Webvantage.ViewModels.UnityMenuModel
    UnityMenuModel.JobNumber = Model.JobNumber
    UnityMenuModel.JobComponentNumber = Model.JobComponentNumber
    UnityMenuModel.JobJacketSchedule.Visible = False
    UnityMenuModel.JobJacket.Visible = False
    UnityMenuModel.CurrentPrintPage = "TrafficSchedule_Print.aspx"
    UnityMenuModel.TargetTag = "body"

End Code

@(Html.Action("UnityMenu", "Utilities", UnityMenuModel))


<script>

    $(() => {

        $('#GanttWrapper').hide();

        $('#ExportButtonPDF').hide();

        $('#EmployeeOptions').kendoPopup({
            anchor: $('#EmployeeOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#DateOptions').kendoPopup({
            anchor: $('#DateOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#TaskOptions').kendoPopup({
            anchor: $('#TaskOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            open: (e) => {
                var data = {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber
                };

                $.ajax({
                    type: "GET",
                    url: "@Href("~/ProjectManagement/ProjectSchedule/GetAutoStatus")",
                    data: data,
                    dataType: "json",
                    success: function (response) {
                        if (response === true) {
                            $("#AutoStatus").prop("checked", true);
                        }
                        else {
                            $("#AutoStatus").prop("checked", false);
                        }
                    }
                });
            },
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        setTimeout(() => {
            $("#Status").data("kendoDropDownList").focus();
        }, 50)        

        let _isClientPortal = "@Model.CanUserEdit";

        if (_isClientPortal == "False") {

            $("#UpdateStatus").hide();
            $("#Save").hide();
            $("#Cancel").hide();
            $("#Order").hide();
            $("#VersionsItem").hide();
            $("#EstimatedScheduleItem").hide();
            $("#copyToListItem").hide();
            $("#Bookmark").hide();
            $("#AddBlankTask").hide();
            $("#DeleteTask").hide();
            $("#CopyTask").hide();
            $("#DetailTask").hide();
            $("#CalculateTask").hide();
            $("#OptionsTask").hide();
            $("#ReplaceTask").hide();
            $("#DateOptionsTask").hide();
            $("#EmployeeOptionsTask").hide();
            $("input[type=radio]").prop("disabled", true);
           

            $("#startdate").data("kendoDatePicker").enable(false);
            $("#duedate").data("kendoDatePicker").enable(false);
            $("#completeddate").data("kendoDatePicker").enable(false);
            $("#Status").data("kendoDropDownList").enable(false);
            $("TemplateCB").hide();

            $("#dateShipped").data("kendoDatePicker").enable(false);
            $("#dateDelivered").data("kendoDatePicker").enable(false);
            $("CommentsTextArea").hide();
            //$("gutcomplete").data("kendoNumericTextBox").enable(false);
            //$("#ReceivedBy").data("kendoTextBox").enable(false);
            //$("#Reference").data("kendoTextBox").enable(false);

        }

    });

    function exportToPDF() {
        if (!$('#ScheduleWrap').is(":hidden")) {
            var treeList = $("#treelist").data('kendoTreeList');
            treeList.saveAsExcel();
        }
        else if (!$('#GanttWrapper').is(":hidden")) {
            if (!$("#gantt").is(":hidden")){
                var gantt = $("#gantt").data('kendoGantt');
                gantt.options.pdf.fileName = 'Job @Model.JobNumber.ToString.PadLeft(6, "0")' + '-' + '@Model.JobComponentNumber.ToString.PadLeft(2, "0")' + '-Gantt' ;
                gantt.saveAsPDF();
            }
            else if (!$("#orderGantt").is(":hidden")) {
                var gantt = $("#orderGantt").data('kendoGantt');
                gantt.options.pdf.fileName = 'Job @Model.JobNumber.ToString.PadLeft(6, "0")' + '-' + '@Model.JobComponentNumber.ToString.PadLeft(2, "0")' + '-Gantt' ;
                gantt.saveAsPDF();
            }

        }
    }

    function ganttClick() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(() => {
                    $('#treelist').data('kendoTreeList').dataSource.sync().then(() => {
                        GanttSelected()
                    });
                //}).fail(() => {
                //    taskEdited = false;
                //    setSave();
                //    GanttSelected();
                //});
        }
        else {
            GanttSelected();
        }
    }

    function GanttSelected() {
        $('#ScheduleWrap').hide();
        $('#GanttWrapper').show();
        $('#RelatedJobs').hide();
        $('#OtherInformation').hide();
        $('#Assignments').hide();

        $('#ExportButton').hide();
        $('#ExportButtonPDF').show();

        $('#treelist').data('kendoTreeList').clearSelection();
        getSettingGantt();
        resizeGantt();
        refreshGantt();
    }

    function gridClick() {
        let dfd = jQuery.Deferred();

        $('#GanttWrapper').hide();
        $('#ScheduleWrap').show();
        $('#RelatedJobs').hide();
        $('#OtherInformation').hide();
        $('#Assignments').hide();

        $('#ExportButton').show();
        $('#ExportButtonPDF').hide();

        resizeGrid();
        //redundent redundent
        //refreshGrid().then(() => {
        //    dfd.resolve();
        //});

        return dfd;
    }

    function relatedJobsClick() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(() => {
                    $('#treelist').data('kendoTreeList').dataSource.sync().then(() => {
                        relatedJobsSelected()
                    });
                //}).fail(() => {
                //    taskEdited = false;
                //    setSave();
                //    relatedJobsSelected();
                //});
        }
        else {
            relatedJobsSelected();
        }
    }

    function relatedJobsSelected() {
        $('#GanttWrapper').hide();
        $('#ScheduleWrap').hide();
        $('#RelatedJobs').show();
        $('#OtherInformation').hide();
        $('#Assignments').hide();
        $('#ExportButton').hide();
        $('#ExportButtonPDF').hide();


        $('#treelist').data('kendoTreeList').clearSelection();
    }

    function otherInformationClick() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(() => {
                    $('#treelist').data('kendoTreeList').dataSource.sync().then(() => {
                        otherInformationSelected()
                    });
                //}).fail(() => {
                //    taskEdited = false;
                //    setSave();
                //    otherInformationSelected();
                //});
        }
        else {
            otherInformationSelected();
        }
    }

    function otherInformationSelected() {
        $('#GanttWrapper').hide();
        $('#ScheduleWrap').hide();
        //$('#ScheduleGridGantt').hide();
        $('#RelatedJobs').hide();
        $('#OtherInformation').show();
        $('#Assignments').hide();
        $('#ExportButton').hide();
        $('#ExportButtonPDF').hide();

        $('#treelist').data('kendoTreeList').clearSelection();
    }

    function assignmentsClick() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(() => {
                    $('#treelist').data('kendoTreeList').dataSource.sync().then(() => {
                        assigmentsSelected()
                    });
                //}).fail(() => {
                //    taskEdited = false;
                //    setSave();
                //    assigmentsSelected();
                //});
        }
        else {
            assigmentsSelected();
        }
    }

    function assigmentsSelected() {
        $('#GanttWrapper').hide();
        $('#ScheduleWrap').hide();
        //$('#ScheduleGridGantt').hide();
        $('#RelatedJobs').hide();
        $('#OtherInformation').hide();
        $('#Assignments').show();
        $('#ExportButton').hide();
        $('#ExportButtonPDF').hide();

        $('#treelist').data('kendoTreeList').clearSelection();
    }

    $(window).resize((e) => {
        _resize();
    });

    function _resize() {
        //console.trace();
        console.log('_resize');
        el = $('#JobInfo');
        var bottom = el.offset().top;
        var viewHeight = $(window).height();

        if (el.height() < 35) {
            $('#ScheduleWrap').height(viewHeight - bottom - 125);
            $('#GanttWrapper').height(viewHeight - bottom - 125);
        }
        else if (el.height() <= 163) {
            $('#ScheduleWrap').height(viewHeight - bottom - 255);
            $('#GanttWrapper').height(viewHeight - bottom - 255);
        }
        else {
            $('#ScheduleWrap').height(viewHeight - bottom - 305);
            $('#GanttWrapper').height(viewHeight - bottom - 305);
        }

        resizeGrid();
        resizeGantt();
    }

    function EstimatedScheduleDlg(){
        OpenEstimatedScheduleDlg(@Model.JobNumber,@Model.JobComponentNumber);
    }

    function Versions(){
        var url = 'TrafficScheduleVersion.aspx?jd=1&j=@Model.JobNumber&jc=@Model.JobComponentNumber';
        OpenRadWindow('Versions', url, 0, 0, false, refreshWindow);
    }

    function currentScroll() {
        return 0;
    }

    function showEmployeeOptions() {
        showPopupForElement($('#EmployeeOptions'), $('#EmployeeOptionsButton'));
    }
    function showDateOptions() {
        showPopupForElement($('#DateOptions'), $('#DateOptionsButton'));
    }
    function showTaskOptions() {
        showPopupForElement($('#TaskOptions'), $('#TaskOptionsButton'));
    }
    function showPopupForElement(popUp, anchor) {
        closeAllPopups();
        var popUpData = popUp.data('kendoPopup');
        popUpData.options.anchor = anchor;
        popUpData.open();
        $('#myOverlay').show();
    }
    function closeAllPopups() {
        $('.toolbar-custom-drop').each(function () {
            $(this).data('kendoPopup').close();
        });
        $('#myOverlay').hide();
    }

    function savePS() {

        $('#saveButton').trigger('click');

    }

    function clearDatesClick() {
        clearDates().then(() => {
            taskEdited = false;
            setSave();
            refreshGantt();
            refreshGrid();
        });
    }

    function calculateDatesClick() {
        var datePicker = $("#startdate").data("kendoDatePicker");

        if ($('#CalcStartDate').prop("checked") || CalculateByPredecessor == 1) {
            $('#CalcStartDate').prop("checked", true);
            var StartDate = datePicker.value();
            if (StartDate == null) {
                datePicker.value(new Date());
            }
        }
        else {
            datePicker = $("#duedate").data("kendoDatePicker");
            var DueDate = datePicker.value();
            if (DueDate == null) {
                showKendoAlert("Please enter a due date.");
                return;
            }

        }

        var kendoTreeList = $("#treelist").data("kendoTreeList");
        var data = kendoTreeList.dataSource.data();
        var hasLockedDates = false;
        data.forEach((v, i, a) => {
            if (v.DueDateLock) {
                hasLockedDates = true;
            }
        });

        var kendoTreeList = $("#treelist").data("kendoTreeList");

        console.log(kendoTreeList.dataSource);

        var data = kendoTreeList.dataSource.data();

        console.log(data);

        //var hasLockedDates = false;

        //data.forEach((v, i, a) => {
        //    if (v.DueDateLock) {
        //        hasLockedDates = true;
        //    }
        //});

        //if (hasLockedDates == true) {
        //    showKendoAlert("Tasks with locked due dates will not be recalculated.");
        //}

        if (setSave()) {
            if (onlyDateChange()) {
                var treelist = $('#treelist').data('kendoTreeList')

                kendo.ui.progress(treelist.element, true);

                saveJobInfo().then(() => {
                    calculateDates().then(() => {
                        taskEdited = false;
                        setSave();
                        refreshGantt();
                        kendo.ui.progress(treelist.element, false);
                    });
                });
            }
            else {
                saveJobInfo().then(() => {
                    var treelist = $('#treelist').data('kendoTreeList')

                    kendo.ui.progress(treelist.element, true);

                    treelist.dataSource.sync().done(() => {
                        calculateDates().then(() => {
                            taskEdited = false;
                            setSave();
                            refreshGantt();
                            kendo.ui.progress(treelist.element, false);
                        });
                    });
                });
            }
        }
        else {
            var treelist = $('#treelist').data('kendoTreeList')

            kendo.ui.progress(treelist.element, true);

            calculateDates().then(() => {
                refreshGantt();
                kendo.ui.progress(treelist.element, false);
            });
        }

    }

    function updateStatus() {
        if (setSave()) {
            showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
                .done(function () {
                    $('#saveButton').trigger('click');

                    setTimeout(() => {
                        updateScheduleStatus(@Model.JobNumber, @Model.JobComponentNumber).then(() => {
                            taskEdited = false;
                            setSave();
                        });
                    }, 500);
                })
                .fail(function () {
                    updateScheduleStatus(@Model.JobNumber, @Model.JobComponentNumber).then(() => {
                        taskEdited = false;
                        setSave();
                    });
                });
        }
        else {
            updateScheduleStatus(@Model.JobNumber, @Model.JobComponentNumber);
        }
    }

    function changeCalc() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(function () {
                    $('#saveButton').trigger('click');
                    setTimeout(() => {
                        changeScheduleCalculation(@Model.JobNumber, @Model.JobComponentNumber, CalculateByPredecessor).then(() => {
                            taskEdited = false;
                            setSave();
                        });
                    }, 500);
                @*})
                .fail(function () {
                    changeScheduleCalculation(@Model.JobNumber, @Model.JobComponentNumber, CalculateByPredecessor).then(() => {
                        taskEdited = false;
                        setSave();
                    });
                });*@
        }
        else {
            changeScheduleCalculation(@Model.JobNumber, @Model.JobComponentNumber, CalculateByPredecessor).then(() => {
            });
        }
    }

    function cancleChanges() {

        //$('#cancelButton').trigger('click');

        if (setSave()) {
            showKendoConfirm("Are you sure you want to cancel all unsaved changes on this schedule? You cannot undo this operation.")
                .done(function () {
                    //$('#saveButton').trigger('click');

                    setTimeout(() => {
                        $('#cancelButton').trigger('click');
                    }, 500);
                })
                .fail(function () {
                    //$('#cancelButton').trigger('click');
                });
        }
        else {
            $('#cancelButton').trigger('click');
        }
    }

    function refresPage() {
        if (setSave()) {
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(function () {
                    $('#saveButton').trigger('click');

                    setTimeout(() => {
                        $('#refreshProjectSchedule').trigger('click');
                    }, 500);
                //})
                //.fail(function () {
                //    $('#refreshProjectSchedule').trigger('click');
                //});
        }
        else {
            $('#refreshProjectSchedule').trigger('click');
        }
    }

    function print() {
         var url = 'TrafficSchedule_Print.aspx?pm=0&mode=4&j=@Model.JobNumber&jc=@Model.JobComponentNumber';
        OpenRadWindow('Print/Send Project Schedule', url, 0, 0, false);
    }

    function openSettings() {
        if (setSave()) {
            var jt = '@Html.Raw(Json.Encode(Request.QueryString("JT")))';
            if (!jt) {
                jt = '';
            }
            var url = '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Setup?JT=' + jt + '&j=@Model.JobNumber&jc=@Model.JobComponentNumber';
            //showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(function () {
                    $('#saveButton').trigger('click');
                    setTimeout(() => {
                        OpenRadWindow('Settings/Options', url, 0, 0, false, refreshWindow);
                    }, 500);
                //})
                //.fail(function () {
                //    OpenRadWindow('Settings/Options', url, 0, 0, false, refreshWindow);
                //});
        }
        else {
            var jt = '@Html.Raw(Json.Encode(Request.QueryString("JT")))';
            if (!jt) {
                jt = '';
            }
            var url = '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)Setup?JT=' + jt + '&j=@model.JobNumber&jc=@Model.JobComponentNumber';
            OpenRadWindow('Settings/Options', url, 0, 0, false, refreshWindow);
        }
    }

    function refreshWindow() {
        location.reload();
    }

    function bookmarkPage() {
        var data = {
            JobNumber: @Model.JobNumber,
            JobComponentNumber: @Model.JobComponentNumber
        };
        $.post({
            url: controllerBase + 'BookMarkPagePS',
            dataType: 'json',
            data: data
        }).always(function () {

        });
    }

    function onlyDateChange() {
        var onlyDate = dateChange;

        if (taskDeleted === true ||
            taskEdited === true ||
            taskInserted === true ||
            assigmentsChange === true ||
            jobInfoChange === true ||
            otherInformationChange === true ||
            relatedJobsChange === true) {
            return false;
        }

        if (ScheduleTreeListDataSource) {
            data = ScheduleTreeListDataSource.data();
            $.each(data, (key, value) => {
                //value.isNew() ||
                if (!value.HasChildren && (value.dirty)) {
                    onlyDate = false;
                }
            });
        }

        return onlyDate;
    }

    function setSave() {
        var treeList = $('#treelist').data('kendoTreeList');
        if (treeList) {
            var selected = treeList.select();

            if (selected.length > 0) {
                $('#deleteTaskBtn').removeClass('k-state-disabled');
            }
            else {
                $('#deleteTaskBtn').addClass('k-state-disabled');
            }
        }

        let _isClientPortal = "@Model.CanUserEdit";

        if ((isGridDirty() === true ||
            assigmentsChange === true ||
            jobInfoChange === true ||
            otherInformationChange === true ||
            dateChange === true ||
            relatedJobsChange === true ||
            commentsChange === true) && _isClientPortal !== "False") {
            $("#saveButton").removeClass('k-state-disabled');
            $("#cancelButtonVis").removeClass('k-state-disabled');
            return true;
        }
        else {
            $("#saveButton").addClass('k-state-disabled');
            $("#saveButton").blur();
            $("#cancelButtonVis").addClass('k-state-disabled');
            return false;
        }
    }
</script>
