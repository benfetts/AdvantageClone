<!DOCTYPE html>
<html>
<head>
    <title>@ViewBag.Title - My Telerik MVC Application</title>
    <link href="@Url.Content("~/Content/Site.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/kendo/current/kendo.common-material.min.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/kendo/current/kendo.mobile.all.min.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/kendo/current/kendo.dataviz.min.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/kendo/current/kendo.material.min.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/kendo/current/kendo.dataviz.material.min.css")" rel="stylesheet" type="text/css" />
    <script src="@Url.Content("~/Scripts/kendo/current/jquery.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/current/jszip.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/current/kendo.all.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo/current/kendo.aspnetmvc.min.js")"></script>
    <script src="@Url.Content("~/Scripts/kendo.modernizr.custom.js")"></script>
</head>
<body>
    <header>
        <div class="content-wrapper">
            <div class="float-left">
                <p class="site-title">@Html.ActionLink("your logo here", "Index", "Home")</p>
            </div>
            <div class="float-right">
                <nav>
                    <ul id="menu">
                        <li>@Html.ActionLink("Home", "Index", "Home")</li>
                        <li>@Html.ActionLink("About", "About", "Home")</li>
                        <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
                    </ul>
                </nav>
            </div>
        </div>
    </header>
    <div id="body">
        @RenderSection("featured", required:=False)
        <section class="content-wrapper main-content clear-fix">
            @RenderBody()
        </section>
    </div>
    <footer>
        <div class="content-wrapper">
            <div class="float-left">
                <p>&copy; @DateTime.Now.Year - My Telerik MVC Application</p>
            </div>
        </div>
    </footer>
</body>
</html>
