@*<script type="text/javascript" src="~/JScripts/aam.inbox.filter.mvc.js"></script>*@
<style>
    #bankHeader td,
    #checkHeader td,
    #bankAccountDetails td {
        padding-bottom: 10px;
    }

    #DiscountAccount,
    #CashAccount {
        border: 1px solid #ccc;
        border-radius: 4px;
        width: 200px;
        min-width: 200px;
        line-height: 32px;
        padding-left: 4px;
    }

    #DiscountAccountDisp,
    #CashAccountDisp{
        width: 200px;
        min-width: 200px;        
        padding-left: 4px;
    }

    #LastCheck,
    #NextCheck {        
        padding-left: 4px;
    }

    .k-state-disabled {
        background-color: #f5f5f5;
    }

    #ClientListDiv > div > div,
    #APAccountListDiv > div > div,
    #VendorListDiv > div > div {

        height: 144px;
        max-height: 144px;
    }

    #MediaListDiv > div > div {
        /*height: 100px;*/
    }

    .k-multiselect-wrap {
        max-height: 144px !important;
        overflow: auto !important;
    }
</style>

<div>
    <ul id="panelbar" style="display:inline-block;position:relative;width:calc(100vw - 18px);min-width:calc(100vw - 18px);">
        <li id="panelMain" class="k-state-active" style="position: relative;width:calc(100vw - 18px) !important;">            
            <span id="panelBarTitle" class="k-link k-state-selected" style="position:relative;width:calc(100vw - 45px) !important;font-weight:600;font-size:14px;"> Advantage Pay | Create New Batch</span>
            <div id="filterPanelDiv" style="padding-top: 30px;padding-bottom: 20px;padding-left: 30px; border-bottom: none;overflow:auto;" class="disabled-area">
                <table id="" style="">
                    <tr>
                        <td style="vertical-align:top;width:150px;">
                            <span style="font-weight:bold">Cash Account</span>
                            <div id="CashAccountDisp" style="margin:4px 0 0 4px"></div><br />
                            <span style="font-weight:bold">Discount Account</span>
                            <div id="DiscountAccountDisp" style="margin:4px 0 0 4px"></div><br />
                        </td>
                        <td>
                            <span style="font-weight:bold">Payment Date</span>
                            <div id="CheckDatePicker" style="margin-bottom:4px;">
                                <input id="checkDate" title="" style="width: 200px; color: #767676;" placeholder="" class="batch-header" />
                            </div>
                            <span style="font-weight:bold">Date to Pay Cutoff</span>
                            <div id="DateToPayCutoffPicker" style="margin-bottom:4px;">
                                <input id="dateToPayCutoff" title="" style="width: 200px; color: #767676;" placeholder="" class="batch-header" />
                            </div>
                            <span style="font-weight:bold">Posting Period</span>
                            <div id="PostingPeriodDropDown">
                                <input id="postingPeriod" title="" style="width: 200px; color: #767676;" class="batch-header" />
                            </div>
                        </td>
                        <td style="padding-left:35px;vertical-align: top;">
                            <span style="font-weight:bold">Filter Invoices by A/P Account</span>
                            <div id="APAccountListDiv" style="width:225px;">
                                <input id="APAccountList" class="batch-header" />
                            </div>
                        </td>
                        <td style="padding-left:35px;vertical-align: top;">
                            <span style="font-weight:bold">Filter Invoices by Vendor</span>
                            <div id="VendorListDiv" style="width:225px;">
                                <input id="VendorList" class="batch-header"/>
                            </div>
                        </td>
                        <td style="padding-left:35px;vertical-align: top;">
                            <span style="font-weight:bold">Filter Invoices by Client</span>
                            <div id="ClientListDiv" style="width:225px;">
                                <input id="ClientList" class="batch-header"/>
                            </div>
                        </td>
                        <td style="padding-left:35px;vertical-align: top;">
                            <span style="font-weight:bold;">Media Filter</span>
                            <div id="mediaFilterType" style="float:right;">
                                Select All: <input id="mediaCheckBoxAll" type="checkbox" checked disabled="disabled" onchange="mediaCheckChange(this);" class="batch-header"/>
                            </div>
                            <div id="MediaListDiv" style="width:225px;margin-top:5px;">
                                <input id="MediaList" class="batch-header"/>
                            </div>
                            
                        </td>
                        <td style="padding-left:35px;vertical-align: top;">
                            <span style="font-weight:bold;">Include</span>
                            <div id="IncludeItemsDiv" style="width:225px;margin-top:5px;">
                                <input id="IncludeItemsList" class="batch-header"/>
                            </div>                            
                        </td>

                        @*<td>
            Single Check for vendors<br />
            Selected Invoices Totals<br />
            Default Bank/VCC Accepted Status
        </td>*@
                    </tr>                                        
                </table>
            </div>
        </li>
    </ul>
