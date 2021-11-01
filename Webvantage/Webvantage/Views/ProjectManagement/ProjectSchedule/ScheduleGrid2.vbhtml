@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule

<script type="text/javascript" src="~/JScripts/projectschedule.mvc.js"></script>

<script type="text/x-kendo-template" id="emptyTemplate">

</script>
<script type="text/x-kendo-template" id="levelTemplate">
    <span id="levelWrap">
        @(Html.Kendo().CheckBox().Name("SelectAllTasksCheckBox").Checked(False).HtmlAttributes(New With {.onchange = "selectAllTasks()"}).ToClientTemplate) Level
    </span>
</script>
<script type="text/x-kendo-template" id="phaseTemplate">
    # var theID = 'Phase_' + SequenceNumber; #
    <div class="col-cont-wrap">
        <input class="ps-phase ps-update" name="TrafficPhaseID" value="#: TrafficPhaseID #" id="#: theID #" desc="#: PhaseDescription #" style="width: 100%;" />
    </div>
</script>
<script type="text/x-kendo-template" id="taskCodeTemplate">
    # var theID = 'TaskCode_' + SequenceNumber; #
    @(Html.Kendo().TextBox().Name("TaskCode").Value("#: TaskCode != null ? TaskCode : '' #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update code-6"}).ToClientTemplate)
</script>
<script type="text/x-kendo-template" id="taskDescriptionTemplate">
    # var theID = 'TaskDesc_' + SequenceNumber; #
    @(Html.Kendo().TextBox().Name("TaskDescription").Value("#: TaskDescription != null ? TaskDescription : '' #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update"}).ToClientTemplate)
</script>
<script type="text/x-kendo-template" id="moveLeftOrRightTemplate">
    <div>
        # var theID = 'TaskDesc_' + SequenceNumber; #
        # var moveL = treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber)) ? true : false; #
        # var levelNodes = treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber)) ? treeList.dataSource.childNodes(treeList.dataSource.parentNode(treeList.dataSource.get(SequenceNumber))) : treeList.dataSource.rootNodes(); #
        # var moveR = levelNodes.indexOf(treeList.dataSource.get(SequenceNumber)) > 0 ? true : false; #
        # if(moveL === true) { #
        <a href="javascript:void(0);" onclick="moveLeft(this)">
            <img src="@Url.Content("~/Images/Icons/Grey/256/indent_decrease.png")" class="icon-btn" />
        </a>
        # } #
        # if(moveR === true) { #
        <a href="javascript:void(0);" onclick="moveRight(this)">
            <img src="@Url.Content("~/Images/Icons/Grey/256/indent_increase.png")" class="icon-btn" />
        </a>
        # } #
    </div>
</script>
<script type="text/x-kendo-template" id="linkedTemplate">
    # var theID = 'Link_' + SequenceNumber; #
    # var levels = Level.split('.'); #
    # var theLevel = levels[levels.length - 1]; #
    # var onClick = !isSelectingPreds() ? "linkItem(" + SequenceNumber + "," + !HasPredecessors + ")": ''; #
    # var imgSrc = HasPredecessors == true ? 'link.png' : 'link_broken.png'; #
    #if(HasChildren == true || theLevel == "1"){#

    #} else {#
    <a href="javascript:void(0);" onclick="#: onClick #" class="img-link">
        <img src="@Url.Content("~/Images/Icons/Grey/256/#: imgSrc #")"  class="icon-btn" />
    </a>
    #}#
</script>
<script type="text/x-kendo-template" id="selectPredsTemplate">
    # var theID = 'SelectPreds_' + SequenceNumber; #
    # var row = $('tr[data-uid=' + uid + ']'); #
    # var isSelecting = isSelectingPreds(); #
    # var isSelector = isSelecting && row.hasClass('pred-selector') ? true : false; #
    #if(HasChildren == true){#

    #} else if (isSelecting == true && isSelector == false) {#
    <div class="go-center">
        @(Html.Kendo().CheckBox().Name("SelectPredCheckBox").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
    </div>
    #} else {#
    <div class="select-preds-wrap">
        <a href="javascript:void(0);" onclick="selectPredecessors(#: SequenceNumber  #)" class="img-link" id="#: theID #">
            <img src="@Url.Content("~/Images/Icons/Grey/256/link_add.png")"  class="icon-btn"  />
        </a>
    </div>
    #}#
</script>
<script type="text/x-kendo-template" id="predecessorsTextboxTemplate">
    # var theID = 'PredecessorsTextbox_' + SequenceNumber; #
    #if(HasChildren == true){#

    #} else { #
    @(Html.Kendo().TextBox().Name("PredecessorLevelNotation").Value("#: PredecessorLevelNotation != null ? PredecessorLevelNotation : '' #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update"}).ToClientTemplate)
    #} #
