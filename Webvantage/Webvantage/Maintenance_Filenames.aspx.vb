Public Class Maintenance_Filenames
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Maintenance_Filenames_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.PanelEdit.Visible = False
            Me.BindRadComboBoxReportGroups()

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub LinkButtonEdit_Click(sender As Object, e As EventArgs) Handles LinkButtonEdit.Click

        Me.PanelEdit.Visible = Not Me.PanelEdit.Visible

    End Sub

    Private Sub LinkButtonSave_Click(sender As Object, e As EventArgs) Handles LinkButtonSave.Click

    End Sub

#End Region

#Region " Methods "

    Private Sub BindRadComboBoxReportGroups()

        Me.RadComboBoxReportGroups.Items.Clear()

        For Each item As Generic.KeyValuePair(Of AdvantageFramework.Reporting.ActiveReports.ReportFilenameGroup, String) In AdvantageFramework.Reporting.ActiveReports.LoadReportGroups()

            Me.RadComboBoxReportGroups.Items.Add(New Telerik.Web.UI.RadComboBoxItem(item.Value, CType(item.Key, Integer)))

        Next

    End Sub

#End Region

End Class