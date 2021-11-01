Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class TimesheetHeaderViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String = String.Empty
        Public Property FullName As String = String.Empty

#End Region

#Region " Methods "

        Sub New()


        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class TimesheetViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeCode As String = String.Empty
        Public Property FullName As String = String.Empty
        Public Property StartDate As Date? = Nothing
        Public Property EndDate As Date? = Nothing
        Public Property IsMissingComments As Boolean? = False
        Public Property DaysToDisplay As Integer = 7
        Public Property IsApprovalActive As Boolean? = False
        Public Property IsViewingSingleDay As Boolean = False
        Public Property RequireHoursBeforeSubmit As Boolean? = False
        Public Property RequireHoursBeforeSubmitType As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType? = AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions.AllowSubmitForApprovalType.None

        Public Property Groups As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel) = Nothing
        Public Property Lines As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel) = Nothing
        Public Property Days As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel) = Nothing

        Public Property UserSettings As Settings = Nothing

        Public ReadOnly Property HasHours As Boolean
            Get

                Dim Hours As Decimal = 0

                Try

                    If Days IsNot Nothing AndAlso Days.Count > 0 Then

                        Hours = (From Entity In Days
                                 Select Entity.TotalHours).Sum

                    End If

                Catch ex As Exception
                    Hours = 0
                End Try

                Return Hours > 0

            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

            Groups = New List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetRowGroupViewModel)
            Lines = New List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel)
            Days = New List(Of AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel)

        End Sub

#End Region

    End Class

    '    <Serializable()> Public Class TimesheetGrid

    '#Region " Constants "



    '#End Region

    '#Region " Enum "



    '#End Region

    '#Region " Variables "



    '#End Region

    '#Region " Properties "

    '        Public Property Header As TimesheetHeaderViewModel = Nothing
    '        Public Property Lines As Generic.List(Of TimesheetGridLine)

    '#End Region

    '#Region " Methods "

    '        Sub New()

    '        End Sub

    '#End Region

    '    End Class
    '    <Serializable()> Public Class TimesheetGridLine

    '#Region " Constants "



    '#End Region

    '#Region " Enum "



    '#End Region

    '#Region " Variables "



    '#End Region

    '#Region " Properties "

    '        Public Property Info As TimesheetLineViewModel

    '        Public Property Day1 As TimesheetEntryViewModel
    '        Public Property Day2 As TimesheetEntryViewModel
    '        Public Property Day3 As TimesheetEntryViewModel
    '        Public Property Day4 As TimesheetEntryViewModel
    '        Public Property Day5 As TimesheetEntryViewModel
    '        Public Property Day6 As TimesheetEntryViewModel
    '        Public Property Day7 As TimesheetEntryViewModel
    '        Public Property Day1_Visible As Boolean = False
    '        Public Property Day2_Visible As Boolean = False
    '        Public Property Day3_Visible As Boolean = False
    '        Public Property Day4_Visible As Boolean = False
    '        Public Property Day5_Visible As Boolean = False
    '        Public Property Day6_Visible As Boolean = False
    '        Public Property Day7_Visible As Boolean = False


    '#End Region

    '#Region " Methods "
    '        Sub New()

    '        End Sub

    '#End Region

    '    End Class

    <Serializable()>
    Public Class AgencySettings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            UseBatchMethodToPostEmployeeTime
            UseCopyTimesheetFeature
            AllowCopyOfTimesheetHours
            CheckForClosedPostingPeriods
            RequireTimeComments
            AllowQvADrilldownInTimesheets
            SupervisorApprovalActive
            SupervisorCanEditOthersTimeWithinApprovals
            AutoAlertSupervisor
            DefaultDisplayDays
            AddUniqueRowWhenCommentsAreIncluded
            RequireAssignment
            WeeklyTimeType

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UseBatchMethodToPostEmployeeTime As Boolean = False
        Public Property UseCopyTimesheetFeature As Boolean = False
        Public Property AllowCopyOfTimesheetHours As Boolean = False
        Public Property CheckForClosedPostingPeriods As Boolean = False
        Public Property RequireTimeComments As Boolean = False
        Public Property AllowQvADrilldownInTimesheets As Boolean = False
        Public Property SupervisorApprovalActive As Boolean = False
        Public Property SupervisorCanEditOthersTimeWithinApprovals As Boolean = False
        Public Property AutoAlertSupervisor As Boolean = False
        Public Property DefaultDisplayDays As Short = 7
        Public Property AddUniqueRowWhenCommentsAreIncluded As Boolean = False
        Public Property RequireAssignment As Boolean = False
        Public Property WeeklyTimeType As Short = 7
        Public Property StartWeekOn As Short = 0
        Public Property AgencyOverride As Boolean = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class Settings

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            DaysToDisplay
            StartTimesheetOnDayOfWeek
            ShowCommentsUsing
            DivisionLabel
            ProductLabel
            ProductCategoryLabel
            JobLabel
            JobComponentLabel
            FunctionCategoryLabel
            ShowJobName
            ShowComponentName
            ShowJobAndComponentNumber
            ShowClientName
            ShowDivisionName
            ShowProductName
            ShowFunctionCategory
            ShowAssignment
            SundayHoursGoal
            MondayHoursGoal
            TuesdayHoursGoal
            WednesdayHoursGoal
            ThursdayHoursGoal
            FridayHoursGoal
            SaturdayHoursGoal
            AddUniqueRowWhenComment
            ShowProgressBar
            ShowHoursRemaining
            RepeatRowForAllDays

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DaysToDisplay As Integer = 7
        Public Property StartTimesheetOnDayOfWeek As Short = 1
        Public Property ShowCommentsUsing As String = String.Empty
        Public Property DivisionLabel As String = "Division"
        Public Property ProductLabel As String = "Product"
        Public Property ProductCategoryLabel As String = "Product Category"
        Public Property JobLabel As String = "Job"
        Public Property JobComponentLabel As String = "Component"
        Public Property FunctionCategoryLabel As String = "Function"

        Public Property ShowJobName As Boolean = True
        Public Property ShowComponentName As Boolean = True
        Public Property ShowJobAndComponentNumber As Boolean = True
        Public Property ShowClientName As Boolean = True
        Public Property ShowDivisionName As Boolean = True
        Public Property ShowProductName As Boolean = True
        Public Property ShowFunctionCategory As Boolean = True
        Public Property ShowAssignment As Boolean = True
        Public Property AddUniqueRowWhenComment As Boolean = False

        Public Property SundayHoursGoal As Decimal? = 0.0
        Public Property MondayHoursGoal As Decimal? = 0.0
        Public Property TuesdayHoursGoal As Decimal? = 0.0
        Public Property WednesdayHoursGoal As Decimal? = 0.0
        Public Property ThursdayHoursGoal As Decimal? = 0.0
        Public Property FridayHoursGoal As Decimal? = 0.0
        Public Property SaturdayHoursGoal As Decimal? = 0.0

        Public Property ShowProgressBar As Boolean = False
        Public Property ShowHoursRemaining As Boolean = False

        Public Property RepeatRowForAllDays As Boolean? = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class SettingsOptions

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property StartWeekOnDays As Generic.List(Of StartWeekDay)
        Public Property DaysToShow As Generic.List(Of Short)
        Public Property DisplayOptions As Generic.List(Of DisplayOption)

#End Region

#Region " Methods "

        Sub New()

            Dim DisOpt As DisplayOption = Nothing
            Dim StartWeekDay As StartWeekDay = Nothing

            StartWeekOnDays = New List(Of StartWeekDay)
            DaysToShow = New List(Of Short)
            DisplayOptions = New List(Of DisplayOption)

            StartWeekDay = New StartWeekDay
            StartWeekDay.DayOfWeek = CType(DayOfWeek.Sunday, Integer)
            StartWeekDay.Day = DayOfWeek.Sunday.ToString
            StartWeekOnDays.Add(StartWeekDay)
            StartWeekDay = Nothing

            StartWeekDay = New StartWeekDay
            StartWeekDay.DayOfWeek = CType(DayOfWeek.Monday, Integer)
            StartWeekDay.Day = DayOfWeek.Monday.ToString
            StartWeekOnDays.Add(StartWeekDay)
            StartWeekDay = Nothing

            StartWeekDay = New StartWeekDay
            StartWeekDay.DayOfWeek = CType(DayOfWeek.Saturday, Integer)
            StartWeekDay.Day = DayOfWeek.Saturday.ToString
            StartWeekOnDays.Add(StartWeekDay)
            StartWeekDay = Nothing

            DaysToShow.Add(7)
            DaysToShow.Add(5)

            DisOpt = New DisplayOption
            DisOpt.Key = "JobName"
            DisOpt.Display = "Job Name"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing

            DisOpt = New DisplayOption
            DisOpt.Key = "ComponentName"
            DisOpt.Display = "Component Name"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing

            DisOpt = New DisplayOption
            DisOpt.Key = "JobCompNum"
            DisOpt.Display = "Job/Component Number"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing

            DisOpt = New DisplayOption
            DisOpt.Key = "Client"
            DisOpt.Display = "Client"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing

            DisOpt = New DisplayOption
            DisOpt.Key = "Division"
            DisOpt.Display = "Division"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing

            DisOpt = New DisplayOption
            DisOpt.Key = "Product"
            DisOpt.Display = "Product"
            DisOpt.Value = True
            DisplayOptions.Add(DisOpt)
            DisOpt = Nothing


        End Sub

#End Region

#Region " Sub Classes"

        <Serializable()>
        Public Class DisplayOption
            Public Property Key As String
            Public Property Display As String
            Public Property Value As Boolean

            Sub New()

            End Sub
        End Class
        <Serializable()>
        Public Class StartWeekDay
            Public Property DayOfWeek As Integer
            Public Property Day As String
            Sub New()

            End Sub
        End Class

#End Region

    End Class

End Namespace
