Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class MediaPlanComparisonDetailByVendor

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID

            OrderNumber
            OrderLineNumber
            Headline  '(LineDescription)

            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            VendorCode
            VendorName
            CampaignCode
            CampaignName
            MediaType
            SalesClassCode
            SalesClassDescription
            Month
            MonthName
            Year
            EstimateID
            EstimateName
            EstimateBudget
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
            OrderQuantity
            OrderNetAmount
            OrderCommission
            OrderAgencyFee
            OrderBillAmount
            OrderResaleTax
            OrderVendorTax
            BilledQuantity
            BilledCommissionAmount
            BilledAgencyFee
            BilledNetAmount
            BilledBillAmount
            BilledResaleTax
            BilledVendorTax
            APQuantity
            APNetAmount
            PlanBillToOrderedBillVariance
            PlanBillToBilledVariance
            OrderedToBilledVariance
            OrderedToAPVariance
            MasterPlanID
            MasterPlanName
            PlanEstBudgetToPlanBillVariance
            PlanEstBudgetToOrderBillVariance

            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            AdSize
            EditionIssue
            Section
            Material
            Remarks
            URL
            InternetTypeCode
            InternetTypeDescription
            OutOfHomeTypeCode
            OutOfHomeTypeDescription
            Placement
            PackageName
            Location
            LineMarketCode
            LineMarketDescription
            TargetAudience
            AdSizeDescription
            AdNumber
            AdNumberDescription

        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing

        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Short) = Nothing
        Private _Headline As String = Nothing

        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _Month As Integer = Nothing
        Private _MonthName As String = Nothing
        Private _Year As Integer = Nothing
        Private _EstimateID As Nullable(Of Integer) = Nothing
        Private _EstimateName As String = Nothing
        Private _EstimateBudget As Nullable(Of Decimal) = Nothing
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
        Private _OrderQuantity As Nullable(Of Decimal) = Nothing
        Private _OrderNetAmount As Nullable(Of Decimal) = Nothing
        Private _OrderCommission As Nullable(Of Decimal) = Nothing
        Private _OrderAgencyFee As Nullable(Of Decimal) = Nothing
        Private _OrderBillAmount As Nullable(Of Decimal) = Nothing
        Private _OrderResaleTax As Nullable(Of Decimal) = Nothing
        Private _OrderVendorTax As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _BilledAgencyFee As Nullable(Of Decimal) = Nothing
        Private _BilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledBillAmount As Nullable(Of Decimal) = Nothing
        Private _BilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _BilledVendorTax As Nullable(Of Decimal) = Nothing
        Private _APQuantity As Nullable(Of Decimal) = Nothing
        Private _APNetAmount As Nullable(Of Decimal) = Nothing
        Private _PlanBillToOrderedBillVariance As Nullable(Of Decimal) = Nothing
        Private _PlanBillToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToAPVariance As Nullable(Of Decimal) = Nothing
        Private _PlanEstBudgetToPlanBillVariance As Nullable(Of Decimal) = Nothing
        Private _PlanEstBudgetToOrderBillVariance As Nullable(Of Decimal) = Nothing

        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _AdSize As String = Nothing
        Private _EditionIssue As String = Nothing
        Private _Section As String = Nothing
        Private _Material As String = Nothing
        Private _Remarks As String = Nothing
        Private _URL As String = Nothing
        Private _InternetTypeCode As String = Nothing
        Private _InternetTypeDescription As String = Nothing
        Private _OutOfHomeTypeCode As String = Nothing
        Private _OutOfHomeTypeDescription As String = Nothing
        Private _Placement As String = Nothing
        Private _PackageName As String = Nothing
        Private _Location As String = Nothing
        Private _LineMarketCode As String = Nothing
        Private _LineMarketDescription As String = Nothing
        Private _TargetAudience As String = Nothing
        Private _AdSizeDescription As String = Nothing
        Private _AdNumber As String = Nothing
        Private _AdNumberDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property OrderLineNumber() As Nullable(Of Short)
            Get
                OrderLineNumber = _OrderLineNumber
            End Get
            Set(value As Nullable(Of Short))
                _OrderLineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Headline() As String
            Get
                Headline = _Headline
            End Get
            Set(value As String)
                _Headline = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaType() As String
            Get
                MediaType = _MediaType
            End Get
            Set(value As String)
                _MediaType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Month() As Integer
            Get
                Month = _Month
            End Get
            Set(value As Integer)
                _Month = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MonthName() As String
            Get
                MonthName = _MonthName
            End Get
            Set(value As String)
                _MonthName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Year() As Integer
            Get
                Year = _Year
            End Get
            Set(value As Integer)
                _Year = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateID() As Nullable(Of Integer)
            Get
                EstimateID = _EstimateID
            End Get
            Set(value As Nullable(Of Integer))
                _EstimateID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateName() As String
            Get
                EstimateName = _EstimateName
            End Get
            Set(value As String)
                _EstimateName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateBudget() As Nullable(Of Decimal)
            Get
                EstimateBudget = _EstimateBudget
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateBudget = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanUnits() As Nullable(Of Decimal)
            Get
                PlanUnits = _PlanUnits
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanUnits = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanImpressions() As Nullable(Of Decimal)
            Get
                PlanImpressions = _PlanImpressions
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanImpressions = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanClicks() As Nullable(Of Decimal)
            Get
                PlanClicks = _PlanClicks
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanClicks = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanDemo1() As Nullable(Of Decimal)
            Get
                PlanDemo1 = _PlanDemo1
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanDemo1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanDemo2() As Nullable(Of Decimal)
            Get
                PlanDemo2 = _PlanDemo2
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanDemo2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanQuantity() As Nullable(Of Decimal)
            Get
                PlanQuantity = _PlanQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanNetAmount() As Nullable(Of Decimal)
            Get
                PlanNetAmount = _PlanNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanCommission() As Nullable(Of Decimal)
            Get
                PlanCommission = _PlanCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanAgencyFee() As Nullable(Of Decimal)
            Get
                PlanAgencyFee = _PlanAgencyFee
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanAgencyFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanBillAmount() As Nullable(Of Decimal)
            Get
                PlanBillAmount = _PlanBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanBillAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderQuantity() As Nullable(Of Decimal)
            Get
                OrderQuantity = _OrderQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderNetAmount() As Nullable(Of Decimal)
            Get
                OrderNetAmount = _OrderNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderCommission() As Nullable(Of Decimal)
            Get
                OrderCommission = _OrderCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderCommission = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderAgencyFee() As Nullable(Of Decimal)
            Get
                OrderAgencyFee = _OrderAgencyFee
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderAgencyFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderBillAmount() As Nullable(Of Decimal)
            Get
                OrderBillAmount = _OrderBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderBillAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderResaleTax() As Nullable(Of Decimal)
            Get
                OrderResaleTax = _OrderResaleTax
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OrderVendorTax() As Nullable(Of Decimal)
            Get
                OrderVendorTax = _OrderVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderVendorTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledCommissionAmount() As Nullable(Of Decimal)
            Get
                BilledCommissionAmount = _BilledCommissionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommissionAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledAgencyFee() As Nullable(Of Decimal)
            Get
                BilledAgencyFee = _BilledAgencyFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAgencyFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledNetAmount() As Nullable(Of Decimal)
            Get
                BilledNetAmount = _BilledNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledBillAmount() As Nullable(Of Decimal)
            Get
                BilledBillAmount = _BilledBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledBillAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledResaleTax() As Nullable(Of Decimal)
            Get
                BilledResaleTax = _BilledResaleTax
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledVendorTax() As Nullable(Of Decimal)
            Get
                BilledVendorTax = _BilledVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledVendorTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APQuantity() As Nullable(Of Decimal)
            Get
                APQuantity = _APQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _APQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APNetAmount() As Nullable(Of Decimal)
            Get
                APNetAmount = _APNetAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _APNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Plan Bill to Ordered Bill Variance")>
        Public Property PlanBillToOrderedBillVariance() As Nullable(Of Decimal)
            Get
                PlanBillToOrderedBillVariance = _PlanBillToOrderedBillVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanBillToOrderedBillVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Plan Bill to Billed Variance")>
        Public Property PlanBillToBilledVariance() As Nullable(Of Decimal)
            Get
                PlanBillToBilledVariance = _PlanBillToBilledVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanBillToBilledVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Ordered to Billed Variance")>
        Public Property OrderedToBilledVariance() As Nullable(Of Decimal)
            Get
                OrderedToBilledVariance = _OrderedToBilledVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderedToBilledVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Ordered to AP Variance")>
        Public Property OrderedToAPVariance() As Nullable(Of Decimal)
            Get
                OrderedToAPVariance = _OrderedToAPVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _OrderedToAPVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property MasterPlanID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MasterPlanName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Plan Est Budget to Plan Bill Variance")>
        Public Property PlanEstBudgetToPlanBillVariance() As Nullable(Of Decimal)
            Get
                PlanEstBudgetToPlanBillVariance = _PlanEstBudgetToPlanBillVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanEstBudgetToPlanBillVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Plan Est Budget to Order Bill Variance")>
        Public Property PlanEstBudgetToOrderBillVariance() As Nullable(Of Decimal)
            Get
                PlanEstBudgetToOrderBillVariance = _PlanEstBudgetToOrderBillVariance
            End Get
            Set(value As Nullable(Of Decimal))
                _PlanEstBudgetToOrderBillVariance = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdSize() As String
            Get
                AdSize = _AdSize
            End Get
            Set(value As String)
                _AdSize = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EditionIssue() As String
            Get
                EditionIssue = _EditionIssue
            End Get
            Set(value As String)
                _EditionIssue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Section() As String
            Get
                Section = _Section
            End Get
            Set(value As String)
                _Section = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Material() As String
            Get
                Material = _Material
            End Get
            Set(value As String)
                _Material = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Remarks() As String
            Get
                Remarks = _Remarks
            End Get
            Set(value As String)
                _Remarks = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property URL() As String
            Get
                URL = _URL
            End Get
            Set(value As String)
                _URL = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetTypeCode() As String
            Get
                InternetTypeCode = _InternetTypeCode
            End Get
            Set(value As String)
                _InternetTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InternetTypeDescription() As String
            Get
                InternetTypeDescription = _InternetTypeDescription
            End Get
            Set(value As String)
                _InternetTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeTypeCode() As String
            Get
                OutOfHomeTypeCode = _OutOfHomeTypeCode
            End Get
            Set(value As String)
                _OutOfHomeTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutOfHomeTypeDescription() As String
            Get
                OutOfHomeTypeDescription = _OutOfHomeTypeDescription
            End Get
            Set(value As String)
                _OutOfHomeTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Placement() As String
            Get
                Placement = _Placement
            End Get
            Set(value As String)
                _Placement = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PackageName() As String
            Get
                PackageName = _PackageName
            End Get
            Set(value As String)
                _PackageName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Location() As String
            Get
                Location = _Location
            End Get
            Set(value As String)
                _Location = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineMarketCode() As String
            Get
                LineMarketCode = _LineMarketCode
            End Get
            Set(value As String)
                _LineMarketCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LineMarketDescription() As String
            Get
                LineMarketDescription = _LineMarketDescription
            End Get
            Set(value As String)
                _LineMarketDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TargetAudience() As String
            Get
                TargetAudience = _TargetAudience
            End Get
            Set(value As String)
                _TargetAudience = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdSizeDescription() As String
            Get
                AdSizeDescription = _AdSizeDescription
            End Get
            Set(value As String)
                _AdSizeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumber() As String
            Get
                AdNumber = _AdNumber
            End Get
            Set(value As String)
                _AdNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdNumberDescription() As String
            Get
                AdNumberDescription = _AdNumberDescription
            End Get
            Set(value As String)
                _AdNumberDescription = value
            End Set
        End Property


#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
