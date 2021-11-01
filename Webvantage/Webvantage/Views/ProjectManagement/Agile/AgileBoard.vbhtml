@ModelType Webvantage.Controllers.ProjectManagement.AgileController.BoardView
@Code

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
            $("#NewSprintDialog").ejDialog();
            $("#NewSprintDialog").ejDialog("destroy");
            $("#NewSprintDialog").ejDialog();
            var newSprintURL = "";
            try {
                newSprintURL = "@Html.Raw(ViewData("NewSprintURL"))";
            } catch (e) {
                newSprintURL = null;
            }
           try {
               if (newSprintURL && newSprintURL != "") {
                    //console.log(newSprintURL)
                    $("#NewSprintDialog").ejDialog({
                        title: "New Sprint",
                        showOnInit: false,
                        contentType: "iframe",
                        contentUrl: newSprintURL,
                        height: 600
                    });
                }
            } catch (e) {
            }
            $("#NewSprintDialog").ejDialog("refresh");
            $("#NewSprintDialog").ejDialog("open");
        }
        function editBoard() {
            var url = "@Html.Raw(ViewData("EditAgileBoardURL"))";
            $("#EditBoardDialog").ejDialog({
                contentUrl: url
            });
            $("#EditBoardDialog").ejDialog("open");
        }
        function reloadWindow (){
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
             var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)AgileBoards";
             window.location.assign(url);
        }
        function closeDialogs() {
            closeBoardDialog();
            closeSprintDialog();
        }
        function closeBoardDialog() {
            $("#EditBoardDialog").ejDialog("close");
        }
        function closeSprintDialog() {
            $("#NewSprintDialog").ejDialog("close");
        }
    </script>
    @Code
        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
            Sub(items)
                items.Add().Id("NewSprintToolBarItem").Type(CommandType.Button).Click("newSprint").Text("<span class='wvi wvi-navigate-plus'></span>").HtmlAttributes(New With {.title = "Add new sprint", .class = "wv-icon-button wv-add-new k-button"}).Enable(ViewData("CanAdd"))
                items.Add().Type(CommandType.Button).Click("editBoard").Text("<span class='wvi wvi-pencil-action-edit'></span>").HtmlAttributes(New With {.title = "Edit Board", .class = "wv-icon-button wv-neutral"})
                items.Add().Type(CommandType.Separator)
                items.Add().Type(CommandType.Button).Click("goBack").Text("<span class='wvi wvi-arrow-left'></span>").HtmlAttributes(New With {.title = "Go Back", .class = "wv-icon-button wv-neutral"})
                items.Add().Type(CommandType.Separator)
                items.Add().Type(CommandType.Button).Click("bookmarkBoard").Text("<span class='wvi wvi-book-bookmark'></span>").HtmlAttributes(New With {.title = "Bookmark this board", .class = "k-button wv-icon-button "})
                items.Add().Id("RefreshToolBarItem").Text("<span class='wvi wvi-refresh'></span>").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Click("reloadWindow")

            End Sub
)
        TopToolBar.Events(
    Sub(e)

    End Sub)
        TopToolBar.Render()
    End Code
</div>
@Code

    Dim EditBoardDialog = Html.EJ().Dialog("EditBoardDialog")
    EditBoardDialog.Title("Edit Board")
    EditBoardDialog.ShowOnInit(False)
    EditBoardDialog.ContentType("iframe")
    'EditBoardDialog.ContentUrl(ViewData("EditAgileBoardURL"))
    EditBoardDialog.Height("600px")
    EditBoardDialog.Width("800px")
    EditBoardDialog.Render()

End Code
<div id="NewSprintDialog"></div>
<script>
</script>
<div style="margin-top: 0px; width: 100%">
    <div>
        <div style="display:inline-block; text-align: left; width:80%">
            @Html.Raw(Model.Header.Description)
        </div>
        <div style="display:inline-block; text-align: right; width:18%">
            @Html.EJ().CheckBox("CheckboxIncludeCompleted").Value("IncludeCompleted").Size(Size.Medium).Checked(False).ClientSideEvents(Sub(evt)
                                                                                                                                            evt.Change("checkboxIncludeCompletedChanged")
                                                                                                                                        End Sub)&nbsp;&nbsp;Include completed
        </div>
    </div>
</div>
<script id="tmpltIsActive" type="text/template">
    <input type="radio" name="activeSprint" value="{{:ID}}" {{if IsActive == true }} checked="checked" {{/if}} onclick="isActiveChange({{:ID}}, this, {{:IsComplete}});" />
