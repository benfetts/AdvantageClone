Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports System.Data.SqlClient
Imports System.Web.Script.Services
Imports System.IO
Imports System.Collections
Imports System.Reflection
Imports System.Net
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.ServiceModel.Activation
Imports System.Drawing.Imaging
Imports System.Drawing
Imports AdvantageMobile
Imports DevExtreme.MVC.Demos.Models.FileManagement
Imports Newtonsoft.Json

#If DEBUG Then
<System.ServiceModel.ServiceBehavior(IncludeExceptionDetailInFaults:=True)>
<AdvantageMobile.DataService.JSONPSupportBehavior>
Public Class DataService
#Else
<AdvantageMobile.DataService.JSONPSupportBehavior> _
Public Class DataService
#End If
    Inherits EntityFrameworkDataService(Of Global.AdvantageMobile.DataEntities)
    Implements IServiceProvider

#Region " Constants "

    Private Const _AuthHeaderKey As String = "PBTT20071002"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property _BypassAuthentication As Boolean = False
    Private Property _DataServiceUser As New DataServiceUser

#End Region

#Region " Methods "

#Region " DataService "

    Public Shared Sub InitializeService(ByVal config As DataServiceConfiguration)

        config.SetServiceOperationAccessRule("*", ServiceOperationRights.All)
        config.SetEntitySetAccessRule("*", EntitySetRights.All)
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3
        config.UseVerboseErrors = True

    End Sub
    Public Function GetService(ByVal serviceType As Type) As Object Implements IServiceProvider.GetService

        If serviceType Is GetType(IDataServiceStreamProvider) Then

            ' Return the stream provider to the data service.
            Return New AdvantageMobile.DataService.FileStreamProvider()

        End If

        Return Nothing

    End Function
    Protected Overrides Function CreateDataSource() As Global.AdvantageMobile.DataEntities
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim ErrorMessage As String = String.Empty
        Dim Authorized As Boolean = False

        If HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.Session IsNot Nothing Then

            Me._DataServiceUser.SessionID = HttpContext.Current.Session.SessionID

        End If
        If HttpContext.Current.Request.Headers("Authorization") Is Nothing Then 'This happens for non-content requests such as OPTIONS

            Me._BypassAuthentication = True

        End If

        Me._DataServiceUser.Token = HttpContext.Current.Request.Headers(_AuthHeaderKey)

        If Me._BypassAuthentication = False Then

            Dim IsSecureConnection As Boolean = True

            ' NOTE in production, use basic authentication over SSL only!
            '#If DEBUG Then

            '#Else
            '           IsSecureConnection = HttpContext.Current.Request.IsSecureConnection
            '#End If
            If AdvantageMobile.DataService.Application.GetBooleanConfigSetting(AdvantageMobile.DataService.Application.BooleanWebConfigSetting.SecureConnection) = True Then

                IsSecureConnection = HttpContext.Current.Request.IsSecureConnection

            End If

            If IsSecureConnection = True Then

                Dim auth As New AdvantageMobile.DataService.Security.Authorization()
                If auth.Authorize(HttpContext.Current, Me._DataServiceUser, ErrorMessage) = True Then

                    Authorized = True

                Else

                    Authorized = False
                    If String.IsNullOrWhiteSpace(ErrorMessage) = True Then ErrorMessage = "Authorization failed"
                    Me._DataServiceUser.ErrorMessage = ErrorMessage

                    'Throw New DataServiceException(401, ErrorMessage)
                    'Me._DataServiceUser.IsValid = False

                End If

            Else

                Authorized = False
                'Throw New DataServiceException(401, "DataServices must be run over SSL")
                'Me._DataServiceUser.IsValid = False

            End If

        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'If Not Me._DataServiceUser Is Nothing AndAlso Me._DataServiceUser.IsValid = True Then

        '    Dim UserDataEntities As Global.AdvantageMobile.DataEntities = New Global.AdvantageMobile.DataEntities()
        '    UserDataEntities.Database.Connection.ConnectionString = Me._DataServiceUser.ConnectionString

        '    Return UserDataEntities

        'Else

        '    Return MyBase.CreateDataSource()

        'End If
        If Me._DataServiceUser IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Me._DataServiceUser.ConnectionString) = False Then

            Dim UserDataEntities As Global.AdvantageMobile.DataEntities = New Global.AdvantageMobile.DataEntities()
            UserDataEntities.Database.Connection.ConnectionString = Me._DataServiceUser.ConnectionString

            Return UserDataEntities

        Else

            Return MyBase.CreateDataSource()

        End If

    End Function
    Protected Overrides Sub HandleException(args As HandleExceptionArgs)
        If TypeOf (args.Exception) Is System.Reflection.TargetInvocationException AndAlso args.Exception.InnerException IsNot Nothing Then

            If TypeOf (args.Exception.InnerException) Is DataServiceException Then

                args.Exception = args.Exception.InnerException

            Else

                args.Exception = New DataServiceException(400, args.Exception.InnerException.Message)

            End If

        End If
    End Sub
    'Protected Overrides Sub OnStartProcessingRequest(ByVal args As ProcessRequestArgs)

    '    MyBase.OnStartProcessingRequest(args)

    'End Sub
    'Protected Overrides Sub OnStartProcessingRequest(ByVal args As ProcessRequestArgs)

    '    '' '' '' ''If HttpContext.Current IsNot Nothing AndAlso HttpContext.Current.Session IsNot Nothing Then

    '    '' '' '' ''    Me._DataServiceUser.SessionID = HttpContext.Current.Session.SessionID

    '    '' '' '' ''End If
    '    '' '' '' ''If HttpContext.Current.Request.Headers("Authorization") Is Nothing Then 'This happens for non-content requests such as OPTIONS

    '    '' '' '' ''    Me._BypassAuthentication = True

    '    '' '' '' ''Else

    '    '' '' '' ''    Me._DataServiceUser.Token = HttpContext.Current.Request.Headers("Authorization")

    '    '' '' '' ''End If
    '    '' '' '' ''If Me._BypassAuthentication = False Then

    '    '' '' '' ''    Dim IsSecureConnection As Boolean = True

    '    '' '' '' ''    ' NOTE in production, use basic authentication over SSL only!
    '    '' '' '' ''    '#If DEBUG Then

    '    '' '' '' ''    '#Else
    '    '' '' '' ''    '           IsSecureConnection = HttpContext.Current.Request.IsSecureConnection
    '    '' '' '' ''    '#End If
    '    '' '' '' ''    If AdvantageMobile.DataService.Application.GetBooleanConfigSetting(AdvantageMobile.DataService.Application.BooleanWebConfigSetting.SecureConnection) = True Then

    '    '' '' '' ''        IsSecureConnection = HttpContext.Current.Request.IsSecureConnection

    '    '' '' '' ''    End If

    '    '' '' '' ''    If IsSecureConnection = True Then

    '    '' '' '' ''        Dim auth As New AdvantageMobile.DataService.Security.Authorization()
    '    '' '' '' ''        If auth.Authorize(HttpContext.Current, Me._DataServiceUser) = False Then

    '    '' '' '' ''            Throw New DataServiceException(401, "Invalid user code or password")
    '    '' '' '' ''            Me._DataServiceUser.IsValid = False

    '    '' '' '' ''        End If

    '    '' '' '' ''    Else

    '    '' '' '' ''        Throw New DataServiceException(401, "DataServices must be run over SSL")
    '    '' '' '' ''        Me._DataServiceUser.IsValid = False

    '    '' '' '' ''    End If

    '    '' '' '' ''End If

    '    MyBase.OnStartProcessingRequest(args)

    'End Sub

#End Region

#Region " Service Operations "

    '   Keep Alphabetical:
    '   Don't forget to mark methods with:   <WebGet()> _

    ''Try



    ''Catch ex As Exception

    ''    AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
    ''    Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))

    ''End Try

    <WebGet()>
    Public Function CopyTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal EmployeeCode As String, ByVal [Date] As String) As Global.AdvantageMobile.SaveTimeEntryResult
        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.CopyTimeEntry(EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, [Date])

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function DeleteTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer, ByVal TimeType As String) As String
        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.DeleteTimeEntry(EmployeeTimeID, EmployeeTimeDetailID, TimeType)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function DismissCompleteAlert(ByVal AlertID As Integer, ByVal EmployeeCode As String, Optional ForceAssignmentComplete As Boolean = False) As Boolean

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim ErrorMessage As String = String.Empty

            Return am.DismissCompleteAlert(AlertID, EmployeeCode, ForceAssignmentComplete, ErrorMessage)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAlertAssignedEmployee(ByVal AlertID As Integer) As Global.AdvantageMobile.Employee

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAlertAssignedEmployee(AlertID)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAlertAttachments(ByVal AlertID As Integer, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.AlertAttachmentsList)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return am.GetAlertAttachments(AlertID, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAlertComments(ByVal AlertID As Integer, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.AlertCommentsList)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return am.GetAlertComments(AlertID, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function GetAlertAssignees(ByVal AlertID As Integer) As List(Of Global.AdvantageMobile.advtf_alert_recipient_get_Result)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAlertAssignees(AlertID).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAlertRecipients(ByVal AlertID As Integer,
                                       ByVal Filter As String,
                                       ByVal Sort As String,
                                       ByVal Skip As Integer,
                                       ByVal Take As Integer) As List(Of Global.AdvantageMobile.advtf_alert_recipient_get_Result)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAlertRecipients(AlertID, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAlerts(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String,
                              ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.Alert)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim AlertList As List(Of Global.AdvantageMobile.Alert)

            AlertList = am.GetAlerts(EmployeeCode, SearchValue, Filter, Sort, Skip, Take).ToList()

            For Each Alert As Global.AdvantageMobile.Alert In AlertList.Where(Function(Entity) Entity.ClientCode IsNot Nothing)

                am.GetClientDisplay(Alert)

            Next

            Return AlertList

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAssignments(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String,
                                   ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.Alert)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAssignments(EmployeeCode, SearchValue, Filter, Sort, Skip, Take).ToList

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAssignmentTemplates() As List(Of Global.AdvantageMobile.AlertAssignmentTemplate)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAssignmentTemplates().ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAssignmentTemplateStateDetails(ByVal AssignmentTemplateID As Integer, ByVal AssignmentStateID As Integer) As Global.AdvantageMobile.AlertAssignmentTemplateState

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAssignmentTemplateStateDetails(AssignmentTemplateID, AssignmentStateID)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAssignmentTemplateStateEmployees(ByVal AssignmentTemplateID As Integer, ByVal AssignmentStateID As Integer, ByVal ShowAllActive As Boolean) As List(Of Global.AdvantageMobile.Employee)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAssignmentTemplateStateEmployees(AssignmentTemplateID, AssignmentStateID, ShowAllActive).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetAssignmentTemplateStates(ByVal AssignmentTemplateID As Integer) As List(Of Global.AdvantageMobile.AlertAssignmentState)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.GetAssignmentTemplateStates(AssignmentTemplateID).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetClients(ByVal SearchValue As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.Client)

        Try

            Dim cm As New AdvantageMobile.DataService.Client.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return cm.GetClients(SearchValue, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetClientsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Client

        Try

            Dim cm As New AdvantageMobile.DataService.Client.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return cm.GetClientsByJobNumber(JobNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetDepartmentsByEmployeeCode(ByVal EmployeeCode As String) As List(Of Global.AdvantageMobile.EmployeeDepartmentTeam)

        Try

            Dim dtm As New AdvantageMobile.DataService.DepartmentTeam.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return dtm.GetDepartmentsByEmployeeCode(EmployeeCode).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetDivisions(ByVal ClientCode As String, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.Division)

        Try

            Dim dm As New AdvantageMobile.DataService.Division.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return dm.GetDivisions(ClientCode, SearchValue).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetDivisionsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Division

        Try

            Dim dm As New AdvantageMobile.DataService.Division.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return dm.GetDivisionsByJobNumber(JobNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetEmployeeSchedule(ByVal EmployeeCode As String, ByVal StartDate As String, ByVal EndDate As String, ByVal SearchValue As String,
                                        ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.CalendarItem)

        Try

            Dim cm As New AdvantageMobile.DataService.Calendar.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return cm.GetEmployeeSchedule(EmployeeCode, StartDate, EndDate, SearchValue, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetEmployeeSummary(ByVal EmployeeCode As String) As Global.AdvantageMobile.EmployeeSummary
        Try
            If Me._DataServiceUser Is Nothing Then
                AdvantageMobile.DataService.Application.DebugMessageToEventLog("DataService.svc Me._DataServiceUser Is Nothing")
            End If
            Dim e As New AdvantageMobile.DataService.Employee.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return e.GetEmployeeSummary(EmployeeCode)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetEmployeeTime(ByVal EmployeeCode As String, ByVal [Date] As String) As Global.AdvantageMobile.EmployeeTime

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetEmployeeTime(EmployeeCode, [Date])

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function GetFunctionsByEmployeeCode(ByVal EmployeeCode As String, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.[Function])

        Try

            Dim fm As New AdvantageMobile.DataService.Function.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return fm.GetFunctionsByEmployeeCode(EmployeeCode, SearchValue).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function LoadAllEmployeeExpenseFunctions(ByVal SearchValue As String) As List(Of Global.AdvantageMobile.[Function])

        Try

            Dim fm As New AdvantageMobile.DataService.Function.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return fm.LoadAllEmployeeExpenseFunctions(SearchValue).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetHoursForDay(ByVal EmployeeCode As String, ByVal [Date] As String) As Nullable(Of Decimal)

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetHoursForDay(EmployeeCode, [Date])

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetHoursThisWeek(ByVal EmployeeCode As String) As Nullable(Of Decimal)

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetHoursThisWeek(EmployeeCode)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Global.AdvantageMobile.JobComponent

        Try

            Dim jcm As New AdvantageMobile.DataService.JobJacket.JobComponent.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return jcm.GetJobComponent(JobNumber, JobComponentNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobComponents(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal JobNumber As Integer, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.JobComponent)

        Try

            Dim jcm As New AdvantageMobile.DataService.JobJacket.JobComponent.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return jcm.GetJobComponents(ClientCode, DivisionCode, ProductCode, JobNumber, SearchValue, 0).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobComponentsExpense(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                            ByVal JobNumber As Integer, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.JobComponent)

        Try

            Dim jcm As New AdvantageMobile.DataService.JobJacket.JobComponent.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return jcm.GetJobComponents(ClientCode, DivisionCode, ProductCode, JobNumber, SearchValue, 1).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobLog(ByVal JobNumber As Integer) As Global.AdvantageMobile.JobLog

        Try

            Dim jm As New AdvantageMobile.DataService.JobJacket.Job.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return jm.GetJobLog(JobNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobLogs(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SearchValue As String,
                               ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.JobLog)

        Try

            Dim jm As New AdvantageMobile.DataService.JobJacket.Job.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim Jobs As List(Of Global.AdvantageMobile.JobLog)
            Jobs = Nothing

            Jobs = jm.GetJobLogs(ClientCode, DivisionCode, ProductCode, SearchValue, 0, Skip, Take).ToList()

            Return Jobs

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetJobLogsExpense(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SearchValue As String,
                                      ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.JobLog)

        Try

            Dim jm As New AdvantageMobile.DataService.JobJacket.Job.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim Jobs As List(Of Global.AdvantageMobile.JobLog)
            Jobs = Nothing

            Jobs = jm.GetJobLogs(ClientCode, DivisionCode, ProductCode, SearchValue, 1, Skip, Take).ToList()

            Return Jobs

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetMobileUser() As Global.AdvantageMobile.MobileUser

        Try

            Dim sm As New AdvantageMobile.DataService.Security.Methods(Me.CurrentDataSource)
            Dim mu As New Global.AdvantageMobile.MobileUser
            mu = sm.GetMobileUser(Me._DataServiceUser)

            If mu.IsValid = True Then

                mu.Token = Me._DataServiceUser.Token

                Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
                mu.TimeApprovalActive = tsm.IsApprovalActive(mu.EmployeeCode)

            Else

                Try

                    If String.IsNullOrWhiteSpace(Me._DataServiceUser.ConnectionString) = True Then

                        mu.IsValidDatabase = False
                        mu.ThemeWin8 = "Invalid database."

                    End If
                    If String.IsNullOrWhiteSpace(mu.ThemeWin8) = True AndAlso
                       String.IsNullOrWhiteSpace(Me._DataServiceUser.ErrorMessage) = False Then

                        mu.ThemeWin8 = Me._DataServiceUser.ErrorMessage

                    End If

                Catch ex As Exception
                End Try

            End If

            Return mu

        Catch ex As Exception
            Dim mu As New Global.AdvantageMobile.MobileUser
            mu.IsValid = False
            mu.IsValidDatabase = False
            mu.ThemeWin8 = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            Return mu
        End Try

    End Function
    <WebGet()>
    Public Function GetProducts(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.Product)

        Try

            Dim pm As New AdvantageMobile.DataService.Product.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return pm.GetProducts(ClientCode, DivisionCode, SearchValue).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetProductsByJobNumber(ByVal JobNumber As Integer) As Global.AdvantageMobile.Product

        Try

            Dim pm As New AdvantageMobile.DataService.Product.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return pm.GetProductsByJobNumber(JobNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetProjects(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.ProjectViewpoint)

        Try

            Dim pm As New AdvantageMobile.DataService.ProjectSchedule.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return pm.GetProjects(EmployeeCode, SearchValue, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetRecipientSelect(ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SearchValue As String) As List(Of Global.AdvantageMobile.EmailRecipients)

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            SearchValue = SearchValue.Trim()
            If SearchValue = "" Then

                Return am.GetRecipients(AlertID, JobNumber, JobComponentNumber, "", "", "", 0, 0).ToList()

            Else

                Return am.GetRecipients(AlertID, JobNumber, JobComponentNumber, "", "", "", 0, 0).ToList().Where(Function(EmailRecipients) EmailRecipients.FullName.ToUpper().Contains(SearchValue.ToUpper())).ToList()

            End If

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTask(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As Global.AdvantageMobile.JobTrafficDetail

        Try

            Dim tm As New AdvantageMobile.DataService.ProjectSchedule.Task.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tm.GetTask(JobNumber, JobComponentNumber, SequenceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTasks(ByVal EmployeeCode As String, ByVal SearchValue As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.MyTask)

        Try

            Dim tm As New AdvantageMobile.DataService.ProjectSchedule.Task.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim TaskList As New List(Of Global.AdvantageMobile.MyTask)
            Dim SearchFor As AdvantageMobile.DataService.Application.SearchFor = AdvantageMobile.DataService.Application.SearchFor.Standard
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0

            SearchFor = AdvantageMobile.DataService.Application.GetSearchType(SearchValue, JobNumber, JobComponentNumber)

            Select Case SearchFor
                Case AdvantageMobile.DataService.Application.SearchFor.JobNumber

                    TaskList = tm.GetTasks(EmployeeCode, "", Filter, Sort, Skip, Take).ToList().Where(Function(Entity) Entity.JobNumber = JobNumber).ToList()

                Case AdvantageMobile.DataService.Application.SearchFor.JobNumberAndJobComponentNumber

                    TaskList = tm.GetTasks(EmployeeCode, "", Filter, Sort, Skip, Take).ToList().Where(Function(Entity) Entity.JobNumber = JobNumber AndAlso Entity.JobComponentNumber = JobComponentNumber).ToList()

                Case Else

                    TaskList = tm.GetTasks(EmployeeCode, SearchValue, Filter, Sort, Skip, Take).ToList()

            End Select

            Return TaskList

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimeCategories(ByVal SearchValue As String) As List(Of Global.AdvantageMobile.TimeCategory)

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimeCategories(SearchValue).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimeEntry(ByVal EmployeeTimeID As Integer, ByVal EmployeeTimeDetailID As Integer) As Global.AdvantageMobile.TimeEntry

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimeEntry(EmployeeTimeID, EmployeeTimeDetailID)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimesheetDay(ByVal EmployeeCode As String, ByVal [Date] As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.TimeEntry)

        Try

            AdvantageMobile.DataService.Application.UrlDecode([Date])

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimesheetDay(EmployeeCode, [Date], Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimesheetMonth(ByVal EmployeeCode As String, ByVal [Date] As String) As List(Of Global.AdvantageMobile.TimeEntry)

        Try

            AdvantageMobile.DataService.Application.UrlDecode([Date])

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimesheetMonth(EmployeeCode, [Date]).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimesheetWeek(ByVal EmployeeCode As String, ByVal [Date] As String) As List(Of Global.AdvantageMobile.TimeEntry)

        Try

            AdvantageMobile.DataService.Application.UrlDecode([Date])

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimesheetWeek(EmployeeCode, [Date]).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimeSummary(ByVal EmployeeCode As String, ByVal Group As Short, ByVal [Date] As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.TimeSummary)

        Try

            AdvantageMobile.DataService.Application.UrlDecode([Date])

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimeSummary(EmployeeCode, Group, [Date], Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimeTemplate(ByVal EmployeeTimeTemplateID As Integer) As Global.AdvantageMobile.EmployeeTimeTemplate

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimeTemplate(EmployeeTimeTemplateID)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTimeTemplates(ByVal EmployeeCode As String, ByVal Filter As String, ByVal Sort As String, ByVal Skip As Integer, ByVal Take As Integer) As List(Of Global.AdvantageMobile.TimeTemplate)

        Try

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.GetTimeTemplates(EmployeeCode, Filter, Sort, Skip, Take).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    '<WebGet()> _
    'Public Function IsEmployeeAssociatedToVendorCode(ByVal EmployeeCode As String) As Boolean

    '    Try

    '        Dim erm As New AdvantageMobile.ExpenseReport.Methods(Me.CurrentDataSource, Me._DataServiceUser)
    '        Return erm.IsEmployeeAssociatedToVendorCode(EmployeeCode)

    '    Catch ex As Exception

    '        AdvantageMobile.DataService.Application.ThrowNewDataServiceException(ex)
    '        Return False

    '    End Try

    'End Function
    <WebGet()>
    Public Function ImageReceiptUpload(ByVal ID As Integer, ByVal Image As String) As Integer 'success return 1 else 0
        Try

            Return 1

        Catch ex As Exception

            Return 0

        End Try
    End Function

    <WebGet()>
    Public Function IsTimesheetPostPeriodClosed(ByVal [Date] As String) As Boolean

        Try

            AdvantageMobile.DataService.Application.UrlDecode([Date])

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.IsTimesheetPostPeriodClosed([Date])

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function IsValidDatabase() As Boolean

        Try

            Dim sec As New AdvantageMobile.DataService.Security.Methods(Me.CurrentDataSource)
            Return sec.IsValidDatabase()

        Catch ex As Exception
            Return True
        End Try

    End Function
    <WebGet()>
    Public Function MarkTaskTempComplete(ByVal EmployeeCode As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As Boolean

        Try

            Dim tm As New AdvantageMobile.DataService.ProjectSchedule.Task.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tm.MarkTaskTempComplete(EmployeeCode, JobNumber, JobComponentNumber, SequenceNumber, Now.Date)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function NotifiyAlertRecipients(ByVal AlertID As Integer, ByVal IsNew As Boolean, ByVal IncludeOriginator As Boolean) As Boolean

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.NotifiyAlertRecipients(AlertID, IsNew, IncludeOriginator)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SaveAlertAssignment(ByVal AlertID As Integer, ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer, ByVal EmployeeCode As String, ByVal UserCode As String,
                                        ByVal Comments As String, ByVal IsUnassigned As Boolean, ByVal IsNewAssignment As Boolean) As Boolean

        Try

            AdvantageMobile.DataService.Application.UrlDecode(Comments)

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim ErrorMessage As String = String.Empty
            Dim Saved As Boolean = False

            Saved = am.SaveAlertAssignment(AlertID, AlertTemplateID, AlertStateID, EmployeeCode, UserCode, Comments, IsUnassigned, IsNewAssignment, ErrorMessage)

            Return Saved

        Catch ex As Exception
            'AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            'Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SaveAlertRecipients(ByVal AlertID As Integer, ByVal Codes As String) As Boolean

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.SaveAlertRecipients(AlertID, Codes)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SaveAlertComment(ByVal AlertID As Integer, ByVal Comment As String) As Boolean

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.SaveAlertComment(AlertID, Comment)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function SaveTimeEntry(ByVal EmployeeTimeID As Integer,
                                  ByVal EmployeeTimeDetailID As Integer,
                                  ByVal EmployeeCode As String,
                                  ByVal EmployeeDate As String,
                                  ByVal FunctionOrCategory As String,
                                  ByVal EmployeeHours As String,
                                  ByVal JobNumber As Integer,
                                  ByVal JobComponentNumber As Short,
                                  ByVal DepartmentTeam As String,
                                  ByVal ProductCategory As String,
                                  ByVal UserID As String,
                                  ByVal Comments As String,
                                  ByVal AlertID As Integer?,
                                  ByVal TaskSequenceNumber As Short?) As Global.AdvantageMobile.SaveTimeEntryResult

        Try

            AdvantageMobile.DataService.Application.UrlDecode(EmployeeDate)
            AdvantageMobile.DataService.Application.UrlDecode(EmployeeHours)
            AdvantageMobile.DataService.Application.UrlDecode(Comments)

            Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tsm.SaveTimeEntry(EmployeeTimeID, EmployeeTimeDetailID, EmployeeCode, EmployeeDate, FunctionOrCategory, EmployeeHours,
                                     JobNumber, JobComponentNumber, DepartmentTeam, ProductCategory, UserID, Comments, AlertID, TaskSequenceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SearchForTimesheetJobs(ByVal SearchValue As String) As List(Of Global.AdvantageMobile.SimpleJob)

        Try

            Dim jm As New AdvantageMobile.DataService.JobJacket.Job.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return jm.SearchForTimesheetJobs(SearchValue).ToList()

        Catch ex As Exception
            Dim list As New List(Of Global.AdvantageMobile.SimpleJob)
            Return list
            'AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            'Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SignIn() As Integer

        Try

            Dim cred As New AdvantageFramework.Mobile.Classes.Credential(Me._DataServiceUser.Token)
            Dim LicenseSet As Boolean = False
            Dim LicenseID As Integer = 0

            If cred IsNot Nothing Then

                Dim ErrorMessage As String = ""
                Dim sec As New AdvantageMobile.DataService.Security.Methods(Me.CurrentDataSource)

                If cred.ChooseServer = False OrElse cred.ServerName = "" Then

                    sec.LoadRegistrySignIn(cred.DatabaseName, cred.ServerName, Nothing, Nothing)

                End If

                LicenseID = sec.SignIn(cred.ServerName, cred.DatabaseName, cred.IsWindowsAuth, cred.UserCode, cred.Password, cred.ChooseServer, Me._DataServiceUser.SessionID)

                If LicenseID > 0 Then

                    AdvantageMobile.DataService.Application.AddToEventLog("Sign in succeeded for user: " & cred.UserCode, Diagnostics.EventLogEntryType.SuccessAudit)

                End If

            End If

            Return LicenseID

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SignOut() As Integer
        Try

            Dim cred As New AdvantageFramework.Mobile.Classes.Credential(Me._DataServiceUser.Token)
            Dim SignedOut As Boolean = False
            Dim LicenseID As Integer = 0

            If cred IsNot Nothing Then

                Dim ErrorMessage As String = ""
                Dim sec As New AdvantageMobile.DataService.Security.Methods(Me.CurrentDataSource)

                LicenseID = sec.SignOut(cred.ServerName, cred.DatabaseName, cred.IsWindowsAuth, cred.UserCode, cred.Password, cred.ChooseServer, cred.AdvantageUserLicenseInUseID)

                If cred.AdvantageUserLicenseInUseID <> 0 And LicenseID = 0 Then

                    AdvantageMobile.DataService.Application.AddToEventLog("Sign out succeeded for user: " & cred.UserCode, Diagnostics.EventLogEntryType.SuccessAudit)

                End If

            End If

            Return LicenseID

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function SubmitDayForTimeApproval(ByVal EmployeeCode As String, ByVal EmployeeDate As String, ByVal Approve As Boolean) As String

        Dim tsm As New AdvantageMobile.DataService.Timesheet.Methods(Me.CurrentDataSource, Me._DataServiceUser)
        Return tsm.SubmitForApproval(EmployeeCode, CType(EmployeeDate, Date), Approve)

    End Function
    <WebGet()>
    Public Function UpdateAssignment(ByVal AlertID As Integer, ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer, ByVal IsUnassigned As Boolean, ByVal EmployeeCode As String, ByVal Comment As String) As String

        Try

            Dim am As New AdvantageMobile.DataService.Alert.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return am.UpdateAlertAssignment(AlertID, AlertTemplateID, AlertStateID, IsUnassigned, EmployeeCode, Comment)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function UnMarkTaskTempComplete(ByVal EmployeeCode As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As Boolean

        Try

            Dim tm As New AdvantageMobile.DataService.ProjectSchedule.Task.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return tm.MarkTaskTempComplete(EmployeeCode, JobNumber, JobComponentNumber, SequenceNumber, Nothing)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

#End Region

#Region "Service Operations - Expense"

    <WebGet()>
    Public Function GetApprover(ByVal Key As String) As Global.AdvantageMobile.AvailableApprover

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return exp.GetApprover(Key)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function GetApproverList(ByVal EmployeeCode As String,
                                    ByVal SearchValue As String,
                                    ByVal Skip As Integer, ByVal Take As Integer) As Generic.List(Of Global.AdvantageMobile.AvailableApprover)

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim list As Generic.List(Of Global.AdvantageMobile.AvailableApprover)

            list = exp.GetApproverList(EmployeeCode, SearchValue, Skip, Take)

            Return list

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function

    <WebGet()>
    Public Function GetExpenseReportOptions(ByVal InvoiceNumber As Integer) As Global.AdvantageMobile.ExpenseReportSubmitOptions

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return exp.GetExpenseReportOptions(InvoiceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function InsertExpenseHeader(ByVal EmployeeCode As String,
                                        ByVal ExpenseDate As String,
                                        ByVal Description As String,
                                        ByVal Details As String
                                        ) As String

        Try

            AdvantageMobile.DataService.Application.UrlDecode(ExpenseDate)
            AdvantageMobile.DataService.Application.UrlDecode(Description)
            AdvantageMobile.DataService.Application.UrlDecode(Details)

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return exp.InsertExpenseHeader(EmployeeCode, ExpenseDate, Description, Details).ToString

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function UpdateExpenseHeader(ByVal InvoiceNumber As Integer,
                                    ByVal ExpenseDate As String,
                                    ByVal Description As String,
                                    ByVal Details As String
                                    ) As String
        Try
            AdvantageMobile.DataService.Application.UrlDecode(ExpenseDate)
            AdvantageMobile.DataService.Application.UrlDecode(Description)
            AdvantageMobile.DataService.Application.UrlDecode(Details)

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.UpdateExpenseHeader(InvoiceNumber, ExpenseDate, Description, Details)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function DeleteExpenseHeader(ByVal InvoiceNumber As Integer
                                ) As String
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.DeleteExpenseHeader(InvoiceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function

    <WebGet()>
    Public Function SubmitExpenseReport(ByVal EmployeeCode As String,
                                        ByVal InvoiceNumber As Integer,
                                        ByVal ApproverEmployeeCode As String,
                                        ByVal IncludeReceiptsInEmailAndAlert As Boolean) As String

        Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
        Return exp.SubmitExpenseReport(EmployeeCode, InvoiceNumber, ApproverEmployeeCode, IncludeReceiptsInEmailAndAlert).ToString

    End Function
    <WebGet()>
    Public Function UnSubmitExpenseReport(ByVal EmployeeCode As String, ByVal InvoiceNumber As Integer) As String
        Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
        Return exp.UnSubmitExpenseReport(EmployeeCode, InvoiceNumber).ToString
    End Function
    <WebGet()>
    Public Function CopyExpenseReport(ByVal InvoiceNumber As Integer, ByVal EmployeeCode As String,
                                      ByVal ReportDate As String, ByVal Description As String, ByVal Details As String) As String

        Try
            AdvantageMobile.DataService.Application.UrlDecode(ReportDate)
            AdvantageMobile.DataService.Application.UrlDecode(Description)
            AdvantageMobile.DataService.Application.UrlDecode(Details)

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.CopyExpenseReport(InvoiceNumber, EmployeeCode, ReportDate, Description, Details).ToString
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function CopyExpenseReportDetail(ByVal ExpenseDetailID As String, ByVal InvoiceNumber As String, ByVal EmployeeCode As String) As String

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.CopyExpenseReportDetail(ExpenseDetailID, InvoiceNumber, EmployeeCode).ToString
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpenses(ByVal EmployeeCode As String) As Generic.List(Of Global.AdvantageMobile.Expense)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpenses(EmployeeCode).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetOpenReports(ByVal EmployeeCode As String) As Generic.List(Of Global.AdvantageMobile.Expense)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetOpenReports(EmployeeCode).ToList()

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function InsertExpenseDetail(ByVal ID As Integer,
    ByVal InvoiceNumber As Integer,
    ByVal LineNumber As Integer,
    ByVal ItemDate As String,
    ByVal Description As String,
    ByVal CcFlag As Nullable(Of Boolean),
    ByVal ClientCode As String,
    ByVal DivisionCode As String,
    ByVal ProductCode As String,
    ByVal JobNumber As Nullable(Of Integer),
    ByVal JobComponentNumber As Nullable(Of Short),
    ByVal FunctionCode As String,
    ByVal Quantity As Nullable(Of Integer),
    ByVal Rate As String,
    ByVal CcAmount As String,
    ByVal Amount As String,
    ByVal ApComment As String,
    ByVal CreatedBy As String,
    ByVal ModifiedBy As String,
    ByVal ModifiedDate As String,
    ByVal PaymentType As Nullable(Of Short)) As String
        Try

            AdvantageMobile.DataService.Application.UrlDecode(ItemDate)
            AdvantageMobile.DataService.Application.UrlDecode(Description)

            Dim expense = New Global.AdvantageMobile.ExpenseDetail()
            expense.ID = ID
            expense.InvoiceNumber = InvoiceNumber
            expense.LineNumber = LineNumber
            expense.ItemDate = CType(ItemDate, Date)
            expense.Description = Description
            expense.CcFlag = CcFlag
            expense.ClientCode = ClientCode
            expense.DivisionCode = DivisionCode
            expense.ProductCode = ProductCode
            expense.JobNumber = JobNumber
            expense.JobComponentNumber = JobComponentNumber
            expense.FunctionCode = FunctionCode
            expense.Quantity = Quantity
            expense.Rate = CType(Rate, Decimal)
            expense.CcAmount = CType(CcAmount, Decimal)
            expense.Amount = CType(Amount, Decimal)
            expense.ApComment = ApComment
            expense.CreatedBy = CreatedBy
            expense.ModifiedBy = ModifiedBy
            expense.ModifiedDate = CType(ModifiedDate, Date)
            expense.PaymentType = PaymentType
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.InsertExpenseDetail(expense).ToString
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function UpdateExpenseDetail(ByVal ID As Integer,
    ByVal InvoiceNumber As Integer,
    ByVal LineNumber As Integer,
    ByVal ItemDate As String,
    ByVal Description As String,
    ByVal CcFlag As Boolean,
    ByVal ClientCode As String,
    ByVal DivisionCode As String,
    ByVal ProductCode As String,
    ByVal JobNumber As Integer,
    ByVal JobComponentNumber As Short,
   ByVal FunctionCode As String,
   ByVal Quantity As Integer,
   ByVal Rate As String,
   ByVal CcAmount As String,
   ByVal Amount As String,
   ByVal ApComment As String,
   ByVal CreatedBy As String,
   ByVal ModifiedBy As String,
   ByVal ModifiedDate As String,
   ByVal PaymentType As Short) As String
        Try

            AdvantageMobile.DataService.Application.UrlDecode(ItemDate)
            AdvantageMobile.DataService.Application.UrlDecode(Description)

            Dim expense = New Global.AdvantageMobile.ExpenseDetail()
            expense.ID = ID
            expense.InvoiceNumber = InvoiceNumber
            expense.LineNumber = LineNumber
            expense.ItemDate = CType(ItemDate, Date)
            expense.Description = Description
            expense.CcFlag = CcFlag
            expense.ClientCode = ClientCode
            expense.DivisionCode = DivisionCode
            expense.ProductCode = ProductCode
            expense.JobNumber = JobNumber
            expense.JobComponentNumber = JobComponentNumber
            expense.FunctionCode = FunctionCode
            expense.Quantity = Quantity
            expense.Rate = CType(Rate, Decimal)
            expense.CcAmount = CType(CcAmount, Decimal)
            expense.Amount = CType(Amount, Decimal)
            expense.ApComment = ApComment
            expense.CreatedBy = CreatedBy
            expense.ModifiedBy = ModifiedBy
            expense.ModifiedDate = CType(ModifiedDate, Date)
            expense.PaymentType = PaymentType
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.UpdateExpenseDetail(expense)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function DeleteExpenseDetail(ByVal expenseDetailID As Integer
                                ) As String
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.DeleteExpenseDetail(expenseDetailID)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function

    <WebGet()>
    Public Function GetExpensesOpen(ByVal EmployeeCode As String) As Nullable(Of Decimal)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpensesOpen(EmployeeCode)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpensesPending(ByVal EmployeeCode As String) As Nullable(Of Decimal)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpensesPending(EmployeeCode)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpensesDenied(ByVal EmployeeCode As String) As Nullable(Of Decimal)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpensesDenied(EmployeeCode)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetFunctionRate(ByVal FunctionCode As String) As Nullable(Of Decimal)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetFunctionRate(FunctionCode)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpenseReport(ByVal InvoiceNumber As String) As Global.AdvantageMobile.Expense
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpenseReport(InvoiceNumber).FirstOrDefault()
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpenseItems(ByVal InvoiceNumber As String) As Generic.List(Of Global.AdvantageMobile.ExpenseDetail)
        Try
            AdvantageMobile.DataService.Application.UrlDecode(InvoiceNumber)
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpenseReportItems(InvoiceNumber)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpenseDetail(ByVal InvoiceNumber As String, ByVal ExpenseDetailID As String) As Global.AdvantageMobile.ExpenseDetail
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpenseDetail(ExpenseDetailID)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetTotalInvoiceAmount(ByVal InvoiceNumber As Integer) As Nullable(Of Decimal)

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetTotalInvoiceAmount(InvoiceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetTotalExpenseAmount(ByVal InvoiceNumber As Integer) As Nullable(Of Decimal)

        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetTotalExpenseAmount(InvoiceNumber)

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try

    End Function
    <WebGet()>
    Public Function GetExpenseDocuments(ByVal InvoiceNumber As String) As Generic.List(Of Global.AdvantageMobile.Document)
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetDocumentsByInvoiceNumber(InvoiceNumber).ToList()
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetExpenseDetailDocument(ByVal DocumentID As Integer, ByVal ExpenseDetailID As Integer) As Global.AdvantageMobile.ExpenseDetailDocument
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetExpenseDetailDocument(DocumentID, ExpenseDetailID)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetDocumentsByExpenseDetailID(ByVal ExpenseDetailID As Integer) As Generic.List(Of Global.AdvantageMobile.Document)
        Try

            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Dim list As Generic.List(Of Global.AdvantageMobile.Document) = Nothing

            list = exp.GetDocumentsByExpenseDetailID(ExpenseDetailID).ToList()

            Return list

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetDocumentFromDatabase(ByVal DocumentID As Integer) As Global.AdvantageMobile.Document
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetDocumentFromDatabase(DocumentID)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function GetDocumentFromRepository(ByVal RepositoryFileName As String) As Byte()
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return exp.GetDocumentFromRepository(RepositoryFileName)
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function

    <WebInvoke(Method:="POST", RequestFormat:=WebMessageFormat.Json)>
    Public Function UploadChunk(ByVal file As String, ByVal chunkMetadata2 As String) As Boolean

        Try

            Dim fb As HttpPostedFileBase

            If String.IsNullOrWhiteSpace(file) Then

                'fb = CType(file, HttpPostedFileBase)

            End If

            If String.IsNullOrWhiteSpace(chunkMetadata2) = False Then

                Dim metaDataObject = JsonConvert.DeserializeObject(Of ChunkMetaData)(chunkMetadata2)

            End If

        Catch ex As Exception

        End Try

    End Function
    <Serializable>
    Public Class ChunkMetaData
        Public Property Index As Integer
        Public Property TotalCount As Integer
        Public Property FileSize As Integer
        Public Property FileName As String
        Public Property FileType As String
        Public Property FileGuid As String
        Sub New()

        End Sub
    End Class

    <WebInvoke(Method:="POST", RequestFormat:=WebMessageFormat.Json)>
    Public Function SaveDocument(ByVal EmployeeCode As String, ByVal InvoiceNumber As String, ByVal ExpenseDetailID As String, ByVal RowID As Integer, ByVal name As String) As String
        Try
            ', ByVal documentBase64 As String
            Dim documentBase64 As String = Encoding.UTF8.GetString(OperationContext.Current.RequestContext.RequestMessage.GetBody(Of Byte()))

            ' Restore the byte array.
            AdvantageMobile.DataService.Application.UrlDecode(documentBase64)

            Dim doc As String() = documentBase64.Split(New Char() {","c})

            'Resize the image (max with of 800 pixels)
            doc(1) = ResizeImage(doc(1))

            AdvantageMobile.DataService.Application.UrlDecode(EmployeeCode)
            AdvantageMobile.DataService.Application.UrlDecode(InvoiceNumber)
            AdvantageMobile.DataService.Application.UrlDecode(ExpenseDetailID)
            AdvantageMobile.DataService.Application.UrlDecode(RowID)
            AdvantageMobile.DataService.Application.UrlDecode(name)

            Dim fileType As String = doc(0)
            Dim documentBytes() As Byte = Convert.FromBase64String(doc(1))
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)

            Return exp.AddDocument(EmployeeCode, InvoiceNumber, ExpenseDetailID, RowID, name, documentBytes, fileType, String.Empty, String.Empty, String.Empty).ToString

        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function

    <WebGet()>
    Public Function RetrieveDocument(ByVal repositoryFilename As String) As String
        Try
            Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
            Return Convert.ToBase64String(exp.GetDocumentFromRepository(repositoryFilename))
        Catch ex As Exception
            AdvantageMobile.DataService.Application.ErrorToEventLog(ex)
            Throw New DataServiceException(500, ex.Message.ToString() & If(ex.InnerException IsNot Nothing, Environment.NewLine & " INNER:  " & ex.InnerException.Message.ToString(), ""))
        End Try
    End Function
    <WebGet()>
    Public Function DeleteDetailDocument(ByVal DocumentID As Integer) As String
        Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
        Return exp.DeleteDetailDocument(DocumentID).ToString
    End Function
    <WebGet()>
    Public Function DeleteHeaderDocument(ByVal InvoiceNumber As String, ByVal DocumentID As String) As String
        Dim exp As New AdvantageMobile.DataService.Expense.Methods(Me.CurrentDataSource, Me._DataServiceUser)
        Return exp.DeleteHeaderDocument(InvoiceNumber, DocumentID).ToString
    End Function
#End Region

    Private Function ResizeImage(ByVal base64Image As String) As String

        Dim img As Drawing.Image = Base64ToImage(base64Image)
        Dim scaleFactor As Double = 1

        'Calculate the scale factor
        If (img.Size.Height > img.Size.Width) Then
            'Max 800 x 600
            scaleFactor = (600 / img.Size.Height)
        Else
            'Max 800 x 600
            scaleFactor = (800 / img.Size.Width)
        End If

        Dim bm_dest As New Bitmap(
            CInt(img.Width * scaleFactor),
            CInt(img.Height * scaleFactor))

        ' Make a Graphics object for the result Bitmap.
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        ' Copy the source image into the destination bitmap.
        gr_dest.DrawImage(img, 0, 0,
            bm_dest.Width + 1,
            bm_dest.Height + 1)

        ' Convert back to base64.
        Dim s64 As String = ImageToBase64(bm_dest)

        'dispose of the image
        img.Dispose()

        'dispose of the graphics object
        gr_dest.Dispose()

        'return the new scaled base64 encoded image
        Return s64

    End Function

    Function Base64ToImage(ByVal base64string As String) As System.Drawing.Image
        'Setup image and get data stream together
        Dim img As System.Drawing.Image
        Dim MS As System.IO.MemoryStream = New System.IO.MemoryStream
        Dim b64 As String = base64string.Replace(" ", "+")
        Dim b() As Byte

        'Converts the base64 encoded msg to image data
        b = Convert.FromBase64String(b64)
        MS = New System.IO.MemoryStream(b)

        'creates image
        img = System.Drawing.Image.FromStream(MS)

        'dispose of the memort stream
        MS.Dispose()

        Return img

    End Function

    Function ImageToBase64(ByVal img As Drawing.Image)

        Dim MS As MemoryStream = New MemoryStream()

        img.Save(MS, ImageFormat.Jpeg)

        Dim s64 As String = System.Convert.ToBase64String(MS.GetBuffer())

        MS.Dispose()

        Return s64

    End Function

#End Region

End Class

