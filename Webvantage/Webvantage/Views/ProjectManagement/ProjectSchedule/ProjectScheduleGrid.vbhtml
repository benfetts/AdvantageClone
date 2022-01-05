@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

@functions 
    Public Function LockColumn(ByVal Column As Integer) As String
        Dim AppVars As Webvantage.cAppVars = Nothing
        AppVars = New Webvantage.cAppVars(Webvantage.cAppVars.Application.PROJECT_SCHEDULE)
        AppVars.getAllAppVars()

        If Column <= CInt(AppVars.getAppVar("LockedColumns", "Integer", "0")) Then
            Return "locked: true"
        Else
            Return "locked: false"
        End If
    End Function

    Public Function LockedColumnCount() As Integer
        Dim AppVars As Webvantage.cAppVars = Nothing
        AppVars = New Webvantage.cAppVars(Webvantage.cAppVars.Application.PROJECT_SCHEDULE)
        AppVars.getAllAppVars()

        Return CInt(AppVars.getAppVar("LockedColumns", "Integer", "0"))
    End Function
end functions



<style>
    #treelist {
        margin: 0;
        padding: 0;
        border-width: 0;
        height: 100%; /* DO NOT USE !important for setting the Grid height! */
    }

    .k-grid-header th.k-header,
    .k-grid td {
        padding: 2px 5px;
        height: auto;
        /*max-height: 35px;*/
    }

    .k-grid .k-grid-header .k-header .k-link {
        height: auto;
    }

    .k-grid .k-grid-header .k-header {
        white-space: normal;
    }

    .k-grid .k-button {
        margin: .16em;
    }

    .k-treelist-group > td {
        font-weight: bold;
        background: #cfcfcf;
    }

    .k-treelist-group.k-state-selected {
        background: #afafaf;
    }

    .k-treelist-group input, .k-treelist-group textarea {
        font-weight: normal;
    }

    .selecting-preds .img-link > img {
        opacity: .5;
        filter: alpha(opacity=50);
        cursor: default;
    }

    .pred-selector .img-link[id^=SelectPreds] > img {
        opacity: 1;
        filter: alpha(opacity=100);
        cursor: pointer;
    }

    .lastColumn {
        border-right: solid !important;
        border-right-width: 1px !important;
        border-right-color: #ccc !important;
    }

    .k-grid input.k-checkbox + label.k-checkbox-label {
        display: grid;
        margin-bottom: 15px;
    }

    .k-drag-clue {
        font-size: 15px;
    }

    span.k-icon.k-drag-status {
        font-size: 20px;
    }

    span.k-header.k-drag-separator {
        font-size: 20px;
    }

    input.k-fubar[type="checkbox"] {
        margin-right: 0px !important;
    }

    .k-grid-filter.k-state-active {
        background-color: yellow;
    }

    #treelist .k-footer-template:not([data-parentid='null']) {
        display: none;
    }

    form.k-filter-menu .k-textbox, form.k-filter-menu .k-widget {
        margin-bottom: 6px;
    }

    .ps-standard-light-pink {
        box-shadow: inset 0 0 25px 0 #EEACB9 !important;
    }

    .ps-standard-light-orange {
        box-shadow: inset 0 0 25px 0 #F5C7A1 !important;
    }

    .ps-standard-light-grey {
        box-shadow: inset 0 0 25px 0 #AEAEAE !important;
    }

    .ps-standard-light-green {
        box-shadow: inset 0 0 25px 0 #99C3B8 !important;
    }
    .ps-projected {
        box-shadow: inset 0 0 25px 0 #FFEB3B !important;
    }

</style>

<div id="treelist" style="border: 1px solid #CCC;"></div>

<ul id="TaskContextMenu" class="k-widget k-context-menu" data-role="contextmenu" style="display:none">
    <li id="TaskDetails" value="0">Task Details</li>
    <li class="k-separator"></li>
    <li id="ContextAbove" value="1">Add Task Above</li>
    <li id="ContextInto" value="2">Add Task Into</li>
    <li id="ContextBelow" value="3">Add Task Below</li>
    <li class="k-separator"></li>
    <li id="DeleteTask" value="4">Delete Task</li>
</ul>

@Html.Partial("DocumentsList")


<script id="template" type="text/x-kendo-template">
    <tr data-uid="#= uid #">
        # this.columns.forEach(function(col) {
        var val = data[col.field],
        css,
        style = ''
        cClasses = '';
        if (typeof col.attributes === 'function') {
        css = col.attributes(data);
        cClasses = css["class"];
        style = css.style
        }
        #
        <td class='#= cClasses #' style='#= style #'>
            #= data[col.field] #
        </td>
        # }) #
    </tr>
</script>

<script>
    var ScheduleTreeListDataSource;
    var taskDeleted = false;
    var taskEdited = false;
    var taskInserted = false;
    var CalculateByPredecessor = 0;
    var selectedRows = [];
    var gStatus = [{
        Code: 'A',
        Name: 'Active'
    }, {
        Code: 'P',
        Name: 'Projected'
    }];

    var selectingPreds = false;
    var numberOfLockedColumns = @LockedColumnCount();

    $(() => {
        ScheduleTreeListDataSource = new kendo.data.TreeListDataSource({
            batch: true,
            filter: (e) => {
            },
            transport: {
                create: (e) => {
                    $.ajax({
                        url: "@Href("~/ProjectManagement/ProjectSchedule/CreateProjectScheduleTask")",
                        type: 'POST',
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(e.data.models),
                        success: (results) => {
                            taskInserted = false;
                            e.success(results);
                        },
                        error: (results) => {
                            e.error(results);
                        }
                    });
                },
                read: (e) => {

                    var data = {
                        JobNumber: @Model.JobNumber,
                        JobComponentNumber: @Model.JobComponentNumber,
                        Sort: CalculateByPredecessor ? '' : 'order'
                    };

                    $.ajax({
                        url: "@Href("~/ProjectManagement/ProjectSchedule/ReadGanttTask")",
                        dataType: 'json',
                        data: data,
                        success: (resultsString) => {
                            var results = JSON.parse(resultsString);
                            $.each(results, (i, e) => {
                                if (typeof e.EmployeeCode !== 'undefined' && e.EmployeeCode !== null) {
                                    var o = {
                                        EmployeeCodes: e.EmployeeCode.split(',')
                                    }
                                    $.extend(e, o);
                                }
                                if (typeof e.ClientContact !== 'undefined' && e.ClientContact !== null) {
                                    var o = {
                                        ClientContacts: e.ClientContact.split(',')
                                    }
                                    $.extend(e, o);
                                }
                            });
                            e.success(results);
                            $(".k-grid-content-locked").height($(".k-grid-content").height());
                        },
                        error: (results) => {
                            e.error(results);
                        }
                    });
                },
                update: (e) => {
                    var data = [];
                    e.data.models.forEach((v, i, a) => {
                        data[i] = {
                            AlertId: v.AlertId,
                            //AttachedEntityType: v.AttachedEntityType,
                            ClientContact: v.ClientContact,
                            ClientContactName: v.ClientContactName,
                            //DataContext: v.DataContext,
                            //DbContext: v.DbContext,
                            DispersedHours: v.DispersedHours,
                            DueDateComments: v.DueDateComments,
                            DueDateLock: v.DueDateLock,
                            DueTime: v.DueTime,
                            EmployeeCode: v.EmployeeCode,
                            //EmployeeCodes: v.EmployeeCodes,
                            EmployeeName: v.EmployeeName,
                            //EntityError: v.EntityError,
                            //Error: v.Error,
                            EstimateFunction: v.EstimateFunction,
                            FunctionComments: v.FunctionComments,
                            FunctionDescription: v.FunctionDescription,
                            GridOrder: v.GridOrder,
                            HasAlerts: v.HasAlerts,
                            HasAssignment: v.HasAssignment,
                            HasChildren: v.HasChildren,
                            HasDocuments: v.HasDocuments,
                            HasPredecessors: v.HasPredecessors,
                            ID: v.ID,
                            JobCompletedDate: v.JobCompletedDate != null ? v.JobCompletedDate.toJSON() : v.JobCompletedDate,
                            JobComponentNumber: v.JobComponentNumber,
                            JobDays: v.JobDays,
                            JobDueDate: v.JobDueDate != null ? v.JobDueDate.toJSON() : v.JobDueDate,
                            JobHours: v.JobHours,
                            JobNumber: v.JobNumber,
                            JobOrder: v.JobOrder,
                            JobRevisedDate: v.JobRevisedDate != null ? v.JobRevisedDate.toJSON() : v.JobRevisedDate,
                            Level: v.Level,
                            Milestone: v.Milestone,
                            ParentTaskSequenceNumber: v.ParentTaskSequenceNumber,
                            PercentComplete: v.PercentComplete,
                            PhaseDescription: v.PhaseDescription,
                            PhaseEndDate: v.PhaseEndDate != null ? v.PhaseEndDate.toJSON() : v.PhaseEndDate,
                            PhaseOrder: v.PhaseOrder,
                            PhaseStartDate: v.PhaseStartDate != null ? v.PhaseStartDate.toJSON() : v.PhaseStartDate,
                            PostedHours: v.PostedHours,
                            Predecessor: v.Predecessor,
                            PredecessorLevelNotation: v.PredecessorLevelNotation,
                            PredecessorSequenceNumbers: v.PredecessorSequenceNumbers,
                            RevisedDueTime: v.RevisedDueTime,
                            RevisionDateComments: v.RevisionDateComments,
                            SequenceNumber: v.SequenceNumber,
                            TaskCode: v.TaskCode,
                            TaskDescription: v.TaskDescription,
                            TaskStartDate: v.TaskStartDate != null ? v.TaskStartDate.toJSON() : v.TaskStartDate,
                            TaskStatus: v.TaskStatus,
                            //TempCompleteDateString: v.TempCompleteDateString,
                            TemporaryCompleteDate: v.TemporaryCompleteDate != null ? v.TemporaryCompleteDate.toJSON() : v.TemporaryCompleteDate,
                            TrafficPhaseID: v.TrafficPhaseID,
                            TrafficRole: v.TrafficRole,
                            //hasChildren: v.hasChildren,
                            Priority: v.Priority
                        }
                    });

                    $.ajax({
                        url: "@Href("~/ProjectManagement/ProjectSchedule/UpdateProjectScheduleTask")",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(data),
                        method: "POST",
                        success: (results) => {
                            //well the call worked, but who knows if they all saved....
                            var tasks = [];
                            results.forEach((v, i, a) => {
                                tasks[i] = v.Task;

                                if (v.ErrorMessage !== '') {
                                    alert(results.ErrorMessage);
                                }
                                
                            });

                            e.success(tasks);
                        },
                        error: (jqXHR, textStatus, errorThrown) => {
                            alert(errorThrown);
                            e.error(errorThrown);
                        }
                    }).then(() => {
                        //console.log('update completed');
                    });
                },
                destroy: (e) => {
                    var data =  [];

                    e.data.models.forEach((v, i, a) => {
                        data[i] = {
                            JobNumber: v.JobNumber,
                            JobComponentNumber: v.JobComponentNumber,
                            SequenceNumber: v.SequenceNumber
                        }
                    });

                    $.ajax({
                        url: "@Href("~/ProjectManagement/ProjectSchedule/DeleteTask")",
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        type: 'POST',
                        data: JSON.stringify(data),
                        success: (results) => {
                            if (results.Message !== '') {
                                showKendoAlert('Unable to delete all selected tasks! ' + results.Message);
                            }
                            taskDeleted = false;
                            e.success();
                            $('#treelist').data('kendoTreeList').refresh();
                            setSave();
                        },
                        error: (jqXHR, textStatus, errorThrown) => {
                            e.error(jqXHR, textStatus, errorThrown);
                        }
                    });
                },
                parameterMap: (data, type) => {
                    if (type == 'update') {
                        data.PredecessorSequenceNumbers = JSON.stringify(data.PredecessorSequenceNumbers);
                    }

                    return data;
                }
            },
            //sort: { field: "GridOrder", dir: "asc" },
            //serverFiltering: false,
            schema: {
                model: {
                    id: "SequenceNumber",
                    parentId: "ParentTaskSequenceNumber",
                    expanded: true,
                    fields: {
                        ID: { from: "ID", type: "number", nullable: true },
                        AlertId: { from: "AlertId", type: "number" },
                        TaskCode: {
                            from: 'TaskCode', type: 'string'
                        },
                        TaskDescription: {
                            from: "TaskDescription", defaultValue: "", type: "string"
                        },
                        Milestone: { from: 'Milestone', type: 'string' },
                        EmployeeCode: { from: 'EmployeeCode', type: 'string' },
                        EmployeeName: { from: 'EmployeeName', type: 'string' },
                        JobOrder: { from: 'JobOrder', type: 'number', validation: { min: 0 } },
                        JobDays: { from: 'JobDays', type: 'number', validation: { min: 0 } },
                        DispersedHours: { from: 'DispersedHours', type: 'number', editable: false },
                        TaskStartDate: { from: "TaskStartDate", type: "date" },
                        JobRevisedDate: { from: "JobRevisedDate", type: "date" },
                        JobDueDate: { from: "JobDueDate", type: "date" },
                        DueTime: { from: 'DueTime', type: 'string' },
                        JobCompletedDate: { from: "JobCompletedDate", type: "date" },
                        EstimateFunction: { from: 'EstimateFunction', type: 'string' },
                        TaskStatus: { from: 'TaskStatus', type: 'string' },
                        DueDateLock: { from: 'DueDateLock', type: 'number' },
                        FunctionDescription: { from: 'FunctionDescription', type: 'string' },
                        DueDateComments: { from: 'DueDateComments', type: 'string' },
                        RevisionDateComments: { from: 'RevisionDateComments', type: 'string' },
                        PostedHours: { from: 'PostedHours', type: 'number', editable: false },
                        JobNumber: { from: 'JobNumber', type: 'number', defaultValue: @Model.JobNumber },
                        JobComponentNumber: { from: 'JobComponentNumber', type: 'number', defaultValue: @Model.JobComponentNumber },
                        SequenceNumber: { from: "SequenceNumber", type: "number", defaultValue: null },
                        TemporaryCompleteDate: { from: "TemporaryCompleteDate", type: "date", editable: false },
                        TrafficPhaseID: { from: 'TrafficPhaseID', type: 'number' },
                        PhaseOrder: { from: 'PhaseOrder', type: 'number' },
                        PhaseDescription: { from: 'PhaseDescription', type: 'string' },
                        JobHours: { from: 'JobHours', type: 'number', validation: { min: 0 } },
                        Predecessor: { from: 'Predecessor', type: 'number' },
                        FunctionComments: { from: 'FunctionComments', type: 'string' },
                        TrafficRole: { from: 'TrafficRole', type: 'string' },
                        HasAssignment: { from: 'HasAssignment', type: 'number' },
                        HasAlerts: { from: 'HasAlerts', type: 'number' },
                        PercentComplete: { from: "PercentComplete", type: "number", editable: false },
                        PhaseStartDate: { from: "PhaseStartDate", type: "date" },
                        PhaseEndDate: { from: "PhaseEndDate", type: "date" },
                        ClientContact: { from: 'ClientContact', type: 'string' },
                        ClientContactName: { from: 'ClientContactName', type: 'string' },
                        ParentTaskSequenceNumber: { from: "ParentTaskSequenceNumber", type: "number", nullable: true, defaultValue: null, Validation: { required: true } },
                        GridOrder: { from: 'GridOrder', type: 'number' },
                        Level: { from: 'Level', type: 'string', editable: false },
                        HasDocuments: { from: "HasDocuments", type: "boolean", editable: false },
                        HasChildren: { from: "HasChildren", type: "boolean" },
                        HasPredecessors: { from: "HasPredecessors", type: "boolean" },
                        PredecessorLevelNotation: { from: 'PredecessorLevelNotation', type: 'string' },
                        Priority: { from: 'Priority', type: 'number' }
                    }
                }
            },
            aggregate: [
                { field: "PostedHours", aggregate: "sum" },
                { field: "DispersedHours", aggregate: "sum" },
                { field: "JobDays", aggregate: "sum" },
                { field: "JobHours", aggregate: "sum" },
                { field: "TaskStartDate", aggregate: "min" },
                { field: "JobRevisedDate", aggregate: "max" }
            ]
        });

        treeList = $("#treelist").kendoTreeList({
            dataSource: ScheduleTreeListDataSource,
            resizable: true,
            filterable: {
                extra: false
            },
            filterMenuInit: function (e) {
            },
            filterMenuInit: function (e) {
            },
            @if Model.CanUserEdit Then
                    @<text> editable: {
                move: true,
                mode: "incell",
                confirmation: "Do you really really really want to do this?"
            }, </text>
            Else
                    @<text> editable: false, </text>
            End If
            selectable: "row, multiple",
            edit: edit,
            navigatable: true,
            allowCopy: true,
            cellClose: function (e) {
                if (e.type === "save" && e.model.dirty) {
                    taskEdited = true;
                    setSave();
                }

                let model = e.model;
                let that = e.sender;
                setTimeout(() => {
                    let selector = `div[taskduedate-cell='${model.AlertId}']`;
                    if (model) {
                        var className = getDueDateClass(model);

                        if ($(selector).length) {
                            $(selector).closest("td").removeClass("ps-standard-light-pink");
                            $(selector).closest("td").removeClass("ps-standard-light-orange");
                            $(selector).closest("td").removeClass("ps-standard-light-grey");
                            $(selector).closest("td").removeClass("ps-standard-light-green");
                            $(selector).closest("td").removeClass("ps-projected");

                            $(selector).closest("td").addClass(className);
                        }
                    }
                },0);

            },
            change: (e) => {
                var treeList = $("#treelist").data("kendoTreeList")
                var selected = treeList.select();

                if (selected.length === 2) {
                    var item = treeList.dataItem(selected[0]);
                    if (!item.HasChildren) {
                        $('#taskDetailButton').removeClass('k-state-disabled');
                        $('#taskDetailButton').prop('disabled', false);
                    }
                    else {
                        $('#taskDetailButton').addClass('k-state-disabled');
                        $('#taskDetailButton').prop('disabled', true);
                    }

                    $("#dropdown-content").addClass('showDropdown');
                }
                else {
                    $('#taskDetailButton').addClass('k-state-disabled');
                    $('#taskDetailButton').prop('disabled', true);

                    $("#dropdown-content").removeClass('showDropdown');
                }

                if (selected.length > 0) {
                    $('#deleteTaskBtn').removeClass('k-state-disabled');
                    $('#copyButton').removeClass('k-state-disabled');
                }
                else {
                    $('#deleteTaskBtn').addClass('k-state-disabled');
                    $('#copyButton').addClass('k-state-disabled');
                }

                selectedRows = [];
                $.each(selected, (index, value) => {
                    var item = treeList.dataItem(value);
                    selectedRows.push(item.SequenceNumber);
                });

                if (e.action == "itemchange") {
                    e.items[0].dirtyFields = e.items[0].dirtyFields || {};
                    e.items[0].dirtyFields[e.field] = true;
                }

                var that = e.sender;
                var rows = e.sender.table.find("tr");
                rows.each(function (idx, row) {
                    var dataItem = that.dataItem(row);
                    if (dataItem) {
                        var className = getDueDateClass(dataItem);

                        let selector = `div[taskduedate-cell='${dataItem.AlertId}']`;

                        var elm = $(selector);

                        //due date was manually entered
                        if ($(selector).length) {
                            $(selector).closest("td").removeClass("ps-standard-light-pink");
                            $(selector).closest("td").removeClass("ps-standard-light-orange");
                            $(selector).closest("td").removeClass("ps-standard-light-grey");
                            $(selector).closest("td").removeClass("ps-standard-light-green");
                            $(selector).closest("td").removeClass("ps-projected");

                            $(selector).closest("td").addClass(className);
                        }
                    }

                });

            },
            expand: (e) => {
            },
            dataBound: (e) => {

                if (selectedRows && selectedRows.length > 0) {
                    let treeList = $("#treelist").data("kendoTreeList");
                    let myselected = selectedRows;

                    $.each(treeList.dataSource._data, function (idx, record) {
                        $.each(myselected, (i, val) => {
                            if (record.SequenceNumber == val) {
                                var row = treeList.tbody
                                    .find("tr[data-uid='" + record.uid + "']");

                                treeList.select(row);
                            }
                        });
                    });
                }

                var that = e.sender;
                var rows = e.sender.table.find("tr");
                rows.each(function (idx, row) {
                    var dataItem = that.dataItem(row);
                    var dueDateCell = $(row).find("td.due-date");

                    if (dataItem) {
                        dueDateCell.removeClass("ps-standard-light-pink");
                        dueDateCell.removeClass("ps-standard-light-orange");
                        dueDateCell.removeClass("ps-standard-light-grey");
                        dueDateCell.removeClass("ps-standard-light-green");
                        dueDateCell.removeClass("ps-projected");

                        dueDateCell.addClass(getDueDateClass(dataItem));
                    }
                });

                var treelist = $('#treelist').data("kendoTreeList");

                var column = treelist.columns[treelist.columns.length - 1];

                if (column.attributes && column.attributes.class && column.attributes.class.indexOf(' lastColumn') < 0) {
                    column.attributes.class = column.attributes.class + ' lastColumn';
                    if (column.headerAttributes) {
                        column.headerAttributes.class = column.headerAttributes.class + ' lastColumn';
                    }
                }

                //var fixed_grid = $('.k-grid-content-locked');
                //if (fixed_grid) {
                //    fixed_grid.height(fixed_grid.height() + 15);
                //}

                //var lockedHeight = $('#treelist').find('.k-grid-content-locked').height();
                //var scrollableHeight = $('#treelist').find('.k-grid-content.k-auto-scrollable').height();

                //console.log("databound", lockedHeight, scrollableHeight);
                //$('#treelist').find('.k-grid-content-locked').css("height", scrollableHeight);
            },
            drop: (e) => {
                var container = e.sender.wrapper.children(".k-grid-content");
                var position = e.originalEvent.clientY - $(e.sender.element).position().top - $(container).position().top;
                var height = $(e.dropTarget).height();
                var top = $(e.dropTarget).position().top;
                var rows = $(e.dropTarget).closest("tr");
                var scrollTop = $(container).scrollTop();
                var treelist = $('#treelist').data("kendoTreeList");
                treelist.closeCell();
                treelist.table.focus();
                if (CalculateByPredecessor == 0) {
                    if (position != null) {
                        if (position + scrollTop - top <= height / 2) {
                            var treelist = $('#treelist').data("kendoTreeList");
                            treelist.dataSource.remove(e.source);
                            var index = treelist.dataSource.indexOf(e.destination);
                            var data = treelist.dataSource.data();
                            var previous = data[index - 1];
                            if (index > 0) {
                                if (!previous.JobOrder) {
                                    if (e.destination.JobOrder && e.destination.JobOrder > 0) {
                                        e.source.JobOrder = e.destination.JobOrder - 1
                                    }
                                    else {
                                        e.source.JobOrder = null;
                                    }
                                }
                                else if (e.destination.JobOrder) {
                                    if (previous.JobOrder < e.destination.JobOrder - 1) {
                                        e.source.JobOrder = e.destination.JobOrder - 1
                                    }
                                    else {
                                        e.source.JobOrder = e.destination.JobOrder;
                                    }
                                }
                                else {
                                    e.source.JobOrder = null;
                                }
                            }
                            else {
                                e.source.JobOrder = null;
                            }

                            let seqNumber = e.source.SequenceNumber;
                            treelist.dataSource.insert(index, e.source);
                            updateItemsOrder(treelist.dataSource.data()).then(() => {
                                treelist.clearSelection();
                                var data = treelist.dataSource.data();

                                var record = data.find(x => x.SequenceNumber == seqNumber);

                                var row = treeList.tbody
                                    .find("tr[data-uid='" + record.uid + "']");

                                treelist.select(row);
                                $(container).scrollTop(scrollTop);

                            });

                            e.preventDefault();
                        }
                        else {
                            var treelist = $('#treelist').data("kendoTreeList");
                            treelist.dataSource.remove(e.source);
                            var index = treelist.dataSource.indexOf(e.destination);
                            var data = treelist.dataSource.data();
                            if (index < data.length) {
                                var previous = data[index + 1];

                                if (index == data.length - 1) {
                                    previous = data[index];
                                }

                                if (!previous.JobOrder) {
                                    if (e.destination.JobOrder && e.destination.JobOrder > 0) {
                                        e.source.JobOrder = e.destination.JobOrder + 1
                                    }
                                    else {
                                        e.source.JobOrder = null;
                                    }
                                }
                                else if (e.destination.JobOrder) {
                                    if (previous.JobOrder < e.destination.JobOrder + 1) {
                                        e.source.JobOrder = e.destination.JobOrder + 1
                                    }
                                    else {
                                        e.source.JobOrder = e.destination.JobOrder;
                                    }
                                }
                                else {
                                    e.source.JobOrder = null;
                                }
                            }
                            else {
                                e.source.JobOrder = null;
                            }

                            let seqNumber = e.source.SequenceNumber;
                            treelist.dataSource.insert(index + 1, e.source);
                            updateItemsOrder(treelist.dataSource.data()).then(() => {
                                treelist.clearSelection();
                                var data = treelist.dataSource.data();

                                var record = data.find(x => x.SequenceNumber == seqNumber);

                                var row = treeList.tbody
                                    .find("tr[data-uid='" + record.uid + "']");

                                treelist.select(row);
                                $(container).scrollTop(scrollTop);

                            });
                            e.preventDefault();

                        }
                    }
                    else {
                        var treelist = $('#treelist').data("kendoTreeList");
                        treelist.dataSource.remove(e.source);
                        treelist.dataSource.add(e.source);
                        updateItemsOrder(treelist.dataSource.data()).then(() => {
                            $(container).scrollTop(scrollTop);
                        });

                        e.preventDefault();
                    }
                }
                else {
                    if (e.dropTarget != null) {
                        var row = $(e.dropTarget).closest("tr");
                        if (row.length > 0) {
                            if (position + scrollTop - top <= 7) {
                                var treelist = $('#treelist').data("kendoTreeList");
                                treelist.dataSource.remove(e.source);
                                var index = treelist.dataSource.indexOf(e.destination);
                                var data = treelist.dataSource.data();
                                if (index > 0) {
                                    var previous = data[index - 1];
                                    //in this case we should be at the same level as the one we dropped on
                                    e.source.ParentTaskSequenceNumber = e.destination.ParentTaskSequenceNumber;
                                    if (e.source.ParentTaskSequenceNumber == null) {
                                        e.source.ParentTaskSequenceNumber = -1
                                    }
                                    if (!previous.JobOrder) {
                                        if (e.destination.JobOrder && e.destination.JobOrder > 0) {
                                            e.source.JobOrder = e.destination.JobOrder - 1
                                        }
                                        else {
                                            e.source.JobOrder = null;
                                        }
                                    }
                                    else if (e.destination.JobOrder) {
                                        if (previous.JobOrder < e.destination.JobOrder - 1) {
                                            e.source.JobOrder = e.destination.JobOrder - 1
                                        }
                                        else {
                                            e.source.JobOrder = e.destination.JobOrder;
                                        }
                                    }
                                    else {
                                        e.source.JobOrder = null;
                                    }
                                }
                                else {
                                    e.source.JobOrder = null;
                                }

                                let seqNumber = e.source.SequenceNumber;
                                treelist.dataSource.insert(index, e.source);
                                updateItemsOrder(treelist.dataSource.data()).then(() => {
                                    treelist.clearSelection();
                                    var data = treelist.dataSource.data();

                                    var record = data.find(x => x.SequenceNumber == seqNumber);

                                    var row = treeList.tbody
                                        .find("tr[data-uid='" + record.uid + "']");

                                    treelist.select(row);
                                    $(container).scrollTop(scrollTop);

                                });
                            }
                            else if (position + scrollTop - top >= height - 7) {
                                var treelist = $('#treelist').data("kendoTreeList");
                                treelist.dataSource.remove(e.source);
                                var index = treelist.dataSource.indexOf(e.destination);
                                var data = treelist.dataSource.data();
                                if (index < data.length - 1) {
                                    var previous = data[index + 1];
                                    //in this case we should be at the same level as the one we dropped on
                                    e.source.ParentTaskSequenceNumber = e.destination.ParentTaskSequenceNumber;
                                    if (e.source.ParentTaskSequenceNumber == null) {
                                        e.source.ParentTaskSequenceNumber = -1
                                    }
                                    if (!previous.JobOrder) {
                                        if (e.destination.JobOrder && e.destination.JobOrder > 0) {
                                            e.source.JobOrder = e.destination.JobOrder + 1
                                        }
                                        else {
                                            e.source.JobOrder = null;
                                        }
                                    }
                                    else if (e.destination.JobOrder) {
                                        if (previous.JobOrder < e.destination.JobOrder + 1) {
                                            e.source.JobOrder = e.destination.JobOrder + 1
                                        }
                                        else {
                                            e.source.JobOrder = e.destination.JobOrder;
                                        }
                                    }
                                    else {
                                        e.source.JobOrder = null;
                                    }
                                    let seqNumber = e.source.SequenceNumber;
                                    treelist.dataSource.insert(index + 1, e.source);
                                    updateItemsOrder(treelist.dataSource.data()).then(() => {
                                        treelist.clearSelection();
                                        var data = treelist.dataSource.data();

                                        var record = data.find(x => x.SequenceNumber == seqNumber);

                                        var row = treeList.tbody
                                            .find("tr[data-uid='" + record.uid + "']");

                                        treelist.select(row);
                                        $(container).scrollTop(scrollTop);
                                    });
                                }
                                else {
                                    e.source.JobOrder = null;

                                    let seqNumber = e.source.SequenceNumber;
                                    treelist.dataSource.insert(index + 1, e.source);
                                    updateItemsOrder(treelist.dataSource.data()).then(() => {
                                        treelist.clearSelection();
                                        var data = treelist.dataSource.data();

                                        var record = data.find(x => x.SequenceNumber == seqNumber);

                                        var row = treeList.tbody
                                            .find("tr[data-uid='" + record.uid + "']");

                                        treelist.select(row);
                                        $(container).scrollTop(scrollTop);
                                    });
                                }

                            }
                            else {
                                var treelist = $('#treelist').data("kendoTreeList");
                                var SeqNum = e.destination.SequenceNumber;

                                //in this case we should be the child of the one we were dropped on
                                e.source.ParentTaskSequenceNumber = SeqNum;

                                let seqNumber = e.source.SequenceNumber;
                                updateItemsOrder(treelist.dataSource.data()).then(() => {
                                    treelist.clearSelection();
                                    var data = treelist.dataSource.data();

                                    var record = data.find(x => x.SequenceNumber == seqNumber);

                                    var row = treeList.tbody
                                        .find("tr[data-uid='" + record.uid + "']");

                                    treelist.select(row);
                                    $(container).scrollTop(scrollTop);
                                });
                            }
                        }
                        else {
                            var treelist = $('#treelist').data("kendoTreeList");
                            e.source.ParentTaskSequenceNumber = -1;

                            let seqNumber = e.source.SequenceNumber;
                            updateItemsOrder(treelist.dataSource.data()).then(() => {
                                treelist.clearSelection();
                                var data = treelist.dataSource.data();

                                var record = data.find(x => x.SequenceNumber == seqNumber);

                                var row = treeList.tbody
                                    .find("tr[data-uid='" + record.uid + "']");

                                treelist.select(row);
                                $(container).scrollTop(scrollTop);
                            });
                        }
                    }
                    else {
                        var treelist = $('#treelist').data("kendoTreeList");
                        e.source.ParentTaskSequenceNumber = -1;

                        let seqNumber = e.source.SequenceNumber;
                        updateItemsOrder(treelist.dataSource.data()).then(() => {
                            var data = treelist.dataSource.data();

                            var record = data.find(x => x.SequenceNumber == seqNumber);

                            var row = treeList.tbody
                                .find("tr[data-uid='" + record.uid + "']");

                            treelist.select(row);
                            $(container).scrollTop(scrollTop);
                        });
                    }
                    e.preventDefault();
                    setSave();
                }
            },
            dragstart: function (e) {
                //$("#treelist").data("kendoTreeList").selectable.userEvents.cancel();
                if (setSave()) {
                    saveFormClick();
                }
            },
            drag: (e) => {

                if (e.status != 'i-cancel' && e.target != null) {
                    var container = e.sender.wrapper.children(".k-grid-content");
                    var position = e.pageY - $(e.sender.element).position().top - $(container).position().top;
                    var height = $(e.target).height();
                    var top = $(e.target).position().top;
                    var rows = $(e.target).closest("tr");
                    var scrollTop = $(container).scrollTop();

                    //var treeList = $('#treelist').data('kendoTreeList');
                    //var rowstree = treeList.select();

                    if (rows.length > 0) {
                        if (CalculateByPredecessor == 0) {
                            if (position + scrollTop - top <= height / 2) {
                                e.setStatus('k-i-arrow-up')
                            }
                            else {
                                e.setStatus('k-i-arrow-down')
                            }
                        }
                        else {
                            if (position + scrollTop - top  <= 7) {
                                e.setStatus('k-i-arrow-up')
                            }
                            else if (position + scrollTop - top  >= height - 7) {
                                e.setStatus('k-i-arrow-down')
                            }
                            else {
                                e.setStatus('k-i-arrow-right');
                            }
                        }
                    }

                    e.preventDefault();
                }
            },
            excelExport: exportToExcel,//exportGridWithTemplatesContent,
            columns: [
                { locked: true, field: "Level", title: "Level", width: 100, headerTemplate: "<input type='checkbox' onclick='toggleAll(event)' /> Level", template: "<span>#: Level #</span>", attributes: { autofit: true, minwidth: '100px' }, filterable: false, expandable: true },
                //{ field: "TrafficRole", title: "TrafficRole", width: 100, attributes: { autofit: true, minwidth: '100px' } },
                @Code
                    Dim Count As Integer = 0
                End Code

           @for each item In Model.Columns
               If item.Visible Then
                   Count = Count + 1
                   Select Case item.ColumnType
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDescription
                    @<text> { field: "@item.ColumnType.ToString", title: "@item.HeaderText", editor: taskDescriptionEditor, attributes: { style: "text-overflow: ellipsis", class: "editable-cell" }, width: 260 }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCode
                    @<text> {
               field: "@item.ColumnType", title: "@item.HeaderText", editor: taskCodeDropList, width:  95, attributes: { class: "editable-cell" },
                    filterable: {
                        ui: function (element) {
                            var dropDownList = element.kendoDropDownList({
                                dataTextField:  "Code",
                                dataValueField: "Code",
                                valuePrimitive: true,
                                optionLabel: " ",
                                dataSource: new kendo.data.DataSource({
                                    transport: {
                                        read: "@Url.Content("~/Utilities/SearchTasks")",
                                        dataType: "json",
                                        data: {
                                            IncludeNoFilter: false,
                                            IncludeNone: false
                                        },
                                        parameterMap: function (data, type) {
                                            return data;
                                        }
                                    }
                                })
                            });

                            dropDownList.value = '';
                        }
                    }
                }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Priority
                        @<text>{
                    field: "Priority", title: "Priority", width: 100, template: priorityTemplate, editor: priorityEditor, attributes: { autofit: true, minwidth: '100px' }, filterable: false,
               filterable: {
                   ui: function (element) {
                       element.kendoDropDownList({
                           dataTextField: "Name",
                           dataValueField: "Code",
                           valuePrimitive: true,
                           dataSource: [{ Code: 1, Name: 'HH' },
                           { Code: 2, Name: 'H' },
                           { Code: 3, Name: '--' },
                           { Code: 4, Name: 'L' },
                           { Code: 5, Name: 'LL' }]
                       });
                   }
               }
                },</text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Phase
                    @<text> {
                    field: "TrafficPhaseID", title: "@item.HeaderText", editor: phaseDropList, template: '#=PhaseDescription#', width: 150, attributes: { class: "editable-cell" },
                        filterable: {
                        ui: function (element) {
                            element.kendoDropDownList({
                                dataTextField:  "Name",
                                dataValueField: "Code",
                                valuePrimitive: true,
                                dataSource: new kendo.data.DataSource({
                                    transport: {
                                        read: "@Url.Content("~/ProjectManagement/ProjectSchedule/SearchPhases")",
                                        dataType: "json",
                                        data: {
                                            IncludeNoFilter: false,
                                            IncludeNone: false
                                        },
                                        parameterMap: function (data, type) {
                                            return data;
                                        }
                                    }
                                })
                            });
                        }
                    }
                }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStatus
                    @<text> {
                    field: "@item.ColumnType.ToString",
                    title: "@item.HeaderText", template: "",
                    attributes: { class: 'icon-col go-center editable-cell' },
                    headerAttributes: { class: 'icon-col' },
                    width: "100px",
                    template: "#if(HasChildren == false){if(@item.ColumnType.ToString == 'P'){# Projected #}else{# Active #}}#",
                    editor: statusDropList,
                    filterable:  {
                        ui: (element) => {
                           element.kendoDropDownList({
                               dataTextField:  "Name",
                               dataValueField: "Code",
                               valuePrimitive: true,
                               dataSource: new kendo.data.DataSource({
                                   data: gStatus
                               })
                           });
                            element.css('margin-top', 100);
                        }
                    }   }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStartDate
                    @<text> {
            field: "@item.ColumnType.ToString", title: "@item.HeaderText", template: startDateTemplate, width: "110px", editor: dateEditor, attributes: { class: 'date-sm editable-cell' }, headerAttributes: { class: 'date-sm' },
                    filterable: {
                        ui: dateFilter,
                        extra: true
                        }
                    }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDueDate
                    @<text> {
                    field: "@AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString",
                    title: "@item.HeaderText",
                    template: dueDateTemplate,
                    width:  "110px",
                    editor: dateEditor,
            attributes: { class: 'date-sm due-date editable-cell ', style: "padding:0px" },
                    headerAttributes: { class: 'date-sm' },
                    filterable: {
                        ui: dateFilter,
                        extra: true
                    }
                }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.OriginalDueDate
                    @<text> {
               field: "@AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate.ToString", title: "@item.HeaderText", template: originalDueDateTemplate, width:  "110px", editor: dateEditor, attributes:  { class: "editable-cell" },
               filterable: {
                   ui: dateFilter,
                   extra: true
               }
                }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.CompletedDate
                    @<text> {
               field: "@AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate.ToString", title: "@item.HeaderText", template: completedDateTemplate, width:  "110px", editor: dateEditor, attributes:  { class: 'date-sm editable-cell' }, headerAttributes: { class: 'date-sm' },
               filterable: {
                   ui: dateFilter,
                   extra: true
               }
                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TempCompletedDate
                    @<text> {
               field: "TemporaryCompleteDate", title: "@item.HeaderText", format: "{0:d}", width: "110px", template: tempCompletedDateTemplate, editor: dateEditor, attributes:  { class: 'date-sm editable-cell' }, headerAttributes: { class: 'date-sm' },
               filterable: {
                   ui: dateFilter,
                   extra: true
               }
                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Milestone
                    @<text> {
                    title: "@item.HeaderText",
               field: "Milestone",
               editable: function (e) { return false; },
                    template: kendo.template($("#milestoneTemplate").html()),
                    attributes: { class: 'cb-sm-hdr editable-cell' }, headerAttributes: { class: 'cb-sm-hdr' },
                    headerTemplate: "<div class='go-center' style='padding-right: 4px'>M/S</div>",
                    width: 36, filterable: false

                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobDays
                    @<text> {
               field: "@item.ColumnType.ToString", title: "@item.HeaderText", template: "#if(HasChildren == false && @item.ColumnType.ToString){ return @item.ColumnType.ToString }#", width: 64, filterable: { ui: numericFilter }, editor: editNumber, attributes: { class: "editable-cell" }, footerTemplate: footerTemplate
                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobOrder
                    @<text> { field: "@item.ColumnType.ToString", title: "@item.HeaderText", width: 80, NotCalculateByPredecessor: true, hidden: true, editor: editNumber, filterable: {ui: numericFilter }, attributes:  { class: "editable-cell" } }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EstimateFunction
                    @<text> {
               field: "EstimateFunction", title: "@item.HeaderText", editor: estimateFunctionDropList, width:  150, template: estimateFunctionTemplate, attributes:  { class: "editable-cell" },
               filterable: {
                   ui: (element) => {
                       element.kendoDropDownList({
                           dataTextField:  "Name",
                           dataValueField: "Code",
                           valuePrimitive: true,
                           dataSource: new kendo.data.DataSource({
                               transport: {
                                   read: "@Url.Content("~/Utilities/SearchEstimateFunctions")",
                                   dataType: "json"
                               },
                               schema: {
                                   model: {
                                       fields: {
                                           Code: { type: "string" },
                                           Name: { type: "string" }
                                       }
                                   }
                               }
                           })
                       })

                       dropDownList.value = '';
                   }
               }
                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Linked
                    @<text> { title: "@item.HeaderText", template: kendo.template($("#linkedTemplate").html()), attributes: { class: 'icon-col go-center editable-cell' }, headerAttributes: { class: 'icon-col' }, width: "60px", hidden: true, CalculateByPredecessor: true, filterable: false }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.SelectPreds
                    @<text> { title: "@item.HeaderText", template: kendo.template($("#selectPredsTemplate").html()), attributes: { class: 'icon-col go-center editable-cell' }, headerAttributes: { class: 'icon-col' }, width: "60px", hidden: true, CalculateByPredecessor: true, filterable: false }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.MoveLeftOrRight
                    @<text> { title: "@item.HeaderText", template: kendo.template($("#moveLeftOrRightTemplate").html()), attributes: { class: 'move-lr editable-cell' }, headerAttributes: { class: 'move-lr' }, width: "80px", hidden: true, CalculateByPredecessor: true, filterable: false }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsTextbox
                    @<text> { field: 'PredecessorLevelNotation', title: "@item.HeaderText", editor: textAreaEditor, width: 100, CalculateByPredecessor: true, attributes: { class: "editable-cell" }, filterable: false, hidden: true }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsList
                           If Model.CalculateByPredecessor Then

                           End If
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateComments
                    @<text> {
                    field: "DueDateComments", title: "@item.HeaderText", template: (dataitem) => {
                        return "<div style='max-height:38px;overflow:hidden;text-overflow:ellipsis;'>" + (dataitem.DueDateComments != null ? dataitem.DueDateComments : "") + "</div>";
                    }, editor: textAreaCommentEditor, width: "260px", attributes: { class: "editable-cell" }, filterable: false }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.RevisionComments
                    @<text> {
                    field: "RevisionDateComments", title: "@item.HeaderText", template: (dataitem) => {
                            return "<div style='max-height:38px;overflow:hidden;text-overflow:ellipsis;'>" + (dataitem.RevisionDateComments != null ? dataitem.RevisionDateComments : "") + "</div>";
                    }, editor: textAreaCommentEditor, width: "260px", attributes: { class: "editable-cell" }, filterable: false }, </text>

                        case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsTextbox
                    @<text> {
                    field: "FunctionComments", title: "@item.HeaderText", template: (dataitem) => {
                            return "<div style='max-height:38px;overflow:hidden;text-overflow:ellipsis;'>" + (dataitem.FunctionComments != null ? dataitem.FunctionComments : "")  + "</div>";
                    }, editor: textAreaCommentEditor, width: "260px", attributes: { class: "editable-cell" }, filterable: false
                }, </text>

                            case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsImage
                    @<text> { title: "", template: functionCommentsImageTemplate, width: "50px", attributes: { class: 'icon-col' }, headerAttributes: { class: 'icon-col editable-cell' }, filterable: false }, </text>



                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateLock
                    @<text> {
               title: "@item.HeaderText",
               field: "DueDateLock",
               headerTemplate: "<div class='go-center' style='padding-right: 4px'><span class='k-icon k-i-lock'></span></div>",
               editable: function(e) { return false; },
               template: kendo.template($("#dueDateLockTemplate").html()),
               attributes: { class: 'cb-sm-hdr editable-cell' }, headerAttributes: { class: 'cb-sm-hdr' },
               width: 27, filterable: false
                },</text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete
                    @<text> {
               field: "EmployeeCode",
                    title: "@item.HeaderText",
                    width: 280,
                editor: employeeMultiSelect,
                attributes:  { class: "editable-cell" },
                template: employeesNameTextTemplate,
                filterable:  {
                    ui: (element) => {
                            element.kendoMultiSelect({
                                valuePrimitive:  true,
                                required: false,
                                filter: "contains",
                                dataTextField: "NameOnly",
                                dataValueField: "Code",
                                itemTemplate: employeeImageTemplate,
                                dataSource:  new kendo.data.DataSource({
                                    transport: {
                                        read: {
                                            url: "@Url.Content("~/Utilities/SearchEmployee")",
                                            data: (() => {
                                            })
                                        },
                                        dataType: "json"
                                    }
                                })
                                
                            })
                        }
                    }
                }, </text>
                    @<text> {
                    title: "@item.HeaderText",
                    template: employeesImageTemplate,
               attributes:  { class: 'icon-col editable-cell' }, headerAttributes: { class: 'icon-col' },
                    headerTemplate: "<!-- -->",
               width: 40, filterable: false
                }, </text>

                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesTextbox
                    @<text> {
                    field: "EmployeeCode",
                    title: "@item.HeaderText",
                    width: 280,
                    editor: employeeCodeMultiSelect,
                    template: employeesCodeTextTemplate,
                    attributes:  { class: "editable-cell" },
                    filterable: {
                        ui: (element) => {
                            element.kendoMultiSelect({
                                valuePrimitive:  true,
                                filter: "contains",
                                required: false,
                                dataTextField: "Name",
                                dataValueField: "Code",
                                itemTemplate: employeeCodeImageTemplate,
                                dataSource:  new kendo.data.DataSource({
                                    transport: {
                                        read: {
                                            url: "@Url.Content("~/Utilities/SearchEmployee")",
                                            data: (() => {
                                                var filterRole = $('#EmployeeMultiSelect').data('filterRole');
                                                var options = $('#EmployeeMultiSelect').data('options');
                                                if (filterRole) {
                                                    return {
                                                        Role: options.model.TrafficRole
                                                    };
                                                }
                                            })
                                        },
                                        dataType: "json"
                                    }
                                })
                            })
                        }
                    }
                }, </text>
                    @<text> {
                    title: "@item.HeaderText",
                    template: employeesImageTemplate,
               attributes:  { class: 'icon-col editable-cell' }, headerAttributes: { class: 'icon-col' },
                    headerTemplate: "<!-- -->",
               width: 40, filterable: false
                }, </text>

                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobHours
                    @<text> { field: "@item.ColumnType.ToString", title: "@item.HeaderText", width: 80, editor: editNumber, template: "#if(HasChildren == false && @item.ColumnType.ToString){ return @item.ColumnType.ToString }#", attributes: { class: "editable-cell" }, filterable: false, footerTemplate: footerTemplate }, </text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PostedHours
                    @<text> {
                           field: "@item.ColumnType.ToString"
                           , title: "@item.HeaderText"
                           , width: 80
                           , template: "#if(HasChildren == false && @item.ColumnType.ToString){ return @item.ColumnType.ToString }#"
                           , attributes: { class: "editable-cell" }
                           , filterable: false
               , footerTemplate: footerTemplate
                        }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DispersedHours
                    @<text> {
               field: "@item.ColumnType.ToString", title: "@item.HeaderText", width: 100, template: dispersedHourTemplate, attributes: { class: "editable-cell" }, filterable: false, footerTemplate: footerTemplate
                }, </text>

                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueTime
                    @<text> { field: "@AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisedDueTime.ToString", title: "@item.HeaderText", width: 80, attributes: { class: "editable-cell" }, filterable: false }, </text>


                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsLink
                    @<text> {
                    field: "ClientContacts",
                    title: "@item.HeaderText",
                    width: 280,
                    editor: contactMultiSelect,
               template: contactsNameTextTemplate, attributes:  { class: "editable-cell" }, filterable: false
                }, </text>

                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsTextbox
                    @<text> {
                    field: "ClientContacts",
                    title: "@item.HeaderText",
                    width: 280,
                    editor: contactMultiSelect,
               template: contactsCodeTextTemplate, attributes:  { class: "editable-cell" }, filterable: false
                }, </text>
                       Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDocuments
                    @<text> { title: "@item.HeaderText", headerTemplate: "<!-- -->", width: 50, template: taskDocumentsTemplate, attributes:  { class: "editable-cell" }, filterable: false }, </text>

                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PercentComplete
                    @<text> { field: "@item.ColumnType.ToString", title: "% Complete", width: 75, format: "{0:n2}", attributes: { class: "editable-cell" }, filterable: false }, </text>
                       Case Else
                    @<text> { field: "@item.ColumnType.ToString", title: "@item.HeaderText", width: 150, attributes: { class: "editable-cell" }, filterable: false }, </text>

                    End Select
                    End If
                    Next item

            ]
        }).data('kendoTreeList');

        treeList.bind("saveChanges", handleSaveChanges);

        $("#treelist table").on("keydown", ((e) => {
            if (e.keyCode === kendo.keys.TAB) {
            }
            else if (e.code == 'Space') {
                var grid = $("#treelist").data("kendoTreeList");
                var currentCell = grid.current();

                if (currentCell.hasClass("icon-col")) {
                    //prevent keydown
                    e.stopImmediatePropagation();
                }
            }
        }));

        $('#treelist').on('click', '.chkbx', function () {
            var checked = $(this).is(':checked');
            var grid = $('#treelist').data('kendoTreeList');
            var dataItem = grid.dataItem($(this).closest('tr'));
            dataItem.set('Milestone', checked ? 1 : 0);

            setSave();
        }).on('click', '.chkbxddl', function () {
            var checked = $(this).is(':checked');
            var grid = $('#treelist').data('kendoTreeList');
            var dataItem = grid.dataItem($(this).closest('tr'));
            dataItem.set('DueDateLock', checked ? 1 : 0);

            setSave();
        });

        $('#mainFrame').on('keydown', (e) => {
            if (e.keyCode == 45 && (!e.ctrlKey && !e.shiftKey)) {
                e.preventDefault();
                AddTask();
            }
        });

        $('#EmployeeOptions').kendoPopup({
            anchor: $('#EmployeeOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#DateOptions').kendoPopup({
            anchor: $('#DateOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#TaskOptions').kendoPopup({
            anchor: $('#TaskOptionsButton'),
            origin: "bottom left",
            position: "top left",
            collision: "fit",
            close: function () {
                $('#myOverlay').hide();
            }
        }).data('kendoPopup');

        $('#saveButton').on('click', saveFormClick);
        $('#cancelButton').on('click', cancelChanges);
        $('#refreshProjectSchedule').on('click', refresh);

    });

    var expanded = true;

    function expandCollapse() {
        var treelist = $("#treelist").data('kendoTreeList');
        expanded = !expanded;

        var dataItems = treeList.dataSource.data();

        $.each(dataItems, function (i, item) {
            item.expanded = expanded;
        });

        treelist.setDataSource(treelist.dataSource)

        if (expanded) {
            expandAll();
        }
        else {
            collapseAll();
        }
    }

    function clearFilters() {
        var treelist = $("#treelist").data('kendoTreeList');

        treelist.dataSource.filter({});

        treelist.setDataSource(treelist.dataSource);
    }

    function dateFilter(element) {
        element.kendoDatePicker({
            parseFormats:  ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy'
        });
    }

    function numericFilter(element) {
        element.kendoNumericTextBox({
            format: "n0"
        });
    }

    function isGridDirty() {
        if (taskDeleted || taskEdited || taskInserted) {
            return true;
        }
        return false;
    }

    function TaskDetailButtonClick() {
        var treeList = $('#treelist').data('kendoTreeList');
        var gantt = $("#gantt").data("kendoGantt")
        var rows = treeList.select();
        var useGantt = false;

        if (rows.length < 1) {
            rows = gantt.select();
            useGantt = true;
        }

        var dataItems = [];
        for (var i = 0; i < rows.length; i++) {
            if (useGantt) {
                var dataItem = gantt.dataItem(rows[i]);

                var newDateItem = {
                    JobNumber: dataItem.JobNumber,
                    JobComponentNumber: dataItem.JobComponentNumber,
                    SequenceNumber: dataItem.id,
                    ClientCode: dataItem.ClientCode,
                    DivisionCode: dataItem.DivisionCode,
                    ProductCode: dataItem.ProductCode,
                    TaskDescription: dataItem.title
                };

                dataItems[i] = newDateItem;
            }
            else {
                var dataItem = treeList.dataItem(rows[i]);
                dataItems[i] = dataItem;
            }
        }

        if (dataItems.length > 0) {
            viewTaskDetails(dataItems[0]);
        }
    }

    async function deleteTasks() {
        showKendoConfirm("<p>Are you sure you want to delete selected row(s)?<p>")
            .done(async function () {
                        var treeList = $('#treelist').data('kendoTreeList');
                    var gantt;
                    gantt = $("#gantt").data("kendoGantt");

                var rows = treeList.select();
                var useGantt = false;

                if (rows.length < 1) {
                    rows = gantt.select();
                    useGantt = true;
                }

                var dataItems = [];
                if (useGantt) {
                    for (var i = 0; i < rows.length; i++) {
                        var dataItem = gantt.dataItem(rows[i]);
                        dataItems[i] = dataItem;
                    }

                    dataItems.forEach((o) => {
                        gantt.dataSource.remove(o);
                    });

                    gantt.dataSource.sync().then(()=>{
                        setSave();
                    });
                }
                else {

                    kendo.ui.progress(treeList.element, true);

                    var promises = [];

                    var dataSource = treeList.dataSource;

                    treeList.setDataSource([]);

                    for (var i = 0; i < rows.length; i++) {
                        promises[i] = deferedDelete(dataSource.getByUid($(rows[i]).data('uid')), dataSource);
                    }

                    await Promise.all(promises);

                    treeList.setDataSource(dataSource);

                    treeList.dataSource.sync().then(() => {
                        setSave();

                        treeList.dataSource.read().then(() => {
                            kendo.ui.progress(treeList.element, false);
                        });
                    });
                }
            })
            .fail(function () {
            });
    }

    async function deferedDelete(dataItem, tree) {
        var d = new $.Deferred();

        setTimeout(deleteItem, 0, dataItem, tree,d);

        return d.promise()
    }

    function deleteItem(dataItem,dataSource,d) {
        dataSource.remove(dataItem);
        d.resolve();
    }

    function handleSaveChanges(e) {
        var valid = true;
        var rows = this.tbody.find("tr");
        for (var i = 0; i < rows.length; i++) {

            var model = this.dataItem(rows[i]);
            if (model) {

                var cols = $(rows[i]).find("td");
                for (var j = 0; j < cols.length; j++) {

                    if (this.columns[j].field && this.dataSource.options.schema.model.fields[this.columns[j].field]) {
                        var rawCustomRules = this.dataSource.options.schema.model.fields[this.columns[j].field].validation
                        if (rawCustomRules) {
                            var customRules = Object.keys(rawCustomRules)
                                .filter(key => typeof rawCustomRules[key] === "function")
                                        .reduce((obj, key) => {
                                            obj[key] = rawCustomRules[key];
                                    return obj;
                                }, {});
                            var rules = $.extend({}, kendo.ui.Validator.fn.options.rules, customRules);
                            var input = $('<input />');
                            var currentValid = true;
                            input.attr('name', this.columns[j].field);
                            input.val(model[this.columns[j].field])

                            if (rawCustomRules.required) {
                                input.attr('required', 'required');
                            }

                            if (rawCustomRules.min) {
                                input.attr('min', rawCustomRules.min);
                                input.attr('data-type', 'number');
                            }

                            if (rawCustomRules.max) {
                                input.attr('min', rawCustomRules.max);
                                input.attr('data-type', 'number');
                            }

                            for (rule in rules) {
                                if (!rules[rule].call(this, input)) {
                                    valid = false;
                                    currentValid = false
                                                            break;
                                }
                            }

                            if (!currentValid) {
                                var treelist = $('#treelist').data('kendoTreeList');

                                treelist.editCell(cols.eq(j));
                                treelist.editor.editable.validatable.validate();
                            }
                        }
                    }
                }
            }
            else {
                break;
            }
        }
        if (!valid) {
            e.preventDefault(true);
        }
    };

    function validateTask(input) {
        return false;
    }

    function resizeGrid() {
        let dfd = $.Deferred();
        var treeList = $("#treelist");
        var kendoTreeList = treeList.data("kendoTreeList")
        kendoTreeList.resize();

        refreshGrid().then(() => {
            $(".k-grid-content-locked").height($(".k-grid-content").height());
            dfd.resolve();
        });
        return dfd;
    }

    function refreshGrid() {
        let dfd = $.Deferred();
        var treeList = $("#treelist");
        var kendoTreeList = treeList.data("kendoTreeList")
        kendo.ui.progress(kendoTreeList.element, true);

        kendoTreeList.dataSource.read().then(() => {
            $(".k-grid-content-locked").height($(".k-grid-content").height());
            kendo.ui.progress(kendoTreeList.element, false);
            dfd.resolve();
        });

        return dfd;
    }

    function editNumber(container, options) {
        $('<input data-bind="value:' + options.field + '"/>')
            .appendTo(container)
                    .kendoNumericTextBox({
                        spinners:  false,
                step: 0,
                min: 0
            });
    }

    function CalculateByPredecessorChange(CalculateByPredecessor) {
        var kendoTreeList = $("#treelist").data("kendoTreeList")
        var columns = jQuery.grep(kendoTreeList.columns, (function (v, i) { return kendoTreeList.columns[i].CalculateByPredecessor == true; }));
        var notColumns = jQuery.grep(kendoTreeList.columns, (function (v, i) { return kendoTreeList.columns[i].NotCalculateByPredecessor == true; }));

        kendo.ui.progress(kendoTreeList.element, true);

        if (CalculateByPredecessor) {
            jQuery.each(columns,(idx, column) => {
                kendoTreeList.showColumn(column);
            });

            jQuery.each(notColumns, (idx, column) => {
                kendoTreeList.hideColumn(column);
            });

            $("#CalcEndDateWrapper").hide();
            $("#CalcStartDateWrapper").hide();
            $("#AddInto").show();

            //kendoTreeList.setOptions({
            //    editable:  {
            //        move: true,
            //        mode: 'incell'
            //    }
            //});

            //kendoTreeList.refresh(false);

            $('#dropInto').show();
            $('#ContextInto').show();

        }
        else {
            jQuery.each(columns,(idx, column) => {
                kendoTreeList.hideColumn(column);
            });
            jQuery.each(notColumns, (idx, column) => {
                kendoTreeList.showColumn(column);
            });

            $("#CalcEndDateWrapper").show();
            $("#CalcStartDateWrapper").show();
            $("#AddInto").hide();

            //kendoTreeList.setOptions({
            //    editable: {
            //        move: true,
            //        mode: 'incell'
            //    }
            //});

            //kendoTreeList.refresh(false);

            $('#dropInto').hide();
            $('#ContextInto').hide();
        }
        CalculateByPredecessorChangeGantt(CalculateByPredecessor);
        kendo.ui.progress(kendoTreeList.element, false);
        lockColumns();
    }

    function change(e) {
        if (e.action == "itemchange") {
            e.items[0].dirtyFields = e.items[0].dirtyFields || {};
            e.items[0].dirtyFields[e.field] = true;
        }
    }

    function saveFormClick() {
        var treelist = $("#treelist").data('kendoTreeList');

        treelist.dataSource.sync().then(() => {
            taskDeleted = false;
            taskEdited = false;
            taskInserted = false;
            setSave();
            loadJobInfo();
        });
    }

    function CopyTaskButtonClick() {
        var treeList = $("#treelist").data("kendoTreeList");

        var selected = treeList.select();
        treeList.clearSelection();
        var insertIndex = 0;
        if (selected.length > 0) {
            var dataItem = treeList.dataItem(selected[selected.length - 1]);
            insertIndex = treeList.dataSource.indexOf(dataItem) + 1;
        }
        var selected = selected.filter((i) => {
            return i  % 2 === 0
        });

        selected.each(function (idx, row) {
            var dataItem = treeList.dataItem(row);
            var end = treeList.dataSource.data().length;

            var newItem = treeList.dataSource.insert(insertIndex++, {
                TaskCode: dataItem.TaskCode,
                TaskDescription: dataItem.TaskDescription,
                Milestone: dataItem.Milestone,
                EmployeeCode: dataItem.EmployeeCode,
                JobOrder: dataItem.JobOrder,
                JobDays: dataItem.JobDays,
                TaskStartDate: dataItem.TaskStartDate,
                JobRevisedDate: dataItem.JobRevisedDate,
                RevisedDueTime: dataItem.RevisedDueTime,
                JobDueDate: dataItem.JobDueDate,
                DueTime: dataItem.DueTime,
                JobCompletedDate: dataItem.JobCompletedDate,
                EstimateFunction: dataItem.EstimateFunction,
                TaskStatus: dataItem.TaskStatus,
                DueDateLock: dataItem.DueDateLock,
                FunctionDescription: dataItem.FunctionDescription,
                DueDateComments: dataItem.DueDateComments,
                RevisionDateComments: dataItem.RevisionDateComments,
                JobNumber: dataItem.JobNumber,
                JobComponentNumber: dataItem.JobComponentNumber,
                TemporaryCompleteDate: dataItem.TemporaryCompleteDate,
                TrafficPhaseID: dataItem.TrafficPhaseID,
                PhaseOrder: dataItem.PhaseOrder,
                PhaseDescription: dataItem.PhaseDescription,
                JobHours: dataItem.JobHours,
                Predecessor: dataItem.Predecessor,
                FunctionComments: dataItem.FunctionComments,
                TrafficRole: dataItem.TrafficRole,
                EmployeeCodes: dataItem.EmployeeCodes,
                ClientContactName: dataItem.ClientContactName,
                ClientContact: dataItem.ClientContact,
                ParentTaskSequenceNumber: dataItem.ParentTaskSequenceNumber
            });

            newItem.set('EmployeeCode', dataItem.EmployeeCode);
            newItem.set('EmployeeName', dataItem.EmployeeName);
        });

        treeList.dataSource.sync().then(() => {
            var items = treeList.dataSource.data();

            updateItemsOrder(items).then(() => {
                var data = treeList.dataSource.data();
                var newRow = treeList.items().filter("[data-uid='" + data[insertIndex - 1].uid + "']");

                var columnIdx = 0;

                for (i = 0; i < treeList.columns.length - 1; i++) {
                    if (treeList.columns[i].field == 'TaskDescription') {
                        columnIdx = i;
                        break;
                    }
                }

                setTimeout(() => {
                    treeList.select(newRow);
                    treeList.editCell(newRow[0].cells[columnIdx]);
                }, 250);
            });
        });
    }

    async function toggleAll(e) {
        var treelist = $('#treelist').data("kendoTreeList");
        var checked = e.target.checked;
        kendo.ui.progress(treelist.element, true);
        if (checked) {
            var tr = $("#treelist [data-uid]");
            treelist.select(tr);
        }
        else {
            treelist.clearSelection();
        }
        kendo.ui.progress(treelist.element, false);
    }

    function cancelChanges() {
        $('#treelist').data("kendoTreeList").cancelChanges();
        taskDeleted = false;
        taskEdited = false;
        taskInserted = false;
        setSave();
    }

    function refresh() {
        refreshGrid();
        taskDeleted = false;
        taskEdited = false;
        taskInserted = false;
        setSave();
    }

    function edit(e) {
        if (selectingPreds) {
            finishSelectPredecessors();
        }

        if (e.model.HasChildren && e.container.find("input[name='TaskDescription']").length < 1 &&
            e.container.find("textarea[name='FunctionComments']").length < 1 &&
            e.container.find("textarea[name='RevisionDateComments']").length < 1 &&
            e.container.find("textarea[name='DueDateComments']").length < 1) {
            this.closeCell();
        }

        e.container.find("input").bind("focus", function () {
            if (this.style.display != "none") {
                var element = this;
                setTimeout(function () {
                    if (element.select) {
                        element.select();
                    }
                },0);
            }
        });
        setSave();
    }
    function treeListDataBound(e) {
        var treelist = $('#treelist').data("kendoTreeList");
        var column = treelist.columns[treelist.columns.length - 1];
        if (column.attributes && column.attributes.class && column.attributes.class.indexOf(' lastColumn') < 0) {
            column.attributes.class = column.attributes.class + ' lastColumn';
            if (column.headerAttributes) {
                column.headerAttributes.class = column.headerAttributes.class + ' lastColumn';
            }
        }
    }
    //editors
    function priorityEditor(container, options) {
        var dataSource = [{ Code: 1, Name: 'HH' },
        { Code: 2, Name: 'H' },
        { Code: 3, Name: '--' },
        { Code: 4, Name: 'L' },
        { Code: 5, Name: 'LL' }];
        $('<input class="combo-40" data-value-field="Code" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                dataTextField:   "Name",
                dataValueField: "Code",
                valuePrimitive: true,
                dataSource: dataSource
            });
    }
    function dateEditor(container, options) {
        let item;
        item = $('<input id="ActiveDatePicker" class="date-sm" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        item.kendoDatePicker({
            parseFormats:   ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
            format: 'MM/dd/yyyy',
            open: (e) => {
                if (options.field == 'JobCompletedDate' && options.model.JobCompletedDate == null) {
                    options.model.JobCompletedDate = new Date();
                    options.model.dirty = true;
                    options.model.dirtyFields.JobCompletedDate =  true;
                    container.addClass("k-dirty-cell");
                    e.sender.value(options.model.JobCompletedDate);
                    e.sender.trigger("change")
                }
            },
            change: function (e) {
                if (options.field == 'TaskStartDate') {
                    if (new Date(options.model.JobRevisedDate.toDateString()) < new Date(options.model.TaskStartDate.toDateString())) {
                        options.model.set("JobRevisedDate", null);
                        return;
                    }
                }
                if (options.field == 'JobRevisedDate') {
                    //var dataItem = e.sender.dataItem();
                    if (new Date(options.model.JobRevisedDate.toDateString()) < new Date(options.model.TaskStartDate.toDateString())) {
                        showKendoAlert('Due Date must be after Start Date.');
                        options.model.set("JobRevisedDate", null);
                        return;
                    }

                    var className = getDueDateClass(options.model);

                    let selector = `div[taskduedate-cell='${options.model.AlertId}']`;
                    //due date was manually entered
                    if ($(selector).length) {
                        $(selector).closest("td").removeClass("ps-standard-light-pink");
                        $(selector).closest("td").removeClass("ps-standard-light-orange");
                        $(selector).closest("td").removeClass("ps-standard-light-grey");
                        $(selector).closest("td").removeClass("ps-standard-light-green");
                        $(selector).closest("td").removeClass("ps-projected");

                        $(selector).closest("td").addClass(className);
                    } else {
                        //date picker was selected
                        $("td#treelist_active_element").removeClass("ps-standard-light-pink");
                        $("td#treelist_active_element").removeClass("ps-standard-light-orange");
                        $("td#treelist_active_element").removeClass("ps-standard-light-grey");
                        $("td#treelist_active_element").removeClass("ps-standard-light-green");
                        $("td#treelist_active_element").removeClass("ps-projected");

                        $("td#treelist_active_element").addClass(className);
                    }

                }

                if (options.model.JobDays == null && options.model.TaskStartDate != null && options.model.JobRevisedDate != null && (options.field == 'JobRevisedDate' || options.field == 'TaskStartDate')) {

                    getDays(options.model.TaskStartDate, options.model.JobRevisedDate).then((d) => {
                        options.model.set("JobDays", d);
                    });
                }
                container.addClass('ps-standard-light-green');
            }
        });

        item.bind("focus", (() => {
                setTimeout(function () {
                    $('#ActiveDatePicker').select();
                },0);
        }));
        item.bind("mousedown", (e) => { e.stopPropagation(); });
        item.bind('keydown', (e) => {
            if ((e.key == 'ArrowLeft' || e.key == 'ArrowRight') && e.shiftKey) {
                e.stopPropagation();
            }
        });
    }
    function timeEditor(container, options) {
        $('<input data-text-field="' + options.field + '" data-value-field="' + options.field + '" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
                        .kendoTimePicker({
                            parseFormats:   ["0", "hh:mm tt"],
                animation: false,
                interval: 15,
                format: "hh:mm tt",
                dateInput: false,
                change: (() => {
                    this.value(kendo.toString(this.value(), "hh:mm tt"));
                })
            });
    }
    function phaseDropList(container, options) {
        $('<input class="combo-40" data-value-field="Code" data-bind="value:' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                dataTextField:   "Name",
                dataValueField: "Code",
                filter: "contains",
                filtering: function (ev) {
                    var filterValue = ev.filter != undefined ? ev.filter.value : "";
                    ev.preventDefault();

                    this.dataSource.filter({
                        logic: "or",
                        filters: [
                            {
                                field: "Name",
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
                optionLabel: { Name: 'Please Select...', Code: null },
                valuePrimitive: true,
                clearButton: true,
                dataSource: new kendo.data.DataSource({
                transport: {
                    read: "@Url.Content("~/ProjectManagement/ProjectSchedule/SearchPhases")",
                    dataType: "json",
                    data: {
                        IncludeNoFilter: false,
                        IncludeNone: false
                    },
                    parameterMap: function (data, type) {
                        return data;
                    }
                }
            }),
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    if (dataItem) {
                        options.model.set("TrafficPhaseID", dataItem.Code);
                        options.model.set("PhaseDescription", dataItem.Code?dataItem.Name:'');
                    }
                    else {
                        options.model.set("TrafficPhaseID", null);
                        options.model.set("PhaseDescription", '');
                    }
            }
        });
    }

    function taskCodeDropList(container, options) {
        $('<input class="combo-40" name="' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                dataTextField:   "Code",
                dataValueField: "Code",
                filter: "startswith",
                template: taskCodeItemTemplate,
                valuePrimitive: true,
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: "@Url.Content("~/Utilities/SearchTasks")",
                        dataType: "json",
                        data: {
                            IncludeNoFilter: false,
                            IncludeNone: false
                        },
                        parameterMap: function (data, type) {
                            return data;
                        },
                        sort: {
                            field: 'Code',
                            dir: 'asc'
                        },

                    }
                }),
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    options.model.set("TaskDescription", dataItem.Name);
                    options.model.set("JobOrder", dataItem.Order);
                    options.model.set("EstimateFunction", dataItem.EST_FNC_CODE);
                    options.model.set("FunctionDescription", dataItem.FNC_DESCRIPTION);
                },
                open: adjustDropDownWidth
            }).data('kendoDropDownList');
    }

    function taskDescriptionEditor(container, options) {
        var fubar = $('<input autocomplete="off" type="text" id="ActiveTaskDescriptionEditor" maxlength="40" class="k-textbox combo-40" name="' + options.field + '"/>')
            .appendTo(container);

        $('#ActiveTaskDescriptionEditor').data('options', options);
        $('#ActiveTaskDescriptionEditor').on('change', options, ((e) => {
            var options = $('#ActiveTaskDescriptionEditor').data('options');
            options.model.TaskCode = '';
        }))
            .on('focus', (() => {
                setTimeout(() => {
                    fubar.select();
                }, 0);
            })).on('click', () => {
            })
            .on('mousedown', (e) => {
                e.stopPropagation();
            })
            .on('keydown', (e) => {
                if ((e.key == 'ArrowLeft' || e.key == 'ArrowRight') && e.shiftKey) {
                    e.stopPropagation();
                }
            });
    }

    function estimateFunctionDropList(container, options) {
        $('<input class="combo-40" name="' + options.field + '"/>')
            .appendTo(container)
            .kendoComboBox({
                dataTextField: "Name",
                dataValueField: "Code",
                filter: "contains",
                filtering: function (ev) {
                    var filterValue = ev.filter != undefined ? ev.filter.value : "";
                    ev.preventDefault();

                    this.dataSource.filter({
                        logic: "or",
                        filters: [
                            {
                                field: "Name",
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
                valuePrimitive: true,
                template: taskCodeItemTemplate,
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: "@Url.Content("~/Utilities/SearchEstimateFunctions")",
                        dataType: "json"
                    },
                    schema: {
                        model: {
                            fields: {
                                Code: { type: "string" },
                                Name: { type: "string" }
                            }
                        }
                    }
                }),
                change: function (e) {
                    var dataItem = e.sender.dataItem();
                    if (dataItem != undefined) {
                        options.model.set("FunctionDescription", dataItem.Name);
                    } else {
                        options.model.set("FunctionDescription", '');
                    }
                    
                },
                open: adjustDropDownWidth
            }).data('kendoDropDownList');
    }

    function statusDropList(container, options) {
        $('<input class="combo-40" required name="' + options.field + '"/>')
            .appendTo(container)
                        .kendoComboBox({
                            dataTextField:   "Name",
                            dataValueField: "Code",
                            filter: "startswith",
                            filtering: function (ev) {
                                var filterValue = ev.filter != undefined ? ev.filter.value : "";
                                ev.preventDefault();

                                this.dataSource.filter({
                                    logic: "or",
                                    filters: [
                                        {
                                            field: "Name",
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
                            valuePrimitive: true,
                            dataSource: new kendo.data.DataSource({
                                data: gStatus
                            }),
                            change: function (e) {
                                //var dataItem = e.sender.dataItem();
                                //options.model.set("PhaseDescription", dataItem.Name);
                            }
                        });

    }

    function textAreaEditor(container, options) {
        var textArea = $('<textarea id="ActiveTextArea" class="k-textbox text-xl" name="' + options.field + '" rows="1"/>').appendTo(container);

        textArea.on('focus', (() => {
            setTimeout(() => {
                $('#ActiveTextArea').select();
            },50);
        }));
    }

    function textAreaCommentEditor(container, options) {
        var textArea = $('<textarea id="ActiveTextArea" class="k-textbox text-xl" name="' + options.field + '" rows="1"/>').appendTo(container);

        textArea.on('dblclick', (e) => {
            setTaskComments(options.model.SequenceNumber);
        })
        .on('focus', () => {
            setTimeout(() => {
                $('#ActiveTextArea').select();
            }, 50);
        })
        .on('mousedown', (e) => { e.stopPropagation(); })
        .on('keydown', (e) => {
            if ((e.key == 'ArrowLeft' || e.key == 'ArrowRight') && e.shiftKey) {
                e.stopPropagation();
            }
        });
    }

    function getModelData() {
        return psModel;
    }

    function contactMultiSelect(container, options) {
        let open = false;
        var ms = $('<select class="combo-40" name="' + options.field + '"/>')
            .appendTo(container)
            .kendoMultiSelect({
                valuePrimitive: true,
                required: false,
                filter: "contains",
                dataTextField:   "Name",
                dataValueField: "Code",
                open: (() => { open = true; }),
                close: (() => { open = false; }),
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: "@Url.Content("~/ProjectSchedule/SearchContacts")",
                            dataType: "json",
                            data: {
                                ClientCode: psModel.ClientCode,
                                DivCode: psModel.DivisionCode,
                                ProdCode: psModel.ProductCode
                            },
                        },
                        parameterMap: function (data, type) {
                            return data;
                        }
                    }
                }),
                change: (e) => {
                    var dataItem = e.sender.dataItems();
                    var nameArray = [];

                    $.each(dataItem,(i, v) => {
                        nameArray.push(v.Name);
                    });
                    options.model.ClientContactName = nameArray.join(',');

                    options.model.ClientContact = e.sender.value().join(",");

                    setSave();
                }
            }).data('kendoMultiSelect');

        ms.input
            .on("keydown", function (e) {
                if (e.keyCode === 9 && open) {
                    selectItem(ms);
                }
            });
    }


    function employeeMultiSelect(container, options) {
        let open = false;
        let holdOpen = false;
        let oneShot = true;

        var ms = $('<select id="EmployeeMultiSelect" class="combo-40" name="' + options.field + 's' + '"/>')
            .appendTo(container)
            .kendoMultiSelect({
                valuePrimitive: true,
                required: false,
                open: (() => { open = true; }),
                close: ((e) => {
                    if (holdOpen && oneShot) {
                        holdOpen = false;
                        oneShot = false;
                        e.preventDefault();
                    }
                    else {
                        open = false;
                    }

                    holdOpen = false;
                }),
                filter: "contains",
                dataTextField: "NameOnly",
                dataValueField: "Code",
                autoClose: false,
                headerTemplate: '<div><input type="checkbox" id="FilterByRole" class="k-checkbox" data-bind="checked: checkboxChecked, events: { change: clickHandler}" /><label class= "k-checkbox-label" style="font-weight:normal;font-style:italic" for="FilterByRole">Filter by role</label></div>',
                itemTemplate: employeeImageTemplate,
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: "@Url.Content("~/Utilities/SearchEmployee")",
                            data: (() => {
                                var filterRole = $('#EmployeeMultiSelect').data('filterRole');
                                var options = $('#EmployeeMultiSelect').data('options');
                                if (filterRole) {
                                    return {
                                        Role: options.model.TrafficRole ? options.model.TrafficRole : options.model.EstimateFunction,
                                        TaskCode: options.model.TaskCode
                                    };
                                }
                            })
                        },
                        dataType: "json"
                    },
                    requestEnd: (e) => {
                        var employeeMissing = false;
                        var multiSelect = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                        var employees = multiSelect.value();

                        if (e.response) {
                            $.each(employees, (i, v) => {
                                if (!e.response.find(x => x.Code === v)) {
                                    employeeMissing = true;
                                }
                            });
                        }

                        if (!e.response || e.response.length === 0 || employeeMissing) {
                            var checkbox = $('#FilterByRole');
                            var checked = checkbox.prop("checked");
                            $('#EmployeeMultiSelect').data('POS', multiSelect.value());

                            //if (!checked) {
                            //    checkbox.trigger("click");
                            //    e.preventDefault(true);
                            //}
                        }
                        else {
                            setTimeout(() => {
                                var POS = $('#EmployeeMultiSelect').data('POS');
                                if (POS) {
                                    var multiSelect = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                                    multiSelect.value(POS);
                                }
                            }, 50);
                        }
                    }

                }),
                //highlightFirst: false,
                change: (e) => {                   

                    var dataItem = e.sender.dataItems();
                    var nameArray = [];

                    $.each(dataItem, (i, v) => {
                        nameArray.push(v.NameOnly);
                    });
                    options.model.EmployeeName = nameArray.join(', ');
                    options.model.EmployeeCode = e.sender.value().join(", ");

                    setSave();            

                    //e.sender.input.val("");
                    //e.sender.dataSource.filter([]);
                }
            }).data('kendoMultiSelect');

        $('#EmployeeMultiSelect').data('options', options);

        $('#EmployeeMultiSelect').data('filterRole', false);

        ms.dataSource.read();

        var viewModel = kendo.observable({
            checkboxChecked: false,
            clickHandler: function (e) {
                var ms = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                $('#EmployeeMultiSelect').data('filterRole', e.data.checkboxChecked);

                ms.dataSource.read();
            }
        });
        kendo.bind($("#FilterByRole"), viewModel);

        ms.input.attr('autocomplete', 'off');

        ms.input
            .on("keydown", function (e) {
                if (e.keyCode === 9 && open) {
                    selectItem(ms);
                }
                else if (e.keyCode === 13 && open) {
                    selectItem(ms);
                    ms.input.val('');
                    return false;
                }
            });

        ms.input.on('copy', () => {
            var $temp = $("<input>");
            $("body").append($temp);
            $temp.val(ms.value().toString()).select();
            document.execCommand("copy");
            $temp.remove();
        });

        ms.input.on('paste', (e) => {
            if (window.clipboardData) {
                var pastedText = undefined;
                if (window.clipboardData && window.clipboardData.getData) { // IE
                    pastedText = window.clipboardData.getData('Text');
                } else if (e.clipboardData && e.clipboardData.getData) {
                    pastedText = e.clipboardData.getData('text/plain');
                }

                if (pastedText) {
                    ms.value(pastedText.split(','));
                }
            }
            else {
                if (navigator.clipboard.readText) {
                    navigator.clipboard.readText().then(
                        clipText => {
                            ms.value(clipText.split(','));
                            ms.trigger('change');
                        }).catch(e => {
                            console.error(e);
                        });
                }
            }
            return false;
        });

        $('.k-checkbox-label').on('click', (() => {
            holdOpen = true;
        }));
    }

    function selectItem(ms) {
        var list = $('#EmployeeMultiSelect-list.k-list-container.k-popup.k-group.k-reset.k-state-border-up')
        var selected = list.find('.k-item.k-state-focused');
        var offset = selected.data('offsetIndex');
        var dataItem = ms.dataSource.view()[offset];
        var value = ms.value();
        if (dataItem) {
            value.push(dataItem[ms.options.dataValueField]);
            ms.value(value);
            ms.trigger('change');
        }
    }
    function employeeCodeMultiSelect(container, options) {
        let open = false;
        let holdOpen = false;
        let oneShot = true;

        var ms = $('<select id="EmployeeMultiSelect" class="combo-40" name="' + options.field + 's' + '"/>')
            .appendTo(container)
            .kendoMultiSelect({
                valuePrimitive: true,
                filter: "startswith",
                required: false,
                open: (() => { open = true; }),
                close: ((e) => {
                    if (holdOpen && oneShot) {
                        holdOpen = false;
                        oneShot = false;
                        e.preventDefault();
                    }
                    else {
                        open = false;
                    }

                    holdOpen = false;
                }),
                dataTextField: "Code",
                dataValueField: "Code",
                autoClose: false,
                headerTemplate: '<div><input type="checkbox" id="FilterByRole" class="k-checkbox" data-bind="checked: checkboxChecked, events: { change: clickHandler}" /><label class= "k-checkbox-label" style="font-weight:normal;font-style:italic" for="FilterByRole">Filter by role</label></div>',
                itemTemplate: employeeCodeImageTemplate,
                dataSource: new kendo.data.DataSource({
                    transport: {
                        read: {
                            url: "@Url.Content("~/Utilities/SearchEmployee")",
                            data: (() => {
                                var filterRole = $('#EmployeeMultiSelect').data('filterRole');
                                var options = $('#EmployeeMultiSelect').data('options');
                                if (filterRole) {
                                    return {
                                        Role: options.model.TrafficRole ? options.model.TrafficRole : options.model.EstimateFunction,
                                        TaskCode: options.model.TaskCode
                                    };
                                }
                            })
                        },
                        dataType: "json"
                    },
                    sort: {
                        field: 'Code',
                        dir: 'asc'
                    },
                    requestEnd: (e) => {
                        var employeeMissing = false;
                        var multiSelect = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                        var employees = multiSelect.value();

                        if (e.response) {
                            $.each(employees, (i, v) => {
                                if (!e.response.find(x => x.Code === v)) {
                                    employeeMissing = true;
                                }
                            });
                        }

                        if (!e.response || e.response.length === 0 || employeeMissing) {
                            var checkbox = $('#FilterByRole');
                            var checked = checkbox.prop("checked");
                            $('#EmployeeMultiSelect').data('POS', multiSelect.value());
                            //if (!checked) {
                            //    checkbox.trigger("click");
                            //    e.preventDefault(true);
                            //}
                        }
                        else {
                            setTimeout(() => {
                                var POS = $('#EmployeeMultiSelect').data('POS');
                                if(POS) {
                                    var multiSelect = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                                    multiSelect.value(POS);
                                }
                            }, 50);
                        }
                    }

                }),
                change: (e) => {

                    var dataItem = e.sender.dataItems();
                    var nameArray = [];

                    $.each(dataItem, (i, v) => {
                        nameArray.push(v.NameOnly);
                    });
                    options.model.EmployeeName = nameArray.join(', ');

                    options.model.EmployeeCode = e.sender.value().join(", ");

                    setSave();

                    //e.sender.input.val("");
                    //e.sender.dataSource.filter([]);

                }
            }).data('kendoMultiSelect');

        $('#EmployeeMultiSelect').data('options', options);
        $('#EmployeeMultiSelect').data('filterRole', false);

        var viewModel = kendo.observable({
            checkboxChecked: false,
            clickHandler: function (e) {
                var ms = $('#EmployeeMultiSelect').data('kendoMultiSelect');
                $('#EmployeeMultiSelect').data('filterRole', e.data.checkboxChecked);

                ms.dataSource.read();
            }
        });
        kendo.bind($("#FilterByRole"), viewModel);

        ms.input.attr('autocomplete', 'off');

        ms.input
            .on("keydown", function (e) {
                if (e.keyCode === 9 && open) {
                    selectItem(ms);
                }
                else if (e.keyCode === 13 && open) {
                    selectItem(ms);
                    ms.input.val('');
                    return false;
                }
            });

        ms.input.on('copy', () => {
            var $temp = $("<input>");
            $("body").append($temp);
            $temp.val(ms.value().toString()).select();
            document.execCommand("copy");
            $temp.remove();
        });

        ms.input.on('paste', (e) => {

            if (window.clipboardData) {
                var pastedText = undefined;
                if (window.clipboardData && window.clipboardData.getData) { // IE
                    pastedText = window.clipboardData.getData('Text');
                } else if (e.clipboardData && e.clipboardData.getData) {
                    pastedText = e.clipboardData.getData('text/plain');
                }

                if (pastedText) {
                    ms.value(pastedText.split(','));
                }
            }
            else {
                if (navigator.clipboard.readText) {
                    navigator.clipboard.readText().then(
                        clipText => {
                            ms.value(clipText.split(','));
                            ms.trigger('change');
                        }).catch(e => {
                            console.error(e);
                        });
                }
            }

            return false;
        });
        $('.k-checkbox-label').on('click', (() => {
            holdOpen = true;
        }));
    }

    /*
     * Templates
     */
    function priorityTemplate(dataItem) {
        var priority = ['', 'HH', 'H', '--', 'L', 'LL'];
        return '<span>' + priority[dataItem.Priority] + '</span>';
    }

    function dispersedHourTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.DispersedHours) {
            return '<div onClick="dispersedHourClick(' + dataItem.AlertId + ')"><a href="#">' + dataItem.DispersedHours + '</a></div>';
        }
        else if (dataItem.HasChildren == true && treeList.dataSource._aggregateResult[dataItem.id].DispersedHours && treeList.dataSource._aggregateResult[dataItem.id].DispersedHours.sum) {
            //var treeList = $("#treelist").data("kendoTreeList");
            return '<div>' + treeList.dataSource._aggregateResult[dataItem.id].DispersedHours.sum + '</div>';
        }

        return '<div onClick="dispersedHourClick(' + dataItem.AlertId + ')">&nbsp</div>'
    }

    function dispersedHourClick(id) {
        var URL = "";
        var thisTitle = "Hours";
        URL = 'ProjectManagement/Agile/HoursByAlertID/0/' + id;

        var treeList = $("#treelist").data("kendoTreeList");
        let row = treeList.select()[0].closest("tr");

        if (setSave()) {
            //this.showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(function () {
                    $('#saveButton').trigger('click');

                    setTimeout(() => {
                        openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                            reloadTaskList();
                            $("#treelist").data("kendoTreeList").select(row);
                        }));
                    }, 500);
                //})
                //.fail(function () {
                //    openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                //        reloadTaskList();
                //        $("#treelist").data("kendoTreeList").select(row);
                //    }));
                //});
        }
        else {
            openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                reloadTaskList();
                $("#treelist").data("kendoTreeList").select(row);
            }));
        }
    }

    function employeeCodeImageTemplate(dataItem) {
        var rv = '<img class="k-state-default" src="@Href("~/Utilities/EmployeePicture/")' + dataItem.Code + '" style="height:25px;width:25px;border-radius:5px;margin:5px 5px 5px 5px; float:left"></img>';
        rv = rv + '<div><span class="k-state-default">' + dataItem.Name;

        if (dataItem.Title) {
            rv = rv + '<p style="font-size:smaller">' + dataItem.Title + '</p>';
        }
        else {
            rv = rv + '<p style="font-size:smaller">&nbsp</p>';
        }

        rv = rv + '</span></div>';

        return rv;
    }

    function employeeImageTemplate(dataItem) {
        var rv = '<img class="k-state-default" src="@Href("~/Utilities/EmployeePicture/")' + dataItem.Code + '" style="height:25px;width:25px;border-radius:5px;margin:5px 5px 5px 5px; float:left"></img>';
        rv = rv + '<div><span class="k-state-default">' + dataItem.NameOnly;

        if (dataItem.Title) {
            rv = rv + '<p style="font-size:smaller">' + dataItem.Title + '</p>';
        }
        else {
            rv = rv + '<p style="font-size:smaller">&nbsp</p>';
        }

        rv = rv + '</span></div>';

        return rv;
    }

    function adjustDropDownWidth(e) {
        var listContainer = e.sender.list.closest(".k-list-container");
        listContainer.width(listContainer.width() + 150);
    }


    function taskCodeItemTemplate(dataItem) {
        return '<div><span>' + dataItem.Name + ' (' + dataItem.Code + ')</span></div>';
    }

    function functionCommentsImageTemplate(dataItem) {
        var js = "setTaskComments('" + dataItem.SequenceNumber + "')";
        return '<a href="javascript:void(0);" title="Comments"><div class="icon-background background-color-sidebar" onclick="' + js + '"><img src="@Url.Content("~/Images/Icons/White/256/messages.png")" class="icon-image" /></div></a>';
    }

    function clientContactsLinkTemplate(dataItem) {
        var clContacts = dataItem.ClientContact ? dataItem.ClientContact.split(",").join(", ") : 'Add';
        var js = 'void(0)';
        js = "setClientContacts('" + dataItem.TaskCode + "'," + dataItem.SequenceNumber + ")";

        if (dataItem.HasChildren == false) {
            return '<a href="javascript:' + js + '">' + clContacts + '</a>';
        }

        return '';
    }

    function taskDocumentsTemplate(dataItem){
        var iconColor = dataItem.HasDocuments ? 'standard-green' : 'standard-red';
        var title = dataItem.HasDocuments ? 'View Documents' : 'No Documents';
        var theID = "'DocImg_" + dataItem.SequenceNumber + "'";
        var fubar = ",'" + dataItem.TaskCode + "','" + dataItem.TaskDescription + "'";

        return '<a href="javascript:void(0);" title="Documents"> <div class="icon-background background-color-sidebar ' + iconColor + '" title="' + title + '" onclick="setTaskDocuments(' + dataItem.SequenceNumber + fubar + ',' + theID + ',' + @Html.Raw(Json.Encode(CInt(AdvantageFramework.Database.Entities.DocumentLevel.Task))) + ')"> <img src="@Url.Content("~/Images/Icons/White/256/documents_empty.png")" class="icon-image" /></div></a>';
    }

    function employeesImageTemplate(dataItem) {
        var theID = 'EmpImg_' + dataItem.SequenceNumber;
        var js = 'void(0)';

@if (Model.CanUserEdit) Then
    @<text>js = "setEmployeeDlg(" + dataItem.JobNumber + "," + dataItem.JobComponentNumber + ",'" + dataItem.TaskCode + "'," + dataItem.SequenceNumber + ")";</text>
End If

                    if (dataItem.HasChildren == false) {
                        return '<a href="javascript:void(0);" title="Employees" class="spacekeyselect" ><div Class="icon-background background-color-sidebar " style="background:00BCD4 !important;" onclick="' + js+'"><img src="@Url.Content("~/Images/Icons/White/256/users.png")" Class="icon-image" /></div></a>';
        }

        return '';
    }

    function imageKeyPress(e) {
        this.showKendoAlert('keypress');
    }

    function setEmployeeDlg(JobNumber, JobComponentNumber, TaskCode, SequenceNumber) {
        if (setSave()) {
            //this.showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
            //    .done(function () {
                    $('#saveButton').trigger('click');
                    setTimeout(() => {
                        setEmployees(JobNumber, JobComponentNumber, TaskCode, SequenceNumber);
                    }, 500);
                //})
                //.fail(function () {
                //    setEmployees(JobNumber, JobComponentNumber, TaskCode, SequenceNumber);
                //});
        }
        else {
            setEmployees(JobNumber, JobComponentNumber, TaskCode, SequenceNumber);
        }
    }

    function estimateFunctionTemplate(dataItem) {
        if (dataItem.FunctionDescription) {
            return dataItem.FunctionDescription;
        }

        return '';
    }

    function employeesNameTextTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.EmployeeName) {
            return '<span>' + dataItem.EmployeeName + '</span>';
        }

        return '';
    }

    function employeesCodeTextTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.EmployeeName) {
            return '<span>' + dataItem.EmployeeCode + '</span>';
        }

        return '';
    }

    function contactsNameTextTemplate(dataItem) {
        if (dataItem.ClientContactName) {
            return '<span>' + dataItem.ClientContactName + '</span>';
        }

        return '';
    }

    function contactsCodeTextTemplate(dataItem) {
        if (dataItem.ClientContactName) {
            return '<span>' + dataItem.ClientContact + '</span>';
        }

        return '';
    }

    function startDateTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.TaskStartDate) {
            return kendo.toString(kendo.parseDate(dataItem.TaskStartDate), "MM/dd/yyyy");
        }
        else if (dataItem.HasChildren == true && treeList.dataSource._aggregateResult[dataItem.id].TaskStartDate && treeList.dataSource._aggregateResult[dataItem.id].TaskStartDate.min) {
            return kendo.toString(kendo.parseDate(treeList.dataSource._aggregateResult[dataItem.id].TaskStartDate.min), "MM/dd/yyyy");
        }

        return '';
    }

    function dueDateTemplate(dataItem) {
        let dueDate = '';
        let dueDateFormated = '';
        if (dataItem.HasChildren == false && dataItem.JobRevisedDate) {

            dueDate = kendo.toString(kendo.parseDate(dataItem.JobRevisedDate), "MM/dd/yyyy");

            dueDateFormatted = '<div style="padding-left:3px;" taskDueDate-cell=' + dataItem.AlertId + '>' + dueDate + '</div>';

            return dueDateFormatted;
        }
        else if (dataItem.HasChildren == true && treeList.dataSource._aggregateResult[dataItem.id].JobRevisedDate && treeList.dataSource._aggregateResult[dataItem.id].JobRevisedDate.max) {
            return kendo.toString(kendo.parseDate(treeList.dataSource._aggregateResult[dataItem.id].JobRevisedDate.max), "MM/dd/yyyy");
        }

        return '';
    }

    function getDueDateClass(dataItem) {
        let taskClass = '';


        if (dataItem.JobRevisedDate != null) {
            let IsWeekendDate = IsWeekend(dataItem.JobRevisedDate);
            let TaskDateDiff = DateDiff(dataItem.JobRevisedDate);

            var today = new Date(new Date().toLocaleDateString());

            if (dataItem.JobCompletedDate != null || dataItem.HasChildren) {
                taskClass = '';
            } else if (TaskDateDiff < 0) {
                taskClass = 'ps-standard-light-pink';
            } else if (dataItem.JobRevisedDate.valueOf() === today.valueOf()) {
                taskClass = 'ps-standard-light-orange';
            } else if (IsWeekendDate && TaskDateDiff > 0) {
                taskClass = 'ps-standard-light-grey';
            } else if (TaskDateDiff > 0 && TaskDateDiff <= 7) {
                taskClass = 'ps-projected';
            } else {
                taskClass = 'ps-standard-light-green';
            }
        }

        return taskClass;
    }

    function IsWeekend(DueDate) {
        let day = DueDate.getDay();

        if (day == 0 || day == 6) {
            return true;
        }

        return false;
    }

    function DateDiff(DueDate) {
        const date1 = Date.now();
        const date2 = DueDate;
        const diffTime = Math.abs(date2 - date1);
        const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24)); 
        if (DueDate.setHours(0, 0, 0, 0) >= (new Date(date1)).setHours(0,0,0,0)) {
            return diffDays;
        }
        return 0 - diffDays;
    }

    function originalDueDateTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.JobDueDate) {
            return kendo.toString(kendo.parseDate(dataItem.JobDueDate), "MM/dd/yyyy");
        }

        return '';
    }

    function completedDateTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.JobCompletedDate) {
            return kendo.toString(kendo.parseDate(dataItem.JobCompletedDate), "MM/dd/yyyy");
        }

        return '';
    }

    function tempCompletedDateTemplate(dataItem) {
        if (dataItem.HasChildren == false && dataItem.TemporaryCompleteDate) {
            return kendo.toString(kendo.parseDate(dataItem.TemporaryCompleteDate), "MM/dd/yyyy");
        }

        return '';
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

    var lockAdd = false;

    function AddTask(location) {

        if (!$('#ScheduleWrap').is(':visible')) {
            gridClick().then(() => {
                _AddTask(location)
            });
        }
        else {
            _AddTask(location)
        }
    }

    function _AddTask(location) {
        if (lockAdd === true) {
            return;
        }

        lockAdd = true;
        var treeList = $('#treelist').data("kendoTreeList");
        var selected = treeList.select();
        treeList.clearSelection();

        let index = 0;

        if (selected && selected.length > 0) {
            var dataItem = treeList.dataItem(selected[0]);
            var myData = treeList.dataSource.data();

            var currentRowIndex = -1;

            for (let index = 0; index < myData.length; index++) {
                if (myData[index].SequenceNumber === dataItem.SequenceNumber) {
                    currentRowIndex = index;
                    break;
                }
            }

            //var currentRowIndex = $(selected[0]).closest("tr").index();
            var newItem;
            if (location === 0) {
                var newItem = treeList.dataSource.insert(currentRowIndex, {});
                newItem.set('ParentTaskSequenceNumber', dataItem.ParentTaskSequenceNumber);
            }
            else if (location === 2) {
                var newItem = treeList.dataSource.insert(currentRowIndex, {});
                newItem.set('ParentTaskSequenceNumber', dataItem.SequenceNumber);
            }
            else {
                var newItem = treeList.dataSource.insert(currentRowIndex + 1, {});
                newItem.set('ParentTaskSequenceNumber', dataItem.ParentTaskSequenceNumber);
            }

            newItem.set('TaskStatus', 'P');
            newItem.set('JobDueDate', null);
            newItem.set('JobRevisedDate', null);
            newItem.set('TaskStartDate', null);
            newItem.set('JobCompletedDate', null);
            newItem.set('TemporaryCompleteDate', null);
            newItem.set('JobRevisedDate', null);

            newItem.set('JobOrder', dataItem.JobOrder);

        }
        else {
            var currentRowIndex = treeList.dataSource.total();
            var dataItem = treeList.dataSource.data()[treeList.dataSource.total() - 1];
            //var newItem = treeList.dataSource.insert(currentRowIndex, {});
            var newItem = treeList.dataSource.add({});
            newItem.set('TaskStatus', 'P');
            newItem.set('JobDueDate', null);
            newItem.set('JobRevisedDate', null);
            newItem.set('TaskStartDate', null);
            newItem.set('JobCompletedDate', null);
            newItem.set('TemporaryCompleteDate', null);
            newItem.set('JobRevisedDate', null);

            if (dataItem !== undefined) {
                newItem.set('JobOrder', dataItem.JobOrder);
            }

            index = treeList.dataSource.data().length - 1;
        }

        treeList.dataSource.sync().then(() => {
            var items = treeList.dataSource.data();

            updateItemsOrder(items).then(() => {
                var data = treeList.dataSource.data();
                var max = {
                    SequenceNumber: -1
                };

                for (var i = 0; i < data.length; i++) {
                    if (data[i].SequenceNumber > max.SequenceNumber) {
                        max = data[i];
                    }
                }


                var newRow = treeList.items().filter("[data-uid='" + max.uid + "']");

                var columnIdx = 0;

                for (i = 0; i < treeList.columns.length - 1; i++) {
                    if (treeList.columns[i].field == 'TaskCode') {
                        columnIdx = i;
                        break;
                    }

                    if (treeList.columns[i].field == 'TaskDescription') {
                        columnIdx = i;
                    }
                }

                setTimeout(() => {
                    treeList.select(newRow);
                    treeList.editCell(newRow[0].cells[columnIdx]);
                    lockAdd = false;
                }, 250);
            });
        });
    }

    function updateCheckBox() {
        taskEdited = true;
        setSave();
    }

    function exportToExcel(e) {
        let sheet = e.workbook.sheets[0];
        let rows = sheet.rows;
        let sheetColumns = [];
        let templatedColumns = ["Estimate Function", "Phase", "M/S", "Lock", "Employees"];
        let aggColumns = [];
        let footerIndexes = [];                

        //hardcoding the aggregates.
        //calling e.sender.dataSource.aggregate() to get the aggregates causes 
        //an error.  To recreate, set aggColumns = e.sender.dataSource.aggregate();
        //iterating through the aggColumns to update the field column below will throw the error
        //"after" the first export.  clicking export again throws the error.
        aggColumns.push({ field: "PostedHours", aggregate: "sum" });
        aggColumns.push({ field: "DispersedHours", aggregate: "sum" });
        aggColumns.push({ field: "JobDays", aggregate: "sum" });
        aggColumns.push({ field: "JobHours", aggregate: "sum" });       

        //update the aggregate "field" to be the column "title"
        for (let i = 0; i < aggColumns.length; i++) {
            let dataElement = $.grep(e.sender.columns, function (col) {
                return col.field == aggColumns[i].field;
            });

            if (dataElement.length > 0) {
                aggColumns[i].field = dataElement[0].title;
            }
        }

        let footerCnt = 0;
        let prevFooterIndex = 0;
        let hierDepth, minColCount, maxColCount;
        hierDepth = rows[0].cells[0].colSpan - 1;

        //setup preliminary data about the export hierarchy and columns
        for (let i = 0; i < rows.length; i++) {
            switch (rows[i].type) {
                case "header":
                    minColCount = rows[i].cells.length;
                    maxColCount = minColCount;

                    for (let k = 0; k < rows[i].cells.length; k++) {
                        sheetColumns.push({ columnIndex: k, columnTitle: rows[i].cells[k].value, dataField: "", dataColumnIndex: 0, dataColumnTemplate: kendo.template });
                    }
                    break;
                case "data":
                    if (rows[i].cells.length > maxColCount) {
                        maxColCount = rows[i].cells.length;
                    }
                    break;
                case "footer":
                    if (footerCnt == 0) {
                        footerIndexes.push({ index: i, size: 0 });
                        ++footerCnt;
                        prevFooterIndex = i;
                        break;
                    }

                    if (prevFooterIndex == i - 1) {
                        ++footerIndexes[footerCnt - 1].size;
                    }

                    prevFooterIndex = i;
                    break;
            }
        }

        //if (footerIndexes.length > 0) {
        //    sheet.rows.splice(footerIndexes[0].index, footerIndexes[0].size);
        //}
        
        for (let i = 0; i < sheetColumns.length; i++) {
            let idx = -1;
            let dataElement;

            idx = templatedColumns.indexOf(sheetColumns[i].columnTitle);
            if (idx !== -1) {
                dataElement = $.grep(e.sender.columns, function (col) {
                    return col.title == sheetColumns[i].columnTitle;
                });

                sheetColumns[i].dataColumnIndex = dataElement[0]["data-index"];
                sheetColumns[i].dataColumnTemplate = dataElement[0].template;
            }

            if (sheetColumns[i].columnTitle == "Lock" || sheetColumns[i].columnTitle == "M/S") {
                sheet.columns[hierDepth + sheetColumns[i].columnIndex].width = 50;
            }
        }

        for (let i = 0; i < rows.length; i++) {
            let row = rows[i];
            let len = row.cells.length;
            let levelPosition = len - minColCount;
            let dataItem;
            let ci = 0;

            switch (row.type) {
                case "header":                    
                    break; 
                case "data":
                    dataItem = $.grep(e.data, function (col) {
                        return col.Level == row.cells[levelPosition].value;
                    });

                    for (let k = 0; k < sheetColumns.length; k++) {
                        switch (sheetColumns[k].columnTitle) {
                            case "Estimate Function":
                                try {
                                    row.cells[levelPosition + sheetColumns[k].columnIndex].value = sheetColumns[k].dataColumnTemplate(dataItem[0]);
                                } catch (e) {
                                    console.error("ESTIMATE: ", e);
                                }

                                break;
                            case "Employees":
                                try {
                                    row.cells[levelPosition + sheetColumns[k].columnIndex].value = $(sheetColumns[k].dataColumnTemplate(dataItem[0])).text();//.replace("<span>", "").replace("</span>", "");
                                } catch (e) {
                                    console.error("EMPLOYEES ERROR: ", e);
                                }
                                break;
                            case "Client Contacts":
                                try {       
                                    if (ci === 0) {
                                        ci = sheetColumns[k].columnIndex
                                        row.cells[levelPosition + sheetColumns[k].columnIndex].value = dataItem[0].ClientContact;//.replace("<span>", "").replace("</span>", "");
                                    } else {
                                        row.cells[levelPosition + sheetColumns[k].columnIndex].value = dataItem[0].ClientContactName;//.replace("<span>", "").replace("</span>", "");
                                    }                                    
                                } catch (e) {
                                    console.error("CC ERROR: ", e);
                                }
                                break;
                            case "Phase":
                                try {
                                    row.cells[levelPosition + sheetColumns[k].columnIndex].value = sheetColumns[k].dataColumnTemplate(dataItem[0]);
                                } catch (e) {
                                    console.error("PHASE ERROR: ", e);
                                }

                                break;
                            case "M/S":
                                try {
                                    if (dataItem[0].Milestone === '1') {
                                        row.cells[levelPosition + sheetColumns[k].columnIndex].value = "TRUE";
                                    } else {
                                        row.cells[levelPosition + sheetColumns[k].columnIndex].value = "FALSE";
                                    }
                                    //row.cells[levelPosition + sheetColumns[k].columnIndex].value = row.cells[levelPosition + sheetColumns[k].columnIndex].value ? "TRUE" : "FALSE";
                                    //console.log(dataItem[0].Milestone);
                                } catch (e) {
                                    console.error("M/S: ", e);
                                }

                                break;
                            case "Lock":
                                try {                                    
                                    row.cells[levelPosition + sheetColumns[k].columnIndex].value = row.cells[levelPosition + sheetColumns[k].columnIndex].value ? "TRUE" : "FALSE";
                                } catch (e) {
                                    console.error("LOCK: ", e);
                                }

                                break;

                            case "Priority":
                                try {
                                    var priority = ['', 'HH', 'H', '--', 'L', 'LL'];
                                    row.cells[levelPosition + sheetColumns[k].columnIndex].value = priority[dataItem[0].Priority];
                                } catch (e) {
                                    console.error("Priority: ", e);
                                }

                                break;

                            case "Status":
                                try {
                                    if (dataItem[0].hasChildren === true) {
                                        row.cells[levelPosition + sheetColumns[k].columnIndex].value = "";
                                    }
                                } catch (e) {
                                    console.error("Status: ", e);
                                }

                                break;      
                        }
                    }

                    break;
                case "footer":
                    for (let k = 0; k < sheetColumns.length; k++) {                        
                        let idx = aggColumns.findIndex((col) => { return col.field === sheetColumns[k].columnTitle; });
                        if (idx !== -1) {
                            row.cells[levelPosition + sheetColumns[k].columnIndex].value = $(row.cells[levelPosition + sheetColumns[k].columnIndex].value).text();//.replace("<b>", "").replace("</b>", "");
                            row.cells[levelPosition + sheetColumns[k].columnIndex].textAlign = "right";
                        }
                    }
                    break;
            }
        }        
    }


    function exportGridWithTemplatesContent(e) {
        e.workbook.fileName = 'Job @Model.JobNumber.ToString.PadLeft(6, "0")-@Model.JobComponentNumber.ToString.PadLeft(2, "0")-Schedule.xlsx';           
        
        var data = e.data;
        var gridColumns = e.sender.columns;
        var sheet = e.workbook.sheets[0];
        var visibleGridColumns = [];
        var columnTemplates = [];
        var footerTemplates = [];
        var dataItem;
        // Create element to generate templates in.
        var elem = document.createElement('div');

        // Get a list of visible columns
        for (var i = 0; i < gridColumns.length; i++) {
            if (!gridColumns[i].hidden) {
                visibleGridColumns.push(gridColumns[i]);
            }
        }

        var foundEmployees = false;
        $.each(sheet.rows[0].cells, (i, v) => {
            var index;
            if (foundEmployees == false || v.value !== 'Employees') {
                index = visibleGridColumns.findIndex((o) => { return o.title === v.value; });

                if (v.value === 'Employees') {
                    foundEmployees = true;
                }

                if (visibleGridColumns[index].template) {
                    columnTemplates.push({ cellIndex: i + 1, template: kendo.template(visibleGridColumns[index].template), Title: visibleGridColumns[index].title });
                    if (visibleGridColumns[index].footerTemplate) {
                        footerTemplates.push({ cellIndex: i + 1, template: kendo.template(visibleGridColumns[index].footerTemplate), Title: visibleGridColumns[index].title, field: visibleGridColumns[index].field });
                    }
                }
            }
            else {
                var eCount = 0;
                $.each(visibleGridColumns, (ii, vv) => {
                    if (vv.title === v.value) {
                        eCount++;
                    }

                    if (eCount === 3 && vv.title === v.value) {
                        columnTemplates.push({ cellIndex: i + 1, template: kendo.template(vv.template), Title: vv.title });
                    }
                });
            }
        });

        // Traverse all exported rows.
        for (var i = 1; i < sheet.rows.length; i++) {
            var dataItem = data[i - 1];

            if (!dataItem) {
                var row = sheet.rows[i];

                for (var j = 0; j < footerTemplates.length; j++) {
                    var footerTemplate = footerTemplates[j];

                    elem.innerHTML = footerTemplate.template(e.sender.dataSource.aggregates().null[footerTemplate.field]);

                    row.cells[footerTemplate.cellIndex - 1].value = elem.textContent || elem.innerText || "";

                }

                continue;
            }

            var count = (dataItem.Level.match(/\./g) || []).length;
            var row = sheet.rows[i];

            // Get the data item corresponding to the current row.
            for (var j = 0; j < columnTemplates.length; j++) {
                var columnTemplate = columnTemplates[j];
                // Generate the template content for the current cell.
                elem.innerHTML = columnTemplate.template(dataItem);
                if (row.cells[columnTemplate.cellIndex + count] != undefined) {
                    if (columnTemplate.Title == 'M/S') {
                        sheet.columns[columnTemplate.cellIndex + count].width = 50;
                        row.cells[columnTemplate.cellIndex + count].value = dataItem.Milestone ? 'TRUE' : 'FALSE';
                    }
                    else if (columnTemplate.Title == 'Lock') {
                        sheet.columns[columnTemplate.cellIndex + count].width = 50;
                        row.cells[columnTemplate.cellIndex + count].value = dataItem.DueDateLock ? 'TRUE' : 'FALSE';
                    }
                    else {
                        // Output the text content of the templated cell into the exported cell.
                        row.cells[columnTemplate.cellIndex + count].value = elem.textContent || elem.innerText || "";
                    }
                }
            }
        }
    }

    function getDays(start, end) {
        let dfd = jQuery.Deferred();
        var data = {
            StartDate: start.toJSON(),
            EndDate: end.toJSON()
        };

        $.ajax({
            type: "GET",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetDays")",
            data: data,
            dataType: "json",
            success: (response) => {
                dfd.resolve(response);
            }
        });

        return dfd.promise();

    }

    function footerTemplate(data) {
        return "<b>" + (data.sum ? data.sum : '') + "</b>";
    }

    function lockColumns() {
        var kendoTreeList = $("#treelist").data("kendoTreeList")
        kendo.ui.progress(kendoTreeList.element, true);
        var lockedColumns = 0;
        kendoTreeList.columns.forEach((v, i, a) => {

            if (numberOfLockedColumns >= lockedColumns) {
                if (v.locked !== true) {
                    kendoTreeList.lockColumn(i);
                }

                if (v.hidden !== true) {
                    lockedColumns++;
                }
            }
            else {
                if (v.hidden !== true && v.locked == true) {
                    kendoTreeList.unlockColumn(i);
                }
            }
        });

        kendo.ui.progress(kendoTreeList.element, false);

    }

</script>

<script type="text/x-kendo-template" id="milestoneTemplate">

    @If Model.CanUserEdit = True Then
        @<div class="go-center" style="display:flex;">
            # var theID = 'IsMilestone_' + SequenceNumber; #
            #if(Milestone == true){#
            @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(True).HtmlAttributes(New With {.id = "#: theID #", .onchange = "updateCheckBox();"}).ToClientTemplate)
            #}else{#
            @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(False).HtmlAttributes(New With {.id = "#: theID #", .onchange = "updateCheckBox();"}).ToClientTemplate)
            #}#
        </div>

    Else

        @<div class="go-center">
            #if(Milestone == true){#
            <span class="glyphicon glyphicon-ok"></span>
            #}#
        </div>

    End If

</script>

<script type="text/x-kendo-template" id="dueDateLockTemplate">

    @If Model.CanUserEdit = True Then

        @<div class="go-center" style="display:flex;margin:0px">
            # var theID = 'DueDateLock_' + SequenceNumber; #
    #if(HasChildren == false){#
            #if(DueDateLock === 1){#
            @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(True).HtmlAttributes(New With {.id = "#: theID #", .onchange = "updateCheckBox();", .class = " k-fubar "}).ToClientTemplate)
            #}else{#
            @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(False).HtmlAttributes(New With {.id = "#: theID #", .onchange = "updateCheckBox();", .class = " k-fubar "}).ToClientTemplate)
            #}#
    #}#
        </div>

    Else

        @<div class="go-center">
            #if(DueDateLock === 1){#
            <span class="glyphicon glyphicon-ok"></span>
            #}#
        </div>

    End If

</script>
<script type="text/x-kendo-template" id="moveLeftOrRightTemplate">

    @If Model.CanUserEdit = True Then
        @<div>
            # var theID = 'TaskDesc_' + SequenceNumber; #
            # var moveL = treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber)) ? true : false; #
            # var levelNodes = treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber)) ? treeList.dataSource.childNodes(treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber))) : treeList.dataSource.rootNodes(); #
            # var moveR = levelNodes.indexOf(treeList.dataSource.get(SequenceNumber)) > 0 ? true : false; #
            # if(moveL === true) { #
            <a href="javascript:void(0);" onclick="moveLeft(this)">
                <img src="@Url.Content("~/Images/Icons/Grey/256/indent_decrease.png")" Class="icon-btn" />
            </a>
            # } #
            # if(moveR === true) { #
            <a href="javascript:void(0);" onclick="moveRight(this)">
                <img src="@Url.Content("~/Images/Icons/Grey/256/indent_increase.png")" class="icon-btn" />
            </a>
            # } #
            # if(moveR === false && moveL === false) { #
            <div class="icon-btn"></div>
            # } #
        </div>
    End If

</script>

<script type="text/x-kendo-template" id="linkedTemplate">
    # var theID = 'Link_' + SequenceNumber; #
    # var levels = Level.split('.'); #
    # var theLevel = levels[levels.length - 1]; #
    @(Html.Raw("# var onClick = " & If(Model.CanUserEdit, "!isSelectingPreds() ? 'linkItem(' + SequenceNumber + ', ' + !HasPredecessors + ')' : ''", "''") & "; #"))
    # var imgSrc = HasPredecessors == true ? 'link.png' : 'link_broken.png'; #
    #if(HasChildren == true || theLevel == "1"){#

    #} else {#
    <div onkeydown="linkKeyPress(event)">
        <a href="javascript:void(0);" onclick="#: onClick #" class="img-link">
            <img src="@Url.Content("~/Images/Icons/Grey/256/#: imgSrc #")" class="icon-btn" />
        </a>
    </div>
    #}#
</script>
<script type="text/javascript">
    function linkKeyPress(e) {
        if (e.keyCode == 32) {
            this.showKendoAlert('space bar');
        }
    }
</script>

<script type="text/x-kendo-template" id="selectPredsTemplate">
    # var theID = 'SelectPreds_' + SequenceNumber; #
    # var row = $('tr[data-uid=' + uid + ']'); #
    # var isSelecting = isSelectingPreds(); #
    # var isSelector = isSelecting && row.hasClass('pred-selector') ? true : false; #
    @(Html.Raw("# var js = " & If(Model.CanUserEdit, "isSelecting === true ? 'finishSelectPredecessors()' : 'selectPredecessors(' + SequenceNumber  + ')'", "''") & "; #"))
    #if(HasChildren == true){#

    #} else if (isSelecting == true && isSelector == false) {#
    <div class="go-center" style="display:flex;padding-left: 10px;">
        @(Html.Kendo().CheckBox().Name("SelectPredCheckBox").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
    </div>
    #} else {#
    <div class="select-preds-wrap">
        <a href="javascript:void(0);" onclick="#: js #" class="img-link" id="#: theID #">
            <img src="@Url.Content("~/Images/Icons/Grey/256/link_add.png")" class="icon-btn" />
        </a>
    </div>
    #}#

</script>
