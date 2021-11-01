@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
@Code

    ViewData("Title") = "Project Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section


<style>
    .container-table {
        width: 100%;
    }

    .left-cell {
        width: 200px;
    }

    .right-cell {
    }
</style>
<div id="gridToolBarWrap">
    @Code
        Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
        TopToolBar.Items(
            Sub(items)
                'items.Add().Id("SaveButton").Type(CommandType.Button).Click("saveSprint").Text("<span class='glyphicon glyphicon-floppy-disk'></span>").HtmlAttributes(New With {.title = "Save Sprint"})
                items.Add().Type(CommandType.Separator)
                items.Add().Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .style = "width:35px;"}).Icon("refresh").Click("reloadWindow")
                items.Add().Type(CommandType.Button).Click("goBack").Text("<span class='glyphicon glyphicon-arrow-left'></span>").HtmlAttributes(New With {.title = "Go Back"})
            End Sub
)
        TopToolBar.Events(
    Sub(e)

    End Sub)
        TopToolBar.Render()


    End Code
    <script>
        function saveSprint(){
            document.getElementById("saveHeaderButton").click();
        }
        function reloadWindow(){
            location.reload();
        }
        function goBack (){
            var boardId = 0;
            boardId = @Html.Raw(Model.Board.ID)
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)AgileBoard/" + boardId;
            window.location.assign(url);
            //window.history.back();
        }
        function completeSprint (){
            $("#CompleteSprintDialog").ejDialog("open");
        }
    </script>
</div>
@Using (Ajax.BeginForm("SaveSprintHeader", New With {.SprintID = Model.SprintHeaderID, .JobNumber = Model.JobNumber,
                                  .JobComponentNumber = Model.JobComponentNumber}, New AjaxOptions() With {.HttpMethod = "POST"}, New With {.id = "DetailsForm"}))
@<div id = "sprintHeader" style="width:100%; display: none;">
    <div style = "width:100%;" >
        <div style="margin: 8px 0px 0px 0px;">
            @(Html.TextAreaFor(Function(m) m.SprintHeader.Description, New With {.class = "k-textbox", .style = "height: 80px; width: 100%; resize: vertical !important;"}))
        </div>
        <div style="margin: 12px 0px 0px 0px;">
            <table>
                <tr>
                    <td style="">
                        Week Starting:
                    </td>
                    <td style="padding: 0px 0px 0px 10px;">
                        Duration:
                    </td>
                </tr>
                <tr>
                    <td style="">
                        @(Html.Kendo.DatePickerFor(Function(m) m.SprintHeader.StartDate).Format("d").HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                    </td>
                    <td style="padding: 0px 0px 0px 10px;">
                        @Html.TextBox("NumberOfWeeks", Model.SprintHeader.NumberOfWeeks, New With {.class = "e-textbox", .style = "width:45px;"}) week(s)
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div  class="form-group"style = "width:100%; text-align:left; margin: 6px 0px 0px 0px; display:none;" >
        <input type="submit" id="saveHeaderButton" value="Save" />
    </div>
</div>
End Using
@Code
    Dim CompleteSprintDialog = Html.EJ().Dialog("CompleteSprintDialog")
    CompleteSprintDialog.Title("Complete Sprint?")
    CompleteSprintDialog.ShowOnInit(False)
    CompleteSprintDialog.ContentTemplate(Sub()
                                             @<div>
                                                  <div>
                                                      @Html.EJ().CheckBox("CheckBoxBackToBacklog").Value("BackToBacklog")&nbsp;&nbsp;Put In Progress items back to Backlog
                                                  </div>
                                                  <div style="margin-top: 4px;">
                                                      @Html.EJ().CheckBox("CheckBoxLeaveInState").Value("LeaveInCurrentState")&nbsp;&nbsp;Leave In Progress items in current State
                                                  </div>
                                                  <div style="margin-top: 10px; margin-bottom: 10px;">
                                                      <button id="ButtonSave" class="k-button k-primary" onclick="saveComplete();">Save</button>
                                                      <button id="ButtonCancel" class="k-button" onclick="cancelComplete();">Cancel</button>
                                                  </div>
                                              </div>
                                         End Sub)
    CompleteSprintDialog.Render()
End Code
<script>
    function cancelComplete() {
        $("#CompleteSprintDialog").ejDialog("close");
    }
    function saveComplete() {
    }
</script>
<div id = "ControlRegion" style="margin-top: 12px;" >
    @Html.Partial("_Board", Model)
</div>
