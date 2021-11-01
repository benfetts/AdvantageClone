Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Webvantage.cGlobals
Imports Webvantage.cGlobals.Globals
Imports Webvantage.MiscFN
Imports System
Imports System.IO
Imports System.IO.Compression
Imports Telerik.Web.UI

<Serializable()> Public Class BaseDesktopObject
    Inherits BaseUserControl

    Private ParentPage As Object ' Webvantage.UI_TopMenu
    Public ReadOnly Property SecuritySession As AdvantageFramework.Security.Session
        Get
            Try
                Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
                Return Session
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Public ReadOnly Property IsFloating As Boolean
        Get
            Return HttpContext.Current.Request.Url.ToString().IndexOf("DesktopObjectWindow.aspx") > -1
        End Get
    End Property
    Public ReadOnly Property IsFloatingDO As Boolean
        Get
            Return HttpContext.Current.Request.Url.ToString().IndexOf("DesktopObjectLoadWindow.aspx") > -1
        End Get
    End Property
    Public Property PersistenceManager As RadPersistenceManager
        Get
            If Not Me.ParentPage Is Nothing Then
                Return Me.ParentPage.PersistenceManager
            End If
        End Get
        Set(value As RadPersistenceManager)
            Me.ParentPage.PersistenceManager = value
        End Set
    End Property
    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

        Try

            If Me.IsFloating = True Or Me.IsFloatingDO = True Then

                Me.ParentPage = CType(Me.Page.Master, Webvantage.ChildPage)

            Else

                Me.ParentPage = CType(Me.Page, Webvantage.DefaultParent)

            End If

        Catch ex As Exception

            Me.ParentPage = Nothing

        End Try
    End Sub


    Public Sub HookUpOpenWindow(ByRef Control As WebControl, ByVal [URL] As String, Optional Title As String = "", Optional ByVal Modal As Boolean = False, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0)
        With Control.Attributes

            .Remove("onclick")
            .Add("onclick", "OpenRadWindow('','" & [URL] & "',0,0, " & Modal.ToString().ToLower() & ");return false;")

        End With
    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowBeforeOpen As Boolean = False, Optional ByVal IsModal As Boolean = False)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenWindow(Title, URL, Height, Width, CloseCurrentWindowBeforeOpen, IsModal)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal [URL] As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenWindow(URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub OpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenFloatingWindow(Title, URL, Height, Width, Top, Left)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub RefreshBookmarksDesktopObject()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshBookmarksDesktopObject()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenTimesheetStopwatchNotificationWindow()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenTimesheetStopwatchNotificationWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CAllUiAction(Action, ExtraQuerystringParameters)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Function HookUpCallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String) As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpCallUiAction(Action, ExtraQuerystringParameters)
        Else
            Return "return false;"
        End If
    End Function

    Private Sub ShowMessageBox(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.ShowMessageBox(Message, Title)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub ShowMessage(ByVal ErrorMessage As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.ShowMessage(ErrorMessage)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub RefreshTasks()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTasks()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CopyToClipboard(ByVal Text As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CopyToClipboard(Text)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshAlertWindows(Optional ByVal CloseThisWindow As Boolean = True,
                                   Optional ByVal IncludeAlertDesktopObject As Boolean = True,
                                   Optional ByVal IncludeProjectSchedulePage As Boolean = False,
                                   Optional ByVal IncludeAlertInbox As Boolean = True,
                                   Optional ByVal IncludeDashboard As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshAlertWindows(CloseThisWindow, IncludeAlertDesktopObject, IncludeProjectSchedulePage, IncludeAlertInbox, IncludeDashboard)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshInOutBoardObjects(ByVal CurrentObjectName As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshInOutBoardObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshJobRequestObjects(ByVal CurrentObjectName As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshJobRequestObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetDesktopObject(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTimesheetDesktopObject(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetWindows(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTimesheetWindows(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CalendarSync(ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CalendarSync(EmployeeNonTaskID, IsHoliday, IsDeleting)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub SendEmail(ByVal Guid As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.SendEmail(Guid)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub ReviewGenerateFeedbackSummary(ByVal ConceptShareProjectID As Integer, ByVal ConceptShareReviewID As Integer)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.ReviewGenerateFeedbackSummary(ConceptShareProjectID, ConceptShareReviewID)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    'Public Sub OpenWindowFromQueryString(Optional ByVal CustomWindowTitle As String = "", Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, _

    Public Sub DeliverGrid(ByVal TheGrid As DataTable, ByVal Filename As String)

        Session("EXPORT_GRID") = TheGrid
        Session("EXPORT_GRID_FILENAME") = Filename

        If Me.IsFloating = False Then

            'HttpContext.Current.Response.RedirectLocation = "Documents_StreamGrid.aspx"
            HttpContext.Current.Response.Redirect("Documents_StreamGrid.aspx")

        Else

            HttpContext.Current.Response.Redirect("Documents_StreamGrid.aspx")

        End If

    End Sub

    Public Sub DeliverFile(ByVal DocumentId As Integer)
        'If Me.IsFloating = False Then
        '    HttpContext.Current.Response.RedirectLocation = "Documents_StreamFile.aspx?id=" & DocumentId
        'Else
        HttpContext.Current.Response.Redirect("Documents_StreamFile.aspx?id=" & DocumentId)
        'End If
    End Sub

    Public Function CheckUserGroupSetting(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
        Dim SessionKey As String = "CheckUserGroupSetting" & GroupSetting.ToString()
        Dim i As Integer = 0
        If Session(SessionKey) Is Nothing Then
            Try
                i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, GroupSetting).Any(Function(SettingValue) SettingValue = True))
            Catch ex As Exception
                i = 0
            End Try
        Else
            i = CType(Session(SessionKey), Integer)
        End If
        Return i
    End Function

    Public Function CheckModuleAccess(ByVal User As AdvantageFramework.Security.Classes.User, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, ModuleCode, User)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                Session(SessionKey) = ModuleAccess

            End If

        End If

        Return ModuleAccess

    End Function

    Public Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

        If Session(SessionKey) Is Nothing Then

            If Me.IsClientPortal = True Then

                Try
                    ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(_Session, [Module].ToString)
                Catch ex As Exception
                    ModuleAccess = 1
                End Try

            Else

                Try

                    ModuleAccess = CheckModuleAccess(_Session.User, [Module].ToString, False)

                Catch ex As Exception
                    ModuleAccess = 0
                End Try

            End If

            Session(SessionKey) = ModuleAccess

        Else

            ModuleAccess = CType(Session(SessionKey), Integer)

        End If

        If ModuleAccess = 0 And TransferToNoAccessPage = True Then

            Server.Transfer("NoAccess.aspx")

        End If

        If ModuleAccess = -1 Then ModuleAccess = 1

        Return ModuleAccess

    End Function

    Public Overloads Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.HookUpLookUp(LookUpHyperLink, URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Overloads Function HookUpLookUp(ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "", Optional ByVal JavascriptToExecuteAfter As String = "") As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpLookUp(URL, JavascriptToExecuteBefore, JavascriptToExecuteAfter)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function

    Public Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False) As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpOpenWindow(Title, URL, Height, Width, CloseCurrentWindowAfterOpen)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function

    Public Function HookUpOpenDetailWindow(ByVal DataKey As String) As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpOpenDetailWindow(DataKey)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function

    Public ReadOnly Property IsClientPortal() As Boolean
        Get
            Try
                Return MiscFN.IsClientPortal()
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    Private Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

    End Sub
End Class
<Serializable()> Public Class BaseContentUserControl
    Inherits BaseChildPageUserControl

    Public Const ButtonClass As String = "waves-effect waves-light btn"
    Public Const ButtonClassDisabled As String = "waves-effect waves-light btn disabled"

    Public Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then
                ViewState("JobNumber") = 0
            End If
            Return ViewState("JobNumber")
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Public Property JobComponentNumber As Short
        Get
            If ViewState("JobComponentNumber") Is Nothing Then
                ViewState("JobComponentNumber") = 0
            End If
            Return ViewState("JobComponentNumber")
        End Get
        Set(value As Short)
            ViewState("JobComponentNumber") = value
        End Set
    End Property

    Private Sub BaseContentUserControl_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then


        End If

    End Sub

    Public Sub LoadJobAndComponentNumberFromQuerystring()

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me.JobNumber = qs.JobNumber
        Me.JobComponentNumber = qs.JobComponentNumber

    End Sub

    Public Function AddCardContent(ByVal Key As String, ByVal Value As String, Optional ByVal Trim As Boolean = False) As String

        Dim Colon As String = ":"

        Key = Key.Trim()
        Value = Value.Trim()

        If Key = "" AndAlso Value = "" Then

            Return "<br/>"

        Else

            If Key = "" Or Key.EndsWith("?") = True Then Colon = ""

            If Trim = True Then

                Value = If(Value.Length > 70, Value.Substring(0, 70) & "...", Value)

            End If

            Return String.Format("<div class=""content-key-value""><div class=""content-key"">{0}" & Colon & "</div><div class=""content-value"">{1}</div></div>", Key, Value)

        End If


    End Function

End Class
<Serializable()> Public Class BaseChildPageUserControl
    Inherits BaseUserControl

    Private ParentPage As Webvantage.ChildPage

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

        Me.ParentPage = Me.Page.Master

    End Sub
    Private Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

    End Sub

    Public Sub CallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CallUiAction(Action, ExtraQuerystringParameters)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Function CheckUserGroupSetting(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
        Dim SessionKey As String = "CheckUserGroupSetting" & GroupSetting.ToString()
        Dim i As Integer = 0
        If Session(SessionKey) Is Nothing Then
            Try
                i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, GroupSetting).Any(Function(SettingValue) SettingValue = True))
            Catch ex As Exception
                i = 0
            End Try
        Else
            i = CType(Session(SessionKey), Integer)
        End If
        Return i
    End Function
    Public Function CheckModuleAccess(ByVal User As AdvantageFramework.Security.Classes.User, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, ModuleCode, User)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                Session(SessionKey) = ModuleAccess

            End If

        End If

        Return ModuleAccess

    End Function
    Public Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                ModuleAccess = CheckModuleAccess(_Session.User, [Module].ToString, False)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            Session(SessionKey) = ModuleAccess
        Else
            ModuleAccess = CType(Session(SessionKey), Integer)
        End If

        If ModuleAccess = 0 And TransferToNoAccessPage = True Then
            Server.Transfer("NoAccess.aspx")
        End If

        If ModuleAccess = -1 Then ModuleAccess = 1
        Return ModuleAccess

    End Function
    Public Sub DeliverFile(ByVal DocumentId As Integer)
        'HttpContext.Current.Response.RedirectLocation = "Documents_StreamFile.aspx?id=" & DocumentId
        HttpContext.Current.Response.Redirect("Documents_StreamFile.aspx?id=" & DocumentId)
    End Sub
    Public Sub DeliverGrid(ByVal TheGrid As GridView, ByVal Filename As String)
        Session("EXPORT_GRID") = TheGrid
        Session("EXPORT_GRID_FILENAME") = Filename
        'HttpContext.Current.Response.RedirectLocation = "Documents_StreamGrid.aspx"
        HttpContext.Current.Response.Redirect("Documents_StreamGrid.aspx")
    End Sub
    Public Function EnableBookmarks() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "EnableBookmarks"

        Return True

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try

                IsValid = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_DesktopObjects_BookmarksDO, False) = 1

            Catch ex As Exception

                IsValid = False

            End Try

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function
    Public Function HookUpCallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String) As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpCallUiAction(Action, ExtraQuerystringParameters)
        Else
            Return "return false;"
        End If
    End Function
    Public Overloads Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.HookUpLookUp(LookUpHyperLink, URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Function HookUpLookUp(ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "", Optional ByVal JavascriptToExecuteAfter As String = "") As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpLookUp(URL, JavascriptToExecuteBefore, JavascriptToExecuteAfter)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Public Sub HookUpOpenWindow(ByRef Control As WebControl, ByVal [URL] As String, Optional Title As String = "", Optional ByVal Modal As Boolean = False, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0)
        With Control.Attributes
            .Remove("onclick")
            .Add("onclick", "OpenRadWindow('','" & [URL] & "',0,0, " & Modal.ToString().ToLower() & ");return false;")
        End With
    End Sub
    Public Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False) As String
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.HookUpOpenWindow(Title, URL, Height, Width, CloseCurrentWindowAfterOpen)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Public Sub OpenPrintSendSilently(ByVal QS As AdvantageFramework.Web.QueryString)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenPrintSendSilently(QS)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CheckForAsyncMessage()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CheckForAsyncMessage()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenTimesheetStopwatchNotificationWindow()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenTimesheetStopwatchNotificationWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowBeforeOpen As Boolean = False)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenWindow(Title, URL, Height, Width, CloseCurrentWindowBeforeOpen)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal [URL] As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenWindow("", URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub OpenLookUp(ByVal [URL] As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.OpenLookUp(URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                  Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False)
        If Not Me.ParentPage Is Nothing Then
            If [URL].Contains(".aspx") = True Then
                Title = ""
            End If
            Me.ParentPage.OpenWindow(Title, URL, Height, Width, CloseCurrentWindowAfterOpen, IsModal)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal QS As AdvantageFramework.Web.QueryString, Optional ByVal CustomWindowTitle As String = "", Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                      Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False)

        Me.OpenWindow(CustomWindowTitle, QS.ToString(True), Height, Width, CloseCurrentWindowAfterOpen)

    End Sub
    Public Sub RefreshTasks()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTasks()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CopyToClipboard(ByVal Text As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.CopyToClipboard(Text)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshAlertWindows(Optional ByVal CloseThisWindow As Boolean = True,
                                   Optional ByVal IncludeAlertDesktopObject As Boolean = True,
                                   Optional ByVal IncludeProjectSchedulePage As Boolean = False,
                                   Optional ByVal IncludeAlertInbox As Boolean = True,
                                   Optional ByVal IncludeDashboard As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshAlertWindows(CloseThisWindow, IncludeAlertDesktopObject, IncludeProjectSchedulePage, IncludeAlertInbox, IncludeDashboard)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub RefreshBookmarksDesktopObject()
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshBookmarksDesktopObject()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshInOutBoardObjects(ByVal CurrentObjectName As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshInOutBoardObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshJobRequestObjects(ByVal CurrentObjectName As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshJobRequestObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetDesktopObject(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTimesheetDesktopObject(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetWindows(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.RefreshTimesheetWindows(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Function SendEmail(ByVal Guid As String)
        If Not Me.ParentPage Is Nothing Then
            Return Me.ParentPage.SendEmail(Guid)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Public Sub ShowMessage(ByVal ErrorMessage As String)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.ShowMessage(ErrorMessage)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Private Sub ShowMessageBox(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        If Not Me.ParentPage Is Nothing Then
            Me.ParentPage.ShowMessageBox(Message, Title)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

End Class
Public Class BaseUserControl
    Inherits System.Web.UI.UserControl
    Protected _Session As AdvantageFramework.Security.Session = Nothing

    Public ReadOnly Property EventTarget() As String
        Get
            Try
                If String.IsNullOrWhiteSpace(Me.Page.Request.Form("__EVENTTARGET")) = False Then

                    Return Me.Page.Request.Form("__EVENTTARGET").ToString().Replace("onclick#", "")

                Else

                    Return ""

                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property EventArgument() As String
        Get
            Try
                If String.IsNullOrWhiteSpace(Me.Page.Request.Form("__EVENTARGUMENT")) = False Then

                    Return Me.Page.Request.Form("__EVENTARGUMENT").ToString().Replace("onclick#", "")

                Else

                    Return ""

                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property DesktopObjectsAreFloating() As Boolean
        Get
            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            t.Load()
            Return t.Settings.FloatDesktopObjects
        End Get
    End Property
    Public ReadOnly Property TimeZoneToday As DateTime
        Get
            Try

                Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

                If Offset <> 0 Then

                    Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

                Else

                    Return Now.Date

                End If

            Catch ex As Exception
                Return Now.Date
            End Try
        End Get
    End Property
    Public Sub SetRadDatePicker(ByRef RadDatePicker As Telerik.Web.UI.RadDatePicker)

        Dim Today As New RadCalendarDay
        Today.Date = Me.TimeZoneToday
        Today.ItemStyle.CssClass = "radcalendar-today"
        RadDatePicker.Calendar.SpecialDays.Add(Today)

    End Sub

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Try

            If HttpContext.Current.Session("ConnString") Is Nothing AndAlso HttpContext.Current.Response.IsRequestBeingRedirected = False Then 'natural timeout most likely occurred.

                AdvantageFramework.Security.AddWebvantageEventLog("BasePage.vb (BaseUserControl): connection string is nothing (most likely session timeout occurred ")
                HttpContext.Current.Response.Redirect("SignIn.aspx?m=13", True)
                Exit Sub

            End If
            If HttpContext.Current.Session("ConnString") IsNot Nothing AndAlso HttpContext.Current.Session("ConnString").ToString().Trim() = "" AndAlso
                    HttpContext.Current.Response.IsRequestBeingRedirected = False Then

                AdvantageFramework.Security.AddWebvantageEventLog("BasePage.vb (BaseUserControl): connection string is blank ")
                HttpContext.Current.Response.Redirect("SignIn.aspx?m=1", True)
                Exit Sub

            End If

        Catch ex As Exception

            HttpContext.Current.Response.Redirect("SignIn.aspx", True)
            Exit Sub

        End Try
        If Session("Security_Session") Is Nothing Then

            If TypeOf Me.Page Is Webvantage.DefaultParent Then

                _Session = DirectCast(Me.Page, Webvantage.DefaultParent)._Session

            Else

                If Session("UserGUID") IsNot Nothing Then

                    _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))

                Else

                    _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))

                End If

            End If

            Session("Security_Session") = _Session

        Else

            _Session = Session("Security_Session")

        End If


    End Sub

    Public Sub ApplicationMostLikelyGotReset()
        Try
            With HttpContext.Current.Response
                .Write("<script type=""text/javascript"">window.location = 'SignIn.aspx';</script>")
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Function Sanitize(ByVal StringToEncode As String) As String

        Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
        Sanitizer.AllowDataAttributes = True
        Sanitizer.AllowedAttributes.Add("class")
        Return Sanitizer.Sanitize(StringToEncode)

    End Function

    Public Function UserCanPrintInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanPrint = UserCanPrintInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanPrint = False
            End Try

            Session(SessionKey) = CanPrint

        Else
            CanPrint = CType(Session(SessionKey), Boolean)
        End If
        Return CanPrint
    End Function
    Public Function UserCanPrintInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanPrint = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanPrint = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanPrint

            End If

        End If

        Return CanPrint

    End Function

    Public Function UserCanUpdateInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanUpdate = UserCanUpdateInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanUpdate = False
            End Try

            Session(SessionKey) = CanUpdate

        Else
            CanUpdate = CType(Session(SessionKey), Boolean)
        End If
        Return CanUpdate
    End Function
    Public Function UserCanUpdateInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanUpdate = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanUpdate = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanUpdate

            End If

        End If

        Return CanUpdate

    End Function

    Public Function UserCanAddInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanAdd = UserCanAddInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanAdd = False
            End Try

            Session(SessionKey) = CanAdd

        Else
            CanAdd = CType(Session(SessionKey), Boolean)
        End If
        Return CanAdd
    End Function
    Public Function UserCanAddInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanAdd = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanAdd = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanAdd

            End If

        End If

        Return CanAdd

    End Function

    Public Function UserCanCustom1Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanCustom1 = UserCanCustom1Module(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            Session(SessionKey) = CanCustom1

        Else
            CanCustom1 = CType(Session(SessionKey), Boolean)
        End If
        Return CanCustom1
    End Function
    Public Function UserCanCustom1Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom1 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, SecurityModule)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom1

            End If

        End If

        Return CanCustom1

    End Function

    Public Function UserCanCustom2Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanCustom2 = UserCanCustom2Module(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            Session(SessionKey) = CanCustom2

        Else
            CanCustom2 = CType(Session(SessionKey), Boolean)
        End If
        Return CanCustom2
    End Function
    Public Function UserCanCustom2Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom2 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom2

            End If

        End If

        Return CanCustom2

    End Function

End Class

Public Class BaseLookupPage
    Inherits Webvantage.BaseChildPage

    Public Function SetFocusToInput(ByVal InputID As String) As String

        If String.IsNullOrWhiteSpace(InputID) = False Then

            'Return "setTimeout(function() { $(CallingWindowContent.document).find(""input[id='" &
            '        InputID & "']"").focus(); }, 1000); setTimeout(function() { $(CallingWindowContent.document).find(""input[id='" &
            '        InputID & "']"").selectionEnd  = $(CallingWindowContent.document).find(""input[id='" &
            '        InputID & "']"").selectionStart; }, 100);"
            Return String.Format("CallingWindowContent.document.getElementById('{0}').focus();", InputID)

        Else

            Return ""

        End If

    End Function
    Public Function SelectedValue(ByRef LookupGrid As Telerik.Web.UI.RadGrid) As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In LookupGrid.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.GetDataKeyValue("code")
            End If
        Next
    End Function
    Public Function SelectedText(ByRef LookupGrid As Telerik.Web.UI.RadGrid) As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In LookupGrid.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.Item("GridBoundColumnDescription").Text
            End If
        Next
    End Function
    Public Sub SetLookupGrid(ByRef Grid As Telerik.Web.UI.RadGrid)

        Grid.ClientSettings.Scrolling.ScrollHeight = New Unit(595, UnitType.Pixel)
        Grid.Width = New Unit(580, UnitType.Pixel)

        If Me.CurrentTheme = TkTheme.Large Then

            Grid.PageSize = 12

        Else

            Grid.PageSize = 22

        End If

    End Sub

    Private Sub Page_PreInit1(sender As Object, e As System.EventArgs) Handles Me.PreInit
        'If MiscFN.BrowserTypeIs(Browser_Types.Chrome) = True Or MiscFN.BrowserTypeIs(Browser_Types.Safari) Then
        '    Me.EnableRadFormDecorator = False
        'End If
    End Sub



End Class
<Serializable()> Public Class BasePrintablePage
    Inherits Webvantage.BasePageShared

End Class
Public Class BasePrintSendPage
    Inherits Webvantage.BaseChildPage

    Public Enum PageMode

        Print = 1
        SendAlert = 2
        SendEmail = 3
        Options = 4
        SendAssignment = 5
        NewAlert = 6
        NewAssignment = 7
        NewProof = 8

    End Enum

    Public ReadOnly Property CurrentPageMode As PageMode
        Get

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            If IsNumeric(qs.GetValue("mode")) = True Then

                Return CType(qs.GetValue("mode"), BasePrintSendPage.PageMode)

            Else

                Return PageMode.Options

            End If

        End Get
    End Property

End Class
Public Class BaseChildPage
    Inherits Webvantage.BasePageShared

    Private _MasterPage As Webvantage.ChildPage

    Public OpenerRadWindowName As String = ""
    Public ControlsToSet As String = ""
    Public CallingControlName As String = ""
    Public AllowFloat As Boolean = True

    Public ReadOnly Property TimeZoneOffset As Decimal
        Get
            Return cEmployee.GetTimeZoneOffset()
        End Get
    End Property
    Public ReadOnly Property TimeZoneToday As DateTime
        Get
            Try

                Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

                If Offset <> 0 Then

                    Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

                Else

                    Return Now.Date

                End If

            Catch ex As Exception
                Return Now.Date
            End Try
        End Get
    End Property
    Public Property PageTitle() As String
        Get
            Try
                Return CType(Me.Master.FindControl("LabelPageTitle"), Label).Text
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As String)
            value = value.Replace(" ", "&nbsp;")
            Try
                If Me.Master.FindControl("LabelPageTitle") IsNot Nothing Then

                    CType(Me.Master.FindControl("LabelPageTitle"), Label).Text = value

                End If
            Catch ex As Exception
            End Try
            Try
                Me.Page.Title = value
            Catch ex As Exception
            End Try
        End Set
    End Property
    Public Property BodyTag() As HtmlControls.HtmlGenericControl
        Get
            Try
                If Not Me._MasterPage Is Nothing Then
                    Return Me._MasterPage.BodyTag
                Else
                    Me.ApplicationMostLikelyGotReset()
                End If
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As HtmlControls.HtmlGenericControl)
            Try
                If Not Me._MasterPage Is Nothing Then
                    value = Me._MasterPage.BodyTag
                Else
                    Me.ApplicationMostLikelyGotReset()
                End If
            Catch ex As Exception
            End Try
        End Set
    End Property
    Public Property EnableRadFormDecorator() As Boolean
        Get
            Try
                Return Me._MasterPage.EnableRadFormDecorator
            Catch ex As Exception
                Return False
            End Try
        End Get
        Set(value As Boolean)
            Me._MasterPage.EnableRadFormDecorator = value
        End Set
    End Property
    Public ReadOnly Property IsDefaultWorkspace As Boolean
        Get
            If HttpContext.Current.Session("_IsDefaultWorkspace") Is Nothing Then
                HttpContext.Current.Session("_IsDefaultWorkspace") = False
            End If
            Return HttpContext.Current.Session("_IsDefaultWorkspace")
        End Get
    End Property

    'Public Property Querystring As New AdvantageFramework.Web.QueryString

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Error

        If Session("ConnString") Is Nothing Then

            HttpContext.Current.Response.Write("<script>top.window.location.href = ""SignIn.aspx""</script>")

        Else

            Server.Transfer("Error.aspx")

        End If

    End Sub
    Private Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

        AddHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

        Try
            Me._MasterPage = CType(Me.Page.Master, Webvantage.ChildPage)
        Catch ex As Exception
            Me._MasterPage = Nothing
        End Try

        ''Try
        ''    If Me.IsClientPortal = True Then
        ''        If Not Request.Cookies("MY_SETTINGS_CP")("TELERIK_THEME") Is Nothing Then
        ''            Select Case Request.Cookies("MY_SETTINGS_CP")("TELERIK_THEME").ToString()
        ''                Case "Default"
        ''                    Me.Theme = "TelerikDefault"
        ''                Case "Telerik"
        ''                    Me.Theme = "TelerikTheme"
        ''                Case Else
        ''                    Me.Theme = Request.Cookies("MY_SETTINGS_CP")("TELERIK_THEME").ToString()
        ''            End Select
        ''        End If
        ''    Else
        ''        If Not Request.Cookies("MY_SETTINGS")("TELERIK_THEME") Is Nothing Then
        ''            Select Case Request.Cookies("MY_SETTINGS")("TELERIK_THEME").ToString()
        ''                Case "Default"
        ''                    Me.Theme = "TelerikDefault"
        ''                Case "Telerik"
        ''                    Me.Theme = "TelerikTheme"
        ''                Case Else
        ''                    Me.Theme = Request.Cookies("MY_SETTINGS")("TELERIK_THEME").ToString()
        ''            End Select
        ''        End If
        ''    End If

        ''Catch ex As Exception
        ''    Me.Theme = "Bootstrap"
        ''End Try

        '''RadFormDecorator screws up some Javascript in web-kit browsers, disable if 2 main web-kit browsers detected
        ''If MiscFN.BrowserTypeIs(Browser_Types.Chrome) = True Or MiscFN.BrowserTypeIs(Browser_Types.Safari) Then
        ''    Me.EnableRadFormDecorator = False
        ''End If

    End Sub
    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        'Me.Querystring = Me.Querystring.FromCurrent()

    End Sub
    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Me.AllowFloat = False Then
            'Me.BodyTag.Attributes.Add("onload", "CheckWnd();")
            Me.Page.ClientScript.RegisterClientScriptBlock(Me.Page.GetType(), "CheckWindow", "CheckWnd();", True)
        End If
    End Sub
    Private Sub Page_Unload(sender As Object, e As System.EventArgs) Handles Me.Unload

        RemoveHandler AdvantageFramework.Navigation.ShowMessageBoxEvent, AddressOf ShowMessageBox

    End Sub

    Public Sub FocusControl(ByVal [Control] As Web.UI.Control)

        [Control].Focus()

    End Sub

#Region " Bookmark "

    Public Enum BookmarkType
        ProjectSchedule
        JobJacket
        Estimate
        EstimateQuote
        PurchaseOrder
    End Enum
    Public Sub BookmarkSave(ByVal [Type] As BookmarkType)
        Dim PageName As String = HttpContext.Current.Request.Url.ToString()
    End Sub
    Public Sub BookmarkRemove(ByVal [Type] As BookmarkType)

    End Sub
    Public Function BookmarksGet() As DataTable

    End Function

#End Region

    Public Sub SetRadDatePicker(ByRef RadDatePicker As Telerik.Web.UI.RadDatePicker)

        Dim Today As New RadCalendarDay
        Today.Date = Me.TimeZoneToday
        Today.ItemStyle.CssClass = "radcalendar-today"
        RadDatePicker.Calendar.SpecialDays.Add(Today)

    End Sub

    Public Function AddCardContent(ByVal Key As String, ByVal Value As String,
                                   Optional ByVal Trim As Boolean = False,
                                   Optional IsHTMLValue As Boolean = False, Optional IsNumericValue As Boolean = False) As String

        Dim Colon As String = ":"
        Dim ShortValue As String = ""
        Dim ValueCSS As String = "content-value"

        Key = Key.Trim()
        Value = Value.Trim()

        If Key = "" AndAlso Value = "" Then

            Return "<br/>"

        Else

            If Key = "" Or Key.EndsWith("?") = True Then Colon = ""

            'If Trim = True Then 'replace with CSS?

            ShortValue = If(Value.Length > 29, Value.Substring(0, 29) & "...", Value)

            'End If

            If IsNumericValue = True Then

                ValueCSS &= "-numeric"

            End If

            If IsHTMLValue = False OrElse Trim = True Then

                Return String.Format("<div class=""content-key-value""><div class=""content-key"">{0}{4}</div><div title=""{1}"" class=""{3}"">{2}</div></div>", Key, Value, ShortValue, ValueCSS, Colon)

            Else

                Return String.Format("<div class=""content-key-value""><div class=""content-key"">{0}{3}</div><div class=""{2}"">{1}</div></div>", Key, Value, ValueCSS, Colon)

            End If

        End If

    End Function

    Public Sub CheckForStopwatch()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CheckForStopwatch()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub HideAlertNotificationWindow()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.HideAlertNotificationWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub OpenTimesheetStopwatchNotificationWindow()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.OpenTimesheetStopwatchNotificationWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub ShowAlertNotificationWindow()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.ShowAlertNotificationWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RedirectFloatingWindow()
        Try

        Catch ex As Exception

        End Try
    End Sub
    Public Sub RefreshMDIPage()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshMDIPage()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub BackToSignInPage()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.BackToSignInPage()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshCaller(ByVal Caller As String, Optional ByVal CloseThisWindow As Boolean = False, Optional ByVal ForceNewURL As Boolean = False,
                             Optional ByVal OpenCallerIfNotFound As Boolean = False)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshCaller(Caller, CloseThisWindow, ForceNewURL, OpenCallerIfNotFound)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub SimpleClose()
        Me._MasterPage.SimpleClose()
    End Sub

    Public Sub CloseThisWindowAndOpenNewWindow(ByVal [URL] As String, Optional ByVal ForceNewURL As Boolean = False)
        Me.CloseThisWindowAndRefreshCaller(URL, ForceNewURL, True)
    End Sub
    Public Sub CloseThisWindowAndRefreshCaller(ByVal Caller As String, Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseThisWindowAndRefreshCaller(Caller, ForceNewURL, OpenCallerIfNotFound)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CloseThisWindowAndRefreshCallerAdvanced(ByVal PageName As String, Optional ByVal RefreshFunction As String = "", Optional ByVal QueryString As String = "", Optional ByVal ForceNewURL As Boolean = False, Optional ByVal OpenCallerIfNotFound As Boolean = False)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseThisWindowAndRefreshCallerAdvanced(PageName, RefreshFunction, QueryString, ForceNewURL, OpenCallerIfNotFound)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CloseThisWindowAndRefreshChildPageGrid(ByVal ChildPageName As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseThisWindowAndRefreshChildPageGrid(ChildPageName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub BillingApprovalBatchCreated()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.BillingApprovalBatchCreated()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTasks()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshTasks()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CopyToClipboard(ByVal Text As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CopyToClipboard(Text)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshDashboardReviews()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshDashboardReviews()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshDashboardAlerts()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshDashboardAlerts()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshDashboardAssignments()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshDashboardAssignments()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshAlertWindows(Optional ByVal CloseThisWindow As Boolean = True,
                                   Optional ByVal IncludeAlertDesktopObject As Boolean = True,
                                   Optional ByVal IncludeProjectSchedulePage As Boolean = False,
                                   Optional ByVal IncludeAlertInbox As Boolean = True,
                                   Optional ByVal IncludeDashboard As Boolean = True,
                                   Optional ByVal FromContent As Boolean = False)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshAlertWindows(CloseThisWindow, IncludeAlertDesktopObject, IncludeProjectSchedulePage, IncludeAlertInbox, IncludeDashboard, FromContent)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshAlertRecipients()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshAlertRecipients()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshInOutBoardObjects(ByVal CurrentObjectName As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshInOutBoardObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshJobRequestObjects(ByVal CurrentObjectName As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshJobRequestObjects(CurrentObjectName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetDesktopObject(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshTimesheetDesktopObject(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshTimesheetWindows(Optional ByVal CloseThisWindow As Boolean = True)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshTimesheetWindows(CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshChildPageGrid(ByVal PageName As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshChildPageGrid(PageName)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CalendarSync(ByVal EmployeeNonTaskID As Integer, ByVal IsHoliday As Boolean, ByVal IsDeleting As Boolean)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CalendarSync(EmployeeNonTaskID, IsHoliday, IsDeleting)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub SendEmail(ByVal Guid As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.SendEmail(Guid)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CheckForAsyncMessage()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CheckForAsyncMessage()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub ReviewGenerateFeedbackSummary(ByVal ConceptShareProjectID As Integer, ByVal ConceptShareReviewID As Integer)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.ReviewGenerateFeedbackSummary(ConceptShareProjectID, ConceptShareReviewID)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    'Public Sub OpenWindowFromQueryString(Optional ByVal CustomWindowTitle As String = "", Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, _
    '                                     Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False)

    '    If Not Me.Querystring Is Nothing Then

    '        Me.OpenWindow(Me.Querystring, CustomWindowTitle, Height, Width, CloseCurrentWindowAfterOpen, IsModal)

    '    End If

    'End Sub
    Public Sub OpenPrintSendSilently(ByVal QS As AdvantageFramework.Web.QueryString)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.OpenPrintSendSilently(QS)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub OpenWindow(ByVal QS As AdvantageFramework.Web.QueryString, Optional ByVal CustomWindowTitle As String = "", Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                    Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False, Optional Callback As String = Nothing)

        Me.OpenWindow(CustomWindowTitle, QS.ToString(True), Height, Width, CloseCurrentWindowAfterOpen, IsModal, Callback)

    End Sub
    Public Overloads Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                                    Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False, Optional Callback As String = Nothing)
        If Not Me._MasterPage Is Nothing Then
            ''I will be removing the Title param. It throws off the window tracking.  The title needs to be set on the page, not from this opener 
            'If [URL].Contains(".aspx") = True Then
            '    Title = ""
            'End If
            Me._MasterPage.OpenWindow(Title, URL, Height, Width, CloseCurrentWindowAfterOpen, IsModal, Callback)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub RefreshBookmarksDesktopObject()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.RefreshBookmarksDesktopObject()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CloseThisWindow()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseThisWindow()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub CloseDialog()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseDialog()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub

    Public Sub CloseThisWindowNew()
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CloseThisWindowNew()
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub OpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                          Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0)
        If Not Me._MasterPage Is Nothing Then

            If MiscFN.BrowserTypeIs(Browser_Types.IE) = True Then [Title] = ""
            Me._MasterPage.OpenFloatingWindow(Title, URL, Height, Width, Top, Left)

        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Function HookUpOpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0,
                              Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As String
        If Not Me._MasterPage Is Nothing Then
            Return Me._MasterPage.HookUpOpenFloatingWindow("", URL, Height, Width, Top, Left)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Protected Overridable Sub ShowMessageBox(ByVal Message As String, ByVal MessageBoxButtons As AdvantageFramework.WinForm.MessageBox.MessageBoxButtons, ByVal Title As String, ByRef DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.ShowMessageBox(Message, MessageBoxButtons, Title, DialogResult)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub ShowMessage(ByVal ErrorMessage As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.ShowMessage(ErrorMessage)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub CallFunctionOnParentPage(Optional ByVal CallingWindowPageName As String = "", Optional ByVal FunctionName As String = "", Optional ByVal CloseThisWindow As Boolean = False)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CallFunctionOnParentPage(CallingWindowPageName, FunctionName, CloseThisWindow)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub OpenLookUpRecipients(ByVal [URL] As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.OpenLookUpRecipients(URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Sub OpenLookUp(ByVal [URL] As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.OpenLookUp(URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.HookUpLookUp(LookUpHyperLink, URL)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Overloads Function HookUpLookUp(ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "", Optional ByVal JavascriptToExecuteAfter As String = "") As String
        If Not Me._MasterPage Is Nothing Then
            Return Me._MasterPage.HookUpLookUp(URL, JavascriptToExecuteBefore, JavascriptToExecuteAfter)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Public Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal CallBack As String = Nothing, Optional ByVal Param As String = Nothing) As String
        If Not Me._MasterPage Is Nothing Then
            Return Me._MasterPage.HookUpOpenWindow(Title, URL, Height, Width, CloseCurrentWindowAfterOpen, CallBack, Param)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Function
    Public Sub HookUpOpenWindow(ByRef Control As WebControl, ByVal [URL] As String, Optional Title As String = "", Optional ByVal Modal As Boolean = False, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0)
        With Control.Attributes
            .Remove("onclick")
            .Add("onclick", "OpenRadWindow('','" & [URL] & "',0,0, " & Modal.ToString().ToLower() & ");return false;")
        End With
    End Sub
    Public Sub CallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.CallUiAction(Action, ExtraQuerystringParameters)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Public Function HookUpCallUiAction(ByVal Action As Webvantage.UI_Action.ActionType, ByVal ExtraQuerystringParameters As String) As String
        If Not Me._MasterPage Is Nothing Then
            Return Me._MasterPage.HookUpCallUiAction(Action, ExtraQuerystringParameters)
        Else
            Return "return false;"
        End If
    End Function
    Public Sub AddJavascriptToPage(ByVal Javascript As String)
        If Not Me._MasterPage Is Nothing Then
            Me._MasterPage.AddJavascriptToPage(Javascript)
        Else
            Me.ApplicationMostLikelyGotReset()
        End If
    End Sub
    Private Sub ApplicationMostLikelyGotReset()
        Try
            With HttpContext.Current.Response
                .Write("<script type=""text/javascript"">GetRadWindow().BrowserWindow.GoToSignIn();</script>")
            End With
        Catch ex As Exception
        End Try
    End Sub

End Class

<Serializable()> Public Class BasePageShared
    Inherits System.Web.UI.Page

#Region " Constants "

    Private Const ItemsPerRequest As Integer = 10

#End Region

#Region " Enum "

    Public Enum Lockable_Applications
        Estimating = 0
        ProjectSchedule = 1
        JobJacket = 2
        PurchaseOrder = 3
        All_Lockable_Apps = 4
    End Enum
    Public Enum [TkTheme]
        Large
        Small
    End Enum

#End Region

#Region " Variables "

    Public _Session As AdvantageFramework.Security.Session = Nothing
    Private mRadScriptManagerParent As New Telerik.Web.UI.RadScriptManager
    Private mRadToolTipManagerParent As New Telerik.Web.UI.RadToolTipManager

#End Region

#Region " Properties "

    Public ReadOnly Property SecuritySession As AdvantageFramework.Security.Session
        Get
            Dim Session As AdvantageFramework.Security.Session = TryCast(HttpContext.Current.Session("Security_Session"), AdvantageFramework.Security.Session)
            Return Session
        End Get
    End Property
    Public ReadOnly Property IsNTAuth() As Boolean
        Get
            Return MiscFN.IsNTAuth()
        End Get
    End Property
    'Public ReadOnly Property EnableBookmarks() As Boolean
    '    Get
    '        Return MiscFN.EnableBookmarks()
    '    End Get
    'End Property
    Public Property RadScriptManagerParent() As Telerik.Web.UI.RadScriptManager
        Get
            Return Me.mRadScriptManagerParent
        End Get
        Set(ByVal value As Telerik.Web.UI.RadScriptManager)
            Me.mRadScriptManagerParent = value
        End Set
    End Property
    Public Property RadToolTipManagerParent() As Telerik.Web.UI.RadToolTipManager
        Get
            Return Me.mRadToolTipManagerParent
        End Get
        Set(ByVal value As Telerik.Web.UI.RadToolTipManager)
            Me.mRadToolTipManagerParent = value
        End Set
    End Property
    Public WriteOnly Property IncludeRadToolTipManagerOnAjaxUpdateJavascriptEvent() As Boolean
        Set(ByVal value As Boolean)
            If value = True Then
                'Me.RadToolTipManagerParent.Attributes.Add("OnAjaxUpdate", "OnAjaxUpdate")
            End If
        End Set
    End Property
    Public ReadOnly Property EventTarget() As String
        Get
            Try
                If String.IsNullOrWhiteSpace(Me.Page.Request.Form("__EVENTTARGET")) = False Then

                    Return Me.Page.Request.Form("__EVENTTARGET").ToString().Replace("onclick#", "")

                Else

                    Return ""

                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property EventArgument() As String
        Get
            Try
                If String.IsNullOrWhiteSpace(Me.Page.Request.Form("__EVENTARGUMENT")) = False Then

                    Return Me.Page.Request.Form("__EVENTARGUMENT").ToString().Replace("onclick#", "")

                Else

                    Return ""

                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property CallingPage() As String
        Get
            Try
                If Not Request.QueryString("caller") Is Nothing Then
                    Return Request.QueryString("caller").ToString()
                End If
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property PageFilename() As String
        Get
            Try
                Return Path.GetFileName(Request.Path)
            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public ReadOnly Property IsClientPortal() As Boolean
        Get
            Try
                Return MiscFN.IsClientPortal()
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    Public Property WebvantageLink As String
        Get
            If ViewState("WebvantageLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("WebvantageLink")
            End If
        End Get
        Set(value As String)
            ViewState("WebvantageLink") = value
        End Set
    End Property
    Public Property ClientPortalLink As String
        Get
            If ViewState("ClientPortalLink") Is Nothing Then
                Return String.Empty
            Else
                Return ViewState("ClientPortalLink")
            End If
        End Get
        Set(value As String)
            ViewState("ClientPortalLink") = value
        End Set
    End Property
    Public ReadOnly Property CurrentQuerystring As AdvantageFramework.Web.QueryString
        Get

            Dim qs As New AdvantageFramework.Web.QueryString
            qs = qs.FromCurrent()
            Return qs

        End Get
    End Property
    ''''Public ReadOnly Property DeepLink As String
    ''''    Get

    ''''        Dim s As String = String.Empty

    ''''        Try

    ''''            If Me._Session IsNot Nothing Then

    ''''                Dim qs As New AdvantageFramework.Web.QueryString
    ''''                qs = qs.FromCurrent()

    ''''                If qs IsNot Nothing Then

    ''''                    Dim Deep As New AdvantageFramework.Web.DeepLink(Me._Session)
    ''''                    s = Deep.Build(AdvantageFramework.Web.DeepLink.LinkType.External, qs)

    ''''                End If

    ''''            End If

    ''''            Return s

    ''''        Catch ex As Exception
    ''''            Return String.Empty
    ''''        End Try

    ''''    End Get
    ''''End Property
    Public ReadOnly Property CurrentTheme As BasePageShared.TkTheme
        Get

            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))
            t.Load()

            If t.Settings.TelerikTheme.ToLower() = "bootstrap" Then
                Return TkTheme.Large
            Else
                Return TkTheme.Small
            End If

        End Get
    End Property

#End Region

#Region " Methods "

#Region " Page "

    '''''Compress Viewstate
    ''''Protected Overrides Function LoadPageStateFromPersistenceMedium() As Object

    ''''    Dim viewState As String = Request.Form("__VSTATE")
    ''''    Dim bytes As Byte() = Convert.FromBase64String(viewState)
    ''''    bytes = ViewStateCompressor.Decompress(bytes)
    ''''    Dim formatter As New LosFormatter()
    ''''    Return formatter.Deserialize(Convert.ToBase64String(bytes))

    ''''End Function
    ''''Protected Overrides Sub SavePageStateToPersistenceMedium(viewState As Object)

    ''''    Dim formatter As New LosFormatter()
    ''''    Dim writer As New StringWriter()
    ''''    formatter.Serialize(writer, viewState)
    ''''    Dim viewStateString As String = writer.ToString()
    ''''    Dim bytes As Byte() = Convert.FromBase64String(viewStateString)
    ''''    bytes = ViewStateCompressor.Compress(bytes)
    ''''    ClientScript.RegisterHiddenField("__VSTATE", Convert.ToBase64String(bytes))

    ''''End Sub

    Private Sub Page_PreInit(sender As Object, e As System.EventArgs) Handles Me.PreInit

        If Session("Security_Session") Is Nothing AndAlso Not Session("ConnString") Is Nothing AndAlso Not Session("UserCode") Is Nothing Then

            If Session("UserGUID") IsNot Nothing Then

                _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))
                Session("Security_Session") = _Session

            Else

                _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))
                Session("Security_Session") = _Session

            End If

        Else

            _Session = Session("Security_Session")

        End If

        Try

            Dim t As New UserTheme(Session("EmpCode"), Session("UserCode"), Session("ConnString"))

            t.Load()

            With Me.Page

                .Culture = LoGlo.UserCultureGet()
                .UICulture = LoGlo.UserCultureGet()
                .Theme = t.Settings.AppTheme

            End With

        Catch ex As Exception
        End Try

        Try

            AdvantageFramework.Security.WriteToWebvantageEventLog = cApplication.WriteToWebvantageEventLog

        Catch ex As Exception

        End Try

    End Sub
    Private Sub BasePageShared_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If HttpContext.Current.Session("ConnString") Is Nothing AndAlso HttpContext.Current.Response.IsRequestBeingRedirected = False Then 'natural timeout most likely occurred.

                AdvantageFramework.Security.AddWebvantageEventLog("BasePage.vb (BasePageShared): connection string is nothing (most likely session timeout occurred ")
                HttpContext.Current.Response.Redirect("SignIn.aspx?m=13", True)
                Exit Sub

            End If
            If HttpContext.Current.Session("ConnString") IsNot Nothing AndAlso HttpContext.Current.Session("ConnString").ToString().Trim() = "" AndAlso
                    HttpContext.Current.Response.IsRequestBeingRedirected = False Then

                AdvantageFramework.Security.AddWebvantageEventLog("BasePage.vb (BasePageShared): connection string is blank ")
                HttpContext.Current.Response.Redirect("SignIn.aspx?m=1", True)
                Exit Sub

            End If

        Catch ex As Exception

            HttpContext.Current.Response.Redirect("SignIn.aspx", True)
            Exit Sub

        End Try

    End Sub
    Private Sub Page_Error(sender As Object, e As EventArgs) Handles Me.Error



    End Sub

#End Region
#Region " Application Access "

    Public Function LoadUserSetting(ByVal Setting As AdvantageFramework.Security.UserSettings) As Boolean

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "LoadUserSetting" & Setting.ToString()

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try

                If AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Setting) Then

                    IsValid = True

                Else

                    IsValid = False

                End If

            Catch ex As Exception

                IsValid = False

            End Try

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function

    Public Function CheckUserGroupSetting(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
        Dim SessionKey As String = "CheckUserGroupSetting" & GroupSetting.ToString()
        Dim i As Integer = 0
        If Session(SessionKey) Is Nothing Then
            Try
                i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, GroupSetting).Any(Function(SettingValue) SettingValue = True))
            Catch ex As Exception
                i = 0
            End Try
        Else
            i = CType(Session(SessionKey), Integer)
        End If
        Return i
    End Function

    Public Function CheckEmployeeAccess(ByVal EmpCode As String) As Boolean
        If Me.HasAccessToEmployee(EmpCode) = False Then
            Server.Transfer("NoAccess.aspx")
        End If
    End Function

    Public Function HasAccessToEmployee(ByVal EmpCode As String) As Boolean
        Dim SessionKey As String = "HasAccessToEmployee" & EmpCode.Trim()
        Dim HasAccess As Boolean = False
        If Session(SessionKey) Is Nothing Then
            Try
                Dim arP(2) As SqlParameter

                Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                pUserId.Value = HttpContext.Current.Session("UserCode").ToString()
                arP(0) = pUserId

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode.Trim()
                arP(1) = pEmpCode

                If CType(SqlHelper.ExecuteScalar(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_SEC_EMP_CHECK_ACCESS", arP), Integer) = 0 Then
                    HasAccess = False
                Else
                    HasAccess = True
                End If

            Catch ex As Exception
                HasAccess = False
            End Try
        Else
            HasAccess = CType(Session(SessionKey), Boolean)
        End If
        Return HasAccess
    End Function

    Public Function EnableBookmarks() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "EnableBookmarks"

        Return True

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try

                IsValid = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_DesktopObjects_BookmarksDO, False) = 1

            Catch ex As Exception

                IsValid = False

            End Try

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function

    Public Sub CheckAndSaveAllSecurityForModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission)

        CheckModuleAccess(UserPermission, True)
        UserHasAccessToAddNew(UserPermission, True)

        UserCanPrintInModule(UserPermission, True)
        UserCanUpdateInModule(UserPermission, True)
        UserCanAddInModule(UserPermission, True)
        UserCanCustom1Module(UserPermission, True)
        UserCanCustom2Module(UserPermission, True)

    End Sub
    Public Overloads Function CheckModuleAccess(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        'objects
        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(UserPermission)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                Session(SessionKey) = ModuleAccess

            End If

        End If

        CheckModuleAccess = ModuleAccess

    End Function

    Public Overloads Function CheckModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

        Dim ModuleAccess As Integer = 1

        ModuleAccess = CheckModuleAccess([Module].ToString, TransferToNoAccessPage)

        Return ModuleAccess

    End Function

    Public Overloads Function CheckModuleAccess(ByVal ModuleCode As String, Optional ByVal TransferToNoAccessPage As Boolean = True) As Integer

        Dim ModuleAccess As Integer = 1
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode

        If Session(SessionKey) Is Nothing Then

            If Me.IsClientPortal Then

                Try
                    ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(_Session, ModuleCode)
                Catch ex As Exception
                    ModuleAccess = 1
                End Try

            Else

                Try

                    ModuleAccess = CheckModuleAccess(_Session.User, ModuleCode, False)

                Catch ex As Exception
                    ModuleAccess = 1
                End Try

            End If

            Session(SessionKey) = ModuleAccess
        Else
            ModuleAccess = CType(Session(SessionKey), Integer)
        End If

        If ModuleAccess = 0 And TransferToNoAccessPage = True Then
            Server.Transfer("NoAccess.aspx")
        End If

        If ModuleAccess = -1 Then ModuleAccess = 1

        Return ModuleAccess

    End Function
    Public Overloads Function CheckModuleAccess(ByVal ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesClientPortalUserHaveAccessToModule(_Session, ModuleCode)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                Session(SessionKey) = ModuleAccess

            End If

        End If

        Return ModuleAccess

    End Function
    Public Overloads Function CheckModuleAccess(ByVal User As AdvantageFramework.Security.Classes.User, ByVal ModuleCode As String, ByVal SaveValueToSession As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                ModuleAccess = CType(Session(SessionKey), Integer)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, ModuleCode, User)

            Catch ex As Exception
                ModuleAccess = 0
            End Try

            If ModuleAccess = -1 Then

                ModuleAccess = 1

            End If

            If SaveValueToSession Then

                Session(SessionKey) = ModuleAccess

            End If

        End If

        Return ModuleAccess

    End Function

    Public Overloads Function CheckAdvantageModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules, ByVal TransferToNoAccessPage As Boolean) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

        If Session(SessionKey) IsNot Nothing Then

            ModuleAccess = CType(Session(SessionKey), Integer)

        Else

            Try

                Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(DbContext, 1, [Module].ToString(), _Session.User.ID)

                End Using

            Catch ex As Exception

                ModuleAccess = 0

            End Try

            If ModuleAccess = -1 Then ModuleAccess = 1

            Session(SessionKey) = ModuleAccess

            If ModuleAccess = 0 And TransferToNoAccessPage = True Then Server.Transfer("NoAccess.aspx")

        End If

        Return ModuleAccess

    End Function
    Public Overloads Function CheckAdvantageModuleAccess(ByVal [Module] As AdvantageFramework.Security.Modules) As Integer

        Dim ModuleAccess As Integer = 0
        Dim SessionKey As String = "CheckModuleAccess" & [Module].ToString()

        If Session(SessionKey) IsNot Nothing Then

            ModuleAccess = CType(Session(SessionKey), Integer)

        Else

            Try

                Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ModuleAccess = AdvantageFramework.Security.DoesUserHaveAccessToModule(DbContext, 1, [Module].ToString(), _Session.User.ID)

                End Using

            Catch ex As Exception

                ModuleAccess = 0

            End Try

            If ModuleAccess = -1 Then ModuleAccess = 1

            Session(SessionKey) = ModuleAccess

        End If

        Return ModuleAccess

    End Function

    Public Function UserHasAccessToAddNew(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        ''bypass
        'Return True
        Dim UserDoesHaveAccess As Boolean = False
        Dim SessionKey As String = "UserHasAccessToAddNew" & SecurityModule.ToString()
        If Session(SessionKey) Is Nothing Then
            If Me.CheckModuleAccess(SecurityModule.ToString(), False) = 1 _
               And Me.UserCanAddInModule(SecurityModule) = True Then
                UserDoesHaveAccess = True
            Else
                UserDoesHaveAccess = False
            End If
            Session(SessionKey) = UserDoesHaveAccess
        Else
            UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
        End If
        Return UserDoesHaveAccess
    End Function
    Public Function UserHasAccessToAddNew(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Boolean

        Dim UserDoesHaveAccess As Boolean = False
        Dim SessionKey As String = "UserHasAccessToAddNew" & UserPermission.ModuleCode
        If Session(SessionKey) Is Nothing Then
            If Me.CheckModuleAccess(UserPermission, True) = 1 _
               And Me.UserCanAddInModule(UserPermission, True) = True Then
                UserDoesHaveAccess = True
            Else
                UserDoesHaveAccess = False
            End If
            Session(SessionKey) = UserDoesHaveAccess
        Else
            UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
        End If
        Return UserDoesHaveAccess

    End Function

    Public Function UserCanPrintInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanPrint = UserCanPrintInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanPrint = False
            End Try

            Session(SessionKey) = CanPrint

        Else
            CanPrint = CType(Session(SessionKey), Boolean)
        End If
        Return CanPrint
    End Function
    Public Function UserCanPrintInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanPrint = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanPrint = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanPrint

            End If

        End If

        Return CanPrint

    End Function
    Public Function UserCanPrintInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanPrint As Boolean = False
        Dim SessionKey As String = "UserCanPrintInModule" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanPrint = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanPrint = AdvantageFramework.Security.CanUserPrintInModule(UserPermission)

            Catch ex As Exception
                CanPrint = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanPrint

            End If

        End If

        Return CanPrint

    End Function

    Public Function UserCanUpdateInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanUpdate = UserCanUpdateInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanUpdate = False
            End Try

            Session(SessionKey) = CanUpdate

        Else
            CanUpdate = CType(Session(SessionKey), Boolean)
        End If
        Return CanUpdate
    End Function

    Public Function UserCanUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanUpdate = UserCanUpdateInModule(DbContext, ApplicationID, _Session.User, SecurityModule, False)

            Catch ex As Exception
                CanUpdate = False
            End Try

            Session(SessionKey) = CanUpdate

        Else
            CanUpdate = CType(Session(SessionKey), Boolean)
        End If
        Return CanUpdate
    End Function

    Public Function UserCanUpdateInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanUpdate = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanUpdate = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanUpdate

            End If

        End If

        Return CanUpdate

    End Function

    Public Function UserCanUpdateInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanUpdate = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(DbContext, ApplicationID, SecurityModule.ToString, User.UserCode)

            Catch ex As Exception
                CanUpdate = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanUpdate

            End If

        End If

        Return CanUpdate

    End Function
    Public Function UserCanUpdateInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanUpdate As Boolean = False
        Dim SessionKey As String = "UserCanUpdateInModule" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanUpdate = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(UserPermission)

            Catch ex As Exception
                CanUpdate = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanUpdate

            End If

        End If

        Return CanUpdate

    End Function

    Public Function UserCanAddInModule(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanAdd = UserCanAddInModule(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanAdd = False
            End Try

            Session(SessionKey) = CanAdd

        Else
            CanAdd = CType(Session(SessionKey), Boolean)
        End If
        Return CanAdd
    End Function
    Public Function UserCanAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanAdd = UserCanAddInModule(DbContext, ApplicationID, _Session.User, SecurityModule, False)

            Catch ex As Exception
                CanAdd = False
            End Try

            Session(SessionKey) = CanAdd

        Else
            CanAdd = CType(Session(SessionKey), Boolean)
        End If
        Return CanAdd
    End Function

    Public Function UserCanAddInModule(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanAdd = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanAdd = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanAdd

            End If

        End If

        Return CanAdd

    End Function

    Public Function UserCanAddInModule(ByVal DbContext As AdvantageFramework.Security.Database.DbContext, ByVal ApplicationID As Integer, ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanAdd = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanAdd = AdvantageFramework.Security.CanUserAddInModule(DbContext, ApplicationID, SecurityModule.ToString, User.UserCode)

            Catch ex As Exception
                CanAdd = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanAdd

            End If

        End If

        Return CanAdd

    End Function
    Public Function UserCanAddInModule(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanAdd As Boolean = False
        Dim SessionKey As String = "UserCanAddInModule" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanAdd = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanAdd = AdvantageFramework.Security.CanUserAddInModule(UserPermission)

            Catch ex As Exception
                CanAdd = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanAdd

            End If

        End If

        Return CanAdd

    End Function

    Public Function UserCanCustom1Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanCustom1 = UserCanCustom1Module(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            Session(SessionKey) = CanCustom1

        Else

            CanCustom1 = CType(Session(SessionKey), Boolean)

        End If

        UserCanCustom1Module = CanCustom1

    End Function
    Public Function UserCanCustom1Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom1 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(_Session, SecurityModule)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom1

            End If

        End If

        UserCanCustom1Module = CanCustom1

    End Function
    Public Function UserCanCustom1Module(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom1 As Boolean = False
        Dim SessionKey As String = "UserCanCustom1Module" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom1 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(UserPermission)

            Catch ex As Exception
                CanCustom1 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom1

            End If

        End If

        Return CanCustom1

    End Function

    Public Function UserCanCustom2Module(ByVal SecurityModule As AdvantageFramework.Security.Modules) As Boolean
        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()

        If Session(SessionKey) Is Nothing Then

            Try

                CanCustom2 = UserCanCustom2Module(_Session.User, SecurityModule, False)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            Session(SessionKey) = CanCustom2

        Else
            CanCustom2 = CType(Session(SessionKey), Boolean)
        End If
        Return CanCustom2
    End Function
    Public Function UserCanCustom2Module(ByVal User As AdvantageFramework.Security.Classes.User, ByVal SecurityModule As AdvantageFramework.Security.Modules, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & SecurityModule.ToString()
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom2 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(_Session, SecurityModule, User)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom2

            End If

        End If

        Return CanCustom2

    End Function
    Public Function UserCanCustom2Module(ByVal UserPermission As AdvantageFramework.Security.Database.Views.UserPermission, ByVal SaveValueToSession As Boolean) As Integer

        Dim CanCustom2 As Boolean = False
        Dim SessionKey As String = "UserCanCustom2Module" & UserPermission.ModuleCode
        Dim FoundExistingValue As Boolean = False

        If SaveValueToSession Then

            If Session(SessionKey) IsNot Nothing Then

                FoundExistingValue = True

                CanCustom2 = CType(Session(SessionKey), Boolean)

            End If

        End If

        If FoundExistingValue = False Then

            Try

                CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(UserPermission)

            Catch ex As Exception
                CanCustom2 = False
            End Try

            If SaveValueToSession Then

                Session(SessionKey) = CanCustom2

            End If

        End If

        Return CanCustom2

    End Function

    Public Function LoadUserGroupSettingAccess(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
        Dim i As Integer = 0
        Dim SessionKey As String = "LoadUserGroupSettingAccess" & GroupSetting.ToString()
        If Session(SessionKey) Is Nothing Then
            i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, GroupSetting).Any(Function(SettingValue) SettingValue = True))
            Session(SessionKey) = i
        Else
            i = CType(Session(SessionKey), Integer)
        End If
        Return i
    End Function

    'Public Function LoadUserGroupSettingAccessBool(ByVal GroupSetting As AdvantageFramework.Security.GroupSettings) As Integer
    '    Dim HasAccess As Boolean = False
    '    Dim SessionKey As String = "LoadUserGroupSettingAccess" & GroupSetting.ToString()
    '    If Session(SessionKey) Is Nothing Then
    '        i = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, GroupSetting).Any(Function(SettingValue) SettingValue = True))
    '        Session(SessionKey) = i
    '    Else
    '        i = CType(Session(SessionKey), Integer)
    '    End If
    '    Return i
    'End Function


    'this basically just needed for user_code that has multiple employee codes (multiple recs) in SEC_EMP
    Public Function AccessOnlyToSelf(ByRef SingleEmpCode As String, ByRef SingleEmpFML As String) As Boolean
        Dim UserDoesHaveAccess As Boolean = False
        Dim SessionKey As String = "AccessOnlyToSelf" & SingleEmpCode
        If Session(SessionKey) Is Nothing Then
            Try

                Dim pUserId As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                pUserId.Value = HttpContext.Current.Session("UserCode").ToString()

                Dim dt As New DataTable
                dt = SqlHelper.ExecuteDataTable(Session("ConnString"), CommandType.StoredProcedure, "usp_wv_SEC_EMP_RESTRICTED_TO_SELF", "dt", pUserId)
                If dt.Rows.Count > 0 AndAlso dt(0)("EMP_CODE").ToString().Trim() <> "" Then
                    SingleEmpCode = dt(0)("EMP_CODE")
                    SingleEmpFML = dt(0)("EMP_FML")
                    UserDoesHaveAccess = True
                End If
            Catch ex As Exception
                UserDoesHaveAccess = False
            End Try
        Else
            UserDoesHaveAccess = CType(Session(SessionKey), Boolean)
        End If
        Return UserDoesHaveAccess
    End Function

#End Region
#Region " Pagemethods for column change "

    <System.Web.Services.WebMethod()>
    Public Shared Sub ColumnChanged(ByVal GridName As String, ByVal ColumnName As String, ByVal IsVisible As Boolean)

        'objects
        Dim ASPGridNameParts() As String = Nothing
        Dim ASPGridName As String = ""

        ASPGridNameParts = Split(GridName, "_")

        If ASPGridNameParts.Length > 0 Then

            Try

                ASPGridName = ASPGridNameParts.Last

            Catch ex As Exception
                ASPGridName = ""
            Finally

                If ASPGridName <> "" Then

                    AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), ASPGridName, ColumnName, IsVisible)

                End If

            End Try

        End If

    End Sub

#End Region
#Region " Other shared pagemethods "


#End Region

    Public Sub DeliverGrid(ByVal TheGrid As DataTable, ByVal Filename As String)

        Session("EXPORT_GRID") = TheGrid
        Session("EXPORT_GRID_FILENAME") = Filename
        HttpContext.Current.Response.Redirect("Documents_StreamGrid.aspx")

    End Sub
    Public Sub DeliverFile(ByVal DocumentId As Integer)

        HttpContext.Current.Response.Redirect("Documents_StreamFile.aspx?id=" & DocumentId & "&cp=" & Me.IsClientPortal)

    End Sub
    Public Function Sanitize(ByVal StringToEncode As String) As String

        Dim s As String = ""

        Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
        Sanitizer.AllowDataAttributes = True
        Sanitizer.AllowedAttributes.Add("class")
        s = Sanitizer.Sanitize(StringToEncode)
        If s = "" Then s = HttpUtility.HtmlEncode(StringToEncode)

        Return s
        'Return Server.UrlEncode(StringToEncode)

    End Function
    Public Sub DisableButtonOnClick(ByVal Button As System.Web.UI.WebControls.Button)

        Button.Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(Button, Nothing) + ";")

    End Sub
    Public Sub DisableRadButtonOnClick(ByVal RadButton As Telerik.Web.UI.RadButton)

        RadButton.Attributes.Add("onclick", " this.disabled = true; " + Page.ClientScript.GetPostBackEventReference(RadButton, Nothing) + ";")

    End Sub

#End Region

End Class

Public NotInheritable Class ViewStateCompressor

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Shared Function Compress(data As Byte()) As Byte()
        Dim output As New MemoryStream()
        Dim gzip As New GZipStream(output, CompressionMode.Compress, True)
        gzip.Write(data, 0, data.Length)
        gzip.Close()
        Return output.ToArray()
    End Function
    Public Shared Function Decompress(data As Byte()) As Byte()
        Dim input As New MemoryStream()
        input.Write(data, 0, data.Length)
        input.Position = 0
        Dim gzip As New GZipStream(input, CompressionMode.Decompress, True)
        Dim output As New MemoryStream()
        Dim buff As Byte() = New Byte(63) {}
        Dim read As Integer = -1
        read = gzip.Read(buff, 0, buff.Length)
        While read > 0
            output.Write(buff, 0, read)
            read = gzip.Read(buff, 0, buff.Length)
        End While
        gzip.Close()
        Return output.ToArray()
    End Function

#End Region

#Region " Methods "


    Private Sub New()
    End Sub

#End Region


End Class

Public Interface IRadWindowFunctions

    Sub ShowMessage(ByVal [ErrorMessage] As String)
    Sub ShowMessageBox(ByVal [ErrorMessage] As String, Optional ByVal [Title] As String = "")
    Sub BackToSignInPage(Optional ByVal Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage, Optional ByRef DBSessionId As String = "", Optional ByRef CurrSessionId As String = "")
    Sub OpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal IsModal As Boolean = False, Optional Callback As String = Nothing)
    Sub OpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0)
    Sub OpenLookUp(ByVal [URL] As String)
    Sub HookUpLookUp(ByRef LookUpHyperLink As System.Web.UI.WebControls.HyperLink, ByVal [URL] As String)
    Function HookUpLookUp(ByVal LookUpType As String, ByVal [URL] As String, Optional ByVal JavascriptToExecuteBefore As String = "", Optional ByVal JavascriptToExecuteAfter As String = "") As String
    Function HookUpOpenWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal CloseCurrentWindowAfterOpen As Boolean = False, Optional ByVal CallBack As String = Nothing, Optional ByVal Param As String = Nothing) As String
    Function HookUpOpenFloatingWindow(ByVal [Title] As String, ByVal [URL] As String, Optional ByVal Height As Integer = 0, Optional ByVal Width As Integer = 0, Optional ByVal Top As Integer = 0, Optional ByVal Left As Integer = 0) As String

End Interface