</script>
<script id="tmpltIsComplete" type="text/template">
    <input type="checkbox" {{if IsComplete == true }} checked="checked" {{/if}} onclick="isCompletedChange({{:ID}}, this);" disabled style="display:none !important" />
    {{if IsComplete == true }} 
    <span class="glyphicon glyphicon-ok" title="This sprint is completed"></span>
    {{/if}}
</script>
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
        'If Model.Sprints.Count > 0 Then
        Dim CanUpdate As Boolean = False
        If ViewData("CanUpdate") IsNot Nothing AndAlso ViewData("CanUpdate") = True Then
            CanUpdate = True
        End If

        Dim WrapSettings As New Syncfusion.JavaScript.Models.TextWrapSettings
        WrapSettings.WrapMode = WrapMode.Both

        Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.Database.Entities.SprintHeader)("Sprints")
        GridBuilder.Datasource(Model.Sprints)
        GridBuilder.EditSettings(Sub(Edit)
                                     Edit.AllowDeleting(True)
                                 End Sub)
        GridBuilder.AllowMultiSorting(True)
        GridBuilder.AllowSelection(False)
        GridBuilder.AllowSorting(True)
        GridBuilder.AllowTextWrap(True)
        GridBuilder.TextWrapSettings(WrapSettings)
        GridBuilder.SelectionType(SelectionType.Single)
        GridBuilder.EnableToolbarItems(False)
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
                                Column.Field("Description").HeaderText("Sprint").EditType(EditingType.StringEdit).Add()
                                Column.Field("StartDateAsString").HeaderText("Start").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(110).Add()
                                Column.Field("NumberOfWeeks").HeaderText("Weeks").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Width(68).Add()
                                Column.Field("ItemCount").HeaderText("Active Items").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Width(68).Add()
                                'Column.Field("IsComplete").HeaderText("Complete").Type("boolean").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Width(82).Add()
                                Column.Field("IsComplete").HeaderText("Complete").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#tmpltIsComplete").Width(85).Add()
                                Column.Field("IsActive").HeaderText("Active").TextAlign(Syncfusion.JavaScript.TextAlign.Center).Template("#tmpltIsActive").Width(60).Add()
                                If CanUpdate = True Then
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
                                         Events.ActionBegin("gridActionBegin")
                                     End Sub)
        GridBuilder.Render()

        'End If
    End Code
    <script>
        var boardId = @Html.Raw(Model.Header.ID) * 1;
        function bookmarkBoard() {
            if (boardId) {
                var boardData = {
                    BoardID: boardId
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/BookmarkBoard",
                    dataType: "json",
                    data: boardData
                }).always(function (result) {
                    showKendoAlert(result.message);
                });
            }
        }
        function isCompletedChange(sprintHeaderId, checkbox) {
            //console.log(sprintHeaderId)
            //console.log(checkbox.checked)
            //var data = {
            //    BoardHeaderID: boardHeaderId,
            //    IsActive: checkbox.checked
            //};
            //$.post({
            //    url: window.appBase + "ProjectManagement/Agile/SetBoardActive",
            //    dataType: "json",
            //    data: data
            //}).always(response => {
            //});
        }
        function isActiveChange(sprintHeaderId, checkbox, isCompleted) {
            //console.log(isCompleted)
            if (isCompleted == true) {
                showKendoAlert("Cannot start completed sprint");
                $(checkbox).prop("checked", false);
                return false;
            } else {
                showKendoConfirm("Start sprint?")
                    .done(function () {
                        var startSprintData = {
                            SprintID: sprintHeaderId,
                            IncludeSprintList: true,
                            IncludeCompleted: $("#CheckboxIncludeCompleted").ejCheckBox("instance").option("checked")
                        };
                        //console.log(startSprintData)
                        $.post({
                            url: window.appBase + "ProjectManagement/Agile/StartSprint",
                            dataType: "json",
                            data: startSprintData
                        }).always(function (result) {
                            //console.log(result)
                            if (result) {
                                if (result.Success == true) {
                                    $("#Sprints").ejGrid({
                                        dataSource: result.Data
                                    });
                                }
                                if (result.Success == false) {
                                    showKendoAlert(result.Message)
                                }
                            }
                        });
                    })
                    .fail(function () {
                        $(checkbox).prop("checked", false);
                        return false;
                    });
            }
        }
        function checkboxIncludeCompletedChanged(args) {
            //console.log(args)
            var Data = {
                BoardID: boardId,
                IncludeCompleted: $("#CheckboxIncludeCompleted").ejCheckBox("instance").option("checked")
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/FilterBoardView",
                dataType: "json",
                data: Data
            }).always(function (result) {
                if (result) {
                    //console.log(result );
                    $("#Sprints").ejGrid({
                       dataSource: result
                    });
                }
            });
       }
      function gridActionBegin(args) {
            if (args.requestType == "delete") {
                var id = args.data.ID;
                if (id) {
                    showKendoConfirm("Are you sure you want to delete \"" + args.data.Description + "\"?")
                        .done(function () {
                            var deleteData = {
                                SprintID: id,
                                IncludeCompleted: $("#CheckboxIncludeCompleted").ejCheckBox("instance").option("checked")
                            };
                            $.post({
                                url: window.appBase + "ProjectManagement/Agile/DeleteSprintBySprintID",
                                dataType: "json",
                                data: deleteData
                            }).always(function (result) {
                                if (result) {
                                    //console.log(result );
                                    //$("#Sprints").ejGrid({
                                    //   dataSource: result
                                    //});
                                }
                            });
                        })
                        .fail(function () {
                            args.cancel = true;
                        });
                } else {
                    args.cancel = true;
                }
            }
        }
         function viewDetailsClicked(args) {
            var grid = $("#Sprints").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            loadSprint(id);
        }
        function editClicked(args) {
            var grid = $("#Sprints").ejGrid("instance");
            var index = this.element.closest("tr").index();
            var record = grid.getCurrentViewData()[index];
            var id = grid.getCurrentViewData()[index].ID;
            var url = "@Html.Raw(ViewData("EditSprintURL"))/" + id;
            //console.log(url);
            $("#NewSprintDialog").ejDialog();
            $("#NewSprintDialog").ejDialog("destroy");
            $("#NewSprintDialog").ejDialog();
            $("#NewSprintDialog").ejDialog({
                title: "Edit Sprint",
                showOnInit: false,
                contentType: "iframe",
                contentUrl: url,
                height: 600
            });
            $("#NewSprintDialog").ejDialog("open");
        }
        function deleteClicked(args) {
            //var grid = $("#Sprints").ejGrid("instance");
            //var index = this.element.closest("tr").index();
            //var record = grid.getCurrentViewData()[index];
            //var id = grid.getCurrentViewData()[index].ID;
            //if (id) {
            //    showKendoConfirm("Delete \"" + grid.getCurrentViewData()[index].Description + "\"?")
            //        .done(function () {
            //            var deleteData = {
            //                SprintID: id,
            //                IncludeCompleted: $("#CheckboxIncludeCompleted").ejCheckBox("instance").option("checked")
            //            };
            //            $.post({
            //                url: window.appBase + "ProjectManagement/Agile/DeleteSprintBySprintID",
            //                dataType: "json",
            //                data: deleteData
            //            }).always(function (result) {
            //                if (result) {
            //                    //console.log(result );
            //                    //$("#Sprints").ejGrid({
            //                    //   dataSource: result
            //                    //});
            //                }
            //            });
            //        })
            //        .fail(function () {
            //        });
            //}
        }
        function gridRowSelected(args) {
            //console.log(args.data.ID)
            //console.log(args);
            loadSprint(args.data.ID);
        }
        function loadSprint(sprintId) {
            if (sprintId) {
                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Sprint/" + sprintId;
                window.location.assign(url);
                //OpenRadWindow("Project Board", url);
            }
        }
   </script> 
</div>
<div style="margin: 10px 0px 0px 0px;">
    @Code
        If Model.Orphans IsNot Nothing AndAlso Model.Orphans.Count > 0 Then

            Dim OrphanGrid = Html.EJ().Grid(Of Webvantage.Controllers.ProjectManagement.AgileController.SimpleOrphan)("Orphans")
            OrphanGrid.Datasource(Model.Orphans)
            OrphanGrid.EditSettings(Sub(Edit)
                                    End Sub)
            OrphanGrid.AllowMultiSorting(True)
            OrphanGrid.AllowSelection(False)
            OrphanGrid.AllowSorting(True)
            OrphanGrid.AllowTextWrap(True)
            OrphanGrid.SelectionType(SelectionType.Single)
            OrphanGrid.EnableToolbarItems(False)
            OrphanGrid.Columns(Sub(Column)
                                   'Column.Field("ID").Visible(False).IsPrimaryKey(True).Add()
                                   Column.Field("Description").HeaderText("Assignments Awaiting a Sprint").EditType(EditingType.StringEdit).HeaderTooltip("Create a sprint to capture assignments awaiting a sprint").Add()
                               End Sub)
            OrphanGrid.ToolbarSettings(Sub(Toolbar)
                                       End Sub)
            OrphanGrid.ClientSideEvents(Sub(Events)
                                        End Sub)
            OrphanGrid.Render()

        End If
    End Code
</div>
