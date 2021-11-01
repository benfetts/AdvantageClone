
(function() {
    AdvantageMobile_UI.AlertAssignmentTemplateViewModel = function(data) {
				this.ID = ko.observable();
				this.Name = ko.observable();
				this.IsActive = ko.observable();
				this.IS_DIGITAL_ASSET = ko.observable();
				this.AUTO_NXT_STATE = ko.observable();
				this.TYPE = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertAssignmentTemplateViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Name: this.Name(),
			IsActive: this.IsActive(),
			IS_DIGITAL_ASSET: this.IS_DIGITAL_ASSET(),
			AUTO_NXT_STATE: this.AUTO_NXT_STATE(),
			TYPE: this.TYPE(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Name(data.Name);
				this.IsActive(data.IsActive);
				this.IS_DIGITAL_ASSET(data.IS_DIGITAL_ASSET);
				this.AUTO_NXT_STATE(data.AUTO_NXT_STATE);
				this.TYPE(data.TYPE);
		
            }
        }
    });
})();