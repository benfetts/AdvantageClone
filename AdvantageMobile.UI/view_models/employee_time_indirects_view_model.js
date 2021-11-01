
(function() {
    AdvantageMobile_UI.EmployeeTimeIndirectViewModel = function(data) {
				this.EmployeeTimeID = ko.observable();
				this.ID = ko.observable();
				this.SequenceNumber = ko.observable();
				this.Category = ko.observable();
				this.Hourse = ko.observable();
				this.CostRate = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.Comment = ko.observable();
				this.DateEntered = ko.observable();
				this.UserCode = ko.observable();
				this.TotalCost = ko.observable();
				this.EditFlag = ko.observable();
				this.Notes = ko.observable();
				this.AlternateCostRate = ko.observable();
				this.AlternateCostAmount = ko.observable();
				this.StartTime = ko.observable();
				this.EndTime = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimeIndirectViewModel.prototype, {
        toJS: function() {
            return {
			EmployeeTimeID: this.EmployeeTimeID(),
			ID: this.ID(),
			SequenceNumber: this.SequenceNumber(),
			Category: this.Category(),
			Hourse: this.Hourse(),
			CostRate: String(this.CostRate() || 0),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			Comment: this.Comment(),
			DateEntered: this.DateEntered(),
			UserCode: this.UserCode(),
			TotalCost: String(this.TotalCost() || 0),
			EditFlag: this.EditFlag(),
			Notes: this.Notes(),
			AlternateCostRate: String(this.AlternateCostRate() || 0),
			AlternateCostAmount: String(this.AlternateCostAmount() || 0),
			StartTime: this.StartTime(),
			EndTime: this.EndTime(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmployeeTimeID(data.EmployeeTimeID);
				this.ID(data.ID);
				this.SequenceNumber(data.SequenceNumber);
				this.Category(data.Category);
				this.Hourse(data.Hourse);
				this.CostRate(data.CostRate);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.Comment(data.Comment);
				this.DateEntered(data.DateEntered);
				this.UserCode(data.UserCode);
				this.TotalCost(data.TotalCost);
				this.EditFlag(data.EditFlag);
				this.Notes(data.Notes);
				this.AlternateCostRate(data.AlternateCostRate);
				this.AlternateCostAmount(data.AlternateCostAmount);
				this.StartTime(data.StartTime);
				this.EndTime(data.EndTime);
		
            }
        }
    });
})();