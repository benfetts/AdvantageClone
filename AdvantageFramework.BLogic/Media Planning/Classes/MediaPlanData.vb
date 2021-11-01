Namespace MediaPlanning.Classes

	Public Class MediaPlanData

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			VendorCode
			RowIndex
			StartDate
			Week
			Month
			Year
			Quarter
			MediaPlanData
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property VendorCode As String
		Public Property RowIndex As Integer
		Public Property StartDate As Date
		Public Property Week As Integer
		Public Property Month As Integer
		Public Property Year As Integer
		Public Property Quarter As Integer
		Public Property Rate As Decimal?
		Public Property DayOfWeeks As String

		Public Property MediaPlanDataDetails As Generic.List(Of AdvantageFramework.Exporting.DataClasses.MediaPlanningData)

#End Region

#Region " Methods "



#End Region

	End Class

End Namespace
