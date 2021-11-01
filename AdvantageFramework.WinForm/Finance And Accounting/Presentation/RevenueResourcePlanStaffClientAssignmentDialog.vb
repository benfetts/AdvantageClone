Namespace FinanceAndAccounting.Presentation

    Public Class RevenueResourcePlanStaffClientAssignmentDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController = Nothing
        Protected _RevenueResourcePlanID As Integer = 0
        Protected _RevenueResourcePlanStaffID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _RevenueResourcePlanID = RevenueResourcePlanID
            _RevenueResourcePlanStaffID = RevenueResourcePlanStaffID

        End Sub
        Private Sub LoadViewModel()

            DataGridViewForm_StaffClientAssignments.DataSource = _ViewModel.PlanStaffClientAssignments

            DataGridViewForm_StaffClientAssignments.ItemDescription = _ViewModel.PlanStaff.HoursAvailable & " Hours Available"

            DataGridViewForm_StaffClientAssignments.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Client.ToString).OptionsColumn.AllowFocus = False
            DataGridViewForm_StaffClientAssignments.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Division.ToString).OptionsColumn.AllowFocus = False
            DataGridViewForm_StaffClientAssignments.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Product.ToString).OptionsColumn.AllowFocus = False
            DataGridViewForm_StaffClientAssignments.Columns(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Hours.ToString).OptionsColumn.AllowFocus = False

        End Sub
        Private Sub SaveViewModel()

            '_ViewModel.Worksheet.Name = TextBoxForm_Description.Text

        End Sub
        Private Sub RefreshViewModel()

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled
            ButtonItemCDP_Add.Enabled = _ViewModel.CDPAddEnabled
            ButtonItemCDP_Delete.Enabled = _ViewModel.CDPDeleteEnabled

        End Sub
        Private Sub SetControlDataSources()



        End Sub
        Private Sub SetControlPropertySettings()

            DataGridViewForm_StaffClientAssignments.SetupForEditableGrid()

            DataGridViewForm_StaffClientAssignments.MultiSelect = False
            DataGridViewForm_StaffClientAssignments.SetBookmarkColumnIndex(0)
            DataGridViewForm_StaffClientAssignments.OptionsView.ShowFooter = True

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            GridColumn = DataGridViewForm_StaffClientAssignments.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Percent.ToString)

            If GridColumn IsNot Nothing Then

                GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)

                GridColumnSummaryItem.FieldName = GridColumn.FieldName
                GridColumnSummaryItem.DisplayFormat = "{0:p0}"

                GridColumn.Summary.Add(GridColumnSummaryItem)

            End If

            GridColumn = DataGridViewForm_StaffClientAssignments.CurrentView.Columns.ColumnByFieldName(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Hours.ToString)

            If GridColumn IsNot Nothing Then

                GridColumnSummaryItem = New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)

                GridColumnSummaryItem.FieldName = GridColumn.FieldName
                GridColumnSummaryItem.DisplayFormat = "{0:n1}"

                GridColumn.Summary.Add(GridColumnSummaryItem)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim RevenueResourcePlanStaffClientAssignmentDialog As RevenueResourcePlanStaffClientAssignmentDialog = Nothing

            RevenueResourcePlanStaffClientAssignmentDialog = New RevenueResourcePlanStaffClientAssignmentDialog(RevenueResourcePlanID, RevenueResourcePlanStaffID)

            ShowFormDialog = RevenueResourcePlanStaffClientAssignmentDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RevenueResourcePlanStaffClientAssignmentDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemCDP_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemCDP_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            SetControlPropertySettings()

            _Controller = New AdvantageFramework.Controller.FinanceAndAccounting.RevenueResourcePlanController(Me.Session)

            _ViewModel = _Controller.StaffClientAssignment_Load(_RevenueResourcePlanID, _RevenueResourcePlanStaffID)

            LoadViewModel()

            FormatGrid()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            DataGridViewForm_StaffClientAssignments.CurrentView.BestFitColumns()

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewForm_StaffClientAssignments.GridViewSelectionChanged()

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.StaffClientAssignment_UserEntryChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub
        Private Sub RevenueResourcePlanStaffClientAssignmentDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.StaffClientAssignment_ClearChanged(_ViewModel)

                RefreshViewModel()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewForm_StaffClientAssignments.CloseGridEditorAndSaveValueToDataSource()

            If _Controller.StaffClientAssignment_Validate(_ViewModel) Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.StaffClientAssignment_Save(_ViewModel)

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Percent total is greater than 100. Please correct before saving.")

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_StaffClientAssignments.CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

            _Controller.StaffClientAssignment_LoadPlanStaffClientAssignments(_ViewModel)

            LoadViewModel()

            Me.ClearChanged()

            RefreshViewModel()

            DataGridViewForm_StaffClientAssignments.CurrentView.UpdateSummary()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Me.RaiseClearChanged()

        End Sub
        Private Sub ButtonItemCDP_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCDP_Add.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_StaffClientAssignments.CloseGridEditorAndSaveValueToDataSource()

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    _Controller.StaffClientAssignment_Save(_ViewModel)

                    [Continue] = True

                    Me.ClearChanged()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.RaiseClearChanged()

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                If RevenueResourcePlanStaffClientAssignmentAddCDPDialog.ShowFormDialog(_ViewModel.Plan.ID, _ViewModel.PlanStaff.ID) = System.Windows.Forms.DialogResult.OK Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

                    _Controller.StaffClientAssignment_LoadPlanStaffClientAssignments(_ViewModel)

                    LoadViewModel()

                    DataGridViewForm_StaffClientAssignments.CurrentView.BestFitColumns()

                    Me.ClearChanged()

                    RefreshViewModel()

                    DataGridViewForm_StaffClientAssignments.CurrentView.UpdateSummary()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.RaiseClearChanged()

                End If

            End If

        End Sub
        Private Sub ButtonItemCDP_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemCDP_Delete.Click

            'objects
            Dim [Continue] As Boolean = False

            DataGridViewForm_StaffClientAssignments.CloseGridEditorAndSaveValueToDataSource()

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You need to save your changes before continuing.  Do you want to save your changes now?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Save Changes?") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                    _Controller.StaffClientAssignment_Save(_ViewModel)

                    [Continue] = True

                    Me.ClearChanged()

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    Me.RaiseClearChanged()

                End If

            Else

                [Continue] = True

            End If

            If [Continue] Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                _Controller.StaffClientAssignment_DeletePlanStaffClientAssignment(_ViewModel, DataGridViewForm_StaffClientAssignments.GetFirstSelectedRowDataBoundItem)

                _Controller.StaffClientAssignment_LoadPlanStaffClientAssignments(_ViewModel)

                LoadViewModel()

                Me.ClearChanged()

                RefreshViewModel()

                DataGridViewForm_StaffClientAssignments.CurrentView.UpdateSummary()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                Me.RaiseClearChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_StaffClientAssignments_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewForm_StaffClientAssignments.FocusedRowChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None AndAlso Me.FormShown AndAlso
                    DataGridViewForm_StaffClientAssignments.CurrentView.OptionsView.ShowIndicator Then

                _Controller.StaffClientAssignment_SelectedPlanStaffClientAssignmentChanged(_ViewModel, DataGridViewForm_StaffClientAssignments.GetFirstSelectedRowDataBoundItem())

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewForm_StaffClientAssignments_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_StaffClientAssignments.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Percent.ToString Then

                _Controller.StaffClientAssignment_PercentChanged(_ViewModel, DataGridViewForm_StaffClientAssignments.GetFirstSelectedRowDataBoundItem(), e.Value)

                DataGridViewForm_StaffClientAssignments.CurrentView.UpdateSummary()

            End If

        End Sub
        Private Sub DataGridViewForm_StaffClientAssignments_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_StaffClientAssignments.ShowingEditorEvent

            'If DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn IsNot Nothing Then

            '    If DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Client.ToString OrElse
            '            DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Division.ToString OrElse
            '            DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Product.ToString OrElse
            '            DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment.Properties.Hours.ToString Then

            '        DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn = DataGridViewForm_StaffClientAssignments.CurrentView.GetNearestCanFocusedColumn(DataGridViewForm_StaffClientAssignments.CurrentView.FocusedColumn)

            '    End If

            'End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
