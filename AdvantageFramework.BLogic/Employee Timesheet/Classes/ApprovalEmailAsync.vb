Imports System.Threading
Namespace EmployeeTimesheet

    <Serializable()>
    Public Class ApprovalEmailAsync

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Session
        Private _Alert As AdvantageFramework.Database.Entities.Alert
        Private _EmployeeCode As String

#End Region

#Region " Properties "

        'Public Property ErrorMessage As String = String.Empty
        Public Property StartOfWeekDate As Nullable(Of Date)
        Public Property IsSubmittingEntireWeek As Boolean = False
        Public Property SingleSubmitDate As Nullable(Of Date)

        Public Property CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity = Nothing
        Public Property ImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing

#End Region

#Region " Methods "

        Public Sub Send()

            CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

            If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                Try

                    CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)

                Catch ex As Exception
                    CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                End Try

            End If

            Dim SendThreadStart As New ParameterizedThreadStart(AddressOf SendAsync)
            Dim SendThread As New Thread(SendThreadStart)

            SendThread.Start()

        End Sub

        Private Sub SendAsync()

            Try

                Dim ErrorMessage As String = String.Empty
                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                Dim SubjectDate As Date = Nothing

                If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                    ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    If DbContext.Database.SqlQuery(Of Short)("SELECT ISNULL(AUTO_ALERT_SUPER, 0) FROM AGENCY WITH(NOLOCK);").FirstOrDefault() = 1 Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        If IsSubmittingEntireWeek = True AndAlso StartOfWeekDate IsNot Nothing Then

                            SubjectDate = CType(StartOfWeekDate, Date)

                        End If
                        If IsSubmittingEntireWeek = False AndAlso SingleSubmitDate IsNot Nothing Then

                            SubjectDate = CType(SingleSubmitDate, Date)

                        End If

                        _Alert = New AdvantageFramework.Database.Entities.Alert

                        _Alert.AlertTypeID = 3
                        _Alert.AlertCategoryID = 43

                        If IsSubmittingEntireWeek = False Then

                            _Alert.Subject = "Timesheet Approval Request for " & Employee.ToString & " for " & SubjectDate.ToShortDateString()

                        Else

                            _Alert.Subject = "Timesheet Approval Request for " & Employee.ToString & " for week of " & SubjectDate.ToShortDateString()

                        End If

                        _Alert.Body = WriteTimesheetSuperviorApprovalLink(DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(WEBVANTAGE_URL, '') FROM AGENCY WITH(NOLOCK);").FirstOrDefault(),
                                                                          SubjectDate.ToShortDateString,
                                                                          _EmployeeCode,
                                                                          IsSubmittingEntireWeek)
                        _Alert.GeneratedDate = System.DateTime.Now
                        _Alert.PriorityLevel = 3
                        _Alert.EmployeeCode = _EmployeeCode
                        _Alert.AlertLevel = ""
                        _Alert.UserCode = DbContext.UserCode

                        If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, _Alert) = True Then

                            If AdvantageFramework.AlertSystem.AddAlertRecipient(DbContext, _Alert.ID, Employee.SupervisorEmployeeCode) = True Then

                                AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(_SecuritySession, _Alert, "[New Alert] ", Nothing, Nothing, "Timesheet", ErrorMessage:=ErrorMessage)

                            End If

                        End If

                    End If

                End Using

                If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                    ImpersonationContext.Undo()

                End If

            Catch ex As Exception

            End Try

        End Sub

        Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session,
                ByVal EmployeeCode As String)

            _SecuritySession = SecuritySession
            _EmployeeCode = EmployeeCode

        End Sub

#End Region

    End Class

End Namespace