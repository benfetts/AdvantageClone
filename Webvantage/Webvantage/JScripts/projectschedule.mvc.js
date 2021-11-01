var controllerBase = window.appBase + 'ProjectManagement/ProjectSchedule/';
var treeList, expandedIds, nonExpandedIds;
var treeListSuspend;
var dropTarget;
var draggedRow, targetRow, draggedItem, targetItem;
var offsetMilliseconds = new Date().getTimezoneOffset() * 60000;

/*
 * Actions
 */
function setTaskDocuments(sequenceNumber,TaskCode, TaskDescription, imgID, docLevel) {
    var model = getModelData();
    var treelist = $("#treelist").data("kendoTreeList");
    var taskDesc = encodeURI(TaskCode + ' - ' + TaskDescription);
    OpenRadWindow('Document List', 'Documents_List2.aspx?j=' + model.JobNumber + '&jc=' + model.JobComponentNumber + '&s=' + sequenceNumber + '&doc_img=' + imgID + '&doclvl=' + docLevel + '&task_desc=' + taskDesc, 0, 0, true, function () {
        reloadTaskList();
    });
}

function setTaskComments(sequenceNumber) {
    //var windowOptions = {
    //    actions: ["Close"],
    //    draggable: true,
    //    resizable: true,
    //    width: 500,
    //    height: 500,
    //    title: "Comments",
    //    visible: false,
    //    close: (e) => {
    //        console.log(e);
    //    }
    //};

    var windowOptions = {
        title: "Comments",
        width: 500,
        height: 500,
        showFooter: false,
        enableModal: true,
        allowDraggable: true,
        backgroundScroll: false,
        enableResize: true,
        enableAutoResize: true,
        showOnInit: false
    };

    var grid = $("#treelist").data("kendoTreeList");

    var data = grid.dataSource.data();

    var dataItem = data.find((o) => { return o["SequenceNumber"] == sequenceNumber; });

    $("#kendoWindowComments").ejDialog(windowOptions);
    $("#kendoWindowComments").data("SequenceNumber", sequenceNumber);

    //$("#kendoWindowComments").data("kendoWindow").center();
    //$("#kendoWindowComments").data("kendoWindow").open();

    $("#kendoWindowComments").ejDialog("open");
    $("#kendoWindowComments").ejDialog("refresh");

    $("#taskComment").val(dataItem['FunctionComments']);
    $("#dueDateComment").val(dataItem['DueDateComments']);
    $("#revisedDateComment").val(dataItem['RevisionDateComments']);

    $("#saveCommentsButton").unbind('click');
    $("#saveCommentsButton").unbind('click');
    $("#cancelCommentsButton").unbind('click');

    $("#saveCommentsButton").on('click', saveCommentsDialog);
    $("#cancelCommentsButton").on('click', (e) => {
        //$("#kendoWindowComments").data("kendoWindow").close();
        $("#kendoWindowComments").ejDialog("close");
    });

    //var model = getModelData();
    //OpenRadWindow('Comments', 'TrafficSchedule_TaskComments.aspx?JobNum=' + model.JobNumber + '&JobComp=' + model.JobComponentNumber + '&SeqNum=' + sequenceNumber, 450, 500, true, function () {
    //    reloadTaskList();
    //});

}

function saveCommentsDialog(e) {
    var grid = $("#treelist").data("kendoTreeList");
    var sequenceNumber = $("#kendoWindowComments").data("SequenceNumber");
    var data = grid.dataSource.data();
    var dataItem = data.find((o) => { return o["SequenceNumber"] == sequenceNumber; });

    var comment = $("#taskComment").val();
    if (dataItem['FunctionComments'] != comment && !(comment == '' && dataItem['FunctionComments'] == null)) {
        dataItem.set('FunctionComments', comment);
        taskEdited = true;
    }
    comment = $("#dueDateComment").val();
    if (dataItem['DueDateComments'] != comment && !(comment == '' && dataItem['DueDateComments'] == null)) {
        dataItem.set('DueDateComments', comment);
        taskEdited = true;
    }
    comment = $("#revisedDateComment").val();
    if (dataItem['RevisionDateComments'] != comment && !(comment == '' && dataItem['RevisionDateComments'] == null)) {
        dataItem.set('RevisionDateComments', comment);
        taskEdited = true;
    }
    setSave();
    $("#kendoWindowComments").ejDialog("close");
    //$("#kendoWindowComments").data("kendoWindow").close();
}

function setEmployees(JobNumber, JobComponentNumber,taskCode, sequenceNumber) {
    var url = 'TrafficSchedule_TaskEmployees.aspx?From=ts&JobNum=' + JobNumber + '&JobComp=' + JobComponentNumber + '&SeqNum=' + sequenceNumber + '&TaskCode=' + taskCode;
    openRadWindowWithEvents('Employees', url, 600, 650, true, function () {
        reloadTaskList();
    });
}
function setClientContacts(taskCode, sequenceNumber) {
    var model = getModelData();
    OpenRadWindow('Contacts', 'TrafficSchedule_TaskContacts.aspx?caller=TrafficSchedule.aspx&JobNum=' + model.JobNumber + '&JobComp=' + model.JobComponentNumber + '&SeqNum=' + sequenceNumber + '&TaskCode=' + taskCode + '&Client=' + model.ClientCode + '&Division=' + model.DivisionCode + '&Product=' + model.ProductCode, 600, 650, true, function () {
        reloadTaskList();
    });
}
function viewJobTrafficVersions(JobNumber, JobComponentNumber) {
    OpenRadWindow('', 'TrafficScheduleVersion.aspx?j=' + JobNumber + '&jc=' + JobComponentNumber, 0, 0, false, function () {
        reloadTaskList();
    });
}
function QuickEditTaskButtonClick() {
    var model = getModelData();
    var url = 'ProjectManagement/ProjectSchedule/QuickEdit' + window.queryString + '&JobNumber=' + model.JobNumber + '&JobComponentNumber=' + model.JobComponentNumber;
    openRadWindowWithEvents('Edit Tasks', url, 730, 825, true, function () {
        reloadTaskList();
    });
}
function addTasksFromListOfTasks() {
    var model = getModelData();
    var dueDate = $('#duedate').val();
    var url = 'Schedule_QuickAdd.aspx?j=' + model.JobNumber + '&jc=' + model.JobComponentNumber + '&dd=' + dueDate + '&rsh=0&mode=1';
    openRadWindowWithEvents('Add Tasks', url, 800, 950, true, function () {
        closeAllPopups();
        reloadTaskList();
    });
}
function addTasksFromTaskTemplates() {
    var model = getModelData();
    var dueDate = $('#duedate').val();
    var url = 'TrafficSchedule_QuickAdd.aspx?R=1&JobNum=' + model.JobNumber + '&JobComp=' + model.JobComponentNumber + '&DueDate=' + dueDate + '&Rush=0';
    openRadWindowWithEvents('Add Tasks', url, 600, 800, true, function () {
        closeAllPopups();
        reloadTaskList();
    });
}
function CopyToProjectSchedules(JobNumber, JobComponentNumber,JobTypeCode) {

    if (typeof JobTypeCode === "undefined" || JobTypeCode === null) {
        JobTypeCode = '';
    }

    var url = 'ProjectManagement/ProjectSchedule/CopyToProjectSchedules?JobNumber=' + JobNumber + '&JobComponentNumber=' + JobComponentNumber + '&JobTypeCode=' + JobTypeCode;
    openRadWindowWithEvents('', url, 600, 800, true, function () {
        reloadTaskList();
    });
}
function addTasksFromExistingSchedule() {
    var model = getModelData();
    var url = 'TrafficSchedule_CopyFrom.aspx?R=1&JobNum=' + model.JobNumber + '&JobComp=' + model.JobComponentNumber;
    openRadWindowWithEvents('', url, 590, 900, true, function () {
        closeAllPopups();
        reloadTaskList();
    });
}
function addTasksFromEstimate() {
    var model = getModelData();
    var url = 'Schedule_AddFromEst.aspx?j=' + model.JobNumber + '&jc=' + model.JobComponentNumber;
    openRadWindowWithEvents('Create from estimate', url, 730, 825, true, function () {
        closeAllPopups();
        reloadTaskList();
    });
}
function deleteSelectedTasks() {
    var items = treeList.select();
    var confirmMsg = 'Are you sure you want to delete the selected task';
    if (items.length <= 0) {
        showKendoAlert('Please select a task to delete');
        return;
    }
    if (items.length > 1) {
        confirmMsg += 's';
    }
    confirmMsg += '?';
    showKendoConfirm(confirmMsg)
        .done(function () {
            $.each(items, function (i,e) {
                treeList.removeRow(e);
            });
            taskDeleted = true;
            setSave();
        })
        .fail(function () {
        });
}
function searchAndReplaceTasks() {
    var model = getModelData();
    OpenRadWindow('Search and Replace', 'ProjectManagement/ProjectSchedule/FindAndReplace?wm=0&Components=' + model.JobNumber + ',' + model.JobComponentNumber, 0, 0, true, refresPage);
}
function filterTasks() {
    var model = getModelData();
    var curFilterString = '';
    if (filterString) {
        curFilterString = filterString;
    }
    OpenRadWindow('Task Filter', 'TrafficSchedule_Filter.aspx?View=single&JobNum=' + model.JobNumber + '&JobCompNum=' + model.JobComponentNumber + curFilterString, 300, 555, true, function () {
        reloadTaskList();
    });
}
function clearFilters() {
    var href = window.location.href;
    var filters = filterString.split("&");
    $.each(filters, function () {
        href = href.replace('&' + this, '');
    });
    window.location.href = href;
}
function autoStatus() {
    var model = getModelData();
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        AutoStatus: $('#AutoStatus').is(':checked')
    };
    postToAction('UpdateAutoStatus', data, true);
}
function calculateDates() {
    let dfd = jQuery.Deferred();

    postToAction('CalculateScheduleDates', null, true).then(() => {
        closeAllPopups();
        dfd.resolve();
    });

    return dfd.promise();
}
function markTempComplete() {
    postToAction('MarkTempComplete', null, true).then(() => {
        closeAllPopups();
    });
}
function clearDates() {
    postToAction('ClearDates', null, true).then(() => {
        closeAllPopups();
    });
}
function clearDatesIncludingOriginalDueDate() {
    var model = getModelData();
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        IncludeOriginal: true
    };
    postToAction('ClearDates', data, true).then(() => {
        closeAllPopups();
    });
}
function setOriginalDueDateWhereNotSet() {
    postToAction('SetOriginalDueDateOnlyWhereNotSet', null, true).then(() => {
        closeAllPopups();
    });
}
function setOriginalDueDateForSelected() {
    var model = getModelData();
    var seqNums = getSelectedSequenceNumbers();
    if (!seqNums || seqNums.length <= 0) {
        showKendoAlert('No tasks are selected.');
        return;
    }
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        SequenceNumbers: seqNums
    };
    postToAction('SetOriginalDueDateForTasks', data, true).then(() => {
        closeAllPopups();
    });
}
function setOriginalDueDateForAll() {
    postToAction('SetOriginalDueDate', null, true).then(() => {
        closeAllPopups();
    });
}
function setEmployeeTeamByFunction() {
    var model = getModelData();
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        ByFunction: true
    };
    postToAction('SetEmployeeTeam', data, true).then(() => {
        closeAllPopups();
    });
}
function setEmployeeTeamByRole() {
    var model = getModelData();
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        ByFunction: false
    };
    postToAction('SetEmployeeTeam', data, true).then(() => {
        closeAllPopups();
    });
}
function findEmployees() {
    var model = getModelData();
    OpenRadWindow('Find Employees', 'Resources_Emps_Find.aspx?from=1&j=' + model.JobNumber + '&jc=' + model.JobComponentNumber + '&cli=' + model.ClientCode, 0, 0, false, function () {
        closeAllPopups();
        reloadTaskList();
    });
}
function clearEmployeeAssignments() {
    showKendoConfirm("Are you sure you want to clear all assignments?")
        .done(function () {
            postToAction('ClearEmployeeAssignments', null, true).then(() => {
                closeAllPopups();
            });
        })
        .fail(function () {
        });
}

var uid = "";

function selectPredecessors(e) {
    var item = treeList.dataSource.get(e);
    if (item) {
        if (!item.PredecessorLevelNotation) {
            item.PredecessorLevelNotation = "";
        }

        var currentPreds = item.PredecessorLevelNotation.split(',');
        if (!currentPreds || (currentPreds.length === 1 && currentPreds[0] === '')) {
            currentPreds = [];
        }
        $.each(currentPreds, (i) => {
            currentPreds[i] = $.trim(currentPreds[i]);
        });
        $.each(treeList.items(), function () {
            $(this).addClass('selecting-preds');
        });
        uid = item.uid;
        var row = $('tr[data-uid=' + item.uid + ']');
        row.addClass('pred-selector');
        // selecting
        $('.k-textbox').addClass('k-state-disabled pred-disabled');
        $('.k-textbox').each(function () {
            $(this).prop('disabled', true);
        });
        $('[data-role=numerictextbox]').each(function () {
            $(this).addClass('pred-disabled');
            $(this).data('kendoNumericTextBox').enable(false);
        });
        treeList.refresh();
        if (currentPreds.length > 0) {
            $.each(treeList.dataSource.view(), function () {
                var checked = false;
                if (currentPreds.indexOf(this.Level) >= 0) {
                    checked = true;
                }
                $('#SelectPreds_' + this.SequenceNumber).attr('checked', checked ? 'checked' : false);
            });
        }

        selectingPreds = true;
    }
}
function finishSelectPredecessors() {

    var rows = $('tr.pred-selector');

    if (rows.lenght > 0) {
        var row = $(rows[0]);
    }
    else{
        row = $('tr[data-uid=' + uid + ']');
    }

    var item = treeList.dataItem(row);
    if (!item.PredecessorLevelNotation) {
        item.PredecessorLevelNotation = '';
    }

    var currentPreds = item.PredecessorLevelNotation.split(',');
    if (!currentPreds) {
        currentPreds = [];
    }
    $.each(currentPreds, (i) => {
        currentPreds[i] = $.trim(currentPreds[i]);
    });
    var levels = [];
    var newPreds = [];
    var predsChanged = false;
    $('input[id^=SelectPreds_]').each(function () {
        if ($(this).is(":checked")) {
            var seq = this.id.split("_")[1];
            var currItem = treeList.dataSource.get(seq);
            if (currentPreds.indexOf(currItem.Level) < 0) {
                predsChanged = true;
            }
            newPreds[newPreds.length] = currItem.SequenceNumber;
            levels[levels.length] = currItem.Level;
        }
    });
    if (newPreds.length !== currentPreds.length) {
        predsChanged = true;
    }
    if (predsChanged === true) {
        validatePredecessors(item, newPreds, function () {
            item.set('PredecessorSequenceNumbers', newPreds);
            var PredecessorLevelNotation = levels.join(", ");
            item.set('PredecessorLevelNotation', PredecessorLevelNotation);
            taskEdited = true;
            setSave();
            endSelectingPreds();
        }, function () {
            //on fail
            endSelectingPreds();
        });
    } else {
        endSelectingPreds();
    }

    selectingPreds = false;
}
function endSelectingPreds() {
    $('tr.pred-selector').removeClass('pred-selector');
    $.each(treeList.items(), function () {
        $(this).removeClass('selecting-preds');
    });
    $('.k-textbox').removeClass('k-state-disabled pred-disabled');
    $('.k-textbox').each(function () {
        $(this).prop('disabled', false);
    });
    $('.pred-disabled[data-role=numerictextbox]').each(function () {
        $(this).removeClass('pred-disabled');
        $(this).data('kendoNumericTextBox').enable(true);
    });
    treeList.refresh();
}
function linkItem(e, linked) {
    var item = treeList.dataSource.get(e);
    var itemIndex = treeList.items().index($('tr[data-uid=' + item.uid + ']'));
    var linkTo = treeList.dataSource.getByUid($(treeList.items()[itemIndex - 1]).attr('data-uid'));
    var data = {
        JobNumber: item.JobNumber,
        JobComponentNumber: item.JobComponentNumber,
        SequenceNumber: item.SequenceNumber,
        Linked: false,
        LinkToSequenceNumber: null
    };
    var url = controllerBase + 'LinkItem';
    if (linked === true) {
        data.Linked = true;
        data.LinkToSequenceNumber = linkTo.SequenceNumber;
    }
    $.post({
        url: url,
        dataType: 'json',
        data: data
    }).done(function (result) {
        if (result) {
            var predList = '';
            if (result.Success === true) {
                item.HasPredecessors = result.Data.HasPredecessors;
                item.PredecessorSequenceNumbers = result.Data.PredecessorSequenceNumbers;
                item.PredecessorLevelNotation = result.Data.PredecessorLevelNotation;
                //treeList.dataSource.pushUpdate(item);
            } else {
                showKendoAlert(result.Message);
            }
        }
    }).always(function () {
       treeList.refresh();
    });
}
function taskContextMenuSelect(e) {
    var task = treeList.dataItem(e.target);
    if (e.item.id === "TaskDetails") {
        viewTaskDetails(task);
    } else if (e.item.id === "DeleteTask") {
        treeList.select($(e.target));
        deleteSelectedTasks();
    } else if (e.item.id === "NewTaskAssignment") {
        newTaskAssignment(task);
    } else if (e.item.id === "NewTaskAlert") {
        newTaskAlert(task);
    } else if (e.item.id === "ContextAbove") {
        treeList.clearSelection();
        treeList.select($(e.target));
        openQuickAddTaskWindow(treeList.select(), false, true, false, false);
    } else if (e.item.id === "ContextInto") {
        treeList.clearSelection();
        treeList.select($(e.target));
        openQuickAddTaskWindow(treeList.select(), false, false, true, false);
    } else if (e.item.id === "ContextBelow") {
        treeList.clearSelection();
        treeList.select($(e.target));
        openQuickAddTaskWindow(treeList.select(), false, false, false, true);
    }
}
function viewTaskDetails(task) {
    var model = getModelData();
    var url = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" + model.JobNumber + "&JobComp=" + model.JobComponentNumber + "&SeqNum=" + task.SequenceNumber + "&Client=" + model.ClientCode + "&Division=" + model.DivisionCode + "&Product=" + model.ProductCode;
    OpenRadWindow(task.TaskDescription, url, 0, 0, false, function () {
        reloadTaskList();
    });
}
function newTaskAssignment(task) {
    var model = getModelData();
    var url = "Alert_New.aspx?assn=1&pop=1&f= " + model.TaskAlertSource + "&j=" + model.JobNumber + "&jc=" + model.JobComponentNumber + "&seq=" + task.SequenceNumber + "&fnc=" + task.FunctionCode + "&cli=&div=&prd=";
    OpenRadWindow('', url, 0, 0, false, function () {
        reloadTaskList();
    });
}
function newTaskAlert(task) {
    var model = getModelData();
    var url = "Alert_New.aspx?assn=0&pop=1&f= " + model.TaskAlertSource + "&j=" + model.JobNumber + "&jc=" + model.JobComponentNumber + "&seq=" + task.SequenceNumber + "&fnc=" + task.FunctionCode + "&cli=&div=&prd=";
    OpenRadWindow('', url, 0, 0, false, function () {
        reloadTaskList();
    });
}
function selectAllTasks() {
    if ($('#SelectAllTasksCheckBox').is(":checked")) {
        treeList.select(treeList.tbody.find('tr'));
    } else {
        treeList.clearSelection();
    }
}
function changeScheduleCalculation(JobNumber, JobComponentNumber, CalculateByPredecessor) {
    var data = {
        JobNumber: JobNumber,
        JobComponentNumber: JobComponentNumber,
        CalculateByPredecessor: !CalculateByPredecessor
    };
    let dfd = jQuery.Deferred();

    postToAction('ChangeScheduleCalculation', data, false, true).then(() => {
        dfd.resolve();
    });

    return dfd.promise();
}
function updateScheduleStatus(JobNumber, JobComponentNumber) {

    var data = {
        JobNumber: JobNumber,
        JobComponentNumber: JobComponentNumber
    };

    let dfd = jQuery.Deferred();

    postToAction('UpdateScheduleStatus', data, false, true).then(() => {
        dfd.resolve();
    });

    return dfd.promise();
}

/*
 * TreeList events
 */
function treeListDataBinding(e) {
    treeList = e.sender;
    treeList.selectable.options.multiple = true;
}
function getSelectedSequenceNumbers() {
    var items = treeList.select();
    var seqNums = [];
    if (items) {
        $.each(items, function () {
            seqNums.push(treeList.dataItem(this).SequenceNumber);
        });
    }
    return seqNums;
}
function treeListDataBound(e) {

    //var wrapper = this.wrapper,
    //    header = wrapper.find('.k-grid-header'),
    //    initLeft = null;

    //function resizeFixed() {
    //    autoSizeColumns();
    //}

    //function scrollFixed() {
    //    var offset = $(this).scrollTop(),
    //        tableOffsetTop = wrapper.offset().top,
    //        tableOffsetBottom = tableOffsetTop + wrapper.height() - header.height();

    //    if (offset < tableOffsetTop || offset > tableOffsetBottom) {
    //        header.removeClass("fixed-header");
    //    } else if (offset >= tableOffsetTop && offset <= tableOffsetBottom && !header.hasClass("fixed")) {
    //        header.addClass("fixed-header");
    //    }
    //    if (header.hasClass("fixed-header")) {
    //        if (!initLeft) {
    //            initLeft = parseInt(header.css('left'));
    //            header.css('top', $('#gridToolBarWrap').height());
    //        }
    //        header.css('left', initLeft - $(window).scrollLeft());
    //    }
    //}

    //$(window).resize(resizeFixed);
    //$(window).scroll(scrollFixed);

    //var item = treeList.dataSource.at(0);

    //var model = getModelData();

    //var data = {
    //    JobNumber: model.JobNumber,
    //    JobComponentNumber: model.JobComponentNumber,
    //    SequenceNumber: -1,
    //    FilterByTrafficCode: false,
    //    TrafficCode: null,
    //    MustIncludeEmployees: ''
    //};


    //var emps = [];

    //$.ajax({
    //    url: controllerBase + "LoadAvailableEmployees",
    //    data: data,
    //    method: 'GET'
    //}).always(function (response) {
    //    emps = response;

    //    $('input.ps-auto-complete').each(function () {
    //        if ($(this).closest('td').find('.k-widget').length === 0) {
    //            var initValue = $(this).val();
    //            var values = [];
    //            var autoBind = true;
    //            var dataSource;
    //            if (initValue !== '') {
    //                initValue = initValue.replace(/\s/g, '');
    //                values = initValue.split(",");
    //            }
    //            if (values.length === 0) {
    //                values = [];
    //                dataSource = emps;
    //            } else {
    //                data.MustIncludeEmployees = initValue;
    //                dataSource = {
    //                    serverFiltering: false,
    //                    transport: {
    //                        read: {
    //                            url: controllerBase + 'LoadAvailableEmployees',
    //                            data: data
    //                        }
    //                    }
    //                };
    //            }
    //            $(this).kendoMultiSelect({
    //                dataTextField: 'EmployeeName',
    //                dataValueField: 'EmployeeCode',
    //                filter: 'contains',
    //                dataSource: dataSource,
    //                value: values,
    //                autoBind: true,
    //                change: function (e) {
    //                    var dataItem = treeList.dataItem($(e.sender.element).closest('tr'));
    //                    var emps = this.value().join(",");
    //                    if (emps === '') {
    //                        emps = null;
    //                    }
    //                    if (!dataItem.PredecessorSequenceNumbers) {
    //                        dataItem.PredecessorSequenceNumbers = [];
    //                    }
    //                    dataItem.set('EmployeeCode', emps);
    //                },
    //                dataBound: function (e) {
    //                    if ($(this.input).val() !== '' && $(this.input).val().length > 0) {
    //                        var inp = this;
    //                        window.setTimeout(function () {
    //                            inp.refresh();
    //                        }, 1000);
    //                    }
    //                }
    //            });
    //        }
    //    });

    //});

    //var taskStatusList = [{ text: 'Projected', value: 'P' },
    //{ text: 'Active', value: 'A' },
    //{ text: 'High Priority', value: 'H' },
    //{ text: 'Low Priority', value: 'L' }];

    //$('span[data-field="TaskStatus"]').each(function () {
    //    var taskStatus = $(this).html();
    //    var taskStatusDesc = '';
    //    $(taskStatusList).each(function () {
    //        if (this.value === taskStatus) {
    //            taskStatusDesc = this.text;
    //        }
    //    });
    //    if (taskStatusDesc === '') {
    //        taskStatusDesc = 'Projected';
    //    }
    //    $(this).html(taskStatusDesc);
    //});

    //$('input[data-field="TaskStatus"]').each(function () {
    //    var statusDescription = '';
    //    var taskStatus = $(this).val();
    //    $(taskStatusList).each(function () {
    //        if (this.value.toUpperCase() === taskStatus.toUpperCase() || this.text.toUpperCase() === taskStatus.toUpperCase()) {
    //            statusDescription = this.text;
    //        }
    //    });
    //    if (statusDescription === '') {
    //        statusDescription = taskStatusList[0].text;
    //    }
    //    $(this).val(statusDescription);
    //});

    //if (model.IsQuickEdit === false) {
    //    $(treeList.tbody).find('tr').each(function () {
    //        var dataItem = treeList.dataItem($(this));
    //        var hasAlerts = false;
    //        if (dataItem) {
    //            if (Boolean(dataItem.HasAlerts) === true || Boolean(dataItem.HasAssignment) === true) {
    //                hasAlerts = true;
    //            ////}
    //        }
    //        if (hasAlerts) {
    //            $(this).find('td:eq(0)').addClass('has-alerts');
    //        } else {
    //            $(this).find('td:eq(0)').removeClass('has-alerts');
    //        }
    //    });
    //}

    setExpanded();
    //if (item) {
    //    autoSizeColumns();
    //}
    //makeDraggable();
}
function treeListExpand(e) {
    autoSizeColumns();
}
function treeListCollapse(e) {
    autoSizeColumns();
}
function selectionChanged(e) {
    var selection = treeList.select();
    var items = treeList.dataSource.view().length;
    var allSelected = false;
    if (items > 0) {
        if (selection.length === items) {
            allSelected = true;
        }
    }
    $('#SelectAllTasksCheckBox').prop('checked', allSelected);
}
function treeListRequestStart(e) {
    if (treeList) {
        if (treeListSuspend) {
            clearTimeout(treeListSuspend);
        }
        treeListSuspend = setTimeout(function () {
            kendo.ui.progress(treeList.element, true);
        }, 1000);
    }
}
function addOffset(tasks) {
    for (var i = 0; i < tasks.length; i++) {
        addOffsetToDate(tasks[i], 'TaskStartDate');
        addOffsetToDate(tasks[i], 'JobRevisedDate');
        addOffsetToDate(tasks[i], 'JobCompletedDate');
        addOffsetToDate(tasks[i], 'JobDueDate');
        addOffsetToDate(tasks[i], 'PhaseStartDate');
        addOffsetToDate(tasks[i], 'PhaseEndDate');
    }
}
function addOffsetToDate(task, dateProp) {
    if (task[dateProp]) {
        task[dateProp] = task[dateProp].replace(/\d+/, function (n) { return parseInt(n) + offsetMilliseconds; });
    }
}
function treeListRequestEnd(e) {
    if (treeListSuspend) {
        clearTimeout(treeListSuspend);
    }
    var data = e.response;
    if (data.Data && data.Data.length) {
        var tasks = data.Data;
        if (this.group().length) {
            for (var i = 0; i < tasks.length; i++) {
                var gr = tasks[i];
                if (gr.Member === "TaskStartDate" || gr.Member === "JobRevisedDate" || gr.Member === "JobCompletedDate" || gr.Member === "JobDueDate" || gr.Member === "PhaseStartDate" || gr.Member === "PhaseEndDate") {
                    gr.Key = gr.Key.replace(/\d+/, function (n) { return parseInt(n) + offsetMilliseconds; });
                }
                addOffset(gr.Items);
            }
        } else {
            addOffset(tasks);
        }
    }
    if (treeList) {
        kendo.ui.progress(treeList.element, false);
        if (e.type === 'update') {
            var item = treeList.dataSource.get(data.Task.SequenceNumber);
            if (item) {
                if (data.Task) {
                    refreshDataSourceTask(data.Task);
                }
                if (data.TasksMadeActive && data.TasksMadeActive.length > 0) {
                    $.each(data.TasksMadeActive, function () {
                        var activeItem = treeList.dataSource.get(this);
                        if (activeItem) {
                            activeItem.TaskStatus = 'A';
                            treeList.dataSource.pushUpdate(activeItem);
                        }
                    });
                }
                if (data.TrafficStatus) {
                    if (data.TrafficStatus.Code) {
                        $('#JobTraffic_TrafficCode').val(data.TrafficStatus.Code);
                        $('#JobTraffic_Traffic_Description').val(data.TrafficStatus.Description);
                    }
                }
                if (data.ScheduleWasCompleted) {
                    if (data.ScheduleCompletedDate) {
                        $('#ScheduleCompletedDate').data('kendoDatePicker').value(data.ScheduleCompletedDate);

                    } else {
                        $('#ScheduleCompletedDate').data('kendoDatePicker').value(null);
                    }
                }
                if (data.ErrorMessage && data.ErrorMessage !== '') {
                    showKendoAlert(data.ErrorMessage);
                }
            }
        }
        if (e.type === 'create') {
            if (data) {
                if (data.Errors) {
                    item = treeList.dataSource.get(-1);
                    treeList.dataSource.remove(item);
                    showKendoAlert(data.Errors);
                } else {
                    var taskWindow = $('#QuickAddTaskWindow').data('kendoWindow');
                    taskWindow.close();
                    treeList.dataSource.get(-1).SequenceNumber = data.SequenceNumber;
                    treeList.dataSource.bind('sync', refreshItemsAfterCreate);


                    refreshItemsAfterCreate();
                }
            }
        }
    }
}
function refreshItemsAfterCreate() {
    treeList.dataSource.unbind('sync');
    updateItemsOrder(treeList.dataSource.view());
}

