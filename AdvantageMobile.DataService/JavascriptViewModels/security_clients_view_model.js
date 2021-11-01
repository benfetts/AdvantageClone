
(function() {
    AdvantageMobile_UI.SecurityClientViewModel = function(data) {
				this.UserCode = ko.observable();
				this.ClientCode = ko.observable();
				this.DivisionCode = ko.observable();
				this.ProductCode = ko.observable();
				this.IsTimeEntry = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SecurityClientViewModel.prototype, {
        toJS: function() {
            return {
			UserCode: this.UserCode(),
			ClientCode: this.ClientCode(),
			DivisionCode: this.DivisionCode(),
			ProductCode: this.ProductCode(),
			IsTimeEntry: this.IsTimeEntry(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.UserCode(data.UserCode);
				this.ClientCode(data.ClientCode);
				this.DivisionCode(data.DivisionCode);
				this.ProductCode(data.ProductCode);
				this.IsTimeEntry(data.IsTimeEntry);
		
            }
        }
    });
})();