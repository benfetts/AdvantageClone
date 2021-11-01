Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet10
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            HoursAssignedEvent
            HoursUsedNonTask
            HoursAvailable
            HoursAssignedTask
            HoursAppointments
            HoursBalanceAvailable
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _HoursAssignedEvent As Nullable(Of Decimal) = Nothing
        Private _HoursUsedNonTask As Nullable(Of Decimal) = Nothing
        Private _HoursAvailable As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _HoursAppointments As Nullable(Of Decimal) = Nothing
        Private _HoursBalanceAvailable As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property HoursAssignedEvent As Nullable(Of Decimal)
            Get
                HoursAssignedEvent = _HoursAssignedEvent
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAssignedEvent = value
            End Set
        End Property
        Public Property HoursUsedNonTask As Nullable(Of Decimal)
            Get
                HoursUsedNonTask = _HoursUsedNonTask
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursUsedNonTask = value
            End Set
        End Property
        Public Property HoursAvailable As Nullable(Of Decimal)
            Get
                HoursAvailable = _HoursAvailable
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailable = value
            End Set
        End Property
        Public Property HoursAssignedTask As Nullable(Of Decimal)
            Get
                HoursAssignedTask = _HoursAssignedTask
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAssignedTask = value
            End Set
        End Property
        Public Property HoursAppointments As Nullable(Of Decimal)
            Get
                HoursAppointments = _HoursAppointments
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAppointments = value
            End Set
        End Property
        Public Property HoursBalanceAvailable As Nullable(Of Decimal)
            Get
                HoursBalanceAvailable = _HoursBalanceAvailable
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursBalanceAvailable = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace