Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class ClientPLDetail

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
            JobNumber
            JobDescription
            JobComponentNumber
            ComponentDescription
            JobStatus
            JobTypeCode
            JobTypeDescription
            SalesClassFormatCode
            ComplexityCode
            PromotionCode
            ClientReference
            ClientPO
            JobAECode
            JobAEName
            LabelFromUDFTable1
            LabelFromUDFTable2
            LabelFromUDFTable3
            LabelFromUDFTable4
            LabelFromUDFTable5
            CompLabelFromUDFTable1
            CompLabelFromUDFTable2
            CompLabelFromUDFTable3
            CompLabelFromUDFTable4
            CompLabelFromUDFTable5
            FunctionCode
            FunctionConsolidationCode
            FunctionConsolidation
            FunctionDescription
            FunctionHeading
            FunctionType
            OrderNumber
            OrderDescription
            LineNumber
            MediaMonth
            MediaYear
            StartDate
            EndDate
            MarketCode
            MarketDescription
            SalesGLAccountCode
            SalesGLAccountDescription
            CostOfSalesGLAccountCode
            CostOfSalesGLAccountDescription
            DirectExpenseGLAccountCode
            DirectExpenseGLAccountDescription
            BilledHours
            BilledQuantity
            BilledFee
            BilledTime
            BilledCommission
            BilledCostOfSales
            BilledIncomeRec
            EstimatedHours
            EstimateFee
            EstimateTime
            EstimateMarkupAmount
            EstimatedCostAmount
            EstimatedTotalAmount
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
            ForecastFee
            ForecastTime
            ForecastCommission
            ForecastCostOfSales
            ForecastDirectServiceCost
            ForecastDirectExpense
            ForecastGrossIncome
            ForecastIncome
            SumofTotalBilledOffice
            SumofTotalBilledClient
            SumofTotalCostOfBillingOffice
            SumofTotalCostOfBillingClient
            SumofDirectExpensesOffice
            SumofDirectExpensesClient
            SumofDirectServiceCostOffice
            SumofDirectServiceCostOfficeCurrent
            SumofDirectServiceCostClient
            SumofDirectServiceCostClientCurrent
            SumofTotalGrossIncomeOffice
            SumofTotalGrossIncomeClient
            SumofTotalBilledSalesClass
            SumofTotalCostOfBillingSalesClass
            SumofDirectExpensesSalesClass
            SumofDirectServiceCostSalesClass
            StartPeriod
            EndPeriod
            PeriodClientBilledTotal
            PeriodClientTotalGrossIncome
            PeriodClientNetProfit
            'StartPeriod1
            'EndPeriod1
            'Period1ClientBilledTotal
            'Period1ClientTotalGrossIncome
            'Period1ClientNetProfit
            'StartPeriod2
            'EndPeriod2
            'Period2ClientBilledTotal
            'Period2ClientTotalGrossIncome
            'Period2ClientNetProfit
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
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobStatus As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _JobTypeDescription As String = Nothing
        Private _SalesClassFormatCode As String = Nothing
        Private _ComplexityCode As String = Nothing
        Private _PromotionCode As String = Nothing
        Private _ClientReference As String = Nothing
        Private _ClientPO As String = Nothing
        Private _JobAECode As String = Nothing
        Private _JobAEName As String = Nothing
        Private _LabelFromUDFTable1 As String = Nothing
        Private _LabelFromUDFTable2 As String = Nothing
        Private _LabelFromUDFTable3 As String = Nothing
        Private _LabelFromUDFTable4 As String = Nothing
        Private _LabelFromUDFTable5 As String = Nothing
        Private _CompLabelFromUDFTable1 As String = Nothing
        Private _CompLabelFromUDFTable2 As String = Nothing
        Private _CompLabelFromUDFTable3 As String = Nothing
        Private _CompLabelFromUDFTable4 As String = Nothing
        Private _CompLabelFromUDFTable5 As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidation As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionHeading As String = Nothing
        Private _FunctionType As String = Nothing
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderDescription As String = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _MediaMonth As Nullable(Of Short) = Nothing
        Private _MediaYear As Nullable(Of Short) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _MarketCode As String = Nothing
        Private _MarketDescription As String = Nothing
        Private _SalesGLAccountCode As String = Nothing
        Private _SalesGLAccountDescription As String = Nothing
        Private _CostOfSalesGLAccountCode As String = Nothing
        Private _CostOfSalesGLAccountDescription As String = Nothing
        Private _DirectExpenseGLAccountCode As String = Nothing
        Private _DirectExpenseGLAccountDescription As String = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledFee As Nullable(Of Decimal) = Nothing
        Private _BilledTime As Nullable(Of Decimal) = Nothing
        Private _BilledCommission As Nullable(Of Decimal) = Nothing
        Private _BilledCostOfSales As Nullable(Of Decimal) = Nothing
        Private _BilledIncomeRec As Nullable(Of Decimal) = Nothing
        Private _EstimatedHours As Nullable(Of Decimal) = Nothing
        Private _EstimateFee As Nullable(Of Decimal) = Nothing
        Private _EstimateTime As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedCostAmount As Nullable(Of Decimal) = Nothing
        Private _EstimatedTotalAmount As Nullable(Of Decimal) = Nothing
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
        Private _ForecastFee As Nullable(Of Decimal) = Nothing
        Private _ForecastTime As Nullable(Of Decimal) = Nothing
        Private _ForecastCommission As Nullable(Of Decimal) = Nothing
        Private _ForecastCostOfSales As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectServiceCost As Nullable(Of Decimal) = Nothing
        Private _ForecastDirectExpense As Nullable(Of Decimal) = Nothing
        Private _ForecastGrossIncome As Nullable(Of Decimal) = Nothing
        Private _ForecastIncome As Nullable(Of Decimal) = Nothing
        Private _SumofTotalBilledOffice As Nullable(Of Decimal) = Nothing
        Private _SumofTotalBilledClient As Nullable(Of Decimal) = Nothing
        Private _SumofTotalCostOfBillingOffice As Nullable(Of Decimal) = Nothing
        Private _SumofTotalCostOfBillingClient As Nullable(Of Decimal) = Nothing
        Private _SumofDirectExpensesOffice As Nullable(Of Decimal) = Nothing
        Private _SumofDirectExpensesClient As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOffice As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostOfficeCurrent As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostClient As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostClientCurrent As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeOffice As Nullable(Of Decimal) = Nothing
        Private _SumofTotalGrossIncomeClient As Nullable(Of Decimal) = Nothing
        Private _SumofTotalBilledSalesClass As Nullable(Of Decimal) = Nothing
        Private _SumofTotalCostOfBillingSalesClass As Nullable(Of Decimal) = Nothing
        Private _SumofDirectExpensesSalesClass As Nullable(Of Decimal) = Nothing
        Private _SumofDirectServiceCostSalesClass As Nullable(Of Decimal) = Nothing
        'Private _StartPeriod As String = Nothing
        'Private _EndPeriod As String = Nothing
        'Private _PeriodClientBilledTotal As Nullable(Of Decimal) = Nothing
        'Private _PeriodClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        'Private _PeriodClientNetProfit As Nullable(Of Decimal) = Nothing
        'Private _StartPeriod1 As String = Nothing
        'Private _EndPeriod1 As String = Nothing
        'Private _Period1ClientBilledTotal As Nullable(Of Decimal) = Nothing
        'Private _Period1ClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        'Private _Period1ClientNetProfit As Nullable(Of Decimal) = Nothing
        'Private _StartPeriod2 As String = Nothing
        'Private _EndPeriod2 As String = Nothing
        'Private _Period2ClientBilledTotal As Nullable(Of Decimal) = Nothing
        'Private _Period2ClientTotalGrossIncome As Nullable(Of Decimal) = Nothing
        'Private _Period2ClientNetProfit As Nullable(Of Decimal) = Nothing
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
            Set(value As String)
                _OfficeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(value As String)
                _ClientDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(value As String)
                _DivisionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(value As String)
                _ProductDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultAECode() As String
            Get
                DefaultAECode = _DefaultAECode
            End Get
            Set(value As String)
                _DefaultAECode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DefaultAEName() As String
            Get
                DefaultAEName = _DefaultAEName
            End Get
            Set(value As String)
                _DefaultAEName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF1() As String
            Get
                ProductUDF1 = _ProductUDF1
            End Get
            Set(value As String)
                _ProductUDF1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF2() As String
            Get
                ProductUDF2 = _ProductUDF2
            End Get
            Set(value As String)
                _ProductUDF2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF3() As String
            Get
                ProductUDF3 = _ProductUDF3
            End Get
            Set(value As String)
                _ProductUDF3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductUDF4() As String
            Get
                ProductUDF4 = _ProductUDF4
            End Get
            Set(value As String)
                _ProductUDF4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Industry() As String
            Get
                Industry = _Industry
            End Get
            Set
                _Industry = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Specialty() As String
            Get
                Specialty = _Specialty
            End Get
            Set
                _Specialty = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set
                _Region = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property RegionCode() As String
            Get
                RegionCode = _RegionCode
            End Get
            Set
                _RegionCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Revenue() As Nullable(Of Decimal)
            Get
                Revenue = _Revenue
            End Get
            Set
                _Revenue = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NumberOfEmployees() As Nullable(Of Integer)
            Get
                NumberOfEmployees = _NumberOfEmployees
            End Get
            Set
                _NumberOfEmployees = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(value As String)
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CampaignName() As String
            Get
                CampaignName = _CampaignName
            End Get
            Set(value As String)
                _CampaignName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostingPeriod() As String
            Get
                PostingPeriod = _PostingPeriod
            End Get
            Set(value As String)
                _PostingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")> ', DisplayFormat:="f0"
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(value As String)
                _ComponentDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobStatus() As String
            Get
                JobStatus = _JobStatus
            End Get
            Set(value As String)
                _JobStatus = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(value As String)
                _JobTypeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobTypeDescription() As String
            Get
                JobTypeDescription = _JobTypeDescription
            End Get
            Set(value As String)
                _JobTypeDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesClassFormatCode() As String
            Get
                SalesClassFormatCode = _SalesClassFormatCode
            End Get
            Set(value As String)
                _SalesClassFormatCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ComplexityCode() As String
            Get
                ComplexityCode = _ComplexityCode
            End Get
            Set(value As String)
                _ComplexityCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PromotionCode() As String
            Get
                PromotionCode = _PromotionCode
            End Get
            Set(value As String)
                _PromotionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(value As String)
                _ClientReference = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAECode() As String
            Get
                JobAECode = _JobAECode
            End Get
            Set(value As String)
                _JobAECode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAEName() As String
            Get
                JobAEName = _JobAEName
            End Get
            Set(value As String)
                _JobAEName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable1() As String
            Get
                LabelFromUDFTable1 = _LabelFromUDFTable1
            End Get
            Set(value As String)
                _LabelFromUDFTable1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable2() As String
            Get
                LabelFromUDFTable2 = _LabelFromUDFTable2
            End Get
            Set(value As String)
                _LabelFromUDFTable2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable3() As String
            Get
                LabelFromUDFTable3 = _LabelFromUDFTable3
            End Get
            Set(value As String)
                _LabelFromUDFTable3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable4() As String
            Get
                LabelFromUDFTable4 = _LabelFromUDFTable4
            End Get
            Set(value As String)
                _LabelFromUDFTable4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property LabelFromUDFTable5() As String
            Get
                LabelFromUDFTable5 = _LabelFromUDFTable5
            End Get
            Set(value As String)
                _LabelFromUDFTable5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable1() As String
            Get
                CompLabelFromUDFTable1 = _CompLabelFromUDFTable1
            End Get
            Set(value As String)
                _CompLabelFromUDFTable1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable2() As String
            Get
                CompLabelFromUDFTable2 = _CompLabelFromUDFTable2
            End Get
            Set(value As String)
                _CompLabelFromUDFTable2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable3() As String
            Get
                CompLabelFromUDFTable3 = _CompLabelFromUDFTable3
            End Get
            Set(value As String)
                _CompLabelFromUDFTable3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable4() As String
            Get
                CompLabelFromUDFTable4 = _CompLabelFromUDFTable4
            End Get
            Set(value As String)
                _CompLabelFromUDFTable4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CompLabelFromUDFTable5() As String
            Get
                CompLabelFromUDFTable5 = _CompLabelFromUDFTable5
            End Get
            Set(value As String)
                _CompLabelFromUDFTable5 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionConsolidation() As String
            Get
                FunctionConsolidation = _FunctionConsolidation
            End Get
            Set(value As String)
                _FunctionConsolidation = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(value As String)
                _FunctionHeading = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property OrderNumber() As Nullable(Of Integer)
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Nullable(Of Integer))
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(value As String)
                _OrderDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaMonth() As Nullable(Of Short)
            Get
                MediaMonth = _MediaMonth
            End Get
            Set(value As Nullable(Of Short))
                _MediaMonth = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MediaYear() As Nullable(Of Short)
            Get
                MediaYear = _MediaYear
            End Get
            Set(value As Nullable(Of Short))
                _MediaYear = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndDate() As Nullable(Of Date)
            Get
                EndDate = _EndDate
            End Get
            Set(value As Nullable(Of Date))
                _EndDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketCode() As String
            Get
                MarketCode = _MarketCode
            End Get
            Set(value As String)
                _MarketCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketDescription() As String
            Get
                MarketDescription = _MarketDescription
            End Get
            Set(value As String)
                _MarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesGLAccountCode() As String
            Get
                SalesGLAccountCode = _SalesGLAccountCode
            End Get
            Set(value As String)
                _SalesGLAccountCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property SalesGLAccountDescription() As String
            Get
                SalesGLAccountDescription = _SalesGLAccountDescription
            End Get
            Set(value As String)
                _SalesGLAccountDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostOfSalesGLAccountCode() As String
            Get
                CostOfSalesGLAccountCode = _CostOfSalesGLAccountCode
            End Get
            Set(value As String)
                _CostOfSalesGLAccountCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostOfSalesGLAccountDescription() As String
            Get
                CostOfSalesGLAccountDescription = _CostOfSalesGLAccountDescription
            End Get
            Set(value As String)
                _CostOfSalesGLAccountDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectExpenseGLAccountCode() As String
            Get
                DirectExpenseGLAccountCode = _DirectExpenseGLAccountCode
            End Get
            Set(value As String)
                _DirectExpenseGLAccountCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectExpenseGLAccountDescription() As String
            Get
                DirectExpenseGLAccountDescription = _DirectExpenseGLAccountDescription
            End Get
            Set(value As String)
                _DirectExpenseGLAccountDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours
            End Get
            Set
                _BilledHours = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity
            End Get
            Set
                _BilledQuantity = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
                Public Property BilledFee() As Nullable(Of Decimal)
            Get
                BilledFee = _BilledFee
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledTime() As Nullable(Of Decimal)
            Get
                BilledTime = _BilledTime
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCommission() As Nullable(Of Decimal)
            Get
                BilledCommission = _BilledCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledCostOfSales() As Nullable(Of Decimal)
            Get
                BilledCostOfSales = _BilledCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledCostOfSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledIncomeRec() As Nullable(Of Decimal)
            Get
                BilledIncomeRec = _BilledIncomeRec
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledIncomeRec = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimatedHours() As Nullable(Of Decimal)
            Get
                EstimatedHours = _EstimatedHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateFee() As Nullable(Of Decimal)
            Get
                EstimateFee = _EstimateFee
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTime() As Nullable(Of Decimal)
            Get
                EstimateTime = _EstimateTime
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimateMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimatedCostAmount() As Nullable(Of Decimal)
            Get
                EstimatedCostAmount = _EstimatedCostAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedCostAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimatedTotalAmount() As Nullable(Of Decimal)
            Get
                EstimatedTotalAmount = _EstimatedTotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _EstimatedTotalAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ManualSale() As Nullable(Of Decimal)
            Get
                ManualSale = _ManualSale
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualSale = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ManualCOS() As Nullable(Of Decimal)
            Get
                ManualCOS = _ManualCOS
            End Get
            Set(value As Nullable(Of Decimal))
                _ManualCOS = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLSales() As Nullable(Of Decimal)
            Get
                GLSales = _GLSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLCostOfSales() As Nullable(Of Decimal)
            Get
                GLCostOfSales = _GLCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _GLCostOfSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalGrossIncome() As Nullable(Of Decimal)
            Get
                TotalGrossIncome = _TotalGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalGrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectServiceCost() As Nullable(Of Decimal)
            Get
                DirectServiceCost = _DirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectServiceCost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectServiceBillAmount() As Nullable(Of Decimal)
            Get
                DirectServiceBillAmount = _DirectServiceBillAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectServiceBillAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DirectExpense() As Nullable(Of Decimal)
            Get
                DirectExpense = _DirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _DirectExpense = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLDirectExpense() As Nullable(Of Decimal)
            Get
                GLDirectExpense = _GLDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _GLDirectExpense = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalDirectCosts() As Nullable(Of Decimal)
            Get
                TotalDirectCosts = _TotalDirectCosts
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalDirectCosts = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalIncome() As Nullable(Of Decimal)
            Get
                TotalIncome = _TotalIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Overhead() As Nullable(Of Decimal)
            Get
                Overhead = _Overhead
            End Get
            Set(value As Nullable(Of Decimal))
                _Overhead = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IncomeLessOverhead() As Nullable(Of Decimal)
            Get
                IncomeLessOverhead = _IncomeLessOverhead
            End Get
            Set(value As Nullable(Of Decimal))
                _IncomeLessOverhead = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FTE() As Nullable(Of Decimal)
            Get
                FTE = _FTE
            End Get
            Set(value As Nullable(Of Decimal))
                _FTE = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CRClientSales() As Nullable(Of Decimal)
            Get
                CRClientSales = _CRClientSales
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CRClientCostOfSales() As Nullable(Of Decimal)
            Get
                CRClientCostOfSales = _CRClientCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientCostOfSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CRClientDirectExpense() As Nullable(Of Decimal)
            Get
                CRClientDirectExpense = _CRClientDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _CRClientDirectExpense = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonbillableAPSales() As Nullable(Of Decimal)
            Get
                NonbillableAPSales = _NonbillableAPSales
            End Get
            Set(value As Nullable(Of Decimal))
                _NonbillableAPSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonbillableAPCostOfSales() As Nullable(Of Decimal)
            Get
                NonbillableAPCostOfSales = _NonbillableAPCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _NonbillableAPCostOfSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastFee() As Nullable(Of Decimal)
            Get
                ForecastFee = _ForecastFee
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastFee = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastTime() As Nullable(Of Decimal)
            Get
                ForecastTime = _ForecastTime
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastCommission() As Nullable(Of Decimal)
            Get
                ForecastCommission = _ForecastCommission
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCommission = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastCostOfSales() As Nullable(Of Decimal)
            Get
                ForecastCostOfSales = _ForecastCostOfSales
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastCostOfSales = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastDirectServiceCost() As Nullable(Of Decimal)
            Get
                ForecastDirectServiceCost = _ForecastDirectServiceCost
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectServiceCost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastDirectExpense() As Nullable(Of Decimal)
            Get
                ForecastDirectExpense = _ForecastDirectExpense
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastDirectExpense = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastGrossIncome() As Nullable(Of Decimal)
            Get
                ForecastGrossIncome = _ForecastGrossIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastGrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ForecastIncome() As Nullable(Of Decimal)
            Get
                ForecastIncome = _ForecastIncome
            End Get
            Set(value As Nullable(Of Decimal))
                _ForecastIncome = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalBilledOffice() As Nullable(Of Decimal)
            Get
                SumofTotalBilledOffice = _SumofTotalBilledOffice
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalBilledOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalBilledClient() As Nullable(Of Decimal)
            Get
                SumofTotalBilledClient = _SumofTotalBilledClient
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalBilledClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalCostOfBillingOffice() As Nullable(Of Decimal)
            Get
                SumofTotalCostOfBillingOffice = _SumofTotalCostOfBillingOffice
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalCostOfBillingOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalCostOfBillingClient() As Nullable(Of Decimal)
            Get
                SumofTotalCostOfBillingClient = _SumofTotalCostOfBillingClient
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalCostOfBillingClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectExpensesOffice() As Nullable(Of Decimal)
            Get
                SumofDirectExpensesOffice = _SumofDirectExpensesOffice
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectExpensesOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectExpensesClient() As Nullable(Of Decimal)
            Get
                SumofDirectExpensesClient = _SumofDirectExpensesClient
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectExpensesClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOffice() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOffice = _SumofDirectServiceCostOffice
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectServiceCostOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostOfficeCurrent() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostOfficeCurrent = _SumofDirectServiceCostOfficeCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectServiceCostOfficeCurrent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostClient() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostClient = _SumofDirectServiceCostClient
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectServiceCostClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostClientCurrent() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostClientCurrent = _SumofDirectServiceCostClientCurrent
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectServiceCostClientCurrent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeOffice() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeOffice = _SumofTotalGrossIncomeOffice
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalGrossIncomeOffice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalGrossIncomeClient() As Nullable(Of Decimal)
            Get
                SumofTotalGrossIncomeClient = _SumofTotalGrossIncomeClient
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalGrossIncomeClient = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalBilledSalesClass() As Nullable(Of Decimal)
            Get
                SumofTotalBilledSalesClass = _SumofTotalBilledSalesClass
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalBilledSalesClass = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofTotalCostOfBillingSalesClass() As Nullable(Of Decimal)
            Get
                SumofTotalCostOfBillingSalesClass = _SumofTotalCostOfBillingSalesClass
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofTotalCostOfBillingSalesClass = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectExpensesSalesClass() As Nullable(Of Decimal)
            Get
                SumofDirectExpensesSalesClass = _SumofDirectExpensesSalesClass
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectExpensesSalesClass = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SumofDirectServiceCostSalesClass() As Nullable(Of Decimal)
            Get
                SumofDirectServiceCostSalesClass = _SumofDirectServiceCostSalesClass
            End Get
            Set(value As Nullable(Of Decimal))
                _SumofDirectServiceCostSalesClass = value
            End Set
        End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property StartPeriod() As String
        '    Get
        '        StartPeriod = _StartPeriod
        '    End Get
        '    Set(value As String)
        '        _StartPeriod = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EndPeriod() As String
        '    Get
        '        EndPeriod = _EndPeriod
        '    End Get
        '    Set(value As String)
        '        _EndPeriod = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property PeriodClientBilledTotal() As Nullable(Of Decimal)
        '    Get
        '        PeriodClientBilledTotal = _PeriodClientBilledTotal
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _PeriodClientBilledTotal = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property PeriodClientTotalGrossIncome() As Nullable(Of Decimal)
        '    Get
        '        PeriodClientTotalGrossIncome = _PeriodClientTotalGrossIncome
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _PeriodClientTotalGrossIncome = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property PeriodClientNetProfit() As Nullable(Of Decimal)
        '    Get
        '        PeriodClientNetProfit = _PeriodClientNetProfit
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _PeriodClientNetProfit = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property StartPeriod1() As String
        '    Get
        '        StartPeriod1 = _StartPeriod1
        '    End Get
        '    Set(value As String)
        '        _StartPeriod1 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EndPeriod1() As String
        '    Get
        '        EndPeriod1 = _EndPeriod1
        '    End Get
        '    Set(value As String)
        '        _EndPeriod1 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period1ClientBilledTotal() As Nullable(Of Decimal)
        '    Get
        '        Period1ClientBilledTotal = _Period1ClientBilledTotal
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period1ClientBilledTotal = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period1ClientTotalGrossIncome() As Nullable(Of Decimal)
        '    Get
        '        Period1ClientTotalGrossIncome = _Period1ClientTotalGrossIncome
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period1ClientTotalGrossIncome = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period1ClientNetProfit() As Nullable(Of Decimal)
        '    Get
        '        Period1ClientNetProfit = _Period1ClientNetProfit
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period1ClientNetProfit = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property StartPeriod2() As String
        '    Get
        '        StartPeriod2 = _StartPeriod2
        '    End Get
        '    Set(value As String)
        '        _StartPeriod2 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property EndPeriod2() As String
        '    Get
        '        EndPeriod2 = _EndPeriod2
        '    End Get
        '    Set(value As String)
        '        _EndPeriod2 = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period2ClientBilledTotal() As Nullable(Of Decimal)
        '    Get
        '        Period2ClientBilledTotal = _Period2ClientBilledTotal
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period2ClientBilledTotal = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period2ClientTotalGrossIncome() As Nullable(Of Decimal)
        '    Get
        '        Period2ClientTotalGrossIncome = _Period2ClientTotalGrossIncome
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period2ClientTotalGrossIncome = value
        '    End Set
        'End Property
        '<System.Runtime.Serialization.DataMemberAttribute()>
        'Public Property Period2ClientNetProfit() As Nullable(Of Decimal)
        '    Get
        '        Period2ClientNetProfit = _Period2ClientNetProfit
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _Period2ClientNetProfit = value
        '    End Set
        'End Property


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
