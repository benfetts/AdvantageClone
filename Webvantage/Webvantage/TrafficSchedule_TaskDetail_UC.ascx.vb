Imports System.Data.SqlClient
Imports System.Data
Partial Public Class TrafficSchedule_TaskDetail_UC
    Inherits Webvantage.BaseChildPageUserControl

    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public NumberOfDays As Integer = 0
    Public NumberOfHours As Decimal = CDec(0.0)

    Public Phase As String = ""
    Public TaskCode As String = ""
    Public TaskStatus As String = ""
    Public EstimateFunction As String = ""
    Public StartDate As String = ""
    Public DueDate As String = ""
    Public OriginalDueDate As String = ""
    Public DateCompleted As String = ""
    Public TaskComments As String = ""
    Public RevisionDateComments As String = ""
    Public DueDateComments As String = ""
    Public Event CancelClicked()
    Public IsMilestone As Boolean = False
    Public IsLocked As Boolean = False
    Public TaskDescription As String

    Public LoadTaskFailed As Boolean = False
    Public ErrorMessage As String = ""

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.JobNumber = Request.QueryString("JobNum")
        Me.JobCompNumber = Request.QueryString("JobComp")
        Me.SeqNum = Request.QueryString("SeqNum")
        Dim CurrentQueryString As New AdvantageFramework.Web.QueryString
        CurrentQueryString = CurrentQueryString.FromCurrent

        If CurrentQueryString.JobNumber > 0 Then Me.JobNumber = CurrentQueryString.JobNumber
        If CurrentQueryString.JobComponentNumber > 0 Then Me.JobCompNumber = CurrentQueryString.JobComponentNumber
        If CurrentQueryString.TaskSequenceNumber > 0 Then Me.SeqNum = CurrentQueryString.TaskSequenceNumber
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            If Not Me.IsPostBack And Not Me.Page.IsCallback Then

                Me.SetRadDatePicker(Me.RadDatePickerStartDate)
                Me.SetRadDatePicker(Me.RadDatePickerDueDate)
                Me.SetRadDatePicker(Me.RadDatePickerDateCompleted)

                LoadPhase()
                'Me.TxtOrder.Focus()

                LoadTask()


            Else
                If Not TxtTaskCode.Text = "" Then
                    Me.TxtTaskDescription.Text = LookupTaskCode(Me.TxtTaskCode.Text)
                End If
            End If

            'LoadEstimateFunctions()

            'LoadJustTempDueDate()
            'Me.TxtStartDate = Me.FindControl("TxtStatDate")
            'Me.RadDatePickerStartDate.SelectedDate = StartDate
            'Response.Write("Test value passed in: " & StartDate)
            'Dim strURL As String = "TrafficSchedule_TaskEmployees.aspx?JobNum=" & Me.JobNumber & "&JobComp=" & Me.JobCompNumber & "&SeqNum=" & Me.SeqNum & "&TaskCode=" & Me.TxtTaskCode.Text
            'Me.hlEmployees.Attributes.Add("onclick", "window.radopen(""" & strURL & """,""RadWindowEmps"");")
            CheckPageSecurity()

        Catch ex As Exception
            Response.Write("Error in TrafficSchedule_Detail2:Page_Load " & ex.Message.ToString())
        End Try
    End Sub
    Public Sub CheckPageSecurity()
        Try
            Dim access As Integer = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = Me.JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = Me.JobCompNumber
            oTask.Where.SEQ_NBR.Value = Me.SeqNum
            oTask.Query.Load()

            If access = 1 Or Session("Admin") = True Then
                Me.TxtTaskCode.ReadOnly = False
                Me.TxtTaskDescription.ReadOnly = False

                'txtTempComplete.Attributes.Clear()
                'Me.txtTempComplete.ReadOnly = False
                Me.txtTempComplete.ReadOnly = True
                txtTempComplete.Attributes.Add("onkeydown", "return BlockEntry(event)")
                txtTempComplete.TabIndex = -1


                Me.TxtTaskComments.ReadOnly = False
                Me.TxtDueDateComments.ReadOnly = False
                Me.TxtRevisionDateComments.ReadOnly = False
                Me.DropTaskStatus.Visible = True
                txtTaskStatus.Visible = False
                Me.TxtTimeDue.ReadOnly = False
                Me.DropPhase.Visible = True
                txtPhase.Visible = False
                hlTaskCode.Visible = True
                aTask.Visible = False
                If oTask.s_DUE_DATE_LOCK = "0" Or oTask.s_DUE_DATE_LOCK = "" Then
                    Me.RadDatePickerDueDate.Enabled = True
                    Me.RadDatePickerStartDate.Enabled = True
                Else
                    Me.RadDatePickerDueDate.Enabled = False
                    Me.RadDatePickerStartDate.Enabled = False
                End If
                Me.RadDatePickerDateCompleted.Enabled = True

                Me.hlTaskCode.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & Me.TxtTaskCode.ClientID & "&type=task');return false;")
                'Me.hlTaskCode.Attributes.Add("onmouseup", "document.getElementById(""" & Me.TxtTaskDescription.ClientID & """).value = ''")
                'Me.TxtTaskCode.Attributes.Add("onchange", "document.getElementById(""" & Me.TxtTaskDescription.ClientID & """).value = ''")
                aContact.Visible = False
                TxtClientContacts.ReadOnly = False
                LkBtnContacts.Visible = True

            Else
                hlTaskCode.Visible = False
                aTask.Visible = True
                Me.TxtTaskCode.ReadOnly = True
                Me.TxtTaskDescription.ReadOnly = True

                Me.RadDatePickerStartDate.Enabled = False
                Me.RadDatePickerDueDate.Enabled = False
                Me.RadDatePickerDateCompleted.Enabled = False

                Me.TxtTaskComments.ReadOnly = True
                Me.TxtDueDateComments.ReadOnly = True
                Me.TxtRevisionDateComments.ReadOnly = True
                Me.DropTaskStatus.Visible = False
                txtTaskStatus.Visible = True
                Me.TxtTimeDue.ReadOnly = True
                Me.DropPhase.Visible = False
                txtPhase.Visible = True
                Me.hlTaskCode.Attributes.Clear()
                Me.hlTaskCode.Attributes.Clear()
                Me.TxtTaskCode.Attributes.Clear()
                TxtClientContacts.ReadOnly = True
                aContact.Visible = True
                LkBtnContacts.Visible = False
            End If

            Me.LoadTaskFailed = False
            Me.ErrorMessage = ""

        Catch ex As Exception

            Me.LoadTaskFailed = True
            Me.ErrorMessage = ex.Message.ToString()

        End Try
    End Sub
    Public Sub LoadJustTempDueDate()
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = Me.JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = Me.JobCompNumber
            oTask.Where.SEQ_NBR.Value = Me.SeqNum
            If oTask.Query.Load Then
                Try
                    Me.txtTempComplete.Text = oTask.TEMP_COMP_DATE
                Catch exDateTempCompDate As Exception
                    Me.txtTempComplete.Text = ""
                End Try
            End If
        Catch x As Exception

        End Try
    End Sub
    Public Sub LoadTask()
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = Me.JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = Me.JobCompNumber
            oTask.Where.SEQ_NBR.Value = Me.SeqNum
            If oTask.Query.Load Then

                If Not IsNothing(oTask.FNC_CODE) Then
                    Me.TxtTaskCode.Text = oTask.FNC_CODE
                    If Me.TxtTaskCode.Text.Trim() = "" Then
                        Me.TxtTaskDescription.Text = oTask.s_TASK_DESCRIPTION
                    Else
                        TxtTaskDescription.Text = LookupTaskCode(oTask.FNC_CODE)
                    End If
                End If
                If IsDBNull(oTask.s_TASK_START_DATE) = False And oTask.s_TASK_START_DATE <> "" Then
                    Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(oTask.TASK_START_DATE)
                Else
                    Me.RadDatePickerStartDate.SelectedDate = Nothing
                End If
                If IsDBNull(oTask.s_JOB_DUE_DATE) = False And oTask.s_JOB_DUE_DATE <> "" Then
                    If IsDBNull(oTask.s_JOB_REVISED_DATE) = False And oTask.s_JOB_REVISED_DATE <> "" Then
                        Me.RadDatePickerDueDate.SelectedDate = LoGlo.FormatDate(oTask.JOB_REVISED_DATE)
                    Else
                        Me.RadDatePickerDueDate.SelectedDate = LoGlo.FormatDate(oTask.JOB_DUE_DATE)
                    End If
                Else
                    If IsDBNull(oTask.s_JOB_REVISED_DATE) = False And oTask.s_JOB_REVISED_DATE <> "" Then
                        Me.RadDatePickerDueDate.SelectedDate = LoGlo.FormatDate(oTask.JOB_REVISED_DATE)
                    Else
                        Me.RadDatePickerDueDate.SelectedDate = Nothing
                    End If
                End If
                Try
                    'Me.txtTempComplete.Text = LoGlo.FormatDate(oTask.TEMP_COMP_DATE)
                    If IsDBNull(oTask.s_TEMP_COMP_DATE) = False And oTask.s_TEMP_COMP_DATE <> "" Then
                        Me.txtTempComplete.Text = LoGlo.FormatDate(oTask.TEMP_COMP_DATE)
                    Else
                        Me.txtTempComplete.Text = ""
                    End If
                Catch exDateTempCompDate As Exception
                    Me.txtTempComplete.Text = ""
                End Try

                ' Me.TxtOriginalDueDate.Text = oTask.s_JOB_DUE_DATE
                Try
                    ' Me.RadDatePickerDateCompleted.SelectedDate = LoGlo.FormatDate(oTask.JOB_COMPLETED_DATE)
                    If IsDBNull(oTask.s_JOB_COMPLETED_DATE) = False And oTask.s_JOB_COMPLETED_DATE <> "" Then
                        Me.RadDatePickerDateCompleted.SelectedDate = LoGlo.FormatDate(oTask.JOB_COMPLETED_DATE)
                    Else
                        Me.RadDatePickerDateCompleted.SelectedDate = Nothing
                    End If
                Catch exdate As Exception
                    Me.RadDatePickerDateCompleted.SelectedDate = ""
                End Try
                Me.TxtTaskComments.Text = oTask.s_FNC_COMMENTS
                Me.TxtDueDateComments.Text = oTask.s_DUE_DATE_COMMENTS
                Me.TxtRevisionDateComments.Text = oTask.s_REV_DATE_COMMENTS
                'If oTask.s_MILESTONE = "1" Then
                '    Me.ChkMilestone.Checked = True
                'End If
                ' Me.TxtHoursAllowed.Text = oTask.s_JOB_HRS
                ' Me.TxtDays.Text = oTask.s_JOB_DAYS
                'If oTask.s_FNC_EST <> "" Then
                '    Me.dropEstFnc.SelectedValue = oTask.s_FNC_EST
                'End If
                If Not oTask.TASK_STATUS = "" Then
                    Me.DropTaskStatus.SelectedValue = oTask.TASK_STATUS
                    txtTaskStatus.Text = DropTaskStatus.SelectedItem.Text
                End If

                ' Me.TxtOrder.Text = oTask.s_JOB_ORDER
                If IsDBNull(oTask.s_DUE_TIME) = False Then
                    Me.TxtTimeDue.Text = oTask.s_DUE_TIME
                Else
                    Me.TxtTimeDue.Text = ""
                End If
                'If oTask.s_DUE_DATE_LOCK = "0" Or oTask.s_DUE_DATE_LOCK = "" Then
                '    Me.chkLocked.Checked = False
                'Else
                '    Me.chkLocked.Checked = True
                'End If
                If oTask.s_TRAFFIC_PHASE_ID = "" Then
                    Me.DropPhase.SelectedValue = "0"
                Else
                    Dim od As New cDropDowns(Session("ConnString"))
                    Dim desc As String = od.GetTrafficPhaseDesc(oTask.TRAFFIC_PHASE_ID)
                    If Me.DropPhase.Items.Contains(New Telerik.Web.UI.RadComboBoxItem(desc, oTask.s_TRAFFIC_PHASE_ID)) = False Then
                        Me.DropPhase.Items.Add(New Telerik.Web.UI.RadComboBoxItem(desc, oTask.s_TRAFFIC_PHASE_ID))
                        Me.DropPhase.SelectedValue = oTask.s_TRAFFIC_PHASE_ID
                        txtPhase.Text = DropPhase.SelectedItem.Text
                    Else
                        Me.DropPhase.SelectedValue = oTask.s_TRAFFIC_PHASE_ID
                        txtPhase.Text = DropPhase.SelectedItem.Text
                    End If
                End If
                Dim access As Integer = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
                If access = 1 Then
                    If oTask.s_DUE_DATE_LOCK = "0" Or oTask.s_DUE_DATE_LOCK = "" Then
                        Me.RadDatePickerDueDate.Enabled = True
                        Me.RadDatePickerStartDate.Enabled = True
                    Else
                        Me.RadDatePickerDueDate.Enabled = False
                        Me.RadDatePickerStartDate.Enabled = False
                    End If
                Else
                    Me.RadDatePickerDueDate.Enabled = False
                    Me.RadDatePickerStartDate.Enabled = False
                End If

                'Now add calendars


            End If
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
        'Try
        '    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        '    Me.TxtEmployeesList.Text = s.GetTaskEmpListString(Me.JobNumber, Me.JobCompNumber, Me.SeqNum)
        'Catch ex As Exception

        'End Try
        Try
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Me.TxtClientContacts.Text = s.GetTaskContactListString(Me.JobNumber, Me.JobCompNumber, Me.SeqNum)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub LoadPhase()
        Try
            Dim oD As New cDropDowns(Session("ConnString"))
            With Me.DropPhase
                .DataSource = oD.GetTrafficPhasesAll()
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With

        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub
    Private Sub SaveTask()
        Try

        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub
    'Private Sub LoadEstimateFunctions()
    '    Try
    '        Dim d As New cDropDowns(Session("ConnString"))
    '        With Me.dropEstFnc
    '            .DataSource = d.GetEstimateFunctionsPS()
    '            .DataTextField = "description"
    '            .DataValueField = "code"
    '            .DataBind()
    '            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
    '        End With
    '    Catch ex As Exception
    '        Response.Write(ex.Message.ToString())
    '    End Try
    'End Sub


    Public Property Task_ContactList() As String
        Get
            Return Me.TxtClientContacts.Text
        End Get
        Set(ByVal value As String)
            Me.TxtClientContacts.Text = value
        End Set
    End Property

    Public Property Task_FNCode() As String
        Get
            Return Me.TxtTaskCode.Text
        End Get
        Set(ByVal value As String)
            Me.TxtTaskCode.Text = value
        End Set
    End Property

    Public Property Task_Description() As String
        Get
            Return Me.TxtTaskDescription.Text
        End Get
        Set(ByVal value As String)
            Me.TxtTaskDescription.Text = value
        End Set
    End Property

    Public Property Start_Date() As String
        Get
            If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing Then
                Return Me.RadDatePickerStartDate.SelectedDate
            End If
        End Get
        Set(ByVal value As String)
            Me.RadDatePickerStartDate.SelectedDate = value
        End Set
    End Property
    Public Property Due_Date() As String
        Get
            If Not Me.RadDatePickerDueDate.SelectedDate Is Nothing Then
                Return Me.RadDatePickerDueDate.SelectedDate
            End If
        End Get
        Set(ByVal value As String)
            Me.RadDatePickerDueDate.SelectedDate = value
        End Set
    End Property
    Public Property Time_Due() As String
        Get
            Return Me.TxtTimeDue.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtTimeDue.Text = value.Trim
        End Set
    End Property
    Public Property Function_Comments() As String
        Get
            Return Me.TxtTaskComments.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtTaskComments.Text = value.Trim
        End Set
    End Property

    Public Property Task_Status() As String
        Get
            Return Me.DropTaskStatus.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.DropTaskStatus.SelectedValue = value.Trim
        End Set
    End Property
    Public Property Phase_Field() As String
        Get
            Return Me.DropPhase.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.DropPhase.SelectedValue = value.Trim
        End Set
    End Property


    Public Property RevisionDate_Comments() As String
        Get
            Return Me.TxtRevisionDateComments.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtRevisionDateComments.Text = value.Trim
        End Set
    End Property
    Public Property Date_Completed() As String
        Get
            If Not Me.RadDatePickerDateCompleted.SelectedDate Is Nothing Then
                Return Me.RadDatePickerDateCompleted.SelectedDate
            End If
        End Get
        Set(ByVal value As String)
            Me.RadDatePickerDateCompleted.SelectedDate = value
        End Set
    End Property

    Public Property DueDate_Comments() As String
        Get
            Return Me.TxtDueDateComments.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtDueDateComments.Text = value.Trim
        End Set
    End Property
    'Public Property Start_Time() As String
    '    Get
    '        If Not Me.radTimePickerStart.SelectedDate Is Nothing Then
    '            Return Me.radTimePickerStart.SelectedDate
    '        End If
    '    End Get
    '    Set(ByVal value As String)
    '        Me.radTimePickerStart.SelectedDate = value
    '    End Set
    'End Property
    'Public Property End_Time() As String
    '    Get
    '        If Not Me.radTimePickerEnd.SelectedDate Is Nothing Then
    '            Return Me.radTimePickerEnd.SelectedDate
    '        End If
    '    End Get
    '    Set(ByVal value As String)
    '        Me.radTimePickerEnd.SelectedDate = value
    '    End Set
    'End Property

    'Private Sub TxtTaskCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTaskCode.TextChanged
    '    If Not TxtTaskCode.Text = "" Then
    '        TxtTaskDescription.Text = LookupTaskCode(TxtTaskCode.Text)
    '    Else
    '        Me.TxtTaskDescription.Text = ""
    '    End If
    'End Sub

    Private Function LookupTaskCode(ByVal sTaskCode As String) As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim sReturn As String = ""
        Dim sSQL = " SELECT     TRF_CODE as Code, ISNULL(TRF_DESC, '') as Description " & _
                   " FROM         TRAFFIC_FNC " & _
                   " WHERE ((TRF_INACTIVE IS NULL) OR TRF_INACTIVE = 0 and TRF_CODE='" + sTaskCode + "') "
        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, sSQL)
        Catch

        Finally

        End Try
        If dr.HasRows Then
            Do While dr.Read()
                If dr("Code").ToString.ToUpper.Trim = sTaskCode.ToUpper.Trim Then
                    sReturn = dr("Description").ToString
                End If
            Loop
        End If

        Return sReturn

    End Function
End Class