@Code Layout = "~/Views/Shared/_LayoutPageBase.vbhtml"
End Code

<style>
    #gridTotals {
        margin: 0px;
        padding: 0px;
    }

    #gridTotals > tbody > tr > td {
        height: 6px;
        border: none;
        margin: 0px;
        padding: 0px;
        width: 150px;
        text-align: center;
        font-weight: 600;
    }

    th.k-header.k-state-focused > a.k-link:link,
    th.k-header.k-state-focused > a.k-link:link > span.k-i-sort-asc-sm,
    th.k-header.k-state-focused > a.k-link:link > span.k-i-sort-desc-sm 
    {
        color: white !important;
    }

    input[type="radio"][disabled], input[type="checkbox"][disabled], input[type="radio"].disabled, input[type="checkbox"].disabled, fieldset[disabled] input[type="radio"], fieldset[disabled] input[type="checkbox"]{
        cursor: auto;
    }

    .k-button{
        margin-top:5px;
    }
</style>

<div id="summaryGrid" style="border: 1px solid #CCC;height:400px;max-height:400px;margin-top:10px;" tabindex="1"></div>
<script type="text/x-kendo-template" id="template">
    <ul Class="list-inline" style="margin-bottom: 0; padding-left: 8px;">
        <li id="columnSelectorListItem" style="padding:0">
            <a id="col-menu" style="text-decoration: none;"></a>
        </li>              
        <li style="padding:5px 0 0 0;">
            <button class="k-button wv-icon-button wv-neutral" onclick="ExportToExcel()"><span class='wvi wvi-spreadsheet-sum' title="Export" style="font-size: 18px;"></span></button>
        </li> 
        <li style="padding:5px 0 0 0;">
            <button class="k-button wv-icon-button" onclick="printClick()" title="Add time"><span class="wvi wvi-printer2" title="Print Expense Report"></span></button>
        </li>
        <li style="float:right;">
            <div>
                <table id="gridTotals">
                    <tr style="line-height:10px !important;">
                        <td>Invoice Totals</td>
                        <td>Invoice Balance</td>
                        <td>Approved Amount</td>
                    </tr>
                    <tr>
                        <td id="invoiceTotals">$0.00</td>
                        <td id="invoiceBalance">$0.00</td>
                        <td id="approvedAmount">$0.00</td>
                    </tr>
                </table>

            </div>
        </li>
    </ul>

</script>
<script>
    $(() => {       
        
    });

    let _batchId = @ViewBag.BatchId;  
    let _invoiceTotals = 0;
    let _invoiceBalance = 0;
    let _approvedAmount = 0;

    var batchFilter = {
        BatchId: _batchId,
    };

    var gridData = new kendo.data.DataSource({
        transport: {
            read: (e) => {
                $.ajax({
                    type: "GET",
                    url: "GetVendorSummary",
                    contentType: "application/json",
                    data: {
                        BatchId: _batchId,
                    },
                    success: (results) => {
                        e.success(results);

                        console.log(results);
                        for (let i = 0; i < results.length; i++) {
                            _invoiceTotals += results[i].InvoiceTotal;
                            _invoiceBalance += results[i].InvoiceBalance;
                            _approvedAmount += results[i].ApprovedAmount;
                        }

                        $("#invoiceTotals").html(kendo.toString(_invoiceTotals, "c"));
                        $("#invoiceBalance").html(kendo.toString(_invoiceBalance, "c"));
                        $("#approvedAmount").html(kendo.toString(_approvedAmount, "c"));                        
                    },
                    error: (results) => {
                        e.error(results);
                    }
                });
            }
        },
        pageSize: 10,
        schema: {
            model: {
                fields: {
                    PayToVendorCode: { from: "PayToVendorCode", type: "string", editable: false },
                    PayToVendorName: { from: "PayToVendorName", type: "string", editable: false },
                    InvoiceType: { from: "InvoiceType", type: "string", editable: false },
                    InvoiceBalance: { from: "InvoiceBalance", type: "number", editable: false },
                    InvoiceTotal: { from: "InvoiceTotal", type: "number", editable: false },
                    ApprovedAmount: { from: "ApprovedAmount", type: "number", editable: false },
                    VendorEmail: { from: "VendorEmail", type: "string", editable: true },
                    VendorPaymentManagerEmail: { from: "VendorPaymentManagerEmail", type: "string", editable: true },
                    SpecialTerms: { from: "SpecialTerms", type: "number", editable: false},
                    VendorNotes: { from: "VendorNotes", type: "string", editable: false }
                }
            }
        }
    });

    var batchGrid = $("#summaryGrid").kendoGrid({
        autoWidth: true,
        autoBind: true,
        navigatable: true,
        reorderable: true,
        toolbar: kendo.template($("#template").html()),
        dataSource: gridData,
        sortable: true,
        pageable: {
            pageSizes: [10, 15, 20, 50, 100, 200],
            buttonCount: 5
        },
        resizable: false,        
        editable: "incell",
        columns: [                        
            { field: "PayToVendorName", title: "Pay To Vendor", width: 250 },
            { field: "InvoiceType", title: "Invoice Type", width: 175 },
            { field: "InvoiceTotal", title: "Invoice</br>Total", width: 120, format: "{0:c}", attributes: { style: "text-align: right;" } },
            { field: "InvoiceBalance", title: "Invoice</br>Balance", width: 120, format: "{0:c}", attributes: { style: "text-align: right;" } },            
            { field: "ApprovedAmount", title: "Approved</br>Amount", width: 120, format: "{0:c}", attributes: { style: "text-align: right;" } },
            { field: "VendorEmail", title: "Email", width: 175, editor: emailEditor },
            { field: "VendorPaymentManagerEmail", title: "Payment</br>Manager Email", width: 175, editor: emailEditor },
            {
                field: "SpecialTerms", title: "Special</br>Terms", width: 75, attributes: { style: "text-align: center;" },
                template: '<input type="checkbox" id="specialTermsCB" #= SpecialTerms ? checked="checked" : "" # disabled />'
            },
            { field: "VendorNotes", title: "Vendor Notes", width: 200 }

            //{ field: "PaymentEmail", title: "Payment Mgr</br>Email", width: 200, attributes: { class: 'gridPaymentEmail', id: "#= 'paymentEmail_' + InvoiceNumber #" }, editor: emailEditor },
        ],
        dataBound: function (e) {
            totalpages = e.sender.pager.totalPages();
            e.sender.pager.options.messages.display = "{2} items in " + totalpages + " page(s)";
        }
    });

    function emailEditor(container, options) {
        let vendorCode = options.model.PayToVendorCode;                
        let textArea = $('<input autocomplete="off" type="text" id="emailEditorInput" class="k-textbox combo-40" name="' + options.field + '"/>').appendTo(container);

        textArea.on('focus', () => {
            setTimeout(() => {
                $('#emailEditorInput').select();
            }, 50);
        })
            .on('mousedown', (e) => { e.stopPropagation(); })
            .on('keydown', (e) => {
                if ((e.key == 'ArrowLeft' || e.key == 'ArrowRight') && e.shiftKey) {
                    e.stopPropagation();
                }
            })
            .on('change', (e) => {
                let columnName = e.target.name;                
                let emailAddressType = '';
                let oldEmail = options.model.get(columnName)
                let newEmail = $('#emailEditorInput').val();

                console.log(oldEmail, newEmail);

                IsEmailAddressValid(newEmail).then(function (valid) {
                    if (valid) {
                        options.model.set(columnName, newEmail);
                        if (columnName == "VendorEmail") {
                            emailAddressType = "VENDOR";
                        } else {
                            emailAddressType = "PAYMENT_MANAGER";
                        }

                        UpdateEmailAddress(emailAddressType, options.model.PayToVendorCode, newEmail);
                    } else {
                        options.model.set("PaymentEmail", oldEmail);

                        showKendoAlert("Please enter a valid email address.");
                    }
                });
            });
    }

    function IsEmailAddressValid(email) {
        let response = $.ajax({
            url: 'IsEmailAddressValid?Email=' + email,
            dataType: 'json'
        });
        
        return response;
    }  

    function UpdateEmailAddress(emailAddressType, vendorCode, email) {
        let response = false;
        let postData = {
            VendorCode: vendorCode,
            EmailAddress: email,
            EmailAddressType: emailAddressType
        };

        console.log(postData);

        $.ajax({
            type: "POST",
            url: "SaveEmailAddress",
            data: postData,
            success: function (response) {            
                response = response.Success;
            },
            error: function (response) {                
                response = response.Success;
            }
        });

        return response;
    } 
</script>
