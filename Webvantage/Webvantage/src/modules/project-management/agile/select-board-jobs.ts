import { bindable, inject } from 'aurelia-framework';
import { AgileService } from 'services/project-management/agile/agile-service';
import { ModuleBase } from 'modules/base/module-base';

@inject(AgileService)
export class SelectBoardJobs extends ModuleBase {

    @bindable boardId: number;

    service: AgileService;
    jobsDataSource: kendo.data.DataSource;
    selectJobsGrid: kendo.ui.Grid;
    filter: HTMLInputElement;
    filterTimeout: number;
    selectedJobs = [];
    filterString: string = '';

    selectJobsGridOnChange(e) {
        let me = this;
        var grid: kendo.ui.Grid = e.sender;
        var items = grid.items();
        items.each(function (idx, row) {
            var idVal = grid.dataItem(row).get('Key');
            if (row.className.indexOf('k-state-selected') >= 0) {
                me.selectedJobs[idVal] = grid.dataItem(row);
            } else if (me.selectedJobs[idVal]) {
                delete me.selectedJobs[idVal];
            }
        });
    }
    selectJobsGridOnReady(e) {
        var grid: kendo.ui.Grid = e;
        grid.setOptions({ pageable: { pageSizes: [10, 20, 50, 100, 200] } });
    }
    activate(params: any) {
        let me = this;
        this.boardId = params.BoardID;
        this.jobsDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ProjectManagement/Agile/InitSelectBoardJobs',
                    type: 'POST',
                    data: function () {
                        return {
                            BoardID: me.boardId,
                            ExcludeJobsOnBoard: true,
                            FilterString: me.filterString
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
            pageSize: 50
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

                me.jobsDataSource.read();

            }, 500);
            
        });
        (<any>window).MvcSaveBridge = function () {
            return me.save();
        }
    }
    save() {
        let items = this.selectedJobs;
        var dataItems = [];
        var fullDataItems = [];
        for (var prop in items) {
            var jobNumber = Number(prop.split(",")[0]);
            var jobComponentNumber = Number(prop.split(",")[1]);
            dataItems.push({ JobNumber: jobNumber, JobComponentNumber: jobComponentNumber });
            fullDataItems.push(items[prop]);
        }
        if (dataItems.length === 0) {
            this.alert('Please select a job.');
            return false;
        }
        if (this.boardId > 0) {
            return this.service.addJobsToBoard(this.boardId, dataItems).then(response => {
                if (response.content.Success === false && response.content.Message) {
                    this.alert(response.content.Message);
                }
                return response;
            });
        } else {
            return fullDataItems;
        }
    }

    constructor(service: AgileService) {
        super();
        this.service = service;
        let me = this;
        this.jobsDataSource = new kendo.data.DataSource();
    }

}
