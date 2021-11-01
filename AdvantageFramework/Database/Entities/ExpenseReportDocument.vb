Namespace Database.Entities

	<Table("EXPENSE_DOCS")>
	Public Class ExpenseReportDocument
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			DocumentID
			InvoiceNumber
			Document

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("DOCUMENT_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DocumentID() As Integer
		<Key>
		<Required>
        <Column("INV_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceNumber() As Integer

        Public Overridable Property Document As Database.Entities.Document

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DocumentID

        End Function

#End Region

	End Class

End Namespace
