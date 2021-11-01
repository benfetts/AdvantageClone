
(function() {
    AdvantageMobile_UI.AlertAssignmentEmailGroupViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertAssignmentTemplateID = ko.observable();
				this.AlertAssignmentStateID = ko.observable();
				this.EmailGroupCode = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentEmailGroupViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			EmailGroupCode: this.EmailGroupCode(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.EmailGroupCode(data.EmailGroupCode);
		
            }
        }
    });
})();