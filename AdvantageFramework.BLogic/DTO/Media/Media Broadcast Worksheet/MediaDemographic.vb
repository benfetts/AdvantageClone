Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class MediaDemographic
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Description
            IsMales
            IsFemales
            AgeFrom
            AgeTo
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Code() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsMales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsFemales() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AgeFrom() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AgeTo() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.IsMales = False
            Me.IsFemales = False
            Me.AgeFrom = Nothing
            Me.AgeTo = Nothing

        End Sub
        Public Sub New(ID As Integer, Code As String, Description As String, IsMales As Boolean, IsFemales As Boolean, AgeFrom As Nullable(Of Short), AgeTo As Nullable(Of Short))

            Me.ID = ID
            Me.Code = Code
            Me.Description = Description
            Me.IsMales = IsMales
            Me.IsFemales = IsFemales
            Me.AgeFrom = AgeFrom
            Me.AgeTo = AgeTo

        End Sub
        Public Sub New(WorksheetSecondaryDemo As DTO.Media.MediaBroadcastWorksheet.WorksheetSecondaryDemo)

            Me.ID = WorksheetSecondaryDemo.MediaDemographicID
            Me.Code = WorksheetSecondaryDemo.MediaDemographicCode
            Me.Description = WorksheetSecondaryDemo.MediaDemographicDescription
            Me.IsMales = WorksheetSecondaryDemo.IsMales
            Me.IsFemales = WorksheetSecondaryDemo.IsFemales
            Me.AgeFrom = WorksheetSecondaryDemo.AgeFrom
            Me.AgeTo = WorksheetSecondaryDemo.AgeTo

        End Sub
        Public Sub New(MediaDemographic As AdvantageFramework.Database.Entities.MediaDemographic)

            Me.ID = MediaDemographic.ID
            Me.Code = MediaDemographic.Code
            Me.Description = MediaDemographic.Description
            Me.IsMales = MediaDemographic.IsMales
            Me.IsFemales = MediaDemographic.IsFemales
            Me.AgeFrom = MediaDemographic.AgeFrom
            Me.AgeTo = MediaDemographic.AgeTo

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
