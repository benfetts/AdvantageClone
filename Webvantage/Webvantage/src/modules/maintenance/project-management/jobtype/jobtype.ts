import { ModuleBase } from 'modules/base/module-base';
import { JobTypeService } from 'services/maintenance/project-management/jobtype-service';
import { inject, bindable } from 'aurelia-framework';
import { JobTypeModel } from 'models/maintenance/jobtype-model';

@inject(JobTypeService)
export class JobType extends ModuleBase {

    // properties
    service: JobTypeService;
    model: any;
    jobTypes: Array<JobTypeModel>;
    datasource: kendo.data.DataSource;
    hasASelectedRow: boolean;
    gridVM: any;
    grid: kendo.ui.Grid;
    @bindable showInactive: boolean = false;
    inactiveButton: HTMLElement;
    hasChanges: boolean = false;
    resizeTimeout: number;
    salesClassCodes: Array<any>;


    showInactiveChanged(newValue, oldValue) {
        let me = this;
        window.setTimeout(function () {
            me.filterInactive();
        });
    }

    // toolbar
    export() {
        
        this.grid.options.excel.allPages = true;
        //this.grid.options.excel.filterable = true;
        this.grid.options.excel.fileName = "JobTypes.xlsx";
        this.grid.saveAsExcel();
    }

    excelExport(e) {

        var sheet = e.workbook.sheets[0];

        for (var i = 1; i < sheet.rows.length; i++) {

            var row = sheet.rows[i];

            //Is Inactive
            if (row.cells[3].value === true) {
                row.cells[3].value = "Yes"
            }
            else {
                row.cells[3].value = "No";
            }
            
        }
    }

    // methods

    delete(uid) {

        //make sure they want to delete
        this.confirm('Are you sure you want to delete?').then(() => {

            //get the item from the datasource
            let item = this.grid.dataSource.getByUid(uid);

            //if it is not a new item
            if (item.isNew() == false) {

                //capture the response
                let success: boolean = false;

                //delete the item
                this.service.deleteJobType(item).then(response => {

                    //check the response
                    success = response.content;

                    if (success) {
                        //remove the item
                        this.datasource.remove(item);
                    }
                    else {
                        //let them know the delete failed
                        this.showNotification('This code is in use and cannot be deleted!',"error");
                    }
                });
            }
            else {

                //if it has never been saved, just delete it from the datasource
                this.datasource.remove(item);
            }

            //display the delete with the item code
            //this.alert('This item will be deleted after you click save.');

        }, () => {
            //let them know we cancelled the delete
            //this.alert('Delete cancelled');
        });
    }

    cancel(){

        if (this.hasChanges === true) {

            //make sure they want to cancel all changes
            this.confirm('Are you sure you want to cancel all of your changes? <br/>Note: You will lose all unsaved data.').then(confirmed => {

                this.grid.cancelChanges();
                this.hasChanges = false;

            }, denied => {
                
            })

        }
        
    }
    cancelRowChanges(uid) {

        let item = this.grid.dataSource.getByUid(uid);
        this.datasource.cancelChanges(item);

        if (item.isNew() === false) {

            var dataItem: any = item;

            this.service.getJobType(dataItem.Code).then(response => {

                this.grid.dataSource.pushUpdate(response.content);

                this.checkForChanges();

            });

        } else {

            this.checkForChanges();

        }

    }

    checkForChanges() {

        var hasChanges = false;

        for (var i = 0; i < this.datasource.data().length; i++) {
            if (this.datasource.data()[i].dirty === true) {
                hasChanges = true;
            }
        }

        this.hasChanges = hasChanges;

    }

    save() {

        if (this.hasChanges) {

            if (this.validateGrid()) {

                this.grid.saveChanges();
            }

        }

    }

    validateGrid() {

        var valid = true;

        var rows = this.grid.tbody.find("tr");

        for (var i = 0; i < rows.length; i++) {

            // Get the model
            var model = this.grid.dataItem(rows[i]);

            // Check the id property - this will indicate an insert row
            if (model && model.get("id") === "" && valid) {

                // Loop through the columns and validate them
                var cols = $(rows[i]).find("td");

                for (var j = 0; j < cols.length; j++) {

                    // Put cell into edit mode
                    this.grid.editCell($(cols[j]));

                    // Take cell out of edit mode
                    cols[j].blur();

                    // By calling editable end we will make validation fire
                    if ((<any>this.grid).editable != null && (<any>this.grid).editable.end() === false) {

                        valid = false;
                        break;
                    }

                    else {

                        // Take cell out of edit mode
                        this.grid.closeCell();

                    }

                }

            }

            else {

                // We're now to existing rows or have a validation error so we can stop
                break;
            }
        }


        return valid;
    }

    gridOnSave(e) {

        this.showSuccessNotification("Changes saved.");
    }

