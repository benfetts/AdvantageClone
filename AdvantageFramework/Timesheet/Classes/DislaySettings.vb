Namespace Timesheet.Settings

    <Serializable()> Public Class DisplaySettings

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DaysToDisplay As TimesheetSettings.DaysToShow
        Public Property ShowCommentsUsing As String = "icon"
        Public Property StartTimesheetOnDayOfWeek As DayOfWeek = DayOfWeek.Sunday
        Public Property [Labels] As Labels
        Public Property DisablePagingOnMainGrid As Boolean = False
        Public Property RepeatRowForAllDays As Boolean = False
        Public Property OnlyShowMyProgress As Boolean = False
        Public Property AgencyOverride As Boolean = False

#End Region

#Region " Methods "

        Sub New()

            [Labels] = New Labels()

        End Sub

#End Region

    End Class

End Namespace

