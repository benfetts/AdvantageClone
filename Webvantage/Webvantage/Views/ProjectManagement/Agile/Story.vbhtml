@ModelType  AdvantageFramework.Database.Entities.SprintHeader
@Code

    ViewData("Title") = "Story"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script type="text/javascript" src="~/JScripts/validator.js"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<style>



</style>
<script>



</script>
@Using (Ajax.BeginForm("SaveNewSprintHeader", New With {.SprintID = Model.ID, .JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber},
                                              New AjaxOptions() With {.HttpMethod = "POST"}, New With {.id = "DetailsForm"}))

    @<div id="sprintHeader" style="width:100%;">
        <h3>Board</h3>
        <div style="width:100%;">
            <div>
                @(Html.TextAreaFor(Function(m) m.Description, New With {.class = "k-textbox", .style = "height: 80px; width: 100%; resize: vertical !important;"}))
            </div>
            <div style="margin: 6px 0px 0px 0px;">
                <table>
                    <tr>
                        <td style="">
                            Start:
                        </td>
                        <td style="padding: 0px 0px 0px 6px;">
                            End:
                        </td>
                        <td style="padding: 0px 0px 0px 10px;">
                            Weeks:
                        </td>
                    </tr>
                    <tr>
                        <td style="">
                            @(Html.Kendo.DatePickerFor(Function(m) m.StartDate).Format("d").HtmlAttributes(New With {.style = "width: 125px;", .data_shortdate = ""}))
                        </td>
                        <td style="padding: 0px 0px 0px 6px;">
                        </td>
                        <td style="padding: 0px 0px 0px 10px;">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div style="width:100%; text-align:left; margin: 6px 0px 0px 0px;">
            <input type="submit" id="saveHeaderButton" value="Save" />
        </div>

    </div>

End Using

