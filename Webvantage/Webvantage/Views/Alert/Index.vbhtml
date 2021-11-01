@ModelType Webvantage.Models.AlertModel
@Code
    ViewData("Title") = "View Alert"

    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code

<h3>
    Alert ID:  @Model.AlertID
</h3>
<div>
    @Html.Partial("_AlertDetailsPartialPage", Model)
</div>