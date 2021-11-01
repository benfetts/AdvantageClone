Namespace Classes.Media.Nielsen

    Public Class LeadInLeadOutParameters

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ShowLeadInLeadOut
            NielsenMarketNumber
            ShareBookID
            HPUTBookID
            MediaDemoTypes
            MediaDemoDetailTypes
            StationCode
            MediaSpotTVResearchDaytimeTypes
            VendorNCCTVSyscodeID
            TVGeography
            Week
            StartTime
            EndTime
            LeadInStartEndTime
            LeadOutStartEndTime
            PercentStartTime1
            PercentStartTime2
            PercentEndTime1
            PercentEndTime2
            IsQuarterHours
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ShowLeadInLeadOut As Boolean
        Public Property NielsenMarketNumber As Integer
        Public Property ShareBookID As Integer
        Public Property HPUTBookID As Integer
        Public Property MediaDemoTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaDemoType)
        Public Property MediaDemoDetailTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaDemoDetailType)
        Public Property StationCode As Integer
        Public Property MediaSpotTVResearchDaytimeTypes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)
        Public Property VendorNCCTVSyscodeID As Integer
        Public Property TVGeography As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies
        Public Property Week As Integer
        Public Property StartEndTimes As Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime)
        Public Property LeadInStartEndTime As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime
        Public Property LeadOutStartEndTime As AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime
        Public Property PercentStartTime1 As Decimal
        Public Property PercentStartTime2 As Decimal
        Public Property PercentEndTime1 As Decimal
        Public Property PercentEndTime2 As Decimal
        Public Property IsQuarterHours As Boolean
        Public Property ComscoreMarketNumber As Integer
        Public Property CallLetters As String
        Public Property ComscoreDemoNumber As Integer
        Public Property StationNumber As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.ShowLeadInLeadOut = False
            Me.NielsenMarketNumber = 0
            Me.ShareBookID = 0
            Me.HPUTBookID = 0
            Me.MediaDemoTypes = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaDemoType)
            Me.MediaDemoDetailTypes = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaDemoDetailType)
            Me.StationCode = 0
            Me.MediaSpotTVResearchDaytimeTypes = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.MediaSpotTVResearchDaytimeType)
            Me.VendorNCCTVSyscodeID = 0
            Me.TVGeography = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.TVGeographies.DMA
            Me.NielsenMarketNumber = 0
            Me.StartEndTimes = New Generic.List(Of AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime)
            Me.LeadInStartEndTime = New AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime
            Me.LeadOutStartEndTime = New AdvantageFramework.Classes.Media.Nielsen.LeadInLeadOutStartEndTime
            Me.PercentStartTime1 = 0
            Me.PercentStartTime2 = 0
            Me.PercentEndTime1 = 0
            Me.PercentEndTime2 = 0
            Me.IsQuarterHours = False
            Me.ComscoreMarketNumber = 0
            Me.CallLetters = String.Empty
            Me.ComscoreDemoNumber = 0
            Me.StationNumber = 0

        End Sub

#End Region

    End Class

End Namespace
