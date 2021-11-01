Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_DATE")>
	Public Class MediaBroadcastWorksheetMarketGoalDate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketGoalID
			[Date]
			Rate
			GRP
			IsHiatus
			MediaBroadcastWorksheetMarketGoal
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_DATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketGoalID() As Integer
		<Required>
		<Column("DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property [Date]() As Date
		<Required>
		<Column("RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 4)>
		Public Property Rate() As Decimal
		<Required>
		<Column("GRP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
		Public Property GRP() As Decimal
		<Required>
		<Column("IS_HIATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsHiatus() As Boolean

		Public Overridable Property MediaBroadcastWorksheetMarketGoal As Database.Entities.MediaBroadcastWorksheetMarketGoal

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
