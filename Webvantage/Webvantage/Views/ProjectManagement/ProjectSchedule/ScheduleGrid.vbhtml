@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule

<script type="text/x-kendo-template" id="emptyTemplate">

</script>
<script type="text/x-kendo-template" id="levelTemplate">
    <span id="levelWrap">
        @(Html.Kendo().CheckBox().Name("SelectAllTasksCheckBox").Checked(False).HtmlAttributes(New With {.onchange = "selectAllTasks()"}).ToClientTemplate) Level
    </span>
</script>
<script type="text/x-kendo-template" id="phaseTemplate">
    # var theID = 'Phase_' + SequenceNumber; #

    @If AllowPageEdit() = True Then

        @<div class="col-cont-wrap">
            <input class="k-textbox" name="TrafficPhaseID" value="#: PhaseDescription #" id="#: theID #" style="width: 100%;" data-field="TrafficPhaseID" data-phase />
        </div>

    Else

        @(Html.Raw("#= PhaseDescription #"))

    End If

</script>
<script type="text/x-kendo-template" id="taskCodeTemplate">
    # var taskCode = TaskCode != null ? TaskCode : ''; #
    # var theID = 'TaskCode_' + SequenceNumber; #

    @If AllowPageEdit = True Then

        @(Html.Kendo().TextBox().Name("TaskCode").Value("#: taskCode #").HtmlAttributes(New With {.id = "#: theID #", .class = "code-6", .data_task = ""}).ToClientTemplate)

    Else

        @(Html.Raw("#= taskCode #"))

    End If
        
</script>
<script type="text/x-kendo-template" id="taskDescriptionTemplate">
    # var taskDesc = TaskDescription != null ? TaskDescription : ''; #
    # var theID = 'TaskDesc_' + SequenceNumber; #

    @If AllowPageEdit = True Then

        @<div class="col-cont-wrap">
            @(Html.TextArea("TaskDescription", "#: taskDesc #", New With {.class = "k-textbox ps-update", .style = "width: 100%", .id = "#: theID #", .maxlength = 40}))
        </div>

    Else

        @(Html.Raw("#= taskDesc #"))

    End If

</script>
<script type="text/x-kendo-template" id="moveLeftOrRightTemplate">

    @If AllowPageEdit = True Then
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
<script type = "text/x-kendo-template" id="linkedTemplate">
    # var theID = 'Link_' + SequenceNumber; #
    # var levels = Level.split('.'); #
    # var theLevel = levels[levels.length - 1]; #
    @(Html.Raw("# var onClick = " & If(AllowPageEdit, "!isSelectingPreds() ? 'linkItem(' + SequenceNumber + ', ' + !HasPredecessors + ')' : ''", "''") & "; #"))
    # var imgSrc = HasPredecessors == true ? 'link.png' : 'link_broken.png'; #
    #if(HasChildren == true || theLevel == "1"){#

    #} else {#
    <a href="javascript:void(0);" onclick="#: onClick #" class="img-link">
        <img src="@Url.Content("~/Images/Icons/Grey/256/#: imgSrc #")" class="icon-btn" />
    </a>
    #}#
</script>
<script type="text/x-kendo-template" id="selectPredsTemplate">
    # var theID = 'SelectPreds_' + SequenceNumber; #
    # var row = $('tr[data-uid=' + uid + ']'); #
    # var isSelecting = isSelectingPreds(); #
    # var isSelector = isSelecting && row.hasClass('pred-selector') ? true : false; #
    @(Html.Raw("# var js = " & If(AllowPageEdit(), "isSelecting === true ? 'finishSelectPredecessors()' : 'selectPredecessors(' + SequenceNumber  + ')'", "''") & "; #"))
    #if(HasChildren == true){#

    #} else if (isSelecting == true && isSelector == false) {#
    <div class="go-center">
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
<script type="text/x-kendo-template" id="predecessorsTextboxTemplate">
    #if(HasChildren == true){#

    #} else { #
    # var preds = PredecessorLevelNotation != null ? PredecessorLevelNotation : ''; #

@If AllowPageEdit = True Then

    @(Html.Raw("# var theID = 'PredecessorsTextbox_' + SequenceNumber; #"))
    @(Html.Kendo().TextBox().Name("PredecessorLevelNotation").Value("#: preds #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update"}).ToClientTemplate)

Else

    @(Html.Raw("#= preds #"))

End If

    # } #
</script>
<script type="text" id="jobOrderTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobOrder_' + SequenceNumber; #
        # var ord = JobOrder !== null ? JobOrder : ''; #
        <input name="#: theID #" id="#: theID #" type="text" class="k-textbox" value="#: ord #" data-numeric="integer" data-field="JobOrder" />
    </div>
</script>
<script type="text/x-kendo-template" id="taskStatusTemplate">
    <div class="col-cont-wrap">
        # var theID = 'TaskStatus_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        
@If AllowPageEdit = True Then

    @<div class="input-group shared-combo">
        <input class="k-textbox" name="#: theID #" data-field="TaskStatus" value="#: TaskStatus #" style="width: 100%;" data-taskStatus id="#: theID #" />
        <div class="input-group-addon addon-btn">
            <span class="k-icon k-i-arrow-s"></span>
        </div>
    </div>
    @<span class="k-invalid-msg" data-for="#: theID #"></span>

Else

    @<span data-field="TaskStatus">#: TaskStatus #</span>

End If

        # } #
    </div>
</script>
<script type="text/x-kendo-template" id="milestoneTemplate">

    @If AllowPageEdit = True Then

        @<div class="go-center">
            # var theID = 'IsMilestone_' + SequenceNumber; #
            #if(Milestone == true){#
            @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
            #}else{#
            @(Html.Kendo().CheckBox().Name("IsMilestone").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
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
<script type="text/x-kendo-template" id="jobDaysTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobDays_' + SequenceNumber; #
        # var days = JobDays !== null ? JobDays : ''; #
        #if(HasChildren == true){#

        #} else {#
        <input name="#: theID #" data-field="JobDays" id="#: theID #" type="text" class="k-textbox" value="#: days #" data-numeric="integer" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="taskStartDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(kendo.parseDate(TaskStartDate)) && TaskStartDate ? kendo.format('{0:d}', TaskStartDate) : ''; #
        # var disabled = DueDateLock === 1 ? true : false; #
        # var theID = 'TaskStartDate_' + SequenceNumber; #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        #= kendo.Template.compile($('\\#datePickerTemplate').html())({ name: 'TaskStartDate', id: theID, itemDate: theDate, isDisabled: disabled, cssClass: '' }) #
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="datePickerTemplate">
    # var theDate = !isNaN(kendo.parseDate(itemDate)) && itemDate ? kendo.format('{0:d}', itemDate) : ''; #
    # var disabled = isDisabled === true ? 'disabled' : ''; #
    <div class="input-group shared-calendar-picker">
        <input name="#: id #" type="text" class="k-textbox #: cssClass #" value="#= theDate #" id="#= id #" data-field="#: name #" data-shortdate #: disabled # />
        <div class="input-group-addon addon-btn"><span class="k-icon k-i-calendar"></span>
        </div>
    </div>
    <span class="k-invalid-msg" data-for="#: id #"></span>
</script>
<script type="text/x-kendo-template" id="jobRevisedDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(kendo.parseDate(JobRevisedDate)) && JobRevisedDate ? kendo.format('{0:d}', JobRevisedDate) : ''; #
        # var disabled = DueDateLock === 1 ? true : false; #
        # var cssClass = getClassForDueDate(theDate, DueDateLock, JobCompletedDate); #
        # var theID = 'JobRevisedDate_' + SequenceNumber; #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        #= kendo.Template.compile($('\\#datePickerTemplate').html())({ name: 'JobRevisedDate', id: theID, itemDate: theDate, isDisabled: disabled, cssClass: cssClass }) #
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="dueDateLockTemplate">

    @If AllowPageEdit = True Then

        @<div class="go-center">
            # var theID = 'DueDateLock_' + SequenceNumber; #
            #if(DueDateLock === 1){#
            @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
            #}else{#
            @(Html.Kendo().CheckBox().Name("DueDateLock").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
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
<script type="text/x-kendo-template" id="revisedDueTimeTemplate">
    # var theID = 'RevisedDueTime_' + SequenceNumber; #
    # var dueTime = RevisedDueTime != null ? RevisedDueTime : ''; #

    @If AllowPageEdit = True Then

        @(Html.Kendo().TextBox().Name("RevisedDueTime").Value("#: dueTime #").HtmlAttributes(New With {.id = "#: theID #", .class = "ps-update"}).ToClientTemplate)

    Else

        @<span>
            #= dueTime #
        </span>

    End If
    
</script>
<script type="text/x-kendo-template" id="jobDueDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(kendo.parseDate(JobDueDate)) && JobDueDate ? kendo.format('{0:d}', JobDueDate) : ''; #
        # var theID = 'JobDueDate_' + SequenceNumber; #
        #if(HasChildren == true){#
        #: theDate #
        #} else {#
        #= kendo.Template.compile($('\\#datePickerTemplate').html())({ name: 'JobDueDate', id: theID, itemDate: theDate, isDisabled: false, cssClass: '' }) #
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="jobCompletedDateTemplate">
    <div class="col-cont-wrap">
        # var theDate = !isNaN(kendo.parseDate(JobCompletedDate)) && JobCompletedDate ? kendo.format('{0:d}', JobCompletedDate) : ''; #
        # var theID = 'JobCompletedDate_' + SequenceNumber; #
        #if(HasChildren == true){#

        #} else {#
        #= kendo.Template.compile($('\\#datePickerTemplate').html())({ name: 'JobCompletedDate', id: theID, itemDate: theDate, isDisabled: false, cssClass: '' }) #
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="temporaryCompleteDateTemplate">
    <div class="col-cont-wrap">
        #: TempCompleteDateString #
    </div>
</script>
<script type="text/x-kendo-template" id="jobHoursTemplate">
    <div class="col-cont-wrap">
        # var theID = 'JobHours_' + SequenceNumber; #
        # var format = 'n2'; #
        # var val = kendo.toString(Number(JobHours), format); #
        #if(HasChildren == true){#

        #} else {#
        <input name="#: theID #" id="#= theID #" type="text" class="k-textbox" value="#: val #" data-numeric="decimal" data-format="#: format #" data-field="JobHours" />
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="dispersedHoursTemplate">

    @If AllowPageEdit = True Then

        @<div class="go-right col-cont-wrap">
            # var fmtHours = kendo.format('{0:n2}', DispersedHours); #
            #if(HasChildren == true){#
            #: fmtHours #
            #} else {#
            <a href="javascript:setEmployees('#: TaskCode #', '#: SequenceNumber #');">
                #: fmtHours #
            </a>
            #}#
        </div>

    End If
    
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
        @(Html.Raw("# var js = " & If(AllowPageEdit(), "'setEmployees(""' + TaskCode + '"", ""' + SequenceNumber + '"")'", "'void(0)'") & "; #"))
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:#: js #;">
            #: emps #
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="employeesAutoCompleteTemplate">
    # var emps = EmployeeCode ? EmployeeCode : ''; #
    # var theID = 'EmployeesAutoComplete_' + SequenceNumber; #
    #if(HasChildren == true){#

    #} else {#

    @If AllowPageEdit = True Then

        @<div class="col-cont-wrap">
            <input id="#= theID #" class="ps-auto-complete" style="width:100%" value="#: emps #"/>
        </div>

    Else

        @<span>
            #= emps.split(",").join(", ") #
        </span>

    End If

    #}#
</script>
<script type="text/x-kendo-template" id="employeesTextTemplate">
    # var emps = EmployeeCode ? EmployeeCode : ''; #
    # var theID = 'EmployeeCodeTextBox_' + SequenceNumber; #
    #if(HasChildren == true){#

    #} else {#

    @If AllowPageEdit = True Then

        @<div class="col-cont-wrap">
            @(Html.TextArea("EmployeeCode", "#: emps #", New With {.class = "k-textbox ps-update", .style = "width: 100%", .id = "#: theID #"}))
        </div>

    Else

        @<span>
            #= emps.split(",").join(", ") #
        </span>

    End If
        
    #}#
</script>
<script type="text/x-kendo-template" id="employeesImageTemplate">
    <div class="col-cont-wrap">
        # var theID = 'EmpImg_' + SequenceNumber; #
        @(Html.Raw("# var js = " & If(AllowPageEdit, "'setEmployees(""' + TaskCode + '"", ""' + SequenceNumber + '"")'", "'void(0)'") & "; #"))
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:void(0);" title="Employees">
            <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick="#: js #">
                <img src="@Url.Content("~/Images/Icons/White/256/users.png")" class="icon-image" />
            </div>
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="employeesNonEditable">
    # var emps = EmployeeCode ? EmployeeCode : ''; #
    #= emps.split(",").join(", ") #
</script>
<script type="text/x-kendo-template" id="clientContactsLinkTemplate">
    <div class="go-center col-cont-wrap">
        # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : 'Add'; #
        # var canEdit = getModelData().CanUserEdit; #
        # var js = "setClientContacts(" + (TaskCode ? "'" + TaskCode + "'" : null) + ", " + SequenceNumber + ")"; #
        @(Html.Raw("# js = " & If(AllowPageEdit(), "js", "'void(0)'") & "; #"))
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:#= js #;">
            #: clContacts #
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="clientContactsTextTemplate">
    # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : ''; #
    # var theID = 'ClientContactsText_' + SequenceNumber; #
    #if(HasChildren == true){#

    #} else {#

    @If AllowPageEdit() = True Then

        @<div class="go-center col-cont-wrap">
            @(Html.TextArea("ClientContact", "#: clContacts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))    
        </div>

    Else

        @<span>
            #= clContacts #
        </span>

    End If

    #}#
</script>
<script type="text/x-kendo-template" id="clientContactsImageTemplate">
    <div class="col-cont-wrap">
        # var clContacts = ClientContact ? ClientContact.split(",").join(", ") : 'Add'; #
        # var js = "setClientContacts(" + (TaskCode ? "'" + TaskCode + "'" : null) + ", " + SequenceNumber + ")"; #
        @(Html.Raw("# js = " & If(AllowPageEdit(), "js", "'void(0)'") & "; #"))
        #if(HasChildren == true){#

        #} else {#
        <a href="javascript:void(0);">
            <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick="#: js #" title="#: clContacts #">
                <img src="@Url.Content("~/Images/Icons/White/256/user_telephone.png")" class="icon-image" title="#: clContacts #" />
            </div>
        </a>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="estimateFunctionTemplate">
    
    # var estFnc = EstimateFunction === null ? '' : EstimateFunction; #

    @If AllowPageEdit = True Then

        @<div class="col-cont-wrap">
            # var theID = 'EstimateFunction_' + SequenceNumber; #
            #if(HasChildren == true){#

            #}else{#
            <input class="k-textbox" id="#: theID #" name="EstimateFunction" value="#: estFnc #" style="width: 100%;" data-estimateFunction />
            #}#
        </div>

    Else

        @<div class="col-cont-wrap">
            # var theID = 'EstimateFunction_' + SequenceNumber; #
            #if(HasChildren == true){#

            #}else{#
            #= estFnc #
            #}#
        </div>

    End If
    
</script>
<script type="text/x-kendo-template" id="functionCommentsTextTemplate">
    # var fncCmts = FunctionComments ? FunctionComments : ''; #
    # var theID = 'FunctionComments_' + SequenceNumber; #

    @If AllowPageEdit = True Then

        @(Html.TextArea("FunctionComments", "#: fncCmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))

    Else

        @(Html.TextArea("FunctionComments", "#: fncCmts #", New With {.class = "k-textbox", .id = "#: theID #", .style = "width: 100%", .readonly = ""}))

    End If

</script>
<script type="text/x-kendo-template" id="functionCommentsImageTemplate">
    # var js = 'setTaskComments("' + SequenceNumber + '")'; #
    <a href="javascript:void(0);" title="Comments">
        <div class="icon-background background-color-sidebar" style="background: \\#00BCD4 !important;" onclick="#: js #">
            <img src="@Url.Content("~/Images/Icons/White/256/messages.png")" class="icon-image" />
        </div>
    </a>
</script>
<script type="text/x-kendo-template" id="dueDateCommentsTemplate">
    # var Cmts = DueDateComments ? DueDateComments : ''; #
    # var theID = 'DueDateComments_' + SequenceNumber; #
    
    @If AllowPageEdit = True Then

        @(Html.TextArea("DueDateComments", "#: Cmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))

    Else

        @(Html.TextArea("DueDateComments", "#: Cmts #", New With {.class = "k-textbox", .id = "#: theID #", .style = "width: 100%", .readonly = ""}))

    End If

</script>
<script type="text/x-kendo-template" id="revisionDateCommentsTemplate">
    # var Cmts = RevisionDateComments ? RevisionDateComments : ''; #
    # var theID = 'RevisionDateComments_' + SequenceNumber; #

    @If AllowPageEdit = True Then

        @(Html.TextArea("RevisionDateComments", "#: Cmts #", New With {.class = "k-textbox ps-update", .id = "#: theID #", .style = "width: 100%"}))

    Else

        @(Html.TextArea("RevisionDateComments", "#: Cmts #", New With {.class = "k-textbox", .id = "#: theID #", .style = "width: 100%", .readonly = ""}))

    End If

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
    input[type=number]::-webkit-inner-spin-button, 
    input[type=number]::-webkit-outer-spin-button { 
      -webkit-appearance: none; 
      margin: 0; 
    }
    input::-webkit-calendar-picker-indicator {
      display: none;
    }

    .k-grid .k-textbox, .k-grid .k-numerictextbox {
        width: 100% !important;
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
        background: lightblue!important;
    }
    #status-popup {
        width: 150px;
        display: none;
    }
    tr.k-footer-template {
        display: none;
    }
    tr.k-footer-template:last-child {
        display: table-row;
    }
    .fixed-header {
        position: fixed;
        z-index: 1;
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
                                                                                                                    .Create(Sub(r) r.Action("CreateProjectScheduleTask", "ProjectSchedule").Data("getModelData")) _
                                                                                                                    .Update(Sub(u) u.Action("UpdateProjectScheduleTask", "ProjectSchedule").Data("getModelData")) _
                                                                                                                    .Destroy(Sub(d) d.Action("DeleteScheduleTasks", "ProjectSchedule").Type(HttpVerbs.Post)) _
                                                                                                                    .Model(Sub(m)
                                                                                                                               m.Id(Function(i) i.SequenceNumber)
                                                                                                                               m.ParentId(Function(i) i.ParentTaskSequenceNumber)
                                                                                                                               m.Expanded(True)
                                                                                                                               m.Field(Function(i) i.SequenceNumber).DefaultValue(-1).Editable(False)
                                                                                                                               m.Field(Function(i) i.JobNumber).Editable(False)
                                                                                                                               m.Field(Function(i) i.JobComponentNumber).Editable(False)
                                                                                                                           End Sub) _
                                                                                                                    .AutoSync(True) _
                                                                                                                    .Events(Sub(e)
                                                                                                                                e.RequestStart("treeListRequestStart")
                                                                                                                                e.RequestEnd("treeListRequestEnd")
                                                                                                                            End Sub).Aggregates(Sub(a)
                                                                                                                                                    a.Add(Function(i) i.DispersedHours).Sum()
                                                                                                                                                    a.Add(Function(i) i.JobHours).Sum()
                                                                                                                                                    a.Add(Function(i) i.PostedHours).Sum()
                                                                                                                                                End Sub).ServerOperation(False)
                                                                                                                End Sub) _
                                                                                                    .Events(Sub(e)
                                                                                                                e.DataBound("treeListDataBound")
                                                                                                                e.DataBinding("treeListDataBinding")
                                                                                                                e.Expand("treeListExpand")
                                                                                                                e.Collapse("treeListCollapse")
                                                                                                                e.Change("selectionChanged")
                                                                                                            End Sub) _
                                                                                                    .Selectable(True) _
                                                                                                    .Messages(Sub(m)
                                                                                                                  m.NoRows(" ")
                                                                                                              End Sub) _
                                                .HtmlAttributes(New With {.style = ""}))

</div>

<div id="ktl">


</div>

@If Me.IsClientPortal = False AndAlso Me.Model.IsQuickEdit = False Then

    @(Html.Kendo.ContextMenu().Name("TaskContextMenu").Orientation(ContextMenuOrientation.Vertical).Target("#ProjectSchedule").Filter("tbody > tr").Items(Sub(i)
                                                                                                                                                              i.Add().Text("Task Details").HtmlAttributes(New With {.id = "TaskDetails"})
                                                                                                                                                              i.Add().Separator(True)
                                                                                                                                                              If Model.CanUserEdit Then

                                                                                                                                                                  i.Add().Text("Add Task Above").HtmlAttributes(New With {.id = "ContextAbove"})

                                                                                                                                                                  If Model.CalculateByPredecessor Then

                                                                                                                                                                      i.Add().Text("Add Task Into").HtmlAttributes(New With {.id = "ContextInto"})

                                                                                                                                                                  End If

                                                                                                                                                                  i.Add().Text("Add Task Below").HtmlAttributes(New With {.id = "ContextBelow"})

                                                                                                                                                              End If
                                                                                                                                                              If Model.CanUserEdit Then

                                                                                                                                                                  i.Add().Separator(True)
                                                                                                                                                                  i.Add().Text("Delete Task").HtmlAttributes(New With {.id = "DeleteTask"})

                                                                                                                                                              End If

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

<div id="calendar-popup">

</div>
<ul class="dropdown-menu" id="status-popup">
    <li><a id="Status_Projected">Projected</a></li>
    <li><a id="Status_Active">Active</a></li>
    <li style="display:none;"><a id="Status_LowPriority">Low Priority</a></li>
    <li style="display:none;"><a id="Status_HighPriority">High Priority</a></li>
</ul>

@If Model.IsQuickEdit = False Then

@(Html.Kendo.Window().Name("QuickAddTaskWindow").Title("Quick Add Task").Content(QuickAddContent().ToHtmlString).Width(600).Modal(True).Actions(Sub(a)
                                                                                                                                                        a.Close()
                                                                                                                                                    End Sub).Events(Sub(e)
                                                                                                                                                                        e.Open("QuickAddTaskWindowOpen")
                                                                                                                                                                        e.Close("QuickAddTaskWindowClose")
                                                                                                                                                                    End Sub).Visible(False))

End If

@Section PageScripts


End Section

<script type="text/javascript">

    var toolTip;

    $(document).ready(function () {

        dropTarget = $('#DropTarget');
        dropTarget.hide();
        $('.div-btn').kendoButton();
        $('#dropAbove').kendoDropTarget({ drop: dropAbove });
        $('#dropInto').kendoDropTarget({ drop: dropInto });
        $('#dropBelow').kendoDropTarget({ drop: dropBelow });
        $('#calendar-popup').hide();

        $('th[colclass]').each(function() {
            $(this).addClass($(this).attr('colclass'));
        });
        toolTip = $('#ProjectSchedule').kendoTooltip({
            filter: ".select-preds-wrap",
            position: "right",
            content: function(e){
                var title = getModelData().CanUserEdit === true ? 'Click to Select Predecessor(s)' : 'Predecessor(s)';
                var content = '<div style="font-weight: bold;">' + title + '</div>';
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

    function totalDisbursedHours() {
        var totalHours = 0;
        $.each(treeList.dataSource.view(), function () {
            if (this.HasChildren === false) {
                totalHours += this.DispersedHours;
            }
        });
        return totalHours;
    }
    function totalJobHours() {
        var totalHours = 0;
        $.each(treeList.dataSource.view(), function () {
            if (this.HasChildren === false) {
                totalHours += this.JobHours;
            }
        });
        return totalHours;
    }
    function totalPostedHours() {
        var totalHours = 0;
        $.each(treeList.dataSource.view(), function () {
            if (this.HasChildren === false) {
                totalHours += this.PostedHours;
            }
        });
        return totalHours;
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
        ShowingEmployees: @Html.Raw(Json.Encode(Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete) OrElse Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesLink) OrElse Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesTextbox))),
        ShowingClientContacts: @Html.Raw(Json.Encode(Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsLink) OrElse Model.IsColumnVisible(AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsTextbox))),
        IsClientPortal: @Html.Raw(Json.Encode(Me.IsClientPortal)),
        CanUserEdit: @Html.Raw(Json.Encode(Me.Model.CanUserEdit)),
        AlertSourceApp: @Html.Raw(Json.Encode(CInt(Webvantage.MiscFN.Source_App.ProjectSchedule))),
        TaskAlertSource: @Html.Raw(Json.Encode(CInt(Webvantage.MiscFN.Source_App.ProjectScheduleTask))),
        IsQuickEdit: @Html.Raw(Json.Encode(CBool(Model.IsQuickEdit))),
        UsingATaskLevelFilter: function () {
            if (this.TaskCode || this.RoleCode || this.EmployeeCode) {
                return true;
            }
            if (this.PhaseFilter) {
                if (this.PhaseFilter !== 'no_filter') {
                    return true;
                }
            }
            return false;
        }, 
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

            If Model.IsQuickEdit Then

                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Level.ToString).Template("<span>#: Level #</span>").HeaderTemplateId("levelTemplate").HtmlAttributes(New With {.autofit = True, .minwidth = 100})
                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString).HtmlAttributes(New With {.Class = "code-6"}).HeaderAttributes(New With {.colclass = "code-6"})
                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString).HtmlAttributes(New With {.class = "text-40"}).HeaderAttributes(New With {.colclass = "text-40"})

                If Model.CalculateByPredecessor = True AndAlso AllowPageEdit() Then

                    ColumnFactory.Add().Title("").TemplateId("moveLeftOrRightTemplate").HtmlAttributes(New With {.class = "move-lr"}).HeaderAttributes(New With {.colclass = "move-lr"})

                End If

            Else

                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Level.ToString).Title("Level").Template("<span>#: Level #</span>").HeaderTemplateId("levelTemplate").HtmlAttributes(New With {.autofit = True, .minwidth = 100})

                For Each ScheduleColumn In Model.Columns.OrderBy(Function(c) c.Order)

                    If ScheduleColumn.Visible = True Then

                        Select Case ScheduleColumn.ColumnType

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Phase

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PhaseDescription.ToString).Title(ScheduleColumn.HeaderText).TemplateId("phaseTemplate").HtmlAttributes(New With {.class = "combo-40"}).HeaderAttributes(New With {.colclass = "combo-40"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCode

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskCode.ToString).Title(ScheduleColumn.HeaderText).TemplateId("taskCodeTemplate").HtmlAttributes(New With {.class = "code-6"}).HeaderAttributes(New With {.colclass = "code-6"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDescription

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskDescription.ToString).Title(ScheduleColumn.HeaderText).TemplateId("taskDescriptionTemplate").HtmlAttributes(New With {.class = "text-40"}).HeaderAttributes(New With {.colclass = "text-40"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.MoveLeftOrRight

                                If Model.CalculateByPredecessor = True AndAlso AllowPageEdit() Then

                                    ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("moveLeftOrRightTemplate").HtmlAttributes(New With {.class = "move-lr"}).HeaderAttributes(New With {.colclass = "move-lr"})

                                End If

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsTextbox

                                If Model.CalculateByPredecessor Then

                                    ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("predecessorsTextboxTemplate").HtmlAttributes(New With {.class = "pred-input"}).HeaderAttributes(New With {.colclass = "pred-input"})

                                End If

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PredecessorsList

                                If Model.CalculateByPredecessor Then

                                    ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PredecessorLevelNotation.ToString).HeaderTemplate("<!-- -->").HtmlAttributes(New With {.class = "pred-list"}).HeaderAttributes(New With {.colclass = "pred-list"})

                                End If

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStatus

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStatus.ToString).Title(ScheduleColumn.HeaderText).TemplateId("taskStatusTemplate").HtmlAttributes(New With {.class = "combo-15"}).HeaderAttributes(New With {.colclass = "combo-15"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.Milestone

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.Milestone.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-center' style='padding-right: 4px'>M/S</div>").TemplateId("milestoneTemplate").HtmlAttributes(New With {.class = "cb-sm-hdr"}).HeaderAttributes(New With {.colclass = "cb-sm-hdr"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobDays

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDays.ToString).Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("jobDaysTemplate")).HtmlAttributes(New With {.class = "number-3"}).HeaderAttributes(New With {.colclass = "number-3"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskStartDate

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TaskStartDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("taskStartDateTemplate")).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDueDate

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobRevisedDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("jobRevisedDateTemplate")).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateLock

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateLock.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-center' style='padding-right: 4px'><span class='k-icon k-i-lock'></span></div>").TemplateId("dueDateLockTemplate").HtmlAttributes(New With {.class = "cb-sm-hdr"}).HeaderAttributes(New With {.colclass = "cb-sm-hdr"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueTime

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisedDueTime.ToString).Title(ScheduleColumn.HeaderText).TemplateId("revisedDueTimeTemplate").HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.OriginalDueDate

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobDueDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("jobDueDateTemplate")).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.CompletedDate

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobCompletedDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("jobCompletedDateTemplate")).HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TempCompletedDate

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.TemporaryCompleteDate.ToString).Format("{0:d}").Title(ScheduleColumn.HeaderText).TemplateId("temporaryCompleteDateTemplate").HtmlAttributes(New With {.class = "date-sm"}).HeaderAttributes(New With {.colclass = "date-sm"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobHours

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobHours.ToString).Format("{0:n2}").Title(ScheduleColumn.HeaderText).TemplateId(EditorTemplateSecurity("jobHoursTemplate")).HeaderTemplate("<div class='go-right'>Default<br/>Hours</div>").FooterTemplate("#= kendo.format('{0:n2}', totalJobHours()) #").HtmlAttributes(New With {.Class = "def-hrs"}).HeaderAttributes(New With {.colclass = "def-hrs"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DispersedHours

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DispersedHours.ToString).Format("{0:n2}").FooterTemplate("#= kendo.format('{0:n2}', totalDisbursedHours()) #").Title(ScheduleColumn.HeaderText).HeaderTemplate("<div class='go-right'>Disbursed<br/>Hours</div>").TemplateId(EditorTemplateSecurity("dispersedHoursTemplate")).HtmlAttributes(New With {.class = "disb-hrs"}).HeaderAttributes(New With {.colclass = "disb-hrs"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PostedHours

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PostedHours.ToString).Format("{0:n2}").Title(ScheduleColumn.HeaderText).HeaderTemplate("Posted<br/>Hours").TemplateId(EditorTemplateSecurity("postedHoursTemplate")).FooterTemplate("#= kendo.format('{0:n2}', totalPostedHours()) #").HtmlAttributes(New With {.class = "posted-hrs"}).HeaderAttributes(New With {.colclass = "posted-hrs"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.PercentComplete

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.PercentComplete.ToString).Format("{0:n2}").Title(ScheduleColumn.HeaderText).HeaderTemplate("Percentage<br/>Complete").TemplateId(EditorTemplateSecurity("percentCompleteTemplate")).HtmlAttributes(New With {.class = "pct-comp"}).HeaderAttributes(New With {.colclass = "pct-comp"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesLink

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("employeesLinkTemplate").HtmlAttributes(New With {.class = "add-by-link"}).HeaderAttributes(New With {.colclass = "add-by-link"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesAutoComplete

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("employeesAutoCompleteTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesTextbox

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("employeesTextTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EmployeesImage

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("employeesImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsLink

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<div>Client<br/>Contacts</div>").TemplateId("clientContactsLinkTemplate").HtmlAttributes(New With {.class = "add-by-link"}).HeaderAttributes(New With {.colclass = "add-by-link"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsTextbox

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).TemplateId("clientContactsTextTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.ClientContactsImage

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("clientContactsImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.EstimateFunction

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.EstimateFunction.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("Estimate<br/>Function").TemplateId("estimateFunctionTemplate").HtmlAttributes(New With {.class = "combo-6"}).HeaderAttributes(New With {.colclass = "combo-6"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsImage

                                ColumnFactory.Add().Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("functionCommentsImageTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskCommentsTextbox

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.FunctionComments.ToString).Title(ScheduleColumn.HeaderText).TemplateId("functionCommentsTextTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.DueDateComments

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.DueDateComments.ToString).Title(ScheduleColumn.HeaderText).TemplateId("dueDateCommentsTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.RevisionComments

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.RevisionDateComments.ToString).Title(ScheduleColumn.HeaderText).TemplateId("revisionDateCommentsTemplate").HtmlAttributes(New With {.class = "text-xl"}).HeaderAttributes(New With {.colclass = "text-xl"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.TaskDocuments

                                ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.HasDocuments.ToString).Title(ScheduleColumn.HeaderText).HeaderTemplate("<!-- -->").TemplateId("taskDocumentsTemplate").HtmlAttributes(New With {.class = "icon-col"}).HeaderAttributes(New With {.colclass = "icon-col"})

                            Case AdvantageFramework.ProjectSchedule.Classes.Schedule.ScheduleColumn.Type.JobOrder

                                If Not Model.CalculateByPredecessor Then

                                    ColumnFactory.Add().Field(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.JobOrder.ToString).Title("Order").Format("{0:n0}").TemplateId(EditorTemplateSecurity("jobOrderTemplate")).HtmlAttributes(New With {.class = "number-3"}).HeaderAttributes(New With {.colclass = "number-3"})

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

            End If

            ColumnFactory.Add().Template("<div></div>") 'used as a filler

        End Sub

        Private Function EditorTemplateSecurity(ByVal TemplateName As String, Optional ByVal NonEditableTemplateName As String = "") As String

            If Me.AllowPageEdit() = False Then

                TemplateName = NonEditableTemplateName

            End If

            Return TemplateName

        End Function

        Private Function AllowPageEdit() As Boolean

            Return Me.IsClientPortal = False AndAlso Me.Model.CanUserEdit = True

        End Function

        End Functions

@Helper QuickAddContent()

    @<div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-2" for="QuickAddTaskCode">Code:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox.Name("QuickAddTaskCode").HtmlAttributes(New With {.class = "code-10", .maxlength = "10", .data_task = ""}))
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-2" for="QuickAddTaskDescription">Description:</label>
            <div class="col-sm-10">
                @(Html.Kendo.TextBox.Name("QuickAddTaskDescription").HtmlAttributes(New With {.style = "width: 100%", .maxlength = "40"}))
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-12 text-right">
                @(Html.Kendo.Button.Name("QuickAdd").Content("Add").HtmlAttributes(New With {.class = "k-primary"}))
                @(Html.Kendo.Button.Name("QuickAddAbove").Content("Add Above Selected").HtmlAttributes(New With {.class = "k-primary"}))
                @Code                                       If Model.CalculateByPredecessor = True Then
                        @(Html.Kendo.Button.Name("QuickAddInto").Content("Add Into Selected").HtmlAttributes(New With {.class = "k-primary"})) 
                    End If
                                        End Code
                @(Html.Kendo.Button.Name("QuickAddBelow").Content("Add Below Selected").HtmlAttributes(New With {.class = "k-primary"}))
            </div>
        </div>
    </div>

End Helper


