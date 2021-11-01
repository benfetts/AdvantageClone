Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing

Partial Public Class TrafficSchedule_TaskPrint
    Inherits Webvantage.BaseChildPage

    Private _RowCount As Integer = 0
    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public dHoursAllowedTotal As Double = 0
    Public dHoursPostedTotal As Double = 0
    Public dQuotedHoursTotal As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not IsPostBack Then
            Me.Page.Title = "Task Detail Report"
            Session("ShowQuotedHours") = False
            Me.JobNumber = Request.QueryString("JobNum")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNum")
            If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
            If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobCompNumber = Me.CurrentQuerystring.JobComponentNumber
            If Me.CurrentQuerystring.TaskSequenceNumber > 0 Then Me.SeqNum = Me.CurrentQuerystring.TaskSequenceNumber
            Session("JobNumber") = JobNumber
            Session("JobCompNumber") = JobCompNumber
            Session("SeqNum") = SeqNum

            LoadPhase()
            LoadEstimateFunctions()
            LoadTask()
            LoadTaskData(JobNumber, JobCompNumber, SeqNum)
            GetPageData(JobNumber, JobCompNumber)
            LoadEmployee()
        Else

        End If
    End Sub
#Region "ClientJobInfo"
    Public Sub GetPageData(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer)
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, JobComponentNumber, Session("UserCode").ToString(), False).Tables(0)
        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("CL_CODE")) = False And IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                Me.lblClient.Text = "(" + dt.Rows(0)("CL_CODE") + ") " + dt.Rows(0)("CL_NAME")
            End If
            If IsDBNull(dt.Rows(0)("DIV_CODE")) = False And IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                Me.lblDivision.Text = "(" + dt.Rows(0)("DIV_CODE") + ") " + dt.Rows(0)("DIV_NAME")
            End If
            If IsDBNull(dt.Rows(0)("PRD_CODE")) = False And IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                Me.lblProduct.Text = "(" + dt.Rows(0)("PRD_CODE") + ") " + dt.Rows(0)("PRD_DESCRIPTION")
            End If
            If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False And IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                ' _JobNum = CInt(dt.Rows(0)("JOB_NUMBER"))
                Me.lblJob.Text = "(" + dt.Rows(0)("JOB_NUMBER").ToString() + ") " + dt.Rows(0)("JOB_DESC")
            End If
            If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False And IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                Me.lblJobComp.Text = "(" + dt.Rows(0)("JOB_COMPONENT_NBR").ToString() + ") " + dt.Rows(0)("JOB_COMP_DESC")
            End If
            If IsDBNull(dt.Rows(0)("TRF_DESC")) = False Then
                'Me.TxtTrafficStatusDescription.Text = ""
                Me.lblJobStatus.Text = dt.Rows(0)("TRF_DESC")
                Me.lblJobStatus.Text = "(" + dt.Rows(0)("TRF_CODE") + ") " + dt.Rows(0)("TRF_DESC")
            End If
            If IsDBNull(dt.Rows(0)("Comments")) = False Then
                Me.lblJobComments.Text = dt.Rows(0)("Comments")
            End If
            If IsDBNull(dt.Rows(0)("START_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("START_DATE")) = True Then
                    Me.lblJobStartDate.Text = String.Format("{0:d}", CDate(dt.Rows(0)("START_DATE")))
                Else
                    Me.lblJobStartDate.Text = ""
                End If
            Else
                Me.lblJobStartDate.Text = ""
            End If
            If Me.lblJobStartDate.Text = "1/1/1900" Then
                Me.lblJobStartDate.Text = ""
            End If
            If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                If cGlobals.wvIsDate(dt.Rows(0)("JOB_FIRST_USE_DATE")) = True Then
                    ' Me.lblJobDueDate.Text = cGlobals.wvCDate(dt.Rows(0)("JOB_FIRST_USE_DATE")).ToShortDateString
                    Me.lblJobDueDate.Text = String.Format("{0:d}", CDate(dt.Rows(0)("JOB_FIRST_USE_DATE")))
                Else
                    Me.lblJobDueDate.Text = ""
                End If
            Else
                Me.lblJobDueDate.Text = ""
            End If
            If Me.lblJobDueDate.Text = "1/1/1900" Then
                Me.lblJobDueDate.Text = ""
            End If
            Dim AECode As String
            Dim AEDesc As String
            If IsDBNull(dt.Rows(0)("EMP_CODE_AE")) = False Then
                AECode = dt.Rows(0)("EMP_CODE_AE")
            Else
                AECode = ""
            End If
            If IsDBNull(dt.Rows(0)("AE_NAME")) = False Then
                AEDesc = dt.Rows(0)("AE_NAME")
            Else
                AEDesc = ""
            End If
            lblAE.Text = "(" + AECode + ") " + AEDesc

        End If
    End Sub
#End Region
#Region "TaskDetail"
    Public Sub LoadTask()
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = Me.JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = Me.JobCompNumber
            oTask.Where.SEQ_NBR.Value = Me.SeqNum
            If oTask.Query.Load Then

                If Not IsNothing(oTask.FNC_CODE) Then
                    Me.TxtTaskCode.Text = oTask.FNC_CODE
                    TxtTaskDescription.Text = LookupTaskCode(oTask.FNC_CODE)
                End If
                'Me.TxtTaskDescription.Text = oTask.s_TASK_DESCRIPTION
                If IsDBNull(oTask.s_TASK_START_DATE) = False And oTask.s_TASK_START_DATE <> "" Then
                    Me.TxtStartDate.Text = LoGlo.FormatDate(oTask.s_TASK_START_DATE)
                Else
                    Me.TxtStartDate.Text = ""
                End If
                If IsDBNull(oTask.s_JOB_DUE_DATE) = False And oTask.s_JOB_DUE_DATE <> "" Then
                    If IsDBNull(oTask.s_JOB_REVISED_DATE) = False And oTask.s_JOB_REVISED_DATE <> "" Then
                        Me.TxtDueDate.Text = LoGlo.FormatDate(oTask.s_JOB_REVISED_DATE)
                    Else
                        Me.TxtDueDate.Text = LoGlo.FormatDate(oTask.s_JOB_DUE_DATE)
                    End If
                Else
                    If IsDBNull(oTask.s_JOB_REVISED_DATE) = False And oTask.s_JOB_REVISED_DATE <> "" Then
                        Me.TxtDueDate.Text = LoGlo.FormatDate(oTask.JOB_REVISED_DATE)
                    Else
                        Me.TxtDueDate.Text = ""
                    End If

                End If
                Try
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
                    If IsDBNull(oTask.s_JOB_COMPLETED_DATE) = False And oTask.s_JOB_COMPLETED_DATE <> "" Then
                        Me.TxtDateCompleted.Text = LoGlo.FormatDate(oTask.s_JOB_COMPLETED_DATE)
                    Else
                        Me.TxtDateCompleted.Text = Nothing
                    End If
                Catch exdate As Exception
                    Me.TxtDateCompleted.Text = ""
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
                    Me.DropPhase.SelectedValue = oTask.s_TRAFFIC_PHASE_ID
                    txtPhase.Text = DropPhase.SelectedItem.Text
                End If
                Dim access As Integer = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit).Any(Function(SettingValue) SettingValue = True))
                If oTask.s_DUE_DATE_LOCK = "0" Or oTask.s_DUE_DATE_LOCK = "" Then

                    If access = 1 Then

                        Me.TxtDueDate.ReadOnly = False
                        Me.TxtStartDate.ReadOnly = False

                        Me.TxtDueDate.Enabled = True
                        Me.TxtStartDate.Enabled = True

                    Else

                        Me.TxtDueDate.ReadOnly = True
                        Me.TxtStartDate.ReadOnly = True

                        Me.TxtDueDate.Enabled = False
                        Me.TxtStartDate.Enabled = False

                    End If

                Else

                    If access = 1 Then

                        Me.TxtDueDate.ReadOnly = False
                        Me.TxtStartDate.ReadOnly = False

                        Me.TxtDueDate.Enabled = True
                        Me.TxtStartDate.Enabled = True

                    Else

                        Me.TxtDueDate.ReadOnly = True
                        Me.TxtStartDate.ReadOnly = True

                        Me.TxtDueDate.Enabled = False
                        Me.TxtStartDate.Enabled = False

                    End If

                End If
                'Now add calendars


            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
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
    Public Sub LoadJustTempDueDate()
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = Me.JobNumber
            oTask.Where.JOB_COMPONENT_NBR.Value = Me.JobCompNumber
            oTask.Where.SEQ_NBR.Value = Me.SeqNum
            If oTask.Query.Load Then
                Try
                    Me.txtTempComplete.Text = LoGlo.FormatDate(oTask.TEMP_COMP_DATE)
                Catch exDateTempCompDate As Exception
                    Me.txtTempComplete.Text = ""
                End Try
            End If
        Catch x As Exception

        End Try
    End Sub
    Public Sub LoadTaskData(ByVal JobNumberinput As Integer, ByVal JobCompNumberinput As Integer, ByVal SeqNuminput As Integer)
        Try
            Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
            oTask.Where.JOB_NUMBER.Value = JobNumberinput
            oTask.Where.JOB_COMPONENT_NBR.Value = JobCompNumberinput
            oTask.Where.SEQ_NBR.Value = SeqNuminput
            If oTask.Query.Load Then
                If IsDBNull(oTask.s_JOB_DUE_DATE) = False And oTask.s_JOB_DUE_DATE <> "" Then
                    Me.TxtOriginalDueDate.Text = LoGlo.FormatDate(oTask.JOB_DUE_DATE)
                End If
                If oTask.s_MILESTONE = "1" Then
                    Me.ChkMilestone.Checked = True
                    Me.txtMileStone.Text = "Yes"
                Else
                    ChkMilestone.Checked = False
                    txtMileStone.Text = "No"
                End If
                Me.TxtHoursAllowed.Text = oTask.s_JOB_HRS
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
            Me.ShowMessage(ex.Message.ToString())
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
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
    Private Function LookupTaskCode(ByVal sTaskCode As String) As String
        Dim oSQL As SqlHelper
        Dim dr As SqlDataReader
        Dim sReturn As String = ""
        Dim sSQL = " SELECT     TRF_CODE as Code, TRF_CODE+ISNULL(' - '+TRF_DESC, '') as Description " & _
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
    Private Sub LoadEstimateFunctions()
        Try
            Dim d As New cDropDowns(Session("ConnString"))
            With Me.dropEstFnc
                .DataSource = d.GetEstimateFunctionsPS()
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "[None]"))
            End With
        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub
#End Region

#Region "Employee Grid"
    Public ReadOnly Property EmployeeDataSource() As DataTable
        Get
            Try
                Dim oNewDT As New DataTable
                Dim dc As New DataColumn("iSortItem", System.Type.GetType("System.Int32"))
                dc.DefaultValue = 1
                dc.AllowDBNull = False
                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                oNewDT = s.GetTaskEmpList(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))
                oNewDT.Columns.Add(dc)

                'perform sort
                For Each d As DataRow In oNewDT.Rows
                    If d.Item("EMP_CODE").ToString() = CStr(Session("EmpCode")) Then
                        d.Item("iSortItem") = 0
                    End If
                Next
                oNewDT.DefaultView.Sort = "iSortItem ASC,EMP_CODE ASC"

                _RowCount = oNewDT.Rows.Count
                Return oNewDT
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property

    Public Sub RefreshEmployeeGrid()
        LoadEmployee()
        Me.RadGridEmployees.DataSource = Me.EmployeeDataSource
        Me.RadGridEmployees.DataBind()
    End Sub

    Public Sub LoadEmployee()
        Try
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            'Me.TxtEmployeesList.Text = s.GetTaskEmpListString(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))

        Catch ex As Exception

        End Try
    End Sub


    Private Sub RadGridEmployees_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEmployees.ItemDataBound

        If Not IsNothing(Session("ShowQuotedHours")) Then
            Dim ColHoursQuoted As Telerik.Web.UI.GridColumn
            ColHoursQuoted = Me.RadGridEmployees.MasterTableView.Columns.FindByUniqueName("QuotedHours")
            If Session("ShowQuotedHours") = True Then
                ColHoursQuoted.Visible = True
            Else
                ColHoursQuoted.Visible = False
            End If
        End If

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            Dim olblEmpCode As System.Web.UI.WebControls.Label = e.Item.Cells(0).Controls(0).FindControl("lblEmpCode")
            If olblEmpCode.Text = CStr(Session("EmpCode")) Then
                e.Item.BackColor = Color.LightBlue
            Else
                Dim otxtPercentComplete As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtPercentComplete")
                Dim otxtCompletedDate As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtCompleted")
                Dim otxtCompltedComment As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtCompletedComment")
                'imgbtnShowComments
                Dim oimgbtnShowComments As System.Web.UI.WebControls.ImageButton = e.Item.Cells(0).Controls(0).FindControl("ImageButtonShowComments")

                otxtCompletedDate.Wrap = True
                otxtCompletedDate.BorderStyle = BorderStyle.None
                otxtCompletedDate.Attributes.Clear()
                otxtCompletedDate.BorderWidth = 0
                otxtCompletedDate.ReadOnly = True
                otxtCompletedDate.TabIndex = -1

                otxtCompltedComment.Wrap = True
                otxtCompltedComment.Rows = 2
                otxtCompltedComment.TextMode = TextBoxMode.MultiLine
                otxtCompltedComment.BorderStyle = BorderStyle.None
                otxtCompltedComment.BorderWidth = 0
                otxtCompltedComment.ReadOnly = True
                otxtCompltedComment.TabIndex = -1

                otxtPercentComplete.Wrap = True
                otxtPercentComplete.ReadOnly = True
                otxtPercentComplete.BorderStyle = BorderStyle.None
                otxtPercentComplete.BorderWidth = 0
                otxtPercentComplete.TabIndex = -1
                oimgbtnShowComments.Visible = False

            End If

            Dim olblQuotedHours As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtQuotedHours")
            If Not IsNothing(olblQuotedHours) Then
                olblQuotedHours.Text = String.Format("{0:0.00}", CDbl(GetQuotedHours(Session("JobNumber"), Session("JobCompNumber"), GetFNCCode, olblEmpCode.Text).ToString()))
                If IsNumeric(olblQuotedHours.Text) Then
                    dQuotedHoursTotal += CDbl(olblQuotedHours.Text)
                End If
            End If


            Dim olblHoursAllowed As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtHoursAllowedGrid")
            If Not IsNothing(olblHoursAllowed) Then
                If IsNumeric(olblHoursAllowed.Text) Then
                    dHoursAllowedTotal += CDbl(olblHoursAllowed.Text)
                End If
            End If
            'GetHoursPosted
            Dim olblHoursPosted As System.Web.UI.WebControls.TextBox = e.Item.Cells(0).Controls(0).FindControl("txtHoursPosted")
            If Not IsNothing(olblHoursPosted) Then
                olblHoursPosted.Text = String.Format("{0:0.00}", CDbl(GetHoursPosted(Session("JobNumber"), Session("JobCompNumber"), GetFNCCode, olblEmpCode.Text).ToString()))
                If IsNumeric(olblHoursPosted.Text) Then
                    dHoursPostedTotal += CDbl(olblHoursPosted.Text)
                End If
            End If

        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Header Then
            e.Item.BackColor = Color.LightGoldenrodYellow
        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Footer Then
            Dim olblHoursAllowedTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblHoursAllowedTotal")
            Dim olblHoursPostedTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblHoursPostedTotal")
            Dim olblQuotedHoursTotal As System.Web.UI.WebControls.Label = e.Item.Cells(0).FindControl("lblQuotedHoursTotal")
            olblHoursAllowedTotal.Text = String.Format("{0:0.00}", CDbl(dHoursAllowedTotal.ToString()))
            olblHoursPostedTotal.Text = String.Format("{0:0.00}", CDbl(dHoursPostedTotal.ToString()))
            olblQuotedHoursTotal.Text = String.Format("{0:0.00}", CDbl(dQuotedHoursTotal.ToString()))

            ' e.Item.BackColor = Color.LightGoldenrodYellow
        End If
    End Sub
    Public Function GetHoursPosted(ByVal iJob As Integer, ByVal iJobComp As Integer, ByVal sFNCCode As String, ByVal sEmpCode As String) As Double
        'lblHoursPosted
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim oHours As DataTable
        Dim dblReturn As Double = 0
        Try
            oHours = s.GetScheduleHoursPosted(iJob, iJobComp, sFNCCode, sEmpCode)
            If Not IsNothing(oHours) Then
                If oHours.Rows.Count > 0 Then
                    dblReturn = oHours.Rows(0).Item("SumOfEMP_HOURS")
                End If
            End If

        Catch x As Exception

        End Try
        Return dblReturn
    End Function
    Public Function GetQuotedHours(ByVal iJob As Integer, ByVal iJobComp As Integer, ByVal sFNCCode As String, ByVal sEmpCode As String) As Double
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim oHours As DataTable
        Dim dblReturn As Double = 0
        Try
            oHours = s.GetScheduleQuotedHours(iJob, iJobComp, sFNCCode, sEmpCode)
            If Not IsNothing(oHours) Then
                If oHours.Rows.Count > 0 Then
                    dblReturn = oHours.Rows(0).Item("SumOfEst_Ref_Quantity")
                End If
            End If

        Catch x As Exception

        End Try
        Return dblReturn
    End Function
    Private Function GetFNCCode() As String

        Dim oTask As New JOB_TRAFFIC_DET(Session("ConnString"))
        oTask.Where.JOB_NUMBER.Value = Session("JobNumber")
        oTask.Where.JOB_COMPONENT_NBR.Value = Session("JobCompNumber")
        oTask.Where.SEQ_NBR.Value = Session("SeqNum")
        If oTask.Query.Load Then
            Return oTask.FNC_EST
        End If
        Return ""
    End Function
    Protected Sub RadGridEmployees_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEmployees.NeedDataSource
        Try
            Me.RadGridEmployees.DataSource = EmployeeDataSource
        Catch ex As Exception
        End Try
    End Sub
#End Region
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function

#Region "Comment Grid"
    '*****************************comment grid **************************8
    Public ReadOnly Property CommentDataSource() As DataTable
        Get
            Try
                Dim res As Object = Me.Session("_dsComments")
                If res Is Nothing Then
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Session("_dsComments") = s.GetTrafficDetComments(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))
                End If

                Dim dt As DataTable = DirectCast(Me.Session("_dsComments"), DataTable)
                _RowCount = dt.Rows.Count
                Return dt
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property
    Public Sub RadGridComments_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComments.NeedDataSource
        Try
            Me.Session("_dsComments") = Nothing
            Me.RadGridComments.DataSource = CommentDataSource
        Catch ex As Exception

        End Try
    End Sub
    '*****************************end Comment Grid************************
#End Region


End Class