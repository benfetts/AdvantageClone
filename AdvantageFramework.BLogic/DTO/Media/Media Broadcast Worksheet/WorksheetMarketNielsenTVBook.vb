Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketNielsenTVBook
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			NielsenTVBookID
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
		Public Property NielsenTVBookID() As Integer

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.NielsenTVBookID = 0

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketNielsenTVBook As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			Me.ID = MediaBroadcastWorksheetMarketNielsenTVBook.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID
			Me.NielsenTVBookID = MediaBroadcastWorksheetMarketNielsenTVBook.NielsenTVBookID

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketNielsenTVBook As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			MediaBroadcastWorksheetMarketNielsenTVBook.ID = Me.ID
			MediaBroadcastWorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketNielsenTVBook.NielsenTVBookID = Me.NielsenTVBookID

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
