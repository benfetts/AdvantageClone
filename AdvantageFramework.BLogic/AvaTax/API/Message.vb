Namespace AvaTax.API

    <Serializable> _
    Public Class Message

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Summary As String = Nothing
        Private _Details As String = Nothing
        Private _RefersTo As String = Nothing
        Private _Severity As AdvantageFramework.AvaTax.API.SeverityLevel = Nothing
        Private _Source As String = Nothing

#End Region

#Region " Properties "

        Public Property Summary() As String
            Get
                Summary = _Summary
            End Get
            Set(value As String)
                _Summary = value
            End Set
        End Property
        Public Property Details() As String
            Get
                Details = _Details
            End Get
            Set(value As String)
                _Details = value
            End Set
        End Property
        Public Property RefersTo() As String
            Get
                RefersTo = _RefersTo
            End Get
            Set(value As String)
                _RefersTo = value
            End Set
        End Property
        Public Property Severity() As AdvantageFramework.AvaTax.API.SeverityLevel
            Get
                Severity = _Severity
            End Get
            Set(value As AdvantageFramework.AvaTax.API.SeverityLevel)
                _Severity = value
            End Set
        End Property
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set(value As String)
                _Source = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace