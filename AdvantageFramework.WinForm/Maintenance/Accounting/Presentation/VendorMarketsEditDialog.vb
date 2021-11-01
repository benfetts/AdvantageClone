Namespace Maintenance.Accounting.Presentation

    Public Class VendorMarketsEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorMarketsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.VendorMarketsController = Nothing
        Protected _VendorCode As String = String.Empty
        Protected _MarketCode As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(VendorCode As String, MarketCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _MarketCode = MarketCode

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

        End Sub
        Private Sub SaveViewModel()

            '_ViewModel.Vendor.MarketCode = ComboBoxForm_HomeMarket.GetSelectedValue

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonItemMarkets_Delete.Enabled = _ViewModel.MarketDeleteEnabled
            ButtonItemMarkets_Cancel.Enabled = _ViewModel.MarketCancelEnabled
            ButtonItemMarkets_MoveUp.Enabled = _ViewModel.MarketMoveUpEnabled
            ButtonItemMarkets_MoveDown.Enabled = _ViewModel.MarketMoveDownEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Markets.OptionsView.ShowColumnHeaders = False
            DataGridViewForm_Markets.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Markets.OptionsCustomization.AllowFilter = False
            DataGridViewForm_Markets.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Markets.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_Markets.OptionsCustomization.AllowSort = False
            DataGridViewForm_Markets.OptionsMenu.EnableColumnMenu = False

            DataGridViewForm_Markets.SetBookmarkColumnIndex(2)

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Markets.DataSource = _ViewModel.VendorMarkets.ToList

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Vendor.Properties.MarketCode.ToString) IsNot Nothing Then

                DataGridViewForm_Markets.CurrentView.AutoFillColumn = DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Vendor.Properties.MarketCode.ToString)

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Description"
                SubItemGridLookUpEditControl.ValueMember = "Code"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Code"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Description"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("StateProvince"))

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _ViewModel.Markets.ToList

                SubItemGridLookUpEditControl.DataSource = BindingSource

                AddHandler SubItemGridLookUpEditControl.QueryPopUp, AddressOf SubItemGridLookUpEditControl_MarketQueryPopup

                DataGridViewForm_Markets.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Markets.Columns(AdvantageFramework.DTO.Maintenance.Accounting.Vendor.Vendor.Properties.MarketCode.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            DataGridViewForm_Markets.CurrentView.BestFitColumns()

        End Sub
        Protected Sub SubItemGridLookUpEditControl_MarketQueryPopup(sender As Object, e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If TypeOf DataGridViewForm_Markets.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Markets.CurrentView.ActiveEditor

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _Controller.LoadMarkets(_ViewModel)

                GridLookUpEdit.Properties.DataSource = BindingSource

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(VendorCode As String, MarketCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorMarketsEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.VendorMarketsEditDialog = Nothing

            VendorMarketsEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.VendorMarketsEditDialog(VendorCode, MarketCode)

            ShowFormDialog = VendorMarketsEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorMarketsEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemMarkets_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemMarkets_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemMarkets_MoveUp.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemMarkets_MoveDown.Image = AdvantageFramework.My.Resources.DownImage

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.VendorMarketsController(Me.Session)

            _ViewModel = _Controller.Load(_VendorCode, _MarketCode)

            SetControlDataSources()

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub VendorMarketsEditDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewForm_Markets.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            DataGridViewForm_Markets.CloseGridEditorAndSaveValueToDataSource()
            DataGridViewForm_Markets.CurrentView.CloseEditorForUpdating()

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    If _Controller.Save(_ViewModel, ErrorMessage) Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemMarkets_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_Delete.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    _Controller.DeleteMarket(_ViewModel)

                    LoadGrid()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    DataGridViewForm_Markets.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemMarkets_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemMarkets_Cancel.Click

            DataGridViewForm_Markets.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemMarkets_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_MoveUp.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                _Controller.MoveUpMarkets(_ViewModel)

                LoadGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub ButtonItemMarkets_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonItemMarkets_MoveDown.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

                _Controller.MoveDownMarkets(_ViewModel)

                LoadGrid()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Markets.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewForm_Markets.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewForm_Markets.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        _Controller.AddMarket(_ViewModel, e.Row)

                        'LoadGrid()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Markets.InitNewRowEvent

            _Controller.InitNewRowEvent(_ViewModel, DataGridViewForm_Markets.CurrentView.GetRow(e.RowHandle))

            RefreshViewModel()

        End Sub
        Private Sub DataGridViewForm_Markets_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Markets.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                _Controller.SelectionChanged(_ViewModel, DataGridViewForm_Markets.IsNewItemRow, DataGridViewForm_Markets.GetFirstSelectedRowDataBoundItem)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Markets_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_Markets.ShowingEditorEvent

            If DataGridViewForm_Markets.IsNewItemRow(DataGridViewForm_Markets.CurrentView.FocusedRowHandle) = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace