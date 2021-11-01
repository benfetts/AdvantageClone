
(function() {
    AdvantageMobile_UI.TimeEntryViewModel = function(data) {
        this.EmployeeTimeID = ko.observable();
        this.EmployeeTimeDetailID = ko.observable();
        this.FunctionCategory = ko.observable();
        this.FunctionCategoryDescription = ko.observable();
        this.EmployeeHours = ko.observable();
        this.ClientCode = ko.observable();
        this.DivisionCode = ko.observable();
        this.ProductCode = ko.observable();
        this.JobNumber = ko.observable();
        this.ClientRef = ko.observable();
        this.JobComponentNumber = ko.observable();
        this.DepartmentTeamCode = ko.observable();
        this.TimeType = ko.observable();
        this.EditFlag = ko.observable();
        this.MaxSequenceNumber = ko.observable();
        this.StartTime = ko.observable();
        this.EndTime = ko.observable();
        this.EmployeeDate = ko.observable();
        this.Comments = ko.observable();
        this.JobDescription = ko.observable();
        this.JobComponentDescription = ko.observable();
        this.ProductCategoryCode = ko.observable();
        this.ClientName = ko.observable();
        this.DivisionName = ko.observable();
        this.ProductDescription = ko.observable();
        this.ProcessControl = ko.observable();
        this.NonEditMessage = ko.observable();
        this.CannotEditDueToProcessControl = ko.observable();
        this.HasStopwatch = ko.observable();
        this.StopwatchEmployeeTimeID = ko.observable();
        this.StopwatchEmployeeTimeDetailID = ko.observable();
        this.CommentIsRequired = ko.observable();
        this.IsDenied = ko.observable();
        this.IsApproved = ko.observable();
        this.IsPendingApproval = ko.observable();
        this.IsPostPeriodClosed = ko.observable();
        this.CreateDate = ko.observable();
        this.ClientCommentIsRequired = ko.observable();
        this.TimesheetIsMissingComments = ko.observable();
        if(data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.TimeEntryViewModel.prototype, {
        toJS: function() {
            return {
                EmployeeTimeID: this.EmployeeTimeID(),
                EmployeeTimeDetailID: this.EmployeeTimeDetailID(),
                FunctionCategory: this.FunctionCategory(),
                FunctionCategoryDescription: this.FunctionCategoryDescription(),
                EmployeeHours: this.EmployeeHours(),
                ClientCode: this.ClientCode(),
                DivisionCode: this.DivisionCode(),
                ProductCode: this.ProductCode(),
                JobNumber: this.JobNumber(),
                ClientRef: this.ClientRef(),
                JobComponentNumber: this.JobComponentNumber(),
                DepartmentTeamCode: this.DepartmentTeamCode(),
                TimeType: this.TimeType(),
                EditFlag: this.EditFlag(),
                MaxSequenceNumber: this.MaxSequenceNumber(),
                StartTime: this.StartTime(),
                EndTime: this.EndTime(),
                EmployeeDate: this.EmployeeDate(),
                Comments: this.Comments(),
                JobDescription: this.JobDescription(),
                JobComponentDescription: this.JobComponentDescription(),
                ProductCategoryCode: this.ProductCategoryCode(),
                ClientName: this.ClientName(),
                DivisionName: this.DivisionName(),
                ProductDescription: this.ProductDescription(),
                ProcessControl: this.ProcessControl(),
                NonEditMessage: this.NonEditMessage(),
                CannotEditDueToProcessControl: this.CannotEditDueToProcessControl(),
                HasStopwatch: this.HasStopwatch(),
                StopwatchEmployeeTimeID: this.StopwatchEmployeeTimeID(),
                StopwatchEmployeeTimeDetailID: this.StopwatchEmployeeTimeDetailID(),
                CommentIsRequired: this.CommentIsRequired(),
                IsDenied: this.IsDenied(),
                IsApproved: this.IsApproved(),
                IsPendingApproval: this.IsPendingApproval(),
                IsPostPeriodClosed: this.IsPostPeriodClosed(),
                CreateDate: this.CreateDate(),
                ClientCommentIsRequired: this.ClientCommentIsRequired(),
                TimesheetIsMissingComments: this.TimesheetIsMissingComments(),
            };
        },

        fromJS: function(data) {
            if(data) {
                this.EmployeeTimeID(data.EmployeeTimeID);
                this.EmployeeTimeDetailID(data.EmployeeTimeDetailID);
                this.FunctionCategory(data.FunctionCategory);
                this.FunctionCategoryDescription(data.FunctionCategoryDescription);
                this.EmployeeHours(data.EmployeeHours);
                this.ClientCode(data.ClientCode);
                this.DivisionCode(data.DivisionCode);
                this.ProductCode(data.ProductCode);
                this.JobNumber(data.JobNumber);
                this.ClientRef(data.ClientRef);
                this.JobComponentNumber(data.JobComponentNumber);
                this.DepartmentTeamCode(data.DepartmentTeamCode);
                this.TimeType(data.TimeType);
                this.EditFlag(data.EditFlag);
                this.MaxSequenceNumber(data.MaxSequenceNumber);
                this.StartTime(data.StartTime);
                this.EndTime(data.EndTime);
                this.EmployeeDate(data.EmployeeDate);
                this.Comments(data.Comments);
                this.JobDescription(data.JobDescription);
                this.JobComponentDescription(data.JobComponentDescription);
                this.ProductCategoryCode(data.ProductCategoryCode);
                this.ClientName(data.ClientName);
                this.DivisionName(data.DivisionName);
                this.ProductDescription(data.ProductDescription);
                this.ProcessControl(data.ProcessControl);
                this.NonEditMessage(data.NonEditMessage);
                this.CannotEditDueToProcessControl(data.CannotEditDueToProcessControl);
                this.HasStopwatch(data.HasStopwatch);
                this.StopwatchEmployeeTimeID(data.StopwatchEmployeeTimeID);
                this.StopwatchEmployeeTimeDetailID(data.StopwatchEmployeeTimeDetailID);
                this.CommentIsRequired(data.CommentIsRequired);
                this.IsDenied(data.IsDenied);
                this.IsApproved(data.IsApproved);
                this.IsPendingApproval(data.IsPendingApproval);
                this.IsPostPeriodClosed(data.IsPostPeriodClosed);
                this.CreateDate(data.CreateDate);
                this.ClientCommentIsRequired(data.ClientCommentIsRequired);
                this.TimesheetIsMissingComments(data.TimesheetIsMissingComments);
		
            }
        }
    });
})();