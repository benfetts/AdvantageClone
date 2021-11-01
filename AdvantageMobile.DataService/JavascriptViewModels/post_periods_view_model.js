
(function() {
    AdvantageMobile_UI.PostPeriodViewModel = function(data) {
				this.Period = ko.observable();
				this.ARMonth = ko.observable();
				this.ARYear = ko.observable();
				this.ARCurrentMonth = ko.observable();
				this.GLMonth = ko.observable();
				this.GLYear = ko.observable();
				this.GLCurrentMonth = ko.observable();
				this.APCurrentMonth = ko.observable();
				this.StartDate = ko.observable();
				this.EndDate = ko.observable();
				this.MonthName = ko.observable();
				this.UserCode = ko.observable();
				this.EnteredDate = ko.observable();
				this.ModifiedDate = ko.observable();
				this.Modified = ko.observable();
				this.ID = ko.observable();
				this.TECurrentMonth = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.PostPeriodViewModel.prototype, {
        toJS: function() {
            return {
			Period: this.Period(),
			ARMonth: this.ARMonth(),
			ARYear: this.ARYear(),
			ARCurrentMonth: this.ARCurrentMonth(),
			GLMonth: this.GLMonth(),
			GLYear: this.GLYear(),
			GLCurrentMonth: this.GLCurrentMonth(),
			APCurrentMonth: this.APCurrentMonth(),
			StartDate: this.StartDate(),
			EndDate: this.EndDate(),
			MonthName: this.MonthName(),
			UserCode: this.UserCode(),
			EnteredDate: this.EnteredDate(),
			ModifiedDate: this.ModifiedDate(),
			Modified: this.Modified(),
			ID: this.ID(),
			TECurrentMonth: this.TECurrentMonth(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.Period(data.Period);
				this.ARMonth(data.ARMonth);
				this.ARYear(data.ARYear);
				this.ARCurrentMonth(data.ARCurrentMonth);
				this.GLMonth(data.GLMonth);
				this.GLYear(data.GLYear);
				this.GLCurrentMonth(data.GLCurrentMonth);
				this.APCurrentMonth(data.APCurrentMonth);
				this.StartDate(data.StartDate);
				this.EndDate(data.EndDate);
				this.MonthName(data.MonthName);
				this.UserCode(data.UserCode);
				this.EnteredDate(data.EnteredDate);
				this.ModifiedDate(data.ModifiedDate);
				this.Modified(data.Modified);
				this.ID(data.ID);
				this.TECurrentMonth(data.TECurrentMonth);
		
            }
        }
    });
})();