</script>
<script type="text" id="jobOrderTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobOrder_' + SequenceNumber; #
        <input name="JobOrder" type="text" class="ps-numeric ps-update" value="#: JobOrder #" />
    </div>
</script>
<script type="text/x-kendo-template" id="taskStatusTemplate">
    <div class="col-cont-wrap">
        # var theID = 'TaskStatus_' + SequenceNumber; #
        #if(HasChildren == true){#

        #}else{#
        <input class="ps-task-status ps-update" name="TaskStatus" value="#: TaskStatus #" style="width: 100%;" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="milestoneTemplate">
    <div class="go-center">
        # var theID = 'IsMilestone_' + SequenceNumber; #
        #if(Milestone == true){#
        @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}else{#
        @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="jobDaysTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobDays_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        <input name="JobDays" type="text" class="ps-numeric ps-update" value="#: JobDays #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="taskStartDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(Date.parse(TaskStartDate)) ? kendo.format('{0:d}', TaskStartDate) : ''; #
        # var disabled = DueDateLock === 1 ? 'disabled' : ''; #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        <input name="TaskStartDate" type="text" class="ps-date-picker" value="#= theDate #"  #: disabled # />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="jobRevisedDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(Date.parse(JobRevisedDate)) ? kendo.format('{0:d}', JobRevisedDate) : ''; #
        # var disabled = DueDateLock === 1 ? 'disabled' : ''; #
        # var cssClass = getClassForDueDate(theDate, DueDateLock, JobCompletedDate); #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        <input name="JobRevisedDate" type="text" class="ps-date-picker #: cssClass #" value="#= theDate #"  #: disabled # />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="dueDateLockTemplate">
    <div class="go-center">
        # var theID = 'DueDateLock_' + SequenceNumber; #
        #if(DueDateLock === 1){#
        @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}else{#
        @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="revisedDueTimeTemplate">
    # var theID = 'TaskCode_' + SequenceNumber; #
    @(Html.Kendo().TextBox().Name("RevisedDueTime").Value("#: RevisedDueTime != null ? RevisedDueTime : '' #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update"}).ToClientTemplate)
</script>
<script type="text/x-kendo-template" id="jobDueDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(Date.parse(JobDueDate)) ? kendo.format('{0:d}', JobDueDate) : ''; #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        <input name="JobDueDate" type="text" class="ps-date-picker" value="#= theDate #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="jobCompletedDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(Date.parse(JobCompletedDate)) ? kendo.format('{0:d}', JobCompletedDate) : ''; #
        #if(HasChildren == true){#

        #} else {#
        <input name="JobCompletedDate" type="text" class="ps-date-picker" value="#= theDate #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="temporaryCompleteDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(Date.parse(TemporaryCompleteDate)) ? kendo.format('{0:d}', TemporaryCompleteDate) : ''; #
        #if(HasChildren == true){#

        #} else {#
        <input name="TemporaryCompleteDate" type="text" class="ps-date-picker" value="#= theDate #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="jobHoursTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobHours_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        <input name="JobHours" type="text" class="ps-numeric ps-update" value="#: JobHours #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="dispersedHoursTemplate">
    <div class="go-right col-cont-wrap">
        # var fmtHours = kendo.format('{0:n2}', DispersedHours); #
        #if(HasChildren == true){#
        #: fmtHours #
        #} else {#
        <a href="javascript:setEmployees('#: TaskCode #', '#: SequenceNumber #');">
            #: fmtHours #
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="postedHoursTemplate">
    <div class="go-right col-cont-wrap">
        # var fmtHours = kendo.format('{0:n2}', PostedHours); #
        #: fmtHours #
    </div>
</script>
<script type="text/x-kendo-template" id="percentCompleteTemplate">
    <div class="go-right col-cont-wrap">
        # var fmtHours = kendo.format('{0:n2}', PercentComplete); #
        #: fmtHours #
    </div>
</script>
<script type="text/x-kendo-template" id="employeesLinkTemplate">
    <div class="go-center col-cont-wrap">
        # var emps = EmployeeCode ? EmployeeCode.split(",").join(", ") : 'Add'; #
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:setEmployees('#: TaskCode #', '#: SequenceNumber #');">
            #: emps #
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="employeesAutoCompleteTemplate">
    <div class="col-cont-wrap">
        # var emps = EmployeeCode ? EmployeeCode : ''; #
        # var theID = 'EmployeesAutoComplete_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        <input id="#= theID #" class="ps-auto-complete" style="width:100%" value="#: emps #" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="employeesTextTemplate">
    <div class="col-cont-wrap">
        # var emps = EmployeeCode ? EmployeeCode : ''; #
        # var theID = 'EmployeeCodeTextBox_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        @(Html.TextArea("EmployeeCode", "#: emps #", New With {.class = "k-textbox ps-update", .style = "width: 100%", .id = "#: theID #"}))
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="employeesImageTemplate">
    <div class="col-cont-wrap">
        # var theID = 'EmpImg_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:void(0);">
            <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick='setEmployees("#: TaskCode #", "#: SequenceNumber #")'>
                <img src="@Url.Content("~/Images/Icons/White/256/users.png")" class="icon-image" />
            </div>
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="clientContactsLinkTemplate">
    <div class="go-center col-cont-wrap">
        # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : 'Add'; #
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:setClientContacts('#: TaskCode #', '#: SequenceNumber #');">
            #: clContacts #
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="clientContactsTextTemplate">
    <div class="go-center col-cont-wrap">
        # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : ''; #
        # var theID = 'ClientContactsText_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        @(Html.TextArea("ClientContact", "#: clContacts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="clientContactsImageTemplate">
    <div class="col-cont-wrap">
        # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : 'Add'; #
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:void(0);">
            <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick='setClientContacts("#: TaskCode #", "#: SequenceNumber #")' title="#: clContacts #">
                <img src="@Url.Content("~/Images/Icons/White/256/user_telephone.png")" class="icon-image" title="#: clContacts #" />
            </div>
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="estimateFunctionTemplate">
    <div class="col-cont-wrap">
        # var theID = 'EstimateFunction_' + SequenceNumber; #
        # var estFnc = EstimateFunction === null ? '' : EstimateFunction; #
        #if(HasChildren == true){#

        #}else{#
        <input class="ps-estimate-function ps-update" id="#: theID #" name="EstimateFunction" value="#: estFnc #" style="width: 100%;" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="functionCommentsTextTemplate">
    # var fncCmts = FunctionComments ? FunctionComments : ''; #
    # var theID = 'FunctionComments_' + SequenceNumber; #
    @(Html.TextArea("FunctionComments", "#: fncCmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))
</script>
<script type="text/x-kendo-template" id="functionCommentsImageTemplate">
    <a href="javascript:void(0);" title="Comments">
        <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick='setTaskComments("#: SequenceNumber #")'>
            <img src="@Url.Content("~/Images/Icons/White/256/messages.png")" class="icon-image" />
        </div>
    </a>
</script>
<script type="text/x-kendo-template" id="dueDateCommentsTemplate">
    # var Cmts = DueDateComments ? DueDateComments : ''; #
    # var theID = 'DueDateComments_' + SequenceNumber; #
    @(Html.TextArea("DueDateComments", "#: Cmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))
</script>
<script type="text/x-kendo-template" id="revisionDateCommentsTemplate">
    # var Cmts = RevisionDateComments ? RevisionDateComments : ''; #
    # var theID = 'RevisionDateComments_' + SequenceNumber; #
    @(Html.TextArea("RevisionDateComments", "#: Cmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))
</script>
<script type="text/x-kendo-template" id="taskDocumentsTemplate">
    # var iconColor = HasDocuments ? 'standard-green' : 'standard-red'; #
    # var title = HasDocuments ? 'View Documents' : 'No Documents'; #
    # var theID = 'DocImg_' + SequenceNumber; #
    <a href="javascript:void(0);" title="Documents">
        <div class="icon-background background-color-sidebar #: iconColor #" onclick='setTaskDocuments("#: SequenceNumber #", "#: theID #", @Html.Raw(Json.Encode(CInt(AdvantageFramework.Database.Entities.DocumentLevel.Task))))' title="#: title #">
            <img src="@Url.Content("~/Images/Icons/White/256/documents_empty.png")" class="icon-image" id="#: theID #" />
        </div>
    </a>
</script>

<style type="text/css">
    
    .k-grid .k-textbox, .k-grid .k-numerictextbox {
        width: 100% !important;
    }

    .ps-date-picker {
        width: 100%;
    }

    .go-right {
        text-align: right;
    }

    .go-center {
        text-align: center;
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

    #DropTarget {
        border: 1px solid black;
        background-color: rgba(0, 0, 0, 0.5);
        position: absolute;
        left: 0;
        right: 0;
    }

    #tbl-hint {
        border: 1px solid black;
        border-collapse: collapse;
        padding: 5px;
        background: white;
    }

    #tbl-hint td {
        padding: 5px;
    }

    #tbl-hint span.k-icon {
        display: none;
    }

    #DropTarget button {
        margin-right: 10px;
    }

    #DropTarget button:first-child {
        margin-left: 10px;
    }
    .has-alerts {
        background: lightblue !important;
    }

    
</style>

<div>

    @(Html.Kendo() _
                            .TreeList(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) _
                            .Name("ProjectSchedule") _
                            .Columns(Sub(col)
                                         ColumnHelper(col)
                                     End Sub) _
                            .DataSource(Sub(ds)
                                            ds.Batch(False) _
                                            .Read(Sub(r) r.Action("ReadProjectScheduleTasks", "ProjectSchedule").Data("getModelData")) _
                                            .Update(Sub(u) u.Action("UpdateProjectScheduleTask", "ProjectSchedule").Data("getModelData")) _
                                            .Destroy(Sub(d) d.Action("DeleteScheduleTasks", "ProjectSchedule").Type(HttpVerbs.Post)) _
                                            .Model(Sub(m)
                                                       m.Id(Function(i) i.SequenceNumber)
                                                       m.ParentId(Function(i) i.ParentTaskSequenceNumber)
                                                       m.Expanded(True)
                                                       m.Field(Function(i) i.SequenceNumber).DefaultValue(-1).Editable(False)
                                                       m.Field(Function(i) i.JobNumber).Editable(False)
                                                       m.Field(Function(i) i.JobComponentNumber).Editable(False)

                                                   End Sub).AutoSync(True).Events(Sub(e)
                                                                                      e.RequestStart("treeListRequestStart")
                                                                                      e.RequestEnd("treeListRequestEnd")
                                                                                  End Sub)
                                        End Sub) _
                            .Events(Sub(e)
                                        e.DataBound("treeListDataBound")
                                        e.DataBinding("treeListDataBinding")
                                        e.Expand("treeListExpand")
                                        e.Collapse("treeListCollapse")
                                        e.Change("selectionChanged")
                                    End Sub) _
                            .Selectable(True) _
                            .HtmlAttributes(New With {.style = ""}))

</div>

<div id="ktl">
    

</div>

@If Me.IsClientPortal = False Then

    @(Html.Kendo.ContextMenu().Name("TaskContextMenu").Orientation(ContextMenuOrientation.Vertical).Target("#ProjectSchedule").Filter("tbody > tr").Items(Sub(i)
                                                                                                                                                              i.Add().Text("Task Details").HtmlAttributes(New With {.id = "TaskDetails"})
                                                                                                                                                              i.Add().Separator(True)
                                                                                                                                                              i.Add().Text("New Task Alert").HtmlAttributes(New With {.id = "NewTaskAlert"})
                                                                                                                                                              i.Add().Text("New Task Assignment").HtmlAttributes(New With {.id = "NewTaskAssignment"})
                                                                                                                                                              i.Add().Separator(True)
                                                                                                                                                              i.Add().Text("Delete Task").HtmlAttributes(New With {.id = "DeleteTask"})
                                                                                                                                                          End Sub).Events(Sub(e)
                                                                                                                                                                              e.Select("taskContextMenuSelect")
                                                                                                                                                                          End Sub))

End If


<div id='DropTarget'>
    <button id='dropAbove' class='div-btn k-button'>ABOVE</button>

    @If Model.CalculateByPredecessor = True Then

        @<button id='dropInto' class='div-btn k-button'>INDENT</button>

    End If
    
    <button id='dropBelow' class='div-btn k-button'>BELOW</button>
</div>

@Section PageScripts


End Section

<script type="text/javascript">

    var toolTip;

    $(document).ready(function () {
        $('th[colclass]').each(function() {
            $(this).addClass($(this).attr('colclass'));
        });
        toolTip = $('#ProjectSchedule').kendoTooltip({
            filter: ".select-preds-wrap",
            position: "right",
            content: function(e){
                var content = '<div style="font-weight: bold;">Click to Select Predecessor(s)</div>';
                var item = treeList.dataItem($(e.target).closest('tr'));
                if(item){
                    var notation = item.PredecessorLevelNotation;
                    if(notation){
                        content += '<div style="margin-top: 5px;">' + notation + '</div>';
                    }
                }
                return "<div style='text-align: left;'>" + content + "</div>";
            },
            show: function(e){
                e.sender.popup.wrapper.css('margin-left', '10px');
            }
        }).data("kendoTooltip");
    });

    function getModelData(){
        return psModel;
    }

    var psModel = {
        ClientCode: @Html.Raw(Json.Encode(Model.ClientCode)),
        DivisionCode: @Html.Raw(Json.Encode(Model.DivisionCode)),
        ProductCode: @Html.Raw(Json.Encode(Model.ProductCode)),
        JobNumber: @Model.JobNumber,
        JobComponentNumber: @Model.JobComponentNumber,
        SequenceNumber: @Html.Raw(Json.Encode(Model.SequenceNumber)),
        CalculateByPredecessor: @Html.Raw(Json.Encode(Model.CalculateByPredecessor)),
        PhaseFilter: @Html.Raw(Json.Encode(Model.PhaseFilter)),
        RoleCode: @Html.Raw(Json.Encode(Model.RoleCode)),
        TaskCode: @Html.Raw(Json.Encode(Model.TaskCode)),
        EmployeeCode: @Html.Raw(Json.Encode(Model.EmployeeCode)),
        CutOffDate: @Html.Raw(Json.Encode(Model.CutOffDate)),
        IncludeOnlyPendingTasks: @Html.Raw(Json.Encode(Model.IncludeOnlyPendingTasks)),
        ExcludeProjectedTasks: @Html.Raw(Json.Encode(Model.ExcludeProjectedTasks)),
        IncludeCompletedTasks: @Html.Raw(Json.Encode(Model.UserSettings.IncludeCompletedTasks)),
        SortString: @Html.Raw(Json.Encode(Model.UserSettings.SortString)),
        ShowingEmployees: @Html.Raw(Json.Encode(Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete) OrElse Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesLink))),
        ShowingClientContacts: @Html.Raw(Json.Encode(Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsLink) OrElse Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsTextbox))),
        IsClientPortal: @Html.Raw(Json.Encode(Me.IsClientPortal)),
        AlertSourceApp: @Html.Raw(Json.Encode(CInt(Webvantage.MiscFN.Source_App.ProjectSchedule))),
        TaskAlertSource: @Html.Raw(Json.Encode(CInt(Webvantage.MiscFN.Source_App.ProjectScheduleTask))),
        Blank: ''
    };

