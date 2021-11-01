Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetSecondaryDemo
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetID
			MediaDemographicID
			MediaDemographicCode
            MediaDemographicDescription
            IsMales
            IsFemales
            AgeFrom
            AgeTo
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property MediaBroadcastWorksheetID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaDemographic, CustomColumnCaption:="Media Demographic")>
		Public Property MediaDemographicID() As Integer
		<Required>
		<MaxLength(10)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public Property MediaDemographicCode() As String
		<Required>
		<MaxLength(50)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MediaDemographicDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property IsMales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property IsFemales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property AgeFrom() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property AgeTo() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetID = 0
			Me.MediaDemographicID = 0
			Me.MediaDemographicCode = Nothing
            Me.MediaDemographicDescription = String.Empty
            Me.IsMales = False
            Me.IsFemales = False
            Me.AgeFrom = Nothing
            Me.AgeTo = Nothing

        End Sub
		Public Sub New(MediaBroadcastWorksheetSecondaryDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSecondaryDemo)

			Me.ID = MediaBroadcastWorksheetSecondaryDemo.ID
			Me.MediaBroadcastWorksheetID = MediaBroadcastWorksheetSecondaryDemo.MediaBroadcastWorksheetID
			Me.MediaDemographicID = MediaBroadcastWorksheetSecondaryDemo.MediaDemographicID
			Me.MediaDemographicCode = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.Code, String.Empty)
			Me.MediaDemographicDescription = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.Description, String.Empty)
            Me.IsMales = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.IsMales, False)
            Me.IsFemales = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.IsFemales, False)
            Me.AgeFrom = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.AgeFrom, Nothing)
            Me.AgeTo = If(MediaBroadcastWorksheetSecondaryDemo.MediaDemographic IsNot Nothing, MediaBroadcastWorksheetSecondaryDemo.MediaDemographic.AgeTo, Nothing)

        End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetSecondaryDemo As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSecondaryDemo)

			MediaBroadcastWorksheetSecondaryDemo.ID = Me.ID
			MediaBroadcastWorksheetSecondaryDemo.MediaBroadcastWorksheetID = Me.MediaBroadcastWorksheetID
			MediaBroadcastWorksheetSecondaryDemo.MediaDemographicID = Me.MediaDemographicID

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
