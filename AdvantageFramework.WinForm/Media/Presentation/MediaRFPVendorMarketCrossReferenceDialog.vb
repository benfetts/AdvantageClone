Namespace Media.Presentation

    Public Class MediaRFPVendorMarketCrossReferenceDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaRFPVendorMarketCrossReferenceController = Nothing
        Protected _VendorCode As String = Nothing
        Protected _VendorName As String = Nothing
        Protected _SourceMarketNames As IEnumerable(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(VendorCode As String, VendorName As String, SourceMarketNames As IEnumerable(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _VendorName = VendorName
            _SourceMarketNames = SourceMarketNames

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_VendorCode, _SourceMarketNames)

        End Sub
        Private Sub LoadGrid()

            DataGridViewPanel_VendorMarkets.DataSource = _ViewModel.MediaRFPVendorMarketCrossReferenceList

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewPanel_VendorMarkets.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            TextBoxPanel_VendorCode.ReadOnly = True
            TextBoxPanel_VendorName.ReadOnly = True

            DataGridViewPanel_VendorMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewPanel_VendorMarkets.OptionsBehavior.Editable = True
            DataGridViewPanel_VendorMarkets.MultiSelect = False

        End Sub
        Private Sub AddNewRow(MediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference)

            Dim ErrorMessage As String = Nothing

            If MediaRFPVendorMarketCrossReference IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.Add(MediaRFPVendorMarketCrossReference, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewPanel_VendorMarkets.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewPanel_VendorMarkets.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(VendorCode As String, VendorName As String, SourceMarketNames As IEnumerable(Of String)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaRFPVendorMarketCrossReferenceDialog As MediaRFPVendorMarketCrossReferenceDialog = Nothing

            MediaRFPVendorMarketCrossReferenceDialog = New MediaRFPVendorMarketCrossReferenceDialog(VendorCode, VendorName, SourceMarketNames)

            ShowFormDialog = MediaRFPVendorMarketCrossReferenceDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaRFPVendorMarketCrossReferenceDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaRFPVendorMarketCrossReferenceController(Me.Session)

            SetControlPropertySettings()

            TextBoxPanel_VendorCode.Text = _VendorCode
            TextBoxPanel_VendorName.Text = _VendorName

        End Sub
        Private Sub MediaRFPVendorMarketCrossReferenceDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            RefreshViewModel(True)

            Me.ClearChanged()

            DataGridViewPanel_VendorMarkets.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaRFPVendorMarketCrossReferenceDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaRFPVendorMarketCrossReferenceDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

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

            DataGridViewPanel_VendorMarkets.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewPanel_VendorMarkets.HasASelectedRow Then

                DataGridViewPanel_VendorMarkets.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_VendorMarkets.IsNewItemRow, DataGridViewPanel_VendorMarkets.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewPanel_VendorMarkets.CurrentView.CloseEditorForUpdating()

            'If _ViewModel.MediaRFPVendorMarketCrossReferenceList.Any(Function(Entity) Entity.HasError) = False Then

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

            _Controller.Save(_ViewModel)

            RefreshViewModel(False)

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            'Else

            '    AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before saving.")

            'End If

        End Sub
        Private Sub DataGridViewPanel_VendorMarkets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewPanel_VendorMarkets.FocusedRowChangedEvent

            _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_VendorMarkets.IsNewItemRow, DataGridViewPanel_VendorMarkets.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewPanel_VendorMarkets_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewPanel_VendorMarkets.InitNewRowEvent

            DirectCast(DataGridViewPanel_VendorMarkets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference).VendorCode = _VendorCode

        End Sub
        Private Sub DataGridViewPanel_VendorMarkets_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewPanel_VendorMarkets.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPVendorMarketCrossReference.Properties.MarketCode.ToString Then

                Datasource = _ViewModel.RepositoryMarketList

            End If

        End Sub
        Private Sub DataGridViewPanel_VendorMarkets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewPanel_VendorMarkets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewPanel_VendorMarkets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewPanel_VendorMarkets.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewPanel_VendorMarkets_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewPanel_VendorMarkets.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewPanel_VendorMarkets.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewPanel_VendorMarkets.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewPanel_VendorMarkets.CurrentView.SetColumnError(DataGridViewPanel_VendorMarkets.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
