@ModelType AdvantageFramework.ProjectManagement.Agile.Classes.ProjectBoard
@Code

    ViewData("Title") = "Employee Board"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<div id="ControlRegion" style="margin-top: 10px;">
    @Html.Partial("_Board", Model)
</div>