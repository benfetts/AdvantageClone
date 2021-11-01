
(function () {
    AdvantageMobile_UI.EmployeeTimeTemplateViewModel = function (data) {
        this.ID = ko.observable();
        this.EmployeeCode = ko.observable();
        this.JobNumber = ko.observable();
        this.JobComponentNumber = ko.observable();
        this.FunctionCode = ko.observable();
        this.DefaultComment = ko.observable();
        this.DepartmentTeamCode = ko.observable();
        this.ProductCategoryCode = ko.observable();
        this.EmployeeHours = ko.observable();
        this.ApplyToDays = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimeTemplateViewModel.prototype, {
        toJS: function () {
            return {
                ID: this.ID(),
                EmployeeCode: this.EmployeeCode(),
                JobNumber: this.JobNumber(),
                JobComponentNumber: this.JobComponentNumber(),
                FunctionCode: this.FunctionCode(),
                DefaultComment: this.DefaultComment(),
                DepartmentTeamCode: this.DepartmentTeamCode(),
                ProductCategoryCode: this.ProductCategoryCode(),
                EmployeeHours: String(this.EmployeeHours() || 0),
                ApplyToDays: this.ApplyToDays(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.ID(data.ID);
                this.EmployeeCode(data.EmployeeCode);
                this.JobNumber(data.JobNumber);
                this.JobComponentNumber(data.JobComponentNumber);
                this.FunctionCode(data.FunctionCode);
                this.DefaultComment(data.DefaultComment);
                this.DepartmentTeamCode(data.DepartmentTeamCode);
                this.ProductCategoryCode(data.ProductCategoryCode);
                this.EmployeeHours(data.EmployeeHours);
                this.ApplyToDays(data.ApplyToDays);

            }
        }
    });
})();