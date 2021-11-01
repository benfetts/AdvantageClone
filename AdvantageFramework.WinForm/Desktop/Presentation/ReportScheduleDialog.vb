Namespace Desktop.Presentation

    Public Class ReportScheduleDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _DynamicReportID As Integer = 0
        Protected _SelectedDynamicReport As AdvantageFramework.Reporting.DynamicReports = -1
        Protected _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Protected _SerializedParameterDictionary As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(DynamicReportID As Integer, SelectedDynamicReport As AdvantageFramework.Reporting.DynamicReports, ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _DynamicReportID = DynamicReportID
            _SelectedDynamicReport = SelectedDynamicReport
            _ParameterDictionary = ParameterDictionary

            _SerializedParameterDictionary = AdvantageFramework.ClassUtilities.GetParameterContent(_ParameterDictionary)

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Cancel.Enabled = ScheduledReportControlForm_ScheduledReports.DataGridViewForm_ScheduledReports.IsNewItemRow
            ButtonItemActions_Save.Enabled = ScheduledReportControlForm_ScheduledReports.DataGridViewForm_ScheduledReports.UserEntryChanged
            ButtonItemActions_Delete.Enabled = ScheduledReportControlForm_ScheduledReports.DataGridViewForm_ScheduledReports.HasASelectedRow AndAlso Not ButtonItemActions_Cancel.Enabled

            ButtonItemCriteria_Edit.Enabled = ScheduledReportControlForm_ScheduledReports.ShowCriteriaEdit

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DynamicReportID As Integer, SelectedDynamicReport As AdvantageFramework.Reporting.DynamicReports, ParameterDictionary As Generic.Dictionary(Of String, Object)) As System.Windows.Forms.DialogResult

            'objects
            Dim ReportScheduleDialog As Desktop.Presentation.ReportScheduleDialog = Nothing

            ReportScheduleDialog = New Desktop.Presentation.ReportScheduleDialog(DynamicReportID, SelectedDynamicReport, ParameterDictionary)

            ShowFormDialog = ReportScheduleDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ReportScheduleDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            Me.ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub ReportScheduleDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemCriteria_Edit.Image = AdvantageFramework.My.Resources.EditImage

            ScheduledReportControlForm_ScheduledReports.LoadControl(True, _SerializedParameterDictionary, _DynamicReportID)

        End Sub
        Private Sub ReportScheduleDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub
        Private Sub ReportScheduleDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            Me.ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            ScheduledReportControlForm_ScheduledReports.CancelNewItem()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            ScheduledReportControlForm_ScheduledReports.DeleteSelectedScheduledReport()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemCriteria_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemCriteria_Edit.Click

            ScheduledReportControlForm_ScheduledReports.EditCriteria()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If ScheduledReportControlForm_ScheduledReports.Save() Then

                Me.ClearChanged()

            End If

        End Sub
        Private Sub ScheduledReportControlForm_ScheduledReports_ScheduledReportChangedEvent() Handles ScheduledReportControlForm_ScheduledReports.ScheduledReportChangedEvent



        End Sub
        Private Sub ScheduledReportControlForm_ScheduledReports_ScheduledReportSelectionChangedEvent() Handles ScheduledReportControlForm_ScheduledReports.ScheduledReportSelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace