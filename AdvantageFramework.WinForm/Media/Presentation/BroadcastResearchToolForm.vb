Namespace Media.Presentation

    Public Class BroadcastResearchToolForm

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum CumeType
            CUME
            ECUME
        End Enum

#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.BroadcastResearchController = Nothing
        Protected _NielsenCopyright As String = "Copyright © " & Now.Year.ToString & " The Nielsen Company"
        Protected _ComscoreCopyright As String = "Copyright © " & Now.Year.ToString & " Comscore"
        Protected _NielsenPuertoRicoCopyright As String = "Copyright © " & Now.Year.ToString & " Nielsen Media, Puerto Rico"
        Private _MissingIntegrationSettingsMessageShown As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub AddCriteria()

            'objects
            Dim ResearchID As Nullable(Of Integer) = Nothing
            Dim ErrorMessage As String = ""

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV AndAlso AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTV, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTV, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadSpotTVViewModel(ResearchID, True)

                TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio AndAlso AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadio, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadio, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadSpotRadioViewModel(ResearchID, True)

                TabControlSpotRadio_ResearchCriteria.SelectedTab = TabItemSpotRadio_MarketBooks

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty AndAlso AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadioCounty, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadioCounty, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadSpotRadioCountyViewModel(ResearchID, True)

                TabControlSpotRadioCounty_ResearchCriteria.SelectedTab = TabItemSpotRadioCounty_MarketBooks

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National AndAlso AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotNational, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotNational, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadNationalViewModel(ResearchID, True)

                TabControlNational_ResearchCriteria.SelectedTab = TabItemNational_ReportType

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico AndAlso AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTVPuertoRico, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTVPuertoRico, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadSpotTVPuertoRicoViewModel(ResearchID, True)

                TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab = TabItemSpotTVPuertoRico_ReportTypeStations

            End If

        End Sub
        Private Sub EditCriteria()

            'objects
            Dim ResearchID As Nullable(Of Integer) = Nothing
            Dim ErrorMessage As String = ""

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                ResearchID = _ViewModel.SpotTVSelectedResearchCriteria.ID

                If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTV, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTV, _ViewModel.SpotTVSelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                    LoadSpotTVViewModel(ResearchID, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                ResearchID = _ViewModel.SelectedResearchCriteria.ID

                If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadio, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadio, _ViewModel.SelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                    LoadSpotRadioViewModel(ResearchID, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                ResearchID = _ViewModel.SpotRadioCountySelectedResearchCriteria.ID

                If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadioCounty, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadioCounty, _ViewModel.SpotRadioCountySelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                    LoadSpotRadioCountyViewModel(ResearchID, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                ResearchID = _ViewModel.NationalSelectedResearchCriteria.ID

                If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotNational, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotNational, _ViewModel.NationalSelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                    LoadNationalViewModel(ResearchID, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                ResearchID = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID

                If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTVPuertoRico, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTVPuertoRico, _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                    LoadSpotTVPuertoRicoViewModel(ResearchID, True)

                End If

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV AndAlso _ViewModel.SpotTVSaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = SaveSpotTV()

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio AndAlso _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = SaveSpotRadio()

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty AndAlso _ViewModel.SpotRadioCountySaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = SaveSpotRadioCounty()

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National AndAlso _ViewModel.NationalSaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = SaveNational()

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico AndAlso _ViewModel.SpotTVPuertoRicoSaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = SaveSpotTVPuertoRico()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function SaveSpotRadio() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Saving)

                SaveSpotRadioViewModel()

                Saved = _Controller.SaveSpotRadio(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadSpotRadioViewModel(_ViewModel.SelectedResearchCriteria.ID, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            SaveSpotRadio = Saved

        End Function
        Private Function SaveSpotTV() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Saving)

                SaveSpotTVViewModel()

                Saved = _Controller.SaveSpotTV(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadSpotTVViewModel(_ViewModel.SpotTVSelectedResearchCriteria.ID, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            SaveSpotTV = Saved

        End Function
        Private Sub LoadSpotTVBooksTab(Optional ForceReload As Boolean = False, Optional SourceChanged As Boolean = False)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

            If TabItemSpotTV_Books.Tag <> True OrElse ForceReload Then

                ShareHPUTBookControl_Books.ClearControl()

                If Not String.IsNullOrWhiteSpace(_ViewModel.SpotTVSelectedResearchCriteria.MarketCode) Then

                    If SourceChanged Then

                        ShareHPUTBookControl_Books.Enabled = ShareHPUTBookControl_Books.LoadControl(Nothing, Me.SearchableComboBoxSpotTVMarketStation_Market.GetSelectedValue,
                                                                                                    (_ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker),
                                                                                                    _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID)
                    Else

                        ShareHPUTBookControl_Books.Enabled = ShareHPUTBookControl_Books.LoadControl(_ViewModel.SpotTVSelectedResearchCriteria.ID, Me.SearchableComboBoxSpotTVMarketStation_Market.GetSelectedValue,
                                                                                                    (_ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker),
                                                                                                    _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID)
                    End If

                    RefreshSpotTVTab()

                Else

                    ShareHPUTBookControl_Books.Enabled = False

                End If

                TabItemSpotTV_Books.Tag = True

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub EnableOrDisableActions()

            If Me.FormShown Then

                RibbonBarOptions_Demographics.Visible = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Demographics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) AndAlso TabControlNational_ResearchCriteria.SelectedTab.Equals(TabItemNational_Demographics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Demographics))

                RibbonBarOptions_Metrics.Visible = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Metrics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadioCounty_Metrics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab) AndAlso TabControlSpotRadioCounty_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadioCounty_Metrics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) AndAlso TabControlNational_ResearchCriteria.SelectedTab.Equals(TabItemNational_Metrics)) OrElse
                    (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Metrics))

                ButtonItemDemographics_Up.Enabled = RibbonBarOptions_Demographics.Visible AndAlso
                    (DataGridViewSpotTV_SelectedDemographics.HasOnlyOneSelectedRow AndAlso DataGridViewSpotTV_SelectedDemographics.CurrentView.FocusedRowHandle > 0) OrElse
                    (DataGridViewNational_DemographicsSelected.HasOnlyOneSelectedRow AndAlso DataGridViewNational_DemographicsSelected.CurrentView.FocusedRowHandle > 0) OrElse
                    (DataGridViewSpotTVPuertoRico_SelectedDemographics.HasOnlyOneSelectedRow AndAlso DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.FocusedRowHandle > 0)

                ButtonItemDemographics_Down.Enabled = RibbonBarOptions_Demographics.Visible AndAlso
                    (DataGridViewSpotTV_SelectedDemographics.HasOnlyOneSelectedRow AndAlso DataGridViewSpotTV_SelectedDemographics.CurrentView.FocusedRowHandle <> DataGridViewSpotTV_SelectedDemographics.CurrentView.RowCount - 1) OrElse
                    (DataGridViewNational_DemographicsSelected.HasOnlyOneSelectedRow AndAlso DataGridViewNational_DemographicsSelected.CurrentView.FocusedRowHandle <> DataGridViewNational_DemographicsSelected.CurrentView.RowCount - 1) OrElse
                    (DataGridViewSpotTVPuertoRico_SelectedDemographics.HasOnlyOneSelectedRow AndAlso DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.FocusedRowHandle <> DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.RowCount - 1)

                ButtonItemMetrics_Up.Enabled = ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Metrics) AndAlso
                                                RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotTV_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                DataGridViewSpotTV_SelectedMetrics.CurrentView.FocusedRowHandle > 0)) OrElse
                                               ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadio_Metrics) AndAlso
                                                RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotRadio_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                DataGridViewSpotRadio_SelectedMetrics.CurrentView.FocusedRowHandle > 0)) OrElse
                                               ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab) AndAlso TabControlSpotRadioCounty_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadioCounty_Metrics) AndAlso
                                                RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotRadioCounty_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                DataGridViewSpotRadioCounty_SelectedMetrics.CurrentView.FocusedRowHandle > 0)) OrElse
                                               ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) AndAlso TabControlNational_ResearchCriteria.SelectedTab.Equals(TabItemNational_Metrics) AndAlso
                                                RibbonBarOptions_Metrics.Visible AndAlso DataGridViewNational_MetricsSelected.HasOnlyOneSelectedRow AndAlso
                                                DataGridViewNational_MetricsSelected.CurrentView.FocusedRowHandle > 0)) OrElse
                                                ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Metrics) AndAlso
                                                RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotTVPuertoRico_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.FocusedRowHandle > 0))

                ButtonItemMetrics_Down.Enabled = ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Metrics) AndAlso
                                                  RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotTV_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                  DataGridViewSpotTV_SelectedMetrics.CurrentView.FocusedRowHandle <> DataGridViewSpotTV_SelectedMetrics.CurrentView.RowCount - 1)) OrElse
                                                 ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadio_Metrics) AndAlso
                                                  RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotRadio_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                  DataGridViewSpotRadio_SelectedMetrics.CurrentView.FocusedRowHandle <> DataGridViewSpotRadio_SelectedMetrics.CurrentView.RowCount - 1)) OrElse
                                                 ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab) AndAlso TabControlSpotRadioCounty_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadioCounty_Metrics) AndAlso
                                                  RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotRadioCounty_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                  DataGridViewSpotRadioCounty_SelectedMetrics.CurrentView.FocusedRowHandle <> DataGridViewSpotRadioCounty_SelectedMetrics.CurrentView.RowCount - 1)) OrElse
                                                 ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) AndAlso TabControlNational_ResearchCriteria.SelectedTab.Equals(TabItemNational_Metrics) AndAlso
                                                  RibbonBarOptions_Metrics.Visible AndAlso DataGridViewNational_MetricsSelected.HasOnlyOneSelectedRow AndAlso
                                                  DataGridViewNational_MetricsSelected.CurrentView.FocusedRowHandle <> DataGridViewNational_MetricsSelected.CurrentView.RowCount - 1)) OrElse
                                                  ((TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Metrics) AndAlso
                                                  RibbonBarOptions_Metrics.Visible AndAlso DataGridViewSpotTVPuertoRico_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                                                  DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.FocusedRowHandle <> DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.RowCount - 1))

                RibbonBarOptions_ReportView.Visible = TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadio_Results) AndAlso
                        _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition

                ComboBoxSpotTVMarketStation_Source.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab))
                SearchableComboBoxSpotTVMarketStation_Market.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab))
                ComboBoxSpotTVMarketStation_ReportType.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab))

                LabelSpotTVMarketStation_MaximumRank.Visible = (_ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker)
                NumericInputSpotTVMarketStation_MaximumRank.Visible = (_ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker)

                LabelSpotRadioMarket_MaxRank.Visible = (_ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker)
                NumericInputSpotRadioMarket_MaxRank.Visible = (_ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker)

                ComboBoxSpotRadioMarket_Source.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab))
                SearchableComboBoxSpotRadio_Market.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab))
                ComboBoxSpotRadioMarketDemographic_ReportType.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab))
                SearchableComboBoxSpotRadioMarket_Demographic.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab))

                RadioButtonSpotRadioListeningType_Car.Enabled = _ViewModel.SpotRadioIsDiaryMarket
                RadioButtonSpotRadioListeningType_Work.Enabled = _ViewModel.SpotRadioIsDiaryMarket

                RadioButtonSpotRadioListeningType_Home.Enabled = Not _ViewModel.SpotRadioIsDiaryMarket
                RadioButtonSpotRadioListeningType_OutOfHome.Enabled = Not _ViewModel.SpotRadioIsDiaryMarket

                RadioButtonSpotRadioGeography_DMA.Enabled = _ViewModel.SpotRadioHasDMAData
                RadioButtonSpotRadioGeography_TSA.Enabled = _ViewModel.SpotRadioHasTSAData

                If Not RadioButtonSpotRadioGeography_DMA.Enabled AndAlso RadioButtonSpotRadioGeography_DMA.Checked Then

                    RadioButtonSpotRadioGeography_Metro.Checked = True

                End If

                If Not RadioButtonSpotRadioGeography_TSA.Enabled AndAlso RadioButtonSpotRadioGeography_TSA.Checked Then

                    RadioButtonSpotRadioGeography_Metro.Checked = True

                End If

                SearchableComboBoxSpotRadioMarket_Qualitative.ReadOnly = (_ViewModel.SpotRadioQualitativeIsReadonly OrElse
                    (_ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition))

                GroupBoxSpotRadioMarket_ListeningType.Enabled = Not (_ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition)

                If DataGridViewSpotRadio_Dayparts.EmbeddedNavigator.Buttons.CustomButtons.Count > 2 Then

                    DataGridViewSpotRadio_Dayparts.EmbeddedNavigator.Buttons.CustomButtons.Item(2).Enabled = DataGridViewSpotRadio_Dayparts.HasOnlyOneSelectedRow AndAlso
                        DataGridViewSpotRadio_Dayparts.CurrentView.FocusedRowHandle > 0

                    DataGridViewSpotRadio_Dayparts.EmbeddedNavigator.Buttons.CustomButtons.Item(3).Enabled = DataGridViewSpotRadio_Dayparts.HasOnlyOneSelectedRow AndAlso
                        DataGridViewSpotRadio_Dayparts.CurrentView.FocusedRowHandle <> DataGridViewSpotRadio_Dayparts.CurrentView.RowCount - 1

                End If

                SearchableComboBoxCounty_County.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab))
                ComboBoxCounty_ReportType.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab))
                SearchableComboBoxCounty_Demographic.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab))

                LabelCounty_MaxRank.Visible = (_ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Ranker)
                NumericInputCounty_MaxRank.Visible = (_ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Ranker)

                RibbonBarOptions_Dashboard.Visible = (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Results)) OrElse
                                                     (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadio_Results)) OrElse
                                                     (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab) AndAlso TabControlSpotRadioCounty_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadioCounty_Results)) OrElse
                                                     (TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Results))

                ButtonItemView_Books.Enabled = TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) OrElse TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab)

                ComboBoxNational_ReportType.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                DateEditNationalDates_StartDate.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                DateEditNationalDates_EndDate.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                TextBoxNationalDates_Days.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                TextBoxNationalDates_StartTime.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                TextBoxNationalDates_EndTime.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))
                ComboBoxNationalDates_Stream.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab))

                'puerto rico
                ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab))

                DateEditSpotTVPuertoRicoPeriod_ShareStartDate.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab))
                DateEditSpotTVPuertoRicoPeriod_ShareEndDate.SetRequired(TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab))

            End If

        End Sub
        Private Sub LoadSpotRadioViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            'objects
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            _ViewModel = _Controller.LoadSpotRadio(ResearchID)

            If Not _MissingIntegrationSettingsMessageShown AndAlso String.IsNullOrWhiteSpace(_ViewModel.MissingIntegrationSettingsMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.MissingIntegrationSettingsMessage)
                _MissingIntegrationSettingsMessageShown = True

            End If

            ComboBoxSpotRadioMarket_Source.DataSource = _ViewModel.SpotRadioSourceList
            SearchableComboBoxSpotRadio_Market.DataSource = _ViewModel.RadioMarketList
            ComboBoxSpotRadioMarketDemographic_ReportType.DataSource = _ViewModel.SpotRadioResearchReportTypeList
            SearchableComboBoxSpotRadioMarket_Demographic.DataSource = _ViewModel.MediaDemographicList
            SearchableComboBoxSpotRadioMarket_Qualitative.DataSource = _ViewModel.NielsenRadioQualitativeList

            If LoadGrid Then

                DataGridViewSpotRadio_UserCriterias.DataSource = _ViewModel.ResearchCriteriaList

                If DataGridViewSpotRadio_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewSpotRadio_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

                DataGridViewSpotRadio_UserCriterias.CurrentView.BestFitColumns()

            Else

                DataGridViewSpotRadio_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.SelectedResearchCriteria Is Nothing Then

                DataGridViewSpotRadio_UserCriterias.FocusToFindPanel(True)

                SearchableComboBoxSpotRadio_Market.SelectedValue = Nothing

                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_Geography, 1)
                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_ListeningType, 1)
                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_Ethnicity, 1)

                NumericInputSpotRadioMarket_MaxRank.EditValue = Nothing

            Else

                DataGridViewSpotRadio_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.ID.ToString, _ViewModel.SelectedResearchCriteria.ID, True)

                ComboBoxSpotRadioMarket_Source.SelectedValue = _ViewModel.SelectedResearchCriteria.Source.ToString
                SearchableComboBoxSpotRadio_Market.SelectedValue = _ViewModel.SelectedResearchCriteria.MarketCode
                ComboBoxSpotRadioMarketDemographic_ReportType.SelectedValue = _ViewModel.SelectedResearchCriteria.ReportType.ToString

                NumericInputSpotRadioMarket_MaxRank.EditValue = _ViewModel.SelectedResearchCriteria.MaxRank

                SearchableComboBoxSpotRadioMarket_Demographic.SelectedValue = _ViewModel.SelectedResearchCriteria.MediaDemoID

                SearchableComboBoxSpotRadioMarket_Qualitative.SelectedValue = _ViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID

                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_Geography, _ViewModel.SelectedResearchCriteria.Geography)
                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_ListeningType, _ViewModel.SelectedResearchCriteria.ListeningType)
                SetGroupBoxRadioButton(GroupBoxSpotRadioMarket_Ethnicity, _ViewModel.SelectedResearchCriteria.Ethnicity)

                CheckBoxSpotRadioOptions_ShowSpill.Checked = _ViewModel.SelectedResearchCriteria.ShowSpill
                CheckBoxSpotRadioOptions_TotalListening.Checked = _ViewModel.SelectedResearchCriteria.IncludeTotalListening
                CheckBoxSpotRadioOptions_ShowFormat.Checked = _ViewModel.SelectedResearchCriteria.ShowFormat
                CheckBoxSpotRadioOptions_ShowFrequency.Checked = _ViewModel.SelectedResearchCriteria.ShowFrequency

                DataGridViewSpotRadio_Books.DataSource = _ViewModel.NielsenRadioBookList
                DataGridViewSpotRadio_Books.CurrentView.BestFitColumns()

                DataGridViewSpotRadio_Dayparts.DataSource = _ViewModel.NielsenDaypartList
                DataGridViewSpotRadio_Dayparts.CurrentView.BestFitColumns()
                DataGridViewSpotRadio_Dayparts.CurrentView.Columns(AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString).Width = 150

                RepositoryItemGridLookUpEdit = DataGridViewSpotRadio_Dayparts.CurrentView.Columns(AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString).ColumnEdit

                If RepositoryItemGridLookUpEdit IsNot Nothing Then

                    RemoveHandler RepositoryItemGridLookUpEdit.Popup, AddressOf RepositoryItemGridLookUpEdit_PopUp
                    AddHandler RepositoryItemGridLookUpEdit.Popup, AddressOf RepositoryItemGridLookUpEdit_PopUp

                End If

                DataGridViewSpotRadio_AvailableMetrics.DataSource = _ViewModel.AvailableMetricList
                DataGridViewSpotRadio_AvailableMetrics.CurrentView.BestFitColumns()

                DataGridViewSpotRadio_SelectedMetrics.DataSource = _ViewModel.SelectedMetricList
                DataGridViewSpotRadio_SelectedMetrics.CurrentView.BestFitColumns()

                DataGridViewSpotRadio_AvailableStations.DataSource = _ViewModel.AvailableStationList
                DataGridViewSpotRadio_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewSpotRadio_SelectedStations.DataSource = _ViewModel.SelectedStationList
                DataGridViewSpotRadio_SelectedStations.CurrentView.BestFitColumns()

            End If

            RefreshSpotRadioTab()

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub LoadSpotTVViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            ShareHPUTBookControl_Books.ClearControl()

            TabItemSpotTV_Books.Tag = False

            _ViewModel = _Controller.LoadSpotTV(ResearchID)

            If Not _MissingIntegrationSettingsMessageShown AndAlso String.IsNullOrWhiteSpace(_ViewModel.MissingIntegrationSettingsMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.MissingIntegrationSettingsMessage)
                _MissingIntegrationSettingsMessageShown = True

            End If

            ComboBoxSpotTVMarketStation_Source.DataSource = _ViewModel.SpotTVSourceList
            SearchableComboBoxSpotTVMarketStation_Market.DataSource = _ViewModel.SpotTVMarketList
            ComboBoxSpotTVMarketStation_ReportType.DataSource = _ViewModel.SpotTVResearchReportTypeList

            If LoadGrid Then

                DataGridViewSpotTV_UserCriterias.DataSource = _ViewModel.SpotTVResearchCriteriaList

                If DataGridViewSpotTV_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewSpotTV_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

                DataGridViewSpotTV_UserCriterias.CurrentView.BestFitColumns()

            Else

                DataGridViewSpotTV_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.SpotTVSelectedResearchCriteria Is Nothing Then

                DataGridViewSpotTV_UserCriterias.FocusToFindPanel(True)

                SearchableComboBoxSpotTVMarketStation_Market.SelectedValue = Nothing

                NumericInputSpotTVMarketStation_MaximumRank.EditValue = Nothing

            Else

                DataGridViewSpotTV_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.ID.ToString, _ViewModel.SpotTVSelectedResearchCriteria.ID, True)

                ComboBoxSpotTVMarketStation_Source.SelectedValue = _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID.ToString
                SearchableComboBoxSpotTVMarketStation_Market.SelectedValue = _ViewModel.SpotTVSelectedResearchCriteria.MarketCode
                ComboBoxSpotTVMarketStation_ReportType.SelectedValue = _ViewModel.SpotTVSelectedResearchCriteria.ReportType.ToString

                CheckBoxSpotTVOptions_DominantProgramming.Checked = _ViewModel.SpotTVSelectedResearchCriteria.DominantProgramming
                CheckBoxSpotTVOptions_ShowProgramName.Checked = _ViewModel.SpotTVSelectedResearchCriteria.ShowProgramName
                CheckBoxSpotTVOptions_ShowSpill.Checked = _ViewModel.SpotTVSelectedResearchCriteria.ShowSpill
                CheckBoxSpotTVOptions_GroupByDaysTimes.Checked = _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes

                NumericInputSpotTVMarketStation_MaximumRank.EditValue = _ViewModel.SpotTVSelectedResearchCriteria.MaxRank

                If String.IsNullOrWhiteSpace(_ViewModel.SpotTVSelectedResearchCriteria.MarketCode) = False Then

                    LoadSpotTVBooksTab()

                End If

                DataGridViewSpotTV_DayTimes.DataSource = _ViewModel.SpotTVDayTimeList
                DataGridViewSpotTV_DayTimes.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableDemographics.DataSource = _ViewModel.SpotTVAvailableDemographicList
                DataGridViewSpotTV_AvailableDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTV_SelectedDemographics.DataSource = _ViewModel.SpotTVSelectedDemographicList
                DataGridViewSpotTV_SelectedDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableMetrics.DataSource = _ViewModel.SpotTVAvailableMetricList
                DataGridViewSpotTV_AvailableMetrics.CurrentView.BestFitColumns()

                DataGridViewSpotTV_SelectedMetrics.DataSource = _ViewModel.SpotTVSelectedMetricList
                DataGridViewSpotTV_SelectedMetrics.CurrentView.BestFitColumns()

                ShowOrHideDemographicsColumns(DataGridViewSpotTV_AvailableDemographics)
                ShowOrHideDemographicsColumns(DataGridViewSpotTV_SelectedDemographics)

            End If

            RefreshSpotTVTab()

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub SaveSpotTVViewModel()

            DataGridViewSpotTV_DayTimes.CurrentView.CloseEditorForUpdating()
            ShareHPUTBookControl_Books.DataGridViewControl_ShareHPUTBook.CurrentView.CloseEditorForUpdating()

            _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = ComboBoxSpotTVMarketStation_Source.GetSelectedValue
            _ViewModel.SpotTVSelectedResearchCriteria.MarketCode = SearchableComboBoxSpotTVMarketStation_Market.GetSelectedValue
            _ViewModel.SpotTVSelectedResearchCriteria.ReportType = ComboBoxSpotTVMarketStation_ReportType.GetSelectedValue
            _ViewModel.SpotTVSelectedResearchCriteria.DominantProgramming = CheckBoxSpotTVOptions_DominantProgramming.Checked
            _ViewModel.SpotTVSelectedResearchCriteria.ShowProgramName = CheckBoxSpotTVOptions_ShowProgramName.Checked
            _ViewModel.SpotTVSelectedResearchCriteria.ShowSpill = CheckBoxSpotTVOptions_ShowSpill.Checked
            _ViewModel.SpotTVSelectedResearchCriteria.MaxRank = NumericInputSpotTVMarketStation_MaximumRank.GetValue
            _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes = CheckBoxSpotTVOptions_GroupByDaysTimes.Checked

            _ViewModel.SpotTVSelectedNielsenStationList = DataGridViewSpotTV_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Station).ToList
            _ViewModel.SpotTVDayTimeList = DataGridViewSpotTV_DayTimes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList

            _ViewModel.SpotTVShareHPUTBookViewModel = ShareHPUTBookControl_Books.ViewModel

            _ViewModel.SpotTVSelectedDemographicList = DataGridViewSpotTV_SelectedDemographics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Demographic).ToList
            _ViewModel.SpotTVSelectedMetricList = DataGridViewSpotTV_SelectedMetrics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList

        End Sub
        Private Sub SaveSpotRadioViewModel()

            _ViewModel.SelectedResearchCriteria.Source = ComboBoxSpotRadioMarket_Source.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.MarketCode = SearchableComboBoxSpotRadio_Market.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.ReportType = ComboBoxSpotRadioMarketDemographic_ReportType.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.MediaDemoID = SearchableComboBoxSpotRadioMarket_Demographic.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = SearchableComboBoxSpotRadioMarket_Qualitative.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.MaxRank = NumericInputSpotRadioMarket_MaxRank.GetValue

            _ViewModel.SelectedResearchCriteria.ShowSpill = CheckBoxSpotRadioOptions_ShowSpill.Checked
            _ViewModel.SelectedResearchCriteria.IncludeTotalListening = CheckBoxSpotRadioOptions_TotalListening.Checked
            _ViewModel.SelectedResearchCriteria.ShowFormat = CheckBoxSpotRadioOptions_ShowFormat.Checked
            _ViewModel.SelectedResearchCriteria.ShowFrequency = CheckBoxSpotRadioOptions_ShowFrequency.Checked

            _ViewModel.SelectedResearchCriteria.Geography = GetGroupBoxRadioButtonValue(GroupBoxSpotRadioMarket_Geography)
            _ViewModel.SelectedResearchCriteria.ListeningType = GetGroupBoxRadioButtonValue(GroupBoxSpotRadioMarket_ListeningType)
            _ViewModel.SelectedResearchCriteria.Ethnicity = GetGroupBoxRadioButtonValue(GroupBoxSpotRadioMarket_Ethnicity)

            _ViewModel.NielsenRadioBookList = DataGridViewSpotRadio_Books.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList

            _ViewModel.NielsenDaypartList = DataGridViewSpotRadio_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList

            _ViewModel.SelectedMetricList = DataGridViewSpotRadio_SelectedMetrics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList

            _ViewModel.SelectedStationList = DataGridViewSpotRadio_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList

        End Sub
        Private Sub ResizeBandChildren(BandedDataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView, GridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            'objects
            Dim Graphics As System.Drawing.Graphics = Nothing
            Dim ColumnsWidth As Integer = 0
            Dim BandStringSize As System.Drawing.SizeF = Nothing
            Dim StringSize As System.Drawing.SizeF = Nothing

            Graphics = BandedDataGridView.CreateGraphics()

            For Each Band In GridBand.Children

                ColumnsWidth = 0

                BandStringSize = Graphics.MeasureString(Band.Caption, BandedDataGridView.Font)

                For Each GridColumn In Band.Columns

                    StringSize = Graphics.MeasureString(GridColumn.GetCaption, GridColumn.AppearanceCell.Font)
                    ColumnsWidth += Math.Round(StringSize.Width, 0)

                Next

                If Band.Width < ColumnsWidth OrElse Band.Width < BandStringSize.Width Then

                    Band.Width = If(ColumnsWidth > BandStringSize.Width, ColumnsWidth, BandStringSize.Width) + 5

                End If

            Next

            Graphics.Dispose()

        End Sub
        Private Sub BestFitBands(BandedDataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedDataGridView)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim Graphics As System.Drawing.Graphics = Nothing
            Dim ColumnsWidth As Integer = 0
            Dim BandStringSize As System.Drawing.SizeF = Nothing
            Dim StringSize As System.Drawing.SizeF = Nothing

            If BandedDataGridView.CurrentView.Bands.Count > 0 Then

                Graphics = BandedDataGridView.CreateGraphics()

                CopyrightGridBand = BandedDataGridView.CurrentView.Bands.Item(0)

                If CopyrightGridBand IsNot Nothing Then

                    BandStringSize = Graphics.MeasureString(CopyrightGridBand.Caption, BandedDataGridView.Font)

                    If BandStringSize.Width > CopyrightGridBand.Width Then

                        CopyrightGridBand.Width = BandStringSize.Width

                    End If

                    For Each Band In CopyrightGridBand.Children

                        ColumnsWidth = 0

                        BandStringSize = Graphics.MeasureString(Band.Caption, BandedDataGridView.Font)

                        For Each GridColumn In Band.Columns

                            StringSize = Graphics.MeasureString(GridColumn.GetCaption, GridColumn.AppearanceCell.Font)
                            ColumnsWidth += Math.Round(StringSize.Width, 0)

                        Next

                        If Band.Width < ColumnsWidth OrElse Band.Width < BandStringSize.Width Then

                            Band.Width = If(ColumnsWidth > BandStringSize.Width, ColumnsWidth, BandStringSize.Width)

                        End If

                        ResizeBandChildren(BandedDataGridView, Band)

                    Next

                End If

                Graphics.Dispose()

            End If

        End Sub
        Private Sub SetupSpotTVRankerDataBands(RatingsServiceID As Integer)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DemoBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DemoBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim DoneSorting As Boolean = False
            Dim SortString As String = Nothing

            BandedDataGridViewSpotTVResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotTVResults.ClearGridCustomization()
            BandedDataGridViewSpotTVResults.AutoUpdateViewCaption = False

            DemoBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                CopyrightGridBand.Caption = _NielsenCopyright

            Else

                CopyrightGridBand.Caption = _ComscoreCopyright

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Add(CopyrightGridBand)

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            If _ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 Then

                BlankGridBand.Caption = "Market: " & _ViewModel.SpotTVResearchResultList.FirstOrDefault.MarketDescription

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotTVResearchResultList
                                        Select Entity.DemographicOrder, Entity.DemographicStream, Entity.BookID, Entity.HPUTBookID, Entity.MediaSpotTVResearchBookID).OrderBy(Function(Entity) Entity.DemographicOrder).ThenBy(Function(Entity) Entity.MediaSpotTVResearchBookID).Distinct.ToList

                DemoBand = CopyrightGridBand.Children.AddBand(ResearchResult.DemographicStream)
                DemoBand.Tag = ResearchResult.DemographicOrder & "_" & ResearchResult.BookID & "_" & ResearchResult.HPUTBookID.GetValueOrDefault(0)
                DemoBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                DemoBand.AppearanceHeader.Options.UseTextOptions = True
                DemoBand.OptionsBand.FixedWidth = True
                DemoBand.OptionsBand.AllowMove = False

                DemoBands.Add(DemoBand)

            Next

            BandedDataGridViewSpotTVResults.ClearDatasource(_ViewModel.SpotTVReportDataTable.Clone)

            BandedDataGridViewSpotTVResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Station.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.ProgramName.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Demo") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)
                    GridColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False

                End If

            Next

            For Each DemoBand In DemoBands

                For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                    If GridColumn.FieldName.EndsWith(DemoBand.Tag) Then

                        DemoBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Imps (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            If _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                GridColumn.Caption = "SIU"

                            Else

                                GridColumn.Caption = "H/PUT"

                            End If

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ShowIntabWarning") Then

                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName.StartsWith("CSInfo") Then

                            GridColumn.Caption = " "

                        End If

                    End If

                Next

            Next

            If _ViewModel.SpotTVReportDataTable.Rows.Count > 0 Then

                For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        VisibleIndex = BandedDataGridViewSpotTVResults.CurrentView.Columns(GridColumn.FieldName).VisibleIndex + 1

                        _ViewModel.SpotTVReportDataTable.Columns.Add("NullRankCheck", GetType(Integer), GridColumn.FieldName & " Is Null")

                        SortString = "NullRankCheck ASC, " & GridColumn.FieldName & " ASC"

                        Exit For

                    End If

                Next

                While Not DoneSorting AndAlso BandedDataGridViewSpotTVResults.CurrentView.Columns(VisibleIndex + 1) IsNot Nothing

                    If BandedDataGridViewSpotTVResults.CurrentView.Columns(VisibleIndex + 1).FieldName.StartsWith("Rank") Then

                        DoneSorting = True

                    Else

                        SortString += ", " & BandedDataGridViewSpotTVResults.CurrentView.Columns(VisibleIndex + 1).FieldName & " DESC"

                    End If

                    VisibleIndex += 1

                    If VisibleIndex > BandedDataGridViewSpotTVResults.CurrentView.VisibleColumns.Count - 1 Then

                        DoneSorting = True

                    End If

                End While

            End If

            _ViewModel.SpotTVReportDataTable.DefaultView.Sort = SortString

            BandedDataGridViewSpotTVResults.CurrentView.ViewCaption = _ViewModel.SpotTVSelectedResearchCriteria.CriteriaName & " (Ranker)"
            BandedDataGridViewSpotTVResults.DataSource = _ViewModel.SpotTVReportDataTable.DefaultView.ToTable

            If BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            If _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes Then

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString).Group()

                End If

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString).Group()

                End If

            End If

            BandedDataGridViewSpotTVResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotTVResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVResults)

        End Sub
        Private Sub SetupSpotTVTrendByBookDataBands(RatingsServiceID As Integer)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim StationMetricsBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim StationMetricsBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewSpotTVResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotTVResults.ClearGridCustomization()
            BandedDataGridViewSpotTVResults.AutoUpdateViewCaption = False

            StationMetricsBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                CopyrightGridBand.Caption = _NielsenCopyright

            Else

                CopyrightGridBand.Caption = _ComscoreCopyright

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Add(CopyrightGridBand)

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            If _ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 Then

                BlankGridBand.Caption = "Market: " & _ViewModel.SpotTVResearchResultList.FirstOrDefault.MarketDescription & " / " & _ViewModel.SpotTVResearchResultList.FirstOrDefault.Demographic

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotTVResearchResultList
                                        Select Entity.Station,
                                               Entity.StationCode).Distinct.OrderBy(Function(Entity) Entity.Station).ToList

                StationMetricsBand = CopyrightGridBand.Children.AddBand("")

                If _ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 AndAlso _ViewModel.SpotTVResearchResultList.FirstOrDefault.ShowSpill AndAlso
                        _ViewModel.SpotTVResearchResultList.Where(Function(Entity) Entity.StationCode = ResearchResult.StationCode).FirstOrDefault.IsSpill Then

                    StationMetricsBand.Caption = ResearchResult.Station & " (Spill)"

                Else

                    StationMetricsBand.Caption = ResearchResult.Station

                End If

                StationMetricsBand.Tag = ResearchResult.StationCode
                StationMetricsBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                StationMetricsBand.AppearanceHeader.Options.UseTextOptions = True
                StationMetricsBand.OptionsBand.FixedWidth = True
                StationMetricsBand.OptionsBand.AllowMove = False

                StationMetricsBands.Add(StationMetricsBand)

            Next

            BandedDataGridViewSpotTVResults.ClearDatasource(_ViewModel.SpotTVReportDataTable.Clone)

            BandedDataGridViewSpotTVResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Books.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Books.ToString Then

                        GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Station") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each StationMetricsBand In StationMetricsBands

                For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                    If GridColumn.FieldName.EndsWith(StationMetricsBand.Tag) Then

                        StationMetricsBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Imps (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            If _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                GridColumn.Caption = "SIU"

                            Else

                                GridColumn.Caption = "H/PUT"

                            End If

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ProgramName") Then

                            GridColumn.Caption = "Program Name"

                        ElseIf GridColumn.FieldName.StartsWith("ShowIntabWarning") Then

                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName.StartsWith("CSInfo") Then

                            GridColumn.Caption = " "

                        End If

                    End If

                Next

            Next

            BandedDataGridViewSpotTVResults.CurrentView.ViewCaption = _ViewModel.SpotTVSelectedResearchCriteria.CriteriaName & " (Trend By Book)"
            BandedDataGridViewSpotTVResults.DataSource = _ViewModel.SpotTVReportDataTable

            If BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            If _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes Then

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString).Group()

                End If

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString).Group()

                End If

            End If

            BandedDataGridViewSpotTVResults.OptionsBehavior.Editable = False

            'If _ViewModel.SpotTVReportDataTable.Rows.Count > 0 AndAlso BandedDataGridViewSpotTVResults.CurrentView.Columns("Station") IsNot Nothing Then

            '    BandedDataGridViewSpotTVResults.CurrentView.ClearSorting()
            '    BandedDataGridViewSpotTVResults.CurrentView.BeginSort()
            '    BandedDataGridViewSpotTVResults.CurrentView.Columns("Station").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            '    BandedDataGridViewSpotTVResults.CurrentView.EndSort()

            'End If

            BandedDataGridViewSpotTVResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVResults)

        End Sub
        Private Sub SetupSpotTVTrendByStationDataBands(RatingsServiceID As Integer)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BookMetricsBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim BookMetricsBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewSpotTVResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotTVResults.ClearGridCustomization()
            BandedDataGridViewSpotTVResults.AutoUpdateViewCaption = False

            BookMetricsBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                CopyrightGridBand.Caption = _NielsenCopyright

            Else

                CopyrightGridBand.Caption = _ComscoreCopyright

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotTVResults.CurrentView.Bands.Add(CopyrightGridBand)

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            If _ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 Then

                BlankGridBand.Caption = "Market: " & _ViewModel.SpotTVResearchResultList.FirstOrDefault.MarketDescription & " / " & _ViewModel.SpotTVResearchResultList.FirstOrDefault.Demographic

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotTVResearchResultList
                                        Select Entity.Books,
                                               Entity.MediaSpotTVResearchBookID).Distinct.ToList

                BookMetricsBand = CopyrightGridBand.Children.AddBand("")

                BookMetricsBand.Caption = ResearchResult.Books

                BookMetricsBand.Tag = ResearchResult.MediaSpotTVResearchBookID
                BookMetricsBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                BookMetricsBand.AppearanceHeader.Options.UseTextOptions = True
                BookMetricsBand.OptionsBand.FixedWidth = True
                BookMetricsBand.OptionsBand.AllowMove = False

                BookMetricsBands.Add(BookMetricsBand)

            Next

            BandedDataGridViewSpotTVResults.ClearDatasource(_ViewModel.SpotTVReportDataTable.Clone)

            BandedDataGridViewSpotTVResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Station.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.IsSpill.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.StationCode.ToString Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Books") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each BookMetricsBand In BookMetricsBands

                For Each GridColumn In BandedDataGridViewSpotTVResults.Columns

                    If GridColumn.FieldName.EndsWith(BookMetricsBand.Tag) Then

                        BookMetricsBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Imps (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            If _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                                GridColumn.Caption = "SIU"

                            Else

                                GridColumn.Caption = "H/PUT"

                            End If

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ProgramName") Then

                            GridColumn.Caption = "Program Name"

                        ElseIf GridColumn.FieldName.StartsWith("ShowIntabWarning") Then

                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName.StartsWith("BookIDDaytimeID") Then

                            GridColumn.Visible = False

                        ElseIf GridColumn.FieldName.StartsWith("CSInfo") Then

                            GridColumn.Caption = " "

                        End If

                    End If

                Next

            Next

            BandedDataGridViewSpotTVResults.CurrentView.ViewCaption = _ViewModel.SpotTVSelectedResearchCriteria.CriteriaName & " (Trend By Station)"
            BandedDataGridViewSpotTVResults.DataSource = _ViewModel.SpotTVReportDataTable

            If BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotTVResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            If _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes Then

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString).Group()

                End If

                If BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString).Group()

                End If

            End If

            BandedDataGridViewSpotTVResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotTVResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVResults)

        End Sub
        Private Sub RefreshSpotRadioTab(Optional RefreshData As Boolean = True)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

            TabControlSpotRadio_ResearchCriteria.Enabled = (_ViewModel.SelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Export.Enabled = _ViewModel.ExportEnabled
            ButtonItemActions_Add.Enabled = _ViewModel.AddEnabled
            ButtonItemActions_Edit.Enabled = _ViewModel.EditEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.CopyEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.ProcessEnabled
            ButtonItemActions_Refresh.Enabled = (_ViewModel.SelectedResearchCriteria IsNot Nothing)

            TabItemSpotRadio_Results.Visible = (Not _ViewModel.SpotRadioIsDirty AndAlso _ViewModel.SpotRadioReportDataTable IsNot Nothing)

            If _ViewModel.SpotRadioQualitativeIsReadonly Then

                SearchableComboBoxSpotRadioMarket_Qualitative.SelectedValue = 1

            End If

            If _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                RadioButtonSpotRadioListeningType_Total.Checked = True

            End If

            If _ViewModel.SelectedResearchCriteria IsNot Nothing Then

                GroupBoxSpotRadioMarket_Options.Enabled = (_ViewModel.SelectedResearchCriteria.Source = Nielsen.Database.Entities.RadioSource.Nielsen)

                If _ViewModel.SelectedResearchCriteria.Source = Nielsen.Database.Entities.RadioSource.Eastlan Then

                    CheckBoxSpotRadioOptions_ShowSpill.Checked = False
                    CheckBoxSpotRadioOptions_ShowFormat.Checked = False
                    CheckBoxSpotRadioOptions_ShowFrequency.Checked = False

                Else

                    CheckBoxSpotRadioOptions_ShowSpill.Checked = _ViewModel.SelectedResearchCriteria.ShowSpill
                    CheckBoxSpotRadioOptions_ShowFormat.Checked = _ViewModel.SelectedResearchCriteria.ShowFormat
                    CheckBoxSpotRadioOptions_ShowFrequency.Checked = _ViewModel.SelectedResearchCriteria.ShowFrequency

                End If

            Else

                GroupBoxSpotRadioMarket_Options.Enabled = True

            End If

            If RefreshData Then

                SearchableComboBoxSpotRadio_Market.DataSource = Nothing
                SearchableComboBoxSpotRadio_Market.DataSource = _ViewModel.RadioMarketList

                If _ViewModel.SelectedResearchCriteria IsNot Nothing Then

                    SearchableComboBoxSpotRadio_Market.SelectedValue = _ViewModel.SelectedResearchCriteria.MarketCode

                End If

                DataGridViewSpotRadio_Books.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook))
                DataGridViewSpotRadio_Books.DataSource = _ViewModel.NielsenRadioBookList

                DataGridViewSpotRadio_AvailableStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station))
                DataGridViewSpotRadio_AvailableStations.DataSource = _ViewModel.AvailableStationList

                DataGridViewSpotRadio_SelectedStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station))
                DataGridViewSpotRadio_SelectedStations.DataSource = _ViewModel.SelectedStationList

                DataGridViewSpotRadio_Dayparts.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart))
                DataGridViewSpotRadio_Dayparts.DataSource = _ViewModel.NielsenDaypartList

                DataGridViewSpotRadio_AvailableMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotRadio_AvailableMetrics.DataSource = _ViewModel.AvailableMetricList

                DataGridViewSpotRadio_SelectedMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotRadio_SelectedMetrics.DataSource = _ViewModel.SelectedMetricList

                If _ViewModel.SpotRadioReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Ranker Then

                    SetupSpotRadioRankerDataBands()

                ElseIf _ViewModel.SpotRadioReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Trend Then

                    SetupSpotRadioTrendDataBands()

                ElseIf _ViewModel.SpotRadioReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                    SetupSpotRadioAudienceCompositionDataBands()

                Else

                    BandedDataGridViewSpotRadioResults.CurrentView.Bands.Clear()
                    BandedDataGridViewSpotRadioResults.ClearGridCustomization()

                End If

            End If

            If _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.Age Then

                ButtonItemReportView_ByAge.Checked = True

            ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.AgeGender Then

                ButtonItemReportView_ByAgeGender.Checked = True

            ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.Gender Then

                ButtonItemReportView_ByGender.Checked = True

            End If

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub RefreshSpotTVTab(Optional RefreshData As Boolean = True)

            TabControlSpotTV_ResearchCriteria.Enabled = (_ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Export.Enabled = _ViewModel.SpotTVExportEnabled
            ButtonItemActions_Add.Enabled = _ViewModel.SpotTVAddEnabled
            ButtonItemActions_Edit.Enabled = _ViewModel.SpotTVEditEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SpotTVSaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.SpotTVDeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.SpotTVCopyEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.SpotTVProcessEnabled
            ButtonItemActions_Refresh.Enabled = (_ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing)

            TabItemSpotTV_Results.Visible = (Not _ViewModel.SpotTVIsDirty AndAlso _ViewModel.SpotTVReportDataTable IsNot Nothing)

            If RefreshData Then

                SearchableComboBoxSpotTVMarketStation_Market.DataSource = _ViewModel.SpotTVMarketList

                If _ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing Then

                    CheckBoxSpotTVOptions_ShowSpill.Enabled = (_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen)

                    CheckBoxSpotTVOptions_ShowProgramName.Checked = _ViewModel.SpotTVSelectedResearchCriteria.ShowProgramName
                    CheckBoxSpotTVOptions_ShowSpill.Checked = _ViewModel.SpotTVSelectedResearchCriteria.ShowSpill
                    CheckBoxSpotTVOptions_GroupByDaysTimes.Checked = _ViewModel.SpotTVSelectedResearchCriteria.GroupByDaysTimes

                End If

                DataGridViewSpotTV_AvailableStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station))
                DataGridViewSpotTV_AvailableStations.DataSource = _ViewModel.SpotTVAvailableNielsenStationList

                If DataGridViewSpotTV_AvailableStations.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.Station.Properties.StationCode.ToString) IsNot Nothing Then

                    DataGridViewSpotTV_AvailableStations.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.Station.Properties.StationCode.ToString).Visible = False

                End If

                DataGridViewSpotTV_SelectedStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station))
                DataGridViewSpotTV_SelectedStations.DataSource = _ViewModel.SpotTVSelectedNielsenStationList

                If DataGridViewSpotTV_SelectedStations.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.Station.Properties.StationCode.ToString) IsNot Nothing Then

                    DataGridViewSpotTV_SelectedStations.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.Station.Properties.StationCode.ToString).Visible = False

                End If

                DataGridViewSpotTV_DayTimes.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.DaysAndTime))
                DataGridViewSpotTV_DayTimes.DataSource = _ViewModel.SpotTVDayTimeList

                DataGridViewSpotTV_AvailableDemographics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic))
                DataGridViewSpotTV_AvailableDemographics.DataSource = _ViewModel.SpotTVAvailableDemographicList

                DataGridViewSpotTV_SelectedDemographics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic))
                DataGridViewSpotTV_SelectedDemographics.DataSource = _ViewModel.SpotTVSelectedDemographicList

                DataGridViewSpotTV_AvailableMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotTV_AvailableMetrics.DataSource = _ViewModel.SpotTVAvailableMetricList

                DataGridViewSpotTV_SelectedMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotTV_SelectedMetrics.DataSource = _ViewModel.SpotTVSelectedMetricList

                ShowOrHideDemographicsColumns(DataGridViewSpotTV_AvailableDemographics)
                ShowOrHideDemographicsColumns(DataGridViewSpotTV_SelectedDemographics)

                If _ViewModel.SpotTVReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVProcessEnabled AndAlso _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.Ranker Then

                    SetupSpotTVRankerDataBands(_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID)

                ElseIf _ViewModel.SpotTVReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVProcessEnabled AndAlso _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook Then

                    SetupSpotTVTrendByBookDataBands(_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID)

                ElseIf _ViewModel.SpotTVReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVProcessEnabled AndAlso _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation Then

                    SetupSpotTVTrendByStationDataBands(_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID)

                Else

                    BandedDataGridViewSpotTVResults.CurrentView.Bands.Clear()
                    BandedDataGridViewSpotTVResults.ClearGridCustomization()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub RepositoryItem_Enter(sender As Object, e As EventArgs)

            CType(sender, DevExpress.XtraEditors.BaseEdit).SelectAll()

        End Sub
        Private Function GetGroupBoxRadioButtonValue(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox) As Object

            'objects
            Dim ObjectValue As Object = Nothing

            For Each RadioButtonControl In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked Then

                    ObjectValue = RadioButtonControl.Tag
                    Exit For

                End If

            Next

            GetGroupBoxRadioButtonValue = ObjectValue

        End Function
        Private Sub SetGroupBoxRadioButton(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox, TagValue As Object)

            For Each RadioButtonControl In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Tag = TagValue Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

        End Sub
        Private Sub GeographyChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetGeography(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl).Tag))

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub ListeningTypeChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetListeningType(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl).Tag))

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub EthnicityChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetEthnicity(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl).Tag))

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Function CUMEVisibility(BroadcastResearchViewModel As AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel, Fieldname As String, CheckType As CumeType) As Boolean

            'objects
            Dim IsVisible As Boolean = True
            Dim StartUnderscore As Integer = -1
            Dim EndUnderscore As Integer = -1
            Dim NielsenPeriodID As Integer = 0

            StartUnderscore = InStr(1, Fieldname, "_")
            EndUnderscore = InStr(StartUnderscore + 1, Fieldname, "_")

            If StartUnderscore <> -1 AndAlso EndUnderscore <> -1 Then

                NielsenPeriodID = Mid(Fieldname, StartUnderscore + 1, EndUnderscore - StartUnderscore - 1)

                If CheckType = CumeType.CUME AndAlso Not BroadcastResearchViewModel.CumeNielsenPeriodIDs.Contains(NielsenPeriodID) Then

                    IsVisible = False

                ElseIf CheckType = CumeType.ECUME AndAlso Not BroadcastResearchViewModel.ExclusiveCumeNielsenPeriodIDs.Contains(NielsenPeriodID) Then

                    IsVisible = False

                End If

            End If

            CUMEVisibility = IsVisible

        End Function
        Private Function SpotRadioGetEthnicity() As String

            'objects
            Dim Ethnicity As String = String.Empty

            If _ViewModel.SelectedResearchCriteria.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Black Then

                Ethnicity = " / " & AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Black.ToString

            ElseIf _ViewModel.SelectedResearchCriteria.Ethnicity = AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Hispanic Then

                Ethnicity = " / " & AdvantageFramework.Database.Entities.SpotRadioResearchEthnicity.Hispanic.ToString

            End If

            SpotRadioGetEthnicity = Ethnicity

        End Function
        Private Function SpotRadioGetGeography() As String

            'objects
            Dim GeographyName As String = String.Empty

            If _ViewModel.SelectedResearchCriteria.Geography = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.Metro Then

                GeographyName = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.Metro.ToString

            ElseIf _ViewModel.SelectedResearchCriteria.Geography = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.TSA Then

                GeographyName = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.TSA.ToString

            ElseIf _ViewModel.SelectedResearchCriteria.Geography = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.DMA Then

                GeographyName = AdvantageFramework.Database.Entities.SpotRadioResearchGeography.DMA.ToString

            End If

            SpotRadioGetGeography = GeographyName

        End Function
        Private Function SpotRadioGetListeningType() As String

            'objects
            Dim ListeningType As String = String.Empty

            If _ViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Car Then

                ListeningType = "Listening in Car"

            ElseIf _ViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Home Then

                ListeningType = "Listening at Home"

            ElseIf _ViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.OutOfHome Then

                ListeningType = "Listening Out of Home"

            ElseIf _ViewModel.SelectedResearchCriteria.ListeningType = AdvantageFramework.Database.Entities.SpotRadioResearchListeningType.Work Then

                ListeningType = "Listening at Work"

            End If

            SpotRadioGetListeningType = ListeningType

        End Function
        Private Sub SetupSpotRadioRankerDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim IntabInfoGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DaypartBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DaypartBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SortString As String = Nothing

            BandedDataGridViewSpotRadioResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotRadioResults.ClearGridCustomization()
            BandedDataGridViewSpotRadioResults.AutoUpdateViewCaption = False

            DaypartBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                CopyrightGridBand.Caption = Strings.Trim(Replace(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Copyright, "Copyright", "Copyright ©")) & ", " & _ViewModel.SpotRadioResearchResultList.FirstOrDefault.CopyrightMarketBooks

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " EASTLAN RESOURCES"

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Add(CopyrightGridBand)

            IntabInfoGridBand = CopyrightGridBand.Children.AddBand("")
            IntabInfoGridBand.Name = "IntabInfo"

            If _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                If _ViewModel.SpotRadioResearchResultList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.BookCount = 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0) & "* Warning: Estimates may be unstable due to low sample size."

                ElseIf _ViewModel.SpotRadioResearchResultList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.BookCount > 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0) & "* Warning: One or more of the books averaged are less than Nielsen standard and considered unstable."

                Else

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0)

                End If

            End If

            IntabInfoGridBand.OptionsBand.AllowMove = False

            BlankGridBand = IntabInfoGridBand.Children.AddBand("")

            If _ViewModel.SpotRadioResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                BlankGridBand.Caption = SpotRadioGetGeography() & "/" & _ViewModel.SpotRadioResearchResultList.FirstOrDefault.Demographic & Space(1) &
                    If(String.IsNullOrWhiteSpace(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.QualitativeName), SpotRadioGetListeningType(), _ViewModel.SpotRadioResearchResultList.FirstOrDefault.QualitativeName & Space(1) & SpotRadioGetListeningType())

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotRadioResearchResultList
                                        Select Entity.Daypart, Entity.DaypartBooks, Entity.MediaSpotRadioResearchDaypartID).OrderBy(Function(Entity) Entity.MediaSpotRadioResearchDaypartID).Distinct.ToList

                DaypartBand = IntabInfoGridBand.Children.AddBand(ResearchResult.Daypart)
                DaypartBand.Tag = ResearchResult.MediaSpotRadioResearchDaypartID
                DaypartBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                DaypartBand.AppearanceHeader.Options.UseTextOptions = True
                DaypartBand.OptionsBand.FixedWidth = True
                DaypartBand.OptionsBand.AllowMove = False

                DaypartBands.Add(DaypartBand)

            Next

            BandedDataGridViewSpotRadioResults.ClearDatasource(_ViewModel.SpotRadioReportDataTable.Clone)

            BandedDataGridViewSpotRadioResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFormat.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFrequency.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString Then

                        GridColumn.Caption = "Station"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFormat.ToString Then

                        GridColumn.Caption = "Format"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFrequency.ToString Then

                        GridColumn.Caption = "Frequency"

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Daypart") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each DaypartBand In DaypartBands

                For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                    If GridColumn.FieldName.EndsWith(DaypartBand.Tag) Then

                        DaypartBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("AQHRating") Then

                            GridColumn.Caption = "AQH Rating"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("AQHShare") Then

                            GridColumn.Caption = "AQH Share"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("AQH") Then

                            GridColumn.Caption = "AQH (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("CumeRating") Then

                            GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.CUME)
                            GridColumn.Caption = "Cume Rating"
                            GridColumn.DisplayFormat.FormatString = "n1"

                            'ElseIf GridColumn.FieldName.StartsWith("CumeShare") Then

                            '    GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.CUME)
                            '    GridColumn.Caption = "Cume Share"
                            '    GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("Cume") Then

                            GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.CUME)
                            GridColumn.Caption = "Cume (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ExclusiveCume") Then

                            GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.ECUME)
                            GridColumn.Caption = "Exclusive Cume (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("PURPercent") Then

                            GridColumn.Caption = "PUR %"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("PUR") Then

                            GridColumn.Caption = "PUR (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        End If

                    End If

                Next

            Next

            If _ViewModel.SpotRadioReportDataTable.Rows.Count > 0 Then

                For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        _ViewModel.SpotRadioReportDataTable.Columns.Add("NullRankCheck", GetType(Integer), GridColumn.FieldName & " Is Null")

                        SortString = "NullRankCheck ASC, " & GridColumn.FieldName & " ASC"

                        Exit For

                    End If

                Next

                For Each GridColumn In DaypartBands.FirstOrDefault.Columns

                    If GridColumn.FieldName.StartsWith("Rank") = False Then

                        SortString += ", " & GridColumn.FieldName & " DESC"

                    End If

                Next

            End If

            _ViewModel.SpotRadioReportDataTable.DefaultView.Sort = SortString

            BandedDataGridViewSpotRadioResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False

            BandedDataGridViewSpotRadioResults.CurrentView.ViewCaption = _ViewModel.SelectedResearchCriteria.CriteriaName & " (Ranker)"
            BandedDataGridViewSpotRadioResults.DataSource = _ViewModel.SpotRadioReportDataTable.DefaultView.ToTable

            If BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            BandedDataGridViewSpotRadioResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotRadioResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioResults)

        End Sub
        Private Sub SetupSpotRadioTrendDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim IntabInfoGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewSpotRadioResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotRadioResults.ClearGridCustomization()
            BandedDataGridViewSpotRadioResults.AutoUpdateViewCaption = False

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                CopyrightGridBand.Caption = Strings.Trim(Replace(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Copyright, "Copyright", "Copyright ©")) & ", " & _ViewModel.SpotRadioResearchResultList.FirstOrDefault.CopyrightMarketBooks

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " EASTLAN RESOURCES"

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Add(CopyrightGridBand)

            IntabInfoGridBand = CopyrightGridBand.Children.AddBand("")
            IntabInfoGridBand.Name = "IntabInfo"

            If _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                If _ViewModel.SpotRadioResearchResultList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.BookCount = 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0) & "* Warning: Estimates may be unstable due to low sample size."

                ElseIf _ViewModel.SpotRadioResearchResultList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.BookCount > 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0) & "* Warning: One or more of the books averaged are less than Nielsen standard and considered unstable."

                Else

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.Intab, 0)

                End If

            End If

            IntabInfoGridBand.OptionsBand.AllowMove = False

            BlankGridBand = IntabInfoGridBand.Children.AddBand("")

            If _ViewModel.SpotRadioResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                BlankGridBand.Caption = SpotRadioGetGeography() & "/" & _ViewModel.SpotRadioResearchResultList.FirstOrDefault.Demographic & Space(1) & _ViewModel.SpotRadioResearchResultList.FirstOrDefault.Daypart & Space(1) &
                    If(String.IsNullOrWhiteSpace(_ViewModel.SpotRadioResearchResultList.FirstOrDefault.QualitativeName), SpotRadioGetListeningType(), _ViewModel.SpotRadioResearchResultList.FirstOrDefault.QualitativeName & Space(1) & SpotRadioGetListeningType())

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioResults.ClearDatasource(_ViewModel.SpotRadioReportDataTable.Clone)

            BandedDataGridViewSpotRadioResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFormat.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFrequency.ToString OrElse
                        GridColumn.FieldName = "MetricName" Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString Then

                        GridColumn.Caption = "Station"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFormat.ToString Then

                        GridColumn.Caption = "Format"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationFrequency.ToString Then

                        GridColumn.Caption = "Frequency"

                    ElseIf GridColumn.FieldName = "MetricName" Then

                        GridColumn.Caption = "Metric"

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("BookMetric") Then

                    If _ViewModel.SpotRadioResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioResearchResultList.Count > 0 Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        GridColumn.Caption = (From Entity In _ViewModel.SpotRadioResearchResultList
                                              Where Entity.BookID = Mid(GridColumn.FieldName, 11)
                                              Select Entity.Books).FirstOrDefault.Replace(", ", vbCrLf)

                        BlankGridBand.Columns.Add(GridColumn)

                    End If

                End If

            Next

            BandedDataGridViewSpotRadioResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            BandedDataGridViewSpotRadioResults.CurrentView.ViewCaption = _ViewModel.SelectedResearchCriteria.CriteriaName & " (Trend)"
            BandedDataGridViewSpotRadioResults.DataSource = _ViewModel.SpotRadioReportDataTable.DefaultView.ToTable

            If BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            BandedDataGridViewSpotRadioResults.OptionsBehavior.Editable = False

            If _ViewModel.SpotRadioReportDataTable.Rows.Count > 0 AndAlso BandedDataGridViewSpotRadioResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString) IsNot Nothing Then

                BandedDataGridViewSpotRadioResults.CurrentView.ClearSorting()
                BandedDataGridViewSpotRadioResults.CurrentView.BeginSort()
                BandedDataGridViewSpotRadioResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchResult.Properties.StationName.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                BandedDataGridViewSpotRadioResults.CurrentView.EndSort()

            End If

            BandedDataGridViewSpotRadioResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioResults)

        End Sub
        Private Sub SetupSpotRadioAudienceCompositionDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim IntabInfoGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DisplayByBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DisplayByBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim MainDemographicDisplayByBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SortString As String = Nothing

            BandedDataGridViewSpotRadioResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotRadioResults.ClearGridCustomization()
            BandedDataGridViewSpotRadioResults.AutoUpdateViewCaption = False

            DisplayByBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If _ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 Then

                CopyrightGridBand.Caption = Strings.Trim(Replace(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Copyright, "Copyright", "Copyright ©")) & ", " & _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.CopyrightMarketBooks

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            ElseIf _ViewModel.SelectedResearchCriteria.Source = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " EASTLAN RESOURCES"

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioResults.CurrentView.Bands.Add(CopyrightGridBand)

            IntabInfoGridBand = CopyrightGridBand.Children.AddBand("")
            IntabInfoGridBand.Name = "IntabInfo"

            If _ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 Then

                If _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.BookCount = 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Intab, 0) & "* Warning: Estimates may be unstable due to low sample size."

                ElseIf _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.IntabFlag AndAlso _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.BookCount > 1 Then

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Intab, 0) & "* Warning: One or more of the books averaged are less than Nielsen standard and considered unstable."

                Else

                    IntabInfoGridBand.Caption = "Population: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Population, 0) & " / Intab: " & FormatNumber(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Intab, 0)

                End If

            End If

            IntabInfoGridBand.OptionsBand.AllowMove = False

            BlankGridBand = IntabInfoGridBand.Children.AddBand("")

            If _ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 Then

                BlankGridBand.Caption = SpotRadioGetGeography() & " / " & _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Daypart

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            If _ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 Then

                MainDemographicDisplayByBand = IntabInfoGridBand.Children.AddBand(_ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Demographic)
                MainDemographicDisplayByBand.Tag = _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.Demographic
                MainDemographicDisplayByBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                MainDemographicDisplayByBand.AppearanceHeader.Options.UseTextOptions = True
                MainDemographicDisplayByBand.OptionsBand.FixedWidth = True
                MainDemographicDisplayByBand.OptionsBand.AllowMove = False

                DisplayByBands.Add(MainDemographicDisplayByBand)

            End If

            If _ViewModel.SelectedResearchCriteria.DisplayByValue = AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.GenderAge Then

                For Each ResearchResult In (From Entity In _ViewModel.SpotRadioAudienceCompositionList
                                            Select Entity.DisplayBy, Entity.AgeFrom).OrderBy(Function(Entity) Entity.DisplayBy).ThenBy(Function(Entity) Entity.AgeFrom.GetValueOrDefault(0)).Distinct.ToList

                    DisplayByBand = IntabInfoGridBand.Children.AddBand(ResearchResult.DisplayBy)
                    DisplayByBand.Tag = ResearchResult.DisplayBy
                    DisplayByBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    DisplayByBand.AppearanceHeader.Options.UseTextOptions = True
                    DisplayByBand.OptionsBand.FixedWidth = True
                    DisplayByBand.OptionsBand.AllowMove = False

                    DisplayByBands.Add(DisplayByBand)

                Next

            Else

                For Each ResearchResult In (From Entity In _ViewModel.SpotRadioAudienceCompositionList
                                            Select Entity.DisplayBy, Entity.AgeFrom).OrderBy(Function(Entity) Entity.AgeFrom.GetValueOrDefault(0)).ThenBy(Function(Entity) Entity.DisplayBy).Distinct.ToList

                    DisplayByBand = IntabInfoGridBand.Children.AddBand(ResearchResult.DisplayBy)
                    DisplayByBand.Tag = ResearchResult.DisplayBy
                    DisplayByBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    DisplayByBand.AppearanceHeader.Options.UseTextOptions = True
                    DisplayByBand.OptionsBand.FixedWidth = True
                    DisplayByBand.OptionsBand.AllowMove = False

                    DisplayByBands.Add(DisplayByBand)

                Next

            End If

            BandedDataGridViewSpotRadioResults.ClearDatasource(_ViewModel.SpotRadioReportDataTable.Clone)

            BandedDataGridViewSpotRadioResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationFormat.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationFrequency.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.Rank.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationName.ToString Then

                        GridColumn.Caption = "Station"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationFormat.ToString Then

                        GridColumn.Caption = "Format"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.StationFrequency.ToString Then

                        GridColumn.Caption = "Frequency"

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.TotalAQH.ToString AndAlso
                        _ViewModel.SelectedMetricList.Where(Function(M) M.ID = AdvantageFramework.Database.Entities.MediaMetricID.AQH).Any Then

                    GridColumn.Caption = "AQH (00)"

                    If MainDemographicDisplayByBand IsNot Nothing Then

                        MainDemographicDisplayByBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.TotalCume.ToString AndAlso
                        _ViewModel.SelectedMetricList.Where(Function(M) M.ID = AdvantageFramework.Database.Entities.MediaMetricID.Cume).Any Then

                    GridColumn.Caption = "Cume (00)"

                    If MainDemographicDisplayByBand IsNot Nothing Then

                        MainDemographicDisplayByBand.Columns.Add(GridColumn)

                    End If

                ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition.Properties.TotalExclusiveCume.ToString AndAlso
                        _ViewModel.SelectedMetricList.Where(Function(M) M.ID = AdvantageFramework.Database.Entities.MediaMetricID.ExclusiveCume).Any Then

                    GridColumn.Caption = "Exclusive Cume (00)"

                    If MainDemographicDisplayByBand IsNot Nothing Then

                        MainDemographicDisplayByBand.Columns.Add(GridColumn)

                    End If

                End If

            Next

            For Each DisplayByBand In DisplayByBands

                For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                    If GridColumn.FieldName.EndsWith(DisplayByBand.Tag) AndAlso Not GridColumn.FieldName.StartsWith("Display") Then

                        DisplayByBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("AQHPercent") Then

                            GridColumn.Caption = "AQH %"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("AQH") Then

                            GridColumn.Caption = "AQH (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("CumePercent") Then

                            'GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.CUME)
                            GridColumn.Caption = "Cume %"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Cume") Then

                            'GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.CUME)
                            GridColumn.Caption = "Cume (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ExclusiveCumePercent") Then

                            'GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.ECUME)
                            GridColumn.Caption = "Exclusive Cume %"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ExclusiveCume") Then

                            'GridColumn.Visible = CUMEVisibility(_ViewModel, GridColumn.FieldName, CumeType.ECUME)
                            GridColumn.Caption = "Exclusive Cume (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        End If

                    End If

                Next

            Next

            If _ViewModel.SpotRadioReportDataTable.Rows.Count > 0 Then

                For Each GridColumn In BandedDataGridViewSpotRadioResults.Columns

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        _ViewModel.SpotRadioReportDataTable.Columns.Add("NullRankCheck", GetType(Integer), GridColumn.FieldName & " Is Null")

                        SortString = "NullRankCheck ASC, " & GridColumn.FieldName & " ASC"

                        Exit For

                    End If

                Next

                For Each GridColumn In DisplayByBands.FirstOrDefault.Columns

                    If GridColumn.FieldName.StartsWith("Rank") = False Then

                        SortString += ", " & GridColumn.FieldName & " DESC"

                    End If

                Next

            End If

            _ViewModel.SpotRadioReportDataTable.DefaultView.Sort = SortString

            BandedDataGridViewSpotRadioResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False

            BandedDataGridViewSpotRadioResults.CurrentView.ViewCaption = _ViewModel.SelectedResearchCriteria.CriteriaName & " (Audience Composition)"
            BandedDataGridViewSpotRadioResults.DataSource = _ViewModel.SpotRadioReportDataTable.DefaultView.ToTable

            If BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill") IsNot Nothing Then

                BandedDataGridViewSpotRadioResults.CurrentView.Columns("IsSpill").ColumnEdit = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemCheckBox(False, GetType(Boolean))

            End If

            BandedDataGridViewSpotRadioResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotRadioResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioResults)

        End Sub
        Private Sub EndSorting(sender As Object, e As EventArgs)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedGridView).Tag = "T" Then

                For Each GridColumn In BandedDataGridViewSpotTVResults.CurrentView.SortedColumns

                    GridColumn.BestFit()

                Next

            ElseIf DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.BandedGridView).Tag = "R" Then

                For Each GridColumn In BandedDataGridViewSpotRadioResults.CurrentView.SortedColumns

                    GridColumn.BestFit()

                Next

            End If

        End Sub
        Private Sub AddNavigatorCustomButtons(ByRef DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, ImageCollection As DevExpress.Utils.ImageCollection)

            'objects
            Dim Button As DevExpress.XtraEditors.NavigatorCustomButton = Nothing

            Button = DataGridView.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = True
            Button.Visible = True
            Button.Hint = "Move Up"
            Button.ImageIndex = ImageCollection.Images.Count - 2

            Button = DataGridView.EmbeddedNavigator.Buttons.CustomButtons.Add()
            Button.Tag = DevExpress.XtraEditors.NavigatorButtonType.Custom
            Button.Enabled = True
            Button.Visible = True
            Button.Hint = "Move Down"
            Button.ImageIndex = ImageCollection.Images.Count - 1

        End Sub
        Private Sub RepositoryItemGridLookUpEdit_PopUp(sender As Object, e As EventArgs)

            If _ViewModel.SelectedResearchCriteria.ReportType <> AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                If DataGridViewSpotRadio_Dayparts.CurrentView.FocusedRowHandle < 0 Then

                    DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ActiveFilterString = "IsStandard = True"

                Else

                    DirectCast(sender, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.ActiveFilterString = ""

                End If

            End If

        End Sub
        Private Sub ResizeRadioWarning()

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) AndAlso TabControlSpotRadio_ResearchCriteria.SelectedTab.Equals(TabItemSpotRadio_Results) Then

                If (_ViewModel.SpotRadioResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioResearchResultList.Count > 0 AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.ShowFootNote) OrElse
                        (_ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 AndAlso _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.ShowFootNote) Then

                    LabelSpotRadioResults_Footer.Text = AdvantageFramework.DTO.Media.ConstNielsenRadioFooter
                    LabelSpotRadioResults_Footer.Visible = True
                    BandedDataGridViewSpotRadioResults.Height = TabControlPanelSpotRadioResults_Results.Height - LabelSpotRadioResults_Footer.Height - 50

                ElseIf (_ViewModel.SpotRadioResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioResearchResultList.Count > 0 AndAlso _ViewModel.SpotRadioResearchResultList.FirstOrDefault.ShowDiaryFootNote) OrElse
                    (_ViewModel.SpotRadioAudienceCompositionList IsNot Nothing AndAlso _ViewModel.SpotRadioAudienceCompositionList.Count > 0 AndAlso _ViewModel.SpotRadioAudienceCompositionList.FirstOrDefault.ShowDiaryFootNote) Then

                    LabelSpotRadioResults_Footer.Text = AdvantageFramework.DTO.Media.ConstNielsenRadioDiaryFooter
                    LabelSpotRadioResults_Footer.Visible = True
                    BandedDataGridViewSpotRadioResults.Height = TabControlPanelSpotRadioResults_Results.Height - LabelSpotRadioResults_Footer.Height - 50

                Else

                    LabelSpotRadioResults_Footer.Visible = False
                    BandedDataGridViewSpotRadioResults.Height = TabControlPanelSpotRadioResults_Results.Height - 42

                End If

            End If

        End Sub
        Private Sub ResizeTVWarning()

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) AndAlso TabControlSpotTV_ResearchCriteria.SelectedTab.Equals(TabItemSpotTV_Results) Then

                If (_ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 AndAlso
                        _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso
                        _ViewModel.SpotTVResearchResultList.Where(Function(Entity) Entity.ShowIntabWarning).Any) Then

                    LabelSpotTVResults_Footer.Visible = True
                    BandedDataGridViewSpotTVResults.Height = TabControlPanelSpotTVResults_Results.Height - LabelSpotTVResults_Footer.Height - 50

                ElseIf (_ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 AndAlso
                        _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso
                        _ViewModel.SpotTVResearchResultList.Where(Function(Entity) Entity.ComscoreMeetsDemoThreshold = False OrElse Entity.ComscoreMeetsHighQualityDemoThreshold = False).Any) Then

                    LabelSpotTVResults_Footer.Visible = True
                    LabelSpotTVResults_Footer.Text = AdvantageFramework.DTO.Media.ConstComscoreTVFooter
                    BandedDataGridViewSpotTVResults.Height = TabControlPanelSpotTVResults_Results.Height - LabelSpotTVResults_Footer.Height - 50

                Else

                    LabelSpotTVResults_Footer.Visible = False
                    BandedDataGridViewSpotTVResults.Height = TabControlPanelSpotTVResults_Results.Height - 42

                End If

            End If

        End Sub
        Private Sub LoadTVDashboardDataSource()

            If DashboardViewerTVDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerTVDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerTVDashboard_Dashboard.Dashboard.DataSources.Add(_ViewModel.SpotTVResearchResultList)

                Else

                    DashboardViewerTVDashboard_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.SpotTVResearchResultList

                End If

                DashboardViewerTVDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Sub LoadTVDashboard(ForceReload As Boolean)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If DashboardViewerTVDashboard_Dashboard.Dashboard Is Nothing OrElse ForceReload Then

                If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                    DashboardViewerTVDashboard_Dashboard.LoadDashboard(MemoryStream)

                Else

                    If AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TV IsNot Nothing AndAlso AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TV.Length > 0 Then

                        MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TV)

                        DashboardViewerTVDashboard_Dashboard.LoadDashboard(MemoryStream)

                    End If

                End If

            End If

        End Sub
        Private Sub LoadRadioDashboardDataSource()

            If DashboardViewerRadioDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerRadioDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerRadioDashboard_Dashboard.Dashboard.DataSources.Add(_ViewModel.SpotRadioResearchResultList)

                Else

                    DashboardViewerRadioDashboard_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.SpotRadioResearchResultList

                End If

                DashboardViewerRadioDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Sub LoadRadioDashboard(ForceReload As Boolean)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If DashboardViewerRadioDashboard_Dashboard.Dashboard Is Nothing OrElse ForceReload Then

                If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                    DashboardViewerRadioDashboard_Dashboard.LoadDashboard(MemoryStream)

                Else

                    If AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_Radio IsNot Nothing AndAlso AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_Radio.Length > 0 Then

                        MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_Radio)

                        DashboardViewerRadioDashboard_Dashboard.LoadDashboard(MemoryStream)

                    End If

                End If

            End If

        End Sub
        Private Sub SelectAdjacentRow(DataGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView, RowHandle As Integer)

            If DataGridView.CurrentView.RowCount > 0 Then

                DataGridView.CurrentView.BeginSelection()

                DataGridView.CurrentView.ClearSelection()

                RowHandle = If(RowHandle = 0, 0, RowHandle - 1)

                DataGridView.CurrentView.SelectRow(RowHandle)
                DataGridView.CurrentView.FocusedRowHandle = RowHandle

                DataGridView.CurrentView.EndSelection()

            End If

        End Sub
        Private Sub ShowOrHideDemographicsColumns(DatGridView As AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView)

            If _ViewModel IsNot Nothing AndAlso _ViewModel.SpotTVSelectedResearchCriteria IsNot Nothing Then

                If DatGridView.Columns(AdvantageFramework.DTO.Media.SpotTV.Demographic.Properties.Group.ToString) IsNot Nothing Then

                    DatGridView.Columns(AdvantageFramework.DTO.Media.SpotTV.Demographic.Properties.Group.ToString).Visible = Not (_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen)

                End If

                If DatGridView.Columns(AdvantageFramework.DTO.Media.SpotTV.Demographic.Properties.Category.ToString) IsNot Nothing Then

                    DatGridView.Columns(AdvantageFramework.DTO.Media.SpotTV.Demographic.Properties.Category.ToString).Visible = Not (_ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen)

                End If

            End If

        End Sub
        Private Sub LoadRadioCountyDashboard(ForceReload As Boolean)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If DashboardViewerRadioCountyDashboard_Dashboard.Dashboard Is Nothing OrElse ForceReload Then

                If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                    DashboardViewerRadioCountyDashboard_Dashboard.LoadDashboard(MemoryStream)

                Else

                    If AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_RadioCounty IsNot Nothing AndAlso AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_RadioCounty.Length > 0 Then

                        MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_RadioCounty)

                        DashboardViewerRadioCountyDashboard_Dashboard.LoadDashboard(MemoryStream)

                    End If

                End If

            End If

        End Sub
        Private Sub LoadRadioCountyDashboardDataSource()

            If DashboardViewerRadioCountyDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerRadioCountyDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerRadioCountyDashboard_Dashboard.Dashboard.DataSources.Add(_ViewModel.SpotRadioCountyResearchResultList)

                Else

                    DashboardViewerRadioCountyDashboard_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.SpotRadioCountyResearchResultList

                End If

                DashboardViewerRadioCountyDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Sub LoadTVPuertoRicoDashboardDataSource()

            If DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard IsNot Nothing Then

                If DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard.DataSources.Count = 0 Then

                    DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard.DataSources.Add(_ViewModel.SpotTVPuertoRicoResearchResultList)

                Else

                    DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard.DataSources(0).Data = _ViewModel.SpotTVPuertoRicoResearchResultList

                End If

                DashboardViewerTVPuertoRicoDashboard_Dashboard.Refresh()

            End If

        End Sub
        Private Sub LoadTVPuertoRicoDashboard(ForceReload As Boolean)

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard Is Nothing OrElse ForceReload Then

                If _ViewModel.Dashboard IsNot Nothing AndAlso _ViewModel.Dashboard.Layout IsNot Nothing AndAlso _ViewModel.Dashboard.Layout.Length > 0 Then

                    MemoryStream = New System.IO.MemoryStream(_ViewModel.Dashboard.Layout)

                    DashboardViewerTVPuertoRicoDashboard_Dashboard.LoadDashboard(MemoryStream)

                Else

                    If AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TVPuertoRico IsNot Nothing AndAlso AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TVPuertoRico.Length > 0 Then

                        MemoryStream = New System.IO.MemoryStream(AdvantageFramework.My.Resources.BroadcastResearchToolDashboard_TVPuertoRico)

                        DashboardViewerTVPuertoRicoDashboard_Dashboard.LoadDashboard(MemoryStream)

                    End If

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim BroadcastResearchToolForm As Media.Presentation.BroadcastResearchToolForm = Nothing

            BroadcastResearchToolForm = New Media.Presentation.BroadcastResearchToolForm

            BroadcastResearchToolForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastResearchToolForm_BeforeFormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Clearing

        End Sub
        Private Sub BroadcastResearchToolForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler RadioButtonSpotRadioGeography_DMA.CheckedChangedEx, AddressOf GeographyChanged
            RemoveHandler RadioButtonSpotRadioGeography_Metro.CheckedChangedEx, AddressOf GeographyChanged
            RemoveHandler RadioButtonSpotRadioGeography_TSA.CheckedChangedEx, AddressOf GeographyChanged

            RemoveHandler RadioButtonSpotRadioListeningType_Car.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            RemoveHandler RadioButtonSpotRadioListeningType_Home.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            RemoveHandler RadioButtonSpotRadioListeningType_OutOfHome.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            RemoveHandler RadioButtonSpotRadioListeningType_Total.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            RemoveHandler RadioButtonSpotRadioListeningType_Work.CheckedChangedEx, AddressOf ListeningTypeChangedEx

            RemoveHandler RadioButtonSpotRadioEthnicity_All.CheckedChangedEx, AddressOf EthnicityChanged
            RemoveHandler RadioButtonSpotRadioEthnicity_Black.CheckedChangedEx, AddressOf EthnicityChanged
            RemoveHandler RadioButtonSpotRadioEthnicity_Hispanic.CheckedChangedEx, AddressOf EthnicityChanged

            RemoveHandler RadioButtonNationalBreakout_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalBreakout_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalBreakout_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalCorrections_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalCorrections_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalCorrections_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalOvernights_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalOvernights_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalOvernights_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalPremieres_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalPremieres_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalPremieres_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalRepeats_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalRepeats_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalRepeats_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalSpecials_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalSpecials_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            RemoveHandler RadioButtonNationalSpecials_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged

        End Sub
        Private Sub BroadcastResearchToolForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub BroadcastResearchToolForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ImageCollection As DevExpress.Utils.ImageCollection = Nothing

            AddHandler RadioButtonSpotRadioGeography_DMA.CheckedChangedEx, AddressOf GeographyChanged
            AddHandler RadioButtonSpotRadioGeography_Metro.CheckedChangedEx, AddressOf GeographyChanged
            AddHandler RadioButtonSpotRadioGeography_TSA.CheckedChangedEx, AddressOf GeographyChanged

            AddHandler RadioButtonSpotRadioListeningType_Car.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            AddHandler RadioButtonSpotRadioListeningType_Home.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            AddHandler RadioButtonSpotRadioListeningType_OutOfHome.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            AddHandler RadioButtonSpotRadioListeningType_Total.CheckedChangedEx, AddressOf ListeningTypeChangedEx
            AddHandler RadioButtonSpotRadioListeningType_Work.CheckedChangedEx, AddressOf ListeningTypeChangedEx

            AddHandler RadioButtonSpotRadioEthnicity_All.CheckedChangedEx, AddressOf EthnicityChanged
            AddHandler RadioButtonSpotRadioEthnicity_Black.CheckedChangedEx, AddressOf EthnicityChanged
            AddHandler RadioButtonSpotRadioEthnicity_Hispanic.CheckedChangedEx, AddressOf EthnicityChanged

            AddHandler RadioButtonNationalBreakout_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalBreakout_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalBreakout_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalCorrections_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalCorrections_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalCorrections_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalOvernights_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalOvernights_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalOvernights_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalPremieres_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalPremieres_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalPremieres_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalRepeats_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalRepeats_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalRepeats_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalSpecials_Exclude.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalSpecials_Ignore.CheckedChangedEx, AddressOf NationalRadioButtonChanged
            AddHandler RadioButtonNationalSpecials_Only.CheckedChangedEx, AddressOf NationalRadioButtonChanged

            BandedDataGridViewSpotTVResults.CurrentView.Tag = "T"
            BandedDataGridViewSpotRadioResults.CurrentView.Tag = "R"

            BandedDataGridViewSpotTVResults.OptionsCustomization.AllowColumnMoving = False
            BandedDataGridViewSpotTVResults.OptionsCustomization.AllowQuickHideColumns = False

            BandedDataGridViewSpotRadioResults.OptionsCustomization.AllowColumnMoving = False
            BandedDataGridViewSpotRadioResults.OptionsCustomization.AllowQuickHideColumns = False

            BandedDataGridViewSpotRadioCountyResults.OptionsCustomization.AllowColumnMoving = False
            BandedDataGridViewSpotRadioCountyResults.OptionsCustomization.AllowQuickHideColumns = False

            BandedDataGridViewNationalResults.OptionsCustomization.AllowColumnMoving = False
            BandedDataGridViewNationalResults.OptionsCustomization.AllowQuickHideColumns = False

            BandedDataGridViewSpotTVPuertoRicoResults.OptionsCustomization.AllowColumnMoving = False
            BandedDataGridViewSpotTVPuertoRicoResults.OptionsCustomization.AllowQuickHideColumns = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_Books.Image = AdvantageFramework.My.Resources.NielsenBookImage

            ButtonItemDemographics_Up.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemDemographics_Down.Image = AdvantageFramework.My.Resources.DownImage

            ButtonItemMetrics_Up.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemMetrics_Down.Image = AdvantageFramework.My.Resources.DownImage

            ButtonItemDashboard_Edit.Image = AdvantageFramework.My.Resources.EditImage

            ButtonItemReportView_ByAge.Image = AdvantageFramework.My.Resources.AgeImage
            ButtonItemReportView_ByAgeGender.Image = AdvantageFramework.My.Resources.GenderAndAgeImage
            ButtonItemReportView_ByGender.Image = AdvantageFramework.My.Resources.GenderImage
            ButtonItemReportView_ByGenderAge.Image = AdvantageFramework.My.Resources.GenderAndAgeImage

            DataGridViewSpotTV_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewSpotTV_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewSpotTV_UserCriterias.MultiSelect = False

            DataGridViewSpotTV_AvailableStations.OptionsBehavior.Editable = False
            DataGridViewSpotTV_SelectedStations.OptionsBehavior.Editable = False

            DataGridViewSpotTV_DayTimes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewSpotTV_DayTimes.UseEmbeddedNavigator = True

            ShareHPUTBookControl_Books.DataGridViewControl_ShareHPUTBook.UseEmbeddedNavigator = True

            DataGridViewSpotTV_AvailableDemographics.OptionsBehavior.Editable = False
            DataGridViewSpotTV_SelectedDemographics.OptionsBehavior.Editable = False

            DataGridViewSpotTV_AvailableMetrics.OptionsBehavior.Editable = False
            DataGridViewSpotTV_SelectedMetrics.OptionsBehavior.Editable = False

            DataGridViewSpotTV_SelectedDemographics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotTV_SelectedDemographics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotTV_SelectedDemographics.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewSpotTV_SelectedMetrics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotTV_SelectedMetrics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotTV_SelectedMetrics.CurrentView.OptionsCustomization.AllowSort = False


            SearchableComboBoxSpotRadio_Market.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.MarketCode)
            SearchableComboBoxSpotRadioMarket_Demographic.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.MediaDemoID)
            SearchableComboBoxSpotRadioMarket_Qualitative.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.NielsenRadioQualitativeID)

            DataGridViewSpotRadio_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewSpotRadio_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewSpotRadio_UserCriterias.MultiSelect = False

            DataGridViewSpotRadio_AvailableStations.OptionsBehavior.Editable = False
            DataGridViewSpotRadio_SelectedStations.OptionsBehavior.Editable = False

            DataGridViewSpotRadio_Books.UseEmbeddedNavigator = True
            DataGridViewSpotRadio_Books.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotRadio_Books.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotRadio_Books.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewSpotRadio_Dayparts.UseEmbeddedNavigator = True
            DataGridViewSpotRadio_Dayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewSpotRadio_Dayparts.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotRadio_Dayparts.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotRadio_Dayparts.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewSpotRadio_AvailableMetrics.OptionsBehavior.Editable = False
            DataGridViewSpotRadio_SelectedMetrics.OptionsBehavior.Editable = False

            DataGridViewSpotRadio_SelectedMetrics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotRadio_SelectedMetrics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotRadio_SelectedMetrics.CurrentView.OptionsCustomization.AllowSort = False

            ImageCollection = DataGridViewSpotRadio_Dayparts.EmbeddedNavigator.Buttons.DefaultImageList
            ImageCollection.AddImage(AdvantageFramework.My.Resources.UpImage)
            ImageCollection.AddImage(AdvantageFramework.My.Resources.DownImage)

            AddNavigatorCustomButtons(DataGridViewSpotRadio_Dayparts, ImageCollection)

            LabelSpotRadioResults_Footer.AutoSize = True

            LabelSpotTVResults_Footer.Text = AdvantageFramework.DTO.Media.ConstNielsenTVFooter
            LabelSpotTVResults_Footer.AutoSize = True

            NumericInputSpotTVMarketStation_MaximumRank.SetPropertySettings(AdvantageFramework.Database.Entities.MediaSpotTVResearch.Properties.MaxRank)

            DataGridViewSpotRadioCounty_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewSpotRadioCounty_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewSpotRadioCounty_UserCriterias.MultiSelect = False

            NumericInputSpotRadioMarket_MaxRank.SetPropertySettings(AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.MaxRank)

            DataGridViewSpotRadioCounty_Years.UseEmbeddedNavigator = True
            DataGridViewSpotRadioCounty_Years.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotRadioCounty_Years.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotRadioCounty_Years.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewSpotRadioCounty_AvailableStations.OptionsBehavior.Editable = False
            DataGridViewSpotRadioCounty_SelectedStations.OptionsBehavior.Editable = False

            DataGridViewSpotRadioCounty_AvailableMetrics.OptionsBehavior.Editable = False
            DataGridViewSpotRadioCounty_SelectedMetrics.OptionsBehavior.Editable = False

            SearchableComboBoxCounty_County.HideValueMemberColumn = True

            DateEditNationalDates_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast
            DateEditNationalDates_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.Broadcast

            DataGridViewNational_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewNational_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewNational_UserCriterias.MultiSelect = False

            DataGridViewNational_DemographicsAvailable.OptionsBehavior.Editable = False
            DataGridViewNational_DemographicsAvailable.ShowSelectDeselectAllButtons = True

            DataGridViewNational_DemographicsSelected.OptionsBehavior.Editable = False
            DataGridViewNational_DemographicsSelected.ShowSelectDeselectAllButtons = True

            DataGridViewNational_MetricsAvailable.OptionsBehavior.Editable = False
            DataGridViewNational_MetricsAvailable.ShowSelectDeselectAllButtons = True

            DataGridViewNational_MetricsSelected.OptionsBehavior.Editable = False
            DataGridViewNational_MetricsSelected.ShowSelectDeselectAllButtons = True

            DataGridViewNational_NetworksAvailable.OptionsBehavior.Editable = False
            DataGridViewNational_NetworksAvailable.ShowSelectDeselectAllButtons = True

            DataGridViewNational_NetworksSelected.OptionsBehavior.Editable = False
            DataGridViewNational_NetworksSelected.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTVPuertoRico_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewSpotTVPuertoRico_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewSpotTVPuertoRico_UserCriterias.MultiSelect = False

            DataGridViewSpotTVPuertoRico_AvailableStations.OptionsBehavior.Editable = False
            DataGridViewSpotTVPuertoRico_SelectedStations.OptionsBehavior.Editable = False

            DataGridViewSpotTVPuertoRico_DayTimes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewSpotTVPuertoRico_DayTimes.UseEmbeddedNavigator = True

            DataGridViewSpotTVPuertoRico_AvailableDemographics.OptionsBehavior.Editable = False
            DataGridViewSpotTVPuertoRico_SelectedDemographics.OptionsBehavior.Editable = False

            DataGridViewSpotTVPuertoRico_AvailableMetrics.OptionsBehavior.Editable = False
            DataGridViewSpotTVPuertoRico_SelectedMetrics.OptionsBehavior.Editable = False

            DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.OptionsCustomization.AllowSort = False

            LabelSpotTVPuertoRicoResults_Footer.Text = AdvantageFramework.DTO.Media.ConstNielsenTVFooter
            LabelSpotTVPuertoRicoResults_Footer.AutoSize = True

        End Sub
        Private Sub BroadcastResearchToolForm_Resize(sender As Object, e As EventArgs) Handles Me.Resize

            ResizeRadioWarning()
            ResizeTVWarning()
            ResizeTVPuertoRicoWarning()

        End Sub
        Private Sub BroadcastResearchToolForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            SearchableComboBoxSpotRadioMarket_Demographic.HideValueMemberColumn = True
            SearchableComboBoxCounty_Demographic.HideValueMemberColumn = True

            DataGridViewSpotTV_AvailableStations.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTV_SelectedStations.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTV_AvailableDemographics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTV_SelectedDemographics.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTV_AvailableMetrics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTV_SelectedMetrics.ShowSelectDeselectAllButtons = True

            CheckBoxSpotTVOptions_DominantProgramming.Enabled = False

            DataGridViewSpotRadio_AvailableMetrics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotRadio_SelectedMetrics.ShowSelectDeselectAllButtons = True

            DataGridViewSpotRadio_AvailableStations.ShowSelectDeselectAllButtons = True
            DataGridViewSpotRadio_SelectedStations.ShowSelectDeselectAllButtons = True

            DataGridViewSpotRadioCounty_AvailableMetrics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotRadioCounty_SelectedMetrics.ShowSelectDeselectAllButtons = True

            DataGridViewSpotRadioCounty_AvailableStations.ShowSelectDeselectAllButtons = True
            DataGridViewSpotRadioCounty_SelectedStations.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTVPuertoRico_AvailableStations.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTVPuertoRico_SelectedStations.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTVPuertoRico_AvailableDemographics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTVPuertoRico_SelectedDemographics.ShowSelectDeselectAllButtons = True

            DataGridViewSpotTVPuertoRico_AvailableMetrics.ShowSelectDeselectAllButtons = True
            DataGridViewSpotTVPuertoRico_SelectedMetrics.ShowSelectDeselectAllButtons = True

            Me.ShowWaitForm("Validating data sources...")

            _Controller = New AdvantageFramework.Controller.Media.BroadcastResearchController(Me.Session)

            If AdvantageFramework.Security.IsMediaToolUser(Me.Session, Me.Session.User.ID) Then

                TabItemTabs_SpotRadioCountyTab.Visible = Me.Session.IsNielsenSetup
                TabItemTabs_NationalTab.Visible = Me.Session.IsNationalSetup

                If Me.Session.IsNielsenSetup OrElse Me.Session.IsComscoreSetup Then

                    LoadSpotTVViewModel(Nothing, True)

                ElseIf Me.Session.IsEastlanSetup Then

                    LoadSpotRadioViewModel(Nothing, True)

                    TabItemTabs_SpotTVTab.Visible = False

                ElseIf Me.Session.IsNielsenPuertoRicoSetup Then

                    LoadSpotTVPuertoRicoViewModel(Nothing, True)

                ElseIf Me.Session.IsNationalSetup Then

                    LoadNationalViewModel(Nothing, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Could not validate license\database.  Please check integration settings.")
                    Me.Close()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("You must be a Media Tools User to access this module.")
                Me.Close()

            End If

            Me.CloseWaitForm()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            If CheckForUnsavedChanges() Then

                If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                    TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

                End If

                AddCriteria()

            End If

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            'objects
            Dim ResearchID As Integer = 0

            If CheckForUnsavedChanges() Then

                If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                    If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTV, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTV, _ViewModel.SpotTVSelectedResearchCriteria.ID, ResearchID) = Windows.Forms.DialogResult.OK Then

                        LoadSpotTVViewModel(ResearchID, True)

                        TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

                    End If

                ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                    If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadio, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadio, _ViewModel.SelectedResearchCriteria.ID, ResearchID) = Windows.Forms.DialogResult.OK Then

                        LoadSpotRadioViewModel(ResearchID, True)

                        TabControlSpotRadio_ResearchCriteria.SelectedTab = TabItemSpotRadio_MarketBooks

                    End If

                ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                    If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotRadioCounty, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotRadioCounty, _ViewModel.SpotRadioCountySelectedResearchCriteria.ID, ResearchID) = Windows.Forms.DialogResult.OK Then

                        LoadSpotRadioCountyViewModel(ResearchID, True)

                        TabControlSpotRadioCounty_ResearchCriteria.SelectedTab = TabItemSpotRadioCounty_MarketBooks

                    End If

                ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                    If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotNational, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotNational, _ViewModel.NationalSelectedResearchCriteria.ID, ResearchID) = Windows.Forms.DialogResult.OK Then

                        LoadNationalViewModel(ResearchID, True)

                        TabControlNational_ResearchCriteria.SelectedTab = TabItemNational_ReportType

                    End If

                ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                    If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(AdvantageFramework.DTO.Media.Methods.ResearchCriteriaTypes.SpotTVPuertoRico, AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ResearchType.SpotTVPuertoRico, _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID, ResearchID) = Windows.Forms.DialogResult.OK Then

                        LoadSpotTVPuertoRicoViewModel(ResearchID, True)

                        TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab = TabItemSpotTVPuertoRico_ReportTypeStations

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV AndAlso AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.SpotTVSelectedResearchCriteria.CriteriaName & "'?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.DeleteSpotTV(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadSpotTVViewModel(Nothing, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio AndAlso AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.SelectedResearchCriteria.CriteriaName & "'?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.DeleteSpotRadio(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadSpotRadioViewModel(Nothing, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty AndAlso AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.SpotRadioCountySelectedResearchCriteria.CriteriaName & "'?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.SpotRadioCounty_Delete(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadSpotRadioCountyViewModel(Nothing, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National AndAlso AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.NationalSelectedResearchCriteria.CriteriaName & "'?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.National_Delete(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadNationalViewModel(Nothing, True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico AndAlso AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.CriteriaName & "'?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.DeleteSpotTVPuertoRico(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadSpotTVPuertoRicoViewModel(Nothing, True)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Edit.Click

            EditCriteria()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                BandedDataGridViewSpotTVResults.CurrentView.OptionsPrint.AutoWidth = False

                If DataGridViewSpotTV_UserCriterias.HasASelectedRow Then

                    BandedDataGridViewSpotTVResults.Print(DefaultLookAndFeel.LookAndFeel, DirectCast(DataGridViewSpotTV_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).CriteriaName, _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                Else

                    BandedDataGridViewSpotTVResults.Print(DefaultLookAndFeel.LookAndFeel, "Spot TV Research", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                BandedDataGridViewSpotRadioResults.CurrentView.OptionsPrint.AutoWidth = False

                If DataGridViewSpotRadio_UserCriterias.HasASelectedRow Then

                    BandedDataGridViewSpotRadioResults.Print(DefaultLookAndFeel.LookAndFeel, DirectCast(DataGridViewSpotRadio_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).CriteriaName, _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                Else

                    BandedDataGridViewSpotRadioResults.Print(DefaultLookAndFeel.LookAndFeel, "Spot Radio Research", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                BandedDataGridViewSpotRadioCountyResults.CurrentView.OptionsPrint.AutoWidth = False

                If DataGridViewSpotRadioCounty_UserCriterias.HasASelectedRow Then

                    BandedDataGridViewSpotRadioCountyResults.Print(DefaultLookAndFeel.LookAndFeel, DirectCast(DataGridViewSpotRadioCounty_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).CriteriaName, _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                Else

                    BandedDataGridViewSpotRadioCountyResults.Print(DefaultLookAndFeel.LookAndFeel, "Spot Radio County Research", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                BandedDataGridViewNationalResults.CurrentView.OptionsPrint.AutoWidth = False

                If DataGridViewNational_UserCriterias.HasASelectedRow Then

                    BandedDataGridViewNationalResults.Print(DefaultLookAndFeel.LookAndFeel, DirectCast(DataGridViewNational_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.National.ResearchCriteria).CriteriaName, _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                Else

                    BandedDataGridViewNationalResults.Print(DefaultLookAndFeel.LookAndFeel, "National Research", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.OptionsPrint.AutoWidth = False

                If DataGridViewSpotTVPuertoRico_UserCriterias.HasASelectedRow Then

                    BandedDataGridViewSpotTVPuertoRicoResults.Print(DefaultLookAndFeel.LookAndFeel, DirectCast(DataGridViewSpotTVPuertoRico_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).CriteriaName, _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                Else

                    BandedDataGridViewSpotTVPuertoRicoResults.Print(DefaultLookAndFeel.LookAndFeel, "Spot TV Puerto Rico Research", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                SaveSpotTV()

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                SaveSpotRadio()

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                SaveSpotRadioCounty()

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                SaveNational()

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                SaveSpotTVPuertoRico()

            End If

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim InfoMessage As String = Nothing

            Me.ShowWaitForm("Processing...")

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                SaveSpotTVViewModel()

                Try

                    If _Controller.RunSpotTVReport(_ViewModel, ErrorMessage, InfoMessage) Then

                        LoadTVDashboard(False)

                        LoadTVDashboardDataSource()

                        RefreshSpotTVTab()

                        TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_Results

                        TabControlResults_TVResults.SelectedTab = TabItemTVResults_TVDataTab

                        ResizeTVWarning()

                        If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Catch ex As Exception

                    If Not String.IsNullOrWhiteSpace(ex.Message) AndAlso ex.Message.ToUpper.Contains("COMSCORE") Then

                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)

                    End If

                End Try

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                SaveSpotRadioViewModel()

                If _Controller.RunSpotRadioReport(_ViewModel, ErrorMessage, InfoMessage) Then

                    LoadRadioDashboard(False)

                    LoadRadioDashboardDataSource()

                    RefreshSpotRadioTab()

                    TabControlSpotRadio_ResearchCriteria.SelectedTab = TabItemSpotRadio_Results

                    TabControlResults_RadioResults.SelectedTab = TabItemRadioResults_RadioDataTab

                    ResizeRadioWarning()

                    If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                SaveSpotRadioCountyViewModel()

                If _Controller.SpotRadioCounty_RunReport(_ViewModel, ErrorMessage, InfoMessage) Then

                    LoadRadioCountyDashboard(False)

                    LoadRadioCountyDashboardDataSource()

                    RefreshSpotRadioCountyTab(True, True)

                    TabControlSpotRadioCounty_ResearchCriteria.SelectedTab = TabItemSpotRadioCounty_Results

                    TabControlResults_RadioCountyResults.SelectedTab = TabItemRadioCountyResults_RadioCountyDataTab

                    If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                SaveNationalViewModel()

                If _Controller.National_RunReport(_ViewModel, ErrorMessage, InfoMessage) Then

                    'LoadNationalDashboard(False)

                    'LoadNationalDashboardDataSource()

                    RefreshNationalTab(True)

                    TabControlNational_ResearchCriteria.SelectedTab = TabItemNational_Results

                    TabControlResults_NationalResults.SelectedTab = TabItemNationalResults_Data

                    If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico AndAlso SaveSpotTVPuertoRicoViewModel() Then

                Try

                    If _Controller.RunSpotTVPuertoRicoReport(_ViewModel, ErrorMessage, InfoMessage) Then

                        LoadTVPuertoRicoDashboard(False)

                        LoadTVPuertoRicoDashboardDataSource()

                        RefreshSpotTVPuertoRicoTab()

                        TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab = TabItemSpotTVPuertoRico_Results

                        TabControlResults_TVPuertoRicoResults.SelectedTab = TabItemTVPuertoRicoResults_TVDataTab

                        ResizeTVPuertoRicoWarning()

                        If String.IsNullOrWhiteSpace(InfoMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show(InfoMessage)

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                Catch ex As Exception

                    If Not String.IsNullOrWhiteSpace(ex.Message) AndAlso ex.Message.ToUpper.Contains("COMSCORE") Then

                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)

                    End If

                End Try

            End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                    LoadSpotTVViewModel(_ViewModel.SpotTVSelectedResearchCriteria.ID, True)

                ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) Then

                    LoadSpotRadioViewModel(_ViewModel.SelectedResearchCriteria.ID, True)

                End If

            End If

        End Sub
        Private Sub ButtonItemMetrics_Down_Click(sender As Object, e As EventArgs) Handles ButtonItemMetrics_Down.Click

            'objects
            Dim SelectedID As Integer = 0

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                SelectedID = DirectCast(DataGridViewSpotTV_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotTV(_ViewModel, DataGridViewSpotTV_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotTVTab()

                DataGridViewSpotTV_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                SelectedID = DirectCast(DataGridViewSpotRadio_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotRadio(_ViewModel, DataGridViewSpotRadio_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotRadioTab()

                DataGridViewSpotRadio_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                SelectedID = DirectCast(DataGridViewSpotRadioCounty_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.SpotRadioCounty_MoveMetric(_ViewModel, DataGridViewSpotRadioCounty_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotRadioCountyTab(True)

                DataGridViewSpotRadioCounty_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                SelectedID = DirectCast(DataGridViewNational_MetricsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.National_MoveMetric(_ViewModel, DataGridViewNational_MetricsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshNationalTab(True)

                DataGridViewNational_MetricsSelected.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                SelectedID = DirectCast(DataGridViewSpotTVPuertoRico_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotTVPuertoRico(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotTVPuertoRicoTab()

                DataGridViewSpotTVPuertoRico_SelectedMetrics.SelectRow(0, SelectedID)

            End If

        End Sub
        Private Sub ButtonItemMetrics_Up_Click(sender As Object, e As EventArgs) Handles ButtonItemMetrics_Up.Click

            'objects
            Dim SelectedID As Integer = 0

            If _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTV Then

                SelectedID = DirectCast(DataGridViewSpotTV_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotTV(_ViewModel, DataGridViewSpotTV_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotTVTab()

                DataGridViewSpotTV_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadio Then

                SelectedID = DirectCast(DataGridViewSpotRadio_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotRadio(_ViewModel, DataGridViewSpotRadio_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotRadioTab()

                DataGridViewSpotRadio_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotRadioCounty Then

                SelectedID = DirectCast(DataGridViewSpotRadioCounty_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.SpotRadioCounty_MoveMetric(_ViewModel, DataGridViewSpotRadioCounty_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotRadioCountyTab(True)

                DataGridViewSpotRadioCounty_SelectedMetrics.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.National Then

                SelectedID = DirectCast(DataGridViewNational_MetricsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.National_MoveMetric(_ViewModel, DataGridViewNational_MetricsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshNationalTab(True)

                DataGridViewNational_MetricsSelected.SelectRow(0, SelectedID)

            ElseIf _ViewModel.SelectedResearchTab = AdvantageFramework.ViewModels.Media.BroadcastResearchViewModel.ResearchTab.SpotTVPuertoRico Then

                SelectedID = DirectCast(DataGridViewSpotTVPuertoRico_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.Metric).ID

                _Controller.MoveMetricSpotTVPuertoRico(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotTVPuertoRicoTab()

                DataGridViewSpotTVPuertoRico_SelectedMetrics.SelectRow(0, SelectedID)

            End If

        End Sub
        Private Sub TabControlForm_Tabs_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_Tabs.SelectedTabChanged

            If Me.FormShown Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                If e.NewTab.Equals(TabItemTabs_SpotTVTab) Then

                    If DataGridViewSpotTV_UserCriterias.HasASelectedRow Then

                        LoadSpotTVViewModel(DirectCast(DataGridViewSpotTV_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID, False)

                    Else

                        LoadSpotTVViewModel(Nothing, True)

                    End If

                ElseIf e.NewTab.Equals(TabItemTabs_SpotRadioTab) Then

                    If DataGridViewSpotRadio_UserCriterias.HasASelectedRow Then

                        LoadSpotRadioViewModel(DirectCast(DataGridViewSpotRadio_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID, False)

                    Else

                        LoadSpotRadioViewModel(Nothing, True)

                    End If

                ElseIf e.NewTab.Equals(TabItemTabs_SpotRadioCountyTab) Then

                    If DataGridViewSpotRadioCounty_UserCriterias.HasASelectedRow Then

                        LoadSpotRadioCountyViewModel(DirectCast(DataGridViewSpotRadioCounty_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID, False)

                    Else

                        LoadSpotRadioCountyViewModel(Nothing, True)

                    End If

                ElseIf e.NewTab.Equals(TabItemTabs_NationalTab) Then

                    If DataGridViewNational_UserCriterias.HasASelectedRow Then

                        LoadNationalViewModel(DirectCast(DataGridViewNational_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID, False)

                    Else

                        LoadNationalViewModel(Nothing, True)

                    End If

                ElseIf e.NewTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) Then

                    If DataGridViewNational_UserCriterias.HasASelectedRow Then

                        LoadSpotTVPuertoRicoViewModel(DirectCast(DataGridViewNational_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID, False)

                    Else

                        LoadSpotTVPuertoRicoViewModel(Nothing, True)

                    End If

                End If

                EnableOrDisableActions()

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub TabControlForm_Tabs_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_Tabs.SelectedTabChanging

            If Me.FormShown Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemDashboard_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemDashboard_Edit.Click

            'objects
            Dim DashboardLayout() As Byte = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                MemoryStream = New System.IO.MemoryStream

                If DashboardViewerTVDashboard_Dashboard.Dashboard IsNot Nothing Then

                    DashboardViewerTVDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                    DashboardLayout = MemoryStream.ToArray
                    MemoryStream.Flush()
                    MemoryStream.Close()

                    If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.SpotTVResearchResultList, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                        _Controller.SaveTVDashboard(_ViewModel, DashboardLayout)

                        LoadTVDashboard(True)

                    End If

                    LoadTVDashboardDataSource()

                End If

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) Then

                MemoryStream = New System.IO.MemoryStream

                If DashboardViewerRadioDashboard_Dashboard.Dashboard IsNot Nothing Then

                    DashboardViewerRadioDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                    DashboardLayout = MemoryStream.ToArray
                    MemoryStream.Flush()
                    MemoryStream.Close()

                    If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.SpotRadioResearchResultList, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                        MemoryStream = New System.IO.MemoryStream

                        MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                        MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                        _Controller.SaveRadioDashboard(_ViewModel, DashboardLayout)

                        LoadRadioDashboard(True)

                    End If

                    LoadRadioDashboardDataSource()

                End If

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioCountyTab) Then

                MemoryStream = New System.IO.MemoryStream

                If DashboardViewerRadioCountyDashboard_Dashboard.Dashboard IsNot Nothing Then

                    DashboardViewerRadioCountyDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                    DashboardLayout = MemoryStream.ToArray
                    MemoryStream.Flush()
                    MemoryStream.Close()

                    If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.SpotRadioCountyResearchResultList, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                        MemoryStream = New System.IO.MemoryStream

                        MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                        MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                        _Controller.SaveRadioCountyDashboard(_ViewModel, DashboardLayout)

                        LoadRadioCountyDashboard(True)

                    End If

                    LoadRadioCountyDashboardDataSource()

                End If

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) Then

                MemoryStream = New System.IO.MemoryStream

                If DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard IsNot Nothing Then

                    DashboardViewerTVPuertoRicoDashboard_Dashboard.Dashboard.SaveToXml(MemoryStream)

                    DashboardLayout = MemoryStream.ToArray
                    MemoryStream.Flush()
                    MemoryStream.Close()

                    If AdvantageFramework.Reporting.Presentation.DashboardEditorForm.ShowFormDialog(Me.Session, _ViewModel.SpotTVPuertoRicoResearchResultList, DashboardLayout, False) = Windows.Forms.DialogResult.OK Then

                        MemoryStream = New System.IO.MemoryStream

                        MemoryStream.Write(DashboardLayout, 0, DashboardLayout.Length)
                        MemoryStream.Seek(0, IO.SeekOrigin.Begin)

                        _Controller.SaveTVPuertoRicoDashboard(_ViewModel, DashboardLayout)

                        LoadTVPuertoRicoDashboard(True)

                    End If

                    LoadTVPuertoRicoDashboardDataSource()

                End If

            End If

        End Sub

#Region " Spot TV "

        Private Sub BandedDataGridViewSpotTVResults_CreateReportFooterAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles BandedDataGridViewSpotTVResults.CreateReportFooterAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing
            Dim RectangleF As System.Drawing.RectangleF = Nothing

            If (_ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 AndAlso
                    _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen AndAlso
                    _ViewModel.SpotTVResearchResultList.Where(Function(Entity) Entity.ShowIntabWarning).Any) Then

                Try

                    TextBrick = New DevExpress.XtraPrinting.TextBrick
                    TextBrick.Text = AdvantageFramework.DTO.Media.ConstNielsenTVFooter
                    TextBrick.BackColor = System.Drawing.Color.White
                    TextBrick.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
                    TextBrick.VertAlignment = DevExpress.Utils.VertAlignment.Top
                    TextBrick.StringFormat = DevExpress.XtraPrinting.BrickStringFormat.Create(DevExpress.XtraPrinting.TextAlignment.TopLeft, True)

                    SizeF = e.Graph.MeasureString(AdvantageFramework.DTO.Media.ConstNielsenTVFooter, CInt(Math.Ceiling(e.Graph.ClientPageSize.Width)), TextBrick.StringFormat.Value)

                    RectangleF = New System.Drawing.RectangleF(0, 0, SizeF.Width, SizeF.Height)
                    RectangleF.Height = RectangleF.Height + 20

                    e.Graph.DrawBrick(TextBrick, RectangleF)

                Catch ex As Exception

                End Try

            ElseIf (_ViewModel.SpotTVResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVResearchResultList.Count > 0 AndAlso
                    _ViewModel.SpotTVSelectedResearchCriteria.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore AndAlso
                    _ViewModel.SpotTVResearchResultList.Where(Function(Entity) Entity.ComscoreMeetsDemoThreshold = False OrElse Entity.ComscoreMeetsHighQualityDemoThreshold = False).Any) Then

                Try

                    TextBrick = New DevExpress.XtraPrinting.TextBrick
                    TextBrick.Text = AdvantageFramework.DTO.Media.ConstComscoreTVFooter
                    TextBrick.BackColor = System.Drawing.Color.White
                    TextBrick.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
                    TextBrick.VertAlignment = DevExpress.Utils.VertAlignment.Top
                    TextBrick.StringFormat = DevExpress.XtraPrinting.BrickStringFormat.Create(DevExpress.XtraPrinting.TextAlignment.TopLeft, True)

                    SizeF = e.Graph.MeasureString(AdvantageFramework.DTO.Media.ConstComscoreTVFooter, CInt(Math.Ceiling(e.Graph.ClientPageSize.Width)), TextBrick.StringFormat.Value)

                    RectangleF = New System.Drawing.RectangleF(0, 0, SizeF.Width, SizeF.Height)
                    RectangleF.Height = RectangleF.Height + 20

                    e.Graph.DrawBrick(TextBrick, RectangleF)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewSpotTVResults.CustomColumnDisplayTextEvent

            Dim DataRow As System.Data.DataRow = Nothing

            If e.Column.FieldName.StartsWith(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Intab.ToString) AndAlso Not e.Value.Equals(System.DBNull.Value) Then

                DataRow = BandedDataGridViewSpotTVResults.GetRowDataBoundItem(BandedDataGridViewSpotTVResults.CurrentView.GetRowHandle(e.ListSourceRowIndex)).row

                If DataRow.Item(Replace(e.Column.FieldName, "Intab", "ShowIntabWarning")) Then

                    e.DisplayText = FormatNumber(e.Value, 0).ToString & " *"

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedDataGridViewSpotTVResults.CustomColumnSortEvent

            'objects
            Dim Value1 As Decimal? = Nothing
            Dim Value2 As Decimal? = Nothing

            Try

                If e.Value1 Is Nothing Then

                    Value1 = CDec(1000000000)

                Else

                    Value1 = CDec(e.Value1)

                End If

                If e.Value2 Is Nothing Then

                    Value2 = CDec(1000000000)

                Else

                    Value2 = CDec(e.Value2)

                End If

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_CustomDrawBandHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs) Handles BandedDataGridViewSpotTVResults.CustomDrawBandHeaderEvent

            'objects
            Dim Font As System.Drawing.Font = Nothing

            If e.Band IsNot Nothing AndAlso e.Band.Name = "Copyright" Then

                Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Regular)
                e.Appearance.Font = Font
                e.Appearance.ForeColor = System.Drawing.Color.Red

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_EndGroupingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotTVResults.EndGroupingEvent

            'objects
            Dim AssignGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            BandedDataGridViewSpotTVResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVResults.OptionsView.ShowGroupPanel = (BandedDataGridViewSpotTVResults.CurrentView.GroupedColumns.Count > 0)

            For Each column In BandedDataGridViewSpotTVResults.CurrentView.Columns

                If BandedDataGridViewSpotTVResults.CurrentView.GroupedColumns.Contains(column) Then

                    column.OwnerBand = Nothing

                Else

                    AssignGridBand = TryCast(column.Tag, DevExpress.XtraGrid.Views.BandedGrid.GridBand)

                    If AssignGridBand IsNot Nothing Then

                        column.OwnerBand = AssignGridBand

                    End If

                End If

            Next

            BandedDataGridViewSpotTVResults.CurrentView.ExpandAllGroups()

            BandedDataGridViewSpotTVResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVResults)

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_EndSortingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotTVResults.EndSortingEvent

            BestFitBands(BandedDataGridViewSpotTVResults)

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewSpotTVResults.PopupMenuShowingEvent

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                BlankGridBand = BandedDataGridViewSpotTVResults.CurrentView.Bands.Where(Function(Band) Band.Tag = "BLANK").FirstOrDefault

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.ToUpper = "COLUMN/BAND CHOOSER" OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = False

                    End If

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) OrElse
                                MenuItem.Caption.ToUpper.Equals("SHOW GROUP BY BOX") Then

                        MenuItem.Visible = False

                    End If

                    If BlankGridBand IsNot Nothing AndAlso Not BlankGridBand.Columns.Contains(e.HitInfo.Column) Then

                        If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) Then

                            MenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedDataGridViewSpotTVResults.RowCellStyleEvent

            If e.Column.FieldName.StartsWith("Rank") Then

                If BandedDataGridViewSpotTVResults.CurrentView.GetRow(e.RowHandle) IsNot Nothing AndAlso e.CellValue.Equals(System.DBNull.Value) = False AndAlso
                        _ViewModel.SpotTVReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVReportDataTable.Select(e.Column.FieldName & " = " & e.CellValue).Count > 1 Then

                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Italic)

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVResults_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles BandedDataGridViewSpotTVResults.RowDoubleClickEvent

            'objects
            Dim BandedGridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = Nothing
            Dim BandedGridHitInfo As DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo = Nothing
            Dim IDs() As String = Nothing
            Dim StationCode As Integer = 0
            Dim ColumnHandle As Integer = 0

            If (_ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook OrElse
                    _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation) Then

                BandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

                If BandedGridView IsNot Nothing Then

                    BandedGridHitInfo = BandedGridView.CalcHitInfo(e.Location)

                    If BandedGridHitInfo IsNot Nothing AndAlso BandedGridHitInfo.InRowCell AndAlso BandedGridHitInfo.Column.FieldName.StartsWith(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.ProgramName.ToString) AndAlso
                            DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(BandedGridView.Columns(BandedGridHitInfo.Column.FieldName).ColumnHandle).ToString = "Various" Then

                        If _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook Then

                            StationCode = Replace(BandedGridHitInfo.Column.FieldName, AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.ProgramName.ToString, "")

                        End If

                        For Each Column As DevExpress.XtraGrid.Columns.GridColumn In BandedGridView.Columns

                            If _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook AndAlso Column.FieldName = "BookIDDaytimeID" Then

                                ColumnHandle = Column.ColumnHandle
                                Exit For

                            ElseIf _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation AndAlso Column.FieldName = "BookIDDaytimeID" & BandedGridHitInfo.Band.Tag Then

                                ColumnHandle = Column.ColumnHandle
                                Exit For

                            ElseIf _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation AndAlso Column.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.StationCode.ToString Then

                                StationCode = DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(Column.ColumnHandle).ToString

                            End If

                        Next

                        If ColumnHandle <> 0 Then

                            IDs = DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(ColumnHandle).ToString.Split("|")

                            If IDs.Length = 2 Then

                                _Controller.GetProgramDetails(_ViewModel, StationCode, IDs(0), IDs(1))

                                If Not String.IsNullOrWhiteSpace(_ViewModel.ProgramWeeks) Then

                                    AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.ProgramWeeks, Title:="Week - Program")

                                End If

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemDemographics_Down_Click(sender As Object, e As EventArgs) Handles ButtonItemDemographics_Down.Click

            Dim SelectedID As Integer = 0

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                SelectedID = DirectCast(DataGridViewSpotTV_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTV.Demographic).ID

                _Controller.MoveDemographic(_ViewModel, DataGridViewSpotTV_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotTVTab()

                DataGridViewSpotTV_SelectedDemographics.SelectRow(0, SelectedID)

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) Then

                SelectedID = DirectCast(DataGridViewNational_DemographicsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.National.Demographic).ID

                _Controller.National_MoveDemographic(_ViewModel, DataGridViewNational_DemographicsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshNationalTab(False)

                DataGridViewNational_DemographicsSelected.SelectRow(0, SelectedID)

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) Then

                SelectedID = DirectCast(DataGridViewSpotTVPuertoRico_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ID

                _Controller.MoveDemographic(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                RefreshSpotTVPuertoRicoTab()

                DataGridViewSpotTVPuertoRico_SelectedDemographics.SelectRow(0, SelectedID)

            End If

        End Sub
        Private Sub ButtonItemDemographics_Up_Click(sender As Object, e As EventArgs) Handles ButtonItemDemographics_Up.Click

            Dim SelectedID As Integer = 0

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                SelectedID = DirectCast(DataGridViewSpotTV_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTV.Demographic).ID

                _Controller.MoveDemographic(_ViewModel, DataGridViewSpotTV_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotTVTab()

                DataGridViewSpotTV_SelectedDemographics.SelectRow(0, SelectedID)

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) Then

                SelectedID = DirectCast(DataGridViewNational_DemographicsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.National.Demographic).ID

                _Controller.National_MoveDemographic(_ViewModel, DataGridViewNational_DemographicsSelected.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshNationalTab(False)

                DataGridViewNational_DemographicsSelected.SelectRow(0, SelectedID)

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) Then

                SelectedID = DirectCast(DataGridViewSpotTVPuertoRico_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ID

                _Controller.MoveDemographic(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedDemographics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                RefreshSpotTVPuertoRicoTab()

                DataGridViewSpotTVPuertoRico_SelectedDemographics.SelectRow(0, SelectedID)

            End If

        End Sub
        Private Sub ButtonSpotTVDemographics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVDemographics_AddToSelected.Click

            _Controller.AddToSelectedDemographics(_ViewModel, DataGridViewSpotTV_AvailableDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Demographic).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub ButtonSpotTVDemographics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVDemographics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedDemographics(_ViewModel, DataGridViewSpotTV_SelectedDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Demographic).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub ButtonSpotTVMetrics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVMetrics_AddToSelected.Click

            _Controller.AddToSelectedSpotTVMetrics(_ViewModel, DataGridViewSpotTV_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub ButtonSpotTVMetrics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVMetrics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotTVMetrics(_ViewModel, DataGridViewSpotTV_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub ButtonSpotTVStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVStation_AddToSelected.Click

            _Controller.AddToSelectedSpotTVStations(_ViewModel, DataGridViewSpotTV_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Station).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub ButtonSpotTVStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVStation_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotTVStations(_ViewModel, DataGridViewSpotTV_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Station).ToList)

            RefreshSpotTVTab()

        End Sub
        Private Sub CheckBoxSpotTVOptions_DominantProgramming_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotTVOptions_DominantProgramming.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetDominantProgramming(_ViewModel, CheckBoxSpotTVOptions_DominantProgramming.Checked)

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub CheckBoxSpotTVOptions_GroupByDaysTimes_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotTVOptions_GroupByDaysTimes.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetGroupByDaysTimesSpotTV(_ViewModel, CheckBoxSpotTVOptions_GroupByDaysTimes.Checked)

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub CheckBoxSpotTVOptions_ShowProgramName_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotTVOptions_ShowProgramName.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetShowProgramName(_ViewModel, CheckBoxSpotTVOptions_ShowProgramName.Checked)

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub CheckBoxSpotTVOptions_ShowSpill_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotTVOptions_ShowSpill.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetShowSpillSpotTV(_ViewModel, CheckBoxSpotTVOptions_ShowSpill.Checked)

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub ComboBoxSpotTVMarketStation_ReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxSpotTVMarketStation_ReportType.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxSpotTVMarketStation_ReportType.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetReportType(_ViewModel, ComboBoxSpotTVMarketStation_ReportType.GetSelectedValue)

                If String.IsNullOrWhiteSpace(_ViewModel.SpotTVSelectedResearchCriteria.MarketCode) = False Then

                    LoadSpotTVBooksTab(True)

                End If

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub ComboBoxSpotTVMarketStation_Source_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxSpotTVMarketStation_Source.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxSpotTVMarketStation_Source.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetTVSource(_ViewModel, ComboBoxSpotTVMarketStation_Source.GetSelectedValue)

                LoadSpotTVBooksTab(True, True)

                RefreshSpotTVTab()

                DataGridViewSpotTV_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableMetrics.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotTV_DayTimes.CellValueChangedEvent

            _Controller.DayTimeCellChanged(_ViewModel)

            RefreshSpotTVTab(False)

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_CustomRowCellEditForEditingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewSpotTV_DayTimes.CustomRowCellEditForEditingEvent

            'objects
            Dim RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = Nothing
            Dim RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.Days.ToString Then

                RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit

                AddHandler RepositoryItemTextEdit.Enter, AddressOf RepositoryItem_Enter

                e.RepositoryItem = RepositoryItemTextEdit

            End If

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSpotTV_DayTimes.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSpotTV_DayTimes.CancelNewItemRow()

                        _Controller.DayTimeCancelNewItemRow(_ViewModel)

                        RefreshSpotTVTab()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        _Controller.DeleteSelectedDayTimes(_ViewModel, DataGridViewSpotTV_DayTimes.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList)

                        RefreshSpotTVTab()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotTV_DayTimes.InitNewRowEvent

            DirectCast(DataGridViewSpotTV_DayTimes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.DaysAndTime).BroadcastType = DTO.DaysAndTime.BroadcastTypes.TV
            DirectCast(DataGridViewSpotTV_DayTimes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.DaysAndTime).IsUsing3rdPartyData = True

            _Controller.DayTimeInitNewRowEvent(_ViewModel)

            RefreshSpotTVTab(False)

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTV_DayTimes.SelectionChangedEvent

            _Controller.DayTimeSelectionChanged(_ViewModel, DataGridViewSpotTV_DayTimes.IsNewItemRow,
                                                DataGridViewSpotTV_DayTimes.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList)

            RefreshSpotTVTab(False)

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSpotTV_DayTimes.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewSpotTV_DayTimes.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                FocusedRow.BroadcastType = DTO.DaysAndTime.BroadcastTypes.TV

                ErrorText = _Controller.DayTimeValidateEntityProperty(FocusedRow, DataGridViewSpotTV_DayTimes.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewSpotTV_DayTimes.CurrentView.SetColumnError(DataGridViewSpotTV_DayTimes.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewSpotTV_DayTimes_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotTV_DayTimes.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.DayTimeValidateEntity(e.Row, e.Valid)

                If DataGridViewSpotTV_DayTimes.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewSpotTV_DayTimes.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        _Controller.DayTimeAddNewRowEvent(_ViewModel)

                        RefreshSpotTVTab(False)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotTV_AvailableDemographics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_AvailableDemographics.RowDoubleClickEvent

            _Controller.AddToSelectedDemographics(_ViewModel, DataGridViewSpotTV_AvailableDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Demographic).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_AvailableDemographics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_AvailableMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_AvailableMetrics.RowDoubleClickEvent

            _Controller.AddToSelectedSpotTVMetrics(_ViewModel, DataGridViewSpotTV_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_AvailableMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_AvailableStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_AvailableStations.RowDoubleClickEvent

            _Controller.AddToSelectedSpotTVStations(_ViewModel, DataGridViewSpotTV_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Station).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_AvailableStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_SelectedDemographics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_SelectedDemographics.RowDoubleClickEvent

            _Controller.RemoveFromSelectedDemographics(_ViewModel, DataGridViewSpotTV_SelectedDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Demographic).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_SelectedDemographics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_SelectedMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_SelectedMetrics.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotTVMetrics(_ViewModel, DataGridViewSpotTV_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_SelectedMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_SelectedStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTV_SelectedStations.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotTVStations(_ViewModel, DataGridViewSpotTV_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTV.Station).ToList)

            RefreshSpotTVTab()

            SelectAdjacentRow(DataGridViewSpotTV_SelectedStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTV_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewSpotTV_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewSpotTV_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewSpotTV_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSelectedSpotTVResearchCriteria(_ViewModel, DataGridViewSpotTV_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadSpotTVViewModel(DirectCast(DataGridViewSpotTV_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria).ID, False)

                TabItemSpotTV_Books.Tag = False

                LoadSpotTVBooksTab()

                TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewSpotTV_SelectedDemographics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTV_SelectedDemographics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewSpotTV_SelectedMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTV_SelectedMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxSpotTVMarketStation_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotTVMarketStation_Market.EditValueChanged

            TabItemSpotTV_Books.Tag = False

            If Me.FormShown AndAlso SearchableComboBoxSpotTVMarketStation_Market.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetTVAvailableStationsDemographicsMetrics(_ViewModel, SearchableComboBoxSpotTVMarketStation_Market.GetSelectedValue)

                RefreshSpotTVTab()

                DataGridViewSpotTV_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTV_AvailableMetrics.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub ShareHPUTBookControl_Books_ShareHPUTBookInitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ShareHPUTBookControl_Books.ShareHPUTBookInitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ShareHPUTBookControl_Books_ShareHPUTBookChanged() Handles ShareHPUTBookControl_Books.ShareHPUTBookChanged

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.ShareHPUTBooksChanged(_ViewModel)

                RefreshSpotTVTab()

            End If

        End Sub
        Private Sub ShareHPUTBookControl_Books_ShareHPUTBookSelectionChangedEvent(sender As Object, e As EventArgs) Handles ShareHPUTBookControl_Books.ShareHPUTBookSelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlSpotTV_ResearchCriteria_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlSpotTV_ResearchCriteria.SelectedTabChanging

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If e.NewTab.Equals(TabItemSpotTV_Books) Then

                    If Not _ViewModel.IsMarketSelected Then

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                        e.Cancel = True

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a market first.")

                        TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

                        Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                    Else

                        LoadSpotTVBooksTab()

                    End If

                ElseIf Not _ViewModel.IsMarketSelected Then

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                    e.Cancel = True

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a market first.")

                    TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

                    Me.FormAction = WinForm.Presentation.Methods.FormActions.None

                End If

            End If

        End Sub
        Private Sub TabControlSpotTV_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSpotTV_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub

#End Region

#Region " Spot Radio "

        Private Sub BandedDataGridViewSpotRadioResults_CreateReportFooterAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles BandedDataGridViewSpotRadioResults.CreateReportFooterAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing
            Dim RectangleF As System.Drawing.RectangleF = Nothing

            If LabelSpotRadioResults_Footer.Visible AndAlso String.IsNullOrWhiteSpace(LabelSpotRadioResults_Footer.Text) = False Then

                Try

                    TextBrick = New DevExpress.XtraPrinting.TextBrick
                    TextBrick.Text = LabelSpotRadioResults_Footer.Text
                    TextBrick.BackColor = System.Drawing.Color.White
                    TextBrick.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
                    TextBrick.VertAlignment = DevExpress.Utils.VertAlignment.Top
                    TextBrick.StringFormat = DevExpress.XtraPrinting.BrickStringFormat.Create(DevExpress.XtraPrinting.TextAlignment.TopLeft, True)

                    SizeF = e.Graph.MeasureString(LabelSpotRadioResults_Footer.Text, CInt(Math.Ceiling(e.Graph.ClientPageSize.Width)), TextBrick.StringFormat.Value)

                    RectangleF = New System.Drawing.RectangleF(0, 0, SizeF.Width, SizeF.Height)
                    RectangleF.Height = RectangleF.Height + 20

                    e.Graph.DrawBrick(TextBrick, RectangleF)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewSpotRadioResults.CustomColumnDisplayTextEvent

            'objects
            Dim MetricName As String = Nothing

            If _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.Trend AndAlso
                    e.Column.FieldName.StartsWith("BookMetric") AndAlso Not e.Value.Equals(System.DBNull.Value) Then

                MetricName = BandedDataGridViewSpotRadioResults.CurrentView.GetListSourceRowCellValue(e.ListSourceRowIndex, "MetricName")

                If MetricName = "AQH Rating" Then

                    e.DisplayText = FormatNumber(e.Value, 1,,, TriState.True)

                ElseIf MetricName = "AQH Share" Then

                    e.DisplayText = FormatNumber(e.Value, 1,,, TriState.True)

                ElseIf MetricName = "AQH (00)" Then

                    e.DisplayText = FormatNumber(e.Value, 0,,, TriState.True)

                ElseIf MetricName = "Cume Rating" Then

                    e.DisplayText = FormatNumber(e.Value, 1,,, TriState.True)

                ElseIf MetricName = "Cume (00)" Then

                    e.DisplayText = FormatNumber(e.Value, 0,,, TriState.True)

                ElseIf MetricName = "Exclusive Cume (00)" Then

                    e.DisplayText = FormatNumber(e.Value, 0,,, TriState.True)

                ElseIf MetricName = "PUR %" Then

                    e.DisplayText = FormatNumber(e.Value, 1,,, TriState.True)

                ElseIf MetricName = "PUR (00)" Then

                    e.DisplayText = FormatNumber(e.Value, 0,,, TriState.True)

                ElseIf MetricName = "Population (00)" Then

                    e.DisplayText = FormatNumber(e.Value, 0,,, TriState.True)

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedDataGridViewSpotRadioResults.CustomColumnSortEvent

            'objects
            Dim Value1 As Decimal? = Nothing
            Dim Value2 As Decimal? = Nothing

            Try

                If e.Value1 Is Nothing Then

                    Value1 = CDec(1000000000)

                Else

                    Value1 = CDec(e.Value1)

                End If

                If e.Value2 Is Nothing Then

                    Value2 = CDec(1000000000)

                Else

                    Value2 = CDec(e.Value2)

                End If

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_CustomDrawBandHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs) Handles BandedDataGridViewSpotRadioResults.CustomDrawBandHeaderEvent

            'objects
            Dim Font As System.Drawing.Font = Nothing

            If e.Band IsNot Nothing AndAlso e.Band.Name = "Copyright" Then

                Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Regular)
                e.Appearance.Font = Font
                e.Appearance.ForeColor = System.Drawing.Color.Red

            End If

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_EndGroupingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotRadioResults.EndGroupingEvent

            'objects
            Dim AssignGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            BandedDataGridViewSpotRadioResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioResults.OptionsView.ShowGroupPanel = (BandedDataGridViewSpotRadioResults.CurrentView.GroupedColumns.Count > 0)

            For Each column In BandedDataGridViewSpotRadioResults.CurrentView.Columns

                If BandedDataGridViewSpotRadioResults.CurrentView.GroupedColumns.Contains(column) Then

                    column.OwnerBand = Nothing

                Else

                    AssignGridBand = TryCast(column.Tag, DevExpress.XtraGrid.Views.BandedGrid.GridBand)

                    If AssignGridBand IsNot Nothing Then

                        column.OwnerBand = AssignGridBand

                    End If

                End If

            Next

            BandedDataGridViewSpotRadioResults.CurrentView.ExpandAllGroups()

            BandedDataGridViewSpotRadioResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioResults)

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_EndSortingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotRadioResults.EndSortingEvent

            BestFitBands(BandedDataGridViewSpotRadioResults)

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewSpotRadioResults.PopupMenuShowingEvent

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                BlankGridBand = BandedDataGridViewSpotRadioResults.CurrentView.Bands.Where(Function(Band) Band.Tag = "BLANK").FirstOrDefault

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.ToUpper = "COLUMN/BAND CHOOSER" OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = False

                    End If

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) OrElse
                                MenuItem.Caption.ToUpper.Equals("SHOW GROUP BY BOX") Then

                        MenuItem.Visible = False

                    End If

                    If BlankGridBand IsNot Nothing AndAlso Not BlankGridBand.Columns.Contains(e.HitInfo.Column) Then

                        If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) Then

                            MenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub BandedDataGridViewSpotRadioResults_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedDataGridViewSpotRadioResults.RowCellStyleEvent

            If e.Column.FieldName.StartsWith("Rank") Then

                If BandedDataGridViewSpotRadioResults.CurrentView.GetRow(e.RowHandle) IsNot Nothing AndAlso e.CellValue.Equals(System.DBNull.Value) = False AndAlso
                        _ViewModel.SpotRadioReportDataTable IsNot Nothing AndAlso _ViewModel.SpotRadioReportDataTable.Select(e.Column.FieldName & " = " & e.CellValue).Count > 1 Then

                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Italic)

                End If

            End If

        End Sub
        Private Sub ButtonItemReportView_ByAge_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemReportView_ByAge.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso ButtonItemReportView_ByAge.Checked Then

                _Controller.SetAudienceCompositionDisplayBy(_ViewModel, DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.Age)

                ButtonItemActions_Process_Click(sender, e)

            End If

        End Sub
        Private Sub ButtonItemReportView_ByAgeGender_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemReportView_ByAgeGender.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso ButtonItemReportView_ByAgeGender.Checked Then

                _Controller.SetAudienceCompositionDisplayBy(_ViewModel, DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.AgeGender)

                ButtonItemActions_Process_Click(sender, e)

            End If

        End Sub
        Private Sub ButtonItemReportView_ByGender_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemReportView_ByGender.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso ButtonItemReportView_ByGender.Checked Then

                _Controller.SetAudienceCompositionDisplayBy(_ViewModel, DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.Gender)

                ButtonItemActions_Process_Click(sender, e)

            End If

        End Sub
        Private Sub ButtonItemReportView_ByGenderAge_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemReportView_ByGenderAge.CheckedChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso ButtonItemReportView_ByGenderAge.Checked Then

                _Controller.SetAudienceCompositionDisplayBy(_ViewModel, DTO.Media.SpotRadio.ResearchCriteria.DisplayBy.GenderAge)

                ButtonItemActions_Process_Click(sender, e)

            End If

        End Sub
        Private Sub ButtonSpotRadioMetrics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioMetrics_AddToSelected.Click

            _Controller.AddToSelectedSpotRadioMetrics(_ViewModel, DataGridViewSpotRadio_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioTab()

        End Sub
        Private Sub ButtonSpotRadioMetrics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioMetrics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotRadioMetrics(_ViewModel, DataGridViewSpotRadio_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioTab()

        End Sub
        Private Sub ButtonSpotRadioStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioStation_AddToSelected.Click

            _Controller.AddToSelectedSpotRadioStations(_ViewModel, DataGridViewSpotRadio_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshSpotRadioTab()

        End Sub
        Private Sub ButtonSpotRadioStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioStation_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotRadioStations(_ViewModel, DataGridViewSpotRadio_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshSpotRadioTab()

        End Sub
        Private Sub CheckBoxSpotRadioOptions_ShowFormat_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotRadioOptions_ShowFormat.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetShowFormatSpotRadio(_ViewModel, CheckBoxSpotRadioOptions_ShowFormat.Checked)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub CheckBoxSpotRadioOptions_ShowFrequency_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotRadioOptions_ShowFrequency.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetShowFrequencySpotRadio(_ViewModel, CheckBoxSpotRadioOptions_ShowFrequency.Checked)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub CheckBoxSpotRadioOptions_ShowSpill_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotRadioOptions_ShowSpill.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetShowSpillSpotRadio(_ViewModel, CheckBoxSpotRadioOptions_ShowSpill.Checked)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub CheckBoxSpotRadioOptions_TotalListening_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSpotRadioOptions_TotalListening.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeTotalListeningSpotRadio(_ViewModel, CheckBoxSpotRadioOptions_TotalListening.Checked)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub ComboBoxSpotRadioMarketDemographic_ReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxSpotRadioMarketDemographic_ReportType.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxSpotRadioMarketDemographic_ReportType.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetRadioReportType(_ViewModel, ComboBoxSpotRadioMarketDemographic_ReportType.GetSelectedValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub ComboBoxSpotRadioMarket_Source_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxSpotRadioMarket_Source.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxSpotRadioMarket_Source.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetRadioSource(_ViewModel, ComboBoxSpotRadioMarket_Source.GetSelectedValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Books_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotRadio_Books.CellValueChangedEvent

            _Controller.BookCellChanged(_ViewModel, DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle), e.Column.FieldName, e.Value)

            RefreshSpotRadioTab(False)

        End Sub
        Private Sub DataGridViewSpotRadio_Books_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSpotRadio_Books.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSpotRadio_Books.CancelNewItemRow()

                        _Controller.BookCancelNewItemRow(_ViewModel)

                        RefreshSpotRadioTab()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        _Controller.DeleteSelectedBooks(_ViewModel, DataGridViewSpotRadio_Books.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList)

                        RefreshSpotRadioTab()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Books_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotRadio_Books.InitNewRowEvent

            _Controller.BookInitNewRowEvent(_ViewModel)

            RefreshSpotRadioTab(False)

        End Sub
        Private Sub DataGridViewSpotRadio_Books_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewSpotRadio_Books.QueryPopupNeedDatasourceEvent

            _ViewModel.NielsenRadioBookList = DataGridViewSpotRadio_Books.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList

            Datasource = _Controller.GetRepositoryNielsenRadioPeriods(_ViewModel, FieldName, DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle))

            OverrideDefaultDatasource = True

        End Sub
        Private Sub DataGridViewSpotRadio_Books_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewSpotRadio_Books.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID2.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID3.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID4.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID5.ToString Then

                Datasource = _ViewModel.NielsenRadioPeriodRepository

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Books_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadio_Books.SelectionChangedEvent

            _Controller.BookSelectionChanged(_ViewModel, DataGridViewSpotRadio_Books.IsNewItemRow,
                                             DataGridViewSpotRadio_Books.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList)

            RefreshSpotRadioTab(False)

        End Sub
        Private Sub DataGridViewSpotRadio_Books_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSpotRadio_Books.ShowingEditorEvent

            If String.IsNullOrWhiteSpace(_ViewModel.SelectedResearchCriteria.MarketCode) Then

                e.Cancel = True

            ElseIf DataGridViewSpotRadio_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString Then

                e.Cancel = (DataGridViewSpotRadio_Books.IsNewItemRow = False)

            ElseIf DataGridViewSpotRadio_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID2.ToString Then

                e.Cancel = DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).NielsenRadioPeriodID1.HasValue

            ElseIf DataGridViewSpotRadio_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID3.ToString Then

                e.Cancel = DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle) Is Nothing OrElse
                   Not DirectCast(DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).NielsenRadioPeriodID2.HasValue

            ElseIf DataGridViewSpotRadio_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID4.ToString Then

                e.Cancel = DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).NielsenRadioPeriodID3.HasValue

            ElseIf DataGridViewSpotRadio_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID5.ToString Then

                e.Cancel = DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadio_Books.CurrentView.GetRow(DataGridViewSpotRadio_Books.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).NielsenRadioPeriodID4.HasValue

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Books_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadio_Books.ShownEditorEvent

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewSpotRadio_Books.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewSpotRadio_Books.CurrentView.ActiveEditor

                If GridLookUpEdit.Properties.View.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.ID.ToString) IsNot Nothing Then

                    GridLookUpEdit.Properties.View.Columns(AdvantageFramework.DTO.Media.NielsenRadioPeriod.Properties.ID.ToString).Visible = False

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Books_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotRadio_Books.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateBook(_ViewModel, e.Row, e.Valid)

                If DataGridViewSpotRadio_Books.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        _Controller.BookAddNewRowEvent(_ViewModel)

                        RefreshSpotRadioTab(False)

                    Else

                        DataGridViewSpotRadio_Books.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotRadio_Dayparts.CellValueChangedEvent

            'objects
            Dim NielsenRadioDaypart As AdvantageFramework.DTO.Media.NielsenDaypart = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                NielsenRadioDaypart = DirectCast(DataGridViewSpotRadio_Dayparts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.NielsenDaypart)

                _Controller.DaypartCellChanged(_ViewModel, e.Value, NielsenRadioDaypart)

                DataGridViewSpotRadio_Dayparts.CurrentView.RefreshRow(e.RowHandle)

                RefreshSpotRadioTab(False)

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSpotRadio_Dayparts.EmbeddedNavigatorButtonClick

            'objects
            Dim SelectedID As Integer = 0

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSpotRadio_Dayparts.CancelNewItemRow()

                        _Controller.DaypartCancelNewItemRow(_ViewModel)

                        RefreshSpotRadioTab()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        _Controller.DeleteSelectedDayparts(_ViewModel, DataGridViewSpotRadio_Dayparts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList)

                        RefreshSpotRadioTab()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Custom

                        SelectedID = DirectCast(DataGridViewSpotRadio_Dayparts.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.NielsenDaypart).ID

                        If e.Button.Hint = "Move Up" Then

                            _Controller.MoveDaypart(_ViewModel, DataGridViewSpotRadio_Dayparts.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Up)

                        ElseIf e.Button.Hint = "Move Down" Then

                            _Controller.MoveDaypart(_ViewModel, DataGridViewSpotRadio_Dayparts.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.BroadcastResearchController.MoveItemDirection.Down)

                        End If

                        RefreshSpotRadioTab()

                        DataGridViewSpotRadio_Dayparts.SelectRow(0, SelectedID)

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotRadio_Dayparts.InitNewRowEvent

            _Controller.DaypartInitNewRowEvent(_ViewModel)

            RefreshSpotRadioTab(False)

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewSpotRadio_Dayparts.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                Datasource = _ViewModel.NielsenDaypartRepository

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewSpotRadio_Dayparts.QueryPopupNeedDatasourceEvent

            _ViewModel.NielsenDaypartList = DataGridViewSpotRadio_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList

            If _ViewModel.SelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioResearchReportType.AudienceComposition Then

                Datasource = _Controller.GetRepositoryNielsenRadioDayparts(_ViewModel, FieldName, DataGridViewSpotRadio_Dayparts.CurrentView.GetRow(DataGridViewSpotRadio_Dayparts.CurrentView.FocusedRowHandle), True)

            Else

                Datasource = _Controller.GetRepositoryNielsenRadioDayparts(_ViewModel, FieldName, DataGridViewSpotRadio_Dayparts.CurrentView.GetRow(DataGridViewSpotRadio_Dayparts.CurrentView.FocusedRowHandle), False)

            End If

            OverrideDefaultDatasource = True

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadio_Dayparts.SelectionChangedEvent

            _Controller.DaypartSelectionChanged(_ViewModel, DataGridViewSpotRadio_Dayparts.IsNewItemRow,
                                                DataGridViewSpotRadio_Dayparts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList)

            RefreshSpotRadioTab(False)

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSpotRadio_Dayparts.ShowingEditorEvent

            If DataGridViewSpotRadio_Dayparts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                e.Cancel = (DataGridViewSpotRadio_Dayparts.IsNewItemRow = False)

            ElseIf DataGridViewSpotRadio_Dayparts.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_Dayparts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotRadio_Dayparts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateDaypartEntity(_ViewModel, e.Row, e.Valid)

                If DataGridViewSpotRadio_Dayparts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        _Controller.DaypartAddNewRowEvent(_ViewModel, e.Row)

                        RefreshSpotRadioTab(False)

                    Else

                        DataGridViewSpotRadio_Dayparts.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewSpotRadio_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewSpotRadio_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewSpotRadio_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSelectedSpotRadioResearchCriteria(_ViewModel, DataGridViewSpotRadio_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadSpotRadioViewModel(DirectCast(DataGridViewSpotRadio_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID, False)

                TabControlSpotRadio_ResearchCriteria.SelectedTab = TabItemSpotRadio_MarketBooks

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewSpotRadio_SelectedMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadio_SelectedMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewSpotRadio_AvailableMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadio_AvailableMetrics.RowDoubleClickEvent

            _Controller.AddToSelectedSpotRadioMetrics(_ViewModel, DataGridViewSpotRadio_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioTab()

            SelectAdjacentRow(DataGridViewSpotRadio_AvailableMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadio_AvailableStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadio_AvailableStations.RowDoubleClickEvent

            _Controller.AddToSelectedSpotRadioStations(_ViewModel, DataGridViewSpotRadio_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshSpotRadioTab()

            SelectAdjacentRow(DataGridViewSpotRadio_AvailableStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadio_SelectedMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadio_SelectedMetrics.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotRadioMetrics(_ViewModel, DataGridViewSpotRadio_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioTab()

            SelectAdjacentRow(DataGridViewSpotRadio_SelectedMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadio_SelectedStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadio_SelectedStations.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotRadioStations(_ViewModel, DataGridViewSpotRadio_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshSpotRadioTab()

            SelectAdjacentRow(DataGridViewSpotRadio_SelectedStations, e.RowHandle)

        End Sub
        Private Sub SearchableComboBoxSpotRadioMarket_Demographic_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotRadioMarket_Demographic.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Code.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Code.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.ID.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.ID.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Type.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Type.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.IsInactive.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.IsInactive.ToString).Visible = False

            End If

        End Sub
        Private Sub SearchableComboBoxSpotRadioMarket_Demographic_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotRadioMarket_Demographic.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxSpotRadioMarket_Demographic.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSpotRadioDemographic(_ViewModel, SearchableComboBoxSpotRadioMarket_Demographic.GetSelectedValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub SearchableComboBoxSpotRadio_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotRadio_Market.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxSpotRadio_Market.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSpotRadioAvailableStations(_ViewModel, SearchableComboBoxSpotRadio_Market.GetSelectedValue, _ViewModel.SelectedResearchCriteria.ID)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub SearchableComboBoxSpotRadio_Market_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotRadio_Market.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenTVCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenTVCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenTVDMACode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenTVDMACode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenRadioCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenBlackRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenBlackRadioCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenHispanicRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.NielsenHispanicRadioCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanRadioCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanBlackRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanBlackRadioCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanHispanicRadioCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Market.Properties.EastlanHispanicRadioCode.ToString).Visible = False

            End If

        End Sub
        Private Sub SearchableComboBoxSpotRadioMarket_Qualitative_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxSpotRadioMarket_Qualitative.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxSpotRadioMarket_Qualitative.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSpotRadioQualitative(_ViewModel, SearchableComboBoxSpotRadioMarket_Qualitative.GetSelectedValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub TabControlSpotRadio_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSpotRadio_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlSpotRadio_ResearchCriteria_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlSpotRadio_ResearchCriteria.SelectedTabChanging

            If Me.FormShown AndAlso e.OldTab IsNot Nothing AndAlso e.OldTab.Equals(TabItemSpotRadio_MarketBooks) Then

                _Controller.SetBooks(_ViewModel, DataGridViewSpotRadio_Books.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList)

            ElseIf Me.FormShown AndAlso e.OldTab IsNot Nothing AndAlso e.OldTab.Equals(TabItemSpotRadio_GeographyDayparts) Then

                _Controller.SetDayparts(_ViewModel, DataGridViewSpotRadio_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList)

            End If

        End Sub
        Private Sub NumericInputSpotRadioMarket_MaxRank_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputSpotRadioMarket_MaxRank.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetRadioMaxRank(_ViewModel, NumericInputSpotRadioMarket_MaxRank.GetValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub NumericInputSpotTVMarketStation_MaximumRank_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputSpotTVMarketStation_MaximumRank.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetTVMaxRank(_ViewModel, NumericInputSpotTVMarketStation_MaximumRank.GetValue)

                RefreshSpotTVTab()

            End If

        End Sub

#End Region

#Region " Spot Radio County "

        Private Sub LoadSpotRadioCountyViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            'objects
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            _ViewModel = _Controller.SpotRadioCounty_Load(ResearchID)

            If Not _MissingIntegrationSettingsMessageShown AndAlso String.IsNullOrWhiteSpace(_ViewModel.MissingIntegrationSettingsMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.MissingIntegrationSettingsMessage)
                _MissingIntegrationSettingsMessageShown = True

            End If

            SearchableComboBoxCounty_County.DataSource = _ViewModel.SpotRadioCountyList

            ComboBoxCounty_ReportType.DataSource = _ViewModel.SpotRadioCountyResearchReportTypeList

            SearchableComboBoxCounty_Demographic.DataSource = _ViewModel.SpotRadioCountyMediaDemographicList

            If _ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing Then

                SearchableComboBoxCounty_County.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode

                ComboBoxCounty_ReportType.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType

                SearchableComboBoxCounty_Demographic.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.MediaDemoID

            End If

            If LoadGrid Then

                DataGridViewSpotRadioCounty_UserCriterias.DataSource = _ViewModel.SpotRadioCountyResearchCriteriaList

                If DataGridViewSpotRadioCounty_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewSpotRadioCounty_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

                DataGridViewSpotRadioCounty_UserCriterias.CurrentView.BestFitColumns()

            Else

                DataGridViewSpotRadioCounty_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.SpotRadioCountySelectedResearchCriteria Is Nothing Then

                DataGridViewSpotRadioCounty_UserCriterias.FocusToFindPanel(True)

                SearchableComboBoxCounty_County.SelectedValue = Nothing

                'SetGroupBoxRadioButton(GroupBoxSpotRadioCounty_Ethnicity, 1)

                NumericInputCounty_MaxRank.EditValue = Nothing

            Else

                DataGridViewSpotRadioCounty_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria.Properties.ID.ToString, _ViewModel.SpotRadioCountySelectedResearchCriteria.ID, True)

                SearchableComboBoxCounty_County.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode
                ComboBoxCounty_ReportType.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType.ToString

                NumericInputCounty_MaxRank.EditValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.MaxRank
                SearchableComboBoxCounty_Demographic.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.MediaDemoID
                'SetGroupBoxRadioButton(GroupBoxSpotRadioCounty_Ethnicity, _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity)
                CheckBoxCounty_ShowFrequency.Checked = _ViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency

                CheckBoxCountyDaypart68.Checked = _ViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68
                CheckBoxCountyDaypart84.Checked = _ViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84

                DataGridViewSpotRadioCounty_Years.DataSource = _ViewModel.SpotRadioCountyYearList
                DataGridViewSpotRadioCounty_Years.CurrentView.BestFitColumns()

                DataGridViewSpotRadioCounty_AvailableStations.DataSource = _ViewModel.SpotRadioCountyAvailableStationList
                DataGridViewSpotRadioCounty_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewSpotRadioCounty_SelectedStations.DataSource = _ViewModel.SpotRadioCountySelectedStationList
                DataGridViewSpotRadioCounty_SelectedStations.CurrentView.BestFitColumns()

                DataGridViewSpotRadioCounty_AvailableMetrics.DataSource = _ViewModel.SpotRadioCountyAvailableMetricList
                DataGridViewSpotRadioCounty_AvailableMetrics.CurrentView.BestFitColumns()

                DataGridViewSpotRadioCounty_SelectedMetrics.DataSource = _ViewModel.SpotRadioCountySelectedMetricList
                DataGridViewSpotRadioCounty_SelectedMetrics.CurrentView.BestFitColumns()

            End If

            RefreshSpotRadioCountyTab(False)

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Function SaveSpotRadioCounty() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Saving)

                SaveSpotRadioCountyViewModel()

                Saved = _Controller.SpotRadioCounty_Save(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadSpotRadioCountyViewModel(_ViewModel.SpotRadioCountySelectedResearchCriteria.ID, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            SaveSpotRadioCounty = Saved

        End Function
        Private Sub RefreshSpotRadioCountyTab(RefreshData As Boolean, Optional ByVal RefreshStations As Boolean = False)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

            TabControlSpotRadioCounty_ResearchCriteria.Enabled = (_ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Export.Enabled = _ViewModel.SpotRadioCountyExportEnabled
            ButtonItemActions_Add.Enabled = _ViewModel.SpotRadioCountyAddEnabled
            ButtonItemActions_Edit.Enabled = _ViewModel.SpotRadioCountyEditEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SpotRadioCountySaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.SpotRadioCountyDeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.SpotRadioCountyCopyEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.SpotRadioCountyProcessEnabled
            ButtonItemActions_Refresh.Enabled = (_ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing)

            TabItemSpotRadioCounty_Results.Visible = (Not _ViewModel.SpotRadioCountyIsDirty AndAlso _ViewModel.SpotRadioCountyReportDataTable IsNot Nothing)

            If _ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing Then

                CheckBoxCounty_ShowFrequency.Checked = _ViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency

                'If _ViewModel.SpotRadioCountyWeightingFlags IsNot Nothing Then

                '    For Each WeightingFlag In _ViewModel.SpotRadioCountyWeightingFlags

                '        Select Case WeightingFlag

                '            Case "B"

                '                RadioButtonSpotRadioCounty_BlackOthers.Enabled = True
                '                RadioButtonSpotRadioCounty_BlackOthers.Checked = True

                '                _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = CShort(RadioButtonSpotRadioCounty_BlackOthers.Tag)

                '            Case "S"

                '                RadioButtonSpotRadioCounty_HispanicOthers.Enabled = True
                '                RadioButtonSpotRadioCounty_HispanicOthers.Checked = True

                '                _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = CShort(RadioButtonSpotRadioCounty_HispanicOthers.Tag)

                '            Case "A"

                '                RadioButtonSpotRadioCounty_BlackHispanicOthers.Enabled = True
                '                RadioButtonSpotRadioCounty_BlackHispanicOthers.Checked = True

                '                _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = CShort(RadioButtonSpotRadioCounty_BlackHispanicOthers.Tag)

                '            Case Else

                '                RadioButtonSpotRadioCounty_All.Enabled = True
                '                RadioButtonSpotRadioCounty_All.Checked = True

                '                _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = CShort(RadioButtonSpotRadioCounty_All.Tag)

                '        End Select

                '    Next

                'End If

            End If

            If RefreshStations Then

                DataGridViewSpotRadioCounty_AvailableStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station))
                DataGridViewSpotRadioCounty_AvailableStations.DataSource = _ViewModel.SpotRadioCountyAvailableStationList

                DataGridViewSpotRadioCounty_SelectedStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station))
                DataGridViewSpotRadioCounty_SelectedStations.DataSource = _ViewModel.SpotRadioCountySelectedStationList

            End If

            If RefreshData Then

                SearchableComboBoxCounty_County.DataSource = Nothing
                SearchableComboBoxCounty_County.DataSource = _ViewModel.SpotRadioCountyList

                If _ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing Then

                    SearchableComboBoxCounty_County.SelectedValue = _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode

                End If

                DataGridViewSpotRadioCounty_Years.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year))
                DataGridViewSpotRadioCounty_Years.DataSource = _ViewModel.SpotRadioCountyYearList

                DataGridViewSpotRadioCounty_AvailableMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotRadioCounty_AvailableMetrics.DataSource = _ViewModel.SpotRadioCountyAvailableMetricList

                DataGridViewSpotRadioCounty_SelectedMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotRadioCounty_SelectedMetrics.DataSource = _ViewModel.SpotRadioCountySelectedMetricList

                If _ViewModel.SpotRadioCountyReportDataTable IsNot Nothing AndAlso _ViewModel.SpotRadioCountyProcessEnabled AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Ranker Then

                    SetupSpotRadioCountyRankerDataBands()

                ElseIf _ViewModel.SpotRadioCountyReportDataTable IsNot Nothing AndAlso _ViewModel.SpotRadioCountyProcessEnabled AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotRadioCountyResearchReportType.Trend Then

                    SetupSpotRadioCountyTrendDataBands()

                Else

                    BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Clear()
                    BandedDataGridViewSpotRadioCountyResults.ClearGridCustomization()

                End If

            End If

            If _ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.Age Then

                ButtonItemReportView_ByAge.Checked = True

            ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.AgeGender Then

                ButtonItemReportView_ByAgeGender.Checked = True

            ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.Gender Then

                ButtonItemReportView_ByGender.Checked = True

            End If

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub SaveSpotRadioCountyViewModel()

            _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode = SearchableComboBoxCounty_County.GetSelectedValue
            _ViewModel.SpotRadioCountySelectedResearchCriteria.ReportType = ComboBoxCounty_ReportType.GetSelectedValue
            _ViewModel.SpotRadioCountySelectedResearchCriteria.MediaDemoID = SearchableComboBoxCounty_Demographic.GetSelectedValue
            _ViewModel.SpotRadioCountySelectedResearchCriteria.MaxRank = NumericInputCounty_MaxRank.GetValue

            _ViewModel.SpotRadioCountySelectedResearchCriteria.Ethnicity = 1 'GetGroupBoxRadioButtonValue(GroupBoxSpotRadioCounty_Ethnicity)
            _ViewModel.SpotRadioCountySelectedResearchCriteria.Daypart68 = CheckBoxCountyDaypart68.Checked
            _ViewModel.SpotRadioCountySelectedResearchCriteria.Daypart84 = CheckBoxCountyDaypart84.Checked
            _ViewModel.SpotRadioCountySelectedResearchCriteria.ShowFrequency = CheckBoxCounty_ShowFrequency.Checked

            _ViewModel.SpotRadioCountyYearList = DataGridViewSpotRadioCounty_Years.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year).ToList

            _ViewModel.SpotRadioCountySelectedStationList = DataGridViewSpotRadioCounty_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station).ToList

            _ViewModel.SpotRadioCountySelectedMetricList = DataGridViewSpotRadioCounty_SelectedMetrics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList

        End Sub
        Private Sub SetupSpotRadioCountyRankerDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim IntabInfoGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DaypartBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DaypartBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SortString As String = Nothing

            BandedDataGridViewSpotRadioCountyResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotRadioCountyResults.ClearGridCustomization()
            BandedDataGridViewSpotRadioCountyResults.AutoUpdateViewCaption = False

            DaypartBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                CopyrightGridBand.Caption = "Copyright © " & _ViewModel.SpotRadioCountyResearchResultList.First.Years & " The Nielsen Company, " & _ViewModel.SpotRadioCountyResearchResultList.First.CountyName & ", " & _ViewModel.SpotRadioCountyResearchResultList.First.State

            Else

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Add(CopyrightGridBand)

            IntabInfoGridBand = CopyrightGridBand.Children.AddBand("")
            IntabInfoGridBand.Name = "IntabInfo"

            If _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                If _ViewModel.SpotRadioCountyResearchResultList.First.IntabFlag AndAlso _ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1 Then

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab & "* Warning: Estimates may be unstable due to low sample size."

                ElseIf _ViewModel.SpotRadioCountyResearchResultList.First.IntabFlag AndAlso _ViewModel.SpotRadioCountyResearchResultList.First.BookCount > 1 Then

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab & "* Warning: One or more of the books averaged are less than Nielsen standard and considered unstable."

                Else

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab

                End If

            End If

            IntabInfoGridBand.OptionsBand.AllowMove = False

            BlankGridBand = IntabInfoGridBand.Children.AddBand("")

            If _ViewModel.SpotRadioCountyResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                BlankGridBand.Caption = _ViewModel.SpotRadioCountyResearchResultList.First.Demographic

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotRadioCountyResearchResultList
                                        Select Entity.Daypart, Entity.NielsenRadioDaypartID).Distinct.ToList

                DaypartBand = IntabInfoGridBand.Children.AddBand(ResearchResult.Daypart)
                DaypartBand.Tag = ResearchResult.NielsenRadioDaypartID
                DaypartBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                DaypartBand.AppearanceHeader.Options.UseTextOptions = True
                DaypartBand.OptionsBand.FixedWidth = True
                DaypartBand.OptionsBand.AllowMove = False

                DaypartBands.Add(DaypartBand)

            Next

            BandedDataGridViewSpotRadioCountyResults.ClearDatasource(_ViewModel.SpotRadioCountyReportDataTable.Clone)

            BandedDataGridViewSpotRadioCountyResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotRadioCountyResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString Then

                        GridColumn.Caption = "Station"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString Then

                        GridColumn.Caption = "Frequency"

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Daypart") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each DaypartBand In DaypartBands

                For Each GridColumn In BandedDataGridViewSpotRadioCountyResults.Columns

                    If GridColumn.FieldName.EndsWith(DaypartBand.Tag) Then

                        DaypartBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("AQHRating") Then

                            GridColumn.Caption = "AQH Rating"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("AQH") Then

                            GridColumn.Caption = "AQH (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("CumeRating") Then

                            GridColumn.Caption = "Cume Rating"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("Cume") Then

                            GridColumn.Caption = "Cume (00)"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("StationShareofCountyPercent") Then

                            GridColumn.Caption = "Sta % of Cty"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("CountyShareofStationPercent") Then

                            GridColumn.Caption = "Cty % of Sta"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        End If

                    End If

                Next

            Next

            If _ViewModel.SpotRadioCountyReportDataTable.Rows.Count > 0 Then

                For Each GridColumn In BandedDataGridViewSpotRadioCountyResults.Columns

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        _ViewModel.SpotRadioCountyReportDataTable.Columns.Add("NullRankCheck", GetType(Integer), GridColumn.FieldName & " Is Null")

                        SortString = "NullRankCheck ASC, " & GridColumn.FieldName & " ASC"

                        Exit For

                    End If

                Next

                For Each GridColumn In DaypartBands.FirstOrDefault.Columns

                    If GridColumn.FieldName.StartsWith("Rank") = False Then

                        SortString += ", " & GridColumn.FieldName & " DESC"

                    End If

                Next

            End If

            _ViewModel.SpotRadioCountyReportDataTable.DefaultView.Sort = SortString

            BandedDataGridViewSpotRadioCountyResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False

            BandedDataGridViewSpotRadioCountyResults.CurrentView.ViewCaption = _ViewModel.SpotRadioCountySelectedResearchCriteria.CriteriaName & " (Ranker)"
            BandedDataGridViewSpotRadioCountyResults.DataSource = _ViewModel.SpotRadioCountyReportDataTable.DefaultView.ToTable

            BandedDataGridViewSpotRadioCountyResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotRadioCountyResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioCountyResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioCountyResults)

        End Sub
        Private Sub SetupSpotRadioCountyTrendDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim IntabInfoGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewSpotRadioCountyResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotRadioCountyResults.ClearGridCustomization()
            BandedDataGridViewSpotRadioCountyResults.AutoUpdateViewCaption = False

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            If _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                CopyrightGridBand.Caption = "Copyright © " & _ViewModel.SpotRadioCountyResearchResultList.First.Years & " The Nielsen Company, " & _ViewModel.SpotRadioCountyResearchResultList.First.CountyName & ", " & _ViewModel.SpotRadioCountyResearchResultList.First.State

            Else

                CopyrightGridBand.Caption = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

            End If

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Add(CopyrightGridBand)

            IntabInfoGridBand = CopyrightGridBand.Children.AddBand("")
            IntabInfoGridBand.Name = "IntabInfo"

            If _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                If _ViewModel.SpotRadioCountyResearchResultList.First.IntabFlag AndAlso _ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1 Then

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab & "* Warning: Estimates may be unstable due to low sample size."

                ElseIf _ViewModel.SpotRadioCountyResearchResultList.First.IntabFlag AndAlso _ViewModel.SpotRadioCountyResearchResultList.First.BookCount > 1 Then

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab & "* Warning: One or more of the books averaged are less than Nielsen standard and considered unstable."

                Else

                    IntabInfoGridBand.Caption = If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Population: ", "Populations: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Population & " / " &
                        If(_ViewModel.SpotRadioCountyResearchResultList.First.BookCount = 1, "Intab: ", "Intabs: ") & _ViewModel.SpotRadioCountyResearchResultList.First.Intab

                End If

            End If

            IntabInfoGridBand.OptionsBand.AllowMove = False

            BlankGridBand = IntabInfoGridBand.Children.AddBand("")

            If _ViewModel.SpotRadioCountyResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                BlankGridBand.Caption = _ViewModel.SpotRadioCountyResearchResultList.FirstOrDefault.Demographic & Space(1) & _ViewModel.SpotRadioCountyResearchResultList.FirstOrDefault.Daypart

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotRadioCountyResults.ClearDatasource(_ViewModel.SpotRadioCountyReportDataTable.Clone)

            BandedDataGridViewSpotRadioCountyResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotRadioCountyResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString OrElse
                        GridColumn.FieldName = "MetricName" Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString Then

                        GridColumn.Caption = "Station"

                    ElseIf GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationFrequency.ToString Then

                        GridColumn.Caption = "Frequency"

                    ElseIf GridColumn.FieldName = "MetricName" Then

                        GridColumn.Caption = "Metric"

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("BookMetric") Then

                    If _ViewModel.SpotRadioCountyResearchResultList IsNot Nothing AndAlso _ViewModel.SpotRadioCountyResearchResultList.Count > 0 Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        GridColumn.Caption = (From Entity In _ViewModel.SpotRadioCountyResearchResultList
                                              Where Entity.BookID = Mid(GridColumn.FieldName, 11)
                                              Select Entity.Books).FirstOrDefault.Replace(", ", vbCrLf)

                        BlankGridBand.Columns.Add(GridColumn)

                    End If

                End If

            Next

            BandedDataGridViewSpotRadioCountyResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            BandedDataGridViewSpotRadioCountyResults.CurrentView.ViewCaption = _ViewModel.SpotRadioCountySelectedResearchCriteria.CriteriaName & " (Trend)"
            BandedDataGridViewSpotRadioCountyResults.DataSource = _ViewModel.SpotRadioCountyReportDataTable.DefaultView.ToTable

            BandedDataGridViewSpotRadioCountyResults.OptionsBehavior.Editable = False

            If _ViewModel.SpotRadioCountyReportDataTable.Rows.Count > 0 AndAlso BandedDataGridViewSpotRadioCountyResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString) IsNot Nothing Then

                BandedDataGridViewSpotRadioCountyResults.CurrentView.ClearSorting()
                BandedDataGridViewSpotRadioCountyResults.CurrentView.BeginSort()
                BandedDataGridViewSpotRadioCountyResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult.Properties.StationName.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                BandedDataGridViewSpotRadioCountyResults.CurrentView.EndSort()

            End If

            BandedDataGridViewSpotRadioCountyResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotRadioCountyResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotRadioCountyResults)

        End Sub
        Private Sub ButtonSpotRadioCountyStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioCountyStation_AddToSelected.Click

            _Controller.SpotRadioCounty_AddToSelectedStations(_ViewModel, DataGridViewSpotRadioCounty_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station).ToList)

            RefreshSpotRadioCountyTab(False, True)

        End Sub
        Private Sub ButtonSpotRadioCountyStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioCountyStation_RemoveFromSelected.Click

            _Controller.SpotRadioCounty_RemoveFromSelectedStations(_ViewModel, DataGridViewSpotRadioCounty_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station).ToList)

            RefreshSpotRadioCountyTab(False, True)

        End Sub
        Private Sub ButtonSpotRadioCountyMetrics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioCountyMetrics_AddToSelected.Click

            _Controller.SpotRadioCounty_AddToSelectedMetrics(_ViewModel, DataGridViewSpotRadioCounty_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioCountyTab(True)

        End Sub
        Private Sub ButtonSpotRadioCountyMetrics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotRadioCountyMetrics_RemoveFromSelected.Click

            _Controller.SpotRadioCounty_RemoveFromSelectedMetrics(_ViewModel, DataGridViewSpotRadioCounty_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioCountyTab(True)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewSpotRadioCounty_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewSpotRadioCounty_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewSpotRadioCounty_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetSelectedResearchCriteria(_ViewModel, DataGridViewSpotRadioCounty_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadSpotRadioCountyViewModel(DirectCast(DataGridViewSpotRadioCounty_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria).ID, False)

                TabControlSpotRadioCounty_ResearchCriteria.SelectedTab = TabItemSpotRadioCounty_MarketBooks

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub SearchableComboBoxCounty_County_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxCounty_County.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxCounty_County.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetCounty(_ViewModel, SearchableComboBoxCounty_County.GetSelectedValue, _ViewModel.SpotRadioCountySelectedResearchCriteria.ID)

                RefreshSpotRadioCountyTab(True)

            End If

        End Sub
        Private Sub SearchableComboBoxCounty_Demographic_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxCounty_Demographic.Popup

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.ID.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.ID.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Group.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Group.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Category.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.MediaDemographic.Properties.Category.ToString).Visible = False

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotRadioCounty_Years.CellValueChangedEvent

            _Controller.SpotRadioCounty_YearCellChanged(_ViewModel, DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle), e.Column.FieldName, e.Value)

            RefreshSpotRadioCountyTab(False)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSpotRadioCounty_Years.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSpotRadioCounty_Years.CancelNewItemRow()

                        _Controller.SpotRadioCounty_YearCancelNewItemRow(_ViewModel)

                        RefreshSpotRadioCountyTab(True)

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        _Controller.SpotRadioCounty_DeleteSelectedYears(_ViewModel, DataGridViewSpotRadioCounty_Years.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year).ToList)

                        RefreshSpotRadioCountyTab(True)

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotRadioCounty_Years.InitNewRowEvent

            _Controller.SpotRadioCounty_YearInitNewRowEvent(_ViewModel)

            RefreshSpotRadioCountyTab(False)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewSpotRadioCounty_Years.QueryPopupNeedDatasourceEvent

            _ViewModel.SpotRadioCountyYearList = DataGridViewSpotRadioCounty_Years.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year).ToList

            Datasource = _Controller.SpotRadioCounty_GetYearRepository(_ViewModel, FieldName, DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle))

            OverrideDefaultDatasource = True

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewSpotRadioCounty_Years.RepositoryDataSourceLoadingEvent

            If FieldName.StartsWith("Year") Then

                Datasource = _ViewModel.SpotRadioCountyYearRepository

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadioCounty_Years.SelectionChangedEvent

            _Controller.SpotRadioCounty_YearSelectionChanged(_ViewModel, DataGridViewSpotRadioCounty_Years.IsNewItemRow)

            RefreshSpotRadioCountyTab(False)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewSpotRadioCounty_Years.ShowingEditorEvent

            If Not _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.HasValue Then

                e.Cancel = True

            ElseIf DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year1.ToString Then

                e.Cancel = (DataGridViewSpotRadioCounty_Years.IsNewItemRow = False)

            ElseIf DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year2.ToString Then

                e.Cancel = DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadioCounty.Year).Year1.HasValue

            ElseIf DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year3.ToString Then

                e.Cancel = DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle) Is Nothing OrElse
                   Not DirectCast(DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadioCounty.Year).Year2.HasValue

            ElseIf DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year4.ToString Then

                e.Cancel = DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadioCounty.Year).Year3.HasValue

            ElseIf DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.Year5.ToString Then

                e.Cancel = DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle) Is Nothing OrElse
                    Not DirectCast(DataGridViewSpotRadioCounty_Years.CurrentView.GetRow(DataGridViewSpotRadioCounty_Years.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.SpotRadioCounty.Year).Year4.HasValue

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadioCounty_Years.ShownEditorEvent

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewSpotRadioCounty_Years.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewSpotRadioCounty_Years.CurrentView.ActiveEditor

                If GridLookUpEdit.Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.MediaSpotRadioCountyResearchYearID.ToString) IsNot Nothing Then

                    GridLookUpEdit.Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.Year.Properties.MediaSpotRadioCountyResearchYearID.ToString).Visible = False

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotRadioCounty_Years.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.SpotRadioCounty_ValidateYear(_ViewModel, e.Row, e.Valid)

                If DataGridViewSpotRadioCounty_Years.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        _Controller.SpotRadioCounty_YearAddNewRowEvent(_ViewModel)

                        RefreshSpotRadioCountyTab(False)

                    Else

                        DataGridViewSpotRadioCounty_Years.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub TabControlSpotRadioCounty_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSpotRadioCounty_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlSpotRadioCounty_ResearchCriteria_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlSpotRadioCounty_ResearchCriteria.SelectedTabChanging

            If Me.FormShown Then

                _Controller.SpotRadioCounty_SetYearList(_ViewModel, DataGridViewSpotRadioCounty_Years.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year).ToList())

                If e.NewTab.Equals(TabItemSpotRadioCounty_Stations) Then

                    If Not _ViewModel.SpotRadioCountySelectedResearchCriteria.CountyCode.HasValue OrElse _ViewModel.SpotRadioCountyYearList Is Nothing OrElse _ViewModel.SpotRadioCountyYearList.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("Stations cannot be selected without a county and at least one year selected.")

                        e.Cancel = True

                    ElseIf _ViewModel.SpotRadioCountyAvailableStationList Is Nothing OrElse (_ViewModel.SpotRadioCountyAvailableStationList.Count = 0 AndAlso _ViewModel.SpotRadioCountySelectedStationList.Count = 0) Then

                        _Controller.SpotRadioCounty_SetAvailableStations(_ViewModel)

                        RefreshSpotRadioCountyTab(False, True)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_AvailableMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadioCounty_AvailableMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewSpotRadioCounty_SelectedMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotRadioCounty_SelectedMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub CheckBoxCounty_ShowFrequency_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCounty_ShowFrequency.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetShowFrequency(_ViewModel, CheckBoxCounty_ShowFrequency.Checked)

                RefreshSpotRadioCountyTab(False)

            End If

        End Sub
        Private Sub NumericInputCounty_MaxRank_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputCounty_MaxRank.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetMaxRank(_ViewModel, NumericInputCounty_MaxRank.GetValue)

                RefreshSpotRadioCountyTab(False)

            End If

        End Sub
        Private Sub CheckBoxCountyDaypart68_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCountyDaypart68.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetDaypart68(_ViewModel, CheckBoxCountyDaypart68.Checked)

                RefreshSpotRadioCountyTab(False)

            End If

        End Sub
        Private Sub CheckBoxCountyDaypart84_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCountyDaypart84.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetDaypart84(_ViewModel, CheckBoxCountyDaypart84.Checked)

                RefreshSpotRadioCountyTab(False)

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_AvailableMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadioCounty_AvailableMetrics.RowDoubleClickEvent

            _Controller.SpotRadioCounty_AddToSelectedMetrics(_ViewModel, DataGridViewSpotRadioCounty_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioCountyTab(True, False)

            SelectAdjacentRow(DataGridViewSpotRadioCounty_AvailableMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_SelectedMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadioCounty_SelectedMetrics.RowDoubleClickEvent

            _Controller.SpotRadioCounty_RemoveFromSelectedMetrics(_ViewModel, DataGridViewSpotRadioCounty_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotRadioCountyTab(True, False)

            SelectAdjacentRow(DataGridViewSpotRadioCounty_SelectedMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_AvailableStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadioCounty_AvailableStations.RowDoubleClickEvent

            _Controller.SpotRadioCounty_AddToSelectedStations(_ViewModel, DataGridViewSpotRadioCounty_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station).ToList)

            RefreshSpotRadioCountyTab(True, True)

            SelectAdjacentRow(DataGridViewSpotRadioCounty_AvailableStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotRadioCounty_SelectedStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotRadioCounty_SelectedStations.RowDoubleClickEvent

            _Controller.SpotRadioCounty_RemoveFromSelectedStations(_ViewModel, DataGridViewSpotRadioCounty_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station).ToList)

            RefreshSpotRadioCountyTab(True, True)

            SelectAdjacentRow(DataGridViewSpotRadioCounty_SelectedStations, e.RowHandle)

        End Sub
        Private Sub SearchableComboBoxCounty_Demographic_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxCounty_Demographic.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxCounty_Demographic.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetDemographic(_ViewModel, SearchableComboBoxCounty_Demographic.GetSelectedValue)

                RefreshSpotRadioCountyTab(False, False)

            End If

        End Sub
        Private Sub ComboBoxCounty_ReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxCounty_ReportType.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxCounty_ReportType.HasASelectedValue AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SpotRadioCounty_SetReportType(_ViewModel, ComboBoxCounty_ReportType.GetSelectedValue)

                RefreshSpotRadioCountyTab(False, False)

            End If

        End Sub
        Private Sub DataGridViewSpotRadioCounty_Years_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSpotRadioCounty_Years.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.SpotRadioCounty.Year = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewSpotRadioCounty_Years.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.SpotRadioCounty_YearValidateProperty(FocusedRow, DataGridViewSpotRadioCounty_Years.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub
        Private Sub SearchableComboBoxCounty_County_QueryPopUp(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SearchableComboBoxCounty_County.QueryPopUp

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.County.Properties.CountyCode.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.County.Properties.CountyCode.ToString).Visible = False

            End If

            If DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.County.Properties.MarketNumber.ToString) IsNot Nothing Then

                DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.Columns(AdvantageFramework.DTO.Media.SpotRadioCounty.County.Properties.MarketNumber.ToString).Visible = False

            End If

        End Sub
        Private Sub ButtonItemView_Books_Click(sender As Object, e As EventArgs) Handles ButtonItemView_Books.Click

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVTab) Then

                AdvantageFramework.Media.Presentation.BroadcastResearchBooksDialog.ShowFormDialog(BroadcastResearchBooksDialog.ShowBookType.TV)

            ElseIf TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotRadioTab) Then

                AdvantageFramework.Media.Presentation.BroadcastResearchBooksDialog.ShowFormDialog(BroadcastResearchBooksDialog.ShowBookType.Radio)

            End If

        End Sub

        Private Sub RadioButtonNationDates_DateCode_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonNationDates_DateCode.CheckedChanged

        End Sub

#End Region

#Region " National "

        Private Sub LoadNationalViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            'objects
            Dim RepositoryItemGridLookUpEdit As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit = Nothing

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            TextBoxNationalDates_Days.MaxLength = 20
            TextBoxNationalDates_StartTime.MaxLength = 10
            TextBoxNationalDates_EndTime.MaxLength = 10

            _ViewModel = _Controller.National_Load(ResearchID)

            If Not _MissingIntegrationSettingsMessageShown AndAlso String.IsNullOrWhiteSpace(_ViewModel.MissingIntegrationSettingsMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.MissingIntegrationSettingsMessage)
                _MissingIntegrationSettingsMessageShown = True

            End If

            ComboBoxNational_ReportType.DataSource = _ViewModel.NationalResearchReportTypeList

            ComboBoxNationalDates_Stream.DataSource = _ViewModel.NationalResearchReportStreamList

            If LoadGrid Then

                DataGridViewNational_UserCriterias.DataSource = _ViewModel.NationalResearchCriteriaList

                If DataGridViewNational_UserCriterias.Columns(AdvantageFramework.DTO.Media.National.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewNational_UserCriterias.Columns(AdvantageFramework.DTO.Media.National.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

                DataGridViewNational_UserCriterias.CurrentView.BestFitColumns()

            Else

                DataGridViewNational_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.NationalSelectedResearchCriteria Is Nothing Then

                DataGridViewNational_UserCriterias.FocusToFindPanel(True)

            Else

                DataGridViewNational_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.National.ResearchCriteria.Properties.ID.ToString, _ViewModel.NationalSelectedResearchCriteria.ID, True)

                ComboBoxNational_ReportType.SelectedValue = _ViewModel.NationalSelectedResearchCriteria.ReportType.ToString

                RadioButtonNationalTimeType_Program.Checked = (_ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.P.ToString)
                RadioButtonNationalTimeType_Commercial.Checked = (_ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.C.ToString)

                RadioButtonNationalEthnicity_GeneralMarket.Checked = (_ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.G.ToString)
                RadioButtonNationalEthnicity_Hispanic.Checked = (_ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString)

                DataGridViewNational_NetworksAvailable.DataSource = _ViewModel.NationalNetworkAvailableList
                DataGridViewNational_NetworksAvailable.CurrentView.BestFitColumns()

                DataGridViewNational_NetworksSelected.DataSource = _ViewModel.NationalNetworkSelectedList
                DataGridViewNational_NetworksSelected.CurrentView.BestFitColumns()

                DateEditNationalDates_StartDate.EditValue = _ViewModel.NationalSelectedResearchCriteria.StartDate
                DateEditNationalDates_EndDate.EditValue = _ViewModel.NationalSelectedResearchCriteria.EndDate

                TextBoxNationalDates_Days.Text = _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.Days
                TextBoxNationalDates_StartTime.Text = _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime
                TextBoxNationalDates_EndTime.Text = _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime

                ComboBoxNationalDates_Stream.SelectedValue = _ViewModel.NationalSelectedResearchCriteria.Stream

                SetRadioButton(GroupBoxNationalDates_Breakouts, _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag)
                SetRadioButton(GroupBoxNationalDates_Specials, _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag)
                SetRadioButton(GroupBoxNationalDates_Overnights, _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag)
                SetRadioButton(GroupBoxNationalDates_Repeats, _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag)
                SetRadioButton(GroupBoxNationalDates_Premieres, _ViewModel.NationalSelectedResearchCriteria.PremieresFlag)
                SetRadioButton(GroupBoxNationalDates_Corrections, _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag)

                CheckBoxNationalDates_ShowProgramTypes.Checked = _ViewModel.NationalSelectedResearchCriteria.ShowProgramTypes
                CheckBoxNationalDates_ShowAirings.Checked = _ViewModel.NationalSelectedResearchCriteria.ShowAirings

                DataGridViewNational_DemographicsAvailable.DataSource = _ViewModel.NationalDemographicAvailableList
                DataGridViewNational_DemographicsAvailable.CurrentView.BestFitColumns()

                DataGridViewNational_DemographicsSelected.DataSource = _ViewModel.NationalDemographicSelectedList
                DataGridViewNational_DemographicsSelected.CurrentView.BestFitColumns()

                DataGridViewNational_MetricsAvailable.DataSource = _ViewModel.NationalMetricAvailableList
                DataGridViewNational_MetricsAvailable.CurrentView.BestFitColumns()

                DataGridViewNational_MetricsSelected.DataSource = _ViewModel.NationalMetricSelectedList
                DataGridViewNational_MetricsSelected.CurrentView.BestFitColumns()

            End If

            RefreshNationalTab(False)

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub SetRadioButton(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox, Flag As String)

            For Each RC In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RC.Tag = Flag Then

                    RC.Checked = True
                    Exit For

                End If

            Next

        End Sub
        Private Function SaveNational() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Saving)

                SaveNationalViewModel()

                Saved = _Controller.National_Save(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadNationalViewModel(_ViewModel.NationalSelectedResearchCriteria.ID, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            SaveNational = Saved

        End Function
        Private Sub RefreshNationalTab(RefreshData As Boolean)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Refreshing

            TabControlNational_ResearchCriteria.Enabled = (_ViewModel.NationalSelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Export.Enabled = _ViewModel.NationalExportEnabled
            ButtonItemActions_Add.Enabled = _ViewModel.NationalAddEnabled
            ButtonItemActions_Edit.Enabled = _ViewModel.NationalEditEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.NationalSaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.NationalDeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.NationalCopyEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.NationalProcessEnabled
            ButtonItemActions_Refresh.Enabled = (_ViewModel.NationalSelectedResearchCriteria IsNot Nothing)

            TabItemNational_Results.Visible = (Not _ViewModel.NationalIsDirty AndAlso _ViewModel.NationalReportDataTable IsNot Nothing)

            If RefreshData Then

                DataGridViewNational_DemographicsAvailable.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.National.Demographic))
                DataGridViewNational_DemographicsAvailable.DataSource = _ViewModel.NationalDemographicAvailableList

                DataGridViewNational_DemographicsSelected.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.National.Demographic))
                DataGridViewNational_DemographicsSelected.DataSource = _ViewModel.NationalDemographicSelectedList

                DataGridViewNational_NetworksAvailable.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.National.Network))
                DataGridViewNational_NetworksAvailable.DataSource = _ViewModel.NationalNetworkAvailableList

                DataGridViewNational_NetworksSelected.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.National.Network))
                DataGridViewNational_NetworksSelected.DataSource = _ViewModel.NationalNetworkSelectedList

                DataGridViewNational_MetricsAvailable.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewNational_MetricsAvailable.DataSource = _ViewModel.NationalMetricAvailableList

                DataGridViewNational_MetricsSelected.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewNational_MetricsSelected.DataSource = _ViewModel.NationalMetricSelectedList

                If _ViewModel.NationalReportDataTable IsNot Nothing AndAlso _ViewModel.NationalProcessEnabled AndAlso (_ViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker OrElse
                        _ViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkRanker) Then

                    SetupNationalRankerDataBands(_ViewModel.NationalSelectedResearchCriteria.ReportType)

                    If _ViewModel.NationalReportDataTable.Rows.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("No data found.")

                    End If

                ElseIf _ViewModel.NationalReportDataTable IsNot Nothing AndAlso _ViewModel.NationalProcessEnabled AndAlso (_ViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart OrElse
                        _ViewModel.NationalSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart) Then

                    SetupNationalFlowchartDataBands(_ViewModel.NationalSelectedResearchCriteria.ReportType)

                    If _ViewModel.NationalReportDataTable.Rows.Count = 0 Then

                        AdvantageFramework.WinForm.MessageBox.Show("No data found.")

                    End If

                Else

                    BandedDataGridViewNationalResults.CurrentView.Bands.Clear()
                    BandedDataGridViewNationalResults.ClearGridCustomization()

                End If

            End If

            'If _ViewModel.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.Age Then

            '    ButtonItemReportView_ByAge.Checked = True

            'ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.AgeGender Then

            '    ButtonItemReportView_ByAgeGender.Checked = True

            'ElseIf _ViewModel.SelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotRadioCountySelectedResearchCriteria.DisplayByValue = DTO.Media.SpotRadioCounty.ResearchCriteria.DisplayBy.Gender Then

            '    ButtonItemReportView_ByGender.Checked = True

            'End If

            EnableOrDisableActions()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub DataGridViewNational_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewNational_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewNational_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewNational_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.National_SetSelectedResearchCriteria(_ViewModel, DataGridViewNational_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.National.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadNationalViewModel(DirectCast(DataGridViewNational_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.National.ResearchCriteria).ID, False)

                TabControlNational_ResearchCriteria.SelectedTab = TabItemNational_ReportType

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub ComboBoxNationalDates_Stream_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxNationalDates_Stream.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel.NationalSelectedResearchCriteria IsNot Nothing AndAlso
                    ComboBoxNationalDates_Stream.DataSource IsNot Nothing Then

                _Controller.National_SetStream(_ViewModel, If(ComboBoxNationalDates_Stream.HasASelectedValue, ComboBoxNationalDates_Stream.GetSelectedValue, Nothing))

                RefreshNationalTab(True)

            End If

        End Sub
        Private Sub ComboBoxNational_ReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxNational_ReportType.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel.NationalSelectedResearchCriteria IsNot Nothing AndAlso
                    ComboBoxNational_ReportType.DataSource IsNot Nothing Then

                _Controller.National_SetReportType(_ViewModel, If(ComboBoxNational_ReportType.HasASelectedValue, CShort(ComboBoxNational_ReportType.GetSelectedValue), Nothing))

                RefreshNationalTab(True)

            End If

        End Sub
        Private Sub RadioButtonNationalEthnicity_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonNationalEthnicity_GeneralMarket.CheckedChangedEx, RadioButtonNationalEthnicity_Hispanic.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.National_SetEthnicity(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl).Tag)

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub RadioButtonNationalTimeType_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonNationalTimeType_Commercial.CheckedChangedEx, RadioButtonNationalTimeType_Program.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.National_SetTimeType(_ViewModel, DirectCast(sender, AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl).Tag)

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub ButtonNationalDemographics_AddSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalDemographics_AddSelected.Click

            _Controller.National_MediaDemographicsAddToSelected(_ViewModel, DataGridViewNational_DemographicsAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Demographic).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub ButtonNationalDemographics_RemoveSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalDemographics_RemoveSelected.Click

            _Controller.National_MediaDemographicsRemoveFromSelected(_ViewModel, DataGridViewNational_DemographicsSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Demographic).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub ButtonNationalMetrics_AddSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalMetrics_AddSelected.Click

            _Controller.National_MetricsAddToSelected(_ViewModel, DataGridViewNational_MetricsAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub ButtonNationalMetrics_RemoveSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalMetrics_RemoveSelected.Click

            _Controller.National_MetricsRemoveFromSelected(_ViewModel, DataGridViewNational_MetricsSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub ButtonNationalNetworks_AddSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalNetworks_AddSelected.Click

            _Controller.National_NetworksAddToSelected(_ViewModel, DataGridViewNational_NetworksAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Network).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub ButtonNationalNetworks_RemoveSelected_Click(sender As Object, e As EventArgs) Handles ButtonNationalNetworks_RemoveSelected.Click

            _Controller.National_NetworksRemoveFromSelected(_ViewModel, DataGridViewNational_NetworksSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Network).ToList)

            RefreshNationalTab(True)

        End Sub
        Private Sub DataGridViewNational_DemographicsAvailable_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_DemographicsAvailable.RowDoubleClickEvent

            _Controller.National_MediaDemographicsAddToSelected(_ViewModel, DataGridViewNational_DemographicsAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Demographic).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_DemographicsAvailable, e.RowHandle)

        End Sub
        Private Sub DataGridViewNational_DemographicsSelected_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_DemographicsSelected.RowDoubleClickEvent

            _Controller.National_MediaDemographicsRemoveFromSelected(_ViewModel, DataGridViewNational_DemographicsSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Demographic).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_DemographicsSelected, e.RowHandle)

        End Sub
        Private Sub DataGridViewNational_MetricsAvailable_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_MetricsAvailable.RowDoubleClickEvent

            _Controller.National_MetricsAddToSelected(_ViewModel, DataGridViewNational_MetricsAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_MetricsAvailable, e.RowHandle)

        End Sub
        Private Sub DataGridViewNational_MetricsSelected_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_MetricsSelected.RowDoubleClickEvent

            _Controller.National_MetricsRemoveFromSelected(_ViewModel, DataGridViewNational_MetricsSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_MetricsSelected, e.RowHandle)

        End Sub
        Private Sub DataGridViewNational_MetricsSelected_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewNational_MetricsSelected.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewNational_NetworksAvailable_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_NetworksAvailable.RowDoubleClickEvent

            _Controller.National_NetworksAddToSelected(_ViewModel, DataGridViewNational_NetworksAvailable.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Network).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_NetworksAvailable, e.RowHandle)

        End Sub
        Private Sub DataGridViewNational_NetworksSelected_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewNational_NetworksSelected.RowDoubleClickEvent

            _Controller.National_NetworksRemoveFromSelected(_ViewModel, DataGridViewNational_NetworksSelected.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.National.Network).ToList)

            RefreshNationalTab(True)

            SelectAdjacentRow(DataGridViewNational_NetworksSelected, e.RowHandle)

        End Sub
        Private Sub SaveNationalViewModel()

            _ViewModel.NationalSelectedResearchCriteria.ReportType = CShort(ComboBoxNational_ReportType.GetSelectedValue)

            If RadioButtonNationalTimeType_Program.Checked Then

                _ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.P.ToString

            End If

            If RadioButtonNationalTimeType_Commercial.Checked Then

                _ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.C.ToString

            End If

            If RadioButtonNationalEthnicity_GeneralMarket.Checked Then

                _ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.G.ToString

            End If

            If RadioButtonNationalEthnicity_Hispanic.Checked Then

                _ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString

            End If

            _ViewModel.NationalSelectedResearchCriteria.StartDate = DateEditNationalDates_StartDate.EditValue
            _ViewModel.NationalSelectedResearchCriteria.EndDate = DateEditNationalDates_EndDate.EditValue

            _ViewModel.NationalSelectedResearchCriteria.Stream = ComboBoxNationalDates_Stream.GetSelectedValue

            _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Breakouts)
            _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Specials)
            _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Overnights)
            _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Repeats)
            _ViewModel.NationalSelectedResearchCriteria.PremieresFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Premieres)
            _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag = GetRadioButtonCheckedTag(GroupBoxNationalDates_Corrections)

            _ViewModel.NationalSelectedResearchCriteria.ShowProgramTypes = CheckBoxNationalDates_ShowProgramTypes.Checked
            _ViewModel.NationalSelectedResearchCriteria.ShowAirings = CheckBoxNationalDates_ShowAirings.Checked

        End Sub
        Private Function GetRadioButtonCheckedTag(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox) As String

            Dim SelectedTag As String = String.Empty

            For Each RC In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl)

                If RC.Checked Then

                    SelectedTag = RC.Tag
                    Exit For

                End If

            Next

            GetRadioButtonCheckedTag = SelectedTag

        End Function
        Private Sub TextBoxNationalDates_Days_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxNationalDates_Days.FinalizeValidationEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None AndAlso Me.TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) AndAlso
                    _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.Days <> TextBoxNationalDates_Days.Text Then

                If _Controller.National_ValidateDays(_ViewModel, TextBoxNationalDates_Days.Text) = False Then

                    IsValid = False

                    ErrorText = "Invalid days"

                End If

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub TextBoxNationalDates_StartTime_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxNationalDates_StartTime.FinalizeValidationEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None AndAlso Me.TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) Then

                If _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime <> TextBoxNationalDates_StartTime.Text Then

                    If _Controller.National_ValidateStartTime(_ViewModel, TextBoxNationalDates_StartTime.Text, ErrorText) = False AndAlso String.IsNullOrWhiteSpace(_ViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime) = False Then

                        IsValid = False

                    End If

                    If String.IsNullOrWhiteSpace(Me.TextBoxNationalDates_EndTime.Text) = False Then

                        Me.ValidateControl(Me.TextBoxNationalDates_EndTime)

                    End If

                End If

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub TextBoxNationalDates_EndTime_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxNationalDates_EndTime.FinalizeValidationEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None AndAlso Me.TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_NationalTab) Then

                If _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime <> TextBoxNationalDates_EndTime.Text Then

                    If _Controller.National_ValidateEndTime(_ViewModel, TextBoxNationalDates_EndTime.Text, ErrorText) = False AndAlso String.IsNullOrWhiteSpace(_ViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime) = False Then

                        IsValid = False

                    End If

                    If String.IsNullOrWhiteSpace(Me.TextBoxNationalDates_StartTime.Text) = False Then

                        Me.ValidateControl(Me.TextBoxNationalDates_StartTime)

                    End If

                End If

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub NationalRadioButtonChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _ViewModel.NationalIsDirty = True

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub SetupNationalRankerDataBands(ReportType As Short)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim FiltersCaption As String = String.Empty
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DemoBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DemoBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim MediaSpotNationalResearchMetrics As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotNationalResearchMetric) = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaSpotNationalResearchMetrics = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotNationalResearchMetric.LoadByMediaSpotNationalResearchID(DbContext, _ViewModel.NationalSelectedResearchCriteria.ID)
                                                    Select Entity).OrderBy(Function(Entity) Entity.Order).ToList

            End Using

            BandedDataGridViewNationalResults.CurrentView.BeginUpdate()

            BandedDataGridViewNationalResults.CurrentView.Bands.Clear()
            BandedDataGridViewNationalResults.ClearGridCustomization()
            BandedDataGridViewNationalResults.AutoUpdateViewCaption = False

            DemoBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"
            CopyrightGridBand.Caption = _NielsenCopyright & "  Ethnicity: " & If(_ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString, "Hispanic", "General Market") &
                "  Time Type: " & If(_ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.P.ToString, "Program", "Commercial") &
                "  Dates: " & _ViewModel.NationalSelectedResearchCriteria.StartDate.Value.ToShortDateString & "-" & _ViewModel.NationalSelectedResearchCriteria.EndDate.Value.ToShortDateString &
                "  Times: " & _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime & "-" & _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime &
                "  Stream: " & _ViewModel.NationalSelectedResearchCriteria.Stream
            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewNationalResults.CurrentView.Bands.Add(CopyrightGridBand)

            If _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Breakouts: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Breakouts: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Repeats: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Repeats: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Specials: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Specials: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.PremieresFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Premieres: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.PremieresFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Premieres: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Overnights: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Overnights: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Corrections: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Corrections: excluded  "

            End If

            If FiltersCaption.Length > 0 Then

                CopyrightGridBand.Caption += vbCrLf & FiltersCaption
                CopyrightGridBand.RowCount = 2

            End If

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            If _ViewModel.NationalReportDataTable.Rows.Count > 0 Then

                Dim DataRow As System.Data.DataRow = Nothing

                DataRow = _ViewModel.NationalReportDataTable.Rows(0)

                For Each DataColumn In _ViewModel.NationalReportDataTable.Columns

                    If DirectCast(DataColumn, System.Data.DataColumn).Caption.StartsWith("Demographic") Then

                        DemoBand = CopyrightGridBand.Children.AddBand(DataRow(DataColumn))
                        DemoBand.Tag = DirectCast(DataColumn, System.Data.DataColumn).Caption.Substring(11)
                        DemoBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        DemoBand.AppearanceHeader.Options.UseTextOptions = True
                        DemoBand.OptionsBand.FixedWidth = True
                        DemoBand.OptionsBand.AllowMove = False

                        DemoBands.Add(DemoBand)

                    End If

                Next

            End If

            BandedDataGridViewNationalResults.ClearDatasource(_ViewModel.NationalReportDataTable.Clone)

            BandedDataGridViewNationalResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewNationalResults.Columns

                GridColumn.Tag = CInt(0)

                If GridColumn.FieldName = "Network" OrElse
                        GridColumn.FieldName = "ProgramName" OrElse
                        GridColumn.FieldName = "ProgramType" OrElse
                        GridColumn.FieldName = "Airings" Then

                    If GridColumn.FieldName = "Network" Then

                        BlankGridBand.Columns.Add(GridColumn)
                        GridColumn.Tag = BlankGridBand

                        GridColumn.Caption = "Network"

                    ElseIf GridColumn.FieldName = "ProgramName" Then

                        BlankGridBand.Columns.Add(GridColumn)
                        GridColumn.Tag = BlankGridBand

                        GridColumn.Caption = "Program Name"

                    ElseIf GridColumn.FieldName = "ProgramType" Then

                        If _ViewModel.NationalSelectedResearchCriteria.ShowProgramTypes Then

                            BlankGridBand.Columns.Add(GridColumn)
                            GridColumn.Tag = BlankGridBand

                            GridColumn.Caption = "Program Type"

                        Else

                            GridColumn.Visible = False

                        End If

                    ElseIf GridColumn.FieldName = "Airings" Then

                        If _ViewModel.NationalSelectedResearchCriteria.ShowAirings Then

                            BlankGridBand.Columns.Add(GridColumn)
                            GridColumn.Tag = BlankGridBand

                            GridColumn.Caption = "Airings"

                        Else

                            GridColumn.Visible = False

                        End If

                    End If

                ElseIf GridColumn.FieldName.StartsWith("Demographic") Then

                    GridColumn.Visible = False

                Else

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(4))

                    ElseIf GridColumn.FieldName.StartsWith("HPUTPercent") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(11))

                    ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(4))

                    ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(11))

                    ElseIf GridColumn.FieldName.StartsWith("Rating") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(6))

                    ElseIf GridColumn.FieldName.StartsWith("Share") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(5))

                    ElseIf GridColumn.FieldName.StartsWith("VPVH") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(4))

                    ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                        GridColumn.Tag = CInt(GridColumn.FieldName.Substring(8))

                    End If

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName).Replace("HPUT", "H/PUT").Replace("Percent", "%")

                End If

            Next

            For Each DemoBand In DemoBands

                For Each GridColumn In BandedDataGridViewNationalResults.Columns

                    If IsNumeric(GridColumn.Tag) AndAlso GridColumn.Tag = DemoBand.Tag Then

                        DemoBand.Columns.Add(GridColumn)

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.Caption = "Rating"
                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.Caption = "Share"
                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Imps (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUTPercent") Then

                            GridColumn.Caption = "H/PUT %"
                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            GridColumn.Caption = "H/PUT (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.Caption = "Universe (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("VPVH") Then

                            GridColumn.Caption = "VPVH"
                            GridColumn.DisplayFormat.FormatString = "n0"

                            If DemoBand.Caption = "Households" Then

                                GridColumn.Visible = False

                            End If

                        End If

                    End If

                Next

            Next

            BandedDataGridViewNationalResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False

            If ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramRanker Then

                BandedDataGridViewNationalResults.CurrentView.ViewCaption = _ViewModel.NationalSelectedResearchCriteria.CriteriaName & " (Program Ranker)"

            ElseIf ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkRanker Then

                BandedDataGridViewNationalResults.CurrentView.ViewCaption = _ViewModel.NationalSelectedResearchCriteria.CriteriaName & " (Network Ranker)"

            End If

            BandedDataGridViewNationalResults.DataSource = _ViewModel.NationalReportDataTable.DefaultView.ToTable

            BandedDataGridViewNationalResults.OptionsBehavior.Editable = False

            BandedDataGridViewNationalResults.CurrentView.EndUpdate()

            BandedDataGridViewNationalResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewNationalResults)

        End Sub
        Private Sub TabControlNational_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlNational_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewNational_DemographicsSelected_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewNational_DemographicsSelected.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DateEditNationalDates_EndDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditNationalDates_EndDate.EditValueChanged

            Dim ErrorText As String = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                If _Controller.National_ValidateEndDate(_ViewModel, DateEditNationalDates_EndDate.GetValue, ErrorText) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                End If

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub DateEditNationalDates_StartDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditNationalDates_StartDate.EditValueChanged

            Dim ErrorText As String = Nothing

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                If _Controller.National_ValidateStartDate(_ViewModel, DateEditNationalDates_StartDate.GetValue, ErrorText) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorText)

                End If

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub CheckBoxNationalDates_ShowAirings_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxNationalDates_ShowAirings.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.National_SetShowAirings(_ViewModel, e.NewChecked.Checked)

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub CheckBoxNationalDates_ShowProgramTypes_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxNationalDates_ShowProgramTypes.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.National_SetShowProgramTypes(_ViewModel, e.NewChecked.Checked)

                RefreshNationalTab(False)

            End If

        End Sub
        Private Sub SetupNationalFlowchartDataBands(ReportType As Short)

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim FiltersCaption As String = String.Empty
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DemoBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DemoBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim DoneSorting As Boolean = False
            'Dim SortString As String = Nothing

            BandedDataGridViewNationalResults.CurrentView.BeginUpdate()

            BandedDataGridViewNationalResults.CurrentView.Bands.Clear()
            BandedDataGridViewNationalResults.ClearGridCustomization()
            BandedDataGridViewNationalResults.AutoUpdateViewCaption = False

            DemoBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"
            CopyrightGridBand.Caption = _NielsenCopyright & "  Ethnicity: " & If(_ViewModel.NationalSelectedResearchCriteria.Ethnicity = Database.Entities.NationalResearchReportEthnicity.H.ToString, "Hispanic", "General Market") &
                "  Time Type: " & If(_ViewModel.NationalSelectedResearchCriteria.TimeType = Database.Entities.Methods.NationalResearchReportTimeType.P.ToString, "Program", "Commercial") &
                "  Dates: " & _ViewModel.NationalSelectedResearchCriteria.StartDate.Value.ToShortDateString & "-" & _ViewModel.NationalSelectedResearchCriteria.EndDate.Value.ToShortDateString &
                "  Times: " & _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.StartTime & "-" & _ViewModel.NationalSelectedResearchCriteria.DaysAndTime.EndTime &
                "  Stream: " & _ViewModel.NationalSelectedResearchCriteria.Stream
            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewNationalResults.CurrentView.Bands.Add(CopyrightGridBand)

            If _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Breakouts: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.BreakoutFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Breakouts: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Repeats: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.RepeatsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Repeats: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Specials: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.SpecialsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Specials: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.PremieresFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Premieres: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.PremieresFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Premieres: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Overnights: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.OvernightsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Overnights: excluded  "

            End If

            If _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag = Database.Entities.NationalResearchReportFlags.O.ToString Then

                FiltersCaption += "Corrections: only  "

            ElseIf _ViewModel.NationalSelectedResearchCriteria.CorrectionsFlag = Database.Entities.NationalResearchReportFlags.E.ToString Then

                FiltersCaption += "Corrections: excluded  "

            End If

            If FiltersCaption.Length > 0 Then

                CopyrightGridBand.Caption += vbCrLf & FiltersCaption
                CopyrightGridBand.RowCount = 2

            End If

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            BlankGridBand.Caption = ""
            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            DemoBand = CopyrightGridBand.Children.AddBand(_ViewModel.NationalDemographicSelectedList.First.Description & " - " & _ViewModel.NationalMetricSelectedList.First.Description)
            DemoBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            DemoBand.AppearanceHeader.Options.UseTextOptions = True
            DemoBand.OptionsBand.FixedWidth = True
            DemoBand.OptionsBand.AllowMove = False

            DemoBands.Add(DemoBand)

            BandedDataGridViewNationalResults.ClearDatasource(_ViewModel.NationalReportDataTable.Clone)

            BandedDataGridViewNationalResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewNationalResults.Columns

                If GridColumn.FieldName = "Network" OrElse
                        GridColumn.FieldName = "ProgramName" OrElse
                        GridColumn.FieldName = "ProgramType" OrElse
                        GridColumn.FieldName = "Airings" Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = "Network" Then

                        GridColumn.Caption = "Network"

                    ElseIf GridColumn.FieldName = "ProgramName" Then

                        GridColumn.Caption = "Program Name"

                    ElseIf GridColumn.FieldName = "ProgramType" Then

                        GridColumn.Caption = "Program Type"

                    ElseIf GridColumn.FieldName = "Airings" Then

                        GridColumn.Caption = "Airings"

                    End If

                Else

                    DemoBand.Columns.Add(GridColumn)

                    GridColumn.Caption = MonthName(GridColumn.FieldName.Substring(4, 2), True) & Space(1) & GridColumn.FieldName.Substring(0, 4)
                    GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                    If _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("Rating") Then

                        GridColumn.DisplayFormat.FormatString = "n2"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("Share") Then

                        GridColumn.DisplayFormat.FormatString = "n2"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("Impressions") Then

                        GridColumn.DisplayFormat.FormatString = "n1"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("HPUTPercent") Then

                        GridColumn.DisplayFormat.FormatString = "n2"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("H/PUT") Then

                        GridColumn.DisplayFormat.FormatString = "n1"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("Universe") Then

                        GridColumn.DisplayFormat.FormatString = "n1"

                    ElseIf _ViewModel.NationalMetricSelectedList.First.Description.StartsWith("VPVH") Then

                        GridColumn.DisplayFormat.FormatString = "n0"

                    End If

                End If

            Next

            BandedDataGridViewNationalResults.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False

            If ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.ProgramFlowchart Then

                BandedDataGridViewNationalResults.CurrentView.ViewCaption = _ViewModel.NationalSelectedResearchCriteria.CriteriaName & " (Program Flowchart)"

            ElseIf ReportType = AdvantageFramework.Database.Entities.NationalResearchReportType.NetworkFlowchart Then

                BandedDataGridViewNationalResults.CurrentView.ViewCaption = _ViewModel.NationalSelectedResearchCriteria.CriteriaName & " (Network Flowchart)"

            End If

            BandedDataGridViewNationalResults.DataSource = _ViewModel.NationalReportDataTable.DefaultView.ToTable

            BandedDataGridViewNationalResults.OptionsBehavior.Editable = False

            BandedDataGridViewNationalResults.CurrentView.EndUpdate()

            BandedDataGridViewNationalResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewNationalResults)

        End Sub
        Private Sub BandedDataGridViewSpotRadioCountyResults_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewSpotRadioCountyResults.PopupMenuShowingEvent

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                BlankGridBand = BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Where(Function(Band) Band.Tag = "BLANK").FirstOrDefault

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.ToUpper = "COLUMN/BAND CHOOSER" OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = False

                    End If

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) OrElse
                                MenuItem.Caption.ToUpper.Equals("SHOW GROUP BY BOX") Then

                        MenuItem.Visible = False

                    End If

                    If BlankGridBand IsNot Nothing AndAlso Not BlankGridBand.Columns.Contains(e.HitInfo.Column) Then

                        If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) Then

                            MenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub BandedDataGridViewNationalResults_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewNationalResults.PopupMenuShowingEvent

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                BlankGridBand = BandedDataGridViewSpotRadioCountyResults.CurrentView.Bands.Where(Function(Band) Band.Tag = "BLANK").FirstOrDefault

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.ToUpper = "COLUMN/BAND CHOOSER" OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = False

                    End If

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) OrElse
                                MenuItem.Caption.ToUpper.Equals("SHOW GROUP BY BOX") Then

                        MenuItem.Visible = False

                    End If

                    If BlankGridBand IsNot Nothing AndAlso Not BlankGridBand.Columns.Contains(e.HitInfo.Column) Then

                        If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) Then

                            MenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub

#End Region

#Region " Spot TV Puerto Rico "

        Private Sub LoadSpotTVPuertoRicoViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.Loading

            TabItemSpotTVPuertoRico_PeriodsDaysTimes.Tag = False

            _ViewModel = _Controller.LoadSpotTVPuertoRico(ResearchID)

            If Not _MissingIntegrationSettingsMessageShown AndAlso String.IsNullOrWhiteSpace(_ViewModel.MissingIntegrationSettingsMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.MissingIntegrationSettingsMessage)
                _MissingIntegrationSettingsMessageShown = True

            End If

            ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.DataSource = _ViewModel.SpotTVPuertoRicoResearchReportTypeList

            If LoadGrid Then

                DataGridViewSpotTVPuertoRico_UserCriterias.DataSource = _ViewModel.SpotTVPuertoRicoResearchCriteriaList

                If DataGridViewSpotTVPuertoRico_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewSpotTVPuertoRico_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

                DataGridViewSpotTVPuertoRico_UserCriterias.CurrentView.BestFitColumns()

            Else

                DataGridViewSpotTVPuertoRico_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria Is Nothing Then

                DataGridViewSpotTVPuertoRico_UserCriterias.FocusToFindPanel(True)

                NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.EditValue = Nothing

            Else

                DataGridViewSpotTVPuertoRico_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria.Properties.ID.ToString, _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID, True)

                ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.SelectedValue = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType.ToString

                CheckBoxSpotTVPuertoRicoOptions_ShowProgramName.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName
                CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes
                'CheckBoxSpotTVPuertoRicoOptions_SubtotalByWeekdayWeekend.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.SubtotalByWeekdayWeekend

                NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.EditValue = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank

                DateEditSpotTVPuertoRicoPeriod_ShareStartDate.EditValue = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareStartDate
                DateEditSpotTVPuertoRicoPeriod_ShareEndDate.EditValue = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareEndDate

                DataGridViewSpotTVPuertoRico_AvailableStations.DataSource = _ViewModel.SpotTVPuertoRicoAvailableStationList
                DataGridViewSpotTVPuertoRico_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_SelectedStations.DataSource = _ViewModel.SpotTVPuertoRicoSelectedStationList
                DataGridViewSpotTVPuertoRico_SelectedStations.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_DayTimes.DataSource = _ViewModel.SpotTVPuertoRicoDayTimeList
                DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_AvailableDemographics.DataSource = _ViewModel.SpotTVPuertoRicoAvailableDemographicList
                DataGridViewSpotTVPuertoRico_AvailableDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_SelectedDemographics.DataSource = _ViewModel.SpotTVPuertoRicoSelectedDemographicList
                DataGridViewSpotTVPuertoRico_SelectedDemographics.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_AvailableMetrics.DataSource = _ViewModel.SpotTVPuertoRicoAvailableMetricList
                DataGridViewSpotTVPuertoRico_AvailableMetrics.CurrentView.BestFitColumns()

                DataGridViewSpotTVPuertoRico_SelectedMetrics.DataSource = _ViewModel.SpotTVPuertoRicoSelectedMetricList
                DataGridViewSpotTVPuertoRico_SelectedMetrics.CurrentView.BestFitColumns()

                ShowOrHideDemographicsColumns(DataGridViewSpotTVPuertoRico_AvailableDemographics)
                ShowOrHideDemographicsColumns(DataGridViewSpotTVPuertoRico_SelectedDemographics)

            End If

            RefreshSpotTVPuertoRicoTab()

            Me.ClearChanged()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub RefreshSpotTVPuertoRicoTab(Optional RefreshData As Boolean = True)

            TabControlSpotTVPuertoRico_ResearchCriteria.Enabled = (_ViewModel.SpotTVPuertoRicoSelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Export.Enabled = _ViewModel.SpotTVPuertoRicoExportEnabled
            ButtonItemActions_Add.Enabled = _ViewModel.SpotTVPuertoRicoAddEnabled
            ButtonItemActions_Edit.Enabled = _ViewModel.SpotTVPuertoRicoEditEnabled
            ButtonItemActions_Save.Enabled = _ViewModel.SpotTVPuertoRicoSaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.SpotTVPuertoRicoDeleteEnabled
            ButtonItemActions_Copy.Enabled = _ViewModel.SpotTVPuertoRicoCopyEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.SpotTVPuertoRicoProcessEnabled
            ButtonItemActions_Refresh.Enabled = (_ViewModel.SpotTVPuertoRicoSelectedResearchCriteria IsNot Nothing)

            TabItemSpotTVPuertoRico_Results.Visible = (Not _ViewModel.SpotTVPuertoRicoIsDirty AndAlso _ViewModel.SpotTVPuertoRicoReportDataTable IsNot Nothing)

            NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.Visible = (_ViewModel.SpotTVPuertoRicoSelectedResearchCriteria IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.Ranker)
            LabelSpotTVPuertoRicoReportTypeStation_MaximumRank.Visible = NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.Visible

            If RefreshData Then

                If _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria IsNot Nothing Then

                    CheckBoxSpotTVPuertoRicoOptions_ShowProgramName.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName
                    CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes
                    'CheckBoxSpotTVPuertoRicoOptions_SubtotalByWeekdayWeekend.Checked = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.SubtotalByWeekdayWeekend

                End If

                DataGridViewSpotTVPuertoRico_AvailableStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station))
                DataGridViewSpotTVPuertoRico_AvailableStations.DataSource = _ViewModel.SpotTVPuertoRicoAvailableStationList

                DataGridViewSpotTVPuertoRico_SelectedStations.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station))
                DataGridViewSpotTVPuertoRico_SelectedStations.DataSource = _ViewModel.SpotTVPuertoRicoSelectedStationList

                DataGridViewSpotTVPuertoRico_DayTimes.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.DaysAndTime))
                DataGridViewSpotTVPuertoRico_DayTimes.DataSource = _ViewModel.SpotTVPuertoRicoDayTimeList

                DataGridViewSpotTVPuertoRico_AvailableDemographics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic))
                DataGridViewSpotTVPuertoRico_AvailableDemographics.DataSource = _ViewModel.SpotTVPuertoRicoAvailableDemographicList

                DataGridViewSpotTVPuertoRico_SelectedDemographics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic))
                DataGridViewSpotTVPuertoRico_SelectedDemographics.DataSource = _ViewModel.SpotTVPuertoRicoSelectedDemographicList

                DataGridViewSpotTVPuertoRico_AvailableMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotTVPuertoRico_AvailableMetrics.DataSource = _ViewModel.SpotTVPuertoRicoAvailableMetricList

                DataGridViewSpotTVPuertoRico_SelectedMetrics.ClearDatasource(New Generic.List(Of AdvantageFramework.DTO.Media.Metric))
                DataGridViewSpotTVPuertoRico_SelectedMetrics.DataSource = _ViewModel.SpotTVPuertoRicoSelectedMetricList

                ShowOrHideDemographicsColumns(DataGridViewSpotTVPuertoRico_AvailableDemographics)
                ShowOrHideDemographicsColumns(DataGridViewSpotTVPuertoRico_SelectedDemographics)

                If _ViewModel.SpotTVPuertoRicoReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoProcessEnabled AndAlso _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.Ranker Then

                    SetupSpotTVPuertoRicoRankerDataBands()

                ElseIf _ViewModel.SpotTVPuertoRicoReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoProcessEnabled AndAlso _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVPuertoRicoResearchReportType.TrendByDate Then

                    SetupSpotTVPuertoRicoTrendByDateDataBands()

                    'ElseIf _ViewModel.SpotTVPuertoRicoReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoProcessEnabled AndAlso _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation Then

                    '    SetupSpotTVPuertoRicoTrendByStationDataBands()

                Else

                    BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Bands.Clear()
                    BandedDataGridViewSpotTVPuertoRicoResults.ClearGridCustomization()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Sub SetupSpotTVPuertoRicoRankerDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DemoBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DemoBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim DoneSorting As Boolean = False
            Dim SortString As String = Nothing

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotTVPuertoRicoResults.ClearGridCustomization()
            BandedDataGridViewSpotTVPuertoRicoResults.AutoUpdateViewCaption = False

            DemoBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"

            CopyrightGridBand.Caption = _NielsenPuertoRicoCopyright

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Bands.Add(CopyrightGridBand)

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            If _ViewModel.SpotTVPuertoRicoResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoResearchResultList.Count > 0 Then

                BlankGridBand.Caption = "Date Range: " & _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareStartDate.Value.ToShortDateString() & " - " & _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareEndDate.Value.ToShortDateString()

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.Tag = "BLANK"
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotTVPuertoRicoResearchResultList
                                        Select Entity.DemographicOrder, Entity.Demographic).OrderBy(Function(Entity) Entity.DemographicOrder).Distinct.ToList

                DemoBand = CopyrightGridBand.Children.AddBand(ResearchResult.Demographic)
                DemoBand.Tag = ResearchResult.DemographicOrder
                DemoBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                DemoBand.AppearanceHeader.Options.UseTextOptions = True
                DemoBand.OptionsBand.FixedWidth = True
                DemoBand.OptionsBand.AllowMove = False

                DemoBands.Add(DemoBand)

            Next

            BandedDataGridViewSpotTVPuertoRicoResults.ClearDatasource(_ViewModel.SpotTVPuertoRicoReportDataTable.Clone)

            BandedDataGridViewSpotTVPuertoRicoResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotTVPuertoRicoResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Station.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Times.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.ProgramName.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Demo") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)
                    GridColumn.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False

                End If

            Next

            For Each DemoBand In DemoBands

                For Each GridColumn In BandedDataGridViewSpotTVPuertoRicoResults.Columns

                    If GridColumn.FieldName.EndsWith(DemoBand.Tag) Then

                        DemoBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Aud (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            GridColumn.Caption = "H/PUT"
                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.Caption = "Sample Size"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ShowIntabWarning") Then

                            GridColumn.Visible = False

                        End If

                    End If

                Next

            Next

            If _ViewModel.SpotTVPuertoRicoReportDataTable.Rows.Count > 0 Then

                For Each GridColumn In BandedDataGridViewSpotTVPuertoRicoResults.Columns

                    If GridColumn.FieldName.StartsWith("Rank") Then

                        VisibleIndex = BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(GridColumn.FieldName).VisibleIndex + 1

                        _ViewModel.SpotTVPuertoRicoReportDataTable.Columns.Add("NullRankCheck", GetType(Integer), GridColumn.FieldName & " Is Null")

                        SortString = "NullRankCheck ASC, " & GridColumn.FieldName & " ASC"

                        Exit For

                    End If

                Next

                While Not DoneSorting AndAlso BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(VisibleIndex + 1) IsNot Nothing

                    If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(VisibleIndex + 1).FieldName.StartsWith("Rank") Then

                        DoneSorting = True

                    Else

                        SortString += ", " & BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(VisibleIndex + 1).FieldName & " DESC"

                    End If

                    VisibleIndex += 1

                    If VisibleIndex > BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.VisibleColumns.Count - 1 Then

                        DoneSorting = True

                    End If

                End While

            End If

            _ViewModel.SpotTVPuertoRicoReportDataTable.DefaultView.Sort = SortString

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.ViewCaption = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.CriteriaName & " (Ranker)"
            BandedDataGridViewSpotTVPuertoRicoResults.DataSource = _ViewModel.SpotTVPuertoRicoReportDataTable.DefaultView.ToTable

            If _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes Then

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Days.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Days.ToString).Group()

                End If

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Times.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Times.ToString).Group()

                End If

            End If

            BandedDataGridViewSpotTVPuertoRicoResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVPuertoRicoResults)

        End Sub
        Private Function SaveSpotTVPuertoRicoViewModel() As Boolean

            Dim Saved As Boolean = True

            DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.CloseEditorForUpdating()

            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ReportType = ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.GetSelectedValue
            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.MaxRank = NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.GetValue
            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShowProgramName = CheckBoxSpotTVPuertoRicoOptions_ShowProgramName.Checked
            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes = CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes.Checked
            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.SubtotalByWeekdayWeekend = CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes.Checked

            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareStartDate = DateEditSpotTVPuertoRicoPeriod_ShareStartDate.GetValue
            _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareEndDate = DateEditSpotTVPuertoRicoPeriod_ShareEndDate.GetValue

            _ViewModel.SpotTVPuertoRicoSelectedStationList = DataGridViewSpotTVPuertoRico_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList
            _ViewModel.SpotTVPuertoRicoDayTimeList = DataGridViewSpotTVPuertoRico_DayTimes.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList

            _ViewModel.SpotTVPuertoRicoSelectedDemographicList = DataGridViewSpotTVPuertoRico_SelectedDemographics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ToList
            _ViewModel.SpotTVPuertoRicoSelectedMetricList = DataGridViewSpotTVPuertoRico_SelectedMetrics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList

            If _ViewModel.SpotTVPuertoRicoDayTimeList.Any(Function(Entity) Entity.HasError) = True Then

                Saved = False
                TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab = TabItemSpotTVPuertoRico_PeriodsDaysTimes
                AdvantageFramework.WinForm.MessageBox.Show("Fix errors in Days/Times first.")

            End If

            SaveSpotTVPuertoRicoViewModel = Saved

        End Function
        Private Function SaveSpotTVPuertoRico() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Saving)

                If SaveSpotTVPuertoRicoViewModel() Then

                    Saved = _Controller.SaveSpotTVPuertoRico(_ViewModel, ErrorMessage)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadSpotTVPuertoRicoViewModel(_ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ID, True)

                ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            SaveSpotTVPuertoRico = Saved

        End Function
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_CreateReportFooterAreaEvent(sender As Object, e As DevExpress.XtraPrinting.CreateAreaEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.CreateReportFooterAreaEvent

            'objects
            Dim TextBrick As DevExpress.XtraPrinting.TextBrick = Nothing
            Dim SizeF As System.Drawing.SizeF = Nothing
            Dim RectangleF As System.Drawing.RectangleF = Nothing

            If (_ViewModel.SpotTVPuertoRicoResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoResearchResultList.Count > 0 AndAlso
                    _ViewModel.SpotTVPuertoRicoResearchResultList.Where(Function(Entity) Entity.ShowIntabWarning).Any) Then

                Try

                    TextBrick = New DevExpress.XtraPrinting.TextBrick
                    TextBrick.Text = AdvantageFramework.DTO.Media.ConstNielsenTVFooter
                    TextBrick.BackColor = System.Drawing.Color.White
                    TextBrick.HorzAlignment = DevExpress.Utils.HorzAlignment.Near
                    TextBrick.VertAlignment = DevExpress.Utils.VertAlignment.Top
                    TextBrick.StringFormat = DevExpress.XtraPrinting.BrickStringFormat.Create(DevExpress.XtraPrinting.TextAlignment.TopLeft, True)

                    SizeF = e.Graph.MeasureString(AdvantageFramework.DTO.Media.ConstNielsenTVFooter, CInt(Math.Ceiling(e.Graph.ClientPageSize.Width)), TextBrick.StringFormat.Value)

                    RectangleF = New System.Drawing.RectangleF(0, 0, SizeF.Width, SizeF.Height)
                    RectangleF.Height = RectangleF.Height + 20

                    e.Graph.DrawBrick(TextBrick, RectangleF)

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.CustomColumnDisplayTextEvent

            Dim DataRow As System.Data.DataRow = Nothing
            'Dim ColumnIndex As Integer = 0
            'Dim ShowAsterisk As Boolean = False

            'DataRow = BandedDataGridViewSpotTVPuertoRicoResults.GetRowDataBoundItem(BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.GetRowHandle(e.ListSourceRowIndex)).row

            'For ColumnIndex = 0 To DataRow.Table.Columns.Count - 1

            '    If DataRow.Table.Columns(ColumnIndex).ColumnName.StartsWith("ShowIntabWarning") AndAlso DataRow(ColumnIndex).Equals(System.DBNull.Value) = False AndAlso DataRow(ColumnIndex) = True Then

            '        ShowAsterisk = True
            '        Exit For

            '    End If

            'Next

            'If e.Column.FieldName.EndsWith(ColumnIndex) AndAlso ShowAsterisk Then

            '    e.DisplayText = FormatNumber(e.Value, 0).ToString & " *"

            'End If

            If e.Column.FieldName.StartsWith(AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Intab.ToString) AndAlso Not e.Value.Equals(System.DBNull.Value) Then

                DataRow = BandedDataGridViewSpotTVPuertoRicoResults.GetRowDataBoundItem(BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.GetRowHandle(e.ListSourceRowIndex)).row

                If DataRow.Item(Replace(e.Column.FieldName, "Intab", "ShowIntabWarning")) = True Then

                    e.DisplayText = FormatNumber(e.Value, 0).ToString & " *"

                End If

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.CustomColumnSortEvent

            'objects
            Dim Value1 As Decimal? = Nothing
            Dim Value2 As Decimal? = Nothing

            Try

                If e.Value1 Is Nothing Then

                    Value1 = CDec(1000000000)

                Else

                    Value1 = CDec(e.Value1)

                End If

                If e.Value2 Is Nothing Then

                    Value2 = CDec(1000000000)

                Else

                    Value2 = CDec(e.Value2)

                End If

                e.Handled = True
                e.Result = System.Collections.Comparer.Default.Compare(Value1, Value2)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_CustomDrawBandHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.BandedGrid.BandHeaderCustomDrawEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.CustomDrawBandHeaderEvent

            'objects
            Dim Font As System.Drawing.Font = Nothing

            If e.Band IsNot Nothing AndAlso e.Band.Name = "Copyright" Then

                Font = New System.Drawing.Font(e.Appearance.Font, Drawing.FontStyle.Regular)
                e.Appearance.Font = Font
                e.Appearance.ForeColor = System.Drawing.Color.Red

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_EndGroupingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.EndGroupingEvent

            'objects
            Dim AssignGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.OptionsView.ShowGroupPanel = (BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.GroupedColumns.Count > 0)

            For Each column In BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.GroupedColumns.Contains(column) Then

                    column.OwnerBand = Nothing

                Else

                    AssignGridBand = TryCast(column.Tag, DevExpress.XtraGrid.Views.BandedGrid.GridBand)

                    If AssignGridBand IsNot Nothing Then

                        column.OwnerBand = AssignGridBand

                    End If

                End If

            Next

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.ExpandAllGroups()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVPuertoRicoResults)

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_EndSortingEvent(sender As Object, e As EventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.EndSortingEvent

            BestFitBands(BandedDataGridViewSpotTVPuertoRicoResults)

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_PopupMenuShowingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.PopupMenuShowingEvent

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing

            If e.MenuType = DevExpress.XtraGrid.Views.Grid.GridMenuType.Column Then

                BlankGridBand = BandedDataGridViewSpotTVResults.CurrentView.Bands.Where(Function(Band) Band.Tag = "BLANK").FirstOrDefault

                For Each MenuItem In e.Menu.Items.OfType(Of DevExpress.Utils.Menu.DXMenuItem)()

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization)) OrElse
                            MenuItem.Caption.ToUpper = "COLUMN/BAND CHOOSER" OrElse
                            MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnRemoveColumn)) Then

                        MenuItem.Visible = False

                    End If

                    If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) OrElse
                                MenuItem.Caption.ToUpper.Equals("SHOW GROUP BY BOX") Then

                        MenuItem.Visible = False

                    End If

                    If BlankGridBand IsNot Nothing AndAlso Not BlankGridBand.Columns.Contains(e.HitInfo.Column) Then

                        If MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroup)) OrElse
                                MenuItem.Caption.Equals(DevExpress.XtraGrid.Localization.GridLocalizer.Active.GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId.MenuColumnGroupBox)) Then

                            MenuItem.Visible = False

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub BandedDataGridViewSpotTVPuertoRicoResults_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.RowCellStyleEvent

            If e.Column.FieldName.StartsWith("Rank") Then

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.GetRow(e.RowHandle) IsNot Nothing AndAlso e.CellValue.Equals(System.DBNull.Value) = False AndAlso
                        _ViewModel.SpotTVPuertoRicoReportDataTable IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoReportDataTable.Select(e.Column.FieldName & " = " & e.CellValue).Count > 1 Then

                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Italic)

                End If

            End If

        End Sub
        'Private Sub BandedDataGridViewSpotTVPuertoRicoResults_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles BandedDataGridViewSpotTVPuertoRicoResults.RowDoubleClickEvent

        '    'objects
        '    Dim BandedGridView As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView = Nothing
        '    Dim BandedGridHitInfo As DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo = Nothing
        '    Dim IDs() As String = Nothing
        '    Dim StationCode As Integer = 0
        '    Dim ColumnHandle As Integer = 0

        '    If (_ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook OrElse
        '            _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation) Then

        '        BandedGridView = TryCast(sender, DevExpress.XtraGrid.Views.BandedGrid.BandedGridView)

        '        If BandedGridView IsNot Nothing Then

        '            BandedGridHitInfo = BandedGridView.CalcHitInfo(e.Location)

        '            If BandedGridHitInfo IsNot Nothing AndAlso BandedGridHitInfo.InRowCell AndAlso BandedGridHitInfo.Column.FieldName.StartsWith(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.ProgramName.ToString) AndAlso
        '                    DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(BandedGridView.Columns(BandedGridHitInfo.Column.FieldName).ColumnHandle).ToString = "Various" Then

        '                If _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook Then

        '                    StationCode = Replace(BandedGridHitInfo.Column.FieldName, AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.ProgramName.ToString, "")

        '                End If

        '                For Each Column As DevExpress.XtraGrid.Columns.GridColumn In BandedGridView.Columns

        '                    If _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByBook AndAlso Column.FieldName = "BookIDDaytimeID" Then

        '                        ColumnHandle = Column.ColumnHandle
        '                        Exit For

        '                    ElseIf _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation AndAlso Column.FieldName = "BookIDDaytimeID" & BandedGridHitInfo.Band.Tag Then

        '                        ColumnHandle = Column.ColumnHandle
        '                        Exit For

        '                    ElseIf _ViewModel.SpotTVSelectedResearchCriteria.ReportType = AdvantageFramework.Database.Entities.SpotTVResearchReportType.TrendByStation AndAlso Column.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.StationCode.ToString Then

        '                        StationCode = DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(Column.ColumnHandle).ToString

        '                    End If

        '                Next

        '                If ColumnHandle <> 0 Then

        '                    IDs = DirectCast(BandedGridView.GetRow(e.RowHandle), System.Data.DataRowView).Row.ItemArray(ColumnHandle).ToString.Split("|")

        '                    If IDs.Length = 2 Then

        '                        _Controller.GetProgramDetails(_ViewModel, StationCode, IDs(0), IDs(1))

        '                        If Not String.IsNullOrWhiteSpace(_ViewModel.ProgramWeeks) Then

        '                            AdvantageFramework.WinForm.MessageBox.Show(_ViewModel.ProgramWeeks, Title:="Week - Program")

        '                        End If

        '                    End If

        '                End If

        '            End If

        '        End If

        '    End If

        'End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.CellValueChangedEvent

            _Controller.DayTimeCellChangedPuertoRico(_ViewModel)

            RefreshSpotTVPuertoRicoTab(False)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_CustomRowCellEditForEditingEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.CustomRowCellEditForEditingEvent

            'objects
            Dim RepositoryItemTextEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit = Nothing
            Dim RepositoryItemTimeEdit As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit = Nothing

            If e.Column.FieldName = AdvantageFramework.DTO.DaysAndTime.Properties.Days.ToString Then

                RepositoryItemTextEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit

                AddHandler RepositoryItemTextEdit.Enter, AddressOf RepositoryItem_Enter

                e.RepositoryItem = RepositoryItemTextEdit

            End If

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_EmbeddedNavigatorButtonClick(sender As Object, e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewSpotTVPuertoRico_DayTimes.CancelNewItemRow()

                        _Controller.DayTimeCancelNewItemRowPuertoRico(_ViewModel)

                        RefreshSpotTVPuertoRicoTab()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        _Controller.DeleteSelectedDayTimesPuertoRico(_ViewModel, DataGridViewSpotTVPuertoRico_DayTimes.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList)

                        RefreshSpotTVPuertoRicoTab()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.InitNewRowEvent

            DirectCast(DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.DaysAndTime).BroadcastType = DTO.DaysAndTime.BroadcastTypes.TVPuertoRico
            DirectCast(DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.DaysAndTime).IsUsing3rdPartyData = True

            _Controller.DayTimeInitNewRowPuertoRicoEvent(_ViewModel)

            RefreshSpotTVPuertoRicoTab(False)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.SelectionChangedEvent

            _Controller.DayTimeSelectionChangedPuertoRico(_ViewModel, DataGridViewSpotTVPuertoRico_DayTimes.IsNewItemRow,
                                                          DataGridViewSpotTVPuertoRico_DayTimes.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.DaysAndTime).ToList)

            RefreshSpotTVPuertoRicoTab(False)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                FocusedRow.BroadcastType = DTO.DaysAndTime.BroadcastTypes.TVPuertoRico

                ErrorText = _Controller.DayTimeValidateEntityProperty(FocusedRow, DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.SetColumnError(DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_DayTimes_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewSpotTVPuertoRico_DayTimes.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.DayTimeValidateEntity(e.Row, e.Valid)

                If DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewSpotTVPuertoRico_DayTimes.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        _Controller.DayTimeAddNewRowPuertoRicoEvent(_ViewModel)

                        RefreshSpotTVPuertoRicoTab(False)

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonSpotTVPuertoRicoDemographics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoDemographics_AddToSelected.Click

            _Controller.AddToSelectedPuertoRicoDemographics(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub ButtonSpotTVPuertoRicoDemographics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoDemographics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedPuertoRicoDemographics(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub ButtonSpotTVPuertoRicoMetrics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoMetrics_AddToSelected.Click

            _Controller.AddToSelectedSpotTVPuertoRicoMetrics(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub ButtonSpotTVPuertoRicoMetrics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoMetrics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotTVPuertoRicoMetrics(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub ButtonSpotTVPuertoRicoStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoStation_AddToSelected.Click

            _Controller.AddToSelectedSpotTVPuertoRicoStations(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub ButtonSpotTVPuertoRicoStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonSpotTVPuertoRicoStation_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedSpotTVPuertoRicoStations(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList)

            RefreshSpotTVPuertoRicoTab()

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_AvailableDemographics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_AvailableDemographics.RowDoubleClickEvent

            _Controller.AddToSelectedPuertoRicoDemographics(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_AvailableDemographics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_AvailableMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_AvailableMetrics.RowDoubleClickEvent

            _Controller.AddToSelectedSpotTVPuertoRicoMetrics(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_AvailableMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_AvailableStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_AvailableStations.RowDoubleClickEvent

            _Controller.AddToSelectedSpotTVPuertoRicoStations(_ViewModel, DataGridViewSpotTVPuertoRico_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_AvailableStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_SelectedDemographics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_SelectedDemographics.RowDoubleClickEvent

            _Controller.RemoveFromSelectedPuertoRicoDemographics(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedDemographics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Demographic).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_SelectedDemographics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_SelectedMetrics_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_SelectedMetrics.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotTVPuertoRicoMetrics(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_SelectedMetrics, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_SelectedStations_RowDoubleClickEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles DataGridViewSpotTVPuertoRico_SelectedStations.RowDoubleClickEvent

            _Controller.RemoveFromSelectedSpotTVPuertoRicoStations(_ViewModel, DataGridViewSpotTVPuertoRico_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station).ToList)

            RefreshSpotTVPuertoRicoTab()

            SelectAdjacentRow(DataGridViewSpotTVPuertoRico_SelectedStations, e.RowHandle)

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewSpotTVPuertoRico_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewSpotTVPuertoRico_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSelectedSpotTVPuertoRicoResearchCriteria(_ViewModel, DataGridViewSpotTVPuertoRico_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadSpotTVPuertoRicoViewModel(DirectCast(DataGridViewSpotTVPuertoRico_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchCriteria).ID, False)

                TabItemSpotTVPuertoRico_PeriodsDaysTimes.Tag = False

                'LoadSpotTVpuertoricoBooksTab()

                TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab = TabItemSpotTVPuertoRico_ReportTypeStations

                Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSpotTVPuertoRicoOptions_GroupByDaysTimes.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                _Controller.PuertoRicoOptionGroupByDaysTimesChanged(e.NewChecked.Checked, _ViewModel)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        Private Sub CheckBoxSpotTVPuertoRicoOptions_ShowProgramName_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSpotTVPuertoRicoOptions_ShowProgramName.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                _Controller.PuertoRicoOptionShowProgramNameChanged(e.NewChecked.Checked, _ViewModel)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        'Private Sub CheckBoxSpotTVPuertoRicoOptions_SubtotalByWeekdayWeekend_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxSpotTVPuertoRicoOptions_SubtotalByWeekdayWeekend.CheckedChangedEx

        '    If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

        '        _Controller.PuertoRicoOptionSubtotalByWeekdayWeekendChanged(e.NewChecked.Checked, _ViewModel)

        '        RefreshSpotTVPuertoRicoTab()

        '    End If

        'End Sub
        Private Sub ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.SelectedValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel IsNot Nothing Then

                _Controller.PuertoRicoReportTypeChanged(_ViewModel, ComboBoxSpotTVPuertoRicoReportTypeStation_ReportType.GetSelectedValue)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        Private Sub DateEditSpotTVPuertoRicoPeriod_ShareEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditSpotTVPuertoRicoPeriod_ShareEndDate.EditValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel IsNot Nothing Then

                _Controller.PuertoRicoDatesChanged(_ViewModel)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        Private Sub DateEditSpotTVPuertoRicoPeriod_ShareStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles DateEditSpotTVPuertoRicoPeriod_ShareStartDate.EditValueChanged

            If Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso _ViewModel IsNot Nothing Then

                _Controller.PuertoRicoDatesChanged(_ViewModel)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        Private Sub NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank_EditValueChanged(sender As Object, e As EventArgs) Handles NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetTVPuertoRicoMaxRank(_ViewModel, NumericInputSpotTVPuertoRicoReportTypeStation_MaximumRank.GetValue)

                RefreshSpotTVPuertoRicoTab()

            End If

        End Sub
        Private Sub ResizeTVPuertoRicoWarning()

            If TabControlForm_Tabs.SelectedTab.Equals(TabItemTabs_SpotTVPuertoRicoTab) AndAlso TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTab.Equals(TabItemSpotTVPuertoRico_Results) Then

                If (_ViewModel.SpotTVPuertoRicoResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoResearchResultList.Count > 0 AndAlso
                        _ViewModel.SpotTVPuertoRicoResearchResultList.Where(Function(Entity) Entity.ShowIntabWarning).Any) Then

                    LabelSpotTVPuertoRicoResults_Footer.Visible = True
                    BandedDataGridViewSpotTVPuertoRicoResults.Height = TabControlPanelSpotTVPuertoRicoResults_Results.Height - LabelSpotTVPuertoRicoResults_Footer.Height - 50

                Else

                    LabelSpotTVPuertoRicoResults_Footer.Visible = False
                    BandedDataGridViewSpotTVPuertoRicoResults.Height = TabControlPanelSpotTVPuertoRicoResults_Results.Height - 42

                End If

            End If

        End Sub
        'Private Sub TabControlSpotTVPuertoRico_ResearchCriteria_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTabChanging

        '    If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

        '        If e.NewTab.Equals(TabItemSpotTV_Books) Then

        '            If Not _ViewModel.IsMarketSelected Then

        '                Me.FormAction = WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

        '                e.Cancel = True

        '                AdvantageFramework.WinForm.MessageBox.Show("Please select a market first.")

        '                TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

        '                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        '            Else

        '                LoadSpotTVBooksTab()

        '            End If

        '        ElseIf Not _ViewModel.IsMarketSelected Then

        '            Me.FormAction = WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

        '            e.Cancel = True

        '            AdvantageFramework.WinForm.MessageBox.Show("Please select a market first.")

        '            TabControlSpotTV_ResearchCriteria.SelectedTab = TabItemSpotTV_MarketStations

        '            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        '        End If

        '    End If

        'End Sub
        Private Sub TabControlSpotTVPuertoRico_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlSpotTVPuertoRico_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_SelectedDemographics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTVPuertoRico_SelectedDemographics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewSpotTVPuertoRico_SelectedMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewSpotTVPuertoRico_SelectedMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub SetupSpotTVPuertoRicoTrendByDateDataBands()

            'objects
            Dim CopyrightGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim StationMetricsBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim StationMetricsBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BeginUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Bands.Clear()
            BandedDataGridViewSpotTVPuertoRicoResults.ClearGridCustomization()
            BandedDataGridViewSpotTVPuertoRicoResults.AutoUpdateViewCaption = False

            StationMetricsBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            CopyrightGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            CopyrightGridBand.Name = "Copyright"
            CopyrightGridBand.Caption = _NielsenPuertoRicoCopyright

            CopyrightGridBand.OptionsBand.AllowMove = False

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Bands.Add(CopyrightGridBand)

            BlankGridBand = CopyrightGridBand.Children.AddBand("")

            If _ViewModel.SpotTVPuertoRicoResearchResultList IsNot Nothing AndAlso _ViewModel.SpotTVPuertoRicoResearchResultList.Count > 0 Then

                BlankGridBand.Caption = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareStartDate.Value.ToShortDateString() & " - " & _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.ShareEndDate.Value.ToShortDateString() & " / " & _ViewModel.SpotTVPuertoRicoResearchResultList.First.Demographic

            End If

            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True
            BlankGridBand.OptionsBand.FixedWidth = True
            BlankGridBand.OptionsBand.AllowMove = False

            For Each ResearchResult In (From Entity In _ViewModel.SpotTVPuertoRicoResearchResultList
                                        Select Entity.Station,
                                               Entity.StationID).Distinct.OrderBy(Function(Entity) Entity.Station).ToList

                StationMetricsBand = CopyrightGridBand.Children.AddBand("")

                StationMetricsBand.Caption = ResearchResult.Station
                StationMetricsBand.Tag = ResearchResult.StationID
                StationMetricsBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                StationMetricsBand.AppearanceHeader.Options.UseTextOptions = True
                StationMetricsBand.OptionsBand.FixedWidth = True
                StationMetricsBand.OptionsBand.AllowMove = False

                StationMetricsBands.Add(StationMetricsBand)

            Next

            BandedDataGridViewSpotTVPuertoRicoResults.ClearDatasource(_ViewModel.SpotTVPuertoRicoReportDataTable.Clone)

            BandedDataGridViewSpotTVPuertoRicoResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewSpotTVPuertoRicoResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.TrendDate.ToString OrElse
                        GridColumn.FieldName = "Day" OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.Times.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)
                    GridColumn.Tag = BlankGridBand

                    If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTVPuertoRico.ResearchResult.Properties.TrendDate.ToString Then

                        GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                        GridColumn.Caption = "Date"

                    End If

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Station") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each StationMetricsBand In StationMetricsBands

                For Each GridColumn In BandedDataGridViewSpotTVPuertoRicoResults.Columns

                    If GridColumn.FieldName.EndsWith("_" & StationMetricsBand.Tag) Then

                        StationMetricsBand.Columns.Add(GridColumn)

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.Caption = "Aud (000)"
                            GridColumn.DisplayFormat.FormatString = "n1"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            GridColumn.Caption = "H/PUT"

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.Caption = "Sample Size"
                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("ProgramName") Then

                            GridColumn.Caption = "Program Name"

                        ElseIf GridColumn.FieldName.StartsWith("ShowIntabWarning") Then

                            GridColumn.Visible = False

                        End If

                    End If

                Next

            Next

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.ViewCaption = _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.CriteriaName & " (Trend By Date)"
            BandedDataGridViewSpotTVPuertoRicoResults.DataSource = _ViewModel.SpotTVPuertoRicoReportDataTable

            If _ViewModel.SpotTVPuertoRicoSelectedResearchCriteria.GroupByDaysTimes Then

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString).Group()

                End If

                If BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString) IsNot Nothing Then

                    BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.Columns(AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString).Group()

                End If

            End If

            BandedDataGridViewSpotTVPuertoRicoResults.OptionsBehavior.Editable = False

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.EndUpdate()

            BandedDataGridViewSpotTVPuertoRicoResults.CurrentView.BestFitColumns()

            BestFitBands(BandedDataGridViewSpotTVPuertoRicoResults)

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
