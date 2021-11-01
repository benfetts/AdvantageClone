Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Data.Services
Imports System.Data.Services.Common
Imports System.Data.Services.Providers
Imports System.Data.SqlClient
Imports System.Linq
Imports System.ServiceModel.Web
Imports System.Web
Imports System.Diagnostics
Imports System.Reflection


Namespace AdvantageMobile.DataService.Application

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "

        Private Const _EventLogName = "Adv Dataservice Log"

        Private Const _EventSource = "Adv Dataservice Message"
        Private Const _DebugEventSource = "Adv Dataservice Debug Message"
        Private Const _WarningEventSource = "Adv Dataservice Warning"
        Private Const _ErrorEventSource = "Adv Dataservice Error"

#End Region

#Region " Enum "

        Public Enum BooleanWebConfigSetting

            SecureConnection
            UpperCaseUser
            UpperCaseDatabase
            ChooseServer
            SQLControledAdmin
            NTAuthIgnoreCase
            EnableDocRepSize

        End Enum
        Public Enum StringWebConfigSetting

            PlaceHolder

        End Enum
        Public Enum SearchFor

            None = 0
            Standard = 1
            JobNumber = 2
            JobNumberAndJobComponentNumber = 3

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub UrlDecode(ByRef Value As String)

            Value = Web.HttpUtility.UrlDecode(Value)

        End Sub

        Public Function GetBooleanConfigSetting(ByVal Setting As BooleanWebConfigSetting) As Boolean

            Dim Value As Boolean = False

            If GetStringConfigSetting(Setting.ToString().ToLower()) = "true" Then Value = True

            Return Value

        End Function
        Public Function GetStringConfigSetting(ByVal Setting As StringWebConfigSetting) As String

            Return GetStringConfigSetting(Setting.ToString())

        End Function
        Public Function GetStringConfigSetting(ByVal Setting As String) As String

            Dim Value As String = ""
            Dim rootWebConfig1 As System.Configuration.Configuration

            rootWebConfig1 = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(Nothing)

            If (rootWebConfig1.AppSettings.Settings.Count > 0) Then

                Dim customSetting As System.Configuration.KeyValueConfigurationElement
                customSetting = rootWebConfig1.AppSettings.Settings(Setting.ToString())

                If customSetting.Value IsNot Nothing Then Value = customSetting.Value

            End If

            Return Value

        End Function

        Public Sub ThrowNewDataServiceException(ByRef [Exception] As Exception)

            Dim sb As New System.Text.StringBuilder
            Dim EventLog As EventLog = Nothing

            Try

                If [Exception] IsNot Nothing Then

                    EventLog = New EventLog(_EventLogName)

                    If EventLog IsNot Nothing Then

                        EventLog.Source = _EventSource
                        If [Exception].Message IsNot Nothing Then

                            sb.Append([Exception].Message.ToString())

                        End If

                        If [Exception].InnerException IsNot Nothing AndAlso [Exception].Message.ToString() <> [Exception].InnerException.Message.ToString() Then

                            sb.Append(Environment.NewLine)
                            sb.Append([Exception].InnerException.Message.ToString())

                        End If

                        EventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error)

                    End If

                    'Throw New DataServiceException(500, [Exception].Message.ToString())

                End If

            Catch ex As Exception

            Finally

                sb = Nothing
                EventLog = Nothing

            End Try

        End Sub
        Public Sub AddToEventLog(ByVal Message As String, Optional ByVal EntryType As EventLogEntryType = EventLogEntryType.Information)
            Try

                Dim EventLog As EventLog = Nothing

                EventLog = New EventLog(_EventLogName)

                If EventLog IsNot Nothing Then

                    Select Case EntryType
                        Case EventLogEntryType.Error
                            EventLog.Source = _ErrorEventSource
                        Case EventLogEntryType.Information, EventLogEntryType.SuccessAudit
                            EventLog.Source = _EventSource
                        Case EventLogEntryType.Warning, EventLogEntryType.FailureAudit
                            EventLog.Source = _WarningEventSource
                    End Select

                    EventLog.WriteEntry(Message, EntryType, 9000 + CType(EntryType, Integer))

                End If

            Catch ex As Exception

            End Try
        End Sub
        Public Sub ErrorToEventLog(ByVal [Exception] As Exception)
            Try

                If [Exception] IsNot Nothing Then

                    Dim sb As New System.Text.StringBuilder
                    Dim EventLog As EventLog = Nothing

                    EventLog = New EventLog(_EventLogName)

                    If EventLog IsNot Nothing Then

                        EventLog.Source = _ErrorEventSource

                        If String.IsNullOrWhiteSpace([Exception].Message) = False Then

                            sb.Append("Exception Message:  ")
                            sb.Append(Environment.NewLine)
                            sb.Append([Exception].Message.ToString())

                        End If
                        If [Exception].InnerException IsNot Nothing AndAlso
                            String.IsNullOrWhiteSpace([Exception].InnerException.Message) Then

                            sb.Append(Environment.NewLine)
                            sb.Append(Environment.NewLine)
                            sb.Append("Inner Exception Message:  ")
                            sb.Append([Exception].InnerException.Message.ToString())

                        End If

                        Try

                            Dim st As StackTrace = New StackTrace([Exception])

                            If st IsNot Nothing Then

                                Dim sf As StackFrame = st.GetFrame(st.FrameCount - 1)

                                If sf IsNot Nothing Then

                                    Dim m As MethodBase = sf.GetMethod

                                    If m IsNot Nothing Then

                                        sb.Append(Environment.NewLine)

                                        If String.IsNullOrWhiteSpace(sf.GetFileName) = False Then

                                            sb.Append(Environment.NewLine)
                                            sb.Append("In file:  ")
                                            sb.Append(sf.GetFileName)

                                        End If
                                        If String.IsNullOrWhiteSpace(m.Name) = False Then

                                            sb.Append(Environment.NewLine)
                                            sb.Append("In method:  ")
                                            sb.Append(m.Name)

                                        End If
                                        If sf.GetFileLineNumber > 0 Then

                                            sb.Append(Environment.NewLine)
                                            sb.Append("At line:  ")
                                            sb.Append(sf.GetFileLineNumber.ToString())

                                        End If

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                        EventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error, 9000)

                    End If

                End If

            Catch ex As Exception
            End Try
        End Sub
        Public Sub DebugMessageToEventLog(ByVal Message As String)
