Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptJobSpecsVendor
    Public dtVendor As DataTable
    Public imgPath As String
    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'Dim closedate As DateTime = Convert.ToDateTime(Me.txtCloseDate.Text)
        If Me.txtCloseDate.Text <> "" Then
            Me.txtCloseDate.Text = CDate(Me.txtCloseDate.Text).ToShortDateString
        End If
        'Dim rundate As DateTime = Convert.ToDateTime(Me.txtRunDate.Text)
        If Me.txtRunDate.Text <> "" Then
            Me.txtRunDate.Text = CDate(Me.txtRunDate.Text).ToShortDateString
        End If
        'Dim extdate As DateTime = Convert.ToDateTime(Me.txtExtDate.Text)
        If Me.txtExtDate.Text <> "" Then
            Me.txtExtDate.Text = CDate(Me.txtExtDate.Text).ToShortDateString
        End If
        If Me.txtCloseDate.Text = "1/1/1900" Then
            Me.txtCloseDate.Text = ""
        End If
        If Me.txtRunDate.Text = "1/1/1900" Then
            Me.txtRunDate.Text = ""
        End If
        If Me.txtExtDate.Text = "1/1/1900" Then
            Me.txtExtDate.Text = ""
        End If
        If Me.txtVendorName.Text <> "" Then
            Me.txtVendor.Text = Me.txtVendor.Text & " - " & Me.txtVendorName.Text
        End If
        If Me.txtAdSizeDesc.Text <> "" Then
            Me.txtAdSize.Text = Me.txtAdSize.Text & " - " & Me.txtAdSizeDesc.Text
        End If
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        
    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptJobSpecsVendor_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = dtVendor
    End Sub
End Class
