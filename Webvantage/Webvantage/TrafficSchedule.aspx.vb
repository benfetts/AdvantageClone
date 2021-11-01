Imports System.Data.SqlClient

Partial Public Class TrafficSchedule
    Inherits Webvantage.BaseChildPage

#Region " Enum "

    Private Enum ColumnNames
        colTASK_STATUS
        colPHASE_DESC
        colJOB_ORDER
        colMilestone
        colJOB_DAYS
        colJOB_HRS
        colTASK_START_DATE
        colJOB_REVISED_DATE
        colDUE_TIME
        colLock
        colJOB_COMPLETED_DATE
        colEMP_CODE_TEXT_AUTO
        colEMP_CODE_TEXT
        colCLI_CONTACT_TEXT
        colEstimateFunction
        colFNC_COMMENTS
        colDUE_DATE_COMMENTS
        colREV_DATE_COMMENTS
        GridTemplateColumnSelectPreds
        ColumnLinked
        ColumnMove
        colEMP_CODE
        colCLI_CONTACT
        colCLI_CONTACT_IMGBTN
        GridTemplateColumnPreds
        GridTemplateColumnInputPreds
    End Enum

    Private Enum GridControls
        LabelLevelNotation
        ImageButtonMoveLeft
        ImageButtonMoveRight
        TextBoxJobOrder
        RadToolTipAddPredecessors
        ImageButtonAddPredecessors
        LabelPredecessorsLabel
        CheckBoxSelectPredecessor
        RadButtonLinked
        RadComboBoxTaskStatus
        RadComboBoxPhaseDescription
        TextBoxTaskCode
        HiddenFieldTaskCode
        ImageButtonTaskCode
        TextBoxTaskDescription
        CheckBoxMilestone
        TextBoxJobDays
        LabelJobDays
        TextBoxTaskStartDate
        LabelTaskStartDate
        TextBoxJobRevisedDate
        LabelJobRevisedDate
        ImageDueDateLock
        CheckBoxDueDateLock
        TextBoxRevisedDueTime
        HiddenFieldRevisedDueTime
        HiddenFieldDueTime
        TextBoxJobDueDate
        TextBoxJobCompletedDate
        TextBoxTemporaryCompleteDate
        LabelTemporaryCompleteDate
        TextBoxJobHours
        LinkButtonDispersedHours
        LabelDisbursedHours
        LabelPostedHours
        LabelPercentComplete
        LinkButtonEmployees
        TextBoxEmployees
        RadAutoCompleteBoxEmployees
        ImageButtonEmployees
        LinkButtonClientContacts
        TextBoxClientContacts
        ImageButtonClientContacts
        RadComboBoxEstimateFunction
        ImageButtonShowComments
        TextBoxFunctionComments
        TextBoxDueDateComments
        TextBoxRevisionDateComments
        ImageButtonSave
        ImageButtonDelete
        ImageButtonHasDocuments
        RadTextBoxPredecessors
    End Enum

    Private Enum SessionVars
        PS_Ignore_Filter
    End Enum

    Private Enum QueryStringVars
        JobNum
        JobComp
        P
        Role
        Task
        Emp
        Cut
        Pend
        Proj
        Comp
        seq
    End Enum

#End Region

#Region " Variables "

#Region " Public "

    Public _RowCount As Integer = 0
    Public _HeaderDatakey As String = ""

#End Region

#Region " Private "

    Private _SortString As String = "order"
    Private _RowIncrement As Integer = 0
    Private _ReloadMe As Boolean = False
    Private _CameFromJobTemplate As Boolean = False
    Private _TaskPhaseFilter As String = ""
    Private _RoleCode As String = ""
    Private _TaskCode As String = ""
    Private _EmployeeCode As String = ""
    Private _CutOffDate As String = ""
    Private _IncludeOnlyPendingTasks As Boolean = False
    Private _ExcludeProjectedTasks As Boolean = False
    Private _IncludeCompletedTasks As Boolean = False
    Private _UsingATaskLevelFilter As Boolean = False
    Private _IsAgencyRequiredEmail As Boolean = False
    Private _IsAutoEmailPromptOnNew As Boolean = False
    Private _IsAutoEmailPromptOnUpdate As Boolean = False
    Private _IsClientGetsEmailOnNew As Boolean = False
    Private _IsClientGetsEmailOnUpdate As Boolean = False
    Private _TaskFilterIndex As String = ""
    Private _AutoUpdateTrafficCode As Boolean = True
    Private _CanEditProjectSchedule As Boolean = True
    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _SequenceNumber As Integer = -1
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _Phases As System.Data.DataTable = Nothing
    Private _EstimateFunctions As System.Data.DataTable = Nothing
    Private _Columns As System.Data.DataTable = Nothing
    Private _DataLoaded As Boolean
    Private _CurrentDetailRowIsLocked As Boolean = False
    Private Shared _arP As System.Data.SqlClient.SqlParameter = Nothing
    Private _PageStatePersister As System.Web.UI.PageStatePersister = Nothing
    Private _IsJobDashboard As Boolean = False
    Private _LoadingDatasource As Boolean = False

#End Region

#Region "Protected "

    Protected WithEvents DropPhaseFilter As Telerik.Web.UI.RadComboBox = Nothing
    Protected WithEvents DropSort As Telerik.Web.UI.RadComboBox = Nothing

#End Region

#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer
        Get
            Dim Index As Integer = 0
            Try

                Index = CInt(ViewState("CurrentGridPageIndex"))

            Catch ex As Exception
                Index = 0
            End Try

            Return Index

        End Get
        Set(value As Integer)
            ViewState("CurrentGridPageIndex") = value
        End Set
    End Property
    Private Shared Property arP(p1 As Integer) As System.Data.SqlClient.SqlParameter
        Get
            Return _arP
        End Get
        Set(value As System.Data.SqlClient.SqlParameter)
            _arP = value
        End Set
    End Property
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get

            If _PageStatePersister Is Nothing Then

                _PageStatePersister = New System.Web.UI.SessionPageStatePersister(Me)

            End If

            Return _PageStatePersister

        End Get
    End Property
    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    If oTrafficSchedule.CalculateDateLocked = True Then
                        Me.RblCalcOnStartDate.Enabled = False
                        Me.RblCalcOnDueDate.Enabled = False
                    Else
                        ' TP Dim col As Telerik.Web.UI.GridColumn = Me.RadGridProjectSchedule.MasterTableView.GetColumn("colPREDECESSORS_TEXT")
                        'If col.Visible = True Then
                        '    Me.RblCalcOnDueDate.Enabled = False
                        '    Me.RblCalcOnDueDate.Checked = False
                        '    Me.RblCalcOnStartDate.Checked = True
                        'Else
                        Me.RblCalcOnDueDate.Enabled = True
                        'End If
                        Me.RblCalcOnStartDate.Enabled = True
                    End If
                    If _UsingATaskLevelFilter = True AndAlso Session("PS_Ignore_Filter") = "0" Then
                        Dim dt As DataTable
                        dt = oTrafficSchedule.GetScheduleTasks(_JobNumber, _JobComponentNumber, _SortString, CStr(Session("UserCode")), _EmployeeCode, _TaskCode, _RoleCode, _IncludeCompletedTasks, _IncludeOnlyPendingTasks, _ExcludeProjectedTasks, _CutOffDate, _TaskPhaseFilter)
                        _RowCount = dt.Rows.Count
                        Return dt
                    Else
                        Dim FilterValue As String = Me.DropPhaseFilter.SelectedValue
                        If FilterValue = "0" Then
                            FilterValue = "is_null"
                        End If
                        Dim dt As DataTable
                        dt = oTrafficSchedule.GetScheduleTasks(_JobNumber, _JobComponentNumber, _SortString, CStr(Session("UserCode")), "", "", "", Me.ChkShowCompletedTasks.Checked, False, False, "", FilterValue)
                        _RowCount = dt.Rows.Count
                        Return dt
                    End If
                    With Me.RadGridProjectSchedule
                        .Visible = True
                    End With
                End If
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property
    Public ReadOnly Property DataSource2() As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
        Get

            'objects
            Dim oTrafficSchedule As Webvantage.cSchedule = Nothing
            Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
            Dim ScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim FilterValue As String = Nothing

            Try

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    oTrafficSchedule = New Webvantage.cSchedule(Session("ConnString"), CStr(Session("UserCode")))

                    If oTrafficSchedule.CalculateDateLocked = True Then

                        Me.RblCalcOnStartDate.Enabled = False
                        Me.RblCalcOnDueDate.Enabled = False

                    Else

                        'TP GridColumn = Me.RadGridProjectSchedule.MasterTableView.GetColumn("colPREDECESSORS_TEXT")

                        'If GridColumn.Visible = True Then

                        '    Me.RblCalcOnDueDate.Enabled = False
                        '    Me.RblCalcOnDueDate.Checked = False
                        '    Me.RblCalcOnStartDate.Checked = True

                        'Else

                        Me.RblCalcOnDueDate.Enabled = True

                        'End If

                        Me.RblCalcOnStartDate.Enabled = True

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _UsingATaskLevelFilter = True AndAlso Session("PS_Ignore_Filter") = "0" Then

                            ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, _JobNumber, _JobComponentNumber, _SortString, CStr(Session("UserCode")), _EmployeeCode, _TaskCode, _RoleCode, _IncludeCompletedTasks, _IncludeOnlyPendingTasks, _ExcludeProjectedTasks, _CutOffDate, _TaskPhaseFilter, False, False, False, IsColumnVisible(ColumnNames.GridTemplateColumnPreds) OrElse IsColumnVisible(ColumnNames.GridTemplateColumnInputPreds))

                            _RowCount = ScheduleTaskList.Count

                            Return ScheduleTaskList

                        Else

                            FilterValue = Me.DropPhaseFilter.SelectedValue

                            If FilterValue = "0" Then

                                FilterValue = "is_null"

                            End If

                            ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(DbContext, _JobNumber, _JobComponentNumber, _SortString, CStr(Session("UserCode")), "", "", "", Me.ChkShowCompletedTasks.Checked, False, False, "", FilterValue, False, False, False, IsColumnVisible(ColumnNames.GridTemplateColumnPreds) OrElse IsColumnVisible(ColumnNames.GridTemplateColumnInputPreds))

                            _RowCount = ScheduleTaskList.Count

                            Return ScheduleTaskList

                        End If

                    End Using

                    With Me.RadGridProjectSchedule
                        .Visible = True
                    End With

                End If

            Catch ex As Exception
                Return New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            End Try

        End Get
    End Property
    Private Property CalculateByPredecessor() As Boolean
        Get
            Try

                CalculateByPredecessor = ViewState("CalculateByPredecessor")

            Catch ex As Exception
                CalculateByPredecessor = False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("CalculateByPredecessor") = value
        End Set
    End Property
    Private Property CalculateCommandName As String
        Get
            If ViewState("CalculateCommandName") IsNot Nothing Then

                Return ViewState("CalculateCommandName")

            Else

                Return "CalculateDates"

            End If
        End Get
        Set(value As String)

            ViewState("CalculateCommandName") = value

        End Set
    End Property

#End Region

#Region " Methods "

    Private Function IsColumnVisible(ByVal ColumnName As ColumnNames) As Boolean

        'objects
        Dim ColumnVisible As Boolean = False

        Try

            ColumnVisible = Me.RadGridProjectSchedule.MasterTableView.GetColumn(ColumnName.ToString).Visible

        Catch ex As Exception
            ColumnVisible = False
        Finally
            IsColumnVisible = ColumnVisible
        End Try

    End Function
    Private Function SaveGridRow(ByVal GridDataItem As Telerik.Web.UI.GridDataItem, Optional ByVal RebindGrid As Boolean = True) As String

        'objects
        Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
        Dim Validator As Webvantage.cValidations = Nothing
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim TaskCode As String = ""
        Dim TaskDescription As String = ""
        Dim IsValidTaskCode As Boolean = True
        Dim ClientContactID As Integer = 0
        Dim PhaseID As String = ""
        Dim OriginalDueDate As String = Nothing
        Dim RevisedDueDate As String = Nothing
        Dim DueTime As String = Nothing
        Dim OriginalDueTime As String = Nothing
        Dim RevisedDueTime As String = Nothing
        Dim EmployeesString As String = Nothing
        Dim ContactsString As String = Nothing
        Dim ContactIDsString As String = Nothing
        Dim ContactsArray As String() = Nothing
        Dim SequenceNumber As Short = Nothing
        Dim JobOrder As Integer = 0

        Try

            SequenceNumber = CShort(GridDataItem.GetDataKeyValue(AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber.ToString))

        Catch ex As Exception
            SequenceNumber = -1
        End Try

        JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(_DbContext, _JobNumber, _JobComponentNumber, SequenceNumber)

        If JobComponentTask IsNot Nothing Then

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            If IsColumnVisible(ColumnNames.colTASK_STATUS) = True Then

                JobComponentTask.StatusCode = DirectCast(FindGridControl(GridDataItem, GridControls.RadComboBoxTaskStatus), Telerik.Web.UI.RadComboBox).SelectedValue

            End If

            If IsColumnVisible(ColumnNames.colPHASE_DESC) = True Then

                PhaseID = DirectCast(FindGridControl(GridDataItem, GridControls.RadComboBoxPhaseDescription), Telerik.Web.UI.RadComboBox).SelectedValue

                If PhaseID <> "[None]" Then

                    JobComponentTask.PhaseID = CInt(PhaseID)

                Else

                    JobComponentTask.PhaseID = Nothing

                End If

            End If

            Validator = New Webvantage.cValidations(_Session.ConnectionString)

            TaskCode = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxTaskCode), System.Web.UI.WebControls.TextBox).Text.Trim()
            TaskDescription = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxTaskDescription), System.Web.UI.WebControls.TextBox).Text.Trim()

            If String.IsNullOrWhiteSpace(TaskCode) = False Then

                IsValidTaskCode = Validator.ValidateTaskCode(TaskCode)

                Try

                    Using DataTable = Schedule.GetAddNewFunctionData(TaskCode)

                        If DataTable.Rows.Count > 0 Then

                            If IsDBNull(DataTable.Rows(0)("TRF_DESC")) = False Then

                                TaskDescription = DataTable.Rows(0)("TRF_DESC").ToString.Trim

                            End If

                        End If

                    End Using

                Catch ex As Exception

                End Try

            End If

            If IsValidTaskCode Then

                JobComponentTask.TaskCode = TaskCode

            Else

                JobComponentTask.TaskCode = Nothing

            End If

            JobComponentTask.Description = TaskDescription

            If IsColumnVisible(ColumnNames.colMilestone) = True Then

                If DirectCast(FindGridControl(GridDataItem, GridControls.CheckBoxMilestone), System.Web.UI.WebControls.CheckBox).Checked Then

                    JobComponentTask.IsMilestone = 1

                Else

                    If JobComponentTask.IsMilestone.HasValue = True Then

                        JobComponentTask.IsMilestone = 0

                    End If

                End If

            End If

            If IsColumnVisible(ColumnNames.colJOB_ORDER) = True Then

                If IsNumeric(CType(FindGridControl(GridDataItem, GridControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox).Text) = True Then

                    JobComponentTask.OrderNumber = CShort(CType(FindGridControl(GridDataItem, GridControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox).Text)

                Else

                    JobComponentTask.OrderNumber = 0

                End If

            End If

            If IsColumnVisible(ColumnNames.colJOB_DAYS) = True Then

                If IsNumeric(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobDays), System.Web.UI.WebControls.TextBox).Text) Then

                    JobComponentTask.Days = CType(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobDays), System.Web.UI.WebControls.TextBox).Text, Short)

                Else

                    JobComponentTask.Days = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colJOB_HRS) = True Then

                If IsNumeric(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobHours), System.Web.UI.WebControls.TextBox).Text) Then

                    JobComponentTask.Hours = CType(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobHours), System.Web.UI.WebControls.TextBox).Text, Decimal)

                Else

                    JobComponentTask.Hours = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colTASK_START_DATE) = True Then

                If cGlobals.wvIsDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxTaskStartDate), System.Web.UI.WebControls.TextBox).Text) Then

                    JobComponentTask.StartDate = cGlobals.wvCDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxTaskStartDate), System.Web.UI.WebControls.TextBox).Text)

                ElseIf DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxTaskStartDate), System.Web.UI.WebControls.TextBox).Text.Trim = "" Then

                    JobComponentTask.StartDate = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colJOB_REVISED_DATE) = True Then

                If cGlobals.wvIsDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobDueDate), System.Web.UI.WebControls.TextBox).Text) Then

                    OriginalDueDate = cGlobals.wvCDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobDueDate), System.Web.UI.WebControls.TextBox).Text).ToShortDateString

                End If

                If cGlobals.wvIsDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobRevisedDate), System.Web.UI.WebControls.TextBox).Text) Then

                    RevisedDueDate = cGlobals.wvCDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobRevisedDate), System.Web.UI.WebControls.TextBox).Text).ToShortDateString

                End If

                If String.IsNullOrWhiteSpace(OriginalDueDate) AndAlso String.IsNullOrWhiteSpace(RevisedDueDate) Then

                    JobComponentTask.DueDate = Nothing

                ElseIf String.IsNullOrWhiteSpace(OriginalDueDate) AndAlso String.IsNullOrWhiteSpace(RevisedDueDate) = False Then

                    JobComponentTask.DueDate = RevisedDueDate
                    JobComponentTask.OriginalDueDate = RevisedDueDate

                ElseIf String.IsNullOrWhiteSpace(OriginalDueDate) = False AndAlso String.IsNullOrWhiteSpace(RevisedDueDate) Then

                    JobComponentTask.OriginalDueDate = OriginalDueDate
                    JobComponentTask.DueDate = Nothing

                ElseIf String.IsNullOrWhiteSpace(OriginalDueDate) = False AndAlso String.IsNullOrWhiteSpace(RevisedDueDate) = False Then

                    JobComponentTask.OriginalDueDate = OriginalDueDate
                    JobComponentTask.DueDate = RevisedDueDate

                End If

            End If

            If IsColumnVisible(ColumnNames.colDUE_TIME) = True Then

                DueTime = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxRevisedDueTime), System.Web.UI.WebControls.TextBox).Text
                OriginalDueTime = DirectCast(FindGridControl(GridDataItem, GridControls.HiddenFieldDueTime), System.Web.UI.WebControls.HiddenField).Value.Replace("&nbsp;", "")
                RevisedDueTime = DirectCast(FindGridControl(GridDataItem, GridControls.HiddenFieldRevisedDueTime), System.Web.UI.WebControls.HiddenField).Value.Replace("&nbsp;", "")

                If String.IsNullOrWhiteSpace(OriginalDueTime) AndAlso String.IsNullOrWhiteSpace(RevisedDueTime) Then

                    If String.IsNullOrWhiteSpace(DueTime) = False Then

                        JobComponentTask.OriginalDueTime = DueTime
                        JobComponentTask.DueTime = DueTime

                    End If

                ElseIf String.IsNullOrWhiteSpace(OriginalDueTime) = False AndAlso String.IsNullOrWhiteSpace(RevisedDueTime) Then

                    If String.IsNullOrWhiteSpace(DueTime) = False Then

                        JobComponentTask.DueTime = DueTime

                    Else

                        JobComponentTask.DueTime = Nothing

                    End If

                ElseIf String.IsNullOrWhiteSpace(OriginalDueTime) = False AndAlso String.IsNullOrWhiteSpace(RevisedDueTime) = False Then

                    If String.IsNullOrWhiteSpace(DueTime) = False Then

                        JobComponentTask.DueTime = DueTime

                    Else

                        JobComponentTask.DueTime = Nothing

                    End If

                End If

            End If

            If IsColumnVisible(ColumnNames.colLock) = True Then

                If DirectCast(FindGridControl(GridDataItem, GridControls.CheckBoxDueDateLock), System.Web.UI.WebControls.CheckBox).Checked Then

                    JobComponentTask.IsDueDateLocked = 1

                Else

                    If JobComponentTask.IsDueDateLocked.HasValue Then

                        JobComponentTask.IsDueDateLocked = 0

                    End If

                End If

            End If

            If IsColumnVisible(ColumnNames.colJOB_COMPLETED_DATE) = True Then

                If cGlobals.wvIsDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobCompletedDate), System.Web.UI.WebControls.TextBox).Text) Then

                    JobComponentTask.CompletedDate = cGlobals.wvCDate(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobCompletedDate), System.Web.UI.WebControls.TextBox).Text)

                ElseIf String.IsNullOrWhiteSpace(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxJobCompletedDate), System.Web.UI.WebControls.TextBox).Text) = True Then

                    JobComponentTask.CompletedDate = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colEMP_CODE_TEXT_AUTO) = True Then

                EmployeesString = GetCommaDelimitedStringOfEmployeeCodes(DirectCast(FindGridControl(GridDataItem, GridControls.RadAutoCompleteBoxEmployees), Telerik.Web.UI.RadAutoCompleteBox))
                EmployeesString = MiscFN.RemoveDuplicatesFromString(EmployeesString, ",")

            End If

            If IsColumnVisible(ColumnNames.colEMP_CODE_TEXT) = True Then

                EmployeesString = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxEmployees), System.Web.UI.WebControls.TextBox).Text
                EmployeesString = MiscFN.RemoveDuplicatesFromString(EmployeesString, ",")

            End If

            If IsColumnVisible(ColumnNames.colCLI_CONTACT_TEXT) = True Then

                ContactsString = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxClientContacts), System.Web.UI.WebControls.TextBox).Text
                ContactsString = MiscFN.RemoveDuplicatesFromString(ContactsString, ",")
                ContactsArray = ContactsString.Split(",")

                For Each Contact In ContactsArray

                    If String.IsNullOrWhiteSpace(Contact) = False Then

                        ClientContactID = Schedule.WVGetContactCodeID(Contact, HiddenFieldClientCode.Value, HiddenFieldDivisionCode.Value, HiddenFieldProductCode.Value)

                        If ClientContactID <> 0 Then

                            If Schedule.WVCheckContactCodeIDScheduleUser(ClientContactID) = 1 AndAlso Schedule.WVCheckContactCodeIDInactive(ClientContactID) = 0 Then

                                ContactIDsString &= ClientContactID & ","

                            End If

                        End If

                    End If

                Next

            End If

            If IsColumnVisible(ColumnNames.colEstimateFunction) = True Then

                If DirectCast(FindGridControl(GridDataItem, GridControls.RadComboBoxEstimateFunction), Telerik.Web.UI.RadComboBox).SelectedIndex > 0 Then

                    JobComponentTask.FuctionCode = DirectCast(FindGridControl(GridDataItem, GridControls.RadComboBoxEstimateFunction), Telerik.Web.UI.RadComboBox).SelectedValue

                Else

                    JobComponentTask.FuctionCode = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colFNC_COMMENTS) = True Then

                If String.IsNullOrWhiteSpace(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxFunctionComments), System.Web.UI.WebControls.TextBox).Text) = False Then

                    JobComponentTask.Comment = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxFunctionComments), System.Web.UI.WebControls.TextBox).Text

                Else

                    JobComponentTask.Comment = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colDUE_DATE_COMMENTS) = True Then

                If String.IsNullOrWhiteSpace(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxDueDateComments), System.Web.UI.WebControls.TextBox).Text) = False Then

                    JobComponentTask.OriginalDueDateComment = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxDueDateComments), System.Web.UI.WebControls.TextBox).Text

                Else

                    JobComponentTask.OriginalDueDateComment = Nothing

                End If

            End If

            If IsColumnVisible(ColumnNames.colREV_DATE_COMMENTS) = True Then

                If String.IsNullOrWhiteSpace(DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxRevisionDateComments), System.Web.UI.WebControls.TextBox).Text) = False Then

                    JobComponentTask.DueDateComment = DirectCast(FindGridControl(GridDataItem, GridControls.TextBoxRevisionDateComments), System.Web.UI.WebControls.TextBox).Text

                Else

                    JobComponentTask.DueDateComment = Nothing

                End If

            End If

        End If

        AdvantageFramework.Database.Procedures.JobComponentTask.Update(_DbContext, JobComponentTask)

        If IsColumnVisible(ColumnNames.colEMP_CODE_TEXT) = True Or IsColumnVisible(ColumnNames.colEMP_CODE_TEXT_AUTO) = True Then

            Me.SaveEmpList(_JobNumber, _JobComponentNumber, SequenceNumber, EmployeesString)

        End If

        If IsColumnVisible(ColumnNames.colCLI_CONTACT_TEXT) = True Then

            If ContactIDsString <> "" Then

                ContactIDsString = ContactIDsString.Substring(0, ContactIDsString.Length - 1)

            End If

            Me.SaveContactList(_JobNumber, _JobComponentNumber, SequenceNumber, ContactIDsString)

        End If

        'Try

        '    Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

        '        SyncWithOutlook = AdvantageFramework.Calendar.Outlook.IsSyncWithOutlookEnabled(DataContext)

        '    End Using

        'Catch ex As Exception
        '    SyncWithOutlook = False
        'Finally

        '    If SyncWithOutlook Then

        '        AdvantageFramework.Calendar.Outlook.SyncJobComponentTask(Session("ConnString").ToString(), Session("UserCode").ToString, JobNumber, JobComponentNumber, SequenceNumber, False)

        '    End If

        'End Try

        If RebindGrid = True Then

            Me.RadGridProjectSchedule.Rebind()

        End If

    End Function
    'Private Function GetLevelNotation(ByVal ItemIndexHierarchical As String) As String

    '    'objects
    '    Dim Levels As Generic.List(Of Integer) = Nothing

    '    Levels = New Generic.List(Of Integer)

    '    For Each Level In (From lvl In ItemIndexHierarchical.Split(":") _
    '                                   Select l = CInt(lvl.Split("_").Last)).ToList

    '        Levels.Add(Level + 1)

    '    Next

    '    GetLevelNotation = String.Join(".", Levels)

    'End Function
    Private Function DeleteGridRow(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer) As String

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DocumentIDs As Integer() = Nothing
        Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
        Dim DocumentsToDelete As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            Try

                DocumentIDs = _DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.JOB_TRAFFIC_DET_DOCS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2}", JobNumber, JobComponentNumber, SequenceNumber)).ToArray

            Catch ex As Exception

            End Try

            Schedule.DeleteTask(JobNumber, JobComponentNumber, SequenceNumber)

            If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                DocumentsToDelete = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                For Each DocumentID In DocumentIDs

                    Document = Nothing

                    Try

                        If _DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_TRAFFIC_VER_DET_DOCS WHERE DOCUMENT_ID = {0}", DocumentID)).FirstOrDefault = 0 Then

                            Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(_DbContext, DocumentID)

                            If Document IsNot Nothing Then

                                DocumentsToDelete.Add(Document)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                Next

                If DocumentsToDelete IsNot Nothing AndAlso DocumentsToDelete.Count > 0 Then

                    AdvantageFramework.Database.Procedures.Document.Delete(_DbContext, DocumentsToDelete)

                End If

            End If

        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function
    Private Function BlankDT() As System.Data.DataTable

        'objects
        Dim DataTable As System.Data.DataTable = Nothing

        DataTable = New System.Data.DataTable

        Return DataTable

    End Function
    Private Sub AutoAlerts(ByVal SaveSuccessful As Boolean)

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim AlertRequirements As System.Data.DataTable = Nothing
        Dim RequirementDescription As String = Nothing
        Dim RowRequired As Boolean = False
        Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
        Dim AlertPopUpTitle As String = Nothing
        Dim AlertPopUpBody As String = Nothing
        Dim AlertBody As String = Nothing
        Dim IsNew As Boolean = False
        Dim URLRedirectToReadOnly As String = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim Alerts As Webvantage.cAlerts = Nothing
        Dim Employee As Webvantage.cEmployee = Nothing
        Dim EmailGroup As String = Nothing
        Dim URLPopEmail As String = Nothing
        Dim EmailFlag As Integer = Nothing
        Dim AlertID As Integer = Nothing
        Dim WebServices As Webvantage.cWebServices = Nothing

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            AlertRequirements = New System.Data.DataTable("AlertReqs")
            AlertRequirements = Schedule.GetAlertRequirements(_JobNumber, _JobComponentNumber, Me.HiddenFieldClientCode.Value, Me.HiddenFieldDivisionCode.Value, Me.HiddenFieldProductCode.Value)

            For Each DataRow In AlertRequirements.Rows.OfType(Of System.Data.DataRow)()

                RowRequired = False

                RequirementDescription = DataRow("ReqDescript")

                If DataRow("IsRequired") = "1" Then

                    RowRequired = True

                End If

                Select Case RequirementDescription

                    Case "AgencyRequiredEmail"

                        _IsAgencyRequiredEmail = RowRequired

                    Case "AutoEmailPromptOnNew"

                        _IsAutoEmailPromptOnNew = RowRequired

                    Case "AutoEmailPromptOnUpdate"

                        _IsAutoEmailPromptOnUpdate = RowRequired

                    Case "ClientGetsEmailOnNewJS"

                        _IsClientGetsEmailOnNew = RowRequired

                    Case "ClientGetsEmailOnUpdateJS"

                        _IsClientGetsEmailOnUpdate = RowRequired

                End Select

            Next

            If SaveSuccessful = True Then

                JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(_DbContext, _JobNumber, _JobComponentNumber)

                URLRedirectToReadOnly = Server.UrlDecode("location.href=""Content.aspx?PageMode=Edit&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber & "&NewComp=0" & """")

                Try

                    If Request.QueryString("NewSchedule") = "1" Then   'this is a new job

                        AlertPopUpTitle = "Project Schedule - Job/Comp " & _JobNumber.ToString.PadLeft(6, "0") & "/01 - " & JobComponentView.JobComponentDescription & " for client " & JobComponentView.ClientCode & " created by " & Session("EmployeeName")
                        IsNew = True

                    ElseIf IsNumeric(_JobNumber) AndAlso IsNumeric(_JobComponentNumber) Then 'this is an edit

                        AlertPopUpTitle = "Existing Project Schedule - Job/Comp - " & _JobNumber.ToString.PadLeft(6, "0") & "-" & _JobComponentNumber.ToString.PadLeft(2, "0") & " - " & JobComponentView.JobComponentDescription & " for client " & JobComponentView.ClientCode & " modified by " & Session("EmployeeName")
                        IsNew = False

                    End If

                    AlertPopUpBody = AlertBody

                Catch ex As Exception
                    Me.ShowMessage("Error in getting QS vars: " & ex.Message.ToString())
                End Try

                StringBuilder = New System.Text.StringBuilder

                Alerts = New Webvantage.cAlerts(_Session.ConnectionString)
                Employee = New Webvantage.cEmployee(_Session.ConnectionString)

                EmailGroup = Alerts.GetDefaultGroup(Me.HiddenFieldClientCode.Value, Me.HiddenFieldDivisionCode.Value, Me.HiddenFieldProductCode.Value, _JobNumber, _JobComponentNumber)

                Try

                    With StringBuilder

                        .Append("?")
                        .Append("EmailGroup=" & EmailGroup.Replace("/", "-").Replace("&", "and").Replace("'", "").Replace(",", ""))
                        .Append("&DivCode=" & Me.HiddenFieldDivisionCode.Value)
                        .Append("&JobCompNo=" & _JobComponentNumber)
                        .Append("&JobNo=" & _JobNumber)
                        .Append("&ProdCode=" & Me.HiddenFieldProductCode.Value)
                        .Append("&Recipients=" & "")
                        .Append("&ClientCode=" & Me.HiddenFieldClientCode.Value)

                        If IsNew = True Then

                            .Append("&New=1")
                        Else

                            .Append("&New=0")

                        End If

                    End With
                Catch ex As Exception
                    Me.ShowMessage("Error setting sbQSVars: " & ex.Message.ToString())
                End Try

                Try

                    'st:   test using session instead of qs to pass what could potentially be too much data for a qs
                    Session("AlertPopUp_Title") = AlertPopUpTitle
                    Session("AlertPopUp_Body") = AlertPopUpBody

                Catch ex As Exception
                    Me.ShowMessage("Error in setting pop up body and title from session: " & ex.Message.ToString())
                End Try

                Try

                    URLPopEmail = Server.UrlDecode("window.open('popup_email_alert.aspx" & StringBuilder.ToString() & "','','screenX=150,left=150,screenY=150,top=150,width=310,height=575,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")

                    If _IsAgencyRequiredEmail = True Then

                        Try

                            If _IsClientGetsEmailOnUpdate = True AndAlso Request.QueryString("NewJob") <> "1" AndAlso Request.QueryString("NewComp") <> "new" Then

                                If _IsAutoEmailPromptOnUpdate = True Then   'do prompt check here   , if prompt is true

                                    PageLoadJS(URLPopEmail)

                                Else 'prompt is false , Send silent
                                    'loop through the group and send silent the email:
                                    Try

                                        Using SqlDataReader = GetEmailAddressFromGroup(EmailGroup)

                                            Alerts = New Webvantage.cAlerts(_Session.ConnectionString)

                                            AlertID = Alerts.AddAlerts(2, 4, AlertPopUpTitle, AlertPopUpBody, Now, "", Me.HiddenFieldClientCode.Value, Me.HiddenFieldDivisionCode.Value, Me.HiddenFieldProductCode.Value, "",
                                            _JobNumber, _JobComponentNumber, Session("EmpCode"), "JC", _Session.UserCode)

                                            If Not SqlDataReader Is Nothing Then

                                                If SqlDataReader.HasRows = True Then

                                                    WebServices = New Webvantage.cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

                                                    Do While SqlDataReader.Read()

                                                        If IsDBNull(SqlDataReader(1)) = False Then

                                                            EmailFlag = Employee.GetAlertEmailFlag(SqlDataReader.GetString(0))

                                                            If EmailFlag = 1 Then

                                                                If WebServices.SendEmail("", SqlDataReader.GetString(1), AlertPopUpTitle, AlertPopUpBody) = False Then

                                                                    Me.ShowMessage(WebServices.getErrMsg)

                                                                End If

                                                            ElseIf EmailFlag = 2 Then

                                                                Alerts.AddAlertRecipient(AlertID, SqlDataReader.GetString(0), SqlDataReader.GetString(1))

                                                            ElseIf EmailFlag = 3 Then

                                                                If WebServices.SendEmail("", SqlDataReader.GetString(1), AlertPopUpTitle, AlertPopUpBody) = False Then

                                                                    Me.ShowMessage(WebServices.getErrMsg)

                                                                End If

                                                                Alerts.AddAlertRecipient(AlertID, SqlDataReader.GetString(0), SqlDataReader.GetString(1))

                                                            End If

                                                        End If

                                                    Loop

                                                End If

                                            End If

                                        End Using

                                        PageLoadJS(URLRedirectToReadOnly)
                                        Exit Sub

                                    Catch ex As Exception
                                        Me.ShowMessage("Error in PopEmailUpdate conditional else case: " & ex.Message.ToString())
                                    End Try

                                End If

                            ElseIf _IsClientGetsEmailOnNew = True AndAlso (Request.QueryString("NewJob") = "1" OrElse Request.QueryString("NewComp") = "new") Then

                                Try

                                    If _IsAutoEmailPromptOnNew = True AndAlso (Request.QueryString("NewJob") = "1" OrElse Request.QueryString("NewComp") = "new") Then

                                        PageLoadJS(URLPopEmail)

                                    Else

                                        Try

                                            Using SqlDataReader = GetEmailAddressFromGroup(EmailGroup)

                                                Alerts = New Webvantage.cAlerts(_Session.ConnectionString)

                                                AlertID = Alerts.AddAlerts(2, 3, AlertPopUpTitle, AlertPopUpBody, Now, "", Me.HiddenFieldClientCode.Value, Me.HiddenFieldDivisionCode.Value, Me.HiddenFieldProductCode.Value, "",
                                                                           _JobNumber, _JobComponentNumber, Session("EmpCode"), "JC", Session("UserCode"))

                                                If Not SqlDataReader Is Nothing Then

                                                    If SqlDataReader.HasRows = True Then

                                                        WebServices = New Webvantage.cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

                                                        Do While SqlDataReader.Read()

                                                            If IsDBNull(SqlDataReader(1)) = False Then

                                                                EmailFlag = Employee.GetAlertEmailFlag(SqlDataReader.GetString(0))

                                                                If EmailFlag = 1 Then

                                                                    If WebServices.SendEmail("", SqlDataReader.GetString(1), AlertPopUpTitle, AlertPopUpBody) = False Then

                                                                        Me.ShowMessage(WebServices.getErrMsg)

                                                                    End If

                                                                ElseIf EmailFlag = 2 Then

                                                                    Alerts.AddAlertRecipient(AlertID, SqlDataReader.GetString(0), SqlDataReader.GetString(1))

                                                                ElseIf EmailFlag = 3 Then

                                                                    If WebServices.SendEmail("", SqlDataReader.GetString(1), AlertPopUpTitle, AlertPopUpBody) = False Then

                                                                        Me.ShowMessage(WebServices.getErrMsg)

                                                                    End If

                                                                    Alerts.AddAlertRecipient(AlertID, SqlDataReader.GetString(0), SqlDataReader.GetString(1))

                                                                End If

                                                            End If

                                                        Loop

                                                    End If

                                                End If

                                            End Using

                                            PageLoadJS(URLRedirectToReadOnly)
                                            Exit Sub

                                        Catch ex As Exception
                                            Me.ShowMessage("Error in getting pop email new loop: " & ex.Message.ToString())
                                        End Try

                                    End If

                                Catch ex As Exception
                                    Me.ShowMessage("Error in PopEmailNew conditional: " & ex.Message.ToString())
                                End Try

                            Else

                                Try

                                    Alerts = New Webvantage.cAlerts(_Session.ConnectionString)

                                    'AlertID = oAlert.AddAlerts(2, 4, strAlertPopUp_title, strAlertPopUp_body, Now, "", Me.Jobpanel1.PanelClient, Me.Jobpanel1.PanelDivision, Me.Jobpanel1.PanelProduct, "", _
                                    'JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))
                                    PageLoadJS(URLRedirectToReadOnly)

                                    Exit Sub

                                Catch ex As Exception
                                    Me.ShowMessage("Error in popEmailNew conditional for else case: " & ex.Message.ToString())
                                End Try

                            End If

                        Catch ex As Exception
                            Me.ShowMessage("Error saving when ClientGetsEmail on Update is true: " & ex.Message.ToString())
                            Exit Sub
                        Finally

                        End Try

                    Else

                        PageLoadJS(URLRedirectToReadOnly)
                        Exit Sub

                    End If

                Catch ex As Exception
                    Me.ShowMessage("Error saving when autoemail is true: " & ex.Message.ToString())
                    Exit Sub
                Finally

                End Try

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckForPredecessors()

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From JobTrafficPred In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Load(DbContext)
                    Where JobTrafficPred.JobPredecessor = _JobNumber AndAlso
                          JobTrafficPred.JobComponentPredecessor = _JobComponentNumber
                    Select JobTrafficPred).Any = True Then

                    Me.CalculateCommandName = "CalculateDates"
                    Me.ButtonDatesCalculate.Attributes.Remove("onclick")
                    Me.ButtonDatesCalculate.Attributes.Add("onclick", "return confirm('This job is a predecessor.  All jobs associated with this job will be calculated.  Are you sure you want to calculate?');")

                Else

                    Me.CalculateCommandName = "Calculate"
                    Me.ButtonDatesCalculate.Attributes.Remove("onclick")

                End If

            End Using

        Catch ex As Exception

            Me.CalculateCommandName = "Calculate"

        End Try

    End Sub
    Private Sub checkEstApproval()

        'objects
        Dim Estimating As Webvantage.cEstimating = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim EstimateNumber As Integer
        Dim EstimateComponentNumber As Integer

        Try

            Estimating = New Webvantage.cEstimating(_Session.ConnectionString, _Session.UserCode)

            DataTable = Estimating.GetEstimateData(0, 0, _JobNumber, _JobComponentNumber, Session("UserCode"))

            If DataTable.Rows.Count > 0 Then

                If IsDBNull(DataTable.Rows(0)("ESTIMATE_NUMBER")) = False Then

                    EstimateNumber = DataTable.Rows(0)("ESTIMATE_NUMBER")

                End If

                If IsDBNull(DataTable.Rows(0)("EST_COMPONENT_NBR")) = False Then

                    EstimateComponentNumber = DataTable.Rows(0)("EST_COMPONENT_NBR")

                End If

            End If

            Using SqlDataReader = Estimating.GetApprovals(EstimateNumber, EstimateComponentNumber, "")

                Using SqlDataReader2 = Estimating.GetInternalApprovals(EstimateNumber, EstimateComponentNumber, "")

                    If SqlDataReader.HasRows = False AndAlso SqlDataReader2.HasRows = False Then

                        Me.ButtonAddTasksCreateFromEstimate.Enabled = False

                    Else

                        Me.ButtonAddTasksCreateFromEstimate.Enabled = True

                    End If

                End Using

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckUserRights()

        'objects
        Dim Security As Webvantage.cSecurity = Nothing
        Dim CanView As String = ""
        Dim CanEdit As String = ""
        Dim CanInsert As String = ""
        Dim Custom1 As String = ""

        Try

            Security = New Webvantage.cSecurity(_Session.ConnectionString)

            CanView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            CanEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            CanInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")
            Custom1 = IIf(Me.UserCanCustom1Module(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), "Y", "N")

            If CanView = "" AndAlso Me.IsClientPortal = False Then

                Me.RadToolbarSchedule.FindItemByValue("Print").Enabled = False

            End If

            If CanEdit = "N" AndAlso CanInsert = "N" Then

                Me.RadToolbarSchedule.FindItemByValue("SaveHeader").Enabled = False
                Me.RadToolbarSchedule.FindItemByValue("New").Enabled = False

                Me.TxtComments.ReadOnly = True
                Me.RadDatePickerDateShipped.Enabled = False
                Me.RadDatePickerDateDelivered.Enabled = False
                Me.TxtReceivedBy.ReadOnly = True
                Me.TxtReference.ReadOnly = True

                If Custom1 = "N" Then

                    Me.HlASSIGN_1.Attributes.Add("onclick", "")
                    Me.HlASSIGN_1.Enabled = False
                    Me.TxtASSIGN_1Code.ReadOnly = True
                    Me.TxtASSIGN_1Description.ReadOnly = True
                    Me.HlASSIGN_2.Attributes.Add("onclick", "")
                    Me.HlASSIGN_2.Enabled = False
                    Me.TxtASSIGN_2Code.ReadOnly = True
                    Me.TxtASSIGN_2Description.ReadOnly = True
                    Me.HlASSIGN_3.Attributes.Add("onclick", "")
                    Me.HlASSIGN_3.Enabled = False
                    Me.TxtASSIGN_3Code.ReadOnly = True
                    Me.TxtASSIGN_3Description.ReadOnly = True
                    Me.HlASSIGN_4.Attributes.Add("onclick", "")
                    Me.HlASSIGN_4.Enabled = False
                    Me.TxtASSIGN_4Code.ReadOnly = True
                    Me.TxtASSIGN_4Description.ReadOnly = True
                    Me.HlASSIGN_5.Attributes.Add("onclick", "")
                    Me.HlASSIGN_5.Enabled = False
                    Me.TxtASSIGN_5Code.ReadOnly = True
                    Me.TxtASSIGN_5Description.ReadOnly = True

                End If

                Me.RadDatePickerStartDate.Enabled = False
                Me.RadDatePickerDueDate.Enabled = False
                Me.RadDatePickerJobCompleted.Enabled = False
                Me.TextboxGutPercentComplete.ReadOnly = True

                Me.HlTrafficStatus.Attributes.Add("onclick", "")
                Me.HlTrafficStatus.Enabled = False
                Me.TxtTrafficStatusCode.ReadOnly = True
                Me.TxtTrafficStatusDescription.ReadOnly = True
                Me.ChkShowCompletedTasks.Enabled = False

                Me.ButtonAddTasksFromListOfTasks.Enabled = False
                Me.ButtonAddTasksFromTaskTemplates.Enabled = False
                Me.ButtonAddTasksCopyFromExistingSchedule.Enabled = False
                Me.ButtonDatesCalculate.Enabled = False
                Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarSplitButtonOriginalDueDate").Enabled = False

                Me.ButtonEmployeesSetTeamByFunction.Enabled = False
                Me.ButtonEmployeesSetTeamByRole.Enabled = False
                Me.ButtonEmployeesFind.Enabled = False
                Me.ButtonEmployeesClearAllAssignments.Enabled = False
                Me.ButtonSearchAndReplaceInTasks.Enabled = False
                Me.ButtonDeleteSelectedTasks.Enabled = False
                Me.ButtonAddTasksCreateFromEstimate.Enabled = False
                Me.ButtonEmployeesSetTeamByFunction.Enabled = False
                Me.ButtonEmployeesSetTeamByRole.Enabled = False
                _CanEditProjectSchedule = False

            ElseIf CanEdit = "Y" AndAlso CanInsert = "N" Then

                Me.RadToolbarSchedule.FindItemByValue("New").Enabled = False

            ElseIf CanEdit = "N" AndAlso CanInsert = "Y" Then

                Me.RadToolbarSchedule.FindItemByValue("SaveHeader").Enabled = False

                Me.TxtComments.ReadOnly = True
                Me.RadDatePickerDateShipped.Enabled = False
                Me.RadDatePickerDateDelivered.Enabled = False
                Me.TxtReceivedBy.ReadOnly = True
                Me.TxtReference.ReadOnly = True

                If Custom1 = "N" Then

                    Me.HlASSIGN_1.Attributes.Add("onclick", "")
                    Me.HlASSIGN_1.Enabled = False
                    Me.TxtASSIGN_1Code.ReadOnly = True
                    Me.TxtASSIGN_1Description.ReadOnly = True
                    Me.HlASSIGN_2.Attributes.Add("onclick", "")
                    Me.HlASSIGN_2.Enabled = False
                    Me.TxtASSIGN_2Code.ReadOnly = True
                    Me.TxtASSIGN_2Description.ReadOnly = True
                    Me.HlASSIGN_3.Attributes.Add("onclick", "")
                    Me.HlASSIGN_3.Enabled = False
                    Me.TxtASSIGN_3Code.ReadOnly = True
                    Me.TxtASSIGN_3Description.ReadOnly = True
                    Me.HlASSIGN_4.Attributes.Add("onclick", "")
                    Me.HlASSIGN_4.Enabled = False
                    Me.TxtASSIGN_4Code.ReadOnly = True
                    Me.TxtASSIGN_4Description.ReadOnly = True
                    Me.HlASSIGN_5.Attributes.Add("onclick", "")
                    Me.HlASSIGN_5.Enabled = False
                    Me.TxtASSIGN_5Code.ReadOnly = True
                    Me.TxtASSIGN_5Description.ReadOnly = True

                End If

                Me.RadDatePickerStartDate.Enabled = False
                Me.RadDatePickerDueDate.Enabled = False
                Me.RadDatePickerJobCompleted.Enabled = False
                Me.TextboxGutPercentComplete.ReadOnly = True

                Me.HlTrafficStatus.Attributes.Add("onclick", "")
                Me.HlTrafficStatus.Enabled = False
                Me.TxtTrafficStatusCode.ReadOnly = True
                Me.TxtTrafficStatusDescription.ReadOnly = True
                Me.ChkShowCompletedTasks.Enabled = False

                Me.ButtonAddTasksFromListOfTasks.Enabled = False
                Me.ButtonAddTasksFromTaskTemplates.Enabled = False
                Me.ButtonAddTasksCopyFromExistingSchedule.Enabled = False
                Me.ButtonDatesCalculate.Enabled = False
                Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarSplitButtonOriginalDueDate").Enabled = False
                Me.ButtonEmployeesSetTeamByFunction.Enabled = False
                Me.ButtonEmployeesSetTeamByRole.Enabled = False
                Me.ButtonEmployeesFind.Enabled = False
                Me.ButtonEmployeesClearAllAssignments.Enabled = False
                Me.ButtonSearchAndReplaceInTasks.Enabled = False
                Me.ButtonDeleteSelectedTasks.Enabled = False
                Me.ButtonAddTasksCreateFromEstimate.Enabled = False
                Me.ButtonEmployeesSetTeamByFunction.Enabled = False
                Me.ButtonEmployeesSetTeamByRole.Enabled = False
                _CanEditProjectSchedule = False

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Function GetEmailAddressFromGroup(ByVal EmailGroupString As String) As System.Data.SqlClient.SqlDataReader

        'objects
        Dim SqlHelper As Webvantage.SqlHelper = Nothing
        Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
        Dim SqlParameters As System.Data.SqlClient.SqlParameter() = Nothing

        Try

            If String.IsNullOrWhiteSpace(EmailGroupString) = False Then

                SqlParameters = {New System.Data.SqlClient.SqlParameter("@EmailGroup", SqlDbType.VarChar, 50) With {.Value = EmailGroupString}}

                SqlDataReader = SqlHelper.ExecuteReader(_Session.ConnectionString, CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", SqlParameters)

            End If

            Return SqlDataReader

        Catch ex As Exception

        End Try

    End Function
    Private Sub PageLoadJS(ByVal JavascriptString As String)

        'objects
        Dim FullJavaScriptString As String = String.Empty

        FullJavaScriptString = "<script type=""text/javascript"">function init() { " & JavascriptString & " } window.onload = init;</script>"

        If Not Page.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then

            Page.RegisterStartupScript("JSAlert", FullJavaScriptString)

        End If

    End Sub
    Private Sub SaveGrid(Optional ByVal RebindGrid As Boolean = True)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim SequenceNumber As Short = -1

        _RowCount = Me.RadGridProjectSchedule.MasterTableView.Items.Count

        If _RowCount > 0 Then

            For RowIndex = 0 To RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem).Count - 1

                GridDataItem = RadGridProjectSchedule.Items(RowIndex)

                Try

                    SequenceNumber = GridDataItem.GetDataKeyValue("SequenceNumber")

                Catch ex As Exception
                    SequenceNumber = -1
                End Try

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

                    SaveGridRow(GridDataItem, False)

                End If

            Next

            For Each GridDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            Next

            If RebindGrid = True Then

                Me.RadGridProjectSchedule.Rebind()

            End If

        End If

    End Sub
    Private Sub SaveCalculate()

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim CalculateByPredecessor As Integer = -1

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            If Me.RadToolBarButtonJobOrder.Value = "Order" Then

                CalculateByPredecessor = 0

            End If

            If Me.RadToolBarButtonJobOrder.Value = "Predecessor" Then

                CalculateByPredecessor = 1

            End If

            Schedule.UpdateScheduleDetailCalculate(_JobNumber, _JobComponentNumber, CalculateByPredecessor)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub SaveScheduleDetails(ByVal SaveStatusAuto As Boolean) 'don't need the param...

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim StartDate As String = ""
        Dim DueDate As String = ""
        Dim CompletedDate As String = ""

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            _AutoUpdateTrafficCode = Me.RadToolBarButtonUpdateStatus.Checked 'MiscFN.ToolbarButtonToggleIsToggled(Me.RadToolbarSchedule, 3)
            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            Try

                If Me.RadDatePickerStartDate.SelectedDate.HasValue = True Then

                    StartDate = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString

                Else

                    StartDate = ""

                End If

            Catch ex As Exception

            End Try

            Try

                If Me.RadDatePickerDueDate.SelectedDate.HasValue = True Then

                    DueDate = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString

                Else

                    DueDate = ""

                End If

            Catch ex As Exception

            End Try

            Try

                If Me.RadDatePickerJobCompleted.SelectedDate.HasValue = True Then

                    CompletedDate = CType(Me.RadDatePickerJobCompleted.SelectedDate, Date).ToShortDateString

                Else

                    CompletedDate = ""

                End If

            Catch ex As Exception

            End Try

            Try

                If Me.TextboxGutPercentComplete.Text = "" Then

                    Me.TextboxGutPercentComplete.Text = "0.00"

                End If

            Catch ex As Exception

            End Try

            Schedule.UpdateScheduleDetails(_JobNumber, _JobComponentNumber, StartDate, DueDate, Me.TxtTrafficStatusCode.Text, _AutoUpdateTrafficCode,
                                           Me.RblCalcOnStartDate.Checked, CompletedDate, Me.TextboxGutPercentComplete.Text)

        End If

    End Sub
    Private Sub SaveOtherInformation()

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DateShipped As String = ""
        Dim DateDelivered As String = ""

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            Try

                If Me.RadDatePickerDateShipped.SelectedDate.HasValue = True Then

                    DateShipped = CType(Me.RadDatePickerDateShipped.SelectedDate, Date).ToShortDateString

                Else

                    DateShipped = ""

                End If

            Catch ex As Exception

            End Try

            Try

                If Me.RadDatePickerDateDelivered.SelectedDate.HasValue = True Then

                    DateDelivered = CType(Me.RadDatePickerDateDelivered.SelectedDate, Date).ToShortDateString

                Else

                    DateDelivered = ""

                End If

            Catch ex As Exception

            End Try

            Schedule.UpdateScheduleOtherInformation(_JobNumber, _JobComponentNumber, DateShipped, DateDelivered, Me.TxtReceivedBy.Text, Me.TxtReference.Text)

        End If

    End Sub
    Private Sub SaveScheduleComments()

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Schedule = New cSchedule(_Session.ConnectionString, _Session.UserCode)

            Schedule.UpdateScheduleComment(_JobNumber, _JobComponentNumber, Me.TxtComments.Text)

        End If

    End Sub
    Private Sub SaveScheduleAssignements()

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            Schedule.UpdateScheduleAssignments(_JobNumber, _JobComponentNumber, Me.TxtASSIGN_1Code.Text.Trim(), Me.TxtASSIGN_2Code.Text.Trim(),
                                               Me.TxtASSIGN_3Code.Text.Trim(), Me.TxtASSIGN_4Code.Text.Trim(), Me.TxtASSIGN_5Code.Text.Trim(),
                                               Me.HfOld_ASSIGN1.Value.Trim(), Me.HfOld_ASSIGN2.Value.Trim(), Me.HfOld_ASSIGN3.Value.Trim(),
                                               Me.HfOld_ASSIGN4.Value.Trim(), Me.HfOld_ASSIGN5.Value.Trim())

        End If

    End Sub

    Private Function SaveContactList(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer, ByVal ContactIDList As String) As String

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        Try

            Schedule = New cSchedule(_Session.ConnectionString, _Session.UserCode)

            Return Schedule.UpdateTaskContactListFromString(JobNumber, JobComponentNumber, SequenceNumber, ContactIDList)

        Catch ex As Exception
            Return ex.Message.ToString
        End Try

    End Function
    Private Function SavePredList(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer, ByVal PredecessorList As String) As DataTable

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        Try

            Schedule = New cSchedule(_Session.ConnectionString, _Session.UserCode)

            Return Schedule.UpdateTaskPredListFromString(JobNumber, JobComponentNumber, SequenceNumber, PredecessorList)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Function SaveEmpList(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByVal SequenceNumber As Integer, ByVal EmployeeList As String) As DataTable

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            EmployeeList = MiscFN.CleanStringForSplit(EmployeeList, ",")

            Return Schedule.UpdateTaskEmployeeListFromString(JobNumber, JobComponentNumber, SequenceNumber, EmployeeList)

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Private Sub SaveAlmostEverything(Optional ByVal RebindGrid As Boolean = True)

        ''I think autosave is covering all fields...

        'If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

        '    SaveScheduleAssignements()
        '    SaveScheduleComments()
        '    SaveOtherInformation()
        '    SaveScheduleDetails(True)

        'End If

    End Sub
    Private Function GetDueDate() As String

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        _RowCount = Me.RadGridProjectSchedule.MasterTableView.Items.Count

        If _RowCount > 0 Then

            GridDataItem = DirectCast(RadGridProjectSchedule.Items(_RowCount - 1), Telerik.Web.UI.GridDataItem)

            Return CType(FindGridControl(GridDataItem, GridControls.TextBoxJobRevisedDate), System.Web.UI.WebControls.TextBox).Text

        End If

    End Function
    Private Function GetStartDate() As String

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        _RowCount = Me.RadGridProjectSchedule.MasterTableView.Items.Count

        If _RowCount > 0 Then

            GridDataItem = DirectCast(RadGridProjectSchedule.Items(0), Telerik.Web.UI.GridDataItem)

            Return CType(FindGridControl(GridDataItem, GridControls.TextBoxTaskStartDate), System.Web.UI.WebControls.TextBox).Text

        End If

    End Function
    Private Sub LoadLookups()

        Me.HlTrafficStatus.Attributes.Add("onclick", "FocusTB('" & Me.TxtTrafficStatusCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtTrafficStatusCode.ClientID & "&type=statuscodes');return false;")
        Me.TxtTrafficStatusCode.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtTrafficStatusCode.ClientID & "&type=statuscodes');return false;")

    End Sub
    Private Function ValidateStartAndDueDates(ByVal DisplayError As Boolean) As Boolean

        If Me.RblCalcOnStartDate.Checked = True AndAlso Me.RadDatePickerStartDate.SelectedDate.HasValue = False Then

            If DisplayError Then

                Me.ShowMessage("Start date required.")

            End If

            Return False

        End If

        If Me.RblCalcOnDueDate.Checked = True AndAlso Me.RadDatePickerDueDate.SelectedDate.HasValue = False Then

            If DisplayError Then

                Me.ShowMessage("Due date required.")

            End If

            Return False

        End If

        If Me.CalculateByPredecessor = True AndAlso Me.RblCalcOnDueDate.Checked = True Then

            If DisplayError = True Then

                Me.ShowMessage("Calculating by due date is not permitted when in predecessor mode.")

            End If

            Return False

        End If

        Return True

    End Function
    Private Sub Toolbar_SaveAll()

        'objects
        Dim ThisJobNum As Integer = 0
        Dim ThisJobCompNum As Integer = 0
        Dim Validator As Webvantage.cValidations = Nothing
        Dim Schedule As Webvantage.cSchedule = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            ThisJobNum = _JobNumber
            ThisJobCompNum = _JobComponentNumber

            Validator = New cValidations(_Session.ConnectionString)

            If Validator.ValidateTrafficStatus(Me.TxtTrafficStatusCode.Text, True) = False Then

                Me.ShowMessage("Invalid Project Schedule Status.")
                Me.TxtTrafficStatusCode.Focus()
                Exit Sub

            End If

            If Me.TxtASSIGN_1Code.Text <> "" AndAlso (Me.TxtASSIGN_1Code.Text.Trim() <> Me.HfOld_ASSIGN1.Value.Trim()) Then

                If Validator.ValidateEmpCodetd(Me.TxtASSIGN_1Code.Text) = False Then

                    Me.ShowMessage("Invalid " & Me.HlASSIGN_1.Text & " code.")
                    Me.TxtASSIGN_1Code.Focus()
                    Exit Sub

                End If

            End If

            If Me.TxtASSIGN_2Code.Text <> "" AndAlso (Me.TxtASSIGN_2Code.Text.Trim() <> Me.HfOld_ASSIGN2.Value.Trim()) Then

                If Validator.ValidateEmpCodetd(Me.TxtASSIGN_2Code.Text) = False Then

                    Me.ShowMessage("Invalid " & Me.HlASSIGN_2.Text & " code.")
                    Me.TxtASSIGN_2Code.Focus()
                    Exit Sub

                End If

            End If

            If Me.TxtASSIGN_3Code.Text <> "" AndAlso (Me.TxtASSIGN_3Code.Text.Trim() <> Me.HfOld_ASSIGN3.Value.Trim()) Then

                If Validator.ValidateEmpCodetd(Me.TxtASSIGN_3Code.Text) = False Then

                    Me.ShowMessage("Invalid " & Me.HlASSIGN_3.Text & " code.")
                    Me.TxtASSIGN_3Code.Focus()
                    Exit Sub

                End If

            End If

            If Me.TxtASSIGN_4Code.Text <> "" AndAlso (Me.TxtASSIGN_4Code.Text.Trim() <> Me.HfOld_ASSIGN4.Value.Trim()) Then

                If Validator.ValidateEmpCodetd(Me.TxtASSIGN_4Code.Text) = False Then

                    Me.ShowMessage("Invalid " & Me.HlASSIGN_4.Text & " code.")
                    Me.TxtASSIGN_4Code.Focus()
                    Exit Sub

                End If

            End If

            If Me.TxtASSIGN_5Code.Text <> "" AndAlso (Me.TxtASSIGN_5Code.Text.Trim() <> Me.HfOld_ASSIGN5.Value.Trim()) Then

                If Validator.ValidateEmpCodetd(Me.TxtASSIGN_5Code.Text) = False Then

                    Me.ShowMessage("Invalid " & Me.HlASSIGN_5.Text & " code.")
                    Me.TxtASSIGN_5Code.Focus()
                    Exit Sub

                End If

            End If

            If Me.TextboxGutPercentComplete.Text <> "" Then

                If IsNumeric(Me.TextboxGutPercentComplete.Text) = False Then

                    Me.ShowMessage("Invalid percent complete.")
                    Me.TextboxGutPercentComplete.Focus()
                    Exit Sub

                End If

            End If

            If ThisJobNum <> 0 AndAlso ThisJobCompNum <> 0 Then

                If Validator.ValidateJobNumber(ThisJobNum) = False Then

                    Me.ShowMessage("This job does not exist!")
                    Exit Sub

                End If

                If Validator.ValidateJobCompNumber(ThisJobNum, ThisJobCompNum) = False Then

                    Me.ShowMessage("This is not a valid job/component!")
                    Exit Sub

                End If

                If Validator.ValidateJobIsOpen(ThisJobNum, ThisJobCompNum) = False Then

                    Me.ShowMessage("This job/comp is closed.")
                    Exit Sub

                End If

            End If

            SaveScheduleAssignements()
            SaveScheduleComments()
            SaveOtherInformation()
            SaveScheduleDetails(_AutoUpdateTrafficCode)

            Schedule = New cSchedule()

            If Schedule.UpdateScheduleStatus(ThisJobNum, ThisJobCompNum, True, "") = True Then

                LoadScheduleHeader()

            End If

        End If

    End Sub
    Private Function GetQueryStringVariable(ByVal QueryStringVar As QueryStringVars) As Object

        'objects
        Dim Value As Object = Nothing

        Try

            If Request.QueryString(QueryStringVar.ToString) IsNot Nothing Then

                Value = Request.QueryString(QueryStringVar.ToString)

            End If

        Catch ex As Exception
            Value = Nothing
        Finally
            GetQueryStringVariable = Value
        End Try

    End Function
    Private Sub SetQSVars()

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        Try

            If IsNumeric(GetQueryStringVariable(QueryStringVars.JobNum)) Then

                _JobNumber = CType(GetQueryStringVariable(QueryStringVars.JobNum), Integer)

            End If

        Catch ex As Exception
            _JobNumber = 0
        End Try

        Try

            If IsNumeric(GetQueryStringVariable(QueryStringVars.JobComp)) Then

                _JobComponentNumber = CType(GetQueryStringVariable(QueryStringVars.JobComp), Integer)

            End If

        Catch ex As Exception
            _JobComponentNumber = 0
        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.P) = Nothing Then

                _TaskPhaseFilter = GetQueryStringVariable(QueryStringVars.P).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Role) = Nothing Then

                _RoleCode = GetQueryStringVariable(QueryStringVars.Role).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Task) = Nothing Then

                _TaskCode = GetQueryStringVariable(QueryStringVars.Task).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Emp) = Nothing Then

                _EmployeeCode = GetQueryStringVariable(QueryStringVars.Emp).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Cut) = Nothing Then

                _CutOffDate = GetQueryStringVariable(QueryStringVars.Cut).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Pend) = Nothing Then

                _IncludeOnlyPendingTasks = CType(GetQueryStringVariable(QueryStringVars.Pend).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Proj) = Nothing Then

                _ExcludeProjectedTasks = CType(GetQueryStringVariable(QueryStringVars.Proj).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Comp) = Nothing Then

                _IncludeCompletedTasks = CType(GetQueryStringVariable(QueryStringVars.Comp).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.seq) = Nothing Then

                _SequenceNumber = CType(GetQueryStringVariable(QueryStringVars.seq), Integer)

            End If

        Catch ex As Exception
            _SequenceNumber = -1
        End Try

        Try

            If Session(Me.SessionVars.PS_Ignore_Filter.ToString) = Nothing Then

                Session(Me.SessionVars.PS_Ignore_Filter.ToString) = "0"

            End If

        Catch ex As Exception

        End Try

        'Clean up old querystring names by letting clean qs class override
        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        If QueryString.JobNumber > 0 Then

            _JobNumber = QueryString.JobNumber

        End If

        If QueryString.JobComponentNumber > 0 Then

            _JobComponentNumber = QueryString.JobComponentNumber

        End If

        'Me.IsLoadedIntoDashboard = QueryString.IsJobDashboard

        If QueryString.PhaseFilter <> "" Then

            _TaskPhaseFilter = QueryString.PhaseFilter

        End If

        If QueryString.RoleCode <> "" Then

            _RoleCode = QueryString.RoleCode

        End If

        If QueryString.TaskCode <> "" Then

            _TaskCode = QueryString.TaskCode

        End If

        If QueryString.EmployeeCode <> "" Then

            _EmployeeCode = QueryString.EmployeeCode

        End If

        If QueryString.CutOffDate <> "" Then

            _CutOffDate = QueryString.CutOffDate

        End If

        If QueryString.IncludeOnlyPendingTasks = True Then

            _IncludeOnlyPendingTasks = QueryString.IncludeOnlyPendingTasks

        End If

        If QueryString.ExcludeProjectedTasks = True Then

            _ExcludeProjectedTasks = QueryString.ExcludeProjectedTasks

        End If

        If QueryString.IncludeCompletedTasks = True Then

            _IncludeCompletedTasks = QueryString.IncludeCompletedTasks

        End If

        If QueryString.TaskSequenceNumber > 0 Then

            _SequenceNumber = QueryString.TaskSequenceNumber

        End If

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            _HeaderDatakey = _JobNumber.ToString() & "|" & _JobComponentNumber.ToString()

        End If

        _TaskFilterIndex = _TaskPhaseFilter

        If _TaskPhaseFilter <> "no_filter" AndAlso _TaskPhaseFilter <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _RoleCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _TaskCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _EmployeeCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _CutOffDate.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _IncludeOnlyPendingTasks = True Then

            _UsingATaskLevelFilter = True

        End If

        If _ExcludeProjectedTasks = True Then

            _UsingATaskLevelFilter = True

        End If

        If _IncludeCompletedTasks = True Then

            _UsingATaskLevelFilter = True

        End If

    End Sub
    Private Sub HookUpHeaderPageMethods()

        'objects
        Dim key As String = ""

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            key = _JobNumber.ToString() & "|" & _JobComponentNumber.ToString()

            Me.TxtComments.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'TRF_COMMENTS', this.value, '" & Me.TxtComments.ClientID & "');")
            Me.TxtReceivedBy.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'RECEIVED_BY', this.value, '" & Me.TxtReceivedBy.ClientID & "');")
            Me.TxtReference.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'REFERENCE', this.value, '" & Me.TxtReference.ClientID & "');")
            Me.TxtASSIGN_1Code.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'ASSIGN_1', this.value, '" & Me.TxtASSIGN_1Code.ClientID & "');")
            Me.TxtASSIGN_2Code.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'ASSIGN_2', this.value, '" & Me.TxtASSIGN_2Code.ClientID & "');")
            Me.TxtASSIGN_3Code.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'ASSIGN_3', this.value, '" & Me.TxtASSIGN_3Code.ClientID & "');")
            Me.TxtASSIGN_4Code.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'ASSIGN_4', this.value, '" & Me.TxtASSIGN_4Code.ClientID & "');")
            Me.TxtASSIGN_5Code.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'ASSIGN_5', this.value, '" & Me.TxtASSIGN_5Code.ClientID & "');")
            Me.TextboxGutPercentComplete.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'PERCENT_COMPLETE', this.value, '" & Me.TextboxGutPercentComplete.ClientID & "');")
            Me.TxtTrafficStatusCode.Attributes.Add("onblur", "DataChangeScheduleHeader('" & key & "', 'TRF_CODE', this.value, '" & Me.TxtTrafficStatusCode.ClientID & "');")

        End If

    End Sub
    Private Function CalculateScheduleDates() As Boolean

        'objects
        Dim Calculated As Boolean = False
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim Result As Integer = 0
        Dim ErrorMessage As String = ""
        Dim GridColumnsDataTable As System.Data.DataTable = Nothing
        Dim CalculateByPredecessor As Boolean = False
        Dim ScheduleHeaderDataTable As System.Data.DataTable = Nothing

        Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)
        ScheduleHeaderDataTable = Schedule.GetScheduleHeader(_JobNumber, _JobComponentNumber, _Session.UserCode, False).Tables(0)
        GridColumnsDataTable = Me.GetGridColumnsToDisplay

        If ScheduleHeaderDataTable.Rows(0)("SCHEDULE_CALC") = 1 Then

            CalculateByPredecessor = True

        ElseIf ScheduleHeaderDataTable.Rows(0)("SCHEDULE_CALC") = 0 Then

            CalculateByPredecessor = False

        Else

            For Each DataRow In GridColumnsDataTable.Rows.OfType(Of System.Data.DataRow)()

                If DataRow("COLUMN_NAME") = "colPREDECESSORS_TEXT" AndAlso DataRow("SHOW_ON_GRID") = "True" Then

                    CalculateByPredecessor = True
                    Exit For

                End If

            Next

        End If

        If CalculateByPredecessor Then

            Result = Schedule.CalculateDueDatesPred(_JobNumber, _JobComponentNumber, 1)

        Else

            Result = Schedule.CalculateDueDates(_JobNumber, _JobComponentNumber, 0)

        End If

        Select Case Result

            Case -1

                ErrorMessage = "Could not get start date."

            Case -2

                ErrorMessage = "Schedule is not feasible for calculation."

        End Select

        If Result = -1 OrElse Result = -2 Then

            Me.ShowMessage(ErrorMessage)

        Else

            Calculated = True

        End If

        If Calculated = True Then

            If Me.RadListBoxPredecessors.Items.Count > 0 Then

                Result = Schedule.CalculateJobPreds(_JobNumber, _JobComponentNumber, 0, Session("EmpCode"))

            End If

            Schedule.UpdateTaskAlertsDueDate(_JobNumber, _JobComponentNumber)

        End If

        Return Calculated

    End Function
    Private Sub SetTrafficScheduleAssignLabels()

        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DataSet As System.Data.DataSet = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim ManagerColumn As String = ""

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)
            DataSet = Schedule.GetScheduleAssignmentLabels()
            DataTable = DataSet.Tables(0)

            If IsDBNull(DataSet.Tables(1).Rows(0)(0)) = False Then

                ManagerColumn = DataSet.Tables(1).Rows(0)(0).ToString.Trim.ToUpper

            End If

            If DataTable.Rows.Count > 0 Then

                If IsDBNull(DataTable.Rows(0)("AGY_SETTINGS_VALUE")) = False Then

                    Me.HlASSIGN_1.Text = DataTable.Rows(0)("AGY_SETTINGS_VALUE")

                    If ManagerColumn = "TR_TITLE1" Then

                        Me.LitASSIGN1_Manager.Visible = True

                    Else

                        Me.LitASSIGN1_Manager.Visible = False

                    End If

                End If

                If IsDBNull(DataTable.Rows(1)("AGY_SETTINGS_VALUE")) = False Then

                    Me.HlASSIGN_2.Text = DataTable.Rows(1)("AGY_SETTINGS_VALUE")

                    If ManagerColumn = "TR_TITLE2" Then

                        Me.LitASSIGN2_Manager.Visible = True

                    Else

                        Me.LitASSIGN2_Manager.Visible = False

                    End If

                End If

                If IsDBNull(DataTable.Rows(2)("AGY_SETTINGS_VALUE")) = False Then

                    Me.HlASSIGN_3.Text = DataTable.Rows(2)("AGY_SETTINGS_VALUE")

                    If ManagerColumn = "TR_TITLE3" Then

                        Me.LitASSIGN3_Manager.Visible = True

                    Else

                        Me.LitASSIGN3_Manager.Visible = False

                    End If

                End If

                If IsDBNull(DataTable.Rows(3)("AGY_SETTINGS_VALUE")) = False Then

                    Me.HlASSIGN_4.Text = DataTable.Rows(3)("AGY_SETTINGS_VALUE")

                    If ManagerColumn = "TR_TITLE4" Then

                        Me.LitASSIGN4_Manager.Visible = True

                    Else

                        Me.LitASSIGN4_Manager.Visible = False

                    End If

                End If

                If IsDBNull(DataTable.Rows(4)("AGY_SETTINGS_VALUE")) = False Then

                    Me.HlASSIGN_5.Text = DataTable.Rows(4)("AGY_SETTINGS_VALUE")

                    If ManagerColumn = "TR_TITLE5" Then

                        Me.LitASSIGN5_Manager.Visible = True

                    Else

                        Me.LitASSIGN5_Manager.Visible = False

                    End If

                End If

            End If

        Catch ex As Exception

        End Try

        Try

            If Not Me.IsPostBack Then

                Me.HlASSIGN_1.Attributes.Add("onclick", "FocusTB('" & Me.TxtASSIGN_1Code.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TxtASSIGN_1Code.ClientID.ToString() & "');return false;")
                Me.HlASSIGN_2.Attributes.Add("onclick", "FocusTB('" & Me.TxtASSIGN_2Code.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TxtASSIGN_2Code.ClientID.ToString() & "');return false;")
                Me.HlASSIGN_3.Attributes.Add("onclick", "FocusTB('" & Me.TxtASSIGN_3Code.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TxtASSIGN_3Code.ClientID.ToString() & "');return false;")
                Me.HlASSIGN_4.Attributes.Add("onclick", "FocusTB('" & Me.TxtASSIGN_4Code.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TxtASSIGN_4Code.ClientID.ToString() & "');return false;")
                Me.HlASSIGN_5.Attributes.Add("onclick", "FocusTB('" & Me.TxtASSIGN_5Code.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&type=empcode&control=" & Me.TxtASSIGN_5Code.ClientID.ToString() & "');return false;")

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub SetScheduleGridColumns()

        'objects
        Dim ColumnName As String = ""
        Dim PredVsOrderColumns As Generic.Dictionary(Of String, Boolean) = Nothing
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing

        _Columns = GetGridColumnsToDisplay()

        If _Columns.Rows.Count > 0 Then

            For Each DataRow In _Columns.Rows.OfType(Of System.Data.DataRow)()

                ColumnName = DataRow("ColumnName")

                If ColumnName.IndexOf(",") > 0 Then

                    For Each SeparateColumnName In ColumnName.Split(",")

                        Try

                            GridColumn = Me.RadGridProjectSchedule.MasterTableView.GetColumnSafe(SeparateColumnName)

                            If GridColumn IsNot Nothing Then

                                With GridColumn

                                    .Visible = CType(DataRow("ShowOnGrid"), Boolean)

                                    If ColumnName.Split(",").First = SeparateColumnName Then

                                        .HeaderText = DataRow("HeaderText")

                                    End If

                                End With

                            End If

                        Catch ex As Exception

                        End Try

                    Next

                Else

                    Try

                        GridColumn = Me.RadGridProjectSchedule.MasterTableView.GetColumnSafe(ColumnName)

                        If GridColumn IsNot Nothing Then

                            With GridColumn

                                If ColumnName = "colPREDECESSORS_TEXT" Then

                                    Me.RblCalcOnDueDate.Enabled = False

                                Else

                                    Me.RblCalcOnDueDate.Enabled = True

                                End If

                                .Visible = CType(DataRow("ShowOnGrid"), Boolean)
                                .HeaderText = DataRow("HeaderText")

                            End With

                        End If

                    Catch ex As Exception

                    End Try

                End If

            Next

        End If

        PredVsOrderColumns = New Generic.Dictionary(Of String, Boolean)

        PredVsOrderColumns.Add(ColumnNames.ColumnLinked.ToString, Me.CalculateByPredecessor)
        PredVsOrderColumns.Add(ColumnNames.GridTemplateColumnSelectPreds.ToString, Me.CalculateByPredecessor)
        PredVsOrderColumns.Add(ColumnNames.GridTemplateColumnInputPreds.ToString, Me.CalculateByPredecessor AndAlso IsColumnVisible(ColumnNames.GridTemplateColumnInputPreds))
        PredVsOrderColumns.Add(ColumnNames.colJOB_ORDER.ToString, Not Me.CalculateByPredecessor)
        PredVsOrderColumns.Add(ColumnNames.ColumnMove.ToString, Me.CalculateByPredecessor AndAlso IsColumnVisible(ColumnNames.ColumnMove))
        PredVsOrderColumns.Add(ColumnNames.GridTemplateColumnPreds.ToString, Me.CalculateByPredecessor AndAlso IsColumnVisible(ColumnNames.GridTemplateColumnPreds))

        For Each KeyValuePair In PredVsOrderColumns

            If Me.RadGridProjectSchedule.MasterTableView.GetColumnSafe(KeyValuePair.Key) IsNot Nothing Then

                With Me.RadGridProjectSchedule.MasterTableView.GetColumn(KeyValuePair.Key)

                    .Visible = KeyValuePair.Value

                End With

            End If

        Next

    End Sub
    Private Function GetGridColumnsToDisplay() As System.Data.DataTable

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DataTable As New System.Data.DataTable

        Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

        If Me.IsClientPortal = True Then
            DataTable = Schedule.GetScheduleColumns(_Session.ClientPortalUser.UserName, False, False, False)
        Else
            DataTable = Schedule.GetScheduleColumns(_Session.User.EmployeeCode, False, False, False)
        End If


        GetGridColumnsToDisplay = DataTable

    End Function
    Private Function LoadScheduleHeader() As String

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim VersionString As String = ""
        Dim CalculateByDueDate As Boolean = False
        Dim CalculateBy As Integer = 0 '1 is start, zero/null is due
        Dim Rush As Integer = 0
        Dim IsPredecessor As Boolean = False

        Try

            If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                Exit Function

            End If

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            DataTable = Schedule.GetScheduleHeader(_JobNumber, _JobComponentNumber, _Session.UserCode, False).Tables(0)

            If DataTable.Rows.Count > 0 Then

                Session("SchedJobNumber") = _JobNumber
                Session("SchedJobComponentNumber") = _JobComponentNumber
                Session("SchedHeaderLoaded") = _JobNumber

                If IsDBNull(DataTable.Rows(0)("CL_CODE")) = False Then

                    Me.LinkButtonClient.Text = DataTable.Rows(0)("CL_CODE")
                    Me.HiddenFieldClientCode.Value = DataTable.Rows(0)("CL_CODE")

                End If

                If IsDBNull(DataTable.Rows(0)("CL_NAME")) = False Then

                    Me.LinkButtonClient.Text &= " - " & DataTable.Rows(0)("CL_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("DIV_CODE")) = False Then

                    Me.LinkButtonDivision.Text = DataTable.Rows(0)("DIV_CODE")
                    Me.HiddenFieldDivisionCode.Value = DataTable.Rows(0)("DIV_CODE")

                End If

                If IsDBNull(DataTable.Rows(0)("DIV_NAME")) = False Then

                    Me.LinkButtonDivision.Text &= " - " & DataTable.Rows(0)("DIV_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("PRD_CODE")) = False Then

                    Me.LinkButtonProduct.Text = DataTable.Rows(0)("PRD_CODE")
                    Me.HiddenFieldProductCode.Value = DataTable.Rows(0)("PRD_CODE")

                End If

                If IsDBNull(DataTable.Rows(0)("PRD_DESCRIPTION")) = False Then

                    Me.LinkButtonProduct.Text &= " - " & DataTable.Rows(0)("PRD_DESCRIPTION")

                End If

                If IsDBNull(DataTable.Rows(0)("JOB_NUMBER")) = False Then

                    Me.LinkButtonJob.Text = MiscFN.PadJobNum(DataTable.Rows(0)("JOB_NUMBER").ToString())
                    _JobNumber = DataTable.Rows(0)("JOB_NUMBER").ToString()

                End If

                If IsDBNull(DataTable.Rows(0)("JOB_DESC")) = False Then

                    Me.LinkButtonJob.Text &= " - " & DataTable.Rows(0)("JOB_DESC")

                End If

                If IsDBNull(DataTable.Rows(0)("JOB_COMPONENT_NBR")) = False Then

                    Me.LinkButtonJobComponent.Text = MiscFN.PadJobCompNum(DataTable.Rows(0)("JOB_COMPONENT_NBR").ToString())
                    _JobComponentNumber = DataTable.Rows(0)("JOB_COMPONENT_NBR").ToString()

                End If

                If IsDBNull(DataTable.Rows(0)("JOB_COMP_DESC")) = False Then

                    Me.LinkButtonJobComponent.Text &= " - " & DataTable.Rows(0)("JOB_COMP_DESC")

                End If

                If IsDBNull(DataTable.Rows(0)("TRF_CODE")) = False Then

                    Me.TxtTrafficStatusCode.Text = DataTable.Rows(0)("TRF_CODE")

                End If

                If IsDBNull(DataTable.Rows(0)("TRF_DESC")) = False Then

                    Me.TxtTrafficStatusDescription.Text = DataTable.Rows(0)("TRF_DESC")

                End If

                If IsDBNull(DataTable.Rows(0)("Comments")) = False Then

                    Me.TxtComments.Text = DataTable.Rows(0)("Comments")

                End If

                If IsDBNull(DataTable.Rows(0)("DATE_SHIPPED")) = False Then

                    Me.RadDatePickerDateShipped.SelectedDate = DataTable.Rows(0)("DATE_SHIPPED")

                End If

                If IsDBNull(DataTable.Rows(0)("DATE_DELIVERED")) = False Then

                    Me.RadDatePickerDateDelivered.SelectedDate = DataTable.Rows(0)("DATE_DELIVERED")

                End If

                If IsDBNull(DataTable.Rows(0)("RECEIVED_BY")) = False Then

                    Me.TxtReceivedBy.Text = DataTable.Rows(0)("RECEIVED_BY")

                End If

                If IsDBNull(DataTable.Rows(0)("REFERENCE")) = False Then

                    Me.TxtReference.Text = DataTable.Rows(0)("REFERENCE")

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_1")) = False Then

                    Me.TxtASSIGN_1Code.Text = DataTable.Rows(0)("ASSIGN_1").ToString().Trim()
                    Me.HfOld_ASSIGN1.Value = DataTable.Rows(0)("ASSIGN_1").ToString().Trim()

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_1_FML_NAME")) = False Then

                    Me.TxtASSIGN_1Description.Text = DataTable.Rows(0)("ASSIGN_1_FML_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_2")) = False Then

                    Me.TxtASSIGN_2Code.Text = DataTable.Rows(0)("ASSIGN_2").ToString().Trim()
                    Me.HfOld_ASSIGN2.Value = DataTable.Rows(0)("ASSIGN_2").ToString().Trim()

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_2_FML_NAME")) = False Then

                    Me.TxtASSIGN_2Description.Text = DataTable.Rows(0)("ASSIGN_2_FML_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_3")) = False Then

                    Me.TxtASSIGN_3Code.Text = DataTable.Rows(0)("ASSIGN_3").ToString().Trim()
                    Me.HfOld_ASSIGN3.Value = DataTable.Rows(0)("ASSIGN_3").ToString().Trim()

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_3_FML_NAME")) = False Then

                    Me.TxtASSIGN_3Description.Text = DataTable.Rows(0)("ASSIGN_3_FML_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_4")) = False Then

                    Me.TxtASSIGN_4Code.Text = DataTable.Rows(0)("ASSIGN_4").ToString().Trim()
                    Me.HfOld_ASSIGN4.Value = DataTable.Rows(0)("ASSIGN_4").ToString().Trim()

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_4_FML_NAME")) = False Then

                    Me.TxtASSIGN_4Description.Text = DataTable.Rows(0)("ASSIGN_4_FML_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_5")) = False Then

                    Me.TxtASSIGN_5Code.Text = DataTable.Rows(0)("ASSIGN_5").ToString().Trim()
                    Me.HfOld_ASSIGN5.Value = DataTable.Rows(0)("ASSIGN_5").ToString().Trim()

                End If

                If IsDBNull(DataTable.Rows(0)("ASSIGN_5_FML_NAME")) = False Then

                    Me.TxtASSIGN_5Description.Text = DataTable.Rows(0)("ASSIGN_5_FML_NAME")

                End If

                If IsDBNull(DataTable.Rows(0)("START_DATE")) = False Then

                    If cGlobals.wvIsDate(DataTable.Rows(0)("START_DATE")) = True Then

                        Me.RadDatePickerStartDate.SelectedDate = cGlobals.wvCDate(DataTable.Rows(0)("START_DATE")).ToShortDateString

                    Else

                        Me.RadDatePickerStartDate.SelectedDate = Nothing

                    End If

                Else

                    Me.RadDatePickerStartDate.SelectedDate = Nothing

                End If

                If Me.RadDatePickerStartDate.SelectedDate = "1/1/1900" Then

                    Me.RadDatePickerStartDate.SelectedDate = ""

                End If

                If IsDBNull(DataTable.Rows(0)("JOB_FIRST_USE_DATE")) = False Then

                    If cGlobals.wvIsDate(DataTable.Rows(0)("JOB_FIRST_USE_DATE")) = True Then

                        Me.RadDatePickerDueDate.SelectedDate = cGlobals.wvCDate(DataTable.Rows(0)("JOB_FIRST_USE_DATE")).ToShortDateString

                    Else

                        Me.RadDatePickerDueDate.SelectedDate = Nothing

                    End If

                Else

                    Me.RadDatePickerDueDate.SelectedDate = Nothing

                End If

                If Me.RadDatePickerDueDate.SelectedDate = "1/1/1900" Then

                    Me.RadDatePickerDueDate.SelectedDate = Nothing

                End If

                If IsDBNull(DataTable.Rows(0)("JobCompleted")) = False Then

                    If cGlobals.wvIsDate(DataTable.Rows(0)("JobCompleted")) = True Then

                        Me.RadDatePickerJobCompleted.SelectedDate = cGlobals.wvCDate(DataTable.Rows(0)("JobCompleted")).ToShortDateString

                    Else

                        Me.RadDatePickerJobCompleted.SelectedDate = Nothing

                    End If
                Else

                    Me.RadDatePickerJobCompleted.SelectedDate = Nothing

                End If

                If IsDBNull(DataTable.Rows(0)("GUT_PERCENT_COMPLETE")) = False Then

                    Me.TextboxGutPercentComplete.Text = String.Format("{0:#,##0.00}", DataTable.Rows(0)("GUT_PERCENT_COMPLETE"))

                Else

                    Me.TextboxGutPercentComplete.Text = ""

                End If

                If IsDBNull(DataTable.Rows(0)("EMP_CODE_AE")) = False Then

                    Me.LblAccountExecutive.Text = DataTable.Rows(0)("EMP_CODE_AE")
                Else

                    Me.LblAccountExecutive.Text = ""

                End If

                If IsDBNull(DataTable.Rows(0)("AE_NAME")) = False Then

                    Me.LblAccountExecutive.Text &= " - " & DataTable.Rows(0)("AE_NAME")

                End If

                Try

                    If IsDBNull(DataTable.Rows(0)("SCHEDULE_CALC")) = False AndAlso CInt(DataTable.Rows(0)("SCHEDULE_CALC")) = 1 Then

                        IsPredecessor = True

                    End If

                Catch ex As Exception
                    IsPredecessor = False
                End Try

                If IsPredecessor = True Then

                    Me.RadToolBarButtonJobOrder.Text = "Predecessor"
                    Me.RadToolBarButtonJobOrder.ToolTip = "Click to calculate by Order"
                    Me.RadToolBarButtonJobOrder.Value = "Order"
                    Me.RadToolBarButtonJobOrder.CommandName = "Order"
                    Me.CalculateByPredecessor = True

                Else

                    Me.RadToolBarButtonJobOrder.Text = "Order"
                    Me.RadToolBarButtonJobOrder.ToolTip = "Click to calculate by Predecessor"
                    Me.RadToolBarButtonJobOrder.Value = "Predecessor"
                    Me.RadToolBarButtonJobOrder.CommandName = "Predecessor"
                    Me.CalculateByPredecessor = False

                End If

                If IsDBNull(DataTable.Rows(0)("AUTO_UPDATE_STATUS")) = False Then

                    Me.CheckBoxAutoStatusUpdateTasks.Checked = CType(DataTable.Rows(0)("AUTO_UPDATE_STATUS"), Boolean)

                Else

                    Me.CheckBoxAutoStatusUpdateTasks.Checked = Schedule.GetUpdateStatusDefault()

                End If

                Try

                    If IsDBNull(DataTable.Rows(0)("VERSION_ID")) = False AndAlso
                       IsDBNull(DataTable.Rows(0)("VER_SEQ_NBR")) = False AndAlso
                       IsDBNull(DataTable.Rows(0)("VERSION_NAME")) = False Then

                        Me.LinkButtonVersionInformation.CommandArgument = DataTable.Rows(0)("VERSION_ID")

                        VersionString = DataTable.Rows(0)("VER_SEQ_NBR").ToString().PadLeft(2, "0") & " - " & DataTable.Rows(0)("VERSION_NAME")

                        If IsDBNull(DataTable.Rows(0)("VERSION_LAST_APPLIED")) = False Then

                            VersionString &= ", Last Applied: " & CDate(DataTable.Rows(0)("VERSION_LAST_APPLIED")).ToShortDateString()

                        End If

                    End If

                Catch ex As Exception
                    VersionString = ""
                End Try

                If String.IsNullOrWhiteSpace(VersionString) = False Then

                    Me.LinkButtonVersionInformation.Text = VersionString

                Else

                    Me.LinkButtonVersionInformation.Text = "--"

                End If

                Me.RadToolbarSchedule.FindItemByValue("Versions").ToolTip = Me.LinkButtonVersionInformation.Text

                If IsDBNull(DataTable.Rows(0)("TRF_SCHEDULE_BY")) = False Then

                    CalculateBy = CType(DataTable.Rows(0)("TRF_SCHEDULE_BY"), Integer)

                    If CalculateBy = 0 Then

                        CalculateByDueDate = True

                    Else

                        CalculateByDueDate = False

                    End If

                Else

                    CalculateByDueDate = True

                End If

                Me.RblCalcOnDueDate.Checked = CalculateByDueDate
                Me.RblCalcOnStartDate.Checked = Not CalculateByDueDate

                Try

                    If IsDBNull(DataTable.Rows(0)("JOB_RUSH_CHARGES")) = False Then

                        Rush = CType(DataTable.Rows(0)("JOB_RUSH_CHARGES"), Integer)

                    End If

                    If Rush = 1 Then

                        Me.LblRush.Visible = True

                    Else

                        Me.LblRush.Visible = False

                    End If

                Catch ex As Exception
                    Me.LblRush.Visible = False
                End Try

                Me.CollapsablePanelHeader.Collapsed = False
                Me.CollapsablePanelComments.Collapsed = False
                Me.CollapsablePanelDetails.Collapsed = False
                Me.RadGridProjectSchedule.Visible = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.RadListBoxJobCompPred.DataSource = (From JobTrfPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(DbContext, _JobNumber, _JobComponentNumber).Include("JobTraffic").ToList
                                                           Select [Description] = JobTrfPredecessor.JobPredecessor & "/" & JobTrfPredecessor.JobComponentPredecessor & " - " & AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobTrfPredecessor.JobPredecessor, JobTrfPredecessor.JobComponentPredecessor).Description,
                                                                  [Code] = JobTrfPredecessor.JobPredecessor & "/" & JobTrfPredecessor.JobComponentPredecessor
                                                           Order By [Description]).ToList

                    Me.RadListBoxJobCompPred.DataTextField = "Description"
                    Me.RadListBoxJobCompPred.DataValueField = "Code"
                    Me.RadListBoxJobCompPred.DataBind()
                    Me.RadListBoxJobCompPred.SelectionMode = ListSelectionMode.Multiple

                    Me.RadListBoxPredecessors.DataSource = (From JobTrfPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, _JobNumber, _JobComponentNumber).Include("JobTraffic").ToList
                                                            Select [Description] = JobTrfPredecessor.JobNumber & "/" & JobTrfPredecessor.JobComponentNumber & " - " & JobTrfPredecessor.JobTraffic.JobComponent.Description,
                                                                   [Code] = JobTrfPredecessor.JobNumber & "/" & JobTrfPredecessor.JobComponentNumber
                                                            Order By [Description]).ToList

                    Me.RadListBoxPredecessors.DataTextField = "Description"
                    Me.RadListBoxPredecessors.DataValueField = "Code"
                    Me.RadListBoxPredecessors.DataBind()
                    Me.RadListBoxPredecessors.SelectionMode = ListSelectionMode.Multiple

                End Using

                Me.HookUpHeaderPageMethods()

                _DataLoaded = True

                Return ""

            Else

                MiscFN.ResponseRedirect("TrafficSchedule_Search.aspx")

            End If

        Catch ex As Exception
            _DataLoaded = False
            Return ex.Message.ToString
        End Try

    End Function
    Private Sub LoadEstimateFunctionsDataTable()

        'objects
        Dim DropDown As Webvantage.cDropDowns = Nothing
        Dim DataTable As System.Data.DataTable = Nothing

        If _EstimateFunctions Is Nothing Then

            _EstimateFunctions = New System.Data.DataTable

        End If

        If _EstimateFunctions.Rows.Count = 0 Then

            DropDown = New Webvantage.cDropDowns(_Session.ConnectionString)

            Try

                DataTable = DropDown.GetEstimateFunctionsPS

                DataTable.DefaultView.Sort = "Description ASC"

            Catch ex As Exception

            End Try

            _EstimateFunctions = DataTable.DefaultView.ToTable()

        End If

    End Sub
    Private Sub LoadPhasesDataTable()

        'objects
        Dim DropDown As Webvantage.cDropDowns = Nothing

        If _Phases Is Nothing Then

            _Phases = New System.Data.DataTable

        End If

        If _Phases.Rows.Count = 0 Then

            DropDown = New Webvantage.cDropDowns(_Session.ConnectionString)

            _Phases = DropDown.GetTrafficPhasesAll

        End If

    End Sub
    Private Sub HideEmptyDetailTableAndExpandColumn(ByVal GridTableView As Telerik.Web.UI.GridTableView)

        'objects
        Dim TableCell As System.Web.UI.WebControls.TableCell = Nothing

        If GridTableView.Items.Count > 0 Then

            Try

                For Each GridNestedViewItem In GridTableView.GetItems(Telerik.Web.UI.GridItemType.NestedView).OfType(Of Telerik.Web.UI.GridNestedViewItem)()

                    For Each NestedGridTableView In GridNestedViewItem.NestedTableViews.OfType(Of Telerik.Web.UI.GridTableView)()

                        If NestedGridTableView.Items.Count = 0 Then

                            TableCell = NestedGridTableView.ParentItem("ExpandColumn")

                            TableCell.Controls(0).Visible = False
                            TableCell.Text = ""
                            GridNestedViewItem.Visible = False

                        End If

                        For Each GridColumn In NestedGridTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

                            If RadGridProjectSchedule.Columns().OfType(Of Telerik.Web.UI.GridColumn).Where(Function(gc) gc.UniqueName = GridColumn.UniqueName).Any Then

                                GridColumn.Visible = RadGridProjectSchedule.Columns().OfType(Of Telerik.Web.UI.GridColumn).Where(Function(gc) gc.UniqueName = GridColumn.UniqueName).First.Visible()

                            End If

                        Next

                        If NestedGridTableView.HasDetailTables Then

                            HideEmptyDetailTableAndExpandColumn(NestedGridTableView)

                        End If

                    Next

                Next


            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Function FindGridControl(ByVal GridItem As Telerik.Web.UI.GridItem, ByVal GridControl As GridControls) As System.Web.UI.Control

        'objects
        Dim Control As System.Web.UI.Control = Nothing

        Try

            Control = GridItem.FindControl(GridControl.ToString)

        Catch ex As Exception
            Control = Nothing
        End Try

        FindGridControl = Control

    End Function
    Private Sub UpdateTaskListOrder(ByVal ScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask))

        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim SQlUpdateString As String = ""

        StringBuilder = New System.Text.StringBuilder

        For Each ScheduleTask In ScheduleTaskList

            Try

                StringBuilder.AppendLine(String.Format(" UPDATE " &
                                                       "    dbo.JOB_TRAFFIC_DET " &
                                                       " SET " &
                                                       "    [GRID_ORDER] = {0} " &
                                                       " WHERE " &
                                                       "    [JOB_NUMBER] = {1} AND " &
                                                       "    [JOB_COMPONENT_NBR] = {2} AND " &
                                                       "    [SEQ_NBR] = {3};", ScheduleTaskList.IndexOf(ScheduleTask) + 1, ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber))

            Catch ex As Exception

            End Try

        Next

        Try

            SQlUpdateString = StringBuilder.ToString()

            _DbContext.Database.ExecuteSqlCommand(SQlUpdateString)

        Catch ex As Exception

        End Try

    End Sub
    Private Function CheckIfPredecessorExists(ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short) As Boolean

        'objects
        Dim Exists As Boolean = False

        Try

            If _DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND PREDECESSOR_SEQ_NBR = {3} ", _JobNumber, _JobComponentNumber, SequenceNumber, PredecessorSequenceNumber).FirstOrDefault > 0 Then

                Exists = True

            End If

        Catch ex As Exception
            Exists = False
        Finally
            CheckIfPredecessorExists = Exists
        End Try

    End Function
    Private Sub CreatePredecessor(ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short)

        Try

            If CheckIfPredecessorExists(SequenceNumber, PredecessorSequenceNumber) = False Then

                _DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.JOB_TRAFFIC_DET_PREDS (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, PREDECESSOR_SEQ_NBR) VALUES ({0}, {1}, {2}, {3})", _JobNumber, _JobComponentNumber, SequenceNumber, PredecessorSequenceNumber)

                DeletePredecessor(PredecessorSequenceNumber, SequenceNumber) 'prevents circular predecessor

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub DeletePredecessor(ByVal SequenceNumber As Short, ByVal PredecessorSequenceNumber As Short)

        Try

            _DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND PREDECESSOR_SEQ_NBR = {3}", _JobNumber, _JobComponentNumber, SequenceNumber, PredecessorSequenceNumber)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub MoveTaskHierarchy(ByVal SequenceNumber As Short, ByVal ParentTaskSequenceNumber As Short?)

        'objects
        Dim Schedule As Webvantage.cSchedule = Nothing

        Try

            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

            Schedule.MoveTaskHierarchy(_JobNumber, _JobComponentNumber, SequenceNumber, ParentTaskSequenceNumber)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub HideGridControlAndRemoveData(ByVal WebControl As System.Web.UI.WebControls.WebControl)

        If WebControl IsNot Nothing Then

            With WebControl

                .Visible = False

                If TypeOf WebControl Is System.Web.UI.WebControls.TextBox Then

                    With DirectCast(WebControl, System.Web.UI.WebControls.TextBox)

                        .Text = Nothing

                    End With

                ElseIf TypeOf WebControl Is Telerik.Web.UI.RadTextBox Then

                    With DirectCast(WebControl, Telerik.Web.UI.RadTextBox)

                        .Text = Nothing

                    End With

                ElseIf TypeOf WebControl Is System.Web.UI.WebControls.ImageButton Then

                    With DirectCast(WebControl, System.Web.UI.WebControls.ImageButton)

                        .CommandArgument = Nothing
                        .CommandName = Nothing

                    End With

                ElseIf TypeOf WebControl Is System.Web.UI.WebControls.Label Then

                    With DirectCast(WebControl, System.Web.UI.WebControls.Label)

                        .Text = Nothing

                    End With

                ElseIf TypeOf WebControl Is System.Web.UI.WebControls.LinkButton Then

                    With DirectCast(WebControl, System.Web.UI.WebControls.LinkButton)

                        .Text = Nothing
                        .CommandArgument = Nothing
                        .CommandName = Nothing

                    End With

                ElseIf TypeOf WebControl Is Telerik.Web.UI.RadButton Then

                    With DirectCast(WebControl, Telerik.Web.UI.RadButton)

                        .Text = Nothing
                        .CommandArgument = Nothing
                        .CommandName = Nothing

                    End With

                End If

            End With

        End If

    End Sub
    Private Sub LoadPhaseComboBox(ByVal PhaseRadComboBox As Telerik.Web.UI.RadComboBox, ByVal PhaseID As Integer?, ByVal PhaseDescription As String, ByVal MinimalSource As Boolean)

        If PhaseRadComboBox IsNot Nothing Then

            PhaseRadComboBox.Items.Clear()

            LoadPhasesDataTable()

            Try

                With PhaseRadComboBox

                    If MinimalSource AndAlso PhaseID.HasValue Then

                        .DataSource = _Phases.AsEnumerable.Where(Function(Row) Row.Field(Of Integer)("Code") = PhaseID.Value).Select(Function(Row) New With {.Code = Row.Field(Of Integer)("Code"),
                                                                                                                                                             .Description = Row.Field(Of String)("Description")}).ToList

                    Else

                        .DataSource = _Phases

                    End If

                    .DataTextField = "Description"
                    .DataValueField = "Code"
                    .DataBind()

                End With

                Try

                    If PhaseID.HasValue AndAlso PhaseRadComboBox.Items.FindItemByValue(PhaseID.Value.ToString) Is Nothing Then

                        PhaseRadComboBox.Items.Add(New Telerik.Web.UI.RadComboBoxItem(PhaseDescription, PhaseID.Value.ToString))

                        For Each RadComboBoxItem In Me.DropPhaseFilter.Items.OfType(Of Telerik.Web.UI.RadComboBoxItem)()

                            If RadComboBoxItem.Value = PhaseID.Value.ToString Then

                                Me.DropPhaseFilter.Items.Add(New Telerik.Web.UI.RadComboBoxItem(PhaseDescription.Trim, PhaseID.Value.ToString))

                                Exit For

                            End If

                        Next

                        MiscFN.RadComboBoxSetIndex(PhaseRadComboBox, PhaseDescription, True)

                    Else

                        MiscFN.RadComboBoxSetIndex(PhaseRadComboBox, PhaseDescription, True)

                    End If

                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub LoadEstimateFunctionComboBox(ByVal EstimateFunctionRadComboBox As Telerik.Web.UI.RadComboBox, ByVal FunctionCode As String, ByVal MinimalSource As Boolean)

        Dim EstimateFunctionDataTable As System.Data.DataTable = Nothing
        Dim DataRow As System.Data.DataRow = Nothing

        If EstimateFunctionRadComboBox IsNot Nothing Then

            EstimateFunctionRadComboBox.Items.Clear()

            LoadEstimateFunctionsDataTable()

            Try

                With EstimateFunctionRadComboBox

                    If MinimalSource Then

                        EstimateFunctionDataTable = _EstimateFunctions.AsEnumerable.Where(Function(Row) Row.Field(Of String)("Code") = FunctionCode).AsDataView.ToTable

                    Else

                        EstimateFunctionDataTable = _EstimateFunctions

                    End If

                    DataRow = EstimateFunctionDataTable.NewRow()

                    DataRow("Code") = ""
                    DataRow("Description") = "[None]"

                    EstimateFunctionDataTable.Rows.InsertAt(DataRow, 0)

                    .DataSource = EstimateFunctionDataTable
                    .DataTextField = "Code" '"Description"
                    .DataValueField = "Code"
                    .DataBind()

                End With

                Try

                    MiscFN.RadComboBoxSetIndex(EstimateFunctionRadComboBox, FunctionCode, False)

                Catch ex As Exception

                End Try

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub SetGridSort(ByVal SortString As String)

        'objects
        Dim AppVars As Webvantage.cAppVars = Nothing
        Dim GridGroupByExpression As Telerik.Web.UI.GridGroupByExpression = Nothing

        Try

            If String.IsNullOrWhiteSpace(SortString) = True Then

                SortString = "order"

            End If

            _SortString = SortString

            AppVars = New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)

            With AppVars

                .getAllAppVars()
                .setAppVar("GridSort", SortString, "String")
                .SaveAllAppVars()

            End With

            Select Case SortString

                Case "order"

                    Me.RadGridProjectSchedule.MasterTableView.GroupByExpressions.Clear()

                Case "phase"

                    GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("PhaseDescription Phase Group By PhaseOrder, PhaseDescription")

                    With Me.RadGridProjectSchedule

                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GridGroupByExpression)
                        .MasterTableView.GroupsDefaultExpanded = True

                    End With

                Case "startdue"

                    Me.RadGridProjectSchedule.MasterTableView.GroupByExpressions.Clear()

            End Select

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ClearDates(ByVal IncludeOriginal As Boolean)

        'objects
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            StringBuilder = New System.Text.StringBuilder

            StringBuilder.Append("UPDATE dbo.JOB_TRAFFIC_DET SET ")
            StringBuilder.Append(" TASK_START_DATE = NULL, ")
            StringBuilder.Append(" JOB_REVISED_DATE = NULL, ")
            StringBuilder.Append(" JOB_COMPLETED_DATE = NULL ")

            If IncludeOriginal Then

                StringBuilder.Append(", JOB_DUE_DATE = NULL ")

            End If

            StringBuilder.Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR")

            JobNumberSqlParameter = New SqlClient.SqlParameter("JOB_NUMBER", System.Data.SqlDbType.Int) With {.Value = _JobNumber}
            JobComponentNumberSqlParameter = New SqlClient.SqlParameter("JOB_COMPONENT_NBR", System.Data.SqlDbType.SmallInt) With {.Value = _JobComponentNumber}

            _DbContext.Database.ExecuteSqlCommand(StringBuilder.ToString, JobNumberSqlParameter, JobComponentNumberSqlParameter)

        End If

    End Sub

#Region " Public "

    <System.Web.Services.WebMethod()>
    Public Shared Function GetPredecessorsLevelList(ByVal DataKey As String, ByVal LabelList As String) As String

        Dim Keys As String() = Nothing
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Integer = 0
        Dim SequenceNumber As Integer = -1
        Dim PredecessorsList As New Generic.List(Of Short)
        Dim PredList As Generic.List(Of Object) = Nothing
        Dim SequenceNumbersAndLabels As String() = Nothing
        Dim FinalPredList As String = ""
        Dim JavaScriptSerializer As System.Web.Script.Serialization.JavaScriptSerializer = Nothing

        Keys = DataKey.Split("|")
        SequenceNumbersAndLabels = LabelList.Split("|")

        Try

            JobNumber = Keys(0)

        Catch ex As Exception
            JobNumber = 0
        End Try

        Try

            JobComponentNumber = Keys(1)

        Catch ex As Exception
            JobNumber = 0
        End Try

        Try

            SequenceNumber = Keys(2)

        Catch ex As Exception
            SequenceNumber = -1
        End Try

        If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

            Try
                '' THIS THROWS A WEIRD ERROR, BUT ONLY IN RELEASE MODE; IT WORKS FINE IN DEBUG
                'Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                '    PredecessorsArray = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};", JobNumber, JobComponentNumber, SequenceNumber)).ToArray()

                'End Using

                '' THIS WORKS IN BOTH DEBUG AND RELEASE....
                Dim MyDatatable As New DataTable
                Using MyConn As New SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))

                    Dim MyCommand As New SqlClient.SqlCommand()

                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = String.Format("SELECT [PREDECESSOR_SEQ_NBR] FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};", JobNumber, JobComponentNumber, SequenceNumber)
                        .Connection = MyConn

                    End With

                    MyConn.Open()
                    MyDatatable.Load(MyCommand.ExecuteReader)

                End Using

                If MyDatatable IsNot Nothing Then

                    If MyDatatable.Rows.Count > 0 Then

                        For i As Integer = 0 To MyDatatable.Rows.Count - 1

                            PredecessorsList.Add(MyDatatable.Rows(i)("PREDECESSOR_SEQ_NBR"))

                        Next

                    End If

                End If

            Catch ex As Exception

                AdvantageFramework.Security.AddWebvantageEventLog(ex.Message.ToString())

            End Try

            If PredecessorsList IsNot Nothing AndAlso PredecessorsList.Count > 0 Then

                PredList = New Generic.List(Of Object)

                For Each SequenceNumbersAndLabel In SequenceNumbersAndLabels

                    If PredecessorsList.Contains(CShort(SequenceNumbersAndLabel.Split(":").First)) Then

                        PredList.Add(New With {.Predecessor = SequenceNumbersAndLabel.Split(":").Last})

                    End If

                Next

            End If

        End If

        JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer

        Return JavaScriptSerializer.Serialize(New With {.Predecessors = PredList})

    End Function
    <System.Web.Services.WebMethod(True)>
    Public Shared Function LinkItem(ByVal DataKey As String, ByVal Linked As String) As String

        Dim Keys As String() = Nothing
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Integer = 0
        Dim SequenceNumber As Integer = -1
        Dim LinkToTaskSequenceNumber As Integer = -1
        Dim Status As Integer = Nothing
        Dim Message As String = ""
        Dim JavaScriptSerializer As System.Web.Script.Serialization.JavaScriptSerializer = Nothing

        Keys = DataKey.Split("|")

        Try

            JobNumber = Keys(0)

        Catch ex As Exception
            JobNumber = 0
        End Try

        Try

            JobComponentNumber = Keys(1)

        Catch ex As Exception
            JobNumber = 0
        End Try

        Try

            SequenceNumber = Keys(2)

        Catch ex As Exception
            SequenceNumber = -1
        End Try

        If Linked Then

            Try

                LinkToTaskSequenceNumber = Keys(3)

            Catch ex As Exception
                LinkToTaskSequenceNumber = -1
            End Try

        End If

        If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_traffic_schedule_LinkTasks {0}, {1}, {2}, {3}, {4}", JobNumber, JobComponentNumber, SequenceNumber, CShort(Linked), LinkToTaskSequenceNumber)

            End Using

            Status = System.Net.HttpStatusCode.OK
            Message = "Success!"

        Else

            Status = System.Net.HttpStatusCode.BadRequest
            Message = "Error: Could not get datakey"

        End If

        JavaScriptSerializer = New Script.Serialization.JavaScriptSerializer

        Return JavaScriptSerializer.Serialize(New With {.Status = Status,
                                                        .SequenceNumber = SequenceNumber,
                                                        .Message = Message})

    End Function
    <System.Web.Services.WebMethod(True)>
    Public Shared Function UpdatePredecessors(DataKey As String, Predecessors As String) As String

        Dim Keys As String() = Nothing
        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Integer = 0
        Dim SequenceNumber As Integer = -1
        Dim PredecessorsList As Generic.List(Of Object) = Nothing
        Dim JavaScriptSerializer As System.Web.Script.Serialization.JavaScriptSerializer = Nothing

        Try

            Keys = DataKey.Split("|")

            Try

                JobNumber = Keys(0)

            Catch ex As Exception
                JobNumber = 0
            End Try

            Try

                JobComponentNumber = Keys(1)

            Catch ex As Exception
                JobNumber = 0
            End Try

            Try

                SequenceNumber = Keys(2)

            Catch ex As Exception
                SequenceNumber = -1
            End Try

            Dim MyDatatable As New DataTable
            Using MyConn As New SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))

                Dim MyCommand As New SqlClient.SqlCommand()

                With MyCommand

                    .CommandType = CommandType.Text
                    .CommandText = String.Format("EXEC dbo.advsp_traffic_schedule_UpdatePredsByLevel {0}, {1}, {2}, '{3}'", JobNumber, JobComponentNumber, SequenceNumber, Predecessors)
                    .Connection = MyConn

                End With

                MyConn.Open()
                MyDatatable.Load(MyCommand.ExecuteReader)

            End Using

            If MyDatatable IsNot Nothing Then

                PredecessorsList = New Generic.List(Of Object)

                If MyDatatable.Rows.Count > 0 Then

                    For i As Integer = 0 To MyDatatable.Rows.Count - 1

                        PredecessorsList.Add(New With {.Predecessor = MyDatatable.Rows(i)("Level")})

                    Next

                End If

            End If

        Catch ex As Exception
            PredecessorsList = Nothing
        Finally

            JavaScriptSerializer = New System.Web.Script.Serialization.JavaScriptSerializer

            UpdatePredecessors = JavaScriptSerializer.Serialize(New With {.Predecessors = PredecessorsList})

        End Try

    End Function
    <System.Web.Services.WebMethod(True)>
    Public Shared Function DetailAutoSave(ByVal DataKey As String, ByVal ControlType As String, ByVal ControlName As String, ByVal ControlValue As String) As String

        Dim JobNumber As Integer = 0
        Dim JobComponentNumber As Integer = 0
        Dim SequenceNumber As Integer = -1
        Dim ReturnMessage As String = ""
        Dim RunSQL As Boolean = True
        Dim UpdateAlertDueDates As Boolean = False
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim ar() As String = Nothing
        Dim IsUpdatingCompletedDate As Boolean = False
        Dim DatatableTaskSeqNbrThatWereMadeActive As System.Data.DataTable = Nothing
        Dim AutoAlertTaskEmployees As Boolean = False
        Dim AgencySettingsMethods As AdvantageFramework.Web.AgencySettings.Methods = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim SqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
        Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim Validations As Webvantage.cValidations = Nothing
        Dim ValueSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim DescriptionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim IsValid As Boolean = False
        Dim GoodFunctionCode As String = ""
        Dim SqlParameterList As System.Data.SqlClient.SqlParameter() = Nothing
        Dim Message As String = Nothing
        Dim CurrentStatus As String = ""
        Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
        Dim DataRow As System.Data.DataRow = Nothing
        Dim RowContactsString As String = ""
        Dim RowContactsArray() As String = Nothing
        Dim RowContactIDsString As String = ""
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
        Dim TimeSheet As wvTimeSheet.cTimeSheet = Nothing
        Dim ClientContactID As Integer = Nothing
        Dim NewCode As String = ""
        Dim NewDesc As String = ""
        Dim UpdatingDates As Boolean = False
        Dim oSchedule As cSchedule = New cSchedule(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

        LoGlo.UserCultureSet(LoGlo.UserCultureGet())

        Try

            Schedule = New Webvantage.cSchedule

            ar = DataKey.Split("|")

            If ar.Length <> 3 Then

                Return "Error: Could not get datakey"
                Exit Function

            End If

            Try

                JobNumber = ar(0)

            Catch ex As Exception

                JobNumber = 0

            End Try

            Try

                JobComponentNumber = ar(1)

            Catch ex As Exception

                JobComponentNumber = 0

            End Try

            Try

                SequenceNumber = ar(2)

            Catch ex As Exception

                SequenceNumber = -1

            End Try


            If JobNumber > 0 AndAlso JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

                Try
                    DatatableTaskSeqNbrThatWereMadeActive = New System.Data.DataTable

                    AgencySettingsMethods = New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)
                    AutoAlertTaskEmployees = AgencySettingsMethods.GetValue(AdvantageFramework.Agency.Settings.TRF_NXT_TSK_AUTO_EML, "") = "1"

                    StringBuilder = New System.Text.StringBuilder

                    Using SqlConnection As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))

                        Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                            SqlConnection.Open()
                            SqlTransaction = SqlConnection.BeginTransaction
                            SqlCommand = New System.Data.SqlClient.SqlCommand()

                            StringBuilder.Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET ")

                            ValueSqlParameter = New System.Data.SqlClient.SqlParameter
                            ValueSqlParameter.ParameterName = "@VALUE"

                            ControlValue = ControlValue.Trim()

                            Select Case ControlType

                                Case "txt"

                                    If ControlName.IndexOf("TextBoxTaskCode") > -1 Then

                                        If ControlValue.Trim() <> "" Then

                                            Validations = New cValidations(HttpContext.Current.Session("ConnString"))

                                            If Validations.ValidateTaskCode(ControlValue.Trim()) = False Then

                                                Throw New Exception("Invalid Task Code.")
                                                ReturnMessage = "Invalid Task Code."

                                            End If

                                        End If

                                        StringBuilder.Append("FNC_CODE")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.VarChar
                                            .Size = 10

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxTaskDescription") > -1 Then

                                        Try

                                            DescriptionSqlParameter = New System.Data.SqlClient.SqlParameter("@TRF_DESC", SqlDbType.VarChar, 40)
                                            DescriptionSqlParameter.Value = ControlValue

                                            DataTable = New System.Data.DataTable
                                            DataTable = SqlHelper.ExecuteDataTable(HttpContext.Current.Session("ConnString"), CommandType.Text, "SELECT TRF_CODE FROM TRAFFIC_FNC WITH(NOLOCK) WHERE TRF_DESC = @TRF_DESC;", "DtData", DescriptionSqlParameter)

                                            If Not DataTable Is Nothing Then

                                                If DataTable.Rows.Count > 0 Then

                                                    IsValid = True
                                                    GoodFunctionCode = DataTable.Rows(0)("TRF_CODE").ToString()

                                                End If

                                            End If

                                            If IsValid = False Then

                                                StringBuilder.Append(" FNC_CODE = NULL, ")

                                            Else

                                                StringBuilder.Append(" FNC_CODE = '")
                                                StringBuilder.Append(GoodFunctionCode)
                                                StringBuilder.Append("', ")

                                            End If

                                        Catch ex As Exception

                                        End Try

                                        StringBuilder.Append("TASK_DESCRIPTION")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.VarChar
                                            .Size = 40

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxJobOrder") > -1 Then

                                        If ControlValue.Trim() <> "" AndAlso IsNumeric(ControlValue) = False Then

                                            ReturnMessage = "Invalid Job Order."

                                        End If

                                        StringBuilder.Append("JOB_ORDER")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallInt

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = CType(ControlValue, Integer)

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxJobDays") > -1 Then

                                        'UpdatingDates = True

                                        If ControlValue.Trim() <> "" AndAlso IsNumeric(ControlValue) = False Then

                                            ReturnMessage = "Invalid Job Days."

                                        End If

                                        StringBuilder.Append("JOB_DAYS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallInt

                                            If String.IsNullOrWhiteSpace(ControlValue) Then

                                                .Value = DBNull.Value

                                            Else

                                                Try

                                                    .Value = CType(ControlValue, Integer)

                                                Catch ex As Exception
                                                    .Value = 0
                                                End Try

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxTaskStartDate") > -1 Then

                                        UpdatingDates = True

                                        If ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = False Then

                                            ReturnMessage = "Invalid Start Date."

                                        ElseIf ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = True Then

                                            ControlValue = cGlobals.wvCDate(ControlValue)

                                        End If

                                        StringBuilder.Append("TASK_START_DATE")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallDateTime

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = cGlobals.wvCDate(ControlValue)

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxJobRevisedDate") > -1 Then

                                        UpdatingDates = True

                                        If ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = False Then

                                            ReturnMessage = "Invalid Due Date."

                                        ElseIf ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = True Then

                                            ControlValue = cGlobals.wvCDate(ControlValue)

                                        End If

                                        StringBuilder.Append("JOB_REVISED_DATE")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallDateTime

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = cGlobals.wvCDate(ControlValue)

                                            End If

                                        End With

                                        Try

                                            SqlParameterList = {New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber},
                                                                New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                                                                New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt) With {.Value = SequenceNumber},
                                                                New System.Data.SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = 0},
                                                                New System.Data.SqlClient.SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10) With {.Value = System.DBNull.Value},
                                                                New System.Data.SqlClient.SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime) With {.Value = If(String.IsNullOrWhiteSpace(ControlValue), System.DBNull.Value, ControlValue)}}

                                            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.StoredProcedure, "usp_wv_JOB_TRAFFIC_DET_SAVE_REVISED_COLS", SqlParameterList)
                                            UpdateAlertDueDates = True

                                        Catch ex As Exception

                                        End Try

                                    ElseIf ControlName.IndexOf("TextBoxRevisedDueTime") > -1 Then

                                        Try

                                            SqlParameterList = {New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber},
                                                                New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber},
                                                                New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt) With {.Value = SequenceNumber},
                                                                New System.Data.SqlClient.SqlParameter("@TYPE", SqlDbType.SmallInt) With {.Value = 1},
                                                                New System.Data.SqlClient.SqlParameter("@DUE_TIME", SqlDbType.VarChar, 10) With {.Value = ControlValue.Trim()},
                                                                New System.Data.SqlClient.SqlParameter("@JOB_REVISED_DATE", SqlDbType.SmallDateTime) With {.Value = System.DBNull.Value}}

                                            SqlHelper.ExecuteNonQuery(HttpContext.Current.Session("ConnString"), CommandType.StoredProcedure, "usp_wv_JOB_TRAFFIC_DET_SAVE_REVISED_COLS", SqlParameterList)

                                        Catch ex As Exception

                                        End Try

                                        StringBuilder.Append("REVISED_DUE_TIME")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.VarChar
                                            .Size = 10

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxJobDueDate") > -1 Then

                                        UpdatingDates = True

                                        If ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = False Then

                                            ReturnMessage = "Invalid Original Due Date."

                                        ElseIf ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = True Then

                                            ControlValue = cGlobals.wvCDate(ControlValue)

                                        End If

                                        StringBuilder.Append("JOB_DUE_DATE")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallDateTime

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = cGlobals.wvCDate(ControlValue)

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxJobCompletedDate") > -1 Then

                                        UpdatingDates = True

                                        If ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = False Then

                                            ReturnMessage = "Invalid Completed Date."

                                        ElseIf ControlValue.Trim() <> "" AndAlso cGlobals.wvIsDate(ControlValue) = True Then

                                            ControlValue = cGlobals.wvCDate(ControlValue)

                                        End If

                                        StringBuilder.Append("JOB_COMPLETED_DATE")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.SmallDateTime

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else
                                                .Value = cGlobals.wvCDate(ControlValue)

                                            End If

                                        End With

                                        If ReturnMessage = "" Then 'AndAlso Not [String].IsNullOrWhiteSpace(ControlValue) Then

                                            IsUpdatingCompletedDate = True

                                        End If

                                    ElseIf ControlName.IndexOf("TextBoxJobHours") > -1 Then

                                        If ControlValue.Trim() <> "" AndAlso IsNumeric(ControlValue) = False Then

                                            ReturnMessage = "Invalid Job Hours."

                                        End If

                                        StringBuilder.Append("JOB_HRS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.Decimal

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = CType(ControlValue, Decimal)

                                            End If

                                        End With

                                        Message = Schedule.UpdateTaskEmployeeHours(JobNumber, JobComponentNumber, SequenceNumber, CType(ControlValue, Decimal))

                                        If Message <> "" Then

                                            ReturnMessage = Message

                                        End If

                                    ElseIf ControlName.IndexOf("TextBoxEmployees") > -1 Then

                                        ControlValue = MiscFN.CleanStringForSplit(ControlValue, ",")

                                        DataTable = New System.Data.DataTable

                                        DataTable = Schedule.UpdateTaskEmployeeListFromString(JobNumber, JobComponentNumber, SequenceNumber, ControlValue)

                                        If DataTable.Rows(0)("MESSAGE").ToString().Trim() <> "SUCCESS" Then

                                            For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                                ReturnMessage &= DataRow("MESSAGE").ToString().Trim() & "##"

                                            Next

                                        End If

                                        RunSQL = False

                                    ElseIf ControlName.IndexOf("RadAutoCompleteBoxEmployees") > -1 Then

                                        ControlValue = MiscFN.CleanStringForSplit(ControlValue, ",")

                                        If ControlName = "RadAutoCompleteBoxEmployeesDelete" Then

                                            DataTable = New System.Data.DataTable

                                            DataTable = Schedule.UpdateTaskEmployeeListFromString(JobNumber, JobComponentNumber, SequenceNumber, ControlValue)

                                            If DataTable.Rows(0)("MESSAGE").ToString().Trim() <> "SUCCESS" Then

                                                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                                    ReturnMessage &= DataRow("MESSAGE").ToString().Trim() & "##"

                                                Next

                                            End If

                                        Else

                                            If oSchedule.CheckJobComponentTaskEmployee(JobNumber, JobComponentNumber, SequenceNumber, ControlValue) = False Then
                                                Message = oSchedule.AddEmployeeToTask(JobNumber, JobComponentNumber, SequenceNumber, ControlValue)
                                                If Message Is Nothing Or Message = "" Then
                                                    Message = "SUCCESS"
                                                End If
                                            Else
                                                Message = "SUCCESS"
                                            End If

                                            If Message <> "SUCCESS" Then

                                                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                                    ReturnMessage &= Message 'DataRow("MESSAGE").ToString().Trim() & "##"

                                                Next

                                            End If

                                        End If

                                        RunSQL = False

                                    ElseIf ControlName.IndexOf("TxtPredecessor") > -1 Then

                                        ControlValue = MiscFN.CleanStringForSplit(ControlValue, ",")

                                        If ControlValue <> "" AndAlso IsNumeric(ControlValue) = True Then

                                            If ControlValue = SequenceNumber.ToString Then

                                                Throw New Exception("A task cannot be a predecessor of itself")
                                                ReturnMessage = "A task cannot be a predecessor of itself."

                                            End If

                                        End If

                                        DataTable = New System.Data.DataTable

                                        DataTable = Schedule.UpdateTaskPredListFromString(JobNumber, JobComponentNumber, SequenceNumber, ControlValue)

                                        If Not DataTable Is Nothing Then

                                            If DataTable.Rows(0)("MESSAGE").ToString().Trim() <> "SUCCESS" Then

                                                For Each DataRow In DataTable.Rows.OfType(Of System.Data.DataRow)()

                                                    ReturnMessage &= DataRow("MESSAGE").ToString().Trim() & "##"

                                                Next

                                            End If

                                        Else

                                            Throw New Exception("Invalid Predecessor.")
                                            ReturnMessage = "Invalid Predecessor."

                                        End If

                                        RunSQL = False

                                    ElseIf ControlName.IndexOf("TextBoxClientContacts") > -1 Then

                                        ControlValue = MiscFN.CleanStringForSplit(ControlValue, ",")

                                        RowContactsString = MiscFN.CleanStringForSplit(ControlValue, ",")
                                        RowContactsArray = RowContactsString.Split(",")

                                        Try

                                            TimeSheet = New wvTimeSheet.cTimeSheet(CStr(HttpContext.Current.Session("ConnString")))

                                            TimeSheet.GetJobInfo(JobNumber, "", "", ClientCode, DivisionCode, ProductCode)

                                            If ClientCode = "" OrElse DivisionCode = "" OrElse ProductCode = "" Then

                                                ReturnMessage = "Problem getting the Client/Division/Product for this job"

                                            Else

                                                ReturnMessage = ""

                                            End If

                                        Catch ex As Exception
                                            ReturnMessage = "Problem getting the Client/Division/Product for this job"
                                        End Try

                                        If ReturnMessage = "" Then

                                            For Each RowContact In RowContactsArray

                                                If String.IsNullOrWhiteSpace(RowContact) = False Then

                                                    ClientContactID = Schedule.WVGetContactCodeID(RowContact, ClientCode, DivisionCode, ProductCode)

                                                    If ClientContactID <> 0 Then

                                                        If Schedule.WVCheckContactCodeIDScheduleUser(ClientContactID) = 1 AndAlso Schedule.WVCheckContactCodeIDInactive(ClientContactID) = 0 Then

                                                            RowContactIDsString &= ClientContactID & ","

                                                        End If
                                                    End If

                                                End If

                                            Next

                                        End If

                                        ReturnMessage = Schedule.UpdateTaskContactListFromString(JobNumber, JobComponentNumber, SequenceNumber, RowContactIDsString)
                                        RunSQL = False

                                    ElseIf ControlName.IndexOf("TextBoxFunctionComments") > -1 Then

                                        StringBuilder.Append("FNC_COMMENTS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.Text

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxDueDateComments") > -1 Then

                                        StringBuilder.Append("DUE_DATE_COMMENTS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.Text

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    ElseIf ControlName.IndexOf("TextBoxRevisionDateComments") > -1 Then

                                        StringBuilder.Append("REV_DATE_COMMENTS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.Text

                                            If ControlValue = "" Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    End If

                                Case "ddl"

                                    If ControlName.IndexOf("RadComboBoxTaskStatus") > -1 Then

                                        StringBuilder.Append("TASK_STATUS")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.VarChar
                                            .Size = 1
                                            .Value = ControlValue

                                        End With

                                        If AutoAlertTaskEmployees = True AndAlso ControlValue = "A" Then

                                            'This is to handle a task that was automatically made active, but since the grid doesn't refresh, user could still make it active manually and this will prevent double email.

                                            Try

                                                JobComponentTask = Nothing
                                                JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, JobNumber, JobComponentNumber, SequenceNumber)

                                                If Not JobComponentTask Is Nothing Then

                                                    CurrentStatus = JobComponentTask.StatusCode

                                                End If

                                            Catch ex As Exception
                                                CurrentStatus = ""
                                            End Try

                                            If CurrentStatus <> "A" Then

                                                DatatableTaskSeqNbrThatWereMadeActive.Columns.Add("SEQ_NBR")

                                                DataRow = DatatableTaskSeqNbrThatWereMadeActive.NewRow()
                                                DataRow("SEQ_NBR") = SequenceNumber

                                                DatatableTaskSeqNbrThatWereMadeActive.Rows.Add(DataRow)

                                            End If

                                        End If

                                    ElseIf ControlName.IndexOf("RadComboBoxPhaseDescription") > -1 Then

                                        StringBuilder.Append("TRAFFIC_PHASE_ID")

                                        If CType(ControlValue.Trim(), Integer) = 0 Then

                                            ValueSqlParameter.Value = System.DBNull.Value

                                        Else

                                            ValueSqlParameter.Value = CType(ControlValue.Trim(), Integer)

                                        End If

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.Int

                                        End With

                                    ElseIf ControlName.IndexOf("RadComboBoxEstimateFunction") > -1 Then

                                        StringBuilder.Append("FNC_EST")

                                        With ValueSqlParameter

                                            .SqlDbType = SqlDbType.VarChar
                                            .Size = 6

                                            If ControlValue = "" OrElse ControlValue.ToLower().IndexOf("none") > -1 Then

                                                .Value = System.DBNull.Value

                                            Else

                                                .Value = ControlValue

                                            End If

                                        End With

                                    End If

                                Case "chk"

                                    If ControlName.IndexOf("CheckBoxMilestone") > -1 Then

                                        StringBuilder.Append("MILESTONE")

                                    ElseIf ControlName.IndexOf("CheckBoxDueDateLock") > -1 Then

                                        StringBuilder.Append("DUE_DATE_LOCK")

                                    End If

                                    With ValueSqlParameter

                                        .SqlDbType = SqlDbType.SmallInt
                                        .Value = CType(ControlValue, Integer)

                                    End With

                            End Select

                            StringBuilder.Append(" = @VALUE")
                            StringBuilder.Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;")

                            SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int) With {.Value = JobNumber})
                            SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt) With {.Value = JobComponentNumber})
                            SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt) With {.Value = SequenceNumber})

                            SqlCommand.Parameters.Add(ValueSqlParameter)

                            Try

                                If RunSQL = True AndAlso ReturnMessage = "" Then

                                    With SqlCommand

                                        .CommandText = StringBuilder.ToString()
                                        .CommandType = CommandType.Text
                                        .Connection = SqlConnection
                                        .Transaction = SqlTransaction
                                        .ExecuteNonQuery()

                                    End With

                                    SqlTransaction.Commit()

                                    If UpdateAlertDueDates = True Then

                                        If Schedule.UpdateTaskAlertsDueDate(JobNumber, JobComponentNumber, SequenceNumber, ReturnMessage) = False Then

                                        End If

                                    End If

                                    If IsUpdatingCompletedDate = True Then

                                        DatatableTaskSeqNbrThatWereMadeActive = Schedule.SetNextTaskActive(JobNumber, JobComponentNumber, SequenceNumber, ReturnMessage)

                                        If Schedule.AutoUpdateTrafficCode(JobNumber, JobComponentNumber, ReturnMessage, NewCode, NewDesc) = True Then

                                            ReturnMessage &= "|" & NewCode & "|" & NewDesc

                                        End If

                                        If DatatableTaskSeqNbrThatWereMadeActive IsNot Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                                            ReturnMessage &= "|Next Seq Nbr|" & String.Join("|", (From DtRow In DatatableTaskSeqNbrThatWereMadeActive.Rows.OfType(Of System.Data.DataRow)()
                                                                                                  Select DtRow("SEQ_NBR")).ToArray)

                                        End If

                                    End If

                                    If UpdatingDates = True Then

                                        Schedule.UpdateScheduleHierarchyDates(JobNumber, JobComponentNumber)

                                    End If

                                    If AutoAlertTaskEmployees = True Then

                                        'manually set to active...autosend alert to emps??
                                        If Not DatatableTaskSeqNbrThatWereMadeActive Is Nothing AndAlso DatatableTaskSeqNbrThatWereMadeActive.Rows.Count > 0 Then

                                            Dim ThisSeqNbr As Integer = 0

                                            Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
                                            Dim EmpCodeString As String = ""
                                            Dim NewAlertId As Integer = 0

                                            Dim _Session As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("AdvantageUserLicenseInUseID"), HttpContext.Current.Session("ConnString"))

                                            For j As Integer = 0 To DatatableTaskSeqNbrThatWereMadeActive.Rows.Count - 1

                                                ThisSeqNbr = CType(DatatableTaskSeqNbrThatWereMadeActive.Rows(j)("SEQ_NBR"), Integer)

                                                NewAlertId = AdvantageFramework.ProjectSchedule.CreateTaskAlert(DbContext, JobNumber, JobComponentNumber, ThisSeqNbr, HttpContext.Current.Session("EmpCode"), EmpCodeString)

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
                                                        .InsertEmailBodyAsAlertDescription = True
                                                        .SessionID = HttpContext.Current.Session.SessionID.ToString()
                                                        .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                                                        .Send()

                                                    End With

                                                    Try
                                                        SignalR.Classes.NotificationHub.NotifyRecipientsAll(NewAlertId, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                                                    Catch ex As Exception
                                                    End Try

                                                End If

                                                EmpCodeString = ""
                                                NewAlertId = 0

                                            Next

                                        End If

                                    End If

                                End If
                            Catch ex As Exception
                                SqlTransaction.Rollback()
                                ReturnMessage = ex.Message.ToString()
                            Finally

                                If SqlConnection.State = ConnectionState.Open Then

                                    SqlConnection.Close()

                                End If

                            End Try
                        End Using

                    End Using

                Catch ex As Exception

                    ReturnMessage = ex.Message.ToString()

                End Try

                Return ReturnMessage

            Else

                Return "Invalid datakey:  " & JobNumber.ToString() & "," & JobComponentNumber.ToString() & "," & SequenceNumber.ToString()
                Exit Function

            End If


        Catch ex As Exception

            Return "Error:  " & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

        End Try
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function SaveTaskCode(ByVal DataKey As String, ByVal TaskCodeClientId As String, ByVal TaskDescClientId As String, ByVal TaskCodeValue As String) As String

        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = -1
        Dim ReturnMessage As String = ""
        Dim SQL As New System.Text.StringBuilder

        Dim ar() As String
        ar = DataKey.Split("|")
        If ar.Length <> 3 Then
            Return "Error:  Could not get datakey"
            Exit Function
        End If
        Try
            JobNumber = ar(0)
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            JobComponentNbr = ar(1)
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            SeqNbr = ar(2)
        Catch ex As Exception
            SeqNbr = -1
        End Try

        If JobNumber > 0 AndAlso JobComponentNbr > 0 AndAlso SeqNbr > -1 Then
            If TaskCodeValue.Trim() <> "" Then
                Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
                If v.ValidateTaskCode(TaskCodeValue.Trim()) = False Then
                    ReturnMessage = "Invalid Task Code."
                Else
                    Dim Desc As String
                    Try
                        Dim StrSQL As String = "SELECT TRF_DESC FROM TRAFFIC_FNC WITH(NOLOCK) WHERE TRF_CODE = @TRF_CODE;"
                        Dim MyCmd As New System.Data.SqlClient.SqlCommand()

                        Dim pCode As New System.Data.SqlClient.SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
                        pCode.Value = TaskCodeValue.Trim()
                        MyCmd.Parameters.Add(pCode)
                        Using MyConn As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))
                            MyConn.Open()
                            With MyCmd
                                .CommandText = StrSQL
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                Desc = .ExecuteScalar()
                            End With
                        End Using
                    Catch ex As Exception
                    End Try
                    Try
                        Dim StrSQL As String = "UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET FNC_CODE = @FNC_CODE, TASK_DESCRIPTION = @TASK_DESCRIPTION WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;"
                        Dim MyCmd As New System.Data.SqlClient.SqlCommand()

                        Dim pCode As New System.Data.SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
                        pCode.Value = TaskCodeValue.Trim()
                        MyCmd.Parameters.Add(pCode)

                        If Desc.Trim() <> "" Then
                            Dim pDesc As New System.Data.SqlClient.SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
                            pDesc.Value = Desc.Trim()
                            MyCmd.Parameters.Add(pDesc)
                        End If

                        Dim pJOB_NUMBER As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJOB_NUMBER.Value = JobNumber
                        MyCmd.Parameters.Add(pJOB_NUMBER)

                        Dim pJOB_COMPONENT_NBR As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        pJOB_COMPONENT_NBR.Value = JobComponentNbr
                        MyCmd.Parameters.Add(pJOB_COMPONENT_NBR)

                        Dim pSEQ_NBR As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)

                        Using MyConn As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))
                            Dim MyTrans As System.Data.SqlClient.SqlTransaction
                            MyConn.Open()
                            MyTrans = MyConn.BeginTransaction
                            Try
                                With MyCmd
                                    .CommandText = StrSQL
                                    .CommandType = CommandType.Text
                                    .Connection = MyConn
                                    .Transaction = MyTrans
                                    .ExecuteNonQuery()
                                    ReturnMessage = "OK|" & TaskDescClientId & "|" & Desc
                                End With
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                    Catch ex As Exception
                    End Try
                End If
            Else
                'Set fn code to null
                Try
                    Dim MyCmd As New System.Data.SqlClient.SqlCommand()

                    Using MyConn As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))
                        Dim pJOB_NUMBER As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                        pJOB_NUMBER.Value = JobNumber
                        MyCmd.Parameters.Add(pJOB_NUMBER)

                        Dim pJOB_COMPONENT_NBR As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                        pJOB_COMPONENT_NBR.Value = JobComponentNbr
                        MyCmd.Parameters.Add(pJOB_COMPONENT_NBR)

                        Dim pSEQ_NBR As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                        pSEQ_NBR.Value = SeqNbr
                        MyCmd.Parameters.Add(pSEQ_NBR)


                        Dim MyTrans As System.Data.SqlClient.SqlTransaction
                        MyConn.Open()
                        MyTrans = MyConn.BeginTransaction
                        Try
                            With MyCmd
                                .CommandText = "UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET FNC_CODE = NULL WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;"
                                .CommandType = CommandType.Text
                                .Connection = MyConn
                                .Transaction = MyTrans
                                .ExecuteNonQuery()
                                Return ""
                            End With
                            MyTrans.Commit()
                        Catch ex As Exception
                            MyTrans.Rollback()
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using

                Catch ex As Exception

                End Try
            End If
        End If

        Return ReturnMessage
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function SaveTaskDesc(ByVal DataKey As String, ByVal TaskCodeClientId As String, ByVal TaskDescClientId As String, ByVal TaskCodeValue As String, ByVal TaskDescValue As String) As String

        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim SeqNbr As Integer = -1
        Dim ReturnMessage As String = ""
        Dim SQL As New System.Text.StringBuilder

        Dim ar() As String
        ar = DataKey.Split("|")
        If ar.Length <> 3 Then
            Return "Error:  Could not get datakey"
            Exit Function
        End If
        Try
            JobNumber = ar(0)
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            JobComponentNbr = ar(1)
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            SeqNbr = ar(2)
        Catch ex As Exception
            SeqNbr = -1
        End Try

        If JobNumber > 0 AndAlso JobComponentNbr > 0 AndAlso SeqNbr > -1 Then
            Dim IsValid As Boolean = False
            Dim GoodFncCode As String = ""
            Dim dt As New DataTable
            Dim pDESC As New System.Data.SqlClient.SqlParameter("@TRF_DESC", SqlDbType.VarChar, 40)
            pDESC.Value = TaskDescValue
            dt = SqlHelper.ExecuteDataTable(HttpContext.Current.Session("ConnString"), CommandType.Text, "SELECT TRF_CODE FROM TRAFFIC_FNC WITH(NOLOCK) WHERE (TRF_INACTIVE IS NULL OR TRF_INACTIVE = 0) AND TRF_DESC = @TRF_DESC;", "DtData", pDESC)
            'if input something that is a real desc, get the real fnc code
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    IsValid = True
                    GoodFncCode = dt.Rows(0)("TRF_CODE").ToString().Trim()
                End If
            End If

            'if input is something that is custom, save, clear fnc code and push back empty to fnc
            With SQL
                .Append("UPDATE [JOB_TRAFFIC_DET] WITH(ROWLOCK) SET FNC_CODE = ")
                If IsValid = True AndAlso GoodFncCode <> "" Then
                    .Append("@FNC_CODE")
                Else
                    .Append("NULL")
                End If
                .Append(", TASK_DESCRIPTION = @TASK_DESCRIPTION ")
                .Append("WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR AND SEQ_NBR = @SEQ_NBR;")
            End With

            Dim MyCmd As New System.Data.SqlClient.SqlCommand()
            Dim pCode As New System.Data.SqlClient.SqlParameter("@FNC_CODE", SqlDbType.VarChar, 10)
            If IsValid = True AndAlso GoodFncCode <> "" Then
                pCode.Value = GoodFncCode.Trim()
            Else
                pCode.Value = System.DBNull.Value
            End If
            MyCmd.Parameters.Add(pCode)

            Dim pTASK_DESCRIPTION As New System.Data.SqlClient.SqlParameter("@TASK_DESCRIPTION", SqlDbType.VarChar, 40)
            pTASK_DESCRIPTION.Value = TaskDescValue
            MyCmd.Parameters.Add(pTASK_DESCRIPTION)

            Dim pJOB_NUMBER As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber
            MyCmd.Parameters.Add(pJOB_NUMBER)

            Dim pJOB_COMPONENT_NBR As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr
            MyCmd.Parameters.Add(pJOB_COMPONENT_NBR)

            Dim pSEQ_NBR As New System.Data.SqlClient.SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
            pSEQ_NBR.Value = SeqNbr
            MyCmd.Parameters.Add(pSEQ_NBR)

            Using MyConn As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))
                Dim MyTrans As System.Data.SqlClient.SqlTransaction
                MyConn.Open()
                MyTrans = MyConn.BeginTransaction
                Try
                    With MyCmd
                        .CommandText = SQL.ToString()
                        .CommandType = CommandType.Text
                        .Connection = MyConn
                        .Transaction = MyTrans
                        .ExecuteNonQuery()
                        ReturnMessage = "OK|" & TaskCodeClientId & "|" & GoodFncCode
                    End With
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using



        End If


        Return ReturnMessage
    End Function
    <System.Web.Services.WebMethod()>
    Public Shared Function AutoSaveScheduleHeader(ByVal DataKey As String, ByVal FieldName As String, ByVal ControlValue As String, ByVal ControlClientId As String) As String

        Dim JobNumber As Integer = 0
        Dim JobComponentNbr As Integer = 0
        Dim ReturnMessage As String = ""
        Dim IsUpdatingStatusCode As Boolean = False

        Dim Sql As New System.Text.StringBuilder
        Dim ar() As String

        ar = DataKey.Split("|")

        If ar.Length <> 2 Then

            Return "ERROR|Could not get datakey"
            Exit Function

        End If
        Try

            JobNumber = ar(0)

        Catch ex As Exception

            JobNumber = 0

        End Try
        Try

            JobComponentNbr = ar(1)

        Catch ex As Exception

            JobComponentNbr = 0

        End Try

        If ControlValue IsNot Nothing Then

            Try

                ControlValue = ControlValue.Trim()

            Catch ex As Exception
                ControlValue = Nothing
            End Try

        End If

        Try

            Dim pJOB_NUMBER As New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            pJOB_NUMBER.Value = JobNumber

            Dim pJOB_COMPONENT_NBR As New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            pJOB_COMPONENT_NBR.Value = JobComponentNbr

            Dim pVALUE As New System.Data.SqlClient.SqlParameter
            pVALUE.ParameterName = "@VALUE"

            If ControlValue = "" OrElse ControlValue = "[None]" Then

                pVALUE.Value = System.DBNull.Value

            Else

                pVALUE.Value = ControlValue

            End If

            If FieldName = "START_DATE" OrElse FieldName = "JOB_FIRST_USE_DATE" OrElse FieldName = "TRF_SCHEDULE_BY" Then

                Sql.Append("UPDATE [JOB_COMPONENT] WITH(ROWLOCK) SET ")

            Else

                Sql.Append("UPDATE [JOB_TRAFFIC] WITH(ROWLOCK) SET ")

            End If

            Sql.Append(FieldName)
            Sql.Append(" = @VALUE")

            Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
            Select Case FieldName
                Case "TRF_COMMENTS"

                    pVALUE.SqlDbType = SqlDbType.Text

                Case "DATE_SHIPPED", "DATE_DELIVERED", "COMPLETED_DATE", "START_DATE", "JOB_FIRST_USE_DATE" '<-- "Due date"

                    If ControlValue <> "" AndAlso IsDate(ControlValue) = False Then

                        ReturnMessage = "ERROR|Invalid date."

                    End If

                    pVALUE.SqlDbType = SqlDbType.SmallDateTime

                Case "RECEIVED_BY"

                    With pVALUE

                        .SqlDbType = SqlDbType.VarChar
                        .Size = 40

                    End With

                Case "REFERENCE"

                    With pVALUE

                        .SqlDbType = SqlDbType.VarChar
                        .Size = 150

                    End With

                Case "ASSIGN_1", "ASSIGN_2", "ASSIGN_3", "ASSIGN_4", "ASSIGN_5"

                    If ControlValue <> "" AndAlso v.ValidateEmpCode(ControlValue) = False Then

                        ReturnMessage = "ERROR|Invalid Employee."

                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.VarChar
                        .Size = 6

                    End With

                Case "PERCENT_COMPLETE"

                    If ControlValue <> "" AndAlso IsNumeric(ControlValue) = False Then

                        ReturnMessage = "ERROR|Invalid number."

                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.Decimal

                    End With

                Case "INCLUDE_COMPLETED"

                    'Dim oAppVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
                    'oAppVars.getAllAppVars()
                    'oAppVars.setAppVar("IncludeCompleted", Me.ChkShowCompletedTasks.Checked, "Boolean")
                    'oAppVars.SaveAllAppVars()

                Case "TRF_CODE"

                    If ControlValue = "" Then

                        ReturnMessage = "ERROR|Status Code required."

                    Else

                        If v.ValidateTrafficStatus(ControlValue) = False Then

                            ReturnMessage = "ERROR|Invalid Project Schedule Status."

                        End If

                    End If

                    With pVALUE

                        .SqlDbType = SqlDbType.VarChar
                        .Size = 10

                    End With

                    IsUpdatingStatusCode = True

            End Select

            With Sql

                .Append(" WHERE JOB_NUMBER = @JOB_NUMBER AND JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR;")

            End With

            If ReturnMessage = "" Then

                Using MyConn As New System.Data.SqlClient.SqlConnection(HttpContext.Current.Session("ConnString"))

                    Dim MyTrans As System.Data.SqlClient.SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Dim MyCmd As New System.Data.SqlClient.SqlCommand()

                    Try

                        With MyCmd

                            .Parameters.Add(pJOB_NUMBER)
                            .Parameters.Add(pJOB_COMPONENT_NBR)
                            .Parameters.Add(pVALUE)
                            .CommandText = Sql.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()

                        End With

                        MyTrans.Commit()

                        If IsUpdatingStatusCode = True Then

                            Dim s As New cSchedule()
                            Dim StatusDescription As String = AdvantageFramework.StringUtilities.JavascriptSafe(s.GetStatusDescription(ControlValue))

                            If StatusDescription.Trim() <> "" Then

                                ReturnMessage = "STATUS_UPDATE|" & AdvantageFramework.StringUtilities.JavascriptSafe(StatusDescription)

                            Else

                                ReturnMessage = ""

                            End If

                        Else

                            ReturnMessage = ""

                        End If

                    Catch ex As Exception

                        MyTrans.Rollback()
                        ReturnMessage = "ERROR|" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

                    Finally

                        If MyConn.State = ConnectionState.Open Then MyConn.Close()

                    End Try

                End Using

            End If

        Catch ex As Exception

            ReturnMessage = "ERROR|" & AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())

        End Try

        Return ReturnMessage

    End Function

#End Region

#Region " Page Event Handlers "

    Private Sub TrafficSchedule_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim QueryString As AdvantageFramework.Web.QueryString = New AdvantageFramework.Web.QueryString

        QueryString = QueryString.FromCurrent

        _IsJobDashboard = QueryString.IsJobDashboard

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        Me.SetQSVars()

        Me.RadToolbarSchedule.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        'If Me.CurrentQuerystring.IsJobDashboard = True Then

        Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonSeparator0").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("SaveTemplate").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("SaveHeader").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Search").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("New").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("FilterSingle").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("ViewWorksheet").Visible = False
        'Me.RadToolbarSchedule.FindItemByValue("GanttView").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("NewJobAlert").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("NewAlertAssignment").Visible = False
        Me.RadToolbarSchedule.FindItemByText("Modules").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("CheckWorkload").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Status").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Separator4").Visible = False
        Me.RadToolbarSchedule.FindItemByText("Print/Send").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Separator5").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Separator7").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Bookmark").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("ViewMulti").Visible = False
        Me.RadToolbarSchedule.FindItemByValue("Separator3").Visible = False

        Me.CollapsablePanelHeader.Visible = False
        Me.CollapsablePanelAssignments.Visible = False

        'End If

        Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarButtonTasksTooltip").Attributes.Add("id", "RadToolBarButtonTasksTooltip")
        Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarButtonDatesTooltip").Attributes.Add("id", "RadToolBarButtonDatesTooltip")
        Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarButtonEmployeesTooltip").Attributes.Add("id", "RadToolBarButtonEmployeesTooltip")

        Me.ButtonDeleteSelectedTasks.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
        Me.ButtonEmployeesClearAllAssignments.Attributes.Add("onclick", "return confirm('Are you sure you want to clear all assignments?');")

        Me.MyUnityContextMenu.JobNumber = _JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = _JobComponentNumber
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Schedule}

    End Sub
    Protected Sub TrafficSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
            Me.CheckForPredecessors()
            Me.DropPhaseFilter = CType(Me.RadToolbarScheduleGrid.FindItemByValue("RadToolbarButtonPhase").FindControl("DropPhaseFilter"), Telerik.Web.UI.RadComboBox)
            Me.DropSort = CType(Me.RadToolbarScheduleGrid.FindItemByValue("RadToolbarButtonPhase").FindControl("DropSort"), Telerik.Web.UI.RadComboBox)

            Try

                With Telerik.Web.UI.RadAjaxManager.GetCurrent(Page)

                    .ClientEvents.OnResponseEnd = "RadAjaxManagerOnResponseEnd"

                End With

            Catch ex As Exception

            End Try

            Try
                If Not Request.QueryString("JT") = Nothing Then
                    If Request.QueryString("JT") = "1" Then
                        _CameFromJobTemplate = True
                    Else
                        _CameFromJobTemplate = False
                    End If
                Else
                    _CameFromJobTemplate = False
                End If
            Catch ex As Exception
                _CameFromJobTemplate = False
            End Try

            If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                If Request.QueryString("pnl") = "1" Then
                    Me.CollapsablePanelJobs.Collapsed = False
                Else
                    Me.CollapsablePanelJobs.Collapsed = True
                End If


                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    Dim v As New cValidations(Session("ConnString"))
                    If v.ValidateJobCompIsViewable(Session("UserCode"), _JobNumber, _JobComponentNumber) = False Then
                        'Server.Transfer("NoAccess.aspx")
                        Me.ShowMessage("Access to this job/comp is denied")
                        Me.CloseThisWindow()
                        Exit Sub
                    End If

                End If

                LoadScheduleHeader()

                If Me.CalculateByPredecessor = False Then

                    Me.DropSort.Visible = True
                    RadGridProjectSchedule.ClientSettings.AllowExpandCollapse = False
                    RadGridProjectSchedule.MasterTableView.FilterExpression = ""
                    RadGridProjectSchedule.ClientSettings.ClientEvents.OnRowMouseOver = ""

                Else

                    Me.DropSort.Visible = False
                    RadGridProjectSchedule.ClientSettings.AllowExpandCollapse = True
                    RadGridProjectSchedule.MasterTableView.FilterExpression = "(ParentTaskSequenceNumber == NULL)"
                    RadGridProjectSchedule.ClientSettings.ClientEvents.OnRowMouseOver = "OnRowMouseOver"

                End If

                SetScheduleGridColumns()
                Session("errorMsg") = ""
                Session("errorCount") = 0
                Session("PS_Ignore_Filter") = "0"

                LoadPhasesDataTable()
                With Me.DropPhaseFilter
                    .DataSource = _Phases
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End With

                LoadLookups()

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then
                    Me.CollapsablePanelComments.Collapsed = True
                    Me.CollapsablePanelDetails.Collapsed = True
                End If

                SetTrafficScheduleAssignLabels()

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso _SequenceNumber > -1 Then
                    Dim StrEditURL As String = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & _SequenceNumber & "&Client=" & Me.HiddenFieldClientCode.Value & "&Division=" & Me.HiddenFieldDivisionCode.Value & "&Product=" & Me.HiddenFieldProductCode.Value
                    Me.OpenWindow("", StrEditURL)
                End If

                Try

                    Dim appVars As New cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
                    appVars.getAllAppVars()
                    Me.RadGridProjectSchedule.MasterTableView.AllowPaging = Not appVars.getAppVar("DisablePaging", "Boolean", "False") = "True"

                Catch ex As Exception

                    Me.RadGridProjectSchedule.MasterTableView.AllowPaging = True

                End Try

                'RadGridProjectSchedule.MasterTableView.HierarchyDefaultExpanded = True

            Else

                Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

                Select Case Me.EventTarget
                    Case "Refresh"

                        LoadScheduleHeader()
                        Me.RadGridProjectSchedule.Rebind()

                    Case "RebindGrid" ', ""

                        Me.RadGridProjectSchedule.Rebind()

                End Select
            End If


        Catch ex1 As ArithmeticException
            Me.ShowMessage("This number not allowed.")
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
        If _ReloadMe = True Then
            If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then
                Dim strJT As String = ""
                If Not Request.QueryString("JT") = Nothing Then
                    If Request.QueryString("JT") = "1" Then
                        strJT = "1"
                    Else
                        strJT = "0"
                    End If
                End If
                Session("SchedHeaderLoaded") = 0
                MiscFN.ResponseRedirect("TrafficSchedule.aspx?R=1&JT=" & strJT & "&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber, False)
            End If
        End If

        'Ugly cluge to display error message if email does not send in modal page
        If Not Session("errorMsg") Is Nothing Then
            If Session("errorMsg") <> "" Then
                If Session("errorCount") = 1 Then
                    Me.ShowMessage(Session("errorMsg"))
                    Session("errorMsg") = ""
                    Session("errorCount") = 0
                Else
                    Dim ct As Int16
                    ct = Session("errorCount")
                    ct = ct + 1
                    Session("errorCount") = ct
                End If
            End If
        End If

        Me.checkEstApproval()
        Me.CheckUserRights()

        If Me.IsClientPortal = True Then

            Me.RadToolbarButtonSaveAll.Visible = False
            Me.RadToolbarButtonClear.Visible = False
            Me.RadToolbarButtonNew.Visible = False
            Me.RadToolBarButtonUpdateStatus.Visible = False
            Me.RadToolbarButtonViewSingle.Visible = False
            Me.RadToolbarButtonViewMulti.Visible = False
            Me.RadToolbarButtonViewWorksheet.Visible = False
            Me.RadToolbarButtonGanttView.Visible = False
            Me.RadToolBarButtonEstimate.Visible = False
            Me.RadToolbarTemplateButtonStatus.Visible = False
            Me.RadToolbarButtonNewAlertAssignment.Visible = False
            Me.RadToolBarButtonJobOrder.Visible = False
            Me.RadToolbarButtonCheckWorkload.Visible = False
            Me.RadToolbarButtonQuickEdit.Visible = False
            Me.RadToolBarButtonVersions.Visible = False

            Me.ButtonAddTasksFromListOfTasks.Enabled = False
            Me.ButtonAddTasksFromTaskTemplates.Enabled = False
            Me.ButtonAddTasksCopyFromExistingSchedule.Enabled = False

            Me.ButtonDatesCalculate.Enabled = False
            Me.ButtonEmployeesSetTeamByFunction.Enabled = False
            Me.ButtonDatesMarkTempComplete.Enabled = False
            Me.ButtonEmployeesFind.Enabled = False
            Me.ButtonEmployeesClearAllAssignments.Enabled = False
            Me.ButtonSetOriginalDueDateOnlyWhereNotSet.Enabled = False
            Me.ButtonSetOriginalDueDateOnlySelected.Enabled = False
            Me.ButtonSetOriginalDueDateAll.Enabled = False

            Me.ButtonEmployeesSetTeamByFunction.Enabled = False
            Me.ButtonEmployeesSetTeamByRole.Enabled = False
            Me.ButtonDeleteSelectedTasks.Enabled = False
            Me.ButtonSearchAndReplaceInTasks.Enabled = False

            Me.RadToolbarSchedule.FindItemByValue("RadToolBarButtonSeparator0").Visible = False
            Me.RadToolbarSchedule.FindItemByValue("Separator1").Visible = False
            Me.RadToolbarSchedule.FindItemByValue("New").Visible = False
            Me.RadToolbarSchedule.FindItemByValue("ViewMulti").Visible = False
            Me.RadToolbarSchedule.FindItemByValue("GanttView").Visible = False

            'Me.RadToolbarScheduleGrid.FindItemByValue("Separator0").Visible = False
            Me.ButtonAddTasksCreateFromEstimate.Visible = False
            Me.ButtonDatesCalculate.Enabled = False
            'Me.RadToolbarScheduleGrid.FindItemByValue("RadToolBarSplitButtonOriginalDueDate").Visible = False
            Me.ImageButtonJobCompPred.Enabled = False
            Dim access As Integer
            access = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents, False)
            If access = 0 Then
                Me.radbtnDocs.Visible = False
            Else

                radbtnDocs.Visible = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False))

            End If

        End If

        If Me.IsClientPortal = True Then

            Me.RadToolbarSchedule.FindItemByValue("SendAssignment").Visible = False

        End If

        RadToolbarButtonGanttView.Visible = Not _IsJobDashboard

    End Sub
    Private Sub TrafficSchedule_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        'objects
        Dim PhaseFilterValues As String = Nothing

        Try

            If Session(Me.SessionVars.PS_Ignore_Filter.ToString) = "0" Then

                If Me.DropPhaseFilter.Items.Count > 0 AndAlso _TaskPhaseFilter.Trim() <> "" Then

                    PhaseFilterValues = _TaskPhaseFilter

                    If PhaseFilterValues = "is_null" Then

                        PhaseFilterValues = "0"

                    End If

                    MiscFN.RadComboBoxSetIndex(Me.DropPhaseFilter, PhaseFilterValues, False, False)

                End If

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub TrafficSchedule_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub ButtonAddTasksFromListOfTasks_Click(sender As Object, e As EventArgs) Handles ButtonAddTasksFromListOfTasks.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString

        With QueryString

            .Page = "Schedule_QuickAdd.aspx"
            .JobNumber = _JobNumber
            .JobComponentNumber = _JobComponentNumber

            If Not Me.RadDatePickerDueDate.SelectedDate Is Nothing Then

                .DueDate = Me.RadDatePickerDueDate.SelectedDate

            Else

                .DueDate = ""

            End If

            .Rush = False
            .Add("mode", "1")

        End With

        Me.OpenWindow("", QueryString.ToString(True), 800, 875, False, True)

    End Sub
    Private Sub ButtonAddTasksFromTaskTemplates_Click(sender As Object, e As EventArgs) Handles ButtonAddTasksFromTaskTemplates.Click

        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Rush As Integer = 0
        Dim URL As String = ""

        SaveAlmostEverything()

        Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

        DataTable = Schedule.GetScheduleHeader(_JobNumber, _JobComponentNumber, _Session.UserCode, False).Tables(0)

        Try

            If IsDBNull(DataTable.Rows(0)("JOB_RUSH_CHARGES")) = False Then

                Rush = CType(DataTable.Rows(0)("JOB_RUSH_CHARGES"), Integer)

            End If

        Catch ex As Exception
            Rush = 0
        End Try

        URL = "TrafficSchedule_QuickAdd.aspx?R=1&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&DueDate=" & Me.RadDatePickerDueDate.SelectedDate & "&Rush=" & Rush.ToString()
        Me.OpenWindow("", URL, 600, 800, False, True)

    End Sub
    Private Sub ButtonAddTasksCopyFromExistingSchedule_Click(sender As Object, e As EventArgs) Handles ButtonAddTasksCopyFromExistingSchedule.Click

        SaveAlmostEverything()
        Me.OpenWindow("", "TrafficSchedule_CopyFrom.aspx?R=1&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber, 590, 900, False, True)

    End Sub
    Private Sub ButtonAddTasksCreateFromEstimate_Click(sender As Object, e As EventArgs) Handles ButtonAddTasksCreateFromEstimate.Click

        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        SaveAlmostEverything()

        QueryString = New AdvantageFramework.Web.QueryString()

        With QueryString

            .Page = "Schedule_AddFromEst.aspx"
            .JobNumber = _JobNumber
            .JobComponentNumber = _JobComponentNumber

        End With

        Me.OpenWindow("", QueryString.ToString(True), 730, 825, False, True)

    End Sub

    Private Sub ButtonDeleteSelectedTasks_Click(sender As Object, e As EventArgs) Handles ButtonDeleteSelectedTasks.Click

        Dim Count As Integer = 0

        SaveAlmostEverything(False)

        For Each GridDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If GridDataItem.Selected OrElse HiddenFieldSelectAll.Value = "1" Then

                DeleteGridRow(_JobNumber, _JobComponentNumber, CShort(GridDataItem.GetDataKeyValue("SequenceNumber")))

            End If

            Count = Count + 1

        Next

        HiddenFieldSelectAll.Value = 0

        If Count = 0 Then

            Me.ShowMessage("No rows were selected for deletion.")
            Exit Sub

        End If

        RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ButtonSearchAndReplaceInTasks_Click(sender As Object, e As EventArgs) Handles ButtonSearchAndReplaceInTasks.Click

        SaveAlmostEverything()
        Me.OpenWindow("Search and Replace", "ProjectManagement/ProjectSchedule/FindAndReplace?wm=0&Components=" & _JobNumber.ToString() & "," & _JobComponentNumber.ToString(), 0, 0, False, True)

    End Sub
    Private Sub ButtonFilterTasks_Click(sender As Object, e As EventArgs) Handles ButtonFilterTasks.Click

        SaveAlmostEverything()

        Dim StringBuilder As New System.Text.StringBuilder

        If Not Request.QueryString("Emp") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Emp=")
            StringBuilder.Append(Request.QueryString("Emp").ToString())

        End If

        If Not Request.QueryString("Task") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Task=")
            StringBuilder.Append(Request.QueryString("Task").ToString())

        End If

        If Not Request.QueryString("Role") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Role=")
            StringBuilder.Append(Request.QueryString("Role").ToString())

        End If

        If Not Request.QueryString("Cut") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Cut=")
            StringBuilder.Append(Request.QueryString("Cut").ToString())

        End If

        If Not Request.QueryString("Comp") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Comp=")
            StringBuilder.Append(Request.QueryString("Comp").ToString())

        End If

        If Not Request.QueryString("Pend") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Pend=")
            StringBuilder.Append(Request.QueryString("Pend").ToString())

        End If

        If Not Request.QueryString("Proj") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("Proj=")
            StringBuilder.Append(Request.QueryString("Proj").ToString())

        End If

        If Not Request.QueryString("P") = Nothing Then

            StringBuilder.Append("&")
            StringBuilder.Append("P=")
            StringBuilder.Append(Request.QueryString("P").ToString())

        End If

        Me.OpenWindow("Task Filter", "TrafficSchedule_Filter.aspx?View=single&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber & StringBuilder.ToString, 300, 555, False, True)

    End Sub
    Private Sub CheckBoxAutoStatusUpdateTAsks_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoStatusUpdateTasks.CheckedChanged

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Dim SQL As String = ""
            Dim AutoUpdateStatus As Integer = 0
            Dim SqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing

            If Me.CheckBoxAutoStatusUpdateTasks.Checked = True Then

                AutoUpdateStatus = 1

            End If

            SQL = String.Format("UPDATE JOB_TRAFFIC WITH(ROWLOCK) SET AUTO_UPDATE_STATUS = {0} WHERE JOB_NUMBER = {1} AND JOB_COMPONENT_NBR = {2};", AutoUpdateStatus, _JobNumber, _JobComponentNumber)

            Using SqlConnection = New System.Data.SqlClient.SqlConnection(Session("ConnString"))

                SqlConnection.Open()

                SqlTransaction = SqlConnection.BeginTransaction
                SqlCommand = New System.Data.SqlClient.SqlCommand(SQL, SqlConnection, SqlTransaction)

                Try

                    SqlCommand.ExecuteNonQuery()
                    SqlTransaction.Commit()

                Catch ex As Exception
                    SqlTransaction.Rollback()
                Finally

                    If SqlConnection.State = ConnectionState.Open Then

                        SqlConnection.Close()

                    End If

                End Try

            End Using

            Me.RadGridProjectSchedule.Rebind()

        End If

    End Sub

    Private Sub ButtonDatesClear_Click(sender As Object, e As EventArgs) Handles ButtonDatesClear.Click

        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            ClearDates(False)

        End If

        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ButtonDatesClearIncludeOriginal_Click(sender As Object, e As EventArgs) Handles ButtonDatesClearIncludeOriginal.Click

        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            ClearDates(True)

        End If

        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ButtonDatesCalculate_Click(sender As Object, e As EventArgs) Handles ButtonDatesCalculate.Click

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            If Me.ValidateStartAndDueDates(True) = False Then

                Exit Sub

            End If

            SaveScheduleAssignements()
            SaveScheduleComments()
            SaveOtherInformation()
            SaveScheduleDetails(True)

            If Me.CalculateScheduleDates() = True Then

                LoadScheduleHeader()
                Me.RadGridProjectSchedule.Rebind()

            End If

        End If

    End Sub
    Private Sub ButtonDatesMarkTempComplete_Click(sender As Object, e As EventArgs) Handles ButtonDatesMarkTempComplete.Click

        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Dim Schedule As Webvantage.cSchedule = Nothing
            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)
            Schedule.MarkTempComplete(_JobNumber, _JobComponentNumber)

        End If

        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ButtonSetOriginalDueDateOnlyWhereNotSet_Click(sender As Object, e As EventArgs) Handles ButtonSetOriginalDueDateOnlyWhereNotSet.Click

        SaveAlmostEverything()

        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                         "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} " &
                                                         "AND ((NOT JOB_REVISED_DATE IS NULL) AND (JOB_DUE_DATE IS NULL));", _JobNumber, _JobComponentNumber))

        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ButtonSetOriginalDueDateOnlySelected_Click(sender As Object, e As EventArgs) Handles ButtonSetOriginalDueDateOnlySelected.Click

        SaveAlmostEverything()

        Dim StringBuilder As New System.Text.StringBuilder
        Dim Count As Integer = 0
        Dim VariableString As String = ""

        For Each GridDataItem In RadGridProjectSchedule.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If GridDataItem.Selected Then

                If IsNumeric(GridDataItem.GetDataKeyValue("SequenceNumber")) Then

                    StringBuilder.Append(GridDataItem.GetDataKeyValue("SequenceNumber"))
                    StringBuilder.Append(",")

                End If

                Count += 1

            End If

        Next

        If Count = 0 Then

            Me.ShowMessage("No rows were selected.")
            Exit Sub

        Else

            VariableString = MiscFN.CleanStringForSplit(StringBuilder.ToString(), ",")

            _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                             "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR IN ({2});", _JobNumber, _JobComponentNumber, VariableString))


            Me.RadGridProjectSchedule.Rebind()

        End If

    End Sub
    Private Sub ButtonSetOriginalDueDateAll_Click(sender As Object, e As EventArgs) Handles ButtonSetOriginalDueDateAll.Click

        SaveAlmostEverything()

        _DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET WITH(ROWLOCK) SET JOB_DUE_DATE = JOB_REVISED_DATE " &
                                                         "WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};", _JobNumber, _JobComponentNumber))

        Me.RadGridProjectSchedule.Rebind()

    End Sub

    Private Sub ButtonEmployeesFind_Click(sender As Object, e As EventArgs) Handles ButtonEmployeesFind.Click

        Me.OpenWindow("Find Employees", "Resources_Emps_Find.aspx?from=1&j=" & _JobNumber & "&jc=" & _JobComponentNumber & "&cli=" & Me.HiddenFieldClientCode.Value, , , , False)

    End Sub
    Private Sub ButtonEmployeesSetTeamByFunction_Click(sender As Object, e As EventArgs) Handles ButtonEmployeesSetTeamByFunction.Click

        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Dim Schedule As Webvantage.cSchedule = Nothing
            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)
            Schedule.ApplyTeam(True, _JobNumber, _JobComponentNumber)

            Me.RadGridProjectSchedule.Rebind()

        End If

    End Sub
    Private Sub ButtonEmployeesSetTeamByRole_Click(sender As Object, e As EventArgs) Handles ButtonEmployeesSetTeamByRole.Click

        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Dim Schedule As Webvantage.cSchedule = Nothing
            Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)
            Schedule.ApplyTeam(False, _JobNumber, _JobComponentNumber)

            Me.RadGridProjectSchedule.Rebind()

        End If

    End Sub
    Private Sub ButtonEmployeesClearAllAssignments_Click(sender As Object, e As EventArgs) Handles ButtonEmployeesClearAllAssignments.Click
        SaveAlmostEverything()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            Dim SqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SQL As String = ""

            SQL = "DELETE FROM JOB_TRAFFIC_DET_EMPS WHERE JOB_NUMBER = " & _JobNumber & " AND JOB_COMPONENT_NBR = " & _JobComponentNumber

            Using SqlConnection = New System.Data.SqlClient.SqlConnection(Session("ConnString"))

                SqlConnection.Open()
                SqlTransaction = SqlConnection.BeginTransaction
                SqlCommand = New System.Data.SqlClient.SqlCommand(SQL, SqlConnection, SqlTransaction)

                Try
                    SqlCommand.ExecuteNonQuery()
                    SqlTransaction.Commit()
                Catch ex As Exception
                    SqlTransaction.Rollback()
                Finally

                    If SqlConnection.State = ConnectionState.Open Then

                        SqlConnection.Close()

                    End If

                End Try

            End Using

            Me.RadGridProjectSchedule.Rebind()

        End If

    End Sub

    Private Sub LinkButtonVersions_Click(sender As Object, e As EventArgs) Handles LinkButtonVersions.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .JobNumber = _JobNumber
                .JobComponentNumber = _JobComponentNumber
                .Page = "TrafficScheduleVersion.aspx"

            End With

            Me.OpenWindow(QueryString)

        End If

    End Sub
    Private Sub LinkButtonVersionInformation_Click(sender As Object, e As EventArgs) Handles LinkButtonVersionInformation.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            QueryString = New AdvantageFramework.Web.QueryString

            With QueryString

                .JobNumber = _JobNumber
                .JobComponentNumber = _JobComponentNumber

                If IsNumeric(LinkButtonVersionInformation.CommandArgument) = True Then

                    .TrafficScheduleVersionID = CType(LinkButtonVersionInformation.CommandArgument, Integer)
                    .Page = "TrafficScheduleVersion_New.aspx"

                Else

                    .Page = "TrafficScheduleVersion.aspx"

                End If

            End With

            Me.OpenWindow(QueryString)

        End If

    End Sub
    Private Sub LinkButtonClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonClient.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If Me.IsClientPortal = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .Page = "TrafficSchedule_Search.aspx"
                .ClientCode = ""
                .DivisionCode = ""
                .ProductCode = ""
                .JobNumber = 0
                .JobComponentNumber = 0

            End With

            Me.OpenWindow("", QueryString.ToString(True))

        End If
    End Sub
    Private Sub LinkButtonDivision_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonDivision.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If Me.IsClientPortal = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .Page = "TrafficSchedule_Search.aspx"
                .ClientCode = Me.HiddenFieldClientCode.Value
                .DivisionCode = ""
                .ProductCode = ""
                .JobNumber = 0
                .JobComponentNumber = 0

            End With

            Me.OpenWindow("", QueryString.ToString(True))

        End If
    End Sub
    Private Sub LinkButtonProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonProduct.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If Me.IsClientPortal = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .Page = "TrafficSchedule_Search.aspx"
                .ClientCode = Me.HiddenFieldClientCode.Value
                .DivisionCode = Me.HiddenFieldDivisionCode.Value
                .ProductCode = ""
                .JobNumber = 0
                .JobComponentNumber = 0

            End With

            Me.OpenWindow("", QueryString.ToString(True))

        End If
    End Sub
    Private Sub LinkButtonJob_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonJob.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If Me.IsClientPortal = False Then

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .Page = "TrafficSchedule_Search.aspx"
                .ClientCode = Me.HiddenFieldClientCode.Value
                .DivisionCode = Me.HiddenFieldDivisionCode.Value
                .ProductCode = Me.HiddenFieldProductCode.Value
                .JobNumber = 0
                .JobComponentNumber = 0

            End With

            Me.OpenWindow("", QueryString.ToString(True))

        End If
    End Sub
    Private Sub LinkButtonJobComponent_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButtonJobComponent.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        If Me.IsClientPortal = False Then

            QueryString = New AdvantageFramework.Web.QueryString

            With QueryString

                .Page = "TrafficSchedule_Search.aspx"
                .ClientCode = Me.HiddenFieldClientCode.Value
                .DivisionCode = Me.HiddenFieldDivisionCode.Value
                .ProductCode = Me.HiddenFieldProductCode.Value
                .JobNumber = _JobNumber
                .JobComponentNumber = 0

            End With

            Me.OpenWindow("", QueryString.ToString(True))

        End If
    End Sub
    Private Sub RadToolbarSchedule_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarSchedule.ButtonClick

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim oEstimating As Webvantage.cEstimating = Nothing
        Dim VariableString As String = ""
        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
        Dim Validations As Webvantage.cValidations = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSaveTemplate.Value

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficScheduleTemplate_New.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber

                End With

                Me.OpenWindow(QueryString)

            Case RadToolBarButtonVersions.Value

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    QueryString = New AdvantageFramework.Web.QueryString()

                    With QueryString

                        .JobNumber = _JobNumber
                        .JobComponentNumber = _JobComponentNumber
                        .Page = "TrafficScheduleVersion.aspx"

                    End With

                    Me.OpenWindow(QueryString)

                End If

            Case RadToolbarTemplateButtonRefresh.Value

                LoadScheduleHeader()
                RadGridProjectSchedule.Rebind()

            Case RadToolbarButtonSaveAll.Value, "SaveAll"

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    Me.Toolbar_SaveAll()
                    LoadScheduleHeader()
                    RadGridProjectSchedule.Rebind()

                End If

            Case "Print"

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                    Me.ShowMessage("Invalid job/comp.")
                    Exit Sub

                End If

                Validations = New Webvantage.cValidations(_Session.ConnectionString)

                If Validations.ValidateJobCompIsViewable(_Session.UserCode, _JobNumber, _JobComponentNumber) = False Then

                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub

                End If

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Print.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber
                    .Add("pm", "0")
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                    If Me.CalculateByPredecessor = False Then

                        .Add("sort", Me.DropSort.SelectedValue)

                    End If

                End With

                Me.OpenPrintSendSilently(QueryString)

            Case "SendAlert"

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                    Me.ShowMessage("Invalid job/comp.")
                    Exit Sub

                End If

                Validations = New Webvantage.cValidations(_Session.ConnectionString)

                If Validations.ValidateJobCompIsViewable(_Session.UserCode, _JobNumber, _JobComponentNumber) = False Then

                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub

                End If

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Print.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber
                    .Add("pm", "0")
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                    If Me.CalculateByPredecessor = False Then

                        .Add("sort", Me.DropSort.SelectedValue)

                    End If

                End With

                Me.OpenPrintSendSilently(QueryString)

            Case "SendAssignment"

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                    Me.ShowMessage("Invalid job/comp.")
                    Exit Sub

                End If

                Validations = New Webvantage.cValidations(_Session.ConnectionString)

                If Validations.ValidateJobCompIsViewable(_Session.UserCode, _JobNumber, _JobComponentNumber) = False Then

                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub

                End If

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Print.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber
                    .Add("pm", "0")
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                    If Me.CalculateByPredecessor = False Then

                        .Add("sort", Me.DropSort.SelectedValue)

                    End If

                End With

                Me.OpenPrintSendSilently(QueryString)

            Case "SendEmail"

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                    Me.ShowMessage("Invalid job/comp.")
                    Exit Sub

                End If

                Validations = New Webvantage.cValidations(_Session.ConnectionString)

                If Validations.ValidateJobCompIsViewable(_Session.UserCode, _JobNumber, _JobComponentNumber) = False Then

                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub

                End If

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Print.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber
                    .Add("pm", "0")
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                    If Me.CalculateByPredecessor = False Then

                        .Add("sort", Me.DropSort.SelectedValue)

                    End If

                End With

                Me.OpenPrintSendSilently(QueryString)

            Case "PrintSendOptions"

                If _JobNumber = 0 OrElse _JobComponentNumber = 0 Then

                    Me.ShowMessage("Invalid job/comp.")
                    Exit Sub

                End If

                Validations = New Webvantage.cValidations(_Session.ConnectionString)

                If Validations.ValidateJobCompIsViewable(Session("UserCode"), _JobNumber, _JobComponentNumber) = False Then

                    Me.ShowMessage("Access to this job/comp is denied.")
                    Exit Sub

                End If

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Print.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber
                    .Add("pm", "0")
                    .Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                    If Me.CalculateByPredecessor = False Then

                        .Add("sort", Me.DropSort.SelectedValue)

                    End If

                End With

                Me.OpenWindow(QueryString)

            Case RadToolbarButtonSetting.Value

                If Not Request.QueryString("JT") = Nothing Then

                    If Request.QueryString("JT") = "1" Then

                        VariableString = "1"

                    Else

                        VariableString = "0"

                    End If

                End If

                Me.OpenWindow("", "TrafficSchedule_Setup.aspx?JT=" & VariableString & "&j=" & _JobNumber & "&jc=" & _JobComponentNumber)

            Case RadToolbarButtonClear.Value

                Session("SchedHeaderLoaded") = Nothing
                Me.OpenWindow("", "TrafficSchedule_Search.aspx?t=0")

            Case "ViewSingle"

                Session("SchedHeaderLoaded") = Nothing
                Me.OpenWindow("", "TrafficSchedule_Search.aspx?t=0")

            Case RadToolbarButtonViewMulti.Value

                Session("SchedHeaderLoaded") = Nothing
                Me.OpenWindow("", "TrafficSchedule_Search.aspx?t=1")

            Case RadToolbarButtonNew.Value

                'MiscFN.ResponseRedirect("TrafficSchedule_AddNew.aspx")

            Case RadToolbarButtonCheckWorkload.Value

                SaveAlmostEverything()

                If Me.RadDatePickerStartDate.SelectedDate.HasValue = False OrElse Me.RadDatePickerDueDate.SelectedDate.HasValue = False Then

                    Me.ShowMessage("Workload analysis requires valid start and due dates.")
                    Exit Sub

                Else

                    Session("WorkloadStart") = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
                    Session("WorkloadEnd") = cGlobals.wvCDate(Me.RadDatePickerDueDate.SelectedDate).ToShortDateString
                    Session("WorkloadIsMulti") = "False"
                    Session("WorkloadJobCompList") = _JobNumber.ToString() & "," & _JobComponentNumber.ToString() & "|"

                    Me.OpenWindow("Workload Analysis", "ProgressIndicator.aspx?destPage=TrafficSchedule_Workload2.aspx", 500, 950, False, False)

                End If

            Case radbtnAlert.Value

                SaveAlmostEverything()
                Session("AlertsCurrentPageNumber") = 0
                Me.OpenWindow("Alerts for Job:  " & _JobNumber.ToString().PadLeft(6, "0") & "/" & _JobComponentNumber.ToString().PadLeft(2, "0"), "Alert_Inbox.aspx?ps=1&j=" & _JobNumber.ToString() & "&jc=" & _JobComponentNumber.ToString())

            Case RadToolBarButtonScheduleAlerts.Value

                SaveAlmostEverything()

                QueryString = New AdvantageFramework.Web.QueryString

                With QueryString

                    .Page = "Alert_Inbox.aspx"
                    .Add("lstlvl", AdvantageFramework.Database.Entities.AlertListLevel.ProjectSchedule)
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber

                End With

                Me.OpenWindow(QueryString)

            Case radbtnDocs.Value

                SaveAlmostEverything()
                Session("DocFilterLevel") = "JC"
                Session("DocFilterValue") = _JobNumber & "," & _JobComponentNumber
                Me.OpenWindow("Documents for Job " & _JobNumber & "-" & _JobComponentNumber, "Documents_JobComponent.aspx?m=D&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber)

            Case RadToolbarButtonNewJobAlert.Value

                If Me.IsClientPortal = True Then

                    Me.OpenWindow("New Job Alert", "Alert_New.aspx?f=" & CType(MiscFN.Source_App.JobJacket, Integer).ToString() & "&j=" & _JobNumber & "&jc=" & _JobComponentNumber)

                Else

                    Me.OpenWindow("New Job Alert", "Alert_New.aspx?f=" & CType(MiscFN.Source_App.ProjectSchedule, Integer).ToString() & "&j=" & _JobNumber & "&jc=" & _JobComponentNumber)

                End If

            Case RadToolbarButtonNewAlertAssignment.Value

                Me.OpenWindow("", "Alert_New.aspx?assn=1&f=" & CType(MiscFN.Source_App.ProjectSchedule, Integer).ToString() & "&j=" & _JobNumber & "&jc=" & _JobComponentNumber)

            Case radbtnCalendar.Value

                Me.OpenWindow("Calendar", "Calendar_MonthView.aspx?FromApp=PS&JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber)

            Case radbtnJobTemplate.Value

                Me.OpenWindow("", "Content.aspx?JobNum=" & _JobNumber & "&JobCompNum=" & _JobComponentNumber & "&PageMode=Edit&NewComp=0")

            Case RadToolbarTemplateButtonStatus.Value

                QueryString = New AdvantageFramework.Web.QueryString()

                With QueryString

                    .Page = "TrafficSchedule_Status_Graph.aspx"
                    .JobNumber = _JobNumber
                    .JobComponentNumber = _JobComponentNumber

                End With

                Me.OpenWindow("Risk Analysis", QueryString.ToString(True))

            Case RadToolBarButtonEstimate.Value

                oEstimating = New Webvantage.cEstimating(_Session.ConnectionString, _Session.UserCode)

                Using SqlDataReader = oEstimating.GetEstJob(_JobNumber, _JobComponentNumber)

                    If SqlDataReader.HasRows = True Then

                        SqlDataReader.Read()

                        If SqlDataReader("ESTIMATE_NUMBER") <> 0 Then

                            Me.OpenWindow("Estimate", "Estimating.aspx?JT=1&EstNum=" & SqlDataReader("ESTIMATE_NUMBER") & "&EstComp=" & SqlDataReader("EST_COMPONENT_NBR") & "&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&newEst=edit")

                        Else

                            Me.OpenWindow("New Estimate", "Estimating_AddNew.aspx?JT=1&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber)

                        End If

                    Else

                        Me.OpenWindow("New Estimate", "Estimating_AddNew.aspx?JT=1&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber)

                    End If

                End Using

            Case RadToolbarButtonGanttView.Value
                ' Me.OpenWindow("Gantt", "TrafficSchedule_Gantt.aspx?from=ps&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber)
                Me.OpenWindow("Gantt", "angulargantt.aspx?from=ps&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber)

            Case RadToolBarButtonJobOrder.Value

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    QueryString = QueryString.FromCurrent()
                    Me.Toolbar_SaveAll()
                    SaveCalculate()

                    MiscFN.ResponseRedirect(QueryString.ToString(True)) ' have to refresh the page to redo the grid structure

                End If

            Case "Predecessor"

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    QueryString = New AdvantageFramework.Web.QueryString

                    QueryString = QueryString.FromCurrent()
                    Me.Toolbar_SaveAll()
                    SaveCalculate()

                    MiscFN.ResponseRedirect(QueryString.ToString(True)) ' have to refresh the page to redo the grid structure

                End If

            Case RadToolBarButtonBookmark.Value

                Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(_Session.ConnectionString, _Session.UserCode)

                QueryString = New AdvantageFramework.Web.QueryString

                QueryString = QueryString.FromCurrent()

                With Bookmark

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectSchedule
                    .UserCode = Session("UserCode")
                    .Name = "PS: " & _JobNumber.ToString() & "/" & _JobComponentNumber.ToString()
                    .PageURL = "TrafficSchedule.aspx" & QueryString.ToString()

                End With

                If BookmarkMethods.SaveBookmark(Bookmark, VariableString) = False Then

                    Me.ShowMessage(VariableString)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

            Case RadToolBarButtonUpdateStatus.Value

                Schedule = New Webvantage.cSchedule

                If Schedule.UpdateScheduleStatus(_JobNumber, _JobComponentNumber, True, "") = True Then

                    LoadScheduleHeader()

                End If

        End Select

    End Sub
    Private Sub RadGridProjectSchedule_CustomAggregate(sender As Object, e As Telerik.Web.UI.GridCustomAggregateEventArgs) Handles RadGridProjectSchedule.CustomAggregate

        'objects
        Dim JobHours As Decimal = Nothing
        Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TextBoxJobHours As System.Web.UI.WebControls.TextBox = Nothing

        If e.Column.UniqueName = Me.ColumnNames.colJOB_HRS.ToString Then

            For Each GridDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                If GridDataItem.DataItem IsNot Nothing Then

                    Try

                        ScheduleTask = DirectCast(GridDataItem.DataItem, AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

                    Catch ex As Exception

                    End Try

                End If

                If ScheduleTask IsNot Nothing Then

                    JobHours = JobHours + ScheduleTask.JobHours.GetValueOrDefault(0)

                Else

                    Try

                        TextBoxJobHours = DirectCast(GridDataItem.FindControl("TextBoxJobHours"), System.Web.UI.WebControls.TextBox)

                        If String.IsNullOrWhiteSpace(TextBoxJobHours.Text) = False Then

                            JobHours = JobHours + CDec(TextBoxJobHours.Text)

                        End If

                    Catch ex As Exception

                    End Try

                End If

            Next

            e.Result = JobHours

        End If

    End Sub
    Private Sub RadGridProjectSchedule_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProjectSchedule.ItemCommand


        If e.Item Is Nothing Then Exit Sub

        'objects
        Dim ItemIndex As Integer = 0
        Dim SequenceNumber As Integer = 0
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TaskCode As String = ""
        Dim StartDate As String = ""
        Dim DueDate As String = ""
        Dim FunctionCode As String = ""
        Dim HiddenFieldTaskCode As System.Web.UI.WebControls.HiddenField = Nothing
        Dim WindowURL As String = Nothing
        Dim cSchedule As Webvantage.cSchedule = Nothing
        Dim ScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim NewScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim ParentTaskSequenceNumber As Short? = Nothing
        Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TaskAboveInSameLevel As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim Index As Integer = 0

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        If Not e.Item Is Nothing Then

            ItemIndex = e.Item.ItemIndex

        Else

            Exit Sub

        End If

        If ItemIndex = -1 Then 'command item

            MiscFN.SavePageSize(Me.RadGridProjectSchedule.ID, Me.RadGridProjectSchedule.PageSize)
            Exit Sub

        End If

        GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

        Try

            SequenceNumber = GridDataItem.GetDataKeyValue("SequenceNumber")

        Catch ex As Exception
            SequenceNumber = -1
        End Try

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso SequenceNumber > -1 Then

            Select Case e.CommandName

                Case "SetEmployees"

                    Try

                        Me.SaveGridRow(GridDataItem)

                    Catch ex As Exception

                    End Try

                    Try

                        HiddenFieldTaskCode = CType(FindGridControl(GridDataItem, GridControls.HiddenFieldTaskCode), System.Web.UI.WebControls.HiddenField)

                        If HiddenFieldTaskCode.Value.Trim <> "" Then

                            TaskCode = HiddenFieldTaskCode.Value

                        End If

                    Catch ex As Exception
                        TaskCode = ""
                    End Try

                    WindowURL = "TrafficSchedule_TaskEmployees.aspx?From=ts&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & SequenceNumber & "&TaskCode=" & TaskCode

                    Me.OpenWindow("Employees", WindowURL, 600, 650, , True)

                Case "SetClientContacts"

                    Try

                        HiddenFieldTaskCode = CType(FindGridControl(GridDataItem, GridControls.HiddenFieldTaskCode), System.Web.UI.WebControls.HiddenField)

                        If HiddenFieldTaskCode.Value.Trim <> "" Then

                            TaskCode = HiddenFieldTaskCode.Value

                        End If

                    Catch ex As Exception
                        TaskCode = ""
                    End Try

                    Try

                        Me.SaveGridRow(GridDataItem)

                    Catch ex As Exception

                    End Try

                    WindowURL = "TrafficSchedule_TaskContacts.aspx?caller=" & Me.PageFilename & "&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & SequenceNumber & "&TaskCode=" & TaskCode & "&Client=" & Me.HiddenFieldClientCode.Value & "&Division=" & Me.HiddenFieldDivisionCode.Value & "&Product=" & Me.HiddenFieldProductCode.Value

                    Me.OpenWindow("Add Contact", WindowURL, , , , True)

                Case "ShowComments"

                    Try

                        SaveGridRow(GridDataItem, True)

                    Catch ex As Exception

                    End Try

                    WindowURL = "TrafficSchedule_TaskComments.aspx?JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & SequenceNumber

                    Me.OpenWindow("Comments", WindowURL, , , , True)

                Case "SetPredecessors"

                Case "SaveRow"

                    SaveGridRow(GridDataItem, True)

                Case "DeleteRow"

                    DeleteGridRow(_JobNumber, _JobComponentNumber, SequenceNumber)
                    Me.RadGridProjectSchedule.Rebind()

                Case "EditRow"

                    SaveGridRow(GridDataItem, True)
                    WindowURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & SequenceNumber & "&Client=" & Me.HiddenFieldClientCode.Value & "&Division=" & Me.HiddenFieldDivisionCode.Value & "&Product=" & Me.HiddenFieldProductCode.Value
                    Me.OpenWindow("Edit Task", WindowURL)

                Case "MoveLeft"

                    If GridDataItem.OwnerTableView.ParentItem IsNot Nothing Then

                        ScheduleTaskList = Me.DataSource2

                        ScheduleTask = (From SchTask In ScheduleTaskList
                                        Where SchTask.SequenceNumber = CShort(GridDataItem.GetDataKeyValue("SequenceNumber"))
                                        Select SchTask).SingleOrDefault

                        If ScheduleTask IsNot Nothing Then

                            ScheduleTaskList.Remove(ScheduleTask)

                            Try

                                TaskAboveInSameLevel = (From SchTask In ScheduleTaskList
                                                        Where SchTask.SequenceNumber = ScheduleTask.ParentTaskSequenceNumber
                                                        Select SchTask).SingleOrDefault

                            Catch ex As Exception
                                TaskAboveInSameLevel = Nothing
                            End Try

                            ScheduleTask.ParentTaskSequenceNumber = TaskAboveInSameLevel.ParentTaskSequenceNumber

                            MoveTaskHierarchy(ScheduleTask.SequenceNumber, ScheduleTask.ParentTaskSequenceNumber)

                            Try

                                Index = ScheduleTaskList.IndexOf((From SchTask In ScheduleTaskList
                                                                  Where SchTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) = TaskAboveInSameLevel.ParentTaskSequenceNumber.GetValueOrDefault(-1) AndAlso
                                                                        SchTask.GridOrder.GetValueOrDefault(0) > TaskAboveInSameLevel.GridOrder.GetValueOrDefault(0)
                                                                  Order By SchTask.GridOrder.GetValueOrDefault(0) Ascending
                                                                  Select SchTask).First)

                            Catch ex As Exception
                                Index = ScheduleTaskList.Count
                            End Try

                            ScheduleTaskList.Insert(Index, ScheduleTask)

                            UpdateTaskListOrder(ScheduleTaskList)

                        End If

                        RadGridProjectSchedule.Rebind()

                    End If

                Case "MoveRight"

                    Try

                        If GridDataItem.OwnerTableView.Items(GridDataItem.ItemIndex - 1) IsNot Nothing Then

                            ScheduleTaskList = Me.DataSource2

                            ScheduleTask = (From SchTask In ScheduleTaskList
                                            Where SchTask.SequenceNumber = CShort(GridDataItem.GetDataKeyValue("SequenceNumber"))
                                            Select SchTask).SingleOrDefault

                            If ScheduleTask IsNot Nothing Then

                                ScheduleTaskList.Remove(ScheduleTask)

                                Try

                                    ParentTaskSequenceNumber = CShort(GridDataItem.OwnerTableView.Items(GridDataItem.ItemIndex - 1).GetDataKeyValue("SequenceNumber"))

                                Catch ex As Exception
                                    ParentTaskSequenceNumber = Nothing
                                End Try

                                If (From SchTask In ScheduleTaskList
                                    Where SchTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) = ParentTaskSequenceNumber.GetValueOrDefault(-1)
                                    Select SchTask).Any Then

                                    Index = ScheduleTaskList.IndexOf((From SchTask In ScheduleTaskList
                                                                      Where SchTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) = ParentTaskSequenceNumber.GetValueOrDefault(-1)
                                                                      Select SchTask).Last)

                                Else

                                    Index = ScheduleTaskList.IndexOf((From SchTask In ScheduleTaskList
                                                                      Where SchTask.SequenceNumber = ParentTaskSequenceNumber.GetValueOrDefault(-1)
                                                                      Select SchTask).Last)

                                End If

                                ScheduleTask.ParentTaskSequenceNumber = ParentTaskSequenceNumber

                                MoveTaskHierarchy(ScheduleTask.SequenceNumber, ScheduleTask.ParentTaskSequenceNumber)

                                ScheduleTaskList.Insert(Index + 1, ScheduleTask)

                                UpdateTaskListOrder(ScheduleTaskList)

                            End If

                        End If

                    Catch ex As Exception

                    End Try

                    RadGridProjectSchedule.Rebind()

                Case "PickPredecessors"

                    Dim CheckBoxSelectPredecessor As System.Web.UI.WebControls.CheckBox = Nothing
                    Dim ImageButtonAddPredecessors As System.Web.UI.WebControls.ImageButton = Nothing
                    Dim CurItemSequenceNumber As Short = Nothing
                    Dim Control As System.Web.UI.Control = Nothing
                    Dim WebControl As System.Web.UI.WebControls.WebControl = Nothing
                    Dim IsPredecessor As Boolean = False
                    Dim IsChild As Boolean = False

                    ImageButtonAddPredecessors = FindGridControl(GridDataItem, GridControls.ImageButtonAddPredecessors)

                    ImageButtonAddPredecessors.CommandName = "SavePickPredecessors"

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            For Each GridControlName In [Enum].GetValues(GetType(GridControls))

                                If GridControlName <> GridControls.CheckBoxSelectPredecessor AndAlso
                                   GridControlName <> GridControls.ImageButtonAddPredecessors Then

                                    Control = FindGridControl(GDataItem, GridControlName)

                                    If TypeOf Control Is System.Web.UI.WebControls.WebControl Then

                                        WebControl = DirectCast(Control, System.Web.UI.WebControls.WebControl)

                                        WebControl.Enabled = False
                                        WebControl.CssClass = WebControl.CssClass & " Greyed"

                                    End If

                                End If

                            Next

                            Try

                                GDataItem("DragDropColumn").Enabled = False
                                GDataItem("DragDropColumn").CssClass = GDataItem("DragDropColumn").CssClass & " Greyed"

                            Catch ex As Exception

                            End Try

                            CurItemSequenceNumber = GDataItem.GetDataKeyValue("SequenceNumber")

                            CheckBoxSelectPredecessor = FindGridControl(GDataItem, GridControls.CheckBoxSelectPredecessor)

                            If CurItemSequenceNumber <> SequenceNumber Then

                                If GDataItem.ChildItem IsNot Nothing AndAlso GDataItem.ChildItem.NestedTableViews.Any(Function(GTblView) GTblView.Items.Count > 0) = True Then

                                    CheckBoxSelectPredecessor.Enabled = False
                                    CheckBoxSelectPredecessor.Visible = False

                                Else

                                    CheckBoxSelectPredecessor.Enabled = True
                                    CheckBoxSelectPredecessor.Visible = True

                                End If

                                If CheckBoxSelectPredecessor.Visible Then

                                    IsPredecessor = CBool(DbContext.Database.SqlQuery(Of Integer)("SELECT " &
                                                                                                      "  CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END " &
                                                                                                      "FROM  " &
                                                                                                      "  dbo.JOB_TRAFFIC_DET_PREDS " &
                                                                                                      "WHERE " &
                                                                                                      "  JOB_NUMBER = {0} AND " &
                                                                                                      "  JOB_COMPONENT_NBR = {1} AND " &
                                                                                                      "  SEQ_NBR = {2} AND " &
                                                                                                      "  PREDECESSOR_SEQ_NBR = {3} ",
                                                                                                      _JobNumber, _JobComponentNumber, SequenceNumber, CurItemSequenceNumber).FirstOrDefault)

                                    CheckBoxSelectPredecessor.Checked = IsPredecessor

                                End If

                                Try

                                    FindGridControl(GDataItem, GridControls.ImageButtonAddPredecessors).Visible = False

                                Catch ex As Exception

                                End Try

                            Else

                                ImageButtonAddPredecessors.Enabled = True
                                CheckBoxSelectPredecessor.Visible = False

                            End If

                        Next

                    End Using

                Case "SavePickPredecessors"

                    For Each GDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        If GDataItem.GetDataKeyValue("SequenceNumber") <> SequenceNumber Then

                            If CType(FindGridControl(GDataItem, GridControls.CheckBoxSelectPredecessor), System.Web.UI.WebControls.CheckBox).Checked Then

                                CreatePredecessor(SequenceNumber, GDataItem.GetDataKeyValue("SequenceNumber"))

                            Else

                                DeletePredecessor(SequenceNumber, GDataItem.GetDataKeyValue("SequenceNumber"))

                            End If

                        End If

                    Next

                    RadGridProjectSchedule.Rebind()

                Case "Documents"

                    Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
                    Dim TextBoxTaskCode As System.Web.UI.WebControls.TextBox = Nothing
                    Dim TextBoxTaskDescription As System.Web.UI.WebControls.TextBox = Nothing
                    Dim Description As String = Nothing

                    QueryString = New AdvantageFramework.Web.QueryString

                    With QueryString

                        .Page = "Documents_List2.aspx"
                        .JobNumber = _JobNumber
                        .JobComponentNumber = _JobComponentNumber
                        .TaskSequenceNumber = SequenceNumber
                        .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Task
                        .Add("doc_img", FindGridControl(GridDataItem, GridControls.ImageButtonHasDocuments).ClientID)
                        .Add("opener", HiddenFieldWindowName.Value)

                    End With

                    TextBoxTaskCode = FindGridControl(GridDataItem, GridControls.TextBoxTaskCode)
                    TextBoxTaskDescription = FindGridControl(GridDataItem, GridControls.TextBoxTaskDescription)

                    If TextBoxTaskCode IsNot Nothing AndAlso TextBoxTaskCode.Visible Then

                        Description = TextBoxTaskCode.Text

                        If TextBoxTaskDescription IsNot Nothing AndAlso TextBoxTaskDescription.Visible Then

                            Description &= " - " & TextBoxTaskDescription.Text

                        End If

                    Else

                        With AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(_DbContext, _JobNumber, _JobComponentNumber, SequenceNumber)

                            Description = .TaskCode & If(String.IsNullOrWhiteSpace(.Description), "", " - " & .Description)

                        End With

                    End If

                    QueryString.Add("task_desc", Description)

                    Me.OpenWindow(QueryString, "Document List")

            End Select

        End If

    End Sub
    Private Sub RadGridProjectSchedule_ItemCreated(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectSchedule.ItemCreated

        If e.Item.OwnerTableView IsNot RadGridProjectSchedule.MasterTableView Then

            If e.Item.ItemType <> Telerik.Web.UI.GridItemType.Item AndAlso
                e.Item.ItemType <> Telerik.Web.UI.GridItemType.AlternatingItem AndAlso
                e.Item.ItemType <> Telerik.Web.UI.GridItemType.NoRecordsItem Then

                e.Item.Style("display") = "none"

            End If

        End If

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or
                e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim RadAutoCompleteBoxEmployees As Telerik.Web.UI.RadAutoCompleteBox = Nothing
            Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            RadAutoCompleteBoxEmployees = DirectCast(FindGridControl(e.Item, GridControls.RadAutoCompleteBoxEmployees), Telerik.Web.UI.RadAutoCompleteBox)

            If RadAutoCompleteBoxEmployees IsNot Nothing Then

                RadAutoCompleteBoxEmployees.DataTextField = "EMP_NAME"
                RadAutoCompleteBoxEmployees.DataValueField = "EMPCODE"
                RadAutoCompleteBoxEmployees.DataSource = oSchedule.GetAvailableEmpList(_JobNumber, _JobComponentNumber, -1, False, "", Session("UserCode"))
                RadAutoCompleteBoxEmployees.DataBind()

            End If

        End If

    End Sub
    Private Sub RadGridProjectSchedule_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectSchedule.ItemDataBound

        'objects
        Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing
        Dim ItemIndexHierarchical As String() = Nothing
        Dim LevelNotation As String = Nothing
        Dim IsFirstItemInLevel As Boolean = False
        Dim Levels As Generic.List(Of Integer) = Nothing
        Dim HasCompletedDate As Boolean = False
        Dim HasRevisedDate As Boolean = False
        Dim ThisDueDate As Date = Nothing
        Dim LabelLevelNotation As System.Web.UI.WebControls.Label = Nothing
        Dim ImageButtonMoveLeft As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonMoveRight As System.Web.UI.WebControls.ImageButton = Nothing
        Dim RadButtonLinked As Telerik.Web.UI.RadButton = Nothing
        Dim RadComboBoxTaskStatus As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadComboBoxPhaseDescription As Telerik.Web.UI.RadComboBox = Nothing
        Dim TextBoxTaskCode As System.Web.UI.WebControls.TextBox = Nothing
        Dim HiddenFieldTaskCode As System.Web.UI.WebControls.HiddenField = Nothing
        Dim ImageButtonTaskCode As System.Web.UI.WebControls.ImageButton = Nothing
        Dim TextBoxTaskDescription As System.Web.UI.WebControls.TextBox = Nothing
        Dim CheckBoxMilestone As System.Web.UI.WebControls.CheckBox = Nothing
        Dim TextBoxJobDays As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxTaskStartDate As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxJobRevisedDate As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageDueDateLock As System.Web.UI.WebControls.Image = Nothing
        Dim CheckBoxDueDateLock As System.Web.UI.WebControls.CheckBox = Nothing
        Dim TextBoxRevisedDueTime As System.Web.UI.WebControls.TextBox = Nothing
        Dim HiddenFieldRevisedDueTime As System.Web.UI.WebControls.HiddenField = Nothing
        Dim HiddenFieldDueTime As System.Web.UI.WebControls.HiddenField = Nothing
        Dim TextBoxJobDueDate As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxJobCompletedDate As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxTemporaryCompleteDate As System.Web.UI.WebControls.TextBox = Nothing
        Dim LabelTemporaryCompleteDate As System.Web.UI.WebControls.Label = Nothing
        Dim TextBoxJobHours As System.Web.UI.WebControls.TextBox = Nothing
        Dim LinkButtonDispersedHours As System.Web.UI.WebControls.LinkButton = Nothing
        Dim LabelPostedHours As System.Web.UI.WebControls.Label = Nothing
        Dim LabelPercentComplete As System.Web.UI.WebControls.Label = Nothing
        Dim LinkButtonEmployees As System.Web.UI.WebControls.LinkButton = Nothing
        Dim TextBoxEmployees As System.Web.UI.WebControls.TextBox = Nothing
        Dim RadAutoCompleteBoxEmployees As Telerik.Web.UI.RadAutoCompleteBox = Nothing
        Dim ImageButtonEmployees As System.Web.UI.WebControls.ImageButton = Nothing
        Dim LinkButtonClientContacts As System.Web.UI.WebControls.LinkButton = Nothing
        Dim TextBoxClientContacts As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageButtonClientContacts As System.Web.UI.WebControls.ImageButton = Nothing
        Dim RadComboBoxEstimateFunction As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonShowComments As System.Web.UI.WebControls.ImageButton = Nothing
        Dim TextBoxFunctionComments As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxDueDateComments As System.Web.UI.WebControls.TextBox = Nothing
        Dim TextBoxRevisionDateComments As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageButtonSave As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonAddPredecessors As System.Web.UI.WebControls.ImageButton = Nothing
        Dim RadToolTipAddPredecessors As Telerik.Web.UI.RadToolTip = Nothing
        Dim LabelJobRevisedDate As System.Web.UI.WebControls.Label = Nothing
        Dim LabelTaskStartDate As System.Web.UI.WebControls.Label = Nothing
        Dim TextBoxJobOrder As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageButtonHasDocuments As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DivHasDocuments As System.Web.UI.HtmlControls.HtmlControl = Nothing
        Dim LabelJobDays As System.Web.UI.WebControls.Label = Nothing
        Dim LabelPredecessorsLabel As System.Web.UI.WebControls.Label = Nothing
        Dim RadTextBoxPredecessors As Telerik.Web.UI.RadTextBox = Nothing
        Dim LabelDisbursedHours As System.Web.UI.WebControls.Label = Nothing
        Dim DivEmployees As System.Web.UI.HtmlControls.HtmlControl = Nothing
        Dim DivClientContacts As System.Web.UI.HtmlControls.HtmlControl = Nothing
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim EmployeeString As String = Nothing
        Dim EmployeeText As String = Nothing
        Dim ContactsString As String = Nothing
        Dim ContactsText As String = Nothing
        Dim DataKey As String = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing

        Dim oSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            'find all controls
            LabelLevelNotation = DirectCast(FindGridControl(e.Item, GridControls.LabelLevelNotation), System.Web.UI.WebControls.Label)
            ImageButtonMoveLeft = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonMoveLeft), System.Web.UI.WebControls.ImageButton)
            ImageButtonMoveRight = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonMoveRight), System.Web.UI.WebControls.ImageButton)
            RadButtonLinked = DirectCast(FindGridControl(e.Item, GridControls.RadButtonLinked), Telerik.Web.UI.RadButton)
            RadComboBoxTaskStatus = DirectCast(FindGridControl(e.Item, GridControls.RadComboBoxTaskStatus), Telerik.Web.UI.RadComboBox)
            RadComboBoxPhaseDescription = DirectCast(FindGridControl(e.Item, GridControls.RadComboBoxPhaseDescription), Telerik.Web.UI.RadComboBox)
            TextBoxTaskCode = DirectCast(FindGridControl(e.Item, GridControls.TextBoxTaskCode), System.Web.UI.WebControls.TextBox)
            HiddenFieldTaskCode = DirectCast(FindGridControl(e.Item, GridControls.HiddenFieldTaskCode), System.Web.UI.WebControls.HiddenField)
            ImageButtonTaskCode = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonTaskCode), System.Web.UI.WebControls.ImageButton)
            TextBoxTaskDescription = DirectCast(FindGridControl(e.Item, GridControls.TextBoxTaskDescription), System.Web.UI.WebControls.TextBox)
            CheckBoxMilestone = DirectCast(FindGridControl(e.Item, GridControls.CheckBoxMilestone), System.Web.UI.WebControls.CheckBox)
            TextBoxJobDays = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobDays), System.Web.UI.WebControls.TextBox)
            TextBoxTaskStartDate = DirectCast(FindGridControl(e.Item, GridControls.TextBoxTaskStartDate), System.Web.UI.WebControls.TextBox)
            TextBoxJobRevisedDate = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobRevisedDate), System.Web.UI.WebControls.TextBox)
            ImageDueDateLock = DirectCast(FindGridControl(e.Item, GridControls.ImageDueDateLock), System.Web.UI.WebControls.Image)
            CheckBoxDueDateLock = DirectCast(FindGridControl(e.Item, GridControls.CheckBoxDueDateLock), System.Web.UI.WebControls.CheckBox)
            TextBoxRevisedDueTime = DirectCast(FindGridControl(e.Item, GridControls.TextBoxRevisedDueTime), System.Web.UI.WebControls.TextBox)
            HiddenFieldRevisedDueTime = DirectCast(FindGridControl(e.Item, GridControls.HiddenFieldRevisedDueTime), System.Web.UI.WebControls.HiddenField)
            HiddenFieldDueTime = DirectCast(FindGridControl(e.Item, GridControls.HiddenFieldDueTime), System.Web.UI.WebControls.HiddenField)
            TextBoxJobDueDate = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobDueDate), System.Web.UI.WebControls.TextBox)
            TextBoxJobCompletedDate = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobCompletedDate), System.Web.UI.WebControls.TextBox)
            TextBoxTemporaryCompleteDate = DirectCast(FindGridControl(e.Item, GridControls.TextBoxTemporaryCompleteDate), System.Web.UI.WebControls.TextBox)
            LabelTemporaryCompleteDate = DirectCast(FindGridControl(e.Item, GridControls.LabelTemporaryCompleteDate), System.Web.UI.WebControls.Label)
            TextBoxJobHours = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobHours), System.Web.UI.WebControls.TextBox)
            LinkButtonDispersedHours = DirectCast(FindGridControl(e.Item, GridControls.LinkButtonDispersedHours), System.Web.UI.WebControls.LinkButton)
            LabelPostedHours = DirectCast(FindGridControl(e.Item, GridControls.LabelPostedHours), System.Web.UI.WebControls.Label)
            LabelPercentComplete = DirectCast(FindGridControl(e.Item, GridControls.LabelPercentComplete), System.Web.UI.WebControls.Label)
            LinkButtonEmployees = DirectCast(FindGridControl(e.Item, GridControls.LinkButtonEmployees), System.Web.UI.WebControls.LinkButton)
            TextBoxEmployees = DirectCast(FindGridControl(e.Item, GridControls.TextBoxEmployees), System.Web.UI.WebControls.TextBox)
            RadAutoCompleteBoxEmployees = DirectCast(FindGridControl(e.Item, GridControls.RadAutoCompleteBoxEmployees), Telerik.Web.UI.RadAutoCompleteBox)
            ImageButtonEmployees = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonEmployees), System.Web.UI.WebControls.ImageButton)
            LinkButtonClientContacts = DirectCast(FindGridControl(e.Item, GridControls.LinkButtonClientContacts), System.Web.UI.WebControls.LinkButton)
            TextBoxClientContacts = DirectCast(FindGridControl(e.Item, GridControls.TextBoxClientContacts), System.Web.UI.WebControls.TextBox)
            ImageButtonClientContacts = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonClientContacts), System.Web.UI.WebControls.ImageButton)
            RadComboBoxEstimateFunction = DirectCast(FindGridControl(e.Item, GridControls.RadComboBoxEstimateFunction), Telerik.Web.UI.RadComboBox)
            ImageButtonShowComments = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonShowComments), System.Web.UI.WebControls.ImageButton)
            TextBoxFunctionComments = DirectCast(FindGridControl(e.Item, GridControls.TextBoxFunctionComments), System.Web.UI.WebControls.TextBox)
            TextBoxDueDateComments = DirectCast(FindGridControl(e.Item, GridControls.TextBoxDueDateComments), System.Web.UI.WebControls.TextBox)
            TextBoxRevisionDateComments = DirectCast(FindGridControl(e.Item, GridControls.TextBoxRevisionDateComments), System.Web.UI.WebControls.TextBox)
            ImageButtonSave = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonSave), System.Web.UI.WebControls.ImageButton)
            ImageButtonDelete = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonDelete), System.Web.UI.WebControls.ImageButton)
            ImageButtonAddPredecessors = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonAddPredecessors), System.Web.UI.WebControls.ImageButton)
            RadToolTipAddPredecessors = DirectCast(FindGridControl(e.Item, GridControls.RadToolTipAddPredecessors), Telerik.Web.UI.RadToolTip)
            LabelJobRevisedDate = DirectCast(FindGridControl(e.Item, GridControls.LabelJobRevisedDate), System.Web.UI.WebControls.Label)
            LabelTaskStartDate = DirectCast(FindGridControl(e.Item, GridControls.LabelTaskStartDate), System.Web.UI.WebControls.Label)
            TextBoxJobOrder = DirectCast(FindGridControl(e.Item, GridControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox)
            ImageButtonHasDocuments = DirectCast(FindGridControl(e.Item, GridControls.ImageButtonHasDocuments), System.Web.UI.WebControls.ImageButton)
            DivHasDocuments = DirectCast(e.Item.FindControl("DivHasDocuments"), System.Web.UI.HtmlControls.HtmlControl)
            LabelJobDays = DirectCast(FindGridControl(e.Item, GridControls.LabelJobDays), System.Web.UI.WebControls.Label)
            LabelPredecessorsLabel = DirectCast(FindGridControl(e.Item, GridControls.LabelPredecessorsLabel), System.Web.UI.WebControls.Label)
            LabelDisbursedHours = DirectCast(FindGridControl(e.Item, GridControls.LabelDisbursedHours), System.Web.UI.WebControls.Label)
            DivEmployees = DirectCast(e.Item.FindControl("DivEmployees"), System.Web.UI.HtmlControls.HtmlControl)
            DivClientContacts = DirectCast(e.Item.FindControl("DivClientContacts"), System.Web.UI.HtmlControls.HtmlControl)
            RadTextBoxPredecessors = DirectCast(FindGridControl(e.Item, GridControls.RadTextBoxPredecessors), Telerik.Web.UI.RadTextBox)

            If TypeOf e.Item.DataItem Is AdvantageFramework.ProjectSchedule.Classes.ScheduleTask Then

                ScheduleTask = e.Item.DataItem

                If ScheduleTask IsNot Nothing Then

                    DataKey = _JobNumber.ToString() & "|" & _JobComponentNumber.ToString() & "|" & ScheduleTask.SequenceNumber

                    Levels = New Generic.List(Of Integer)

                    For Each Level In (From lvl In e.Item.ItemIndexHierarchical.Split(":")
                                       Select l = CInt(lvl.Split("_").Last)).ToList

                        Levels.Add(Level + 1)

                        IsFirstItemInLevel = If(Level = 0, True, False)

                    Next

                    'LevelNotation = GetLevelNotation(e.Item.ItemIndexHierarchical)

                    'LabelLevelNotation.Text = LevelNotation

                    LabelLevelNotation.Text = ScheduleTask.Level

                    If String.IsNullOrWhiteSpace(TextBoxLabels.Text) = False Then

                        TextBoxLabels.Text = TextBoxLabels.Text & "|"

                    End If

                    TextBoxLabels.Text = TextBoxLabels.Text & String.Format("{0}:{1}", ScheduleTask.SequenceNumber, ScheduleTask.Level)

                    If ScheduleTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) < 0 Then

                        ImageButtonMoveLeft.Visible = False

                    End If

                    If IsFirstItemInLevel = True Then

                        ImageButtonMoveRight.Visible = False
                        RadButtonLinked.Visible = False

                    End If

                    If Me.CalculateByPredecessor = True Then

                        If ScheduleTask.HasPredecessors = True Then

                            RadButtonLinked.Visible = True
                            RadButtonLinked.Checked = True

                        End If

                    Else

                        RadButtonLinked.Visible = False
                        ImageButtonAddPredecessors.Visible = False

                    End If

                    If RadButtonLinked.Visible Then

                        Dim TaskAboveSeqNbr As Short = Nothing
                        Dim CommandArg As String = Nothing

                        CommandArg = String.Format("{0}|{1}|{2}", ScheduleTask.JobNumber, ScheduleTask.JobComponentNumber, ScheduleTask.SequenceNumber)

                        If e.Item.ItemIndex > 0 Then

                            Try

                                TaskAboveSeqNbr = CShort(e.Item.OwnerTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem).OrderByDescending(Function(item) item.ItemIndex).Where(Function(item) DirectCast(item.DataItem, AdvantageFramework.ProjectSchedule.Classes.ScheduleTask).HasChildren = False).FirstOrDefault().GetDataKeyValue("SequenceNumber"))

                                CommandArg = CommandArg & "|" & TaskAboveSeqNbr

                            Catch ex As Exception

                            End Try

                        End If

                        RadButtonLinked.CommandArgument = CommandArg

                    End If

                    If IsNumeric(_JobNumber) = True AndAlso _JobNumber = 0 Then

                        _JobNumber = CType(_JobNumber, Integer)

                    End If

                    If IsNumeric(_JobComponentNumber) = True AndAlso _JobComponentNumber = 0 Then

                        _JobComponentNumber = CType(_JobComponentNumber, Integer)

                    End If

                    If ScheduleTask.HasDocuments = True Then

                        'ImageButtonHasDocuments.ImageUrl = "~/Images/documents16_exist.png"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivHasDocuments, "standard-green")
                        ImageButtonHasDocuments.ToolTip = "View Documents"

                    Else

                        'ImageButtonHasDocuments.ImageUrl = "~/Images/documents16.png"
                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivHasDocuments, "standard-red")
                        ImageButtonHasDocuments.ToolTip = "No Documents"

                    End If

                    RadToolTipAddPredecessors.OnClientBeforeShow = "function(s, e){ OnClientBeforeShow(s, e, '" & DataKey & "' ); }"

                    Try

                        If (Me.HfHasAlertAssignmentColor.Value <> "" AndAlso (ScheduleTask.HasAssignment = 1)) OrElse (ScheduleTask.HasAlerts = 1) Then

                            CType(e.Item, Telerik.Web.UI.GridDataItem)("ColumnLevelNotation").BackColor = System.Drawing.Color.LightBlue ' ColorTranslator.FromHtml(Me.HfHasAlertAssignmentColor.Value)

                        End If

                    Catch ex As Exception

                    End Try

                    LabelPredecessorsLabel.Text = ScheduleTask.PredecessorLevelNotation
                    RadTextBoxPredecessors.Text = ScheduleTask.PredecessorLevelNotation

                    'GRID sequence number (not DB sequence)
                    _RowIncrement += 1
                    'CType(e.Item.FindControl("TxtGridOrder"), TextBox).Text = RowIncrement

                    'If row has a valid task detail, work with it
                    If _JobNumber > 0 AndAlso _JobComponentNumber > 0 AndAlso ScheduleTask.SequenceNumber > -1 Then

                        If ScheduleTask.DueDateLock = 1 Then

                            _CurrentDetailRowIsLocked = True

                        Else

                            _CurrentDetailRowIsLocked = False

                        End If

                        CheckBoxDueDateLock.Checked = _CurrentDetailRowIsLocked
                        TextBoxTaskStartDate.Enabled = Not _CurrentDetailRowIsLocked
                        TextBoxJobRevisedDate.Enabled = Not _CurrentDetailRowIsLocked

                        Schedule = New Webvantage.cSchedule(_Session.ConnectionString, _Session.UserCode)

                        If IsColumnVisible(ColumnNames.colEMP_CODE) = True OrElse IsColumnVisible(ColumnNames.colEMP_CODE_TEXT) = True OrElse IsColumnVisible(ColumnNames.colEMP_CODE_TEXT_AUTO) = True Then

                            EmployeeString = Schedule.GetTaskEmpListString(_JobNumber, _JobComponentNumber, ScheduleTask.SequenceNumber)

                            If String.IsNullOrWhiteSpace(LinkButtonEmployees.Text) AndAlso String.IsNullOrWhiteSpace(EmployeeString) Then

                                EmployeeText = "Add"

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonEmployees.Text) = False AndAlso String.IsNullOrWhiteSpace(EmployeeString) Then

                                EmployeeText = LinkButtonEmployees.Text

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonEmployees.Text) = False AndAlso String.IsNullOrWhiteSpace(EmployeeString) = False Then

                                EmployeeText = LinkButtonEmployees.Text & ", " & EmployeeString

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonEmployees.Text) AndAlso String.IsNullOrWhiteSpace(EmployeeString) = False Then

                                EmployeeText = EmployeeString

                            End If

                            If EmployeeText.Length > 0 Then

                                LinkButtonEmployees.Text = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(EmployeeText.Trim, ","), ",")
                                EmployeeText = EmployeeText.Replace("Add", "")
                                TextBoxEmployees.Text = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(EmployeeText.Trim, ","), ",")
                                Me.AddEntries(MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(EmployeeText.Trim, ","), ","), RadAutoCompleteBoxEmployees)

                            End If

                            RadAutoCompleteBoxEmployees.DataSource = oSchedule.GetAvailableEmpList(_JobNumber, _JobComponentNumber, ScheduleTask.SequenceNumber, False, "", Session("UserCode"))
                            RadAutoCompleteBoxEmployees.DataTextField = "EMP_NAME"
                            RadAutoCompleteBoxEmployees.DataValueField = "EMPCODE"
                            RadAutoCompleteBoxEmployees.DataBind()

                        End If

                        If IsColumnVisible(ColumnNames.colCLI_CONTACT) = True OrElse IsColumnVisible(ColumnNames.colCLI_CONTACT_IMGBTN) = True OrElse IsColumnVisible(ColumnNames.colCLI_CONTACT_TEXT) = True Then

                            ContactsString = Schedule.GetTaskContactListString(_JobNumber, _JobComponentNumber, ScheduleTask.SequenceNumber)

                            If String.IsNullOrWhiteSpace(LinkButtonClientContacts.Text) AndAlso String.IsNullOrWhiteSpace(ContactsString) Then

                                ContactsText = "Add"

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonClientContacts.Text) = False AndAlso String.IsNullOrWhiteSpace(ContactsString) Then

                                ContactsText = LinkButtonClientContacts.Text

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonClientContacts.Text) = False AndAlso String.IsNullOrWhiteSpace(ContactsString) = False Then

                                ContactsText = LinkButtonClientContacts.Text & ", " & ContactsString

                            ElseIf String.IsNullOrWhiteSpace(LinkButtonClientContacts.Text) AndAlso String.IsNullOrWhiteSpace(ContactsString) = False Then

                                ContactsText = ContactsString

                            End If

                            If ContactsText.Length > 0 Then

                                LinkButtonClientContacts.Text = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(ContactsText.Trim, ","), ",")
                                ImageButtonClientContacts.ToolTip = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(ContactsText.Trim, ","), ",")
                                ContactsText = ContactsText.Replace("Add", "")
                                TextBoxClientContacts.Text = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(ContactsText.Trim, ","), ",")

                            End If

                        End If

                        Try

                            If String.IsNullOrWhiteSpace(ScheduleTask.TaskStatus) = False Then

                                RadComboBoxTaskStatus.SelectedValue = ScheduleTask.TaskStatus.ToUpper

                            End If

                        Catch ex As Exception

                        End Try

                        If IsColumnVisible(ColumnNames.colPHASE_DESC) = True Then

                            LoadPhaseComboBox(RadComboBoxPhaseDescription, ScheduleTask.TrafficPhaseID, ScheduleTask.PhaseDescription, True)

                        End If

                        If IsColumnVisible(ColumnNames.colEstimateFunction) = True Then

                            LoadEstimateFunctionComboBox(RadComboBoxEstimateFunction, ScheduleTask.EstimateFunction, True)

                        End If

                        Try

                            ImageButtonTaskCode.Attributes.Add("onclick", "FocusTB('" & TextBoxTaskCode.ClientID & "');OpenRadWindowLookup('LookUp_Quick.aspx?fromform=pstask&key=" & DataKey & "&calledfrom=custom&control=" & TextBoxTaskCode.ClientID & "&type=task');ClearTB('" & TextBoxTaskCode.ClientID & "');ClearTB('" & TextBoxTaskDescription.ClientID & "');return false;")
                            TextBoxTaskCode.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=pstask&key=" & DataKey & "&calledfrom=custom&control=" & TextBoxTaskCode.ClientID & "&type=task');return false;")

                        Catch ex As Exception

                        End Try

                        Try

                            TextBoxTaskCode.Attributes.Add("onkeydown", "javascript:ClearTB('" & TextBoxTaskDescription.ClientID & "');")
                            TextBoxTaskDescription.Attributes.Add("onkeydown", "javascript:ClearTB('" & TextBoxTaskCode.ClientID & "');")
                            TextBoxTaskCode.Attributes.Add("onkeyup", "javascript:ClearTB('" & TextBoxTaskDescription.ClientID & "');")
                            TextBoxTaskDescription.Attributes.Add("onkeyup", "javascript:ClearTB('" & TextBoxTaskCode.ClientID & "');")

                        Catch ex As Exception

                        End Try

                        Try

                            CheckBoxMilestone.Checked = CBool(ScheduleTask.Milestone.GetValueOrDefault(0))

                        Catch ex As Exception

                        End Try

                        Try

                            If ScheduleTask.JobCompletedDate.HasValue Then

                                HasCompletedDate = cGlobals.wvIsDate(ScheduleTask.JobCompletedDate)

                            End If

                            If ScheduleTask.JobRevisedDate.HasValue Then

                                HasRevisedDate = cGlobals.wvIsDate(ScheduleTask.JobRevisedDate)

                            End If

                            If HasRevisedDate = True AndAlso HasCompletedDate = False Then

                                ThisDueDate = cGlobals.wvCDate(ScheduleTask.JobRevisedDate)
                                TextBoxJobRevisedDate.Text = ThisDueDate.ToShortDateString.Trim()

                                If (ThisDueDate > Today() AndAlso ThisDueDate < Today.AddDays(8)) Then

                                    TextBoxJobRevisedDate.CssClass = "standard-yellow"
                                    TextBoxJobRevisedDate.ToolTip = "Task is due this week!"

                                End If

                                If MiscFN.IsWeekendDay(ThisDueDate) = True Then

                                    TextBoxJobRevisedDate.CssClass = "standard-light-grey"
                                    TextBoxJobRevisedDate.ToolTip = "Due date is on a weekend!"

                                End If

                                If ThisDueDate = Today() Then

                                    TextBoxJobRevisedDate.CssClass = "standard-orange"
                                    TextBoxJobRevisedDate.ToolTip = "Task is due today!"

                                End If

                                If ThisDueDate < Today Then

                                    TextBoxJobRevisedDate.CssClass = "standard-red"
                                    TextBoxJobRevisedDate.ToolTip = "Task is overdue!"

                                End If

                            End If

                            If HasRevisedDate = True Then

                                ThisDueDate = cGlobals.wvCDate(ScheduleTask.JobRevisedDate)
                                TextBoxJobRevisedDate.Text = ThisDueDate.ToShortDateString.Trim()

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If ScheduleTask.TaskStartDate.HasValue Then

                                If cGlobals.wvIsDate(ScheduleTask.TaskStartDate) = True Then

                                    TextBoxTaskStartDate.Text = cGlobals.wvCDate(ScheduleTask.TaskStartDate).ToShortDateString.Trim()

                                Else

                                    TextBoxTaskStartDate.Text = ""

                                End If

                            Else

                                TextBoxTaskStartDate.Text = ""

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If ScheduleTask.JobRevisedDate.HasValue Then

                                If cGlobals.wvIsDate(ScheduleTask.JobRevisedDate) = True Then

                                    TextBoxJobRevisedDate.Text = cGlobals.wvCDate(ScheduleTask.JobRevisedDate).ToShortDateString.Trim()

                                Else

                                    TextBoxJobRevisedDate.Text = ""

                                End If

                            Else

                                TextBoxJobRevisedDate.Text = ""

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If ScheduleTask.JobDueDate.HasValue Then

                                If cGlobals.wvIsDate(ScheduleTask.JobDueDate) = True Then

                                    TextBoxJobDueDate.Text = cGlobals.wvCDate(ScheduleTask.JobDueDate).ToShortDateString.Trim()

                                Else

                                    TextBoxJobDueDate.Text = ""

                                End If

                            Else

                                TextBoxJobDueDate.Text = ""

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If ScheduleTask.JobCompletedDate.HasValue Then

                                If cGlobals.wvIsDate(ScheduleTask.JobCompletedDate) = True Then

                                    TextBoxJobCompletedDate.Text = cGlobals.wvCDate(ScheduleTask.JobCompletedDate).ToShortDateString.Trim()

                                Else

                                    TextBoxJobCompletedDate.Text = ""

                                End If

                            Else

                                TextBoxJobCompletedDate.Text = ""

                            End If

                            TextBoxJobCompletedDate.Attributes.Add("onclick", "SetToday('" & TextBoxJobCompletedDate.ClientID & "'); this.onchange();")

                        Catch ex As Exception

                        End Try

                        Try

                            If String.IsNullOrWhiteSpace(ScheduleTask.TemporaryCompleteDate) = False Then

                                If cGlobals.wvIsDate(ScheduleTask.TemporaryCompleteDate) = True Then

                                    TextBoxTemporaryCompleteDate.Text = cGlobals.wvCDate(ScheduleTask.TemporaryCompleteDate).ToShortDateString.Trim()

                                Else

                                    TextBoxTemporaryCompleteDate.Text = ""

                                End If

                            Else

                                TextBoxTemporaryCompleteDate.Text = ""

                            End If

                        Catch ex As Exception

                        End Try

                        LabelTemporaryCompleteDate.Text = TextBoxTemporaryCompleteDate.Text

                        If ScheduleTask.HasAssignment = 1 Then

                            ImageButtonDelete.Enabled = False

                        Else

                            ImageButtonDelete.Attributes("onclick") = "return confirm('Are you sure you want to delete this row?')"

                        End If

                        Try

                            If _CanEditProjectSchedule = True Then

                                StringBuilder = New System.Text.StringBuilder

                                With StringBuilder

                                    .Append("function DataChangeRadComboBox() {")
                                    .Append("var val;")
                                    .Append("var combo1 = $find('" & RadComboBoxTaskStatus.ClientID & "');")
                                    .Append("val = combo1.get_selectedItem().get_value();")
                                    .Append("DataChange('" & DataKey & "', 'ddl', 'RadComboBoxTaskStatus', val);")
                                    .Append("}")

                                End With

                                RadComboBoxTaskStatus.OnClientSelectedIndexChanged = StringBuilder.ToString

                                StringBuilder.Clear()

                                With StringBuilder

                                    .Append("function DataChangeRadComboBox() {")
                                    .Append("var val;")
                                    .Append("var combo1 = $find('" & RadComboBoxPhaseDescription.ClientID & "');")
                                    .Append("val = combo1.get_selectedItem().get_value();")
                                    .Append("DataChange('" & DataKey & "', 'ddl', 'RadComboBoxPhaseDescription', val);")
                                    .Append("}")

                                End With

                                RadComboBoxPhaseDescription.OnClientSelectedIndexChanged = StringBuilder.ToString

                                TextBoxTaskCode.Attributes.Add("onblur", "DataChangeTaskCode('" & DataKey & "','" & TextBoxTaskCode.ClientID & "','" & TextBoxTaskDescription.ClientID & "',this.value);")

                                With TextBoxTaskDescription

                                    .Attributes.Add("onkeyup", "ClearTBe(event,'" & TextBoxTaskCode.ClientID & "');")
                                    .Attributes.Add("onblur", "DataChangeTaskDesc('" & DataKey & "','" & TextBoxTaskCode.ClientID & "','" & TextBoxTaskDescription.ClientID & "',this.value);")

                                End With

                                TextBoxJobOrder.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                CheckBoxMilestone.InputAttributes.Add("onclick", "DataChangeCheckboxMilestone('" & DataKey & "','" & CheckBoxMilestone.ClientID & "');")
                                CheckBoxDueDateLock.InputAttributes.Add("onclick", "DataChangeCheckboxLock('" & DataKey & "','" & CheckBoxDueDateLock.ClientID & "');")
                                TextBoxJobDays.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxTaskStartDate.Attributes.Add("ondblclick", "setDataKey('" & DataKey & "');showPopup(this, event);")
                                TextBoxJobRevisedDate.Attributes.Add("ondblclick", "setDataKey('" & DataKey & "');showPopup(this, event);")
                                TextBoxJobDueDate.Attributes.Add("ondblclick", "setDataKey('" & DataKey & "');showPopup(this, event);")
                                TextBoxJobCompletedDate.Attributes.Add("ondblclick", "setDataKey('" & DataKey & "');showPopup(this, event);")
                                TextBoxTaskStartDate.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxJobRevisedDate.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxRevisedDueTime.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxJobDueDate.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxJobCompletedDate.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxJobHours.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxEmployees.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxClientContacts.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")

                                StringBuilder.Clear()

                                With StringBuilder

                                    .Append("function DataChangeRadComboBox() {")
                                    .Append("var val;")
                                    .Append("var combo1 = $find('" & RadComboBoxEstimateFunction.ClientID & "');")
                                    .Append("val = combo1.get_selectedItem().get_value();")
                                    .Append("DataChange('" & DataKey & "', 'ddl', 'RadComboBoxEstimateFunction', val);")
                                    .Append("}")

                                End With

                                RadComboBoxEstimateFunction.OnClientSelectedIndexChanged = StringBuilder.ToString

                                TextBoxFunctionComments.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxDueDateComments.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")
                                TextBoxRevisionDateComments.Attributes.Add("onchange", "DataChange('" & DataKey & "','txt',this.name,this.value);")

                                StringBuilder.Clear()

                                With StringBuilder

                                    .Append("function DataChangeRadAutoCompleteBox(sender, eventArgs) {")
                                    .Append("var val;")
                                    .Append("var comboauto = $find('" & RadAutoCompleteBoxEmployees.ClientID & "');")
                                    .Append("val = eventArgs.get_entry().get_value();")
                                    .Append("DataChange('" & DataKey & "', 'txt', 'RadAutoCompleteBoxEmployees', val);")
                                    .Append("}")

                                End With

                                RadAutoCompleteBoxEmployees.OnClientEntryAdded = StringBuilder.ToString

                                StringBuilder.Clear()

                                With StringBuilder

                                    .Append("function DataChangeRadAutoCompleteBox() {")
                                    .Append("var val;")
                                    .Append("var entryCount;")
                                    .Append("var empslist = '';")
                                    .Append("var comboauto = $find('" & RadAutoCompleteBoxEmployees.ClientID & "');")
                                    .Append("entryCount = comboauto.get_entries().get_count();")
                                    .Append("for (var i = 0; i < entryCount; i++) {")
                                    .Append("empslist += comboauto.get_entries().getEntry(i).get_value();")
                                    .Append("empslist += ',';")
                                    .Append(" }")
                                    .Append("DataChange('" & DataKey & "', 'txt', 'RadAutoCompleteBoxEmployeesDelete', empslist);")
                                    .Append("}")

                                End With

                                RadAutoCompleteBoxEmployees.OnClientEntryRemoved = StringBuilder.ToString

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            If _CanEditProjectSchedule = False OrElse Me.IsClientPortal = True Then

                                RadComboBoxTaskStatus.Enabled = False
                                RadComboBoxPhaseDescription.Enabled = False
                                TextBoxTaskCode.ReadOnly = True
                                TextBoxTaskDescription.ReadOnly = True
                                CheckBoxMilestone.Enabled = False
                                CheckBoxDueDateLock.Enabled = False
                                TextBoxJobOrder.ReadOnly = True
                                TextBoxJobDays.ReadOnly = True
                                TextBoxTaskStartDate.ReadOnly = True
                                TextBoxJobRevisedDate.ReadOnly = True
                                TextBoxRevisedDueTime.ReadOnly = True
                                TextBoxJobDueDate.ReadOnly = True
                                TextBoxJobCompletedDate.ReadOnly = True
                                TextBoxJobCompletedDate.Attributes.Add("onclick", "")
                                TextBoxJobCompletedDate.Attributes.Add("ondblclick", "")
                                TextBoxJobHours.ReadOnly = True
                                TextBoxEmployees.ReadOnly = True
                                RadAutoCompleteBoxEmployees.Enabled = False
                                TextBoxClientContacts.ReadOnly = True
                                RadComboBoxEstimateFunction.Enabled = False
                                TextBoxFunctionComments.ReadOnly = True
                                TextBoxDueDateComments.ReadOnly = True
                                TextBoxRevisionDateComments.ReadOnly = True
                                ImageButtonEmployees.Enabled = False
                                ImageButtonClientContacts.Enabled = False
                                LinkButtonEmployees.Enabled = False
                                LinkButtonClientContacts.Enabled = False
                                ImageButtonTaskCode.Enabled = False
                                TextBoxTaskCode.Attributes.Add("ondblclick", "")
                                LinkButtonDispersedHours.Enabled = False
                                ImageButtonAddPredecessors.Visible = False
                                RadTextBoxPredecessors.ReadOnly = True

                                If Me.IsClientPortal = True Then

                                    RadContextMenuGridItem.FindItemByValue("TaskDetails").Enabled = True
                                    RadContextMenuGridItem.FindItemByValue("NewTaskAlert").Enabled = False
                                    RadContextMenuGridItem.FindItemByValue("NewTaskAssignment").Enabled = False
                                    RadContextMenuGridItem.FindItemByValue("DeleteTask").Enabled = False
                                    'RadContextMenuGridItem.FindItemByValue("CopyTask").Enabled = False

                                    'RadContextMenuGridItem.Enabled = False

                                End If

                            ElseIf Me.IsClientPortal = True Then

                                RadContextMenuGridItem.FindItemByValue("TaskDetails").Enabled = True
                                RadContextMenuGridItem.FindItemByValue("NewTaskAlert").Enabled = False
                                RadContextMenuGridItem.FindItemByValue("NewTaskAssignment").Enabled = False
                                RadContextMenuGridItem.FindItemByValue("DeleteTask").Enabled = False
                                'RadContextMenuGridItem.FindItemByValue("CopyTask").Enabled = False

                                'RadContextMenuGridItem.Enabled = False

                            End If

                        Catch ex As Exception

                        End Try

                        Try

                            LabelPercentComplete.Text = String.Format("{0:N}", CDec(LabelPercentComplete.Text))

                        Catch ex As Exception

                        End Try

                    End If 'job is loaded

                    If ScheduleTask.HasChildren = True Then

                        LabelJobRevisedDate.Visible = True
                        LabelTaskStartDate.Visible = True
                        LabelDisbursedHours.Visible = True

                        HideGridControlAndRemoveData(LabelJobDays)
                        HideGridControlAndRemoveData(ImageButtonAddPredecessors)
                        HideGridControlAndRemoveData(RadButtonLinked)
                        HideGridControlAndRemoveData(TextBoxJobRevisedDate)
                        HideGridControlAndRemoveData(TextBoxTaskStartDate)
                        HideGridControlAndRemoveData(TextBoxJobDays)
                        HideGridControlAndRemoveData(TextBoxJobDueDate)
                        HideGridControlAndRemoveData(TextBoxJobCompletedDate)
                        HideGridControlAndRemoveData(TextBoxTemporaryCompleteDate)
                        HideGridControlAndRemoveData(TextBoxClientContacts)
                        HideGridControlAndRemoveData(ImageButtonClientContacts)
                        HideGridControlAndRemoveData(LinkButtonClientContacts)
                        HideGridControlAndRemoveData(TextBoxEmployees)
                        HideGridControlAndRemoveData(RadAutoCompleteBoxEmployees)
                        HideGridControlAndRemoveData(ImageButtonEmployees)
                        HideGridControlAndRemoveData(LinkButtonEmployees)
                        HideGridControlAndRemoveData(TextBoxJobHours)
                        HideGridControlAndRemoveData(CheckBoxDueDateLock)
                        HideGridControlAndRemoveData(RadComboBoxTaskStatus)
                        HideGridControlAndRemoveData(LinkButtonDispersedHours)
                        HideGridControlAndRemoveData(RadComboBoxEstimateFunction)
                        HideGridControlAndRemoveData(RadTextBoxPredecessors)

                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivEmployees)
                        AdvantageFramework.Web.Presentation.Controls.DivHide(DivClientContacts)

                    End If

                End If

            End If

        End If 'in a datarow

        If TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then

            GridFooterItem = e.Item

            If Not GridFooterItem Is Nothing Then

                Try

                    GridFooterItem("colJOB_HRS").Text = GridFooterItem("colJOB_HRS").Text.Replace("Sum", "").Replace("Custom", "").Replace(":", "").Replace(" ", "")

                Catch ex As Exception

                End Try

                Try

                    GridFooterItem("colDISPERSED_JOB_HRS").Text = GridFooterItem("colDISPERSED_JOB_HRS").Text.Replace("Sum", "").Replace(":", "").Replace(" ", "")

                Catch ex As Exception

                End Try

                Try

                    GridFooterItem("colPOSTED_HOURS").Text = GridFooterItem("colPOSTED_HOURS").Text.Replace("Sum", "").Replace(":", "").Replace(" ", "")

                Catch ex As Exception

                End Try

            End If

        End If

    End Sub
    Private Sub RadGridProjectSchedule_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridProjectSchedule.PageIndexChanged

        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub RadGridProjectSchedule_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridProjectSchedule.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridProjectSchedule.ID, e.NewPageSize)

        End If

    End Sub
    Private Sub RadGridProjectSchedule_PreRender(sender As Object, e As System.EventArgs) Handles RadGridProjectSchedule.PreRender

        Dim RadAutoCompleteBoxEmployees As Telerik.Web.UI.RadAutoCompleteBox = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim DataKey As String = Nothing
        Dim ScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing

        HideEmptyDetailTableAndExpandColumn(RadGridProjectSchedule.MasterTableView)

        For Each GridDataItem In RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            GridDataItem.ExpandHierarchyToTop()

        Next

        If RadGridProjectSchedule.Items.Count = 0 Or IsClientPortal = True Then

            RadToolbarButtonQuickEdit.Visible = False

        Else

            RadToolbarButtonQuickEdit.Visible = True

        End If

        If IsClientPortal = True Then
            Me.RadGridProjectSchedule.ClientSettings.AllowRowsDragDrop = False
        End If

        Me.RadToolbarScheduleGrid.FindItemByValue("SeparatorQuickEdit").Visible = RadToolbarButtonQuickEdit.Visible

    End Sub
    Private Sub RadGridProjectSchedule_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjectSchedule.NeedDataSource

        'objects
        Dim oAppVars As Webvantage.cAppVars = Nothing
        Dim SortString As String = ""
        Dim RadAutoCompleteBoxEmployees As Telerik.Web.UI.RadAutoCompleteBox = Nothing

        _LoadingDatasource = True

        Try

            oAppVars = New Webvantage.cAppVars(cAppVars.Application.PROJECT_SCHEDULE)

            oAppVars.getAllAppVars()

            If oAppVars.getAppVar("IncludeCompleted") <> "" Then

                Me.ChkShowCompletedTasks.Checked = oAppVars.getAppVar("IncludeCompleted", "Boolean")
                _IncludeCompletedTasks = Me.ChkShowCompletedTasks.Checked

            End If

            If Me.CalculateByPredecessor = False Then

                SortString = oAppVars.getAppVar("GridSort", "String")

                Me.SetGridSort(SortString)

                If String.IsNullOrWhiteSpace(SortString) = False Then

                    Try

                        MiscFN.RadComboBoxSetIndex(Me.DropSort, SortString, False)

                    Catch ex As Exception

                    End Try

                End If

            Else

                Me.RadGridProjectSchedule.MasterTableView.GroupByExpressions.Clear()

            End If

            TextBoxLabels.Text = ""

            Dim ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
            Dim CustomPages As Generic.Dictionary(Of Integer, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) = Nothing
            Dim PageSize As Integer = MiscFN.LoadPageSize(Me.RadGridProjectSchedule.ID)
            Dim PageIndex As Integer = Me.CurrentGridPageIndex

            ScheduleTasks = Me.DataSource2

            If RadGridProjectSchedule.MasterTableView.AllowPaging = True Then

                Me.RadGridProjectSchedule.AllowCustomPaging = True

                CustomPages = GetCustomPages(ScheduleTasks, PageSize)

                RadGridProjectSchedule.VirtualItemCount = ScheduleTasks.Count 'CustomPages.Count * PageSize

                If CustomPages.Count <= PageIndex Then

                    PageIndex = Math.Max(0, (CustomPages.Count - 1))

                End If

                CustomGridPagingPageCount.Value = CustomPages.Count
                CustomGridPagingItemCount.Value = ScheduleTasks.Count

                If CustomPages.Count > 0 Then

                    Me.RadGridProjectSchedule.DataSource = CustomPages(PageIndex) 'dt

                Else

                    Me.RadGridProjectSchedule.DataSource = ""

                End If

            Else

                CustomGridPagingPageCount.Value = 1
                CustomGridPagingItemCount.Value = ScheduleTasks.Count

                Me.RadGridProjectSchedule.AllowCustomPaging = False
                Me.RadGridProjectSchedule.DataSource = ScheduleTasks

            End If

            Me.RadGridProjectSchedule.CurrentPageIndex = PageIndex
            Me.RadGridProjectSchedule.PageSize = PageSize

        Catch ex As Exception

        End Try

        _LoadingDatasource = False

    End Sub
    Private Function GetCustomPages(ByVal ScheduleTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask), ByVal PageSize As Integer) As Generic.Dictionary(Of Integer, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask))

        'objects
        Dim Levels As String() = Nothing
        Dim LevelTasks As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim Pages As Generic.Dictionary(Of Integer, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)) = Nothing
        Dim PreviousLevel As String = Nothing

        Pages = New Generic.Dictionary(Of Integer, Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask))

        Levels = ScheduleTasks.Where(Function(t) t.ParentTaskSequenceNumber.HasValue = Nothing).Select(Function(t) t.Level).ToArray

        For Each Level In Levels

            LevelTasks = ScheduleTasks.Where(Function(t) t.Level = Level OrElse t.Level.StartsWith(Level & ".")).ToList

            If Pages.Any = False Then

                Pages.Add(0, LevelTasks)

            ElseIf Pages.Last.Value.Count >= PageSize Then

                Pages.Add(Pages.Count(), LevelTasks)

            Else

                Pages.Last.Value.AddRange(LevelTasks)

            End If

        Next

        Return Pages

    End Function
    Private Sub RadGridProjectSchedule_RowDrop(sender As Object, e As Telerik.Web.UI.GridDragDropEventArgs) Handles RadGridProjectSchedule.RowDrop

        'objects
        Dim NewScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim OriginalScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim OriginalScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TargetScheduleTask As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TaskAbove As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TaskBelow As AdvantageFramework.ProjectSchedule.Classes.ScheduleTask = Nothing
        Dim TasksToMove As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing
        Dim TaskIDsToMove As Integer() = Nothing
        Dim ParentTaskSequenceNumber As Short? = Nothing
        Dim GridOrder As Integer = 0
        Dim TargetTaskID As Integer = 0
        Dim IsTargetTaskParent As Boolean = False
        Dim AddTasksBeforeTarget As Boolean = False
        Dim TaskChanged As Boolean = False
        Dim JobOrder As Integer? = Nothing
        Dim DoUpdate As Boolean = False
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim SQLString As String = Nothing

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        If String.IsNullOrWhiteSpace(e.HtmlElement) Then

            OriginalScheduleTaskList = Me.DataSource2

            TaskIDsToMove = (From Entity In e.DraggedItems.OfType(Of Telerik.Web.UI.GridDataItem)()
                             Select CInt(Entity.GetDataKeyValue("ID"))).ToArray

            TasksToMove = (From Entity In OriginalScheduleTaskList
                           Where TaskIDsToMove.Contains(Entity.ID)
                           Select Entity).ToList

            If e.DestDataItem IsNot Nothing Then

                TargetTaskID = CInt(e.DestDataItem.GetDataKeyValue("ID"))

            ElseIf e.DestinationTableView IsNot Nothing AndAlso e.DestinationTableView.ParentItem IsNot Nothing Then

                TargetTaskID = CInt(e.DestinationTableView.ParentItem.GetDataKeyValue("ID"))

                IsTargetTaskParent = True

            End If

            TargetScheduleTask = (From Entity In OriginalScheduleTaskList
                                  Where Entity.ID = TargetTaskID
                                  Select Entity).SingleOrDefault

            If TargetScheduleTask IsNot Nothing Then

                NewScheduleTaskList = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)

                For Each OriginalScheduleTask In OriginalScheduleTaskList

                    If TasksToMove.Select(Function(t) t.ID).ToArray.Contains(OriginalScheduleTask.ID) = False Then

                        If OriginalScheduleTask.ID = TargetScheduleTask.ID Then

                            If IsTargetTaskParent Then

                                ParentTaskSequenceNumber = TargetScheduleTask.SequenceNumber

                            Else

                                ParentTaskSequenceNumber = TargetScheduleTask.ParentTaskSequenceNumber

                                If e.DropPosition = Telerik.Web.UI.GridItemDropPosition.Above Then

                                    AddTasksBeforeTarget = True

                                End If

                            End If

                            If Me.CalculateByPredecessor = False Then

                                If AddTasksBeforeTarget Then

                                    Try

                                        TaskAbove = OriginalScheduleTaskList(OriginalScheduleTaskList.IndexOf(TargetScheduleTask) - 1)

                                    Catch ex As Exception
                                        TaskAbove = Nothing
                                    End Try

                                    TaskBelow = TargetScheduleTask

                                Else

                                    TaskAbove = TargetScheduleTask

                                    Try

                                        TaskBelow = OriginalScheduleTaskList(OriginalScheduleTaskList.IndexOf(TargetScheduleTask) + 1)

                                    Catch ex As Exception
                                        TaskBelow = Nothing
                                    End Try

                                End If

                                If TaskAbove IsNot Nothing Then

                                    JobOrder = TaskAbove.JobOrder

                                Else

                                    JobOrder = TaskBelow.JobOrder

                                End If

                            End If

                            If AddTasksBeforeTarget = True Then

                                NewScheduleTaskList.AddRange(TasksToMove)
                                NewScheduleTaskList.Add(OriginalScheduleTask)

                            Else

                                NewScheduleTaskList.Add(OriginalScheduleTask)
                                NewScheduleTaskList.AddRange(TasksToMove)

                            End If

                        Else

                            NewScheduleTaskList.Add(OriginalScheduleTask)

                        End If

                    End If

                Next

                StringBuilder = New System.Text.StringBuilder

                For Each ScheduleTask In NewScheduleTaskList

                    DoUpdate = False

                    For Each OrigScheduleTask In OriginalScheduleTaskList

                        If OrigScheduleTask.ID = ScheduleTask.ID Then

                            OriginalScheduleTask = OrigScheduleTask

                            Exit For

                        End If

                    Next

                    GridOrder = NewScheduleTaskList.IndexOf(ScheduleTask) + 1

                    If TasksToMove.Any(Function(t) t.ID = OriginalScheduleTask.ID) Then

                        If Me.CalculateByPredecessor = True Then

                            If ParentTaskSequenceNumber.GetValueOrDefault(-1) <> ScheduleTask.ParentTaskSequenceNumber.GetValueOrDefault(-1) Then

                                ScheduleTask.ParentTaskSequenceNumber = ParentTaskSequenceNumber

                                MoveTaskHierarchy(ScheduleTask.SequenceNumber, ScheduleTask.ParentTaskSequenceNumber)

                            End If

                        Else

                            ScheduleTask.JobOrder = JobOrder

                            DoUpdate = True

                        End If

                    End If

                    If DoUpdate = False Then

                        If ScheduleTask.GridOrder.GetValueOrDefault(-1) <> GridOrder Then

                            DoUpdate = True

                        End If

                    End If

                    If DoUpdate Then

                        StringBuilder.Append(String.Format(" UPDATE " &
                                                           "     [dbo].[JOB_TRAFFIC_DET] " &
                                                           " SET " &
                                                           "     [GRID_ORDER] = {0}, " &
                                                           "     [JOB_ORDER] = {1} " &
                                                           " WHERE " &
                                                           "     [ROWID] = {2}; ", GridOrder, If(ScheduleTask.JobOrder.HasValue, ScheduleTask.JobOrder, "NULL"), ScheduleTask.ID))

                    End If

                Next

                SQLString = StringBuilder.ToString

                If String.IsNullOrWhiteSpace(SQLString) = False Then

                    Try

                        _DbContext.Database.ExecuteSqlCommand(SQLString)

                    Catch ex As Exception

                    End Try

                End If

                'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex
                RadGridProjectSchedule.Rebind()

            End If

        End If

    End Sub
    Private Sub RadToolbarScheduleGrid_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarScheduleGrid.ButtonClick

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim CheckBoxSelectAllRows As System.Web.UI.WebControls.CheckBox = Nothing
        Dim Schedule As Webvantage.cSchedule = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim Rush As Integer = 0
        Dim URL As String = ""
        Dim CheckBox As System.Web.UI.WebControls.CheckBox = Nothing
        Dim VariableString As String = ""
        Dim Count As Integer = 0
        Dim SqlTransaction As System.Data.SqlClient.SqlTransaction = Nothing
        Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
        Dim StringBuilder As System.Text.StringBuilder = Nothing
        Dim SQL As String = ""

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        Select Case e.Item.Value

            Case RadToolbarButtonQuickEdit.Value

                QueryString = New AdvantageFramework.Web.QueryString
                QueryString = QueryString.FromCurrent()

                With QueryString

                    .Page = "TrafficSchedule_QuickEdit.aspx"
                    .Add(QueryStringVars.Comp.ToString, Me.ChkShowCompletedTasks.Checked)

                End With

                Me.OpenWindow("", QueryString.ToString(True), 730, 825, False, True)

            Case "AddFromPreset" '**Grid** Toolbar event

                SaveAlmostEverything()
                URL = "TrafficSchedule_AddFromPreset.aspx?R=1&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber
                Me.OpenWindow("", URL, 200, 400, False, True)

            Case RadToolbarButtonCheckWorkload.Value

                SaveAlmostEverything()

                If Me.RadDatePickerStartDate.SelectedDate.HasValue = False OrElse Me.RadDatePickerDueDate.SelectedDate.HasValue = False Then

                    Me.ShowMessage("Workload analysis requires valid start and due dates.")
                    Exit Sub

                Else

                    Session("WorkloadStart") = cGlobals.wvCDate(Me.RadDatePickerStartDate.SelectedDate).ToShortDateString
                    Session("WorkloadEnd") = cGlobals.wvCDate(Me.RadDatePickerDueDate.SelectedDate).ToShortDateString
                    Session("WorkloadIsMulti") = "False"
                    Session("WorkloadJobCompList") = _JobNumber.ToString() & "," & _JobComponentNumber.ToString() & "|"

                    URL = "ProgressIndicator.aspx?destPage=TrafficSchedule_Workload2.aspx"
                    Me.OpenWindow("Workload Analysis", URL, 500, 900, False, False)

                End If

        End Select

    End Sub
    Private Sub RadListBoxJobCompPred_Deleting(sender As Object, e As Telerik.Web.UI.RadListBoxDeletingEventArgs) Handles RadListBoxJobCompPred.Deleting

        Dim JobTrafficPredecessorsList As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
        Dim Values As String() = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing

        Try

            For Each RadListBoxItem In Me.RadListBoxJobCompPred.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                If RadListBoxItem.Selected Then

                    Values = RadListBoxItem.Value.Split("/")

                    Try

                        JobNumber = CInt(Values(0))

                    Catch ex As Exception
                        JobNumber = 0
                    End Try

                    Try

                        JobComponentNumber = CShort(Values(1))

                    Catch ex As Exception
                        JobComponentNumber = 0
                    End Try

                    For Each JobTrafficPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumber(_DbContext, _JobNumber, _JobComponentNumber).ToList

                        If JobTrafficPredecessor.JobPredecessor = JobNumber AndAlso JobTrafficPredecessor.JobComponentPredecessor = JobComponentNumber Then

                            AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(_DbContext, JobTrafficPredecessor)

                        End If

                    Next

                End If

            Next

        Catch ex As Exception

        End Try

    End Sub
    Private Sub DropPhaseFilter_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropPhaseFilter.SelectedIndexChanged

        Session(Me.SessionVars.PS_Ignore_Filter.ToString) = "1"
        Me.RadGridProjectSchedule.Rebind()

    End Sub
    Private Sub ChkShowCompletedTasks_CheckedChanged(sender As Object, e As System.EventArgs) Handles ChkShowCompletedTasks.CheckedChanged

        'objects
        Dim AppVars As Webvantage.cAppVars = Nothing

        Try

            AppVars = New Webvantage.cAppVars(cAppVars.Application.PROJECT_SCHEDULE)
            AppVars.getAllAppVars()
            AppVars.setAppVar("IncludeCompleted", Me.ChkShowCompletedTasks.Checked, "Boolean")
            AppVars.SaveAllAppVars()
            _IncludeCompletedTasks = Me.ChkShowCompletedTasks.Checked
            Me.RadGridProjectSchedule.Rebind()

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ImageButtonJobCompPred_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonJobCompPred.Click

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        Try

            QueryString = New AdvantageFramework.Web.QueryString()

            With QueryString

                .Page = "TrafficSchedule_AddJobPred.aspx"
                .JobNumber = _JobNumber
                .JobComponentNumber = _JobComponentNumber

            End With

            Me.OpenWindow("", QueryString.ToString(True), 730, 1025, False, True)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadListBoxPredecessors_Deleting(sender As Object, e As Telerik.Web.UI.RadListBoxDeletingEventArgs) Handles RadListBoxPredecessors.Deleting

        'objects
        Dim JobTrafficPredecessorsList As Generic.List(Of AdvantageFramework.Database.Entities.JobTrafficPredecessors) = Nothing
        Dim Values As String() = Nothing
        Dim JobNumber As Integer = Nothing
        Dim JobComponentNumber As Short = Nothing

        Try

            For Each RadListBoxItem In Me.RadListBoxPredecessors.Items.OfType(Of Telerik.Web.UI.RadListBoxItem)()

                If RadListBoxItem.Selected Then

                    Values = RadListBoxItem.Value.Split("/")

                    Try

                        JobNumber = CInt(Values(0))

                    Catch ex As Exception
                        JobNumber = 0
                    End Try

                    Try

                        JobComponentNumber = CShort(Values(1))

                    Catch ex As Exception
                        JobComponentNumber = 0
                    End Try

                    For Each JobTrafficPredecessor In AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(_DbContext, _JobNumber, _JobComponentNumber).ToList

                        If JobTrafficPredecessor.JobNumber = JobNumber AndAlso JobTrafficPredecessor.JobComponentNumber = JobComponentNumber Then

                            AdvantageFramework.Database.Procedures.JobTrafficPredecessors.Delete(_DbContext, JobTrafficPredecessor)

                        End If

                    Next

                End If

            Next

            Me.CheckForPredecessors()

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadListBoxJobCompPred_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxJobCompPred.ItemDataBound

        'objects
        Dim Values As String() = Nothing

        Try

            Values = e.Item.Value.Split("/")
            e.Item.Attributes.Add("ondblclick", Me.HookUpOpenWindow("", "TrafficSchedule.aspx?JobNum=" & Values(0) & "&JobComp=" & Values(1)))

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadListBoxPredecessors_ItemDataBound(sender As Object, e As Telerik.Web.UI.RadListBoxItemEventArgs) Handles RadListBoxPredecessors.ItemDataBound

        'objects
        Dim Values As String() = Nothing

        Try

            Values = e.Item.Value.Split("/")
            e.Item.Attributes.Add("ondblclick", Me.HookUpOpenWindow("", "TrafficSchedule.aspx?JobNum=" & Values(0) & "&JobComp=" & Values(1)))

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadDatePickerDateShipped_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDateShipped.SelectedDateChanged

        'objects
        Dim ErrorMessage As String = ""
        Dim SelectedDateString As String = ""

        If Not Me.RadDatePickerDateShipped.SelectedDate Is Nothing Then

            SelectedDateString = CType(Me.RadDatePickerDateShipped.SelectedDate, Date).ToShortDateString()

        End If

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "DATE_SHIPPED", SelectedDateString, Me.RadDatePickerDateShipped.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RadDatePickerDateDelivered_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDateDelivered.SelectedDateChanged

        'objects
        Dim ErrorMessage As String = ""
        Dim SelectedDateString As String = ""

        If Not Me.RadDatePickerDateDelivered.SelectedDate Is Nothing Then

            SelectedDateString = CType(Me.RadDatePickerDateDelivered.SelectedDate, Date).ToShortDateString()

        End If

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "DATE_DELIVERED", SelectedDateString, Me.RadDatePickerDateDelivered.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RblCalcOnStartDate_CheckedChanged(sender As Object, e As EventArgs) Handles RblCalcOnStartDate.CheckedChanged

        'objects
        Dim ErrorMessage As String = ""

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "TRF_SCHEDULE_BY", If(RblCalcOnStartDate.Checked, 1, 0), Me.RblCalcOnStartDate.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged

        'objects
        Dim ErrorMessage As String = Nothing
        Dim SelectedDateString As String = Nothing

        If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing Then

            SelectedDateString = CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString()

        End If

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "START_DATE", SelectedDateString, Me.RadDatePickerStartDate.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RblCalcOnDueDate_CheckedChanged(sender As Object, e As EventArgs) Handles RblCalcOnDueDate.CheckedChanged

        'objects
        Dim ErrorMessage As String = ""

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "TRF_SCHEDULE_BY", If(RblCalcOnDueDate.Checked = False, 1, 0), Me.RblCalcOnDueDate.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RadDatePickerDueDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerDueDate.SelectedDateChanged

        'objects
        Dim ErrorMessage As String = ""
        Dim SelectedDateString As String = ""

        If Not Me.RadDatePickerDueDate.SelectedDate Is Nothing Then

            SelectedDateString = CType(Me.RadDatePickerDueDate.SelectedDate, Date).ToShortDateString()

        End If

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "JOB_FIRST_USE_DATE", SelectedDateString, Me.RadDatePickerDueDate.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Private Sub RadDatePickerJobCompleted_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerJobCompleted.SelectedDateChanged

        'objects
        Dim ErrorMessage As String = ""
        Dim SelectedDateString As String = ""

        If Not Me.RadDatePickerJobCompleted.SelectedDate Is Nothing Then

            SelectedDateString = CType(Me.RadDatePickerJobCompleted.SelectedDate, Date).ToShortDateString()

        End If

        ErrorMessage = TrafficSchedule.AutoSaveScheduleHeader(_JobNumber.ToString() & "|" & _JobComponentNumber.ToString(), "COMPLETED_DATE", SelectedDateString, Me.RadDatePickerJobCompleted.ClientID)

        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

            Me.ShowMessage(ErrorMessage)

        End If

    End Sub
    Protected Sub RadContextMenuGridItem_ItemClick(sender As Object, e As Telerik.Web.UI.RadMenuEventArgs)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim FunctionCode As String = Nothing
        Dim WindowURL As String = Nothing
        Dim SequenceNumber As Short = Nothing

        GridDataItem = RadGridProjectSchedule.Items.OfType(Of Telerik.Web.UI.GridDataItem).Where(Function(i) i.ItemIndexHierarchical = HiddenFieldSelectedRow.Value).FirstOrDefault

        'Me.CurrentGridPageIndex = RadGridProjectSchedule.CurrentPageIndex

        If GridDataItem IsNot Nothing Then

            SequenceNumber = CShort(GridDataItem.GetDataKeyValue("SequenceNumber"))

            Select Case e.Item.Value

                Case "TaskDetails"

                    SaveGridRow(GridDataItem, True)
                    WindowURL = "TrafficSchedule_TaskDetail.aspx?pop=0&JobNum=" & _JobNumber & "&JobComp=" & _JobComponentNumber & "&SeqNum=" & SequenceNumber & "&Client=" & Me.HiddenFieldClientCode.Value & "&Division=" & Me.HiddenFieldDivisionCode.Value & "&Product=" & Me.HiddenFieldProductCode.Value
                    Me.OpenWindow("Edit Task", WindowURL)

                Case "NewTaskAlert"

                    Try

                        FunctionCode = CType(FindGridControl(GridDataItem, GridControls.TextBoxTaskCode), System.Web.UI.WebControls.TextBox).Text

                    Catch ex As Exception
                        FunctionCode = ""
                    End Try

                    WindowURL = "Alert_New.aspx?caller=" & Me.PageFilename & "&assn=0&pop=1&f= " & CType(MiscFN.Source_App.ProjectScheduleTask, Integer).ToString() &
                                "&j=" & _JobNumber.ToString() & "&jc=" & _JobComponentNumber.ToString() & "&seq=" & SequenceNumber.ToString() & "&fnc=" &
                                FunctionCode & "&cli=&div=&prd="

                    Me.OpenWindow("New Assignment", WindowURL)

                Case "NewTaskAssignment"

                    Try

                        FunctionCode = CType(FindGridControl(GridDataItem, GridControls.TextBoxTaskCode), System.Web.UI.WebControls.TextBox).Text

                    Catch ex As Exception
                        FunctionCode = ""
                    End Try

                    WindowURL = "Alert_New.aspx?assn=1&pop=1&f= " & CType(MiscFN.Source_App.ProjectScheduleTask, Integer).ToString() &
                                "&j=" & _JobNumber.ToString() & "&jc=" & _JobComponentNumber.ToString() & "&seq=" & SequenceNumber.ToString() & "&fnc=" &
                                FunctionCode & "&cli=&div=&prd="

                    Me.OpenWindow("New Assignment", WindowURL)

                Case "DeleteTask"

                    For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridProjectSchedule.MasterTableView.Items
                        If gridItem.Selected = True Then
                            SequenceNumber = CShort(gridItem.GetDataKeyValue("SequenceNumber"))
                            DeleteGridRow(_JobNumber, _JobComponentNumber, SequenceNumber)
                        End If
                    Next


                    Me.RadGridProjectSchedule.Rebind()

                Case "CopyTask"

                    For Each gridItem As Telerik.Web.UI.GridDataItem In Me.RadGridProjectSchedule.MasterTableView.Items
                        If gridItem.Selected = True Then
                            SequenceNumber = CShort(gridItem.GetDataKeyValue("SequenceNumber"))
                            DeleteGridRow(_JobNumber, _JobComponentNumber, SequenceNumber)
                        End If
                    Next


                    Me.RadGridProjectSchedule.Rebind()

            End Select

        End If

    End Sub
    Protected Sub RadComboBoxEstimateFunction_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs)

        'objects
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim SelectedValue As String = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadComboBox Then

            RadComboBox = DirectCast(sender, Telerik.Web.UI.RadComboBox)

            SelectedValue = RadComboBox.SelectedValue

            LoadEstimateFunctionComboBox(RadComboBox, SelectedValue, False)

        End If

    End Sub
    Protected Sub RadComboBoxPhaseDescription_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs)

        'objects
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim PhaseID As Integer? = Nothing
        Dim PhaseDescription As String = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadComboBox Then

            RadComboBox = DirectCast(sender, Telerik.Web.UI.RadComboBox)

            If RadComboBox.SelectedItem IsNot Nothing Then

                PhaseID = CInt(RadComboBox.SelectedItem.Value)
                PhaseDescription = RadComboBox.SelectedItem.Text

            End If

            LoadPhaseComboBox(RadComboBox, PhaseID, PhaseDescription, False)

        End If

    End Sub
    Private Sub DropSort_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles DropSort.SelectedIndexChanged

        SetGridSort(Me.DropSort.SelectedValue)

        RadGridProjectSchedule.Rebind()

    End Sub

#End Region

#Region " Auto Complete "

    Public Function GetCommaDelimitedStringOfEmployeeCodes(ByVal radbox As Telerik.Web.UI.RadAutoCompleteBox) As String

        Dim sb As New System.Text.StringBuilder

        For Each entry As Telerik.Web.UI.AutoCompleteBoxEntry In radbox.Entries

            If entry.Text.Contains("(CC)") = False Then

                sb.Append(entry.Value)
                sb.Append(",")

            End If

        Next

        Return MiscFN.CleanStringForSplit(sb.ToString(), ",")

    End Function
    Public Overloads Sub AddEntries(ByVal CommaDelimitedStringOfEmployeeCodes As String, ByVal radbox As Telerik.Web.UI.RadAutoCompleteBox)

        CommaDelimitedStringOfEmployeeCodes = MiscFN.CleanStringForSplit(CommaDelimitedStringOfEmployeeCodes, ",")
        Dim ar() As String
        ar = CommaDelimitedStringOfEmployeeCodes.Split(",")

        Me.AddEntries(ar, radbox)

    End Sub
    Public Overloads Sub AddEntries(ByVal Strings As String(), ByVal radbox As Telerik.Web.UI.RadAutoCompleteBox)

        Dim e As New cEmployee(HttpContext.Current.Session("ConnString"))
        Dim Name As String = ""

        radbox.Entries.Clear()

        For Each Str As String In Strings

            Str = Str.Trim()

            If Str <> "" Then

                Dim NewEntry As New Telerik.Web.UI.AutoCompleteBoxEntry

                Name = e.GetName(Str)

                If Name Is Nothing OrElse Name = "" Then

                    Name = Str

                End If

                NewEntry.Text = Name
                NewEntry.Value = Str

                radbox.Entries.Add(NewEntry)

            End If

        Next

    End Sub

#End Region

#End Region

End Class
