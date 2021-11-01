Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketNielsenRadioPeriod
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			NielsenRadioPeriodID
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
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property NielsenRadioPeriodID() As Integer

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.NielsenRadioPeriodID = 0

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketNielsenRadioPeriod As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			Me.ID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID
			Me.NielsenRadioPeriodID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.NielsenRadioPeriodID

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketNielsenRadioPeriod As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			MediaBroadcastWorksheetMarketNielsenRadioPeriod.ID = Me.ID
			MediaBroadcastWorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketNielsenRadioPeriod.NielsenRadioPeriodID = Me.NielsenRadioPeriodID

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
