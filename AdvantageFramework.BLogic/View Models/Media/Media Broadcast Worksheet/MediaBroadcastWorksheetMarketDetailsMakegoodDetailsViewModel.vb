Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketDetailsMakegoodDetailsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
        Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket

        Public Property DataTable As System.Data.DataTable
        Public Property DetailDates As Hashtable
        Public Property RateDates As Hashtable
        Public Property HiatusDataTable As System.Data.DataTable

        Public Property RowIndex As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.Worksheet = Nothing
            Me.WorksheetMarket = Nothing

        End Sub

#End Region

    End Class

End Namespace
