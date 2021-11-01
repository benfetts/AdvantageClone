Namespace ViewModels.Maintenance.Media

    Public Class MediaTacticSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsNewRow As Boolean
        Public Property SaveEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public ReadOnly Property HasASelectedMediaTactic As Boolean
            Get
                HasASelectedMediaTactic = (Me.SelectedMediaTactic IsNot Nothing)
            End Get
        End Property

        Public Property MediaTactics As Generic.List(Of AdvantageFramework.DTO.MediaTactic)
        Public Property SelectedMediaTactic As AdvantageFramework.DTO.MediaTactic

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsNewRow = False
            Me.SaveEnabled = False
            Me.DeleteEnabled = False
            Me.CancelEnabled = False

            Me.MediaTactics = New Generic.List(Of AdvantageFramework.DTO.MediaTactic)
            Me.SelectedMediaTactic = Nothing

        End Sub

#End Region

    End Class

End Namespace
