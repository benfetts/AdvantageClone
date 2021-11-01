
(function () {
    AdvantageMobile_UI.SaveTimeEntryResultViewModel = function (data) {
        this.FullText = ko.observable();
        this.Message = ko.observable();
        this.EmployeeTimeID = ko.observable();
        this.EmployeeTimeDetailID = ko.observable();
        this.EmployeeHours = ko.observable();
        this.BillingRate = ko.observable();
        this.NoBillFlag = ko.observable();
        this.ErrorCode = ko.observable();
        this.WarningMessage = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.SaveTimeEntryResultViewModel.prototype, {
        toJS: function () {
            return {
                FullText: this.FullText(),
                Message: this.Message(),
                EmployeeTimeID: this.EmployeeTimeID(),
                EmployeeTimeDetailID: this.EmployeeTimeDetailID(),
                EmployeeHours: this.EmployeeHours(),
                BillingRate: this.BillingRate(),
                NoBillFlag: this.NoBillFlag(),
                ErrorCode: this.ErrorCode(),
                WarningMessage: this.WarningMessage(),

            };
        },

        fromJS: function (data) {
            if (data) {
                this.FullText(data.FullText);
                this.Message(data.Message);
                this.EmployeeTimeID(data.EmployeeTimeID);
                this.EmployeeTimeDetailID(data.EmployeeTimeDetailID);
                this.EmployeeHours(data.EmployeeHours);
                this.BillingRate(data.BillingRate);
                this.NoBillFlag(data.NoBillFlag);
                this.ErrorCode(data.ErrorCode);
                this.WarningMessage(data.WarningMessage);

            }
        }
    });
})();