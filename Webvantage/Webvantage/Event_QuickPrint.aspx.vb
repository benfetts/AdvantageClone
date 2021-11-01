Public Partial Class Event_QuickPrint
    Inherits System.Web.UI.Page

    Private FromForm As Integer = 0 ' 0 = Job Jacket, 1 = Somewhere else (more than one job)
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private CutOff As DateTime = Nothing
    Private GenId As Integer = 0
    Private AdNbr As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetQSVars()
        If Not Me.IsPostBack Then
            Dim evt As New cEvents()
            Me.GridView1.DataSource = evt.EventGetDetails(Me.JobNumber, Me.JobComponentNbr, Me.CutOff.ToShortDateString(), Me.GenId, Me.AdNbr)
            Me.GridView1.DataBind()
        End If
    End Sub

    Private Sub SetQSVars()
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
        Try
            If Not Request.QueryString("adnbr") Is Nothing Then
                Me.AdNbr = Request.QueryString("adnbr")
            End If
        Catch ex As Exception
            Me.AdNbr = ""
        End Try



        If JobNumber > 0 And JobComponentNbr > 0 Then
            Me.LblHeader.Text = "Events for Job/Comp " & MiscFN.PadJobNum(Me.JobNumber) & "/" & MiscFN.PadJobCompNum(Me.JobComponentNbr)
        End If
    End Sub

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Try
                If cGlobals.wvIsDate(e.Row.Cells(4).Text) = True Then
                    e.Row.Cells(4).Text = cGlobals.wvCDate(e.Row.Cells(4).Text).ToShortDateString()
                End If
            Catch ex As Exception
            End Try
            Try
                If cGlobals.wvIsDate(e.Row.Cells(6).Text) = True Then
                    e.Row.Cells(6).Text = cGlobals.wvCDate(e.Row.Cells(6).Text).ToShortTimeString()
                End If
            Catch ex As Exception
            End Try
            Try
                If cGlobals.wvIsDate(e.Row.Cells(7).Text) = True Then
                    e.Row.Cells(7).Text = cGlobals.wvCDate(e.Row.Cells(7).Text).ToShortTimeString()
                End If
            Catch ex As Exception
            End Try

        End If
    End Sub
End Class