Namespace Media.Presentation

    Public Class MediaPlanEstimateGRPBudgetDialog

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum Actualize
            NoRollFoward
            RollFowardAll
            RollFowardNext
            RollFowardPercent
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanEstimateGRPBudgetViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaPlanningController = Nothing
        Protected _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlan = MediaPlan

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.UserEntryChanged Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Save()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemSystem_Close.Enabled = (Me.UserEntryChanged = False)
            ButtonItemActions_Apply.Enabled = (Me.UserEntryChanged = False)

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.EstimateGRPBudget_Load(_MediaPlan)

            DataGridViewForm_GRPBudget.DataSource = _ViewModel.MediaPlanDetailGRPBudgets
            DataGridViewForm_GRPBudget.CurrentView.BestFitColumns()

            If DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.MarketDescription.ToString) IsNot Nothing Then

                DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.MarketDescription.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.SpotLength.ToString) IsNot Nothing Then

                If _ViewModel.HasSpotLengths Then

                    DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.SpotLength.ToString).OptionsColumn.AllowFocus = False

                Else

                    DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.SpotLength.ToString).Visible = False

                End If

            End If

            If DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.EntryDate.ToString) IsNot Nothing Then

                DataGridViewForm_GRPBudget.CurrentView.Columns(AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.EntryDate.ToString).OptionsColumn.AllowFocus = False

            End If

        End Sub
        Private Function Save() As Boolean

            Dim Saved As Boolean = True

            DataGridViewForm_GRPBudget.CloseGridEditorAndSaveValueToDataSource()

            _ViewModel.MediaPlanDetailGRPBudgets = DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList

            Saved = _Controller.EstimateGRPBudget_Save(_ViewModel)

            LoadViewModel()

            Save = Saved

        End Function
        Private Sub EnableDisableCopyButton()

            Dim SelectedMarketLengths As IEnumerable(Of String) = Nothing

            If _ViewModel.HasSpotLengths AndAlso (From Entity In DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
                                                  Select Entity.MarketCode, Entity.SpotLength).Distinct.Count = 1 Then

                SelectedMarketLengths = (From Entity In DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
                                         Select Entity.MarketCode & "|" & Entity.SpotLength.Value).Distinct.ToList

                If (From Entity In DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList
                    Where SelectedMarketLengths.Contains(Entity.MarketCode & "|" & Entity.SpotLength.Value) = False
                    Select Entity).Count > 0 Then

                    ButtonItemActions_Copy.Enabled = True

                Else

                    ButtonItemActions_Copy.Enabled = False

                End If

            ElseIf _ViewModel.HasSpotLengths = False AndAlso (From Entity In DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
                                                              Select Entity.MarketCode).Distinct.Count = 1 Then

                SelectedMarketLengths = (From Entity In DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
                                         Select Entity.MarketCode).Distinct.ToList

                If (From Entity In DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList
                    Where SelectedMarketLengths.Contains(Entity.MarketCode) = False
                    Select Entity).Count > 0 Then

                    ButtonItemActions_Copy.Enabled = True

                Else

                    ButtonItemActions_Copy.Enabled = False

                End If

            Else

                ButtonItemActions_Copy.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanEstimateGRPBudgetDialog As AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetDialog = Nothing

            MediaPlanEstimateGRPBudgetDialog = New AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetDialog(MediaPlan)

            ShowFormDialog = MediaPlanEstimateGRPBudgetDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEstimateGRPBudgetDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Apply.Image = AdvantageFramework.My.Resources.ApproveImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemBudget_Allocate.Image = AdvantageFramework.My.Resources.ProcessImage

            DataGridViewForm_GRPBudget.DataSource = New Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)

            _Controller = New AdvantageFramework.Controller.Media.MediaPlanningController(Me.Session)

        End Sub
        Private Sub MediaPlanEstimateGRPBudgetDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.ShowWaitForm("Loading...")

            LoadViewModel()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaPlanEstimateGRPBudgetDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.None
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadViewModel()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If Save() Then

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Apply_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Apply.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            Dim SelectedMediaPlanDetailGRPBudget As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget) = Nothing
            Dim Available As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget) = Nothing
            Dim SelectedMarketLengths As IEnumerable(Of String) = Nothing
            Dim CopyToMarketLengths As IEnumerable(Of AdvantageFramework.DTO.Media.MarketSpotLength) = Nothing
            Dim AllMediaPlanDetailGRPBudgets As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget) = Nothing
            Dim UpdateMediaPlanDetailGRPBudget As AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget = Nothing

            DataGridViewForm_GRPBudget.CloseGridEditorAndSaveValueToDataSource()

            SelectedMediaPlanDetailGRPBudget = DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList

            If _ViewModel.HasSpotLengths Then

                SelectedMarketLengths = (From Entity In SelectedMediaPlanDetailGRPBudget
                                         Select Entity.MarketCode & "|" & Entity.SpotLength.Value).Distinct.ToList

                Available = (From Entity In DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList
                             Where SelectedMarketLengths.Contains(Entity.MarketCode & "|" & Entity.SpotLength.Value) = False
                             Select Entity).ToList

            Else

                SelectedMarketLengths = (From Entity In SelectedMediaPlanDetailGRPBudget
                                         Select Entity.MarketCode).Distinct.ToList

                Available = (From Entity In DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList
                             Where SelectedMarketLengths.Contains(Entity.MarketCode) = False
                             Select Entity).ToList

            End If

            If MediaPlanEstimateGRPBudgetCopyDialog.ShowFormDialog(Available, _ViewModel.HasSpotLengths, CopyToMarketLengths) = Windows.Forms.DialogResult.OK Then

                AllMediaPlanDetailGRPBudgets = DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).ToList

                For Each MediaPlanDetailGRPBudget In SelectedMediaPlanDetailGRPBudget

                    For Each CopyToMarketLength In CopyToMarketLengths

                        UpdateMediaPlanDetailGRPBudget = AllMediaPlanDetailGRPBudgets.Where(Function(All) All.MarketCode = CopyToMarketLength.MarketCode AndAlso
                                                                                                          All.SpotLength.GetValueOrDefault(0) = CopyToMarketLength.SpotLength.GetValueOrDefault(0) AndAlso
                                                                                                          All.EntryDate = MediaPlanDetailGRPBudget.EntryDate).SingleOrDefault

                        If UpdateMediaPlanDetailGRPBudget IsNot Nothing Then

                            UpdateMediaPlanDetailGRPBudget.GRPBudget = MediaPlanDetailGRPBudget.GRPBudget

                        End If

                    Next

                Next

                DataGridViewForm_GRPBudget.CurrentView.RefreshData()

                DataGridViewForm_GRPBudget.SetUserEntryChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_GRPBudget_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_GRPBudget.ShowingEditorEvent

            If DataGridViewForm_GRPBudget.CurrentView IsNot Nothing AndAlso DataGridViewForm_GRPBudget.CurrentView.ActiveEditor IsNot Nothing Then

                DataGridViewForm_GRPBudget.CurrentView.ActiveEditor.SelectAll()

            End If

        End Sub
        Private Sub DataGridViewForm_GRPBudget_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_GRPBudget.SelectionChangedEvent

            EnableDisableCopyButton()

        End Sub
        Private Sub ButtonItemBudget_Allocate_Click(sender As Object, e As EventArgs) Handles ButtonItemBudget_Allocate.Click

            'objects
            Dim TotalGRP As Decimal = 0
            Dim MarketDescription As String = Nothing
            Dim MktCode As String = Nothing
            Dim MediaPlanDetailGRPBudgets As Generic.List(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget) = Nothing
            Dim AllocatedAmount As Decimal = 0
            Dim SpotLengths As IEnumerable(Of Short) = Nothing
            Dim PlanEstimateGRPBudgetAllocateSpotLengthPercents As Generic.List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent) = Nothing

            If (From Entity In DataGridViewForm_GRPBudget.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)
                Select Entity.MarketCode).Distinct.Count > 1 Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select only one market.")

            ElseIf DataGridViewForm_GRPBudget.HasASelectedRow Then

                MarketDescription = DirectCast(DataGridViewForm_GRPBudget.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).MarketDescription
                MktCode = DirectCast(DataGridViewForm_GRPBudget.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).MarketCode

                MediaPlanDetailGRPBudgets = DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).Where(Function(B) B.MarketCode = MktCode).ToList

                SpotLengths = MediaPlanDetailGRPBudgets.Where(Function(Entity) Entity.SpotLength.HasValue).Select(Function(Entity) Entity.SpotLength.Value).Distinct.ToList

                PlanEstimateGRPBudgetAllocateSpotLengthPercents = New List(Of AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent)

                For Each SpotLength In SpotLengths

                    PlanEstimateGRPBudgetAllocateSpotLengthPercents.Add(New AdvantageFramework.DTO.Media.PlanEstimateGRPBudgetAllocateSpotLengthPercent(SpotLength, If(SpotLengths.Count = 1, 100, 0)))

                Next

                If AdvantageFramework.Media.Presentation.MediaPlanEstimateGRPBudgetAllocateDialog.ShowFormDialog("Enter Total GRP for: " & MarketDescription, TotalGRP, PlanEstimateGRPBudgetAllocateSpotLengthPercents) = Windows.Forms.DialogResult.OK Then

                    MediaPlanDetailGRPBudgets = DataGridViewForm_GRPBudget.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget).Where(Function(B) B.MarketCode = MktCode).ToList

                    If PlanEstimateGRPBudgetAllocateSpotLengthPercents.Count >= 1 Then

                        For Each SpotLengthPercent In PlanEstimateGRPBudgetAllocateSpotLengthPercents

                            SpotLengthPercent.BudgetAmount = FormatNumber(TotalGRP * SpotLengthPercent.Percent / 100, 2)

                        Next

                        If PlanEstimateGRPBudgetAllocateSpotLengthPercents.Sum(Function(B) B.BudgetAmount) <> TotalGRP Then

                            PlanEstimateGRPBudgetAllocateSpotLengthPercents(PlanEstimateGRPBudgetAllocateSpotLengthPercents.Count - 1).BudgetAmount += TotalGRP - PlanEstimateGRPBudgetAllocateSpotLengthPercents.Sum(Function(B) B.BudgetAmount)

                        End If

                        For Each SpotLengthPercent In PlanEstimateGRPBudgetAllocateSpotLengthPercents

                            AllocatedAmount = FormatNumber(SpotLengthPercent.BudgetAmount / MediaPlanDetailGRPBudgets.Where(Function(B) B.SpotLength.GetValueOrDefault(0) = SpotLengthPercent.SpotLength).Count, 2)

                            For Each MediaPlanDetailGRPBudget In MediaPlanDetailGRPBudgets.Where(Function(B) B.SpotLength.GetValueOrDefault(0) = SpotLengthPercent.SpotLength)

                                MediaPlanDetailGRPBudget.GRPBudget = AllocatedAmount

                            Next

                            If MediaPlanDetailGRPBudgets.Where(Function(B) B.SpotLength.GetValueOrDefault(0) = SpotLengthPercent.SpotLength).Select(Function(B) B.GRPBudget).Sum <> SpotLengthPercent.BudgetAmount Then

                                MediaPlanDetailGRPBudgets.Where(Function(B) B.SpotLength.GetValueOrDefault(0) = SpotLengthPercent.SpotLength).Last.GRPBudget += SpotLengthPercent.BudgetAmount - MediaPlanDetailGRPBudgets.Where(Function(B) B.SpotLength.GetValueOrDefault(0) = SpotLengthPercent.SpotLength).Select(Function(B) B.GRPBudget).Sum

                            End If

                        Next

                    Else

                        AllocatedAmount = FormatNumber(TotalGRP / MediaPlanDetailGRPBudgets.Count, 2)

                        For Each MediaPlanDetailGRPBudget In MediaPlanDetailGRPBudgets

                            MediaPlanDetailGRPBudget.GRPBudget = AllocatedAmount

                        Next

                        If FormatNumber(AllocatedAmount * MediaPlanDetailGRPBudgets.Count, 2) <> TotalGRP Then

                            MediaPlanDetailGRPBudgets(MediaPlanDetailGRPBudgets.Count - 1).GRPBudget += FormatNumber((TotalGRP - FormatNumber(AllocatedAmount * MediaPlanDetailGRPBudgets.Count, 2)), 2)

                        End If

                    End If

                    DataGridViewForm_GRPBudget.CurrentView.RefreshData()

                    DataGridViewForm_GRPBudget.SetUserEntryChanged()

                    EnableDisableCopyButton()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_GRPBudget_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_GRPBudget.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridColumnSummaryItem As DevExpress.XtraGrid.GridColumnSummaryItem = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_GRPBudget.CurrentView.OptionsView.ShowFooter = True

                DataGridViewForm_GRPBudget.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewForm_GRPBudget.CurrentView.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewForm_GRPBudget.Columns

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget.Properties.GRPBudget.ToString Then

                        If DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName) IsNot Nothing Then

                            If DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName).SummaryItem.SummaryType <> DevExpress.Data.SummaryItemType.Sum Then

                                DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                                DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName).SummaryItem.DisplayFormat = "{0:n2}"

                            End If

                        End If

                        'If Not DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName).Summary.Where(Function(S) S.SummaryType = DevExpress.Data.SummaryItemType.Custom).Any Then

                        '    GridColumnSummaryItem = DataGridViewForm_GRPBudget.Columns(GridColumn.FieldName).Summary.Add(DevExpress.Data.SummaryItemType.Custom)
                        '    GridColumnSummaryItem.DisplayFormat = "{0:n2}"

                        'End If

                    End If

                Next

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
