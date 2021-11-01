@ModelType Generic.List(Of AdvantageFramework.Database.Entities.SprintHeader)
@Code

    ViewData("Title") = "Sprints"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<div id="gridToolBarWrap">
    <script>
        function newSprint() {
            $("#NewSprintDialog").ejDialog("open");
        }
        function reloadWindow (){
            location.reload();
        }
        function manageEpics() {
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Epics";
            window.location = url;
       }
        function manageBoards() {
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)AgileBoards";
            window.location = url;
        }
        function manageBacklog() {
             var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)BacklogManager";
            window.location = url;
       }
    </script>
    @Code
        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
            Sub(items)
                items.Add().Id("NewSprintToolBarItem").Type(CommandType.Button).Click("newSprint").Icon("plus").HtmlAttributes(New With {.title = "Add new sprint"})
                items.Add().Type(CommandType.Separator)
                items.Add().Template("<div>Manage:</div>")
                items.Add().Id("ManageEpicsToolBarItem").Type(CommandType.Button).Click("manageEpics").Text("Epics").HtmlAttributes(New With {.title = "Manage Epics"})
                items.Add().Id("ManageBoardsToolBarItem").Type(CommandType.Button).Click("manageBoards").Text("Boards").HtmlAttributes(New With {.title = "Manage Boards"})
                items.Add().Id("ManageBacklogToolBarItem").Type(CommandType.Button).Click("manageBacklog").Text("Backlog").HtmlAttributes(New With {.title = "Manage Backlog"})
                items.Add().Type(CommandType.Separator)
                items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .style = "width:35px;"}).Icon("refresh").Click("reloadWindow")
            End Sub
        )
        TopToolBar.Events(
    Sub(e)

    End Sub)
        TopToolBar.Render()
    End Code
</div>
@Code


    Dim NewSprintDialog = Html.EJ().Dialog("NewSprintDialog")
    Dim NewSprintURL = ViewData("NewSprintURL")

    NewSprintDialog.Title("New Sprint")
    NewSprintDialog.ShowOnInit(False)
    NewSprintDialog.ContentType("iframe")
    NewSprintDialog.ContentUrl(NewSprintURL)

    NewSprintDialog.Height("500px")
    NewSprintDialog.Width("800px")
    NewSprintDialog.Render()

End Code
<div style="margin: 10px 0px 0px 0px;">
    <style>
        /*
            .e-headercell {
                border: 0px !important;
                background-color: #2A579A !important;
                color: #FFFFFF;
            }
            .e-rowcell {
                border: 0px !important;
            }
        */
    </style>
    @Code
        If Model.Count > 0 Then

            Dim BoardBuilder = Html.EJ().Grid(Of AdvantageFramework.Database.Entities.SprintHeader)("BoardsGrid")
            BoardBuilder.Datasource(Model)
            BoardBuilder.Columns(Sub(Column)

                                     Column.Field("ID").Visible(False).IsPrimaryKey(True).Add()
                                     Column.Field("Description").HeaderText("Description").EditType(EditingType.StringEdit).Add()
                                     Column.Field("StartDate").HeaderText("Week Beginning").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Format("{0:d}").Width(150).Add()
                                     Column.Field("NumberOfWeeks").HeaderText("# of Weeks").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).Add()
                                     Column.Field("IsActive").HeaderText("Active").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Width(60).Add()

                                 End Sub)
            BoardBuilder.AllowSelection(False)
            BoardBuilder.SelectionType(SelectionType.Single)
            BoardBuilder.AllowSorting(True)
            BoardBuilder.AllowMultiSorting(True)
            BoardBuilder.EnableToolbarItems(False)
            BoardBuilder.AllowTextWrap(True)
            BoardBuilder.ToolbarSettings(Sub(Toolbar)
                                             'Toolbar.ShowToolbar().ToolbarItems(Sub(Items)
                                             '                                       Items.AddTool(ToolBarItems.PrintGrid)
                                             '                                       Items.AddTool(ToolBarItems.Add)
                                             '                                       'Items.AddTool(ToolBarItems.Edit)
                                             '                                       'Items.AddTool(ToolBarItems.Delete)
                                             '                                       'Items.AddTool(ToolBarItems.Update)
                                             '                                       'Items.AddTool(ToolBarItems.Cancel)
                                             '                                   End Sub)
                                         End Sub)
            BoardBuilder.EditSettings(Sub(Edit)
                                          'Edit.AllowAdding().AllowDeleting().AllowEditing().AllowEditOnDblClick().EditMode(EditMode.Dialog)
                                      End Sub)
            BoardBuilder.ClientSideEvents(Sub(Events)
                                              Events.RowSelected("gridRowSelected")
                                          End Sub)

            BoardBuilder.Render()

        End If
    End Code
    <script>
        function gridRowSelected(args) {
            //console.log(args.data.ID)
            //console.log(args);
            var sprintId = args.data.ID;
            if (sprintId) {
                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)/Sprint/" + sprintId;
                goToURL(url);
                //OpenRadWindow("Project Board", url);
            }
        }
    </script>
</div>
