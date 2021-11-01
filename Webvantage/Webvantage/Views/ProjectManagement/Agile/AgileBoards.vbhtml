@ModelType Generic.List(Of Webvantage.Controllers.ProjectManagement.AgileController.BoardDisplay)
@Code


    ViewData("Title") = ""
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<div id="gridToolBarWrap">
    @Code
        Dim CanAdd As Boolean = False
        Dim IsPMD As Boolean = False

        If ViewData("CanAdd") IsNot Nothing AndAlso ViewData("CanAdd") = True Then
            CanAdd = True
        End If
        If ViewData("IsPMD") IsNot Nothing AndAlso ViewData("IsPMD") = True Then
            IsPMD = True
        End If
        
        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
        Sub(items)

            If CanAdd = True Then

                If IsPMD = False Then

                    items.Add().Id("NewBoardToolBarItem").Type(CommandType.Button).Click("newBoard").Text("<span class='wvi wvi-navigate-plus'></span>").HtmlAttributes(New With {.title = "Add new board", .class = "wv-icon-button wv-add-new"}).Enable(CanAdd)

                Else

                    items.Add().Id("NewBoardToolBarItem").Type(CommandType.Button).Click("newBoard").Text("<span class='wvi wvi-navigate-plus'></span>").HtmlAttributes(New With {.title = "Add/remove this job from board(s)", .class = "wv-icon-button wv-add-new"}).Enable(CanAdd)

                End If

                items.Add().Type(CommandType.Separator)

            End If

            items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Text("<span class='wvi wvi-refresh'></span>").Click("reloadWindow")
            'items.Add().Type(CommandType.Button).Click("goBack").Text("<span class='glyphicon glyphicon-arrow-left'></span>").HtmlAttributes(New With {.title = "Go Back"})
            If IsPMD = False Then

                items.Add().Type(CommandType.Separator)
                items.Add().Type(CommandType.Button).Click("bookmarkBoard").Text("<span class='wvi wvi-book-bookmark'></span>").HtmlAttributes(New With {.title = "Bookmark this page", .class = "k-button wv-icon-button "})

            End If

        End Sub
)
        TopToolBar.Events(
Sub(e)

End Sub)
        TopToolBar.Render()
    End Code
</div>
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

            Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.Database.Entities.SprintHeader)("BoardsGrid")
            GridBuilder.Datasource(Model)
            GridBuilder.AllowMultiSorting(True)
            GridBuilder.AllowSelection(False)
            GridBuilder.AllowSorting(True)
            GridBuilder.AllowTextWrap(True)
            GridBuilder.EnableToolbarItems(False)
            GridBuilder.SelectionType(SelectionType.Single)
            GridBuilder.EditSettings(Sub(Edit)
                                         'Edit.AllowDeleting() '.AllowEditing()
                                         'Edit.ShowDeleteConfirmDialog()
                                     End Sub)
            GridBuilder.ToolbarSettings(Sub(Toolbar)
                                            'Toolbar.ShowToolbar().ToolbarItems(Sub(Items)
                                            '                                       Items.AddTool(ToolBarItems.PrintGrid)
                                            '                                       Items.AddTool(ToolBarItems.Add)
                                            '                                       'Items.AddTool(ToolBarItems.Edit)
                                            '                                       'Items.AddTool(ToolBarItems.Delete)
                                            '                                       'Items.AddTool(ToolBarItems.Update)
                                            '                                       'Items.AddTool(ToolBarItems.Cancel)
                                            '                                   End Sub)
                                        End Sub)
            GridBuilder.ClientSideEvents(Sub(Events)
                                             'Events.RowSelected("gridRowSelected")
                                             Events.DataBound("boardsGridDataBound")
                                         End Sub)
            GridBuilder.Columns(Sub(Column)
                                    Column.Field("ID").Visible(False).IsPrimaryKey(True).Add()
                                    Column.HeaderText("").Commands(Sub(command)
                                                                       command.Type("ViewDetails").ButtonOptions(New Syncfusion.JavaScript.Models.ButtonProperties With {
                                                                                                                      .ContentType = ContentType.ImageOnly,
                                                                                                                      .Text = "View",
                                                                                                                      .PrefixIcon = "glyphicon glyphicon-search",
                                                                                                                      .HtmlAttributes = New Dictionary(Of String, Object) From {{"title", "View"}},
                                                                                                                      .Click = "viewDetailsClicked"}).Add()
                                                                   End Sub).Width("88px").Visible(True).Add()
                                    Column.Field("Name").HeaderText("Name").EditType(EditingType.StringEdit).Add()
                                    Column.Field("Description").HeaderText("Description").EditType(EditingType.StringEdit).Add()
                                    Column.Field("SprintCount").HeaderText("Sprints").EditType(EditingType.NumericEdit).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(70).Visible(False).Add()
                                    'Column.Field("CreatedDate").HeaderText("Created").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Format("{0:d}").Width(150).Add()
                                    'Column.Field("CreatedByUserCode").HeaderText("By").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).Add()
                                    Column.Field("BoardOwnerFullName").HeaderText("Owner").EditType(EditingType.StringEdit).Add()
                                    Column.Field("OfficeName").HeaderText("Office").EditType(EditingType.StringEdit).Add()
                                    If IsPMD = False Then

                                        Column.HeaderText("").Commands(Sub(command)
                                                                           command.Type(UnboundType.Edit).ButtonOptions(New Syncfusion.JavaScript.Models.ButtonProperties With {
                                                                                                                      .ContentType = ContentType.ImageOnly,
                                                                                                                      .Text = "Edit",
                                                                                                                      .PrefixIcon = "glyphicon glyphicon-pencil",
                                                                                                                      .HtmlAttributes = New Dictionary(Of String, Object) From {{"title", "Edit"}},
                                                                                                                      .Click = "editClicked"}).Add()
                                                                           command.Type(UnboundType.Delete).ButtonOptions(New Syncfusion.JavaScript.Models.ButtonProperties With {
                                                                                                                                .ContentType = ContentType.ImageOnly,
                                                                                                                                .Text = "Delete",
                                                                                                                                .Enabled = ViewData("CanAdd"),
                                                                                                                                .PrefixIcon = "wvi wvi-delete",
                                                                                                                                .HtmlAttributes = New Dictionary(Of String, Object) From {{"title", "Delete"}},
                                                                                                                                .Click = "deleteClicked"}).Add()
                                                                       End Sub).Width("145px").Visible(True).Add()

                                    End If
                                End Sub)
            GridBuilder.Render()

        Else

            If ViewData("IsPMD") IsNot Nothing AndAlso ViewData("IsPMD") = True Then

                @Html.Raw("This job is not part of any boards")

            End If

        End If
    End Code
    <script>
        var newAgileBoardUrl = "";
        var addJobToBoardsUrl = "";
        var isPMD = false;

        newAgileBoardUrl = "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)" + "NewAgileBoard/0";
        addJobToBoardsUrl = "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)" + "AddJobToBoards";
        isPMD = @Html.Raw(ViewData("IsPMD").ToString.ToLower)

        function newBoard() {
            var qs = getQueryString();
            var jobNumber = 0;
            var jobComponentNumber = 0;
            var h = 0;
            var w = 0;
            var t = "";
            if (qs) {
                if (qs.j) {
                    jobNumber = qs.j * 1;
                }
                if (qs.jc) {
                    jobComponentNumber = qs.jc * 1;
                }
            }
            $("#NewBoardDialog").ejDialog();
            $("#NewBoardDialog").ejDialog("destroy");
            $("#NewBoardDialog").ejDialog();
            var url = window.appBase + newAgileBoardUrl;
            if (isPMD == true && jobNumber > 0 && jobComponentNumber > 0) {
                url = window.appBase + addJobToBoardsUrl + "?j=" + jobNumber + "&jc=" + jobComponentNumber;
                h = 400;
                w = 800;
                t = "Add Job To Boards";
            } else {
                url = window.appBase + newAgileBoardUrl;
                h = 600;
                w = 800;
                t = "New Board";
            }
            var dialog = $("#NewBoardDialog").ejDialog({
                contentType: "iframe",
                contentUrl: url,
                title: t,
                height: h,
                width: w
            });
            $("#NewBoardDialog").ejDialog("refresh");
            $("#NewBoardDialog").ejDialog("open");
        }
        function reloadWindow(){
            location.reload();
        }
        function goToURL(url){
            if (url) {
                window.location.assign(url);
            } else {
                reloadWindow();
            }
        }
        function goBack(){
            window.history.back();
        }
        function bookmarkBoard() {
            //if (boardId) {
                var boardData = {
                    BoardID: 0
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/BookmarkMainBoard",
                    dataType: "json",
                    data: boardData
                }).always(function (result) {
                    showKendoAlert(result.message);
                });
            //}
        }
        function viewDetailsClicked(args) {
            var grid = $("#BoardsGrid").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            var name = grid.getCurrentViewData()[index].Name;
            //console.log(grid.getCurrentViewData()[index])
            loadBoard(id, name);
        }
        function editClicked(args) {
            var grid = $("#BoardsGrid").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            if (id) {
                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)NewAgileBoard/" + id;
                $("#EditBoardDialog").ejDialog({
                    contentUrl: url,
                    contentType: 'iframe',
                    title: 'Edit Board',
                    height: 600,
                    width: 800
                });
                $("#EditBoardDialog").ejDialog("open");
            }
        }
        function deleteClicked(args) {
            var grid = $("#BoardsGrid").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            var confirmMessage = "";
            var sprintCount = grid.getCurrentViewData()[index].SprintCount * 1;
            var boardName = grid.getCurrentViewData()[index].Name;
            if (sprintCount && sprintCount > 0) {
                if (sprintCount == 1) {
                    confirmMessage = "There is one sprint on the " + "\"" + grid.getCurrentViewData()[index].Name + "\" board.\nAre you sure you want to delete?";
                }
                if (sprintCount > 1) {
                    confirmMessage = "There are " + sprintCount + " sprints on the " + "\"" + grid.getCurrentViewData()[index].Name + "\" board.\nAre you sure you want to delete?";
                }
            } else {
                confirmMessage = "Are you sure you want to delete the \"" + grid.getCurrentViewData()[index].Name + "\" board?"
            }
            if (id) {
                showKendoConfirm(confirmMessage)
                    .done(function () {
                        var deleteData = {
                            BoardID: id
                        };
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/DeleteAgileBoard",
                            dataType: "json",
                            data: deleteData
                        }).always(function (result) {
                            if (result) {
                                //console.log(result );
                                $("#BoardsGrid").ejGrid({
                                    dataSource: result
                                });
                            }
                        });
                    })
                    .fail(function () {
                    });
            }
        }
        function gridRowSelected(args) {
            var id = args.data.ID;
            loadBoard(id, "");
        }
        function boardsGridDataBound(args) {
        //   //console.log(args)
        }
        function loadBoard(boardId, boardName) {
            if (boardId) {
                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)AgileBoard/" + boardId;
                //window.location.assign(url);
                window.location.href = url;
            }
        }
        function newBoardDialogLoaded(args) {
        }
        function newBoardDialogContentLoad(args) {
        }
        function closeDialogs() {
            closeNewBoardDialog();
            closeEditBoardDialog();
        }
        function closeNewBoardDialog() {
            if ($("#NewBoardDialog").data() && $("#NewBoardDialog").data('ejDialog')) {
                $("#NewBoardDialog").ejDialog("close");
            }
        }
        function closeEditBoardDialog() {
            if ($("#EditBoardDialog").data() && $("#EditBoardDialog").data('ejDialog')) {
                $("#EditBoardDialog").ejDialog("close");
            }
        }
        $(document).ready(function () {
            window.setTimeout(function () {
                if (isPMD == true) {

                } else {

                }
            }, 250);
        });
    </script>
</div>

<div id="NewBoardDialog"></div>
<div id="EditBoardDialog"></div>
