Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketSubmarketsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property AddMarketGroupsEnabled As Boolean

        Public Property AddEnabled As Boolean
        Public Property AddAllEnabled As Boolean
        Public Property RemoveEnabled As Boolean
        Public Property RemoveAllEnabled As Boolean

        Public Property MoveUpEnabled As Boolean
        Public Property MoveDownEnabled As Boolean

        Public Property MediaBroadcastWorksheetMarketID As Integer

        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)

        Public Property AvailableMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)
        Public Property SelectedMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)

        Public Property CountryID As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = True
            Me.CancelEnabled = True

            Me.AddMarketGroupsEnabled = True

            Me.AddEnabled = False
            Me.AddAllEnabled = False
            Me.RemoveEnabled = False
            Me.RemoveAllEnabled = False

            Me.MoveUpEnabled = False
            Me.MoveDownEnabled = False

            Me.MediaBroadcastWorksheetMarketID = 0

            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)

            Me.AvailableMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)
            Me.SelectedMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSubmarket)

            Me.CountryID = 0

        End Sub

#End Region

    End Class

End Namespace
