Namespace Reporting.Database.Views

    <Table("V_DRPT_ALERTS_COMMENT_LIVE")>
    Public Class AlertsWithCommentsReport
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AlertID
            SequenceNumber
            AlertType
            Description
            Subject
            Body
            GeneratedDate
            Priority
            ClientCode
            DivisionCode
            ProductCode
            CampaignCode
            JobNumber
            ComponentNumber
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            VendorCode
            EmployeeCode
            PurchaseOrderNumber
            PurchaseOrderRevisionNumber
            OrderNumber
            RevisionNumber
            UserCode
            PDFDirectory
            AlertLevel
            CampaignIdentifier
            OfficeCode
            GetsAlerts
            BillingApprovalBatchID
            TaskSequence
            TaskDueDate
            AlertAssignmentID
            AlertAssignmentTemplate
            AlertStateID
            AlertState
            TimeDue
            Version
            VersionDescription
            Build
            BuildDescription
            CommentUserCode
            CommentDate
            Comment
            AssignedEmployeeCode
            AssignedEmployeeName

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <Required>
        <Column("AlertID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property AlertID() As Integer
        <Column("SequenceNumber")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Short)
        <Required>
        <MaxLength(40)>
        <Column("AlertType", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertType() As String
        <Required>
        <MaxLength(40)>
        <Column("Description", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <MaxLength(254)>
        <Column("Subject", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Subject() As String
		<Column("Body")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property Body() As String
		<Column("GeneratedDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GeneratedDate() As Nullable(Of Date)
		<Column("Priority")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Priority() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("ClientCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DivisionCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("ProductCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(6)>
		<Column("CampaignCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCode() As String
		<Column("JobNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("ComponentNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ComponentNumber() As Nullable(Of Short)
		<Column("EstimateNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property EstimateNumber() As Nullable(Of Integer)
		<Column("EstimateComponentNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateComponentNumber() As Nullable(Of Short)
		<Column("EstimateQuoteNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateQuoteNumber() As Nullable(Of Short)
		<Column("EstimateRevisionNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EstimateRevisionNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("VendorCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorCode() As String
		<MaxLength(6)>
		<Column("EmployeeCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Column("PurchaseOrderNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property PurchaseOrderNumber() As Nullable(Of Integer)
		<Column("PurchaseOrderRevisionNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PurchaseOrderRevisionNumber() As Nullable(Of Short)
		<Column("OrderNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<Column("RevisionNumber")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RevisionNumber() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("UserCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<MaxLength(254)>
		<Column("PDFDirectory", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PDFDirectory() As String
		<MaxLength(50)>
		<Column("AlertLevel", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertLevel() As String
		<Column("CampaignIdentifier")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignIdentifier() As Nullable(Of Integer)
		<MaxLength(4)>
		<Column("OfficeCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Required>
		<MaxLength(3)>
		<Column("GetsAlerts", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GetsAlerts() As String
		<Column("BillingApprovalBatchID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalBatchID() As Nullable(Of Integer)
		<Column("TaskSequence")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaskSequence() As Nullable(Of Short)
		<Column("TaskDueDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TaskDueDate() As Nullable(Of Date)
		<Column("AlertAssignmentID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentID() As Nullable(Of Integer)
		<MaxLength(100)>
		<Column("AlertAssignmentTemplate", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertAssignmentTemplate() As String
		<Column("AlertStateID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertStateID() As Nullable(Of Integer)
		<MaxLength(100)>
		<Column("AlertState", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertState() As String
		<MaxLength(10)>
		<Column("TimeDue", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property TimeDue() As String
		<MaxLength(10)>
		<Column("Version", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Version() As String
		<MaxLength(100)>
		<Column("VersionDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VersionDescription() As String
		<MaxLength(10)>
		<Column("Build", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Build() As String
		<MaxLength(100)>
		<Column("BuildDescription", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BuildDescription() As String
		<MaxLength(100)>
		<Column("CommentUserCode", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommentUserCode() As String
		<Column("CommentDate")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CommentDate() As Nullable(Of Date)
		<Column("Comment")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
		Public Property Comment() As String
        <MaxLength(6)>
        <Column("AssignedEmployeeCode", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedEmployeeCode() As String
        <MaxLength(64)>
        <Column("AssignedEmployeeName", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AssignedEmployeeName() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
