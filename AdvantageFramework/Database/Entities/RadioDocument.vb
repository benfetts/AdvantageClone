Namespace Database.Entities

	<Table("RADIO_DOCUMENT")>
	Public Class RadioDocument
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			DocumentID
			OrderNumber
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<DatabaseGenerated(DatabaseGeneratedOption.None)>
		<Required>
		<Column("DOCUMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property DocumentID() As Integer
		<Required>
		<Column("ORDER_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property OrderNumber() As Integer

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.DocumentID.ToString & " - " & Me.OrderNumber.ToString

		End Function

#End Region

	End Class

End Namespace
