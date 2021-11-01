Namespace Services.QvAAlert.Classes

    <Serializable()>
    Public Class QvAFunction

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FunctionCode As String = Nothing
        Private _FunctionOrderCode As String = Nothing
        Private _FunctionTypeCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _Quoted As Decimal = Nothing
        Private _Actual As Decimal = Nothing
        Private _QvA As Decimal = Nothing
        Private _ThresholdAlert As Integer = Nothing

#End Region

#Region " Properties "

        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionOrderCode() As String
            Get
                FunctionOrderCode = _FunctionOrderCode
            End Get
            Set(ByVal value As String)
                _FunctionOrderCode = value
            End Set
        End Property
        Public Property FunctionTypeCode() As String
            Get
                FunctionTypeCode = _FunctionTypeCode
            End Get
            Set(ByVal value As String)
                _FunctionTypeCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property Quoted() As Decimal
            Get
                Quoted = _Quoted
            End Get
            Set(ByVal value As Decimal)
                _Quoted = value
            End Set
        End Property
        Public Property Actual() As Decimal
            Get
                Actual = _Actual
            End Get
            Set(ByVal value As Decimal)
                _Actual = value
            End Set
        End Property
        Public Property QvA() As Decimal
            Get
                QvA = _QvA
            End Get
            Set(ByVal value As Decimal)
                _QvA = value
            End Set
        End Property
        Public Property ThresholdAlert() As Integer
            Get
                ThresholdAlert = _ThresholdAlert
            End Get
            Set(ByVal value As Integer)
                _ThresholdAlert = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
