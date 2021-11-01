@ModelType AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel
<link href="~/CSS/timesheet._grid.mvc.min.css" rel="stylesheet" />
@*<div id="entrygrid" style="border: 1px solid #CCC;"></div>*@
<div style="margin-left: 20px; width: 100%;">

    @(Html.Kendo().Grid(Model.Lines).Name("TimeLines") _
                                                                                                                            .Columns(Sub(c)
                                                                                                                                         'c.AutoGenerate(True)
                                                                                                                                         c.Bound(Function(p) p.ClientCode).Title("Client")
                                                                                                                                         c.Bound(Function(p) p.ClientName).Title("Client")
                                                                                                                                         c.Bound(Function(p) p.DivisionCode).Title("Division")
                                                                                                                                         c.Bound(Function(p) p.DivisionName).Title("Division")
                                                                                                                                         c.Bound(Function(p) p.ProductCode).Title("Product")
                                                                                                                                         c.Bound(Function(p) p.ProductDescription).Title("Product")
                                                                                                                                         c.Bound(Function(p) p.JobNumber).Title("Job")
                                                                                                                                         c.Bound(Function(p) p.JobDescription).Title("Description")
                                                                                                                                         c.Bound(Function(p) p.JobComponentNumber).Title("Component")
                                                                                                                                         c.Bound(Function(p) p.JobComponentDescription).Title("Description")
                                                                                                                                         c.Bound(Function(p) p.FunctionCategory).Title("Function/Category")
                                                                                                                                         c.Bound(Function(p) p.FunctionCategoryDescription).Title("Description")
                                                                                                                                         c.Bound(Function(p) p.DepartmentTeamCode).Title("Dept/Team")
                                                                                                                                         Dim DayCount As Integer = Model.DaysToDisplay
                                                                                                                                         For i As Integer = 0 To DayCount - 1
                                                                                                                                             Try
                                                                                                                                                 Dim pos As Integer = i
                                                                                                                                                 c.Bound(Function(p) p.Entries(pos).Hours).Title("Day " * pos + 1)
                                                                                                                                             Catch ex As Exception
                                                                                                                                             End Try
                                                                                                                                         Next
                                                                                                                                     End Sub) _
                                                                                                                .Sortable() _
                                                                                                                .Pageable(Sub(p)
                                                                                                                          End Sub) _
                                                                                                                .Filterable(Sub(f)
                                                                                                                            End Sub) _
                                                                                                                .Selectable(Sub(s)
                                                                                                                            End Sub) _
                                                                                                                .Events(Sub(e)
                                                                                                                        End Sub) _
                                                                                                                .DataSource(Sub(d)
                                                                                                                                d.Server() _
                                                                                                                                .Model(Sub(m)
                                                                                                                                           m.Id(Function(i) i.LineID)
                                                                                                                                       End Sub)
                                                                                                                            End Sub) _
                                                                        .Scrollable(Sub(sc)
                                                                                        sc.Enabled(True)
                                                                                    End Sub)
)

</div>

<script>
    function resizeGrid(size) {
        if (size === null || size === undefined) {
            size = 0.6;
        }
        var windowHeight = $(window).height();
        var windowWidth = $(window).width();
        windowHeight = windowHeight * size;
        windowWidth = windowWidth * size;
        $(".k-grid-content").height(windowHeight);
        $(".k-grid").width(windowWidth);
    }
    $(document).ready(function () {
        //resizeGrid(.8);
    });

</script>
@Scripts.Render("~/JScripts/timesheet._grid.mvc.min.js")
