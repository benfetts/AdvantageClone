Namespace AvaTax.API

    <Serializable> _
    Public Class ValidateResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Address As AdvantageFramework.AvaTax.API.Address = Nothing
        Private _ResultCode As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _Messages As AdvantageFramework.AvaTax.API.Message() = Nothing

#End Region

#Region " Properties "

        Public Property Address() As AdvantageFramework.AvaTax.API.Address
            Get
                Address = _Address
            End Get
            Set(value As AdvantageFramework.AvaTax.API.Address)
                _Address = value
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