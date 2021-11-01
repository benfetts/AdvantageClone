Namespace DTO

    Public Class MediaChannel
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Description = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(MediaChannel As AdvantageFramework.Database.Entities.MediaChannel)

            Me.ID = MediaChannel.ID
            Me.Description = MediaChannel.Description
            Me.IsInactive = MediaChannel.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef MediaChannel As AdvantageFramework.Database.Entities.MediaChannel)

            MediaChannel.ID = Me.ID
            MediaChannel.Description = Me.Description
            MediaChannel.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
