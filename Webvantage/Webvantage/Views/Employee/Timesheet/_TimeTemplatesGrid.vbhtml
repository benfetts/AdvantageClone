@ModelType Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)
    @Code
        If Model.Count > 0 Then

            Dim GridBuilder = Html.EJ().Grid(Of AdvantageFramework.Database.Entities.EmployeeTimeTemplate)("TimeTemplatesGrid")
            GridBuilder.Datasource(Model)
            GridBuilder.AllowMultiSorting(True)
            GridBuilder.AllowSelection(False)
            GridBuilder.AllowSorting(True)
            GridBuilder.AllowTextWrap(True)
            GridBuilder.EnableToolbarItems(False)
            GridBuilder.SelectionType(SelectionType.Single)
            GridBuilder.EditSettings(Sub(Edit)
                                     End Sub)
            GridBuilder.ToolbarSettings(Sub(Toolbar)
                                        End Sub)
            GridBuilder.ClientSideEvents(Sub(Events)
                                             Events.RowSelected("timeTemplatesGridRowSelected")
                                             Events.DataBound("timeTemplatesGridDataBound")
                                         End Sub)
            GridBuilder.Columns(Sub(Column)
                                    Column.Field("EmployeeTimeTemplateID").Visible(False).IsPrimaryKey(True).Add()
                                    Column.Field("FunctionCategoryDescription").HeaderText("Description").EditType(EditingType.StringEdit).Add()
                                    Column.Field("Hours").HeaderText("Hours").EditType(EditingType.NumericEdit).TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(70).Visible(True).Add()
                                    Column.Field("Comment").HeaderText("Comment").EditType(EditingType.StringEdit).Add()
                                    'Column.Field("CreatedDate").HeaderText("Created").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Format("{0:d}").Width(150).Add()
                                    'Column.Field("CreatedByUserCode").HeaderText("By").TextAlign(Syncfusion.JavaScript.TextAlign.Right).Width(100).Add()
                                    'Column.Field("BoardOwnerFullName").HeaderText("Owner").EditType(EditingType.StringEdit).Add()
                                    'Column.Field("OfficeName").HeaderText("Office").EditType(EditingType.StringEdit).Add()
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
                                                                                                                            .PrefixIcon = "wvi wvi-delete",
                                                                                                                            .HtmlAttributes = New Dictionary(Of String, Object) From {{"title", "Delete"}},
                                                                                                                            .Click = "deleteClicked"}).Add()
                                                                   End Sub).Width("145px").Visible(True).Add()
                                End Sub)
            GridBuilder.Render()

        Else

                @Html.Raw("No time templates")

        End If
    End Code
    <script>
        function viewDetailsClicked(args) {
            //var grid = $("#BoardsGrid").ejGrid("instance");
            //var index = this.element.closest("tr").index();
            //var record = grid.getCurrentViewData()[index];
            //var id = grid.getCurrentViewData()[index].ID;
            //var name = grid.getCurrentViewData()[index].Name;
            ////console.log(grid.getCurrentViewData()[index])
            //loadBoard(id, name);
        }
        function editClicked(args) {
            @*var grid = $("#BoardsGrid").ejGrid("instance");
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
            }*@
        }
        function deleteClicked(args) {
            //var grid = $("#BoardsGrid").ejGrid("instance");
            //var index = this.element.closest("tr").index();
            //var record = grid.getCurrentViewData()[index];
            //var id = grid.getCurrentViewData()[index].ID;
            //var confirmMessage = "";
            //var sprintCount = grid.getCurrentViewData()[index].SprintCount * 1;
            //var boardName = grid.getCurrentViewData()[index].Name;
            //if (sprintCount && sprintCount > 0) {
            //    if (sprintCount == 1) {
            //        confirmMessage = "There is one sprint on the " + "\"" + grid.getCurrentViewData()[index].Name + "\" board.\nAre you sure you want to delete?";
            //    }
            //    if (sprintCount > 1) {
            //        confirmMessage = "There are " + sprintCount + " sprints on the " + "\"" + grid.getCurrentViewData()[index].Name + "\" board.\nAre you sure you want to delete?";
            //    }
            //} else {
            //    confirmMessage = "Are you sure you want to delete the \"" + grid.getCurrentViewData()[index].Name + "\" board?"
            //}
            //if (id) {
            //    showKendoConfirm(confirmMessage)
            //        .done(function () {
            //            var deleteData = {
            //                BoardID: id
            //            };
            //            $.post({
            //                url: window.appBase + "ProjectManagement/Agile/DeleteAgileBoard",
            //                dataType: "json",
            //                data: deleteData
            //            }).always(function (result) {
            //                if (result ) {
            //                   //console.log(result );
            //                    $("#BoardsGrid").ejGrid({
            //                        dataSource: result
            //                    });
            //                }
            //            });
            //        })
            //        .fail(function () {
            //        });
            //}
        }
        function timeTemplatesGridRowSelected(args) {

        }
        function gridRowSelected(args) {
            var id = args.data.ID;
        }
        function timeTemplatesGridDataBound(args) {
        //   //console.log(args)
        }
        function closeDialogs() {
            closeNewTimeTemplateDialog();
        }
        function closeNewTimeTemplateDialog() {
            if ($("#NewBoardDialog").data() && $("#NewBoardDialog").data('ejDialog')) {
                $("#NewBoardDialog").ejDialog("close");
            }
        }
        $(document).ready(function () {
        });
    </script>

