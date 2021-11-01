Namespace AvaTax.API

    <Serializable> _
    Public Class TaxLine

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LineNo As String = Nothing
        Private _TaxCode As String = Nothing
        Private _Taxability As Boolean = Nothing
        Private _Taxable As Decimal = Nothing
        Private _Rate As Decimal = Nothing
        Private _Tax As Decimal = Nothing
        Private _Discount As Decimal = Nothing
        Private _TaxCalculated As Decimal = Nothing
        Private _Exemption As Decimal = Nothing
        Private _TaxDetails As AdvantageFramework.AvaTax.API.TaxDetail() = Nothing

#End Region

#Region " Properties "

        Public Property LineNo() As String
            Get
                LineNo = _LineNo
            End Get
            Set(value As String)
                _LineNo = value
            End Set
        End Property
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        Public Property Taxability() As Boolean
            Get
                Taxability = _Taxability
            End Get
            Set(value As Boolean)
                _Taxability = value
            End Set
        End Property
        Public Property Taxable() As Decimal
            Get
                Taxable = _Taxable
            End Get
            Set(value As Decimal)
                _Taxable = value
            End Set
        End Property
        Public Property Rate() As Decimal
            Get
                Rate = _Rate
            End Get
            Set(value As Decimal)
                _Rate = value
            End Set
        End Property
        Public Property Tax() As Decimal
            Get
                Tax = _Tax
            End Get
            Set(value As Decimal)
                _Tax = value
            End Set
        End Property
        Public Property Discount() As Decimal
            Get
                Discount = _Discount
            End Get
            Set(value As Decimal)
                _Discount = value
            End Set
        End Property
        Public Property TaxCalculated() As Decimal
            Get
                TaxCalculated = _TaxCalculated
            End Get
            Set(value As Decimal)
                _TaxCalculated = value
            End Set
        End Property
        Public Property Exemption() As Decimal
            Get
                Exemption = _Exemption
            End Get
            Set(value As Decimal)
                _Exemption = value
            End Set
        End Property
        Public Property TaxDetails() As AdvantageFramework.AvaTax.API.TaxDetail()
            Get
                TaxDetails = _TaxDetails
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxDetail())
                _TaxDetails = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace