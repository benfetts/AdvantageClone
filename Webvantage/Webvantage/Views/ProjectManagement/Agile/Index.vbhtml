@ModelType AdvantageFramework.ProjectSchedule.Classes.ProjectBoard

@Code

    ViewData("Title") = "Project Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code

<script id="customToolTip" type="text/x-jsrender">
    <div class='e-kanbantooltiptemplate'>
        <table>
            <tr>
                <td class="photo"></td>
                <td class="details">
                    <table>
                        <colgroup>
                            <col style="width:30%">
                            <col style="width:70%">
                        </colgroup>
                        <tbody>
                            <tr>
                                <td class="CardHeader">Days:</td>
                                <td>{{:Days}}</td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Milestone:</td>
                                <td>{{:IsMilestoneDisplay}}</td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Comment:</td>
                                <td>{{:Comment}}</td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Start:</td>
                                <td>{{:StartDateDisplay}}</td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Due:</td>
                                <td>{{:DueDateDisplay}}</td>
                            </tr>
                            <tr>
                                <td class="CardHeader">Due Comment:</td>
                                <td>{{:DueDateComment}}</td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</script>
<script>
    function cardDragStop(args){
        //console.log(args);
//        var task = args.data[0][0];
//        if (task) {
//           //console.log(JSON.stringify(task));
//        }
    }
    function cardDrop(args){
//       //console.log(args);
//        var task = args.data[0][0];
//        if (task) {
//           //console.log(JSON.stringify(task));
//        }
           // showKendoAlert("Dropped Column mapping key: " + args.draggedElement.parent().attr("data-ej-mappingkey"));
       //console.log(args.draggedElement.parent())
        showKendoAlert("Dropped Column mapping key: " + args.draggedElement.parent().attr("data-ej-mappingkey"));
    }
</script>
<style>
    .details > table {
        width: 100%;
        margin-left: 2px;
        border-collapse: separate;
        border-spacing: 1px;
    }

    .e-kanbantooltiptemplate {
        width: 250px;
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
</style>

<div id="gridToolBarWrap">
    <script>

        function QuickEditTaskButtonClick(){
            showKendoAlert("QuickEditTaskButtonClick");
        }
        function QuickAddTaskButtonClick(){
            showKendoAlert("QuickAddTaskButtonClick");
        }
        function showTaskOptions(){
            showKendoAlert("showTaskOptions");
        }
        function showEmployeeOptions(){
            showKendoAlert("showEmployeeOptions");
        }
        function openSettings(){
            showKendoAlert("openSettings ");
        }
        function reloadWindow (){
            showKendoAlert("reloadWindow  ");
        }


    </script>
    @Code


        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
            Sub(items)

                If Model.Schedule.CanUserEdit = True Then

                    items.Add().Id("QuickEditTaskButton").Type(CommandType.Button).Click("QuickEditTaskButtonClick").Text("<span class='glyphicon glyphicon-pencil'></span>").HtmlAttributes(New With {.title = "Quick Edit Schedule"})
                    items.Add().Id("QuickAddTaskButon").Type(CommandType.Button).Click("QuickAddTaskButtonClick").Text("<span class='glyphicon glyphicon-plus'></span>").HtmlAttributes(New With {.title = "Quick Add Task"})

                End If

                items.Add().Id("TaskOptionsButton").Type(CommandType.Button).Click("showTaskOptions").Text("Tasks")

                If Model.Schedule.CanUserEdit = True Then

                    items.Add().Id("EmployeeOptionsButton").Type(CommandType.Button).Click("showEmployeeOptions").Text("Employees")

                End If

                items.Add().Type(CommandType.Separator)
                items.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Settings/Options", .style = "width:35px;"}).Icon("custom").Click("openSettings")
                items.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .style = "width:35px;"}).Icon("refresh").Click("reloadWindow")

            End Sub
        )
        TopToolBar.Events(
            Sub(e)

            End Sub)
        TopToolBar.Render()


    End Code
</div>
<div id="ControlRegion">
    @Code

        Dim kanbanbuilder = Html.EJ().Kanban("Kanban")
        kanbanbuilder.DataSource(Model.Tasks)
        kanbanbuilder.SelectionType(SelectionType.Multiple)
        kanbanbuilder.KeyField("StatusCode")
        kanbanbuilder.Locale("en-US")
        kanbanbuilder.AllowTitle(True)
        kanbanbuilder.IsResponsive(True)
        kanbanbuilder.AllowDragAndDrop(True)
        kanbanbuilder.AllowKeyboardNavigation(True)
        kanbanbuilder.ClientSideEvents(
            Sub(events)
                events.CardDragStop("cardDragStop")
                events.CardDrop("cardDrop")
            End Sub
    )
        kanbanbuilder.TooltipSettings(
    Sub(tooltip)
        tooltip.Enable(True).Template("#customToolTip")
    End Sub)
        kanbanbuilder.EditSettings(
            Sub(ed)
                ed.AllowAdding(True)
                ed.AllowEditing(True)
                ed.FormPosition(KanbanFormPosition.Right)
                ed.EditMode(KanbanEditMode.Dialog)
                ed.EditItems(Sub(e)
                                 e.Field("Phase").EditType(KanbanEditingType.Dropdown).Add()
                                 e.Field("Task").EditType(KanbanEditingType.Dropdown).Add()
                                 e.Field("Status").EditType(KanbanEditingType.Dropdown).Add()
                                 e.Field("Start").EditType(KanbanEditingType.DatePicker).Add()
                                 e.Field("Due").EditType(KanbanEditingType.DateTimePicker).Add()
                                 e.Field("Completed").EditType(KanbanEditingType.DatePicker).Add()
                                 e.Field("Task Comments").EditType(KanbanEditingType.TextArea).Add()
                                 e.Field("Due Date Comments").EditType(KanbanEditingType.TextArea).Add()
                                 e.Field("Revised Due Date Comments").EditType(KanbanEditingType.TextArea).Add()
                             End Sub)
            End Sub)
        kanbanbuilder.Fields(
            Sub(field)
                field.Color("TrafficRoleCode")
                field.Content("Description")
                field.PrimaryKey("SequenceNumber")
                field.Title("PhaseDescription")
            End Sub)
        kanbanbuilder.Columns(
            Sub(col)
                col.HeaderText("To Do").Key("P").Add()
                col.HeaderText("Low Priority").Key("L").Add()
                col.HeaderText("Normal Priority").Key("A").Add()
                col.HeaderText("High Priority").Key("H").Add()
                col.HeaderText("Done").Key("D").Add()
            End Sub)
        kanbanbuilder.StackedHeaderRows(
            Sub(rows)
                rows.StackedHeaderColumns(Sub(Columns)
                                              Columns.HeaderText("Doing").Column("Low Priority, Normal Priority, High Priority").Add()
                                          End Sub).Add()
            End Sub)
        kanbanbuilder.CardSettings(
            Sub(card)
                card.ColorMapping(Sub(color)
                                      color.Add("#E53935", "HH,highest,crtvm")
                                      color.Add("#FF9800", "H,high,est,as")
                                      color.Add("#00BCD4", "--,normal,NoRoleCode")
                                      color.Add("#1976D2", "L,low,progde,prog")
                                      color.Add("#0D47A1", "LL,lowest,qa")
                                  End Sub)
            End Sub)
        kanbanbuilder.Render()
    End Code
</div>
