@Code

    ViewData("Title") = "Employee"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<h4>
    EMPLOYEE FULL VIEW!
</h4>
<div id="ControlRegion">
    @Html.Partial("_Employee", Model)
</div>
