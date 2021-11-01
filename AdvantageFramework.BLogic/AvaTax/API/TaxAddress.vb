Namespace AvaTax.API

    <Serializable> _
    Public Class TaxAddress

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Address As String = Nothing
        Private _AddressCode As String = Nothing
        Private _City As String = Nothing
        Private _Region As String = Nothing
        Private _Country As String = Nothing
        Private _PostalCode As String = Nothing
        Private _Latitude As Decimal = Nothing
        Private _Longitude As Decimal = Nothing
        Private _TaxRegionId As String = Nothing
        Private _JurisCode As String = Nothing

#End Region

#Region " Properties "

        Public Property Address() As String
            Get
                Address = _Address
            End Get
            Set(value As String)
                _Address = value
            End Set
        End Property
        Public Property AddressCode() As String
            Get
                AddressCode = _AddressCode
            End Get
            Set(value As String)
                _AddressCode = value
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
        Public Property Country() As String
            Get
                Country = _Country
            End Get
            Set(value As String)
                _Country = value
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
        Public Property Latitude() As Decimal
            Get
                Latitude = _Latitude
            End Get
            Set(value As Decimal)
                _Latitude = value
            End Set
        End Property
        Public Property Longitude() As Decimal
            Get
                Longitude = _Longitude
            End Get
            Set(value As Decimal)
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
        Public Property JurisCode() As String
            Get
                JurisCode = _JurisCode
            End Get
            Set(value As String)
                _JurisCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace