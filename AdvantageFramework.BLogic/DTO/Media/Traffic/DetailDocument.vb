Namespace DTO.Media.Traffic

    Public Class DetailDocument
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ParentID
            DaypartDescription
            Length
            StartTime
            EndTime
            AdNumber
            CreativeTitle
            Location
            IsBookend
            BookendName
            'BookendSequenceNumber
            Position
            Rotation
            Filename
            Description
            IsURL
            Link
            CableNetworkStationCodes
            HasDocuments
        End Enum

#End Region

#Region " Variables "

        Private _QueryString As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ParentID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaTrafficCreativeGroupID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DaypartDescription() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Length() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StartTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EndTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AdNumber() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CreativeTitle() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Location() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsBookend() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BookendName() As String
        '<AdvantageFramework.BaseClasses.Attributes.Entity()>
        'Public Property BookendSequenceNumber() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Position() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Rotation As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Filename() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsURL() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Link() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DocumentID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CableNetworkStationCodes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HasDocuments() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
