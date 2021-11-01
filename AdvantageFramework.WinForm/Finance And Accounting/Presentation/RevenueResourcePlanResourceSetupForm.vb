Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanResourceSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0

#End Region

#Region " Properties "

        Public ReadOnly Property RevenueResourcePlanID As Integer
            Get
                RevenueResourcePlanID = _RevenueResourcePlanID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _RevenueResourcePlanID = RevenueResourcePlanID

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

            LoadDashboardDataSource()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

            ButtonItemResource_ViewDetails.Enabled = _ViewModel.ResourceViewDetailsEnabled

            ButtonItemDashboard_Edit.Enabled = _ViewModel.DashbaordEditEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Clients.SetupForEditableGrid()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Clients.DataSource = _ViewModel.PlanClientResources

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If DataGridViewForm_Clients.Columns.ColumnByFieldName(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource.Properties.OwnerCode.ToString) IsNot Nothing Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default
                'SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                SubItemGridLookUpEditControl.DisplayMember = "Display"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _ViewModel.Employees.ToList

                SubItemGridLookUpEditControl.DataSource = BindingSource

                AdvantageFramework.WinForm.Presentation.Controls.AddComboItemToExistingDataSource(BindingSource, "Display", "Value", "[None]", String.Empty, True, False, Nothing)

                DataGridViewForm_Clients.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewForm_Clients.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource.Properties.OwnerCode.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

            DataGridViewForm_Clients.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Clients.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Clients.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub LoadDashboard()

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            'DashboardViewerForm_Dashboard.Dashboard.BeginUpdate()

            If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                DashboardViewerForm_Dashboard.LoadDashboard(MemoryStream)

            Else

                If AdvantageFramework.My.Resources.RevenueResourcePlanResourceDashboard IsNot Nothing AndAlso AdvantageFramework.My.Resources.RevenueResourcePlanResourceDashboard.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.RevenueResourcePlanResourceDashboard)

                    DashboardViewerForm_Dashboard.LoadDashboard(MemoryStream)

                End If

            End If

            'DashboardViewerForm_Dashboard.Dashboard.EndUpdate()

        End Sub
        Private Sub LoadDashboardDataSource()

            If DashboardViewerForm_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerForm_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerForm_Dashboard.Dashboard.DataSources.Add(_ViewModel.DashboardDataSource)

                Else

                    DashboardViewerForm_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.DashboardDataSource

                End If

                DashboardViewerForm_Dashboard.Refresh()

            End If

        End Sub
        Private Function CheckForOpenResourceManageTab(RevenueResourcePlanResourceID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanResourceManageForm Then

                        If DirectCast(MdiChildForm, AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanResourceManageForm).RevenueResourcePlanResourceID = RevenueResourcePlanResourceID Then

                            MdiChildForm.Activate()

                            IsOpened = True
                            Exit For

                        End If

                    End If

                Next

            End If

            CheckForOpenResourceManageTab = IsOpened

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(RevenueResourcePlanID As Integer)

            'objects
            Dim RevenueResourcePlanResourceSetupForm As RevenueResourcePlanResourceSetupForm = Nothing

            RevenueResourcePlanResourceSetupForm = New RevenueResourcePlanResourceSetupForm(RevenueResourcePlanID)

            RevenueResourcePlanResourceSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanResourceSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemResource_ViewDetails.Image = AdvantageFramework.My.Resources.ViewImage

            ButtonItemDashboard_Edit.Image = AdvantageFramework.My.Resources.EditImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.ResourceSetup_Load(_RevenueResourcePlanID)

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            LoadDashboard()

            LoadDashboardDataSource()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_Clients.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanResourceSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_Clients.GridViewSelectionChanged()

            Me.Text &= " - (" & _ViewModel.Plan.Description & ")"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            DataGridViewForm_Clients.CloseGridEditorAndSaveValueToDataSource()

            If RevenueResourcePlanResourceAddDialog.ShowFormDialog(_RevenueResourcePlanID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                _Controller.ResourceSetup_LoadPlanClientResources(_ViewModel)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewForm_Clients.GridViewSelectionChanged()

                DataGridViewForm_Clients.CurrentView.BestFitColumns()

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            DataGridViewForm_Clients.CloseGridEditorAndSaveValueToDataSource()

            If CheckForOpenResourceManageTab(_ViewModel.SelectedPlanClientResource.ID) = False Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this resource plan?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    _Controller.ResourceSetup_Delete(_ViewModel, DataGridViewForm_Clients.GetFirstSelectedRowDataBoundItem())

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    LoadViewModel()

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewForm_Clients.GridViewSelectionChanged()

                    DataGridViewForm_Clients.CurrentView.BestFitColumns()

                    RefreshViewModel()

                    Me.CloseWaitForm()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please close resource detail window before deleting.")

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            DataGridViewForm_Clients.CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

            _Controller.ResourceSetup_LoadPlanClientResources(_ViewModel)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_Clients.GridViewSelectionChanged()

            DataGridViewForm_Clients.CurrentView.BestFitColumns()

            RefreshViewModel()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemResource_ViewDetails_Click(sender As Object, e As EventArgs) Handles ButtonItemResource_ViewDetails.Click

            If CheckForOpenResourceManageTab(_ViewModel.SelectedPlanClientResource.ID) = False Then

                RevenueResourcePlanResourceManageForm.ShowForm(_ViewModel.SelectedPlanClientResource.RevenueResourcePlanID, _ViewModel.SelectedPlanClientResource.ID, _ViewModel.SelectedPlanClientResource.RevenueResourcePlanResourceRevisionID)

            End If

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            DataGridViewForm_Clients.CloseGridEditorAndSaveValueToDataSource()

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerForm_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerForm_Dashboard.Dashboard.SaveToXml(MemoryStream)

                DashboardLayout = MemoryStream.ToArray
                MemoryStream.Flush()
                MemoryStream.Close()

                If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.DashboardDataSource, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                    _Controller.ResourceSetup_SaveDashboard(_ViewModel, DashboardLayout)

                    LoadDashboard()

                End If

                LoadDashboardDataSource()

            End If

        End Sub
        Private Sub DataGridViewForm_Clients_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Clients.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_Clients.CurrentView.OptionsView.ShowIndicator Then

                _Controller.ResourceSetup_SelectedPlanClientResourceChanged(_ViewModel, DataGridViewForm_Clients.GetFirstSelectedRowDataBoundItem())

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Clients_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Clients.CellValueChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource.Properties.Notes.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource.Properties.RevisionNotes.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource.Properties.OwnerCode.ToString Then

                    _Controller.ResourceSetup_Save(_ViewModel, DataGridViewForm_Clients.GetRowDataBoundItem(e.RowHandle))

                    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Clients_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewForm_Clients.RowDoubleClickEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                ButtonItemResource_ViewDetails.RaiseClick()

            End If

        End Sub
        Private Sub DataGridViewForm_Clients_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_Clients.PopupMenuShowingEvent

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                For Each MenuItem As DevExpress.Utils.Menu.DXMenuItem In e.Menu.Items

                    Select Case MenuItem.Tag

                        Case DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnShowColumn,
                                 DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn

                            MenuItem.Visible = False

                    End Select

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
