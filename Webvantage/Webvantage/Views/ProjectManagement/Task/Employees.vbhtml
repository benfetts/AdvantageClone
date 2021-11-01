@ModelType Webvantage.ViewModels.EmployeesViewModel
@Code

    ViewData("Title") = "Employees"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<div id="ControlRegion" style="padding: 10px 10px 10px 0px; height:100%; width:100%;">
    @Html.Partial("_Employees", Model)
</div>
