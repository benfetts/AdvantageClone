Namespace Media.Classes

    <Serializable()> _
    Public Class MediaOrderLine

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            OrderType
            OrderTypeName
            MediaType
            [Status]
            IsOrder
            OrderDate
            OrderNumber
            OrderDescription
            OrderLineStatus
            OrderLineStatusDescription
            OrderLineStartDate
            OrderLineEndDate
            OfficeCode
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            JobNumber
            JobComponentNumber
            CampaignIdentifier
            CampaignCode
            CampaignName
            VendorCode
            VendorName
            Buyer
            ClientPO
            MarketCode
            MarketDescription
            OrderAccepted
            LineNumber
            ActiveRevision
            FlightDates
            StartDate
            EndDate
            MediaMonth
            MediaYear
            CloseDate
            MatlCloseDate
            ExtCloseDate
            ExtMatlCloseDate
            Size
            PrintColumn
            PrintInches
            PrintLines
            AdNumber
            AdNumberDescription
            Headline
            InternetType
            OutdoorType
            Material
            EditionIssue
            Section
            StartTime
            EndTime
            [Length]
            Tag
            Programming
            MatlNotes
            Remarks
            ProductionSize
            EstimateNumber
            EstimateLineNumber
            EstimateRevisionNumber
            LineTotal
            CostPer
            Impressions
            LineIsCancelled
            RevisionNumber
            MatCompDate
            AdSizeCode
            AdSizeDescription
            DateToBill
            OrderProcessingControl
            Quantity
            Rate
            BillingAmount
            GrossAmount
            NetAmount
            SequenceNumber
            IsInJob
            IsInJobText

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property OrderType As String = String.Empty
        Public Property OrderTypeName As String = String.Empty
        Public Property MediaType As String = String.Empty
        Public Property [Status] As String = String.Empty
        Public Property IsOrder As Nullable(Of Boolean) = False
        Public Property OrderDate As Nullable(Of Date) = Nothing
        Public Property OrderNumber As Nullable(Of Integer) = 0
        Public Property OrderDescription As String = String.Empty
        Public Property OrderLineStatus As Nullable(Of Short) = 0
        Public Property OrderLineStatusDescription As String = String.Empty
        Public Property OrderLineStartDate As Nullable(Of Date) = Nothing
        Public Property OrderLineEndDate As Nullable(Of Date) = Nothing
        Public Property OfficeCode As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property ProductDescription As String = String.Empty
        Public Property JobNumber As Nullable(Of Integer) = 0
        Public Property JobComponentNumber As Nullable(Of Short) = 0
        Public Property CampaignIdentifier As Nullable(Of Integer) = 0
        Public Property CampaignCode As String = String.Empty
        Public Property CampaignName As String = String.Empty
        Public Property VendorCode As String = String.Empty
        Public Property VendorName As String = String.Empty
        Public Property Buyer As String = String.Empty
        Public Property ClientPO As String = String.Empty
        Public Property MarketCode As String = String.Empty
        Public Property MarketDescription As String = String.Empty
        Public Property OrderAccepted As Nullable(Of Boolean) = False
        Public Property LineNumber As Nullable(Of Integer) = 0
        Public Property ActiveRevision As Nullable(Of Boolean) = False
        Public Property FlightDates As String = String.Empty
        Public Property StartDate As Nullable(Of Date) = Nothing
        Public Property EndDate As Nullable(Of Date) = Nothing
        Public Property MediaMonth As String = String.Empty
        Public Property MediaYear As String = String.Empty
        Public Property CloseDate As Nullable(Of Date) = Nothing
        Public Property MatlCloseDate As Nullable(Of Date) = Nothing
        Public Property ExtCloseDate As Nullable(Of Date) = Nothing
        Public Property ExtMatlCloseDate As Nullable(Of Date) = Nothing
        Public Property Size As String = String.Empty
        Public Property PrintColumn As Nullable(Of Decimal) = 0
        Public Property PrintInches As Nullable(Of Decimal) = 0
        Public Property PrintLines As Nullable(Of Decimal) = 0
        Public Property AdNumber As String = String.Empty
        Public Property AdNumberDescription As String = String.Empty
        Public Property Headline As String = String.Empty
        Public Property InternetType As String = String.Empty
        Public Property OutdoorType As String = String.Empty
        Public Property Material As String = String.Empty
        Public Property EditionIssue As String = String.Empty
        Public Property Section As String = String.Empty
        Public Property StartTime As String = String.Empty
        Public Property EndTime As String = String.Empty
        Public Property [Length] As String = String.Empty
        Public Property Tag As String = String.Empty
        Public Property Programming As String = String.Empty
        Public Property MatlNotes As String = String.Empty
        Public Property Remarks As String = String.Empty
        Public Property ProductionSize As String = String.Empty
        Public Property EstimateNumber As Nullable(Of Integer) = 0
        Public Property EstimateLineNumber As Nullable(Of Integer) = 0
        Public Property EstimateRevisionNumber As Nullable(Of Integer) = 0
        Public Property LineTotal As Nullable(Of Decimal) = 0
        Public Property CostPer As Nullable(Of Decimal) = 0
        Public Property Impressions As Nullable(Of Decimal) = 0
        Public Property LineIsCancelled As Nullable(Of Boolean)
        Public Property RevisionNumber As Nullable(Of Integer) = 0
        Public Property MatCompDate As Nullable(Of Date) = Nothing
        Public Property AdSizeCode As String = String.Empty
        Public Property AdSizeDescription As String = String.Empty
        Public Property DateToBill As Nullable(Of Date) = Nothing
        Public Property OrderProcessingControl As Nullable(Of Short) = 0
        Public Property Quantity As Nullable(Of Decimal) = 0
        Public Property Rate As Nullable(Of Decimal) = 0
        Public Property BillingAmount As Nullable(Of Decimal) = 0
        Public Property GrossAmount As Nullable(Of Decimal) = 0
        Public Property NetAmount As Nullable(Of Decimal) = 0
        Public Property SequenceNumber As Nullable(Of Short) = 0
        Public Property IsInJob As Nullable(Of Boolean) = False
        Public Property IsInJobText As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
