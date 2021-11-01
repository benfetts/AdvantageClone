
(function() {
    AdvantageMobile_UI.TimeCategoryTypeViewModel = function(data) {
				this.ID = ko.observable();
				this.Description = ko.observable();
				this.Use = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.TimeCategoryTypeViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Description: this.Description(),
			Use: this.Use(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Description(data.Description);
				this.Use(data.Use);
		
            }
        }
    });
})();