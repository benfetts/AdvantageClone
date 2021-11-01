@Code

    ViewData("Title") = "Epics"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code
@Section PageScripts

    <script src="~/JScripts/validator.js" type="text/javascript"></script>
    <script type="text/javascript" src="~/JScripts/agile.mvc.js"></script>

End Section
<div id="gridToolBarWrap">
    <script>
        function reloadWindow (){
            location.reload();
        }
         function goBack (){
            window.history.back();
        }
    </script>
    @Code
    Dim TopToolBar = Html.Kendo().ToolBar.Name("TopToolBar")
    TopToolBar.Items(
        Sub(items)
            items.Add().Id("RefreshToolBarItem").Text("").Type(CommandType.Button).HtmlAttributes(New With {.title = "Refresh", .style = "width:35px;"}).Icon("refresh").Click("reloadWindow")
            items.Add().Type(CommandType.Button).Click("goBack").Text("<span class='glyphicon glyphicon-arrow-left'></span>").HtmlAttributes(New With {.title = "Go Back"})
        End Sub
)
    TopToolBar.Events(
Sub(e)

End Sub)
    TopToolBar.Render()
    End Code
</div>
