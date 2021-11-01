Namespace Classes.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketOrderDate

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			StartDate
			EndDate
			Month
			Year
			MonthWeeks
			WorksheetMarketOrderDateDatas
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property StartDate As Date
		Public Property EndDate As Date
		Public Property Month As Integer
		Public Property Year As Integer
		Public Property MonthWeeks As Generic.List(Of Integer)
		Public Property WorksheetMarketOrderDateDatas As Generic.List(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDateData)

#End Region

#Region " Methods "

		Public Sub New()

			Me.StartDate = Date.MinValue
			Me.EndDate = Date.MinValue
			Me.Month = Date.MinValue.Month
			Me.Year = Date.MinValue.Year
			Me.MonthWeeks = New Generic.List(Of Integer)
			Me.WorksheetMarketOrderDateDatas = New Generic.List(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDateData)

		End Sub
		Public Function Clone() As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDate

			'objects
			Dim WorksheetMarketOrderDate As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDate = Nothing
			Dim WorksheetMarketOrderDateData As AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDateData = Nothing

			WorksheetMarketOrderDate = New AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDate

			WorksheetMarketOrderDate.StartDate = Me.StartDate
			WorksheetMarketOrderDate.EndDate = Me.EndDate
			WorksheetMarketOrderDate.Month = Me.Month
			WorksheetMarketOrderDate.Year = Me.Year
			WorksheetMarketOrderDate.MonthWeeks = Me.MonthWeeks
			WorksheetMarketOrderDate.WorksheetMarketOrderDateDatas = New Generic.List(Of AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDateData)

			For Each WMODD In Me.WorksheetMarketOrderDateDatas

				WorksheetMarketOrderDateData = New AdvantageFramework.Classes.Media.MediaBroadcastWorksheet.WorksheetMarketOrderDateData

				WorksheetMarketOrderDateData.[Date] = WMODD.[Date]
				WorksheetMarketOrderDateData.Month = WMODD.Month
				WorksheetMarketOrderDateData.Year = WMODD.Year
				WorksheetMarketOrderDateData.Week = WMODD.Week

				WorksheetMarketOrderDate.WorksheetMarketOrderDateDatas.Add(WorksheetMarketOrderDateData)

			Next

			Clone = WorksheetMarketOrderDate

		End Function

#End Region

	End Class

End Namespace
