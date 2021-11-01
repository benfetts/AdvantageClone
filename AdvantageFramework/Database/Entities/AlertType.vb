Namespace Database.Entities

	<Table("ALERT_TYPE")>
	Public Class AlertType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			Alerts
			AlertCategories

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("ALERT_TYPE_ID")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(40)>
		<Column("ALERT_TYPE_DESC", TypeName:="varchar")>
		Public Property Description() As String

        Public Overridable Property Alerts As ICollection(Of Database.Entities.Alert)
        Public Overridable Property AlertCategories As ICollection(Of Database.Entities.AlertCategory)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
