
(function() {
    AdvantageMobile_UI.AlertAssignmentTemplateStateViewModel = function(data) {
				this.AlertAssignmentTemplateID = ko.observable();
				this.AlertAssignmentStateID = ko.observable();
				this.SortOrder = ko.observable();
				this.DefaultEmployeeCode = ko.observable();
				this.IsDefault = ko.observable();
				this.IsCompleted = ko.observable();
				this.EmployeeLookupType = ko.observable();
				this.DefaultRoleCode = ko.observable();
				this.DefaultDepartmentTeamCode = ko.observable();
				this.DefaultAlertGroupCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentTemplateStateViewModel.prototype, {
        toJS: function() {
            return {
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			SortOrder: this.SortOrder(),
			DefaultEmployeeCode: this.DefaultEmployeeCode(),
			IsDefault: this.IsDefault(),
			IsCompleted: this.IsCompleted(),
			EmployeeLookupType: this.EmployeeLookupType(),
			DefaultRoleCode: this.DefaultRoleCode(),
			DefaultDepartmentTeamCode: this.DefaultDepartmentTeamCode(),
			DefaultAlertGroupCode: this.DefaultAlertGroupCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.SortOrder(data.SortOrder);
				this.DefaultEmployeeCode(data.DefaultEmployeeCode);
				this.IsDefault(data.IsDefault);
				this.IsCompleted(data.IsCompleted);
				this.EmployeeLookupType(data.EmployeeLookupType);
				this.DefaultRoleCode(data.DefaultRoleCode);
				this.DefaultDepartmentTeamCode(data.DefaultDepartmentTeamCode);
				this.DefaultAlertGroupCode(data.DefaultAlertGroupCode);
		
            }
        }
    });
})();