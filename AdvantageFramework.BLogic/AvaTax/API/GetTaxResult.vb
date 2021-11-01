Namespace AvaTax.API

    <Serializable> _
    Public Class GetTaxResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocCode As String = Nothing
        Private _DocDate As DateTime = Nothing
        Private _TimeStamp As DateTime = Nothing
        Private _TotalAmount As Decimal = Nothing
        Private _TotalDiscount As Decimal = Nothing
        Private _TotalExemption As Decimal = Nothing
        Private _TotalTaxable As Decimal = Nothing
        Private _TotalTax As Decimal = Nothing
        Private _TotalTaxCalculated As Decimal = Nothing
        Private _TaxDate As DateTime = Nothing
        Private _TaxLines As AdvantageFramework.AvaTax.API.TaxLine() = Nothing
        Private _TaxSummary As AdvantageFramework.AvaTax.API.TaxLine() = Nothing
        Private _TaxAddresses As TaxAddress() = Nothing
        Private _ResultCode As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _Messages As Message() = Nothing

#End Region

#Region " Properties "

        ' Result of tax/get verb POST
        Public Property DocCode() As String
            Get
                DocCode = _DocCode
            End Get
            Set(value As String)
                _DocCode = value
            End Set
        End Property
        Public Property DocDate() As DateTime
            Get
                DocDate = _DocDate
            End Get
            Set(value As DateTime)
                _DocDate = value
            End Set
        End Property
        Public Property TimeStamp() As DateTime
            Get
                TimeStamp = _TimeStamp
            End Get
            Set(value As DateTime)
                _TimeStamp = value
            End Set
        End Property
        Public Property TotalAmount() As Decimal
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(value As Decimal)
                _TotalAmount = value
            End Set
        End Property
        Public Property TotalDiscount() As Decimal
            Get
                TotalDiscount = _TotalDiscount
            End Get
            Set(value As Decimal)
                _TotalDiscount = value
            End Set
        End Property
        Public Property TotalExemption() As Decimal
            Get
                TotalExemption = _TotalExemption
            End Get
            Set(value As Decimal)
                _TotalExemption = value
            End Set
        End Property
        Public Property TotalTaxable() As Decimal
            Get
                TotalTaxable = _TotalTaxable
            End Get
            Set(value As Decimal)
                _TotalTaxable = value
            End Set
        End Property
        Public Property TotalTax() As Decimal
            Get
                TotalTax = _TotalTax
            End Get
            Set(value As Decimal)
                _TotalTax = value
            End Set
        End Property
        Public Property TotalTaxCalculated() As Decimal
            Get
                TotalTaxCalculated = _TotalTaxCalculated
            End Get
            Set(value As Decimal)
                _TotalTaxCalculated = value
            End Set
        End Property
        Public Property TaxDate() As DateTime
            Get
                TaxDate = _TaxDate
            End Get
            Set(value As DateTime)
                _TaxDate = value
            End Set
        End Property
        Public Property TaxLines() As AdvantageFramework.AvaTax.API.TaxLine()
            Get
                TaxLines = _TaxLines
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxLine())
                _TaxLines = value
            End Set
        End Property
        Public Property TaxSummary() As AdvantageFramework.AvaTax.API.TaxLine()
            Get
                TaxSummary = _TaxSummary
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxLine())
                _TaxSummary = value
            End Set
        End Property
        Public Property TaxAddresses() As AdvantageFramework.AvaTax.API.TaxAddress()
            Get
                TaxAddresses = _TaxAddresses
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxAddress())
                _TaxAddresses = value
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
        Public Property Messages() As Message()
            Get
                Messages = _Messages
            End Get
            Set(value As Message())
                _Messages = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace