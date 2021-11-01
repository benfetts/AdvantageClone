Namespace AvaTax.Classes

    Public Class AvaTaxInvoice

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            DivisionCode
            ProductCode
            FunctionCode
            SalesClassCode
            FunctionDescription
            TaxExempt
            AvaTaxCompanyCode
            AvaTaxCode
            HoursQuantity
            Amount
            BillingAddress
            BillingCity
            BillingState
            BillingZip
            BillingCountry
            TotalTax
            InvoiceNumber
            IsAvaTaxCalculated
            InvoiceDate
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _TaxExempt As Boolean = False
        Private _AvaTaxCompanyCode As String = Nothing
        Private _AvaTaxCode As String = Nothing
        Private _HoursQuantity As Decimal = Nothing
        Private _Amount As Decimal = Nothing
        Private _BillingAddress As String = Nothing
        Private _BillingCity As String = Nothing
        Private _BillingState As String = Nothing
        Private _BillingZip As String = Nothing
        Private _TotalTax As Decimal = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _IsAvaTaxCalculated As Boolean = False
        Private _BillingCountry As String = Nothing
        Private _InvoiceDate As Date = Nothing

#End Region

#Region " Properties "

        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property TaxExempt() As Boolean
            Get
                TaxExempt = _TaxExempt
            End Get
            Set(value As Boolean)
                _TaxExempt = value
            End Set
        End Property
        Public Property AvaTaxCompanyCode() As String
            Get
                AvaTaxCompanyCode = _AvaTaxCompanyCode
            End Get
            Set(value As String)
                _AvaTaxCompanyCode = value
            End Set
        End Property
        Public Property AvaTaxCode() As String
            Get
                AvaTaxCode = _AvaTaxCode
            End Get
            Set(value As String)
                _AvaTaxCode = value
            End Set
        End Property
        Public Property HoursQuantity() As Decimal
            Get
                HoursQuantity = _HoursQuantity
            End Get
            Set(value As Decimal)
                _HoursQuantity = value
            End Set
        End Property
        Public Property Amount() As Decimal
            Get
                Amount = _Amount
            End Get
            Set(value As Decimal)
                _Amount = value
            End Set
        End Property
        Public Property BillingAddress() As String
            Get
                BillingAddress = _BillingAddress
            End Get
            Set(value As String)
                _BillingAddress = value
            End Set
        End Property
        Public Property BillingCity() As String
            Get
                BillingCity = _BillingCity
            End Get
            Set(value As String)
                _BillingCity = value
            End Set
        End Property
        Public Property BillingState() As String
            Get
                BillingState = _BillingState
            End Get
            Set(value As String)
                _BillingState = value
            End Set
        End Property
        Public Property BillingZip() As String
            Get
                BillingZip = _BillingZip
            End Get
            Set(value As String)
                _BillingZip = value
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
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        Public Property IsAvaTaxCalculated() As Boolean
            Get
                IsAvaTaxCalculated = _IsAvaTaxCalculated
            End Get
            Set(value As Boolean)
                _IsAvaTaxCalculated = value
            End Set
        End Property
        Public Property BillingCountry() As String
            Get
                BillingCountry = _BillingCountry
            End Get
            Set(value As String)
                _BillingCountry = value
            End Set
        End Property
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace