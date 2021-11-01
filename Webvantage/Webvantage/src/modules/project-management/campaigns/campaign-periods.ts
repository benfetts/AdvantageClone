import { ModuleBase } from 'modules/base/module-base';
import { inject } from 'aurelia-framework';
import { customElement } from 'aurelia-framework';
import { CampaignService } from 'services/project-management/campaign-service';
import { CampaignModel } from 'models/project-managment/campaign-model';
import { DialogService } from 'aurelia-dialog';
import { Webvantage } from '../../../webvantage';
import { Application } from 'models/common/application';
import { HttpClient } from 'aurelia-http-client';
import { CampaignDetailModel } from 'models/project-managment/campaign-detail-model'
import { ModelBase } from 'models/base/model-base';
import { CreateBudgetDialog } from 'modules/project-management/campaigns/create-budget-dialog';
import { UserSettingService } from 'services/utilities/user-settings-service';

@inject(DialogService, UserSettingService)
export class CampaignPeriods extends ModelBase{
    SalesClassTemplate = '${SalesClassName}';
    PostPeriodTemplate = '${PostPeriodName}';
    CampaignDetailTypeTemplate = '${CampaignDetailTypeName}';
    DepartmentTeamTemplate = '${DepartmentTeamName}';
    FunctionTemplate = '${FunctionName}';

    dialogService: DialogService;
    service: UserSettingService;

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;
    CampiagnIdentifier: number;

    pageSize: number = 15;
    totalpages: number;

    gridVM: any;

    salesClassDataSource: kendo.data.DataSource;
    functionDataSource: kendo.data.DataSource;
    postPeriodDataSource: kendo.data.DataSource;
    campaignDetailTypeDataSource: kendo.data.DataSource;
    departmentTeamDataSource: kendo.data.DataSource;
    title: string;
    hasChanges: boolean = false;

    campaignDetailModel: CampaignDetailModel = new CampaignDetailModel();

    onFocus() {
        console.log('focus');
    }

