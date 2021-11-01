Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class Resources_Emps_Find
    Inherits Webvantage.BaseChildPage

    Protected WithEvents DropFilterRole As RadComboBox
    Protected WithEvents DropGroupBy As RadComboBox

    Public JobNumber As Integer = 0
    Public JobComponentNbr As Integer = 0
    Public CliCode As String = ""
    Public FromForm As Integer = 0
    Private CutOff As DateTime = Nothing
    Private GenId As Integer = 0

    '0 = Event_View.aspx
    '1 = TrafficSchedule.aspx

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetQSVars()

        Me.DropFilterRole = CType(Me.RadToolbarEventTasks.FindItemByValue("FilterByRole").FindControl("DropFilterRole"), RadComboBox)
        Me.DropGroupBy = CType(Me.RadToolbarEventTasks.FindItemByValue("GroupBy").FindControl("DropGroupBy"), RadComboBox)

        If Me.Page.IsPostBack Or Me.Page.IsCallback Then

        Else
            Dim r As New cResources()
            With Me.DropFilterRole
                .DataSource = r.GetRoleList(Me.JobNumber, Me.JobComponentNbr, Me.FromForm)
                .DataTextField = "ROLE_DESC"
                .DataValueField = "TRF_ROLE_CODES"
                .DataBind()
            End With
            Me.LblPleaseSelect.Visible = True
            Me.RadGridAvailableEmployees.Visible = False
        End If
    End Sub

    Private Function SaveTasksGrid() As Boolean
        Dim NoErrors As Boolean = True
        Me.LblMSG_Grid.Text = ""
        Me.SetQSVars()
        Dim strJCSE As String = ""
        Dim strJC As New List(Of String)()
        Dim duplicate As Boolean = False
        Dim RowCount As Integer = Me.RadGridAvailableEmployees.MasterTableView.Items.Count
        If RowCount > 0 Then
            Dim SbUpdate As New System.Text.StringBuilder
            Dim arP(1) As SqlParameter
            For i As Integer = 0 To RowCount - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridAvailableEmployees.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Try
                    Dim err As Boolean = False
                    Dim RowEmp As String = ""
                    Try
                        RowEmp = CType(CurrentGridRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text
                    Catch ex As Exception
                        err = True
                    End Try

                    If Me.FromForm = 0 Then
                        Dim RowEventTaskId As Integer = 0
                        Dim RowEventTaskDate As DateTime = Nothing
                        Dim RowEventTaskStartTime As DateTime = Nothing
                        Dim RowEventTaskEndTime As DateTime = Nothing

                        Try
                            RowEventTaskId = CType(CType(CurrentGridRow.FindControl("HfEVENT_TASK_ID"), HiddenField).Value, Integer)
                        Catch ex As Exception
                            RowEventTaskId = 0
                            err = True
                        End Try
                        Try
                            RowEventTaskDate = CType(CType(CurrentGridRow.FindControl("HfEVENT_TASK_DATE"), HiddenField).Value, DateTime)
                        Catch ex As Exception
                            RowEventTaskDate = Nothing
                            err = True
                        End Try
                        Try
                            RowEventTaskStartTime = CType(CType(CurrentGridRow.FindControl("HfSTART_TIME"), HiddenField).Value, DateTime)
                        Catch ex As Exception
                            RowEventTaskStartTime = Nothing
                            err = True
                        End Try
                        Try
                            RowEventTaskEndTime = CType(CType(CurrentGridRow.FindControl("HfEND_TIME"), HiddenField).Value, DateTime)
                        Catch ex As Exception
                            RowEventTaskEndTime = Nothing
                            err = True
                        End Try

                        If err = False Then
                            If RowEmp <> "" Then
                                Dim EmpIsBooked As Boolean = False
                                Dim ValidEmp As Boolean = False
                                Dim r As New cResources()
                                EmpIsBooked = r.EmployeeIsBooked(RowEmp, RowEventTaskId, RowEventTaskDate, RowEventTaskStartTime, RowEventTaskEndTime, )
                                Dim v As New cValidations(Session("ConnString"))
                                ValidEmp = v.ValidateEmpCodetd(RowEmp)
                                If EmpIsBooked = True Or ValidEmp = False Then
                                    Me.LblMSG_Grid.Text = "Invalid/Booked employee(s) marked in red"
                                    CType(CurrentGridRow.FindControl("TxtCURR_EMP_CODE"), TextBox).BackColor = Drawing.Color.Red
                                    NoErrors = False
                                End If
                                If ValidEmp = True And EmpIsBooked = False Then
                                    SbUpdate.Append("UPDATE EVENT_TASK WITH(ROWLOCK) SET EMP_CODE = '")
                                    SbUpdate.Append(RowEmp)
                                    SbUpdate.Append("' WHERE EVENT_TASK_ID = ")
                                    SbUpdate.Append(RowEventTaskId)
                                    SbUpdate.Append(";")
                                End If

                            Else 'null out the emp
                                SbUpdate.Append("UPDATE EVENT_TASK WITH(ROWLOCK) SET EMP_CODE = NULL WHERE EVENT_TASK_ID = ")
                                SbUpdate.Append(RowEventTaskId)
                                SbUpdate.Append(";")
                            End If
                        End If
                    End If

                    If Me.FromForm = 1 Then 'Adding emp to a JOB task
                        Dim RowSeqNbr As Integer = 0
                        Dim RowHoursAllowed As Decimal = 0.0
                        Try
                            RowSeqNbr = CType(CType(CurrentGridRow.FindControl("HfSEQ_NBR"), HiddenField).Value, Integer)
                        Catch ex As Exception
                            RowSeqNbr = 0
                            err = True
                        End Try
                        Try
                            RowHoursAllowed = CType(CType(CurrentGridRow.FindControl("HfEVENT_TASK_HOURS_ALLOWED"), HiddenField).Value, Decimal)
                        Catch ex As Exception
                            RowHoursAllowed = 0
                            err = True
                        End Try

                        'Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                        '    emp = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Me.JobNumber, Me.JobComponentNbr, RowSeqNbr, RowEmp)
                        'End Using

                        If strJC IsNot Nothing Then
                            strJCSE = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & RowSeqNbr.ToString() & "|" & RowEmp

                            If strJC.Contains(strJCSE) Then
                                duplicate = True
                            End If

                        End If

                        If err = False Then
                            If RowEmp <> "" And duplicate = False Then
                                Dim v As New cValidations(Session("ConnString"))
                                If v.ValidateEmpCodetd(RowEmp) = True Then
                                    SbUpdate.Append("INSERT INTO JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, EMP_CODE, HOURS_ALLOWED) VALUES (")
                                    SbUpdate.Append(Me.JobNumber.ToString())
                                    SbUpdate.Append(", ")
                                    SbUpdate.Append(Me.JobComponentNbr.ToString())
                                    SbUpdate.Append(", ")
                                    SbUpdate.Append(RowSeqNbr.ToString())
                                    SbUpdate.Append(", '")
                                    SbUpdate.Append(RowEmp)
                                    SbUpdate.Append("', @ROW_HOURS")
                                    Dim parameterROW_HOURS As New SqlParameter("@ROW_HOURS", SqlDbType.Decimal)
                                    parameterROW_HOURS.Value = RowHoursAllowed
                                    arP(0) = parameterROW_HOURS
                                    SbUpdate.Append(");")

                                    strJCSE = Me.JobNumber.ToString() & "|" & Me.JobComponentNbr.ToString() & "|" & RowSeqNbr.ToString() & "|" & RowEmp

                                    strJC.Add(strJCSE)

                                Else
                                    Me.LblMSG_Grid.Text = "Employee invalid"
                                    Return False
                                End If
                            Else 'null out the emp

                                duplicate = False

                            End If
                        End If
                    End If

                Catch ex As Exception
                End Try
            Next
            Dim StrUpdate As String = SbUpdate.ToString()
            If StrUpdate.Trim() <> "" Then
                StrUpdate = StrUpdate.Replace("= ''", "= NULL ")
                Try
                    SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, StrUpdate, arP)
                    Return True
                Catch ex As Exception
                    Me.ShowMessage(ex.Message.ToString())
                    Return False
                End Try
            End If
        End If
    End Function

    Private DsMain As DataSet

    Private Sub RadGridAvailableEmployees_DetailTableDataBind(ByVal source As Object, ByVal e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridAvailableEmployees.DetailTableDataBind
        Try
            Dim parentItem As Telerik.Web.UI.GridDataItem = CType(e.DetailTableView.ParentItem, Telerik.Web.UI.GridDataItem)
            If Not parentItem.Edit Then
                Dim ThisEventTaskId As Integer = 0
                Try
                    ThisEventTaskId = CType(parentItem.GetDataKeyValue("EVENT_TASK_ID"), Integer)
                Catch ex As Exception
                    ThisEventTaskId = 0
                End Try

                'Dim ThisRolecode As String
                'Try
                '    ThisRolecode = CType(parentItem.GetDataKeyValue("TRF_ROLE_CODE"), Integer)
                'Catch ex As Exception
                '    ThisRolecode = ""
                'End Try

                Select Case e.DetailTableView.Name
                    Case "OtherEmpsGrid"
                        Try
                            If DsMain Is Nothing Then
                                Dim r As New cResources()
                                DsMain = r.FindAvailableEmployees(FromForm, Me.DropFilterRole.SelectedValue, Me.JobNumber, Me.JobComponentNbr, Nothing, Nothing, False)
                            End If
                            Dim dv As DataView = New DataView(DsMain.Tables(1))
                            dv.RowFilter = "EVENT_TASK_ID = " & ThisEventTaskId
                            Dim DtOtherEmps As New DataTable
                            DtOtherEmps = dv.ToTable()
                            If DtOtherEmps.Rows.Count > 0 Then
                                e.DetailTableView.DataSource = dv.ToTable()
                            Else 'no emps available...get all emps with that role....
                                Try
                                    Dim start_time As DateTime = CType(CType(parentItem.FindControl("HfSTART_TIME"), HiddenField).Value, DateTime)
                                    Dim end_time As DateTime = CType(CType(parentItem.FindControl("HfEND_TIME"), HiddenField).Value, DateTime)
                                    Dim task_trf_code As String = CType(parentItem.FindControl("HfTRF_TASK_CODE"), HiddenField).Value
                                    Dim r As New cResources()
                                    'If end_time.ToShortTimeString() = "12:00 AM" And (start_time.ToShortDateString() = end_time.ToShortDateString()) Then
                                    If end_time.ToShortTimeString() = "12:00 AM" And Me.FromForm = 0 Then
                                        end_time = DateAdd(DateInterval.Minute, -1, end_time)
                                    End If
                                    'Dim DV2 As DataView = New DataView(r.FindAvailableEmployees(task_trf_code, start_time, end_time, Me.FromForm))
                                    'DV2.Sort = "HRS_AVAIL DESC, SENIORITY DESC"
                                    e.DetailTableView.DataSource = r.FindAvailableEmployees(task_trf_code, start_time, end_time, Me.FromForm)
                                Catch ex As Exception
                                    '...THIS SHOULD JUST END UP SHOWING "NO RECORDS"
                                    e.DetailTableView.DataSource = dv.ToTable()
                                End Try
                            End If
                        Catch ex As Exception
                        End Try
                End Select
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridAvailableEmployees_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAvailableEmployees.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Me.LblMSG_Grid.Text = ""
        Dim arP(1) As SqlParameter
        Select Case e.CommandName
            Case Telerik.Web.UI.RadGrid.ExpandCollapseCommandName
                For Each thisItem As Telerik.Web.UI.GridItem In e.Item.OwnerTableView.Items
                    If thisItem.Expanded And thisItem.ItemIndex <> e.Item.ItemIndex Then
                        thisItem.Expanded = False
                    ElseIf thisItem.Expanded = True And thisItem.ItemIndex = e.Item.ItemIndex Then
                        Me.HfSingleCollapsedItemIndex.Value = ""
                    ElseIf thisItem.Expanded = False And thisItem.ItemIndex = e.Item.ItemIndex Then
                        Me.HfSingleCollapsedItemIndex.Value = e.Item.ItemIndexHierarchical.ToString()
                    End If
                Next
            Case "SaveRowEmp" 'This is the disk icon on the parent row
                Try
                    Dim SelectedEmp As String = ""

                    Dim parentRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAvailableEmployees.MasterTableView.Items(index), Telerik.Web.UI.GridDataItem)
                    Try
                        SelectedEmp = CType(parentRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text.Trim()
                    Catch ex As Exception
                        SelectedEmp = ""
                    End Try
                    If SelectedEmp = "" Then
                        Try
                            SelectedEmp = CType(parentRow.FindControl("HfEMP_CODE_FIRST_CHOICE"), HiddenField).Value.Trim()
                        Catch ex As Exception
                            SelectedEmp = ""
                        End Try
                    End If

                    Dim ThisEvtTskId As Integer = 0
                    Try
                        ThisEvtTskId = CType(CType(parentRow.FindControl("HfEVENT_TASK_ID"), HiddenField).Value.Trim(), Integer)
                    Catch ex As Exception
                        ThisEvtTskId = 0
                    End Try
                    'update the record
                    If ThisEvtTskId = 0 Then
                        Exit Sub
                    End If
                    Dim StrUpdate As String = ""

                    Dim ThisDate As DateTime = Nothing
                    Dim ThisStart As DateTime = Nothing
                    Dim ThisEnd As DateTime = Nothing

                    Try
                        ThisDate = CType(CType(parentRow.FindControl("HfEVENT_TASK_DATE"), HiddenField).Value.Trim(), DateTime)
                    Catch ex As Exception
                        ThisDate = Nothing
                    End Try
                    Try
                        ThisStart = CType(CType(parentRow.FindControl("HfSTART_TIME"), HiddenField).Value.Trim(), DateTime)
                    Catch ex As Exception
                        ThisStart = Nothing
                    End Try
                    Try
                        ThisEnd = CType(CType(parentRow.FindControl("HfEND_TIME"), HiddenField).Value.Trim(), DateTime)
                    Catch ex As Exception
                        ThisEnd = Nothing
                    End Try

                    If SelectedEmp <> "" Then
                        Dim EmpIsBooked As Boolean = False
                        Dim ValidEmp As Boolean = False
                        Dim v As New cValidations(Session("ConnString"))
                        ValidEmp = v.ValidateEmpCodetd(SelectedEmp)
                        If Not ThisDate = Nothing And Not ThisStart = Nothing And Not ThisEnd = Nothing Then
                            Dim r As New cResources()
                            EmpIsBooked = r.EmployeeIsBooked(SelectedEmp, ThisEvtTskId, ThisDate, ThisStart, ThisEnd, )
                        End If
                        If EmpIsBooked = True Or ValidEmp = False Then
                            Me.LblMSG_Grid.Text = "Employee invalid/booked"
                            CType(parentRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Focus()
                            Exit Sub
                        End If
                    End If

                    If Me.FromForm = 0 Then
                        If SelectedEmp <> "" Then
                            StrUpdate = "UPDATE EVENT_TASK WITH(ROWLOCK) SET EMP_CODE = '" & SelectedEmp & "' WHERE EVENT_TASK_ID = " & ThisEvtTskId.ToString()
                        Else
                            StrUpdate = "UPDATE EVENT_TASK WITH(ROWLOCK) SET EMP_CODE = NULL WHERE EVENT_TASK_ID = " & ThisEvtTskId.ToString()
                        End If
                    End If
                    If Me.FromForm = 1 Then
                        Dim ThisSeqNbr As Integer = -1
                        Dim ThisHrs As Decimal = 0.0

                        Try
                            ThisSeqNbr = CType(CType(parentRow.FindControl("HfSEQ_NBR"), HiddenField).Value.Trim(), Integer)
                        Catch ex As Exception
                            ThisSeqNbr = -1
                        End Try
                        Try
                            ThisHrs = CType(CType(parentRow.FindControl("HfEVENT_TASK_HOURS_ALLOWED"), HiddenField).Value.Trim(), Decimal)
                        Catch ex As Exception
                            ThisHrs = 0
                        End Try
                        If SelectedEmp <> "" And ThisSeqNbr > -1 Then
                            StrUpdate = "INSERT INTO JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) (JOB_NUMBER, JOB_COMPONENT_NBR, SEQ_NBR, EMP_CODE, HOURS_ALLOWED) VALUES (" & Me.JobNumber.ToString() & ", " & Me.JobComponentNbr.ToString() & ", " & ThisSeqNbr & ", '" & SelectedEmp & "', @ROW_HOURS);"
                            Dim parameterROW_HOURS As New SqlParameter("@ROW_HOURS", SqlDbType.Decimal)
                            parameterROW_HOURS.Value = ThisHrs
                            arP(0) = parameterROW_HOURS
                            'ElseIf SelectedEmp = "" And ThisSeqNbr > 0 Then
                            '    StrUpdate = "DELETE FROM JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) WHERE JOB_NUMBER = 98 AND JOB_COMPONENT_NBR = 1 AND EMP_CODE = 'ama';"
                        End If
                    End If


                    Try
                        SqlHelper.ExecuteNonQuery(Session("ConnString"), CommandType.Text, StrUpdate, arP)
                        'Using MyConn As New SqlConnection(Session("ConnString"))
                        '    MyConn.Open()
                        '    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        '    Dim MyCmd As New SqlCommand(StrUpdate, MyConn, MyTrans)
                        '    Try
                        '        MyCmd.ExecuteNonQuery()
                        '        MyTrans.Commit()
                        '    Catch ex As Exception
                        '        MyTrans.Rollback()
                        '    Finally
                        '        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        '    End Try
                        'End Using
                    Catch ex As Exception
                    End Try
                    'rebind the grid
                    Me.RadGridAvailableEmployees.Rebind()
                    Select Case Me.FromForm
                        Case 0
                            Me.RefreshCaller("Event_View.aspx")
                        Case 1
                            Me.RefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
                    End Select

                Catch ex As Exception
                End Try
            Case "AddEmpToTask" 'this is on the child row (list of emps) (the plus sign)
                Try
                    Dim SelectedEmp As String = ""
                    Dim parentRow As Telerik.Web.UI.GridDataItem = CType(e.Item.OwnerTableView.ParentItem, Telerik.Web.UI.GridDataItem)
                    Dim CurrentEventTaskId As Integer = 0
                    Try
                        SelectedEmp = e.CommandArgument
                    Catch ex As Exception
                        SelectedEmp = ""
                    End Try
                    Try
                        CurrentEventTaskId = CType(CType(parentRow.FindControl("HfEVENT_TASK_ID"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        CurrentEventTaskId = 0
                    End Try
                    If Me.FromForm = 0 Then
                        '''If CurrentEventTaskId > 0 And SelectedEmp <> "" Then
                        '''    'VALIDATE EMP!
                        '''    Dim v As New cValidations(Session("ConnString"))
                        '''    If v.ValidateEmpCodetd(SelectedEmp) = False Then
                        '''        Exit Sub
                        '''    End If
                        '''    Dim StrUpdate As String = "UPDATE EVENT_TASK WITH(ROWLOCK) SET EMP_CODE = '" & SelectedEmp & "' WHERE EVENT_TASK_ID = " & CurrentEventTaskId.ToString()
                        '''    Try
                        '''        Using MyConn As New SqlConnection(Session("ConnString"))
                        '''            MyConn.Open()
                        '''            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                        '''            Dim MyCmd As New SqlCommand(StrUpdate, MyConn, MyTrans)
                        '''            Try
                        '''                MyCmd.ExecuteNonQuery()
                        '''                MyTrans.Commit()
                        '''            Catch ex As Exception
                        '''                MyTrans.Rollback()
                        '''            Finally
                        '''                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        '''            End Try
                        '''        End Using
                        '''    Catch ex As Exception
                        '''    End Try
                        '''    'rebind the grid
                        '''    Me.RadGridAvailableEmployees.Rebind()
                        '''End If
                        ''''If CurrentEventTaskId > 0 And SelectedEmp <> "" Then
                        ''''    Dim v As New cValidations(Session("ConnString"))
                        ''''    If v.ValidateEmpCodetd(SelectedEmp) = False Then
                        ''''        Exit Sub
                        ''''    End If

                        ''''End If

                    ElseIf Me.FromForm = 1 Then

                    End If
                    Try
                        CType(parentRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text = e.CommandArgument.ToString()
                    Catch ex As Exception

                    End Try
                Catch ex As Exception
                End Try
            Case "RestoreRecommended"

        End Select
    End Sub

    Private Sub RadGridAvailableEmployees_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAvailableEmployees.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim tb As System.Web.UI.WebControls.TextBox
                'emp code lookup:
                Try
                    tb = CType(dataItem.FindControl("TxtCURR_EMP_CODE"), TextBox)
                    tb.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&control=" & tb.ClientID & "&type=empcode');return false;")
                Catch ex As Exception
                End Try

            Catch ex As Exception
                'main try
            End Try
        End If
    End Sub

    Private Sub RadGridAvailableEmployees_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAvailableEmployees.NeedDataSource
        Me.SetQSVars()
        'If Not Me.IsPostBack And Not Me.IsCallback Then
        'End If
        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 And Me.DropFilterRole.SelectedIndex > 0 Then
            If DsMain Is Nothing Then
                Dim r As New cResources()
                DsMain = r.FindAvailableEmployees(FromForm, Me.DropFilterRole.SelectedValue, Me.JobNumber, Me.JobComponentNbr, Nothing, Nothing, False)
            End If
            Me.LblPleaseSelect.Visible = False
            Dim dv As New DataView
            dv = DsMain.Tables(0).DefaultView
            'dv.RowFilter = "TRF_ROLE_CODE = '" & DropFilterRole.SelectedValue & "'"
            Me.RadGridAvailableEmployees.DataSource = dv
            Me.RadGridAvailableEmployees.Visible = True

            If DropFilterRole.SelectedValue = "" Then
                Me.RadGridAvailableEmployees.MasterTableView.GetColumn("ColTRF_ROLE_CODE").Visible = True
            Else
                Me.RadGridAvailableEmployees.MasterTableView.GetColumn("ColTRF_ROLE_CODE").Visible = False
            End If

        Else
            Me.LblPleaseSelect.Visible = True
            Me.RadGridAvailableEmployees.Visible = False
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            If IsNumeric(Request.QueryString("from")) = True Then
                FromForm = CType(Request.QueryString("from"), Integer)
            End If
        Catch ex As Exception
            FromForm = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("j")) = True Then
                JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
            JobNumber = 0
        End Try
        Try
            If IsNumeric(Request.QueryString("jc")) = True Then
                JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
            JobComponentNbr = 0
        End Try
        Try
            CliCode = Request.QueryString("cli").ToString()
        Catch ex As Exception
            CliCode = ""
        End Try
        Try
            CutOff = CType(Request.QueryString("cod"), DateTime)
        Catch ex As Exception
            CutOff = Nothing
        End Try
        Try
            If IsNumeric(Request.QueryString("g")) = True Then
                GenId = CType(Request.QueryString("g"), Integer)
            End If
        Catch ex As Exception
            GenId = 0
        End Try


        If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
            Select Case Me.FromForm
                Case 0
                    Me.Title = "Employee Finder - Event Tasks for Job/Comp: " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
                Case 1
                    Me.Title = "Employee Finder - Project Schedule Tasks for Job/Comp: " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
            End Select
        End If
    End Sub

    'the child grid "itemdatabound"
    Private Sub RadGridAvailableEmployees_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAvailableEmployees.PreRender
        Dim gtv As Telerik.Web.UI.GridTableView
        'RadGridAvailableEmployees
        For i As Integer = 0 To Me.RadGridAvailableEmployees.MasterTableView.Items.Count - 1
            ''maintain single expand
            If IsNumeric(Me.HfSingleExpandedItemIndex.Value) = True Then
                If i = CType(Me.HfSingleExpandedItemIndex.Value, Integer) Then
                    Me.RadGridAvailableEmployees.MasterTableView.Items(i).Expanded = True
                Else
                    Me.RadGridAvailableEmployees.MasterTableView.Items(i).Expanded = False
                End If
            End If

            For j As Integer = 0 To Me.RadGridAvailableEmployees.MasterTableView.Items(i).ChildItem.NestedTableViews.Length - 1
                gtv = CType(Me.RadGridAvailableEmployees.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem).ChildItem.NestedTableViews(j)
                'dataItem is the child rows...
                For Each dataItem As Telerik.Web.UI.GridDataItem In gtv.Items
                    If dataItem.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or dataItem.ItemType = Telerik.Web.UI.GridItemType.Item Then
                        'set "available for" hours indicator
                        Try
                            If IsNumeric(dataItem.Cells(6).Text) = True Then
                                Dim h As Decimal = CType(dataItem.Cells(6).Text, Decimal)
                                If h <= 0 Then
                                    'background red
                                    dataItem.Cells(6).CssClass = "standard-red"
                                End If
                                dataItem.Cells(6).Text = FormatNumber(h, 2, TriState.True, TriState.False, TriState.True)
                            Else
                                dataItem.Cells(6).Text = "0.00"
                            End If
                        Catch ex As Exception
                        End Try

                        'set "from" and "to"
                        Dim ParentItem As Telerik.Web.UI.GridDataItem = CType(dataItem.OwnerTableView.ParentItem, Telerik.Web.UI.GridDataItem)

                        Dim ParentStartTime As DateTime = Nothing
                        Dim ParentEndTime As DateTime = Nothing
                        Dim ThisStartTime As DateTime = Nothing
                        Dim ThisEndTime As DateTime = Nothing
                        'start time of the task
                        Try
                            ParentStartTime = MiscFN.NormalizeDate(Convert.ToDateTime(CType(ParentItem.FindControl("HfSTART_TIME"), HiddenField).Value))
                        Catch ex As Exception
                            ParentStartTime = Nothing
                        End Try
                        'end time of the task
                        Try
                            ParentEndTime = MiscFN.NormalizeDate(Convert.ToDateTime(CType(ParentItem.FindControl("HfEND_TIME"), HiddenField).Value))
                        Catch ex As Exception
                            ParentEndTime = Nothing
                        End Try
                        'start time of the employee availability
                        Try
                            If cGlobals.wvIsDate(dataItem.Cells(7).Text) = True Then
                                ThisStartTime = MiscFN.NormalizeDate(Convert.ToDateTime(dataItem.Cells(7).Text))
                                dataItem.Cells(7).Text = ThisStartTime.ToShortTimeString()
                            Else
                                dataItem.Cells(7).Text = "--"
                            End If
                        Catch ex As Exception
                            ThisStartTime = Nothing
                        End Try
                        'end time of the employee availability
                        Try
                            If cGlobals.wvIsDate(dataItem.Cells(8).Text) = True Then
                                ThisEndTime = MiscFN.NormalizeDate(Convert.ToDateTime(dataItem.Cells(8).Text))
                                dataItem.Cells(8).Text = ThisEndTime.ToShortTimeString()
                            Else
                                dataItem.Cells(8).Text = "--"
                            End If
                        Catch ex As Exception
                            ThisEndTime = Nothing
                        End Try
                        'show/hide the start/end columns?
                        If Me.FromForm = 1 Then
                            Try
                                dataItem.OwnerTableView.GetColumn("ColEMP_START_TIME").Display = False
                                dataItem.OwnerTableView.GetColumn("ColEMP_END_TIME").Display = False
                            Catch ex As Exception
                            End Try
                        End If



                        'show icon if the emp is the recommended
                        Dim Parent_RecommendedEmp As String = ""
                        Dim Child_CurrentEmp As String = ""
                        Try
                            Parent_RecommendedEmp = CType(ParentItem.FindControl("HfEMP_CODE_FIRST_CHOICE"), HiddenField).Value
                        Catch ex As Exception
                            Parent_RecommendedEmp = ""
                        End Try
                        Try
                            Child_CurrentEmp = dataItem.Cells(3).Text 'i think this is the emp code in the child grid...
                        Catch ex As Exception
                            Child_CurrentEmp = ""
                        End Try
                        Dim IsMatch As Boolean = False
                        If Parent_RecommendedEmp <> "" And Child_CurrentEmp <> "" Then
                            If Parent_RecommendedEmp.Trim() = Child_CurrentEmp.Trim() Then
                                IsMatch = True
                            End If
                        End If
                        'one final one
                        If IsMatch = False Then

                        End If
                        Try
                            Dim hf As System.Web.UI.WebControls.HiddenField = CType(dataItem.FindControl("HfIS_FIRST_CHOICE"), HiddenField)
                            Dim IsFirstChoiceDiv As HtmlControls.HtmlControl = CType(dataItem.FindControl("DivIsFirstChoice"), HtmlControls.HtmlControl)

                            If hf.Value = "1" Or hf.Value = "True" Or IsMatch = True Then

                                IsFirstChoiceDiv.Attributes.Add("title", "Recommended")

                            Else

                                AdvantageFramework.Web.Presentation.Controls.DivHide(IsFirstChoiceDiv)

                            End If
                        Catch ex As Exception

                        End Try


                        '''only do comparison if all info is available:
                        ''If Not ParentStartTime = Nothing And Not ParentEndTime = Nothing And Not ThisStartTime = Nothing And Not ThisEndTime = Nothing Then
                        ''    If ParentStartTime < ThisStartTime And ParentEndTime < ThisStartTime Then 'the task is completely before emp's available hours
                        ''        dataItem.Cells(6).CssClass = "standard-red"
                        ''    ElseIf ParentStartTime > ThisStartTime And ParentEndTime > ThisStartTime Then 'the task is completely after emp's available hours
                        ''        dataItem.Cells(7).CssClass = "standard-red"
                        ''    End If
                        ''End If
                        If Not ParentStartTime = Nothing And Not ParentEndTime = Nothing And Not ThisStartTime = Nothing And Not ThisEndTime = Nothing Then
                            'If Date.Compare(ParentStartTime, ThisStartTime) > 0 And Date.Compare(ParentEndTime, ThisStartTime) > 0 Then 'the task is completely before emp's available hours
                            '    dataItem.Cells(6).CssClass = "standard-red"
                            'ElseIf Date.Compare(ParentStartTime, ThisEndTime) < 0 And Date.Compare(ParentEndTime, ThisEndTime) < 0 Then 'the task is completely after emp's available hours
                            '    dataItem.Cells(7).CssClass = "standard-red"
                            'ElseIf Date.Compare(ParentStartTime, ThisStartTime) > 0 And Date.Compare(ParentEndTime, ThisEndTime) <= 0 Then 'the task starts before emp starts but ends within emp end 
                            '    dataItem.Cells(6).CssClass = "standard-yellow"
                            'End If
                            If Date.Compare(ParentStartTime, ThisStartTime) > 0 And Date.Compare(ParentEndTime, ThisStartTime) > 0 Then

                            End If
                        End If
                    End If
                Next
            Next
        Next
    End Sub

    Private Sub Resources_Emps_Find_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not Me.IsPostBack And Not Me.IsCallback Then
            'If Not DsMain Is Nothing Then
            '    With Me.DropFilterRole
            '        .DataSource = DsMain.Tables(2)
            '        .DataTextField = "ROLE_DESC"
            '        .DataValueField = "TRF_ROLE_CODES"
            '        .DataBind()
            '    End With
            'End If
        End If

        If Me.LblMSG_Grid.Text = "" Then
            Me.LblMSG_Grid.Visible = False
        Else
            Me.LblMSG_Grid.Visible = True
        End If
        Select Case Me.FromForm
            Case 0 'event tasks
                With Me.RadGridAvailableEmployees.MasterTableView
                    .GetColumn("ColEVENT_ID").Display = True
                    .GetColumn("ColEVENT_TASK_DESC").Display = True
                    .GetColumn("ColSTART_TIME").Display = True
                    .GetColumn("ColEND_TIME").Display = True
                    .GetColumn("ColEND_DATE").Display = False
                End With
                Me.RadToolbarEventTasks.FindItemByValue("GroupBy").Visible = True
            Case 1 'project tasks
                With Me.RadGridAvailableEmployees.MasterTableView
                    .GetColumn("ColEVENT_ID").Display = False
                    .GetColumn("ColEVENT_TASK_DESC").Display = False
                    .GetColumn("ColSTART_TIME").Display = False
                    .GetColumn("ColEND_TIME").Display = False
                    .GetColumn("ColEND_DATE").Display = True
                End With
                Me.RadToolbarEventTasks.FindItemByValue("GroupBy").Visible = False
        End Select


    End Sub

    Private Sub DropFilterRole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropFilterRole.SelectedIndexChanged
        Me.RadGridAvailableEmployees.Rebind()
    End Sub

    Private Sub DropGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropGroupBy.SelectedIndexChanged
        Try
            Select Case Me.DropGroupBy.SelectedValue
                Case "none"
                    Me.RadGridAvailableEmployees.MasterTableView.GroupByExpressions.Clear()
                Case "event"
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("EVENT_ID Event-ID Group By EVENT_ID")
                    With Me.RadGridAvailableEmployees
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case "task"
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("TRF_TASK_CODE Task-Code Group By TRF_TASK_CODE")
                    With Me.RadGridAvailableEmployees
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case "date"
                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("TEXT_START Date Group By TEXT_START")
                    With Me.RadGridAvailableEmployees
                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True
                    End With
                Case Else
                    Me.RadGridAvailableEmployees.MasterTableView.GroupByExpressions.Clear()
            End Select
            Me.RadGridAvailableEmployees.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CloseWindow()
        'Select Case FromForm
        '    Case 0
        '        Me.CloseThisWindowAndRefreshCaller("Event_View.aspx?from=0&j=" & JobNumber & "&jc=" & JobComponentNbr & "&cli=" & CliCode & "&cod=" & Me.CutOff & "&g=" & Me.GenId, True)
        '    Case 1
        '        Me.CloseThisWindowAndRefreshCaller("TrafficSchedule.aspx")
        '    Case Else
        Me.CloseThisWindow()
        'End Select
    End Sub
    Private Sub RadToolbarEventTasks_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarEventTasks.ButtonClick
        Select Case e.Item.Value
            Case "CloseWindow" ' the "back button
                Me.CloseWindow()
            Case "Save"
                If Me.SaveTasksGrid() = True Then
                    Me.RadGridAvailableEmployees.Rebind()
                    'Me.CloseWindow()
                    Select Case Me.FromForm
                        Case 0
                            Me.RefreshCaller("Event_View.aspx")
                        Case 1
                            Me.RefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
                    End Select

                    Me.CloseThisWindow()
                End If
            Case "ClearEmployees"
                Dim RowCount As Integer = Me.RadGridAvailableEmployees.MasterTableView.Items.Count
                If RowCount > 0 Then
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                        CType(CurrentGridRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text = ""
                    Next
                End If
            Case "ApplyRecommended"
                Dim RowCount As Integer = Me.RadGridAvailableEmployees.MasterTableView.Items.Count
                If RowCount > 0 Then
                    For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                        Dim RecommendedEmp As String = ""
                        Try
                            RecommendedEmp = CType(CurrentGridRow.FindControl("HfEMP_CODE_FIRST_CHOICE"), HiddenField).Value
                        Catch ex As Exception
                            RecommendedEmp = ""
                        End Try
                        Dim CurrEmp As String = ""
                        Try
                            CurrEmp = CType(CurrentGridRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text
                        Catch ex As Exception
                            CurrEmp = ""
                        End Try
                        'only replace if one isn't already saved:
                        If CurrEmp = "" And RecommendedEmp <> "" Then
                            CType(CurrentGridRow.FindControl("TxtCURR_EMP_CODE"), TextBox).Text = RecommendedEmp
                        End If
                    Next
                    If Me.SaveTasksGrid() = True Then
                        Me.RadGridAvailableEmployees.Rebind()
                        'Me.CloseWindow()
                        Select Case Me.FromForm
                            Case 0
                                Me.RefreshCaller("Event_View.aspx")
                            Case 1
                                Me.RefreshCaller(Webvantage.Controllers.ProjectManagement.ProjectScheduleController.BaseRoute & "Index")
                        End Select

                        Me.CloseThisWindow()
                    End If
                    'Me.CloseThisWindow()
                End If
            Case "DeleteEventTasks"
                Dim RowCount As Integer = Me.RadGridAvailableEmployees.MasterTableView.Items.Count
                If RowCount > 0 Then
                    Dim SbDelete As New System.Text.StringBuilder
                    Dim SbDelete2 As New System.Text.StringBuilder
                    Dim SbDelete3 As New System.Text.StringBuilder
                    Dim StrDelete As String = ""
                    Dim StrDelete2 As String = ""
                    Dim StrDelete3 As String = ""
                    Dim chk As CheckBox
                    Dim DoDelete As Boolean = False

                    If Me.FromForm = 0 Then
                        SbDelete.Append("DELETE FROM [EVENT_TASK] WITH(ROWLOCK) WHERE EVENT_TASK_ID IN (")
                        For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                            chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                If IsNumeric(CurrentGridRow.GetDataKeyValue("EVENT_TASK_ID")) Then
                                    SbDelete.Append(CType(CurrentGridRow.GetDataKeyValue("EVENT_TASK_ID"), Integer).ToString())
                                    SbDelete.Append(",")
                                    DoDelete = True
                                End If
                            End If
                        Next

                        StrDelete = SbDelete.ToString()
                        StrDelete = MiscFN.RemoveTrailingDelimiter(StrDelete, ",")
                        StrDelete &= ");"
                    End If
                    If Me.FromForm = 1 Then
                        SbDelete.Append("DELETE FROM [JOB_TRAFFIC_DET_PREDS] WITH(ROWLOCK) WHERE JOB_NUMBER = ")
                        SbDelete.Append(Me.JobNumber.ToString())
                        SbDelete.Append(" AND JOB_COMPONENT_NBR = ")
                        SbDelete.Append(Me.JobComponentNbr.ToString())
                        SbDelete.Append(" AND SEQ_NBR IN (")
                        For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                            chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                If IsNumeric(CurrentGridRow.GetDataKeyValue("SEQ_NBR")) Then
                                    SbDelete.Append(CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer).ToString())
                                    SbDelete.Append(",")
                                    DoDelete = True
                                End If
                            End If
                        Next

                        StrDelete = SbDelete.ToString()
                        StrDelete = MiscFN.RemoveTrailingDelimiter(StrDelete, ",")
                        StrDelete &= ");"

                        SbDelete2.Append("DELETE FROM [JOB_TRAFFIC_DET_EMPS] WITH(ROWLOCK) WHERE JOB_NUMBER = ")
                        SbDelete2.Append(Me.JobNumber.ToString())
                        SbDelete2.Append(" AND JOB_COMPONENT_NBR = ")
                        SbDelete2.Append(Me.JobComponentNbr.ToString())
                        SbDelete2.Append(" AND SEQ_NBR IN (")
                        For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                            chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                If IsNumeric(CurrentGridRow.GetDataKeyValue("SEQ_NBR")) Then
                                    SbDelete2.Append(CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer).ToString())
                                    SbDelete2.Append(",")
                                    DoDelete = True
                                End If
                            End If
                        Next

                        StrDelete2 = SbDelete2.ToString()
                        StrDelete2 = MiscFN.RemoveTrailingDelimiter(StrDelete2, ",")
                        StrDelete2 &= ");"

                        SbDelete3.Append("DELETE FROM [JOB_TRAFFIC_DET] WITH(ROWLOCK) WHERE JOB_NUMBER = ")
                        SbDelete3.Append(Me.JobNumber.ToString())
                        SbDelete3.Append(" AND JOB_COMPONENT_NBR = ")
                        SbDelete3.Append(Me.JobComponentNbr.ToString())
                        SbDelete3.Append(" AND SEQ_NBR IN (")
                        For Each CurrentGridRow As Telerik.Web.UI.GridDataItem In Me.RadGridAvailableEmployees.MasterTableView.Items
                            chk = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                            If chk.Checked = True Then
                                If IsNumeric(CurrentGridRow.GetDataKeyValue("SEQ_NBR")) Then
                                    SbDelete3.Append(CType(CurrentGridRow.GetDataKeyValue("SEQ_NBR"), Integer).ToString())
                                    SbDelete3.Append(",")
                                    DoDelete = True
                                End If
                            End If
                        Next

                        StrDelete3 = SbDelete3.ToString()
                        StrDelete3 = MiscFN.RemoveTrailingDelimiter(StrDelete3, ",")
                        StrDelete3 &= ");"
                    End If

                    StrDelete = StrDelete & StrDelete2 & StrDelete3

                    If DoDelete = True Then
                        Using MyConn As New SqlConnection(Session("ConnString"))
                            MyConn.Open()
                            Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                            Dim MyCmd As New SqlCommand(StrDelete, MyConn, MyTrans)
                            Try
                                MyCmd.ExecuteNonQuery()
                                MyTrans.Commit()
                            Catch ex As Exception
                                MyTrans.Rollback()
                            Finally
                                If MyConn.State = ConnectionState.Open Then MyConn.Close()
                            End Try
                        End Using
                        Me.RadGridAvailableEmployees.Rebind()
                    End If


                End If

            Case "Print"
                Me.OpenWindow("", "Resources_Emps_QuickPrint.aspx?f=" & Me.FromForm.ToString() & "&j=" & Me.JobNumber & "&jc=" & Me.JobComponentNbr & "&cli=" & Me.CliCode, 800, 900)
        End Select
    End Sub
End Class
