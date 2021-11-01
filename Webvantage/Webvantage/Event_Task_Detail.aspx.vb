Imports Webvantage.cGlobals
Imports System.Data.SqlClient

Partial Class Event_Task_Detail
    Inherits Webvantage.BaseChildPage

    Private EventId As Integer = 0
    Private EventTaskId As Integer = 0
    Private AllowFormEdit As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Me.SetQSVars()
            Me.LoadEventTask()
            Me.SetEdit()
        End If
    End Sub

    Private Sub LoadEventTask()
        If EventTaskId > 0 Then
            Dim evt As New cEvents()
            Dim dt As New DataTable
            dt = evt.TaskGetDetails(Me.EventTaskId)
            If dt.Rows.Count > 0 Then
                If IsDBNull(dt.Rows(0)("OFFICE")) = False Then
                    Me.LblOffice.Text = dt.Rows(0)("OFFICE").ToString()
                End If
                If IsDBNull(dt.Rows(0)("CLIENT")) = False Then
                    Me.LblClient.Text = dt.Rows(0)("CLIENT").ToString()
                End If
                If IsDBNull(dt.Rows(0)("DIVISION")) = False Then
                    Me.LblDivision.Text = dt.Rows(0)("DIVISION").ToString()
                End If
                If IsDBNull(dt.Rows(0)("PRODUCT")) = False Then
                    Me.LblProduct.Text = dt.Rows(0)("PRODUCT").ToString()
                End If
                If IsDBNull(dt.Rows(0)("JOB")) = False Then
                    Me.LblJob.Text = dt.Rows(0)("JOB").ToString()
                End If
                If IsDBNull(dt.Rows(0)("JOB_COMPONENT")) = False Then
                    Me.LblJobComp.Text = dt.Rows(0)("JOB_COMPONENT").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT")) = False Then
                    Me.LblEvent.Text = dt.Rows(0)("EVENT").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_TRF_CODE")) = False Then
                    Me.TxtTrfFncCode.Text = dt.Rows(0)("EVENT_TASK_TRF_CODE").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_TRF_DESC")) = False Then
                    Me.TxtTrfFncDescription.Text = dt.Rows(0)("EVENT_TASK_TRF_DESC").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_START_DATE")) = False Then
                    Me.RadDatePickerEventTaskDate.SelectedDate = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_START_DATE"))
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_START_TIME")) = False Then
                    Me.RadMaskedTxtStartTime.Text = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_START_TIME")).ToShortTimeString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_END_TIME")) = False Then
                    Me.RadMaskedTxtEndTime.Text = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_END_TIME")).ToShortTimeString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_EMP_CODE")) = False Then
                    Me.TxtEmpCode.Text = dt.Rows(0)("EVENT_TASK_EMP_CODE").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_EMP_FML_NAME")) = False Then
                    Me.TxtEmpFML.Text = dt.Rows(0)("EVENT_TASK_EMP_FML_NAME").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_HOURS_ALLOWED")) = False Then
                    Me.TxtHours.Text = FormatNumber(dt.Rows(0)("EVENT_TASK_HOURS_ALLOWED"), 2, TriState.False, TriState.False, TriState.True)
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_COMMENTS")) = False Then
                    Me.TxtComments.Text = dt.Rows(0)("EVENT_TASK_COMMENTS").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_TEMP_COMP_DATE")) = False Then
                    Me.RadDatePickerCompletedDate.SelectedDate = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_TEMP_COMP_DATE"))
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_COMPLETED_COMMENTS")) = False Then
                    Me.TxtCompletedComments.Text = dt.Rows(0)("EVENT_TASK_COMPLETED_COMMENTS").ToString()
                End If
                'do the labels:
                If IsDBNull(dt.Rows(0)("EVENT_TASK_TRF")) = False Then
                    Me.LblTrfFncCode.Text = dt.Rows(0)("EVENT_TASK_TRF").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_START_DATE")) = False Then
                    Me.LblEventTaskDate.Text = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_START_DATE")).ToShortDateString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_START_TIME")) = False Then
                    Me.LblStartTime.Text = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_START_TIME")).ToShortTimeString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_END_TIME")) = False Then
                    Me.LblEndTime.Text = Convert.ToDateTime(dt.Rows(0)("EVENT_TASK_END_TIME")).ToShortTimeString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_EMPLOYEE")) = False Then
                    Me.LblEmpCode.Text = dt.Rows(0)("EVENT_TASK_EMPLOYEE").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_COMMENTS")) = False Then
                    Me.LblComments.Text = dt.Rows(0)("EVENT_TASK_COMMENTS").ToString()
                End If
                If IsDBNull(dt.Rows(0)("EVENT_TASK_HOURS_ALLOWED")) = False Then
                    Me.LblHours.Text = FormatNumber(dt.Rows(0)("EVENT_TASK_HOURS_ALLOWED"), 2, TriState.False, TriState.False, TriState.True)
                End If
            End If
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            EventTaskId = CType(Request.QueryString("etid"), Integer)
        Catch ex As Exception
            EventTaskId = 0
        End Try
    End Sub

    Private Sub SetEdit()
        Me.LblTrfFncCode.Visible = Not AllowFormEdit
        Me.TxtTrfFncCode.Visible = AllowFormEdit
        Me.TxtTrfFncDescription.Visible = AllowFormEdit

        Me.LblEventTaskDate.Visible = Not AllowFormEdit
        Me.RadDatePickerEventTaskDate.Visible = AllowFormEdit
        Me.LblStartTime.Visible = Not AllowFormEdit
        Me.RadMaskedTxtStartTime.Visible = AllowFormEdit

        Me.LblEndTime.Visible = Not AllowFormEdit
        Me.RadMaskedTxtEndTime.Visible = AllowFormEdit

        Me.LblEmpCode.Visible = Not AllowFormEdit
        Me.TxtEmpCode.Visible = AllowFormEdit
        Me.TxtEmpFML.Visible = AllowFormEdit

        Me.LblHours.Visible = Not AllowFormEdit
        Me.TxtHours.Visible = AllowFormEdit

        Me.LblComments.Visible = Not AllowFormEdit
        Me.TxtComments.Visible = AllowFormEdit

    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'just do a quick save for now...
        Me.SetQSVars()

        If MiscFN.ValidDate(Me.RadDatePickerCompletedDate, True) = False Then
            Me.ShowMessage("Invalid Completed Date")
            Exit Sub
        End If

        Dim SQL As String = "UPDATE EVENT_TASK WITH(ROWLOCK) SET TEMP_COMP_DATE = @TempCompDate, COMPLETED_COMMENTS = @CompletedComments WHERE EVENT_TASK_ID = @EventTaskId"
        Try
            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                MyConn.Open()
                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                Dim MyCmd As New SqlCommand(SQL, MyConn, MyTrans)
                With MyCmd
                    If MiscFN.ValidDate(RadDatePickerCompletedDate) = False Then
                        .Parameters.AddWithValue("@TempCompDate", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@TempCompDate", cGlobals.wvCDate(Me.RadDatePickerCompletedDate.SelectedDate))
                    End If
                    If Me.TxtCompletedComments.Text.Trim() = "" Then
                        .Parameters.AddWithValue("@CompletedComments", DBNull.Value)
                    Else
                        .Parameters.AddWithValue("@CompletedComments", Me.TxtCompletedComments.Text.Trim())
                    End If
                    .Parameters.AddWithValue("@EventTaskId", Me.EventTaskId)
                End With
                Try
                    MyCmd.ExecuteNonQuery()
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                    Me.LblMSG.Text = "Transaction error:  " & ex.Message.ToString()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
            Me.LblMSG.Text = "Save error:  " & ex.Message.ToString()
        End Try
    End Sub
End Class