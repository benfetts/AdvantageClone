AdvantageMobile_UI.home = function (params, viewInfo) {

    var loadPanelVisible = ko.observable(false);
    var loadPanelMessage = localizeString('Loading');
    var totalHoursToday = ko.observable(0.0);
    var todayDate = ko.observable(new Date);
    var emptyUser = "iVBORw0KGgoAAAANSUhEUgAAAIAAAACACAYAAADDPmHLAAAFFElEQVR42u2dTWxUVRiGpymQsgAtQemGFTGYNBrd2rqzCa6MLohxQRRCIpR1N27c2MYFSpG4UONSZFPjikgg0Q0lMalVEUNtIIHIRqFJ0ymYtP34Ts4XgTBD75zO3/3O8yTvZjoz99z7vp1zz++tVAAAAAAAAAAAnCAiu1X7VeOqKdWM6paqqlo1Ve21GXvPuH1mN1ewfIb3qIZVn6rmZOPM2XeF7+zhCnev8f2qMdW8tI55O0Y/V7y7jJ9QLUr7WLRjEoQOGt+rGlXdls5x28rQiyPtNX+valq6h1CWvTjTHvMPqJak+whlOoBDrf3Jn5TuZ5Iqofnm96m+k/IQytqHc80z/6yUj7OEoDk/+1NSXqaoDjYWgEkpP5M4mX637wVaBwnt/CVHAViin6Cxen9a/DHN/UCxAIyKX0Zx+Mnm7+hw3347xg524HT9AEyIfyZwurb5/W0e0u0Uiwwj1w7AmOTDGI4/an5Pi2fydBvzTC97NADDkh/DOP8gACcyDMAJnH8QgLkMAzCH85X/5+3nCusOJC7AyJX9BCCuwsmVcQJQ7gkfG54wQgDierxcmSEAcVFmrtwiAHFlbq5UCUBcnp0rqwSAAFAFUAVwE8hNIM1AmoF0BNERRFcwXcEMBjEYxHAww8G5hYAJIZkHgClhmQeASaGZB4Bp4YSAhSG5B4ClYYSAxaG5B4Dl4YSADSJyDwBbxBACNokiBGwTB8JGkdwPCFvFZh8CNosmBGwXTwh4YAQ81DrgkTH0E/DQKKoEHhsHwoMj4aEg8OjYDIx+Q/XcE/7ekYdHhzKFsuFQ64zfqvrCTLmn+lj1dIHPtfTx8aEMVpZ7VrZQxq041lzzB1W/1/jvvKP6ULWzA2Xaace+U6NcoayDONecC31Y1t9DYFn1tWqolbNtrXoZsmMtr1OmUObDOJh+sbervk2os6+rPlGNNOOn2KqeEbsPuJ5QnnAO23G0sYv+UpNu4P5TXVJ9bu31fVadPGvjCz2mPntt0N4zap+5ZN+xUf5SvYyzxcx/t8DPaxkJ5/QeDtc3fpPqswymhZ9Sbcbxx+v7HyQfzqmewvlofqh7f5H8mFXtyt38Xaorki9/qgZyNT/0oP0q8FuRHk1v5vdaPQiR8+EmOKcAfITnjzGRi/lDkvf+wPUI1+TVHNr6l/G6Lldc9xHoyb2Px+ty1Kv5m1U38Hddbqq2eAzA23hbmHc8BuA8vhbmgscevxV8bahFMOApAAfxtGEOeQrAN/jZMKc9BYC7/4TWgKf6H9IY8BCA1/AxmREPATiGj8kc8xCA4/iYzHEPATiDj8mc8RCAH/ExmZ88BIDh33QuewjATXzMuC9AT2IBH5NZ8BCAu/iYzF0PAWAUMJ0VDwFYw8dk1jwEoIqPyVQ9BOAiPiZz0UMAjuJjMkc8BGALnUFJhI2mfMwO1hN5XvUvnhbmH/G297Ce0Iv0ChYizJ56oeIRiZtBfI/HdQnX5pmKd/Qk35K4cxZEwo5ob1ZyQuJC0fDwh9mMjZ+1a7CpkjMSl4x/lcnAUdha9kvVKxWo2WR8XeImjdccmX7NzmmfeFz42cJA7FEdkrg37x9Sjo0lVq2socxhRdQenGxeILZJ3Lf/iMQNFy9Ys2m1Q0bfsDKcsjKFqmwbTrU/GGGv3/AgqRH7r/tAdVJ1WuJmVD+rrqr+tvuMZRumXjOt2GsL9p6r9plz9h0n7TsP2jHCsXguIAAAAAAAAACUivsA0Iz8f9I8SgAAAABJRU5ErkJggg==";
    var scrollView = {
        //pullDownAction: pullDown
        onPullDown: function (options) {
            pullDown();
            options.component.release();
        }
    };
    var totalHoursGuage = {
        scale: {
            startValue: 0.00,
            endValue: ko.observable(24),
        },
        size: {
            height: 60,
            width: '100%'
        },
        value: totalHoursToday,
        title: {
            text: ""//localizeString('Hours Today')
        }
        //theme: 'tizen'
    };
    var displayDate = ko.observable('');

    function viewShowing() {
        //alert(DevExpress.devices.current().platform);
        if (AdvantageMobile_UI.CurrentUser.IsValidDatabase() == false) {
            AdvantageMobile_UI.Messages.toastWarning(localizeString("Invalid Database"));
            goToSignIn();
        };
        ////viewModel.displayDate(Globalize.format(viewModel.todayDate(), 'D'));
        var weekday = new Array(7);
        weekday[0] = "Sunday";
        weekday[1] = "Monday";
        weekday[2] = "Tuesday";
        weekday[3] = "Wednesday";
        weekday[4] = "Thursday";
        weekday[5] = "Friday";
        weekday[6] = "Saturday";

        var n = weekday[viewModel.todayDate().getDay()];
        viewModel.displayDate(n + ", " + viewModel.todayDate().toShortDateString());
        loadUser();
    };
    function pullDown() {
        loadUser();
    }
    function guageClick() {
        AdvantageMobile_UI.app.navigate({
            view: 'time_main',
            settings: { source: 2, date: todayDate().toShortDateString(), viewBy: 0 }
        });
    }
    function expensesClick() {
        AdvantageMobile_UI.app.navigate({
            view: 'expenses_summary',
            settings: { }
        });
    }
    function infoPanelClick() {
        //AdvantageMobile_UI.app.navigate({
        //    view: 'my_settings',
        //    settings: { }
        //});
    }
    function dateClick() {
        AdvantageMobile_UI.app.navigate({
            view: 'schedule_list',
            settings: {}
        });
    }
    function loadUser() {
        if (AdvantageMobile_UI.CurrentUser.EmployeeCode() != undefined) {
            loadPanelVisible(true);
            AdvantageMobile_UI.db.get('GetEmployeeSummary', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode()
            })
                .done(function (data) {
                    currentEmployee = new AdvantageMobile_UI.EmployeeSummaryViewModel(data);
                    //console.log("loadUser")
                    if (currentEmployee.Image() != null) {
                        viewModel.userPhoto('data:image/jpeg;base64, ' + currentEmployee.Image());
                        //console.log(currentEmployee.Image())
                    } else {
                        viewModel.userPhoto('data:image/png;base64, ' + emptyUser);
                        //console.log(emptyUser)
                    }
                    viewModel.userName(currentEmployee.FullName());
                    viewModel.assignmentCount(currentEmployee.AssignmentCount());
                    viewModel.alertCount(currentEmployee.AlertCount());
                    viewModel.expenseCount(currentEmployee.ExpenseCount());
                    viewModel.totalHoursToday(currentEmployee.TimesheetHoursForToday());
                    if (currentEmployee.StandardHoursForToday() !== undefined && currentEmployee.StandardHoursForToday() > 0) {
                        var t = 0.00;
                        var s = 0.00;
                        t = currentEmployee.TimesheetHoursForToday() * 1.00;
                        s = currentEmployee.StandardHoursForToday() * 1.00;
                        totalHoursGuage.scale.endValue(t > s ? t : s);
                    }
                    loadPanelVisible(false);
                })
                .fail(function (data) {
                    loadPanelVisible(false);
                    if (data.message.indexOf("Unspecified network error") > -1) {
                        goToSignIn();
                    } else {
                        handleDataServiceError(data);
                    }
                });
        } else {
            AdvantageMobile_UI.app.navigate({
                view: 'sign_in',
                settings: {}
            });
        }
    }

    var viewModel = {
        loadPanelVisible: loadPanelVisible,
        loadPanelMessage: loadPanelMessage,
        viewShowing: viewShowing,
        pullDown: pullDown,
        scrollView: scrollView,
        assignmentCount: ko.observable(0),
        alertCount: ko.observable(0),
        expenseCount: ko.observable(0),
        userName: ko.observable(''),
        userPhoto: ko.observable(''),
        loadUser: loadUser,
        totalHoursGuage: totalHoursGuage,
        guageClick: guageClick,
        expensesClick: expensesClick,
        infoPanelClick: infoPanelClick,
        totalHoursToday: totalHoursToday,
        todayDate: todayDate,
        displayDate: displayDate,
        dateClick: dateClick
    };
    return viewModel;

};