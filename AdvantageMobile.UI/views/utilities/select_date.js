AdvantageMobile_UI.select_date = function (params) {
    /*
        params.settings.source = 0, my schedule, schedule_list
        params.settings.source = 1, timesheet day list, time_list
        params.settings.source = 2, timesheet entry, time_entry

    */
    var source = 0;
    var selectedDate = new Date();

    var calendar = {
        min: new Date(1974, 1, 1),
        max: new Date(2099, 12, 31),
        firstDayOfWeek: 0,
        onValueChanged: function (e) {
            selectedDate = e.value;
            setDate();
        },
        value: ko.observable(new Date()),
    };
    var datePicker = {
        min: new Date(1974, 1, 1),
        max: new Date(2099, 12, 31),
        onValueChanged: function (e) {
            selectedDate = e.value;
            setDate();
        },
        value: ko.observable(new Date()),
    };
    function viewShowing() {
        source = params.settings.source;
    };
    function viewShown(e) {
        firstLoad = false;
    };
    function viewDisposing() {

    };
    function setDate() {
        if (firstLoad == false) {
            switch (source) {
                case 0:
                    AdvantageMobile_UI.app.navigate({
                        view: "schedule_list",
                        settings: { date: selectedDate }
                    });
                    break;
                case 1:
                    AdvantageMobile_UI.app.navigate({
                        view: "time_list",
                        settings: { date: selectedDate }
                    });
                    break;
                case 2:
                    var newDate = new Date(selectedDate);
                    if (newDate) {
                        AdvantageMobile_UI.db.get('CopyTimeEntry', {
                            EmployeeTimeID: params.settings.et_id,
                            EmployeeTimeDetailID: params.settings.et_dtl_id,
                            EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                            Date: newDate.toShortDateString()
                        }).done(function (data) {
                            var SaveTimeEntryResult = new AdvantageMobile_UI.SaveTimeEntryResultViewModel(data);
                            if (SaveTimeEntryResult.EmployeeTimeID() > 0 && SaveTimeEntryResult.EmployeeTimeDetailID() > 0) {
                                AdvantageMobile_UI.Messages.toastSuccess();
                                AdvantageMobile_UI.app.navigate({
                                    view: "time_entry",
                                    settings: { source: 3, employeeTimeId: SaveTimeEntryResult.EmployeeTimeID(), employeeTimeDetailId: SaveTimeEntryResult.EmployeeTimeDetailID(), timeType: params.settings.time_type }
                                }, { target: "current" });

                            } else {
                                AdvantageMobile_UI.Messages.toastError(localizeString('Save Failed') + ":  " + SaveTimeEntryResult.Message());
                            }
                        }).fail(function (data) {
                            handleDataServiceError(data);
                        });
                    }
                    break;
            };
        };
    };
    var viewModel = {
        viewShowing: viewShowing,
        viewShown: viewShown,
        viewDisposing: viewDisposing,
        calendar: calendar,
        datePicker: datePicker,
    };
    return viewModel;
};