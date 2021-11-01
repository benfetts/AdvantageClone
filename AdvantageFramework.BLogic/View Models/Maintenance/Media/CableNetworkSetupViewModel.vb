Namespace ViewModels.Maintenance.Media

    Public Class CableNetworkSetupViewModel

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

        Public ReadOnly Property HasASelectedCableNetworkStation As Boolean
            Get
                HasASelectedCableNetworkStation = (Me.SelectedCableNetworkStation IsNot Nothing)
            End Get
        End Property

        Public Property CableNetworkStations As Generic.List(Of AdvantageFramework.DTO.CableNetworkStation)
        Public Property SelectedCableNetworkStation As AdvantageFramework.DTO.CableNetworkStation

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsNewRow = False
            Me.SaveEnabled = False
            Me.DeleteEnabled = False
            Me.CancelEnabled = False

            Me.CableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.CableNetworkStation)
            Me.SelectedCableNetworkStation = Nothing

        End Sub

#End Region

    End Class

End Namespace
