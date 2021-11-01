Namespace Database.Entities

	<Table("BILL_APPR_HDR")>
	Public Class BillingApprovalHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			BillingApprovalID
			JobNumber
			JobComponentNumber
			EmployeeCode
			ApprovedAmount
			ApprovalComment
			ClientComment
			CreateDate
			CreatedBy
			ARInvoiceNumber
			InvoiceDate
			BillTypeFlag
			IsAdjusted
			ApprovalStatus

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("BA_HDR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("BA_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalID() As Integer
		<Required>
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Integer
		<Required>
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Short
		<Required>
		<MaxLength(6)>
		<Column("ACCT_EXEC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("APPROVED_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedAmount() As Nullable(Of Decimal)
		<Column("APPR_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovalComment() As String
		<Column("CLIENT_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientComment() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreateDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("CREATE_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("AR_INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceNumber() As Nullable(Of Integer)
		<Column("INVOICE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceDate() As Nullable(Of Date)
		<Column("BILL_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BillTypeFlag() As Nullable(Of Byte)
        <Column("ADJUSTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsAdjusted() As Nullable(Of Boolean)
		<Column("APPR_STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovalStatus() As Nullable(Of Short)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
