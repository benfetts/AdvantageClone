Namespace Database.ComplexTypes

    <System.Data.Objects.DataClasses.EdmComplexTypeAttribute(NamespaceName:="ObjectContext", Name:="JobAmount")>
    <Serializable()>
    Public Class JobAmount
        Inherits BaseClasses.ComplexType

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobAmountType
            JobNumber
            JobComponentNumber
            FunctionType
            FunctionCode
            FunctionDescription
            JobAmountID
            JobAmountSequenceNumber
            JobAmountDate
            PostPeriodCode
            JobAmountCode
            JobAmountDescription
            JobAmountComment
            JobAmountExtra
            FeeTime
            Hours
            TotalBillAmount
            BillAmount
            ExtMarkupAmount
            NonResaleTaxAmount
            ResaleTaxAmount
            JobAmountTotal
            CostAmount
            AccountsRecievablePostPeriodCode
            AccountsRecievableInvoiceNumber
            AccountsRecievableType
            IsAdvanceBilling
            IsNonBillable
            GlexActBill
            EstimateHours
            EstimateTotalAmount
            EstimateContTotalAmount
            EstimateNonResaleTaxAmount
            EstimateResaleTaxAmount
            EstimateMarkupAmount
            EstimateCostAmount
            IsEstimateNonBillable
            EstimateFeeTime
            ApproximateHours
            ApproximateCostAmount
            ApproximateExtNetAmount
            ApproximateTotalAmount
            PurchaseOrderNumber
            OpenPurchaseOrderAmount
            OpenPurchaseOrderGrossAmount
        End Enum

#End Region

#Region " Variables "

        Private _JobAmountType As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionType As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _JobAmountID As Nullable(Of Integer) = Nothing
        Private _JobAmountSequenceNumber As Nullable(Of Integer) = Nothing
        Private _JobAmountDate As Nullable(Of Date) = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _JobAmountCode As String = Nothing
        Private _JobAmountDescription As String = Nothing
        Private _JobAmountComment As String = Nothing
        Private _JobAmountExtra As String = Nothing
        Private _FeeTime As Nullable(Of Byte) = Nothing
        Private _Hours As Nullable(Of Decimal) = Nothing
        Private _TotalBillAmount As Nullable(Of Decimal) = Nothing
        Private _BillAmount As Nullable(Of Decimal) = Nothing
        Private _ExtMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _NonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _ResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _JobAmountTotal As Nullable(Of Decimal) = Nothing
        Private _CostAmount As Nullable(Of Decimal) = Nothing
        Private _AccountsRecievablePostPeriodCode As String = Nothing
        Private _AccountsRecievableInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _AccountsRecievableType As String = Nothing
        Private _IsAdvanceBilling As Nullable(Of Byte) = Nothing
        Private _IsNonBillable As Nullable(Of Byte) = Nothing
        Private _GlexActBill As Nullable(Of Integer) = Nothing
        Private _EstimateHours As Nullable(Of Decimal) = Nothing
        Private _EstimateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateContTotalAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateNonResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateResaleTaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkupAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateCostAmount As Nullable(Of Decimal) = Nothing
        Private _IsEstimateNonBillable As Nullable(Of Byte) = Nothing
        Private _EstimateFeeTime As Nullable(Of Byte) = Nothing
        Private _ApproximateHours As Nullable(Of Decimal) = Nothing
        Private _ApproximateCostAmount As Nullable(Of Decimal) = Nothing
        Private _ApproximateExtNetAmount As Nullable(Of Decimal) = Nothing
        Private _ApproximateTotalAmount As Nullable(Of Decimal) = Nothing
        Private _PurchaseOrderNumber As Nullable(Of Integer) = Nothing
        Private _OpenPurchaseOrderAmount As Nullable(Of Decimal) = Nothing
        Private _OpenPurchaseOrderGrossAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountType() As String
            Get
                JobAmountType = _JobAmountType
            End Get
            Set(ByVal value As String)
                _JobAmountType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
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
        Public Property JobAmountID() As Nullable(Of Integer)
            Get
                JobAmountID = _JobAmountID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobAmountID = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountSequenceNumber() As Nullable(Of Integer)
            Get
                JobAmountSequenceNumber = _JobAmountSequenceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobAmountSequenceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountDate() As Nullable(Of Date)
            Get
                JobAmountDate = _JobAmountDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _JobAmountDate = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountCode() As String
            Get
                JobAmountCode = _JobAmountCode
            End Get
            Set(ByVal value As String)
                _JobAmountCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountDescription() As String
            Get
                JobAmountDescription = _JobAmountDescription
            End Get
            Set(ByVal value As String)
                _JobAmountDescription = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountComment() As String
            Get
                JobAmountComment = _JobAmountComment
            End Get
            Set(ByVal value As String)
                _JobAmountComment = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountExtra() As String
            Get
                JobAmountExtra = _JobAmountExtra
            End Get
            Set(ByVal value As String)
                _JobAmountExtra = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FeeTime() As Nullable(Of Byte)
            Get
                FeeTime = _FeeTime
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _FeeTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours() As Nullable(Of Decimal)
            Get
                Hours = _Hours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Hours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TotalBillAmount() As Nullable(Of Decimal)
            Get
                TotalBillAmount = _TotalBillAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TotalBillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BillAmount() As Nullable(Of Decimal)
            Get
                BillAmount = _BillAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BillAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ExtMarkupAmount() As Nullable(Of Decimal)
            Get
                ExtMarkupAmount = _ExtMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ExtMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                NonResaleTaxAmount = _NonResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ResaleTaxAmount() As Nullable(Of Decimal)
            Get
                ResaleTaxAmount = _ResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property JobAmountTotal() As Nullable(Of Decimal)
            Get
                JobAmountTotal = _JobAmountTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _JobAmountTotal = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CostAmount() As Nullable(Of Decimal)
            Get
                CostAmount = _CostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountsRecievablePostPeriodCode() As String
            Get
                AccountsRecievablePostPeriodCode = _AccountsRecievablePostPeriodCode
            End Get
            Set(ByVal value As String)
                _AccountsRecievablePostPeriodCode = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountsRecievableInvoiceNumber() As Nullable(Of Integer)
            Get
                AccountsRecievableInvoiceNumber = _AccountsRecievableInvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _AccountsRecievableInvoiceNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountsRecievableType() As String
            Get
                AccountsRecievableType = _AccountsRecievableType
            End Get
            Set(ByVal value As String)
                _AccountsRecievableType = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, True)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsAdvanceBilling() As Nullable(Of Byte)
            Get
                IsAdvanceBilling = _IsAdvanceBilling
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _IsAdvanceBilling = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsNonBillable() As Nullable(Of Byte)
            Get
                IsNonBillable = _IsNonBillable
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _IsNonBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GlexActBill() As Nullable(Of Integer)
            Get
                GlexActBill = _GlexActBill
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GlexActBill = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateHours() As Nullable(Of Decimal)
            Get
                EstimateHours = _EstimateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateTotalAmount = _EstimateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateContTotalAmount() As Nullable(Of Decimal)
            Get
                EstimateContTotalAmount = _EstimateContTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateContTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNonResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateNonResaleTaxAmount = _EstimateNonResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateNonResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateResaleTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateResaleTaxAmount = _EstimateResaleTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateResaleTaxAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateMarkupAmount() As Nullable(Of Decimal)
            Get
                EstimateMarkupAmount = _EstimateMarkupAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkupAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateCostAmount() As Nullable(Of Decimal)
            Get
                EstimateCostAmount = _EstimateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateCostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsEstimateNonBillable() As Nullable(Of Byte)
            Get
                IsEstimateNonBillable = _IsEstimateNonBillable
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _IsEstimateNonBillable = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateFeeTime() As Nullable(Of Byte)
            Get
                EstimateFeeTime = _EstimateFeeTime
            End Get
            Set(ByVal value As Nullable(Of Byte))
                _EstimateFeeTime = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApproximateHours() As Nullable(Of Decimal)
            Get
                ApproximateHours = _ApproximateHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ApproximateHours = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApproximateCostAmount() As Nullable(Of Decimal)
            Get
                ApproximateCostAmount = _ApproximateCostAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ApproximateCostAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApproximateExtNetAmount() As Nullable(Of Decimal)
            Get
                ApproximateExtNetAmount = _ApproximateExtNetAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ApproximateExtNetAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ApproximateTotalAmount() As Nullable(Of Decimal)
            Get
                ApproximateTotalAmount = _ApproximateTotalAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ApproximateTotalAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PurchaseOrderNumber() As Nullable(Of Integer)
            Get
                PurchaseOrderNumber = _PurchaseOrderNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _PurchaseOrderNumber = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OpenPurchaseOrderAmount() As Nullable(Of Decimal)
            Get
                OpenPurchaseOrderAmount = _OpenPurchaseOrderAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPurchaseOrderAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property
        <System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty:=False, IsNullable:=True),
        System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OpenPurchaseOrderGrossAmount() As Nullable(Of Decimal)
            Get
                OpenPurchaseOrderGrossAmount = _OpenPurchaseOrderGrossAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPurchaseOrderGrossAmount = System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value)
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobAmountType

        End Function

#End Region

    End Class

End Namespace
