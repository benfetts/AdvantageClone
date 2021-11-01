Imports Telerik.Web.UI

Public Class DesktopTaskList
    Inherits Webvantage.BaseDesktopObject

    Public dDateStart As Date
    Public dDateDue As Date
    Public sDateSelection As String
    Public search As String



    Private Sub DesktopTaskList_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.MyUnityContextMenu.SetRadGrid(Me.TasksRG)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(TasksRG)

        Me.butExport.Attributes.Add("onclick", "window.open('dtp_tasklistPrint.aspx?export=1', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        Me.butPrint.Attributes.Add("onclick", "window.open('dtp_tasklistPrint.aspx', 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=1350,height=800,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")
        If Not Page.IsPostBack Then

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            CheckAppAccessFunction()
            Dim oReports As New cReports(Session("ConnString"))
            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.Label5.Text = str & ":"
            End If

            LoadDropDowns()
            LoadSelections()
            LoadTasks()

        Else

            Select Case Me.EventTarget
                Case "RebindGrid", "UpdatePanelRadDock"
                    Me.TasksRG.Rebind()

            End Select

        End If

    End Sub

    Public Function CheckAppAccessFunction() As Integer
        Try
            Dim oSec As New cSecurity(Session("ConnString"))
            If Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) Then 'AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True) Then
                Me.ImgBtnTempComplete.Visible = True
                Return 0
            Else
                Me.ImgBtnTempComplete.Visible = False
                Return 1
            End If
        Catch ex As Exception
        End Try
    End Function

    Private Sub LoadTasks()

        Me.TasksRG.Rebind()

    End Sub

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddEmployee
            .DataSource = oDD.GetEmployees(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddRole
            .DataSource = oDD.GetRoles()
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddManager
            .DataSource = oDD.GetManagers(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.RadComboBoxAccountExec
            .DataSource = oDD.GetAccountExecs(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With

        With Me.ddOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
        End With


    End Sub

    Private Sub LoadSelections()
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim taskVar As String

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sEmployee")
        If taskVar <> "" Then
            Me.ddEmployee.SelectedValue = taskVar
        Else
            Me.ddEmployee.SelectedValue = CStr(Session("EmpCode"))
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "dDateStart")
        If taskVar <> "" Then
            Me.RadDatePickerStart.SelectedDate = LoGlo.FormatDate(taskVar)
            dDateStart = Me.RadDatePickerStart.SelectedDate
        Else
            SetThisWeek()
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "dDateDue")
        If taskVar <> "" Then
            Me.RadDatePickerDue.SelectedDate = LoGlo.FormatDate(taskVar)
            dDateDue = Me.RadDatePickerDue.SelectedDate
        Else
            SetThisWeek()
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sRole")
        If taskVar <> "" Then
            Me.ddRole.SelectedValue = taskVar
        Else
            Me.ddRole.SelectedValue = "All"
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sManager")
        If taskVar <> "" Then
            Me.ddManager.SelectedValue = taskVar
        Else
            Me.ddManager.SelectedValue = "All"
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sAcctExec")
        If taskVar <> "" Then
            Me.RadComboBoxAccountExec.SelectedValue = taskVar
        Else
            Me.RadComboBoxAccountExec.SelectedValue = "All"
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sOffice")
        If taskVar <> "" Then
            Me.ddOffice.SelectedValue = taskVar
        Else
            Me.ddOffice.SelectedValue = "All"
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "DatePicker")
        If taskVar <> "" Then
            Me.ddDatePicker.SelectedValue = taskVar
        Else
            Me.ddDatePicker.SelectedValue = "1"
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sStatus")
        If taskVar <> "" Then
            Me.ddType.SelectedValue = taskVar
        End If

        taskVar = otask.getAppVars(Session("UserCode"), "TaskList", "sSearch")
        If taskVar <> "" Then
            Me.txtSearch.Text = taskVar
        End If
        Try
            If otask.getAppVars(Session("UserCode"), "TaskList", "OnlyMarkedComplete") <> "" Then
                Me.ChkOnlyMarkedComplete.Checked = CType(otask.getAppVars(Session("UserCode"), "TaskList", "OnlyMarkedComplete"), Boolean)
            End If
            If otask.getAppVars(Session("UserCode"), "TaskList", "ExcludeUnassigned") <> "" Then
                Me.CheckBoxExcludeUnassigned.Checked = CType(otask.getAppVars(Session("UserCode"), "TaskList", "ExcludeUnassigned"), Boolean)
            End If
            If otask.getAppVars(Session("UserCode"), "TaskList", "OnlyUnassigned") <> "" Then
                Me.CheckBoxOnlyUnassigned.Checked = CType(otask.getAppVars(Session("UserCode"), "TaskList", "OnlyUnassigned"), Boolean)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        otask.setAppVars(Session("UserCode"), "TaskList", "sSearch", "", Me.txtSearch.Text)
        LoadTasks()
        'Me.TasksRadGrid.Rebind()
    End Sub

    Private Sub ddDatePicker_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDatePicker.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        sDateSelection = Me.ddDatePicker.SelectedValue
        otask.setAppVars(Session("UserCode"), "TaskList", "DatePicker", "", sDateSelection)

        Select Case sDateSelection
            Case "0" 'Today
                RadDatePickerStart.SelectedDate = Today()
                RadDatePickerDue.SelectedDate = Today()
                dDateStart = Today()
                dDateDue = Today()
                otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(dDateStart))
                otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(dDateDue))

            Case "1" 'This Week (Set to beginning of week first - Sun-Sat)
                SetThisWeek()

            Case "2" 'Two Weeks
                SetThis2Week()
                'If RadDatePickerStart.SelectedDate.HasValue Then
                '    dDateStart = RadDatePickerStart.SelectedDate
                'Else
                '    dDateStart = Today()
                'End If
                'RadDatePickerDue.SelectedDate = dDateStart.AddDays(14)
                'dDateDue = RadDatePickerDue.SelectedDate
                'otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(dDateStart))
                'otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(dDateDue))

            Case "3" 'One Month
                'If RadDatePickerStart.SelectedDate.HasValue Then
                '    dDateStart = RadDatePickerStart.SelectedDate
                'Else
                dDateStart = Today()
                'End If
                RadDatePickerStart.SelectedDate = dDateStart
                RadDatePickerDue.SelectedDate = dDateStart.AddMonths(1)
                dDateDue = RadDatePickerDue.SelectedDate
                otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(dDateStart))
                otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(dDateDue))

        End Select

        LoadTasks()
    End Sub

    Private Sub SetCriteria(ByRef s As DateTime, ByRef e As DateTime)
        If Me.RadDatePickerStart.SelectedDate = Nothing Or Me.RadDatePickerDue.SelectedDate = Nothing Then
            SetThisWeek()
        End If

        Try
            s = CType(Me.RadDatePickerStart.SelectedDate, DateTime)
        Catch ex As Exception
            Dim weekday As Int16
            Dim strt_date As DateTime

            weekday = Date.Today.DayOfWeek
            If weekday > 0 Then
                weekday = 0 - weekday
                strt_date = Date.Today.AddDays(weekday)
            Else
                strt_date = Today()
            End If
            s = strt_date
        End Try

        Try
            e = CType(Me.RadDatePickerDue.SelectedDate, DateTime)
        Catch ex As Exception
            e = s.AddDays(6)
        End Try

    End Sub

    Private Sub RadDatePickerDue_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDue.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        dDateDue = Me.RadDatePickerDue.SelectedDate
        If dDateDue = "#12:00:00 AM#" Then
            dDateDue = Today()
        End If

        otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(dDateDue))

        Me.ddDatePicker.SelectedValue = "4"
        otask.setAppVars(Session("UserCode"), "TaskList", "DatePicker", "", "4")

        LoadTasks()
    End Sub

    Private Sub RadDatePickerStart_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStart.SelectedDateChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))

        dDateStart = Me.RadDatePickerStart.SelectedDate
        If dDateStart = "#12:00:00 AM#" Then
            dDateStart = Today()
        End If

        otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(dDateStart))

        Me.ddDatePicker.SelectedValue = "4"
        otask.setAppVars(Session("UserCode"), "TaskList", "DatePicker", "", "4")

        LoadTasks()
    End Sub

    Private Function SetThisWeek()
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim weekday As Int16
        Dim strt_date As Date

        weekday = Date.Today.DayOfWeek
        If weekday > 0 Then
            weekday = 0 - weekday
            strt_date = Date.Today.AddDays(weekday)
        Else
            strt_date = Today()
        End If


        RadDatePickerStart.SelectedDate = LoGlo.FormatDate(strt_date.ToString())
        RadDatePickerDue.SelectedDate = LoGlo.FormatDate(strt_date.AddDays(6).ToString())

        otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(RadDatePickerStart.SelectedDate))
        otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(RadDatePickerDue.SelectedDate))

    End Function

    Private Function SetThis2Week()
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim weekday As Int16
        Dim strt_date As Date

        weekday = Date.Today.DayOfWeek
        If weekday > 0 Then
            weekday = 0 - weekday
            strt_date = Date.Today.AddDays(weekday)
        Else
            strt_date = Today()
        End If

        RadDatePickerStart.SelectedDate = strt_date
        RadDatePickerDue.SelectedDate = strt_date.AddDays(14)

        otask.setAppVars(Session("UserCode"), "TaskList", "dDateStart", "", CStr(RadDatePickerStart.SelectedDate))
        otask.setAppVars(Session("UserCode"), "TaskList", "dDateDue", "", CStr(RadDatePickerDue.SelectedDate))

    End Function

    Private Sub LoadDataKeyValues(ByVal GridDataItem As Telerik.Web.UI.GridDataItem,
                                  ByRef JobNumber As Integer, ByRef JobComponentNumber As Short, ByRef SequenceNumber As Short)

        Try

            JobNumber = CInt(GridDataItem.GetDataKeyValue("JobNo"))

        Catch ex As Exception

        End Try

        Try

            JobComponentNumber = CShort(GridDataItem.GetDataKeyValue("JobComp"))

        Catch ex As Exception

        End Try

        Try

            SequenceNumber = CShort(GridDataItem.GetDataKeyValue("SeqNo"))

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub ddManager_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddManager.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sManager", "", Me.ddManager.SelectedValue)
        LoadTasks()
    End Sub

    Protected Sub RadComboBoxAccountExec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadComboBoxAccountExec.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sAcctExec", "", Me.RadComboBoxAccountExec.SelectedValue)
        LoadTasks()
    End Sub

    Private Sub ddOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddOffice.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sOffice", "", Me.ddOffice.SelectedValue)
        LoadTasks()
    End Sub

    Private Sub ddEmployee_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddEmployee.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sEmployee", "", Me.ddEmployee.SelectedValue)
        LoadTasks()
    End Sub

    Private Sub ddRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRole.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sRole", "", Me.ddRole.SelectedValue)
        LoadTasks()
    End Sub

    Private Sub ddType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddType.SelectedIndexChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sStatus", "", Me.ddType.SelectedValue)
        LoadTasks()
    End Sub

    Private Sub imgbtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnSearch.Click
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "sSearch", "", Me.txtSearch.Text)
        Me.TasksRG.MasterTableView.CurrentPageIndex = 0
        LoadTasks()
    End Sub

    Private Sub ImgBtnTempComplete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnTempComplete.Click
        Try

            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim st As DateTime
            Dim et As DateTime
            Dim dt As New DataTable

            Me.SetCriteria(st, et)

            dt = oDO.MarkNewTasksComplete(CStr(Session("UserCode")), Me.ddEmployee.SelectedValue, Me.ddRole.SelectedValue, st, et, Me.ddManager.SelectedValue,
                                          Me.ddOffice.SelectedValue, Me.ddType.SelectedValue, Me.txtSearch.Text)

            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then

                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                Dim DatatableTaskSeqNbrThatWereMadeActive As DataTable = Nothing
                Dim AutoAlertTaskEmployees As Boolean = False
                Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)

                AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                For i As Integer = 0 To dt.Rows.Count - 1

                    DatatableTaskSeqNbrThatWereMadeActive = New DataTable
                    DatatableTaskSeqNbrThatWereMadeActive = s.SetNextTaskActive(dt.Rows(i)("JobNo"), dt.Rows(i)("JobComp"), dt.Rows(i)("SeqNo"))

                    s.AutoUpdateTrafficCode(dt.Rows(i)("JobNo"), dt.Rows(i)("JobComp"))

                    If AutoAlertTaskEmployees = True Then

                        If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Dim ThisSeqNbr As Integer = 0

                                Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                                Dim EmpCodeString As String = ""
                                Dim NewAlertId As Integer = 0

                                For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                                    ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)

                                    NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, dt.Rows(i)("JobNo"), dt.Rows(i)("JobComp"), ThisSeqNbr, HttpContext.Current.Session("EmpCode"), EmpCodeString)

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

                            End Using

                        End If

                    End If

                    DatatableTaskSeqNbrThatWereMadeActive = Nothing

                Next

            End If

            Me.TasksRG.Rebind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkOnlyMarkedComplete_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkOnlyMarkedComplete.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "OnlyMarkedComplete", "Boolean", Me.ChkOnlyMarkedComplete.Checked)
        Me.TasksRG.Rebind()
    End Sub

    Private Sub CheckBoxExcludeUnassigned_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxExcludeUnassigned.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "ExcludeUnassigned", "Boolean", Me.CheckBoxExcludeUnassigned.Checked)
        Me.TasksRG.Rebind()
    End Sub

    Private Sub CheckBoxOnlyUnassigned_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxOnlyUnassigned.CheckedChanged
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TaskList", "OnlyUnassigned", "Boolean", Me.CheckBoxOnlyUnassigned.Checked)
        Me.TasksRG.Rebind()
    End Sub

    Private Sub TasksRG_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles TasksRG.ItemCommand

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Integer = Nothing
        Dim SequenceNumber As Integer = Nothing
        Dim Description As String = Nothing

        Try

            LoadDataKeyValues(DirectCast(e.Item, Telerik.Web.UI.GridDataItem), JobNumber, JobComponentNumber, SequenceNumber)

            Select Case e.CommandName

                Case "Documents"

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Documents_List2.aspx"
                        .JobNumber = JobNumber
                        .JobComponentNumber = JobComponentNumber
                        .TaskSequenceNumber = SequenceNumber
                        .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Task
                        .Add("doc_img", e.Item.FindControl("ImageButtonDocuments").ClientID)
                        .Add("opener", HiddenFieldWindowName.Value)

                    End With

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        With AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                            Description = .TaskCode & If(String.IsNullOrWhiteSpace(.Description), "", " - " & .Description)

                        End With

                    End Using

                    QueryString.Add("task_desc", Description)

                    Me.OpenWindow("Document List", QueryString.ToString(True))

            End Select

        Catch ex As Exception

        End Try

    End Sub
    Private Sub TasksRG_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles TasksRG.ItemDataBound

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim GridHeaderItem As Telerik.Web.UI.GridHeaderItem = Nothing
        Dim FlagImage As Web.UI.WebControls.Image = e.Item.FindControl("ImageFlag")
        Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
        Dim DataRowView As System.Data.DataRowView = Nothing
        Dim cdp() As String = Nothing
        Dim ViewImage As WebControls.ImageButton = Nothing
        Dim IsEventTask As Boolean = False
        Dim ThisRow_DataKey As String = Nothing
        Dim ViewLinkButton As WebControls.LinkButton = Nothing
        Dim PriorityColorDiv As HtmlControls.HtmlControl = Nothing
        Dim PriorityImage As Web.UI.WebControls.Image = Nothing
        Dim DocumentsImageButton As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DocumentsDiv As HtmlControls.HtmlControl = Nothing
        Dim HasDocuments As Boolean = False

        If e.Item.ItemType = GridItemType.Header Then

            GridHeaderItem = TryCast(e.Item, Telerik.Web.UI.GridHeaderItem)
            GridHeaderItem("TemplateColumn1").Text = "&nbsp;"
            GridHeaderItem("Documents").Text = "&nbsp;"

        End If

        Try

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)

                If GridDataItem IsNot Nothing Then

                    DataRowView = TryCast(GridDataItem.DataItem, System.Data.DataRowView)

                    Dim AlertID As Integer = 0
                    Dim SprintID As Integer = 0

                    If IsDBNull(DataRowView("ALERT_ID")) = False Then AlertID = DataRowView("ALERT_ID")
                    If IsDBNull(DataRowView("SPRINT_ID")) = False Then SprintID = DataRowView("SPRINT_ID")

                    If IsDBNull(DataRowView("DueDate")) = False Then

                        AdvantageFramework.Web.Presentation.Controls.SetDue(DataRowView("DueDate"), "column66", GridDataItem)

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(FlagColorDiv)

                    End If

                    cdp = DataRowView("CDP").ToString.Split("/")

                    ViewImage = GridDataItem.FindControl("ImageButtonViewDetails")

                    Try

                        If IsDBNull(DataRowView("IS_EVENT")) = False AndAlso DataRowView("IS_EVENT") = "1" Then IsEventTask = True

                    Catch ex As Exception
                        IsEventTask = False
                    End Try

                    Try

                        ThisRow_DataKey = "DTO|0|2|3|4|" & DataRowView("JobNo") & "|" & DataRowView("JobComp") & "|" & DataRowView("SeqNo") & "|8|" & DataRowView("EmpCode") & "|" & cdp(0).Trim & "|" & cdp(1).Trim & "|" & cdp(2).Trim & "|" & DataRowView("Task")

                        If IsEventTask = False Then

                            If AlertID > 0 Then

                                Dim QsViewDetails As New AdvantageFramework.Web.QueryString

                                QsViewDetails.Page = "Desktop_AlertView"
                                QsViewDetails.Add("AlertID", DataRowView("ALERT_ID").ToString)
                                QsViewDetails.Add("SprintID", DataRowView("SPRINT_ID").ToString)

                                ViewImage.Attributes.Add("onclick", Me.HookUpOpenWindow("", QsViewDetails.ToString(True)))

                            Else

                                ViewImage.Attributes.Add("onclick", Me.HookUpOpenDetailWindow(ThisRow_DataKey))

                            End If

                        Else

                            If IsNumeric(DataRowView("EVENT_TASK_ID")) = True Then

                                ViewImage.Attributes.Add("onclick", Me.HookUpOpenWindow(DataRowView("JobNo"), "Event_Task_Detail.aspx?etid=" & DataRowView("EVENT_TASK_ID").ToString()))

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                    'Dim txtComment As System.Web.UI.WebControls.TextBox = e.Item.Cells(6).FindControl("taskcomment")
                    If Not DataRowView("TempCompleteDate") Is System.DBNull.Value Then

                        e.Item.Font.Strikeout = True

                        For Each TableCell In GridDataItem.Cells.OfType(Of System.Web.UI.WebControls.TableCell)()

                            TableCell.Font.Strikeout = True

                        Next

                    End If

                    ViewLinkButton = GridDataItem.FindControl("ViewLinkButton")
                    ViewLinkButton.Text = DataRowView("JobData")
                    ViewLinkButton.ToolTip = DataRowView("JobData")

                    ViewLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("Job Jacket", "Content.aspx?From=DO&PageMode=Edit&JobNum=" & DataRowView("JobNo") & "&JobCompNum=" & DataRowView("JobComp") & "&NewComp=0"))

                    If String.IsNullOrEmpty(GridDataItem("column6").Text) = False AndAlso GridDataItem("column6").Text <> "&nbsp;" Then 'start date column
                        GridDataItem("column6").Text = LoGlo.FormatDate(GridDataItem("column6").Text)
                    End If

                    If String.IsNullOrEmpty(GridDataItem("column66").Text) = False AndAlso GridDataItem("column66").Text <> "&nbsp;" Then 'due date column
                        GridDataItem("column66").Text = LoGlo.FormatDate(GridDataItem("column66").Text)
                    End If

                    PriorityColorDiv = GridDataItem.FindControl("DivPriorityColor")
                    PriorityImage = GridDataItem.FindControl("ImagePriority")

                    PriorityImage.ToolTip = ""

                    If IsEventTask = True Then

                        PriorityImage.ToolTip = "Event Task"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "calendar-event")

                    End If

                    Select Case DataRowView("TASK_STATUS").ToString().Trim().ToUpper()
                        Case "H"
                            'PriorityImage.ImageUrl = "~/Images/priority_high.png"
                            PriorityImage.ToolTip = "High Priority"
                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-high")
                        Case "L"
                            'PriorityImage.ImageUrl = "~/Images/priority_low.png"
                            PriorityImage.ToolTip = "Low Priority"
                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(PriorityColorDiv, "alert-priority-low")
                        Case "A"
                            Select Case DataRowView("PRIORITY")
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
                            Select Case DataRowView("PRIORITY")
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

                    DocumentsImageButton = GridDataItem.FindControl("ImageButtonDocuments")
                    DocumentsDiv = GridDataItem.FindControl("DivDocumentsColor")

                    DocumentsImageButton.ToolTip = ""

                    If IsEventTask = True Then

                        DocumentsImageButton.Visible = False
                        DocumentsDiv.Visible = False

                    Else

                        DocumentsImageButton.Visible = True
                        DocumentsImageButton.CommandName = "Documents"

                        Try

                            If DataRowView("HAS_DOCUMENTS") = True Then

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

                    'Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    'Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(CInt(e.Item.DataItem("JobNo")), CInt(e.Item.DataItem("JobComp")), CInt(e.Item.DataItem("SeqNo")))
                    'If strEmps <> "" Then
                    '    e.Item.Cells(3).Text = strEmps
                    'End If

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TasksRG_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles TasksRG.NeedDataSource
        Try

            Me.TasksRG.MasterTableView.CurrentPageIndex = 0

            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim st As DateTime
            Dim et As DateTime
            Dim filter As String = ""

            Me.SetCriteria(st, et)

            Dim dt As New DataTable

            dt = oDO.GetTasksNew(CStr(Session("UserCode")), Me.ddEmployee.SelectedValue, Me.ddRole.SelectedValue, st, et, Me.ddManager.SelectedValue,
                                 Me.ddOffice.SelectedValue, Me.ddType.SelectedValue, Me.txtSearch.Text, Me.RadComboBoxAccountExec.SelectedValue)

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    If IsDBNull(dt.Rows(i)("TaskComment")) = False Then

                        dt.Rows(i)("TaskComment") = dt.Rows(i)("TaskComment").ToString().Replace(Environment.NewLine, "<br />")

                    End If

                Next

            End If

            Dim dv As New DataView(dt)

            If Me.ChkOnlyMarkedComplete.Checked = True Then

                filter = "(NOT(TempCompleteDate IS NULL))"

            End If

            If Me.CheckBoxExcludeUnassigned.Checked = True Then

                If filter = "" Then

                    filter = "(EmpCode <> '')"

                Else

                    filter &= " AND (EmpCode <> '')"

                End If

            End If

            If Me.CheckBoxOnlyUnassigned.Checked = True Then

                If filter = "" Then

                    filter = "(EmpCode = '')"

                Else

                    filter &= " AND (EmpCode = '')"

                End If

            End If

            If filter = "" Then

                filter = "(HAS_CHILDREN = 0)"

            Else

                filter &= " AND (HAS_CHILDREN = 0)"

            End If

            dv.RowFilter = filter

            Me.TasksRG.DataSource = dv
            Me.TasksRG.MasterTableView.GetColumn("ColTempComplete").Display = Me.ChkOnlyMarkedComplete.Checked
            Me.TasksRG.PageSize = MiscFN.LoadPageSize(Me.TasksRG.ID)

            Dim ShowReOrderColumn As Boolean = False

            If Me.ddEmployee.SelectedIndex > 0 Then

                If AdvantageFramework.Security.UserHasAccessToEmployee(_Session, _Session.UserCode, Me.ddEmployee.SelectedValue) = True Then

                    ShowReOrderColumn = True

                End If

            End If

            TasksRG.MasterTableView.GetColumn("DragDropColumn").Visible = ShowReOrderColumn
            TasksRG.ClientSettings.AllowRowsDragDrop = ShowReOrderColumn
            TasksRG.ClientSettings.Selecting.AllowRowSelect = ShowReOrderColumn

        Catch ex As Exception

        End Try
    End Sub
    Private Sub TasksRG_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles TasksRG.PageIndexChanged
        LoadTasks()
    End Sub
    Private Sub TasksRG_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles TasksRG.PageSizeChanged
        MiscFN.SavePageSize(Me.TasksRG.ID, e.NewPageSize)
    End Sub
    Private Sub TasksRG_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles TasksRG.PreRender
        Session("TasksListDOSortExp") = Me.TasksRG.MasterTableView.SortExpressions.GetSortString
    End Sub
    Private Sub TasksRG_SortCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridSortCommandEventArgs) Handles TasksRG.SortCommand
        Try
            Dim sortstr As String
            Dim sortCt As Integer
            Dim sortarr(10) As String
            Dim sortExpr(2) As String
            Dim sortOrder(10), sortFldname(10) As String
            Dim sortIdx As Integer

            'Create new sort expression to pass to print screen
            ' sort orders: 0=ASC, 1=DESC, 2=None
            sortCt = Me.TasksRG.MasterTableView.SortExpressions.Count
            sortstr = Me.TasksRG.MasterTableView.SortExpressions.GetSortString

            If sortstr = Nothing Then sortstr = ""
            If e.OldSortOrder = 2 Then 'New sort column
                If sortstr.Length > 0 Then sortstr = sortstr + ","
                sortstr = sortstr + e.SortExpression

                If e.NewSortOrder = 0 Then
                    sortstr = sortstr + " ASC"
                Else
                    sortstr = sortstr + " DESC"
                End If

                sortCt = sortCt + 1

            Else 'Need to find existing column and change sort order, sortCt stays the same
                sortarr = sortstr.Split(",")

                For sortIdx = 0 To sortCt - 1
                    sortstr = sortarr(sortIdx).Trim
                    sortExpr = sortstr.Split(" ")

                    sortFldname(sortIdx) = sortExpr(0)
                    sortOrder(sortIdx) = sortExpr(1)

                    If sortFldname(sortIdx) = e.SortExpression Then
                        If sortOrder(sortIdx) = "ASC" Then
                            sortOrder(sortIdx) = "DESC"
                        Else
                            sortOrder(sortIdx) = "ASC"
                        End If
                    End If
                Next

                sortstr = ""
                For sortIdx = 0 To sortCt - 1
                    If sortIdx > 0 Then sortstr = sortstr + ", "
                    sortstr = sortstr + sortFldname(sortIdx) + " " + sortOrder(sortIdx)
                Next
            End If

            Session("TskLstSortExpr") = sortstr
            Session("TskLstSortCt") = sortCt

            LoadTasks()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TasksRG_RowDrop(sender As Object, e As GridDragDropEventArgs) Handles TasksRG.RowDrop

        Dim s As String = ""
        If Me.ddEmployee.SelectedIndex > 0 AndAlso e.DraggedItems(0).OwnerGridID = TasksRG.ClientID Then

            If e.DestDataItem IsNot Nothing Then

                Dim NewIndex As Integer = e.DestDataItem.ItemIndex
                Dim CurrentGridRow As GridDataItem = e.DraggedItems(0)
                Dim LastIndex As Integer = CurrentGridRow.ItemIndex

                If NewIndex <> LastIndex Then

                    s = SortTaskList(CurrentGridRow.GetDataKeyValue("JobNo"), CurrentGridRow.GetDataKeyValue("JobComp"), CurrentGridRow.GetDataKeyValue("SeqNo"),
                                                    CurrentGridRow.GetDataKeyValue("EVENT_TASK_ID"), NewIndex, Me.ddEmployee.SelectedItem.Value)

                    If s.Trim() = "" Then

                        TasksRG.Rebind()

                    Else

                        Me.ShowMessage(s)

                    End If

                End If

            End If

        End If

    End Sub

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Try

            Me.MyUnityContextMenu.JobNumber = TasksRG.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNo")
            Me.MyUnityContextMenu.JobComponentNumber = TasksRG.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComp")

        Catch ex As Exception
        End Try

    End Sub
    Private Sub ImageButtonFilter_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonFilter.Click

        Me.CollapsablePanelFilter.Collapsed = Not Me.CollapsablePanelFilter.Collapsed
        Me.CollapsablePanelFilter.Visible = Not Me.CollapsablePanelFilter.Visible

    End Sub

    Private Function SortTaskList(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                                  ByVal EventTaskID As Integer, ByVal NewPosition As Integer, ByVal EmployeeCode As String) As String

        System.Threading.Thread.Sleep(250)

        Dim UserCode As String = HttpContext.Current.Session("UserCode")
        Dim ConnectionString As String = HttpContext.Current.Session("ConnString")

        Try

            Using DbContext As New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_card_user_sort_tasks] '{0}', '{1}', {2}, {3}, {4}, {5}, {6}, 1;",
                                                     UserCode, EmployeeCode, JobNumber, JobComponentNumber, TaskSequenceNumber, EventTaskID, NewPosition))

            End Using

            Return ""

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try

    End Function

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_TaskList
                .UserCode = Session("UserCode")
                .Name = "Task List (All)"
                .Description = "Task List (All)"
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
