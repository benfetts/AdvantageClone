Namespace Database.Views

    <Table("V_EXPENSE_SUMMARY")>
    Public Class ExpenseSummary
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Employee
            InvoiceNumber
            InvoiceDate
            Description
            Status
            SubmittedTo
            IsSubmitted
            IsApproved
            ApproverNotes
            EmployeeCode
            TotalExpense
            TotalPayable
            DocumentCount
            DetailDescription

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <MaxLength(61)>
        <Column("EMPLOYEE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Employee() As String
        <Key>
        <Required>
        <Column("INV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As Integer
        <Column("INV_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Report Date")>
        Public Property InvoiceDate() As Nullable(Of Date)
        <MaxLength(30)>
        <Column("EXP_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Description() As String
        <Column("STATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Status() As Nullable(Of Integer)
        <MaxLength(6)>
        <Column("SUBMITTED_TO", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SubmittedTo() As String
        <Column("SUBMITTED_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsSubmitted() As Nullable(Of Short)
        <Column("APPROVED_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Status")>
        Public Property IsApproved() As Nullable(Of Short)
        <MaxLength(254)>
        <Column("APPR_NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Approval Comments", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property ApproverNotes() As String
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
        <Column("TOTALEXPENSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="C2", IsReadOnlyColumn:=True)>
        Public Property TotalExpense() As Nullable(Of Decimal)
        <Column("TOTALPAYABLE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="C2", IsReadOnlyColumn:=True)>
        Public Property TotalPayable() As Nullable(Of Decimal)
        <Column("DOC_COUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Documents/Receipts", DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
		Public Property DocumentCount() As Nullable(Of Integer)
		<Column("DTL_DESC", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, DefaultColumnType:=AdvantageFramework.BaseClasses.DefaultColumnTypes.Memo)>
        Public Property DetailDescription() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Employee.ToString

        End Function

#End Region

    End Class

End Namespace
