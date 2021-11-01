
(function () {
    AdvantageMobile_UI.ProjectViewpointViewModel = function (data) {
        this.ClientCode = ko.observable();
        this.DivisionCode = ko.observable();
        this.ProductCode = ko.observable();
        this.JobNumber = ko.observable();
        this.JobDescription = ko.observable();
        this.JobComponentNumber = ko.observable();
        this.JobComponentDescription = ko.observable();
        this.EmployeeCode = ko.observable();
        this.JobComponentJobCompDate = ko.observable();
        this.JobProcessControl = ko.observable();
        this.ProcessDate = ko.observable();
        this.StartDate = ko.observable();
        this.CompletedDate = ko.observable();
        this.ClientDivisionProductCodes = ko.observable();
        this.JobAndComp = ko.observable();
        this.AccountExecutiveFullName = ko.observable();
        this.Status = ko.observable();
        this.JobComponentStartDate = ko.observable();
        this.OpenAssignments = ko.observable();
        this.OpenTasks = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ProjectViewpointViewModel.prototype, {
        toJS: function () {
            return {
                ClientCode: this.ClientCode(),
                DivisionCode: this.DivisionCode(),
                ProductCode: this.ProductCode(),
                JobNumber: this.JobNumber(),
                JobDescription: this.JobDescription(),
                JobComponentNumber: this.JobComponentNumber(),
                JobComponentDescription: this.JobComponentDescription(),
                EmployeeCode: this.EmployeeCode(),
                JobComponentJobCompDate: this.JobComponentJobCompDate(),
                JobProcessControl: this.JobProcessControl(),
                ProcessDate: this.ProcessDate(),
                StartDate: this.StartDate(),
                CompletedDate: this.CompletedDate(),
                ClientDivisionProductCodes: this.ClientDivisionProductCodes(),
                JobAndComp: this.JobAndComp(),
                AccountExecutiveFullName: this.AccountExecutiveFullName(),
                Status: this.Status(),
                JobComponentStartDate: this.JobComponentStartDate(),
                OpenAssignments: this.OpenAssignments(),
                OpenTasks: this.OpenTasks(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.ClientCode(data.ClientCode);
                this.DivisionCode(data.DivisionCode);
                this.ProductCode(data.ProductCode);
                this.JobNumber(data.JobNumber);
                this.JobDescription(data.JobDescription);
                this.JobComponentNumber(data.JobComponentNumber);
                this.JobComponentDescription(data.JobComponentDescription);
                this.EmployeeCode(data.EmployeeCode);
                this.JobComponentJobCompDate(data.JobComponentJobCompDate);
                this.JobProcessControl(data.JobProcessControl);
                this.ProcessDate(data.ProcessDate);
                this.StartDate(data.StartDate);
                this.CompletedDate(data.CompletedDate);
                this.ClientDivisionProductCodes(data.ClientDivisionProductCodes);
                this.JobAndComp(data.JobAndComp);
                this.AccountExecutiveFullName(data.AccountExecutiveFullName);
                this.Status(data.Status);
                this.JobComponentStartDate(data.JobComponentStartDate);
                this.OpenAssignments(data.OpenAssignments);
                this.OpenTasks(data.OpenTasks);

            }
        }
    });
})();