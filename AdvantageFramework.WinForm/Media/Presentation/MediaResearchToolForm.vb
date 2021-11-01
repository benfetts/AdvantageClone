Namespace Media.Presentation

    Public Class MediaResearchToolForm

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaResearchToolViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaResearchToolController = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub EnableOrDisableActions()

            If Me.FormShown Then

                SearchableComboBoxAudienceMetrics_Market.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                SearchableComboBoxAudienceMetrics_Station.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                ComboBoxAudienceMetrics_Stream.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                ComboBoxAudienceMetrics_NielsenService.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                ComboBoxAudienceMetrics_SampleType.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                ComboBoxAudienceMetrics_BookMonth.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                NumericInputAudienceMetrics_BookYear.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                DateTimePickerAudienceMetrics_StartDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                DateTimePickerAudienceMetrics_EndDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                DateTimePickerAudienceMetrics_StartTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                DateTimePickerAudienceMetrics_EndTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))
                DateTimePickerAudienceMetrics_DayStarts.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics))

                SearchableComboBoxNational_Media.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                SearchableComboBoxNational_Service.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                SearchableComboBoxNational_MarketBreak.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                ComboBoxNational_TimeType.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                ComboBoxNational_Stream.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                DateTimePickerNational_StartDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                DateTimePickerNational_EndDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                DateTimePickerNational_StartTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))
                DateTimePickerNational_EndTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational))

                SearchableComboBoxRadio_Period.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))
                SearchableComboBoxRadio_Market.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))
                SearchableComboBoxRadio_Geography.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))
                SearchableComboBoxRadio_Station.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))
                DateTimePickerRadio_StartTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))
                DateTimePickerRadio_EndTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio))

                DateTimePickerComscore_StartDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore))
                DateTimePickerComscore_StartTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore))
                DateTimePickerComscore_EndDate.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore))
                DateTimePickerComscore_EndTime.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore))
                ComboBoxComscore_Market.SetRequired(TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore))

                ButtonItemActions_Process.Enabled = Not TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScoreResults)

            End If

        End Sub
        Private Sub SetDateRange()

            Dim BookMonth As Nullable(Of Integer) = Nothing
            Dim BookYear As Nullable(Of Integer) = Nothing
            Dim MinDate As Date = Nothing
            Dim MaxDate As Date = Nothing

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ComboBoxAudienceMetrics_BookMonth.HasASelectedValue Then

                    BookMonth = CInt(ComboBoxAudienceMetrics_BookMonth.SelectedValue)
                    BookYear = CInt(NumericInputAudienceMetrics_BookYear.Value)

                    If BookMonth.HasValue AndAlso BookYear.HasValue Then

                        _Controller.SetNielsenBroadcastDateRange(_ViewModel, BookMonth, BookYear)

                        If _ViewModel.NielsenBroadcastStartDate.HasValue Then

                            MinDate = _ViewModel.NielsenBroadcastStartDate
                            MaxDate = _ViewModel.NielsenBroadcastEndDate

                            If MaxDate.Hour * 100 + MaxDate.Minute < CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).Minute Then

                                MaxDate = MaxDate.AddDays(-1)

                            End If

                            DateTimePickerAudienceMetrics_StartDate.MinDate = MinDate
                            DateTimePickerAudienceMetrics_StartDate.MaxDate = MaxDate
                            DateTimePickerAudienceMetrics_StartDate.Value = MinDate

                            DateTimePickerAudienceMetrics_EndDate.MinDate = MinDate
                            DateTimePickerAudienceMetrics_EndDate.MaxDate = MaxDate
                            DateTimePickerAudienceMetrics_EndDate.Value = MaxDate

                        End If

                    End If

                End If

            End If

            DateTimePickerAudienceMetrics_StartDate.Enabled = _ViewModel.NielsenBroadcastStartDate.HasValue
            DateTimePickerAudienceMetrics_EndDate.Enabled = _ViewModel.NielsenBroadcastEndDate.HasValue

        End Sub
        Private Sub RefreshSpotRadioTab(Optional RefreshData As Boolean = True)

            SearchableComboBoxRadio_Period.DataSource = _ViewModel.NielsenRadioPeriodList
            SearchableComboBoxAudienceMetrics_Station.DataSource = _ViewModel.NielsenRadioStationList

        End Sub
        Private Sub RefreshComscoreTab()

            DataGridViewComscore_AvailableStations.DataSource = Nothing
            DataGridViewComscore_SelectedStations.DataSource = Nothing

            DataGridViewComscore_AvailableStations.DataSource = _ViewModel.ComscoreAvailableTVStationList.OrderBy(Function(Entity) Entity.CallLetters).ToList
            DataGridViewComscore_AvailableStations.CurrentView.BestFitColumns()

            DataGridViewComscore_SelectedStations.DataSource = _ViewModel.ComscoreSelectedTVStationList.OrderBy(Function(Entity) Entity.CallLetters).ToList
            DataGridViewComscore_SelectedStations.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveViewModel()

            _ViewModel.ComscoreStartDate = DateTimePickerComscore_StartDate.GetValue
            _ViewModel.ComscoreEndDate = DateTimePickerComscore_EndDate.GetValue

            _ViewModel.ComscoreStartTime = CDate(DateTimePickerComscore_StartTime.GetValue).ToString("HH:mm")
            _ViewModel.ComscoreEndTime = CDate(DateTimePickerComscore_EndTime.GetValue).ToString("HH:mm")

            _ViewModel.ComscoreSelectedMarketNumber = ComboBoxComscore_Market.GetSelectedValue
            _ViewModel.ComscoreSelectedMediaDemographicList = DataGridViewComscore_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).ToList

        End Sub
        Private Sub SetCaptionAndVisibility(Key As Integer, Prefix As String, ByRef GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            If _ViewModel.JSONOrdinalComscoreDemoNumbers.ContainsKey(Key) Then

                GridColumn.Caption = Prefix & " " & _ViewModel.ComscoreSelectedMediaDemographicList.Where(Function(D) D.ComscoreDemoNumber = _ViewModel.JSONOrdinalComscoreDemoNumbers.Item(Key)).FirstOrDefault.Description

            Else

                GridColumn.Visible = False

            End If

        End Sub
        Private Sub SetColumnCaptions()

            For Each GridColumn In DataGridViewComscore_Results.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                If GridColumn.FieldName.EndsWith("01") Then

                    SetCaptionAndVisibility(1, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_01") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("02") Then

                    SetCaptionAndVisibility(2, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_02") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("03") Then

                    SetCaptionAndVisibility(3, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_03") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("04") Then

                    SetCaptionAndVisibility(4, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_04") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("05") Then

                    SetCaptionAndVisibility(5, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_05") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("06") Then

                    SetCaptionAndVisibility(6, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_06") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("07") Then

                    SetCaptionAndVisibility(7, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_07") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("08") Then

                    SetCaptionAndVisibility(8, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_08") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("09") Then

                    SetCaptionAndVisibility(9, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_09") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("10") Then

                    SetCaptionAndVisibility(10, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_10") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("11") Then

                    SetCaptionAndVisibility(11, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_11") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("12") Then

                    SetCaptionAndVisibility(12, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_12") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("13") Then

                    SetCaptionAndVisibility(13, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_13") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("14") Then

                    SetCaptionAndVisibility(14, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_14") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("15") Then

                    SetCaptionAndVisibility(15, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_15") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("16") Then

                    SetCaptionAndVisibility(16, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_16") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("17") Then

                    SetCaptionAndVisibility(17, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_17") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("18") Then

                    SetCaptionAndVisibility(18, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_18") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("19") Then

                    SetCaptionAndVisibility(19, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_19") - 1), GridColumn)

                ElseIf GridColumn.FieldName.EndsWith("20") Then

                    SetCaptionAndVisibility(20, Mid(GridColumn.FieldName, 1, InStr(GridColumn.FieldName, "_20") - 1), GridColumn)

                End If

            Next

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim MediaResearchToolForm As AdvantageFramework.Media.Presentation.MediaResearchToolForm = Nothing

            MediaResearchToolForm = New AdvantageFramework.Media.Presentation.MediaResearchToolForm

            MediaResearchToolForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaResearchToolForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

            _Controller = New AdvantageFramework.Controller.Media.MediaResearchToolController(Me.Session)
            _ViewModel = _Controller.LoadAudienceMetricsCriteria()

            SearchableComboBoxAudienceMetrics_Market.DataSource = _ViewModel.TVMarketList
            SearchableComboBoxAudienceMetrics_Market.SelectedValue = Nothing

            SearchableComboBoxAudienceMetrics_Station.SelectedValue = Nothing

            ComboBoxAudienceMetrics_Stream.DataSource = _ViewModel.NielsenDataStreamDataTable

            ComboBoxAudienceMetrics_NielsenService.DataSource = _ViewModel.NielsenServiceDataTable

            ComboBoxAudienceMetrics_SampleType.DataSource = _ViewModel.NielsenSampleTypeDataTable

            ComboBoxAudienceMetrics_BookMonth.DataSource = _ViewModel.MonthList
            ComboBoxAudienceMetrics_BookMonth.SelectedValue = CLng(Now.Month)

            NumericInputAudienceMetrics_BookYear.Properties.MinValue = 1997
            NumericInputAudienceMetrics_BookYear.Properties.MaxValue = 2078
            NumericInputAudienceMetrics_BookYear.Properties.MaxLength = 4
            NumericInputAudienceMetrics_BookYear.SetPropertySettings("Book Year")
            NumericInputAudienceMetrics_BookYear.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False

            DateTimePickerAudienceMetrics_StartDate.ValueObject = Now.ToShortDateString
            DateTimePickerAudienceMetrics_EndDate.ValueObject = Now.ToShortDateString
            DateTimePickerAudienceMetrics_StartTime.ValueObject = "9:00 AM"
            DateTimePickerAudienceMetrics_EndTime.ValueObject = "10:00 AM"
            DateTimePickerAudienceMetrics_DayStarts.ValueObject = "3:00 AM"

            DataGridViewAudienceMetrics_SelectedDemos.DataSource = _ViewModel.MediaDemographicTVList
            DataGridViewAudienceMetrics_SelectedDemos.CurrentView.BestFitColumns()

            DataGridViewAudienceMetrics_Results.CurrentView.OptionsBehavior.ReadOnly = True

            'National
            SearchableComboBoxNational_Media.DataSource = _ViewModel.NationalBroadcastTypeList
            SearchableComboBoxNational_Media.SelectedValue = AdvantageFramework.Nielsen.Database.Entities.BroadcastTypeID.NetworkTV

            SearchableComboBoxNational_Service.DataSource = _ViewModel.NationalRatingsServiceList
            SearchableComboBoxNational_Service.SelectedValue = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen

            SearchableComboBoxNational_MarketBreak.DataSource = _ViewModel.NationalMediaMarketBreakList
            SearchableComboBoxNational_MarketBreak.SelectedValue = 1

            ComboBoxNational_TimeType.DataSource = _ViewModel.NationalNielsenTimeTypeDataTable

            ComboBoxNational_Stream.DataSource = _ViewModel.NielsenNationalDataStreamDataTable

            DateTimePickerNational_StartDate.ValueObject = Now.ToShortDateString
            DateTimePickerNational_EndDate.ValueObject = Now.ToShortDateString
            DateTimePickerNational_StartTime.ValueObject = "9:00 AM"
            DateTimePickerNational_EndTime.ValueObject = "10:00 AM"

            DataGridViewNational_SelectedDemos.DataSource = _ViewModel.NationalMediaDemographicTVList
            DataGridViewNational_SelectedDemos.CurrentView.BestFitColumns()

            RadioButtonGroupBy_None.Checked = True

            DataGridViewNational_Results.CurrentView.OptionsBehavior.ReadOnly = True

            'Radio
            SearchableComboBoxRadio_Period.DataSource = _ViewModel.NielsenRadioPeriodList
            SearchableComboBoxRadio_Period.SelectedValue = Nothing

            SearchableComboBoxRadio_Market.DataSource = _ViewModel.NielsenRadioMarketList
            SearchableComboBoxRadio_Market.SelectedValue = Nothing

            SearchableComboBoxRadio_Geography.DataSource = _ViewModel.NielsenRadioGeoIndicatorDataTable
            SearchableComboBoxRadio_Geography.SelectedValue = Nothing

            DataGridViewRadio_SelectedDemos.DataSource = _ViewModel.RadioMediaDemographicList
            DataGridViewRadio_SelectedDemos.CurrentView.BestFitColumns()

            'comscore
            DateTimePickerComscore_StartDate.ValueObject = Now.ToShortDateString
            DateTimePickerComscore_EndDate.ValueObject = Now.ToShortDateString
            DateTimePickerComscore_StartTime.ValueObject = "9:00 AM"
            DateTimePickerComscore_EndTime.ValueObject = "10:00 AM"

            DataGridViewComscore_AvailableStations.CurrentView.OptionsBehavior.Editable = False
            DataGridViewComscore_SelectedStations.CurrentView.OptionsBehavior.Editable = False
            DataGridViewComscore_Results.CurrentView.OptionsBehavior.Editable = False

            TabItemUnitTests_comScore.Tag = False

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaResearchToolForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ComboBoxAudienceMetrics_SampleType.Enabled = False

            SetDateRange()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            If TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics) Then

                If DataGridViewAudienceMetrics_Results.HasRows Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        DataGridViewAudienceMetrics_Results.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""), Agency, _Controller.Session)

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("No rows in grid to export.")

                End If

            ElseIf TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational) Then

                If DataGridViewNational_Results.HasRows Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        DataGridViewNational_Results.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("Form", ""), Agency, _Controller.Session)

                    End Using

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("No rows in grid to export.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Process_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Process.Click

            Dim StartHour As Integer = 0
            Dim EndHour As Integer = 0
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing
            Dim AdjustMinutes As Short = 0
            Dim SelectedMediaDemographics As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic) = Nothing
            Dim ErrorMessage As String = ""
            Dim GroupBy As Integer = 0

            If Me.Validator Then

                If TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetrics) Then

                    If (CheckBoxDays_Sun.Checked OrElse CheckBoxDays_Mon.Checked OrElse CheckBoxDays_Tue.Checked OrElse CheckBoxDays_Wed.Checked OrElse CheckBoxDays_Thu.Checked OrElse CheckBoxDays_Fri.Checked OrElse CheckBoxDays_Sat.Checked) AndAlso
                            DataGridViewAudienceMetrics_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).Any Then

                        GroupBoxAudienceMetrics_Days.Focus()

                        SelectedMediaDemographics = DataGridViewAudienceMetrics_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).ToList

                        StartHour = CDate(DateTimePickerAudienceMetrics_StartTime.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_StartTime.GetValue).Minute

                        If CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Minute < CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).Minute Then

                            EndHour = CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Minute + 2400

                        Else

                            EndHour = CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerAudienceMetrics_EndTime.GetValue).Minute

                        End If

                        StartDate = CDate(DateTimePickerAudienceMetrics_StartDate.GetValue).ToShortDateString
                        EndDate = CDate(DateTimePickerAudienceMetrics_EndDate.GetValue).ToShortDateString

                        If StartHour > EndHour Then

                            AdvantageFramework.WinForm.MessageBox.Show("Invalid buy.")

                        ElseIf StartDate > EndDate Then

                            AdvantageFramework.WinForm.MessageBox.Show("End date must be after or the same as start date.")

                        Else

                            Me.ShowWaitForm("Loading...")

                            AdjustMinutes = DateDiff(DateInterval.Minute, CDate(CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).ToShortDateString), CDate(CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).ToShortDateString & " " & CDate(DateTimePickerAudienceMetrics_DayStarts.GetValue).ToShortTimeString))

                            _Controller.RefreshAudienceMetricsResults(_ViewModel, SearchableComboBoxAudienceMetrics_Market.GetSelectedValue, SearchableComboBoxAudienceMetrics_Station.GetSelectedValue, ComboBoxAudienceMetrics_Stream.SelectedValue,
                                                      ComboBoxAudienceMetrics_NielsenService.SelectedValue, ComboBoxAudienceMetrics_SampleType.SelectedValue,
                                                      CInt(ComboBoxAudienceMetrics_BookMonth.SelectedValue), CInt(NumericInputAudienceMetrics_BookYear.Value), StartDate, EndDate, StartHour, EndHour,
                                                      CheckBoxDays_Sun.Checked, CheckBoxDays_Mon.Checked, CheckBoxDays_Tue.Checked, CheckBoxDays_Wed.Checked, CheckBoxDays_Thu.Checked, CheckBoxDays_Fri.Checked, CheckBoxDays_Sat.Checked, AdjustMinutes, SelectedMediaDemographics)

                            DataGridViewAudienceMetrics_Results.DataSource = _ViewModel.AudienceMetricList
                            DataGridViewAudienceMetrics_Results.CurrentView.BestFitColumns()

                            Me.CloseWaitForm()

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please check at least one day and one demographic.")

                    End If

                ElseIf TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsNational) Then

                    If (CheckBoxNationalDays_Sun.Checked OrElse CheckBoxNationalDays_Mon.Checked OrElse CheckBoxNationalDays_Tue.Checked OrElse CheckBoxNationalDays_Wed.Checked OrElse CheckBoxNationalDays_Thu.Checked OrElse CheckBoxNationalDays_Fri.Checked OrElse CheckBoxNationalDays_Sat.Checked) AndAlso
                            DataGridViewNational_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).Any Then

                        GroupBoxNational_Days.Focus()

                        SelectedMediaDemographics = DataGridViewNational_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).ToList

                        StartHour = CDate(DateTimePickerNational_StartTime.GetValue).Hour * 100 + CDate(DateTimePickerNational_StartTime.GetValue).Minute

                        If CDate(DateTimePickerNational_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerNational_EndTime.GetValue).Minute < 600 Then

                            EndHour = CDate(DateTimePickerNational_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerNational_EndTime.GetValue).Minute + 2400

                        Else

                            EndHour = CDate(DateTimePickerNational_EndTime.GetValue).Hour * 100 + CDate(DateTimePickerNational_EndTime.GetValue).Minute

                        End If

                        StartDate = CDate(DateTimePickerNational_StartDate.GetValue).ToShortDateString
                        EndDate = CDate(DateTimePickerNational_EndDate.GetValue).ToShortDateString

                        If StartHour > EndHour Then

                            AdvantageFramework.WinForm.MessageBox.Show("Invalid buy.")

                        ElseIf StartDate > EndDate Then

                            AdvantageFramework.WinForm.MessageBox.Show("End date must be after or the same as start date.")

                        Else

                            If RadioButtonGroupBy_Date.Checked Then

                                GroupBy = 1

                            ElseIf RadioButtonGroupBy_Network.Checked Then

                                GroupBy = 2

                            End If

                            Me.ShowWaitForm("Loading...")

                            _Controller.RefreshNationalAudienceMetricsResults(_ViewModel, SearchableComboBoxNational_MarketBreak.GetSelectedValue, ComboBoxNational_TimeType.SelectedValue, ComboBoxNational_Stream.SelectedValue,
                                                      StartDate, EndDate, StartHour, EndHour,
                                                      CheckBoxNationalDays_Sun.Checked, CheckBoxNationalDays_Mon.Checked, CheckBoxNationalDays_Tue.Checked, CheckBoxNationalDays_Wed.Checked, CheckBoxNationalDays_Thu.Checked, CheckBoxNationalDays_Fri.Checked, CheckBoxNationalDays_Sat.Checked, GroupBy, SelectedMediaDemographics)

                            DataGridViewNational_Results.DataSource = _ViewModel.NationalAudienceMetricList
                            DataGridViewNational_Results.CurrentView.BestFitColumns()

                            Me.CloseWaitForm()

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please check at least one day and one demographic.")

                    End If

                ElseIf TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_AudienceMetricsRadio) Then

                    If DataGridViewRadio_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).Any Then

                        SelectedMediaDemographics = DataGridViewRadio_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).ToList

                        Me.ShowWaitForm("Loading...")

                        _Controller.RefreshRadioAudienceMetricsResults(_ViewModel, SearchableComboBoxRadio_Market.GetSelectedValue, SearchableComboBoxRadio_Period.GetSelectedValue,
                                                                       SearchableComboBoxRadio_Geography.GetSelectedValue, SearchableComboBoxRadio_Station.GetSelectedValue,
                                                                       SelectedMediaDemographics, CheckRadio_Sunday.Checked, CheckRadio_Monday.Checked, CheckRadio_Tuesday.Checked, CheckRadio_Wednesday.Checked, CheckRadio_Thursday.Checked, CheckRadio_Friday.Checked, CheckRadio_Saturday.Checked)

                        DataGridViewRadio_Results.DataSource = _ViewModel.RadioWorksheetMetricList
                        DataGridViewRadio_Results.CurrentView.BestFitColumns()

                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please check at least one demographic.")

                    End If

                ElseIf TabControlForm_UnitTests.SelectedTab.Equals(TabItemUnitTests_comScore) Then

                    If DataGridViewComscore_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).Any AndAlso
                            DataGridViewComscore_SelectedDemos.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.MediaDemographic).Where(Function(Entity) Entity.IsSelected = True).Count <= 20 Then

                        If DataGridViewComscore_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ComscoreTVStation).Any AndAlso
                                DataGridViewComscore_SelectedStations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ComscoreTVStation).Count <= 100 Then

                            Me.ShowWaitForm("Loading...")

                            SaveViewModel()

                            Try

                                _Controller.GetLocalTimeViews(_ViewModel)

                            Catch ex As Exception

                                While ex.InnerException IsNot Nothing

                                    ex = ex.InnerException

                                End While

                                AdvantageFramework.WinForm.MessageBox.Show(ex.Message)

                            End Try

                            TabControlForm_UnitTests.SelectedTab = TabItemUnitTests_comScoreResults

                            DataGridViewComscore_Results.DataSource = Nothing
                            DataGridViewComscore_Results.DataSource = _ViewModel.ComscoreLocalTimeViewList

                            If _ViewModel.ComscoreJSONRequestString IsNot Nothing Then

                                System.Windows.Forms.Clipboard.SetText(_ViewModel.ComscoreJSONRequestString)

                            End If

                            SetColumnCaptions()

                            DataGridViewComscore_Results.CurrentView.BestFitColumns()

                            Me.CloseWaitForm()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Please check at least one tv but no more than one-hundred tv stations.")

                        End If

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please check at least one but no more than twenty demographics.")

                    End If

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ComboBoxAudienceMetrics_BookMonth_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxAudienceMetrics_BookMonth.SelectedValueChanged

            If Me.FormShown Then

                SetDateRange()

            End If

        End Sub
        Private Sub DataGridViewAudienceMetrics_SelectedDemos_DeselectAllEvent() Handles DataGridViewAudienceMetrics_SelectedDemos.DeselectAllEvent

            For Each MediaDemographicTV In DataGridViewAudienceMetrics_SelectedDemos.GetAllRowsDataBoundItems()

                MediaDemographicTV.IsSelected = False

            Next

            DataGridViewAudienceMetrics_SelectedDemos.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewAudienceMetrics_SelectedDemos_SelectAllEvent() Handles DataGridViewAudienceMetrics_SelectedDemos.SelectAllEvent

            For Each MediaDemographicTV In DataGridViewAudienceMetrics_SelectedDemos.GetAllRowsDataBoundItems()

                MediaDemographicTV.IsSelected = True

            Next

            DataGridViewAudienceMetrics_SelectedDemos.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewNational_SelectedDemos_DeselectAllEvent() Handles DataGridViewNational_SelectedDemos.DeselectAllEvent

            For Each MediaDemographicTV In DataGridViewNational_SelectedDemos.GetAllRowsDataBoundItems()

                MediaDemographicTV.IsSelected = False

            Next

            DataGridViewNational_SelectedDemos.CurrentView.RefreshData()

        End Sub
        Private Sub DataGridViewNational_SelectedDemos_SelectAllEvent() Handles DataGridViewNational_SelectedDemos.SelectAllEvent

            For Each MediaDemographicTV In DataGridViewNational_SelectedDemos.GetAllRowsDataBoundItems()

                MediaDemographicTV.IsSelected = True

            Next

            DataGridViewNational_SelectedDemos.CurrentView.RefreshData()

        End Sub
        Private Sub DateTimePickerAudienceMetrics_EndTime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerAudienceMetrics_EndTime.Validating

            If DateTimePickerAudienceMetrics_EndTime.ValueObject IsNot Nothing AndAlso (DateTimePickerAudienceMetrics_EndTime.Value.Minute <> 0 AndAlso DateTimePickerAudienceMetrics_EndTime.Value.Minute <> 15 AndAlso
                    DateTimePickerAudienceMetrics_EndTime.Value.Minute <> 30 AndAlso DateTimePickerAudienceMetrics_EndTime.Value.Minute <> 45) Then

                AdvantageFramework.WinForm.MessageBox.Show("End time must be quarter hour.")

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerAudienceMetrics_StartTime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerAudienceMetrics_StartTime.Validating

            If DateTimePickerAudienceMetrics_StartTime.ValueObject IsNot Nothing AndAlso (DateTimePickerAudienceMetrics_StartTime.Value.Minute <> 0 AndAlso DateTimePickerAudienceMetrics_StartTime.Value.Minute <> 15 AndAlso
                    DateTimePickerAudienceMetrics_StartTime.Value.Minute <> 30 AndAlso DateTimePickerAudienceMetrics_StartTime.Value.Minute <> 45) Then

                AdvantageFramework.WinForm.MessageBox.Show("Start time must be quarter hour.")

                e.Cancel = True

            End If

        End Sub
        Private Sub DateTimePickerAudienceMetrics_DayStarts_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DateTimePickerAudienceMetrics_DayStarts.Validating

            If DateTimePickerAudienceMetrics_DayStarts.ValueObject IsNot Nothing AndAlso (DateTimePickerAudienceMetrics_DayStarts.Value.Minute <> 0) Then

                AdvantageFramework.WinForm.MessageBox.Show("Day start time must be on the hour.")

                e.Cancel = True

            End If

        End Sub
        Private Sub NumericInputAudienceMetrics_BookYear_ValueChanged(sender As Object, e As EventArgs) Handles NumericInputAudienceMetrics_BookYear.ValueChanged

            If Me.FormShown Then

                SetDateRange()

            End If

        End Sub
        Private Sub SearchableComboBoxAudienceMetrics_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxAudienceMetrics_Market.EditValueChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None AndAlso SearchableComboBoxAudienceMetrics_Market.HasASelectedValue Then

                _Controller.LoadStations(_ViewModel, SearchableComboBoxAudienceMetrics_Market.GetSelectedValue)

                SearchableComboBoxAudienceMetrics_Station.DataSource = _ViewModel.NielsenStationList

            End If

        End Sub
        Private Sub TabControlForm_UnitTests_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_UnitTests.SelectedTabChanged

            EnableOrDisableActions()

        End Sub
        Private Sub TabControlForm_UnitTests_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_UnitTests.SelectedTabChanging

            If e.NewTab.Equals(TabItemUnitTests_comScore) AndAlso TabItemUnitTests_comScore.Tag = False Then

                _Controller.LoadComscoreMarkets(_ViewModel)

                _Controller.LoadComscoreMediaDemographics(_ViewModel)

                ComboBoxComscore_Market.DataSource = _ViewModel.ComscoreMarketList

                DataGridViewComscore_SelectedDemos.DataSource = _ViewModel.ComscoreMediaDemographicList.OrderBy(Function(Entity) Entity.Description).ToList
                DataGridViewComscore_SelectedDemos.CurrentView.BestFitColumns()

                TabItemUnitTests_comScore.Tag = True

            End If

        End Sub
        Private Sub SearchableComboBoxRadio_StationOrCombo_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxRadio_Station.QueryPopupNeedDataSource

            If SearchableComboBoxRadio_Market.HasASelectedValue Then

                _Controller.GetRadioStationOrCombo(SearchableComboBoxRadio_Market.GetSelectedValue, _ViewModel)

                SearchableComboBoxRadio_Station.DataSource = _ViewModel.NielsenRadioStationList

                DataSourceSet = True

            End If

        End Sub
        Private Sub SearchableComboBoxRadio_Market_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxRadio_Market.EditValueChanged

            If Me.FormShown AndAlso SearchableComboBoxRadio_Market.HasASelectedValue AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                _Controller.SetSpotRadioDataByMarket(_ViewModel, SearchableComboBoxRadio_Market.GetSelectedValue)

                RefreshSpotRadioTab()

            End If

        End Sub
        Private Sub ButtonComscoreTVStation_AddToSelected_Click(sender As Object, e As EventArgs) Handles ButtonComscoreTVStation_AddToSelected.Click

            _Controller.AddToSelectedComscoreTVStations(_ViewModel, DataGridViewComscore_AvailableStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ComscoreTVStation).ToList)

            RefreshComscoreTab()

        End Sub
        Private Sub ButtonComscoreTVStation_RemoveFromSelected_Click(sender As Object, e As EventArgs) Handles ButtonComscoreTVStation_RemoveFromSelected.Click

            _Controller.RemoveFromSelectedComscoreStations(_ViewModel, DataGridViewComscore_SelectedStations.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ComscoreTVStation).ToList)

            RefreshComscoreTab()

        End Sub
        Private Sub ComboBoxComscore_Market_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxComscore_Market.SelectedValueChanged

            If Me.FormShown AndAlso ComboBoxComscore_Market.HasASelectedValue Then

                _Controller.LoadComscoreTVStations(ComboBoxComscore_Market.GetSelectedValue, _ViewModel)

                RefreshComscoreTab()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
