Namespace GeneralLedger.ReportWriter.Classes

    Public Class GLData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLACode
            Actual
            Budget1
            Budget2
            Budget3
            Budget4
            PostPeriodCode
            Year
            Month
            OfficeCode
        End Enum

#End Region

#Region " Variables "

        Private _GLACode As String = Nothing
        Private _Actual As Decimal = Nothing
        Private _Budget1 As Decimal = Nothing
        Private _Budget2 As Decimal = Nothing
        Private _Budget3 As Decimal = Nothing
        Private _Budget4 As Decimal = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _Year As Integer = Nothing
        Private _Month As Integer = Nothing
        Private _OfficeCode As String = Nothing

#End Region

#Region " Properties "

        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = value
            End Set
        End Property
        Public Property Actual() As Decimal
            Get
                Actual = _Actual
            End Get
            Set(value As Decimal)
                _Actual = value
            End Set
        End Property
        Public Property Budget1() As Decimal
            Get
                Budget1 = _Budget1
            End Get
            Set(value As Decimal)
                _Budget1 = value
            End Set
        End Property
        Public Property Budget2() As Decimal
            Get
                Budget2 = _Budget2
            End Get
            Set(value As Decimal)
                _Budget2 = value
            End Set
        End Property
        Public Property Budget3() As Decimal
            Get
                Budget3 = _Budget3
            End Get
            Set(value As Decimal)
                _Budget3 = value
            End Set
        End Property
        Public Property Budget4() As Decimal
            Get
                Budget4 = _Budget4
            End Get
            Set(value As Decimal)
                _Budget4 = value
            End Set
        End Property
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        Public Property Year() As Integer
            Get
                Year = _Year
            End Get
            Set(value As Integer)
                _Year = value
            End Set
        End Property
        Public Property Month() As Integer
            Get
                Month = _Month
            End Get
            Set(value As Integer)
                _Month = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace