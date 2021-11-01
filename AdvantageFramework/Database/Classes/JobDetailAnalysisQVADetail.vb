Namespace Database.Classes

    <Serializable()>
    Public Class JobDetailAnalysisQVADetail

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FunctionCode
            FunctionDescription
            FunctionType
            Estimate
            ItemDate
            ItemDescription
            InvoiceReference
            EstimateQuantity
            EstimateAmount
            EstimateMarkup
            EstimateTax
            EstimateTotal
            ActualHours
            ActualAmount
            ActualMarkup
            ActualTax
            ActualTotal
            Billed
            OpenPOAmount
            ARInvoiceNumber
            SuppliedByCode
            NonBillable
            AdjustedDate
            AdjustedComment
            RecID
            SequenceNumber
            GroupDescription
            FunctionTypeDescription
            FunctionHeadingID
            FunctionHeadingDescription
            FunctionConsolidationCode
            FunctionConsolidationDescription
            JobNumber
            JobComponentNumber

        End Enum

#End Region

#Region " Variables "

        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _FunctionType As String = Nothing
        Private _Estimate As Nullable(Of Integer) = Nothing
        Private _ItemDate As Nullable(Of Date) = Nothing
        Private _ItemDescription As String = Nothing
        Private _InvoiceReference As String = Nothing
        Private _EstimateQuantity As Nullable(Of Decimal) = Nothing
        Private _EstimateAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateMarkup As Nullable(Of Decimal) = Nothing
        Private _EstimateTax As Nullable(Of Decimal) = Nothing
        Private _EstimateTotal As Nullable(Of Decimal) = Nothing
        Private _ActualHours As Nullable(Of Decimal) = Nothing
        Private _ActualAmount As Nullable(Of Decimal) = Nothing
        Private _ActualMarkup As Nullable(Of Decimal) = Nothing
        Private _ActualTax As Nullable(Of Decimal) = Nothing
        Private _ActualTotal As Nullable(Of Decimal) = Nothing
        Private _Billed As Nullable(Of Decimal) = Nothing
        Private _OpenPOAmount As Nullable(Of Decimal) = Nothing
        Private _ARInvoiceNumber As Nullable(Of Integer) = Nothing
        Private _SuppliedByCode As String = Nothing
        Private _NonBillable As Nullable(Of Short) = Nothing
        Private _AdjustedDate As Nullable(Of Date) = Nothing
        Private _AdjustedComment As String = Nothing
        Private _RecID As Nullable(Of Integer) = Nothing
        Private _SequenceNumber As Nullable(Of Integer) = Nothing
        Private _GroupDescription As String = Nothing
        Private _FunctionTypeDescription As String = Nothing
        Private _FunctionHeadingID As Nullable(Of Integer) = Nothing
        Private _FunctionHeadingDescription As String = Nothing
        Private _FunctionConsolidationCode As String = Nothing
        Private _FunctionConsolidationDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

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
        Public Property FunctionType() As String
            Get
                FunctionType = _FunctionType
            End Get
            Set(ByVal value As String)
                _FunctionType = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Estimate() As Nullable(Of Integer)
            Get
                Estimate = _Estimate
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _Estimate = value
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
        Public Property ItemDescription() As String
            Get
                ItemDescription = _ItemDescription
            End Get
            Set(ByVal value As String)
                _ItemDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceReference() As String
            Get
                InvoiceReference = _InvoiceReference
            End Get
            Set(ByVal value As String)
                _InvoiceReference = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateQuantity() As Nullable(Of Decimal)
            Get
                EstimateQuantity = _EstimateQuantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateQuantity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateAmount() As Nullable(Of Decimal)
            Get
                EstimateAmount = _EstimateAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateMarkup() As Nullable(Of Decimal)
            Get
                EstimateMarkup = _EstimateMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTax() As Nullable(Of Decimal)
            Get
                EstimateTax = _EstimateTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property EstimateTotal() As Nullable(Of Decimal)
            Get
                EstimateTotal = _EstimateTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualHours() As Nullable(Of Decimal)
            Get
                ActualHours = _ActualHours
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualAmount() As Nullable(Of Decimal)
            Get
                ActualAmount = _ActualAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualMarkup() As Nullable(Of Decimal)
            Get
                ActualMarkup = _ActualMarkup
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualMarkup = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualTax() As Nullable(Of Decimal)
            Get
                ActualTax = _ActualTax
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualTotal() As Nullable(Of Decimal)
            Get
                ActualTotal = _ActualTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ActualTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Billed() As Nullable(Of Decimal)
            Get
                Billed = _Billed
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Billed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenPOAmount() As Nullable(Of Decimal)
            Get
                OpenPOAmount = _OpenPOAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenPOAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceNumber() As Nullable(Of Integer)
            Get
                ARInvoiceNumber = _ARInvoiceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ARInvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SuppliedByCode() As String
            Get
                SuppliedByCode = _SuppliedByCode
            End Get
            Set(ByVal value As String)
                _SuppliedByCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As Nullable(Of Short)
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjustedDate() As Nullable(Of Date)
            Get
                AdjustedDate = _AdjustedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _AdjustedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdjustedComment() As String
            Get
                AdjustedComment = _AdjustedComment
            End Get
            Set(ByVal value As String)
                _AdjustedComment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecID() As Nullable(Of Integer)
            Get
                RecID = _RecID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _RecID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SequenceNumber() As Nullable(Of Integer)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _SequenceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GroupDescription() As String
            Get
                GroupDescription = _GroupDescription
            End Get
            Set(ByVal value As String)
                _GroupDescription = value
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
        Public Property FunctionHeadingID() As Nullable(Of Integer)
            Get
                FunctionHeadingID = _FunctionHeadingID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _FunctionHeadingID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionHeadingDescription() As String
            Get
                FunctionHeadingDescription = _FunctionHeadingDescription
            End Get
            Set(ByVal value As String)
                _FunctionHeadingDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationCode() As String
            Get
                FunctionConsolidationCode = _FunctionConsolidationCode
            End Get
            Set(ByVal value As String)
                _FunctionConsolidationCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionConsolidationDescription() As String
            Get
                FunctionConsolidationDescription = _FunctionConsolidationDescription
            End Get
            Set(ByVal value As String)
                _FunctionConsolidationDescription = value
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
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
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
