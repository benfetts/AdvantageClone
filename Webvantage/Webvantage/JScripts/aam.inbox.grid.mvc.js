//
function subjectTemplate(dataItem) {
    let SubjectView = ''
    let SubjectViewDetail = '';
    let test = '';

    SubjectView = dataItem.Subject;

    if (SubjectView.length > 40) {
        SubjectView = dataItem.Subject.substring(0, 40) + '...';
    }

    SubjectViewDetail = `<a href='javascript: void (0);' title='${dataItem.Subject}' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${dataItem.Subject}")'>${SubjectView}</a>`;

    return SubjectViewDetail
}

function onShowDetailsClick(ID, Category, SprintID, Subject) {
    if (gridDirty) {
        promptSave().done(() => showDetails(ID, Category, SprintID, Subject));                
    } else {
        showDetails(ID, Category, SprintID, Subject);
    }
}

function showDetails(ID, Category, SprintID, Subject) {
    let droplist = $('#AAView').data('kendoDropDownList');

    if (droplist.value() === "Drafts") {
        let url = 'Desktop_AlertView?AlertID=' + ID + '&SprintID=' + SprintID;
        OpenRadWindow(Subject, url);
    } else {
        if (Category == 38) {

        } else {
            let url = 'Desktop_AlertView?AlertID=' + ID + '&SprintID=' + SprintID;
            OpenRadWindow(Subject, url);
        }
    }
}

function onShowJobJacketClick(JobNumber, JobComponentNumber) {
    if (gridDirty) {
        promptSave().done(() => showJobJacket(JobNumber, JobComponentNumber));
    } else {
        showJobJacket(JobNumber, JobComponentNumber);
    }
}

function showJobJacket(JobNumber, JobComponentNumber) {    
    let url = ""            

    url = `Content.aspx?From=DO&PageMode=Edit&JobNum=${JobNumber}&JobCompNum=${JobComponentNumber}&NewComp=0`;
    OpenRadWindow('Job Jacket', url);    
}

function gridDataChanged() {        
    if (!pageFlag) {
        gridDirty = true;
        enableSave();
    }
    
}

function onAssignToClick(AssignToURL, AssignToTitle) {
    if (gridDirty) {
        promptSave().done(() => ProcessAssignToClick(AssignToURL, AssignToTitle));

    } else {
        ProcessAssignToClick(AssignToURL, AssignToTitle)
    }
}


function ProcessAssignToClick(AssignToURL, AssignToTitle) {        
    var url = AssignToURL
    openRadWindowWithEvents(AssignToTitle, url, 500, 500, false, function () {
        //reloadTaskList();        
        gridDirty = false;
        enableSave();
        saveGridChanges();
        refreshPage();
    });    
}

function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {    
    OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);        
}

function documentsTemplate(dataItem) {

    if (dataItem.AttachmentCount >= 1) {
        if (dataItem.AttachmentCount === 1){
            return "<div class='icon-background background-color-sidebar standard-light-green'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='" + dataItem.AttachmentCount + " attachment'></div>";
        } else {
            return "<div class='icon-background background-color-sidebar standard-light-green'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='" + dataItem.AttachmentCount + " attachments'></div>";
        }
        
    } else {
        return "<div class='icon-background background-color-sidebar standard-pink'><input style='cursor:default !important;' class='icon-image' type='image' id='image' src='../Images/Icons/White/256/documents_empty.png' title='No attachments'></div>";
    }

}

//function taskClientTemplate() {

//    return `${dataItem.ClientCode}/${dataItem.DivisionCode}/${dataItem.ProductCode}`;
//}

function startDateTemplate(dataItem) {
    if (dataItem.StartDate) {
        return kendo.toString(kendo.parseDate(dataItem.StartDate), "MM/dd/yyyy");
    }

    return '';
}

function taskFlagTemplate(dataItem) {
    let taskFlagDetail = '';
    let dueDate = '';

    if (dataItem.Category == "Task") {
        dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");

        taskFlagDetail = `<div taskflag-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${getDueDateClass(dataItem.TaskDateDiff, true, dataItem.AlertCategoryID, dataItem.TaskDateDiffIsWeekend)}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/signal_flag.png' style='cursor:default !important;' title='${getDueDateTitle(dataItem.TaskDateDiff, dueDate, dataItem.TaskDateDiffIsWeekend)}'></div>`
    } else {
        taskFlagDetail = "";
    }
    

    return taskFlagDetail;
}

function taskTempCompleteTemplate(dataItem) {
    let taskTempCompleteDetail = '';  
    let taskIcon = '';
    let taskTitle = '';
    let taskClass = '';

    if (dataItem.IsMyTaskTempComplete) {
        taskIcon = '../Images/Icons/white/256/delete.png';
        taskTitle = 'Mark not completed'
        taskClass = 'standard-pink';
    } else {
        taskIcon = '../Images/Icons/White/256/ok.png';
        taskTitle = 'Mark temp complete';
        taskClass = 'standard-light-green';
    }

    ///dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");

    taskTempCompleteDetail = `<div taskTempComp-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${taskClass}'>
                            <input class='icon-image' type='image' id='image' src='${taskIcon}' title='${taskTitle}' 
                            onclick='processTempComplete(${dataItem.IsMyTaskTempComplete}, ${dataItem.JobNumber}, ${dataItem.JobComponentNumber}, ${dataItem.TaskSequenceNumber});'></div>`;

    return taskTempCompleteDetail;
}

function processTempComplete(isTaskTempComplete, jobNumber, jobComponentNumber, sequenceNumber) {
    let data = {        
        IsTaskTempComplete: isTaskTempComplete,
        JobNumber: jobNumber,
        JobComponentNumber: jobComponentNumber,
        TaskSequenceNumber: sequenceNumber
    };

        $.ajax({
            type: "POST",
            url: "Inbox/ProcessTempComplete",
            data: JSON.stringify(data),
            contentType: 'application/json',
            success: function (response) {
                if (response.Message.length > 0) {
                    showKendoAlert(response.Message);                
                }                

                let grid = $("#aagrid").data("kendoGrid");
                grid.dataSource.read();                
            },
            error: function (response) {
                console.log("An error occurred during update: " + response.message);
                //showKendoAlert(Message);
            }
        });    
}

function dueDateTemplate(dataItem) {
    let dueDate = '';
    let dueDateFormatted = '';
    let taskClass = '';    

    if (dataItem.DueDate) {
        dueDate = kendo.toString(kendo.parseDate(dataItem.DueDate), "MM/dd/yyyy");
        
        //apply special formatting for tasks            
        if (dataItem.AlertCategoryID == 71) {            
            
            dueDateFormatted = `<div taskDueDate-cell='${dataItem.AlertID}' title='${getDueDateTitle(dataItem.TaskDateDiff, dueDate, dataItem.TaskDateDiffIsWeekend)}'>${dueDate} </div>`;

        } else {
            dueDateFormatted = dueDate;
        }        
    }

    return dueDateFormatted;
}

function getDueDateTitle(TaskDateDiff, TaskDueDate, IsWeekendDate) {
    let taskTitle = '';

    if (TaskDateDiff == 0) {
        taskTitle = 'Task is due today!';
    } else if (TaskDateDiff < 0) {
        taskTitle = `Task is overdue ${TaskDateDiff * -1} day(s) on ${TaskDueDate}`;
    } else if (TaskDateDiff > 0 && IsWeekendDate) {
        taskTitle = 'Due data is on a weekend!';
    } else {
        taskTitle = `Due in ${TaskDateDiff} days(s) on ${TaskDueDate}`;
    }

    return taskTitle;
}

function getDueDateClass(TaskDateDiff, TaskFlag, AlertCategoryID, IsWeekendDate) {            
    let taskClass = '';    

    if (!TaskFlag) {        
        if (TaskDateDiff > 8 || TaskDateDiff == null) {
            
            taskClass = '';
            return;
        }
    }          

    if (AlertCategoryID == 71) {
        if (TaskDateDiff == 0) {
            taskClass = 'standard-light-orange';
        } else if (TaskDateDiff < 0) {
            taskClass = 'standard-pink';
        } else if (IsWeekendDate && TaskDateDiff > 0) {
            taskClass = 'standard-light-grey';
        } else if (TaskDateDiff > 0 && TaskDateDiff < 9) {
            taskClass = 'standard-yellow';            
        } else {
            taskClass = 'standard-light-green';
        }            
    }
    
    return taskClass;
}

function jobTemplate(dataItem) {    
    let job = '';
    let jobNumber = '';
    let jobDescription = '';    
    let jobView = '';

    if (dataItem.JobNumber !== 0) {
        jobNumber = ('000000' + dataItem.JobNumber).slice(-6);
        jobDescription = dataItem.TaskJobDescription;

        job = `${jobNumber} - ${jobDescription}`;

        if (job.length > 40) {
            jobView = `<span title='${job}'>${job.substr(0, 40)}...</span>`;
        } else {
            jobView = `<span title='${job}'>${job}</span>`;
        }
    }
    
    return jobView;
}

function jobComponentTemplate(dataItem) {
    let job = '';
    let jobNumber = '';
    let jobComponentNumber = '';
    let jobDescription = '';
    let jobText = '';
    let jobViewDetail = ''

    if (dataItem.JobNumber !== 0) {
        jobNumber = ('000000' + dataItem.JobNumber).slice(-6);
        jobComponentNumber = ('000' + dataItem.JobComponentNumber).slice(-3);
        jobDescription = dataItem.TaskJobDescription;

        job = `${jobNumber}/${jobComponentNumber} - ${jobDescription} | ${dataItem.ClientName}`;
        
        if (job.length > 40) {                        
            jobText = job.substr(0, 40) + '...';
        } else {
            jobText = job;
        }
    }            

    if (dataItem.Category == 'Task' || (dataItem.JobNumber > 0 && dataItem.JobComponentNumber > 0)) {
        let JobNumber = '';
        let JobComponentNumber = '';

        JobNumber = dataItem.JobNumber;
        JobComponentNumber = dataItem.JobComponentNumber;

        jobViewDetail = `<a href='javascript: void (0);' title='${job}' onclick='onShowJobJacketClick(${JobNumber},${JobComponentNumber})'>${jobText}</a>`;
    } else {
        jobViewDetail = `<span title='${job}'>${jobText}</span>`;
    }

    return jobViewDetail;
}

//function taskJobComponentDescriptionTemplate(dataItem) {
//    let taskJobComponent = '';
//    let taskJobComponentView = '';

//    taskJobComponent = dataItem.TaskJobComponentDescription;

//    if (taskJobComponent.length > 40) {
//        taskJobComponentView = `<span title='${taskJobComponent}'>${taskJobComponent.substr(0,40)}...</span>`;
//    } else {
//        taskJobComponentView = `<span title='${taskJobComponent}'>${taskJobComponent}</span>`;
//    }

//    return taskJobComponentView;
//}

//function taskJobDescriptionTemplate(dataItem) {
//    let taskJob = '';
//    let taskJobView = '';

//    taskJob = dataItem.TaskJobDescription;

//    if (taskJob.length > 40) {
//        taskJobView = `<span title='${taskJob}'>${taskJob.substr(0, 40)}...</span>`;
//    } else {
//        taskJobView = `<span title='${taskJob}'>${taskJob}</span>`;
//    }

//    return taskJobView;
//}

function detailsTemplate(dataItem) {
    let divDetail = "";
    let title = getDetailTitleDescriptionByPriority(dataItem.Priority);
    let classText = getClassByPriority(dataItem.Priority);    

    if (dataItem.IsRead == 1) {
        divDetail = `<div priority-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${classText}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/mail_open.png' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${dataItem.Subject}")' title='${title}'></div>`
    } else {
        divDetail = `<div priority-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar ${classText}'><input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/mail.png' onclick='onShowDetailsClick(${dataItem.AlertID},${dataItem.AlertCategoryID},${dataItem.SprintID},"${dataItem.Subject}")' title='${title}'></div>`
    }

    return divDetail;
}

function statusTemplate(dataItem) {

    let currentState = "";
    let stateDetail = {};
    let canComplete = false;

    let isTask = false;
    let statusDetail = '';

    if (dataItem.Category == "Task") {
        statusDetail = taskTempCompleteTemplate(dataItem);
    } else {
        if (show == "myalertsandassignments") {
            if (dataItem.IsMyAssignment === true || dataItem.IsMyTask === true || dataItem.IsTaskAssignment === true) {
                canComplete = 1;
            }
        } else if (show == "myalertassignments") {
            canComplete = 1;
        } else {
            canComplete = 0;
        }

        currentState = getStatusState(dataItem);
        stateDetail = getStatusDetail(currentState, dataItem.Category);

        if (stateDetail.icon == '') {
            statusDetail = '';
        }

        statusDetail = `<div class='icon-background background-color-sidebar ${stateDetail.class}'><input class='icon-image' type='image' id='image' 
                    src='${stateDetail.icon}' onclick="alertAction(${dataItem.AlertID},${dataItem.SprintID},'${dataItem.Category}', ${canComplete})" 
                    title='${stateDetail.title}'></div>`;
    }

    return statusDetail;
}

function taskTemplate(dataItem) {
    let taskStatus = dataItem.TaskStatus;
    let priority = dataItem.Priority;
    let priorityClass = "";
    let priorityTooltip = "";
    let divDetail = "";    
    let alertID = dataItem.AlertID;    

    if (dataItem.IsTaskAssignment == true) {    
        if (taskStatus.length > 0) {
            if (taskStatus == "H") {
                priorityClass = getClassByPriority("2");
            } else if (taskStatus == "L") {
                priorityClass = getClassByPriority("4");
            } else {
                priorityClass = getClassByPriority(priority);
            }
        } 
        
        priorityTooltip = getTaskTitleDescription(taskStatus, priority);

        divDetail = `<div task-cell='${alertID}' class='icon-background background-color-sidebar ${priorityClass}'>`;
        divDetail += `<input class='icon-image' style='cursor:default !important;' type='image' id='image'`;
        divDetail += `src = '../Images/Icons/White/256/progress_bar.png' title = '${priorityTooltip}' ></div >`;
    }   
    
    return divDetail;
}

function taskCommentTemplate(dataItem) {
    let TaskCommentView = ''

    TaskCommentView = dataItem.TaskComments;

    if (TaskCommentView.length > 40) {
        TaskCommentView = dataItem.TaskComments.substring(0, 40) + '...';
    }

    return "<div title='" + dataItem.TaskComments + "'>" + TaskCommentView + "</div>"

}

function taskClientTemplate(dataItem) {
    let taskClientView = ''

    if (!dataItem.ClientCode || !dataItem.DivisionCode || !dataItem.ProductCode) {
        return "";
    }
    else {
        return `${dataItem.ClientCode}/${dataItem.DivisionCode}/${dataItem.ProductCode}`;
    }        
}

function functionAssignToTemplate(dataItem) {

    let response = '';

    if (dataItem.AssignedTo.length == 0) {
        response = '';
    } else {
        //console.log("Address:" + dataItem.AssignedToLinkAddress);
        let title = '';
        let jscript = '';

        if (dataItem.AssignedToLinkAddress.includes("TrafficSchedule_TaskEmployees")) {
            title = 'Employees';
        } else if (dataItem.AssignedToLinkAddress.includes("Desktop_Reassign")) {
            title = 'Assignment';
        } else {
            //Desktop_AlertView
            title = dataItem.Subject;
        }

        jscript = "onAssignToClick('" + dataItem.AssignedToLinkAddress + "', '" + title + "')";

        response = '<a href="javascript:void(0);" title="' + dataItem.AssignedToTitle + '" onclick="' + jscript + '">' + dataItem.AssignedTo + '</a>';
    }

    return response;
}

function AlertLevelTemplate(dataItem) {

    let response = ''

    if (dataItem.Level == null || dataItem.Level.length <= 0) {
        response = ''
    } else {
        if (dataItem.AlertLevelText == null || dataItem.AlertLevelText.length <= 0) {
            response = "<span title='No Description Available'>" + dataItem.Level + "</span>";
        } else {
            response = "<span title='" + dataItem.AlertLevelText + "'>" + dataItem.Level + "</span>";
        }
    }
    return response;
}

function priorityTemplate(dataItem) {
    if (dataItem.Priority) {
        if (dataItem.Priority == "3") {
            return "--"
        } else if (dataItem.Priority == "1") {
            return "HH"
        } else if (dataItem.Priority == "2") {
            return "H"
        } else if (dataItem.Priority == "4") {
            return "L"
        } else if (dataItem.Priority == "5") {
            return "LL"
        } else {
            return '';
        }
    }

    return '';
}

