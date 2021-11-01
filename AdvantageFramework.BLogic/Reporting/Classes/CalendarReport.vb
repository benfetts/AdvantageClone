Namespace Reporting.Classes

    Public Class CalendarReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Public ReadOnly Property CalendarWeekStart As Date
        '    Get
        '        'objects
        '        Dim WeekStartDate As Date = Nothing

        '        WeekStartDate = Me.StartDate

        '        If WeekStartDate.DayOfWeek <> DayOfWeek.Sunday Then

        '            WeekStartDate = WeekStartDate.AddDays(-CInt(WeekStartDate.DayOfWeek))

        '        End If

        '        Return WeekStartDate

        '    End Get
        'End Property
        'Public ReadOnly Property CalendarWeekEnd As Date
        '    Get
        '        'objects
        '        Dim WeekEndDate As Date = Nothing

        '        WeekEndDate = Me.EndDate

        '        If WeekEndDate.DayOfWeek <> DayOfWeek.Saturday Then

        '            WeekEndDate = WeekEndDate.AddDays(6 - CInt(WeekEndDate.DayOfWeek))

        '        End If

        '        Return WeekEndDate

        '    End Get
        'End Property
        'Public ReadOnly Property StartDate As Date
        '    Get

        '        'Dim MinDate As Date = Nothing

        '        'If CalendarItems IsNot Nothing AndAlso CalendarItems.Count > 0 Then

        '        '    MinDate = CalendarItems.Select(Function(ci) ci.StartDate).Min

        '        '    MinDate = New Date(MinDate.Year, MinDate.Month, 1)

        '        '    Return MinDate

        '        'Else

        '        '    Return Nothing

        '        'End If

        '    End Get
        'End Property
        'Public ReadOnly Property EndDate As Date
        '    Get

        '        'Dim MaxDate As Date = Nothing

        '        'If CalendarItems IsNot Nothing AndAlso CalendarItems.Count > 0 Then

        '        '    MaxDate = CalendarItems.Select(Function(ci) ci.EndDate).Max

        '        '    MaxDate = New Date(MaxDate.Year, MaxDate.Month, 1).AddMonths(1).AddDays(-1)

        '        '    Return MaxDate

        '        'Else

        '        '    Return Nothing

        '        'End If

        '    End Get
        'End Property
        Public Property Worksheets As Generic.List(Of Worksheet)
        Public Property ReportTitle As String
        Public Property LogoLocation As String
        Public Property TitleAlignment As Short '0: Left, 1: Right, 2: Center

#End Region

#Region " Methods "

        Public Function GetLastDayOfWeekInSameMonth(ByVal CurrentDate As Date) As Date

            'objects
            Dim LastDayOfWeekInSameMonth As Date = Nothing

            LastDayOfWeekInSameMonth = CurrentDate

            While LastDayOfWeekInSameMonth.DayOfWeek <> DayOfWeek.Saturday AndAlso LastDayOfWeekInSameMonth.AddDays(1).Month = CurrentDate.Month

                LastDayOfWeekInSameMonth = LastDayOfWeekInSameMonth.AddDays(1)

            End While

            Return LastDayOfWeekInSameMonth

        End Function
        Public Function AddWorksheet() As Worksheet

            Me.AddWorksheet(New Worksheet)

            Return Me.Worksheets.Last

        End Function
        Public Sub AddWorksheet(ByVal Worksheet As Worksheet)

            If Me.Worksheets Is Nothing Then

                Me.Worksheets = New List(Of Worksheet)

            End If

            Me.Worksheets.Add(Worksheet)

        End Sub
        Public Sub New()

            Me.ReportTitle = "Calendar Report"
            Me.Worksheets = New List(Of Worksheet)

        End Sub

#End Region

#Region " Classes "

#Region " Class: Worksheet "

        Public Class Worksheet

#Region " Variables "

            Private _MinimumRowsPerDate As Integer = 5

#End Region

#Region " Properties "

            Public Property Name As String
            Public Property Subtitle As Object
            Public Property CalendarItems As Generic.List(Of CalendarItem)
            Public Property MinimumRowsPerDate As Integer
                Get
                    MinimumRowsPerDate = _MinimumRowsPerDate
                End Get
                Set(value As Integer)
                    _MinimumRowsPerDate = value
                End Set
            End Property

#End Region

#Region " Methods "

            Public Function GetNumberOfRowsNeeded(ByVal CalendarDate As Date, ByVal DueDateView As Boolean) As Integer

                'objects
                Dim FirstDayOfWeek As Date = Nothing
                Dim LastDayOfWeek As Date = Nothing
                Dim Items As Integer = 0
                Dim MaxItems As Integer = 0


                FirstDayOfWeek = CalendarDate
                LastDayOfWeek = CalendarDate

                While FirstDayOfWeek.DayOfWeek <> DayOfWeek.Sunday AndAlso FirstDayOfWeek.AddDays(-1).Month = FirstDayOfWeek.Month

                    FirstDayOfWeek = FirstDayOfWeek.AddDays(-1)

                End While

                While LastDayOfWeek.DayOfWeek <> DayOfWeek.Saturday AndAlso LastDayOfWeek.AddDays(1).Month = FirstDayOfWeek.Month

                    LastDayOfWeek = LastDayOfWeek.AddDays(1)

                End While

                While FirstDayOfWeek <= LastDayOfWeek

                    If DueDateView Then

                        Items = (From Item In Me.CalendarItems
                                 Let EndDateNoTime = New Date(Item.EndDate.Year, Item.EndDate.Month, Item.EndDate.Day)
                                 Where EndDateNoTime = FirstDayOfWeek
                                 Select Item).Count

                    Else

                        Items = (From Item In Me.CalendarItems
                                 Let StartDateNoTime = New Date(Item.StartDate.Year, Item.StartDate.Month, Item.StartDate.Day),
                                     EndDateNoTime = New Date(Item.EndDate.Year, Item.EndDate.Month, Item.EndDate.Day)
                                 Where StartDateNoTime <= FirstDayOfWeek AndAlso
                                       EndDateNoTime >= FirstDayOfWeek
                                 Select Item).Count

                    End If

                    If Items > MaxItems Then

                        MaxItems = Items

                    End If

                    FirstDayOfWeek = FirstDayOfWeek.AddDays(1)

                End While

                Return Math.Max(MaxItems + 1, Me.MinimumRowsPerDate)

            End Function
            Public Sub New()

                Me.CalendarItems = New List(Of CalendarItem)

            End Sub

#End Region

        End Class

#End Region

#Region " Class: CalendarItem "

        Public Class CalendarItem

#Region " Properties "

            Public Property Description As String
            Public Property StartDate As Date
            Public Property EndDate As Date
            Public Property Background As String
            Public Property JobNumber As Integer
            Public Property JobComponentNumber As Short
            Public Property IsEvent As Boolean
            Public Property IsEventTask As Boolean

#End Region

#Region " Methods "

            Public Sub New()


            End Sub

#End Region

        End Class

#End Region

#End Region

    End Class

End Namespace


