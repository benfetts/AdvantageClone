
//
var _activeView = "";

//parent call from Webvantage.ts
function refreshPage(requestor) {
    //
    if (requestor == "parent" && _activeView == "paymentManager") {        
        manageModuleViews(_activeView);
    }    
}

function openRadWindowWithEvents(title, url, windowHeight, windowWidth, modal, onCloseCallback) {
    OpenRadWindow(title, url, windowHeight, windowWidth, modal, onCloseCallback);
}

function manageModuleViews(operation) {
    _activeView = operation;

    $("#dashboardButton").removeClass("k-state-active");
    $("#managePaymentsButton").removeClass("k-state-active");
    $("#manageVCCsButton").removeClass("k-state-active");
    $("#outstandingButton").removeClass("k-state-active");
    $("#completedButton").removeClass("k-state-active");    

    switch (operation) {
        case "dashboard":   
            LoadDashboardView();
            $("#payments-dashboard").show();
            $("#dashboardButton").addClass("k-state-active");

            //$("#manage-payments").hide();
            //$("#manage-virtual-cards").hide();
            //$("#payments-outstanding").hide();
            //$("#payments-completed").hide();
            break;
        case "paymentManager":
            LoadManagePaymentsView();
            $("#manage-payments").show();
            $("#managePaymentsButton").addClass("k-state-active");

            //$("#payments-dashboard").hide();            
            //$("#manage-virtual-cards").hide();
            //$("#payments-outstanding").hide();
            //$("#payments-completed").hide();
            break;
        case "vcManager":
            LoadManageVCCView();
            $("#manage-virtual-cards").show();
            $("#manageVCCsButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();            
            $("#payments-outstanding").hide();
            $("#payments-completed").hide();
            break;
        case "outstanding":
            LoadOutstandingApprovalsView();
            $("#payments-outstanding").show();
            $("#outstandingButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();
            $("#manage-virtual-cards").hide();            
            $("#payments-completed").hide();
            break;
        case "completed":
            LoadCompletedBatchesView();
            $("#payments-completed").show();
            $("#completedButton").addClass("k-state-active");

            $("#manage-payments").hide();
            $("#payments-dashboard").hide();
            $("#manage-virtual-cards").hide();
            $("#payments-outstanding").hide();            
            break;
    }    
    
}
