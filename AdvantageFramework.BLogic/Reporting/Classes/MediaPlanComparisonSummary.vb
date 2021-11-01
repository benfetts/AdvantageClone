Namespace Reporting.Classes

    <Serializable()>
    Public Class MediaPlanComparisonSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OfficeCode
            OfficeName
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductDescription
            CampaignCode
            CampaignName
            MediaType
            SalesClassCode
            SalesClassDescription
            Month
            MonthName
            Year
            MasterPlanID
            MasterPlanName
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
            PlanEstBudgetToPlanBillVariance
            PlanEstBudgetToOrderBillVariance
        End Enum

#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _Month As Integer = Nothing
        Private _MonthName As String = Nothing
        Private _Year As Integer = Nothing
        Private _MasterPlanID As Nullable(Of Integer) = Nothing
        Private _MasterPlanName As String = Nothing
        Private _EstimateID As Integer = Nothing
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
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledCommissionAmount As Nullable(Of Decimal) = Nothing
        Private _BilledAgencyFee As Nullable(Of Decimal) = Nothing
        Private _BilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledBillAmount As Nullable(Of Decimal) = Nothing
        Private _APQuantity As Nullable(Of Decimal) = Nothing
        Private _APNetAmount As Nullable(Of Decimal) = Nothing
        Private _PlanBillToOrderedBillVariance As Nullable(Of Decimal) = Nothing
        Private _PlanBillToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToBilledVariance As Nullable(Of Decimal) = Nothing
        Private _OrderedToAPVariance As Nullable(Of Decimal) = Nothing
        Private _PlanEstBudgetToPlanBillVariance As Nullable(Of Decimal) = Nothing
        Private _PlanEstBudgetToOrderBillVariance As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MasterPlanID As Nullable(Of Integer)
            Get
                MasterPlanID = _MasterPlanID
            End Get
            Set(value As Nullable(Of Integer))
                _MasterPlanID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MasterPlanName As String
            Get
                MasterPlanName = _MasterPlanName
            End Get
            Set(value As String)
                _MasterPlanName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property EstimateID() As Integer
            Get
                EstimateID = _EstimateID
            End Get
            Set(value As Integer)
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OfficeCode.ToString

        End Function

#End Region

    End Class

End Namespace

