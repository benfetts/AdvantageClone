Namespace Reporting.Database.Classes

    <Serializable>
    Public Class ClientPL

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            DefaultAECode
            DefaultAEName
            ProductUDF1
            ProductUDF2
            ProductUDF3
            ProductUDF4
            Industry
            Specialty
            Region
            RegionCode
            Revenue
            NumberOfEmployees
            Source
            Type
            SalesClassCode
            SalesClassDescription
            CampaignID
            CampaignCode
            CampaignName
            PostingPeriod
            PostingPeriodYear
            PostingPeriodMonth
            Year
            BilledHours
            BilledQuantity
            BilledFee
            BilledTime
            BilledCommission
            BilledCostOfSales
            BilledIncomeRec
            ManualSale
            ManualCOS
            GLSales
            GLCostOfSales
            BilledTotal
            TotalGrossIncome
            Hours
            DirectServiceCost
            DirectServiceBillAmount
            DirectExpense
            GLDirectExpense
            TotalDirectCosts
            TotalIncome
            Overhead
            IncomeLessOverhead
            FTE
            CRClientSales
            CRClientCostOfSales
            CRClientDirectExpense
            NonbillableAPSales
            NonbillableAPCostOfSales
            BudgetFee
            BudgetTime
            BudgetCommission
            BudgetCostOfSales
            BudgetDirectServiceCost
            BudgetDirectExpense
            BudgetSummaryBilling
            BudgetSummaryCOS
            BudgetSummaryIncome
            BudgetBillingAmount
            BudgetCOSAmount
            BudgetGrossIncome
            BudgetDirectCost
            BudgetIncome
            BudgetVarianceFee
            BudgetVarianceTime
            BudgetVarianceCommission
            BudgetVarianceCostOfSales
            BudgetVarianceDirectServiceCost
            BudgetVarianceDirectExpense
            BudgetVarianceGrossIncome
            BudgetVarianceIncome
            BudgetVarianceBilling
            BudgetVarianceDirectCost
            ForecastFee
            ForecastTime
            ForecastCommission
            ForecastCostOfSales
            ForecastDirectServiceCost
            ForecastDirectExpense
            ForecastGrossIncome
            ForecastIncome
            BFVarianceFee
            BFVarianceTime
            BFVarianceCommission
            BFVarianceCostOfSales
            BFVarianceDirectServiceCost
            BFVarianceDirectExpense
            BFVarianceGrossIncome
            BFVarianceIncome
            SumofTotalGrossIncomeOffice
            SumofDirectServiceCostOffice
            SumofTotalGrossIncomeOfficeYear
            SumofDirectServiceCostOfficeYear
            StartPeriod
            EndPeriod
            PeriodClientBilledTotal
            PeriodClientTotalGrossIncome
            PeriodClientNetProfit
            PP1Start
            PP1End
            PP1ClientBilledTotal
            PP1ClientTotalGrossIncome
            PP1ClientNetProfit
            PP2Start
            PP2End
            PP2ClientBilledTotal
            PP2ClientTotalGrossIncome
            PP2ClientNetProfit
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _DefaultAECode As String = Nothing
        Private _DefaultAEName As String = Nothing
        Private _ProductUDF1 As String = Nothing
        Private _ProductUDF2 As String = Nothing
        Private _ProductUDF3 As String = Nothing
        Private _ProductUDF4 As String = Nothing
        Private _Industry As String = Nothing
        Private _Specialty As String = Nothing
        Private _Region As String = Nothing
        Private _RegionCode As String = Nothing
        Private _Revenue As Nullable(Of Decimal) = Nothing
        Private _NumberOfEmployees As Nullable(Of Integer) = Nothing
        Private _Source As String = Nothing
        Private _Type As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _CampaignID As Nullable(Of Integer) = Nothing
        Private _CampaignCode As String = Nothing
        Private _CampaignName As String = Nothing
        Private _PostingPeriod As String = Nothing
        Private _PostingPeriodYear As Nullable(Of Integer) = Nothing
        Private _PostingPeriodMonth As Nullable(Of Short) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledFee As Nullable(Of Decimal) = Nothing
        Private _BilledTime As Nullable(Of Decimal) = Nothing
        Private _BilledCommission As Nullable(Of Decimal) = Nothing
        Private _BilledCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BilledIncomeRec As Nullable(Of Decimal) = Nothing
        Private _ManualSale As Nullable(Of Decimal) = Nothing
        Private _ManualCOS As Nullable(Of Decimal) = Nothing
        Private _GLSales As Nullable(Of Decimal) = Nothing
        Private _GLCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BilledTotal As Nullable(Of Decimal) = Nothing
        Private _TotalGrossIncome As Nullable(Of Decimal) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _DirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _DirectServiceBillAmount As Nullable(Of Decimal) = Nothing
        Private _DirectExpense As Nullable(Of Decimal) = Nothing
        Private _GLDirectExpense As Nullable(Of Decimal) = Nothing
        Private _TotalDirectCosts As Nullable(Of Decimal) = Nothing
        Private _TotalIncome As Nullable(Of Decimal) = Nothing
        Private _Overhead As Nullable(Of Decimal) = Nothing
        Private _IncomeLessOverhead As Nullable(Of Decimal) = Nothing
        Private _FTE As Nullable(Of Decimal) = Nothing
        Private _CRClientSales As Nullable(Of Decimal) = Nothing
        Private _CRClientCostOfSales As Nullable(Of Decimal) = Nothing
        Private _CRClientDirectExpense As Nullable(Of Decimal) = Nothing
        Private _NonbillableAPSales As Nullable(Of Decimal) = Nothing
        Private _NonbillableAPCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BudgetFee As Nullable(Of Decimal) = Nothing
        Private _BudgetTime As Nullable(Of Decimal) = Nothing
        Private _BudgetCommission As Nullable(Of Decimal) = Nothing
        Private _BudgetCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryBilling As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryCOS As Nullable(Of Decimal) = Nothing
        Private _BudgetSummaryIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetBillingAmount As Nullable(Of Decimal) = Nothing
        Private _BudgetCOSAmount As Nullable(Of Decimal) = Nothing
        Private _BudgetGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetDirectCost As Nullable(Of Decimal) = Nothing
        Private _BudgetIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceFee As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceTime As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceCommission As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceDirectCost As Nullable(Of Decimal) = Nothing
        Private _ForecastFee As Nullable(Of Decimal) = Nothing
        Private _ForecastTime As Nullable(Of Decimal) = Nothing
        Private _ForecastCommission As Nullable(Of Decimal) = Nothing
        Private _ForecastCostOfSales As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectExpense As Nullable(Of Decimal) = Nothing
        Private _ForecastGrossIncome As Nullable(Of Decimal) = Nothing
        Private _ForecastIncome As Nullable(Of Decimal) = Nothing
        Private _BFVarianceFee As Nullable(Of Decimal) = Nothing
        Private _BFVarianceTime As Nullable(Of Decimal) = Nothing
        Private _BFVarianceCommission As Nullable(Of Decimal) = Nothing
        Private _BFVarianceCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BFVarianceDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _BFVarianceDirectExpense As Nullable(Of Decimal) = Nothing
        Private _BFVarianceGrossIncome As Nullable(Of Decimal) = Nothing
        Private _BFVarianceIncome As Nullable(Of Decimal) = Nothing
        Private _BudgetVarianceBilling As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeOffice As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOffice As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeOfficeYear As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOfficeYear As Nullable(Of Decimal) = Nothing
        Private _StartPeriod As String = Nothing
        Private _EndPeriod As String = Nothing
        Private _PeriodClientBilledTotal As Nullable(Of Decimal) = Nothing
        Private _PeriodClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        Private _PeriodClientNetProfit As Nullable(Of Decimal) = Nothing
        Private _PP1Start As String = Nothing
        Private _PP1End As String = Nothing
        Private _PP1ClientBilledTotal As Nullable(Of Decimal) = Nothing
        Private _PP1ClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        Private _PP1ClientNetProfit As Nullable(Of Decimal) = Nothing
        Private _PP2Start As String = Nothing
        Private _PP2End As String = Nothing
        Private _PP2ClientBilledTotal As Nullable(Of Decimal) = Nothing
        Private _PP2ClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        Private _PP2ClientNetProfit As Nullable(Of Decimal) = Nothing

        Public Sub New()

        End Sub

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of Integer))
                _ID = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        Public Property DefaultAECode() As String
            Get
                DefaultAECode = _DefaultAECode
            End Get
            Set(value As String)
                _DefaultAECode = value
            End Set
        End Property
        Public Property DefaultAEName() As String
            Get
                DefaultAEName = _DefaultAEName
            End Get
            Set(value As String)
                _DefaultAEName = value
            End Set
        End Property
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = value
            End Set
        End Property
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = value
            End Set
        End Property
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = value
            End Set
        End Property
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = value
            End Set
        End Property
        Public Property Industry() As String
            Get
                Industry = _Industry
            End Get
            Set
                _Industry = Value
            End Set
        End Property
        Public Property Specialty() As String
            Get
                Specialty = _Specialty
            End Get
            Set
                _Specialty = Value
            End Set
        End Property
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set
                _Region = Value
            End Set
        End Property
        Public Property RegionCode() As String
            Get
                RegionCode = _RegionCode
            End Get
            Set
                _RegionCode = Value
            End Set
        End Property
        Public Property Revenue() As Nullable(Of Decimal)
            Get
                Revenue = _Revenue
            End Get
            Set
                _Revenue = Value
            End Set
        End Property
        Public Property NumberOfEmployees() As Nullable(Of Integer)
            Get
                NumberOfEmployees = _NumberOfEmployees
            End Get
            Set
                _NumberOfEmployees = Value
            End Set
        End Property
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = Value
            End Set
        End Property
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property CampaignID() As Nullable(Of Integer)
            Get
                CampaignID = _CampaignID
            End Get
            Set(value As Nullable(Of Integer))
                _CampaignID = value
            End Set
        End Property
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        Public Property PostingPeriod() As String
            Get
                PostingPeriod = _PostingPeriod
            End Get
            Set(value As String)
                _PostingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")> '
        Public Property PostingPeriodYear() As Nullable(Of Integer)
            Get
                PostingPeriodYear = _PostingPeriodYear
            End Get
            Set
                _PostingPeriodYear = Value
            End Set
        End Property
        Public Property PostingPeriodMonth() As Nullable(Of Short)
            Get
                PostingPeriodMonth = _PostingPeriodMonth
            End Get
            Set
                _PostingPeriodMonth = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")> ', DisplayFormat:="f0"
        Public Property Year() As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours
            End Get
            Set
                _BilledHours = Value
            End Set
        End Property
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set
                _BilledQuantity = Value
            End Set
        End Property
        Public Property BilledFee() As Nullable(Of Decimal)
            Get
                BilledFee = _BilledFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledFee = value
            End Set
        End Property
        Public Property BilledTime() As Nullable(Of Decimal)
            Get
                BilledTime = _BilledTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTime = value
            End Set
        End Property
        Public Property BilledCommission() As Nullable(Of Decimal)
            Get
                BilledCommission = _BilledCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommission = value
            End Set
        End Property
        Public Property BilledCostOfSales() As Nullable(Of Decimal)
            Get
                BilledCostOfSales = _BilledCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCostOfSales = value
            End Set
        End Property
        Public Property BilledIncomeRec() As Nullable(Of Decimal)
            Get
                BilledIncomeRec = _BilledIncomeRec
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledIncomeRec = value
            End Set
        End Property
        Public Property ManualSale() As Nullable(Of Decimal)
            Get
                ManualSale = _ManualSale
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualSale = value
            End Set
        End Property
        Public Property ManualCOS() As Nullable(Of Decimal)
            Get
                ManualCOS = _ManualCOS
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualCOS = value
            End Set
        End Property
        Public Property GLSales() As Nullable(Of Decimal)
            Get
                GLSales = _GLSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLSales = value
            End Set
        End Property
        Public Property GLCostOfSales() As Nullable(Of Decimal)
            Get
                GLCostOfSales = _GLCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLCostOfSales = value
            End Set
        End Property
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = value
            End Set
        End Property
        Public Property TotalGrossIncome() As Nullable(Of Decimal)
            Get
                TotalGrossIncome = _TotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalGrossIncome = value
            End Set
        End Property
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        Public Property DirectServiceCost() As Nullable(Of Decimal)
            Get
                DirectServiceCost = _DirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectServiceCost = value
            End Set
        End Property
        Public Property DirectServiceBillAmount() As Nullable(Of Decimal)
            Get
                DirectServiceBillAmount = _DirectServiceBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectServiceBillAmount = value
            End Set
        End Property
        Public Property DirectExpense() As Nullable(Of Decimal)
            Get
                DirectExpense = _DirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectExpense = value
            End Set
        End Property
        Public Property GLDirectExpense() As Nullable(Of Decimal)
            Get
                GLDirectExpense = _GLDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _GLDirectExpense = value
            End Set
        End Property
        Public Property TotalDirectCosts() As Nullable(Of Decimal)
            Get
                TotalDirectCosts = _TotalDirectCosts
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalDirectCosts = value
            End Set
        End Property
        Public Property TotalIncome() As Nullable(Of Decimal)
            Get
                TotalIncome = _TotalIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalIncome = value
            End Set
        End Property
        Public Property Overhead() As Nullable(Of Decimal)
            Get
                Overhead = _Overhead
            End Get
            Set(value As Nullable(Of Decimal))
                _Overhead = value
            End Set
        End Property
        Public Property IncomeLessOverhead() As Nullable(Of Decimal)
            Get
                IncomeLessOverhead = _IncomeLessOverhead
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeLessOverhead = value
            End Set
        End Property
        Public Property FTE() As Nullable(Of Decimal)
            Get
                FTE = _FTE
            End Get
            Set(value As Nullable(Of Decimal))
                _FTE = value
            End Set
        End Property
        Public Property CRClientSales() As Nullable(Of Decimal)
            Get
                CRClientSales = _CRClientSales
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientSales = value
            End Set
        End Property
        Public Property CRClientCostOfSales() As Nullable(Of Decimal)
            Get
                CRClientCostOfSales = _CRClientCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientCostOfSales = value
            End Set
        End Property
        Public Property CRClientDirectExpense() As Nullable(Of Decimal)
            Get
                CRClientDirectExpense = _CRClientDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientDirectExpense = value
            End Set
        End Property
        Public Property NonbillableAPSales() As Nullable(Of Decimal)
            Get
                NonbillableAPSales = _NonbillableAPSales
            End Get
            Set(value As Nullable(Of Decimal))
                _NonbillableAPSales = value
            End Set
        End Property
        Public Property NonbillableAPCostOfSales() As Nullable(Of Decimal)
            Get
                NonbillableAPCostOfSales = _NonbillableAPCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _NonbillableAPCostOfSales = value
            End Set
        End Property
        Public Property BudgetFee() As Nullable(Of Decimal)
            Get
                BudgetFee = _BudgetFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetFee = value
            End Set
        End Property
        Public Property BudgetTime() As Nullable(Of Decimal)
            Get
                BudgetTime = _BudgetTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetTime = value
            End Set
        End Property
        Public Property BudgetCommission() As Nullable(Of Decimal)
            Get
                BudgetCommission = _BudgetCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetCommission = value
            End Set
        End Property
        Public Property BudgetCostOfSales() As Nullable(Of Decimal)
            Get
                BudgetCostOfSales = _BudgetCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetCostOfSales = value
            End Set
        End Property
        Public Property BudgetDirectServiceCost() As Nullable(Of Decimal)
            Get
                BudgetDirectServiceCost = _BudgetDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetDirectServiceCost = value
            End Set
        End Property
        Public Property BudgetDirectExpense() As Nullable(Of Decimal)
            Get
                BudgetDirectExpense = _BudgetDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetDirectExpense = value
            End Set
        End Property
        Public Property BudgetSummaryBilling() As Nullable(Of Decimal)
            Get
                BudgetSummaryBilling = _BudgetSummaryBilling
            End Get
            Set
                _BudgetSummaryBilling = Value
            End Set
        End Property
        Public Property BudgetSummaryCOS() As Nullable(Of Decimal)
            Get
                BudgetSummaryCOS = _BudgetSummaryCOS
            End Get
            Set
                _BudgetSummaryCOS = Value
            End Set
        End Property
        Public Property BudgetSummaryIncome() As Nullable(Of Decimal)
            Get
                BudgetSummaryIncome = _BudgetSummaryIncome
            End Get
            Set
                _BudgetSummaryIncome = Value
            End Set
        End Property
        Public Property BudgetBillingAmount() As Nullable(Of Decimal)
            Get
                BudgetBillingAmount = _BudgetBillingAmount
            End Get
            Set
                _BudgetBillingAmount = Value
            End Set
        End Property
        Public Property BudgetCOSAmount() As Nullable(Of Decimal)
            Get
                BudgetCOSAmount = _BudgetCOSAmount
            End Get
            Set
                _BudgetCOSAmount = Value
            End Set
        End Property
        Public Property BudgetGrossIncome() As Nullable(Of Decimal)
            Get
                BudgetGrossIncome = _BudgetGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetGrossIncome = value
            End Set
        End Property
        Public Property BudgetDirectCost() As Nullable(Of Decimal)
            Get
                BudgetDirectCost = _BudgetDirectCost
            End Get
            Set
                _BudgetDirectCost = Value
            End Set
        End Property
        Public Property BudgetIncome() As Nullable(Of Decimal)
            Get
                BudgetIncome = _BudgetIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetIncome = value
            End Set
        End Property
        Public Property BudgetVarianceFee() As Nullable(Of Decimal)
            Get
                BudgetVarianceFee = _BudgetVarianceFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceFee = value
            End Set
        End Property
        Public Property BudgetVarianceTime() As Nullable(Of Decimal)
            Get
                BudgetVarianceTime = _BudgetVarianceTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceTime = value
            End Set
        End Property
        Public Property BudgetVarianceCommission() As Nullable(Of Decimal)
            Get
                BudgetVarianceCommission = _BudgetVarianceCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceCommission = value
            End Set
        End Property
        Public Property BudgetVarianceCostOfSales() As Nullable(Of Decimal)
            Get
                BudgetVarianceCostOfSales = _BudgetVarianceCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceCostOfSales = value
            End Set
        End Property
        Public Property BudgetVarianceDirectServiceCost() As Nullable(Of Decimal)
            Get
                BudgetVarianceDirectServiceCost = _BudgetVarianceDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceDirectServiceCost = value
            End Set
        End Property
        Public Property BudgetVarianceDirectExpense() As Nullable(Of Decimal)
            Get
                BudgetVarianceDirectExpense = _BudgetVarianceDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceDirectExpense = value
            End Set
        End Property
        Public Property BudgetVarianceGrossIncome() As Nullable(Of Decimal)
            Get
                BudgetVarianceGrossIncome = _BudgetVarianceGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceGrossIncome = value
            End Set
        End Property
        Public Property BudgetVarianceIncome() As Nullable(Of Decimal)
            Get
                BudgetVarianceIncome = _BudgetVarianceIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BudgetVarianceIncome = value
            End Set
        End Property
        Public Property BudgetVarianceBilling() As Nullable(Of Decimal)
            Get
                BudgetVarianceBilling = _BudgetVarianceBilling
            End Get
            Set
                _BudgetVarianceBilling = Value
            End Set
        End Property
        Public Property BudgetVarianceDirectCost() As Nullable(Of Decimal)
            Get
                BudgetVarianceDirectCost = _BudgetVarianceDirectCost
            End Get
            Set
                _BudgetVarianceDirectCost = Value
            End Set
        End Property
        Public Property ForecastFee() As Nullable(Of Decimal)
            Get
                ForecastFee = _ForecastFee
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastFee = value
            End Set
        End Property
        Public Property ForecastTime() As Nullable(Of Decimal)
            Get
                ForecastTime = _ForecastTime
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastTime = value
            End Set
        End Property
        Public Property ForecastCommission() As Nullable(Of Decimal)
            Get
                ForecastCommission = _ForecastCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCommission = value
            End Set
        End Property
        Public Property ForecastCostOfSales() As Nullable(Of Decimal)
            Get
                ForecastCostOfSales = _ForecastCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCostOfSales = value
            End Set
        End Property
        Public Property ForecastDirectServiceCost() As Nullable(Of Decimal)
            Get
                ForecastDirectServiceCost = _ForecastDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectServiceCost = value
            End Set
        End Property
        Public Property ForecastDirectExpense() As Nullable(Of Decimal)
            Get
                ForecastDirectExpense = _ForecastDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectExpense = value
            End Set
        End Property
        Public Property ForecastGrossIncome() As Nullable(Of Decimal)
            Get
                ForecastGrossIncome = _ForecastGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastGrossIncome = value
            End Set
        End Property
        Public Property ForecastIncome() As Nullable(Of Decimal)
            Get
                ForecastIncome = _ForecastIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastIncome = value
            End Set
        End Property
        Public Property BFVarianceFee() As Nullable(Of Decimal)
            Get
                BFVarianceFee = _BFVarianceFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceFee = value
            End Set
        End Property
        Public Property BFVarianceTime() As Nullable(Of Decimal)
            Get
                BFVarianceTime = _BFVarianceTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceTime = value
            End Set
        End Property
        Public Property BFVarianceCommission() As Nullable(Of Decimal)
            Get
                BFVarianceCommission = _BFVarianceCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceCommission = value
            End Set
        End Property
        Public Property BFVarianceCostOfSales() As Nullable(Of Decimal)
            Get
                BFVarianceCostOfSales = _BFVarianceCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceCostOfSales = value
            End Set
        End Property
        Public Property BFVarianceDirectServiceCost() As Nullable(Of Decimal)
            Get
                BFVarianceDirectServiceCost = _BFVarianceDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceDirectServiceCost = value
            End Set
        End Property
        Public Property BFVarianceDirectExpense() As Nullable(Of Decimal)
            Get
                BFVarianceDirectExpense = _BFVarianceDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceDirectExpense = value
            End Set
        End Property
        Public Property BFVarianceGrossIncome() As Nullable(Of Decimal)
            Get
                BFVarianceGrossIncome = _BFVarianceGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceGrossIncome = value
            End Set
        End Property
        Public Property BFVarianceIncome() As Nullable(Of Decimal)
            Get
                BFVarianceIncome = _BFVarianceIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _BFVarianceIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeOffice() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeOffice = _SumofTotalGrossIncomeOffice
            End Get
            Set
                _SumofTotalGrossIncomeOffice = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOffice() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOffice = _SumofDirectServiceCostOffice
            End Get
            Set
                _SumofDirectServiceCostOffice = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeOfficeYear() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeOfficeYear = _SumofTotalGrossIncomeOfficeYear
            End Get
            Set
                _SumofTotalGrossIncomeOfficeYear = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOfficeYear() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOfficeYear = _SumofDirectServiceCostOfficeYear
            End Get
            Set
                _SumofDirectServiceCostOfficeYear = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartPeriod() As String
            Get
                StartPeriod = _StartPeriod
            End Get
            Set(value As String)
                _StartPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndPeriod() As String
            Get
                EndPeriod = _EndPeriod
            End Get
            Set(value As String)
                _EndPeriod = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PeriodClientBilledTotal() As Nullable(Of Decimal)
            Get
                PeriodClientBilledTotal = _PeriodClientBilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _PeriodClientBilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PeriodClientTotalGrossIncome() As Nullable(Of Decimal)
            Get
                PeriodClientTotalGrossIncome = _PeriodClientTotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _PeriodClientTotalGrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PeriodClientNetProfit() As Nullable(Of Decimal)
            Get
                PeriodClientNetProfit = _PeriodClientNetProfit
            End Get
            Set(value As Nullable(Of Decimal))
                _PeriodClientNetProfit = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP1Start() As String
            Get
                PP1Start = _PP1Start
            End Get
            Set(value As String)
                _PP1Start = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP1End() As String
            Get
                PP1End = _PP1End
            End Get
            Set(value As String)
                _PP1End = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP1ClientBilledTotal() As Nullable(Of Decimal)
            Get
                PP1ClientBilledTotal = _PP1ClientBilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _PP1ClientBilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP1ClientTotalGrossIncome() As Nullable(Of Decimal)
            Get
                PP1ClientTotalGrossIncome = _PP1ClientTotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _PP1ClientTotalGrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP1ClientNetProfit() As Nullable(Of Decimal)
            Get
                PP1ClientNetProfit = _PP1ClientNetProfit
            End Get
            Set(value As Nullable(Of Decimal))
                _PP1ClientNetProfit = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP2Start() As String
            Get
                PP2Start = _PP2Start
            End Get
            Set(value As String)
                _PP2Start = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP2End() As String
            Get
                PP2End = _PP2End
            End Get
            Set(value As String)
                _PP2End = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP2ClientBilledTotal() As Nullable(Of Decimal)
            Get
                PP2ClientBilledTotal = _PP2ClientBilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _PP2ClientBilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP2ClientTotalGrossIncome() As Nullable(Of Decimal)
            Get
                PP2ClientTotalGrossIncome = _PP2ClientTotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _PP2ClientTotalGrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PP2ClientNetProfit() As Nullable(Of Decimal)
            Get
                PP2ClientNetProfit = _PP2ClientNetProfit
            End Get
            Set(value As Nullable(Of Decimal))
                _PP2ClientNetProfit = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
