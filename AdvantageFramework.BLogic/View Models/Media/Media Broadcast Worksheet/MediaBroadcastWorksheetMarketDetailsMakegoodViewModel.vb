Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketDetailsMakegoodViewModel

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
        Public Property OriginalDataRow As System.Data.DataRow

#End Region

#Region " Methods "

        Public Sub New()

			Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

            'Me.[Date] = Date.MinValue
            'Me.RemoveSpots = 1
            'Me.MaximunTotalSpots = 0
            'Me.RowIndex = -1
            'Me.DateColumn = String.Empty
            'Me.IsRowBookend = False

        End Sub

#End Region

	End Class

End Namespace
