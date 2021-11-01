Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet5
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            EmployeeDirectHoursGoalPercent
            DayOfYear
            WeekOfYear
            MonthOfYear
            Year
            StandardHoursAvailable
            EmployeeDirectHoursGoalHours
            HoursUsedNonTask
            HoursAvailable
            HoursAssignedTask
            HoursAppointments
            HoursBalanceAvailable
            IsFirstChoice
            IsOverBooked
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _EmployeeDirectHoursGoalPercent As Decimal = Nothing
        Private _DayOfYear As Nullable(Of Date) = Nothing
        Private _WeekOfYear As Nullable(Of Date) = Nothing
        Private _MonthOfYear As Nullable(Of Date) = Nothing
        Private _Year As Nullable(Of Date) = Nothing
        Private _StandardHoursAvailable As Decimal = Nothing
        Private _EmployeeDirectHoursGoalHours As Decimal = Nothing
        Private _HoursUsedNonTask As Decimal = Nothing
        Private _HoursAvailable As Decimal = Nothing
        Private _HoursAssignedTask As Decimal = Nothing
        Private _HoursAppointments As Decimal = Nothing
        Private _HoursBalanceAvailable As Decimal = Nothing
        Private _IsFirstChoice As Short = Nothing
        Private _IsOverBooked As Short = Nothing

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
        Public Property EmployeeDirectHoursGoalPercent As Decimal
            Get
                EmployeeDirectHoursGoalPercent = _EmployeeDirectHoursGoalPercent
            End Get
            Set(value As Decimal)
                _EmployeeDirectHoursGoalPercent = value
            End Set
        End Property
        Public Property DayOfYear As Nullable(Of Date)
            Get
                DayOfYear = _DayOfYear
            End Get
            Set(value As Nullable(Of Date))
                _DayOfYear = value
            End Set
        End Property
        Public Property WeekOfYear As Nullable(Of Date)
            Get
                WeekOfYear = _WeekOfYear
            End Get
            Set(value As Nullable(Of Date))
                _WeekOfYear = value
            End Set
        End Property
        Public Property MonthOfYear As Nullable(Of Date)
            Get
                MonthOfYear = _MonthOfYear
            End Get
            Set(value As Nullable(Of Date))
                _MonthOfYear = value
            End Set
        End Property
        Public Property Year As Nullable(Of Date)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Date))
                _Year = value
            End Set
        End Property
        Public Property StandardHoursAvailable As Decimal
            Get
                StandardHoursAvailable = _StandardHoursAvailable
            End Get
            Set(value As Decimal)
                _StandardHoursAvailable = value
            End Set
        End Property
        Public Property EmployeeDirectHoursGoalHours As Decimal
            Get
                EmployeeDirectHoursGoalHours = _EmployeeDirectHoursGoalHours
            End Get
            Set(value As Decimal)
                _EmployeeDirectHoursGoalHours = value
            End Set
        End Property
        Public Property HoursUsedNonTask As Decimal
            Get
                HoursUsedNonTask = _HoursUsedNonTask
            End Get
            Set(value As Decimal)
                _HoursUsedNonTask = value
            End Set
        End Property
        Public Property HoursAvailable As Decimal
            Get
                HoursAvailable = _HoursAvailable
            End Get
            Set(value As Decimal)
                _HoursAvailable = value
            End Set
        End Property
        Public Property HoursAssignedTask As Decimal
            Get
                HoursAssignedTask = _HoursAssignedTask
            End Get
            Set(value As Decimal)
                _HoursAssignedTask = value
            End Set
        End Property
        Public Property HoursAppointments As Decimal
            Get
                HoursAppointments = _HoursAppointments
            End Get
            Set(value As Decimal)
                _HoursAppointments = value
            End Set
        End Property
        Public Property HoursBalanceAvailable As Decimal
            Get
                HoursBalanceAvailable = _HoursBalanceAvailable
            End Get
            Set(value As Decimal)
                _HoursBalanceAvailable = value
            End Set
        End Property
        Public Property IsFirstChoice As Short
            Get
                IsFirstChoice = _IsFirstChoice
            End Get
            Set(value As Short)
                _IsFirstChoice = value
            End Set
        End Property
        Public Property IsOverBooked As Short
            Get
                IsOverBooked = _IsOverBooked
            End Get
            Set(value As Short)
                _IsOverBooked = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class


End Namespace

