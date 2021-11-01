Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadViewModel()

            LoadGrid()

            LoadDashboardDataSource()

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Update.Enabled = _ViewModel.UpdateEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled
            ButtonItemActions_Refresh.Enabled = _ViewModel.RefreshEnabled

            ButtonItemManage_Staff.Enabled = _ViewModel.StaffEnabled
            ButtonItemManage_Revenue.Enabled = _ViewModel.RevenueEnabled
            ButtonItemManage_Resources.Enabled = _ViewModel.ResourcesEnabled

            ButtonItemDashboard_Edit.Enabled = _ViewModel.DashbaordEditEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_Plans.OptionsBehavior.Editable = False

        End Sub
        Private Sub LoadGrid()

            _Controller.Setup_LoadPlans(_ViewModel)

            DataGridViewForm_Plans.CurrentView.BeginUpdate()

            DataGridViewForm_Plans.DataSource = _ViewModel.Plans

            DataGridViewForm_Plans.CurrentView.EndUpdate()

        End Sub
        Private Sub FormatGrid()

            DataGridViewForm_Plans.OptionsCustomization.AllowGroup = False
            DataGridViewForm_Plans.OptionsCustomization.AllowColumnMoving = False
            DataGridViewForm_Plans.OptionsCustomization.AllowQuickHideColumns = False

        End Sub
        Private Sub LoadDashboard()

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            'DashboardViewerForm_Dashboard.Dashboard.BeginUpdate()

            If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                DashboardViewerForm_Dashboard.LoadDashboard(MemoryStream)

            Else

                If AdvantageFramework.My.Resources.RevenueResourcePlanDashboard IsNot Nothing AndAlso AdvantageFramework.My.Resources.RevenueResourcePlanDashboard.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.RevenueResourcePlanDashboard)

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
        Private Function CheckForOpenResourceSetupTab(RevenueResourcePlanID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanResourceSetupForm Then

                        If DirectCast(MdiChildForm, AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanResourceSetupForm).RevenueResourcePlanID = RevenueResourcePlanID Then

                            MdiChildForm.Activate()

                            IsOpened = True
                            Exit For

                        End If

                    End If

                Next

            End If

            CheckForOpenResourceSetupTab = IsOpened

        End Function
        Private Function CheckForOpenRevenueSetupTab(RevenueResourcePlanID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanRevenueSetupForm Then

                        If DirectCast(MdiChildForm, AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanRevenueSetupForm).RevenueResourcePlanID = RevenueResourcePlanID Then

                            MdiChildForm.Activate()

                            IsOpened = True
                            Exit For

                        End If

                    End If

                Next

            End If

            CheckForOpenRevenueSetupTab = IsOpened

        End Function
        Private Function CheckForOpenStaffSetupTab(RevenueResourcePlanID As Integer) As Boolean

            'objects
            Dim IsOpened As Boolean = False

            If TypeOf MdiParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                For Each MdiChildForm In DirectCast(MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).MdiChildren

                    If TypeOf MdiChildForm Is AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanRevenueSetupForm Then

                        If DirectCast(MdiChildForm, AdvantageFramework.FinanceAndAccounting.Presentation.RevenueResourcePlanRevenueSetupForm).RevenueResourcePlanID = RevenueResourcePlanID Then

                            MdiChildForm.Activate()

                            IsOpened = True
                            Exit For

                        End If

                    End If

                Next

            End If

            CheckForOpenStaffSetupTab = IsOpened

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim RevenueResourcePlanSetupForm As RevenueResourcePlanSetupForm = Nothing

            RevenueResourcePlanSetupForm = New RevenueResourcePlanSetupForm

            RevenueResourcePlanSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Update.Image = AdvantageFramework.My.Resources.UpdateImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemManage_Staff.Image = AdvantageFramework.My.Resources.EmployeesImage
            ButtonItemManage_Revenue.Image = AdvantageFramework.My.Resources.ClientCashReceiptsImage
            ButtonItemManage_Resources.Image = AdvantageFramework.My.Resources.DepartmentTeamListImage

            ButtonItemDashboard_Edit.Image = AdvantageFramework.My.Resources.EditImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.Setup_Load()

            LoadViewModel()

            LoadGrid()

            FormatGrid()

            LoadDashboard()

            LoadDashboardDataSource()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_Plans.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewForm_Plans.GridViewSelectionChanged()

            DataGridViewForm_Plans.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim RevenueResourcePlanID As Integer = 0

            If RevenueResourcePlanEditDialog.ShowFormDialog(RevenueResourcePlanID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadViewModel()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                If RevenueResourcePlanID <> 0 Then

                    DataGridViewForm_Plans.SelectRow(0, RevenueResourcePlanID)

                End If

                DataGridViewForm_Plans.GridViewSelectionChanged()

                DataGridViewForm_Plans.CurrentView.BestFitColumns()

                RefreshViewModel()

            End If

        End Sub
        Private Sub ButtonItemActions_Update_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Update.Click

            If RevenueResourcePlanEditDialog.ShowFormDialog(_ViewModel.SelectedPlan.ID) = Windows.Forms.DialogResult.OK Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading, "Loading...")

                LoadViewModel()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewForm_Plans.GridViewSelectionChanged()

                DataGridViewForm_Plans.CurrentView.BestFitColumns()

                RefreshViewModel()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete this revenue & resource plan?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                _Controller.Delete(_ViewModel.SelectedPlan, ErrorMessage)

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    LoadViewModel()

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewForm_Plans.GridViewSelectionChanged()

                    DataGridViewForm_Plans.CurrentView.BestFitColumns()

                    RefreshViewModel()

                    Me.CloseWaitForm()

                Else

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Copying)

            _Controller.Copy(_ViewModel.SelectedPlan, ErrorMessage)

            If String.IsNullOrWhiteSpace(ErrorMessage) Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                LoadViewModel()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                DataGridViewForm_Plans.GridViewSelectionChanged()

                DataGridViewForm_Plans.CurrentView.BestFitColumns()

                RefreshViewModel()

                Me.CloseWaitForm()

            Else

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)
                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Refreshing)

            LoadViewModel()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_Plans.GridViewSelectionChanged()

            DataGridViewForm_Plans.CurrentView.BestFitColumns()

            RefreshViewModel()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            MemoryStream = New System.IO.MemoryStream

            If DashboardViewerForm_Dashboard.Dashboard IsNot Nothing Then

                DashboardViewerForm_Dashboard.Dashboard.SaveToXml(MemoryStream)

                DashboardLayout = MemoryStream.ToArray
                MemoryStream.Flush()
                MemoryStream.Close()

                If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.DashboardDataSource, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                    _Controller.Setup_SaveDashboard(_ViewModel, DashboardLayout)

                    LoadDashboard()

                End If

                LoadDashboardDataSource()

            End If

        End Sub
        Private Sub ButtonItemManage_Staff_Click(sender As Object, e As EventArgs) Handles ButtonItemManage_Staff.Click

            If CheckForOpenStaffSetupTab(_ViewModel.SelectedPlan.ID) = False Then

                RevenueResourcePlanStaffManageForm.ShowForm(_ViewModel.SelectedPlan.ID)

            End If

        End Sub
        Private Sub ButtonItemManage_Revenue_Click(sender As Object, e As EventArgs) Handles ButtonItemManage_Revenue.Click

            If CheckForOpenRevenueSetupTab(_ViewModel.SelectedPlan.ID) = False Then

                RevenueResourcePlanRevenueSetupForm.ShowForm(_ViewModel.SelectedPlan.ID)

            End If

        End Sub
        Private Sub ButtonItemManage_Resources_Click(sender As Object, e As EventArgs) Handles ButtonItemManage_Resources.Click

            If CheckForOpenResourceSetupTab(_ViewModel.SelectedPlan.ID) = False Then

                RevenueResourcePlanResourceSetupForm.ShowForm(_ViewModel.SelectedPlan.ID)

            End If

        End Sub
        Private Sub DataGridViewForm_Plans_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_Plans.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_Plans.CurrentView.OptionsView.ShowIndicator Then

                _Controller.Setup_SelectedPlanChanged(_ViewModel, DataGridViewForm_Plans.GetFirstSelectedRowDataBoundItem())

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_Plans_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Plans.CellValueChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown Then

                If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan.Properties.Notes.ToString Then

                    '_Controller.setu(_ViewModel, DataGridViewForm_Plans.GetRowDataBoundItem(e.RowHandle))

                    'RefreshViewModel()

                    'ElseIf e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff.Properties.DirectPercentGoal.ToString Then

                    '    _Controller.StaffManage_SaveDirectPercentGoal(_ViewModel, DataGridViewForm_Staff.GetRowDataBoundItem(e.RowHandle))

                    '    RefreshViewModel()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Plans_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles DataGridViewForm_Plans.PopupMenuShowingEvent

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
