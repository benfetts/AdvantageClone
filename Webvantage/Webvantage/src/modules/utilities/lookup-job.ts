import { bindable, inject } from 'aurelia-framework';
import { LookupService } from 'services/utilities/lookup-service';
import { ModuleBase } from 'modules/base/module-base';

@inject(LookupService)
export class LookupJob extends ModuleBase {

    @bindable hideInfo: boolean = false;
    @bindable salesClassColumnHeaderText: string = 'Sales Class<br/>Job Type';
    @bindable currentPage: number = 0;
    @bindable totalPages: number = 0;
    @bindable recordCount: number = 0;

    service: LookupService;
    lookupDataSource: kendo.data.DataSource;
    lookupGrid: kendo.ui.Grid;
    filter: HTMLInputElement;
    filterTimeout: number;
    filterString: string = '';
    selectedItem: any;
    lookupType: number = 0;
    lookupSource: number = 0;
    includeClosed: boolean = false;
    clientCode: string = '';
    divisionCode: string = '';
    productCode: string = '';
    jobNumber: number = 0;

    selectClick() {
        this.select();
    }
    cancelClick() {
        this.cancel();
        if (window.parent) {
            wvbridge.CloseWindow();
        }
    }
    select() {
        let me = this;
        //var key = me.selectedItem.Key;
        //var jobNumber = me.selectedItem.JobNumber;
        //var jobComponentNumber = me.selectedItem.JobComponentNumber;
        //var clientCode = me.selectedItem.ClientCode;
        //var divisionCode = me.selectedItem.DivisionCode;
        //var productCode = me.selectedItem.ProductCode;
        wvbridge.processLookupToAngular(me.selectedItem);
        wvbridge.CloseWindow();
    }
    cancel() {
    }
    lookupGridOnChange(e) {
        let me = this;
        me.selectedItem = null;
        var grid: kendo.ui.Grid = e.sender;
        var items = grid.items();
        items.each(function (idx, row) {
            var idVal = grid.dataItem(row).get('Key');
            if (row.className.indexOf('k-state-selected') >= 0) {
                me.selectedItem = grid.dataItem(row);
            }
        });
    }
    doubleClick() {
        this.select();
    }
    lookupGridOnDataBound(e) {
        this.currentPage = this.lookupDataSource.page();
        this.totalPages = this.lookupDataSource.totalPages();
        this.recordCount = this.lookupDataSource.total();
    }
    activate(params: any) {
        let me = this;
        if (params) {
            if (params.LookupType) {
                this.lookupType = params.LookupType;
            }
            if (params.LookupSource) {
                this.lookupSource = params.LookupSource;
            }
            if (params.IncludeClosed) {
                this.includeClosed = params.IncludeClosed;
            }
            if (params.ClientCode) {
                this.clientCode = params.ClientCode;
            }
            if (params.DivisionCode) {
                this.divisionCode = params.DivisionCode;
            }
            if (params.ProductCode) {
                this.productCode = params.ProductCode;
            }
            if (params.JobNumber) {
                this.jobNumber = params.JobNumber;
            }
       }
        if (this.lookupType && this.lookupType == 1) {
            this.hideInfo = true;
            this.salesClassColumnHeaderText = 'Sales Class';
        }
        this.lookupDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/Lookup/InitJobLookup',
                    type: 'POST',
                    data: function () {
                        return {
                            LookupType: me.lookupType,
                            LookupSource: me.lookupType,
                            IncludeClosed: me.lookupType,
                            SearchCriteriaText: me.filterString,
                            ClientCode: me.clientCode,
                            DivisionCode: me.divisionCode,
                            ProductCode: me.productCode,
                            JobNumber: me.jobNumber
                        };
                    }
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                errors: "Errors",
                model: {
                    id: "Key",
                    fields: {
                        JobNumber: { type: 'number' },
                        JobComponentNumber: { type: 'number' },
                        Key: { type: 'string' },
                        Description: { type: 'string' },
                        ClientCode: { type: 'string' },
                        DivisionCode: { type: 'string' },
                        ProductCode: { type: 'string' },
                        Client: { type: 'string' },
                        IsOnBoard: { type: 'boolean' },
                        SalesClassCode: { type: 'string' },
                        SalesClassDescription: { type: 'string' },
                        ManagerCode: { type: 'string' },
                        ManagerName: { type: 'string' },
                        AccountExecutiveCode: { type: 'string' },
                        AccountExecutiveName: { type: 'string' },
                        JobTypeCode: { type: 'string' },
                        JobTypeDescription: { type: 'string' }
                    }
                }
            },
            serverPaging: true,
            serverFiltering: true,
            pageSize: 20
        });
    }
    attached() {
        let me = this;
        $(document).ready(function () {
            $(me.filter).focus();
        });
        $(this.filter).on('input', function (e) {
            if (me.filterTimeout) {
                window.clearTimeout(me.filterTimeout);
            }
            me.filterTimeout = window.setTimeout(function () {
                me.lookupDataSource.read();
            }, 500);
        });
        //(<any>window).MvcSaveBridge = function () {
        //    return me.select();
        //}
    }
    constructor(service: LookupService) {
        super();
        this.service = service;
        let me = this;
        this.lookupDataSource = new kendo.data.DataSource();
    }

}
