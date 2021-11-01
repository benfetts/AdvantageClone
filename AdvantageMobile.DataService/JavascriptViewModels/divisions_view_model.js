
(function() {
    AdvantageMobile_UI.DivisionViewModel = function(data) {
				this.ClientCode = ko.observable();
				this.Code = ko.observable();
				this.Name = ko.observable();
				this.DIV_ATTENTION = ko.observable();
				this.BAddress1 = ko.observable();
				this.BAddress2 = ko.observable();
				this.BCity = ko.observable();
				this.BCounty = ko.observable();
				this.BState = ko.observable();
				this.BCountry = ko.observable();
				this.BZip = ko.observable();
				this.SAddress1 = ko.observable();
				this.SAddress2 = ko.observable();
				this.SCity = ko.observable();
				this.SCounty = ko.observable();
				this.SState = ko.observable();
				this.SCountry = ko.observable();
				this.SZip = ko.observable();
				this.DIV_ALPHA_SORT = ko.observable();
				this.IsActive = ko.observable();
				this.BATCH_NAME = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.DivisionViewModel.prototype, {
        toJS: function() {
            return {
			ClientCode: this.ClientCode(),
			Code: this.Code(),
			Name: this.Name(),
			DIV_ATTENTION: this.DIV_ATTENTION(),
			BAddress1: this.BAddress1(),
			BAddress2: this.BAddress2(),
			BCity: this.BCity(),
			BCounty: this.BCounty(),
			BState: this.BState(),
			BCountry: this.BCountry(),
			BZip: this.BZip(),
			SAddress1: this.SAddress1(),
			SAddress2: this.SAddress2(),
			SCity: this.SCity(),
			SCounty: this.SCounty(),
			SState: this.SState(),
			SCountry: this.SCountry(),
			SZip: this.SZip(),
			DIV_ALPHA_SORT: this.DIV_ALPHA_SORT(),
			IsActive: this.IsActive(),
			BATCH_NAME: this.BATCH_NAME(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ClientCode(data.ClientCode);
				this.Code(data.Code);
				this.Name(data.Name);
				this.DIV_ATTENTION(data.DIV_ATTENTION);
				this.BAddress1(data.BAddress1);
				this.BAddress2(data.BAddress2);
				this.BCity(data.BCity);
				this.BCounty(data.BCounty);
				this.BState(data.BState);
				this.BCountry(data.BCountry);
				this.BZip(data.BZip);
				this.SAddress1(data.SAddress1);
				this.SAddress2(data.SAddress2);
				this.SCity(data.SCity);
				this.SCounty(data.SCounty);
				this.SState(data.SState);
				this.SCountry(data.SCountry);
				this.SZip(data.SZip);
				this.DIV_ALPHA_SORT(data.DIV_ALPHA_SORT);
				this.IsActive(data.IsActive);
				this.BATCH_NAME(data.BATCH_NAME);
		
            }
        }
    });
})();