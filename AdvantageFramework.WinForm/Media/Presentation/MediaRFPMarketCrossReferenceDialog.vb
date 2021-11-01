Namespace Media.Presentation

    Public Class MediaRFPMarketCrossReferenceDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaRFPMarketCrossReferenceController = Nothing
        Protected _SourceMarketNames As IEnumerable(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(SourceMarketNames As IEnumerable(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            _SourceMarketNames = SourceMarketNames

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_SourceMarketNames)

        End Sub
        Private Sub LoadGrid()

            DataGridViewPanel_Markets.DataSource = _ViewModel.MediaRFPMarketCrossReferenceList

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewPanel_Markets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewPanel_Markets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            DataGridViewPanel_Markets.OptionsBehavior.Editable = True
            DataGridViewPanel_Markets.MultiSelect = False

        End Sub
        Private Sub AddNewRow(MediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference)

            Dim ErrorMessage As String = Nothing

            If MediaRFPMarketCrossReference IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.Add(MediaRFPMarketCrossReference, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewPanel_Markets.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewPanel_Markets.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(SourceMarketNames As IEnumerable(Of String)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaRFPMarketCrossReferenceDialog As MediaRFPMarketCrossReferenceDialog = Nothing

            MediaRFPMarketCrossReferenceDialog = New MediaRFPMarketCrossReferenceDialog(SourceMarketNames)

            ShowFormDialog = MediaRFPMarketCrossReferenceDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaRFPMarketCrossReferenceDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaRFPMarketCrossReferenceController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaRFPMarketCrossReferenceDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            RefreshViewModel(True)

            Me.ClearChanged()

            DataGridViewPanel_Markets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaRFPMarketCrossReferenceDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaRFPMarketCrossReferenceDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewPanel_Markets.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewPanel_Markets.HasASelectedRow Then

                DataGridViewPanel_Markets.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_Markets.IsNewItemRow, DataGridViewPanel_Markets.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewPanel_Markets.CurrentView.CloseEditorForUpdating()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

            _Controller.Save(_ViewModel)

            RefreshViewModel(False)

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

        End Sub
        Private Sub DataGridViewPanel_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewPanel_Markets.FocusedRowChangedEvent

            _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_Markets.IsNewItemRow, DataGridViewPanel_Markets.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewPanel_Markets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewPanel_Markets.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPMarketCrossReference.Properties.MarketCode.ToString Then

                Datasource = _ViewModel.RepositoryMarketList

            End If

        End Sub
        Private Sub DataGridViewPanel_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewPanel_Markets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewPanel_Markets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewPanel_Markets.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewPanel_Markets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewPanel_Markets.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewPanel_Markets.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewPanel_Markets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewPanel_Markets.CurrentView.SetColumnError(DataGridViewPanel_Markets.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewPanel_Markets_ColumnValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewPanel_Markets.ColumnValueChangedEvent

            If e.Column.FieldName = DTO.Media.RFP.MediaRFPMarketCrossReference.Properties.MarketCode.ToString Then

                _Controller.SetMarketDescription(_ViewModel, e.Value)

                DataGridViewPanel_Markets.RefreshDataSource()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
