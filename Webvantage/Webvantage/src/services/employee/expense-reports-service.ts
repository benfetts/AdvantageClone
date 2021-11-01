import { ServiceBase } from 'services/base/service-base';
import { EmployeeExpenseReport } from 'models/employee/expense-report';

export class ExpenseReportsService extends ServiceBase {

    getExpenseReports(code, month, year) {
        return this.http.get('GetExpenseReports', { Code: code, Month: month, Year: year })
            .then(response => {
                var expenseReports: Array<EmployeeExpenseReport.ExpenseReport> = new Array<EmployeeExpenseReport.ExpenseReport>();
                var expenseReport: EmployeeExpenseReport.ExpenseReport;
                if (response.content.length > 0) {
                    for (var i = 0; i < response.content.length; i++) {
                        expenseReport = new EmployeeExpenseReport.ExpenseReport;
                        Object.assign(expenseReport, response.content[i]);
                        expenseReports.push(expenseReport);
                    }
                }
                return expenseReports;
            });
    }

    getExpenseReport(invoiceNumber) {
        return this.http.get('GetExpenseReport', { InvoiceNumber: invoiceNumber })
            .then(response => {
                var expenseReport: EmployeeExpenseReport.ExpenseReport;
                if (response.content) {
                    expenseReport = new EmployeeExpenseReport.ExpenseReport;
                    Object.assign(expenseReport, response.content);
                }
                return expenseReport;
            });
    }

    getExpenseReportDetails(invoiceNumber) {
        return this.http.get('GetExpenseReportDetails', { InvoiceNumber: invoiceNumber })
            .then(response => {
                var expenseDetails: Array<EmployeeExpenseReport.ExpenseReportDetail> = new Array<EmployeeExpenseReport.ExpenseReportDetail>();
                var expenseDetail: EmployeeExpenseReport.ExpenseReportDetail;
                if (response.content.length > 0) {
                    for (var i = 0; i < response.content.length; i++) {
                        expenseDetail = new EmployeeExpenseReport.ExpenseReportDetail;
                        Object.assign(expenseDetail, response.content[i]);
                        expenseDetails.push(expenseDetail);
                    }
                }
                return expenseDetails;
            });
    }

    getExpenseReportDetail(id) {
        return this.http.get('GetExpenseReportDetail', { ID: id })
            .then(response => {
                var expenseDetail: EmployeeExpenseReport.ExpenseReportDetail;
                if (response.content) {
                        expenseDetail = new EmployeeExpenseReport.ExpenseReportDetail;
                        Object.assign(expenseDetail, response.content);   
                }
                return expenseDetail;
            });
    } GetEmployeeDefault
    
    getEmployee(code) {
        return this.http.get('GetEmployee', { Code: code });
    }

    getEmployeeDefault() {
        return this.http.get('GetEmployeeDefault');
    }

    getEmployees() {
        return this.http.get('GetEmployees');
    }

    getPaymenTypes() {
        return this.http.get('GetPaymenTypes');
    }

    initExpenseEdit(invoiceNumber: number) {
        return this.http.get('InitExpenseEdit', { InvoiceNumber: invoiceNumber});
    }

    getFunctionCodes() {
        return this.http.get('GetFunctionCodes');
    }

    addBookmark(code, month, year) {
        return this.http.get('AddBookmark', { Code: code, Month: month, Year: year });
    }

    addInvoiceBookmark(code, invoiceNumber, description) {
        return this.http.get('AddInvoiceBookmark', { Code: code, InvoiceNumber: invoiceNumber, Description: description });
    }

    createExpenseReport(expenseReports: any) {
        return this.http.post('CreateExpenseReports', { ExpenseReports: [expenseReports] })
            .then(response => {

                var expenseReports: Array<EmployeeExpenseReport.ExpenseReport> = new Array<EmployeeExpenseReport.ExpenseReport>();
                var item: EmployeeExpenseReport.ExpenseReport;

                if (response.content.length > 0) {
                    for (var i = 0; i < response.content.length; i++) {
                        item = new EmployeeExpenseReport.ExpenseReport;
                        Object.assign(item, response.content[i]);
                        expenseReports.push(item);
                    }
                }

                return expenseReports;
            });
    }

    updateExpenseReport(expenseReports: any) {
        return this.http.post('UpdateExpenseReports', { ExpenseReports: [expenseReports] });
    }

    deleteExpenseReportDetails(expenseReportDetails: any) {
        return this.http.post('DeleteExpenseReportDetails', { ExpenseReportDetails: [expenseReportDetails] });
    }

    constructor() {
        super({ baseUrl: "Employee/ExpenseReports" });
    }

}
