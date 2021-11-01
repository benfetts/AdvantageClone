// Moved from View/Employee/Timesheet/Index.vbhtml

//  Layout
function dayOrWeekSelect(e) {
    saveClick("dayOrWeekSelect", e);
}
function _dayOrWeekSelect(e) {
    dayOrWeekView = $('#DayOrWeek > .k-state-active').attr('view');
    if (dayOrWeekView == "Day") {
        var data = {
            StartDate: kendo.toString($("#DatePicker")[0].value, "d")
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result == true) {
                var d = new Date();
                selectSingleDay(kendo.toString(d, "d"));
            } else {
                selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
            }
        });
    } else {
        selectWeek();
    }
}
function selectSingleDay(shortDate) {
    saveClick("selectSingleDay", shortDate);
}
function _selectSingleDay(shortDate) {
    //console.log("selectSingleDay");
    if (shortDate) {
        activeDateString = shortDate;
        startDate = activeDateString;
    } else {
        //console.log("no short date");
        getDatePickerDate();
        activeDateString = startDate;
    }
    //console.log("selectSingleDay", activeDateString);
    setDayView();
}
function changeSingleDay(navButton, shortDate) {
    //console.log("changeSingleDay Called!");
    saveClick("changeSingleDay", navButton, shortDate);
}
function _changeSingleDay(navButton, shortDate) {
    if (shortDate) {
        activeDateString = shortDate;
        manualSingleDayDateString = shortDate;
    } else {
        //console.log("no short date");
        getDatePickerDate();
        activeDateString = startDate;
    }
    //console.log("changeSingleDay", activeDateString, $(navButton).parent());
    $($(navButton).parent()).find("td").each(function () {
        var dayCell = $(this);
        $(dayCell).removeClass("day-view-day-cell-selected");
    });
    $(navButton).addClass("day-view-day-cell-selected");
    isViewingSingleDay = true;
    loadSingleDayTimesheet();
}
function setDayView() {
    //console.log("setDayView");
    isViewingSingleDay = true;
    ////  Load nav
    //loadDayNav();
    //  Reload timesheet
    loadSingleDayTimesheet();
}
function selectWeek() {
    isViewingSingleDay = false;
    backToWeekView();
}
function loadDayNav() {
    isViewingSingleDay = true;
    var data = {
        EmployeeCode: employeeCode,
        ActiveDate: kendo.toString(startDate, "d"),
        StartDate: kendo.toString(startDate, "d")
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/GetTimesheetDayHeader",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            //console.log("GetTimesheetDayHeader", result);
            var totalHours = 0.0;
            var shortDate = "";
            for (var i = 0; i < result.length; i++) {
                if (i == 0) {
                    startOfWeekDate = result[i].ShortDate;
                }
                endOfWeekDate = result[i].ShortDate;
                $("#day-" + i + "-text").text(result[i].ShortDayOfWeek + " " + result[i].DayMonthDisplay);
                $("#day-" + i + "-hours").text(kendo.toString(result[i].Hours, "N2"));
                shortDate = result[i].ShortDate;
                //console.log("loadDayNav", shortDate);
                $("#day-" + i + "-cell").removeAttr("onclick");
                if (result[i].Selected == true || result[i].ShortDate == activeDateString) {
                    $("#day-" + i + "-cell").addClass("day-view-day-cell-selected");
                } else {
                    $("#day-" + i + "-cell").removeClass("day-view-day-cell-selected");
                    //$("#day-" + i + "-cell").click(function () { changeSingleDay(shortDate); });
                }
                $("#day-" + i + "-cell").attr("abbr", shortDate);
                $("#day-" + i + "-cell").attr("onclick", "changeSingleDay(this, '" + shortDate + "');");
                totalHours += result[i].Hours * 1;
                //console.log($("#day-" + i + "-text"));
                //console.log($("#day-" + i + "-hours"));
            }
            $("#day-nav-total-hours").html(kendo.toString(totalHours, "N2"));
            if (!manualSingleDayDateString || manualSingleDayDateString == "") {
                selectDayNavDay();
            } else {
                setManualDayNavDay(manualSingleDayDateString);
            }
            //  Show nav
            $("#dayViewNavRow").show();
            $("#dayViewNav").show();
            //  Set label
            setDateLabelOrPicker();
        }
    });
}
function selectDayNavDay() {
    //console.log("selectDayNavDay", activeDateString,  kendo.toString(startDate, "d"));
    activeDateString = kendo.toString(startDate, "d");
    $(".day-view-day-cell").each(function () {
        $(this).removeClass("day-view-day-cell-selected");
        //console.log("loop", $(this).prop("abbr"));
        if ($(this).prop("abbr") == activeDateString) {
            $(this).addClass("day-view-day-cell-selected");
            //console.log("selected!", $(this));
            daySet = true;
        }
    });
}
function setManualDayNavDay(selectedDate) {
    //console.log("setManualDayNavDay", activeDateString,  selectedDate);
    $(".day-view-day-cell").each(function () {
        $(this).removeClass("day-view-day-cell-selected");
        if ($(this).prop("abbr") == selectedDate) {
            $(this).addClass("day-view-day-cell-selected");
        }
    });
}
function loadSingleDayTimesheet() {
    isViewingSingleDay = true;
    setDatePickerDate(activeDateString);
    //console.log("loadSingleDayTimesheet", isViewingSingleDay, activeDateString);
    var navUrl = window.appBase + "Employee/Timesheet/_Timesheet?emp=" + employeeCode + "&sd=" + activeDateString + "&dtd=1&nav=" + navType + "&cct=" + currentCopyType + "&isdd=1&sort=" + sortValue + "&grp=" + groupValue;
    if (navUrl) {
        $('#day-view-refresh').load(navUrl, function (html) {
            //console.log("loadSingldDayTimesheet: after reload")
            loadDayNav();
            initTimesheetPartialView(false);
            setSortValue(sortValue);
            setGroupValue(groupValue);
            unCheckAndClearAllSelectedRows();
            restoreCollapsedRows();
            window.setTimeout(function () {
                hideProgress();
            }, 750);
            window.setTimeout(function () {
                initTooltips();
            }, 500);
        });
    }
}

function groupDropDownListChanged() {
    saveClick("groupDropDownListChanged");
}
function _groupDropDownListChanged() {
    try {
        groupValue = $("#groupDropDownList").val();
        //console.log("groupDropDownListChanged", groupValue);
        var data = {
            GroupBy: groupValue
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/SaveUserGroup",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log("groupDropDownListChanged", response);
            }
            navigate();
        });
    } catch (e) {
        //console.log("sortDropDownListChanged:ERROR", e);
    }
}

function sortDropDownListChanged() {
    saveClick("sortDropDownListChanged");
}
function _sortDropDownListChanged() {
    try {
        sortValue = $("#sortDropDownList").val();
        //console.log("sortDropDownListChanged", sortValue);
        var data = {
            SortValue: sortValue
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/SaveUserTimesheetSort",
            dataType: "json",
            data: data
        }).always(function (response) {
            //if (response) {
            //}
            navigate();
        });
    } catch (e) {
        //console.log("sortDropDownListChanged:ERROR", e);
    }
}
function getUserSort() {
    var data = {
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/GetUserTimesheetSort",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            setSortValue(response);
        } else {
            setSortValue("");
        }
    });
}
//  Navigate
function backToWeekView() {
    saveClick("backToWeekView");
}
function _backToWeekView() {
    isViewingSingleDay = false;
    activeDateString = "";
    manualSingleDayDateString = "";
    $("#dayViewNavRow").hide();
    $("#dayViewNav").hide();
    var buttongroup = $("#DayOrWeek").kendoButtonGroup({}).data("kendoButtonGroup");
    if (buttongroup) {
        buttongroup.select(1);
    }
    navType = 0;
    daysToDisplay = settingsDaysToDisplay;
    navigate();
}
function navigatorClicked(e) {
    navDirection = $('#Navigator > .k-state-active').attr('direction');
    if (navDirection == "previous") {
        navigateToPrevious();
    } else if (navDirection == "next") {
        navigateToNext();
    } else {
        navigateToToday();
    }
}
function navigateToPrevious() {
    saveClick("navigateToPrevious");
}
function _navigateToPrevious() {
    clearExpandedRows();
    navType = 2;
    navigate();
}
function navigateToNext() {
    saveClick("navigateToNext");
}
function _navigateToNext() {
    clearExpandedRows();
    navType = 3;
    navigate();
}
function navigateToToday() {
    saveClick("navigateToToday");
}
function _navigateToToday() {
    clearExpandedRows();
    navType = 1;
    navigate();
}
function navigateToDate() {
    saveClick("navigateToDate");
}
function _navigateToDate() {
    clearExpandedRows();
    navType = 4;
    navigate();
}
function navigate() {
    //if (typeof sortValue == 'object') {
    //    sortValue = "";
    //}
    if (allowNavigate == true) {
        showProgress();
        inserts = [];
        //saveClick();
        var navUrl = "";
        //console.log("navigate", isViewingSingleDay, daysToDisplay)
        if (isViewingSingleDay == true) {
            navUrl = window.appBase + "Employee/Timesheet/_Timesheet?emp=" + employeeCode + "&sd=" + activeDateString + "&dtd=" + daysToDisplay + "&nav=" + navType + "&cct=" + currentCopyType + "&isdd=1&sort=" + sortValue + "&grp=" + groupValue;
            //console.log("navigate URL", navUrl);
            try {
                window.setTimeout(function () {
                    $('#timesheet-control').load(navUrl, function (html) {
                        navType = 0;
                        initTimesheetPartialView(true);
                        manualSingleDayDateString = "";
                        loadDayNav();
                        setSortValue(sortValue);
                        //console.log("navigate", groupValue);
                        setGroupValue(groupValue);
                        unCheckAndClearAllSelectedRows();
                        //console.log("navigate:1", expandedRows);
                        restoreCollapsedRows();
                        restoreSelectedRows();
                        window.setTimeout(function () {
                            hideProgress();
                        }, 750);
                        window.setTimeout(function () {
                            initTooltips();
                        }, 500);
                        //selectDayNavDay();
                        //console.log("navigate, startDate after", startDate, $("#DatePicker")[0].value);
                        //filterTimesheet(userSearchString);
                        //$("#searchInput").val(userSearchString);
                    });
                }, 10);
            } catch (e) {
                hideProgress();
            }
        } else {
            getDatePickerDate();
            //console.log("WTF", daysToDisplay, settingsDaysToDisplay);
            //if (daysToDisplay == 1) {
            //    daysToDisplay = settingsDaysToDisplay;
            //}
            navUrl = window.appBase + "Employee/Timesheet/_Timesheet?emp=" + employeeCode + "&sd=" + startDate + "&dtd=" + daysToDisplay + "&nav=" + navType + "&cct=" + currentCopyType + "&isdd=0&sort=" + sortValue + "&grp=" + groupValue;
            //console.log("wiik navigate URL", navUrl);
            window.setTimeout(function () {
                try {
                    $('#timesheet-control').load(navUrl, function (html) {
                        navType = 0;
                        initTimesheetPartialView(true);
                        setDatePickerDate(startDate);
                        setSortValue(sortValue);
                        //console.log("navigate", groupValue);
                        setGroupValue(groupValue);
                        unCheckAndClearAllSelectedRows();
                        //console.log("navigate:2", expandedRows);
                        restoreCollapsedRows();
                        restoreSelectedRows();
                        window.setTimeout(function () {
                            hideProgress();
                        }, 750);
                        window.setTimeout(function () {
                            initTooltips();
                        }, 500);
                    });
                } catch (e) {
                    hideProgress();
                }
            }, 10);
        }
    }
}
function setGroupValue(group) {
    try {
        groupValue = group;
        //console.log("setGroupValue", groupValue);  //savedGroup
        //console.log("setGroupValue", savedGroup);  //savedGroup
        if ((!groupValue || groupValue == "") && savedGroup && savedGroup != "") {
            groupValue = savedGroup;
        }
        if (!groupValue) {
            groupValue = "";
        }
        var groupDropDownList = $("#groupDropDownList").data("kendoDropDownList");
        if (groupDropDownList) {
            groupDropDownList.value(groupValue);
        }
        //console.log("WTF", groupValue);
        //if (groupValue && groupValue != "") {
        //    collapseAllHeaders();
        //}
    } catch (e) {
        //console.log("setGroupValue:ERROR", e);
    }
}
function setSortValue(sort) {
    try {
        sortValue = sort;
        //console.log("setSortValue", sortValue);
        if (!sortValue) {
            sortValue = "";
        }
        var sortDropDownList = $("#sortDropDownList").data("kendoDropDownList");
        if (sortDropDownList) {
            sortDropDownList.value(sortValue);
        }
    } catch (e) {
        //console.log("setSortValue:ERROR", e);
    }
}
function checkForCurrentWeek() {
    var isInCurrentWeek = false;
    var currDate = new Date();
    var todayDate = kendo.toString(currDate, "d");
    $("#employeeTimeTable thead>tr.day_header_row>td").filter(function () {
        if (todayDate == $(this)[0].id.replace("time-col-", "")) {
            isInCurrentWeek = true;
        }
    });
    return isInCurrentWeek;
}
//  Change employee dialog
var employeeDialogInitiated = false;
function showSelectEmployeeDialog() {
    if (employeeDialogInitiated == false) {
        initEmployees();
    }
    saveClick("showSelectEmployeeDialog");
}
function _showSelectEmployeeDialog() {
    //initEmployees();
    $("#selectEmployeeDialogEmployeeName").text("");
    $("#selectEmployeeDialogEmployeeName").html("");
    $("#selectEmployeeDialogEmployeeName").val("");
    $("#selectEmployeeDialogEmployeeName").focus();
    var listBox = $("#selectEmployeeDialogEmployeeListBox").getKendoListBox();
    if (listBox) {
        listBox.dataSource.filter({});
    }
    $("#selectEmployeeDialog").ejDialog({
        showFooter: false,
        enableModal: true,
        closeOnEscape: true,
        backgroundScroll: false,
        enablePersistence: true,
        enableResize: false
    });
    $("#selectEmployeeDialog").ejDialog("open");
}
function selectEmployeeSelectButtonClick() {
    var listbox = $("#selectEmployeeDialogEmployeeListBox").data("kendoListBox");
    if (listbox) {
        var element = listbox.select();
        var dataItem = listbox.dataItem(element[0]);
        if (dataItem && dataItem.Code != employeeCode) {
            employeeCode = dataItem.Code;
            navigate();
            //console.log("", dataItem);
            $("#employeeImage").attr('src', employeePictureURL + employeeCode);
            $("#employeeName").attr('title', dataItem.Description);
            $("#employeeName").text(dataItem.Description);
            $("#selectEmployeeDialog").ejDialog("close");
            selectEmployeeInListBox();
            //var copyFromMyProjectsListView = $("#copyFromMyProjectsListView").data("kendoListView");
            //if (copyFromMyProjectsListView) {
            //    //copyFromMyProjectsListView.dataSource.read();
            //    //console.log("copyFromMyProjectsListView", copyFromMyProjectsListView);
            //}
            copyProjectsDataSource = null;
            loadCopyFromMyProjects();
        }
    }
}
function selectEmployeeCancelButtonClick() {
    refreshTimesheet();
    $("#selectEmployeeDialog").ejDialog("close");
}
//  New entry dialog
function openNewEntryDialog() {
    var URL = "";
    var thisTitle = "Add Time";
    if (isViewingSingleDay == true) {
        URL = window.appBase + "Employee/Timesheet/Entry?emp=" + employeeCode + "&sd=" + activeDateString + "&new=1";
    } else {
        var shortDate = "";
        try {
            shortDate = kendo.toString(startDate, "d");
        } catch (e) {
            shortDate = startDate;
        }
        //console.log(shortDate);
        if (checkForCurrentWeek() == true) {
            var today = new Date();
            URL = window.appBase + "Employee/Timesheet/Entry?emp=" + employeeCode + "&new=1" + "&sd=" + kendo.toString(today, "d");
        } else {
            URL = window.appBase + "Employee/Timesheet/Entry?emp=" + employeeCode + "&sd=" + shortDate + "&new=1";
        }
    }
    _openEntryDialog(thisTitle, URL, true);
}
//  Dialogs
function closeDialogs() {
    closeNewEntryDialog();
}
function openEntryDialog(employeeTimeId, employeeTimeDetailId, functionCategoryCode,
    jobNumber, jobComponentNumber, sDate, alertId, departmentTeamCode,
    ctrl, isInputTextbox) {
    //console.log("openEntryDialog", employeeTimeId, employeeTimeDetailId, functionCategoryCode, jobNumber, jobComponentNumber, sDate, alertId);
    var URL = "";
    var thisTitle = "Edit Time";
    if (!employeeTimeId) { employeeTimeId = 0; }
    if (!employeeTimeDetailId) { employeeTimeDetailId = 0; }
    if (!jobNumber) { jobNumber = 0; }
    if (!jobComponentNumber) { jobComponentNumber = 0; }
    if (!alertId) { alertId = 0; }
    URL = window.appBase + "Employee/Timesheet/Entry?emp=" + employeeCode + "&etid=" + employeeTimeId + "&etdid=" + employeeTimeDetailId + "&fn=" + functionCategoryCode + "&j=" + jobNumber + "&jc=" + jobComponentNumber + "&sd=" + sDate + "&a=" + alertId + "&dtc=" + departmentTeamCode + "&new=0&udc=1";
    if (employeeTimeId > 0 && employeeTimeDetailId > 0) {
        thisTitle = "Edit Time";
        _openEntryDialog(thisTitle, URL, false);
    } else {
        if (ctrl) {
            if (ctrl.defaultValue == "" & ctrl.value != "" && isNaN(ctrl.value) == false) {
                URL = URL + "&hrs=" + ctrl.value;
            }
            var row = ctrl.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement;
            var rowId;
            var rowNumber = -1;
            //console.log("row", row);
            if (row) {
                rowId = row.id;
                rowNumber = getRowNumber(row);
                let rowInfo = new RowInfo(rowId);
                var entryDate = ctrl.getAttribute("entry-date");
                var thisEntry;
                var hasJobNumber = false;
                var hasJobComponentNumber = false;
                thisEntry = new EntryInfo();
                thisEntry.RowNumber = rowNumber;
                thisEntry.EmployeeCode = employeeCode;
                thisEntry.EntryDate = entryDate;
                if (rowInfo.JobNumber && rowInfo.JobNumber > 0) {
                    thisEntry.JobNumber = rowInfo.JobNumber;
                    hasJobNumber = true;
                }
                if (rowInfo.JobComponentNumber && rowInfo.JobComponentNumber > 0) {
                    thisEntry.JobComponentNumber = rowInfo.JobComponentNumber;
                    hasJobComponentNumber = true;
                }
                if (hasJobNumber == true && hasJobComponentNumber == true) {
                    thisEntry.TimeType = "D";
                } else {
                    thisEntry.TimeType = "N";
                }
                thisEntry.FunctionCategoryCode = rowInfo.FunctionCode;
                thisEntry.DepartmentTeamCode = rowInfo.DepartmentTeamCode;
                thisEntry.Hours = ctrl.value * 1;
                if (thisEntry.Comment && thisEntry.Comment != "") {
                    thisEntry.HasComments = true;
                }
                thisEntry.AlertID = rowInfo.AlertID;
                thisEntry.key = employeeCode
                    + "|" + rowInfo.FunctionCode
                    + "|" + rowInfo.DepartmentTeamCode
                    + "|" + rowInfo.JobNumber
                    + "|" + rowInfo.JobComponentNumber
                    + "|" + "0"
                    + "|" + "0"
                    + "|" + "0"
                    + "|" + thisEntry.TimeType
                    + "|" + entryDate
                    + "|" + "false"
                    + "|" + "false"
                    + "|" + "0"
                    + "|" + rowInfo.AlertID;
                // what to do with entry?
                // remove from inserts and manually add single?
                removeInsert(thisEntry);
            }
        }
        thisTitle = "Add Time";
        _openEntryDialog(thisTitle, URL, true);
    }
}
function _openEntryDialog(title, url, brandNew) {
    saveClick();
    var h = "600px";
    var w = "600px";
    if (brandNew == true) {
        h = "570px";
        w = "700px";
    }
    $("#entryDialog").ejDialog("destroy");
    $("#entryDialog").ejDialog({
        contentUrl: url,
        title: title + "",
        closeOnEscape: true,
        showOnInit: false,
        contentType: "iframe",
        height: h,
        width: w,
        showFooter: false,
        enableModal: false,
        backgroundScroll: true,
        enableResize: false
    });
    $("#entryDialog").ejDialog("open");
    $("#entryDialog").ejDialog("refresh");
}
function closeNewEntryDialog() {
    $("#entryDialog").ejDialog("close");
}
function openTimeTemplateEditDialog() {
    //console.log("openTimeTemplateEditDialog");
    var URL = "";
    if (isViewingSingleDay == true) {
        URL = window.appBase + "Timesheet_CopyFrom.aspx?v=2&emp=" + employeeCode + "&sd=" + activeDateString;
    } else {
        var shortDate = "";
        try {
            shortDate = kendo.toString(startDate, "d");
        } catch (e) {
            shortDate = startDate;
        }
        if (checkForCurrentWeek() == true) {
            URL = window.appBase + "Timesheet_CopyFrom.aspx?v=2&emp=" + employeeCode;
        } else {
            URL = window.appBase + "Timesheet_CopyFrom.aspx?v=2&emp=" + employeeCode + "&sd=" + shortDate;
        }
    }
    $("#settingsDialog").ejDialog("destroy");
    $("#settingsDialog").ejDialog({
        contentUrl: URL,
        title: "Copy From Time Template Options",
        closeOnEscape: true,
        showOnInit: false,
        contentType: "iframe",
        height: "750px",
        width: "1100px",
        showFooter: false,
        enableModal: true,
        backgroundScroll: true,
        enableResize: true,
        close: function (e) {
            //console.log("openTimeTemplateEditDialog:close");
            currentCopyType = 2; // Templates
            refreshCopyFromList();
        }
    });
    $("#settingsDialog").ejDialog("open");
    $("#settingsDialog").ejDialog("refresh");
}
function openCalendarEditDialog() {
    //console.log("openCalendarEditDialog");
    var URL = "";
    if (isViewingSingleDay == true) {
        URL = window.appBase + "Timesheet_CopyFrom.aspx?v=2&emp=" + employeeCode + "&sd=" + activeDateString;
    } else {
        var shortDate = "";
        try {
            shortDate = kendo.toString(startDate, "d");
        } catch (e) {
            shortDate = startDate;
        }
        if (checkForCurrentWeek() == true) {
            URL = window.appBase + "Timesheet_CopyFrom.aspx?v=3&emp=" + employeeCode;
        } else {
            URL = window.appBase + "Timesheet_CopyFrom.aspx?v=3&emp=" + employeeCode + "&sd=" + shortDate;
        }
    }
    $("#settingsDialog").ejDialog("destroy");
    $("#settingsDialog").ejDialog({
        contentUrl: URL,
        title: "Copy From Calendar Options",
        closeOnEscape: true,
        showOnInit: false,
        contentType: "iframe",
        height: "750px",
        width: "1250px",
        showFooter: false,
        enableModal: true,
        backgroundScroll: true,
        enableResize: true
    });
    $("#settingsDialog").ejDialog("open");
    $("#settingsDialog").ejDialog("refresh");
}
//  Settings dialog
function settingsClick() {
    openSettingsDialog();
}
function openSettingsDialog() {
    saveClick("openSettingsDialog");
}
function _openSettingsDialog() {
    var URL = "";
    URL = window.appBase + "Employee/Timesheet/Settings?my=1&emp=" + employeeCode;
    $("#settingsDialog").ejDialog("destroy");
    $("#settingsDialog").ejDialog({
        contentUrl: URL,
        title: "Settings",
        showOnInit: false,
        contentType: "iframe",
        height: "640px",
        width: "550px",
        showFooter: false,
        enableModal: true,
        backgroundScroll: false,
        enableResize: false
    });
    $("#settingsDialog").ejDialog("open");
    $("#settingsDialog").ejDialog("refresh");
}
function closeSettingsDialog() {
    $("#settingsDialog").ejDialog("close");
}
//  Helpers
function getDatePickerDate() {
    var datepicker = $("#DatePicker").data("kendoDatePicker");
    try {
        startDate = kendo.toString(datepicker.value(), "d");
    } catch (e) {
        startDate = null;
    }
    if (!startDate || startDate == null || startDate == "" || startDate == undefined) {
        startDate = kShortDateStringFromDatePicker(datepicker);
    }
}
function parseDate(value) {
    var isValid = false;
    var formats = ["MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy"];
    var parsedDate = kendo.parseDate(value);
    if (!parsedDate) {
        $.each(formats, function () {
            parsedDate = kendo.parseDate(value, this);
            if (parsedDate) {
                return false;
            }
        });
    };
    if (parsedDate) {
        parsedDate = kendo.toString(parsedDate, 'd');
        isValid = true;
    }
    return {
        isValid: isValid,
        value: parsedDate
    }
}
function setDatePickerDate(dateVal) {
    var datepicker = $("#DatePicker").data("kendoDatePicker");
    try {
        datepicker.value(dateVal);
    } catch (e) {
        //console.log("setDatePickerDate error", e);
    }
}
function hardRefresh() {
    window.location.reload();
}
function cancelClick() {
    inserts = [];
    updates = [];
    disableSaveButton();
    disableCancelButton();
    //refreshTimesheet();
    navigate();
}
function refreshTimesheet() {
    //console.log("refreshTimesheet", expandedRows);
    cancelClick();
}
function bookmark() {
    var data = {
        PageURL: "Employee/Timesheet",
        Name: "Timesheet"
    };

    $.post({
        url: window.appBase + "Employee/Timesheet/Bookmark",
        dataType: "json",
        data: data
    });
}
//  Select employees
function initEmployees() {
    var crudServiceBaseUrl = window.appBase + "Employee/Timesheet",
        dataSource = new kendo.data.DataSource({
            serverFiltering: false,
            transport: {
                read: {
                    url: crudServiceBaseUrl + "/GetMyEmployees",
                    dataType: "json"
                }
            },
            requestStart: function (e) {
                if (e.type == "read") {
                }
            },
            requestEnd: function (e) {
                if (e.type == "read") {
                    employeeDialogInitiated = true;
                }
            },
            schema: {
                model: {
                    id: "Code",
                    fields: {
                        Code: { editable: false, nullable: true },
                        Description: { type: "string" }
                    }
                }
            }
        });
    $("#selectEmployeeDialogEmployeeName").on("input", function (e) {
        window.setTimeout(function () {
            var s = $("#selectEmployeeDialogEmployeeName").val();
            //console.log("searchVal", s, isBackspace);
            if (listbox.items().length != 1 || isBackspace == true) {
                listbox.dataSource.filter({ field: "Description", value: $(e.target).val(), operator: "contains" });
                //console.log("list??", listbox.items().length);
                selectEmployeeInListBox();
            }
        }, 0);
    });
    var listbox = $("#selectEmployeeDialogEmployeeListBox").kendoListBox({
        dataSource: dataSource,
        draggable: false,
        dataTextField: "Description",
        dataValueField: "Code",
        selectable: "single",
        template: kendo.template($("#employeeLookupTemplate").html())
    }).data("kendoListBox");
    if (listbox) {
        listbox.wrapper.find(".k-list").on("dblclick", ".k-item", function (e) {
            //console.log("doubleClick", e);
            selectEmployeeSelectButtonClick();
        });
    }
    //var data = {
    //};
    //$.get({
    //    url: window.appBase + "Employee/Timesheet/GetMyEmployees",
    //    dataType: "json",
    //    data: data
    //}).always(function (response) {
    //    if (response) {
    //        var lb = $("#selectEmployeeDialogEmployeeListBox").data("kendoListBox");
    //        if (lb) {
    //            lb.setDataSource(response);
    //            if (response.length > 1) {
    //                hookupEmployeeSelector(true);
    //            } else {
    //                hookupEmployeeSelector(false);
    //            }
    //            selectEmployeeInListBox();
    //        }
    //    }
    //});
}
function selectEmployeeInListBox() {
    window.setTimeout(function () {
        var lb = $("#selectEmployeeDialogEmployeeListBox").data("kendoListBox");
        if (lb.items()) {
            lb.clearSelection();
            if (lb.items().length == 1) {
                lb.select(lb.items()[0]);
                lb.items()[0].focus();
                //$("#selectEmployeeSelectButton").focus();
            } else {
                for (i = 0; i < lb.element.children().length; i++) {
                    if (employeeCode == $(lb.element.children()[i]).val()) {
                        lb.select(lb.items()[i]);
                        lb.items()[i].focus();
                    }
                }
                $("#selectEmployeeDialogEmployeeListBox").focus();
            }
        }
    }, 100);
}
//  Change row function
function rowChangeFunctionClick(selectedRow, rowId) {
    currentRowContextRowId = rowId * 1;
    showSelectFunctionDialog(selectedRow);
}
function showSelectFunctionDialog(selectedRow) {
    functionChangeRowInfo = null;
    var thisRow = new RowInfo(selectedRow);
    if (thisRow) {
        functionChangeRowInfo = thisRow;
        var thisType = "D";
        var thisJobNumber = 0;
        if (thisRow.JobNumber && thisRow.JobNumber > 0) {
            thisType = "D";
            thisJobNumber = thisRow.JobNumber;
        } else {
            thisType = "N";
            thisJobNumber = 0;
        }
        if (thisType == "N") {
            $("#selectFunctionDialog").ejDialog({
                title: "Available Categories"
            });
            $("#selectFunctionDialogFunction").attr("placeholder", "Select a category");
        } else {
            $("#selectFunctionDialog").ejDialog({
                title: "Available Functions"
            });
            $("#selectFunctionDialogFunction").attr("placeholder", "Select a function");
        }
        var data = {
            EmployeeCode: employeeCode,
            TimeType: thisType,
            JobNumber: thisJobNumber,
            IncludePleaseSelect: false
        };
        $.get({
            url: window.appBase + "Employee/Timesheet/GetFunctionsAndCategories",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                var lb = $("#selectFunctionsListBox").data("kendoListBox");
                if (lb) {
                    lb.setDataSource(response);
                    if (thisRow && thisRow.FunctionCode) {
                        if (lb.items()) {
                            for (i = 0; i < lb.element.children().length; i++) {
                                if (thisRow.FunctionCode == $(lb.element.children()[i]).val()) {
                                    lb.enable(lb.items()[i], false);
                                }
                            }
                            $("#selectFunctionDialogFunction").focus();
                            $("#selectFunctionDialog").ejDialog("open");
                        }
                    }
                }
            }
        });
    }
}
function selectFunctionSelectButtonClick() {
    var listbox = $("#selectFunctionsListBox").data("kendoListBox");
    var newFunctionCode;
    var updateKeys = [];
    var thisJobNumber = 0;
    var thisJobComponentNumber = 0;
    var isCategoryUpdate = false;
    if (functionChangeRowInfo.JobNumber && functionChangeRowInfo.JobNumber > 0) {
        thisJobNumber = functionChangeRowInfo.JobNumber;
    }
    if (functionChangeRowInfo.JobComponentNumber && functionChangeRowInfo.JobComponentNumber > 0) {
        thisJobComponentNumber = functionChangeRowInfo.JobComponentNumber;
    }
    if (thisJobNumber == 0 && thisJobComponentNumber == 0) {
        isCategoryUpdate = true;
    }
    if (listbox) {
        var element = listbox.select();
        var dataItem = listbox.dataItem(element[0]);
        if (dataItem && dataItem.Code) {
            newFunctionCode = dataItem.Code;
        }
    }
    //console.log("selectFunctionSelectButtonClick?", newFunctionCode);
    if (!newFunctionCode || newFunctionCode == "") {
        if (isCategoryUpdate == false) {
            showNotification("No function selected'", "warning");
        } else {
            showNotification("No category selected'", "warning");
        }
        selectFunctionCancelButtonClick();
    } else {
        if (functionChangeRowInfo && newFunctionCode) {
            var rowKey = "#" + functionChangeRowInfo.key;
            var row;
            var cell;
            $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
                //console.log("this", $(this));
                //console.log("$(this)[0]", $(this)[0]);
                //console.log("functionChangeRowInfo.key", functionChangeRowInfo.key);
                if ($(this)[0].id && $(this)[0].id == functionChangeRowInfo.key) {
                    row = $(this)[0];
                    if ($(row).attr("row-id") * 1 == currentRowContextRowId) {
                        //console.log("find row", $(row));
                        $(row).find("td.input-cell").each(function () {
                            cell = $(this)[0];
                            //console.log("cell??", cell);
                            if ($(cell).attr("property") && $(cell).attr("property") != "0|0") {
                                //updateEntryFunction($(cell).attr("property"), newFunctionCode);
                                updateKeys.push($(cell).attr("property"));
                            }
                        });
                    }
                }
            });
            if (updateKeys && updateKeys.length > 0) {
                saveClick();
                if (isCategoryUpdate == false) {
                    updateRowFunction(updateKeys, newFunctionCode);
                } else {
                    updateRowCategory(updateKeys, newFunctionCode);
                }
            }
        }
    }
}
function selectFunctionCancelButtonClick() {
    functionChangeRowInfo = null;
    currentRowContextRowId = 0;
    $("#selectFunctionDialog").ejDialog("close");
}
function updateRowFunction(keys, newFnc) {
    //console.log("updateRowFunction", keys.toString(), newFnc);
    var data = {
        Entries: keys.toString(),
        FunctionCode: newFnc,
        EmployeeCode: employeeCode
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/UpdateFunction",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            if (result.Success == true) {
                if (result.Message && result.Message != "") {
                    showNotification(result.Message);
                } else {
                    showSuccessNotification("Function updated for row.");
                }
                selectFunctionCancelButtonClick();
            }
            if (result.Success == false) {
                if (result.Message && result.Message != "") {
                    showNotification(result.Message, "error");
                } else {
                    showNotification("Function not updated.", "error");
                }
                selectFunctionCancelButtonClick();
            }
        }
        refreshTimesheet();
        currentRowContextRowId = 0;
    });
}
function updateRowCategory(keys, newCat) {
    //console.log("updateRowCategory", keys.toString(), newCat);
    var data = {
        Entries: keys.toString(),
        CategoryCode: newCat
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/UpdateCategory",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            if (result.Success == true) {
                showSuccessNotification("Category updated for row.");
                selectFunctionCancelButtonClick();
            }
            if (result.Success == false) {
                if (result.Message && result.Message != "") {
                    showNotification(result.Message, "error");
                } else {
                    showNotification("Category not updated.", "error");
                }
                selectFunctionCancelButtonClick();
            }
        }
        refreshTimesheet();
        currentRowContextRowId = 0;
    });
}
function rowDialogClosed(e) {
    currentRowContextRowId = 0;
    //console.log("rowDialogClosed", currentRowContextRowId);
}
//  Change row assignment
function rowChangeAssignmentClick(selectedRow, rowId) {
    currentRowContextRowId = rowId * 1;
    showChangeAssignmentDialog(selectedRow);
}
function showChangeAssignmentDialog(selectedRow) {
    if (currentRowContextRowId == 0) {
        //
    }
    assignmentChangeRowInfo = null;
    var thisRow = new RowInfo(selectedRow);
    if (thisRow) {
        assignmentChangeRowInfo = thisRow;
        var thisJobNumber = 0;
        var thisJobComponentNumber = 0;
        if (thisRow.JobNumber && thisRow.JobNumber > 0) {
            thisJobNumber = thisRow.JobNumber;
        }
        if (thisRow.JobComponentNumber && thisRow.JobComponentNumber > 0) {
            thisJobComponentNumber = thisRow.JobComponentNumber;
        }
        if (thisJobNumber && thisJobNumber > 0 && thisJobComponentNumber && thisJobComponentNumber > 0) {
            var data = {
                JobNumber: thisJobNumber,
                JobComponentNumber: thisJobComponentNumber
            };
            //console.log("showChangeAssignmentDialog");
            $.get({
                url: window.appBase + "Employee/Timesheet/GetJobAssignments?inclps=0&j=" + thisJobNumber + "&jc=" + thisJobComponentNumber,
                dataType: "json",
                data: data
            }).always(function (response) {
                if (response) {
                    var lb = $("#changeAssignmentDialogListBox").data("kendoListBox");
                    if (lb && response) {
                        lb.setDataSource(response);
                        if (thisRow && thisRow.AlertID) {
                            if (lb.items()) {
                                for (i = 0; i < lb.element.children().length; i++) {
                                    if (thisRow.AlertID == $(lb.element.children()[i]).val()) {
                                        lb.enable(lb.items()[i], false);
                                    }
                                }
                                $("#changeAssignmentDialog").focus();
                                $("#changeAssignmentDialog").ejDialog("open");
                            }
                        }
                    }
                    //$("#changeAssignmentDialogAssignmentInput").on("input", function (e) {
                    //    var listBox = $("#changeAssignmentDialogListBox").getKendoListBox();
                    //    if (listBox) {
                    //        var searchString = $(this).val();
                    //        if (searchString && searchString != "") {
                    //            listBox.dataSource.filter({ field: "Description", operator: "contains", value: searchString });
                    //        }
                    //    }
                    //});
                    //$("#changeAssignmentDialogListBox").kendoListBox({
                    //    dataSource: response,
                    //    dataTextField: "Description",
                    //    dataValueField: "AlertID",
                    //    selectable: "single"
                    //});
                    //var lb = $("#changeAssignmentDialogListBox").data("kendoListBox");
                    //if (lb) {
                    //    lb.destroy();
                    //    $("#changeAssignmentDialogListBox").kendoListBox({
                    //        //dataTextField: "Description",
                    //        //dataValueField: "AlertID",
                    //        selectable: "single"
                    //    });
                    //    lb = $("#changeAssignmentDialogListBox").data("kendoListBox");
                    //    //console.log("response?", response);
                    //    //lb.setDataSource(response);
                    //    for (i = 0; i < response.length; i++) {
                    //        //console.log(response[i])
                    //    }
                    //    if (thisRow && thisRow.AlertID) {
                    //        if (lb.items()) {
                    //            for (i = 0; i < lb.element.children().length; i++) {
                    //                if (thisRow.AlertID == $(lb.element.children()[i]).val()) {
                    //                    lb.enable(lb.items()[i], false);
                    //                }
                    //            }
                    //            $("#changeAssignmentDialog").focus();
                    //            $("#changeAssignmentDialog").ejDialog("open");
                    //        }
                    //    }
                    //    //console.log("length", response.length, lb.element.children().length);
                    //}
                }
            });
        } else {
            showNotification("Option not available for indirect time");
        }
    }
}
function changeAssignmentDialogSaveButtonClick() {
    var listbox = $("#changeAssignmentDialogListBox").data("kendoListBox");
    var newAlertId;
    var updateKeys = [];
    if (listbox) {
        var element = listbox.select();
        var dataItem = listbox.dataItem(element[0]);
        if (dataItem && dataItem.AlertID) {
            newAlertId = dataItem.AlertID * 1;
        }
    }
    if (!newAlertId || isNaN(newAlertId) == true || newAlertId == undefined || newAlertId == 0) {
        showNotification("No assignment selected");
        changeAssignmentDialogCancelButtonClick();
    } else {
        if (assignmentChangeRowInfo && newAlertId) {
            var rowKey = "#" + assignmentChangeRowInfo.key;
            var row;
            var cell;
            $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
                if ($(this)[0].id && $(this)[0].id == assignmentChangeRowInfo.key) {
                    row = $(this)[0];
                    if ($(row).attr("row-id") * 1 == currentRowContextRowId) {
                        $(row).find("td").each(function () {
                            cell = $(this)[0];
                            if ($(cell).attr("property") && $(cell).attr("property") != "0|0") {
                                //updateEntryFunction($(cell).attr("property"), newFunctionCode);
                                updateKeys.push($(cell).attr("property"));
                            }
                        });
                    }
                }
            });
            if (updateKeys && updateKeys.length > 0) {
                saveClick();
                updateRowAssignment(updateKeys, newAlertId);
            }
        }
    }
}
function changeAssignmentDialogCancelButtonClick() {
    assignmentChangeRowInfo = null;
    currentRowContextRowId = 0;
    var lb = $("#changeAssignmentDialogListBox").data("kendoListBox");
    if (lb) {
        lb.dataSource.data([]);
    }
    $("#changeAssignmentDialog").ejDialog("close");
}
function updateRowAssignment(keys, alertId) {
    //console.log("updateRowAssignment", keys.toString(), alertId);
    var data = {
        Entries: keys.toString(),
        AlertID: alertId
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/UpdateAssignment",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result) {
            if (result.Success == true) {
                showSuccessNotification("Assignment updated for row.");
                changeAssignmentDialogCancelButtonClick();
            }
            if (result.Success == false) {
                if (result.Message && result.Message != "") {
                    showNotification(result.Message, "error");
                } else {
                    showNotification("Assignment not updated.", "error");
                }
                changeAssignmentDialogCancelButtonClick();
            }
        }
        refreshTimesheet();
        currentRowContextRowId = 0;
    });
}
//  Start stopwatch from row
function startStopwatchFromRow(selectedRowKey) {
    saveClick("startStopwatchFromRow", selectedRowKey);
}
function _startStopwatchFromRow(selectedRowKey) {
    stopWatchRowInfo = null;
    var thisRow = new RowInfo(selectedRowKey);
    if (thisRow) {
        stopWatchRowInfo = thisRow;
        var todayDate = new Date();
        var data = {
            EmployeeCode: employeeCode,
            EntryDate: kendo.toString(todayDate, "d"),
            JobNumber: stopWatchRowInfo.JobNumber,
            JobComponentNumber: stopWatchRowInfo.JobComponentNumber,
            FunctionCode: stopWatchRowInfo.FunctionCode,
            AlertID: stopWatchRowInfo.AlertID
        };
        //console.log("startStopwatchFromRow data", data);
        $.post({
            url: window.appBase + "Employee/Timesheet/StartStopwatchFromRow",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
                //console.log("startStopwatchFromRow result", result);
                if (result.Success && result.Success == true) {
                    refreshTimesheet();
                    checkForStopwatch();
                    showSuccessNotification("Stopwatch started.");
                } else {
                    if (result.Message && result.Message != "") {
                        try {
                            showNotification(JSON.parse(result.Message), "error");
                        } catch (e) {
                            showNotification(result.Message, "error");
                        }
                    }
                }
            }
            refreshTimesheet();
        });
    }
}
//  Copy row
function copyRow(selectedRowKey) {
    saveClick("copyRow", selectedRowKey);
}
function _copyRow(selectedRowKey) {
    copyRowRowInfo = null;
    var thisRow = new RowInfo(selectedRowKey);
    if (thisRow) {
        saveClick();
        copyRowRowInfo = thisRow;
        // Get actual row and then get first entry that is real
        var rowKey = "#" + selectedRowKey;
        var row;
        var cell;
        var existingDate;
        $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
            if ($(this)[0].id && $(this)[0].id == selectedRowKey) {
                row = $(this)[0];
                $(row).find("td.input-cell").each(function () {
                    cell = $(this)[0];
                    if ($(cell).attr("property") && $(cell).attr("property") != "0|0") {
                        existingDate = $(cell).attr("abbr");
                    }
                });
            }
        });
        if (!existingDate) {
            existingDate = kendo.toString(startDate, "d");
        }
        var data = {
            EmployeeCode: employeeCode,
            StartDate: existingDate,
            JobNumber: copyRowRowInfo.JobNumber,
            JobComponentNumber: copyRowRowInfo.JobComponentNumber,
            FunctionCategoryCode: copyRowRowInfo.FunctionCode,
            AlertID: copyRowRowInfo.AlertID
        };
        //console.log("copyRow data", data);
        $.post({
            url: window.appBase + "Employee/Timesheet/CopyRow",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log(response);
                showSuccessNotification("Row copied.");
                refreshTimesheet();
            }
        });
    }
}
//  Copy 
function copyFromOptionsClick() {
    saveClick("copyFromOptionsClick");
}
function _copyFromOptionsClick() {
    if (copyPanelVisible == false) {
        showCopyPanel();
    } else {
        hideCopyPanel();
    }
    copyPanelVisible = !copyPanelVisible;
    hideProgress();    
}
//  Copy To
function copyToOptionsClick() {
    saveClick("copyToOptionsClick");
}
function _copyToOptionsClick() {
    $("#copyToDialogCopyItems").focus();
    $("#copyToDialog").ejDialog("open");
}
function copyToDialogSelectButtonClick() {
    //saveClick();
    var saveType = $("#copyToDialogCopyItemsButtonGroup > .k-state-active")[0].innerText.toLowerCase();
    if (saveType.indexOf("timesheet") > -1 == true) {
        copyEntireTimesheet();
    } else if (saveType.indexOf("rows") > -1 == true) {
        if (hasSelectedRows() == false) {
            showNotification("No rows selected to copy!", "warning");
        } else {
            copySelectedRows();
        }
    }
}
function copyEntireTimesheet() {
    var calendar = $("#copyToDialogCalendar").data("kendoCalendar");
    var typeItem = $("#copyToDialogCopyItemsButtonGroup > .k-state-active")[0];
    var targetDate = kendo.toString(calendar.value(), "d");
    var isSingleDay = false;
    var type;
    if (typeItem.innerText.toLowerCase().indexOf("timesheet") > -1 == true) {
        type = 0;
    } else {
        type = 1;
    }
    if ($("#DayOrWeek > .k-state-active").attr("view") == "Week") {
        isSingleDay = false;
    } else {
        isSingleDay = true;
    }
    var data = {
        Type: type,
        EmployeeCode: employeeCode,
        SourceDate: $("#DatePicker")[0].value,
        TargetDate: targetDate,
        IncludeHours: $("#copyToDialogIncludeHoursCheckBox").is(":checked"),
        IncludeComments: $("#copyToDialogIncludeCommentsCheckBox").is(":checked"),
        SingleDay: isSingleDay
    };
    //if (!data.Type) {
    //    showNotification("Please select whether to copy the entire timesheet or just the selected rows", "error");
    //    return;
    //}
    //if (!data.TargetDate) {
    //    showNotification("Please use the calendar and select a date to copy to", "error");
    //    return;
    //}
    //if (!data.SourceDate || !data.EmployeeCode) {
    //    showNotification("Cannot get required parameters.", "error");
    //    return;
    //}
    $.post({
        url: window.appBase + "Employee/Timesheet/CopyTimesheet",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            //console.log("copyToDialogSelectButtonClick", response);
            if (response.Success == true) {
                setDatePickerDate(kendo.toString(calendar.value(), "d"));
                copyToDialogCancelButtonClick();
                navigate();
            } else {
                if (response.Message && response.Message != "") {
                    showNotification(response.Message, "error");
                }
            }
        }
    });
}
function copySelectedRows() {
    //console.log("copySelectedRows");
    var calendar = $("#copyToDialogCalendar").data("kendoCalendar");
    var sourceDate = $("#DatePicker")[0].value;
    var targetDate = kendo.toString(calendar.value(), "d");
    var includeHours = $("#copyToDialogIncludeHoursCheckBox").is(":checked");
    var includeComments = $("#copyToDialogIncludeCommentsCheckBox").is(":checked");
    var copyRowsInfos = [];
    for (var i = selectedRows.length; i--;) {
        if (selectedRows[i]) {
            var row;
            var cell;
            $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
                if ($(this)[0].id && $(this)[0].id == selectedRows[i].RowInfo.key) {
                    row = $(this)[0];
                    if ($(row).attr("row-id") * 1 == selectedRows[i].ID) {
                        $(row).find("td.input-cell").each(function () {
                            cell = $(this)[0];
                            if ($(cell).attr("property") && $(cell).attr("property") != "0|0") {
                                var hoursTb;
                                $(cell).find("input.hours-textbox").each(function () {
                                    if (this) {
                                        hoursTb = this;
                                        if (hoursTb.id) {
                                            let entryInfo = new EntryInfo(hoursTb.id);
                                            if (entryInfo && entryInfo.EmployeeTimeID > 0 && entryInfo.EmployeeTimeDetailID > 0) {
                                                if (!entryInfo.TimeType || entryInfo.TimeType == "" || entryInfo.TimeType == undefined) {
                                                    if (entryInfo.JobNumber && entryInfo.JobNumber > 0) {
                                                        entryInfo.TimeType = "D";
                                                    } else {
                                                        entryInfo.TimeType = "N";
                                                    }
                                                }
                                                var copyInfo = {
                                                    EmployeeTimeID: entryInfo.EmployeeTimeID,
                                                    EmployeeTimeDetailID: entryInfo.EmployeeTimeDetailID,
                                                    TimeType: entryInfo.TimeType,
                                                    EntryDate: entryInfo.EntryDate,
                                                    Hours: entryInfo.Hours,
                                                    Comment: entryInfo.Comment
                                                };
                                                copyRowsInfos.push(copyInfo);
                                            }
                                        }
                                    }
                                });
                            }
                        });
                    }
                }
            });
        }
    }
    if (copyRowsInfos && copyRowsInfos.length > 0) {
        showProgress();
        try {
            var data = {
                EmployeeCode: employeeCode,
                SourceDate: sourceDate,
                TargetDate: targetDate,
                IncludeHours: includeHours,
                IncludeComments: includeComments,
                Entries: JSON.stringify(copyRowsInfos)
            }
            //console.log("Send update", data);
            $.post({
                url: window.appBase + "Employee/Timesheet/CopySelectedRows",
                dataType: "json",
                data: data
            }).always(function (result) {
                hideProgress();
                copyToDialogCancelButtonClick();
                unCheckAndClearAllSelectedRows();
                if (result) {
                    console.log("Copy results!", result.Data.ErrorMessages);
                    if (result.Data.Failed * 1 > 0) {
                        showNotification("Some entries could not be copied.", "error");
                    } else if (result.Data.Saved * 1 == 0) {
                        showNotification("No entries were copied.", "error");
                    }
                    if (result.Data.ErrorMessages.length > 0) {
                        var s = "";
                        for (var i = 0; i < result.Data.ErrorMessages.length; i++) {
                            s = "";
                            s = result.Data.ErrorMessages[i];
                            if (s && s != "" && s.indexOf("SUCCESS") == -1) {
                                showNotification(s, "error");
                            }
                        }
                    }
                    if (result.Data.Saved * 1 > 0) {
                        if (result.Data.Failed * 1 == 0) {
                            // Everything saved correctly
                        }
                        //if (response.Data.CopiedToDate && response.Data.CopiedToDate != "") {
                        //    //console.log("copySelectedRows", response.Data.CopiedToDate);
                        setDatePickerDate(targetDate);
                        navigate();
                        //} else {
                        //    refreshTimesheet();
                        //}
                    }
                }
            });
        } catch (e) {
            hideProgress();
        }
    }
}
function copyToDialogCancelButtonClick() {
    $("#copyToDialog").ejDialog("close");
}
//  Export to Excel
function exportToExcel() {
    saveClick("exportToExcel");
}
function _exportToExcel() {
    window.location.href = window.appBase + "Employee/Timesheet/GetReport?EmployeeCode=" + employeeCode + "&StartDate=" + startDate + "&DaysToGet=7&Sort=1";
}
function openPrintSettingsPage() {
    saveClick("openPrintSettingsPage");
}
function _openPrintSettingsPage() {
    hideProgress();
    var shortDate = kendo.toString(startDate, "d");
    var url = window.appBase + "Timesheet_QuickPrintSettings.aspx?empcode=" + employeeCode + "&tsdate=" + kendo.toString(startDate, "d") + "&sortkey=&Type=1&Report=timesheetprint";
    $("#approvalCommentDialog").ejDialog({
        contentUrl: url,
        title: "Print Timesheet",
        closeOnEscape: true,
        showOnInit: false,
        contentType: "iframe",
        height: "400px",
        width: "450px",
        showFooter: false,
        enableModal: true,
        backgroundScroll: false,
        enableResize: false
    });
    $("#approvalCommentDialog").ejDialog("open");
    $("#approvalCommentDialog").ejDialog("refresh");
}
//  Agency Settings
function initAgencySettings() {
    //console.log("initAgencySettings")
    agencyTimesheetSettings = new AgencyTimesheetSettings();
    var data = {
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/GetTimesheetAgencySettings",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            agencyTimesheetSettings = response;
            if (agencyTimesheetSettings) {
                //console.log("GetTimesheetAgencySettings", agencyTimesheetSettings);
                useCopyTimesheetFeature = agencyTimesheetSettings.UseCopyTimesheetFeature;
                agencyCommentsRequired = agencyTimesheetSettings.RequireTimeComments;
                if (useCopyTimesheetFeature == false) {
                    $("#copyToListItem").hide();
                    $("#copyFromListItem").hide();
                }
                if (agencyTimesheetSettings.AllowCopyOfTimesheetHours == false) {
                    $("#copyToDialogIncludeHoursDiv").hide();
                }
            }
        }
    });
}

// Editing
function hoursKeyUp(tb) {
    var hoursValue = 0;
    if (tb.value != "." && tb.value != "," && tb.value != "-" && tb.value != "-." && tb.value != "-,") {
        if (jQuery.isNumeric(tb.value) == false) {
            tb.value = "";
            return false;
        }
    }
    if (isNaN(tb.value) == false) {
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
    calculateTotals(tb);
}
function hoursChanged(tb) {
    if (tb) {
        //  Changes
        var hasChange = false;
        var hasCommentChange = false;
        var row = tb.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement;
        var commentCell;
        var commentTextArea;
        var defaultTextArea;
        var comments = "";
        var defaultComments = "";
        var isDelete = false;
        var inputId = tb.id;
        var rowId;
        var originalHasHours = false;
        var changeHasHours = false;
        var rowNumber = -1;
        if (row) {
            rowId = row.id;
            rowNumber = getRowNumber(row);
        }
        //console.log("row number", rowNumber);
        let rowInfo = new RowInfo(rowId);
        commentCell = tb.parentElement.parentElement;
        var isUpdate = false;
        var entryDate = tb.getAttribute("entry-date");
        var thisEntry;
        if (inputId && inputId != "") {
            isUpdate = true;
        }
        if (commentCell) {
            commentTextArea = $(commentCell).find("#commentsInput")[0];
            defaultTextArea = $(commentCell).find("#commentsDefault")[0];
        }
        if (commentTextArea) {
            comments = commentTextArea.value;
        }
        if (defaultTextArea) {
            defaultComments = defaultTextArea.value;
        }
        if (tb.defaultValue != tb.value) {
            hasChange = true;
        }
        if (defaultComments != comments) {
            hasChange = true;
            hasCommentChange = true;
        }
        if (hasChange == true) {
            var oldVal;
            var newVal;
            if (tb.defaultValue != "" && isNaN(tb.defaultValue) == false) {
                oldVal = tb.defaultValue * 1;
                originalHasHours = true;
            } else {
                originalHasHours = false;
            }
            if (tb.value != "" && isNaN(tb.value) == false) {
                newVal = tb.value * 1;
                if (newVal > 24) {
                    newVal = 24;
                    tb.value = newVal;
                }
                changeHasHours = true;
            } else {
                changeHasHours = false;
            }
            if (oldVal == newVal && hasCommentChange == false) {
                hasChange = false;
            }
            if (originalHasHours == false && changeHasHours == false) {
                hasChange = false;
            } else if (originalHasHours == true && changeHasHours == true) {
                isUpdate = true;
            } else if (originalHasHours == true && changeHasHours == false) {
                isDelete = true;
            } else if (originalHasHours == false && changeHasHours == true) {
                isUpdate = false;
            }
            //console.log("hasCHANGE???", hasChange);
            if (hasChange == false) {
                thisEntry = null;
                thisEntry = new EntryInfo(inputId);
                if (thisEntry) {
                    thisEntry.RowNumber = rowNumber;
                    removeInsert(thisEntry);
                    removeUpdate(thisEntry);
                    removeDelete(thisEntry);
                }
            }
        }
        //console.log("hasChange", hasChange, oldVal, newVal, isDelete, hasCommentChange);
        if (hasChange == true || hasCommentChange == true) {
            var hours = 0;
            if (tb.value && isNaN(tb.value) == false) {
                hours = tb.value * 1;
            }
            if (isUpdate == true) {
                try {
                    thisEntry = null;
                    thisEntry = new EntryInfo(inputId);
                    thisEntry.RowNumber = rowNumber;
                    if (thisEntry.Hours != hours || hasChange == true || hasCommentChange == true) {
                        thisEntry.Hours = hours;
                        thisEntry.Comment = comments;
                        if (thisEntry.Comment && thisEntry.Comment != "") {
                            thisEntry.HasComments = true;
                        } else {
                            thisEntry.HasComments = false;
                        }
                        if (isDelete == false) {
                            removeDelete(thisEntry);
                            if (thisEntry.HasComments == false && thisEntry.CommentsRequired == true && isViewingSingleDay == true && hours != 0) {
                                $(commentTextArea).focus();
                                showNotification("Comment required.", "error");
                                return false;
                            } else {
                                //console.log("entry?", thisEntry);
                                addUpdate(thisEntry);
                            }
                        } else {
                            addDelete(thisEntry);
                        }
                    }
                } catch (e) {
                    //
                }
            } else {
                //  Inserts
                try {
                    thisEntry = null;
                    thisEntry = new EntryInfo();
                    thisEntry.RowNumber = rowNumber;
                    var hasJobNumber = false;
                    var hasJobComponentNumber = false;
                    thisEntry.EmployeeCode = employeeCode;
                    thisEntry.EntryDate = entryDate;
                    if (rowInfo.JobNumber && rowInfo.JobNumber > 0) {
                        thisEntry.JobNumber = rowInfo.JobNumber;
                        hasJobNumber = true;
                    }
                    if (rowInfo.JobComponentNumber && rowInfo.JobComponentNumber > 0) {
                        thisEntry.JobComponentNumber = rowInfo.JobComponentNumber;
                        hasJobComponentNumber = true;
                    }
                    if (hasJobNumber == true && hasJobComponentNumber == true) {
                        thisEntry.TimeType = "D";
                    } else {
                        thisEntry.TimeType = "N";
                    }
                    thisEntry.FunctionCategoryCode = rowInfo.FunctionCode;
                    thisEntry.DepartmentTeamCode = rowInfo.DepartmentTeamCode;
                    thisEntry.Hours = hours;
                    thisEntry.Comment = comments;
                    if (thisEntry.Comment && thisEntry.Comment != "") {
                        thisEntry.HasComments = true;
                    }
                    thisEntry.AlertID = rowInfo.AlertID;
                    thisEntry.key = employeeCode
                        + "|" + rowInfo.FunctionCode
                        + "|" + rowInfo.DepartmentTeamCode
                        + "|" + rowInfo.JobNumber
                        + "|" + rowInfo.JobComponentNumber
                        + "|" + "0"
                        + "|" + "0"
                        + "|" + "0"
                        + "|" + thisEntry.TimeType
                        + "|" + entryDate
                        + "|" + "false"
                        + "|" + "false"
                        + "|" + "0"
                        + "|" + rowInfo.AlertID;
                    addInsert(thisEntry);
                } catch (e) {
                    //
                }
            }
            setSaveCancelButtons();
        }
        // End hasChange
        calculateTotals(tb);
    }
}
function commentsChanged(ta) {
    if (ta) {
        var hasChange = false;
        var commentDiv;
        var row;
        var entryRow;
        var commentTextArea;
        var defaultTextArea;
        var comments = "";
        var defaultComments = "";
        var hours = 0;
        commentDiv = ta.parentElement;
        row = ta.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement;
        entryRow = ta.parentElement.parentElement.parentElement;
        if (commentDiv) {
            commentTextArea = $(commentDiv).find("#commentsInput")[0];
            defaultTextArea = $(commentDiv).find("#commentsDefault")[0];
        }
        if (commentTextArea) {
            comments = commentTextArea.value;
        }
        if (defaultTextArea) {
            defaultComments = defaultTextArea.value;
        }
        if (defaultComments != comments) {
            hasChange = true;
        }
        //console.log("commentsChanged", defaultComments, comments);
        if (hasChange == true) {
            if (entryRow) {
                var hoursTb;
                hoursTb = $(entryRow).find("input.hours-textbox")[0];
                if (hoursTb) {
                    if (isNaN($(hoursTb).val()) == true || $(hoursTb).val() == "") {
                        //console.log("NO VALUE!");
                        $(hoursTb).val(0);
                    }
                    hoursChanged(hoursTb);
                }
            }
        }
    }
}
function calculateTotals(tb) {
    var row = tb.parentElement.parentElement.parentElement.parentElement.parentElement.parentElement;
    //  Row total
    try {
        if (row) {
            var rowTotal = 0;
            var totalSpan = $(row).find("#totalRowHours");
            var numberOfDays = 0;
            $(row).find("input.hours-textbox").each(function () {
                numberOfDays += 1;
                if (isNaN($(this).val()) == false) {
                    rowTotal += $(this).val() * 1;
                }
            });
            if (totalSpan) {
                totalSpan.text(kendo.toString(rowTotal, "n"));
                //try {
                //    if (rowTotal > numberOfDays * 24) {
                //    } else {
                //    }
                //} catch (e) {
                //    //console.log("err");
                //}
            }
        }
    } catch (e) {
        //console.log("hoursChanged Row total Error", e);
    }
    //  Column total
    var cell = $(tb).parent().parent().parent().parent().parent();
    try {
        if (cell) {
            var colIndex = $(cell).index();
            var allCellsOnTheColumn = $(cell).closest('table').find('tr').find('>td:eq(' + colIndex + ')');
            if (allCellsOnTheColumn) {
                var colTotal = 0;
                //var colTotalSpan = $(allCellsOnTheColumn).find("#totalColHours");
                var colTotalCell = $(allCellsOnTheColumn).find("#footerTotalCell");
                var d = "";
                d = $(cell).attr("abbr");
                d = d.replace("/", "");
                d = d.replace("/", "");
                //console.log("d", d);
                $(allCellsOnTheColumn).find("input.hours-textbox").each(function () {
                    if (isNaN($(this).val()) == false) {
                        colTotal += $(this).val() * 1;
                    }
                });
                //console.log("total", colTotal);
                var colTotalSpan = $("#totalColHours-" + d);
                //console.log("found colTotalSpan?", colTotalSpan);
                //var colTotalSpan = $("#totalColHours-7/15/2019");
                //console.log("found colTotalSpan?", colTotalSpan);
                if (colTotalSpan) {
                    colTotalSpan.text(kendo.toString(colTotal, "n"));
                }
                //if (colTotalSpan) {
                //    //var dayGoal = 0;
                //    //if (isNaN(colTotalSpan.attr("hours-goal")) == false) {
                //    //    dayGoal = colTotalSpan.attr("hours-goal") * 1;
                //    //}
                //    //if (dayGoal > 0) {
                //    //    colTotalCell.prop("title", "Goal:  " + kendo.toString(dayGoal, "n"));
                //    //}
                //    //console.log("goal", colTotalSpan.attr("hours-goal"));
                //    colTotalSpan.text(kendo.toString(colTotal, "n"));
                //}
            }
        }
    } catch (e) {
        //console.log("hoursChanged Column Total Error", e);
    }
    //  Grand total:
    var grandTotal = 0;
    var grandTotalSpan = $("#totalGridHours");
    try {
        $("#employeeTimeTable").find("input.hours-textbox").each(function () {
            if (isNaN($(this).val()) == false) {
                grandTotal += $(this).val() * 1;
            }
        });
        if (grandTotalSpan) {
            grandTotalSpan.text(kendo.toString(grandTotal, "n"));
        }
    } catch (e) {
        //console.log("hoursChanged Grand total Error", e);
    }

}
function clearAllEdits() {
    inserts = [];
    updates = [];
    deletes = [];
    setSaveCancelButtons();
}
function setSaveCancelButtons() {
    if (inserts.length > 0 || updates.length > 0 || deletes.length > 0) {
        enableSaveButton();
        enableCancelButton();
    } else {
        if (inserts.length == 0 && updates.length == 0 && deletes.length == 0) {
            disableSaveButton();
            disableCancelButton();
        }
    }
}
function addUpdate(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        removeDelete(entryInfo);
        removeUpdate(entryInfo);
        updates.push(entryInfo);
        //console.log("Update added", entryInfo.key, updates.length);
    } else {
        //console.log("addUpdate:No entryInfo");
    }
}
function addInsert(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        //console.log("addInsert:entryInfo:", entryInfo);
        removeInsert(entryInfo);
        inserts.push(entryInfo);
        //console.log("Insert added entryInfo.key", entryInfo.key);
        //console.log("Insert added inserts", inserts);
    } else {
        //console.log("addInsert:No entryInfo");
    }
}
function addDelete(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        removeUpdate(entryInfo);
        removeDelete(entryInfo);
        deletes.push(entryInfo);
        //console.log("Delete added", entryInfo.key, deletes.length);
    } else {
        //console.log("addDelete:No entryInfo");
    }
}
function removeUpdate(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        var key = entryInfo.key;
        var rowNumber = entryInfo.RowNumber;
        if (key) {
            if (updates && updates.length > 0) {
                for (var i = updates.length; i--;) {
                    if (updates[i]) {
                        if (updates[i].key == key && updates[i].RowNumber == rowNumber) {
                            updates.splice(i, 1);
                            //console.log("Update removed", key);
                        }
                    }
                }
            }
        } else {
            if (updates && updates.length > 0) {
                for (var i = updates.length; i--;) {
                    if (updates[i]) {
                        var newUpdateKey = "";
                        var existingUpdateKey = "";
                        newUpdateKey = tempKey(entryInfo);
                        existingUpdateKey = tempKey(updates[i]);
                        if (newUpdateKey == existingUpdateKey) {
                            updates.splice(i, 1);
                            //console.log("Update removed", key);
                        }
                    }
                }
            }
        }
    }
}
function removeInsert(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        var key = entryInfo.key;
        var rowNumber = entryInfo.RowNumber;
        if (key) {
            //console.log("removeInsert key", key)
            //console.log("removeInsert inserts", inserts)
            if (inserts && inserts.length > 0) {
                for (var i = inserts.length; i--;) {
                    if (inserts[i]) {
                        if (inserts[i].key == key && inserts[i].RowNumber == rowNumber) {
                            inserts.splice(i, 1);
                            //console.log("Insert removed has key", key);
                        }
                    }
                }
            }
        } else {
            if (inserts && inserts.length > 0) {
                for (var i = inserts.length; i--;) {
                    if (inserts[i]) {
                        var newInsertKey = "";
                        var existingInsertKey = "";
                        newInsertKey = tempKey(entryInfo);
                        existingInsertKey = tempKey(inserts[i]);
                        if (newInsertKey == existingInsertKey && inserts[i].RowNumber == rowNumber) {
                            //console.log("keys?", newInsertKey, existingInsertKey);
                            inserts.splice(i, 1);
                            //console.log("Insert removed [no key path]", newInsertKey, existingInsertKey);
                        }
                    }
                }
            }
        }
    }
}
function removeDelete(entryInfo) {
    if (entryInfo && entryInfo != undefined) {
        var key = entryInfo.key;
        var rowNumber = entryInfo.RowNumber;
        if (key) {
            if (deletes && deletes.length > 0) {
                for (var i = deletes.length; i--;) {
                    if (deletes[i]) {
                        if (deletes[i].key == key && deletes[i].RowNumber == rowNumber) {
                            deletes.splice(i, 1);
                            //console.log("Delete removed", key);
                        }
                    }
                }
            }
        } else {
            if (deletes && deletes.length > 0) {
                for (var i = deletes.length; i--;) {
                    if (deletes[i]) {
                        var newDeleteKey = "";
                        var existingDeleteKey = "";
                        newDeleteKey = tempKey(entryInfo);
                        existingDeleteKey = tempKey(deletes[i]);
                        if (newDeleteKey == existingDeleteKey) {
                            deletes.splice(i, 1);
                            //console.log("Delete removed", key);
                        }
                    }
                }
            }
        }
    }
}
function tempKey(entryInfo) {
    var s = "";
    if (entryInfo.EmployeeCode) {
        s += entryInfo.EmployeeCode + "|";
    } else {
        s += "|";
    }
    if (entryInfo.FunctionCategoryCode) {
        s += entryInfo.FunctionCategoryCode + "|";
    } else {
        s += "|";
    }
    if (entryInfo.DepartmentTeamCode) {
        s += entryInfo.DepartmentTeamCode + "|";
    } else {
        s += "|";
    }
    if (entryInfo.JobNumber) {
        s += entryInfo.JobNumber + "|";
    } else {
        s += "|";
    }
    if (entryInfo.JobComponentNumber) {
        s += entryInfo.JobComponentNumber + "|";
    } else {
        s += "|";
    }
    if (entryInfo.EmployeeTimeID) {
        s += entryInfo.EmployeeTimeID + "|";
    } else {
        s += "|";
    }
    if (entryInfo.EmployeeTimeDetailID) {
        s += entryInfo.EmployeeTimeDetailID + "|";
    } else {
        s += "|";
    }
    if (entryInfo.EditFlag) {
        s += entryInfo.EditFlag + "|";
    } else {
        s += "|";
    }
    if (entryInfo.TimeType) {
        s += entryInfo.TimeType + "|";
    } else {
        s += "|";
    }
    if (entryInfo.EntryDate) {
        s += entryInfo.EntryDate + "|";
    } else {
        s += "|";
    }
    if (entryInfo.CommentsRequired) {
        s += entryInfo.CommentsRequired + "|";
    } else {
        s += "|";
    }
    if (entryInfo.HasComments) {
        s += entryInfo.HasComments + "|";
    } else {
        s += "|";
    }
    s += "0|";  // Hours
    if (entryInfo.AlertID) {
        s += entryInfo.AlertID + "|";
    } else {
        s += "|";
    }
    return s;
}
function updateDashboardWeeklyHours() {
    this.refreshDashboardTime();
}
function saveClick(executeAfter, fnObj, fnObj2) {
    //console.log("saveClick", executeAfter, fnObj, fnObj2)
    //console.log("saveClick")
    //console.log("inserts", inserts)
    //console.log("updates", updates)
    //console.log("deletes", deletes)
    insertsCount = inserts.length;
    updatesCount = updates.length;
    deletesCount = deletes.length;
    insertedCount = 0;
    insertedFailedCount = 0;
    updatedCount = 0;
    updatedFailedCount = 0;
    deletedCount = 0;
    deletedFailedCount;
    hasInserts = false;
    hasUpdates = false;
    hasDeletes = false;
    if (insertsCount > 0) {
        hasInserts = true;
    }
    if (updatesCount > 0) {
        hasUpdates = true;
    }
    if (deletesCount > 0) {
        hasDeletes = true;
    }
    if (hasUpdates == true || hasInserts == true || hasDeletes == true) {
        var hasUpdated = false;
        showProgress();
        var saveData = {
            Inserts: inserts,
            Updates: updates,
            Deletes: deletes
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/SaveTimesheetWeekViewChanges",
            dataType: "json",
            data: saveData
        }).always(function (result) {
            if (result && result.Data) {
                //console.log("SaveTimesheetWeekViewChanges", result);
                var deleteFails = 0;
                var deleteSuccesses = 0;
                var deleteTotal = 0;
                var insertFails = 0;
                var insertSuccesses = 0;
                var insertTotal = 0;
                var updateFails = 0;
                var updateSuccesses = 0;
                var updateTotal = 0;
                var hasEstimateWarning = false;
                var blockedByExceedOption = false;
                var estimateWarning = "";
                if (result.Data.DeleteFails && isNaN(result.Data.DeleteFails) == false) {
                    deleteFails = result.Data.DeleteFails * 1;
                }
                if (result.Data.DeleteSuccesses && isNaN(result.Data.DeleteSuccesses) == false) {
                    deleteSuccesses = result.Data.DeleteSuccesses * 1;
                }
                if (result.Data.DeleteTotal && isNaN(result.Data.DeleteTotal) == false) {
                    deleteTotal = result.Data.DeleteTotal * 1;
                }
                if (result.Data.InsertFails && isNaN(result.Data.InsertFails) == false) {
                    insertFails = result.Data.InsertFails * 1;
                }
                if (result.Data.InsertSuccesses && isNaN(result.Data.InsertSuccesses) == false) {
                    insertSuccesses = result.Data.InsertSuccesses * 1;
                }
                if (result.Data.InsertTotal && isNaN(result.Data.InsertTotal) == false) {
                    insertTotal = result.Data.InsertTotal * 1;
                }
                if (result.Data.UpdateFails && isNaN(result.Data.UpdateFails) == false) {
                    updateFails = result.Data.UpdateFails * 1;
                }
                if (result.Data.UpdateSuccesses && isNaN(result.Data.UpdateSuccesses) == false) {
                    updateSuccesses = result.Data.UpdateSuccesses * 1;
                }
                if (result.Data.UpdateTotal && isNaN(result.Data.UpdateTotal) == false) {
                    updateTotal = result.Data.UpdateTotal * 1;
                }
                if (result.Data.HasEstimateWarning) {
                    hasEstimateWarning = result.Data.HasEstimateWarning;
                }
                if (result.Data.EstimateWarning) {
                    estimateWarning = result.Data.EstimateWarning;
                }
                if (result.Data.BlockedByExceedOption) {
                    blockedByExceedOption = result.Data.BlockedByExceedOption;
                }
                if (deleteFails && deleteFails > 0) {
                    var delMsg = "";
                    if (deleteFails == 1) {
                        delMsg = "One entry";
                    } else if (deleteFails > 1) {
                        delMsg = deleteFails + " entries";
                    }
                    delMsg = delMsg + " did not delete.";
                    showNotification(delMsg, "error");
                }
                if (insertFails && insertFails > 0) {
                    var insMsg = "";
                    if (insertFails == 1) {
                        insMsg = "One entry";
                    } else if (insertFails > 1) {
                        insMsg = insertFails + " entries";
                    }
                    insMsg = insMsg + " did not insert.";
                    showNotification(insMsg, "error");
                }
                if (updateFails && updateFails > 0) {
                    var updMsg = "";
                    if (updateFails == 1) {
                        updMsg = "One entry";
                    } else if (updateFails > 1) {
                        updMsg = updateFails + " entries";
                    }
                    updMsg = updMsg + " did not update.";
                    showNotification(updMsg, "error");
                }
                if (hasEstimateWarning == true) {
                    if (estimateWarning != "") {
                        if (blockedByExceedOption == false) {
                            showNotification(estimateWarning, "info");
                        } else {
                            showNotification(estimateWarning, "error");
                        }
                    }
                }
            }
            inserts = [];
            updates = [];
            deletes = [];
            setSaveCancelButtons();
            if (executeAfter && executeAfter != "") {
                //console.log("saveClick: executeAfter!!", executeAfter, fnObj, fnObj2);
                executeAfterSave(executeAfter, true, fnObj, fnObj2);
            } else {
                window.setTimeout(function () {
                    refreshTimesheet();
                    hasUpdated = true;
                    resetAfterSave();
                }, 500);
                checkForSaveFail();
                updateDashboardWeeklyHours();
            }
        });
    } else {
        //console.log("?", executeAfter);
        if (executeAfter && executeAfter != "") {
            //console.log("before?")
            executeAfterSave(executeAfter, false, fnObj, fnObj2);
        }
    }
}
function executeAfterSave(executeAfter, hasChanges, fnObj, fnObj2) {
    //console.log("executeAfterSave", executeAfter, fnObj, fnObj2);
    //if (executeAfter == "") {
    //}
    var reset = false;
    if (executeAfter == "submitWeekForApproval") {
        _submitWeekForApproval();
    }
    if (executeAfter == "submitForApproval" && fnObj != undefined) {
        _submitForApproval(fnObj);
    }
    if (executeAfter == "groupDropDownListChanged") {
        _groupDropDownListChanged();
    }
    if (executeAfter == "sortDropDownListChanged") {
        _sortDropDownListChanged();
    }
    if (executeAfter == "dayOrWeekSelect" && fnObj != undefined) {
        _dayOrWeekSelect(fnObj);
    }
    if (executeAfter == "backToWeekView") {
        _backToWeekView();
    }
    if (executeAfter == "navigateToPrevious") {
        _navigateToPrevious();
    }
    if (executeAfter == "navigateToNext") {
        _navigateToNext();
    }
    if (executeAfter == "navigateToToday") {
        _navigateToToday();
    }
    if (executeAfter == "navigateToDate") {
        _navigateToDate();
    }
    if (executeAfter == "showSelectEmployeeDialog") {
        setSaveCancelButtons();
        hideProgress();
        _showSelectEmployeeDialog();
    }
    if (executeAfter == "openSettingsDialog") {
        _openSettingsDialog();
    }
    if (executeAfter == "startStopwatchFromRow" && fnObj != undefined) {
        _startStopwatchFromRow(fnObj);
    }
    if (executeAfter == "copyRow" && fnObj != undefined) {
        _copyRow(fnObj);
    }
    if (executeAfter == "exportToExcel") {
        _exportToExcel();
    }
    if (executeAfter == "unSubmitWeekForApproval") {
        _unSubmitWeekForApproval();
    }
    if (executeAfter == "changeSingleDay" && fnObj != undefined && fnObj2 != undefined) {
        _changeSingleDay(fnObj, fnObj2);
    }
    if (executeAfter == "selectSingleDay" && fnObj != undefined) {
        _selectSingleDay(fnObj);
    }
    if (executeAfter == "deleteClick") {
        _deleteClick();
    }
    if (executeAfter == "copyFromOptionsClick") {
        if (hasChanges == true) {
            window.setTimeout(function () {
                refreshTimesheet();
            }, 500);
            checkForSaveFail();
            updateDashboardWeeklyHours();
        }
        _copyFromOptionsClick();
    }
    if (executeAfter == "copyToOptionsClick") {
        if (hasChanges == true) {
            window.setTimeout(function () {
                refreshTimesheet();
            }, 500);
            checkForSaveFail();
            updateDashboardWeeklyHours();
        }
        _copyToOptionsClick();
    }
    if (executeAfter == "openPrintSettingsPage") {
        if (hasChanges == true) {
            window.setTimeout(function () {
                refreshTimesheet();
            }, 500);
            checkForSaveFail();
            updateDashboardWeeklyHours();
        }
        _openPrintSettingsPage();
    }
}
function resetAfterSave() {
    setSaveCancelButtons();
    //unCheckAndClearAllSelectedRows();
    hideProgress();
}
function checkForSaveFail() {
    ////console.log("failed", updatedFailedCount, insertedFailedCount);
    //if (updatedFailedCount > 0 || insertedFailedCount > 0) {
    //    var message = "";
    //    if (updatedFailedCount > 0) {
    //        if (updatedFailedCount == 1) {
    //            message = "One entry did not update.";
    //        } else {
    //            message = updatedFailedCount + " entries did not update.";
    //        }
    //    }
    //    if (insertedFailedCount > 0) {
    //        if (updatedFailedCount > 0) {
    //            message += "\n";
    //        }
    //        if (insertedFailedCount == 1) {
    //            message += "One entry was not added.";
    //        } else {
    //            message += insertedFailedCount + " entries did not add.";
    //        }
    //    }
    //    showNotification(message);
    //    refreshTimesheet();
    //}
}
function saveAll() {

}
function saveFinished() {
    hideProgress();
    refreshTimesheet();
    checkForSaveFail();
}
function enableSaveButton() {
    if ($("#saveButton")) {
        $("#saveButton").removeClass("k-state-disabled");
    }
}
function disableSaveButton() {
    if ($("#saveButton")) {
        $("#saveButton").addClass("k-state-disabled");
    }
}
function enableCancelButton() {
    if ($("#cancelButton")) {
        $("#cancelButton").removeClass("k-state-disabled");
    }
}
function disableCancelButton() {
    if ($("#cancelButton")) {
        $("#cancelButton").addClass("k-state-disabled");
    }
}
// Copy
function refreshCopyFromList() {
    if (currentCopyType == 1) { //  My Projects
        copyProjectsDataSource = null;
        loadCopyFromMyProjects();
    } else if (currentCopyType == 2) { //  Templates
        copyFromMyTimeTemplatesDataSource = null;
        loadCopyFromMyTemplates();
    } else if (currentCopyType == 3) { //  Calendar
        copyFromMyCalendarDataSource = null;
        loadCopyFromMyCalendar();
    } else if (currentCopyType == 4) { //  Recent Assignments
        copyRecentAssignmentsDataSource = null;
        loadCopyFromRecentAssignments();
    } else if (currentCopyType == 5) { //  Recent Jobs
        copyRecentJobsDataSource = null;
        loadCopyFromRecentJobs();
    } else {
        copyProjectsDataSource = null;
        copyRecentAssignmentsDataSource = null;
        copyRecentJobsDataSource = null;
        copyFromMyTimeTemplatesDataSource = null;
        copyFromMyCalendarDataSource = null;
    }
}
function copyFromSelect(sel) {
    var value = sel.value;
    _copyFromSelect(value);
}
function _copyFromSelect(value) {
    $("#copyFromSettingsButton").prop("disabled", true);
    $("#copyFromSettingsButton").prop("title", "No options available.");
    if (value) {
        copyProjectsDataSource = null;
        copyRecentAssignmentsDataSource = null;
        copyRecentJobsDataSource = null;
        copyFromMyTimeTemplatesDataSource = null;
        copyFromMyCalendarDataSource = null;
        if (value == "projects") {
            currentCopyType = 1;
            loadCopyFromMyProjects();
        } else if (value == "templates") {
            currentCopyType = 2;
            $("#copyFromSettingsButton").prop("disabled", false);
            $("#copyFromSettingsButton").prop("title", "Time Template Options");
            loadCopyFromMyTemplates();
        } else if (value == "calendar") {
            currentCopyType = 3;
            $("#copyFromSettingsButton").prop("disabled", false);
            $("#copyFromSettingsButton").prop("title", "Calendar Options");
            loadCopyFromMyCalendar();
        } else if (value == "recent-assignments") {
            currentCopyType = 4;
            loadCopyFromRecentAssignments();
        } else if (value == "recent-jobs") {
            currentCopyType = 5;
            loadCopyFromRecentJobs();
        } else {
            currentCopyType = -1;
            hideCopyPanel();
        }
    } else {
        currentCopyType = -1;
        hideCopyPanel();
    }
    hideAllCopyFromContainers();
}
function showCopyPanel() {
    currentCopyType = 0;
    $("#CopyCell").show();
    $("#copyFromSettingsButton").prop("disabled", true);
}
function hideCopyPanel() {
    currentCopyType = -1;
    copyProjectsDataSource = null;
    copyRecentAssignmentsDataSource = null;
    copyRecentJobsDataSource = null;
    copyFromMyTimeTemplatesDataSource = null;
    copyFromMyCalendarDataSource = null;
    hideAllCopyFromContainers();
    var dropdownlist = $("#copyFrom").data("kendoDropDownList");
    if (dropdownlist) {
        dropdownlist.select(0);
    }
    setTimeout(function () {
        $("#CopyCell").hide();
        $("#copyFromSettingsButton").prop("disabled", true);
    }, 0);
}
function hideAllCopyFromContainers() {
    $("#copyFromMyProjectsContainer").hide();
    $("#copyFromRecentAssignmentsContainer").hide();
    $("#copyFromRecentJobsContainer").hide();
    $("#copyFromMyTimeTemplatesContainer").hide();
    $("#copyFromMyCalendarContainer").hide();
    if (currentCopyType == 1) {
        $("#copyFromMyProjectsContainer").show();
    } else if (currentCopyType == 2) {
        $("#copyFromMyTimeTemplatesContainer").show();
    } else if (currentCopyType == 3) {
        $("#copyFromMyCalendarContainer").show();
    } else if (currentCopyType == 4) {
        $("#copyFromRecentAssignmentsContainer").show();
    } else if (currentCopyType == 5) {
        $("#copyFromRecentJobsContainer").show();
    }
}
function loadCopyFromMyProjects() {
    $("#copyFromPanelHeader").html("Projects");
    if (!copyProjectsDataSource) {
        copyProjectsDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: window.appBase + "Employee/Timesheet/GetMyAssignments?emp=" + employeeCode,
                    dataType: "json"
                }
            }
        });
    }
    $("#copyFromMyProjectsListView").kendoListView({
        dataSource: copyProjectsDataSource,
        dataBound: function (e) {
            if (this.dataSource.data().length == 0) {
                $("#copyFromMyProjectsListView").append("<span>No projects</span>");
            }
        },
        selectable: "single",
        navigatable: true,
        template: kendo.template($("#copyFromMyProjectsItemTemplate").html())
    });
}
function filterCopyFromMyProjectsDataSource(searchInput) {
    try {
        var searchString = $(searchInput).val();
        //console.log("filterCopyFromMyProjectsDataSource", searchString);
        var copyFromMyProjectsListView = $("#copyFromMyProjectsListView").data("kendoListView");
        if (copyFromMyProjectsListView) {
            if (searchString && searchString != "") {
                //console.log("start search");
                var filter = { logic: "or", filters: [] };
                if (isNaN(searchString) == true) {
                    filter.filters.push({ field: "ClientCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ClientName", operator: "contains", value: searchString });
                    filter.filters.push({ field: "DivisionCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ProductCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "FunctionCategory", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobComponentDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "TaskDescription", operator: "contains", value: searchString });
                } else {
                    filter.filters.push({ field: "JobNumber", operator: "eq", value: parseInt(searchString) });
                    filter.filters.push({ field: "JobComponentNumber", operator: "eq", value: parseInt(searchString) });
                }
                if (filter.filters.length > 0) {
                    //console.log("filtering");
                    copyFromMyProjectsListView.dataSource.query({ filter: filter });
                } else {
                    copyFromMyProjectsListView.dataSource.filter({});
                }
            } else {
                copyFromMyProjectsListView.dataSource.filter({});
            }
        }
    } catch (e) {
        //
    }
}
function loadCopyFromRecentAssignments() {
    $("#copyFromPanelHeader").html("My Recent Assignments");
    if (!copyRecentAssignmentsDataSource) {
        copyRecentAssignmentsDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: window.appBase + "Employee/Timesheet/GetMyRecentAssignments",
                    dataType: "json"
                }
            }
        });
    }
    $("#copyFromRecentAssignmentsListView").kendoListView({
        dataSource: copyRecentAssignmentsDataSource,
        dataBound: function (e) {
            if (this.dataSource.data().length == 0) {
                $("#copyFromRecentAssignmentsListView").append("<span>No recent assignments</span>");
            }
        },
        selectable: "single",
        navigatable: true,
        template: kendo.template($("#copyRecentItemTemplate").html())
    });
}
function filterCopyFromRecentAssignmentsDataSource(searchInput) {
    try {
        var searchString = $(searchInput).val();
        //console.log("filterCopyFromRecentAssignmentsDataSource", searchString);
        var copyFromRecentAssignmentsListView = $("#copyFromRecentAssignmentsListView").data("kendoListView");
        if (copyFromRecentAssignmentsListView) {
            if (searchString && searchString != "") {
                //console.log("start search");
                var filter = { logic: "or", filters: [] };
                if (isNaN(searchString) == true) {
                    filter.filters.push({ field: "ClientCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ClientName", operator: "contains", value: searchString });
                    filter.filters.push({ field: "DivisionCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ProductCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobComponentDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "Title", operator: "contains", value: searchString });
                } else {
                    filter.filters.push({ field: "JobNumber", operator: "eq", value: parseInt(searchString) });
                    filter.filters.push({ field: "JobComponentNumber", operator: "eq", value: parseInt(searchString) });
                }
                if (filter.filters.length > 0) {
                    //console.log("filtering");
                    copyFromRecentAssignmentsListView.dataSource.query({ filter: filter });
                } else {
                    copyFromRecentAssignmentsListView.dataSource.filter({});
                }
            } else {
                copyFromRecentAssignmentsListView.dataSource.filter({});
            }
        }
    } catch (e) {
        //
    }
}
function loadCopyFromRecentJobs() {
    $("#copyFromPanelHeader").html("My Recent Jobs");
    if (!copyRecentJobsDataSource) {
        copyRecentJobsDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: window.appBase + "Employee/Timesheet/GetMyRecentJobs",
                    dataType: "json"
                }
            }
        });
    }
    $("#copyFromRecentJobsListView").kendoListView({
        dataSource: copyRecentJobsDataSource,
        dataBound: function (e) {
            if (this.dataSource.data().length == 0) {
                $("#copyFromRecentJobsListView").append("<span>No recent jobs</span>");
            }
        },
        selectable: "single",
        navigatable: true,
        template: kendo.template($("#copyRecentItemTemplate").html())
    });
}
function filterCopyFromRecentJobsDataSource(searchInput) {
    try {
        var searchString = $(searchInput).val();
        //console.log("filterCopyFromRecentJobsDataSource", searchString);
        var copyFromRecentJobsListView = $("#copyFromRecentJobsListView").data("kendoListView");
        if (copyFromRecentJobsListView) {
            if (searchString && searchString != "") {
                //console.log("start search");
                var filter = { logic: "or", filters: [] };
                if (isNaN(searchString) == true) {
                    filter.filters.push({ field: "ClientCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ClientName", operator: "contains", value: searchString });
                    filter.filters.push({ field: "DivisionCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ProductCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobComponentDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "Title", operator: "contains", value: searchString });
                } else {
                    filter.filters.push({ field: "JobNumber", operator: "eq", value: parseInt(searchString) });
                    filter.filters.push({ field: "JobComponentNumber", operator: "eq", value: parseInt(searchString) });
                }
                if (filter.filters.length > 0) {
                    //console.log("filtering");
                    copyFromRecentJobsListView.dataSource.query({ filter: filter });
                } else {
                    copyFromRecentJobsListView.dataSource.filter({});
                }
            } else {
                copyFromRecentJobsListView.dataSource.filter({});
            }
        }
    } catch (e) {
        console.log("Error: ", e);
    }
}
function loadCopyFromMyTemplates() {
    $("#copyFromPanelHeader").html("Time Templates");
    if (!copyFromMyTimeTemplatesDataSource) {
        copyFromMyTimeTemplatesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: window.appBase + "Employee/Timesheet/GetEmployeeTimeTemplates?EmployeeCode=" + employeeCode,
                    dataType: "json"
                }
            }
        });
    }
    $("#copyFromMyTimeTemplatesListView").kendoListView({
        dataSource: copyFromMyTimeTemplatesDataSource,
        dataBound: function (e) {
            if (this.dataSource.data().length == 0) {
                $("#copyFromMyTimeTemplatesListView").append("<span>No template items</span>");
            }
        },
        selectable: "single",
        navigatable: true,
        template: kendo.template($("#copyFromMyTimeTemplatesItemTemplate").html())
    });
}
function filterCopyFromMyTimeTemplatesDataSource(searchInput) {
    try {
        var searchString = $(searchInput).val();
        //console.log("filterCopyFromMyTimeTemplatesDataSource", searchString);
        var copyFromMyTimeTemplatesListView = $("#copyFromMyTimeTemplatesListView").data("kendoListView");
        if (copyFromMyTimeTemplatesListView) {
            if (searchString && searchString != "") {
                //console.log("start search");
                var filter = { logic: "or", filters: [] };
                if (isNaN(searchString) == true) {
                    filter.filters.push({ field: "ClientCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ClientName", operator: "contains", value: searchString });
                    filter.filters.push({ field: "DivisionCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ProductCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "JobComponentDescription", operator: "contains", value: searchString });
                    filter.filters.push({ field: "Title", operator: "contains", value: searchString });
                } else {
                    filter.filters.push({ field: "JobNumber", operator: "eq", value: parseInt(searchString) });
                    filter.filters.push({ field: "JobComponentNumber", operator: "eq", value: parseInt(searchString) });
                }
                if (filter.filters.length > 0) {
                    //console.log("filtering");
                    copyFromMyTimeTemplatesListView.dataSource.query({ filter: filter });
                } else {
                    copyFromMyTimeTemplatesListView.dataSource.filter({});
                }
            } else {
                copyFromMyTimeTemplatesListView.dataSource.filter({});
            }
        }
    } catch (e) {
        console.log("Error: ", e);
    }
}
function loadCopyFromMyCalendar() {
    getDatePickerDate();
    $("#copyFromPanelHeader").html("Calendar");
    var thisUrl = "";
    thisUrl = window.appBase + "Employee/Timesheet/GetEmployeeCalendarItems?EmployeeCode=" + employeeCode + "&StartDate=" + startDate;
    //console.log("loadCopyFromMyCalendar", thisUrl);
    //if (!copyFromMyCalendarDataSource) {
        copyFromMyCalendarDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: thisUrl,
                    dataType: "json"
                }
            }
        });
    //}
    $("#copyFromMyCalendarListView").kendoListView({
        dataSource: copyFromMyCalendarDataSource,
        dataBound: function (e) {
            if (this.dataSource.data().length == 0) {
                $("#copyFromMyCalendarListView").append("<span>No calendar items</span>");
            }
        },
        selectable: "single",
        navigatable: true,
        template: kendo.template($("#copyFromMyCalendarTemplate").html())
    });
}
function filterCopyFromMyCalendarDataSource(searchInput) {
    try {
        var searchString = $(searchInput).val();
        //console.log("filterCopyFromMyCalendarDataSource", searchString);
        var copyFromMyCalendarListView = $("#copyFromMyCalendarListView").data("kendoListView");
        if (copyFromMyCalendarListView) {
            if (searchString && searchString != "") {
                //console.log("start search");
                var filter = { logic: "or", filters: [] };
                if (isNaN(searchString) == true) {
                    filter.filters.push({ field: "ClientCode", operator: "contains", value: searchString });
                    //filter.filters.push({ field: "ClientName", operator: "contains", value: searchString });
                    filter.filters.push({ field: "DivisionCode", operator: "contains", value: searchString });
                    filter.filters.push({ field: "ProductCode", operator: "contains", value: searchString });
                    //filter.filters.push({ field: "JobDescription", operator: "contains", value: searchString });
                    //filter.filters.push({ field: "JobComponentDescription", operator: "contains", value: searchString });
                    //filter.filters.push({ field: "Title", operator: "contains", value: searchString });
                } else {
                    filter.filters.push({ field: "JobNumber", operator: "eq", value: parseInt(searchString) });
                    filter.filters.push({ field: "JobComponentNumber", operator: "eq", value: parseInt(searchString) });
                }
                if (filter.filters.length > 0) {
                    //console.log("filtering");
                    copyFromMyCalendarListView.dataSource.query({ filter: filter });
                } else {
                    copyFromMyCalendarListView.dataSource.filter({});
                }
            } else {
                copyFromMyCalendarListView.dataSource.filter({});
            }
        }
    } catch (e) {
        console.log("Error: ", e);
    }
}
function copyFromSettingsButtonClick() {
    if (currentCopyType == 1) { //  My Projects
    } else if (currentCopyType == 2) { //  Templates
        openTimeTemplateEditDialog();
    } else if (currentCopyType == 3) { //  Calendar
        openCalendarEditDialog();
    } else if (currentCopyType == 4) { //  Recent Assignments
    } else if (currentCopyType == 5) { //  Recent Jobs
    } else {
        //
    }
}
// Draggable
function adjustDropDownWidth(e) {
    var listContainer = e.sender.list.closest(".k-list-container");
    listContainer.width(listContainer.width() + kendo.support.scrollbar());
}
function dropTargetOnDrop(e) {
    window.setTimeout(function () {
        var item;
        if (currentCopyType == 1) { //  My Projects
            if (copyProjectsDataSource) {
                item = copyProjectsDataSource.getByUid(e.draggable.hint.data().uid);
                //console.log("WTF?", currentCopyType, item);
                if (!item || item == undefined) {
                    //console.log("hrrrmmmmm")
                    //console.log(copyProjectsDataSource);
                    //console.log(e.draggable.hint.data().uid);
                    //console.log("data?", copyProjectsDataSource.data());
                    window.setTimeout(function () {
                        //item = copyProjectsDataSource.getByUid(e.draggable.hint.data().uid);
                        var items = copyProjectsDataSource.data();
                        if (items) {
                            for (var i = 0; i < items.length; i++) {
                                //console.log("ITEM?", items[i].uid, e.draggable.hint.data().uid);
                                if (items[i].uid == e.draggable.hint.data().uid) {
                                    item = items[i];
                                    //console.log("found single item?", item);
                                }
                            }
                        }
                    }, 50);
                }
                dropMyProjectsItem(item);
            }
        } else if (currentCopyType == 2) { //  Templates
            if (copyFromMyTimeTemplatesDataSource) {
                item = copyFromMyTimeTemplatesDataSource.getByUid(e.draggable.hint.data().uid);
                if (!item || item == undefined) {
                    window.setTimeout(function () {
                        item = copyFromMyTimeTemplatesDataSource.getByUid(e.draggable.hint.data().uid);
                    }, 10);
                }
                dropMyTimeTemplatesItem(item);
            }
        } else if (currentCopyType == 3) { //  Calendar
            if (copyFromMyCalendarDataSource) {
                item = copyFromMyCalendarDataSource.getByUid(e.draggable.hint.data().uid);
                if (!item || item == undefined) {
                    window.setTimeout(function () {
                        item = copyFromMyCalendarDataSource.getByUid(e.draggable.hint.data().uid);
                    }, 10);
                }
                dropMyCalendarItem(item);
            }
        } else if (currentCopyType == 4) { //  Recent Assignments
            if (copyRecentAssignmentsDataSource) {
                item = copyRecentAssignmentsDataSource.getByUid(e.draggable.hint.data().uid);
                if (!item || item == undefined) {
                    window.setTimeout(function () {
                        item = copyRecentAssignmentsDataSource.getByUid(e.draggable.hint.data().uid);
                    }, 10);
                }
                dropRecentsItem(item);
            }
        } else if (currentCopyType == 5) { //  Recent Jobs
            if (copyRecentJobsDataSource) {
                item = copyRecentJobsDataSource.getByUid(e.draggable.hint.data().uid);
                if (!item || item == undefined) {
                    window.setTimeout(function () {
                        item = copyRecentJobsDataSource.getByUid(e.draggable.hint.data().uid);
                    }, 10);
                }
                dropRecentsItem(item);
            }
        }
        //console.log("dropTargetOnDrop:END", currentCopyType, item);
    }, 10);
}
function dropMyProjectsItem(item) {
    window.setTimeout(function () {
        //console.log("dropMyProjectsItem", item);
        if (item) {
            var dropFunctionCode = "";
            var dropDepartmentCode = "";
            var dropJobNumber = 0;
            var dropJobComponentNumber = 0;
            var dropTaskSequenceNumber = -1;
            var dropAlertId = 0;
            if (item.TaskCode) {
                dropFunctionCode = item.TaskCode;
            }
            if (item.JobNumber) {
                dropJobNumber = item.JobNumber;
            }
            if (item.JobComponentNumber) {
                dropJobComponentNumber = item.JobComponentNumber;
            }
            if (item.TaskSequenceNumber) {
                dropTaskSequenceNumber = item.TaskSequenceNumber;
            }
            if (item.ID) {
                dropAlertId = item.ID;
            }
            //console.log("drop item", item);
            showProgress();
            try {
                var dropItemData = {
                    EmployeeCode: employeeCode,
                    EntryDate: $("#DatePicker")[0].value,
                    Hours: hours,
                    Comment: comment,
                    FunctionOrCategoryCode: dropFunctionCode,
                    DepartmentTeamCode: dropDepartmentCode,
                    JobNumber: dropJobNumber,
                    JobComponentNumber: dropJobComponentNumber,
                    TaskSequenceNumber: dropTaskSequenceNumber,
                    AlertID: dropAlertId
                };
                //console.log("drop insert data", dropItemData);
                $.post({
                    url: window.appBase + "Employee/Timesheet/AddEntryFromCopyFromMyProjects",
                    dataType: "json",
                    data: dropItemData
                }).always(function (result) {
                    hideProgress();
                    if (result) {
                        if (result.Success && result.Success == true) {
                            if (result.Message != "") {
                                if (result.Message.indexOf("NO_CHANGE") > -1) {
                                    showNotification("Job already on timesheet.");
                                } else {
                                    showNotification(result.Message);
                                }
                            } else {
                                showSuccessNotification("Item added!");
                            }
                            //refreshTimesheet();
                        } else {
                            if (result.Message != "") {
                                showNotification(result.Message, "error");
                            }
                        }
                    }
                    if (isViewingSingleDay == true) {
                        loadSingleDayTimesheet();
                    } else {
                        refreshTimesheet();
                    }
                });
            } catch (e) {
                hideProgress();
            }
        }
    }, 10);
}
function dropRecentsItem(item) {
    window.setTimeout(function () {
        if (item) {
            //console.log("dropRecentsItem", item);
            showProgress();
            try {
                var dropAlertId = 0;
                var dropJobNumber = 0;
                var dropJobComponentNumber = 0;
                if (item.AlertID) {
                    dropAlertId = item.AlertID;
                }
                if (item.JobNumber) {
                    dropJobNumber = item.JobNumber;
                }
                if (item.JobComponentNumber) {
                    dropJobComponentNumber = item.JobComponentNumber;
                }
                var dropItemData = {
                    EmployeeCode: employeeCode,
                    EntryDate: $("#DatePicker")[0].value,
                    AlertID: dropAlertId,
                    JobNumber: dropJobNumber,
                    JobComponentNumber: dropJobComponentNumber
                };
                //console.log("dropRecentsItem:data", dropItemData);
                $.post({
                    url: window.appBase + "Employee/Timesheet/AddEntryFromCopyFromMyRecents",
                    dataType: "json",
                    data: dropItemData
                }).always(function (result) {
                    hideProgress();
                    if (result) {
                        if (result.Success && result.Success == true) {
                            if (result.Message != "") {
                                if (result.Message.indexOf("NO_CHANGE") > -1) {
                                    showNotification("Item already on timesheet.");
                                } else {
                                    showNotification(result.Message);
                                }
                            } else {
                                showSuccessNotification("Item added!");
                            }
                            //refreshTimesheet();
                        } else {
                            if (result.Message != "") {
                                showNotification(result.Message, "error");
                            }
                        }
                    }
                    if (isViewingSingleDay == true) {
                        loadSingleDayTimesheet();
                    } else {
                        refreshTimesheet();
                    }
                });
            } catch (e) {
                hideProgress();
            }
        }
    }, 10);
}
function dropMyTimeTemplatesItem(item) {
    window.setTimeout(function () {
        //console.log("dropMyTimeTemplatesItem", item);
        if (item) {
            //console.log("dropMyTimeTemplatesItem", item);
            showProgress();
            try {
                var dropEmployeeTimeTemplateID = 0;
                if (item.EmployeeTimeTemplateID) {
                    dropEmployeeTimeTemplateID = item.EmployeeTimeTemplateID;
                }
                var dropItemData = {
                    EmployeeCode: employeeCode,
                    EntryDate: $("#DatePicker")[0].value,
                    EmployeeTimeTemplateID: dropEmployeeTimeTemplateID
                };
                //console.log("dropMyTimeTemplatesItem:data", dropItemData);
                $.post({
                    url: window.appBase + "Employee/Timesheet/AddEntryFromCopyFromMyTimeTemplates",
                    dataType: "json",
                    data: dropItemData
                }).always(function (result) {
                    hideProgress();
                    if (result) {
                        //console.log("AddEntryFromCopyFromMyTimeTemplates", result);
                        if (result.Data && result.Data.length > 0) {
                            var items = result.Data;
                            for (var i = 0; i < items.length; i++) {
                                if (items[i] && items[i] != "") {
                                    showNotification(items[i], "error");
                                }
                            }
                        } else {
                            if (result.Success && result.Success == true) {
                                if (result.Message != "") {
                                    if (result.Message.indexOf("NO_CHANGE") > -1) {
                                        showNotification("Item already on timesheet.");
                                    } else {
                                        showNotification(result.Message);
                                    }
                                } else {
                                    showSuccessNotification("Item added!");
                                }
                                //refreshTimesheet();
                            } else {
                                if (result.Message != "") {
                                    showNotification(result.Message, "error");
                                }
                            }
                        }
                    }
                    if (isViewingSingleDay == true) {
                        loadSingleDayTimesheet();
                    } else {
                        refreshTimesheet();
                    }
                });
            } catch (e) {
                hideProgress();
            }
        }
    }, 10);
}
function dropMyCalendarItem(item) {
    window.setTimeout(function () {
        if (item) {
            showProgress();
            try {
                var dropEmployeeTimeStagingID = 0;
                var dropFunctionCode = "";
                var dropDepartmentCode = "";
                var dropHours = 0;
                var dropComment = "";
                var dropJobNumber = 0;
                var dropJobComponentNumber = 0;
                var dropTimeType = "";
                if (item.ID && parseInt(item.ID) > 0) {
                    dropEmployeeTimeStagingID = parseInt(item.ID);
                }
                if (item.FunctionCode) {
                    dropFunctionCode = item.FunctionCode;
                }
                if (item.DepartmentCode) {
                    dropDepartmentCode = item.DepartmentCode;
                }
                if (item.Hours && parseFloat(item.Hours) > 0) {
                    dropHours = parseFloat(item.Hours);
                }
                if (item.Comment) {
                    dropComment = item.Comment;
                }
                if (item.JobNumber && parseInt(item.JobNumber) > 0) {
                    dropJobNumber = parseInt(item.JobNumber);
                }
                if (item.JobComponentNumber && parseInt(item.JobComponentNumber) > 0) {
                    dropJobComponentNumber = parseInt(item.JobComponentNumber);
                }
                if (item.TimeType) {
                    dropTimeType = item.TimeType;
                }
                if (dropJobNumber > 0 && dropJobComponentNumber > 0) {
                    dropTimeType = "D";
                } else {
                    dropTimeType = "N";
                }
                var dropItemData = {
                    EmployeeCode: employeeCode,
                    EntryDate: $("#DatePicker")[0].value,
                    EmployeeTimeStagingID: dropEmployeeTimeStagingID,
                    FunctionCode: dropFunctionCode,
                    DepartmentCode: dropDepartmentCode,
                    Hours: dropHours,
                    Comment: dropComment,
                    JobNumber: dropJobNumber,
                    JobComponentNumber: dropJobComponentNumber,
                    TimeType: dropTimeType
                };
                //console.log("dropMyCalendarItem:data", dropItemData);
                $.post({
                    url: window.appBase + "Employee/Timesheet/AddEntryFromCopyFromCalendar",
                    dataType: "json",
                    data: dropItemData
                }).always(function (result) {
                    hideProgress();
                    if (result) {
                        if (result.Success && result.Success == true) {
                            showSuccessNotification("Success!");
                            //if (result.Message != "") {
                            //    if (result.Message.indexOf("NO_CHANGE") > -1) {
                            //        showNotification("Item already on timesheet.");
                            //    } else {
                            //    showSuccessNotification("Item added!");
                            //    }
                            //} else {
                            //    showSuccessNotification("Item added!");
                            //}
                        } else {
                            if (result.Message != "") {
                                showNotification(result.Message, "error");
                            }
                        }
                    }
                    if (isViewingSingleDay == true) {
                        loadSingleDayTimesheet();
                    } else {
                        refreshTimesheet();
                    }
                });
            } catch (e) {
                hideProgress();
            }
        }
    }, 10);
}
// Context menu
function lineContextMenuSelect(e) {
    window.setTimeout(function () {
        var parentRow = $(e.target).parent().parent();
        var rowId = parentRow.attr("id");
        let rowInfo = new RowInfo(rowId);
        currentRowContextRowId = $(parentRow).attr("row-id");
        if (rowInfo) {
            var contextUrl = "";
            if (e.item.id == "details") {
                contextUrl = window.appBase + "Timesheet_Details.aspx?j=" + rowInfo.JobNumber + "&jc=" + rowInfo.JobComponentNumber + "&fn=" + rowInfo.FunctionCode + "&emp=" + employeeCode + "&alertid=" + rowInfo.AlertID;
                $("#detailsDialog").ejDialog("destroy");
                $("#detailsDialog").ejDialog({
                    contentUrl: contextUrl,
                    title: "Details",
                    showOnInit: false,
                    contentType: "iframe",
                    height: "600px",
                    width: "900px",
                    showFooter: false,
                    enableModal: true,
                    backgroundScroll: false,
                    enableResize: true
                });
                $("#detailsDialog").ejDialog("open");
                $("#detailsDialog").ejDialog("refresh");
            } else if (e.item.id == "rowView") {
                showNotification("Not implemented.");
            } else if (e.item.id == "deleteRow") {
                var deleteInfos = [];
                showKendoConfirm("Delete  row?")
                .done(function () {
                    //console.log("parentRow", parentRow);
                    $(parentRow).each(function () {
                        $('td', this).each(function () {
                            var timeInput = $(this).find(":input");
                            if (timeInput.attr("id") != undefined && timeInput.attr("id") != "") {
                                var theID = "";
                                theID = timeInput.attr("id");
                                let entryInfo = new EntryInfo(theID);
                                if (entryInfo && entryInfo.EmployeeTimeID > 0 && entryInfo.EmployeeTimeDetailID > 0) {
                                    if (!entryInfo.TimeType || entryInfo.TimeType == "" || entryInfo.TimeType == undefined) {
                                        if (entryInfo.JobNumber > 0) {
                                            entryInfo.TimeType = "D";
                                        } else {
                                            entryInfo.TimeType = "N";
                                        }
                                    }
                                    var deleteInfo = {
                                        EmployeeTimeID: entryInfo.EmployeeTimeID,
                                        EmployeeTimeDetailID: entryInfo.EmployeeTimeDetailID,
                                        TimeType: entryInfo.TimeType
                                    };
                                    deleteInfos.push(deleteInfo);
                                }
                            }
                        });
                    });
                    if (deleteInfos && deleteInfos.length > 0) {
                        showProgress();
                        saveClick();
                        var deleted = 0;
                        var failed = 0;
                        var counter = 0;
                        for (var i = 0; i < deleteInfos.length; i++) {
                            try {
                                $.post({
                                    url: window.appBase + "Employee/Timesheet/DeleteEntry",
                                    dataType: "json",
                                    data: deleteInfos[i]
                                }).always(function (result) {
                                    if (result) {
                                        if (result.Success == true) {
                                            deleted += 1;
                                        }
                                        if (result.Success == false) {
                                            failed += 1;
                                        }
                                        counter = counter + 1;
                                        if (counter == deleteInfos.length) {
                                            refreshTimesheet();
                                            if (deleted > 0) {
                                                if (failed == 0) {
                                                    showSuccessNotification("Row deleted!");
                                                }
                                                if (failed > 0) {
                                                    showNotification("Some entries successfully deleted.", "warning");
                                                }
                                            }
                                            if (failed > 0) {
                                                showNotification("Some entries could not be deleted.", "error");
                                            }
                                            updateDashboardWeeklyHours();
                                            hideProgress();
                                        }
                                    }
                                }).done(function () {
                                });
                            } catch (e) {
                                //
                            }
                        }
                        // loop done
                        hideProgress();// just in case
                    }
                })
                .fail(function () { });
            } else if (e.item.id == "changeFunction") {
                showSelectFunctionDialog(rowId);
            } else if (e.item.id == "changeAssignment") {
                showChangeAssignmentDialog(rowId);
            } else if (e.item.id == "copyRow") {
                copyRow(rowId);
            } else if (e.item.id == "startStopwatch") {
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
                        if (result.StopwatchIsRunning == true) {
                            showKendoConfirm("There is a stopwatch already running.\nStop it and start a new stopwatch?")
                                .done(function () {
                                    startStopwatchFromRow(rowId);
                                })
                                .fail(function () {
                                    return false;
                                });
                        } else {
                            startStopwatchFromRow(rowId);
                        }
                    }
                });
            }
        }
    }, 10);
}
function lineContextMenuOpen(e) {
    try {
        if (e.item && agencyTimesheetSettings && agencyTimesheetSettings.AllowQvADrilldownInTimesheets == false) {
            $(e.item[0].childNodes[0]).hide();
        }
    } catch (e) {
        console.log("Error: ", e);
    }
}
// Select rows
function hasSelectedRows() {
    var hsr = false;
    if (selectedRows && selectedRows.length > 0) {
        hsr = true;
    } else {
        hsr = false;
    }
    //console.log("hasSelectedRows", hsr);
    return hsr;
}
function rowCheckedChanged(chk) {
    //console.log("rowCheckedChanged jq", $(chk));
    var rowKey = chk.id.replace("checkBox_", "");
    var rowNumber = $(chk).attr("row-id") * 1;
    if (rowKey && rowNumber) {
        var rowInfo = new RowInfo(rowKey);
        var row = {
            ID: rowNumber,
            RowInfo: rowInfo
        }
        //console.log("rowCheckedChanged inputID", row);
        if (chk.checked == true) {
            addSelectedRow(row);
        } else {
            removeSelectedRow(row);
        }
    }
}
function addSelectedRow(row) {
    if (row && row != undefined) {
        removeSelectedRow(row);
        selectedRows.push(row);
        //console.log("Selected row added", row);
    }
    //console.log("addSelectedRow", selectedRows);
    setDeleteButton();
}
function removeSelectedRow(row) {
    if (row && row != undefined) {
        var key = row.ID;
        if (key) {
            if (selectedRows && selectedRows.length > 0) {
                for (var i = selectedRows.length; i--;) {
                    if (selectedRows[i]) {
                        if (selectedRows[i].ID == key) {
                            selectedRows.splice(i, 1);
                            //console.log("Selected row removed", row);
                        }
                    }
                }
            }
        }
    }
    //console.log("removeSelectedRow", selectedRows);
    setDeleteButton();
}
function unCheckAndClearAllSelectedRows() {
    selectedRows = [];
    setDeleteButton();
}
function restoreSelectedRows() {
    if (selectedRows && selectedRows.length > 0) {
        //console.log("restoreSelectedRows", selectedRows);
        var row;
        $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
            if ($(this)[0].id) {
                row = $(this)[0];
                if (row) {
                    var rowId = $(row).attr("row-id") * 1;
                    if (isRowInSelectedList(rowId) == true) {
                        $(row).toggleClass("row-selected");
                    }
                }
            }
        });
    }
}
function isRowInSelectedList(rowId) {
    var yesItIs = false;
    for (var i = selectedRows.length; i--;) {
        if (selectedRows[i]) {
            if (selectedRows[i].ID * 1 == rowId * 1) {
                yesItIs = true;
                break;
            }
        }
    }
    return yesItIs;
}
// Delete selected rows
function setDeleteButton() {
    //console.log("setDeleteButton");
    if (hasSelectedRows() == true) {
        enableDeleteButton();
    } else {
        disableDeleteButton();
    }
}
function enableDeleteButton() {
    if ($("#deleteButton")) {
        $("#deleteButton").removeClass("k-state-disabled");
    }
}
function disableDeleteButton() {
    if ($("#deleteButton")) {
        $("#deleteButton").addClass("k-state-disabled");
    }
}
function deleteClick() {
    saveClick("deleteClick");
}
function _deleteClick() {
    if (hasSelectedRows() == true) {
        var deleteText = "";
        var selectedRowsLength = 0;
        if (selectedRows) {
            selectedRowsLength = selectedRows.length;
        }
        if (selectedRowsLength == 1) {
            deleteText = "Delete selected row?";
        } else if (selectedRowsLength > 1) {
            deleteText = "Delete selected rows?";
        }
        showKendoConfirm(deleteText)
            .done(function () {
                var deleteInfos = [];
                showProgress();
                for (var i = selectedRows.length; i--;) {
                    if (selectedRows[i]) {
                        var row;
                        var cell;
                        $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
                            if ($(this)[0].id && $(this)[0].id == selectedRows[i].RowInfo.key) {
                                row = $(this)[0];
                                if ($(row).attr("row-id") * 1 == selectedRows[i].ID) {
                                    $(row).find("td.input-cell").each(function () {
                                        cell = $(this)[0];
                                        if ($(cell).attr("property") && $(cell).attr("property") != "0|0") {
                                            var hoursTb;
                                            $(cell).find("input.hours-textbox").each(function () {
                                                if (this) {
                                                    hoursTb = this;
                                                    if (hoursTb.id) {
                                                        let entryInfo = new EntryInfo(hoursTb.id);
                                                        if (entryInfo && entryInfo.EmployeeTimeID > 0 && entryInfo.EmployeeTimeDetailID > 0) {
                                                            //console.log("delete entry info", entryInfo);
                                                            if (!entryInfo.TimeType || entryInfo.TimeType == "" || entryInfo.TimeType == undefined) {
                                                                if (entryInfo.JobNumber > 0) {
                                                                    entryInfo.TimeType = "D";
                                                                } else {
                                                                    entryInfo.TimeType = "N";
                                                                }
                                                            }
                                                            var deleteInfo = {
                                                                EmployeeTimeID: entryInfo.EmployeeTimeID,
                                                                EmployeeTimeDetailID: entryInfo.EmployeeTimeDetailID,
                                                                TimeType: entryInfo.TimeType
                                                            };
                                                            deleteInfos.push(deleteInfo);
                                                        }
                                                    }
                                                }
                                            });
                                        }
                                    });
                                }
                            }
                        });
                    }
                }
                //hideProgress();
                // Delete
                if (deleteInfos && deleteInfos.length > 0) {
                    //console.log("before", deleteInfos);
                    deleteAllEntries(deleteInfos);
                } else {
                    hideProgress();
                }
            })
            .fail(function () {
                hideProgress();
           });
    } else {
        showNotification("No rows selected to delete.");
    }
}
function deleteAllEntries(deleteInfosArray) {
    //console.log("deleteAllEntries", deleteInfosArray);
    var data = {
        Deletes: deleteInfosArray
    };
    try {
        showProgress();
        $.post({
            url: window.appBase + "Employee/Timesheet/DeleteEntries",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
                var successes = 0;
                var fails = 0;
                fails = result.Data.Fails * 1;
                if (fails > 0) {
                    if (fails == 1) {
                        showNotification("One entry could not be deleted.", "error");
                    } else if (fails > 1) {
                        showNotification(fails + " entries could not be deleted.", "error");
                    }
                }
            }
            deletes = [];
            hideProgress();
            unCheckAndClearAllSelectedRows();
            refreshTimesheet();
        }).done(function () {
        });
    } catch (e) {
        hideProgress();
    }
}
// Approval
function submitForApproval(token) {
    saveClick("submitForApproval", token);
}
function _submitForApproval(token) {
    var status = $(token).parent().attr("appr-status");
    var approvalDate = $(token).parent().attr("appr-date");
    //console.log("submitForApproval", status, approvalDate);
    var approve;
    if (status == "Submit") {
        approve = true;
    } else if (status == "Pending") {
        approve = false;
    } else if (status == "Denied") {
        approve = false;
    }
    if (approve != undefined && approvalDate) {
        showProgress();
        try {
            var data = {
                EmployeeCode: employeeCode,
                EmployeeDate: approvalDate,
                Approve: approve
            };
            $.post({
                url: window.appBase + "Employee/Timesheet/SubmitForApproval",
                dataType: "json",
                data: data
            }).always(function (result) {
                hideProgress();
                if (result) {
                    if (result.Success == true) {
                        //showSuccessNotification("Approval submitted.");
                        if (approve == true) {
                            notifySupervisorOfApproval();
                        }
                    }
                    if (result.Success == false) {
                        //
                    }
                    if (result.Message && result.Message != "") {
                        showNotification(result.Message);
                    }
                }
                refreshTimesheet();
            });
        } catch (e) {
            hideProgress();
        }
    }
}
function submitWeekForApproval() {
    saveClick("submitWeekForApproval");
}
function _submitWeekForApproval() {
    //console.log("submitWeekForApproval");
    showProgress();
    try {
        var datepicker = $("#DatePicker").data("kendoDatePicker");
        var data = {
            EmployeeCode: employeeCode,
            EmployeeDate: kendo.toString(datepicker.value(), "d")
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/SubmitWeekForApproval",
            dataType: "json",
            data: data
        }).always(function (result) {
            hideProgress();
            refreshTimesheet();
            //console.log("submitWeekForApproval", result);
            if (result) {
                if (result.Success == true) {
                    //refreshTimesheet();
                    notifySupervisorOfApproval();
                }
                if (result.Success == false) {
                    //
                }
                if (result.Message && result.Message != "") {
                    if (result.Message.indexOf("|") == -1) {

                        showNotification(result.Message);

                    } else {

                        var msgs = result.Message.split("|");
                        for (var i = 0; i < msgs.length; i++) {
                            showNotification(msgs[i]);
                        }
                    }
                }
            }
        });
    } catch (e) {
        hideProgress();
    }


}
function unSubmitWeekForApproval() {
    saveClick("unSubmitWeekForApproval");
}
function _unSubmitWeekForApproval() {
    showProgress();
    try {
        var datepicker = $("#DatePicker").data("kendoDatePicker");
        var data = {
            EmployeeCode: employeeCode,
            EmployeeDate: kendo.toString(datepicker.value(), "d")
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/UnSubmitWeekForApproval",
            dataType: "json",
            data: data
        }).always(function (result) {
            hideProgress();
            refreshTimesheet();
            //console.log("unSubmitWeekForApproval", result);
            if (result) {
                if (result.Success == true) {
                    //refreshTimesheet();
                }
                if (result.Success == false) {
                    //
                }
                if (result.Message && result.Message != "") {
                    showNotification(result.Message);
                }
            }
        });
    } catch (e) {
        hideProgress();
    }
}
function viewApprovalComments(token) {
    var approvalDate = $(token).parent().attr("appr-date");
    $.get({
        url: window.appBase + "Employee/Timesheet/HasApprovalComment?emp=" + employeeCode + "&sd=" + approvalDate,
        dataType: "json"
    }).always(function (result) {
        if (result != undefined) {
            if (result == true) {
                $.get({
                    url: window.appBase + "Employee/Timesheet/GetApprovalComment?emp=" + employeeCode + "&sd=" + approvalDate,
                    dataType: "json"
                }).always(function (result) {
                    if (result && result != "") {
                        $("#approvalCommentDialog").html(result.replace(/\r?\n/g, '<br />'));
                        $("#approvalCommentDialog").ejDialog({
                            title: "Approval Comment",
                            closeOnEscape: true,
                            showOnInit: false,
                            height: "200px",
                            width: "400px",
                            showFooter: false,
                            enableModal: true,
                            backgroundScroll: false,
                            enableResize: false
                        });
                        $("#approvalCommentDialog").ejDialog("open");
                    } else {
                        $("#approvalCommentDialog").html("");
                        showNotification("No supervisor approval comment.");
                    }
                });
            } else {
                showNotification("No supervisor approval comment.")
            }
        }
    });
}
function showApprovalRow() {
    try {
        if ($("#approvalRow")) {
            $("#approvalRow").show();
        }
    } catch (e) {
        //
    }
}
function hideApprovalRow() {
    try {
        if ($("#approvalRow")) {
            $("#approvalRow").hide();
        }
    } catch (e) {
        //
    }
}
function isApprovalActive() {
    var data = {
        EmployeeCode: employeeCode
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/IsApprovalActive",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result && result == true) {
            showApprovalRow();
        } else {
            hideApprovalRow();
        }
    });
}
function notifySupervisorOfApproval() {
    var data = {
        EmployeeCode: employeeCode
    };
    $.post({
        url: window.appBase + "Employee/Timesheet/NotifySupervisorOfApproval",
        dataType: "json",
        data: data
    }).always(function (result) {
    });
}
// Helpers 
function isUserLimited() {
    $.get({
        url: window.appBase + "Employee/Timesheet/UserLimited",
        dataType: "json",
        data: null
    }).always(function (result) {
        if (result == false) {
            hookupEmployeeSelector(true);
        } else {
            hookupEmployeeSelector(false);
        }
    });
}
function showProgress() {
    //kendo.ui.progress($("#kanBanControl"), true);
    if (progressShowing == false) {
        //console.log("showProgress!")
        kendo.ui.progress($("body"), true);
        progressShowing = true;
    }
}
function hideProgress() {
    //kendo.ui.progress($("#kanBanControl"), false);
    if (progressShowing == true) {
        window.setTimeout(function () {
            //console.log("hideProgress!")
            kendo.ui.progress($("body"), false);
            progressShowing = false;
        }, 750);
    }
}
function goOld() {
    var url = window.appBase + "Timesheet.aspx";
    window.location = url;
}
function setDateLabelOrPicker() {
    if (isViewingSingleDay == false) {
        //console.log("setting date label", isViewingSingleDay);
        $("#DatePickerContainer").show();
        $("#WeekOfLabel").hide();
    } else {
        //console.log("setting date label", isViewingSingleDay);
        $("#DatePickerContainer").hide();
        $("#WeekOfLabel").show();
        $("#WeekOfLabel").text(startOfWeekDate);
    }
}
function searchTimesheet(tb) {
    var value = $(tb).val().toLowerCase();
    //$("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
    //    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
    //});
    filterTimesheet(value);
}
function filterTimesheet(searchString) {
    userSearchString = searchString;
    $("#employeeTimeTable tbody>tr.border_bottom").filter(function () {
        $(this).toggle($(this).text().toLowerCase().indexOf(searchString) > -1);
    });
}
function hookupEmployeeSelector(doIt) {
    if (doIt == true) {
        $("#employee-selector").click(function () {
            showSelectEmployeeDialog();
        });
        $("#employee-selector").css("cursor", "pointer");
        $("#selectEmployee").show();
        $("#employee-selector").show();
    } else {
        $("#employee-selector").click(function () {
            return false;
        });
        $("#employee-selector").css("cursor", "default");
        $("#selectEmployee").hide();
        $("#employee-selector").hide();
    }
}
// Init
function initTimesheetPartialView(reInitDate) {
    if (reInitDate == true) {
        startDateString = $("#dateValue").text();
        if (startDateString) {
            startDate = kendo.parseDate(startDateString);
            if (startDate) {
                $("#DatePicker").data("kendoDatePicker").value(startDate);
            }
        }
        setDateLabelOrPicker();
    }
    //console.log("currentCopyType", currentCopyType);
    if (currentCopyType && currentCopyType > 0) {
        var currCopyValue = "";
        if (currentCopyType == 1) {
            currCopyValue = "projects";
        } else if (currentCopyType == 2) {
            currCopyValue = "templates";
        } else if (currentCopyType == 3) {
            currCopyValue = "calendar";
        } else if (currentCopyType == 4) {
            currCopyValue = "recent-assignments";
        } else if (currentCopyType == 5) {
            currCopyValue = "recent-jobs";
        }
        $("#copyFrom").val(currCopyValue);
        _copyFromSelect(currCopyValue);
        //showCopyPanel();
    } else {
        //hideCopyPanel();
    }
    $("#copyFrom").kendoDropDownList({ open: adjustDropDownWidth });
    initSortDropDownList();
    initGroupDropDownList();
    getUserSort();
    var kendoDraggableOptions = {
        filter: ">div.copy-item",
        cursor: "move",
        hint: function (element) {
            return element.clone().css({ "opacity": 1, "background-color": "#449D44", "border": "1px solid #398439", "color": "#FFF" });
        }
    }
    $("#copyFromMyProjectsListView").kendoDraggable(kendoDraggableOptions);
    $("#copyFromRecentAssignmentsListView").kendoDraggable(kendoDraggableOptions);
    $("#copyFromRecentJobsListView").kendoDraggable(kendoDraggableOptions);
    $("#copyFromMyTimeTemplatesListView").kendoDraggable(kendoDraggableOptions);
    $("#copyFromMyCalendarListView").kendoDraggable(kendoDraggableOptions);
    var draggableOptionsCursorOffset = { top: 10, left: 10 };
    var draggable = $("#copyFromMyProjectsListView").data("kendoDraggable");
    draggable.options.cursorOffset = draggableOptionsCursorOffset;
    draggable = $("#copyFromRecentAssignmentsListView").data("kendoDraggable");
    draggable.options.cursorOffset = draggableOptionsCursorOffset;
    draggable = $("#copyFromRecentJobsListView").data("kendoDraggable");
    draggable.options.cursorOffset = draggableOptionsCursorOffset;
    draggable = $("#copyFromMyTimeTemplatesListView").data("kendoDraggable");
    draggable.options.cursorOffset = draggableOptionsCursorOffset;
    draggable = $("#copyFromMyCalendarListView").data("kendoDraggable");
    draggable.options.cursorOffset = draggableOptionsCursorOffset;

    $("#employeeTimeTable").kendoDropTarget({
        drop: dropTargetOnDrop
    });
    isUserLimited();
    //isApprovalActive();
    window.setTimeout(function () {
        initTooltips();
    }, 500);
}

// Classes
class AgencyTimesheetSettings {
    constructor() {
        this.UseBatchMethodToPostEmployeeTime = false;
        this.UseCopyTimesheetFeature = false;
        this.AllowCopyOfTimesheetHours = false;
        this.CheckForClosedPostingPeriods = false;
        this.RequireTimeComments = false;
        this.AllowQvADrilldownInTimesheets = false;
        this.SupervisorApprovalActive = false;
        this.SupervisorCanEditOthersTimeWithinApprovals = false;
        this.AutoAlertSupervisor = false;
        this.DefaultDisplayDays = 7;
        this.AddUniqueRowWhenCommentsAreIncluded = false;
        this.RequireAssignment = false;
        this.WeeklyTimeType = 0;
    }
}
class RowInfo {
    constructor(key) {
        this.ClientCode = "";
        this.DivisionCode = "";
        this.ProductCode = "";
        this.JobNumber = 0;
        this.JobComponentNumber = 0;
        this.FunctionCode = null;
        this.DepartmentTeamCode = "";
        this.JobProcessControl = 0;
        this.AlertID = 0;
        this.key = key;
        if (this.key) {
            var itm = this.key.split("|");
            if (itm) {
                try { this.ClientCode = itm[0]; } catch (e) { this.ClientCode = ""; }
                try { this.DivisionCode = itm[1]; } catch (e) { this.DivisionCode = ""; }
                try { this.ProductCode = itm[2]; } catch (e) { this.ProductCode = ""; }
                try { this.JobNumber = itm[3]; } catch (e) { this.JobNumber = 0; }
                try { this.JobComponentNumber = itm[4]; } catch (e) { this.JobComponentNumber = 0; }
                try { this.FunctionCode = itm[5]; } catch (e) { this.FunctionCode = null; }
                try { this.DepartmentTeamCode = itm[6]; } catch (e) { this.DepartmentTeamCode = ""; }
                try { this.JobProcessControl = itm[7]; } catch (e) { this.JobProcessControl = 0; }
                try { this.AlertID = itm[8]; } catch (e) { this.AlertID = 0; }
            }
        }
    }
}
class EntryInfo {
    constructor(key) {
        this.key = key;
        if (this.key) {
            var itm = this.key.split("|");
            this.EmployeeCode = itm[0];
            this.FunctionCategoryCode = itm[1];
            this.DepartmentTeamCode = itm[2];
            if (itm[3]) {
                this.JobNumber = itm[3] * 1;
            } else {
                this.JobNumber = 0;
            }
            if (itm[4]) {
                this.JobComponentNumber = itm[4] * 1;
            } else {
                this.JobComponentNumber = 0;
            }
            if (itm[5]) {
                this.EmployeeTimeID = itm[5] * 1;
            } else {
                this.EmployeeTimeID = 0;
            }
            if (itm[6]) {
                this.EmployeeTimeDetailID = itm[6] * 1;
            } else {
                this.EmployeeTimeDetailID = 0;
            }
            if (itm[7]) {
                this.EditFlag = itm[7] * 1;
            } else {
                this.EditFlag = 0;
            }
            this.TimeType = itm[8];
            if (itm[9]) {
                this.EntryDate = itm[9];
            } else {
                this.EntryDate = null;
            }
            if (itm[10]) {
                if (itm[10].toLowerCase() == "true" || itm[10] == true) {
                    this.CommentsRequired = true;
                } else {
                    this.CommentsRequired = false;
                }
            } else {
                this.CommentsRequired = false;
            }
            if (itm[11]) {
                if (itm[11].toLowerCase() == "true" || itm[11] == true) {
                    this.HasComments = true;
                } else {
                    this.HasComments = false;
                }
            } else {
                this.HasComments = false;
            }
            if (itm[12]) {
                this.Hours = itm[12] * 1;
            } else {
                this.Hours = 0;
            }
            if (itm[13]) {
                this.AlertID = itm[13] * 1;
            } else {
                this.AlertID = 0;
            }
        } else {
            this.EmployeeCode = "";
            this.FunctionCategoryCode = "";
            this.DepartmentTeamCode = "";
            this.JobNumber = 0;
            this.JobComponentNumber = 0;
            this.EmployeeTimeID = 0;
            this.EmployeeTimeDetailID = 0;
            this.EntryDate = null;
            this.TimeType = "D";
            this.EditFlag = "";
            this.CommentsRequired = false;
            this.HasComments = false;
            this.Hours = 0;
            this.AlertID = 0;
        }
        this.Comment = "";
        this.RowNumber = -1;
    }
}
// Expand/Collapse
function clearExpandedRows() {
    //console.log("clearExpandedRows:before", expandedRows);
    expandedRows = [];
    //console.log("clearExpandedRows:after", expandedRows);
}
function expandCollapseRow(row) {
    var thisRow = $(row)[0];
    //console.log("expandCollapseRow:before", expandedRows);
    $(row).nextUntil('tr.group_row').slideToggle(0, function () {
    });
    //console.log("expandCollapseRow:collapsed?", $(thisRow).data("is-collapsed"));
    $(thisRow).data("is-collapsed", !$(thisRow).data("is-collapsed"));
    //console.log("expandCollapseRow:collapsed?", $(thisRow).data("is-collapsed"));
    //console.log("expandCollapseRow:after", expandedRows);
    trackCollapsedRows(row.id);
}
function trackCollapsedRows(rowId) {
    if (expandedRows) {
        var removed = false;
        for (var i = expandedRows.length; i--;) {
            if (expandedRows[i]) {
                if (expandedRows[i] == rowId) {
                    expandedRows.splice(i, 1);
                    removed = true;
                }
            }
        }
        if (removed == false) {
            expandedRows.push(rowId);
        }
    }
    if (expandedRows && expandedRows.length > 0) {
        hasCollapsedRows = true;
    } else {
        hasCollapsedRows = false;
    }
    //console.log("trackCollapsedRows", expandedRows);
}
function isCollapsed(rowId) {
    var yesItIs = false;
    for (var i = expandedRows.length; i--;) {
        if (expandedRows[i]) {
            if (expandedRows[i] == rowId) {
                yesItIs = true;
                break;
            }
        }
    }
    return yesItIs;
}
function restoreCollapsedRows() {
    if (expandedRows && expandedRows.length > 0) {
        $("#employeeTimeTable tbody>tr.group_row").filter(function () {
            var thisRow;
            var thisRowId = "";
            var isThisCollapsed = false;
            thisRow = $(this)[0];
            thisRowId = $(this)[0].id;
            isThisCollapsed = $(thisRow).data("is-collapsed");
            if (thisRowId) {
                if (isCollapsed(thisRowId) == true) {
                    expandCollapseRow(thisRow);
                }
            }
        });
    }
    //console.log("restoreCollapsedRows", expandedRows);
}
function detailRowClick(row) {
    $(row).toggleClass("row-selected");
    var selected = $(row).hasClass("row-selected");
    var rowKey = row.id;
    var rowNumber = $(row).attr("row-id") * 1;
    if (rowKey && rowNumber) {
        var rowInfo = new RowInfo(rowKey);
        var thisRow = {
            ID: rowNumber,
            RowInfo: rowInfo
        };
        if (selected == true) {
            addSelectedRow(thisRow);
        } else {
            removeSelectedRow(thisRow);
        }
    }
    setDeleteButton();
}
function descriptionColumnClick(cell) {
    detailRowClick($(cell).parent()[0]);
}
function expandCollapseAll() {
    if (isAllCollapsed == true) {
        expandAllHeaders();
    } else {
        collapseAllHeaders();
    }
}
function expandAllHeaders() {
    window.setTimeout(function () {
        $("#employeeTimeTable tbody>tr.group_row").filter(function () {
            var thisRow;
            var thisRowId = "";
            var isThisCollapsed = false;
            thisRow = $(this)[0];
            thisRowId = $(this)[0].id;
            isThisCollapsed = $(thisRow).data("is-collapsed");
            if (thisRowId) {
                if (isCollapsed(thisRowId) == true || isThisCollapsed == true) {
                    expandCollapseRow(thisRow);
                }
                //console.log("expandAllHeaders:is-collapsed?", isThisCollapsed);
            }
        });
        $("#expandCollapseAllDiv").prop("title", "Expand all");
        $("#expandCollapseSpan").toggleClass("rotate-180");
        isAllCollapsed = true;
        //console.log("expandAllHeaders", expandedRows);
    }, 200);
}
function collapseAllHeaders() {
    window.setTimeout(function () {
        $("#employeeTimeTable tbody>tr.group_row").filter(function () {
            var thisRow;
            var thisRowId = "";
            var isThisCollapsed = false;
            thisRow = $(this)[0];
            thisRowId = $(this)[0].id;
            isThisCollapsed = $(thisRow).data("is-collapsed");
            if (thisRowId) {
                if (isCollapsed(thisRowId) == false || isThisCollapsed == false) {
                    expandCollapseRow(thisRow);
                }
                //console.log("collapseAllHeaders:is-collapsed?", isThisCollapsed);
            }
        });
        $("#expandCollapseAllDiv").prop("title", "Expand all");
        $("#expandCollapseSpan").toggleClass("rotate-180");
        isAllCollapsed = true;
        //console.log("collapseAllHeaders", expandedRows);
    }, 200);
}
function getRowNumber(row) {
    try {
        return $(row).attr("row-id") * 1;
    } catch (e) {
        return -1;
    }
}
//  Tooltip comment
function tooltipShow(e) {
    var data = {
        etid: e.sender.target().first().data("etid"),
        etdid: e.sender.target().first().data("etdid"),
        tt: e.sender.target().first().data("tt")
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/GetTimeEntryCommentText",
        dataType: "json",
        data: data
    }).always(function (response) {
        if (response) {
            $("#commentSpan").html(response.responseText);
        }
    });
}
function initTooltips() {
    //console.log("initTooltips");
    //var commentTooltip = $("#employeeTimeTable").kendoTooltip({
    //    filter: "div.comment-tooltip-container",
    //    content: kendo.template($("#commentTemplate").html()),
    //    position: "right",
    //    requestStart: function (e) {
    //        e.options.url = kendo.format(getCommentUrl, e.target.data("etid"), e.target.data("etdid"), e.target.data("tt"));
    //    },
    //    contentLoad: function (e) {
    //    },
    //    autoHide: false,
    //    show: tooltipShow
    //}).data("kendoTooltip");
}
//  Progress Bar
function progressTooltip(progressIsShowingTrafficHours, quotedHours, actualHours, threshold, isOverThreshold) {
    var toolTip = "";
    var quotedOrTraffic = "";
    var remainingText = "";
    var hoursRemaining = 0;
    var progress = 0;
    var thresholdHours = 0;
    hoursRemaining = quotedHours - actualHours;
    if (quotedHours && isNaN(quotedHours) == false && quotedHours != 0) {
        progress = (actualHours / quotedHours) * 100;
        if (progressIsShowingTrafficHours == true) {
            quotedOrTraffic = "traffic";
        } else {
            quotedOrTraffic = "quoted";
        }
        if (hoursRemaining) {
            if (hoursRemaining > 0) {
                remainingText = "remaining:  " + kendo.toString(hoursRemaining, "N2") + " hours";
            } else if (hoursRemaining < 0) {
                remainingText = "over by:  " + kendo.toString(hoursRemaining, "N2") + " hours";
            }
        }
        toolTip = kendo.toString(actualHours, "N2") + " posted hours of " + kendo.toString(quotedHours, "N2") + " " + quotedOrTraffic + " hours, " + remainingText;
        if (threshold && threshold > 0) {
            thresholdHours = quotedHours * (threshold * 0.01);
            toolTip = tooltip + ", threshold:  " + kendo.toString(thresholdHours, "N2") + " hours (" + kendo.toString(thresholdHours, "N2") + "%)";
        }
    } else {
        toolTip = kendo.toString(actualHours, "N2") + " posted hours";
    }
}



