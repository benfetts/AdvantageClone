@ModelType AdvantageFramework.Database.Entities.JobForecastRevision
@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("Title") = "Select Job Components"
End Code

<div style="margin: 10px;">
    <div>
        <div style="display: inline-block; vertical-align: top; height: 400px;">
            @(Html.Kendo().Grid(Of AdvantageFramework.Database.Views.JobComponentView) _
                        .Name("Grid") _
                        .Columns(Sub(cols)
                                     cols.Bound("ClientCode").Title("Client").Width(175).ClientTemplate("<div class='desc-container' title='#= ClientCode # - #= ClientName #'>#= ClientCode # - #= ClientName #</div>").Width(175)
                                     cols.Bound("JobNumber").Title("Job").ClientTemplate("<div class='desc-container' title='#= JobNumber # - #= JobDescription #'>#= JobNumber # - #= JobDescription #</div>").Width(175)
                                     cols.Bound("JobComponentNumber").Title("Component").ClientTemplate("<div class='desc-container' title='#= JobComponentNumber # - #= JobComponentDescription #'>#= JobComponentNumber # - #= JobComponentDescription #</div>").Width(175)
                                 End Sub) _
                        .Pageable(Sub(p)
                                      p.Numeric(False)
                                      p.Refresh(False)
                                      p.Input(True)
                                  End Sub) _
                              .Scrollable(Sub(s)
                                              s.Enabled(False)
                                          End Sub) _
                        .Selectable(Sub(s)
                                        s.Mode(GridSelectionMode.Multiple)
                                    End Sub) _
                                .Events(Sub(e)
                                            e.Change("availableSelectionChanged")
                                            e.DataBound("availableDataBound")
                                        End Sub) _
                        .DataSource(Sub(d)
                                        d.Ajax() _
                                        .PageSize(10) _
                                        .Read(Function(r) r.Action("JobForecast_AvailableJobComponents", "JobForecast").Data("searchData"))
                                    End Sub))
        </div>
        <div style="display:inline-block;">
            @(Html.Kendo().Button().Name("Insert").HtmlAttributes(New With {.type = "button", .style = "width: 30px; margin-bottom: 5px; display: block;"}).Content("&gt;").Events(Sub(e) e.Click("insertItems")))
            @(Html.Kendo().Button().Name("InsertAll").HtmlAttributes(New With {.type = "button", .style = "width: 30px; margin-bottom: 5px; display: block;"}).Content("&gt;&gt;").Events(Sub(e) e.Click("insertAllItems")))
            @(Html.Kendo().Button().Name("RemoveAll").HtmlAttributes(New With {.type = "button", .style = "width: 30px; margin-bottom: 5px; display: block;"}).Content("&lt;&lt;").Events(Sub(e) e.Click("removeAllItems")))
            @(Html.Kendo().Button().Name("Remove").HtmlAttributes(New With {.type = "button", .style = "width: 30px; margin-bottom: 5px; display: block;"}).Content("&lt;").Events(Sub(e) e.Click("removeItems")))
        </div>
        <div style="display: inline-block; vertical-align: top; height: 400px;">
            @(Html.Kendo().Grid(Of AdvantageFramework.Database.Views.JobComponentView) _
                        .Name("SelectedGrid") _
                        .Columns(Sub(cols)
                                     cols.Bound("ClientCode").Title("Client").Width(175).ClientTemplate("<div class='desc-container' title='#= ClientCode # - #= ClientName #'>#= ClientCode # - #= ClientName #</div>").Width(175)
                                     cols.Bound("JobNumber").Title("Job").ClientTemplate("<div class='desc-container' title='#= JobNumber # - #= JobDescription #'>#= JobNumber # - #= JobDescription #</div>").Width(175)
                                     cols.Bound("JobComponentNumber").Title("Component").ClientTemplate("<div class='desc-container' title='#= JobComponentNumber # - #= JobComponentDescription #'>#= JobComponentNumber # - #= JobComponentDescription #</div>").Width(175)
                                 End Sub) _
                        .Pageable(Sub(p)
                                      p.Numeric(False)
                                      p.Refresh(False)
                                      p.Input(True)
                                  End Sub) _
                        .Pageable() _
                        .Selectable(Sub(s)
                                        s.Mode(GridSelectionMode.Multiple)
                                    End Sub) _
                                .Events(Sub(e)
                                            e.Change("selectedSelectionChanged")
                                            e.DataBound("selectedDataBound")
                                        End Sub) _
                        .DataSource(Sub(d)
                                        d.Ajax() _
                                        .PageSize(10) _
                                        .Read(Function(r) r.Action("JobForecast_SelectedJobComponents", "JobForecast").Data("searchData"))
                                    End Sub))
        </div>
    </div>
</div>

<script type="text/javascript">
    function searchData() {
        return {
            RevisionID: 1,
            ClientCode: '',
            DivisionCode: '',
            ProductCode: ''
        };
    }
    function refreshGrids() {
        refreshAvailableGrid();
        refreshSelectedGrid();
    }
    function refreshGrid(grid) {
        grid.data('kendoGrid').dataSource.read();
    }
    function refreshAvailableGrid() {
        refreshGrid($('#Grid'));
    }
    function refreshSelectedGrid() {
        refreshGrid($('#SelectedGrid'));
    }
    function insertItems() {
        var data = {
            RevisionID: 1,
            JobNumber: 290,
            JobComponentNumber: 1
        };
        $.ajax({
            url: '@Url.Action("AddJobComponentsToForecast", "JobForecast")',
            type: 'POST',
            data: JSON.stringify(data),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                refreshGrids();
            },
            error: function (data) {
               //console.log(data);
                showKendoAlert('Error adding selected items!');
            }
        });
    }
    function insertAllItems() {
        $.ajax({
            url: '/@Html.Raw(Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute)AddAllJobComponentsToForecast',
            type: 'POST',
            data: JSON.stringify("{RevisionID: 1}"),
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                refreshGrids();
            },
            error: function (data) {
                showKendoAlert('Error adding all items!');
            }
        });
    }
    function removeAllItems() {
        showKendoConfirm("Are you sure you want to remove all job components from the forecast?")
            .done(function () {
                $.ajax({
                    url: '/@Html.Raw(Webvantage.Controllers.FinanceAndAccounting.JobForecastController.BaseRoute)RemoveAllJobComponentsFromForecast',
                    type: 'POST',
                    data: JSON.stringify("{RevisionID: 1}"),
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function (result) {
                        refreshGrids();
                    },
                    error: function (data) {
                        showKendoAlert('Error removing all items!');
                    }
                });
            })
            .fail(function () {
            });
    }
    function removeItems() {
        showKendoConfirm("Are you sure you want to remove the job component from the forecast?")
            .done(function () {
                var data = {
                    RevisionID: 1,
                    JobNumber: 290,
                    JobComponentNumber: 1
                };
                $.ajax({
                    url: '@Url.Action("RemoveJobComponentsFromForecast", "JobForecast")',
                    type: 'POST',
                    data: JSON.stringify(data),
                    dataType: 'json',
                    contentType: 'application/json; charset=utf-8',
                    success: function (result) {
                        refreshGrids();
                    },
                    error: function (data) {
                        showKendoAlert('Error removing selected items!');
                    }
                });
            })
            .fail(function () {
            });
    }
    function availableSelectionChanged(args) {
        checkAllowAdd();
    }
    function selectedSelectionChanged(args) {
        checkAllowRemove();
    }
    function availableDataBound(args) {
        checkAllowAdd();
    }
    function selectedDataBound(args) {
        checkAllowRemove();
    }
    function checkAllowAdd() {
        var grid = $('#Grid').data('kendoGrid');
        var button = $('#Insert').data('kendoButton');
        var allButton = $('#InsertAll').data('kendoButton');
        checkButtons(grid, button, allButton);
    }
    function checkAllowRemove() {
        var grid = $('#SelectedGrid').data('kendoGrid');
        var button = $('#Remove').data('kendoButton');
        var allButton = $('#RemoveAll').data('kendoButton');
        checkButtons(grid, button, allButton);
    }
    function checkButtons(grid, button, allButton) {
        var enabled = false;
        if (grid.select().length > 0) {
            enabled = true;
        }
        button.enable(enabled);
        enabled = false;
        if (grid.dataSource.total() > 0) {
            enabled = true;
        }
        allButton.enable(enabled);
    }

</script>

<style type="text/css">
    .desc-container {
        width: 200px;
        white-space: nowrap; 
        text-overflow: ellipsis; 
        overflow: hidden;
    }
</style>
