Imports DevExpress.XtraGrid.Views.Grid

Namespace Maintenance.Accounting.Presentation

    Public Class VendorComboRadioStationDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorComboRadioStationViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Accounting.VendorComboRadioStationController = Nothing
        Protected _VendorCode As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(VendorCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _VendorCode = VendorCode

        End Sub
        Private Sub LoadViewModel()

            LoadAvailableVendorsGrid()
            LoadSelectedVendorsGrid()

        End Sub
        Private Sub SaveViewModel()



        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

            ButtonForm_Add.Enabled = _ViewModel.AddEnabled
            ButtonForm_AddAll.Enabled = _ViewModel.AddAllEnabled
            ButtonForm_Remove.Enabled = _ViewModel.RemoveEnabled
            ButtonForm_RemoveAll.Enabled = _ViewModel.RemoveAllEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_AvailableVendors.OptionsBehavior.Editable = False
            DataGridViewForm_AvailableVendors.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_AvailableVendors.OptionsCustomization.AllowGroup = False
            DataGridViewForm_AvailableVendors.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_AvailableVendors.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_AvailableVendors.MultiSelect = True
            DataGridViewForm_AvailableVendors.OptionsView.ColumnAutoWidth = False

            DataGridViewForm_SelectedVendors.OptionsBehavior.Editable = False
            DataGridViewForm_SelectedVendors.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_SelectedVendors.OptionsCustomization.AllowGroup = False
            DataGridViewForm_SelectedVendors.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewForm_SelectedVendors.OptionsMenu.EnableColumnMenu = False
            DataGridViewForm_SelectedVendors.MultiSelect = True
            DataGridViewForm_SelectedVendors.OptionsView.ColumnAutoWidth = False

            DataGridViewForm_AvailableVendors.SetBookmarkColumnIndex(2)
            DataGridViewForm_SelectedVendors.SetBookmarkColumnIndex(2)

        End Sub
        Private Sub LoadAvailableVendorsGrid()

            DataGridViewForm_AvailableVendors.DataSource = _ViewModel.AvailableVendors.ToList

        End Sub
        Private Sub LoadSelectedVendorsGrid()

            DataGridViewForm_SelectedVendors.DataSource = _ViewModel.SelectedVendors.ToList

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_AvailableVendors.CurrentView.BestFitColumns()
            DataGridViewForm_SelectedVendors.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(VendorCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim VendorComboRadioStationDialog As Maintenance.Accounting.Presentation.VendorComboRadioStationDialog = Nothing

            VendorComboRadioStationDialog = New Maintenance.Accounting.Presentation.VendorComboRadioStationDialog(VendorCode)

            ShowFormDialog = VendorComboRadioStationDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub VendorComboRadioStationDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.Maintenance.Accounting.VendorComboRadioStationController(Me.Session)

            _ViewModel = _Controller.Load(_VendorCode)

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub VendorComboRadioStationDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RefreshViewModel()

            DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
            DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                If _Controller.Save(_ViewModel, ErrorMessage) Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    AdvantageFramework.WinForm.MessageBox.Show(Me, ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Add_Click(sender As Object, e As EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                AvailableVendors = DataGridViewForm_AvailableVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.AddVendors(_ViewModel, AvailableVendors)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_AddAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_AddAll.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.AddAllVendors(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_Remove_Click(sender As Object, e As EventArgs) Handles ButtonForm_Remove.Click

            'objects
            Dim SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                SelectedVendors = DataGridViewForm_SelectedVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.RemoveVendors(_ViewModel, SelectedVendors)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonForm_RemoveAll_Click(sender As Object, e As EventArgs) Handles ButtonForm_RemoveAll.Click

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                _Controller.RemoveAllVendors(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_AvailableVendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AvailableVendors.SelectionChangedEvent

            'objects
            Dim AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                AvailableVendors = DataGridViewForm_AvailableVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.AvailableVendorsSelectedChanged(_ViewModel, AvailableVendors)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_AvailableVendors_RowDoubleClickEvent(sender As Object, e As RowClickEventArgs) Handles DataGridViewForm_AvailableVendors.RowDoubleClickEvent

            'objects
            Dim AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewForm_AvailableVendors.HasOnlyOneSelectedRow Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                AvailableVendors = DataGridViewForm_AvailableVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.AddVendors(_ViewModel, AvailableVendors)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_SelectedVendors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_SelectedVendors.SelectionChangedEvent

            'objects
            Dim SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                SelectedVendors = DataGridViewForm_SelectedVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.SelectedVendorsSelectedChanged(_ViewModel, SelectedVendors)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_SelectedVendors_RowDoubleClickEvent(sender As Object, e As RowClickEventArgs) Handles DataGridViewForm_SelectedVendors.RowDoubleClickEvent

            'objects
            Dim SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation) = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso DataGridViewForm_SelectedVendors.HasOnlyOneSelectedRow Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding)

                SelectedVendors = DataGridViewForm_SelectedVendors.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation).ToList

                _Controller.RemoveVendors(_ViewModel, SelectedVendors)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                RefreshViewModel()

                DataGridViewForm_AvailableVendors.GridViewSelectionChanged()
                DataGridViewForm_SelectedVendors.GridViewSelectionChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
