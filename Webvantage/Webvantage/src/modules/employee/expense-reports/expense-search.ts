import { ModuleBase } from 'modules/base/module-base';
import { Router } from 'aurelia-router';
import { inject } from 'aurelia-framework';
import { ExpenseReportsService } from 'services/employee/expense-reports-service';
import * as moment from 'moment';

@inject(Router, ExpenseReportsService)
export class ExpenseSearch extends ModuleBase {

    router: Router;
    service: ExpenseReportsService;
    datasource: kendo.data.DataSource;
    employees: kendo.data.DataSource;
    ddlemployee: kendo.ui.DropDownList;
    monthPicker: kendo.ui.DatePicker;
    grid: kendo.ui.Grid;
    employee: any;
    employeeCode: string;
    employeeName: string;
    employeeTerminationDate: any;
    years: Array<any>;
    selectedDate: Date;
    
    //ExpenseReports: Array<any>;

    getYears() {

        this.years = new Array();

        var year = new Date().getFullYear();

        for (var x = (year - 5); x < (year + 6); x++) {

            this.years.push({ value: x });
        }
    }

    setDate() {

        this.selectedDate = new Date();

    }

    setEmployeeCode() {

        this.service.getEmployeeDefault().then(Response => {
            this.employeeCode = Response.content;
            console.log('empcode:response', Response.content);
        })

    }

    monthPickerOnChange() {

        this.selectedDate = this.monthPicker.value();
        this.search();

    }

    getEmployees() {

        //get all of the employee codes
        this.service.getEmployees().then(response => {            
            this.employees = new kendo.data.DataSource({
                data: response.content,
                schema: {
                    model: {
                        id: 'Code'
                    }
                }
            });
            
            //console.log('getFunctionCodes:response', response);
        });

        
    }

    newExpenseReport() {

        var employee = this.employees.get(this.employeeCode);

        if (employee.get("TerminationDate") != null) {
            this.showNotification("You cannot add a new expense report for a terminated employee.")
        }
        else {
            this.router.navigateToRoute("edit", { id: 0, EmpCode: this.employeeCode });
        }

    }

    addBookmark() {

        var employee = this.employees.get(this.employeeCode);

        this.service.addBookmark(this.employeeCode, this.selectedDate.getMonth() + 1, this.selectedDate.getFullYear()).then(response => {

            //capture the response
            let success: boolean = false;

            success = response.content;

            if (success) {
                this.showSuccessNotification("Created a new bookmark for " + employee.get("Name"));
            }
            else {
                this.showNotification("Failed to create bookmark!", "error");
            }
        });
    }

    search() {
        let terminationDate = null,
            name = null;
        let employee: any = this.employees.get(this.employeeCode);

        if (employee) {
            terminationDate = employee.TerminationDate;
            name = employee.Name;
        }
        this.employeeTerminationDate = terminationDate;
        this.employeeName = name;

        this.grid.dataSource.read();
    }

    adjustDropDownWidth(e) {

        var listContainer = e.sender.list.closest(".k-list-container");

        listContainer.width(listContainer.width() + kendo.support.scrollbar() + 20);
    }

    editExpenseReport(ExpenseReport: any) {
        this.router.navigateToRoute('edit', { id: ExpenseReport.InvoiceNumber });
    }

    activate(params: any) {
        //this.tempData();

        if (params.EmployeeCode) {

            this.employeeCode = params.EmployeeCode;
            this.search();
        };
    }

    attached() {

        

    }

    constructor(router: Router, service: ExpenseReportsService) {
        super();
        this.router = router;
        this.service = service;
        let me = this;

        this.datasource = new kendo.data.DataSource({
            transport: {
                read: { url: 'Employee/ExpenseReports/GetExpenseReports' },
                parameterMap: function (data, type) {
                    if (type = 'read') {
                        return {
                            Code: me.employeeCode,
                            Month: me.selectedDate.getMonth() + 1,
                            Year: me.selectedDate.getFullYear()
                        };
                    }
                }
            },
            pageSize: 10,
            schema: {
                model: {
                    id: 'InvoiceNumber',
                    fields: {
                        InvoiceNumber: { type: 'number' },
                        ReportDate: { type: 'date' },
                        CreatedDate: { type: 'date' },
                        Description: { type: 'string' },
                        Status: { type: 'string' },
                        TotalNonBillable: { type: 'money' },
                        TotalBillable: { type: 'money' },
                        TotalAmount: { type: 'money' },
                        Paid: { type: 'boolean' }
                    }
                }
            }

        });

        this.getYears();
        this.setDate();
        this.getEmployees();
        this.setEmployeeCode();
    }

}
