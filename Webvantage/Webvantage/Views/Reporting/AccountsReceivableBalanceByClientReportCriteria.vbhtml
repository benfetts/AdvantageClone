@ModelType Object
@Code
    ViewData("IsFullLayout") = True
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<style type="text/css">
    .k-checkbox-label {
        font-weight: normal;
    }
</style>

<div style="margin-top: 10px;">
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-3 col-md-2" for="EndPostPeriod">Ending Post Period:</label>
            <div class="col-sm-9">
                @(Html.Kendo().DropDownList().Name("EndPostPeriod").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                       ds.Read("GetPostPeriods", "Reporting")
                                                                                                                                                                                   End Sub).HtmlAttributes(New With {.style = "width: 350px"}).Events(Sub(e)
                                                                                                                                                                                                                                                          e.DataBound("setInitialPostPeriod")
                                                                                                                                                                                                                                                      End Sub))
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-3 col-md-2" for="EndPostPeriod">Record Source:</label>
            <div class="col-sm-9">
                @(Html.Kendo().DropDownList().Name("RecordSource").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                      ds.Read("GetRecordSources", "Reporting")
                                                                                                                                                                                  End Sub).HtmlAttributes(New With {.style = "width: 350px"}))
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-3 col-sm-9">
                @(Html.Kendo().Button().Name("ViewReport").Content("OK").HtmlAttributes(New With {.style = "width: 100px"}).Events(Sub(e) e.Click("viewReport")))
                @(Html.Kendo().Button().Name("Cancel").Content("Cancel").HtmlAttributes(New With {.style = "width: 100px"}).Events(Sub(e) e.Click("closeWindow")))
            </div>
        </div>
    </div>
</div>

<script>
    
    function getReportData() {
        var recordSource = $('#RecordSource').val();
        if (recordSource !== '') {
            recordSource = Number(recordSource);
        } else {
            recordSource = 0;
        }
        var selectedOptions = {
            EndPostPeriod: $('#EndPostPeriod').val(),
            RecordSource: recordSource
        };
        return selectedOptions;
    }
    function viewReport() {
        var data = getReportData();
        if (data.EndPostPeriod) {
            $.ajax({
                type: 'GET',
                url: '@Url.Action("ViewAccountsReceivableBalanceByClientReport", "Reporting")',
                data: data,
                dataType: 'json'
            }).done(function (result) {
                RefreshWindow(result.url, true, true);
                CloseThisWindow();
            }).fail(function (result) {
               //console.log(result);
                showKendoAlert('Something went terribly wrong!');
            });
        } else {
            showKendoAlert('Please select an ending post period.');
        }
    }
    function setInitialPostPeriod(e) {
        $.each(e.sender.dataItems(), function () {
            if (this.IsCurrent === true) {
                e.sender.value(this.Code);
            }
        });
    }

</script>
