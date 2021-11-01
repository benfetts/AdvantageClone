@Code
    ViewData("Title") = "Job Forecast"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

    <div style="margin:10px;">
        @Code

            Html.Kendo.ToolBar() _
                .Name("ToolBar") _
                .Items(Sub(items)
                           items.Add().Type(CommandType.Separator)
                           items.Add().Type(CommandType.Button).Text("Add").Click("addForecast")
                           items.Add().Type(CommandType.Separator)
                           items.Add().Type(CommandType.Button).Text("Settings").Click("forecastSettings")
                           items.Add().Type(CommandType.Separator)
                       End Sub) _
                   .Render()

        End Code
    </div>

    <div style="margin:10px;">
        <div style="display:inline-block">
            <div>
                <strong>Month</strong><br />
                @Code
                    Html.Kendo().ComboBox() _
                        .Name("Month") _
                        .Filter(FilterType.Contains) _
                        .Placeholder("Select...") _
                        .DataTextField("Value") _
                        .DataValueField("Key") _
                        .BindTo((From Item In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.DateUtilities.Months)) _
                                    Select New With {.Key = Item.Key, _
                                                    .Value = Item.Value}).ToList) _
                    .Render()
                End Code
            </div>
        </div>
        <div style="display:inline-block">
            <span>
                <strong>Year</strong><br />
                @Code
                    Html.Kendo().ComboBox() _
                        .Name("Year") _
                        .Filter(FilterType.Contains) _
                        .Placeholder("Select...") _
                        .DataTextField("Year") _
                        .DataValueField("Year") _
                        .DataSource(Sub(d)
                                            d.Read(Function(r) r.Action("PostPeriods_Read", "JobForecast"))
                                    End Sub) _
                        .Events(Sub(e)
                                        e.Change("filterGrid")
                                End Sub) _
                    .Render()
                End Code
            </span>
        </div>
        <div style="display:inline-block">
            <span>
                <strong>Employee</strong><br />
                @Code
                    Html.Kendo().ComboBox() _
                        .Name("Employee") _
                        .Filter(FilterType.Contains) _
                        .Placeholder("Select...") _
                        .DataTextField("Name") _
                        .DataValueField("Code") _
                        .DataSource(Sub(d)
                                            d.Read(Function(r) r.Action("Employees_Read", "JobForecast"))
                                    End Sub) _
                        .Events(Sub(e)
                                        e.Change("filterGrid")
                                End Sub) _
                    .Render()
                End Code
            </span>
        </div>
    </div>
    <div style="margin: 10px;">

        @Code

            Html.Kendo().Grid(Of AdvantageFramework.JobForecast.Classes.JobForecastView) _
                .Name("Grid") _
                .Columns(Sub(columns)
                                 columns.Bound(Function(jf) jf.JobForecastRevisionID).Title(" ").Width(30).ClientTemplate("<div class='icon-background background-color-sidebar'><input type='image' class='icon-image' src='" + Url.Content("~/Images/Icons/White/256/magnifying_glass.png") + "' onclick='openForecast(#= JobForecastRevisionID #)' /></div>")
                                 columns.Bound(Function(jf) jf.Description).Title("Description")
                                 columns.Bound(Function(jf) jf.RevisionNumber).Title("Revision").Width(90)
                                 columns.Bound(Function(jf) jf.AssignedToEmployeeName).Title("Assigned To")
                                 columns.Bound(Function(jf) jf.IsApproved).Title("Approved").ClientTemplate("# if (IsApproved == true) { # <div class='icon-background standard-green' style='margin: 0 auto;'> <img class='icon-image' src='" + Url.Content("~/Images/Icons/White/256/check.png") + "' /></div> # } #").Width(80)
                         End Sub) _
                .Pageable() _
                .Selectable(Sub(s)
                                    s.Mode(GridSelectionMode.Single)
                            End Sub) _
                .Events(Sub(e)
                                e.Change("gridSelectionChanged")
                        End Sub) _
                .DataSource(Sub(d)
                                    d.Ajax() _
                                        .PageSize(10) _
                                        .Read(Function(r) r.Action("JobForecast_Read", "JobForecast").Data("searchData"))
                            End Sub) _
            .Render()

        End Code

    </div>

    <script type="text/javascript">

        function searchData() {
            return {
                EmployeeCode: $('#Employee').val(),
                Year: $('#Year').val(),
                Month: $('#Month').val()
            };
        }
        function filterGrid() {
            var grid = $('#Grid').data('kendoGrid');
            grid.dataSource.read();
        }
        function addForecast() {
            showKendoAlert('Add Forecast!');
        }
        function forecastSettings() {
            showKendoAlert('Forecast Settings!');
        }
        function openForecast(id) {
            showKendoAlert('open forecast with id ' + id  + '!');
        }
        function gridSelectionChanged(args) {
            
        }
        function openSelectedForecast() {
            var grid = $('#Grid').data('kendoGrid');
            var selectedItem = grid.dataItem(grid.select());
            if (selectedItem) {
                openForecast(selectedItem.JobForecastRevisionID);
            }
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement && window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        $("#Grid").delegate("tbody>tr", "dblclick", function () { openSelectedForecast() });

        $(document).ready(function () {
            $('#Month').parent().css('width', '125px');
            $('#Year').parent().css('width', '125px');
            $('#Employee').parent().css('width', '250px');
        });

    </script>

    <style type="text/css">
        .icon-background {
            height: 21px !important;
            width: 21px !important;
            border-radius: 50% !important;
            vertical-align:middle !important;
            text-align: center !important;
            /*cursor: pointer;*/
        }
        .icon-image {
            position: relative;
            height: 15px !important;
            width: 15px !important;
            bottom: 2px !important;
            vertical-align: middle !important;
            text-align: center !important;
            /*cursor: pointer;*/
        }
        .standard-green {
            background-color:#4CAF50 !important;
            color: #FFFFFF !important;
        }
        .background-color-sidebar {
            background-color: black !important;
            color: #FFFFFF !important;
        }
    </style>
