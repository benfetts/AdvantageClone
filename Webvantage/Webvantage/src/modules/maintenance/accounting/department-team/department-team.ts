import { ModuleBase } from 'modules/base/module-base';
import { DepartmentTeamService } from 'services/maintenance/accounting/department-team-service';
import { inject } from 'aurelia-framework';
import { DepartmentTeamModel } from 'models/maintenance/department-team-model';

@inject(DepartmentTeamService)
export class DepartmentTeam extends ModuleBase {

    // properties
    service: DepartmentTeamService;
    model: any;
    dataSource: kendo.data.DataSource;
    serviceFeeTypesDataSource: kendo.data.DataSource;
    poApprovalRulesDataSource: kendo.data.DataSource;
    hasASelectedRow: boolean;
    grid: kendo.ui.Grid;

    delete(uid) {
        kendo.confirm('Are you sure you want to delete?').then(() => {
            
        }, () => {
            // do nothing
        });
    }
    saveClick() {
        this.grid.saveChanges();
    }
    addClick() {
        this.grid.addRow();
    }
    cancelClick() {
        this.grid.cancelChanges();
    }
    exportClick() {
        this.grid.saveAsExcel();
    }

    inactiveClick(uid) {
        //let item = this.dataSource.getByUid(uid);
        //if (!item.isNew()) {
        //    var model: any = item;
        //    this.service.updateDepartmentTeam(model).then(response => {
        //        this.grid.dataSource.pushUpdate(item);
        //    });
        //}
    }

    // methods
    getDepartmentTeams() {
        this.grid.dataSource.read();
    }
    toolbarClick(message: string) {
        kendo.alert(message);
    }
    gridOnEdit(e) {
        let fieldName = $(e.container).find("input").attr("name");
        if (fieldName === 'Code' && !e.model.isNew()) {
            this.grid.editCell($(e.container).siblings().first());
            return;
        }
        if (fieldName === 'Code') {
            $(e.container).find("input").attr('maxlength', 4);
        } else if (fieldName === 'Description') {
            $(e.container).find("input").attr('maxlength', 30);
        } else if (fieldName === 'Category') {
            $(e.container).find("input").attr('maxlength', 30);
        } else if (fieldName === 'ServiceFeeTypeCode') {
            $(e.container).find("input").attr('maxlength', 6);
        } else if (fieldName === 'PurchaseOrderApprovalRuleCode') {
            $(e.container).find("input").attr('maxlength', 6);
        }
    }

    activate(model: any) {
        this.model = model;    
    }

    poApprovalRuleEditor(container, options) {
        let dropDownList = $('<input name="' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                valuePrimitive: true,
                dataTextField: 'Description',
                dataValueField: 'Code',
                dataSource: this.poApprovalRulesDataSource,
                autoWidth: true
            }).data('kendoDropDownList');
        dropDownList.open();
    }
    serviceFeeTypeEditor(container, options) {
        let dropDownList = $('<input name="' + options.field + '" />')
            .appendTo(container)
            .kendoDropDownList({
                autoBind: false,
                valuePrimitive: true,
                dataTextField: 'Description',
                dataValueField: 'Code',
                dataSource: this.serviceFeeTypesDataSource,
                autoWidth: true
            }).data('kendoDropDownList');
        dropDownList.open();
    }

    attached() {
        
    }
    
    constructor(departmentTeamService: DepartmentTeamService) {
        super();
        let me = this;
        this.service = departmentTeamService;
        this.serviceFeeTypesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Maintenance/Accounting/DepartmentTeam/GetServiceFeeTypes'
                }
            },
            schema: {
                model: {
                    id: 'Code',
                    fields: {
                        'Code': { type: "string" },
                        'Description': { type: "string" }
                    }
                }
            }
        });
        this.poApprovalRulesDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Maintenance/Accounting/DepartmentTeam/GetPurchaseOrderApprovalRules'
                }
            },
            schema: {
                model: {
                    id: 'Code',
                    fields: {
                        'Code': { type: "string" },
                        'Description': { type: "string" }
                    }
                }
            }
        });
        this.poApprovalRulesDataSource.read();
        this.serviceFeeTypesDataSource.read();        
        this.dataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Maintenance/Accounting/DepartmentTeam/GetDepartmentTeams'
                },
                update: {
                    url: 'Maintenance/Accounting/DepartmentTeam/UpdateDepartmentTeams',
                    type: 'POST'
                },
                create: {
                    url: 'Maintenance/Accounting/DepartmentTeam/CreateDepartmentTeams',
                    type: 'POST'
                },
                destroy: {
                    url: 'Maintenance/Accounting/DepartmentTeam/DeleteDepartmentTeams',
                    type: 'POST'
                },
                parameterMap: function (data, type) {
                    if (type !== 'read') {
                        return {
                            DepartmentTeams: data.models
                        };
                    }
                }
            },
            sync: function (e) {
                me.showSuccessNotification("Changes saved!");
            },
            change: function (e) {
               //console.log(e);
                if (e.action == 'itemchange') {
                    let item: any = e.items[0];
                    item.dirtyFields = item.dirtyFields || {};
                    item.dirtyFields[e.field] = true;
                }
            },
            autoSync: false,
            batch: true,
            pageSize: 10,
            schema: {
                model: {
                    id: 'Code',
                    fields: {
                        "Code": {
                            type: "string",
                            nullable: false,
                            validation: {
                                required: true
                            }
                        },
                        "Description": {
                            type: "string",
                            nullable: false,
                            validation: {
                                required: true
                            }
                        },
                        "DirectHoursPercentGoal": {
                            type: "number"
                        },
                        "Category": {
                            type: "string"
                        },
                        "PurchaseOrderApprovalRuleCode": {
                            type: "string"
                        },
                        "ServiceFeeTypeCode": {
                            type: "string"
                        },
                        "IsInactive": {
                            type: "boolean",
                            editable: false
                        }
                    }
                }
            }

        });

    }

}
