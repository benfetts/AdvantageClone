//  Init
var fromOldUC = false;

function initControls() {
    //console.log("initControls", isEdit, isTrueNewEntry);
    var entryDatePicker = $("#EntryDate").data("kendoDatePicker");
    if (entryDatePicker) {
        entryDatePicker.bind("change", function (e) {
            dateChanged(e);
        });
    }
    if (isTrueNewEntry === true) {
        initClientsMultiSelect();
        initDivisionsMultiSelect();
        initProductsMultiSelect();
        initJobsMultiSelect();
        initJobAssignmentsComboBox();
        initFunctionCategoryComboBox();
    } else {
        if (isEdit === false) {
            if (jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0) {
                timeType = "D";
                setReadOnlyJob();
                initJobAssignmentsComboBox();
                initFunctionCategoryComboBox();
            } else {
                if (functionCategoryCode) {
                    timeType = "N";
                    showClientAndJobContainers();
                    setReadOnlyDate();
                    showDirectTimeContainer();
                }
            }
        }
    }
    $("#hoursInput").keyup(function (e) {
        setSaveButton();
    });
    $("#newEntryDialogSave").click(function (e) {
        saveClick();
    });
    $("#newEntryDialogCancel").click(function (e) {

        if (window.parent.closeDialogs !== undefined) {
            window.parent.closeDialogs();
        } else {
            CloseDialog();
        }

        //try {
        //    if (window.parent) {
        //        if (window.parent.closeDialogs != undefined) {
        //            window.parent.closeDialogs();
        //        } else {
        //            window.parent.CloseThisWindow();
        //        }
        //    }
        //} catch (e) {
        //}
        //try {
        //    if (window) {
        //        window.close();
        //    }
        //} catch (e) {
        //}
    });
    $("#checkBoxSaveAsTemplateContainer").prop("title", templateToolTip);
    setSaveButton();
    getTimesheetAgencySettings();
    if (isTrueNewEntry === true) {
        //loadJobsCount();
    }
}
function getTimesheetAgencySettings() {
    try {
        var data = {
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/GetTimesheetAgencySettings",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log("Entry.vbhtml:GetTimesheetAgencySettings", response);
                useCopyTimesheetFeature = response.UseCopyTimesheetFeature;
                agencyCommentsRequired = response.RequireTimeComments;
                //console.log("agencyCommentsRequired", agencyCommentsRequired);
                setCommentRequiredTextArea();
            }
            if (useCopyTimesheetFeature === false) {
                $("#checkBoxSaveAsTemplateContainer").hide();
            }
        });
    } catch (e) {
        //console.log("initControls:GetTimesheetAgencySettings:error:", e);
    }
}
function initQueryString(qs) {
    if (qs) {
        if (qs.emp) {
            employeeCode = qs.emp;
        }
        if (qs.etid) {
            employeeTimeId = qs.etid;
        }
        if (qs.etdid) {
            employeeTimeDetailId = qs.etdid;
        }
        if (qs.j) {
            jobNumber = qs.j;
        }
        if (qs.jc) {
            jobComponentNumber = qs.jc;
        }
        if (qs.s) {
            taskSequenceNumber = qs.s;
        }
        if (qs.a) {
            alertId = qs.a * 1;
        }
        if (qs.fn) {
            functionCategoryCode = qs.fn;
        }
        if (qs.dtc) {
            departmentTeamCode = qs.dtc;
        }
        if (qs.sd) {
            // entryDate = qs.sd;
        }
        if (jobNumber > 0 && jobComponentNumber > 0) {
            isDirectTime = true;
            timeType = "D";
        } else {
            isDirectTime = false;
            timeType = "N";
        }
        if (qs.new && qs.new * 1 === 1) {
            isTrueNewEntry = true;
        } else {
            isTrueNewEntry = false;
        }
        if (qs.udc) {
            if (qs.udc === "1" || qs.udc === 1) {
                unlockDateControl = true;
            }
        }
        if (qs.hrs && isNaN(qs.hrs) === false) {
            $("#hoursInput").val(kendo.toString(qs.hrs, "n2"));
            $("#hoursInputDefault").val(kendo.toString(qs.hrs, "n2"));
            hours = kendo.toString(qs.hrs, "n2");
        }
        if (qs.Type) {
            type = qs.Type;
        } else {
            type = "";
        }
        if (type === "New") {
            fromOldUC = true;
        }
        //console.log("queryString", qs);
    }
}
function init() {
    var hasJobComponent = false;
    if (employeeTimeId > 0 && employeeTimeDetailId > 0) {
        isEdit = true;
        isTrueNewEntry = false;
    }
    initControls();
    if (isEdit === true) {
        $("#newEntryDialogSave").html("Save");
        isStopwatch = false;
        loadEntry();
        loadComment();
    }
    else {
        if (jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0) {
            hasJobComponent = true;
            try {
                var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
                if (jobsMultiSelect) {
                    jobComponentID = [];
                    jobComponentID[0] = jobNumber + "," + jobComponentNumber
                    jobsMultiSelect.value(jobComponentID[0]);
                    jobsMultiSelect.trigger("change");
                }
            } catch (e) {
                //console.log("init:set job drop value and trigger", e);
            }
            isDirectTime = true;
        }
        if (isDirectTime === true) {
            if (alertId && alertId > 0) {
                var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
                if (jobAssignmentsComboBox) {
                    jobAssignmentsComboBox.value(alertId);
                }
            }
        }
        var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
        if (functionCategoryComboBox) {
            functionCategoryComboBox.value(functionCategoryCode);
        }
        if (isEdit === false && isTrueNewEntry === false && hasJobComponent === false) {
            isStopwatch = false;
            $("#newEntryDialogSave").html("Save");
            showClientAndJobComboBoxs(false);
        }
        else {
            showClientAndJobComboBoxs(true);
        }
        $("#jobAssignmentsListContainer").show();
        $("#functionCategoryComboBoxContainer").show();
    }
    //console.log("init", isEdit, isTrueNewEntry);
    checkPostPeriod();
    setAssignmentAndFunctions();
    setFunctionCategoryLabel();
}
//  Controls
function checkBoxSaveAsTemplateChanged(e) {
    saveAsTemplate = e.isChecked;
    if (e.isChecked === true) {
        $("#newEntryDialogSave").html("Save");
        $("#newEntryDialogSave").prop("title", templateToolTip);
        isStopwatch = false;
    } else {
        setSaveButton();
    }
}
function functionDropDowListDataBound(e) {
    //window.setTimeout(function () {
    //    if (!functionCategoryCode || functionCategoryCode === "") {
    //        if (timeType === "D") {
    //            setTaskFunctionCode();
    //        } else {
    //            unSetDefaultEmployeeCode();
    //        }
    //    } else {
    //        var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
    //        functionCategoryComboBox.value(functionCategoryCode);
    //    }
    //}, 10);
}
function getFunctionCategoryDataSourceRequestParameters() {
    return {
        EmployeeCode: employeeCode,
        TimeType: timeType,
        JobNumber: jobNumber
    };
}
function setFunctionComboBoxDefault() {
    if (!functionCategoryCode || functionCategoryCode === "") {
        if (timeType === "D") {
            setTaskFunctionCode();
        } else {
            unSetDefaultEmployeeCode();
        }
    } else {
        var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
        if (functionCategoryComboBox) {
            functionCategoryComboBox.value(functionCategoryCode);
        }
    }
}
function dateChanged(e) {
    entryDate = $("#EntryDate").data("kendoDatePicker").value();
    if (!entryDate || entryDate === null || entryDate === "" || entryDate === undefined) {
        var dp = $("#EntryDate").data("kendoDatePicker");
        if (dp) {
            dp.value(kendo.parseDate(kShortDateStringFromDatePicker(dp)));
        }
    }
    checkPostPeriod();
}
function setSaveButton() {
    var hoursInput = $("#hoursInput").val();
    if (isEdit === false) {
        if (hoursInput === "" || isNaN(hoursInput) === true) {
            $("#newEntryDialogSave").html("Start Stopwatch");
            $("#newEntryDialogSave").prop("title", "Start a stopwatch.");
            isStopwatch = true;
        } else {
            $("#newEntryDialogSave").html("Save");
            $("#newEntryDialogSave").prop("title", "Save.");
            isStopwatch = false;
        }
    }
}

//  Helpers
function setTaskFunctionCode() {
    if (jobNumber > 0 && jobComponentNumber > 0 && taskSequenceNumber > -1) {
        var data = {
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            TaskSequenceNumber: taskSequenceNumber
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/GetTaskFunctionCodeForTaskTimeEntry",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response && response !== "") {
                taskFunctionCode = response;
                //console.log("setTaskFunctionCode", taskFunctionCode);
                if (taskFunctionCode && taskFunctionCode !== "") {
                    employeeDefaultFunctionCode = taskFunctionCode;
                    var combobox = $("#functionCategoryComboBox").data("kendoComboBox");
                    if (combobox) {
                        combobox.value(taskFunctionCode);
                        var s = "";
                        s = combobox.value();
                        //console.log("s???", s);
                        if (s == "" || s == null) {
                            setDefaultEmployeeFunctionCode();
                        }
                    }
                } else {
                    setDefaultEmployeeFunctionCode();
                }
            } else {
                setDefaultEmployeeFunctionCode();
            }
        });
    } else {
        setDefaultEmployeeFunctionCode();
    }
}
function setDefaultEmployeeFunctionCode() {
    window.setTimeout(function () {
        if (employeeDefaultFunctionCode && employeeDefaultFunctionCode !== "") {
            var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
            if (functionCategoryComboBox) {
                functionCategoryComboBox.value(employeeDefaultFunctionCode);
                var s = "";
                s = functionCategoryComboBox.value();
                if (s == "" || s == null) {
                    functionCategoryComboBox.value(null);
                    functionCategoryComboBox.text(null);
                }
            }
        }
    }, 0);
}
function unSetDefaultEmployeeCode() {
    var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
    if (functionCategoryComboBox) {
        functionCategoryComboBox.value("");
        functionCategoryComboBox.select(-1);
    }
}
function setAssignmentAndFunctions() {
    //console.log("setAssignmentAndFunctions");
    if (timeTypeChanged === true) {
        if (timeType === "D") {
            setTaskFunctionCode();
        } else {
            unSetDefaultEmployeeCode();
        }
    }
    //  Function
    reloadFunctionsComboBox();
    setFunctionComboBoxDefault();
    setReadOnlyFunctionCategory();
    //  Assignment
    //console.log("setAssignmentAndFunctions");
    reloadJobAssignmentsComboBox();
    window.setTimeout(function (e) {
        var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
        //if (typeof jobAssignmentsList !== 'undefined') {
        if (alertId && alertId > 0) {
            jobAssignmentsComboBox.value(alertId);
        } else {
            jobAssignmentsComboBox.value("");
        }
        setReadOnlyAssignment();
        //}       
    }, 250);
    //console.log("end");
}
function reloadJobAssignmentsComboBox() {
    //console.log("reloadJobAssignmentsComboBox", jobNumber, jobComponentNumber);
    var jobAssignmentsDataSourceMod = new kendo.data.DataSource({});
    ////if (jobNumber === 0 || jobComponentNumber === 0) {
    ////    //console.log("reloadJobAssignmentsComboBox:  NEED TO REGET JOB INFO!");
    ////    var jobsComboBox = $("#jobsComboBox").data("kendoComboBox");
    ////    ////if (jobsComboBox && jobsComboBox.value()) {
    ////    ////    //console.log("reloadJobAssignmentsComboBox");
    ////    ////}
    ////    var selectedDataItem;
    ////    try {
    ////        selectedDataItem = $("#jobsComboBox").data("kendoComboBox").dataItem($("#jobsComboBox").data("kendoComboBox").select());
    ////        //console.log("reloadJobAssignmentsComboBox: SELECTED DATA ITEM!!!", selectedDataItem);
    ////    } catch (e) {
    ////        selectedDataItem = null;
    ////    }
    ////    if (selectedDataItem && selectedDataItem.Key) {
    ////        //console.log("reloadJobAssignmentsComboBox", selectedDataItem);
    ////        var values = selectedDataItem.Key.split(",");
    ////        if (values && values.length === 2) {
    ////            jobNumber = values[0] * 1;
    ////            jobComponentNumber = values[1] * 1;
    ////        }
    ////    }
    ////}
    //console.log("reloadJobAssignmentsComboBox", isEdit, isTrueNewEntry);
    if (isEdit === false && isTrueNewEntry === false && type !== "New") {
        jobAssignmentsDataSourceMod = new kendo.data.DataSource({});
        setJobAssignmentsComboBoxDataSource(jobAssignmentsDataSourceMod);
    } else {
        jobAssignmentsDataSourceMod = new kendo.data.DataSource({
            serverFiltering: false,
            transport: {
                read: {
                    url: window.appBase + "Employee/Timesheet/GetJobAssignments?j=" + jobNumber + "&jc=" + jobComponentNumber + "&inclps="
                }
            },
            requestStart: function (e) {
                if (e.type === "read") {
                    //
                }
            },
            requestEnd: function (e) {
                var type = e.type;
                var items = [];
                items = e.response;
                //console.log(442);
            }
        });
        setJobAssignmentsComboBoxDataSource(jobAssignmentsDataSourceMod);
    }
}