////  Keyboard shortcuts
//$(document).bind('keydown', 'Ctrl+return', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+s', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+t', function () { copyToOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+f', function () { copyFromOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+w', function () {
//    selectWeek();
//});
//$(document).bind('keydown', 'Ctrl+d', function () {
//    var data = {
//        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
//    };
//    $.get({
//        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
//        dataType: "json",
//        data: data
//    }).always(function (result) {
//        if (result == true) {
//            var d = new Date();
//            selectSingleDay(kendo.toString(d, "d"));
//        } else {
//            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
//        }
//    });
//});
//$(document).bind('keydown', 'Ctrl+right', function () { navigateToNext(); });
//$(document).bind('keydown', 'Ctrl+left', function () { navigateToPrevious(); });
//$(document).bind('keydown', 'Ctrl+up', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+down', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+r', function () { refreshTimesheet(); });
//$(document).bind('keydown', 'Ctrl+b', function () { bookmark(); });
//$(document).bind('keydown', 'Ctrl+p', function () { openPrintSettingsPage(); });
//$(document).bind('keydown', 'Ctrl+e', function () { settingsClick(); });
//$(document).bind('keydown', 'Ctrl+n', function () { openNewEntryDialog(); });

$(document).bind('keydown', 'shift+return', function () { saveClick(); });
$(document).bind('keydown', 'shift+s', function () { saveClick(); });
$(document).bind('keydown', 'shift+t', function () { copyToOptionsClick(); });
$(document).bind('keydown', 'shift+f', function () { copyFromOptionsClick(); });
$(document).bind('keydown', 'shift+w', function () {
    selectWeek();
});
$(document).bind('keydown', 'shift+d', function () {
    var data = {
        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result == true) {
            var d = new Date();
            selectSingleDay(kendo.toString(d, "d"));
        } else {
            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
        }
    });
});
$(document).bind('keydown', 'shift+right', function () { navigateToNext(); });
$(document).bind('keydown', 'shift+left', function () { navigateToPrevious(); });
$(document).bind('keydown', 'shift+up', function () { navigateToToday(); });
$(document).bind('keydown', 'shift+down', function () { navigateToToday(); });
$(document).bind('keydown', 'shift+r', function () { refreshTimesheet(); });
$(document).bind('keydown', 'shift+b', function () { bookmark(); });
$(document).bind('keydown', 'shift+p', function () { openPrintSettingsPage(); });
$(document).bind('keydown', 'shift+e', function () { settingsClick(); });
$(document).bind('keydown', 'shift+n', function () { openNewEntryDialog(); });

$(document).bind('keydown', 'alt+shift+return', function () { saveClick(); });
$(document).bind('keydown', 'alt+shift+s', function () { saveClick(); });
$(document).bind('keydown', 'alt+shift+t', function () { copyToOptionsClick(); });
$(document).bind('keydown', 'alt+shift+f', function () { copyFromOptionsClick(); });
$(document).bind('keydown', 'alt+shift+w', function () {
    selectWeek();
});
$(document).bind('keydown', 'alt+shift+d', function () {
    var data = {
        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
    };
    $.get({
        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
        dataType: "json",
        data: data
    }).always(function (result) {
        if (result == true) {
            var d = new Date();
            selectSingleDay(kendo.toString(d, "d"));
        } else {
            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
        }
    });
});
$(document).bind('keydown', 'alt+shift+right', function () { navigateToNext(); });
$(document).bind('keydown', 'alt+shift+left', function () { navigateToPrevious(); });
$(document).bind('keydown', 'alt+shift+up', function () { navigateToToday(); });
$(document).bind('keydown', 'alt+shift+down', function () { navigateToToday(); });
$(document).bind('keydown', 'alt+shift+r', function () { refreshTimesheet(); });
$(document).bind('keydown', 'alt+shift+b', function () { bookmark(); });
$(document).bind('keydown', 'alt+shift+p', function () { openPrintSettingsPage(); });
$(document).bind('keydown', 'alt+shift+e', function () { settingsClick(); });
$(document).bind('keydown', 'alt+shift+n', function () { openNewEntryDialog(); });


