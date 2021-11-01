import { UserSettingService } from 'services/utilities/user-settings-service';
import { ModuleBase } from 'modules/base/module-base';
import { customElement } from 'aurelia-framework'
import { Webvantage } from '../../../webvantage';
import { DialogService } from 'aurelia-dialog';
import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';

@inject(UserSettingService, DialogService, 'openModule')
export class Estimate extends ModuleBase {
    dialogService: DialogService;
    openModule;
    service: UserSettingService;

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;
    jobPadding: number = 6;
    jobComponentPadding: number = 3;

    officeMultiSelect: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    divisionMultiSelect: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;
    productMultiSelect: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;
    salesClassMultiSelect: kendo.ui.MultiSelect;
    salesClassDataSource: kendo.data.DataSource;
    campaignMultiSelect: kendo.ui.MultiSelect;
    campaignDataSource: kendo.data.DataSource;
    jobMultiSelect: kendo.ui.MultiSelect;
    jobDataSource: kendo.data.DataSource;
    componentMultiSelect: kendo.ui.MultiSelect;
    componentDataSource: kendo.data.DataSource;

    estimateNumberMultiSelect: kendo.ui.MultiSelect;
    estimateComponentNumberMultiSelect: kendo.ui.MultiSelect;
    estimateNumberDataSource: kendo.data.DataSource;
    estimateComponentNumberDataSource: kendo.data.DataSource;

    virtualClient;
    virtualDivision;
    virtualProduct;
    virtualJob;
    virtualComponent;

    resetClient: boolean = false;
    resetDivision: boolean = false;
    resetProduct: boolean = false;
    resetJob: boolean = false;
    resetComponent: boolean = false;
    backFillInProgress: boolean = false;

    // search parameters
    officeCode = [];
    clientCode = [];
    divisionID = [];
    productID = [];
    salesClassCode = [];
    campaignID = [];
    jobCode = [];
    componentCode = [];

    estimateNumber = [];
    estimateComponentNumber = [];

    theId: string = "";

    showClosed: boolean = false;

    pageSize: number = 15;
    totalpages: number;
    isbookmark: boolean = false;

    //search function init
    search() {
        let me = this;

        me.data.data([]);
        
        this.grid.dataSource.query({ page: 1, pageSize: this.pageSize }).then(function () {
            if (me.data.total() == 1) {
                var item = me.data.data()[0];

                me.openModule('', me.showDetailView(item.EstimateNumber, item.EstimateComponentNumber,item.JobNumber, item.JobComponentNumber));
            }
        });
    }

    showDetailView(Estimate, EstComponent, Job, JobComponent) {
        if (Job <= 0) {
            return "Estimating.aspx?EstNum=" + Estimate + "&EstComp=" + EstComponent + "&newEst=edit";
        }

        return "Content.aspx?contaid=4&e=" + Estimate + "&ec=" + EstComponent + "&j=" + Job + "&jc=" + JobComponent;
    }

    clearSearch() {
        this.officeCode = [];

        this.clientCode = [];
        this.divisionID = [];
        this.productID = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();

        this.salesClassCode = [];
        this.campaignID = [];
        this.jobCode = [];
        this.componentCode = [];

        this.setOfficeDataSource();
        this.setSalesClassDataSource();
        this.setCampaignDataSource();
        this.setJobDataSource();
        this.setComponentDataSource();

        this.estimateNumber = [];
        this.setEstimateNumberDataSource();
        this.estimateComponentNumber = [];
        this.setEstimateComponentNumberDataSource();

        this.data.data([]);

        this.showClosed = false;
    }

    showClosedCheckChanged() {
        this.jobCode = [];
        this.componentCode = [];
        this.estimateNumber = [];
        this.estimateComponentNumber = [];

        this.setJobDataSource();
        this.setComponentDataSource();
        this.setEstimateNumberDataSource();
        this.setEstimateComponentNumberDataSource();
        this.data.data([]);
    }

    setOfficeDataSource() {
        let me = this;
        this.officeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchOffices'
                }
            }
        });
        if (this.officeMultiSelect) {
            this.officeMultiSelect.setDataSource(this.officeDataSource);
        }
    }

    officeMultiSelect_OnChange(e) {
        this.clientCode = [];
        this.divisionID = [];
        this.productID = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();

        this.jobCode = [];
        this.setJobDataSource();
        this.componentCode = [];
        this.setComponentDataSource();
        this.campaignID = [];
        this.setCampaignDataSource();
        this.estimateNumber = [];
        this.setEstimateNumberDataSource();
        this.estimateComponentNumber = [];
        this.setEstimateComponentNumberDataSource();

        if (this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != "") {
            this.clientMultiSelect.focus();
        }

        this.data.data([]);
   }

    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_es").data("kendoMultiSelect");

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
            pageSize: 31,
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

                            if (!me.resetClient) {
                                if (Text == "") {
                                    var dataItems = me.clientMultiSelect.dataItems();

                                    if (dataItems && dataItems.length > 0) {
                                        Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    }
                                }
                            }
                            else {
                                me.resetClient = false;
                            }
                        }

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
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

        this.campaignID = [];

        if (!me.clientCode || me.clientCode.length == 0 || me.clientCode[0] == '') {
            this.divisionID = [];
            this.productID = [];

            this.productDataSource.read();
            this.divisionDataSource.read();
        }
        else {
            this.divisionDataSource.read().then(function () {
                if (me.divisionDataSource.total() == 1) {
                    me.divisionID = [];
                    me.divisionID[0] = me.divisionDataSource.data()[0].ID;
                }

                me.divisionMultiSelect.trigger('change');
                me.divisionMultiSelect.focus();
            });
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();
        this.setCampaignDataSource();

        this.data.data([]);
    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_es").data("kendoMultiSelect");

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
            pageSize: 31,
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

                            if (Text == 'Division') {
                                Text = "";
                            }

                            if (!me.resetDivision) {
                                if (Text == "") {
                                    var dataItems = me.divisionMultiSelect.dataItems();

                                    if (dataItems && dataItems.length > 0) {
                                        Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    }
                                }
                            }
                            else {
                                me.resetDivision = false;
                            }
                        }

                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }

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
        this.campaignID = [];
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

                    me.salesClassMultiSelect.focus();
                }
                else {
                    me.productMultiSelect.focus();
                }
                //me.productMultiSelect.trigger('change');
            });
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();
        this.setCampaignDataSource();

        this.data.data([]);
    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_es").data("kendoMultiSelect");

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
            pageSize: 31,
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

                            if (Text == 'Product') {
                                Text = "";
                            }

                            if (!me.resetProduct) {
                                if (Text == "") {
                                    var dataItems = me.productMultiSelect.dataItems();

                                    if (dataItems && dataItems.length > 0) {
                                        Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    }
                                }
                            }
                            else {
                                me.resetProduct = false;
                            }
                        }

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }
                        if (me.divisionID && me.divisionID.length > 0) {
                            divisionCode = me.divisionID[0].split(',')[1];
                        }
                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }

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
        this.campaignID = [];
        this.resetJob = true;
        this.resetComponent = true;

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

            this.salesClassMultiSelect.focus();
        }
        else {
            this.productDataSource.read();
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();
        this.setCampaignDataSource();

        this.data.data([]);
    }

    setSalesClassDataSource() {
        let me = this;
        this.salesClassDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchSalesClass'
                }
            }
        });
        if (this.salesClassMultiSelect) {
            this.salesClassMultiSelect.setDataSource(this.salesClassDataSource);
        }
    }

    salesClassMultiSelect_OnChange(e) {

        this.jobCode = [];
        this.componentCode = [];
        this.setJobDataSource();
        this.setComponentDataSource();
        this.estimateNumber = [];
        this.setEstimateNumberDataSource();
        this.estimateComponentNumber = [];
        this.setEstimateComponentNumberDataSource();

        if (this.salesClassCode && this.salesClassCode.length > 0 && this.salesClassCode[0] != '') {
            this.campaignMultiSelect.focus();
        }

        this.data.data([]);
    }

    setCampaignDataSource() {
        let me = this;


        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            data = {},
            url = 'Utilities/SearchCampaign';

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

        data = {
            OfficeCode: officeCode,
            ClientCode: clientCode,
            DivisionCode: divisionCode,
            ProductCode: productCode,
            InclClosed: me.showClosed
        };

        this.campaignDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: url,
                    data: data
                }
            }
        });
        if (this.campaignMultiSelect) {
            this.campaignMultiSelect.setDataSource(this.campaignDataSource);
        }
    }

    campaignMultiSelect_OnChange(e) {
        this.data.data([]);

        this.jobCode = [];
        this.componentCode = [];
        this.setJobDataSource();
        this.setComponentDataSource();
        this.estimateNumber = [];
        this.setEstimateNumberDataSource();
        this.estimateComponentNumber = [];
        this.setEstimateComponentNumberDataSource();

        if (this.campaignID && this.campaignID.length > 0 && this.campaignID[0] != 0) {
            this.estimateNumberMultiSelect.focus();
        }

    }


    onJobReady(e) {
        let me = this;

        var multiselect = $("#JobMultiSelect_es").data("kendoMultiSelect");

        multiselect.list.width(450);

        multiselect.bind("deselect", () => {
            me.jobCode = [];
            me.jobMultiSelect.trigger('change');
        });
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging: true,
            pageSize: 31,
            schema: {
                data: "Jobs",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchJobEstimate',
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

                            if (Text == 'Job') {
                                Text = "";
                            }

                            if (!me.resetJob) {
                                if (Text == "") {
                                    var dataItems = me.jobMultiSelect.dataItems();

                                    //if (dataItems && dataItems.length > 0) {
                                    //    Text = dataItems[0].Code.toString() + ' - ' + dataItems[0].Description;
                                    //}
                                }
                            }
                            else {
                                me.resetJob = false;
                            }
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
                        if (me.officeCode && me.officeCode.length > 0) {
                            officeCode = me.officeCode[0];
                        }
                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            SalesClass = me.salesClassCode[0];
                        }
                        if (me.campaignID && me.campaignID.length > 0) {
                            CampaignID = me.campaignID[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            AccountExecutive: AccountExecutive,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            Text: Text,
                            ShowClosedJobs: me.showClosed
                        }
                    }
                }
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
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
        this.resetComponent = true;

        var dataItems = me.jobMultiSelect.dataItems();

        if (!this.jobCode || this.jobCode.length < 1 || this.jobCode[0] == '') {
            this.componentCode = [];
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

            me.componentMultiSelect.focus();
        }

        this.data.data([]);
    }

    onComponentReady(e) {
        let me = this;

        var multiselect = $("#ComponentMultiSelect_es").data("kendoMultiSelect");

        multiselect.list.width(450);

        multiselect.bind("deselect", () => {
            me.componentCode = [];
            me.componentMultiSelect.trigger('change');
        });
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
                    url: 'Utilities/SearchJobCompEstimate',
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

                            if (Text == 'Component') {
                                Text = '';
                            }

                            if (!me.resetComponent) {
                                if (Text == "") {
                                    var dataItems = me.componentMultiSelect.dataItems();

                                    if (dataItems && dataItems.length > 0) {
                                        Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    }
                                }
                            }
                            else {
                                me.resetComponent = false;
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
                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            SalesClass = me.salesClassCode[0];
                        }
                        if (me.campaignID && me.campaignID.length > 0) {
                            CampaignID = me.campaignID[0];
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
                            Text: Text,
                            ShowClosedJobs: me.showClosed
                        }
                    }
                }
            }
        });
        if (this.componentMultiSelect) {
            this.componentMultiSelect.setDataSource(this.componentDataSource);
        }
    }

    componentMultiSelect_OnChange(e) {
        let me = this;

        if (this.componentCode && this.componentCode.length == 1 && this.componentCode[0] != '') {
            var codes = this.componentCode[0].split(',');


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

                                    me.jobDataSource.read().then(() => {
                                        //set job code last
                                        if (!me.jobCode || me.jobCode.length == 0 || me.jobCode[0] == '' || me.jobCode[0] != codes[0]) {
                                            me.jobCode = [];
                                            me.jobCode[0] = codes[0];
                                            me.backFillInProgress = false;

                                            if (this.componentCode && this.componentCode.length == 1) {
                                                this.search();
                                            }
                                            else {
                                                this.data.data([]);
                                            }
                                        }
                                    });
                                });
                            });
                        }
                    });
                }
            }
        }
        else {
            this.componentDataSource.read();
        }
    }


    setEstimateNumberDataSource() {
        let me = this;
        this.estimateNumberDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchEstimateNumber',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            jobCode = 0,
                            componentCode = 0,
                            salesClass = '',
                            campaignID = 0;

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
                        if (me.componentCode && me.componentCode.length > 0) {
                            componentCode = me.componentCode[0];
                        }
                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            salesClass = me.salesClassCode[0];
                        }
                        if (me.campaignID && me.campaignID.length > 0) {
                            campaignID = me.campaignID[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            SalesClass: salesClass,
                            CampaignID: campaignID,
                            JobCode: jobCode,
                            ComponentCode: componentCode
                        };
                    }
                }
            }
        });
        if (this.estimateNumberMultiSelect) {
            this.estimateNumberMultiSelect.setDataSource(this.estimateNumberDataSource);
        }
    }

    estimateNumberMultiSelect_OnChange(e) {
        let me = this;
        this.estimateComponentNumber = [];
        this.setEstimateComponentNumberDataSource();
        this.data.data([]);

        this.estimateComponentNumberDataSource.read().then(function () {
            if (me.estimateComponentNumberDataSource.total() == 1) {
                me.estimateComponentNumber = [];
                me.estimateComponentNumber[0] = me.estimateComponentNumberDataSource.data()[0].Code

                me.search();
            }
        });

        if (this.estimateNumber && this.estimateNumber.length > 0 && this.estimateNumber[0] != 0) {
            this.estimateComponentNumberMultiSelect.focus();
        }
    }

    setEstimateComponentNumberDataSource() {
        let me = this;
        this.estimateComponentNumberDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchEstimateCompNumber',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            jobCode = 0,
                            componentCode = 0,
                            estimateCode = 0,
                            salesClass = '',
                            campaignID = 0;

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

                        if (me.componentCode && me.componentCode.length > 0) {
                            componentCode = me.componentCode[0];
                        }

                        if (me.estimateNumber && me.estimateNumber.length > 0) {
                            estimateCode = me.estimateNumber[0];
                        }
                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            salesClass = me.salesClassCode[0];
                        }
                        if (me.campaignID && me.campaignID.length > 0) {
                            campaignID = me.campaignID[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            SalesClass: salesClass,
                            CampaignID: campaignID,
                            JobCode: jobCode,
                            ComponentCode: componentCode,
                            EstimateCode: estimateCode
                        };
                    }
                }
            }
        });
        if (this.estimateComponentNumberMultiSelect) {
            this.estimateComponentNumberMultiSelect.setDataSource(this.estimateComponentNumberDataSource);
        }
    }

    estimateComponentNumberMultiSelect_OnChange(e) {
        if (this.estimateComponentNumber && this.estimateComponentNumber.length > 0 && this.estimateComponentNumber[0] != 0) {
            this.jobMultiSelect.focus();
        }

        if (this.estimateComponentNumber && this.estimateComponentNumber.length == 1) {
            this.search();
        }
        else {
            this.data.data([]);
        }
    }

    getPageSize(): number {

        let me = this;

        var pageSizegrid: number;

        this.service.getPageSize("EstimateSearchGrid").then(response => {

            me.pageSize = response.content;

            me.setGridDataSource();

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
            this.service.updatePageSize(PageSize, "EstimateSearchGrid");
            this.pageSize = PageSize;
        }
    }

    bookmark() {
        let client = new HttpClient();
        let me = this;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            salesClassCode = '',
            campaignCode = 0,
            jobNumber = 0,
            componentNumber = 0,
            estimateNumber = '',
            estimateComponentNumber = '';

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

        if (me.salesClassCode && me.salesClassCode.length > 0) {
            salesClassCode = me.salesClassCode[0];
        }

        if (me.campaignID && me.campaignID.length > 0) {
            campaignCode = me.campaignID[0];
        }

        if (me.jobCode && me.jobCode.length > 0) {
            jobNumber = me.jobCode[0];
        }

        if (me.componentCode && me.componentCode.length > 0) {
            componentNumber = me.componentCode[0];
        }

        if (me.estimateNumber && me.estimateNumber.length > 0) {
            estimateNumber = me.estimateNumber[0];
        }

        if (me.estimateComponentNumber && me.estimateComponentNumber.length > 0) {
            estimateComponentNumber = me.estimateComponentNumber[0];
        }


        var data = {
            Office: officeCode,
            Client: clientCode,
            Division: divisionCode,
            Product: productCode,
            SalesClass: salesClassCode,
            Campaign: campaignCode,
            JobNumber: jobNumber > 0 ? jobNumber : null,
            ComponentNumber: componentNumber > 0 ? componentNumber : null,
            EstimateNumber: estimateNumber,
            EstimateComponentNumber: estimateComponentNumber,
            ShowClosed: me.showClosed
        };

        client.post('Estimate/BookMarkPage', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }

    gridReady(e) {
        if (this.isbookmark) {
            if ((this.officeCode && this.officeCode.length && this.officeCode[0] != '') ||
                (this.clientCode && this.clientCode.length && this.clientCode[0] != '') ||
                (this.divisionID && this.divisionID.length && this.divisionID[0] != '') ||
                (this.productID && this.productID.length && this.productID[0] != '') ||
                (this.salesClassCode && this.salesClassCode.length && this.salesClassCode[0] != '') ||
                (this.campaignID && this.campaignID.length && this.campaignID[0] > 0) ||
                (this.jobCode && this.jobCode.length && this.jobCode[0] > 0) ||
                (this.componentCode && this.componentCode.length && this.componentCode[0] > 0) ||
                (this.estimateNumber && this.estimateNumber.length && this.estimateNumber[0] != '') ||
                (this.estimateComponentNumber && this.estimateComponentNumber.length && this.estimateComponentNumber[0] != '')) {
                setTimeout(() => {
                    this.search();
                }, 500);
            }
        }
    }

    activate(params: any) {
        if (params.Parameters != undefined) {
            if (params.Parameters['o'] != undefined) {
                this.officeCode[0] = params.Parameters['o'];
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
            if (params.Parameters['sc'] != undefined) {
                this.salesClassCode[0] = params.Parameters['sc'];
            }
            if (params.Parameters['cid'] != undefined) {
                this.campaignID[0] = params.Parameters['cid'];
            }
            if (params.Parameters['e'] != undefined) {
                this.estimateNumber[0] = params.Parameters['e'];
            }
            if (params.Parameters['ec'] != undefined) {
                this.estimateComponentNumber[0] = params.Parameters['ec'];
            }
            if (params.Parameters['j'] != undefined) {
                this.jobCode[0] = params.Parameters['j'];
            }
            if (params.Parameters['jc'] != undefined) {
                this.componentCode[0] = params.Parameters['jc'];
            }
            if (params.Parameters['closedarchived'] != undefined) {
                this.showClosed = params.Parameters['closedarchived'];
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

        if (me.jobMultiSelect) {
            Text = <string>me.jobMultiSelect.input.val();

            if (Text == 'Job') {
                Text = '';
            }

            if (Text == "") {
                var dataItems = me.jobMultiSelect.dataItems();

                if (dataItems && dataItems.length > 0) {
                    Text = dataItems[0].Code.toString() + ' - ' + dataItems[0].Description;
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
            url: 'Utilities/SearchJobIndexEstimate',
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

    componentMapper(options) {
        let me = (<any>this).me;

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

            if (Text == 'Component') {
                Text = '';
            }

            if (Text == "") {
                var dataItems = me.componentMultiSelect.dataItems();

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
            url: 'Utilities/SearchComponentIndexEstimate',
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

    setGridDataSource() {
        let me = this;

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Estimate/Search',
                    data: function () {

                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            salesClassCode = '',
                            estimateNumber = 0,
                            estimateComponentNumber = 0,
                            componentCode = 0,
                            jobCode = 0,
                            campaignID = 0;

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

                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            salesClassCode = me.salesClassCode[0];
                        }

                        if (me.campaignID && me.campaignID.length > 0) {
                            campaignID = me.campaignID[0];
                        }

                        if (me.estimateNumber && me.estimateNumber.length > 0) {
                            estimateNumber = me.estimateNumber[0];
                        }

                        if (me.estimateComponentNumber && me.estimateComponentNumber.length > 0) {
                            estimateComponentNumber = me.estimateComponentNumber[0].Code;
                            estimateNumber = me.estimateComponentNumber[0].EstimateCode;
                        }

                        if (me.jobCode && me.jobCode.length > 0) {
                            jobCode = me.jobCode[0];
                        }

                        if (me.componentCode && me.componentCode.length > 0) {
                            componentCode = me.componentCode[0].split(',')[1];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            SalesClassCode: salesClassCode,
                            EstimateNumber: estimateNumber,
                            EstimateComponentNumber: estimateComponentNumber,
                            JobCode: jobCode,
                            ComponentCode: componentCode,
                            CampaignID: campaignID,
                            ShowAll: me.showClosed
                        }
                    }
                }
            },
            pageSize: this.pageSize,
            schema: {
                model: {
                    id: 'ID',
                    fields: {
                        ID: { type: 'number' },
                        Code: { type: 'string' },
                        Name: { type: 'string' },
                        StartDate: { type: 'date' },
                        EndDate: { type: 'date' },
                        ClientName: { type: 'string' },
                        ClientCode: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        DivisionName: { type: 'string' },
                        ProductCode: { type: 'string' },
                        ProductName: { type: 'string' },
                        OfficeCode: { type: 'string' },
                        OfficeName: { type: 'string' },
                        EstimateNumber: { type: 'number' },
                        EstimateComponentNumber: { type: 'number' },
                        EstimateDescription: { type: 'string' },
                        EstimateComponentDescription: { type: 'string' },
                        JobComponentDescription: { type: 'string' },
                        JobDescription: { type: 'string' },
                        SalesClass: { type: 'string' },
                        SalesClassDescription: { type: 'string' },
                        InternallyApproved: { type: 'date' },
                        ClientApproved: { type: 'date' },
                        Detail: { type: 'string' }
                    }
                }
            }
        });

        if (me.grid) {
            me.grid.setDataSource(me.data);
        }
    }

    constructor(service: UserSettingService, dialogService: DialogService, openModule) {
        super();
        let me = this;
        this.dialogService = dialogService;
        this.service = service;
        this.openModule = openModule;

        this.getPageSize();

        me.setOfficeDataSource();
        me.setClientDataSource();
        me.setDivisionDataSource();
        me.setProductDataSource();
        me.setSalesClassDataSource();
        me.setCampaignDataSource();
        me.setEstimateNumberDataSource();
        me.setEstimateComponentNumberDataSource();
        me.setJobDataSource();
        me.setComponentDataSource();

        this.theId = this.uuidv4();
        this.CanAdd('Estimate/CanAdd');

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

    }
}
