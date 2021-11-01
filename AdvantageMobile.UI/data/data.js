(function () {

    var EmployeeCode = "";
    var SearchValue = "";

    var taskPriorityIndicatorCSS = "card-indicator task-priority-pending";
    var taskDueCSS = "";
    var taskCardCSS = "card-content";
    var lineLabelCSS = ""
    var taskListDataSource = new DevExpress.data.DataSource({
        load: function () {
            var d = new $.Deferred();
            AdvantageMobile_UI.db.get('GetTasks', {
                EmployeeCode: EmployeeCode,
                SearchValue: SearchValue,
            }).done(function (data) {
                d.resolve(data);
                DevExpress.ui.dialog.alert("load complete")
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        map: function (item) {
            var strStart = "";
            var strDue = "";
            var boolTmpCmplt = false;
            var tmpCmpltIcon = "icon_check";
            if (item.TaskStatus) {
                taskPriorityIndicatorCSS = setTaskPriorityIndicatorCSS(item.TaskStatus);
            };
            if (item.StartDate) {
                item.StartDate.toShortDateString()
            };
            if (item.DueDate) {
                item.DueDate.toShortDateString()
                taskDueCSS = setDueDateColorCSS(item.DueDate);
            };
            if (item.TempCompleteDate != null) {
                boolTmpCmplt = true;
                tmpCmpltIcon = "icon_undo";
                taskCardCSS = "card-content line-through"
            } else {
                taskCardCSS = "card-content";
            };
            return {
                JobNumber: item.JobNumber,
                JobComponentNumber: item.JobComponentNumber,
                SequenceNumber: item.SequenceNumber,
                Description: item.TaskDescription,
                TaskStatus: setPriority(item.TaskStatus),
                StartDate: strStart,
                DueDate: strDue,
                statusText: 'Status:',
                startText: 'Start:',
                dueText: 'Due:',
                itemHeaderText: item.JobData,
                TaskPriorityIndicatorCSS: taskPriorityIndicatorCSS,
                TaskDueCSS: taskDueCSS,
                IsTempComplete: boolTmpCmplt,
                TempCompleteDate: item.TempCompleteDate,
                TempCompleteIcon: tmpCmpltIcon,
                CardCSS: taskCardCSS
            };
        }
    });

    function dismissCompleteAlert(alertId, forceAssignmentComplete) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('DismissCompleteAlert', {
            AlertID: alertId,
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            ForceAssignmentComplete: forceAssignmentComplete,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };
    function getEmployeeTaskListDataSource(employeeCode, searchValue) {
        EmployeeCode = employeeCode;
        SearchValue = searchValue;
        return taskListDataSource;
    };
    function markTaskTempComplete(jobNumber, jobComponentNumber, sequenceNumber) {
        var d = new $.Deferred();
        var success = false;
        AdvantageMobile_UI.db.get('MarkTaskTempComplete', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            SequenceNumber: sequenceNumber,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };
    function unMarkTaskTempComplete(jobNumber, jobComponentNumber, sequenceNumber) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('UnMarkTaskTempComplete', {
            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            SequenceNumber: sequenceNumber,
        }).done(function (data) {
            d.resolve(data);
            //AdvantageMobile_UI.Messages.toastSuccess();
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };
    function notifyAlertRecipients(alertId, isNew, includeOriginator) {
        var d = new $.Deferred();
        AdvantageMobile_UI.db.get('NotifiyAlertRecipients', {
            AlertID: alertId,
            IsNew: isNew,
            IncludeOriginator: includeOriginator,
        }).done(function (data) {
            d.resolve(data);
        }).fail(function (data) {
            handleDataServiceError(data);
        })
        return d.promise();
    };

    $.extend(AdvantageMobile_UI.db, {
        getEmployeeTaskListDataSource: getEmployeeTaskListDataSource,
        notifyAlertRecipients: notifyAlertRecipients,
        dismissCompleteAlert: dismissCompleteAlert,
        markTaskTempComplete: markTaskTempComplete,
        unMarkTaskTempComplete: unMarkTaskTempComplete,
    });


}());