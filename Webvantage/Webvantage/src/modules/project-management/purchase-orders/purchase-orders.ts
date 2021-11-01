import { UserSettingService } from 'services/utilities/user-settings-service';
import { ModuleBase } from 'modules/base/module-base';
import { customElement } from 'aurelia-framework'
import { inject } from 'aurelia-framework';
import { DialogService } from 'aurelia-dialog';
import { NewPurchaseOrderDlg } from 'modules/project-management/purchase-orders/new-purchase-order-dlg'
import { HttpClient } from 'aurelia-http-client';

@inject(DialogService, UserSettingService, 'openModule')
export class PurchaseOrders extends ModuleBase {
    
    dialogService: DialogService;
    service: UserSettingService;
    openModule;

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;

    description: string = '';

    status = [];

    jobMultiSelect: kendo.ui.MultiSelect;
    jobDataSource: kendo.data.DataSource;
    jobCode = [];

    componentMultiSelect: kendo.ui.MultiSelect;
    componentDataSource: kendo.data.DataSource;
    componentCode = [];

    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;

    divisionMultiSelect: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;

    productMultiSelect: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;

    poNumberMultiSelect: kendo.ui.MultiSelect;
    poNumberDataSource: kendo.data.DataSource;
    poNumber = [];

    vendorMultiSelect: kendo.ui.MultiSelect;
    vendorDataSource: kendo.data.DataSource;
    vendorCode = [];

    employeeMultiSelect: kendo.ui.MultiSelect;
    employeeDataSource: kendo.data.DataSource;
    employeeCode = [];

    approversMultiSelect: kendo.ui.MultiSelect;
    approversDataSource: kendo.data.DataSource;
    approversCode = [];

    statusMultiSelect: kendo.ui.MultiSelect;

    fromDatePicker: kendo.ui.DatePicker;
    toDatePicker: kendo.ui.DatePicker;
    dueDatePicker: kendo.ui.DatePicker;

    FromDate: Date = null;
    ToDate: Date = null;
    DueDate: Date = null;

    virtualClient;
    virtualDivision;
    virtualProduct;
    virtualJob;
    virtualComponent;

    // search parameters
    clientCode = [];
    divisionID = [];
    productID = [];

    resetClient: boolean = false;
    resetDivision: boolean = false;
    resetProduct: boolean = false;
    resetJob: boolean = false;
    resetComponent: boolean = false;
    backFillInProgress: boolean = false;

    pageSize: number = 15;
    totalpages: number;
    isbookmark: boolean = false;

    OmitClosed: boolean = true;
    OmitVoided: boolean = true;
    Printed: boolean = false;

    OmitClosedId: string = "";
    OmitVoidedId: string = "";
    PrintedId: string = "";

    EncryptPO: string = "";

    search() {
        let me = this;
        me.data.data([]);

        this.grid.dataSource.query({ page: 1, pageSize: this.pageSize }).then(function () {
            if (me.data.total() == 1) {
                var item = me.data.data()[0];

                //me.openModule('PO ' + item.PONumber + ' - ' + item.Description , me.showDetailView(item.PONumber));
                me.showDetailView(item.PONumber, item.DisplayPONumber, item.Description);
            }
        });
    }

    clear() {
        this.jobCode = [];
        this.componentCode = [];
        this.clientCode = [];
        this.poNumber = [];
        this.vendorCode = [];
        this.employeeCode = [];

        this.divisionID = [];
        this.productID = [];

        this.description = '';
        this.approversCode = [];
        this.status = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.FromDate = null;
        this.ToDate = null;
        this.DueDate = null;

        this.OmitClosed = true;
        this.OmitVoided = true;
        this.Printed = false;

        this.setComponentDataSource();
        this.setJobDataSource();
        this.setPONumberDataSource();
        this.setVendorDataSource();
        this.setEmployeeDataSource();
        this.setApproversDataSource();

        this.divisionDataSource.read();
        this.productDataSource.read();

        this.data.data([]);
    }

    showDetailView(PONumber, DisplayPONumber, Description) {
        let client = new HttpClient();
        let me = this;
        
        var data = {
            PONumber: PONumber
        };
        client.get('Utilities/EncryptPONumber', data)
            .then(data => {
                this.EncryptPO = data.content;               

                me.openModule(me.getTitle(DisplayPONumber, Description), "purchaseorder.aspx?po_number=" + this.EncryptPO + "&pagemode=edit");

            });               

        //return "purchaseorder.aspx?po_number=" + this.EncryptPO + "&pagemode=edit";
    }

    getTitle(PONumber : string, Description: string ) {
        return 'PO ' + PONumber + ' - ' + Description;
    }

    showOmitClosedChanged() {
        this.poNumber = [];

        this.setPONumberDataSource();
        this.data.data([]);
    }

    showOmitVoidedChanged() {
        this.poNumber = [];

        this.setPONumberDataSource();
        this.data.data([]);
    }

    showPrintedChanged() {
        this.poNumber = [];

        this.setPONumberDataSource();
        this.data.data([]);
    }

    setPONumberDataSource() {
        let me = this;
        this.poNumberDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchPONumber',
                    data: function () {

                        return {
                            OmitVoided: me.OmitVoided,
                            OmitClosed: me.OmitClosed
                        }
                    }
                }
            }
        });
        if (this.poNumberMultiSelect) {
            this.poNumberMultiSelect.setDataSource(this.poNumberDataSource);
        }
    }

    poNumberMultiSelect_OnChange(e) {
        if (this.poNumber && this.poNumber.length == 1) {
            this.search();
        }
        else {
            this.data.data([]);
        }
    }

    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_pos").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.clientCode = [];
            me.clientMultiSelect.trigger('change');
        });
    }

    setClientDataSource() {
        let me = this;
        this.clientDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Clients",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '',
                            Text = "";

                        if (me.clientMultiSelect) {

                            Text = <string>me.clientMultiSelect.input.val();

                            if (Text == 'Client') {
                                Text = "";
                            }

                            if (Text == "") {
                                var dataItems = me.clientMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                }
                            }
                        }

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    clientMultiSelect_OnChange(e) {
        let me = this;

        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        if (!me.clientCode || me.clientCode.length == 0 || me.clientCode[0] == '') {
            console.log(me.clientCode);
            console.log('reload div and prod');
            this.divisionID = [];
            this.productID = [];

            this.divisionDataSource.read();
            this.productDataSource.read();
        }
        else {
            this.divisionDataSource.read().then(function () {
                if (me.divisionDataSource.total() == 1) {
                    me.divisionID = [];
                    me.divisionID[0] = me.divisionDataSource.data()[0].ID;
                }

                me.divisionMultiSelect.trigger('change');
            });

            this.divisionMultiSelect.focus();
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.data.data([]);
    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_pos").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.divisionID = [];
            me.divisionMultiSelect.trigger('change');
        });
    }

    setDivisionDataSource() {
        let me = this;
        this.divisionDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Divisions",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchDivisions',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            Text = "";

                        if (me.divisionMultiSelect) {
                            Text = <string>me.divisionMultiSelect.input.val();
                        }

                        if (Text == 'Division') {
                            Text = "";
                        }

                        if (!me.resetDivision) {
                            if (Text == "" && me.divisionMultiSelect) {
                                var dataItems = me.divisionMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                }
                            }
                        }
                        else {
                            me.resetDivision = false;
                        }

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    divisionMultiSelect_OnChange(e) {
        let me = this;

        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        if (!me.divisionID || me.divisionID.length == 0 || me.divisionID[0] == '') {
            this.productID = [];
            this.productDataSource.read();
        }
        else {

            if (this.divisionID && this.divisionID.length > 0) {
                var codes = this.divisionID[0].split(',');

                if (!this.clientCode || this.clientCode[0] == '' || this.clientCode.length == 0 || this.clientCode[0] != codes[0]) {
                    this.clientCode = [];
                    this.clientCode[0] = codes[0];
                }
            }

            this.productDataSource.read().then(function () {
                if (me.productDataSource.total() == 1) {
                    me.productID = [];

                    me.productID[0] = me.productDataSource.data()[0].ID;

                    me.jobMultiSelect.focus();
                }
                else {
                }

                me.productMultiSelect.trigger('change');
            });

            me.productMultiSelect.focus();
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.data.data([]);
    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_pos").data("kendoMultiSelect");

        multiselect.bind("deselect", () => {
            me.productID = [];
            me.productMultiSelect.trigger('change');
        });
    }

    setProductDataSource() {
        let me = this;
        this.productDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Products",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchProducts',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            officeCode = '',
                            Text = "";

                        if (me.productMultiSelect) {
                            Text = <string>me.productMultiSelect.input.val();
                        }

                        if (Text == 'Product') {
                            Text = "";
                        }

                        if (!me.resetProduct) {
                            if (Text == "" && me.productMultiSelect) {
                                var dataItems = me.productMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                }
                            }
                        }
                        else {
                            me.resetProduct = false;
                        }

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }
                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            Text: Text
                        }
                    }
                }
            }
        });
    }

    productMultiSelect_OnChange(e) {
        let me = this;

        if (this.productID && this.productID.length > 0) {
            var codes = this.productID[0].split(',');

            if (!this.clientCode || this.clientCode[0] == '' || this.clientCode.length == 0 || this.clientCode[0] != codes[0]) {
                this.clientCode = [];
                this.clientCode[0] = codes[0];
            }

            if (!this.divisionID || this.divisionID[0] == '' || this.divisionID.length == 0 || this.divisionID[0] != codes[0] + ',' + codes[1]) {
                this.divisionDataSource.read().then(() => {
                    me.divisionID = [];
                    me.divisionID[0] = codes[0] + ',' + codes[1];
                });
            }

            this.jobMultiSelect.focus();
        }
        else {
            this.productDataSource.read();
        }

        this.resetJob = true;
        this.resetComponent = true;

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.data.data([]);
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 5,
            schema: {
                data: "Jobs",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchJob',
                    data: function () {

                        var clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            officeCode = '',
                            AccountExecutive = '',
                            CampaignID = 0,
                            SalesClass = '',
                            JobType = '',
                            Text = "";

                        if (me.jobMultiSelect) {
                            Text = <string>me.jobMultiSelect.input.val();
                        }

                        if (Text == 'Job') {
                            Text = "";
                        }

                        if (!me.resetJob) {
                            if (Text == "" && me.jobMultiSelect) {
                                var dataItems = me.jobMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Code.toString() + ' - ' + dataItems[0].Description;
                                }
                            }
                        }
                        else {
                            me.resetJob = false;
                        }

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }
                        if (me.productID && me.productID.length > 0) {
                            productCode = me.productID[0].split(',')[2];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            AccountExecutive: AccountExecutive,
                            ShowClosedJobs: 0,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            Text: Text
                        }
                    }
                }
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
    }

    onJobReady(e) {
        let me = this;

        var multiselect = $("#JobMultiSelect_pos").data("kendoMultiSelect");

        multiselect.list.width(450);

        multiselect.bind("deselect", () => {
            me.jobCode = [];
            me.jobMultiSelect.trigger('change');
        });
    }

    backFillCDP() {
        let dfd = jQuery.Deferred();

        let me = this;
        if (!this.clientCode || this.clientCode.length == 0 || this.clientCode[0] == '' ||
            !this.divisionID || this.divisionID.length == 0 || this.divisionID[0] == '' ||
            !this.productID || this.productID.length == 0 || this.productID[0] == '') {

            if (!me.backFillInProgress) {
                me.backFillInProgress = true;
                $.ajax({
                    url: 'Utilities/SearchCDPForJob',
                    type: 'GET',
                    dataType: 'json',
                    data: {
                        JobNumber: this.jobCode[0]
                    },
                    success: (data) => {
                        if (data.ClientCode != me.clientCode[0]) {
                            console.log('setting client');
                            me.clientCode = [];
                            me.clientCode[0] = data.ClientCode;
                        }

                        if (me.divisionID[0] != data.ClientCode + ',' + data.DivisionCode) {
                            setTimeout(() => {
                                console.log('reading division data');
                                me.divisionDataSource.read().then(() => {
                                    console.log('setting division');
                                    me.divisionID = []
                                    me.divisionID[0] = data.ClientCode + ',' + data.DivisionCode;

                                    setTimeout(() => {
                                        console.log('reading product data');
                                        me.productDataSource.read().then(() => {
                                            console.log('setting product');
                                            me.productID = [];
                                            me.productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;

                                            me.backFillInProgress = false;
                                            dfd.resolve();
                                        });
                                    }, 15);
                                });
                            }, 15);
                        }
                        else if (me.productID[0] != data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode) {
                            me.productID = [];
                            me.productDataSource.read().then(() => {
                                me.productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;

                                me.backFillInProgress = false;
                                dfd.resolve();
                            });
                        }
                    }
                });
            }
        }
        else {
            dfd.resolve();
        }

        return dfd;
    }

    jobMultiSelect_OnChange(e) {
        let me = this;

        var dataItems = me.jobMultiSelect.dataItems();

        console.log(this.jobDataSource.data());

        //if (dataItems && dataItems.length > 0) {
        //    if (!this.clientCode || this.clientCode.length < 1 || this.clientCode[0] == '' || this.clientCode[0] != dataItems[0].ClientCode) {
        //        this.clientCode[0] = dataItems[0].ClientCode;
        //    }
        //}

        if (!this.jobCode || this.jobCode.length < 1 || this.jobCode[0] == '') {
            this.componentCode = [];
            this.resetComponent = true;
            this.componentDataSource.read();
        }
        else {

            this.backFillCDP();

            this.componentDataSource.read().then(function () {
                if (me.componentDataSource.total() == 1) {
                    me.componentCode = [];
                    me.componentCode[0] = me.componentDataSource.data()[0].ID;

                    me.search();
                }
            });

            this.componentMultiSelect.focus();
        }


        this.data.data([]);
    }

    setComponentDataSource() {
        let me = this;

        this.componentDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 31,
            schema: {
                data: "JobComponents",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchComponent',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            jobCode = '',
                            AccountExecutive = '',
                            CampaignID = 0,
                            SalesClass = '',
                            JobType = '',
                            Text = "";

                        if (me.componentMultiSelect) {
                            Text = <string>me.componentMultiSelect.input.val();
                        }

                        if (Text == 'Component') {
                            Text = '';
                        }

                        if (!me.resetComponent) {
                            if (Text == "" && me.componentMultiSelect) {
                                var dataItems = me.componentMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                }
                            }
                        }
                        else {
                            me.resetComponent = false;
                        }

                        //if (me.officeCode && me.officeCode.length > 0) {
                        //    officeCode = me.officeCode[0];
                        //}
                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }

                        if (me.productID && me.productID.length > 0) {
                            productCode = me.productID[0].split(',')[2];
                        }
                        if (me.jobCode && me.jobCode.length > 0) {
                            jobCode = me.jobCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            JobCode: jobCode,
                            AccountExecutive: AccountExecutive,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            ShowClosedJobs: 0,
                            Text: Text
                        }
                    }
                }
            }
        });
        if (this.componentMultiSelect) {
            this.componentMultiSelect.setDataSource(this.componentDataSource);
        }
    }

    onComponentReady(e) {
        let me = this;

        var multiselect = $("#ComponentMultiSelect_pos").data("kendoMultiSelect");

        multiselect.list.width(450);

        multiselect.bind("deselect", () => {
            me.componentCode = [];
            me.componentMultiSelect.trigger('change');
        });
    }

    componentMultiSelect_OnChange(e) {
        let me = this;

        if (this.componentCode && this.componentCode.length == 1 && this.componentCode[0] != '') {
            var codes = this.componentCode[0].split(',');

            if (!me.jobCode || me.jobCode.length < 1 || me.jobCode[0] != codes[0]) {
                me.jobCode = [];
                me.jobCode[0] = codes[0];
            }

            if (!this.clientCode || this.clientCode.length == 0 || this.clientCode[0] == '' ||
                !this.divisionID || this.divisionID.length == 0 || this.divisionID[0] == '' ||
                !this.productID || this.productID.length == 0 || this.productID[0] == '') {
                if (!me.backFillInProgress) {
                    me.backFillInProgress = true;
                    $.ajax({
                        url: 'Utilities/SearchCDPForJob',
                        type: 'GET',
                        dataType: 'json',
                        data: {
                            JobNumber: codes[0]
                        },
                        success: (data) => {
                            me.clientCode = [];
                            me.clientCode[0] = data.ClientCode;
                            me.divisionDataSource.read().then(() => {
                                me.divisionID = []
                                me.divisionID[0] = data.ClientCode + ',' + data.DivisionCode;

                                me.productDataSource.read().then(() => {
                                    me.productID = [];
                                    me.productID[0] = data.ClientCode + ',' + data.DivisionCode + ',' + data.ProductCode;
                                    me.backFillInProgress = false;

                                    me.search();
                                });
                            });
                        }
                    });
                }
            }

            this.vendorMultiSelect.focus();
        }
        else {
            this.componentDataSource.read();
        }
    }

    setEmployeeDataSource() {
        let me = this;
        this.employeeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchEmployee'
                }
            }
        });
        if (this.employeeMultiSelect) {
            this.employeeMultiSelect.setDataSource(this.employeeDataSource);
        }
    }

    employeeMultiSelect_OnChange(e) {
        this.data.data([]);

        if (this.employeeCode && this.employeeCode.length > 0 && this.employeeCode[0] != '') {
            this.approversMultiSelect.focus()
        }
    }

    setApproversDataSource() {
        let me = this;
        this.approversDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchPOApprovers'
                }
            }
        });
        if (this.approversMultiSelect) {
            this.approversMultiSelect.setDataSource(this.approversDataSource);
        }
    }

    approversMultiSelect_OnChange(e) {
        this.data.data([]);

        this.statusMultiSelect.focus();
    }

    setVendorDataSource() {
        let me = this;
        this.vendorDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchVendor'
                }
            }
        });
        if (this.vendorMultiSelect) {
            this.vendorMultiSelect.setDataSource(this.vendorDataSource);
        }
    }

    vendorMultiSelect_OnChange(e) {
        this.data.data([]);

        this.employeeMultiSelect.focus();
    }

    getPageSize(): number {

        var pageSizegrid: number;

        this.service.getPageSize("PurchaseOrderSearchGrid").then(response => {

            this.pageSize = response.content
            return response.content;
        });

        return pageSizegrid;
    }

    onDataBound(e) {
        var PageSize = this.grid.dataSource.pageSize();
        this.totalpages = this.grid.pager.totalPages();
        this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        if (this.pageSize != PageSize) {
            this.service.updatePageSize(PageSize, "PurchaseOrderSearchGrid");
            this.pageSize = PageSize;
        }
    }

    newPurchaseOrder() {
        let me = this;
        this.dialogService.open({ viewModel: NewPurchaseOrderDlg, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                me.search();
            }
        });
    }

    bookmark() {
        let client = new HttpClient();
        let me = this;

        var poNumber = '',
            poDescription = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            jobNumber = 0,
            componentNumber = 0,
            vendor = '',
            fromDate = null,
            toDate = null,
            dueDate = null,
            issuedBy = '',
            approver = '',
            poStatus = '';

        if (me.poNumber && me.poNumber.length > 0) {
            poNumber = me.poNumber[0];
        }
      
        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0].split(',')[1];
        }

        if (me.productID && me.productID.length > 0) {
            productCode = me.productID[0].split(',')[2];
        }

        if (me.jobCode && me.jobCode.length > 0) {
            jobNumber = me.jobCode[0];
        }

        if (me.componentCode && me.componentCode.length > 0) {
            componentNumber = me.componentCode[0];
        }

        if (me.vendorCode && me.vendorCode.length > 0) {
            vendor = me.vendorCode[0];
        }

        if (me.FromDate != null) {
            fromDate = me.FromDate;
        }

        if (me.ToDate != null) {
            toDate = me.ToDate;
        }

        if (me.DueDate != null) {
            dueDate = me.DueDate;
        }

        if (me.employeeCode && me.employeeCode.length > 0) {
            issuedBy = me.employeeCode[0];
        }

        if (me.approversCode && me.approversCode.length > 0) {
            approver = me.approversCode[0];
        }

        if (me.status && me.status.length > 0) {
            poStatus = me.status[0];
        }


        var data = {
            PurchaseOrderNumber: poNumber,
            PODescription: me.description,
            Client: clientCode,
            Division: divisionCode,
            Product: productCode,
            JobNumber: jobNumber > 0 ? jobNumber : null,
            ComponentNumber: componentNumber > 0 ? componentNumber : null,
            Vendor: vendor,
            FromDate: fromDate,
            ToDate: toDate,
            DueDate: dueDate,
            IssuedBy: issuedBy,
            Approver: approver,
            POStatus: poStatus
        };

        client.post('PurchaseOrders/BookMarkPage', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }

    attached() {
        let client = new HttpClient();

        client.get('Utilities/GetDateFormat')
            .then(data => {

                this.fromDatePicker.setOptions({
                    format: data.content.DateFormat,
                    parseFormats: data.content.DateInputFormat
                });

                this.toDatePicker.setOptions({
                    format: data.content.DateFormat,
                    parseFormats: data.content.DateInputFormat
                });

                this.dueDatePicker.setOptions({
                    format: data.content.DateFormat,
                    parseFormats: data.content.DateInputFormat
                });
            });
    }

    gridReady(e) {
        if (this.isbookmark) {
            if ((this.poNumber && this.poNumber.length > 0 && this.poNumber[0] != '') ||
                (this.clientCode && this.clientCode.length > 0 && this.clientCode[0] != '') ||
                (this.divisionID && this.divisionID.length > 0 && this.divisionID[0] != '') ||
                (this.productID && this.productID.length > 0 && this.productID[0] != '') ||
                (this.jobCode && this.jobCode.length > 0 && this.jobCode[0] > 0) ||
                (this.componentCode && this.componentCode.length > 0 && this.componentCode[0] > 0) ||
                (this.vendorCode && this.vendorCode.length > 0 && this.vendorCode[0] != '') ||
                (this.employeeCode && this.employeeCode.length > 0 && this.employeeCode[0] != '') ||
                (this.approversCode && this.approversCode.length > 0 && this.approversCode[0] != '') ||
                (this.status && this.status.length > 0 && this.status[0] != '')) {
                setTimeout(() => {
                    this.search();
                }, 500);
            }
        }
    }

    activate(params: any) {

        //console.log("activate " + params.Parameters.indexOf('c'));
        if (params.Parameters != undefined) {
            if (params.Parameters['po'] != undefined) {
                this.poNumber[0] = params.Parameters['po'];
            }
            if (params.Parameters['podescription'] != undefined) {
                this.description = params.Parameters['podescription'];
            }
            if (params.Parameters['c'] != undefined) {
                this.clientCode[0] = params.Parameters['c'];
            }
            if (params.Parameters['d'] != undefined) {
                this.divisionID[0] = params.Parameters['d'];
            }
            if (params.Parameters['p'] != undefined) {
                this.productID[0] = params.Parameters['p'];
            }           
            if (params.Parameters['j'] != undefined) {
                this.jobCode[0] = params.Parameters['j'];
            }
            if (params.Parameters['jc'] != undefined) {
                this.componentCode[0] = params.Parameters['jc'];
            }
            if (params.Parameters['vc'] != undefined) {
                this.vendorCode[0] = params.Parameters['vc'];
            }
            if (params.Parameters['fromdate'] != undefined) {
                this.FromDate = new Date(params.Parameters['fromdate'].replace(/%2f/g, '/'));
            }
            if (params.Parameters['todate'] != undefined) {
                this.ToDate = new Date(params.Parameters['todate'].replace(/%2f/g, '/'));
            }
            if (params.Parameters['duedate'] != undefined) {
                this.DueDate = new Date(params.Parameters['duedate'].replace(/%2f/g, '/'));
            }
            if (params.Parameters['issued'] != undefined) {
                this.employeeCode[0] = params.Parameters['issued'];
            }
            if (params.Parameters['approver'] != undefined) {
                this.approversCode[0] = params.Parameters['approver'];
            }
            if (params.Parameters['postatus'] != undefined) {
                this.status = params.Parameters['postatus'];
            }

            this.isbookmark = true;
        }

    }

    clientMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            Text = "";

        if (me.clientMultiSelect) {
            Text = <string>me.clientMultiSelect.input.val();

            if (Text == 'Client') {
                Text = '';
            }

            if (Text == "") {
                var dataItems = me.clientMultiSelect.dataItems();

                if (dataItems && dataItems.length > 0) {
                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                }
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }


        var data = {
            OfficeCode: officeCode,
            Text: Text,
            ClientCode: options.value[0]
        }


        $.ajax({
            url: 'Utilities/SearchClientIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        });
    }

    divisionMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            Text = "";

        if (me.divisionMultiSelect) {
            Text = <string>me.divisionMultiSelect.input.val();

            if (Text == 'Division') {
                Text = '';
            }

            if (Text == "") {
                var dataItems = me.divisionMultiSelect.dataItems();

                if (dataItems && dataItems.length > 0) {
                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                }
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: options.value[0],
            SprintID: 0,
            Text: Text
        }

        $.ajax({
            url: 'Utilities/SearchDivisionIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        });
    }

    productMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            Text = "",
            divisionCode = "";

        if (me.productMultiSelect) {
            Text = <string>me.productMultiSelect.input.val();

            if (Text == 'Product') {
                Text = '';
            }

            if (Text == "") {
                var dataItems = me.productMultiSelect.dataItems();

                if (dataItems && dataItems.length > 0) {
                    Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                }
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0].split(',')[1];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductID: options.value[0],
            Text: Text
        };


        $.ajax({
            url: 'Utilities/SearchProductIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        }).fail(function () {
            alert("error");
        });
    }

    jobMapper(options) {
        let me = (<any>this).me;

        console.log('job mapper ' + options.value[0]);

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            jobCode = '',
            AccountExecutive = '',
            CampaignID = 0,
            SalesClass = '',
            JobType = '',
            Text = "";

        Text = <string>me.jobMultiSelect.input.val();

        if (Text == 'Job') {
            Text = '';
        }

        if (Text == "" && me.jobMultiSelect) {
            var dataItems = me.jobMultiSelect.dataItems();

            if (dataItems && dataItems.length > 0) {
                Text = dataItems[0].Code.toString() + ' - ' + dataItems[0].Description;
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }
        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }
        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0].split(',')[1];
        }
        if (me.productID && me.productID.length > 0) {
            productCode = me.productID[0].split(',')[2];
        }
        if (me.jobCode && me.jobCode.length > 0) {
            jobCode = me.jobCode[0];
        }
        if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
            AccountExecutive = me.accountExecutiveCode[0];
        }
        if (me.jobTypeCode && me.jobTypeCode.length > 0) {
            JobType = me.jobTypeCode[0];
        }
        if (me.salesClassCode && me.salesClassCode.length > 0) {
            SalesClass = me.salesClassCode[0];
        }
        if (me.campaignID && me.campaignID.length > 0) {
            CampaignID = me.campaignID[0];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductCode: productCode,
            JobCode: options.value[0],
            AccountExecutive: AccountExecutive,
            CampaignID: CampaignID,
            SalesClass: SalesClass,
            JobType: JobType,
            ShowClosedJobs: me.showClosed,
            Text: Text
        }

        $.ajax({
            url: 'Utilities/SearchJobIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                console.log('job mapper success ' + data);
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    componentMapper(options) {
        let me = (<any>this).me;

        console.log('Component mapper ' + options.value[0]);

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            jobCode = '',
            AccountExecutive = '',
            CampaignID = 0,
            SalesClass = '',
            JobType = '',
            Text = "";

        Text = <string>me.componentMultiSelect.input.val();

        if (Text == 'Component') {
            Text = '';
        }

        if (Text == "" && me.componentMultiSelect) {
            var dataItems = me.componentMultiSelect.dataItems();

            if (dataItems && dataItems.length > 0) {
                Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }
        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }
        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0].split(',')[1];
        }
        if (me.productID && me.productID.length > 0) {
            productCode = me.productID[0].split(',')[2];
        }
        if (me.jobCode && me.jobCode.length > 0) {
            jobCode = me.jobCode[0];
        }
        if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
            AccountExecutive = me.accountExecutiveCode[0];
        }
        if (me.jobTypeCode && me.jobTypeCode.length > 0) {
            JobType = me.jobTypeCode[0];
        }
        if (me.salesClassCode && me.salesClassCode.length > 0) {
            SalesClass = me.salesClassCode[0];
        }
        if (me.campaignID && me.campaignID.length > 0) {
            CampaignID = me.campaignID[0];
        }

        var data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductCode: productCode,
            JobCode: jobCode,
            ComponentID: options.value[0],
            AccountExecutive: AccountExecutive,
            CampaignID: CampaignID,
            SalesClass: SalesClass,
            JobType: JobType,
            ShowClosedJobs: me.showClosed,
            Text: Text
        }


        $.ajax({
            url: 'Utilities/SearchComponentIndex',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }


    constructor(dialogService: DialogService, service: UserSettingService, openModule) {
        super();
        let me = this;
        this.dialogService = dialogService;
        this.service = service;
        this.openModule = openModule;
        this.getPageSize();

        this.OmitClosedId = this.uuidv4();
        this.OmitVoidedId = this.uuidv4();
        this.PrintedId = this.uuidv4();

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/PurchaseOrders/Search',
                    data: function () {

                        var jobCode = 0,
                            componentCode = 0,
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            poNumber = 0,
                            vendorCode = '',
                            employeeCode = '',
                            approversCode = '',
                            fromDate = null,
                            toDate = null,
                            dueDate = null,
                            status = 0;

                        if (me.vendorCode && me.vendorCode.length > 0) {
                            vendorCode = me.vendorCode[0];
                        }

                        if (me.poNumber && me.poNumber.length > 0) {
                            poNumber = me.poNumber[0];
                        }

                        if (me.jobCode && me.jobCode.length > 0) {
                            jobCode = me.jobCode[0]
                        }

                        if (me.componentCode && me.componentCode.length > 0) {
                            var codes = me.componentCode[0].split(',');
                            componentCode = codes[1];
                        }

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }

                        if (me.productID && me.productID.length > 0) {
                            productCode = me.productID[0].split(',')[2];
                        }

                        if (me.employeeCode && me.employeeCode.length > 0) {
                            employeeCode = me.employeeCode[0];
                        }

                        if (me.approversCode && me.approversCode.length > 0) {
                            approversCode = me.approversCode[0];
                        }

                        if (me.status && me.status.length > 0) {
                            status = me.status[0];
                        }

                        if (me.FromDate) {
                            fromDate = me.FromDate.toDateString();
                        }

                        if (me.ToDate) {
                            toDate = me.ToDate.toDateString();
                        }

                        if (me.DueDate) {
                            dueDate = me.DueDate.toDateString();
                        }

                        return {
                            PONumber: poNumber,
                            Description: me.description,
                            JobCode: jobCode,
                            ComponentCode: componentCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            VendorCode: vendorCode,
                            FromDate: fromDate,
                            ToDate: toDate,
                            DueDate: dueDate,
                            EmployeeCode: employeeCode,
                            ApproversCode: approversCode,
                            Status: status,
                            OmitClosed: me.OmitClosed,
                            OmitVoided: me.OmitVoided,
                            Printed: me.Printed
                        }
                    }
                }
            },
            pageSize: this.pageSize,
            schema: {
                model: {
                    id: 'PONumber',
                    fields: {
                        PONumber: { type: 'number' },
                        DisplayPONumber: { type: 'string' },
                        PODate: { type: 'date' },
                        VendorCode: { type: 'string' },
                        VendorName: { type: 'string' },
                        Description: { type: 'string' },
                        DueDate: { type: 'date' },
                        IssuedBy: { type: 'string' },
                        VoidDate: { type: 'date' },
                        Voided: { type: 'number' }
                    }
                }
            }
        });

        me.setComponentDataSource();
        me.setJobDataSource();
        me.setClientDataSource();
        me.setDivisionDataSource();
        me.setProductDataSource();
        me.setPONumberDataSource();
        me.setVendorDataSource();
        me.setEmployeeDataSource();
        me.setApproversDataSource();

        this.virtualClient = {
            itemHeight: 26,
            me: this,
            valueMapper: this.clientMapper
        };

        this.virtualDivision = {
            itemHeight: 26,
            me: this,
            valueMapper: this.divisionMapper
        };

        this.virtualProduct = {
            itemHeight: 26,
            me: this,
            valueMapper: this.productMapper
        };

        this.virtualJob = {
            itemHeight: 26,
            me: this,
            valueMapper: this.jobMapper
        };

        this.virtualComponent = {
            itemHeight: 26,
            me: this,
            valueMapper: this.componentMapper
        };

        //this.CanAdd('');
    }
}
