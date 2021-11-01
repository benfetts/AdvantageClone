Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetCopyViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _MediaBroadcastWorksheetID As Integer = 0
        Protected _CopyWithNewCDP As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaBroadcastWorksheetID As Integer, CopyWithNewCDP As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaBroadcastWorksheetID = MediaBroadcastWorksheetID
            _CopyWithNewCDP = CopyWithNewCDP

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Copy_Load(_MediaBroadcastWorksheetID, _CopyWithNewCDP)

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_CDP.DataSource = _ViewModel.WorksheetCopyCDPs

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled

            DataGridViewForm_CDP.Enabled = _ViewModel.CopyWithNewCDP

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_CDP.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_CDP.OptionsBehavior.Editable = False

            DataGridViewForm_CDP.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_CDP.OptionsSelection.MultiSelect = False

            DataGridViewForm_CDP.ShowSelectDeselectAllButtons = False
            DataGridViewForm_CDP.SelectRowsWhenSelectDeselectAllButtonClicked = False
            DataGridViewForm_CDP.FocusToFindPanel(False)

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaBroadcastWorksheetID As Integer, CopyWithNewCDP As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetCopyDialog As MediaBroadcastWorksheetCopyDialog = Nothing

            MediaBroadcastWorksheetCopyDialog = New MediaBroadcastWorksheetCopyDialog(MediaBroadcastWorksheetID, CopyWithNewCDP)

            ShowFormDialog = MediaBroadcastWorksheetCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemDataOptions_CopySpots.Image = AdvantageFramework.My.Resources.DateTimeImage
            ButtonItemDataOptions_CopyRates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            RefreshViewModel()

            Me.ClearChanged()

            DataGridViewForm_CDP.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            _ViewModel.CopySpots = ButtonItemDataOptions_CopySpots.Checked
            _ViewModel.CopyRates = ButtonItemDataOptions_CopyRates.Checked
            _ViewModel.UseLatestRevision = ButtonItemOptions_UseLatestRevision.Checked

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

            _Controller.Copy_WorksheetCopyCDPsSelectionChanged(_ViewModel, DataGridViewForm_CDP.CurrentView.GetFocusedRow)

            _Controller.Copy_Copy(_ViewModel, ErrorMessage)

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Worksheet_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_CDP.FocusedRowChangedEvent

            _Controller.Copy_WorksheetCopyCDPsSelectionChanged(_ViewModel, DataGridViewForm_CDP.CurrentView.GetFocusedRow)

            RefreshViewModel()

        End Sub

#End Region

#End Region

    End Class

End Namespace