Namespace Classes.Media

	Public Class BroadcastCalendarWeek

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			Year
			Week
			Month
			WeekDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property Year() As Integer
		Public Property Week() As Integer
		Public Property Month() As Integer
		Public Property WeekDate() As Date

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.WeekDate.ToShortDateString

		End Function

#End Region

	End Class

End Namespace