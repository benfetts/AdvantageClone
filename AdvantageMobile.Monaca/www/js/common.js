/* Global Functions */
/*
    try {
    } 
    catch (ex) {
    }
    finally {
    }

*/
var networkErrorShown = false;

function handleDataServiceError(error) {
    var msg = '';
    try {
        msg = "Error: " + error.message + " " + (error.stacktrace || "");
    } catch (e) {
        msg = "Error: " + e.message + " " + (e.stacktrace || "");
    } finally {
        if (msg && msg != '') {
            if (msg.indexOf("Unspecified network error") > 0) {
                try {
                    if (networkErrorShown == false) {
                        DevExpress.ui.dialog.alert("Please verify URL");
                        networkErrorShown = true;
                        AdvantageMobile_UI.app.navigate('sign_in');
                    };
                } catch (e) { };
            };
        } else {
            console.log(msg);
        };
    };
};
function localizeString(key) {
    //try {
    //    var dictionary = Globalize.cultures[staticCulture].messages;
    //    return dictionary[key.substring(1)];
    //} catch (e) {
    //    return key.substring(1);
    //};
    return key
};
function booleanToYesNo(booleanValue) {
    if (booleanValue == true) {
        return "Yes";
    } else {
        return "No";
    }
};

////var alertPriorities = [
////        { id: 1, alphaCode: 'HH', name: localizeString('Highest') },
////        { id: 2, alphaCode: 'H', name: localizeString('High') },
////        { id: 3, alphaCode: '--', name: '--' },
////        { id: 4, alphaCode: 'L', name: localizeString('Low') },
////        { id: 5, alphaCode: 'LL', name: localizeString('Lowest') },
////];
function setPriority(priority) {
    if (!priority) {
        return '--';  
    } else {
        var str = '--';
        switch (priority.toUpperCase()) {
            case 'A':
                str = "Active"
                break;
            case 'P':
                str = "Projected"
                break;
            case 'H':
                str = "High"
                break;
            case 'L':
                str = "Low"
                break;
            case 'HH':
                str = "Highest"
                break;
            case 'LL':
                str = "Lowest"
                break;
            default:
                str = '--'; 
                break;
        }
        return str;
    }
};
function setAlertPriorityText(priority) {
    if (!priority || priority == undefined || priority == null || isNaN(priority) == true) {
        return '--';  
    } else {
        var str = ''; 
        switch (priority) {
            case 1:
                str = 'HH';
                break;
            case 2:
                str = 'H';
                break;
            case 3:
                str = '';
                break;
            case 4:
                str = 'L';
                break;
            case 5:
                str = 'LL';
                break;
            default:
                str = ''; 
                break;
        }
        return str;
    }
};
function setAlertPriorityCSS(priority) {
    if (!priority || priority == undefined || priority == null || isNaN(priority) == true) {
        return 'alert-priority-normal';
    } else {
        var str = 'alert-priority-normal';
        switch (priority) {
            case 1:
                str = 'alert-priority-highest';
                break;
            case 2:
                str = 'alert-priority-high';
                break;
            case 3:
                str = 'alert-priority-normal';
                break;
            case 4:
                str = 'alert-priority-low';
                break;
            case 5:
                str = 'alert-priority-lowest';
                break;
            default:
                str = 'alert-priority-normal';
                break;
        }
        return str;
    }
};

function setTaskPriorityIndicatorCSS(priority) {
    if (!priority) {
        return 'card-indicator task-priority-pending';
    } else {
        var str = 'card-indicator task-priority-pending';
        switch (priority.toUpperCase()) {
            case 'A':
                str = 'card-indicator task-priority-active';
                break;
            case 'P':
                str = 'card-indicator task-priority-pending';
                break;
            case 'H':
                str = 'card-indicator alert-priority-high';
                break;
            case 'L':
                str = 'card-indicator alert-priority-low';
                break;
            default:
                str = 'card-indicator task-priority-pending';
                break;
        }
        return str;
    }
};
function setDueDateColorCSS(dueDate) {
    var today = new Date();
    if (dueDate < today) {
        return "task-due-overdue";
    };
};

