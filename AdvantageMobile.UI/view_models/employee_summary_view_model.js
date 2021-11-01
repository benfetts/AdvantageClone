
(function () {
    AdvantageMobile_UI.EmployeeSummaryViewModel = function (data) {
        this.AlertCount = ko.observable();
        this.AssignmentCount = ko.observable();
        this.DefaultFunctionCode = ko.observable();
        this.DepartmentTeamCode = ko.observable();
        this.EmployeeCode = ko.observable();
        this.FirstName = ko.observable();
        this.FullName = ko.observable();
        this.Image = ko.observable();
        this.ImageFileType = ko.observable();
        this.LastName = ko.observable();
        this.MiddleInitial = ko.observable();
        this.StandardHoursForToday = ko.observable();
        this.TaskCount = ko.observable();
        this.ExpenseCount = ko.observable();
        this.TimesheetHoursForToday = ko.observable();
        this.UserCode = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeSummaryViewModel.prototype, {
        toJS: function () {
            return {
                AlertCount: this.AlertCount(),
                AssignmentCount: this.AssignmentCount(),
                DefaultFunctionCode: this.DefaultFunctionCode(),
                DepartmentTeamCode: this.DepartmentTeamCode(),
                EmployeeCode: this.EmployeeCode(),
                FirstName: this.FirstName(),
                FullName: this.FullName(),
                Image: this.Image(),
                ImageFileType: this.ImageFileType(),
                LastName: this.LastName(),
                MiddleInitial: this.MiddleInitial(),
                StandardHoursForToday: this.StandardHoursForToday(),
                TaskCount: this.TaskCount(),
                ExpenseCount: this.ExpenseCount(),
                TimesheetHoursForToday: this.TimesheetHoursForToday(),
                UserCode: this.UserCode(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.AlertCount(data.AlertCount);
                this.AssignmentCount(data.AssignmentCount);
                this.DefaultFunctionCode(data.DefaultFunctionCode);
                this.DepartmentTeamCode(data.DepartmentTeamCode);
                this.EmployeeCode(data.EmployeeCode);
                this.FirstName(data.FirstName);
                this.FullName(data.FullName);
                this.Image(data.Image);
                this.ImageFileType(data.ImageFileType);
                this.LastName(data.LastName);
                this.MiddleInitial(data.MiddleInitial);
                this.StandardHoursForToday(data.StandardHoursForToday);
                this.TaskCount(data.TaskCount);
                this.ExpenseCount(data.ExpenseCount);
                this.TimesheetHoursForToday(data.TimesheetHoursForToday);
                this.UserCode(data.UserCode);
            }
        }
    });
})();