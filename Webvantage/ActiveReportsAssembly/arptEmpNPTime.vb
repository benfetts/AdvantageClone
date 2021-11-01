Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptEmpNPTime

    Public strUserID As String
    Public sort As String
    Public office As String
    Public super As String
    Public emp As String
    Public dept As String
    Public StartDate As String
    Public EndDate As String
    Public inclTermEmp As String

    Public dt As DataTable

    Public CultureCode As String = "en-US"
    Private Sub arptEmpNPTime_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = dt
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        Me.lblDate.Text = Now.Date.Date
    End Sub

    Private Sub PageFooter1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.BeforePrint
        Me.lbluser.Text = strUserID
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            'Me.TextBox8.Text = Me.TextBox6.Value - Me.TextBox7.Value 'CType(Me.TextBox6.Text, Decimal) - CType(Me.TextBox7.Text, Decimal)
            Dim str() As String = Me.TextBox5.Text.Split("-")
            Me.TextBox5.Text = CDate(ReportFunctions.FormatDate(str(0))).ToShortDateString & " - " & CDate(ReportFunctions.FormatDate(str(1))).ToShortDateString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Select Case sort
            Case 1, 2
                Me.LabelOfficeHDR.Visible = True
                Me.Line1.Visible = True
                Me.Line3.Visible = True
                Me.LabelOfficeHDR.Text = "Office: " & Me.TBOffice.Text
                Me.GroupHeader1.Height = 0.24

            Case 3, 4
                Me.LabelOfficeHDR.Visible = False
                Me.Line1.Visible = False
                Me.Line3.Visible = False
                Me.GroupHeader1.Height = 0

        End Select
        Me.LabelOfficeHDR.Text = "Office: " & Me.TBOffice.Text
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        Select Case sort
            Case 1, 4
                Me.LabelEmpHDR.Text = "Employee: " & Me.TBEmpCode.Text & " - " & Me.TBEmp.Text
            Case 2, 3
                Me.LabelEmpHDR.Text = "Employee: " & Me.TBEmp.Text
        End Select
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Select Case sort
            Case 1, 2
                Me.GroupFooter1.Height = 0.22
            Case 3, 4
                Me.GroupFooter1.Height = 0
        End Select

    End Sub
End Class
