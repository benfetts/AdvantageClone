
(function() {
    AdvantageMobile_UI.EmployeeDepartmentTeamViewModel = function(data) {
				this.EmployeeCode = ko.observable();
				this.DepartmentTeamCode = ko.observable();
				this.Description = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeDepartmentTeamViewModel.prototype, {
        toJS: function() {
            return {
			EmployeeCode: this.EmployeeCode(),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			Description: this.Description(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmployeeCode(data.EmployeeCode);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
				this.Description(data.Description);
		
            }
        }
    });
})();