@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard

<style>
body {
  overflow: hidden !important; /* Hide scrollbars */
}
    .details > table {
        width: 100%;
        margin-left: 2px;
        border-collapse: separate;
        border-spacing: 1px;
    }

    .e-kanbantooltiptemplate {
        width: 150px;
        padding: 3px;
    }

        .e-kanbantooltiptemplate > table {
            width: 100%;
        }

        .e-kanbantooltiptemplate td {
            vertical-align: top;
        }

    td.details {
        padding-left: 10px;
    }

    .CardHeader {
        font-weight: bolder;
    }

    .e-templatetable {
        width: 100%;
    }

    .details > table {
        margin-left: 2px;
        border-collapse: separate;
        border-spacing: 2px;
        width: 100%;
    }

    .details td {
        vertical-align: top;
    }

    .details {
        padding: 8px 8px 10px 0;
    }

    .photo {
        padding: 8px 6px 10px 6px;
        text-align: center;
        width: 50px;
    }


    .CardHeader {
        font-weight: bolder;
        padding-right: 10px;
    }

    .footer {
        height: 34px !important;
        background-color: #00BCD4;
    }

    .type-indicator {
        border-radius: 50%;
        height: 24px;
        width: 24px;
        margin-left: 5px;
        margin-top: 1px;
        vertical-align: top;
        text-align: center;
        background-color: #757575;
    }

    .type-indicator-text {
        position: relative;
        font-size: 16px;
        color: #FFFFFF;
    }

    .board-card-action-icon {
        height: 24px;
        width: 24px;
    }

    .board-card-footer {
    }

    .e-kanban.custom-class .e-headercelldiv {
        width: auto !important;
    }

    #Kanban_Context > li.priority-selected {
        background: #ddd;
    }

    ul {
        list-style-type: none;
        text-align: justify;
        margin: 0px 0px 0px 10px;
    }

    input[type="radio"] {
        vertical-align: text-top;
    }

    .card-template-tooltip {
        text-align: left;
        max-width: 400px;
        padding: 4px;
    }
    .job-jacket-options span {
        color: #1a1a1a;
        font-size: 14px;
    }

    .dropdown-submenu {
        position: relative;
    }

    .wv-icon-button span.wvi-vertical-ellipsis {
        font-size: 18px !important;
        line-height: 20px;
    }
    .dropdown-submenu > .dropdown-menu {
        top: 0;
        left: 100%;
        margin-top: -6px;
        margin-left: -1px;
        -webkit-border-radius: 0 6px 6px 6px;
        -moz-border-radius: 0 6px 6px;
        border-radius: 0 6px 6px 6px;
    }

        .dropdown-submenu:hover > .dropdown-menu {
            display: block;
        }
        .dropdown-menu a {
            font-size: 14px;
        }
        .dropdown-submenu > a:after {
            display: block;
            content: " ";
            float: right;
            width: 0;
            height: 0;
            border-color: transparent;
            border-style: solid;
            border-width: 5px 0 5px 5px;
            border-left-color: #ccc;
            margin-top: 5px;
            margin-right: -10px;
        }

        .dropdown-submenu:hover > a:after {
            border-left-color: #fff;
        }

        .dropdown-submenu.pull-left {
            float: none;
        }

            .dropdown-submenu.pull-left > .dropdown-menu {
                left: -100%;
                margin-left: 10px;
                -webkit-border-radius: 6px 0 6px 6px;
                -moz-border-radius: 6px 0 6px 6px;
                border-radius: 6px 0 6px 6px;
            }
</style>
<script id="titleToolTip" type="text/x-kendo-template">
    <div style="text-align: left;">
        <p>#=target.data('Title')#</p>
        <div>
            #=target.data('LastModifiedDate')#
        </div>
    </div>
</script>
<script id="customToolTip" type="text/x-jsrender">
    <div>
        <div style="text-align: left; font-size: 12px;">
            {{encodeHtml:Title}}
        </div>
        {{if LastModifiedDate }}
        <div>
            {{lastModFormat:LastModifiedDate}}{{if LastModifiedBy}}&nbsp;by:&nbsp;&nbsp;{{:LastModifiedBy}}{{/if}}
        </div>
        {{/if}}
        {{if CreateDate }}
        <div>
            {{createdFormat:CreateDate}}
        </div>
        {{/if}}
        {{if DueDateStr || TimeDue }}
        <div class="dueDate">Due: <span class="{{:DueDateCSS}}" title="{{:DueDateToolTip}}">{{:DueDateStr}}{{if TimeDue}}&nbsp;&nbsp;{{:TimeDue}}{{/if}}</span></div>
        {{/if}}
    </div>
</script>
<script id="customCardTemplate" type="text/x-jsrender">
    <div class="wv-card priority-{{:Priority}}" >
        <div class="content">
            <div id="cardTitle" class="title{{if IsRead == false}} not-is-read{{/if}}" title="{{tooltipFormat:Title}} {{lastModFormat:LastModifiedDate}}{{if LastModifiedBy}} by {{tooltipFormat:LastModifiedBy}}{{/if}}
{{if AssignNumber}} ID: {{:AssignNumber}}{{/if}}" onclick="viewCardDetails({{:AlertID}}, '{{encodeHtml2:Title}}')" style="cursor: pointer;">
                {{if Indicator }}
                <span class="wv-badge" title="{{:AlertCategoryName}}">{{:Indicator}}</span>
                {{/if}}
                {{encodeHtml:Title}}
            </div>
            {{if BoardColumnStateCount > 1  }}
            <div class="subtitle">{{:CardStateName}}</div>
            {{else AlertStateID > 0 }}
            <div class="subtitle">{{:AlertStateName}}</div>
            {{/if}}
            <div class="clientName" title="{{:ClientName}}">{{:ClientName}}</div>
            <div class="jobName" title="{{:JobName}}">{{:JobName}}</div>
            {{if DueDateStr || TimeDue }}
            <div class="dueDate" title="{{:DueDateStr}} {{:TimeDue}}">Due Date: <span class="{{:DueDateCSS}}" title="{{:DueDateToolTip}}">{{:DueDateStr}}&nbsp;&nbsp;{{:TimeDue}}</span></div>
            {{/if}}
            <!-- <div>Commit: </div> -->
            <ul class="list-inline" >
                {{if ShowChecklists == true && ChecklistTotal > 0 }}
                <li title="Checklist items completed">
                    <span id="checklist-icon" class="wvi wvi-clipboard-checks"></span> <span class="checklist-items">{{:ChecklistComplete}}/{{:ChecklistTotal}}</span>
                </li>
                {{/if}}
                {{if false}}
                <li class="">
                    <span class="wvi wvi-clock "></span> <span class="alert-hours">40/70</span><small><i> hours allocated.</i></small>
                </li>
                {{/if}}
            </ul>
            {{if Assignees }}
            <div class="assignees">
                {{for Assignees }}
                {{if IsCurrentNotify }}
                <div class="icon-wrapper" title="{{tooltipFormat:EmployeeFullName}}{{if IsRead == true}} (Read){{/if}}{{if IsRead == false}} (Not read){{/if}}{{if IsTaskTempComplete == true}} (Completed){{/if}}">
                    <img src='@Url.Action("EmployeePicture", "Utilities")/{{:EmployeeCode}}' class="wv-employee-img-thumbnail {{if IsTaskTempComplete == true}}wv-task-complete complete-icon{{/if}}" />
                    {{if IsTaskTempComplete == true}}
                    <span class="complete-icon glyphicon glyphicon-ok"></span>
                    {{/if}}
                </div>
                {{/if}}
                {{/for}}
            </div>
            {{/if}}
        </div>
        <div class="wv-footer">           
            {{if Indicator }}
            <span class="wv-badge" title="{{:AlertCategoryName}}">{{:Indicator}}</span>
            {{/if}}
            {{if IsAutoRoute == true }}
            <ul class="list-inline pull-left text-center" style="height: 22px;">
                <li>
                    <button class="btn btn-link" title="Auto Routed Assignment" style="cursor:default !important;"><span class="wvi wvi-arrow-u-turn"></span></button>
                </li>
            </ul>
            {{/if}}
            <ul class="list-inline pull-right text-center" style="height: 22px;">
                {{if TsActive == true}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Add Time" title="Add Time" onclick="openAddWorkItemTimeDialog({{:AlertID}}, {{:JobNumber}}, {{:JobComponentNumber}}, {{:TaskSequenceNumber}});" href="javascript:void(0)"><span class="wvi wvi-clock"></span></button>
                </li>
                {{/if}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Hours" title="Hours" onclick="openWeeklyHoursDialog({{:AlertID}}, null);" href="javascript:void(0)"><span class="wvi wvi-calendar-7"></span></button>
                </li>
                {{if !IsTask || IsTask == false}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Complete assignment" title="Complete assignment" onclick="completeAssignment(this, {{:AlertID}});" href="javascript:void(0)"><span class="wvi wvi-check"></span></button>
                </li>
                {{/if}}
                {{if IsTask == true}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Set employees" title="Set employees" onclick="setTaskEmployees({{:JobNumber}}, {{:JobComponentNumber}}, {{:TaskSequenceNumber}});" href="javascript:void(0)"><span class="wvi wvi-users-relation2"></span></button>

                </li>
                {{if MyTask == true}}
                {{if MyTaskCompleted == true}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Mark not temp complete" title="Mark not temp complete" onclick="markTempComplete(this, {{:JobNumber}}, {{:JobComponentNumber}}, {{:TaskSequenceNumber}});" href="javascript:void(0)"><span class="wvi wvi-undo"></span></button>
                </li>
                {{else}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="Mark temp complete" title="Mark temp complete" onclick="markTempComplete(this, {{:JobNumber}}, {{:JobComponentNumber}}, {{:TaskSequenceNumber}});" href="javascript:void(0)"><span class="wvi wvi-check"></span></button>
                </li>
                {{/if}}
                {{/if}}
                {{/if}}
                <li>
                    <button class="wv-icon-link wv-icon-button btn-link" alt="View card details" title="View card details" onclick="viewCardDetails({{:AlertID}}, '{{encodeHtml:Title.replace("'","\'")}}')" href="javascript:void(0)"><span class="wvi wvi-magnifying-glass"></span></button>
                </li>
            </ul>
        </div>
    </div>
</script>
<script id="editDialog" type="text/template">
    <iframe id="hoursIframe" style="height: 590px; width: 800px; border: 1px solid white;"></iframe>
    <div id="addTable" style="width:645px; padding-left: 2px;">
    </div>
</script>
<script id="newWorkItemHoursFooter" type="text/x-jsrender">
    <div style="text-align: right;">
        <div class="k-button-group">
            <button id='workItemTimeSave' class="k-primary">Add</button>
            <button id='workItemTimeCancel'>Cancel</button>
        </div>
    </div>
</script>
<div class="board-options">
    <h5 class="">
        Board Options
        <button id="optionsButton" class="btn btn-link" type="button" data-toggle="collapse" data-target="#editDetails" aria-expanded="false" aria-controls="collapseExample" onclick="toggleOptions()">
            <span class="k-icon k-i-arrow-60-down"></span>
        </button>
    </h5>
    <div class="collapse in" id="editDetails">
        <div class="row">
            <div class="col-md-6 col-xs-12">
                <h6>
                    Filter Options
                </h6>
                <div class="form-group">
                    <div class="input-group" id="filter-cards">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-filter"></span></div>
                        <input id="filterInput" name="filterInput" type="text" class="e-textbox" value="" style="" onkeyup="filterByText()" onfocus="this.value = this.value;" placeholder="Filter cards" />

                        <div class="input-group-addon">
                            @Html.EJ().CheckBox("CheckboxFilterOnlyBacklog").Value("OnlyBacklog").Size(Size.Small).ClientSideEvents(Sub(evt)
                                                                                                                                        evt.Change("filterByBacklog")
                                                                                                                                    End Sub)
                            <span>Only Filter backlog</span>
                        </div>
                    </div>
                    <div class="input-group" style="margin-top: 5px;">
                        <div class="input-group-addon"><span class="glyphicon glyphicon-user"></span></div>
                        @Html.Kendo().MultiSelect().Name("FilterEmployees").Placeholder("Filter assignees on board").DataSource(Sub(ds)
                                                                                                                                    ds.Read(Sub(read)
                                                                                                                                                read.Action("GetBoardFilterEmployees", "Agile", New With {.SprintID = Model.SprintHeaderID})
                                                                                                                                            End Sub)
                                                                                                                                End Sub).DataTextField("Name").DataValueField("Code").Events(Sub(evt)
                                                                                                                                                                                                 evt.Change("filterEmployees")
                                                                                                                                                                                             End Sub).HtmlAttributes(New With {.class = "wv-ej-autocomplete"})


                        <div class="input-group-addon">
                            @Html.EJ().CheckBox("CheckboxFilterBacklogByEmployee").Value("EmployeeBacklog").Size(Size.Small).ClientSideEvents(Sub(evt)
                                                                                                                                                  evt.Change("filterByBacklogByEmployee")
                                                                                                                                              End Sub)
                            <span>Filter backlog</span>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div style="float: left; margin-right:5px; margin-bottom: 5px;">
                    <div>
                        <h6>Swim lanes by</h6>
                        @Html.Kendo().ButtonGroup().Name("SwimBy").Selection("single").Items(Sub(i)
                                                                                                 i.Add().Text("Client").HtmlAttributes(New With {.swim_by = "ClientName", .title = "Groups the board by client name"})
                                                                                                 i.Add().Text("None").HtmlAttributes(New With {.swim_by = "None", .title = "No grouping"})
                                                                                                 i.Add().Text("Job").HtmlAttributes(New With {.swim_by = "JobName", .title = "Groups the board by job"})
                                                                                             End Sub).Events(Sub(e)
                                                                                                                 e.Select("swimByOnSelect")
                                                                                                             End Sub).Index(1)
                    </div>
                    <div>
                        <div class="checkbox" style="clear: both;">
                            <label>
                                <input type="checkbox" value="expand" id="swimExpand" name="swim" onclick="swimExpandCheckboxChanged();">&nbsp;Collapse
                            </label>
                        </div>
                    </div>
                </div>
                <div style="float: left; margin-bottom: 5px;">
                    <div style="margin-left: 20px;">
                        <h6>Backlog Sort</h6>
                        @Html.Kendo().ButtonGroup().Name("BacklogSortBy").Selection("single").Items(Sub(i)
                                                                                                        i.Add().Icon("a glyphicon glyphicon-sort-by-attributes").HtmlAttributes(New With {.sort_by = "2", .title = "Temporarily sort backlog ascending"})
                                                                                                        i.Add().Text("None").HtmlAttributes(New With {.sort_by = "0", .title = "No backlog sorting"})
                                                                                                        i.Add().Icon("a glyphicon glyphicon-sort-by-attributes-alt").HtmlAttributes(New With {.sort_by = "1", .title = "Temporarily sort backlog descending"})
                                                                                                    End Sub).Events(Sub(e)
                                                                                                                        e.Select("backlogSortByOnSelect")
                                                                                                                    End Sub).Index(1)
                    </div>
                    <div>
                        <div class="checkbox" style="clear: both;">
                            <label>
                                <input type="radio" value="modified" id="radioSortModified" name="sortType" onclick="backlogSortTypeChanged(this);" checked="checked">&nbsp;Modified
                            </label>
                            <label>
                                <input type="radio" value="priority" id="radioSortPriority" name="sortType" onclick="backlogSortTypeChanged(this);">&nbsp;Priority
                            </label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xs-12 text-center">
            </div>
        </div>
    </div>
</div>
<div id="kanBanControl" style="margin-bottom: 40px;">

    @Code

        Dim EditSprintDialog = Html.EJ().Dialog("WeeklyHoursDialog")
        EditSprintDialog.Title("Weekly Hours")
        EditSprintDialog.ShowOnInit(False)
        EditSprintDialog.ContentType("iframe")
        EditSprintDialog.Height("400px")
        EditSprintDialog.Width("800px")
        EditSprintDialog.Render()

        Dim AddWorkItemTimeDialog = Html.EJ().Dialog("AddWorkItemTimeDialog")
        AddWorkItemTimeDialog.Title("Add Time")
        AddWorkItemTimeDialog.ShowOnInit(False)
        AddWorkItemTimeDialog.ContentType("iframe")
        AddWorkItemTimeDialog.Height("400px")
        AddWorkItemTimeDialog.Width("500px")
        AddWorkItemTimeDialog.Render()


        Dim BaseURL = String.Format("{0}://{1}{2}{3}",
                                    Request.Url.Scheme,
                                    Request.Url.Authority,
                                    Url.Content("~"),
                                    Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)

        Dim kanbanbuilder = Html.EJ().Kanban("Kanban")
        kanbanbuilder.DataSource(Sub(d)

                                     d.URL(String.Format("{0}LoadSprintData?SprintID={1}", BaseURL, Model.SprintHeaderID))
                                     d.CrudURL(String.Format("{0}CrudSprintData?SprintID={1}", BaseURL, Model.SprintHeaderID))
                                     d.Adaptor(AdaptorType.UrlAdaptor)

                                 End Sub)
        kanbanbuilder.KeyField("BoardStateID")
        kanbanbuilder.Locale(Me.Locale)
        kanbanbuilder.AllowDragAndDrop(True)
        kanbanbuilder.AllowFiltering(True)
        kanbanbuilder.AllowHover(True)
        kanbanbuilder.AllowKeyboardNavigation(True)
        kanbanbuilder.AllowPrinting(False)
        kanbanbuilder.AllowScrolling(False)
        kanbanbuilder.AllowSelection(False)
        kanbanbuilder.AllowTitle(True)
        kanbanbuilder.AllowToggleColumn(True)
        kanbanbuilder.EnableTouch(True)
        kanbanbuilder.EnableTotalCount(False)
        kanbanbuilder.CssClass("custom-class")
        kanbanbuilder.IsResponsive(True)
        kanbanbuilder.SelectionType(SelectionType.Single)
        kanbanbuilder.ShowColumnWhenEmpty(True)
        kanbanbuilder.ClientSideEvents(
            Sub(events)

                events.Create("kanbanCreate")
                events.CardDrop("cardDrop")
                events.ActionBegin("actionBegin")
                events.ActionComplete("actionComplete")
                events.EndAdd("endAdd")
                events.EndEdit("endEdit")
                events.HeaderClick("headerClick")
                events.CardDrag("cardDrag")
                events.CardDragStart("cardDragStart")
                events.CardDragStop("cardDragStop")
                events.ContextClick("kanbanContextClick")
                events.ContextOpen("kanbanContextOpen")
                events.DataBound("kanbanDataBound")

            End Sub)
        kanbanbuilder.Fields(
        Sub(field)

            field.PrimaryKey("CardQueryID")
            field.Title("Title")
            field.Content("FullName")
            field.Priority("SequenceNumber")

            'If Model.ShowSwimLaneBy <> AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.SwimLaneKey.None Then

            '    field.SwimlaneKey(Model.ShowSwimLaneBy.ToString)

            'End If

        End Sub)
        kanbanbuilder.Columns(
            Sub(col)

                If Model.BoardColumns IsNot Nothing AndAlso Model.BoardColumns.Count > 0 Then

                    For Each Column As AdvantageFramework.Database.Entities.BoardColumn In Model.BoardColumns

                        If Column.Name = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Backlog.ToString OrElse
                           Column.Name = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Completed.ToString Then

                            If Column.Name = AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard.HardCodedColumn.Completed.ToString AndAlso
                                (Model.SprintHeader.IsComplete IsNot Nothing AndAlso Model.SprintHeader.IsComplete = True) Then

                                col.HeaderText(Column.Name).Key(Column.Keys).IsCollapsed(False).AllowDrag(False).AllowDrop(False).Add()

                            Else

                                col.HeaderText(Column.Name).Key(Column.Keys).IsCollapsed(False).Add()

                            End If

                        Else

                            col.HeaderText(String.Format("{1}<span class=""glyphicon glyphicon-plus"" onclick=""addToColumn({0});"" style=""margin-left: 6px;cursor: pointer;"" title=""Add""></span>", Column.ID, Column.Name)).Key(Column.Keys).ShowAddButton(True).Add()

                        End If

                    Next

                End If

            End Sub)
        kanbanbuilder.StackedHeaderRows(
        Sub(rows)

            If Model.StackedColumns IsNot Nothing AndAlso Model.StackedColumns.Count > 0 Then

                rows.StackedHeaderColumns(Sub(Columns)

                                              For Each StackedColumn In Model.StackedColumns

                                                  Columns.HeaderText(StackedColumn.Parent).Column(StackedColumn.Children).Add()

                                              Next

                                          End Sub).Add()
            End If

        End Sub)
        kanbanbuilder.CardSettings(
            Sub(card)

                card.Template("#customCardTemplate")

            End Sub)
        kanbanbuilder.EditSettings(
                Sub(edit)

                    edit.AllowAdding(True)
                    edit.AllowEditing(True)
                    edit.EditMode(KanbanEditMode.DialogTemplate)
                        'edit.DialogTemplate("#editDialog")
                        edit.EditItems(Sub(items)

                                       items.Field("SprintHeaderID").Add()
                                       items.Field("FullName").EditType(KanbanEditingType.Dropdown).Add()

                                   End Sub)

                End Sub)
        kanbanbuilder.ContextMenuSettings(
        Sub(context)

            context.Enable(True).DisableDefaultItems(Sub(dfltItems)

                                                         dfltItems.Add(KanbanContextMenuItem.EditCard)
                                                         dfltItems.Add(KanbanContextMenuItem.DeleteCard)
                                                         dfltItems.Add(KanbanContextMenuItem.PrintCard)
                                                         dfltItems.Add(KanbanContextMenuItem.MoveToSwimlane)

                                                     End Sub)

            context.CustomMenuItems(Sub(customContextMenu)

                                        customContextMenu.Text("Highest").Target(ContextTarget.Card).Add()
                                        customContextMenu.Text("High").Target(ContextTarget.Card).Add()
                                        customContextMenu.Text("Normal").Target(ContextTarget.Card).Add()
                                        customContextMenu.Text("Low").Target(ContextTarget.Card).Add()
                                        customContextMenu.Text("Lowest").Target(ContextTarget.Card).Add()
                                        customContextMenu.Text("View Schedule").Target(ContextTarget.Card).Add()

                                    End Sub)

        End Sub)
        kanbanbuilder.TooltipSettings(
        Sub(tooltip)

            tooltip.Enable(False)
            tooltip.Template("#customToolTip")

        End Sub)
        kanbanbuilder.Render()
    End Code
</div>
<script type="text/javascript">    
    $.views.converters("lastModFormat", function (val) {
        var n = ""
        try {
            if (val) {
                if (val instanceof Date && !isNaN(val.valueOf())) {
                    var d = new Date(val);
                    //n = "<br /><i>Last modified:  " + d.toLocaleString() + "</i>";
                    //n = "<i>Last modified:  " + d.toLocaleString() + "</i>";
                    n = "Last modified:  " + d.toLocaleString();
                }
            }
        } catch (e) {
            n = ""
        }
        return n
    })
    $.views.converters("createdFormat", function (val) {
        var n = ""
        try {
            if (val) {
                if (val instanceof Date && !isNaN(val.valueOf())) {
                    var d = new Date(val);
                    //n = "<br /><i>Created:  " + d.toLocaleString() + "</i>";
                    //n = "<i>Created:  " + d.toLocaleString() + "</i>";
                    n = "Created:  " + d.toLocaleString();
                }
            }
        } catch (e) {
            n = ""
        }
        return n
    })
    $.views.converters("encodeHtml", function (val) {
        var buf = [];
        if (val) {
            for (var i = val.length - 1; i >= 0; i--) {
                buf.unshift(['&#', val[i].charCodeAt(), ';'].join(''));
            }
        }
       
        return buf.join('');;
    })
    $.views.converters("encodeHtml2", function (val) {

        var v = ''
        try {
            if (val) {
                n = val.replace(/"/g, '&quot;');
                n = n.replace(/'/g, '39&apos');
            }
        } catch (e) {
            n = val
        }
        return n;
    })
    $.views.converters("tooltipFormat", function (val) {
        var n = ""
        try {
            if (val) {
                n = val.replace(/"/g, '&quot;');
            }
        } catch (e) {
            n = ""
        }
        return n
    })
</script>
<script>
    var scrollPosition = 0;
    var targetAlertStateDragID = 0;
    var stateList = @Html.Raw(Model.StateList)
    var sprintHeaderId = @Html.Raw(Model.SprintHeaderID) * 1;
    var baseURL = "" + window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)";
    var boardHeaderId = @Html.Raw(Model.BoardHeaderID.GetValueOrDefault(0));
    var sprintId = @Html.Raw(Model.SprintHeaderID.GetValueOrDefault(0));
    var emps = '@Html.Raw(Request.QueryString("emps"))'.split(',');
    var currentBacklogSort = 0; // 0 = none, 1 = modified date desc, 2 = modified date asc, 3 = priority desc, 4 = priority asc;
    var currentBacklogSortType = "modified"; // modified, priority
    var currentBacklogSortSetting = 0;
    var currentBacklogSortTypeSetting = "modified"; // modified, priority
    var filterTimeout;
    var onRefreshCallBack;
    var setExpandCollapseSwimlanes = false;
    var swimExpandCheckbox = $("#swimExpand");
    var expandSwimLanes = swimExpandCheckbox.is(':checked');
    var swimLaneKeyColumn = null;
    var swimLaneCollapsSetting = false;
    var swimLaneSelected = false;
    var addedclick = false;
    var filtercardskey = null;
    var filtercardsonlybacklogkey = false;
    var filteremployeekey = null;
    var filteremployeebacklogkey = false;
    var optionsExpanded = true;
    var kbnCollapseCollec = retrivedCollec = kbnSlCollapseCollec = retrivedSlCollec = [];
    var init = false;

    function toggleOptions() {
        optionsExpanded = !optionsExpanded;
        window.setTimeout(function () {
            setBoardSize();
        }, 100);
    }
    function setBoardSize() { 
        var viewportWidth = $(window).width(); 
        var viewportHeight = $(window).height(); 
        var heightOffset = 270; 
        var widthOffset = 20; 
        if (optionsExpanded === false) {
            heightOffset = heightOffset - 130;
        }
        $("#Kanban").ejKanban({ 
            allowScrolling: true, 
            scrollSettings: { 
                width: viewportWidth - widthOffset, 
                height: viewportHeight - heightOffset 
            } 
        }); 
    } 
    function showProgress() {
        //kendo.ui.progress($("#kanBanControl"), true);
        //kendo.ui.progress($("body"), true);
    }
    function hideProgress() {
        //kendo.ui.progress($("#kanBanControl"), false);
        //kendo.ui.progress($("body"), false);
    }
    function menuAction(action, alertID, jobnumber, jobcomponentnumber, employeecode) {
        //console.log(model.EmployeeCode);
        if (action == 0) {            
            OpenRadWindow('Alert', 'Alert_New.aspx?caller=jobtemplate&f=1&jt=1&j=' + jobnumber + '&jc=' + jobcomponentnumber, 0, 1000);
        }
        if (action == 1) {
            OpenRadWindow('Assignment', 'Desktop_NewAssignment?caller=jobtemplate&f=1&jt=1&assn=1&j=' + jobnumber + '&jc=' + jobcomponentnumber, 0, 1250);
        }
        if (action == 3) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('New Job', 'JobTemplate_New.aspx?j=' + jobnumber + '&jc=' + jobcomponentnumber, 0, 1200);
            }
        }
        if (action == 4) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('Job', 'Content.aspx?PageMode=Edit&NewComp=0&contaid=10&j=' + jobnumber + '&jc=' + jobcomponentnumber + '&f=2');
            }            
        }

        if (action == 6) {

            var data = {
                EmployeeCode: employeecode
            };
            $.post({
                url: window.appBase + "Desktop/Alert/HasStopwatch",
                dataType: "json",
                data: data
            }).always(function (result) {
                if (result) {
                    //console.log("stopwatch result", result);
                    if (result.StopwatchIsRunning == true) {
                        var ec = result.EmployeeCode;
                        showKendoConfirm("There is a stopwatch already running.\nStop it and start a new stopwatch?")
                            .done(function () {
                                var data2 = {
                                    EmployeeCode: result.EmployeeCode
                                };
                                $.post({
                                    url: window.appBase + "Employee/Timesheet/StopStopwatch",
                                    dataType: "json",
                                    data: data2
                                }).always(function (result) {
                                    if (result) {
                                        //console.log("stop?", ec);
                                        _startStopwatch(ec, jobnumber, jobcomponentnumber, alertID);
                                    }
                                });
                            })
                            .fail(function () {
                                return false;
                            });
                    } else {
                        _startStopwatch(result.EmployeeCode, jobnumber, jobcomponentnumber, alertID);
                    }
                }
            });      
            
        }

        //if (action == 6) {
        //    var data = {
        //        EmployeeCode: employeecode
        //    };
        //    $.post({
        //        url: window.appBase + "Employee/Timesheet/HasStopwatch",
        //        dataType: "json",
        //        data: data
        //    }).always(function (result) {
        //        if (result) {
        //            //console.log("stopwatch result", result);
        //            if (result.StopwatchIsRunning == true) {
                        //showKendoConfirm("There is a stopwatch already running.\nStop it and start a new stopwatch?")
                        //    .done(function () {
                        //        $.post({
                        //            url: window.appBase + "Employee/Timesheet/StopStopwatch",
                        //            dataType: "json",
                        //            data: data
                        //        }).always(function (result) {
                        //            if (result) {
                        //                //console.log("stop?", result);
                        //                _startStopwatch();
                        //            }
                        //        });
                        //    })
                        //    .fail(function () {
                        //        return false;
                        //    });
        //            } else {
        //                _startStopwatch(employeecode, jobnumber, jobcomponentnumber, alertID);
        //            }
        //        }
        //    });
        //}

        if (action == 7) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=1&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            } else {

                var width = 780;
                var height = 800;
                var left = 150;
                var top = 150;
                var params = 'width=' + width + ', height=' + height;
                params += ', top=' + top + ', left=' + left;
                params += ', directories=no';
                params += ', location=no';
                params += ', menubar=no';
                params += ', resizable=yes';
                params += ', scrollbars=auto';
                params += ', status=no';
                params += ', toolbar=no';
                let newwin = window.open('Alert_Html.aspx?a=' + alertID, 'PopLookup', params);

                setTimeout(function () {
                    newwin.focus();
                }, 1);
            }
        }
        if (action == 8) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=2&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        if (action == 9) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=5&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        if (action == 10) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('Email', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=3&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        if (action == 11) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'JobTemplate_Print.aspx?fromapp=jobtemplate&mode=4&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }

        //Alerts
        if (action == 12) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=1&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Documents
        if (action == 13) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=3&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Creative Brief
        if (action == 14) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=2&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Job Specs
        if (action == 15) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=7&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Job Version
        if (action == 16) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=11&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Estimate
        if (action == 17) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {

                //if (this.estimatenumber > 0) {
                //    OpenRadWindow('', 'Content.aspx?contaid=4&JT=0&newEst=edit&j=' + jobnumber + '&jc=' + jobcomponentnumber + '&e=' + this.estimatenumber + '&ec=' + this.estimatecomponentnumber);
                //} else {
                    OpenRadWindow('', 'Content.aspx?contaid=4&JT=0&newEst=job&j=' + jobnumber + '&jc=' + jobcomponentnumber);
                //}


            }
        }
        //Schedule
        if (action == 18) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=15&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Boards
        if (action == 19) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=25&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //QVA
        if (action == 20) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=13&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Purchase Orders
        if (action == 21) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=12&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Snapshot
        if (action == 22) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'TrafficSchedule_ProjectSummary.aspx?j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }
        //Proofs
        if (action == 23) {
            if (jobnumber > 0 && jobcomponentnumber > 0) {
                OpenRadWindow('', 'Content.aspx?contaid=24&j=' + jobnumber + '&jc=' + jobcomponentnumber);
            }
        }

    }
    function addToColumn(boardColumnId) {
        var stateId = 0;
        var colData = {
            BoardHeaderID: boardHeaderId,
            BoardColumnID: boardColumnId
        };
        showProgress();
        $.post({
            url: window.appBase + "ProjectManagement/Agile/GetStateIDFromColumn",
            dataType: "json",
            data: colData
        }).always(function (result) {
            stateId = result.Data * 1;
            hideProgress();
            addCard(stateId, 0, 0, "");
        });
    }
    function wtfScrollTop() {
        setTimeout(function () {
            $('html,body').animate({ scrollTop: 0 }, 'fast');
        }, 500)
    }
    function expandSwim() {
        if (setExpandCollapseSwimlanes == true) {
            //console.log("function expandSwim():  " + expandSwimLanes)
            expandSwimLanes = swimExpandCheckbox.is(':checked');
            var kanbanObj = $("#Kanban").ejKanban("instance");
            //var kanbanData = $('#Kanban').data('ejKanban');
            //kanbanData.refresh(true);
            if (kanbanObj && kanbanObj.KanbanSwimlane) {
                if (expandSwimLanes === true) {
                    kanbanObj.KanbanSwimlane.collapseAll();
                    //kanbanObj.KanbanSwimlane.expandAll();
                } else {
                    kanbanObj.KanbanSwimlane.expandAll();
                    //kanbanObj.KanbanSwimlane.collapseAll();
                }
                //wtfScrollTop();
            }
        }
    }
    function swimByOnSelect(e) {
        if ($('#Kanban').data('ejKanban')) {
            var scrollPos = $('html,body').scrollTop();
            onRefreshCallBack = function () {
                $('html,body').scrollTop(scrollPos);
            }
            var val = $('#SwimBy > .k-state-active').attr('swim-by');
            if (val != "None") {
                setExpandCollapseSwimlanes = true;
                swimLaneKeyColumn = val;
            } else {
                setExpandCollapseSwimlanes = false;
                swimLaneKeyColumn = null;
            }
            setSwimExpandCheckboxDisabled();
            var classes = document.getElementById('Kanban').className.split(/\s+/);
            for (var i = 0; i < classes.length; i++) {
                if (classes[i].startsWith('by-')) {
                    $('#Kanban').removeClass(classes[i]);
                }
            }
            if (swimLaneKeyColumn) {
                $('#Kanban').addClass('by-' + swimLaneKeyColumn);
            }
            //$("#Kanban").ejKanban(
            //    {
            //        fields: {
            //            swimlaneKey: swimLaneKeyColumn
            //        }
            //    });
            $("#Kanban").ejKanban("option", { "fields": { swimlaneKey: swimLaneKeyColumn } });

            saveSwimLaneBySetting();

            var oldRefreshCallBack = function () { };

            if (onRefreshCallBack) {
                oldRefreshCallBack = onRefreshCallBack;
            }
            onRefreshCallBack = function () {
                oldRefreshCallBack();
                expandSwim();
            }
        }
    }
    function swimLaneRadioChecked(e) {
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
        }
        if (e.value != "None") {
            setExpandCollapseSwimlanes = true;
            swimLaneKeyColumn = e.value;
        } else {
            setExpandCollapseSwimlanes = false;
            swimLaneKeyColumn = null;
        }
        setSwimExpandCheckboxDisabled();
        var classes = document.getElementById('Kanban').className.split(/\s+/);
        for (var i = 0; i < classes.length; i++) {
            if (classes[i].startsWith('by-')) {
                $('#Kanban').removeClass(classes[i]);
            }
        }
        if (swimLaneKeyColumn) {
            $('#Kanban').addClass('by-' + swimLaneKeyColumn);
        }
        //$("#Kanban").ejKanban(
        //    {
        //        fields: {
        //            swimlaneKey: swimLaneKeyColumn
        //        }
        //    });
        $("#Kanban").ejKanban("option", { "fields": { swimlaneKey: swimLaneKeyColumn } });
        expandSwim();
    }
    function setSwimExpandCheckboxDisabled() {
        if (setExpandCollapseSwimlanes == false) {
            swimExpandCheckbox.attr("disabled", true);
        } else {
            swimExpandCheckbox.removeAttr("disabled");
        }
    }
    function swimExpandCheckboxChanged() {
        expandSwimLanes = swimExpandCheckbox.is(':checked');
        setExpandCollapseSwimlanes = true;
        //console.log("swimExpandCheckboxChanged, expandSwimLanes: " + expandSwimLanes)
        //console.log("swimExpandCheckboxChanged, setExpandCollapseSwimlanes: " + setExpandCollapseSwimlanes)
        expandSwim();
        saveSwimLaneCollapseOption();
    }
    function saveSwimLaneCollapseOption() {
        //expandSwimLanes = swimExpandCheckbox.is(':checked');
        //var data = {
        //    Collapse: expandSwimLanes
        //};
        ////console.log("saveSwimLaneCollapseOption", expandSwimLanes);
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveSwimLaneCollapseSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveSwimLaneBySetting() {
        //var settingValue = "None";
        //if (swimLaneKeyColumn) {
        //    settingValue = swimLaneKeyColumn;
        //}
        //var data = {
        //    SettingValue: settingValue
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveSwimLaneBySetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilter() {
        //var settingValue = "";
        //if (filtercardskey) {
        //    settingValue = filtercardskey;
        //}
        //var data = {
        //    SettingValue: settingValue
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterCardSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilterOnlyBacklog() {
        
        //var data = {
        //    Backlog: filtercardsonlybacklogkey
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterOnlyBacklogSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilterEmployee() {
        //var settingValue = "";
        //var selectedData = [];       
        
        //if (filteremployeekey) {
        //    settingValue = filteremployeekey.join(",");
        //}
        //var data = {
        //    SettingValue: settingValue
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterEmployeeSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilterEmployeeBacklog() {
        //var data = {
        //    Backlog: filteremployeebacklogkey
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterEmployeeBacklogSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilterBacklogSort() {
        //var settingValue = 0;
        //if (currentBacklogSort) {
        //    settingValue = currentBacklogSort;
        //}
        //var data = {
        //    SettingValue: settingValue
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterBacklogSort",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function saveFilterBacklogSortType() {
        //var data = {
        //    SettingValue: currentBacklogSortType
        //};
        //$.post({
        //    url: window.appBase + "ProjectManagement/Agile/SaveFilterBacklogSortTypeSetting",
        //    dataType: "json",
        //    data: data
        //}).always(function (response) {
        //    if (response) {
        //        //console.log("saveSwimLaneBySetting", response)
        //    }
        //});
    }
    function sortBacklog() {
        var isFiltered = false;
        //console.log("sortBacklog", currentBacklogSort);
        if (currentBacklogSort && currentBacklogSort > 0) {
            if (currentBacklogSortType === "priority") {
                currentBacklogSort = currentBacklogSort + 2;
            }
            isFiltered = true
            applyFilterCards();
        }
    }
    function kanbanDataBound() {
        window.setTimeout(function () {
            setBoardSize();
        }, 10);

    }
    function setSavedSwimlaneOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetSwimLaneCollapseSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                swimLaneCollapsSetting = response;
            }
            swimExpandCheckbox.prop("checked", swimLaneCollapsSetting);
            $.get({
                url: window.appBase + "ProjectManagement/Agile/GetSwimLaneBySetting",
                dataType: "json"
            }).always(function (response) {
                if (response) {
                    if (response == "None") {
                        swimLaneKeyColumn = null;
                    } else {
                        swimLaneKeyColumn = response;
                    }
                } else {
                    swimLaneKeyColumn = null;
                }
                if (swimLaneKeyColumn) {
                    var buttongroup = $("#SwimBy").kendoButtonGroup().data("kendoButtonGroup");
                    if (swimLaneKeyColumn == "ClientName") {
                        buttongroup.select(0);
                        swimLaneSelected = true;
                    }
                    if (swimLaneKeyColumn == "JobName") {
                        buttongroup.select(2);
                        swimLaneSelected = true;
                    }
                    if (swimLaneSelected === true) {
                        swimExpandCheckbox.removeAttr("disabled");
                    } else {
                        swimExpandCheckbox.attr("disabled", true);
                    }
                    if (swimLaneSelected === true && swimLaneCollapsSetting === true) {
                        setTimeout(function () {
                            var kanbanObj = $("#Kanban").ejKanban("instance");
                            if (kanbanObj && kanbanObj.KanbanSwimlane) {
                                kanbanObj.KanbanSwimlane.collapseAll();
                                //console.log("collapsed set");
                            }
                        }, 500);
                    }
                } else {
                    if (swimLaneSelected === true) {
                        swimExpandCheckbox.removeAttr("disabled");
                    } else {
                        swimExpandCheckbox.attr("disabled", true);
                    }
                }
                });
            });
    }
    function setFilterOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetFilterCardSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                filtercardskey = response;
            }
            var input = $('#filterInput');
            $("#filterInput").val(filtercardskey);
            
        });
    }
    function setFilterOnlyBacklogOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetFilterOnlyBacklogSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                filtercardsonlybacklogkey = response;
            }
            $('#CheckboxFilterOnlyBacklog').ejCheckBox({ checked: filtercardsonlybacklogkey });
            
            
        });
    }
    function setFilterEmployeeOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetFilterEmployeeSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                filteremployeekey = response;
                var employees = filteremployeekey.split(",");
                $('#FilterEmployees').data('kendoMultiSelect').value(employees);
            }
        });
    }
    function setFilterEmployeeBacklogOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetFilterEmployeeBacklogSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                filteremployeebacklogkey = response;
            }
            $('#CheckboxFilterBacklogByEmployee').ejCheckBox({ checked: filteremployeebacklogkey });


        });
    }
    function setFilterBacklogSortOptionsType() {       
            $.get({
                url: window.appBase + "ProjectManagement/Agile/GetFilterBacklogSortTypeSetting",
                dataType: "json"
            }).always(function (response) {
                if (response) {
                    currentBacklogSortTypeSetting = response;
                }
                currentBacklogSortType = currentBacklogSortTypeSetting;

                if (currentBacklogSortTypeSetting == 'priority') {
                    $("#radioSortPriority").prop("checked", true);
                } else if (currentBacklogSortTypeSetting == 'modified') {
                    $("#radioSortModified").prop("checked", true);
                } else {
                    $("#radioSortModified").prop("checked", true);
                }

                sortBacklog();

            });
    }
    function setFilterBacklogSortOptions() {
        $.get({
            url: window.appBase + "ProjectManagement/Agile/GetFilterBacklogSortSetting",
            dataType: "json"
        }).always(function (response) {
            if (response) {
                currentBacklogSortSetting = response;
            }            
            var buttongroup = $("#BacklogSortBy").kendoButtonGroup().data("kendoButtonGroup");

            if (currentBacklogSortSetting == "0") {
                buttongroup.select(1);
                currentBacklogSort = 0;
            } else if (currentBacklogSortSetting == "1") {
                buttongroup.select(2);
                currentBacklogSort = 1;
            } else if (currentBacklogSortSetting == "2") {
                buttongroup.select(0);
                currentBacklogSort = 2;
            } else {
                buttongroup.select(1);
                currentBacklogSort = 0;
            }

            sortBacklog();
        });
    }  
    function filterByText() {
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
            setTimeout(function () {
                var input = $('#filterInput');
                input.focus();
            });
        }
        filterCards();
        filtercardskey = $("#filterInput").val();
        //saveFilter();
    }
    function filterByBacklog() {
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
            setTimeout(function () {
                var input = $('#CheckboxFilterOnlyBacklog');
                input.focus();
            });
        }
        filterCards();
        filtercardsonlybacklogkey = $("#CheckboxFilterOnlyBacklog").ejCheckBox("instance").option("checked");
        //saveFilterOnlyBacklog();
    }
    function filterByBacklogByEmployee() {
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
            setTimeout(function () {
                var input = $('#CheckboxFilterBacklogByEmployee');
                input.focus();
            });
        }
        filterCards();
        filteremployeebacklogkey = $("#CheckboxFilterBacklogByEmployee").ejCheckBox("instance").option("checked");
        //saveFilterEmployeeBacklog();
    }
    function filterEmployees() {
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
            setTimeout(function () {
                var empInput = $('#FilterEmployees').data('kendoMultiSelect');
                empInput.focus();
            });
        }
        filterCards();
        filteremployeekey = $('#FilterEmployees').data('kendoMultiSelect').value();
        //saveFilterEmployee();
    }
    function filterCards() {
        console.log("filterCards");
        if (filterTimeout) {
            clearTimeout(filterTimeout);
        }
        filterTimeout = setTimeout(function () {
            applyFilterCards();
        }, 500);
    }
    var refreshNeeded = false;
    var lastSearchText = "";
    var lastOnlyBacklog = false;
    var lastEmployees;
    var lastBacklogSort = false;
    var lastEmployeeBacklog = "";
    function applyFilterCards() {
        var search = $("#filterInput").val();
        var onlyBacklog = $("#CheckboxFilterOnlyBacklog").ejCheckBox("instance").option("checked");
        var employeeBacklog = $("#CheckboxFilterBacklogByEmployee").ejCheckBox("instance").option("checked");
        var empInput = $('#FilterEmployees').data('kendoMultiSelect');
        var emps = empInput.value();
        var kanban = $('#Kanban').data('ejKanban');
        var hasSearchText = false,
            hasOnlyBacklog = false,
            hasEmployees = false,
            hasBacklogSort = false,
            hasEmployeeBacklog = false;  
        if (search != lastSearchText) {
            if (kanban.model.query._params) {
                for (var i = 0; i < kanban.model.query._params.length; i++) {
                    if (kanban.model.query._params[i].key === "SearchText") {
                        hasSearchText = true;
                        kanban.model.query._params[i].value = search;
                    }
                }
            }
            if (hasSearchText == false) {
                kanban.model.query.addParams("SearchText", search);
                hasSearchText = true;
            }
            lastSearchText = search;
            refreshNeeded = true;
        }
        if (onlyBacklog != lastOnlyBacklog) {
            if (kanban.model.query._params) {
                for (var i = 0; i < kanban.model.query._params.length; i++) {
                    if (kanban.model.query._params[i].key === "OnlyBacklog") {
                        hasOnlyBacklog = onlyBacklog;
                        kanban.model.query._params[i].value = onlyBacklog;
                    }
                }
            }
            if (hasOnlyBacklog == false) {
                kanban.model.query.addParams("OnlyBacklog", onlyBacklog);
                hasOnlyBacklog = true;
            }
            lastOnlyBacklog = onlyBacklog;
            refreshNeeded = true;
        }
        if (emps != lastEmployees) {
            if (kanban.model.query._params) {
                for (var i = 0; i < kanban.model.query._params.length; i++) {
                    if (kanban.model.query._params[i].key === "Employees") {
                        hasEmployees = true;
                        kanban.model.query._params[i].value = emps;
                    }
                }
            }
            if (hasEmployees == false) {
                kanban.model.query.addParams("Employees", emps);
                hasEmployees;
            }
            lastEmployees = emps;
            refreshNeeded = true;
        }
        if (currentBacklogSort != lastBacklogSort) {
            if (kanban.model.query._params) {
                for (var i = 0; i < kanban.model.query._params.length; i++) {
                    if (kanban.model.query._params[i].key === "SortBacklog") {
                        hasBacklogSort = currentBacklogSort;
                        kanban.model.query._params[i].value = currentBacklogSort;
                    }
                }
            }
            if (hasBacklogSort == false) {
                kanban.model.query.addParams("SortBacklog", currentBacklogSort);
                hasBacklogSort = true;
            }
            lastBacklogSort = currentBacklogSort;
            refreshNeeded = true;
        }
        if (employeeBacklog != lastEmployeeBacklog) {
            if (kanban.model.query._params) {
                for (var i = 0; i < kanban.model.query._params.length; i++) {
                    if (kanban.model.query._params[i].key === "EmployeeBacklog") {
                        hasEmployeeBacklog = employeeBacklog;
                        kanban.model.query._params[i].value = employeeBacklog;
                    }
                }
            }
            if (hasEmployeeBacklog == false) {
                kanban.model.query.addParams("EmployeeBacklog", employeeBacklog);
                hasEmployeeBacklog = true;
            }
            lastEmployeeBacklog = employeeBacklog;
            refreshNeeded = true;
        }
        //console.log(kanban.model.query._params); 
        if (refreshNeeded == true) {
            kanban.refresh(true);
            refreshNeeded = false;
            var scrollPos = $('html,body').scrollTop();
            onRefreshCallBack = function () {
                $('html,body').scrollTop(scrollPos);
            }
        }
    }
    function getStateName(alertStateId){
        for (var i = 0; i < stateList.length; i++) {
            if (stateList[i].AlertStateID == alertStateId) {
                return stateList[i].Name;
            }
        }
    }
    function openWeeklyHoursDialog(alertId, title) {
        var URL = "";
        var thisTitle = "Hours"
        //if (title) {
        //    thisTitle = thisTitle + " for " + decodeURI(title);
        //    //thisTitle = title;
        //}
        URL = baseURL + "HoursByAlertID/" + sprintId + "/" + alertId;
        ////$("#WeeklyHoursDialog").ejDialog("destroy");
        ////$("#WeeklyHoursDialog").ejDialog({
        ////    contentUrl: URL,
        ////    title: thisTitle + "",
        ////    showOnInit: false,
        ////    contentType: "iframe",
        ////    height: "400px",
        ////    width: "800px"
        ////});
        ////$("#WeeklyHoursDialog").ejDialog("open");
        ////$("#WeeklyHoursDialog").ejDialog("refresh");
        OpenRadWindow(thisTitle, URL, 700, 1000, true);

    }
    function openChecklistsDialog(alertId) {
        showKendoAlert('Placeholder for the "show checklists on cards" setting');
    }
    function openAddWorkItemTimeDialog(alertId, jobNumber, jobComponentNumber, taskSequenceNumber) {
        if (jobNumber && jobComponentNumber && jobNumber > 0 && jobComponentNumber > 0) {
            var URL = "";
            var s = -1;
            if (taskSequenceNumber && isNaN(taskSequenceNumber) == false && taskSequenceNumber > -1) {
                s = taskSequenceNumber;
            }
            $.get({
                url: window.appBase + "Desktop/Alert/CanAddTimeToJob?JobComponentNumber=" + jobComponentNumber + "&JobNumber=" + jobNumber,
                dataType: "json"
            }).always(function (result) {
                if (result) {
                    if (result.Success && result.Success == true) {
                        openAddTimeWindow(alertId, jobNumber, jobComponentNumber, taskSequenceNumber);
                    } else {
                        if (result.Message && result.Message != "") {
                            showKendoAlert(result.Message);
                        } else {
                            showKendoAlert('Adding time is not allowed.');
                        }
                    }
                }
            });
        } else {
            openAddTimeWindow(alertId, 0, 0, -1);
        }
    }
    function openAddTimeWindow(alertId, jobNumber, jobComponentNumber, taskSequenceNumber) {
        var URL = "";
        var thisTitle = "Add Time"
        var s = -1;
        if (taskSequenceNumber && isNaN(taskSequenceNumber) == false && taskSequenceNumber > -1) {
            s = taskSequenceNumber;
        }
        //URL = window.appBase + 'ProjectManagement_Agile_NewWorkItemTimeDialog?AlertID=' + alertId;
        URL = window.appBase + 'Employee/Timesheet/Entry?a=' + alertId + "&j=" + jobNumber + "&jc=" + jobComponentNumber + "&s=" + taskSequenceNumber;
        $("#AddWorkItemTimeDialog").ejDialog("destroy");
        $("#AddWorkItemTimeDialog").ejDialog({
            contentUrl: URL,
            title: thisTitle + "",
            showOnInit: false,
            contentType: "iframe",
            height: "600px",
            width: "600px",
            showFooter: false,
            footerTemplateId: 'newWorkItemHoursFooter',
            enableModal: true,
            enableResize: false
        });
        $("#workItemTimeSave").kendoButton({
            click: function () {
                saveAddWorkItemTimeDialog();
            }
        });
        $("#workItemTimeCancel").kendoButton({
            click: function () {
                closeAddWorkItemTimeDialog();
            }
        });
        $("#AddWorkItemTimeDialog").ejDialog("open");
        $("#AddWorkItemTimeDialog").ejDialog("refresh");
    }
    function disableWorkItemTimeSaveButton(disable) {
        if (disable == true) {
            $("#workItemTimeSave").data("kendoButton").enable(false);
        } else {
            $("#workItemTimeSave").data("kendoButton").enable(true);
        }
    }
    function saveAddWorkItemTimeDialog() {
        var content = $('#AddWorkItemTimeDialog').find('iframe')[0].contentWindow;
        if (content && content.MvcSaveBridge) {
            var result = content.MvcSaveBridge();
            if (typeof result === 'boolean') {
                if (result === true) {
                    closeAddWorkItemTimeDialog();
                }
            } else {
                result.then(function (response) {
                    if (response.content.Success === true) {
                        closeAddWorkItemTimeDialog();
                    } else if (response.content.Message) {
                        showKendoAlert(resonse.content.Message);
                    }
                });
            }
        }
    }
    function closeAddWorkItemTimeDialog() {
        $("#AddWorkItemTimeDialog").ejDialog("close");
    }
    function closeDialogs() {
        $("#AddWorkItemTimeDialog").ejDialog("close");
    }
    function kanbanCreate(args) {
        hideCollapsedCounter();
        ////filterCards();

        //console.log("kanbanCreate", args);
        //setSavedSwimlaneOptions();
        //setFilterBacklogSortOptionsType();
        //setFilterBacklogSortOptions();
        //setFilterOptions();
        //setFilterOnlyBacklogOptions();
        //setFilterEmployeeBacklogOptions();
        //setFilterEmployeeOptions();
        //if (emps) {
        //    var empInput = $('#FilterEmployees').data('kendoMultiSelect');
        //    empInput.value(emps);
        //}
        ///****/
        //var kbnObj = $('#Kanban').data('ejKanban')
        //retrivedCollec = JSON.parse(sessionStorage.getItem("kbnCollapseCollec"));
        //if (!retrivedCollec) return;
        //for (var i = 0; i < retrivedCollec.length; i++) { }
        //kbnObj.toggleColumn(retrivedCollec[i]);
        //retrivedSlCollec = JSON.parse(sessionStorage.getItem("kbnSlCollapseCollec"));
        //if (!retrivedSlCollec) return;
        //for (var i = 0; i < retrivedSlCollec.length; i++)
        //    kbnObj.KanbanSwimlane.toggle($(".e-slexpandcollapse").eq(retrivedSlCollec[i]));
        ///****/

        ////this.element.ejWaitingPopup({
        ////    cssClass: "rwLoading"
        ////});
        //collapseBacklog();
    }
    function collapseBacklog() {
        window.setTimeout(function () {
            var kanbanObj = $("#Kanban").data("ejKanban"); 
            if (kanbanObj) {
                try {
                    //console.log("collapsing");
                    kanbanObj.toggleColumn("Backlog"); 
                    kanbanObj.toggleColumn("Completed"); 
                } catch (e) {
                    console.log("collapse error", e);
                }
            }
        }, 250);
        //var columns = obj.model.columns; 
        ////console.log("columns", columns);
        //if (columns) {
        //    for (var i = 0; i < columns.length; i++) { 
        //        if (columns[i].headerText == "Backlog" || columns[i].headerText == "Completed") {
        //            var key = $(obj.element.find(".e-columnrow")).find('td[data-ej-mappingkey="' + columns[i].key + '"]');
        //            if (key) {
        //                //console.log("key", key);
        //                var divv = key.find(".e-shrinklabel");
        //                if (divv) {
        //                    //console.log(divv);
        //                    key.find(".e-shrinklabel").addClass("e-hide");
        //                }
        //                //console.log(key.find(".e-shrinklabel").addClass("e-hide"));
        //            }
        //            //console.log(obj.getHeaderTable().find(".e-headercell").eq(i));
        //            //if (obj.getHeaderTable().find(".e-headercell").eq(i).hasClass("e-shrinkcol")) {
        //            //    console.log("header loop")
        //            //}
        //        }
        //        /*
		      //  if (obj.getHeaderTable().find(".e-headercell").eq(i).hasClass("e-shrinkcol")) { 
        //            var key = $(obj.element.find(".e-columnrow")).find('td[data-ej-mappingkey="' + columns[i].key + '"]'); 
        //            console.log(key);
        //            for (var j = 0; j < key.length; j++) { 
        //                console.log("key", key);
				    //    key.eq(j).find(".e-shrinklabel").addClass("e-hide") 
			     //   } 
		      //  } 
        //        */
	       // } 
        //}
    }
    function kanbanContextOpen(args) {
        $('#Kanban_Context > li').each(function () {
            var li = $(this);
            var txt = li.find('a.e-menulink').text();
            if (txt.indexOf("Move to Swim") > -1) {
                li.hide();
            }
        });
        if (args.cardData) {
            var priority = 'Normal';
            if (args.cardData.Priority === 1) {
                priority = 'Highest';
            } else if (args.cardData.Priority === 2) {
                priority = 'High';
            } else if (args.cardData.Priority === 3) {
                priority = 'Normal';
            } else if (args.cardData.Priority === 4) {
                priority = 'Low';
            } else if (args.cardData.Priority === 5) {
                priority = 'Lowest';
            }
            $('#Kanban_Context > li').each(function () {
                var li = $(this);
                var txt = li.find('a.e-menulink').text();
                li.removeClass('priority-selected');
                if (li.find('a.e-menulink').text() === priority) {
                    li.addClass('priority-selected');
                }
            });
        }
    }
    function kanbanContextClick(args) {
        var priority;
        if (args.cardData) {
            if (args.text === 'Highest') {
                priority = 1;
            } else if (args.text === 'High') {
                priority = 2;
            } else if (args.text === 'Normal') {
                priority = 3;
            } else if (args.text === 'Low') {
                priority = 4;
            } else if (args.text === 'Lowest') {
                priority = 5;
            } else if (args.text === 'View Schedule') {
                OpenRadWindow("", "Content.aspx?contaid=15&j=" + args.cardData.JobNumber + "&jc=" + args.cardData.JobComponentNumber)
            }
            if (priority) {
                showProgress();
                var cardData = {
                    AlertID: args.cardData.AlertID,
                    Priority: priority
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/UpdateCardPriority",
                    dataType: "json",
                    data: cardData
                }).always(function(response) {
                    if (response === true) {
                        args.cardData.Priority = priority;
                        var card = $(args.card).find('.wv-card').removeClass(function (index, className) {
                            return (className.match(/(^|\s)priority-\S+/g) || []).join(' ');
                        }).addClass('priority-' + priority);
                    }
                    hideProgress();
                });
            }
        }
    }
    function headerClick(args) {
        //console.log("headerClick", args);
        hideCollapsedCounter();
    }
    function hideCollapsedCounter() {
        var obj = $("#Kanban").data("ejKanban");
        var columns = obj.model.columns;
        for (var i=0; i< columns.length; i++){
            if (obj.getHeaderTable().find(".e-headercell").eq(i).hasClass("e-shrinkcol")) {
                try {
                    var key = $(obj.element.find(".e-columnrow")).find('td[data-ej-mappingkey="'+columns[i].key+'"]');
                    for(var j=0;j< key.length; j++){
                        key.eq(j).find(".e-shrinklabel").css("display", "none")
                    }
                } catch (e) {
                   //console.log(columns[i].key);
                }
            }
        }
    }
    function endAdd(args) {
        //console.log(args)
    }
    function endEdit(args) {
        //console.log(args)
    }
    function shortDate(val) {
        var d = new Date(val);
        var n = d.toLocaleDateString();
        return n
    }
    function actionBegin(args) {
        if (args) {
            if (args.requestType) {
                //console.log("actionBegin!!!", args.requestType);
                showProgress();
                //console.log("actionBegin requestType: ", args)
                //console.log(args.data)
                if (args.requestType === "add") {
                    args.cancel = true;
                    var boardState = -1;
                    var jobNum, jobCompNum, jobData;
                    var clientCode = "";
                    if (args.data.BoardStateID) {
                        boardState = args.data.BoardStateID[0];
                    }
                    if (args.model.fields.swimlaneKey === 'JobName' && args.data.JobName) {
                        jobData = args.data.JobName.split(" - ")[0].split("/");
                        if (jobData.length === 2) {
                            jobNum = parseInt(jobData[0]);
                            jobCompNum = parseInt(jobData[1]);
                            addCard(boardState, jobNum, jobCompNum, clientCode);
                        }
                    } else if (args.model.fields.swimlaneKey == "ClientName" && args.data.ClientName) {
                        var clientData = {
                            ClientName: args.data.ClientName
                        };
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/GetClientCodeFromName",
                            dataType: "json",
                            data: clientData
                        }).always(function (result) {
                            clientCode = result.Data
                            addCard(boardState, jobNum, jobCompNum, clientCode);
                        });
                    } else if (addedclick == false) {
                        addedclick = true;
                        addCard(boardState, jobNum, jobCompNum, clientCode);
                    } else {
                        addedclick = false;
                    }
                } else if (args.requestType === "beginedit") {
                    args.cancel = true;
                    viewCardDetails(args.data.AlertID, args.data.Title);
                } else if (args.requestType === "refresh") {
                    addedclick = false;
                }
            } else {
                args.cancel = true;
            }
        }
    }
    function actionComplete(args) {
        hideProgress();
        if (args) {
            //console.log("actionComplete!!!", args.requestType);
            if (args.requestType) {
                var obj = $("#Kanban").data("ejKanban");
                //console.log("actionComplete!!!", args.requestType);
                if (args.requestType == "refresh") {
                    //console.log("actionComplete:refresh");
                    if (init == true) {
                        if (onRefreshCallBack) {
                            onRefreshCallBack();
                            onRefreshCallBack = null;
                        }
                    } else {
                        init = true;
                        collapseBacklog();
                    }
                    args.cancel = true;
                    //hideProgress();
                    //return false
                }
                //for (var i = 0; i < args.model.columns.length; i++) {
                //    var key = args.model.columns[i].key;
                //    //if (key[0] == "-1" || key[0] == "-2" || key[0] == "-3") {
                //        //obj.getContentTable().find(".e-columnrow td[ej-mappingkey=" + key + "]").addClass("eCustom" + key);
                //        //obj.getHeaderTable().find(".e-headerdiv").eq(i).addClass("eCustomHeader" + key);
                //    //}
                //}
                //console.log(args.requestType);
                //if (args.model.editSettings.editMode == "dialogtemplate"){
                //    if (args.requestType == "save") {
                //        var data = {
                //            SprintHeaderID: $("#SprintHeaderID").val(),
                //            BoardColumnID: $("#BoardColumnID").val(),
                //            TaskCode: args.data[0].addCode,
                //            TaskDescription: args.data[0].Title,
                //            EmployeeCode: args.data[0].addEmployee,
                //            Priority: args.data[0].addPriority,
                //            StartDate: shortDate(args.data[0].addStart),
                //            DueDate: shortDate(args.data[0].addDue),
                //            Week1: args.data[0].addWeek1,
                //            Week2: args.data[0].addWeek2
                //        };
                //    }
                //    if (args.requestType == "beginedit") {
                //        $("#hoursIframe").show();
                //        $("#addTable").hide();
                //        var hoursURL = "";
                //        hoursURL = baseURL + "HoursByAlertID/" + args.data.SprintHeaderID + "/" + args.data.AlertID;
                //        $("#hoursIframe").attr("src", hoursURL)
                //    }
                //    if (args.requestType == "add") {
                //        $("#hoursIframe").hide();
                //        $("#addTable").show();
                //    }
                //}
            } else {
                args.cancel = true;
            }
        }
        hideProgress();
    }
    function cardDrag(e) {
        /*  Keep states in view */
        if ($(e.dragTarget).hasClass('e-columnkey') || $(e.dragTarget).hasClass('e-rowcell')) {
            var target;
            $(e.dragTarget).hasClass('e-columnkey') ? target = $(e.dragTarget) : target = $(e.dragTarget).find('.e-columnkey');
            if (target.hasClass('e-columnkey')) {
                var scrollTop, height, scrollEle;
                var multiKeyDiv = target.parent();
                multiKeyDiv.css('vertical-align', 'top');
                if (this.model.allowScrolling && this.kanbanContent.hasClass('e-scroller')) {
                    var scrollObj = this.kanbanContent.data('ejScroller');
                    scrollTop = scrollObj.scrollTop();
                    height = this.kanbanContent.height();
                }
                else {
                    scrollEle = document.scrollingElement ? document.scrollingElement : document.documentElement
                    scrollTop = scrollEle.scrollTop === 0 ? 0 : (scrollEle.scrollTop > target.parents('.e-rowcell')[0].offsetTop ? scrollEle.scrollTop - target.parents('.e-rowcell')[0].offsetTop : target.parents('.e-rowcell')[0].offsetTop - scrollEle.scrollTop);
                    height = $(window).height() - (scrollEle.scrollTop > target.parents('.e-rowcell')[0].offsetTop ? 0 : target.parents('.e-rowcell')[0].offsetTop - scrollEle.scrollTop);
                    if ((window.innerHeight + window.scrollY) >= Math.round(document.body.offsetHeight)) {
                        height = height - ($(document).height() - (target.parents('.e-rowcell')[0].offsetHeight + target.parents('.e-rowcell')[0].offsetTop))
                    }
                }
                multiKeyDiv.height(height);
                var innerHeight = 60 // height / multiKeyDiv.children().length;
                multiKeyDiv.children().height(innerHeight);
                scrollTop > 0 ? multiKeyDiv.css('top', scrollTop) : multiKeyDiv.css('top', '');
                multiKeyDiv.find('.e-text').css('top', (innerHeight / 2) - 10);
            }
        }
        /*  Rename state id's with state names */
        var multi = this.element.find(".e-targetclonemulti");
        var sid = 0;
        if (multi.length != 0) {
            for (var i = 0; i < multi.find(".e-columnkey").length; i++) {
                sid = multi.children().eq(i).find(".e-text").html();
                multi.children().eq(i).find(".e-text").html(getStateName(sid))
            }
            if (multi.find(".e-columnkey").hasClass("e-active")) {
                var index = $(multi).find(".e-columnkey.e-active").index();
                if (index != -1) {
                    targetAlertStateDragID = $(multi).parent().attr("data-ej-mappingkey").split(",")[index];
                }
            }
        }
        /*  Scroll page on drag */
        var cursorY, cursorX;
        var kObj = $("#Kanban").data("ejKanban");
        if (!ej.isNullOrUndefined(e["event"].clientX))
            cursorX = e["event"].clientX;
        else
            cursorX = e["event"].originalEvent.changedTouches[0].clientX;
        if (!ej.isNullOrUndefined(e["event"].clientY))
            cursorY = e["event"].clientY;
        else
            cursorY = e["event"].originalEvent.changedTouches[0].clientY;
        if (!kObj.element.hasClass('e-responsive') && !e.model.scrollSettings.height != 0) {
            var kTop = kObj.element.offset().top;
            var height = window.visualViewport.height;
            if (kTop > window.scrollY)
                var top = kTop - window.scrollY;
            else
                var top = kTop;
            if (cursorY > ((height > 60 ? height - 60 : height)))
                $(window).scrollTop(window.scrollY + 5);
            else if ((cursorY - 30 < top) && window.scrollY > 0) {
                $(window).scrollTop(window.scrollY - 5);
            }
        }
        if (!kObj.element.hasClass('e-responsive') && !e.model.scrollSettings.width != "auto") {
            var kLeft = kObj.element.offset().left;
            var width = window.visualViewport.width;
            if (kLeft > window.scrollX)
                var left = kLeft - window.scrollX;
            else
                var left = kLeft;
            if (cursorX > (width > 60 ? width - 60 : width))
                $(window).scrollLeft(window.scrollX + 5);
            else if ((cursorX - 10 < left) && window.scrollX > 0)
                $(window).scrollLeft(window.scrollX - 5);
        }
   } // End card drag
    function cardDragStart(args) {
        //showProgress();
    }
    function cardDragStop(args) {
        //console.log("cardDragStop draggedElement", args)
        //console.log("cardDragStop dropTarget", args.dropTarget)
        //hideProgress();
        var multi = this.element.find(".e-targetclonemulti");
        if (multi.find(".e-columnkey").hasClass("e-active")) {
            var index = $(multi).find(".e-columnkey.e-active").index();
            //console.log("cardDragStop index: " + index)
            if (index != -1) {
                multi.find(".e-columnkey.e-active .e-text").html(multi.parent().attr("data-ej-mappingkey").split(",")[index]) // Replace text into corresponding column key value
            }
        }
    }
    function cardDrop(args){
        if (args && args.draggedElement.parent() && args.data[0]) {
            //var search = $("#filterInput").val();
            //var empInput = $('#FilterEmployees').data('kendoMultiSelect');
            //var emps = empInput.value();
            //if (search || emps) {
            //    if (search != "" || emps.length > 0) {
            //        var changedArray
            //        var crudData = {
            //            changed: [ args.data[0] ],
            //            added: null,
            //            deleted: null
            //        };
            //        $.post({
            //            url: window.appBase + "ProjectManagement/Agile/CrudSprintData",
            //            dataType: "json",
            //            data: crudData
            //        }).always(function (result) {
            //            //$("#Kanban").ejKanban({ dataSource: result });
            //            //refreshBoard(false)
            //            filterCards(false, false);
            //        });
            //    }
            //}
        }
    }
    function viewCardDetails(alertID, title) {
        OpenRadWindow(title.replace(/39&apos/g,"'"), 'Desktop_AlertView?AlertID=' + alertID + '&SprintID=' + sprintId + "&FromBoard=1&OpenedFrom=25");
        // NEED TO REFRESH BOARD ON CLOSE WITH NEW TABBED UI!!!???

        //setTimeout(function () {
        //    var win = GetRadWindow().BrowserWindow.FindWindow('Desktop_AlertView');
        //    if (win) {
        //        win.add_close(function () {
        //            //refreshBoard(true);
        //            var scrollPos = $('html,body').scrollTop();
        //            onRefreshCallBack = function () {
        //                $('html,body').scrollTop(scrollPos);
        //            }
        //            filterCards();
        //        });
        //    }
        //}, 250);
    }    
    function RefreshCallback() {
        console.log("RefreshCallback");
        var scrollPos = $('html,body').scrollTop();
        onRefreshCallBack = function () {
            $('html,body').scrollTop(scrollPos);
        }
        refreshBoard(true);
    }
    function addCard(boardState, jobNumber, jobComponentNumber, clientCode) {
        if (!jobNumber) {
            jobNumber = '';
        }
        if (!jobComponentNumber) {
            jobComponentNumber = '';
        }
        if (!clientCode) {
            clientCode = '';
        }
        //console.log("addCard: ", boardState, sprintId, jobNumber, jobComponentNumber, clientCode)
        OpenRadWindow('Assignment', 'Desktop_AddWorkItem?BoardStateID=' + boardState + '&JobNumber=' + jobNumber + '&JobComponentNumber=' + jobComponentNumber + '&SprintID=' + sprintId + '&ClientCode=' + clientCode, null, 1145, false, RefreshCallback);
        //setTimeout(function () {
        //    var win = GetRadWindow().BrowserWindow.FindWindow('Desktop_AddWorkItem');
        //    if (win) {
        //        win.add_close(function () {
        //            var scrollPos = $('html,body').scrollTop();
        //            onRefreshCallBack = function () {
        //                $('html,body').scrollTop(scrollPos);
        //            }
        //            refreshBoard(true);
        //        });
        //    }
        //}, 500);
    }
    function refreshBoard(templateRefresh) {
        console.log("refreshBoard")
        $('#Kanban').data('ejKanban').refresh(templateRefresh);
        $('#FilterEmployees').data('kendoMultiSelect').dataSource.read();
    }
    function pushSprintRefresh(thisSprintId, sprintIsActive, sprintIsComplete, employeeName) {
        if (thisSprintId == sprintId) {
            refreshNeeded = true;
            checkSprintActiveComplete(thisSprintId, sprintIsActive, sprintIsComplete);
            filterCards();
            if (employeeName) {
                showNotification("Sprint updated by " + employeeName, "info");
            } else {
                showNotification("Sprint updated by other user!", "info");
            }
        }
    }
    function wireUpExpandCollapseToSession() {
        ////Here you can use the swimlane expand and collapse
        //var slexpandcollaspe = $("#Kanban").find(".e-slexpandcollapse .e-icon");
        //slexpandcollaspe.click(function (args) {
        //   //console.log("slexpandcollaspe")
        //    if (slexpandcollaspe.hasClass("e-slexpand") || slexpandcollaspe.hasClass("e-slcollapse")) {
        //        var value = $('#Kanban .e-swimlanerow').index($(args.target).parents(".e-swimlanerow"));
        //        if (sessionStorage.getItem("kbnSlCollapseCollec") == '' || ej.isNullOrUndefined(sessionStorage.getItem("kbnSlCollapseCollec")))
        //            var kbnSlCollapseCollec = [];
        //        else
        //            var kbnSlCollapseCollec = JSON.parse(sessionStorage.getItem("kbnSlCollapseCollec"));
        //        kbnSlCollapseCollec.push(value);
        //        sessionStorage.setItem("kbnSlCollapseCollec", JSON.stringify(kbnSlCollapseCollec));
        //       //console.log(JSON.stringify(kbnSlCollapseCollec))
        //    }
        //});
        ////Here you can use the column expand and collapse
        //var clexpandcollaspe = $("#Kanban").find(".e-headercell .e-icon");
        //clexpandcollaspe.click(function (args) {
        //   //console.log("clexpandcollaspe")
        //    var value = $(args.target).parents(".e-headercell").find('.e-headerdiv').text();
        //    if (clexpandcollaspe.hasClass("e-clexpand") || clexpandcollaspe.hasClass("e-clcollapse")) {
        //        var value = $(args.target).parents(".e-headercell").find('.e-headerdiv').text();
        //        if (sessionStorage.getItem("kbnCollapseCollec") == '' || ej.isNullOrUndefined(sessionStorage.getItem("kbnCollapseCollec")))
        //            var kbnCollapseCollec = [];
        //        else
        //            var kbnCollapseCollec = JSON.parse(sessionStorage.getItem("kbnCollapseCollec"));
        //        kbnCollapseCollec.push(value);
        //        sessionStorage.setItem("kbnCollapseCollec", JSON.stringify(kbnCollapseCollec));
        //       //console.log(JSON.stringify(kbnCollapseCollec))
        //    }
        //});
    }
    function completeAssignment(sender, alertId) {
        showProgress();
        var data = {
            AlertID: alertId
        };
        $.post({
            url: window.appBase + "Desktop/Alert/CompleteAlertByAlertID",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                if (response.Success == true) {
                    //console.log("completeAssignment refresh");
                    refreshBoard(true);
                }
            }
            hideProgress();
        });
    }
    function markTempComplete(sender, jobNumber, jobComponentNumber, taskSequenceNumber) {
        var content = $(sender).parent().parent().children("div.content")
        //if (content) {
        //}
        showProgress();
        var data = {
            JobNumber: jobNumber,
            JobComponentNumber: jobComponentNumber,
            TaskSequenceNumber: taskSequenceNumber,
            SprintID: sprintId
        };
        $.post({
            url: window.appBase + "ProjectManagement/Agile/MarkTaskTempComplete",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log("markTempComplete refresh");
                refreshBoard(true);
            }
            hideProgress();
        });
    }
    function backlogSortTypeChanged(e) {
        currentBacklogSortType = e.value;
        saveFilterBacklogSortType();
        setCurrentBacklogSort();
        if (currentBacklogSort && currentBacklogSort > 0) {
            sortBacklog();
        }
    }
    function backlogSortByOnSelect(e) {
        if ($('#Kanban').data('ejKanban')) {
            var scrollPos = $('html,body').scrollTop();
            onRefreshCallBack = function () {
                $('html,body').scrollTop(scrollPos);
            }
            setCurrentBacklogSort();
            sortBacklog();
        }
    }
    function setCurrentBacklogSort() {
        var value = Number($('#BacklogSortBy > .k-state-active').attr('sort-by'));
        if (isNaN(value) == true) {
            currentBacklogSort = 0;
        } else {
            currentBacklogSort = value * 1;
        }
        saveFilterBacklogSort();
    }
    function _startStopwatch(employeecode, jobnumber, jobcomponentnumber, alertid) {
        var data = {
            EmployeeCode: employeecode,
            EntryDate: '',
            Hours: 0,
            Comment: '',
            FunctionCode: '',
            DepartmentTeamCode: '',
            JobNumber: jobnumber,
            JobComponentNumber: jobcomponentnumber,
            AlertID: alertid
        };
        $.post({
            url: window.appBase + "Employee/Timesheet/StartStopwatch",
            dataType: "json",
            data: data
        }).always(function (result) {
            if (result) {
                if (result.Success && result.Success === true) {
                    window.parent.showSuccessNotification("Stopwatch started.");
                    try {
                        checkForStopwatch();
                    } catch (e) {
                    }
                    try {
                        refreshDashboardTime();
                    } catch (e) {
                    }
                    try {
                        window.parent.refreshTimesheet();
                    } catch (e) {
                    }
                    //try {
                    //    if (window.parent.closeDialogs != undefined) {
                    //        window.parent.closeDialogs();
                    //    } else {
                    //        window.parent.CloseThisWindow();
                    //    }
                    //} catch (e) {
                    //    try {
                    //        CloseThisWindow();
                    //    } catch (e) {
                    //    }
                    //}
                } else {
                    if (result.Message && result.Message !== "") {
                        try {
                            window.parent.showNotification(JSON.parse(result.Message), "error");
                        } catch (e) {
                            window.parent.showNotification(result.Message, "error");
                        }
                    }
                }
            }
        });
    }
    $(window).scroll(function (event) {
        scrollPosition = $(window).scrollTop();
    });
    $(function () {
        //var tooltip = $("#kanBanControl").kendoTooltip({
        //    filter: "#cardTitle",
        //    //width: 400,
        //    position: "top"
        //}).data("kendoTooltip");
        ////$("#Kanban").ejKanban(
        ////    {
        ////        create: function (args) {
        ////            var kbnObj = $('#Kanban').data('ejKanban')
        ////            retrivedCollec = JSON.parse(sessionStorage.getItem("kbnCollapseCollec"));
        ////            if (!retrivedCollec) return;
        ////            for (var i = 0; i < retrivedCollec.length; i++) {}
        ////                kbnObj.toggleColumn(retrivedCollec[i]);
        ////            retrivedSlCollec = JSON.parse(sessionStorage.getItem("kbnSlCollapseCollec"));
        ////            if (!retrivedSlCollec) return;
        ////            for (var i = 0; i < retrivedSlCollec.length; i++)
        ////                kbnObj.KanbanSwimlane.toggle($(".e-slexpandcollapse").eq(retrivedSlCollec[i]));
        ////        }
        ////    });
        ////Here you can use the swimlane expand and collapse
        //var slexpandcollaspe = $("#Kanban").find(".e-slexpandcollapse .e-icon");
        //slexpandcollaspe.click(function (args) {
        //   //console.log("slexpandcollaspe")
        //   if (slexpandcollaspe.hasClass("e-slexpand") || slexpandcollaspe.hasClass("e-slcollapse")) {
        //        var value = $('#Kanban .e-swimlanerow').index($(args.target).parents(".e-swimlanerow"));
        //        if (sessionStorage.getItem("kbnSlCollapseCollec") == '' || ej.isNullOrUndefined(sessionStorage.getItem("kbnSlCollapseCollec")))
        //            var kbnSlCollapseCollec = [];
        //        else
        //            var kbnSlCollapseCollec = JSON.parse(sessionStorage.getItem("kbnSlCollapseCollec"));
        //        kbnSlCollapseCollec.push(value);
        //        sessionStorage.setItem("kbnSlCollapseCollec", JSON.stringify(kbnSlCollapseCollec));
        //      //console.log(JSON.stringify(kbnSlCollapseCollec))
        //  }
        //});
        ////Here you can use the column expand and collapse
        //var clexpandcollaspe = $("#Kanban").find(".e-headercell .e-icon");
        //clexpandcollaspe.click(function (args) {
        //   //console.log("clexpandcollaspe")
        //    var value = $(args.target).parents(".e-headercell").find('.e-headerdiv').text();
        //    if (clexpandcollaspe.hasClass("e-clexpand") || clexpandcollaspe.hasClass("e-clcollapse")) {
        //        var value = $(args.target).parents(".e-headercell").find('.e-headerdiv').text();
        //        if (sessionStorage.getItem("kbnCollapseCollec") == '' || ej.isNullOrUndefined(sessionStorage.getItem("kbnCollapseCollec")))
        //            var kbnCollapseCollec = [];
        //        else
        //            var kbnCollapseCollec = JSON.parse(sessionStorage.getItem("kbnCollapseCollec"));
        //        kbnCollapseCollec.push(value);
        //        sessionStorage.setItem("kbnCollapseCollec", JSON.stringify(kbnCollapseCollec));
        //       //console.log(JSON.stringify(kbnCollapseCollec))
        //    }
        //});

        $("#backlotSortSelect").kendoDropDownList({
            change: function (e) {
                var scrollPos = $('html,body').scrollTop();
                onRefreshCallBack = function () {
                    $('html,body').scrollTop(scrollPos);
                    setTimeout(function () {
                        var input = $("#backlotSortSelect").data('kendoDropDownList');
                        input.focus();
                    });
                }
                var value = this.value();
                if (isNaN(value) == true) {
                    currentBacklogSort = 0;
                } else {
                    currentBacklogSort = value * 1;
                }
                sortBacklog();
            }
        });
    });
    $(window).resize(function() {
        setBoardSize();
    });
    $(document).ready(function () {
        //window.setTimeout(function () {
        //    setBoardSize();
        //}, 1100);
        setSwimExpandCheckboxDisabled();
    });

</script>