function setScheduleIndicatorCSS(CalenderItemType) {
    if (!CalenderItemType) {
        return 'card-indicator';
    } else {
        var str = '--';
        switch (CalenderItemType.toUpperCase()) {
            case 'A':
                str = 'card-indicator calendar-activity';
                break;
            case 'C':
                str = 'card-indicator calendar-activity';
                break;
            case 'E':
                str = 'card-indicator calendar-event';
                break;
            case 'ET':
                str = 'card-indicator calendar-event-task';
                break;
            case 'H':
                str = 'card-indicator calendar-holiday';
                break;
            case 'M':
                str = 'card-indicator calendar-activity';
                break;
            case 'T':
                str = 'card-indicator calendar-task';
                break;
            default:
                str = 'card-indicator';
                break;
        }
        return str;
    }
};
function setScheduleDateDisplay(CalenderItemType, StartDate, EndDate, StartTime, EndTime, NumberOfDays, IsAllDay) {
    try {
        var today = new Date();
        var hasStart = true;
        var hasEnd = true;
        var isOverDue = false;
        var startString = "";
        var endString = ""
        var displayString = "";

        if (!NumberOfDays || NumberOfDays == undefined) { NumberOfDays = 0 };
        if (!StartDate || StartDate == undefined) { hasStart = false };
        if (!EndDate || EndDate == undefined) { hasEnd = false };

        if (hasStart == true) {
            if (StartDate.toShortDateString() == today.toShortDateString()) {
                startString = "Today";
            } else {
                startString = StartDate.toShortDateString();
            }
        };
        if (hasEnd == true) {
            if (EndDate < today) {
                isOverDue = true;
            }
            if (EndDate.toShortDateString() == today.toShortDateString()) {
                endString = "Today"
            } else {
                endString = EndDate.toShortDateString();
            }
        };

        if (hasStart == true && hasEnd == true) {
            if (startString == endString) {
                displayString = startString;
            } else {
                displayString = startString + " to " + endString;
            };
        } else if (hasStart == true && hasEnd == false) {
            displayString =  "Start: " + startString;
        } else if (hasStart == false && hasEnd == true) {
            displayString =  "Due: " + endString;
        };

        if (CalenderItemType && CalenderItemType != "T") {
            if (NumberOfDays > 1) {
                if (hasStart == true && hasEnd == true) {
                    if (startString == endString) {
                        displayString = startString;
                    };
                    displayString = startString + " to " + endString;
                } else if (hasStart == true && hasEnd == false) {
                    displayString = "Start: " + startString;
                } else if (hasStart == false && hasEnd == true) {
                    displayString = "Due: " + endString;
                };
            } else if (IsAllDay == 1) {
                displayString = "All Day";
            } else {
                displayString = StartTime.toShortTimeString() + " to " + EndTime.toShortTimeString();
            };
        };

        return displayString;

    } catch (ex) {
        //alert(ex)
    }

};

function setTimeEntryStatus(status) {
    if (!status) {
        return '--';
    } else {
        var str = '--';
        i = parseInt(status)
        switch (i) {
            case 0:
                str = '--';  //localizeString('Ready To Submit');
                break;
            case 1:
                str = "Pending"
                break;
            case 2:
                str = "Approved"
                break;
            case 3:
                str = "Denied"
                break;
            case 4:
                str = "Not Submitted"
                break;
            case 5:
                str = '--';  //localizeString('Missing');
                break;
            case 6:
                str = '--';  //localizeString('All Time');
                break;
            case 7:
                str = '--';  //localizeString('Does Not Exist');
                break;
            case 8:
                str = "Post Period closed"
                break;
            case 9:
                str = '--';  //localizeString('Entered');
                break;
            default:
                str = '--';
                break;
        };
        return str;
    };
};
function localizeTimeEntryMessage(message) {
    return message
};

function jobDisplay(jobNumber, jobComponentNumber, componentDescription) {
    var job = "";
    var comp = "";
    var ret = "";
    
    if (jobNumber != undefined) {
        job = "" + jobNumber;
        var pad = "000000";
        ret = pad.substring(0, pad.length - job.length) + job;
        if (jobComponentNumber != undefined) {
            comp = "" + jobComponentNumber;
            pad = "00";
            ret = ret + " | " + pad.substring(0, pad.length - comp.length) + comp;
        };
        if (componentDescription != undefined) {
            ret = ret + " - " + componentDescription
        };
    };
    return ret;
};

window.AdvantageMobile_UI = $.extend(true, window.AdvantageMobile_UI, {
    handleDataServiceError: handleDataServiceError,
    localizeString: localizeString,
    booleanToYesNo: booleanToYesNo,
    ////alertPriorities: alertPriorities,
    setPriority: setPriority,
    setAlertPriorityText: setAlertPriorityText,
    setAlertPriorityCSS: setAlertPriorityCSS,
    localizeTimeEntryMessage: localizeTimeEntryMessage,
    ////////shutDown: shutDown,
    jobDisplay: jobDisplay,
});