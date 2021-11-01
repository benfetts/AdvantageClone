import { ProjectScheduleService } from 'services/project-management/project-schedule-service';
import { UserSettingService } from 'services/utilities/user-settings-service';
import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject, observable } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';
import { DialogService } from 'aurelia-dialog';
import { NewProjectScheduleDlg } from 'modules/project-management/project-schedule/new-project-schedule';

@inject(DialogService, Router, ProjectScheduleService, UserSettingService, 'openModule')
export class ProjectScheduleSearch extends ModuleBase {
    dialogService: DialogService;
    service: ProjectScheduleService;
    usersettingservice: UserSettingService;
    router: Router;
    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;

    disabled = false;
    vertical = false;
    type = 'multi';
    active = 2;

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

    // search editors
    statusMultiSelect: kendo.ui.MultiSelect;
    projectManagerMultiSelect: kendo.ui.MultiSelect;
    phaseMultiSelect: kendo.ui.MultiSelect;
    roleMultiSelect: kendo.ui.MultiSelect;
    taskMultiSelect: kendo.ui.MultiSelect;
    employeeMultiSelect: kendo.ui.MultiSelect;


    // search datasources
    statusDataSource: kendo.data.DataSource;
    projectManagerDataSource: kendo.data.DataSource;
    phaseDataSource: kendo.data.DataSource;
    roleDataSource: kendo.data.DataSource;
    taskDataSource: kendo.data.DataSource;
    employeeDataSource: kendo.data.DataSource;

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
    accountExecutiveCode = [];
    jobTypeCode = [];
    statusCode = [];


    projectManagerCode = [];
    @observable excludeCompletedSchedules: boolean = true;
    onlyScheduleTemplates: boolean = false;
    phaseCode = [];
    roleCode = [];
    taskCode = [];
    employeeCode = [];
    dateCutoff: Date = null;

    onlyPendingTasks: boolean = false;
    excludeProjectedTasks: boolean = false;
    includeCompletedTasks: boolean = false;

    excludeCompletedSchedulesID: string;
    onlyScheduleTemplatesID: string;
    onlyPendingTasksID: string;
    excludeProjectedTasksID: string;
    includeCompletedTasksID: string;

    IncludeNoFilter: boolean = true;
    IncludeNone: boolean = true;

    pageSize: number = 15;
    totalpages: number;
    isbookmark: boolean = false;

    openModule;

    datePicker: kendo.ui.DatePicker;

    search() {
        let me = this;

        if (this.grid.dataSource.pageSize() != this.pageSize || this.grid.dataSource.page() != 1) {
            this.grid.dataSource.query({ page: 1, pageSize: this.pageSize });
        }
        //this.grid.pager.page(1);  
        this.grid.dataSource.read().then(function () {
            var foo = me.data.total();
            console.log("foo ", foo);
//        this.grid.dataSource.query({ page: 1, pageSize: this.pageSize }).then(function () {
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
        console.log('job code reset');
        this.jobCode = [];
        this.componentCode = [];
        this.accountExecutiveCode = [];
        this.jobTypeCode = [];
        this.statusCode = [];

        this.projectManagerCode = [];
        this.excludeCompletedSchedules = true;
        this.onlyScheduleTemplates = false;
        this.phaseCode = [];
        this.roleCode = [];
        this.taskCode = [];
        this.employeeCode = [];
        this.dateCutoff = null;
        this.onlyPendingTasks = false;
        this.excludeProjectedTasks = false;
        this.includeCompletedTasks = false;

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
        console.log('this.jobDataSource.read()');
        this.jobDataSource.read();
        this.componentDataSource.read();
        this.setAccountExecutiveDataSource();
        this.setJobTypeDataSource();
        this.setStatusDataSource();
        this.setProjectManagerDataSource();
        this.setPhaseDataSource();
        this.setEmployeeDataSource();
        this.setTaskDataSource();
        this.setRoleDataSource();

        this.clearGrid();
    }

    clearGrid() {
        this.grid.dataSource.data([]);
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
            jobtype = '',
            jobstatus = '',
            projectManagerCode = '',
            phaseCode = '',
            roleCode = '',
            taskCode = '',
            employeeCode = '',
            dateCutoff = null;

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
            jobtype = me.jobTypeCode[0];
        }

        if (me.statusCode && me.statusCode.length > 0) {
            jobstatus = me.statusCode[0];
        }

        if (me.projectManagerCode && me.projectManagerCode.length > 0) {
            projectManagerCode = me.projectManagerCode[0];
        }

        if (me.phaseCode && me.phaseCode.length > 0) {
            phaseCode = me.phaseCode[0];
        }

        if (me.roleCode && me.roleCode.length > 0) {
            roleCode = me.roleCode[0];
        }

        if (me.taskCode && me.taskCode.length > 0) {
            taskCode = me.taskCode[0];
        }

        if (me.employeeCode && me.employeeCode.length > 0) {
            employeeCode = me.employeeCode[0];
        }

        if (me.dateCutoff) {
            dateCutoff = me.dateCutoff.toDateString();
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
            JobType: jobtype,
            JobStatus: jobstatus,
            projectManagerCode: projectManagerCode,
            phaseCode: phaseCode,
            roleCode: roleCode,
            taskCode: taskCode,
            employeeCode: employeeCode,
            dateCutoff: dateCutoff
        };

        client.post('ProjectSchedule/BookMarkPage', data)
            .then(data => {
                //console.log(data.statusCode + ' - ' + data.statusText);
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

        this.resetClient = true;
        this.resetDivision = true;
        this.resetProduct = true;
        this.resetJob = true;
        this.resetComponent = true;

        this.clientDataSource.read();
        this.divisionDataSource.read();
        this.productDataSource.read();

        this.jobCode = [];
        console.log('this.jobDataSource.read()');
        this.jobDataSource.read();
        this.componentCode = [];
        this.componentDataSource.read();
        this.campaignID = [];
        this.setCampaignDataSource();
        this.accountExecutiveCode = [];
        this.setAccountExecutiveDataSource();

        this.clearGrid();

        if (this.officeCode && this.officeCode.length > 0 && this.officeCode[0] != "") {
            this.clientMultiSelect.focus();
        }
    }

    onClientReady(e) {
        let me = this;

        var multiselect = $("#ClientMultiSelect_pss").data("kendoMultiSelect");

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
                                Text = '';
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

            this.productDataSource.read();
            this.divisionDataSource.read();

            this.jobCode = [];
            this.componentCode = [];
            console.log('this.jobDataSource.read()');
            this.jobDataSource.read();
            this.componentDataSource.read();
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

        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();

        this.clearGrid();
    }

    onDivisionReady(e) {
        let me = this;

        var multiselect = $("#DivisionMultiSelect_pss").data("kendoMultiSelect");

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
                                Text = '';
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
            this.jobCode = [];
            this.componentCode = [];
            console.log('this.jobDataSource.read()');
            this.jobDataSource.read();
            this.componentDataSource.read();
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

        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();

        this.clearGrid();
    }

    onProductReady(e) {
        let me = this;

        var multiselect = $("#ProductMultiSelect_pss").data("kendoMultiSelect");

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
                                Text = '';
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

            console.log("resetting ");
            this.jobCode = [];
            this.componentCode = [];
            console.log('this.jobDataSource.read()');
            this.jobDataSource.read();
            this.componentDataSource.read();
        }

        this.setCampaignDataSource();
        this.setAccountExecutiveDataSource();

        this.clearGrid();
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

        console.log('this.jobDataSource.read()');
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
            ProductCode: productCode
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

        console.log('this.jobDataSource.read()');
        this.jobDataSource.read();
        this.componentDataSource.read();

        this.clearGrid();

        if (this.campaignID && this.campaignID.length > 0 && this.campaignID[0] != 0) {
            this.jobMultiSelect.focus();
        }
    }

    //onJobReady(e) {
    //    let me = this;

    //    var multiselect = $("#JobMultiSelect_pss").data("kendoMultiSelect");

    //    multiselect.list.width(450);

    //    multiselect.bind("deselect", () => {
    //        console.log('job code reset');
    //        me.jobCode = [];
    //        me.jobMultiSelect.trigger('change');
    //    });
    //}

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
                    url: 'Utilities/SearchJobPS',
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

                                //if (dataItems && dataItems.length > 0) {
                                //    console.log(dataItems);
                                //    //Text = dataItems[0].Name.substring(0, dataItems[0].Name.lastIndexOf('(') - 1);
                                //    Text = dataItems[0].Code.toString() + ' - ' + dataItems[0].Description;
                                //}
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
                            //ShowClosedJobs: me.showClosed,
                            CampaignID: CampaignID,
                            SalesClass: SalesClass,
                            JobType: JobType,
                            Text: Text
                        }

                        console.log('Job Datasource', data);

                        return data;
                    }
                }
            },
            requestStart(e) {
                console.log("Job Data Source Request Start",e);
            },
            requestEnd(e) {
                console.log("Job Data Source Request Ended");
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
    }

    jobMapper(options) {
        let me = (<any>this).me;

        console.log('Job Mapper');

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
                ShowClosedJobs: !me.excludeCompletedSchedules,
                Text: Text
            }

        console.log('Job Mapper', data);

        $.ajax({
            url: 'Utilities/SearchJobIndexPS',
            type: 'GET',
            dataType: 'json',
            data: data,
            success: (data) => {
                console.log('Job Mapper Results',data);
                options.success(data);
            }
        }).fail(function (xhr, status, error) {
            //alert(error);
        });
    }

    onJobReady(e) {
        let me = this;

        var multiselect = $("#JobMultiSelect_pss").data("kendoMultiSelect");

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
        console.log('in change', dataItems, e);

        this.resetComponent = true;

        if (!this.jobCode || this.jobCode.length < 1 || this.jobCode[0] == '') {
            this.componentCode = [];
            this.componentDataSource.read();
        }
        else {

            this.backFillCDP().then(() => {

                this.componentDataSource.read().then(function () {
                    if (me.componentDataSource.total() == 1) {
                        me.componentCode = [];
                        me.componentCode[0] = me.componentDataSource.data()[0].ID;

                        me.search();
                    }
                });
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
                    url: 'Utilities/SearchComponentPS',
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
                            ShowClosedJobs: !me.excludeCompletedSchedules,
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

        var multiselect = $("#ComponentMultiSelect_pss").data("kendoMultiSelect");

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

            if (!this.jobCode || this.jobCode.length < 1 || this.jobCode[0] != codes[0]) {
                this.jobCode = [];
                this.jobCode[0] = codes[0];
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

                                    //me.jobDataSource.read().then(() => {
                                    //    //set job code last
                                    //    //if (!me.jobCode || me.jobCode.length == 0 || me.jobCode[0] == '' || me.jobCode[0] != codes[0]) {
                                    //    me.jobCode = [];
                                    //    me.jobCode[0] = codes[0];

                                    //    me.backFillInProgress = false;
                                    //    //}

                                    //    me.search();
                                    //});
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
            url: 'Utilities/SearchComponentIndexPS',
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
        this.resetJob = true;
        this.resetComponent = true;
        console.log('this.jobDataSource.read()');
        this.jobDataSource.read();
        this.jobCode = [];
        this.componentDataSource.read();
        this.componentCode = [];

        this.clearGrid();

        if (this.accountExecutiveCode && this.accountExecutiveCode.length > 0 && this.accountExecutiveCode[0] != 0) {
            this.jobTypeMultiSelect.focus();
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

                            if (Text == 'Job Type') {
                                Text = "";
                            }

                            if (Text == "") {
                                var dataItems = me.jobTypeMultiSelect.dataItems();

                                if (dataItems && dataItems.length > 0) {
                                    Text = dataItems[0].Name;
                                }
                            }
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
        this.resetJob = true;
        this.resetComponent = true;
        console.log('job code reset');
        this.jobCode = [];
        console.log('this.jobDataSource.read()');
        this.jobDataSource.read();
        this.componentCode = [];
        this.componentDataSource.read();

        this.clearGrid();

        this.statusMultiSelect.focus();
    }

    setStatusDataSource() {
        let me = this;
        this.statusDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchStatus'
                }
            }
        });
        if (this.statusMultiSelect) {
            this.statusMultiSelect.setDataSource(this.statusDataSource);
        }
    }

    statusMultiSelect_OnChange(e) {
        this.clearGrid();
    }

    setProjectManagerDataSource() {
        let me = this;
        this.projectManagerDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchProjectManager'
                }
            }
        });
        if (this.projectManagerMultiSelect) {
            this.projectManagerMultiSelect.setDataSource(this.projectManagerDataSource);
        }
    }

    excludeCompletedSchedulesChanged(newValue,oldValue) {

        if (this.jobDataSource) {
            console.log('this.jobDataSource.read()');
            this.jobDataSource.read();
        }
        if (this.componentDataSource) {
            this.componentDataSource.read();
        }
    }

    projectManagerMultiSelect_OnChange(e) {
        this.clearGrid();
    }

    setPhaseDataSource() {
        let me = this;
        this.phaseDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/ProjectSchedule/SearchPhases',
                    data: {
                        IncludeNoFilter: me.IncludeNoFilter,
                        IncludeNone: me.IncludeNone
                    }
                }
            }
        });

        if (this.phaseMultiSelect) {
            this.phaseMultiSelect.setDataSource(this.phaseDataSource);
        }
    }

    phaseMultiSelect_OnChange(e) {
        this.clearGrid();
    }

    setRoleDataSource() {
        let me = this;
        this.roleDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/ProjectSchedule/SearchRole'
                }
            }
        });
        if (this.roleMultiSelect) {
            this.roleMultiSelect.setDataSource(this.roleDataSource);
        }
    }

    roleMultiSelect_OnChange(e) {
        this.clearGrid();
    }

    setTaskDataSource() {
        let me = this;
        this.taskDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/ProjectSchedule/SearchTask'
                }
            }
        });
        if (this.taskMultiSelect) {
            this.taskMultiSelect.setDataSource(this.taskDataSource);
        }
    }

    taskMultiSelect_OnChange(e) {
        this.clearGrid();
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
        this.clearGrid();
    }

    getPageSize(){

        let me = this;

        this.usersettingservice.getPageSize("ProjectScheduleSearchGrid").then(response => {

            me.pageSize = response.content
            me.setGridDataSource();
            return response.content;
        });
    }

    onDataBound(e) {
        var PageSize = this.grid.dataSource.pageSize();
        this.totalpages = this.grid.pager.totalPages();
        this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        if (this.pageSize != PageSize) {
            this.usersettingservice.updatePageSize(PageSize, "ProjectScheduleSearchGrid");
            this.pageSize = PageSize;
        }
    }

    attached() {
        let client = new HttpClient();

        client.get('Utilities/GetDateFormat')
            .then(data => {

                this.datePicker.setOptions({
                    format: data.content.DateFormat,
                    parseFormats: data.content.DateInputFormat
                });
            });
    }

    showEditView(e) {

        let me = this;

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
            statusCode = '',
            projectManagerCode = '',
            phaseCode = '',
            employeeCode = '',
            taskCode = '',
            roleCode = '',
            cutoffDate: String = null;

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
            componentNumber = me.componentCode[0];
        }

        if (me.accountExecutiveCode && me.accountExecutiveCode.length > 0) {
            accountExecutiveCode = me.accountExecutiveCode[0];
        }

        if (me.jobTypeCode && me.jobTypeCode.length > 0) {
            jobTypeCode = me.jobTypeCode[0];
        }

        if (me.statusCode && me.statusCode.length > 0) {
            statusCode = me.statusCode[0];
        }

        if (me.projectManagerCode && me.projectManagerCode.length > 0) {
            projectManagerCode = me.projectManagerCode[0];
        }

        if (me.phaseCode && me.phaseCode.length > 0) {
            phaseCode = me.phaseCode[0];
        }

        if (me.employeeCode && me.employeeCode.length > 0) {
            employeeCode = me.employeeCode[0];
        }

        if (me.taskCode && me.taskCode.length > 0) {
            taskCode = me.taskCode[0];
        }

        if (me.roleCode && me.roleCode.length > 0) {
            roleCode = me.roleCode[0];
        }

        if (me.dateCutoff) {
            cutoffDate = me.dateCutoff.toDateString();
        }

        return 'ProjectManagement_ProjectSchedule_EditView?OfficeCode=' + officeCode + '&ClientCode=' + clientCode + '&DivisionCode=' + divisionCode +
            '&ProductCode=' + productCode + '&SalesClassCode=' + salesClassCode + '&Campaign=' + campaignID +
            '&JobNumber=' + jobNumber + '&ComponentNumber=' + componentNumber + '&AccountExecutiveCode=' + accountExecutiveCode +
            '&JobTypeCode=' + jobTypeCode + '&StatusCode=' + statusCode + '&ProjectManagerCode=' + projectManagerCode +
            '&PhaseCode=' + phaseCode + '&EmployeeCode=' + employeeCode + '&TaskCode=' + taskCode + '&RoleCode=' + roleCode +
            '&ExcludeCompletedSchedules=' + me.excludeCompletedSchedules + '&OnlyPendingTasks=' + me.onlyPendingTasks + '&ExcludeProjectedTasks=' + me.excludeProjectedTasks +
            '&IncludeCompletedTasks=' + me.includeCompletedTasks + '&OnlyScheduleTemplates=' + me.onlyScheduleTemplates +
            '&CutoffDate=' + cutoffDate;
    }

    //pageable = {
    //    refresh: true,
    //    pageSizes: true,
    //    buttonCount: 10
    //}

    showDetailView(JobNumber, JobComponentNumber) {
        return "Content.aspx?contaid=15&j=" + JobNumber + "&jc=" + JobComponentNumber;
    }

    newProjectShedule() {
        let me = this;
        this.dialogService.open({ viewModel: NewProjectScheduleDlg, lock: false }).whenClosed(response => {
            if (!response.wasCancelled) {
                me.search();
            }
        });
    }

    setGridDataSource() {
        let me = this;

        this.data = new kendo.data.DataSource({
            transport: {

                read: {

                    url: 'ProjectManagement/ProjectSchedule/Search',
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
                            statusCode = '',
                            projectManagerCode = '',
                            phaseCode = '',
                            employeeCode = '',
                            taskCode = '',
                            roleCode = '',
                            cutoffDate: String = null;

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

                        if (me.statusCode && me.statusCode.length > 0) {
                            statusCode = me.statusCode[0];
                        }

                        if (me.projectManagerCode && me.projectManagerCode.length > 0) {
                            projectManagerCode = me.projectManagerCode[0];
                        }

                        if (me.phaseCode && me.phaseCode.length > 0) {
                            phaseCode = me.phaseCode[0];
                        }

                        if (me.employeeCode && me.employeeCode.length > 0) {
                            employeeCode = me.employeeCode[0];
                        }

                        if (me.taskCode && me.taskCode.length > 0) {
                            taskCode = me.taskCode[0];
                        }

                        if (me.roleCode && me.roleCode.length > 0) {
                            roleCode = me.roleCode[0];
                        }

                        if (me.dateCutoff) {
                            cutoffDate = me.dateCutoff.toDateString();
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
                            StatusCode: statusCode,
                            ProjectManagerCode: projectManagerCode,
                            PhaseCode: phaseCode,
                            EmployeeCode: employeeCode,
                            TaskCode: taskCode,
                            RoleCode: roleCode,
                            ExcludeCompletedSchedules: me.excludeCompletedSchedules,
                            OnlyPendingTasks: me.onlyPendingTasks,
                            ExcludeProjectedTasks: me.excludeProjectedTasks,
                            IncludeCompletedTasks: me.includeCompletedTasks,
                            OnlyScheduleTemplates: me.onlyScheduleTemplates,
                            DateCutoff: cutoffDate
                        }
                    }
                }
            },
            pageSize: this.pageSize,
            serverPaging: true,
            schema: {
                data: "data",
                total: "total",
                model: {
                    id: 'JobNumber',
                    fields: {
                        JobNumber: { type: 'number' },
                        JobComponentNumber: { type: 'number' },
                        OfficeName: { type: 'string' },
                        OfficeCode: { type: 'string' },
                        ClientName: { type: 'string' },
                        ClientCode: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        DivisionName: { type: 'string' },
                        ProductCode: { type: 'string' },
                        ProductDescription: { type: 'string' },
                        StartDate: { type: 'date' },
                        DueDate: { type: 'date' },
                        JobDescription: { type: 'string' },
                        AccountExecutiveCode: { type: 'string' },
                        AccountExecutiveName: { type: 'string' }
                    }
                }
            }
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
                (this.salesClassCode && this.salesClassCode.length > 0 && this.salesClassCode[0] != '') ||
                (this.campaignID && this.campaignID.length > 0 && this.campaignID[0] > 0) ||
                (this.jobCode && this.jobCode.length > 0 && this.jobCode[0] > 0) ||
                (this.componentCode && this.componentCode.length > 0 && this.componentCode[0] > 0) ||
                (this.accountExecutiveCode && this.accountExecutiveCode.length > 0 && this.accountExecutiveCode[0] != '') ||
                (this.jobTypeCode && this.jobTypeCode.length > 0 && this.jobTypeCode[0] != '') ||
                (this.projectManagerCode && this.projectManagerCode.length > 0 && this.projectManagerCode[0] != '') ||
                (this.phaseCode && this.phaseCode.length > 0 && this.phaseCode[0] != '') ||
                (this.employeeCode && this.employeeCode.length > 0 && this.employeeCode[0] != '') ||
                (this.taskCode && this.taskCode.length > 0 && this.taskCode[0] != '') ||
                (this.roleCode && this.roleCode.length > 0 && this.roleCode[0] != '')) {
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
                this.productID[0] = this.replaceAll(this.productID[0], '%2c', ',');
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
                this.componentCode[0] = this.replaceAll(params.Parameters['jc'], '%2c', ',');
            }
            if (params.Parameters['jt'] != undefined) {
                this.jobTypeCode[0] = params.Parameters['jt'];
            }
            if (params.Parameters['js'] != undefined) {
                this.statusCode[0] = params.Parameters['js'];
            }

            if (params.Parameters.projectManagerCode) {
                this.projectManagerCode[0] = params.Parameters.projectManagerCode
            }
            if (params.Parameters.phaseCode) {
                this.phaseCode[0] = params.Parameters.phaseCode
            }
            if (params.Parameters.roleCode) {
                this.roleCode[0] = params.Parameters.roleCode
            }
            if (params.Parameters.taskCode) {
                this.taskCode[0] = params.Parameters.taskCode;
            }
            if (params.Parameters.employeeCode) {
                this.employeeCode[0] = params.Parameters.employeeCode;
            }
            if (params.Parameters.dateCutoff) {
                this.dateCutoff = new Date(this.replaceAll(params.Parameters.dateCutoff, '%2f', '/'));
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
        }).fail(function (xhr, status, error) {
            //alert(error);
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
        }).fail(function (xhr, status, error) {
            //alert(error);
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
        }).fail(function (xhr, status, error) {
            //alert(error);
        });
    }

    constructor(dialogService: DialogService, router: Router, service: ProjectScheduleService, usersettingservice: UserSettingService, openModule) {
        super();
        let me = this;
        this.dialogService = dialogService;
        this.router = router;
        this.service = service;
        this.usersettingservice = usersettingservice;
        this.openModule = openModule;

        this.getPageSize();

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
        this.setStatusDataSource();
        this.setProjectManagerDataSource();
        this.setPhaseDataSource();
        this.setEmployeeDataSource();
        this.setTaskDataSource();
        this.setRoleDataSource();

        this.CanAdd('ProjectSchedule/CanAdd');

        this.onlyPendingTasksID = this.uuidv4();
        this.excludeProjectedTasksID = this.uuidv4();
        this.includeCompletedTasksID = this.uuidv4();
        this.excludeCompletedSchedulesID = this.uuidv4();
        this.onlyScheduleTemplatesID = this.uuidv4();

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
