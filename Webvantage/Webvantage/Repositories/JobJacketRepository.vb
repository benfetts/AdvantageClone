Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Webvantage.ViewModels
Imports Webvantage.Interfaces
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Namespace Repositories
    Public Class JobJacketRepository
        Inherits Repositories.RepositoryBase
        Implements IJobJacketRepository

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

        Public Sub New(DataContext As AdvantageFramework.Database.DataContext, session As AdvantageFramework.Security.Session)
            Me.DataContext = DataContext
            Me.Session = session
        End Sub

        Public Function CommentsDisplayMode() As String Implements IJobJacketRepository.CommentsDisplayMode
            Dim LegacyDisplaySettingsObject As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            Dim LegacyTimesheetObject As New cTimeSheet(Me.Session.ConnectionString)

            LegacyDisplaySettingsObject = LegacyTimesheetObject.GetSessionTimesheetSettings(Me.Session.UserCode)

            Return LegacyDisplaySettingsObject.ShowCommentsUsing
        End Function

        Public Function ValidateCDPEntry(ValidationRequest As TimesheetValidationRequest) As TimesheetValidationResult Implements IJobJacketRepository.ValidateCDPEntry

            Dim LegacyJobFunctionsObject As cJobFunctions = Nothing
            Dim LegacyTimesheetObject As cTimeSheet = Nothing
            Dim ValidationResult As TimesheetValidationResult = Nothing
            Dim LegacyTrafficObject As cTraffic = Nothing
            Dim LegacyValidationObject As cValidations = Nothing
            Dim LegacyRequiredFieldValidator As cRequired = Nothing
            Dim AgencySettings As AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions = Nothing

            Dim ThisClient As String
            Dim ThisDiv As String
            Dim ThisProd As String
            Dim ThisJob As String
            Dim ThisJobComp As String
            Dim ThisFuncCat As String
            Dim ThisDept As String
            Dim ThisProdCat As String
            Dim ThisHours As String
            Dim CurrentError As String
            Dim StartDate As Date
            Dim JobId As Integer
            Dim JobComponentId As Integer

            Dim culureInfo As System.Globalization.CultureInfo
            Dim lg As New LoGlo()
            culureInfo = lg.GetCultureInfo

            LegacyTrafficObject = New cTraffic(Me.Session.ConnectionString, Me.Session.UserCode)
            LegacyValidationObject = New cValidations(Me.Session.ConnectionString)
            LegacyRequiredFieldValidator = New cRequired(Me.Session.ConnectionString)
            LegacyJobFunctionsObject = New cJobFunctions(Me.Session.ConnectionString)
            LegacyTimesheetObject = New cTimeSheet(Me.Session.ConnectionString)

            AgencySettings = New AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions(Me.Session.ConnectionString)

            ValidationResult = New TimesheetValidationResult()
            ValidationResult.ValidationPassed = True
            ValidationResult.ErrorMessage = String.Empty

            If String.IsNullOrWhiteSpace(ValidationRequest.Job) Then
                ThisJob = 0
            Else
                If IsNumeric(ValidationRequest.Job) Then
                    ThisJob = CInt(ValidationRequest.Job)
                End If
            End If

            If String.IsNullOrWhiteSpace(ValidationRequest.JobComponent) Then
                ThisJobComp = 0
            Else
                If IsNumeric(ValidationRequest.JobComponent) Then
                    ThisJobComp = CInt(ValidationRequest.JobComponent)
                End If
            End If

            If ThisJob > 0 AndAlso ThisJobComp > 0 Then
                If ValidationResult.ValidationPassed AndAlso LegacyJobFunctionsObject.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid Job and Job Component."
                End If

                If ValidationResult.ValidationPassed AndAlso LegacyValidationObject.ValidateJobIsOpen(ThisJob, ThisJobComp) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "This job/comp is closed."
                End If
                If ValidationResult.ValidationPassed AndAlso LegacyValidationObject.ValidateJobCompIsEditable(ThisJob, ThisJobComp) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Job/comp process control does not allow access."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ThisJob > 0 And ThisJobComp = 0 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Job selected without a component."
            End If


            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Client <> "" Then
                If LegacyValidationObject.ValidateCDPIsViewable("CL", Me.Session.UserCode, ValidationRequest.Client.Trim, "", "", "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this client is denied."

                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Client <> "" And ValidationRequest.Division <> "" Then
                If LegacyValidationObject.ValidateCDPIsViewable("DI", Me.Session.UserCode, ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, "", "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this division is denied."

                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Client <> "" And ValidationRequest.Division <> "" And ValidationRequest.Product <> "" Then
                If LegacyValidationObject.ValidateCDPIsViewable("PR", Me.Session.UserCode, ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, ValidationRequest.Product.Trim, "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this product is denied."

                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Job <> "" Then
                If IsNumeric(ValidationRequest.Job.Trim) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Job number is not a number."

                End If
                If LegacyValidationObject.ValidateJobNumber(ValidationRequest.Job) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "This job does not exist."

                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.JobComponent <> "" Then
                If IsNumeric(ValidationRequest.JobComponent.Trim) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Job component number is not a number."

                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Job = "" And ValidationRequest.JobComponent <> "" Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "You cannot enter a component number without a job number."

            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Job <> "" And ValidationRequest.JobComponent <> "" Then
                If LegacyValidationObject.ValidateJobCompNumber(ValidationRequest.Job, ValidationRequest.JobComponent) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "This is not a valid job/component."

                End If
                If LegacyValidationObject.ValidateJobCompIsViewable(Me.Session.UserCode, ValidationRequest.Job.Trim, ValidationRequest.JobComponent.Trim, "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this job/comp is denied."

                End If
            End If

            If IsNumeric(ValidationRequest.Job) = True Then
                JobId = CType(ValidationRequest.Job, Integer)
            End If

            If IsNumeric(ValidationRequest.JobComponent) = True Then
                JobComponentId = CType(ValidationRequest.JobComponent, Integer)
            End If

            If JobId > 0 And JobComponentId > 0 And ThisFuncCat.Length > 6 Then
                ThisFuncCat = ThisFuncCat.Substring(0, 6)
            End If

            ValidateCDPEntry = ValidationResult
        End Function

        Private Function ValidateHours(HoursEntry As String) As Boolean
            If HoursEntry.Trim = "" Then
                Return True
            End If

            If IsNumeric(HoursEntry) = False Then
                Return False
            End If

            If CDbl(HoursEntry) >= -24 AndAlso CDbl(HoursEntry) <= 24 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function CommentsRequiredForApproval() As Boolean Implements IJobJacketRepository.CommentsRequiredForApproval
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.EmployeeTimesheet.CheckIfApprovalRequired(DbContext, Me.Session.UserCode)
            End Using
        End Function

        Public Function CommentsRequiredAgencyLevel() As Boolean Implements IJobJacketRepository.CommentsRequiredAgencyLevel
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.Database.Procedures.Agency.Load(DbContext).TimeCommentsRequired.GetValueOrDefault(0) = 1
            End Using
        End Function

        Public Function CommentsRequired() As Boolean Implements IJobJacketRepository.CommentsRequired
            Dim required As New cRequired(Session.ConnectionString)
            CommentsRequired = required.RequiredTimesheetComments
        End Function

        Public Function CommentsRequiredForJob(JobNumber As Integer) As Boolean Implements IJobJacketRepository.CommentsRequiredForJob
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.EmployeeTimesheet.CheckTimeCommentsRequired(DbContext, JobNumber, 0, 0)
            End Using
        End Function

        Public Function GetTimesheetTotals(ValidationRequest As TimesheetValidationRequest) As TimesheetTotalsResult Implements IJobJacketRepository.GetTimesheetTotals

            Dim CurrentTimesheet = AdvantageFramework.Timesheet.GetTimeSheet(Session.ConnectionString, Session.UserCode, ValidationRequest.EmployeeCode, ValidationRequest.SundayDate, CDate(ValidationRequest.SundayDate).AddDays(6))

            Dim TotalsResult = New TimesheetTotalsResult()

            TotalsResult.SundayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Sunday)
            TotalsResult.MondayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Monday)
            TotalsResult.TuesdayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Tuesday)
            TotalsResult.WednesdayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Wednesday)
            TotalsResult.ThursdayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Thursday)
            TotalsResult.FridayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Friday)
            TotalsResult.SaturdayHours = CurrentTimesheet.GetTotalHoursByDay(DayOfWeek.Saturday)
            TotalsResult.TotalHours = CurrentTimesheet.GetTotalHours()

            Return TotalsResult
        End Function

#End Region

    End Class
End Namespace
