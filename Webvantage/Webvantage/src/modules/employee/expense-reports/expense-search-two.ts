import { UserSettingService } from 'services/utilities/user-settings-service';
import { ModuleBase } from 'modules/base/module-base';
import { customElement } from 'aurelia-framework'
import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-http-client';
import { Router } from 'aurelia-router';
import { Webvantage } from '../../../webvantage';

@inject(Router, UserSettingService, 'openModule', Webvantage)
export class SearchPageTwo extends ModuleBase {

    router: Router;
    service: UserSettingService;
    openModule;
    
    webvantage: Webvantage;

    clientMultiSelect: kendo.ui.MultiSelect;
    clientDataSource: kendo.data.DataSource;
    clientCode = [];
    jobMultiSelect: kendo.ui.MultiSelect;
    jobDataSource: kendo.data.DataSource;
    jobCode = [];

    employeeMultiSelect: kendo.ui.MultiSelect;
    employeeDataSource: kendo.data.DataSource;
    employeeCode = [];
    empcode: string = '';

    functionMultiSelect: kendo.ui.MultiSelect;
    functionDataSource: kendo.data.DataSource;
    functionCode = [];

    fromDatePicker: kendo.ui.DatePicker;
    toDatePicker: kendo.ui.DatePicker;

    data: kendo.data.DataSource;
    grid: kendo.ui.Grid;

    descriptionSearch: string = ''

    showOpen: boolean = true;
    showPending: boolean = true;
    showDenied: boolean = true;
    showApproved: boolean = false;
    showTerminatedEmp: boolean = false;

    excludePaid: boolean = false;
    excludeUnpaid: boolean = false;

    isEmployeeVendor: boolean = false;

    StartDate: Date = null;
    EndDate: Date = null;
    ItemDate: Date = null;

    pageSize: number = 15;
    totalpages: number;

    search() {
        
        this.grid.dataSource.pageSize(this.pageSize)
        this.grid.dataSource.read();
    }

    clearSearch() {
        this.clientCode = [];
        this.jobCode = [];
        this.setJobDataSource();
        this.showOpen = true;
        this.showPending = true;
        this.showDenied = true;
        this.showApproved = false;
        this.functionCode = [];
        this.StartDate = null;
        this.EndDate = null;
        this.ItemDate = null;
        this.descriptionSearch = '';
        this.excludePaid = false;
        this.excludeUnpaid = false;


        this.GetUser();

        this.data.data([]);
    }   

    onChange() {
        
        this.search();
    }

    showDetailView(InvoiceNumber) {
        //return "Expense_Edit_v2.aspx?invoice=" + InvoiceNumber;
        return "Employee/ExpenseReports/NewExpenseReport?invoice=" + InvoiceNumber + "&empcode=" + this.employeeCode;
    }

    getTitle(InvoiceNumber: string, Description: string) {
        return 'EX ' + InvoiceNumber + ' - ' + Description;
    }

    ExpensePaidDetail(InvoiceNumber) {
        this.openModule("Expense Detail", "Expense_Paid_detail.aspx?Inv=" + InvoiceNumber + "&Emp=" + this.employeeCode[0],1061,834);
    }

    bookmark() {
        let client = new HttpClient();
        let me = this;

        var clientCode = '',
            jobNumber = 0,
            startDate = null,
            endDate = null,
            itemDate = null,
            functionCode = '',
            description = '';

        if (me.clientCode && me.clientCode.length > 0) {
            clientCode = me.clientCode[0];
        }
        if (me.jobCode && me.jobCode.length > 0) {
            jobNumber = me.jobCode[0];
        }
        if (me.StartDate != null) {
            startDate = me.StartDate;
        }
        if (me.EndDate != null) {
            endDate = me.EndDate;
        }
        if (me.ItemDate != null) {
            itemDate = me.ItemDate;
        }
        if (me.functionCode && me.functionCode.length > 0) {
            functionCode = me.functionCode[0];
        }
        if (me.descriptionSearch && me.descriptionSearch.length > 0) {
            description = me.descriptionSearch;
        }

        var data = {
            Employee: "",
            FromDate: startDate,
            ToDate: endDate,
            Client: clientCode,
            JobNumber: jobNumber > 0 ? jobNumber : null,
            FunctionCode: functionCode,
            Description: description,
            ItemDate: itemDate
        };

        client.post('ExpenseReports/BookMarkPage', data)
            .then(data => {
                console.log(data.statusCode + ' - ' + data.statusText);
            });
    }

    showTerminatedEmpChange() {
        let me = this;

        me.setEmployeeDataSource();

        me.employeeDataSource.read().then(function () {
            me.GetUser();
        });
    }

    excludePaidChange() {

    }

    excludeUnPaidChange() {

    }

    setClientDataSource() {
        let me = this;
        this.clientDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchClients',
                    data: function () {
                        var officeCode = '';

                        return {
                            OfficeCode: officeCode
                        }
                    }
                }
            },
            schema: {
                data: "Clients",
                total: "Total",
            }
        });
        if (this.clientMultiSelect) {
            this.clientMultiSelect.setDataSource(this.clientDataSource);
        }
    }

    clientMultiSelect_OnChange(e) {
        this.jobCode = [];
        this.setJobDataSource();
        this.data.data([]);
    }

    setFunctionDataSource() {
        let me = this;
        this.functionDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchVenderFunctions'
                }
            }
        });
        if (this.functionMultiSelect) {
            this.functionMultiSelect.setDataSource(this.functionDataSource);
        }
    }

    functionMultiSelect_OnChange(e) {
        this.data.data([]);
    }

    setJobDataSource() {
        let me = this;
        this.jobDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Utilities/SearchJob',
                    data: function () {
                        var clientCode = '',
                            divisionCode = '',
                            productCode = '',
                            officeCode = '',
                            AccountExecutive = '';

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        return {
                            OfficeCode: officeCode,
                            ClientCode: clientCode,
                            DivisionCode: divisionCode,
                            ProductCode: productCode,
                            AccountExecutive: AccountExecutive,
                            ShowClosedJobs: 0
                        }
                    }
                }
            },
            schema: {
                 data: "Jobs",
                total: "Total",
            }
        });
        if (this.jobMultiSelect) {
            this.jobMultiSelect.setDataSource(this.jobDataSource);
        }
    }

    jobMultiSelect_OnChange(e) {
        this.data.data([]);
    }

    setEmployeeDataSource() {
        //console.log('something goes here');
        let me = this;
        this.employeeDataSource = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'ExpenseReports/SearchExpenseEmployees',
                    data: function () {
                        return {
                            ShowTerminatedEmployees: me.showTerminatedEmp
                        };
                    }
                }
            }
        });
        if (this.employeeMultiSelect) {
            this.employeeMultiSelect.setDataSource(this.employeeDataSource);
        }
    }

    employeeMultiSelect_OnChange(e) {
        this.search();
    }

    getPageSize(): number {

        var pageSizegrid: number;

        this.service.getPageSize("ExpenseSearchGrid").then(response => {

            this.pageSize = response.content
            return response.content;
        });

        return pageSizegrid;
    }

    GetUser() {
        let client = new HttpClient();
        let me = this;              

        client.get('Utilities/GetLoggedInUser')
            .then(function (data){
                console.log(data.content);                
                me.employeeCode = [];
                me.employeeCode[0] = data.content.Code;
                me.employeeMultiSelect.refresh();
                me.empcode = data.content.Code;
                me.GetIsEmployeeVendor();
                              
            });
    }

    GetIsEmployeeVendor() {
        let client = new HttpClient();
        let me = this;

        this.service.getIsEmployeeVendor(this.employeeCode[0]).then(response => {

            me.isEmployeeVendor = response.content;

            if (me.isEmployeeVendor === false) {
                me.employeeCode = [];
            }
            
        });   
    }

    GetExpenseSecurity() {
        let client = new HttpClient();

        client.get('Employee/ExpenseReports/GetExpenseReportSecurity')
            .then(function (data) {
                console.log(data.content);
                this.CanAdd = data.content;
            });
    }

    attached() {
        let me = this;

        me.employeeDataSource.read().then(function () {
            me.GetUser();
        });        

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

    activate(params: any) {

        //console.log("activate " + params.Parameters.indexOf('c'));

        this.webvantage.currentPage = this;

        if (params.Parameters != undefined) {
            if (params.Parameters['emp'] != undefined) {
                this.employeeCode[0] = params.Parameters['emp'];
            }
            if (params.Parameters['c'] != undefined) {
                this.clientCode[0] = params.Parameters['c'];
            }
            if (params.Parameters['j'] != undefined) {
                this.jobCode[0] = params.Parameters['j'];
            }
            if (params.Parameters['fromdate'] != undefined) {
                this.StartDate = new Date(params.Parameters['fromdate'].replace(/%2f/g,'/'));
            }
            if (params.Parameters['todate'] != undefined) {
                this.EndDate = new Date(params.Parameters['todate'].replace(/%2f/g, '/'));
            }
            if (params.Parameters['itemdate'] != undefined) {
                this.ItemDate = new Date(params.Parameters['itemdate'].replace(/%2f/g, '/'));
            }
            if (params.Parameters['desc'] != undefined) {
                this.descriptionSearch = params.Parameters['desc'];
            }
            if (params.Parameters['fn'] != undefined) {
                this.functionCode = params.Parameters['fn'];
            }
        }

    }

    newExpenseReport() {

        //this.openModule("New Expense Report", "Expense_Edit_V2.aspx?invoice=new&empcode=" + this.employeeCode);
        if (this.employeeCode.length > 0) {
            this.service.getIsEmployeeVendor(this.employeeCode[0]).then(response => {

                this.isEmployeeVendor = response.content;

                if (this.isEmployeeVendor === false) {
                    this.showNotification("This employee code is not associated with a vendor code.")
                } else {
                    this.openModule("New Expense Report", "Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" + this.employeeCode);
                }

            });
       } else if (this.empcode !== '') {
            this.service.getIsEmployeeVendor(this.empcode).then(response => {

                this.isEmployeeVendor = response.content;

                if (this.isEmployeeVendor === false) {
                    this.showNotification("This employee code is not associated with a vendor code.")
                } else {
                    this.openModule("New Expense Report", "Employee/ExpenseReports/NewExpenseReport?invoice=new&empcode=" + this.empcode);
                }

            });
        }
        //var employee = this.employees.get(this.employeeCode);

        //if (employee.get("TerminationDate") != null) {
        //    this.showNotification("You cannot add a new expense report for a terminated employee.")
        //}
        //else {
          //  this.router.navigateToRoute("edit", { id: 0, EmpCode: this.employeeCode });
        //}

    }

    getStatusTitle(Status: string, ApprovedBy: string, ApprovedDate: Date) {
        var StatusTitle: string = Status;

        //if (Status == 'Approved' && ApprovedBy && ApprovedDate) {
        //    StatusTitle += " By " + ApprovedBy + " on " + ApprovedDate.toLocaleDateString();
        //}

        return StatusTitle;
    }

    constructor(router: Router, service: UserSettingService, openModule, webvantage: Webvantage) {
        super();
        let me = this;
        this.service = service;
        this.router = router;
        this.openModule = openModule;
        this.webvantage = webvantage;

        this.CanAdd('Employee/ExpenseReports/GetExpenseReportSecurity');

        this.getPageSize();
        this.data = new kendo.data.DataSource({
            transport: {
                read: {
                    url: 'Employee/ExpenseReports/GetExpenseReports',
                    data: function () {

                        var clientCode = '',
                            jobCode = 0,
                            projectManagerCode = '',
                            employeeCode = '',
                            functionCode = '',
                            startDate = null,
                            endDate = null,
                            itemDate = null,
                            descriptionSearch = '';

                        if (me.clientCode && me.clientCode.length > 0) {
                            clientCode = me.clientCode[0];
                        }

                        if (me.jobCode && me.jobCode.length > 0) {
                            jobCode = me.jobCode[0];
                        }

                        if (me.employeeCode && me.employeeCode.length > 0) {
                            employeeCode = me.employeeCode[0];
                        }

                        if (me.functionCode && me.functionCode.length > 0) {
                            functionCode = me.functionCode[0];
                        }

                        if (me.StartDate) {
                            startDate = me.StartDate.toDateString();
                        }

                        if (me.EndDate) {
                            endDate = me.EndDate.toDateString();
                        }

                        if (me.ItemDate) {
                            itemDate = me.ItemDate.toDateString();
                        }

                        if (me.descriptionSearch && me.descriptionSearch.length > 0) {
                            descriptionSearch = me.descriptionSearch;
                        }

                        return {
                            ClientCode: clientCode,
                            JobCode: jobCode,
                            EmployeeCode: employeeCode,
                            FunctionCode: functionCode,
                            ShowOpen: me.showOpen,
                            ShowPending: me.showPending,
                            ShowDenied: me.showDenied,
                            ShowApproved: me.showApproved,
                            StartDate: startDate,
                            EndDate: endDate,
                            ItemDate: itemDate,
                            DescriptionSearch: descriptionSearch,
                            ExcludePaid: me.excludePaid,
                            ExcludeUnpaid: me.excludeUnpaid,
                        }
                    }
                }
            },
            pageSize: this.pageSize,
            schema: {
                model: {
                    id: 'InvoiceNumber',
                    fields: {
                        InvoiceNumber: { type: 'number' },
                        ReportDate: { type: 'date' },
                        CreatedDate: { type: 'date' },
                        Description: { type: 'string' },
                        Status: { type: 'string' },
                        TotalAmount: { type: 'money' },
                        TotalBillable: { type: 'money' },
                        TotalNonBillable: { type: 'money' },
                        Paid: { type: 'boolean' },
                        ApprovedBy: { type: 'string' },
                        ApprovedDate: { type: 'date' },
                        HasDocuments: { type: 'boolean' },
                        AttachmentCount: {type: 'number'}
                    }
                }
            }
        });

        me.setClientDataSource();
        me.setJobDataSource();
        me.setEmployeeDataSource();

        me.setFunctionDataSource();
        //me.GetExpenseSecurity();
    }

    gridOnDataBound(e) {

        var items = e.sender.items();
        items.each(function (i) {
            var dataItem = e.sender.dataItem(this);

            this.className += "wv-row-" + dataItem.StatusCode;
        });

        var PageSize = this.grid.dataSource.pageSize();
        this.totalpages = this.grid.pager.totalPages();
        this.grid.pager.options.messages.display = "{2} items in " + this.totalpages + " pages";
        //console.log("onDB1:" + PageSize);
        //console.log("onDB2:" + this.pageSize);
        if (typeof PageSize === 'undefined') {
            PageSize = this.grid.dataSource.total();
        }
        if (this.pageSize != PageSize) {
            this.service.updatePageSize(PageSize, "ExpenseSearchGrid");
            this.pageSize = PageSize;
        }
    }
}
