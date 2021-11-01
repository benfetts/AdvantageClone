Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class DashboardViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Today
        Public Property HoursToday As Decimal = 0.00
        Public Property GoalHoursToday As Decimal = 0.00
        Public ReadOnly Property RequiredHoursToday As Decimal
            Get
                Dim Val As Decimal = 0.00
                Try
                    If (GoalHoursToday - HoursToday) < 0 Then

                        Val = 0

                    Else
                        Val = GoalHoursToday - HoursToday

                    End If
                Catch ex As Exception
                    Val = 0
                End Try
                Return Val

            End Get
        End Property
        ''Public ReadOnly Property DirectHoursToGoalToday As Decimal
        ''    Get

        ''        Return GoalHoursToday - HoursToday

        ''    End Get
        ''End Property
        ''Public ReadOnly Property DirectHoursToGoalTodayPercent As Decimal
        ''    Get

        ''        Return HoursToday / GoalHoursToday * 100

        ''    End Get
        ''End Property

        ''Public Property AgencyHoursToday As Decimal? = 0.00
        ''Public Property NewBusinessHoursToday As Decimal? = 0.00
        ''Public Property ClientHoursToday As Decimal? = 0.00
        ''Public Property IndirectHoursToday As Decimal? = 0.00

        'ThisWeek
        Public Property HoursThisWeek As Decimal = 0.00
        Public Property GoalHoursThisWeek As Decimal = 0.00
        Public ReadOnly Property DirectHoursToGoalThisWeek As Decimal
            Get
                Dim Val As Decimal = 0.00
                Try
                    If (GoalHoursThisWeek - HoursThisWeek) < 0 Then

                        Val = 0

                    Else
                        Val = GoalHoursThisWeek - HoursThisWeek

                    End If
                Catch ex As Exception
                    Val = 0
                End Try
                Return Val

            End Get
        End Property
        Public ReadOnly Property DirectHoursToGoalThisWeekPercent As Decimal
            Get
                Dim Val As Decimal = 0.00
                Try
                    If GoalHoursThisWeek > 0 Then

                        Val = Decimal.Round((HoursThisWeek / GoalHoursThisWeek * 100), 2)

                        If Val > 100.0 Then
                            Val = 100.0
                        End If

                    End If
                Catch ex As Exception
                    Val = 0
                End Try
                Return Val
            End Get
        End Property
        Public Property AgencyHoursThisWeek As Decimal = 0.00
        Public Property NewBusinessHoursThisWeek As Decimal = 0.00
        Public Property ClientHoursThisWeek As Decimal = 0.00
        Public Property IndirectHoursThisWeek As Decimal = 0.00
        Public Property RequiredHoursThisWeek As Decimal = 0.00
        Public ReadOnly Property RequiredHoursWeek As Decimal
            Get
                Dim Val As Decimal = 0.00
                Try
                    If (RequiredHoursThisWeek - HoursThisWeek) < 0 Then

                        Val = 0

                    Else
                        Val = RequiredHoursThisWeek - HoursThisWeek

                    End If
                Catch ex As Exception
                    Val = 0
                End Try
                Return Val

            End Get
        End Property
        Public Property RequiredHoursThisWeekByType As Decimal = 0.00
        Public Property Color As String = ""
        Public Property DarkColor As String = ""

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class TimeSummaryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DayDisplay As Date?

        Public Property Hours As Decimal? = 0.00
        Public Property AgencyHours As Decimal? = 0.00
        Public Property NonBillableHours As Decimal? = 0.00
        Public Property ClientHours As Decimal? = 0.00
        Public Property IndirectHours As Decimal? = 0.00

        Public Property HasStopwatch As Boolean? = False
        Public Property StopwatchEmployeeTimeID As Integer? = 0
        Public Property StopwatchEmployeeTimeDetailID As Short? = 0
        Public Property Selected As Boolean? = False

        Public Property HoursGoal As Decimal? = 0.00

        Public ReadOnly Property ShortDate As String
            Get

                Dim s As String = String.Empty

                Try

                    If DayDisplay IsNot Nothing Then

                        Dim d As Date = DayDisplay
                        s = d.ToShortDateString

                    End If

                Catch ex As Exception
                    s = String.Empty
                End Try

                Return s

            End Get
        End Property
        Public ReadOnly Property DayOfWeekString As String
            Get

                Dim s As String = String.Empty

                Try

                    If DayDisplay IsNot Nothing Then

                        Dim d As Date = DayDisplay
                        s = d.DayOfWeek.ToString

                    End If

                Catch ex As Exception
                    s = String.Empty
                End Try

                Return s

            End Get
        End Property

        Public Property ShortDayOfWeek As String = String.Empty
        Public Property DayMonthDisplay As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class MonthlyHoursViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Hours As Decimal = 0.00
        Public Property Goal As Decimal = 0.00

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class WeeklyGoalsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Total As Decimal = 0.00

#End Region

#Region " Properties "

        Public Property SundayGoal As Decimal? = 0.00
        Public Property MondayGoal As Decimal? = 0.00
        Public Property TuesdayGoal As Decimal? = 0.00
        Public Property WednesdayGoal As Decimal? = 0.00
        Public Property ThursdayGoal As Decimal? = 0.00
        Public Property FridayGoal As Decimal? = 0.00
        Public Property SauturdayGoal As Decimal? = 0.00

        Public ReadOnly Property Total
            Get

                If SundayGoal IsNot Nothing Then _Total += SundayGoal
                If MondayGoal IsNot Nothing Then _Total += MondayGoal
                If TuesdayGoal IsNot Nothing Then _Total += TuesdayGoal
                If WednesdayGoal IsNot Nothing Then _Total += WednesdayGoal
                If ThursdayGoal IsNot Nothing Then _Total += ThursdayGoal
                If FridayGoal IsNot Nothing Then _Total += FridayGoal
                If SauturdayGoal IsNot Nothing Then _Total += SauturdayGoal

                Return _Total

            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
