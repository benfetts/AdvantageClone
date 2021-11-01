//

function toWeeklyTime() {
    //console.log("toWeeklyTime", alertId);
    try {
        var data = {
            AlertID: alertId,
            CreatePriorWeeks: false
        };
        $.get({
            url: window.appBase + "ProjectManagement/Agile/CheckAndUpdateAlertEmployeesAndHours",
            dataType: "json",
            data: data
        }).always(function (result) {
            try {
                if (result) {
                    if (result.Success === false && result.ErrorMessage !== "") {
                        showNotification(result.ErrorMessage);
                    } else {
                        filterGrid();
                    }
                }
            } catch (e) {
                //
            }
        });
    } catch (e) {
        console.log("Error:toWeeklyTime:", e);
    }
}
function toEmployeeTime() {
    try {
        showKendoConfirm("This will remove weekly time entries")
            .done(function () {
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
                            if (result.Success === false && result.ErrorMessage !== "") {
                                showNotification(result.ErrorMessage);
                            } else {
                                filterGrid();
                            }
                        }
                    } catch (e) {
                        //
                    }
                });
            })
            .fail(function () {
            });
    } catch (e) {
        console.log("Error:toEmployeeTime:", e);
    }
}
function checkBoxPastChanged(e) {
    saveShowPastWeeksSetting(e.isChecked).then(() => {
        filterGrid();
    });
}
function checkBoxFutureChanged(e) {
    saveShowFutureWeeksSetting(e.isChecked).then(() => {
        filterGrid();
    });
}
function checkBoxGroupEmployeeChanged(e) {
    saveGroupEmployeesSetting(e.isChecked).then(() => {
        setGridGrouping();
    });
}
function checkBoxGroupWeekChanged(e) {
    saveGroupWeeksSetting(e.isChecked).then(() => {
        setGridGrouping();
    });
}
function saveCreatePriorWeeksSetting(checked) {
    var data = {
        Checked: checked
    };
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/SaveCreatePriorWeeksSetting",
        dataType: "json",
        data: data
    }).always(function (result) {
        try {
            if (result) {
                //
            }
            loading(false);
        } catch (e) {
            loading(false);
        }
    });
}
function saveShowPastWeeksSetting(checked) {
    var dfd = $.Deferred();
    var data = {
        Checked: checked
    };
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/SaveShowPastWeeksSetting",
        dataType: "json",
        data: data
    }).always(function (result) {
        try {
            if (result) {
                //
            }
            loading(false);
        } catch (e) {
            loading(false);
        }
        dfd.resolve();
    });

    return dfd.promise();
}
function saveShowFutureWeeksSetting(checked) {
    var dfd = $.Deferred();
    var data = {
        Checked: checked
    };
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/SaveShowFutureWeeksSetting",
        dataType: "json",
        data: data
    }).always(function (result) {
        try {
            if (result) {
                //
            }
            loading(false);
        } catch (e) {
            loading(false);
        }
        dfd.resolve();
    });

    return dfd.promise();
}
function saveGroupEmployeesSetting(checked) {
    var dfd = $.Deferred();
    var data = {
        Checked: checked
    };
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/SaveGroupEmployeesSetting",
        dataType: "json",
        data: data
    }).always(function (result) {
        try {
            if (result) {
                //
            }
            loading(false);
        } catch (e) {
            loading(false);
        }
        dfd.resolve();
    });

    return dfd.promise();
}
function saveGroupWeeksSetting(checked) {
    var dfd = $.Deferred();

   var data = {
        Checked: checked
    };
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/SaveGroupWeeksSetting",
        dataType: "json",
        data: data
    }).always(function (result) {
        try {
            if (result) {
                //
            }
            loading(false);
        } catch (e) {
            loading(false);
        }
        dfd.resolve();
        });

    return dfd.promise();
}

function refreshGridContent() {
    var gridObj = $("#WorkItemHoursGrid").data("ejGrid");
    gridObj.refreshContent(true);
    console.log("refreshGridContent");
}
function setGridGrouping() {
    try {
        if (hasWeeklyHours === true) {
            groupEmployee = $("#CheckboxGroupEmployee").ejCheckBox("instance").option("checked");
            groupWeek = $("#CheckboxGroupWeek").ejCheckBox("instance").option("checked");
        }
        _setGridGrouping();
    } catch (e) {
        console.log("setGridGrouping:error:", e);
    }
}
function _setGridGrouping() {
    try {
        var gridObj = $("#WorkItemHoursGrid").data("ejGrid");
        if (hasWeeklyHours === true) {
            gridObj.showColumns("Hours");
            gridObj.showColumns("Week of");
            gridObj.hideColumns("Hours Allowed");
            gridObj.hideColumns("% Complete");
            //gridObj.hideColumns("Completed");
            if (groupEmployee === true) {
                gridObj.groupColumn("FullName");
                gridObj.hideColumns("Employee");
            } else {
                gridObj.ungroupColumn("FullName");
                gridObj.showColumns("Employee");
            }
            if (groupWeek === true) {
                gridObj.groupColumn("WeekStart");
                gridObj.hideColumns("Week of");
            } else {
                gridObj.ungroupColumn("WeekStart");
                gridObj.showColumns("Week of");
                gridObj.ungroupColumn("WeekStart");
            }
        } else {
            gridObj.ungroupColumn("FullName");
            gridObj.hideColumns("Hours");
            gridObj.hideColumns("Week of");
            if (hasStartDate === false || hasDueDate === false) {
                gridObj.hideColumns("Available");
                gridObj.hideColumns("Assigned");
                gridObj.hideColumns("Balance");
            } else {
                gridObj.showColumns("Available");
                gridObj.showColumns("Assigned");
                gridObj.showColumns("Balance");
            }
            gridObj.showColumns("Hours Allowed");
            gridObj.showColumns("% Complete");
            gridObj.showColumns("Completed");
            gridObj.showColumns("Employee");
        }
    } catch (e) {
        console.log("_setGridGrouping:error:", e);
    }
}
function filterGrid() {
    var showPast = false;
    var showFuture = false;
    var empInput;
    var emps;
    var showAvailability = false;

    try {
        if ($("#CheckboxPast").ejCheckBox("instance")) {
            showPast = $("#CheckboxPast").ejCheckBox("instance").option("checked");
        }
    } catch (e) {
        showPast = false;
    }
    try {
        if ($("#CheckboxFuture").ejCheckBox("instance")) {
            showFuture = $("#CheckboxFuture").ejCheckBox("instance").option("checked");
        }
    } catch (e) {
        showFuture = false;
    }
    try {
        if ($('#FilterEmployees').data('kendoMultiSelect')) {
            empInput = $('#FilterEmployees').data('kendoMultiSelect');
        }
    } catch (e) {
        empInput = null;
    }
    try {
        if (empInput) {
            emps = empInput.value();
        }
    } catch (e) {
        emps = null;
    }
    try {
        if (!hasWeeklyHours || hasWeeklyHours === null || hasWeeklyHours === undefined) {
            hasWeeklyHours = false;
        }
    } catch (e) {
        hasWeeklyHours = false;
    }
    try {
        if ($("#CheckboxShowAvailability").ejCheckBox("instance")) {
            showAvailability = $("#CheckboxShowAvailability").ejCheckBox("instance").option("checked");
        }
    } catch (e) {
        showAvailability = false;
    }
    var data = {
        SprintHeaderID: thisSprintHeaderId,
        AlertID: thisAlertId,
        ShowPast: showPast,
        ShowFuture: showFuture,
        EmployeeCodes: emps,
        HasWeeklyHours: hasWeeklyHours,
        ShowAvailability: showAvailability
    };
    //console.log("filterGrid", data);
    loading(true);
    $.post({
        url: window.appBase + "ProjectManagement/Agile/FilterHoursGrid",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            //console.log("filterGrid:response:", response);
            if (response.Data && response.Data.Hours) {
                response.Data.Hours.forEach(function (value, index) {
                    if (response.Data.Hours[index].WeekStart) {
                        response.Data.Hours[index].WeekStart = new Date(parseInt(response.Data.Hours[index].WeekStart.substr(6)));
                    }

                    if (response.Data.Hours[index].WeekEnd) {
                        response.Data.Hours[index].WeekEnd = new Date(parseInt(response.Data.Hours[index].WeekEnd.substr(6)));
                    }
                });

                $("#WorkItemHoursGrid").ejGrid({
                    dataSource: response.Data.Hours
                });
            }
            setGridGrouping();
            window.setTimeout(() => {
                if ($("#lastFocus").val()) {
                    //console.log("lastFocus", $("#lastFocus").val())
                    $("#" + $("#lastFocus").val()).focus();
                }
            }, 10);
            loading(false);
        }
    });
}
function filterEmployees() {

}
function loading(show) {
    var element = $(document.body);
    if (element) {
        kendo.ui.progress(element, show);
    }
}
function trackControl(arg) {
    arg.select();
    console.log(arg.id);
    $("#lastFocus").val(arg.id);
}

