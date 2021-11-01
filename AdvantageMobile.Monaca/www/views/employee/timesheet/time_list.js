AdvantageMobile_UI.time_list = function (params, viewInfo) {
    /*
        
        params.settings.viewBy -->  0 = Day, 1 = Week, 2 = Month ==> Switched to separate pages; this var not in use
        params.settings.source -->  0 = time_main, 1 = time_entry, 2 = home, 3 = select_date
        params.settings.date

    */

    var selectedDate = ko.observable(new Date);
    var title = ko.observable('');
    var serviceName = 'GetTimesheetDay';
    var submitVisible = AdvantageMobile_UI.CurrentUser.TimeApprovalActive();
    var itemCount = 0;
    var submitButtonSet = false;
    var isPending = false;
    var isDenied = false;
    var isSubmit = true;
    var firstLoad = true;
    var submitButtonCSS = ko.observable("hide"); // message-block

    var timeEntryList = {
        dataSource: new DevExpress.data.DataSource({
            load: function (loadOptions) {
                var d = new $.Deferred();
                var filterOptions = loadOptions.filter ? loadOptions.filter.join(",") : "";
                var sortOptions = loadOptions.sort ? JSON.stringify(loadOptions.sort) : "";
                var skip = loadOptions.skip;
                var take = loadOptions.take;
                itemCount = 0;
                AdvantageMobile_UI.db.get(serviceName, {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    Date: viewModel.selectedDate().toShortDateString(),
                    filter: filterOptions,
                    sort: sortOptions,
                    skip: skip,
                    take: take
                }).done(function (data) {
                    d.resolve(data);
                }).fail(function (data) {
                    handleDataServiceError(data);
                })
                return d.promise();
            },
            pageSize: 12,
            map: function (item) {
                var showJobInfo = false;
                var showComment = false;
                var jobAndComponentDisplay = "";
                if ((item.JobNumber != undefined && item.JobNumber > 0) && (item.JobComponentNumber != undefined && item.JobComponentNumber > 0)) {
                    jobAndComponentDisplay = jobDisplay(item.JobNumber, item.JobComponentNumber, item.JobComponentDescription);
                    showJobInfo = true;
                };
                if (item.Comments != undefined && item.Comments != "") {
                    showComment = true;
                }
                var jobInfoCSS = "";
                var commentCSS = "";
                if (showComment == false) {
                    commentCSS = "hide";
                }
                if (showJobInfo == false) {
                    jobInfoCSS = "hide";
                }
                itemCount += 1;
                if (submitButtonSet == false) {
                    isPending = item.IsPendingApproval;
                    isDenied = item.IsDenied;
                    submitButtonSet = true;
                };
                var cdp = ""
                if (item.ClientCode != undefined) {
                    cdp = item.ClientCode;
                    if (item.DivisionCode != undefined) {
                        cdp = cdp + " | " + item.DivisionCode;
                        if (item.ProductCode != undefined) {
                            cdp = cdp + " | " + item.ProductCode;
                        };
                    };
                };
                return {
                    EmployeeTimeID: item.EmployeeTimeID,
                    EmployeeTimeDetailID: item.EmployeeTimeDetailID,
                    TimeType: item.TimeType,
                    EmployeeDate: item.EmployeeDate.toUtcShortDateString(),
                    JobNumber: item.JobNumber,
                    JobComponentNumber: item.JobComponentNumber,
                    JobComponentDescription: item.JobComponentDescription,
                    FunctionCategory: item.FunctionCategory,
                    FunctionCategoryDescription: item.FunctionCategoryDescription,
                    functionCategoryDisplay: item.FunctionCategory + ' - ' + item.FunctionCategoryDescription,
                    EmployeeHours: item.EmployeeHours.toTwoDecimalPlaces(),
                    Comments: item.Comments,
                    hoursText: localizeString('Hours') + ':',
                    commentsText: localizeString('Comments') + ':',
                    jobInfoCSS: jobInfoCSS,
                    jobAndComponentDisplay: jobAndComponentDisplay,
                    commentCSS: commentCSS,
                    cdp: cdp,
                };
            }
        }),
        rendered: ko.observable(false),
        searchQuery: ko.observable().extend({ throttle: 1000 }),
        paginate: true,
        pageLoadMode: "scrollBottom",
     pullRefreshEnabled: true,
        onContentReady: function (e) {
            if (isPending == true || isDenied == true) {
                isSubmit = false;
            } else {
                isSubmit = true;
            };
            if (firstLoad == true) {
                setSubmitButtonText();
                firstLoad = false;
            };
            if (itemCount == 0) {

            }
        }
    };
    function setSubmitButtonText() {
        //alert("setSubmitButtonText " + isSubmit)
        if (isSubmit == true) {
            submitButton.text(localizeString("Submit"));
        } else {
            submitButton.text(localizeString("Unsubmit"));
        };
    };

    var navBar = {
        items: [
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Previous') + ' ' + localizeString('Day'), onClick: goPrevious } },
            { location: 'center', widget: 'button', options: { type: 'normal', icon: 'icon_calendar_31', onClick: goToSelectDate } },
            { location: 'center', widget: 'button', options: { type: 'normal', icon: 'icon_star_blue', onClick: goToday } },
            { location: 'center', widget: 'button', options: { type: 'normal', text: localizeString('Next') + ' ' + localizeString('Day'), onClick: goNext } }
            //,{ location: 'center', text: this.title }
        ],
    };
    var addButton = {
        title: 'Add',
        id: 'create',
        icon: 'plus',
        onExecute: function (e) {
            AdvantageMobile_UI.db.get('IsTimesheetPostPeriodClosed', {
                Date: viewModel.selectedDate().toShortDateString()
            }).done(function (data) {
                if (data == true) {
                    AdvantageMobile_UI.Messages.toastFail(localizeString("Post Period Is Closed"));
                } else {
                    AdvantageMobile_UI.app.navigate({
                        view: "time_entry",
                        settings: { source: -1, date: viewModel.selectedDate(), isPreFill: false }
                    });
                }
            }).fail(function (data) {
                handleDataServiceError(data);
            })
        }
    };
    var submitButton = {
        text: ko.observable(localizeString("Submit")),
        onClick: function (e) {
            if (itemCount > 0) {
                var date = new Date(selectedDate());
                AdvantageMobile_UI.db.get('SubmitDayForTimeApproval', {
                    EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
                    EmployeeDate: date.toShortDateString(),
                    Approve: isSubmit
                }).done(function (data) {
                    if (data == "SUCCESS") {
                        AdvantageMobile_UI.Messages.toastSuccess();
                        isSubmit = !isSubmit;
                        viewModel.timeEntryList.dataSource.load();
                        //alert("isSubmit after change " + isSubmit)
                        setSubmitButtonText();
                    } else {
                        AdvantageMobile_UI.Messages.toastError(localizeString('Save Failed') + ":  " + data);
                    };
                }).fail(function (data) {
                    handleDataServiceError(data);
                });
            } else {
                AdvantageMobile_UI.Messages.toastFail(localizeString("No Records"));
            };
        }
    };
    function viewShowing() {
        if (params.settings) {
            if (params.settings.date) {
                selectedDate(new Date(params.settings.date));
            };
            serviceName = 'GetTimesheetDay';
        };
        load();
        if (submitVisible == false) {
            submitButtonCSS("hide");
        };
    };
    function goNext(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(1))
        viewModel.selectedDate(newDate);
        firstLoad = true;
        load();
    };
    function goToday(e) {
        var newDate = new Date();
        viewModel.selectedDate(newDate);
        firstLoad = true;
        load();
    };
    function goToSelectDate(e) {
        AdvantageMobile_UI.app.navigate({
            view: "select_date",
            settings: { source: 1 }
        });
    };
    function goPrevious(e) {
        var newDate = new Date(viewModel.selectedDate().addDays(-1))
        viewModel.selectedDate(newDate);
        firstLoad = true;
        load();
    };
    function load() {
        var today = new Date();
        if (viewModel.selectedDate().toUtcShortDateString() == today.toUtcShortDateString()) {
            viewModel.title(localizeString("Today"));
        } else {
            ////viewModel.title(Globalize.format(viewModel.selectedDate(), 'D'));
            viewModel.title(viewModel.selectedDate().toShortDateString());
        }
        viewModel.timeEntryList.dataSource.load();
    };
    var viewModel = {
        //  Put the binding properties here
        title: title,
        viewShowing: viewShowing,
        selectedDate: selectedDate,
        timeEntryList: timeEntryList,
        navBar: navBar,
        goNext: goNext,
        goPrevious: goPrevious,
        addButton: addButton,
        submitButton: submitButton,
        submitVisible: submitVisible,
        submitButtonCSS: submitButtonCSS
    };

    return viewModel;

};