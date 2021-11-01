Namespace Reporting.Database.Classes

    <Serializable>
    Public Class DigitalResultsComparisonReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanID
            MediaPlanDescription
            ClientCode
            ClientName
            DivisonCode
            DivisionName
            ProductCode
            ProductName
            EstimateID
            EstimateDescription
            MediaType
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            VendorCode
            VendorName
            MarketCode
            MarketDescription
            AdSizeCode
            AdSizeDescription
            AdNumber
            AdNumberDescription
            InternetTypeCode
            InternetTypeDescription
            Placement
            PlacementPixelSize
            PlacementPixelURL
            Creative
            Tactic
            PagePositioning
            StartDate
            EndDate
            NetGrossRate
            Units
            Impressions
            Clicks
            ClickRate
            TotalConversions
            Rate
            NetDollars
            GrossDollars
            TargetAudience
            ImpressionsViewable
            ImpressionsMeasurable
            TotalConversionsB
            TotalConversionsC
            ConversionRate
            ConversionRateB
            ConversionRateC
            OfficeCode
            OfficeName
            Month
            Year
            PlanUnits
            PlanImpressions
            PlanClicks
            PlanDemo1
            PlanDemo2
            PlanQuantity
            PlanNetAmount
            PlanCommission
            PlanAgencyFee
            PlanBillAmount
            PlanRate
            PlanCPI
            PlanCTR
            PlanConversionRatePercent
            OrderQuantity
            OrderNetAmount
            OrderCommission
            OrderAgencyFee
            OrderBillAmount
            BilledQuantity
            BilledCommissionAmount
            BilledAgencyFee
            BilledNetAmount
            BilledBillAmount
            APQuantity
            APNetAmount
            PlanBillToOrderedBillVariance
            PlanBillToBilledVariance
            OrderedToBilledVariance
            OrderedToAPVariance
            OrderNumber
            LineNumber
            OrderDescription
            OrderComment
            OrderDate
            ClientPO
            LinkID
            LineLinkID
            OrderDateType
            InsertionDate
            OrderEndDate
            OrderMonth
            Orderyear
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            CostType
            ProjectedImpressions
            GuaranteedImpressions
            ActualImpressions
            LineDescription
            MiscellaneousInfo
            OrderCopy
            MaterialNotes
            ID
            DaypartCode
        End Enum

#End Region

#Region " Variables "

        Private _MediaPlanID As Nullable(Of Integer) = Nothing
        Private _MediaPlanDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisonCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _EstimateID As Nullable(Of Integer) = Nothing
        Private _EstimateDescription As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _AdSizeCode As String = Nothing
        Private _AdSizeDescription As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing
        Private _InternetTypeCode As String = Nothing
        Private _InternetTypeDescription As String = Nothing
        Private _Placement As String = Nothing
        Private _PlacementPixelSize As String = Nothing
        Private _PlacementPixelURL As String = Nothing
        Private _Creative As String = Nothing
        Private _Tactic As String = Nothing
        Private _PagePositioning As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _NetGrossRate As String = Nothing
        Private _Units As Nullable(Of Decimal) = Nothing
        Private _Impressions As Nullable(Of Integer) = Nothing
        Private _Clicks As Nullable(Of Decimal) = Nothing
        Private _ClickRate As Nullable(Of Decimal) = Nothing
        Private _TotalConversions As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _NetDollars As Nullable(Of Decimal) = Nothing
        Private _GrossDollars As Nullable(Of Decimal) = Nothing
        Private _TargetAudience As String = Nothing
        Private _ImpressionsViewable As Nullable(Of Decimal) = Nothing
        Private _ImpressionsMeasurable As Nullable(Of Decimal) = Nothing
        Private _TotalConversionsB As Nullable(Of Decimal) = Nothing
        Private _TotalConversionsC As Nullable(Of Decimal) = Nothing
        Private _ConversionRate As Nullable(Of Decimal) = Nothing
        Private _ConversionRateB As Nullable(Of Decimal) = Nothing
        Private _ConversionRateC As Nullable(Of Decimal) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _Month As Nullable(Of Integer) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _PlanUnits As Nullable(Of Decimal) = Nothing
        Private _PlanImpressions As Nullable(Of Decimal) = Nothing
        Private _PlanClicks As Nullable(Of Decimal) = Nothing
        Private _PlanDemo1 As Nullable(Of Decimal) = Nothing
        Private _PlanDemo2 As Nullable(Of Decimal) = Nothing
        Private _PlanQuantity As Nullable(Of Decimal) = Nothing
        Private _PlanNetAmount As Nullable(Of Decimal) = Nothing
        Private _PlanCommission As Nullable(Of Decimal) = Nothing
        Private _PlanAgencyFee As Nullable(Of Decimal) = Nothing
        Private _PlanBillAmount As Nullable(Of Decimal) = Nothing
        Private _PlanRate As Nullable(Of Decimal) = Nothing
        Private _PlanCPI As Nullable(Of Decimal) = Nothing
        Private _PlanCTR As Nullable(Of Decimal) = Nothing
        Private _PlanConversionRatePercent As Nullable(Of Decimal) = Nothing
        Private _OrderQuantity As Nullable(Of Integer) = Nothing
        Private _OrderNetAmount As Nullable(Of Decimal) = Nothing
        Private _OrderCommission As Nullable(Of Decimal) = Nothing
        Private _OrderAgencyFee As Nullable(Of Decimal) = Nothing
        Private _OrderBillAmount As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Integer) = Nothing
        Private _BilledCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _BilledAgencyFee As Nullable(Of Decimal) = Nothing
        Private _BilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledBillAmount As Nullable(Of Decimal) = Nothing
        Private _APQuantity As Nullable(Of Integer) = Nothing
        Private _APNetAmount As Nullable(Of Decimal) = Nothing
        Private _PlanBillToOrderedBillVariance As Nullable(Of Decimal) = Nothing
        Private _PlanBillToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToAPVariance As Nullable(Of Decimal) = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _OrderDescription As String = Nothing
        Private _OrderComment As String = Nothing
        Private _OrderDate As Nullable(Of Date) = Nothing
        Private _ClientPO As String = Nothing
        Private _LinkID As Nullable(Of Integer) = Nothing
        Private _LineLinkID As Nullable(Of Integer) = Nothing
        Private _OrderDateType As String = Nothing
        Private _InsertionDate As Nullable(Of Date) = Nothing
        Private _OrderEndDate As Nullable(Of Date) = Nothing
        Private _OrderMonth As String = Nothing
        Private _Orderyear As Nullable(Of Short) = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _CostType As String = Nothing
        Private _ProjectedImpressions As Nullable(Of Integer) = Nothing
        Private _GuaranteedImpressions As Nullable(Of Integer) = Nothing
        Private _ActualImpressions As Nullable(Of Integer) = Nothing
        Private _LineDescription As String = Nothing
        Private _MiscellaneousInfo As String = Nothing
        Private _OrderCopy As String = Nothing
        Private _MaterialNotes As String = Nothing
        Private _ID As Nullable(Of System.Guid) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set
                _ID = Value
            End Set
        End Property
        Public Property MediaPlanID() As Nullable(Of Integer)
            Get
                MediaPlanID = _MediaPlanID
            End Get
            Set
                _MediaPlanID = Value
            End Set
        End Property
        Public Property MediaPlanDescription() As String
            Get
                MediaPlanDescription = _MediaPlanDescription
            End Get
            Set
                _MediaPlanDescription = Value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set
                _ClientCode = Value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set
                _ClientName = Value
            End Set
        End Property
        Public Property DivisonCode() As String
            Get
                DivisonCode = _DivisonCode
            End Get
            Set
                _DivisonCode = Value
            End Set
        End Property
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set
                _DivisionName = Value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set
                _ProductCode = Value
            End Set
        End Property
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set
                _ProductName = Value
            End Set
        End Property
        Public Property EstimateID() As Nullable(Of Integer)
            Get
                EstimateID = _EstimateID
            End Get
            Set
                _EstimateID = Value
            End Set
        End Property
        Public Property EstimateDescription() As String
            Get
                EstimateDescription = _EstimateDescription
            End Get
            Set
                _EstimateDescription = Value
            End Set
        End Property
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set
                _MediaType = Value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set
                _SalesClassCode = Value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set
                _SalesClassDescription = Value
            End Set
        End Property
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set
                _CampaignID = Value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set
                _CampaignCode = Value
            End Set
        End Property
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set
                _CampaignName = Value
            End Set
        End Property
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set
                _VendorCode = Value
            End Set
        End Property
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set
                _VendorName = Value
            End Set
        End Property
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set
                _MarketCode = Value
            End Set
        End Property
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set
                _MarketDescription = Value
            End Set
        End Property
        Public Property AdSizeCode() As String
            Get
                AdSizeCode = _AdSizeCode
            End Get
            Set
                _AdSizeCode = Value
            End Set
        End Property
        Public Property AdSizeDescription() As String
            Get
                AdSizeDescription = _AdSizeDescription
            End Get
            Set
                _AdSizeDescription = Value
            End Set
        End Property
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set
                _AdNumber = Value
            End Set
        End Property
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set
                _AdNumberDescription = Value
            End Set
        End Property
        Public Property InternetTypeCode() As String
            Get
                InternetTypeCode = _InternetTypeCode
            End Get
            Set
                _InternetTypeCode = Value
            End Set
        End Property
        Public Property InternetTypeDescription() As String
            Get
                InternetTypeDescription = _InternetTypeDescription
            End Get
            Set
                _InternetTypeDescription = Value
            End Set
        End Property
        Public Property Placement() As String
            Get
                Placement = _Placement
            End Get
            Set
                _Placement = Value
            End Set
        End Property
        Public Property PlacementPixelSize() As String
            Get
                PlacementPixelSize = _PlacementPixelSize
            End Get
            Set
                _PlacementPixelSize = Value
            End Set
        End Property
        Public Property PlacementPixelURL() As String
            Get
                PlacementPixelURL = _PlacementPixelURL
            End Get
            Set
                _PlacementPixelURL = Value
            End Set
        End Property
        Public Property Creative() As String
            Get
                Creative = _Creative
            End Get
            Set
                _Creative = Value
            End Set
        End Property
        Public Property Tactic() As String
            Get
                Tactic = _Tactic
            End Get
            Set
                _Tactic = Value
            End Set
        End Property
        Public Property PagePositioning() As String
            Get
                PagePositioning = _PagePositioning
            End Get
            Set
                _PagePositioning = Value
            End Set
        End Property
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set
                _StartDate = Value
            End Set
        End Property
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set
                _EndDate = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Net / Gross Rate")>
        Public Property NetGrossRate() As String
            Get
                NetGrossRate = _NetGrossRate
            End Get
            Set
                _NetGrossRate = Value
            End Set
        End Property
        Public Property Units() As Nullable(Of Decimal)
            Get
                Units = _Units
            End Get
            Set
                _Units = Value
            End Set
        End Property
        Public Property Impressions() As Nullable(Of Integer)
            Get
                Impressions = _Impressions
            End Get
            Set
                _Impressions = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property Clicks() As Nullable(Of Decimal)
            Get
                Clicks = _Clicks
            End Get
            Set
                _Clicks = Value
            End Set
        End Property
        Public Property ClickRate() As Nullable(Of Decimal)
            Get
                ClickRate = _ClickRate
            End Get
            Set
                _ClickRate = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversions() As Nullable(Of Decimal)
            Get
                TotalConversions = _TotalConversions
            End Get
            Set
                _TotalConversions = Value
            End Set
        End Property
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set
                _Rate = Value
            End Set
        End Property
        Public Property NetDollars() As Nullable(Of Decimal)
            Get
                NetDollars = _NetDollars
            End Get
            Set
                _NetDollars = Value
            End Set
        End Property
        Public Property GrossDollars() As Nullable(Of Decimal)
            Get
                GrossDollars = _GrossDollars
            End Get
            Set
                _GrossDollars = Value
            End Set
        End Property
        Public Property TargetAudience() As String
            Get
                TargetAudience = _TargetAudience
            End Get
            Set
                _TargetAudience = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ImpressionsViewable() As Nullable(Of Decimal)
            Get
                ImpressionsViewable = _ImpressionsViewable
            End Get
            Set
                _ImpressionsViewable = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property ImpressionsMeasurable() As Nullable(Of Decimal)
            Get
                ImpressionsMeasurable = _ImpressionsMeasurable
            End Get
            Set
                _ImpressionsMeasurable = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversionsB() As Nullable(Of Decimal)
            Get
                TotalConversionsB = _TotalConversionsB
            End Get
            Set
                _TotalConversionsB = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property TotalConversionsC() As Nullable(Of Decimal)
            Get
                TotalConversionsC = _TotalConversionsC
            End Get
            Set
                _TotalConversionsC = Value
            End Set
        End Property
        Public Property ConversionRate() As Nullable(Of Decimal)
            Get
                ConversionRate = _ConversionRate
            End Get
            Set
                _ConversionRate = Value
            End Set
        End Property
        Public Property ConversionRateB() As Nullable(Of Decimal)
            Get
                ConversionRateB = _ConversionRateB
            End Get
            Set
                _ConversionRateB = Value
            End Set
        End Property
        Public Property ConversionRateC() As Nullable(Of Decimal)
            Get
                ConversionRateC = _ConversionRateC
            End Get
            Set
                _ConversionRateC = Value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set
                _OfficeCode = Value
            End Set
        End Property
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set
                _OfficeName = Value
            End Set
        End Property
        Public Property Month() As Nullable(Of Integer)
            Get
                Month = _Month
            End Get
            Set
                _Month = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set
                _Year = Value
            End Set
        End Property
        Public Property PlanUnits() As Nullable(Of Decimal)
            Get
                PlanUnits = _PlanUnits
            End Get
            Set
                _PlanUnits = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property PlanImpressions() As Nullable(Of Decimal)
            Get
                PlanImpressions = _PlanImpressions
            End Get
            Set
                _PlanImpressions = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property PlanClicks() As Nullable(Of Decimal)
            Get
                PlanClicks = _PlanClicks
            End Get
            Set
                _PlanClicks = Value
            End Set
        End Property
        Public Property PlanDemo1() As Nullable(Of Decimal)
            Get
                PlanDemo1 = _PlanDemo1
            End Get
            Set
                _PlanDemo1 = Value
            End Set
        End Property
        Public Property PlanDemo2() As Nullable(Of Decimal)
            Get
                PlanDemo2 = _PlanDemo2
            End Get
            Set
                _PlanDemo2 = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n0")>
        Public Property PlanQuantity() As Nullable(Of Decimal)
            Get
                PlanQuantity = _PlanQuantity
            End Get
            Set
                _PlanQuantity = Value
            End Set
        End Property
        Public Property PlanNetAmount() As Nullable(Of Decimal)
            Get
                PlanNetAmount = _PlanNetAmount
            End Get
            Set
                _PlanNetAmount = Value
            End Set
        End Property
        Public Property PlanCommission() As Nullable(Of Decimal)
            Get
                PlanCommission = _PlanCommission
            End Get
            Set
                _PlanCommission = Value
            End Set
        End Property
        Public Property PlanAgencyFee() As Nullable(Of Decimal)
            Get
                PlanAgencyFee = _PlanAgencyFee
            End Get
            Set
                _PlanAgencyFee = Value
            End Set
        End Property
        Public Property PlanBillAmount() As Nullable(Of Decimal)
            Get
                PlanBillAmount = _PlanBillAmount
            End Get
            Set
                _PlanBillAmount = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PlanRate() As Nullable(Of Decimal)
            Get
                PlanRate = _PlanRate
            End Get
            Set
                _PlanRate = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PlanCPI() As Nullable(Of Decimal)
            Get
                PlanCPI = _PlanCPI
            End Get
            Set
                _PlanCPI = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PlanCTR() As Nullable(Of Decimal)
            Get
                PlanCTR = _PlanCTR
            End Get
            Set
                _PlanCTR = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PlanConversionRatePercent() As Nullable(Of Decimal)
            Get
                PlanConversionRatePercent = _PlanConversionRatePercent
            End Get
            Set
                _PlanConversionRatePercent = Value
            End Set
        End Property
        Public Property OrderQuantity() As Nullable(Of Integer)
            Get
                OrderQuantity = _OrderQuantity
            End Get
            Set
                _OrderQuantity = Value
            End Set
        End Property
        Public Property OrderNetAmount() As Nullable(Of Decimal)
            Get
                OrderNetAmount = _OrderNetAmount
            End Get
            Set
                _OrderNetAmount = Value
            End Set
        End Property
        Public Property OrderCommission() As Nullable(Of Decimal)
            Get
                OrderCommission = _OrderCommission
            End Get
            Set
                _OrderCommission = Value
            End Set
        End Property
        Public Property OrderAgencyFee() As Nullable(Of Decimal)
            Get
                OrderAgencyFee = _OrderAgencyFee
            End Get
            Set
                _OrderAgencyFee = Value
            End Set
        End Property
        Public Property OrderBillAmount() As Nullable(Of Decimal)
            Get
                OrderBillAmount = _OrderBillAmount
            End Get
            Set
                _OrderBillAmount = Value
            End Set
        End Property
        Public Property BilledQuantity() As Nullable(Of Integer)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set
                _BilledQuantity = Value
            End Set
        End Property
        Public Property BilledCommissionAmount() As Nullable(Of Decimal)
            Get
                BilledCommissionAmount = _BilledCommissionAmount
            End Get
            Set
                _BilledCommissionAmount = Value
            End Set
        End Property
        Public Property BilledAgencyFee() As Nullable(Of Decimal)
            Get
                BilledAgencyFee = _BilledAgencyFee
            End Get
            Set
                _BilledAgencyFee = Value
            End Set
        End Property
        Public Property BilledNetAmount() As Nullable(Of Decimal)
            Get
                BilledNetAmount = _BilledNetAmount
            End Get
            Set
                _BilledNetAmount = Value
            End Set
        End Property
        Public Property BilledBillAmount() As Nullable(Of Decimal)
            Get
                BilledBillAmount = _BilledBillAmount
            End Get
            Set
                _BilledBillAmount = Value
            End Set
        End Property
        Public Property APQuantity() As Nullable(Of Integer)
            Get
                APQuantity = _APQuantity
            End Get
            Set
                _APQuantity = Value
            End Set
        End Property
        Public Property APNetAmount() As Nullable(Of Decimal)
            Get
                APNetAmount = _APNetAmount
            End Get
            Set
                _APNetAmount = Value
            End Set
        End Property
        Public Property PlanBillToOrderedBillVariance() As Nullable(Of Decimal)
            Get
                PlanBillToOrderedBillVariance = _PlanBillToOrderedBillVariance
            End Get
            Set
                _PlanBillToOrderedBillVariance = Value
            End Set
        End Property
        Public Property PlanBillToBilledVariance() As Nullable(Of Decimal)
            Get
                PlanBillToBilledVariance = _PlanBillToBilledVariance
            End Get
            Set
                _PlanBillToBilledVariance = Value
            End Set
        End Property
        Public Property OrderedToBilledVariance() As Nullable(Of Decimal)
            Get
                OrderedToBilledVariance = _OrderedToBilledVariance
            End Get
            Set
                _OrderedToBilledVariance = Value
            End Set
        End Property
        Public Property OrderedToAPVariance() As Nullable(Of Decimal)
            Get
                OrderedToAPVariance = _OrderedToAPVariance
            End Get
            Set
                _OrderedToAPVariance = Value
            End Set
        End Property
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set
                _OrderNumber = Value
            End Set
        End Property
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set
                _LineNumber = Value
            End Set
        End Property
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set
                _OrderDescription = Value
            End Set
        End Property
        Public Property OrderComment() As String
            Get
                OrderComment = _OrderComment
            End Get
            Set
                _OrderComment = Value
            End Set
        End Property
        Public Property OrderDate() As Nullable(Of Date)
            Get
                OrderDate = _OrderDate
            End Get
            Set
                _OrderDate = Value
            End Set
        End Property
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set
                _ClientPO = Value
            End Set
        End Property
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set
                _LinkID = Value
            End Set
        End Property
        Public Property LineLinkID() As Nullable(Of Integer)
            Get
                LineLinkID = _LineLinkID
            End Get
            Set
                _LineLinkID = Value
            End Set
        End Property
        Public Property OrderDateType() As String
            Get
                OrderDateType = _OrderDateType
            End Get
            Set
                _OrderDateType = Value
            End Set
        End Property
        Public Property InsertionDate() As Nullable(Of Date)
            Get
                InsertionDate = _InsertionDate
            End Get
            Set
                _InsertionDate = Value
            End Set
        End Property
        Public Property OrderEndDate() As Nullable(Of Date)
            Get
                OrderEndDate = _OrderEndDate
            End Get
            Set
                _OrderEndDate = Value
            End Set
        End Property
        Public Property OrderMonth() As String
            Get
                OrderMonth = _OrderMonth
            End Get
            Set
                _OrderMonth = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property Orderyear() As Nullable(Of Short)
            Get
                Orderyear = _Orderyear
            End Get
            Set
                _Orderyear = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set
                _JobNumber = Value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set
                _JobDescription = Value
            End Set
        End Property
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set
                _JobComponentNumber = Value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set
                _JobComponentDescription = Value
            End Set
        End Property
        Public Property CostType() As String
            Get
                CostType = _CostType
            End Get
            Set
                _CostType = Value
            End Set
        End Property
        Public Property ProjectedImpressions() As Nullable(Of Integer)
            Get
                ProjectedImpressions = _ProjectedImpressions
            End Get
            Set
                _ProjectedImpressions = Value
            End Set
        End Property
        Public Property GuaranteedImpressions() As Nullable(Of Integer)
            Get
                GuaranteedImpressions = _GuaranteedImpressions
            End Get
            Set
                _GuaranteedImpressions = Value
            End Set
        End Property
        Public Property ActualImpressions() As Nullable(Of Integer)
            Get
                ActualImpressions = _ActualImpressions
            End Get
            Set
                _ActualImpressions = Value
            End Set
        End Property
        Public Property LineDescription() As String
            Get
                LineDescription = _LineDescription
            End Get
            Set
                _LineDescription = Value
            End Set
        End Property
        Public Property MiscellaneousInfo() As String
            Get
                MiscellaneousInfo = _MiscellaneousInfo
            End Get
            Set
                _MiscellaneousInfo = Value
            End Set
        End Property
        Public Property OrderCopy() As String
            Get
                OrderCopy = _OrderCopy
            End Get
            Set
                _OrderCopy = Value
            End Set
        End Property
        Public Property MaterialNotes() As String
            Get
                MaterialNotes = _MaterialNotes
            End Get
            Set
                _MaterialNotes = Value
            End Set
        End Property
        Public Property DaypartCode() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.MediaPlanID.ToString

        End Function

#End Region

    End Class

End Namespace
