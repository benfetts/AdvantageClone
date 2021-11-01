
(function() {
    AdvantageMobile_UI.EmployeeTimesheetFunctionViewModel = function(data) {
				this.EmployeeCode = ko.observable();
				this.FunctionCode = ko.observable();
				this.GroupCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.EmployeeTimesheetFunctionViewModel.prototype, {
        toJS: function() {
            return {
			EmployeeCode: this.EmployeeCode(),
			FunctionCode: this.FunctionCode(),
			GroupCode: this.GroupCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.EmployeeCode(data.EmployeeCode);
				this.FunctionCode(data.FunctionCode);
				this.GroupCode(data.GroupCode);
		
            }
        }
    });
})();