/*
 * Helpers
 */
function reloadTaskList() {
    beginTaskListRefresh();
    treeList.dataSource.read().always(function () {
        endTaskListRefresh();
    });
}
function postToAction(action, data, refreshTaskList, refreshPage) {
    var dfd = jQuery.Deferred();
    if (refreshTaskList === true) {
        beginTaskListRefresh();
    }
    if (!data) {
        var model = getModelData();
        data = {
            JobNumber: model.JobNumber,
            JobComponentNumber: model.JobComponentNumber
        };
    }
    $.post({
        url: controllerBase + action,
        dataType: 'json',
        data: data
    }).always(function (response) {
        if (refreshPage === true) {
            //window.location.reload();
            $('#refreshProjectSchedule').trigger('click');
        } else {
            if (response) {
                if (response.Data) {
                    if (response.Data.StartDate) {
                        $('#startdate').data('kendoDatePicker').value(response.Data.StartDate);
                    }
                    if (response.Data.DueDate) {
                        $('#duedate').data('kendoDatePicker').value(response.Data.DueDate);
                    }
                    if (response.Data.ScheduleCompletedDate) {
                        $('#ActualComplete').data('kendoDatePicker').value(response.Data.ScheduleCompletedDate);

                    }
                }
            }
            if (refreshTaskList === true) {
                treeList.dataSource.read().always(function () {
                    endTaskListRefresh();
                });
            }
        }

        dfd.resolve();
    });

    return dfd.promise();
}
function lookupEntity(data, callbackOnSuccess, callbackOnFail) {
    $.post({
        url: controllerBase + 'LookupEntity',
        dataType: 'json',
        data: data
    }).always(function (response) {
        if (response.Success === true) {
            callbackOnSuccess(response);
        } else if (response.Message !== '') {
            showKendoAlert(response.Message);
            callbackOnFail();
        }
    });
}
function refreshDataSourceTask(task) {
    var item = treeList.dataSource.get(task.SequenceNumber);
    if (item) {
        addOffsetToDate(task, 'JobDueDate');
        item.TaskCode = task.TaskCode;
        item.TaskDescription = task.TaskDescription;
        item.PredecessorLevelNotation = task.PredecessorLevelNotation;
        item.PredecessorSequenceNumbers = task.PredecessorSequenceNumbers;
        item.HasPredecessors = task.HasPredecessors;
        item.JobDueDate = kendo.parseDate(task.JobDueDate);
        if (task.DueDateLock !== item.DueDateLock) {
            item.DueDateLock = task.DueDateLock;
            $('#DueDateLock_' + item.SequenceNumber).prop('checked', item.DueDateLock === 1 ? true : false);
        }
        treeList.dataSource.pushUpdate(item);
    }
}
function saveExpanded() {
    expandedIds = [];
    nonExpandedIds = [];
    $.each(treeList.dataSource.view(), function () {
        if (treeList.dataSource.childNodes(this).length > 0) {
            if (this.expanded === true) {
                expandedIds.push(this.id);
            } else {
                nonExpandedIds.push(this.id);
            }
        }
    });
}
function setExpanded() {
    if (expandedIds && expandedIds.length > 0) {
        $.each(expandedIds, function () {
            var item = treeList.dataSource.get(this);
            if (item && item.expanded === false) {
                treeList.expand('tr[data-uid=' + item.uid + ']');
            }
        });
        expandedIds = [];
    }
    if (nonExpandedIds && nonExpandedIds.length > 0) {
        $.each(nonExpandedIds, function () {
            var item = treeList.dataSource.get(this);
            if (item && item.expanded === true) {
                treeList.collapse('tr[data-uid=' + item.uid + ']');
            }
        });
        nonExpandedIds = [];
    }
}
function autoSizeColumns() {
    setTimeout(function () {
        var treeListWidth = 0;
        for (var i = 0; i < treeList.columns.length; i++) {
            var col = treeList.columns[i];
            if (col.attributes) {
                if (col.attributes.autofit === true) {
                    //treeList.autoFitColumn(i);
                }
                if (i === 0) {
                    var paddingLeft = parseFloat(treeList.table.find('td:first-child').css('padding-left'));
                    var paddingRight = parseFloat(treeList.table.find('td:first-child').css('padding-right'));
                    col.attributes.minwidth = $('#levelWrap').width() + paddingLeft + paddingRight + 5;
                    var colContentWidth = 0;
                    treeList.tbody.children('tr').find('td:first-child').each(function () {
                        var rowColContentWidth = 0;
                        $(this).find('span').each(function () {
                            rowColContentWidth += $(this).width();
                        });
                        if (rowColContentWidth > colContentWidth) {
                            colContentWidth = rowColContentWidth;
                        }
                    });
                    colContentWidth += paddingLeft;
                    colContentWidth += paddingRight;
                    if (colContentWidth > col.attributes.minwidth) {
                        col.attributes.minwidth = colContentWidth;
                    }
                }
                if (!isNaN(col.attributes.minwidth)) {
                    if (treeList.thead.closest('table').children('colgroup').find('col').eq(i).width() < col.attributes.minwidth) {
                        treeList.thead.closest('table').children('colgroup').find('col').eq(i).width(col.attributes.minwidth);
                    }
                    if (treeList.tbody.closest('table').children('colgroup').find('col').eq(i).width() < col.attributes.minwidth) {
                        treeList.tbody.closest('table').children('colgroup').find('col').eq(i).width(col.attributes.minwidth);
                    }
                }
            }
        }
        treeListWidth = 0;
        treeList.tbody.find('tr:first-child td').each(function () {
            treeListWidth += $(this).outerWidth();
        });
        if (treeList.dataSource.view().length > 0) {
            $('#ProjectSchedule').width(treeListWidth + 15);
        }
    }, 0);
}
function isSelectingPreds() {
    return $('tr.selecting-preds').length > 0 ? true : false;
}
function calculateItemLevel(seqNum) {
    var item = treeList.dataSource.get(seqNum);
    var parentItem;
    var level = '';
    if (item) {
        parentItem = treeList.dataSource.parentNode(item);
        if (parentItem) {
            level = parentItem.Level + '.' + (treeList.dataSource.childNodes(parentItem).indexOf(item) + 1).toString();
        } else {
            level = (treeList.dataSource.rootNodes().indexOf(item) + 1).toString();
        }
    }
    return level;
}
function calculateLevels(parentItem) {
    var items, baseLevel;
    if (!parentItem) {
        items = treeList.dataSource.rootNodes();
        baseLevel = '';
    } else {
        items = treeList.dataSource.childNodes(parentItem);
        baseLevel = parentItem.Level + '.';
    }
    for (var i = 1; i <= items.length; i++) {
        var item = items[i - 1];
        item.Level = baseLevel + i.toString();
        calculateLevels(item);
    }
}
function getPredLevelNotation(seqNum) {
    var item = treeList.dataSource.get(seqNum);
    var predList = [];
    var notation = '';
    if (item) {
        $.each(item.PredecessorSequenceNumbers, function () {
            var pred = treeList.dataSource.get(seqNum);
            if (pred) {
                predList.push(pred.Level);
            }
        });
        if (pList.length > 0) {
            notation = predList.join(', ');
        }
    }
    return notation;
}
function updateTask(element, property) {
    var item = treeList.dataSource.getByUid($(element).closest('tr').attr('data-uid'));
    if (item) {
        var val;
        if ($(element).is("input[type='checkbox']")) {
            val = $(element).is(":checked");
            if (property === 'Milestone' || property === 'DueDateLock') {
                val = val === true ? 1 : 0;
            }
        } else {
            val = $(element).val();
        }
        if (!item.PredecessorSequenceNumbers) {
            item.PredecessorSequenceNumbers = [];
        }
        item.set(property, val);
    }
}
function getClassForDueDate(theDate, dueDateLock, completedDate) {
    var cssClass = '';
    var tooltip = '';
    var hasCompletedDate = !isNaN(Date.parse(completedDate)) ? true : false;
    if (dueDateLock !== 1 && !hasCompletedDate) {
        if (theDate) {
            var today = new Date(new Date().toLocaleDateString());
            var weekends = [0, 6];
            var weekOut = new Date();
            weekOut = new Date(weekOut.setDate(weekOut.getDate() + 8));
            theDate = new Date(new Date(theDate).toLocaleDateString());
            if (theDate < today) {
                cssClass = 'standard-red';
                tooltip = 'Task is overdue!';
            } else if (theDate.valueOf() === today.valueOf()) {
                cssClass = 'standard-orange';
                tooltip = 'Task is due today!';
            } else if (weekends.indexOf(theDate.getDay()) > -1) {
                cssClass = 'standard-light-grey';
                tooltip = 'Due date is on a weekend!';
            } else if (theDate > today && theDate < weekOut) {
                cssClass = 'standard-yellow';
                tooltip = 'Task is due in a week!';
            }
        }
    }
    return cssClass;
}

/*
 * Drag/Drop
 */

function makeDraggable() {
    var model = getModelData();
    if (model.IsClientPortal === false && model.CanUserEdit === true && model.UsingATaskLevelFilter() === false) {
        treeList.table.kendoDraggable({
            filter: 'tr[role=row]',
            ignore: 'input, textarea, select',
            hint: function (element) {
                draggedRow = $(element).closest('tr');
                var item = treeList.dataSource.getByUid($(element).attr('data-uid'));
                var row;
                var tbl = $('<table role="grid" id="tbl-hint"></table>');
                if ($(element).hasClass('k-state-selected') === true && treeList.select().length > 1) {
                    $.each(treeList.select(), function () {
                        row = $(this).clone();
                        row.html(row.find('td:lt(5)'));
                        tbl.append(row);
                    });
                } else {
                    row = element.clone();
                    row.html(row.find('td:lt(5)'));
                    tbl.append(row);
                }
                return tbl;
            },
            container: $("#ProjectSchedule"),
            drag: drag,
            dragend: dragEnd,
            dragstart: dragStart,
            cursorOffset: { top: 20, left: 20 }
        });
    }
}
function drag(e) {
    var tRow = $(e.target).closest('tr');
    var currentTargetItem;
    var dropTarget = $('#DropTarget');

    if (tRow.length === 1) {
        targetRow = tRow;
        targetItem = treeList.dataSource.getByUid($(targetRow).attr('data-uid'));
        if (targetRow && targetItem && !targetRow.hasClass('row-moving')) {
            dropTarget.width(targetRow.width());
            dropTarget.height(targetRow.height());
            dropTarget.css('box-sizing', 'border-box');
            dropTarget.css('line-height', dropTarget.height() + 'px');
            dropTarget.offset(targetRow.offset());
            //if (targetItem.id !== draggedItem.parentId) {
            //    $('#dropInto').show();
            //} else {
            //    $('#dropInto').hide();
            //}
            dropTarget.show();
        } else {
            dropTarget.hide();
            targetRow = null;
        }
    }
}
function dragEnd(e) {
    $('html').css('cursor', 'default');
    dropTarget.hide();
    draggedRow = null;
    targetRow = null;
    draggedItem = null;
    targetItem = null;
    $(treeList.tbody).find('tr').removeClass('row-moving');
}
function dragStart(e) {
    //var model = getModelData();
    //if (model.UsingATaskLevelFilter() === true) {
    //    e.preventDefault();
    //}
    if (treeList.select().length > 1 && $(draggedRow).hasClass('k-state-selected') === true) { // dragging multiple only when dragging initiated on a selected row
        var selected = treeList.select();
        for (var i = 0; i < selected.length - 1; i++) {
            if (treeList.dataSource.parentNode(treeList.dataItem(selected[i])) !== treeList.dataSource.parentNode(treeList.dataItem(selected[i + 1]))) {
                e.preventDefault();
                return false;
            }
        }
        $.each(treeList.select(), function () {
            flagDragging(treeList.dataItem(this));
        });
        draggedRow = $(treeList.select()[0]);
    } else {
        flagDragging(treeList.dataItem(draggedRow));
    }
    $('html').css('cursor', '-webkit-grabbing');
    draggedItem = treeList.dataSource.getByUid($(draggedRow).attr('data-uid'));
    targetRow = null;
    targetItem = null;
}
function flagDragging(node) {
    if (node) {
        $('tr[data-uid="' + node.uid + '"]').addClass('row-moving');
        $.each(treeList.dataSource.childNodes(node), function () {
            flagDragging(this);
        });
    }
}
function updateItemsOrder(items) {
    var itemArray = [];
    var url = controllerBase + 'UpdateOrder';
    let dfd = $.Deferred();
    var model = getModelData();
    $.each(items, function () {
        itemArray[itemArray.length] = {
            SequenceNumber: this.SequenceNumber,
            ParentTaskSequenceNumber: this.ParentTaskSequenceNumber, //only used when moving hierarchy level!
            JobOrder: this.JobOrder
        };
    });
    var data = {
        JobNumber: model.JobNumber,
        JobComponentNumber: model.JobComponentNumber,
        Items: itemArray
    };
    beginTaskListRefresh();
    $.post({
        url: url,
        dataType: 'json',
        data: data
    }).always(function () {
        $('.col-cont-wrap').html();
        draggedRow = null;
        targetRow = null;
        draggedItem = null;
        targetItem = null;
        treeList.dataSource.read().always(function () {
            endTaskListRefresh();

            dfd.resolve();
        });
    });

    return dfd;
}
function dropAbove(e) {
    doDrop(e, 1);
}
function dropBelow(e) {
    doDrop(e, -1);
}
function dropInto(e) {
    doDrop(e, 0);
}
function moveRight(e) {
    var model = getModelData();
    var moveDirection = 0;
    if (model.UsingATaskLevelFilter() === false) {
        if (setSave()) {
            treeList.dataSource.sync().then(() => {
                draggedRow = $(e).closest('tr');
                draggedItem = treeList.dataSource.getByUid($(draggedRow).attr('data-uid'));
                var itemAbove = treeList.dataSource.at(treeList.dataSource.indexOf(draggedItem) - 1);
                if (itemAbove.ParentTaskSequenceNumber !== draggedItem.ParentTaskSequenceNumber) {
                    moveDirection = -1;
                }
                targetItem = itemAbove;
                targetRow = $('tr[data-uid=' + targetItem.uid + ']').closest('tr');
                doDrop(e, moveDirection);
            });
        }
        else {
            draggedRow = $(e).closest('tr');
            draggedItem = treeList.dataSource.getByUid($(draggedRow).attr('data-uid'));
            var itemAbove = treeList.dataSource.at(treeList.dataSource.indexOf(draggedItem) - 1);
            if (itemAbove.ParentTaskSequenceNumber !== draggedItem.ParentTaskSequenceNumber) {
                moveDirection = -1;
            }
            targetItem = itemAbove;
            targetRow = $('tr[data-uid=' + targetItem.uid + ']').closest('tr');
            doDrop(e, moveDirection);
        }
    } else {
        showKendoAlert("Indenting is not allowed when using a task level filter.");
    }
}
function moveLeft(e) {
    var model = getModelData();
    if (model.UsingATaskLevelFilter() === false) {
        if (setSave()) {
            treeList.dataSource.sync().then(() => {
                draggedRow = $(e).closest('tr');
                draggedItem = treeList.dataSource.getByUid($(draggedRow).attr('data-uid'));
                var parentNode = treeList.dataSource.parentNode(draggedItem);
                var levelNodes = [];
                var itemAbove;
                if (parentNode) {
                    targetItem = parentNode;
                    targetRow = $('tr[data-uid=' + targetItem.uid + ']').closest('tr');
                    doDrop(e, -1);
                }
            });
        }
        else {
            draggedRow = $(e).closest('tr');
            draggedItem = treeList.dataSource.getByUid($(draggedRow).attr('data-uid'));
            var parentNode = treeList.dataSource.parentNode(draggedItem);
            var levelNodes = [];
            var itemAbove;
            if (parentNode) {
                targetItem = parentNode;
                targetRow = $('tr[data-uid=' + targetItem.uid + ']').closest('tr');
                doDrop(e, -1);
            }
        }
    } else {
        showKendoAlert("Indenting is not allowed when using a task level filter.");
    }

}
function beginTaskListRefresh() {
    kendo.ui.progress(treeList.element, true);
    saveExpanded();
}
function endTaskListRefresh() {
    kendo.ui.progress(treeList.element, false);
    setExpanded();
}
var refreshTimeout;

