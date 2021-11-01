Namespace ViewModels.Media

    Public Class MediaRequestForProposalViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsNielsenSetup As Boolean
        Public Property IsAgencyASP As Boolean

        Public Property SelectedMediaRFPHeader As AdvantageFramework.DTO.Media.RFP.MediaRFPHeader

        Public Property MediaRFPHeaderStatuses As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeaderStatus)

        Public Property MediaRFPHeaders As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

        Public Property MediaRFPAvailLines As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

        Public Property MediaRFPDemos As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

        Public Property RepositoryStatusList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property RepositoryDaypartList As Generic.List(Of AdvantageFramework.DTO.Daypart)

        Public Property RepositoryMediaDemographicList As Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

        Public Property RepositoryCableNetworkStations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

        Public ReadOnly Property AddToWorksheetEnabled As Boolean
            Get
                AddToWorksheetEnabled = MediaRFPAvailLines.Where(Function(AL) AL.Status = AdvantageFramework.Database.Entities.MediaRFPAvailLineStatus.P.ToString AndAlso
                                                                              AL.HasError = False AndAlso
                                                                              AL.MediaBroadcastWorksheetMarketDetailID.HasValue = False).Any
            End Get
        End Property

        Public Property RFPGuidelines As String

        Public Property BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)

        Public Property MediaBroadcastWorksheetMarketID As Integer

        Public Property MediaBroadcastWorksheetRatingsServiceID As AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID

        Public Property ComscoreMarketNumber As Nullable(Of Short)

        Public Property IsCanadianWorksheet As Boolean

        Public Property MediaRFPMarkets As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket)

        Public Property RepositoryMarketList As Generic.List(Of AdvantageFramework.DTO.Market)

        Public Property MediaTypeCode As String

        Public Property WorksheetHasDemos As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            MediaRFPHeaders = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

            MediaRFPHeaderStatuses = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeaderStatus)

            MediaRFPAvailLines = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPAvailLine)

            MediaRFPDemos = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPDemo)

            RepositoryStatusList = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            RepositoryDaypartList = New Generic.List(Of AdvantageFramework.DTO.Daypart)

            RepositoryMediaDemographicList = New Generic.List(Of AdvantageFramework.DTO.Media.MediaDemographic)

            RepositoryCableNetworkStations = New Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

            BroadcastCalendarWeeks = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek)

            MediaBroadcastWorksheetRatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen

            Me.IsCanadianWorksheet = False

            Me.MediaRFPMarkets = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarket)

            Me.RepositoryMarketList = New Generic.List(Of AdvantageFramework.DTO.Market)

            Me.WorksheetHasDemos = False

        End Sub

#End Region

    End Class

End Namespace
