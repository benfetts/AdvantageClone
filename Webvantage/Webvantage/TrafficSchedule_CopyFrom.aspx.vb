Imports Webvantage.cGlobals
Imports Telerik.Web.UI
Public Class TrafficSchedule_CopyFrom
    Inherits Webvantage.BaseChildPage

    Private SchedJobNum As Integer = 0
    Private SchedJobComp As Integer = 0
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Try
            SchedJobNum = CType(Request.QueryString("JobNum"), Integer)
        Catch ex As Exception
            SchedJobNum = 0
        End Try
        Try
            SchedJobComp = CType(Request.QueryString("JobComp"), Integer)
        Catch ex As Exception
            SchedJobComp = 0
        End Try
        Me.LoadLookups()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            CheckBoxListCopyOptions.Items.Clear()

            For Each EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.CopyOptions))

                CheckBoxListCopyOptions.Items.Add(New System.Web.UI.WebControls.ListItem(EnumObject.Description, EnumObject.Code))

            Next

        End If

    End Sub

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tscf&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tscf&type=division&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tscf&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value);return false;")
        Me.HlJob.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=schedulecopy&type=jobschedulejt&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobType.ClientID & ".value);return false;")
        Me.HlComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=schedulecopy&type=jobcompschedulejt&control=" & Me.TxtJobCompNum.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&jobcomp=' + document.forms[0]." & Me.TxtJobCompNum.ClientID & ".value + '&jobtype=' + document.forms[0]." & Me.TxtJobType.ClientID & ".value);return false;")
        Me.HlJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=tscf&calledfrom=custom&form=schedule&control=" & Me.TxtJobType.ClientID & "&job=' + document.forms[0]." & Me.TxtJobNum.ClientID & ".value + '&type=jobtype');return false;")
    End Sub

    Private Sub RadGridCopyFromSchedules_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCopyFromSchedules.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                If e.Item.DataItem("MILESTONE") = "1" Then
                    CType(e.Item.FindControl("chkMILESTONE"), CheckBox).Checked = True
                End If
            Catch ex As Exception

            End Try
            Try
                CType(e.Item.FindControl("TxtSTART_DATE"), TextBox).Text = Now.Date.ToShortDateString()
            Catch ex As Exception

            End Try
            e.Item.Selected = True
        End If
    End Sub

    Private Sub RadGridCopyFromSchedules_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCopyFromSchedules.NeedDataSource
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        If Me.TxtJobNum.Text <> "" And Me.TxtJobCompNum.Text <> "" Then
            If IsNumeric(Me.TxtJobNum.Text) = True And IsNumeric(Me.TxtJobCompNum.Text) = True Then
                Dim dt As DataTable = oTrafficSchedule.GetScheduleTaskswithClosed(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, "order", CStr(Session("UserCode")), "", "", "", True, False, False)
                Me.RadGridCopyFromSchedules.DataSource = dt
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        If Me.TxtJobNum.Text <> "" Then
            If IsNumeric(Me.TxtJobNum.Text) = False Then
                Me.ShowMessage("Please enter a valid job number.")
                Me.TxtJobNum.Focus()
                Exit Sub
            End If
        End If
        If Me.TxtJobCompNum.Text <> "" Then
            If IsNumeric(Me.TxtJobCompNum.Text) = False Then
                Me.ShowMessage("Please enter a valid component number.")
                Me.TxtJobCompNum.Focus()
                Exit Sub
            End If
        End If
        If Me.TxtJobNum.Text <> "" Then
            JobNum = CInt(Me.TxtJobNum.Text)
        End If
        If Me.TxtJobCompNum.Text <> "" Then
            JobComp = CInt(Me.TxtJobCompNum.Text)
        End If

        If JobNum <= 0 Then
            Me.ShowMessage("Please enter a valid job number.")
            Me.TxtJobNum.Focus()
            Exit Sub
        End If
        If JobComp <= 0 Then
            If JobNum > 0 Then
                Me.TxtJobNum.Text = JobNum
            End If
            Me.ShowMessage("Please enter a valid component number.")
            Me.TxtJobCompNum.Focus()
            Exit Sub
        End If
        'Some basic job validation:
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If myVal.ValidateJobNumber(JobNum) = False Then
            Me.ShowMessage("This job does not exist!")
            Me.TxtJobNum.Focus()
            Exit Sub
        End If
        If myVal.ValidateJobCompNumber(JobNum, JobComp) = False Then
            Me.ShowMessage("This is not a valid job/component!")
            Me.TxtJobNum.Focus()
            Exit Sub
        End If
        If JobNum > 0 And JobComp > 0 Then
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNum, JobComp) = False Then
                Me.ShowMessage("Access to this job/comp is denied.")
                Me.TxtJobNum.Focus()
                Exit Sub
            End If
            'If myVal.ValidateJobCompIsEditable(JobNum, JobComp) = False Then
            '    Me.ShowMessage("Job/comp process control does not allow access.")
            '    Me.TxtJobNum.Focus()
            '    Exit Sub
            'End If
        End If
        Dim dt As DataTable = oTrafficSchedule.GetScheduleHeader(JobNum, JobComp, Session("UserCode").ToString(), False).Tables(0)
        If dt.Rows.Count > 0 Then
            If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                Me.TxtClientCode.Text = dt.Rows(0)("CL_CODE")
            End If
            If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                Me.TxtClientDescription.Text = dt.Rows(0)("CL_NAME")
            End If
            If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                Me.TxtDivisionCode.Text = dt.Rows(0)("DIV_CODE")
            End If
            If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                Me.TxtDivisionDescription.Text = dt.Rows(0)("DIV_NAME")
            End If
            If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                Me.TxtProductCode.Text = dt.Rows(0)("PRD_CODE")
            End If
            If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                Me.TxtProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")
            End If
            If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then
                Me.TxtJobNum.Text = dt.Rows(0)("JOB_NUMBER")
            End If
            If IsDBNull(dt.Rows(0)("JOB_DESC")) = False Then
                Me.TxtJobDescription.Text = dt.Rows(0)("JOB_DESC")
            End If
            If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                Me.TxtJobCompNum.Text = dt.Rows(0)("JOB_COMPONENT_NBR")
            End If
            If IsDBNull(dt.Rows(0)("JOB_COMP_DESC")) = False Then
                Me.TxtJobCompDescription.Text = dt.Rows(0)("JOB_COMP_DESC")
            End If
        End If
        Me.RadGridCopyFromSchedules.Rebind()
    End Sub

    Private Sub GetCopyOptions(ByRef IncludeStartDate As Boolean, ByRef IncludeDueDate As Boolean, ByRef IncludeTaskEmployees As Boolean, ByRef IncludeTaskComment As Boolean, ByRef IncludeDueDateComment As Boolean)

        For Each ListItem In Me.CheckBoxListCopyOptions.Items.OfType(Of System.Web.UI.WebControls.ListItem)()

            Select Case ListItem.Value

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeStartDate.ToString

                    IncludeStartDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDate.ToString

                    IncludeDueDate = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskEmployees.ToString

                    IncludeTaskEmployees = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeTaskComment.ToString

                    IncludeTaskComment = ListItem.Selected

                Case AdvantageFramework.ProjectSchedule.CopyOptions.IncludeDueDateComment.ToString

                    IncludeDueDateComment = ListItem.Selected

            End Select

        Next

    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim NewTaskStatus As String = ""
        Dim NewPhaseDesc As String = ""
        Dim NewPhaseID As Integer = 0
        Dim NewJobOrder As Integer = 0
        Dim NewPredessorString As String = ""
        Dim NewTaskCode As String = ""
        Dim NewTaskDescription As String = ""
        Dim NewMilestone As Boolean = False
        Dim NewJobDays As Integer = 0
        Dim NewJobHours As Decimal = 0.0
        Dim NewStartDate As String = ""
        Dim NewRevisedDate As String = ""
        Dim NewDueTime As String = ""
        Dim NewJobDueDate As String = ""
        Dim NewJobCompletedDate As String = ""
        Dim NewEmpCodeString As String = ""
        Dim NewClientCodeString As String = ""
        Dim NewEstimateFunction As String = ""
        Dim NewFunctionComment As String = ""
        Dim NewDueDateComment As String = ""
        Dim NewRevisedDateComment As String = ""
        Dim NewDefRoleCode As String = ""
        Dim CopySeqNum As Integer
        Dim SequenceList As Generic.Dictionary(Of Short, Short) = New Generic.Dictionary(Of Short, Short)
        Dim ParentSequenceList As Generic.Dictionary(Of Short, Short) = New Generic.Dictionary(Of Short, Short)
        Dim PredecessorList As Generic.Dictionary(Of Short, String) = New Generic.Dictionary(Of Short, String)
        Dim IncludeStartDate As Boolean = False
        Dim IncludeDueDate As Boolean = False
        Dim IncludeTaskEmployees As Boolean = False
        Dim IncludeTaskComment As Boolean = False
        Dim IncludeDueDateComment As Boolean = False
        Dim GridOrder As Short? = Nothing

        GetCopyOptions(IncludeStartDate, IncludeDueDate, IncludeTaskEmployees, IncludeTaskComment, IncludeDueDateComment)

        Dim chk As CheckBox
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCopyFromSchedules.MasterTableView.Items
            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If chk.Checked = True Then
                'Set variables:
                Try
                    NewJobOrder = CType(CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("TxtJOB_ORDER"), TextBox).Text, Integer)
                Catch ex As Exception
                    NewJobOrder = 0
                End Try
                Try
                    NewPhaseID = CType(CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("HFPhaseID"), HiddenField).Value, Integer)
                Catch ex As Exception
                    NewPhaseID = 0
                End Try
                Try
                    NewTaskCode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")
                    NewTaskCode = NewTaskCode.Trim()
                Catch ex As Exception
                    NewTaskCode = ""
                End Try
                NewTaskDescription = gridDataItem("colTRF_DESC").Text.Replace("&nbsp;", "")
                Try
                    NewMilestone = CType(gridDataItem("colMILESTONE").FindControl("ChkMILESTONE"), CheckBox).Checked
                Catch ex As Exception
                    NewMilestone = False
                End Try

                NewEstimateFunction = CType(gridDataItem("colMILESTONE").FindControl("HfEstimateFunction"), HiddenField).Value

                Try
                    NewJobDays = CType(CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("TxtJOB_DAYS"), TextBox).Text, Integer)
                Catch ex As Exception
                    NewJobDays = 0
                End Try
                Try
                    NewJobHours = CType(CType(gridDataItem("colTRF_PRESET_HRS").FindControl("TxtJOB_HRS"), TextBox).Text, Decimal)
                Catch ex As Exception
                    NewJobHours = 0
                End Try
                Try
                    NewDefRoleCode = CType(gridDataItem("colTRF_PRESET_ORDER").FindControl("HFRoleCode"), HiddenField).Value
                Catch ex As Exception
                    NewDefRoleCode = ""
                End Try
                Try
                    NewTaskStatus = CType(gridDataItem("colMILESTONE").FindControl("HfTaskStatus"), HiddenField).Value
                Catch ex As Exception
                    NewTaskStatus = ""
                End Try

                If IncludeStartDate = True Then
                    Try
                        NewStartDate = CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("HFStartDate"), HiddenField).Value
                        If cGlobals.wvIsDate(NewStartDate) = True Then
                            NewStartDate = cGlobals.wvCDate(NewStartDate).ToShortDateString
                        Else
                            NewStartDate = ""
                        End If
                    Catch ex As Exception
                        NewStartDate = ""
                    End Try
                Else
                    NewStartDate = ""
                End If

                If IncludeDueDate = True Then
                    Try
                        NewRevisedDate = CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("HFRevisedDueDate"), HiddenField).Value
                        If cGlobals.wvIsDate(NewRevisedDate) = True Then
                            NewRevisedDate = cGlobals.wvCDate(NewRevisedDate).ToShortDateString
                        Else
                            NewRevisedDate = ""
                        End If
                    Catch ex As Exception
                        NewRevisedDate = ""
                    End Try
                    Try
                        NewJobDueDate = CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("HFJobDueDate"), HiddenField).Value
                        If cGlobals.wvIsDate(NewJobDueDate) = True Then
                            NewJobDueDate = cGlobals.wvCDate(NewJobDueDate).ToShortDateString
                        Else
                            NewJobDueDate = ""
                        End If
                    Catch ex As Exception
                        NewJobDueDate = ""
                    End Try

                Else
                    NewRevisedDate = ""
                    NewJobDueDate = ""
                End If

                'do not copy completed date
                NewJobCompletedDate = ""
                'Try
                '    NewJobCompletedDate = CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("HFDateCompleted"), HiddenField).Value
                '    If cGlobals.wvIsDate(NewJobCompletedDate) = True Then
                '        NewJobCompletedDate = cGlobals.wvCDate(NewJobCompletedDate).ToShortDateString
                '    Else
                '        NewJobCompletedDate = ""
                '    End If
                'Catch ex As Exception
                '    NewJobCompletedDate = ""
                'End Try

                Try
                    NewDueTime = CType(gridDataItem("colTRF_PRESET_DAYS").FindControl("HFTimeDue"), HiddenField).Value
                Catch ex As Exception
                    NewDueTime = ""
                End Try

                If IncludeTaskComment = True Then
                    Try
                        NewFunctionComment = CType(gridDataItem("colMILESTONE").FindControl("HFFunctionComments"), HiddenField).Value
                    Catch ex As Exception
                        NewFunctionComment = ""
                    End Try
                Else
                    NewFunctionComment = ""
                End If

                If IncludeDueDateComment = True Then
                    Try
                        NewDueDateComment = CType(gridDataItem("colMILESTONE").FindControl("HFDueDateComments"), HiddenField).Value
                    Catch ex As Exception
                        NewDueDateComment = ""
                    End Try
                Else
                    NewDueDateComment = ""
                End If

                Try
                    NewRevisedDateComment = CType(gridDataItem("colMILESTONE").FindControl("HFRevDateComments"), HiddenField).Value
                Catch ex As Exception
                    NewRevisedDateComment = ""
                End Try
                Try
                    CopySeqNum = CType(CType(gridDataItem("colMILESTONE").FindControl("HfSEQ_NBR"), HiddenField).Value, Integer)
                    Dim strPreds As String = oTrafficSchedule.GetTaskPredListString(Me.TxtJobNum.Text, Me.TxtJobCompNum.Text, CopySeqNum)
                    If strPreds.Length > 0 Then
                        strPreds = MiscFN.RemoveTrailingDelimiter(MiscFN.RemoveDuplicatesFromString(strPreds.Trim, ","), ",")
                    End If
                    NewPredessorString = strPreds

                Catch ex As Exception

                End Try

                GridOrder = Nothing
                Try

                    If Not String.IsNullOrWhiteSpace(CType(gridDataItem.FindControl("HiddenFieldGridOrder"), HiddenField).Value) Then

                        GridOrder = CShort(CType(gridDataItem.FindControl("HiddenFieldGridOrder"), HiddenField).Value)

                    End If

                Catch ex As Exception
                    GridOrder = Nothing
                End Try

                'Save:
                Try

                    Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                    Dim StrErr As String = ""
                    Dim IsValidTaskCode As Boolean = True
                    If NewTaskCode <> "" Then
                        IsValidTaskCode = myVal.ValidateTaskCode(NewTaskCode)
                    End If
                    If IsValidTaskCode = True Then

                        ' add predecessors after all tasks have been added!!
                        If Not String.IsNullOrWhiteSpace(NewPredessorString) Then

                            PredecessorList.Add(CopySeqNum, NewPredessorString)

                        End If

                        NewPredessorString = ""

                        StrErr = oTrafficSchedule.AddNewTaskCopyFrom(SchedJobNum, SchedJobComp, NewJobOrder, NewPhaseID, NewPredessorString, NewTaskCode, NewTaskDescription, NewMilestone, NewJobDays, _
                                                                     NewJobHours, NewStartDate, NewRevisedDate, NewDueTime, NewJobDueDate, False, NewJobCompletedDate, _
                                                                     "", NewEstimateFunction, NewFunctionComment, NewDueDateComment, NewRevisedDateComment, NewDefRoleCode, NewClientCodeString, NewTaskStatus, CopySeqNum, GridOrder)
                        'handle employee separately to be able to get hours
                        If IsNumeric(StrErr) = True Then

                            Dim SchedSeqNum As Integer = CType(StrErr, Integer)
                            Dim HfSEQ_NBR As System.Web.UI.WebControls.HiddenField = CType(gridDataItem.FindControl("HfSEQ_NBR"), System.Web.UI.WebControls.HiddenField)
                            Dim HiddenFieldParentTaskSeq As System.Web.UI.WebControls.HiddenField = CType(gridDataItem.FindControl("HiddenFieldParentTaskSeq"), System.Web.UI.WebControls.HiddenField)
                            Dim OldSeqNum As Integer = Nothing
                            Dim ParentTaskSeq As Integer = Nothing

                            If HfSEQ_NBR.Value <> "" Then

                                OldSeqNum = CShort(HfSEQ_NBR.Value)

                            End If

                            SequenceList.Add(OldSeqNum, SchedSeqNum)

                            If HiddenFieldParentTaskSeq.Value <> "" Then

                                ParentTaskSeq = CShort(HiddenFieldParentTaskSeq.Value)

                                ParentSequenceList.Add(SchedSeqNum, ParentTaskSeq)

                            End If

                            If IncludeTaskEmployees = True Then
                                Try
                                    'Assume that if they are at this stage, there is a valid job/comp loaded to copy FROM
                                    Dim CopyJobNum As Integer = CType(Me.TxtJobNum.Text, Integer)
                                    Dim CopyJobCompNum As Integer = CType(Me.TxtJobCompNum.Text, Integer)

                                    oTrafficSchedule.CopyEmployees(CopyJobNum, CopyJobCompNum, CopySeqNum, SchedJobNum, SchedJobComp, SchedSeqNum, NewJobHours)
                                Catch ex As Exception

                                End Try
                            End If

                        End If

                    End If
                Catch ex As Exception
                End Try
            End If
        Next

        If ParentSequenceList IsNot Nothing AndAlso ParentSequenceList.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each ParentSequence In ParentSequenceList

                    Try

                        If SequenceList.ContainsKey(ParentSequence.Value) Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.JOB_TRAFFIC_DET SET PARENT_TASK_SEQ = {0} WHERE JOB_NUMBER = {1} AND JOB_COMPONENT_NBR = {2} AND SEQ_NBR = {3}", SequenceList(ParentSequence.Value), SchedJobNum, SchedJobComp, ParentSequence.Key))

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End Using

        End If

        If PredecessorList IsNot Nothing AndAlso PredecessorList.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each Predecessor In PredecessorList

                    Dim NewTaskSeq As Short = -1
                    Dim OldTaskSeq As Short = -1
                    Dim NewPredList As Generic.List(Of Short) = New Generic.List(Of Short)

                    Try

                        OldTaskSeq = Predecessor.Key
                        NewTaskSeq = SequenceList(OldTaskSeq)

                        For Each Pred In Predecessor.Value.Split(",")

                            Dim NewPredSeq As Short = -1

                            If SequenceList.ContainsKey(CShort(Pred)) Then

                                NewPredList.Add(SequenceList(CShort(Pred)))

                            End If

                        Next

                        If NewPredList IsNot Nothing AndAlso NewPredList.Count > 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.usp_wv_Traffic_Schedule_SaveTask_PredListString '{0}', {1}, {2}, {3}", String.Join(",", NewPredList), SchedJobNum, SchedJobComp, NewTaskSeq))

                        End If

                    Catch ex As Exception

                    End Try

                Next

            End Using

        End If

        CloseAndRefresh()

    End Sub

    Private Sub CloseAndRefresh()
        'Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        Me.CloseThisWindow()
    End Sub

End Class
