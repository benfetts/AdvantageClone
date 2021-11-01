@ModelType Webvantage.ViewModels.JobForecastModel.ActualizeSettings
@Code
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

@Code   

    If ViewData("Submitted") IsNot Nothing Then

        If ViewData("Submitted") = True Then

            @<script type="text/javascript">

                function CloseThisWindowAndRefreshCaller(callerID) {
                    var caller = callerID;
                    var oWindow;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    if (oWindow) {
                        var manager = oWindow.get_windowManager();
                        var callerWin = manager.getWindowById(caller);
                        if (callerWin) {
                           //console.log('heye')
                            callerWin.setUrl(callerWin.get_navigateUrl());
                        }
                        oWindow.close();
                    }
                }
                CloseThisWindowAndRefreshCaller('@ViewData("opener")');

             </script>
            
        End If
        
    End If
    
End Code

<div style="text-align: center;">
    <div style="margin: 10px auto; display:inline-block; text-align: left;">

        @Using (Html.BeginForm("Actualize", "JobForecast", FormMethod.Post, New With {.ID = "TheForm"}))
            @<div class="form-layout">
                <ul>
                    <li>Post Period End:</li>
                    <li>@(Html.Kendo().ComboBoxFor(Function(m) m.PostPeriodCode) _
                        .DataSource(Sub(d)
                                        d.Read(Sub(s)
                                                   s.Action("GetForecastPostPeriods", "JobForecast", New With {.JobForecastRevisionID = 1})
                                               End Sub)
                                    End Sub) _
                        .DataValueField("Code") _
                        .DataTextField("CodeAndDescription").Height(140)
                    )</li>
                </ul>
                <div>@Html.ValidationMessageFor(Function(m) m.PostPeriodCode)</div>
            </div>
            @<div style="margin-top:10px;" class="form-layout">
                <ul>
                    <li>Roll Forward Balance:</li>
                    <li>@(Html.Kendo().CheckBoxFor(Function(m) m.RollForwardBalances))</li>
                </ul>
            </div>
            @<div style="margin-top:50px; text-align: right;">
                @(Html.Kendo().Button() _
                .Name("Actualize") _
                .Content("Actualize") _
                .Events(Sub(e)
                            e.Click("actualizeClick")
                        End Sub)
                )
            </div>

        End Using

    </div>
</div>
<style type="text/css">
    .form-layout > ul li:first-child {
	    width: 150px;
        text-align: left;
    }
</style>


<script type="text/javascript">
    function actualizeClick(args) {
        showKendoConfirm("Are you sure you want to continue?")
            .done(function () {
                $('#TheForm').submit();
            })
            .fail(function () {
            });
    }
</script>
