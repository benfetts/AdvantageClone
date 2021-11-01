Namespace Media.Presentation

    Public Class MediaTrafficInstructionCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficInstructionCopyViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaTrafficController = Nothing
        Protected _MediaTrafficRevisionID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaTrafficRevisionID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaTrafficRevisionID = MediaTrafficRevisionID

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Copy_LoadWorksheetMarkets(_MediaTrafficRevisionID)

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_WorksheetMarkets.DataSource = _ViewModel.Worksheets

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_WorksheetMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewForm_WorksheetMarkets.OptionsBehavior.Editable = False

            DataGridViewForm_WorksheetMarkets.OptionsDetail.EnableMasterViewMode = False
            DataGridViewForm_WorksheetMarkets.OptionsSelection.MultiSelect = False

            DataGridViewForm_WorksheetMarkets.ShowSelectDeselectAllButtons = False
            DataGridViewForm_WorksheetMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = False
            DataGridViewForm_WorksheetMarkets.FocusToFindPanel(False)

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaTrafficRevisionID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaTrafficInstructionCopyDialog As MediaTrafficInstructionCopyDialog = Nothing

            MediaTrafficInstructionCopyDialog = New MediaTrafficInstructionCopyDialog(MediaTrafficRevisionID)

            ShowFormDialog = MediaTrafficInstructionCopyDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTrafficInstructionCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaTrafficController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaTrafficInstructionCopyDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            Me.ClearChanged()

            DataGridViewForm_WorksheetMarkets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim DialogResult As AdvantageFramework.WinForm.MessageBox.DialogResults = WinForm.MessageBox.DialogResults.Cancel
            Dim ErrorMessage As String = String.Empty

            DialogResult = AdvantageFramework.WinForm.MessageBox.Show("Do you want to copy instructions to all vendors on the worksheet?  If Yes, instructions will be applied to all vendors.  If No, instructions must be applied to vendors from within the worksheet.", WinForm.MessageBox.MessageBoxButtons.YesNoCancel, MessageBoxIcon:=Windows.Forms.MessageBoxIcon.Hand, MessageBoxDefaultButton:=Windows.Forms.MessageBoxDefaultButton.Button3)

            If DialogResult = WinForm.MessageBox.DialogResults.Yes Then

                _ViewModel.CopyAllVendors = True

            ElseIf DialogResult = WinForm.MessageBox.DialogResults.No Then

                _ViewModel.CopyAllVendors = False

            End If

            If DialogResult <> WinForm.MessageBox.DialogResults.Cancel Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

                _ViewModel.MediaBroadcastWorksheetMarketIDs = (From Entity In DataGridViewForm_WorksheetMarkets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)
                                                               Select Entity.MediaBroadcastWorksheetMarketID).ToArray

                _Controller.Copy_Copy(_ViewModel, ErrorMessage)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace