Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="QuoteVsActualSummary")>
    <Serializable()>
    Public Class QuoteVsActualSummary
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            FunctionDescription
            FunctionType
            QuotedHours
            QuotedAmount
            QuotedMarkup
            QuotedTaxAmount
            QuotedTotalAmount
            ActualHours
            ActualAmount
            ActualMarkup
            ActualTaxAmount
            ActualTotalAmount
            OpenPurchaseOrderNetAmount
            BilledToDateAmount
            QuoteVsActualPurchaseOrderAmount
            ActualPOvsBilled
            HasQuoteVsActual
            IsAdvancedBilled
            HasQuoteVsActualPurchaseOrder
            IsAdvancedBilledPurchaseOrder
            NonBillableActualHours
            NonBillableActualTotalAmount
            AdvancedBilledAmount
            PurchaseOrderTotalAmount
            PurchaseOrderAppliedAmount
            NonBillableTaxAmount
            NonBillableMarkup
            NonBillableAmount
            ApprovedAmount
            NonBillableHours
            PercentQuote
        End Enum

#End Region

#Region " Variables "

        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _QuotedHours As Nullable(Of Decimal) = Nothing
        Private _QuotedAmount As Nullable(Of Decimal) = Nothing
        Private _QuotedMarkup As Nullable(Of Decimal) = Nothing
        Private _QuotedTaxAmount As Nullable(Of Decimal) = Nothing
        Private _QuotedTotalAmount As Nullable(Of Decimal) = Nothing
        Private _ActualHours As Nullable(Of Decimal) = Nothing
        Private _ActualAmount As Nullable(Of Decimal) = Nothing
        Private _ActualMarkup As Nullable(Of Decimal) = Nothing
        Private _ActualTaxAmount As Nullable(Of Decimal) = Nothing
        Private _ActualTotalAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPurchaseOrderNetAmount As Nullable(Of Decimal) = Nothing
        Private _BilledToDateAmount As Nullable(Of Decimal) = Nothing
        Private _QuoteVsActualPurchaseOrderAmount As Nullable(Of Decimal) = Nothing
        Private _ActualPOvsBilled As Nullable(Of Decimal) = Nothing
        Private _HasQuoteVsActual As Nullable(Of Decimal) = Nothing
        Private _IsAdvancedBilled As Nullable(Of Decimal) = Nothing
        Private _HasQuoteVsActualPurchaseOrder As Nullable(Of Decimal) = Nothing
        Private _IsAdvancedBilledPurchaseOrder As Nullable(Of Decimal) = Nothing
        Private _NonBillableActualHours As Nullable(Of Decimal) = Nothing
        Private _NonBillableActualTotalAmount As Nullable(Of Decimal) = Nothing
        Private _AdvancedBilledAmount As Nullable(Of Decimal) = Nothing
        Private _PurchaseOrderTotalAmount As Nullable(Of Decimal) = Nothing
        Private _PurchaseOrderAppliedAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableTaxAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableMarkup As Nullable(Of Decimal) = Nothing
        Private _NonBillableAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovedAmount As Nullable(Of Decimal) = Nothing
        Private _NonBillableHours As Nullable(Of Decimal) = Nothing
        Private _PercentQuote As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedHours() As Nullable(Of Decimal)
            Get
                QuotedHours = _QuotedHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedAmount() As Nullable(Of Decimal)
            Get
                QuotedAmount = _QuotedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedMarkup() As Nullable(Of Decimal)
            Get
                QuotedMarkup = _QuotedMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedTaxAmount() As Nullable(Of Decimal)
            Get
                QuotedTaxAmount = _QuotedTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuotedTotalAmount() As Nullable(Of Decimal)
            Get
                QuotedTotalAmount = _QuotedTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuotedTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualHours() As Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualAmount() As Nullable(Of Decimal)
            Get
                ActualAmount = _ActualAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualMarkup() As Nullable(Of Decimal)
            Get
                ActualMarkup = _ActualMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualTaxAmount() As Nullable(Of Decimal)
            Get
                ActualTaxAmount = _ActualTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualTotalAmount() As Nullable(Of Decimal)
            Get
                ActualTotalAmount = _ActualTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OpenPurchaseOrderNetAmount() As Nullable(Of Decimal)
            Get
                OpenPurchaseOrderNetAmount = _OpenPurchaseOrderNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPurchaseOrderNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BilledToDateAmount() As Nullable(Of Decimal)
            Get
                BilledToDateAmount = _BilledToDateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledToDateAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property QuoteVsActualPurchaseOrderAmount() As Nullable(Of Decimal)
            Get
                QuoteVsActualPurchaseOrderAmount = _QuoteVsActualPurchaseOrderAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _QuoteVsActualPurchaseOrderAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ActualPOvsBilled() As Nullable(Of Decimal)
            Get
                ActualPOvsBilled = _ActualPOvsBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualPOvsBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HasQuoteVsActual() As Nullable(Of Decimal)
            Get
                HasQuoteVsActual = _HasQuoteVsActual
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HasQuoteVsActual = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAdvancedBilled() As Nullable(Of Decimal)
            Get
                IsAdvancedBilled = _IsAdvancedBilled
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IsAdvancedBilled = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property HasQuoteVsActualPurchaseOrder() As Nullable(Of Decimal)
            Get
                HasQuoteVsActualPurchaseOrder = _HasQuoteVsActualPurchaseOrder
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _HasQuoteVsActualPurchaseOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAdvancedBilledPurchaseOrder() As Nullable(Of Decimal)
            Get
                IsAdvancedBilledPurchaseOrder = _IsAdvancedBilledPurchaseOrder
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _IsAdvancedBilledPurchaseOrder = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableActualHours() As Nullable(Of Decimal)
            Get
                NonBillableActualHours = _NonBillableActualHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableActualHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableActualTotalAmount() As Nullable(Of Decimal)
            Get
                NonBillableActualTotalAmount = _NonBillableActualTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableActualTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AdvancedBilledAmount() As Nullable(Of Decimal)
            Get
                AdvancedBilledAmount = _AdvancedBilledAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AdvancedBilledAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PurchaseOrderTotalAmount() As Nullable(Of Decimal)
            Get
                PurchaseOrderTotalAmount = _PurchaseOrderTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PurchaseOrderTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PurchaseOrderAppliedAmount() As Nullable(Of Decimal)
            Get
                PurchaseOrderAppliedAmount = _PurchaseOrderAppliedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PurchaseOrderAppliedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableTaxAmount() As Nullable(Of Decimal)
            Get
                NonBillableTaxAmount = _NonBillableTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableMarkup() As Nullable(Of Decimal)
            Get
                NonBillableMarkup = _NonBillableMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableMarkup = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableAmount() As Nullable(Of Decimal)
            Get
                NonBillableAmount = _NonBillableAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApprovedAmount() As Nullable(Of Decimal)
            Get
                ApprovedAmount = _ApprovedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ApprovedAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonBillableHours() As Nullable(Of Decimal)
            Get
                NonBillableHours = _NonBillableHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PercentQuote() As Nullable(Of Decimal)
            Get
                PercentQuote = _PercentQuote
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PercentQuote = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.FunctionCode

        End Function

#End Region

    End Class

End Namespace
