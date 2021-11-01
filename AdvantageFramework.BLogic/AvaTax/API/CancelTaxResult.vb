Namespace AvaTax.API

    <Serializable> _
    Public Class CancelTaxResult

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ResultCode As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _TransactionId As String = Nothing
        Private _DocId As String = Nothing
        Private _Messages As AdvantageFramework.AvaTax.API.Message() = Nothing

#End Region

#Region " Properties "

        Public Property ResultCode() As AdvantageFramework.AvaTax.API.SeverityLevel
            Get
                ResultCode = _ResultCode
            End Get
            Set(value As AdvantageFramework.AvaTax.API.SeverityLevel)
                _ResultCode = value
            End Set
        End Property
        Public Property TransactionId() As String
            Get
                TransactionId = _TransactionId
            End Get
            Set(value As String)
                _TransactionId = value
            End Set
        End Property
        Public Property DocId() As String
            Get
                DocId = _DocId
            End Get
            Set(value As String)
                _DocId = value
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