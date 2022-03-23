import { UserSettingService } from 'services/utilities/user-settings-service';
import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject, bindable, observable } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';
import { DialogService } from 'aurelia-dialog';
import { UpdateAlertGroupDlg } from 'modules/project-management/job-jacket/update-alert-group-dlg';
import { UpdateAccountExecutiveDlg } from 'modules/project-management/job-jacket/update-ae-dlg';
import { Webvantage } from '../../../webvantage';

@inject(Router, UserSettingService, DialogService, 'openModule')
export class JobJacketSearch extends ModuleBase {

    dialogService: DialogService;
    openModule;
    service: UserSettingService;
    router: Router;

    display: {
        display:'none'
    }

    // search controls
    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;

    //search editors
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
    accountExecutiveMultiSelect: kendo.ui.MultiSelect;
    accountExecutiveDataSource: kendo.data.DataSource;
    jobTypeMultiSelect: kendo.ui.MultiSelect;
    jobTypeDataSource: kendo.data.DataSource;
    yearPicker: kendo.ui.DatePicker;

    virtualJob;
    virtualComponent;
    virtualClient;
    virtualDivision;
    virtualProduct;

    resetClient: boolean = false;
    resetDivision: boolean = false;
    resetProduct: boolean = false;
    resetJob: boolean = false;
    resetComponent: boolean = false;
    backFillInProgress: boolean = false;


    // search parameters
    officeCode = [];
    clientCode = [] ;
    divisionID = [];
    productID = [];
    salesClassCode = [];
    campaignID = [];
    accountExecutiveCode = [];
    jobCode = [];
    componentCode = [];
    jobTypeCode = [];
    year: Date = null;

    actionSelected;

    theId = ""

    showClosed: boolean = false;
    isbookmark: boolean = false;

    pageSize: number = 15;
    totalpages: number;

    @bindable isClientPortal: boolean = false;

    /*
        Methods
    */

    search() {
        let me = this;

        if (this.grid.dataSource.pageSize() != this.pageSize || this.grid.dataSource.page() != 1) {
            this.grid.dataSource.query({ page: 1, pageSize: this.pageSize });
        }
        //this.grid.pager.page(1);  
        this.grid.dataSource.read().then(function () {
            if (me.data.total() == 1) {
                var item = me.data.data()[0];

                me.openModule('', me.showDetailView(item.JobNumber, item.JobComponentNumber));
            }
        });

        
    }

    clearSearch() {
        this.officeCode = [];
        this.clientCode = [];
        this.divisionID = [];
        this.productID = [];
        this.salesClassCode = [];
        this.campaignID = [];
        this.jobCode = [];
        this.componentCode = [];
        this.accountExecutiveCode = [];
        this.jobTypeCode = [];

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.setOfficeDataSource();
        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();
        this.setSalesClassDataSource();
        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();
        this.setJobTypeDataSource();
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.year = null;

        this.showClosed = false;

        this.clearGrid();
    }

    showClosedCheckChanged() {
        this.campaignID = [];
        this.jobCode = [];
        this.componentCode = [];

        this.setCampaignDataSource();
        this.jobDataSource.read();
        this.componentDataSource.read();

        return true;
    }


    get disableAE() {
        if ((this.clientCode && this.clientCode.length > 0) &&
            (this.divisionID && this.divisionID.length > 0) &&
            (this.productID && this.productID.length > 0)) {
            return false;
        }
        return true;
    }

    bookmark() {
        let client = new HttpClient();
        let me = this;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            salesClassCode = '',
            campaignId = 0,
            jobNumber = 0,
            componentNumber = 0,
            accountExecutiveCode = '',
            jobtypecode = '';

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

        if (me.salesClassCode && me.salesClassCode.length > 0) {
            salesClassCode = me.salesClassCode[0];
        }

        if (me.campaignID && me.campaignID.length > 0) {
            campaignId = me.campaignID[0];
        }

        if (me.jobCode && me.jobCode.length > 0) {
            jobNumber = me.jobCode[0];
        }

        if (me.componentCode && me.componentCode.length > 0) {
            componentNumber = me.componentCode[0];
        }

        if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
            accountExecutiveCode = me.accountExecutiveCode[0];
        }

