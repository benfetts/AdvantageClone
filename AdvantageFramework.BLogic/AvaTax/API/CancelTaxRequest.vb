Namespace AvaTax.API

    <Serializable> _
    Public Class CancelTaxRequest

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CancelCode As AdvantageFramework.AvaTax.API.CancelCode = Nothing
        Private _DocType As AdvantageFramework.AvaTax.API.DocType = Nothing
        Private _CompanyCode As String = Nothing
        Private _DocCode As String = Nothing
        Private _DocID As String = Nothing

#End Region

#Region " Properties "

        Public Property CancelCode() As AdvantageFramework.AvaTax.API.CancelCode
            Get
                CancelCode = _CancelCode
            End Get
            Set(value As AdvantageFramework.AvaTax.API.CancelCode)
                _CancelCode = value
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
        Public Property DocCode() As String
            Get
                DocCode = _DocCode
            End Get
            Set(value As String)
                _DocCode = value
            End Set
        End Property
        Public Property DocID() As String
            Get
                DocID = _DocID
            End Get
            Set(value As String)
                _DocID = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace