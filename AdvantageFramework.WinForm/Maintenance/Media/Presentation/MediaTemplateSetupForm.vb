Namespace Maintenance.Media.Presentation

    Public Class MediaTemplateSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Maintenance.Media.PlanEstimateTemplateViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            Dim Saved As Boolean = True

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Saved = Save()

                Else

                    Me.ClearChanged()

                End If

            End If

            CheckForUnsavedChanges = Saved

        End Function
        Private Sub AddNewRow(DTO As AdvantageFramework.DTO.BaseClass)

            'objects
            Dim ErrorMessage As String = Nothing

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

            If DTO IsNot Nothing AndAlso DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength)) Then

                If _Controller.AddSpotLength(DTO, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

        End Sub
        Private Sub LoadTactics()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadTactics(_ViewModel)

            DataGridViewTactics_Tactics.ClearDatasource()
            DataGridViewTactics_Tactics.DataSource = _ViewModel.Tactics
            DataGridViewTactics_Tactics.CurrentView.BestFitColumns()

            LabelTactics_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewTactics_Tactics.GridViewSelectionChanged()

        End Sub
        Private Sub LoadVendors()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadVendors(_ViewModel)

            DataGridViewVendors_Vendors.ClearDatasource()
            DataGridViewVendors_Vendors.DataSource = _ViewModel.Vendors
            DataGridViewVendors_Vendors.CurrentView.BestFitColumns()

            LabelVendors_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewVendors_Vendors.GridViewSelectionChanged()

        End Sub
        Private Sub LoadMarkets()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadMarkets(_ViewModel)

            DataGridViewMarkets_Markets.ClearDatasource()
            DataGridViewMarkets_Markets.DataSource = _ViewModel.Markets
            DataGridViewMarkets_Markets.CurrentView.BestFitColumns()

            LabelMarkets_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewMarkets_Markets.GridViewSelectionChanged()

        End Sub
        Private Sub LoadDayparts()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadDayparts(_ViewModel)

            DataGridViewDayparts_Dayparts.ClearDatasource()
            DataGridViewDayparts_Dayparts.DataSource = _ViewModel.Dayparts
            DataGridViewDayparts_Dayparts.CurrentView.BestFitColumns()

            LabelDayparts_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewDayparts_Dayparts.GridViewSelectionChanged()

        End Sub
        Private Sub LoadSpotLengths()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadSpotLengths(_ViewModel)

            DataGridViewSpotLengths_SpotLengths.ClearDatasource()
            DataGridViewSpotLengths_SpotLengths.DataSource = _ViewModel.SpotLengths
            DataGridViewSpotLengths_SpotLengths.CurrentView.BestFitColumns()

            LabelSpotLengths_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewSpotLengths_SpotLengths.GridViewSelectionChanged()

        End Sub
        Private Sub LoadDemographics()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadDemographics(_ViewModel)

            DataGridViewDemographics_Demographics.ClearDatasource()
            DataGridViewDemographics_Demographics.DataSource = _ViewModel.Demographics
            DataGridViewDemographics_Demographics.CurrentView.BestFitColumns()

            LabelDemographics_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewDemographics_Demographics.GridViewSelectionChanged()

        End Sub
        Private Sub LoadQuarters()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadQuarters(_ViewModel)

            DataGridViewQuarters_Quarters.ClearDatasource()
            DataGridViewQuarters_Quarters.DataSource = _ViewModel.Quarters
            DataGridViewQuarters_Quarters.CurrentView.BestFitColumns()

            LabelQuarters_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewQuarters_Quarters.GridViewSelectionChanged()

        End Sub
        Private Sub LoadOutOfHomeTypes()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadOutOfHomeTypes(_ViewModel)

            DataGridViewOutOfHomeTypes_OutOfHomeTypes.ClearDatasource()
            DataGridViewOutOfHomeTypes_OutOfHomeTypes.DataSource = _ViewModel.OutdoorTypes
            DataGridViewOutOfHomeTypes_OutOfHomeTypes.CurrentView.BestFitColumns()

            LabelOutOfHomeTypes_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewOutOfHomeTypes_OutOfHomeTypes.GridViewSelectionChanged()

        End Sub
        Private Sub LoadAdSizes()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadAdSizes(_ViewModel)

            DataGridViewAdSizes_AdSizes.ClearDatasource()
            DataGridViewAdSizes_AdSizes.DataSource = _ViewModel.AdSizes
            DataGridViewAdSizes_AdSizes.CurrentView.BestFitColumns()

            LabelAdSizes_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewAdSizes_AdSizes.GridViewSelectionChanged()

        End Sub
        Private Sub LoadRateTypes()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _Controller.LoadRateTypes(_ViewModel)

            DataGridViewRateTypes_RateTypes.ClearDatasource()
            DataGridViewRateTypes_RateTypes.DataSource = _ViewModel.RateTypes
            DataGridViewRateTypes_RateTypes.CurrentView.BestFitColumns()

            LabelRateTypes_TemplateName.Text = If(_ViewModel.SelectedPlanEstimateTemplate IsNot Nothing, _ViewModel.SelectedPlanEstimateTemplate.Description, "")

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            DataGridViewRateTypes_RateTypes.GridViewSelectionChanged()

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) Then

                    DataGridViewTemplates_Templates.DataSource = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)
                    DataGridViewTemplates_Templates.DataSource = _ViewModel.PlanEstimateTemplates
                    DataGridViewTemplates_Templates.GridViewSelectionChanged()
                    DataGridViewTemplates_Templates.ValidateAllRows()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Tactics) Then

                    DataGridViewTactics_Tactics.CurrentView.RefreshData()
                    DataGridViewTactics_Tactics.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Vendors) Then

                    DataGridViewVendors_Vendors.CurrentView.RefreshData()
                    DataGridViewVendors_Vendors.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Markets) Then

                    DataGridViewMarkets_Markets.CurrentView.RefreshData()
                    DataGridViewMarkets_Markets.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Dayparts) Then

                    DataGridViewDayparts_Dayparts.CurrentView.RefreshData()
                    DataGridViewDayparts_Dayparts.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) Then

                    DataGridViewSpotLengths_SpotLengths.CurrentView.RefreshData()
                    DataGridViewSpotLengths_SpotLengths.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Demographics) Then

                    DataGridViewDemographics_Demographics.CurrentView.RefreshData()
                    DataGridViewDemographics_Demographics.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Quarters) Then

                    DataGridViewQuarters_Quarters.CurrentView.RefreshData()
                    DataGridViewQuarters_Quarters.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_OutOfHomeTypes) Then

                    DataGridViewOutOfHomeTypes_OutOfHomeTypes.CurrentView.RefreshData()
                    DataGridViewOutOfHomeTypes_OutOfHomeTypes.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_AdSizes) Then

                    DataGridViewAdSizes_AdSizes.CurrentView.RefreshData()
                    DataGridViewAdSizes_AdSizes.GridViewSelectionChanged()

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_RateTypes) Then

                    DataGridViewRateTypes_RateTypes.CurrentView.RefreshData()
                    DataGridViewRateTypes_RateTypes.GridViewSelectionChanged()

                End If

            End If

            RibbonBarOptions_EstimateTemplates.Visible = TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates)

            ButtonItemEstimateTemplates_EnterPercent.Enabled = _ViewModel.PercentEntryEnabled
            ButtonItemEstimateTemplates_EnterRates.Enabled = _ViewModel.RateEntryEnabled

            ButtonItemActions_Save.Enabled = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) AndAlso DataGridViewTemplates_Templates.UserEntryChanged) OrElse
                (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) AndAlso DataGridViewSpotLengths_SpotLengths.UserEntryChanged)

            ButtonItemActions_Cancel.Enabled = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) AndAlso DataGridViewTemplates_Templates.CurrentView.IsNewItemRow(DataGridViewTemplates_Templates.CurrentView.FocusedRowHandle)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) AndAlso DataGridViewSpotLengths_SpotLengths.CurrentView.IsNewItemRow(DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedRowHandle))

            ButtonItemActions_Delete.Enabled = (ButtonItemActions_Save.Enabled = False) AndAlso (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) AndAlso _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsSystem = False) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) AndAlso DataGridViewSpotLengths_SpotLengths.HasASelectedRow AndAlso _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsSystem = False)

            ButtonItemActions_Copy.Enabled = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) AndAlso
                DataGridViewTemplates_Templates.UserEntryChanged = False AndAlso _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing AndAlso
                (_ViewModel.SelectedPlanEstimateTemplate.IsSystem = False OrElse (_ViewModel.SelectedPlanEstimateTemplate.IsSystem AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsMissingMappings = False)))

            If _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing Then

                TabItemTabs_Vendors.Visible = (_ViewModel.SelectedPlanEstimateTemplate.IsSystem = False AndAlso {"I", "M", "N", "O"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type))
                TabItemTabs_Tactics.Visible = (_ViewModel.SelectedPlanEstimateTemplate.Type = "I" AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsSystem = False)
                TabItemTabs_Markets.Visible = {"R", "T"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)
                TabItemTabs_Dayparts.Visible = {"R", "T"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)
                TabItemTabs_SpotLengths.Visible = {"R", "T"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)
                TabItemTabs_Demographics.Visible = {"R", "T"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)
                TabItemTabs_Quarters.Visible = (_ViewModel.SelectedPlanEstimateTemplate.Type <> "I")
                TabItemTabs_OutOfHomeTypes.Visible = (_ViewModel.SelectedPlanEstimateTemplate.Type = "O")
                TabItemTabs_AdSizes.Visible = {"M", "N"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)
                TabItemTabs_RateTypes.Visible = {"N"}.Contains(_ViewModel.SelectedPlanEstimateTemplate.Type)

            Else

                TabItemTabs_Vendors.Visible = False
                TabItemTabs_Tactics.Visible = False
                TabItemTabs_Markets.Visible = False
                TabItemTabs_Dayparts.Visible = False
                TabItemTabs_SpotLengths.Visible = False
                TabItemTabs_Demographics.Visible = False
                TabItemTabs_Quarters.Visible = False
                TabItemTabs_OutOfHomeTypes.Visible = False
                TabItemTabs_AdSizes.Visible = False
                TabItemTabs_RateTypes.Visible = False

            End If

        End Sub
        Private Function Save() As Boolean

            'objects
            Dim FocusedRowHandle As Integer = 0
            Dim Saved As Boolean = False

            SaveViewModel()

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) Then

                If _ViewModel.PlanEstimateTemplates.Any(Function(Entity) Entity.HasError) = False Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.Saving

                    _Controller.SaveTemplateTypes(_ViewModel)

                    DataGridViewTemplates_Templates.ClearChanged()

                    RefreshViewModel(True)

                    Saved = True

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid.")

                End If

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) Then

                If _ViewModel.SpotLengths.Any(Function(Entity) Entity.HasError) = False Then

                    _Controller.SaveSpotLengths(_ViewModel)

                    DataGridViewSpotLengths_SpotLengths.ClearChanged()

                    RefreshViewModel(True)

                    Saved = True

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid.")

                End If

            End If

            Save = Saved

        End Function
        Private Sub SaveViewModel()

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) Then

                DataGridViewTemplates_Templates.CurrentView.CloseEditorForUpdating()

                DataGridViewTemplates_Templates.ValidateAllRows()

                _ViewModel.PlanEstimateTemplates = DataGridViewTemplates_Templates.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate).ToList

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Dayparts) Then

                DataGridViewDayparts_Dayparts.CurrentView.CloseEditorForUpdating()

                DataGridViewDayparts_Dayparts.ValidateAllRows()

                _ViewModel.Dayparts = DataGridViewDayparts_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart).ToList

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) Then

                DataGridViewSpotLengths_SpotLengths.CurrentView.CloseEditorForUpdating()

                DataGridViewSpotLengths_SpotLengths.ValidateAllRows()

                _ViewModel.SpotLengths = DataGridViewSpotLengths_SpotLengths.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength).ToList

            End If

        End Sub
        Private Function OkayToDelete(Checked As Boolean) As Boolean

            Dim Okay As Boolean = True

            If Checked = False AndAlso _ViewModel.HasPercentsDefined Then

                If AdvantageFramework.WinForm.MessageBox.Show("Percentages will be deleted.  Okay to proceed?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = WinForm.MessageBox.DialogResults.No Then

                    Okay = False

                Else

                    _ViewModel.HasPercentsDefined = False

                End If

            End If

            OkayToDelete = Okay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaTemplateSetupForm As Maintenance.Media.Presentation.MediaTemplateSetupForm = Nothing

            MediaTemplateSetupForm = New Maintenance.Media.Presentation.MediaTemplateSetupForm()

            MediaTemplateSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaTemplateSetupForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            DataGridViewTemplates_Templates.OptionsNavigation.AutoFocusNewRow = True

            DataGridViewVendors_Vendors.ByPassUserEntryChanged = True
            DataGridViewTactics_Tactics.ByPassUserEntryChanged = True
            DataGridViewMarkets_Markets.ByPassUserEntryChanged = True
            DataGridViewDemographics_Demographics.ByPassUserEntryChanged = True
            DataGridViewOutOfHomeTypes_OutOfHomeTypes.ByPassUserEntryChanged = True
            DataGridViewAdSizes_AdSizes.ByPassUserEntryChanged = True
            DataGridViewRateTypes_RateTypes.ByPassUserEntryChanged = True
            DataGridViewQuarters_Quarters.ByPassUserEntryChanged = True
            DataGridViewDayparts_Dayparts.ByPassUserEntryChanged = True

            DataGridViewVendors_Vendors.ShowSelectDeselectAllButtons = True
            DataGridViewTactics_Tactics.ShowSelectDeselectAllButtons = True
            DataGridViewMarkets_Markets.ShowSelectDeselectAllButtons = True
            DataGridViewDemographics_Demographics.ShowSelectDeselectAllButtons = True
            DataGridViewOutOfHomeTypes_OutOfHomeTypes.ShowSelectDeselectAllButtons = True
            DataGridViewAdSizes_AdSizes.ShowSelectDeselectAllButtons = True
            DataGridViewRateTypes_RateTypes.ShowSelectDeselectAllButtons = True
            DataGridViewQuarters_Quarters.ShowSelectDeselectAllButtons = True
            DataGridViewDayparts_Dayparts.ShowSelectDeselectAllButtons = True

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage

            ButtonItemEstimateTemplates_EnterRates.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemEstimateTemplates_EnterPercent.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemEstimateTemplates_Clients.Image = AdvantageFramework.My.Resources.ClientImage

            ButtonItemPlanTemplates_Clients.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemPlanTemplates_Manage.Image = AdvantageFramework.My.Resources.TemplateImage

            _Controller = New AdvantageFramework.Controller.Maintenance.Media.MediaPlanEstimateTemplateController(Me.Session)

            _ViewModel = _Controller.Load()

        End Sub
        Private Sub MediaTemplateSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            DataGridViewTemplates_Templates.DataSource = _ViewModel.PlanEstimateTemplates
            DataGridViewTemplates_Templates.CurrentView.AFActiveFilterString = "[IsInactive] = False"
            DataGridViewTemplates_Templates.CurrentView.BestFitColumns()
            DataGridViewTemplates_Templates.ValidateAllRows()

            If DataGridViewTemplates_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString) IsNot Nothing Then

                DataGridViewTemplates_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString).MinWidth = 85

            End If

            If DataGridViewTemplates_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Goals.ToString) IsNot Nothing Then

                DataGridViewTemplates_Templates.CurrentView.Columns(AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Goals.ToString).Width = 750

            End If

            DataGridViewTactics_Tactics.DataSource = _ViewModel.Tactics
            DataGridViewVendors_Vendors.DataSource = _ViewModel.Vendors
            DataGridViewMarkets_Markets.DataSource = _ViewModel.Markets
            DataGridViewDayparts_Dayparts.DataSource = _ViewModel.Dayparts
            DataGridViewSpotLengths_SpotLengths.DataSource = _ViewModel.SpotLengths
            DataGridViewDemographics_Demographics.DataSource = _ViewModel.Demographics
            DataGridViewQuarters_Quarters.DataSource = _ViewModel.Quarters
            DataGridViewOutOfHomeTypes_OutOfHomeTypes.DataSource = _ViewModel.OutdoorTypes
            DataGridViewAdSizes_AdSizes.DataSource = _ViewModel.AdSizes

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            RefreshViewModel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) Then

                DataGridViewTemplates_Templates.CancelNewItemRow()

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) Then

                DataGridViewSpotLengths_SpotLengths.CancelNewItemRow()

            End If

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing
            Dim ErrorMessage As String = Nothing

            If _Controller.CopyMediaPlanEstimateTemplate(_ViewModel, ErrorMessage) Then

                DataGridViewTemplates_Templates.DataSource = _ViewModel.PlanEstimateTemplates
                DataGridViewTemplates_Templates.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                DataGridViewTemplates_Templates.CurrentView.BestFitColumns()
                DataGridViewTemplates_Templates.ValidateAllRows()

                RefreshViewModel(True)

            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_Templates) Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete the selected template?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = WinForm.MessageBox.DialogResults.Yes Then

                    PlanEstimateTemplate = DataGridViewTemplates_Templates.GetFirstSelectedRowDataBoundItem

                    If _Controller.DeleteSelectedPlanEstimateTemplate(_ViewModel) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Selected Template is in use and cannot be deleted.")

                    Else

                        DataGridViewTemplates_Templates.CurrentView.DeleteFromDataSource(PlanEstimateTemplate)

                    End If

                End If

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotLengths) Then

                _Controller.DeleteSelectedSpotLengths(DataGridViewSpotLengths_SpotLengths.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength).ToList, _ViewModel)

            End If

            RefreshViewModel(True)

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemEstimateTemplates_Clients_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateTemplates_Clients.Click

            AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateProductDialog.ShowFormDialog(ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Estimate)

        End Sub
        Private Sub ButtonItemEstimateTemplates_EnterPercent_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateTemplates_EnterPercent.Click

            If _ViewModel.SelectedPlanEstimateTemplate.IsMissingMappings Then

                If AdvantageFramework.WinForm.MessageBox.Show("Would you like to map missing vendor/tactics now?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Missing System Template Mappings") = WinForm.MessageBox.DialogResults.Yes Then

                    AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateMappingDialog.ShowFormDialog()

                    _Controller.RefreshIsMissingMappings(_ViewModel)

                End If

            Else

                AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateDataEntryDialog.ShowFormDialog(_ViewModel.SelectedPlanEstimateTemplate.ID, False, True)

                _Controller.SetHasDatasFlag(_ViewModel)

            End If

        End Sub
        Private Sub ButtonItemEstimateTemplates_EnterRates_Click(sender As Object, e As EventArgs) Handles ButtonItemEstimateTemplates_EnterRates.Click

            If _ViewModel.SelectedPlanEstimateTemplate.Type = "I" Then

                AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateDataEntryDialog.ShowFormDialog(_ViewModel.SelectedPlanEstimateTemplate.ID, True, False)

            Else

                AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateDataEntryDialog.ShowFormDialog(_ViewModel.SelectedPlanEstimateTemplate.ID, False, False)

            End If

            _Controller.SetHasDatasFlag(_ViewModel)

        End Sub
        Private Sub ButtonItemPlanTemplates_Clients_Click(sender As Object, e As EventArgs) Handles ButtonItemPlanTemplates_Clients.Click

            AdvantageFramework.Maintenance.Media.Presentation.MediaTemplateProductDialog.ShowFormDialog(ViewModels.Maintenance.Media.ProductTemplateViewModel.TemplateLevel.Plan)

        End Sub
        Private Sub ButtonItemPlanTemplates_Manage_Click(sender As Object, e As EventArgs) Handles ButtonItemPlanTemplates_Manage.Click

            AdvantageFramework.Maintenance.Media.Presentation.MediaPlanTemplateSetupDialog.ShowFormDialog()

        End Sub
        Private Sub DataGridViewAdSizes_AdSizes_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewAdSizes_AdSizes.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize.Properties.Selected.ToString Then

                _Controller.SaveSelectedAdSize(e.Value, DirectCast(DataGridViewAdSizes_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize), _ViewModel)

            End If

        End Sub
        Private Sub DataGridViewAdSizes_AdSizes_DeselectAllEvent() Handles DataGridViewAdSizes_AdSizes.DeselectAllEvent

            _Controller.SaveAllAdSizes(False, DataGridViewAdSizes_AdSizes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize).ToList, _ViewModel)

            LoadAdSizes()

        End Sub
        Private Sub DataGridViewAdSizes_AdSizes_SelectAllEvent() Handles DataGridViewAdSizes_AdSizes.SelectAllEvent

            _Controller.SaveAllAdSizes(True, DataGridViewAdSizes_AdSizes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.AdSize).ToList, _ViewModel)

            LoadAdSizes()

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDayparts_Dayparts.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart.Properties.Selected.ToString Then

                If OkayToDelete(e.Value) Then

                    _Controller.SaveSelectedDaypart(e.Value, DirectCast(DataGridViewDayparts_Dayparts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart), _ViewModel)

                Else

                    DataGridViewDayparts_Dayparts.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_DeselectAllEvent() Handles DataGridViewDayparts_Dayparts.DeselectAllEvent

            _Controller.SaveAllDayparts(False, DataGridViewDayparts_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart).ToList, _ViewModel)

            LoadDayparts()

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_SelectAllEvent() Handles DataGridViewDayparts_Dayparts.SelectAllEvent

            _Controller.SaveAllDayparts(True, DataGridViewDayparts_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart).ToList, _ViewModel)

            LoadDayparts()

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewDayparts_Dayparts.ShowingEditorEvent

            If DataGridViewDayparts_Dayparts.CurrentView.FocusedRowHandle >= 0 AndAlso DataGridViewDayparts_Dayparts.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart.Properties.DaypartID.ToString Then

                e.Cancel = True

            ElseIf DataGridViewDayparts_Dayparts.CurrentView.IsNewItemOrAutoFilterRow(DataGridViewDayparts_Dayparts.CurrentView.FocusedRowHandle) AndAlso _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsSystem Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewDayparts_Dayparts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewDayparts_Dayparts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewDayparts_Dayparts.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        RefreshViewModel(True)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewDayparts_Dayparts.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Daypart = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewDayparts_Dayparts.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewDayparts_Dayparts.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewDayparts_Dayparts.CurrentView.SetColumnError(DataGridViewDayparts_Dayparts.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewDemographics_Demographics_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewDemographics_Demographics.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor.Properties.Selected.ToString Then

                _Controller.SaveSelectedDemographic(e.Value, DirectCast(DataGridViewDemographics_Demographics.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic), _ViewModel)

            End If

        End Sub
        Private Sub DataGridViewDemographics_Demographics_DeselectAllEvent() Handles DataGridViewDemographics_Demographics.DeselectAllEvent

            _Controller.SaveAllDemographics(False, DataGridViewDemographics_Demographics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic).ToList, _ViewModel)

            LoadDemographics()

        End Sub
        Private Sub DataGridViewDemographics_Demographics_SelectAllEvent() Handles DataGridViewDemographics_Demographics.SelectAllEvent

            _Controller.SaveAllDemographics(True, DataGridViewDemographics_Demographics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Demographic).ToList, _ViewModel)

            LoadDemographics()

        End Sub
        Private Sub DataGridViewMarkets_Markets_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewMarkets_Markets.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market.Properties.Selected.ToString Then

                If OkayToDelete(e.Value) Then

                    _Controller.SaveSelectedMarket(e.Value, DirectCast(DataGridViewMarkets_Markets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market), _ViewModel)

                Else

                    DataGridViewMarkets_Markets.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewMarkets_Markets_DeselectAllEvent() Handles DataGridViewMarkets_Markets.DeselectAllEvent

            _Controller.SaveAllMarkets(False, DataGridViewMarkets_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market).ToList, _ViewModel)

            LoadMarkets()

        End Sub
        Private Sub DataGridViewMarkets_Markets_SelectAllEvent() Handles DataGridViewMarkets_Markets.SelectAllEvent

            _Controller.SaveAllMarkets(True, DataGridViewMarkets_Markets.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Market).ToList, _ViewModel)

            LoadMarkets()

        End Sub
        Private Sub DataGridViewOutOfHomeTypes_OutOfHomeTypes_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOutOfHomeTypes_OutOfHomeTypes.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType.Properties.Selected.ToString Then

                _Controller.SaveSelectedOutdoorType(e.Value, DirectCast(DataGridViewOutOfHomeTypes_OutOfHomeTypes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType), _ViewModel)

            End If

        End Sub
        Private Sub DataGridViewOutOfHomeTypes_OutOfHomeTypes_DeselectAllEvent() Handles DataGridViewOutOfHomeTypes_OutOfHomeTypes.DeselectAllEvent

            _Controller.SaveAllOutdoorTypes(False, DataGridViewOutOfHomeTypes_OutOfHomeTypes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType).ToList, _ViewModel)

            LoadOutOfHomeTypes()

        End Sub
        Private Sub DataGridViewOutOfHomeTypes_OutOfHomeTypes_SelectAllEvent() Handles DataGridViewOutOfHomeTypes_OutOfHomeTypes.SelectAllEvent

            _Controller.SaveAllOutdoorTypes(True, DataGridViewOutOfHomeTypes_OutOfHomeTypes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.OutdoorType).ToList, _ViewModel)

            LoadOutOfHomeTypes()

        End Sub
        Private Sub DataGridViewQuarters_Quarters_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewQuarters_Quarters.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter.Properties.Selected.ToString Then

                _Controller.SaveSelectedQuarter(e.Value, DirectCast(DataGridViewQuarters_Quarters.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter), _ViewModel)

            End If

        End Sub
        Private Sub DataGridViewQuarters_Quarters_DeselectAllEvent() Handles DataGridViewQuarters_Quarters.DeselectAllEvent

            _Controller.SaveAllQuarters(False, DataGridViewQuarters_Quarters.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter).ToList, _ViewModel)

            LoadQuarters()

        End Sub
        Private Sub DataGridViewQuarters_Quarters_SelectAllEvent() Handles DataGridViewQuarters_Quarters.SelectAllEvent

            _Controller.SaveAllQuarters(True, DataGridViewQuarters_Quarters.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Quarter).ToList, _ViewModel)

            LoadQuarters()

        End Sub
        Private Sub DataGridViewRateTypes_RateTypes_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRateTypes_RateTypes.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType.Properties.Selected.ToString Then

                _Controller.SaveSelectedRateType(e.Value, DirectCast(DataGridViewRateTypes_RateTypes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType), _ViewModel)

            End If

        End Sub
        Private Sub DataGridViewRateTypes_RateTypes_DeselectAllEvent() Handles DataGridViewRateTypes_RateTypes.DeselectAllEvent

            _Controller.SaveAllRateTypes(False, DataGridViewRateTypes_RateTypes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType).ToList, _ViewModel)

            LoadRateTypes()

        End Sub
        Private Sub DataGridViewRateTypes_RateTypes_SelectAllEvent() Handles DataGridViewRateTypes_RateTypes.SelectAllEvent

            _Controller.SaveAllRateTypes(True, DataGridViewRateTypes_RateTypes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.RateType).ToList, _ViewModel)

            LoadRateTypes()

        End Sub
        Private Sub DataGridViewSpotLengths_SpotLengths_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotLengths_SpotLengths.InitNewRowEvent

            Dim SpotLength As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength = Nothing

            SpotLength = DirectCast(DataGridViewSpotLengths_SpotLengths.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength)

            SpotLength.MediaPlanEstimateTemplateID = _ViewModel.SelectedPlanEstimateTemplate.ID

        End Sub
        Private Sub DataGridViewSpotLengths_SpotLengths_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotLengths_SpotLengths.SelectionChangedEvent

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewSpotLengths_SpotLengths_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSpotLengths_SpotLengths.ShowingEditorEvent

            If DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedRowHandle >= 0 AndAlso DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength.Properties.SpotLength.ToString Then

                e.Cancel = True

            ElseIf DataGridViewSpotLengths_SpotLengths.CurrentView.IsNewItemOrAutoFilterRow(DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedRowHandle) AndAlso _ViewModel.SelectedPlanEstimateTemplate IsNot Nothing AndAlso _ViewModel.SelectedPlanEstimateTemplate.IsSystem Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSpotLengths_SpotLengths_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotLengths_SpotLengths.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewSpotLengths_SpotLengths.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewSpotLengths_SpotLengths.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotLengths_SpotLengths_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSpotLengths_SpotLengths.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.SpotLength = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewSpotLengths_SpotLengths.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewSpotLengths_SpotLengths.CurrentView.SetColumnError(DataGridViewSpotLengths_SpotLengths.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewTactics_Tactics_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTactics_Tactics.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor.Properties.Selected.ToString Then

                If OkayToDelete(e.Value) Then

                    _Controller.SaveSelectedTactic(e.Value, DirectCast(DataGridViewTactics_Tactics.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic), _ViewModel)

                Else

                    DataGridViewTactics_Tactics.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewTactics_Tactics_DeselectAllEvent() Handles DataGridViewTactics_Tactics.DeselectAllEvent

            _Controller.SaveAllTactics(False, DataGridViewTactics_Tactics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic).ToList, _ViewModel)

            LoadTactics()

        End Sub
        Private Sub DataGridViewTactics_Tactics_SelectAllEvent() Handles DataGridViewTactics_Tactics.SelectAllEvent

            _Controller.SaveAllTactics(True, DataGridViewTactics_Tactics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Tactic).ToList, _ViewModel)

            LoadTactics()

        End Sub
        Private Sub DataGridViewTemplates_Templates_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewTemplates_Templates.CellValueChangingEvent

            If e.RowHandle >= 0 Then

                DataGridViewTemplates_Templates.SetUserEntryChanged()

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewTemplates_Templates_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewTemplates_Templates.FocusedRowChangedEvent

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If e.FocusedRowHandle < 0 Then

                    _ViewModel.SelectedPlanEstimateTemplate = Nothing

                Else

                    _ViewModel.SelectedPlanEstimateTemplate = DataGridViewTemplates_Templates.GetRowDataBoundItem(e.FocusedRowHandle)

                End If

                _Controller.SetDataEntryFlag(_ViewModel)
                _Controller.SetHasDatasFlag(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub DataGridViewTemplates_Templates_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewTemplates_Templates.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString Then

                Datasource = _ViewModel.RepositoryMediaTypes

            End If

        End Sub
        Private Sub DataGridViewTemplates_Templates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewTemplates_Templates.ShowingEditorEvent

            'objects
            Dim PlanEstimateTemplate As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing

            If DataGridViewTemplates_Templates.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.IsSystem.ToString Then

                e.Cancel = True

            ElseIf DataGridViewTemplates_Templates.CurrentView.FocusedRowHandle >= 0 Then

                PlanEstimateTemplate = DirectCast(DataGridViewTemplates_Templates.CurrentView.GetRow(DataGridViewTemplates_Templates.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate)

                If DataGridViewTemplates_Templates.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate.Properties.Type.ToString Then

                    e.Cancel = True

                Else

                    If PlanEstimateTemplate.IsSystem Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewTemplates_Templates_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewTemplates_Templates.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewTemplates_Templates.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewTemplates_Templates.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        _Controller.AddPlanEstimateTemplate(_ViewModel, e.Row)

                        RefreshViewModel(False)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewTemplates_Templates_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewTemplates_Templates.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.PlanEstimateTemplate = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewTemplates_Templates.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewTemplates_Templates.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewTemplates_Templates.CurrentView.SetColumnError(DataGridViewTemplates_Templates.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewVendors_Vendors.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor.Properties.Selected.ToString Then

                If OkayToDelete(e.Value) Then

                    _Controller.SaveSelectedVendor(e.Value, DirectCast(DataGridViewVendors_Vendors.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor), _ViewModel)

                Else

                    DataGridViewVendors_Vendors.CurrentView.CloseEditor()

                End If

            End If

        End Sub
        Private Sub DataGridViewVendors_Vendors_DeselectAllEvent() Handles DataGridViewVendors_Vendors.DeselectAllEvent

            _Controller.SaveAllVendors(False, DataGridViewVendors_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor).ToList, _ViewModel)

            LoadVendors()

        End Sub
        Private Sub DataGridViewVendors_Vendors_SelectAllEvent() Handles DataGridViewVendors_Vendors.SelectAllEvent

            _Controller.SaveAllVendors(True, DataGridViewVendors_Vendors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.Media.PlanEstimateTemplate.Vendor).ToList, _ViewModel)

            LoadVendors()

        End Sub
        Private Sub TabControlForm_Tabs_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_Tabs.SelectedTabChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If e.NewTab.Equals(TabItemTabs_Templates) Then

                    _Controller.SetDataEntryFlag(_ViewModel)

                ElseIf e.NewTab.Equals(TabItemTabs_Tactics) Then

                    LoadTactics()

                ElseIf e.NewTab.Equals(TabItemTabs_Vendors) Then

                    LoadVendors()

                ElseIf e.NewTab.Equals(TabItemTabs_Markets) Then

                    LoadMarkets()

                ElseIf e.NewTab.Equals(TabItemTabs_Dayparts) Then

                    LoadDayparts()

                ElseIf e.NewTab.Equals(TabItemTabs_SpotLengths) Then

                    LoadSpotLengths()

                ElseIf e.NewTab.Equals(TabItemTabs_Demographics) Then

                    LoadDemographics()

                ElseIf e.NewTab.Equals(TabItemTabs_Quarters) Then

                    LoadQuarters()

                ElseIf e.NewTab.Equals(TabItemTabs_OutOfHomeTypes) Then

                    LoadOutOfHomeTypes()

                ElseIf e.NewTab.Equals(TabItemTabs_AdSizes) Then

                    LoadAdSizes()

                ElseIf e.NewTab.Equals(TabItemTabs_RateTypes) Then

                    LoadRateTypes()

                End If

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub TabControlForm_Tabs_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Tabs.SelectedTabChanging

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                DataGridViewTemplates_Templates.CurrentView.CloseEditorForUpdating()
                DataGridViewTactics_Tactics.CurrentView.CloseEditorForUpdating()
                DataGridViewVendors_Vendors.CurrentView.CloseEditorForUpdating()
                DataGridViewMarkets_Markets.CurrentView.CloseEditorForUpdating()
                DataGridViewDayparts_Dayparts.CurrentView.CloseEditorForUpdating()
                DataGridViewSpotLengths_SpotLengths.CurrentView.CloseEditorForUpdating()
                DataGridViewDemographics_Demographics.CurrentView.CloseEditorForUpdating()
                DataGridViewQuarters_Quarters.CurrentView.CloseEditorForUpdating()
                DataGridViewOutOfHomeTypes_OutOfHomeTypes.CurrentView.CloseEditorForUpdating()
                DataGridViewAdSizes_AdSizes.CurrentView.CloseEditorForUpdating()
                DataGridViewRateTypes_RateTypes.CurrentView.CloseEditorForUpdating()

                e.Cancel = Not CheckForUnsavedChanges()

                If e.Cancel = False Then

                    If e.NewTab.Equals(TabItemTabs_Tactics) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_Vendors) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_Markets) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_Dayparts) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_SpotLengths) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_Demographics) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_Quarters) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_OutOfHomeTypes) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_AdSizes) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    ElseIf e.NewTab.Equals(TabItemTabs_RateTypes) Then

                        If _ViewModel.SelectedPlanEstimateTemplate Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please select a template first.")
                            e.Cancel = True

                        End If

                    End If

                    RefreshViewModel(False)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