// 1: Above
// 0: Into
// -1: Below
function doDrop(e, direction) {

    var allItems = treeList.dataSource.view().slice(0);
    var indexOfDragged = treeList.dataSource.indexOf(draggedItem);
    var indexOfTarget = treeList.dataSource.indexOf(targetItem);
    var lastItemUnderDragged = indexOfDragged;
    var itemsToMove = [];
    var orderedItems = [];
    var model = getModelData();
    var draggedItems = [];

    if (treeList.select().length > 1 && $('tr[data-uid="' + draggedItem.uid + '"]').hasClass('k-state-selected')) {
        $.each(treeList.select(), function () {
            draggedItems.push(treeList.dataItem(this));
        });
    } else {
        draggedItems.push(draggedItem);
    }

    //for (var i = (indexOfDragged + 1) ; i < allItems.length; i++) {
    //    var item = allItems[i];
    //    if (treeList.dataSource.level(item) > treeList.dataSource.level(draggedItem)) {
    //        lastItemUnderDragged = treeList.dataSource.indexOf(item);
    //    } else {
    //        break;
    //    }
    //}

    //itemsToMove = allItems.slice(indexOfDragged, lastItemUnderDragged + 1);
    itemsToMove = draggedItems;

    if (draggedItem.parentId !== targetItem.parentId) {
        $.each(draggedItems, function () {
            this.ParentTaskSequenceNumber = targetItem.parentId;
            if (this.ParentTaskSequenceNumber === null) {
                this.ParentTaskSequenceNumber = -1;
            }
        });
    }
    if (direction === 0) {
        $.each(draggedItems, function () {
            this.ParentTaskSequenceNumber = targetItem.SequenceNumber;
        });
        targetItem.expanded = true;
    }
    if (model.CalculateByPredecessor === false) {
        var orderAbove, orderBelow;
        if (direction === 1) {
            if (indexOfTarget > 0) {
                orderAbove = allItems[indexOfTarget - 1].JobOrder;
            }
            orderBelow = allItems[indexOfTarget].JobOrder;
        } else if (direction === -1) {
            orderAbove = allItems[indexOfTarget].JobOrder;
            if (indexOfTarget < allItems.length - 1) {
                orderBelow = allItems[indexOfTarget + 1].JobOrder;
            }
        }
        $.each(draggedItems, function () {
            if (!isNaN(orderAbove)) {
                this.JobOrder = orderAbove;
            } else {
                this.JobOrder = orderBelow;
            }
        });
    }

    for (i = 0; i < allItems.length; i++) {
        if (i === indexOfTarget) {
            if (direction === 0 || direction === -1) {
                orderedItems[orderedItems.length] = allItems[i];
            }
            orderedItems = orderedItems.concat(itemsToMove);
            if (direction === 1) {
                orderedItems[orderedItems.length] = allItems[i];
            }
        } else if (itemsToMove.indexOf(allItems[i]) < 0) {
            orderedItems[orderedItems.length] = allItems[i];
        }
    }
    updateItemsOrder(orderedItems);
}
function isTargetAChild(target) {
    var isChild = false;
    if (target.parentId === draggedItem.id) {
        isChild = true;
    } else {
        var parentNode = treeList.dataSource.parentNode(target);
        if (parentNode) {
            isChild = isTargetAChild(parentNode);
        }
    }
    return isChild;
}
function lookup(element, type) {
    var jqElement = $(element);
    var url, onClose;
    if (type === 'TaskCode' || type === 'QuickAddTaskCode') {
        item = treeList.dataSource.getByUid(jqElement.closest('tr').attr('data-uid'));
        url = controllerBase + 'LookupTasks';
        onClose = function (selectedItem) {
            if (selectedItem) {
                jqElement.val(selectedItem['Code']);
                if (type === 'TaskCode') {
                    updateTask(element, element.name);
                } else if (type === 'QuickAddTaskCode') {
                    $('#QuickAddTaskDescription').val(selectedItem['Description']);
                }
            }
        };
    } else if (type === 'Status') {
        url = controllerBase + 'LookupStatus';
        onClose = function (selectedItem) {
            if (selectedItem) {
                jqElement.val(selectedItem.Code);
                $('#JobTraffic_Traffic_Description').val(selectedItem.Description);
                validator.validateInput(element);
                jqElement.change(); //fires autosave
            }
        };
    } else if (type === 'Employee') {
        url = controllerBase + 'LookupEmployees';
        onClose = function (selectedItem) {
            if (selectedItem) {
                jqElement.attr('picked', '');
                jqElement.val(selectedItem['Code']);
                fillAssignmentName(element, selectedItem['FullName']);
                validator.validateInput(element);
                jqElement.change(); //fires autosave
            }
        };
    } else if (type === 'TrafficPhaseID') {
        url = controllerBase + 'LookupPhases';
        onClose = function (selectedItem) {
            if (selectedItem) {
                jqElement.attr('picked', '');
                jqElement.val(selectedItem['CodeAndDescription']);
                jqElement.attr('tpid', selectedItem['Code']);
                validator.validateInput(element);
                jqElement.change(); //fires autosave
            }
        };
    } else if (type === 'EstimateFunction') {
        url = controllerBase + 'LookupFunctions';
        onClose = function (selectedItem) {
            if (selectedItem) {
                jqElement.attr('picked', '');
                jqElement.val(selectedItem['Code']);
                validator.validateInput(element);
                jqElement.change(); //fires autosave
            }
        };
    }
    if (url) {
        openRadWindowLookupWithEvents(url, onClose);
    }
}
function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {
    OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);
    //setTimeout(function () {
    //    var win = GetRadWindow().BrowserWindow.FindWindow(url);
    //    if (win) {
    //        win.add_close(onCloseCallback);
    //    }
    //}, 500);
}
function OpenRadWindowLookup(url, onCloseCallback) {

    let Dialog = $("#LookUpDlgDiv");

    if (typeof Dialog !== 'undefined' && Dialog.length) {
        $("#LookUpDlgDiv").remove();
        Dialog = $('<div id="LookUpDlgDiv"></div>');
    }
    else {
        Dialog = $('<div id="LookUpDlgDiv"></div>');
    }

    var Title = '';

    Dialog.ejDialog({
        autoOpen: false,
        modal: true,
        height: 700,
        width: 625,
        title: "Lookup" + Title,
        enableResize: true,
        contentUrl: url,
        contentType: "iframe"
    });

    var iFrame = Dialog[0].ownerDocument.getElementsByClassName('e-iframe')[0];

    iFrame.contentWindow.Close = function (selectedItem) {

        if (onCloseCallback) {
            onCloseCallback(selectedItem);
        }

        Dialog.ejDialog('close');
    };
}
function openRadWindowLookupWithEvents(url, onCloseCallback) {
    OpenRadWindowLookup(url, onCloseCallback);
}
function addQuickTask(row, direction) {
    var index;
    var parentSeq = null;
    var newTask = {};
    var model = getModelData();
    var defaults = $.data($('#QuickAddTaskCode')[0], 'defaults');
    newTask.JobNumber = model.JobNumber;
    newTask.JobComponentNumber = model.JobComponentNumber;
    newTask.TaskCode = null; //$('#QuickAddTaskCode').val();
    newTask.TaskDescription = 'blank'; //$('#QuickAddTaskDescription').val();
    if (newTask.TaskCode !== '' || newTask.TaskDescription !== '') {
        if (row) {
            var dataItem = treeList.dataItem(row);
            var itemAboveOrBelow, jobOrder;
            index = treeList.dataSource.indexOf(treeList.dataItem(row));
            parentSeq = dataItem.ParentTaskSequenceNumber;
            jobOrder = dataItem.JobOrder;
            if (direction === -1) {
                index += 1;
                if (treeList.dataSource.view().length > index) {
                    itemAboveOrBelow = treeList.dataSource.at(index);
                    if ($.isNumeric(dataItem.JobOrder) && $.isNumeric(itemAboveOrBelow.JobOrder) &&
                        itemAboveOrBelow.JobOrder - dataItem.JobOrder >= 2) {
                        jobOrder = dataItem.JobOrder + 1;
                    } else {
                        index -= 1;
                    }
                }
            } else if (direction === 0) {
                index += 1;
                parentSeq = dataItem.SequenceNumber;
            } else if (direction === 1) {
                if (index > 0) {
                    itemAboveOrBelow = treeList.dataSource.at(index - 1);
                    if ($.isNumeric(dataItem.JobOrder) && $.isNumeric(itemAboveOrBelow.JobOrder) &&
                        dataItem.JobOrder - itemAboveOrBelow.JobOrder >= 2) {
                        jobOrder = dataItem.JobOrder - 1;
                    } else {
                        index -= 1;
                    }
                }
            }
            newTask.JobOrder = jobOrder;
            newTask.ParentTaskSequenceNumber = parentSeq;
            newTask.GridOrder = index + 1;
            treeList.dataSource.insert(index, newTask);
        } else {
            if (defaults) {
                newTask.JobOrder = defaults.JobOrder;
            }
            treeList.dataSource.add(newTask);
        }
        //var kendoWindow = $('#QuickAddTaskWindow').data('kendoWindow');
        //kendoWindow.close();
    } else {
        showKendoAlert('Please enter a task code or description');
    }
}
function QuickAddTaskWindowOpen(e) {
    var taskWindow = e.sender;
    var windowHeight = $(window).outerHeight();
    var parentWidth = $('body').width();
    var left = (parentWidth - 600) / 2;
    var top = (windowHeight - 200) / 2;
    top += $(window).scrollTop();
    taskWindow.setOptions({
        position: {
            top: top,
            left: left
        }
    });
}
function QuickAddTaskWindowClose(e) {
    $('#QuickAddTaskCode').val('');
    $('#QuickAddTaskDescription').val('');
}
function showQuickAddTaskWindow(items) {
    var allowAboveAndBelow = false;
    var allowInto = false;
    if (items) {
        if ($(items).length > 0) {
            allowAboveAndBelow = true;
            allowInto = true;
            if ($(items).length > 1) {
                allowInto = false;
            }
        }
    }
    openQuickAddTaskWindow(items, true, allowAboveAndBelow, allowInto, allowAboveAndBelow);
}
function openQuickAddTaskWindow(items, add, above, into, below) {
    var taskWindow = $('#QuickAddTaskWindow').data('kendoWindow');
    $('#QuickAdd').unbind('click');
    $('#QuickAddBelow').unbind('click');
    $('#QuickAddAbove').unbind('click');
    $('#QuickAddInto').unbind('click');
    if (add === true) {
        $('#QuickAdd').click(function () {
            addQuickTask(items[items.length - 1], -1);
        });
        $('#QuickAdd').show();
    } else {
        $('#QuickAdd').hide();
    }
    if (above === true) {
        $('#QuickAddAbove').click(function () {
            addQuickTask(items[items.length - 1], 1);
        });
        $('#QuickAddAbove').show();
    } else {
        $('#QuickAddAbove').hide();
    }
    if (into === true) {
        $('#QuickAddInto').click(function () {
            addQuickTask(items[items.length - 1], 0);
        });
        $('#QuickAddInto').show();
    } else {
        $('#QuickAddInto').hide();
    }
    if (below === true) {
        $('#QuickAddBelow').click(function () {
            addQuickTask(items[items.length - 1], -1);
        });
        $('#QuickAddBelow').show();
    } else {
        $('#QuickAddBelow').hide();
    }
    taskWindow.center();
    taskWindow.open();
}
function QuickAddTaskButtonClick() {
    showQuickAddTaskWindow(treeList.select());
}
function fillAssignmentName(codeInput, name) {
    $(codeInput).parent().find('.assignment-name').val(name);
};
function validatePredecessors(item, predecessorSequenceNumbers, onSuccess, onFail) {
    if (predecessorSequenceNumbers && predecessorSequenceNumbers.length > 0) {
        $.post({
            url: controllerBase + 'ValidatePredecessors',
            dataType: 'json',
            data: { JobNumber: item.JobNumber, JobComponentNumber: item.JobComponentNumber, SequenceNumber: item.SequenceNumber, PredecessorSequenceNumbers: predecessorSequenceNumbers }
        }).always(function (response) {
            if (response.Success === true) {
                onSuccess();
            } else {
                showKendoAlert(response.Message);
                onFail();
            }
        });
    } else {
        onSuccess();
    }
}