</div>
<script>
    let todayDate = kendo.toString(kendo.parseDate(new Date()), 'MM/dd/yyyy');

    $(() => {        

        $("#panelbar").kendoPanelBar({
            expand: onExpand,
            collapse: onCollapse
        }).data("kendoPanelBar");

        let accountFilter = $("#APAccountList").data("kendoMultiSelect");        
        let vendorFilter = $("#VendorList").data("kendoMultiSelect");
        let clientFilter = $("#ClientList").data("kendoMultiSelect");
        let mediaFilter = $("#MediaList").data("kendoMultiSelect");
        let includeItemsFilter = $("#IncludeItemsList").data("kendoMultiSelect");

        accountFilter.bind("deselect", multiSelectDeselect);
        accountFilter.bind("change", multiSelectChange);  
        accountFilter.bind("select", multiSelectSelect);  

        vendorFilter.bind("deselect", multiSelectDeselect);
        vendorFilter.bind("change", multiSelectChange);                            
        vendorFilter.bind("select", multiSelectSelect);

        clientFilter.bind("deselect", multiSelectDeselect);
        clientFilter.bind("change", multiSelectChange);
        clientFilter.bind("select", multiSelectSelect);

        mediaFilter.bind("deselect", multiSelectDeselect);
        mediaFilter.bind("change", multiSelectChange);
        mediaFilter.bind("select", multiSelectSelect);

        includeItemsFilter.bind("deselect", multiSelectDeselect);
        includeItemsFilter.bind("change", multiSelectChange);
        includeItemsFilter.bind("select", multiSelectSelect);
    });

    function mediaCheckChange(e) {        
        let check = e.checked;
        
        if (_headerLocked) {
            DataLossNotification("header").then(function (continueChange) {
                if (continueChange) {
                    e.checked = check;

                    if (check) {
                        SetMediaType("ALL");
                    } else {
                        SetMediaType("NONE");
                    }

                    DeleteBatchHeader();

                    _headerLocked = false;

                    ManageSaveDeleteButtons();
                    ManageInvoiceSelection();
                    RefreshInvoiceGrid();
                } else {
                    e.checked = !check;
                }
            });
        } else {
            e.checked = check;

            if (check) {
                SetMediaType("ALL");
            } else {
                SetMediaType("NONE");
            }
            RefreshInvoiceGrid();
        }
    }

    function SetMediaType(selection) {        
        let list = $("#MediaList").data("kendoMultiSelect");
        if (selection == "ALL") {            
            var values = $.map(list.dataSource.data(), function (dataItem) {
                return dataItem.Code;
            });
            list.value(values);
        } else {            
            list.value([]);
        }                
        ProcessSelectedFilterChange(list.element[0].id, list.dataItems());        
        RefreshInvoiceGrid();
    }    

    $("#APAccountList").kendoMultiSelect({           
        autoWidth: true,        
        clearButton: false,
        placeholder: "",                               
        valuePrimitive: true,
        required: false,
        open: (function (e) {            
        }),        
        select: (e) => {
            //bound on doc ready      
        },
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code",        
        itemTemplate: APAccountItemTemplate,
        dataSource: new kendo.data.DataSource({
            transport: {                
                read: {
                    url: "@Href("~/PaymentCenter/GetAccountsPayableAccounts")",
                    dataType: "json"
                }
            }
        }),
        change: (e) => {         
            //bound on doc ready            
        },
        deselect: (e) => {
            //bound on doc ready            
        }
    }).data('kendoMultiSelect');    
        


    $("#IncludeItemsList").kendoMultiSelect({
        autoWidth: true,
        //enable: false,
        clearButton: false,
        placeholder: "",
        valuePrimitive: true,
        required: false,
        open: (() => {
        }),
        close: ((e) => {
        }),
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code",
        itemTemplate: "#: Description #",
        dataSource: {
            data: [
                { Code: "GL", Description: "Non-Client Items" },
                { Code: "Production", Description: "Production Items" }                
            ]
        },
        change: (e) => {            
        },
        dataBound: (e) => {            
        }
    }).data('kendoMultiSelect');

    $("#MediaList").kendoMultiSelect({   
        autoWidth: true,
        //enable: false,
        clearButton: false,
        placeholder: "",                               
        valuePrimitive: true,
        required: false,
        open: (() => {                
        }),
        close: ((e) => {                
        }),
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code",        
        itemTemplate: "#: Description #",
        dataSource: {
            data: [                
                { Code: "Internet", Description: "Internet" },
                { Code: "Magazine", Description: "Magazine" },
                { Code: "Newspaper", Description: "Newspaper" },
                { Code: "Out of Home", Description: "Out of Home" },
                { Code: "Radio", Description: "Radio" },
                { Code: "Television", Description: "Television" }
                ]
        },
        change: (e) => {    
            let list = $("#MediaList").data("kendoMultiSelect");            

            if (list.value().length < list.dataSource.data().length) {
                $("#mediaCheckBoxAll").prop("checked", false);
            } else {
                $("#mediaCheckBoxAll").prop("checked", true);
            }            
            ProcessSelectedFilterChange(e.sender.element[0].id, e.sender.dataItems());
            RefreshInvoiceGrid();
        },
        dataBound: (e) => {              
            //let list = $("#MediaList").data("kendoMultiSelect");
            //var values = $.map(list.dataSource.data(), function (dataItem) {
            //    return dataItem.value;
            //});
            //list.value(values);

            $("#mediaCheckBoxAll").prop("checked", false);
        }
    }).data('kendoMultiSelect');

    $("#ClientList").kendoMultiSelect({   
        autoWidth: true,
        //enable: false,
        clearButton: false,
        placeholder: "",                               
        valuePrimitive: true,
        required: false,
        open: (() => {                
        }),
        close: ((e) => {                
        }),
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code",        
        itemTemplate: ClientItemTemplate,
        dataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "@Href("~/PaymentCenter/GetClients")",
                    data: InvoiceFilter,
                    dataType: "json"                    
                }
            }
        }),
        change: (e) => {                  
            //bound on doc ready
        },
        deselect: (e) => {            
            //bound on doc ready
        }
    }).data('kendoMultiSelect');

    $("#VendorList").kendoMultiSelect({   
        autoWidth: true,
        clearButton: false,
        //enable: false,
        placeholder: "",                               
        valuePrimitive: true,
        required: false,
        open: (() => {                
        }),
        close: ((e) => {                
        }),
        filter: "contains",
        dataTextField: "Description",
        dataValueField: "Code",
        itemTemplate: VendorItemTemplate,
        dataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "@Href("~/PaymentCenter/GetVendorsByAPAccount")",
                    data: { BankCode: "ALL", APAccountcode: "ALL", VCCStatus: 0, DefaultBank: 0 },
                    dataType: "json"                    
                }
            }
        }),
        change: (e) => {            
            //bound on doc ready
        },
        deselect: (e) => { 
            //bound on doc ready
        }
    }).data('kendoMultiSelect');

    function APAccountItemTemplate(dataItem) {            
        rv = '<div><span class="k-state-default">' + dataItem.Description + " (" + dataItem.Code + ")";
        //rv = rv + '<p style="font-size:smaller">' + dataItem.Description + '</p>';        
        rv = rv + '</span></div>';

        return rv;
    }

    function ClientItemTemplate(dataItem) {
        rv = '<div><span class="k-state-default">' + dataItem.Description + " (" + dataItem.Code + ")";
        //rv = rv + '<p style="font-size:smaller">' + dataItem.Description + '</p>';
        rv = rv + '</span></div>';

        return rv;
    }

    function VendorItemTemplate(dataItem) {
        rv = '<div><span class="k-state-default">' + dataItem.Description + " (" + dataItem.Code + ")";
        //rv = rv + '<p style="font-size:smaller">' + dataItem.Description + '</p>';
        rv = rv + '</span></div>';

        return rv;
    }

    $("#postingPeriod").kendoDropDownList({
        //autoBind: false,
        //enable: false,            
        dataTextField: "PostingPeriodCode",
        dataValueField: "PostingPeriodCode",
        template: "#: data.PostingPeriodCode #",
        optionLabel: "",
        index: -1,        
        dataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "@Href("~/PaymentCenter/GetPostingPeriods")",
                    dataType: "json"                    
                }                
            }
        }),
        dataBound: function (e) {            
        },
        change: function (e) {            
            if (_headerLocked) {
                UpdateBatchHeader("POSTING_PERIOD", this.value());
            }            
        }
    }).data('kendoDropDownList');

    $("#checkDate").kendoDatePicker({        
        change: function (e) {
            InvoiceFilter.CheckDate = this.value();            

            if (_headerLocked) {
                UpdateBatchHeader("PAYMENT_DATE", kendo.toString(this.value(), "yyyy-MM-dd"));
            }            
        },
        placeholder: "",
        parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
        format: 'MM/dd/yyyy'        
    }).data("kendoDatePicker");    

    $("#dateToPayCutoff").kendoDatePicker({        
        //enable: false,
        change: function (e) {
            if (_headerLocked) {
                e.preventDefault();
                DataLossNotification("header").then(function (continueChange) {
                    if (continueChange) {

                        DeleteBatchHeader();

                        _headerLocked = false;
                        
                        ManageSaveDeleteButtons();
                        ManageInvoiceSelection();
                        RefreshInvoiceGrid();
                    }
                });
            } else {
                InvoiceFilter.DateToPayCutoff = this.value();
                RefreshInvoiceGrid();
            }
        },
        placeholder: "",
        parseFormats: ['MM-dd-yyyy', 'MM-dd-yy', 'MM/dd/yyyy', 'MM/dd/yy', 'MMddyyyy', 'MMddyy'],
        format: 'MM/dd/yyyy'        
    }).data("kendoDatePicker");

    function onExpand(e) {        
        setTimeout(() => {
            $(window).trigger('resize', false);
        }, 200);
    }

    function onCollapse(e) {        
        setTimeout(() => {
            $(window).trigger('resize', true);
        }, 300);
    }
</script>
