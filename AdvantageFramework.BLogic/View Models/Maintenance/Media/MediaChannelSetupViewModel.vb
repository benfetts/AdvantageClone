Namespace ViewModels.Maintenance.Media

    Public Class MediaChannelSetupViewModel

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

        Public ReadOnly Property HasASelectedMediaChannel As Boolean
            Get
                HasASelectedMediaChannel = (Me.SelectedMediaChannel IsNot Nothing)
            End Get
        End Property

        Public Property MediaChannels As Generic.List(Of AdvantageFramework.DTO.MediaChannel)
        Public Property SelectedMediaChannel As AdvantageFramework.DTO.MediaChannel

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsNewRow = False
            Me.SaveEnabled = False
            Me.DeleteEnabled = False
            Me.CancelEnabled = False

            Me.MediaChannels = New Generic.List(Of AdvantageFramework.DTO.MediaChannel)
            Me.SelectedMediaChannel = Nothing

        End Sub

#End Region

    End Class

End Namespace
