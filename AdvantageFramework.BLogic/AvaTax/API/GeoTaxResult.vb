Namespace AvaTax.API

    <Serializable> _
    Public Class GeoTaxResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Rate As Decimal = Nothing
        Private _Tax As Decimal = Nothing
        Private _TaxDetails As AdvantageFramework.AvaTax.API.TaxDetail() = Nothing
        Private _ResultCode As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _Messages As AdvantageFramework.AvaTax.API.Message() = Nothing

#End Region

#Region " Properties "

        ' Result of tax/get verb GET
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
        Public Property TaxDetails() As AdvantageFramework.AvaTax.API.TaxDetail()
            Get
                TaxDetails = _TaxDetails
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxDetail())
                _TaxDetails = value
            End Set
        End Property
        Public Property ResultCode() As AdvantageFramework.AvaTax.API.SeverityLevel
            Get
                ResultCode = _ResultCode
            End Get
            Set(value As AdvantageFramework.AvaTax.API.SeverityLevel)
                _ResultCode = value
            End Set
        End Property
        Public Property Messages() As AdvantageFramework.AvaTax.API.Message()
            Get
                Messages = _Messages
            End Get
            Set(value As AdvantageFramework.AvaTax.API.Message())
                _Messages = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace