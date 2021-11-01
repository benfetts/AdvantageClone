Namespace Reporting.Presentation

    Public Class MediaTrafficInstructionsInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Reporting.MediaTrafficInstructionsCriteriaViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Reporting.MediaTrafficInstructionsCriteriaController = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(DynamicReport As AdvantageFramework.Reporting.DynamicReports, ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

            If _DynamicReport = DynamicReports.MediaTrafficMissingInstructions Then

                Me.Text = "Media Traffic Missing Instructions Criteria"

                GroupBoxForm_TrafficStartingDateRange.Text = "Spot Date Range"

                CheckBoxForm_IncludeAllMediaTrafficRevisions.Visible = False

            End If

        End Sub
        Private Sub RefreshViewModel()

            DataGridViewForm_MediaBroadcastWorksheets.ClearDatasource()
            DataGridViewForm_MediaBroadcastWorksheets.DataSource = _ViewModel.MediaBroadcastWorksheets
            DataGridViewForm_MediaBroadcastWorksheets.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.StartDate = DateTimePickerStartDateRange_FromDate.Value
            _ViewModel.EndDate = DateTimePickerStartDateRange_ToDate.Value

            _ViewModel.IncludeInactiveWorksheets = CheckBoxForm_IncludeInactiveWorksheets.Checked
            _ViewModel.IncludeAllMediaTrafficRevisions = CheckBoxForm_IncludeAllMediaTrafficRevisions.Checked

        End Sub
        Private Sub Save()

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Refreshing)

                SaveViewModel()

                _Controller.RefreshWorksheets(_ViewModel)

                RefreshViewModel()

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficInstructionsInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.MediaTrafficInstructionsInitialLoadingDialog = Nothing

            MediaTrafficInstructionsInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.MediaTrafficInstructionsInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = MediaTrafficInstructionsInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = MediaTrafficInstructionsInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficInstructionsInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_MediaBroadcastWorksheets.ShowSelectDeselectAllButtons = True

            _Controller = New AdvantageFramework.Controller.Reporting.MediaTrafficInstructionsCriteriaController(Me.Session)

            _ViewModel = _Controller.Load(_DynamicReport = DynamicReports.MediaTrafficMissingInstructions)

        End Sub
        Private Sub MediaTrafficInstructionsInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DateTimePickerStartDateRange_FromDate.Value = _ViewModel.StartDate
            DateTimePickerStartDateRange_ToDate.Value = _ViewModel.EndDate

            CheckBoxForm_IncludeInactiveWorksheets.Checked = _ViewModel.IncludeInactiveWorksheets
            CheckBoxForm_IncludeAllMediaTrafficRevisions.Checked = _ViewModel.IncludeAllMediaTrafficRevisions

            DataGridViewForm_MediaBroadcastWorksheets.DataSource = _ViewModel.MediaBroadcastWorksheets

            DataGridViewForm_MediaBroadcastWorksheets.CurrentView.BestFitColumns()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            If _ParameterDictionary Is Nothing Then

                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

            End If

            If _DynamicReport = DynamicReports.MediaTrafficMissingInstructions Then

                _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficMissingInstructionsInitialCriteria.MediaBroadcastWorksheetMarketIDs.ToString) = DataGridViewForm_MediaBroadcastWorksheets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Worksheet).Select(Function(W) W.MediaBroadcastWorksheetMarketID).ToArray

            ElseIf _DynamicReport = DynamicReports.MediaTrafficInstructions Then

                _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficInstructionsInitialCriteria.MediaBroadcastWorksheetMarketIDs.ToString) = DataGridViewForm_MediaBroadcastWorksheets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Worksheet).Select(Function(W) W.MediaBroadcastWorksheetMarketID).ToArray
                _ParameterDictionary(AdvantageFramework.Reporting.MediaTrafficInstructionsInitialCriteria.IncludeAllMediaTrafficRevisions.ToString) = _ViewModel.IncludeAllMediaTrafficRevisions

            End If

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub CheckBoxForm_IncludeAllMediaTrafficRevisions_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_IncludeAllMediaTrafficRevisions.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Save()

            End If

        End Sub
        Private Sub CheckBoxForm_IncludeInactiveWorksheets_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_IncludeInactiveWorksheets.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Save()

            End If

        End Sub
        Private Sub DateTimePickerStartDateRange_FromDate_ValueObjectChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartDateRange_FromDate.ValueObjectChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Save()

            End If

        End Sub
        Private Sub DateTimePickerStartDateRange_ToDate_ValueObjectChanged(sender As Object, e As EventArgs) Handles DateTimePickerStartDateRange_ToDate.ValueObjectChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                Save()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace