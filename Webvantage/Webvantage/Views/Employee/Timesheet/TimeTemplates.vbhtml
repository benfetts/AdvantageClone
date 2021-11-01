@ModelType Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)
@Code
    ViewData("Title") = "Time Templates"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code
<style>
</style>
<div>
    <div id="gridToolBarWrap">
        <script>    
            var employeeCode = "";
            employeeCode = "@Html.Raw(ViewData("EmployeeCode"))";
            function newClick() {
                $("#TimeTemplatesDialog").ejDialog();
                $("#TimeTemplatesDialog").ejDialog("destroy");
                $("#TimeTemplatesDialog").ejDialog();
                var url = window.appBase + "Timesheet_Template_Add.aspx?emp=" + employeeCode;
                var dialog = $('#TimeTemplatesDialog').ejDialog({
                    contentType: 'iframe',
                    contentUrl: url,
                    title: 'Time Template',
                    height: 600,
                    width: 600
                });
                $("#TimeTemplatesDialog").ejDialog("refresh");
                $("#TimeTemplatesDialog").ejDialog("open");
            }
            function refreshClick() {
                //console.log("refreshClick");
            }
       </script>
        @Code

            Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
            TopToolBar.Items(Sub(items)
                                 items.Add().Id("NewTimeTemplateToolBarItem").Type(CommandType.Button).Click("newClick").Text("<span class='wvi wvi-navigate-plus'></span>").HtmlAttributes(New With {.title = "Add new time template", .class = "wv-icon-button wv-add-new"})
                                 items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .class = "wv-icon-button wv-neutral"}).Text("<span class='wvi wvi-rotate-right'></span>").Click("refreshClick")
                             End Sub
            )
            TopToolBar.Events(Sub(e)
                              End Sub)
            TopToolBar.Render()
        End Code
    </div>
    <div id="time-templates-grid-container" style="margin: 10px 0px 0px 0px;">
        @Html.Partial("_TimeTemplatesGrid", Model)
    </div>
</div>
<div id="TimeTemplatesDialog"></div>
