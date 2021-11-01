AdvantageMobile_UI.expense_reports_list = function (params, viewInfo) {

    var captureReceiptCommand = {
        title: 'Add Receipt',
        id: 'menu-custom1',
        onExecute: function () {
            AdvantageMobile_UI.app.navigate({
                view: "expense_receipt"
            });
        }
    };
    var newExpenseReportCommand = {
        title: 'New Expense Report',
        id: 'menu-add',
        onExecute: function () {
            AdvantageMobile_UI.app.navigate({
                view: "expense_report",
                settings: { isNew: true }
            });
        },
        visible: ko.observable(true)
    };
    var expenseListDataSource = new DevExpress.data.DataSource({
        load: function () {
            var d = new $.Deferred();
            AdvantageMobile_UI.db.get('GetExpensesForCurrentMonth', {
                EmployeeCode: AdvantageMobile_UI.CurrentUser.EmployeeCode(),
            }).done(function (data) {
                d.resolve(data);
            }).fail(function (data) {
                handleDataServiceError(data);
            })
            return d.promise();
        },
        map: function (item) {
            return new AdvantageMobile_UI.ExpenseViewModel(item);
        }
    });

    var viewModel = {
        //  Put the binding properties here
        onButtonCaptureRecieptClick: function (e) {
            AdvantageMobile_UI.app.navigate({
                view: "expense_receipt"
            });
        },
        captureReceiptCommand: captureReceiptCommand,
        newExpenseReportCommand: newExpenseReportCommand,
        expenseListDataSource: expenseListDataSource,

    };

    return viewModel;

};