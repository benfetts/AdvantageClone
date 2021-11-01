@ModelType Webvantage.ViewModels.UnityMenuModel

@(Html.Kendo().
                ContextMenu().
                Name("UnityMenu").
                Target(Model.TargetTag).
                            Orientation(ContextMenuOrientation.Vertical).
            Items(Sub(item)

                      Dim DoSeparator As Boolean = False

                      If Model.NewAlert.Visible = True Then

                          DoSeparator = True
                          item.Add().Text(Model.NewAlert.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "NewAlert"})

                      End If

                      If Model.NewAssignment.Visible = True Then

                          DoSeparator = True
                          item.Add().Text(Model.NewAssignment.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "NewAssignment"})

                      End If

                      If DoSeparator Then

                          DoSeparator = False
                          item.Add().Separator(True)

                      End If

                      If Model.NewJob.Visible Then

                          item.Add().Text(Model.NewJob.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "NewJob"})
                          item.Add().Separator(True)

                      End If

                      If Model.JobJacket.Visible Then

                          item.Add().Text(Model.JobJacket.Text).
                          Items(Sub(jjItems)

                                    If Model.JobJacketAlerts.Visible Then

                                        jjItems.Add().Text(Model.JobJacketAlerts.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketAlerts"})

                                    End If

                                    If Model.JobJacketDocuments.Visible Then

                                        jjItems.Add().Text(Model.JobJacketDocuments.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketDocuments"})

                                    End If

                                    If Model.JobJacketCreativeBrief.Visible Then

                                        jjItems.Add().Text(Model.JobJacketCreativeBrief.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketCreativeBrief"})

                                    End If

                                    If Model.JobJacketSpecifications.Visible Then

                                        jjItems.Add().Text(Model.JobJacketSpecifications.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketSpecifications"})

                                    End If

                                    If Model.JobJacketVersions.Visible Then

                                        jjItems.Add().Text(Model.JobJacketVersions.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketVersions"})

                                    End If

                                    If Model.JobJacketEstimates.Visible Then

                                        jjItems.Add().Text(Model.JobJacketEstimates.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketEstimates"})

                                    End If

                                    If Model.JobJacketSchedule.Visible Then

                                        jjItems.Add().Text(Model.JobJacketSchedule.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketSchedule"})

                                    End If

                                    If Model.JobJacketBoards.Visible Then

                                        jjItems.Add().Text(Model.JobJacketBoards.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketBoards"})

                                    End If

                                    If Model.JobJacketQvA.Visible Then

                                        jjItems.Add().Text(Model.JobJacketQvA.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketQvA"})

                                    End If

                                    If Model.JobJacketPurchaseOrders.Visible Then

                                        jjItems.Add().Text(Model.JobJacketPurchaseOrders.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketPurchaseOrders"})

                                    End If

                                    If Model.JobJacketEvents.Visible Then

                                        jjItems.Add().Text(Model.JobJacketEvents.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketEvents"})

                                    End If

                                    If Model.JobJacketProofs.Visible Then

                                        jjItems.Add().Text(Model.JobJacketProofs.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketReviews"})

                                    End If

                                    If Model.JobJacketSnapshot.Visible Then

                                        jjItems.Add().Text(Model.JobJacketSnapshot.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacketSnapshot"})

                                    End If

                                End Sub).Url("UnityAction").HtmlAttributes(New With {.Action = "JobJacket"})

                          item.Add().Separator(True)

                      End If

                      If Model.AddTime.Visible Then

                          DoSeparator = True
                          item.Add().Text(Model.AddTime.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "AddTime"})

                      End If

                      If Model.Stopwatch.Visible Then

                          DoSeparator = True
                          item.Add().Text(Model.Stopwatch.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "Stopwatch"})

                      End If

                      If DoSeparator Then

                          DoSeparator = False
                          item.Add().Separator(True)

                      End If

                      If Model.Print.Visible Then

                          item.Add().Text(Model.Print.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "Print"})

                      End If

                      If Model.SendAlert.Visible Then

                          item.Add().Text(Model.SendAlert.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "SendAlert"})

                      End If

                      If Model.SendAssignment.Visible Then

                          item.Add().Text(Model.SendAssignment.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "SendAssignment"})

                      End If

                      If Model.SendEmail.Visible Then

                          item.Add().Text(Model.SendEmail.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "SendEmail"})

                      End If

                      If Model.PrintSendOptions.Visible Then

                          item.Add().Text(Model.PrintSendOptions.Text).Url("UnityAction").HtmlAttributes(New With {.Action = "PrintSendOptions"})

                      End If

                  End Sub).Events(Sub(e)
                                      e.Select("unityMenuItemClick")
                                  End Sub))

<style>
    .k-menu-link:link {
        color: black !important;
        padding-left: 30px !important;
    }

    .k-context-menu{
        width:200px;
    }
</style>

<script type="text/javascript">
    function unityMenuItemClick(e) {
        e.preventDefault();
        var action = $(e.item).attr('Action');
        var url = $(e.item).find('a').attr('href');
        var data = {
            ActionName: action,
            UnityMenuModel: @Html.Raw(Json.Encode(Model))
        };
        $.post({
            url: window.appBase + 'Utilities/' + url,
            data: data
        }).always(function (response) {
            if (response.Success === true) {
                if (response.Data.OpenWindow === true) {
                    if (response.Data.IsSilentOpen === true) {
                        CallPrintSendPageSilently(response.Data.Url);
                    } else {
                        if (action == 'AddTime') {
                            OpenRadWindow('Add Time', response.Data.Url, 600,600);
                        } else if (action == 'Stopwatch') {
                            OpenRadWindow('Timesheet Stopwatch', 'Timesheet_Stopwatch.aspx', 475, 500);
                        } else if (action == 'PrintSendOptions') {
                            OpenRadWindow('Print/Send Project Schedule', response.Data.Url);
                        } else {
                            OpenRadWindow('', response.Data.Url);
                        }                          
                    }
                }
            } else {
                if (response.Message !== '') {
                    showKendoAlert(response.Message);
                }
            }
        });
        
    }
</script>
<style type="text/css">
    #UnityMenu {
        background: white;
    }
</style>
