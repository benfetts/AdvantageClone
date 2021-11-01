@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.WeeklyHours
@Code

    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section

@*@code

        If Model.Alert IsNot Nothing Then

        End If

    End Code*@
<style>
    .k-i-calendar {
        height: 32px !important;
    }

    .k-picker-wrap .k-input {
        height: 2.667em !important;
        line-height: 2.667em !important;
        min-height: 2.667em !important;
    }

    .k-picker-wrap {
        height: 2.667em !important;
    }

        .k-picker-wrap .k-select {
            height: 2.667em !important;
            min-height: 2.667em !important;
            line-height: 2.667em !important;
        }
</style>

@Code 
    Dim HasWeeklyHours As Boolean = False
    HasWeeklyHours = ViewData("HasWeeklyHours")
@<div style="display:block; vertical-align: top !important;">
    <table style="width: 100%;">
        <tr>
            <td style="padding-top: 2px; vertical-align: bottom !important; width: 170px;">
                <div title="Allocate hours by employee">
                    @Html.EJ().RadioButton("RadioButtonEmployeeHours").Name("HoursType").ClientSideEvents(Sub(e)
                                                                                                              e.Change("hoursTypeChanged")
                                                                                                          End Sub).Size(RadioButtonSize.Medium).Checked(Not HasWeeklyHours).Enabled(True).Text("Hours by Employee").Value("employee")
                </div>

            </td>
            <td style="padding-top: 2px; vertical-align: bottom !important; width: 160px;">
                <div title="Allocate hours by weeks">
                    @Html.EJ().RadioButton("RadioButtonWeeklyHours").Name("HoursType").ClientSideEvents(Sub(e)
                                                                                                            e.Change("hoursTypeChanged")
                                                                                                        End Sub).Size(RadioButtonSize.Medium).Checked(HasWeeklyHours).Enabled(True).Text("Hours by Week").Value("week")
                </div>

            </td>
            <td style="padding-top: 0px; vertical-align: top !important;">
                <div title="Load Available, Assigned, and Balance Hours">
                    @Html.EJ().CheckBox("CheckboxShowAvailability").Name("showavail").ClientSideEvents(Sub(e)
                                                                                                           e.Change("checkBoxShowAvailabilityChanged")
                                                                                                       End Sub).Size(Size.Small).Checked(Model.ShowAvailability).Enabled(True).Text("Show Availability").Value("show")
                </div>
            </td>
        </tr>
    </table>
</div>
End Code

    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="        width: 100%;
        background-color: #E5E5E5;
        padding: 8px 0px 8px 0px;
        border-bottom: 1px solid #CCC;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);
        margin: 5px auto;
        overflow: auto;">
        <div style="float:left; display: inline-block;">
            <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                <li style="padding:0">
                    <button class=" wv-icon-button k-button k-grid-add wv-add-new" style="        display: none !important;
