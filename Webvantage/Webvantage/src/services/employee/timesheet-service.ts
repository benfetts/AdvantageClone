import { ServiceBase } from 'services/base/service-base';
import { EmployeeTimesheet } from 'models/employee/employee-timesheet';

export class TimesheetService extends ServiceBase {

    getTimesheetDashboard() {
        return this.http.get('GetTimesheetDashboard');
    }
    getMonthlyHours() {
        return this.http.get('GetMonthlyHours');
    }
    getTimeSummary() {
        return this.http.get('GetTimeSummary');
    }
    checkIfPostPeriodIsAvailable(entryDate: Date) {
        var data = {
            EntryDate: entryDate.toISOString()
        };
        return this.http.get('CheckIfPostPeriodIsAvailable', data);
    }
    saveHoursToAlert(alertID: number, entryDate: Date, functionCode: string, hours: number, comment: string) {
        var data = {
            AlertID: alertID,
            EntryDate: entryDate,
            FunctionCode: functionCode,
            Hours: hours * 1,
            Comment: comment
        };
        return this.http.post('SaveHoursToAlert', data);
    }
    getFunctionsAndCategories(employeeCode: string, functions: boolean, categories: boolean) {
        return this.http.get('GetFunctionsAndCategories', { EmployeeCode: employeeCode, Functions: functions, Categories: categories });
    }
    getTimesheetRows(employeeCode: string, startDate: Date) {
        return this.http.get('GetTimesheetRows', { EmployeeCode: employeeCode, StartDate: startDate.toLocaleDateString() });
    }
    saveTimesheetRows(employeeCode: string, records: Array<EmployeeTimesheet.Row>) {
        return this.http.post('SaveTimesheetRows', { EmployeeCode: employeeCode, Records: records });
    }
    saveTimesheetUserSettings(settings: EmployeeTimesheet.Settings) {
        return this.http.post('SaveTimesheetUserSettings', { Settings: settings });
    }
    initTimesheetEntry(employeeTimeId: number, employeeTimeDetailId: number) {

    }
    initAddTimesheetRow(employeeCode: string) {
        return this.http.post('InitAddTimesheetRow', { EmployeeCode: employeeCode });
    }
    //initTimesheet(employeeCode: string, start: Date) {
    //    return this.http.get('InitTimesheet', { EmployeeCode: employeeCode, Start: start });
    //}
    initTimesheet(employeeCode: string) {
        return this.http.get('InitTimesheet', { EmployeeCode: employeeCode });
    }
    constructor() {
        super({ baseUrl: "Employee/Timesheet" });
    }
}
