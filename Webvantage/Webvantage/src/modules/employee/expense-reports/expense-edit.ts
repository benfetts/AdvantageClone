import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject, bindable } from 'aurelia-framework';
import { ExpenseReportsService } from 'services/employee/expense-reports-service';
import { EmployeeExpenseReport } from 'models/employee/expense-report'
import * as moment from 'moment';

@inject(Router, ExpenseReportsService)
export class ExpenseEdit extends ModuleBase {

    message: string = 'Editing Expense Report #';
    id: number;
    router: Router;
    service: ExpenseReportsService;
    gridVM: any;
    grid: kendo.ui.Grid;
    datasource: kendo.data.DataSource;
    expenseReport: EmployeeExpenseReport.ExpenseReport;
    employeeName: string;
    employeeCode: string;
    employee: any;
    status: string;
    reportDate: Date;
    hasChanges: boolean = false;
    selectAll: boolean = false;
    totalExpenses: number = 0;
    lessCreditCard: number = 0;
    totalDue: number = 0;
    selectedRows: Array<number>;
    descriptionInput: HTMLInputElement;
    functionCodes: Array<any>;
    paymentTypes: Array<any>;
    jobs: Array<any>;

    CanSubmit: boolean = false;
    CanSave: boolean = true;
    CanCopy: boolean = true;
    CanDelete: boolean = true;

    getExpenseReport() {

        this.service.getExpenseReport(this.id).then(response => {

            this.expenseReport = response;

            if (this.expenseReport.InvoiceNumber === 0) {

                this.getEmployee(this.employeeCode);
            }
            else {
                this.getEmployee(this.expenseReport.EmployeeCode);
            }

            if (this.expenseReport.InvoiceNumber === 0) {
                this.setupNewExpenseReport();
            }

            this.setupForm(this.expenseReport.Status, this.expenseReport.InvoiceNumber);

            //console.log(response.content);

        });

    }

    setupForm(status, invoiceNumber) {

        if (status != EmployeeExpenseReport.ExpenseReportStatus.Open) {

            this.CanSave = false;
            this.CanCopy = false;
            this.CanDelete = false;
        }

        if (invoiceNumber === 0) {

            this.CanSubmit = false;
        }

    }

    submit() {
        alert('submit!');
    }

    setupNewExpenseReport() {

        this.expenseReport.CreatedBy = this.expenseReport.EmployeeName;
        this.expenseReport.CreatedDate = new Date();
        this.expenseReport.InvoiceDate = new Date();
        this.expenseReport.StatusCode = "Open";
        this.expenseReport.Status = 0;

    }

    getEmployee(code) {

        this.service.getEmployee(code).then(response => {

            this.employee = response.content;

            this.expenseReport.EmployeeName = this.employee.Name;
            this.expenseReport.EmployeeCode = this.employee.Code;
            this.expenseReport.VendorCode = this.employee.VendorCode;



            //console.log(response.content);

        });

        return true;
    }

    save() {

        this.saveExpenseReport();

    }

    saveExpenseReport() {

        if (this.validateExpenseReport() && this.validateExpenseReportDetails()) {

            if (this.expenseReport.InvoiceNumber === 0) {

                //add the invoice and load the invoice with the new invoice number
                this.service.createExpenseReport(this.expenseReport).then(response => {

                    if (response && response.length > 0) {

                        //set the current expense report data with the new Invoice Number
                        this.expenseReport = response[0];

                        //Update the expense report details
                        this.updateExpenseDetails();

                        //sync the data items
                        this.grid.dataSource.sync();

                    }
                    else {
                        //let them know that we could not save
                        this.showNotification("Could not save data!", "error");
                    }
                });
            }
            else {

                //update the expense report
                this.service.updateExpenseReport(this.expenseReport).then(response => {

                    if (response) {

                        //Update the expense report details
                        this.updateExpenseDetails();

                        //sync the data items
                        this.grid.dataSource.sync();
                    }
                    else {

                        //let them know that we could not save
                        this.showNotification("Could not save data!", "error");
                    }
                });
            }
        }

    }

    updateExpenseDetails() {

        //make sure this is set
        this.id = this.expenseReport.InvoiceNumber;

        //update all details that have the wrong invoice number before we sync the data
        for (var i = 0; i < this.datasource.data().length; i++) {
            if (this.datasource.data()[i].InvoiceNumber != this.expenseReport.InvoiceNumber) {

                this.datasource.data()[i].InvoiceNumber = this.expenseReport.InvoiceNumber;
                this.datasource.data()[i].dirty = true;
            }
        }
    }

    validateExpenseReport() {

        var validated = true;

        if (!this.expenseReport.VendorCode) {
            validated = false;

            this.showNotification("This employee is not associated with a vendor code!", "error");

        }

        //validate the description field
        if (!this.expenseReport.Description) {

            validated = false;

            var input = this.descriptionInput;

            this.showValidationError(this.descriptionInput);

            this.showNotification("Description is required!", "error");
        }
        else {

            var input = this.descriptionInput;

            this.clearValidationError(input);
        }

        return validated;
    }

    validateExpenseReportDetails() {

        var valid = true;

        var rows = this.grid.tbody.find("tr");

        for (var i = 0; i < rows.length; i++) {

            // Get the model
            var model = this.grid.dataItem(rows[i]);

            // Check the id property - this will indicate an insert row
            if (model && model.get("ID") === 0 && valid) {

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
                this.service.deleteExpenseReportDetails(item).then(response => {

                    //check the response
                    success = response.content;

                    if (success) {
                        console.log('delete sucess!');

                        //remove the item
                        this.datasource.remove(item);
                    }
                    else {
                        //let them know the delete failed
                        this.showNotification('Delete failed!');
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

    showValidationError(input) {

        $(input).css('border-color', 'red');
    }

    clearValidationError(input) {

        $(input).css('border-color', '');
    }

    search() {
        //this.router.navigateToRoute('search');
        this.router.navigateBack();
    }

    cancelRowChanges(uid) {

        let item = this.grid.dataSource.getByUid(uid);
        this.datasource.cancelChanges(item);

        if (item.isNew() === false) {

            var dataItem: any = item;

            this.service.getExpenseReportDetail(dataItem.ID).then(response => {

               //console.log(response);

                this.grid.dataSource.pushUpdate(response);

            });
        }

        this.calcExpenses();
    }


    adjustDropDownWidth(e) {

        var listContainer = e.sender.list.closest(".k-list-container");

        listContainer.width(listContainer.width() + kendo.support.scrollbar());
    }

    editSmallInt(container, options) {

        //create a numeric editor
        var input = $('<input data-bind="value:' + options.field + '"/>')

        //add it to the container
        input.appendTo(container)

        //disable the spinners
        input.kendoNumericTextBox({
            spinners: false,
            decimals: 0,
            restrictDecimals: true,
            min: 0,
            max: 32767
        });

        //disable the arrow keys
        input.unbind("keydown");
    }

    editQuantity(container, options) {

        //create a numeric editor
        var input = $('<input data-bind="value:' + options.field + '"/>')

        //add it to the container
        input.appendTo(container)

        //disable the spinners
        input.kendoNumericTextBox({
            spinners: false,
            decimals: 0,
            restrictDecimals: true,
            min: 0,
            max: 32767,
            change: this.calcLineItemAmount
        });

        //disable the arrow keys
        input.unbind("keydown");
    }

    editNumber(container, options) {

        //create a numeric editor
        var input = $('<input data-bind="value:' + options.field + '"/>')

        //add it to the container
        input.appendTo(container)

        //disable the spinners
        input.kendoNumericTextBox({
            spinners: false,
            decimals: 2,
            restrictDecimals: true,
            min: 0,
            max: 32767
        });

        //disable the arrow keys
        input.unbind("keydown");
    }

    editRate(container, options) {
        
        //create a numeric editor
        var input = $('<input data-bind="value:' + options.field + '"/>')

        //add it to the container
        input.appendTo(container)

        //disable the spinners
        input.kendoNumericTextBox({
            spinners: false,
            decimals: 2,
            restrictDecimals: true,
            min: 0,
            max: 32767,
            change: this.calcLineItemAmount
        });

        //disable the arrow keys
        input.unbind("keydown");
    }

    editDate(container, options) {

        //create the date editor
        var input = $('<input class="RequiredInput" data-bind="value:' + options.field + '" style="width: 100%;"/>');

        //add it to the container
        input.appendTo(container).kendoDatePicker();
    }

    editDescriptionMemo(container, options) {

        //create the date editor
        var input = $('<textarea class="RequiredInput" type="text" style="height: 80px; width: 100%; resize: none!important; white-space: pre-wrap;" data-bind="value:' + options.field + '"></></textarea>');

        //add it to the container
        input.appendTo(container)

        input.on('focus', (() => {
            setTimeout(() => {
                input.select();
            }, 0);
        }));
    }

    functionCodeEditor(container, options) {

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
            dataSource: this.functionCodes,
            open: this.adjustDropDownWidth,
            change: this.onFunctionCodeEditorChange,
            filtering: this.onFunctionCodeEditorFilter
        });
    }

    onFunctionCodeEditorFilter(e) {

        var listBox = e.sender.listView;

        if (e.filter.value != "") {

            e.preventDefault();

            e.sender.dataSource.filter({
                logic: "or",
                filters: [
                    { field: 'Code', operator: 'contains', value: e.filter.value },
                    { field: 'Description', operator: 'contains', value: e.filter.value }
                ]
            });

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
        else {

            e.preventDefault();

            e.sender.dataSource.filter({});

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
    }

    onFunctionCodeEditorChange(e) {
        
        var grid = e.sender.element.closest(".k-grid").data("kendoGrid");

        var row = e.sender.element.closest("tr");

        var dataItem = grid.dataItem(row);

        var data = grid.dataSource.getByUid(dataItem.uid);

        //set the billing rate
        data.set("Rate", e.sender.listView.selectedDataItems()[0].BillingRate);

        //is it billable?
        var isBillable = e.sender.listView.selectedDataItems()[0].NonBillableFlag == 0 ? false : true;

        //set the NonBillable flag
        data.set("NonBillable", isBillable);

        //Calc the item amount
        if (data.get("Rate") > 0) {

            data.set("Amount", data.get("Quantity") * data.get("Rate"))
        }
    }

    calcLineItemAmount(e) {      

        var grid = e.sender.element.closest(".k-grid").data("kendoGrid");

        var row = e.sender.element.closest("tr");

        var dataItem = grid.dataItem(row);

        var data = grid.dataSource.getByUid(dataItem.uid);

        //Calc the item amount
        if (data.get("Rate") > 0) {

            data.set("Amount", data.get("Quantity") * data.get("Rate"))
        }
    }

    clientEditor(container, options) {

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
            dataTextField: "Name",
            dataValueField: "Code",
            dataSource: {
                type: JSON,
                serverFiltering: false,
                ignoreCase: true,
                transport: {
                    read: "Employee/ExpenseReports/GetClients"
                }

            },
            open: this.adjustDropDownWidth,
            filtering: this.onClientEditorFilter
        });

        //get the input as a kendo dropdown list
        var myKendoDropdownList = input.data("kendoDropDownList");

        //automatically open
        myKendoDropdownList.open();


    }

    onClientEditorFilter(e) {

        var listBox = e.sender.listView;

        if (e.filter.value != "") {

            e.preventDefault();

            e.sender.dataSource.filter({
                logic: "or",
                filters: [
                    { field: 'Code', operator: 'contains', value: e.filter.value },
                    { field: 'Name', operator: 'contains', value: e.filter.value }
                ]
            });

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
        else {

            e.preventDefault();

            e.sender.dataSource.filter({});

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
    }


    jobEditor(container, options) {

        let me = this;

        //get the client code
        var clientCode = options.model.ClientCode;

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
            filter: "eq",
            //ignoreCase: true,
            dataTextField: "Description",
            dataValueField: "Number",
            dataSource: {
                type: JSON,
                serverFiltering: false,
                ignoreCase: true,
                transport: {
                    read: {
                        url: "Employee/ExpenseReports/GetJobs",
                        data: function () {
                            return { ClientCode: clientCode };
                        },
                        cache: false
                    }
                }
            },
            open: this.adjustDropDownWidth,
            filtering: this.onJobEditorFilter,
            change: this.onJobEditorChange
        });

        //get the input as a kendo dropdown list
        var myKendoDropdownList = input.data("kendoDropDownList");

        //automatically open
        myKendoDropdownList.open();

    }

    onJobEditorFilter(e) {

        var listBox = e.sender.listView;

        if (e.filter.value != "") {

            e.preventDefault();

            e.sender.dataSource.filter({
                logic: "or",
                filters: [
                    { field: 'Number', operator: 'eq', value: e.filter.value },
                    { field: 'Description', operator: 'contains', value: e.filter.value }
                ]
            });

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
        else {

            e.preventDefault();

            e.sender.dataSource.filter({});

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
    }

    onJobEditorChange(e) {

        var grid = e.sender.element.closest(".k-grid").data("kendoGrid");

        var row = e.sender.element.closest("tr");

        var dataItem = grid.dataItem(row);

        dataItem.DivisionCode = e.sender.listView.selectedDataItems()[0].DivisionCode;
        dataItem.ProductCode = e.sender.listView.selectedDataItems()[0].ProductCode;
        dataItem.JobComponentNumber = e.sender.listView.selectedDataItems()[0].JobComponentNumber;
    }


    paymentTypeEditor(container, options) {

        let me = this;

        //get the client code
        var clientCode = options.model.ClientCode;

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
            dataTextField: "text",
            dataValueField: "value",
            //optionLabel: "[Please Select]",
            dataSource: this.paymentTypes,
            open: this.adjustDropDownWidth,
            filtering: this.onPaymentTypeEditorFilter
        });

        //get the input as a kendo dropdown list
        var myKendoDropdownList = input.data("kendoDropDownList");

        //automatically open
        myKendoDropdownList.open();

    }

    onPaymentTypeEditorFilter(e) {

        var listBox = e.sender.listView;

        if (e.filter.value != "") {

            e.preventDefault();

            e.sender.dataSource.filter({
                logic: "or",
                filters: [
                    { field: 'Number', operator: 'eq', value: e.filter.value },
                    { field: 'Description', operator: 'contains', value: e.filter.value }
                ]
            });

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
        else {

            e.preventDefault();

            e.sender.dataSource.filter({});

            listBox.setDSFilter(e.sender.dataSource.filter());

        }
    }


    formatDate(value) {

        if (value != null) {
            return moment(value).toDate().toLocaleDateString();
        }
        else {
            return '';
        }
    }

    toggleAll(e) {

        if (this.selectAll === false) {
            this.grid.clearSelection();
        } else {
            this.grid.select("tr");
        };

        return true;
    }

    getNextLineNumber() {

        var maxLineNumber = 0

        var data = this.datasource.data();

        for (var i = 0; i < data.length; i++) {

            if (maxLineNumber < data[i].LineNumber) {

                maxLineNumber = data[i].LineNumber;

            }
        }

        return maxLineNumber + 1;

    }

    beforeEdit(e) {

        //if it is a new row
        if (e.model.LineNumber === 0) {

            //get the next row number
            e.model.LineNumber = this.getNextLineNumber();
        }

        //console.log(e);
    }

    copyRow(uid) {

        var dataItem = this.datasource.getByUid(uid);

        var newDataItem = EmployeeExpenseReport.ExpenseReportDetail;

        newDataItem.prototype.copyInto(dataItem);

        //Set the default values
        newDataItem.prototype.ID = 0;
        //newDataItem.prototype.ItemDate = newDataItem.prototype.getShortDate(new Date());
        newDataItem.prototype.ModifiedBy = null;
        newDataItem.prototype.ModifiedDate = null;
        newDataItem.prototype.CreatedBy = "";

        var tempJSON = JSON.stringify(newDataItem.prototype);

        tempJSON = JSON.parse(tempJSON);

        //fixes the date string
        (<any>tempJSON).ItemDate = newDataItem.prototype.getShortDate(new Date());

        //add the row
        var newRow = this.datasource.add(tempJSON);

        //set the object dirty
        newRow.dirty = true;

        //set dirty fields
        (<any>newRow).dirtyFields["ItemDate"] = true;
        (<any>newRow).dirtyFields["Description"] = true;
    }

    deleteSelectedRow() {
        console.log('In delete row.');

        //get the item from the datasource
        let items = this.grid.select();

        if (items.length > 0) {

            //make sure they want to delete
            this.confirm('Are you sure you want to delete the selected row(s)?').then(() => {

                for (var i = 0; i < items.length; i++) {

                    var item = this.grid.dataSource.getByUid(items[i].dataset.uid);

                    //if it is not a new item
                    if (item.isNew() == false) {

                        //capture the response
                        let success: boolean = false;

                        //delete the item
                        this.service.deleteExpenseReportDetails(item.id).then(response => {

                            //check the response
                            success = response.content;

                            if (success) {
                                //remove the item
                                console.log('delete sucess');

                                this.datasource.remove(item);
                                this.updateExpenseDetails();
                            }
                            else {
                                //let them know the delete failed
                                this.showNotification('Delete failed!');
                            }
                        });

                    }
                    else {

                        //if it has never been saved, just delete it from the datasource
                        this.datasource.remove(item);
                    }
                }

                //display the delete with the item code
                //this.alert('This item will be deleted after you click save.');

            }, () => {
                //let them know we cancelled the delete
                //this.alert('Delete cancelled');
            });
        }
        else {
            this.showNotification("No rows selected!", "error");
        }
    }

    calcExpenses() {

        this.totalExpenses = 0;
        this.lessCreditCard = 0;
        this.totalDue = 0;

        if (this.datasource) {

            for (var i = 0; i < this.datasource.data().length; i++) {

                this.totalExpenses += this.datasource.data()[i].Amount;

                if (this.datasource.data()[i].PaymentType === 0) {
                    this.lessCreditCard += this.datasource.data()[i].Amount;
                }

                this.totalDue = (this.totalExpenses - this.lessCreditCard);
            }
        }
    }

    addBookmark() {

        var employee = this.expenseReport.EmployeeCode;

        this.service.addInvoiceBookmark(this.employeeCode, this.expenseReport.InvoiceNumber, this.expenseReport.Description).then(response => {

            //capture the response
            let success: boolean = false;

            success = response.content;

            if (success) {
                this.showSuccessNotification("Created a new bookmark for " + this.expenseReport.EmployeeName);
            }
            else {
                this.showNotification("Failed to create bookmark!", "error");
            }
        });
    }

    attached() {

        let me = this;

        this.service.initExpenseEdit(this.id).then(response => {

            this.paymentTypes = response.content.PaymentTypes;
            this.functionCodes = response.content.Functions;

            window.setTimeout(function () {
                me.gridVM.recreate();
            }, 0);

        });

    }

    activate(params, routeConfig) {

        //this.id = Number(params.id);

        //if (params.EmpCode) {

        //    this.employeeCode = params.EmpCode;
            this.employeeCode = 'ama';

        //};

        //this.getExpenseReport();

       //console.log('activate:ExpenseEdit', params);
       //console.log('activate:ExpenseEdit', routeConfig);
    }

    constructor(router: Router, service: ExpenseReportsService) {
        super();
        this.router = router;
        this.service = service;
        let me = this;

        this.datasource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Employee/ExpenseReports/GetExpenseReportDetails'
                },
                update: {
                    url: 'Employee/ExpenseReports/UpdateExpenseReportDetails',
                    type: 'POST'
                },
                create: {
                    url: 'Employee/ExpenseReports/CreateExpenseReportDetails',
                    type: 'POST'
                },
                destroy: {
                    url: 'Employee/ExpenseReports/DeleteExpenseReportDetails',
                    type: 'POST'
                },
                parameterMap: function (data, type) {
                    if (type !== 'read') {
                        return {
                            ExpenseReportDetails: data.models
                        }
                    }
                    else {
                        return {
                            InvoiceNumber: me.id
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
                    id: "ID",
                    fields: {
                        ID: { type: "number" },
                        InvoiceNumber: {
                            type: "number",
                            defaultValue: me.id
                        },
                        LineNumber: { type: "number" },
                        ItemDate: { type: "Date" },
                        Description: {
                            type: "string",
                            validation: {
                                required: true,
                                minlength: 1,
                                DescriptionValidation: function (input) {

                                    if (input[0].value == "") {

                                        input.attr("data-AmountValidation-msg", "Amount is required!");
                                        return false;
                                    }
                                    else {
                                        return true;
                                    }
                                }
                            }
                        },
                        CreditCardFlag: { type: "boolean" },
                        ClientCode: { type: "string" },
                        DivisionCode: { type: "string" },
                        ProductCode: { type: "string" },
                        JobNumber: { type: "number" },
                        JobComponentNumber: { type: "number" },
                        FunctionCode: {
                            type: "string",
                            validation: {
                                required: true
                            }
                        },
                        Quantity: { type: "number" },
                        Rate: { type: "number" },
                        CreditCardAmount: { type: "number" },
                        Amount: {
                            type: "number",
                            validation: {
                                required: true,
                                AmountValidation: function (input) {

                                    if (parseFloat(input[0].value) === 0 || isNaN(parseFloat(input[0].value))) {

                                        input.attr("data-AmountValidation-msg", "Amount is required!");
                                        return false;
                                    }
                                    else {
                                        return true;
                                    }

                                }
                            }
                        },
                        APComment: { type: "string" },
                        CreatedBy: { type: "string" },
                        ModifiedBy: { type: "string" },
                        ModifiedDate: { type: "Date" },
                        PaymentType: { type: "number" },
                        IsImported: { type: "boolean" }
                    }

                },

            },
            pageSize: 10,
            change: function (e) {

                if (e.action === 'add') {

                    var datasource = me.grid.dataSource;
                    var filters = null;
                    var sorting = [{ field: "Description", dir: "asc" }, { field: "LineNumber", dir: "asc" } ];
                    
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

                me.calcExpenses();
            }

        });
    }

}
