@ModelType Webvantage.ViewModels.MediaManager.OrderFormViewModel
@Code
    ViewData("Title") = "Order Form"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
<div class="panel-heading bg-primary">
    <div class="panel-title" style="text-align:center">
        @If Model.IsQuote Then

            @<h2>Quote Request From @Html.DisplayFor(Function(M) M.AgencyName)</h2>

        Else

            If Model.MediaType = "M" OrElse Model.MediaType = "N" Then

                @<h2>Insertion Order From @Html.DisplayFor(Function(M) M.AgencyName)</h2>

            Else

                @<h2>Order From @Html.DisplayFor(Function(M) M.AgencyName)</h2>

            End If

        End If
    </div>
</div>
End Section
<br />
<style>
    .form-group .control-label, .form-group .form-control-static, panel-body, span, .form-group label{
        font-family: Verdana !important;
        font-size: 10pt;
        font-weight: normal;
    }
    #instrutions-container h4 {
        border-color: transparent;
    }
    .form-group input {
        min-height: 30px;
        font-size: 10pt;
    }

    h2, h3, h4, body, html, table, th, td {
        font-family: Verdana !important;
    }
    .modal-dialog {
        z-index: 9999;
    }
    .alert {
        margin: 4px 8px 17px 8px;
    }

    h2 {
        font-size: 24px;
    }
    .btn {
        border-radius: 4px;
        padding: 6px 12px;
    }
   
</style>
@If Model.IsValid = False Then

    @<div class="alert alert-danger">
        <strong>Invalid order requested.</strong>
    </div>

Else

    If Model.InDifferentOrderState Then

        @<div class="alert alert-danger">
            <strong>The order requested is not valid anymore.</strong>
        </div>

    Else

        Using Html.BeginForm("OrderForm", "MediaManager", New With {.QueryString = Model.QueryString}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

            @Html.AntiForgeryToken()

            @<div id="instrutions-container" class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title"><h4>Instructions</h4></div>
                </div>
                <div class="panel-body">
                    <div>
                        @Ajax.ActionLink("View Order", "DownloadOrderDocument", New With {.QueryString = Model.QueryString}, New AjaxOptions With {.HttpMethod = "Post"})
                        @If Model.HasRelatedDocuments Then
                            @<text>&nbsp;&nbsp;&nbsp;</text>
                            @Ajax.ActionLink("Download Related Documents", "DownloadOrderRelatedDocuments", New With {.QueryString = Model.QueryString}, New AjaxOptions With {.HttpMethod = "Post"})
                        End If

                        <br />
                        <br />
                        <text>
                            <span class="badge" style="width:75px; padding: 6px 0;">Step 1</span><span style="padding-left:2em"></span>Enter or verify the cost of the ad in the spaces provided below.<br />
                        </text>
                        <br />
                        <span class="badge" style="width:75px; padding: 6px 0;">Step 2</span><span style="padding-left:2em"></span>Click on Terms of Agreement to acknowledge that you have read and agree to the terms.<br />
                        <br />
                        <span class="badge" style="width:75px; padding: 6px 0;">Step 3</span><span style="padding-left:2em"></span>Click Submit to complete the process and notify the Agency.<br />
                        <br />
                        <span class="badge" style="width:75px; padding: 6px 0;">NOTICE</span><span style="color:red;padding-left:2em"></span>If you then have problems viewing the order or entering required information, contact <b>@Model.ContactName</b> at <b>@Model.ContactNumber</b> immediately.



                    </div>
                </div>
            </div>

            @Html.ValidationSummary(False, "", New With {.style = "color:red"})

            @Html.HiddenFor(Function(M) Model.IsValid)
            @Html.HiddenFor(Function(M) Model.ContactName)
            @Html.HiddenFor(Function(M) Model.ContactNumber)
            @Html.HiddenFor(Function(M) Model.HasRelatedDocuments)
            @Html.HiddenFor(Function(M) Model.ClientName)
            @Html.HiddenFor(Function(M) Model.OrderComments)
            @Html.HiddenFor(Function(M) Model.TermsOfAgreement)
            @Html.HiddenFor(Function(M) Model.OrderNumber)
            @Html.HiddenFor(Function(M) Model.InDifferentOrderState)
            @Html.HiddenFor(Function(M) Model.UserCode)
            @Html.HiddenFor(Function(M) Model.MediaManagerGeneratedReportID)
            @Html.HiddenFor(Function(M) Model.IsQuote)
            @Html.HiddenFor(Function(M) Model.MediaType)

            @<div class="row">
                <div Class="page-header">
                    <h3>
                        Order Details
                    </h3>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px">
                        @Html.DisplayNameFor(Function(M) M.ClientName):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.DisplayFor(Function(M) M.ClientName)
                    </div>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px">
                        @Html.DisplayNameFor(Function(M) M.OrderComments):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.DisplayFor(Function(M) M.OrderComments)
                    </div>
                </div>
            </div>
            @<div class="page-header">
                <h3>
                    Order Information
                </h3>
            </div>
            @<table id="OrderDetails" class="table table-striped table-bordered table-condensed">
                <tbody>
                    @Code
                        Dim DetailCounter As Integer = 0
                        For DetailCounter = 0 To Model.OrderFormDetails.Count - 1
                            @<tr id="OrderDetails_@DetailCounter">
                                 <td>
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).OrderNumber)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).LineNumber)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).RevisionNumber)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).RunDates)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).IsCancellation)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).HasRelatedDocuments)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).InDifferentOrderState)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).IsNetAmount)
                                     @Html.HiddenFor(Function(M) Model.OrderFormDetails(DetailCounter).CurrencySymbol)
                                     <div class="form-group">
                                         <label class="col-md-2 control-label">
                                             Order/Line Number:
                                         </label>
                                         <div class="col-md-2 form-control-static">
                                             @Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).OrderNumber) - @Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).LineNumber)
                                         </div>
                                         <label class="col-md-2 control-label">
                                             Revision Number:
                                         </label>
                                         <div class="col-md-2 form-control-static">
                                             @Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).RevisionNumber)
                                         </div>
                                     </div>
                                     <div class="form-group">
                                         <label class="col-md-2 control-label">
                                             Run Dates:
                                         </label>
                                         <div class="col-md-2 form-control-static">
                                             @Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).RunDates)
                                         </div>
                                         <label class="col-md-2 control-label">
                                             Is Cancellation:
                                         </label>
                                         <div class="col-md-2 form-control-static">
                                             @If Model.OrderFormDetails(DetailCounter).IsCancellation Then
                                                 @<span class="label label-info control-label">YES</span>
                                             Else
                                                 @<span class="label label-info control-label">NO</span>
                                             End If
                                         </div>
                                     </div>

                                     @If Model.OrderFormDetails(DetailCounter).IsNetAmount = False Then
                                         @<div class="form-group">
                                             <label class="col-md-2 control-label">
                                                 Gross Amount:
                                             </label>
                                             @If Model.OrderFormDetails(DetailCounter).IsCancellation Then
                                                 @<div class="col-md-2 form-control-static">
                                                     @Html.Raw(Model.OrderFormDetails(DetailCounter).CurrencySymbol)@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).GrossAmount)
                                                 </div>
                                             Else
                                                 If Model.OrderFormDetails(DetailCounter).HasBeenSubmitted Then
                                                     @<div class="col-md-2 form-control-static">
                                                         @Html.Raw(Model.OrderFormDetails(DetailCounter).CurrencySymbol)@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).GrossAmount)
                                                     </div>
                                                 Else
                                                     @<div class="col-md-2">
                                                         @Html.Kendo().NumericTextBoxFor(Function(M) Model.OrderFormDetails(DetailCounter).GrossAmount).Events(Function(E) E.Change("GrossAmountChange").Spin("GrossAmountSpin")).HtmlAttributes(New With {.style = "width:100%", .rowID = DetailCounter})
                                                     </div>
                                                 End If
                                             End If
                                             <label class="col-md-2 control-label">
                                                 Commission Pct:
                                             </label>
                                             <div class="col-md-2">
                                                 @If Model.OrderFormDetails(DetailCounter).HasBeenSubmitted Then
                                                     @Html.Kendo().NumericTextBoxFor(Function(M) Model.OrderFormDetails(DetailCounter).CommissionPercentage).Events(Function(E) E.Change("CommissionPercentageChange").Spin("CommissionPercentageSpin")).HtmlAttributes(New With {.style = "width:100%", .rowID = DetailCounter}).Min(0).Max(100).Step(1).Format("#.## \%").Enable(False)
                                                 Else
                                                     @Html.Kendo().NumericTextBoxFor(Function(M) Model.OrderFormDetails(DetailCounter).CommissionPercentage).Events(Function(E) E.Change("CommissionPercentageChange").Spin("CommissionPercentageSpin")).HtmlAttributes(New With {.style = "width:100%", .rowID = DetailCounter}).Min(0).Max(100).Step(1).Format("#.## \%").Enable((Model.OrderFormDetails(DetailCounter).IsCancellation = False))
                                                 End If
                                             </div>
                                         </div>
                                     End If
                                     <div class="form-group">
                                         <label class="col-md-2 control-label">
                                             Net Amount:
                                         </label>
                                         @If Model.OrderFormDetails(DetailCounter).IsCancellation Then
                                             @<div class="col-md-2 form-control-static">
                                                 @Html.Raw(Model.OrderFormDetails(DetailCounter).CurrencySymbol)@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).NetAmount)
                                             </div>
                                         Else
                                             @If Model.OrderFormDetails(DetailCounter).HasBeenSubmitted Then
                                                 @<div class="col-md-2 form-control-static">
                                                     @Html.Raw(Model.OrderFormDetails(DetailCounter).CurrencySymbol)@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).NetAmount)
                                                 </div>
                                             Else
                                                 @<div class="col-md-2">
                                                     @Html.Kendo().NumericTextBoxFor(Function(M) Model.OrderFormDetails(DetailCounter).NetAmount).Events(Function(E) E.Change("NetAmountChange").Spin("NetAmountSpin")).HtmlAttributes(New With {.style = "width:100%", .rowID = DetailCounter})
                                                 </div>
                                             End If
                                         End If
                                     </div>

                                     @If Model.OrderFormDetails(DetailCounter).HasBeenSubmitted Then
                                         @<div Class="form-group">
                                             @If Model.OrderFormDetails(DetailCounter).IsCancellation Then
                                                 @<div class="alert alert-success">
                                                     <strong>Thank you for confirming the cancellation of this order.</strong>
                                                 </div>
                                             ElseIf String.IsNullOrWhiteSpace(Model.OrderFormDetails(DetailCounter).CardNumber) = False Then
                                                 @<div class="col-md-12">
                                                     <div class="panel panel-success">
                                                         <div class="panel-heading">
                                                             <div class="panel-title"><h4>Thank you for submitting!</h4></div>
                                                         </div>
                                                         <div class="panel-body">
                                                             <strong> Please Charge the Following Credit Card:</strong><br />
                                                             <br />
                                                             <br />
                                                             <div class="col-md-2"><strong>Charge To:</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToName)<br />
                                                             <div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToAddress)<br />
                                                             @If String.IsNullOrWhiteSpace(Model.OrderFormDetails(DetailCounter).ChargeToAddress2) = False Then
                                                                 @<text><div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToAddress2)<br /></text>
                                                             End If
                                                             <div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToCity),&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToState)&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).ChargeToZip)<br />
                                                             <br />
                                                             <br />
                                                             <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.OrderFormDetails(DetailCounter).CardNumber)</strong></div>&nbsp;&nbsp;&nbsp;@Html.Encode("MasterCard " & Model.OrderFormDetails(DetailCounter).CardNumber.Substring(0, 4) & "-" & Model.OrderFormDetails(DetailCounter).CardNumber.Substring(4, 4) & "-" & Model.OrderFormDetails(DetailCounter).CardNumber.Substring(8, 4) & "-" & Model.OrderFormDetails(DetailCounter).CardNumber.Substring(12, 4))<br />
                                                             <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.OrderFormDetails(DetailCounter).CardExpirationDate)</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).CardExpirationDate)<br />
                                                             <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.OrderFormDetails(DetailCounter).CardCVCCode)</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.OrderFormDetails(DetailCounter).CardCVCCode)<br />
                                                         </div>
                                                     </div>
                                                 </div>
                                             Else
                                                 @<div class="alert alert-success">
                                                     <strong>Thank you for submitting this order.</strong>
                                                 </div>
                                             End If
                                         </div>
                                     End If

                                 </td>
                            </tr>
                        Next DetailCounter
                    End Code

                </tbody>
            </table>

            @<div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                </div>
            </div>
            @<div class="row">
                <div class="form-group">
                    <label class="col-md-2 control-label" style="padding-right:8px">
                        @Html.DisplayNameFor(Function(M) M.AuthorizedBy):
                    </label>
                    @If Model.HasBeenSubmitted Then
                        @<div class="col-md-10 form-control-static">
                            @Html.DisplayFor(Function(M) M.AuthorizedBy)
                        </div>
                    Else
                        @<div class="col-md-10">
                            @Html.TextBoxFor(Function(M) M.AuthorizedBy, New With {.class = "form-control"})
                        </div>
                    End If
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" style="padding-right:8px">
                        @Html.DisplayNameFor(Function(M) M.Notes):
                    </label>
                    @If Model.HasBeenSubmitted Then
                        @<div class="col-md-10 form-control-static">
                            @Html.DisplayFor(Function(M) M.Notes)
                        </div>
                    Else
                        @<div class="col-md-10">
                            @Html.TextAreaFor(Function(M) M.Notes, New With {.class = "form-control", .style = "width: 100%; min-height: 120px;"})
                        </div>
                    End If
                </div>
            </div>
            @<div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                </div>
            </div>
            @<div class="text-center">
                <div class="row">
                    <div class="col-md-12">
                        <div class="form-group">
                            <label>
                                @Html.DisplayNameFor(Function(M) M.TermsOfAgreement) - <a href="#TermsOfAgreementModal" data-toggle="modal">Click Here</a>
                            </label>
                        </div>
                        <div class="form-group">
                            @Html.Kendo().CheckBoxFor(Function(M) M.AcceptTermsOfAgreement).Enable(Not Model.HasBeenSubmitted).Label(Html.DisplayNameFor(Function(M) M.AcceptTermsOfAgreement).ToString)
                        </div>
                        <div class="form-group">
                            @If Model.HasBeenSubmitted Then
                                @<button class="btn btn-lg btn-primary" type="submit" value="OrderForm" disabled>Submit</button>
                            Else
                                @<button class="btn btn-lg btn-primary" type="submit" value="OrderForm">Submit</button>
                            End If
                        </div>
                    </div>
                </div>
            </div>
            @<div id="TermsOfAgreementModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title" style="border-color: transparent;">@Html.DisplayNameFor(Function(M) M.TermsOfAgreement)</h4>
                        </div>
                        <div class="modal-body">
                            <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
                                @Model.TermsOfAgreement
                            </p>
                        </div>
                        <div class="modal-footer no-padding">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>
                </div>
            </div>

                                End Using

                            End If

                        End If

<script>

    function GrossAmountChange() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        NetAmount.value(GrossAmount.value() - (GrossAmount.value() * (CommissionPercentage.value() / 100)));

    }
    function GrossAmountSpin() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        NetAmount.value(GrossAmount.value() - (GrossAmount.value() * (CommissionPercentage.value() / 100)));

    }
    function CommissionPercentageChange() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        NetAmount.value(GrossAmount.value() - (GrossAmount.value() * (CommissionPercentage.value() / 100)));

    }
    function CommissionPercentageSpin() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        NetAmount.value(GrossAmount.value() - (GrossAmount.value() * (CommissionPercentage.value() / 100)));

    }
    function NetAmountChange() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        if (NetAmount.value() == 0) {

            GrossAmount.value(0);
            CommissionPercentage.value(0);

        } else {

            var Dominator = (-1 * (CommissionPercentage.value() / 100)) + 1;

            GrossAmount.value(NetAmount.value() / Dominator);

        }

    }
    function NetAmountSpin() {

        var NetAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__NetAmount").getKendoNumericTextBox();
        var GrossAmount = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__GrossAmount").getKendoNumericTextBox();
        var CommissionPercentage = $("#OrderFormDetails_" + +this.wrapper.context.attributes.getNamedItem("rowid").value + "__CommissionPercentage").getKendoNumericTextBox();

        if (NetAmount.value() == 0) {

            GrossAmount.value(0);
            CommissionPercentage.value(0);

        } else {

            var Dominator = (-1 * (CommissionPercentage.value() / 100)) + 1;

            GrossAmount.value(NetAmount.value() / Dominator);

        }
    }
</script>
