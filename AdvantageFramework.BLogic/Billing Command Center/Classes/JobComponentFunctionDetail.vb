Namespace BillingCommandCenter.Classes

    <Serializable()>
    Public Class JobComponentFunctionDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionHeading
            FunctionCode
            FunctionDescription
            EstimateHours
            EstimateQuantity
            EstimateNetAmount
            EstimateMarkupAmount
            EstimateAmount
            AmountToBill
            EstimateResaleTax
            EstimateTotal
            ActualBillableHours
            ActualBillableQuantity
            ActualBillableNetAmount
            ActualBillableMarkupAmount
            ActualBillableAmount
            ActualBillableResaleTax
            ActualBillableTotal
            BilledHours
            BilledQuantity
            BilledNet
            BilledMarkup
            BilledAmount
            BilledResaleTax
            BilledTotal
            UnbilledHours
            UnbilledQuantity
            UnbilledNetAmount
            UnbilledMarkupAmount
            UnbilledAmount
            UnbilledResaleTax
            UnbilledTotal
            AdvanceHours
            AdvanceQuantity
            AdvanceBilledNetAmount
            AdvanceBilledMarkupAmount
            AdvanceBilledAmount
            AdvanceBilledResaleTax
            AdvanceBilledTotal
            TotalBilledAmount
            TotalBilledTax
            TotalBilled
            UnbilledAdvanceAmount
            UnbilledAdvanceResaleTax
            UnbilledAdvanceTotal
            FlatIncomeRecognized
            NonBillableHours
            NonBillableQuantity
            NonBillableNetAmount
            NonBillableMarkupAmount
            NonBillableAmount
            FeeHours
            FeeAmount
            FeeResaleTax
            FeeTotal
            BillHoldAmount
            OpenPOAmount
            PercentCompleteTime
            PercentCompleteAll
            JobNumber
            ComponentNumber
            FunctionType
            FunctionOrder
            FunctionConsolidationCode
            FunctionConsolidationDescription
            BilledOfEstimate
            BillingApprovalFunctionAmount
            BillingApprovalFunctionComment
            BillingApprovalFunctionClientComment
            AdvanceBillRequested
            Reconcile
            BillingApprovalDetailID
            FlatIncomeToRecognize
            AmountToReconcile
            UnbilledNetOnly
            BillingUser
            GrossIncome
            AdvanceBillingBalance
            AdvanceBillingRetained
        End Enum

#End Region

#Region " Variables "

        Private _FunctionHeading As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _EstimateHours As Decimal = Nothing
        Private _EstimateQuantity As Decimal = Nothing
        Private _EstimateNetAmount As Decimal = Nothing
        Private _EstimateMarkupAmount As Decimal = Nothing
        Private _EstimateAmount As Decimal = Nothing
        Private _AmountToBill As Decimal = Nothing
        Private _EstimateResaleTax As Decimal = Nothing
        Private _EstimateTotal As Decimal = Nothing
        Private _ActualBillableHours As Nullable(Of Decimal) = Nothing
        Private _ActualBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _ActualBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableAmount As Nullable(Of Decimal) = Nothing
        Private _ActualBillableResaleTax As Nullable(Of Decimal) = Nothing
        Private _ActualBillableTotal As Nullable(Of Decimal) = Nothing
        Private _BilledHours As Nullable(Of Decimal) = Nothing
        Private _BilledQuantity As Nullable(Of Decimal) = Nothing
        Private _BilledNet As Nullable(Of Decimal) = Nothing
        Private _BilledMarkup As Nullable(Of Decimal) = Nothing
        Private _BilledAmount As Nullable(Of Decimal) = Nothing
        Private _BilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _BilledTotal As Nullable(Of Decimal) = Nothing
        Private _UnbilledHours As Nullable(Of Decimal) = Nothing
        Private _UnbilledQuantity As Nullable(Of Decimal) = Nothing
        Private _UnbilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _UnbilledTotal As Nullable(Of Decimal) = Nothing
        Private _AdvanceHours As Nullable(Of Decimal) = Nothing
        Private _AdvanceQuantity As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledNetAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledAmount As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledResaleTax As Nullable(Of Decimal) = Nothing
        Private _AdvanceBilledTotal As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceAmount As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceResaleTax As Nullable(Of Decimal) = Nothing
        Private _UnbilledAdvanceTotal As Nullable(Of Decimal) = Nothing
        Private _FlatIncomeRecognized As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Nullable(Of Decimal) = Nothing
        Private _NonBillableQuantity As Nullable(Of Decimal) = Nothing
        Private _NonBillableNetAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _FeeAmount As Nullable(Of Decimal) = Nothing
        Private _FeeResaleTax As Nullable(Of Decimal) = Nothing
        Private _FeeTotal As Nullable(Of Decimal) = Nothing
        Private _BillHoldAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _PercentCompleteTime As Nullable(Of Decimal) = Nothing
        Private _PercentCompleteAll As Nullable(Of Decimal) = Nothing
        Private _JobNumber As Integer = Nothing
        Private _ComponentNumber As Short = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionOrder As Nullable(Of Short) = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidationDescription As String = Nothing
        Private _BilledOfEstimate As Decimal = Nothing
        Private _BillingApprovalFunctionAmount As Nullable(Of Decimal) = Nothing
        Private _BillingApprovalFunctionComment As String = Nothing
        Private _BillingApprovalFunctionClientComment As String = Nothing
        Private _AdvanceBillRequested As Boolean = False
        Private _Reconcile As Boolean = False
        Private _BillingApprovalDetailID As Nullable(Of Integer) = Nothing
        Private _FlatIncomeToRecognize As Nullable(Of Decimal) = Nothing
        Private _ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing
        Private _UnbilledNetOnly As Nullable(Of Decimal) = Nothing
        Private _BillingUser As String = Nothing
        Private _GrossIncome As Nullable(Of Decimal) = Nothing
        Private _AdvanceBillingRetained As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function" & vbCrLf & "Type")>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(value As String)
                _FunctionType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function" & vbCrLf & "Heading")>
        Public Property FunctionHeading() As String
            Get
                FunctionHeading = _FunctionHeading
            End Get
            Set(value As String)
                _FunctionHeading = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function" & vbCrLf & "Code")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function" & vbCrLf & "Description")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Hours")>
        Public Property EstimateHours() As Decimal
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(value As Decimal)
                _EstimateHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Quantity")>
        Public Property EstimateQuantity() As Decimal
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(value As Decimal)
                _EstimateQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Net Amount")>
        Public Property EstimateNetAmount() As Decimal
            Get
                EstimateNetAmount = _EstimateNetAmount
            End Get
            Set(value As Decimal)
                _EstimateNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Markup Amount")>
        Public Property EstimateMarkupAmount() As Decimal
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(value As Decimal)
                _EstimateMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Amount")>
        Public Property EstimateAmount() As Decimal
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(value As Decimal)
                _EstimateAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Resale Tax")>
        Public Property EstimateResaleTax() As Decimal
            Get
                EstimateResaleTax = _EstimateResaleTax
            End Get
            Set(value As Decimal)
                _EstimateResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Estimate" & vbCrLf & "Total")>
        Public Property EstimateTotal() As Decimal
            Get
                EstimateTotal = _EstimateTotal
            End Get
            Set(value As Decimal)
                _EstimateTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Hours")>
        Public Property ActualBillableHours() As Nullable(Of Decimal)
            Get
                ActualBillableHours = _ActualBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Quantity")>
        Public Property ActualBillableQuantity() As Nullable(Of Decimal)
            Get
                ActualBillableQuantity = _ActualBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Net Amount")>
        Public Property ActualBillableNetAmount() As Nullable(Of Decimal)
            Get
                ActualBillableNetAmount = _ActualBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Markup Amount")>
        Public Property ActualBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                ActualBillableMarkupAmount = _ActualBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Amount")>
        Public Property ActualBillableAmount() As Nullable(Of Decimal)
            Get
                ActualBillableAmount = _ActualBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual Billable" & vbCrLf & "Resale Tax")>
        Public Property ActualBillableResaleTax() As Nullable(Of Decimal)
            Get
                ActualBillableResaleTax = _ActualBillableResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Actual" & vbCrLf & "Billable Total")>
        Public Property ActualBillableTotal() As Nullable(Of Decimal)
            Get
                ActualBillableTotal = _ActualBillableTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _ActualBillableTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Hours")>
        Public Property BilledHours() As Nullable(Of Decimal)
            Get
                BilledHours = _BilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Quantity")>
        Public Property BilledQuantity() As Nullable(Of Decimal)
            Get
                BilledQuantity = _BilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Net")>
        Public Property BilledNet() As Nullable(Of Decimal)
            Get
                BilledNet = _BilledNet.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledNet = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Markup")>
        Public Property BilledMarkup() As Nullable(Of Decimal)
            Get
                BilledMarkup = _BilledMarkup.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledMarkup = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Amount")>
        Public Property BilledAmount() As Nullable(Of Decimal)
            Get
                BilledAmount = _BilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Resale Tax")>
        Public Property BilledResaleTax() As Nullable(Of Decimal)
            Get
                BilledResaleTax = _BilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Billed" & vbCrLf & "Total")>
        Public Property BilledTotal() As Nullable(Of Decimal)
            Get
                BilledTotal = _BilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Hours")>
        Public Property UnbilledHours() As Nullable(Of Decimal)
            Get
                UnbilledHours = _UnbilledHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Quantity")>
        Public Property UnbilledQuantity() As Nullable(Of Decimal)
            Get
                UnbilledQuantity = _UnbilledQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Net Amount")>
        Public Property UnbilledNetAmount() As Nullable(Of Decimal)
            Get
                UnbilledNetAmount = _UnbilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Markup Amount")>
        Public Property UnbilledMarkupAmount() As Nullable(Of Decimal)
            Get
                UnbilledMarkupAmount = _UnbilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Amount")>
        Public Property UnbilledAmount() As Nullable(Of Decimal)
            Get
                UnbilledAmount = _UnbilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Resale Tax")>
        Public Property UnbilledResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledResaleTax = _UnbilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Total")>
        Public Property UnbilledTotal() As Nullable(Of Decimal)
            Get
                UnbilledTotal = _UnbilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Hours")>
        Public Property AdvanceHours() As Nullable(Of Decimal)
            Get
                AdvanceHours = _AdvanceHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Quantity")>
        Public Property AdvanceQuantity() As Nullable(Of Decimal)
            Get
                AdvanceQuantity = _AdvanceQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Net Amount")>
        Public Property AdvanceBilledNetAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledNetAmount = _AdvanceBilledNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Markup Amount")>
        Public Property AdvanceBilledMarkupAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledMarkupAmount = _AdvanceBilledMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Billed Amount")>
        Public Property AdvanceBilledAmount() As Nullable(Of Decimal)
            Get
                AdvanceBilledAmount = _AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Resale Tax")>
        Public Property AdvanceBilledResaleTax() As Nullable(Of Decimal)
            Get
                AdvanceBilledResaleTax = _AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billed" & vbCrLf & "Total")>
        Public Property AdvanceBilledTotal() As Nullable(Of Decimal)
            Get
                AdvanceBilledTotal = _AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBilledTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Billed" & vbCrLf & "Amount")>
        Public ReadOnly Property TotalBilledAmount() As Decimal
            Get
                TotalBilledAmount = Me.BilledAmount.GetValueOrDefault(0) + Me.AdvanceBilledAmount.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total Billed" & vbCrLf & "Tax")>
        Public ReadOnly Property TotalBilledTax() As Nullable(Of Decimal)
            Get
                TotalBilledTax = Me.BilledResaleTax.GetValueOrDefault(0) + Me.AdvanceBilledResaleTax.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Total" & vbCrLf & "Billed")>
        Public ReadOnly Property TotalBilled() As Nullable(Of Decimal)
            Get
                TotalBilled = Me.BilledTotal.GetValueOrDefault(0) + Me.AdvanceBilledTotal.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Advance Amount")>
        Public Property UnbilledAdvanceAmount() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceAmount = _UnbilledAdvanceAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled Advance" & vbCrLf & "Resale Tax")>
        Public Property UnbilledAdvanceResaleTax() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceResaleTax = _UnbilledAdvanceResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Unbilled" & vbCrLf & "Advance Total")>
        Public Property UnbilledAdvanceTotal() As Nullable(Of Decimal)
            Get
                UnbilledAdvanceTotal = _UnbilledAdvanceTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledAdvanceTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Flat Income" & vbCrLf & "Recognized")>
        Public Property FlatIncomeRecognized() As Nullable(Of Decimal)
            Get
                FlatIncomeRecognized = _FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeRecognized = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Flat Income" & vbCrLf & "to Recognize")>
        Public Property FlatIncomeToRecognize() As Nullable(Of Decimal)
            Get
                FlatIncomeToRecognize = _FlatIncomeToRecognize.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FlatIncomeToRecognize = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Hours")>
        Public Property NonBillableHours() As Nullable(Of Decimal)
            Get
                NonBillableHours = _NonBillableHours.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableHours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Quantity")>
        Public Property NonBillableQuantity() As Nullable(Of Decimal)
            Get
                NonBillableQuantity = _NonBillableQuantity.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableQuantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Net Amount")>
        Public Property NonBillableNetAmount() As Nullable(Of Decimal)
            Get
                NonBillableNetAmount = _NonBillableNetAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableNetAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Markup Amount")>
        Public Property NonBillableMarkupAmount() As Nullable(Of Decimal)
            Get
                NonBillableMarkupAmount = _NonBillableMarkupAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableMarkupAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Non Billable" & vbCrLf & "Amount")>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _NonBillableAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Hours")>
        Public Property FeeHours() As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee Time Amount")>
        Public Property FeeAmount() As Nullable(Of Decimal)
            Get
                FeeAmount = _FeeAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Resale Tax")>
        Public Property FeeResaleTax() As Nullable(Of Decimal)
            Get
                FeeResaleTax = _FeeResaleTax.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeResaleTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Fee" & vbCrLf & "Total")>
        Public Property FeeTotal() As Nullable(Of Decimal)
            Get
                FeeTotal = _FeeTotal.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _FeeTotal = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Bill Hold" & vbCrLf & "Amount")>
        Public Property BillHoldAmount() As Nullable(Of Decimal)
            Get
                BillHoldAmount = _BillHoldAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _BillHoldAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Open PO" & vbCrLf & "Amount")>
        Public Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _OpenPOAmount.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _OpenPOAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Percent" & vbCrLf & "Complete Time")>
        Public Property PercentCompleteTime() As Nullable(Of Decimal)
            Get
                PercentCompleteTime = _PercentCompleteTime.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentCompleteTime = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Percent" & vbCrLf & "Complete All")>
        Public Property PercentCompleteAll() As Nullable(Of Decimal)
            Get
                PercentCompleteAll = _PercentCompleteAll.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentCompleteAll = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComponentNumber() As Short
            Get
                ComponentNumber = _ComponentNumber
            End Get
            Set(value As Short)
                _ComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function" & vbCrLf & "Order")>
        Public Property FunctionOrder() As Nullable(Of Short)
            Get
                FunctionOrder = _FunctionOrder
            End Get
            Set(value As Nullable(Of Short))
                _FunctionOrder = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Consol" & vbCrLf & "Code")>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Consol" & vbCrLf & "Description")>
        Public Property FunctionConsolidationDescription() As String
            Get
                FunctionConsolidationDescription = _FunctionConsolidationDescription
            End Get
            Set(value As String)
                _FunctionConsolidationDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="% Billed" & vbCrLf & "of Quote")>
        Public Property BilledOfEstimate() As Decimal
            Get
                BilledOfEstimate = _BilledOfEstimate
            End Get
            Set(value As Decimal)
                _BilledOfEstimate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Amount" & vbCrLf & "to Bill")>
        Public Property AmountToBill() As Decimal
            Get
                AmountToBill = _AmountToBill
            End Get
            Set(value As Decimal)
                _AmountToBill = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Approved" & vbCrLf & "Amount")>
        Public Property BillingApprovalFunctionAmount() As Nullable(Of Decimal)
            Get
                BillingApprovalFunctionAmount = _BillingApprovalFunctionAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _BillingApprovalFunctionAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval" & vbCrLf & "Comment", IsReadOnlyColumn:=True)>
        Public Property BillingApprovalFunctionComment() As String
            Get
                BillingApprovalFunctionComment = _BillingApprovalFunctionComment
            End Get
            Set(value As String)
                _BillingApprovalFunctionComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Approval" & vbCrLf & "Client Comment")>
        Public Property BillingApprovalFunctionClientComment() As String
            Get
                BillingApprovalFunctionClientComment = _BillingApprovalFunctionClientComment
            End Get
            Set(value As String)
                _BillingApprovalFunctionClientComment = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AdvanceBillRequested() As Boolean
            Get
                AdvanceBillRequested = _AdvanceBillRequested
            End Get
            Set(value As Boolean)
                _AdvanceBillRequested = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Reconcile() As Boolean
            Get
                Reconcile = _Reconcile
            End Get
            Set(value As Boolean)
                _Reconcile = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingApprovalDetailID() As Nullable(Of Integer)
            Get
                BillingApprovalDetailID = _BillingApprovalDetailID
            End Get
            Set(value As Nullable(Of Integer))
                _BillingApprovalDetailID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public Property ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary
            Get
                ProductionSummary = _ProductionSummary
            End Get
            Set(value As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)
                _ProductionSummary = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public ReadOnly Property AmountToReconcile() As Decimal
            Get
                AmountToReconcile = GetAmountToReconcile
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property UnbilledNetOnly() As Nullable(Of Decimal)
            Get
                UnbilledNetOnly = _UnbilledNetOnly.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _UnbilledNetOnly = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BillingUser() As String
            Get
                BillingUser = _BillingUser
            End Get
            Set(value As String)
                _BillingUser = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Gross" & vbCrLf & "Income")>
        Public Property GrossIncome() As Nullable(Of Decimal)
            Get
                GrossIncome = _GrossIncome.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _GrossIncome = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance Billing" & vbCrLf & "Balance")>
        Public ReadOnly Property AdvanceBillingBalance() As Decimal
            Get
                AdvanceBillingBalance = Me.AdvanceBilledAmount.GetValueOrDefault(0) - Me.FlatIncomeRecognized.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", CustomColumnCaption:="Advance" & vbCrLf & "Billing Retained")>
        Public Property AdvanceBillingRetained() As Nullable(Of Decimal)
            Get
                AdvanceBillingRetained = _AdvanceBillingRetained.GetValueOrDefault(0)
            End Get
            Set(value As Nullable(Of Decimal))
                _AdvanceBillingRetained = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.BillingCommandCenter.Classes.JobComponentFunctionDetail.Properties.BillingApprovalDetailID.ToString
                    ' don't want the icon in the grid cell
                    If Me.BillingApprovalFunctionAmount IsNot Nothing Then

                        If Me.BillingApprovalFunctionAmount.Value <> Me.AmountToBill Then

                            IsValid = True

                            ErrorText = "Amount to Bill does not match Approved Amount."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function
        Public Sub RecalculateAmountToReconcile()

            GetAmountToReconcile()

        End Sub
        Private Function GetAmountToReconcile() As Decimal

            Dim Amount As Decimal = 0

            If Me.ProductionSummary IsNot Nothing Then

                If Me.ProductionSummary.AccountPayableProductionItems IsNot Nothing Then

                    Amount += Me.ProductionSummary.AccountPayableProductionItems.Where(Function(Entity) Entity.FunctionCode = Me.FunctionCode AndAlso Entity.Reconcile = True AndAlso Entity.IsNonBillable.GetValueOrDefault(0) = 0).Sum(Function(Entity) Entity.Total)

                End If

                If Me.ProductionSummary.EmployeeTimeItems IsNot Nothing Then

                    Amount += Me.ProductionSummary.EmployeeTimeItems.Where(Function(Entity) Entity.FunctionCode = Me.FunctionCode AndAlso Entity.Reconcile = True AndAlso Entity.IsNonBillable.GetValueOrDefault(0) = 0).Sum(Function(Entity) Entity.Total)

                End If

                If Me.ProductionSummary.IncomeOnlyItems IsNot Nothing Then

                    Amount += Me.ProductionSummary.IncomeOnlyItems.Where(Function(Entity) Entity.FunctionCode = Me.FunctionCode AndAlso Entity.Reconcile = True AndAlso Entity.IsNonBillable = False).Sum(Function(Entity) Entity.Total)

                End If

            End If

            GetAmountToReconcile = Amount

        End Function

#End Region

    End Class

End Namespace