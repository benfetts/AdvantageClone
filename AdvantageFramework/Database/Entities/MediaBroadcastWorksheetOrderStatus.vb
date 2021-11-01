Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_ORDER_STATUS")>
	Public Class MediaBroadcastWorksheetOrderStatus
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
			MediaBroadcastWorksheetMarketDetailDates
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_ORDER_STATUS_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(25)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String

		Public Overridable Property MediaBroadcastWorksheetMarketDetailDates As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString & " - " & Me.Name.ToString

		End Function

#End Region

	End Class

End Namespace