//function setUpAfterJobChange(key) {
//    //console.log("setUpAfterJobChange", key);
//    if (key) {
//        var values = key.split(",");
//        if (values && values.length === 2) {
//            jobNumber = values[0] * 1;
//            jobComponentNumber = values[1] * 1;
//        } else {
//            jobNumber = 0;
//            jobComponentNumber = 0;
//        }
//        if (jobNumber > 0 && jobComponentNumber > 0) {
//            if (timeType === "N") {
//                timeTypeChanged = true;
//            } else {
//                timeTypeChanged = false;
//            }
//            timeType = "D";
//            isDirectTime = true;
//            checkJobCommentRequired();
//        } else {
//            if (timeType === "D") {
//                timeTypeChanged = true;
//            } else {
//                timeTypeChanged = false;
//            }
//            timeType = "N";
//            isDirectTime = false;
//            jobNumber = 0;
//            jobComponentNumber = 0;
//            alertId = 0;
//            commentsRequired = false;
//            setCommentRequiredTextArea();
//        }
//    } else {
//        jobNumber = 0;
//        jobComponentNumber = 0;
//    }
//}

function clearAndDisableAssignmentsComboBox() {
    //if (isEdit == false) {
    var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
    if (jobAssignmentsComboBox) {
        jobAssignmentsComboBox.dataSource.data({});
        jobAssignmentsComboBox.text(null);
        jobAssignmentsComboBox.value(null);
        jobAssignmentsComboBox.enable(false);
    }
    //}
}
function closeAndRefresh() {
    try {
        isSaving(false);
        try {
            window.parent.refreshTimesheet();
        } catch (e) {
            try {
                refreshTimesheetTab();
            } catch (e) {
                //
            }
        }
        try {
            window.parent.updateDashboardWeeklyHours();
        } catch (e) {
            try {
                refreshDashboardTime();
            } catch (e) {
                //
            }
        }

        if (window.parent.closeDialogs !== undefined) {
            window.parent.closeDialogs();
        } else {
            CloseDialog();
        }


        //try {
        //    if (window.parent.closeDialogs != undefined) {
        //        window.parent.closeDialogs();
        //    } else {
        //        window.parent.CloseThisWindow();
        //    }
        //} catch (e) {
        //    try {
        //        CloseThisWindow();
        //    } catch (e) {
        //    }
        //}
    } catch (e) {
        //
    }
}
function showClientAndJobContainers(show) {
    if (show === true) {
        $("#client-division-product-container").show();
        $("#jobs-container").show();
    } else {
        $("#client-division-product-container").hide();
        $("#jobs-container").hide();
    }
}
function showDirectTimeContainer() {
    if (timeType === "D") {
        $("#direct-time-container").show();
    } else {
        $("#direct-time-container").hide();
    }
}
function showClientAndJobComboBoxs(show) {
    if (show === true) {
        $("#selectedJobSpanContainer").hide();
        $("#jobsComboBoxContainer").show();
        $("#selectedClientSpanContainer").hide();
        $("#clientComboBoxContainer").show();
        $("#selectedDivisionSpanContainer").hide();
        $("#divisionComboBoxContainer").show();
        $("#selectedProductSpanContainer").hide();
        $("#productComboBoxContainer").show();
    } else {
        $("#selectedJobSpanContainer").show();
        $("#jobsComboBoxContainer").hide();
        $("#selectedClientSpanContainer").show();
        $("#clientComboBoxContainer").hide();
        $("#selectedDivisionSpanContainer").show();
        $("#divisionComboBoxContainer").hide();
        $("#selectedProductSpanContainer").show();
        $("#productComboBoxContainer").hide();
    }
}
function hideClientReq() {
    $("#client-req-asterisk").hide();
    $("#client-req-msg-container").hide();
    $("#client-req-msg").text("");
}
function isSaving(saving) {
    if (saving === true) {
        $("#buttonsContainer").hide();
        $("#buttonMessageContainer").show();
    } else {
        $("#buttonsContainer").show();
        $("#buttonMessageContainer").hide();
        $("#hoursInput").val("");
        setSaveButton();
    }
}

//  Validate
function hoursKeyUp(tb) {
    var hoursValue = 0;
    if (tb.value !== "." && tb.value !== "," && tb.value !== "-" && tb.value !== "-." && tb.value !== "-,") {
        if (jQuery.isNumeric(tb.value) === false) {
            tb.value = "";
            return false;
        }
    }
    if (isNaN(tb.value) === false) {
        hoursValue = tb.value * 1;
    }
    //if (hoursValue && hoursValue > 24) {
    //    hoursValue = 24;
    //    tb.value = hoursValue;
    //}
    //if (hoursValue && hoursValue < -24) {
    //    hoursValue = -24;
    //    tb.value = hoursValue;
    //}
}
function validateInput() {
    isValidInput = true;
    var selectedDataItem;
    try {
        if ($("#EntryDate")[0]) {
            entryDate = $("#EntryDate")[0].value;
        }
        if ($("#hoursInput")) {
            hours = $("#hoursInput").val();
            hours = hours * 1;
        }
        if ($("#commentsInput")) {
            comment = $("#commentsInput").val();
        }
        if (fromOldUC === true) {
            try {
                if (alertId === 0 && jobAssignmentsSpanContainerVisible === false && $("#jobAssignmentsComboBox")) {
                    alertId = $("#jobAssignmentsComboBox").data("kendoComboBox").value();
                    if (isNaN(alertId) === true) {
                        try {
                            selectedDataItem = null;
                            selectedDataItem = $("#jobAssignmentsComboBox").data("kendoComboBox").dataItem($("#jobAssignmentsComboBox").data("kendoComboBox").select());
                        } catch (e) {
                            selectedDataItem = null;
                        }
                        if (selectedDataItem && selectedDataItem.AlertID) {
                            alertId = selectedDataItem.AlertID;
                        }
                    }
                }
                //console.log("alertid??", alertId);
            } catch (e) {
                //
            }
        }
        if (isTrueNewEntry === true) {
            ////try {
            ////    getJobAndComponentNumbersFromComboBox();
            ////} catch (e) {
            ////    //
            ////}
            try {
                if (alertId === 0 && jobAssignmentsSpanContainerVisible === false && $("#jobAssignmentsComboBox")) {
                    alertId = $("#jobAssignmentsComboBox").data("kendoComboBox").value();
                    if (isNaN(alertId) === true) {
                        try {
                            selectedDataItem = null;
                            selectedDataItem = $("#jobAssignmentsComboBox").data("kendoComboBox").dataItem($("#jobAssignmentsComboBox").data("kendoComboBox").select());
                        } catch (e) {
                            selectedDataItem = null;
                        }
                        if (selectedDataItem && selectedDataItem.AlertID) {
                            alertId = selectedDataItem.AlertID;
                        }
                    }
                }
                //console.log("alertid??", alertId);
            } catch (e) {
                //
            }
            try {
                if (!functionCategoryCode || functionCategoryCode === "") {
                    if (isEdit === false && isTrueNewEntry === true && $("#functionCategoryComboBox")) {
                        try {
                            selectedDataItem = null;
                            selectedDataItem = $("#functionCategoryComboBox").data("kendoComboBox").dataItem($("#functionCategoryComboBox").data("kendoComboBox").select());
                        } catch (e) {
                            selectedDataItem = null;
                        }
                        if (selectedDataItem && selectedDataItem.Code) {
                            functionCategoryCode = selectedDataItem.Code;
                        }
                    }
                }
            } catch (e) {
                //
            }
            if (!functionCategoryCode || functionCategoryCode === "") {
                try {
                    selectedDataItem = $("#functionCategoryComboBox").data("kendoComboBox").dataItem($("#functionCategoryComboBox").data("kendoComboBox").select());
                } catch (e) {
                    selectedDataItem = null;
                }
                if (selectedDataItem && selectedDataItem.Code) {
                    functionCategoryCode = selectedDataItem.Code;
                }
            }
        }
        if (!functionCategoryCode || functionCategoryCode === "") {
            if ($("#functionCategoryComboBox")) {
                try {
                    selectedDataItem = $("#functionCategoryComboBox").data("kendoComboBox").dataItem($("#functionCategoryComboBox").data("kendoComboBox").select());
                } catch (e) {
                    selectedDataItem = null;
                }
                if (selectedDataItem && selectedDataItem.Code) {
                    functionCategoryCode = selectedDataItem.Code;
                }
            }
        }
        if (isValidInput === true) {
            if (!alertId || isNaN(alertId) === true || alertId === undefined) {
                alertId = 0;
            }
        }
        if (isValidInput === true) {
            if (hours > 24) {
                //showKendoAlert("Laws of space, time, and astrophysics do not allow a single entry to be more than 24 hours!\n(Unless you really did travel back in time to work extra; in which case, please contact your supervisor/manager...and NASA; they'll probably want a word with you.)");
                window.parent.showNotification("Seriously?  You worked more than 24 hours today on this one entry?", "error");
                isValidInput = false;
            }
        }
        //console.log("validate test", assignmentIsRequired, jobNumber, jobComponentNumber, alertId, isValidInput);
        if (isValidInput === true) {
            if (assignmentIsRequired === true && jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0 && (!alertId || alertId === 0)) {
                var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
                if (jobAssignmentsComboBox) {
                    var assignmentCount = jobAssignmentsComboBox.dataSource.data().length;
                    if (assignmentCount > 0) {
                        window.parent.showNotification("Please select an assignment.", "error");
                        isValidInput = false;
                    }
                } else {
                    //console.log("no jobAssignmentsComboBox");
                }
            }
        }
        if (isValidInput === true && jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0) {
            if (isStopwatch === false && commentsRequired === true) {
                if (!comment || comment.trim() === "" || comment.length === 0) {
                    //console.log("hours?", hours);
                    if (hours && hours !== 0) {
                        window.parent.showNotification("Comment required.", "error");
                        isValidInput = false;
                    }
                }
            }
            //console.log("more validation?");
        }
        if (isValidInput === true) {
            //console.log("more validation?");
            if (!functionCategoryCode || functionCategoryCode === "") {
                if (jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0 && employeeDefaultFunctionCode && employeeDefaultFunctionCode != "") {
                    functionCategoryCode = employeeDefaultFunctionCode;
                } else {
                    isValidInput = false;
                }
            }
            if (!functionCategoryCode || functionCategoryCode === "") {
                window.parent.showNotification("No function/category code!", "error");
                isValidInput = false;
            }
        }
        if (isValidInput === true) {
            //console.log("more validation?");
        }
    } catch (e) {
        isValidInput = true;
    }
    //console.log("validateInput", isValidInput);
}
function checkJobCommentRequired() {
    //console.log("checkJobCommentRequired", jobNumber);
    if (jobNumber > 0) {
        var data = {
            JobNumber: jobNumber
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/IsCommentRequiredJob",
            dataType: "json",
            data: data
        }).always(function (result) {
            commentsRequired = result;
            setCommentRequiredTextArea();
        });
    } else {
        commentsRequired = false;
        setCommentRequiredTextArea();
    }
}
function setCommentRequiredTextArea() {
    //console.log("setCommentRequiredTextArea", agencyCommentsRequired, commentsRequired, jobNumber);
    if (commentsRequired === true) {
        $("#commentsInput").addClass("RequiredInput");
    } else {
        $("#commentsInput").removeClass("RequiredInput");
    }
}
function checkPostPeriod() {
    $("#postperiod-warning").hide();
    postPeriodIsClosed = false;
    entryDate = $("#EntryDate").data("kendoDatePicker").value();
    if (entryDate) {
        var data = {
            EntryDate: kendo.toString(entryDate, 'd')
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/CheckIfPostPeriodIsAvailable",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response && response.PostPeriodIsAvailable === false) {
                $("#postperiod-warning").show();
                postPeriodIsClosed = true;
            } else {
                $("#postperiod-warning").hide();
                postPeriodIsClosed = false;
            }
            if (postPeriodIsClosed === true) {
                $("#newEntryDialogSave").prop("disabled", true);
                $("#newEntryDialogSave").attr("disabled", "disabled");
            } else {
                $("#newEntryDialogSave").prop("disabled", false);
                $("#newEntryDialogSave").removeAttr("disabled");
            }
            checkDayEditStatus();
        });
    }
}
function checkDayEditStatus() {
    $("#edit-status-warning").hide();
    dayIsAvailable = true;
    entryDate = $("#EntryDate").data("kendoDatePicker").value();
    if (entryDate) {
        var data = {
            EmployeeCode: employeeCode,
            EntryDate: kendo.toString(entryDate, 'd')
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/CheckDayEditStatus",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response && response.DayIsAvailable === false) {
                dayIsAvailable = false;
                $("#edit-status-warning").show();
                $("#edit-status-warning-message").text(response.ErrorMessage);
            } else {
                dayIsAvailable = true;
                $("#edit-status-warning").hide();
            }
            if (dayIsAvailable === false) {
                $("#newEntryDialogSave").prop("disabled", true);
                $("#newEntryDialogSave").attr("disabled", "disabled");
            } else {
                if (postPeriodIsClosed === false) {
                    $("#newEntryDialogSave").prop("disabled", false);
                    $("#newEntryDialogSave").removeAttr("disabled");
                }
            }
        });
    }
}

//  Post
function saveClick() {
    validateInput();
    if (isValidInput === true) {
        if (isStopwatch === true) {
            startStopwatch();
        } else {
            if (saveAsTemplate === true) {
                saveEntryAsTimeTemplate();
            }
            if (isEdit === false) {
                addEntry();
            } else {
                updateEntry();
            }
            //if (saveAsTemplate === false) {
            //    if (isEdit === false) {
            //        addEntry();
            //    } else {
            //        updateEntry();
            //    }
            //} else {
            //    saveEntryAsTimeTemplate();
            //}
        }
    }
}
function updateEntry() {
    //console.log("updateEntry");
    var hasChange = false;
    var isDelete = false;
    if ($("#commentsInput").val() !== $("#commentsInputDefault").val() || $("#hoursInput").val() !== $("#hoursInputDefault").val()) {
        hasChange = true;
    }
    //console.log("has change?", hasChange);
    if (hasChange === true) {
        isSaving(true);
        if (!$("#hoursInput").val() || $("#hoursInput").val() === "" || isNaN($("#hoursInput").val()) === true || $("#hoursInput").val() === undefined) {
            isDelete = true;
        }
        if (isDelete === false) {
            var data = {
                IsDirectTime: isDirectTime,
                EmployeeTimeID: employeeTimeId,
                EmployeeTimeDetailID: employeeTimeDetailId,
                Hours: hours,
                Comment: comment,
                FunctionOrCategoryCode: functionCategoryCode,
                DepartmentTeamCode: departmentTeamCode,
                AlertID: alertId
            };
            //console.log("updateEntry", data);
            $.post({
                url: window.appBase + "Employee/Timesheet/UpdateEntry",
                dataType: "json",
                data: data
            }).always(function (result) {
                if (result) {
                    if (result.Success && result.Success === true) {
                        closeAndRefresh();
                    } else {
                        if (result.Message && result.Message !== "") {
                            try {
                                window.parent.showNotification(JSON.parse(result.Message), "error");
                            } catch (e) {
                                window.parent.showNotification(result.Message, "error");
                            }
                        }
                    }
                }
                isSaving(false);
            });
        } else {
            var thisTimeType = "";
            if (isDirectTime === true) {
                thisTimeType = "D";
            } else {
                thisTimeType = "N";
            }
            var deleteInfo = {
                EmployeeTimeID: employeeTimeId,
                EmployeeTimeDetailID: employeeTimeDetailId,
                TimeType: thisTimeType
            };
            //console.log("deleteInfo", deleteInfo);
            $.post({
                url: window.appBase + "Employee/Timesheet/DeleteEntry",
                dataType: "json",
                data: deleteInfo
            }).always(function (result) {
                if (result) {
                    if (result.Success === true) {
                        closeAndRefresh();
                        //hideProgress();
                        //refreshTimesheet();
                        //updateDashboardWeeklyHours();
                    }
                    if (result.Success === false) {
                        showNotification(result.Message);
                    }
                    isSaving(false);
                }
            });
        }
    } else {
        window.parent.showNotification("No change detected");
    }
}
function addEntry() {
    //console.log("addEntry");
    isSaving(true);
    if (employeeTimeId && employeeTimeId > 0 && employeeTimeDetailId && employeeTimeDetailId > 0) {
        updateEntry();
    } else {
        if (!taskSequenceNumber || taskSequenceNumber === undefined || taskSequenceNumber === null || isNaN(taskSequenceNumber) === true || taskSequenceNumber === "") {
            taskSequenceNumber = -1;
        }
        if (!alertId || alertId === undefined || alertId === null || isNaN(alertId) === true || alertId === "") {
            alertId = 0;
        }
        if (!hours || hours === undefined || isNaN(hours) === true) {
            hours = 0;
        }
        var data = {
            EmployeeCode: employeeCode,
            EntryDate: entryDate,
            Hours: hours,
            Comment: comment,
            FunctionOrCategoryCode: functionCategoryCode,
            DepartmentTeamCode: departmentTeamCode,
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            AlertID: alertId
        };
        //console.log("addEntry", data);
        $.post({
            url: window.appBase + "Employee/Timesheet/AddEntry",
            dataType: "json",
            data: data
        }).always(function (result) {
            try {
                if (result) {
                    if (result.Success && result.Success === true) {
                        if (result.Message && result.Message !== "") {
                            if (checkForEstimateWarning(result.Message).hasWarning === true) {
                                window.parent.showNotification(checkForEstimateWarning(result.Message).message, "info");
                                window.setTimeout(function () {
                                    closeAndRefresh();
                                }, 1500);
                            } else {
                                closeAndRefresh();
                            }
                        } else {
                            closeAndRefresh();
                        }
                    } else {
                        if (result.Message && result.Message !== "") {
                            //console.log("FAIL MESSAGE", result.Message);
                            if (parseTimesheetMessage(result.Message).success === false) {
                                window.parent.showNotification(parseTimesheetMessage(result.Message).message, "error");
                            } else {
                                window.parent.showNotification(parseTimesheetMessage(result.Message).message, "info");
                            }
                            isSaving(false);
                        }
                    }
                }
            } catch (e) {
                //
            }
            isSaving(false);
        });
    }
}
function startStopwatch() {
    var data = {
        EmployeeCode: employeeCode
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/HasStopwatch",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            //console.log("stopwatch result", result);
            if (result.StopwatchIsRunning === true) {
                showKendoConfirm("There is a stopwatch already running.<br/>Stop it and start a new stopwatch?")
                    .done(function () {
                        $.post({
                            url: window.appBase + "Employee/Timesheet/StopStopwatch",
                            dataType: "json",
                            data: data
                        }).always(function (result) {
                            if (result) {
                                //console.log("stop?", result);
                                _startStopwatch();
                            }
                        });
                    })
                    .fail(function () {
                        return false;
                    });
            } else {
                _startStopwatch();
            }
        }
    });
}
function _startStopwatch() {
    var data = {
        EmployeeCode: employeeCode,
        EntryDate: entryDate,
        Hours: 0,
        Comments: comment,
        FunctionCode: functionCategoryCode,
        DepartmentTeamCode: departmentTeamCode,
        JobNumber: jobNumber,
        JobComponentNumber: jobComponentNumber,
        AlertID: alertId
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/StartStopwatch",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            if (result.Success && result.Success === true) {
                window.parent.showSuccessNotification("Stopwatch started.");
                try {
                    checkForStopwatch();
                } catch (e) {
                    //
                }
                try {
                    refreshDashboardTime();
                } catch (e) {
                    //
                }
                try {
                    window.parent.refreshTimesheet();
                } catch (e) {
                    //
                }

                if (window.parent.closeDialogs !== undefined) {
                    window.parent.closeDialogs();
                } else {
                    CloseDialog();
                }

                //try {
                //    if (window.parent.closeDialogs != undefined) {
                //        window.parent.closeDialogs();
                //    } else {
                //        window.parent.CloseThisWindow();
                //    }
                //} catch (e) {
                //    try {
                //        CloseThisWindow();
                //    } catch (e) {
                //    }
                //}
            } else {
                if (result.Message && result.Message !== "") {
                    try {
                        window.parent.showNotification(JSON.parse(result.Message), "error");
                    } catch (e) {
                        window.parent.showNotification(result.Message, "error");
                    }
                }
            }
        }
    });
}
function saveEntryAsTimeTemplate() {
    var data = {
        EmployeeCode: employeeCode,
        EntryDate: entryDate,
        Hours: hours,
        Comment: comment,
        FunctionOrCategoryCode: functionCategoryCode,
        DepartmentTeamCode: departmentTeamCode,
        JobNumber: jobNumber,
        JobComponentNumber: jobComponentNumber,
        AlertID: alertId
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/SaveEntryAsTimeTemplate",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            if (result.Success && result.Success === true) {
                //closeAndRefresh();
            } else {
                if (result.Message && result.Message !== "") {
                    window.parent.showNotification(result.Message, "error");
                }
            }
        }
    });
}

//  Get
function loadEntry() {
    var data = {
        IsDirectTime: isDirectTime,
        EmployeeTimeID: employeeTimeId,
        EmployeeTimeDetailID: employeeTimeDetailId
    };
    //console.log("loadEntry data", data);
    $.get({
        url: window.appBase + "Employee/Timesheet/GetTimeEntry",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            isEdit = true;
            //console.log("loadEntry", response);
            if (isNaN(response.EmployeeTimeID) === false && response.EmployeeTimeID * 1 > 0) {
                employeeTimeId = response.EmployeeTimeID * 1;
            }
            if (isNaN(response.EmployeeTimeDetailID) === false && response.EmployeeTimeDetailID * 1 > 0) {
                employeeTimeDetailId = response.EmployeeTimeDetailID * 1;
            }
            if (isNaN(response.EditFlag) === false && response.EditFlag * 1 > 0) {
                editFlag = response.EditFlag * 1;
            }
            if (response.TimeType && response.TimeType !== "") {
                timeType = response.TimeType;
            }
            if (response.HasStopwatch) {
                hasStopwatch = response.HasStopwatch;
            }
            if (response.CommentsRequired) {
                commentsRequired = response.CommentsRequired;
                setCommentRequiredTextArea();
            }
            if (response.CanDelete) {
                canDelete = response.CanDelete;
            }
            if (response.FunctionCategoryCode && response.FunctionCategoryCode !== "") {
                functionCategoryCode = response.FunctionCategoryCode;
                //var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
                //functionCategoryComboBox.value(functionCategoryCode);
            }
            if (response.DepartmentTeamCode && response.DepartmentTeamCode !== "") {
                departmentTeamCode = response.DepartmentTeamCode;
            }
            if (isNaN(response.Hours) === false) {
                $("#newEntryDialogSave").html("Save");
                $("#hoursInput").val(kendo.toString(response.Hours, "n2"));
                $("#hoursInputDefault").val(kendo.toString(response.Hours, "n2"));
            }
            if (isNaN(response.JobNumber) === false && response.JobNumber * 1 > 0) {
                jobNumber = response.JobNumber * 1;
                if (isNaN(response.JobComponentNumber) === false && response.JobComponentNumber * 1 > 0) {
                    jobComponentNumber = response.JobComponentNumber * 1;
                    isDirectTime = true;
                    timeType = "D";
                }
            }
            if (jobNumber === undefined || jobNumber === 0 || jobComponentNumber === undefined || jobComponentNumber === 0) {
                isDirectTime = false;
                timeType = "N";
            }
            showDirectTimeContainer();
            if (isDirectTime === false) {
                commentsRequired = false;
                setCommentRequiredTextArea();
            }
            setFunctionCategoryLabel();
            if (isNaN(response.AlertID) === false && response.AlertID * 1 > 0) {
                alertId = response.AlertID * 1;
            } else {
                alertId = 0;
            }
            if (isTrueNewEntry === false) {
                if (response.ClientDisplay) {
                    $("#client-division-product-container").prop("title", response.ClientDisplay);
                } else {
                    $("#client-division-product-container").prop("title", "Use these to filter jobs by client, division, and product.");
                }
                if (response.ClientName) {
                    $("#selectedClientSpan").text(response.ClientName);
                    $("#client-filter-container").prop("title", response.ClientName);
                } else {
                    $("#client-filter-container").prop("title", "Use this to filter jobs by client.");
                }
                if (response.DivisionName) {
                    $("#selectedDivisionSpan").text(response.DivisionName);
                    $("#division-filter-container").prop("title", response.DivisionName);
                } else {
                    $("#division-filter-container").prop("title", "Use this to filter jobs by division (client required).");
                }
                if (response.ProductName) {
                    $("#selectedProductSpan").text(response.ProductName);
                    $("#filter-filter-container").prop("title", response.ProductName);
                } else {
                    $("#filter-filter-container").prop("title", "Use this to filter jobs by product (client and division required).");
                }
                if (response.JobDisplay) {
                    selectedJob = response.JobDisplay;
                    $("#selectedJobSpan").text(selectedJob);
                    $("#jobs-container").prop("title", selectedJob);
                    showClientAndJobComboBoxs(false);
                    jobEditSet = true;
                } else {
                    $("#jobs-container").prop("title", "Job for time entry.  Leave blank to save indirect ti");
                }
                if (response.AssignmentDisplay) {
                    selectedAssignment = response.AssignmentDisplay;
                    $("#jobAssignmentsSpan").text(selectedAssignment);
                    $("#assignments-container").prop("title", selectedAssignment);
                    $("#assignments-container").show();
                    $("#jobAssignmentsSpanContainer").show();
                    jobAssignmentsSpanContainerVisible = true;
                    $("#jobAssignmentsListContainer").hide();
                } else {
                    $("#assignments-container").hide();
                }
                assignmentEditSet = true;
                if (response.FunctionCategoryDisplay) {
                    selectedFunctionCategory = response.FunctionCategoryDisplay;
                    $("#functionCategorySpan").text(selectedFunctionCategory);
                    $("#functionCategorySpanContainer").show();
                    $("#functionCategoryComboBoxContainer").hide();
                    functionEditSet = true;
                }
                setReadOnlyDate();
                hideClientReq();
            }
        }
    });
}
function loadComment() {
    var data = {
        IsDirectTime: isDirectTime,
        EmployeeTimeID: employeeTimeId,
        EmployeeTimeDetailID: employeeTimeDetailId
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/GetTimeEntryComment",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            if (response.EmployeeComments) {
                $("#commentsInput").val(response.EmployeeComments);
                $("#commentsInputDefault").val(response.EmployeeComments);
            }
        }
    });
}
function loadJobsCount() { //   Only on init!
    isOverJobLimit = false;
    try {
        var data = {
        };
        if (!clientCode || clientCode === null || clientCode === "null" || clientCode === undefined) {
            clientCode = "";
            hasClient = false;
        }
        if (!divisionCode || divisionCode === null || divisionCode === "null" || divisionCode === undefined) {
            divisionCode = "";
            hasDivision = false;
        }
        if (!productCode || productCode === null || productCode === "null" || productCode === undefined) {
            productCode = "";
            hasProduct = false;
        }
        $.get({
            url: window.appBase + "Employee/Timesheet/GetJobsForEmployeeCount?emp=" + employeeCode + "&c=" + clientCode + "&d=" + divisionCode + "&p=" + productCode,
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result && isNaN(result) === false) {
                jobCount = result * 1;
            }
        });
    } catch (e) {
        isOverJobLimit = false;
    }
}

//  Form
function setReadOnlyJob() {
    if (jobEditSet === false) {
        window.setTimeout(function () {
            if (isTrueNewEntry === false) {
                if (jobNumber && jobNumber > 0 && jobComponentNumber && jobComponentNumber > 0) {
                    //console.log("setReadOnlyJob", selectedJob, jobNumber, jobComponentNumber);
                    showClientAndJobComboBoxs(false);
                    var data = {
                        JobNumber: jobNumber,
                        JobComponentNumber: jobComponentNumber
                    };
                    $.get({
                        url: window.appBase + "Employee/Timesheet/GetJobDisplay",
                        dataType: "json",
                        data: data
                    }).always(function (response) {
                        if (response) {
                            //console.log("setReadOnlyJob:response:", response);
                            if (response.JobDisplay) {
                                $("#selectedJobSpan").text(response.JobDisplay);
                                $("#jobs-container").prop("title", response.JobDisplay);
                            }
                            if (response.ClientDivisionProductDisplay) {
                                $("#selectedClientSpan").text(response.ClientDivisionProductDisplay);
                                $("#client-division-product-container").prop("title", response.ClientDivisionProductDisplay);
                            }
                            if (response.ClientName) {
                                $("#selectedClientSpan").text(response.ClientName);
                                $("#selectedClientSpanContainer").prop("title", response.ClientName);
                            }
                            if (response.DivisionName) {
                                $("#selectedDivisionSpan").text(response.DivisionName);
                                $("#selectedDivisionSpanContainer").prop("title", response.DivisionName);
                            }
                            if (response.ProductName) {
                                $("#selectedProductSpan").text(response.ProductName);
                                $("#selectedProductSpanContainer").prop("title", response.ProductName);
                            }
                        }
                    });
                } else {
                    showClientAndJobComboBoxs(true);
                }
            }
            jobEditSet = true;
            setReadOnlyDate();
        }, 5);
    }
}
function setReadOnlyAssignment() {
    if (assignmentEditSet === false) {
        window.setTimeout(function () {
            if (isTrueNewEntry === false) {
                if (alertId && alertId > 0) {
                    var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
                    var selectedAssignment;
                    if (jobAssignmentsComboBox) {
                        selectedAssignment = $("#jobAssignmentsComboBox").data("kendoComboBox").text();
                    }
                    var data = {
                        AlertID: alertId
                    };
                    $.get({
                        url: window.appBase + "Employee/Timesheet/GetAssignmentSubject",
                        dataType: "json",
                        data: data
                    }).always(function (response) {
                        if (response) {
                            //console.log("setReadOnlyAssignment", response);
                            selectedAssignment = response;
                            $("#jobAssignmentsSpan").text(selectedAssignment);
                            $("#assignments-container").show();
                            $("#jobAssignmentsSpanContainer").show();
                            jobAssignmentsSpanContainerVisible = true;
                            $("#jobAssignmentsListContainer").hide();
                        } else {
                            $("#assignments-container").hide();
                        }
                    });
                } else if (type !== "New") {
                    $("#assignments-container").hide();
                }
            } else {
                //console.log("do something else");
            }
            assignmentEditSet = true;
        }, 5);
    }
}
function setReadOnlyFunctionCategory() {
    if (functionEditSet === false) {
        window.setTimeout(function () {
            if (isTrueNewEntry === false && functionCategoryCode && functionCategoryCode !== "") {
                if (functionCategoryCode && functionCategoryCode !== "") {
                    var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
                    if (functionCategoryComboBox) {
                        var selectedFunctionCategory = functionCategoryComboBox.text();
                        var data = {
                            FunctionCategoryCode: functionCategoryCode,
                            IsFunction: isDirectTime
                        };
                        $.get({
                            url: window.appBase + "Employee/Timesheet/GetFunctionCategoryDescription",
                            dataType: "json",
                            data: data
                        }).always(function (response) {
                            if (response) {
                                selectedFunctionCategory = response;
                                $("#functionCategorySpan").text(selectedFunctionCategory);
                                $("#functionCategorySpanContainer").show();
                                $("#functionCategoryComboBoxContainer").hide();
                            }
                        });
                    }
                } else {
                    $("#functionCategoryComboBoxContainer").show();
                    $("#functionCategorySpanContainer").hide();
                }
            }
            functionEditSet = true;
        }, 5);
    }
}
function setReadOnlyDate() {
    if (dateEditSet === false) {
        window.setTimeout(function (e) {
            if (isTrueNewEntry === false) {
                //console.log("set date", kendo.toString($("#EntryDate").data("kendoDatePicker").value(), 'd'));
                $("#dateSpan").text(kendo.toString($("#EntryDate").data("kendoDatePicker").value(), 'd'));
                $("#dateSpan").prop("title", kendo.toString($("#EntryDate").data("kendoDatePicker").value(), 'D'));
                $("#dateSpanContainer").show();
                $("#dateDatePickerContainer").hide();
                $("#commentsInput").focus();
            } else {
                $("#dateSpanContainer").hide();
                $("#dateDatePickerContainer").show();
            }
            if (unlockDateControl === false) {
                $("#dateSpanContainer").hide();
                $("#dateDatePickerContainer").show();
            }
            dateEditSet = true;
        }, 500);
    }
}
function setFunctionCategoryLabel() {
    //console.log("setFunctionCategoryLabel");
    if (isDirectTime === false) {
        $("#functionCategoryLabel").text("Category:");
        $("#function-category-container").prop("title", "Indirect time category.");
        timeType = "N";
        commentsRequired = false;
        setCommentRequiredTextArea();
    } else {
        $("#functionCategoryLabel").text("Function:");
        $("#function-category-container").prop("title", "Direct time function.");
        timeType = "D";
    }
    try {
        var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
        if (jobAssignmentsComboBox) {
            jobAssignmentsComboBox.enable(isDirectTime);
        }
    } catch (e) {
        //
    }
}

//  Dropdowns
var clientInitiated = false;
var clientSearchText = "";
var hasChange = false;
var jobInitiated = false;
var lastJobClient = "";
var lastJobDivision = "";
var lastJobProduct = "";
var backFillInProgress = false;

