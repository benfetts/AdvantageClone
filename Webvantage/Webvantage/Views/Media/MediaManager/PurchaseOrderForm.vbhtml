@ModelType Webvantage.ViewModels.MediaManager.PurchaseOrderFormViewModel
@Code
    ViewData("Title") = "Purchase Order Form"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>Purchase Order From @Html.DisplayFor(Function(M) M.AgencyName)</h2>
        </div>
    </div>
End Section
<br />
<style>
    h2, h3, h4 {
        font-family: Verdana !important;
    }

    .form-group .control-label, .form-group .form-control-static {
        font-family: Verdana !important;
        font-size: 10pt;
    }
    h2 {
        font-size: 24px;
    }
</style>

@If Model.IsValid = False Then

    @<div class="alert alert-danger">
        <strong>Invalid purchase order requested.</strong>
    </div>

Else

    If Model.InDifferentOrderState Then

        @<div class="alert alert-danger">
            <strong>The purchase order requested is not valid anymore.</strong>
        </div>

    Else

        Using Html.BeginForm("PurchaseOrderForm", "MediaManager", New With {.QueryString = Model.QueryString}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})

            @Html.AntiForgeryToken()

            @<div class="panel panel-info">
                <div class="panel-heading">
                    <div class="panel-title"><h4>Instructions</h4></div>
                </div>
                <div class="panel-body">
                    <div>
                        @Ajax.ActionLink("View Order", "DownloadPurchaseOrderDocument", New With {.QueryString = Model.QueryString}, New AjaxOptions With {.HttpMethod = "Post"})
                        @*@If Model.HasRelatedDocuments Then
                                @<text>&nbsp;&nbsp;&nbsp;</text>
                                @Ajax.ActionLink("Download Related Documents", "DownloadOrderRelatedDocuments", New With {.QueryString = Model.QueryString}, New AjaxOptions With {.HttpMethod = "Post"})
                            End If*@
                        <br />
                        <br />
                        <text>
                            <span class="badge" style="width:75px">Step 1</span><span style="padding-left:2em"></span>Review and verify the cost.<br />
                        </text>
                        <br />
                        <span class="badge" style="width:75px">Step 2</span><span style="padding-left:2em"></span>Click on Terms of Agreement to acknowledge that you have read and agree to the terms.<br />
                        <br />
                        <span class="badge" style="width:75px">Step 3</span><span style="padding-left:2em"></span>Click Submit to complete the process and notify the Agency.<br />
                        <br />
                        <span class="badge" style="width:75px">NOTICE</span><span style="color:red;padding-left:2em"></span>If you then have problems viewing the purchase order, contact <b>@Model.ContactName</b> at <b>@Model.ContactNumber</b> immediately.
                    </div>
                </div>
            </div>

            @Html.ValidationSummary(False, "", New With {.style = "color:red"})

            @Html.HiddenFor(Function(M) Model.IsValid)
            @Html.HiddenFor(Function(M) Model.ContactName)
            @Html.HiddenFor(Function(M) Model.ContactNumber)
            @*@Html.HiddenFor(Function(M) Model.HasRelatedDocuments)*@
            @Html.HiddenFor(Function(M) Model.VendorName)
            @Html.HiddenFor(Function(M) Model.TermsOfAgreement)
            @Html.HiddenFor(Function(M) Model.PONumber)
            @Html.HiddenFor(Function(M) Model.InDifferentOrderState)
            @Html.HiddenFor(Function(M) Model.UserCode)
            @Html.HiddenFor(Function(M) Model.MediaManagerGeneratedPOReportID)
            @Html.HiddenFor(Function(M) Model.PONumber)
            @Html.HiddenFor(Function(M) Model.PODescription)
            @Html.HiddenFor(Function(M) Model.IssueDate)
            @Html.HiddenFor(Function(M) Model.DueDate)
            @Html.HiddenFor(Function(M) Model.Originator)
            @Html.HiddenFor(Function(M) Model.POTotal)
            @Html.HiddenFor(Function(M) Model.RevisionNumber)

            @<div class="row">
                <div Class="page-header">
                    <h3>
                        Order Information
                    </h3>
                </div>
                <table id="OrderDetails" class="table table-striped table-bordered table-condensed">
                    <tbody>
                        <tr id="OrderInfo">
                            <td>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        Vendor Name:
                                    </label>
                                    <div class="col-md-2 form-control-static">
                                        @Html.DisplayFor(Function(M) Model.VendorName)
                                    </div>
                                    <label class="col-md-2 control-label">
                                        Originator:
                                    </label>
                                    <div class="col-md-2 form-control-static">
                                        @Html.DisplayFor(Function(M) Model.Originator)
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        PO Number:
                                    </label>
                                    @If Model.RevisionNumber.HasValue AndAlso Model.RevisionNumber.Value > 0 Then
                                        @<div class="col-md-2 form-control-static">
                                            @Html.DisplayFor(Function(M) Model.PONumber) REV @Html.DisplayFor(Function(M) Model.RevisionNumber)
                                        </div>
                                    Else
                                        @<div Class="col-md-2 form-control-static">
                                            @Html.DisplayFor(Function(M) Model.PONumber)
                                        </div>
                                    End If
                                    <label class="col-md-2 control-label">
                                        Issue Date:
                                    </label>
                                    <div class="col-md-2 form-control-static">
                                        @Html.DisplayFor(Function(M) Model.IssueDate)
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        Description:
                                    </label>
                                    <div class="col-md-2 form-control-static">
                                        @Html.DisplayFor(Function(M) Model.PODescription)
                                    </div>
                                    @If Model.DueDate.HasValue Then
                                        @<Label Class="col-md-2 control-label">
                                            Due Date:
                                        </Label>
                                        @<div class="col-md-2 form-control-static">
                                            @Html.DisplayFor(Function(M) Model.DueDate)
                                        </div>
                                    End If
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">
                                        PO Total:
                                    </label>
                                    <div class="col-md-2 form-control-static">
                                        @Html.DisplayFor(Function(M) Model.POTotal)
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            @<div class="page-header">
                <h3>
                    Order Details
                </h3>
            </div>
            @<table id="OrderDetails" class="table table-striped table-bordered table-condensed">
                <tbody>
                    <tr>
                        <td>Item Description</td>
                        <td>Client Name</td>
                        <td>Job / Component Number</td>
                        <td>QTY</td>
                        <td>Rate</td>
                        <td>Amount</td>
                    </tr>
                    @Code
                        Dim DetailCounter As Integer = 0
                        For DetailCounter = 0 To Model.PurchaseOrderFormDetails.Count - 1
                            @<tr id="OrderDetails_@DetailCounter">
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Description)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).ClientName)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).JobNumber)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).JobComponentNumber)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Quantity)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Rate)
                                @Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Amount)
                                @*@Html.HiddenFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).InDifferentOrderState)*@
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Description)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).ClientName)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).JobNumber) - @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).JobComponentNumber)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Quantity)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Rate)
                                </td>
                                <td>
                                    @Html.DisplayFor(Function(M) Model.PurchaseOrderFormDetails(DetailCounter).Amount)
                                </td>
                            </tr>
                        Next DetailCounter
                    End Code
                </tbody>
            </table>
            @If Model.HasBeenSubmitted Then
                @<div Class="form-group">
                    @If String.IsNullOrWhiteSpace(Model.CardNumber) = False Then
                        @<div class="col-md-12">
                            <div class="panel panel-success">
                                <div class="panel-heading">
                                    <div class="panel-title"><h4>Thank you for submitting!</h4></div>
                                </div>
                                <div class="panel-body">
                                    <strong> Please Charge the Following Credit Card:</strong><br />
                                    <br />
                                    <br />
                                    <div class="col-md-2"><strong>Charge To:</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToName)<br />
                                    <div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToAddress)<br />
                                    @If String.IsNullOrWhiteSpace(Model.ChargeToAddress2) = False Then
                                        @<text><div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToAddress2)<br /></text>
                                    End If
                                    <div class="col-md-2">&nbsp;</div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToCity),&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToState)&nbsp;@Html.DisplayFor(Function(M) Model.ChargeToZip)<br />
                                    <br />
                                    <br />
                                    <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.CardNumber)</strong></div>&nbsp;&nbsp;&nbsp;@Html.Encode("MasterCard " & Model.CardNumber.Substring(0, 4) & "-" & Model.CardNumber.Substring(4, 4) & "-" & Model.CardNumber.Substring(8, 4) & "-" & Model.CardNumber.Substring(12, 4))<br />
                                    <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.CardExpirationDate)</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.CardExpirationDate)<br />
                                    <div class="col-md-2"><strong>@Html.DisplayNameFor(Function(M) Model.CardCVCCode)</strong></div>&nbsp;&nbsp;&nbsp;@Html.DisplayFor(Function(M) Model.CardCVCCode)<br />
                                </div>
                            </div>
                        </div>
                    Else
                        @<div class="alert alert-success">
                            <strong>Thank you for submitting this purchase order.</strong>
                        </div>
                    End If
                </div>
            End If

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
                                @<button class="btn btn-lg btn-primary" type="submit" value="PurchaseOrderForm" disabled>Submit</button>
                            Else
                                @<button class="btn btn-lg btn-primary" type="submit" value="PurchaseOrderForm">Submit</button>
                            End If
                        </div>
                    </div>
                </div>
            </div>
            @<div id="TermsOfAgreementModal" class="modal fade">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">@Html.DisplayNameFor(Function(M) M.TermsOfAgreement)</h4>
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

