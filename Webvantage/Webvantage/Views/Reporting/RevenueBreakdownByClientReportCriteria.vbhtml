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
            <label class="control-label col-sm-3 col-md-2" for="StartPostPeriod">Starting Post Period:</label>
            <div class="col-sm-9">
                @(Html.Kendo().DropDownList().Name("StartPostPeriod").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                         ds.Read("GetPostPeriods", "Reporting")
                                                                                                                                                                                     End Sub).HtmlAttributes(New With {.style = "width: 350px"}).Events(Sub(e)
                                                                                                                                                                                                                                                            e.DataBound("setInitialPostPeriod")
                                                                                                                                                                                                                                                        End Sub))
                @(Html.Kendo().Button().Content("YTD").Name("YTD").HtmlAttributes(New With {.style = "width: 60px;"}).Events(Sub(e) e.Click("postPeriodYTD")))
                @(Html.Kendo().Button().Content("1 Year").Name("1Year").HtmlAttributes(New With {.style = "width: 80px;"}).Events(Sub(e) e.Click("postPeriod1Year")))
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-sm-3 col-md-2" for="EndPostPeriod">Ending Post Period:</label>
            <div class="col-sm-9">
                @(Html.Kendo().DropDownList().Name("EndPostPeriod").Filter("contains").OptionLabel("Please Select").DataTextField("Description").DataValueField("Code").DataSource(Sub(ds)
                                                                                                                                                                                       ds.Read("GetPostPeriods", "Reporting")
                                                                                                                                                                                   End Sub).HtmlAttributes(New With {.style = "width: 350px"}).Events(Sub(e)
                                                                                                                                                                                                                                                          e.DataBound("setInitialPostPeriod")
                                                                                                                                                                                                                                                      End Sub))
                @(Html.Kendo().Button().Content("MTD").Name("MTD").HtmlAttributes(New With {.style = "width: 60px;"}).Events(Sub(e) e.Click("postPeriodMTD")))
                @(Html.Kendo().Button().Content("2 Years").Name("2Years").HtmlAttributes(New With {.style = "width: 80px;"}).Events(Sub(e) e.Click("postPeriod2Years")))
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

    function postPeriodYTD() {
        loadPostPeriodPresetOption(0);
    }
    function postPeriodMTD() {
        loadPostPeriodPresetOption(1);
    }
    function postPeriod1Year() {
        loadPostPeriodPresetOption(2);
    }
    function postPeriod2Years() {
        loadPostPeriodPresetOption(3);
    }
    function loadPostPeriodPresetOption(optionValue) {
        var data = { PresetOption: optionValue };
        $.get({
            url: window.appBase + 'Reporting/LoadPresetPostPeriod',
            data: data
        }).always(function (result) {
            if (result) {
                if (result.PostPeriodStart) {
                    $('#StartPostPeriod').data('kendoDropDownList').value(result.PostPeriodStart);
                }
                if (result.PostPeriodEnd) {
                    $('#EndPostPeriod').data('kendoDropDownList').value(result.PostPeriodEnd);
                }
            }
        });
    }
    function getReportData() {
        var selectedOptions = {
            StartPostPeriod: $('#StartPostPeriod').val(),
            EndPostPeriod: $('#EndPostPeriod').val()
        };
        return selectedOptions;
    }
    function viewReport() {
        var data = getReportData();
        if (data.StartPostPeriod <= data.EndPostPeriod) {
            $.ajax({
                type: 'GET',
                url: '@Url.Action("ViewRevenueBreakdownByClientReport", "Reporting")',
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
            showKendoAlert('Please select a starting post period that is before the ending post period.');
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
