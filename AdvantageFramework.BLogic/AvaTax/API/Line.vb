Namespace AvaTax.API

    <Serializable> _
    Public Class Line

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _LineNo As String = Nothing
        Private _DestinationCode As String = Nothing
        Private _OriginCode As String = Nothing
        Private _ItemCode As String = Nothing
        Private _Qty As Decimal = Nothing
        Private _Amount As Decimal = Nothing
        Private _TaxCode As String = Nothing
        Private _CustomerUsageType As String = Nothing
        Private _TaxOverride As AdvantageFramework.AvaTax.API.TaxOverrideDef = Nothing
        Private _Description As String = Nothing
        Private _Discounted As Boolean = Nothing
        Private _TaxIncluded As Boolean = Nothing
        Private _Ref1 As String = Nothing
        Private _Ref2 As String = Nothing

#End Region

#Region " Properties"

        Public Property LineNo() As String
            Get
                LineNo = _LineNo
            End Get
            Set(value As String)
                _LineNo = value
            End Set
        End Property
        Public Property DestinationCode() As String
            Get
                DestinationCode = _DestinationCode
            End Get
            Set(value As String)
                _DestinationCode = value
            End Set
        End Property
        Public Property OriginCode() As String
            Get
                OriginCode = _OriginCode
            End Get
            Set(value As String)
                _OriginCode = value
            End Set
        End Property
        Public Property ItemCode() As String
            Get
                ItemCode = _ItemCode
            End Get
            Set(value As String)
                _ItemCode = value
            End Set
        End Property
        Public Property Qty() As Decimal
            Get
                Qty = _Qty
            End Get
            Set(value As Decimal)
                _Qty = value
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
        Public Property TaxCode() As String
            Get
                TaxCode = _TaxCode
            End Get
            Set(value As String)
                _TaxCode = value
            End Set
        End Property
        Public Property CustomerUsageType() As String
            Get
                CustomerUsageType = _CustomerUsageType
            End Get
            Set(value As String)
                _CustomerUsageType = value
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
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Discounted() As Boolean
            Get
                Discounted = _Discounted
            End Get
            Set(value As Boolean)
                _Discounted = value
            End Set
        End Property
        Public Property TaxIncluded() As Boolean
            Get
                TaxIncluded = _TaxIncluded
            End Get
            Set(value As Boolean)
                _TaxIncluded = value
            End Set
        End Property
        Public Property Ref1() As String
            Get
                Ref1 = _Ref1
            End Get
            Set(value As String)
                _Ref1 = value
            End Set
        End Property
        Public Property Ref2() As String
            Get
                Ref2 = _Ref2
            End Get
            Set(value As String)
                _Ref2 = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace