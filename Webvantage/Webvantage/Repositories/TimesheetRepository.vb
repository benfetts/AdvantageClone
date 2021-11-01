Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Webvantage.ViewModels
Imports Webvantage.Interfaces
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Namespace Repositories
    Public Class TimesheetRepository
        Inherits Repositories.RepositoryBase
        Implements ITimesheetRepository

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

        Public Function CommentsDisplayMode() As String Implements ITimesheetRepository.CommentsDisplayMode
            Dim LegacyDisplaySettingsObject As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            Dim LegacyTimesheetObject As New cTimeSheet(Me.Session.ConnectionString)

            LegacyDisplaySettingsObject = LegacyTimesheetObject.GetSessionTimesheetSettings(Me.Session.UserCode)

            Return LegacyDisplaySettingsObject.ShowCommentsUsing
        End Function

        Public Function ValidateTimesheetEntry(ValidationRequest As TimesheetValidationRequest) As TimesheetValidationResult Implements ITimesheetRepository.ValidateTimesheetEntry

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
            Dim PostPeriodClosedSunday As Boolean
            Dim PostPeriodClosedMonday As Boolean
            Dim PostPeriodClosedTuesday As Boolean
            Dim PostPeriodClosedWednesday As Boolean
            Dim PostPeriodClosedThursday As Boolean
            Dim PostPeriodClosedFriday As Boolean
            Dim PostPeriodClosedSaturday As Boolean
            Dim JobId As Integer
            Dim JobComponentId As Integer

            Dim TimesheetCommentsRequired As Boolean
            Dim HoursCast As Double

            Dim culureInfo As System.Globalization.CultureInfo
            Dim lg As New LoGlo()
            culureInfo = lg.GetCultureInfo

            Threading.Thread.CurrentThread.CurrentCulture = culureInfo

            If (IsNumeric(ValidationRequest.Job)) Then

                TimesheetCommentsRequired = Me.CommentsRequiredForJob(ValidationRequest.Job)

            End If

            LegacyTrafficObject = New cTraffic(Me.Session.ConnectionString, Me.Session.UserCode)
            LegacyValidationObject = New cValidations(Me.Session.ConnectionString)
            LegacyRequiredFieldValidator = New cRequired(Me.Session.ConnectionString, Me.Session.UserCode)
            LegacyJobFunctionsObject = New cJobFunctions(Me.Session.ConnectionString)
            LegacyTimesheetObject = New cTimeSheet(Me.Session.ConnectionString)

            AgencySettings = New AdvantageFramework.Timesheet.Settings.AgencyTimeEntryOptions(Me.Session.ConnectionString)

            PostPeriodClosedSunday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate))
            PostPeriodClosedMonday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(1))
            PostPeriodClosedTuesday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(2))
            PostPeriodClosedWednesday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(3))
            PostPeriodClosedThursday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(4))
            PostPeriodClosedFriday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(5))
            PostPeriodClosedSaturday = LegacyTimesheetObject.PostPeriodClosed(lg.SetDate(culureInfo, ValidationRequest.SundayDate).AddDays(6))

            ValidationResult = New TimesheetValidationResult()
            ValidationResult.ValidationPassed = True
            ValidationResult.ErrorMessage = String.Empty

            If String.IsNullOrWhiteSpace(ValidationRequest.EmployeeCode) Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Employee Code is required."
            End If

            If ValidationResult.ValidationPassed AndAlso LegacyTrafficObject.IsEmpTerminated(ValidationRequest.EmployeeCode) Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Employee code is inactive."
            End If

            If ValidationResult.ValidationPassed AndAlso LegacyTrafficObject.ValidateEmpCode(ValidationRequest.EmployeeCode) = False Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Invalid employee code."
            End If

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


            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.SundayHours) = False Then
                If ValidateHours(ValidationRequest.SundayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(0).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.MondayHours) = False Then
                If ValidateHours(ValidationRequest.MondayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(1).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.TuesdayHours) = False Then
                If ValidateHours(ValidationRequest.TuesdayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(2).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.WednesdayHours) = False Then
                If ValidateHours(ValidationRequest.WednesdayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for" & CType(ValidationRequest.SundayDate, Date).AddDays(3).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.ThursdayHours) = False Then
                If ValidateHours(ValidationRequest.ThursdayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(4).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.FridayHours) = False Then
                If ValidateHours(ValidationRequest.FridayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(5).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso String.IsNullOrWhiteSpace(ValidationRequest.SaturdayHours) = False Then
                If ValidateHours(ValidationRequest.SaturdayHours) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid hours entry for " & CType(ValidationRequest.SundayDate, Date).AddDays(6).DayOfWeek.ToString() & "."
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.SundayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.SundayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(0).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.MondayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.MondayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(1).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.TuesdayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.TuesdayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(2).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.WednesdayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.WednesdayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(3).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.ThursdayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.ThursdayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(4).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.FridayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.FridayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(5).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso TimesheetCommentsRequired Then
                If Double.TryParse(ValidationRequest.SaturdayHours, HoursCast) Then
                    If HoursCast <> 0 AndAlso String.IsNullOrWhiteSpace(ValidationRequest.SaturdayComments) Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "A comment entry is required for " & CType(ValidationRequest.SundayDate, Date).AddDays(6).DayOfWeek.ToString() & "."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.SundayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(0).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.MondayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(1).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.TuesdayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(2).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.WednesdayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(3).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.ThursdayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(4).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.FridayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(5).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.SaturdayComments.Length > 32000 Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = CType(ValidationRequest.SundayDate, Date).AddDays(6).DayOfWeek.ToString() & " comment exceeds limit of 32,000 characters."
            End If

            If ValidationResult.ValidationPassed AndAlso PostPeriodClosedSunday AndAlso PostPeriodClosedMonday AndAlso PostPeriodClosedTuesday AndAlso PostPeriodClosedWednesday AndAlso PostPeriodClosedThursday AndAlso PostPeriodClosedFriday AndAlso PostPeriodClosedSaturday Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "The posting period for this week is closed."
            End If

            ThisFuncCat = ValidationRequest.FunctionCategory.Trim

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

            If ValidationResult.ValidationPassed AndAlso ThisFuncCat = "" Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Function is a required field."

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

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Job = "" And ValidationRequest.JobComponent = "" And ValidationRequest.FunctionCategory <> "" Then
                'it is a category and not a function
                If LegacyValidationObject.ValidateFunctionCategoryAll(ValidationRequest.EmployeeCode, ThisFuncCat, "V", True) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = ThisFuncCat & " is an invalid category."
                End If
            End If

            Dim CurrDefaultFN As String = LegacyTimesheetObject.GetDefaultFunction(ValidationRequest.EmployeeCode)
            If ValidationResult.ValidationPassed AndAlso ValidationRequest.FunctionCategory = CurrDefaultFN Then
                If LegacyValidationObject.ValidateFunctionTSAddNew(ValidationRequest.EmployeeCode, CurrDefaultFN) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "This employee does not have access to his/her own default function."

                End If
            End If
            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Job <> "" And ValidationRequest.JobComponent <> "" And ValidationRequest.FunctionCategory <> "" And ValidationRequest.FunctionCategory <> CurrDefaultFN Then
                If LegacyValidationObject.ValidateFunctionTSAddNew(ValidationRequest.EmployeeCode, ThisFuncCat) = False Then

                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = ThisFuncCat & " is an invalid function."

                Else

                    If LegacyValidationObject.ValidateFunctionDeptTeamIsInActive(ThisFuncCat) = True Then

                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "Function has inactive deptartment/team."

                    End If

                End If
            End If

            'ThisDept = ValidationRequest.Department

            'If ValidationResult.ValidationPassed AndAlso LegacyValidationObject.ValidateDeptTeam(ThisDept) = False Then
            '    ValidationResult.ValidationPassed = False
            '    ValidationResult.ErrorMessage = "Department is not valid."

            'End If

            If ValidationResult.ValidationPassed Then
                ThisProdCat = ValidationRequest.ProductCategory.Trim
                If ThisProdCat = "" Then

                    If LegacyRequiredFieldValidator.ProductCategoryRequired(ThisClient) = True Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "Product Category is required."

                    End If
                Else
                    If LegacyValidationObject.ValidateProductCategory(ThisProdCat, ThisClient, ThisDiv, ThisProd) = False Then
                        ValidationResult.ValidationPassed = False
                        ValidationResult.ErrorMessage = "Product Category is not valid."
                    End If
                End If
            End If

            If ValidationResult.ValidationPassed = True Then

                If IsNumeric(ValidationRequest.Job) AndAlso IsNumeric(ValidationRequest.JobComponent) Then

                    If LegacyRequiredFieldValidator.RequireTimeEntryAssignment = True AndAlso
                       LegacyRequiredFieldValidator.JobHasWorkItems(CType(ValidationRequest.Job, Integer), CType(ValidationRequest.JobComponent, Integer)) = True Then

                        If String.IsNullOrWhiteSpace(ValidationRequest.AlertID) = True Then

                            ValidationResult.ValidationPassed = False
                            ValidationResult.ErrorMessage = "Assignment is required."

                        Else

                            If IsNumeric(ValidationRequest.AlertID) = False Then

                                ValidationResult.ValidationPassed = False
                                ValidationResult.ErrorMessage = "Assignment is not valid."

                            Else

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, ValidationRequest.AlertID)

                                    If Alert Is Nothing Then

                                        ValidationResult.ValidationPassed = False
                                        ValidationResult.ErrorMessage = "Assignment is not valid."

                                    Else

                                        If Alert.IsWorkItem Is Nothing OrElse Alert.IsWorkItem = False Then

                                            ValidationResult.ValidationPassed = False
                                            ValidationResult.ErrorMessage = "Assignment is not valid."

                                        End If

                                        'do we need to validate that the alert matches the job/comp or does it really really matter at all?
                                        If ValidationResult.ValidationPassed = True Then

                                            Try

                                                If Alert.JobNumber Is Nothing OrElse Alert.JobComponentNumber Is Nothing OrElse
                                                        String.IsNullOrWhiteSpace(ValidationRequest.Job) = True OrElse
                                                        String.IsNullOrWhiteSpace(ValidationRequest.JobComponent) = True Then

                                                    ValidationResult.ValidationPassed = False
                                                    ValidationResult.ErrorMessage = "Assignment is not valid for this job."

                                                End If
                                                If ValidationResult.ValidationPassed = True Then

                                                    If Alert.JobNumber IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ValidationRequest.Job) = False AndAlso Alert.JobNumber.ToString <> ValidationRequest.Job Then

                                                        ValidationResult.ValidationPassed = False
                                                        ValidationResult.ErrorMessage = "Assignment is not valid for this job."

                                                    End If

                                                End If
                                                If ValidationResult.ValidationPassed = True Then

                                                    If Alert.JobComponentNumber IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ValidationRequest.JobComponent) = False AndAlso
                                                        Alert.JobComponentNumber.ToString <> ValidationRequest.JobComponent Then

                                                        ValidationResult.ValidationPassed = False
                                                        ValidationResult.ErrorMessage = "Assignment is not valid for this job."

                                                    End If

                                                End If

                                            Catch ex As Exception
                                            End Try

                                        End If

                                    End If
                                End Using

                            End If

                        End If

                    End If

                End If

            End If

            ValidateTimesheetEntry = ValidationResult

        End Function

        Public Function ValidateAccountSetupEntry(ValidationRequest As TimesheetValidationRequest) As TimesheetValidationResult Implements ITimesheetRepository.ValidateAccountSetupEntry

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

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)
            '    Dim AccountSetupForms As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
            '    Dim TotalPercent As Decimal = 0
            '    AccountSetupForms = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByJobandComponent(DbContext, ValidationRequest.Job, ValidationRequest.JobComponent).ToList

            '    If AccountSetupForms IsNot Nothing Then
            '        For Each AccountSetup In AccountSetupForms
            '            If AccountSetup.ClientCode = ValidationRequest.Client And AccountSetup.DivisionCode = ValidationRequest.Division And AccountSetup.ProductCode = ValidationRequest.Product Then
            '                ValidationResult.ValidationPassed = False
            '                ValidationResult.ErrorMessage = "Client, Division, Product has already been added."
            '            End If
            '        Next
            '    End If

            '    If ValidationRequest.PercentSplit <> "" Then
            '        If (CDec(ValidationRequest.PercentSplit) + TotalPercent) > 100.0 Then
            '            ValidationResult.ValidationPassed = False
            '            ValidationResult.ErrorMessage = "Total Percent can not be more than 100."
            '        End If
            '    End If
            'End Using

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
                If LegacyValidationObject.ValidateCDP(ValidationRequest.Client.Trim, "", "", True) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid Client!"
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Client <> "" And ValidationRequest.Division <> "" Then
                If LegacyValidationObject.ValidateCDPIsViewable("DI", Me.Session.UserCode, ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, "", "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this division is denied."

                End If
                If LegacyValidationObject.ValidateCDP(ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, "", True) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid Client, Division!"
                End If
            End If

            If ValidationResult.ValidationPassed AndAlso ValidationRequest.Client <> "" And ValidationRequest.Division <> "" And ValidationRequest.Product <> "" Then
                If LegacyValidationObject.ValidateCDPIsViewable("PR", Me.Session.UserCode, ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, ValidationRequest.Product.Trim, "ts") = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Access to this product is denied."

                End If
                If LegacyValidationObject.ValidateCDP(ValidationRequest.Client.Trim, ValidationRequest.Division.Trim, ValidationRequest.Product.Trim, True) = False Then
                    ValidationResult.ValidationPassed = False
                    ValidationResult.ErrorMessage = "Invalid Client, Division, Product!"
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

            If IsNumeric(ValidationRequest.PercentSplit) = False Then
                ValidationResult.ValidationPassed = False
                ValidationResult.ErrorMessage = "Invalid Percent."
            End If

            If IsNumeric(ValidationRequest.Job) = True Then
                JobId = CType(ValidationRequest.Job, Integer)
            End If

            If IsNumeric(ValidationRequest.JobComponent) = True Then
                JobComponentId = CType(ValidationRequest.JobComponent, Integer)
            End If




            ValidateAccountSetupEntry = ValidationResult
        End Function

        Private Function ValidateHours(HoursEntry As String) As Boolean
            If HoursEntry.Trim = "" Then
                Return True
            End If

            If IsNumeric(HoursEntry) = False Then
                Return False
            End If

            If HoursEntry >= -24 AndAlso HoursEntry <= 24 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function CommentsRequiredForApproval() As Boolean Implements ITimesheetRepository.CommentsRequiredForApproval
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.EmployeeTimesheet.CheckIfApprovalRequired(DbContext, Me.Session.UserCode)
            End Using
        End Function

        Public Function CommentsRequiredAgencyLevel() As Boolean Implements ITimesheetRepository.CommentsRequiredAgencyLevel
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.Database.Procedures.Agency.Load(DbContext).TimeCommentsRequired.GetValueOrDefault(0) = 1
            End Using
        End Function

        Public Function CommentsRequired() As Boolean Implements ITimesheetRepository.CommentsRequired
            Dim required As New cRequired(Session.ConnectionString)
            CommentsRequired = required.RequiredTimesheetComments
        End Function

        Public Function CommentsRequiredForJob(JobNumber As Integer) As Boolean Implements ITimesheetRepository.CommentsRequiredForJob
            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)
                Return AdvantageFramework.EmployeeTimesheet.CheckTimeCommentsRequired(DbContext, JobNumber, 0, 0)
            End Using
        End Function

        Public Function GetTimesheetTotals(ValidationRequest As TimesheetValidationRequest) As TimesheetTotalsResult Implements ITimesheetRepository.GetTimesheetTotals

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
