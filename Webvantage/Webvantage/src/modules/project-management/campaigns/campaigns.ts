import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject } from 'aurelia-framework';
import { customElement } from 'aurelia-framework'
import { HttpClient } from 'aurelia-http-client';
import { Webvantage } from '../../../webvantage';
import { DialogService } from 'aurelia-dialog';
import { NewCampaignDlg } from 'modules/project-management/campaigns/new-campaign-dlg';
import { UserSettingService } from 'services/utilities/user-settings-service';

@inject(Router,DialogService, UserSettingService, 'openModule')
export class Campaign extends ModuleBase {

    router: Router;
    service: UserSettingService;
    dialogService: DialogService;
    openModule;

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;


    officeMultiSelect: kendo.ui.MultiSelect;
    officeDataSource: kendo.data.DataSource;
    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    divisionMultiSelect: kendo.ui.MultiSelect;
    divisionDataSource: kendo.data.DataSource;
    productMultiSelect: kendo.ui.MultiSelect;
    productDataSource: kendo.data.DataSource;
    campaignMultiSelect: kendo.ui.MultiSelect;
    campaignDataSource: kendo.data.DataSource;

    virtualClient;
    virtualDivision;
    virtualProduct;

    resetClient: boolean = false;
    resetDivision: boolean = false;
    resetProduct: boolean = false;

    // search parameters
    officeCode = [];
    clientCode = [];
    divisionID = [];
    productID = [];
    campaignCode = [];

    fromDatePicker: kendo.ui.DatePicker;
    toDatePicker: kendo.ui.DatePicker;
    FromDate: Date = null;
    ToDate: Date = null;
    tempFromDate: Date = new Date();
    tempToDate: Date = new Date();
    InclClosed: boolean = false;
    isbookmark: boolean = false;

    pageSize: number = 15;
    totalpages: number;

    fromChange() {
        this.FromDate = this.fromDatePicker.value();

        if (this.FromDate == null) {
            alert('From Date is Invalid!');
        }
    }

    toChange() {
        this.ToDate = this.toDatePicker.value();

        if (this.ToDate == null) {
            alert('To Date is Invalid!');
        }
    }

    showClosedCheckChanged() {
        //this.setCampaignDataSource();
        this.readCampaignDataSource();
    }

    getTitle(CampaignID: string, Description: string) {
        return 'Campaign ' + CampaignID + ' - ' + Description;
    }

    clearSearch() {
        this.officeCode = [];
        this.clientCode = [];
        this.divisionID = [];
        this.productID = [];
        this.campaignCode = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;

        this.setOfficeDataSource();
        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();
        this.readCampaignDataSource();

        this.InclClosed = false;

        this.FromDate = null;
        this.ToDate = null;
        this.tempFromDate = new Date();
        this.tempToDate = new Date();

        this.data.data([]);
    }


    search() {
        let me = this;

        this.grid.dataSource.query({ page: 1, pageSize: this.pageSize }).then(function () {
            if (me.data.total() == 1) {
                var item = me.data.data()[0];

                me.openModule(me.getTitle(item.Code, item.Name), me.showDetailView(item.ID, item.Code));
            }
        });
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
        this.campaignCode = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;

        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();
        //this.setCampaignDataSource();
        this.readCampaignDataSource();

        if (this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != '') {
            this.clientMultiSelect.focus();
        }

        this.data.data([]);
    }

    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_cs").data("kendoMultiSelect");

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


                            if (Text == "") {

                                if (!me.resetClient) {
                                    var dataItems = me.clientMultiSelect.dataItems();

                                    if (dataItems && dataItems.length > 0) {
                                        Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    }
                                }
                                else {
                                    me.resetClient = false;
                                }
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
        this.divisionID = [];
        this.productID = [];

        this.productDataSource.read();
        this.divisionDataSource.read();

        if (this.clientCode && this.clientCode.length > 0 && this.clientCode[0] != '') {
            this.divisionDataSource.read().then(function () {

                me.divisionMultiSelect.trigger('change');

            });

            this.divisionMultiSelect.focus();
        }

        this.campaignCode = [];
        this.readCampaignDataSource();

        this.data.data([]);
    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_cs").data("kendoMultiSelect");

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
        //this.campaignID = [];

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
                }
                else {
                }
            });

            me.productMultiSelect.focus();
        }

        this.campaignCode = [];
        this.readCampaignDataSource();

        this.data.data([]);
    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_cs").data("kendoMultiSelect");

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
        //this.campaignID = [];

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

            this.campaignMultiSelect.focus();
        }
        else {
            this.productDataSource.read();
        }

        this.campaignCode = [];
        this.readCampaignDataSource();

        this.data.data([]);
    }

    campaignMultiSelect_OnChange(e) {
        if (this.campaignCode && this.campaignCode.length == 1) {
            this.search();
        }
        else {
            this.data.data([]);
        }
    }

    readCampaignDataSource() {
        let me = this;

        this.campaignDataSource.read().then(() => {
            if (me.campaignDataSource.data().length == 1) {
                me.search();
            }
        });
    }

    setCampaignDataSource() {
        let me = this;

        this.campaignDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchCampaign',
                    data: function () {
                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = ''

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

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            InclClosed: me.InclClosed
                        }

                    }
                }
            }
        });
        if (this.campaignMultiSelect) {
            this.campaignMultiSelect.setDataSource(this.campaignDataSource);
        }
    }

    showDetailView(CampaignID, CampaignCode) {
        //return "modules/project-management/campaigns/new-campaign?cid=" + CampaignID + "&cmp=" + CampaignCode;

        return "Campaign.aspx?Mode=open&cid=" + CampaignID + "&cmp=" + CampaignCode;
    }

    newCampaign() {
        let me = this;
        this.dialogService.open({ viewModel: NewCampaignDlg, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                me.search();
            }
        });
    }

    getPageSize(): number {

        var pageSizegrid: number;

        this.service.getPageSize("CampaignSearchGrid").then(response => {

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
            this.service.updatePageSize(PageSize, "CampaignSearchGrid");
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
            campaignCode = '',
            toDate = '',
            fromDate = '';

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }

        if (me.divisionID && me.divisionID.length > 0) {
            divisionCode = me.divisionID[0];
        }

        if (me.productID && me.productID.length > 0) {
            productCode = me.productID[0];
        }
        
        if (me.campaignCode && me.campaignCode.length > 0) {
            campaignCode = me.campaignCode[0];
        }

        if (this.FromDate) {
            fromDate = this.FromDate.toDateString();
        }
        if (this.ToDate) {
            toDate = this.ToDate.toDateString();
        }


        var data = {
            Office: officeCode,
            Client: clientCode,
            Division: divisionCode,
            Product: productCode,
            Campaign: campaignCode,
            ShowClosed: me.InclClosed,
            FromDate: fromDate,
            ToDate: toDate
        };

        client.post('Campaign/BookMarkPage', data)
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
            });
    }

    replaceAll(str: string, find: string, replace: string) {
        return str.replace(new RegExp(find, 'g'), replace);
    }

    gridReady(e) {
        if (this.isbookmark) {
            if ((this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != '') ||
                (this.clientCode && this.clientCode.length > 0 && this.clientCode[0] != '') ||
                (this.divisionID && this.divisionID.length > 0 && this.divisionID[0] != '') ||
                (this.productID && this.productID.length > 0 && this.productID[0] != '') ||
                (this.campaignCode && this.campaignCode.length > 0 && this.campaignCode[0] != '') ||
                (this.FromDate) ||
                (this.ToDate)) {
                setTimeout(() => {
                    this.search();
                }, 500);
            }
        }
    }

    isValidDate(d) {
        return d instanceof Date && !isNaN(<any>d);
    }

    activate(params: any) {

        //console.log("activate " + params.Parameters.indexOf('c'));
        if (params.Parameters != undefined) {
            if (params.Parameters['o'] != undefined) {
                this.officeCode[0] = params.Parameters['o'];
            }
            if (params.Parameters['c'] != undefined) {
                this.clientCode[0] = params.Parameters['c'];
            }
            if (params.Parameters['d'] != undefined) {
                this.divisionID[0] = params.Parameters['d'];
                this.divisionID[0] = this.divisionID[0].replace('%2c', ',');
            }
            if (params.Parameters['p'] != undefined) {
                this.productID[0] = params.Parameters['p'];
                this.productID[0] = this.replaceAll(this.productID[0], '%2c', ',');
            }
            if (params.Parameters['cmp'] != undefined) {
                this.campaignCode[0] = params.Parameters['cmp'];
            }
            if (params.Parameters.FromDate) {

                this.FromDate = new Date(this.replaceAll(params.Parameters.FromDate, '%2f', '/'));
                if (this.isValidDate(this.FromDate)) {
                    this.tempFromDate = this.FromDate;
                }
                else {
                    this.FromDate = null;
                }
            }
            if (params.Parameters.ToDate) {

                this.ToDate = new Date(this.replaceAll(params.Parameters.ToDate, '%2f', '/'));
                if (this.isValidDate(this.ToDate)) {
                    this.tempToDate = this.ToDate;
                }
                else {
                    this.ToDate = null;
                }
            }

            if (params.Parameters.closedarchived && params.Parameters.closedarchived == 'True') {
                this.InclClosed = true;
            }

            this.isbookmark = true;
        }

    }

    clientMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            Text = "";

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

    constructor(router: Router,dialogService: DialogService, service: UserSettingService, openModule) {
        super();

        this.router = router;
        this.dialogService = dialogService;
        this.service = service;
        this.openModule = openModule;
        this.getPageSize();

        let me = this;

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Campaign/Search',
                    data: function () {

                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            campaignCode = '',
                            fromDate = null,
                            toDate = null;

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

                        if (me.campaignCode && me.campaignCode.length > 0) {
                            campaignCode = me.campaignCode[0];
                        }

                        if (me.FromDate != null) {
                            fromDate = me.FromDate.toDateString();
                        }

                        if (me.ToDate != null) {
                            toDate = me.ToDate.toDateString();
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            CampaignCode: campaignCode,
                            ShowClosedCampaigns: me.InclClosed,
                            FromDate: fromDate,
                            ToDate: toDate 
                        }
                    }
                }
            },
            serverPaging: true,
            pageSize: this.pageSize,
            schema: {
                data: "data",
                total: "total",
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
                        OfficeName: { type: 'string' }
                    }
                }
            }
            
        });
        
        this.setOfficeDataSource();
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setCampaignDataSource();

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

        this.CanAdd('Campaign/CanAdd');
    }
}
