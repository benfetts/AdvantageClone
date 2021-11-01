Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class TaxInformation

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            FullInvoiceNumber
            TaxLabel
            TaxAmount
            EstimateTaxAmount
            PriorTaxAmount
            TTDTaxAmount
        End Enum

#End Region

#Region " Variables "

        Private _FullInvoiceNumber As String = Nothing
        Private _TaxLabel As String = Nothing
        Private _TaxAmount As Nullable(Of Decimal) = Nothing
        Private _EstimateTaxAmount As Nullable(Of Decimal) = Nothing
        Private _PriorTaxAmount As Nullable(Of Decimal) = Nothing
        Private _TTDTaxAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property FullInvoiceNumber() As String
            Get
                FullInvoiceNumber = _FullInvoiceNumber
            End Get
            Set(ByVal value As String)
                _FullInvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxLabel() As String
            Get
                TaxLabel = _TaxLabel
            End Get
            Set(ByVal value As String)
                _TaxLabel = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxAmount() As Nullable(Of Decimal)
            Get
                TaxAmount = _TaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateTaxAmount() As Nullable(Of Decimal)
            Get
                EstimateTaxAmount = _EstimateTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _EstimateTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PriorTaxAmount() As Nullable(Of Decimal)
            Get
                PriorTaxAmount = _PriorTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _PriorTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TTDTaxAmount() As Nullable(Of Decimal)
            Get
                TTDTaxAmount = _TTDTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TTDTaxAmount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal FullInvoiceNumber As String, TaxLabel As String, TaxAmount As Nullable(Of Decimal))

            _FullInvoiceNumber = FullInvoiceNumber
            _TaxLabel = TaxLabel
            _TaxAmount = TaxAmount

        End Sub
        Public Sub New(ByVal FullInvoiceNumber As String, TaxLabel As String, TaxAmount As Nullable(Of Decimal), TTDTaxAmount As Nullable(Of Decimal))

            _FullInvoiceNumber = FullInvoiceNumber
            _TaxLabel = TaxLabel
            _TaxAmount = TaxAmount
            _TTDTaxAmount = TTDTaxAmount

        End Sub
        Public Sub New(ByVal FullInvoiceNumber As String, TaxLabel As String, TaxAmount As Nullable(Of Decimal), EstimateTaxAmount As Nullable(Of Decimal), PriorTaxAmount As Nullable(Of Decimal), TTDTaxAmount As Nullable(Of Decimal))

            _FullInvoiceNumber = FullInvoiceNumber
            _TaxLabel = TaxLabel
            _TaxAmount = TaxAmount
            _EstimateTaxAmount = EstimateTaxAmount
            _PriorTaxAmount = PriorTaxAmount
            _TTDTaxAmount = TTDTaxAmount

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.FullInvoiceNumber.ToString

        End Function

#End Region

    End Class

End Namespace
