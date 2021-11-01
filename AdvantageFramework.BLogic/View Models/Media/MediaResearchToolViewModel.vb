Namespace ViewModels.Media

    Public Class MediaResearchToolViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property NielsenStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)
        Public Property AudienceMetricList As Generic.List(Of AdvantageFramework.Database.Classes.AudienceMetric)
        Public Property MediaDemographicTVList As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
        Public Property TVMarketList As Generic.List(Of AdvantageFramework.Database.Entities.Market)

		Public Property NielsenDataStreamDataTable As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property NielsenServiceDataTable As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property NielsenSampleTypeDataTable As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

		Public Property MonthList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property NielsenBroadcastStartDate As Nullable(Of Date)
        Public Property NielsenBroadcastEndDate As Nullable(Of Date)

        'National
        Public Property NationalBroadcastTypeList As Generic.List(Of AdvantageFramework.Database.Entities.BroadcastType)
        Public Property NationalRatingsServiceList As Generic.List(Of AdvantageFramework.Database.Entities.RatingsService)
        Public Property NationalMediaMarketBreakList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.MediaMarketBreak)

        Public Property NationalNielsenTimeTypeDataTable As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property NielsenNationalDataStreamDataTable As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
		Public Property NationalMediaDemographicTVList As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
        Public Property NationalAudienceMetricList As Generic.List(Of AdvantageFramework.Database.Classes.NationalAudienceMetric)

        'Radio
        Public Property NielsenRadioPeriodList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod)
        Public Property NielsenRadioMarketList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioMarket)
        Public Property NielsenRadioGeoIndicatorDataTable As IEnumerable(Of Object)
        Public Property NielsenRadioDaypartList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioDaypart)
        Public Property NielsenRadioStationList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)
        Public Property RadioMediaDemographicList As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
        Public Property RadioWorksheetMetricList As Generic.List(Of AdvantageFramework.Database.Classes.RadioWorksheetMetric)

        'comScore
        Public Property ComscoreLocalTimeViewsResponseList As Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse)
        Public Property ComscoreMarketList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property ComscoreStartDate As Date
        Public Property ComscoreStartTime As Date
        Public Property ComscoreEndDate As Date
        Public Property ComscoreEndTime As Date

        Public Property ComscoreQuarterHourStart As Date
        Public Property ComscoreQuarterHourEnd As Date

        Public Property ComscoreSelectedMarketNumber As Integer
        Public Property ComscoreAvailableTVStationList As Generic.List(Of AdvantageFramework.Database.Entities.ComscoreTVStation)
        Public Property ComscoreSelectedTVStationList As Generic.List(Of AdvantageFramework.Database.Entities.ComscoreTVStation)
        Public Property ComscoreMediaDemographicList As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
        Public Property ComscoreSelectedMediaDemographicList As Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)

        Public Property JSONOrdinalComscoreDemoNumbers As Dictionary(Of Integer, Integer)

        Public Property ComscoreClientID As String
        Public Property ComscoreClientSecret As String
        Public Property ComscoreAsClientID As String
        Public Property ComscoreLocalTimeViewList As Generic.List(Of DTO.Media.ComscoreLocalTimeView)
        Public Property ComscoreJSONRequestString As String

#End Region

#Region " Methods "

        Public Sub New()

            ComscoreLocalTimeViewsResponseList = New Generic.List(Of Services.ComScore.Classes.LocalTimeViewsResponse)
            ComscoreMarketList = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            ComscoreMediaDemographicList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)
            ComscoreAvailableTVStationList = New Generic.List(Of AdvantageFramework.Database.Entities.ComscoreTVStation)
            ComscoreSelectedTVStationList = New Generic.List(Of AdvantageFramework.Database.Entities.ComscoreTVStation)
            ComscoreSelectedMediaDemographicList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaDemographic)

            JSONOrdinalComscoreDemoNumbers = New Dictionary(Of Integer, Integer)

        End Sub

#End Region

    End Class

End Namespace