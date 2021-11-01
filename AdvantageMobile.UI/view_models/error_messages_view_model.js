
(function () {
    AdvantageMobile_UI.ErrorMessageViewModel = function (data) {
        this.Code = ko.observable();
        this.Message = ko.observable();
        if (data)
            this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.ErrorMessageViewModel.prototype, {
        toJS: function () {
            return {
                Code: this.Code(),
                Message: this.Message(),
            };
        },

        fromJS: function (data) {
            if (data) {
                this.Code(data.Code);
                this.Message(data.Message);
            }
        }
    });
})();