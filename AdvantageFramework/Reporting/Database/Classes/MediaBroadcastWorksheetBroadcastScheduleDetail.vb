Namespace Reporting.Database.Classes

    <Serializable>
    Public Class MediaBroadcastWorksheetBroadcastScheduleDetail

#Region " Constants "

#End Region

#Region " Enum "

        Public Enum Properties

            BucketRow
            BucketLastRow
            ClientCode
            DivisionCode
            ProductCode
            MediaBroadcastWorksheetMarketID
            RatingsSource
            VendorCode
            LineNumber
            MakeGoodNumber
            Days
            Length
            StationGross
            Earliestdate
            Week1Date
            Week2Date
            Week3Date
            Week4Date
            Week5Date
            Week6Date
            Week7Date
            Week8Date
            Week9Date
            Week10Date
            Week11Date
            Week12Date
            Week13Date
            Week14Date

            Week1Spots
            Week2Spots
            Week3Spots
            Week4Spots
            Week5Spots
            Week6Spots
            Week7Spots
            Week8Spots
            Week9Spots
            Week10Spots
            Week11Spots
            Week12Spots
            Week13Spots
            Week14Spots
            TotalSpots

            Week1PrimaryGRP
            Week2PrimaryGRP
            Week3PrimaryGRP
            Week4PrimaryGRP
            Week5PrimaryGRP
            Week6PrimaryGRP
            Week7PrimaryGRP
            Week8PrimaryGRP
            Week9PrimaryGRP
            Week10PrimaryGRP
            Week11PrimaryGRP
            Week12PrimaryGRP
            Week13PrimaryGRP
            Week14PrimaryGRP

            Week1PrimaryGrossImpressions
            Week2PrimaryGrossImpressions
            Week3PrimaryGrossImpressions
            Week4PrimaryGrossImpressions
            Week5PrimaryGrossImpressions
            Week6PrimaryGrossImpressions
            Week7PrimaryGrossImpressions
            Week8PrimaryGrossImpressions
            Week9PrimaryGrossImpressions
            Week10PrimaryGrossImpressions
            Week11PrimaryGrossImpressions
            Week12PrimaryGrossImpressions
            Week13PrimaryGrossImpressions
            Week14PrimaryGrossImpressions

            Week1PrimaryCPP
            Week2PrimaryCPP
            Week3PrimaryCPP
            Week4PrimaryCPP
            Week5PrimaryCPP
            Week6PrimaryCPP
            Week7PrimaryCPP
            Week8PrimaryCPP
            Week9PrimaryCPP
            Week10PrimaryCPP
            Week11PrimaryCPP
            Week12PrimaryCPP
            Week13PrimaryCPP
            Week14PrimaryCPP

            Week1PrimaryCPM
            Week2PrimaryCPM
            Week3PrimaryCPM
            Week4PrimaryCPM
            Week5PrimaryCPM
            Week6PrimaryCPM
            Week7PrimaryCPM
            Week8PrimaryCPM
            Week9PrimaryCPM
            Week10PrimaryCPM
            Week11PrimaryCPM
            Week12PrimaryCPM
            Week13PrimaryCPM
            Week14PrimaryCPM

            Week1Costs
            Week2Costs
            Week3Costs
            Week4Costs
            Week5Costs
            Week6Costs
            Week7Costs
            Week8Costs
            Week9Costs
            Week10Costs
            Week11Costs
            Week12Costs
            Week13Costs
            Week14Costs

            DemographicGroupName

            DemographicGroupRTG
            DemographicGroupIMP

            DemographicGroupCPP
            DemographicGroupCPM
            DemographicGroupGRP

            'Header Band

            Name
            ClientName
            WorksheetName
            HeaderBand
            Media
            Product
            Market
            PrimaryDemographic
            Separation
            EstimateComments
            Estimate
            Description
            StartDate
            EndDate
            Survey
            SurveyLine2
            Buyer
            Vendor
            VendorName
            VendorAddress1
            VendorAddress2
            VendorAddress3
            VendorCity
            VendorState
            VendorZip
            VendorPhone
            VendorPhoneExtension
            VendorFax
            VendorFaxExtension
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
            DivisionName
            SharebookNielsenTVBookID
            HutputNielsenTVBookID
            RatingsServiceID
            Quarter
            MediaGroupMetricID
            TRSource1
            TRSource2
            DayPartName
            ProgramName
            CableNetwork
            IsCable

            TotalGRP
            TotalGIMP

            PageHeaderLogoPathLand
            PageHeaderComment
            RadioBookID1
            RadioBookID2
            RadioBookID3
            RadioBookID4
            RadioBookID5
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

            Rate

            Comments
            IsBookend
            IsAddedValue

            GRPFormat

        End Enum
#End Region

#Region " Variables "

#End Region

#Region " Properties "
#Region "       Report Detail"
        Public Property BucketRow As Integer
        Public Property BucketLastRow As Boolean
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property RatingsSource As String
        Public Property VendorCode As String
        Public Property LineNumber As Integer
        Public Property MakeGoodNumber As Integer
        Public Property Days As String
        Public Property Length As Integer
        Public Property StationGross As Decimal
        Public Property EarliestDate As Date
        Public Property Week1Date As Nullable(Of Date)
        Public Property Week2Date As Nullable(Of Date)
        Public Property Week3Date As Nullable(Of Date)
        Public Property Week4Date As Nullable(Of Date)
        Public Property Week5Date As Nullable(Of Date)
        Public Property Week6Date As Nullable(Of Date)
        Public Property Week7Date As Nullable(Of Date)
        Public Property Week8Date As Nullable(Of Date)
        Public Property Week9Date As Nullable(Of Date)
        Public Property Week10Date As Nullable(Of Date)
        Public Property Week11Date As Nullable(Of Date)
        Public Property Week12Date As Nullable(Of Date)
        Public Property Week13Date As Nullable(Of Date)
        Public Property Week14Date As Nullable(Of Date)
        Public Property Week1Spots As Nullable(Of Integer)
        Public Property Week2Spots As Nullable(Of Integer)
        Public Property Week3Spots As Nullable(Of Integer)
        Public Property Week4Spots As Nullable(Of Integer)
        Public Property Week5Spots As Nullable(Of Integer)
        Public Property Week6Spots As Nullable(Of Integer)
        Public Property Week7Spots As Nullable(Of Integer)
        Public Property Week8Spots As Nullable(Of Integer)
        Public Property Week9Spots As Nullable(Of Integer)
        Public Property Week10Spots As Nullable(Of Integer)
        Public Property Week11Spots As Nullable(Of Integer)
        Public Property Week12Spots As Nullable(Of Integer)
        Public Property Week13Spots As Nullable(Of Integer)
        Public Property Week14Spots As Nullable(Of Integer)
        Public Property TotalSpots As Integer
        Public Property Week1PrimaryGRP As Nullable(Of Decimal)
        Public Property Week2PrimaryGRP As Nullable(Of Decimal)
        Public Property Week3PrimaryGRP As Nullable(Of Decimal)
        Public Property Week4PrimaryGRP As Nullable(Of Decimal)
        Public Property Week5PrimaryGRP As Nullable(Of Decimal)
        Public Property Week6PrimaryGRP As Nullable(Of Decimal)
        Public Property Week7PrimaryGRP As Nullable(Of Decimal)
        Public Property Week8PrimaryGRP As Nullable(Of Decimal)
        Public Property Week9PrimaryGRP As Nullable(Of Decimal)
        Public Property Week10PrimaryGRP As Nullable(Of Decimal)
        Public Property Week11PrimaryGRP As Nullable(Of Decimal)
        Public Property Week12PrimaryGRP As Nullable(Of Decimal)
        Public Property Week13PrimaryGRP As Nullable(Of Decimal)
        Public Property Week14PrimaryGRP As Nullable(Of Decimal)
        Public Property Week1PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week2PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week3PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week4PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week5PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week6PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week7PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week8PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week9PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week10PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week11PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week12PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week13PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week14PrimaryGrossImpressions As Nullable(Of Decimal)
        Public Property Week1PrimaryCPP As Nullable(Of Decimal)
        Public Property Week2PrimaryCPP As Nullable(Of Decimal)
        Public Property Week3PrimaryCPP As Nullable(Of Decimal)
        Public Property Week4PrimaryCPP As Nullable(Of Decimal)
        Public Property Week5PrimaryCPP As Nullable(Of Decimal)
        Public Property Week6PrimaryCPP As Nullable(Of Decimal)
        Public Property Week7PrimaryCPP As Nullable(Of Decimal)
        Public Property Week8PrimaryCPP As Nullable(Of Decimal)
        Public Property Week9PrimaryCPP As Nullable(Of Decimal)
        Public Property Week10PrimaryCPP As Nullable(Of Decimal)
        Public Property Week11PrimaryCPP As Nullable(Of Decimal)
        Public Property Week12PrimaryCPP As Nullable(Of Decimal)
        Public Property Week13PrimaryCPP As Nullable(Of Decimal)
        Public Property Week14PrimaryCPP As Nullable(Of Decimal)
        Public Property Week1PrimaryCPM As Nullable(Of Decimal)
        Public Property Week2PrimaryCPM As Nullable(Of Decimal)
        Public Property Week3PrimaryCPM As Nullable(Of Decimal)
        Public Property Week4PrimaryCPM As Nullable(Of Decimal)
        Public Property Week5PrimaryCPM As Nullable(Of Decimal)
        Public Property Week6PrimaryCPM As Nullable(Of Decimal)
        Public Property Week7PrimaryCPM As Nullable(Of Decimal)
        Public Property Week8PrimaryCPM As Nullable(Of Decimal)
        Public Property Week9PrimaryCPM As Nullable(Of Decimal)
        Public Property Week10PrimaryCPM As Nullable(Of Decimal)
        Public Property Week11PrimaryCPM As Nullable(Of Decimal)
        Public Property Week12PrimaryCPM As Nullable(Of Decimal)
        Public Property Week13PrimaryCPM As Nullable(Of Decimal)
        Public Property Week14PrimaryCPM As Nullable(Of Decimal)


        Public Property Week1Costs As Nullable(Of Decimal)
        Public Property Week2Costs As Nullable(Of Decimal)
        Public Property Week3Costs As Nullable(Of Decimal)
        Public Property Week4Costs As Nullable(Of Decimal)
        Public Property Week5Costs As Nullable(Of Decimal)
        Public Property Week6Costs As Nullable(Of Decimal)
        Public Property Week7Costs As Nullable(Of Decimal)
        Public Property Week8Costs As Nullable(Of Decimal)
        Public Property Week9Costs As Nullable(Of Decimal)
        Public Property Week10Costs As Nullable(Of Decimal)
        Public Property Week11Costs As Nullable(Of Decimal)
        Public Property Week12Costs As Nullable(Of Decimal)
        Public Property Week13Costs As Nullable(Of Decimal)
        Public Property Week14Costs As Nullable(Of Decimal)
        Public Property DemographicGroupName As String
        'Public Property DemographicGroup2Name As String
        Public Property DemographicGroupRTG As Nullable(Of Decimal)
        Public Property DemographicGroupIMP As Nullable(Of Decimal)
        Public Property DemographicGroupCPP As Nullable(Of Decimal)
        Public Property DemographicGroupCPM As Nullable(Of Decimal)
        Public Property DemographicGroupGRP As Nullable(Of Decimal)
        Public Property Name As String
        Public Property ClientName As String
        Public Property WorksheetName As String
        Public Property HeaderBand As String
        Public Property Media As String
        Public Property Product As String
        Public Property Market As String
        Public Property PrimaryDemographic As String
        Public Property Separation As Integer
        Public Property EstimateComments As String
        Public Property Estimate As String
        Public Property Description As String
        Public Property StartDate As DateTime
        Public Property EndDate As DateTime
        Public Property Survey As String
        Public Property SurveyLine2 As String
        Public Property Buyer As String
        Public Property Vendor As String
        Public Property VendorName As String
        Public Property VendorAddress1 As String
        Public Property VendorAddress2 As String
        Public Property VendorAddress3 As String
        Public Property VendorCity As String
        Public Property VendorState As String
        Public Property VendorZip As String
        Public Property VendorPhone As String
        Public Property VendorPhoneExtension As String
        Public Property VendorFax As String
        Public Property VendorFaxExtension As String
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
        Public Property DivisionName As String
        Public Property SharebookNielsenTVBookID As Nullable(Of Integer)
        Public Property HutputNielsenTVBookID As Nullable(Of Integer)
        Public Property RatingsServiceID As Nullable(Of Integer)
        Public Property Quarter As Integer
        Public Property MediaGroupMetricID As Nullable(Of Integer)
        Public Property TRSource1 As String
        Public Property TRSource2 As String
        Public Property DayPartName As String
        Public Property ProgramName As String
        Public Property CableNetwork As String
        Public Property IsCable As Boolean
        Public Property TotalGRP As Decimal
        Public Property TotalGIMP As Decimal
        Public Property PageHeaderLogoPathLand As String
        Public Property PageHeaderComment As String
        Public Property RadioBookID1 As Nullable(Of Integer)
        Public Property RadioBookID2 As Nullable(Of Integer)
        Public Property RadioBookID3 As Nullable(Of Integer)
        Public Property RadioBookID4 As Nullable(Of Integer)
        Public Property RadioBookID5 As Nullable(Of Integer)

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

        Public Property Rate As Nullable(Of Decimal)

        Public Property Comments As String
        Public Property IsBookend As Boolean
        Public Property IsAddedValue As Boolean

        Public Property GRPFormat As String

#End Region
#End Region

#Region " Methods "

#End Region

    End Class

End Namespace
