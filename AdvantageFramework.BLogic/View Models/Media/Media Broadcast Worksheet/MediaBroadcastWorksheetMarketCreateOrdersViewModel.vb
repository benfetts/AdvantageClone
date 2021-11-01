Namespace ViewModels.Media.MediaBroadcastWorksheet

	Public Class MediaBroadcastWorksheetMarketCreateOrdersViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CreateOrdersByWeekEnabled As Boolean

        Public Property MediaBroadcastWorksheetID As Integer
        Public Property MediaBroadcastWorksheetMarketID As Integer
		Public Property Worksheet As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.Worksheet
		Public Property WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket

		Public Property WorksheetDates As Generic.List(Of Date) = Nothing
		Public Property WorksheetStartDates As Generic.List(Of Date) = Nothing
		Public Property WorksheetEndDates As Generic.List(Of Date) = Nothing
		Public Property BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.Classes.Media.BroadcastCalendarWeek) = Nothing

		Public Property StartDate As Date
		Public Property EndDate As Date
        Public Property CreateOrdersByWeek As Boolean
        Public Property MinEndDateAllowed As Date

#End Region

#Region " Methods "

        Public Sub New()

            Me.CreateOrdersByWeekEnabled = False

            Me.MediaBroadcastWorksheetID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.Worksheet = Nothing
			Me.WorksheetMarket = Nothing

			Me.WorksheetDates = New Generic.List(Of Date)
			Me.WorksheetStartDates = New Generic.List(Of Date)
			Me.WorksheetEndDates = New Generic.List(Of Date)
			Me.BroadcastCalendarWeeks = New Generic.List(Of AdvantageFramework.Classes.Media.BroadcastCalendarWeek)

			Me.StartDate = Date.MinValue
            Me.EndDate = Date.MinValue
            Me.CreateOrdersByWeek = False
            Me.MinEndDateAllowed = Date.MinValue

        End Sub

#End Region

	End Class

End Namespace
