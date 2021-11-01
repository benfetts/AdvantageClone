
(function() {
    AdvantageMobile_UI.AlertAssignmentTemplateDepartmentTeamViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertAssignmentTemplateID = ko.observable();
				this.AlertAssignmentStateID = ko.observable();
				this.DepartmentTeamCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentTemplateDepartmentTeamViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			DepartmentTeamCode: this.DepartmentTeamCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.DepartmentTeamCode(data.DepartmentTeamCode);
		
            }
        }
    });
})();