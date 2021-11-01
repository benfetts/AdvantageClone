import { DialogController } from 'aurelia-dialog';
import { bindable, inject, customElement, NewInstance } from 'aurelia-framework';
import { browserWindow } from 'services/utilities/browserWindow'
import { Webvantage } from '../../webvantage'

@inject(DialogController, NewInstance.of(browserWindow))
export class IframeDialog {
    controller: DialogController;
    BrowserWindow: browserWindow;

    data: any;
    frame: any;

    activate(Data: any) {
        let me = this;
        this.data = Data;
        this.controller.settings.lock = false;

        if (this.data.title == 'JobTemplate_NewComponent.aspx') {
            this.data.title = "New Job Component"
        }
        else if (this.data.title == 'Documents_List2.aspx') {
            this.data.title = "Document List"
        }
        else if (this.data.title == 'TrafficSchedule_QuickAdd.aspx') {
            this.data.title = "Task Add"
        }
        else if (this.data.title == 'Workspace_Manage.aspx') {
            this.data.title = "Workspace Template"
        }
        else if(this.data.title == 'AgencySettings.aspx') {
            this.data.title = "Client Portal Customization"
        }
        else if (this.data.title == 'AgencySettings_Upload.aspx') {
            this.data.title = "Upload"
        }
        else if (this.data.title == 'EmployeeTimeForecast_New.aspx') {
            this.data.title = "Employee Time Forecast"
        }

        if (this.data.url.includes('Expense_Paid_detail.aspx') ||
            this.data.url.includes('Alert_Comments.aspx') ||
            //this.data.url.includes('Alert_Assignment.aspx') ||
            this.data.url.includes('Timesheet_Stopwatch.aspx') ||
            this.data.url.includes('TrafficSchedule_TaskEmployees.aspx')) {
            this.controller.settings.overlayDismiss = true;
        }

        if (this.data.url.includes('Alert_Assignment.aspx')) {
            this.data.width = 450;
            this.data.height = 650;
        }

        if (this.data.url.includes('Desktop_NewAssignment')) {
            this.data.width = 1145;
        }
        else if (this.data.url.includes('Expense_Paid_detail.aspx') ||
            this.data.url.includes('Documents_List.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('popContacts.aspx')) {
            this.data.width = 1100;
            this.data.height = 600;
            //this.data.title = "Client Address Information";
        }
        else if (this.data.url.includes('JobTemplate_Print.aspx')) {
            this.data.title = "Print Job";
        }
        else if (this.data.url.includes('CreativeBrief_Print.aspx')) {
            this.data.title = "Print Creative Brief";
        }
        else if (this.data.url.includes('JobSpecs_Print.aspx')) {
            this.data.title = "Print Job Specification";
        }
        
        else if (this.data.url.includes('Documents_Upload.aspx')) {
            this.data.width = 1100;
            this.data.height = 700;
        }

        else if (this.data.url.includes('TrafficSchedule_TaskEmployees.aspx')) {
            this.data.width = 1100;
            this.data.height = 700;
        }
        
        else if (this.data.url.includes('Reporting_UserDefinedReportEdit.aspx')) {
            this.data.title = 'Add New Report';
            this.data.width = 800;
            this.data.height = 500;
        }
        else if (this.data.url.includes('Document_Edit.aspx')) {
            this.data.width = 1100;
            this.data.title = 'Document Edit';
        }
        else if (this.data.url.includes('Reporting_InitialLoadingBillingApproval.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('BillingApproval.aspx')) {
            this.data.width = 600;
            this.data.height = 250;
        }
        else if (this.data.url.includes('Documents_History.aspx')) {
            this.data.title = 'Document History';
        }
        else if (this.data.url.includes('Maintenance_ClientEdit.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Documents_List2.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('purchaseorder_dtl_add.aspx')) {
            this.data.width = 1700;
            this.data.title = 'Select';
        }
        else if (this.data.url.includes('PurchaseOrder_CopyWizard.aspx')) {
            this.data.width = 1100;
            this.data.title = 'Purchase Order';
        }
        else if (this.data.url.includes('popContactsAdd.aspx')) {
            this.data.width = 900;
        }
        else if (this.data.url.includes('Documents_List2.aspx')) {
            this.data.width = 1100;
            this.data.title = 'All Documents';
        }
        //else if (this.data.url.includes('Reporting_FilterReport.aspx')) {
        //    this.data.width = 1100;
        //    this.data.title = 'Filter Editor';
        //}
        else if (this.data.url.includes('Reporting_MediaSpecificationReportEdit.aspx')) {
            this.data.width = 1100;
            this.data.title = 'Add New Media Report';
        }
        else if (this.data.url.includes('JobVerTmplt.aspx')) {
            this.data.width = 1100;
            this.data.title = 'Job Request';
        }
        //else if (this.data.url.includes('Reporting_EmployeeUtilizationReportEdit.aspx')) {
        //    this.data.width = 1100;
        //    this.data.title = 'New Employee Report';
        //}
        else if (this.data.url.includes('Reporting_InitialLoadingSaveDynamicReportTemplate.aspx')) {
            this.data.title = 'Save';
        }
        else if (this.data.url.includes('jobVerNew.aspx')) {
            this.data.title = 'Add New';
            this.data.height = 400;
        }
        else if (this.data.url.includes('Documents_List2.aspx')) {
            this.data.title = 'Duplicate';
            this.data.width = 1100;
        }
        else if (this.data.url.includes('BillingApproval_Batch.aspx')) {

            this.data.width = 1100;
        }
        else if (this.data.url.includes('LookUp_AdNumber.aspx')) {

            this.data.width = 1100;
        }
        else if (this.data.url.includes('purchaseorder.aspx')) {
            this.data.title = 'New Purchase Order';
            this.data.width = 1100;
            this.data.height = 650;
        }
        else if (this.data.url.includes('Reporting_InitialLoading.aspx')) {
            this.data.title = 'Set Initial Criteria';
            this.data.width = 800;
        }
        else if (this.data.url.includes('Documents_ProofHQUpload.aspx')) {
            this.data.title = 'Upload A New Document';
            this.data.width = 800;
        }
        else if (this.data.url.includes('Reporting_SaveDynamicReportTemplate.aspx')) {
            this.data.title = 'Save Report Template';
            this.data.width = 900;
            this.data.height = 500;
        }
        
        else if (this.data.url.includes('JobForecast_New.aspx')) {
            this.data.title = 'Job Forecast';
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Documents_Upload.aspx')) {
            this.data.width = 800;
        }
        else if (this.data.url.includes('Estimating_AddNew.aspx')) {
            this.data.title = 'New Estimate';
            this.data.width = 1100;
        }

        else if (this.data.url.includes('TrafficSchedule_AddJobPred.aspx')) {
            this.data.title = 'Add Job Predecessors';

        }
        else if (this.data.url.includes('Calendar_NewActivity.aspx')) {
            this.data.width = 1000;
            this.data.height = 700;
            this.data.title = 'Calendar Activity';
        }
        else if (this.data.url.includes('JobTemplate_New.aspx')) {
            this.data.width = 1100;
            this.data.height = 700;
            this.data.title = 'Job Jacket';
        }
        else if (this.data.url.includes('TrafficScheduleVersion.aspx')) {
            this.data.title = 'Versions';
        }
        else if (this.data.url.includes('Maintenance_ActivitySummary.aspx')) {
            this.data.width = 1100;
            this.data.height = 700;
        }
        else if (this.data.url.includes('Expense_Edit_V2.aspx') ||
            this.data.url.includes('Expense_Edit.aspx')) {
            this.data.title = 'New Expense Report';
            this.data.width = 1500;
        }
        else if (this.data.url.includes('purchaseorder_dtl.aspx')) {
            this.data.title = 'Purchase Order Details';
        }
        //else if (this.data.url.includes('jobVerTmplt.aspx')) {
        //    this.data.title = 'Add New';
        //}

        else if (this.data.url.includes('Documents_ImageViewer.aspx')) {
            this.data.title = 'Comments';
            this.data.width = 1300;
            this.data.height = 700;
        }
        else if (this.data.url.includes('Estimating_FunctionComments.aspx')) {
            this.data.title = 'Estimate Function Comments';
        }
        else if (this.data.url.includes('VendorQuote_Comments.aspx')) {
            this.data.title = 'Vendor Quote Comments';
        }
        else if (this.data.url.includes('Reporting_InitialLoadingDirectTime.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingPostPeriod.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Alert_New.aspx')) {
            this.data.width = 1100;
            this.data.height = 650;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingJobDetail.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingJobDetailFeesOOP.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingBillingWorksheetProduction.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingEstimatedAndActualIncome.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingAlert.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingMediaPlanComparisonSummary.aspx')) {
            this.data.width = 1100;
        }
     
        else if (this.data.url.includes('TrafficScheduleTemplate_New.aspx')) {
            this.data.title = 'New Task Template'; 
        } 
        else if (this.data.url.includes('TrafficSchedule_QuickAdd.aspx')) {
            this.data.width = 1200;
        } 
        else if (this.data.url.includes('Employee/Timesheet/Entry')) {
            //this.data.height = 570;
            //this.data.width = 680;
        }

        else if (this.data.url.includes('ProjectManagement/Agile/Design')) {
            this.data.width = 1300;
            this.data.height = 700;
        }

        else if (this.data.url.includes('VendorQuote.aspx')) {
            this.data.width = 1200;
        }
        else if (this.data.url.includes('Security_DocumentRepository.aspx')) {
            this.data.height = 700;
            this.data.width = 1100;
        }

        else if (this.data.url.includes('Estimating_JobHistory.aspx')) {
            this.data.width = 1500;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingMediaPlan.aspx')) {
            this.data.width = 1000;
        }
        else if (this.data.url.includes('Workspace_Manage.aspx')) {
            this.data.width = 1100;
        }
        else if (this.data.url.includes('Reporting_InitialLoadingTransfer.aspx')) {
            this.data.width = 675;
        }
        
        else if (this.data.url.includes('PurchaseOrderAPDetails.aspx')) {
            this.data.title = 'AP Detail';
        }
        

        else if (this.data.url.includes('Alert_Settings.aspx')) {
            this.data.title = 'Alert Settings';
            this.data.width = 600;
            this.data.height = 400;

        }

        else if (this.data.url.includes('Alert_AddAttachments.aspx')) {
            this.data.title = 'Add Attachment';
        }
        

        else if (this.data.url.includes('Estimating_PrintSettings.aspx')) {

            this.data.width = 1300;

        }
        else if (this.data.url.includes('Maintenance_ProductEdit.aspx')) {

            this.data.width = 1200;

        }

        else if (this.data.url.includes('Security_ClientPortal_Settings.aspx')) {
            this.data.height = 600;
            //this.data.width = 1100;

        }
        //else if (this.data.url.includes('jobVerTmplt.aspx') && this.data.title == '') {
        //    this.data.title = 'Add New';
        //}

        //this.removeTelerik();
    }
    removeTelerik() {
        var telerik = document.getElementById("telerik-aqua-body");
        telerik.classList.remove("telerik-aqua-body");
    }
    attached() {
        let me = this;

        me.frame = $(document.getElementById('ai-dialog-iframe'))[0];

        me.frame.ownerDocument['GetRadWindow'] = function () {

            me.BrowserWindow.Parent = me;
            me.BrowserWindow.Frame = me.frame;
            me.BrowserWindow.webvantage = me.data.webvantage;
            me.BrowserWindow.CloseDialog = me.CloseDialog;

            return {
                BrowserWindow: me.BrowserWindow
            };
        }.bind(this)

        me.frame.ownerDocument['GetRadWindowNew'] = function () {

            me.BrowserWindow.Parent = me;
            me.BrowserWindow.Frame = me.frame;
            me.BrowserWindow.webvantage = me.data.webvantage;
            me.BrowserWindow.CloseDialog = me.CloseDialog;

            return {
                BrowserWindow: me.BrowserWindow
            };
        }.bind(this)


    }

    CloseDialog() {
        var me;
        me = this;
        me.Parent.controller.close(true);
    }

    closeModule(param: any) {
        this.controller.close(true);
    }

    constructor(controller: DialogController, BrowserWindow: browserWindow) {
        this.controller = controller;
        this.controller.settings.lock = true;
        this.controller.settings.overlayDismiss = false;

        this.BrowserWindow = BrowserWindow;
    }

}
