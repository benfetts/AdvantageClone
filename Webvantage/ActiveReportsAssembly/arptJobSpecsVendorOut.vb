Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptJobSpecsVendorOut
    Public dtVendor As DataTable
    Public imgPath As String
    Public Sub New()
        InitializeComponent()
    End Sub 'New

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptJobSpecsVendorOut_ReportStart(sender As Object, e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)

    End Sub
End Class