function gridQueryCellInfo(args) {
    var hoursBalance = 0;
    var hoursLeft = 0;
    var hoursAvailable = 0;
    var hoursAssigned = 0;
    //console.log(args)
    if (args.data) {
        if (args.data.HoursLeft && isNaN(args.data.HoursLeft) === false) {
            hoursLeft = args.data.HoursLeft * 1;
        }
        if (args.data.HoursAvailableForWeek && isNaN(args.data.HoursAvailableForWeek) === false) {
            hoursAvailable = args.data.HoursAvailableForWeek * 1;
        }
        if (args.data.HoursAssignedForWeek && isNaN(args.data.HoursAssignedForWeek) === false) {
            hoursAssigned = args.data.HoursAssignedForWeek * 1;
        }
        if (args.data.HoursBalance && isNaN(args.data.HoursBalance) === false) {
            hoursBalance = args.data.HoursBalance * 1;
        }
    }
    if (hoursLeft < 0) {
        if (args.column.field === "HoursLeft") {
            args.cell.class = "overage";
            args.cell.style.color = "#D32F2F";
            //console.log("HoursLeft in red")
        }
    }
    if (hoursAvailable < hoursAssigned) {
        if (args.column.field === "HoursAssigned") {
            args.cell.class = "overage";
            args.cell.style.color = "#D32F2F";
            //console.log("HoursAssigned in red")
        }
    }
    if (hoursBalance < 0) {
        if (args.column.field === "HoursAssignedForWeek" || args.column.field === "HoursBalance") {
            args.cell.class = "overage";
            args.cell.style.color = "#D32F2F";
            //console.log("HoursAssignedForWeek & HoursBalance in red")
        }
    }
    //if (hoursAssigned == 0) {
    //    hoursAssigned = parseFloat(hoursAssigned).toFixed(2);
    //}
}
function gridActionBegin(args) {
    console.log("gridActionBegin", args);
}
function gridBeginEdit(args) {
    console.log("gridBeginEdit", args);
}
function gridEndEdit(args) {
    console.log("gridEndEdit", args);
}
function gridCellEdit(args) {
    console.log("gridCellEdit", args);
}

function hoursChanged(sprintEmployeeID, textbox, oldValue, employeeCode) {
    console.log("hoursChanged:", thisAlertId, thisSprintHeaderId, sprintEmployeeID, employeeCode, textbox.value);
    if (isNaN(textbox.value) === true) {
        //showKendoAlert("Invalid hours");
        textbox.value = parseFloat(oldValue).toFixed(2);
    } else {
        var newValue = 0.0;
        oldValue = oldValue * 1;
        newValue = textbox.value * 1;
        if (oldValue !== newValue) {
            if (sprintEmployeeID && sprintEmployeeID > 0) {
                var hoursData = {
                    SprintEmployeeID: sprintEmployeeID,
                    Hours: newValue
                };
                //console.log("data", hoursData);
                loading(true);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/UpdateWorkItemHours",
                    dataType: "json",
                    data: hoursData
                }).always(function (result) {
                    try {
                        if (result) {
                            if (result.Success === true) {
                                
                                filterGrid();
                                if (result.Data.HoursAllowed) {
                                    $("#hoursAllowedSpan").text(result.Data.HoursAllowed);
                                }
                                if (result.Data.HoursAllocated) {
                                    $("#hoursAllocatedSpan").text(result.Data.HoursAllocated);
                                }
                            }
                            if (result.Success === false) {
                                console.log("UpdateWorkItemHours:error:", result);
                                showNotification(result.Message, "error");
                                textbox.focus();
                                textbox.select();
                            }
                        }
                        loading(false);
                    } catch (e) {
                        loading(false);
                    }
                });
            } else {
                console.log("save emp hours");
                var empHoursData = {
                    AlertID: thisAlertId,
                    EmployeeCode: employeeCode,
                    Hours: newValue
                };
                //console.log("empHoursData", empHoursData);
                loading(true);
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/UpdateEmployeeHours",
                    dataType: "json",
                    data: empHoursData
                }).always(function (result) {
                    try {
                        if (result) {
                            console.log(result);
                            if (result.Success === true) {
                                filterGrid();
                                if (result.Data.HoursAllowed) {
                                    $("#hoursAllowedSpan").text(result.Data.HoursAllowed);
                                }
                                if (result.Data.HoursAllocated) {
                                    $("#hoursAllocatedSpan").text(result.Data.HoursAllocated);
                                }
                            }
                            if (result.Success === false) {
                                //console.log("FAIL", result);
                                showNotification(result.Message, "error");
                                textbox.focus();
                                textbox.select();
                            }
                        }
                        loading(false);
                    } catch (e) {
                        loading(false);
                    }
                });
            }
        } else {
            textbox.value = parseFloat(oldValue).toFixed(2);
        }
    }
}
