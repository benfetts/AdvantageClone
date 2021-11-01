Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class JobDetailAnalysisEmployeeTime

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarkupPercent
            JobComponent
            IsNonBillable
            Hold
            AdvanceBillFlag
            ClientCode
            ClientDescription
            DivisionCode
            DivisionDescription
            ProductCode
            ProductDescription
            AccountExecutiveCode
            AccountExecutive
            ClientReference
            JobNumber
            JobDescription
            SalesClassCode
            JobComponentNumber
            ComponentDescription
            JobTypeCode
            FunctionTypeOrder
            FunctionType
            FunctionTypeDescription
            Order
            FunctionCode
            FunctionDescription
            ItemDescription
            ItemDate
            ItemCode
            ClientPO
            StartDate
            DueDate
            'SumOfEstimate
            'SumOfEstimateHours
            'SumOfEstimateCont
            'SumOfEstimateNetCost
            'SumOfEstimateNetAmount
            'SumOfEstimateExtMarkup
            'SumOfEstimateVenTax
            'SumOfEstimateResaleTax
            SumOfIncomeOnly
            SumOfBillEmpHours
            SumOfTotalBill
            'SumOfAPNetCost
            SumOfAPQuantity
            SumOfExtMarkupAmount
            'SumOfVenTax
            SumOfResaleTax
            SumOfResaleBilled
            'SumOfOpenPOAmount
            SumOfLineTotal
            SumOfNonBillableEmpHours
            SumOfNonBillableAmount
            SumOfNonBillableMarkupAmount
            SumOfBilledAmount
            SumOfAdvanceBilled
            SumOfAdvanceResale
            SumOfAdvanceResaleBilled
            SumOfAdvanceFinalBilled
            SumOfAdvanceTotal
            'SumOfBilledCost
            SumOfUnbilled
            ProcessDesc
            JobProcessControl
            Code
            ZeroMU
            IsAdvanceBill
            EstimateNumber
            EstimateComponentNumber
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _JobComponent As String = Nothing
        Private _IsNonBillable As String = Nothing
        Private _Hold As String = Nothing
        Private _AdvanceBillFlag As Nullable(Of Short) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionDescription As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductDescription As String = Nothing
        Private _AccountExecutiveCode As String = Nothing
        Private _AccountExecutive As String = Nothing
        Private _ClientReference As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _ComponentDescription As String = Nothing
        Private _JobTypeCode As String = Nothing
        Private _FunctionTypeOrder As Nullable(Of Integer) = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionTypeDescription As String = Nothing
        Private _Order As Nullable(Of Integer) = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _ItemDescription As String = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _ItemCode As String = Nothing
        Private _ClientPO As String = Nothing
        'Private _SumOfEstimate As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateHours As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateCont As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateNetAmount As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateExtMarkup As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateVenTax As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateResaleTax As Nullable(Of Decimal) = Nothing
        Private _SumOfIncomeOnly As Nullable(Of Decimal) = Nothing
        Private _SumOfBillEmpHours As Nullable(Of Decimal) = Nothing
        Private _SumOfTotalBill As Nullable(Of Decimal) = Nothing
        'Private _SumOfAPNetCost As Nullable(Of Decimal) = Nothing
        Private _SumOfAPQuantity As Nullable(Of Decimal) = Nothing
        Private _SumOfExtMarkupAmount As Nullable(Of Decimal) = Nothing
        'Private _SumOfVenTax As Nullable(Of Decimal) = Nothing
        Private _SumOfResaleTax As Nullable(Of Decimal) = Nothing
        Private _SumOfResaleBilled As Nullable(Of Decimal) = Nothing
        'Private _SumOfOpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfLineTotal As Nullable(Of Decimal) = Nothing
        Private _SumOfNonBillableEmpHours As Nullable(Of Decimal) = Nothing
        Private _SumOfNonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfNonBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfBilledAmount As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceResale As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceResaleBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceFinalBilled As Nullable(Of Decimal) = Nothing
        Private _SumOfAdvanceTotal As Nullable(Of Decimal) = Nothing
        'Private _SumOfBilledCost As Nullable(Of Decimal) = Nothing
        Private _SumOfUnbilled As Nullable(Of Decimal) = Nothing
        Private _ProcessDesc As String = Nothing
        Private _JobProcessControl As Nullable(Of Short) = Nothing
        Private _Code As String = Nothing
        Private _ZeroMU As Nullable(Of Decimal) = Nothing
        Private _IsAdvanceBill As String = Nothing
        Private _EstimateNumber As Nullable(Of Integer) = Nothing
        Private _EstimateComponentNumber As Nullable(Of Short) = Nothing

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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobComponent() As String
            Get
                JobComponent = _JobComponent
            End Get
            Set(ByVal value As String)
                _JobComponent = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsNonBillable() As String
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(ByVal value As String)
                _IsNonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Hold() As String
            Get
                Hold = _Hold
            End Get
            Set(ByVal value As String)
                _Hold = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdvanceBillFlag() As Nullable(Of Short)
            Get
                AdvanceBillFlag = _AdvanceBillFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _AdvanceBillFlag = value
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
        Public Property AccountExecutiveCode() As String
            Get
                AccountExecutiveCode = _AccountExecutiveCode
            End Get
            Set(ByVal value As String)
                _AccountExecutiveCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountExecutive() As String
            Get
                AccountExecutive = _AccountExecutive
            End Get
            Set(ByVal value As String)
                _AccountExecutive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientReference() As String
            Get
                ClientReference = _ClientReference
            End Get
            Set(ByVal value As String)
                _ClientReference = value
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
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(ByVal value As String)
                _SalesClassCode = value
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
        Public Property JobTypeCode() As String
            Get
                JobTypeCode = _JobTypeCode
            End Get
            Set(ByVal value As String)
                _JobTypeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionTypeOrder() As Nullable(Of Integer)
            Get
                FunctionTypeOrder = _FunctionTypeOrder
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionTypeOrder = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionTypeDescription() As String
            Get
                FunctionTypeDescription = _FunctionTypeDescription
            End Get
            Set(ByVal value As String)
                _FunctionTypeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Order() As Nullable(Of Integer)
            Get
                Order = _Order
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Order = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(ByVal value As String)
                _ItemDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemDate() As Nullable(Of Date)
            Get
                ItemDate = _ItemDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ItemDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(ByVal value As String)
                _ItemCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        Public Property StartDate() As Nullable(Of Date)

        Public Property DueDate() As Nullable(Of Date)
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimate() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimate = _SumOfEstimate
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimate = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateHours() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateHours = _SumOfEstimateHours
        '    End Get
        '    Set(value As Nullable(Of Decimal))
        '        _SumOfEstimateHours = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateCont() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateCont = _SumOfEstimateCont
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimateCont = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateNetCost() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateNetCost = _SumOfEstimateNetCost
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimateNetCost = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateExtMarkup() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateExtMarkup = _SumOfEstimateExtMarkup
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimateExtMarkup = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateVenTax() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateVenTax = _SumOfEstimateVenTax
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimateVenTax = value
        '    End Set
        'End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfEstimateResaleTax() As Nullable(Of Decimal)
        '    Get
        '        SumOfEstimateResaleTax = _SumOfEstimateResaleTax
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfEstimateResaleTax = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfIncomeOnly() As Nullable(Of Decimal)
            Get
                SumOfIncomeOnly = _SumOfIncomeOnly
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfIncomeOnly = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfBillEmpHours() As Nullable(Of Decimal)
            Get
                SumOfBillEmpHours = _SumOfBillEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfBillEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfTotalBill() As Nullable(Of Decimal)
            Get
                SumOfTotalBill = _SumOfTotalBill
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfTotalBill = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfAPNetCost() As Nullable(Of Decimal)
        '    Get
        '        SumOfAPNetCost = _SumOfAPNetCost
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfAPNetCost = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAPQuantity() As Nullable(Of Decimal)
            Get
                SumOfAPQuantity = _SumOfAPQuantity
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAPQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfExtMarkupAmount() As Nullable(Of Decimal)
            Get
                SumOfExtMarkupAmount = _SumOfExtMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfExtMarkupAmount = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfVenTax() As Nullable(Of Decimal)
        '    Get
        '        SumOfVenTax = _SumOfVenTax
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfVenTax = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfResaleTax() As Nullable(Of Decimal)
            Get
                SumOfResaleTax = _SumOfResaleTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfResaleTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfResaleBilled() As Nullable(Of Decimal)
            Get
                SumOfResaleBilled = _SumOfResaleBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfResaleBilled = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfOpenPOAmount() As Nullable(Of Decimal)
        '    Get
        '        SumOfOpenPOAmount = _SumOfOpenPOAmount
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfOpenPOAmount = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfLineTotal() As Nullable(Of Decimal)
            Get
                SumOfLineTotal = _SumOfLineTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfLineTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfNonBillableEmpHours() As Nullable(Of Decimal)
            Get
                SumOfNonBillableEmpHours = _SumOfNonBillableEmpHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfNonBillableEmpHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfNonBillableAmount() As Nullable(Of Decimal)
            Get
                SumOfNonBillableAmount = _SumOfNonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfNonBillableAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfNonBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                SumOfNonBillableMarkupAmount = _SumOfNonBillableMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfNonBillableMarkupAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfBilledAmount() As Nullable(Of Decimal)
            Get
                SumOfBilledAmount = _SumOfBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfBilledAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAdvanceBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceBilled = _SumOfAdvanceBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfAdvanceBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAdvanceResale() As Nullable(Of Decimal)
            Get
                SumOfAdvanceResale = _SumOfAdvanceResale
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceResale = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAdvanceResaleBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceResaleBilled = _SumOfAdvanceResaleBilled
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceResaleBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAdvanceFinalBilled() As Nullable(Of Decimal)
            Get
                SumOfAdvanceFinalBilled = _SumOfAdvanceFinalBilled
            End Get
            Set(value As Nullable(Of Decimal))
                _SumOfAdvanceFinalBilled = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfAdvanceTotal() As Nullable(Of Decimal)
            Get
                SumOfAdvanceTotal = _SumOfAdvanceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _SumOfAdvanceTotal = value
            End Set
        End Property
        '<'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        'Public Property SumOfBilledCost() As Nullable(Of Decimal)
        '    Get
        '        SumOfBilledCost = _SumOfBilledCost
        '    End Get
        '    Set(ByVal value As Nullable(Of Decimal))
        '        _SumOfBilledCost = value
        '    End Set
        'End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SumOfUnbilled() As Nullable(Of Decimal)
            Get
                SumOfUnbilled = _SumOfUnbilled
            End Get
            Set
                _SumOfUnbilled = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ProcessDesc() As String
            Get
                ProcessDesc = _ProcessDesc
            End Get
            Set(ByVal value As String)
                _ProcessDesc = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property JobProcessControl() As Nullable(Of Short)
            Get
                JobProcessControl = _JobProcessControl
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobProcessControl = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Code() As String
            Get
                Code = _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ZeroMU() As Nullable(Of Decimal)
            Get
                ZeroMU = _ZeroMU
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ZeroMU = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsAdvanceBill() As String
            Get
                IsAdvanceBill = _IsAdvanceBill
            End Get
            Set(ByVal value As String)
                _IsAdvanceBill = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateNumber() As Nullable(Of Integer)
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _EstimateNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EstimateComponentNumber() As Nullable(Of Short)
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _EstimateComponentNumber = value
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