        if (me.jobTypeCode && me.jobTypeCode.length > 0) {
            jobtypecode = me.jobTypeCode[0];
        }


        var data = {
            Office: officeCode,
            Client: clientCode,
            Division: divisionCode,
            Product: productCode,
            SalesClass: salesClassCode,
            Campaign: campaignId,
            JobNumber: jobNumber > 0 ? jobNumber : null,
            ComponentNumber: componentNumber > 0 ? componentNumber : null,
            AccountExecutive: accountExecutiveCode,
            ShowClosed: me.showClosed,
            JobType: jobtypecode
        };

        client.post('JobJacket/BookMarkPage', data)
            .then(data => {
            });
    }

    actionSelected_OnChange(e) {
        let me = this;
        var rows = this.grid.select();
        let data = [];
        let selected = [];
        let client = new HttpClient();

        rows.each(function (e) {
            var dataItem;
            dataItem = me.grid.dataItem(this);
            selected.push(dataItem);

            data.push(dataItem.JobNumber + "/" + dataItem.JobComponentNumber);
        });

        switch (this.actionSelected) {
            case "Print":
                if (data.length > 0) {
                    var url = "";

                    data.forEach(function (value, index, array) {
                        url += "JobComponents=" + escape(value) + "&";
                    });

                    url = url.substring(0, url.length - 1);
                    url = "JobJacket/PrintJobs?" + url

                    window.open(url, "_self");

                }
                else {
                    alert("No jobs selected to print.")
                }
                this.actionSelected = "Print/Send";
                break;
            case "Send Alert":
                if (data.length > 0) {

                    //this.openModule("New Alert", "Alert_New.aspx?eml=0&send=1&caller=jobtemplateprint&pagetype=jt&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber + "&f=1&Report=joborder&printjof=1&printjs=0&printjv=0&printcb=0");
                    this.openModule("New Alert", "JobTemplate_Print.aspx?caller=JobTemplatePrint&fromapp=jobsearch&mode=2&Job=" + selected[0].JobNumber + "&JobComp=" + selected[0].JobComponentNumber + "&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber);

                }
                else {
                    alert("No jobs selected to alert.")
                }
                this.actionSelected = "Print/Send";
                break;
            case "Send Assignment":
                if (data.length > 0) {

                    //this.openModule("New Assignment", "Alert_New.aspx?eml=0&assn=1&send=1&caller=jobtemplateprint&pagetype=jt&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber + "&f=1&Report=joborder&printjof=1&printjs=0&printjv=0&printcb=0");
                    this.openModule("New Assignment", "JobTemplate_Print.aspx?caller=JobTemplatePrint&fromapp=jobsearch&mode=5&Job=" + selected[0].JobNumber + "&JobComp=" + selected[0].JobComponentNumber + "&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber);

                }
                else {
                    alert("No jobs selected to send.")
                }
                this.actionSelected = "Print/Send";
                break;
            case "Send Email":
                if (data.length > 0) {

                    //this.openModule("Send Email", "Alert_New.aspx?eml=1&send=1&caller=jobtemplateprint&pagetype=jt&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber + "&f=1&Report=joborder&printjof=1&printjs=0&printjv=0&printcb=0");
                    this.openModule("New Email", "JobTemplate_Print.aspx?caller=JobTemplatePrint&fromapp=jobsearch&mode=3&Job=" + selected[0].JobNumber + "&JobComp=" + selected[0].JobComponentNumber + "&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber);

                }
                else {
                    alert("No jobs selected to email.")
                }
                this.actionSelected = "Print/Send";
                break;
            case "Options":
                this.actionSelected = "Print/Send";
                if (data.length > 0) {
                    this.openModule("Print Job", "JobTemplate_Print.aspx?caller=JobTemplatePrint&fromapp=jobsearch&mode=4&Job=" + selected[0].JobNumber + "&JobComp=" + selected[0].JobComponentNumber + "&j=" + selected[0].JobNumber + "&jc=" + selected[0].JobComponentNumber);
                }
                else {
                    alert("No jobs selected to print.")
                }

                break;
        }
    }

    updateAccountExecutive() {
        let me = this;

        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            data = {};

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
        };

        this.dialogService.open({ viewModel: UpdateAccountExecutiveDlg, model: data, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                var rows = this.grid.select();
                var Components: string[] = [];

                if (response.output.UpdateSelected == 1) {
                    if (confirm("Are you sure you want to update the AE on selected jobs?")) {
                        rows.each(function (e) {
                            var dataItem;
                            dataItem = me.grid.dataItem(this);

                            Components.push(dataItem.JobNumber + "/" + dataItem.JobComponentNumber);
                        });
                    }
                    else {
                        return;
                    }
                }
                else {
                    if (confirm("Are you sure you want to update the AE on current page?")) {
                        this.data.data().forEach(function (o, i, s) {
                            Components.push(s[i].JobNumber + "/" + s[i].JobComponentNumber);
                        })
                    }
                    else {
                        return;
                    }
                }

                var data = {
                    AccountExecutive: response.output.AccountExec,
                    IsDefault: response.output.IsDefault,
                    Components: Components
                }

                let client = new HttpClient();
                let count = data.Components.length;

                client.post("JobJacket/UpdateAE", data).then(data => {
                    alert("Account Executive was updated for " + count + " jobs");
                });
            }
        });
    }

    updateAlertGroup() {
        let me = this;

        this.dialogService.open({ viewModel: UpdateAlertGroupDlg, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                var rows = this.grid.select();
                var Components: string[] = [];

                if (response.output.UpdateSelected == 1) {
                    if (confirm("Are you sure you want to update the Alert Group on selected jobs?")) {
                        rows.each(function (e) {
                            var dataItem;
                            dataItem = me.grid.dataItem(this);

                            Components.push(dataItem.JobNumber + "/" + dataItem.JobComponentNumber);
                        });
                    }
                    else {
                        return;
                    }
                }
                else {
                    if (confirm("Are you sure you want to update the Alert Group on the current page?")) {
                        this.data.data().forEach(function (o, i, s) {
                            Components.push(s[i].JobNumber + "/" + s[i].JobComponentNumber);
                        })
                    }
                    else {
                        return;
                    }
                }

                var data = {
                    AlertGroup: response.output.alertGroupName,
                    IsDefault: response.output.IsDefault,
                    Components: Components
                }

                let client = new HttpClient();
                let count = data.Components.length;

                client.post("JobJacket/UpdateAlertGroup", data).then(data => {
                    alert("Alert Group has been updated on " + count + " jobs");
                });
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

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.clientCode = [];
        this.divisionID = [];
        this.productID = [];
        this.jobCode = [];
        this.componentCode = [];
        this.campaignID = [];
        this.accountExecutiveCode = [];

        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();
        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.clearGrid();

        if (this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != "") {
            this.clientMultiSelect.focus();
        }

    }

    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_jjs").data("kendoMultiSelect");

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
        this.accountExecutiveCode = [];

        if (!me.clientCode || me.clientCode.length == 0 || me.clientCode[0] == '') {
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

        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();

        this.clearGrid();;
    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_jjs").data("kendoMultiSelect");

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
        this.accountExecutiveCode = [];

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

                me.productMultiSelect.trigger('change');
            });
        }

        this.jobCode = [];
        this.componentCode = [];
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();

        this.clearGrid();
    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_jjs").data("kendoMultiSelect");

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
        this.campaignID = [];
        this.accountExecutiveCode = [];

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
        this.setAccountExecutiveDataSource();

        this.clearGrid();
    }

    clearGrid() {
        (<any>this.data)._aggregateResult = null;
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
        this.jobTypeCode = [];
        this.setJobTypeDataSource();
        this.jobCode = [];
        this.componentCode = [];

        this.jobDataSource.read();
        this.componentDataSource.read();

        this.clearGrid();

        if (this.salesClassCode && this.salesClassCode.length > 0 && this.salesClassCode[0] != '') {
            this.campaignMultiSelect.focus();
        }
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
        this.jobCode = [];
        this.componentCode = [];

        this.jobDataSource.read();
        this.componentDataSource.read();
       
        this.clearGrid();

        if (this.campaignID && this.campaignID.length > 0 && this.campaignID[0] != 0) {
            this.accountExecutiveMultiSelect.focus();
        }
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            serverPaging:true,
            pageSize: 31,
            schema: {
                data: "Jobs",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchJob',
                    data: function (e) {

                        var clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            officeCode = '',
                            AccountExecutive = '',
                            CampaignID = 0,
                            SalesClass = '',
                            JobType = '',
                            Text = "";

                        //if (e) {
                        //    if (e.filter && e.filter.filters.length > 0) {
                        //        Text = e.filter.filters[0].value;

                        //    }
                        //}

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
                                    //Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                    Text = dataItems[0].Code.toString() + ' - ' +dataItems[0].Description;
                                }
                            }
                        }
                        else {
                            me.resetJob = false;
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
                            AccountExecutive: AccountExecutive,
                            ShowClosedJobs: me.showClosed,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            Text: Text
                        }

                        return data;
                    }
                }
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
    }

    jobFiltering(e) {

        //if (e && !e.filter) {
        //    e.preventDefault();
        //}
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
        }

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
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    onJobReady(e) {
        let me = this;

        var multiselect = $("#JobMultiSelect_jjs").data("kendoMultiSelect");

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
                            me.clientCode = [];
                            me.clientCode[0] = data.ClientCode;
                        }

                        if (me.divisionID[0] != data.ClientCode + ',' + data.DivisionCode) {
                            setTimeout(() => {
                                me.divisionDataSource.read().then(() => {
                                    me.divisionID = []
                                    me.divisionID[0] = data.ClientCode + ',' + data.DivisionCode;

                                    setTimeout(() => {
                                        me.productDataSource.read().then(() => {
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

            this.componentMultiSelect.focus();
        }

        this.clearGrid();
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
                            ShowClosedJobs: me.showClosed,
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

        var multiselect = $("#ComponentMultiSelect_jjs").data("kendoMultiSelect");

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
                                    this.search();
                                });
                            });
                        }
                    });
                }
            }
            else {
                this.search();
            }
        }
        else {
                this.componentDataSource.read();
        }
    }

    setAccountExecutiveDataSource() {
        let me = this;
        var officeCode = '',
            clientCode = '',
            divisionCode = '',
            productCode = '',
            data = {};

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
            ProductCode: productCode
        };


        this.accountExecutiveDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchAccountExecutive',
                    data: data
                }
            }
        });
        if (this.accountExecutiveMultiSelect) {
            this.accountExecutiveMultiSelect.setDataSource(this.accountExecutiveDataSource);
        }
    }

    accountExecutiveMultiSelect_OnChange(e) {
        this.jobCode = [];
        this.componentCode = [];

        this.jobDataSource.read();
        this.componentDataSource.read();

        this.clearGrid();

        if (this.accountExecutiveCode && this.accountExecutiveCode.length > 0 && this.accountExecutiveCode[0] != 0) {
            this.jobMultiSelect.focus();
        }

    }

    setJobTypeDataSource() {
        let me = this;
        this.jobTypeDataSource = new kendo.data.DataSource({
            serverFiltering: true,
            //serverPaging: true,
            //pageSize: 31,
            schema: {
                data: "JobTypes",
                total: "Total",
            },
            transport: {
                read: {
                    url: 'Utilities/SearchJobType',
                    data: function () {
                        var salesClassCode = '',
                            Text = "";

                        if (me.jobTypeMultiSelect) {
                            Text = <string>me.jobTypeMultiSelect.input.val();
                        }

                        if (Text == 'Job Type') {
                            Text = "";
                        }

                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            salesClassCode = me.salesClassCode[0];
                        }

                        return {
                            SalesClassCode: salesClassCode,
                            Text: Text
                        }
                    }
                }
            }
        });
        if (this.jobTypeMultiSelect) {
            this.jobTypeMultiSelect.setDataSource(this.jobTypeDataSource);
        }
    }

    jobTypeMultiSelect_OnChange(e) {
        this.jobCode = [];
        this.componentCode = [];

        this.jobDataSource.read();
        this.componentDataSource.read();

        this.clearGrid();
    }

    getPageSize(): number {

        var pageSizegrid: number;

        this.service.getPageSize("JobJacketSearchGrid").then(response => {

            this.pageSize = response.content;

            //this.grid.dataSource.pageSize(this.pageSize);

            return response.content;
        });

        return pageSizegrid;
    }

    getClientPortal() {

        try {
            this.service.isClientPortal().then(response => {
                if (response) {
                    this.isClientPortal = response.content.ClientPortal;

                    if (this.isClientPortal == true) {
                        this.clientCode[0] = response.content.ClientCode;
                    }
                }
            });
        } catch (e) {
            console.log("dashboard.ts:loadCounts:isClientPortal:error", e);
        }

    }

    onDataBound(e) {
        var PageSize = this.grid.dataSource.pageSize();
        this.totalpages = this.grid.pager.totalPages();
        this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        if (this.pageSize != PageSize) {
            this.service.updatePageSize(PageSize, "JobJacketSearchGrid");
            this.pageSize = PageSize;
        }
        
    }

    showDetailView(JobNumber, JobComponent) {
        return "Content.aspx?contaid=10&j=" + JobNumber + "&jc=" + JobComponent;
    }

    setGridDataSource() {
        let me = this;

        this.data = new kendo.data.DataSource({
            transport: {
                read: {

                    url: 'ProjectManagement/JobJacket/Search',
                    data: function () {

                        var officeCode = '',
                            clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            salesClassCode = '',
                            campaignID = 0,
                            jobNumber = 0,
                            componentNumber = 0,
                            accountExecutiveCode = '',
                            jobTypeCode = '',
                            year = null;

                        if (me.year != null) {
                            year = me.year.getFullYear();
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
                        if (me.salesClassCode && me.salesClassCode.length > 0) {
                            salesClassCode = me.salesClassCode[0];
                        }

                        if (me.campaignID && me.campaignID.length > 0) {
                            campaignID = me.campaignID[0];
                        }

                        if (me.jobCode && me.jobCode.length > 0) {
                            jobNumber = me.jobCode[0];
                        }

                        if (me.componentCode && me.componentCode.length > 0) {
                            componentNumber = me.componentCode[0].split(',')[1];
                        }

                        if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
                            accountExecutiveCode = me.accountExecutiveCode[0];
                        }

                        if (me.jobTypeCode && me.jobTypeCode.length > 0) {
                            jobTypeCode = me.jobTypeCode[0];
                        }


                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            SalesClassCode: salesClassCode,
                            CampaignID: campaignID,
                            JobNumber: jobNumber,
                            ComponentNumber: componentNumber,
                            AccountExecutiveCode: accountExecutiveCode,
                            JobTypeCode: jobTypeCode,
                            ShowClosed: me.showClosed,
                            Year: year
                        }
                    }
                }
            },
            serverAggregates: true,
            aggregate: [{ field: "Budget", aggregate: "sum" }],
            serverPaging: true,
            pageSize: this.pageSize,
            schema: {
                data: "Data", // records are returned in the "data" field of the response
                total: "total", // total number of records is in the "total" field of the response
                aggregates: "aggregates",
                model: {
                    id: 'JobNumber',
                    fields: {
                        JobNumber: { type: 'number' },
                        JobDescription: { type: 'string' },
                        JobComponentNumber: { type: 'number' },
                        JobComponentDescription: { type: 'string' },
                        ClientName: { type: 'string' },
                        ClientCode: { type: 'string' },
                        DivisionName: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        ProductName: { type: 'string' },
                        ProductCode: { type: 'string' },
                        DueDate: { type: 'date' },
                        SalesClass: { type: 'string' },
                        JobType: { type: 'string' },
                        StartDate: { type: 'date' },
                        OfficeName: { type: 'string' },
                        Budget: { type: 'number' },
                        EstimateStatus: { type: 'string' },
                        JobCompDesc: { type: 'string' }
                    }
                }
            }            
        });
    }

    replaceAll(str:string, find:string, replace:string) {
        return str.replace(new RegExp(find, 'g'), replace);
    }

    gridReady(e) {
        if (this.isbookmark) {
            if ((this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != '') ||
                (this.clientCode && this.clientCode.length > 0 && this.clientCode[0] != '') ||
                (this.divisionID && this.divisionID.length > 0 && this.divisionID[0] != '') ||
                (this.productID && this.productID.length > 0 && this.productID[0] != '') ||
                (this.salesClassCode && this.salesClassCode.length > 0 && this.salesClassCode[0] != '') ||
                (this.campaignID && this.campaignID.length > 0 && this.campaignID[0] > 0) ||
                (this.jobCode && this.jobCode.length > 0 && this.jobCode[0] != '') ||
                (this.componentCode && this.componentCode.length > 0 && this.componentCode[0] != '') ||
                (this.accountExecutiveCode && this.accountExecutiveCode.length > 0 && this.accountExecutiveCode[0] != '') ||
                (this.jobTypeCode && this.jobTypeCode.length > 0 && this.jobTypeCode[0] != '') ) {
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
                this.divisionID[0] = this.divisionID[0].replace('%2c', ',');
            }
            if (params.Parameters['p'] != undefined) {
                this.productID[0] = params.Parameters['p'];
                this.productID[0] = this.replaceAll(this.productID[0],'%2c', ',');
            }
            if (params.Parameters['sc'] != undefined) {
                this.salesClassCode[0] = params.Parameters['sc'];
            }
            if (params.Parameters['cid'] != undefined) {
                this.campaignID[0] = params.Parameters['cid'];
            }
            if (params.Parameters['ae'] != undefined) {
                this.accountExecutiveCode[0] = params.Parameters['ae'];
            }
            if (params.Parameters['j'] != undefined) {
                this.jobCode[0] = params.Parameters['j'];
            }
            if (params.Parameters['jc'] != undefined) {
                this.componentCode[0] = params.Parameters['jc'];
            }
            if (params.Parameters['jt'] != undefined) {
                this.jobTypeCode[0] = params.Parameters['jt'];
            }
            if (params.Parameters['closedarchived'] != undefined) {
                if (params.Parameters['closedarchived'] == 'True') {
                    this.showClosed = true;
                }
            }
            if (params.Parameters['isbookmark'] != undefined) {
                this.isbookmark = params.Parameters['isbookmark'];
            }             
        }
       
    }

    clientMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            Text = "";

        if (me.clientMultiSelect) {

            Text = <string>me.clientMultiSelect.input.val();
        }

        if (Text == 'Client') {
            Text = "";
        }

        if (Text == "" && me.clientMultiSelect) {
            var dataItems = me.clientMultiSelect.dataItems();

            if (dataItems && dataItems.length > 0) {
                Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
            }
        }

        if (me.officeCode && me.officeCode.length > 0) {
            officeCode = me.officeCode[0];
        }


        var data = { OfficeCode: officeCode,
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
        }).fail(function (xhr, status, error) {
            alert(error);
        });
    }

    divisionMapper(options) {
        let me = (<any>this).me;

        var officeCode = '',
            clientCode = '',
            Text = "";

        if (me.divisionMultiSelect) {

            Text = <string>me.divisionMultiSelect.input.val();
        }

        if (Text == 'Division') {
            Text = "";
        }

        if (Text == "" && me.divisionMultiSelect) {
            var dataItems = me.divisionMultiSelect.dataItems();

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
        }).fail(function (xhr, status, error) {
            alert(error);
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
        }

        if (Text == 'Product') {
            Text = "";
        }

        if (Text == "" && me.productMultiSelect) {
            var dataItems = me.productMultiSelect.dataItems();

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
        }

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

    constructor(router: Router, service: UserSettingService, dialogService: DialogService, openModule) {
        super();
        let me = this;

        this.router = router;
        this.service = service;
        this.dialogService = dialogService;
        this.openModule = openModule;
        this.getPageSize();
        this.getClientPortal();
        this.setGridDataSource();

        this.setOfficeDataSource();
        this.setClientDataSource();
        this.setDivisionDataSource();
        this.setProductDataSource();
        this.setSalesClassDataSource();
        this.setCampaignDataSource();
        this.setJobDataSource();
        this.setComponentDataSource();
        this.setAccountExecutiveDataSource();
        this.setJobTypeDataSource();

        this.theId = this.uuidv4();
        this.CanAdd('JobJacket/CanAdd');

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

    attached() {
        window.addEventListener('click', e => {
            if ($(e.target).attr('title') === 'Job Jacket Search') {
                this.grid.pager.resize();
            }
        });
    }
}
