Namespace Database.Entities

	<Table("ALERT")>
	Public Class Alert
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			AlertTypeID
			AlertCategoryID
			Subject
			Body
			GeneratedDate
			PriorityLevel
			EmployeeCode
			UserCode
			AlertLevel
			EmailBody
			AlertStateID
			AlertAssignmentTemplateID
			DueDate
			TimeDue
			ClientContactID
			ClientCode
			DivisionCode
			ProductCode
			CampaignCode
			JobNumber
			JobComponentNumber
			EstimateNumber
			EstimateComponentNumber
			EstimateQuoteNumber
			EstimateRevisionNumber
			VendorCode
			PORevisionNumber
			PONumber
			OfficeCode
			CampaignID
			NonTaskID
			IsCPAlert
			BillingApprovalBatchID
			TaskSequenceNumber
			AlertSequenceNumber
			Version
			Build
			Version2
			Build2
			AccountPayableID
			AccountPayableSequenceNumber
			MediaATBRevisionID
            LastUpdated
            JobVersionID
            IsDraft
            AttachmentCount
            LastUpdatedUserCode
            LastUpdatedFullName
            AssignedEmployeeCode
            AssignedEmployeeFullName
            AssignmentCompleted
            LastAssignedEmployeeCode
            IsConceptShareReview
            ConceptShareAutoApproveMethodID
            ConceptShareReviewTypeID
            ConceptShareReviewStatusID
            ConceptShareProjectID
            ConceptShareReviewID
            ConceptShareNumberOfReviewers
            ConceptShareNumberOfCompletedReviewers
            ConceptShareNumberOfApprovedReviewers
            ConceptShareNumberOfRejectedReviewers
            ConceptShareNumberOfDeferredReviewers
            ConceptShareAssetImage
            IsWorkItem
            BoardStateID
            EpicID
            HoursAllowed
            BacklogSequenceNumber
            StartDate

            AlertType
			AlertAttachments
			AlertComments
			AlertRecipients
			AlertCategory
			AlertRecipientDismisseds
			ClientPortalAlertRecipients
			ClientPortalAlertRecipientDismisseds
			AlertState

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <DatabaseGenerated(DatabaseGeneratedOption.None)>
        <Required>
		<Column("ALERT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("ALERT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertTypeID() As Integer
		<Required>
		<Column("ALERT_CAT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertCategoryID() As Integer
		<MaxLength(254)>
		<Column("SUBJECT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Subject() As String
		<Column("BODY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Body() As String
		<Column("GENERATED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneratedDate() As Nullable(Of Date)
		<Column("PRIORITY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PriorityLevel() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<MaxLength(100)>
		<Column("ALERT_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(50)>
		<Column("ALERT_LEVEL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertLevel() As String
		<Column("BODY_HTML")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmailBody() As String
		<Column("ALERT_STATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertStateID() As Nullable(Of Integer)
		<Column("ALRT_NOTIFY_HDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplateID() As Nullable(Of Integer)
		<Column("DUE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DueDate() As Nullable(Of Date)
		<MaxLength(10)>
		<Column("TIME_DUE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TimeDue() As String
		<Column("ALERT_USER_CP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientContactID() As Nullable(Of Integer)
		<MaxLength(6)>
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(6)>
		<Column("CMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCode() As String
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<Column("ESTIMATE_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateNumber() As Nullable(Of Integer)
		<Column("EST_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateComponentNumber() As Nullable(Of Short)
		<Column("EST_QUOTE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateQuoteNumber() As Nullable(Of Short)
		<Column("ESTIMATE_REV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateRevisionNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<Column("PO_REVISION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PORevisionNumber() As Nullable(Of Short)
		<Column("PO_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PONumber() As Nullable(Of Integer)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Column("CMP_IDENTIFIER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignID() As Nullable(Of Integer)
		<Column("NON_TASK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NonTaskID() As Nullable(Of Integer)
		<Column("CP_ALERT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCPAlert() As Nullable(Of Short)
		<Column("BA_BATCH_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalBatchID() As Nullable(Of Integer)
		<Column("TASK_SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaskSequenceNumber() As Nullable(Of Short)
		<Column("ALERT_SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertSequenceNumber() As Nullable(Of Short)
		<MaxLength(10)>
		<Column("VER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Version() As String
		<MaxLength(10)>
		<Column("BUILD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Build() As String
		<MaxLength(10)>
		<Column("VER2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Version2() As String
		<MaxLength(10)>
		<Column("BUILD2", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Build2() As String
		<Column("AP_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableID() As Nullable(Of Integer)
		<Column("AP_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AccountPayableSequenceNumber() As Nullable(Of Short)
		<Column("ATB_REV_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaATBRevisionID() As Nullable(Of Integer)
		<Column("LAST_UPDATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastUpdated() As Nullable(Of Date)
        <Column("JOB_VER_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobVersionID() As Nullable(Of Integer)
        <Column("IS_DRAFT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDraft() As Nullable(Of Boolean)
        <Column("ATTACHMENT_COUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AttachmentCount() As Nullable(Of Integer)
        <Column("LAST_UPDATED_USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastUpdatedUserCode() As String
        <Column("LAST_UPDATED_FML", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastUpdatedFullName() As String
        <Column("ASSIGNED_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedEmployeeEmployeeCode() As String
        <Column("ASSIGNED_EMP_FML", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedEmployeeFullName() As String
        <Column("ASSIGN_COMPLETED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignmentCompleted() As Nullable(Of Boolean)
        <Column("LAST_ASSIGNED_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LastAssignedEmployeeCode() As String
        <Column("IS_CS_REVIEW")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsConceptShareReview() As Nullable(Of Boolean)
        <Column("CS_AUTO_APPR_METHOD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareAutoApproveMethodID() As Nullable(Of Integer)
        <Column("CS_REVIEW_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareReviewTypeID() As Nullable(Of Integer)
        <Column("CS_REVIEW_STATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareReviewStatusID() As Nullable(Of Integer)
        <Column("CS_PROJECT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareProjectID() As Nullable(Of Integer)
        <Column("CS_REVIEW_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareReviewID() As Nullable(Of Integer)
        <Column("CS_NUM_REVIEWER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareNumberOfReviewers() As Nullable(Of Integer)
        <Column("CS_NUM_CMPLT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareNumberOfCompletedReviewers() As Nullable(Of Integer)
        <Column("CS_ASSET_IMG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareAssetImage() As Byte()
        <Column("CS_NUM_REJECT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareNumberOfRejectedReviewers() As Nullable(Of Integer)
        <Column("CS_NUM_DEFER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareNumberOfDeferredReviewers() As Nullable(Of Integer)
        <Column("CS_NUM_APPR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ConceptShareNumberOfApprovedReviewers() As Nullable(Of Integer)
        <Column("IS_WORK_ITEM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsWorkItem() As Nullable(Of Boolean)
        <Column("BOARD_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardStateID() As Nullable(Of Integer)
        <Column("EPIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EpicID() As Nullable(Of Integer)
        <Column("HRS_ALLOWED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HoursAllowed() As Nullable(Of Decimal)
        <Column("BACKLOG_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BacklogSequenceNumber() As Nullable(Of Integer)
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)

        Public Overridable Property AlertType As Database.Entities.AlertType
        Public Overridable Property AlertAttachments As ICollection(Of Database.Entities.AlertAttachment)
        Public Overridable Property AlertComments As ICollection(Of Database.Entities.AlertComment)
        Public Overridable Property AlertRecipients As ICollection(Of Database.Entities.AlertRecipient)
        Public Overridable Property AlertCategory As Database.Entities.AlertCategory
        Public Overridable Property AlertRecipientDismisseds As ICollection(Of Database.Entities.AlertRecipientDismissed)
        Public Overridable Property ClientPortalAlertRecipients As ICollection(Of Database.Entities.ClientPortalAlertRecipient)
        Public Overridable Property ClientPortalAlertRecipientDismisseds As ICollection(Of Database.Entities.ClientPortalAlertRecipientDismissed)
        Public Overridable Property AlertState As Database.Entities.AlertState

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
