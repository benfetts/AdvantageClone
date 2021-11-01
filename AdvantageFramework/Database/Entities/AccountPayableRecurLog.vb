Namespace Database.Entities

	<Table("AP_RECUR_LOG")>
	Public Class AccountPayableRecurLog
        Inherits BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			AccountPayableRecurID
			InvoiceDate
			PostPeriodCode
			UserCode
			DatePosted

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("RECUR_ID")>
		Public Property AccountPayableRecurID() As Integer
		<Column("INVOICE_DATE")>
		Public Property InvoiceDate() As Nullable(Of Date)
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		Public Property PostPeriodCode() As String
		<MaxLength(100)>
		<Column("USER_ID", TypeName:="varchar")>
		Public Property UserCode() As String
		<Column("DATE_POSTED")>
		Public Property DatePosted() As Nullable(Of Date)


#End Region

#Region " Methods "



#End Region

	End Class

End Namespace
