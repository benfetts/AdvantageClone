Namespace Database.Entities

	<Table("EXPENSE_HEADER")>
	Public Class ExpenseReport
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			InvoiceNumber
			EmployeeCode
			VendorCode
			InvoiceDate
			Description
			Details
			DateFrom
			DateTo
			InvoiceAmount
			ApprovedBy
			ApprovedDate
			Status
			ApproverNotes
			IsSubmitted
			IsApproved
			CreatedBy
			CreatedDate
			ModifiedBy
			ModifiedDate
			SubmittedTo
			BatchDate

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceNumber() As Integer
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Employee")>
		Public Property EmployeeCode() As String
		<MaxLength(6)>
		<Column("VN_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Vendor")>
		Public Property VendorCode() As String
		<Column("INV_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property InvoiceDate() As Nullable(Of Date)
		<MaxLength(30)>
		<Column("EXP_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Column("DTL_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Details() As String
		<Column("DATE_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateFrom() As Nullable(Of Date)
		<Column("DATE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DateTo() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("INV_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceAmount() As Nullable(Of Decimal)
		<MaxLength(6)>
		<Column("APPROVED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedBy() As String
		<Column("APPROVED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedDate() As Nullable(Of Date)
		<Column("STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As Nullable(Of Integer)
		<MaxLength(254)>
		<Column("APPR_NOTES", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApproverNotes() As String
		<Column("SUBMITTED_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsSubmitted() As Nullable(Of Short)
		<Column("APPROVED_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsApproved() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("CREATE_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MOD_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MOD_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("SUBMITTED_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SubmittedTo() As String
		<Column("BATCH_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchDate() As Nullable(Of Date)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.InvoiceNumber

        End Function
        Protected Overrides Sub FinalizeEntityPropertyValidation(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object, ByRef ErrorText As String, IsEntityKey As Boolean, IsNullable As Boolean, IsRequired As Boolean, MaxLength As Integer, Precision As Long, Scale As Long, PropertyType As BaseClasses.PropertyTypes)

            If PropertyName = AdvantageFramework.Database.Entities.ExpenseReport.Properties.InvoiceDate.ToString Then

                If IsValid = False Then

                    If String.IsNullOrEmpty(ErrorText) = False Then

                        ErrorText = ErrorText.Replace("Invoice Date", "Report Date")

                    End If

                End If

            End If

        End Sub

#End Region

	End Class

End Namespace
