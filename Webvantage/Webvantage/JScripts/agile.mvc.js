var controllerBase = window.appBase + "ProjectManagement/Agile/";

function moveToColumn(sprintDetailId, boardId, boardColumnId) {
    try {
        var data = {
            SprintDetailID: sprintDetailId,
            BoardID: boardId,
            BoardColumnID: boardColumnId
        };
        postToAction("MoveBoardItem", data);
    } catch (e) {
        //
    }
}
function resetProjectBoard(sprintId) {
    showKendoConfirm("Reset?")
        .done(function () {
            var data = {
                SprintID: sprintId
            };
            postToAction("DeleteSprintBySprintID", data);
        })
        .fail(function () {
        });
}
function openAlert(alertId) {
    if(alertId) {
        OpenRadWindow('', 'Alert_View.aspx?a=' + alertId, 0, 0, true);
    }
}
function openAssignment(alertId) {
    if(alertId) {
        OpenRadWindow('', 'Alert_Assignment.aspx?a=' + alertId, 0, 0, true);
    }
}
function openTask(jobNumber, jobComponentNumber, taskSequenceNumber) {
    if(jobNumber && jobComponentNumber && taskSequenceNumber) {
        OpenRadWindow('', 'TrafficSchedule_TaskDetail.aspx?j=' + jobNumber + '&jc=' + jobComponentNumber + '&a=' + taskSequenceNumber, 0, 0, true);
    }
}
function setTaskEmployees(jobNumber, jobComponentNumber, taskSequenceNumber) {
    if (jobNumber && jobComponentNumber && taskSequenceNumber >= 0) {
        OpenRadWindow('Employees', 'TrafficSchedule_TaskEmployees.aspx?From=pb&j=' + jobNumber + '&jc=' + jobComponentNumber + '&s=' + taskSequenceNumber, 0, 0, true);
    }
}
function postToAction(action, data) {
    //console.log(action) 
    //console.log(data)
    if (action && data) {
        $.post({
            url: controllerBase + action,
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log(response);
                if (response.Success && response.Success === true) {
                    //alert ("Success!");
                }
                if (response.Success && response.Success === false && Response.Message) {
                    alert ("Error in action: " + action + "\n" + Response.Message);
                }
                if (response.Data) {
                    //  Do something?
                }
            }
        });
    }
}


