Namespace AvaTax.API

    <Serializable> _
    Public Class Address

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _AddressCode As String = Nothing
        Private _Line1 As String = Nothing
        Private _Line2 As String = Nothing
        Private _Line3 As String = Nothing
        Private _City As String = Nothing
        Private _Region As String = Nothing
        Private _PostalCode As String = Nothing
        Private _Country As String = Nothing
        Private _County As String = Nothing
        Private _FipsCode As String = Nothing
        Private _CarrierRoute As String = Nothing
        Private _PostNet As String = Nothing
        Private _AddressType As System.Nullable(Of AdvantageFramework.AvaTax.API.AddressType) = Nothing
        Private _Latitude As System.Nullable(Of Decimal) = Nothing
        Private _Longitude As System.Nullable(Of Decimal) = Nothing
        Private _TaxRegionId As String = Nothing

#End Region

#Region " Properties "

        Public Property AddressCode() As String
            Get
                AddressCode = _AddressCode
            End Get
            Set(value As String)
                _AddressCode = value
            End Set
        End Property
        Public Property Line1() As String
            Get
                Line1 = _Line1
            End Get
            Set(value As String)
                _Line1 = value
            End Set
        End Property
        Public Property Line2() As String
            Get
                Line2 = _Line2
            End Get
            Set(value As String)
                _Line2 = value
            End Set
        End Property
        Public Property Line3() As String
            Get
                Line3 = _Line3
            End Get
            Set(value As String)
                _Line3 = value
            End Set
        End Property
        Public Property City() As String
            Get
                City = _City
            End Get
            Set(value As String)
                _City = value
            End Set
        End Property
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set(value As String)
                _Region = value
            End Set
        End Property
        Public Property PostalCode() As String
            Get
                PostalCode = _PostalCode
            End Get
            Set(value As String)
                _PostalCode = value
            End Set
        End Property
        Public Property Country() As String
            Get
                Country = _Country
            End Get
            Set(value As String)
                _Country = value
            End Set
        End Property
        Public Property County() As String
            Get
                County = _County
            End Get
            Set(value As String)
                _County = value
            End Set
        End Property
        Public Property FipsCode() As String
            Get
                FipsCode = _FipsCode
            End Get
            Set(value As String)
                _FipsCode = value
            End Set
        End Property
        Public Property CarrierRoute() As String
            Get
                CarrierRoute = _CarrierRoute
            End Get
            Set(value As String)
                _CarrierRoute = value
            End Set
        End Property
        Public Property PostNet() As String
            Get
                PostNet = _PostNet
            End Get
            Set(value As String)
                _PostNet = value
            End Set
        End Property
        Public Property AddressType() As System.Nullable(Of AdvantageFramework.AvaTax.API.AddressType)
            Get
                AddressType = _AddressType
            End Get
            Set(value As System.Nullable(Of AdvantageFramework.AvaTax.API.AddressType))
                _AddressType = value
            End Set
        End Property
        Public Property Latitude() As System.Nullable(Of Decimal)
            Get
                Latitude = _Latitude
            End Get
            Set(value As System.Nullable(Of Decimal))
                _Latitude = value
            End Set
        End Property
        Public Property Longitude() As System.Nullable(Of Decimal)
            Get
                Longitude = _Longitude
            End Get
            Set(value As System.Nullable(Of Decimal))
                _Longitude = value
            End Set
        End Property
        Public Property TaxRegionId() As String
            Get
                TaxRegionId = _TaxRegionId
            End Get
            Set(value As String)
                _TaxRegionId = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace