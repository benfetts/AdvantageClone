@ModelType Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel)
@Code       ViewData("Title") = ""
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts
    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>
End Section
<div id="gridToolBarWrap">
    <script>
        function boardDesigner (){
            $("#NewBoardDialog").ejDialog("open");
        }
        function reloadWindow (){
            location.reload();
        }
        function boardHeaderAdded(boardHeaderID) {
            var jobNumber = @Html.Raw(Json.Encode(ViewData("JobNumber")));
            var jobComponentNumber = @Html.Raw(Json.Encode(ViewData("JobComponentNumber")));
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)/Design/" + boardHeaderID + "/" + jobNumber + "/" + jobComponentNumber + "/ProjectBoards";
            window.location = url;
        }
        function goToURL(url) {
            window.location = url;
        }
        function closeDialogs() {
            $("#NewBoardDialog").ejDialog("close");
        }
    </script>
    @Code
        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
            Sub(items)
                items.Add().Id("BoardDesignerToolBarItem").Type(CommandType.Button).Click("boardDesigner").Text("<span class='wvi wvi-navigate-plus'></span>").HtmlAttributes(New With {.title = "Create and design a new board", .class = "wv-icon-button wv-add-new"})
                items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Text("<span class='wvi wvi-rotate-right'></span>").Click("reloadWindow")
            End Sub
)
        TopToolBar.Events(
        Sub(e)

        End Sub)
        TopToolBar.Render()
    End Code
</div>
@Code


    Dim NewBoardDialog = Html.EJ().Dialog("NewBoardDialog")
    NewBoardDialog.Title("New Board")
    NewBoardDialog.ShowOnInit(False)
    NewBoardDialog.ContentType("iframe")
    NewBoardDialog.ContentUrl(String.Format("{0}://{1}{2}{3}/{4}/{5}/{6}",
                                            Request.Url.Scheme,
                                            Request.Url.Authority,
                                            Url.Content("~"),
                                            Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute & "NewBoard",
                                            0, 0, "Boards"))
    NewBoardDialog.Height("470px")
    NewBoardDialog.Render()
End Code

<style>
    .view-button {
        margin-left: 10px !important;
        margin-right: 10px !important;
    }
</style>

<div style="margin: 10px 0px 10px 0px; padding: 0px 0px 10px 0px; width: 100%">
    <script>
        function goToURL(url) {
            window.location = url;
        }
        function loadBoard(boardId) {
            if (boardId) {
                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Design/" + boardId + "/0/0/Boards";
                //goToURL(url);
                OpenRadWindow("Board Designer", url);
            }
        }
        function viewDetailsClicked(args) {
            var grid = $("#BoardListsGrid").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            loadBoard(id);
        }
        function editClicked(args) {
            var grid = $("#BoardListsGrid").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            loadBoard(id);
        }
        function gridRowSelected(args) {

            var boardHeaderId = args.data.ID;
            if (boardHeaderId) {
                loadBoard(boardHeaderId);
          }
        }
        function boardHeaderAdded(boardHeaderID) {
            var jobNumber = 0;
            var jobComponentNumber = 0;
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Design/" + boardHeaderID + "/" + jobNumber + "/" + jobComponentNumber + "/Boards";
            //window.location = url;
            OpenRadWindow("", url);
            $.post({
                url: window.appBase + "ProjectManagement/Agile/LoadBoardDesignerList",
                dataType: "json"
            }).always(function (result) {
                if (result) {
                   //console.log(result);
                    $("#BoardListsGrid").ejGrid({
                        dataSource: result
                    });
                }
            });
            $("#NewBoardDialog").ejDialog("close");
       }

    </script>
    <script id="chkTmplt" type="text/template">
        <input type="checkbox" {{if IsActive == true }}checked="checked"{{/if}} onclick="isActiveChange({{:ID}}, this);" />
    </script>

        @Code
            Dim BoardBuilder = Html.EJ().Grid(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.BoardMaintenanceViewModel)("BoardListsGrid")
            BoardBuilder.Datasource(Model.ToList)
            BoardBuilder.Columns(Sub(Column)
                                     Column.Field("Name").HeaderText("Name").Add()
                                     Column.Field("Description").HeaderText("Description").Add()
                                     Column.Field("IsActive").HeaderText("Active").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#chkTmplt").Width(60).Add()
                                     Column.HeaderText("").Commands(Sub(command)
                                                                        command.Type("ViewDetails").ButtonOptions(New Syncfusion.JavaScript.Models.ButtonProperties With {
                                                                                                                       .ContentType = ContentType.ImageOnly,
                                                                                                                       .CssClass = "view-button",
                                                                                                                       .PrefixIcon = "glyphicon glyphicon-pencil",
                                                                                                                       .HtmlAttributes = New Dictionary(Of String, Object) From {{"title", "Edit"}},
                                                                                                                       .Click = "editClicked"}).Add()
                                                                    End Sub).Visible(True).Width("98").Add()
                                 End Sub)
            BoardBuilder.AllowSelection(False)
            BoardBuilder.AllowTextWrap(True)
            BoardBuilder.SelectionType(SelectionType.Single)
            BoardBuilder.AllowSorting(True)
            BoardBuilder.AllowMultiSorting(True)
            BoardBuilder.EnableToolbarItems(True)
            BoardBuilder.EditSettings(Sub(Edit)
                                          Edit.AllowAdding(True)
                                          Edit.AllowDeleting(True)
                                          Edit.AllowEditing(True)
                                          Edit.AllowEditOnDblClick(False)
                                          Edit.EditMode(EditMode.Normal)
                                      End Sub)
            BoardBuilder.ClientSideEvents(Sub(evt)
                                          End Sub)
            BoardBuilder.Render()
        End Code


</div>
<script>
    function isActiveChange(boardHeaderId, checkbox) {
        //console.log(boardHeaderId)
        //console.log(checkbox.checked)
        var data = {
            BoardHeaderID: boardHeaderId,
            IsActive: checkbox.checked
        };
        $.post({
            url: window.appBase + "ProjectManagement/Agile/SetBoardActive",
            dataType: "json",
            data: data
        }).always(response => {
        });
    }
</script>
