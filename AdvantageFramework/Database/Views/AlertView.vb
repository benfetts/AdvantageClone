Namespace Database.Views

    <Table("WV_MYALERTSLIST")>
    Public Class AlertView
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertID
            Subject
            Generated
            Processed
            UserName
            EmployeeCode
            Priority
            Type
            Category
            AlertTypeID
            AlertCategoryID
            AttachmentCount
            AlertLevel
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            CampaignCode
            JobNumber
            JobComponentNumber
            SenderEmployeeCode
            DismissedDate
            ClientName
            DivisionName
            ProductDescription
            CampaignName
            Body
            LowerSubject
            LowerBody
            OfficeName
            JobDescription
            JobComponentDescription
            AlertUser
            ClientPortalAlert
            NewAlert
            ReadAlert
            VendorCode
            DueDate
            TimeDue
            AlertStateID
            AlertStateName
            CurrentNotify
            CurrentNotifyEmployeeCode
            CurrentNotifyEmployeeFullName
            GroupOffice
            GroupClient
            GroupDivision
            GroupProduct
            GroupJob
            GroupJobComponent
            TaskSequenceNumber
            TaskFunctionCode
            TaskFunctionDescription
            EstimateNumber
            EstimateComponentNumber
            GroupEstimateNumber
            GroupEstimateComponent
            GroupTask
            GroupCampaign
            CampaignID
            Version
            Build
            AlertSequenceNumber
            GroupPriority
            GroupDueDate
            GroupDueDateDisplay
            ID
            Sent
            AlertNotifyHeaderID
            AlertNotifyName
            VendorName

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ALERT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Integer
        <MaxLength(254)>
        <Column("SUBJECT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Subject() As String
        <Column("GENERATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Generated() As Nullable(Of Date)
        <Column("PROCESSED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Processed() As Nullable(Of Date)
        <MaxLength(64)>
        <Column("USER_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserName() As String
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
        <Required>
        <Column("PRIORITY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Priority() As Integer
        <Required>
        <MaxLength(40)>
        <Column("TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
        <Required>
        <MaxLength(40)>
        <Column("CATEGORY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Category() As String
        <Required>
        <Column("ALERT_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertTypeID() As Integer
        <Required>
        <Column("ALERT_CAT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertCategoryID() As Integer
        <Column("ATTACHMENTCOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AttachmentCount() As Nullable(Of Integer)
        <MaxLength(50)>
        <Column("ALERT_LEVEL", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertLevel() As String
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
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
        <MaxLength(6)>
        <Column("SENDER_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SenderEmployeeCode() As String
        <MaxLength(10)>
        <Column("DISMISSED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DismissedDate() As String
        <MaxLength(40)>
        <Column("CL_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
        <MaxLength(40)>
        <Column("DIV_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
        <MaxLength(40)>
        <Column("PRD_DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
        <MaxLength(128)>
        <Column("CMP_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
        <Column("BODY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Body() As String
        <MaxLength(254)>
        <Column("LOWER_SUBJECT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LowerSubject() As String
        <MaxLength(30)>
        <Column("LOWER_BODY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LowerBody() As String
        <MaxLength(30)>
        <Column("OFFICE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
        <MaxLength(60)>
        <Column("JOB_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
        <MaxLength(60)>
        <Column("JOB_COMP_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
        <MaxLength(100)>
        <Column("ALERT_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertUser() As String
        <Column("CP_ALERT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPortalAlert() As Nullable(Of Short)
        <Column("NEW_ALERT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NewAlert() As Nullable(Of Short)
        <Column("READ_ALERT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ReadAlert() As Nullable(Of Short)
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
        <Column("DUE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
        <MaxLength(10)>
        <Column("TIME_DUE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeDue() As String
        <Column("ALERT_STATE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertStateID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("ALERT_STATE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertStateName() As String
        <Column("CURRENT_NOTIFY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentNotify() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("CURRENT_NOTIFY_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentNotifyEmployeeCode() As String
        <MaxLength(64)>
        <Column("CURRENT_NOTIFY_EMP_FML", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CurrentNotifyEmployeeFullName() As String
        <MaxLength(37)>
        <Column("GRP_OFFICE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupOffice() As String
        <MaxLength(49)>
        <Column("GRP_CLIENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupClient() As String
        <MaxLength(57)>
        <Column("GRP_DIVISION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDivision() As String
        <MaxLength(65)>
        <Column("GRP_PRODUCT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupProduct() As String
        <MaxLength(69)>
        <Column("GRP_JOB", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupJob() As String
        <MaxLength(136)>
        <Column("GRP_COMPONENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupJobComponent() As String
        <Column("TASK_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskSequenceNumber() As Nullable(Of Short)
        <MaxLength(10)>
        <Column("TASK_FNC_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskFunctionCode() As String
        <MaxLength(40)>
        <Column("TASK_FNC_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TaskFunctionDescription() As String
        <Column("ESTIMATE_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateNumber() As Nullable(Of Integer)
        <Column("EST_COMPONENT_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
        <MaxLength(67)>
        <Column("GRP_ESTIMATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupEstimateNumber() As String
        <MaxLength(134)>
        <Column("GRP_ESTIMATE_COMPONENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupEstimateComponent() As String
        <MaxLength(51)>
        <Column("GRP_TASK", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupTask() As String
        <Required>
        <MaxLength(69)>
        <Column("GRP_CAMPAIGN", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupCampaign() As String
        <Column("CMP_IDENTIFIER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignID() As Nullable(Of Integer)
        <MaxLength(10)>
        <Column("VER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Version() As String
        <MaxLength(10)>
        <Column("BUILD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Build() As String
        <Column("ALERT_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertSequenceNumber() As Nullable(Of Short)
        <Required>
        <MaxLength(6)>
        <Column("GRP_PRIORITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupPriority() As String
        <MaxLength(64)>
        <Column("GRP_DUE_DATE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDueDate() As String
        <MaxLength(64)>
        <Column("GRP_DUE_DATE_DISPLAY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDueDateDisplay() As String
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Nullable(Of Integer)
        <Column("SENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Sent() As Nullable(Of Date)
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("ALRT_NOTIFY_HDR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertNotifyHeaderID() As Nullable(Of Integer)
        <MaxLength(100)>
        <Column("ALERT_NOTIFY_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertNotifyName() As String
        <Required>
        <MaxLength(1)>
        <Column("VN_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertID.ToString

        End Function

#End Region

    End Class

End Namespace
