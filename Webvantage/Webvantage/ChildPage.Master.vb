Imports Webvantage.cGlobals.Globals

Public Class ChildPage
    Inherits System.Web.UI.MasterPage
    Implements IRadWindowFunctions

#Region " Constants "

#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private RadAlertEnabled As Boolean = False
    Public Shared CallFunctionOnCallingWindowString As String = ""
    Public ThemeCssFile As String = ""
    Public SideBarColor As String = ""
    Public BackgroundColor As String = ""
    Public DarkHighlightColor As String = ""
    Public LightHighlightColor As String = ""
    Public DarkModeScript As String = ""

#End Region

#Region " Properties "

    Public Property BodyTag() As HtmlControls.HtmlGenericControl
        Get
            Return Me.BodyTagMain
        End Get
        Set(value As HtmlControls.HtmlGenericControl)
            value = Me.BodyTagMain
        End Set
    End Property
    Public Property EnableRadFormDecorator() As Boolean
        Get
            Return Me.RadFormDecoratorMain.Enabled
        End Get
        Set(value As Boolean)
            Me.RadFormDecoratorMain.Enabled = value
        End Set
    End Property
    Public WriteOnly Property BodyOnload() As String
        Set(value As String)
            Try
                Dim sb As New System.Text.StringBuilder
                With sb

                End With
            Catch ex As Exception
            End Try
        End Set
    End Property
    Public Property PersistenceManager() As Telerik.Web.UI.RadPersistenceManager
        Get
            Return Me.RadPersistenceManagerMain
        End Get
        Set(value As Telerik.Web.UI.RadPersistenceManager)
            Me.RadPersistenceManagerMain = value
        End Set
    End Property
    Public Property RadFormDecorator() As Telerik.Web.UI.RadFormDecorator
        Get
            Return Me.RadFormDecoratorMain
        End Get
        Set(value As Telerik.Web.UI.RadFormDecorator)
            Me.RadFormDecoratorMain = value
        End Set
    End Property
    'Public Property RadToolTipManager As Telerik.Web.UI.RadToolTipManager
    '    Get
    '        Return Me.RadToolTipManagerMain
    '    End Get
    '    Set(value As Telerik.Web.UI.RadToolTipManager)
    '        Me.RadToolTipManagerMain = value
    '    End Set
    'End Property

#End Region

#Region " Page "

    Private Sub Page_Error(sender As Object, e As System.EventArgs) Handles Me.Error

        Server.Transfer("Error.aspx")

    End Sub
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Try

            If Session("ConnString") Is Nothing Then 'natural timeout most likely occurred.

                AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: connection string is nothing (most likely session timeout occurred ")
                Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.TimeOut)
                Exit Sub

            End If
            If Session("ConnString").ToString().Trim() = "" Then

                AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: connection string is blank ")
                Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString)
                Exit Sub

            End If

        Catch ex As Exception

            Response.Redirect("SignIn.aspx", True)
            Exit Sub

        End Try
        Try
            If Session("UserCode") Is Nothing Then

                AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: User Code is nothing ")
                Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoUserCode)
                Exit Sub

            End If
            If Session("UserCode").ToString().Trim() = "" Then

                AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: User Code is blank ")
                Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoUserCode)
                Exit Sub

            End If
            If MiscFN.IsClientPortal() = False Then

                If Session("SecUserId") Is Nothing Then

                    AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: SecUserId is nothing ")
                    Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoSecUserId)
                    Exit Sub

                End If
                If Session("SecUserId").ToString().Trim() = "" Then

                    AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: SecUserId is blank ")
                    Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoSecUserId)
                    Exit Sub

                End If

            Else 'Client Portal, this is the Client Contact Id

                If Session("UserID") Is Nothing Then

                    Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoClientPortalUserId)
                    Exit Sub

                End If
                If Session("UserID").ToString().Trim() = "" Then

                    Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoClientPortalUserId)
                    Exit Sub

                End If

            End If
        Catch ex As Exception

            AdvantageFramework.Security.AddWebvantageEventLog("ChildPage: error checking session variables --> " & ex.Message)
            Me.BackToSignInPage(AdvantageFramework.Security.ErrorMessages.SystemMessageType.TimeOut)
            Exit Sub

        End Try

        If Not Page.IsPostBack And Not Page.IsCallback Then

            Dim m As AdvantageFramework.Security.ErrorMessages.SystemMessageType
            Dim s As New cSecurity(Session("ConnString"))
            Dim DbSess As String = ""
            Dim CurrSess As String = ""

            Try

                CurrSess = Session("CurrentSessionId")

            Catch ex As Exception

                CurrSess = ""

            End Try

            If s.ValidSessionId(m, DbSess, CurrSess) = False Then

                AdvantageFramework.Security.AddWebvantageEventLog("Session Id Mis-match.  Sign in ID (From DB):" & DbSess.ToString() & ", Current ID (From Session): " & CurrSess.ToString())
                Me.BackToSignInPage(m, DbSess, CurrSess)
                Exit Sub

            End If

        End If

        Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
        t.Load()

        Me.SideBarColor = t.Settings.SimpleLayoutSideBarColor
        Me.BackgroundColor = t.Settings.SimpleLayoutBackgroundColor
        Me.DarkHighlightColor = t.Settings.SimpleLayoutDarkHighlightColor
        Me.LightHighlightColor = t.Settings.SimpleLayoutLightHighlightColor

        Me.RadSkinManagerMain.Skin = t.Settings.TelerikTheme
        Me.RadFormDecoratorMain.Skin = t.Settings.TelerikTheme

        If t.Settings.TelerikTheme.Contains("Metro") Then

            Me.RadFormDecoratorMain.ControlsToSkip = Telerik.Web.UI.FormDecoratorDecoratedControls.CheckBoxes

        End If

        Me.ThemeCssFile = t.Settings.CssFile

        If t.Settings.IsDarkMode = True Then

            Me.DarkModeScript = "enableDarkMode();"

        End If

    End Sub
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Page.Header.DataBind()

    End Sub

#End Region

#Region " Controls "

#End Region

#Region " Methods "

#Region " Window Functions Implementation and Other Window Methods "

    Public Function HookUpOpenDetailWindow(ByVal DataKey As String) As String
        Try
            Dim ar() As String
            Dim URL As String = ""

            Dim FromForm As String = ""
            Dim IsNonTask As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = 0
            Dim NonId As String = ""
            Dim EmpCode As String = ""
            Dim ClCode As String = ""
            Dim DivCode As String = ""
            Dim PrdCode As String = ""
            Dim Description As String = ""

            ar = DataKey.Split("|")

            FromForm = ar(0)
            IsNonTask = CType(ar(1), Integer)
            JobNumber = CType(ar(5), Integer)
            JobComponentNbr = CType(ar(6), Integer)
            SeqNbr = CType(ar(7), Integer)
            NonId = ar(8)
            EmpCode = ar(9)
            ClCode = ar(10)
            DivCode = ar(11)
            PrdCode = ar(12)

            If ar.Length >= 14 Then
                Description = ar(13)
            End If

            Select Case IsNonTask
                Case 0
                    URL = "TrafficSchedule_TaskDetail.aspx?pop=1&form=" & FromForm & "&JobNum=" & JobNumber.ToString() & "&JobComp=" & JobComponentNbr.ToString() & "&SeqNum=" & SeqNbr.ToString() &
                        "&EmpCode=" & EmpCode & "&Client=" & ClCode & "&Division=" & DivCode & "&Product=" & PrdCode
                Case 1
                    URL = "Calendar_NewActivity.aspx?TaskNo=" & NonId.ToString()
                Case 2
                    URL = "Event_Detail.aspx?et=0&j=" & JobNumber.ToString() & "&jc=" & JobComponentNbr.ToString() & "&evt=" & NonId & "&cli=" & ClCode & "&from=1"
                Case 3
                    URL = "Event_Task_Detail.aspx?etid=" & NonId & "&f=c"
            End Select
            Return "OpenRadWindow('" & Description & "','" & URL & "',0,0);return false;"
        Catch ex As Exception
            Return "ShowMessage('Error in javascript function:  HookUpOpenDetailWindow');"
        End Try
    End Function
    Public Sub ShowMessageBox(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)

        Me.ShowMessage(Message)

    End Sub
    Public Sub RefreshDashboardReviews()

        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("refreshDashboardReviews();"))

    End Sub
    Public Sub RefreshDashboardAlerts()

        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("refreshDashboardAlerts();"))

    End Sub
    Public Sub RefreshDashboardAssignments()

        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("refreshDashboardAssignments();"))

    End Sub
    Public Sub refreshAlertsAndAssignmentsManagerPMD()

        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("refreshAlertsAndAssignmentsManagerPMD();"))

    End Sub
    Public Sub ShowMessage(ByVal [ErrorMessage] As String) Implements IRadWindowFunctions.ShowMessage

        If ErrorMessage.Trim() = "" Then Exit Sub

        If RadAlertEnabled = False Then

            ErrorMessage = ErrorMessage.Replace("<br>", "\n")
            ErrorMessage = ErrorMessage.Replace("<br/>", "\n")
            ErrorMessage = ErrorMessage.Replace("<br />", "\n")
            ErrorMessage = ErrorMessage.Replace(Environment.NewLine, "\n")

        End If
        'ErrorMessage = HttpUtility.JavaScriptStringEncode(ErrorMessage)
        Me.RadAjaxManagerMain.ResponseScripts.Add("ShowMessage('" & ErrorMessage & "');return false;")

    End Sub
    Public Sub ShowMessageBox(ByVal [ErrorMessage] As String, Optional ByVal [Title] As String = "") Implements IRadWindowFunctions.ShowMessageBox
        'ErrorMessage = HttpUtility.JavaScriptStringEncode(ErrorMessage)
        'Me.RadAjaxManagerMain.ResponseScripts.Add("ShowRadAlert('" & ErrorMessage & "','" & Title & "');")
        Me.ShowMessage(ErrorMessage)
    End Sub
    Public Sub RefreshMDIPage()
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshParentPage();")
    End Sub
    Public Sub BackToSignInPage(Optional ByVal Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage,
                                Optional ByRef DBSessionId As String = "", Optional ByRef CurrSessionId As String = "") Implements IRadWindowFunctions.BackToSignInPage
        Dim s As String = ""
        If Message <> AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage Then
            s = "?m=" & CType(Message, Integer).ToString()
            If Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.SessionIdMismatch Then
                s &= "&d="
                s &= DBSessionId
                s &= "&c="
                s &= CurrSessionId
            End If
        End If
        Me.RadAjaxManagerMain.ResponseScripts.Add("GetRadWindow().BrowserWindow.location.href = 'SignIn.aspx" & s & "';")
    End Sub
    Public Sub CallFunctionOnParentPage(ByVal CallingWindowPageName As String, ByVal FunctionName As String, ByVal CloseThisWindow As Boolean)
        Dim s As String = ""
        If CloseThisWindow = True Then
            s = "CloseThisWindow();"
        End If
        Me.CallFunctionOnCallingWindowString = "CallingWindow.get_contentFrame().contentWindow." & FunctionName
        Me.RadAjaxManagerMain.ResponseScripts.Add("CallFunctionOnCallingWindow('" & CallingWindowPageName & "','" & FunctionName & "');" & s)
    End Sub
    Public Sub CheckForStopwatch()
        Me.RadAjaxManagerMain.ResponseScripts.Add("checkForStopwatch();refreshTimesheetTab();refreshDashboardTime();")
    End Sub
    Public Sub HideAlertNotificationWindow()
        Me.RadAjaxManagerMain.ResponseScripts.Add("refreshAlerts();")
    End Sub
    Public Sub ShowAlertNotificationWindow()
        Me.RadAjaxManagerMain.ResponseScripts.Add("refreshAlerts();")
    End Sub
    Public Sub OpenTimesheetStopwatchNotificationWindow()
        Me.RadAjaxManagerMain.ResponseScripts.Add("OpenStopwatchNotify();")
    End Sub
    'When ForceNewURL is false, if an existing window is found, it will reload with the existing url (including querystring)
    'When ForceNewURL is true, if an existing window is found, it will reload with the new URL (and queerystring) you pass in
    'this lets us use the functions as a "refresh" by default, but also use it as a "refresh with new data"
    Public Sub CloseThisWindowAndRefreshCaller(ByVal Caller As String, Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        Me.RefreshCaller(Caller, True, ForceNewURL, OpenCallerIfNotFound)
    End Sub
    Public Sub CloseThisWindowAndRefreshCallerAdvanced(ByVal PageName As String, Optional ByVal RefreshFunction As String = "", Optional ByVal QueryString As String = "", Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        Me.RefreshCallerAdvanced(PageName, RefreshFunction, QueryString, True, ForceNewURL, OpenCallerIfNotFound)
    End Sub
    Public Sub BillingApprovalBatchCreated()
        Me.RadAjaxManagerMain.ResponseScripts.Add("BillingApprovalBatchCreated();")
    End Sub
    Public Sub CloseThisWindowAndRefreshChildPageGrid(ByVal ChildPageName As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("RefreshChildPageGrid('{0}');CloseThisWindow();", ChildPageName))
    End Sub
    Public Sub RefreshTasks()
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshTasks();")
    End Sub
    Public Sub CopyToClipboard(ByVal Text As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("copyToClipboard('{0}');", Text))
    End Sub
    Public Sub RefreshAlertWindows(Optional ByVal CloseThisWindow As Boolean = True,
                                   Optional ByVal IncludeAlertDesktopObject As Boolean = True,
                                   Optional ByVal IncludeProjectSchedulePage As Boolean = False,
                                   Optional ByVal IncludeAlertInbox As Boolean = True,
                                   Optional ByVal IncludeDashboard As Boolean = True,
                                   Optional ByVal FromContent As Boolean = False)

        Dim CloseString As String = ""
        Dim ProjectScheduleString As String = ""

        If CloseThisWindow = True Then

            If FromContent = True Then
                CloseString = "CloseThisWindowNew();"
            Else
                CloseString = "CloseThisWindow();"
            End If

        End If
        If IncludeProjectSchedulePage = True Then

            ProjectScheduleString = "RefreshProjectScheduleGrid();"

        End If
        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("RefreshAlertWindows({0}, {1}, {4});{2}{3}",
                                                                IncludeAlertDesktopObject.ToString.ToLower,
                                                                IncludeAlertInbox.ToString.ToLower,
                                                                ProjectScheduleString,
                                                                CloseString,
                                                                IncludeDashboard.ToString.ToLower))
    End Sub
    Public Sub RefreshAlertRecipients()
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshAlertRecipients();CloseThisWindow();")
    End Sub
    Public Sub RefreshInOutBoardObjects(ByVal CurrentObjectName As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshInOutBoardObjects('" & CurrentObjectName & "');")
    End Sub
    Public Sub RefreshJobRequestObjects(ByVal CurrentObjectName As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshJobRequestObjects('" & CurrentObjectName & "');")
    End Sub
    Public Sub RefreshTimesheetDesktopObject(Optional ByVal CloseThisWindow As Boolean = True)
        Dim CloseString As String = ""
        If CloseThisWindow = True Then
            CloseString = "CloseThisWindow();"
        End If
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshTimesheetDTO();" & CloseString)
    End Sub
    Public Sub RefreshTimesheetWindows(Optional ByVal CloseThisWindow As Boolean = True)
        Dim CloseString As String = ""
        If CloseThisWindow = True Then
            CloseString = "CloseThisWindow();"
        End If
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshTimesheetWindows();" & CloseString)
    End Sub
    Public Sub RefreshChildPageGrid(ByVal PageName As String)

        PageName = PageName.Trim()

        If PageName <> "" Then

            Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshChildPageGrid('" & PageName & "');")

        End If

    End Sub
    Public Sub CalendarSync(ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)
        Me.RadAjaxManagerMain.ResponseScripts.Add("CalendarSync(" & EmployeeNonTaskID.ToString() & ", " & IsHoliday.ToString().ToLower() & "," & IsDeleting.ToString().ToLower() & ");")
    End Sub
    Public Function SendEmail(ByVal Guid As String) As Boolean
        Me.RadAjaxManagerMain.ResponseScripts.Add("SendEmail('" & Guid & "');")
    End Function
    Public Sub CheckForAsyncMessage()
        Me.RadAjaxManagerMain.ResponseScripts.Add("CheckForAsyncMessage();")
    End Sub
    Public Sub ReviewGenerateFeedbackSummary(ByVal ConceptShareProjectID As Integer, ByVal ConceptShareReviewID As Integer)
        Me.RadAjaxManagerMain.ResponseScripts.Add(String.Format("ReviewGenerateFeedbackSummary({0}, {1});", ConceptShareProjectID, ConceptShareReviewID))
    End Sub

    Public Sub RefreshCaller(ByVal Caller As String, Optional ByVal CloseThisWindow As Boolean = False, Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        If Caller.Trim() <> "" Then
            Dim s As String = ""
            If CloseThisWindow = True Then
                s = "CloseThisWindow();"
            End If
            Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshWindow('" & Caller.Trim() & "'," & ForceNewURL.ToString().ToLower() & "," & OpenCallerIfNotFound.ToString().ToLower() & ");" & s)
        End If
    End Sub

    Public Sub SimpleClose()
        Me.RadAjaxManagerMain.ResponseScripts.Add("simpleCloseWindow();")
    End Sub

    Public Sub RefreshCallerAdvanced(ByVal PageName As String, Optional ByVal RefreshFunction As String = "", Optional ByVal QueryString As String = "", Optional ByVal CloseThisWindow As Boolean = False, Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        If PageName.Trim() <> "" Then
            Dim s As String = ""
            If CloseThisWindow = True Then
                s = "CloseThisWindow();"
            End If
            Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshWindow({ pageName: '" + PageName + "', refreshFunction: '" + RefreshFunction + "', query: '" + QueryString + "' }," & ForceNewURL.ToString().ToLower() & "," & OpenCallerIfNotFound.ToString().ToLower() & ");" & s)
        End If
    End Sub

    Public Overloads Sub OpenWindow(ByVal QS As AdvantageFramework.Web.QueryString, Optional ByVal CustomWindowTitle As String = "", Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                    Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False)

        Me.OpenWindow(CustomWindowTitle, QS.ToString(True), Height, Width, CloseCurrentWindowAfterOpen, IsModal)

    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                    Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False, Optional Callback As String = Nothing) Implements IRadWindowFunctions.OpenWindow
        Dim s As String = ""
        If CloseCurrentWindowAfterOpen = True Then
            s = "CloseThisWindow();"
        End If
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerMain.ResponseScripts.Add("OpenRadWindow('" & Title & "','" & URL & "'," & Height & "," & Width & ", " & IsModal.ToString().ToLower() & "," & Callback & ");" & s)
    End Sub
    Public Sub OpenPrintSendSilently(ByVal QS As AdvantageFramework.Web.QueryString)
        Me.RadAjaxManagerMain.ResponseScripts.Add("CallPrintSendPageSilently('" & QS.ToString(True) & "');")
    End Sub
    Public Sub CloseThisWindow()
        Me.RadAjaxManagerMain.ResponseScripts.Add("CloseThisWindow();")
    End Sub
    Public Sub CloseDialog()
        Me.RadAjaxManagerMain.ResponseScripts.Add("CloseDialog();")
    End Sub

    Public Sub CloseThisWindowNew()
        Me.RadAjaxManagerMain.ResponseScripts.Add("CloseThisWindowNew();")
    End Sub

    Public Sub OpenLookUp(ByVal [URL] As String) Implements IRadWindowFunctions.OpenLookUp
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerMain.ResponseScripts.Add("OpenRadWindowLookup('" & [URL] & "');")
    End Sub

    Public Sub OpenLookUpRecipients(ByVal [URL] As String)
        [URL] = MiscFN.JavascriptSafe([URL])
        Me.RadAjaxManagerMain.ResponseScripts.Add("OpenRadWindowLookup('" & [URL] & "');")
    End Sub
    Public Sub RefreshBookmarksDesktopObject()
        Me.RadAjaxManagerMain.ResponseScripts.Add("RefreshBookmarksDTO();")
    End Sub

    Public Overloads Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String) Implements IRadWindowFunctions.HookUpLookUp
        [URL] = MiscFN.JavascriptSafe([URL])
        With LookUpHyperLink.Attributes
            .Remove("onclick")
            .Add("onclick", "OpenRadWindowLookup('" & [URL] & "');return false;")
        End With
    End Sub

    Public Overloads Function HookUpLookUp(ByVal LookUpType As String, ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "", Optional ByVal JavascriptToExecuteAfter As String = "") As String Implements IRadWindowFunctions.HookUpLookUp
        [URL] = MiscFN.JavascriptSafe([URL])

        Dim StringBuilderJavascript As New System.Text.StringBuilder
        With StringBuilderJavascript
            '    'If JavascriptToExecuteBefore.Trim() <> "" Then
            '    '    .Append(JavascriptToExecuteBefore.Trim())
            '    'End If
            .Append("OpenRadWindowLookup(" & [URL] & ");return false;")
            '    'If JavascriptToExecuteAfter.Trim() <> "" Then
            '    '    .Append(JavascriptToExecuteAfter.Trim())
            '    'End If
        End With
        ''Return HttpUtility.JavaScriptStringEncode(StringBuilderJavascript.ToString())
        Return StringBuilderJavascript.ToString()
        'Return ""



        'Dim FunctionName As String = "LookUp_" & LookUpType
        'Dim StringBuilderJavascript As New System.Text.StringBuilder
        'With StringBuilderJavascript

        'End With

    End Function

    Public Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal CallBack As String = Nothing, Optional ByVal Param As String = Nothing) As String Implements IRadWindowFunctions.HookUpOpenWindow
        [URL] = MiscFN.JavascriptSafe([URL])
        Dim s As String = ""
        Dim callbackstring = ""

        If CallBack IsNot Nothing Then
            callbackstring = ",false," & CallBack

            If Param IsNot Nothing Then
                callbackstring = callbackstring & "," & Param
            End If
        End If

        If CloseCurrentWindowAfterOpen = True Then
            s = "CloseThisWindow();"
        End If
        Return "OpenRadWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & callbackstring & ");" & s & "return false;"
    End Function

    Public Sub CallUiAction(ByVal Action As UI_Action.ActionType, ByVal ExtraQuerystringParameters As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add("CallUiAction(" & CType(Action, Integer) & ",'" & ExtraQuerystringParameters & "');")
    End Sub
    Public Function HookUpCallUiAction(ByVal Action As UI_Action.ActionType, ByVal ExtraQuerystringParameters As String) As String
        Return "CallUiAction(" & CType(Action, Integer) & ",'" & ExtraQuerystringParameters & "');" & "return false;"
    End Function

    Public Sub OpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) Implements IRadWindowFunctions.OpenFloatingWindow
        Me.RadAjaxManagerMain.ResponseScripts.Add("OpenFloatingWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & Top & "," & Left & ");")
    End Sub

    Function HookUpOpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                              Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As String Implements IRadWindowFunctions.HookUpOpenFloatingWindow

        Title = AdvantageFramework.StringUtilities.JavascriptSafe(Title)
        [URL] = AdvantageFramework.StringUtilities.JavascriptSafe([URL])

        Return "OpenFloatingWindow('" & Title & "',' " & URL & "'," & Height & "," & Width & "," & Top & "," & Left & ");return false;"

    End Function

    Public Sub AddJavascriptToPage(ByVal Javascript As String)
        Me.RadAjaxManagerMain.ResponseScripts.Add(Javascript)
    End Sub

#End Region

#End Region

End Class
