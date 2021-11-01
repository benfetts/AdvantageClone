Public Class ReportTypeUC
    Inherits Webvantage.BaseUserControl

    Public strReportSelect As String = "1"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.LoadReportTypes()

        End If
    End Sub

    Private Sub LoadReportTypes()

        Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("PDF"), CStr("1")))
        Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Excel"), CStr("2")))
        'Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("HTML"), CStr("3")))
        Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Text"), CStr("4")))
        Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Rich Text"), CStr("5")))
        'Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("TIFF"), CStr("6")))
        'Me.RadComboBoxReportType.Items.Add(New Telerik.Web.UI.RadComboBoxItem(CStr("Reporting Services"), CStr("Reporting Services")))

    End Sub

    Private Sub RadComboBoxReportType_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReportType.SelectedIndexChanged

        Me.strReportSelect = Me.RadComboBoxReportType.SelectedValue

    End Sub

End Class