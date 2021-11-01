Namespace Media.Presentation

    Public Class SpotRadioResearchForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.SpotRadioResearchViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.SpotRadioResearchController = Nothing

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

            If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(DTO.Media.Methods.ResearchCriteriaTypes.SpotRadio, BroadcastResearchToolReportEditDialog.ResearchType.SpotRadio, ResearchID) = Windows.Forms.DialogResult.OK Then

                LoadViewModel(ResearchID, True)

            End If

        End Sub
        Private Sub EditCriteria()

            'objects
            Dim ResearchID As Nullable(Of Integer) = Nothing
            Dim ErrorMessage As String = ""

            ResearchID = _ViewModel.SelectedResearchCriteria.ID

            If AdvantageFramework.Media.Presentation.BroadcastResearchToolReportEditDialog.ShowFormDialog(DTO.Media.Methods.ResearchCriteriaTypes.SpotRadio, BroadcastResearchToolReportEditDialog.ResearchType.SpotRadio, _ViewModel.SelectedResearchCriteria.ID) = Windows.Forms.DialogResult.OK Then

                LoadViewModel(ResearchID, False)

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If _ViewModel.SaveEnabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Save()

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.Saving)

                SaveViewModel()

                Saved = _Controller.Save(_ViewModel, ErrorMessage)

                Me.SetFormActionAndShowWaitForm(WinForm.Presentation.Methods.FormActions.None)

                If Saved Then

                    LoadViewModel(_ViewModel.SelectedResearchCriteria.ID, True)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            RibbonBarOptions_DayTimes.Visible = TabControlForm_ResearchCriteria.SelectedTab.Equals(TabItemResearchCriteria_DaysTimes)
            RibbonBarOptions_Books.Visible = TabControlForm_ResearchCriteria.SelectedTab.Equals(TabItemResearchCriteria_Books)
            RibbonBarOptions_Metrics.Visible = TabControlForm_ResearchCriteria.SelectedTab.Equals(TabItemResearchCriteria_Metrics)

            ButtonItemMetrics_Up.Enabled = RibbonBarOptions_Metrics.Visible AndAlso DataGridViewRightSection_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                DataGridViewRightSection_SelectedMetrics.CurrentView.FocusedRowHandle > 0
            ButtonItemMetrics_Down.Enabled = RibbonBarOptions_Metrics.Visible AndAlso DataGridViewRightSection_SelectedMetrics.HasOnlyOneSelectedRow AndAlso
                DataGridViewRightSection_SelectedMetrics.CurrentView.FocusedRowHandle <> DataGridViewRightSection_SelectedMetrics.CurrentView.RowCount - 1

        End Sub
        Private Sub LoadViewModel(ResearchID As Nullable(Of Integer), LoadGrid As Boolean)

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            _ViewModel = _Controller.Load(ResearchID)

            SearchableComboBoxMarket_Market.DataSource = _ViewModel.RadioMarketList
            SearchableComboBoxMarket_Demographic.DataSource = _ViewModel.MediaDemographicList
            SearchableComboBoxMarket_Qualitative.DataSource = _ViewModel.NielsenRadioQualitativeList

            If LoadGrid Then

                DataGridViewLeftSection_UserCriterias.DataSource = _ViewModel.ResearchCriteriaList

                If DataGridViewLeftSection_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.CriteriaName.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_UserCriterias.Columns(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.CriteriaName.ToString).BestFit()

                End If

            Else

                DataGridViewLeftSection_UserCriterias.CurrentView.RefreshData()

            End If

            If _ViewModel.SelectedResearchCriteria Is Nothing Then

                DataGridViewLeftSection_UserCriterias.FocusToFindPanel(True)

                SearchableComboBoxMarket_Market.SelectedValue = Nothing

                SetGroupBoxRadioButton(GroupBoxMarket_OutputType, 1)
                SetGroupBoxRadioButton(GroupBoxMarket_Geography, 1)
                SetGroupBoxRadioButton(GroupBoxMarket_ListeningType, 1)
                SetGroupBoxRadioButton(GroupBoxMarket_Ethnicity, 1)

                CheckBoxInclude_ERadio.Checked = False
                CheckBoxInclude_Networks.Checked = False
                CheckBoxInclude_OTAIS.Checked = False
                CheckBoxInclude_Simulcast.Checked = False
                CheckBoxInclude_Stations.Checked = True
                CheckBoxInclude_TotalListening.Checked = False
                CheckBoxInclude_XCodes.Checked = False

            Else

                DataGridViewLeftSection_UserCriterias.SelectRow(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.ID.ToString, _ViewModel.SelectedResearchCriteria.ID, True)

                SearchableComboBoxMarket_Market.SelectedValue = _ViewModel.SelectedResearchCriteria.MarketCode
                SearchableComboBoxMarket_Demographic.SelectedValue = _ViewModel.SelectedResearchCriteria.MediaDemoID
                SearchableComboBoxMarket_Qualitative.SelectedValue = _ViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID

                SetGroupBoxRadioButton(GroupBoxMarket_OutputType, _ViewModel.SelectedResearchCriteria.OutputType)
                SetGroupBoxRadioButton(GroupBoxMarket_Geography, _ViewModel.SelectedResearchCriteria.Geography)
                SetGroupBoxRadioButton(GroupBoxMarket_ListeningType, _ViewModel.SelectedResearchCriteria.ListeningType)
                SetGroupBoxRadioButton(GroupBoxMarket_Ethnicity, _ViewModel.SelectedResearchCriteria.Ethnicity)

                CheckBoxInclude_ERadio.Checked = _ViewModel.SelectedResearchCriteria.IncludeERadio
                CheckBoxInclude_Networks.Checked = _ViewModel.SelectedResearchCriteria.IncludeNetworks
                CheckBoxInclude_OTAIS.Checked = _ViewModel.SelectedResearchCriteria.IncludeOTAIS
                CheckBoxInclude_Simulcast.Checked = _ViewModel.SelectedResearchCriteria.IncludeSimulcast
                CheckBoxInclude_Stations.Checked = _ViewModel.SelectedResearchCriteria.IncludeStations
                CheckBoxInclude_TotalListening.Checked = _ViewModel.SelectedResearchCriteria.IncludeTotalListening
                CheckBoxInclude_XCodes.Checked = _ViewModel.SelectedResearchCriteria.IncludeXCodes

                DataGridViewBooks_Books.DataSource = _ViewModel.NielsenRadioBookList
                DataGridViewBooks_Books.CurrentView.BestFitColumns()

                DataGridViewDayparts_Dayparts.DataSource = _ViewModel.NielsenDaypartList
                DataGridViewDayparts_Dayparts.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableMetrics.DataSource = _ViewModel.AvailableMetricList
                DataGridViewLeftSection_AvailableMetrics.CurrentView.BestFitColumns()

                DataGridViewRightSection_SelectedMetrics.DataSource = _ViewModel.SelectedMetricList
                DataGridViewRightSection_SelectedMetrics.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableStations.DataSource = _ViewModel.AvailableStationList
                DataGridViewLeftSection_AvailableStations.CurrentView.BestFitColumns()

                DataGridViewRightSection_SelectedStations.DataSource = _ViewModel.SelectedStationList
                DataGridViewRightSection_SelectedStations.CurrentView.BestFitColumns()

                DataGridViewLeftSection_AvailableFormats.DataSource = _ViewModel.AvailableNielsenRadioFormatList
                DataGridViewLeftSection_AvailableFormats.CurrentView.BestFitColumns()

                DataGridViewRightSection_SelectedFormats.DataSource = _ViewModel.SelectedNielsenRadioFormatList
                DataGridViewRightSection_SelectedFormats.CurrentView.BestFitColumns()

            End If

            RefreshViewModel()

            Me.ClearChanged()

            Me.FormAction = WinForm.Presentation.Methods.FormActions.None

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.SelectedResearchCriteria.MarketCode = SearchableComboBoxMarket_Market.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.MediaDemoID = SearchableComboBoxMarket_Demographic.GetSelectedValue
            _ViewModel.SelectedResearchCriteria.NielsenRadioQualitativeID = SearchableComboBoxMarket_Qualitative.GetSelectedValue

            _ViewModel.SelectedResearchCriteria.OutputType = GetGroupBoxRadioButtonValue(GroupBoxMarket_OutputType)
            _ViewModel.SelectedResearchCriteria.Geography = GetGroupBoxRadioButtonValue(GroupBoxMarket_Geography)
            _ViewModel.SelectedResearchCriteria.ListeningType = GetGroupBoxRadioButtonValue(GroupBoxMarket_ListeningType)
            _ViewModel.SelectedResearchCriteria.Ethnicity = GetGroupBoxRadioButtonValue(GroupBoxMarket_Ethnicity)

            _ViewModel.SelectedResearchCriteria.IncludeERadio = CheckBoxInclude_ERadio.Checked
            _ViewModel.SelectedResearchCriteria.IncludeNetworks = CheckBoxInclude_Networks.Checked
            _ViewModel.SelectedResearchCriteria.IncludeOTAIS = CheckBoxInclude_OTAIS.Checked
            _ViewModel.SelectedResearchCriteria.IncludeSimulcast = CheckBoxInclude_Simulcast.Checked
            _ViewModel.SelectedResearchCriteria.IncludeStations = CheckBoxInclude_Stations.Checked
            _ViewModel.SelectedResearchCriteria.IncludeTotalListening = CheckBoxInclude_TotalListening.Checked
            _ViewModel.SelectedResearchCriteria.IncludeXCodes = CheckBoxInclude_XCodes.Checked

            _ViewModel.NielsenRadioBookList = DataGridViewBooks_Books.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList

            _ViewModel.NielsenDaypartList = DataGridViewDayparts_Dayparts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList

            _ViewModel.SelectedMetricList = DataGridViewRightSection_SelectedMetrics.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList

            _ViewModel.SelectedStationList = DataGridViewRightSection_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList

            _ViewModel.SelectedNielsenRadioFormatList = DataGridViewRightSection_SelectedFormats.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenRadioFormat).ToList

        End Sub
        Private Sub SetupRankerDataBands()

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim DemoBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim DemoBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim VisibleIndex As Integer = 0
            Dim DoneSorting As Boolean = False

            BandedDataGridViewResults.CurrentView.BeginUpdate()

            BandedDataGridViewResults.CurrentView.Bands.Clear()
            BandedDataGridViewResults.ClearGridCustomization()

            DemoBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            BlankGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            BlankGridBand.Caption = " "
            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True

            BandedDataGridViewResults.CurrentView.Bands.Add(BlankGridBand)

            For Each ResearchResult In (From Entity In _ViewModel.ResearchResultList
                                        Select Entity.DemographicOrder, Entity.DemographicStream).OrderBy(Function(Entity) Entity.DemographicOrder).Distinct.ToList

                DemoBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                DemoBand.Caption = ResearchResult.DemographicStream
                DemoBand.Tag = ResearchResult.DemographicOrder
                DemoBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                DemoBand.AppearanceHeader.Options.UseTextOptions = True

                BandedDataGridViewResults.CurrentView.Bands.Add(DemoBand)

                DemoBands.Add(DemoBand)

            Next

            BandedDataGridViewResults.ClearDatasource(_ViewModel.ReportDataTable.Clone)

            BandedDataGridViewResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Station.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Demo") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each DemoBand In DemoBands

                For Each GridColumn In BandedDataGridViewResults.Columns

                    If GridColumn.FieldName.EndsWith(DemoBand.Tag) Then

                        DemoBand.Columns.Add(GridColumn)

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        End If

                    End If

                Next

            Next

            BandedDataGridViewResults.DataSource = _ViewModel.ReportDataTable
            BandedDataGridViewResults.CurrentView.BestFitColumns()

            If _ViewModel.ReportDataTable.Rows.Count > 0 AndAlso BandedDataGridViewResults.CurrentView.Columns("Rank1") IsNot Nothing Then

                BandedDataGridViewResults.CurrentView.ClearSorting()
                BandedDataGridViewResults.CurrentView.BeginSort()
                BandedDataGridViewResults.CurrentView.Columns("Rank1").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                VisibleIndex = BandedDataGridViewResults.CurrentView.Columns("Rank1").VisibleIndex + 1

                While Not DoneSorting AndAlso BandedDataGridViewResults.CurrentView.Columns(VisibleIndex + 1) IsNot Nothing

                    If BandedDataGridViewResults.CurrentView.Columns(VisibleIndex + 1).FieldName.StartsWith("Rank") Then

                        DoneSorting = True

                    Else

                        BandedDataGridViewResults.CurrentView.Columns(VisibleIndex + 1).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                    End If

                    VisibleIndex += 1

                    If VisibleIndex > BandedDataGridViewResults.CurrentView.VisibleColumns.Count - 1 Then

                        DoneSorting = True

                    End If

                End While

                BandedDataGridViewResults.CurrentView.EndSort()

            End If

            BandedDataGridViewResults.CurrentView.EndUpdate()

        End Sub
        Private Sub SetupTrendDataBands()

            'objects
            Dim BlankGridBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim MonthYearBands As Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand) = Nothing
            Dim MonthYearBand As DevExpress.XtraGrid.Views.BandedGrid.GridBand = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BandedDataGridViewResults.CurrentView.BeginUpdate()

            BandedDataGridViewResults.CurrentView.Bands.Clear()
            BandedDataGridViewResults.ClearGridCustomization()

            MonthYearBands = New Generic.List(Of DevExpress.XtraGrid.Views.BandedGrid.GridBand)

            BlankGridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
            BlankGridBand.Caption = " "
            BlankGridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            BlankGridBand.AppearanceHeader.Options.UseTextOptions = True

            BandedDataGridViewResults.CurrentView.Bands.Add(BlankGridBand)

            For Each ResearchResult In (From Entity In _ViewModel.ResearchResultList
                                        Select Entity.MonthYear, Entity.Stream, Entity.StreamYear, Entity.StreamMonth).OrderBy(Function(Entity) Entity.StreamYear).ThenBy(Function(Entity) Entity.StreamMonth).Distinct.ToList

                MonthYearBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand
                MonthYearBand.Caption = ResearchResult.Stream & " - " & ResearchResult.MonthYear
                MonthYearBand.Tag = ResearchResult.StreamYear.ToString & ResearchResult.StreamMonth.ToString
                MonthYearBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                MonthYearBand.AppearanceHeader.Options.UseTextOptions = True

                BandedDataGridViewResults.CurrentView.Bands.Add(MonthYearBand)

                MonthYearBands.Add(MonthYearBand)

            Next

            BandedDataGridViewResults.ClearDatasource(_ViewModel.ReportDataTable.Clone)

            BandedDataGridViewResults.ItemDescription = "Research Result(s)"

            For Each GridColumn In BandedDataGridViewResults.Columns

                If GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.IsSpill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Station.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Days.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.DTO.Media.SpotTV.ResearchResult.Properties.Times.ToString Then

                    BlankGridBand.Columns.Add(GridColumn)

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("MonthYear") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) AndAlso GridColumn.FieldName.StartsWith("Stream") Then

                    GridColumn.Visible = False

                ElseIf IsNumeric(Mid(GridColumn.FieldName, GridColumn.FieldName.Length, 1)) Then

                    GridColumn.Caption = AdvantageFramework.StringUtilities.RemoveAllNonAlpha(GridColumn.FieldName)

                End If

            Next

            For Each MonthYearBand In MonthYearBands

                For Each GridColumn In BandedDataGridViewResults.Columns

                    If GridColumn.FieldName.EndsWith(MonthYearBand.Tag) Then

                        MonthYearBand.Columns.Add(GridColumn)

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric

                        If GridColumn.FieldName.StartsWith("Rating") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Share") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Impressions") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("HPUT") Then

                            GridColumn.DisplayFormat.FormatString = "n2"

                        ElseIf GridColumn.FieldName.StartsWith("Intab") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        ElseIf GridColumn.FieldName.StartsWith("Universe") Then

                            GridColumn.DisplayFormat.FormatString = "n0"

                        End If

                    End If

                Next

            Next

            BandedDataGridViewResults.DataSource = _ViewModel.ReportDataTable
            BandedDataGridViewResults.CurrentView.BestFitColumns()

            If _ViewModel.ReportDataTable.Rows.Count > 0 AndAlso BandedDataGridViewResults.CurrentView.Columns("Station") IsNot Nothing Then

                BandedDataGridViewResults.CurrentView.ClearSorting()
                BandedDataGridViewResults.CurrentView.BeginSort()
                BandedDataGridViewResults.CurrentView.Columns("Station").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                BandedDataGridViewResults.CurrentView.EndSort()

            End If

            BandedDataGridViewResults.CurrentView.EndUpdate()

        End Sub
        Private Sub RefreshViewModel(Optional RefreshData As Boolean = True)

            TabControlForm_ResearchCriteria.Enabled = (_ViewModel.SelectedResearchCriteria IsNot Nothing)

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Process.Enabled = _ViewModel.ProcessEnabled

            ButtonItemBooks_Cancel.Enabled = _ViewModel.BookCancelEnabled
            ButtonItemBooks_Delete.Enabled = _ViewModel.BookDeleteEnabled

            ButtonItemDayTimes_Cancel.Enabled = _ViewModel.DaypartCancelEnabled
            ButtonItemDayTimes_Delete.Enabled = _ViewModel.DaypartDeleteEnabled

            TabItemResearchCriteria_Results.Visible = _ViewModel.ProcessEnabled

            If RefreshData Then

                DataGridViewBooks_Books.DataSource = Nothing
                DataGridViewBooks_Books.DataSource = _ViewModel.NielsenRadioBookList

                DataGridViewLeftSection_AvailableStations.DataSource = Nothing
                DataGridViewLeftSection_AvailableStations.DataSource = _ViewModel.AvailableStationList

                DataGridViewRightSection_SelectedStations.DataSource = Nothing
                DataGridViewRightSection_SelectedStations.DataSource = _ViewModel.SelectedStationList

                DataGridViewDayparts_Dayparts.DataSource = Nothing
                DataGridViewDayparts_Dayparts.DataSource = _ViewModel.NielsenDaypartList

                DataGridViewLeftSection_AvailableFormats.DataSource = Nothing
                DataGridViewLeftSection_AvailableFormats.DataSource = _ViewModel.AvailableNielsenRadioFormatList

                DataGridViewRightSection_SelectedFormats.DataSource = Nothing
                DataGridViewRightSection_SelectedFormats.DataSource = _ViewModel.SelectedNielsenRadioFormatList

                DataGridViewLeftSection_AvailableMetrics.DataSource = Nothing
                DataGridViewLeftSection_AvailableMetrics.DataSource = _ViewModel.AvailableMetricList

                DataGridViewRightSection_SelectedMetrics.DataSource = Nothing
                DataGridViewRightSection_SelectedMetrics.DataSource = _ViewModel.SelectedMetricList

                If _ViewModel.ReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.OutputType = AdvantageFramework.Database.Entities.SpotRadioResearchOutputType.Ranker Then

                    SetupRankerDataBands()

                ElseIf _ViewModel.ReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.OutputType = AdvantageFramework.Database.Entities.SpotRadioResearchOutputType.Trend Then

                    SetupTrendDataBands()

                ElseIf _ViewModel.ReportDataTable IsNot Nothing AndAlso _ViewModel.ProcessEnabled AndAlso _ViewModel.SelectedResearchCriteria.OutputType = AdvantageFramework.Database.Entities.SpotRadioResearchOutputType.AudienceComp Then



                Else

                    BandedDataGridViewResults.CurrentView.Bands.Clear()
                    BandedDataGridViewResults.ClearGridCustomization()

                End If

            End If

            EnableOrDisableActions()

        End Sub
        Private Function GetGroupBoxRadioButtonValue(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox) As Object

            'objects
            Dim ObjectValue As Object = Nothing

            For Each RadioButtonControl In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Checked Then

                    ObjectValue = RadioButtonControl.Tag
                    Exit For

                End If

            Next

            GetGroupBoxRadioButtonValue = ObjectValue

        End Function
        Private Sub SetGroupBoxRadioButton(GroupBox As AdvantageFramework.WinForm.Presentation.Controls.GroupBox, TagValue As Object)

            For Each RadioButtonControl In GroupBox.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl)

                If RadioButtonControl.Tag = TagValue Then

                    RadioButtonControl.Checked = True
                    Exit For

                End If

            Next

        End Sub
        Private Sub OutputTypeChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetOutputType(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag))

                RefreshViewModel()

            End If

        End Sub
        Private Sub GeographyChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetGeography(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag))

                RefreshViewModel()

            End If

        End Sub
        Private Sub ListeningTypeChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetListeningType(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag))

                RefreshViewModel()

            End If

        End Sub
        Private Sub EthnicityChanged(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs)

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetEthnicity(_ViewModel, CShort(DirectCast(e.NewChecked, AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl).Tag))

                RefreshViewModel()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SpotRadioResearchForm As AdvantageFramework.Media.Presentation.SpotRadioResearchForm = Nothing

            SpotRadioResearchForm = New AdvantageFramework.Media.Presentation.SpotRadioResearchForm

            SpotRadioResearchForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SpotRadioResearchForm_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler RadioButtonOutput_AudienceComp.CheckedChangedEx, AddressOf OutputTypeChanged
            RemoveHandler RadioButtonOutput_Ranker.CheckedChangedEx, AddressOf OutputTypeChanged
            RemoveHandler RadioButtonOutput_Trend.CheckedChangedEx, AddressOf OutputTypeChanged

            RemoveHandler RadioButtonGeography_DMA.CheckedChangedEx, AddressOf GeographyChanged
            RemoveHandler RadioButtonGeography_Metro.CheckedChangedEx, AddressOf GeographyChanged
            RemoveHandler RadioButtonGeography_TSA.CheckedChangedEx, AddressOf GeographyChanged

            RemoveHandler RadioButtonListeningType_Car.CheckedChangedEx, AddressOf ListeningTypeChanged
            RemoveHandler RadioButtonListeningType_Home.CheckedChangedEx, AddressOf ListeningTypeChanged
            RemoveHandler RadioButtonListeningType_OOH.CheckedChangedEx, AddressOf ListeningTypeChanged
            RemoveHandler RadioButtonListeningType_Total.CheckedChangedEx, AddressOf ListeningTypeChanged
            RemoveHandler RadioButtonListeningType_Work.CheckedChangedEx, AddressOf ListeningTypeChanged

            RemoveHandler RadioButtonEthnicity_All.CheckedChangedEx, AddressOf EthnicityChanged
            RemoveHandler RadioButtonEthnicity_Black.CheckedChangedEx, AddressOf EthnicityChanged
            RemoveHandler RadioButtonEthnicity_Hispanic.CheckedChangedEx, AddressOf EthnicityChanged
            RemoveHandler RadioButtonEthnicity_IAS.CheckedChangedEx, AddressOf EthnicityChanged

        End Sub
        Private Sub SpotRadioResearchForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            e.Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub SpotRadioResearchForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            AddHandler RadioButtonOutput_AudienceComp.CheckedChangedEx, AddressOf OutputTypeChanged
            AddHandler RadioButtonOutput_Ranker.CheckedChangedEx, AddressOf OutputTypeChanged
            AddHandler RadioButtonOutput_Trend.CheckedChangedEx, AddressOf OutputTypeChanged

            AddHandler RadioButtonGeography_DMA.CheckedChangedEx, AddressOf GeographyChanged
            AddHandler RadioButtonGeography_Metro.CheckedChangedEx, AddressOf GeographyChanged
            AddHandler RadioButtonGeography_TSA.CheckedChangedEx, AddressOf GeographyChanged

            AddHandler RadioButtonListeningType_Car.CheckedChangedEx, AddressOf ListeningTypeChanged
            AddHandler RadioButtonListeningType_Home.CheckedChangedEx, AddressOf ListeningTypeChanged
            AddHandler RadioButtonListeningType_OOH.CheckedChangedEx, AddressOf ListeningTypeChanged
            AddHandler RadioButtonListeningType_Total.CheckedChangedEx, AddressOf ListeningTypeChanged
            AddHandler RadioButtonListeningType_Work.CheckedChangedEx, AddressOf ListeningTypeChanged

            AddHandler RadioButtonEthnicity_All.CheckedChangedEx, AddressOf EthnicityChanged
            AddHandler RadioButtonEthnicity_Black.CheckedChangedEx, AddressOf EthnicityChanged
            AddHandler RadioButtonEthnicity_Hispanic.CheckedChangedEx, AddressOf EthnicityChanged
            AddHandler RadioButtonEthnicity_IAS.CheckedChangedEx, AddressOf EthnicityChanged

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

            ButtonItemDayTimes_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemDayTimes_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemBooks_Cancel.Image = AdvantageFramework.My.Resources.DetailCancelImage
            ButtonItemBooks_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage

            ButtonItemMetrics_Up.Image = AdvantageFramework.My.Resources.UpImage
            ButtonItemMetrics_Down.Image = AdvantageFramework.My.Resources.DownImage

            SearchableComboBoxMarket_Market.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.MarketCode)
            SearchableComboBoxMarket_Demographic.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.MediaDemoID)
            SearchableComboBoxMarket_Qualitative.SetPropertySettings(AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.NielsenRadioQualitativeID)

            DataGridViewLeftSection_UserCriterias.OptionsFind.AlwaysVisible = True
            DataGridViewLeftSection_UserCriterias.OptionsBehavior.Editable = False
            DataGridViewLeftSection_UserCriterias.MultiSelect = False

            DataGridViewLeftSection_AvailableStations.OptionsBehavior.Editable = False
            DataGridViewRightSection_SelectedStations.OptionsBehavior.Editable = False

            DataGridViewDayparts_Dayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            DataGridViewLeftSection_AvailableFormats.OptionsBehavior.Editable = False
            DataGridViewRightSection_SelectedFormats.OptionsBehavior.Editable = False

            DataGridViewLeftSection_AvailableMetrics.OptionsBehavior.Editable = False
            DataGridViewRightSection_SelectedMetrics.OptionsBehavior.Editable = False

            DataGridViewRightSection_SelectedFormats.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewRightSection_SelectedFormats.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_SelectedFormats.CurrentView.OptionsCustomization.AllowSort = False

            DataGridViewRightSection_SelectedMetrics.CurrentView.OptionsMenu.EnableColumnMenu = False
            DataGridViewRightSection_SelectedMetrics.CurrentView.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_SelectedMetrics.CurrentView.OptionsCustomization.AllowSort = False

            _Controller = New AdvantageFramework.Controller.Media.SpotRadioResearchController(Me.Session)

            LoadViewModel(Nothing, True)

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub BandedDataGridViewResults_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles BandedDataGridViewResults.CustomDrawCellEvent

            If e.Column.FieldName.StartsWith("Rank") Then

                If BandedDataGridViewResults.CurrentView.GetRow(e.RowHandle) IsNot Nothing AndAlso _ViewModel.ReportDataTable.Select(e.Column.FieldName & " = " & e.CellValue).Count > 1 Then

                    e.Appearance.Font = New System.Drawing.Font(e.Appearance.Font, System.Drawing.FontStyle.Italic)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            If CheckForUnsavedChanges() Then

                AddCriteria()

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete '" & _ViewModel.SelectedResearchCriteria.CriteriaName & "'?", WinForm.MessageBox.MessageBoxButtons.YesNo, "Confirm Delete") = WinForm.MessageBox.DialogResults.Yes Then

                If Not _Controller.Delete(_ViewModel, ErrorMessage) Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    LoadViewModel(Nothing, True)

                End If

            End If

        End Sub
        'Private Sub ButtonItemActions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Edit.Click

        '    EditCriteria()

        'End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            BandedDataGridViewResults.Print(DefaultLookAndFeel.LookAndFeel, "Spot TV Research", _Controller.GetAgency, UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim ErrorMessage As String = Nothing

            Me.ShowWaitForm("Processing...")

            SaveViewModel()

            'If _Controller.RunReport(_ViewModel, ErrorMessage) Then

            '    RefreshViewModel()

            '    TabControlForm_ResearchCriteria.SelectedTab = TabItemResearchCriteria_Results

            'Else

            '    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            'End If

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemBooks_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemBooks_Cancel.Click

            DataGridViewBooks_Books.CancelNewItemRow()

            _Controller.BookCancelNewItemRow(_ViewModel)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemBooks_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemBooks_Delete.Click

            _Controller.DeleteSelectedBooks(_ViewModel, DataGridViewBooks_Books.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDayTimes_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemDayTimes_Cancel.Click

            DataGridViewDayparts_Dayparts.CancelNewItemRow()

            _Controller.DaypartCancelNewItemRow(_ViewModel)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemDayTimes_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemDayTimes_Delete.Click

            _Controller.DeleteSelectedDayparts(_ViewModel, DataGridViewDayparts_Dayparts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonItemMetrics_Down_Click(sender As Object, e As EventArgs) Handles ButtonItemMetrics_Down.Click

            Dim SelectedID As Integer = 0

            SelectedID = DirectCast(DataGridViewRightSection_SelectedMetrics.GetFirstSelectedRowDataBoundItem, DTO.Media.Metric).ID

            _Controller.MoveMetric(_ViewModel, DataGridViewRightSection_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.SpotTVResearchController.MoveItemDirection.Down)

            RefreshViewModel()

            DataGridViewRightSection_SelectedMetrics.SelectRow(0, SelectedID)

        End Sub
        Private Sub ButtonItemMetrics_Up_Click(sender As Object, e As EventArgs) Handles ButtonItemMetrics_Up.Click

            Dim SelectedID As Integer = 0

            SelectedID = DirectCast(DataGridViewRightSection_SelectedMetrics.GetFirstSelectedRowDataBoundItem, DTO.Media.Metric).ID

            _Controller.MoveMetric(_ViewModel, DataGridViewRightSection_SelectedMetrics.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Controller.Media.SpotTVResearchController.MoveItemDirection.Up)

            RefreshViewModel()

            DataGridViewRightSection_SelectedMetrics.SelectRow(0, SelectedID)

        End Sub
        Private Sub ButtonRightSectionFormats_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionFormats_AddToSelected.Click

            _Controller.AddToSelectedFormats(_ViewModel, DataGridViewLeftSection_AvailableFormats.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenRadioFormat).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSectionFormats_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionFormats_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedFormats(_ViewModel, DataGridViewRightSection_SelectedFormats.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenRadioFormat).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSectionMetrics_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionMetrics_AddToSelected.Click

            _Controller.AddToSelectedMetrics(_ViewModel, DataGridViewLeftSection_AvailableMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSectionMetrics_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionMetrics_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedMetrics(_ViewModel, DataGridViewRightSection_SelectedMetrics.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.Metric).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSectionStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionStation_AddToSelected.Click

            _Controller.AddToSelectedStations(_ViewModel, DataGridViewLeftSection_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshViewModel()

        End Sub
        Private Sub ButtonRightSectionStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonRightSectionStation_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedStations(_ViewModel, DataGridViewRightSection_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.Station).ToList)

            RefreshViewModel()

        End Sub
        Private Sub CheckBoxInclude_ERadio_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_ERadio.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeERadio, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_Networks_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_Networks.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeNetworks, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_OTAIS_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_OTAIS.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeOTAIS, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_Simulcast_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_Simulcast.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeSimulcast, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_Stations_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_Stations.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeStations, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_TotalListening_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_TotalListening.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeTotalListening, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub CheckBoxInclude_XCodes_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxInclude_XCodes.CheckedChangedEx

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetIncludeOption(_ViewModel, AdvantageFramework.Database.Entities.MediaSpotRadioResearch.Properties.IncludeXCodes, e.NewChecked.Checked)

                RefreshViewModel()

            End If

        End Sub
        Private Sub DataGridViewBooks_Books_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewBooks_Books.CellValueChangedEvent

            _Controller.BookCellChanged(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewBooks_Books_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewBooks_Books.InitNewRowEvent

            _Controller.BookInitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewBooks_Books_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewBooks_Books.QueryPopupNeedDatasourceEvent

            Datasource = _Controller.GetRepositoryNielsenRadioPeriods(_ViewModel)
            OverrideDefaultDatasource = True

        End Sub
        Private Sub DataGridViewBooks_Books_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewBooks_Books.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID2.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID3.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID4.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID5.ToString Then

                Datasource = _ViewModel.NielsenRadioPeriodRepository

            End If

        End Sub
        Private Sub DataGridViewBooks_Books_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewBooks_Books.SelectionChangedEvent

            _Controller.BookSelectionChanged(_ViewModel, DataGridViewDayparts_Dayparts.IsNewItemRow,
                                             DataGridViewBooks_Books.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook).ToList)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewBooks_Books_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewBooks_Books.ShowingEditorEvent

            If DataGridViewBooks_Books.CurrentView.FocusedColumn.FieldName = AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook.Properties.NielsenRadioPeriodID1.ToString Then

                e.Cancel = (DataGridViewBooks_Books.IsNewItemRow = False)

            End If

        End Sub
        Private Sub DataGridViewBooks_Books_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewBooks_Books.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateBook(_ViewModel, e.Row, e.Valid)

                If DataGridViewBooks_Books.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewBooks_Books.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        RefreshViewModel(False)

                        DataGridViewBooks_Books.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                        DataGridViewBooks_Books.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    End If

                End If

            End If

        End Sub
        'Private Sub DataGridViewBooks_Books_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewBooks_Books.ValidatingEditorEvent

        '    'objects
        '    Dim FocusedRow As AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook = Nothing
        '    Dim ErrorText As String = String.Empty

        '    FocusedRow = DataGridViewBooks_Books.CurrentView.GetFocusedRow

        '    If FocusedRow IsNot Nothing Then

        '        ErrorText = _Controller.ValidateBookProperty(_ViewModel, FocusedRow, DataGridViewBooks_Books.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

        '        DataGridViewBooks_Books.CurrentView.SetColumnError(DataGridViewBooks_Books.CurrentView.FocusedColumn, ErrorText)

        '        e.Valid = True

        '    End If

        'End Sub
        Private Sub DataGridViewDayparts_Dayparts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewDayparts_Dayparts.InitNewRowEvent

            _Controller.DaypartInitNewRowEvent(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewDayparts_Dayparts.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Media.NielsenDaypart.Properties.ID.ToString Then

                Datasource = _ViewModel.NielsenDaypartRepository

            End If

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewDayparts_Dayparts.SelectionChangedEvent

            _Controller.DaypartSelectionChanged(_ViewModel, DataGridViewDayparts_Dayparts.IsNewItemRow,
                                                DataGridViewDayparts_Dayparts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.NielsenDaypart).ToList)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewDayparts_Dayparts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewDayparts_Dayparts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    If e.Valid Then

                        _Controller.DaypartAddNewRowEvent(_ViewModel)

                        RefreshViewModel(False)

                    Else

                        DataGridViewDayparts_Dayparts.CurrentView.NewItemRowText = e.ErrorText

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewDayparts_Dayparts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewDayparts_Dayparts.ValidatingEditorEvent

            'objects
            Dim FocusedRow As Object = Nothing
            Dim ErrorText As String = Nothing

            FocusedRow = DataGridViewDayparts_Dayparts.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing AndAlso TypeOf FocusedRow Is AdvantageFramework.DTO.Media.DayTime Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewDayparts_Dayparts.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewDayparts_Dayparts.CurrentView.SetColumnError(DataGridViewDayparts_Dayparts.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewLeftSection_UserCriterias_BeforeLeaveRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_UserCriterias.BeforeLeaveRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewLeftSection_UserCriterias_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewLeftSection_UserCriterias.FocusedRowChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSelectedResearchCriteria(_ViewModel, DataGridViewLeftSection_UserCriterias.CurrentView.GetRowCellValue(e.FocusedRowHandle, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria.Properties.ID.ToString))

                Me.FormAction = WinForm.Presentation.Methods.FormActions.LoadingSelectedItem

                LoadViewModel(DirectCast(DataGridViewLeftSection_UserCriterias.GetFirstSelectedRowDataBoundItem, AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria).ID, False)

                Me.FormAction = WinForm.Presentation.Methods.FormActions.None

            End If

        End Sub
        Private Sub DataGridViewRightSection_SelectedFormats_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_SelectedFormats.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedMetrics_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_SelectedMetrics.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub SearchableComboBoxMarket_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxMarket_Market.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetMarketCode(_ViewModel, SearchableComboBoxMarket_Market.GetSelectedValue)

                RefreshViewModel()

            End If

        End Sub
        Private Sub TabControlForm_ResearchCriteria_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_ResearchCriteria.SelectedTabChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
