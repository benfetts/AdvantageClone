@ModelType Object
@Code       ViewData("Title") = "Project Schedule - Setup"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = True

End Code

<script type="text/x-kendo-template" id="showOnGridTemplate">
    <div style="text-align: center;">
        # var theID = 'ShowOnGrid_' + ID; #
        # if(ShowOnGrid === 'True'){#
        @(Html.Kendo().CheckBox().Name("ShowOnGrid").Checked(True).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}else{#
        @(Html.Kendo().CheckBox().Name("ShowOnGrid").Checked(False).HtmlAttributes(New With {.id = "#: theID #"}).ToClientTemplate)
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="predOnlyTemplate">
    <div style="text-align: center;">
        # if(ColumnName === 'JobOrder'){#

        #} else { #
        <span class="glyphicon glyphicon-ok"></span>
        #}#
    </div>
</script>
<script type="text/x-kendo-template" id="orderOnlyTemplate">
    <div style="text-align: center;">
        # if(ColumnName === 'ColumnMove' || ColumnName === 'GridTemplateColumnInputPreds' || ColumnName === 'GridTemplateColumnPreds' || ColumnName === 'Linked' || ColumnName === 'SelectPreds'){#

        #} else { #
        <span class="glyphicon glyphicon-ok"></span>
        #}#
    </div>
</script>

<script>
    var showOnGridTemplate = kendo.template($('#showOnGridTemplate').html());
    var predOnlyTemplate = kendo.template($('#predOnlyTemplate').html());
    var orderOnlyTemplate = kendo.template($('#orderOnlyTemplate').html());
</script>

<div>

    <h4>Available Columns</h4>
    <div class="alert alert-info text-center">
        Drag &amp; drop available columns to reorder them on the schedule.
    </div>
    @(Html.Kendo().Grid(Of AdvantageFramework.Database.Classes.TrafficScheduleUserColumn).Name("SetupItems").Columns(Sub(col)
                                                                                                                         col.AutoGenerate(False)
                                                                                                                         col.Bound(Function(c) c.ColumnShortDescription).Title("Column Heading")
                                                                                                                         col.Bound(Function(c) c.ColumnLongDescription).Title("Description")
                                                                                                                         col.Bound(Function(c) c.ShowOnGrid).Title("Display").ClientTemplate("#= showOnGridTemplate(data) #")
                                                                                                                         col.Group(Sub(g)
                                                                                                                                       g.Title("Mode").Columns(Sub(c)
                                                                                                                                                                   c.Bound(Function(groupCol) groupCol.ShowOnGrid).Title("Order").ClientTemplate("#= orderOnlyTemplate(data) #")
                                                                                                                                                                   c.Bound(Function(groupCol) groupCol.ShowOnGrid).Title("Predecessor").ClientTemplate("#= predOnlyTemplate(data) #")
                                                                                                                                                               End Sub)
                                                                                                                                   End Sub)
                                                                                                                     End Sub).DataSource(Sub(ds)
                                                                                                                                             ds.Ajax() _
                                                                                                                                         .Read(Sub(r) r.Action("ReadSetupUserColumns", "ProjectSchedule")) _
                                                                                                                                         .Update(Sub(u) u.Action("UpdateSetupUserColumns", "ProjectSchedule")).AutoSync(False).Model(Sub(m)
                                                                                                                                                                                                                                         m.Id("ID")
                                                                                                                                                                                                                                     End Sub).Events(Sub(e)
                                                                                                                                                                                                                                                         e.RequestEnd("gridRequestEnd")
                                                                                                                                                                                                                                                         e.RequestStart("gridRequestStart")
                                                                                                                                                                                                                                                     End Sub)
                                                                                                                                         End Sub))

</div>

<div class="form-horizontal" style="margin-top: 10px;">
    <h4>Other Settings</h4>
    <div class="form-group" style="display:none">
        <span class="col-xs-9 col-xs-offset-3 col-lg-1 col-lg-offset-1">@(Html.Kendo.CheckBox().Name("DisablePaging").Label("Disable paging*").Checked(Model.DisablePaging))</span>
    </div>
    <div class="form-inline">
        <div class="form-group" style="padding: 6px 10px;">
            <label for="ScheduleDefault" class="">Default Schedule:</label>
            <div class="form-control" style="border-color: transparent; box-shadow: none;">
                @(Html.Kendo.RadioButton().Name("ScheduleDefault").Label("Order").Value("0").Checked(Not Model.PredecessorDefault))&nbsp;&nbsp;&nbsp;
                @(Html.Kendo.RadioButton().Name("ScheduleDefault").Label("Predecessor").Value("1").Checked(Model.PredecessorDefault))
            </div>
        </div>
    </div>
    <div class="form-inline">
        <div class="form-group" style="padding: 6px 10px;">
            <div class="form-control" style="border-color: transparent; box-shadow: none;">
                @(Html.Kendo.CheckBox().Name("CopyEmployees").Checked(Model.CopyEmployees))&nbsp;
            </div>
            <label for="CopyEmployees" class="">Copy employee assignments on copy task?</label>
        </div>
        <div style="display:none">
            *Note: This can drastically increase load time for large schedules!
        </div>
    </div>
    <div class="form-inline">
        <div class="form-group" style="padding: 6px 10px;">
            <label for="LockedColumns" class="">Number of locked columns:</label>
            <div class="form-control" style="border-color: transparent; box-shadow: none;">
                @(Html.Kendo.TextBox().Name("LockedColumns").Value(Model.LockedColumns))&nbsp;
            </div>
        </div>
        <div style="display:none">
            *Note: This can drastically increase load time for large schedules!
        </div>
    </div>
</div>

<script>

    var SetupItems;

    $(document).ready(function() {
        SetupItems = $('#SetupItems').data('kendoGrid');
        SetupItems.table.kendoSortable({
            filter: '>tbody >tr',
            hint: $.noop,
            cursor: 'move',
            placeholder: function (element) {
                var el = element.clone().addClass('k-state-hover').css('opacity', .65);
                return el;
            },
            container: '#SetupItems tbody',
            change: function (e) {
               //console.log('changed !!!');
                var newIndex = e.newIndex + 1,
                    dataItem = SetupItems.dataSource.getByUid(e.item.data('uid'));
                SetupItems.dataSource.remove(dataItem);
                SetupItems.dataSource.insert(newIndex - 1, dataItem);
                dataItem.set('ColumnOrder', newIndex);
                SetupItems.dataSource.sync();
            }
        });
    });

    $('body').on('change', 'input[name="ShowOnGrid"]', function () {
        var row = $(this).closest('tr');
        var item = SetupItems.dataSource.getByUid($(row).attr('data-uid'));
        if (item) {
            item.set('ShowOnGrid', $(this).is(":checked") ? "True" : "False");
            SetupItems.dataSource.sync();
        }
    }).on('change', 'input[name="DisablePaging"]', function () {
        saveSetting('DisablePaging', $(this).is(":checked"));
    }).on('change', 'input[name="ScheduleDefault"]', function () {
        saveSetting('SCHEDULE_CALC', $(this).val());
    }).on('change', 'input[name="CopyEmployees"]', function () {
        saveSetting('CopyEmployees', $(this).is(":checked"));
    }).on('change', 'input[name="LockedColumns"]', function () {
        saveSetting('LockedColumns', $(this).val());
    });

    function saveSetting(code, value) {
        $.post({
            url: window.appBase + '@Html.Raw(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute)UpdateDefaultScheduleSetting',
            data: { SettingCode: code, SettingValue: value }
        }).always(function (response) {

        });
    }

    function gridRequestEnd(e) {
        if (e.type === 'update') {
            //e.sender.read();
        }
    }
    function gridRequestStart(e) {
       //console.log(e);
    }

</script>

<style>
    h4 {
        text-transform: uppercase;
    }

    label {
        font-weight: normal;
    }

    .k-grid tbody tr {
        cursor: move;
    }
</style>
