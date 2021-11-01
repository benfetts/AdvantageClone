Namespace Estimate.Printing.Classes

    <Serializable()>
    Public Class TaxInformation002

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateNumber
            EstimateComponentNumber
            EstimateQuoteNumber
            EstimateRevisionNumber
            TaxLabel
            TaxAmountQuote1
            TaxAmountQuote2
            TaxAmountQuote3
            TaxAmountQuote4
        End Enum

#End Region

#Region " Variables "

        Private _EstimateNumber As Integer = Nothing
        Private _EstimateComponentNumber As Short = Nothing
        Private _EstimateQuoteNumber As Short = Nothing
        Private _EstimateRevisionNumber As Short = Nothing
        Private _TaxLabel As String = Nothing
        Private _TaxAmountQuote1 As Nullable(Of Decimal) = Nothing
        Private _TaxAmountQuote2 As Nullable(Of Decimal) = Nothing
        Private _TaxAmountQuote3 As Nullable(Of Decimal) = Nothing
        Private _TaxAmountQuote4 As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateNumber() As Integer
            Get
                EstimateNumber = _EstimateNumber
            End Get
            Set(ByVal value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateComponentNumber() As Integer
            Get
                EstimateComponentNumber = _EstimateComponentNumber
            End Get
            Set(ByVal value As Integer)
                _EstimateComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateQuoteNumber() As Integer
            Get
                EstimateQuoteNumber = _EstimateQuoteNumber
            End Get
            Set(ByVal value As Integer)
                _EstimateQuoteNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EstimateRevisionNumber() As Integer
            Get
                EstimateRevisionNumber = _EstimateRevisionNumber
            End Get
            Set(ByVal value As Integer)
                _EstimateRevisionNumber = value
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
        Public Property TaxAmountQuote1() As Nullable(Of Decimal)
            Get
                TaxAmountQuote1 = _TaxAmountQuote1
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxAmountQuote1 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxAmountQuote2() As Nullable(Of Decimal)
            Get
                TaxAmountQuote2 = _TaxAmountQuote2
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxAmountQuote2 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxAmountQuote3() As Nullable(Of Decimal)
            Get
                TaxAmountQuote3 = _TaxAmountQuote3
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxAmountQuote3 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TaxAmountQuote4() As Nullable(Of Decimal)
            Get
                TaxAmountQuote4 = _TaxAmountQuote4
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _TaxAmountQuote4 = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal EstimateNumber As Integer, ByVal EstimateComponentNumber As Integer, ByVal EstimateQuoteNumber As Integer, TaxLabel As String, TaxAmount As Nullable(Of Decimal))

            _EstimateNumber = EstimateNumber
            _EstimateComponentNumber = EstimateComponentNumber
            _EstimateQuoteNumber = EstimateQuoteNumber
            _EstimateRevisionNumber = EstimateRevisionNumber
            _TaxLabel = TaxLabel
            _TaxAmountQuote1 = TaxAmountQuote1
            _TaxAmountQuote2 = TaxAmountQuote2
            _TaxAmountQuote3 = TaxAmountQuote3
            _TaxAmountQuote4 = TaxAmountQuote4

        End Sub

        Public Overrides Function ToString() As String

            ToString = Me.EstimateNumber.ToString

        End Function

#End Region

    End Class

End Namespace