function getKeyPress(e) {
    var unicode = e.keyCode ? e.keyCode : e.charCode;
    //console.log("unicode", unicode);
}
function initJobAssignmentsComboBox() {
    //console.log("initJobAssignmentsComboBox");
    assignmentMultiSelectDataSource = new kendo.data.DataSource({
        //serverFiltering: true,
        //serverPaging: true,
        //pageSize: 31,
        //schema: {
        //    data: "Divisions",
        //    total: "Total",
        //},
        transport: {
            read: {
                url: window.appBase + "Employee/Timesheet/GetJobAssignments",
                data: function () {
                    var Text = "";
                    //var jobAssignmentsMultiSelect = $("#jobAssignmentsMultiSelect").data("kendoMultiSelect");
                    //if (jobAssignmentsMultiSelect) {
                    //    Text = jobAssignmentsMultiSelect.input.val();
                    //    if (Text == 'Assignment') {
                    //        Text = "";
                    //    }
                    //    if (!resetAssignment) {
                    //        if (Text == "") {
                    //            var dataItems = jobAssignmentsMultiSelect.dataItems();
                    //            if (dataItems && dataItems.length > 0) {
                    //                try {
                    //                    Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                    //                } catch (e) { }
                    //            }
                    //        }
                    //    } else {
                    //        resetAssignment = false;
                    //    }
                    //}
                    //return {
                    //    j: jobNumber,
                    //    jc: jobComponentNumber,
                    //    inclps: false,
                    //    Text: Text
                    //}
                    return {
                        j: jobNumber,
                        jc: jobComponentNumber,
                        inclps: false
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
                //e.preventDefault();
            }
        },
        requestEnd: function (e) {
            //setAssignmentAndFunctions();
            //console.log(1552);
            var type = e.type;
            var items = [];
            items = e.response;
            //console.log(items);
            if (items && items.length > 0) {
                try {
                    window.setTimeout(() => {
                        var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
                        if (jobAssignmentsComboBox) {
                            jobAssignmentsComboBox.focus();
                        }
                    }, 500);
                } catch (e) {
                }
            } else {
                try {
                    window.setTimeout(() => {

                    }, 500);
                } catch (e) {
                }
            }
        }
    });
    try {
        $("#jobAssignmentsComboBox").kendoComboBox({
            animation: false,
            filter: "contains",
            dataTextField: "Description",
            dataValueField: "AlertID",
            //valueTemplate: descriptionOnlyTemplate,
            //template: descriptionOnlyTemplate,
            noDataTemplate: "",
            delay: 750,
            suggest: false,
            dataSource: assignmentMultiSelectDataSource,
            dataBound: function (e) {
                //console.log("jobAssignmentsComboBox:dataBound!")
                setReadOnlyAssignment();
            },
            change: function (e) {
            },
            error: function (xhr, error) {
                console.debug(xhr);
                console.debug(error);
            }
        });
    } catch (e) {
        //console.log("initJobAssignmentsComboBox:error:", e);
    }
}
function initFunctionCategoryComboBox() {
    try {
        var functionFooterTemplate = "";
        var functionNoDataTemplate = "";
        if (timeType === "N") {
            functionNoDataTemplate = "No categories";
        } else {
            functionNoDataTemplate = "No functions";
        }
        $("#functionCategoryComboBox").kendoComboBox({
            animation: false,
            filter: "contains",
            dataTextField: "Description",
            dataValueField: "Code",
            footerTemplate: functionFooterTemplate,
            valueTemplate: '<span class="selected-value" style="" title="#:data.Description#">#:data.Description# (#:data.Code#)</span>',
            template: '<span class="k-state-default" style="" title="#:data.Description# (#:data.Code#)">#:data.Description# (#:data.Code#)</span>',
            noDataTemplate: "",
            delay: 750,
            suggest: false,
            dataBound: function (e) {
                functionDropDowListDataBound(e);
            },
            filtering: function (ev) {
                var filterValue = ev.filter !== undefined ? ev.filter.value : "";
                ev.preventDefault();
                this.dataSource.filter({
                    logic: "or",
                    filters: [
                        {
                            field: "Description",
                            operator: "contains",
                            value: filterValue
                        },
                        {
                            field: "Code",
                            operator: "contains",
                            value: filterValue
                        }
                    ]
                });
            },
            change: functionCategoryComboBoxChanged,
            error: function (xhr, error) {
                console.debug(xhr);
                console.debug(error);
            }
        });
    } catch (e) {
        //console.log("initFunctionCategoryComboBox:error:", e);
    }
}
function setJobAssignmentsComboBoxDataSource(ds) {
    ////console.log("setJobAssignmentsComboBoxDataSource", ds);
    //initJobAssignmentsComboBox();
    //var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
    //if (jobAssignmentsComboBox) {
    //    if (ds === undefined || ds === null) {
    //        ds = new kendo.data.DataSource({});
    //    }
    //    jobAssignmentsComboBox.setDataSource(ds);
    //    jobAssignmentsComboBox.enable(true);
    //}
}
function setFunctionCategoryComboBoxDataSource(ds) {
    initFunctionCategoryComboBox();
    var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
    if (functionCategoryComboBox) {
        functionCategoryComboBox.setDataSource(ds);
        functionCategoryComboBox.enable(true);
    }
}
function reloadFunctionsComboBox() {
    //if (clientID && clientID.length > 0) {
    //    if (timeType === "N") {
    //        timeTypeChanged = true;
    //    } else {
    //        timeTypeChanged = false;
    //    }
    //    timeType = "D";
    //    isDirectTime = true;
    //}
    //console.log("reloadFunctionsComboBox", clientID, timeType, timeTypeChanged, jobNumber, clientCode);
    functionCategoryDataSourceURL = window.appBase + "Employee/Timesheet/GetFunctionsAndCategories";
    var functionCategorDataSourceMod = new kendo.data.DataSource({
        serverFiltering: false,
        transport: {
            read: {
                url: functionCategoryDataSourceURL,
                dataType: "json",
                data: {
                    EmployeeCode: employeeCode,
                    TimeType: timeType,
                    JobNumber: jobNumber,
                    ClientCode: clientCode
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
            }
        },
        requestEnd: function (e) {
            var type = e.type;
            var items = [];
            var found = false;
            var text = "";
            var value = "";
            items = e.response;
            if (items && employeeDefaultFunctionCode !== "") {
                var functionCategoryComboBox = $("#functionCategoryComboBox").data("kendoComboBox");
                for (var i = 0; i < items.length; i++) {
                    if (items[i].Code === employeeDefaultFunctionCode) {
                        functionListHasDefault = true;
                        if (functionCategoryComboBox) {
                            functionCategoryComboBox.value(employeeDefaultFunctionCode);
                            functionCategoryComboBox.text(items[i].Description + ' (' + items[i].Code + ')');
                        }
                        found = true;
                        break;
                    }
                }
                if (found === false) {
                    functionCategoryComboBox.value(null);
                    functionCategoryComboBox.text(null);
                }
            }
        }
    });
    setFunctionCategoryComboBoxDataSource(functionCategorDataSourceMod);
}
function functionCategoryComboBoxChanged(e) {
    var selectedIndex = e.sender.selectedIndex;
    functionCategoryChanged();
}
function functionCategoryChanged() {
    if (timeType === "N") {
        clientCode = "";
        divisionCode = "";
        productCode = "";
        clientID = [];
        divisionID = [];
        productID = [];
        setClientsMultiSelectValue("");
        setDivisionsMultiSelectValue("");
        setProductsMultiSelectValue("");
        //enableClientsMultiSelect(false);
        //enableDivisionsMultiSelect(false);
        //enableProductsMultiSelect(false);
        hasClient = false;
    } else {
        //enableClientsMultiSelect(true);
        //enableDivisionsMultiSelect(true);
        //enableProductsMultiSelect(true);
    }
    try {
        selectedDataItem = null;
        selectedDataItem = $("#functionCategoryComboBox").data("kendoComboBox").dataItem($("#functionCategoryComboBox").data("kendoComboBox").select());
    } catch (e) {
        selectedDataItem = null;
    }
    if (selectedDataItem && selectedDataItem.Code) {
        functionCategoryCode = selectedDataItem.Code;
    }
    //console.log("????", timeType, functionCategoryCode);
}
var clientsMultiSelectDataSource;
var divisionsMultiSelectDataSource;
var productsMultiSelectDataSource;
//var jobsMultiSelectDataSource;
var componentMultiSelectDataSource;
var assignmentMultiSelectDataSource;
var functionCategoryMultiSelectDataSource;

var resetClient;
var resetDivision;
var resetProduct;
var resetJob;
var resetComponent;
var resetAssignment;
var resetFunction;

var clientID = [];
var divisionID = [];
var productID = [];
////var jobID = [];
var jobComponentID = [];
var assignmentID = [];
var functionCategoryID = [];
var codes = [];

function getClientCodeFromMultiSelect() {
    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
    var s = "";
    //try {
    var values;
    values = clientsMultiSelect.value();
    //console.log("getClientCodeFromMultiSelect: values: ", values);
    if (values && values.length > 0) {
        if (values[0].indexOf(",") > -1) {
            var codes = values[0].split(',');
            if (codes && codes.length > 0) {
                s = codes[0];
            }
        } else {
            s = values[0];
        }
    }
    //console.log("getClientCodeFromMultiSelect: s: ", s);
    //} catch (e) {
    //}
    return s;
}
function getDivisionCodeFromMultiSelect() {
    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
    var s = "";
    //try {
    var values;
    values = divisionsMultiSelect.value();
    //console.log("getDivisionCodeFromMultiSelect: values: ", values);
    if (values && values.length > 0) {
        if (values[0].indexOf(",") > -1) {
            var codes = values[0].split(',');
            if (codes && codes.length > 0) {
                s = codes[1];
            }
        } else {
            s = values[0];
        }
    }

    //console.log("getDivisionCodeFromMultiSelect: s: ", s);
    //} catch (e) {
    //}
    return s;
}
function getProductCodeFromMultiSelect() {
    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
    var s = "";
    //try {
    var values;
    values = productsMultiSelect.value();
    //console.log("getProductCodeFromMultiSelect: values: ", values);
    if (values && values.length > 0) {
        if (values[0].indexOf(",") > -1) {
            var codes = values[0].split(',');
            if (codes && codes.length > 0) {
                s = codes[2];
            }
        } else {
            s = values[0];
        }
    }
    //console.log("getProductCodeFromMultiSelect: s: ", s);
    //} catch (e) {
    //}
    return s;
}
function getJobCodeFromMultiSelect() {
    var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
    var s = "";
    var values;
    values = jobsMultiSelect.value();
    if (values && values.length > 0) {
        s = values[0];
    }
    //console.log("getJobCodeFromMultiSelect", s);
    return s;
}
function getAssignmentCodeFromMultiSelect() {
    var jobAssignmentsMultiSelect = $("#jobAssignmentsMultiSelect").data("kendoMultiSelect");
    var s = "";
    //try {
    var values;
    values = jobAssignmentsMultiSelect.value();
    //console.log("getAssignmentCodeFromMultiSelect: values: ", values);
    if (values && values.length > 0) {
        s = values[0];
    }
    //console.log("getAssignmentCodeFromMultiSelect: s: ", s);
    //} catch (e) {
    //}
    return s;
}
function getFunctionCategoryCodeFromMultiSelect() {
    var functionCategoryMultiSelect = $("#functionCategoryMultiSelect").data("kendoMultiSelect");
    var s = "";
    //try {
    var values;
    values = functionCategoryMultiSelect.value();
    //console.log("functionCategoryMultiSelect: values: ", values);
    if (values && values.length > 0) {
        s = values[0];
    }
    //console.log("functionCategoryMultiSelect: s: ", s);
    //} catch (e) {
    //}
    return s;
}

function setClientsMultiSelectValue(val) {
    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
    if (clientsMultiSelect) {
        clientsMultiSelect.value(val);
    }
}
function setDivisionsMultiSelectValue(val) {
    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
    if (divisionsMultiSelect) {
        divisionsMultiSelect.value(val);
    }
}
function setProductsMultiSelectValue(val) {
    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
    if (productsMultiSelect) {
        productsMultiSelect.value(val);
    }
}
function setJobsMultiSelectValue(val) {
    var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
    if (jobsMultiSelect) {
        jobsMultiSelect.value(val);
    }
}
function setJobAssignmentsMultiSelectValue(val) {
    var jobAssignmentsMultiSelect = $("#jobAssignmentsMultiSelect").data("kendoMultiSelect");
    if (jobAssignmentsMultiSelect) {
        jobAssignmentsMultiSelect.value(val);
    }
}
function setFunctionCategoryMultiSelectValue(val) {
    var functionCategoryMultiSelect = $("#functionCategoryMultiSelect").data("kendoMultiSelect");
    if (functionCategoryMultiSelect) {
        functionCategoryMultiSelect.value(val);
    }
}

function enableClientsMultiSelect(val) {
    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
    if (clientsMultiSelect) {
        clientsMultiSelect.enable(val);
    }
}
function enableDivisionsMultiSelect(val) {
    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
    if (divisionsMultiSelect) {
        divisionsMultiSelect.enable(val);
    }
}
function enableProductsMultiSelect(val) {
    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
    if (productsMultiSelect) {
        productsMultiSelect.enable(val);
    }
}
function enableJobsMultiSelect(val) {
    var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
    if (jobsMultiSelect) {
        jobsMultiSelect.enable(val);
    }
}
function enableJobAssignmentsMultiSelect(val) {
    var jobAssignmentsMultiSelect = $("#jobAssignmentsMultiSelect").data("kendoMultiSelect");
    if (jobAssignmentsMultiSelect) {
        jobAssignmentsMultiSelect.enable(val);
    }
}
function enableFunctionCategoryMultiSelect(val) {
    var functionCategoryMultiSelect = $("#functionCategoryMultiSelect").data("kendoMultiSelect");
    if (functionCategoryMultiSelect) {
        functionCategoryMultiSelect.enable(val);
    }
}

function backFillCDP() {
    var dfd = jQuery.Deferred();
    if (!clientID || clientID.length == 0 || clientID[0] == '' ||
        !divisionID || divisionID.length == 0 || divisionID[0] == '' ||
        !productID || productID.length == 0 || productID[0] == '') {
        if (!backFillInProgress) {
            backFillInProgress = true;
            $.ajax({
                url: window.appBase + 'Utilities/SearchCDPForJob',
                type: 'GET',
                dataType: 'json',
                data: {
                    JobNumber: jobComponentID[0]
                },
                success: (data) => {
                    if (data.ClientCode != clientID[0]) {
                        clientID = [];
                        clientID[0] = data.ClientCode;
                    }

                    if (divisionID[0] != data.ClientCode + ',' + data.DivisionCode) {
                        setTimeout(() => {
                            divisionsMultiSelectDataSource.read().then(() => {
                                divisionID = []
                                divisionID[0] = data.ClientCode + ',' + data.DivisionCode;
                                setTimeout(() => {
                                    productsMultiSelectDataSource.page(0);
                                    //console.log("reading products from backfillCDP 1")
                                    productsMultiSelectDataSource.read().then(() => {
                                        //console.log("productsMultiSelectDataSource.total() 1", productsMultiSelectDataSource.total());
                                        productID = [];
                                        productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                                        backFillInProgress = false;
                                        dfd.resolve();
                                    });
                                }, 15);
                            });
                        }, 15);
                    } else if (productID[0] != data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode) {
                        productID = [];
                        //console.log("reading products from backfillCDP 2")
                        productsMultiSelectDataSource.page(0);
                        productsMultiSelectDataSource.read().then(() => {
                            //console.log("productsMultiSelectDataSource.total() 2", productsMultiSelectDataSource.total());
                            productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                            backFillInProgress = false;
                            dfd.resolve();
                        });
                    }
                }
            });
        }
    } else {
        dfd.resolve();
    }
    return dfd;
}

function initClientsMultiSelect() {
    clientsMultiSelectDataSource = new kendo.data.DataSource({
        serverFiltering: true,
        serverPaging: true,
        pageSize: 31,
        schema: {
            data: "Clients",
            total: "Total",
        },
        //offlineStorage: "clients-offline",
        transport: {
            read: {
                url: window.appBase + 'Utilities/SearchClients',
                data: function () {
                    var officeCode = "";
                    var Text = "";
                    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
                    if (clientsMultiSelect) {
                        Text = clientsMultiSelect.input.val();
                        if (Text == "Client") {
                            Text = "";
                        }
                        if (!resetClient) {
                            if (Text == "") {
                                var dataItems = clientsMultiSelect.dataItems();
                                if (dataItems && dataItems.length > 0) {
                                    try {
                                        Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                                    } catch (e) { }
                                }
                            }
                        }
                        else {
                            resetClient = false;
                        }
                    }
                    return {
                        OfficeCode: "",
                        Text: Text
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
            }
        },
        requestEnd: function (e) {
        }
    });
    $("#clientsMultiSelect").kendoMultiSelect({
        autoBind: false,
        filter: "contains",
        delay: 750,
        tagTemplate: "<span title='#: data.Name #' class='ms-tag'>#: data.Name #</span>",
        template: "<span title='#: data.Name #'>#: data.Name #</span>",
        placeholder: "Client",
        dataTextField: "Name",
        dataValueField: "Code",
        dataSource: clientsMultiSelectDataSource,
        virtual: {
            itemHeight: 26,
            me: this,
            valueMapper: clientMapper
        },
        change: function (e) {
            //console.log("client change triggered", this.value());
            var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
            var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
            if (this && this.value()) {
                clientID = this.value();
            }
            resetDivision = true;
            resetProduct = true;
            resetJob = true;
            resetComponent = true;
            resetAssignment = true;
            resetFunction = true;
            checkMultiSelectsEnableClient();
            if (!clientID || clientID.length == 0 || clientID[0] == '') {
                divisionID = [];
                productID = [];
                setDivisionsMultiSelectValue(divisionID);
                setProductsMultiSelectValue(productID);
                divisionsMultiSelectDataSource.read();
                ////console.log("productRead from client change");
                ////productsMultiSelectDataSource.page(0);
                ////productsMultiSelectDataSource.read();
                refreshProducsMultiSelectDatasource();
                isDirectTime = true;
                timeType = "D";
            } else {
                divisionsMultiSelectDataSource.read().then(function () {
                    if (divisionsMultiSelectDataSource.total() > 0) {
                        enableDivisionsMultiSelect(true);
                    }
                    if (divisionsMultiSelectDataSource.total() == 1) {
                        divisionID = [];
                        divisionID[0] = divisionsMultiSelectDataSource.data()[0].ID;
                        divisionsMultiSelect.value(divisionID[0]);
                    }
                    divisionsMultiSelect.trigger("change");
                });
                divisionsMultiSelect.focus();
            }
            jobComponentID = [];
            setJobsMultiSelectValue(jobComponentID);
            componentMultiSelectDataSource.read();
        },
        deselect: function (e) {
            var dataItem = e.dataItem;
            var item = e.item;
            var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
            if (timeType === "D") {
                timeTypeChanged = true;
            }
            timeType = "N";
            isDirectTime = false;
            jobNumber = 0;
            jobComponentNumber = 0;
            setAssignmentAndFunctions();
            setFunctionCategoryLabel();
            clientID = [];
            clientsMultiSelect.value(clientID);
            clientsMultiSelect.trigger("change");
            jobNumber = 0;
            jobComponentNumber = 0;
        },
        maxSelectedItems: 1
    });
    window.setTimeout(function () {
        try {
            var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
            clientsMultiSelect.list.width(450);
        } catch (e) {
        }
        checkMultiSelectsEnableClient();
    }, 10);
}
function clientMapper(options) {
    Text = "";
    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
    if (clientsMultiSelect) {
        Text = clientsMultiSelect.input.val();
    }
    if (Text == 'Client') {
        Text = "";
    }
    if (Text == "" && clientsMultiSelect) {
        var dataItems = clientsMultiSelect.dataItems();
        if (dataItems && dataItems.length > 0) {
            try {
                Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
            } catch (e) { }
        }
    }
    var data = {
        OfficeCode: "",
        Text: Text,
        ClientCode: options.value[0]
    }
    $.ajax({
        url: window.appBase + 'Utilities/SearchClientIndex',
        type: 'GET',
        dataType: 'json',
        data: data,
        success: (data) => {
            //console.log("SearchClientIndex", data);
            options.success(data);
        }
    }).fail(function (xhr, status, error) {
        alert(error);
    });
}
function initDivisionsMultiSelect() {
    divisionsMultiSelectDataSource = new kendo.data.DataSource({
        serverFiltering: true,
        serverPaging: true,
        pageSize: 31,
        schema: {
            data: "Divisions",
            total: "Total",
        },
        transport: {
            read: {
                url: window.appBase + 'Utilities/SearchDivisions',
                data: function () {
                    var clientCode = "";
                    var Text = "";
                    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
                    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
                    //var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
                    if (divisionsMultiSelect) {
                        Text = divisionsMultiSelect.input.val();
                        if (Text == 'Division') {
                            Text = "";
                        }
                        if (!resetDivision) {
                            if (Text == "") {
                                var dataItems = divisionsMultiSelect.dataItems();
                                if (dataItems && dataItems.length > 0) {
                                    try {
                                        Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                                    } catch (e) { }
                                }
                            }
                        } else {
                            resetDivision = false;
                        }
                    }
                    if (clientID && clientID.length > 0) {
                        clientCode = clientID[0];
                        //console.log(2229, clientID, clientCode, clientsMultiSelect.value())
                    } else {
                        //console.log(2231, clientID, clientCode, clientsMultiSelect.value())
                    }
                    return {
                        OfficeCode: "",
                        ClientCode: clientCode,
                        Text: Text
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
                //e.preventDefault();
            }
        },
        requestEnd: function (e) {
        }
    });
    $("#divisionsMultiSelect").kendoMultiSelect({
        autoBind: false,
        filter: "contains",
        delay: 750,
        tagTemplate: "<span title='#: data.Name #'  class='ms-tag'>#: data.Name #</span>",
        template: "<span title='#: data.Name #'>#: data.Name #</span>",
        placeholder: "Division",
        dataTextField: "Name",
        dataValueField: "ID",
        dataSource: divisionsMultiSelectDataSource,
        virtual: {
            itemHeight: 26,
            me: this,
            valueMapper: divisionMapper
        },
        change: function (e) {
            var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
            var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            //console.log("divisionsMultiSelect:change:this.value()", this.value());
            //console.log("divisionsMultiSelect:change:this.value()", divisionsMultiSelect.value());
            //console.log("divisionsMultiSelect:change:divisionID", divisionID);
            if (this && this.value()) {
                divisionID = this.value();
            }
            resetProduct = true;
            resetJob = true;
            resetComponent = true;
            if (!divisionID || divisionID.length == 0 || divisionID[0] == '') {
                productID = [];
                setProductsMultiSelectValue(productID);
                ////console.log("divisionsMultiselect: about to read products 1")
                ////productsMultiSelectDataSource.page(0);
                ////productsMultiSelectDataSource.read().then(function () {
                ////    console.log("divisionsMultiselect: products read.  productsMultiSelectDataSource.total() 1: ", productsMultiSelectDataSource.total());
                ////});
                refreshProducsMultiSelectDatasource();
                jobComponentID = [];
                setJobsMultiSelectValue(jobComponentID);
            } else {
                if (divisionID && divisionID.length > 0) {
                    var codes = divisionID[0].split(',');
                    if (!clientID || clientID[0] == '' || clientID.length == 0 || clientID[0] != codes[0]) {
                        clientID = [];
                        clientID[0] = codes[0];
                        setClientsMultiSelectValue(clientID[0]);
                    }
                    isDirectTime = true;
                    timeType = "D";
                }
                ////console.log("divisionsMultiselect: about to read products 2")
                refreshProducsMultiSelectDatasource();
                ////productsMultiSelectDataSource.page(0);
                ////productsMultiSelectDataSource.read().then(function () {
                ////    console.log("divisionsMultiselect: products read.  productsMultiSelectDataSource.total() 2: ", productsMultiSelectDataSource.total());
                ////    if (productsMultiSelectDataSource.total() > 0) {
                ////        enableProductsMultiSelect(true);
                ////    }
                ////    if (productsMultiSelectDataSource.total() == 1) {
                ////        productID = [];
                ////        productID[0] = productsMultiSelectDataSource.data()[0].ID;
                ////        //console.log("divisionsMultiSelect:change:productsMultiSelectDataSource.read:productID[0]", productID[0]);
                ////        productsMultiSelect.value(productID[0]);
                ////    }
                ////    else {
                ////        productsMultiSelect.focus();
                ////    }
                ////    productsMultiSelect.trigger("change");
                ////});
            }
            jobComponentID = [];
            setJobsMultiSelectValue(null);
            componentMultiSelectDataSource.read();
        },
        deselect: function (e) {
            var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
            var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
            divisionID = [];
            divisionsMultiSelect.value(divisionID);
            //divisionsMultiSelect.trigger("change");
            //console.log("division deselected", divisionID, clientID, clientsMultiSelect.value(), divisionsMultiSelect.value());
            divisionsMultiSelectDataSource.read().then(function () {
                //if (divisionsMultiSelectDataSource.total() == 1) {
                //    divisionID = [];
                //    divisionID[0] = divisionsMultiSelectDataSource.data()[0].ID;
                //    divisionsMultiSelect.value(divisionID[0]);
                //}
                divisionsMultiSelect.trigger("change");
            });
            divisionsMultiSelect.focus();
            jobNumber = 0;
            jobComponentNumber = 0;
        },
        maxSelectedItems: 1
    });
    window.setTimeout(function () {
        try {
            var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
            divisionsMultiSelect.list.width(450);
        } catch (e) {
        }
    }, 10);
}
function divisionMapper(options) {
    var officeCode = '';
    var clientCode = '';
    var Text = "";
    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
    if (divisionsMultiSelect) {
        Text = divisionsMultiSelect.input.val();
    }
    if (Text == "Division") {
        Text = "";
    }
    if (Text == "" && divisionsMultiSelect) {
        var dataItems = divisionsMultiSelect.dataItems();
        if (dataItems && dataItems.length > 0) {
            try {
                Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
            } catch (e) { }
        }
    }
    if (clientID && clientID.length > 0) {
        clientCode = clientID[0];
    }
    var data = {
        OfficeCode: "",
        ClientCode: clientCode,
        DivisionCode: options.value[0],
        SprintID: 0,
        Text: Text
    }
    $.ajax({
        url: window.appBase + "Utilities/SearchDivisionIndex",
        type: "GET",
        dataType: "json",
        data: data,
        success: (data) => {
            options.success(data);
        }
    }).fail(function (xhr, status, error) {
        alert(error);
    });
}
function initProductsMultiSelect() {
    productsMultiSelectDataSource = new kendo.data.DataSource({
        serverFiltering: true,
        serverPaging: true,
        pageSize: 31,
        schema: {
            data: "Products",
            total: "Total",
        },
        transport: {
            read: {
                url: window.appBase + "Utilities/SearchProducts",
                data: function () {
                    var clientCode = "";
                    var divisionCode = "";
                    var officeCode = "";
                    var Text = "";
                    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
                    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
                    if (productsMultiSelect) {
                        Text = productsMultiSelect.input.val();
                    }
                    if (Text == "Product") {
                        Text = "";
                    }
                    if (!resetProduct) {
                        if (Text == "" && productsMultiSelect) {
                            var dataItems = productsMultiSelect.dataItems();
                            if (dataItems && dataItems.length > 0) {
                                try {
                                    Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                                } catch (e) { }
                            }
                        }
                    } else {
                        resetProduct = false;
                    }
                    if (clientID && clientID.length > 0) {
                        clientCode = clientID[0];
                    }
                    if (divisionID && divisionID.length > 0) {
                        divisionCode = divisionID[0].split(',')[1];
                    } else {
                        var val;
                        val = divisionsMultiSelect.value();
                        if (val && val.length > 0) {
                            var item = val[0].split(",");
                            if (item && item.length > 1) {
                                divisionCode = item[1];
                            }
                        }
                        //console.log("orrrr", getDivisionCodeFromMultiSelect())
                        divisionCode = getDivisionCodeFromMultiSelect();
                        divisionID = [];
                        divisionID = val;
                    }
                    //console.log("SearchProducts", clientID, divisionID, divisionsMultiSelect.value());
                    return {
                        OfficeCode: "",
                        ClientCode: clientCode,
                        DivisionCode: divisionCode,
                        Text: Text
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
            }
        },
        requestEnd: function (e) {
        }
    });
    $("#productsMultiSelect").kendoMultiSelect({
        autoBind: false,
        filter: "contains",
        delay: 750,
        tagTemplate: "<span title='#: data.Name #' class='ms-tag'>#: data.Name #</span>",
        template: "<span title='#: data.Name #'>#: data.Name #</span>",
        placeholder: "Product",
        dataTextField: "Name",
        dataValueField: "ID",
        dataSource: productsMultiSelectDataSource,
        virtual: {
            itemHeight: 26,
            me: this,
            valueMapper: productMapper
        },
        change: function (e) {
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            if (this && this.value()) {
                productID = this.value();
            }
            resetJob = true;
            resetComponent = true;
            if (productID && productID.length > 0) {
                var codes = productID[0].split(',');
                //console.log("productsMultiSelect:change:codes:before:", codes, clientID, divisionID, productID);
                if (!clientID || clientID[0] == '' || clientID.length == 0 || clientID[0] != codes[0]) {
                    clientsMultiSelectDataSource.read().then(() => {
                        //console.log("1")
                        clientID = [];
                        clientID[0] = codes[0];
                        setClientsMultiSelectValue(clientID[0]);
                    });
                }
                if (!divisionID || divisionID[0] == '' || divisionID.length == 0 || divisionID[0] != codes[0] + ',' + codes[1]) {
                    //console.log("2")
                    divisionsMultiSelectDataSource.read().then(() => {
                        divisionID = [];
                        divisionID[0] = codes[0] + ',' + codes[1];
                        setDivisionsMultiSelectValue(divisionID[0]);
                    });
                }
                isDirectTime = true;
                timeType = "D";
                //console.log("productsMultiSelect:change:codes:after:", codes, clientID, divisionID, productID);
            } else {
                //console.log("read product from product change?")
                refreshProducsMultiSelectDatasource(true);
            }
            jobComponentID = [];
            setJobsMultiSelectValue(null);
            componentMultiSelectDataSource.read().then(() => {
                var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
                if (!productID || productID[0] == "" || productID.length == 0) {
                    if (productsMultiSelect.value()) {
                        productID = productsMultiSelect.value();
                    }
                }
                if (componentMultiSelectDataSource.total() > 0) {
                    enableJobsMultiSelect(true);
                }
                if (componentMultiSelectDataSource.total() == 1) {
                    //console.log(2531, jobComponentID)
                    jobComponentID = [];
                    jobComponentID[0] = componentMultiSelectDataSource.data()[0].ID;
                    jobsMultiSelect.value(jobComponentID[0]);
                    enableDivisionsMultiSelect(true);
                    enableProductsMultiSelect(true);
                    setJobNumberAndJobComponentNumberFromJobIDArray(jobComponentID[0]);
                    setAssignmentAndFunctions();
                    setFunctionCategoryLabel();
                } else {
                    if (!productID || productID.length == 0) {
                        productsMultiSelect.focus();
                    } else {
                        jobsMultiSelect.focus();
                    }
                }
            });
        },
        deselect: function (e) {
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            //if (productsMultiSelect) {
            productID = [];
            productsMultiSelect.value(null);
            productsMultiSelect.trigger("change");
            //}
            jobNumber = 0;
            jobComponentNumber = 0;
        },
        maxSelectedItems: 1
    });
    window.setTimeout(function () {
        try {
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            productsMultiSelect.list.width(450);
        } catch (e) {
        }
    }, 10);
}
function productMapper(options) {
    var officeCode = "";
    var clientCode = "";
    var divisionCode = "";
    var Text = "";
    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
    if (productsMultiSelect) {
        Text = productsMultiSelect.input.val();
    }
    if (Text == "Product") {
        Text = "";
    }
    if (Text == "" && productsMultiSelect) {
        var dataItems = productsMultiSelect.dataItems();
        if (dataItems && dataItems.length > 0) {
            try {
                Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf("(") - 1);
            } catch (e) { }
        }
    }
    if (clientCode && clientID.length > 0) {
        clientCode = clientID[0];
    }
    if (divisionID && divisionID.length > 0) {
        divisionCode = divisionID[0].split(",")[1];
    }
    var data = {
        OfficeCode: "",
        ClientCode: clientCode,
        DivisionCode: divisionCode,
        ProductID: options.value[0],
        Text: Text
    };
    $.ajax({
        url: window.appBase + "Utilities/SearchProductIndex",
        type: "GET",
        dataType: "json",
        data: data,
        success: (data) => {
            options.success(data);
        }
    }).fail(function (xhr, status, error) {
        alert(error);
    });
}
function initJobsMultiSelect() {
    componentMultiSelectDataSource = new kendo.data.DataSource({
        serverFiltering: true,
        serverPaging: true,
        pageSize: 31,
        schema: {
            data: "JobComponents",
            total: "Total",
        },
        transport: {
            read: {
                url: window.appBase + 'Utilities/SearchComponentFromTimesheet',
                data: function () {
                    var officeCode = "";
                    var clientCode = "";
                    var divisionCode = "";
                    var productCode = "";
                    var jobCode = "";
                    var AccountExecutive = "";
                    var CampaignID = 0;
                    var SalesClass = "";
                    var JobType = "";
                    var Text = "";
                    var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
                    if (jobsMultiSelect) {
                        Text = jobsMultiSelect.input.val();
                    }
                    if (Text == 'Component' || Text == "Job") {
                        Text = '';
                    }
                    if (!resetComponent) {
                        if (Text == "" && jobsMultiSelect) {
                            var dataItems = jobsMultiSelect.dataItems();
                            if (dataItems && dataItems.length > 0) {
                                try {
                                    Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                                } catch (e) { }
                            }
                        }
                    } else {
                        resetComponent = false;
                    }
                    if (clientID && clientID.length > 0) {
                        clientCode = clientID[0];
                        //console.log(1, clientCode);
                    } else {
                        clientCode = getClientCodeFromMultiSelect();
                        //console.log(2, clientCode);
                    }
                    if (divisionID && divisionID.length > 0) {
                        if (divisionID[0].toString().indexOf(",") > -1) {
                            divisionCode = divisionID[0].toString().split(',')[1];
                            //console.log(3, divisionCode);
                        } else {
                            divisionCode = divisionID[0].toString();
                            //console.log(4, divisionCode);
                        }
                    } else {
                        divisionCode = getDivisionCodeFromMultiSelect();
                        //console.log(5, divisionCode);
                    }
                    if (productID && productID.length > 0) {
                        clientCode = productID[0].split(',')[0];
                        divisionCode = productID[0].split(',')[1];
                        productCode = productID[0].split(',')[2];
                        clientID = [];
                        clientID[0] = clientCode;
                        divisionID = [];
                        divisionID[0] = clientCode + "," + divisionCode;
                        //console.log(6, clientCode, divisionCode, productCode);
                    } else {
                        productCode = getProductCodeFromMultiSelect();
                        //console.log(7, productCode);
                    }
                    if (jobComponentID && jobComponentID.length > 0) {
                        jobCode = jobComponentID[0];
                        //console.log(8, jobCode);
                    }
                    //console.log("SearchComponentFromTimesheet", clientID, clientCode, divisionID, divisionCode, productID, productCode);
                    return {
                        OfficeCode: "",
                        ClientCode: clientCode,
                        DivisionCode: divisionCode,
                        ProductCode: productCode,
                        JobCode: jobCode,
                        AccountExecutive: AccountExecutive,
                        CampaignID: CampaignID,
                        SalesClass: SalesClass,
                        JobType: JobType,
                        ShowClosedJobs: false,
                        Text: Text
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
            }
        },
        requestEnd: function (e) {
        }
    });
    $("#jobsMultiSelect").kendoMultiSelect({
        autoBind: false,
        filter: "contains",
        delay: 750,
        tagTemplate: "<span title='#: data.Name #' class='ms-tag'>#: data.Name #</span>",
        template: "<span title='#: data.Name #'>#: data.Name #</span>",
        placeholder: "Job",
        dataTextField: "Name",
        dataValueField: "ID",
        dataSource: componentMultiSelectDataSource,
        virtual: {
            itemHeight: 26,
            me: this,
            valueMapper: jobMapper
        },
        change: function (e) {
            try {
                if (this && this.value()) {
                    jobComponentID = this.value();
                }
            } catch (e) { }
            var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
            var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
            var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");
            if (jobComponentID && jobComponentID.length == 1 && jobComponentID[0] != '') {
                var codes = jobComponentID[0].split(',');
                if (codes) {
                    jobNumber = codes[0] * 1;
                    jobComponentNumber = codes[1] * 1;
                    if (jobNumber > 0 && jobComponentNumber > 0) {
                        isDirectTime = true;
                        timeType = "D";
                    } else {
                        isDirectTime = false;
                        timeType = "N";
                    }
                }
                if (jobNumber && jobNumber > 0) {
                    checkJobCommentRequired();
                }
                assignmentMultiSelectDataSource.read().then(() => {
                    setAssignmentAndFunctions();
                    setFunctionCategoryLabel();
                });
                if (!clientID || clientID.length == 0 || clientID[0] == '' ||
                    !divisionID || divisionID.length == 0 || divisionID[0] == '' ||
                    !productID || productID.length == 0 || productID[0] == '') {
                    if (!backFillInProgress) {
                        backFillInProgress = true;
                        $.ajax({
                            url: window.appBase + 'Utilities/SearchCDPForJob',
                            type: 'GET',
                            dataType: 'json',
                            data: {
                                JobNumber: codes[0]
                            },
                            success: (data) => {
                                clientsMultiSelectDataSource.read().then(() => {
                                    clientID = [];
                                    clientID[0] = data.ClientCode;
                                    setClientsMultiSelectValue(clientID[0]);
                                    divisionsMultiSelectDataSource.read().then(() => {
                                        divisionID = []
                                        divisionID[0] = data.ClientCode + ',' + data.DivisionCode;
                                        setDivisionsMultiSelectValue(divisionID[0])
                                        //console.log("product read from job multiselect");
                                        productsMultiSelectDataSource.page(0);
                                        productsMultiSelectDataSource.read().then(() => {
                                            //console.log("productsMultiSelectDataSource.total()", productsMultiSelectDataSource.total());
                                            productID = [];
                                            productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                                            setProductsMultiSelectValue(productID[0]);
                                            backFillInProgress = false;
                                        });
                                    });
                                });
                            }
                        });
                    }
                }
            } else {
                componentMultiSelectDataSource.read().then(() => {
                    assignmentMultiSelectDataSource.read().then(() => {
                        setAssignmentAndFunctions();
                        setFunctionCategoryLabel();
                    });
                });
            }
            enableDivisionsMultiSelect(true);
            enableProductsMultiSelect(true);
        },
        deselect: function (e) {
            try {
                var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
                jobComponentID = [];
                if (jobsMultiSelect) {
                    jobsMultiSelect.value(null);
                    jobsMultiSelect.trigger("change");
                }
                jobNumber = 0;
                jobComponentNumber = 0;
                commentsRequired = false;
                setCommentRequiredTextArea();
            } catch (e) {
            }
        },
        maxSelectedItems: 1
    });
    window.setTimeout(function () {
        try {
            var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
            jobsMultiSelect.list.width(450);
        } catch (e) {
        }
    }, 10);
}
function jobMapper(options) {
    var officeCode = "";
    var clientCode = "";
    var divisionCode = "";
    var productCode = "";
    var jobCode = "";
    var AccountExecutive = "";
    var CampaignID = 0;
    var SalesClass = "";
    var JobType = "";
    var Text = "";
    var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
    if (jobsMultiSelect) {
        Text = jobsMultiSelect.input.val();
    }
    if (Text == "Job") {
        Text = "";
    }
    if (Text == "" && jobsMultiSelect) {
        var dataItems = jobsMultiSelect.dataItems();
        if (dataItems && dataItems.length > 0) {
            try {
                Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
            } catch (e) { }
        }
    }
    if (clientID && clientID.length > 0) {
        clientCode = clientID[0];
    }
    if (divisionID && divisionID.length > 0) {
        divisionCode = divisionID[0].split(',')[1];
    }
    if (productID && productID.length > 0) {
        productCode = productID[0].split(',')[2];
    }
    if (jobComponentID && jobComponentID.length > 0) {
        jobCode = jobComponentID[0];
    }
    var data = {
        OfficeCode: "",
        ClientCode: clientCode,
        DivisionCode: divisionCode,
        ProductCode: productCode,
        JobCode: jobCode,
        ComponentID: options.value[0],
        AccountExecutive: "",
        CampaignID: 0,
        SalesClass: "",
        JobType: "",
        ShowClosedJobs: false,
        Text: Text
    }
    $.ajax({
        url: window.appBase + "Utilities/SearchComponentIndexFromTimesheet",
        type: "GET",
        dataType: "json",
        data: data,
        success: (data) => {
            options.success(data);
        }
    }).fail(function (xhr, status, error) {
        alert(error);
    });
}
function setJobNumberAndJobComponentNumberFromJobIDArray(val) {
    var codes = val.split(",");
    if (codes) {
        jobNumber = codes[0] * 1;
        jobComponentNumber = codes[1] * 1;
        if (jobNumber > 0 && jobComponentNumber > 0) {
            isDirectTime = true;
            timeType = "D";
        } else {
            isDirectTime = false;
            timeType = "N";
        }
    }
}
//function initJobComponentMultiSelect() {
//}
//function jobComponentMapper(options) {
//}
function initJobAssignmentsMultiSelect() {
    assignmentMultiSelectDataSource = new kendo.data.DataSource({
        //serverFiltering: true,
        //serverPaging: true,
        //pageSize: 31,
        //schema: {
        //    data: "Divisions",
        //    total: "Total",
        //},
        transport: {
            read: {
                url: window.appBase + "Employee/Timesheet/GetJobAssignments",
                data: function () {
                    var Text = "";
                    var jobAssignmentsMultiSelect = $("#jobAssignmentsMultiSelect").data("kendoMultiSelect");
                    if (jobAssignmentsMultiSelect) {
                        Text = jobAssignmentsMultiSelect.input.val();
                        if (Text == 'Assignment') {
                            Text = "";
                        }
                        if (!resetAssignment) {
                            if (Text == "") {
                                var dataItems = jobAssignmentsMultiSelect.dataItems();
                                if (dataItems && dataItems.length > 0) {
                                    try {
                                        Text = dataItems[0].Nasubstring(0, dataItems[0].NalastIndexOf('(') - 1);
                                    } catch (e) { }
                                }
                            }
                        } else {
                            resetAssignment = false;
                        }
                    }
                    return {
                        j: jobNumber,
                        jc: jobComponentNumber,
                        inclps: false,
                        Text: Text
                    }
                }
            }
        },
        requestStart: function (e) {
            if (e.type === "read") {
                //e.preventDefault();
            }
        },
        requestEnd: function (e) {
        }
    });


    //jobAssignmentsDataSourceMod = new kendo.data.DataSource({
    //    serverFiltering: false,
    //    transport: {
    //        read: {
    //            url: window.appBase + "Employee/Timesheet/GetJobAssignments?j=" + jobNumber + "&jc=" + jobComponentNumber + "&inclps="
    //        }
    //    },
    //    requestStart: function (e) {
    //        if (e.type === "read") {
    //            //
    //        }
    //    },
    //    requestEnd: function (e) {
    //        var type = e.type;
    //        var items = [];
    //        items = e.response;
    //    }
    //});



}
function jobAssignmentMapper(options) {
}
function initFunctionsMultiSelect() {
}
function functionMapper(options) {
}

function checkMultiSelectsEnableClient() {
    window.setTimeout(function () {
        var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
        var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
        var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
        var jobsMultiSelect = $("#jobsMultiSelect").data("kendoMultiSelect");
        var jobAssignmentsComboBox = $("#jobAssignmentsComboBox").data("kendoComboBox");

        if (clientsMultiSelect) {
            if (!clientsMultiSelect.value() || clientsMultiSelect.value().length == 0) {
                //console.log("no client");
                divisionID = [];
                productID = [];
                jobComponentID = [];
                if (divisionsMultiSelect) {
                    divisionsMultiSelect.value(null);
                    divisionsMultiSelect.enable(false);
                }
                if (productsMultiSelect) {
                    productsMultiSelect.value(null);
                    productsMultiSelect.enable(false);
                }
                if (jobsMultiSelect) {
                    jobsMultiSelect.value(null);
                    jobsMultiSelect.enable(true);
                    if (jobAssignmentsComboBox) {
                        jobAssignmentsComboBox.enable(false);
                    }
                }
            }
            clientsMultiSelect.focus();
        }
    }, 250);
}

var lastClientID;
var lastDivisionID;
var lastProductID;
function refreshProducsMultiSelectDatasource(fromProductChange) {
    //console.log("refreshProducsMultiSelectDatasource")
    var clientsMultiSelect = $("#clientsMultiSelect").data("kendoMultiSelect");
    var divisionsMultiSelect = $("#divisionsMultiSelect").data("kendoMultiSelect");
    var productsMultiSelect = $("#productsMultiSelect").data("kendoMultiSelect");
    //if (clientID && clientID.length > 0 && divisionID && divisionID.length > 0) {
        productsMultiSelectDataSource.page(0);
        productsMultiSelectDataSource.read().then(function () {
            //console.log("productsMultiSelectDataSource.total()", productsMultiSelectDataSource.total());
            if (productsMultiSelectDataSource.total() > 0) {
                enableProductsMultiSelect(true);
            }
            if ((divisionID && divisionID.length > 0) || (divisionsMultiSelect && divisionsMultiSelect.value().length > 0)) {
                if (!fromProductChange || fromProductChange == false) {
                    //console.log("triggering change!");
                    if (productsMultiSelectDataSource.total() == 1) {
                        productID = [];
                        productID[0] = productsMultiSelectDataSource.data()[0].ID;
                        productsMultiSelect.value(productID[0]);
                    }
                    productsMultiSelect.focus();
                    productsMultiSelect.trigger("change");
                }
            }

        });
    //}

}
