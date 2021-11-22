Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetETAMExportDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheetETAMExportViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaBroadcastWorksheetID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID

        End Sub
        Private Sub RefreshViewModel()

            _ViewModel = _Controller.ETAMExport_Load(_MediaBroadcastWorksheetID)

            If _ViewModel.HasExportableDetail Then

                DateEditForm_StartDate.EditValue = _ViewModel.StartDate
                DateEditForm_EndDate.EditValue = _ViewModel.EndDate

                TextBoxForm_Filename.Text = _ViewModel.Filename
                TextBoxForm_OutputFolder.Text = _ViewModel.OutputFolder

                DataGridViewForm_Stations.DataSource = _ViewModel.Stations
                DataGridViewForm_Stations.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.StartDate = DateEditForm_StartDate.GetValue
            _ViewModel.EndDate = DateEditForm_EndDate.GetValue

            _ViewModel.Filename = TextBoxForm_Filename.GetText
            _ViewModel.OutputFolder = TextBoxForm_OutputFolder.GetText

            _ViewModel.SelectedStations = DataGridViewForm_Stations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DateEditForm_StartDate.SetRequired(True)
            DateEditForm_EndDate.SetRequired(True)
            TextBoxForm_Filename.SetRequired(True)
            TextBoxForm_OutputFolder.SetRequired(True)

            DataGridViewForm_Stations.OptionsBehavior.Editable = False

            TextBoxForm_Filename.MaxLength = 30

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaBroadcastWorksheetID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetETAMExportDialog As AdvantageFramework.Media.Presentation.MediaBroadcastWorksheetETAMExportDialog = Nothing

            MediaBroadcastWorksheetETAMExportDialog = New MediaBroadcastWorksheetETAMExportDialog(MediaBroadcastWorksheetID)

            ShowFormDialog = MediaBroadcastWorksheetETAMExportDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetETAMExportDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

            Me.StartPosition = Windows.Forms.FormStartPosition.WindowsDefaultLocation

        End Sub
        Private Sub MediaBroadcastWorksheetETAMExportDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            RefreshViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            If _ViewModel.HasExportableDetail = False Then

                AdvantageFramework.WinForm.MessageBox.Show("No vendors have orders with spots to export.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = Nothing
            Dim OutputFilename As String = Nothing

            If Me.Validator Then

                SaveViewModel()

                If _Controller.ETAMExport_Export(_ViewModel, OutputFilename) Then

                    AdvantageFramework.WinForm.MessageBox.Show("File exported to: " & OutputFilename)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub TextBoxForm_Filename_Validated(sender As Object, e As EventArgs) Handles TextBoxForm_Filename.Validated

            For Each [Char] In System.IO.Path.GetInvalidFileNameChars

                TextBoxForm_Filename.Text = TextBoxForm_Filename.Text.Replace([Char].ToString, "")

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace
