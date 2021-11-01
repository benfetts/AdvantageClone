Namespace Maintenance.Accounting.Classes

    <Serializable()>
    Public Class CostRateETI

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeTimeID
            EmployeeTimeDetailID
            EmployeeCode
            [Date]
            Hours
            Category
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeTimeID As Integer = Nothing
        Private _EmployeeTimeDetailID As Short = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Date As Date = Nothing
        Private _Hours As Decimal = Nothing
        Private _Category As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTimeID As Integer
            Get
                EmployeeTimeID = _EmployeeTimeID
            End Get
            Set(value As Integer)
                _EmployeeTimeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeTimeDetailID As Short
            Get
                EmployeeTimeDetailID = _EmployeeTimeDetailID
            End Get
            Set(value As Short)
                _EmployeeTimeDetailID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property [Date]() As Date
            Get
                [Date] = _Date
            End Get
            Set(value As Date)
                _Date = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Hours As Decimal
            Get
                Hours = _Hours
            End Get
            Set(value As Decimal)
                _Hours = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Category As String
            Get
                Category = _Category
            End Get
            Set(value As String)
                _Category = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
