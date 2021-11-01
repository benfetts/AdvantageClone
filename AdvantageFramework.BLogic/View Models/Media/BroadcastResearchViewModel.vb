Namespace ViewModels.Media

    Public Class BroadcastResearchViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum ResearchTab
            SpotRadio
            SpotTV
            SpotRadioCounty
            National
        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectedResearchTab As ResearchTab
        Public Property MissingIntegrationSettingsMessage As String

#Region " Spot TV "

        Public Property SpotTVAddEnabled As Boolean

        Public ReadOnly Property SpotTVExportEnabled As Boolean
            Get
                SpotTVExportEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing AndAlso Me.SpotTVReportDataTable IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotTVEditEnabled As Boolean
            Get
                SpotTVEditEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotTVDeleteEnabled As Boolean
            Get
                SpotTVDeleteEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotTVCopyEnabled As Boolean
            Get
                SpotTVCopyEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotTVProcessEnabled As Boolean
            Get
                SpotTVProcessEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing AndAlso Not Me.SpotTVIsDirty
            End Get
        End Property
        Public ReadOnly Property SpotTVSaveEnabled As Boolean
            Get
                SpotTVSaveEnabled = Me.SpotTVSelectedResearchCriteria IsNot Nothing AndAlso Me.SpotTVIsDirty
            End Get
        End Property

        Public ReadOnly Property IsMarketSelected As Boolean
            Get
                IsMarketSelected = (Not String.IsNullOrWhiteSpace(SpotTVSelectedResearchCriteria.MarketCode))
            End Get
        End Property

        Public Property SpotTVDayTimeIsNewRow As Boolean
        Public Property SpotTVDayTimeCancelEnabled As Boolean
        Public Property SpotTVDayTimeDeleteEnabled As Boolean

        Public Property SpotTVIsDirty As Boolean

        Public Property SpotTVResearchCriteriaList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria)
        Public Property SpotTVSelectedResearchCriteria As AdvantageFramework.DTO.Media.SpotTV.ResearchCriteria

        Public Property SpotTVMarketList As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property SpotTVResearchReportTypeList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property SpotTVAvailableNielsenStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)
        Public Property SpotTVSelectedNielsenStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)

        Public Property SpotTVDayTimeList As Generic.List(Of AdvantageFramework.DTO.DaysAndTime)
        Public Property SpotTVSelectedDayTimes As Generic.List(Of AdvantageFramework.DTO.DaysAndTime)

        Public Property SpotTVShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel

        Public Property SpotTVAvailableDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic)
        Public Property SpotTVSelectedDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic)

        Public Property SpotTVAvailableMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)
        Public Property SpotTVSelectedMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)

        Public Property SpotTVResearchResultList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult)
        Public Property SpotTVReportDataTable As System.Data.DataTable

		Public Property Dashboard As AdvantageFramework.DTO.Dashboard

        Public Property ProgramWeeks As String

        Public Property SpotTVSourceList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Spot Radio "

        Public Property AddEnabled As Boolean

        Public ReadOnly Property ExportEnabled As Boolean
            Get
                ExportEnabled = Me.SelectedResearchCriteria IsNot Nothing AndAlso Me.SpotRadioReportDataTable IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property EditEnabled As Boolean
            Get
                EditEnabled = Me.SelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = Me.SelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.SelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property ProcessEnabled As Boolean
            Get
                ProcessEnabled = Me.SelectedResearchCriteria IsNot Nothing AndAlso Not Me.SpotRadioIsDirty
            End Get
        End Property
        Public ReadOnly Property SaveEnabled As Boolean
            Get
                SaveEnabled = Me.SelectedResearchCriteria IsNot Nothing AndAlso Me.SpotRadioIsDirty
            End Get
        End Property

        Public Property SpotRadioIsDiaryMarket As Boolean
        Public Property SpotRadioHasTSAData As Boolean
        Public Property SpotRadioHasDMAData As Boolean

        Public Property BookIsNewRow As Boolean
        Public Property BookCancelEnabled As Boolean
        Public Property BookDeleteEnabled As Boolean

        Public Property DaypartIsNewRow As Boolean
        Public Property DaypartCancelEnabled As Boolean
        Public Property DaypartDeleteEnabled As Boolean

        Public Property SpotRadioIsDirty As Boolean

        Public Property SpotRadioQualitativeIsReadonly As Boolean

        Public Property ResearchCriteriaList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria)
        Public Property SelectedResearchCriteria As AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria

        Public Property SpotRadioSourceList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property RadioMarketList As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property SpotRadioResearchReportTypeList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property MediaDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)
        Public Property NielsenRadioQualitativeList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioQualitative)

        Public Property NielsenRadioBookList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook)
        Public Property NielsenRadioPeriodRepository As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

        Public Property NielsenDaypartList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart)
        Public Property NielsenDaypartRepository As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart)

        Public Property AvailableMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)
        Public Property SelectedMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)

        Public Property AvailableStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)
        Public Property SelectedStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

        Public Property SpotRadioResearchResultList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.ResearchResult)
        Public Property SpotRadioAudienceCompositionList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.AudienceComposition)
        Public Property SpotRadioReportDataTable As System.Data.DataTable

        Public ReadOnly Property CumeNielsenPeriodIDs As IEnumerable(Of Integer)
            Get
                CumeNielsenPeriodIDs = (From Entity In NielsenDaypartRepository
                                        Where Entity.Cume = True
                                        Select Entity.ID).ToArray
            End Get
        End Property

        Public ReadOnly Property ExclusiveCumeNielsenPeriodIDs As IEnumerable(Of Integer)
            Get
                ExclusiveCumeNielsenPeriodIDs = (From Entity In NielsenDaypartRepository
                                                 Where Entity.ExclusiveCume = True
                                                 Select Entity.ID).ToArray
            End Get
        End Property

        Public ReadOnly Property QualitativeNielsenPeriodIDs As IEnumerable(Of Integer)
            Get
                QualitativeNielsenPeriodIDs = (From Entity In NielsenDaypartRepository
                                               Where Entity.Qualitative = True
                                               Select Entity.ID).ToArray
            End Get
        End Property

        Public ReadOnly Property DiaryAtWorkInCarNielsenPeriodIDs As IEnumerable(Of Integer)
            Get
                DiaryAtWorkInCarNielsenPeriodIDs = (From Entity In NielsenDaypartRepository
                                                    Where Entity.DiaryAtWorkInCar = True
                                                    Select Entity.ID).ToArray
            End Get
        End Property

        Public ReadOnly Property PPMinHomeOutofHomeNielsenPeriodIDs As IEnumerable(Of Integer)
            Get
                PPMinHomeOutofHomeNielsenPeriodIDs = (From Entity In NielsenDaypartRepository
                                                      Where Entity.PPMinHomeOutofHome = True
                                                      Select Entity.ID).ToArray
            End Get
        End Property

#End Region

#Region " Spot Radio County "

        Public Property SpotRadioCountyAddEnabled As Boolean

        Public ReadOnly Property SpotRadioCountyExportEnabled As Boolean
            Get
                SpotRadioCountyExportEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso Me.SpotRadioCountyReportDataTable IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotRadioCountyEditEnabled As Boolean
            Get
                SpotRadioCountyEditEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotRadioCountyDeleteEnabled As Boolean
            Get
                SpotRadioCountyDeleteEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotRadioCountyCopyEnabled As Boolean
            Get
                SpotRadioCountyCopyEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property SpotRadioCountyProcessEnabled As Boolean
            Get
                SpotRadioCountyProcessEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso Not Me.SpotRadioCountyIsDirty
            End Get
        End Property
        Public ReadOnly Property SpotRadioCountySaveEnabled As Boolean
            Get
                SpotRadioCountySaveEnabled = Me.SpotRadioCountySelectedResearchCriteria IsNot Nothing AndAlso Me.SpotRadioCountyIsDirty
            End Get
        End Property

        Public Property YearIsNewRow As Boolean
        Public Property YearCancelEnabled As Boolean
        Public Property YearDeleteEnabled As Boolean

        Public Property SpotRadioCountyIsDirty As Boolean

        Public Property SpotRadioCountyResearchCriteriaList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria)
        Public Property SpotRadioCountySelectedResearchCriteria As AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchCriteria

        Public Property SpotRadioCountyList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.County)
        Public Property SpotRadioCountyResearchReportTypeList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property SpotRadioCountyMediaDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

        Public Property SpotRadioCountyYearList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year)
        Public Property SpotRadioCountyYearRepository As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property SpotRadioCountyAvailableYears As Generic.List(Of Short)
        Public Property SpotRadioCountyAvailableMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)
        Public Property SpotRadioCountySelectedMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)

        Public Property SpotRadioCountyAvailableStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station)
        Public Property SpotRadioCountySelectedStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station)

        Public Property SpotRadioCountyResearchResultList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.ResearchResult)
        Public Property SpotRadioCountyReportDataTable As System.Data.DataTable

        Public Property SpotRadioCountyWeightingFlags As IEnumerable(Of String)

#End Region

#Region " Available Books "

        Public Property AvailableBooks_NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
        Public Property AvailableBooks_NielsenRadioPeriods As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

#End Region

#Region " National "

        Public Property NationalAddEnabled As Boolean

        Public ReadOnly Property NationalExportEnabled As Boolean
            Get
                NationalExportEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing AndAlso Me.NationalReportDataTable IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property NationalEditEnabled As Boolean
            Get
                NationalEditEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property NationalDeleteEnabled As Boolean
            Get
                NationalDeleteEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property NationalCopyEnabled As Boolean
            Get
                NationalCopyEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing
            End Get
        End Property
        Public ReadOnly Property NationalProcessEnabled As Boolean
            Get
                NationalProcessEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing AndAlso Not Me.NationalIsDirty
            End Get
        End Property
        Public ReadOnly Property NationalSaveEnabled As Boolean
            Get
                NationalSaveEnabled = Me.NationalSelectedResearchCriteria IsNot Nothing AndAlso Me.NationalIsDirty
            End Get
        End Property

        Public Property NationalIsDirty As Boolean

        Public Property NationalResearchCriteriaList As Generic.List(Of AdvantageFramework.DTO.Media.National.ResearchCriteria)
        Public Property NationalSelectedResearchCriteria As AdvantageFramework.DTO.Media.National.ResearchCriteria

        Public Property NationalResearchReportTypeList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property NationalResearchReportStreamList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property NationalDemographicAvailableList As Generic.List(Of AdvantageFramework.DTO.Media.National.Demographic)
        Public Property NationalDemographicSelectedList As Generic.List(Of AdvantageFramework.DTO.Media.National.Demographic)

        Public Property NationalMetricAvailableList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)
        Public Property NationalMetricSelectedList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)

        Public Property NationalNetworkList As Generic.List(Of AdvantageFramework.DTO.Media.National.Network)
        Public Property NationalNetworkAvailableList As Generic.List(Of AdvantageFramework.DTO.Media.National.Network)
        Public Property NationalNetworkSelectedList As Generic.List(Of AdvantageFramework.DTO.Media.National.Network)

        Public Property NationalReportDataTable As System.Data.DataTable

#End Region

#End Region

#Region " Methods "

        Public Sub New()

            'radio
            Me.AvailableStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

            Me.SelectedStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

            'tv
            Me.SpotTVAvailableNielsenStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)
            Me.SpotTVSelectedNielsenStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Station)

            Me.SpotTVAvailableDemographicList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic)
            Me.SpotTVSelectedDemographicList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.Demographic)

            'BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel.ShareHPUTBooks.Clear()
            'BroadcastResearchViewModel.SpotTVShareHPUTBookViewModel.SelectedShareHPUTBooks.Clear()

            Me.SpotTVAvailableMetricList = New Generic.List(Of AdvantageFramework.DTO.Media.Metric)
            Me.SpotTVSelectedMetricList = New Generic.List(Of AdvantageFramework.DTO.Media.Metric)

            'spot radio county
            Me.SpotRadioCountyYearList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Year)

            Me.SpotRadioCountySelectedMetricList = New Generic.List(Of AdvantageFramework.DTO.Media.Metric)

            Me.SpotRadioCountyAvailableStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station)
            Me.SpotRadioCountySelectedStationList = New Generic.List(Of AdvantageFramework.DTO.Media.SpotRadioCounty.Station)
            Me.SpotRadioCountyYearRepository = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            AvailableBooks_NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)
            AvailableBooks_NielsenRadioPeriods = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            'National
            Me.NationalNetworkAvailableList = New Generic.List(Of DTO.Media.National.Network)
            Me.NationalNetworkSelectedList = New Generic.List(Of DTO.Media.National.Network)

            Me.NationalDemographicSelectedList = New Generic.List(Of DTO.Media.National.Demographic)
            Me.NationalDemographicAvailableList = New Generic.List(Of DTO.Media.National.Demographic)

        End Sub

#End Region

    End Class

End Namespace