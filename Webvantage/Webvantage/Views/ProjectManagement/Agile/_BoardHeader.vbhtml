@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner
<style>
    td {
        padding: 6px;
        vertical-align: top;
    }
</style>
<table style="width: 100%; margin: 10px 0px 0px 0px;">
    <colgroup>
        <col style="width:0%; padding: 6px; vertical-align:top;" />
    </colgroup>
    <tr>
        <td>
            <div style="width:100%;">
                <div>
                    Name:
                </div>
                <div>
                    @Html.TextBox("BoardName", Model.Header.Name, New With {.class = "e-textbox required", .style = "width: 100%;"})
                </div>
            </div>
            <div style="width:100%;">
                <div>
                    Description:
                </div>
                <div>
                    @Html.TextArea("BoardDescription", Model.Header.Description, New With {.class = "e-textbox", .style = "width: 100%; height: 80px;"})
                </div>
            </div>
            <div>
                Workflow Template:
            </div>
            <div>
                @Html.EJ().DropDownList("AssignmentTemplates").Width("100%").Datasource(DirectCast(Model.AssignmentTemplates,
                                                                                                       Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.BoardDesigner.AssignmentTemplate))).DropDownListFields(Function(F) F.Value("ID").Text("Name")).SelectedIndex(Model.SelectedTemplateIdIndex).ReadOnly(Model.HeaderHasTemplate)
            </div>
            <div>
                <div style="display:inline-block;">
                    @Html.EJ().CheckBox("CheckboxSequential").Value("IsSequential").Size(Size.Medium).Checked(Model.Header.IsSequential)
                    Must move in sequence
                </div>
                <div style="display:inline-block;">
                    @Html.EJ().CheckBox("CheckboxForceAllColumns").Value("ForceAllColumns").Size(Size.Medium).Checked(Model.Header.ForceAllColumns)
                    Must hit all columns
                </div>
            </div>
        </td>
    </tr>
</table>
<div style="margin-top: 10px;display:block;">
    <button id="ButtonSaveBoard" class="k-button k-primary" onclick="buttonSaveBoardClick();">Save</button>
</div>
<script type="text/javascript">
        function buttonSaveBoardClick(e, ui) {
            var assignmentTemplateId = $("#AssignmentTemplates")[0].value;
            var boardName = $("#BoardName").val();
            var boardDescription = $("#BoardDescription").val();
            var isSequential = $("#CheckboxSequential").ejCheckBox("instance").option("checked");
            var forceAllColumns = $("#CheckboxForceAllColumns").ejCheckBox("instance").option("checked");
            if (boardName == ""){
                showKendoAlert("Please enter a board name")
            } else {
                var data = {
                    AssignmentTemplateID: assignmentTemplateId,
                    BoardName: boardName,
                    BoardDescription: boardDescription,
                    IsSequential: isSequential,
                    ForceAllColumns: forceAllColumns
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
</script>
