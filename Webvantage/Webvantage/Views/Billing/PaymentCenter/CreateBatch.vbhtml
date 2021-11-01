@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code


<script src="~/jscripts/validator.js" type="text/javascript"></script>
<script src="@Url.Content("~/scripts/jszip.min.js")"></script>
<script src="~/JScripts/billing.paymentcenter.createbatch.mvc.js"></script>

<style>
    .container {
        max-width: none;
        width: 100%;
    }

    .toolbar-custom-drop {
        padding: 5px;
        display: none;
    }

        .toolbar-custom-drop .k-button {
            width: 100%;
        }

        .toolbar-custom-drop tbody td {
            padding: 2px 8px 2px 8px !important;
        }

            .toolbar-custom-drop tbody td:last-child {
                padding-right: 2px !important;
            }

    #myOverlay {
        display: none;
    }

    #settings-container {
        /*width: 1455px;
        margin: 5px auto 5px auto;        */
        width: calc(80vw - 50px) !important;
        margin: 5px;
        margin-left: auto;
        margin-right: auto;
        min-width: 760px;
    }

    .k-Button-icon, .k-Split-Button-arrow {
        padding: 2px 4px !important;
    }

    textarea {
        resize: none !important;
    }

    .wvi .wvi-more_vertical {
        text-decoration: none !important;
    }

    body {
        overflow-x: hidden;
        overflow-y: auto;
    }

    .k-dropdown {
        vertical-align: middle;
    }

    .k-widget.k-dropdown .k-dropdown-wrap .k-input {
        line-height: 32px;
    }

    .k-button {
        vertical-align: central;
    }

    /*.k-grid-content {
        overflow: hidden !important;
    }*/
    .main-toolbar-container {
        width: calc(100vw - 58px);
        min-width: calc(100vw - 40px);
        background-color: #E5E5E5;
        padding: 10px 10px 10px 10px;
        border-bottom: 1px solid #CCC;
        box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);
        margin: 5px 14px 5px 1px;
        overflow: auto;
    }

    .disabled {
        pointer-events: none;
    }

    /*added to fix style differences in upgraded Kendo version*/
    .k-toolbar > * {
        display: inline-block !important;
        vertical-align: middle !important;
    }

    /*yellow highlight for required fields*/
    #Banks > span > span.k-dropdown-wrap.k-state-default,
    #PostingPeriodDropDown > span > span.k-dropdown-wrap.k-state-default,
    #checkDate,
    #dateToPayCutoff {
        background-color: rgb(255, 255, 204);
    }
</style>
<script id="bankDropDownTemplate" type="text/x-kendo-template">
    <span class="#: OpenBatchFlag ? 'k-state-disabled': ''#" title="#: OpenBatchFlag ? 'Bank ' + BankCode + ' is currently assinged to an active batch.': ''#">
        #: BankDescription #
    </span>
</script>

<div>
    <div id="TopToolBar" class="wv-bar k-toolbar k-widget k-toolbar-resizable" style="width:calc(100vw - 18px);background-color: #E5E5E5;padding: 10px 10px 10px 10px;border-bottom: 1px solid #CCC;box-shadow: inset 0 1px 0 rgba(255,255,255,.2), 0 1px 2px rgba(0,0,0,.05);margin: 5px 14px 5px 1px; overflow:auto;">
        <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px; width:calc(100vw - 50px)">            
            <li style="padding:0" id="saveListItem">                
                <button id="saveButton" class="k-button wv-icon-button wv-save k-state-disabled" title="Save Batch" onclick="SaveBatchHeader()" disabled><span class='wvi wvi-floppy-disk'></span></button>
            </li>
            @*<li style="padding:0" id="cancelListItem">
            <button id="cancelButton" class="wv-icon-button k-button wv-cancel k-state-disabled" onclick="cancelBatch()" title="Cancel" disabled><span class="wvi wvi-sign-forbidden"></span></button>
        </li>*@
            <li style="padding:0" id="deleteListItem">
                <button tabindex="-1" id="deleteButton" class="k-button wv-icon-button wv-cancel k-state-disabled" onclick="deleteBatch()" title="Delete Batch" disabled><span class="wvi wvi-delete"></span></button>
            </li>
            <li id="ViewListItem" style="padding:0;margin-left:15px;margin-right:15px;">
                <div id="Banks">
                    <span>Select Bank:</span>
                    <input id="Bank" type="text" style="width:300px;" class="batch-header" />
                </div>
            </li>
            @*<li style="padding:0" id="bookmarkListItem">
                <button class="k-button wv-icon-button wv-neutral" onclick="bookmarkPage()"><span class='wvi wvi-book-bookmark' title="Bookmark"></span></button>
            </li>*@
            <li>
                <div id="toggleButtonsContainer" class="k-button-group disabled-area">
                    <button class="k-button k-primary" id="AllQualifiedButton"
                            title="All Qualified"
                            onclick="SetInvoiceType('AQ');">
                        All Qualified
                    </button>
                    <button class="k-button" id="PaidByClientButton"
                            title="Paid By Client"
                            onclick="SetInvoiceType('PBC');">
                        Paid By Client
                    </button>
                </div>
            </li>
            <li>
                <div id="autoApprovePBC" class="k-button-group disabled-area" hidden>
                    <button class="k-button au-target" id="autoApprovePBCButton"
                            title="Auto Approve Qualified Payables"
                            onclick="AutoApprovePBC();">
                        Auto Approve Qualified Payables
                    </button>
                </div>
            </li>
            @*<li>
                <div id="submitContainer">
                    <button class="k-button au-target" id="BatchSubmissionButton"
                            title="Submit Batch"
                            onclick="BatchSubmission();">
                        Submit Batch
                    </button>
                </div>
            </li>*@
            @*<li>
            <div id="postContainer" class="k-button-group k-primary">
                <button class="k-button au-target" id="PostBatchButton"
                        title="Post Batch"
                        onclick="PostBatch();">
                    Post Batch
                </button>
            </div>
        </li>
            <li id="SendOnDateListItem">
                <span title="Send_on_date should be editable at the payment level by the user when utilizing a 3rd party.  Default to the check payment date.  The 3rd party processor will be assigned and maintained at the bank level.">Send On Date</span>
            </li>*@
            <li style="float:right;padding-top:10px;">
                <div id="batchStatusDiv"></div>
            </li>
        </ul>
    </div>
    <div id="FilterWrap">
        @Html.Partial("_CreateBatchFilter")
    </div>
    <div id="InvoiceWrap" style="height: calc(100vh - 425px);">
        @Html.Partial("_CreateBatchGrid")
    </div>
    <div id="showLockedInvoiceDialog" hidden>
        <p>The following invoices have been saved to another batch and will be removed before saving.  Please confirm save below.</p>
        <div id="lockedGrid"></div>
    </div>
</div>
@code
    Dim showSummaryDialog = Html.EJ().Dialog("showSummaryDialog")
    showSummaryDialog.Title("Payment Manager")
    showSummaryDialog.ShowOnInit(False)
    showSummaryDialog.ContentType("iframe")
    showSummaryDialog.Render()
    showSummaryDialog.Height("100%")
End Code

<script>

    let _BatchId = @ViewBag.BatchId;
    let _BatchName = '';
    let _BatchStatus = '';
    let _PaymentModule = "@ViewBag.PaymentModule";
    let _InvoiceType = "AQ";  //All Qualified (AQ) || Paid By Client (PBC)
    let _IsDirty = false;
    let myColumns = new Array();
    let columnSettingsReady = false;
    let userViewSettingsReady = false;
    let _gridView = "Detail";
    let _bankSelected = false;
    let _headerLocked = false;


    $(() => {        
        
    });

    function DeleteBatchHeader(){
        $.ajax({
            type: "POST",
            url: "@Href("~/PaymentCenter/DeleteExistingBatch")",
            data: { BatchId: _BatchId },
            success: function (response) {                
                _BatchId = 0;                
                batchHeader.BatchId = null;

                InvoiceFilter.BatchId = _BatchId;
                InvoiceFilter.BatchStatus = "";
                InvoiceFilter.BatchStatusDescription = "";
                InvoiceFilter.BatchName = "";
                InvoiceFilter.BankCode = '';
                InvoiceFilter.APAccountCode = 'ALL';
                InvoiceFilter.VendorCode = 'ALL';
                InvoiceFilter.ClientCode = 'ALL';
                InvoiceFilter.DateToPayCutoff = '';
                InvoiceFilter.CheckDate = '';
                InvoiceFilter.PaidByClient = 0;
                InvoiceFilter.Production = 1;
                InvoiceFilter.GLDist = 1;
                InvoiceFilter.Television = 1;
                InvoiceFilter.Radio = 1;
                InvoiceFilter.Newspaper = 1;
                InvoiceFilter.Magazine = 1;
                InvoiceFilter.Internet = 1;
                InvoiceFilter.Outdoor = 1;

                ////let bankList = $("#Bank").data("kendoDropDownList");
                //$("#Bank").data("kendoDropDownList").value([]);

                //$("#CashAccountDisp").html("");
                //$("#DiscountAccountDisp").html("");

                //$("#APAccountList").data("kendoMultiSelect").value([]);
                //$("#APAccountList").data("kendoMultiSelect").enable(false);
                //$("#APAccountList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                //$("#VendorList").data("kendoMultiSelect").value([]);
                //$("#VendorList").data("kendoMultiSelect").enable(false);
                //$("#VendorList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                //$("#ClientList").data("kendoMultiSelect").value([]);
                //$("#ClientList").data("kendoMultiSelect").enable(false);
                //$("#ClientList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                //$("#MediaList").data("kendoMultiSelect").enable(false);
                //$("#MediaList").data("kendoMultiSelect").value([]);
                //$("#MediaList").data("kendoMultiSelect").setOptions({ placeholder: "" });
                //$("#mediaCheckBoxAll").attr("disabled", true);
                //$("#mediaCheckBoxAll").prop("checked", false);

                //$("#IncludeItemsList").data("kendoMultiSelect").enable(false);
                //$("#IncludeItemsList").data("kendoMultiSelect").value([]);
                //$("#IncludeItemsList").data("kendoMultiSelect").setOptions({ placeholder: "" });

                //$("#postingPeriod").data("kendoDropDownList").enable(false);
                //$("#postingPeriod").data("kendoDropDownList").setOptions({ optionLabel: "" })

                //$("#checkDate").data("kendoDatePicker").value("");
                //$("#checkDate").attr("placeholder", "");
                //$("#checkDate").data("kendoDatePicker").enable(false);

                //$("#dateToPayCutoff").data("kendoDatePicker").value("");
                //$("#dateToPayCutoff").attr("placeholder", "");
                //$("#dateToPayCutoff").data("kendoDatePicker").enable(false);

                //$("#CashAccountDisp").html("");
                //$("#DiscountAccountDisp").html("");

                //$("#batchStatusDiv").html("");
                
                //_headerLocked = false;
                //DestroyGrid();
                //LoadGridView();
                //$("#completedGridTotals").hide();
                ////$("#invoiceGrid").data("kendoGrid").refresh();
                //_selectedInvoices = [];
                //CalculateSelectedInvoices();
                ////ResetSelectedInvoiceTotals();
            },
            error: function (response) {
            }
        });
    }

    function SetInvoiceType(invoiceType) {        
        let grid = $("#invoiceGrid").data("kendoGrid");
        //this column should only be visible in the grid view if PBC is selected
        //{ field: "PaidByClientAmount", title: "Paid by Client Amount", width: 150, format: "{0:c}" }        

        if (invoiceType == "PBC") {
            _InvoiceType = invoiceType;
            InvoiceFilter.PaidByClient = 1;

            $("#PaidByClientButton").addClass("k-primary");
            $("#AllQualifiedButton").removeClass("k-primary");

            $("#autoApprovePBC").show();

            grid.showColumn("PaidByClientAmount");
        } else {
            _InvoiceType = invoiceType;
            InvoiceFilter.PaidByClient = 0;

            $("#AllQualifiedButton").addClass("k-primary");
            $("#PaidByClientButton").removeClass("k-primary");

            $("#autoApprovePBC").hide();
            grid.hideColumn("PaidByClientAmount");
        }

        //SetInvoiceFilters();
        RefreshInvoiceGrid();
    }

    $("#Bank").kendoDropDownList({
        //autoBind: true,
        index: 0,
        optionLabel: "[Please Select]",
        dataTextField: "BankDescription",
        dataValueField: "BankCode",
        template: kendo.template($("#bankDropDownTemplate").html()),
        dataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "@Href("~/PaymentCenter/GetBanks")",
                    dataType: "json"
                }
            }
        }),
        dataBound: function (e) {            
        },
        select: function (e) {
            let value = e.sender.value();            
            if (_headerLocked) {                
                e.preventDefault();
                if (value !== e.dataItem.BankCode) {
                    DataLossNotification("bank").then(function (continueChange) {
                        if (continueChange) {                            
                            e.sender.value(e.dataItem.BankCode);
                            DeleteBatchHeader();
                            _headerLocked = false;                            
                            
                            if (!e.dataItem.BankCode) {
                                _bankSelected = false;
                                ClearHeaderInformation();
                            } else {
                                e.sender.trigger("change");
                            }

                            ManageSaveDeleteButtons();                                                      
                            ManageInvoiceSelection();
                        }
                    });
                }
            }

            if (e.dataItem.OpenBatchFlag) {
                e.preventDefault();
            } else {
                if (InvoiceFilter.BatchStatus == 'O' || InvoiceFilter.BatchStatus == 'E') {
                    _IsDirty = true;                    
                }
            }
        },
        change: function (e) {            
            console.log("stop here");
            e.preventDefault();

            if ($("#Bank").data("kendoDropDownList").value()) {
                $.ajax({
                    url: "@Href("~/PaymentCenter/GetBankDetail")",
                    data: { BankCode: $("#Bank").data("kendoDropDownList").value() },
                    dataType: 'json',
                    success: function (result) {
                        bankHeaderDetail.cashAccountCode = result.BankCashAccount;
                        bankHeaderDetail.cashAccountDescription = result.BankCashAccountDescription;
                        bankHeaderDetail.discountAccountCode = result.BankDiscountAccount;
                        bankHeaderDetail.discountAccountDescription = result.BankDiscountAccountDescription;
                        bankHeaderDetail.bankCode = $("#Bank").data("kendoDropDownList").value();
                        bankHeaderDetail.bankDescription = result.BankDescription;
                        bankHeaderDetail.bankLastCheckCompleted = result.BankLastCheckCompleted;
                        
                        _bankSelected = true;
                        ManageBankSelection();
                    },
                    error: function (result) {
                    }
                });
            } else {
                _bankSelected = false;
                ManageBankSelection();
            }
        },
        open: function (e) {
            console.log("open");                     
            //refresh the list of available banks everytime the bank dropdown is opened            
            this.dataSource.read();            
        }
    }).data('kendoDropDownList');




    function ResizeGrid(collapseFlag) {

        if ($('#invoiceGrid').offset().top) {
            var bottom = $('#invoiceGrid').offset().top;
            var viewHeight = $(window).height();

            if (collapseFlag == true) {
                $('#invoiceGrid').height(viewHeight - bottom - 15);
            } else {
                $('#invoiceGrid').height(viewHeight - bottom - 15);
            }

            let grid = $("#invoiceGrid").data("kendoGrid");

            if (grid !== undefined) {
                grid.resize();
            }
        }
    }

    function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {
        OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);
    }

    function onCloseCallback() {
        console.log("closed");
    }

    //function PackageInvoiceData(invoiceSelect) {
    //    let Invoices = new Array();

    //    for (let i = 0; i < invoiceSelect.length; i++) {
    //        Invoices.push({
    //            InvoiceNumber: invoiceSelect[i].InvoiceNumber,
    //            PayMethod: invoiceSelect[i].PaymentType,
    //            InvoiceType: invoiceSelect[i].InvoiceType,
    //            ApID: invoiceSelect[i].APId,
    //            ApprovedAmount: invoiceSelect[i].ApprovedAmount
    //        });
    //    }

    //    return Invoices;
    //}

    function PackageAccountData(accountSelect) {
        let Accounts = new Array();

        for (let i = 0; i < accountSelect.length; i++) {
            Accounts.push({
                GLCode: accountSelect[i],
                GLDescription: ""
            });
        }

        return Accounts;
    }

    function PackageVendorData(vendorSelect) {
        let Vendors = new Array();

        for (let i = 0; i < vendorSelect.length; i++) {
            Vendors.push({
                Code: vendorSelect[i],
                Description: ""
            });
        }

        return Vendors;
    }

    function PackageClientData(clientSelect) {
        let Clients = new Array();

        for (let i = 0; i < clientSelect.length; i++) {
            Clients.push({
                Code: clientSelect[i],
                Description: ""
            });
        }

        return Clients;
    }
</script>
