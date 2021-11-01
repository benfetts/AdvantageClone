
(function() {
    AdvantageMobile_UI.AlertAssignmentTemplateEmployeeViewModel = function(data) {
				this.AlertAssignmentStateID = ko.observable();
				this.AlertAssignmentTemplateID = ko.observable();
				this.EmployeeCode = ko.observable();
				this.IS_DFLT = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentTemplateEmployeeViewModel.prototype, {
        toJS: function() {
            return {
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			EmployeeCode: this.EmployeeCode(),
			IS_DFLT: this.IS_DFLT(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.EmployeeCode(data.EmployeeCode);
				this.IS_DFLT(data.IS_DFLT);
		
            }
        }
    });
})();