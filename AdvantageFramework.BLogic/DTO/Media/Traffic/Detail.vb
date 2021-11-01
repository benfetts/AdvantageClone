Namespace DTO.Media.Traffic

    Public Class Detail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficCreativeGroupID
            DayPartID
            Length
            StartTime
            EndTime
            AdNumber
            CreativeTitle
            Location
            IsBookend
            BookendName
            BookendSequenceNumber
            Position
            Rotation
            Comment
            HasDocuments
            AdNumberDocument
            Modified
            StartHour
            EndHour
            IsDeleted
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Guid() As Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficCreativeGroupID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.DaypartID, CustomColumnCaption:="Daypart")>
        Public Property DayPartID() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", UseMinValue:=True, MinValue:=1, UseMaxValue:=True, MaxValue:=999)>
        Public Property Length() As Nullable(Of Short)
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartTime() As String
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndTime() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.Methods.PropertyTypes.AdNumber)>
        Public Property AdNumber() As String
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property CreativeTitle() As String
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Location() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property IsBookend() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BookendName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property BookendSequenceNumber() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Position() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", UseMinValue:=True, MinValue:=1, UseMaxValue:=True, MaxValue:=100)>
        Public Property Rotation As Nullable(Of Short)
        <MaxLength(2000)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property Comment() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property HasDocuments() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property AdNumberDocument() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property StartHour() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndHour() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDeleted() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficRevisionID() As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Guid = Guid.NewGuid

        End Sub
        Public Sub New(MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail)

            Guid = Guid.NewGuid

            Me.ID = MediaTrafficDetail.ID
            Me.MediaTrafficCreativeGroupID = MediaTrafficDetail.MediaTrafficCreativeGroupID
            Me.DayPartID = MediaTrafficDetail.DayPartID
            Me.Length = MediaTrafficDetail.Length
            Me.StartTime = MediaTrafficDetail.StartTime
            Me.EndTime = MediaTrafficDetail.EndTime
            Me.AdNumber = MediaTrafficDetail.AdNumber
            Me.CreativeTitle = MediaTrafficDetail.CreativeTitle
            Me.Location = MediaTrafficDetail.Location
            Me.IsBookend = MediaTrafficDetail.IsBookend
            Me.BookendName = MediaTrafficDetail.BookendName
            Me.BookendSequenceNumber = MediaTrafficDetail.BookendSequenceNumber
            Me.Position = MediaTrafficDetail.Position
            Me.Rotation = MediaTrafficDetail.Rotation
            Me.Comment = MediaTrafficDetail.Comment
            Me.Modified = False
            Me.IsDeleted = False
            Me.MediaTrafficRevisionID = MediaTrafficDetail.MediaTrafficCreativeGroup.MediaTrafficRevisionID
            Me.HasDocuments = MediaTrafficDetail.MediaTrafficDetailDocuments.Count > 0
            Me.AdNumberDocument = (MediaTrafficDetail.Ad IsNot Nothing AndAlso MediaTrafficDetail.Ad.DocumentID.HasValue)

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail)

            MediaTrafficDetail.DayPartID = Me.DayPartID
            MediaTrafficDetail.Length = Me.Length
            MediaTrafficDetail.StartTime = Me.StartTime
            MediaTrafficDetail.EndTime = Me.EndTime
            MediaTrafficDetail.AdNumber = Me.AdNumber
            MediaTrafficDetail.CreativeTitle = Me.CreativeTitle
            MediaTrafficDetail.Location = Me.Location
            MediaTrafficDetail.IsBookend = Me.IsBookend
            MediaTrafficDetail.BookendName = Me.BookendName
            MediaTrafficDetail.BookendSequenceNumber = Me.BookendSequenceNumber
            MediaTrafficDetail.Position = Me.Position
            MediaTrafficDetail.Rotation = Me.Rotation
            MediaTrafficDetail.Comment = Me.Comment

        End Sub

#End Region

    End Class

End Namespace