$('body').on('change', 'input.ps-update, textarea.ps-update', function () {
    if (this.name === 'PredecessorLevelNotation') {
        var input = this;
        var levels = [];
        var preds = [];
        var item = treeList.dataItem($(this).closest('tr'));
        $.each($(this).val().split(","), function () {
            levels.push(this.replace(/\s+/g, ''));
        });
        if (levels.length > 0) {
            $.each(treeList.dataSource.view(), function () {
                if (levels.indexOf(this.Level) > -1) {
                    preds.push(this.SequenceNumber);
                }
            });
            validatePredecessors(item, preds, function () {
                item.set('PredecessorSequenceNumbers', preds);
            }, function () {
                $(input).val(item.PredecessorLevelNotation);
            });
        } else {
            updateTask(this, this.name);
        }

    } else {
        updateTask(this, this.name);
    }
}).on('mouseover', '.div-btn', function () {
    $(this).addClass('k-primary');
}).on('mouseout', '.div-btn', function () {
    $(this).removeClass('k-primary');
}).on('click', 'input[name^="JobCompletedDate"]', function () {
    var mydate = new Date();
    $(this).val(kendo.toString(mydate, 'd'));
    updateTask(this, 'JobCompletedDate');
}).on('change', 'input[name="IsMilestone"]', function () {
    updateTask(this, 'Milestone');
}).on('change', 'input[name="DueDateLock"]', function () {
    updateTask(this, 'DueDateLock');
}).on('dblclick', 'input[name="TaskCode"], input[name="QuickAddTaskCode"], input[name="EstimateFunction"], input[name="TrafficPhaseID"]', function () {
    lookup(this, this.name);
}).on('change', 'input[name="QuickAddTaskCode"]', function () {
    $(this).data('');
    validator.validateInput(this);
}).on('validated', 'input[name="QuickAddTaskCode"]', function (e) {
    var desc;
    var order;
    if (e.isValid === true) {
        if (e.results) {
            if (e.results.Data) {
                desc = e.results.Data.Description;
                order = e.results.Data.Order;
            }
        }
        $('#QuickAddTaskDescription').val(desc);
    }
    $.data(this, 'defaults', { JobOrder: order });
}).on('change', 'input[name="QuickAddTaskDescription"]', function () {
    $('#QuickAddTaskCode').val('');
    if ($(this).val()) {
        lookupEntity({ Type: 'Task', EntityDescription: $(this).val() }, function (response) {
            if (response.Data) {
                $('#QuickAddTaskCode').val(response.Data.Code);
            }
        }, function () {
            //fail
        });
    }
}).on('dblclick', 'input.assignment', function () {
    lookup(this, 'Employee');
}).on('change', 'input.assignment', function () {
    validator.validateInput(this);
}).on('validated', 'input.assignment', function (e) {
    var name;
    if (e.isValid === true) {
        if (e.results) {
            if (e.results.Data) {
                name = e.results.Data.Name;
            }
        }
        fillAssignmentName(this, name);
    }
}).on('change', '#ProjectSchedule input[name="TaskCode"], #ProjectSchedule input[data-field="TaskStatus"], #ProjectSchedule input[data-field="TrafficPhaseID"], #ProjectSchedule input[name="EstimateFunction"], #ProjectSchedule input[data-shortdate], #ProjectSchedule input[data-field="JobDays"], #ProjectSchedule input[data-field="JobOrder"]', function () {
    validator.validateInput(this);
}).on('change', '#ProjectSchedule input[name="TaskCode"], #ProjectSchedule input[data-field="JobHours"]', function () {
    validator.validateInput(this);
}).on('validated', 'input[data-field="TrafficPhaseID"]', function (e) {
    var phaseID;
    if (e.isValid === true) {
        if (e.results) {
            if (e.results.Data) {
                phaseID = e.results.Data.ID;
                $(this).attr('tpid', phaseID);
            }
        }
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set('TrafficPhaseID', $(this).attr('tpid'));
    }
}).on('validated', 'input[name="TaskCode"]', function (e) {
    var taskDesc;
    if (e.isValid === true) {
        if (e.results) {
            if (e.results.Data) {
                taskDesc = e.results.Data.Description;
            }
        }
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set('TaskCode', $(this).val());
    }
}).on('validated', 'input[data-field="TaskStatus"]', function (e) {
    var taskDesc;
    if (e.isValid === true) {
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        $(this).val(e.results.Description);
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set('TaskStatus', e.results.Code);
    }
}).on('validated', 'input[name="EstimateFunction"]', function (e) {
    if (e.isValid === true) {
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set('EstimateFunction', $(this).val());
    }
}).on('validated', '#ProjectSchedule input[data-shortdate], #ProjectSchedule input[data-field="JobDays"], #ProjectSchedule input[data-field="JobOrder"]', function (e) {
    if (e.isValid === true) {
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set($(this).data('field'), $(this).val());
    }
}).on('validated', '#ProjectSchedule input[data-field="JobHours"]', function (e) {
    if (e.isValid === true) {
        var dataItem = treeList.dataSource.getByUid($(this).closest('tr').attr('data-uid'));
        if (!dataItem.PredecessorSequenceNumbers) {
            dataItem.PredecessorSequenceNumbers = [];
        }
        dataItem.set($(this).data('field'), $(this).val());

        treeList.dataSource.read();
    }
}).on('click', '.shared-calendar-picker .addon-btn', function (e) {
    var calendar = $('#calendar-popup').data('kendoCalendar');
    if (!calendar) {
        calendar = $('#calendar-popup').kendoCalendar().data('kendoCalendar');
    }
    var current = this;
    var open = !$(current).hasClass('calendar-active') && !$(this).siblings('input').is(':disabled');
    closeCalendarPopup();
    if (open === true) {
        $(current).addClass('calendar-active');
        var dateInput = $(current).closest('td').find('input');
        var offset = $(dateInput).offset();
        $('#calendar-popup').show();
        $('#calendar-popup').offset({ left: offset.left, top: offset.top + $(dateInput).outerHeight() });
        calendar.bind('change', function () {
            var val = this.value();
            $(dateInput).val(kendo.toString(val, 'd'));
            $(dateInput).change();
            closeCalendarPopup();
        });
        setTimeout(function () {
            $(window).on('click', closeCalendarPopup);
        }, 100);
    }
}).on('click', '.shared-combo .addon-btn', function (e) {
    var current = this;
    var open = !$(current).hasClass('status-dd-active') && !$(this).siblings('input').is(':disabled');
    closeStatusPopup();
    if (open === true) {
        $(current).addClass('status-dd-active');
        var statusInput = $(this).closest('td').find('input');
        var offset = $(statusInput).offset();
        $('#status-popup').show();
        $('#status-popup').offset({ left: offset.left, top: offset.top + $(statusInput).outerHeight() });
        $('#status-popup a').bind('click', function () {
            $(statusInput).val($(this).text());
            $(statusInput).change();
            closeStatusPopup();
        });
        setTimeout(function () {
            $(window).on('click', closeStatusPopup);
        }, 100);
    }
});
function closeCalendarPopup() {
    var calendar = $('#calendar-popup').data('kendoCalendar');
    $('.shared-calendar-picker .addon-btn.calendar-active').removeClass('calendar-active');
    $('#calendar-popup').hide();
    calendar.value(null);
    $(window).unbind('click', closeCalendarPopup);
    calendar.unbind('change');
}
function closeStatusPopup() {
    var statusList = $('#status-popup');
    $('.shared-combo .addon-btn.status-dd-active').removeClass('status-dd-active');
    $('#status-popup').hide();
    $(window).unbind('click', closeStatusPopup);
    $('#status-popup a').unbind('click');
}
function renderDatePicker(name, itemDate, isDisabled, cssClass) {
    return kendo.Template.compile($('\\#datePickerTemplate2').html())({});
}