    setCampaignDetailTypeDataSource() {
        let me = this;
        this.campaignDetailTypeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchCampaignDetailTypes'
                }
            }
        });
    }

    setDepartmentTeamDataSource() {
        let me = this;
        this.departmentTeamDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchDepartmentTeam'
                }
            }
        });
    }

    setSalesClassDataSource() {
        let me = this;
        this.salesClassDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchSalesClassAll'
                }
            }
        });
    }

    setFunctionDataSource() {
        let me = this;
        this.functionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchFunctions'
                }
            }
        });
    }

    setPostPeriodDataSource() {
        let me = this;
        this.postPeriodDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchPostPeriod'
                }
            }
        });
    }

    Budget_OnChange(e) {
        this.saveBudgetAmounts();
    }

    saveBudgetAmounts() {
        var client = new HttpClient();

        var data = {
            CampaignID: this.CampiagnIdentifier,
            BillingBudgetAmount: this.campaignDetailModel.BillingBudgetAmount,
            IncomeBudgetAmount: this.campaignDetailModel.IncomeBudgetAmount
        };

        client.post("ProjectManagement/Campaign/SaveBudgetAmounts", data)
            .then(data => {
                console.log(data);
            });
    }

    activate(params: any) {
        let me = this;
        this.CampiagnIdentifier = params.Parameters['CampaignID'];

        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Campaign/GetPeriods',
                    data: {
                        ID: this.CampiagnIdentifier
                    }
                },
                update: {
                    url: 'ProjectManagement/Campaign/UpdatePeriod',
                    type: 'POST'
                },
                destroy: {
                    url: 'ProjectManagement/Campaign/DestroyPeriod',
                    type: 'POST'
                },
                create: {
                    url: 'ProjectManagement/Campaign/CreatePeriod',
                    type: 'POST'
                    //,create: function (options) {
                    //    var result = getResult(options);
                    //    options.success(result);
                    //}
                },
                parameterMap: function (data, type) {
                    if (type == "create") {
                        // send the created data items as the "models" service parameter encoded in JSON
                        var foo;
                        foo = data;
                        foo.CampaignID = me.CampiagnIdentifier;
                        return foo;
                    }
                    else if (type == "read" || type == "destroy" || type == "update") {
                        return data;
                    }
                }
            },
            pageSize: me.pageSize,
            schema: {
                model: {
                    id: 'ID',
                    fields: {
                        CampaignID: { type: 'number' },
                        ID: { type: 'number' },
                        SalesClassCode: {
                            type: 'string', validation: {
                                required: true,
                                from: "SalesClassCode"
                                //dropdownlistValidation: function (input) {
                                //    if (input.is("[name='SalesClassCode']")) {
                                //        var isValid = true;
                                //        if (input.val() == '') {
                                //            isValid = false;
                                //        }
                                //        return isValid;
                                //    }
                                //    return true;
                                //}
                            }
                        },
                        SalesClassName: { type: 'string' },
                        PostPeriodCode: {
                            type: 'string', validation: {
                                required: true,
                                from: "PostPeriodCode"
                                //dropdownlistValidation: function (input) {
                                //    if (input.is("[name='PostPeriodCode']")) {
                                //        var isValid = true;
                                //        if (input.val() == '') {
                                //            isValid = false;
                                //        }
                                //        return isValid;
                                //    }
                                //    return true;
                                //}
 },
                        },
                        PostPeriodName: { type: 'string' },
                        CampaignDetailTypeCode: { type: 'string', validation: { required: true } },
                        CampaignDetailTypeName: { type: 'string' },
                        DepartmentTeamCode: { type: 'string', validation: { required: true } },
                        DepartmentTeamName: { type: 'string' },
                        BillingBudgetAmount: { type: 'number', validation: { required: true, min: 0 } },
                        IncomeBudgetAmount: { type: 'number', validation: { required: true, min: 0 } },
                        RevisedDate: { type: 'date' },
                        UserCode: { type: 'string' },
                        FunctionCode: { type: 'string', validation: { required: true } },
                        FunctionName: { type: 'string' }
                    }
                }
            },
            change: function (e) {

                if (e.action === 'add') {
                    me.hasChanges = true;
                }
                else if (e.action === 'itemchange') {
                    me.hasChanges = true;
                }
                else if (e.action === 'sync') {
                    me.hasChanges = false;
                }
            },
            requestEnd: function (e) {
                if (e.type != "read") {
                    me.GetCampaignDetails();
                }
            }
        });
    }

    save() {
        let me = this;
        if (this.hasChanges) {

            if (this.validateGrid()) {

                this.grid.saveChanges();
            }

        }
    }

    validateGrid() {

        return true;
    }

    checkForChanges() {

        var hasChanges = false;

        for (var i = 0; i < this.data.data().length; i++) {
            if (this.data.data()[i].dirty === true) {
                hasChanges = true;
            }
        }

        this.hasChanges = hasChanges;

    }

    GetCampaignDetails() {
        let client = new HttpClient();
        let me = this;

        var data = {
            ID: me.CampiagnIdentifier
        };

        client.get("ProjectManagement/Campaign/GetCampaignDetails", data)
            .then(data => {
                me.campaignDetailModel = data.content;

                me.SetTitle();
            });
    }

    attached() {
        let me = this;
        setTimeout(function () {
            me.grid.dataSource.read();
        }, 200);

        let input = document.getElementById('totalBilling');
        input.addEventListener('focus', (event) => {

            var selectTimeId = setTimeout(function () {
                var foo;
                foo = input;
                foo.select();
            });
        }, true);

        let inputTotalIncome = document.getElementById('totalIncome');
        inputTotalIncome.addEventListener('focus', (event) => {

            var selectTimeId = setTimeout(function () {
                var foo;
                foo = inputTotalIncome;
                foo.select();
            });
        }, true);

        this.GetCampaignDetails();
    }

    delete(uid) {
        let me = this;
        let item = this.grid.dataSource.getByUid(uid);
        var client = new HttpClient();

        console.log(item);
        var foo;
        foo = item;
        var data = {
            ID: item.id,
            CampaignID: foo.CampaignID
        };

        client.post("ProjectManagement/Campaign/DestroyPeriod", data)
            .then(data => {
                console.log(data);

                me.GetCampaignDetails();
                me.data.read();
            });
    }

    SetTitle() {
        this.title = '';

        if (this.campaignDetailModel.CampaignIdentifier) {
            this.title = this.campaignDetailModel.CampaignCode;

            if (this.campaignDetailModel.CampaignIdentifier.toString() != this.campaignDetailModel.CampaignCode) {
                this.title += ' (' + this.campaignDetailModel.CampaignIdentifier.toString() + ')'
            }

            this.title += ' - ' + this.campaignDetailModel.CampaignName + ' - ' + this.campaignDetailModel.Client.Name;

            if (this.campaignDetailModel.Client.Name != this.campaignDetailModel.Division.Name && this.campaignDetailModel.Division.Name != "") {
                this.title += '/' + this.campaignDetailModel.Division.Name;

                if (this.campaignDetailModel.Division.Name != this.campaignDetailModel.Product.Name && this.campaignDetailModel.Product.Name != "") {
                    this.title += '/' + this.campaignDetailModel.Product.Name;
                }
            }
            else if (this.campaignDetailModel.Client.Name != this.campaignDetailModel.Product.Name && this.campaignDetailModel.Product.Name != ""){
                this.title += '/' + this.campaignDetailModel.Product.Name;
            }
        }
    }

    Export() {
        alert('Export Budget');
    }

    CreateBudget() {
        let me = this;

        if (confirm("The current budget amounts will be cleared and re-allocated.\nAre you sure you want to continue?")) {
            this.dialogService.open({ viewModel: CreateBudgetDialog, lock: false }).whenClosed(response => {
                if (!response.wasCancelled) {
                    let client = new HttpClient();

                    var data = {
                        ID: me.CampiagnIdentifier,
                        BeginPostPeriodCode: response.output.PostPeriodCode,
                        MaxPeriods: response.output.MaxPeriods
                    };

                    client.post("ProjectManagement/Campaign/CreateBudget", data)
                        .then(data => {
                            me.GetCampaignDetails();
                            me.data.read();

                            if (data.content.success == false) {
                                alert(data.content.message);
                            }
                        });
                }
            });
        }
    }

    ReAllocateBudget() {
        if (confirm("The current budget amounts will be cleared and re-allocated.\nAre you sure you want to continue?")) {
            let client = new HttpClient();
            let me = this;

            var data = {
                ID: me.CampiagnIdentifier
            };

            client.post("ProjectManagement/Campaign/ReAllocateBudget", data)
                .then(data => {
                    me.GetCampaignDetails();
                    me.data.read();
                });
        }
    }

    cancelRowChanges(uid) {

        let item = this.grid.dataSource.getByUid(uid);
        this.data.cancelChanges(item);
        this.grid.refresh();

        this.checkForChanges();
    }

    getPageSize(){

        let me = this;

        return this.service.getPageSize("CampaignPeriodGrid").then(response => {

            me.pageSize = response.content
        });
    }

    onDataBound(e) {
        var PageSize = this.grid.dataSource.pageSize();
        this.totalpages = this.grid.pager.totalPages();
        this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        console.log("onDB1:" + PageSize);
        console.log("onDB2:" + this.pageSize);
        if (this.pageSize != PageSize) {
            this.service.updatePageSize(PageSize, "CampaignPeriodGrid");
            this.pageSize = PageSize;
        }
    }

    constructor(dialogService: DialogService, service: UserSettingService) {
        super();
        this.dialogService = dialogService;
        this.service = service;

        let me = this;

        this.getPageSize().then(data => {
            me.setPostPeriodDataSource();

            me.postPeriodDataSource.pageSize(me.pageSize);
            me.postPeriodDataSource.read()
        });

        this.setSalesClassDataSource();
        this.setFunctionDataSource();
        this.setCampaignDetailTypeDataSource();
        this.setDepartmentTeamDataSource();
    }

    salesClassDropDownEditor(container, options) {
        var item;

        item = $('<input name="SalesClassCode" data-text-field="Name" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.salesClassDataSource,
            change: function (e) {
                Model.SalesClassName = e.sender.text();
            }
        });

        item.kendoDropDownList('open');

        $("<span class='k-invalid-msg' data-for='" + options.field + "'></span>").appendTo(container);
    }

    postPeriodDropDownEditor(container, options) {
        var item;

        item = $('<input name="PostPeriodCode" data-text-field="Name" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.postPeriodDataSource,
            change: function (e) {
                Model.PostPeriodName = e.sender.text();
            }
        });

        item.kendoDropDownList('open');

        $("<span class='k-invalid-msg' data-for='" + options.field + "'></span>").appendTo(container);
    }


    campaignDetailTypeDropDownEditor(container, options) {
        var item;

        item = $('<input data-text-field="Name" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.campaignDetailTypeDataSource,
            change: function (e) {
                Model.CampaignDetailTypeName = e.sender.text();
            }
        });

        item.kendoDropDownList('open');
    }

    departmentTeamDropDownEditor(container, options) {
        var item;

        item = $('<input data-text-field="Name" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.departmentTeamDataSource,
            change: function (e) {
                Model.DepartmentTeamName = e.sender.text();
            }
        });

        item.kendoDropDownList('open');
    }

    functionDropDownEditor(container, options) {
        var item;

        item = $('<input data-text-field="Name" data-value-field="Code" style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        let Model = options.model;

        item.kendoDropDownList({
            valuePrimitive: true,
            autoBind: true,
            dataSource: this.functionDataSource,
            change: function (e) {
                Model.FunctionName = e.sender.text();
            }
        });

        item.kendoDropDownList('open');
    }

    billingAmountEditor(container, options) {
        let item;

        //<input id="totalBilling" type = "number" ak - numerictextbox="k-value.two-way: campaignDetailModel.BillingBudgetAmount; k-decimals.bind: null; k-format.bind: 'n2'; k-spinners.bind: true; k-restrict-decimals.bind: true; k-min.bind: 0;" k - focus.trigger="onFocus" style = " margin-left: 8px;" k - on - change.delegate="Budget_OnChange($event.detail)" />

        item = $('<input style="width: 100%" data-bind="value:' + options.field + '" />')
            .appendTo(container);

        item.kendoNumericTextBox({
            value: options.field,
            spinners: true,
            format: "{0:c2}",
            restrictDecimals: true
        });

        item[0].addEventListener('focus', (event) => {

            var selectTimeId = setTimeout(function () {
                var foo;
                foo = item;
                foo.select();
            });
        }, true);
    }
}
