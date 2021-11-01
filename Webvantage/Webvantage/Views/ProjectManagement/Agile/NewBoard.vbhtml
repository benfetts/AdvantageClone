@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner
@Code

    ViewData("Title") = "New Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
<style>
    td {
        padding: 6px;
        vertical-align: top;
    }
</style>
<table id="headerTable" style="width: 100%; margin: 10px 0px 0px 0px;">
    <colgroup>
        <col style="width:0%; padding: 6px; vertical-align:top;" >
    </colgroup>
    <tr>
        <td>

            <div class="form-group" style="width:100%;">
                <div>
                    Name:
                </div>
                <div>
                    @Html.TextBox("BoardName", Model.Header.Name, New With {.class = "e-textbox RequiredInput", .style = "width: 100%;"})
                </div>
            </div>
            <div class="form-group" style="width:100%;">
                <div>
                    Description:
                </div>
                <div>
                    @Html.TextArea("BoardDescription", Model.Header.Description, New With {.class = "e-textbox", .style = "width: 100%; height: 80px;"})
                </div>
            </div>
            <div class="form-group" style="width:100%;">
                <div>
                    Workflow Template:
                </div>
                <div>
                    @Html.EJ().DropDownList("AssignmentTemplates").Width("100%").Datasource(DirectCast(Model.AssignmentTemplates,
                                                                           Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.AssignmentTemplate))).ClientSideEvents(Sub(events)
                                                                                                                                                                                                       events.Change("assignmentTemplatesChange")
                                                                                                                                                                                                   End Sub).DropDownListFields(Function(F) F.Value("ID").Text("Name")).SelectedIndex(Model.SelectedTemplateIdIndex).ReadOnly(Model.HeaderHasTemplate)
                </div>
            </div>
            <div id="DivBoardOptions" class="form-group" style="width:100%; display:none !important;">
                <div style="display:inline-block;">
                    @Html.EJ().CheckBox("CheckboxSequential").Value("IsSequential").Size(Size.Medium).Checked(Model.Header.IsSequential)
                    Must move in sequence
                </div>
                <div style="display:inline-block;">
                    @Html.EJ().CheckBox("CheckboxForceAllColumns").Value("ForceAllColumns").Size(Size.Medium).Checked(Model.Header.ForceAllColumns)
                    Must hit all columns
                </div>
                <div style="display:inline-block; margin: 0px 0px 0px 6px;">
                    @Html.EJ().CheckBox("CheckboxIsActive").Value("IsActive").Size(Size.Medium).Checked(True)
                    Active
                </div>
            </div>
            <div class="form-group" style="width:100%;">
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
<div style="margin: 10px 0px 0px 6px; display:block; width: 100%; text-align: right;">
    <button id="ButtonSaveBoard" class="k-button k-primary" onclick="buttonSaveBoardClick();">Add</button>
    <button id="ButtonCancel" class="k-button" onclick="cancelClick();">Cancel</button>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#BoardName').focus();
    });

    function cancelClick() {
        window.parent.closeDialogs();
    }
    function buttonSaveBoardClick(e, ui) {
        var assignmentTemplateId = $("#AssignmentTemplates")[0].value;
        var boardName = $("#BoardName").val();
        var boardDescription = $("#BoardDescription").val();
        var isSequential = $("#CheckboxSequential").ejCheckBox("instance").option("checked");
        var forceAllColumns = $("#CheckboxForceAllColumns").ejCheckBox("instance").option("checked");
        var isActive = $("#CheckboxIsActive").ejCheckBox("instance").option("checked");
        var trackChanges = $("#CheckboxTrackChanges").ejCheckBox("instance").option("checked");
        var emailOnChange = $("#CheckboxEmailOnChange").ejCheckBox("instance").option("checked");
        if (boardName == ""){
            showKendoAlert("Please enter a board name")
        } else {
            var data = {
                AssignmentTemplateID: assignmentTemplateId,
                BoardName: boardName,
                BoardDescription: boardDescription,
                IsSequential: isSequential,
                ForceAllColumns: forceAllColumns,
                IsActive: isActive,
                TrackChanges: trackChanges,
                EmailOnChange: emailOnChange
            };
            $.post({
                url: window.appBase + "ProjectManagement/Agile/AddBoardHeader",
                dataType: "json",
                data: data
            }).always(function (response) {
                if (response) {
                   //console.log(response);
                    if (response.Success && response.Success === true) {
                        var parentDoc = window.parent
                        parentDoc.boardHeaderAdded(response.Data.BoardHeaderID);
                    }
                    if (response.Success && response.Success === false && response.Message) {
                        alert ("Error in action: CreateProjectBoard" + "\n" + response.Message);
                    }
                }
            });
        }
    }
        function assignmentTemplatesChange(args) {
            if (args.selectedText == "Basic Board") {
                optionsVisible(false);
            } else {
                optionsVisible(true);
            }
        }
        function optionsVisible(isVisible) {
            //if (isVisible == true) {
            //    $("#DivBoardOptions").show();
            //} else {
            //    $("#DivBoardOptions").hide();
            //}
            $("#CheckboxSequential").ejCheckBox({ enabled: isVisible });
            $("#CheckboxForceAllColumns").ejCheckBox({ enabled: isVisible });
            if (isVisible == false) {
                $("#CheckboxSequential").ejCheckBox({ checked: isVisible });
                $("#CheckboxForceAllColumns").ejCheckBox({ checked: isVisible });
            }
        }
        $(function () {
            $("#headerTable").keyup(function (event) {
                if (event.keyCode === 13) {
                    $("#ButtonSaveBoard").click();
                }
            });
        });
</script>
