Namespace Database.Views

    <Table("V_ESTIMATEAPPR")>
    Public Class EstimateApproval
        Inherits BaseClasses.EntityView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobComponentNumber
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            EstimateApprovalType
            ClientApprovedByName
            ClientApprovedDate
            ClientPurchaseOrderNumber
            ClientEmployeeCode
            ClientApprovedPassword
            ClientApprovalPassword
            ClientCreatedUserCode
            ClientCreatedDate
            ClientApprovalNotes
            InternalApprovedBy
            InternalApprovedDate
            InternalEmployeeCode
            InternalApprovedPassword
            InternalApprovalPassword
            InternalCreatedUserCodeCode
            InternalCreatedDate
            InternalApprovalNotes
            JobComponent
            EstimateRevision

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key, ForeignKey("JobComponent")>
		<Required>
        <Column("JOB_NUMBER", Order:=0)>
        Public Property JobNumber() As Integer
		<Key, ForeignKey("JobComponent")>
		<Required>
        <Column("JOB_COMPONENT_NBR", Order:=1)>
        Public Property JobComponentNumber() As Short
        <Required>
        <Column("ESTIMATE_NUMBER")>
        Public Property EstimateNumber() As Integer
        <Required>
        <Column("EST_COMPONENT_NBR")>
        Public Property EstimateComponentNumber() As Short
        <Required>
        <Column("EST_QUOTE_NBR")>
        Public Property EstimateQuoteNumber() As Short
        <Required>
        <Column("EST_REVISION_NBR")>
        Public Property EstimateRevisionNumber() As Short
        <Column("TYPE")>
        Public Property EstimateApprovalType() As Nullable(Of Integer)
        <MaxLength(40)>
        <Column("CL_EST_APPR_BY", TypeName:="varchar")>
        Public Property ClientApprovedByName() As String
        <Column("CL_EST_APPR_DATE")>
        Public Property ClientApprovedDate() As Nullable(Of Date)
        <MaxLength(20)>
        <Column("CL_EST_APPR_PO_NBR", TypeName:="varchar")>
        Public Property ClientPurchaseOrderNumber() As String
        <MaxLength(6)>
        <Column("CL_EMP_CODE", TypeName:="varchar")>
        Public Property ClientEmployeeCode() As String
        <MaxLength(10)>
        <Column("CL_APPR_PWD", TypeName:="varchar")>
        Public Property ClientApprovedPassword() As String
        <Column("CL_APPROVAL_PWD")>
        Public Property ClientApprovalPassword() As Nullable(Of Short)
        <MaxLength(100)>
        <Column("CL_CREATE_USER", TypeName:="varchar")>
        Public Property ClientCreatedUserCode() As String
		<Column("CL_CREATE_DATE")>
		Public Property ClientCreatedDate() As Nullable(Of Date)
		<Column("CL_APPR_NOTES")>
		Public Property ClientApprovalNotes() As String
		<MaxLength(40)>
		<Column("IN_EST_APPR_BY", TypeName:="varchar")>
		Public Property InternalApprovedBy() As String
		<Column("IN_EST_APPR_DATE")>
		Public Property InternalApprovedDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("IN_EMP_CODE", TypeName:="varchar")>
		Public Property InternalEmployeeCode() As String
		<MaxLength(10)>
		<Column("IN_APPR_PWD", TypeName:="varchar")>
		Public Property InternalApprovedPassword() As String
		<Column("IN_APPROVAL_PWD")>
		Public Property InternalApprovalPassword() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("IN_CREATE_USER", TypeName:="varchar")>
		Public Property InternalCreatedUserCodeCode() As String
		<Column("IN_CREATE_DATE")>
		Public Property InternalCreatedDate() As Nullable(Of Date)
		<Column("IN_APPR_NOTES")>
        Public Property InternalApprovalNotes() As String

		Public Overridable Property JobComponent As Database.Entities.JobComponent
        <ForeignKey("EstimateNumber, EstimateComponentNumber, EstimateQuoteNumber, EstimateRevisionNumber")>
        Public Overridable Property EstimateRevision As Database.Entities.EstimateRevision

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber

        End Function

#End Region

    End Class

End Namespace
