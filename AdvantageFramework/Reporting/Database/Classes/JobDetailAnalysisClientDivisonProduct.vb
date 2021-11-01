Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class JobDetailAnalysisClientDivisonProduct

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
            StartDate
            DueDate
            'SumOfEstimate
            'SumOfEstimateHours
            'SumOfEstimateCont
            'SumOfEstimateNetCost
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
        'Private _SumOfEstimate As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateHours As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateCont As Nullable(Of Decimal) = Nothing
        'Private _SumOfEstimateNetCost As Nullable(Of Decimal) = Nothing
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

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
