@ModelType AdvantageFramework.ViewModels.ProjectSchedule.Schedule

<style>
    .form-group {
        margin-left: unset !important;
        margin-right: unset !important;
    }
</style>

<div style="width:100%;display:inline-block;">
    <div style="width:200px;float:left;margin:4px;position:relative">
        <div style="font-weight: bold">Start Date:</div>
        <input id="dateShipped" title="Date Shipped" style="width: 100%" />
    </div>
    <div style="width:200px;float:left;margin:4px;position:relative">
        <div style="font-weight: bold">Received By</div>
        <input id="ReceivedBy" title="Received By" style="width: 100%" />
    </div>
    <div style="position:relative"></div>
    <div style="width:200px;float:left;margin:4px;position:relative">
        <div style="font-weight: bold">Date Delivered</div>
        <input id="dateDelivered" title="Date Delivered" style="width: 100%" />
    </div>

    <div style="width:200px;float:left;margin:4px;position:relative">
        <div style="font-weight: bold">Reference</div>
        <input id="Reference" title="Reference" style="width: 100%" />
    </div>
</div>
<script>

    var otherInformationChange = false;

    $(() => {
        $("#dateShipped").kendoDatePicker({
            change: onDateShippedChange
        }).data("kendoDatePicker");
        $("#dateDelivered").kendoDatePicker({
            change: onDateDeliveredChange
        }).data("kendoDatePicker");

        $('#ReceivedBy').change(onOtherInfoChange);
        $('#Reference').change(onOtherInfoChange);


        $('#saveButton').on('click', saveOtherInfo);
        $('#cancelButton').on('click', loadOtherInfo);
        $('#refreshProjectSchedule').on('click', loadOtherInfo);

        loadOtherInfo();
    });

    function saveOtherInfo(e) {
        if (otherInformationChange === true) {
            var DateShipped;
            var ReceivedBy;
            var DateDelivered;
            var Reference;

            var datePicker = $("#dateShipped").data("kendoDatePicker");
            DateShipped = datePicker.value();
            datePicker = $("#dateDelivered").data("kendoDatePicker");
            DateDelivered = datePicker.value();

            ReceivedBy = $('#ReceivedBy').val()
            Reference = $('#Reference').val()

            $.ajax({
                type: "Post",
                url: "@Href("~/ProjectManagement/ProjectSchedule/PutOtherInformation")",
                data: {
                    JobNumber: @Model.JobNumber,
                    JobComponentNumber: @Model.JobComponentNumber,
                    DateShipped: DateShipped,
                    ReceivedBy: ReceivedBy,
                    DateDelivered: DateDelivered,
                    Reference: Reference
                },
                dataType: "json",
                success: function (response) {
                    otherInformationChange = false;
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    var msg = '';
                    if (jqXHR.status === 0) {
                        msg = 'Not connect.\n Verify Network.';
                    } else if (jqXHR.status == 404) {
                        msg = 'Requested page not found. [404]';
                    } else if (jqXHR.status == 500) {
                        msg = 'Internal Server Error [500].';
                    } else if (textStatus === 'parsererror') {
                        msg = 'Requested JSON parse failed.';
                    } else if (textStatus === 'timeout') {
                        msg = 'Time out error.';
                    } else if (textStatus === 'abort') {
                        msg = 'Ajax request aborted.';
                    } else {
                        msg = 'Uncaught Error.\n' + jqXHR.responseText;
                    }
                    showKendoAlert(msg + errorThrown);
                }
            });
            otherInformationChange = false;
            setSave();
        }
    }

    function loadOtherInfo(e) {

        $.ajax({
            type: "Get",
            url: "@Href("~/ProjectManagement/ProjectSchedule/GetOtherInformation")",
            data: {
                JobNumber: @Model.JobNumber,
                JobComponentNumber: @Model.JobComponentNumber
            },
            dataType: "json",
            success: function (response) {

                var datePicker = $("#dateShipped").data("kendoDatePicker");
                datePicker.value(response.DateShipped);
                datePicker = $("#dateDelivered").data("kendoDatePicker");
                datePicker.value(response.DateDelivered);

                $('#ReceivedBy').val(response.ReceivedBy);
                $('#Reference').val(response.Reference);
            }
        });

        otherInformationChange = false;
        setSave();
    }

    function onDateShippedChange(e) {
        otherInformationChange = true;
        setSave();
    }

    function onDateDeliveredChange(e) {
        otherInformationChange = true;
        setSave();
    }

    function onOtherInfoChange() {
        otherInformationChange = true;
        setSave();
    }


</script>
