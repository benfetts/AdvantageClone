Namespace DTO

    Public Class MediaTactic
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
        Public Sub New(MediaTactic As AdvantageFramework.Database.Entities.MediaTactic)

            Me.ID = MediaTactic.ID
            Me.Description = MediaTactic.Description
            Me.IsInactive = MediaTactic.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef MediaTactic As AdvantageFramework.Database.Entities.MediaTactic)

            MediaTactic.ID = Me.ID
            MediaTactic.Description = Me.Description
            MediaTactic.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
