Namespace Reporting.Presentation

    Public Class CustomReportImportForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        

#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub UpdateCustomReportImportProgress(ByVal StatusMessage As String, ByVal OverallProgress As Integer, ByVal CurrentActionProgress As Integer)

            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnTextBoxControl(TextBoxForm_Log, StatusMessage & vbNewLine & TextBoxForm_Log.Text)
            AdvantageFramework.WinForm.Presentation.Controls.SetTextOnLabelControl(LabelForm_CurrentActionDescription, StatusMessage)

            ProgressBarForm_OverallProgress.Value = OverallProgress
            ProgressBarForm_CurrentAction.Value = CurrentActionProgress

            Me.Refresh()

        End Sub
        Private Sub ResetCustomReportImportOverallProgressValues(ByVal Minimum As Integer, ByVal Maximum As Integer, ByVal StartValue As Integer)

            ProgressBarForm_OverallProgress.Minimum = Minimum
            ProgressBarForm_OverallProgress.Maximum = Maximum
            ProgressBarForm_OverallProgress.Value = StartValue

            Me.Refresh()

        End Sub
        Private Sub ResetCustomReportImportCurrentActionProgressValues(ByVal Minimum As Integer, ByVal Maximum As Integer, ByVal StartValue As Integer)

            ProgressBarForm_CurrentAction.Minimum = Minimum
            ProgressBarForm_CurrentAction.Maximum = Maximum
            ProgressBarForm_CurrentAction.Value = StartValue

            Me.Refresh()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CustomReportImportForm As CustomReportImportForm = Nothing

            CustomReportImportForm = New CustomReportImportForm

            CustomReportImportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CustomReportImportForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.Reporting.Presentation.UpdateCustomReportImportProgressEvent, AddressOf UpdateCustomReportImportProgress
            RemoveHandler AdvantageFramework.Reporting.Presentation.ResetCustomReportImportOverallProgressValuesEvent, AddressOf ResetCustomReportImportOverallProgressValues
            RemoveHandler AdvantageFramework.Reporting.Presentation.ResetCustomReportImportCurrentActionProgressValuesEvent, AddressOf ResetCustomReportImportCurrentActionProgressValues

        End Sub
        Private Sub CustomReportImportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub CustomReportImportForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            AddHandler AdvantageFramework.Reporting.Presentation.UpdateCustomReportImportProgressEvent, AddressOf UpdateCustomReportImportProgress
            AddHandler AdvantageFramework.Reporting.Presentation.ResetCustomReportImportOverallProgressValuesEvent, AddressOf ResetCustomReportImportOverallProgressValues
            AddHandler AdvantageFramework.Reporting.Presentation.ResetCustomReportImportCurrentActionProgressValuesEvent, AddressOf ResetCustomReportImportCurrentActionProgressValues

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Import_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemActions_Import.Click

            If Me.Validator Then

                TextBoxForm_Log.Text = ""
                ButtonItemActions_Import.Enabled = False
                TextBoxForm_ReportZipFile.Enabled = False

                Me.ShowWaitForm("Processing...")

                AdvantageFramework.Reporting.Presentation.CustomReportImport(Me.Session, TextBoxForm_ReportZipFile.Text)

                LabelForm_CurrentActionDescription.Text = ""

                ProgressBarForm_OverallProgress.Minimum = 0
                ProgressBarForm_OverallProgress.Maximum = 0
                ProgressBarForm_OverallProgress.Value = 0

                ProgressBarForm_CurrentAction.Minimum = 0
                ProgressBarForm_CurrentAction.Maximum = 0
                ProgressBarForm_CurrentAction.Value = 0

                ButtonItemActions_Import.Enabled = True
                TextBoxForm_ReportZipFile.Enabled = True

                Me.CloseWaitForm()

                Me.Refresh()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace