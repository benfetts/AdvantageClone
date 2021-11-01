Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketVendorOrderCommentsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UpdateEnabled As Boolean

        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet = Nothing
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket = Nothing

        Public Property WorksheetMarketVendorOrderCommentsList As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorOrderComments)

#End Region

#Region " Methods "

        Public Sub New()

            Me.UpdateEnabled = False

            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

            Me.WorksheetMarketVendorOrderCommentsList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketVendorOrderComments)

        End Sub

#End Region

    End Class

End Namespace