function getStatusDetail(state, category) {
    let statusDetail = {
        title: "",
        icon: "",
        class: "",
        enabled: true
    };   
    
    switch (state) {
        case "dismiss":
            statusDetail.title = "Dismiss Alert";
            statusDetail.icon = "../Images/Icons/White/256/garbage.png";
            statusDetail.class = "standard-light-green";            
            break;
        case "undismiss":
            statusDetail.title = "Un-dismiss Alert";
            statusDetail.icon = "../Images/Icons/White/256/garbage_full.png";
            statusDetail.class = "standard-amber";
            break;
        case "complete":
            if (category == "task") {
                statusDetail.title = "Mark Not Complete";
                statusDetail.icon = "../Images/Icons/White/256/delete.png";
                statusDetail.class = "standard-pink";
            } else {
                statusDetail.title = "Complete";
                statusDetail.icon = "../Images/Icons/White/256/ok.png";
                statusDetail.class = "standard-light-green";
            }
            
            break;
        case "reOpen":
            if (category == "task") {
                statusDetail.title = "Mark Temp Complete";
                statusDetail.icon = "../Images/Icons/White/256/check.png";
                statusDetail.class = ""; //no class leaves the color green
            } else {
                statusDetail.title = "Re-open Assignment";
                statusDetail.icon = "../Images/Icons/White/256/ok.png";
                statusDetail.class = "standard-amber";
            }            
            
            break;
        case "deleteDraft":
            statusDetail.title = "Delete Draft";
            statusDetail.icon = "../Images/Icons/White/256/delete.png";
            statusDetail.class = "standard-pink";            
            break;
        case "hide":
            statusDetail.title = "";
            statusDetail.icon = "../Images/spacer.gif";
            statusDetail.class = "display-none";            
            statusDetail.enabled = false;
            break;        
        default:
            break;
    }

    return statusDetail;
}

function getStatusState(dataItem){
    let status = "";
    //let openAssignment = false;
    let state = "";
    
    if (isJobJacketView) {
        if (dataItem.AssignedToEmpCode == _EmployeeCode) {

            if (dataItem.IsRouted) {
                if (dataItem.IsMyAssignment) {
                    if (dataItem.AssignedTo.toLowerCase() == "completed") {
                        state = "reOpen";
                    } else {
                        state = "complete";
                    }
                }
                //openAssignment = true;
            }

            if (state == "") {
                if (dataItem.IsTaskTempComplete) {
                    state = "reOpen";
                } else {
                    state = "complete";
                }
            }

        } else {
            state = 'hide';
        }

    } else {
        if (show == "unassigned") {
            state = "hide";
        } else {
            switch (GetViewValue()) {
                case "inbox":
                    switch (show) {
                        case "myalerts":
                            state = "dismiss";
                            break;
                        case "myalertassignments":
                            if (dataItem.Category == "task") {
                                if (dataItem.IsMyTaskTempComplete) {
                                    state = "reOpen";
                                } else {
                                    state = "complete";
                                }
                            } else {
                                state = "complete"
                            }
                            break;
                        case "myalertsandassignments":                                                                                  
                            
                            if ((!dataItem.IsRouted && dataItem.Category !== "task" && !dataItem.IsWorkItem) || dataItem.IsCC) {                                
                                state = "dismiss";
                            } else {
                                if (dataItem.Category == "task") {
                                    if (dataItem.IsMyTaskTempComplete) {
                                        state = "reOpen";
                                    } else {
                                        state = "complete";
                                    }
                                } else {
                                    if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.IsCurrentAssignee) {
                                        state = "complete";
                                    } else if (dataItem.IsWorkItem) {
                                        state = "complete";
                                    } else {                                        
                                        state = "dismiss";
                                    }
                                }
                            }
                            break;
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode) {
                                state = "complete";
                            } else {
                                state = "hide";
                            }
                            break;                        
                    }
                    break;
                case "dismissed":
                    switch (show) {
                        case "myalerts":
                            state = "undismiss";
                            break;
                        case "myalertassignments":
                            state = "reOpen";
                        case "myalertsandassignments":
                            if (!dataItem.IsRouted) {
                                state = "undismiss";
                            } else {
                                if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.IsCurrentAssignee) {
                                    if (!dataItem.IsCC) {
                                        state = "reOpen";
                                    } else {
                                        state = "undismiss";
                                    }
                                } else if (dataItem.IsWorkItem) {
                                    state = "reOpen";
                                } else {
                                    state = "undismiss";
                                }
                            }
                            break;                            
                        case "allalertassignments":
                            if (dataItem.AssignedToEmpCode == _EmployeeCode && (dataItem.IsCurrentAssignee || dataItem.AssignedTo.toLowerCase() == "completed")) {
                                state = "reOpen";                            
                            } else {
                                state = "hide";
                            }
                            break;
                    }
                    break;
                case "all":
                    if (dataItem.IsRouted) {
                        if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() == "completed") {
                            state = "reOpen";
                        } else if (dataItem.AssignedToEmpCode == _EmployeeCode && dataItem.AssignedTo.toLowerCase() !== "completed") {
                            state = "complete";
                        } else {
                            state = "hide";
                        }                        
                    } else {
                        if (dataItem.IsDismissed) {
                            state = "undismiss";
                        } else {
                            state = "dismiss";
                        }
                    }
                    break;
                case "drafts":
                    state = "deleteDraft";
                    break;
                case "task":
                    if (dataItem.IsMyTaskTempComplete) {
                        state = "reOpen";
                    } else {
                        state = "complete";
                    }
                    break;
            }
            
        }
    }

    return state;    
}


