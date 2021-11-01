Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptOpenJobs
    Public strUserID As String = "%"
    Public strClientID As String = "%"
    Public ConnString As String
    Public dttest As DataTable
    Public TextDoc As Boolean
    'Private ds As arptOpenJobsDS
    'Public dt As New arptOpenJobsDS.usp_OpenJobsReportDataTable

    Public CultureCode As String = "en-US"
    Private Sub arptOpenJobs_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'ds = New arptOpenJobsDS
        'Dim t As New arptOpenJobsDSTableAdapters.usp_OpenJobsReportTableAdapter
        't.Fill(dt, strUserID, strClientID)
        Me.DataSource = dttest
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        'Me.DateOJ.Text = Now.Date.Date
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
        If Me.txtComponentNumber.Text <> "" Then
            If Me.txtComponentNumber.Text.Length = 1 Then
                Me.txtComponentNumber.Text = "00" & Me.txtComponentNumber.Text
            End If
            If Me.txtComponentNumber.Text.Length = 2 Then
                Me.txtComponentNumber.Text = "0" & Me.txtComponentNumber.Text
            End If
        End If
        If Me.txtDue_Date1.Text <> "" And Me.txtDue_Date1.Text <> "txtDue_Date1" Then
            Me.txtDue_Date1.Text = CDate(Me.txtDue_Date1.Text).ToShortDateString
        End If

    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        If TextDoc Then
            Me.ReportInfo1.Visible = False
        End If
    End Sub
End Class
