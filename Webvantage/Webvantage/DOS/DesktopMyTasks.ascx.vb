Imports System.Data.SqlClient
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Public Class DesktopMyTasks
    Inherits Webvantage.BaseDesktopObject

    Public strTaskStatus As String
    Public strShow As String = ""

    Private ReadOnly Property FullyCompleteTask As AdvantageFramework.ProjectSchedule.LookupSettingsOptions
        Get
            If ViewState("FullyCompleteTask") Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ViewState("FullyCompleteTask") = CType(AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempCompleteSetting(DbContext), Integer)

                End Using

            End If

            Return CType(CType(ViewState("FullyCompleteTask"), Integer), AdvantageFramework.ProjectSchedule.LookupSettingsOptions)

        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.butPrint.Attributes.Add("onclick", "window.open('dtp_tasks.aspx?taskStatus=<%=(strTaskStatus)%>&show=<%=(strShow)%>', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1100,height=800,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            Me.butExport.Attributes.Add("onclick", "window.open('dtp_tasks.aspx?taskStatus=" & Me.ddType.SelectedValue & "&show=" & Me.ddTaskShow.SelectedValue & "&export=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
            If Not Page.IsPostBack Then
                Dim otask As cTasks = New cTasks(Session("ConnString"))
                Dim taskVar As String

                taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "ddType")
                If taskVar <> "" Then
                    Me.ddType.SelectedValue = taskVar
                Else
                    Me.ddType.SelectedValue = "All"
                End If

                taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "ddTaskShow")
                If taskVar <> "" Then
                    Me.ddTaskShow.SelectedValue = taskVar
                Else
                    Me.ddTaskShow.SelectedValue = "All"
                End If

                taskVar = otask.getAppVars(Session("UserCode"), "MyTasks", "sSearch")
                If taskVar <> "" Then
                    Me.txtSearch.Text = taskVar
                    Me.TextBoxSearchHeader.Text = taskVar
                Else
                    Me.txtSearch.Text = ""
                    Me.TextBoxSearchHeader.Text = ""
                End If

                LoadTasks()
                Session("TasksDOSortOrder") = ""
                Session("TasksDOSortExp") = ""
            Else

                Select Case Me.EventTarget
                    Case "RebindGrid", "UpdatePanelRadDock"
                        Me.TaskRadGrid.Rebind()

                End Select

            End If
            strTaskStatus = Me.ddType.SelectedValue
            strShow = Me.ddTaskShow.SelectedValue

        Catch ex As Exception

        End Try

        Me.MyUnityContextMenu.SetRadGrid(Me.TaskRadGrid)

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(TaskRadGrid)
        If Me.IsClientPortal = True Then
            AddHandler TaskRadGrid.HeaderContextMenu.ItemCreated, AddressOf HeaderContextMenuItemCreated
            Me.ImageButtonBookmark.Visible = False
        End If

        Try
            Dim head As GridHeaderItem
            Try
                If Not Me.TaskRadGrid.MasterTableView.GetItems(GridItemType.Header) Is Nothing Then
                    head = TryCast(Me.TaskRadGrid.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
                End If
            Catch ex As Exception
                head = Nothing
            End Try
            Me.HideIconHeaderLabels(head)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddType", "", Me.ddType.SelectedValue) 'status
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddTaskShow", "", Me.ddTaskShow.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyTasks", "sSearch", "", Me.txtSearch.Text)
        LoadTasks()
    End Sub
    Private Sub imgbtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSearch.Click
        Me.Search(Me.txtSearch.Text)
    End Sub
    Private Sub Search(ByVal Search As String)

        Search = Search.Trim()

        Me.TextBoxSearchHeader.Text = Search
        Me.txtSearch.Text = Search
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "sSearch", "", Search)
        Me.TaskRadGrid.MasterTableView.CurrentPageIndex = 0

        LoadTasks()

    End Sub

    Private Function MarkTempComplete(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                      ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByRef GridRow As GridDataItem) As Boolean

        Dim MarkedComplete As Boolean = False
        Dim MarkedTempComplete As Boolean = False
        Dim AutoAlertTaskEmployees As Boolean = False
        Dim DatatableTaskSeqNbrThatWereMadeActive As New DataTable
        Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)
        Dim job As Integer = CInt(GridRow.GetDataKeyValue("JobNo"))
        Dim jobcomp As Integer = CInt(GridRow.GetDataKeyValue("JobComp"))
        Dim seqno As Integer = CInt(GridRow.GetDataKeyValue("SeqNo"))

        MarkedTempComplete = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, job, jobcomp, seqno, Session("EmpCode"), CType(Now, DateTime), MarkedComplete)
        AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

        If AutoAlertTaskEmployees = True Then

            If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                Dim ThisSeqNbr As Integer = 0
                Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                Dim EmpCodeString As String = ""
                Dim NewAlertId As Integer = 0

                For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                    ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)
                    NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, job, jobcomp, ThisSeqNbr, HttpContext.Current.Session("EmpCode"), EmpCodeString)

                    If NewAlertId > 0 Then

                        Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                                                                      HttpContext.Current.Session("UserCode"),
                                                                                      _Session,
                                                                                      HttpContext.Current.Session("WebvantageURL"),
                                                                                      HttpContext.Current.Session("ClientPortalURL"))
                        With eso

                            .AlertId = NewAlertId
                            .Subject = "[Alert Updated]"
                            .EmployeeCodesToSendEmailTo = EmpCodeString
                            .IsClientPortal = MiscFN.IsClientPortal
                            .IncludeOriginator = False

                        End With

                        eso.SendEmailOnSeparateThread()

                    End If

                    EmpCodeString = ""
                    NewAlertId = 0

                Next

            End If

        End If

        Return MarkedTempComplete

    End Function

    Private Sub TaskRadGrid_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles TaskRadGrid.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim ar() As String
            Dim commandParm As String

            Select Case e.CommandName
                Case "MarkComplete"

                    Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)
                    Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
                    Dim IsEventTask As Boolean = False
                    Dim job As Integer = CInt(GridRow.GetDataKeyValue("JobNo"))
                    Dim jobcomp As Integer = CInt(GridRow.GetDataKeyValue("JobComp"))
                    Dim seqno As Integer = CInt(GridRow.GetDataKeyValue("SeqNo"))
                    Dim Marked As Boolean = False

                    Try

                        If GridRow.GetDataKeyValue("IS_EVENT") = "1" Then

                            IsEventTask = True

                        End If

                    Catch ex As Exception
                        IsEventTask = False
                    End Try

                    If IsEventTask = False Then

                        Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Select Case e.CommandArgument
                                    Case "Mark"

                                        If Me.MarkTempComplete(DbContext, SecurityDbContext, GridRow) = True Then

                                            Me.TaskRadGrid.Rebind()
                                            Me.RefreshTasks()

                                        End If

                                    Case "MarkNoPrompt"

                                        If Me.MarkTempComplete(DbContext, SecurityDbContext, GridRow) = True Then

                                            If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, job, jobcomp, seqno, HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then

                                            End If

                                            Me.TaskRadGrid.Rebind()
                                            Me.RefreshTasks()


                                        End If

                                    Case "MarkWithPrompt"

                                        If Me.MarkTempComplete(DbContext, SecurityDbContext, GridRow) = True Then

                                            If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, job, jobcomp, seqno, HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then

                                            End If

                                            Me.ShowMessage("Task will be completed if you were the last employee to temp complete")

                                            Me.TaskRadGrid.Rebind()
                                            Me.RefreshTasks()

                                        End If

                                    Case "Unmark"

                                        AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, job, jobcomp, seqno, Session("EmpCode"), Nothing)
                                        Me.TaskRadGrid.Rebind()
                                        Me.RefreshTasks()

                                End Select

                            End Using

                        End Using

                    Else
                        Dim EventTaskId As Integer = 0
                        Try
                            EventTaskId = CInt(GridRow.GetDataKeyValue("EVENT_TASK_ID")) 'GCInt(GridRow("column13").Text)
                        Catch ex As Exception
                            EventTaskId = 0
                        End Try
                        If EventTaskId > 0 Then

                            Dim SQL As String = "UPDATE EVENT_TASK WITH(ROWLOCK) SET TEMP_COMP_DATE = @TempCompDate WHERE EVENT_TASK_ID = @EventTaskId"
                            Try
                                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                                    MyConn.Open()
                                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                                    Dim MyCmd As New SqlCommand(SQL, MyConn, MyTrans)
                                    With MyCmd
                                        If e.CommandArgument = "Mark" Then
                                            .Parameters.AddWithValue("@TempCompDate", Today.Date)
                                        ElseIf e.CommandArgument = "Mark Not" Then
                                            .Parameters.AddWithValue("@TempCompDate", DBNull.Value)
                                        End If
                                        .Parameters.AddWithValue("@EventTaskId", EventTaskId)
                                    End With
                                    Try
                                        MyCmd.ExecuteNonQuery()
                                        MyTrans.Commit()
                                    Catch ex As Exception
                                        MyTrans.Rollback()
                                        'Me.LblMSG.Text = "Transaction error:  " & ex.Message.ToString()
                                    Finally
                                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                                    End Try
                                End Using

                            Catch ex As Exception
                                'Me.LblMSG.Text = "Save error:  " & ex.Message.ToString()
                            End Try

                            Me.TaskRadGrid.Rebind()

                        End If

                    End If

                Case "StartStopwatch"

                    Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)
                    Dim job As Integer = CInt(GridRow.GetDataKeyValue("JobNo")) 'GridRow("column9").Text)
                    Dim jobcomp As Integer = CInt(GridRow.GetDataKeyValue("JobComp")) 'GridRow("column10").Text)
                    Dim seqno As Integer = CInt(GridRow.GetDataKeyValue("SeqNo")) 'GridRow("column11").Text)
                    Dim AlertID As Integer = CInt(GridRow.GetDataKeyValue("ALERT_ID")) 'GridRow("column10").Text)
                    Dim s As String = ""

                    If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), job, jobcomp, seqno, AlertID, s) = True Then

                        'Me.OpenTimesheetStopwatchNotificationWindow()
                        Me.OpenWindow("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 475, 500)

                    Else

                        Me.ShowMessage(s)

                    End If

                    Me.TaskRadGrid.Rebind()

                Case "Documents"

                    Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)
                    Dim job As Integer = CInt(GridRow.GetDataKeyValue("JobNo")) 'GridRow("column9").Text)
                    Dim jobcomp As Integer = CInt(GridRow.GetDataKeyValue("JobComp")) 'GridRow("column10").Text)
                    Dim seqno As Integer = CInt(GridRow.GetDataKeyValue("SeqNo")) 'GridRow("column11").Text)
                    Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
                    Dim Description As String = Nothing

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Documents_List2.aspx"
                        .JobNumber = job
                        .JobComponentNumber = jobcomp
                        .TaskSequenceNumber = seqno
                        .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Task
                        .Add("doc_img", e.Item.FindControl("ImageButtonDocuments").ClientID)
                        .Add("opener", HiddenFieldWindowName.Value)

                    End With

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        With AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, job, jobcomp, seqno)

                            Description = .TaskCode & If(String.IsNullOrWhiteSpace(.Description), "", " - " & .Description)

                        End With

                    End Using

                    QueryString.Add("task_desc", Description)

                    Me.OpenWindow("Document List", QueryString.ToString(True))

            End Select
        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Sub
    Private Sub TaskRadGrid_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles TaskRadGrid.ItemDataBound
        If e.Item.ItemType = GridItemType.Header Then
            Dim Header As GridHeaderItem = TryCast(e.Item, GridHeaderItem)
            Me.HideIconHeaderLabels(Header)
        End If
        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim GridRow As GridDataItem = TryCast(e.Item, GridDataItem)

                Dim FlagImage As Web.UI.WebControls.Image = e.Item.FindControl("ImageFlag")
                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")

                If Not e.Item.DataItem("DueDate") Is System.DBNull.Value Then

                    AdvantageFramework.Web.Presentation.Controls.SetDue(e.Item.DataItem("DueDate"), "column78", GridRow)

                Else

                    AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

                End If

                Dim cdp() As String = e.Item.DataItem("CDP").ToString.Split("/")
                Dim ViewImage As WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")
                Dim TimeImage As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("butAddTime")
                Dim StopWatchImage As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonStopwatch")
                Dim IsEventTask As Boolean = False
                Try
                    If e.Item.DataItem("IS_EVENT") = "1" Then
                        IsEventTask = True
                    End If
                Catch ex As Exception
                End Try
                Try
                    Dim ThisRow_DataKey As String = "DTO|0|2|3|4|" & e.Item.DataItem("JobNo") & "|" & e.Item.DataItem("JobComp") & "|" & e.Item.DataItem("SeqNo") & "|8|" & e.Item.DataItem("EmpCode") & "|" & cdp(0).Trim & "|" & cdp(1).Trim & "|" & cdp(2).Trim & "|" & e.Item.DataItem("Task")
                    If IsEventTask = False Then

                        Dim URL As String = String.Empty
                        Dim AlertID As Integer = 0
                        Dim SprintID As Integer = 0
                        Dim QsAddTime As New AdvantageFramework.Web.QueryString


                        Try
                            If e.Item.DataItem("ALERT_ID") > 0 AndAlso e.Item.DataItem("IS_BOARD_TASK") = True Then
                                AlertID = e.Item.DataItem("ALERT_ID")
                            End If
                        Catch ex As Exception
                            AlertID = 0
                        End Try
                        Try
                            If IsDBNull(e.Item.DataItem("SPRINT_ID")) = False Then
                                SprintID = e.Item.DataItem("SPRINT_ID")
                            End If
                        Catch ex As Exception
                            SprintID = 0
                        End Try

                        If AlertID > 0 Then

                            Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                            QsViewDetails.Page = "Desktop_AlertView"
                            QsViewDetails.Add("AlertID", AlertID)
                            QsViewDetails.Add("SprintID", SprintID)

                            ViewImage.Attributes.Add("onclick", Me.HookUpOpenWindow(e.Item.DataItem("Task"), QsViewDetails.ToString(True)))

                        Else

                            ViewImage.Attributes.Add("onclick", Me.HookUpOpenDetailWindow(ThisRow_DataKey))

                        End If

                        QsAddTime.Page = "Employee/Timesheet/Entry"
                        QsAddTime.JobNumber = e.Item.DataItem("JobNo").ToString()
                        QsAddTime.JobComponentNumber = e.Item.DataItem("JobComp").ToString()
                        QsAddTime.TaskSequenceNumber = e.Item.DataItem("SeqNo").ToString()
                        QsAddTime.EmployeeCode = Session("EmpCode")
                        QsAddTime.AlertID = AlertID

                        URL = QsAddTime.ToString(True)

                        TimeImage.Attributes.Add("onclick", Me.HookUpOpenWindow("Add Time", URL, 600, 600))

                    Else
                        If IsNumeric(e.Item.DataItem("EVENT_TASK_ID")) = True Then

                            ViewImage.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Event_Task_Detail.aspx?etid=" & e.Item.DataItem("EVENT_TASK_ID").ToString()))

                            Dim qs As New AdvantageFramework.Web.QueryString()
                            With qs

                                .Page = "Timesheet_CommentsView.aspx"
                                .Add("Type", "New")
                                .Add("caller", "AlertView")
                                .Add("single", "1")
                                .JobNumber = e.Item.DataItem("JobNo")
                                .JobComponentNumber = e.Item.DataItem("JobComp")

                            End With

                            TimeImage.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))

                        End If
                    End If
                Catch ex As Exception
                End Try

                Dim MarkCompleteImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonMarkComplete")
                Dim MarkCompleteDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivMarkComplete")

                If MarkCompleteDiv IsNot Nothing AndAlso MarkCompleteImageButton IsNot Nothing Then
                    If Not e.Item.DataItem("TempCompleteDate") Is System.DBNull.Value Then

                        e.Item.Font.Strikeout = True

                        Dim i As Int16 = 0
                        For i = 0 To e.Item.Cells.Count - 1

                            e.Item.Cells(i).Font.Strikeout = True

                        Next
                        MarkCompleteImageButton.ImageUrl = "~/Images/Icons/White/256/delete.png"
                        MarkCompleteImageButton.ToolTip = "Mark not completed"
                        MarkCompleteImageButton.CommandArgument = "Unmark"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(MarkCompleteDiv, "standard-red")
                        MarkCompleteDiv.Attributes.Add("title", "Mark not completed")

                    Else

                        Select Case Me.FullyCompleteTask
                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes

                                MarkCompleteImageButton.CommandArgument = "MarkNoPrompt"

                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt

                                'MarkCompleteImageButton.OnClientClick = "return confirm('Complete task?');"
                                MarkCompleteImageButton.CommandArgument = "MarkWithPrompt"

                            Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No

                                'old path
                                MarkCompleteImageButton.CommandArgument = "Mark"

                        End Select

                    End If

                End If

                Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.FindControl("ViewLinkButton")

                ViewLinkButton.ToolTip = e.Item.DataItem("JobData")
                ViewLinkButton.Text = e.Item.DataItem("JobData")
                ViewLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Content.aspx?From=DO&PageMode=Edit&JobNum=" & e.Item.DataItem("JobNo") & "&JobCompNum=" & e.Item.DataItem("JobComp") & "&NewComp=0"))

                Try
                    If IsDate(e.Item.DataItem("StartDate")) = True Then
                        GridRow("column77").Text = LoGlo.FormatDate(CType(e.Item.DataItem("StartDate"), Date))
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsDate(e.Item.DataItem("DueDate")) = True Then
                        GridRow("column78").Text = LoGlo.FormatDate(CType(e.Item.DataItem("DueDate"), Date))
                    End If
                Catch ex As Exception
                End Try

                Dim PriorityColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivPriorityColor")
                Dim PriorityImage As Web.UI.WebControls.Image = e.Item.FindControl("ImagePriority")

                PriorityImage.ToolTip = ""

                If IsEventTask = True Then

                    PriorityImage.ToolTip = "Event Task"
                    AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "calendar-event")

                End If

                Select Case e.Item.DataItem("TASK_STATUS").ToString().Trim().ToUpper()
                    Case "H"
                        'PriorityImage.ImageUrl = "~/Images/priority_high.png"
                        PriorityImage.ToolTip = "High Priority"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
                    Case "L"
                        'PriorityImage.ImageUrl = "~/Images/priority_low.png"
                        PriorityImage.ToolTip = "Low Priority"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
                    Case "A"
                        Select Case e.Item.DataItem("PRIORITY")
                            Case 1
                                PriorityImage.ToolTip = "Active (Highest Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-highest")
                            Case 2
                                PriorityImage.ToolTip = "Active (High Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
                            Case 3
                                PriorityImage.ToolTip = "Active (Normal)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-normal")
                            Case 4
                                PriorityImage.ToolTip = "Active (Low Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
                            Case 5
                                PriorityImage.ToolTip = "Active (Lowest Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-lowest")
                        End Select
                    Case "P"
                        Select Case e.Item.DataItem("PRIORITY")
                            Case 1
                                PriorityImage.ToolTip = "Projected (Highest Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-highest")
                            Case 2
                                PriorityImage.ToolTip = "Projected (High Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
                            Case 3
                                PriorityImage.ToolTip = "Projected (Normal)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-normal")
                            Case 4
                                PriorityImage.ToolTip = "Projected (Low Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
                            Case 5
                                PriorityImage.ToolTip = "Projected (Lowest Priority)"
                                'PriorityImage.ImageUrl = "~/Images/lightbulb_on.png"
                                AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-lowest")
                        End Select '
                End Select

                Dim DocumentsImageButton As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("ImageButtonDocuments")
                Dim DocumentsDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDocumentsColor")
                Dim HasDocuments As Boolean = False
                DocumentsImageButton.ToolTip = ""

                If IsEventTask = True Then

                    DocumentsImageButton.Visible = False
                    DocumentsDiv.Visible = False

                Else

                    DocumentsImageButton.Visible = True
                    DocumentsImageButton.CommandName = "Documents"

                    Try

                        If e.Item.DataItem("HAS_DOCUMENTS") = True Then

                            HasDocuments = True

                        End If

                    Catch ex As Exception
                        HasDocuments = False
                    End Try

                    If HasDocuments = True Then

                        DocumentsImageButton.ToolTip = "Task Documents"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DocumentsDiv, "standard-green")

                    Else

                        DocumentsImageButton.ToolTip = "No Task Documents"

                    End If

                End If

                If Me.IsClientPortal = True Then

                    TimeImage.Visible = False
                    MarkCompleteImageButton.Visible = False
                    StopWatchImage.Visible = False

                End If

            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TaskRadGrid_ItemUpdated(sender As Object, e As GridUpdatedEventArgs) Handles TaskRadGrid.ItemUpdated

    End Sub
    Private Sub TaskRadGrid_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles TaskRadGrid.NeedDataSource
        Try
            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim dt As New DataTable
            Dim TaskType As String = ""

            Select Case (Me.ddType.SelectedValue.ToUpper)
                Case "PROJECTED"
                    TaskType = "P"
                Case "ACTIVE"
                    TaskType = "A"
                Case "H"
                    TaskType = "H"
                Case "L"
                    TaskType = "L"
                Case "EVENT_TASKS"
                    TaskType = "E"
                Case "ALL"
                    TaskType = ""
                Case Else
                    TaskType = ""
            End Select

            dt = oDO.GetTasks(CStr(Session("UserCode")), CStr(Session("EmpCode")), Today(), TaskType, Me.ddTaskShow.SelectedValue, Me.txtSearch.Text, Me.IsClientPortal, Session("UserID"), "")

            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then
                        dt.Rows(i)("FNC_COMMENTS") = dt.Rows(i)("FNC_COMMENTS").ToString().Replace(Environment.NewLine, "<br />")
                    End If
                Next
            End If

            Me.TaskRadGrid.DataSource = dt
            Me.TaskRadGrid.PageSize = MiscFN.LoadPageSize(Me.TaskRadGrid.ID)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub TaskRadGrid_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles TaskRadGrid.PageIndexChanged
        LoadTasks()
    End Sub
    Private Sub TaskRadGrid_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles TaskRadGrid.PageSizeChanged
        MiscFN.SavePageSize(Me.TaskRadGrid.ID, e.NewPageSize)
    End Sub
    Private Sub TaskRadGrid_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles TaskRadGrid.PreRender
        Session("TasksDOSortExp") = Me.TaskRadGrid.MasterTableView.SortExpressions.GetSortString
    End Sub
    Private Sub TaskRadGrid_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles TaskRadGrid.SortCommand

        LoadTasks()

    End Sub
    Private Sub TasksRG_RowDrop(sender As Object, e As GridDragDropEventArgs) Handles TaskRadGrid.RowDrop

        Dim s As String = ""
        If e.DraggedItems(0).OwnerGridID = TaskRadGrid.ClientID Then

            If e.DestDataItem IsNot Nothing Then

                Dim NewIndex As Integer = e.DestDataItem.ItemIndex
                Dim CurrentGridRow As GridDataItem = e.DraggedItems(0)
                Dim LastIndex As Integer = CurrentGridRow.ItemIndex


                If NewIndex <> LastIndex Then

                    s = DesktopCardsMyTasks.SortTaskCard(CurrentGridRow.GetDataKeyValue("JobNo"), CurrentGridRow.GetDataKeyValue("JobComp"), CurrentGridRow.GetDataKeyValue("SeqNo"),
                                                    CurrentGridRow.GetDataKeyValue("EVENT_TASK_ID"), NewIndex)

                    If s.Trim() = "" Then

                        TaskRadGrid.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub HeaderContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Try
            If e.Item.Controls.Count > 0 Then
                If e.Item.Text = "Add Time" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Mark Complete" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Start Stopwatch" Then
                    e.Item.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub HideIconHeaderLabels(ByRef header As GridHeaderItem)

        If Not header Is Nothing Then

            Try
                header("TemplateColumn2").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("TemplateColumn3").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("GridTemplateColumnStopwatch").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("TemplateColumn1").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("TemplateColumn4").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("TemplateColumnDocuments").Text = "&nbsp;"
            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub LoadTasks()

        Me.TaskRadGrid.Rebind()

    End Sub
    Public Function SetStyle(ByVal PValue As String) As String
        If PValue = "" Then
            Return "calendarNormal"
        Else
            Return "calendarPending"
        End If
    End Function

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Try

            Me.MyUnityContextMenu.JobNumber = TaskRadGrid.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNo")
            Me.MyUnityContextMenu.JobComponentNumber = TaskRadGrid.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComp")
            Me.MyUnityContextMenu.AlertID = TaskRadGrid.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("ALERT_ID")

        Catch ex As Exception
        End Try

    End Sub

    Private Sub ddType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddType.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddType", "", Me.ddType.SelectedValue) 'status
        LoadTasks()
    End Sub

    Private Sub ddTaskShow_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles ddTaskShow.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "ddTaskShow", "", Me.ddTaskShow.SelectedValue)
        otask.setAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue", "", CheckBoxTodayOnlyWithStartDue.Checked)
        LoadTasks()
    End Sub
    Private Sub CheckBoxTodayOnlyWithStartDue_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTodayOnlyWithStartDue.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "MyTasks", "TodayOnlyStartDue", "", CheckBoxTodayOnlyWithStartDue.Checked)
        LoadTasks()

    End Sub

    Private Sub ImageButtonSearchHeader_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonSearchHeader.Click
        Me.Search(Me.TextBoxSearchHeader.Text)
    End Sub

    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_MyTaskList
                .UserCode = Session("UserCode")
                .Name = "Task List (My)"
                .Description = "Task List (My)"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
