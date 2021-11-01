@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.Sprint
@Code

    ViewData("Title") = "New Sprint"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<style>
    td {
        padding: 6px;
        vertical-align: top;
    }
    .k-i-calendar {
        height: 32px !important;
    }
    .k-picker-wrap .k-input {
        height: 2.667em !important;
        line-height: 2.667em !important;
        min-height: 2.667em !important;
    }
    .k-picker-wrap {
        height: 2.667em !important;
    }
    .k-picker-wrap .k-select {
        height: 2.667em !important;
        min-height: 2.667em !important;
        line-height: 2.667em !important;
    }
</style>
<table style="width: 100%; margin: 10px 0px 0px 0px;">
    <colgroup>
        <col style="width:100%; padding: 6px; vertical-align:top;" />
    </colgroup>
    <tr>
        <td>
            <div class="form-group" style="width:100%;">
                <div>
                    Name:
                </div>
                <div>
                    @Html.TextBox("SprintName", Model.Header.Description, New With {.class = "e-textbox RequiredInput", .style = "width: 100%;"})
                </div>
            </div>
            <div Class="form-group" style="width:100%;">
                <div>
                    Description :
                </div>
                <div>
                    @Html.TextArea("SprintDescription", Model.Header.Comments, New With {.Class = "e-textbox", .style = "width: 100%; height: 80px;"})
                </div>
            </div>
            <div class="" style="width:100%; display: none;">
                <div>
                    Board :
                </div>
                <div>
                    @Html.EJ().DropDownList("Boards").Width("100%").Datasource(Model.Boards).DropDownListFields(Function(F)
                                                                                                                 Return F.Value("ID").Text("Name")
                                                                                                             End Function).Enabled(ViewData("Enabled"))
                </div>
            </div>
            <div class="form-group" style="width:100%;">
                <div style="display: inline-block;">
                    <div>
                        Week Starting:
                    </div>
                    <div>
                        @(Html.Kendo.DatePickerFor(Function(Model) Model.Header.StartDate).Format("d").Name("StartDate").HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}).Enable(ViewData("Enabled")))
                    </div>
                </div>
                <div style="display: inline-block; margin-left: 6px;">
                    <div>
                        Duration:
                    </div>
                    <div>
                        @(Html.Kendo.NumericTextBoxFor(Function(Model) Model.Header.NumberOfWeeks).Format("F1").Name("Weeks").HtmlAttributes(New With {.style = "width: 60px;"}).Min(1).Max(12).Step(1).Enable(ViewData("Enabled")))
                    </div>
                </div>
            </div>

            <div class="form-group" style="width:100%; display:none !important;">
                <div style="display:inline-block;" title="Automatically add a comment when a card is moved from column to column">
                    @Html.EJ().CheckBox("CheckboxTrackChanges").Value("TrackChanges").Size(Size.Medium).Checked(If(Model.Header.TrackChanges IsNot Nothing, Model.Header.TrackChanges, False))
                    Track Changes
                </div>
                <div style="display:inline-block;" title="Send email when card is moved from column to column and comment is automatically added">
                    @Html.EJ().CheckBox("CheckboxEmailOnChange").Value("EmailOnChange").Size(Size.Medium).Checked(If(Model.Header.EmailOnChange IsNot Nothing, Model.Header.EmailOnChange, False))
                    Email On Change
                </div>
            </div>

        </td>
    </tr>
</table>
<div class="k-button-group" style="margin: 10px 0px 0px 6px; display:block; width: 100%; text-align: right;">
    <button id="ButtonCancel" class="k-button" onclick="cancelClick();" style="margin: 0px !important;">Cancel</button>
    <button id="ButtonSaveSprint" class="k-button k-primary" onclick="buttonSaveSprintClick();" style="margin: -3px !important;"></button>
</div>
<script type="text/javascript">
    var boardID = 0;
    var sprintID = 0;
    var enabled = true;
    boardID = @Html.Raw(ViewData("BoardID"));
    sprintID = @Html.Raw(ViewData("SprintID"));
    enabled = @Html.Raw(ViewData("Enabled").ToString.ToLower);
    function cancelClick() {
        window.parent.closeDialogs();
    }

   function buttonSaveSprintClick(e, ui) {
        //console.log($("#Jobs").ejListBox("getCheckedItems"))
        if ($("#SprintName").val() == ""){
            showKendoAlert("Please enter a sprint name");
        } else {
            var startDate = $("#StartDate")[0].value;
            var weeks = $("#Weeks").val();
            var trackChanges = $("#CheckboxTrackChanges").ejCheckBox("instance").option("checked");
            var emailOnChange = $("#CheckboxEmailOnChange").ejCheckBox("instance").option("checked");
           //if ($("#Boards")[0].value && isNaN($("#Boards")[0].value) == false) {
            //    boardID = $("#Boards")[0].value * 1;
            //}
            if (isNaN(boardID) == false) {
                boardID = boardID * 1;
            }
            if (isNaN(boardID) == false) {
                sprintID = sprintID * 1;
            }
            if (sprintID && sprintID > 0) {
                var editSprintData = {
                    SprintID: sprintID,
                    SprintName:  $("#SprintName").val(),
                    SprintDescription: $("#SprintDescription").val(),
                    StartDate: startDate,
                    NumberOfWeeks: weeks,
                    BoardID: boardID,
                    TrackChanges: trackChanges,
                    EmailOnChange: emailOnChange
                };
               //console.log(editSprintData)
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/EditSprint",
                    dataType:  "json",
                    data: editSprintData
                }).always(function (response) {
                    if (response) {
                       //console.log(response);
                        if (response.Success && response.Success === true) {
                            var parentDoc = window.parent
                            parentDoc.goToURL(response.Data.SprintURL);
                            //parentDoc.reloadWindow();
                            //parentDoc.boardHeaderAdded(response.Data.BoardHeaderID);
                        }
                        if (response.Success && response.Success === false && response.Message) {
                            alert ("Error in action: CreateProjectBoard" + "\n" + response.Message);
                        }
                    }
                });
            } else {
                var newSprintData = {
                    SprintName:  $("#SprintName").val(),
                    SprintDescription: $("#SprintDescription").val(),
                    BoardID: boardID,
                    StartDate: startDate,
                    NumberOfWeeks: weeks,
                    TrackChanges: trackChanges,
                    EmailOnChange: emailOnChange
                };
                $.post({
                    url: window.appBase + "ProjectManagement/Agile/AddSprint",
                    dataType:  "json",
                    data: newSprintData
                }).always(function (response) {
                    if (response) {
                       //console.log(response);
                        if (response.Success && response.Success === true) {
                            var parentDoc = window.parent
                            parentDoc.goToURL(response.Data.SprintURL);
                            //parentDoc.reloadWindow();
                            //parentDoc.boardHeaderAdded(response.Data.BoardHeaderID);
                        }
                        if (response.Success && response.Success === false && response.Message) {
                            alert ("Error in action: CreateProjectBoard" + "\n" + response.Message);
                        }
                    }
                });

            }
        }
    }
    $(document).ready(function () {
        $('#BoardName').focus();
        if (enabled == false) {
            $("#SprintName").prop("readonly", true);
            $("#SprintDescription").prop("readonly", true);
            $("#ButtonSaveSprint").prop("disabled", true);
        }
        if (sprintID == 0) {
            $("#ButtonSaveSprint").html("Add")
        } else {
            $("#ButtonSaveSprint").html("Save")
        }
    })
</script>
