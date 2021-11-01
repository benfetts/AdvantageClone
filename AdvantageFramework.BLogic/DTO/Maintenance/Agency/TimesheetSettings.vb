Namespace DTO.Maintenance.Agency

    Public Class TimesheetSettings

        Public Property DisplaySettings As AdvantageFramework.Timesheet.Settings.DisplaySettings

        Public Property DaysToDisplayList As Generic.List(Of Item)

        Public Property StartWeekOnList As Generic.List(Of Day)

        Public Property ShowCommentsList As Generic.List(Of Item)

        Public Property StopwatchMinimumTimeList As Generic.List(Of Item)

        Public Property StopwatchRoundToNextIncrementList As Generic.List(Of Item)

        Public Property AllTimeEntryMinimumTimeList As Generic.List(Of Item)

        Public Property AllTimeEntryRoundToNextIncrementList As Generic.List(Of Item)

        Public Property AgencyTimeEntryOptions As AgencyTimeEntryOptions

        Public Sub New()

            DisplaySettings = New Timesheet.Settings.DisplaySettings()
            DaysToDisplayList = GetDaysToDisplayList()
            StartWeekOnList = GetStartWeekOnDays()
            ShowCommentsList = GetShowCommentsList()
            StopwatchMinimumTimeList = GetStopwatchMinimumTimeList()
            StopwatchRoundToNextIncrementList = GetStopwatchRoundToNextIncrementList()
            AllTimeEntryMinimumTimeList = GetAllTimeEntryMinimumTimeList()
            AllTimeEntryRoundToNextIncrementList = GetAllTimeEntryRoundToNextIncrementList()
            AgencyTimeEntryOptions = New AgencyTimeEntryOptions()

        End Sub

        Public Function GetDaysToDisplayList() As Generic.List(Of Item)

            Dim Items As New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "1", .Value = "1"})
            Items.Add(New Item() With {.Description = "5", .Value = "5"})
            Items.Add(New Item() With {.Description = "7", .Value = "7"})

            Return Items

        End Function

        Private Function GetStartWeekOnDays() As Generic.List(Of Day)

            Dim Days = New Generic.List(Of Day)

            Days.Add(New Day() With {.Description = "Saturday", .Value = 6})
            Days.Add(New Day() With {.Description = "Sunday", .Value = 0})
            Days.Add(New Day() With {.Description = "Monday", .Value = 1})

            Return Days

        End Function

        Private Function GetShowCommentsList() As Generic.List(Of Item)

            Dim Items As New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "Icon", .Value = "icon"})
            Items.Add(New Item() With {.Description = "Textbox", .Value = "textbox"})
            Items.Add(New Item() With {.Description = "None", .Value = "none"})


            Return Items

        End Function

        Public Function GetStopwatchMinimumTimeList() As Generic.List(Of Item)

            Dim Items = New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "2 *", .Value = "2"})
            Items.Add(New Item() With {.Description = "10", .Value = "10"})
            Items.Add(New Item() With {.Description = "15", .Value = "15"})
            Items.Add(New Item() With {.Description = "30", .Value = "30"})
            Items.Add(New Item() With {.Description = "60", .Value = "60"})

            Return Items

        End Function

        Public Function GetStopwatchRoundToNextIncrementList() As Generic.List(Of Item)

            Dim Items = New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "0", .Value = "0"})
            Items.Add(New Item() With {.Description = "10", .Value = "10"})
            Items.Add(New Item() With {.Description = "15", .Value = "15"})
            Items.Add(New Item() With {.Description = "30", .Value = "30"})
            Items.Add(New Item() With {.Description = "60", .Value = "60"})

            Return Items

        End Function

        Public Function GetAllTimeEntryMinimumTimeList() As Generic.List(Of Item)

            Dim Items = New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "0", .Value = "0"})
            Items.Add(New Item() With {.Description = "5", .Value = "5"})
            Items.Add(New Item() With {.Description = "10", .Value = "10"})
            Items.Add(New Item() With {.Description = "15", .Value = "15"})
            Items.Add(New Item() With {.Description = "30", .Value = "30"})
            Items.Add(New Item() With {.Description = "60", .Value = "60"})

            Return Items

        End Function

        Public Function GetAllTimeEntryRoundToNextIncrementList() As Generic.List(Of Item)

            Dim Items = New Generic.List(Of Item)

            Items.Add(New Item() With {.Description = "0", .Value = "0"})
            Items.Add(New Item() With {.Description = "5", .Value = "5"})
            Items.Add(New Item() With {.Description = "10", .Value = "10"})
            Items.Add(New Item() With {.Description = "15", .Value = "15"})
            Items.Add(New Item() With {.Description = "30", .Value = "30"})
            Items.Add(New Item() With {.Description = "60", .Value = "60"})

            Return Items

        End Function

    End Class

    Public Class Item
        Public Property Description As String
        Public Property Value As String

    End Class
    Public Class Day

        Public Property Description As String

        Public Property Value As Integer

    End Class

    Public Class DisplaySettings

        Public Property DaysToDisplay As Integer
        Public Property ShowCommentsUsing As String
        Public Property StartTimesheetOnDayOfWeek As Integer
        Public Property [Labels] As Labels
        Public Property DisablePagingOnMainGrid As Boolean = False
        Public Property RepeatRowForAllDays As Boolean = False
        Public Property OnlyShowMyProgress As Boolean = False

        Public Sub New()

            Labels = New Labels

        End Sub

    End Class

    Public Class Labels
        Public Property Division As String
        Public Property Product As String
        Public Property ProdCat As String
        Public Property Job As String
        Public Property JobComponent As String
        Public Property FuncCat As String

    End Class

    Public Class AgencyTimeEntryOptions

        Public Property StopwatchMinimumTime As Decimal
        Public Property StopwatchRoundToNextIncrement As Decimal
        Public Property AllTimeEntryMinimumTime As Decimal
        Public Property AllTimeEntryRoundToNextIncrement As Decimal
        Public Property CommentsRequiredWhenSubmittingForApproval As Boolean
        Public Property StartTimesheetOnDayOfWeek As Integer
        Public Property RequireAssignment As Boolean

    End Class

End Namespace


