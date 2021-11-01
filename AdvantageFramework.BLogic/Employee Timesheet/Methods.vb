Imports System.Data.SqlClient
Imports System.Threading
Namespace EmployeeTimesheet

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const AppVarKey As String = "NewTimesheet"

#End Region

#Region " Enum "

        Public Enum TimesheetSortOptions
            NewestFirst
            JobComponent
            Client
            Division
            Product
            FunctionCategory
            DepartmentTeam
            [Date]
            ClientAsc
            ClientDesc
            JobAsc
            JobDesc
        End Enum

        Public Enum Settings
            COPY_FROM_TEMPLATE_INSERT_HRS
            DAYS_TO_DISPLAY
            DIVISION
            DropGroupByIndex
            FUNC_CAT
            JOB
            JOB_COMP
            MAIN_TS_NO_PAGING
            PROD_CAT
            PRODUCT
            SHOW_CMNT_USING
            START_WEEK_ON
            COPY_FROM_TEMPLATE_GROUP_BY
            COPY_FROM_TEMPLATE_APPLY_DAY
        End Enum

        Public Enum TemplateGroupByOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client")>
            Client = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Client\Division")>
            Division = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Client\Division\Product")>
            Product = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Client\Division\Product\Job")>
            Job = 4
        End Enum

        Public Enum DayStatus
            Open
            Pending
            Denied
            Approved
            PostPeriodClosed
        End Enum

        Public Enum TimesheetGroupByOptions
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "[None]")>
            [None] = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client")>
            Client = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Client\Division")>
            ClientDivision = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Client\Division\Product")>
            ClientDivisionProduct = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Client\Job")>
            ClientJob = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Client\Division\Job")>
            ClientDivisionJob = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Client\Division\Product\Job")>
            ClientDivisionProductJob = 6
        End Enum

        Public Enum ReportSortByOptions As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "[None]")>
            None = 0
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Client")>
            Client = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Division")>
            Division = 2
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Product")>
            Product = 3
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Job/Component")>
            JobAndComponent = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Func/Cat")>
            FunctionCategory = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "Department")>
            Department = 6
        End Enum

        'Public Enum DayApprovalType
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("0", "Ready to Submit")>
        '    ReadyToSubmit = 0
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "Pending Approval")>
        '    Pending = 1
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Approved")>
        '    Approved = 2
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("3", "Denied")>
        '    Denied = 3
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("4", "Not Submitted")>
        '    NotSubmitted = 4
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("5", "Missing")>
        '    Missing = 5
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("6", "")>
        '    AllTime = 6 'disregard approval status
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("7", "Missing")>
        '    DoesNotExist = 7 'no time entered
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("8", "Post Period Closed")>
        '    PostPeriodClosed = 8
        '    <AdvantageFramework.EnumUtilities.Attributes.EnumObject("9", "Entered")>
        '    Entered = 9
        'End Enum

        Public Enum DayApprovalType
            ReadyToSubmit = 0
            Pending = 1
            Approved = 2
            Denied = 3
            NotSubmitted = 4
            Missing = 5
            Entered = 6
            PostPeriodClosed = 7
        End Enum

        Public Enum ProgressTypes
            Quoted
            OverThreshold
            NotQuoted
        End Enum

#End Region

#Region " Variables "

        Private _AllowProcessControls As Integer() = {1, 4, 7, 8, 11}

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function ClearUserTimesheetSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal UserCode As String) As Boolean

            Dim Cleared As Boolean = True
            Dim SQL As String = String.Empty

            Try

                If String.IsNullOrWhiteSpace(UserCode) = True Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM APP_VARS WHERE [APPLICATION] = 'NewTimesheet' AND [VARIABLE_NAME] IN ('StartTimesheetOnDayOfWeek', 'DaysToDisplay');"))

                Else

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM APP_VARS WHERE [APPLICATION] = 'NewTimesheet' AND [VARIABLE_NAME] IN ('StartTimesheetOnDayOfWeek', 'DaysToDisplay') AND [USERID] = '{0}';", UserCode))

                End If

            Catch ex As Exception
                Cleared = False
            End Try

            Return Cleared

        End Function

        Public Function GetThisWeekHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DailyHours)

            Dim ThisWeek As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DailyHours) = Nothing

            Try

                Dim ParameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                Dim ParameterDaysToDisplay As New SqlParameter("@DAYS_TO_DISPLAY", SqlDbType.SmallInt)
                Dim ParameterStartDate As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)

                ParameterEmpCode.Value = EmployeeCode
                ParameterDaysToDisplay.Value = System.DBNull.Value
                ParameterStartDate.Value = System.DBNull.Value

                ThisWeek = DbContext.Database.SqlQuery(Of AdvantageFramework.EmployeeTimesheet.Classes.DailyHours)("EXEC [dbo].[usp_wv_dto_Get_Current_Weekly_Time_Total] @EMP_CODE, @DAYS_TO_DISPLAY, @START_DATE;",
                                                                                                                   ParameterEmpCode, ParameterDaysToDisplay, ParameterStartDate).ToList

            Catch ex As Exception
                ThisWeek = Nothing
            End Try

            Return ThisWeek

        End Function
        Public Function GetAgencySettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings

            Dim AgencySettings As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings = Nothing
            Dim SQL As String = "SELECT " &
                                "	[UseBatchMethodToPostEmployeeTime] = CAST(ISNULL(A.ET_BATCH, 0) AS BIT), " &
                                "	[UseCopyTimesheetFeature] = CAST(ISNULL(A.COPY_TS, 0) AS BIT), " &
                                "	[AllowCopyOfTimesheetHours] = CAST(ISNULL(A.TS_COPY_HRS, 0) AS BIT), " &
                                "	[CheckForClosedPostingPeriods] = CAST(ISNULL(A.TS_PPERIOD_CHK, 0) AS BIT), " &
                                "	[RequireTimeComments] = CAST(ISNULL(A.TIME_COMMENTS_REQ, 0) AS BIT), " &
                                "	[AllowQvADrilldownInTimesheets] = CAST(ISNULL(A.QVA_QUERY, 0) AS BIT), " &
                                "	[SupervisorApprovalActive] = CAST(ISNULL(A.TIME_APPR_ACTIVE, 0) AS BIT), " &
                                "	[SupervisorCanEditOthersTimeWithinApprovals] = CAST(ISNULL(A.EDIT_OTHER_TIME, 0) AS BIT), " &
                                "	[AutoAlertSupervisor] = CAST(ISNULL(A.AUTO_ALERT_SUPER, 0) AS BIT), " &
                                "	[DefaultDisplayDays] = CAST(ISNULL(A.TS_DAYS_PER_WK, 7) AS SMALLINT), " &
                                "	[AddUniqueRowWhenCommentsAreIncluded] = CAST(ISNULL(A.TIME_UNIQUE_ROW, 0) AS BIT), " &
                                "	[RequireAssignment] = CAST(ISNULL(A.TIME_REQ_ASSN, 0) AS BIT), " &
                                "	[WeeklyTimeType] = CAST(ISNULL(A.WEEKLY_TIME, 0) AS SMALLINT) " &
                                "FROM AGENCY A WITH(NOLOCK);"

            Try

                AgencySettings = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings)(SQL).SingleOrDefault

            Catch ex As Exception
                AgencySettings = Nothing
            End Try
            If AgencySettings IsNot Nothing Then

                Try

                    AgencySettings.StartWeekOn = DbContext.Database.SqlQuery(Of Short)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TS_START_WEEK_ON';").SingleOrDefault

                Catch ex As Exception
                    AgencySettings.StartWeekOn = 0
                End Try
                Try

                    AgencySettings.AgencyOverride = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TS_AGY_OVRRDE';").SingleOrDefault

                Catch ex As Exception
                    AgencySettings.AgencyOverride = 0
                End Try

            End If
            'If AgencySettings Is Nothing Then AgencySettings = New ViewModels.Employee.Timesheet.AgencySettings

            Return AgencySettings

        End Function
        Public Function SaveUserSettings(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings) As Boolean

            Dim AppVarSetting As AdvantageFramework.Database.Entities.AppVars = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.StartTimesheetOnDayOfWeek.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.StartTimesheetOnDayOfWeek.ToString
                AppVarSetting.Value = UserSettings.StartTimesheetOnDayOfWeek
                AppVarSetting.Type = "Short"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.StartTimesheetOnDayOfWeek.ToString Then

                    AppVarSetting.Value = UserSettings.StartTimesheetOnDayOfWeek
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.DaysToDisplay.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.DaysToDisplay.ToString
                AppVarSetting.Value = UserSettings.DaysToDisplay
                AppVarSetting.Type = "Short"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.DaysToDisplay.ToString Then

                    AppVarSetting.Value = UserSettings.DaysToDisplay
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing


            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobName.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobName.ToString
                AppVarSetting.Value = UserSettings.ShowJobName.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowJobName.ToString Then

                    AppVarSetting.Value = UserSettings.ShowJobName.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowComponentName.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowComponentName.ToString
                AppVarSetting.Value = UserSettings.ShowComponentName.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowComponentName.ToString Then

                    AppVarSetting.Value = UserSettings.ShowComponentName.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobAndComponentNumber.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobAndComponentNumber.ToString
                AppVarSetting.Value = UserSettings.ShowJobAndComponentNumber.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowJobAndComponentNumber.ToString Then

                    AppVarSetting.Value = UserSettings.ShowJobAndComponentNumber.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowClientName.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowClientName.ToString
                AppVarSetting.Value = UserSettings.ShowClientName.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowClientName.ToString Then

                    AppVarSetting.Value = UserSettings.ShowClientName.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing


            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowDivisionName.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowDivisionName.ToString
                AppVarSetting.Value = UserSettings.ShowDivisionName.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowDivisionName.ToString Then

                    AppVarSetting.Value = UserSettings.ShowDivisionName.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProductName.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProductName.ToString
                AppVarSetting.Value = UserSettings.ShowProductName.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowProductName.ToString Then

                    AppVarSetting.Value = UserSettings.ShowProductName.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowFunctionCategory.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowFunctionCategory.ToString
                AppVarSetting.Value = UserSettings.ShowFunctionCategory.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowFunctionCategory.ToString Then

                    AppVarSetting.Value = UserSettings.ShowFunctionCategory.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowAssignment.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowAssignment.ToString
                AppVarSetting.Value = UserSettings.ShowAssignment.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowAssignment.ToString Then

                    AppVarSetting.Value = UserSettings.ShowAssignment.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.AddUniqueRowWhenComment.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.AddUniqueRowWhenComment.ToString
                AppVarSetting.Value = UserSettings.AddUniqueRowWhenComment.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.AddUniqueRowWhenComment.ToString Then

                    AppVarSetting.Value = UserSettings.AddUniqueRowWhenComment.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProgressBar.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProgressBar.ToString
                AppVarSetting.Value = UserSettings.ShowProgressBar.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowProgressBar.ToString Then

                    AppVarSetting.Value = UserSettings.ShowProgressBar.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowHoursRemaining.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowHoursRemaining.ToString
                AppVarSetting.Value = UserSettings.ShowHoursRemaining.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.ShowHoursRemaining.ToString Then

                    AppVarSetting.Value = UserSettings.ShowHoursRemaining.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            'RepeatRowForAllDays
            AppVarSetting = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationNameAndVariableName(DbContext, DbContext.UserCode, AppVarKey,
                                                                                                                AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.RepeatRowForAllDays.ToString)
            If AppVarSetting Is Nothing Then

                AppVarSetting = New AdvantageFramework.Database.Entities.AppVars

                AppVarSetting.UserCode = DbContext.UserCode
                AppVarSetting.Application = AppVarKey
                AppVarSetting.Name = AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.RepeatRowForAllDays.ToString
                AppVarSetting.Value = UserSettings.RepeatRowForAllDays.ToString
                AppVarSetting.Type = "Boolean"

                AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVarSetting)

            Else

                If AppVarSetting.Value <> UserSettings.RepeatRowForAllDays.ToString Then

                    AppVarSetting.Value = UserSettings.RepeatRowForAllDays.ToString
                    AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVarSetting)

                End If

            End If
            AppVarSetting = Nothing

            Return True

        End Function
        Public Function GetUserSettings(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.ViewModels.Employee.Timesheet.Settings

            Dim UserSettings As New AdvantageFramework.ViewModels.Employee.Timesheet.Settings
            Dim AllSettings As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim AgencySettings As AdvantageFramework.ViewModels.Employee.Timesheet.AgencySettings = Nothing

            AllSettings = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, DbContext.UserCode, "NewTimesheet").ToList
            AgencySettings = GetAgencySettings(DbContext)
            UserSettings.AddUniqueRowWhenComment = AdvantageFramework.Database.Procedures.Agency.TimesheetAddUniqueRowWhenComment(DbContext)

            If AgencySettings IsNot Nothing Then

                UserSettings.StartTimesheetOnDayOfWeek = AgencySettings.StartWeekOn
                UserSettings.DaysToDisplay = AgencySettings.DefaultDisplayDays

            End If

            If AllSettings IsNot Nothing Then

                For Each Setting As AdvantageFramework.Database.Entities.AppVars In AllSettings

                    Select Case Setting.Name
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.StartTimesheetOnDayOfWeek.ToString
                            UserSettings.StartTimesheetOnDayOfWeek = Setting.Value
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.DaysToDisplay.ToString
                            UserSettings.DaysToDisplay = Setting.Value
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobName.ToString
                            UserSettings.ShowJobName = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowComponentName.ToString
                            UserSettings.ShowComponentName = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowJobAndComponentNumber.ToString
                            UserSettings.ShowJobAndComponentNumber = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowClientName.ToString
                            UserSettings.ShowClientName = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowDivisionName.ToString
                            UserSettings.ShowDivisionName = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProductName.ToString
                            UserSettings.ShowProductName = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowFunctionCategory.ToString
                            UserSettings.ShowFunctionCategory = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowAssignment.ToString
                            UserSettings.ShowAssignment = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.AddUniqueRowWhenComment.ToString
                            UserSettings.AddUniqueRowWhenComment = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowProgressBar.ToString
                            UserSettings.ShowProgressBar = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.ShowHoursRemaining.ToString
                            UserSettings.ShowHoursRemaining = Setting.Value = "True"
                        Case AdvantageFramework.ViewModels.Employee.Timesheet.Settings.Properties.RepeatRowForAllDays.ToString
                            UserSettings.RepeatRowForAllDays = Setting.Value = "True"

                    End Select

                Next

            End If

            If AgencySettings IsNot Nothing AndAlso AgencySettings.AgencyOverride = True Then

                UserSettings.StartTimesheetOnDayOfWeek = AgencySettings.StartWeekOn
                UserSettings.DaysToDisplay = AgencySettings.DefaultDisplayDays

            End If

            Return UserSettings

        End Function

        Public Function SaveDay(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                ByVal EtId As System.Int32, ByVal EtDtlId As System.Int32, ByVal EmpCode As System.String, ByVal EmpDate As System.DateTime,
                                ByVal FncCat As System.String, ByVal ProdCat As String, ByRef EmpHrs As System.Decimal, ByVal JobNumber As System.Int32,
                                ByVal JobComponentNbr As System.Int16, ByVal DeptTeam As System.String, ByVal USER_CODE As String, ByRef ErrorMessage As System.String,
                                ByVal Comments As String, ByRef NewEt_Id As Integer, ByRef NewEtd_Id As Integer,
                                ByVal AlertID As Integer,
                                ByVal AllowDuplicate As Boolean) As Boolean

            Return SaveDay(DbContext.ConnectionString, DbContext.UserCode,
                           EtId, EtDtlId, EmpCode, EmpDate,
                           FncCat, ProdCat, EmpHrs, JobNumber,
                           JobComponentNbr, DeptTeam, USER_CODE, ErrorMessage,
                           Comments, NewEt_Id, NewEtd_Id,
                           AlertID,
                           AllowDuplicate)

        End Function
        Public Function SaveDay(ByVal ConnectionString As String, ByVal UserCode As String,
                                ByVal EtId As System.Int32, ByVal EtDtlId As System.Int32, ByVal EmpCode As System.String, ByVal EmpDate As System.DateTime,
                                ByVal FncCat As System.String, ByVal ProdCat As String, ByRef EmpHrs As System.Decimal, ByVal JobNumber As System.Int32,
                                ByVal JobComponentNbr As System.Int16, ByVal DeptTeam As System.String, ByVal USER_CODE As String, ByRef ErrorMessage As System.String,
                                ByVal Comments As String, ByRef NewEt_Id As Integer, ByRef NewEtd_Id As Integer,
                                ByVal AlertID As Integer,
                                ByVal AllowDuplicate As Boolean) As Boolean

            Dim Success As Boolean = False

            '5210-1-1596 - TS:  When adding time from card or otherwise, add new row by default when a comment is added.
            If EtId = 0 AndAlso EtDtlId = 0 AndAlso String.IsNullOrWhiteSpace(Comments) = False Then

                AllowDuplicate = True

            End If
            Try

                Dim MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCmd As New System.Data.SqlClient.SqlCommand("usp_wv_ts_SaveTimeSheetDay", MyConn)
                Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCmd)

                MyCmd.CommandType = CommandType.StoredProcedure

                Dim parameteret_id As New System.Data.SqlClient.SqlParameter("@et_id", SqlDbType.Int, 4)
                parameteret_id.Value = EtId
                MyCmd.Parameters.Add(parameteret_id)

                Dim parameteretd_id As New System.Data.SqlClient.SqlParameter("@etd_id", SqlDbType.Int, 4)
                parameteretd_id.Value = EtDtlId
                MyCmd.Parameters.Add(parameteretd_id)

                Dim parameteremp_code As New System.Data.SqlClient.SqlParameter("@emp_code", SqlDbType.VarChar, 6)
                parameteremp_code.Value = EmpCode
                MyCmd.Parameters.Add(parameteremp_code)

                Dim parameteremp_date As New System.Data.SqlClient.SqlParameter("@emp_date", SqlDbType.SmallDateTime, 0)
                parameteremp_date.Value = EmpDate.ToShortDateString
                MyCmd.Parameters.Add(parameteremp_date)

                Dim parameterfnc_cat As New System.Data.SqlClient.SqlParameter("@fnc_cat", SqlDbType.VarChar, 10)
                parameterfnc_cat.Value = FncCat
                MyCmd.Parameters.Add(parameterfnc_cat)

                Dim parameteremp_hrs As New System.Data.SqlClient.SqlParameter("@emp_hrs", SqlDbType.Decimal, 8)
                parameteremp_hrs.Value = EmpHrs
                MyCmd.Parameters.Add(parameteremp_hrs)

                Dim parameterjob_nbr As New System.Data.SqlClient.SqlParameter("@job_nbr", SqlDbType.Int, 4)
                parameterjob_nbr.Value = JobNumber
                MyCmd.Parameters.Add(parameterjob_nbr)

                Dim parameterjob_cmp_nbr As New System.Data.SqlClient.SqlParameter("@job_cmp_nbr", SqlDbType.SmallInt, 2)
                parameterjob_cmp_nbr.Value = JobComponentNbr
                MyCmd.Parameters.Add(parameterjob_cmp_nbr)

                Dim parameterdp_tm As New System.Data.SqlClient.SqlParameter("@dp_tm", SqlDbType.VarChar, 4)
                If String.IsNullOrWhiteSpace(DeptTeam) Then
                    parameterdp_tm.Value = DBNull.Value
                Else
                    parameterdp_tm.Value = DeptTeam
                End If
                MyCmd.Parameters.Add(parameterdp_tm)

                Dim parameterstart_time As New System.Data.SqlClient.SqlParameter("@start_time", SqlDbType.Char, 4)
                parameterstart_time.Value = ""
                MyCmd.Parameters.Add(parameterstart_time)

                Dim parameterend_time As New System.Data.SqlClient.SqlParameter("@end_time", SqlDbType.Char, 4)
                parameterend_time.Value = ""
                MyCmd.Parameters.Add(parameterend_time)
                If ProdCat = Nothing Then
                    ProdCat = ""
                End If

                Dim parameterProdCat As New System.Data.SqlClient.SqlParameter("@ProdCat", SqlDbType.VarChar, 10)
                If String.IsNullOrWhiteSpace(ProdCat) Then
                    parameterProdCat.Value = DBNull.Value
                Else
                    parameterProdCat.Value = ProdCat
                End If
                MyCmd.Parameters.Add(parameterProdCat)

                Dim parameterUSER_CODE As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                parameterUSER_CODE.Value = USER_CODE
                MyCmd.Parameters.Add(parameterUSER_CODE)

                Dim parametererror_text As New System.Data.SqlClient.SqlParameter("@error_text", SqlDbType.VarChar)
                parametererror_text.Value = ""
                MyCmd.Parameters.Add(parametererror_text)

                Dim parameterComments As New System.Data.SqlClient.SqlParameter("@comments", SqlDbType.NText, 1073741823)
                If String.IsNullOrWhiteSpace(Comments) Then
                    parameterComments.Value = DBNull.Value
                Else
                    parameterComments.Value = Comments.Trim
                End If
                MyCmd.Parameters.Add(parameterComments)

                Dim parameterAlertID As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int, 4)
                If AlertID = 0 Then
                    parameterAlertID.Value = System.DBNull.Value
                Else
                    parameterAlertID.Value = AlertID
                End If
                MyCmd.Parameters.Add(parameterAlertID)

                Dim parameterAllowDuplicate As New System.Data.SqlClient.SqlParameter("@ALLOW_DUPLICATE", SqlDbType.Bit)
                parameterAllowDuplicate.Value = AllowDuplicate
                MyCmd.Parameters.Add(parameterAllowDuplicate)

                Dim parameterCREATE_DATE As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                ' task code cannot be changed via webvantage YET.
                Dim parameterTaskCode As New System.Data.SqlClient.SqlParameter("@taskCode", SqlDbType.VarChar, 10)
                Dim TaskCode As String = Nothing

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, USER_CODE)

                    If EtId > 0 AndAlso EtDtlId > 0 Then

                        Try

                            TaskCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TRF_CODE FROM dbo.EMP_TIME_DTL WHERE ET_ID = {0} AND ET_DTL_ID = {1}", EtId, EtDtlId)).FirstOrDefault

                        Catch ex As Exception
                        End Try

                    End If
                    If String.IsNullOrEmpty(TaskCode) Then

                        parameterTaskCode.Value = DBNull.Value

                    Else

                        parameterTaskCode.Value = TaskCode

                    End If

                    parameterCREATE_DATE.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                End Using

                MyCmd.Parameters.Add(parameterTaskCode)
                MyCmd.Parameters.Add(parameterCREATE_DATE)

                Try
                    Dim ds As New DataSet
                    Try

                        MyConn.Open()
                        MyAdapter.Fill(ds)

                    Catch ex As Exception
                        ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                        Return False
                    Finally

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()
                            MyConn.Dispose()

                        End If

                    End Try

                    ErrorMessage = ds.Tables(ds.Tables.Count - 1).Rows(0)("RETURN_MESSAGE")

                    Try
                        If Not ds Is Nothing Then
                            ds.Dispose()
                            ds = Nothing
                        End If
                    Catch ex As Exception
                    End Try

                    If ErrorMessage.Contains("SUCCESS") = True OrElse String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                        Success = True

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            ErrorMessage = AdvantageFramework.StringUtilities.RemoveTrailingDelimiter(ErrorMessage, "|")

                            If ErrorMessage.IndexOf("INSERT") > -1 And ErrorMessage.IndexOf("|") > -1 Then

                                Try

                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    'ErrorMessage = ar(0)
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try

                            End If
                            If ErrorMessage.IndexOf("UPDATE") > -1 And ErrorMessage.IndexOf("|") > -1 Then

                                Try

                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    'ErrorMessage = ar(0)
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Return False
                                End Try

                            End If

                        End If

                        Try

                            Dim PostActions As New AdvantageFramework.Controller.Employee.PostTimeSaveActions(ConnectionString, UserCode, EmpCode, EmpDate)
                            PostActions.Run()

                        Catch ex As Exception
                        End Try

                    ElseIf ErrorMessage.Contains("NO_CHANGE") = True Then

                        Success = True

                        Try

                            Dim ar() As String
                            ar = ErrorMessage.Split("|")
                            'ErrorMessage = ar(0)
                            NewEt_Id = CType(ar(1), Integer)
                            NewEtd_Id = CType(ar(2), Integer)
                            EmpHrs = CType(AdvantageFramework.StringUtilities.FormatDecimal(ar(3)), Decimal)

                        Catch ex As Exception
                            NewEt_Id = 0
                            NewEtd_Id = 0
                            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try

                    Else

                        Success = False

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            If ErrorMessage.IndexOf("UPDATE_FAIL|") > -1 Then

                                Try

                                    Dim ar() As String
                                    ar = ErrorMessage.Split("|")
                                    NewEt_Id = CType(ar(1), Integer)
                                    NewEtd_Id = CType(ar(2), Integer)
                                    EmpHrs = CType(ar(3), Decimal)

                                Catch ex As Exception
                                    NewEt_Id = 0
                                    NewEtd_Id = 0
                                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                                    Success = False
                                End Try

                            End If

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                    Success = False
                End Try

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
                Success = False
            End Try

            Return Success

        End Function
        Public Function TimeEntryExists(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByVal Hours As Decimal,
                                        ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                        ByVal FunctionCode As String, ByVal AlertID As Integer,
                                        ByRef EmployeeTimeID As Integer, ByRef EmployeeTimeDetailID As Integer,
                                        ByRef CurrentHours As Decimal, ByRef CurrentComments As String,
                                        ByRef ErrorMessage As String) As Boolean

            Dim Exists As Boolean = False

            Try

                Dim ExistingEntry As ExistingEntryObject = Nothing

                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterHours As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterJobNumber As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterJobComponentNumber As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterFindWithComment As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
                SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EMP_DATE", SqlDbType.SmallDateTime)
                SqlParameterHours = New System.Data.SqlClient.SqlParameter("@EMP_HOURS", SqlDbType.Decimal)
                SqlParameterJobNumber = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                SqlParameterJobComponentNumber = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
                SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar)
                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterFindWithComment = New System.Data.SqlClient.SqlParameter("@FIND_WITH_COMMENT", SqlDbType.Bit)

                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterEmployeeDate.Value = EmployeeDate
                SqlParameterHours.Value = Hours
                SqlParameterJobNumber.Value = JobNumber
                SqlParameterJobComponentNumber.Value = JobComponentNumber
                SqlParameterFunctionCode.Value = FunctionCode
                SqlParameterAlertId.Value = AlertID
                SqlParameterFindWithComment.Value = False

                ExistingEntry = DbContext.Database.SqlQuery(Of ExistingEntryObject)("SELECT * FROM [dbo].[advtf_find_open_time_entry] (@EMP_CODE, @EMP_DATE, @EMP_HOURS, @JOB_NUMBER, @JOB_COMPONENT_NBR, @FNC_CODE, @ALERT_ID, @FIND_WITH_COMMENT);",
                                                                                    SqlParameterEmployeeCode,
                                                                                    SqlParameterEmployeeDate,
                                                                                    SqlParameterHours,
                                                                                    SqlParameterJobNumber,
                                                                                    SqlParameterJobComponentNumber,
                                                                                    SqlParameterFunctionCode,
                                                                                    SqlParameterAlertId,
                                                                                    SqlParameterFindWithComment).SingleOrDefault

                If ExistingEntry IsNot Nothing Then


                    If ExistingEntry.ET_ID IsNot Nothing Then EmployeeTimeID = ExistingEntry.ET_ID
                    If ExistingEntry.ETD_ID IsNot Nothing Then EmployeeTimeDetailID = ExistingEntry.ETD_ID
                    If ExistingEntry.EMP_HOURS IsNot Nothing Then CurrentHours = ExistingEntry.EMP_HOURS
                    If String.IsNullOrWhiteSpace(ExistingEntry.COMMENT) = False Then CurrentComments = ExistingEntry.COMMENT

                    If EmployeeTimeID > 0 OrElse EmployeeTimeDetailID > 0 Then

                        Exists = True

                    Else

                        Exists = False

                    End If

                    ErrorMessage = String.Empty

                End If

            Catch ex As Exception
                Exists = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Exists

        End Function
        Public Function Create(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByVal StartDate As Date,
                               ByVal EndDate As Date, Optional ByVal TimesheetSortOption As TimesheetSortOptions = TimesheetSortOptions.NewestFirst,
                               Optional ByRef ErrorMessage As String = "") As Object

            Return Create(Session.ConnectionString, Session.UserCode, EmployeeCode, StartDate, EndDate, TimesheetSortOption, ErrorMessage)

        End Function
        Public Function Create(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal StartDate As Date,
                               ByVal EndDate As Date, Optional ByVal TimesheetSortOption As TimesheetSortOptions = TimesheetSortOptions.NewestFirst,
                               Optional ByRef ErrorMessage As String = "") As Object

            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                Create = New AdvantageFramework.EmployeeTimesheet.Classes.Timesheet(DbContext, EmployeeCode, StartDate, EndDate, "", UserCode)

            End Using

        End Function
        Public Sub LoadTimesheetSettings(ByVal Session As AdvantageFramework.Security.Session, ByVal UserCode As String, ByRef UserDaysToDisplay As Short,
                                         ByRef UserStartWeekOn As String, ByRef UserShowCommentsUsing As String, ByRef UserMainTimesheetNoPaging As Boolean,
                                         ByRef UserDivision As String, ByRef UserProduct As String, ByRef UserProductCategory As String,
                                         ByRef UserJob As String, ByRef UserJobComp As String, ByRef UserFunctionCategory As String, ByRef CommentsRequired As Boolean)

            'objects
            Dim AgencyDaysToDisplay As Short = Nothing
            Dim AgencyStartWeekOn As String = Nothing
            Dim AgencyShowCommentsUsing As String = Nothing
            Dim AgencyMainTimesheetNoPaging As Boolean = False
            Dim AgencyDivision As String = Nothing
            Dim AgencyProduct As String = Nothing
            Dim AgencyProductCategory As String = Nothing
            Dim AgencyJob As String = Nothing
            Dim AgencyJobComp As String = Nothing
            Dim AgencyFunctionCategory As String = Nothing
            Dim AppVars As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim AgencySettingsToLoad As String() = Nothing
            Dim UserSettingsToLoad As String() = Nothing
            Dim UserSettingCode As String = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                UserMainTimesheetNoPaging = False

                AgencySettingsToLoad = {AdvantageFramework.Agency.Settings.TS_SHOW_CMNT_USING.ToString,
                                        AdvantageFramework.Agency.Settings.TS_START_WEEK_ON.ToString,
                                        AdvantageFramework.Agency.Settings.TS_DIVISION.ToString,
                                        AdvantageFramework.Agency.Settings.TS_PROD_CAT.ToString,
                                        AdvantageFramework.Agency.Settings.TS_PRODUCT.ToString,
                                        AdvantageFramework.Agency.Settings.TS_JOB.ToString,
                                        AdvantageFramework.Agency.Settings.TS_JOB_COMP.ToString,
                                        AdvantageFramework.Agency.Settings.TS_FUNC_CAT.ToString,
                                        "MAIN_TS_NO_PAGING"} 'MAIN_TS_NO_PAGING webvantage only

                UserSettingsToLoad = {AdvantageFramework.EmployeeTimesheet.Settings.SHOW_CMNT_USING.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.START_WEEK_ON.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.DIVISION.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.PROD_CAT.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.PRODUCT.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.JOB.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.JOB_COMP.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.FUNC_CAT.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.MAIN_TS_NO_PAGING.ToString,
                                      AdvantageFramework.EmployeeTimesheet.Settings.DAYS_TO_DISPLAY.ToString}

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                        AgencyDaysToDisplay = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).DefaultDisplayDays.GetValueOrDefault(7)

                        For Each SettingCode In AgencySettingsToLoad

                            Try

                                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, SettingCode)

                                If Setting IsNot Nothing Then

                                    Select Case Setting.Code

                                        Case AdvantageFramework.Agency.Settings.TS_SHOW_CMNT_USING.ToString

                                            AgencyShowCommentsUsing = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_START_WEEK_ON.ToString

                                            AgencyStartWeekOn = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_DIVISION.ToString

                                            AgencyDivision = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_PROD_CAT.ToString

                                            AgencyProductCategory = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_PRODUCT.ToString

                                            AgencyProduct = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_JOB.ToString

                                            AgencyJob = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_JOB_COMP.ToString

                                            AgencyJobComp = CStr(Setting.Value)

                                        Case AdvantageFramework.Agency.Settings.TS_FUNC_CAT.ToString

                                            AgencyFunctionCategory = CStr(Setting.Value)

                                        Case "MAIN_TS_NO_PAGING" ' webvantage only

                                            AgencyMainTimesheetNoPaging = CBool(Setting.Value)

                                    End Select

                                End If

                            Catch ex As Exception

                            End Try

                        Next

                        If AgencyDaysToDisplay = Nothing Then

                            AgencyDaysToDisplay = 7

                        End If

                        If AgencyDaysToDisplay <> 1 AndAlso AgencyDaysToDisplay <> 5 AndAlso AgencyDaysToDisplay <> 7 Then

                            AgencyDaysToDisplay = 7

                        End If

                        If String.IsNullOrEmpty(AgencyShowCommentsUsing) Then

                            AgencyShowCommentsUsing = "icon"

                        End If

                        If String.IsNullOrEmpty(AgencyStartWeekOn) Then

                            AgencyStartWeekOn = "sun"

                        End If

                        If String.IsNullOrEmpty(AgencyDivision) Then

                            AgencyDivision = "Division"

                        End If

                        If String.IsNullOrEmpty(AgencyProduct) Then

                            AgencyProduct = "Product"

                        End If

                        If String.IsNullOrEmpty(AgencyProductCategory) Then

                            AgencyProductCategory = "Prod Cat"

                        End If

                        If String.IsNullOrEmpty(AgencyJob) Then

                            AgencyJob = "Job"

                        End If

                        If String.IsNullOrEmpty(AgencyJobComp) Then

                            AgencyJobComp = "Component"

                        End If

                        If String.IsNullOrEmpty(AgencyFunctionCategory) Then

                            AgencyFunctionCategory = "Func/Cat"

                        End If

                        For Each SettingCode In UserSettingsToLoad

                            Try

                                AppVars = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, UserCode, "TIMESHEET")
                                           Where Entity.Name = SettingCode
                                           Select Entity).SingleOrDefault

                                If AppVars IsNot Nothing Then

                                    Select Case SettingCode

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.SHOW_CMNT_USING.ToString

                                            UserShowCommentsUsing = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.START_WEEK_ON.ToString

                                            UserStartWeekOn = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.DIVISION.ToString

                                            UserDivision = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.PROD_CAT.ToString

                                            UserProductCategory = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.PRODUCT.ToString

                                            UserProduct = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.JOB.ToString

                                            UserJob = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.JOB_COMP.ToString

                                            UserJobComp = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.FUNC_CAT.ToString

                                            UserFunctionCategory = CStr(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.MAIN_TS_NO_PAGING.ToString ' webvantage only

                                            UserMainTimesheetNoPaging = CBool(AppVars.Value)

                                        Case AdvantageFramework.EmployeeTimesheet.Settings.DAYS_TO_DISPLAY.ToString

                                            UserDaysToDisplay = CShort(AppVars.Value)

                                    End Select

                                End If

                            Catch ex As Exception
                                AppVars = Nothing
                            End Try

                        Next

                        If UserDaysToDisplay = Nothing Then

                            UserDaysToDisplay = AgencyDaysToDisplay

                        End If

                        If UserDaysToDisplay <> 1 AndAlso UserDaysToDisplay <> 5 AndAlso UserDaysToDisplay <> 7 Then

                            UserDaysToDisplay = 7

                        End If

                        If String.IsNullOrEmpty(UserShowCommentsUsing) Then

                            UserShowCommentsUsing = AgencyShowCommentsUsing

                        End If

                        If String.IsNullOrEmpty(UserStartWeekOn) Then

                            UserStartWeekOn = AgencyStartWeekOn

                        End If

                        If String.IsNullOrEmpty(UserDivision) Then

                            UserDivision = AgencyDivision

                        End If

                        If String.IsNullOrEmpty(UserProduct) Then

                            UserProduct = AgencyProduct

                        End If

                        If String.IsNullOrEmpty(UserProductCategory) Then

                            UserProductCategory = AgencyProductCategory

                        End If

                        If String.IsNullOrEmpty(UserJob) Then

                            UserJob = AgencyJob

                        End If

                        If String.IsNullOrEmpty(UserJobComp) Then

                            UserJobComp = AgencyJobComp

                        End If

                        If String.IsNullOrEmpty(UserFunctionCategory) Then

                            UserFunctionCategory = AgencyFunctionCategory

                        End If

                        If String.IsNullOrEmpty(UserMainTimesheetNoPaging) Then

                            UserMainTimesheetNoPaging = AgencyMainTimesheetNoPaging

                        End If

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        CommentsRequired = Agency.TimeCommentsRequired

                    End Using

                End Using

            Catch ex As Exception

            End Try

        End Sub
        Public Function SaveTimesheetDay(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal EmployeeCode As String,
                                         ByVal EmployeeDate As Date, ByVal FunctionOrCategory As String, ByVal EmployeeHours As Decimal,
                                         ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal DepartmentTeam As String,
                                         ByVal ProductCategory As String, ByVal UserID As String, ByVal Comments As String, ByVal AlertID As Integer,
                                         ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = False
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0

            Saved = SaveDay(DbContext.ConnectionString, DbContext.UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode,
                            EmployeeDate, FunctionOrCategory, ProductCategory, EmployeeHours, JobNumber, JobComponentNumber, DepartmentTeam, DbContext.UserCode, ErrorMessage, Comments,
                            NewEmployeeTimeID, NewEmployeeTimeDetailID, AlertID, False)

            Return Saved

        End Function
        Public Function CheckTimeCommentsRequired(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As Boolean

            'objects
            Dim IsRequired As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim TimeJobNumber As Integer = Nothing

            Try

                If JobNumber <= 0 Then

                    IsRequired = False

                ElseIf AdvantageFramework.Database.Procedures.Agency.Load(DbContext).TimeCommentsRequired.GetValueOrDefault(0) = 1 Then

                    IsRequired = True

                Else

                    If JobNumber > 0 Then

                        IsRequired = False

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                        If Job IsNot Nothing Then

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Job.ClientCode)

                            If Client IsNot Nothing Then

                                IsRequired = Client.RequireTimeComment

                            End If

                        End If

                    End If

                    If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 Then

                        IsRequired = False

                        Try

                            TimeJobNumber = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.LoadByEmployeeTimeID(DbContext, EmployeeTimeID)
                                             Where Entity.EmployeeTimeDetailID = EmployeeTimeDetailID
                                             Select [JN] = Entity.JobNumber).SingleOrDefault

                        Catch ex As Exception
                            TimeJobNumber = Nothing
                        End Try

                        If TimeJobNumber > 0 Then

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, TimeJobNumber)

                            If Job IsNot Nothing Then

                                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Job.ClientCode)

                                If Client IsNot Nothing Then

                                    IsRequired = Client.RequireTimeComment

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                IsRequired = False
            Finally
                CheckTimeCommentsRequired = IsRequired
            End Try

        End Function
        Public Function DeleteMissingTimeDetail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE [dbo].[MISSING_TIME_DTL] WHERE [EMP_CODE] = '{0}'", EmployeeCode))

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteMissingTimeDetail = Deleted
            End Try

        End Function
        Public Function ProcessMissingTime(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByVal CurrentDate As Date) As String

            Return ProcessMissingTime(Session.ConnectionString, Session.UserCode, EmployeeCode, CurrentDate)

        End Function
        Public Function ProcessMissingTime(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String, ByVal CurrentDate As Date) As String

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Supervisor As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Timesheet As AdvantageFramework.EmployeeTimesheet.Classes.Timesheet = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Message As String = Nothing
            Dim EmployeeFullName As String = Nothing
            Dim EmailSubject As String = Nothing
            Dim TimesheetStartDate As Date = Nothing
            Dim TimesheetEndDate As Date = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(ConnectionString, UserCode)

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            Try

                                If Employee.IsMissingTime.GetValueOrDefault(0) = 1 Then

                                    GetTimesheetDateRange(CurrentDate, TimesheetStartDate, TimesheetEndDate)

                                    Message = "Employee has missing time. "
                                    EmployeeFullName = Employee.FirstName & If(Employee.MiddleInitial <> "", " " & Employee.MiddleInitial & ". ", " ") & Employee.LastName
                                    EmailSubject = "Missing hours notification for: " & EmployeeFullName

                                    StringBuilder = New System.Text.StringBuilder
                                    StringBuilder.AppendLine("On " & System.DateTime.Now.ToString("MM/dd/yyyy") & " at " & System.DateTime.Now.ToShortTimeString & ", ")
                                    StringBuilder.AppendLine(EmployeeFullName & " entered time for the week of " & TimesheetStartDate.ToShortDateString() & " and includes the following hours per day")

                                    HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)
                                    HtmlEmail.AddHeaderRow(StringBuilder.ToString())

                                    Timesheet = Create(ConnectionString, UserCode, EmployeeCode, TimesheetStartDate, TimesheetEndDate)

                                    If Timesheet IsNot Nothing Then

                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(0).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(0).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day1Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(1).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(1).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day2Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(2).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(2).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day3Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(3).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(3).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day4Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(4).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(4).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day5Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(5).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(5).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day6Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))
                                        HtmlEmail.AddKeyValueRow(Timesheet.StartDate.AddDays(6).ToShortDateString() & "&nbsp;&nbsp;" & Timesheet.StartDate.AddDays(6).DayOfWeek.ToString, Timesheet.TimeSheetEntries.Select(Function(Entry) Entry.Day7Hours.GetValueOrDefault(0)).Sum.ToString("00.00"))

                                    End If

                                    HtmlEmail.Finish()

                                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                    If Agency.EmailSupervisor.GetValueOrDefault(0) = 1 Then

                                        Message &= "Email supervisor is true. "

                                        Supervisor = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Employee.SupervisorEmployeeCode)

                                        If Supervisor IsNot Nothing AndAlso Supervisor.Email <> "" Then

                                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                                                If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Supervisor.Email, "[Supervisor Alert] " & EmailSubject, HtmlEmail.ToString, 3,
                                                                             New String() {""}, SendingEmailStatus) Then

                                                    Message &= "Email supervisor sent. "

                                                End If

                                            End Using

                                        Else

                                            Message &= "No supervisor email address. "

                                        End If

                                    End If

                                    If Agency.EmailITContact.GetValueOrDefault(0) = 1 Then

                                        Message &= "Email IT Contact is true. "

                                        If Agency.ITContactEmail <> "" Then

                                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                                                If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Agency.ITContactEmail, "[I/T Contact Alert] " & EmailSubject, HtmlEmail.ToString, 3, New String() {""}, SendingEmailStatus) Then

                                                    Message &= "Email supervisor sent. "

                                                End If

                                            End Using

                                        Else

                                            Message &= "No IT Contact email address! "

                                        End If

                                    End If

                                    Employee.IsMissingTime = 0

                                    AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                                Else

                                    Message &= "Employee is not missing time. "

                                End If

                            Catch ex As Exception
                            End Try

                        End If

                    End Using

                    DeletePriorZeroHours(DbContext, EmployeeCode, CurrentDate, Message)

                End Using

            Catch ex As Exception
                Message = "Error processing missing time."
            Finally
                ProcessMissingTime = Message
            End Try

        End Function

        Public Function CheckEditStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As AdvantageFramework.Timesheet.TimesheetEditType

            Dim ReturnInteger As Integer = 0
            Dim EmployeeTimeID As Integer = 0

            Try

                EmployeeTimeID = GetEmployeeTimeIDForEmployee(DbContext, EmployeeCode, EmployeeDate)

                If EmployeeTimeID > 0 Then

                    Dim SqlParameterEmployeeTimeID As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SqlParameterEmployeeTimeDetailID As System.Data.SqlClient.SqlParameter = Nothing

                    SqlParameterEmployeeTimeID = New System.Data.SqlClient.SqlParameter("@ETID", SqlDbType.Int)
                    SqlParameterEmployeeTimeDetailID = New System.Data.SqlClient.SqlParameter("@ETDTLID", SqlDbType.Int)

                    SqlParameterEmployeeTimeID.Value = EmployeeTimeID
                    SqlParameterEmployeeTimeDetailID.Value = 0


                    ReturnInteger = DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[usp_wv_ts_Check_Edit_Status] @ETID, @ETDTLID;",
                                                                            SqlParameterEmployeeTimeID, SqlParameterEmployeeTimeDetailID).SingleOrDefault


                End If

            Catch ex As Exception
                ReturnInteger = 0
            End Try

            Return CType(ReturnInteger, AdvantageFramework.Timesheet.TimesheetEditType)

        End Function
        Public Function GetEmployeeTimeIDForEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As Integer

            Dim EmployeeTimeID As Integer = 0

            Try

                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@Empcode", SqlDbType.VarChar, 6)
                SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EmpDate", SqlDbType.SmallDateTime)

                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterEmployeeDate.Value = EmployeeDate

                Try

                    EmployeeTimeID = DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[usp_wv_ts_GetETID] @Empcode, @EmpDate;",
                                                                             SqlParameterEmployeeCode, SqlParameterEmployeeDate).SingleOrDefault

                Catch ex As Exception
                    EmployeeTimeID = 0
                End Try


            Catch ex As Exception
                EmployeeTimeID = 0
            End Try

            Return EmployeeTimeID

        End Function
        Public Function CheckApprovalStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As Boolean

            Dim EmployeeTimeID As Integer = 0

            Try

                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@Empcode", SqlDbType.VarChar, 6)
                SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EmpDate", SqlDbType.SmallDateTime)

                Try

                    EmployeeTimeID = DbContext.Database.SqlQuery(Of Integer)("EXEC [dbo].[usp_wv_ts_CheckApproval] @Empcode, @EmpDate;",
                                                                             SqlParameterEmployeeCode, SqlParameterEmployeeDate).SingleOrDefault

                Catch
                    EmployeeTimeID = 0
                End Try


            Catch ex As Exception
                EmployeeTimeID = 0
            End Try

            Return EmployeeTimeID > 0

        End Function

        Public Sub GetTimesheetDateRange(ByVal SelectedDate As Date, ByRef StartDate As Date, ByRef EndDate As Date)

            Try

                If SelectedDate = Nothing Then

                    SelectedDate = System.DateTime.Now

                End If

                If SelectedDate.DayOfWeek = DayOfWeek.Sunday Then

                    StartDate = SelectedDate

                Else

                    StartDate = SelectedDate.AddDays(-SelectedDate.DayOfWeek + System.DayOfWeek.Sunday)

                End If

                EndDate = StartDate.AddDays(6)

            Catch ex As Exception

            End Try

        End Sub
        Public Function DeletePriorZeroHours(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal PriorToDate As Date, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim FirstDayOfThisWeek As Date = Nothing
            Dim CutoffDate As Date = Nothing
            Dim ParameterEmployeeCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            Dim ParameterCutOffDate As New SqlParameter("@CUTOFF_DATE", SqlDbType.SmallDateTime)

            Try

                If System.DateTime.Now.DayOfWeek = DayOfWeek.Sunday Then

                    FirstDayOfThisWeek = System.DateTime.Now

                Else

                    FirstDayOfThisWeek = System.DateTime.Now.AddDays(-System.DateTime.Now.DayOfWeek + System.DayOfWeek.Sunday)

                End If
                If PriorToDate >= FirstDayOfThisWeek Then 'Take the smaller of the two

                    PriorToDate = FirstDayOfThisWeek

                End If
                If PriorToDate.Date.DayOfWeek = DayOfWeek.Sunday Then

                    CutoffDate = PriorToDate

                Else

                    CutoffDate = PriorToDate.AddDays(-PriorToDate.DayOfWeek + System.DayOfWeek.Sunday)

                End If

                ParameterEmployeeCode.Value = EmployeeCode
                'Hack for ppl in different time zone and different start of the week;
                'Just to make sure a few days are not included...
                ParameterCutOffDate.Value = CutoffDate.AddDays(-3)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_ts_DeletePriorZeroHours] @EMP_CODE, @CUTOFF_DATE;", ParameterEmployeeCode, ParameterCutOffDate)
                Deleted = True

            Catch ex As Exception
                ErrorMessage = ex.Message
                Deleted = False
            Finally
                DeletePriorZeroHours = Deleted
            End Try

        End Function
        Public Function LoadTimeCategorOrFunctionListByEmployee(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String, ByVal IndirectTime As Boolean) As IEnumerable

            'objects
            Dim FunctionOrCategoryList As IEnumerable = Nothing
            Dim EmployeeUserIDs As Integer() = Nothing
            Dim FilterFunctions As Boolean = False
            Dim FunctionCodes As String() = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    If IndirectTime Then

                        FunctionOrCategoryList = AdvantageFramework.Database.Procedures.IndirectCategory.LoadAllActive(DbContext).ToList

                    Else

                        If Session.User.EmployeeCode <> EmployeeCode Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                Try

                                    EmployeeUserIDs = (From Entity In AdvantageFramework.Security.Database.Procedures.User.LoadByEmployeeCode(SecurityDbContext, EmployeeCode)
                                                       Select Entity.ID).ToArray

                                    For Each EmployeeUserID In EmployeeUserIDs

                                        If AdvantageFramework.Security.LoadUserSetting(Session, EmployeeUserID, Security.UserSettings.EMP_TS_FNC) = True Then

                                            FilterFunctions = True
                                            Exit For

                                        End If

                                    Next

                                Catch ex As Exception

                                End Try

                            End Using

                        ElseIf AdvantageFramework.Security.LoadUserSetting(Session, Session.User.ID, Security.UserSettings.EMP_TS_FNC) = True Then

                            FilterFunctions = True

                        End If

                        If FilterFunctions Then

                            Try

                                FunctionCodes = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetFunction.LoadByEmployeeCode(DbContext, EmployeeCode)
                                                 Select Entity.FunctionCode).ToArray

                                FunctionOrCategoryList = (From Entity In AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext)
                                                          Where FunctionCodes.Contains(Entity.Code)
                                                          Select Entity).ToList

                            Catch ex As Exception

                            End Try

                        Else

                            FunctionOrCategoryList = AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext).ToList

                        End If

                    End If

                End Using

            Catch ex As Exception
                FunctionOrCategoryList = Nothing
            Finally
                LoadTimeCategorOrFunctionListByEmployee = FunctionOrCategoryList
            End Try

        End Function
        Public Function LoadEmployeeDepartments(ByVal Session As AdvantageFramework.Security.Session, ByVal EmployeeCode As String) As IEnumerable

            'objects
            Dim EmployeeDepartments As String() = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    EmployeeDepartments = (From Entity In AdvantageFramework.Database.Procedures.EmployeeDepartment.Load(DbContext)
                                           Where Entity.EmployeeCode = EmployeeCode
                                           Select Entity.DepartmentTeamCode).ToArray

                    LoadEmployeeDepartments = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                               Where EmployeeDepartments.Contains(Entity.Code)
                                               Select Entity).ToList

                End Using

            Catch ex As Exception
                LoadEmployeeDepartments = Nothing
            End Try

        End Function
        Public Sub ParseDetailRecordInformation(ByVal ReturnMessage As String, ByRef EmployeeTimeID As Integer, ByRef EmployeeTimeDetailID As Integer)

            'objects
            Dim MessageValues As String() = Nothing
            Try

                MessageValues = ReturnMessage.Split("|")

                If MessageValues IsNot Nothing AndAlso MessageValues.Count > 0 Then

                    EmployeeTimeID = CInt(MessageValues.GetValue(1))
                    EmployeeTimeDetailID = CInt(MessageValues.GetValue(2))

                End If

            Catch ex As Exception
                EmployeeTimeID = Nothing
                EmployeeTimeDetailID = Nothing
            End Try

        End Sub
        Public Function CheckIfPostPeriodIsAvailable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DateToCheck As Date) As Boolean

            'objects
            Dim IsAvailable As Boolean = True

            Try

                If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).CheckClosedPeriods.GetValueOrDefault(0) = 1 Then

                    If (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext)
                        Where PostPeriod.StartDate <= DateToCheck AndAlso
                              PostPeriod.EndDate >= DateToCheck
                        Select PostPeriod).Any Then

                        If (From PostPeriod In AdvantageFramework.Database.Procedures.PostPeriod.Load(DbContext)
                            Where PostPeriod.StartDate <= DateToCheck AndAlso
                                  PostPeriod.EndDate >= DateToCheck AndAlso
                                  (PostPeriod.EmployeeTimeStatus Is Nothing OrElse
                                   PostPeriod.EmployeeTimeStatus = "C")
                            Select PostPeriod).Any = False Then

                            IsAvailable = False

                        End If

                    Else

                        IsAvailable = False

                    End If

                End If

            Catch ex As Exception
                IsAvailable = True
            End Try

            CheckIfPostPeriodIsAvailable = IsAvailable

        End Function
        Public Function IsFunctionValid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal FunctionCode As String) As Boolean

            Dim FunctionIsValid As Boolean = False

            Try

                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterFunctionCode As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
                SqlParameterFunctionCode = New System.Data.SqlClient.SqlParameter("@FuncCode", SqlDbType.VarChar)

                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterFunctionCode.Value = FunctionCode

                FunctionIsValid = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_validate_functioncat_ts_addnew] @EmpCode, @FuncCode;"),
                                                                          SqlParameterEmployeeCode,
                                                                          SqlParameterFunctionCode).SingleOrDefault


            Catch ex As Exception
                FunctionIsValid = False
            End Try

            Return FunctionIsValid

        End Function
        Public Function IsCategoryValid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CategoryCode As String) As Boolean

            Dim CategoryIsValid = False

            Try

                Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing

                IndirectCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, CategoryCode)

                If IndirectCategory IsNot Nothing AndAlso
                    (IndirectCategory.IsInactive Is Nothing OrElse IndirectCategory.IsInactive = 0) Then

                    CategoryIsValid = True

                End If

            Catch ex As Exception
                CategoryIsValid = False
            End Try

            Return CategoryIsValid

        End Function
        Public Function SubmitWeekForApproval(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByRef ErrorMessage As String) As Boolean

            Return SubmitUnSubmitWeekForApproval(Session, DbContext, True, EmployeeCode, EmployeeDate, ErrorMessage)

        End Function
        Public Function UnSubmitWeekForApproval(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByRef ErrorMessage As String) As Boolean

            Return SubmitUnSubmitWeekForApproval(Session, DbContext, False, EmployeeCode, EmployeeDate, ErrorMessage)

        End Function

        Public Function SubmitForApproval(ByVal Session As AdvantageFramework.Security.Session,
                                          ByVal EmployeeCode As String, ByVal EmployeeDate As Date,
                                          ByVal Approve As Boolean, ByVal SendEmail As Boolean,
                                          ByRef ErrorMessage As String) As Boolean

            Dim Submitted As Boolean = True

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Dim TimeApprovalActive As Boolean = False
                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                    Dim CurrentDate As Date = Nothing
                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                    Dim CurrentEditStatus As Integer = 0 'Legacy:  6 = Approved, 7 = Pending, 8 = Denied
                    Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing

                    EmployeeTime = AdvantageFramework.Database.Procedures.EmployeeTime.LoadByEmployeeCodeAndDate(DbContext, EmployeeCode, EmployeeDate)

                    If EmployeeTime IsNot Nothing AndAlso EmployeeTime.TotalHours <> 0 Then

                        Try

                            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                            Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
                            Dim SqlParameterReturnOnlyType As System.Data.SqlClient.SqlParameter = Nothing

                            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
                            SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EMP_DATE", SqlDbType.SmallDateTime)
                            SqlParameterReturnOnlyType = New System.Data.SqlClient.SqlParameter("@RETURN_ONLY_TYPE", SqlDbType.Bit)

                            SqlParameterEmployeeCode.Value = EmployeeCode
                            SqlParameterEmployeeDate.Value = EmployeeDate
                            SqlParameterReturnOnlyType.Value = True

                            CurrentEditStatus = DbContext.Database.SqlQuery(Of Integer)(String.Format("[dbo].[advsp_timesheet_employee_day_approval_status] @EMP_CODE, @EMP_DATE, @RETURN_ONLY_TYPE;"),
                                                                                        SqlParameterEmployeeCode,
                                                                                        SqlParameterEmployeeDate,
                                                                                        SqlParameterReturnOnlyType).SingleOrDefault

                        Catch ex As Exception
                            CurrentEditStatus = 0
                        End Try

                        If CurrentEditStatus <> 6 Then 'Already approved

                            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                            Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing
                            Dim SqlParameterApprove As System.Data.SqlClient.SqlParameter = Nothing

                            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
                            SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EmpDate", SqlDbType.SmallDateTime)
                            SqlParameterApprove = New System.Data.SqlClient.SqlParameter("@Approve", SqlDbType.Int)

                            SqlParameterEmployeeCode.Value = EmployeeCode
                            SqlParameterEmployeeDate.Value = EmployeeDate

                            If Approve = True Then

                                SqlParameterApprove.Value = 1

                                If AdvantageFramework.Timesheet.DayIsMissingComment(Session.ConnectionString, Session.UserCode,
                                                                                EmployeeCode, EmployeeDate) = True Then

                                    ErrorMessage = String.Format("{0} is missing comments and cannot be submitted for approval.", EmployeeDate.DayOfWeek.ToString)
                                    Submitted = False

                                Else

                                    Try

                                        'DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[EMP_TIME] WITH(ROWLOCK) SET APPR_PENDING = 1, APPR_FLAG = 0 WHERE [EMP_CODE] = '{0}' AND [EMP_DATE] = '{1}';", EmployeeCode, EmployeeDate))
                                        DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[usp_wv_ts_submit_approval] @EmpCode, @EmpDate, @Approve;"),
                                                                         SqlParameterEmployeeCode,
                                                                         SqlParameterEmployeeDate,
                                                                         SqlParameterApprove)

                                    Catch ex As Exception
                                        Submitted = False
                                    End Try

                                End If

                            Else

                                SqlParameterApprove.Value = 0

                                Try

                                    DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[usp_wv_ts_submit_approval] @EmpCode, @EmpDate, @Approve;"),
                                                                     SqlParameterEmployeeCode,
                                                                     SqlParameterEmployeeDate,
                                                                     SqlParameterApprove)

                                    AdvantageFramework.Timesheet.DeleteZeroHours(Session.ConnectionString, EmployeeCode, EmployeeDate)

                                Catch ex As Exception
                                    Submitted = False
                                End Try

                            End If

                            If Approve AndAlso Submitted = True Then

                                If Approve = True AndAlso SendEmail = True Then

                                    Dim AsyncEmail As New ApprovalEmailAsync(Session, EmployeeCode)
                                    AsyncEmail.IsSubmittingEntireWeek = False
                                    AsyncEmail.SingleSubmitDate = EmployeeDate
                                    AsyncEmail.Send()

                                End If

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Submitted = False
            Finally
                SubmitForApproval = Submitted
            End Try

        End Function
        Public Function CheckIfApprovalRequired(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim ApprovalRequired As Boolean = False

            Try

                If DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(TIME_APPR_ACTIVE, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault() = 1 Then

                    ApprovalRequired = True

                    If AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode).TimesheetApprovalFlag.GetValueOrDefault(False) = True Then

                        ApprovalRequired = False

                    End If

                End If

            Catch ex As Exception
                ApprovalRequired = False
            Finally
                CheckIfApprovalRequired = ApprovalRequired
            End Try

        End Function
        Public Function LoadDaysByApprovalStatus(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Status As String) As IEnumerable

            'objects
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing
            Dim DayStatusList As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus) = Nothing
            Dim DayStatus As AdvantageFramework.EmployeeTimesheet.Classes.DayStatus = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim IsApprovalRequired As Boolean = False
            Dim CurrentDate As Date = Nothing
            Dim CurrentDayStandardHours As Decimal = 0
            Dim CheckClosedPostPeriods As Boolean = False
            Dim PostPeriodClosed As Boolean = False

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    IsApprovalRequired = CheckIfApprovalRequired(DbContext, EmployeeCode)
                    CheckClosedPostPeriods = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).CheckClosedPeriods.GetValueOrDefault(0))

                    CurrentDate = StartDate

                    DayStatusList = New Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DayStatus)

                    While CurrentDate <= EndDate

                        CurrentDayStandardHours = 0

                        EmployeeTime = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTime.Load(DbContext)
                                        Where Entity.EmployeeCode = EmployeeCode AndAlso
                                              Entity.Date = CurrentDate
                                        Select Entity).SingleOrDefault

                        If CheckIfEmployeeWorksOnDay(Employee, CurrentDate.DayOfWeek, CurrentDayStandardHours) OrElse (EmployeeTime IsNot Nothing AndAlso EmployeeTime.TotalHours > 0) Then

                            DayStatus = New AdvantageFramework.EmployeeTimesheet.Classes.DayStatus

                            If CheckClosedPostPeriods Then

                                PostPeriodClosed = Not CheckIfPostPeriodIsAvailable(DbContext, CurrentDate)

                            Else

                                PostPeriodClosed = False

                            End If

                            With DayStatus

                                .DayDate = CurrentDate
                                .StandardHours = CurrentDayStandardHours

                                If EmployeeTime IsNot Nothing Then

                                    .TotalHours = EmployeeTime.TotalHours.GetValueOrDefault(0)
                                    .ApprovalNotes = EmployeeTime.ApprovalNotes

                                    If EmployeeTime.IsApproved.GetValueOrDefault(0) = 0 AndAlso EmployeeTime.IsPendingApproval.GetValueOrDefault(0) = 1 Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Pending

                                    ElseIf EmployeeTime.IsApproved.GetValueOrDefault(0) = 0 AndAlso EmployeeTime.IsPendingApproval.GetValueOrDefault(0) = 2 Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Denied

                                    ElseIf EmployeeTime.IsApproved.GetValueOrDefault(0) = 1 AndAlso (EmployeeTime.IsPendingApproval.GetValueOrDefault(0) = 0 OrElse EmployeeTime.IsPendingApproval.GetValueOrDefault(0) = 1) Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Approved

                                    ElseIf EmployeeTime.TotalHours.GetValueOrDefault(0) <> 0 AndAlso EmployeeTime.IsApproved.GetValueOrDefault(0) = 0 AndAlso EmployeeTime.IsPendingApproval.GetValueOrDefault(0) = 0 Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.NotSubmitted

                                    ElseIf EmployeeTime.TotalHours.GetValueOrDefault(0) = 0 Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Missing

                                    Else

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.ReadyToSubmit

                                    End If

                                Else

                                    .TotalHours = 0
                                    .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Missing

                                End If

                                If PostPeriodClosed Then

                                    .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.PostPeriodClosed

                                End If

                                If IsApprovalRequired = False Then

                                    If .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.NotSubmitted OrElse
                                       .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.ReadyToSubmit Then

                                        .Status = AdvantageFramework.EmployeeTimesheet.DayApprovalType.Entered

                                    End If

                                End If

                            End With

                            'If Status = "" Then

                            'End If

                            DayStatusList.Add(DayStatus)

                        End If

                        CurrentDate = CurrentDate.AddDays(1)

                    End While

                End If

            Catch ex As Exception
                DayStatusList = Nothing
            Finally
                LoadDaysByApprovalStatus = DayStatusList
            End Try

        End Function
        Public Function CheckIfEmployeeWorksOnDay(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal DayOfWeek As System.DayOfWeek, ByRef ScheduleHours As Decimal) As Boolean

            'objects
            Dim DoesWork As Boolean = False

            Try

                If String.IsNullOrWhiteSpace(Employee.WorkDays) = False Then

                    If Employee.WorkDays.ToUpper.Contains(DayOfWeek.ToString.Substring(0, 3).ToUpper) Then

                        Select Case DayOfWeek

                            Case System.DayOfWeek.Sunday

                                ScheduleHours = Employee.SundayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Monday

                                ScheduleHours = Employee.MondayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Tuesday

                                ScheduleHours = Employee.TuesdayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Wednesday

                                ScheduleHours = Employee.WednesdayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Thursday

                                ScheduleHours = Employee.ThursdayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Friday

                                ScheduleHours = Employee.FridayHours.GetValueOrDefault(0)

                            Case System.DayOfWeek.Saturday

                                ScheduleHours = Employee.SaturdayHours.GetValueOrDefault(0)

                        End Select

                        DoesWork = True

                    End If

                End If

            Catch ex As Exception
                DoesWork = False
            Finally
                CheckIfEmployeeWorksOnDay = DoesWork
            End Try

        End Function
        Public Function CheckIfEmployeeWorksOnDay(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String, ByVal DayOfWeek As System.DayOfWeek, ByRef ScheduleHours As Decimal) As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            CheckIfEmployeeWorksOnDay = CheckIfEmployeeWorksOnDay(Employee, DayOfWeek, ScheduleHours)

        End Function
        Public Function CanSubmitTime(ByVal DayApprovalType As AdvantageFramework.EmployeeTimesheet.DayApprovalType) As Boolean

            'objects
            Dim CanSubmit As Boolean = False

            If DayApprovalType = Methods.DayApprovalType.NotSubmitted OrElse
               DayApprovalType = Methods.DayApprovalType.Entered OrElse
               DayApprovalType = Methods.DayApprovalType.ReadyToSubmit Then

                CanSubmit = True

            End If

            CanSubmitTime = CanSubmit

        End Function
        Public Function CanUnSubmitTime(ByVal DayApprovalType As AdvantageFramework.EmployeeTimesheet.DayApprovalType) As Boolean

            'objects
            Dim CanUnSubmit As Boolean = False

            If DayApprovalType = Methods.DayApprovalType.Pending OrElse
               DayApprovalType = Methods.DayApprovalType.Denied Then

                CanUnSubmit = True

            End If

            CanUnSubmitTime = CanUnSubmit

        End Function
        Public Function GetProgressColor(ByVal ProgressType As ProgressTypes) As System.Drawing.Color

            'objects
            Dim Color As System.Drawing.Color = Nothing

            Select Case ProgressType

                Case ProgressTypes.Quoted

                    Color = System.Drawing.ColorTranslator.FromHtml("#3EB71E")

                Case ProgressTypes.OverThreshold

                    Color = System.Drawing.ColorTranslator.FromHtml("#CD5C5C")

                Case ProgressTypes.NotQuoted

                    Color = Drawing.Color.Gold

            End Select

            GetProgressColor = Color

        End Function
        Public Function CopyTimeEntry(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String,
                                      ByVal SourceEtID As Integer, ByVal SourceEtDtlID As Integer, ByVal SourceTimeType As String,
                                      ByVal TargetDate As Date, ByVal TargetEmployeeCode As String,
                                      ByVal CopyHours As Boolean,
                                      Optional ByRef ReturnMessage As String = Nothing) As Boolean

            Dim Copied As Boolean = False

            Dim SqlParameterUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            Dim SqlParameterSourceEtID As New System.Data.SqlClient.SqlParameter("@SOURCE_ET_ID", SqlDbType.Int)
            Dim SqlParameterSourceEtDtlID As New System.Data.SqlClient.SqlParameter("@SOURCE_ET_DTL_ID", SqlDbType.Int)
            Dim SqlParameterSourceTimeType As New System.Data.SqlClient.SqlParameter("@SOURCE_TIME_TYPE", SqlDbType.VarChar, 1)
            Dim SqlParameterTargetDate As New System.Data.SqlClient.SqlParameter("@TARGET_DATE", SqlDbType.SmallDateTime)
            Dim SqlParameterTargetEmployeeCode As New System.Data.SqlClient.SqlParameter("@TARGET_EMP_CODE", SqlDbType.VarChar, 6)
            Dim SqlParameterCopyHours As New System.Data.SqlClient.SqlParameter("@COPY_HOURS", SqlDbType.Bit)
            Dim SqlParameterCreateDate As New System.Data.SqlClient.SqlParameter("@CREATE_DATE_IN", SqlDbType.SmallDateTime)

            SqlParameterUserCode.Value = UserCode
            SqlParameterSourceEtID.Value = SourceEtID
            SqlParameterSourceEtDtlID.Value = SourceEtDtlID
            SqlParameterSourceTimeType.Value = SourceTimeType
            SqlParameterTargetDate.Value = TargetDate
            SqlParameterTargetEmployeeCode.Value = TargetEmployeeCode
            SqlParameterCopyHours.Value = CopyHours
            SqlParameterCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, TargetEmployeeCode)

            ReturnMessage = DbContext.Database.SqlQuery(Of String)("EXEC advsp_timesheet_copy_entry @USER_CODE, @SOURCE_ET_ID, @SOURCE_ET_DTL_ID, @SOURCE_TIME_TYPE, @TARGET_DATE, @TARGET_EMP_CODE, @COPY_HOURS, @CREATE_DATE_IN;",
                                                                       SqlParameterUserCode,
                                                                       SqlParameterSourceEtID,
                                                                       SqlParameterSourceEtDtlID,
                                                                       SqlParameterSourceTimeType,
                                                                       SqlParameterTargetDate,
                                                                       SqlParameterTargetEmployeeCode,
                                                                       SqlParameterCopyHours,
                                                                       SqlParameterCreateDate).FirstOrDefault

            Copied = ReturnMessage.Contains("SUCCESS") = True

            CopyTimeEntry = Copied

        End Function

        Public Function LoadAvailableJobs(DbContext As AdvantageFramework.Database.DbContext,
                                          ClientCode As String, DivisionCode As String, ProductCode As String) As System.Collections.Generic.IEnumerable(Of AdvantageFramework.Database.Entities.Job)

            'LoadAvailableJobs = From Item In LoadAvailableJobComponents(DbContext, ClientCode, DivisionCode, ProductCode, 0)
            '                    Group By JobNumber = Item.JobNumber Into Job = Group
            '                    Select New AdvantageFramework.Database.Views.JobView With {.ClientCode = Job.First.ClientCode, .ClientName = Job.First.ClientName, .DivisionCode = Job.First.DivisionCode, .DivisionName = Job.First.DivisionName, .IsOpen = Job.First.IsOpen, .JobDescription = Job.First.JobDescription, .JobNumber = Job.First.JobNumber, .OfficeCode = Job.First.OfficeCode, .OfficeName = Job.First.OfficeName, .ProductCode = Job.First.ProductCode, .ProductDescription = Job.First.ProductDescription}

            Dim Jobs As Generic.IEnumerable(Of AdvantageFramework.Database.Entities.Job) = Nothing

            Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                    Jobs = From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityContext, DbContext.UserCode)
                           Where Entity.ClientCode = ClientCode AndAlso
                                       Entity.DivisionCode = DivisionCode AndAlso
                                       Entity.ProductCode = ProductCode
                           Select Entity

                ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                    Jobs = From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityContext, DbContext.UserCode)
                           Where Entity.ClientCode = ClientCode AndAlso
                                       Entity.DivisionCode = DivisionCode
                           Select Entity

                ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                    Jobs = From Entity In AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityContext, DbContext.UserCode)
                           Where Entity.ClientCode = ClientCode
                           Select Entity

                Else

                    Jobs = AdvantageFramework.Database.Procedures.Job.LoadOpenByUserCode(DbContext, SecurityContext, DbContext.UserCode)

                End If

            End Using

            Return Jobs

        End Function
        Public Function LoadAvailableJobComponents(DbContext As AdvantageFramework.Database.DbContext, ClientCode As String, DivisionCode As String, ProductCode As String, JobNumber As Integer) As System.Collections.Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)

            LoadAvailableJobComponents = AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, DbContext.UserCode, ClientCode, DivisionCode, ProductCode, JobNumber, False, _AllowProcessControls)

        End Function
        Public Function ApprovedEstimateRequiredButNotFound(DbContext As AdvantageFramework.Database.DbContext, JobNumber As Integer, JobComponentNumber As Short) As Boolean

            Dim ApprovedEstimateRequired As Boolean = False
            Dim ReturnValue As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            If Agency IsNot Nothing Then

                If Agency.ApprovedEstimateRequired IsNot Nothing AndAlso Agency.ApprovedEstimateRequired = True Then

                    ApprovedEstimateRequired = True

                End If

            End If
            If ApprovedEstimateRequired = True Then

                Dim JobHasApprovedEstimate As Boolean = False

                JobHasApprovedEstimate = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM ESTIMATE_APPROVAL WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}",
                                                                                                   JobNumber, JobComponentNumber)).SingleOrDefault > 0

                If JobHasApprovedEstimate = False Then

                    ReturnValue = True

                End If

            End If

            ApprovedEstimateRequiredButNotFound = ReturnValue

        End Function

        Public Function WriteTimesheetSuperviorApprovalLink(ByVal URL As String, ByVal [Date] As DateTime, ByVal EmployeeCode As String, ByVal OpenWeek As Boolean) As String

            Dim OpenAsWeekParameter As String = String.Empty

            If OpenWeek = True Then

                OpenAsWeekParameter = "1"

            Else

                OpenAsWeekParameter = "0"

            End If

            Return String.Format("<a href='{0}/SupervisorApproval_Timesheet.aspx?sedate={1}&empcode={2}&doweek={3}'>Click here to navigate to Timesheet Approval.</a>",
                                 URL, [Date].ToShortDateString(), EmployeeCode, OpenAsWeekParameter)

        End Function
        Public Sub FixTimesheetApprovalRequestLinkForInternalViewing(ByRef AlertBody As String)

            If AlertBody.Contains("SupervisorApproval_Timesheet.aspx?") = True Then

                Dim ar() As String
                Dim qs As String = String.Empty

                ar = AlertBody.Split("?")

                qs = ar(1)
                qs = qs.Substring(0, qs.IndexOf("'")).Trim()

                AlertBody = String.Format("<a href=""#"" onclick=""OpenRadWindow('','SupervisorApproval_Timesheet.aspx?{0}');return false;"">Click here to navigate to Timesheet Approval.</a>", qs)

            End If

        End Sub
        Public Function CheckClosedPeriods(DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                CheckClosedPeriods = DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(TS_PPERIOD_CHK, 0) FROM dbo.AGENCY").FirstOrDefault = 1

            Catch ex As Exception
                CheckClosedPeriods = False
            End Try

        End Function
        Public Function CheckIfDateIsEditable(DbContext As AdvantageFramework.Database.DbContext, EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex,
                                              EmployeeCode As String, EmployeeTimeID As Integer, EmployeeTimeDetailID As Integer, [Date] As Date,
                                              JobNumber As Integer, JobComponentNumber As Short, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsEditable As Boolean = True
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim CanEditEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.CanEditEmployeeTimeReponse = Nothing

            If CheckIfPostPeriodIsAvailable(DbContext, [Date]) Then

                If EmployeeTimeID > 0 AndAlso EmployeeTimeDetailID > 0 AndAlso EmployeeTimeRecord IsNot Nothing Then

                    If EmployeeTimeRecord.DayPostPeriodClosed.GetValueOrDefault(False) = True Then

                        IsEditable = False
                        ErrorMessage = "Cannot edit a day where the post period has been closed."

                    ElseIf EmployeeTimeRecord.DayIsPendingApproval.GetValueOrDefault(False) = True Then

                        IsEditable = False
                        ErrorMessage = "Cannot edit a day that is pending approval."

                    ElseIf EmployeeTimeRecord.DayIsApproved.GetValueOrDefault(False) = True Then

                        IsEditable = False
                        ErrorMessage = "Cannot edit an approved day."

                    ElseIf EmployeeTimeRecord.DayIsDenied.GetValueOrDefault(False) = True Then

                        IsEditable = True

                    Else

                        IsEditable = True

                    End If

                    If EmployeeTimeRecord.IsLockedByProcessControl = 1 Then

                        IsEditable = False
                        ErrorMessage = EmployeeTimeRecord.NonEditMessage

                    End If

                    If IsEditable Then

                        CanEditEmployeeTimeReponse = CheckCanEditEmployeeTime(DbContext, EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID)

                        If CanEditEmployeeTimeReponse IsNot Nothing Then

                            IsEditable = Convert.ToBoolean(CanEditEmployeeTimeReponse.CAN_EDIT)

                            If IsEditable = False Then

                                ErrorMessage = CanEditEmployeeTimeReponse.RETURN_MESSAGE

                            End If

                        End If

                    End If

                Else

                    JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                    If JobComponent IsNot Nothing Then

                        If JobComponent.JobProcessNumber.GetValueOrDefault(1) = 12 OrElse JobComponent.JobProcessNumber.GetValueOrDefault(1) = 10 OrElse
                            JobComponent.JobProcessNumber.GetValueOrDefault(1) = 9 OrElse JobComponent.JobProcessNumber.GetValueOrDefault(1) = 6 OrElse
                            JobComponent.JobProcessNumber.GetValueOrDefault(1) = 5 OrElse JobComponent.JobProcessNumber.GetValueOrDefault(1) = 3 OrElse
                            JobComponent.JobProcessNumber.GetValueOrDefault(1) = 2 Then

                            IsEditable = False
                            ErrorMessage = "* Process Control does not allow editing"

                        End If

                    End If

                    If IsEditable AndAlso EmployeeTimeID > 0 Then

                        CanEditEmployeeTimeReponse = CheckCanEditEmployeeTime(DbContext, EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID)

                        If CanEditEmployeeTimeReponse IsNot Nothing Then

                            IsEditable = Convert.ToBoolean(CanEditEmployeeTimeReponse.CAN_EDIT)

                            If IsEditable = False Then

                                ErrorMessage = CanEditEmployeeTimeReponse.RETURN_MESSAGE

                            End If

                        End If

                    End If

                End If

            Else

                IsEditable = False
                ErrorMessage = "Cannot edit a day where the post period is not available."

            End If

            If IsEditable = True Then
                ErrorMessage = String.Empty
            End If

            CheckIfDateIsEditable = IsEditable

        End Function
        Public Function SaveEmployeeNonProductionTime(ConnectionString As String, UserCode As String, EmployeeTimeID As Integer, EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, IndirectCategoryCode As String,
                                                      Hours As Decimal, DepartmentTeamCode As String, Comments As String, ByRef ErrorMessage As String) As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse

            Dim EmployeeTimeRecords As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex) = Nothing
            Dim EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim ErrorMessageObjectParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse = Nothing

            SaveEmployeeTimeReponse = New AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse(0, 0, "", 0)

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                Try

                    EmployeeTimeRecords = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, EmployeeCode, [Date], [Date], "JOB_NUMBER", DbContext.UserCode).ToList

                Catch ex As Exception
                    EmployeeTimeRecords = Nothing
                End Try

                If CheckIfValidData(DbContext, EmployeeTimeRecords, EmployeeTimeRecord, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], IndirectCategoryCode, Hours, DepartmentTeamCode, Comments, ErrorMessage) Then

                    If CheckIfDateIsEditable(DbContext, EmployeeTimeRecord, EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID, [Date], 0, 0, ErrorMessage) Then

                        ErrorMessageObjectParameter = New System.Data.SqlClient.SqlParameter("@error_text", "")
                        ErrorMessageObjectParameter.SqlDbType = SqlDbType.VarChar
                        ErrorMessageObjectParameter.Size = 4000
                        ErrorMessageObjectParameter.Direction = ParameterDirection.Output

                        If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                            SaveTimeSheetDay(DbContext.ConnectionString, DbContext.UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], IndirectCategoryCode, Hours, 0, 0, DepartmentTeamCode, "", "", "", UserCode, Comments, "", 0, ErrorMessageObjectParameter)

                        Else

                            SaveTimeSheetDay(DbContext.ConnectionString, DbContext.UserCode, 0, 0, EmployeeCode, [Date], IndirectCategoryCode, Hours, 0, 0, DepartmentTeamCode, "", "", "", UserCode, Comments, "", 0, ErrorMessageObjectParameter)

                        End If

                        If ErrorMessageObjectParameter IsNot Nothing AndAlso ErrorMessageObjectParameter.Value IsNot System.DBNull.Value AndAlso String.IsNullOrWhiteSpace(ErrorMessageObjectParameter.Value) = False Then

                            If CheckForTimeSheetEntrySaved(ErrorMessageObjectParameter.Value, SaveEmployeeTimeReponse) = True Then
                                ErrorMessage = String.Empty
                            End If

                        End If

                    End If

                End If

            End Using

            SaveEmployeeNonProductionTime = SaveEmployeeTimeReponse

        End Function
        Public Function SaveEmployeeJobTime(ConnectionString As String, UserCode As String, EmployeeTimeID As Integer,
                                            EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, FunctionCode As String, Hours As Decimal, JobNumber As Integer, JobComponentNumber As Short,
                                            DepartmentTeamCode As String, Comments As String, TaskCode As String, ByRef ErrorMessage As String) As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse

            Dim EmployeeTimeRecords As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex) = Nothing
            Dim EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim ErrorMessageObjectParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse = Nothing

            SaveEmployeeTimeReponse = New AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse(0, 0, "", 0)

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                Try

                    EmployeeTimeRecords = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, EmployeeCode, [Date], [Date], "JOB_NUMBER", DbContext.UserCode).ToList

                Catch ex As Exception
                    EmployeeTimeRecords = Nothing
                End Try

                If CheckIfValidData(DbContext, EmployeeTimeRecords, EmployeeTimeRecord, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], FunctionCode, JobNumber,
                                    JobComponentNumber, Hours, DepartmentTeamCode, Comments, TaskCode, ErrorMessage) Then

                    If CheckIfDateIsEditable(DbContext, EmployeeTimeRecord, EmployeeCode, EmployeeTimeID, EmployeeTimeDetailID, [Date], JobNumber, JobComponentNumber, ErrorMessage) Then

                        ErrorMessageObjectParameter = New System.Data.SqlClient.SqlParameter("@error_text", "")
                        ErrorMessageObjectParameter.SqlDbType = SqlDbType.VarChar
                        ErrorMessageObjectParameter.Size = 4000
                        ErrorMessageObjectParameter.Direction = ParameterDirection.Output

                        If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                            AdvantageFramework.EmployeeTimesheet.SaveTimeSheetDay(ConnectionString, UserCode, EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date], FunctionCode, Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, "", "", "", UserCode, Comments, TaskCode, 0, ErrorMessageObjectParameter)

                        Else

                            AdvantageFramework.EmployeeTimesheet.SaveTimeSheetDay(ConnectionString, UserCode, 0, 0, EmployeeCode, [Date], FunctionCode, Hours, JobNumber, JobComponentNumber, DepartmentTeamCode, "", "", "", UserCode, Comments, TaskCode, 0, ErrorMessageObjectParameter)

                        End If

                        If ErrorMessageObjectParameter IsNot Nothing AndAlso ErrorMessageObjectParameter.Value IsNot System.DBNull.Value AndAlso String.IsNullOrWhiteSpace(ErrorMessageObjectParameter.Value) = False Then

                            If CheckForTimeSheetEntrySaved(ErrorMessageObjectParameter.Value, SaveEmployeeTimeReponse) = True Then
                                ErrorMessage = String.Empty
                            End If

                        End If

                    End If

                End If

            End Using

            SaveEmployeeJobTime = SaveEmployeeTimeReponse

        End Function
        Public Function SaveTimeSheetDay(ConnectionString As String, UserCode As String, et_id As Integer, etd_id As Integer, emp_code As String, emp_date As Date, fnc_cat As String, emp_hrs As Decimal, job_nbr As Integer,
                                         job_cmp_nbr As Short, dp_tm As String, start_time As String, end_time As String, prodCat As String,
                                         userID As String, comments As String, task_code As String, alert_id As Integer, error_text As System.Data.SqlClient.SqlParameter) As Integer


            Dim Saved As Boolean = False
            Dim NewEmployeeTimeID As Integer = 0
            Dim NewEmployeeTimeDetailID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Saved = SaveDay(ConnectionString, UserCode, et_id, etd_id, emp_code,
                            emp_date, fnc_cat, prodCat, emp_hrs, job_nbr, job_cmp_nbr, dp_tm, UserCode, ErrorMessage, comments,
                            NewEmployeeTimeID, NewEmployeeTimeDetailID, alert_id, False)

            error_text.Value = ErrorMessage

            Return Saved

        End Function
        Public Function CheckForTimeSheetEntrySaved(ByVal Message As String, ByVal SaveEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse) As Boolean

            'objects
            Dim TimeSheetEntrySaved As Boolean = False
            Dim MessageValues As String() = Nothing
            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim Hours As Decimal = 0
            Dim BillingRate As Decimal = 0
            Dim IsNonBillable As Boolean = False

            Try

                MessageValues = Message.Split("|")

                If MessageValues IsNot Nothing AndAlso MessageValues.Count > 0 Then

                    Message = MessageValues.GetValue(0)
                    EmployeeTimeID = CInt(MessageValues.GetValue(1))
                    EmployeeTimeDetailID = CInt(MessageValues.GetValue(2))

                    Try

                        Hours = CDec(MessageValues.GetValue(3))

                    Catch ex As Exception

                    End Try

                    Try

                        BillingRate = CDec(MessageValues.GetValue(4))

                    Catch ex As Exception

                    End Try

                    Try

                        IsNonBillable = CBool(MessageValues.GetValue(5))

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                EmployeeTimeID = 0
                EmployeeTimeDetailID = 0
            End Try

            If SaveEmployeeTimeReponse Is Nothing Then

                SaveEmployeeTimeReponse = New AdvantageFramework.EmployeeTimesheet.Classes.SaveEmployeeTimeReponse(0, 0, "", 0)

            End If

            SaveEmployeeTimeReponse.Message = Message
            SaveEmployeeTimeReponse.EmployeeTimeID = EmployeeTimeID
            SaveEmployeeTimeReponse.EmployeeTimeDetailID = EmployeeTimeDetailID
            SaveEmployeeTimeReponse.BillingRate = BillingRate
            SaveEmployeeTimeReponse.IsNonBillable = IsNonBillable

            If String.IsNullOrWhiteSpace(Message) = False AndAlso Message.Contains("_SUCCESS") Then

                TimeSheetEntrySaved = True
                SaveEmployeeTimeReponse.SaveSuccessful = 1

            Else

                TimeSheetEntrySaved = False
                SaveEmployeeTimeReponse.SaveSuccessful = 0

            End If

            CheckForTimeSheetEntrySaved = TimeSheetEntrySaved

        End Function

        Public Function CheckIfAssignmentIsRequired(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim AssignmentRequired As Boolean = False

            Try

                AssignmentRequired = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(ISNULL(TIME_REQ_ASSN, 0) AS BIT) FROM AGENCY WITH(NOLOCK);").FirstOrDefault()

            Catch ex As Exception
                AssignmentRequired = False
            Finally
                CheckIfAssignmentIsRequired = AssignmentRequired
            End Try

        End Function

        Public Function FirstDayOfWeek(ByVal TheDate As Date, UserTimesheetSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings, ByVal DaysToDisplay As Short) As Date
            Try

                Dim FirstDayOfWeekDate As Date
                Dim StartWeekOn As DayOfWeek
                Dim MoveForward As Boolean = False

                If TheDate = Nothing Then TheDate = Now.Date

                Select Case DaysToDisplay
                    Case 1
                        StartWeekOn = TheDate.DayOfWeek
                    Case 5

                        StartWeekOn = DayOfWeek.Monday

                        If (UserTimesheetSettings.StartTimesheetOnDayOfWeek = DayOfWeek.Sunday AndAlso TheDate.DayOfWeek = DayOfWeek.Sunday) OrElse
                            (UserTimesheetSettings.StartTimesheetOnDayOfWeek = DayOfWeek.Saturday AndAlso TheDate.DayOfWeek = DayOfWeek.Saturday) Then

                            MoveForward = True

                        End If

                    Case 7
                        StartWeekOn = UserTimesheetSettings.StartTimesheetOnDayOfWeek
                    Case Else
                        StartWeekOn = UserTimesheetSettings.StartTimesheetOnDayOfWeek
                End Select

                FirstDayOfWeekDate = TheDate


                For i As Integer = 0 To 6 Step 1

                    If FirstDayOfWeekDate.DayOfWeek = StartWeekOn Then

                        Exit For

                    End If
                    If MoveForward = False Then

                        FirstDayOfWeekDate = TheDate.AddDays(-i)

                    Else

                        FirstDayOfWeekDate = TheDate.AddDays(i)

                    End If

                Next

                Return FirstDayOfWeekDate

            Catch ex As Exception
                Return TheDate
            End Try
        End Function
        Public Function FirstDayOfWeekUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TheDate As Date) As Date

            Return FirstDayOfWeek(TheDate, GetUserStartWeekOn(DbContext))

        End Function
        Public Function FirstDayOfWeek(ByVal TheDate As Date, ByVal StartWeekOn As DayOfWeek) As Date
            Try

                Dim FirstDayOfWeekDate As Date

                If TheDate = Nothing Then TheDate = Now.Date

                For i As Integer = 0 To 6 Step 1

                    FirstDayOfWeekDate = TheDate.AddDays(-i)

                    If FirstDayOfWeekDate.DayOfWeek = StartWeekOn Then

                        Exit For

                    End If

                Next

                Return FirstDayOfWeekDate

            Catch ex As Exception
                Return TheDate
            End Try
        End Function

        Private Function AgencyStartWeekOn(ByVal DbContext As AdvantageFramework.Database.DbContext) As DayOfWeek

            Dim Start As DayOfWeek = DayOfWeek.Sunday
            Dim Sql As String = "SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS INT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS.AGY_SETTINGS_CODE = 'TS_START_WEEK_ON';"
            Dim i As Integer? = 0

            Try

                i = DbContext.Database.SqlQuery(Of Integer)(Sql).SingleOrDefault

            Catch ex As Exception
                i = 0
            End Try

            Start = CType(i, DayOfWeek)

            Return Start

        End Function
        Private Function AgencyOverrideEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim Sql As String = "SELECT CAST(COALESCE(AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, 0) AS BIT) FROM AGY_SETTINGS WITH(NOLOCK) WHERE AGY_SETTINGS_CODE = 'TS_AGY_OVRRDE';"
            Dim Override As Boolean = False

            Try

                Override = DbContext.Database.SqlQuery(Of Boolean)(Sql).SingleOrDefault

            Catch ex As Exception
                Override = False
            End Try

            Return Override

        End Function
        Public Function GetUserStartWeekOn(ByVal DbContext As AdvantageFramework.Database.DbContext) As DayOfWeek

            Dim Start As DayOfWeek = DayOfWeek.Sunday

            Try

                Dim i As Integer = -1

                Try

                    i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(ISNULL(VARIABLE_VALUE, -1) AS INT) FROM APP_VARS WHERE [APPLICATION] = 'NewTimesheet' AND VARIABLE_NAME = 'StartTimesheetOnDayOfWeek' AND USERID = '{0}';", DbContext.UserCode)).SingleOrDefault

                Catch ex As Exception
                    i = -1
                End Try

                If AgencyOverrideEmployee(DbContext) = True Then

                    Start = AgencyStartWeekOn(DbContext)

                Else

                    If i = -1 Then

                        Start = AgencyStartWeekOn(DbContext)

                    Else

                        Start = CType(i, DayOfWeek)

                    End If

                End If


            Catch ex As Exception
                Start = DayOfWeek.Sunday
            End Try

            Return Start

        End Function
        Public Function GetEmployeeStartWeekOn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As DayOfWeek

            Dim Start As DayOfWeek = DayOfWeek.Sunday

            Try

                Dim i As Integer = -1

                Try

                    i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM APP_VARS WHERE [APPLICATION] = 'NewTimesheet' AND VARIABLE_NAME = 'StartTimesheetOnDayOfWeek' " &
                                                                              " AND USERID = (SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}' ORDER BY USER_CODE DESC);", EmployeeCode)).SingleOrDefault

                    If i = 0 Then

                        i = -1

                    Else

                        i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(ISNULL(VARIABLE_VALUE, -1) AS INT) FROM APP_VARS WHERE [APPLICATION] = 'NewTimesheet' AND VARIABLE_NAME = 'StartTimesheetOnDayOfWeek' " &
                                                                                  " AND USERID = (SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}' ORDER BY USER_CODE DESC);", EmployeeCode)).SingleOrDefault

                    End If

                Catch ex As Exception
                    i = -1
                End Try

                If AgencyOverrideEmployee(DbContext) = True OrElse i = -1 Then

                    Start = AgencyStartWeekOn(DbContext)

                Else

                    If i = -1 Then

                        Start = AgencyStartWeekOn(DbContext)

                    Else

                        Start = CType(i, DayOfWeek)

                    End If

                End If

            Catch ex As Exception
                Start = DayOfWeek.Sunday
            End Try

            Return Start

        End Function

        Public Function JobCompIsEditable(ByVal ConnectionString As String, ByVal strJobNum As String, ByVal strJobCompNum As String, Optional ByVal OnlyClosedProcessControls As Boolean = False) As Boolean
            If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Or strJobCompNum = "" Or strJobCompNum = String.Empty Or IsNumeric(strJobCompNum) = False Then

                Return False

            Else

                Dim IsValid As Boolean = False

                Dim ireturn As Integer = 0

                Try

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        With MyCommand
                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_validate_JobCompIsEditable"
                            .Connection = MyConn
                        End With

                        Dim parameterJobNum As New System.Data.SqlClient.SqlParameter("@JobNum", SqlDbType.Int)
                        parameterJobNum.Value = strJobNum
                        MyCommand.Parameters.Add(parameterJobNum)

                        Dim parameterJobCompNum As New System.Data.SqlClient.SqlParameter("@JobCompNum", SqlDbType.Int)
                        parameterJobCompNum.Value = strJobCompNum
                        MyCommand.Parameters.Add(parameterJobCompNum)

                        Dim parameterOnlyClosedProcessControls As New System.Data.SqlClient.SqlParameter("@OnlyClosedProcessControls", SqlDbType.SmallInt)
                        If OnlyClosedProcessControls = True Then
                            parameterOnlyClosedProcessControls.Value = 1
                        Else
                            parameterOnlyClosedProcessControls.Value = 0
                        End If
                        MyCommand.Parameters.Add(parameterOnlyClosedProcessControls)

                        MyConn.Open()

                        ireturn = CInt(MyCommand.ExecuteScalar())

                    End Using

                Catch

                    ireturn = 0

                End Try

                If ireturn > 0 Then

                    IsValid = True

                Else

                    IsValid = False

                End If

                Return IsValid

            End If

        End Function
        Public Function FunctionIsValid(ByVal ConnectionString As String, ByVal Empcode As String, ByVal FuncCode As String) As Boolean

            Dim IsValid As Boolean = False

            If Empcode = "" Then

                Return False

            End If
            Try

                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_validate_functioncat_ts_addnew"
                        .Connection = MyConn

                    End With

                    Dim Tparameter1 As New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                    Tparameter1.Value = Empcode

                    Dim Tparameter2 As New System.Data.SqlClient.SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
                    Tparameter2.Value = FuncCode


                    MyCommand.Parameters.Add(Tparameter1)
                    MyCommand.Parameters.Add(Tparameter2)

                    MyConn.Open()

                    IsValid = CInt(MyCommand.ExecuteScalar())

                End Using

            Catch
                IsValid = False
            End Try

            Return IsValid

        End Function

