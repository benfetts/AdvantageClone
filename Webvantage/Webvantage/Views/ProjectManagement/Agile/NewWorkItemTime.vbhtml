@Modeltype AdvantageFramework.ViewModels.ProjectManagement.Agile.AlertTimeEntryViewModel
@Code

    ViewData("Title") = "Add Time"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<script>
</script>
<div class="form-horizontal;">
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <div style="font-weight:bold; color: #333333; font-size:14px;">
                    @Html.Raw(Model.Title)
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 130px;">
                <div class="form-group">
                    <div>
                        Date:
                    </div>
                    <div>
                        @(Html.Kendo.DatePickerFor(Function(Model) Model.Date).Format("d").Name("StartDate").HtmlAttributes(New With {.style = "width: 125px;", .tabindex = 1, .data_shortdate = ""}))
                    </div>
                </div>
            </td>
            <td>
                <div class="form-group">
                    <div>
                        Function:
                    </div>
                    <div>
                        @Html.EJ().DropDownList("FunctionCodes").Datasource(Model.Functions).DropDownListFields(Function(F)
                                                                                                                    Return F.Value("Code").Text("Description")
                                                                                                                End Function).Value(Model.EmployeeDefaultFunctionCode).EnableFilterSearch(True).FilterType(SearchFilterType.Contains).Width("100%")
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="form-group">
                    <div>
                        Hours:
                    </div>
                    <div>
                        @(Html.Kendo.NumericTextBoxFor(Function(Model) Model.Hours).Name("Hours").HtmlAttributes(New With {.style = "width: 100px;", .tabindex = 3, .onfocus = "this.select()"}).Min(0).Max(24).Step(0.25))
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="form-group">
                    <div>
                        Comment:
                    </div>
                    <div>
                        @Html.TextArea("Comment", Model.Comment, New With {.class = "e-textbox", .style = "width: 100%; height: 80px;", .tabindex = 4})
                    </div>
                </div>
            </td>
        </tr>
    </table>
    <div style="margin: 10px 0px 0px 6px; display:block;">
        <button id="ButtonSave" class="k-button k-primary" onclick="buttonSaveClick();" tabindex="5">Save</button>
        <button id="ButtonCancel" class="k-button" onclick="buttonCancelClick();" tabindex="6">Cancel</button>
    </div>
</div>
<script>
    var commentRequired = @Html.Raw(Model.CommentRequired.ToString.ToLower)
    function setCommentRequired() {


    }
    function buttonSaveClick() {
        var alertId = @Html.Raw(Model.AlertID);
        var entryDate = $("#StartDate")[0].value;
        var functionCode = $("#FunctionCodes")[0].value;
        var hours = $("#Hours").val();
        var comment = $("#Comment").val();
        var data = {
            AlertID: alertId * 1,
            EntryDate: entryDate,
            FunctionCode: functionCode,
            Hours: hours * 1,
            Comment: comment
        };
        //console.log(data)
        comment = $.trim(comment);
        if (commentRequired == true && comment == ""){
            showKendoAlert("Please enter a comment");
            return false;
        } 
        if (!entryDate || entryDate == "") {
            showKendoAlert("Plesae select a date");
            return false;
        }
        //if (!hours || isNaN(hours) == true || hours * 1 == 0) {
        //    showKendoAlert("Please enter hours");
        //    return false;
        //}
        $.post({
            url: window.appBase + "ProjectManagement/Agile/SaveHoursToAlert",
            dataType: "json",
            data: data
        }).always(function (response) {
            if (response) {
                //console.log(response);
                if (response.Success && response.Success === true) {
                    clear();
                    var parentDoc = window.parent
                    parentDoc.closeAddWorkItemTimeDialog();
                }
                if (response.Success && response.Success === false && response.Message) {
                    showKendoAlert(response.Message);
                }
            }
            });

    }
    function buttonCancelClick() {
        clear();
        var parentDoc = window.parent
        parentDoc.closeAddWorkItemTimeDialog();
    }
    function clear() {
        $("#StartDate")[0].value = null;
        $("#FunctionCodes")[0].value = null;
        $("#Hours").val(null);
        $("#Comment").val(null);
    }
    $(function () {

        if (commentRequired == true) {
            $("#Comment").addClass("RequiredInput");
        }


    });

</script>
