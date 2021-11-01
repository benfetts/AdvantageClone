Namespace DTO.Media

    Public Class ShareHPUTBook
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ShareBookID
            HPUTBookID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Guid
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Share Book", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenTVBook)>
        Public Property ShareBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="H/PUT Book", PropertyType:=BaseClasses.Methods.PropertyTypes.NielsenTVBook)>
        Public Property HPUTBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaSpotTVResearchBookID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

            ID = Guid.NewGuid

        End Sub
        Public Sub New(MediaSpotTVResearchBook As AdvantageFramework.Database.Entities.MediaSpotTVResearchBook)

            ID = Guid.NewGuid
            ShareBookID = MediaSpotTVResearchBook.ShareBookID
            HPUTBookID = MediaSpotTVResearchBook.HPUTBookID
            MediaSpotTVResearchBookID = MediaSpotTVResearchBook.ID

        End Sub
        Public Sub SaveToEntity(ByRef MediaSpotTVResearchBook As AdvantageFramework.Database.Entities.MediaSpotTVResearchBook)

            MediaSpotTVResearchBook.ShareBookID = Me.ShareBookID
            MediaSpotTVResearchBook.HPUTBookID = Me.HPUTBookID

        End Sub
        Public Sub New(ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook, MediaSpotTVResearchBookID As Integer)

            Me.ID = Guid.NewGuid
            Me.ShareBookID = ComscoreTVBook.ID
            Me.MediaSpotTVResearchBookID = MediaSpotTVResearchBookID

        End Sub

#End Region

    End Class

End Namespace