//$(document).bind('keydown', 'alt+return', function () { saveClick(); });
//$(document).bind('keydown', 'alt+s', function () { saveClick(); });
//$(document).bind('keydown', 'alt+t', function () { copyToOptionsClick(); });
//$(document).bind('keydown', 'alt+f', function () { copyFromOptionsClick(); });
//$(document).bind('keydown', 'alt+w', function () {
//    selectWeek();
//});
//$(document).bind('keydown', 'alt+d', function () {
//    var data = {
//        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
//    };
//    $.get({
//        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
//        dataType: "json",
//        data: data
//    }).always(function (result) {
//        if (result == true) {
//            var d = new Date();
//            selectSingleDay(kendo.toString(d, "d"));
//        } else {
//            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
//        }
//    });
//});
//$(document).bind('keydown', 'alt+right', function () { navigateToNext(); });
//$(document).bind('keydown', 'alt+left', function () { navigateToPrevious(); });
//$(document).bind('keydown', 'alt+up', function () { navigateToToday(); });
//$(document).bind('keydown', 'alt+down', function () { navigateToToday(); });
//$(document).bind('keydown', 'alt+r', function () { refreshTimesheet(); });
//$(document).bind('keydown', 'alt+b', function () { bookmark(); });
//$(document).bind('keydown', 'alt+p', function () { openPrintSettingsPage(); });
//$(document).bind('keydown', 'alt+e', function () { settingsClick(); });
//$(document).bind('keydown', 'alt+n', function () { openNewEntryDialog(); });