function addTimeTemplate(dataItem) {
    let addTimeDetail = '';
    let windowTitle = 'Add Time';    

    if (dataItem.Category == "Task" || (dataItem.JobNumber > 0 && dataItem.JobComponentNumber > 0)) {
        addTimeDetail = `<div stopwatch-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar standard-light-green'>
                            <input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/clock.png' title='Add Time' 
                            onclick="processAddTimeClick(${dataItem.AlertID}, ${dataItem.JobNumber}, ${dataItem.JobComponentNumber}, ${dataItem.TaskSequenceNumber});"></div>`;
    }    

    return addTimeDetail;
}

function processAddTimeClick(AlertID, JobNumber, JobComponentNumber, TaskSequenceNumber) {
    
    let windowURL = `Employee/Timesheet/Entry?a=${AlertID}&emp=${_EmployeeCode}&j=${JobNumber}&jc=${JobComponentNumber}&s=${TaskSequenceNumber}`;
    let windowTitle = 'Add Time';    

    openRadWindowWithEvents(windowTitle, windowURL, 600, 600, false);
}

function stopwatchTemplate(dataItem) {
    let stopWatchDetail = '';    

    if (dataItem.Category == "Task" || (dataItem.JobNumber > 0 && dataItem.JobComponentNumber > 0)) {
        stopWatchDetail = `<div stopwatch-cell='${dataItem.AlertID}' class='icon-background background-color-sidebar standard-light-green'>
                            <input class='icon-image' type='image' id='image' src='../Images/Icons/White/256/stopwatch.png' title='Click to start Stopwatch' 
                            onclick="processStopwatchClick(${dataItem.AlertID}, ${dataItem.JobNumber}, ${dataItem.JobComponentNumber}, ${dataItem.TaskSequenceNumber});"></div>`;
    } else {
        stopWatchDetail = '';
    }

    return stopWatchDetail;
}

function processStopwatchClick(AlertID, JobNumber, JobComponentNumber, TaskSequenceNumber) {    
    console.log(window.appBase);

    if (TaskSequenceNumber == null) {
        TaskSequenceNumber = -1;
    }

    let data = {
        EmployeeCode: _EmployeeCode
    };


    $.post({
        url: "../Employee/Timesheet/HasStopwatch",
        dataType: "json",
        data: JSON.stringify(data),
    }).always(function (result) {
        if (result) {
            //console.log("stopwatch result", result);
            if (result.StopwatchIsRunning === true) {
                showKendoConfirm("There is a stopwatch already running.\nStop it and start a new stopwatch?")
                    .done(function () {
                        $.post({
                            url: "../Employee/Timesheet/StopStopwatch",
                            dataType: "json",
                            data: data
                        }).always(function (result) {
                            if (result) {
                                //console.log("stop?", result);
                                startStopWatch(AlertID, JobNumber, JobComponentNumber, TaskSequenceNumber);
                            }
                        });
                    })
                    .fail(function () {
                        return false;
                    });
            } else {
                startStopWatch(AlertID, JobNumber, JobComponentNumber, TaskSequenceNumber);
            }
        }
    });    
}

function startStopWatch(AlertID, JobNumber, JobComponentNumber, TaskSequenceNumber) {
    let windowTitle = 'Timesheet Stopwatch';
    let windowURL = 'Timesheet_Stopwatch.aspx';

    let data = {
        AlertID: AlertID,
        JobNumber: JobNumber,
        JobComponentNumber: JobComponentNumber,
        TaskSequenceNumber: TaskSequenceNumber
    };

    console.log(data);

    $.ajax({
        type: "POST",
        url: "Inbox/StopWatchStart",
        data: JSON.stringify(data),
        contentType: 'application/json',
        success: function (response) {
            if (response.OpenStopWatch) {
                openRadWindowWithEvents(windowTitle, windowURL, 475, 500, false);
            } else {
                showKendoAlert(response.ErrorMessage);
            }
        },
        error: function (response) {
            showKendoAlert("An error occurred while attempting to start the stopwatch, please contact support.");
        }
    });
}


