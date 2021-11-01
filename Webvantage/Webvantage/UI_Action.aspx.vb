Imports Webvantage.wvTimeSheet
Imports System.Net
Imports System.IO

Public Class UI_Action
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum ActionType

        None = 0
        SaveWindowPositions = 1
        ResetTimesheetEmpCode = 2
        MarkAllEmailAsRead = 3
        ResetTimesheetCommentView = 4
        SaveColumnSetting = 5
        ResetDynamicReportSessionVariables = 6
        ResetAlertInboxBookmarkTrigger = 7
        OpenAlertInboxAsBookmark = 8
        ResetAlertInboxPageIndex = 9
        SetTimesheetEntryFromMainMenu = 10
        GetDocumentRepositoryDocument = 11
        ResetContractSessionVariables = 12
        ResetDivisionEditSessionVariables = 13
        ResetClientEditSessionVariables = 14
        ResetProductEditSessionVariables = 15
        CalendarSync = 16
        Email = 17
        CheckForAsyncMessage = 18
        ResetCRMCentralSessionVariables = 19
        OpenTimesheetToToday = 20
        ResetExpense_SelectItemsVariables = 21
        NewAppNotificationRead = 22
        NewAppNotificationHide = 23
        RenewSession = 24
        CheckSession = 25
        OpenTimesheetToThisWeek = 26
        ReviewGenerateFeedbackSummary = 27
        ResetCalendarSessionVariables = 28
        ResetProjectScheduleFindAndReplaceSessionVariables = 29

    End Enum

#End Region

#Region " Variables "

    Private _ActionType As ActionType = ActionType.None
    Private _Val1 As String = ""
    Private _WorkspaceID As Integer = 0
    Private _DocumentID As Integer = 0

#End Region

#Region " Properties "

    Private Property _QueryString As AdvantageFramework.Web.QueryString

#End Region

#Region " Page Events "

    Private Sub UI_Action_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim ShowMessage As Boolean = False
        Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
        Dim EmployeeNonTaskID As Integer = 0

        Me._QueryString = New AdvantageFramework.Web.QueryString
        Me._QueryString = Me._QueryString.FromCurrent()

        If IsNumeric(Me._QueryString.GetValue("action")) = True Then

            Me._ActionType = CType(CType(Me._QueryString.GetValue("action"), Integer), ActionType)

        Else

            Exit Sub

        End If

        If Me._ActionType = 0 Then Exit Sub

        Me._Val1 = Me._QueryString.GetValue("val").Trim()

        Try

            Select Case Me._ActionType

                Case ActionType.SaveWindowPositions

                    If Me._Val1 <> "" Then
                        Try

                            If IsNumeric(Me._QueryString.GetValue("workspace")) = True Then _WorkspaceID = CType(Me._QueryString.GetValue("workspace"), Integer)

                        Catch ex As Exception

                            _WorkspaceID = 0

                        End Try

                        If _WorkspaceID > 0 Then

                            If Me._Val1.IndexOf("DesktopObjectWindow.aspx?") > -1 Then

                                If Me.IsClientPortal = True Then

                                    Me.SaveWorkspaceObjectSizeAndPositionCP()

                                Else

                                    Me.SaveWorkspaceObjectSizeAndPosition()

                                End If

                            Else

                                Me.SaveUserFavoriteSizeAndPosition()

                            End If

                        End If

                    End If

                Case ActionType.ResetTimesheetEmpCode

                    Session("TimesheetEmpCode") = Nothing
                    Session("TimesheetStartDate") = Nothing

                Case ActionType.MarkAllEmailAsRead

                    Dim a As New cAlerts()
                    a.MarkAllAsRead()

                Case ActionType.ResetTimesheetCommentView

                    Dim cvs As New TimesheetCommentView
                    cvs.ClearSession()

                Case ActionType.SaveColumnSetting

                    If Me._Val1 <> "" Then

                        Dim ar() As String
                        ar = Me._Val1.Split("|")
                        Me.ColumnChanged(ar(1), ar(2), ar(3))

                    End If

                Case ActionType.ResetDynamicReportSessionVariables

                    Session("DRPT_UseBlankData") = True
                    Session("DRPT_DashboardLoaded") = False
                    Session("DRPT_Data") = Nothing

                    Session("DRPT_Criteria") = Nothing
                    Session("DRPT_FilterString") = Nothing
                    Session("DRPT_From") = Nothing
                    Session("DRPT_To") = Nothing
                    Session("DRPT_ShowJobsWithNoDetails") = Nothing
                    Session("DRPT_ParameterDictionary") = Nothing
                    Session("DRPT_Type") = Nothing
                    Session("DRPT_ShowGroupByBox") = Nothing
                    Session("DRPT_ShowViewCaption") = Nothing
                    Session("DRPT_ShowAutoFilterRow") = Nothing
                    Session("DRPT_ActiveFilter") = Nothing
                    Session("DRPT_ColumnsList") = Nothing
                    Session("DRPT_ColumnsListJV") = Nothing
                    Session("DRPT_ColumnsListJS") = Nothing
                    Session("DRPT_Layout") = Nothing
                    Session("DRPT_UDRCategory") = Nothing
                    Session("DRPT_Description") = Nothing
                    Session("DRPT_ViewOnly") = Nothing

                Case ActionType.ResetAlertInboxBookmarkTrigger

                    Session("AlertInboxIsBookmark") = Nothing

                Case ActionType.OpenAlertInboxAsBookmark

                    Session("AlertInboxIsBookmark") = Nothing

                    If Me._QueryString.GetValue("url") <> "" Then

                        Me.OpenWindow("", Server.UrlDecode(AdvantageFramework.Security.Encryption.ASCIIDecoding(Me._QueryString.GetValue("url"))))

                    End If

                Case ActionType.ResetAlertInboxPageIndex

                    Session("AlertsCurrentPageNumber") = 0

                Case ActionType.SetTimesheetEntryFromMainMenu

                    Session("MainTimesheetLoadDefault") = "1"
                    Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
                    Session("TimesheetStartDate") = cEmployee.TimeZoneToday.ToShortDateString()
                    Session("TimesheetMain_UserHasMadeASelection") = Nothing

                Case ActionType.GetDocumentRepositoryDocument

                    If IsNumeric(Me._Val1) = True Then

                        _DocumentID = CType(Me._Val1, Integer)

                        If Me.DocExists() = True Then

                            Me.DeliverFile(_DocumentID)

                        Else

                            Me.ShowMessage("Document does not exist")

                        End If

                    End If

                Case ActionType.ResetContractSessionVariables

                    Session("Contract_RadGridContractFees") = Nothing
                    Session("Contract_RadGridInternalContacts") = Nothing
                    Session("Contract_RadGridReports") = Nothing
                    Session("Contract_RadGridValueAdded") = Nothing

                Case ActionType.ResetDivisionEditSessionVariables

                    Session("DivisionEdit_RadGridSortKeys") = Nothing

                Case ActionType.ResetClientEditSessionVariables

                    Session("ClientEdit_RadGridSortKeys") = Nothing
                    Session("ClientEdit_SelectedDivisionCode") = Nothing

                Case ActionType.ResetProductEditSessionVariables

                    Session("ProductEdit_RadGridSortKeys") = Nothing
                    Session("ProductEdit_RadGridCompanyProfileAffiliations") = Nothing
                    Session("ProductEdit_RadGridCompetitors") = Nothing

                Case ActionType.ResetCRMCentralSessionVariables

                    Webvantage.Desktop_CRMCentral.ResetSessionVariables()

                Case ActionType.ResetCalendarSessionVariables

                    Webvantage.Calendar_MonthView.ResetSessionVariables()

                Case ActionType.CalendarSync

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        If IsNumeric(Me._QueryString.GetValue("1")) = True Then

                            ''AddOnPreRenderCompleteAsync(New BeginEventHandler(AddressOf BeginAsyncCalendarSync), New EndEventHandler(AddressOf EndAsyncCalendarSync))
                            ''Me.CreateAsyncWebRequest()

                            Dim CalendarSyncSessionObject As CalendarSyncSessionObject = Nothing

                            If Me._QueryString.GetValue("3") = "true" Then

                                Try

                                    'EmployeeNonTask = Session("EmployeeNonTask_CalendarObject")
                                    If Session("EmployeeNonTask_CalendarObject") IsNot Nothing Then

                                        EmployeeNonTaskID = CType(Session("EmployeeNonTask_CalendarObject"), Integer)

                                    End If

                                    EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID)

                                Catch ex As Exception
                                    EmployeeNonTask = Nothing
                                End Try

                                If EmployeeNonTask IsNot Nothing Then

                                    CalendarSyncSessionObject = New CalendarSyncSessionObject(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Me._Session, EmployeeNonTask, (Me._QueryString.GetValue("2") = "true"), (Me._QueryString.GetValue("3") = "true"))

                                Else

                                    CalendarSyncSessionObject = New CalendarSyncSessionObject(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Me._Session, Me._QueryString.GetValue("1"), (Me._QueryString.GetValue("2") = "true"), (Me._QueryString.GetValue("3") = "true"))

                                End If

                            Else

                                CalendarSyncSessionObject = New CalendarSyncSessionObject(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Me._Session, Me._QueryString.GetValue("1"), (Me._QueryString.GetValue("2") = "true"), (Me._QueryString.GetValue("3") = "true"))

                            End If

                            CalendarSyncSessionObject.SessionID = HttpContext.Current.Session.SessionID.ToString()
                            CalendarSyncSessionObject.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                            CalendarSyncSessionObject.Sync()

                        End If

                    End Using

                Case ActionType.Email

                    If Me._Val1 <> "" Then

                        'AddOnPreRenderCompleteAsync(New BeginEventHandler(AddressOf BeginAsyncEmail), New EndEventHandler(AddressOf EndAsyncEmail))
                        'Me.CreateAsyncWebRequest()

                        Dim eso As EmailSessionObject = Nothing
                        eso = EmailSessionObject.FromSession(Me._Val1)

                        If eso IsNot Nothing Then

                            eso.SessionID = HttpContext.Current.Session.SessionID.ToString()
                            eso.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                            eso.Send()

                            Me.CheckForAsyncMessage()

                        End If

                    End If

                Case ActionType.CheckForAsyncMessage

                    'Dim AsyncError As New AsyncErrorMessage()

                    'AsyncError.SessionID = HttpContext.Current.Session("UserCode")
                    'AsyncError.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath

                    'If AsyncError.HasError = True Then

                    '    Me.ShowMessage(AsyncError.GetMessage())

                    'End If

                Case ActionType.OpenTimesheetToToday

                    Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                    Dim c As New cTimeSheet(Session("ConnString"))
                    Dim OffsetDate As Date = cEmployee.TimeZoneToday

                    TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                    Select Case TsSettings.StartTimesheetOnDayOfWeek
                        Case DayOfWeek.Saturday
                            OffsetDate = cEmployee.TimeZoneToday.AddDays(1)
                        Case DayOfWeek.Sunday
                            OffsetDate = cEmployee.TimeZoneToday
                        Case DayOfWeek.Monday
                            OffsetDate = cEmployee.TimeZoneToday.AddDays(-1)
                    End Select

                    Session("TimesheetStartDate") = OffsetDate.ToShortDateString()
                    Session("TimesheetMain_SingleViewDayOfWeek") = CType(OffsetDate.DayOfWeek, Integer)
                    Session("TimesheetCommentView_SingleViewDayOfWeek") = CType(OffsetDate.DayOfWeek, Integer)
                    Session("TimesheetMain_UserHasMadeASelection") = CType(OffsetDate.DayOfWeek, Integer)

                    Dim URL As String = "Timesheet.aspx?FromWindow=uix&tsdate=" & OffsetDate.ToShortDateString()
                    Me.OpenWindow("", URL)

                Case ActionType.OpenTimesheetToThisWeek

                    Dim URL As String = "Timesheet.aspx?FromWindow=CurrentDTObject&tsdate=" & cEmployee.TimeZoneToday.ToShortDateString()

                    Session("TimesheetStartDate") = cEmployee.TimeZoneToday.ToShortDateString()
                    Session("TimesheetMain_SingleViewDayOfWeek") = Nothing
                    Session("TimesheetCommentView_SingleViewDayOfWeek") = Nothing

                    Try

                        Dim Show As Integer = 7
                        Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
                        Dim c As New cTimeSheet(Session("ConnString"))

                        TsSettings = c.GetSessionTimesheetSettings(Session("UserCode"))

                        Show = CType(TsSettings.DaysToDisplay, Integer)

                        If Show = 7 Then

                            Session("TimesheetMain_UserHasMadeASelection") = "all7"

                        Else

                            Session("TimesheetMain_UserHasMadeASelection") = "all5"

                        End If

                    Catch ex As Exception

                        Session("TimesheetMain_UserHasMadeASelection") = "all5"

                    End Try

                    Me.OpenWindow("", URL)

                Case ActionType.ResetExpense_SelectItemsVariables

                    Webvantage.Expense_SelectItems.ResetSessionVariables()

                Case ActionType.NewAppNotificationRead

                    AdvantageFramework.Security.ClearNewAdvantageApplicationsAlertSetting(_Session)

                Case ActionType.RenewSession

                    If Session("ConnString") IsNot Nothing Then

                        Session("ConnString") = Session("ConnString")

                    Else

                        Me.BackToSignInPage()

                    End If

                Case ActionType.CheckSession

                    If Session("ConnString") Is Nothing Then

                        Me.BackToSignInPage()

                    End If

                Case ActionType.ReviewGenerateFeedbackSummary

                    'If Me._ConceptShareReviewID > 0 Then

                    '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    '        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    '            Dim PdfBytes As Byte()

                    '            'PdfBytes = AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(DataContext, Me._ConceptShareReviewID)

                    '        End Using
                    '    End Using


                    'End If
                    Dim ConceptShareProjectID As Integer = 0
                    Dim ConceptShareReviewID As Integer = 0

                    Try

                        If IsNumeric(Me._Val1) Then

                            ConceptShareProjectID = CType(Me._Val1, Integer)

                        End If

                    Catch ex As Exception
                        ConceptShareProjectID = 0
                    End Try
                    Try

                        If IsNumeric(Me._QueryString.GetValue("reviewId")) Then

                            ConceptShareReviewID = CType(Me._QueryString.GetValue("reviewId"), Integer)

                        End If

                    Catch ex As Exception
                        ConceptShareReviewID = 0
                    End Try

                    If ConceptShareProjectID > 0 AndAlso ConceptShareReviewID > 0 Then

                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        If Me.IsClientPortal = False Then

                            ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                        Else

                            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                        End If

                        If ConceptShareConnection IsNot Nothing Then

                            Dim Identifier As String = ""
                            Dim Filename As String = ""
                            Dim PdfBytes As Byte()

                            PdfBytes = AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(ConceptShareConnection, ConceptShareProjectID, ConceptShareReviewID)

                            If PdfBytes IsNot Nothing Then

                                'Dim FilePrefix As String = Request.PhysicalApplicationPath.Trim() & "TEMP\"
                                'Dim Filename As String = String.Format("{0}FeedbackSummary{1}.pdf", FilePrefix, AdvantageFramework.StringUtilities.GUID_Date())
                                'Dim SummaryFileStream As New FileStream(Filename, FileMode.OpenOrCreate, FileAccess.Write)

                                'SummaryFileStream.Write(PdfBytes, 0, PdfBytes.Length)
                                'SummaryFileStream.Close()
                                'SummaryFileStream.Dispose()

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    Dim Alert As AdvantageFramework.Database.Entities.Alert

                                    Alert = Nothing
                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByConceptShareReviewID(DbContext, ConceptShareReviewID)

                                    If Alert IsNot Nothing Then

                                        Identifier = Alert.Subject

                                    End If

                                End Using

                                Filename = String.Format("Feedback_Summary_{0}_{1}.pdf", MiscFN.JavascriptSafe(Identifier.Replace(" ", "_")), AdvantageFramework.StringUtilities.GUID_Date())

                                With HttpContext.Current.Response

                                    Try

                                        .Buffer = True
                                        .AddHeader("Content-Disposition", "attachment;filename=""" & Filename & """")
                                        .AddHeader("Content-Length", PdfBytes.Length)
                                        .ContentType = "application/pdf"
                                        .BinaryWrite(PdfBytes)
                                        .End()
                                        .Flush()
                                        .Clear()

                                    Catch ex As Exception
                                        .End()
                                        .Clear()
                                    End Try

                                End With

                            End If

                        End If

                    End If

                Case ActionType.ResetProjectScheduleFindAndReplaceSessionVariables

                    Session("PS_FIND_REPLACE_COMPONENTS") = Nothing

            End Select

        Catch ex As Exception

            If ShowMessage = True Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End If

        End Try

    End Sub

#End Region

#Region " Methods "

    Private Sub SaveWorkspaceObjectSizeAndPosition()
        Try
            Dim DesktopObjectId As Integer = 0
            Dim DesktopObjectTop As Integer = 0
            Dim DesktopObjectLeft As Integer = 0
            Dim DesktopObjectHeight As Integer = 0
            Dim DesktopObjectWidth As Integer = 0
            Dim URL As String = Me._Val1.Trim()

            Try
                DesktopObjectId = Request.QueryString("id")
            Catch ex As Exception
                DesktopObjectId = 0
            End Try
            Try
                DesktopObjectTop = Request.QueryString("t")
            Catch ex As Exception
                DesktopObjectTop = 0
            End Try
            Try
                DesktopObjectLeft = Request.QueryString("l")
            Catch ex As Exception
                DesktopObjectLeft = 0
            End Try
            Try
                DesktopObjectHeight = Request.QueryString("h")
            Catch ex As Exception
                DesktopObjectHeight = 0
            End Try
            Try
                DesktopObjectWidth = Request.QueryString("w")
            Catch ex As Exception
                DesktopObjectWidth = 0
            End Try

            If DesktopObjectId > 0 Then

                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE WV_WORKSPACE_OBJECT WITH(ROWLOCK) SET ")

                    .Append("[HEIGHT] = ")
                    .Append(DesktopObjectHeight.ToString())
                    .Append(", ")
                    .Append("[WIDTH] = ")
                    .Append(DesktopObjectWidth.ToString())
                    .Append(", ")
                    .Append("[TOP_COORD] = ")
                    .Append(DesktopObjectTop.ToString())
                    .Append(", ")
                    .Append("[LEFT_COORD] = ")
                    .Append(DesktopObjectLeft.ToString())

                    .Append(" WHERE ID = ")
                    .Append(DesktopObjectId.ToString())
                    .Append(";")
                End With

                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
                SQL = Nothing

            End If
        Catch ex As Exception
            'don't care
        End Try
    End Sub
    Private Sub SaveWorkspaceObjectSizeAndPositionCP()
        Try
            Dim DesktopObjectId As Integer = 0
            Dim DesktopObjectTop As Integer = 0
            Dim DesktopObjectLeft As Integer = 0
            Dim DesktopObjectHeight As Integer = 0
            Dim DesktopObjectWidth As Integer = 0
            Dim URL As String = Me._Val1.Trim()

            Try
                DesktopObjectId = Request.QueryString("id")
            Catch ex As Exception
                DesktopObjectId = 0
            End Try
            Try
                DesktopObjectTop = Request.QueryString("t")
            Catch ex As Exception
                DesktopObjectTop = 0
            End Try
            Try
                DesktopObjectLeft = Request.QueryString("l")
            Catch ex As Exception
                DesktopObjectLeft = 0
            End Try
            Try
                DesktopObjectHeight = Request.QueryString("h")
            Catch ex As Exception
                DesktopObjectHeight = 0
            End Try
            Try
                DesktopObjectWidth = Request.QueryString("w")
            Catch ex As Exception
                DesktopObjectWidth = 0
            End Try

            If DesktopObjectId > 0 Then

                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE CP_WORKSPACE_OBJECT WITH(ROWLOCK) SET ")

                    .Append("[HEIGHT] = ")
                    .Append(DesktopObjectHeight.ToString())
                    .Append(", ")
                    .Append("[WIDTH] = ")
                    .Append(DesktopObjectWidth.ToString())
                    .Append(", ")
                    .Append("[TOP_COORD] = ")
                    .Append(DesktopObjectTop.ToString())
                    .Append(", ")
                    .Append("[LEFT_COORD] = ")
                    .Append(DesktopObjectLeft.ToString())

                    .Append(" WHERE ID = ")
                    .Append(DesktopObjectId.ToString())
                    .Append(";")
                End With

                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
                SQL = Nothing

            End If
        Catch ex As Exception
            'don't care
        End Try
    End Sub

    Private Sub SaveUserFavoriteSizeAndPosition()
        Try
            Dim UserFavoriteModuleId As Integer = 0
            Dim UserFavoriteTop As Integer = 0
            Dim UserFavoriteLeft As Integer = 0
            Dim UserFavoriteHeight As Integer = 0
            Dim UserFavoriteWidth As Integer = 0
            Dim URL As String = Me._Val1.Trim()

            Try
                UserFavoriteModuleId = Request.QueryString("id")
            Catch ex As Exception
                UserFavoriteModuleId = 0
            End Try
            Try
                UserFavoriteTop = Request.QueryString("t")
            Catch ex As Exception
                UserFavoriteTop = 0
            End Try
            Try
                UserFavoriteLeft = Request.QueryString("l")
            Catch ex As Exception
                UserFavoriteLeft = 0
            End Try
            Try
                UserFavoriteHeight = Request.QueryString("h")
            Catch ex As Exception
                UserFavoriteHeight = 0
            End Try
            Try
                UserFavoriteWidth = Request.QueryString("w")
            Catch ex As Exception
                UserFavoriteWidth = 0
            End Try

            If UserFavoriteModuleId > 0 Then

                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("UPDATE WV_USER_QUICK_LAUNCH_APPS WITH(ROWLOCK) SET ")

                    .Append("[HEIGHT] = ")
                    .Append(UserFavoriteHeight.ToString())
                    .Append(", ")
                    .Append("[WIDTH] = ")
                    .Append(UserFavoriteWidth.ToString())
                    .Append(", ")
                    .Append("[TOP_COORD] = ")
                    .Append(UserFavoriteTop.ToString())
                    .Append(", ")
                    .Append("[LEFT_COORD] = ")
                    .Append(UserFavoriteLeft.ToString())

                    .Append(" WHERE USERID = '")
                    .Append(Session("UserCode").ToString())
                    .Append("' AND TABNO = ")
                    .Append(Me._WorkspaceID.ToString())
                    .Append(" AND APPID = ")
                    .Append(UserFavoriteModuleId.ToString())
                    .Append(";")
                End With
                SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, SQL.ToString())
                SQL = Nothing

            End If
        Catch ex As Exception
            'don't care
        End Try
    End Sub

    Private Function DocExists() As Boolean

        Dim rtn As Boolean = False

        If Me._DocumentID > 0 Then

            Dim d As New Document(Session("ConnString"))
            If d.LoadByPrimaryKey(Me._DocumentID) = True Then

                rtn = True

            End If

        End If

        Return rtn

    End Function

    Private Function GetReviewFeedbackSummary() As Boolean

    End Function

#End Region

#Region " Async Methods "

    '' ASP.Net 2.0 - 4.0 Method
    'Private Sub CreateAsyncWebRequest()

    '    Me._AsyncWebRequest = WebRequest.Create(HttpContext.Current.Request.Url.Scheme & "://" & HttpContext.Current.Request.Url.Host & "/" & HttpContext.Current.Request.ApplicationPath)

    'End Sub

    'Private Function BeginAsyncEmail(ByVal sender As Object, ByVal e As EventArgs, ByVal cb As AsyncCallback, ByVal state As Object) As IAsyncResult

    '    Dim eso As EmailSessionObject = Nothing
    '    eso = EmailSessionObject.FromSession(Me._Val1)

    '    If eso IsNot Nothing Then

    '        eso.Send()
    '        state = eso.ErrorMessage

    '    End If

    '    Return Me._AsyncWebRequest.BeginGetResponse(cb, state)

    'End Function
    'Private Sub EndAsyncEmail(ar As IAsyncResult)

    '    'Destroy async request created in the BeginAsync
    '    Dim response As WebResponse = Me._AsyncWebRequest.EndGetResponse(ar)
    '    response.Close()

    '    'Return message from async call
    '    If Not ar.AsyncState Is Nothing Then

    '        If ar.AsyncState.ToString() <> "" Then

    '            Me.ShowMessage("Error sending email:\n" & ar.AsyncState.ToString())

    '        End If

    '    End If

    'End Sub

    'Private Function BeginAsyncCalendarSync(ByVal sender As Object, ByVal e As EventArgs, ByVal cb As AsyncCallback, ByVal state As Object) As IAsyncResult

    '    Dim CalendarSyncSessionObject As CalendarSyncSessionObject = Nothing

    '    CalendarSyncSessionObject = New CalendarSyncSessionObject(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString(), Me._Session, Me._QueryString.GetValue("1"), (Me._QueryString.GetValue("2") = "true"), (Me._QueryString.GetValue("3") = "true"))

    '    CalendarSyncSessionObject.Sync()

    '    Return Me._AsyncWebRequest.BeginGetResponse(cb, state)

    'End Function
    'Private Sub EndAsyncCalendarSync(ar As IAsyncResult)

    '    'Destroy async request created in the BeginAsync
    '    Dim response As WebResponse = Me._AsyncWebRequest.EndGetResponse(ar)
    '    response.Close()

    '    'nothing to return from async call

    'End Sub

#End Region

End Class
