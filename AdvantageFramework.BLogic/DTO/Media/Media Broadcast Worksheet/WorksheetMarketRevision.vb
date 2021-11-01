Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketRevision
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			RevisionNumber
			Comment
			CreatedByUserCode
			CreatedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
		Public Property RevisionNumber() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property Comment() As String
		<Required>
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
		Public Property CreatedByUserCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
		Public Property CreatedDate() As Date

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.RevisionNumber = 0
			Me.Comment = String.Empty
			Me.CreatedByUserCode = String.Empty
			Me.CreatedDate = Date.MinValue

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketRevision As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketRevision)

			Me.ID = MediaBroadcastWorksheetMarketRevision.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketRevision.MediaBroadcastWorksheetMarketID
			Me.RevisionNumber = MediaBroadcastWorksheetMarketRevision.RevisionNumber
			Me.Comment = MediaBroadcastWorksheetMarketRevision.Comment
			Me.CreatedByUserCode = MediaBroadcastWorksheetMarketRevision.CreatedByUserCode
			Me.CreatedDate = MediaBroadcastWorksheetMarketRevision.CreatedDate

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketRevision As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketRevision)

			MediaBroadcastWorksheetMarketRevision.ID = Me.ID
			MediaBroadcastWorksheetMarketRevision.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketRevision.RevisionNumber = Me.RevisionNumber
			MediaBroadcastWorksheetMarketRevision.Comment = Me.Comment
			MediaBroadcastWorksheetMarketRevision.CreatedByUserCode = Me.CreatedByUserCode
			MediaBroadcastWorksheetMarketRevision.CreatedDate = Me.CreatedDate

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
