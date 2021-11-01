Namespace AvaTax.API

    <Serializable> _
    Public Class CancelTaxResponse

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CancelTaxResult As AdvantageFramework.AvaTax.API.CancelTaxResult = Nothing
        Private _ResultCode As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _Messages As AdvantageFramework.AvaTax.API.Message() = Nothing

#End Region

#Region " Properties "

        Public Property CancelTaxResult() As AdvantageFramework.AvaTax.API.CancelTaxResult
            Get
                CancelTaxResult = _CancelTaxResult
            End Get
            Set(value As AdvantageFramework.AvaTax.API.CancelTaxResult)
                _CancelTaxResult = value
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