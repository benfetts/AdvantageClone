@ModelType AdvantageFramework.ProjectSchedule.Classes.Schedule
@Code

    ViewData("Title") = "Project Schedule - Quick Edit"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

    Dim FilterString As String = ""
    Dim StringBuilder As New System.Text.StringBuilder

    If Not Request.QueryString("Emp") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Emp=")
        StringBuilder.Append(Request.QueryString("Emp").ToString())

    End If

    If Not Request.QueryString("Task") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Task=")
        StringBuilder.Append(Request.QueryString("Task").ToString())

    End If

    If Not Request.QueryString("Role") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Role=")
        StringBuilder.Append(Request.QueryString("Role").ToString())

    End If

    If Not Request.QueryString("Cut") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Cut=")
        StringBuilder.Append(Request.QueryString("Cut").ToString())

    End If

    If Not Request.QueryString("Comp") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Comp=")
        StringBuilder.Append(Request.QueryString("Comp").ToString())

    End If

    If Not Request.QueryString("Pend") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Pend=")
        StringBuilder.Append(Request.QueryString("Pend").ToString())

    End If

    If Not Request.QueryString("Proj") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("Proj=")
        StringBuilder.Append(Request.QueryString("Proj").ToString())

    End If

    If Not Request.QueryString("P") = Nothing Then

        StringBuilder.Append("&")
        StringBuilder.Append("P=")
        StringBuilder.Append(Request.QueryString("P").ToString())

    End If

    FilterString = StringBuilder.ToString

End Code

<style>
    .k-content .form-horizontal .form-group {
        margin-left: 0;
        margin-right: 0;
    }
    
    body {
        margin-top: 10px;
    }
    .k-grid .k-header {
       display: none;
    }
</style>

<div id="ScheduleWrap">
    @Html.Partial("ScheduleGrid", Model)
</div>

<script>
    var filterString = ' @Html.Raw(FilterString)';
</script>

@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/projectschedule.mvc.js"></script>

End Section