    getJobTypes() {

        //just invoke the read function
        this.grid.dataSource.read();
    }
 
    inactiveChanged(uid) {

        //get the item from the datasource
        let item = this.grid.dataSource.getByUid(uid);

        //set it to dirty
        item.dirty = true;
        this.hasChanges = true;

    }
    
    toolbarClick(message: string) {
        //this.alert(message);
    }

    rowSelected(event: any) {
        //console.log('row selected', event);
    }
    
    gridDataBound(e) {
        
    }

    gridOnEdit(e) {

        //console.log(e);

        //get the field name
        var fieldname = e.container.find("input").attr("name");

        //if the name is "Code" and it is not a new item
        if (fieldname === "Code" && e.model.isNew() === false) {
            //do not let them edit it, get the next field
            var cell = $($(e.container).siblings()[0]);

            //move to the next field automatically
            this.grid.editCell(cell);
        } else if (fieldname !== "Code" && e.model.isNew() === true) {
            if (!e.model.Code || e.model.Code === '') {
                //console.log('asdf', $(e.container).parent('tr').find('td').first());
                this.grid.editCell($(e.container).parent('tr').find('td').first());
            }
        }

        //set the Code's max-length
        e.container.find("input[name=Code]").attr("maxlength", 10);

        //set the Description's max-length
        e.container.find("input[name=Description]").attr("maxlength", 30);

        //get the current input
        var input = e.container.find("input");

        //select the text
        input.focus(this.onInputFocus);

        //trigger focus on input for maximum compatability
        input.trigger('focus');
    }

    gridOnDataBound(e) {
        var grid = <kendo.ui.Grid>e.sender;
        (<any>grid.element.find('[data-toggle="tooltip"]')).tooltip();
        grid.autoFitColumn(1);

    }

    salesClassCodeEditor(container, options) {

        // create an input element
        var input = $("<input/>");

        // set its name to the field to which the column is bound ('name' in this case)
        input.attr("name", options.field);

        // append it to the container
        input.appendTo(container);

        // initialize a Kendo UI AutoComplete
        input.kendoDropDownList({
            minLength: 1,
            autoWidth: true,
            filter: "contains",
            dataTextField: "text",
            dataValueField: "value",
            optionLabel: "[Please Select]",
            dataSource: this.salesClassCodes
        });

        //get the input as a kendo dropdown list
        var myKendoDropdownList = input.data("kendoDropDownList");

        //automatically open
        myKendoDropdownList.open();

    }
 
    onInputFocus(e) {

        //get the input
        var input = e.currentTarget;

        //select the value
        setTimeout(function () {
            input.select();
        }, 25);
       
    }

    filterInactive() {

        var filters = [];

        if (this.showInactive) {

            if (this.grid.dataSource.filter()) {

                filters = this.grid.dataSource.filter().filters;

                for (var i = 0; i < this.grid.dataSource.filter().filters.length; i++) {

                    var filter: any = this.grid.dataSource.filter().filters[i];

                    if (filter.field === 'IsInactive') {

                        filters.splice(i, 1);

                    }

                }

            }

        } else {

            if (this.grid.dataSource.filter()) {

                filters = this.grid.dataSource.filter().filters;

            }

            if (!filters || filters.length === 0) {

                filters = [];

            }

            filters.push({
                field: "IsInactive",
                operator: "eq",
                value: false
            });

        }

        if (filters.length === 0) {
            filters = null;
        }

        this.grid.dataSource.filter(filters);
        this.grid.refresh();

    }

    activate(model: any) {

        this.model = model;

        for (var i = 0; i < model.length; i++) {
            var maintJobTypeModel = new JobTypeModel;
            Object.assign(maintJobTypeModel, model[i]);
            this.jobTypes.push(maintJobTypeModel);
        }
    }

    attached() {
        let me = this;
        $(document).ready(function () {
            $(window).resize(function () {
                if (me.resizeTimeout) {
                    window.clearTimeout(me.resizeTimeout);
                }
                me.resizeTimeout = window.setTimeout(function () {
                    me.grid.resize();
                }, 50);
            });


        });
        this.service.initJobTypeMaintenance().then(response => {
            this.salesClassCodes = response.content.SalesClassCodes;
            
            window.setTimeout(function () {
                me.gridVM.recreate();
            }, 0);
        });

        //window.setTimeout(function () {
        //        me.gridVM.recreate();
        //    }, 0);


    }

    clearSortingAndFilters() {
        var datasource = this.grid.dataSource;
        var filters = null;
        var sorting = [{ field: "Code", dir: "asc" }];

        //Clear filters:
        datasource.filter(filters);

        //clear sorting
        datasource.sort(sorting);

    }

    constructor(Service: JobTypeService) {
        super();
        this.service = Service;
        this.jobTypes = new Array<JobTypeModel>();

        let me = this;

        this.datasource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Maintenance/ProjectManagement/JobType/GetJobTypes'
                },
                update: {
                    url: 'Maintenance/ProjectManagement/JobType/UpdateJobTypes',
                    type: 'POST'
                },
                create: {
                    url: 'Maintenance/ProjectManagement/JobType/CreateJobTypes',
                    type: 'POST'
                },
                destroy: {
                    url: 'Maintenance/ProjectManagement/JobType/DeleteJobTypes',
                    type: 'POST'
                },
                parameterMap: function (data, type) {
                    if (type !== 'read') {
                        return {
                            JobTypes: data.models
                        }
                    }
                }
            },
            batch: true,
            autoSync: false,
            requestEnd: function (e) {

                switch (e.type) {

                    case "create":
                        {
                            if (e.response == false) {
                                me.showNotification("One or more new items failed to save!", "error");
                            }
                            else if (e.response == true) {
                                //me.showSuccessNotification("Added new items successfully.");
                            }
                        }
                    case "update":
                        {
                            if (e.response == false) {
                                me.showNotification("One or more items failed to save!", "error");
                            }
                            else if (e.response == true) {

                                me.showSuccessNotification("Changes saved!");
                                //me.showSuccessNotification("Updated items successfully.");
                            }
                        }
                    case "destroy":
                        {
                            if (e.response == false) {
                                me.showNotification("One or more items failed to delete!", "error");
                            }
                            else if (e.response == true) {
                                //me.showSuccessNotification("Item deleted successfully.");
                            }
                        }
                }

            },
            schema: {
                model: {
                    id: "Code",
                    fields: {
                        Code: {
                            type: "string",
                            length: "10",
                            title: "Code",
                            validation: {
                                required: true,
                                CodeValidation: function (input) {

                                    var found = ''

                                    var checkGridCodes = function () {

                                        var codeExists = false;

                                        var rows = me.grid.tbody.find("tr");

                                        var currentRow = input[0].kendoBindingTarget.source.uid;

                                        for (var i = 0; i < rows.length; i++) {

                                            // Get the model
                                            var model = me.grid.dataItem(rows[i]);

                                            //make sure we are not looking at the same row we are edititing.
                                            if (model.uid != currentRow) {

                                                //if the existing code is the same as the new code
                                                if ((<any>model).Code === input.val()) {

                                                    //the code was found
                                                    codeExists = true;
                                                    break;
                                                }
                                            }
                                        };

                                        //failed validation
                                        return codeExists;
                                    }
                                    //get the jobType exists method
                                    $.ajax({
                                        url: "Maintenance/ProjectManagement/JobType/JobTypeExists",
                                        async: false,
                                        data: {
                                            Code: input.val()
                                        },
                                        success: function (response) {
                                            found = response;
                                        }
                                    });

                                    //find special characters
                                    var pattern = /\_|\`|\~|\!|\@|\#|\$|\%|\^|\&|\*|\(|\)|\+|\=|\[|\{|\]|\}|\||\\|\'|\<|\,|\.|\>|\?|\/|\""|\;|\:|\s/g;

                                    //if it was found and input is not blank
                                    if (found == 'True' && input.is("[name='Code']") && input.val() != "") {
                                        input.attr("data-CodeValidation-msg", "Code already exists.");
                                        return false;
                                    }
                                    else if (checkGridCodes()) {
                                        input.attr("data-CodeValidation-msg", "Code already exists.");
                                        return false;
                                    }
                                    //if the input has special characters
                                    else if (pattern.test(input.val()) && input.val() != "") {
                                        input.attr("data-CodeValidation-msg", "Special characters are not allowed.");
                                        return false;
                                    }
                                    else {
                                        return true;
                                    }

                                }
                            }

                        },
                        Description: {
                            type: "string",
                            title: "Description",
                            validation: {
                                required: true
                            }
                        },
                        SalesClassCode: {
                            type: "string",
                            title: "Sales Class",
                            validation: {
                                required: true
                            }
                        },
                        IsInactive: {
                            type: "boolean",
                            title: "Is Inactive",
                            editable: false
                        }
                    }
                }
            },
            pageSize: 50,
            filter: { field: "IsInactive", operator: "eq", value: false },
            change: function (e) {

                if (e.action === 'add') {
                    
                    var datasource = me.grid.dataSource;
                    var filters = null;
                    var sorting = { field: "Code", dir: "asc" };

                    //filter inactive is true
                    if (!me.showInactive) {

                        //filter the inactive items
                        filters = { field: "IsInactive", operator: "eq", value: false };

                    }

                    //update filters:
                    datasource.filter(filters);

                    //update sorting
                    datasource.sort(sorting);
                } 
                else if (e.action === 'itemchange') {
                    me.hasChanges = true;
                }
                else if (e.action === 'sync') {
                    me.hasChanges = false;
                }
            }

        });

    }

}


