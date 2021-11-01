Namespace BillingCommandCenter.Database.Classes

    <Serializable()>
    Public Class MediaOrder

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderNumber
            LineNumber
            BroadcastYear
            BroadcastMonth
            MediaFrom
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "

        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Nullable(Of Integer) = Nothing
        Private _BroadcastYear As Nullable(Of Short) = Nothing
        Private _BroadcastMonth As Nullable(Of Short) = Nothing
        Private _MediaFrom As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "

        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(value As Integer)
                _OrderNumber = value
            End Set
        End Property
        Public Property LineNumber() As Nullable(Of Integer)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Integer))
                _LineNumber = value
            End Set
        End Property
        Public Property BroadcastYear() As Nullable(Of Short)
            Get
                BroadcastYear = _BroadcastYear
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastYear = value
            End Set
        End Property
        Public Property BroadcastMonth() As Nullable(Of Short)
            Get
                BroadcastMonth = _BroadcastMonth
            End Get
            Set(value As Nullable(Of Short))
                _BroadcastMonth = value
            End Set
        End Property
        Public Property MediaFrom() As String
            Get
                MediaFrom = _MediaFrom
            End Get
            Set(value As String)
                _MediaFrom = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OrderNumber.ToString

        End Function

#End Region

    End Class

End Namespace
