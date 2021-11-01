
(function () {
    AdvantageMobile_UI.TimeTemplatesViewModel = function (data) {
        this.ID = ko.observable();
        this.EmployeeCode = ko.observable();
        this.EmployeeFirstName = ko.observable();
        this.EmployeeMiddleInitial = ko.observable();
        this.EmployeeLastName = ko.observable();
        this.JobNumber = ko.observable();
        this.JobDescription = ko.observable();
        this.JobComponentNumber = ko.observable();
        this.JobComponentDescription = ko.observable();
        this.FunctionCode = ko.observable();
        this.TimeCategoryCode = ko.observable();
        this.IsIndirectTime = ko.observable();
        this.FunctionDescription = ko.observable();
        this.DefaultComment = ko.observable();
        this.JobAndComponent = ko.observable();
        this.DepartmentTeamCode = ko.observable();
        this.ProductCategoryCode = ko.observable();
        this.EmployeeHours = ko.observable();
        this.ApplyToDays = ko.observable();
        this.ClientCode = ko.observable();
        this.DivisionCode = ko.observable();
        this.ProductCode = ko.observable();
        this.ClientName = ko.observable();
        this.DivisionName = ko.observable();
        this.ProductName = ko.observable();
        this.JOB = ko.observable();
        this.JobComponentProcessControl = ko.observable();
        this.JobComponentIsClosed = ko.observable();
        this.HasAccessToFunction = ko.observable();

        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.TimeTemplatesViewModel.prototype, {
        toJS: function () {
            return {
                ID: this.ID(),
                EmployeeCode: this.EmployeeCode(),
                EmployeeFirstName: this.EmployeeFirstName(),
                EmployeeMiddleInitial: this.EmployeeMiddleInitial(),
                EmployeeLastName: this.EmployeeLastName(),
                JobNumber: this.JobNumber(),
                JobDescription: this.JobDescription(),
                JobComponentNumber: this.JobComponentNumber(),
                JobComponentDescription: this.JobComponentDescription(),
                FunctionCode: this.FunctionCode(),
                TimeCategoryCode: this.TimeCategoryCode(),
                IsIndirectTime: this.IsIndirectTime(),
                FunctionDescription: this.FunctionDescription(),
                DefaultComment: this.DefaultComment(),
                JobAndComponent: this.JobAndComponent(),
                DepartmentTeamCode: this.DepartmentTeamCode(),
                ProductCategoryCode: this.ProductCategoryCode(),
                EmployeeHours: this.EmployeeHours(),
                ApplyToDays: this.ApplyToDays(),
                ClientCode: this.ClientCode(),
                DivisionCode: this.DivisionCode(),
                ProductCode: this.ProductCode(),
                ClientName: this.ClientName(),
                DivisionName: this.DivisionName(),
                ProductName: this.ProductName(),
                JOB: this.JOB(),
                JobComponentProcessControl: this.JobComponentProcessControl(),
                JobComponentIsClosed: this.JobComponentIsClosed(),
                HasAccessToFunction: this.HasAccessToFunction(),

            };
        },

        fromJS: function (data) {
            if (data) {
                this.ID(data.ID);
                this.EmployeeCode(data.EmployeeCode);
                this.EmployeeFirstName(data.EmployeeFirstName);
                this.EmployeeMiddleInitial(data.EmployeeMiddleInitial);
                this.EmployeeLastName(data.EmployeeLastName);
                this.JobNumber(data.JobNumber);
                this.JobDescription(data.JobDescription);
                this.JobComponentNumber(data.JobComponentNumber);
                this.JobComponentDescription(data.JobComponentDescription);
                this.FunctionCode(data.FunctionCode);
                this.TimeCategoryCode(data.TimeCategoryCode);
                this.IsIndirectTime(data.IsIndirectTime);
                this.FunctionDescription(data.FunctionDescription);
                this.DefaultComment(data.DefaultComment);
                this.JobAndComponent(data.JobAndComponent);
                this.DepartmentTeamCode(data.DepartmentTeamCode);
                this.ProductCategoryCode(data.ProductCategoryCode);
                this.EmployeeHours(data.EmployeeHours);
                this.ApplyToDays(data.ApplyToDays);
                this.ClientCode(data.ClientCode);
                this.DivisionCode(data.DivisionCode);
                this.ProductCode(data.ProductCode);
                this.ClientName(data.ClientName);
                this.DivisionName(data.DivisionName);
                this.ProductName(data.ProductName);
                this.JOB(data.JOB);
                this.JobComponentProcessControl(data.JobComponentProcessControl);
                this.JobComponentIsClosed(data.JobComponentIsClosed);
                this.HasAccessToFunction(data.HasAccessToFunction);

            }
        }
    });
})();