#Region " Private "

        Private Function SubmitUnSubmitWeekForApproval(ByVal Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal Approve As Boolean, ByVal EmployeeCode As String, ByVal EmployeeDate As Date, ByRef ErrorMessage As String) As Boolean

            Dim Submitted As Boolean = False
            Dim StartWeekOn As DayOfWeek = GetEmployeeStartWeekOn(DbContext, EmployeeCode)
            Dim FirstOfWeek As Date = FirstDayOfWeek(CType(EmployeeDate.ToShortDateString, Date), StartWeekOn)
            Dim DayErrorMessage As String = String.Empty
            Dim DaySubmitted As Boolean = False
            Dim ErrorCounter As Integer = 0
            Dim SuccessCounter As Integer = 0

            If Approve = True Then

                If AdvantageFramework.Timesheet.HasStopWatch(Session.ConnectionString, EmployeeCode, FirstOfWeek, DateAdd(DateInterval.Day, 6, FirstOfWeek)) = True Then

                    ErrorMessage = "You have a stopwatch running.  Please stop it before proceeding."
                    Submitted = False
                    Return Submitted

                End If

            End If
            For i As Integer = 0 To 6

                Try

                    DaySubmitted = False
                    DayErrorMessage = String.Empty

                    DaySubmitted = SubmitForApproval(Session, EmployeeCode, DateAdd(DateInterval.Day, i, FirstOfWeek), Approve, False, DayErrorMessage)

                    If DaySubmitted = True Then

                        SuccessCounter += 1

                    Else

                        ErrorCounter += 1

                        If String.IsNullOrWhiteSpace(DayErrorMessage) = False Then

                            ErrorMessage += " " & DayErrorMessage

                        End If

                    End If

                Catch ex As Exception
                    DaySubmitted = False
                    DayErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

            Next

            Submitted = SuccessCounter > 0

            If Approve = True AndAlso Submitted = True Then

                Dim AsyncEmail As New ApprovalEmailAsync(Session, EmployeeCode)

                AsyncEmail.IsSubmittingEntireWeek = True
                AsyncEmail.StartOfWeekDate = FirstOfWeek
                AsyncEmail.Send()

            End If

            Return Submitted

        End Function
        Private Function CheckCanEditEmployeeTime(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String, EmployeeTimeID As Integer, EmployeeTimeDetailID As Integer) As AdvantageFramework.EmployeeTimesheet.Classes.CanEditEmployeeTimeReponse

            'objects
            Dim CanEditEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.CanEditEmployeeTimeReponse = Nothing

            Try

                CanEditEmployeeTimeReponse = DbContext.Database.SqlQuery(Of AdvantageFramework.EmployeeTimesheet.Classes.CanEditEmployeeTimeReponse)("SELECT * FROM [dbo].[wvfn_ts_can_edit] ('" & EmployeeCode & "', " & EmployeeTimeID & ", " & EmployeeTimeDetailID & ", NULL)").FirstOrDefault

            Catch ex As Exception
                CanEditEmployeeTimeReponse = Nothing
            End Try

            CheckCanEditEmployeeTime = CanEditEmployeeTimeReponse

        End Function
        Private Function CheckAgencyRequiredComments(DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                CheckAgencyRequiredComments = DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(TIME_COMMENTS_REQ, 0) FROM dbo.AGENCY").FirstOrDefault = 1

            Catch ex As Exception
                CheckAgencyRequiredComments = False
            End Try

        End Function
        Private Function CheckClientRequiredComments(DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String) As Boolean

            Try

                CheckClientRequiredComments = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT ISNULL(REQ_TIME_COMMENT, 0) FROM dbo.CLIENT WHERE CL_CODE = '{0}'", ClientCode)).FirstOrDefault = 1

            Catch ex As Exception
                CheckClientRequiredComments = False
            End Try

        End Function
        Private Function CheckIfValidData(DbContext As AdvantageFramework.Database.DbContext, EmployeeTimeRecords As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex),
                                          ByRef EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex,
                                          EmployeeTimeID As Integer, EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, IndirectCategoryCode As String, Hours As Decimal, ByRef DepartmentTeamCode As String,
                                          Comments As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValidData As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim IndirectCategory As AdvantageFramework.Database.Entities.IndirectCategory = Nothing
            Dim EmployeeDepartmentTeam As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim LookupDepartmentTeamCode As String = Nothing

            If Hours > 99 Then

                ErrorMessage &= LTrim(RTrim("  " & "Hours exceed the max entry of 99 hours."))
                IsValidData = False

            End If

            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

            If Employee Is Nothing Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find employee."))
                IsValidData = False

            End If

            IndirectCategory = AdvantageFramework.Database.Procedures.IndirectCategory.LoadByIndirectCategoryCode(DbContext, IndirectCategoryCode)

            If IndirectCategory Is Nothing Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find indirect category."))
                IsValidData = False

            End If

            If String.IsNullOrEmpty(DepartmentTeamCode) = False Then

                LookupDepartmentTeamCode = DepartmentTeamCode

                DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, LookupDepartmentTeamCode)

                If DepartmentTeam Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team."))
                    IsValidData = False

                Else

                    EmployeeDepartmentTeam = AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCodeAndDepartmentTeamCode(DbContext, EmployeeCode, LookupDepartmentTeamCode)

                    If EmployeeDepartmentTeam Is Nothing Then

                        ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team for that employee."))
                        IsValidData = False

                    End If

                End If

            Else

                If Employee IsNot Nothing Then

                    DepartmentTeamCode = Employee.DepartmentTeamCode

                End If

            End If

            If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.SingleOrDefault(Function(Entity) Entity.EmployeeTimeID = EmployeeTimeID AndAlso Entity.EmployeeTimeDetailID = EmployeeTimeDetailID)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID = 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.FirstOrDefault(Function(Entity) Entity.EmployeeTimeID = EmployeeTimeID AndAlso Entity.EmployeeDate.GetValueOrDefault("01/01/1900").ToShortDateString = [Date].ToShortDateString)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID = 0 AndAlso EmployeeTimeDetailID = 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.FirstOrDefault(Function(Entity) Entity.EmployeeDate.GetValueOrDefault("01/01/1900").ToShortDateString = [Date].ToShortDateString)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord IsNot Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Employee time record has already been entered for this date."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID = 0 AndAlso EmployeeTimeDetailID <> 0 Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                IsValidData = False

            End If

            If IsValidData Then

                If EmployeeTimeRecord IsNot Nothing Then

                    If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                        If EmployeeTimeRecord.TimeType <> "N" Then

                            ErrorMessage &= LTrim(RTrim("  " & "Incorrect time type record."))
                            IsValidData = False

                        End If

                        If EmployeeTimeRecord.EmployeeDate <> [Date] Then

                            ErrorMessage &= LTrim(RTrim("  " & "Could not find date on employee time record."))
                            IsValidData = False

                        End If

                        If EmployeeTimeRecord.FunctionCategory <> IndirectCategoryCode Then

                            ErrorMessage &= LTrim(RTrim("  " & "Could not find indirect category on employee time record."))
                            IsValidData = False

                        End If

                        'If EmployeeTimeRecord.DepartmentTeamCode <> DepartmentTeamCode Then

                        '    ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team on employee time record."))
                        '    IsValidData = False

                        'End If

                        If EmployeeTimeRecord.CommentsRequired.GetValueOrDefault(0) = 1 AndAlso String.IsNullOrWhiteSpace(Comments) Then

                            ErrorMessage &= LTrim(RTrim("  " & "Comment is required when updating employee time record."))
                            IsValidData = False

                        End If

                    End If

                Else

                    If CheckAgencyRequiredComments(DbContext) AndAlso String.IsNullOrWhiteSpace(Comments) Then

                        ErrorMessage &= LTrim(RTrim("  " & "Comment is required when adding employee time record."))
                        IsValidData = False

                    End If

                End If

            End If

            CheckIfValidData = IsValidData

        End Function
        Private Function CheckAgencyTimesheetTaskOnly(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Try

                CheckAgencyTimesheetTaskOnly = DbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(AGY_SETTINGS_VALUE, 0) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TS_TASK_ONLY'").FirstOrDefault = 1

            Catch ex As Exception
                CheckAgencyTimesheetTaskOnly = False
            End Try

        End Function
        Private Function CheckIfValidData(DbContext As AdvantageFramework.Database.DbContext, EmployeeTimeRecords As Generic.List(Of AdvantageFramework.Database.Classes.EmployeeTimeComplex), ByRef EmployeeTimeRecord As AdvantageFramework.Database.Classes.EmployeeTimeComplex,
                                          EmployeeTimeID As Integer, EmployeeTimeDetailID As Integer, EmployeeCode As String, [Date] As Date, FunctionCode As String,
                                          JobNumber As Integer, JobComponentNumber As Short, Hours As Decimal, DepartmentTeamCode As String, Comments As String, TaskCode As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValidData As Boolean = True
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing
            Dim EmployeeDepartmentTeam As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.[Function] = Nothing
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

            If Hours > 99 Then

                ErrorMessage &= LTrim(RTrim("  " & "Hours exceed the max entry of 99 hours."))
                IsValidData = False

            End If

            Try

                Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = EmployeeCode)

            Catch ex As Exception
                Employee = Nothing
            End Try

            If Employee Is Nothing Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find employee."))
                IsValidData = False

            End If

            Try

                JobComponentView = DbContext.JobComponentViews.SingleOrDefault(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNumber)

            Catch ex As Exception
                JobComponentView = Nothing
            End Try

            If JobComponentView Is Nothing Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find job component."))
                IsValidData = False

            End If

            Try

                [Function] = DbContext.Functions.SingleOrDefault(Function(Entity) Entity.Code = FunctionCode)

            Catch ex As Exception
                [Function] = Nothing
            End Try

            If [Function] Is Nothing Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find function."))
                IsValidData = False

            End If

            If String.IsNullOrEmpty(DepartmentTeamCode) = False Then

                Try

                    DepartmentTeam = DbContext.DepartmentTeams.SingleOrDefault(Function(Entity) Entity.Code = DepartmentTeamCode)

                Catch ex As Exception
                    DepartmentTeam = Nothing
                End Try

                If DepartmentTeam Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team."))
                    IsValidData = False

                Else

                    Try

                        EmployeeDepartmentTeam = DbContext.EmployeeDepartments.SingleOrDefault(Function(Entity) Entity.EmployeeCode = EmployeeCode AndAlso Entity.DepartmentTeamCode = DepartmentTeamCode)

                    Catch ex As Exception
                        EmployeeDepartmentTeam = Nothing
                    End Try

                    If EmployeeDepartmentTeam Is Nothing Then

                        ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team for that employee."))
                        IsValidData = False

                    End If

                End If

            End If

            If String.IsNullOrEmpty(TaskCode) = False Then

                Try

                    Task = DbContext.Tasks.SingleOrDefault(Function(Entity) Entity.Code = TaskCode)

                Catch ex As Exception
                    Task = Nothing
                End Try

                If Task Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find Task."))
                    IsValidData = False

                ElseIf CheckAgencyTimesheetTaskOnly(DbContext) = False Then

                    ErrorMessage &= LTrim(RTrim("  " & "Task is not allowed."))
                    IsValidData = False

                End If

            End If

            If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.SingleOrDefault(Function(Entity) Entity.EmployeeTimeID = EmployeeTimeID AndAlso Entity.EmployeeTimeDetailID = EmployeeTimeDetailID)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID = 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.FirstOrDefault(Function(Entity) Entity.EmployeeTimeID = EmployeeTimeID AndAlso Entity.EmployeeDate.GetValueOrDefault("01/01/1900").ToShortDateString = [Date].ToShortDateString)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord Is Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID = 0 AndAlso EmployeeTimeDetailID = 0 Then

                Try

                    EmployeeTimeRecord = EmployeeTimeRecords.FirstOrDefault(Function(Entity) Entity.EmployeeDate.GetValueOrDefault("01/01/1900").ToShortDateString = [Date].ToShortDateString)

                Catch ex As Exception
                    EmployeeTimeRecord = Nothing
                End Try

                If EmployeeTimeRecord IsNot Nothing Then

                    ErrorMessage &= LTrim(RTrim("  " & "Employee time record has already been entered for this date."))
                    IsValidData = False

                End If

            ElseIf EmployeeTimeID = 0 AndAlso EmployeeTimeDetailID <> 0 Then

                ErrorMessage &= LTrim(RTrim("  " & "Could not find employee time record."))
                IsValidData = False

            End If

            If IsValidData Then

                If EmployeeTimeRecord IsNot Nothing Then

                    If EmployeeTimeID <> 0 AndAlso EmployeeTimeDetailID <> 0 Then

                        If EmployeeTimeRecord.TimeType <> "D" Then

                            ErrorMessage &= LTrim(RTrim("  " & "Incorrect time type record."))
                            IsValidData = False

                        End If

                        If EmployeeTimeRecord.EmployeeDate <> [Date] Then

                            ErrorMessage &= LTrim(RTrim("  " & "Could not find date on employee time record."))
                            IsValidData = False

                        End If

                        If EmployeeTimeRecord.FunctionCategory <> FunctionCode Then

                            ErrorMessage &= LTrim(RTrim("  " & "Could not find function on employee time record."))
                            IsValidData = False

                        End If

                        If EmployeeTimeRecord.JobNumber <> JobNumber OrElse EmployeeTimeRecord.JobComponentNumber <> JobComponentNumber Then

                            ErrorMessage &= LTrim(RTrim("  " & "Could not find job component on employee time record."))
                            IsValidData = False

                        End If

                        'If EmployeeTimeRecord.DepartmentTeamCode <> DepartmentTeamCode Then

                        '    ErrorMessage &= LTrim(RTrim("  " & "Could not find department/team on employee time record."))
                        '    IsValidData = False

                        'End If

                        If (EmployeeTimeRecord.CommentsRequired.GetValueOrDefault(0) = 1 OrElse EmployeeTimeRecord.ClientCommentRequired.GetValueOrDefault(False)) AndAlso String.IsNullOrWhiteSpace(Comments) Then

                            ErrorMessage &= LTrim(RTrim("  " & "Comment is required when updating employee time record."))
                            IsValidData = False

                        End If

                    End If

                Else

                    If (CheckAgencyRequiredComments(DbContext) OrElse CheckClientRequiredComments(DbContext, JobComponentView.ClientCode)) AndAlso String.IsNullOrWhiteSpace(Comments) Then

                        ErrorMessage &= LTrim(RTrim("  " & "Comment is required when adding employee time record."))
                        IsValidData = False

                    End If

                End If

            End If

            If IsValidData = True Then
                ErrorMessage = String.Empty
            End If

            CheckIfValidData = IsValidData

        End Function
        Private Function ConvertFromUniCode(ByVal str As String, ByVal c As Char) As String
            Dim rtstr As String = ""

            For i As Integer = 2 To str.Length - 1 Step 6

                Dim str1 As String = str.Substring(i, 4)
                c = Microsoft.VisualBasic.ChrW(Int16.Parse(str1, System.Globalization.NumberStyles.HexNumber))
                rtstr += c

            Next

            Return rtstr

        End Function

#End Region

#Region " Timesheet Approval "

        Public Function LoadDayApprovalComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal EmployeeCode As String, ByVal EmployeeDate As Date) As String

            Dim ApprovalComment As String = String.Empty

            Try

                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeDate As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar)
                SqlParameterEmployeeDate = New System.Data.SqlClient.SqlParameter("@EmpDate", SqlDbType.SmallDateTime)

                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterEmployeeDate.Value = EmployeeDate

                ApprovalComment = DbContext.Database.SqlQuery(Of String)(String.Format("[dbo].[usp_wv_comment_get_ts_approve] @EmpCode, @EmpDate;"),
                                                                                       SqlParameterEmployeeCode,
                                                                                       SqlParameterEmployeeDate).SingleOrDefault

            Catch ex As Exception
                ApprovalComment = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return ApprovalComment

        End Function

#End Region

#Region " Stopwatch "

        Public Function HasStopWatch(ByVal ConnectionString As String, ByVal EmpCode As String, ByVal StartDate As Date, ByVal EndDate As Date,
                                               Optional ByRef StopwatchEtId As Integer = 0, Optional ByRef StopwatchEtDtlId As Integer = 0,
                                               Optional ByRef StopwatchStart As Date = Nothing,
                                               Optional ByRef ExistingTimeComment As String = "",
                                               Optional ByRef TimeDescription As String = "",
                                               Optional ByRef CurrentServerTime As Date = Nothing) As Boolean
            Dim i As Integer = 0

            Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_ts_HasStopwatch"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                Dim pStartDate As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                pStartDate.Value = StartDate
                Dim pEndDate As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                pEndDate.Value = EndDate

                MyCommand.Parameters.Add(pEmpCode)
                MyCommand.Parameters.Add(pStartDate)
                MyCommand.Parameters.Add(pEndDate)

                MyConn.Open()

                Dim Reader As System.Data.SqlClient.SqlDataReader
                Reader = MyCommand.ExecuteReader()

                If Reader.HasRows = True Then
                    Do While Reader.Read()
                        i = Reader.GetValue(Reader.GetOrdinal("HAS_STOPWATCH"))
                        StopwatchEtId = Reader.GetValue(Reader.GetOrdinal("STOPWATCH_ET_ID"))
                        StopwatchEtDtlId = Reader.GetValue(Reader.GetOrdinal("STOPWATCH_ET_DTL_ID"))
                        If Reader.IsDBNull(Reader.GetOrdinal("STOPWATCH_START_TIME")) = False Then
                            StopwatchStart = Reader.GetDateTime(Reader.GetOrdinal("STOPWATCH_START_TIME"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("COMMENT")) = False Then
                            ExistingTimeComment = Reader(Reader.GetOrdinal("COMMENT"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then
                            TimeDescription = Reader(Reader.GetOrdinal("DESCRIPTION"))
                        End If
                        If Reader.IsDBNull(Reader.GetOrdinal("CURR_SERVER_TIME")) = False Then
                            CurrentServerTime = Reader(Reader.GetOrdinal("CURR_SERVER_TIME"))
                        End If
                    Loop
                End If

            End Using

            If i > 0 Then
                Return True
            Else
                Return False
            End If

        End Function
        Public Function HasStopWatch(ByVal ConnectionString As String,
                                     ByVal UserCode As String,
                                     ByVal EmpCode As String,
                                     Optional ByRef StopwatchEtId As Integer = 0,
                                     Optional ByRef StopwatchEtDtlId As Integer = 0,
                                     Optional ByRef StopwatchStart As Date = Nothing,
                                     Optional ByRef ExistingComment As String = "",
                                     Optional ByRef FuncCatDescription As String = "",
                                     Optional ByRef TimeType As String = "",
                                     Optional ByRef CurrentServerTime As Date = Nothing) As Boolean

            Dim i As Integer = 0
            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)


                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "usp_wv_ts_HasStopwatch"
                        .Connection = MyConn
                    End With

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode
                    Dim pStartDate As New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                    pStartDate.Value = System.DBNull.Value
                    Dim pEndDate As New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                    pEndDate.Value = System.DBNull.Value

                    MyCommand.Parameters.Add(pEmpCode)
                    MyCommand.Parameters.Add(pStartDate)
                    MyCommand.Parameters.Add(pEndDate)

                    MyConn.Open()

                    Dim Reader As System.Data.SqlClient.SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Do While Reader.Read()

                            i = Reader(Reader.GetOrdinal("HAS_STOPWATCH"))
                            StopwatchEtId = CType(Reader(Reader.GetOrdinal("STOPWATCH_ET_ID")), Integer)
                            StopwatchEtDtlId = CType(Reader(Reader.GetOrdinal("STOPWATCH_ET_DTL_ID")), Integer)

                            If Reader.IsDBNull(Reader.GetOrdinal("STOPWATCH_START_TIME")) = False Then
                                StopwatchStart = CType(Reader(Reader.GetOrdinal("STOPWATCH_START_TIME")), Date)
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("COMMENT")) = False Then
                                ExistingComment = Reader(Reader.GetOrdinal("COMMENT"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("DESCRIPTION")) = False Then
                                FuncCatDescription = Reader(Reader.GetOrdinal("DESCRIPTION"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("TIME_TYPE")) = False Then
                                TimeType = Reader(Reader.GetOrdinal("TIME_TYPE"))
                            End If

                            If Reader.IsDBNull(Reader.GetOrdinal("CURR_SERVER_TIME")) = False Then

                                CurrentServerTime = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                            End If

                        Loop

                    End If

                End Using

            End Using

            If i > 0 Then

                Return True

            Else

                Return False

            End If

        End Function
        Public Function StopwatchStart(ByVal ConnectionString As String,
                                       ByVal UserCode As String,
                                       ByVal EmpCode As String,
                                       ByVal JobNumber As Integer,
                                       ByVal JobComponentNbr As Integer,
                                       ByVal TaskSeqNbr As Integer,
                                       ByVal AlertID As Integer,
                                       ByRef ErrorMessage As String) As Boolean
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Dim EtId As Integer = 0
                    Dim EtDtlId As Integer = 0
                    Dim DefaultFunction As String = ""
                    Dim DefaultDepartment As String = ""
                    Dim ProdCat As String = "stopwatch" 'HACK!
                    Dim TodaysDate As Date = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        Dim pJobNumber As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        Dim pJobComponentNbr As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        Dim pSeqNbr As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        Dim Reader As System.Data.SqlClient.SqlDataReader

                        With MyCommand

                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_DefaultFunctionAndDept"
                            .Connection = MyConn

                        End With

                        pEmpCode.Value = EmpCode
                        pJobNumber.Value = JobNumber
                        pJobComponentNbr.Value = JobComponentNbr
                        pSeqNbr.Value = TaskSeqNbr

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pJobNumber)
                        MyCommand.Parameters.Add(pJobComponentNbr)
                        MyCommand.Parameters.Add(pSeqNbr)

                        MyConn.Open()

                        Reader = MyCommand.ExecuteReader()

                        If Reader.HasRows = True Then

                            Do While Reader.Read()

                                If IsDBNull(Reader(Reader.GetOrdinal("FNC_CODE"))) = False Then

                                    DefaultFunction = Reader.GetString(Reader.GetOrdinal("FNC_CODE"))

                                End If
                                If IsDBNull(Reader(Reader.GetOrdinal("DP_TM_CODE"))) = False Then

                                    DefaultDepartment = Reader.GetString(Reader.GetOrdinal("DP_TM_CODE"))

                                End If

                            Loop

                        End If
                        If String.IsNullOrWhiteSpace(DefaultFunction) = True Then

                            ErrorMessage = "There is not a default function associated with this record. Please ensure that you have a default function established before continuing. Stop Watch will be cancelled."
                            Return False

                        End If
                        If String.IsNullOrWhiteSpace(DefaultDepartment) = True Then

                            ErrorMessage = "There is not a department associated with this employee. Please ensure that you have a department established before continuing. Stop Watch will be cancelled."
                            Return False

                        End If
                        If CheckIfPostPeriodIsAvailable(DbContext, TodaysDate) = False Then

                            ErrorMessage = "Post period for this day is closed."
                            Return False

                        End If
                        If JobNumber > 0 AndAlso JobComponentNbr > 0 AndAlso String.IsNullOrWhiteSpace(DefaultFunction) = False AndAlso String.IsNullOrWhiteSpace(DefaultDepartment) = False Then

                            If JobCompIsEditable(ConnectionString, JobNumber, JobComponentNbr) = False Then

                                ErrorMessage = "Job/Component Process Control does not allow access."
                                Return False

                            End If
                            If FunctionIsValid(ConnectionString, EmpCode, DefaultFunction) = False Then

                                ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(DefaultFunction) & " is an invalid Function."
                                Return False

                            End If

                            Dim CurrentHours As Decimal = 0
                            Dim CurrentComments As String = String.Empty
                            Dim HasEntry As Boolean = False

                            If TimeEntryExists(DbContext, EmpCode, TodaysDate, 0,
                                               JobNumber, JobComponentNbr, DefaultFunction, AlertID, EtId, EtDtlId, CurrentHours, CurrentComments, ErrorMessage) Then

                                If EtId > 0 And EtDtlId > 0 And String.IsNullOrWhiteSpace(CurrentComments) Then

                                    'check can edit
                                    Dim CanEditEmployeeTimeReponse As AdvantageFramework.EmployeeTimesheet.Classes.CanEditEmployeeTimeReponse = Nothing
                                    CanEditEmployeeTimeReponse = CheckCanEditEmployeeTime(DbContext, EmpCode, EtId, EtDtlId)

                                    If CanEditEmployeeTimeReponse IsNot Nothing AndAlso CanEditEmployeeTimeReponse.CAN_EDIT = 1 Then

                                        HasEntry = True

                                    End If

                                End If

                            End If
                            If HasEntry = False Then

                                If SaveDay(ConnectionString, UserCode, 0, 0, EmpCode, AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode),
                                       DefaultFunction, ProdCat, 0.0,
                                       JobNumber, JobComponentNbr, DefaultDepartment, UserCode, ErrorMessage, "", EtId, EtDtlId, AlertID, True) = True Then

                                    If EtId > 0 And EtDtlId > 0 Then

                                        HasEntry = True

                                    End If

                                End If

                            End If
                            If HasEntry = True AndAlso EtId > 0 AndAlso EtDtlId > 0 Then

                                CheckForAndStopExistingStopwatch(ConnectionString, UserCode, EmpCode)

                                If StopwatchStart(ConnectionString, UserCode, EmpCode, EtId, EtDtlId, ErrorMessage) = True Then

                                    Return True

                                Else

                                    Return False

                                End If

                            End If

                        End If

                    End Using

                    ErrorMessage = String.Empty
                    Return True

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try

        End Function
        Public Function StopwatchStart(ByVal ConnectionString As String,
                                       ByVal UserCode As String,
                                       ByVal EmpCode As String,
                                       ByVal EtId As Integer,
                                       ByVal EtDtlId As Integer,
                                       Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                Dim StopwatchStarted As Boolean = False
                ErrorMessage = ""

                CheckForAndStopExistingStopwatch(ConnectionString, UserCode, EmpCode)

                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                    MyConn.Open()

                    Using MyCommand = New System.Data.SqlClient.SqlCommand()

                        With MyCommand

                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_StopwatchStart"
                            .Connection = MyConn

                        End With

                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        pEmpCode.Value = EmpCode

                        Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                        pEtId.Value = EtId

                        Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                        pEtDtlId.Value = EtDtlId

                        Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                        pUserCode.Value = UserCode

                        Dim pCreateDate As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                            pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                        End Using

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pEtId)
                        MyCommand.Parameters.Add(pEtDtlId)
                        MyCommand.Parameters.Add(pUserCode)
                        MyCommand.Parameters.Add(pCreateDate)

                        'ErrorMessage = MyCommand.ExecuteScalar()

                        Using MyAdapter = New System.Data.SqlClient.SqlDataAdapter(MyCommand)

                            Dim MyDataSet As New DataSet
                            MyAdapter.Fill(MyDataSet)

                            If MyDataSet IsNot Nothing AndAlso MyDataSet.Tables.Count > 0 Then

                                Try

                                    ErrorMessage = MyDataSet.Tables(MyDataSet.Tables.Count - 1).Rows(0)(0) 'Get last table

                                Catch ex As Exception
                                    ErrorMessage = ""
                                End Try

                            End If

                        End Using

                        If ErrorMessage <> "" AndAlso ErrorMessage.Contains("|") = True Then

                            If ErrorMessage.Contains("SUCCESS") Then

                                StopwatchStarted = True

                            Else

                                Dim ar() As String
                                ar = ErrorMessage.Split("|")

                                ErrorMessage = ar(1)

                                If IsNumeric(ar(2)) = True AndAlso CType(ar(2), Integer) = 1 Then

                                    StopwatchStarted = True

                                End If

                            End If

                        End If

                    End Using

                    If MyConn.State = ConnectionState.Open Then

                        MyConn.Close()
                        MyConn.Dispose()

                    End If

                End Using

                'DeleteZeroHours(EmpCode, Now.Date)
                Return StopwatchStarted

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function
        Private Sub CheckForAndStopExistingStopwatch(ByVal ConnectionString As String,
                                                     ByVal UserCode As String,
                                                     ByVal EmployeeCode As String)

            Try

                Dim e As Integer = 0
                Dim ed As Integer = 0
                Dim h As Decimal = 0
                Dim ss As Date
                Dim c As String = String.Empty
                Dim d As String = String.Empty
                Dim fc As String = String.Empty
                Dim tt As String = String.Empty
                Dim err As String = String.Empty
                Dim dd As DateTime

                If HasStopWatch(ConnectionString, UserCode, EmployeeCode, e, ed, ss, c, fc, tt, dd) = True Then

                    StopwatchStop(ConnectionString, UserCode, EmployeeCode, e, ed, h, c, err)

                End If

            Catch ex As Exception
            End Try

        End Sub
        Public Function StopwatchStop(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmpCode As String, ByVal EtId As Integer, ByVal EtDtlId As Integer,
                                                ByRef HoursSaved As Double, ByVal Comment As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try

                HoursSaved = 0.0
                Dim CanEdit As Integer = 1
                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)

                        Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                        With MyCommand

                            .CommandType = CommandType.StoredProcedure
                            .CommandText = "usp_wv_ts_StopwatchStop"
                            .Connection = MyConn

                        End With

                        Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                        pEmpCode.Value = EmpCode
                        Dim pEtId As New System.Data.SqlClient.SqlParameter("@ET_ID", SqlDbType.Int)
                        pEtId.Value = EtId
                        Dim pEtDtlId As New System.Data.SqlClient.SqlParameter("@ET_DTL_ID", SqlDbType.SmallInt)
                        pEtDtlId.Value = EtDtlId
                        Dim pComment As New System.Data.SqlClient.SqlParameter("@COMMENT", SqlDbType.Text)
                        If Comment.Trim() = "" Then
                            pComment.Value = System.DBNull.Value
                        Else
                            pComment.Value = Comment
                        End If
                        Dim pUserCode As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                        pUserCode.Value = UserCode

                        Dim pCreateDate As New System.Data.SqlClient.SqlParameter("@CREATE_DATE", SqlDbType.SmallDateTime)
                        pCreateDate.Value = AdvantageFramework.Database.Procedures.Generic.TimeZoneTodayForEmployee(DbContext, EmpCode)

                        MyCommand.Parameters.Add(pEmpCode)
                        MyCommand.Parameters.Add(pEtId)
                        MyCommand.Parameters.Add(pEtDtlId)
                        MyCommand.Parameters.Add(pComment)
                        MyCommand.Parameters.Add(pUserCode)
                        MyCommand.Parameters.Add(pCreateDate)

                        Dim MyAdapter As New System.Data.SqlClient.SqlDataAdapter(MyCommand)

                        Dim ds As New DataSet
                        MyConn.Open()
                        MyAdapter.Fill(ds)

                        Dim dt As DataTable

                        If ds.Tables.Count > 0 Then

                            dt = ds.Tables(ds.Tables.Count - 1)

                            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                                HoursSaved = CType(dt.Rows(0)("EMP_HOURS"), Double)
                                CanEdit = CType(dt.Rows(0)("CAN_EDIT"), Integer)
                                ErrorMessage = dt.Rows(0)("RETURN_MESSAGE").ToString()

                            End If

                        End If

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()
                            MyConn.Dispose()

                        End If

                    End Using

                End Using

                If CanEdit = 0 Then

                    Return False

                Else

                    'DeleteZeroHours(EmpCode, Now.Date)
                    Return True

                End If
            Catch ex As Exception

                ErrorMessage = ex.Message.ToString()
                Return False

            End Try
        End Function
        Public Function StopwatchClear(ByVal ConnectionString As String, ByVal EmpCode As String, Optional ByRef ErrorMessage As String = "") As Boolean
            Try
                Using MyConn As New System.Data.SqlClient.SqlConnection(ConnectionString)
                    Dim MyCommand As New System.Data.SqlClient.SqlCommand()
                    With MyCommand
                        .CommandType = CommandType.Text
                        .CommandText = "UPDATE EMP_TIME WITH(ROWLOCK) SET STOP_WATCH_START_TIME = NULL, STOP_WATCH_ET_DTL_ID = NULL WHERE EMP_CODE = @EMP_CODE;"
                        .Connection = MyConn
                    End With

                    Dim pEmpCode As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    pEmpCode.Value = EmpCode

                    MyCommand.Parameters.Add(pEmpCode)

                    MyConn.Open()

                    MyCommand.ExecuteNonQuery()

                    If MyConn.State = ConnectionState.Open Then
                        MyConn.Close()
                        MyConn.Dispose()
                    End If

                End Using

                'DeleteZeroHours(EmpCode, Now.Date)

                ErrorMessage = ""
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try
        End Function

#End Region

#Region " Recents "



#End Region

#Region " Employee Time Template "

        Public Function LoadEmployeeTimeTemplates(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal UserCode As String, ByVal EmployeeCode As String) As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)

            Dim EmployeeTimeTemplates As Generic.List(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate) = Nothing

            Try

                EmployeeTimeTemplates = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Employee.Timesheet.EmployeeTimeTemplate)(String.Format("EXEC [dbo].[usp_wv_EMP_TIME_TMPLT_GET] '{0}', '{1}';", EmployeeCode, UserCode)).ToList

            Catch ex As Exception
                EmployeeTimeTemplates = Nothing
            End Try

            If EmployeeTimeTemplates Is Nothing Then EmployeeTimeTemplates = New Generic.List(Of ViewModels.Employee.Timesheet.EmployeeTimeTemplate)

            Return EmployeeTimeTemplates

        End Function

#End Region

#End Region

#Region " Classes "

        <Serializable()>
        Public Class ExistingEntryObject
            Public Property ET_ID As Integer? = 0
            Public Property ETD_ID As Integer? = 0
            Public Property EMP_HOURS As Decimal? = 0
            Public Property COMMENT As String = String.Empty
            Sub New()

            End Sub
        End Class

#End Region

    End Module

End Namespace
