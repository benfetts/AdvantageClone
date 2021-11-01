Imports Webvantage.wvTimeSheet
Imports System.Data.SqlClient
Imports System.Drawing

Public Class Timesheet_Details_Page
    Inherits Webvantage.BaseChildPage


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private OrderNumber As Integer = 0
    Private LineNumber As Integer = 0
    Private RevNumber As Integer = 0
    Private MediaType As String = ""
    Private MediaYear As String = ""

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private FuncCatCode As String = ""
    Private EmpCode As String = ""
    Private AlertID As Integer = 0

    Public lab As System.Web.UI.WebControls.Label
    Public lab2 As System.Web.UI.WebControls.Label
    Public check As Integer = 0
    Public sumHours As Decimal = 0
    Public sumHoursTraffic As Decimal = 0
    Public sumAmount As Decimal = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub butMarkCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMarkCompleted.Click

        OrderNumber = CInt(Request.Params("OrdNo"))
        LineNumber = CInt(Request.Params("LineNo"))
        RevNumber = CInt(Request.Params("RevNo"))
        MediaType = Request.Params("MediaType")

        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))

        If oTasks.MarkCompletedMedia(OrderNumber, LineNumber, RevNumber, MediaType, Today.Date) = True Then

            butMarkCompleted.Enabled = False

        End If

        'LoadTask()

    End Sub
    Private Sub cbEmployee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEmployee.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TimesheetQVA", "EmpOnly", "", Me.cbEmployee.Checked)

        LoadTrafficDetail()

    End Sub
    Private Sub rbQva_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbQvA.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TimesheetQVA", "QVA", "", Me.rbQvA.Checked)
        otask.setAppVars(Session("UserCode"), "TimesheetQVA", "TrafficHours", "", Me.rbTrafficHours.Checked)

        LoadTrafficDetail()

    End Sub
    Private Sub rbTrafficHours_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTrafficHours.CheckedChanged

        Dim otask As cTasks = New cTasks(Session("ConnString"))
        otask.setAppVars(Session("UserCode"), "TimesheetQVA", "TrafficHours", "", Me.rbTrafficHours.Checked)
        otask.setAppVars(Session("UserCode"), "TimesheetQVA", "QVA", "", Me.rbQvA.Checked)

        LoadTrafficDetail()

    End Sub

    Private Sub gvActualHours_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvActualHours.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lab = e.Row.Cells(1).FindControl("lblDate")
                If lab.Text <> "" Then
                    lab.Text = Convert.ToDateTime(lab.Text).ToShortDateString
                End If
                lab = e.Row.Cells(0).FindControl("lblEmpCode")
                lab2 = e.Row.Cells(1).FindControl("lblDate")
                If lab.Text = "Others" And lab2.Text = "12/12/9999" Then
                    lab2.Text = "[Others]"
                    check = 1
                ElseIf lab2.Text = "1/1/0001" Then
                    lab = e.Row.Cells(1).FindControl("lblDate")
                    lab.Text = ""
                    lab = e.Row.Cells(2).FindControl("lblHours")
                    lab.Text = ""
                    lab = e.Row.Cells(3).FindControl("lblAmount")
                    lab.Text = ""
                    lab = e.Row.Cells(4).FindControl("lblComments")
                    lab.Text = ""
                End If
                lab = e.Row.Cells(2).FindControl("lblHours")
                If lab.Text <> "" Then
                    sumHours += Convert.ToDecimal(lab.Text)
                End If
                lab = e.Row.Cells(3).FindControl("lblAmount")
                If lab.Text <> "" Then
                    sumAmount += Convert.ToDecimal(lab.Text)
                End If
            Case DataControlRowType.Footer
                lab = e.Row.Cells(2).FindControl("lblTotalHours")
                lab.Text = sumHours.ToString
                lab = e.Row.Cells(3).FindControl("lblTotalAmount")
                lab.Text = sumAmount.ToString
        End Select

    End Sub
    Private Sub gvActualHoursTraffic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvActualHoursTraffic.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lab = e.Row.Cells(1).FindControl("lblDate")
                If lab.Text <> "" And lab.Text <> "12/12/9999 12:00:00 AM" Then
                    lab.Text = Convert.ToDateTime(lab.Text).ToShortDateString
                ElseIf lab.Text = "12/12/9999 12:00:00 AM" Then
                    lab = e.Row.Cells(1).FindControl("lblDate")
                    lab.Text = ""
                    lab = e.Row.Cells(2).FindControl("lblActualHours")
                    lab.Text = ""
                    lab = e.Row.Cells(3).FindControl("lblComments")
                    lab.Text = ""
                End If
                lab = e.Row.Cells(2).FindControl("lblActualHours")
                If lab.Text <> "" Then
                    sumHours += Convert.ToDecimal(lab.Text)
                End If
            Case DataControlRowType.Footer
                lab = e.Row.Cells(2).FindControl("lblTotalHoursTraffic")
                lab.Text = sumHours.ToString
        End Select

    End Sub
    Private Sub gvTrafficHours_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvTrafficHours.RowDataBound
        Select Case e.Row.RowType
            Case DataControlRowType.DataRow
                lab = e.Row.Cells(1).FindControl("lblHoursAllowed")
                If lab.Text <> "" Then
                    sumHoursTraffic += Convert.ToDecimal(lab.Text)
                End If
            Case DataControlRowType.Footer
                lab = e.Row.Cells(1).FindControl("lblTotalHours")
                lab.Text = sumHoursTraffic.ToString
        End Select
    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("j") Is Nothing Then
                Me.JobNumber = CType(Request.QueryString("j").ToString().Trim(), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("jc") Is Nothing Then
                Me.JobComponentNbr = CType(Request.QueryString("jc").ToString().Trim(), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try
        Try
            If Not Request.QueryString("fn") Is Nothing Then
                Me.FuncCatCode = Request.QueryString("fn").ToString().Trim()
            End If
        Catch ex As Exception
            Me.FuncCatCode = ""
        End Try
        Try
            If Not Request.QueryString("emp") Is Nothing Then
                Me.EmpCode = Request.QueryString("emp").ToString().Trim()
            End If
        Catch ex As Exception
            Me.EmpCode = ""
        End Try
        Try
            If Not Request.QueryString("alertid") Is Nothing Then
                Me.AlertID = CType(Request.QueryString("alertid").ToString().Trim(), Integer)
            End If
        Catch ex As Exception
            Me.AlertID = 0
        End Try
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Page.IsPostBack = False Then

            Me.pnlQvA.Visible = False
            Me.lblNoTrafficHours.Visible = False
            Me.pnlTrafficHours.Visible = False
            Me.butMarkCompleted.Attributes.Add("onclick", "if(confirm('Do you want to mark this Order as Complete?')==false) return false;")

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim taskVar As String

            taskVar = otask.getAppVars(Session("UserCode"), "TimesheetQVA", "QVA")
            If taskVar <> "" Then

                Me.rbQvA.Checked = taskVar

            Else

                Me.rbQvA.Checked = False

            End If

            taskVar = otask.getAppVars(Session("UserCode"), "TimesheetQVA", "TrafficHours")
            If taskVar <> "" Then

                Me.rbTrafficHours.Checked = taskVar

            Else

                Me.rbTrafficHours.Checked = False

            End If

            taskVar = otask.getAppVars(Session("UserCode"), "TimesheetQVA", "EmpOnly")
            If taskVar <> "" Then

                Me.cbEmployee.Checked = taskVar

            Else

                Me.cbEmployee.Checked = True

            End If

            LoadTrafficDetail()

        End If
    End Sub

#End Region

    Private Function addleadingZeroesJobEstimate(ByVal item As String, Optional ByVal item2 As String = "")
        Dim str As String = ""
        If item.Length = 1 Then
            str = "00000" & item
        End If
        If item.Length = 2 Then
            str = "0000" & item
        End If
        If item.Length = 3 Then
            str = "000" & item
        End If
        If item.Length = 4 Then
            str = "00" & item
        End If
        If item.Length = 5 Then
            str = "0" & item
        End If
        If item2 = "" Then
            Return str
        Else
            If item2.Length = 1 Then
                item2 = "0" & item2
            End If
            Return str & "-" & item2
        End If
    End Function
    Private Function addleadingZeroesCompQuoteRev(ByVal item As String)
        Dim str As String = ""
        If item.Length = 1 Then
            str = "0" & item
            Return str
        Else
            Return item
        End If
    End Function
    Private Sub LoadTrafficDetail()

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim drQva As SqlDataReader
        Dim drQva2 As SqlDataReader
        Dim drdt As DataTable
        Dim drdt2 As DataTable
        Dim drEstimate As SqlDataReader
        Dim drTrafficHours As SqlDataReader
        Dim drTrafficHours2 As SqlDataReader
        Dim amountEstimate As Decimal = 0.0
        Dim amountPosted As Decimal = 0.0
        Dim hoursQuoted As Decimal = 0.0
        Dim amountQuoted As Decimal = 0.0
        Dim estComp As Integer = 0
        Dim datar As DataRow
        Dim view As Integer = 0

        If Me.rbQvA.Checked = True Then
            view = 0
        ElseIf Me.rbTrafficHours.Checked = True Then
            view = 1
        End If

        drQva = oTS.GetQuoteVsActualDD(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, view)
        drQva2 = oTS.GetQuoteVsActualDD(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, view)
        drdt = oTS.GetQuoteVsActualDDdt(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, view)
        drdt2 = oTS.GetQuoteVsActualDDdt(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, view)

        datar = drdt.NewRow

        datar.Item(0) = DBNull.Value
        datar.Item(1) = DBNull.Value
        datar.Item(2) = "Others"
        datar.Item(3) = "1/1/0001"
        datar.Item(4) = DBNull.Value
        datar.Item(5) = DBNull.Value
        datar.Item(6) = 0.0
        datar.Item(7) = 0.0
        datar.Item(8) = DBNull.Value
        drdt.Rows.Add(datar)

        Dim ClCode As String = ""
        Dim ClName As String = ""
        Dim JobName As String = ""
        Dim JobCompName As String = ""
        oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, JobName, JobCompName, , ClCode, , , , ClName)

        Dim Threshold As Double = 100.0
        Dim ProgressQuoted As Decimal = 0.0
        Dim ProgressActual As Decimal = 0.0
        Dim IsOverThreshold As Boolean = False

        If Me.cbEmployee.Checked = True Then

            Try

                Dim oAppVars As New cAppVars(cAppVars.Application.MY_QVA_DTO)
                oAppVars.getAllAppVars()
                Double.TryParse(oAppVars.getAppVar("Threshold", "", "100"), Threshold)

            Catch ex As Exception

                Threshold = 100

            End Try

        Else

            Try

                Dim oAppVars As New cAppVars(cAppVars.Application.ALL_QVA_DTO)
                oAppVars.getAllAppVars()
                Double.TryParse(oAppVars.getAppVar("Threshold", "", "100"), Threshold)

            Catch ex As Exception

                Threshold = 100

            End Try

        End If

        Me.LabelThreshold.Text = String.Format("Threshold:  {0}%", Threshold)

        Me.LabelThreshold.Visible = rbQvA.Checked

        If Me.rbQvA.Checked = True Then

            drEstimate = oTS.GetEstimateData(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked)
            Me.lblClientCode.Text = ClCode
            Me.lblClientName.Text = ClName
            Me.lblJobName.Text = JobName
            Me.lblComponentName.Text = JobCompName

            Do While drQva.Read

                Me.lblJobNumber.Text = drQva.GetInt32(0)
                Me.lblComponentNumber.Text = drQva.GetInt16(1)
                Me.lblFunction.Text = drQva.GetString(4)
                Me.lblFunctionName.Text = drQva.GetString(5)

            Loop
            Do While drEstimate.Read

                hoursQuoted += drEstimate.GetDecimal(10)
                Me.lblEstimate.Text = drEstimate.GetInt32(2)
                estComp = drEstimate.GetInt16(4)
                Me.lblQuoteNumber.Text = drEstimate.GetInt16(6)
                Me.lblRevisionNumber.Text = drEstimate.GetInt16(7)
                amountQuoted += drEstimate.GetDecimal(11) + drEstimate.GetDecimal(12)
                amountEstimate = drEstimate.GetDecimal(11) + drEstimate.GetDecimal(12)

            Loop

            Me.lblHoursQuoted.Text = hoursQuoted
            Me.lblAmountQuoted.Text = amountQuoted

            ProgressQuoted = amountQuoted

            If Me.cbEmployee.Checked = False Then

                Me.gvActualHours.DataSource = drdt

            Else

                Me.gvActualHours.DataSource = drQva2

            End If

            Me.gvActualHours.DataBind()

            amountPosted = sumAmount
            Me.lblAmountPosted.Text = sumAmount
            Me.lblAmountRemaining.Text = (amountQuoted - amountPosted).ToString

            ProgressActual = sumAmount

            If amountPosted > (amountQuoted * (Threshold * 0.01)) Then

                Me.lblAmountRemaining.ForeColor = Color.Red
                IsOverThreshold = True

            End If
            'If Convert.ToDecimal(Me.lblAmountRemaining.Text) < 0.0 Then
            '    Me.lblAmountRemaining.ForeColor = Color.Red
            'Else
            '    Me.lblAmountRemaining.ForeColor = Color.Black
            'End If
            Me.lblHoursPosted.Text = sumHours

            If drEstimate.HasRows = True Then

                Me.lblHoursRemaining.Text = (Convert.ToDecimal(Me.lblHoursQuoted.Text) - Convert.ToDecimal(Me.lblHoursPosted.Text)).ToString

            Else

                Me.lblHoursRemaining.Text = (Convert.ToDecimal(0) - Convert.ToDecimal(Me.lblHoursPosted.Text)).ToString

            End If
            If sumHours > (hoursQuoted * (Threshold * 0.01)) Then

                Me.lblHoursRemaining.ForeColor = Color.Red
                IsOverThreshold = True

            End If
            'If Convert.ToDecimal(Me.lblHoursRemaining.Text) < 0.0 Then
            '    Me.lblHoursRemaining.ForeColor = Color.Red
            'Else
            '    Me.lblHoursRemaining.ForeColor = Color.Black
            'End If
            drEstimate.Close()

            Me.lblJobNumber.Text = addleadingZeroesJobEstimate(Me.lblJobNumber.Text)
            Me.lblComponentNumber.Text = addleadingZeroesCompQuoteRev(Me.lblComponentNumber.Text)

            If Me.lblEstimate.Text <> "" Then

                Me.lblEstimate.Text = addleadingZeroesJobEstimate(Me.lblEstimate.Text, estComp)

            End If

            Me.lblQuoteNumber.Text = addleadingZeroesCompQuoteRev(Me.lblQuoteNumber.Text)
            Me.lblRevisionNumber.Text = addleadingZeroesCompQuoteRev(Me.lblRevisionNumber.Text)
            Me.pnlQvA.Visible = True
            Me.pnlTrafficHours.Visible = False

        ElseIf Me.rbTrafficHours.Checked = True Then

            drTrafficHours = oTS.GetTrafficHours(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, Me.AlertID)
            drTrafficHours2 = oTS.GetTrafficHours(Me.JobNumber, Me.JobComponentNbr, Me.FuncCatCode, Me.EmpCode, Me.cbEmployee.Checked, Me.AlertID)

            Me.lblClientCodeTraffic.Text = ClCode
            Me.lblClientNameTraffic.Text = ClName
            Me.lblJobNameTraffic.Text = JobName
            Me.lblComponentNameTraffic.Text = JobCompName

            If drQva.HasRows = False Then
                Me.lblJobCodeTraffic.Text = Me.JobNumber
                Me.lblComponentNumberTraffic.Text = Me.JobComponentNbr
            Else
                Do While drQva.Read

                    Me.lblJobCodeTraffic.Text = drQva.GetInt32(0)
                    Me.lblComponentNumberTraffic.Text = drQva.GetInt16(1)
                    'Me.lblFunctionCodeTraffic.Text = drQva.GetString(4)
                    'Me.lblFunctionNameTraffic.Text = drQva.GetString(5)

                Loop
            End If



            Dim dv As DataView = New DataView(drdt2)
            dv.RowFilter = "AlertID = " & Me.AlertID

            Me.gvActualHoursTraffic.DataSource = dv.ToTable
            Me.gvActualHoursTraffic.DataBind()
            Me.gvTrafficHours.DataSource = drTrafficHours2
            Me.gvTrafficHours.DataBind()

            If drTrafficHours.HasRows = False Then

                Me.lblNoTrafficHours.Visible = True

            Else

                Me.lblNoTrafficHours.Visible = False

            End If

            Me.lblHoursPostedTraffic.Text = sumHours
            ProgressActual = sumHours

            If drTrafficHours.HasRows = True Then

                Do While drTrafficHours.Read

                    Dim hrs As Decimal
                    hrs += drTrafficHours.GetDecimal(5)
                    Me.lblHoursAllowedTraffic.Text = hrs.ToString

                Loop

                Me.lblHoursRemainingTraffic.Text = (Convert.ToDecimal(Me.lblHoursAllowedTraffic.Text) - Convert.ToDecimal(Me.lblHoursPostedTraffic.Text)).ToString
                ProgressQuoted = Convert.ToDecimal(Me.lblHoursAllowedTraffic.Text)

                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)
                End Using

                If Alert IsNot Nothing Then
                    Me.lblAssignmentDescription.Text = Alert.Subject
                End If

            Else

                Me.lblHoursRemainingTraffic.Text = (Convert.ToDecimal(0) - Convert.ToDecimal(Me.lblHoursPostedTraffic.Text)).ToString

            End If

            If Convert.ToDecimal(Me.lblHoursRemainingTraffic.Text) < 0.0 Then

                Me.lblHoursRemainingTraffic.ForeColor = Color.Red
                IsOverThreshold = True

            End If

            drTrafficHours.Close()
            drTrafficHours2.Close()

            Me.lblJobCodeTraffic.Text = addleadingZeroesJobEstimate(Me.lblJobCodeTraffic.Text)
            Me.lblComponentNumberTraffic.Text = addleadingZeroesCompQuoteRev(Me.lblComponentNumberTraffic.Text)

            Me.pnlQvA.Visible = False
            Me.pnlTrafficHours.Visible = True

        End If

        drQva.Close()
        drQva2.Close()

        'Dim pi As New AdvantageFramework.Web.Presentation.Controls.ProgressIndicator

        'If ProgressQuoted = 0 Then

        '    pi.Max = ProgressActual
        '    pi.Value = ProgressActual
        '    pi.Color = pi.Yellow

        'Else

        '    pi.Max = ProgressQuoted
        '    pi.Value = ProgressActual

        '    If IsOverThreshold = True Then

        '        pi.Color = pi.Red

        '    Else

        '        pi.Color = pi.Green
        '    End If

        'End If

        'If Me.rbTrafficHours.Checked = True Then

        '    Me.LiteralTrafficProgressBar.Text = pi.DrawHTML()

        'Else

        '    Me.LiteralQvAProgressBar.Text = pi.DrawHTML()

        'End If

    End Sub
    Public Function ShowTaskStatus(ByVal TaskStatus As String) As String
        Select Case TaskStatus.ToUpper
            Case "P"
                Return "Projected"
            Case "A"
                Return "Active"
        End Select
    End Function

#End Region


End Class
