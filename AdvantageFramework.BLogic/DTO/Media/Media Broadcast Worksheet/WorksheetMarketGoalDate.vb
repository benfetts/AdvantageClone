Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketGoalDate
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketGoalID
			[Date]
			Rate
			WasRateImported
			GRP
			IsHiatus
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketGoalID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property [Date]() As Date
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Rate() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GRP() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsHiatus() As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketGoalID = 0
			Me.[Date] = CDate(Date.MinValue.ToShortDateString)
			Me.Rate = 0
			Me.GRP = 0
			Me.IsHiatus = False

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketGoalDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketGoalDate)

			Me.ID = MediaBroadcastWorksheetMarketGoalDate.ID
			Me.MediaBroadcastWorksheetMarketGoalID = MediaBroadcastWorksheetMarketGoalDate.MediaBroadcastWorksheetMarketGoalID
			Me.[Date] = CDate(MediaBroadcastWorksheetMarketGoalDate.[Date].ToShortDateString)
			Me.Rate = MediaBroadcastWorksheetMarketGoalDate.Rate
			Me.GRP = MediaBroadcastWorksheetMarketGoalDate.GRP
			Me.IsHiatus = MediaBroadcastWorksheetMarketGoalDate.IsHiatus

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketGoalDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketGoalDate)

			MediaBroadcastWorksheetMarketGoalDate.ID = Me.ID
			MediaBroadcastWorksheetMarketGoalDate.MediaBroadcastWorksheetMarketGoalID = Me.MediaBroadcastWorksheetMarketGoalID
			MediaBroadcastWorksheetMarketGoalDate.[Date] = CDate(Me.[Date].ToShortDateString)
			MediaBroadcastWorksheetMarketGoalDate.Rate = Me.Rate
			MediaBroadcastWorksheetMarketGoalDate.GRP = Me.GRP
			MediaBroadcastWorksheetMarketGoalDate.IsHiatus = Me.IsHiatus

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
