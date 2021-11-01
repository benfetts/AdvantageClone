Public Partial Class Resources_Emps_QuickPrint
    Inherits System.Web.UI.Page

    Private FromForm As Integer = 0
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private CliCode As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetQSVars()
        If Not Me.IsPostBack Then
            If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                Dim evt As New cEvents()

                If Me.FromForm = 0 Then
                    Me.GridViewQuickPrint_PS.Visible = False
                    With Me.GridViewQuickPrint_Event
                        .Visible = True
                        .DataSource = evt.EventTasksDatatable(Me.JobNumber, Me.JobComponentNbr)
                        .DataBind()
                    End With
                ElseIf Me.FromForm = 1 Then
                    Me.GridViewQuickPrint_Event.Visible = False
                    With Me.GridViewQuickPrint_PS
                        .Visible = True
                        .DataSource = evt.ProjectScheduleTasksDatatable(Me.JobNumber, Me.JobComponentNbr)
                        .DataBind()
                    End With
                End If

            End If
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            If IsNumeric(Request.QueryString("j")) = True Then
                JobNumber = CType(Request.QueryString("j"), Integer)
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(Request.QueryString("jc")) = True Then
                JobComponentNbr = CType(Request.QueryString("jc"), Integer)
            End If
        Catch ex As Exception
        End Try
        Try
            If IsNumeric(Request.QueryString("f")) = True Then
                Me.FromForm = CType(Request.QueryString("f"), Integer)
            End If
        Catch ex As Exception
        End Try
        If JobNumber > 0 And JobComponentNbr > 0 Then
            If Me.FromForm = 0 Then
                Me.LblHeader.Text = "Event Tasks for Job/Comp " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
            ElseIf Me.FromForm = 1 Then
                Me.LblHeader.Text = "Schedule Tasks for Job/Comp " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
            End If
        End If
    End Sub

    'Private Sub GridViewQuickPrint_Event_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewQuickPrint_Event.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Try
    '            If cGlobals.wvIsDate(e.Row.Cells(4).Text) = True Then
    '                e.Row.Cells(4).Text = cGlobals.wvCDate(e.Row.Cells(4).Text).ToShortDateString()
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            If cGlobals.wvIsDate(e.Row.Cells(5).Text) = True Then
    '                e.Row.Cells(5).Text = cGlobals.wvCDate(e.Row.Cells(5).Text).ToShortTimeString()
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            If cGlobals.wvIsDate(e.Row.Cells(6).Text) = True Then
    '                e.Row.Cells(6).Text = cGlobals.wvCDate(e.Row.Cells(6).Text).ToShortTimeString()
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub



    'Private Sub GridViewQuickPrint_PS_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridViewQuickPrint_PS.RowDataBound
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        Try
    '            If cGlobals.wvIsDate(e.Row.Cells(2).Text) = True Then
    '                e.Row.Cells(2).Text = cGlobals.wvCDate(e.Row.Cells(2).Text).ToShortDateString()
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        Try
    '            If cGlobals.wvIsDate(e.Row.Cells(3).Text) = True Then
    '                e.Row.Cells(3).Text = cGlobals.wvCDate(e.Row.Cells(3).Text).ToShortDateString()
    '            End If
    '        Catch ex As Exception
    '        End Try
    '    End If
    'End Sub

End Class