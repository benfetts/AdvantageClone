Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Text
Imports System.IO
Imports Webvantage
Imports System.Net
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports DevExpress.Web
Imports HtmlAgilityPack
Imports System.Collections.Generic

Partial Public Class Alert_View
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Public Shared AutoCompleteAlertID As Integer = 0
    Private Const TruncateLength As Integer = 200

    Private CurrentAlert As Alert

    Private _DeepLink As AdvantageFramework.Web.DeepLink = Nothing
    Private Property CurrentAlertID As Integer
        Get
            If ViewState("CurrentAlertID") Is Nothing Then ViewState("CurrentAlertID") = 0
            Return CType(ViewState("CurrentAlertID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("CurrentAlertID") = value
            Alert_View.AutoCompleteAlertID = value
        End Set
    End Property
    Private CurrentAlertTypeId As Integer = 0
    Private CurrentAlertCategoryId As Integer = 0
    Private CurrentAlertLevel As String = ""

    Private accessPrivate As Integer = 0

    Private strEmails As String = ""
    Private strEmailsCP As String = ""

    Private EmployeeCodesForEmail As String = ""
    Private EmployeeCodeOfAlertAssignment As String = ""
    Private ClientPortalIDsForEmail As String = ""

    Private DesktopTabNum As Integer = -1

    Private SelectedAlertType As String = ""
    Private SelectedAlertCategory As String = ""

    Public FromApp As MiscFN.Source_App
    Private FromJobNumber As Integer = 0
    Private FromJobComponentNbr As Integer = 0
    Private FromJobJacket As Boolean = False
    Private FromProjectSchedule As Integer = 0
    Private FromTaskSeqNbr As Integer = -1

    Private CurrAssignEmp As String = ""
    Private CurrentUserIsAssignEmp As Boolean = False

    Private IsDismissed As Boolean = False

    Private AlertFolder As String = "Inbox"

    Private EmpCodeFromFilter As String = ""

    Private VersionId As Integer = 0
    Private BuildId As Integer = 0

    Private GroupSettingsAlertInboxShowAllAssignments As Boolean = False
    Private GroupSettingsAlertInboxShowUnassignedAssignments As Boolean = False
    Private NoAccess As Boolean = False '?

    Private ClientPortalUserHasAccess As Boolean = False

    Private _DocumentList As New Generic.List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument)

    Private _IsAlertAssignmentCC As Boolean = False

    Private _IsMyAlert_Open As Boolean = False
    Private _IsMyAlert_Dismissed As Boolean = False
    Private _IsMyAssignment_Open As Boolean = False
    Private _IsMyAssignment_Completed As Boolean = False

    Private DocumentUploadedWithComment As Boolean = False
    Private _AddAttachmentComment As Boolean = False

    Private _ConnectionString As String = ""
    Private _UserCode As String = ""
    Private _ClientPortalID As String = ""
    Private _EmployeeCode As String = ""
    Private _AddComment As Integer = 0

    Protected WithEvents LabelApproved As Global.System.Web.UI.WebControls.Label
    Protected WithEvents LabelDismissed As Global.System.Web.UI.WebControls.Label
    Protected WithEvents LabelCompleted As Global.System.Web.UI.WebControls.Label

#End Region

#Region " Properties "

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Property ClientCode As String
        Get
            If ViewState("ClientCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ClientCode")
            End If
        End Get
        Set(value As String)
            ViewState("ClientCode") = value
        End Set
    End Property
    Private Property DivisionCode As String
        Get
            If ViewState("DivisionCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("DivisionCode")
            End If
        End Get
        Set(value As String)
            ViewState("DivisionCode") = value
        End Set
    End Property
    Private Property ProductCode As String
        Get
            If ViewState("ProductCode") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ProductCode")
            End If
        End Get
        Set(value As String)
            ViewState("ProductCode") = value
        End Set
    End Property
    Private Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then ViewState("JobNumber") = 0
            Return CType(ViewState("JobNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Private Property JobComponentNumber As Integer
        Get
            If ViewState("JobComponentNumber") Is Nothing Then ViewState("JobComponentNumber") = 0
            Return CType(ViewState("JobComponentNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("JobComponentNumber") = value
        End Set
    End Property
    Private ReadOnly Property ShowFullComments As Boolean
        Get
            Try
                Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
                AppVars.getAllAppVars()
                Return AppVars.getAppVar("ShowFullComments", "boolean", "false").ToString().ToLower() = "true"
                If AppVars.getAppVar("ShowFullComments", "boolean", "false").ToString().ToLower() = "true" Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Private Property RoutedAssignment As Boolean
        Get
            If ViewState("RoutedAssignment") Is Nothing Then ViewState("RoutedAssignment") = False
            Return CType(ViewState("RoutedAssignment"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("RoutedAssignment") = value
        End Set
    End Property
    Private Property MyRoutedAssignment As Boolean
        Get
            If ViewState("MyRoutedAssignment") Is Nothing Then ViewState("MyRoutedAssignment") = False
            Return CType(ViewState("MyRoutedAssignment"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("MyRoutedAssignment") = value
        End Set
    End Property

    Private Property CloseAfterCommentOrReAssign As Boolean
        Get
            Try
                Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
                AppVars.getAllAppVars()
                Return AppVars.getAppVar("CloseAfterCommentOrReAssign", "boolean", "false").ToString().ToLower() = "true"
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Try
                Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)
                av.getAllAppVars()
                av.setAppVar("CloseAfterCommentOrReAssign", value, "Boolean")
                av.SaveAllAppVars()
            Catch ex As Exception
            End Try
        End Set
    End Property

    'Private ReadOnly Property CloseAfterComment As Boolean
    '    Get
    '        Try
    '            Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
    '            AppVars.getAllAppVars()
    '            Return AppVars.getAppVar("CloseAfterComment", "boolean", "false").ToString().ToLower() = "true"
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    End Get
    'End Property
    'Private ReadOnly Property CloseAfterReassign As Boolean
    '    Get
    '        Try
    '            Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
    '            AppVars.getAllAppVars()
    '            Return AppVars.getAppVar("CloseAfterReassign", "boolean", "false").ToString().ToLower() = "true"
    '        Catch ex As Exception
    '            Return False
    '        End Try
    '    End Get
    'End Property

    Public Shared ReadOnly Property DefaultInfoSectionCollapsed As Boolean
        Get
            Try
                Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
                AppVars.getAllAppVars()
                Return AppVars.getAppVar("DefaultInfoSectionCollapsed", "boolean", "false").ToString().ToLower() = "true"
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Private Property _CommentFromToolbar As Boolean
        Get
            If Not ViewState("_CommentFromToolbar") Is Nothing Then
                Return CType(ViewState("_CommentFromToolbar"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("_CommentFromToolbar") = value
        End Set
    End Property
    Private Property IsAlertAssignment As Boolean
        Get
            If Not ViewState("IsAlertAssignment") Is Nothing Then
                Return CType(ViewState("IsAlertAssignment"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsAlertAssignment") = value
        End Set
    End Property
    Private Property IsWorkItem As Boolean
        Get
            If Not ViewState("IsWorkItem") Is Nothing Then
                Return CType(ViewState("IsWorkItem"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsWorkItem") = value
        End Set
    End Property
    Private Property IsApproval As Boolean
        Get
            If Not ViewState("IsApproval") Is Nothing Then
                Return CType(ViewState("IsApproval"), Boolean)
            Else
                Return False
            End If
        End Get
        Set(value As Boolean)
            ViewState("IsApproval") = value
        End Set
    End Property

    Private ReadOnly Property IsProofHQEnabled As Boolean
        Get
            If ViewState("IsProofHQEnabled") Is Nothing Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me._ConnectionString, Me._UserCode)

                    Dim PHQ As Boolean = False

                    If Me.IsClientPortal = False Then

                        PHQ = AdvantageFramework.ProofHQ.IsProofHQEnabled(DataContext)

                    End If

                    ViewState("IsProofHQEnabled") = PHQ

                End Using

            End If
            Return ViewState("IsProofHQEnabled")
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadToolbarAlertView_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAlertView.ButtonClick

        Dim PromptForFullCompleteTask As Boolean = False
        Dim PromptForTempCompleteTask As Boolean = False
        Dim s As String = String.Empty

        Select Case e.Item.Value
            Case "CloseAlert"
                Try
                    Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
                    If rtb IsNot Nothing Then Me.CloseAfterCommentOrReAssign = rtb.Checked
                Catch ex As Exception
                End Try

            Case "Save"

                If Me.UpdateInformation(True) = True And Me.CurrentAlertID > 0 Then

                    Me.AutoCompleteRecipients.Entries.Clear()
                    Me.LoadAlert()
                    'Me.RefreshByRedirect()

                End If

            Case "ClientContacts"

                Try

                    Dim qs As New AdvantageFramework.Web.QueryString

                    qs.Page = "popContacts.aspx"
                    qs.Add("from", "newalert")
                    If String.IsNullOrEmpty(Me.ClientCode) = False Then

                        qs.ClientCode = Me.ClientCode

                        If String.IsNullOrEmpty(Me.DivisionCode) = False Then

                            qs.DivisionCode = Me.DivisionCode

                            If String.IsNullOrEmpty(Me.ProductCode) = False Then

                                qs.ProductCode = Me.ProductCode

                            End If

                        End If

                    End If
                    If Me.JobNumber > 0 Then

                        qs.JobNumber = Me.JobNumber

                        If Me.JobComponentNumber > 0 Then

                            qs.JobComponentNumber = Me.JobComponentNumber

                        End If
                    End If

                    Me.OpenWindow("Contacts", qs.ToString(True), 1200, 400)

                Catch ex As Exception
                End Try

            Case "AlertRecipients"

                If Me.UpdateInformation(False) = False Then Exit Sub
                If Me.AlertRecipients(True, False) = False Then Exit Sub

                If Me.CloseAfterCommentOrReAssign = False Then

                    Me.RadEditorAssignmentComment.Content = Nothing
                    Me.LoadAlert()
                    Me.RefreshAlertWindows(False)
                    Me.RefreshDashboardAlerts()

                Else

                    Me.CloseRefreshAction()

                End If

            Case "AddComment"

                If Me.UpdateInformation(False) = False Then Exit Sub
                Me._CommentFromToolbar = True

            Case "Approve"

                addCommentApproval(True)

                Dim Succeeded As Boolean = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Succeeded = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Me.CurrentAlertID, HttpContext.Current.Session("EmpCode"), _Session.UserCode, Me._ClientPortalID, False,
                                                                            PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                    If Succeeded = True Then

                        If Me.UpdateInformation(False) = False Then Exit Sub
                        If Me.AlertRecipients(True) = False Then Exit Sub

                        If Me.CloseAfterCommentOrReAssign = False Then

                            Me.RadEditorAssignmentComment.Content = Nothing
                            Me.LoadAlert()
                            Me.RefreshAlertWindows(False)

                        Else

                            Me.CloseRefreshAction()

                        End If

                    End If

                End Using

            Case "Deny"

                addCommentApproval(False)

                Dim Succeeded As Boolean = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Succeeded = AdvantageFramework.AlertSystem.DismissAlert(DbContext, Me.CurrentAlertID, HttpContext.Current.Session("EmpCode"), _Session.UserCode, Me._ClientPortalID, False,
                                                                            PromptForFullCompleteTask, PromptForTempCompleteTask, s)

                    If Succeeded = True Then

                        If Me.UpdateInformation(False) = False Then Exit Sub
                        If Me.AlertRecipients(True) = False Then Exit Sub

                        If Me.CloseAfterCommentOrReAssign = False Then

                            Me.RadEditorAssignmentComment.Content = Nothing
                            Me.LoadAlert()
                            Me.RefreshAlertWindows(False)

                        Else

                            Me.CloseRefreshAction()

                        End If

                    End If

                End Using

            Case "Print"

                If Me.UpdateInformation(False) = False Then Exit Sub
                Me.AddJavascriptToPage("window.open('Alert_Html.aspx?a=" & Me.CurrentAlertID.ToString() & "', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=780,height=800,scrollbars=yes,resizable=yes,menubar=no,maximazable=yes');return false;")

            Case "RadToolBarSplitButtonCopy"

                If Me.IsAlertAssignment = True And Me.IsClientPortal = False Then

                    Me.OpenWindow("", "Alert_New.aspx?assn=1&AID=" & Me.CurrentAlertID)

                Else

                    Me.OpenWindow("", "Alert_New.aspx?assn=0&AID=" & Me.CurrentAlertID)

                End If

            Case "CopyAsAssignment"

                Me.OpenWindow("", "Alert_New.aspx?assn=1&AID=" & Me.CurrentAlertID)

            Case "CopyAsStandardAlert"

                Me.OpenWindow("", "Alert_New.aspx?assn=0&AID=" & Me.CurrentAlertID)

            Case "Dismiss"

                If Me.UpdateInformation(False) = False Then Exit Sub

                Dim FromPS As Integer = 0
                Dim JobNumber As Integer = 0
                Dim JobComponentNbr As Integer = 0

                Try
                    If Not Request.QueryString("ps") Is Nothing Then
                        If IsNumeric(Request.QueryString("ps")) = True Then
                            FromPS = CType(Request.QueryString("ps"), Integer)
                        End If
                    End If
                Catch ex As Exception
                    FromPS = 0
                End Try

                If Me.CurrentQuerystring.JobNumber > 0 Then JobNumber = Me.CurrentQuerystring.JobNumber
                If Me.CurrentQuerystring.JobComponentNumber > 0 Then JobComponentNbr = Me.CurrentQuerystring.JobComponentNumber

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Me.RadToolbarAlertView.FindItemByValue("Dismiss").Text.ToLower() = "dismiss" Then

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, Me.CurrentAlertID, Session("EmpCode"), Session("UserCode"), Me._ClientPortalID, False,
                                                                           PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If PromptForFullCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = CurrentAlertID
                                        .Add("complete", 0)
                                        .Add("IsTempComplete", 0)

                                    End With

                                    Me.OpenWindow(QueryString, Height:=250, Width:=500, IsModal:=True)

                                ElseIf PromptForTempCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = CurrentAlertID
                                        .Add("complete", 0)
                                        .Add("IsTempComplete", 1)

                                    End With

                                    Me.OpenWindow(QueryString, Height:=250, Width:=500, IsModal:=True)

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        Else

                            Dim a As New cAlerts()
                            a.UnDismissAlert(Me.CurrentAlertID, Me.IsClientPortal, Me._ClientPortalID)

                            If Me.AlertRecipients(True) = False Then Exit Sub

                        End If

                        If Me.UpdateInformation(False) = False Then Exit Sub

                        If Me.CloseAfterCommentOrReAssign = False Then

                            Me.RadEditorAssignmentComment.Content = Nothing
                            Me.LoadAlert()
                            Me.RefreshAlertWindows(False)
                            Me.RefreshDashboardAlerts()

                        Else

                            Me.CloseRefreshAction()

                        End If

                    End Using

                Catch ex As Exception

                    Me.ShowMessage("Could not dismiss alert.\nPlease check the repository settings.\n" & ex.Message.ToString())

                End Try

            Case "Complete"

                If Me.UpdateInformation(False) = False Then Exit Sub

                Dim FromPS As Integer = 0
                Dim JobNumber As Integer = 0
                Dim JobComponentNbr As Integer = 0
                Try
                    If Not Request.QueryString("ps") Is Nothing Then
                        If IsNumeric(Request.QueryString("ps")) = True Then
                            FromPS = CType(Request.QueryString("ps"), Integer)
                        End If
                    End If
                Catch ex As Exception
                    FromPS = 0
                End Try

                If Me.CurrentQuerystring.JobNumber > 0 Then JobNumber = Me.CurrentQuerystring.JobNumber
                If Me.CurrentQuerystring.JobComponentNumber > 0 Then JobComponentNbr = Me.CurrentQuerystring.JobComponentNumber

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Me.RadToolbarAlertView.FindItemByValue("Complete").Text.ToLower() = "complete" Then

                            If AdvantageFramework.AlertSystem.DismissAlert(DbContext, Me.CurrentAlertID, Session("EmpCode"), Session("UserCode"), Me._ClientPortalID, True,
                                                                           PromptForFullCompleteTask, PromptForTempCompleteTask, s) = True Then

                                If PromptForFullCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = CurrentAlertID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 0)

                                    End With

                                    Me.OpenWindow(QueryString, Height:=250, Width:=500, IsModal:=True)

                                ElseIf PromptForTempCompleteTask = True Then

                                    Dim QueryString As New AdvantageFramework.Web.QueryString
                                    With QueryString

                                        .Page = "TrafficSchedule_ConfirmCompleteAlert.aspx"
                                        .AlertID = CurrentAlertID
                                        .Add("complete", 1)
                                        .Add("IsTempComplete", 1)

                                    End With

                                    Me.OpenWindow(QueryString, Height:=250, Width:=500, IsModal:=True)

                                End If

                            Else

                                If String.IsNullOrWhiteSpace(s) = False Then Me.ShowMessage(s)

                            End If

                        Else

                            Dim a As New cAlerts()
                            a.UnDismissAlert(Me.CurrentAlertID, Me.IsClientPortal, Me._ClientPortalID, True)
                            If Me.AlertRecipients(True) = False Then Exit Sub

                        End If

                        If Me.UpdateInformation(False) = False Then Exit Sub

                        If Me.CloseAfterCommentOrReAssign = False Then

                            Me.RadEditorAssignmentComment.Content = Nothing
                            Me.LoadAlert()
                            Me.RefreshAlertWindows(False)

                        Else

                            Me.CloseRefreshAction()

                        End If

                    End Using

                Catch ex As Exception
                    Me.ShowMessage("Could not complete assignment.\nPlease check the repository settings.\n" & ex.Message.ToString())
                End Try

            'Case "ShowFullComments"

            '    Me.ShowFullComments = CType(Me.RadToolbarAlertView.FindItemByValue("ShowFullComments"), RadToolBarButton).Checked.ToString()
            '    Dim qs As New AdvantageFramework.Web.QueryString()
            '    qs.PassThroughTo("Alert_View.aspx")

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me._ConnectionString, Me._UserCode)
                Dim qs As New AdvantageFramework.Web.QueryString()
                Dim Subject As String = Me.TxtSubject.Text.Trim()
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                If String.IsNullOrWhiteSpace(Subject) = True Then

                    Subject = Me.LabelSubject.Text.Trim()

                End If

                qs = qs.FromCurrent()

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.CurrentAlertID)

                End Using

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Alerts
                    .UserCode = Me._UserCode
                    .Name = String.Format("{0}: {1} {2}", If(Alert.IsWorkItem.GetValueOrDefault(False), "Assignment", "Alert"), Me.CurrentAlertID, Subject)
                    .PageURL = "Alert_View.aspx" & qs.ToString()
                    .Description = Subject

                End With

                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "StartStopwatch"
                Dim ThisTaskSeqNbr As Integer = -1

                If IsNumeric(Me.HiddenFieldJobNumber.Value) = True Then Me.JobNumber = CType(Me.HiddenFieldJobNumber.Value, Integer)
                If IsNumeric(Me.HiddenFieldJobComponentNbr.Value) = True Then Me.JobComponentNumber = CType(Me.HiddenFieldJobComponentNbr.Value, Integer)
                If IsNumeric(Me.HiddenFieldTaskSeqNbr.Value) = True Then ThisTaskSeqNbr = CType(Me.HiddenFieldTaskSeqNbr.Value, Integer)

                If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                    If AdvantageFramework.Timesheet.Methods.StopwatchStart(Me._ConnectionString, Me._UserCode, Me._EmployeeCode, Me.JobNumber, Me.JobComponentNumber, ThisTaskSeqNbr, Me.CurrentAlertID, s) = True Then

                        Me.CheckForStopwatch()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            Case "AddTime"

                Dim ThisTaskSeqNbr As Integer = -1
                Dim alert As AdvantageFramework.Database.Entities.Alert = Nothing
                Dim empnontask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing

                If IsNumeric(Me.HiddenFieldJobNumber.Value) = True Then Me.JobNumber = CType(Me.HiddenFieldJobNumber.Value, Integer)
                If IsNumeric(Me.HiddenFieldJobComponentNbr.Value) = True Then Me.JobComponentNumber = CType(Me.HiddenFieldJobComponentNbr.Value, Integer)
                If IsNumeric(Me.HiddenFieldTaskSeqNbr.Value) = True Then ThisTaskSeqNbr = CType(Me.HiddenFieldTaskSeqNbr.Value, Integer)

                If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Dim EmpTaskCount As Integer = 0

                    Try

                        EmpTaskCount = SqlHelper.ExecuteScalar(Me._ConnectionString, CommandType.Text, "SELECT COUNT(1) FROM JOB_TRAFFIC_DET_EMPS WHERE JOB_NUMBER = " &
                                                                 Me.JobNumber & " AND JOB_COMPONENT_NBR = " & Me.JobComponentNumber &
                                                                 " AND SEQ_NBR = " & ThisTaskSeqNbr & " AND EMP_CODE = '" & Me._EmployeeCode & "';")

                    Catch ex As Exception

                        EmpTaskCount = 0

                    End Try

                    If ThisTaskSeqNbr = -1 Or EmpTaskCount = 0 Then 'open the regular add time window

                        'With qs

                        '    .Page = "Timesheet_CommentsView.aspx"
                        '    .Add("Type", "New")
                        '    .Add("single", "1")
                        '    .JobNumber = Me.JobNumber
                        '    .JobComponentNbr = Me.JobComponentNumber
                        '    If CurrentAlertID > 0 Then
                        '        .AlertId = Me.CurrentAlertID
                        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        '            alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, CurrentAlertID)
                        '            If alert IsNot Nothing AndAlso alert.NonTaskID IsNot Nothing Then
                        '                empnontask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, alert.NonTaskID)
                        '            End If
                        '            If empnontask IsNot Nothing Then
                        '                .Add("caller", "Calendar_NewActivity")
                        '                .FunctionCode = empnontask.FunctionCode
                        '            Else
                        '                .Add("caller", "AlertView")
                        '            End If
                        '        End Using
                        '    Else
                        '        .Add("caller", "AlertView")
                        '    End If

                        'End With
                        Dim URL As String

                        URL = String.Format("Employee/Timesheet/Entry?a={0}&j={1}&jc={2}&s={3}",
                                            Me.CurrentAlertID.ToString,
                                            Me.JobNumber.ToString,
                                            Me.JobComponentNumber.ToString,
                                            ThisTaskSeqNbr.ToString)

                        Me.OpenWindow("Add Time", URL, 600, 600)

                    Else 'open the task time window

                        With qs

                            .Page = "Timesheet_QuickAdd.aspx"
                            .Add("tasklistDO", "1")
                            .Add("JobNum", Me.JobNumber)
                            .Add("JobComp", Me.JobComponentNumber)
                            .Add("Seq", ThisTaskSeqNbr)
                            .Add("TaskEmp", Me._EmployeeCode)

                            .AlertID = Me.CurrentAlertID
                            .JobNumber = Me.JobNumber
                            .JobComponentNumber = Me.JobComponentNumber
                            .TaskSequenceNumber = ThisTaskSeqNbr
                            .EmployeeCode = Me._EmployeeCode

                        End With

                        Me.OpenWindow("", qs.ToString(True))

                    End If


                End If
            Case "ViewComments"

                If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then

                    Me.OpenWindow("Comments for Job:  " & Me.JobNumber.ToString().PadLeft(6, "0") & " - " & Me.JobComponentNumber.ToString().PadLeft(2, "0"), "JobComponent_Comments.aspx?a=0&j=" & Me.JobNumber.ToString() & "&jc=" & Me.JobComponentNumber.ToString(), 450, 710, False, True)

                End If

            Case "AddAttachment"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_AddAttachments.aspx"
                qs.AlertID = Me.CurrentAlertID

                Me.OpenWindow("Add Attachment", qs.ToString(True), 400, 500, False, False, "")

            Case "Settings"

                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Alert_Settings.aspx"

                Me.OpenWindow(qs)

        End Select

    End Sub

    Private Function CheckCompleteProjectScheduleAlert(ByVal AlertID As Integer, ByVal Complete As Boolean) As Boolean

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Return AdvantageFramework.ProjectSchedule.MarkTaskCompleteOnAlertDismissed(DbContext, Session("UserCode"), Session("EmpCode"), AlertID, Complete)

            End Using

        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub LBtnJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnJob.Click
        Try

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "JobTemplate_Search.aspx"
            qs.JobNumber = CurrentAlert.JOB_NUMBER
            qs.Add("f", "2")
            qs.Add("l", "2")

            Me.OpenWindow(qs)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub LBtnJobComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnJobComponent.Click
        Try

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.Page = "Content.aspx"
            qs.JobNumber = CurrentAlert.JOB_NUMBER
            qs.JobComponentNumber = CurrentAlert.JOB_COMPONENT_NBR
            qs.Add("FromAlert", "AlertView")
            qs.Add("PageMode", "Edit")
            qs.Add("NewComp", "0")

            Me.OpenWindow(qs)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub LinkButton_ATB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton_ATB.Click
        Try

            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByID(DbContext, CurrentAlert.ATB_REV_ID)

            End Using

            Me.OpenWindow("", Webvantage.Media_ATB.GenerateBaseQueryString(MediaATBRevision.ATBNumber, MediaATBRevision.RevisionNumber, False))

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadListViewAttachments_ItemCommand(sender As Object, e As RadListViewCommandEventArgs) Handles RadListViewAttachments.ItemCommand

        Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim URL As String = ""
        Dim ThisItem As RadListViewDataItem = e.ListViewItem

        Select Case e.CommandName
            Case "Download"

                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)

            Case "DeleteRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString.ToString(), Me._UserCode.ToString())

                    Dim FileDeleted As Boolean = False
                    Dim RecordDeleted As Boolean = False

                    AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, ThisItem.GetDataKeyValue("ATTACHMENT_ID"))

                    If AlertAttachment IsNot Nothing Then

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                        If Document IsNot Nothing Then

                            Dim DeleteFromRepository As Boolean = False
                            Dim DocumentRepository As DocumentRepository = Nothing
                            Dim DeletedFromAlert As Boolean = False

                            DocumentRepository = New DocumentRepository(Me._ConnectionString)

                            If Document.FileSystemFileName.StartsWith("a_") Then

                                DeleteFromRepository = True

                            End If

                            If DeleteFromRepository = True Then

                                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

                                If IsNTAuth = True Then

                                    currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                                    impersonationContext = currentWindowsIdentity.Impersonate()

                                End If

                                FileDeleted = DocumentRepository.DeleteDocument(Document.ID, Document.FileSystemFileName)

                                If IsNTAuth = True Then

                                    impersonationContext.Undo()
                                    impersonationContext.Dispose()
                                    currentWindowsIdentity.Dispose()

                                End If

                                If FileDeleted Then

                                    If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                        For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                            AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                        Next

                                        AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                                    End If

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, AlertAttachment) Then

                                    For Each DocumentAlertAttachment In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                        AdvantageFramework.Database.Procedures.AlertAttachment.Delete(DbContext, DocumentAlertAttachment)

                                    Next

                                End If

                            End If

                        End If

                    End If

                End Using

                Me.RadListViewAttachments.Rebind()

            Case "ProofHQLink"

                Me.AddJavascriptToPage(String.Format("window.open('{0}', '_blank');", e.CommandArgument))

            Case "ProofHQUpload"

                If IsNumeric(e.CommandArgument) AndAlso CLng(e.CommandArgument) > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me._ConnectionString, Me._UserCode)

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, ThisItem.GetDataKeyValue("ATTACHMENT_ID"))

                            If Agency IsNot Nothing AndAlso AlertAttachment IsNot Nothing Then

                                UploadDocumentToProofHQ(DbContext, DataContext, e.CommandArgument, AlertAttachment.AlertID, Agency)

                            End If

                            Me.RadListViewAttachments.Rebind()
                            'Me.LoadAlert()
                            'Me.LoadLinkableDocuments()

                        End Using

                    End Using

                End If

            Case "ShowHistory"

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString.ToString(), Me._UserCode.ToString())

                    AlertAttachment = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertAttachmentID(DbContext, ThisItem.GetDataKeyValue("ATTACHMENT_ID"))

                    If AlertAttachment IsNot Nothing Then

                        URL = "Documents_History.aspx?Level=AT&FK=" & AlertAttachment.AlertID & "&filename=" & e.CommandArgument

                    End If

                End Using

                If String.IsNullOrWhiteSpace(URL) = False Then

                    Me.OpenWindow("Document History", URL)

                End If

            Case "SignDocument"

                If SignDocument(CInt(e.CommandArgument)) Then

                    Me.RadListViewComments.Rebind()

                End If

        End Select
    End Sub
    Private Sub RadListViewAttachments_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewAttachments.ItemDataBound

        Select Case e.Item.ItemType
            Case RadListViewItemType.DataItem, RadListViewItemType.AlternatingItem

                Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)
                Dim DataItem = ListItem.DataItem

                If ListItem IsNot Nothing AndAlso DataItem IsNot Nothing Then

                    Dim AttachmentDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivAttachment")
                    Dim FileTypeDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFileType")
                    Dim FileTypeLabel As Label = e.Item.FindControl("LabelFileType")
                    Dim CommentLinkDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivCommentLink")
                    Dim HistoryLinkDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivHistoryLink")
                    Dim DigitallySignLinkDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDigitallySignLink")
                    Dim DeleteDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDelete")

                    Dim ProofHQLinkDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivProofHQLink")
                    Dim ProofHQLinkButton As LinkButton = e.Item.FindControl("LinkButtonProofHQ")
                    Dim DigitallySignLinkButton As LinkButton = e.Item.FindControl("LinkButtonDigitallySign")
                    Dim DeleteLinkButton As LinkButton = e.Item.FindControl("LinkButtonDelete")

                    Dim FilenameDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFilename")

                    Dim Filename As String = String.Empty
                    Dim Description As String = String.Empty
                    Dim OpenJavascript As String = String.Empty

                    Dim DocumentID As Integer = DataItem("DOCUMENT_ID")
                    Dim RepositoryFilename As String = DataItem("REPOSITORY_FILENAME")
                    Dim FileSize As Integer = 0
                    Dim ProofHQURL As String = String.Empty
                    Dim IsPrivate As Boolean = False

                    If Not IsDBNull(DataItem("FILENAME")) Then

                        Filename = DataItem("FILENAME")

                    End If
                    If Not IsDBNull(DataItem("DESCRIPTION")) Then

                        Description = DataItem("DESCRIPTION")

                    End If
                    Try

                        FileSize = CType(DataItem("FILE_SIZE"), Integer)

                    Catch ex As Exception
                        FileSize = 0
                    End Try
                    Try

                        IsPrivate = DataItem("PRIVATE_FLAG") = "1"

                    Catch ex As Exception
                        IsPrivate = False
                    End Try
                    Try

                        If IsDBNull(DataItem("PROOFHQ_URL")) = False AndAlso String.IsNullOrWhiteSpace(DataItem("PROOFHQ_URL")) = False Then

                            ProofHQURL = DataItem("PROOFHQ_URL")

                        End If

                    Catch ex As Exception
                        ProofHQURL = String.Empty
                    End Try

                    ProofHQLinkDiv.Visible = False

                    Select Case DataItem("MIME_TYPE")
                        Case "URL"

                            Dim FullURL As String = String.Empty

                            If (RepositoryFilename.ToLower.StartsWith("http://") OrElse RepositoryFilename.ToLower.StartsWith("https://")) Then

                                FullURL = RepositoryFilename

                            Else

                                FullURL = "http://" + RepositoryFilename

                            End If

                            OpenJavascript = String.Format("window.open('{0}'); return false;", FullURL)

                        Case Else

                            OpenJavascript = String.Format("GetDocumentRepositoryDocument({0}); return false;", DocumentID)

                            Dim DocumentHistoryJavascript As String = String.Empty
                            Dim ViewItemURL As String = String.Empty
                            Dim DocumentHistoryQueryString As New AdvantageFramework.Web.QueryString

                            DocumentHistoryQueryString.Page = "Documents_History.aspx"
                            DocumentHistoryQueryString.Add("Level", "")
                            DocumentHistoryQueryString.Add("FK", "")
                            DocumentHistoryQueryString.Add("filename", Filename)
                            DocumentHistoryQueryString.DocumentID = DocumentID

                            DocumentHistoryJavascript = String.Format("OpenRadWindow('','{0}'); return false;", DocumentHistoryQueryString.ToString(True))

                            HistoryLinkDiv.Attributes.Add("onclick", DocumentHistoryJavascript)

                            If Filename.ToUpper.EndsWith(".PDF") Then

                                ViewItemURL = "Documents_PDFViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1&AlertID=" & Me.CurrentAlertID

                                'Show Digitally sign button

                            ElseIf Filename.ToUpper.EndsWith(".DOC") OrElse Filename.ToUpper.EndsWith(".DOCX") Then

                                ViewItemURL = "Documents_WordViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                            ElseIf Filename.ToUpper.EndsWith(".GIF") OrElse Filename.ToUpper.EndsWith(".JPEG") OrElse
                               Filename.ToUpper.EndsWith(".PJPEG") OrElse Filename.ToUpper.EndsWith(".PNG") OrElse
                               Filename.ToUpper.EndsWith(".JPG") OrElse Filename.ToUpper.EndsWith(".TIFF") OrElse
                               Filename.ToUpper.EndsWith(".BMP") Then

                                ViewItemURL = "Documents_ImageViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                            ElseIf Filename.ToUpper.EndsWith(".MSG") Then

                                ViewItemURL = "Documents_MSGViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=1"

                            ElseIf Filename.ToUpper.Contains(".XLS") OrElse Filename.ToUpper.Contains(".XLSX") Then

                                ViewItemURL = "Documents_ExcelViewer.aspx?DocumentID=" & DocumentID & "&PageNumber=0"

                            End If
                            If String.IsNullOrWhiteSpace(ViewItemURL) = False Then

                                CommentLinkDiv.Attributes.Add("onclick", HookUpOpenWindow("", ViewItemURL, 800, 1200))
                                CommentLinkDiv.Visible = True

                            Else

                                CommentLinkDiv.Visible = False

                            End If

                            If Me.IsProofHQEnabled = True Then

                                ProofHQLinkDiv.Visible = True

                                If String.IsNullOrWhiteSpace(ProofHQURL) = False Then

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ProofHQLinkDiv, "standard-green")
                                    ProofHQLinkButton.ToolTip = "Open this attachment in Proof HQ"
                                    ProofHQLinkButton.CommandName = "ProofHQLink"
                                    ProofHQLinkButton.CommandArgument = ProofHQURL

                                Else

                                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(ProofHQLinkDiv, "standard-orange")
                                    ProofHQLinkButton.ToolTip = "Upload this attachment to Proof HQ"
                                    ProofHQLinkButton.CommandName = "ProofHQUpload"
                                    ProofHQLinkButton.CommandArgument = ProofHQURL

                                End If

                            End If

                    End Select

                    'PRIVATE_FLAG

                    AdvantageFramework.Web.Presentation.Controls.SetDocumentBlock(FileTypeDiv, DataItem("MIME_TYPE"), FileTypeLabel, CommentLinkDiv,
                                                                                  Filename, FileSize, DataItem("USER_NAME"), DataItem("GENERATED_DATE"), IsPrivate)

                    FilenameDiv.Attributes.Add("onclick", OpenJavascript)
                    FileTypeDiv.Attributes.Add("onclick", OpenJavascript)

                    If IsPrivate = True Then

                        FilenameDiv.Attributes.Add("style", "font-style: italic !important;")

                    End If

                    DeleteLinkButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                    If Filename.ToUpper.EndsWith(".PDF") Then

                        DigitallySignLinkDiv.Visible = True

                    Else

                        DigitallySignLinkDiv.Visible = False

                    End If

                    Try

                        If HistoryLinkDiv IsNot Nothing Then

                            If CType(DataItem("HISTORY_COUNT"), Integer) > 1 Then

                                HistoryLinkDiv.Attributes.Add("class", "attachment-action-button standardGreen")

                            Else

                                HistoryLinkDiv.Attributes.Add("class", "attachment-action-button")

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                End If

        End Select

    End Sub
    Private Sub RadListViewAttachments_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewAttachments.NeedDataSource

        Dim oAlerts As cAlerts = New cAlerts(CStr(Me._ConnectionString))
        Dim Attachments As New DataTable

        Attachments = oAlerts.GetAlertAttachments(Me.CurrentAlertID)

        Me.RadListViewAttachments.DataSource = Attachments

        If Attachments IsNot Nothing Then

            Me.LabelCurrentAttachments.Text = "Attachments&nbsp;(" & Attachments.Rows.Count.ToString() & ")"

        End If

    End Sub



    Private Function TryToSignDocumentWithEmployeeInfo(DbContext As AdvantageFramework.Database.DbContext, Employee As AdvantageFramework.Database.Views.Employee, Document As AdvantageFramework.Database.Entities.Document, Folder As String) As Boolean

        'objects
        Dim DocumentSigned As Boolean = False
        Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
        Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
        Dim License As Aspose.Pdf.License = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
        Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing
        Dim HasBlankSignature As Boolean = False

        Try

            If Employee IsNot Nothing Then

                If Employee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.AdobeSignatureFilePassword) = False Then

                    License = New Aspose.Pdf.License

                    License.SetLicense("Aspose.Total.lic")
                    License.Embedded = True

                    Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                        Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                            Try

                                SignatureFileMemoryStream = New System.IO.MemoryStream(Employee.AdobeSignatureFile)

                                PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(SignatureFileMemoryStream, Employee.AdobeSignatureFilePassword)
                                PKCS7.Reason = "Advantage Digital Sign"

                            Catch ex As Exception

                            End Try

                            If PKCS7 IsNot Nothing Then

                                DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                If Employee.SignatureImage IsNot Nothing Then

                                    MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                    PdfFileSignature.SignatureAppearanceStream = MemoryStream

                                End If

                                PKCS7.ContactInfo = Employee.ToString

                                For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                    PdfFileSignature.Sign(SignatureName, PKCS7)
                                    HasBlankSignature = True

                                Next

                                If HasBlankSignature = False Then

                                    PdfFileSignature.Sign(1, "Advantage Digital Sign", Employee.ToString, "", True, New System.Drawing.Rectangle(100, 100, 200, 100), PKCS7)

                                End If

                                PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                            End If

                        End Using

                    End Using

                End If

            End If

        Catch ex As Exception
            DocumentSigned = False
        End Try

        Try

            If MemoryStream IsNot Nothing Then

                MemoryStream.Close()
                MemoryStream.Dispose()
                MemoryStream = Nothing

            End If

        Catch ex As Exception

        End Try

        If PKCS7 IsNot Nothing Then

            PKCS7 = Nothing

        End If

        If License IsNot Nothing Then

            License = Nothing

        End If

        TryToSignDocumentWithEmployeeInfo = DocumentSigned

    End Function
    Private Function SignDocument(ByVal DocumentID As Integer) As Boolean

        'objects
        Dim DocumentSigned As Boolean = False
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim Folder As String = ""
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
        Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
        Dim License As Aspose.Pdf.License = Nothing
        Dim HasBlankSignature As Boolean = False
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim MemoryStream As System.IO.MemoryStream = Nothing
        Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
        Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing
        Dim AlertComment As AlertComment = Nothing
        Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
        Dim ImpersonationContext As System.Security.Principal.WindowsImpersonationContext

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    If Document.FileName.ToUpper.Contains(".PDF") Then

                        If IsNTAuth = True Then

                            CurrentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                            ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                        End If

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _EmployeeCode)

                        If IsNTAuth = True Then

                            ImpersonationContext.Undo()

                        End If

                        Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                        If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                            AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                        End If
                        If Employee IsNot Nothing Then

                            If Employee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.AdobeSignatureFilePassword) = False Then

                                DocumentSigned = TryToSignDocumentWithEmployeeInfo(DbContext, Employee, Document, Folder)

                            End If

                        End If

                        If DocumentSigned = False Then

                            License = New Aspose.Pdf.License

                            License.SetLicense("Aspose.Total.lic")
                            License.Embedded = True

                            Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                                Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                                    PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Request.PhysicalApplicationPath, "\") & "AdvantagePDFSign.pfx", "APDFSAPDFS")
                                    PKCS7.Reason = "Advantage Digital Sign"

                                    DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                    If Employee IsNot Nothing Then

                                        If Employee.SignatureImage IsNot Nothing Then

                                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                            PdfFileSignature.SignatureAppearanceStream = MemoryStream

                                        End If

                                        PKCS7.ContactInfo = Employee.ToString

                                    End If

                                    For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                        PdfFileSignature.Sign(SignatureName, PKCS7)
                                        HasBlankSignature = True

                                    Next

                                    If HasBlankSignature = False Then

                                        PdfFileSignature.Sign(1, "Advantage Digital Sign", Employee.ToString, "", True, New System.Drawing.Rectangle(100, 100, 200, 100), PKCS7)

                                    End If

                                    PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                    Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                    DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                End Using

                            End Using

                            Try

                                If MemoryStream IsNot Nothing Then

                                    MemoryStream.Close()
                                    MemoryStream.Dispose()
                                    MemoryStream = Nothing

                                End If

                            Catch ex As Exception

                            End Try

                            If PKCS7 IsNot Nothing Then

                                PKCS7 = Nothing

                            End If

                            If License IsNot Nothing Then

                                License = Nothing

                            End If

                        End If

                        If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                            AliasAccount.EndImpersonation()

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception

            DocumentSigned = False

            If ex IsNot Nothing Then

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message, Diagnostics.EventLogEntryType.Error)

                If ex.InnerException IsNot Nothing Then

                    AdvantageFramework.Security.AddWebvantageEventLog(ex.InnerException.Message, Diagnostics.EventLogEntryType.Error)

                End If

            End If

        End Try

        If DocumentSigned Then

            If IsNTAuth = True Then

                CurrentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                ImpersonationContext = CurrentWindowsIdentity.Impersonate()

            End If

            AlertComment = New AlertComment(CStr(Me._ConnectionString))

            If Me.IsClientPortal = True Then

                AlertComment.AddNewComment(Me.CurrentAlertID, "", "Digitally Signed - " & Document.FileName, Me._ClientPortalID)

            Else

                AlertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Digitally Signed - " & Document.FileName)

            End If

            'If IsNTAuth = True Then

            '    ImpersonationContext.Undo()

            'End If

        Else

            Me.ShowMessage("Failed signing document.")

        End If

        SignDocument = DocumentSigned

    End Function

    Private _HasCommentIcon As Boolean = False
    Private _HasDigitallySignIcon As Boolean = False

    Private Sub RadGridRecipients_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridRecipients.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
            Try
                Dim cb As CheckBox
                cb = CType(e.Item.FindControl("cbSelectAll"), CheckBox)
                If Not cb Is Nothing Then
                    cb.Attributes.Add("onclick", "SelectAll('" & cb.ClientID & "')")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub RadListBoxAlertAssignmentState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxAlertAssignmentState.SelectedIndexChanged

        If CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer) > 0 AndAlso Me.RadListBoxAlertAssignmentState.SelectedItem.Index > -1 Then
            Dim CurrentEmpCode As String = Me.RadComboBoxAssignTo.SelectedValue

            Dim a As New cAlerts()
            With Me.RadComboBoxAssignTo

                .Items.Clear()
                .Text = ""
                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"
                .DataSource = a.GetNotificationRecipients(Me.RadListBoxAlertAssignmentState.SelectedValue, 0, 0, CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer))
                .DataBind()
                .Enabled = True
                .Focus()

            End With
            Try
                If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                    Dim HasDefaultEmpCode As Boolean = False
                    For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                        If item.Text.Contains("*") = True Then

                            item.Selected = True
                            Me.RadComboBoxAssignTo.Text = item.Text
                            Me.RadComboBoxAssignTo.SelectedValue = item.Value
                            Me.RadComboBoxAssignTo.Items.FindItemByValue(item.Value).Selected = True

                            HasDefaultEmpCode = True
                            Exit For

                        End If

                    Next

                    If HasDefaultEmpCode = False And CurrentEmpCode <> "" Then

                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAssignTo, CurrentEmpCode, False)

                    End If

                End If
            Catch ex As Exception
            End Try
            Try
                If Me.RadComboBoxCategory.Items.Count > 0 And Me.RadComboBoxCategory.Enabled = True Then
                    Me.RadComboBoxCategory.FindItemByValue(a.GetDefaultCategory(Me.RadListBoxAlertAssignmentState.SelectedValue)).Selected = True
                End If
            Catch ex As Exception
            End Try

            Try
                Dim SelectedState As String = ""
                Dim SelectedTemplate As String = ""
                Try
                    If Me.RadListBoxAlertAssignmentState.Items.Count > 0 Then
                        SelectedState = Me.RadListBoxAlertAssignmentState.SelectedItem.Text
                    End If
                Catch ex As Exception
                    SelectedState = ""
                End Try
                Try
                    If SelectedState.LastIndexOf("*") = SelectedState.Length - 1 Then
                        SelectedState = SelectedState.Substring(0, SelectedState.Length - 1)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(Me.HiddenFieldAlertAssignmentTemplateID.Value) = True AndAlso CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer) > 0 AndAlso
                        String.IsNullOrWhiteSpace(Me.LabelAlertAssignmentTemplateName.Text) = False Then

                        SelectedTemplate = Me.LabelAlertAssignmentTemplateName.Text

                    End If
                Catch ex As Exception
                    SelectedTemplate = ""
                End Try

                If SelectedState = "" Or SelectedState = "[Please select]" Then SelectedState = "N/A"
                If SelectedTemplate = "" Or SelectedTemplate = "[Please select]" Then SelectedTemplate = "N/A"

                Try
                    Dim m As New cMaintenanceApps()
                    Select Case m.AgencySettingGet("ALRT_ASSGN_DFLT_SUB").ToString().ToLower()
                        Case "state"
                            Me.TxtSubject.Text = SelectedState
                        Case "template"
                            Me.TxtSubject.Text = SelectedTemplate
                        Case "templateandstate"
                            Me.TxtSubject.Text = SelectedTemplate & " | " & SelectedState
                        Case "jjcts"
                            Dim s As String = ""
                            Try
                                If Me.HiddenFieldJobNumber.Value.Trim() <> "" And Me.HiddenFieldJobComponentNbr.Value.Trim() <> "" And Me.HiddenFieldJobCompDescription.Value.Trim() <> "" Then
                                    s = Me.HiddenFieldJobNumber.Value.Trim().PadLeft(6, "0") & "/" & Me.HiddenFieldJobComponentNbr.Value.Trim().PadLeft(2, "0") & " - " & Me.HiddenFieldJobCompDescription.Value.Trim()
                                End If
                            Catch ex As Exception
                                s = ""
                            End Try
                            If s.Trim() <> "" Then
                                s = s & " | "
                            End If
                            Me.TxtSubject.Text = "[" & s & SelectedTemplate & " | " & SelectedState & "]"
                    End Select
                Catch ex As Exception
                End Try

            Catch ex As Exception
            End Try
        Else
            Try
                With Me.RadComboBoxAssignTo
                    If .Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If
                    .Enabled = False
                End With
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub RadComboBoxAssignTo_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxAssignTo.ItemsRequested

        Dim AlertStateId As Integer = 0
        Dim AlertNotifyHdrId As Integer = 0

        If CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer) > 0 Then
            AlertNotifyHdrId = CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer)
        End If
        If Me.RadListBoxAlertAssignmentState.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxAlertAssignmentState.SelectedItem.Value) Then
            AlertStateId = CType(Me.RadListBoxAlertAssignmentState.SelectedItem.Value, Integer)
        End If
        Dim a As New cAlerts()
        Dim data As DataTable = a.GetNotificationRecipients(AlertStateId, 0, 0, AlertNotifyHdrId, e.Text, Me.CheckBoxShowAllAssignmentEmployees.Checked) 'GetData(e.Text)

        Dim itemOffset As Integer = e.NumberOfItems
        Dim endOffset As Integer = Math.Min(itemOffset + Me.RadComboBoxAssignTo.ItemsPerRequest, data.Rows.Count)
        e.EndOfItems = endOffset = data.Rows.Count

        RadComboBoxAssignTo.Items.Clear()

        For i As Integer = itemOffset To endOffset - 1

            RadComboBoxAssignTo.Items.Add(New RadComboBoxItem(data.Rows(i)("EMP_FML").ToString(),
                                                              data.Rows(i)("EMP_CODE").ToString()))

        Next

        e.Message = AdvantageFramework.Web.Presentation.Controls.RadComboBoxAutoFillGetStatusMessage(endOffset, data.Rows.Count)

    End Sub
    Private Sub CheckBoxShowAllAssignmentEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAllAssignmentEmployees.CheckedChanged

        Me.BindRadComboBoxAssignTo()

    End Sub
    Private Sub BindRadComboBoxAssignTo()

        Dim AlertStateId As Integer = 0
        Dim AlertNotifyHdrId As Integer = 0

        If IsNumeric(Me.HiddenFieldAlertAssignmentTemplateID.Value) = True AndAlso CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer) > 0 Then
            AlertNotifyHdrId = CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer)
        End If
        If Me.RadListBoxAlertAssignmentState.SelectedItem IsNot Nothing AndAlso IsNumeric(Me.RadListBoxAlertAssignmentState.SelectedItem.Value) Then
            AlertStateId = CType(Me.RadListBoxAlertAssignmentState.SelectedItem.Value, Integer)
        End If

        If AlertNotifyHdrId > 0 And AlertStateId > 0 Then

            Dim a As New cAlerts()
            Dim RecipientsDatatable As New DataTable

            With Me.RadComboBoxAssignTo

                .Items.Clear()
                .Text = ""
                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"

                If Me.CheckBoxShowAllAssignmentEmployees.Checked = True Then

                    If HttpContext.Current.Session("AllAvailRecipients") Is Nothing Then

                        RecipientsDatatable = a.GetNotificationRecipients(AlertStateId, 0, 0, AlertNotifyHdrId, "", True)
                        HttpContext.Current.Session("AllAvailRecipients") = RecipientsDatatable

                    Else

                        RecipientsDatatable = CType(HttpContext.Current.Session("AllAvailRecipients"), DataTable)

                    End If

                Else

                    RecipientsDatatable = a.GetNotificationRecipients(AlertStateId, 0, 0, AlertNotifyHdrId, "", False)

                End If

                .DataSource = RecipientsDatatable

                .DataBind()

            End With

            If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

                a.SetAssignmentComboBox(Me.RadComboBoxAssignTo, Me.CurrentAlertID)

            Else

                For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                    If item.Text.Contains("*") = True Then

                        item.Selected = True
                        Me.RadComboBoxAssignTo.Text = item.Text
                        Exit For

                    End If

                Next

            End If

            Me.RadComboBoxAssignTo.Focus()

        End If

    End Sub

    Private Function SendAssignment(ByVal AsPopUp As Boolean) As Boolean
        Try
            Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
            If rtb IsNot Nothing Then Me.CloseAfterCommentOrReAssign = rtb.Checked
        Catch ex As Exception
        End Try
        Try
            If Me.RadListBoxAlertAssignmentState.Items.Count > 0 Then

                Try

                    If Me.RadListBoxAlertAssignmentState.SelectedItem Is Nothing Then

                        Me.ShowMessage("Please select a State")
                        Return False

                    End If
                    If Me.RadListBoxAlertAssignmentState.SelectedItem.Index = Nothing Then

                        If Me.RadListBoxAlertAssignmentState.SelectedItem.Index < 0 Then

                            Me.ShowMessage("Please select a State")
                            Return False

                        End If

                    End If

                Catch ex As Exception
                    Me.ShowMessage("Please select a State")
                    Return False
                End Try

            Else

                Me.ShowMessage("This Workflow Template does not have any States")
                Return False

            End If
        Catch ex As Exception
        End Try
        If Me.RadComboBoxAssignTo.Enabled = False Then

            Me.ShowMessage("Assign To selection is disabled")
            Return False

        End If
        If Me.RadComboBoxAssignTo.Items.Count > 0 Then

            If Me.RadComboBoxAssignTo.SelectedItem Is Nothing Then

                Me.ShowMessage("Please select an Assign To employee")
                Return False

            Else

                If Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() = "[None]" Or Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() = "[Please select]" Then

                    Me.ShowMessage("Please select an Assign To employee")
                    Return False

                End If

            End If

        Else

            Me.ShowMessage("This State does not have any employees")
            Return False

        End If

        If Me.UpdateInformation(False) = False Then Return False

        If AsPopUp = True Then

            Try

                If Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() <> "[None]" And Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() <> "[Please select]" Then

                    Dim StrDesktopTab As String = ""

                    Try

                        If Not Request.QueryString("dtab") Is Nothing Then

                            StrDesktopTab = "&dtab=" & CType(Request.QueryString("dtab"), Integer).ToString()

                        End If

                    Catch ex As Exception
                        StrDesktopTab = ""
                    End Try

                End If

            Catch ex As Exception
                Me.ShowMessage("Error opening comment window")
            End Try

        Else

            If Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() <> "[None]" And Me.RadComboBoxAssignTo.SelectedItem.Text.Trim() <> "[Please select]" Then

                Dim a As New cAlerts()
                Dim ThisNotifyAssign_AlrtNotifyHdrId As Integer = 0
                Dim ThisNotifyAssign_StateId As Integer = 0
                Dim ThisNotifyAssign_Emp As String = "unassigned"
                Dim StrComment As String = Me.RadEditorAssignmentComment.Content.Replace(Environment.NewLine, "")

                If Me.LabelCompleted.Visible = True Then

                    a.UnDismissAlert(Me.CurrentAlertID, Me.IsClientPortal, Me._ClientPortalID) ', True)

                End If

                Try

                    If IsNumeric(Me.HiddenFieldAlertAssignmentTemplateID.Value) = True AndAlso CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer) > 0 Then

                        ThisNotifyAssign_AlrtNotifyHdrId = CType(Me.HiddenFieldAlertAssignmentTemplateID.Value, Integer)

                    End If

                Catch ex As Exception
                    ThisNotifyAssign_AlrtNotifyHdrId = 0
                End Try
                Try

                    If Me.RadListBoxAlertAssignmentState.Items.Count > 0 Then

                        If Me.RadListBoxAlertAssignmentState.SelectedItem.Index > -1 Then

                            ThisNotifyAssign_StateId = CType(Me.RadListBoxAlertAssignmentState.SelectedItem.Value, Integer)

                        End If

                    End If

                Catch ex As Exception
                    ThisNotifyAssign_StateId = 0
                End Try
                Try

                    If Me.RadComboBoxAssignTo.Items.Count > 0 Then

                        If Me.RadComboBoxAssignTo.SelectedIndex > -1 Then

                            ThisNotifyAssign_Emp = Me.RadComboBoxAssignTo.SelectedValue

                        End If

                    End If

                Catch ex As Exception
                    ThisNotifyAssign_Emp = "unassigned"
                End Try
                If ThisNotifyAssign_Emp.Trim() <> "" And ThisNotifyAssign_AlrtNotifyHdrId > 0 And ThisNotifyAssign_StateId > 0 Then

                    Dim s As String = String.Empty
                    Dim Success As Boolean = False

                    Success = a.SaveNotifyAssignmentAlertRecipient(Me.CurrentAlertID, ThisNotifyAssign_Emp, 0, ThisNotifyAssign_StateId, ThisNotifyAssign_AlrtNotifyHdrId, StrComment, True, False)

                    If Success = True Then

                        If Me.AlertRecipients(True) = False Then

                            'Return False

                        End If

                        If Me.CloseAfterCommentOrReAssign = False Then

                            Me.RadEditorAssignmentComment.Content = Nothing
                            Me.LoadAlert()
                            Me.RefreshAlertWindows(False)
                            'Me.RefreshByRedirect()

                        Else

                            Me.CloseRefreshAction()

                        End If


                        Return True

                    Else

                        If String.IsNullOrEmpty(s) = False Then Me.ShowMessage(s)
                        Return False

                    End If

                End If

            End If

        End If

        Return True

    End Function
    Private Sub ButtonSendAssignment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSendAssignment.Click

        SendAssignment(False)

    End Sub

    Private Sub BtnUpdateAlert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdateAlert.Click
        If Me.UpdateInformation(True) = True And Me.CurrentAlertID > 0 Then
            Me.AutoCompleteRecipients.Entries.Clear()
            Me.LoadAlert()
            Me.RefreshAlertWindows(False, True, False)
        End If
    End Sub

    Private Sub BtnSelectRecipients_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSelectRecipients.Click

        Dim ThisEmailGroup As String = getDefaultEmailGroup(CurrentAlert.ALERT_LEVEL)
        Dim ThisClCode As String = ""
        Dim ThisDivCode As String = ""
        Dim ThisPrdCode As String = ""
        Dim IsAG As Integer = 0
        Dim strScript As String
        Dim ThisJobNumber As Integer = 0
        Dim ThisJobComponentNumber As Integer = 0
        Dim s As String = ""
        Dim ClientContactCodes As String = ""

        If CurrentAlert.ALERT_LEVEL = "JC" Then

            If CurrentAlert.CL_CODE = "" And CurrentAlert.DIV_CODE = "" And CurrentAlert.PRD_CODE = "" Then

                Dim job As New cJobFunctions(Me._ConnectionString)
                job.GetCliDivProdFromJob(CInt(CurrentAlert.JOB_NUMBER), CInt(CurrentAlert.JOB_COMPONENT_NBR), ThisClCode, ThisDivCode, ThisPrdCode)

            Else

                ThisClCode = CurrentAlert.CL_CODE
                ThisDivCode = CurrentAlert.DIV_CODE
                ThisPrdCode = CurrentAlert.PRD_CODE

            End If

            IsAG = 1

        Else

            ThisClCode = CurrentAlert.CL_CODE

        End If

        ThisEmailGroup = ThisEmailGroup.Replace("/", "-").Replace("&", "and").Replace(",", "_").Replace("'", "__")


        Try

            ThisJobNumber = CurrentAlert.JOB_NUMBER
            ThisJobComponentNumber = CurrentAlert.JOB_COMPONENT_NBR

        Catch ex As Exception
        End Try

        Try

            For Each row As GridDataItem In Me.RadGridRecipients.MasterTableView.Items

                If CType(row("GridTemplateColumnSelect").FindControl("cbSelectRecp"), CheckBox).Checked = True Then

                    If row("GridBoundColumnUserName") IsNot Nothing AndAlso String.IsNullOrWhiteSpace(row("GridBoundColumnUserName").Text) = False AndAlso
                            row("GridBoundColumnUserName").Text.Trim.EndsWith("(CC)") Then

                        s &= row("GridBoundColumnEmpCode").Text & "(CC)" & ","

                    Else

                        s &= row("GridBoundColumnEmpCode").Text & ","

                    End If

                End If

            Next

            s &= Me.GetCommaDelimitedStringOfEmployeeCodes()

            ClientContactCodes = Me.GetCommaDelimitedStringOfClientContactCodes()

            If String.IsNullOrWhiteSpace(ClientContactCodes) = False Then

                s &= "," & ClientContactCodes

            End If

        Catch ex As Exception

            s = ""

        End Try

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.Page = "LookUp_Recipients.aspx"

        qs.JobNumber = ThisJobNumber
        qs.JobComponentNumber = ThisJobComponentNumber
        qs.EmailGroup = ThisEmailGroup
        qs.Add("ag", IsAG)
        qs.ClientCode = ThisClCode
        qs.DivisionCode = ThisDivCode
        qs.ProductCode = ThisPrdCode
        qs.AlertID = Me.CurrentAlertID
        qs.Add("NewAlertLevel", CurrentAlert.ALERT_LEVEL)
        qs.Add("uac", "1")
        qs.Add("seldrcpt", MiscFN.CleanStringForSplit(s, ","))

        Me.OpenLookUpRecipients(qs.ToString(True))

    End Sub
    Private Sub ButtonSaveRecipients_Click(sender As Object, e As EventArgs) Handles ButtonSaveRecipients.Click

        Me.GetRecipients()
        Me.UpdateRecipients(False)
        Me.RadGridRecipients.Rebind()
        Me.AutoCompleteRecipients.Entries.Clear()

    End Sub

    Public Function SetCheckBox(ByVal Value As Integer) As Boolean
        Try
            If Value = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Public Function SetCheckBoxRecp(ByVal Value As Integer) As Boolean
        Try
            If Value = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Function

    Private Sub CheckBoxHideSystemComments_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHideSystemComments.CheckedChanged

        'save setting then
        Try
            Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)
            av.getAllAppVars()
            av.setAppVar("HideSystemComments", CheckBoxHideSystemComments.Checked, "Boolean")
            av.SaveAllAppVars()
        Catch ex As Exception
        End Try

        'rebind
        RadListViewComments.Rebind()

    End Sub
    Private Sub RadListViewComments_NeedDataSource(sender As Object, e As RadListViewNeedDataSourceEventArgs) Handles RadListViewComments.NeedDataSource
        Try

            Dim oAlerts As cAlerts = New cAlerts(CStr(Me._ConnectionString))
            Dim HideSystemComments As Boolean = False

            Try

                Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
                AppVars.getAllAppVars()
                HideSystemComments = AppVars.getAppVar("HideSystemComments", "boolean", "false").ToString().ToLower() = "true"

            Catch ex As Exception
                HideSystemComments = False
            End Try

            Dim DtComments As New DataTable
            DtComments = oAlerts.GetAlertComments(Me.CurrentAlertID, HideSystemComments)

            If DtComments IsNot Nothing Then

                Me.RadListViewComments.DataSource = DtComments
                Me.LabelCommentsLegend.Text = "Comments&nbsp;(" & DtComments.Rows.Count().ToString() & ")"

            End If


        Catch ex As Exception
        End Try
    End Sub
    Private Sub RadListViewComments_ItemDataBound(sender As Object, e As RadListViewItemEventArgs) Handles RadListViewComments.ItemDataBound

        Select Case e.Item.ItemType

            Case RadListViewItemType.AlternatingItem, RadListViewItemType.DataItem
                Try

                    Dim ListItem As RadListViewDataItem = DirectCast(e.Item, RadListViewDataItem)
                    Dim DataItem = ListItem.DataItem

                    If ListItem IsNot Nothing AndAlso DataItem IsNot Nothing Then

                        'Dim EmployeeASPxBinaryImage As ASPxBinaryImage = e.Item.FindControl("ASPxBinaryImageEmployee")
                        'If EmployeeASPxBinaryImage IsNot Nothing Then

                        '    Try

                        '        If DataItem("EmployeeImage") IsNot Nothing AndAlso DataItem("EmployeeImage") IsNot System.DBNull.Value Then
                        '            EmployeeASPxBinaryImage.ContentBytes = DataItem("EmployeeImage")
                        '        End If

                        '    Catch ex As Exception
                        '    End Try

                        '    EmployeeASPxBinaryImage.EmptyImage.Url = "~/Images/Icons/White/256/user.png"
                        '    EmployeeASPxBinaryImage.StoreContentBytesInViewState = True
                        '    EmployeeASPxBinaryImage.ToolTip = DataItem("EmployeeFullName")

                        'End If

                        If _DeepLink Is Nothing Then _DeepLink = New AdvantageFramework.Web.DeepLink(Me._Session)
                        Dim EmployeePictureDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivEmployeePicture")
                        Dim DocumentLinksPlaceHolder As PlaceHolder = CType(e.Item.FindControl("PlaceHolderDocumentLinks"), PlaceHolder)
                        Dim InternalLinksPlaceHolder As PlaceHolder = CType(e.Item.FindControl("PlaceHolderInternalLinks"), PlaceHolder)

                        If EmployeePictureDiv IsNot Nothing Then

                            Dim ImageEmployeePicture As WebControls.Image = e.Item.FindControl("ImageEmployeePicture")

                            If ImageEmployeePicture IsNot Nothing Then

                                Dim HasImage As Boolean = False

                                Try

                                    If DataItem("EmployeeImage") IsNot Nothing AndAlso DataItem("EmployeeImage") IsNot System.DBNull.Value Then

                                        Dim EmployeeImage As Byte()

                                        EmployeeImage = DataItem("EmployeeImage")

                                        If EmployeeImage IsNot Nothing Then

                                            HasImage = True

                                            Try

                                                ImageEmployeePicture.ImageUrl = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(EmployeeImage))

                                            Catch ex As Exception
                                                HasImage = False
                                            End Try

                                        End If

                                        Try

                                            EmployeePictureDiv.Attributes.Add("title", DataItem("EmployeeFullName"))

                                        Catch ex As Exception
                                        End Try

                                    End If

                                Catch ex As Exception
                                    HasImage = False
                                End Try

                                If HasImage = False Then

                                    EmployeePictureDiv.Visible = False

                                End If

                            End If

                        End If

                        Dim TheComment As String = String.Empty

                        Try

                            TheComment = DataItem("Comment").ToString()

                        Catch ex As Exception
                            TheComment = String.Empty
                        End Try
                        If String.IsNullOrWhiteSpace(TheComment) = False Then

                            TheComment = HttpUtility.HtmlDecode(TheComment).Replace(Environment.NewLine, "<br />")

                            If _DeepLink.UrlToInternalLink(TheComment, InternalLinksPlaceHolder, AdvantageFramework.Web.DeepLink.LinkDisplay.Blank) = True Then

                                TheComment = TheComment.Replace("<br />&nbsp;<br />", "<br />")

                            End If

                            TheComment = Me.Sanitize(TheComment)

                            Dim CommentLiteral As System.Web.UI.WebControls.Literal = CType(e.Item.FindControl("LiteralComment"), Literal)
                            Dim ReadMoreHyperLink As System.Web.UI.WebControls.HyperLink = CType(e.Item.FindControl("HyperLinkComment"), HyperLink)

                            If CommentLiteral IsNot Nothing Then

                                If ReadMoreHyperLink IsNot Nothing Then

                                    If (Me.ShowFullComments = False And (TheComment.Length > Me.TruncateLength)) OrElse TheComment.Contains("<img") = True Then

                                        If TheComment.Contains("<img") = True Then

                                            ReadMoreHyperLink.Text = "<br />Click to view image(s) and see full comment"

                                        Else

                                            TheComment = TheComment.Substring(0, TruncateLength) & "..."

                                        End If

                                        ReadMoreHyperLink.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Alert_Comment.aspx?cid=" & DataItem("CommentID")))
                                        ReadMoreHyperLink.Visible = True

                                    Else

                                        ReadMoreHyperLink.Visible = False

                                    End If

                                End If

                                CommentLiteral.Text = TheComment '& "|" & "<font size='2'/>" & DataItem("EmployeeFullName") & " - " & DataItem("GeneratedDate") & "</font>"

                            End If

                        End If

                        Try

                            If TheComment.Contains("DOCUMENT ADDED|") = True Then

                                If DataItem("DocumentList") IsNot Nothing Then

                                    Dim docs As New Generic.List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument)
                                    Dim w As New AdvantageFramework.AlertSystem.Classes.CommentDocument

                                    docs = w.StringToObject(DataItem("DocumentList").ToString())

                                    If docs.Count > 0 Then

                                        Dim SpacerLiteral As New Literal
                                        SpacerLiteral.Text = "<br /><br />"

                                        DocumentLinksPlaceHolder.Controls.Add(SpacerLiteral)

                                        For Each doc As AdvantageFramework.AlertSystem.Classes.CommentDocument In docs

                                            Dim LiteralSpace As New Literal
                                            LiteralSpace.Text = "&nbsp;&nbsp;"
                                            DocumentLinksPlaceHolder.Controls.Add(LiteralSpace)

                                            Dim DocumentLinkButton As New System.Web.UI.WebControls.LinkButton
                                            With DocumentLinkButton

                                                .OnClientClick = "GetDocumentRepositoryDocument(" & doc.DocumentId & "); return false;"
                                                .Text = doc.Filename
                                                .ToolTip = "Click to download " & doc.Filename

                                            End With
                                            DocumentLinksPlaceHolder.Controls.Add(DocumentLinkButton)

                                            Dim LineBreakLiteral As New Literal
                                            LineBreakLiteral.Text = "<br />"
                                            DocumentLinksPlaceHolder.Controls.Add(LineBreakLiteral)

                                        Next

                                    End If

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                Catch ex As Exception
                End Try

        End Select

    End Sub

    'Private Sub RadGridComments_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComments.NeedDataSource
    '    'Try
    '    '    Dim oAlerts As cAlerts = New cAlerts(CStr(Me._ConnectionString))
    '    '    Me.RadGridComments.DataSource = oAlerts.GetAlertComments(Me.CurrentAlertID)
    '    'Catch ex As Exception
    '    'End Try
    'End Sub
    Private Sub RadGridRecipients_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridRecipients.NeedDataSource
        Try
            Dim a As New cAlerts()
            Me.RadGridRecipients.DataSource = a.GetAlertRecipients(Me.CurrentAlertID)

        Catch ex As Exception
        End Try
    End Sub
    Public Sub CheckBoxAlertRecipientSelect_CheckedChanged(sender As Object, e As EventArgs)
        Try

            Dim chk As CheckBox = CType(sender, CheckBox)
            Dim row As Telerik.Web.UI.GridDataItem = chk.Parent.Parent
            Dim CurrEmpCode As String = ""
            Dim alert As New Webvantage.cAlerts()
            Dim s As String = ""

            CurrEmpCode = row.GetDataKeyValue("empCode")

            If chk.Checked = True Then

                s = alert.UpdateAlertRecipients(Me.CurrentAlertID, "'" & CurrEmpCode & "'", "", False)


            Else

                s = alert.UpdateAlertRecipients(Me.CurrentAlertID, "", "'" & CurrEmpCode & "'", False)

            End If

            If s <> "" Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

            End If

        Catch ex As Exception
            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
        End Try
    End Sub

    ''''Private Sub AutoCompleteRecipients_RadAutoCompleteBoxEmployeesEntryAdded(sender As Object, e As AutoCompleteEntryEventArgs) Handles AutoCompleteRecipients.RadAutoCompleteBoxEmployeesEntryAdded

    ''''    If Me.AutoCompleteRecipients.Inserted = True Or Me.AutoCompleteRecipients.Deleted = True Then

    ''''        Me.RadGridRecipients.Rebind()

    ''''    End If

    ''''    Me.AutoCompleteRecipients.FocusTextBox()

    ''''End Sub

#End Region

#Region " Page "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts)

        Me._ConnectionString = Me._Session.ConnectionString
        Me._UserCode = Me._Session.UserCode
        Me._ClientPortalID = HttpContext.Current.Session("UserID")
        Me._EmployeeCode = HttpContext.Current.Session("EmpCode")

        If Me.CurrentAlertID = 0 Then
            Try
                Me.CurrentAlertID = Me.CurrentQuerystring.AlertID
            Catch ex As Exception
                Me.CurrentAlertID = 0
            End Try
        End If
        If Me.CurrentAlertID = 0 Then
            Try
                If Not Request.QueryString("AlertID") Is Nothing Then
                    Me.CurrentAlertID = CType(Request.QueryString("AlertID"), Integer)
                End If
            Catch ex As Exception
                Me.CurrentAlertID = 0
            End Try
        End If
        If Me.CurrentAlertID = 0 Then
            Try
                If Not Request.QueryString("alert") Is Nothing Then
                    Me.CurrentAlertID = CType(Request.QueryString("alert"), Integer)
                End If
            Catch ex As Exception
                Me.CurrentAlertID = 0
            End Try
        End If
        If Me.CurrentAlertID = 0 Then
            Try
                If Not Request.QueryString("a") Is Nothing Then
                    Me.CurrentAlertID = CType(Request.QueryString("a"), Integer)
                End If
            Catch ex As Exception
                Me.CurrentAlertID = 0
            End Try
        End If
        If Me.CurrentAlertID = 0 Then
            Me.CloseThisWindow()
        End If

        Try
            If Not Request.QueryString("f") Is Nothing Then
                Me.FromApp = CType(Request.QueryString("f"), MiscFN.Source_App)
            End If
        Catch ex As Exception
            Me.FromApp = MiscFN.Source_App.Alert
        End Try
        Try
            If Not Request.QueryString("t") Is Nothing Then
                Me.SelectedAlertType = Request.QueryString("t")
            End If
        Catch ex As Exception
        End Try
        Try
            If Not Request.QueryString("c") Is Nothing Then
                Me.SelectedAlertCategory = Request.QueryString("c")
            End If
        Catch ex As Exception
        End Try

        'see if coming from job jacket
        Try
            If Not Request.QueryString("j") Is Nothing Then
                Me.FromJobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            Me.FromJobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then
                Me.FromJobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            Me.FromJobComponentNbr = 0
        End Try
        If Me.FromJobNumber > 0 And Me.FromJobComponentNbr > 0 Then
            Me.FromJobJacket = True
        Else
            Me.FromJobJacket = False
        End If

        Try
            If Not Request.QueryString("seq") Is Nothing Then
                Me.FromTaskSeqNbr = CType(Request.QueryString("seq"), Integer)
            End If
        Catch ex As Exception
            Me.FromTaskSeqNbr = -1
        End Try
        Try
            If Not Request.QueryString("ps") Is Nothing Then
                Me.FromProjectSchedule = CType(Request.QueryString("ps"), Integer)
            End If
        Catch ex As Exception
            Me.FromProjectSchedule = 0
        End Try

        Try
            If Not Request.QueryString("dtab") Is Nothing Then
                Me.DesktopTabNum = CType(Request.QueryString("dtab").ToString(), Integer)
            Else
                Me.DesktopTabNum = -1
            End If
        Catch ex As Exception
            Me.DesktopTabNum = -1
        End Try
        Try
            If Not Request.QueryString("fdr") Is Nothing Then
                Me.AlertFolder = Request.QueryString("fdr").ToString()
            End If
        Catch ex As Exception
            Me.AlertFolder = "Inbox"
        End Try
        Try
            If Not Request.QueryString("dtlemp") Is Nothing Then
                Me.EmpCodeFromFilter = Request.QueryString("dtlemp").ToString().Trim()
            End If
        Catch ex As Exception
            Me.EmpCodeFromFilter = ""
        End Try

        If Me.IsClientPortal = True Then

            'Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

            '    Dim ClientPortalAlertRecipient As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient
            '    ClientPortalAlertRecipient = AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.LoadByAlertIDAndContactID(DbContext, Me.CurrentAlertID, Me._ClientPortalID)

            '    If ClientPortalAlertRecipient IsNot Nothing Then

            '        Me.ClientPortalUserHasAccess = True

            '    End If
            '    If Me.ClientPortalUserHasAccess = False Then

            '        If AdvantageFramework.Database.Procedures.ClientPortalAlertRecipientDismissed.LoadByAlertIDAndContactID(DbContext, Me.CurrentAlertID, Me._ClientPortalID).Count > 0 Then

            '            Me.ClientPortalUserHasAccess = True

            '        End If

            '    End If

            'End Using

            'If ClientPortalUserHasAccess = False Then

            '    Server.Transfer("NoAccess.aspx")

            'End If

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.LabelApproved = Me.RadToolbarAlertView.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelApproved")
        Me.LabelDismissed = Me.RadToolbarAlertView.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelDismissed")
        Me.LabelCompleted = Me.RadToolbarAlertView.FindItemByValue("RadToolBarButtonLabels").FindControl("LabelCompleted")

        accessPrivate = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments)

        Me.GroupSettingsAlertInboxShowAllAssignments = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowAllAssignments) = 1
        Me.GroupSettingsAlertInboxShowUnassignedAssignments = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.AlertInbox_ShowUnassignedAssignments) = 1

        Me.CurrentAlert = New Alert(Me._ConnectionString)
        Me.CurrentAlert.LoadByPrimaryKey(Me.CurrentAlertID)

        Try
            Me.RadScriptManagerParent.RegisterPostBackControl(ImageButtonCommentPopUpStandardComment)
        Catch ex As Exception
        End Try

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim SprintID As Integer = 0
                    Dim AlertCategoryID As Integer = 0

                    Try

                        AlertCategoryID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_CAT_ID, 0) FROM ALERT WITH (NOLOCK) WHERE ALERT_ID = {0};", Me.CurrentAlertID)).SingleOrDefault

                    Catch ex As Exception
                        AlertCategoryID = 0
                    End Try

                    If AlertCategoryID <> 38 AndAlso AlertCategoryID <> 39 AndAlso IsClientPortal = False Then

                        'Dim MyCCCount As Integer = 0

                        'MyCCCount = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM [dbo].[advtf_alert_recipient_get]({0}) WHERE EmployeeCode = '{1}' AND IsCurrentNotify = 1;", Me.CurrentAlertID, _Session.User.EmployeeCode)).SingleOrDefault

                        'If MyCCCount > 0 Then

                        Try

                            SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SPRINT_HDR_ID FROM SPRINT_DTL WHERE ALERT_ID = {0}", Me.CurrentAlertID)).SingleOrDefault

                        Catch ex As Exception
                            SprintID = 0
                        End Try

                        Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                        QsViewDetails.Page = "Desktop_AlertView"
                        QsViewDetails.Add("AlertID", Me.CurrentAlertID.ToString)
                        QsViewDetails.Add("SprintID", SprintID.ToString)

                        MiscFN.ResponseRedirect(QsViewDetails.ToString(True), True)

                        'End If

                    End If

                End Using

            Catch ex As Exception
            End Try

            Me.SetRadDatePicker(Me.RadDatePickerStartDate)
            Me.SetRadDatePicker(Me.RadDatePickerDueDate)

            Me.RadToolbarAlertView.FindItemByValue("AlertRecipients").ToolTip = "Send email and alert recipients"
            Me.RadToolbarAlertView.FindItemByValue("Save").ToolTip = "Save changes"

            Me.RadToolbarAlertView.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks
            Me.RadToolbarAlertView.FindItemByValue("AddAttachment").ToolTip = "Upload/link attachments"

            Try

                Dim AppVars As New cAppVars(cAppVars.Application.ALERT_VIEW)
                AppVars.getAllAppVars()
                Me.CheckBoxHideSystemComments.Checked = AppVars.getAppVar("HideSystemComments", "boolean", "false").ToString().ToLower() = "true"

            Catch ex As Exception
            End Try


            Me.LoadListCategories()
            Dim a As New cAlerts()
            a.LoadPrioritiesComboBox(Me.RadComboBoxPriority)

            Me.LoadAlert()
            Me.LoadApproval()
            Me.RefreshDashboardAlerts()

            'If Not Request.Cookies("ShowFullComments") Is Nothing AndAlso Not Request.Cookies("ShowFullComments").Value Is Nothing Then
            CType(Me.RadToolbarAlertView.FindItemByValue("ShowFullComments"), RadToolBarButton).Checked = Me.ShowFullComments()
            'End If


            If Me.IsClientPortal = True Then

                Me.RadToolbarAlertView.FindItemByValue("ClientContacts").Visible = False
                Me.RadToolbarAlertView.FindItemByValue("AddTime").Visible = False
                Me.RadToolbarAlertView.FindItemByValue("StartStopwatch").Visible = False
                Me.RadToolbarAlertView.FindItemByValue("CopyAsAssignment").Visible = False
                Me.RadToolbarAlertView.FindItemByValue("TimeSeparator").Visible = False
                Me.RadToolbarAlertView.FindItemByValue("Bookmark").Visible = False

            End If

            Try
                Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
                If rtb IsNot Nothing Then rtb.Checked = Me.CloseAfterCommentOrReAssign
            Catch ex As Exception
            End Try

            Me.SetScreenSplit()

        Else

            Select Case Me.EventTarget
                Case "Refresh", "RefreshGrid"

                    Me.LoadAlert()
                    Me.RadListViewAttachments.Rebind()

                Case "AlertRecipients"
                    If Me.AlertRecipients(False) = False Then
                        Exit Sub
                    End If
                    If CType(Me.EventArgument, Boolean) = True Then
                        Me.CloseThisWindowAndRefreshCaller("Alert_Inbox.aspx", False, False)
                    End If
                Case "AlertRecipientsNotifyOriginator"
                    If Me.AlertRecipients(True) = False Then
                        Exit Sub
                    End If
                    If CType(Me.EventArgument, Boolean) = True Then
                        Me.CloseThisWindowAndRefreshCaller("Alert_Inbox.aspx", False, False)
                    End If

                Case "RefreshAlertRecipients"

                    Me.RadGridRecipients.Rebind()

            End Select


        End If

        'If Me.JobNumber > 0 And Me.JobComponentNumber > 0 Then
        '    Me.MyUnityContextMenu.JobNumber = Me.JobNumber
        '    Me.MyUnityContextMenu.JobComponentNumber = Me.JobComponentNumber
        'End If
        'If Me.FromJobNumber > 0 And Me.FromJobComponentNbr > 0 Then
        '    Me.MyUnityContextMenu.JobNumber = Me.FromJobNumber
        '    Me.MyUnityContextMenu.JobComponentNumber = Me.FromJobComponentNbr
        'End If
        'If IsNumeric(Me.HiddenFieldJobNumber.Value) = True Then
        '    Me.MyUnityContextMenu.JobNumber = Me.HiddenFieldJobNumber.Value
        '    Me.JobNumber = Me.HiddenFieldJobNumber.Value
        'End If
        'If IsNumeric(Me.HiddenFieldJobComponentNbr.Value) = True Then
        '    Me.MyUnityContextMenu.JobComponentNumber = Me.HiddenFieldJobComponentNbr.Value
        '    Me.JobComponentNumber = Me.HiddenFieldJobComponentNbr.Value
        'End If

        Me.TxtCommentApproval.Visible = False
        Me.ApprovalRadEditor.Visible = True

        'Me.AutoCompleteRecipients.AlertId = Me.CurrentAlertID
        'Me.AutoCompleteRecipients.IsAssignment = Me.IsAlertAssignment
        'Me.AutoCompleteRecipients.JobNumber = Me.JobNumber
        'Me.AutoCompleteRecipients.ClientCode = Me.HiddenFieldClientCode.Value

    End Sub
    Private Sub Page_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'If Me.CurrentTheme = TkTheme.Small Then
        '    RadEditorAssignmentComment.Height = 105
        '    RadEditorStandardComment.OnClientLoad = "RadEditorOnClientLoad"
        'Else
        '    RadEditorAssignmentComment.Height = 85
        '    If IsAlertAssignment = True Then
        '        If Me.DivJob.Visible = False Then
        '            RadEditorStandardComment.OnClientLoad = "RadEditorOnClientLoadSOFLarge"
        '        Else
        '            RadEditorStandardComment.OnClientLoad = "RadEditorOnClientLoad"
        '        End If
        '    Else
        '        If Me.DivProduct.Visible = False Then
        '            RadEditorStandardComment.OnClientLoad = "RadEditorOnClientLoadSOFLarge"
        '        Else
        '            RadEditorStandardComment.OnClientLoad = "RadEditorOnClientLoad"
        '        End If
        '    End If

        'End If

        'If Session("AssignmentHtmlComment") IsNot Nothing AndAlso Session("AssignmentHtmlComment") <> "" Then
        '    RadEditorAssignmentComment.Content = Session("AssignmentHtmlComment")
        '    Session("AssignmentHtmlComment") = ""
        'End If

        Try

            If (Me.IsAlertAssignment = True OrElse Me.RoutedAssignment = True) AndAlso Me.RadComboBoxAssignTo.SelectedValue.ToString().ToLower().IndexOf("unassigned") > -1 Then

                Me.RadToolbarAlertView.FindItemByValue("Complete").Visible = False

            End If

        Catch ex As Exception
        End Try
        Try

            If Me.RoutedAssignment = True AndAlso Me.MyRoutedAssignment = False AndAlso Me.RadToolbarAlertView.FindItemByValue("Complete").Text = "Complete" Then

                Me.RadToolbarAlertView.FindItemByValue("Complete").Visible = False

            End If

        Catch ex As Exception
        End Try

        If Me.IsAlertAssignment = True OrElse Me.IsWorkItem = True Then

            Me.LabelRecipients.Text = "CC"
            Me.LabelAddRecipients.Text = "Add CC"
            Me.Title = "Assignment"

        Else

            Me.LabelRecipients.Text = "Recipients"
            Me.LabelAddRecipients.Text = "Add Recipients"
            'Me.Title = "Alert"

        End If
        'If Me.DocumentUploadedWithComment = True Then

        '    Me.RadListViewComments.Rebind()

        'End If
        Try

            Dim sb As New System.Text.StringBuilder
            If Me.JobNumber > 0 Then

                sb.Append(Me.JobNumber.ToString())
                sb.Append("-")

                If Me.JobComponentNumber > 0 Then

                    sb.Append(Me.JobComponentNumber.ToString())
                    sb.Append("-")
                    sb.Append(Me.LabelAlertID.Text)
                    sb.Append(" - ")
                    sb.Append(Me.TxtSubject.Text.Replace("'", "\'"))

                    Me.LabelAlertID.Attributes.Add("style", "cursor:copy;")
                    Me.LabelAlertID.Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", sb.ToString()))

                End If

            End If

        Catch ex As Exception
        End Try

        Me.RadListViewComments.Rebind()

        Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
        Deep.BuildJavascriptFromQueryString(Me.CurrentQuerystring, WebvantageLink, ClientPortalLink)
        Me.RadToolbarAlertView.FindItemByValue("CpPermaLink").Visible = Deep.ClientPortalVisible
        If Me.IsClientPortal = True Then

            Me.RadToolbarAlertView.FindItemByValue("WvPermaLink").Visible = False
            Me.RadToolbarAlertView.FindItemByValue("CpPermaLink").Visible = False

        End If


    End Sub
    Private Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload
        Me.CurrentAlert = Nothing
    End Sub

    Private Sub CloseRefreshAction()

        'If Me.FromApp = MiscFN.Source_App.ProjectScheduleTask Then

        '    Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx?JobNum=" & Me.FromJobNumber & "&JobComp=" & Me.FromJobComponentNbr & "&seq=" & Me.FromTaskSeqNbr)

        'Else

        '    Me.RefreshAlertWindows()

        'End If
        Me.RefreshDashboardAlerts()
        Me.RefreshAlertWindows(True, True, Me.FromApp = MiscFN.Source_App.ProjectScheduleTask)

    End Sub

#End Region

#Region " Load Data "

    Private Function LoadAlert()

        If _DeepLink Is Nothing Then _DeepLink = New AdvantageFramework.Web.DeepLink(Me._Session)

        Try

            If Not Request.QueryString("alert") Is Nothing Then

                Me.CurrentAlertID = CType(Request.QueryString("alert"), Integer)

            End If

            If Me.CurrentQuerystring.AlertID > 0 Then Me.CurrentAlertID = Me.CurrentQuerystring.AlertID

        Catch ex As Exception
            Me.CurrentAlertID = 0
        End Try

        Dim QsAddAttachment As New AdvantageFramework.Web.QueryString

        QsAddAttachment.Page = "Alert_AddAttachments.aspx"
        QsAddAttachment.AlertID = Me.CurrentAlertID

        Me.ImageButtonAddAttachment.OnClientClick = Me.HookUpOpenWindow("", QsAddAttachment.ToString(True))

        Dim oAlerts As cAlerts = New cAlerts(CStr(Me._ConnectionString))
        Dim DsAlert As New DataSet
        Dim DtAlertDetails As New DataTable
        Dim DtMyAlert As New DataTable
        Dim DtComments As New DataTable
        Dim DtAttachments As New DataTable
        Dim DtRecipients As New DataTable
        Dim TaskCodeSeqNum As Short = -1
        Dim HasInformation As Boolean = False

        Try
            Dim CPID As Integer = 0
            Try
                If Me._ClientPortalID IsNot Nothing Then
                    CPID = CType(Me._ClientPortalID, Integer)
                End If
            Catch ex As Exception
                CPID = 0
            End Try
            If Me.IsClientPortal = True Then
                DsAlert = oAlerts.GetAlert(Me.CurrentAlertID, CPID)
            Else
                DsAlert = oAlerts.GetAlert(Me.CurrentAlertID)
            End If

            DtAlertDetails = DsAlert.Tables(0)
            DtComments = DsAlert.Tables(1)
            DtMyAlert = DsAlert.Tables(3)
            DtRecipients = DsAlert.Tables(4)
            DtAttachments = DsAlert.Tables(5)

            If Not DtAlertDetails Is Nothing Then
                If DtAlertDetails.Rows.Count > 0 Then

                    Try

                        If CType(DtAlertDetails.Rows(0)("IS_WORK_ITEM"), Boolean) = True Then

                            Me.IsWorkItem = True

                        End If

                    Catch ex As Exception
                        Me.IsWorkItem = False
                    End Try
                    Try

                        If CType(DtAlertDetails.Rows(0)("IS_ROUTED_ASSIGNMENT"), Boolean) = True Then

                            Me.RoutedAssignment = True

                        End If

                    Catch ex As Exception
                        Me.RoutedAssignment = False
                    End Try
                    Try
                        If Me.RoutedAssignment = True Then

                            If DtAlertDetails.Rows(0)("ASSIGNED_EMP_CODE") = HttpContext.Current.Session("EmpCode") Then

                                Me.MyRoutedAssignment = True

                            End If

                        End If

                    Catch ex As Exception
                        Me.MyRoutedAssignment = False
                    End Try
                    Try
                        If Me.MyRoutedAssignment = False Then

                            If DtAlertDetails.Rows(0)("LAST_ASSIGNED_EMP_CODE") = HttpContext.Current.Session("EmpCode") Then

                                Me.MyRoutedAssignment = True

                            End If

                        End If

                    Catch ex As Exception
                        Me.MyRoutedAssignment = False
                    End Try


                    'hide tables unless it has data
                    Me.LabelDismissed.Visible = False
                    Me.DivOffice.Visible = False
                    Me.DivClient.Visible = False
                    Me.DivDivision.Visible = False
                    Me.DivProduct.Visible = False
                    Me.DivCampaign.Visible = False
                    Me.DivJob.Visible = False
                    Me.DivJobComponent.Visible = False
                    Me.DivTask.Visible = False
                    Me.DivEstimateNumber.Visible = False
                    Me.DivEstimateComponent.Visible = False
                    Me.DivATBRevision.Visible = False

                    Me.CurrentAlertID = CType(DtAlertDetails.Rows(0)("ALERT_ID"), Integer)
                    Try
                        Me.CurrentAlertTypeId = CType(DtAlertDetails.Rows(0)("ALERT_TYPE_ID"), Integer)
                    Catch ex As Exception
                        Me.CurrentAlertTypeId = 6
                    End Try

                    Me.CurrentAlertLevel = DtAlertDetails.Rows(0)("ALERT_LEVEL").ToString()
                    Me.CurrentAlertCategoryId = CType(DtAlertDetails.Rows(0)("ALERT_CAT_ID"), Integer)

                    Me._IsMyAlert_Open = CType(DtAlertDetails.Rows(0)("IS_MY_ALERT_OPEN"), Boolean)
                    Me._IsMyAlert_Dismissed = CType(DtAlertDetails.Rows(0)("IS_MY_ALERT_DISMISSED"), Boolean)
                    Me._IsMyAssignment_Open = CType(DtAlertDetails.Rows(0)("IS_MY_ASSIGNMENT_OPEN"), Boolean)
                    Me._IsMyAssignment_Completed = CType(DtAlertDetails.Rows(0)("IS_MY_ASSIGNMENT_COMPLETED"), Boolean)

                    Me.HiddenFieldAlertId.Value = Me.CurrentAlertID.ToString()
                    Me.HiddenFieldAlertTypeId.Value = Me.CurrentAlertTypeId.ToString()
                    Me.HiddenFieldAlertLevel.Value = Me.CurrentAlertLevel
                    Me.HiddenFieldAlertCategoryId.Value = Me.CurrentAlertCategoryId.ToString()
                    Me.HiddenFieldAlertEmpCode.Value = DtAlertDetails.Rows(0)("EMP_CODE").ToString()

                    Me.IsApproval = Me.CurrentAlertCategoryId = 38
                    Me.DivApproval.Visible = Me.IsApproval
                    Me.RadToolbarAlertView.FindItemByValue("Approve").Visible = Me.IsApproval
                    Me.RadToolbarAlertView.FindItemByValue("Deny").Visible = Me.IsApproval
                    Me.RadToolbarAlertView.FindItemByValue("ApproveDenySeparator").Visible = Me.IsApproval

                    'Details section
                    ''Me.LabelAlertType.Text = DtAlertDetails.Rows(0)("ALERT_TYPE_DESC")

                    If IsDBNull(DtAlertDetails.Rows(0)("ORIGINATED_DATE")) = False Then

                        Me.LabelGenerated.Text = LoGlo.FormatDateTime(DtAlertDetails.Rows(0)("ORIGINATED_DATE"))
                    End If

                    If IsDBNull(DtAlertDetails.Rows(0)("USER_NAME")) = False Then
                        Me.LabelGenerated.Text &= " by " & DtAlertDetails.Rows(0)("USER_NAME").ToString()
                    End If
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("ID")) = False Then
                            Me.LabelAlertID.Text = DtAlertDetails.Rows(0)("ID").ToString()
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("IS_ALERT_ASSIGNMENT")) = False Then
                            Me.IsAlertAssignment = MiscFN.IntToBool(CType(DtAlertDetails.Rows(0)("IS_ALERT_ASSIGNMENT"), Integer))
                        End If
                    Catch ex As Exception
                    End Try
                    'Try
                    '    If IsDBNull(DtAlertDetails.Rows(0)("WAS_MARKED_READ")) = False AndAlso DtAlertDetails.Rows(0)("WAS_MARKED_READ") = True Then
                    '        Me.RefreshAlertWindows(False, True, False)
                    '    End If
                    'Catch ex As Exception
                    'End Try
                    Try
                        If Not DtMyAlert Is Nothing Then
                            If DtMyAlert.Rows.Count > 0 Then
                                If IsDBNull(DtMyAlert.Rows(0)("PROCESSED")) = False Then
                                    Me.LabelDismissed.Text = "DISMISSED:  " & LoGlo.FormatDateTime(DtMyAlert.Rows(0)("PROCESSED"))
                                    Me.LabelDismissed.Visible = True
                                Else
                                    Me.LabelDismissed.Text = ""
                                    Me.LabelDismissed.Visible = False
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("OFFICE_DISPLAY")) = False Then
                            Me.LabelOffice.Text = DtAlertDetails.Rows(0)("OFFICE_DISPLAY").ToString()
                            Me.DivOffice.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("CLIENT_DISPLAY")) = False Then
                            Me.LabelClient.Text = DtAlertDetails.Rows(0)("CLIENT_DISPLAY").ToString()
                            Me.DivClient.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("CL_CODE")) = False Then
                            Me.HiddenFieldClientCode.Value = DtAlertDetails.Rows(0)("CL_CODE").ToString()
                            Me.ClientCode = DtAlertDetails.Rows(0)("CL_CODE").ToString()
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("DIV_CODE")) = False Then
                            Me.DivisionCode = IsDBNull(DtAlertDetails.Rows(0)("DIV_CODE"))
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("PRD_CODE")) = False Then
                            Me.ProductCode = IsDBNull(DtAlertDetails.Rows(0)("PRD_CODE"))
                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("DIVISION_DISPLAY")) = False Then
                            Me.LabelDivision.Text = DtAlertDetails.Rows(0)("DIVISION_DISPLAY").ToString()
                            Me.DivDivision.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("PRODUCT_DISPLAY")) = False Then
                            Me.LabelProduct.Text = DtAlertDetails.Rows(0)("PRODUCT_DISPLAY").ToString()
                            Me.DivProduct.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try

                        If IsDBNull(DtAlertDetails.Rows(0)("JOB_NUMBER")) = False AndAlso IsNumeric(DtAlertDetails.Rows(0)("JOB_NUMBER")) = True Then

                            Me.JobNumber = CType(DtAlertDetails.Rows(0)("JOB_NUMBER"), Integer)
                            Me.HiddenFieldJobNumber.Value = Me.JobNumber.ToString()
                            Me.LBtnJob.Text = DtAlertDetails.Rows(0)("JOB_DISPLAY").ToString()
                            Me.DivJob.Visible = True
                            HasInformation = True
                            'Me.MyUnityContextMenu.JobNumber = JobNumber

                        End If

                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("JOB_COMPONENT_NBR")) = False AndAlso IsNumeric(DtAlertDetails.Rows(0)("JOB_COMPONENT_NBR")) = True Then

                            Me.JobComponentNumber = CType(DtAlertDetails.Rows(0)("JOB_COMPONENT_NBR"), Integer)
                            Me.HiddenFieldJobComponentNbr.Value = Me.JobComponentNumber.ToString()
                            Me.LBtnJobComponent.Text = DtAlertDetails.Rows(0)("JOB_COMPONENT_DISPLAY").ToString()
                            Me.DivJobComponent.Visible = True
                            HasInformation = True
                            'Me.MyUnityContextMenu.JobComponentNumber = JobComponentNumber

                        End If
                    Catch ex As Exception
                    End Try

                    If String.IsNullOrEmpty(Me.ClientCode) = False OrElse (Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0) Then

                        Me.RadToolbarAlertView.FindItemByValue("ClientContacts").Visible = True

                    Else

                        Me.RadToolbarAlertView.FindItemByValue("ClientContacts").Visible = False

                    End If

                    If Me.DivJob.Visible = False Or Me.DivJobComponent.Visible = False Then

                        Me.RadToolbarAlertView.FindItemByValue("ViewComments").Visible = False

                    End If

                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("TASK_SEQ_NBR")) = False AndAlso IsNumeric(DtAlertDetails.Rows(0)("TASK_SEQ_NBR")) = True Then

                            TaskCodeSeqNum = CType(DtAlertDetails.Rows(0)("TASK_SEQ_NBR"), Short)
                            Me.HiddenFieldTaskSeqNbr.Value = TaskCodeSeqNum.ToString
                            'Me.MyUnityContextMenu.TaskSequenceNumber = TaskCodeSeqNum

                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If Me.IsClientPortal = False AndAlso Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

                            Me.RadToolbarAlertView.FindItemByValue("AddTime").Visible = True
                            Me.RadToolbarAlertView.FindItemByValue("StartStopwatch").Visible = True
                            Me.RadToolbarAlertView.FindItemByValue("TimeSeparator").Visible = True

                        End If
                    Catch ex As Exception
                    End Try

                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("JOB_COMP_DESC")) = False Then
                            Me.HiddenFieldJobCompDescription.Value = DtAlertDetails.Rows(0)("JOB_COMP_DESC")
                        End If
                    Catch ex As Exception
                        Me.HiddenFieldJobCompDescription.Value = ""
                    End Try

                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("CL_CODE")) = False Then
                            Me.ClientCode = DtAlertDetails.Rows(0)("CL_CODE").ToString()
                        End If
                        If IsDBNull(DtAlertDetails.Rows(0)("DIV_CODE")) = False Then
                            Me.DivisionCode = DtAlertDetails.Rows(0)("DIV_CODE").ToString()
                        End If
                        If IsDBNull(DtAlertDetails.Rows(0)("PRD_CODE")) = False Then
                            Me.ProductCode = DtAlertDetails.Rows(0)("PRD_CODE").ToString()
                        End If
                        Dim v As New cValidations(Me._ConnectionString)
                        Dim s As String = ""
                        If v.ValidateCDPIsViewable(Me.ClientCode, Me.DivisionCode, Me.ProductCode, 0, 0, s) = False Then
                            'Server.Transfer("NoAccess.aspx")
                            Me.ShowMessage(s)
                            Me.CloseThisWindow()
                            Exit Function
                        End If


                    Catch ex As Exception
                    End Try

                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("ESTIMATE_DISPLAY")) = False Then
                            Me.LabelEstimateNumber.Text = DtAlertDetails.Rows(0)("ESTIMATE_DISPLAY").ToString()
                            Me.DivEstimateNumber.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("ESTIMATE_COMPONENT_DISPLAY")) = False Then
                            Me.LabelEstComponentNbr.Text = DtAlertDetails.Rows(0)("ESTIMATE_COMPONENT_DISPLAY").ToString()
                            Me.DivEstimateComponent.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try

                        If TaskCodeSeqNum > -1 Then

                            Dim TaskQueryString As New AdvantageFramework.Web.QueryString

                            TaskQueryString.Page = "TrafficSchedule_TaskDetail.aspx"
                            TaskQueryString.JobNumber = Me.JobNumber
                            TaskQueryString.JobComponentNumber = Me.JobComponentNumber
                            TaskQueryString.TaskSequenceNumber = TaskCodeSeqNum
                            TaskQueryString.ClientCode = DtAlertDetails.Rows(0)("CL_CODE")
                            TaskQueryString.DivisionCode = DtAlertDetails.Rows(0)("DIV_CODE")
                            TaskQueryString.ProductCode = DtAlertDetails.Rows(0)("PRD_CODE")

                            Me.LinkButtonTask.OnClientClick = Me.HookUpOpenWindow("", TaskQueryString.ToString(True))

                            Try

                                If DtAlertDetails.Rows(0)("TASK_FUNCTION_DISPLAY") Is Nothing Then

                                    Me.LinkButtonTask.Text = "[No Description]"

                                Else

                                    Me.LinkButtonTask.Text = DtAlertDetails.Rows(0)("TASK_FUNCTION_DISPLAY").ToString()

                                End If

                                If String.IsNullOrWhiteSpace(Me.LinkButtonTask.Text) = True Then

                                    Me.LinkButtonTask.Text = "[No Description]"

                                End If

                            Catch ex As Exception
                                Me.LinkButtonTask.Text = "[No Description]"
                            End Try

                            Me.DivTask.Visible = True
                            HasInformation = True

                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("ATB_DISPLAY")) = False Then
                            Me.LinkButton_ATB.Text = DtAlertDetails.Rows(0)("ATB_DISPLAY").ToString()
                            Me.DivATBRevision.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("CAMPAIGN_DISPLAY")) = False Then
                            Me.LabelCampaign.Text = DtAlertDetails.Rows(0)("CAMPAIGN_DISPLAY").ToString()
                            Me.DivCampaign.Visible = True
                            HasInformation = True
                        End If
                    Catch ex As Exception
                    End Try

                    If HasInformation = False Then

                        AdvantageFramework.Web.Presentation.Controls.DivHide(Me.DivAlertInfo)

                    End If

                    'information section
                    Try
                        If Me.RadComboBoxCategory.Items.Count > 0 Then
                            If Me.RadComboBoxCategory.FindItemByValue(DtAlertDetails.Rows(0)("ALERT_CAT_ID")) IsNot Nothing Then
                                Me.RadComboBoxCategory.FindItemByValue(DtAlertDetails.Rows(0)("ALERT_CAT_ID")).Selected = True
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Me.RadComboBoxPriority.Items.Count > 0 Then
                            Me.RadComboBoxPriority.FindItemByValue(DtAlertDetails.Rows(0)("PRIORITY")).Selected = True
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(DtAlertDetails.Rows(0)("START_DATE")) Then
                            If cGlobals.wvIsDate(DtAlertDetails.Rows(0)("START_DATE")) = True Then
                                Me.RadDatePickerStartDate.SelectedDate = Convert.ToDateTime(DtAlertDetails.Rows(0)("START_DATE"))
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(DtAlertDetails.Rows(0)("DUE_DATE")) Then
                            If cGlobals.wvIsDate(DtAlertDetails.Rows(0)("DUE_DATE")) = True Then
                                Me.RadDatePickerDueDate.SelectedDate = Convert.ToDateTime(DtAlertDetails.Rows(0)("DUE_DATE"))
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Try
                        If Not IsDBNull(DtAlertDetails.Rows(0)("TIME_DUE")) Then
                            Me.TxtTimeDue.Text = DtAlertDetails.Rows(0)("TIME_DUE").ToString()
                        End If
                    Catch ex As Exception
                    End Try

                    Try

                        Me.LoadVersionAndBuild()

                        If IsDBNull(DtAlertDetails.Rows(0)("VER")) = False AndAlso IsNumeric(DtAlertDetails.Rows(0)("VER")) Then

                            Me.VersionId = CType(DtAlertDetails.Rows(0)("VER"), Integer)

                            Try

                                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxVersion, DtAlertDetails.Rows(0)("VER"), False, True)

                            Catch ex As Exception
                            End Try


                            If Me.VersionId > 0 Then

                                Me.LoadBuild(Me.VersionId)

                            End If

                        End If

                        If IsDBNull(DtAlertDetails.Rows(0)("BUILD")) = False AndAlso IsNumeric(DtAlertDetails.Rows(0)("BUILD")) Then

                            Try

                                MiscFN.RadComboBoxSetIndex(Me.RadComboBoxBuild, DtAlertDetails.Rows(0)("BUILD"), False, True)

                            Catch ex As Exception
                            End Try

                        End If

                    Catch ex As Exception
                    End Try

                    ' Do we have HTML to show? If so, show it, if Not, shot the plain text.
                    Dim BodyText As String = ""
                    Dim BodyHTML As String = ""
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("BODY")) = False Then
                            BodyText = DtAlertDetails.Rows(0)("BODY").ToString()
                        End If
                    Catch ex As Exception
                        BodyText = ""
                    End Try
                    Try
                        If IsDBNull(DtAlertDetails.Rows(0)("BODY_HTML")) = False Then

                            BodyHTML = DtAlertDetails.Rows(0)("BODY_HTML") '.Replace(Environment.NewLine, "<br />")

                        End If
                    Catch ex As Exception
                        BodyHTML = String.Empty
                    End Try

                    If String.IsNullOrWhiteSpace(BodyHTML) = True Then

                        BodyHTML = BodyText.Replace(Environment.NewLine, "<br />")

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing Then

                            AdvantageFramework.AlertSystem.ExternalLinkToInternalLink(BodyHTML, Agency)

                        End If

                    End Using

                    Select Case Me.CurrentAlertTypeId
                        Case 6, 7, 16

                            _DeepLink.UrlToInternalLink(BodyHTML, Me.PlaceHolderDescriptionInternalLinks, AdvantageFramework.Web.DeepLink.LinkDisplay.ShowURL)
                            Me.RadEditorDescription.Html = BodyHTML
                            Me.LabelDescription.Text = ""

                            Me.RadEditorDescription.Visible = True

                        Case Else

                            _DeepLink.UrlToInternalLink(BodyHTML, Me.PlaceHolderDescriptionInternalLinks, AdvantageFramework.Web.DeepLink.LinkDisplay.Rename)
                            Me.LabelDescription.Text = BodyHTML
                            Me.RadEditorDescription.Html = ""

                            Me.RadEditorDescription.Visible = False

                    End Select

                    Me.LabelDescription.Visible = Not Me.RadEditorDescription.Visible

                    If Me.CurrentAlertTypeId = 8 AndAlso Me.LabelDescription.Visible = True AndAlso
                        String.IsNullOrWhiteSpace(Me.LabelDescription.Text) = False Then

                        Me.LabelDescription.Text = Me.LabelDescription.Text.Replace("Timesheet?sd=", "Employee/Timesheet?sd=")

                    End If

                    Select Case Me.CurrentAlertTypeId
                        Case 1, 2, 3, 4, 5, 8, 9, 12

                            Me.RadComboBoxCategory.Enabled = False
                            Me.RadComboBoxPriority.Enabled = False
                            Me.DivDueDateTimeDue.Visible = False
                            Me.BtnUpdateAlert.Visible = False
                            Me.TxtSubject.Text = ""
                            Me.LabelSubject.Text = DtAlertDetails.Rows(0)("SUBJECT").ToString()

                            Me.LabelSubject.Visible = True
                            Me.TxtSubject.Visible = False

                        Case 6, 7, 10, 16

                            Me.TxtSubject.Text = DtAlertDetails.Rows(0)("SUBJECT").ToString()
                            Me.LabelSubject.Text = ""

                            Me.LabelSubject.Visible = False
                            Me.TxtSubject.Visible = True

                            Me.BtnUpdateAlert.Visible = True

                    End Select

                    'New Notify/Assignment stuff:
                    Try
                        Dim ThisAlertNotifyHdrId As Integer = 0

                        'set template
                        Try
                            Try
                                If DtAlertDetails.Rows.Count > 0 AndAlso DtAlertDetails.Columns("ALRT_NOTIFY_HDR_ID") IsNot Nothing Then
                                    If Not DtAlertDetails.Rows(0)("ALRT_NOTIFY_HDR_ID") = Nothing Then
                                        If Not IsDBNull(DtAlertDetails.Rows(0)("ALRT_NOTIFY_HDR_ID")) Then
                                            ThisAlertNotifyHdrId = CType(DtAlertDetails.Rows(0)("ALRT_NOTIFY_HDR_ID"), Integer)
                                        End If
                                    End If
                                End If
                            Catch ex As Exception
                                ThisAlertNotifyHdrId = 0
                            End Try

                            Me.HiddenFieldAlertAssignmentTemplateID.Value = ThisAlertNotifyHdrId

                            If ThisAlertNotifyHdrId > 0 Then

                                Me.LabelAlertAssignmentTemplateName.Text = oAlerts.GetTemplateName(ThisAlertNotifyHdrId)

                            End If

                        Catch ex As Exception
                        End Try

                        'bind states,initially,only bind if it has a template selected
                        Try
                            If ThisAlertNotifyHdrId > 0 Then
                                Me.DivAssignment.Visible = True
                                Dim d As New DataTable
                                d = oAlerts.GetAlertStates("", "", ThisAlertNotifyHdrId)
                                Me.RadListBoxAlertAssignmentState.Items.Clear()
                                For i As Integer = 0 To d.Rows.Count - 1
                                    Dim nn As New Telerik.Web.UI.RadListBoxItem
                                    With nn
                                        .Text = d.Rows(i)("ALERT_STATE_NAME")
                                        .Value = d.Rows(i)("ALERT_STATE_ID")
                                    End With
                                    Me.RadListBoxAlertAssignmentState.Items.Add(nn)
                                Next
                            Else
                                Me.DivAssignment.Visible = False
                            End If
                        Catch ex As Exception
                        End Try

                        'set state
                        Dim ThisAlertStateId As Integer = 0
                        Try
                            If Not IsDBNull(DtAlertDetails.Rows(0)("ALERT_STATE_ID")) Then
                                ThisAlertStateId = CType(DtAlertDetails.Rows(0)("ALERT_STATE_ID"), Integer)
                            End If
                        Catch ex As Exception
                            ThisAlertStateId = 0
                        End Try

                        Try
                            If ThisAlertStateId > 0 And Me.RadListBoxAlertAssignmentState.Items.Count > 0 And Me.DivAssignment.Visible = True Then
                                Try
                                    Dim HasState As Boolean = False
                                    For Each Item As RadListBoxItem In Me.RadListBoxAlertAssignmentState.Items

                                        If Item.Value = ThisAlertStateId Then

                                            Item.Selected = True
                                            HasState = True
                                            Exit For

                                        End If

                                    Next
                                    If HasState = False Then 'add in inactive state if it is selected

                                        Try
                                            Dim DtInactive As New DataTable
                                            Dim a As New cAlerts()

                                            DtInactive = a.GetInactiveStateInUse(ThisAlertStateId)

                                            If Not DtInactive Is Nothing Then

                                                If DtInactive.Rows.Count > 0 Then

                                                    Dim InactiveNode As New Telerik.Web.UI.RadListBoxItem
                                                    With InactiveNode

                                                        .Text = DtInactive.Rows(0)("ALERT_STATE_NAME")
                                                        .Value = DtInactive.Rows(0)("ALERT_STATE_ID")
                                                        .Selected = True

                                                    End With

                                                    Me.RadListBoxAlertAssignmentState.Items.Add(InactiveNode)

                                                End If

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End If

                                Catch ex As Exception
                                End Try
                            End If

                        Catch ex As Exception
                        End Try

                        Try
                            'bind emps
                            If ThisAlertStateId > 0 And ThisAlertNotifyHdrId > 0 And Me.DivAssignment.Visible = True Then
                                Dim ThisASTID As Integer = ThisAlertStateId
                                With Me.RadComboBoxAssignTo
                                    .Items.Clear()
                                    .Text = ""
                                    .DataTextField = "EMP_FML"
                                    .DataValueField = "EMP_CODE"
                                    .DataSource = oAlerts.GetNotificationRecipients(ThisASTID, 0, 0, ThisAlertNotifyHdrId)
                                    .DataBind()
                                End With
                                Me.RadComboBoxAssignTo.Enabled = True

                                'set emp
                                Try
                                    CurrAssignEmp = oAlerts.GetCurrentNotifyAssignment(Me.CurrentAlertID)
                                    If CurrAssignEmp <> "" Then
                                        Me.IsAlertAssignment = True
                                        'If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                                        '    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAssignTo, CurrAssignEmp, False, True)
                                        'End If
                                        oAlerts.SetAssignmentComboBox(Me.RadComboBoxAssignTo, Me.CurrentAlertID)
                                        If CurrAssignEmp = Me._EmployeeCode Then
                                            Me.CurrentUserIsAssignEmp = True
                                        End If
                                    Else

                                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAssignTo, "unassigned", False)

                                    End If
                                Catch ex As Exception
                                    Me.IsAlertAssignment = False
                                    Me.CurrAssignEmp = ""
                                End Try
                            End If
                        Catch ex As Exception
                        End Try

                        ''''Try
                        ''''    Dim a As New Alert()
                        ''''    Me.CheckBoxEmailAssignmentOrigintorOverride_DontEmailMe.Checked = a.EmailAssignmentOrigintorOverride_DontEmailMe
                        ''''Catch ex As Exception
                        ''''End Try

                    Catch ex As Exception
                    End Try

                    'lock down if completed
                    Dim AssignmentIsCompleted As Boolean = False
                    Try
                        Dim a As New cAlerts()
                        If a.AssignmentIsCompleted(Me.CurrentAlertID) = True Then

                            AssignmentIsCompleted = True

                            Me.RadListBoxAlertAssignmentState.Enabled = False
                            With Me.RadComboBoxAssignTo
                                .Items.Clear()
                                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("COMPLETED", "COMPLETED"))
                                .Enabled = False
                            End With
                            Me.ButtonSendAssignment.Enabled = False
                            Me.LabelCompleted.Visible = True

                        Else

                            Me.LabelCompleted.Visible = False

                        End If
                    Catch ex As Exception
                    End Try

                    Dim IsCurrentlyAssigned As Boolean = False
                    Dim IsOriginator As Boolean = False

                    Try
                        If Me.IsAlertAssignment = True And AssignmentIsCompleted = False Then
                            Try
                                If CurrAssignEmp.Trim() = Me._EmployeeCode.ToString().Trim() Then
                                    IsCurrentlyAssigned = True
                                End If
                            Catch ex As Exception
                                IsCurrentlyAssigned = False
                            End Try
                            Try
                                If DtAlertDetails.Rows(0)("ALERT_USER") = Me._UserCode Then
                                    IsOriginator = True
                                End If
                            Catch ex As Exception
                                IsOriginator = False
                            End Try

                            If IsCurrentlyAssigned = True Or IsOriginator = True Or Me.GroupSettingsAlertInboxShowAllAssignments = True Or Me.GroupSettingsAlertInboxShowUnassignedAssignments = True Then

                                'Me.RadToolbarAlertView.FindItemByValue("Complete").Visible = True

                                Me.RadListBoxAlertAssignmentState.Enabled = True
                                Me.RadComboBoxAssignTo.Enabled = True
                                Me.ButtonSendAssignment.Enabled = True

                            Else

                                'Me.RadToolbarAlertView.FindItemByValue("Complete").Visible = False

                                Me.RadListBoxAlertAssignmentState.Enabled = False
                                Me.RadComboBoxAssignTo.Enabled = False
                                Me.ButtonSendAssignment.Enabled = False

                            End If
                        End If
                    Catch ex As Exception
                    End Try

                    If Me.IsAlertAssignment = True And IsCurrentlyAssigned = False Then

                        Me._IsAlertAssignmentCC = True

                    End If

                    Dim DismissButton As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("Dismiss")
                    DismissButton.CommandArgument = Nothing
                    If Me._IsMyAlert_Open = True Or Me._IsMyAlert_Dismissed = True Then

                        DismissButton.Visible = True

                        If Me._IsMyAlert_Open = True Then

                            DismissButton.Text = "Dismiss"
                            DismissButton.ToolTip = "Dismiss this alert"

                        End If
                        If Me._IsMyAlert_Dismissed = True Then

                            DismissButton.Text = "Un-dismiss"
                            DismissButton.ToolTip = "Un-dismiss this alert"

                        End If

                    Else

                        DismissButton.Visible = False

                    End If

                    If Me._IsMyAssignment_Open = True Or Me._IsMyAssignment_Completed = True Then

                        With DirectCast(Me.RadToolbarAlertView.FindItemByValue("Complete"), Telerik.Web.UI.RadToolBarButton)

                            .Visible = True

                            If Me._IsMyAssignment_Completed = True Then

                                .Text = "Re-open"
                                .ToolTip = "Re-open this assignment"

                            ElseIf Me._IsMyAssignment_Open Then

                                .Text = "Complete"
                                .ToolTip = "Complete this assignment"

                            Else

                                .Visible = False

                            End If

                        End With

                    Else

                        Me.RadToolbarAlertView.FindItemByValue("Complete").Visible = False

                    End If


                    Me.DivAssignment.Visible = Me.IsAlertAssignment

                    If Me.CurrentAlertTypeId = 6 OrElse Me.CurrentAlertTypeId = 7 Then

                        RadToolbarAlertView.FindItemByValue("RadToolBarSplitButtonCopy").Visible = True

                    Else

                        RadToolbarAlertView.FindItemByValue("RadToolBarSplitButtonCopy").Visible = False

                    End If

                End If

            End If
            If Not DtComments Is Nothing Then

                Me.LabelCommentsLegend.Text = "Comments&nbsp;(" & DtComments.Rows.Count().ToString() & ")"

            End If

            If Not DtRecipients Is Nothing Then

                Dim ShowButton As Boolean = False

                Me.RadGridRecipients.DataSource = DtRecipients.DefaultView
                Me.RadGridRecipients.DataBind()

                If DtRecipients.Rows.Count > 0 OrElse Me.IsAlertAssignment = True Then

                    ShowButton = True

                End If

                Me.RadToolbarAlertView.FindItemByValue("AlertRecipients").Enabled = ShowButton

            End If

            Me.ShowAlertNotificationWindow()
            DtRecipients.Dispose()
            DtAttachments.Dispose()
            DtComments.Dispose()
            DtMyAlert.Dispose()
            DtAlertDetails.Dispose()
            DtAlertDetails.Dispose()
            DsAlert.Dispose()

        Catch ex As Exception
            Me.ShowMessage("Could not load alert.\n" & ex.Message.ToString())
        End Try
    End Function
    Private Function LoadApproval()
        Try
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Me._ConnectionString)
            Dim dr As SqlDataReader
            dr = PO.GetPOApprData(Me._EmployeeCode, CurrentAlert.PO_NUMBER)
            If dr.HasRows = True Then
                Do While dr.Read
                    If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                        Me.TxtCommentApproval.Text = dr.GetString(5)
                    Else
                        Me.ApprovalRadEditor.Html = dr.GetString(5)
                    End If
                    If IsDBNull(dr("PO_APPROVAL_FLAG")) = False Then
                        If dr.GetBoolean(6) = True Then
                            Me.LabelApproved.Visible = True
                            Me.LabelApproved.Text = "APPROVED"
                            Me.RadToolbarAlertView.FindItemByValue("Approve").Enabled = False
                        ElseIf dr.GetBoolean(6) = False Then
                            Me.LabelApproved.Visible = True
                            Me.LabelApproved.Text = "DENIED"
                            Me.RadToolbarAlertView.FindItemByValue("Deny").Enabled = False
                        Else
                            Me.LabelApproved.Visible = False
                            Me.LabelApproved.Text = ""
                            Me.RadToolbarAlertView.FindItemByValue("Approve").Enabled = True
                            Me.RadToolbarAlertView.FindItemByValue("Deny").Enabled = True
                        End If
                    Else
                        Me.LabelApproved.Visible = False
                        Me.LabelApproved.Text = ""
                        Me.RadToolbarAlertView.FindItemByValue("Approve").Enabled = True
                        Me.RadToolbarAlertView.FindItemByValue("Deny").Enabled = True
                    End If

                Loop
            End If
        Catch ex As Exception

        End Try
    End Function
    Private Function getDefaultEmailGroup(ByVal level As String) As String
        Try
            'get email groups
            Dim oAlerts As cAlerts = New cAlerts(CStr(Me._ConnectionString))
            Dim JobNumber As Integer
            Dim JobComponentNumber As Integer
            Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Me._ConnectionString, Me._UserCode, HttpContext.Current)

            Dim DefaultGroupName As String = ""
            Select Case level
                Case "OF"
                    DefaultGroupName = ""
                Case "CL"
                    If Me.IsClientPortal = True Then
                        If CurrentAlert.PRD_CODE = "" Then
                            DefaultGroupName = _Session.ClientPortalUser.AlertGroupCode
                        Else
                            Dim JobRequestAlertGroup As String = agency.GetValue(AdvantageFramework.Agency.Settings.JR_DFLT_ALERT_GROUP, "")
                            If JobRequestAlertGroup <> "" Then
                                DefaultGroupName = JobRequestAlertGroup
                            Else
                                DefaultGroupName = _Session.ClientPortalUser.AlertGroupCode
                            End If
                        End If
                    Else
                        DefaultGroupName = "" 'oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, 0, 0)
                    End If
                Case "DI"
                    DefaultGroupName = "" 'oAlerts.GetDefaultGroup(Me.txtClient.Text.Trim, Me.txtDivision.Text.Trim, Me.txtProduct.Text.Trim, 0, 0)
                Case "PR"
                    DefaultGroupName = oAlerts.GetDefaultGroup(CurrentAlert.CL_CODE, CurrentAlert.DIV_CODE, CurrentAlert.PRD_CODE, 0, 0)
                Case "CM"
                    DefaultGroupName = ""
                Case "JC"
                    Dim ThisJobNum As Integer = 0
                    Dim ThisCompNum As Integer = 0
                    If IsNumeric(CurrentAlert.JOB_NUMBER) Then ThisJobNum = CType(CurrentAlert.JOB_NUMBER, Integer)
                    If IsNumeric(CurrentAlert.JOB_COMPONENT_NBR) Then ThisCompNum = CType(CurrentAlert.JOB_COMPONENT_NBR, Integer)
                    If ThisJobNum <> 0 And ThisCompNum <> 0 Then
                        'DefaultGroupName = oAlerts.GetDefaultGroup("", "", "", ThisJobNum, ThisCompNum)
                        DefaultGroupName = oAlerts.GetDefaultGroup(CurrentAlert.CL_CODE, CurrentAlert.DIV_CODE, CurrentAlert.PRD_CODE, ThisJobNum, ThisCompNum)

                    End If
            End Select
            Return DefaultGroupName
        Catch
            Err.Raise(Err.Number, "Error: Getting Default Group", Err.Description)
            Exit Function
        End Try
    End Function
    Private Sub GetRecipients()
        Try

            Dim i As Integer
            Dim cb As CheckBox
            Dim hf As System.Web.UI.WebControls.HiddenField
            Dim hfCP As System.Web.UI.WebControls.HiddenField

            Dim oAlerts As New cAlerts(Me._ConnectionString)

            If Me.AutoCompleteRecipients.Entries.Count > 0 Then

                Dim EmployeeCodeList As String = Me.GetCommaDelimitedStringOfEmployeeCodes()
                Dim ClientContactIdList As String = Me.GetCommaDelimitedStringOfClientContacts()

                Dim RecipientArray() As String
                Dim RecipientArrayCC() As String

                RecipientArray = EmployeeCodeList.Split(",")
                RecipientArrayCC = ClientContactIdList.Split(",")

                If Not RecipientArray Is Nothing Then

                    For i = 0 To RecipientArray.Length - 1

                        If RecipientArray(i) <> "" Then

                            If CurrentAlert.AlertCheckForDuplicates(CurrentAlertID, RecipientArray(i)) = False Then

                                CurrentAlert.AddAlertRecipient(RecipientArray(i))

                            End If

                        End If

                    Next

                End If

                If Not RecipientArrayCC Is Nothing Then

                    For i = 0 To RecipientArrayCC.Length - 1

                        If IsNumeric(RecipientArrayCC(i)) = True Then

                            Dim code As Integer = RecipientArrayCC(i) 'oAlerts.CPGetContactCodeID(RecipientArrayCC(i).ToString(), CurrentAlert.CL_CODE)
                            If CurrentAlert.AlertCPCheckForDuplicates(CurrentAlertID, code) = False Then

                                CurrentAlert.AddAlertRecipientCC(code)

                            End If

                        End If
                    Next

                End If

                Dim Employee As New cEmployee(Me._ConnectionString)

                If Not RecipientArray Is Nothing Then

                    For i = 0 To RecipientArray.Length - 1

                        If RecipientArray(i) <> "" Then

                            Dim EmailFlag As Integer = Employee.GetAlertEmailFlag(RecipientArray(i))

                            If EmailFlag = 1 Or EmailFlag = 3 Then

                                strEmails &= Employee.GetEmail(RecipientArray(i)) & ","
                                Me.EmployeeCodesForEmail &= RecipientArray(i) & ","

                            End If

                        End If

                    Next

                End If

                If Not RecipientArrayCC Is Nothing Then

                    For i = 0 To RecipientArrayCC.Length - 1

                        If IsNumeric(RecipientArrayCC(i)) = True Then

                            Dim codeID As Integer = RecipientArrayCC(i) 'oAlerts.CPGetContactCodeID(RecipientArrayCC(i).ToString(), CurrentAlert.CL_CODE)
                            If oAlerts.GetCPAlertEmailFlag(codeID) = 1 Then

                                strEmailsCP &= oAlerts.GetEmail(codeID) & ","
                                Me.ClientPortalIDsForEmail &= codeID & ","

                            End If

                        End If
                    Next

                End If

            End If

            Dim HfEmpCode As System.Web.UI.WebControls.HiddenField
            Dim HfIsContact As System.Web.UI.WebControls.HiddenField
            Dim HfAlertRcptID As System.Web.UI.WebControls.HiddenField

            For i = 0 To Me.RadGridRecipients.MasterTableView.Items.Count - 1

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridRecipients.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                cb = CType(CurrentGridRow.FindControl("cbSelectRecp"), CheckBox)

                If cb.Checked = True Then

                    hf = CType(CurrentGridRow.FindControl("hfEmail"), HiddenField)
                    HfEmpCode = CType(CurrentGridRow.FindControl("HiddenFieldEmpCode"), HiddenField)
                    HfIsContact = CType(CurrentGridRow.FindControl("HiddenFieldIsContact"), HiddenField)
                    HfAlertRcptID = CType(CurrentGridRow.FindControl("HiddenFieldAlertRptID"), HiddenField)

                    If hf.Value <> "" Then

                        strEmails &= hf.Value & ","

                    End If
                    If HfEmpCode.Value <> "" Then

                        Me.EmployeeCodesForEmail &= HfEmpCode.Value & ","

                    End If
                    If HfIsContact.Value = 1 Then

                        strEmailsCP &= hf.Value & ","
                        Me.ClientPortalIDsForEmail &= HfAlertRcptID.Value & ","

                    End If

                End If
            Next

        Catch ex As Exception
        End Try

    End Sub
    Private Sub LoadListCategories()

        'objects
        Dim AllowTaskCategory As Boolean = False
        Dim AllowStoryCategory As Boolean = False

        If Me.CurrentAlert IsNot Nothing Then

            Try

                If Me.CurrentAlert.ALRT_NOTIFY_HDR_ID > 0 Then

                    AllowStoryCategory = True

                End If

            Catch ex As Exception
                AllowStoryCategory = False
            End Try

            If Me.CurrentAlert.ALERT_CAT_ID = 71 Then

                AllowTaskCategory = True
                RadComboBoxCategory.Enabled = False

            ElseIf Me.CurrentAlert.ALERT_CAT_ID = 70 Then

                AllowStoryCategory = True
                RadComboBoxCategory.Enabled = False

            End If

        End If

        Try
            Dim a As New cAlerts()
            With Me.RadComboBoxCategory
                .DataSource = a.GetManualAlertCategories(AllowTaskCategory, AllowStoryCategory)
                .DataTextField = "ALERT_DESC"
                .DataValueField = "ALERT_CAT_ID"
                .DataBind()
            End With
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ReloadInfoPanel()
        Try
            Me.CurrentAlertID = CType(Request.QueryString("Alert"), Integer)
            Me.CurrentAlert = New Alert()
            Dim a As New cAlerts()
            If Me.CurrentAlert.LoadByPrimaryKey(Me.CurrentAlertID) = True Then

                Dim DsAlert As New DataSet
                Dim DtAlertDetails As New DataTable
                Dim oAlerts As New cAlerts()

                If Me.IsClientPortal = True Then
                    DsAlert = oAlerts.GetAlert(Me.CurrentAlert.ALERT_ID, Me._ClientPortalID)
                Else
                    DsAlert = oAlerts.GetAlert(Me.CurrentAlert.ALERT_ID)
                End If

                DtAlertDetails = DsAlert.Tables(0)

                If Not DtAlertDetails Is Nothing Then
                    If DtAlertDetails.Rows.Count > 0 Then
                        With Me.CurrentAlert
                            Try
                                If Me.RadComboBoxCategory.Items.Count > 0 Then
                                    Me.RadComboBoxCategory.FindItemByValue(DtAlertDetails.Rows(0)("ALERT_CAT_ID")).Selected = True
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If Me.RadComboBoxPriority.Items.Count > 0 Then
                                    Me.RadComboBoxPriority.FindItemByValue(.PRIORITY).Selected = True
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If Not DtAlertDetails.Rows(0)("DUE_DATE") = Nothing Then
                                    If cGlobals.wvIsDate(DtAlertDetails.Rows(0)("DUE_DATE")) = True Then
                                        Me.RadDatePickerDueDate.SelectedDate = Convert.ToDateTime(DtAlertDetails.Rows(0)("DUE_DATE")).ToShortDateString()
                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                            Try
                                If Not DtAlertDetails.Rows(0)("TIME_DUE") = Nothing Then
                                    If Not IsDBNull(DtAlertDetails.Rows(0)("TIME_DUE")) Then
                                        Me.TxtTimeDue.Text = DtAlertDetails.Rows(0)("TIME_DUE").ToString()
                                    End If
                                End If
                            Catch ex As Exception
                            End Try


                            ' Do we have HTML to show? If so, show it, if Not, shot the plain text.
                            If .BODY_HTML = "" Then
                                If .ALERT_TYPE_ID = 6 Then
                                    Me.RadEditorDescription.Html = DtAlertDetails.Rows(0)("BODY").ToString.Replace(vbCrLf, "<br />")
                                    Me.LabelDescription.Text = ""

                                    Me.RadEditorDescription.Visible = True
                                    Me.LabelDescription.Visible = False
                                Else
                                    Me.LabelDescription.Text = DtAlertDetails.Rows(0)("BODY").ToString.Replace(vbCrLf, "<br />")
                                    Me.RadEditorDescription.Html = ""

                                    Me.RadEditorDescription.Visible = False
                                    Me.LabelDescription.Visible = True
                                End If
                            Else
                                If .ALERT_TYPE_ID = 6 Then
                                    Me.RadEditorDescription.Html = .BODY_HTML
                                    Me.LabelDescription.Text = ""

                                    Me.RadEditorDescription.Visible = True
                                    Me.LabelDescription.Visible = False
                                Else
                                    Me.LabelDescription.Text = .BODY_HTML
                                    Me.RadEditorDescription.Html = ""

                                    Me.RadEditorDescription.Visible = False
                                    Me.LabelDescription.Visible = True
                                End If
                            End If

                            Me.TxtSubject.Text = .SUBJECT

                        End With

                    End If
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region
#Region " Update Data "

    Private Function UpdateRecipients(ByVal MarkAsNew As Boolean, Optional ByVal ResetCurrentEmployeeReadFlag As Boolean = True)
        Try
            Try
                Dim a As New cAlerts()
                Dim alertList As New AlertRecipient(Me._ConnectionString)
                Dim SbEmpCodeListChecked As New System.Text.StringBuilder
                Dim SbEmpCodeListUnChecked As New System.Text.StringBuilder
                Dim SbContactListChecked As New System.Text.StringBuilder
                Dim SbContactListUnChecked As New System.Text.StringBuilder
                Dim LeaveEmployeeCodeReadFlag As String = ""

                For i = 0 To Me.RadGridRecipients.MasterTableView.Items.Count - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridRecipients.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim cb As CheckBox
                    Dim HfEmpCode As System.Web.UI.WebControls.HiddenField
                    Dim HfIsContact As System.Web.UI.WebControls.HiddenField
                    Dim HfAlertRcptID As System.Web.UI.WebControls.HiddenField
                    cb = CType(CurrentGridRow.FindControl("cbSelectRecp"), CheckBox)
                    HfEmpCode = CType(CurrentGridRow.FindControl("HiddenFieldEmpCode"), HiddenField)
                    HfIsContact = CType(CurrentGridRow.FindControl("HiddenFieldIsContact"), HiddenField)
                    HfAlertRcptID = CType(CurrentGridRow.FindControl("HiddenFieldAlertRptID"), HiddenField)
                    If Not cb Is Nothing AndAlso cb.Checked = True Then
                        If HfIsContact.Value = 1 Then
                            With SbContactListChecked
                                .Append(HfAlertRcptID.Value.ToString().Trim().Replace("&nbsp;", ""))
                                .Append(",")
                            End With
                        Else
                            With SbEmpCodeListChecked
                                .Append("'")
                                .Append(HfEmpCode.Value.ToString().Trim().Replace("&nbsp;", ""))
                                .Append("'")
                                .Append(",")
                            End With
                        End If
                    Else
                        If HfIsContact.Value = 1 Then
                            With SbContactListUnChecked
                                .Append(HfAlertRcptID.Value.ToString().Trim().Replace("&nbsp;", ""))
                                .Append(",")
                            End With
                        Else
                            With SbEmpCodeListUnChecked
                                .Append("'")
                                .Append(HfEmpCode.Value.ToString().Trim().Replace("&nbsp;", ""))
                                .Append("'")
                                .Append(",")
                            End With
                        End If
                    End If
                Next
                Dim StrEmpCodeListChecked As String = ""
                StrEmpCodeListChecked = MiscFN.CleanStringForSplit(SbEmpCodeListChecked.ToString(), ",")

                Dim StrEmpCodeListUnChecked As String = ""
                StrEmpCodeListUnChecked = MiscFN.CleanStringForSplit(SbEmpCodeListUnChecked.ToString(), ",")

                If Not ResetCurrentEmployeeReadFlag Then

                    LeaveEmployeeCodeReadFlag = Me.SecuritySession.User.EmployeeCode

                End If

                a.UpdateAlertRecipients(Me.CurrentAlertID, StrEmpCodeListChecked, StrEmpCodeListUnChecked, MarkAsNew, LeaveEmployeeCodeReadFlag)

                Dim StrContactListChecked As String = ""
                StrContactListChecked = MiscFN.CleanStringForSplit(SbContactListChecked.ToString(), ",")

                Dim StrContactListUnChecked As String = ""
                StrContactListUnChecked = MiscFN.CleanStringForSplit(SbContactListUnChecked.ToString(), ",")

                a.UpdateAlertRecipientsCP(Me.CurrentAlertID, StrContactListChecked, StrContactListUnChecked, MarkAsNew)

            Catch ex As Exception
            End Try

        Catch ex As Exception

        End Try

    End Function

    Private Function UpdateInformation(ByVal ShowMsg As Boolean) As Boolean

        Try

            If Me.BtnUpdateAlert.Visible = True Then

                Dim DueDate As String = ""

                If Me.TxtSubject.Visible = True And Me.TxtSubject.Enabled = True Then

                    If Me.TxtSubject.Text.Trim() = "" Then

                        Me.FocusControl(Me.TxtSubject)
                        Me.ShowMessage("Subject is required")
                        Return False

                    End If

                End If

                If MiscFN.ValidDate(Me.RadDatePickerDueDate, True) = False Then

                    Me.ShowMessage("Invalid due date")
                    Return False

                Else

                    Try

                        DueDate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()

                    Catch ex As Exception
                        DueDate = String.Empty
                    End Try

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try
                        Dim a As New cAlerts(Me._ConnectionString)
                        Dim FxAlert As AdvantageFramework.Database.Entities.Alert
                        Dim s As String = String.Empty
                        Dim UserId As Integer = 0

                        If Me.IsClientPortal = True Then

                            UserId = Me._ClientPortalID

                        End If

                        FxAlert = Nothing
                        FxAlert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.CurrentAlertID)

                        If FxAlert IsNot Nothing Then

                            Dim Changed As Boolean = False

                            If FxAlert.Subject IsNot Nothing AndAlso FxAlert.Subject.Equals(Me.TxtSubject.Text, System.StringComparison.InvariantCultureIgnoreCase) = False Then

                                FxAlert.Subject = Me.TxtSubject.Text
                                Changed = True

                            End If
                            If FxAlert.Body IsNot Nothing AndAlso FxAlert.Body.Equals(Me.RadEditorDescription.Text, System.StringComparison.InvariantCultureIgnoreCase) = False Then

                                FxAlert.Body = Me.RadEditorDescription.Text
                                Changed = True

                            End If
                            If FxAlert.EmailBody IsNot Nothing AndAlso FxAlert.EmailBody.Equals(Me.RadEditorDescription.Html, System.StringComparison.InvariantCultureIgnoreCase) = False Then

                                FxAlert.EmailBody = Me.RadEditorDescription.Html
                                Changed = True

                            End If
                            If FxAlert.PriorityLevel IsNot Nothing AndAlso FxAlert.PriorityLevel IsNot Nothing AndAlso FxAlert.PriorityLevel <> Me.RadComboBoxPriority.SelectedValue Then

                                FxAlert.PriorityLevel = Me.RadComboBoxPriority.SelectedValue
                                Changed = True

                            End If

                            If Me.RadDatePickerStartDate.SelectedDate IsNot Nothing Then

                                If FxAlert.StartDate Is Nothing Then

                                    FxAlert.StartDate = Me.RadDatePickerStartDate.SelectedDate
                                    Changed = True

                                Else

                                    If CDate(FxAlert.StartDate).ToShortDateString <> CDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString Then

                                        FxAlert.StartDate = Me.RadDatePickerStartDate.SelectedDate
                                        Changed = True

                                    End If

                                End If

                                FxAlert.StartDate = Me.RadDatePickerStartDate.SelectedDate

                            Else

                                If FxAlert.StartDate IsNot Nothing Then

                                    FxAlert.StartDate = Nothing
                                    Changed = True

                                End If

                            End If
                            If Me.RadDatePickerDueDate.SelectedDate IsNot Nothing Then

                                If FxAlert.DueDate Is Nothing Then

                                    FxAlert.DueDate = Me.RadDatePickerDueDate.SelectedDate
                                    Changed = True

                                Else

                                    If CDate(FxAlert.DueDate).ToShortDateString <> CDate(Me.RadDatePickerDueDate.SelectedDate).ToShortDateString Then

                                        FxAlert.DueDate = Me.RadDatePickerDueDate.SelectedDate
                                        Changed = True

                                    End If

                                End If

                                FxAlert.DueDate = Me.RadDatePickerDueDate.SelectedDate

                            Else

                                If FxAlert.DueDate IsNot Nothing Then

                                    FxAlert.DueDate = Nothing
                                    Changed = True

                                End If

                            End If

                            If FxAlert.StartDate IsNot Nothing AndAlso FxAlert.DueDate IsNot Nothing Then

                                If FxAlert.StartDate > FxAlert.DueDate Then

                                    Me.ShowMessage("Due date is before start date")
                                    Return False

                                End If

                            End If

                            Try
                                If Me.TxtTimeDue.Text <> FxAlert.TimeDue Then

                                    FxAlert.TimeDue = Me.TxtTimeDue.Text
                                    Changed = True

                                End If

                            Catch ex As Exception

                            End Try
                            If Me.RadComboBoxCategory.SelectedValue IsNot Nothing AndAlso IsNumeric(Me.RadComboBoxCategory.SelectedValue) Then

                                If FxAlert.AlertCategoryID <> CType(Me.RadComboBoxCategory.SelectedValue, Integer) Then

                                    FxAlert.AlertCategoryID = CType(Me.RadComboBoxCategory.SelectedValue, Integer)
                                    Changed = True

                                End If

                            End If
                            Dim HasVersion As Boolean = False
                            Try

                                Dim SelectedVersionID As Integer = 0
                                Dim OldVersionID As Integer = 0
                                Try

                                    If Me.RadComboBoxVersion.SelectedValue IsNot Nothing AndAlso IsNumeric(Me.RadComboBoxVersion.SelectedValue) = True Then

                                        SelectedVersionID = CType(Me.RadComboBoxVersion.SelectedValue, Integer)

                                    End If

                                Catch ex As Exception
                                    SelectedVersionID = 0
                                End Try
                                Try

                                    If String.IsNullOrWhiteSpace(FxAlert.Version) = False AndAlso IsNumeric(FxAlert.Version) = True Then

                                        OldVersionID = CType(FxAlert.Version, Integer)

                                    End If

                                Catch ex As Exception
                                    OldVersionID = 0
                                End Try

                                If OldVersionID = 0 AndAlso SelectedVersionID > 0 Then

                                    FxAlert.Version = SelectedVersionID
                                    HasVersion = True
                                    Changed = True

                                ElseIf OldVersionID > 0 AndAlso SelectedVersionID = 0 Then

                                    FxAlert.Version = ""
                                    Changed = True

                                ElseIf OldVersionID > 0 AndAlso SelectedVersionID > 0 Then

                                    If OldVersionID <> SelectedVersionID Then

                                        FxAlert.Version = SelectedVersionID
                                        HasVersion = True
                                        Changed = True

                                    End If

                                End If

                                If OldVersionID > 0 OrElse SelectedVersionID > 0 Then

                                    HasVersion = True

                                End If

                            Catch ex As Exception
                            End Try

                            If HasVersion = True Then

                                Try

                                    Dim SelectedBuildID As Integer = 0
                                    Dim OldBuildID As Integer = 0
                                    Try

                                        If Me.RadComboBoxBuild.SelectedValue IsNot Nothing AndAlso IsNumeric(Me.RadComboBoxBuild.SelectedValue) = True Then

                                            SelectedBuildID = CType(Me.RadComboBoxBuild.SelectedValue, Integer)

                                        End If

                                    Catch ex As Exception
                                        SelectedBuildID = 0
                                    End Try
                                    Try

                                        If String.IsNullOrWhiteSpace(FxAlert.Build) = False AndAlso IsNumeric(FxAlert.Build) = True Then

                                            OldBuildID = CType(FxAlert.Build, Integer)

                                        End If

                                    Catch ex As Exception
                                        OldBuildID = 0
                                    End Try

                                    If OldBuildID = 0 AndAlso SelectedBuildID > 0 Then

                                        FxAlert.Build = SelectedBuildID
                                        Changed = True

                                    ElseIf OldBuildID > 0 AndAlso SelectedBuildID = 0 Then

                                        FxAlert.Build = ""
                                        Changed = True

                                    ElseIf OldBuildID > 0 AndAlso SelectedBuildID > 0 Then

                                        If OldBuildID <> SelectedBuildID Then

                                            FxAlert.Build = SelectedBuildID
                                            Changed = True

                                        End If

                                    End If

                                Catch ex As Exception
                                End Try

                            Else

                                FxAlert.Build = ""

                            End If

                            If Changed = True Then

                                Return AdvantageFramework.Database.Procedures.Alert.Update(DbContext, FxAlert)
                                's = a.UpdateAlert(Me.CurrentAlertID,
                                '                  FxAlert.Subject, Me.TxtSubject.Text,
                                '                  FxAlert.Body, Me.RadEditorDescription.Text,
                                '                  FxAlert.EmailBody, Me.RadEditorDescription.Html,
                                '                  FxAlert.PriorityLevel, Me.RadComboBoxPriority.SelectedValue,
                                '                  FxAlert.DueDate, DueDate,
                                '                  FxAlert.TimeDue, Me.TxtTimeDue.Text,
                                '                  FxAlert.AlertCategoryID, Me.RadComboBoxCategory.SelectedValue,
                                '                  "", "",
                                '                  FxAlert.Version, Me.RadComboBoxVersion.SelectedValue,
                                '                  FxAlert.Build, Me.RadComboBoxBuild.SelectedValue,
                                '                  UserId)

                                If String.IsNullOrWhiteSpace(s) = False AndAlso s = "" AndAlso ShowMsg = True Then

                                    Me.ShowMessage("No changes made")
                                    Return False

                                End If

                            Else

                                Return True

                            End If

                        End If

                    Catch ex As Exception
                        Return False
                    End Try

                End Using

                Return True

            Else

                Return True

            End If

        Catch ex As Exception
            Return True
        End Try

    End Function

#End Region
#Region " Send Alert "

    Private Function AlertRecipients(ByVal IncludeOriginator As Boolean, Optional ByVal ResetCurrentEmployeeReadFlag As Boolean = True) As Boolean
        Try

            Dim ResetAssignedToEmployeeCodeReadFlag As Boolean = True
            Dim CurrentAssigneeEmployeeCode As String = ""

            Me.GetRecipients()
            Me.UpdateRecipients(True, ResetCurrentEmployeeReadFlag)

            strEmails = MiscFN.RemoveTrailingDelimiter(strEmails, ",")

            If Me.RadComboBoxAssignTo.SelectedIndex > 0 Then

                Me.EmployeeCodeOfAlertAssignment = Me.RadComboBoxAssignTo.SelectedValue

            End If

            If Me.EmployeeCodesForEmail <> "" Then
                Me.EmployeeCodesForEmail = Me.EmployeeCodesForEmail & "," & Me.EmployeeCodeOfAlertAssignment
            Else
                Me.EmployeeCodesForEmail = Me.EmployeeCodeOfAlertAssignment
            End If

            Me.strEmails = MiscFN.CleanStringForSplit(strEmails, ",")
            Me.EmployeeCodesForEmail = MiscFN.CleanStringForSplit(Me.EmployeeCodesForEmail, ",")
            Me.strEmailsCP = MiscFN.CleanStringForSplit(strEmailsCP, ",")
            Me.ClientPortalIDsForEmail = MiscFN.CleanStringForSplit(Me.ClientPortalIDsForEmail, ",")

            If ResetCurrentEmployeeReadFlag = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        CurrentAssigneeEmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ASSIGNED_EMP_CODE FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", Me.CurrentAlertID)).FirstOrDefault()

                    Catch ex As Exception
                        CurrentAssigneeEmployeeCode = String.Empty
                    End Try

                End Using

                If String.IsNullOrWhiteSpace(CurrentAssigneeEmployeeCode) = False Then

                    If CurrentAssigneeEmployeeCode = Me.SecuritySession.User.EmployeeCode Then

                        ResetAssignedToEmployeeCodeReadFlag = False

                    End If

                End If


            End If

            Dim eso As New EmailSessionObject(Me._ConnectionString,
                                              Me._UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = Me.CurrentAlertID
                .Subject = "[Alert Updated]"
                .EmployeeCodesToSendEmailTo = Me.EmployeeCodesForEmail
                .ClientPortalEmailAddressessToSendTo = strEmailsCP
                .IsClientPortal = Me.IsClientPortal
                .IncludeOriginator = IncludeOriginator
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .ResetAssignedToEmployeeCodeReadFlag = ResetAssignedToEmployeeCodeReadFlag
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Me.GetCommaDelimitedStringOfEmployeeCodes()
            Me.strEmails = ""
            Me.strEmailsCP = ""
            Me.EmployeeCodesForEmail = ""

            Me.RadGridRecipients.Rebind()

            Return True

        Catch ex As Exception

            Me.ShowMessage("Error occurred sending mail.  " & ex.Message)
            Return False

        End Try
    End Function

#End Region
#Region " Approval "

    Private Function addCommentApproval(ByVal approve As Boolean)
        ' Just exit out if the user did not enter anything in the CommentsTextBox
        'If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
        '    If Me.TxtCommentApproval.Text = "" Then
        '        Exit Function
        '    End If
        'Else
        '    If Me.ApprovalRadEditor.Text.Trim = "" Then
        '        Exit Function
        '    End If
        'End If


        Try
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Me._ConnectionString)
            Dim alertComment As New AlertComment(Me._ConnectionString)
            Dim newrev As Integer
            Dim dr As SqlDataReader
            dr = PO.GetPOApprData(Me._EmployeeCode, CurrentAlert.PO_NUMBER)
            Dim eso As New EmailSessionObject(Me._ConnectionString,
                                              Me._UserCode,
                                              Me._Session,
                                              HttpContext.Current.Session("WebvantageURL"),
                                              HttpContext.Current.Session("ClientPortalURL"))
            Dim alertid As Integer
            If dr.HasRows = True Then
                Do While dr.Read
                    If approve = True Then
                        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                            If Me.TxtCommentApproval.Text <> "" Then
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Approved - " & Me.TxtCommentApproval.Text)
                            Else
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Approved")
                            End If
                            PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), True, Me._UserCode, Now, Me.TxtCommentApproval.Text)
                            alertid = Me.sendAlertApproval(dr.GetInt32(0), True, Me.TxtCommentApproval.Text)
                            If alertid > 0 Then

                                With eso

                                    .AlertId = alertid
                                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                    .Send()

                                End With

                                Me.CheckForAsyncMessage()

                            End If
                        Else
                            If Me.ApprovalRadEditor.Html <> "" Then
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Approved - " & Me.ApprovalRadEditor.Html)
                            Else
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Approved")
                            End If
                            PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), True, Me._UserCode, Now, Me.ApprovalRadEditor.Html)
                            alertid = Me.sendAlertApproval(dr.GetInt32(0), True, Me.ApprovalRadEditor.Html)
                            If alertid > 0 Then

                                With eso

                                    .AlertId = alertid
                                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                    .Send()

                                End With

                                Me.CheckForAsyncMessage()

                            End If
                        End If
                        Me.LabelApproved.Visible = True
                        Me.LabelApproved.Text = "APPROVED"
                        Me.RadToolbarAlertView.FindItemByValue("Approve").Enabled = False
                        Me.RadToolbarAlertView.FindItemByValue("Deny").Enabled = True
                    Else
                        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                            If Me.TxtCommentApproval.Text <> "" Then
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Denied - " & Me.TxtCommentApproval.Text)
                            Else
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Denied")
                            End If
                            PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), False, Me._UserCode, Now, Me.TxtCommentApproval.Text)
                            alertid = Me.sendAlertApproval(dr.GetInt32(0), False, Me.TxtCommentApproval.Text)
                            If alertid > 0 Then

                                With eso

                                    .AlertId = alertid
                                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                    .Send()

                                End With

                                Me.CheckForAsyncMessage()

                            End If
                        Else
                            If Me.ApprovalRadEditor.Html <> "" Then
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Denied - " & Me.ApprovalRadEditor.Html)
                            Else
                                alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, "Denied")
                            End If
                            PO.UpdatePOApproval(dr.GetInt32(0), dr.GetString(1), dr.GetInt16(2), dr.GetInt32(3), False, Me._UserCode, Now, Me.ApprovalRadEditor.Html)
                            alertid = Me.sendAlertApproval(dr.GetInt32(0), False, Me.ApprovalRadEditor.Html)
                            If alertid > 0 Then

                                With eso

                                    .AlertId = alertid
                                    .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                    .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                    .Send()

                                End With

                                Me.CheckForAsyncMessage()

                            End If
                        End If

                        'newrev = PO.Increment_PO_Revision(1, CurrentAlert.PO_NUMBER)
                        Me.LabelApproved.Visible = True
                        Me.LabelApproved.Text = "DENIED"
                        Me.RadToolbarAlertView.FindItemByValue("Deny").Enabled = False
                        Me.RadToolbarAlertView.FindItemByValue("Approve").Enabled = True
                    End If
                Loop
            Else
                Me.ShowMessage("Approval has been resubmitted or canceled")
            End If

        Catch ex As Exception
            'Throw ex
            Me.ShowMessage("Could add comment.\n" & ex.Message.ToString())
        End Try

    End Function

    Private Function sendAlertApproval(ByVal PONum As Integer, ByVal approve As Boolean, ByVal notes As String)
        Try
            Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                Dim FxAlert As New AdvantageFramework.Database.Entities.Alert
                'Dim Alert As New Alert(Me._ConnectionString)
                Dim alertComment As New AlertComment(Me._ConnectionString)
                Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Me._ConnectionString)
                POHeader.Select_POHeader(PONum, "")
                Dim dr As SqlDataReader
                Dim strBody As String
                Dim usercode As String
                Dim username As String

                With FxAlert

                    .AlertTypeID = 3 'Approvals
                    .AlertCategoryID = 39

                    If approve = True Then
                        .Subject = "PO Approved - " & POHeader.Vendor_Name & " - " & POHeader.PO_Description
                    Else
                        .Subject = "PO Approval Denied - " & POHeader.Vendor_Name & " - " & POHeader.PO_Description
                    End If
                    If POHeader.PO_Revision > 0 Then
                        .Subject &= " Revision: " & POHeader.PO_Revision
                    End If

                    strBody &= "--------------------------------------" & vbCrLf
                    strBody &= "Purchase Order Details:" & vbCrLf
                    strBody &= "--------------------------------------" & vbCrLf

                    strBody &= "PO Number: <a href='purchaseorder.aspx?po_number=" & AdvantageFramework.Security.Encryption.EncryptPO(PONum.ToString()) & "&pagemode=edit'>Click here to view this Purchase Order.</a>" & vbCrLf
                    strBody &= "PO Description: " & POHeader.PO_Description & vbCrLf
                    strBody &= "Issued By: " & POHeader.Issue_By_Emp_Name & vbCrLf
                    strBody &= "Issued To: " & POHeader.Vendor_Name & vbCrLf
                    strBody &= "Total PO Amount: " & String.Format("{0:#,##0.00}", POHeader.PO_Total) & vbCrLf
                    strBody &= "Employee's Limit: " & String.Format("{0:#,##0.00}", POHeader.Get_PO_Emp_Limit(1, POHeader.Issue_By_Emp_Code, usercode, username)) & vbCrLf
                    If POHeader.PO_Revision > 0 Then
                        strBody &= "PO Revision: " & POHeader.PO_Revision & vbCrLf
                    End If
                    strBody &= "Notes: " & notes & vbCrLf

                    dr = POHeader.GetPOApprDataByPO(PONum)
                    If dr.HasRows = True Then
                        strBody &= "" & vbCrLf
                        strBody &= "Approvals needed: " & vbCrLf
                        Do While dr.Read
                            strBody &= dr.GetString(6) & ": "
                            If IsDBNull(dr("PO_APPROVAL_FLAG")) = False Then
                                If dr.GetBoolean(5) = True Then
                                    strBody &= "Approved" & vbCrLf
                                ElseIf dr.GetBoolean(5) = False Then
                                    strBody &= "Denied" & vbCrLf
                                Else
                                    strBody &= "Pending" & vbCrLf
                                End If
                            Else
                                strBody &= "Pending" & vbCrLf
                            End If
                        Loop
                    End If

                    .Body = strBody
                    .GeneratedDate = Now
                    .LastUpdated = Now
                    .PriorityLevel = 3
                    .PONumber = CInt(PONum)
                    .EmployeeCode = Me._EmployeeCode
                    .AlertLevel = "NA"
                    .UserCode = Me._UserCode

                End With

                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, FxAlert) = True Then

                    Dim Alert As New Alert(Me._ConnectionString)
                    Alert.LoadByPrimaryKey(FxAlert.ID)

                    If approve = True Then
                        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                            alertComment.AddNewComment(Alert.ALERT_ID, Me._UserCode, "Approved - " & Me.TxtCommentApproval.Text)
                        Else
                            alertComment.AddNewComment(Alert.ALERT_ID, Me._UserCode, "Approved - " & Me.ApprovalRadEditor.Html)
                        End If
                    Else
                        If MiscFN.BrowserTypeIs(MiscFN.Browser_Types.Safari) = True Then
                            alertComment.AddNewComment(Alert.ALERT_ID, Me._UserCode, "Denied - " & Me.TxtCommentApproval.Text)
                        Else
                            alertComment.AddNewComment(Alert.ALERT_ID, Me._UserCode, "Denied - " & Me.ApprovalRadEditor.Html)
                        End If
                    End If
                    Alert.AddAlertRecipient(POHeader.Issue_By_Emp_Code)

                Else

                    Me.ShowMessage("Alert failed to save")

                End If

                Return FxAlert.ID

            End Using
        Catch ex As Exception
            Me.ShowMessage("Could add alert.\n" & ex.Message.ToString())
        End Try
    End Function

#End Region
#Region " Version & Build "

    Private Sub LoadVersionAndBuild()
        Try
            Me.DivVersionBuild.Visible = False
            If Me.JobNumber = 0 Then
                If IsNumeric(Me.HiddenFieldJobNumber.Value) = True Then
                    Me.JobNumber = CType(Me.HiddenFieldJobNumber.Value, Integer)
                End If
            End If
            If Me.JobComponentNumber = 0 Then
                If IsNumeric(Me.HiddenFieldJobComponentNbr.Value) = True Then
                    Me.JobComponentNumber = CType(Me.HiddenFieldJobComponentNbr.Value, Integer)
                End If
            End If

            If Me.JobNumber = 0 Then Exit Sub

            Dim a As New cAlerts()
            Dim DtVersions As New DataTable

            DtVersions = a.GetSoftwareVersions(Me.JobNumber, Me.JobComponentNumber)

            If DtVersions.Rows.Count = 0 Then
                Exit Sub
            Else
                Me.DivVersionBuild.Visible = True
                With Me.RadComboBoxVersion
                    .DataSource = DtVersions
                    .DataTextField = "VERSION"
                    .DataValueField = "VERSION_ID"
                    .DataBind()
                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                End With
                With Me.RadComboBoxBuild
                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                    .Enabled = False
                End With
            End If
        Catch ex As Exception
            Me.DivVersionBuild.Visible = False
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadBuild(ByVal VersionId As Integer)
        Dim a As New cAlerts()
        If VersionId = 0 Then
            With Me.RadComboBoxBuild
                .Items.Clear()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                .Enabled = False
            End With
        Else
            With Me.RadComboBoxBuild
                .Items.Clear()
                .DataSource = a.GetSoftwareBuilds(VersionId)
                .DataTextField = "BUILD"
                .DataValueField = "BUILD_ID"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
                .Enabled = True
            End With
        End If
    End Sub

    Private Sub RadComboBoxVersion_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxVersion.SelectedIndexChanged
        Me.LoadBuild(CType(Me.RadComboBoxVersion.SelectedValue, Integer))
    End Sub

#End Region
#Region " Comments RadWindow "

    'Private Sub ImageButtonCommentPopUpSendAssignment_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonCommentPopUpSendAssignment.Click

    '    SendAssignment(True)

    'End Sub
    Private Sub ImageButtonCommentPopUpStandardComment_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonCommentPopUpStandardComment.Click

        If Me.UpdateInformation(False) = False Then Exit Sub
        Me.HiddenFieldSendAssignmentClicked.Value = 0
        Me._CommentFromToolbar = True
        Me.ButtonCommentSave.Text = "Add"
        Me.HiddenFieldAddComment.Value = 1
        If String.IsNullOrWhiteSpace(RadTextBoxStandardComment.Text) = False Then
            RadEditorComment.Content = RadTextBoxStandardComment.Text
        End If
        Me.ButtonCommentSendAssignment.Visible = False
        Me.CommentWindowOpen()

        'Dim CommentQueryString As New AdvantageFramework.Web.QueryString

        'CommentQueryString.Page = "Alert_Comment_Editor.aspx"
        'CommentQueryString.AlertId = Me.CurrentAlertID
        'CommentQueryString.Add("Type", "0")
        'CommentQueryString.Add("control", "")
        ''CommentQueryString.Add("opener", Me.PageFilename())

        'Me.OpenWindow("", CommentQueryString.ToString(True), 600, 1050)

    End Sub

    Private Sub ImageButtonCommentPopUpSendAssignment_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonCommentPopUpSendAssignment.Click

        If Me.UpdateInformation(False) = False Then Exit Sub
        Me.HiddenFieldSendAssignmentClicked.Value = 0
        Me._CommentFromToolbar = True
        Me.ButtonCommentSave.Text = "Ok"
        Me.HiddenFieldAddComment.Value = 0
        If RadEditorAssignmentComment.Content <> "" Then
            RadEditorComment.Content = Me.RadEditorAssignmentComment.Content
        End If
        Me.ButtonCommentSendAssignment.Visible = True
        Me.CommentWindowOpen()

        'Dim CommentQueryString As New AdvantageFramework.Web.QueryString

        'CommentQueryString.Page = "Alert_Comment_Editor.aspx"
        'CommentQueryString.AlertId = Me.CurrentAlertID
        'CommentQueryString.Add("Type", "1")
        'CommentQueryString.Add("control", Me.RadEditorAssignmentComment.ClientID)
        'CommentQueryString.Add("opener", Me.PageFilename())

        'Me.OpenWindow("", CommentQueryString.ToString(True), 600, 1050, False, True)

    End Sub

    Private Sub CommentWindowOpen()
        With Me.RadWindowAlertComment
            .VisibleOnPageLoad = True
            .Visible = True
        End With
    End Sub
    Private Sub CommentWindowClose()
        Me.RadEditorComment.Content = ""
        With Me.RadWindowAlertComment
            .VisibleOnPageLoad = False
            .Visible = False
        End With
        Me.HiddenFieldSendAssignmentClicked.Value = 0
    End Sub

    Private Sub ButtonCommentCancel_Click(sender As Object, e As System.EventArgs) Handles ButtonCommentCancel.Click

        Me.CommentWindowClose()

    End Sub

    Private Sub ButtonCommentSave_Click(sender As Object, e As System.EventArgs) Handles ButtonCommentSave.Click

        'objects
        Dim LastAlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

        Try
            Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
            If rtb IsNot Nothing Then Me.CloseAfterCommentOrReAssign = rtb.Checked
        Catch ex As Exception
        End Try

        If Me.CurrentAlertID > 0 Then

            Dim StrComment As String = Me.RadEditorComment.Content.Replace(Environment.NewLine, "")

            If IsAlertAssignment = True And Me.HiddenFieldAddComment.Value = 0 Then 'assignment/notify comment

                Me.CommentWindowClose()

                If Me.CurrentAlertID > 0 Then

                    'Me.LoadAlert()
                    Me.RadEditorAssignmentComment.Content = StrComment
                    'Me.RefreshAlertWindows(False)

                End If

            Else 'normal alert comment

                If StrComment = "" Or StrComment = "<br>" Then

                    Me.ShowMessage("Please enter a comment")
                    Exit Sub

                Else

                    Dim alertComment As New AlertComment(CStr(Me._ConnectionString))
                    If StrComment.Trim() <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Try

                                LastAlertComment = (From Item In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, Me.CurrentAlertID)
                                                    Order By Item.GeneratedDate Descending, Item.ID Descending
                                                    Select Item).FirstOrDefault

                            Catch ex As Exception

                            End Try

                            If LastAlertComment IsNot Nothing Then

                                LastAlertComment.CustodyEnd = Now
                                AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, LastAlertComment)

                            End If

                        End Using

                        If Me.IsClientPortal = True Then

                            alertComment.AddNewComment(Me.CurrentAlertID, "", StrComment, Me._ClientPortalID)

                        Else

                            alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, StrComment)

                        End If

                    End If

                    If Me.AlertRecipients(Me._CommentFromToolbar) = False Then

                        Exit Sub

                    End If

                End If

                Me.CommentWindowClose()

                If Me.CurrentAlertID > 0 Then

                    If Me.CloseAfterCommentOrReAssign = False Then


                        Me.RadEditorAssignmentComment.Content = Nothing
                        Me.LoadAlert()
                        Me.RefreshAlertWindows(False)
                        'Me.RefreshByRedirect()

                    Else

                        Me.CloseRefreshAction()

                    End If


                End If

            End If


        End If
    End Sub

    Private Sub ButtonCommentSendAssignment_Click(sender As Object, e As System.EventArgs) Handles ButtonCommentSendAssignment.Click
        Try
            Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
            If rtb IsNot Nothing Then Me.CloseAfterCommentOrReAssign = rtb.Checked
        Catch ex As Exception
        End Try

        If Me.CurrentAlertID > 0 Then

            Dim StrComment As String = Me.RadEditorComment.Content

            If IsAlertAssignment = True And Me.HiddenFieldAddComment.Value = 0 Then 'assignment/notify comment

                Me.CommentWindowClose()

                Me.RadEditorAssignmentComment.Content = StrComment

                SendAssignment(False)

            End If


        End If

    End Sub

    Private Sub ImageButtonAddStandardComment_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAddStandardComment.Click

        Try
            Dim rtb As RadToolBarButton = Me.RadToolbarAlertView.FindItemByValue("CloseAlert")
            If rtb IsNot Nothing Then Me.CloseAfterCommentOrReAssign = rtb.Checked
        Catch ex As Exception
        End Try

        If Me.CurrentAlertID > 0 Then

            Dim StrComment As String = Me.RadTextBoxStandardComment.Text

            If String.IsNullOrWhiteSpace(StrComment) Then

                Me.ShowMessage("Please enter a comment")
                Exit Sub

            Else

                Dim Saved As Boolean = False
                Dim alertComment As New AlertComment(CStr(Me._ConnectionString))
                Dim LastAlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

                If StrComment.Trim() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Try

                            LastAlertComment = (From Item In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, Me.CurrentAlertID)
                                                Order By Item.GeneratedDate Descending, Item.ID Descending
                                                Select Item).FirstOrDefault

                        Catch ex As Exception

                        End Try

                        If LastAlertComment IsNot Nothing Then

                            LastAlertComment.CustodyEnd = Now
                            AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, LastAlertComment)

                        End If

                    End Using


                    If Me.IsClientPortal = True Then

                        Saved = alertComment.AddNewComment(Me.CurrentAlertID, "", StrComment, Me._ClientPortalID)

                    Else

                        Saved = alertComment.AddNewComment(Me.CurrentAlertID, Me._UserCode, StrComment)

                    End If

                End If

                If Saved = True Then

                    Me.AlertRecipients(True, False)

                    If Me.CloseAfterCommentOrReAssign = False Then

                        Me.RadTextBoxStandardComment.Text = ""
                        Me.RadListViewComments.Rebind()

                    Else

                        Me.CloseRefreshAction()

                    End If

                End If

            End If

        End If

    End Sub

#End Region

    Private Function AppendDocumentAddedComment(ByVal FileAndIdDictionary As System.Collections.Generic.Dictionary(Of Integer, String)) As String

        Dim sb As New System.Text.StringBuilder
        sb.Append("<br /><br />")
        For Each item As System.Collections.Generic.KeyValuePair(Of Integer, String) In FileAndIdDictionary

            'sb.Append(item.Key.ToString())
            With sb

                .Append("<a href=""#"" onclick=""GetDocumentRepositoryDocument('")
                .Append(item.Key.ToString())
                .Append("');return false;"">")
                .Append(item.Value.ToString())
                .Append("</a>")

            End With
            sb.Append(Environment.NewLine)

        Next

        'Return MiscFN.CleanStringForSplit(sb.ToString(), ";", False, True, True, True, False)

    End Function
    Private Sub UploadDocumentToProofHQ(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal DocumentID As Long,
                                        ByVal AlertID As Integer, ByVal Agency As AdvantageFramework.Database.Entities.Agency)

        'objects
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim ProofHQUrl As String = ""
        Dim ByteFile() As Byte = Nothing
        Dim ProofHQFileID As Integer = 0
        Dim ParentProofHQFileID As Integer = 0
        Dim DocumentIDs() As Integer = Nothing
        Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
        Dim ParentDocument As AdvantageFramework.Database.Entities.Document = Nothing
        Dim ProofHQUploaded As Boolean = False

        Try

            If Agency IsNot Nothing Then

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    Try

                        DocumentIDs = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertID).Where(Function(Entity) Entity.DocumentID <> DocumentID).Select(Function(Entity) Entity.DocumentID).ToArray

                    Catch ex As Exception
                        DocumentIDs = Nothing
                    End Try

                    If DocumentIDs IsNot Nothing Then

                        Try

                            Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                         Where DocumentIDs.Any(Function(DocID) DocID = Entity.ID) AndAlso
                                               Entity.FileName = Document.FileName
                                         Select Entity).ToList()

                        Catch ex As Exception
                            Documents = Nothing
                        End Try

                        If Documents IsNot Nothing Then

                            Try

                                ParentDocument = Documents.Where(Function(Entity) Entity.ProofHQFileID.GetValueOrDefault(0) > 0).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                            Catch ex As Exception
                                ParentDocument = Nothing
                            End Try

                            If ParentDocument IsNot Nothing Then

                                ParentProofHQFileID = ParentDocument.ProofHQFileID.GetValueOrDefault(0)

                            End If

                        End If

                    End If

                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                        If ParentProofHQFileID > 0 Then

                            ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, Me._EmployeeCode, ByteFile, ParentProofHQFileID, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                        Else

                            ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, Me._EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                        End If

                        If ProofHQUploaded Then

                            Document.ProofHQUrl = ProofHQUrl
                            Document.ProofHQFileID = ProofHQFileID

                            AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                        End If

                    End If

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SetScreenSplit()

        Dim av As New cAppVars(cAppVars.Application.ALERT_VIEW)
        av.getAllAppVars()

        Dim LeftSide As Integer = 50
        Dim RightSide As Integer = 50
        Try

            LeftSide = av.getAppVar("LeftSide", "Integer", "50")

        Catch ex As Exception
            LeftSide = 50
        End Try

        RightSide = 100 - LeftSide

        Me.RadPaneLeft.Width = New Unit(LeftSide - 1, UnitType.Percentage)
        Me.RadPaneRight.Width = New Unit(RightSide, UnitType.Percentage)

    End Sub
    Private Sub RefreshByRedirect()

        Me.RefreshAlertWindows(False, True, False)

        If Me.CurrentAlertID > 0 Then

            Dim RefreshByRedirectQS As New AdvantageFramework.Web.QueryString
            RefreshByRedirectQS.Page = "Alert_View.aspx"
            RefreshByRedirectQS.AlertID = Me.CurrentAlertID
            RefreshByRedirectQS.Go(False, True)

        Else

            Me.LoadAlert()

        End If


    End Sub

    <System.Web.Services.WebMethod(True)>
    Public Shared Function LoadAutoComplete(context As RadAutoCompleteContext) As AutoCompleteBoxData

        Dim AlertID As Integer = 0
        Dim ClientCode As String = String.Empty
        Dim DivisionCode As String = String.Empty
        Dim ProductCode As String = String.Empty
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Short = 0
        Dim CampaignIdentifier As Integer = 0
        Dim ClientPortalUserID As Integer = 0
        Dim IsReviewers As Boolean = False
        Dim EmailGroupCode As String = String.Empty

        Dim searchString As String = DirectCast(context, Dictionary(Of String, Object))("Text").ToString()
        Dim Recipients As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AutoCompleteRecipients) = Nothing

        Dim items As New Generic.List(Of AutoCompleteBoxItemData)()
        Dim item As AutoCompleteBoxItemData
        Dim Results As New AutoCompleteBoxData()

        Try

            If context IsNot Nothing Then

                Try
                    If context("AlertID") IsNot Nothing Then AlertID = context("AlertID")
                Catch ex As Exception
                End Try
                Try
                    If context("ClientCode") IsNot Nothing Then ClientCode = context("ClientCode")
                Catch ex As Exception
                End Try
                Try
                    If context("DivisionCode") IsNot Nothing Then DivisionCode = context("DivisionCode")
                Catch ex As Exception
                End Try
                Try
                    If context("ProductCode") IsNot Nothing Then ProductCode = context("ProductCode")
                Catch ex As Exception
                End Try
                Try
                    If context("JobNumber") IsNot Nothing Then JobNumber = context("JobNumber")
                Catch ex As Exception
                End Try
                Try
                    If context("JobComponentNumber") IsNot Nothing Then JobComponentNumber = context("JobComponentNumber")
                Catch ex As Exception
                End Try
                Try
                    If context("CampaignIdentifier") IsNot Nothing Then CampaignIdentifier = context("CampaignIdentifier")
                Catch ex As Exception
                End Try
                Try
                    If context("ClientPortalUserID") IsNot Nothing Then ClientPortalUserID = context("ClientPortalUserID")
                Catch ex As Exception
                End Try
                Try
                    If context("IsReviewers") IsNot Nothing Then IsReviewers = context("IsReviewers").ToString.ToLower = "True"
                Catch ex As Exception
                End Try
                Try
                    If context("EmailGroupCode") IsNot Nothing Then ProductCode = context("EmailGroupCode")
                Catch ex As Exception
                End Try

            End If

        Catch ex As Exception
        End Try

        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            Recipients = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AutoCompleteRecipients)(String.Format("[dbo].[usp_wv_AutoCompleteRecipientsLoad] {2}, {3}, {4}, {5}, {6}, NULL, NULL, {0}, '{1}', NULL, NULL",
                                                                                                                                     If(AlertID = 0, "NULL", String.Format("{0}", AlertID)),
                                                                                                                                     HttpContext.Current.Session("UserCode"),
                                                                                                                                     If(String.IsNullOrWhiteSpace(ClientCode), "NULL", String.Format("'{0}'", ClientCode)),
                                                                                                                                     If(String.IsNullOrWhiteSpace(DivisionCode), "NULL", String.Format("'{0}'", DivisionCode)),
                                                                                                                                     If(String.IsNullOrWhiteSpace(ProductCode), "NULL", String.Format("'{0}'", ProductCode)),
                                                                                                                                     If(JobNumber = 0, "NULL", String.Format("{0}", JobNumber)),
                                                                                                                                     If(JobComponentNumber = 0, "NULL", String.Format("{0}", JobComponentNumber)),
                                                                                                                                     If(CampaignIdentifier = 0, "NULL", String.Format("{0}", CampaignIdentifier)),
                                                                                                                                     If(ClientPortalUserID = 0, "NULL", String.Format("{0}", ClientPortalUserID)),
                                                                                                                                     If(IsReviewers = False, "NULL", "1"),
                                                                                                                                     If(String.IsNullOrWhiteSpace(EmailGroupCode), "NULL", String.Format("'{0}'", EmailGroupCode)))).ToList


        End Using

        If Recipients IsNot Nothing AndAlso Recipients.Count > 0 Then

            If String.IsNullOrWhiteSpace(searchString) = False Then

                For Each Recipient As AdvantageFramework.AlertSystem.Classes.AutoCompleteRecipients In Recipients.Where(Function(r) r.FullName.ToUpper.StartsWith(searchString.ToUpper))

                    item = New AutoCompleteBoxItemData()

                    item.Text = Recipient.FullName
                    item.Value = Recipient.Code

                    items.Add(item)
                    item = Nothing

                Next

            Else

                For Each Recipient As AdvantageFramework.AlertSystem.Classes.AutoCompleteRecipients In Recipients

                    item = New AutoCompleteBoxItemData()

                    item.Text = Recipient.FullName
                    item.Value = Recipient.Code

                    items.Add(item)
                    item = Nothing

                Next

            End If

        End If

        Results.Items = items.ToArray

        Return Results

    End Function

#End Region

    Public Function GetCommaDelimitedStringOfEmployeeCodes() As String

        Dim sb As New System.Text.StringBuilder

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.AutoCompleteRecipients.Entries

            If entry.Text.Contains("(CC)") = False Then

                sb.Append(entry.Value)
                sb.Append(",")

            End If
            If entry.Text.Contains("|") = True Then

                Dim ar() As String
                ar = entry.Text.Split("|")

                If ar.Length = 2 Then

                    sb.Append(ar(0))
                    sb.Append(",")

                End If

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function
    Public Function GetCommaDelimitedStringOfClientContactCodes() As String

        Dim sb As New System.Text.StringBuilder
        Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

        Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

            ClientContacts = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, Me.ClientCode).ToList

        End Using

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.AutoCompleteRecipients.Entries

            If entry.Text.Contains("(CC)") = True Then

                Try

                    ClientContact = ClientContacts.SingleOrDefault(Function(Entity) Entity.ContactID = entry.Value)

                Catch ex As Exception
                    ClientContact = Nothing
                End Try

                If ClientContact IsNot Nothing Then

                    sb.Append(ClientContact.ContactCode & "(CC)")
                    sb.Append(",")

                End If

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function
    Public Function GetCommaDelimitedStringOfClientContacts() As String

        Dim sb As New System.Text.StringBuilder

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In Me.AutoCompleteRecipients.Entries

            If entry.Text.Contains("(CC)") = True Then

                sb.Append(entry.Value)
                sb.Append(",")

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function

    Private Sub RadGridWorkItemAssignees_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridWorkItemAssignees.NeedDataSource

        Me.DivWorkItemAssignees.Visible = False

        Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.CurrentAlertID)

            If Alert IsNot Nothing AndAlso Alert.IsWorkItem IsNot Nothing AndAlso Alert.IsWorkItem = True Then

                If Alert.AlertAssignmentTemplateID Is Nothing Then 'not routed assignment

                    Me.DivWorkItemAssignees.Visible = True
                    Dim Controller As New AdvantageFramework.Controller.Desktop.AlertController(Me._Session)
                    Dim Recipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

                    Recipients = (From Entity In Controller.LoadAlertRecipients(DbContext, Me.CurrentAlertID)
                                  Where Entity.IsCurrentNotify = True
                                  Select Entity).ToList

                    If Recipients Is Nothing Then Recipients = New List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

                    Me.RadGridWorkItemAssignees.DataSource = Recipients

                End If

            End If

        End Using

    End Sub

End Class
