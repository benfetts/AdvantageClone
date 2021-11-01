@ModelType Webvantage.ViewModels.AureliaModel
@Code

    Layout = Nothing '"~/Views/Shared/_LayoutPageBase.vbhtml"

    Dim Title As String = ""
    If Not String.IsNullOrWhiteSpace(ViewBag.Title) Then

        Title = ViewBag.Title


    End If

End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>@Title</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <script type="text/javascript" src="@Url.Content("~/Scripts/darkreader.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Jscripts/ChildPage.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/JScripts/common.js")"></script>
    <script>
    @If Me.IsDarkMode = True Then
@<text>enableDarkMode();</text>End If
    </script>
    @Styles.Render("~/Content/kendo/current/css")
    @Styles.Render("~/Content/ej/web/bootstrap-theme/ej.web.all.min.css")

    <link href="@Url.Content("~/CSS/wv-icons.css")" rel="stylesheet" type="text/css" />

    @Styles.Render("~/theme/site")

    <link href="@Url.Content("~/CSS/Material/" & Me.CssFile)" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/CSS/app.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/Common.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/CardLayout.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/CardLayout.Colors.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/prism.css")" rel="stylesheet" type="text/css">

    <script type="text/javascript" src="@Url.Content("~/Jscripts/aurelia-bridge.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/jquery-3.6.0.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/bootstrap.js")"></script>

    @Scripts.Render("~/bundles/kendo")
    @Scripts.Render("~/Scripts/ej/ej.web.all.min.js")
    @Scripts.Render("~/Scripts/jsrender.min.js")
    @Scripts.Render("~/Scripts/jszip.min.js")

    <script type="text/javascript" src="~/Scripts/kendo/cultures/kendo.culture.@(Html.Raw(Me.Locale)).min.js"></script>

    <script type="text/javascript">
        kendo.culture("@Me.Locale");
        $(document).ready(function () {
        });
    </script>
    <style type="text/css">
        .e-textbox {
            border-color: #CCCCCC !important;
        }
        .e-textbox:hover {
            border-color: #AEAEAE !important;
        }
    </style>
</head>

  <body aurelia-app="main">
    <base-app app.bind="App" view-model.bind="Parameters"></base-app>
    <script>

      var modelBinder = function() {
        return @Html.Raw(Json.Encode(Model));
      };

      if(HTMLDocument){
        HTMLDocument.prototype.modelBinder = modelBinder;
      } else if(Document){
        Document.prototype.modelBinder = modelBinder;
      }

    </script>
    <script src="scripts/vendor-bundle.js" data-main="aurelia-bootstrapper"></script>
      
    @Code
        @Html.EJ().ScriptManager()
    End Code

      <script>
          if (!String.prototype.padStart) {
              String.prototype.padStart = function (max, fillString) {
                  return padStart(this, max, fillString);
              }
          }
          function padStart(text, max, mask) {
              const cur = text.length;
              if (max <= cur) {
                  return text;
              }
              const masked = max - cur;
              let filler = String(mask) || ' ';
              while (filler.length < masked) {
                  filler += filler;
              }
              const fillerSlice = filler.slice(0, masked);
              return fillerSlice + text;
          }
      </script>

  </body>

 

</html>

