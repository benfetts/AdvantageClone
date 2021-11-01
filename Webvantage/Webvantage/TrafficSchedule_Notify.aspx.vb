Imports Webvantage.cGlobals
Imports System.IO

Partial Public Class TrafficSchedule_Notify
    Inherits Webvantage.BaseChildPage
    Private CancelScript As String = "javascript:CallFunctionOnParentPage('HidePopUpWindows');return false;"
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private DtDefaultGroup As New DataTable
    Private id As String = ""
    Private arID() As String
    Private CurrentJC As String = ""

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Dim m As New DocumentRepository("", True)
            If m.IsRepositoryLimitFeatureEnabled = True Then

                m.SetRadAsyncUpload(Me.RadUploadTrafficScheduleNotify)

            End If

        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack = True Then
            Try
                If Not Request.QueryString("id") = Nothing Then
                    id = Request.QueryString("id")
                    Me.HFIDString.Value = id
                Else
                    id = ""
                End If
            Catch ex As Exception
                id = ""
            End Try
            Me.LinkDropDownList.Visible = False
        Else
            ViewState("EmpCodesTextBox") = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes()
        End If
        If Not ViewState("EmpCodesTextBox") Is Nothing Then
            Me.AutoCompleteRecipients.AddEntries(ViewState("EmpCodesTextBox").ToString())
        End If

        If Me.HFIDString.Value <> "" Then
            Me.arID = Me.HFIDString.Value.ToString().Split("|")
            'hide skip button on single job
            If Me.arID.Length > 1 Then
                If arID(1).IndexOf(",") > 0 Then
                    Me.BtnSkip.Visible = True
                Else
                    Me.BtnSkip.Visible = False
                End If
            End If
            If Me.arID.Length > 0 Then
                CurrentJC = arID(0)
                Dim ar() As String
                ar = CurrentJC.Split(",")
                If ar.Length > 0 Then
                    Session("SchedJobNumber") = ar(0)
                    Session("SchedJobComponentNumber") = ar(1)
                End If
            End If
            'Else
            '    CloseAndRefresh()
        End If

        Try
            JobNum = CType(Session("SchedJobNumber"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Session("SchedJobComponentNumber"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try

        If Not Me.IsPostBack Then
            ' Me.DropEmailGroups.Enabled = False
            Me.AddRecipientsButton.Enabled = False
            ' Me.BindEmailGroups()
            If JobNum > 0 And JobComp > 0 Then
                Me.FillDefaultGroupDT()
                'just get the default group
                'Dim DefGrp As String = ""
                'Try
                '    DefGrp = DtDefaultGroup.Rows(0)("EMAIL_GR_CODE")
                'Catch ex As Exception
                '    DefGrp = ""
                'End Try
                'If DefGrp <> "" Then
                '    MiscFN.RadComboBoxSetIndex(Me.DropEmailGroups, DefGrp, False)
                'End If

                'pre-select notify emps (same code as radiocheck)
                Me.RadioNotifyEmployeesTask.Checked = True
                ' Me.DropEmailGroups.Enabled = False
                'AddRecipientsButton.Enabled = False
                Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                Dim dt As New DataTable
                dt = s.NotifyGetEmailGroup(JobNum, JobComp, "", True)
                Try
                    Dim str As String = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        str &= dt.Rows(i)("EMP_CODE") & ","
                    Next
                    str = MiscFN.RemoveDuplicatesFromString(str, ",")
                    str = MiscFN.RemoveTrailingDelimiter(str, ",")
                    Me.AutoCompleteRecipients.AddEntries(str)
                Catch ex As Exception
                    Me.ShowError(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
                End Try

                'Subject:
                Dim jd As String = ""
                Dim jcd As String = ""
                Dim clcode As String = ""
                GetScheduleHeader(JobNum, JobComp, jd, jcd, clcode)
                Me.TxtSubject.Text = SubjectLine(JobNum, JobComp, jd, jcd, clcode)
            End If
        End If
    End Sub

    Private Sub AddRecipientsButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddRecipientsButton.Click
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        DtDefaultGroup = s.NotifyGetEmailGroup(JobNum, JobComp, "", False)
        Dim DefGrp As String = ""
        Try
            DefGrp = DtDefaultGroup.Rows(0)("EMAIL_GR_CODE")
        Catch ex As Exception
            DefGrp = ""
        End Try

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs.Page = "LookUp_Recipients.aspx"
        qs.JobNumber = Me.JobNum
        qs.JobComponentNbr = Me.JobComp
        qs.EmailGroup = DefGrp
        qs.Add("ag", "1")
        qs.Add("uac", "1")
        Me.OpenLookUpRecipients(qs.ToString(True))

    End Sub
   
    Private Function SubjectLine(ByVal JobNum As Integer, ByVal JobCompNum As Integer, ByVal JobDescript As String, ByVal JobCompDescript As String, ByVal clcode As String) As String
        Return "Project Schedule Updated! Job/Comp " & JobNum.ToString.PadLeft(6, "0") & "-" & JobCompNum.ToString.PadLeft(2, "0") & " - " & JobCompDescript & " for client " & clcode & " by " & Session("EmployeeName")
    End Function

    Private Function GetScheduleHeader(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer, ByRef JobDescript As String, ByRef JobCompDescript As String, ByRef clcode As String) As String
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        Try
            Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(JobNumber, JobComponentNumber, Session("UserCode").ToString(), False).Tables(0)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                    JobDescript = dt.Rows(0)("JOB_DESC")
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                    JobCompDescript = dt.Rows(0)("JOB_COMP_DESC")
                End If
                If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                    clcode = dt.Rows(0)("CL_CODE")
                End If
            End If
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString
        End Try
    End Function

    Private Sub FillDefaultGroupDT()
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        DtDefaultGroup = s.NotifyGetEmailGroup(JobNum, JobComp, "", False)
        Try
            Dim str As String = ""
            For i As Integer = 0 To DtDefaultGroup.Rows.Count - 1
                str &= DtDefaultGroup.Rows(i)("EMP_CODE") & ","
            Next
            str = MiscFN.RemoveDuplicatesFromString(str, ",")
            str = MiscFN.RemoveTrailingDelimiter(str, ",")
            Me.HFDefaultGroupString.Value = str
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioSendToGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioSendToGroup.CheckedChanged
        If Me.RadioSendToGroup.Checked = True Then
            'Me.DropEmailGroups.Enabled = True


            FillDefaultGroupDT()
            'Dim DefGrp As String = ""
            'Try
            '    DefGrp = DtDefaultGroup.Rows(0)("EMAIL_GR_CODE")
            'Catch ex As Exception
            '    DefGrp = ""
            'End Try
            'If DefGrp <> "" Then
            '    MiscFN.RadComboBoxSetIndex(Me.DropEmailGroups, DefGrp, False)
            'End If 
            AddRecipientsButton.Enabled = True
            Me.AutoCompleteRecipients.AddEntries(Me.HFDefaultGroupString.Value)
        End If
    End Sub

    Private Sub RadioNotifyEmployeesALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyEmployeesAll.CheckedChanged
        Dim str As String = ""
        Try
            JobNum = CType(Session("SchedJobNumber"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Session("SchedJobComponentNumber"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        If Me.RadioNotifyEmployeesAll.Checked = True Then
            Me.AutoCompleteRecipients.Clear()
            'Me.DropEmailGroups.Enabled = False
            AddRecipientsButton.Enabled = False
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            dt = s.NotifyGetEmailGroup(JobNum, JobComp, "", True)
            Try

                For i As Integer = 0 To dt.Rows.Count - 1
                    str &= dt.Rows(i)("EMP_CODE") & ","
                Next
                ' str = MiscFN.RemoveDuplicatesFromString(str, ",")
                ' str = MiscFN.RemoveTrailingDelimiter(str, ",")

            Catch ex As Exception
                Me.ShowError(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
            End Try

            'check assignments...
            Dim dt2 As DataTable = s.GetScheduleHeader(JobNum, JobComp, Session("UserCode").ToString(), False).Tables(0)
            If dt2.Rows.Count > 0 Then
                If Not dt2.Rows(0)("ASSIGN_1").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_1") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_2").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_2") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_3").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_3") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_4").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_4") & ","
                End If
                If Not dt2.Rows(0)("ASSIGN_5").ToString.Trim = "" Then
                    str &= dt2.Rows(0)("ASSIGN_5") & ","
                End If
                If IsDBNull(dt2.Rows(0)("EMP_CODE_AE")) = False Then
                    str &= dt2.Rows(0)("EMP_CODE_AE") & ","
                End If
            End If
            str = MiscFN.RemoveDuplicatesFromString(str, ",")
            str = MiscFN.RemoveTrailingDelimiter(str, ",")
            Me.AutoCompleteRecipients.AddEntries(str)
        End If

    End Sub

    Private Sub RadioNotifyEmployeesTask_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyEmployeesTask.CheckedChanged
        Try
            JobNum = CType(Session("SchedJobNumber"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Session("SchedJobComponentNumber"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        If Me.RadioNotifyEmployeesTask.Checked = True Then
            Me.AutoCompleteRecipients.Clear()
            'Me.DropEmailGroups.Enabled = False
            AddRecipientsButton.Enabled = False
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            dt = s.NotifyGetEmailGroup(JobNum, JobComp, "", True)
            Try
                Dim str As String = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    str &= dt.Rows(i)("EMP_CODE") & ","
                Next
                str = MiscFN.RemoveDuplicatesFromString(str, ",")
                str = MiscFN.RemoveTrailingDelimiter(str, ",")
                Me.AutoCompleteRecipients.AddEntries(str)
            Catch ex As Exception
                Me.ShowError(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))
            End Try
        End If
    End Sub

    Private Sub RadioNotifyNext_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioNotifyNext.CheckedChanged
        Try
            JobNum = CType(Session("SchedJobNumber"), Integer)
        Catch ex As Exception
            JobNum = 0
        End Try
        Try
            JobComp = CType(Session("SchedJobComponentNumber"), Integer)
        Catch ex As Exception
            JobComp = 0
        End Try
        If Me.RadioNotifyNext.Checked = True Then
            Me.AutoCompleteRecipients.Clear()
            'Me.DropEmailGroups.Enabled = False
            AddRecipientsButton.Enabled = False
            Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
            Me.AutoCompleteRecipients.AddEntries(s.NotifyGetNextEmployeesList(JobNum, JobComp))
        End If
    End Sub

    Private Sub BodyHeader(ByRef TheBody As AdvantageFramework.Email.HtmlEmail, ByVal EmpName As String, ByVal CustomMessage As String, ByVal TheClient As String, _
                                ByVal TheDivision As String, ByVal TheProduct As String, ByVal TheJob As String, ByVal TheComponent As String, _
                                ByVal TheStartDate As String, ByVal TheDueDate As String, ByVal TheStatus As String)
        If cGlobals.wvIsDate(TheStartDate) = True Then
            TheStartDate = cGlobals.wvCDate(TheStartDate).ToShortDateString
        End If
        If cGlobals.wvIsDate(TheDueDate) = True Then
            TheDueDate = cGlobals.wvCDate(TheDueDate).ToShortDateString
        End If
        With TheBody
            If EmpName.Trim() <> "" Then
                .AddCustomRow(EmpName & ",")
            End If
            If CustomMessage.Trim() <> "" Then
                .AddCustomRow(CustomMessage)
                .AddBlankRow()
            End If

            .AddHeaderRow("Project Schedule Update")
            .AddKeyValueRow("Client", TheClient)
            .AddKeyValueRow("Division", TheDivision)
            .AddKeyValueRow("Product", TheProduct)
            .AddKeyValueRow("Job", TheJob)
            .AddKeyValueRow("Component", TheComponent)
            .AddKeyValueRow("Start Date", TheStartDate)
            .AddKeyValueRow("Due Date", TheDueDate)
            .AddKeyValueRow("Status", TheStatus)
        End With

    End Sub

    Private Function BodyTasks(ByVal JNum As Integer, ByVal JCNum As Integer) As String
        Dim BoolNextDueMarked As Boolean = False
        Dim NextDueFontStyle As String = ""  ' = " color=""#FF0000"""
        Dim BoolAlternate As Boolean = False
        Dim AltColor As String = ""

        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.BodyBackgroundColor & """>")
            .Append("  <tr>")
            .Append("    <td align=""left"" valign=""middle"" width=""50%"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """ color=""" & AdvantageFramework.Email.HtmlEmail.RowFontColor & """>Task</font></td>")
            .Append("    <td align=""left"" valign=""middle"" width=""20%"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """ color=""" & AdvantageFramework.Email.HtmlEmail.RowFontColor & """>Employees</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """ color=""" & AdvantageFramework.Email.HtmlEmail.RowFontColor & """>Start</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """ color=""" & AdvantageFramework.Email.HtmlEmail.RowFontColor & """>Due</font></td>")
            .Append("    <td align=""right"" valign=""middle"" width=""10%"" bgcolor=""" & AdvantageFramework.Email.HtmlEmail.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """ color=""" & AdvantageFramework.Email.HtmlEmail.RowFontColor & """>Completed</font></td>")
            .Append("  </tr>")
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim dt As New DataTable
            dt = oTrafficSchedule.GetScheduleTasks(JNum, JCNum, "", CStr(Session("UserCode")), "", "", "", True, False, False)
            Dim ThisSEQ As Integer = 0
            Dim ThisTask As String = ""
            Dim ThisEmpListString As String = ""
            Dim ThisStartDate As String = ""
            Dim ThisDueDate As String = ""
            Dim ThisCompletedDate As String = ""
            Dim ThisTaskComment As String = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                If IsDBNull(dt.Rows(i)("TASK_CODE")) = False Then
                    ThisTask = dt.Rows(i)("TASK_CODE")
                Else
                    ThisTask = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("TASK_DESCRIPTION")) = False Then
                    ThisTask &= " - " & dt.Rows(i)("TASK_DESCRIPTION")
                    'Else
                    '    ThisTask = "&nbsp;"
                End If
                'emps!
                If IsDBNull(dt.Rows(i)("TASK_START_DATE")) = False Then
                    ThisStartDate = dt.Rows(i)("TASK_START_DATE")
                Else
                    ThisStartDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("JOB_REVISED_DATE")) = False Then
                    ThisDueDate = dt.Rows(i)("JOB_REVISED_DATE")
                Else
                    ThisDueDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("JOB_COMPLETED_DATE")) = False Then
                    ThisCompletedDate = dt.Rows(i)("JOB_COMPLETED_DATE")
                Else
                    ThisCompletedDate = "&nbsp;"
                End If
                If IsDBNull(dt.Rows(i)("FNC_COMMENTS")) = False Then
                    ThisTaskComment = dt.Rows(i)("FNC_COMMENTS")
                Else
                    ThisTaskComment = ""
                End If

                If cGlobals.wvIsDate(ThisStartDate) = True Then
                    ThisStartDate = cGlobals.wvCDate(ThisStartDate).ToShortDateString
                Else
                    ThisStartDate = "&nbsp;"
                End If
                If cGlobals.wvIsDate(ThisDueDate) = True Then
                    ThisDueDate = cGlobals.wvCDate(ThisDueDate).ToShortDateString
                Else
                    ThisDueDate = "&nbsp;"
                End If
                If cGlobals.wvIsDate(ThisCompletedDate) = True Then
                    ThisCompletedDate = cGlobals.wvCDate(ThisCompletedDate).ToShortDateString
                Else
                    ThisCompletedDate = "&nbsp;"
                    If BoolNextDueMarked = False Then
                        NextDueFontStyle = " color=""#FF0000"""
                        BoolNextDueMarked = True
                    Else
                        NextDueFontStyle = ""
                    End If
                End If

                If IsDBNull(dt.Rows(i)("SEQ_NBR")) = False Then
                    ThisSEQ = CType(dt.Rows(i)("SEQ_NBR"), Integer)
                Else
                    ThisSEQ = -1
                End If

                If BoolAlternate = True Then
                    AltColor = " bgcolor=""#FFFFFF"""
                Else
                    AltColor = " bgcolor=""#DADADA"""
                End If

                .Append("  <tr>")
                .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">" & ThisTask & "</font></td>") 'task
                If ThisSEQ >= 0 Then
                    Dim strEmps As String = oTrafficSchedule.GetTaskEmpListString(JNum, JCNum, ThisSEQ)
                    .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">" & strEmps & "</font></td>") 'emps
                Else
                    .Append("    <td align=""left"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">&nbsp;</font></td>") 'emps
                End If
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">" & ThisStartDate & "</font></td>") 'start
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">" & ThisDueDate & "</font></td>") 'due
                .Append("    <td align=""right"" valign=""top""" & AltColor & "><font size=""" & AdvantageFramework.Email.HtmlEmail.RowFontSize & """ face=""" & AdvantageFramework.Email.HtmlEmail.Font & """" & NextDueFontStyle & ">" & ThisCompletedDate & "</font></td>") 'completed
                .Append("  </tr>")
                If ThisTaskComment.Length > 0 Then
                    .Append("  <tr>")
                    .Append("    <td colspan=""5"" bgcolor=""#FFFFFF"" align=""left"" valign=""top""" & AltColor & "><font size=""1"" face=""" & AdvantageFramework.Email.HtmlEmail.Font & """>Task Comments:&nbsp;&nbsp;" & ThisTaskComment & "</font></td>")
                    .Append("  </tr>")
                End If

                BoolAlternate = Not BoolAlternate
            Next
            .Append("</table>")
        End With
        Return sb.ToString
    End Function

    Private Sub BtnSend_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        If JobNum > 0 And JobComp > 0 Then
            Dim str_uname As String = ""
            Dim str_msg As String = ""
            Dim str_cli_code As String = ""
            Dim str_div_code As String = ""
            Dim str_prd_code As String = ""
            Dim str_cli As String = ""
            Dim str_div As String = ""
            Dim str_prod As String = ""
            Dim str_job As String = ""
            Dim str_comp As String = ""
            Dim str_start As String = ""
            Dim str_due As String = ""
            Dim str_stat As String = ""

            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Try
                Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(JobNum, JobComp, Session("UserCode").ToString(), False).Tables(0)
                If dt.Rows.Count > 0 Then
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        str_cli_code = dt.Rows(0)("CL_CODE")
                        str_cli = dt.Rows(0)("CL_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        str_cli &= " - " & dt.Rows(0)("CL_NAME")
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                        str_div_code = dt.Rows(0)("DIV_CODE")
                        str_div = dt.Rows(0)("DIV_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                        str_div &= " - " & dt.Rows(0)("DIV_NAME")
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                        str_prd_code = dt.Rows(0)("PRD_CODE")
                        str_prod = dt.Rows(0)("PRD_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                        str_prod &= " - " & dt.Rows(0)("PRD_DESCRIPTION")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                        str_job = dt.Rows(0)("JOB_NUMBER")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                        str_job &= " - " & dt.Rows(0)("JOB_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                        str_comp = dt.Rows(0)("JOB_COMPONENT_NBR")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                        str_comp &= " - " & dt.Rows(0)("JOB_COMP_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("TRF_CODE")) = False Then
                        str_stat = dt.Rows(0)("TRF_CODE")
                    End If
                    If IsDBNull(dt.Rows(0)("TRF_DESC")) = False Then
                        str_stat &= " - " & dt.Rows(0)("TRF_DESC")
                    End If
                    If IsDBNull(dt.Rows(0)("START_DATE")) = False Then
                        str_start = dt.Rows(0)("START_DATE")
                    End If
                    If IsDBNull(dt.Rows(0)("JOB_FIRST_USE_DATE")) = False Then
                        str_due = dt.Rows(0)("JOB_FIRST_USE_DATE")
                    End If
                End If
            Catch ex As Exception
            End Try

            'Report:
            Dim StrFilePrefix As String = Request.PhysicalApplicationPath & "TEMP\"
            Dim StrFileName As String = ""
            'Dim StrImagePath As String = Request.PhysicalApplicationPath & "\Images\logo_print.gif"
            If Me.ChkIncludeReport.Checked = True Then
                Dim r As cReports = New cReports(Session("ConnString"))
                Dim StrFileDate As String = "__" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString() & Now.Hour.ToString() & Now.Minute.ToString
                Dim StrFileType As String = ".pdf"
                StrFileName = "Project_Schedule_" & JobNum.ToString() & "_" & JobComp.ToString() & StrFileDate & StrFileType

                Dim rpt As New popReportViewer
                Try
                    Dim ThisOptions As String = JobNum.ToString() & "|" & JobComp.ToString
                    rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                Catch ex As Exception
                    StrFileName = ""
                End Try
            End If

            Dim StrEmps As String = Me.AutoCompleteRecipients.GetCommaDelimitedStringOfEmployeeCodes() & "," & Session("EmpCode").ToString()

            Dim dtEmailList As New DataTable
            dtEmailList = oTrafficSchedule.NotifyGetEmailEmployees(StrEmps)

            Dim ws As New cWebServices(Session("ConnString"))
            Dim CurrEmpName As String = ""
            Dim CurrEmpEmail As String = ""
            Dim strTasksTable As String = BodyTasks(JobNum, JobComp)

            Dim strAddress As String
            'strAddress = Request.Url.Scheme & "://" & Request.Url.Host & "/TrafficSchedule.aspx?JobNum=" & JobNum & "&JobComp=" & JobComp

            Dim sbEmailBody As New System.Text.StringBuilder

            If dtEmailList.Rows.Count > 0 Then

                Dim StrAlertBodyString As String = ""
                Dim StrAlertBodyHTML As String '= StrEmailBody.Replace("<body bgcolor=""#FFFFFF"">", "").Replace("</body>", "")
                Dim StrAlertBodyLink As String = "Please see schedule application for details."
                'StrAlertBodyHTML = StrAlertBodyHTML.Replace("<body bgcolor=""#FFFFFF"">", "").Replace("</body>", "")

                Dim thisAlertID As Integer = 0
                If Me.ChkIncludeReport.Checked = True And StrFileName <> "" Then
                    thisAlertID = SaveAlert(Me.TxtSubject.Text, Me.RadEditorBody.Text & Environment.NewLine & StrAlertBodyLink, Me.RadEditorBody.Html & "<br/><br/>" & strTasksTable, CType(Me.RblPriority.SelectedValue, Short), str_cli_code, str_div_code, str_prd_code, JobNum, JobComp, StrEmps, StrFilePrefix & StrFileName)
                    'thisAlertID = SaveAlert(Me.TxtSubject.Text, Me.RadEditorBody.Text & Environment.NewLine & StrAlertBodyLink, Me.RadEditorBody.Html & "<br/><br/>" & strTasksTable, CType(Me.RblPriority.SelectedValue, Short), str_cli_code, str_div_code, str_prd_code, JobNum, JobComp, StrEmps, "")
                Else
                    thisAlertID = SaveAlert(Me.TxtSubject.Text, Me.RadEditorBody.Text & Environment.NewLine & StrAlertBodyLink, Me.RadEditorBody.Html & "<br/><br/>" & strTasksTable, CType(Me.RblPriority.SelectedValue, Short), str_cli_code, str_div_code, str_prd_code, JobNum, JobComp, StrEmps, "")
                End If

                'Gather General Information section of email
                'By this time, impersonation should be off:
                Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                If IsNTAUTH = True Then
                    currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                    impersonationContext = currentWindowsIdentity.Impersonate()
                End If


                Dim alert As New Alert(Session("ConnString"))
                Dim strGeneralInfo As String = alert.GeneralInfo(thisAlertID)

                'remove from string after sending:
                Me.HFIDString.Value = Me.HFIDString.Value.Replace(CurrentJC & "|", "")
                'close when no more job/comps in list
                Dim str As String = Me.HFIDString.Value
                If Me.HFIDString.Value.Replace("|", "").Replace(",", "") = "" Then
                    CloseAndRefresh()
                Else
                    Session("SchedJobNumber") = "0"
                    Session("SchedJobComponentNumber") = "0"
                    MiscFN.ResponseRedirect("TrafficSchedule_Notify.aspx?id=" & str)
                    Exit Sub
                End If
                '**********************end of save


                Dim bool As Boolean
                For i As Integer = 0 To dtEmailList.Rows.Count - 1
                    Try
                        If IsDBNull(dtEmailList.Rows(i)("EMP_EMAIL")) = False Then
                            CurrEmpEmail = dtEmailList.Rows(i)("EMP_EMAIL")
                        End If
                    Catch ex As Exception
                        CurrEmpEmail = ""
                    End Try
                    If CurrEmpEmail <> "" And MiscFN.IsValidEmail(CurrEmpEmail) = True Then
                        Try
                            If IsDBNull(dtEmailList.Rows(i)("EMP_FML_NAME")) = False Then
                                CurrEmpName = dtEmailList.Rows(i)("EMP_FML_NAME")
                            End If
                        Catch ex As Exception
                            CurrEmpName = "Hello"
                        End Try

                        Dim MyHtmlEmailBody As New AdvantageFramework.Email.HtmlEmail(True)
                        MyHtmlEmailBody.AddCustomRow(strGeneralInfo)
                        BodyHeader(MyHtmlEmailBody, CurrEmpName, Me.RadEditorBody.Html, str_cli, str_div, str_prod, str_job, str_comp, str_start, str_due, str_stat)
                        MyHtmlEmailBody.AddCustomRow(strTasksTable)

                        bool = ws.SendEmailWAttachments(thisAlertID, CurrEmpEmail, Me.TxtSubject.Text, MyHtmlEmailBody.ToString(thisAlertID), , , True, CType(Me.RblPriority.SelectedValue, Short), IsNTAUTH)

                        If bool = False Then
                            Session("errorMsg") = ws.getErrMsg
                        End If
                    End If
                Next

                If StrFileName <> "" Then
                    Try
                        File.Delete(StrFilePrefix & StrFileName)
                    Catch ex As Exception
                    End Try
                End If

                'Alert
                If IsNTAUTH = True Then
                    impersonationContext.Undo()
                End If

            End If
        End If
    End Sub

    Private Sub CloseAndRefresh()
        Dim FunctionName As String = "HidePopUpWindows"
        Me.LitScript.Text = "<script>javascript:CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
    End Sub

    Private Function SaveAlert(ByVal TheSubject As String, ByVal TheBodyText As String, ByVal TheBodyHTML As String, ByVal ThePriority As Short, _
                                        ByVal TheCL_CODE As String, ByVal TheDIV_CODE As String, ByVal ThePRD_CODE As String, ByVal TheJOB_NUMBER As Integer, _
                                        ByVal TheJOB_COMPONENT_NBR As Integer, ByVal AlertRecipients As String, Optional ByVal PDF_Filename As String = "") As Integer
        Try
            Dim ThisAlert As New Alert(Session("ConnString"))
            With ThisAlert
                .AddNew()
                .ALERT_TYPE_ID = 1 'traffic
                .ALERT_CAT_ID = 2 'schedule modified
                .SUBJECT = TheSubject
                .BODY = TheBodyText
                .BODY_HTML = TheBodyHTML
                .GENERATED = Now
                .PRIORITY = ThePriority
                .CL_CODE = TheCL_CODE
                .DIV_CODE = TheDIV_CODE
                .PRD_CODE = ThePRD_CODE
                .JOB_NUMBER = TheJOB_NUMBER
                .JOB_COMPONENT_NBR = TheJOB_COMPONENT_NBR
                .EMP_CODE = Session("EmpCode")
                .ALERT_USER = Session("UserCode")
                .Save()
            End With
            If AlertRecipients.Length > 0 Then
                Dim RecipientArray() As String
                AlertRecipients = AlertRecipients.Replace(" ", "")
                AlertRecipients = MiscFN.RemoveDuplicatesFromString(AlertRecipients, ",")
                AlertRecipients = MiscFN.RemoveTrailingDelimiter(AlertRecipients, ",")
                RecipientArray = AlertRecipients.Split(",")
                If Not RecipientArray Is Nothing Then
                    For i As Integer = 0 To RecipientArray.Length - 1
                        If RecipientArray(i) <> "" Then
                            ThisAlert.AddAlertRecipient(RecipientArray(i))
                        End If
                    Next
                End If
            End If
            Try
                If ThisAlert.ALERT_ID > 0 Then
                    Dim DocumentId As Integer = 0
                    Dim Repository As New DocumentRepository(Session("ConnString"))
                    Dim Document As New Document(Session("ConnString"))
                    Dim RepositoryFilename As String = ""

                    If PDF_Filename <> "" Then
                        Dim FInfo As FileInfo
                        FInfo = New FileInfo(PDF_Filename)
                        Dim FileLength As Long = 0
                        FileLength = FInfo.Length
                        Dim FileBytes(FileLength - 1) As Byte

                        Dim FileStream As System.IO.FileStream = FInfo.OpenRead()
                        FileStream.Read(FileBytes, 0, FileLength)
                        Dim realFilename As String = ""
                        realFilename = MiscFN.ParseLast(PDF_Filename, "\")

                        Dim RepositoryFilenamePS As String = ""
                        RepositoryFilenamePS = "a_" & Guid.NewGuid.ToString()
                        DocumentId = 0
                        Try
                            Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                            Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                            If IsNTAUTH = True Then
                                currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                                impersonationContext = currentWindowsIdentity.Impersonate()
                            End If
                            'db stuff here
                            DocumentId = Document.Add(realFilename, "application/pdf", RepositoryFilenamePS, FileLength, Session("UserCode"), "", "")
                            ThisAlert.AddAttachment(DocumentId, Session("UserCode"))
                            If IsNTAUTH = True Then
                                impersonationContext.Undo()
                            End If
                        Catch ex As Exception
                        End Try
                        Dim RepFNameTemp As String = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "Alert View", "Attached Doc", "a_", RepositoryFilenamePS)
                        FileStream.Close()
                    End If
                    '**********************************************************************
                    'Dim oApp As cApplication = New cApplication(CStr(Session("ConnString")))
                    'Dim AppIsOnASP As Boolean = False

                    Try
                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                        If IsNTAUTH = True Then
                            currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                            impersonationContext = currentWindowsIdentity.Impersonate()
                        End If
                        'AppIsOnASP = Application.IsASPClient()
                        If IsNTAUTH = True Then
                            impersonationContext.Undo()
                        End If
                    Catch ex As Exception

                    End Try
                    Dim HasOverSizedFile As Boolean = False
                    If Me.RadUploadTrafficScheduleNotify.UploadedFiles.Count > 0 Then 'And AppIsOnASP = False Then
                        Dim doc As New DocumentRepository("", True)
                        For a As Integer = 0 To Me.RadUploadTrafficScheduleNotify.UploadedFiles.Count - 1
                            ' Read the uploaded file into a file stream for later
                            Dim realFilename As String = Me.RadUploadTrafficScheduleNotify.UploadedFiles(a).GetName
                            Dim MIMEType As String = Me.RadUploadTrafficScheduleNotify.UploadedFiles(a).ContentType
                            Dim FileLength As Integer = Me.RadUploadTrafficScheduleNotify.UploadedFiles(a).InputStream.Length
                            ' Copy the fileBytes from the upload object
                            Dim ThisFC As New DocumentRepository.FileCompare
                            ThisFC.FileByteLength = CType(FileLength, Long)
                            If doc.IsOverFileSizeLimit(ThisFC) = False Then
                                If FileLength > 0 Then
                                    Dim FileBytes(FileLength - 1) As Byte
                                    Me.RadUploadTrafficScheduleNotify.UploadedFiles(a).InputStream.Read(FileBytes, 0, FileLength)
                                    'Insert your code that runs under the security context of the authenticating user here.
                                    RepositoryFilename = Repository.AddDocument(realFilename, FileBytes, "", "", Session("userCode"), "New Alert", "Attached Doc", "a_")
                                    DocumentId = 0
                                    Try
                                        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
                                        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity
                                        If IsNTAUTH = True Then
                                            currentWindowsIdentity = CType(User.Identity, System.Security.Principal.WindowsIdentity)
                                            impersonationContext = currentWindowsIdentity.Impersonate()
                                        End If
                                        DocumentId = Document.Add(realFilename, MIMEType, RepositoryFilename, FileLength, Session("UserCode"), "", "")
                                        ThisAlert.AddAttachment(DocumentId, Session("UserCode"))
                                        If IsNTAUTH = True Then
                                            impersonationContext.Undo()
                                        End If
                                    Catch ex As Exception
                                    End Try
                                End If
                            Else
                                HasOverSizedFile = True
                            End If
                        Next a
                        If HasOverSizedFile = True Then
                            ShowError("Files that exceeded the file size limit were excluded")
                        End If
                    End If
                    If Me.LinkDropDownList.SelectedIndex > 0 Then 'And AppIsOnASP = False Then
                        DocumentId = 0
                        DocumentId = Me.LinkDropDownList.SelectedValue
                        ThisAlert.AddAttachment(DocumentId, Session("UserCode"))
                    End If
                    '**********************************************************************
                End If
            Catch ex As Exception

            End Try
            'commented this out temp DMR June 11 2009 until EC gets back to answer questions.
            'Try
            '    If ThisAlert.ALERT_ID > 0 And PDF_Filename <> "" Then
            '        'upload to docmanager and associate with alert:
            '        'and delete doc?

            '        'Try
            '        '    FInfo.Delete()
            '        'Catch ex As Exception

            '        'End Try
            '    End If
            'Catch ex As Exception

            'End Try
            Return ThisAlert.ALERT_ID
        Catch ex As Exception
            Return -1
        End Try

    End Function

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        CloseAndRefresh()
    End Sub

    Private Sub BtnSkip_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSkip.Click
        'remove from string after sending:
        Me.HFIDString.Value = Me.HFIDString.Value.Replace(CurrentJC & "|", "")
        'close when no more job/comps in list
        Dim str As String = Me.HFIDString.Value
        If Me.HFIDString.Value.Replace("|", "").Replace(",", "") = "" Then
            CloseAndRefresh()
        Else
            Session("SchedJobNumber") = "0"
            Session("SchedJobComponentNumber") = "0"
            MiscFN.ResponseRedirect("TrafficSchedule_Notify.aspx?id=" & str)
            Exit Sub
        End If
    End Sub

    Protected Sub AttachemtTypeDropDownList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AttachemtTypeDropDownList.SelectedIndexChanged
        Select Case Me.AttachemtTypeDropDownList.SelectedValue
            Case "Upload"
                Me.RadUploadTrafficScheduleNotify.Visible = True
                Me.LinkDropDownList.Visible = False

            Case "Link"
                Me.RadUploadTrafficScheduleNotify.Visible = False
                Me.LinkDropDownList.Visible = True
                LoadLinkableDocuments()
        End Select
    End Sub

    
    Protected Sub LinkDropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LinkDropDownList.SelectedIndexChanged

    End Sub
    Private Sub LoadLinkableDocuments()

        Me.LinkDropDownList.Items.Clear()
        Me.LinkDropDownList.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "[Please select]"))

        Try
            '    Case "CL"
            ''If Me.txtClient.Text.Trim = "" Then
            ''    JSMessageBox("Please select a client.")
            ''    Exit Sub
            ''End If
            'Dim ClientDocs As New vCurrentClientDocuments(Me.ConnectionString)
            'ClientDocs.Where.CL_CODE.Value = Me.txtClient.Text 'Me.ClientAutoSuggestBox.SelectedValue
            'ClientDocs.Query.Load()

            'Do Until ClientDocs.EOF
            '    Me.LinkDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(ClientDocs.FILENAME & " " & ClientDocs.USER_NAME & " " & ClientDocs.UPLOADED_DATE, ClientDocs.DOCUMENT_ID))
            '    ClientDocs.MoveNext()
            'Loop

            Dim JobComponentDocs As New vCurrentJobComponentDocuments(Session("ConnString"))
            JobComponentDocs.Where.JOB_NUMBER.Value = JobNum
            JobComponentDocs.Where.JOB_COMPONENT_NUMBER.Value = JobComp
            JobComponentDocs.Query.Load()
            Do Until JobComponentDocs.EOF
                Me.LinkDropDownList.Items.Add(New Telerik.Web.UI.RadComboBoxItem(JobComponentDocs.FILENAME & ", added by " & JobComponentDocs.USER_NAME & " @ " & JobComponentDocs.UPLOADED_DATE, JobComponentDocs.DOCUMENT_ID))
                JobComponentDocs.MoveNext()
            Loop


        Catch ex As Exception

        End Try

    End Sub


End Class