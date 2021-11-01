
(function() {
    AdvantageMobile_UI.AlertTypeViewModel = function(data) {
				this.ID = ko.observable();
				this.Description = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertTypeViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Description: this.Description(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Description(data.Description);
		
            }
        }
    });
})();