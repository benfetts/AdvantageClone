@ModelType AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel
@Code
    ViewData("Title") = "Select Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
@Section PageScripts
    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>
End Section
<div id="ScheduleForm" class="form-horizontal" style="margin: 12px 0px 0px 0px;">
    <div class="form-group">
        <div style="position: relative;">
            Board
        </div>
        <table style="width: 100%;">
            <tr>
                <td>
                    @Html.EJ().DropDownList("Boards").Width("100%").Datasource(DirectCast(Model.AvailableBoards,
                                                                                         Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Agile.SelectBoardViewModel.AvailableBoard))).DropDownListFields(Function(F) F.Value("ID").Text("Name")).SelectedIndex(0)
                </td>
                <td style="width: 30px; padding-left: 10px; display: none !important;">
                    <a href="#" id="editboardlink" onclick="editBoard();" title="Edit board" display="none !important;">
                        <span class="glyphicon glyphicon-pencil" title="Edit board" style="cursor: pointer;"></span>
                    </a>
                </td>
            </tr>
        </table>
    </div>
    <div class="form-group" style="display:none !important;">
        <div style = "position: relative;" >
            Include
        </div>
        <div style = "position: relative;" >
            <div style="position: relative; display: inline-block;">
                @Html.EJ().RadioButton("RadioButtonTasksAndAssignments").Name("AllowedTypesRadioGroup").Size(RadioButtonSize.Small).Checked(False).Enabled(True).Text("Tasks and Assignments").Value(3)
            </div>
                <div style="position: relative; display: inline-block;">
                @Html.EJ().RadioButton("RadioButtonTasks").Name("AllowedTypesRadioGroup").Size(RadioButtonSize.Small).Checked(False).Enabled(True).Text("Tasks").Value(1)
            </div>
            <div style="position: relative; display: inline-block;">
                @Html.EJ().RadioButton("RadioButtonAssignments").Name("AllowedTypesRadioGroup").Size(RadioButtonSize.Small).Checked(False).Enabled(True).Text("Assignments").Value(2)
            </div>
        </div>
    </div>
    <div style="width:100%;">
        <div>
            <div style="position: relative;">
                Description
            </div>
            <textarea class="k-textbox RequiredInput" id="SprintDescription" name="SprintDescription" style="width: 100%; height: 80px;"></textarea>
        </div>
                <div style="margin: 6px 0px 0px 0px;">
                    <table>
                        <tr>
                            <td style="">
                        Week Starting:
                    </td>
                            <td style="padding: 0px 0px 0px 6px;">
                        Duration:
                    </td>
                            <td style="padding: 0px 0px 0px 10px;"></td>
                        </tr>
                        <tr>
                            <td style="">
                        @(Html.Kendo.DatePickerFor(Function(Model) Model.Header.StartDate).Format("d").Name("StartDate").HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                    </td>
                            <td style="padding: 0px 0px 0px 6px;">
                                <input type="text" class="k-textbox" id="Weeks" name="Weeks" style="width: 40px;" />&nbsp;&nbsp;Weeks
                    </td>
                            <td style="padding: 0px 0px 0px 10px;"></td>
                        </tr>
                    </table>
                        </div>
    </div>
    <div style="margin-top: 10px;display:block;">
        <button id="ButtonSelectBoard" class="k-button k-primary" onclick="buttonSelectBoardClick();">Save</button>
       <div style="display:none">
           <button id="ButtonBoardDesigner" class="k-button k-primary" onclick="openNewBoardDialog();">New Board</button>
        </div>
    </div>
</div>
@Code
    Dim NewBoardDialog = Html.EJ().Dialog("NewBoardDialog")
    NewBoardDialog.Title("New Board")
    NewBoardDialog.ShowOnInit(False)
    NewBoardDialog.ContentType("iframe")
    NewBoardDialog.ContentUrl(ViewData("NewBoardURL"))
    NewBoardDialog.Height("400px")
    NewBoardDialog.Render()
End Code

<script type="text/javascript">
    function editBoard() {
        var selectedBoardId = 0;
        selectedBoardId = $("#Boards")[0].value;
        if (selectedBoardId && isNaN(selectedBoardId) === false && selectedBoardId > 0) {
            var jobNumber = @Html.Raw(Model.JobNumber);
            var jobComponentNumber = @Html.Raw(Model.JobComponentNumber);
            var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Design/" + selectedBoardId + "/" + jobNumber + "/" + jobComponentNumber + "/SelectBoard";
            var parentDoc = window.parent
            parentDoc.goToURL(url);
        } else {
            showKendoAlert("Select a board to edit");
            return false;
        }
    }
    function boardHeaderAdded(boardHeaderID) {
        var jobNumber = @Html.Raw(Model.JobNumber);
        var jobComponentNumber = @Html.Raw(Model.JobComponentNumber);
        var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)Design/" + boardHeaderID + "/" + jobNumber + "/" + jobComponentNumber + "/SelectBoard";
        window.location = url;
    }
    function openNewBoardDialog(e, ui) {
        $("#NewBoardDialog").ejDialog("open");
    }
    function buttonSelectBoardClick(e, ui) {
        var selectedBoardId = $("#Boards")[0].value;

        if (selectedBoardId && isNaN(selectedBoardId) === false) {

            var jobNumber = @Html.Raw(Model.JobNumber);
            var jobComponentNumber = @Html.Raw(Model.JobComponentNumber);
            var description = $("#SprintDescription").val();
            var startDate = $("#StartDate")[0].value;
            var weeks = $("#Weeks").val();
            if ((jobNumber && isNaN(jobNumber) === false) && (jobComponentNumber && isNaN(jobComponentNumber) === false)) {
                var includeType = 3;
                if (description) {
                    var data = {
                        JobNumber: jobNumber,
                        JobComponentNumber: jobComponentNumber,
                        BoardID: selectedBoardId,
                        IncludeType: includeType,
                        StartDate: startDate,
                        Weeks: weeks,
                        Description: description
                    };
                    $.post({
                        url: window.appBase + "ProjectManagement/Agile/CreateProjectBoard",
                        dataType:  "json",
                        data: data
                    }).always(function (response) {
                        if (response) {
                           //console.log(response);
                            if (response.Success && response.Success === true) {
                                var url = window.appBase + "@Html.Raw(Webvantage.Controllers.ProjectManagement.AgileController.BaseRoute)ProjectBoard/" + response.Data.SprintID + "/" + jobNumber + "/" + jobComponentNumber + "/" + includeType;
                                var parentDoc = window.parent
                                parentDoc.goToURL(url);
                            }
                            if (response.Success && response.Success === false && response.Message) {
                                showKendoAlert("Error in action: buttonSelectBoardClick on SelectBoard view." + "\n" + response.Message);
                            }
                        }
                    });

                } else {
                    showKendoAlert("Please enter a description");
                }
            } else {
                showKendoAlert("Could not get job and/or component number");
            }
        } else {
            showKendoAlert("Please select a board");
        }
    }
</script>

