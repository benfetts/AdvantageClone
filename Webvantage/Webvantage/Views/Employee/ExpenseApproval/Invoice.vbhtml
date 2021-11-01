@ModelType AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel
@Code       ViewData("Title") = "Approve Expense Report"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = False
End Code
@Styles.Render("~/CSS/wv-icons.css")
@Styles.Render("~/Content/ej/web/bootstrap-theme/ej.web.all.min.css")
@Styles.Render("~/Content/ej/web/flat-azure/ej.web.all.min.css")


<link href="~/CSS/expense.approval.mvc.min.css" rel="stylesheet" />
<link href="~/CSS/expense.approval.invoice.mvc.min.css" rel="stylesheet" />
<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.min.js")"></script>
<script type="text/javascript" src="@Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js")"></script>
<script>
</script>
@Section PageHeader
    <div class="panel-heading bg-primary">
        <div class="panel-title" style="text-align:center">
            <h2>@Html.Raw(Model.Header.EmployeeFullName) - @Html.Raw(Model.Header.Description)</h2>
        </div>
    </div>
End Section
<div style="padding: 20px 20px 0px 20px;">
    @If Model.ExpenseReportStatus Is Nothing OrElse Model.ExpenseReportStatus = AdvantageFramework.ExpenseReports.Methods.ExpenseReportStatus.Open Then
        @<div id = "statusChangedContainer" class="alert alert-danger" style="display: block;">
            <span id = "statusChangedMessage">The Expense Report status has changed and it is no longer available to approve or deny.</span>
        </div>
    ElseIf Model.Message.Contains("Invalid approver") = True Then
        @<div id = "statusChangedContainer" class="alert alert-danger" style="display: block;">
            <span id = "invalidApproverMessage"><strong>Access denied!</strong>&nbsp;&nbsp;@Model.Message</span>
        </div> Else
        @<div id="expenseReportContainer">
            <div class="row" style="padding-left: 4px;" >
                <div class="form-group">
                    <label class="control-label" style="display:inline-block; margin-right:8px; width: 150px;">
                            Employee
                    </label>
                    <div class="form-control-static" style="display:inline-block; margin-left:0px;">
                            @Html.Raw(Model.Header.EmployeeFullName)
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" style="display:inline-block; margin-right:8px; width: 150px;">
                        Invoice Number
                    </label>
                    <div class="form-control-static" style="display:inline-block; margin-left:0px;">
                        @Html.Raw(Model.Header.InvoiceNumber)
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" style="display:inline-block; margin-right:8px; width: 150px;">
                        Current Status
                    </label>
                    <div class="form-control-static" style="display:inline-block; margin-left:0px;">
                        <span id="currentStatusSpan">@Html.Raw(Model.ExpenseReportStatusDisplay)</span>  @IIf(String.IsNullOrWhiteSpace(Model.Header.ApprovedByFullname) = False, " by " & Model.Header.ApprovedByFullname, "") @IIf(Model.Header.ApprovedDate IsNot Nothing, " at " & Model.Header.ApprovedDate.ToString, "")           
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" style="display: inline-block;margin-right: 8px;width: 150px;">
                        Report Date
                    </label>
                    <div class="form-control-static" style="display: inline-block;margin-left: 0px;">
                        @Html.Raw(Model.Header.InvoiceDateDisplay)
                    </div>
                </div>
                @Code
                    If String.IsNullOrWhiteSpace(Model.Header.Description) = False Then
                        @<div Class="form-group">
                            <Label Class="control-label" style="display: inline-block; margin-right: 8px; width: 150px; ">
                                Description
                            </label>
                            <div Class="form-control-static" style="display:inline-block; margin-left:0px;">
                                @Html.Raw(Model.Header.Description)
                            </div>
                        </div>
                    End If
                    If String.IsNullOrWhiteSpace(Model.Header.Details) = False Then
                        @<div Class="form-group">
                            <Label Class="control-label" style="display: inline-block; margin-right: 8px; width: 150px; ">
                                Detail
                            </label>
                            <div Class="form-control-static" style="display:inline-block; margin-left:0px;">
                                @Html.Raw(Model.Header.Details)
                            </div>
                        </div>
                    End If
               End Code
                <div class="form-group">
                    <label class="control-label" style="display:inline-block; margin-right:8px; width: 150px;">
                        Total Expense
                    </label>
                    <div class="form-control-static" style="display:inline-block; margin-left:0px;">
                        @Html.Raw((From Entity In Model.Items
                                   Select Entity.Amount).Sum)
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label" style="display:inline-block; margin-right:8px; width: 150px;">
                        Total Payable
                    </label>
                    <div class="form-control-static" style="display:inline-block; margin-left:0px;">
                        @Html.Raw((From Entity In Model.Items
                                   Select Entity.Payable).Sum)
                    </div>
                </div>
            </div>
            <div id="buttonContainer" class="row" style="margin-bottom: 10px; padding-left: 4px;">
                <div style="display: inline-block; margin: 4px; display: none;">
                    <button id="addCommentButton" type="button" class="btn btn-primary" style="width: 100px;">Add Comment</button>
                </div>
                <div style="display: inline-block; margin: 4px;">
                    <button id="approveButton" type="button" class="btn btn-success" style="width: 100px;">Approve</button>
                </div>
                <div style="display: inline-block; margin: 4px;">
                    <button id="denyButton" type="button" class="btn btn-danger" style="width: 100px;">Deny</button>
                </div>
                <div style="display: inline-block; margin: 4px; display: none;">
                    <button id="cancelButton" type="button" class="btn btn-secondary" style="width: 100px;">Cancel</button>
                </div>
            </div>
                @(Html.EJ().Grid(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseReportViewModel)("Grid").CssClass("e-table").Datasource((From Entity In Model.Items
                                                                                                                                                           Select Entity.ExpenseDetailID, Entity.ItemDateDisplay, Entity.CDPDisplay, Entity.JobDisplay, Entity.FunctionDescription, Entity.Quantity, Entity.Rate, Entity.Amount, Entity.IsCcYN, Entity.Payable, Entity.Description).Distinct.ToList) _
                                                                            .Columns(Sub(co)
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.ItemDateDisplay.ToString).HeaderText("Date").Width(100).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.CDPDisplay.ToString).HeaderText("C/D/P").Width(150).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.JobDisplay.ToString).HeaderText("Job").Width(200).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.FunctionDescription.ToString).HeaderText("Function/Category").Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.Quantity.ToString).HeaderText("Quantity").Width(90).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.Rate.ToString).HeaderText("Rate").Width(90).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.Amount.ToString).HeaderText("Amount").Width(90).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.IsCcYN.ToString).HeaderText("CC").Width(45).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.Payable.ToString).HeaderText("Payable").Width(90).Add()
                                                                                         co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemViewModel.Properties.Description.ToString).HeaderText("Description").Add()
                                                                                     End Sub).ChildGrid(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)(Sub(child)
                                                                                                                                                                                                    child.Datasource(Model.Documents)
                                                                                                                                                                                                    child.QueryString("ExpenseDetailID")
                                                                                                                                                                                                    child.Columns(Sub(co)
                                                                                                                                                                                                                      co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.FileName.ToString).HeaderText("File Name").Add()
                                                                                                                                                                                                                      co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.Description.ToString).Add()
                                                                                                                                                                                                                      co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.Link.ToString).Width(130).Add()
                                                                                                                                                                                                                  End Sub)
                                                                                                                                                                                                End Sub) _
                                                                            .AllowResizing(True) _
                                                                                                .AllowResizeToFit(True) _
                                                                                                .ClientSideEvents(Sub(eve)
                                                                                                                  End Sub)
                )@(Html.EJ().ScriptManager())
            @If Model.Documents IsNot Nothing AndAlso Model.Documents.Count > 0 Then
            End If
                    <div style="margin-top: 10px;">
                        <input class="k-checkbox" id="checkBoxShowAllDocuments" name="checkBoxShowAllDocuments" type="checkbox" onchange="checkBoxShowAllDocumentsChanged(this)">
                        <label class="k-checkbox-label" for="checkBoxShowAllDocuments">Show all receipts</label>
                    </div>
                    <div id = "docsGridContainer" style="margin-top: 4px; display: none; width: 75%;">
                        @(Html.EJ().Grid(Of AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel)("DocsGrid").CssClass("e-table").Datasource((From Entity In Model.Documents
                                                                                                                                                                             Select Entity.FileName, Entity.Description, Entity.Link).Distinct.ToList) _
                        .Columns(Sub(co)
                                     co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.FileName.ToString).HeaderText("File Name").Add()
                                     co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.Description.ToString).Add()
                                     co.Field(AdvantageFramework.ViewModels.Employee.ExpenseApproval.ExpenseItemDocumentViewModel.Properties.Link.ToString).Width(120).Add()
                                 End Sub) _
                        .AllowResizing(True) _
                                            .AllowResizeToFit(True) _
                                            .ClientSideEvents(Sub(eve)
                                                              End Sub)
                        )@(Html.EJ().ScriptManager())
                    </div>

        </div>
        @<div id = "actionedContainer" Class="alert alert-danger" style="display: none;">
            <span id = "actionedMessage" >The Expense Report status has changed and it is no longer available to approve or deny.</span>
        </div>
                    End If

</div>
<div id="ModalDialog" class="" title="Comment"></div>
<script id="addCommentDialogContent" type="text/template">
    <p style="padding-left: 5px; font-size: 10pt; font-family:Verdana;">
        <textarea name="approvalCommentTextArea" id="approvalCommentTextArea" cols="20" rows="5" style="margin: 0px; height: 92px; width: 361px;"></textarea>
    </p>
</script>
<script id="addCommentDialogFooter" type="text/x-jsrender">
    <div class="footerspan" style="float:right">
        <button id="btnAddCommentDialogDeny" type="button" class="btn btn-danger" style="width: 100px;">Deny</button>
        <button id="btnAddCommentDialogCancel" type="button" class="btn btn-secondary" style="width: 100px;">Cancel</button>
    </div>
</script>
<script>
    var x = "";
    var approverComment = "";
    var currentStatusText = "";
    var approvalFlag = 0;
    x = "@Html.Raw(ViewData("DB"))";
    approvalFlag = @Html.Raw(Model.Header.ApprovedFlag) * 1;
    currentStatusText = "@Html.Raw(Model.ExpenseReportStatusDisplay)";
    approverComment = $('#approvalCommentTextArea').val();
    $("#ModalDialog").ejDialog({
        closeOnEscape: true,
        enableModal: true,
        enableResize: false,
        showFooter: true,
        showOnInit: false,
        maxWidth: 500,
        footerTemplateId: "addCommentDialogFooter"
    });
    $("#approveButton").click(function () {
        //console.log("approvalCommentTextArea", $("#approvalCommentTextArea").val());
        approveInvoice(x, "@Html.Raw(ViewData("ID"))", "@Html.Raw(ViewData("ID2"))", $("#approvalCommentTextArea").val());
    });
    $("#denyButton").click(function() {
        newComment(null);
    });
    $("#cancelButton").click(function() {
        cancelInvoice(x, "@Html.Raw(ViewData("ID"))", "@Html.Raw(ViewData("ID2"))", $("#approvalCommentTextArea").val())
    });
    $("#addCommentButton").click(function () {
        newComment(null);
    });
    $('#btnAddCommentDialogOK').click(function () {
        approverComment = $('#approvalCommentTextArea').val();
        $("#ModalDialog").ejDialog("close");
    });
    $('#btnAddCommentDialogDeny').click(function () {
        approverComment = $('#approvalCommentTextArea').val();
        denyInvoice(x, "@Html.Raw(ViewData("ID"))", "@Html.Raw(ViewData("ID2"))", $("#approvalCommentTextArea").val())
        //$("#ModalDialog").ejDialog("close");
    });
    $('#btnAddCommentDialogCancel').click(function () {
        $('#approvalCommentTextArea').val("");
        approverComment = "";
        $("#ModalDialog").ejDialog("close");
    });
    function newComment(args) {
        var template = document.getElementById("addCommentDialogContent");
        $("#ModalDialog").data("CommandID", 2);
        $("#ModalDialog").ejDialog("open", args);
        $("#ModalDialog").ejDialog("setTitle", "Comment");
        $("#ModalDialog").ejDialog("setContent", template.innerHTML);
        $('#approvalCommentTextArea').val(approverComment);
    };
    //$(window).resize(function() {
    //    var gridObj = $("#Grid").data("ejGrid");
    //    if (gridObj) {
    //    }
    //});
    $(document).ready(function () {
        $("#currentStatusSpan").text(currentStatusText);
        setButtons(approvalFlag);
    });
</script>
@Scripts.Render("~/JScripts/expense.approval.invoice.mvc.min.js")
