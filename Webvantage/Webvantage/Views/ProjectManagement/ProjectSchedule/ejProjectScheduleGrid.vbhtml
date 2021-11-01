@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<div id="treegrid" style="border: 1px solid #CCC;"></div>

<link href="~/CSS/bootstrap.css" rel="stylesheet">
<script src="https://cdn.syncfusion.com/ej2/dist/ej2.min.js" type="text/javascript"></script>
<style>
    .e-rowcell {
        padding: 8px !important
    }
</style>
<script type="text/x-template" id="taskStatusTemplate">
    ${if (TaskStatus === "P")}
    <div>Pending</div>
    ${else}
    <div>Active</div>
    ${/if}
</script>
<script type="text/x-template" id="employeesImageTemplate">
    ${if (HasChildren == 0)}
    <div class="icon-background background-color-sidebar " style="background:00BCD4 !important;" onclick=${employeesImageTemplate(TaskCode,SequenceNumber)}>
        <img src="@Url.Content("~/Images/Icons/White/256/users.png")" class="icon-image" />
    </div>
    ${/if}
</script>

@*# var theID = 'Link_' + SequenceNumber; #
        # var levels = Level.split('.'); #
        # var theLevel = levels[levels.length - 1]; #
    @(Html.Raw("# var onClick = " & If(Model.CanUserEdit, "!isSelectingPreds() ? 'linkItem(' + SequenceNumber + ', ' + !HasPredecessors + ')' : ''", "''") & "; #"))
    onclick="#: onClick #"*@

<script type="text/x-template" id="linkedTemplate">
    ${if (HasChildren == 0)}
    <div onkeydown="linkKeyPress(event)">
        <a href="javascript:void(0);" class="img-link" onclick=${linkTemplate(SequenceNumber,HasPredecessors)}>
            ${if (HasPredecessors == 0)}
            <img src="@Url.Content("~/Images/Icons/Grey/256/link_broken.png")" class="icon-btn" />
            ${else}
            <img src="@Url.Content("~/Images/Icons/Grey/256/link.png")" class="icon-btn" />
            ${/if}
        </a>
    </div>
    ${/if}
</script>

<script type="text/x-template" id="moveLeftOrRightTemplate">
    @If Model.CanUserEdit = True Then
        @<div>
            ${if (true===true)}
            <a href="javascript:void(0);" onclick="moveLeft(this)">
                <img src="@Url.Content("~/Images/Icons/Grey/256/indent_decrease.png")" Class="icon-btn" />
            </a>
            ${/if }
            ${if (true===true)}
            <a href="javascript:void(0);" onclick="moveRight(this)">
                <img src="@Url.Content("~/Images/Icons/Grey/256/indent_increase.png")" class="icon-btn" />
            </a>
            ${/if }
        </div>
    End If
</script>
<script type="text/x-template" id="CommentsImageTemplate">
    <a href="javascript:void(0);" title="Comments">
        <div class="icon-background background-color-sidebar" onclick="TaskComments(${ SequenceNumber } )">
            <img src="@Url.Content("~/Images/Icons/White/256/messages.png")" class="icon-image" />
        </div>
    </a>
</script>

<script type="text/x-template" id="jobDaysTemplate">
    ${if (HasChildren == 0)}
    <span>${JobDays}</span>
    ${/if}
</script>

<script type="text/x-template" id="jobHoursTemplate">
    ${if (HasChildren == 0)}
    <span>${JobHours}</span>
    ${/if}
</script>

<script type="text/x-template" id="postedHoursTemplate">
    ${if (HasChildren == 0)}
    <span>${PostedHours}</span>
    ${/if}
</script>

<script type="text/x-template" id="dispersedHourTemplate">
    ${if (HasChildren == 0 && DispersedHours)}
    <div onClick="dispersedHourClick(${ AlertId })"><a href="#">${DispersedHours}</a></div>
    ${else}
    <div onClick="dispersedHourClick(${ AlertId })">&nbsp</div>
    ${/if}
</script>

@*var iconColor = dataItem.HasDocuments ? 'standard-green' : 'standard-red';
    var title = dataItem.HasDocuments ? 'View Documents' : 'No Documents';
    var theID = "'DocImg_" + dataItem.SequenceNumber + "'";
    var fubar = ",'" + dataItem.TaskCode + "','" + dataItem.TaskDescription + "'";*@

<script type="text/x-template" id="taskDocumentsTemplate">

    <a href="javascript:void(0);" title="Documents">
        <div class="${taskDocumentsClass(HasDocuments)}" title="" onclick=${taskDocumentFunction(SequenceNumber, TaskCode, TaskDescription)}>
            <img src="@Url.Content("~/Images/Icons/White/256/documents_empty.png")" class="icon-image" />
        </div>
    </a>
</script>

<script>

    function isGridDirty() {
        var treegrid = $("#treegrid");
        if (treegrid[0].ej2_instances) {
            var treeGridObj = treegrid[0].ej2_instances[0];
            var changes = treeGridObj.getBatchChanges();
            if (changes.addedRecords.length || changes.changedRecords.length || changes.deletedRecords.length) {
                return true;
            }
        }
        return false;
    }

    function taskDocumentsClass(HasDocuments) {
        if (HasDocuments) {
            return "icon-background background-color-sidebar standard-green ";
        }
        return "icon-background background-color-sidebar standard-red ";
    }

    function taskDocumentFunction(SequenceNumber,TaskCode, TaskDescription) {
        var theID = "DocImg_" + SequenceNumber;
        var functionString = "setTaskDocuments(" + SequenceNumber + ",'" + TaskCode + "','" + TaskDescription + "','" + theID + "'," + @Html.Raw(Json.Encode(CInt(AdvantageFramework.Database.Entities.DocumentLevel.Task))) + ")";
        return functionString.replace(/\s/g, "");;
    }

    function setTaskDocuments(sequenceNumber,TaskCode,TaskDescription,imgID,docLevel) {
        var taskDesc = encodeURI(TaskCode + ' - ' + TaskDescription);
        OpenRadWindow('Document List', 'Documents_List2.aspx?j=@Model.JobNumber &jc=@Model.JobComponentNumber&s=' + sequenceNumber + '&doc_img=' + imgID + '&doclvl=' + docLevel + '&task_desc=' + taskDesc, 0, 0, true, function () {
            reloadTaskList();
        });
    }

    function TaskComments(sequenceNumber) {
        OpenRadWindow('Comments', 'TrafficSchedule_TaskComments.aspx?JobNum=' + @Model.JobNumber + '&JobComp=' + @Model.JobComponentNumber + '&SeqNum=' + sequenceNumber, 450, 500, true, function () {
            reloadTaskList();
        });
    }

    ej.treegrid.TreeGrid.Inject(ej.treegrid.Page);
    ej.treegrid.TreeGrid.Inject(ej.treegrid.Edit);
    ej.treegrid.TreeGrid.Inject(ej.treegrid.Toolbar);
    ej.treegrid.TreeGrid.Inject(ej.treegrid.Resize);
    ej.treegrid.TreeGrid.Inject(ej.treegrid.RowDD);

    class JobComponentAdaptor extends ej.data.UrlAdaptor {
        beforeSend(dataManager, request, ajaxSettings) {
            var data = JSON.parse(ajaxSettings.data);
            data.JobNumber = @Model.JobNumber;
            data.JobComponentNumber = @Model.JobComponentNumber;
            var dataStrng = JSON.stringify(data);
            ajaxSettings.data = dataStrng;
            ajaxSettings.options.data = dataStrng;
        }
    }

    var taskDeleted = false;
    var taskEdited = false;
    var taskInserted = false;
    var CalculateByPredecessor = 0;

    let statusList = [{ value: 'P', text: 'Pending' },
    { value: 'A', text: 'Active' }];

    $(() => {
        var data = new ej.data.DataManager({
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetTasks")",
            updateUrl: "@Href("~/ProjectManagement/ProjectSchedule/UpdateTask")",
            insertUrl: "@Href("~/ProjectManagement/ProjectSchedule/InsertTask")",
            removeUrl: "@Href("~/ProjectManagement/ProjectSchedule/ejDeleteTask")",
            batchUrl: "@Href("~/ProjectManagement/ProjectSchedule/RemoveTask")",
            adaptor: new JobComponentAdaptor(),
            crossDomain: true
        });
        var treeGridObj = new ej.treegrid.TreeGrid({
            dataSource: data,
            treeColumnIndex: 0,
            actionComplete: (args) => {
                console.log(args);
                setSave();
            },
            //toolbar: ['Add', 'Delete', 'Update', 'Cancel'],
            allowRowDragAndDrop: true,
            selectionSettings: { type: 'Single' },
            hasChildMapping: 'HasChildren',
            idMapping: 'SequenceNumber',
            parentIdMapping: 'ParentTaskSequenceNumber',
            height: 425,
            beforeBatchAdd: (args) => {
                args.defaultData.SequenceNumber = 123123;
                args.defaultData.EmployeeCode = '';
                args.defaultData.EmployeeName = '';
                console.log(args.defaultData.SequenceNumber);
            },
            //allowPaging: true,
            isResponsive: true,
            allowResizing: true,
            allowTextWrap: true,
            textWrapSettings: { wrapMode: 'Header' },
            cellEdit: (args) => {
                console.log(args);
                if (args.rowData.HasChildren == true) {
                    args.cancel = true;
                }
            },
            cellSaved: (args) => {
                console.log(args);

                setSave();
            },
            beforeBatchSave: (args) => {
                console.log(args);
            },
            editSettings: {
                allowEditing: true,
                allowAdding: true,
                allowDeleting: true,
                showConfirmDialog: false,
                showDeleteConfirmDialog: false,
                newRowPosition: 'Bottom',
                mode: 'Batch'
            },
            rowDrop: (args) => {
                console.log(args);
                var treegrid = $("#treegrid");
                var treeGridObj = treegrid[0].ej2_instances[0];

                args.cancel = false;

                if (args.dropPosition == "middleSegment") {
                    var targetTask = treeGridObj.getCurrentViewRecords();

                    var parentSequenceNumber = targetTask[args.dropIndex].SequenceNumber;
                    var childSequenceNumber = args.data[0].SequenceNumber;

                    console.log(parentSequenceNumber, childSequenceNumber);
                    console.log(targetTask[args.dropIndex], args.data[0]);
                }
                else if (args.dropPosition == "topSegment") {
                    var targetTask = treeGridObj.getCurrentViewRecords();
                    console.log(parentSequenceNumber, childSequenceNumber);
                    console.log(targetTask[args.dropIndex], args.data[0]);

                }
                else if (args.dropPosition == "bottomSegment") {
                    var targetTask = treeGridObj.getCurrentViewRecords();
                    console.log(parentSequenceNumber, childSequenceNumber);
                    console.log(targetTask[args.dropIndex], args.data[0]);
                }
            },
            load: () => {
                let instance = document.getElementById('treegrid').ej2_instances[0];
                instance.element.addEventListener('mousedown', (e) => {
                    if (e.target.classList.contains("e-rowcell")) {
                        let index = parseInt(e.target.getAttribute("Index"));
                        let colindex = parseInt(e.target.getAttribute("aria-colindex"));
                        let field = instance.getColumns()[colindex].field;
                        instance.editModule.editCell(index, field);
                    }
                })
            },
            columns: [
                { field: "Level", headerText: "Level", width: 100, allowEditing: false },
                { field: "SequenceNumber", headerText: "SequenceNumber", isPrimaryKey: true,  width: 100, allowEditing: false},
                { field: "ParentTaskSequenceNumber", headerText: "ParentTaskSequenceNumber", width: 100, visible: false },
            @for each item In Model.Columns
                If item.Visible Then
                    Select Case item.ColumnType
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Phase
                @<text>{
                    field: "PhaseDescription", headerText: "@item.HeaderText", width: 150, editType: 'dropdownedit', edit: {
                        params: {
                            query: new ej.data.Query(),
                            dataSource:  new ej.data.DataManager({
                                    url: '@Url.Content("~/ProjectManagement/ProjectSchedule/GetPhases")',
                                    adaptor: new ej.data.UrlAdaptor(),
                                    crossDomain: true
                                }),
                            fields: { value: 'Name', text: 'Name' },
                            allowFiltering: true
                        }
                    }
                },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCode
                @<text>{
                    field: "TaskCode", headerText: "@item.HeaderText", width: 130, editType: 'dropdownedit', edit: {
                        create: (arg) => {
                            var inputElement = document.createElement('input');
                            return inputElement;
                        },
                        read: (arg) => {
                            var dropDownList = $(arg)[0].ej2_instances[0];
                            return dropDownList.value;
                        },
                        destroy: () => {
                        },
                        write: (arg) => {
                            console.log(arg);
                            var dropDownList = new ej.dropdowns.DropDownList({
                                dataSource: new ej.data.DataManager({
                                    url: '@Url.Content("~/ProjectManagement/ProjectSchedule/GetTaskList")',
                                    adaptor: new ej.data.UrlAdaptor(),
                                    crossDomain: true
                                }),
                                fields: { value: 'Code', text: 'Code' },
                                change: (arg) => {
                                    if (arg.itemData) {
                                        var rowData = $(arg.element).data('rowData');
                                        var treeGrid = $("#treegrid")[0].ej2_instances[0];
                                        treeGrid.setCellValue(rowData.ID, 'TaskDescription', arg.itemData.Name);
                                    }
                                },
                                value: arg.rowData.TaskCode
                            });
                            $(arg.element).data('rowData', arg.rowData);
                            dropDownList.appendTo(arg.element);
                        }
                    }
                },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDescription
                           @<text>
                { field: "TaskDescription", headerText: "Description", width: 100 },
           </text>

                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStatus
                @<text>{
                    field: "TaskStatus", headerText: "@item.HeaderText", template: '#taskStatusTemplate', width: 110, editType: 'dropdownedit', edit: {
                        params: {
                            query: new ej.data.Query(),
                            dataSource: statusList,
                            fields: { value: 'value', text: 'text' }
                        }
                    }
                },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobOrder
                @<text>{
                    field: "@item.ColumnType.ToString",
                    headerText: "@item.HeaderText",
                    width: 80, NotCalculateByPredecessor: true,
                    textAlign: 'Right',
                    editType: 'numericedit',
                    edit: {
                        params: {
                            showSpinButton: false
                        }
                    }
                }, </text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Linked
                @<text>{ field: "TaskDescription", headerText: "@item.HeaderText", template: "#linkedTemplate", width: 100 },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.MoveLeftOrRight
                @<text>{ field: "TaskDescription", headerText: "@item.HeaderText", template: "#moveLeftOrRightTemplate", width: 80, CalculateByPredecessor: true },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsTextbox
                @<text>{ field: "PredecessorLevelNotation", headerText: "@item.HeaderText", width: 110, CalculateByPredecessor: true }, </text>
                        @*Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStartDate
                @<text>{ field: "TaskStartDate", headerText: "@item.HeaderText", width: 110, editType: "datepickeredit", format: { skeleton: 'short', type: 'date' } },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDueDate
                @<text>{ field: "JobRevisedDate", headerText: "@item.HeaderText", width: 110, editType: "datepickeredit", format: { skeleton: 'short', type: 'date' } }, </text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.OriginalDueDate
                @<text>{ field: "JobDueDate", headerText: "@item.HeaderText", width: 110, editType: "datepickeredit", format: { skeleton: 'short', type: 'date' } },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.CompletedDate
                @<text>{ field: "JobCompletedDate", headerText: "@item.HeaderText", width: 110, editType: "datepickeredit", format: { skeleton: 'short', type: 'date' } },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TempCompletedDate
                @<text>{ field: "TemporaryCompleteDate", headerText: "@item.HeaderText", width: 110, editType: "datepickeredit", format: { skeleton: 'short', type: 'date' } },</text>*@
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateComments,
                             AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.RevisionComments
                @<text>{ field: "@item.ColumnType.ToString", headerText: "@item.HeaderText", width: 260 },</text>
                        case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsTextbox
                @<text>{ field: "FunctionComments", headerText: "@item.HeaderText", width: 260 },</text>
                            case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsImage
                @<text>{ field: "", headerText: "", template: "#CommentsImageTemplate", width: 50 },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobDays
                @<text>{ field: "JobDays", headerText: "@item.HeaderText", width: 100, textAlign: 'Right', template: "#jobDaysTemplate" },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateLock
                @<text>{
                    field: "DueDateLock",
                   headerTemplate: "<div class='go-center' style='padding-right: 4px'><span class='k-icon k-i-lock'></span></div>",
                   width: 65,
                   type: 'boolean',
                   displayAsCheckBox: true,
                   editType: 'booleanedit'
                },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Milestone
                @<text>{ field: "Milestone", headerText: "@item.HeaderText", width: 65, type: 'boolean', displayAsCheckBox: true, editType: 'booleanedit' },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete
                @<text> {
               field: "EmployeeCode", headerText: "Employees", width: 200, edit: {
                        create: (arg) => {
                            var inputElement = document.createElement('input');
                            return inputElement;
                        },
                        read: (arg) => {
                            console.log(arg);
                            var rowData = $(arg).data('rowData');
                            console.log(rowData);
                            var dropDownList = $(arg)[0].ej2_instances[0];
                            console.log(dropDownList);
                            var rValue = dropDownList.value == null ? null : dropDownList.value.join(", ");
                            return rValue;
                        },
                        destroy: () => {

                        },
                        write: (arg) => {
                            console.log('Employee code', arg.rowData.EmployeeCode);
                            if (arg.rowData.EmployeeCode == null)
                                arg.rowData.EmployeeCode = '';

                            let multiSelect = new ej.dropdowns.MultiSelect({
                                dataSource: new ej.data.DataManager({
                                    url: '@Url.Content("~/ProjectManagement/ProjectSchedule/GetEmployees")',
                                    adaptor: new ej.data.UrlAdaptor(),
                                    crossDomain: true
                                }),
                                fields: { value: 'Code', text: 'Name' },
                                value: (typeof arg.rowData.EmployeeCode !== "undefined" && arg.rowData.EmployeeCode && arg.rowData.EmployeeCode != '') ? arg.rowData.EmployeeCode.split(",") : null
                            });
                            // render initialized MultiSelect
                            multiSelect.appendTo(arg.element);
                            $(arg.element).data('rowData', arg.rowData);
                        }
                    }
                },
                {
                    field: "EmployeeCode", headerText: "", width: 40, template: '#employeesImageTemplate'
                },
           </text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesTextbox
                @<text> {
               field: "EmployeeName", headerText: "Employees", width: 200, edit: {
                   create: (arg) => {
                       var inputElement = document.createElement('input');
                       return inputElement;
                   },
                   read: (arg) => {
                       var rowData = $(arg).data('rowData');
                       console.log(rowData);
                       var dropDownList = $(arg)[0].ej2_instances[0];
                       var rValue = dropDownList.value == null ? null : dropDownList.value.join(", ");
                       var treeGrid = $("#treegrid")[0].ej2_instances[0];
                       treeGrid.setCellValue(rowData.ID, 'EmployeeCode', rValue);
                       return dropDownList.text;
                   },
                   destroy: (arg) => {
                       console.log('maybe here', arg);
                   },
                   write: (arg) => {
                       console.log('Employee code', arg.rowData.EmployeeCode);
                       if (arg.rowData.EmployeeCode == null)
                           arg.rowData.EmployeeCode = '';

                       let multiSelect = new ej.dropdowns.MultiSelect({
                           dataSource: new ej.data.DataManager({
                               url: '@Url.Content("~/ProjectManagement/ProjectSchedule/GetEmployees")',
                               adaptor: new ej.data.UrlAdaptor(),
                               crossDomain: true
                           }),
                           fields: { value: 'Code', text: 'NameOnly' },
                           value: (typeof arg.rowData.EmployeeCode !== "undefined" && arg.rowData.EmployeeCode && arg.rowData.EmployeeCode != '') ? arg.rowData.EmployeeCode.split(",") : null
                       });

                       multiSelect.appendTo(arg.element);
                       $(arg.element).data('rowData', arg.rowData);
                   }
               }
                },
                {
                    field: "EmployeeCode", headerText: "", width: 40, template: '#employeesImageTemplate'
                },
           </text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobHours
                @<text>{ field: "@item.ColumnType.ToString", headerText: "@item.HeaderText", width: 100, tempalte: '#jobHoursTemplate', textAlign: 'Right' },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PostedHours
                @<text>{ field: "@item.ColumnType.ToString", headerText: "@item.HeaderText", width: 100, tempalte: '#postedHoursTemplate', textAlign: 'Right', allowEditing: false },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DispersedHours
                @<text>{ field: "@item.ColumnType.ToString", headerText: "@item.HeaderText", width: 100, template: "#dispersedHourTemplate", textAlign: 'Right', allowEditing: false },</text>
                        Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueTime
                @<text>{ field: "@AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisedDueTime.ToString", headerText: "@item.HeaderText", width: 100 },</text>
            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDocuments
                @<text>{ width: 50, template: '#taskDocumentsTemplate' }, </text>
                    End Select
                End If
            Next item
                { field: "HasChildren", headerText: "HasChildren", width: 100, visible: false }

                //{ field: "EstimateFunction", headerText: "EstimateFunction", width: 100 },
                //{ field: "FunctionDescription", headerText: "FunctionDescription", width: 100 },
                //{ field: "PostedHours", headerText: "PostedHours", width: 100 },
                //{ field: "ID", headerText: "ID", width: 100, isPrimaryKey:"true" },
                //{ field: "PhaseOrder", headerText: "PhaseOrder", width: 100 },
                //{ field: "Predecessor", headerText: "Predecessor", width: 100 },
                //{ field: "TrafficRole", headerText: "TrafficRole", width: 100 },
                //{ field: "HasAssignment", headerText: "HasAssignment", width: 100 },
                //{ field: "HasAlerts", headerText: "HasAlerts", width: 100 },
                //{ field: "PercentComplete", headerText: "PercentComplete", width: 100 },
                //{ field: "PhaseStartDate", headerText: "PhaseStartDate", width: 100 },
                //{ field: "PhaseEndDate", headerText: "PhaseEndDate", width: 100 },
                //{ field: "ClientContact", headerText: "ClientContact", width: 100 },
            ]
        });

        treeGridObj.appendTo("#treegrid");
        setTimeout(() => {
            treeGridObj.expandAll();
        }, 500);

        $('#saveButton').on('click', saveGrid);
        $('#cancelButton').on('click', cancelGridChanges);
        $('#refreshProjectSchedule').on('click', refreshGrid);

    });

    function saveGrid() {
        // get all the grid and perform the batchSave operation
        for (let i = 0; i < document.querySelectorAll('.e-grid').length; i++) {
            let gridObj = document.querySelectorAll('.e-grid')[i].ej2_instances[0].editModule.getBatchChanges();
            // batchSave called only when perform CRUD operation (avoid duplicate request)
            if (gridObj.addedRecords.length || gridObj.changedRecords.length || gridObj.deletedRecords.length) { // check whether grid has been edited
                (document.querySelectorAll('.e-grid')[i]).ej2_instances[0].editModule.batchSave();
            }
        }
    }

    function cancelGridChanges() {
        var treegrid = $("#treegrid");
        var treeGridObj = treegrid[0].ej2_instances[0];
        treeGridObj.editModule.batchCancel();
        setSave();
    }

    function refreshGrid() {
        var treegrid = $("#treegrid");
        var treeGridObj = treegrid[0].ej2_instances[0];
        treeGridObj.refresh();
        setSave();
    }

    function employeesImageTemplate(TaskCode, SequenceNumber) {
        var js = 'void(0)';

@if (Model.CanUserEdit) Then
    @<text>js = "setEmployeeDlg('" + TaskCode + "'," + SequenceNumber + ")";</text>
End If

        return js;
    }

    function linkTemplate(SequenceNumber, HasPredecessors) {
        var js = 'void(0)';

        js = "!isSelectingPreds()?linkItem(" + SequenceNumber + "," + !HasPredecessors + "):''";

        return js;

        @*if (@Model.CanUserEdit)
            return "!isSelectingPreds() ? 'linkItem(" + SequenceNumber + ", " + !HasPredecessors + ")' : ''";
        else
            return '';*@
    }

    function setEmployeeDlg(TaskCode, SequenceNumber) {
        if (setSave()) {
            showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
                .done(function () {
                    $('#saveButton').trigger('click');

                    setTimeout(() => {
                        setEmployees(@Model.JobNumber,@Model.JobComponentNumber,TaskCode, SequenceNumber);
                    }, 500);
                })
                .fail(function () {
                    setEmployees(@Model.JobNumber,@Model.JobComponentNumber,TaskCode, SequenceNumber);
                });
        }
        else {
            setEmployees(@Model.JobNumber,@Model.JobComponentNumber,TaskCode, SequenceNumber);
        }
    }

    function dispersedHourClick(id) {
        var URL = "";
        var thisTitle = "Hours";
        URL = 'ProjectManagement/Agile/HoursByAlertID/0/' + id;

        //var treeList = $("#treelist").data("kendoTreeList");
        //let row = treeList.select()[0].closest("tr");

        if (setSave()) {
            showKendoSaveContinue("<p><strong>Pending Changes Will Be Lost </strong> are you sure you want to continue without saving?<p>")
                .done(function () {
                    $('#saveButton').trigger('click');

                    setTimeout(() => {
                        openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                            reloadTaskList();
                            //$("#treelist").data("kendoTreeList").select(row);
                        }));
                    }, 500);
                })
                .fail(function () {
                    openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                        reloadTaskList();
                        //$("#treelist").data("kendoTreeList").select(row);
                    }));
                });
        }
        else {
            openRadWindowWithEvents(thisTitle, URL, 700, 1000, true, (() => {
                reloadTaskList();
                //$("#treelist").data("kendoTreeList").select(row);
            }));
        }

    }

    function resizeGrid() {
        var treegrid = $("#treegrid");
        var treeGridObj = treegrid[0].ej2_instances[0];
        treeGridObj.height = $('#ScheduleWrap').height() - 50;
    }

    function deleteTasks() {
        var treegrid = $("#treegrid");
        var treeGridObj = treegrid[0].ej2_instances[0];

        //var records = treeGridObj.getSelectedRecords();

        treeGridObj.deleteRecord();
        setSave();
    }

    function AddTask() {
        var treegrid = $("#treegrid");
        var treeGridObj = treegrid[0].ej2_instances[0];
        treeGridObj.addRecord();

        //{
        //    SequenceNumber: 0,
        //        Level: null,
        //            HasChildren: false,
        //                ParentTaskSequenceNumber: {
        //    }
        //}, 1
@*{
            JobNumber: @Model.JobNumber,
            JobComponentNumber: @Model.JobComponentNumber,
            TaskDescription: "This is a test",
            TaskStartDate: null,
            JobRevisedDate: null,
            JobDueDate: null,
            JobCompletedDate: null,
            TemporaryCompleteDate: null,
            TaskStatus: 'P',
            EmployeeCode: '',
            Level: '1'
        }*@
        setSave();
    }

</script>
