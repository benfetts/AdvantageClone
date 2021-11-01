Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports Webvantage

Public Class arptMediaSpecs
    Public dtMediaSpecs As DataTable
    Public dtVendor As DataTable
    Public ConnString As String
    Public imgPath As String
    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If Me.txtLblDesc.Text <> "" Then
            Me.txtLblDesc.Text = Me.txtLblDesc.Text & ":"
        End If
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        If Me.txtVendor.Text <> "" Then
            Me.txtVendor.Text = Me.txtVendor.Text & " - " & Me.txtVendorName.Text
        End If
    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptMediaSpecs_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = dtMediaSpecs
    End Sub

    'Private Sub constructReport()
    '    Try
    '        Dim txt1 As New DataDynamics.ActiveReports.TextBox
    '        Me.GroupHeader1.DataField = "VN_CODE"
    '        'txt1.DataField = "VN_CODE"
    '        txt1.Location = New System.Drawing.Point(0.06, 0.06)
    '        txt1.Border.Style = BorderLineStyle.Solid
    '        txt1.Height = 0.19
    '        txt1.Width = 0.63
    '        txt1.Name = "txtVendorCode"
    '        Me.Sections("GroupHeader1").Controls.Add(txt1)
    '        txt1 = New DataDynamics.ActiveReports.TextBox
    '        'txt1.DataField = "VN_NAME"
    '        txt1.Location = New System.Drawing.Point(0.68, 0.6)
    '        Me.Sections("GroupHeader1").Controls.Add(txt1)
    '        txt1 = New DataDynamics.ActiveReports.TextBox
    '        'txt1.DataField = "AD_SIZE"
    '        txt1.Location = New System.Drawing.Point(0.06, 0.06)
    '        txt1.Border.Style = BorderLineStyle.Solid
    '        txt1.Height = 0.19
    '        txt1.Width = 0.63
    '        Me.Sections("Detail1").Controls.Add(txt1)
    '        txt1 = New DataDynamics.ActiveReports.TextBox
    '        'txt1.DataField = "SIZE_DESC"
    '        txt1.Location = New System.Drawing.Point(0.68, 0.06)
    '        txt1.Border.Style = BorderLineStyle.Solid
    '        Me.Sections("Detail1").Controls.Add(txt1)
    '    Catch ex As Exception
    '        Dim str As String = ""
    '    End Try

    'End Sub

    Private Sub GroupHeader2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format
        If Me.txtAdSize.Text <> "" Then
            Me.txtAdSize.Text = Me.txtAdSize.Text & " - " & Me.txtAdSizeDesc.Text
        End If
    End Sub
End Class