" onclick="addClick()"><span class='wvi wvi-navigate-plus' title="Automatically add any missing records"></span></button>
                </li>
                <li style="padding:0">
                    <button class="k-button wv-icon-button wv-cancel" style="display: none !important;" onclick="deleteClick()"><span class='wvi wvi-delete' title="Delete all records and start over"></span></button>
                </li>
                <li style="padding:0">
                    <button class="k-button wv-icon-button wv-neutral" onclick="refreshClick()"><span class='wvi wvi-refresh' title="Refresh"></span></button>
                </li>
                <li style="padding:0; display: none !important;">
                    <button class="k-button wv-icon-button wv-neutral" style="width: 90px !important;" onclick="toEmployeeTime()" title="Convert weekly hours to employee hours"><span style="font-size: 12px;">To Employee</span></button>
                </li>
            </ul>
        </div>
        <div style="float:right; display: inline-block; padding-right: 10px; padding-top: 7px;">
            <ul class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
                <li style="padding:0px 12px 0px 0px;">
                    <b style="margin-right: 4px;">Default Hours Allowed:</b><span id="hoursAllowedSpan">@Html.Raw(If(Model.AlertHours.HoursAllowed IsNot Nothing, FormatNumber(Model.AlertHours.HoursAllowed, 2), "--"))</span>
                </li>
                <li style="padding:0px 12px 0px 0px;">
                    <b style="margin-right: 4px;">Hours Allocated:</b><span id="hoursAllocatedSpan">@Html.Raw(If(Model.AlertHours.HoursAllocated IsNot Nothing, FormatNumber(Model.AlertHours.HoursAllocated, 2), "--"))</span>
                </li>
                <li style="padding: 0px 12px 0px 0px;">
                    <b style="margin-right: 4px;">Start Date:</b>@Html.Raw(If(Model.Alert.StartDate IsNot Nothing, CDate(Model.Alert.StartDate).ToShortDateString, "--"))
                </li>
                <li style="padding: 0px 12px 0px 0px;">
                    <b style="margin-right: 4px;">Due Date:</b>@Html.Raw(If(Model.Alert.DueDate IsNot Nothing, CDate(Model.Alert.DueDate).ToShortDateString, "--"))
                </li>
                <li style="padding:0px 12px 0px 0px; display: none !important;">
                    <b>Start Date:</b>@(Html.Kendo.DatePickerFor(Function(Model) Model.Alert.StartDate).Format("d").Name("StartDate").HtmlAttributes(New With {.tabindex = "4", .style = "width: 125px;", .data_shortdate = "", .title = "Assignment start date"}).Enable(True).Footer(False))
                </li>
                <li style="padding:0px 12px 0px 0px; display: none !important;">
                    <b>Due Date:</b>@(Html.Kendo.DatePickerFor(Function(Model) Model.Alert.DueDate).Format("d").Name("DueDate").HtmlAttributes(New With {.tabindex = "4", .style = "width: 125px;", .data_shortdate = "", .title = "Assignment due date"}).Enable(True).Footer(False))
                </li>
            </ul>
        </div>
    </div>

    <script>
    var alertId = 0;
    var hasWeeklyHours = false;
    var hasStartDate = false;
    var hasDueDate = false;
    var acc = false;

    alertId = @Html.Raw(Model.Alert.ID) * 1;
    hasWeeklyHours = @Html.Raw(ViewData("HasWeeklyHours").ToString.ToLower)
    hasStartDate = @Html.Raw(ViewData("HasStartDate").ToString.ToLower)
    hasDueDate = @Html.Raw(ViewData("HasDueDate").ToString.ToLower)

    function hoursTypeChanged(e) {

        if (e.isChecked === true) {
            if (e.model.value === "employee") {
                hasWeeklyHours = false;
                $("#weeklyOptions").hide();
                deleteClick(e);
            } else if (e.model.value === "week") {
                hasWeeklyHours = true;
                $("#weeklyOptions").show();
                addClick(e);
            }
        }
    }
    function checkBoxShowAvailabilityChanged(e) {

        filterGrid();

    }

    function checkBoxPriorWeeksChanged(e) {
        saveCreatePriorWeeksSetting(e.isChecked);

        var data = {
            AlertID: alertId,
            CreatePriorWeeks: e.isChecked
        };
        $.get({
            url: window.appBase + "ProjectManagement/Agile/CheckAndUpdateAlertEmployeesAndHours",
            dataType: "json",
            data: data
        }).always(function (result) {
            try {
                if (result) {
                    hasWeeklyHours = true;
                    if (result.Success == false && result.ErrorMessage != "") {
                        showNotification(result.ErrorMessage);
                    } else {
                        filterGrid();
                    }
                    setGridGrouping();
                }
            } catch (e) {
            }
        });

    }
    function addClick(e) {
        if (!acc) {
            showKendoConfirm("This will create weekly records, continue?")
                .done(function () {
                    //loading(true);
                    var createPriorWeeks = false;
                    createPriorWeeks = $("#CheckBoxPriorWeeks").is(":checked");
                    var data = {
                        AlertID: alertId,
                        CreatePriorWeeks: createPriorWeeks
                    };
                    $.get({
                        url: window.appBase + "ProjectManagement/Agile/CheckAndUpdateAlertEmployeesAndHours",
                        dataType: "json",
                        data: data
                    }).always(function (result) {
                        try {
                            if (result) {
                                hasWeeklyHours = true;
                                if (result.Success == false && result.ErrorMessage != "") {
                                    showNotification(result.ErrorMessage);
                                } else {
                                    filterGrid();
                                }
                                setGridGrouping();
                                //loading(false);
                            }
                        } catch (e) {
                        }
                    });
                })
                .fail(function () {
                    acc = true;
                    $("#RadioButtonWeeklyHours").ejRadioButton({ checked: false });
                    $("#RadioButtonEmployeeHours").ejRadioButton({ checked: true });
                });
        }
        else {
            acc = false;
        }
    }
    function deleteClick(e) {
        if (!acc) {
            showKendoConfirm("This will remove all weekly hours, continue?")
                .done(function () {
                    //loading(true);
                    var data = {
                        AlertID: alertId
                    };
                    $.post({
                        url: window.appBase + "ProjectManagement/Agile/DeleteWorkItemHours",
                        dataType: "json",
                        data: data
                    }).always(function (result) {
                        try {
                            if (result) {
                                hasWeeklyHours = false;
                                if (result.Success == false && result.ErrorMessage != "") {
                                    showNotification(result.ErrorMessage);
                                } else {
                                    filterGrid();
                                }
                                setGridGrouping();
                                //loading(false);
                            }
                        } catch (e) {
                        }
                    });
                })
                .fail(function () {
                    acc = true;
                    $("#RadioButtonEmployeeHours").ejRadioButton({ checked: false });
                    $("#RadioButtonWeeklyHours").ejRadioButton({ checked: true });
                });
        }
        else {
            acc = false;
        }
    }
    function refreshClick() {
        //console.log("refreshClick", alertId);
        filterGrid();
        //var data = {
        //    AlertID: alertId
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/RefreshWeeklyHours",
        //    dataType: "json",
        //    data: data
        //}).always(function (result) {
        //    try {
        //        if (result) {
        //        }
        //    } catch (e) {
        //    }
        //});
    }
    function load() {
        var navUrl = "";
        var createPriorWeeks = false;
        createPriorWeeks = $("#CheckBoxPriorWeeks").is(":checked");
        //$('#timesheet-control').load(navUrl, function (html) {
        //});
    }
    function startDateChanged(e) {
        var startDate;
        //console.log("startDateChanged:e", e);
        startDate = $("#StartDate").data("kendoDatePicker").value();
        if (!startDate || startDate == null || startDate == "" || startDate == undefined) {
            var dp = $("#StartDate").data("kendoDatePicker");
            if (dp) {
                startDate = dp.value(kendo.parseDate(kShortDateStringFromDatePicker(dp)));
            }
        }
        if (startDate) {
            //console.log("startDateChanged:", startDate);
            var data = {
                AlertID: alertId,
                StartDate: startDate
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/UpdateAssignmentStartDate",
                dataType: "json",
                data: data
            }).always(function (result) {
                try {
                    if (result) {
                        //console.log("UpdateAssignmentStartDate:result:", result);
                    }
                } catch (e) {
                    //console.log("UpdateAssignmentStartDate:error:", result);
                }
            });
        }
    }
    function dueDateChanged(e) {
        var dueDate;
        //console.log("dueDateChanged:e:", e);
        dueDate = $("#DueDate").data("kendoDatePicker").value();
        if (!dueDate || dueDate == null || dueDate == "" || dueDate == undefined) {
            var dp = $("#DueDate").data("kendoDatePicker");
            if (dp) {
                dueDate = dp.value(kendo.parseDate(kShortDateStringFromDatePicker(dp)));
            }
        }
        if (dueDate) {
            //console.log("dueDateChanged:", dueDate);
            var data = {
                AlertID: alertId,
                StartDate: startDate
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/UpdateAssignmentDueDate",
                dataType: "json",
                data: data
            }).always(function (result) {
                try {
                    if (result) {
                    }
                } catch (e) {
                }
            });
        }
    }
    function checkDates() {
        //console.log("hasStartDate", hasStartDate);
        //console.log("hasDueDate", hasDueDate);
        var msg = "";
        $("#RadioButtonWeeklyHoursContainer").removeAttr("title");
        if (hasStartDate === false || hasDueDate === false) {
            if (hasStartDate === true && hasDueDate === false) {
                msg = "Missing start date";
            }
            if (hasStartDate === false && hasDueDate === true) {
                msg = "Missing due date";
            }
            if (hasStartDate === false && hasDueDate === false) {
                msg = "Missing start and due date";
            }
            $("#RadioButtonWeeklyHours").ejRadioButton({ enabled: false });
            $("#RadioButtonWeeklyHoursContainer").attr("title", msg);
        } else {
            $("#RadioButtonWeeklyHours").ejRadioButton({ enabled: true });
            $("#RadioButtonWeeklyHoursContainer").attr("title", "Allocate hours by weeks");
        }
    }
    function initControls() {
        var startDatePicker = $("#StartDate").data("kendoDatePicker");
        var dueDatePicker = $("#DueDate").data("kendoDatePicker");
        if (startDatePicker) {
            startDatePicker.bind("change", function (e) {
                startDateChanged(e);
            })
        }
        if (dueDatePicker) {
            dueDatePicker.bind("change", function (e) {
                dueDateChanged(e);
            })
        }
        checkDates();
    }
    $(document).ready(function () {
        initControls();
    });
    </script>
    <div id="ControlRegion" style="margin-top: 12px;">
        @Html.Partial("_HoursGrid", Model, ViewData)
    </div>
