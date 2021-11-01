Namespace MediaPlanning.Classes

	<Serializable()>
	Public Class WeekStartAndEndDates

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			StartDate
			EndDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property StartDate As Date
		Public Property EndDate As Date

#End Region

#Region " Methods "

		Public Sub New(StartDate As Date, EndDate As Date)

			Me.StartDate = StartDate
			Me.EndDate = EndDate

		End Sub

#End Region

	End Class

End Namespace