#If DEBUG Then
            Try

                Dim EventLog As EventLog = Nothing

                EventLog = New EventLog(_EventLogName)

                If EventLog IsNot Nothing Then

                    EventLog.Source = _DebugEventSource
                    EventLog.WriteEntry(Message, EventLogEntryType.Information, 9000)

                End If

            Catch ex As Exception

            End Try
#End If
        End Sub

        Public Function GetSearchType(ByVal SearchValue As String, ByRef JobNumber As Integer, ByRef JobComponentNumber As Short) As SearchFor

            Dim sf As SearchFor = SearchFor.Standard
            JobNumber = 0
            JobComponentNumber = 0

            If SearchValue.Trim() = "" Then

                sf = SearchFor.None

            Else

                If IsNumeric(SearchValue) = True Then

                    JobNumber = CType(SearchValue, Integer)
                    sf = SearchFor.JobNumber

                Else

                    If SearchValue.Contains("/") = True Then

                        Dim ar() As String
                        ar = SearchValue.Split("/")

                        Select Case ar.Length
                            Case 1

                                If IsNumeric(ar(0)) = True Then

                                    JobNumber = CType(ar(0), Integer)
                                    sf = SearchFor.JobNumber

                                End If

                            Case 2

                                If IsNumeric(ar(0)) = True Then

                                    JobNumber = CType(ar(0), Integer)
                                    sf = SearchFor.JobNumber

                                End If

                                If IsNumeric(ar(1)) = True Then

                                    JobComponentNumber = CType(ar(1), Short)
                                    sf = SearchFor.JobNumberAndJobComponentNumber

                                End If

                            Case Else

                                sf = SearchFor.Standard

                        End Select

                    End If

                End If

            End If

            Return sf

        End Function

#End Region

    End Module

End Namespace
