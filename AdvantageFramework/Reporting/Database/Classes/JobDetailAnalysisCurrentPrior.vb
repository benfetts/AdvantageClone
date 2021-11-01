Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class JobDetailAnalysisCurrentPrior

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            JobNumber
            JobDescription
            JobComponentNumber
            ComponentDescription
            FunctionType
            SumOfEstimateHours
            SumOfEstimate
            SumOfEstimateCont
            SumOfEstimateNetCost
            SumOfEstimateNetAmount
            SumOfEstimateExtMarkup
            SumOfEstimateVenTax
            SumOfEstimateResaleTax
            CurrentMonthSumOfEstimateHours
            CurrentMonthSumOfEstimate
            CurrentMonthSumOfEstimateCont
            CurrentMonthSumOfEstimateNetCost
            CurrentMonthSumOfEstimateNetAmount
            CurrentMonthSumOfEstimateExtMarkup
            CurrentMonthSumOfEstimateVenTax
            CurrentMonthSumOfEstimateResaleTax
            CurrentMonthSumOfIncomeOnly
            CurrentMonthSumOfBillEmpHours
            CurrentMonthSumOfTotalBill
            CurrentMonthSumOfAPQuantity
            CurrentMonthSumOfAPNetCost
            CurrentMonthSumOfExtMarkupAmount
            CurrentMonthSumOfVenTax
            CurrentMonthSumOfResaleTax
            CurrentMonthSumOfResaleBilled
            CurrentMonthSumOfOpenPOAmount
            CurrentMonthSumOfLineTotal
            CurrentMonthSumOfNonBillableEmpHours
            CurrentMonthSumOfNonBillableAmount
            CurrentMonthSumOfBilledAmount
            CurrentMonthSumOfAdvanceBilled
            CurrentMonthSumOfAdvanceTotal
            CurrentMonthSumOfAdvanceResale
            CurrentMonthSumOfAdvanceResaleBilled
            CurrentMonthSumOfAdvanceFinalBilled
            CurrentMonthSumOfBilledCost
            CurrentMonthSumOfUnbilled
            CurrentMonthZeroMU
            PriorMonthsSumOfEstimateHours
            PriorMonthsSumOfEstimate
            PriorMonthsSumOfEstimateCont
            PriorMonthsSumOfEstimateNetCost
            PriorMonthsSumOfEstimateNetAmount
            PriorMonthsSumOfEstimateExtMarkup
            PriorMonthsSumOfEstimateVenTax
            PriorMonthsSumOfEstimateResaleTax
            PriorMonthsSumOfIncomeOnly
            PriorMonthsSumOfBillEmpHours
            PriorMonthsSumOfTotalBill
            PriorMonthsSumOfAPQuantity
            PriorMonthsSumOfAPNetCost
            PriorMonthsSumOfExtMarkupAmount
            PriorMonthsSumOfVenTax
            PriorMonthsSumOfResaleTax
            PriorMonthsSumOfResaleBilled
            PriorMonthsSumOfOpenPOAmount
            PriorMonthsSumOfLineTotal
            PriorMonthsSumOfNonBillableEmpHours
            PriorMonthsSumOfNonBillableAmount
            PriorMonthsSumOfBilledAmount
            PriorMonthsSumOfAdvanceBilled
            PriorMonthsSumOfAdvanceTotal
            PriorMonthsSumOfAdvanceResale
            PriorMonthsSumOfAdvanceResaleBilled
            PriorMonthsSumOfAdvanceFinalBilled
            PriorMonthsSumOfBilledCost
            PriorMonthsSumOfUnbilled
            PriorMonthsZeroMU
            StartDate
            DueDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _SumOfEstimateHours As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimate As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateCont As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
        Private _SumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateHours As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimate As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateCont As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfIncomeOnly As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfBillEmpHours As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfTotalBill As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAPQuantity As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAPNetCost As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfExtMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfVenTax As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfResaleTax As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfResaleBilled As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfOpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfLineTotal As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfNonBillableEmpHours As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfNonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfBilledAmount As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAdvanceBilled As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAdvanceResale As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAdvanceResaleBilled As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfAdvanceFinalBilled As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfBilledCost As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthSumOfUnbilled As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthZeroMU As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateHours As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimate As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateCont As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfIncomeOnly As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfBillEmpHours As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfTotalBill As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAPQuantity As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAPNetCost As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfExtMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfVenTax As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfResaleTax As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfResaleBilled As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfOpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfLineTotal As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfNonBillableEmpHours As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfNonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfBilledAmount As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAdvanceBilled As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAdvanceResale As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAdvanceResaleBilled As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfAdvanceFinalBilled As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfBilledCost As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsSumOfUnbilled As Nullable(Of Decimal) = Nothing
        Private _PriorMonthsZeroMU As Nullable(Of Decimal) = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _DueDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DivisionDescription() As String
            Get
                DivisionDescription = _DivisionDescription
            End Get
            Set(ByVal value As String)
                _DivisionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProductDescription() As String
            Get
                ProductDescription = _ProductDescription
            End Get
            Set(ByVal value As String)
                _ProductDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(ByVal value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ComponentDescription() As String
            Get
                ComponentDescription = _ComponentDescription
            End Get
            Set(ByVal value As String)
                _ComponentDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateHours() As Nullable(Of Decimal)
            Get
                SumOfEstimateHours = _SumOfEstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimate() As Nullable(Of Decimal)
            Get
                SumOfEstimate = _SumOfEstimate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateCont() As Nullable(Of Decimal)
            Get
                SumOfEstimateCont = _SumOfEstimateCont
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateCont = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateNetCost() As Nullable(Of Decimal)
            Get
                SumOfEstimateNetCost = _SumOfEstimateNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateNetCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateNetAmount() As Nullable(Of Decimal)
            Get
                SumOfEstimateNetAmount = _SumOfEstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateExtMarkup() As Nullable(Of Decimal)
            Get
                SumOfEstimateExtMarkup = _SumOfEstimateExtMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateExtMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateVenTax() As Nullable(Of Decimal)
            Get
                SumOfEstimateVenTax = _SumOfEstimateVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateVenTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfEstimateResaleTax() As Nullable(Of Decimal)
            Get
                SumOfEstimateResaleTax = _SumOfEstimateResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfEstimateResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateHours() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateHours = _CurrentMonthSumOfEstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimate() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimate = _CurrentMonthSumOfEstimate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateCont() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateCont = _CurrentMonthSumOfEstimateCont
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateCont = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateNetCost() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateNetCost = _CurrentMonthSumOfEstimateNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateNetCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateNetAmount() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateNetAmount = _CurrentMonthSumOfEstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateExtMarkup() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateExtMarkup = _CurrentMonthSumOfEstimateExtMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateExtMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateVenTax() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateVenTax = _CurrentMonthSumOfEstimateVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateVenTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfEstimateResaleTax() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfEstimateResaleTax = _CurrentMonthSumOfEstimateResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfEstimateResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfIncomeOnly() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfIncomeOnly = _CurrentMonthSumOfIncomeOnly
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfIncomeOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfBillEmpHours() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfBillEmpHours = _CurrentMonthSumOfBillEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfBillEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfTotalBill() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfTotalBill = _CurrentMonthSumOfTotalBill
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfTotalBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAPQuantity() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAPQuantity = _CurrentMonthSumOfAPQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAPQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAPNetCost() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAPNetCost = _CurrentMonthSumOfAPNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAPNetCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfExtMarkupAmount() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfExtMarkupAmount = _CurrentMonthSumOfExtMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfExtMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfVenTax() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfVenTax = _CurrentMonthSumOfVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfVenTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfResaleTax() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfResaleTax = _CurrentMonthSumOfResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfResaleBilled() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfResaleBilled = _CurrentMonthSumOfResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfResaleBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfOpenPOAmount() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfOpenPOAmount = _CurrentMonthSumOfOpenPOAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfOpenPOAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfLineTotal() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfLineTotal = _CurrentMonthSumOfLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfLineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfNonBillableEmpHours() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfNonBillableEmpHours = _CurrentMonthSumOfNonBillableEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfNonBillableEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfNonBillableAmount() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfNonBillableAmount = _CurrentMonthSumOfNonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfNonBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfBilledAmount() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfBilledAmount = _CurrentMonthSumOfBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfBilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAdvanceBilled() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAdvanceBilled = _CurrentMonthSumOfAdvanceBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAdvanceBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAdvanceTotal() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAdvanceTotal = _CurrentMonthSumOfAdvanceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAdvanceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAdvanceResale() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAdvanceResale = _CurrentMonthSumOfAdvanceResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAdvanceResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAdvanceResaleBilled() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAdvanceResaleBilled = _CurrentMonthSumOfAdvanceResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAdvanceResaleBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfAdvanceFinalBilled() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfAdvanceFinalBilled = _CurrentMonthSumOfAdvanceFinalBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfAdvanceFinalBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfBilledCost() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfBilledCost = _CurrentMonthSumOfBilledCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfBilledCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthSumOfUnbilled() As Nullable(Of Decimal)
            Get
                CurrentMonthSumOfUnbilled = _CurrentMonthSumOfUnbilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthSumOfUnbilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CurrentMonthZeroMU() As Nullable(Of Decimal)
            Get
                CurrentMonthZeroMU = _CurrentMonthZeroMU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CurrentMonthZeroMU = value
            End Set
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateHours() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateHours = _PriorMonthsSumOfEstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimate() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimate = _PriorMonthsSumOfEstimate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateCont() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateCont = _PriorMonthsSumOfEstimateCont
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateCont = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateNetCost() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateNetCost = _PriorMonthsSumOfEstimateNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateNetCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateNetAmount() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateNetAmount = _PriorMonthsSumOfEstimateNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateNetAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateExtMarkup() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateExtMarkup = _PriorMonthsSumOfEstimateExtMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateExtMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateVenTax() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateVenTax = _PriorMonthsSumOfEstimateVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateVenTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfEstimateResaleTax() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfEstimateResaleTax = _PriorMonthsSumOfEstimateResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfEstimateResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfIncomeOnly() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfIncomeOnly = _PriorMonthsSumOfIncomeOnly
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfIncomeOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfBillEmpHours() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfBillEmpHours = _PriorMonthsSumOfBillEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfBillEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfTotalBill() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfTotalBill = _PriorMonthsSumOfTotalBill
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfTotalBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAPQuantity() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAPQuantity = _PriorMonthsSumOfAPQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAPQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAPNetCost() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAPNetCost = _PriorMonthsSumOfAPNetCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAPNetCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfExtMarkupAmount() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfExtMarkupAmount = _PriorMonthsSumOfExtMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfExtMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfVenTax() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfVenTax = _PriorMonthsSumOfVenTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfVenTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfResaleTax() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfResaleTax = _PriorMonthsSumOfResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfResaleBilled() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfResaleBilled = _PriorMonthsSumOfResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfResaleBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfOpenPOAmount() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfOpenPOAmount = _PriorMonthsSumOfOpenPOAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfOpenPOAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfLineTotal() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfLineTotal = _PriorMonthsSumOfLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfLineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfNonBillableEmpHours() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfNonBillableEmpHours = _PriorMonthsSumOfNonBillableEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfNonBillableEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfNonBillableAmount() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfNonBillableAmount = _PriorMonthsSumOfNonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfNonBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfBilledAmount() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfBilledAmount = _PriorMonthsSumOfBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfBilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAdvanceBilled() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAdvanceBilled = _PriorMonthsSumOfAdvanceBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAdvanceBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAdvanceTotal() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAdvanceTotal = _PriorMonthsSumOfAdvanceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAdvanceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAdvanceResale() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAdvanceResale = _PriorMonthsSumOfAdvanceResale
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAdvanceResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAdvanceResaleBilled() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAdvanceResaleBilled = _PriorMonthsSumOfAdvanceResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAdvanceResaleBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfAdvanceFinalBilled() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfAdvanceFinalBilled = _PriorMonthsSumOfAdvanceFinalBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfAdvanceFinalBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfBilledCost() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfBilledCost = _PriorMonthsSumOfBilledCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfBilledCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsSumOfUnbilled() As Nullable(Of Decimal)
            Get
                PriorMonthsSumOfUnbilled = _PriorMonthsSumOfUnbilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsSumOfUnbilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PriorMonthsZeroMU() As Nullable(Of Decimal)
            Get
                PriorMonthsZeroMU = _PriorMonthsZeroMU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorMonthsZeroMU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _StartDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
            Get
                DueDate = _DueDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DueDate = value
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
