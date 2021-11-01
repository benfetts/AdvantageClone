
Imports Telerik.Web.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Text
'Imports ICSharpCode.SharpZipLib.Zip
'Imports ICSharpCode.SharpZipLib.Core
Imports Ionic.Zip
Imports System.IO
Imports System.Threading

Partial Public Class TrafficSchedule_Multiview
    Inherits Webvantage.BaseChildPage

#Region " Variables "
    Protected WithEvents DropPhaseFilter As Global.Telerik.Web.UI.RadComboBox
    Protected WithEvents DropSort As Global.Telerik.Web.UI.RadComboBox
    'Private p As ParentPage = CType(Me.Page.Master, ParentPage)
    Private ClientCode As String = ""
    Private DivisionCode As String = ""
    Private ProductCode As String = ""
    Private JobNumber As Integer = 0
    Private JobCompNumber As Integer = 0
    Private JobType As String = ""
    Private EmpCode As String = ""
    Private ManagerCode As String = ""
    Private TaskCode As String = ""
    Private AccountExecCode As String = ""
    Private RoleCode As String = ""
    Private CutOffDate As String = ""
    Private IncludeCompletedTasks As Boolean = True
    Private IncludeOnlyPendingTasks As Boolean = False
    Private ExcludeProjectedTasks As Boolean = False
    Private IncludeCompletedSchedules As Boolean = True
    Private OnlyScheduleTemplates As Boolean = False
    Private EditHeaders As Boolean = False
    Private EditGrids As Boolean = False
    Private UsingATaskLevelFilter As Boolean = False
    Private CampaignCode As String = ""
    Private TaskPhaseFilter As String = ""
    Private OfficeCode As String = ""
    Private SalesClass As String = ""
    Private qs As String = ""
    Private _UserCustom1 As Boolean = False
    Private _LoadingDatasource As Boolean = False

    Private UnlockedImage As String = "~/Images/lock_open16.png"
    Private LockedImage As String = "~/Images/lock16.png"
    Protected WithEvents DropApplyTeamType As Telerik.Web.UI.RadComboBox

    '''Private _ordersExpandedState As Hashtable
    '''Private _selectedState As Hashtable
    '''Private ReadOnly Property ExpandedStates() As Hashtable
    '''    Get
    '''        If Me._ordersExpandedState Is Nothing Then
    '''            _ordersExpandedState = TryCast(Me.Session("_ordersExpandedState"), Hashtable)
    '''            If _ordersExpandedState Is Nothing Then
    '''                _ordersExpandedState = New Hashtable()
    '''                Me.Session("_ordersExpandedState") = _ordersExpandedState
    '''            End If
    '''        End If

    '''        Return Me._ordersExpandedState
    '''    End Get
    '''End Property
    '''Private Sub ClearExpandedChildren(ByVal parentHierarchicalIndex As String)
    '''    Dim indexes As String() = New String(Me.ExpandedStates.Keys.Count - 1) {}
    '''    Me.ExpandedStates.Keys.CopyTo(indexes, 0)
    '''    For Each index As String In indexes
    '''        'all indexes of child items 
    '''        If index.StartsWith(parentHierarchicalIndex + "_") OrElse index.StartsWith(parentHierarchicalIndex + ":") Then
    '''            Me.ExpandedStates.Remove(index)
    '''        End If
    '''    Next
    '''End Sub
    '''Private ReadOnly Property SelectedStates() As Hashtable
    '''    Get
    '''        If Me._selectedState Is Nothing Then
    '''            _selectedState = TryCast(Me.Session("_selectedState"), Hashtable)
    '''            If _selectedState Is Nothing Then
    '''                _selectedState = New Hashtable()
    '''                Me.Session("_selectedState") = _selectedState
    '''            End If
    '''        End If

    '''        Return Me._selectedState
    '''    End Get
    '''End Property

    Private _DataSource As DataTable = Nothing

    Private ReadOnly Property DataSource As DataTable
        Get

            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))

            If _DataSource Is Nothing Then

                _DataSource = oTrafficSchedule.GetScheduleHeader(JobNumber, JobCompNumber, Session("UserCode").ToString(), Me.IncludeCompletedSchedules,
                                                                 ClientCode, DivisionCode, ProductCode, EmpCode, AccountExecCode, TaskCode, RoleCode, CutOffDate, ManagerCode,
                                                                 Me.IncludeCompletedTasks, Me.IncludeOnlyPendingTasks, Me.ExcludeProjectedTasks, Me.CampaignCode, False, False,
                                                                 "", False, Me.OfficeCode, Me.SalesClass, Me.JobType, Me.OnlyScheduleTemplates, Me.TaskPhaseFilter).Tables(0)

            End If

            DataSource = _DataSource

        End Get
    End Property
#End Region

#Region " Page "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

        Me.DropApplyTeamType = CType(Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonApplyTeamType").FindControl("DropApplyTeamType"), Telerik.Web.UI.RadComboBox)
        Me.SetVariables()

        CheckForPredecessors()

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.RadToolbarSchedule.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

            Session("mvSingleExpandedItemIndex") = Nothing
            Session("LastExpandedIndex") = Nothing

        Else 'it is a postback

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridProjectScheduleMultiview)
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Schedule}

        Me.CheckUserRights()

        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonUpdateStatus").Attributes.Add("id", "RadToolBarButtonUpdateStatus")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonCalculate").Attributes.Add("id", "RadToolBarButtonCalculate")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonTeam").Attributes.Add("id", "RadToolBarButtonTeam")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonMarkTempComplete").Attributes.Add("id", "RadToolBarButtonMarkTempComplete")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonFindAndReplace").Attributes.Add("id", "RadToolBarButtonFindAndReplace")

        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonGantt").Attributes.Add("id", "RadToolBarButtonGantt")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonCalendar").Attributes.Add("id", "RadToolBarButtonCalendar")
        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonRiskAnalysis").Attributes.Add("id", "RadToolBarButtonRiskAnalysis")

        Me.ButtonCalculateSelected.Attributes.Add("onclick", "return confirm('All jobs associated with this job will be calculated.  Are you sure you want to Calculate Due Dates on all checked schedules?');")
        Me.ButtonCalculateAll.Attributes.Add("onclick", "return confirm('All jobs associated with this job will be calculated.  Are you sure you want to Calculate Due Dates on all listed schedules?');")
        Me.ButtonApplyTeamSelected.Attributes.Add("onclick", "return confirm('Are you sure you want to Apply Team members to all checked schedules?');")
        Me.ButtonApplyTeamAll.Attributes.Add("onclick", "return confirm('Are you sure you want to Apply Team members to all listed schedules?');")
        Me.ButtonTempCompleteSelected.Attributes.Add("onclick", "return confirm('Are you sure you want to change all tasks marked Temp Complete to Completed on on all checked schedules?');")
        Me.ButtonTempCompleteAll.Attributes.Add("onclick", "return confirm('Are you sure you want to change all tasks marked Temp Complete to Completed on on all listed schedules?');")


    End Sub

    Private Sub SetVariables()
        If Not Request.QueryString("Cli") = Nothing Then
            Me.ClientCode = Request.QueryString("Cli").ToString()
        End If
        If Not Request.QueryString("Div") = Nothing Then
            Me.DivisionCode = Request.QueryString("Div").ToString()
        End If
        If Not Request.QueryString("Prod") = Nothing Then
            Me.ProductCode = Request.QueryString("Prod").ToString()
        End If
        If Not Request.QueryString("Job") = Nothing Then
            Me.JobNumber = CType(Request.QueryString("Job").ToString(), Integer)
        End If
        If Not Request.QueryString("JobComp") = Nothing Then
            Me.JobCompNumber = CType(Request.QueryString("JobComp").ToString(), Integer)
        End If
        If Not Request.QueryString("JobType") = Nothing Then
            Me.JobType = Request.QueryString("JobType").ToString()
        End If
        If Not Request.QueryString("Mgr") = Nothing Then
            Me.ManagerCode = Request.QueryString("Mgr").ToString()
        End If
        If Not Request.QueryString("AE") = Nothing Then
            Me.AccountExecCode = Request.QueryString("AE").ToString()
        End If
        If Not Request.QueryString("CS") = Nothing Then
            Me.IncludeCompletedSchedules = CType(Request.QueryString("CS").ToString(), Boolean)
        End If
        If Not Request.QueryString("OnlyScheduleTemplates") = Nothing Then
            Me.OnlyScheduleTemplates = CType(Request.QueryString("OnlyScheduleTemplates").ToString(), Boolean)
        End If
        If Not Request.QueryString("EH") = Nothing Then
            Me.EditHeaders = CType(Request.QueryString("EH").ToString(), Boolean)
        End If
        If Not Request.QueryString("EG") = Nothing Then
            Me.EditGrids = CType(Request.QueryString("EG").ToString(), Boolean)
        End If
        If Not Request.QueryString("Emp") = Nothing Then
            Me.EmpCode = Request.QueryString("Emp").ToString()
            If Me.EmpCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Task") = Nothing Then
            Me.TaskCode = Request.QueryString("Task").ToString()
            If Me.TaskCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Role") = Nothing Then
            Me.RoleCode = Request.QueryString("Role").ToString()
            If Me.RoleCode.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Cut") = Nothing Then
            Me.CutOffDate = Request.QueryString("Cut").ToString()
            If Me.CutOffDate.Trim <> "" Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Comp") = Nothing Then
            Me.IncludeCompletedTasks = CType(Request.QueryString("Comp").ToString(), Boolean)
            If Me.IncludeCompletedTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Pend") = Nothing Then
            Me.IncludeOnlyPendingTasks = CType(Request.QueryString("Pend").ToString(), Boolean)
            If Me.IncludeOnlyPendingTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Proj") = Nothing Then
            Me.ExcludeProjectedTasks = CType(Request.QueryString("Proj").ToString(), Boolean)
            If Me.ExcludeProjectedTasks = True Then
                Me.UsingATaskLevelFilter = True
            End If
        End If
        If Not Request.QueryString("Camp") = Nothing Then
            Me.CampaignCode = Request.QueryString("Camp").ToString()
        End If
        If Not Request.QueryString("P") = Nothing Then

            Me.TaskPhaseFilter = Request.QueryString("P").ToString()

            If IsNumeric(Me.TaskPhaseFilter) Then

                Me.TaskPhaseFilter = Me.TaskPhaseFilter

            ElseIf Me.TaskPhaseFilter = "is_null" Then

                Me.TaskPhaseFilter = 0

            Else

                Me.TaskPhaseFilter = -1

            End If

        Else

            Me.TaskPhaseFilter = -1

        End If
        If Not Request.QueryString("Off") = Nothing Then
            Me.OfficeCode = Request.QueryString("Off").ToString()
        End If
        If Not Request.QueryString("SC") = Nothing Then
            Me.SalesClass = Request.QueryString("SC").ToString()
        End If
    End Sub

#End Region

    Private Sub SaveHeaderRow(ByVal ThisRow As Telerik.Web.UI.GridDataItem, ByVal ThisJobNum As Integer, ByVal ThisJobCompNum As Integer)
        'Save header:
        Dim CurrentStatusCode As String = ""
        Dim CurrentStartDate As String = ""
        Dim CurrentDueDate As String = ""
        Dim CurrentCompletedDate As String = ""
        Dim CurrentComments As String = ""
        Dim CurrentPercentComplete As String
        Dim InvalidDate As Boolean = False
        Dim ddl As Telerik.Web.UI.RadComboBox
        Dim radstartdate As RadDatePicker
        Dim radduedate As RadDatePicker
        Dim radcompleteddate As RadDatePicker
        Try
            ddl = CType(ThisRow.FindControl("DropStatus"), Telerik.Web.UI.RadComboBox)
            CurrentStatusCode = ddl.SelectedValue
        Catch ex As Exception
        End Try
        Try
            radstartdate = CType(ThisRow.FindControl("RadDatePickerSTART_DATE"), RadDatePicker)
            If MiscFN.ValidDate(radstartdate, True) = False Then
                InvalidDate = True
            Else
                If Not radstartdate.SelectedDate Is Nothing Then
                    CurrentStartDate = cGlobals.wvCDate(radstartdate.SelectedDate).ToShortDateString()
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            radduedate = CType(ThisRow.FindControl("RadDatePickerJOB_FIRST_USE_DATE"), RadDatePicker)
            If MiscFN.ValidDate(radduedate, True) = False Then
                InvalidDate = True
            Else
                If Not radduedate.SelectedDate Is Nothing Then
                    CurrentDueDate = cGlobals.wvCDate(radduedate.SelectedDate).ToShortDateString()
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            radcompleteddate = CType(ThisRow.FindControl("RadDatePickerJobCompleted"), RadDatePicker)
            If MiscFN.ValidDate(radcompleteddate, True) = False Then
                InvalidDate = True
            Else
                If Not radcompleteddate.SelectedDate Is Nothing Then
                    CurrentCompletedDate = cGlobals.wvCDate(radcompleteddate.SelectedDate).ToShortDateString()
                End If
            End If
        Catch ex As Exception
        End Try
        Try
            CurrentComments = CType(ThisRow.FindControl("TxtComments"), TextBox).Text.Trim()
        Catch ex As Exception
        End Try
        Try
            CurrentPercentComplete = CType(ThisRow.FindControl("TxtPercentComplete"), TextBox).Text.Trim()
            If CurrentPercentComplete <> "" Then
                If IsNumeric(CurrentPercentComplete) = False Then
                    InvalidDate = True
                End If
            Else
                CurrentPercentComplete = "0.00"
            End If
        Catch ex As Exception
        End Try
        Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        If InvalidDate = False Then
            'save the header for this row:
            Try
                s.UpdateMultiviewHeaders(ThisJobNum, ThisJobCompNum, CurrentStatusCode, CurrentStartDate, CurrentDueDate, CurrentCompletedDate, CurrentComments, CurrentPercentComplete)
            Catch ex As Exception
            End Try
        End If

        'update status code:
        Dim ud As New cSchedule(Session("ConnString"), Session("UserCode"))
        If ud.GetUpdateStatusDefault() = True Then

            Me.UpdateStatusCode(ThisJobNum, ThisJobCompNum)

        End If


    End Sub

    Private Function UpdateStatusCode(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As Boolean
        Try

            Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable
            Dim Updated As Boolean = False
            Dim NextStatusCode As String = ""

            dt = s.GetNextScheduleStatusCode(JobNumber, JobComponentNumber)

            If dt.Rows.Count > 0 Then

                If IsDBNull(dt.Rows(0)("NEXT_STATUS_CODE")) = False Then

                    NextStatusCode = dt.Rows(0)("NEXT_STATUS_CODE").ToString().Trim

                Else

                    NextStatusCode = ""

                End If
            End If
            If NextStatusCode <> "" Then

                If s.UpdateScheduleTrafficCode(JobNumber, JobComponentNumber, NextStatusCode) = "" Then

                    Updated = True

                End If

            End If

            Return Updated

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try
    End Function

    'difference b/t this one and the one on the single view is:
    'hidden field to maintain original due date (HfJOB_DUE_DATE)
    Private Function SaveGridRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem) As String
        'Create variables:
        Dim RowHasChange As Boolean = False

        Dim RowStatusCode As String = ""
        Dim RowPhaseCode As String = ""
        Dim RowOrder As String = ""
        Dim RowTaskCode As String = ""
        Dim RowTaskDescription As String = ""
        Dim RowDays As Integer = 0
        Dim RowStartDate As Date
        Dim RowRevisedDueDate As String = ""
        Dim RowRevisedDueDateLocked As Boolean
        Dim RowDueTime As String = ""
        Dim RowOriginalDueTime As String = ""
        Dim RowRevisedDueTime As String = ""
        Dim RowOriginalDueDate As String = ""
        Dim RowCompletedDate As Date
        Dim RowHoursAllowed As Decimal = 0

        Dim RowEmployeesString As String = ""
        Dim RowEmployeesArray() As String
        Dim UseEmployeesArray As Boolean = False

        Dim RowTask_JobNum As Integer = 0
        Dim RowTask_JobComp As Integer = 0
        Dim RowTask_SeqNum As Integer = -1

        Dim arKey() As String
        Try
            arKey = DirectCast(TheGridRow.FindControl("HfROW_KEY"), HiddenField).Value.Split("|")
        Catch ex As Exception
            Exit Function
        End Try

        Try
            RowTask_JobNum = CType(arKey(0), Integer)
        Catch ex As Exception
            RowTask_JobNum = 0
        End Try
        Try
            RowTask_JobComp = CType(arKey(1), Integer)
        Catch ex As Exception
            RowTask_JobComp = 0
        End Try
        Try
            RowTask_SeqNum = CType(arKey(2), Integer)
        Catch ex As Exception
            RowTask_SeqNum = -1
        End Try

        If RowTask_JobNum = 0 Or RowTask_JobComp = 0 Or RowTask_SeqNum = -1 Then
            Exit Function
        End If

        Dim SQLPrefix As String = "UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET "
        Dim SQLBody As StringBuilder = New StringBuilder
        Dim SQLSuffix As String = " WHERE (JOB_NUMBER = " & RowTask_JobNum & ") AND (JOB_COMPONENT_NBR = " & RowTask_JobComp & ") AND (SEQ_NBR = " & RowTask_SeqNum & ")"

        Try
            RowStatusCode = DirectCast(TheGridRow.FindControl("DdlTASK_STATUS"), Telerik.Web.UI.RadComboBox).SelectedValue
            '	JOB_TRAFFIC_DET.TASK_STATUS, 
            With SQLBody
                .Append("TASK_STATUS = ")
                .Append("'")
                .Append(RowStatusCode)
                .Append("'")
                .Append(", ")
            End With
        Catch ex As Exception
        End Try

        Try
            RowPhaseCode = DirectCast(TheGridRow.FindControl("DdlPHASE_DESC"), Telerik.Web.UI.RadComboBox).SelectedValue
            'JOB_TRAFFIC_DET.TRAFFIC_PHASE_ID
            With SQLBody
                .Append("TRAFFIC_PHASE_ID = ")
                If DirectCast(TheGridRow.FindControl("DdlPHASE_DESC"), Telerik.Web.UI.RadComboBox).SelectedIndex > 0 Then
                    '.Append("'")
                    .Append(RowPhaseCode)
                    '.Append("'")
                Else
                    .Append("NULL")
                End If
                .Append(", ")
            End With
        Catch ex As Exception
        End Try

        Try
            RowOrder = DirectCast(TheGridRow.FindControl("TxtJOB_ORDER"), TextBox).Text
            '	JOB_TRAFFIC_DET.JOB_ORDER, 
            If IsNumeric(RowOrder) = True Then
                With SQLBody
                    .Append("JOB_ORDER = ")
                    .Append(RowOrder)
                    .Append(", ")
                End With
            End If
        Catch ex As Exception
        End Try

        Dim BoolNoDescript As Boolean = False

        'New traffic function handling:
        Dim v As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim OriginalCode As String = DirectCast(TheGridRow.FindControl("HfTaskCode"), HiddenField).Value.Trim()
        Dim EnteredCode As String = DirectCast(TheGridRow.FindControl("TxtTaskCode"), TextBox).Text.Trim()
        Dim OriginalDescript As String = DirectCast(TheGridRow.FindControl("HfTASK_DESCRIPTION"), HiddenField).Value.Trim()
        Dim EnteredDescript As String = DirectCast(TheGridRow.FindControl("TxtTASK_DESCRIPTION"), TextBox).Text.Trim()

        Dim DBCode As String = ""
        Dim DBDescript As String = ""
        Dim ValidTaskCode As Boolean = True

        If EnteredCode <> "" Then
            ValidTaskCode = v.ValidateTaskCode(EnteredCode)
            DBCode = EnteredCode
            Try
                Dim sched As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                Dim dt1 As New DataTable
                dt1 = sched.GetAddNewFunctionData(EnteredCode)
                If dt1.Rows.Count > 0 Then
                    If IsDBNull(dt1.Rows(0)("TRF_DESC")) = False Then
                        DBDescript = dt1.Rows(0)("TRF_DESC").ToString().Trim()
                    End If
                End If
            Catch ex As Exception
            End Try
        End If

        If EnteredCode = "" And EnteredDescript = "" Then ' no code or description
            'skip?
            'SQLBody.Append("FNC_CODE = NULL, ")
            'SQLBody.Append("TASK_DESCRIPTION = NULL, ")
        ElseIf ValidTaskCode = True And EnteredDescript = "" Then 'has code, but no description
            'if valid code, save both the code and the code's description
            With SQLBody
                .Append("FNC_CODE = ")
                .Append("'")
                .Append(DBCode)
                .Append("'")
                .Append(", ")
                .Append("TASK_DESCRIPTION = ")
                .Append("'")
                .Append(DBDescript.Replace("'", ""))
                .Append("'")
                .Append(", ")
            End With
        ElseIf EnteredCode = "" And EnteredDescript <> "" Then 'has description but no code
            'save null to code, save descript (need to check it's not a default?)
            With SQLBody
                .Append("FNC_CODE = ")
                .Append("NULL")
                .Append(", ")
                .Append("TASK_DESCRIPTION = ")
                .Append("'")
                .Append(EnteredDescript.Replace("'", ""))
                .Append("'")
                .Append(", ")
            End With
        ElseIf ValidTaskCode = True And EnteredDescript <> "" Then  'has both code and description
            'if valid code, save both the code and the code's description
            With SQLBody
                .Append("FNC_CODE = ")
                .Append("'")
                .Append(DBCode)
                .Append("'")
                .Append(", ")
                .Append("TASK_DESCRIPTION = ")
                .Append("'")
                .Append(DBDescript.Replace("'", ""))
                .Append("'")
                .Append(", ")
            End With
        End If


        Try
            If IsNumeric(DirectCast(TheGridRow.FindControl("TxtJOB_DAYS"), TextBox).Text) Then
                RowDays = CType(DirectCast(TheGridRow.FindControl("TxtJOB_DAYS"), TextBox).Text, Integer)
                '	JOB_TRAFFIC_DET.JOB_DAYS, 
                With SQLBody
                    .Append("JOB_DAYS = ")
                    .Append(RowDays)
                    .Append(", ")
                End With
            End If
        Catch ex As Exception
        End Try

        Try
            If IsNumeric(DirectCast(TheGridRow.FindControl("TxtJOB_HRS"), TextBox).Text) Then
                RowHoursAllowed = CType(DirectCast(TheGridRow.FindControl("TxtJOB_HRS"), TextBox).Text, Decimal)
                '	JOB_TRAFFIC_DET.JOB_HRS, 
                With SQLBody
                    .Append("JOB_HRS = ")
                    .Append(RowHoursAllowed)
                    .Append(", ")
                End With
            Else
                SQLBody.Append("JOB_HRS = NULL, ")
            End If
        Catch ex As Exception
        End Try


        Try
            'JOB_TRAFFIC_DET.TASK_START_DATE
            If cGlobals.wvIsDate(DirectCast(TheGridRow.FindControl("TxtTASK_START_DATE"), TextBox).Text) Then
                RowStartDate = cGlobals.wvCDate(DirectCast(TheGridRow.FindControl("TxtTASK_START_DATE"), TextBox).Text)
                With SQLBody
                    .Append("TASK_START_DATE = ")
                    .Append("'")
                    .Append(RowStartDate)
                    .Append("'")
                    .Append(", ")
                End With
            ElseIf DirectCast(TheGridRow.FindControl("TxtTASK_START_DATE"), TextBox).Text.Trim = "" Then
                With SQLBody
                    .Append("TASK_START_DATE = ")
                    .Append("NULL")
                    .Append(", ")
                End With
            End If
        Catch ex As Exception
        End Try

        'We are going to key off this column.
        Try
            'JOB_TRAFFIC_DET.JOB_REVISED_DATE
            If cGlobals.wvIsDate(DirectCast(TheGridRow.FindControl("HfJOB_DUE_DATE"), HiddenField).Value) Then
                RowOriginalDueDate = cGlobals.wvCDate(DirectCast(TheGridRow.FindControl("HfJOB_DUE_DATE"), HiddenField).Value).ToShortDateString
            Else
                RowOriginalDueDate = ""
            End If

            If cGlobals.wvIsDate(DirectCast(TheGridRow.FindControl("TxtJOB_REVISED_DATE"), TextBox).Text) Then
                RowRevisedDueDate = cGlobals.wvCDate(DirectCast(TheGridRow.FindControl("TxtJOB_REVISED_DATE"), TextBox).Text).ToShortDateString
            Else
                RowRevisedDueDate = ""
            End If

            If RowOriginalDueDate = "" And RowRevisedDueDate = "" Then
                With SQLBody
                    .Append("JOB_REVISED_DATE = ")
                    .Append("NULL")
                    .Append(", ")
                End With
            ElseIf RowOriginalDueDate = "" And RowRevisedDueDate <> "" Then
                With SQLBody
                    .Append("JOB_REVISED_DATE = ")
                    .Append("'")
                    .Append(RowRevisedDueDate)
                    .Append("'")
                    .Append(", ")
                End With
                With SQLBody
                    .Append("JOB_DUE_DATE = ")
                    .Append("'")
                    .Append(RowRevisedDueDate)
                    .Append("'")
                    .Append(", ")
                End With
            ElseIf RowOriginalDueDate <> "" And RowRevisedDueDate = "" Then
                With SQLBody
                    .Append("JOB_DUE_DATE = ")
                    .Append("'")
                    .Append(RowOriginalDueDate)
                    .Append("'")
                    .Append(", ")
                End With
                With SQLBody
                    .Append("JOB_REVISED_DATE = ")
                    .Append("'")
                    .Append(RowOriginalDueDate)
                    .Append("'")
                    .Append(", ")
                End With
            ElseIf RowOriginalDueDate <> "" And RowRevisedDueDate <> "" Then
                With SQLBody
                    .Append("JOB_DUE_DATE = ")
                    .Append("'")
                    .Append(RowOriginalDueDate)
                    .Append("'")
                    .Append(", ")
                End With
                With SQLBody
                    .Append("JOB_REVISED_DATE = ")
                    .Append("'")
                    .Append(RowRevisedDueDate)
                    .Append("'")
                    .Append(", ")
                End With
            End If
        Catch ex As Exception
        End Try

        'Due date locked:
        Try
            RowRevisedDueDateLocked = DirectCast(TheGridRow.FindControl("ChkLocked"), CheckBox).Checked
            With SQLBody
                .Append("DUE_DATE_LOCK = ")
                If RowRevisedDueDateLocked = True Then
                    .Append("1")
                Else
                    .Append("0")
                End If
                .Append(", ")
            End With
        Catch ex As Exception
        End Try


        Try
            'JOB_TRAFFIC_DET.DUE_TIME,
            RowDueTime = DirectCast(TheGridRow.FindControl("TxtDUE_TIME"), TextBox).Text
            RowOriginalDueTime = DirectCast(TheGridRow.FindControl("HfDUE_TIME"), HiddenField).Value.Replace("&nbsp;", "")
            RowRevisedDueTime = DirectCast(TheGridRow.FindControl("HfREVISED_DUE_TIME"), HiddenField).Value.Replace("&nbsp;", "")
            If RowOriginalDueTime = "" And RowRevisedDueTime = "" Then
                If RowDueTime <> "" Then
                    'update both to RowDueTime
                    With SQLBody
                        .Append("DUE_TIME = ")
                        .Append("'")
                        .Append(RowDueTime)
                        .Append("'")
                        .Append(", ")
                        .Append("REVISED_DUE_TIME = ")
                        .Append("'")
                        .Append(RowDueTime)
                        .Append("'")
                        .Append(", ")
                    End With
                End If
            ElseIf RowOriginalDueTime <> "" And RowRevisedDueTime = "" Then
                If RowDueTime <> "" Then
                    'update revised to RowDueTime
                    With SQLBody
                        .Append("REVISED_DUE_TIME = ")
                        .Append("'")
                        .Append(RowDueTime)
                        .Append("'")
                        .Append(", ")
                    End With
                Else
                    'update revised to null
                    With SQLBody
                        .Append("REVISED_DUE_TIME = NULL")
                        .Append(", ")
                    End With
                End If
            ElseIf RowOriginalDueTime <> "" And RowRevisedDueTime <> "" Then
                If RowDueTime <> "" Then
                    'update revised to RowDueTime
                    With SQLBody
                        .Append("REVISED_DUE_TIME = ")
                        .Append("'")
                        .Append(RowDueTime)
                        .Append("'")
                        .Append(", ")
                    End With
                Else
                    'update revised to null
                    With SQLBody
                        .Append("REVISED_DUE_TIME = NULL")
                        .Append(", ")
                    End With
                End If
            End If
        Catch ex As Exception
        End Try

        Try
            'JOB_TRAFFIC_DET.JOB_COMPLETED_DATE
            If cGlobals.wvIsDate(DirectCast(TheGridRow.FindControl("TxtJOB_COMPLETED_DATE"), TextBox).Text) Then
                RowCompletedDate = cGlobals.wvCDate(DirectCast(TheGridRow.FindControl("TxtJOB_COMPLETED_DATE"), TextBox).Text)
                With SQLBody
                    .Append("JOB_COMPLETED_DATE = ")
                    .Append("'")
                    .Append(RowCompletedDate)
                    .Append("'")
                    .Append(", ")
                End With
            ElseIf DirectCast(TheGridRow.FindControl("TxtJOB_COMPLETED_DATE"), TextBox).Text = "" Then
                With SQLBody
                    .Append("JOB_COMPLETED_DATE = ")
                    .Append("NULL")
                    .Append(", ")
                End With
            End If
        Catch ex As Exception
        End Try

        'emps:
        Try
            RowEmployeesString = DirectCast(TheGridRow.FindControl("TxtEmployees"), TextBox).Text
            RowEmployeesString = MiscFN.RemoveDuplicatesFromString(RowEmployeesString, ",")
        Catch ex As Exception
        End Try

        Dim str As String = SQLBody.ToString
        str = MiscFN.RemoveTrailingDelimiter(str, ",")

        Dim FullSQLString As String = SQLPrefix & str & SQLSuffix

        'FullSQLString &= SavePredList(RowTask_JobNum, RowTask_JobComp, RowTask_SeqNum, RowPredecessorsString)

        'Compare to dataset to get changes,Validate changes:

        'Save:
        Using MyConn As New SqlConnection(Session("ConnString"))
            MyConn.Open()
            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
            Dim MyCmd As New SqlCommand(FullSQLString, MyConn, MyTrans)
            Try
                MyCmd.ExecuteNonQuery()
                MyTrans.Commit()
            Catch ex As Exception
                MyTrans.Rollback()
            Finally
                If MyConn.State = ConnectionState.Open Then MyConn.Close()
            End Try
        End Using

        'maybe make this sproc call using the above transaction and call to EXEC instead of as separate calls
        Me.SaveEmpList(RowTask_JobNum, RowTask_JobComp, RowTask_SeqNum, RowEmployeesString)

    End Function

    'Main grid:
#Region " RadGridSchedule (Main Grid)"

    Private Function SaveGrid() As Boolean
        Dim RowCount As Integer = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count
        If RowCount > 0 Then
            For i As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrentJobNumber As Integer = 0
                Try
                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                Catch ex As Exception
                    CurrentJobNumber = 0
                End Try
                Dim CurrentJobComponentNumber As Integer = 0
                Try
                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                Catch ex As Exception
                    CurrentJobComponentNumber = 0
                End Try
                Dim chk As CheckBox
                chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                If CurrentJobNumber > 0 AndAlso CurrentJobComponentNumber > 0 Then
                    ' ''Save the child grid here:
                    ''Try
                    ''    Dim gtv As Telerik.Web.UI.GridTableView
                    ''    gtv = CurrentGridRow.ChildItem.NestedTableViews(0)
                    ''    For Each dataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                    ''        If dataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or dataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                    ''            'save the task grid row:
                    ''            Me.SaveGridRow(dataItem)
                    ''        End If
                    ''    Next
                    ''Catch ex As Exception
                    ''End Try
                    SaveHeaderRow(CurrentGridRow, CurrentJobNumber, CurrentJobComponentNumber)
                    Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)

                End If
            Next
            'Me.RadGridProjectScheduleMultiview.Rebind()
        End If
    End Function

    Private Sub RadGridProjectScheduleMultiview_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjectScheduleMultiview.NeedDataSource
        Try
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Try
                If Me.JobNumber > 0 And Me.JobCompNumber > 0 Then
                    Dim x As Integer = oTrafficSchedule.CheckExistsClosed(JobNumber, JobCompNumber)
                    Select Case x
                        Case 0, -2
                            'MiscFN.ResponseRedirect("TrafficSchedule.aspx?JobNum=" & Me.txtJob.Text & "&JobComp=" & Me.txtComponent.Text)
                        Case Else
                            Me.CloseThisWindowAndOpenNewWindow(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Create?ClientCode=" & Me.ClientCode & "&DivisionCode=" & Me.DivisionCode & "&ProductCode=" & Me.ProductCode & "&JobNumber=" & JobNumber & "&JobComponentNumber=" & JobCompNumber)
                    End Select
                End If
            Catch ex As Exception
            End Try
            Dim dt As DataTable = Me.DataSource

            Me.RadGridProjectScheduleMultiview.DataSource = dt
            'If dt.Rows.Count > 0 Then
            '    Me.RadCalendarShared.Visible = True
            'Else
            '    Me.RadCalendarShared.Visible = False
            'End If
            _LoadingDatasource = True

            Try
                If dt.Rows.Count = 1 Then
                    'go directly
                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Content.aspx"
                    qs.JobNumber = CType(dt.Rows(0)("JOB_NUMBER"), Integer)
                    qs.JobComponentNumber = CType(dt.Rows(0)("JOB_COMPONENT_NBR"), Integer)
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                    Me.CloseThisWindowAndOpenNewWindow(qs.ToString(True))

                End If
            Catch ex As Exception
            End Try
            Me.RadGridProjectScheduleMultiview.CurrentPageIndex = Me.CurrentGridPageIndex
            Me.RadGridProjectScheduleMultiview.PageSize = MiscFN.LoadPageSize(Me.RadGridProjectScheduleMultiview.ID)
        Catch ex As Exception
        End Try
        _LoadingDatasource = False
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridProjectScheduleMultiview_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridProjectScheduleMultiview.PageIndexChanged
        Me.SaveGrid()
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridProjectScheduleMultiview.Rebind()
    End Sub

    Private Sub RadGridProjectScheduleMultiview_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridProjectScheduleMultiview.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridProjectScheduleMultiview.ID, e.NewPageSize)

        End If

    End Sub

    'Main grid:
    Private Sub RadGridProjectScheduleMultiview_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectScheduleMultiview.ItemDataBound

        Dim IsTemplate As Boolean = False

        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

                Dim JobNumber As Integer = dataItem.GetDataKeyValue("JOB_NUMBER")
                Dim JobComponentNbr As Integer = dataItem.GetDataKeyValue("JOB_COMPONENT_NBR")

                IsTemplate = dataItem.DataItem("IS_TEMPLATE")

                'Select all rows:
                Try
                    dataItem.Selected = True
                Catch ex As Exception
                End Try

                'Status code dropdown:
                Me.GetStatusCodes()
                Try
                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(dataItem.FindControl("DropStatus"), Telerik.Web.UI.RadComboBox)
                    With ddl
                        .DataSource = dtStatusCodes
                        .DataTextField = "CodeDescription"
                        .DataValueField = "Code"
                        .DataBind()
                    End With
                    Try
                        MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("TRF_CODE"), False)
                    Catch ex As Exception
                    End Try

                    If IsTemplate AndAlso _UserCustom1 Then

                        ddl.Enabled = False

                    End If

                Catch ex As Exception
                End Try

                'date textboxes:

                Dim rdp As Telerik.Web.UI.RadDatePicker
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerSTART_DATE"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("START_DATE")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("START_DATE")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("START_DATE"), Date)
                            End If
                        End If
                        'rdp.SharedCalendar = Me.RadCalendarShared

                        If IsTemplate AndAlso _UserCustom1 Then

                            rdp.Enabled = False

                        End If

                    End If
                Catch ex As Exception
                End Try
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerJOB_FIRST_USE_DATE"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("JOB_FIRST_USE_DATE")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("JOB_FIRST_USE_DATE")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("JOB_FIRST_USE_DATE"), Date)
                            End If
                        End If
                        'rdp.SharedCalendar = Me.RadCalendarShared

                        If IsTemplate AndAlso _UserCustom1 Then

                            rdp.Enabled = False

                        End If

                    End If
                Catch ex As Exception
                End Try
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerJobCompleted"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("JobCompleted")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("JobCompleted")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("JobCompleted"), Date)
                            End If
                        End If

                        If IsTemplate AndAlso _UserCustom1 Then

                            rdp.Enabled = False

                        End If

                        'rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try


                'delete confirm:
                'Try
                '    Dim imgbtnDelete As System.Web.UI.WebControls.ImageButton = CType(dataItem("colDelete").FindControl("ImageButton1"), ImageButton)
                '    imgbtnDelete.Attributes("onclick") = "return confirm('Are you sure you want to delete this schedule?')"
                'Catch ex As Exception
                'End Try

                Dim lb As System.Web.UI.WebControls.Label
                Try
                    lb = dataItem.FindControl("LabelCDP")
                    lb.Text = e.Item.DataItem("CL_CODE") & " / " & e.Item.DataItem("DIV_CODE") & " / " & e.Item.DataItem("PRD_CODE")
                Catch ex As Exception

                End Try

                Try
                    lb = dataItem.FindControl("LabelJC")
                    lb.Text = e.Item.DataItem("JOB_NUMBER") & " - " & e.Item.DataItem("JOB_DESC") & " / " & e.Item.DataItem("JOB_COMPONENT_NBR") & " - " & e.Item.DataItem("JOB_COMP_DESC")
                Catch ex As Exception

                End Try

                Dim key As String = JobNumber.ToString() & "|" & JobComponentNbr.ToString()

                Dim GutPercentCompleteTextbox As System.Web.UI.WebControls.TextBox = CType(dataItem.FindControl("TxtPercentComplete"), TextBox)
                If Not GutPercentCompleteTextbox Is Nothing Then

                    If Not e.Item.DataItem("GUT_PERCENT_COMPLETE") Is Nothing AndAlso IsNumeric(e.Item.DataItem("GUT_PERCENT_COMPLETE")) Then

                        GutPercentCompleteTextbox.Text = FormatNumber(e.Item.DataItem("GUT_PERCENT_COMPLETE"), 2)

                    End If

                    GutPercentCompleteTextbox.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'PERCENT_COMPLETE', this.value, '" & GutPercentCompleteTextbox.ClientID & "');")

                    If IsTemplate AndAlso _UserCustom1 Then

                        GutPercentCompleteTextbox.Enabled = False

                    End If

                End If

                Dim CommentsTextbox As System.Web.UI.WebControls.TextBox = CType(dataItem.FindControl("TxtComments"), TextBox)
                If Not CommentsTextbox Is Nothing Then

                    CommentsTextbox.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'TRF_COMMENTS', this.value, '" & CommentsTextbox.ClientID & "');")

                    If IsTemplate AndAlso _UserCustom1 Then

                        CommentsTextbox.Enabled = False

                    End If

                End If

                Dim StartDateDatePicker As Telerik.Web.UI.RadDatePicker = CType(dataItem.FindControl("RadDatePickerSTART_DATE"), Telerik.Web.UI.RadDatePicker)
                If Not StartDateDatePicker Is Nothing Then

                    StartDateDatePicker.DateInput.ClientEvents.OnValueChanged = "function(sender, args) { DataChangeScheduleHeader('" & key & "', 'START_DATE', args.get_newValue(), '" & StartDateDatePicker.DateInput.ClientID & "'); }"

                End If

                Dim DueDateDatePicker As Telerik.Web.UI.RadDatePicker = CType(dataItem.FindControl("RadDatePickerJOB_FIRST_USE_DATE"), Telerik.Web.UI.RadDatePicker)
                If Not DueDateDatePicker Is Nothing Then

                    DueDateDatePicker.DateInput.OnClientDateChanged = "function(sender, args) { DataChangeScheduleHeader('" & key & "', 'JOB_FIRST_USE_DATE', args.get_newValue(), '" & DueDateDatePicker.DateInput.ClientID & "'); }"

                End If

                Dim CompletedDateDatePicker As Telerik.Web.UI.RadDatePicker = CType(dataItem.FindControl("RadDatePickerJobCompleted"), Telerik.Web.UI.RadDatePicker)
                If Not CompletedDateDatePicker Is Nothing Then

                    CompletedDateDatePicker.DateInput.OnClientDateChanged = "function(sender, args) { DataChangeScheduleHeader('" & key & "', 'COMPLETED_DATE', args.get_newValue(), '" & CompletedDateDatePicker.DateInput.ClientID & "'); }"

                End If


            End If

        Catch ex As Exception

        End Try

    End Sub

    '''For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridProjectScheduleMultiview.MasterTableView.Items
    '''    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
    '''    If chk.Checked Then
    '''    End If
    '''Next

    Private Sub RadGridProjectScheduleMultiview_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProjectScheduleMultiview.ItemCommand
        Try

            If e.Item Is Nothing Then Exit Sub

            Dim index As Integer = 0
            If Not e.Item Is Nothing Then
                index = e.Item.ItemIndex
            Else
                Exit Sub
            End If
            If index = -1 Then 'command item
                MiscFN.SavePageSize(Me.RadGridProjectScheduleMultiview.ID, Me.RadGridProjectScheduleMultiview.PageSize)
                Exit Sub
            End If
            If index >= 0 Then
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.Items(index), Telerik.Web.UI.GridDataItem)
                Dim ThisJobNumber As Integer = CurrentGridRow.GetDataKeyValue("JOB_NUMBER")
                Dim ThisJobCompNumber As Integer = CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")

                Dim TaskJobNumber As Integer = 0
                Dim TaskJobCompNumber As Integer = 0
                Dim TaskSEQ As Integer = -1
                Dim StrKey As String = ""
                Dim ar() As String

                Select Case e.CommandName
                    Case Telerik.Web.UI.RadGrid.ExpandCollapseCommandName
                        'reset when expand/collapse
                        Me.ThisClient = ""
                        Me.ThisDivision = ""
                        Me.ThisProduct = ""
                        Try
                            'For loop makes sure only one item is expanded.
                            For Each thisItem As Telerik.Web.UI.GridItem In e.Item.OwnerTableView.Items
                                If thisItem.Expanded = True And thisItem.ItemIndex <> e.Item.ItemIndex Then
                                    'if the row is expanded and not the clicked row, collapse
                                    thisItem.Expanded = False
                                ElseIf thisItem.Expanded = True And thisItem.ItemIndex = e.Item.ItemIndex Then 'you've just collapsed the row by clicking the collapse button
                                    Session("mvSingleExpandedItemIndex") = Nothing
                                    'save on collapse:
                                    Try
                                        ThisJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                    Catch ex As Exception
                                        ThisJobNumber = 0
                                    End Try
                                    Try
                                        ThisJobCompNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                    Catch ex As Exception
                                        ThisJobCompNumber = 0
                                    End Try
                                    If ThisJobNumber > 0 And ThisJobCompNumber > 0 Then
                                        SaveHeaderRow(CurrentGridRow, ThisJobNumber, ThisJobCompNumber)
                                        'Save the child grid here:
                                        Try
                                            Dim gtv As Telerik.Web.UI.GridTableView
                                            gtv = CurrentGridRow.ChildItem.NestedTableViews(0)
                                            For Each dataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                                                If dataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or dataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                                    'save the task grid row:
                                                    Me.SaveGridRow(dataItem)
                                                End If
                                            Next
                                        Catch ex As Exception
                                        End Try
                                    End If
                                ElseIf thisItem.Expanded = False And thisItem.ItemIndex = e.Item.ItemIndex Then
                                    If Not Session("mvSingleExpandedItemIndex") = Nothing Then
                                        If IsNumeric(Session("mvSingleExpandedItemIndex")) = True Then
                                            Session("LastExpandedIndex") = CType(Session("mvSingleExpandedItemIndex"), Integer).ToString
                                        Else
                                            Session("LastExpandedIndex") = Nothing
                                        End If
                                    Else
                                        Session("LastExpandedIndex") = Nothing
                                    End If
                                    Session("mvSingleExpandedItemIndex") = e.Item.ItemIndexHierarchical.ToString()
                                End If
                            Next
                            'save last expanded row:
                            Dim LastExpandedIndex As Integer = -1
                            If Not Session("LastExpandedIndex") = Nothing Then
                                If IsNumeric(Session("LastExpandedIndex")) = True Then
                                    LastExpandedIndex = CType(Session("LastExpandedIndex"), Integer)
                                End If
                            End If
                            If LastExpandedIndex > -1 Then
                                CurrentGridRow = DirectCast(RadGridProjectScheduleMultiview.Items(LastExpandedIndex), Telerik.Web.UI.GridDataItem)
                                'save last expanded row:
                                Try
                                    ThisJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    ThisJobNumber = 0
                                End Try
                                Try
                                    ThisJobCompNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    ThisJobCompNumber = 0
                                End Try
                                If ThisJobNumber > 0 And ThisJobCompNumber > 0 Then
                                    'Save the child grid here:
                                    Try
                                        Dim gtv As Telerik.Web.UI.GridTableView
                                        gtv = CurrentGridRow.ChildItem.NestedTableViews(0)
                                        For Each dataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                                            If dataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or dataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                                                'save the task grid row:
                                                Me.SaveGridRow(dataItem)
                                            End If
                                        Next
                                    Catch ex As Exception
                                    End Try
                                    SaveHeaderRow(CurrentGridRow, ThisJobNumber, ThisJobCompNumber)
                                End If
                            End If

                        Catch ex As Exception

                        End Try

                    Case "SingleView"
                        Dim RedirectURL As String = ""
                        Dim sbQueryString As New System.Text.StringBuilder

                        Dim qs As New AdvantageFramework.Web.QueryString

                        qs.Page = "Content.aspx"
                        qs.JobNumber = ThisJobNumber
                        qs.JobComponentNumber = ThisJobCompNumber

                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                        If Not Request.QueryString("Emp") = Nothing Then
                            qs.Add("Emp", Request.QueryString("Emp").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Emp=")
                            'sbQueryString.Append(Request.QueryString("Emp").ToString())
                        End If
                        If Not Request.QueryString("Task") = Nothing Then
                            qs.Add("Task", Request.QueryString("Task").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Task=")
                            'sbQueryString.Append(Request.QueryString("Task").ToString())
                        End If
                        If Not Request.QueryString("Role") = Nothing Then
                            qs.Add("Role", Request.QueryString("Role").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Role=")
                            'sbQueryString.Append(Request.QueryString("Role").ToString())
                        End If
                        If Not Request.QueryString("Cut") = Nothing Then
                            qs.Add("Cut", Request.QueryString("Cut").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Cut=")
                            'sbQueryString.Append(Request.QueryString("Cut").ToString())
                        End If
                        If Not Request.QueryString("Comp") = Nothing Then
                            qs.Add("Comp", Request.QueryString("Comp").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Comp=")
                            'sbQueryString.Append(Request.QueryString("Comp").ToString())
                        End If
                        If Not Request.QueryString("Pend") = Nothing Then
                            qs.Add("Pend", Request.QueryString("Pend").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Pend=")
                            'sbQueryString.Append(Request.QueryString("Pend").ToString())
                        End If
                        If Not Request.QueryString("Proj") = Nothing Then
                            qs.Add("Proj", Request.QueryString("Proj").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("Proj=")
                            'sbQueryString.Append(Request.QueryString("Proj").ToString())
                        End If
                        If Not Request.QueryString("P") = Nothing Then
                            qs.Add("P", Request.QueryString("P").ToString())
                            'sbQueryString.Append("&")
                            'sbQueryString.Append("P=")
                            'sbQueryString.Append(Request.QueryString("P").ToString())
                            'sbQueryString.Append("&")
                        End If

                        'RedirectURL = "Content.aspx?R=1&JobNum=" & ThisJobNumber & "&JobComp=" & ThisJobCompNumber & sbQueryString.ToString
                        'Me.OpenWindow("Project Schedule - Single View", RedirectURL)
                        Me.OpenWindow("Project Schedule - Single View", qs.ToString(True))

                        'MiscFN.ResponseRedirect("TrafficSchedule.aspx?R=1&JobNum=" & ThisJobNumber & "&JobComp=" & ThisJobCompNumber)
                    Case "DeleteSchedule"
                        Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                        'Dim chk As CheckBox
                        Dim str As String = ""
                        str = s.DeleteEntireSchedule(ThisJobNumber, ThisJobCompNumber)
                        Me.RadGridProjectScheduleMultiview.Rebind()
                    Case "DeleteRow"
                        StrKey = e.CommandArgument
                        Try
                            ar = StrKey.Split("|")
                        Catch ex As Exception
                        End Try
                        Try
                            TaskJobNumber = CType(ar(0), Integer)
                        Catch ex As Exception
                            TaskJobNumber = 0
                        End Try
                        Try
                            TaskJobCompNumber = CType(ar(1), Integer)
                        Catch ex As Exception
                            TaskJobCompNumber = 0
                        End Try
                        Try
                            TaskSEQ = CType(ar(2), Integer)
                        Catch ex As Exception
                            TaskSEQ = -1
                        End Try
                        If TaskJobNumber > 0 And TaskJobCompNumber > 0 And TaskSEQ >= 0 Then
                            Try
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                If TaskJobNumber > 0 And TaskJobCompNumber > 0 And TaskSEQ >= 0 Then
                                    s.DeleteTask(TaskJobNumber, TaskJobCompNumber, TaskSEQ)
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                        Me.RadGridProjectScheduleMultiview.Rebind()
                    Case "SetEmployees"
                        StrKey = e.CommandArgument
                        Try
                            ar = StrKey.Split("|")
                        Catch ex As Exception
                        End Try
                        Try
                            TaskJobNumber = CType(ar(0), Integer)
                        Catch ex As Exception
                            TaskJobNumber = 0
                        End Try
                        Try
                            TaskJobCompNumber = CType(ar(1), Integer)
                        Catch ex As Exception
                            TaskJobCompNumber = 0
                        End Try
                        Try
                            TaskSEQ = CType(ar(2), Integer)
                        Catch ex As Exception
                            TaskSEQ = -1
                        End Try
                        If TaskJobNumber > 0 And TaskJobCompNumber > 0 And TaskSEQ >= 0 Then
                            Try
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                If TaskJobNumber > 0 And TaskJobCompNumber > 0 And TaskSEQ >= 0 Then

                                End If
                            Catch ex As Exception
                            End Try
                        End If
                        Me.RadGridProjectScheduleMultiview.Rebind()
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private ThisClient As String = ""
    Private ThisDivision As String = ""
    Private ThisProduct As String = ""

#End Region

#Region " Detail Grid "

#End Region

    'Task grid:
#Region " RadGridTasks (Child Grids)"

    Private RowIncrement As Integer = 0
    Private CurrentDetailRowIsLocked As Boolean = False
    Private DateToday As Date = Today()
    Private RowCount As Integer = 0
    'Public Sub RadGridTasks_ItemDataBound1(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs)
    '    If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
    '        'Set GridDataItem
    '        Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

    '        Dim ThisRow_SeqNum As Integer
    '        Try
    '            ThisRow_SeqNum = CType(dataItem.OwnerTableView.DataKeyValues(dataItem.ItemIndex)("SEQ_NBR"), Integer)
    '        Catch ex As Exception
    '            ThisRow_SeqNum = -1
    '        End Try
    '        Dim JobNum As Integer = 0
    '        Dim JobComp As Integer = 0
    '        Try
    '            JobNum = CType(e.Item.DataItem("JOB_NUMBER"), Integer)
    '        Catch ex As Exception
    '            JobNum = 0
    '        End Try
    '        Try
    '            JobComp = CType(e.Item.DataItem("JOB_COMPONENT_NBR"), Integer)
    '        Catch ex As Exception
    '            JobComp = 0
    '        End Try
    '        'If row has a valid task detail, work with it
    '        If JobNum > 0 And JobComp > 0 And ThisRow_SeqNum > -1 Then

    '            'Set textbox
    '            If CType(dataItem.FindControl("HfLocked"), HiddenField).Value = "1" Then
    '                CurrentDetailRowIsLocked = True
    '            Else
    '                CurrentDetailRowIsLocked = False
    '            End If
    '            CType(dataItem.FindControl("TxtTASK_START_DATE"), TextBox).Enabled = CurrentDetailRowIsLocked
    '            CType(dataItem.FindControl("TxtJOB_REVISED_DATE"), TextBox).Enabled = CurrentDetailRowIsLocked
    '            CType(dataItem.FindControl("ChkLocked"), CheckBox).Checked = CurrentDetailRowIsLocked

    '            'Employees list and link
    '            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
    '            Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(JobNum, JobComp, ThisRow_SeqNum)
    '            If strEmps.Length > 0 Then
    '                CType(dataItem.FindControl("ImgBtnEmployees"), ImageButton).ToolTip = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(strEmps.Trim, ","), ",")
    '                CType(dataItem.FindControl("TxtEmployees"), TextBox).Text = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(strEmps.Trim, ","), ",")
    '            End If

    '            'Phase DropDownList
    '            GetPhaseDT()
    '            Try
    '                Dim ddl As Telerik.Web.UI.RadComboBox = CType(dataItem.FindControl("DdlPHASE_DESC"), Telerik.Web.UI.RadComboBox)
    '                With ddl
    '                    .DataSource = dtPhases
    '                    .DataTextField = "Description"
    '                    .DataValueField = "Code"
    '                    .DataBind()
    '                End With
    '                Try
    '                    MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("PHASE_DESC"), True)
    '                Catch ex As Exception
    '                End Try
    '            Catch ex As Exception
    '            End Try

    '            'Task Code DropDownList
    '            GetTrafficScheduleTaskCodes()
    '            Try
    '                Dim ddl As Telerik.Web.UI.RadComboBox = CType(dataItem.FindControl("DdlTASK_CODE"), Telerik.Web.UI.RadComboBox)
    '                With ddl
    '                    .DataSource = dtTrafficScheduleTaskCodes
    '                    .DataTextField = "code"
    '                    .DataValueField = "codedescription"
    '                    .DataBind()
    '                    .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
    '                End With
    '                Try
    '                    MiscFN.RadComboBoxSetIndex(ddl, e.Item.DataItem("TASK_CODE"), True, True)
    '                Catch ex As Exception
    '                End Try
    '            Catch ex As Exception
    '            End Try

    '            'Set due date color
    '            ''Try
    '            ''    Dim ThisDueDate As Date
    '            ''    Dim HasCompletedDate As Boolean = False
    '            ''    If cGlobals.wvIsDate(dataItem.DataItem("JOB_REVISED_DATE")) = True Then
    '            ''        ThisDueDate = cGlobals.wvCDate(dataItem.DataItem("JOB_REVISED_DATE"))
    '            ''        Dim tb As System.Web.UI.WebControls.TextBox = CType(dataItem.FindControl("TxtJOB_REVISED_DATE"), TextBox)
    '            ''        If cGlobals.wvIsDate(dataItem.DataItem("JOB_COMPLETED_DATE")) = False Then

    '            ''            If ThisDueDate = Today() Or (ThisDueDate > Today() And ThisDueDate < Today.AddDays(8)) Then
    '            ''                tb.CssClass = "NoBorderTextBoxSuperSmall standard-yellow"
    '            ''                tb.ToolTip = "Task is due in a week!"
    '            ''            ElseIf ThisDueDate < Today Then
    '            ''                tb.CssClass = "NoBorderTextBoxSuperSmall standard-red"
    '            ''                tb.ToolTip = "Task is overdue!"
    '            ''            End If
    '            ''            If MiscFN.IsWeekendDay(ThisDueDate) = True Then
    '            ''                tb.CssClass = "NoBorderTextBoxSuperSmall standard-light-grey"
    '            ''                tb.ToolTip = "Due date is on a weekend!"
    '            ''            End If
    '            ''        End If
    '            ''    End If
    '            ''Catch ex As Exception
    '            ''End Try
    '            Try
    '                Dim ThisDueDate As Date
    '                Dim HasCompletedDate As Boolean = cGlobals.wvIsDate(dataItem.DataItem("JOB_COMPLETED_DATE"))
    '                Dim tb As System.Web.UI.WebControls.TextBox = CType(dataItem.FindControl("TxtJOB_REVISED_DATE"), TextBox)
    '                If cGlobals.wvIsDate(dataItem.DataItem("JOB_REVISED_DATE")) = True And HasCompletedDate = False Then
    '                    ThisDueDate = cGlobals.wvCDate(dataItem.DataItem("JOB_REVISED_DATE"))
    '                    tb.Text = ThisDueDate.ToShortDateString.Trim()
    '                    If (ThisDueDate > Today() And ThisDueDate < Today.AddDays(8)) Then
    '                        tb.CssClass = "NoBorderTextBoxSuperSmall standard-yellow"
    '                        tb.ToolTip = "Task is due this week!"
    '                    End If
    '                    If MiscFN.IsWeekendDay(ThisDueDate) = True Then
    '                        tb.CssClass = "NoBorderTextBoxSuperSmall standard-light-grey"
    '                        tb.ToolTip = "Due date is on a weekend!"
    '                    End If
    '                    If ThisDueDate = Today() Then
    '                        tb.CssClass = "NoBorderTextBoxSuperSmall standard-orange"
    '                        tb.ToolTip = "Task is due today!"
    '                    End If
    '                    If ThisDueDate < Today Then
    '                        tb.CssClass = "NoBorderTextBoxSuperSmall standard-red"
    '                        tb.ToolTip = "Task is overdue!"
    '                    End If
    '                End If
    '                If cGlobals.wvIsDate(dataItem.DataItem("JOB_REVISED_DATE")) = True Then
    '                    ThisDueDate = cGlobals.wvCDate(dataItem.DataItem("JOB_REVISED_DATE"))
    '                    tb.Text = ThisDueDate.ToShortDateString.Trim()
    '                End If
    '            Catch ex As Exception
    '            End Try

    '            'delete confirm:
    '            Dim imgbtnDelete As System.Web.UI.WebControls.ImageButton = CType(dataItem("colDelete").FindControl("imgbtnDelete"), ImageButton)
    '            imgbtnDelete.Attributes("onclick") = "return confirm('Are you sure you want to delete this row?')"

    '            'calendar links for date textboxes:
    '            Dim datetb As System.Web.UI.WebControls.TextBox
    '            Try
    '                datetb = CType(dataItem("colTASK_START_DATE").FindControl("TxtTASK_START_DATE"), TextBox)
    '                MiscFN.AddCalendarToTB(datetb)
    '            Catch ex As Exception
    '            End Try
    '            Try
    '                datetb = CType(dataItem("colJOB_REVISED_DATE").FindControl("TxtJOB_REVISED_DATE"), TextBox)
    '                MiscFN.AddCalendarToTB(datetb)
    '            Catch ex As Exception
    '            End Try
    '            Try
    '                datetb = CType(dataItem("colJOB_COMPLETED_DATE").FindControl("TxtJOB_COMPLETED_DATE"), TextBox)
    '                MiscFN.AddCalendarToTB(datetb)
    '            Catch ex As Exception
    '            End Try
    '        End If 'job is loaded
    '    End If 'in a datarow
    'End Sub

    '''Public Sub RadGridTasks_ItemCommand1(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
    '''    Dim index As Integer = e.Item.ItemIndex
    '''    Dim JobNum As Integer = 0
    '''    Dim JobComp As Integer = 0
    '''    Try
    '''        JobNum = CType(e.Item.DataItem("JOB_NUMBER"), Integer)
    '''    Catch ex As Exception
    '''        JobNum = 0
    '''    End Try
    '''    Try
    '''        JobComp = CType(e.Item.DataItem("JOB_COMPONENT_NBR"), Integer)
    '''    Catch ex As Exception
    '''        JobComp = 0
    '''    End Try

    '''    Dim ThisRow_SeqNum As Integer = 0
    '''    Try
    '''        ThisRow_SeqNum = CType(e.CommandArgument, Integer)
    '''    Catch ex As Exception
    '''        ThisRow_SeqNum = -1
    '''    End Try
    '''    If JobNum > 0 And JobComp > 0 And ThisRow_SeqNum > -1 Then
    '''        Select Case e.CommandName
    '''            Case "SetEmployees"
    '''                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.Items(index), Telerik.Web.UI.GridDataItem)
    '''                Dim ThisTaskCode As String = ""
    '''                Dim ThisStartDate As String = ""
    '''                Dim ThisDueDate As String = ""
    '''                Try
    '''                    Me.SaveGridRow(index, JobNum, JobComp, ThisRow_SeqNum, CurrentGridRow)
    '''                Catch ex As Exception
    '''                End Try
    '''                Try
    '''                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(CurrentGridRow.FindControl("DdlTASK_CODE"), Telerik.Web.UI.RadComboBox)
    '''                    If ddl.SelectedIndex > 0 Then
    '''                        Dim ar() As String
    '''                        ar = ddl.SelectedValue.Split("|")
    '''                        ThisTaskCode = ar(0)
    '''                    End If
    '''                Catch ex As Exception
    '''                    ThisTaskCode = ""
    '''                End Try
    '''                ''Try
    '''                ''    ThisTaskCode = e.Item.DataItem("TASK_CODE").ToString().Replace("&nbsp;", "")
    '''                ''Catch ex As Exception
    '''                ''    ThisTaskCode = ""
    '''                ''End Try
    '''                With Me.RadWindowManagerScheduler.Windows(0)
    '''                    .NavigateUrl = "TrafficSchedule_TaskEmployees.aspx?JobNum=" & JobNum & "&JobComp=" & JobComp & "&SeqNum=" & ThisRow_SeqNum & "&TaskCode=" & ThisTaskCode
    '''                    .Title = "Employee Assignments"
    '''                    .Modal = True
    '''                    .Top = New Unit(0, UnitType.Pixel)
    '''                    .Height = New Unit(595, UnitType.Pixel)
    '''                    .Width = New Unit(650, UnitType.Pixel)
    '''                    .InitialBehavior = WindowBehaviors.Close
    '''                    .ReloadOnShow = False
    '''                    .Behavior = WindowBehaviors.Close
    '''                    .Skin = MiscFN.SetRadWindowSkin
    '''                    .VisibleOnPageLoad = True
    '''                    .VisibleStatusbar = False
    '''                    .EnableViewState = True
    '''                    .DestroyOnClose = True
    '''                    .ID = "SetEmployeesWindow"
    '''                    .VisibleTitlebar = True
    '''                End With
    '''            Case "SetClientContacts"
    '''                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.Items(index), Telerik.Web.UI.GridDataItem)
    '''                Dim ThisTaskCode As String = ""
    '''                Dim ThisStartDate As String = ""
    '''                Dim ThisDueDate As String = ""
    '''                Try
    '''                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(CurrentGridRow.FindControl("DdlTASK_CODE"), Telerik.Web.UI.RadComboBox)
    '''                    If ddl.SelectedIndex > 0 Then
    '''                        Dim ar() As String
    '''                        ar = ddl.SelectedValue.Split("|")
    '''                        ThisTaskCode = ar(0)
    '''                    End If
    '''                Catch ex As Exception
    '''                    ThisTaskCode = ""
    '''                End Try
    '''                Try
    '''                    Me.SaveGridRow(index, JobNum, JobComp, ThisRow_SeqNum, CurrentGridRow)
    '''                Catch ex As Exception
    '''                End Try
    '''                With Me.RadWindowManagerScheduler.Windows(0)
    '''                    .NavigateUrl = "TrafficSchedule_TaskContacts.aspx?JobNum=" & JobNum & "&JobComp=" & JobComp & "&SeqNum=" & ThisRow_SeqNum & "&TaskCode=" & ThisTaskCode
    '''                    .Title = "Client Contacts"
    '''                    .Modal = True
    '''                    .Top = New Unit(0, UnitType.Pixel)
    '''                    .Height = New Unit(595, UnitType.Pixel)
    '''                    .Width = New Unit(400, UnitType.Pixel)
    '''                    .InitialBehavior = WindowBehaviors.Close
    '''                    .ReloadOnShow = False
    '''                    .Behavior = WindowBehaviors.Close
    '''                    .Skin = MiscFN.SetRadWindowSkin
    '''                    .VisibleOnPageLoad = True
    '''                    .VisibleStatusbar = False
    '''                    .EnableViewState = True
    '''                    .DestroyOnClose = True
    '''                    .ID = "SetEmployeesWindow"
    '''                    .VisibleTitlebar = True
    '''                End With
    '''            Case "SetPredecessors"
    '''                With Me.RadWindowManagerScheduler.Windows(0)
    '''                    .NavigateUrl = "TrafficSchedule_TaskPredecessors.aspx"
    '''                    .Title = "Set Task Predecessors"
    '''                    .Modal = True
    '''                    .Top = New Unit(0, UnitType.Pixel)
    '''                    .Height = New Unit(500, UnitType.Pixel)
    '''                    .Width = New Unit(400, UnitType.Pixel)
    '''                    .InitialBehavior = WindowBehaviors.Close '
    '''                    .ReloadOnShow = False
    '''                    .Behavior = WindowBehaviors.Close
    '''                    .Skin = MiscFN.SetRadWindowSkin
    '''                    .VisibleOnPageLoad = True
    '''                    .VisibleStatusbar = False
    '''                    .EnableViewState = True
    '''                    .DestroyOnClose = True
    '''                    .ID = "SetPredecessorsWindow"
    '''                    .VisibleTitlebar = True
    '''                End With
    '''            Case "ShowComments"
    '''                'Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.Items(index), Telerik.Web.UI.GridDataItem)
    '''                'Dim HeaderText As String '= CType(CurrentGridRow("").FindControl(""), TextBox).Text
    '''                'HeaderText = CurrentGridRow.DataItem("TASK_DESCRIPTION")
    '''                With Me.RadWindowManagerScheduler.Windows(0)
    '''                    .NavigateUrl = "TrafficSchedule_TaskComments.aspx?JobNum=" & JobNum & "&JobComp=" & JobComp & "&SeqNum=" & ThisRow_SeqNum
    '''                    .Title = "Set Task Comments " '& HeaderText
    '''                    .Modal = True
    '''                    .Top = New Unit(0, UnitType.Pixel)
    '''                    .Height = New Unit(375, UnitType.Pixel)
    '''                    .Width = New Unit(500, UnitType.Pixel)
    '''                    .InitialBehavior = WindowBehaviors.Close
    '''                    .ReloadOnShow = False
    '''                    .Behavior = WindowBehaviors.Close
    '''                    .Skin = MiscFN.SetRadWindowSkin
    '''                    .VisibleOnPageLoad = True
    '''                    .VisibleStatusbar = False
    '''                    .EnableViewState = True
    '''                    .DestroyOnClose = True
    '''                    .ID = "SetCommentsWindow"
    '''                    .VisibleTitlebar = True
    '''                End With

    '''            Case "SetDueDateLock"
    '''                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
    '''                s.UpdateTaskRowLock(JobNum, JobComp, ThisRow_SeqNum)
    '''                Me.Session("_ds") = Nothing
    '''                Me.RadGridProjectScheduleMultiview.Rebind()
    '''            Case "SaveRow"
    '''                ''Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.Items(index), Telerik.Web.UI.GridDataItem)
    '''                ''SaveGridRow(index, JobNum, JobComp, ThisRow_SeqNum, CurrentGridRow, True)
    '''            Case "DeleteRow"
    '''                ''DeleteGridRow(JobNum, JobComp, ThisRow_SeqNum)
    '''                ''RefreshGrid()
    '''            Case "EditRow"
    '''                With Me.RadWindowManagerScheduler.Windows(0)
    '''                    .NavigateUrl = "TrafficSchedule_TaskDetailWS.aspx?JobNum=" & JobNum & "&JobComp=" & JobComp & "&SeqNum=" & ThisRow_SeqNum
    '''                    .Title = "Edit Task"
    '''                    .Modal = True
    '''                    .Top = New Unit(0, UnitType.Pixel)
    '''                    .Height = New Unit(590, UnitType.Pixel)
    '''                    .Width = New Unit(845, UnitType.Pixel)
    '''                    .InitialBehavior = WindowBehaviors.None
    '''                    .ReloadOnShow = True
    '''                    .Behavior = WindowBehaviors.None
    '''                    .Skin = MiscFN.SetRadWindowSkin
    '''                    .VisibleOnPageLoad = True
    '''                    .VisibleStatusbar = False
    '''                End With
    '''            Case "MoveUp"
    '''                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
    '''                s.MoveTask(JobNum, JobComp, ThisRow_SeqNum, True)
    '''                Me.RefreshGrid()
    '''            Case "MoveDown"
    '''                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
    '''                s.MoveTask(JobNum, JobComp, ThisRow_SeqNum, False)
    '''                Me.RefreshGrid()
    '''        End Select
    '''    End If

    '''End Sub


#End Region

    'Task grid functions:
#Region " RadGridTasks functions "


    Private Function SaveEmpList(ByVal Task_JobNum As Integer, ByVal Task_JobComp As Integer, ByVal Task_SeqNum As Integer, ByVal The_EmpList As String) As DataTable
        Try
            Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Return s.UpdateTaskEmployeeListFromString(Task_JobNum, Task_JobComp, Task_SeqNum, The_EmpList)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

#End Region

    'Datatables:
#Region " Data "

    Private dtTrafficScheduleTaskCodes As New DataTable
    Private Sub GetTrafficScheduleTaskCodes()
        If dtTrafficScheduleTaskCodes.Rows.Count = 0 Then
            Dim d As New cDropDowns(Session("ConnString"))
            dtTrafficScheduleTaskCodes = d.GetTrafficScheduleCodes
        End If
    End Sub

    Private dtStatusCodes As New DataTable
    Private Sub GetStatusCodes()
        If dtStatusCodes.Rows.Count = 0 Then
            Dim d As New cDropDowns(Session("ConnString"))
            dtStatusCodes = d.GetTrafficStatusCodes()
        End If
    End Sub

    Private dtPhases As New DataTable
    Private Sub GetPhaseDT()
        If dtPhases.Rows.Count = 0 Then
            Dim d As New cDropDowns(Session("ConnString"))
            dtPhases = d.GetTrafficPhasesAll
        End If
    End Sub

#End Region

    'Print stuff copied from ws view:
    Private Function OutputReportFile(ByVal job As String, ByVal comp As String) As String
        Dim StrFileName As String = ""
        'Dim StrImagePath As String = Request.PhysicalApplicationPath & "\Images\logo_print.gif"
        Dim r As cReports = New cReports(Session("ConnString"))
        Dim StrFilePrefix As String = Request.PhysicalApplicationPath.Trim & "TEMP\"
        Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
        Dim StrFileType As String = ".PDF"
        StrFileName = "Project_Schedule_" & job & "_" & comp & StrFileDate & StrFileType

        Dim rpt As New popReportViewer
        Try
            Dim ThisOptions As String = job & "|" & comp
            rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
        Catch ex As Exception
            StrFileName = ""
        End Try
        Return StrFileName
    End Function

    Private Sub DropSort_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropSort.SelectedIndexChanged
        Me.RadGridProjectScheduleMultiview.Rebind()
    End Sub

    Private Sub DropPhaseFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropPhaseFilter.SelectedIndexChanged
        Me.RadGridProjectScheduleMultiview.Rebind()
    End Sub

    Private Sub RadToolbarSchedule_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSchedule.ButtonClick
        RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count
        Select Case e.Item.Value
            Case "ViewSingle"
                Me.CloseThisWindowAndOpenNewWindow("TrafficSchedule_Search.aspx?t=0")
                'MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx?t=0")
            Case "Search"
                Me.CloseThisWindowAndOpenNewWindow("TrafficSchedule_Search.aspx?t=1")
                'MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx?t=1")
            Case "ViewMulti"
                Me.CloseThisWindowAndOpenNewWindow("TrafficSchedule_Search.aspx?t=1")
                'MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx?t=1")
            Case "ViewWorksheet"
                Me.CloseThisWindowAndOpenNewWindow("TrafficSchedule_Search.aspx?t=2")
                'MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx?t=2")
            Case "Refresh"
                Me.RadGridProjectScheduleMultiview.Rebind()
            Case "ExpandAll"
                Me.RadGridProjectScheduleMultiview.Rebind()
            Case "SaveAll"

                Me.SaveGrid()
                Me.RadGridProjectScheduleMultiview.Rebind()

            Case "Print"
                'Dim RowCount As Integer = Me.RadGrid1.MasterTableView.Items.Count
                Dim count As Integer
                Dim jobcompids As String
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                count += 1
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    jobcompids &= CurrentJobNumber & "/" & CurrentJobComponentNumber & ","
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Session("TSWorksheetJobCompIDS") = jobcompids
                End If
                Dim filename As String
                ''Dim outputStream As New System.IO.MemoryStream
                ''Dim zipOutStream As New ZipOutputStream(outputStream)
                Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
                ''zipOutStream.SetLevel(5) ' Medium compression
                Select Case count
                    Case 0
                        Me.ShowMessage("No file(s) selected.")
                    Case 1
                        Dim jc() As String = jobcompids.Split("/")
                        Dim j As String = jc(0)
                        Dim c As String = MiscFN.RemoveTrailingDelimiter(jc(1), ",")

                        Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
                        oAppVars.getAllAppVars()
                        Dim s As String = ""
                        s = oAppVars.getAppVar("Location")

                        Dim ar() As String
                        Try
                            If s = "[None]" Then
                                Session("PSLogoLocation") = ""
                                Session("PSLogoLocationID") = "None"
                            Else
                                ar = s.ToString.Split("|")
                                Session("PSLogoLocation") = ar(1)
                                Session("PSLogoLocationID") = ar(0)
                            End If

                        Catch ex As Exception
                            Session("PSLogoLocation") = ""
                        End Try

                        Dim strURL As String = "popReportViewer.aspx?job=" & j & "&jobcomp=" & c & "&ms=False&Type=1&Report=TrafficDetailByJob"
                        Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                        strBuilder.Append("<script language='javascript'>")
                        strBuilder.Append("window.open('" & strURL & "', '', 'screenX=150,left=150,screenY=150,top=150,width=1,height=1,scrollbars=yes,resizable=no,menubar=no,maximazable=no')")
                        strBuilder.Append("</")
                        strBuilder.Append("script>")
                        Page.RegisterStartupScript("newpage", strBuilder.ToString())
                    Case Is > 1
                        Try
                            Dim outputStream As New System.IO.MemoryStream
                            Dim strfiles As String

                            Dim oAppVars As New cAppVars(cAppVars.Application.SCHEDULE_PRINT, Session("UserCode"))
                            oAppVars.getAllAppVars()
                            Dim s As String = ""
                            s = oAppVars.getAppVar("Location")

                            Dim ar() As String
                            Try
                                If s = "[None]" Then
                                    Session("PSLogoLocation") = ""
                                    Session("PSLogoLocationID") = "None"
                                Else
                                    ar = s.ToString.Split("|")
                                    Session("PSLogoLocation") = ar(1)
                                    Session("PSLogoLocationID") = ar(0)
                                End If

                            Catch ex As Exception
                                Session("PSLogoLocation") = ""
                            End Try

                            'Dim zipOutStream As New ZipOutputStream(outputStream)
                            'zipOutStream.SetLevel(5) ' Medium compression

                            'Dim RepositorySecuritySettings As New vDocumentRepositorySettings(Session("ConnString"))
                            'RepositorySecuritySettings.LoadAll()
                            'Dim ThisUserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
                            'Dim ThisUserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

                            'Dim ThisUserPassword As String = AdvantageFramework.StringUtilities.RijndaelSimpleDecrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
                            'Dim ThisPath = RepositorySecuritySettings.DOC_REPOSITORY_PATH

                            'Dim impersonateUser As Boolean = False
                            'Dim AliasAccount As AliasAccount
                            'impersonateUser = ThisUserName <> ""

                            'If impersonateUser = True Then
                            '    AliasAccount.BeginImpersonation(ThisUserName, ThisUserDomain, ThisUserPassword)
                            'End If

                            Dim zip As New ZipFile

                            Dim jc() As String = jobcompids.Split(",")
                            For i As Integer = 0 To jc.Length - 1
                                Dim jobc As String
                                jobc = jc(i)
                                If jobc <> "" Then
                                    Dim jobcomp() As String = jobc.Split("/")

                                    filename = Me.OutputReportFile(jobcomp(0), jobcomp(1))
                                    Dim f As New IO.FileInfo(StrFilePrefix & filename)
                                    If f.Exists Then


                                        zip.AddFile(StrFilePrefix & filename, "")
                                        strfiles &= filename & "|"
                                        'Dim Repository As New DocumentRepository(Session("ConnString"))
                                        'Dim FileBytes() As Byte
                                        'FileBytes = Repository.GetDocumentByteArray(StrFilePrefix, filename, True)

                                        'Dim ZipEntry As New ZipEntry(filename)
                                        'ZipEntry.DateTime = Now.Date
                                        'zipOutStream.PutNextEntry(ZipEntry)
                                        'zipOutStream.Write(FileBytes, 0, FileBytes.Length)
                                        'zipOutStream.Flush()



                                    End If
                                End If
                            Next

                            zip.Save(Response.OutputStream)

                            Dim str() As String = strfiles.Split("|")
                            For x As Integer = 0 To str.Length - 1
                                If str(x) <> "" Then
                                    Try
                                        My.Computer.FileSystem.DeleteFile(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                    Try
                                        Kill(StrFilePrefix & str(x).Trim)
                                    Catch ex As Exception
                                        'lbl_msg.Text = ex.Message.ToString
                                    End Try
                                End If
                            Next

                            'If impersonateUser = True Then
                            '    AliasAccount.EndImpersonation()
                            'End If

                            'zipOutStream.Finish()
                            'outputStream.Flush()
                            'OutputStream.Close()

                            'OutputStream = New System.IO.FileStream(TempFilename, IO.FileMode.Open, IO.FileAccess.Read)
                            'Dim OutputBytes(outputStream.Length) As Byte

                            'OutputBytes = outputStream.ToArray
                            'outputStream.Read(OutputBytes, 0, outputStream.Length)
                            'outputStream.Close()
                            'zipOutStream.Close()

                            'Response.Buffer = True
                            Response.AddHeader("Content-Disposition", "filename=Webvantage_Project_Schedules__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip")
                            'Response.ContentType = "application/x-zip-compressed"
                            Response.ContentType = "application/zip"
                            'Response.AddHeader("Content-Length", OutputBytes.Length.ToString())

                            'Response.BinaryWrite(OutputBytes)
                            'Response.Flush()
                            Response.End()


                        Catch ex As Exception

                        End Try
                End Select

            Case "CalculateDates"
                Dim pred As Integer = 0
                Dim dtHeader As DataTable
                Dim dt As DataTable = Me.GetGridColumnsToDisplay
                Dim j As Integer = 0
                Dim str As String = ""
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    Me.SaveHeaderRow(CurrentGridRow, CurrentJobNumber, CurrentJobComponentNumber)

                                    Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                    dtHeader = s.GetScheduleHeader(CurrentJobNumber, CurrentJobComponentNumber, Session("UserCode").ToString(), False).Tables(0)

                                    If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                                        pred = 1
                                    ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                                        pred = 0
                                    Else
                                        For z As Integer = 0 To dt.Rows.Count - 1
                                            If dt.Rows(z)("ColumnName") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(z)("ShowOnGrid") = "True" Then
                                                pred = 1
                                            End If
                                        Next
                                    End If
                                    If pred = 1 Then
                                        j = s.CalculateDueDatesPred(CurrentJobNumber, CurrentJobComponentNumber, 1)
                                    Else
                                        j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                    End If
                                    'Select Case i
                                    '    Case -1
                                    '        str = "Could not get start date."
                                    '    Case -2
                                    '        str = "Schedule is not feasible for calculation."
                                    'End Select
                                    'If j = -1 Or j = -2 Then
                                    '    Me.ShowMessage(str)
                                    '    Exit Sub
                                    'End If

                                    Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                        JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, CurrentJobNumber, CurrentJobComponentNumber).ToList
                                        If JobPred.Count > 0 Then
                                            j = s.CalculateJobPreds(CurrentJobNumber, CurrentJobComponentNumber, 0, Session("EmpCode"))
                                        End If
                                    End Using
                                    'run calc sp:

                                    ' j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                    Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)

                                    s.UpdateTaskAlertsDueDate(CurrentJobNumber, CurrentJobComponentNumber)

                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Me.RadGridProjectScheduleMultiview.Rebind()
                End If
            Case "ApplyTeam"
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    'Do stuff with each row
                                    Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                    If Me.DropApplyTeamType.SelectedIndex = 0 Then
                                        s.ApplyTeam(True, CurrentJobNumber, CurrentJobComponentNumber)
                                    Else
                                        s.ApplyTeam(False, CurrentJobNumber, CurrentJobComponentNumber)
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Me.RadGridProjectScheduleMultiview.Rebind()
                End If
            Case "MarkTempComplete"
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    'Do stuff with each row
                                    Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                    s.MarkTempComplete(CurrentJobNumber, CurrentJobComponentNumber)
                                    Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Me.RadGridProjectScheduleMultiview.Rebind()
                End If
            Case "CheckWorkload"
                Dim LowestStartDate As Date = Nothing
                Dim HighestDueDate As Date = Nothing
                Dim CurrStartDate As Date = Nothing
                Dim CurrDueDate As Date = Nothing
                Dim CurrJobCompList As String = ""
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Try
                                CurrStartDate = CType(CType(CurrentGridRow("ColSTART_DATE").FindControl("TxtSTART_DATE"), TextBox).Text, Date)
                            Catch ex As Exception
                                CurrStartDate = Nothing
                            End Try
                            Try
                                CurrDueDate = CType(CType(CurrentGridRow("ColJOB_FIRST_USE_DATE").FindControl("TxtJOB_FIRST_USE_DATE"), TextBox).Text, Date)
                            Catch ex As Exception
                                CurrDueDate = Nothing
                            End Try
                            If LowestStartDate = Nothing Then
                                LowestStartDate = CurrStartDate
                            End If
                            If HighestDueDate = Nothing Then
                                HighestDueDate = CurrDueDate
                            End If
                            If Not CurrStartDate = Nothing Then
                                If CurrStartDate < LowestStartDate Then
                                    LowestStartDate = CurrStartDate
                                End If
                            End If
                            If Not CurrDueDate = Nothing Then
                                If CurrDueDate > HighestDueDate Then
                                    HighestDueDate = CurrDueDate
                                End If
                            End If
                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                CurrJobCompList &= CurrentJobNumber & "," & CurrentJobComponentNumber & "|"
                            End If

                        End If
                    Next
                    If Not LowestStartDate = Nothing AndAlso Not HighestDueDate = Nothing Then
                        'Dim s As String = "TrafficSchedule_Workload2.aspx?s=" & cGlobals.wvCDate(LowestStartDate).ToShortDateString & "&e=" & cGlobals.wvCDate(HighestDueDate).ToShortDateString
                        Session("WorkloadStart") = cGlobals.wvCDate(LowestStartDate).ToShortDateString()
                        Session("WorkloadEnd") = cGlobals.wvCDate(HighestDueDate).ToShortDateString()
                        Session("WorkloadJobCompList") = CurrJobCompList.ToString()
                        Session("WorkloadIsMulti") = "True"
                        Dim z As String = "ProgressIndicator.aspx?destPage=TrafficSchedule_Workload2.aspx"
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerScheduler, "WorkloadWindow", "Workload Analysis", z, 500, 950, False)
                    End If
                End If

            Case "FindAndReplaceAll"

                Dim DataTable As DataTable = Nothing
                Dim JobString As String = Nothing

                DataTable = Me.DataSource

                If DataTable.Rows.Count > 0 Then

                    JobString = String.Join("|", (From DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)
                                                  Select DataRow("JOB_NUMBER").ToString & "," & DataRow("JOB_COMPONENT_NBR").ToString).ToArray)

                    Session("PS_FIND_REPLACE_COMPONENTS") = JobString

                    If Not String.IsNullOrWhiteSpace(JobString) Then

                        Me.OpenWindow("Search and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=ALL", 0, 0, False, True)

                    End If

                End If

            Case "FindAndReplace"
                If RowCount > 0 Then
                    Dim SbJobCompList As New System.Text.StringBuilder
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    'Do stuff with each row
                                    With SbJobCompList
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    Dim sbQueryString As New System.Text.StringBuilder
                    With sbQueryString
                        .Append("&")
                        .Append("Off=")
                        .Append(OfficeCode)
                        .Append("&")
                        .Append("Cli=")
                        .Append(ClientCode)
                        .Append("&")
                        .Append("Div=")
                        .Append(DivisionCode)
                        .Append("&")
                        .Append("Prod=")
                        .Append(ProductCode)
                        .Append("&")
                        .Append("Job=")
                        .Append(JobNumber)
                        .Append("&")
                        .Append("JobComp=")
                        .Append(JobCompNumber)
                        .Append("&")
                        .Append("Emp=")
                        .Append(EmpCode)
                        .Append("&")
                        .Append("Mgr=")
                        .Append(ManagerCode)
                        .Append("&")
                        .Append("Task=")
                        .Append(TaskCode)
                        .Append("&")
                        .Append("AE=")
                        .Append(AccountExecCode)
                        .Append("&")
                        .Append("Role=")
                        .Append(RoleCode)
                        .Append("&")
                        .Append("Cut=")
                        .Append(CutOffDate)
                        .Append("&")
                        .Append("Camp=")
                        .Append(CampaignCode)
                        .Append("&")
                        .Append("SC=")
                        .Append(SalesClass)
                        .Append("&")
                        .Append("Comp=")
                        .Append(IncludeCompletedTasks.ToString())
                        .Append("&")
                        .Append("Pend=")
                        .Append(IncludeOnlyPendingTasks.ToString())
                        .Append("&")
                        .Append("Proj=")
                        .Append(ExcludeProjectedTasks.ToString())
                        .Append("&")
                        .Append("CS=")
                        .Append(IncludeCompletedSchedules.ToString())
                        .Append("&")
                        .Append("P=")
                        .Append(TaskPhaseFilter)
                    End With
                    Dim StrURL As String = "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") & sbQueryString.ToString
                    If SbJobCompList.ToString <> "" Then
                        Me.OpenWindow("Search and Replace", StrURL, 0, 0, False, True)
                        'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerScheduler, "FandRWindow", "Search and Replace", StrURL, 285, 645, False)
                    Else
                        Me.ShowMessage("No rows selected.")
                    End If
                End If
            Case "Calendar"
                Dim sb As New System.Text.StringBuilder
                Dim ctr As Integer = 0
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrectClientCode As String = ""
                                Try
                                    CurrectClientCode = CurrentGridRow.GetDataKeyValue("CL_CODE")
                                Catch ex As Exception
                                    CurrectClientCode = ""
                                End Try
                                Dim CurrentDivisionCode As String = ""
                                Try
                                    CurrentDivisionCode = CurrentGridRow.GetDataKeyValue("DIV_CODE")
                                Catch ex As Exception
                                    CurrentDivisionCode = ""
                                End Try
                                Dim CurrentProductCode As String = ""
                                Try
                                    CurrentProductCode = CurrentGridRow.GetDataKeyValue("PRD_CODE")
                                Catch ex As Exception
                                    CurrentProductCode = ""
                                End Try
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    ctr += 1
                                    With sb
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append(",")
                                        .Append(CurrectClientCode.ToString())
                                        .Append(",")
                                        .Append(CurrentDivisionCode.ToString())
                                        .Append(",")
                                        .Append(CurrentProductCode.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If ctr = 0 Then
                        Exit Sub
                    End If
                    Session("TrafficScheduleMVJobs") = sb.ToString
                    Me.OpenWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PSMV")
                End If
            Case "Summary"
                Dim sb As New System.Text.StringBuilder
                Dim ctr As Integer = 0
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    ctr += 1
                                    'Do something to send to alert window? selected items
                                    With sb
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If ctr = 0 Then
                        Exit Sub
                    End If
                    Session("TrafficScheduleMVJobs") = sb.ToString
                    Me.OpenWindow("Risk Analysis Summary", "TrafficSchedule_Status_Summary.aspx")
                End If
            Case "PrintSendOptions"
                Dim sb As New System.Text.StringBuilder
                Dim ctr As Integer = 0
                Dim j As Integer
                Dim c As Integer
                If RowCount > 0 Then
                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                    ctr += 1
                                    j = CurrentJobNumber
                                    c = CurrentJobComponentNumber
                                    'Do something to send to alert window? selected items
                                    With sb
                                        .Append(CurrentJobNumber.ToString())
                                        .Append(",")
                                        .Append(CurrentJobComponentNumber.ToString())
                                        .Append("|")
                                    End With
                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                    If ctr = 0 Then
                        Me.ShowMessage("No file(s) selected.")
                        Exit Sub
                    End If

                    Dim strgantt As String = sb.ToString
                    Dim qs As New AdvantageFramework.Web.QueryString()

                    Session("TrafficScheduleMVJobs") = sb.ToString

                    qs.Page = "TrafficSchedule_Print.aspx"
                    If ctr = 1 Then
                        qs.JobNumber = j
                        qs.JobComponentNumber = c
                        qs.Add("pm", "0")
                    Else
                        qs.Add("pm", "1")
                    End If
                    qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)
                    qs.Add("count", ctr)

                    Me.OpenWindow(qs)

                    'MiscFN.ResponseRedirect("ExcelGantt/TimelinePage.aspx?From=psmv&ms=0&excludeTC=0")
                End If
            Case "GanttView"
                Dim sb As New System.Text.StringBuilder
                Dim ctr As Integer = 0
                Dim CurrStartDate As Date = Nothing
                Dim DataView As DataView = Nothing
                Dim DataTable As DataTable = Nothing
                Dim NewDataRow As DataRow = Nothing
                If RowCount > 0 Then
                    DataTable = New DataTable
                    DataTable.Columns.Add("JOB_NUMBER")
                    DataTable.Columns.Add("JOB_COMPONENT_NBR")
                    DataTable.Columns.Add("START_DATE", System.Type.GetType("System.DateTime"))
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For i As Integer = 0 To RowCount - 1
                            Try
                                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                                Dim chk As CheckBox
                                chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                                If chk.Checked = True Then
                                    Dim CurrentJobNumber As Integer = 0
                                    Try
                                        CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                    Catch ex As Exception
                                        CurrentJobNumber = 0
                                    End Try
                                    Dim CurrentJobComponentNumber As Integer = 0
                                    Try
                                        CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                    Catch ex As Exception
                                        CurrentJobComponentNumber = 0
                                    End Try
                                    Try
                                        CurrStartDate = CType(CType(CurrentGridRow("ColSTART_DATE").FindControl("RadDatePickerSTART_DATE"), RadDatePicker).SelectedDate, Date)
                                    Catch ex As Exception
                                        CurrStartDate = Nothing
                                    End Try
                                    If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 And CurrStartDate <> Nothing Then

                                        If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, CurrentJobNumber, CurrentJobComponentNumber).Count() > 0 Then

                                            ctr += 1
                                            NewDataRow = DataTable.NewRow
                                            NewDataRow.Item("JOB_NUMBER") = CurrentJobNumber
                                            NewDataRow.Item("JOB_COMPONENT_NBR") = CurrentJobComponentNumber
                                            NewDataRow.Item("START_DATE") = CurrStartDate
                                            DataTable.Rows.Add(NewDataRow)

                                        End If

                                    End If
                                End If
                            Catch ex As Exception
                            End Try
                        Next

                    End Using

                    If DataTable.Rows.Count > 0 Then
                        DataView = DataTable.DefaultView
                        DataView.Sort = "START_DATE"
                        DataTable = DataView.ToTable
                        For i As Integer = 0 To DataTable.Rows.Count - 1
                            With sb
                                .Append(DataTable.Rows(i)("JOB_NUMBER").ToString)
                                .Append(",")
                                .Append(DataTable.Rows(i)("JOB_COMPONENT_NBR").ToString)
                                .Append("|")
                            End With
                        Next
                    End If
                    If ctr = 0 Then
                        Exit Sub
                    End If
                    Session("TrafficScheduleMVJobs") = sb.ToString
                    Me.OpenWindow("Gantt", "angulargantt.aspx")
                End If

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                    .UserCode = Session("UserCode")
                    .Name = "PS Multiview Results"
                    .PageURL = "TrafficSchedule_Multiview.aspx" & qs.ToString()

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()
                End If

            Case "UpdateStatus"

                Dim UpdatedRows As Integer = 0

                If RowCount > 0 Then

                    For i As Integer = 0 To RowCount - 1

                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox

                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)

                        If chk.Checked = True Then

                            Dim CurrentJobNumber As Integer = 0
                            Try

                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)

                            Catch ex As Exception

                                CurrentJobNumber = 0

                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try

                            If CurrentJobNumber > 0 AndAlso CurrentJobComponentNumber > 0 Then

                                If Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber) = True Then

                                    UpdatedRows += 1

                                End If

                            End If

                        End If

                    Next

                End If

                If UpdatedRows > 0 Then Me.RadGridProjectScheduleMultiview.Rebind()

                'Select Case UpdatedRows
                '    Case 0

                '        Me.ShowMessage("No schedules updated")

                '    Case 1

                '        Me.ShowMessage("One schedule updated")

                '    Case Is > 1

                '        Me.ShowMessage(UpdatedRows.ToString() & " schedules updated")

                'End Select

        End Select

    End Sub

    Private Sub CheckUserRights()
        Try
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secView As String
            Dim secEdit As String
            Dim secInsert As String
            Dim custom1 As String

            secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            _UserCustom1 = Me.UserCanCustom1Module(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

            If secView = "N" Then
                Me.RadToolbarSchedule.FindItemByValue("Print").Enabled = False
            End If
            If secEdit = "N" And secInsert = "N" Then
                Me.RadToolbarSchedule.FindItemByValue("SaveAll").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("CalculateDates").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("ApplyTeam").Enabled = False
                Me.RadToolbarSchedule.FindItemByText("Update Status").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("MarkTempComplete").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("FindAndReplace").Enabled = False
            ElseIf secEdit = "Y" And secInsert = "N" Then
            ElseIf secEdit = "N" And secInsert = "Y" Then
                Me.RadToolbarSchedule.FindItemByValue("SaveAll").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("CalculateDates").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("ApplyTeam").Enabled = False
                Me.RadToolbarSchedule.FindItemByText("Update Status").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("MarkTempComplete").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("FindAndReplace").Enabled = False
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub CheckForPredecessors()
        Try
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count
            Dim JobPred As AdvantageFramework.Database.Entities.JobTrafficPredecessors = Nothing
            Dim JobTrafficPreds As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    JobTrafficPreds = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Load(DbContext).ToList.Where(Function(JobTrafficPredecessors) JobTrafficPredecessors.JobPredecessor = CurrentJobNumber And JobTrafficPredecessors.JobComponentPredecessor = CurrentJobComponentNumber).ToList
                                    If JobTrafficPreds.Count > 0 Then
                                        CType(Me.RadToolbarSchedule.FindItemByValue("CalculateDates"), RadToolBarButton).CommandName = "CalculateDates"
                                        Exit Sub
                                    Else
                                        CType(Me.RadToolbarSchedule.FindItemByValue("CalculateDates"), RadToolBarButton).CommandName = "Calculate"
                                    End If
                                End Using
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Function GetGridColumnsToDisplay() As DataTable
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = s.GetScheduleColumns(Session("EmpCode"), False, False, False)
        Return dt
    End Function

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridProjectScheduleMultiview.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridProjectScheduleMultiview.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub

    'Public Sub RadDatePickerSTART_DATE_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)
    '    Try
    '        Dim rdp As RadDatePicker = CType(sender, Telerik.Web.UI.RadDatePicker)
    '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rdp.Parent.Parent, Telerik.Web.UI.GridDataItem)
    '        Dim key As String = CurrentGridRow.GetDataKeyValue("JOB_NUMBER") & "|" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
    '        Dim DateString As String = ""
    '        If Not rdp Is Nothing AndAlso Not rdp.SelectedDate Is Nothing Then
    '            DateString = CType(rdp.SelectedDate, Date).ToShortDateString()
    '        End If
    '        Webvantage.TrafficSchedule.AutoSaveScheduleHeader(key, "START_DATE", DateString, rdp.ClientID)
    '        'Me.RadGridProjectScheduleMultiview.Rebind()

    '    Catch ex As Exception

    '        Me.ShowMessage("Error setting Start Date")

    '    End Try
    'End Sub
    'Public Sub RadDatePickerJOB_FIRST_USE_DATE_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)
    '    Try
    '        Dim rdp As RadDatePicker = CType(sender, Telerik.Web.UI.RadDatePicker)
    '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rdp.Parent.Parent, Telerik.Web.UI.GridDataItem)
    '        Dim key As String = CurrentGridRow.GetDataKeyValue("JOB_NUMBER") & "|" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
    '        Dim DateString As String = ""
    '        If Not rdp Is Nothing AndAlso Not rdp.SelectedDate Is Nothing Then
    '            DateString = CType(rdp.SelectedDate, Date).ToShortDateString()
    '        End If

    '        Webvantage.TrafficSchedule.AutoSaveScheduleHeader(key, "JOB_FIRST_USE_DATE", DateString, rdp.ClientID)
    '        'Me.RadGridProjectScheduleMultiview.Rebind()

    '    Catch ex As Exception

    '        Me.ShowMessage("Error setting Due Date")

    '    End Try
    'End Sub
    'Public Sub RadDatePickerJobCompleted_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)
    '    Try
    '        Dim rdp As RadDatePicker = CType(sender, Telerik.Web.UI.RadDatePicker)
    '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rdp.Parent.Parent, Telerik.Web.UI.GridDataItem)
    '        Dim key As String = CurrentGridRow.GetDataKeyValue("JOB_NUMBER") & "|" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")
    '        Dim DateString As String = ""
    '        If Not rdp Is Nothing AndAlso Not rdp.SelectedDate Is Nothing Then
    '            DateString = CType(rdp.SelectedDate, Date).ToShortDateString()
    '        End If

    '        Webvantage.TrafficSchedule.AutoSaveScheduleHeader(key, "COMPLETED_DATE", DateString, rdp.ClientID)
    '        Me.RadGridProjectScheduleMultiview.Rebind()

    '    Catch ex As Exception

    '        Me.ShowMessage("Error setting Completed Date")

    '    End Try
    'End Sub
    Public Sub DropStatus_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)
        Try
            Dim rcbo As RadComboBox = CType(sender, Telerik.Web.UI.RadComboBox)
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(rcbo.Parent.Parent, Telerik.Web.UI.GridDataItem)
            Dim key As String = CurrentGridRow.GetDataKeyValue("JOB_NUMBER") & "|" & CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR")

            Webvantage.TrafficSchedule.AutoSaveScheduleHeader(key, "TRF_CODE", rcbo.SelectedValue, rcbo.ClientID)
            'Me.RadGridProjectScheduleMultiview.Rebind()

        Catch ex As Exception

            Me.ShowMessage("Error setting Status")

        End Try
    End Sub


    <System.Web.Services.WebMethod()>
    Public Shared Function AutoSaveScheduleHeader(ByVal DataKey As String, ByVal FieldName As String, ByVal ControlValue As String, ByVal ControlClientId As String) As String

        Webvantage.TrafficSchedule.AutoSaveScheduleHeader(DataKey, FieldName, ControlValue, ControlClientId)

    End Function

    Private Sub RadGridProjectScheduleMultiview_PreRender(sender As Object, e As EventArgs) Handles RadGridProjectScheduleMultiview.PreRender

        'objects
        Dim GridPagerItem As Telerik.Web.UI.GridPagerItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        GridPagerItem = RadGridProjectScheduleMultiview.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Pager)(1)
        RadNumericTextBox = GridPagerItem.FindControl("ChangePageSizeTextBox")
        RadNumericTextBox.MaxValue = 100

    End Sub

    Private Sub ButtonUpdateStatusAll_Click(sender As Object, e As EventArgs) Handles ButtonUpdateStatusAll.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim DataTable As DataTable = Nothing
            Dim JobString As String = Nothing
            Dim UpdatedRows As Integer = 0

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then

                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                    Try
                        IsTemplate = CType(CurrentGridRow("IS_TEMPLATE"), Boolean)
                    Catch ex As Exception
                        IsTemplate = False
                    End Try

                    If (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                        Dim CurrentJobNumber As Integer = 0
                        Try
                            CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                        Catch ex As Exception
                            CurrentJobNumber = 0
                        End Try
                        Dim CurrentJobComponentNumber As Integer = 0
                        Try
                            CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            CurrentJobComponentNumber = 0
                        End Try

                        If CurrentJobNumber > 0 AndAlso CurrentJobComponentNumber > 0 Then

                            If Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber) = True Then

                                UpdatedRows += 1

                            End If

                        End If

                    End If

                Next

            End If

            If UpdatedRows > 0 Then Me.RadGridProjectScheduleMultiview.Rebind()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonUpdateStatusSelected_Click(sender As Object, e As EventArgs) Handles ButtonUpdateStatusSelected.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim UpdatedRows As Integer = 0
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            If RowCount > 0 Then

                For i As Integer = 0 To RowCount - 1

                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim chk As CheckBox

                    chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)

                    Try
                        IsTemplate = CType(Me.DataSource.Rows(CurrentGridRow.ItemIndex)("IS_TEMPLATE"), Boolean)
                    Catch ex As Exception
                        IsTemplate = False
                    End Try

                    If chk.Checked = True AndAlso (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                        Dim CurrentJobNumber As Integer = 0
                        Try

                            CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)

                        Catch ex As Exception

                            CurrentJobNumber = 0

                        End Try
                        Dim CurrentJobComponentNumber As Integer = 0
                        Try
                            CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            CurrentJobComponentNumber = 0
                        End Try

                        If CurrentJobNumber > 0 AndAlso CurrentJobComponentNumber > 0 Then

                            If Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber) = True Then

                                UpdatedRows += 1

                            End If

                        End If

                    End If

                Next

            End If

            If UpdatedRows > 0 Then Me.RadGridProjectScheduleMultiview.Rebind()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCalculateAll_Click(sender As Object, e As EventArgs) Handles ButtonCalculateAll.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim pred As Integer = 0
            Dim dtHeader As DataTable
            Dim dt As DataTable = Me.GetGridColumnsToDisplay
            Dim j As Integer = 0
            Dim str As String = ""
            Dim DataTable As DataTable = Nothing

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then
                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Try
                        Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                        Try
                            IsTemplate = CType(CurrentGridRow("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            pred = 0
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Me.SaveHeaderRow(CurrentGridRow, CurrentJobNumber, CurrentJobComponentNumber)

                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                dtHeader = s.GetScheduleHeader(CurrentJobNumber, CurrentJobComponentNumber, Session("UserCode").ToString(), False).Tables(0)

                                If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                                    pred = 1
                                ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                                    pred = 0
                                Else
                                    For z As Integer = 0 To dt.Rows.Count - 1
                                        If dt.Rows(z)("ColumnName") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(z)("ShowOnGrid") = "True" Then
                                            pred = 1
                                        End If
                                    Next
                                End If
                                If pred = 1 Then
                                    j = s.CalculateDueDatesPred(CurrentJobNumber, CurrentJobComponentNumber, 1)
                                Else
                                    j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                End If
                                'Select Case i
                                '    Case -1
                                '        str = "Could not get start date."
                                '    Case -2
                                '        str = "Schedule is not feasible for calculation."
                                'End Select
                                'If j = -1 Or j = -2 Then
                                '    Me.ShowMessage(str)
                                '    Exit Sub
                                'End If

                                Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, CurrentJobNumber, CurrentJobComponentNumber).ToList
                                    If JobPred.Count > 0 Then
                                        j = s.CalculateJobPreds(CurrentJobNumber, CurrentJobComponentNumber, 0, Session("EmpCode"))
                                    End If
                                End Using
                                'run calc sp:

                                ' j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)

                                s.UpdateTaskAlertsDueDate(CurrentJobNumber, CurrentJobComponentNumber)

                            End If

                        End If

                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonCalculateSelected_Click(sender As Object, e As EventArgs) Handles ButtonCalculateSelected.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim pred As Integer = 0
            Dim dtHeader As DataTable
            Dim dt As DataTable = Me.GetGridColumnsToDisplay
            Dim j As Integer = 0
            Dim str As String = ""

            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)

                        Try
                            IsTemplate = CType(Me.DataSource.Rows(CurrentGridRow.ItemIndex)("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If chk.Checked = True AndAlso (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            pred = 0
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                Me.SaveHeaderRow(CurrentGridRow, CurrentJobNumber, CurrentJobComponentNumber)

                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                dtHeader = s.GetScheduleHeader(CurrentJobNumber, CurrentJobComponentNumber, Session("UserCode").ToString(), False).Tables(0)

                                If dtHeader.Rows(0)("SCHEDULE_CALC") = 1 Then
                                    pred = 1
                                ElseIf dtHeader.Rows(0)("SCHEDULE_CALC") = 0 Then
                                    pred = 0
                                Else
                                    For z As Integer = 0 To dt.Rows.Count - 1
                                        If dt.Rows(z)("ColumnName") = "colPREDECESSORS_TEXT" AndAlso dt.Rows(z)("ShowOnGrid") = "True" Then
                                            pred = 1
                                        End If
                                    Next
                                End If
                                If pred = 1 Then
                                    j = s.CalculateDueDatesPred(CurrentJobNumber, CurrentJobComponentNumber, 1)
                                Else
                                    j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                End If
                                'Select Case i
                                '    Case -1
                                '        str = "Could not get start date."
                                '    Case -2
                                '        str = "Schedule is not feasible for calculation."
                                'End Select
                                'If j = -1 Or j = -2 Then
                                '    Me.ShowMessage(str)
                                '    Exit Sub
                                'End If

                                Dim JobPred As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    JobPred = AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, CurrentJobNumber, CurrentJobComponentNumber).ToList
                                    If JobPred.Count > 0 Then
                                        j = s.CalculateJobPreds(CurrentJobNumber, CurrentJobComponentNumber, 0, Session("EmpCode"))
                                    End If
                                End Using
                                'run calc sp:

                                ' j = s.CalculateDueDates(CurrentJobNumber, CurrentJobComponentNumber, 0)
                                Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)

                                s.UpdateTaskAlertsDueDate(CurrentJobNumber, CurrentJobComponentNumber)

                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonApplyTeamAll_Click(sender As Object, e As EventArgs) Handles ButtonApplyTeamAll.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim DataTable As DataTable = Nothing

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then
                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Try
                        Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                        Try
                            IsTemplate = CType(CurrentGridRow("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                If Me.DropApplyTeamType.SelectedIndex = 0 Then
                                    s.ApplyTeam(True, CurrentJobNumber, CurrentJobComponentNumber)
                                Else
                                    s.ApplyTeam(False, CurrentJobNumber, CurrentJobComponentNumber)
                                End If
                            End If

                        End If

                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonApplyTeamSelected_Click(sender As Object, e As EventArgs) Handles ButtonApplyTeamSelected.Click

        Dim IsTemplate As Boolean = False

        Try
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)

                        Try
                            IsTemplate = CType(Me.DataSource.Rows(CurrentGridRow.ItemIndex)("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If chk.Checked = True AndAlso (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                If Me.DropApplyTeamType.SelectedIndex = 0 Then
                                    s.ApplyTeam(True, CurrentJobNumber, CurrentJobComponentNumber)
                                Else
                                    s.ApplyTeam(False, CurrentJobNumber, CurrentJobComponentNumber)
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonTempCompleteAll_Click(sender As Object, e As EventArgs) Handles ButtonTempCompleteAll.Click

        Dim IsTemplate As Boolean = False

        Try
            Dim DataTable As DataTable = Nothing

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then
                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Try
                        Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                        Try
                            IsTemplate = CType(CurrentGridRow("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                s.MarkTempComplete(CurrentJobNumber, CurrentJobComponentNumber)
                                Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)
                            End If

                        End If

                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonTempCompleteSelected_Click(sender As Object, e As EventArgs) Handles ButtonTempCompleteSelected.Click

        Dim IsTemplate As Boolean = False

        Try
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)

                        Try
                            IsTemplate = CType(Me.DataSource.Rows(CurrentGridRow.ItemIndex)("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If chk.Checked = True AndAlso (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                Dim s As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                                s.MarkTempComplete(CurrentJobNumber, CurrentJobComponentNumber)
                                Me.UpdateStatusCode(CurrentJobNumber, CurrentJobComponentNumber)
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Me.RadGridProjectScheduleMultiview.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonReplaceAll_Click(sender As Object, e As EventArgs) Handles ButtonReplaceAll.Click

        Try
            Dim DataTable As DataTable = Nothing
            Dim JobString As String = Nothing

            DataTable = Me.DataSource

            If DataTable.Rows.Count > 0 Then

                If _UserCustom1 = True Then

                    JobString = String.Join("|", (From DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)
                                                  Where DataRow("IS_TEMPLATE") = False
                                                  Select DataRow("JOB_NUMBER").ToString & "," & DataRow("JOB_COMPONENT_NBR").ToString).ToArray)

                Else

                    JobString = String.Join("|", (From DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)
                                                  Select DataRow("JOB_NUMBER").ToString & "," & DataRow("JOB_COMPONENT_NBR").ToString).ToArray)

                End If

                Session("PS_FIND_REPLACE_COMPONENTS") = JobString

                If Not String.IsNullOrWhiteSpace(JobString) Then

                    Me.OpenWindow("Search and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=ALL", 0, 0, False, True)

                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonReplaceSelected_Click(sender As Object, e As EventArgs) Handles ButtonReplaceSelected.Click

        Dim IsTemplate As Boolean = False

        Try
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            If RowCount > 0 Then
                Dim SbJobCompList As New System.Text.StringBuilder
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)


                        Try
                            IsTemplate = CType(Me.DataSource.Rows(CurrentGridRow.ItemIndex)("IS_TEMPLATE"), Boolean)
                        Catch ex As Exception
                            IsTemplate = False
                        End Try

                        If chk.Checked = True AndAlso (_UserCustom1 = True AndAlso IsTemplate = True) = False Then

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                'Do stuff with each row
                                With SbJobCompList
                                    .Append(CurrentJobNumber.ToString())
                                    .Append(",")
                                    .Append(CurrentJobComponentNumber.ToString())
                                    .Append("|")
                                End With
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                Dim sbQueryString As New System.Text.StringBuilder
                With sbQueryString
                    .Append("&")
                    .Append("Off=")
                    .Append(OfficeCode)
                    .Append("&")
                    .Append("Cli=")
                    .Append(ClientCode)
                    .Append("&")
                    .Append("Div=")
                    .Append(DivisionCode)
                    .Append("&")
                    .Append("Prod=")
                    .Append(ProductCode)
                    .Append("&")
                    .Append("Job=")
                    .Append(JobNumber)
                    .Append("&")
                    .Append("JobComp=")
                    .Append(JobCompNumber)
                    .Append("&")
                    .Append("Emp=")
                    .Append(EmpCode)
                    .Append("&")
                    .Append("Mgr=")
                    .Append(ManagerCode)
                    .Append("&")
                    .Append("Task=")
                    .Append(TaskCode)
                    .Append("&")
                    .Append("AE=")
                    .Append(AccountExecCode)
                    .Append("&")
                    .Append("Role=")
                    .Append(RoleCode)
                    .Append("&")
                    .Append("Cut=")
                    .Append(CutOffDate)
                    .Append("&")
                    .Append("Camp=")
                    .Append(CampaignCode)
                    .Append("&")
                    .Append("SC=")
                    .Append(SalesClass)
                    .Append("&")
                    .Append("Comp=")
                    .Append(IncludeCompletedTasks.ToString())
                    .Append("&")
                    .Append("Pend=")
                    .Append(IncludeOnlyPendingTasks.ToString())
                    .Append("&")
                    .Append("Proj=")
                    .Append(ExcludeProjectedTasks.ToString())
                    .Append("&")
                    .Append("CS=")
                    .Append(IncludeCompletedSchedules.ToString())
                    .Append("&")
                    .Append("P=")
                    .Append(TaskPhaseFilter)
                End With
                Dim StrURL As String = "ProjectManagement/ProjectSchedule/FindAndReplace?wm=1&Components=" & MiscFN.RemoveTrailingDelimiter(SbJobCompList.ToString(), "|") & sbQueryString.ToString
                If SbJobCompList.ToString <> "" Then
                    Me.OpenWindow("Search and Replace", StrURL, 0, 0, False, True)
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerScheduler, "FandRWindow", "Search and Replace", StrURL, 285, 645, False)
                Else
                    Me.ShowMessage("No rows selected.")
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonGanttAll_Click(sender As Object, e As EventArgs) Handles ButtonGanttAll.Click
        Try
            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0
            Dim CurrStartDate As Date = Nothing
            Dim DataView As DataView = Nothing
            Dim DataTable As DataTable = Nothing
            Dim NewDataRow As DataRow = Nothing

            Dim DataTablePS As DataTable = Nothing

            DataTablePS = Me.DataSource

            Me._DataSource = Nothing

            If DataTablePS.Rows.Count > 0 Then
                DataTable = New DataTable
                DataTable.Columns.Add("JOB_NUMBER")
                DataTable.Columns.Add("JOB_COMPONENT_NBR")
                DataTable.Columns.Add("START_DATE", System.Type.GetType("System.DateTime"))
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For i As Integer = 0 To DataTablePS.Rows.Count - 1
                        Try
                            Dim CurrentGridRow As System.Data.DataRow = DataTablePS.Rows(i)

                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            Try
                                CurrStartDate = CType(CurrentGridRow("START_DATE"), Date)
                            Catch ex As Exception
                                CurrStartDate = Nothing
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 And CurrStartDate <> Nothing Then

                                If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, CurrentJobNumber, CurrentJobComponentNumber).Count() > 0 Then

                                    ctr += 1
                                    NewDataRow = DataTable.NewRow
                                    NewDataRow.Item("JOB_NUMBER") = CurrentJobNumber
                                    NewDataRow.Item("JOB_COMPONENT_NBR") = CurrentJobComponentNumber
                                    NewDataRow.Item("START_DATE") = CurrStartDate
                                    DataTable.Rows.Add(NewDataRow)

                                End If

                            End If
                        Catch ex As Exception
                        End Try
                    Next

                End Using

                If DataTable.Rows.Count > 0 Then
                    DataView = DataTable.DefaultView
                    DataView.Sort = "START_DATE"
                    DataTable = DataView.ToTable
                    For i As Integer = 0 To DataTable.Rows.Count - 1
                        With sb
                            .Append(DataTable.Rows(i)("JOB_NUMBER").ToString)
                            .Append(",")
                            .Append(DataTable.Rows(i)("JOB_COMPONENT_NBR").ToString)
                            .Append("|")
                        End With
                    Next
                End If
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Gantt", "angulargantt.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonGanttSelected_Click(sender As Object, e As EventArgs) Handles ButtonGanttSelected.Click
        Try

            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0
            Dim CurrStartDate As Date = Nothing
            Dim DataView As DataView = Nothing
            Dim DataTable As DataTable = Nothing
            Dim NewDataRow As DataRow = Nothing
            If RowCount > 0 Then
                DataTable = New DataTable
                DataTable.Columns.Add("JOB_NUMBER")
                DataTable.Columns.Add("JOB_COMPONENT_NBR")
                DataTable.Columns.Add("START_DATE", System.Type.GetType("System.DateTime"))
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For i As Integer = 0 To RowCount - 1
                        Try
                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                            Dim chk As CheckBox
                            chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                Dim CurrentJobNumber As Integer = 0
                                Try
                                    CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                                Catch ex As Exception
                                    CurrentJobNumber = 0
                                End Try
                                Dim CurrentJobComponentNumber As Integer = 0
                                Try
                                    CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                                Catch ex As Exception
                                    CurrentJobComponentNumber = 0
                                End Try
                                Try
                                    CurrStartDate = CType(CType(CurrentGridRow("ColSTART_DATE").FindControl("RadDatePickerSTART_DATE"), RadDatePicker).SelectedDate, Date)
                                Catch ex As Exception
                                    CurrStartDate = Nothing
                                End Try
                                If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 And CurrStartDate <> Nothing Then

                                    If AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, CurrentJobNumber, CurrentJobComponentNumber).Count() > 0 Then

                                        ctr += 1
                                        NewDataRow = DataTable.NewRow
                                        NewDataRow.Item("JOB_NUMBER") = CurrentJobNumber
                                        NewDataRow.Item("JOB_COMPONENT_NBR") = CurrentJobComponentNumber
                                        NewDataRow.Item("START_DATE") = CurrStartDate
                                        DataTable.Rows.Add(NewDataRow)

                                    End If

                                End If
                            End If
                        Catch ex As Exception
                        End Try
                    Next

                End Using

                If DataTable.Rows.Count > 0 Then
                    DataView = DataTable.DefaultView
                    DataView.Sort = "START_DATE"
                    DataTable = DataView.ToTable
                    For i As Integer = 0 To DataTable.Rows.Count - 1
                        With sb
                            .Append(DataTable.Rows(i)("JOB_NUMBER").ToString)
                            .Append(",")
                            .Append(DataTable.Rows(i)("JOB_COMPONENT_NBR").ToString)
                            .Append("|")
                        End With
                    Next
                End If
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Gantt", "angulargantt.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCalendarAll_Click(sender As Object, e As EventArgs) Handles ButtonCalendarAll.Click
        Try
            Dim DataTable As DataTable = Nothing
            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then
                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Try
                        Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                        Dim CurrectClientCode As String = ""
                        Try
                            CurrectClientCode = CurrentGridRow("CL_CODE")
                        Catch ex As Exception
                            CurrectClientCode = ""
                        End Try
                        Dim CurrentDivisionCode As String = ""
                        Try
                            CurrentDivisionCode = CurrentGridRow("DIV_CODE")
                        Catch ex As Exception
                            CurrentDivisionCode = ""
                        End Try
                        Dim CurrentProductCode As String = ""
                        Try
                            CurrentProductCode = CurrentGridRow("PRD_CODE")
                        Catch ex As Exception
                            CurrentProductCode = ""
                        End Try
                        Dim CurrentJobNumber As Integer = 0
                        Try
                            CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                        Catch ex As Exception
                            CurrentJobNumber = 0
                        End Try
                        Dim CurrentJobComponentNumber As Integer = 0
                        Try
                            CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            CurrentJobComponentNumber = 0
                        End Try
                        If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                            ctr += 1
                            With sb
                                .Append(CurrentJobNumber.ToString())
                                .Append(",")
                                .Append(CurrentJobComponentNumber.ToString())
                                .Append(",")
                                .Append(CurrectClientCode.ToString())
                                .Append(",")
                                .Append(CurrentDivisionCode.ToString())
                                .Append(",")
                                .Append(CurrentProductCode.ToString())
                                .Append("|")
                            End With
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PSMV")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonCalendarSelected_Click(sender As Object, e As EventArgs) Handles ButtonCalendarSelected.Click
        Try
            RowCount = Me.RadGridProjectScheduleMultiview.MasterTableView.Items.Count

            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Dim CurrectClientCode As String = ""
                            Try
                                CurrectClientCode = CurrentGridRow.GetDataKeyValue("CL_CODE")
                            Catch ex As Exception
                                CurrectClientCode = ""
                            End Try
                            Dim CurrentDivisionCode As String = ""
                            Try
                                CurrentDivisionCode = CurrentGridRow.GetDataKeyValue("DIV_CODE")
                            Catch ex As Exception
                                CurrentDivisionCode = ""
                            End Try
                            Dim CurrentProductCode As String = ""
                            Try
                                CurrentProductCode = CurrentGridRow.GetDataKeyValue("PRD_CODE")
                            Catch ex As Exception
                                CurrentProductCode = ""
                            End Try
                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                ctr += 1
                                With sb
                                    .Append(CurrentJobNumber.ToString())
                                    .Append(",")
                                    .Append(CurrentJobComponentNumber.ToString())
                                    .Append(",")
                                    .Append(CurrectClientCode.ToString())
                                    .Append(",")
                                    .Append(CurrentDivisionCode.ToString())
                                    .Append(",")
                                    .Append(CurrentProductCode.ToString())
                                    .Append("|")
                                End With
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PSMV")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonRiskAnalysisAll_Click(sender As Object, e As EventArgs) Handles ButtonRiskAnalysisAll.Click
        Try
            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0
            Dim DataTable As DataTable = Nothing

            DataTable = Me.DataSource

            Me._DataSource = Nothing

            If DataTable.Rows.Count > 0 Then
                For i As Integer = 0 To DataTable.Rows.Count - 1
                    Try
                        Dim CurrentGridRow As System.Data.DataRow = DataTable.Rows(i)

                        Dim CurrentJobNumber As Integer = 0
                        Try
                            CurrentJobNumber = CType(CurrentGridRow("JOB_NUMBER"), Integer)
                        Catch ex As Exception
                            CurrentJobNumber = 0
                        End Try
                        Dim CurrentJobComponentNumber As Integer = 0
                        Try
                            CurrentJobComponentNumber = CType(CurrentGridRow("JOB_COMPONENT_NBR"), Integer)
                        Catch ex As Exception
                            CurrentJobComponentNumber = 0
                        End Try
                        If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                            ctr += 1
                            'Do something to send to alert window? selected items
                            With sb
                                .Append(CurrentJobNumber.ToString())
                                .Append(",")
                                .Append(CurrentJobComponentNumber.ToString())
                                .Append("|")
                            End With
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Risk Analysis Summary", "TrafficSchedule_Status_Summary.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ButtonRiskAnalysisSelected_Click(sender As Object, e As EventArgs) Handles ButtonRiskAnalysisSelected.Click
        Try
            Dim sb As New System.Text.StringBuilder
            Dim ctr As Integer = 0
            If RowCount > 0 Then
                For i As Integer = 0 To RowCount - 1
                    Try
                        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridProjectScheduleMultiview.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                        Dim chk As CheckBox
                        chk = CType(CurrentGridRow("ColClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            Dim CurrentJobNumber As Integer = 0
                            Try
                                CurrentJobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
                            Catch ex As Exception
                                CurrentJobNumber = 0
                            End Try
                            Dim CurrentJobComponentNumber As Integer = 0
                            Try
                                CurrentJobComponentNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
                            Catch ex As Exception
                                CurrentJobComponentNumber = 0
                            End Try
                            If CurrentJobNumber > 0 And CurrentJobComponentNumber > 0 Then
                                ctr += 1
                                'Do something to send to alert window? selected items
                                With sb
                                    .Append(CurrentJobNumber.ToString())
                                    .Append(",")
                                    .Append(CurrentJobComponentNumber.ToString())
                                    .Append("|")
                                End With
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
                If ctr = 0 Then
                    Exit Sub
                End If
                Session("TrafficScheduleMVJobs") = sb.ToString
                Me.OpenWindow("Risk Analysis Summary", "TrafficSchedule_Status_Summary.aspx")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
