
(function() {
    AdvantageMobile_UI.EmployeeTimeViewModel = function(data) {
				this.ID = ko.observable();
				this.EmployeeCode = ko.observable();
				this.Date = ko.observable();
				this.PostPeriodCode = ko.observable();
				this.IsArchived = ko.observable();
				this.Freelance = ko.observable();
				this.OfficeCode = ko.observable();
				this.ApprovalUserCode = ko.observable();
				this.ApprovalDate = ko.observable();
				this.IsPendingApproval = ko.observable();
				this.IsApproved = ko.observable();
				this.ApprovalNotes = ko.observable();
				this.TotalDirectHours = ko.observable();
				this.TotalIndirectHours = ko.observable();
				this.TotalHours = ko.observable();
				this.AlertID = ko.observable();
				this.StopwatchStartTime = ko.observable();
				this.StopwatchEmployeeTimeDetailID = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimeViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			EmployeeCode: this.EmployeeCode(),
			Date: this.Date(),
			PostPeriodCode: this.PostPeriodCode(),
			IsArchived: this.IsArchived(),
			Freelance: this.Freelance(),
			OfficeCode: this.OfficeCode(),
			ApprovalUserCode: this.ApprovalUserCode(),
			ApprovalDate: this.ApprovalDate(),
			IsPendingApproval: this.IsPendingApproval(),
			IsApproved: this.IsApproved(),
			ApprovalNotes: this.ApprovalNotes(),
			TotalDirectHours: String(this.TotalDirectHours() || 0),
			TotalIndirectHours: String(this.TotalIndirectHours() || 0),
			TotalHours: String(this.TotalHours() || 0),
			AlertID: this.AlertID(),
			StopwatchStartTime: this.StopwatchStartTime(),
			StopwatchEmployeeTimeDetailID: this.StopwatchEmployeeTimeDetailID(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.EmployeeCode(data.EmployeeCode);
				this.Date(data.Date);
				this.PostPeriodCode(data.PostPeriodCode);
				this.IsArchived(data.IsArchived);
				this.Freelance(data.Freelance);
				this.OfficeCode(data.OfficeCode);
				this.ApprovalUserCode(data.ApprovalUserCode);
				this.ApprovalDate(data.ApprovalDate);
				this.IsPendingApproval(data.IsPendingApproval);
				this.IsApproved(data.IsApproved);
				this.ApprovalNotes(data.ApprovalNotes);
				this.TotalDirectHours(data.TotalDirectHours);
				this.TotalIndirectHours(data.TotalIndirectHours);
				this.TotalHours(data.TotalHours);
				this.AlertID(data.AlertID);
				this.StopwatchStartTime(data.StopwatchStartTime);
				this.StopwatchEmployeeTimeDetailID(data.StopwatchEmployeeTimeDetailID);
		
            }
        }
    });
})();