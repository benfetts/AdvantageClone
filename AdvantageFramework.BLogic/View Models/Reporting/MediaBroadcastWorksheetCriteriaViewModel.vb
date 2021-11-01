Namespace ViewModels.Reporting

    Public Class MediaBroadcastWorksheetCriteriaViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property WorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
        Public Property AllWorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
        'Public Property MediaBroadcastWorksheetMarketBooks As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)
        Public Property MediaBroadcastWorksheetMarketBooksPreBuy As Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

        Public Property RepositoryNielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

        Public Property MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing

        Public Property RepositoryMediaDemographics As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic) = Nothing

        Public Property Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing

        Public Property RepositoryYearMonths As Generic.List(Of AdvantageFramework.DTO.YearMonth) = Nothing

        Public Property BypassLoadingYearMonthRepository As Boolean

        Public Property RatingsServiceList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property MediaType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType

        Public Property RepositoryNielsenRadioBooks As Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

        Public ReadOnly Property HasPrimaryDemographic As Boolean
            Get
                HasPrimaryDemographic = (Me.MediaBroadcastWorksheet IsNot Nothing AndAlso Me.MediaBroadcastWorksheet.PrimaryMediaDemographicID.GetValueOrDefault(0) > 0)
            End Get
        End Property

        Public Property RepositoryRadioMediaDemographics As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic) = Nothing

        Public Property BuyType As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType

#End Region

#Region " Methods "

        Public Sub New()

            _WorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
            _AllWorksheetMarketVendors = New Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)
            '_MediaBroadcastWorksheetMarketBooks = New Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)
            _MediaBroadcastWorksheetMarketBooksPreBuy = New Generic.List(Of AdvantageFramework.DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook)

            _RepositoryNielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            _RepositoryMediaDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            _Clients = New Generic.List(Of AdvantageFramework.Database.Core.Client)

            _RepositoryYearMonths = New Generic.List(Of AdvantageFramework.DTO.YearMonth)

            _RepositoryNielsenRadioBooks = New Generic.List(Of AdvantageFramework.DTO.Media.NielsenRadioPeriod)

            _RepositoryRadioMediaDemographics = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

        End Sub

#End Region

    End Class

End Namespace