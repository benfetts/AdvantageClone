@ModelType AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleViewModel
@Code       ViewData("Title") = "Copy To Project Schedules"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True
End Code

<script type="text/x-kendo-template" id="showOnGridTemplate">
    <div style="text-align: center;">
        # setGrid(); #
        # var dataItem = grid.dataSource.get(ID); #
        # var i = grid.dataSource.indexOf(dataItem); #
        # var theID = 'Selected_' + ID; #
        # if(Selected === true){#
        @(Html.Kendo().CheckBox().Name("JobComponents[#:i#].Selected").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}else{#
        @(Html.Kendo().CheckBox().Name("JobComponents[#:i#].Selected").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}#
    </div>  

</script>
<script>

    var grid = null;

    function setGrid() {

        grid = $('#GridJobComponents').data('kendoGrid');

    }
    var showOnGridTemplate = kendo.template($('#showOnGridTemplate').html());
    function index(dataItem) {
        var data = $("#GridJobComponents").data("kendoGrid").dataSource.data();

        return data.indexOf(dataItem);
    }



</script>


@(Html.Kendo.ToolBar().Name("Toolbar").Items(Sub(ToolBar)

                                                     ToolBar.Add().Type(CommandType.Button).Text("Copy").HtmlAttributes(New With {.id = "CopyTo"})
                                                     ToolBar.Add().Type(CommandType.Separator)
                                                     ToolBar.Add().Type(CommandType.Button).Togglable(True).Text("Hide Descriptions").HtmlAttributes(New With {.id = "ShowHideDescriptions"}).Toggle("ShowHideDescriptionColumns").HtmlAttributes(New With {.title = "Show\Hide Descriptions"})
                                                     ToolBar.Add().Type(CommandType.Button).ImageUrl("../../Images/Icons/Grey/256/undo.png").Text("").HtmlAttributes(New With {.id = "ClearAllFilters", .title = "Clear Column Filters"}).Click("ClearAllRowFilters")

                                                 End Sub))

<div id="dialog">
</div>

<div style="margin-top: 10px;">

    @(Html.Kendo().DataSource(Of Generic.List(Of Integer)).Name("JobComponentIDs").Ajax(Sub(Ajax)
                                                                                            Ajax.Read("CopyToJobComponents_GetJobComponentIDs", "ProjectSchedule", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber})
                                                                                            Ajax.ServerOperation(True)
                                                                                        End Sub))

    <form id="CopyToForm" method="post" action='@Url.Action("CopyToProjectSchedules")' enctype="multipart/form-data" class="form-horizontal" data-role="validator" novalidate="novalidate">

        @Html.HiddenFor(Function(M) Model.IsValid)
        @Html.HiddenFor(Function(M) Model.JobNumber)
        @Html.HiddenFor(Function(M) Model.JobComponentNumber)
        @Html.HiddenFor(Function(M) Model.JobTypeCode)

        @*@Html.ValidationSummary(False, "", New With {.style = "color:red"})*@

        <div class="form-group">
            <div class="col-sm-3 col-md-2 col-lg-2">
                <span data-for='GridHasASelectedRow' class='k-invalid-msg'></span>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                <span data-for='HiddenAddOrUpdateRule' class='k-invalid-msg'></span>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                <span data-for='HiddenHeaderOrDetailRule' class='k-invalid-msg'></span>
            </div>
        </div>

        <div class="form-group">

            <div class="col-sm-3 col-md-2 col-lg-2">
                @*@(Html.Kendo().CheckBoxFor(Function(M) M.AddScheduleIfScheduleDoesntExist).Name("AddScheduleIfScheduleDoesntExistName").Label("Add schedule if schedule doesn't exist").HtmlAttributes(New With {.id = "AddScheduleIfScheduleDoesntExist", .data_addOrUpdateRule = ""}))*@
                <input class="k-checkbox" id="AddScheduleIfScheduleDoesntExist" name="AddScheduleIfScheduleDoesntExist" type="checkbox">
                <label class="k-checkbox-label" for="AddScheduleIfScheduleDoesntExist">Add schedule if schedule doesn't exist</label>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @*@(Html.Kendo().CheckBoxFor(Function(M) M.UpdateScheduleIfExists).Name("UpdateScheduleIfExistsName").Label("Update schedule if exist").HtmlAttributes(New With {.id = "UpdateScheduleIfExists", .data_addOrUpdateRule = ""}))*@
                <input class="k-checkbox" id="UpdateScheduleIfExists" name="UpdateScheduleIfExists" type="checkbox">
                <label class="k-checkbox-label" for="UpdateScheduleIfExists">Update schedule if exist</label>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @*@(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleHeaderData).Name("IncludeScheduleHeaderDataName").Label("Include schedule header data").HtmlAttributes(New With {.id = "IncludeScheduleHeaderData", .data_headerOrDetailRule = ""}))*@
                <input class="k-checkbox" id="IncludeScheduleHeaderData" name="IncludeScheduleHeaderData" type="checkbox" disabled="disabled">
                <label class="k-checkbox-label" for="IncludeScheduleHeaderData">Include schedule header data</label>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.UpdateComponentBudget).Label("Update component budget"))
            </div>

        </div>

        <div class="form-group">

            <div class="col-sm-3 col-md-2 col-lg-2">
                @*@(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleDetailData).Name("IncludeScheduleDetailDataName").Label("Include schedule detail data").HtmlAttributes(New With {.id = "IncludeScheduleDetailData", .data_headerOrDetailRule = ""}))*@
                <input class="k-checkbox" id="IncludeScheduleDetailData" name="IncludeScheduleDetailData" type="checkbox" disabled="disabled">
                <label class="k-checkbox-label" for="IncludeScheduleDetailData">Include schedule detail data</label>
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleDetailScheduleDates).Label("Include schedule dates").Enable(Model.IncludeScheduleDetailData).HtmlAttributes(New With {.id = "IncludeScheduleDetailScheduleDates"}))
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleDetailEmployeeAssignments).Label("Include employee assignments").Enable(Model.IncludeScheduleDetailData).HtmlAttributes(New With {.id = "IncludeScheduleDetailEmployeeAssignments"}))
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleDetailTaskComments).Label("Include task comments").Enable(Model.IncludeScheduleDetailData).HtmlAttributes(New With {.id = "IncludeScheduleDetailTaskComments"}))
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleDetailDueDateComments).Label("Include due date comments").Enable(Model.IncludeScheduleDetailData).HtmlAttributes(New With {.id = "IncludeScheduleDetailDueDateComments"}))
            </div>
            <div class="col-sm-3 col-md-2 col-lg-2">
                @(Html.Kendo().CheckBoxFor(Function(M) M.IncludeScheduleRevsionComments).Label("Include revision comments").Enable(Model.IncludeScheduleDetailData).HtmlAttributes(New With {.id = "IncludeScheduleRevsionComments"}))
            </div>
        </div>

        @(Html.Kendo().Grid(Of AdvantageFramework.ViewModels.ProjectSchedule.CopyToProjectScheduleJobComponentViewModel).Name("GridJobComponents") _
                                                                .Columns(Sub(Columns)

                                                                             Columns.AutoGenerate(False)
                                                                             Columns.Bound(Function(SM) SM.ID).Visible(False).MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.Selected).Sortable(False).ClientTemplate("#= showOnGridTemplate(data) #").HeaderTemplate("<input type='checkbox' id='header-chb' class='k-checkbox'><label class='k-checkbox-label' for='header-chb'></label>").Filterable(False).MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.ClientCode).HeaderTemplate("Client </br> Code").MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.ClientName).HeaderTemplate("Client </br> Name").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.DivisionCode).HeaderTemplate("Division </br> Code").MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.DivisionName).HeaderTemplate("Division </br> Name").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.ProductCode).HeaderTemplate("Product </br> Code").MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.ProductDescription).HeaderTemplate("Product </br> Description").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.JobNumber).HeaderTemplate("Job </br> Number").MinScreenWidth(20).Filterable(Function(Filter) Filter.UI("myfilter"))
                                                                             Columns.Bound(Function(SM) SM.JobDescription).HeaderTemplate("Job </br> Description").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.JobComponentNumber).HeaderTemplate("Job Component </br> Number").MinScreenWidth(20).Filterable(Function(Filter) Filter.UI("myfilter"))
                                                                             Columns.Bound(Function(SM) SM.JobComponentDescription).HeaderTemplate("Job Component </br> Description").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.SalesClassCode).HeaderTemplate("Sales Class </br> Code").MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.SalesClassDescription).HeaderTemplate("Sales Class </br> Description").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.JobTypeCode).HeaderTemplate("Job Type </br> Code").MinScreenWidth(20)
                                                                             Columns.Bound(Function(SM) SM.JobTypeDescription).HeaderTemplate("Job Type </br> Description").MinScreenWidth(200)
                                                                             Columns.Bound(Function(SM) SM.PromotionType).HeaderTemplate("Promotion </br> Type").MinScreenWidth(50)
                                                                             Columns.Bound(Function(SM) SM.CopyFromJobNumber).HeaderTemplate("Copy From </br> Job Number").MinScreenWidth(20).Filterable(Function(Filter) Filter.UI("myfilter"))
                                                                             Columns.Bound(Function(SM) SM.CopyFromJobComponentNumber).HeaderTemplate("Copy From </br> Job Comp Number").MinScreenWidth(20).Filterable(Function(Filter) Filter.UI("myfilter"))

                                                                         End Sub) _
                                                            .Sortable() _
                                                            .Pageable(Sub(Pageable)
                                                                          Pageable.Info(True)
                                                                          Pageable.PreviousNext(True)
                                                                          Pageable.PageSizes(True).PageSizes(New Generic.List(Of Integer)({5, 10, 15, 20, 25, 50}))
                                                                      End Sub) _
                                                            .Filterable(Sub(Filterable)
                                                                            Filterable.Enabled(True)
                                                                            Filterable.Extra(False)
                                                                            Filterable.Mode(GridFilterMode.Menu)
                                                                        End Sub) _
                                                    .Selectable(Sub(Selectable)
                                                                    Selectable.Enabled(False)
                                                                End Sub) _
                                            .Events(Sub(Events)
                                                        Events.DataBinding("GridDataBinding")
                                                        Events.DataBound("GridDataBound")
                                                    End Sub) _
                                .DataSource(Sub(DataSource)

                                                If String.IsNullOrWhiteSpace(Model.JobTypeCode) = False Then

                                                    DataSource.Ajax().Model(Sub(M)
                                                                                M.Id("ID")
                                                                            End Sub).PageSize(Model.PageSize).Batch(True).ServerOperation(True) _
                                                                            .Filter(Function(Filter) Filter.Add(Function(InitialFilter) InitialFilter.JobTypeCode).IsEqualTo(Model.JobTypeCode)) _
                                                                            .Read(Sub(R)
                                                                                      R.Action("CopyToJobComponents_Read", "ProjectSchedule", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber})
                                                                                  End Sub)

                                                Else

                                                    DataSource.Ajax().Model(Sub(M)
                                                                                M.Id("ID")
                                                                            End Sub).PageSize(Model.PageSize).Batch(True).ServerOperation(True) _
                                                                            .Read(Sub(R)
                                                                                      R.Action("CopyToJobComponents_Read", "ProjectSchedule", New With {.JobNumber = Model.JobNumber, .JobComponentNumber = Model.JobComponentNumber})
                                                                                  End Sub)

                                                End If

                                            End Sub))


        <input type="hidden" name="GridHasASelectedRow" data-GridValid />
        <input type="hidden" name="HiddenAddOrUpdateRule" data-addOrUpdateRule />
        <input type="hidden" name="HiddenHeaderOrDetailRule" data-headerOrDetailRule />

    </form>

</div>

@Section PageScripts

    <script type="text/javascript">

        var SelectedIDs = {};
        var SelectAll = false;

        function GridDataBinding() {

            var pageSize = $("#GridJobComponents").data("kendoGrid").dataSource.pageSize();

            //console.log(pageSize);

            $.ajax({
                type: 'POST',
                url: "SavePageSize",
                data: { PageSize: pageSize }
            });

        }

        function GridDataBound() {

            if (SelectAll === false) {

                var view = $("#GridJobComponents").data("kendoGrid").dataSource.view();

                for (var i = 0; i < view.length; i++) {

                    if (SelectedIDs[view[i].ID]) {

                        this.tbody.find("tr[data-uid='" + view[i].uid + "']")
                            .find(".k-checkbox")
                            .attr("checked", "checked");

                    }

                }

            }

        }

        function myfilter(element) {
            element.kendoNumericTextBox({
                format: "########",
                decimals: 0,
                spinners: false
            });
            //element.kendoNumericTextBox({
            //	format: "n0"
            //});
        }

        function ClearAllRowFilters() {

            $("#GridJobComponents").data("kendoGrid").dataSource.filter({});

        }

        function FindColumn(grid, fieldName) {

            var column;

            for (var i = 0; i < grid.columns.length; i++) {

                if (grid.columns[i].field == fieldName) {

                    column = grid.columns[i];
                    break;

                }

            }

            return column;

        }

        function ShowHideDescriptionColumns() {

            var grid = $('#GridJobComponents').data('kendoGrid');

            if (FindColumn(grid, 'ClientName').hidden == true) {

                grid.showColumn('ClientName');
                grid.showColumn('DivisionName');
                grid.showColumn('ProductDescription');
                grid.showColumn('JobDescription');
                grid.showColumn('JobComponentDescription');
                grid.showColumn('SalesClassDescription');
                grid.showColumn('JobTypeDescription');

            } else {

                grid.hideColumn('ClientName');
                grid.hideColumn('DivisionName');
                grid.hideColumn('ProductDescription');
                grid.hideColumn('JobDescription');
                grid.hideColumn('JobComponentDescription');
                grid.hideColumn('SalesClassDescription');
                grid.hideColumn('JobTypeDescription');

            }

        }

        var validator;
        var dialog;

        $(document).ready(function () {

            dialog = $('#dialog');

            function onClose() {
                CloseThisWindow();
            }

            dialog.kendoDialog({
                width: "400px",
                title: "Success",
                closable: false,
                modal: true,
                visible: false,
                content: "<p>Project Schedules have been created/updated.<p>",
                actions: [
                    { text: 'OK', primary: true }
                ],
                close: onClose
            });

            $('#GridJobComponents').data('kendoGrid').wrapper.css('display', 'table');

        });

        $(function () {

            var container = $("#CopyToForm");

            kendo.init(container);

            validator = container.kendoValidator({

                validateOnBlur: false,

                rules: {

                    addOrUpdateRule: function (input) {

                        if (input.is("[data-addOrUpdateRule]")) {

                            var checked = false;

                            if ($('#AddScheduleIfScheduleDoesntExist').is(':checked') || $('#UpdateScheduleIfExists').is(':checked') || $('#UpdateComponentBudget').is(':checked')) {

                                checked = true;

                            }

                            return checked;

                        }

                        return true;

                    },

                    headerOrDetailRule: function (input) {

                        if (input.is("[data-headerOrDetailRule]")) {

                            var checked = false;

                            if ($('#IncludeScheduleHeaderData').is(':checked') || $('#IncludeScheduleDetailData').is(':checked') || $('#UpdateComponentBudget').is(':checked')) {

                                checked = true;

                            }

                            return checked;

                        }

                        return true;

                    },

                    GridValid: function (input) {

                        if (input.is('[data-GridValid]')) {

                            var grid = $('#GridJobComponents').data('kendoGrid');
                            var hasASelected = false;

                            $.each(grid.dataSource.data(), function () {
                                if (SelectedIDs[this.ID] === true) {
                                    hasASelected = true;
                                    return false;
                                }
                            });

                            return hasASelected;

                        }

                        return true;

                    }
                },
                messages: {

                    addOrUpdateRule: "Please select at least one add or update option.",
                    headerOrDetailRule: "Please select at least one header or detail option.",
                    GridValid: "Please select at least one job component."
                },
                validate: function (e) {
                    if (e.valid === true) {
                        this.hideMessages();
                    }
                },
                validateInput: function (e) {

                    //console.log(e);

                }

            });

        });

        $('body').on('change', 'input[name*="Selected"]', function () {

            var checked = $(this).is(":checked");

            var grid = $('#GridJobComponents').data('kendoGrid');
            var dataItem = grid.dataItem($(this).closest('tr'));

            SelectedIDs[dataItem.ID] = checked;

        }).on('click', '#CopyTo', function () {
            var validator = $("#CopyToForm").data("kendoValidator");
            if (validator.validate()) {
                var grid = $('#GridJobComponents').data('kendoGrid');
                var $form = $('#CopyToForm');
                var jcs = [];
                for (var key in SelectedIDs) {

                    //console.log(key);
                    if (key === 'length' || !SelectedIDs.hasOwnProperty(key)) continue;
                    //console.log(SelectedIDs[key]);
                    if (SelectedIDs[key]) {

                        jcs.push({ ID: key, Selected: SelectedIDs[key] });

                    }

                }
                var model = {
                    IsValid: $('#IsValid').val(),
                    JobNumber: $('#JobNumber').val(),
                    JobComponentNumber: $('#JobComponentNumber').val(),
                    JobTypeCode: $('#JobTypeCode').val(),
                    AddScheduleIfScheduleDoesntExist: $('#AddScheduleIfScheduleDoesntExist').is(':checked'),
                    UpdateScheduleIfExists: $('#UpdateScheduleIfExists').is(':checked'),
                    IncludeScheduleHeaderData: $('#IncludeScheduleHeaderData').is(':checked'),
                    IncludeScheduleDetailData: $('#IncludeScheduleDetailData').is(':checked'),
                    IncludeScheduleDetailScheduleDates: $('#IncludeScheduleDetailScheduleDates').is(':checked'),
                    IncludeScheduleDetailEmployeeAssignments: $('#IncludeScheduleDetailEmployeeAssignments').is(':checked'),
                    IncludeScheduleDetailTaskComments: $('#IncludeScheduleDetailTaskComments').is(':checked'),
                    IncludeScheduleDetailDueDateComments: $('#IncludeScheduleDetailDueDateComments').is(':checked'),
                    IncludeScheduleRevsionComments: $('#IncludeScheduleRevsionComments').is(':checked'),
                    UpdateComponentBudget: $('#UpdateComponentBudget').is(':checked'),
                    JobComponents: jcs
                };
                //console.log(jcs.length);
                showKendoConfirm(kendo.format("You are about to copy/update {0} selected schedules. <br />This process cannot be reversed. <br /><br />Are you sure you want to continue?  ", jcs.length))
                    .done(function () {
                        kendo.ui.progress($('body'), true);
                        return $.ajax({
                            type: 'POST',
                            url: $form.attr('action'),
                            data: { CopyToProjectScheduleViewModel: model },
                            error: function () {
                                //console.log('CopyTo', 'failed');
                                kendo.ui.progress($('body'), false);
                            },
                            success: function (response) {
                                kendo.ui.progress($('body'), false);
                                dialog.data("kendoDialog").open();
                                //showKendoAlert("Project Schedules have been created/updated.");
                                //CloseThisWindow();
                            }
                        });
                    })
                    .fail(function () {
                    });
            }
        }).on('mouseenter', 'input.k-formatted-value', function (e) {
            $(this).prop('title', '');
        });

        $('#header-chb').change(function (ev) {

            var checked = ev.target.checked;

            var dataSource = grid.dataSource;
            var filters = dataSource.filter();
            var allData = dataSource.data();
            var query = new kendo.data.Query(allData);
            var data = query.filter(filters).data;

            var currentPage = dataSource.page();
            var currentPageSize = dataSource.pageSize();

            //var JCIDsDataSource = JobComponentIDs;

            kendo.ui.progress($('body'), true);

            //console.log(JobComponentIDs);

            JobComponentIDs.query({
                filter: filters
            }).then(function () {
                var view = JobComponentIDs.view();
                for (var viewItemId = 0; viewItemId < view.length; viewItemId++) {
                    var viewItem = view[viewItemId];
                    //console.log(viewItem.id);
                    SelectedIDs[viewItem.id] = checked;
                }
                kendo.ui.progress($('body'), false);
                //completionFunction(dataSource, currentPage, currentPageSize, filters);
                grid.refresh();
            });

            //SelectAll = true;

            //PageTraverser(dataSource, currentPage, currentPageSize, filters, checked);

            //grid.refresh();

        });

        var filteredRows = [];

        function completionFunction(dataSource, currentPage, currentPageSize, filters) {

            SelectAll = false;

            dataSource.query({
                page: currentPage,
                pageSize: currentPageSize,
                filter: filters
            }).then(function () {

                var view = dataSource.view();
                for (var viewItemId = 0; viewItemId < view.length; viewItemId++) {
                    var viewItem = view[viewItemId];

                }

            });

        }

        function PageTraverser(dataSource, currentPage, currentPageSize, filters, checked) {

            dataSource.query({
                filter: filters
            }).then(function () {
                var view = dataSource.view();
                for (var viewItemId = 0; viewItemId < view.length; viewItemId++) {
                    var viewItem = view[viewItemId];
                    SelectedIDs[viewItem.ID] = checked;
                }
                completionFunction(dataSource, currentPage, currentPageSize, filters);
            });

        }

        $(function () {
            $('#IncludeScheduleDetailData').change(function () {

                var checked = this.checked ? false : 'disabled';

                $('#IncludeScheduleDetailScheduleDates').attr('disabled', checked);
                $('#IncludeScheduleDetailEmployeeAssignments').attr('disabled', checked);
                $('#IncludeScheduleDetailTaskComments').attr('disabled', checked);
                $('#IncludeScheduleDetailDueDateComments').attr('disabled', checked);
                $('#IncludeScheduleRevsionComments').attr('disabled', checked);

                if (this.checked == false) {

                    $('#IncludeScheduleDetailScheduleDates').prop('checked', false);
                    $('#IncludeScheduleDetailEmployeeAssignments').prop('checked', false);
                    $('#IncludeScheduleDetailTaskComments').prop('checked', false);
                    $('#IncludeScheduleDetailDueDateComments').prop('checked', false);
                    $('#IncludeScheduleRevsionComments').prop('checked', false);
                }

            });
        });

        $(function () {
            $('#AddScheduleIfScheduleDoesntExist').change(function () {

                if (this.checked == true || $('#UpdateScheduleIfExists').prop('checked') == true) {

                    $('#IncludeScheduleHeaderData').prop('disabled', '');
                    $('#IncludeScheduleDetailData').prop('disabled', '');
                    $('#IncludeComponentBudget').prop('disabled', '');

                } else {

                    $('#IncludeScheduleHeaderData').prop('disabled', 'disabled');
                    $('#IncludeScheduleDetailData').prop('disabled', 'disabled');
                    $('#IncludeComponentBudget').prop('disabled', 'disabled');

                }

            });
        });

        $(function () {
            $('#UpdateScheduleIfExists').change(function () {

                if (this.checked == true || $('#AddScheduleIfScheduleDoesntExist').prop('checked') == true) {

                    $('#IncludeScheduleHeaderData').prop('disabled', '');
                    $('#IncludeScheduleDetailData').prop('disabled', '');
                    $('#IncludeComponentBudget').prop('disabled', '');

                } else {

                    $('#IncludeScheduleHeaderData').prop('disabled', 'disabled');
                    $('#IncludeScheduleDetailData').prop('disabled', 'disabled');
                    $('#IncludeComponentBudget').prop('disabled', 'disabled');

                }

            });
        });

    </script>
    <style type="text/css">
        .k-grid-filter.k-state-active {
            background-color: yellow;
        }

        .k-grid-header th.k-header {
            position: relative;
        }

            .k-grid-header th.k-header.k-filterable.k-with-icon a.k-link a.k-grid-filter {
                position: absolute;
                top: 5px;
                right: 5px;
            }

        .k-confirm .k-window-titlebar::before {
            content: 'Confirmation';
        }

        .k-dialog .k-window-titlebar .k-dialog-title {
            visibility: hidden;
        }

        .k-autocomplete .k-i-close {
            visibility: hidden;
        }
    </style>
End Section
