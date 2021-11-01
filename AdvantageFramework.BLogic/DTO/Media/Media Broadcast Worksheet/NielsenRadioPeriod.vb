Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class NielsenRadioPeriod
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MediaBroadcastWorksheetMarketNielsenRadioPeriodID
			MediaBroadcastWorksheetMarketID
			Selected
			NielsenRadioPeriodID
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetMarketNielsenRadioPeriodID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Selected() As Boolean
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book")>
		Public Property NielsenRadioPeriodID() As Integer

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetMarketNielsenRadioPeriodID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Selected = False
			Me.NielsenRadioPeriodID = 0

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketNielsenRadioPeriod As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			Me.MediaBroadcastWorksheetMarketNielsenRadioPeriodID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID
			Me.Selected = True
			Me.NielsenRadioPeriodID = MediaBroadcastWorksheetMarketNielsenRadioPeriod.NielsenRadioPeriodID

		End Sub
		Public Sub New(WorksheetMarketNielsenRadioPeriod As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenRadioPeriod)

			Me.MediaBroadcastWorksheetMarketNielsenRadioPeriodID = WorksheetMarketNielsenRadioPeriod.ID
			Me.MediaBroadcastWorksheetMarketID = WorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID
			Me.Selected = True
			Me.NielsenRadioPeriodID = WorksheetMarketNielsenRadioPeriod.NielsenRadioPeriodID

		End Sub
		Public Sub New(NielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod)

			Me.MediaBroadcastWorksheetMarketNielsenRadioPeriodID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Selected = False
			Me.NielsenRadioPeriodID = NielsenRadioPeriod.ID

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketNielsenRadioPeriod As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenRadioPeriod)

			MediaBroadcastWorksheetMarketNielsenRadioPeriod.ID = Me.MediaBroadcastWorksheetMarketNielsenRadioPeriodID
			MediaBroadcastWorksheetMarketNielsenRadioPeriod.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketNielsenRadioPeriod.NielsenRadioPeriodID = Me.NielsenRadioPeriodID

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.NielsenRadioPeriodID.ToString

		End Function

#End Region

	End Class

End Namespace
