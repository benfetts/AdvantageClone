var wvbridge = {
    GetRadWindow: function () {
        return GetRadWindow();
    },
    closeWindow: function () {
        closeWindow();
    },
    CloseWindow: function () {
        closeWindow();
    },
    CloseWindowNew: function () {
        closeWindowNew();
    },
    OpenRadWindow: function (WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal) {
        OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal);
    },
    OpenRadWindowdc: function (WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, dialogCallback, param) {
        OpenRadWindow(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal, dialogCallback, param);
    },
    OpenRadWindowUpdate: function (WindowTitle, WindowURL, NewURL) {
        OpenRadWindowUpdate(WindowTitle, WindowURL, NewURL);
    },
    OpenRadWindowLookup: function (WindowURL) {
        OpenRadWindowLookup(WindowURL);
    },
    OpenRadWindowLookupRecipients: function (WindowURL) {
        OpenRadWindowLookupRecipients(WindowURL);
    },
    OpenRadWindowLookupEmailRecipients: function (WindowURL) {
        OpenRadWindowLookupEmailRecipients(WindowURL);
    },
    copyToClipboard: function (text) {
        copyToClipboard(text);
    },
    RefreshBookmarksDTO: function () {
        RefreshBookmarksDTO();
    },
    toggleFullScreenElement: function (element) {
        toggleFullScreenElement(element);
    },
    showSuccessNotification: function (data) {
        showSuccessNotification(data);
    },
    showInfoNotification: function (data) {
        showInfoNotification(data);
    },
    showWarningNotification: function (data) {
        showWarningNotification(data);
    },
    showErrorNotification: function (data) {
        showErrorNotification(data);
    },
    showNotification: function (data, type) {
        showNotification(data, type);
    },
    GetDocumentRepositoryDocument: function (docID) {
        GetDocumentRepositoryDocument(docID);
    },
    RefreshTimesheetWindows: function () {
        RefreshTimesheetWindows();
    },
    disableWorkItemTimeSaveButton: function (disable) {
        disableWorkItemTimeSaveButton(disable);
    },
    sessionEnded: function () {
        sessionEnded();
    },
    extendTimeout: function () {
        extendTimeout();
    },
    processLookupToAngular: function (args) {
        processLookupToAngular(args);
    },
    CheckWnd: function () {
        CheckWnd();
    },
    OpenStopwatchNotify: function () {
        OpenStopwatchNotify();
    },
    RefreshWindowWithNewURL: function (WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal) {
        RefreshWindowWithNewURL(WindowTitle, WindowURL, WindowHeight, WindowWidth, IsModal);
    },
    refreshCurrentDashboard: function () {
        refreshCurrentDashboard();
    },
    refreshDashboardTime: function () {
        refreshDashboardTime();
    },
    refreshDashboardAssignments: function () {
        refreshDashboardAssignments();
    },
    refreshDashboardAlerts: function () {
        refreshDashboardAlerts();
    },
    refreshDashboardAppointments: function () {
        refreshDashboardAppointments();
    },
    refreshDashboardBookmarks: function () {
        refreshDashboardBookmarks();
    },
    refreshDashboardReviews: function () {
        refreshDashboardReviews();
    },
    refreshAlertNotifications: function () {
        refreshAlertNotifications();
    },
    refreshAlertsAndAssignmentsManagerPMD: function () {
        refreshAlertsAndAssignmentsManagerPMD();
    },
    checkForStopwatch: function () {
        checkForStopwatch();
    },
    refreshTimesheetTab: function () {
        refreshTimesheetTab();
    },
    openStopWatchDialog: function () {
        openStopWatchDialog();
    },
    stopwatchCounter: function (JsDateString, JsServerTime, id) {
        stopwatchCounter(JsDateString, JsServerTime, id);
    },
    RefreshWindow: function (url) {
        RefreshWindow(url, false, false);
    },
    refreshSprint: function (sprintId, sprintIsActive, sprintIsComplete, employeeName) {
        refreshSprint(sprintId, sprintIsActive, sprintIsComplete, employeeName);
    },
    refreshNewAlertView: function (alertId, sprintId, employeeName) {
        refreshNewAlertView(alertId, sprintId, employeeName);
    },
    refreshAlerts: function () {
        refreshAlerts();
    },
    refreshDashboardWorkItems: function () {
        refreshDashboardWorkItems();
    },
    refreshAlertComments: function (alertId, employeeName) {
        refreshAlertComments(alertId, employeeName);
    },
    refreshAlertChecklists: function (alertId, employeeName) {
        refreshAlertChecklists(alertId, employeeName);
    },
    refreshAlertAssigneesAndCCs: function (alertId, employeeName) {
        refreshAlertAssigneesAndCCs(alertId, employeeName);
    },
    refreshAlertHours: function (alertId, employeeName) {
        refreshAlertHours(alertId, employeeName);
    },
    refreshAssignmentTab: function (alertId, sprintId, employeeName, updateType) {
        refreshAssignmentTab(alertId, sprintId, employeeName, updateType);
    },
    CloseAlertView: function (AlertID) {
        CloseAlertView(AlertID);
    },
    refreshMyAssignmentsNotificationsAndCounts: function () {
        refreshMyAssignmentsNotificationsAndCounts();
    },
    refreshExpenseReports: function () {
        refreshExpenseReports();
    },
    messageUser: function (userCode, message) {
        messageUser(userCode, message);
    }
};
