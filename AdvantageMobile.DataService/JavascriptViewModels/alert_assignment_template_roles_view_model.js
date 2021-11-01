
(function() {
    AdvantageMobile_UI.AlertAssignmentTemplateRoleViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertAssignmentTemplateID = ko.observable();
				this.AlertAssignmentStateID = ko.observable();
				this.RoleCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentTemplateRoleViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			RoleCode: this.RoleCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.RoleCode(data.RoleCode);
		
            }
        }
    });
})();