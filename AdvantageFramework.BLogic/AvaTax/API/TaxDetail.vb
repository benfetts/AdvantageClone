Namespace AvaTax.API

    <Serializable> _
    Public Class TaxDetail

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Rate As Decimal = Nothing
        Private _Tax As Decimal = Nothing
        Private _Taxable As Decimal = Nothing
        Private _Country As String = Nothing
        Private _Region As String = Nothing
        Private _JurisType As String = Nothing
        Private _JurisName As String = Nothing
        Private _TaxName As String = Nothing

#End Region

#Region " Properties "

        ' Result object
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
        Public Property Taxable() As Decimal
            Get
                Taxable = _Taxable
            End Get
            Set(value As Decimal)
                _Taxable = value
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
        Public Property Region() As String
            Get
                Region = _Region
            End Get
            Set(value As String)
                _Region = value
            End Set
        End Property
        Public Property JurisType() As String
            Get
                JurisType = _JurisType
            End Get
            Set(value As String)
                _JurisType = value
            End Set
        End Property
        Public Property JurisName() As String
            Get
                JurisName = _JurisName
            End Get
            Set(value As String)
                _JurisName = value
            End Set
        End Property
        Public Property TaxName() As String
            Get
                TaxName = _TaxName
            End Get
            Set(value As String)
                _TaxName = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace