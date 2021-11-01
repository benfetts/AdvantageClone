Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptPurchaseOrder001 

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Me.RichTextBox1.Html = "<html><head></head><body><p> </p><font face=Arial color=green size=2>&nbsp;<b>Sample Text&nbsp;</b>&nbsp;</font><br>Line 2</body></html>"
    End Sub

    Public CultureCode As String = "en-US"
    Private Sub arptPurchaseOrder001_ReportStart(sender As Object, e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)

    End Sub
End Class
