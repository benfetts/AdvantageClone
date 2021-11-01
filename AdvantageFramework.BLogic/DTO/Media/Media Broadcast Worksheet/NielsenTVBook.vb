Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class NielsenTVBook
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MediaBroadcastWorksheetMarketNielsenTVBookID
			MediaBroadcastWorksheetMarketID
			Selected
			NielsenTVBookID
			Year
			Month
			Stream
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetMarketNielsenTVBookID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity()>
		Public Property Selected() As Boolean
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property NielsenTVBookID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Year() As Short
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Month() As Short
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Stream() As String

#End Region

#Region " Methods "

		Public Sub New()

			Me.MediaBroadcastWorksheetMarketNielsenTVBookID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Selected = False
			Me.NielsenTVBookID = 0

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketNielsenTVBook As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			Me.MediaBroadcastWorksheetMarketNielsenTVBookID = MediaBroadcastWorksheetMarketNielsenTVBook.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID
			Me.Selected = True
			Me.NielsenTVBookID = MediaBroadcastWorksheetMarketNielsenTVBook.NielsenTVBookID

		End Sub
		Public Sub New(WorksheetMarketNielsenTVBook As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketNielsenTVBook,
					   NielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

			Me.MediaBroadcastWorksheetMarketNielsenTVBookID = WorksheetMarketNielsenTVBook.ID
			Me.MediaBroadcastWorksheetMarketID = WorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID
			Me.Selected = True
			Me.NielsenTVBookID = WorksheetMarketNielsenTVBook.NielsenTVBookID
			Me.Year = NielsenTVBook.Year
			Me.Month = NielsenTVBook.Month
            Me.Stream = NielsenTVBook.Stream

        End Sub
		Public Sub New(NielsenTVBook As AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

			Me.MediaBroadcastWorksheetMarketNielsenTVBookID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Selected = False
			Me.NielsenTVBookID = NielsenTVBook.ID
			Me.Year = NielsenTVBook.Year
			Me.Month = NielsenTVBook.Month
            Me.Stream = NielsenTVBook.Stream

        End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketNielsenTVBook As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketNielsenTVBook)

			MediaBroadcastWorksheetMarketNielsenTVBook.ID = Me.MediaBroadcastWorksheetMarketNielsenTVBookID
			MediaBroadcastWorksheetMarketNielsenTVBook.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketNielsenTVBook.NielsenTVBookID = Me.NielsenTVBookID

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.NielsenTVBookID.ToString

		End Function

#End Region

	End Class

End Namespace
