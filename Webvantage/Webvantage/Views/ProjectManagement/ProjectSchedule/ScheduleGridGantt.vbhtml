@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
</style>

<div>

    <div id="ScheduleWrap" style="height: calc(100vh - 425px);">
        @Html.Partial("ejProjectScheduleGrid", Model)
    </div>
    <div id="GanttWrapper" style="height: calc(100vh - 425px);">
        @Html.Partial("ScheduleGantt", Model)
    </div>
</div>

<script>

    $(() => {
        setTimeout(() => {
            $(window).trigger('resize');
        }, 800);
    })

    function ganttClick() {
        $('#ScheduleWrap').hide();
        $('#GanttWrapper').show();

        resizeGantt();
    }

    function gridClick() {
        $('#GanttWrapper').hide();
        $('#ScheduleWrap').show();

        resizeGrid();
    }

    $(window).resize((e) => {
        console.log(e);

        el = $('#GridToolBar');
        var bottom = el.offset().top + el.outerHeight(true)
        var viewHeight = $(window).height();

        $('#ScheduleWrap').height(viewHeight - bottom - 45);
        $('#GanttWrapper').height(viewHeight - bottom - 45);

        resizeGrid();
        resizeGantt();
    });

</script>
