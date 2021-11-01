@Code ViewData("Title") = "Upload recipts"
    Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
    ViewData("IsFullLayout") = False
    ViewData("IsAngular") = True
End Code
    <style>
        .k-button.wv-icon-button{min-width:unset!important;}
    </style>
    <script src="~/Scripts/ExpenseReports/expenseReportReceipts.js"></script>

    <div ng-app="angExpenseReportReceipts" ng-controller="ExpenseReportReceiptsController">
        <div class="content padding-x">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-12">
                        <div id="ExpenseReportsGrid" kendo-grid="gridAllReceipts" k-options="allReceiptsOptions"></div>
                    </div>
                </div>
            </div>
         </div>

        <script type="text/x-kendo-template" id="receiptThumnail">
            <div class="thumbnail" style="width:160px">
                <img src="#= data #" />
            </div>
        </script>

        <script type="text/x-kendo-template" id="receiptActionButtons">
            <div class="">
                <a class="k-link k-button wv-icon-button wv-copy" title="Download" download="#= data.filename #" href="#= data.url #"><span class='wviimport wviimport-arrow-down2'></span></a>
                <button class="k-button wv-icon-button wv-copy" ng-click="receiptCopyClick(#= data.DocumentId  #)" title="Copy"><span class='wvi wvi-copy'></span></button>
                <button class="k-button wv-icon-button wv-cancel" ng-click="receiptDeleteClick(#= data.DocumentId  #)" title="Delete"><span class='wvi wvi-delete'></span></button>
            </div>
        </script>
    </div>

    <script>
    @code
        Dim upladedImagesJson = ViewBag.UploadedImages
        Dim uploadedImagesList = Newtonsoft.Json.JsonConvert.SerializeObject(upladedImagesJson.Data)
    End Code
        var invoiceNumber = @Html.Raw(ViewBag.InvoiceNumber);
        var initAllReceipts = @Html.Raw(uploadedImagesList);


        window.onunload = function (event) {
            console.log('close event');
            window.parent.closeExpenseReportReceiptsDialogAndReloadReport(invoiceNumber);
        };
    </script>
