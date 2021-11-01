
(function () {
    AdvantageMobile_UI.MyTaskViewModel = function (data) {
        this.ClientDivisionProductCodes = ko.observable();
        this.JobData = ko.observable();
        this.TaskDescription = ko.observable();
        this.FunctionComments = ko.observable();
        this.StartDate = ko.observable();
        this.DueDate = ko.observable();
        this.DueTime = ko.observable();
        this.JobNumber = ko.observable();
        this.JobComponentNumber = ko.observable();
        this.HoursAllowed = ko.observable();
        this.SequenceNumber = ko.observable();
        this.TempCompleteDate = ko.observable();
        this.EmployeeCode = ko.observable();
        this.IsEvent = ko.observable();
        this.EventTaskID = ko.observable();
        this.TaskStatus = ko.observable();
        this.JobDescription = ko.observable();
        this.JobComponentDescription = ko.observable();
        this.JobNumberAndComponentNumber = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.MyTaskViewModel.prototype, {
        toJS: function () {
            return {
                ClientDivisionProductCodes: this.ClientDivisionProductCodes(),
                JobData: this.JobData(),
                TaskDescription: this.TaskDescription(),
                FunctionComments: this.FunctionComments(),
                StartDate: this.StartDate(),
                DueDate: this.DueDate(),
                DueTime: this.DueTime(),
                JobNumber: this.JobNumber(),
                JobComponentNumber: this.JobComponentNumber(),
                HoursAllowed: this.HoursAllowed(),
                SequenceNumber: this.SequenceNumber(),
                TempCompleteDate: this.TempCompleteDate(),
                EmployeeCode: this.EmployeeCode(),
                IsEvent: this.IsEvent(),
                EventTaskID: this.EventTaskID(),
                TaskStatus: this.TaskStatus(),
                JobDescription: this.JobDescription(),
                JobComponentDescription: this.JobComponentDescription(),
                JobNumberAndComponentNumber: this.JobNumberAndComponentNumber(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.ClientDivisionProductCodes(data.ClientDivisionProductCodes);
                this.JobData(data.JobData);
                this.TaskDescription(data.TaskDescription);
                this.FunctionComments(data.FunctionComments);
                this.StartDate(data.StartDate);
                this.DueDate(data.DueDate);
                this.DueTime(data.DueTime);
                this.JobNumber(data.JobNumber);
                this.JobComponentNumber(data.JobComponentNumber);
                this.HoursAllowed(data.HoursAllowed);
                this.SequenceNumber(data.SequenceNumber);
                this.TempCompleteDate(data.TempCompleteDate);
                this.EmployeeCode(data.EmployeeCode);
                this.IsEvent(data.IsEvent);
                this.EventTaskID(data.EventTaskID);
                this.TaskStatus(data.TaskStatus);
                this.JobDescription(data.JobDescription);
                this.JobComponentDescription(data.JobComponentDescription);
                this.JobNumberAndComponentNumber(data.JobNumberAndComponentNumber);

            }
        }
    });
})();