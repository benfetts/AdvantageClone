Namespace ViewModels.Media

    Public Class SpotRadioResearchViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

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
        Public ReadOnly Property ProcessEnabled As Boolean
            Get
                ProcessEnabled = Me.SelectedResearchCriteria IsNot Nothing AndAlso Not Me.IsDirty
            End Get
        End Property
        Public ReadOnly Property SaveEnabled As Boolean
            Get
                SaveEnabled = Me.SelectedResearchCriteria IsNot Nothing AndAlso Me.IsDirty
            End Get
        End Property

        Public Property BookIsNewRow As Boolean
        Public Property BookCancelEnabled As Boolean
        Public Property BookDeleteEnabled As Boolean

        Public Property DaypartIsNewRow As Boolean
        Public Property DaypartCancelEnabled As Boolean
        Public Property DaypartDeleteEnabled As Boolean

        Public Property IsDirty As Boolean

        Public Property ResearchCriteriaList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria)
        Public Property SelectedResearchCriteria As AdvantageFramework.DTO.Media.SpotRadio.ResearchCriteria

        Public Property RadioMarketList As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property MediaDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)
        Public Property NielsenRadioQualitativeList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioQualitative)

        Public Property NielsenRadioBookList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioBook)
        Public Property NielsenRadioPeriodRepository As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

        Public Property NielsenDaypartList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenDaypart)
        Public Property NielsenDaypartRepository As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.NielsenRadioDaypart)

        Public Property AvailableMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)
        Public Property SelectedMetricList As Generic.List(Of AdvantageFramework.DTO.Media.Metric)

        Public Property AvailableStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)
        Public Property SelectedStationList As Generic.List(Of AdvantageFramework.DTO.Media.SpotRadio.Station)

        Public Property AvailableNielsenRadioFormatList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioFormat)
        Public Property SelectedNielsenRadioFormatList As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioFormat)

        Public Property ResearchResultList As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.ResearchResult)
        Public Property ReportDataTable As System.Data.DataTable

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace