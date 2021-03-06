Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetBroadcastScheduleStationSummary

#Region " Constants "

#End Region

#Region " Enum "

        Enum Properties

            ClientCode
            DivisionCode
            ProductCode
            MediaBroadcastWorksheetMarketID
            DemographicGroup
            VendorCode
            VendorName
            Spots
            StationGross
            MarketGross
            BudgetGross
            StationPercent

            Group1Name
            Group2Name

            PrimaryCumeImpressions
            SecondaryCumeImpressions
            PrimaryGrossImpressions
            SecondaryGrossImpressions
            PrimaryRating
            SecondaryRating
            PrimaryImpressions
            SecondaryImpressions
            BookPrimaryRating
            BookSecondaryRating
            BookPrimaryAHQRating
            BookSecondaryAHQrating
            PrimaryUniverse
            SecondaryUniverse

            Group1PrimaryCPP
            Group2PrimaryCPP


            Group1PrimaryGRP
            Group2PrimaryGRP


            Group1ReachPCT
            Group2ReachPCT

            Group1TotalReachPCT
            Group2TotalReachPCT

            Group1Frequency
            Group2Frequency

            Group1TotalFrequency
            Group2TotalFrequency

            TotalStationGross
            Group1TotalGRP
            Group2TotalGRP

            Group1CPM
            Group2CPM
            'Header Band

            Name
            ClientName
            WorksheetName
            HeaderBand
            Media
            Product
            Market
            MarketDescription
            PrimaryDemographic
            Separation
            EstimateComments
            Estimate
            Description
            StartDate
            EndDate
            Survey
            Buyer
            BuyOrder
            BuyRevision
            BillingName
            BillingAddress1
            BillingAddress2
            BillingCity
            BillingState
            BillingZip
            BillingPhone
            BillingPhoneExtension
            BillingFax
            BillingFaxExtension

            VendorAddress1
            VendorAddress2
            VendorAddress3
            VendorAddressCity
            VendorAddressState
            VendorAddressZip
            DivisionName
            SharebookNielsenTVBookID
            HutputNielsenTVBookID
            RadioBookID1
            RadioBookID2
            RadioBookID3
            RadioBookID4
            RadioBookID5
            RatingsServiceID
            TRSource1
            TRSource2
            SurveyLine2
            PageHeaderLogoPathLand
            PageHeaderComment
            RatingsSource
            UsePrimaryDemo
            MediaTypeCode
            RadioSource

            IsGross

            ShowRatings
            ShowComments
            ShowSpotCosts
            ShowImpressions
            ShowBookends
            ShowTotalCosts
            ShowCPPM
            ShowAddedValue
            ShowRF
        End Enum
#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property DemographicGroup As String
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property Spots As Integer
        Public Property StationGross As Decimal
        Public Property MarketGross As Decimal
        Public Property BudgetGross As Decimal
        Public Property StationPercent As Decimal
        Public Property Group1Name As String
        Public Property Group2Name As String
        Public Property PrimaryCumeImpressions As Nullable(Of Int64)
        Public Property SecondaryCumeImpressions As Nullable(Of Int64)
        Public Property PrimaryGrossImpressions As Nullable(Of Int64)
        Public Property SecondaryGrossImpressions As Nullable(Of Int64)
        Public Property PrimaryImpressions As Nullable(Of Int64)
        Public Property SecondaryImpressions As Nullable(Of Int64)
        Public Property PrimaryRating As Nullable(Of Decimal)
        Public Property SecondaryRating As Nullable(Of Decimal)
        Public Property BookPrimaryRating As Nullable(Of Decimal)
        Public Property BookSecondaryRating As Nullable(Of Decimal)
        Public Property BookPrimaryAHQRating As Nullable(Of Decimal)
        Public Property BookSecondaryAHQrating As Nullable(Of Decimal)
        Public Property PrimaryUniverse As Nullable(Of Int64)
        Public Property SecondaryUniverse As Nullable(Of Int64)
        Public Property Group1PrimaryCPP As Decimal
        Public Property Group2PrimaryCPP As Decimal
        Public Property Group1PrimaryGRP As Double
        Public Property Group2PrimaryGRP As Double
        Public Property Group1ReachPCT As Decimal
        Public Property Group2ReachPCT As Decimal

        Public Property Group1TotalReachPCT As Decimal
        Public Property Group2TotalReachPCT As Decimal

        'Public Property Group1PCT As Decimal
        'Public Property Group2PCT As Decimal
        Public Property Group1Frequency As Decimal
        Public Property Group2Frequency As Decimal

        Public Property Group1TotalFrequency As Double
        Public Property Group2TotalFrequency As Double


        Public Property TotalStationGross As Decimal
        Public Property Group1TotalGRP As Double
        Public Property Group2TotalGRP As Double
        Public Property Group1CPM As Decimal
        Public Property Group2CPM As Decimal

        'Header
        Public Property Name As String
        Public Property ClientName As String
        Public Property WorksheetName As String

        Public Property HeaderBand As String
        Public Property Media As String
        Public Property Product As String
        Public Property Market As String
        Public Property MarketDescription As String
        Public Property PrimaryDemographic As String
        Public Property Separation As Integer
        Public Property EstimateComments As String
        Public Property Estimate As String
        Public Property Description As String
        Public Property StartDate As DateTime
        Public Property EndDate As DateTime
        Public Property Survey As String
        Public Property Buyer As String
        Public Property BuyOrder As String
        Public Property BuyRevision As Integer
        Public Property BillingName As String
        Public Property BillingAddress1 As String
        Public Property BillingAddress2 As String
        Public Property BillingCity As String
        Public Property BillingState As String
        Public Property BillingZip As String
        Public Property BillingPhone As String
        Public Property BillingPhoneExtension As String
        Public Property BillingFax As String
        Public Property BillingFaxExtension As String
        Public Property VendorAddress1 As String
        Public Property VendorAddress2 As String
        Public Property VendorAddress3 As String
        Public Property VendorAddressCity As String
        Public Property VendorAddressState As String
        Public Property VendorAddressZip As String
        Public Property DivisionName As String
        Public Property SharebookNielsenTVBookID As Nullable(Of Integer)
        Public Property HutputNielsenTVBookID As Nullable(Of Integer)
        Public Property RadioBookID1 As Nullable(Of Integer)
        Public Property RadioBookID2 As Nullable(Of Integer)
        Public Property RadioBookID3 As Nullable(Of Integer)
        Public Property RadioBookID4 As Nullable(Of Integer)
        Public Property RadioBookID5 As Nullable(Of Integer)
        Public Property RatingsServiceID As Nullable(Of Integer)
        Public Property TRSource1 As String
        Public Property TRSource2 As String
        Public Property SurveyLine2 As String
        Public Property PageHeaderLogoPathLand As String
        Public Property PageHeaderComment As String
        Public Property RatingsSource As String
        Public Property UsePrimaryDemo As Nullable(Of Integer)
        Public Property MediaTypeCode As String
        Public Property RadioSource As String

        Public Property IsGross As Boolean

        Public Property ShowRatings As Boolean
        Public Property ShowComments As Boolean
        Public Property ShowSpotCosts As Boolean
        Public Property ShowImpressions As Boolean
        Public Property ShowBookends As Boolean
        Public Property ShowTotalCosts As Boolean
        Public Property ShowCPPM As Boolean
        Public Property ShowAddedValue As Boolean
        Public Property ShowRF As Boolean
#End Region

#Region " Methods "

#End Region

    End Class

End Namespace

