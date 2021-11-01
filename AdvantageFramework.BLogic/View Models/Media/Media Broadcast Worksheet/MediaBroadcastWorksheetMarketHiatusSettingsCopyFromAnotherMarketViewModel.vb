Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketHiatusSettingsCopyFromAnotherMarketViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property SelectedWorksheetMarketRevisionNumber As Integer
        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedWorksheetMarket
            End Get
        End Property

        Public ReadOnly Property HasASelectedWorksheetMarket As Boolean
            Get
                HasASelectedWorksheetMarket = (Me.SelectedWorksheetMarket IsNot Nothing)
            End Get
        End Property

        Public Property WorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
        Public Property SelectedWorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.SelectedWorksheetMarketRevisionNumber = 0
            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

            Me.WorksheetMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
            Me.SelectedWorksheetMarket = Nothing

        End Sub

#End Region

    End Class

End Namespace
