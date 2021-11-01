Public Partial Class TrafficSchedule_TaskSettings2
    Inherits Webvantage.BaseChildPageUserControl

    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public Client As String = ""
    Public Division As String = ""
    Public Product As String = ""

    Public Property Order_Field() As String
        Get
            Return Me.TxtOrder.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtOrder.Text = value.Trim
        End Set
    End Property
    Public Property Hours_Allowed() As String
        Get
            Return Me.TxtHoursAllowed.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtHoursAllowed.Text = value.Trim
        End Set
    End Property
    Public Property Original_Hours_Allowed() As String
        Get
            Return Me.HiddenFieldHoursAllowed.Value
        End Get
        Set(ByVal value As String)
            Me.HiddenFieldHoursAllowed.Value = value.Trim
        End Set
    End Property
    Public Property Milestone_Field() As String
        Get
            Return Me.ChkMilestone.Checked
        End Get
        Set(ByVal value As String)
            Me.ChkMilestone.Checked = value.Trim
        End Set
    End Property
    Public Property Days_Field() As String
        Get
            Return Me.TxtDays.Text.Trim
        End Get
        Set(ByVal value As String)
            Me.TxtDays.Text = value.Trim
        End Set
    End Property
    Public Property Estimate_Function() As String
        Get
            Return Me.DropEstFnc.SelectedValue
        End Get
        Set(ByVal value As String)
            Me.DropEstFnc.SelectedValue = value.Trim
        End Set
    End Property
    Public Property OriginalDue_Date() As String
        Get
            If Not Me.RadDatePickerOriginalDueDate.SelectedDate Is Nothing Then
                Return Me.RadDatePickerOriginalDueDate.SelectedDate
            End If
        End Get
        Set(ByVal value As String)
            Me.RadDatePickerOriginalDueDate.SelectedDate = value
        End Set
    End Property
    Public Property Locked_Field() As String
        Get
            Return Me.ChkLocked.Checked
        End Get
        Set(ByVal value As String)
            Me.ChkLocked.Checked = value.Trim
        End Set
    End Property
    Private CurrentQueryString As New AdvantageFramework.Web.QueryString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.JobNumber = Request.QueryString("JobNum")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNum")
            Me.Client = Request.QueryString("Client")
            Me.Division = Request.QueryString("Division")
            Me.Product = Request.QueryString("Product")

            CurrentQueryString = CurrentQueryString.FromCurrent

            If Me.CurrentQueryString.JobNumber > 0 Then Me.JobNumber = Me.CurrentQueryString.JobNumber
            If Me.CurrentQueryString.JobComponentNumber > 0 Then Me.JobCompNumber = Me.CurrentQueryString.JobComponentNumber
            If Me.CurrentQueryString.TaskSequenceNumber > 0 Then Me.SeqNum = Me.CurrentQueryString.TaskSequenceNumber
            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.ClientCode) = False Then Me.Client = Me.CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.DivisionCode) = False Then Me.Division = Me.CurrentQueryString.DivisionCode
            If String.IsNullOrWhiteSpace(Me.CurrentQueryString.ProductCode) = False Then Me.Client = Me.CurrentQueryString.ProductCode

            If Not Me.IsPostBack Then
                LoadEstimateFunctions()
                LoadTaskData(JobNumber, JobCompNumber, SeqNum)
            End If
            CheckPageSecurity()
        Catch ex As Exception
            Response.Write("Error in TrafficSchedule_TaskSettings2:Page_Load " & ex.Message.ToString())
        End Try
    End Sub
    Private Sub CheckPageSecurity()
        Dim access As Integer = Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))

        If access = 1 Then
            Me.RadDatePickerOriginalDueDate.Enabled = True
            Me.ChkMilestone.Visible = True
            Me.txtMileStone.Visible = False
            Me.TxtHoursAllowed.ReadOnly = False
            Me.TxtDays.ReadOnly = False
            Me.dropEstFnc.Visible = True
            Me.txtEstFnc.Visible = False
            Me.TxtOrder.ReadOnly = False
            Me.ChkLocked.Visible = True
            Me.txtLocked.Visible = False
        Else
            Me.RadDatePickerOriginalDueDate.Enabled = False
            ' Me.ChkMilestone.Visible = False
            'Me.txtMileStone.Visible = True
            ChkMilestone.Visible = True
            txtMileStone.Visible = False
            Me.TxtHoursAllowed.ReadOnly = True
            Me.TxtDays.ReadOnly = True
            Me.dropEstFnc.Visible = False
            Me.txtEstFnc.Visible = True
            Me.TxtOrder.ReadOnly = True
            ChkLocked.Visible = True
            txtLocked.Visible = False
            'Me.ChkLocked.Visible = False
            'txtLocked.Visible = True
            ChkLocked.Enabled = False
            ChkMilestone.Enabled = False
        End If
    End Sub
    Public Sub LoadTaskData(ByVal JobNumberinput As Integer, ByVal JobCompNumberinput As Integer, ByVal SeqNuminput As Integer)
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = JobNumberinput
            oTask.Where.JOB_COMPONENT_NBR.Value = JobCompNumberinput
            oTask.Where.SEQ_NBR.Value = SeqNuminput
            If oTask.Query.Load Then
                If IsDBNull(oTask.s_JOB_DUE_DATE) = False And oTask.s_JOB_DUE_DATE <> "" Then
                    Me.RadDatePickerOriginalDueDate.SelectedDate = CDate(oTask.JOB_DUE_DATE)
                Else
                    Me.RadDatePickerOriginalDueDate.SelectedDate = Nothing
                End If
                If oTask.s_MILESTONE = "1" Then
                    Me.ChkMilestone.Checked = True
                    Me.txtMileStone.Text = "Yes"
                Else
                    ChkMilestone.Checked = False
                    txtMileStone.Text = "No"
                End If
                Me.TxtHoursAllowed.Text = oTask.s_JOB_HRS
                Me.HiddenFieldHoursAllowed.Value = oTask.s_JOB_HRS
                Me.TxtDays.Text = oTask.s_JOB_DAYS
                If oTask.s_FNC_EST <> "" Then
                    Me.dropEstFnc.SelectedValue = oTask.s_FNC_EST
                    Me.txtEstFnc.Text = dropEstFnc.SelectedItem.Text
                Else
                    txtEstFnc.Text = ""
                End If
                Me.TxtOrder.Text = oTask.s_JOB_ORDER
                If oTask.s_DUE_DATE_LOCK = "0" Or oTask.s_DUE_DATE_LOCK = "" Then
                    Me.ChkLocked.Checked = False
                    txtLocked.Text = "No"
                Else
                    Me.ChkLocked.Checked = True
                    txtLocked.Text = "Yes"
                End If
            End If


        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try


    End Sub
    Private Sub LoadEstimateFunctions()
        Dim DataTable As System.Data.DataTable = Nothing
        Dim DataRow As System.Data.DataRow = Nothing
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            DataTable = d.GetEstimateFunctionsPS()
            DataTable.DefaultView.Sort = "Description ASC"
            DataTable = DataTable.DefaultView.ToTable
            DataRow = DataTable.NewRow
            DataRow("Code") = ""
            DataRow("Description") = "[None]"
            DataTable.Rows.InsertAt(DataRow, 0)
            With Me.dropEstFnc
                .DataSource = DataTable.DefaultView.ToTable
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try
    End Sub
End Class