
(function() {
    AdvantageMobile_UI.AlertViewModel = function(data) {
				this.ID = ko.observable();
				this.AlertTypeID = ko.observable();
				this.AlertCategoryID = ko.observable();
				this.Subject = ko.observable();
				this.Body = ko.observable();
				this.GeneratedDate = ko.observable();
				this.Priority = ko.observable();
				this.ClientCode = ko.observable();
				this.DivisionCode = ko.observable();
				this.ProductCode = ko.observable();
				this.CampaignCode = ko.observable();
				this.JobNumber = ko.observable();
				this.JobComponentNumber = ko.observable();
				this.EstimateNumber = ko.observable();
				this.EstimateComponentNumber = ko.observable();
				this.EstimateQuoteNumber = ko.observable();
				this.EstimateRevisionNumber = ko.observable();
				this.VendorCode = ko.observable();
				this.EmployeeCode = ko.observable();
				this.PurchaseOrderNumber = ko.observable();
				this.PurchaseOrderRevisionNumber = ko.observable();
				this.OrderNumber = ko.observable();
				this.RevisionNumber = ko.observable();
				this.UserCode = ko.observable();
				this.TempPdfPath = ko.observable();
				this.AlertLevel = ko.observable();
				this.CampaignID = ko.observable();
				this.OfficeCode = ko.observable();
				this.BodyHtml = ko.observable();
				this.IsClientPortal = ko.observable();
				this.BillingApprovalBatchID = ko.observable();
				this.TaskSequenceNumber = ko.observable();
				this.DueDate = ko.observable();
				this.AlertAssignmentStateID = ko.observable();
				this.AlertAssignmentTemplateID = ko.observable();
				this.TimeDue = ko.observable();
				this.Version = ko.observable();
				this.Build = ko.observable();
				this.SequenceNumber = ko.observable();
				this.SentDate = ko.observable();
				this.LastUpdatedDate = ko.observable();
				this.Version2 = ko.observable();
				this.Build2 = ko.observable();
				this.ClientPortalUserID = ko.observable();
				this.NonTaskID = ko.observable();
				this.AccountsPayableID = ko.observable();
				this.AccountsPayableSequenceNumber = ko.observable();
				this.AtbRevisionID = ko.observable();
				this.IS_DRAFT = ko.observable();
				this.ATTACHMENT_COUNT = ko.observable();
				this.LAST_UPDATED_USER_CODE = ko.observable();
				this.LAST_UPDATED_FML = ko.observable();
				this.ASSIGNED_EMP_CODE = ko.observable();
				this.ASSIGNED_EMP_FML = ko.observable();
				this.ASSIGN_COMPLETED = ko.observable();
				this.LAST_ASSIGNED_EMP_CODE = ko.observable();
				this.JOB_VER_HDR_ID = ko.observable();
				this.IS_CS_REVIEW = ko.observable();
				this.CS_AUTO_APPR_METHOD = ko.observable();
				this.CS_REVIEW_TYPE = ko.observable();
				this.CS_REVIEW_STATUS = ko.observable();
				this.CS_PROJECT_ID = ko.observable();
				this.CS_REVIEW_ID = ko.observable();
				this.CS_NUM_REVIEWER = ko.observable();
				this.CS_NUM_CMPLT = ko.observable();
				this.CS_ASSET_IMG = ko.observable();
				this.CS_NUM_REJECT = ko.observable();
				this.CS_NUM_DEFER = ko.observable();
				this.CS_NUM_APPR = ko.observable();
		        if(data)
					this.fromJS(data);
    };

    $.extend(AdvantageMobile_UI.AlertViewModel.prototype, {
        toJS: function() {
            return {
			ID: this.ID(),
			AlertTypeID: this.AlertTypeID(),
			AlertCategoryID: this.AlertCategoryID(),
			Subject: this.Subject(),
			Body: this.Body(),
			GeneratedDate: this.GeneratedDate(),
			Priority: this.Priority(),
			ClientCode: this.ClientCode(),
			DivisionCode: this.DivisionCode(),
			ProductCode: this.ProductCode(),
			CampaignCode: this.CampaignCode(),
			JobNumber: this.JobNumber(),
			JobComponentNumber: this.JobComponentNumber(),
			EstimateNumber: this.EstimateNumber(),
			EstimateComponentNumber: this.EstimateComponentNumber(),
			EstimateQuoteNumber: this.EstimateQuoteNumber(),
			EstimateRevisionNumber: this.EstimateRevisionNumber(),
			VendorCode: this.VendorCode(),
			EmployeeCode: this.EmployeeCode(),
			PurchaseOrderNumber: this.PurchaseOrderNumber(),
			PurchaseOrderRevisionNumber: this.PurchaseOrderRevisionNumber(),
			OrderNumber: this.OrderNumber(),
			RevisionNumber: this.RevisionNumber(),
			UserCode: this.UserCode(),
			TempPdfPath: this.TempPdfPath(),
			AlertLevel: this.AlertLevel(),
			CampaignID: this.CampaignID(),
			OfficeCode: this.OfficeCode(),
			BodyHtml: this.BodyHtml(),
			IsClientPortal: this.IsClientPortal(),
			BillingApprovalBatchID: this.BillingApprovalBatchID(),
			TaskSequenceNumber: this.TaskSequenceNumber(),
			DueDate: this.DueDate(),
			AlertAssignmentStateID: this.AlertAssignmentStateID(),
			AlertAssignmentTemplateID: this.AlertAssignmentTemplateID(),
			TimeDue: this.TimeDue(),
			Version: this.Version(),
			Build: this.Build(),
			SequenceNumber: this.SequenceNumber(),
			SentDate: this.SentDate(),
			LastUpdatedDate: this.LastUpdatedDate(),
			Version2: this.Version2(),
			Build2: this.Build2(),
			ClientPortalUserID: this.ClientPortalUserID(),
			NonTaskID: this.NonTaskID(),
			AccountsPayableID: this.AccountsPayableID(),
			AccountsPayableSequenceNumber: this.AccountsPayableSequenceNumber(),
			AtbRevisionID: this.AtbRevisionID(),
			IS_DRAFT: this.IS_DRAFT(),
			ATTACHMENT_COUNT: this.ATTACHMENT_COUNT(),
			LAST_UPDATED_USER_CODE: this.LAST_UPDATED_USER_CODE(),
			LAST_UPDATED_FML: this.LAST_UPDATED_FML(),
			ASSIGNED_EMP_CODE: this.ASSIGNED_EMP_CODE(),
			ASSIGNED_EMP_FML: this.ASSIGNED_EMP_FML(),
			ASSIGN_COMPLETED: this.ASSIGN_COMPLETED(),
			LAST_ASSIGNED_EMP_CODE: this.LAST_ASSIGNED_EMP_CODE(),
			JOB_VER_HDR_ID: this.JOB_VER_HDR_ID(),
			IS_CS_REVIEW: this.IS_CS_REVIEW(),
			CS_AUTO_APPR_METHOD: this.CS_AUTO_APPR_METHOD(),
			CS_REVIEW_TYPE: this.CS_REVIEW_TYPE(),
			CS_REVIEW_STATUS: this.CS_REVIEW_STATUS(),
			CS_PROJECT_ID: this.CS_PROJECT_ID(),
			CS_REVIEW_ID: this.CS_REVIEW_ID(),
			CS_NUM_REVIEWER: this.CS_NUM_REVIEWER(),
			CS_NUM_CMPLT: this.CS_NUM_CMPLT(),
			CS_ASSET_IMG: this.CS_ASSET_IMG(),
			CS_NUM_REJECT: this.CS_NUM_REJECT(),
			CS_NUM_DEFER: this.CS_NUM_DEFER(),
			CS_NUM_APPR: this.CS_NUM_APPR(),
			};
        },

        fromJS: function(data) {
            if(data) {
				this.ID(data.ID);
				this.AlertTypeID(data.AlertTypeID);
				this.AlertCategoryID(data.AlertCategoryID);
				this.Subject(data.Subject);
				this.Body(data.Body);
				this.GeneratedDate(data.GeneratedDate);
				this.Priority(data.Priority);
				this.ClientCode(data.ClientCode);
				this.DivisionCode(data.DivisionCode);
				this.ProductCode(data.ProductCode);
				this.CampaignCode(data.CampaignCode);
				this.JobNumber(data.JobNumber);
				this.JobComponentNumber(data.JobComponentNumber);
				this.EstimateNumber(data.EstimateNumber);
				this.EstimateComponentNumber(data.EstimateComponentNumber);
				this.EstimateQuoteNumber(data.EstimateQuoteNumber);
				this.EstimateRevisionNumber(data.EstimateRevisionNumber);
				this.VendorCode(data.VendorCode);
				this.EmployeeCode(data.EmployeeCode);
				this.PurchaseOrderNumber(data.PurchaseOrderNumber);
				this.PurchaseOrderRevisionNumber(data.PurchaseOrderRevisionNumber);
				this.OrderNumber(data.OrderNumber);
				this.RevisionNumber(data.RevisionNumber);
				this.UserCode(data.UserCode);
				this.TempPdfPath(data.TempPdfPath);
				this.AlertLevel(data.AlertLevel);
				this.CampaignID(data.CampaignID);
				this.OfficeCode(data.OfficeCode);
				this.BodyHtml(data.BodyHtml);
				this.IsClientPortal(data.IsClientPortal);
				this.BillingApprovalBatchID(data.BillingApprovalBatchID);
				this.TaskSequenceNumber(data.TaskSequenceNumber);
				this.DueDate(data.DueDate);
				this.AlertAssignmentStateID(data.AlertAssignmentStateID);
				this.AlertAssignmentTemplateID(data.AlertAssignmentTemplateID);
				this.TimeDue(data.TimeDue);
				this.Version(data.Version);
				this.Build(data.Build);
				this.SequenceNumber(data.SequenceNumber);
				this.SentDate(data.SentDate);
				this.LastUpdatedDate(data.LastUpdatedDate);
				this.Version2(data.Version2);
				this.Build2(data.Build2);
				this.ClientPortalUserID(data.ClientPortalUserID);
				this.NonTaskID(data.NonTaskID);
				this.AccountsPayableID(data.AccountsPayableID);
				this.AccountsPayableSequenceNumber(data.AccountsPayableSequenceNumber);
				this.AtbRevisionID(data.AtbRevisionID);
				this.IS_DRAFT(data.IS_DRAFT);
				this.ATTACHMENT_COUNT(data.ATTACHMENT_COUNT);
				this.LAST_UPDATED_USER_CODE(data.LAST_UPDATED_USER_CODE);
				this.LAST_UPDATED_FML(data.LAST_UPDATED_FML);
				this.ASSIGNED_EMP_CODE(data.ASSIGNED_EMP_CODE);
				this.ASSIGNED_EMP_FML(data.ASSIGNED_EMP_FML);
				this.ASSIGN_COMPLETED(data.ASSIGN_COMPLETED);
				this.LAST_ASSIGNED_EMP_CODE(data.LAST_ASSIGNED_EMP_CODE);
				this.JOB_VER_HDR_ID(data.JOB_VER_HDR_ID);
				this.IS_CS_REVIEW(data.IS_CS_REVIEW);
				this.CS_AUTO_APPR_METHOD(data.CS_AUTO_APPR_METHOD);
				this.CS_REVIEW_TYPE(data.CS_REVIEW_TYPE);
				this.CS_REVIEW_STATUS(data.CS_REVIEW_STATUS);
				this.CS_PROJECT_ID(data.CS_PROJECT_ID);
				this.CS_REVIEW_ID(data.CS_REVIEW_ID);
				this.CS_NUM_REVIEWER(data.CS_NUM_REVIEWER);
				this.CS_NUM_CMPLT(data.CS_NUM_CMPLT);
				this.CS_ASSET_IMG(data.CS_ASSET_IMG);
				this.CS_NUM_REJECT(data.CS_NUM_REJECT);
				this.CS_NUM_DEFER(data.CS_NUM_DEFER);
				this.CS_NUM_APPR(data.CS_NUM_APPR);
		
            }
        }
    });
})();