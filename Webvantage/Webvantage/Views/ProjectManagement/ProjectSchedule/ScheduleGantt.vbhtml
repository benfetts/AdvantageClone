@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
    .k-gantt-actions .k-button {
        visibility: hidden;
    }

    .k-gantt-layout + .k-gantt-toolbar {
        visibility: hidden;
    }

    .kill-footer {
        display: none;
        height: 0px;
        border-bottom-width: 0px;
        visibility: hidden;
    }

    .k-task-pct {
        font-size: 14px;
    }

    .k-gantt-treelist .k-grid-header tr {
        height: 70px;
    }

    .k-grid-header {
        white-space: nowrap;
    }

    .k-grid .k-grid-header .k-header {
        white-space: nowrap;
    }

    /*.k-marquee.k-gantt-marquee {
        display: none !important;
        visibility: hidden !important;
    }*/
</style>

@*<span id="target"></span>*@

<div id="ganttwrapper" style="width:100%;height:100%">
    <div id="gantt"></div>
</div>

<script>
    var DependencyDataSource;
    var ScheduleGanttDataSource;
    var gantt;
    var ganttTaskUpdate = false;

    $(() => {
        let me = this;

        ScheduleGanttDataSource = new kendo.data.GanttDataSource({
            transport: {
                read: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/ReadGanttTask")",
                    dataType: "json",
                    data: (e) => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber,
                            Sort: CalculateByPredecessor ? '' : 'order',
                            Gantt: 1
                        }
                    }
                },
                update: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/UpdateGanttTask")",
                    dataType: "json",
                    data: (e) => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber
                        };
                    }
                },
                destroy: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/DeleteTask")",
                    dataType: "json",
                    data: (e) => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber,
                            SequenceNumber: e.SequenceNumber
                        };
                    }
                },
                create: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/CreateGanttTask")",
                    dataType: "jsonp",
                    data: (e) => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber,
                            SequenceNumber: e.SequenceNumber
                        };
                    }
                },
                parameterMap: function (data, type) {
                    // if type is "read", then data is { foo: 1 }, we also want to add { "bar": 2 }
                    if (type == 'update') {
                        if (data.TaskStartDate) {
                            data.TaskStartDate = data.TaskStartDate.toDateString();
                        }
                        if (data.JobRevisedDate) {
                            data.JobRevisedDate = data.JobRevisedDate.toDateString();
                        }
                    }
                    else if (type === 'create') {
                    }

                    return data;
                }
            },
            requestEnd: function (e) {
                var response = e.response;
                var type = e.type;

                if (e.type === 'destroy') {
                    if (e.response.Message && e.response.Message != '') {
                        showKendoAlert(e.response.Message);
                        e.preventDefault(true);
                        ScheduleGanttDataSource.read().then(() => {
                            //expandAll();
                        });
                    }
                }
                else if (e.type === 'create') {
                }
                else if (e.type === 'read') {
                    $.each(e.response, (i, v) => {
                        if (v.TaskStartDate && v.TaskStartDate == v.JobRevisedDate) {
                            var date = new Date(parseInt(v.JobRevisedDate.substr(6)));

                            date.setHours(23);
                            date.setMinutes(59);
                            date.setSeconds(59);

                            e.response[i].JobRevisedDate = date;
                        }
                    });

                    //console.log(e);
                }

                $("#gantt").data('kendoGantt').refresh();
            },
            serverFiltering: true,
            schema: {
                model: {
                    id: "id",
                    fields: {
                        id: { from: "SequenceNumber", type: "number", validation: { required: true } },
                        GridOrder: { from: 'GridOrder', type: 'number' },
                        JobDays: { from: 'JobDays', type: 'number' },
                        DispersedHours: { from: 'DispersedHours', type: 'number', editable: false },
                        orderId: { from: 'GridOrder', type: 'number', validation: { required: true } },
                        Level: { from: 'Level', type: 'string' },
                        JobCompletedDate: { from:"JobCompletedDate", type: "date"},
                        //HasChildren: { from: "HasChildren", type: "boolean" },
                        PredecessorLevelNotation: { from: 'PredecessorLevelNotation', type: 'string' },
                        parentId: { from: "ParentTaskSequenceNumber", type: "number", defaultValue: null, validation: { required: true } },
                        summary: { from: "HasChildren", type: "boolean" },
                        percentComplete: { from: "PercentComplete", type: "number", editable: false },
                        start: { from: "TaskStartDate", type: "date" },
                        end: { from: "JobRevisedDate", type: "date" },
                        title: { from: "TaskDescription", type: 'string' },
                        expanded: { from: "Expanded", type: "boolean", defaultValue: false }
                    }
                }
            },
            sort: {
                field: 'GridOrder'
                , dir: "asc"
            }
        });

        DependencyDataSource = new kendo.data.GanttDependencyDataSource({
            transport: {
                read: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/GanttDependencies")",
                    dataType: "json",
                    data: () => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber
                        }
                    }
                },
                update: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/UpdateGanttDependencies")",
                    dataType: "json"
                },
                destroy: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/DestroyGanttDependencies")",
                    dataType: "json"
                },
                create: {
                    url: "@Href("~/ProjectManagement/ProjectSchedule/CreateGanttDependencies")",
                    dataType: "json",
                    data: () => {
                        return {
                            JobNumber: @Model.JobNumber,
                            JobComponentNumber: @Model.JobComponentNumber
                        }
                    }
                }
            },
            schema: {
                model: {
                    id: "id",
                    fields: {
                        id: { from: "ID", type: "number" },
                        predecessorId: { from: "PredecessorID", type: "number" },
                        successorId: { from: "SuccessorID", type: "number" },
                        type: { from: "Type", type: "number" }
                    }
                }
            }
        });

        $('#refreshProjectSchedule').on('click', refreshGantt);
        $('#saveButton').on('click', saveGanttClick);

        $("#ganttwrapper").kendoTooltip({
            filter: ".k-gantt-treelist .k-grid-content td",
            content: function (e) {
                // pass the task data as content for the Tooltip
                return "<strong>" + e.target[0].innerText + "</strong>"
            },
            position: "bottom"
        });
        
    });

    var currentCalculateByPredecessor = -1;

    function CalculateByPredecessorChangeGantt(CalculateByPredecessor) {

        if (currentCalculateByPredecessor == CalculateByPredecessor) {
            return;
        }

        currentCalculateByPredecessor = CalculateByPredecessor;

        var gantt = $("#gantt").data('kendoGantt');

        if (gantt) {
            gantt.destroy();
            $("#gantt").remove();
            $("#ganttwrapper").append('<div id="gantt"></div>');
        }

        if (CalculateByPredecessor) {
            $("#gantt").kendoGantt({
                dataSource: ScheduleGanttDataSource,
                dependencies: DependencyDataSource,
                dataBound: onDataBound,
                save: (e) => {
                    console.log('save', e);
                    ganttTaskUpdate = true;
                },
                snap: false,
                resizable: false,
                resizeTooltipFormat: "MM/dd/yyyy",
                add: function (e) {
                    if (e.dependency && CalculateByPredecessor) {
                        if (e.dependency && e.dependency.type != 1) {
                            e.preventDefault(true);
                            showKendoAlert("Dependancies can only be setup so that the start of one Task is dependent on the end of another Task!");
                        }
                        else {
                            //check to see if dependancy already exists
                            var gantt = $("#gantt").data('kendoGantt');
                            var data = gantt.dataSource.data();
                            var pred = data.find(x => x.id === e.dependency.predecessorId);
                            var successor = data.find(x => x.id === e.dependency.successorId);
                            var predstring = successor.PredecessorLevelNotation;

                            if (!pred.summary && !successor.summary && predstring !== pred.Level && predstring.indexOf(pred.Level + ", ") < 0 && predstring.indexOf(', ' + pred.Level) < 0) {

                                if (predstring === '') {
                                    successor.set('PredecessorLevelNotation', pred.Level);
                                }
                                else {
                                    predstring += ', ' + pred.Level;
                                    successor.set('PredecessorLevelNotation', predstring);
                                }
                            }
                            else {
                                //just act happy if it exists
                                e.preventDefault(true);
                            }
                        }
                    }
                    else if (e.dependency) {
                        e.preventDefault(true);
                    }
                },
                resize: (e) => {
                    if (e.task) {
                        if (!e.task.JobCompletedDate) {
                            if (e.task) {
                                e.task.JobDays = calcBusinessDays(e.start, e.end);
                            }
                        }
                        else {
                            e.preventDefault();
                        }
                    }
                },
                resizeEnd: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                move: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                moveEnd: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                change: (e) => {
                    var gantt = $("#gantt").data("kendoGantt");
                    var selected = gantt.select();

                    if (selected.length === 1) {
                        var item = gantt.dataItem(selected[0]);
                        if (!item.HasChildren) {
                            $('#taskDetailButton').removeClass('k-state-disabled');
                        }
                        else {
                            $('#taskDetailButton').addClass('k-state-disabled');
                        }
                    }
                    else {
                        $('#taskDetailButton').addClass('k-state-disabled');
                    }

                    if (selected.length > 0) {
                        $('#deleteTaskBtn').removeClass('k-state-disabled');
                        //$('#copyButton').removeClass('k-state-disabled');
                    }
                    else {
                        $('#deleteTaskBtn').addClass('k-state-disabled');
                        $('#copyButton').addClass('k-state-disabled');
                    }

                },
                editable: {
                    confirmation: false,
                    create: false,
                    destroy: true,
                    dependencyDestroy: true,
                    template: '	<div class="k-edit-label"><label for="title">Task Description</label></div>' +
                        '<div data-container-for="title" class="k-edit-field"> <input type="text" class="k-input k-textbox" name="title" title="Title" data-bind="value:title"></div>' +
                        '<div class="k-edit-label"><label for="start">Start</label></div>' +
                        '<div data-container-for="start" class="k-edit-field">' +
                        '<input name="selectedDate" type="date" data-bind="value:start" data-format="MM/dd/yyyy" data-role="datepicker" />' +
                        '</div>' +
                        '<div class="k-edit-label"><label for="end">End</label></div>' +
                        '<div data-container-for="end" class="k-edit-field">' +
                        '<input type="text" required="" data-type="date" data-role="datepicker" data-bind="value:end" data-validate="true" name="end" title="End" data-datecompare-msg="End date should be after or equal to the start date" class="k-input" role="combobox" aria-expanded="false" autocomplete="off" aria-disabled="false">' +
                        '</div>'
                },
                tooltip: {
                    visible: true,
                    template: '<div class="k-task-content">' +
                        '<div class="k-task-details" ><strong>#= task.title #</strong>' +
                        '<div class="k-reset">#= task.percentComplete # % Complete</div>' +
                        '<ul class="k-reset">' +
                        '<li>Start Date: #=kendo.toString(task.start,"MM/dd/yyyy")#</li>' +
                        '<li>Due Date: #=kendo.toString(task.end,"MM/dd/yyyy")#</li>' +
                        ' #if(task.JobCompletedDate==null)' +
                        '{#<li>Completed Date:</li>#}' +
                        'else{#<li>Completed Date: #=kendo.toString(task.JobCompletedDate,"MM/dd/yyyy")#</li>#}#' +
                        ' #if(task.JobDays==null)' +
                        '{#<li>Days:</li>#}' +
                        'else{#<li>Days: #= task.JobDays#</li>#}#' +
                        ' #if(task.DispersedHours==null)' +
                        '{#<li>Hours:</li>#}' +
                        'else{#<li>Hours: #=task.DispersedHours#</li>#}#' +
                        '</ul></div></div>'
                },
                remove: (e) => {
                    if (e.task) {
                        e.preventDefault(true);
                        showKendoConfirm("<p>Are you sure you want to delete selected row(s)?<p>")
                            .done(function () {
                                var gantt = $("#gantt").data("kendoGantt");
                                var task = e.task;
                                try {
                                    gantt.dataSource.remove(task);
                                }
                                catch (ex) {
                                }


                                if (gantt.dataSource._destroyed.length < 1) {
                                    gantt.dataSource._destroyed.push(e.task);
                                }

                                gantt.dataSource.sync().then(() => {
                                    setSave();
                                });
                            });
                    }
                    else {
                        var gantt = $("#gantt").data('kendoGantt');
                        var data = gantt.dataSource.data();
                        var pred = data.find(x => x.id === e.dependencies[0].predecessorId);
                        var successor = data.find(x => x.id === e.dependencies[0].successorId);
                        var predstring = successor.PredecessorLevelNotation;

                        if (predstring !== pred.Level) {
                            var temp = predstring.replace(pred.Level + ', ', '');

                            if (temp === predstring) {
                                temp = predstring.replace(', ' + pred.Level, '');
                            }

                            predstring = temp;
                        }
                        else {
                            predstring = '';
                        }
                        successor.set('PredecessorLevelNotation', predstring);
                    }
                },
                height: '100%',
                views: [
                    "day",
                    { type: "week", selected: true },
                    "month"
                ],
                columns: [
                    { field: "title", title: "Level", template: '<span> # Level # </span>', width: 100, editable: false, sortable: false },
                    { field: "id", title: "Task Description", width: 180, template: '<span> # title # </span>' },
                    { field: "JobDays", title: "Days", width: 50, editable: false, sortable: false },
                    { field: "DispersedHours", title: "Hours", width: 50, editable: false, sortable: false },
                    { field: "start", title: "Start Date", format: "{0:MM/dd/yyyy}", width: 100, editable: true, sortable: false },
                    { field: "end", title: "End Date", format: "{0:MM/dd/yyyy}", width: 100, editable: true, sortable: false },
                    { field: "JobCompletedDate", title: "Completed Date", format: "{0:MM/dd/yyyy}", width: 115, editable: false, sortable: false },
                    { field: "PredecessorLevelNotation", title: "Predecessors", width: 100, editable: false, sortable: false }
                ],
                navigate: function (e) {
                    saveSettingGantt('GANTT_VIEW', e.view);
                    //console.log(kendo.format("Navigate to {0} view", e.view.charAt(0).toUpperCase() + e.view.slice(1)));
                }
            }).data('kendoGantt');

            $('.k-gantt-layout.k-gantt-treelist').width(585);
            $('#gantt').data('kendoGantt').resize();
        }
        else {
            $("#gantt").kendoGantt({
                dataSource: ScheduleGanttDataSource,
                dataBound: onDataBound,
                snap: false,
                resizable: false,
                resizeTooltipFormat: "MM/dd/yyyy",
                save: (e) => {
                    console.log('save', e);
                    ganttTaskUpdate = true;
                },
                add: function (e) {
                    //make sure we can't add dependency to an order gantt
                    if (e.dependency) {
                        e.preventDefault(true);
                    }
                },
                resize: (e) => {
                    if (e.task) {
                        if (!e.task.JobCompletedDate) {
                            if (e.task) {
                                e.task.JobDays = calcBusinessDays(e.start, e.end);
                            }
                        }
                        else {
                            e.preventDefault();
                        }
                    }
                },
                resizeEnd: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                move: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                moveEnd: (e) => {
                    if (e.task) {
                        if (e.task.JobCompletedDate) {
                            e.preventDefault();
                        }
                    }
                },
                change: (e) => {
                    var gantt = $("#gantt").data("kendoGantt");
                    var selected = gantt.select();

                    if (selected.length === 1) {
                        var item = gantt.dataItem(selected[0]);
                        if (!item.HasChildren) {
                            $('#taskDetailButton').removeClass('k-state-disabled');
                        }
                        else {
                            $('#taskDetailButton').addClass('k-state-disabled');
                        }
                    }
                    else {
                        $('#taskDetailButton').addClass('k-state-disabled');
                    }

                    if (selected.length > 0) {
                        $('#deleteTaskBtn').removeClass('k-state-disabled');
                        //$('#copyButton').removeClass('k-state-disabled');
                    }
                    else {
                        $('#deleteTaskBtn').addClass('k-state-disabled');
                        $('#copyButton').addClass('k-state-disabled');
                    }

                },
                editable: {
                    confirmation: false,
                    create: false,
                    destroy: true,
                    dependencyDestroy: true,
                    template: '	<div class="k-edit-label"><label for="title">Task Description</label></div>' +
                        '<div data-container-for="title" class="k-edit-field"> <input type="text" class="k-input k-textbox" name="title" title="Title" data-bind="value:title"></div>' +
                        '<div class="k-edit-label"><label for="start">Start</label></div>' +
                        '<div data-container-for="start" class="k-edit-field">' +
                        '<input name="selectedDate" type="date" data-bind="value:start" data-format="MM/dd/yyyy" data-role="datepicker" />' +
                        '</div>' +
                        '<div class="k-edit-label"><label for="end">End</label></div>' +
                        '<div data-container-for="end" class="k-edit-field">' +
                        '<input type="text" required="" data-type="date" data-role="datepicker" data-bind="value:end" data-validate="true" name="end" title="End" data-datecompare-msg="End date should be after or equal to the start date" class="k-input" role="combobox" aria-expanded="false" autocomplete="off" aria-disabled="false">' +
                        '</div>'
                },
                tooltip: {
                    visible: true,
                    template: '<div class="k-task-content">' +
                        '<div class="k-task-details" ><strong>#= task.title #</strong>' +
                        '<div class="k-reset">#= task.percentComplete # % Complete</div>' +
                        '<ul class="k-reset">' +
                        '<li>Start Date: #=kendo.toString(task.start,"MM/dd/yyyy")#</li>' +
                        '<li>Due Date: #=kendo.toString(task.end,"MM/dd/yyyy")#</li>' +
                        ' #if(task.JobCompletedDate==null)' +
                        '{#<li>Completed Date:</li>#}' +
                        'else{#<li>Completed Date: #=kendo.toString(task.JobCompletedDate,"MM/dd/yyyy")#</li>#}#' +
                        ' #if(task.JobDays==null)' +
                        '{#<li>Days:</li>#}' +
                        'else{#<li>Days: #= task.JobDays#</li>#}#' +
                        ' #if(task.DispersedHours==null)' +
                        '{#<li>Hours:</li>#}' +
                        'else{#<li>Hours: #=task.DispersedHours#</li>#}#' +
                        '</ul></div></div>'
                },
                remove: (e) => {
                    if (e.task) {
                        e.preventDefault(true);
                        showKendoConfirm("<p>Are you sure you want to delete selected row(s)?<p>")
                            .done(function () {
                                var gantt = $("#gantt").data("kendoGantt")
                                gantt.dataSource.remove(e.task);

                                if (gantt.dataSource._destroyed.length < 1) {
                                    gantt.dataSource._destroyed.push(e.task);
                                }

                                gantt.dataSource.sync().then(() => {
                                    setSave();
                                });
                            });
                    }
                    else {
                        var gantt = $("#gantt").data('kendoGantt');
                        var data = gantt.dataSource.data();
                        var pred = data.find(x => x.id === e.dependencies[0].predecessorId);
                        var successor = data.find(x => x.id === e.dependencies[0].successorId);
                        var predstring = successor.PredecessorLevelNotation;

                        if (predstring !== pred.Level) {
                            var temp = predstring.replace(pred.Level + ', ', '');

                            if (temp === predstring) {
                                temp = predstring.replace(', ' + pred.Level, '');
                            }

                            predstring = temp;
                        }
                        else {
                            predstring = '';
                        }
                        successor.set('PredecessorLevelNotation', predstring);
                    }
                },
                height: '100%',
                views: [
                    "day",
                    { type: "week", selected: true },
                    "month"
                ],
                columns: [
                    { field: "title", title: "Level", template: '<span> # Level # </span>', width: 100, editable: false, sortable: false },
                    { field: "id", title: "Task Description", width: 180, template: '<span> # title # </span>' },
                    { field: "JobDays", title: "Days", width: 50, editable: false, sortable: false },
                    { field: "DispersedHours", title: "Hours", width: 50, editable: false, sortable: false },
                    { field: "start", title: "Start Date", format: "{0:MM/dd/yyyy}", width: 100, editable: true, sortable: false },
                    { field: "end", title: "End Date", format: "{0:MM/dd/yyyy}", width: 100, editable: true, sortable: false },
                    { field: "JobCompletedDate", title: "Completed Date", format: "{0:MM/dd/yyyy}", width: 115, editable: false, sortable: false }
                ],
                navigate: function (e) {
                    saveSettingGantt('GANTT_VIEW', e.view);
                    //console.log(kendo.format("Navigate to {0} view", e.view.charAt(0).toUpperCase() + e.view.slice(1)));
                }
            }).data('kendoGantt');

            $('.k-gantt-layout.k-gantt-treelist').width(585);
            $('#gantt').data('kendoGantt').resize();
        }
    }

    function calcBusinessDays(dDate1, dDate2) { // input given as Date objects
        var iWeeks, iDateDiff, iAdjust = 0;
        if (dDate2 < dDate1) return -1; // error code if dates transposed
        var iWeekday1 = dDate1.getDay(); // day of week
        var iWeekday2 = dDate2.getDay();
        iWeekday1 = (iWeekday1 == 0) ? 7 : iWeekday1; // change Sunday from 0 to 7
        iWeekday2 = (iWeekday2 == 0) ? 7 : iWeekday2;
        if ((iWeekday1 > 5) && (iWeekday2 > 5)) iAdjust = 1; // adjustment if both days on weekend
        iWeekday1 = (iWeekday1 > 5) ? 5 : iWeekday1; // only count weekdays
        iWeekday2 = (iWeekday2 > 5) ? 5 : iWeekday2;

        // calculate differnece in weeks (1000mS * 60sec * 60min * 24hrs * 7 days = 604800000)
        iWeeks = Math.floor((dDate2.getTime() - dDate1.getTime()) / 604800000)

        if (iWeekday1 < iWeekday2) { //Equal to makes it reduce 5 days
            iDateDiff = (iWeeks * 5) + (iWeekday2 - iWeekday1)
        } else {
            iDateDiff = ((iWeeks + 1) * 5) - (iWeekday1 - iWeekday2)
        }

        iDateDiff -= iAdjust // take into account both days on weekend

        return (iDateDiff + 1); // add 1 because dates are inclusive
    }
    function saveGanttClick() {

        //setTimeout(() => {
        //}, 1000);
        var gantt = $("#gantt").data("kendoGantt")

        if (ganttTaskUpdate) {
            gantt.dataSource.sync().then(() => {
                taskDeleted = false;
                taskEdited = false;
                taskInserted = false;
                setSave();
                ganttTaskUpdate = false;
                gantt.dataSource.read();
            });
        }
    }

    function saveSettingGantt(code, value) {
        $.post({
            url: window.appBase + '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)UpdateDefaultScheduleSetting',
            data: { SettingCode: code, SettingValue: value }
        }).always(function (response) {

        });
    }
    function getSettingGantt() {
         $.ajax({
            type: "Get",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetGanttView")",
            dataType: "json",
            success: function (response) {

                var gantt = $("#gantt").data("kendoGantt");
                gantt.view(response);

            }
        });
    }


    function expandAll() {
        var gantt = $("#gantt").data("kendoGantt");

        if (gantt) {
            var tasks = gantt.dataSource.view();
            for (i = 0; i < tasks.length; i++) {
                tasks[i].set("expanded", true);
            }
        }
    }

    function collapseAll() {
        var gantt = $("#gantt").data("kendoGantt");

        if (gantt) {
            var tasks = gantt.dataSource.view();
            for (i = 0; i < tasks.length; i++) {
                tasks[i].set("expanded", false);
            }
        }
    }

    function onDataBound(e) {
        var gantt = this;
        var ganttList = e.sender.list;
        var dataItems = ganttList.dataSource.view();
        for (var j = 0; j < dataItems.length; j++) {
            var dataItem = dataItems[j];
            var row = $("[data-uid='" + dataItem.uid + "']");
            row.find("td").eq(0).find("span").each(function (i,e) {
                if (i > 0 && i < row.find("td").eq(0).find("span").length - 1) {
                    $(this).text('   ');
                }
            });
            var span = row.find("td").eq(0).find("span").last();
            span.text(dataItem.Level);
            span = row.find("td").eq(1).find("span").last();
            span.text(dataItem.title);

            if (dataItem.summary) {
                span = row.find("td").eq(2).find("span").last();
                span.text('');
                span = row.find("td").eq(3).find("span").last();
                span.text('');
                span = row.find("td").eq(4).find("span").last();
                span.text('');
                span = row.find("td").eq(5).find("span").last();
                span.text('');
                span = row.find("td").eq(6).find("span").last();
                span.text('');
            }
            else {
                span = row.find("td").eq(2).find("span").last();
                span.text(dataItem.JobDays == null ? 0 : dataItem.JobDays);
                span = row.find("td").eq(3).find("span").last();
                span.text(dataItem.DispersedHours == null ? '' : dataItem.DispersedHours);
                span = row.find("td").eq(6).find("span").last();
                span.text(dataItem.JobCompletedDate !== null ? kendo.toString(dataItem.JobCompletedDate, 'MM/dd/yyyy') : '');
            }

            //var str = gantt.element.find(".k-task");
            //if (dataItem.parentId == null) {
            //    this.style.backgroundColor = "#" + Math.floor(Math.random() * 16777215).toString(16);
            //}
        }

        var i = 0
        var colorArray = ['#DC3545', '#4D82B8', '#FFC107', '#800080', '#5CB85C',
            '#FD7E14', '#B89A7C', '#009688', '#00BCD4', '#EFC1B4',
            '#2A579A'];

        $(".k-task.k-task-summary").each(function (e) {
            this.style.backgroundColor = colorArray[i];
            i = i + 1;
        });

        var header_footer = $('#gantt .k-floatwrap.k-header.k-gantt-toolbar');
        $(header_footer[1]).addClass('kill-footer');
    }

    function resizeGantt() {
        var gantt = $("#gantt").data("kendoGantt");

        if (gantt) {
            gantt.resize();
        }

        //expandAll();
    }

    function refreshGantt() {
        var gantt = $("#gantt").data("kendoGantt");
        if (gantt) {
            gantt.dataSource.read().then(() => {
                //expandAll();
            });
            gantt.dependencies.read();
        }

    }

</script>
