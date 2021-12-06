Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketAddViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)
        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSelection)

        Public Property NielsenRadioMarkets As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioMarket)

        Public ReadOnly Property AddEnabled As Boolean
            Get
                AddEnabled = Me.HasAtleastOneMarketSelected
            End Get
        End Property
        Public ReadOnly Property HasAtleastOneMarketSelected As Boolean
            Get
                HasAtleastOneMarketSelected = (Me.Markets IsNot Nothing AndAlso Me.Markets.Any(Function(Entity) Entity.Selected = True))
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0

            Me.Worksheet = Nothing
            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketSelection)

            Me.NielsenRadioMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.NielsenRadioMarket)

        End Sub

#End Region

    End Class

End Namespace
