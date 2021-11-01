@ModelType Webvantage.ViewModels.MediaManager.RequestForProposalFormViewModel
@Code       
    ViewData("Title") = "Request for Proposal Form"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>Request for Proposal From @Html.DisplayFor(Function(M) M.AgencyName)</h2>
        </div>
    </div>
End Section
<br />
@If Model.IsValid = False Then
    @<div class="alert alert-danger">
        <strong>Invalid Request for Proposal requested.</strong>
    </div>

Else

    If Model.InDifferentOrderState Then
        @<div class="alert alert-danger">
            <strong>The request for proposal requested is not valid anymore.</strong>
        </div>

    Else

        Using Html.BeginForm("RequestForProposalForm", "MediaManager", New With {.QueryString = Model.QueryString}, FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})
            @Html.AntiForgeryToken()


            @Html.ValidationSummary(False, "", New With {.style = "color:red"})

            @Html.HiddenFor(Function(M) Model.Subject)
            @Html.HiddenFor(Function(M) Model.Body)
            @Html.HiddenFor(Function(M) Model.CommentToVendor)
            @Html.HiddenFor(Function(M) Model.FilesUploaded)
            @Html.HiddenFor(Function(M) Model.IsValid)
            @Html.HiddenFor(Function(M) Model.InDifferentOrderState)
            @Html.HiddenFor(Function(M) Model.UserCode)

            @<div class="row">
                <div Class="page-header">
                    <h3>
                        Request for Proposal
                    </h3>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px;">
                        @Html.DisplayNameFor(Function(M) M.Subject):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px;">
                        @Html.DisplayFor(Function(M) M.Subject)
                    </div>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px;">
                        @Html.DisplayNameFor(Function(M) M.Body):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.Raw(Model.Body)
                    </div>
                </div>
                <div Class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px;">
                        @Html.DisplayNameFor(Function(M) M.CommentToVendor):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.DisplayFor(Function(M) M.CommentToVendor)
                    </div>
                </div>
            </div>
            @<div class="page-header">
                <h3>
                    Comments
                </h3>
            </div>

            @If Not Model.HasBeenSubmitted Then
                @<div class="form-group">
                    <Label Class="col-md-2 control-label" style="padding-right:8px">
                        @Html.DisplayNameFor(Function(M) M.Comment):
                    </Label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @Html.TextAreaFor(Function(M) M.Comment, New With {.class = "form-control", .required = "required", .pattern = ".*\S+.*", .title = "This field is required", .rows = 4})
                    </div>
                    <label class="col-md-2 control-label" style="padding-right:8px">
                        Selected Files:
                    </label>
                    <div Class="col-md-10 form-control-static" style="padding-left:22px">
                        @(Html.Kendo().Upload.Name("UploadFiles").Multiple(True))
                    </div>
                </div>
            End If

            @<div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                    </div>
                </div>
            </div>
            @<div class="text-center">
                <div class="row">
                    <div class="col-md-12">
                        @*<div class="form-group">
                                <label>
                                    @Html.DisplayNameFor(Function(M) M.TermsOfAgreement) - <a href="#TermsOfAgreementModal" data-toggle="modal">Click Here</a>
                                </label>
                            </div>
                            <div class="form-group">
                                @Html.Kendo().CheckBoxFor(Function(M) M.AcceptTermsOfAgreement).Enable(Not Model.HasBeenSubmitted).Label(Html.DisplayNameFor(Function(M) M.AcceptTermsOfAgreement).ToString)
                            </div>*@
                        <div class="form-group">
                            @If Model.HasBeenSubmitted AndAlso Model.FilesUploaded Then
                                @<div class="alert alert-success">
                                    <strong>Thank you for submitting your response and file(s).</strong>
                                </div>
                                @<button class="btn btn-lg btn-primary" type="submit" value="RequestForProposalForm" disabled>Submit</button>
                            elseif Model.HasBeenSubmitted Then                                @<div class="alert alert-success">
                                    <strong>Thank you for submitting your response.</strong>
                                </div>
                                @<button class="btn btn-lg btn-primary" type="submit" value="RequestForProposalForm" disabled>Submit</button>
                            Else
                                @<button id="Submit" class="btn btn-lg btn-primary" type="submit" value="RequestForProposalForm">Submit</button>
                            End If
                        </div>
                    </div>
                </div>
            </div>


        End Using

    End If

End If

<style>
    .form-group .control-label, .form-group .form-control-static,p,span, .panel-body{
        font-family: Verdana!important;
        font-size: 10pt;
    }
    td font span {
        font-family: Verdana !important;
        font-size: 10pt;
        font-weight: normal;
    }
    .form-control-static tr td:first-child font span {
        font-weight: normal !important;
    }
    h2, h3, h4 {
        font-family: Verdana !important;
    }
    h2 {
        font-size: 24px;
    }
    .btn {
        border-radius: 4px;
        padding: 6px 12px;
    }
</style>