</script>

@Functions

    Public Function FormatClientPortal(ByVal TemplateNameIfNotClientPortal As String)

        If Not Me.IsClientPortal Then

            Return TemplateNameIfNotClientPortal

        Else

            Return ""

        End If

    End Function

    Private Sub ColumnHelper(ColumnFactory As Fluent.TreeListColumnFactory(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask))

        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Level.ToString).Title("Level").Template("<span>#: Level #</span>").HeaderTemplateId("levelTemplate").HtmlAttributes(New With {.autofit = True, .minwidth = 100})

        For Each ScheduleColumn In Model.Columns.OrderBy(Function(c) c.Order)

            If ScheduleColumn.Visible = True Then

                Select Case ScheduleColumn.ColumnType

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Phase

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PhaseDescription.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "combo-40"}).HeaderAttributes(New With {.colclass = "combo-40"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCode

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "code-6"}).HeaderAttributes(New With {.colclass = "code-6"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDescription

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-40"}).HeaderAttributes(New With {.colclass = "text-40"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.MoveLeftOrRight

                        If Not Me.IsClientPortal Then

                            ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "move-lr"}).HeaderAttributes(New With {.colclass = "move-lr"})

                        End If

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsTextbox

                        If Model.CalculateByPredecessor Then

                            ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "pred-input"}).HeaderAttributes(New With {.colclass = "pred-input"})

                        End If

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsList

                        If Model.CalculateByPredecessor Then

                            ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PredecessorLevelNotation.ToString).HeaderTemplate("<!-- -->").HtmlAttributes(New With {.class = "pred-list"}).HeaderAttributes(New With {.colclass = "pred-list"})

                        End If

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStatus

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "combo-15"}).HeaderAttributes(New With {.colclass = "combo-15"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Milestone

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Milestone.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-center' style='padding-right: 4px'>M/S</div>").TemplateId("milestoneTemplate").HtmlAttributes(New With {.class = "cb-sm-hdr"}).HeaderAttributes(New With {.colclass = "cb-sm-hdr"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobDays

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDays.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "number-3"}).HeaderAttributes(New With {.colclass = "number-3"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStartDate

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStartDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDueDate

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateLock

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateLock.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-center' style='padding-right: 4px'><span class='k-icon k-i-lock'></span></div>").TemplateId("dueDateLockTemplate").HtmlAttributes(New With {.class = "cb-sm-hdr"}).HeaderAttributes(New With {.colclass = "cb-sm-hdr"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueTime

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisedDueTime.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.OriginalDueDate

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.CompletedDate

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TempCompletedDate

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TemporaryCompleteDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobHours

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobHours.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-right'>Default<br/>Hours</div>").HtmlAttributes(New With {.class = "number-4-2"}).HeaderAttributes(New With {.colclass = "number-4-2"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DispersedHours

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DispersedHours.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-right'>Disbursed<br/>Hours</div>").HtmlAttributes(New With {.class = "disb-hrs"}).HeaderAttributes(New With {.colclass = "disb-hrs"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PostedHours

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PostedHours.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("Posted<br/>Hours").HtmlAttributes(New With {.class = "posted-hrs"}).HeaderAttributes(New With {.colclass = "posted-hrs"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PercentComplete

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PercentComplete.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("Percentage<br/>Complete").HtmlAttributes(New With {.class = "pct-comp"}).HeaderAttributes(New With {.colclass = "pct-comp"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesLink

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("employeesLinkTemplate").HtmlAttributes(New With {.class = "add-by-link"}).HeaderAttributes(New With {.colclass = "add-by-link"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesTextbox

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesImage

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("employeesImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsLink

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<div>Client<br/>Contacts</div>").TemplateId("clientContactsLinkTemplate").HtmlAttributes(New With {.class = "add-by-link"}).HeaderAttributes(New With {.colclass = "add-by-link"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsTextbox

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsImage

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("clientContactsImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EstimateFunction

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EstimateFunction.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("Estimate<br/>Function").HtmlAttributes(New With {.class = "combo-6"}).HeaderAttributes(New With {.colclass = "combo-6"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsImage

                        ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("functionCommentsImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsTextbox

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.FunctionComments.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateComments

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateComments.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.RevisionComments

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisionDateComments.ToString).Title(ScheduleColumn.HeaderText).HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDocuments

                        ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.HasDocuments.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("taskDocumentsTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobOrder

                        If Not Model.CalculateByPredecessor Then

                            ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobOrder.ToString).Title("Order").HtmlAttributes(New With {.class = "number-3"}).HeaderAttributes(New With {.colclass = "number-3"})

                        End If

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Linked

                        If Model.CalculateByPredecessor AndAlso Not Me.IsClientPortal Then

                            ColumnFactory.Add().Title("Linked").HeaderTemplate("<!-- Linked -->").TemplateId("linkedTemplate").HtmlAttributes(New With {.class = "icon-col go-center"}).HeaderAttributes(New With {.colclass = "icon-col"})

                        End If

                    Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.SelectPreds

                        If Model.CalculateByPredecessor AndAlso Not Me.IsClientPortal Then

                            ColumnFactory.Add().Title("Select Preds").HeaderTemplate("<!-- Select Preds -->").TemplateId("selectPredsTemplate").HtmlAttributes(New With {.class = "icon-col go-center"}).HeaderAttributes(New With {.colclass = "icon-col"})

                        End If

                End Select

            End If

        Next

        ColumnFactory.Add().Template("<div></div>") 'used as a filler

    End Sub

        End Functions