//$(document).bind('keydown', 'Ctrl+Shift+return', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+Shift+s', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+Shift+t', function () { copyToOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+Shift+f', function () { copyFromOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+Shift+w', function () {
//    selectWeek();
//});
//$(document).bind('keydown', 'Ctrl+Shift+d', function () {
//    var data = {
//        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
//    };
//    $.get({
//        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
//        dataType: "json",
//        data: data
//    }).always(function (result) {
//        if (result == true) {
//            var d = new Date();
//            selectSingleDay(kendo.toString(d, "d"));
//        } else {
//            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
//        }
//    });
//});
//$(document).bind('keydown', 'Ctrl+Shift+right', function () { navigateToNext(); });
//$(document).bind('keydown', 'Ctrl+Shift+left', function () { navigateToPrevious(); });
//$(document).bind('keydown', 'Ctrl+Shift+up', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+Shift+down', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+Shift+r', function () { refreshTimesheet(); });
//$(document).bind('keydown', 'Ctrl+Shift+b', function () { bookmark(); });
//$(document).bind('keydown', 'Ctrl+Shift+p', function () { openPrintSettingsPage(); });
//$(document).bind('keydown', 'Ctrl+Shift+e', function () { settingsClick(); });
//$(document).bind('keydown', 'Ctrl+Shift+n', function () { openNewEntryDialog(); });

//$(document).bind('keydown', 'Ctrl+alt+return', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+alt+s', function () { saveClick(); });
//$(document).bind('keydown', 'Ctrl+alt+t', function () { copyToOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+alt+f', function () { copyFromOptionsClick(); });
//$(document).bind('keydown', 'Ctrl+alt+w', function () {
//    selectWeek();
//});
//$(document).bind('keydown', 'Ctrl+alt+d', function () {
//    var data = {
//        StartDate: kendo.toString($("#DatePicker")[0].value, "d")
//    };
//    $.get({
//        url: window.appBase + "Employee/Timesheet/IsCurrentWeek",
//        dataType: "json",
//        data: data
//    }).always(function (result) {
//        if (result == true) {
//            var d = new Date();
//            selectSingleDay(kendo.toString(d, "d"));
//        } else {
//            selectSingleDay(kendo.toString($("#DatePicker")[0].value, "d"));
//        }
//    });
//});
//$(document).bind('keydown', 'Ctrl+alt+right', function () { navigateToNext(); });
//$(document).bind('keydown', 'Ctrl+alt+left', function () { navigateToPrevious(); });
//$(document).bind('keydown', 'Ctrl+alt+up', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+alt+down', function () { navigateToToday(); });
//$(document).bind('keydown', 'Ctrl+alt+r', function () { refreshTimesheet(); });
//$(document).bind('keydown', 'Ctrl+alt+b', function () { bookmark(); });
//$(document).bind('keydown', 'Ctrl+alt+p', function () { openPrintSettingsPage(); });
//$(document).bind('keydown', 'Ctrl+alt+e', function () { settingsClick(); });
//$(document).bind('keydown', 'Ctrl+alt+n', function () { openNewEntryDialog(); });
