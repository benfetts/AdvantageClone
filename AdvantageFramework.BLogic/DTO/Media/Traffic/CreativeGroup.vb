Namespace DTO.Media.Traffic

    Public Class CreativeGroup
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficRevisionID
            Name
            IsDefault
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficRevisionID As Integer
        <Required>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property IsDefault As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup)

            Me.ID = MediaTrafficCreativeGroup.ID
            Me.MediaTrafficRevisionID = MediaTrafficCreativeGroup.MediaTrafficRevisionID
            Me.Name = MediaTrafficCreativeGroup.Name
            Me.IsDefault = MediaTrafficCreativeGroup.IsDefault

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup)

            MediaTrafficCreativeGroup.Name = Me.Name

        End Sub

#End Region

    End Class

End Namespace
