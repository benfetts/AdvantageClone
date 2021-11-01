
(function() {
    AdvantageMobile_UI.SecurityLicenseViewModel = function(data) {
				this.ID = ko.observable();
				this.Type = ko.observable();
				this.Key = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SecurityLicenseViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			Type: this.Type(),
			Key: this.Key(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.Type(data.Type);
				this.Key(data.Key);
		
            }
        }
    });
})();