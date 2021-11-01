@Code       
	Dim LayoutClass As String = "container"
    If ViewData.ContainsKey("IsFullLayout") Then
        If ViewData("IsFullLayout") = True Then
            LayoutClass = "container-fluid"
        End If
    End If
End Code
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <title>@ViewData("Title")</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="~/favicon.ico" type="image/x-icon">
    @Styles.Render("~/Content/kendo/current/css")
    @Styles.Render("~/Content/ej/web/bootstrap-theme/ej.web.all.min.css")
    @Code If String.IsNullOrWhiteSpace(Me.CssFile) = False Then
	@<link href="~/CSS/Material/@Me.CssFile" rel="stylesheet" type="text/css" /> End If End Code
    <link href="@Url.Content("~/CSS/wv-icons.css")" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="@Url.Content("~/Scripts/jquery-3.6.0.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/kendo/current/jszip.min.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/darkreader.js")"></script>
    @Scripts.Render("~/JScripts/shared.mvc.min.js")
    @Code 
		Dim cUserTheme As New Webvantage.UserTheme(HttpContext.Current.Session("EmpCode"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("ConnString"))
        Try
            cUserTheme.Load()
        Catch ex As Exception
            cUserTheme = Nothing
        End Try
        If ViewData.ContainsKey("IsBootstrap") AndAlso ViewData.ContainsKey("IsBootstrap") = True Then
			@Styles.Render("~/theme/site") 
		Else
			If cUserTheme.Settings.TelerikTheme.Contains("Metro") Then
				@Styles.Render("~/theme/small") 
			Else
				@Styles.Render("~/theme/large") 
			End If
		End If
		Try
			@<script type="text/javascript">
				@If Me.IsDarkMode = True Then
					@<text>enableDarkMode();</text>
				End If
			</script> 
		Catch ex As Exception
		End Try 
	End Code
    <link href="@Url.Content("~/CSS/app.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/Common.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/CardLayout.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/CardLayout.Colors.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/prism.css")" rel="stylesheet" type="text/css">
    <link href="@Url.Content("~/CSS/site-new.css")" rel="stylesheet" type="text/css">
    <script type="text/javascript">
        window.appBase = @Html.Raw(HttpUtility.JavaScriptStringEncode(Url.Content("~/"), True));
        window.queryString = "@Html.Raw(Me.QueryString.ToString(False))";
        location.queryString = {};
        var s = "";
        s = location.search.substr(1);
        if (s.indexOf("&amp;") > -1) {
            s = s.replace(/&amp;/g, "&");
        }
        s.split("&").forEach(function (pair) {
            if (pair === "") return;
            var parts = pair.split("=");
            location.queryString[parts[0]] = parts[1] && decodeURIComponent(parts[1].replace(/\+/g, " "));
        });
        function getQueryString() {
            if (window.location.search) {
                //console.log("getQueryString location.queryString", location.queryString);
                return location.queryString;
            }
        }
        function getQueryStringJson() {
            if (window.location.search) {
                return JSON.stringify(location.queryString, null, 2);
            }
        }
    </script>
    <script type="text/javascript" src="@Url.Content("~/Jscripts/ChildPage.js")"></script>
    <script type="text/javascript" src="@Url.Content("~/Scripts/bootstrap.js")"></script>
    @Code 
		If ViewData.ContainsKey("IsAngular") Then
			If ViewData("IsAngular") = True Then
				@Scripts.Render("~/bundles/angularjs") 
			End If
		End If 
	End Code
    @Scripts.Render("~/bundles/kendo")
    <script type="text/javascript" src="~/Scripts/kendo/cultures/kendo.culture.@(Html.Raw(Me.Locale)).min.js"></script>
    <script type="text/javascript">
        kendo.culture("@Me.Locale");
        $(document).ready(function () {
            //enableDarkMode();
        });
        function kShortDateStringFromDatePicker(datepicker) {
            var val;
            try {
                var val2 = datepicker.value();
                if (!val2) {
                    if (datepicker) {
                        val2 = datepicker.element.val();
                        if (val2) {
                            val = kShortDateString(val2).value;
                        }
                    }
                }
            } catch (e) {
                //console.log("getDatePickerDate error", e);
            }
            return val;
        }
        function kShortDateString(value) {
            var isValid = false;
            var formats = ["MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy"];
            var parsedDate = kendo.parseDate(value);
            if (!parsedDate) {
                $.each(formats, function () {
                    parsedDate = kendo.parseDate(value, this);
                    if (parsedDate) {
                        return false;
                    }
                });
            };
            if (parsedDate) {
                parsedDate = kendo.toString(parsedDate, 'd');
                isValid = true;
            }
            return {
                isValid: isValid,
                value: parsedDate
            }
        }
        function parseTimesheetMessage(msg) {
            var success = true;
            var s = "";
            if (msg.indexOf("|") > -1) {
                if (msg.indexOf("SUCCESS") > -1) { success = true; }
                if (msg.indexOf("FAIL") > -1) { success = false; }
                try {
                    var parts = msg.split("|");
                    if (parts && parts.length > 0) {
                        s = parts[parts.length - 1];
                    }
                } catch (e) {
                    s = msg;
                }
            } else {
                s = msg;
            }
            return {
                success: success,
                message: s
            }
        }
        function checkForEstimateWarning(msg) {
            var hasWarning = false;
            var s = "";
            if (msg.indexOf("SUCCESS") > -1 && msg.indexOf("|") > -1) {
                try {
                    var parts = msg.split("|");
                    //console.log("PARTS", parts);
                    if (parts && parts.length > 0) {
                        if (parts[parts.length - 2] * 1 == -15) {
                            hasWarning = true;
                            s = parts[parts.length - 1];
                        }
                    }
                } catch (e) {
                    s = msg;
                }
            }
            return {
                hasWarning: hasWarning,
                message: s
            }
        }
        function gqsv(key) {
            return decodeURIComponent(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + encodeURIComponent(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
        }
        function gup(name) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(location.search);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        };

    </script>

    @RenderSection("HeaderScripts", required:=False)

    <style type="text/css">
        /*
            styles for kendo/bootstrap to play nice
        */
        *, :before, :after {
            -webkit-box-sizing: content-box;
            -moz-box-sizing: content-box;
            box-sizing: content-box;
        }

        /* set a border-box model only to elements that need it */

        .form-control, /* if this class is applied to a Kendo UI widget, its layout may change */
        .container,
        .container-fluid,
        .row,
        .col-xs-1, .col-sm-1, .col-md-1, .col-sm-1,
        .col-xs-2, .col-sm-2, .col-md-2, .col-sm-2,
        .col-xs-3, .col-sm-3, .col-md-3, .col-sm-3,
        .col-xs-4, .col-sm-4, .col-md-4, .col-sm-4,
        .col-xs-5, .col-sm-5, .col-md-5, .col-sm-5,
        .col-xs-6, .col-sm-6, .col-md-6, .col-sm-6,
        .col-xs-7, .col-sm-7, .col-md-7, .col-sm-7,
        .col-xs-8, .col-sm-8, .col-md-8, .col-sm-8,
        .col-xs-9, .col-sm-9, .col-md-9, .col-sm-9,
        .col-xs-10, .col-sm-10, .col-md-10, .col-sm-10,
        .col-xs-11, .col-sm-11, .col-md-11, .col-sm-11,
        .col-xs-12, .col-sm-12, .col-md-12, .col-sm-12 {
            -webkit-box-sizing: border-box !important;
            -moz-box-sizing: border-box !important;
            box-sizing: border-box !important;
        }
        .e-textbox {
            border-color: #CCCCCC !important;
        }
        .e-textbox:hover {
            border-color: #AEAEAE !important;
        }		
    </style>

    @Scripts.Render("~/Scripts/ej/ej.web.all.min.js")
    @Scripts.Render("~/Scripts/jsrender.min.js")
    @Scripts.Render("~/Scripts/jquery.hotkeys.min.js")
    @Code 
	End Code
</head>
<body>
    @RenderSection("PageHeader", required:=False)
    <div class="@LayoutClass">
        @RenderBody()
    </div>
    @Code
        @Html.EJ().ScriptManager() 
    End Code
    @RenderSection("PageScripts", required:=False)
    <script>
        $('body').on('focus', '.input-group input', function () {
            $(this).closest('.input-group').addClass('state-focused');
        }).on('focusout', '.input-group input', function () {
            $(this).closest('.input-group').removeClass('state-focused');
        });
        $(document).ready(function () {
            try {
                $('input[data-role="datepicker"]').each(function (index, el) {
                    $(el).bind("focus", function () {
                        $(this).data("kendoDatePicker").open();
                        $(this).select();
                    });
                });
            } catch (e) {
                //
            }
        });

    </script>
    <script>
        var buttonLayout = "normal";
        //buttonLayout = "stretched";
        function showKendoSaveContinue(content, title) {
            content = javaScriptCommentToHTML(content);
            title = checkForTitle(title);
            return $("<div></div>").kendoConfirm({
                title: false,
                content: content,
                buttonLayout: buttonLayout,
                actions: [{
                            text: "Save",
                            primary: true
                        }, {
                            text: "Continue"
                        }],
                close: function (e) {
                    this.wrapper.remove();
                }
            }).data("kendoConfirm").open().result;
        }
        function showKendoConfirm(content, title) {
            content = javaScriptCommentToHTML(content);
            title = checkForTitle(title);
            return $("<div></div>").kendoConfirm({
                title: title,
                content: content,
                buttonLayout: buttonLayout,
                close: function (e) {
                    this.wrapper.remove();
                }
            }).data("kendoConfirm").open().result;
        }
        function showKendoAlert(content, title) {
            content = javaScriptCommentToHTML(content);
            title = checkForTitle(title);
            $("<div></div>").kendoAlert({
                title: title,
                content: content,
                buttonLayout: buttonLayout
            }).data("kendoAlert").open();
        }
        function showKendoPrompt(content, title, defaultValue) {
            content = javaScriptCommentToHTML(content);
            title = checkForTitle(title);
            return $("<div></div>").kendoPrompt({
                title: title,
                value: defaultValue,
                content: content,
                buttonLayout: buttonLayout
            }).data("kendoPrompt").open().result;
        }   
        function javaScriptCommentToHTML(str) {
            return str = str.replace("\n", "<br/>");
        }
        function checkForTitle(str) {
            if (!str || str == undefined || str == null || str.trim() == "") {
                str = false;
            } else {
                str = String(str);
            }
            return str;
        }
    </script>
</body>
</html>
