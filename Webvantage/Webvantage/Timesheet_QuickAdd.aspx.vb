Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class Timesheet_QuickAdd
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private SeqNum As Integer = 0
    Private TaskEmp As String = ""
    Private Property AlertID As Integer
        Get
            If ViewState("AlertID") Is Nothing Then
                ViewState("AlertID") = 0
            End If
            Return ViewState("AlertID")
        End Get
        Set(value As Integer)
            ViewState("AlertID") = value
        End Set
    End Property
    Private DefFunction As String = ""
    Private DefEmpFunction As String = ""
    Private DefDept As String = ""
    Private DtDepartments As New DataTable
    Private DtFunctions As New DataTable
    Private CommentsRequired As Boolean = False

#End Region

#Region " Properties "

    Private Property SprintID As Integer = 0
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

#End Region

#Region " Page Events "

    Private Sub Timesheet_QuickAdd_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString

        qs = qs.FromCurrent

        JobNum = qs.JobNumber
        JobComp = qs.JobComponentNumber
        SeqNum = qs.TaskSequenceNumber
        TaskEmp = qs.EmployeeCode
        AlertID = qs.AlertID

        Try
            If JobNum = 0 AndAlso Request.QueryString("JobNum") IsNot Nothing Then JobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            If JobComp = 0 AndAlso Request.QueryString("JobComp") IsNot Nothing Then JobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        Try
            If SeqNum = 0 AndAlso Request.QueryString("SeqNo") IsNot Nothing Then SeqNum = CType(Request.QueryString("SeqNo"), Integer)
        Catch ex As Exception
            SeqNum = -1
        End Try
        Try
            If SeqNum = -1 AndAlso Request.QueryString("Seq") IsNot Nothing Then SeqNum = CType(Request.QueryString("Seq"), Integer)
        Catch ex As Exception
            SeqNum = -1
        End Try
        Try
            If String.IsNullOrWhiteSpace(TaskEmp) AndAlso Request.QueryString("TaskEmp") IsNot Nothing Then TaskEmp = Request.QueryString("TaskEmp")
        Catch ex As Exception
            TaskEmp = ""
        End Try
        Try
            If String.IsNullOrWhiteSpace(TaskEmp) = True Then TaskEmp = Session("EmpCode")
        Catch ex As Exception
            TaskEmp = ""
        End Try

    End Sub
    Protected Sub Timesheet_QuickAdd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack Then

            Me.SetRadDatePicker(Me.RadDatePickerDate)

            If JobNum > 0 And JobComp > 0 And SeqNum > -1 And TaskEmp <> "" Then

                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                Dim dt As New DataTable

                dt = oTS.GetQuickAddHeader(JobNum, JobComp, SeqNum, TaskEmp)

                If dt.Rows.Count > 0 Then

                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then

                        Client = dt.Rows(0)("CL_CODE")
                        HfClient.Value = Client
                        Me.TextBoxClientCode.Text = dt.Rows(0)("CL_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then

                        Me.TextBoxClientDescription.Text = dt.Rows(0)("CL_NAME")

                    End If
                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then

                        Division = dt.Rows(0)("DIV_CODE")
                        Me.TextBoxDivisionCode.Text = dt.Rows(0)("DIV_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then

                        Me.TextBoxDivisionDescription.Text = dt.Rows(0)("DIV_NAME")

                    End If
                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then

                        Product = dt.Rows(0)("PRD_CODE")
                        Me.TextBoxProductCode.Text = dt.Rows(0)("PRD_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then

                        Me.TextBoxProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")

                    End If
                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then

                        Me.TextBoxJobNumber.Text = dt.Rows(0)("JOB_NUMBER")

                    End If
                    If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then

                        Me.TextBoxJobDescription.Text = dt.Rows(0)("JOB_DESC")

                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then

                        Me.TextBoxJobComponentNbr.Text = dt.Rows(0)("JOB_COMPONENT_NBR")

                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then

                        Me.TextBoxJobComponentDescription.Text = dt.Rows(0)("JOB_COMP_DESC")

                    End If
                    If IsDBNull(dt.Rows(0)("FNC_CODE")) = False Then

                        Me.TextBoxTaskCode.Text = dt.Rows(0)("FNC_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("TASK_DESCRIPTION")) = False Then

                        Me.TextBoxTaskDescription.Text = dt.Rows(0)("TASK_DESCRIPTION")

                    End If
                    If IsDBNull(dt.Rows(0)("FNC_COMMENTS")) = False Then

                        Me.TextBoxTaskComment.Text = dt.Rows(0)("FNC_COMMENTS")

                    End If
                    If IsDBNull(dt.Rows(0)("FNC_EST")) = False Then

                        Me.DefFunction = dt.Rows(0)("FNC_EST")

                    End If
                    If IsDBNull(dt.Rows(0)("EMP_DEF_FNC_CODE")) = False Then

                        Me.DefEmpFunction = dt.Rows(0)("EMP_DEF_FNC_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("DP_TM_CODE")) = False Then

                        Me.DefDept = dt.Rows(0)("DP_TM_CODE")

                    End If
                    If IsDBNull(dt.Rows(0)("TEMP_COMP_DATE")) = False Then

                        If cGlobals.wvIsDate(dt.Rows(0)("TEMP_COMP_DATE")) Then

                            Me.ChkMarkCompleted.Checked = True
                            Me.HfAlreadyMarked.Value = "True"

                        Else

                            Me.ChkMarkCompleted.Checked = False
                            Me.HfAlreadyMarked.Value = "False"

                        End If

                    Else

                        Me.ChkMarkCompleted.Checked = False
                        Me.HfAlreadyMarked.Value = "False"

                    End If
                    If IsDBNull(dt.Rows(0)("ALERT_ID")) = False Then

                        Me.AlertID = dt.Rows(0)("ALERT_ID")

                    End If

                    'Bind drops
                    LoadFunctionsDS()
                    With Me.DropFunction
                        .DataSource = DtFunctions
                        .DataTextField = "description"
                        .DataValueField = "code"
                        .DataBind()
                    End With

                    LoadDeptDS()
                    With Me.DropDepartment
                        .DataSource = DtDepartments
                        .DataTextField = "description"
                        .DataValueField = "code"
                        .DataBind()
                    End With

                    If DropDepartment.Items.Count <= 1 Then

                        DropDepartment.Enabled = False

                    Else

                        DropDepartment.Enabled = True

                    End If

                    If ProductCategoryIsVisible() = True Then
                        Me.ProdCatRow.Visible = True
                        If RequiredProductCategory(Client) = True Then
                            Me.DropProdCat.CssClass = "RequiredInput"
                        End If
                        'bind DropProdCat
                        Dim d As New cDropDowns(Session("ConnString"))
                        With Me.DropProdCat
                            .DataSource = d.ddProductCategory(Client, Division, Product)
                            .DataTextField = "Description"
                            .DataValueField = "Code"
                            .DataBind()
                            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
                        End With
                    Else
                        Me.ProdCatRow.Visible = False
                    End If
                    'get task comment too:
                    Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
                    Me.TxtCompletedComments.Text = t.GetTaskComment(JobNum, JobComp, SeqNum, TaskEmp)
                    'Set Default

                    'Change per Ellen per Client Request when comming from as task. 2009/05/27 
                    'Works the same as timesheet from my projects.
                    If Me.DefFunction <> "" Then
                        MiscFN.RadComboBoxSetIndex(Me.DropFunction, Me.DefFunction, False)
                    End If
                    If Me.DefEmpFunction <> "" And Me.DefFunction = "" Then
                        MiscFN.RadComboBoxSetIndex(Me.DropFunction, Me.DefEmpFunction, False)
                    End If

                    MiscFN.RadComboBoxSetIndex(Me.DropDepartment, Me.DefDept, False)
                    Me.RadDatePickerDate.SelectedDate = cEmployee.TimeZoneToday

                    'set alias
                    oTS.GetTimesheetSettings(Session("UserCode"), , , , Me.LabelDivisionAlias.Text, Me.LabelProductAlias.Text,
                                             Me.LabelProductCategoryAlias.Text, Me.LabelJobAlias.Text, Me.LabelJobComponentAlias.Text,
                                             Me.LabelFunctionAlias.Text, )

                    If oTS.JobCommentRequired(Me.JobNum) = True Then

                        Me.TxtComments.CssClass = "RequiredInput"

                    End If

                Else

                    'No header record, close the window?
                    Dim cScript2 As String
                    cScript2 = "<script>window.close();ShowMessage('Error getting task.');</script>"
                    RegisterStartupScript("page55", cScript2)

                End If

            End If

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ImageButtonStopwatch_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonStopwatch.Click

        Dim s As String = ""
        Dim ThisEtId As Integer = 0
        Dim ThisEtDtlId As Integer = 0

        If Me.RadDatePickerDate.SelectedDate.HasValue = True Then
            If CType(Me.RadDatePickerDate.SelectedDate, Date).ToShortDateString <> cEmployee.TimeZoneToday.ToShortDateString Then
                Me.ShowMessage("Stopwatch cannot be started on a day other than today")
                Exit Sub
            End If
        End If

        If Me.SaveForm(s, ThisEtId, ThisEtDtlId) = False Then
            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
        Else
            'Dim t As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))
            If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), ThisEtId, ThisEtDtlId, s) = False Then
                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))
            Else
                'Me.CloseWindow()
                '''Me.RefreshCaller("Timesheet_Stopwatch.aspx", True, True, True)
                Me.OpenTimesheetStopwatchNotificationWindow()

            End If
        End If

    End Sub
    Private Sub RadToolBarTimesheetQuickAdd_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarTimesheetQuickAdd.ButtonClick
        Select Case e.Item.Value
            Case "Save"

                Dim s As String = ""
                Dim ThisEtId As Integer = 0
                Dim ThisEtDtlId As Integer = 0

                If Me.SaveForm(s, ThisEtId, ThisEtDtlId) = False Then

                    Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(s))

                Else

                    Me.CloseWindow()

                End If

            Case "Cancel"

                Me.CloseWindow()

        End Select
    End Sub

#End Region

#Region " Methods "

    Private Sub LoadDeptDS()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        DtDepartments = odd.GetDeptDatatable(Session("EmpCode"), True)
    End Sub
    Private Sub LoadFunctionsDS()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        Me.DtFunctions = odd.GetFunctionsByEmpCodeDatatable(Session("EmpCode"), JobNum)
    End Sub
    Private Sub CloseWindow()
        Try
            If Session("TimesheetTask") <> "1" Then
                Me.CloseThisWindowAndRefreshCaller("TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & JobNum & "&JobComp=" & JobComp & "&SeqNum=" & SeqNum & "&Client=" & Me.Client & "&Division=" & Me.Division & "&Product=" & Me.Product)
            Else
                Me.CloseThisWindow()
            End If
        Catch ex As Exception
            Me.CloseThisWindow()
        End Try
    End Sub
    Private Function ProductCategoryIsVisible() As Boolean
        Dim ovisible As cVisible = New cVisible(CStr(Session("ConnString")))
        Return ovisible.ProductCategoryVisible()
    End Function
    Private Function RequiredProductCategory(ByVal ClientCode As String) As Boolean
        Dim oReq As cRequired = New cRequired(CStr(Session("ConnString")))
        Return oReq.ProductCategoryRequired(ClientCode)
    End Function
    Private Function SaveForm(ByRef ErrorMessage As String, ByRef NewEtId As Integer, ByRef NewEtDtlId As Integer) As Boolean
        If MiscFN.ValidDate(Me.RadDatePickerDate) = False Then
            ErrorMessage = MiscFN.InvalidDateMessage
            Return False
        End If
        If Me.RadNumericTextBoxHours.Text.Trim() = "" Then Me.RadNumericTextBoxHours.Text = "0.00"
        If IsNumeric(Me.RadNumericTextBoxHours.Text) = False Then
            ErrorMessage = "Invalid hours."
            Return False
        End If
        If CType(Me.RadNumericTextBoxHours.Text, Decimal) > 24 Then

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe("Invalid hours."))
            Return False

        End If

        Dim ThisDate As Date = cGlobals.wvCDate(Me.RadDatePickerDate.SelectedDate)
        Dim ThisHours As Decimal = CType(Me.RadNumericTextBoxHours.Value, Decimal)

        'job validation
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If myVal.ValidateJobIsOpen(JobNum, JobComp) = False Then
            ErrorMessage = "This job/comp is closed."
            Return False
        End If
        If Me.Client <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Client, "", "", "ts") = False Then
                ErrorMessage = "Access to this client is denied."
                Return False
            End If
        End If
        If Me.Client <> "" And Me.Division <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Client, Division, "", "ts") = False Then
                ErrorMessage = "Access to this division is denied."
                Return False
            End If
        End If
        If Me.Client <> "" And Me.Division <> "" And Me.Product <> "" Then
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Client, Division, Product, "ts") = False Then
                ErrorMessage = "Access to this product is denied."
                Return False
            End If
        End If
        If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.JobNum, Me.JobComp, "ts") = False Then
            ErrorMessage = "Access to this job/comp is denied."
            Return False
        End If
        If myVal.ValidateJobCompIsEditable(Me.JobNum, Me.JobComp) = False Then
            ErrorMessage = "Job/comp process control does not allow access."
            Return False
        End If


        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim CurrDefaultFN As String = oTS.GetDefaultFunction(Me.TaskEmp)
        If Me.DropFunction.SelectedValue = CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(Me.TaskEmp, CurrDefaultFN) = False Then
                ErrorMessage = "This employee does not have access to his/her own default function."
                Return False
            End If
        End If
        If Me.JobNum <> 0 And Me.JobComp <> 0 And Me.DropFunction.SelectedValue <> CurrDefaultFN Then
            If myVal.ValidateFunctionTSAddNew(Me.TaskEmp, Me.DropFunction.SelectedValue) = False Then
                ErrorMessage = Me.DropFunction.SelectedValue & " is an invalid function."
                Return False
            End If
        End If

        If oTS.CheckApprovalStatus(TaskEmp, ThisDate) = True Then
            ErrorMessage = "Status for this day is approved/pending."
            Return False
        End If
        If oTS.PostPeriodClosed(ThisDate) = True Then
            ErrorMessage = "This day is in a closed posting period."
            Return False
        End If

        If Me.TxtComments.Text.Length = 0 And oTS.JobCommentRequired(Me.JobNum) = True Then
            ErrorMessage = "Comment is required."
            Return False
        End If

        Dim ThisDept As String = ""
        ThisDept = Me.DropDepartment.SelectedValue

        If myVal.ValidateDeptTeam(ThisDept) = False Then

            Me.DropDepartment.Focus()
            ErrorMessage = "Invalid Department."
            Return False

        End If

        Dim StrProdCat As String = ""
        If Me.ProdCatRow.Visible = True Then
            If Me.RequiredProductCategory(Me.HfClient.Value) = True Then
                If Me.DropProdCat.SelectedIndex = 0 Then
                    ErrorMessage = "Product/Category is required."
                    Return False
                Else
                    StrProdCat = Me.DropProdCat.SelectedValue
                End If
            Else
                If Me.DropProdCat.SelectedIndex = 0 Then
                    StrProdCat = ""
                Else
                    StrProdCat = Me.DropProdCat.SelectedValue
                End If
            End If
        Else
            StrProdCat = ""
        End If

        If Me.RadNumericTextBoxPercentComplete.Text <> "" Then
            If IsNumeric(Me.RadNumericTextBoxPercentComplete.Text) = False Then
                ErrorMessage = "Invalid Percent Complete"
                Return False
            End If
        End If

        'Dim TimesheetMethods As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

        Dim EtId As Integer = 0
        Dim EtDtlId As Integer = 0
        ''Dim EditExistingEntryIfFound As Boolean = False

        ''If TimesheetMethods.TimeEntryExists(ThisEmp, ThisDate, Me.DropFunction.SelectedValue, StrProdCat, _
        ''                                    JobNum, JobComp, ThisDept, EtId, EtDtlId, EditExistingEntryIfFound, ErrorMessage) = True Then

        ''    If EditExistingEntryIfFound = False Then

        ''        EtId = 0
        ''        EtDtlId = 0

        ''    End If

        ''End If
        If AlertID = 0 AndAlso JobNum > 0 AndAlso JobComp > 0 AndAlso SeqNum > -1 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM ALERT WHERE ALERT_LEVEL = 'BRD' AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND TASK_SEQ_NBR = {2};", JobNum, JobComp, SeqNum)).SingleOrDefault

                Catch ex As Exception
                    AlertID = 0
                End Try
                If AlertID = 0 Then

                    Try

                        DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_agile_add_assignment_from_task] {0}, {1}, {2}, '{3}';", JobNum, JobComp, SeqNum, _Session.UserCode))

                    Catch ex As Exception
                    End Try

                End If
                Try

                    AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM ALERT WHERE ALERT_LEVEL = 'BRD' AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND TASK_SEQ_NBR = {2};", JobNum, JobComp, SeqNum)).SingleOrDefault

                Catch ex As Exception
                    AlertID = 0
                End Try

            End Using

        End If
        Try

            If AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), EtId, EtDtlId, TaskEmp, ThisDate,
                                                    Me.DropFunction.SelectedValue, StrProdCat, ThisHours, JobNum,
                                                    JobComp, ThisDept, Session("UserCode"), ErrorMessage,
                                                    Me.TxtComments.Text, NewEtId, NewEtDtlId, True, Me.AlertID) = True Then

                With oTS
                    .DeleteMissingTimeDtl(TaskEmp)
                End With
                TimesheetPage.ProcessMissingTime(TaskEmp, ThisDate)

                Dim t As cTasks = New cTasks(CStr(Session("ConnString")))
                'If Me.ChkMarkCompleted.Checked = True And Me.HfAlreadyMarked.Value = "False" Then 'AND statement TO make sure we don't re-update date
                '    t.MarkCompleted(JobNum, JobComp, SeqNum, ThisEmp, Today.Date)
                'ElseIf Me.ChkMarkCompleted.Checked = False Then
                '    t.MarkNotCompleted(JobNum, JobComp, SeqNum, ThisEmp)
                'End If

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using sc As New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Me.ChkMarkCompleted.Checked = True Then

                            Select Case FullyCompleteTask

                                Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Yes

                                    If Me.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, CType(Now, DateTime)) = True Then

                                        If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNum, JobComp, SeqNum,
                                                                                                                HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then
                                        End If

                                    End If

                                Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.Prompt

                                    If Me.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, CType(Now, DateTime)) = True Then

                                        If AdvantageFramework.ProjectSchedule.CompleteTaskInsteadOfTempComplete(DbContext, JobNum, JobComp, SeqNum,
                                                                                                                HttpContext.Current.Session("EmpCode"), MiscFN.IsClientPortal) Then

                                            Me.ShowMessage("Task will be completed if you were the last employee to temp complete")

                                        End If

                                    End If

                                Case AdvantageFramework.ProjectSchedule.Methods.LookupSettingsOptions.No

                                    Me.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, CType(Now, DateTime))

                            End Select

                        ElseIf Me.ChkMarkCompleted.Checked = False Then

                            'Me.MarkTempComplete(DbContext, sc, JobNum, JobComp, SeqNum, Nothing)

                        End If

                    End Using

                End Using

                t.SaveTaskComment(JobNum, JobComp, SeqNum, TaskEmp, Me.TxtCompletedComments.Text)

                UpdateJobComponentTaskEmployee(JobNum, JobComp, SeqNum, TaskEmp)

                If Session("TimesheetTaskQuickAdd") = "1" Then

                    Session("TimesheetTaskQuickAdd") = ""
                    Session("TimesheetTask") = "1"

                Else

                    Session("TimesheetTask") = ""

                End If

                Try

                    Dim r As New AdvantageFramework.EmployeeTimesheet.Classes.SaveTimeEntryResult(ErrorMessage)
                    If r IsNot Nothing Then

                        Select Case r.ErrorCode
                            Case -15, -16, -17
                                If r.WarningMessage <> "" Then
                                    Me.ShowMessage(r.WarningMessage)
                                End If
                        End Select

                    End If

                Catch ex As Exception

                End Try

                ErrorMessage = ""
                Return True

            Else

                NewEtId = 0
                NewEtDtlId = 0
                Return False

            End If

        Catch ex As Exception

            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function
    Private Function MarkTempComplete(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                      ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal SequenceNumber As Short, ByVal CompleteDate As DateTime?) As Boolean

        Dim MarkedComplete As Boolean = False
        Dim MarkedTempComplete As Boolean = False
        Dim AutoAlertTaskEmployees As Boolean = False
        Dim DatatableTaskSeqNbrThatWereMadeActive As New DataTable
        Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)

        MarkedTempComplete = AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, SecurityDbContext, JobNumber, JobComponentNumber, SequenceNumber, Session("EmpCode"), CompleteDate, MarkedComplete)

        AutoAlertTaskEmployees = asm.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

        If AutoAlertTaskEmployees = True Then

            If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                Dim ThisSeqNbr As Integer = 0

                Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                Dim EmpCodeString As String = ""
                Dim NewAlertId As Integer = 0

                For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                    ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)

                    NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobNumber, JobComponentNumber, SequenceNumber, HttpContext.Current.Session("EmpCode"), EmpCodeString)

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

    Private Function UpdateJobComponentTaskEmployee(ByVal JobNum As Integer, ByVal CompNum As Integer, ByVal SeqNum As Integer, ByVal EmpCode As String) As Boolean

        'objects
        Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
        Dim JobComponentTaskEmployeeUpdated As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobComponentTaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, JobNum, CompNum, SeqNum, EmpCode)

                If JobComponentTaskEmployee IsNot Nothing Then

                    If Me.RadNumericTextBoxPercentComplete.Text <> "" Then
                        JobComponentTaskEmployee.PercentComplete = CDec(Me.RadNumericTextBoxPercentComplete.Value)
                    End If

                    JobComponentTaskEmployeeUpdated = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Update(DbContext, JobComponentTaskEmployee)

                End If

            End Using

        Catch ex As Exception
            JobComponentTaskEmployeeUpdated = False
        Finally
            UpdateJobComponentTaskEmployee = JobComponentTaskEmployeeUpdated
        End Try

    End Function

#End Region

End Class
