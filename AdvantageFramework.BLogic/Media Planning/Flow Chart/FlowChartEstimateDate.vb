Namespace MediaPlanning.FlowChart

    Public Class FlowChartEstimateDate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Day As Integer
        Public Property [Date] As Date
        Public Property WeekStartDate As Date
        Public Property WeekEndDate As Date
        Public Property Week As Integer
        Public Property Month As Integer
        Public Property MonthName As String
        Public Property MonthStartDate As Date
        Public Property MonthEndDate As Date
        Public Property Quarter As Integer
        Public Property QuarterStartDate As Date
        Public Property QuarterEndDate As Date
        Public Property Year As Integer
        Public Property YearStartDate As Date
        Public Property YearEndDate As Date
        Public Property BroadcastWeekStartDate As Date
        Public Property BroadcastWeekEndDate As Date
        Public Property BroadcastWeek As Integer
        Public Property BroadcastMonth As Integer
        Public Property BroadcastMonthName As String
        Public Property BroadcastMonthStartDate As Date
        Public Property BroadcastMonthEndDate As Date
        Public Property BroadcastQuarter As Integer
        Public Property BroadcastQuarterStartDate As Date
        Public Property BroadcastQuarterEndDate As Date
        Public Property BroadcastYear As Integer
        Public Property BroadcastYearStartDate As Date
        Public Property BroadcastYearEndDate As Date

#End Region

#Region " Methods "

        Public Sub New(FlowChartDate As FlowChartDate, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek))

            Me.Day = FlowChartDate.Date.Day
            Me.Date = FlowChartDate.Date

            Me.WeekStartDate = GetCalendarWeekStartDate(FlowChartDate.Date)
            Me.WeekEndDate = GetCalendarWeekEndDate(FlowChartDate.Date)
            Me.Week = FlowChartDate.DateWeek

            Me.Month = FlowChartDate.DateMonth
            Me.MonthName = FlowChartDate.DateMonthName
            Me.MonthStartDate = New Date(FlowChartDate.DateYear, FlowChartDate.DateMonth, 1)
            Me.MonthEndDate = New Date(FlowChartDate.DateYear, FlowChartDate.DateMonth, Date.DaysInMonth(FlowChartDate.DateYear, FlowChartDate.DateMonth))

            Me.Quarter = FlowChartDate.DateQuarter

            If Me.Quarter = 1 Then

                Me.QuarterStartDate = New Date(FlowChartDate.DateYear, 1, 1)
                Me.QuarterEndDate = New Date(FlowChartDate.DateYear, 3, Date.DaysInMonth(FlowChartDate.DateYear, 3))

            ElseIf Me.Quarter = 2 Then

                Me.QuarterStartDate = New Date(FlowChartDate.DateYear, 4, 1)
                Me.QuarterEndDate = New Date(FlowChartDate.DateYear, 6, Date.DaysInMonth(FlowChartDate.DateYear, 6))

            ElseIf Me.Quarter = 3 Then

                Me.QuarterStartDate = New Date(FlowChartDate.DateYear, 7, 1)
                Me.QuarterEndDate = New Date(FlowChartDate.DateYear, 9, Date.DaysInMonth(FlowChartDate.DateYear, 9))

            ElseIf Me.Quarter = 4 Then

                Me.QuarterStartDate = New Date(FlowChartDate.DateYear, 10, 1)
                Me.QuarterEndDate = New Date(FlowChartDate.DateYear, 12, Date.DaysInMonth(FlowChartDate.DateYear, 12))

            End If

            Me.Year = FlowChartDate.DateYear
            Me.YearStartDate = New Date(FlowChartDate.DateYear, 1, 1)
            Me.YearEndDate = New Date(FlowChartDate.DateYear, 12, Date.DaysInMonth(FlowChartDate.DateYear, 12))

            Me.BroadcastWeekStartDate = FlowChartDate.BroadcastDateWeekDate
            Me.BroadcastWeekEndDate = FlowChartDate.BroadcastDateWeekDate.AddDays(6)
            Me.BroadcastWeek = FlowChartDate.BroadcastDateWeek

            Me.BroadcastMonth = FlowChartDate.BroadcastDateMonth
            Me.BroadcastMonthName = FlowChartDate.BroadcastDateMonthName
            Me.BroadcastMonthStartDate = GetBroadcastMonthStartDate(FlowChartDate.BroadcastDateYear, FlowChartDate.BroadcastDateMonth, BroadcastCalendarWeeks)
            Me.BroadcastMonthEndDate = GetBroadcastMonthEndDate(FlowChartDate.BroadcastDateYear, FlowChartDate.BroadcastDateMonth, BroadcastCalendarWeeks)

            Me.BroadcastQuarter = FlowChartDate.BroadcastDateQuarter
            Me.BroadcastQuarterStartDate = GetBroadcastQuarterStartDate(FlowChartDate.BroadcastDateYear, FlowChartDate.BroadcastDateMonth, BroadcastCalendarWeeks)
            Me.BroadcastQuarterEndDate = GetBroadcastQuarterStartDate(FlowChartDate.BroadcastDateYear, FlowChartDate.BroadcastDateMonth, BroadcastCalendarWeeks)

            Me.BroadcastYear = FlowChartDate.BroadcastDateYear
            Me.BroadcastYearStartDate = GetBroadcastYearStartDate(FlowChartDate.BroadcastDateYear, BroadcastCalendarWeeks)
            Me.BroadcastYearEndDate = GetBroadcastYearEndDate(FlowChartDate.BroadcastDateYear, BroadcastCalendarWeeks)

        End Sub
        Private Function GetCalendarWeekStartDate([Date] As Date) As Date

            'objects
            Dim RevisedDate As Date = Date.MinValue

            RevisedDate = [Date]

            If RevisedDate.Day < 7 Then

                Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday OrElse RevisedDate.Day = 1

                    RevisedDate = RevisedDate.AddDays(-1)

                Loop

            Else

                Do Until RevisedDate.DayOfWeek = DayOfWeek.Sunday

                    RevisedDate = RevisedDate.AddDays(-1)

                Loop

            End If

            GetCalendarWeekStartDate = RevisedDate

        End Function
        Private Function GetCalendarWeekEndDate([Date] As Date) As Date

            'objects
            Dim RevisedDate As Date = Date.MinValue

            RevisedDate = [Date]

            Do Until RevisedDate.DayOfWeek = DayOfWeek.Saturday OrElse RevisedDate.Day = Date.DaysInMonth(RevisedDate.Year, RevisedDate.Month)

                RevisedDate = RevisedDate.AddDays(1)

            Loop

            GetCalendarWeekEndDate = RevisedDate

        End Function
        Private Function GetBroadcastMonthStartDate(Year As Integer, Month As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim BroadcastCalendarWeek As AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek = Nothing

            Try

                StartDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year AndAlso Entity.Month = Month).Select(Function(Entity) Entity.WeekDate).Min

            Catch ex As Exception
                StartDate = Date.MinValue
            End Try

            GetBroadcastMonthStartDate = StartDate

        End Function
        Private Function GetBroadcastMonthEndDate(Year As Integer, Month As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim EndDate As Date = Date.MinValue

            Try

                EndDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year AndAlso Entity.Month = Month).Select(Function(Entity) Entity.WeekDate).Max.AddDays(6)

            Catch ex As Exception
                EndDate = Date.MinValue
            End Try

            GetBroadcastMonthEndDate = EndDate

        End Function
        Private Function GetBroadcastQuarterStartDate(Year As Integer, Month As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim StartingMonth As Integer = 0

            Select Case Month

                Case 1, 2, 3

                    StartingMonth = 3

                Case 4, 5, 6

                    StartingMonth = 6

                Case 7, 8, 9

                    StartingMonth = 9

                Case 10, 11, 12

                    StartingMonth = 12

            End Select

            Try

                StartDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year AndAlso Entity.Month = StartingMonth).Select(Function(Entity) Entity.WeekDate).Min

            Catch ex As Exception
                StartDate = Date.MinValue
            End Try

            GetBroadcastQuarterStartDate = StartDate

        End Function
        Private Function GetBroadcastQuarterEndDate(Year As Integer, Month As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim EndDate As Date = Date.MinValue
            Dim EndingMonth As Integer = 0

            Select Case Month

                Case 1, 2, 3

                    EndingMonth = 3

                Case 4, 5, 6

                    EndingMonth = 6

                Case 7, 8, 9

                    EndingMonth = 9

                Case 10, 11, 12

                    EndingMonth = 12

            End Select

            Try

                EndDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year AndAlso Entity.Month = EndingMonth).Select(Function(Entity) Entity.WeekDate).Max.AddDays(6)

            Catch ex As Exception
                EndDate = Date.MinValue
            End Try

            GetBroadcastQuarterEndDate = EndDate

        End Function
        Private Function GetBroadcastYearStartDate(Year As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim StartDate As Date = Date.MinValue

            Try

                StartDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year).Select(Function(Entity) Entity.WeekDate).Min

            Catch ex As Exception
                StartDate = Date.MinValue
            End Try

            GetBroadcastYearStartDate = StartDate

        End Function
        Private Function GetBroadcastYearEndDate(Year As Integer, BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)) As Date

            'objects
            Dim EndDate As Date = Date.MinValue

            Try

                EndDate = BroadcastCalendarWeeks.Where(Function(Entity) Entity.Year = Year).Select(Function(Entity) Entity.WeekDate).Max.AddDays(6)

            Catch ex As Exception
                EndDate = Date.MinValue
            End Try

            GetBroadcastYearEndDate = EndDate

        End Function

#End Region

    End Class

End Namespace