Namespace AvaTax.API

    <Serializable> _
    Public Class GetTaxRequest

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DocDate As String = Nothing
        Private _CustomerCode As String = Nothing
        Private _Addresses As AdvantageFramework.AvaTax.API.Address() = Nothing
        Private _Lines As AdvantageFramework.AvaTax.API.Line() = Nothing
        Private _Client As String = Nothing
        Private _DocCode As String = Nothing
        Private _DocType As AdvantageFramework.AvaTax.API.DocType = Nothing
        Private _CompanyCode As String = Nothing
        Private _Commit As Boolean = Nothing
        Private _DetailLevel As AdvantageFramework.AvaTax.API.DetailLevel = Nothing
        Private _CustomerUsageType As String = Nothing
        Private _ExemptionNo As String = Nothing
        Private _Discount As Decimal = Nothing
        Private _BusinessIdentificationNo As String = Nothing
        Private _TaxOverride As AdvantageFramework.AvaTax.API.TaxOverrideDef = Nothing
        Private _CurrencyCode As String = Nothing
        Private _PurchaseOrderNo As String = Nothing
        Private _PaymentDate As String = Nothing
        Private _PosLaneCode As String = Nothing
        Private _ReferenceCode As String = Nothing

#End Region

#Region " Properties "

        ' Required for tax calculation
        Public Property DocDate() As String
            Get
                DocDate = _DocDate
            End Get
            Set(value As String)
                _DocDate = value
            End Set
        End Property
        Public Property CustomerCode() As String
            Get
                CustomerCode = _CustomerCode
            End Get
            Set(value As String)
                _CustomerCode = value
            End Set
        End Property
        Public Property Addresses() As AdvantageFramework.AvaTax.API.Address()
            Get
                Addresses = _Addresses
            End Get
            Set(value As AdvantageFramework.AvaTax.API.Address())
                _Addresses = value
            End Set
        End Property
        Public Property Lines() As AdvantageFramework.AvaTax.API.Line()
            Get
                Lines = _Lines
            End Get
            Set(value As AdvantageFramework.AvaTax.API.Line())
                _Lines = value
            End Set
        End Property
        ' Best Practice for tax calculation
        Public Property Client() As String
            Get
                Client = _Client
            End Get
            Set(value As String)
                _Client = value
            End Set
        End Property
        Public Property DocCode() As String
            Get
                DocCode = _DocCode
            End Get
            Set(value As String)
                _DocCode = value
            End Set
        End Property
        Public Property DocType() As AdvantageFramework.AvaTax.API.DocType
            Get
                DocType = _DocType
            End Get
            Set(value As AdvantageFramework.AvaTax.API.DocType)
                _DocType = value
            End Set
        End Property
        Public Property CompanyCode() As String
            Get
                CompanyCode = _CompanyCode
            End Get
            Set(value As String)
                _CompanyCode = value
            End Set
        End Property
        Public Property Commit() As Boolean
            Get
                Commit = _Commit
            End Get
            Set(value As Boolean)
                _Commit = value
            End Set
        End Property
        Public Property DetailLevel() As AdvantageFramework.AvaTax.API.DetailLevel
            Get
                DetailLevel = _DetailLevel
            End Get
            Set(value As AdvantageFramework.AvaTax.API.DetailLevel)
                _DetailLevel = value
            End Set
        End Property
        ' Use where appropriate to the situation
        Public Property CustomerUsageType() As String
            Get
                CustomerUsageType = _CustomerUsageType
            End Get
            Set(value As String)
                _CustomerUsageType = value
            End Set
        End Property
        Public Property ExemptionNo() As String
            Get
                ExemptionNo = _ExemptionNo
            End Get
            Set(value As String)
                _ExemptionNo = value
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
        Public Property BusinessIdentificationNo() As String
            Get
                BusinessIdentificationNo = _BusinessIdentificationNo
            End Get
            Set(value As String)
                _BusinessIdentificationNo = value
            End Set
        End Property
        Public Property TaxOverride() As AdvantageFramework.AvaTax.API.TaxOverrideDef
            Get
                TaxOverride = _TaxOverride
            End Get
            Set(value As AdvantageFramework.AvaTax.API.TaxOverrideDef)
                _TaxOverride = value
            End Set
        End Property
        Public Property CurrencyCode() As String
            Get
                CurrencyCode = _CurrencyCode
            End Get
            Set(value As String)
                _CurrencyCode = value
            End Set
        End Property
        ' Optional
        Public Property PurchaseOrderNo() As String
            Get
                PurchaseOrderNo = _PurchaseOrderNo
            End Get
            Set(value As String)
                _PurchaseOrderNo = value
            End Set
        End Property
        Public Property PaymentDate() As String
            Get
                PaymentDate = _PaymentDate
            End Get
            Set(value As String)
                _PaymentDate = value
            End Set
        End Property
        Public Property PosLaneCode() As String
            Get
                PosLaneCode = _PosLaneCode
            End Get
            Set(value As String)
                _PosLaneCode = value
            End Set
        End Property
        Public Property ReferenceCode() As String
            Get
                ReferenceCode = _ReferenceCode
            End Get
            Set(value As String)
                _ReferenceCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace