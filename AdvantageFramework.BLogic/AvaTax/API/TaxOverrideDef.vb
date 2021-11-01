Namespace AvaTax.API

    <Serializable> _
    Public Class TaxOverrideDef

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _TaxOverrideType As String = Nothing
        Private _TaxAmount As String = Nothing
        Private _TaxDate As String = Nothing
        Private _Reason As String = Nothing

#End Region

#Region " Properties "

        Public Property TaxOverrideType() As String
            Get
                TaxOverrideType = _TaxOverrideType
            End Get
            Set(value As String)
                _TaxOverrideType = value
            End Set
        End Property
        Public Property TaxAmount() As String
            Get
                TaxAmount = _TaxAmount
            End Get
            Set(value As String)
                _TaxAmount = value
            End Set
        End Property
        Public Property TaxDate() As String
            Get
                TaxDate = _TaxDate
            End Get
            Set(value As String)
                _TaxDate = value
            End Set
        End Property
        Public Property Reason() As String
            Get
                Reason = _Reason
            End Get
            Set(value As String)
                _Reason = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace