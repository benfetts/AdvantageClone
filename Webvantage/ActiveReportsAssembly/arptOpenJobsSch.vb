Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptOpenJobsSch 

    Public strUserID As String = "%"
    Public strClientID As String = "%"
    Public ConnString As String
    Public strDateRange As String = ""
    Public dttest As DataTable
    Public TextDoc As Boolean
    Private tempDView As DataView
    Private tempSDate As Date
    Private tempEDate As Date
       
    'Private ds As arptOpenJobsDS
    'Public dt As New arptOpenJobsDS.usp_OpenJobsReportDataTable

    Public CultureCode As String = "en-US"
    Private Sub arptOpenJobs_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        tempDView = New DataView(dttest)
        tempDView.RowFilter = "TRF_SCHEDULE_REQ=1"
        tempDView.Sort = "JOB_COMP_DATE"

        If tempDView.Count > 0 Then
            tempSDate = tempDView(0).Item("JOB_COMP_DATE")
            tempEDate = tempDView(tempDView.Count - 1).Item("JOB_COMP_DATE")
        End If
        tempDView.Sort = ""
        Me.DataSource = tempDView


    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        'Me.DateOJ.Text = Now.Date.Date

        If strDateRange.Trim() = "" Then
            txtOpenDates.Text = Format(tempSDate, "MM/dd/yyyy") & " - " & Format(tempEDate, "MM/dd/yyyy")
        Else
            txtOpenDates.Text = Me.strDateRange
        End If

    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        

        If Me.txtJobNumber.Text <> "" Then
            If Me.txtJobNumber.Text.Length = 1 Then
                Me.txtJobNumber.Text = "00000" & Me.txtJobNumber.Text
            End If
            If Me.txtJobNumber.Text.Length = 2 Then
                Me.txtJobNumber.Text = "0000" & Me.txtJobNumber.Text
            End If
            If Me.txtJobNumber.Text.Length = 3 Then
                Me.txtJobNumber.Text = "000" & Me.txtJobNumber.Text
            End If
            If Me.txtJobNumber.Text.Length = 4 Then
                Me.txtJobNumber.Text = "00" & Me.txtJobNumber.Text
            End If
            If Me.txtJobNumber.Text.Length = 5 Then
                Me.txtJobNumber.Text = "0" & Me.txtJobNumber.Text
            End If
        End If

        Me.lbluser.Text = Me.strUserID
        If txtStarted.Text Is Nothing Then
            txtStarted.Text = "No"
        Else
            If txtStarted.Text.Trim <> "" Then
                txtStarted.Text = "Yes"
            Else
                txtStarted.Text = "No"
            End If
        End If

        If Me.txtComponentNumber.Text <> "" Then
            If Me.txtComponentNumber.Text.Length = 1 Then
                Me.txtComponentNumber.Text = "00" & Me.txtComponentNumber.Text
            End If
            If Me.txtComponentNumber.Text.Length = 2 Then
                Me.txtComponentNumber.Text = "0" & Me.txtComponentNumber.Text
            End If
        End If

    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        If TextDoc Then
            Me.ReportInfo1.Visible = False
        End If
    End Sub

    'Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    '    If strDateRange.Trim() = "" Then
    '        txtOpenDates.Text = Format(tempSDate, "MM/dd/yyyy") & " - " & Format(tempEDate, "MM/dd/yyyy")
    '    Else
    '        txtOpenDates.Text = Me.strDateRange
    '    End If
    'End Sub
End Class
