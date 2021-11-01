Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet1
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            StartDayOfWeek
            EmployeeStartTime
            EmployeeEndTime
            EmployeeDirectHoursGoalPercent
            EmployeeDate
            DayOfWeek
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
            HoursAssignedEvent
            HoursBalanceAvailable
            Note
            IsFullDayOff
            IsFirstChoice
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EmployeeCode As String = Nothing
        Private _StartDayOfWeek As String = Nothing
        Private _EmployeeStartTime As Nullable(Of Date) = Nothing
        Private _EmployeeEndTime As Nullable(Of Date) = Nothing
        Private _EmployeeDirectHoursGoalPercent As Nullable(Of Decimal) = Nothing
        Private _EmployeeDate As Nullable(Of Date) = Nothing
        Private _DayOfWeek As Nullable(Of Integer) = Nothing
        Private _DayOfYear As Nullable(Of Integer) = Nothing
        Private _WeekOfYear As Nullable(Of Date) = Nothing
        Private _MonthOfYear As Nullable(Of Integer) = Nothing
        Private _Year As Nullable(Of Integer) = Nothing
        Private _StandardHoursAvailable As Nullable(Of Decimal) = Nothing
        Private _EmployeeDirectHoursGoalHours As Nullable(Of Decimal) = Nothing
        Private _HoursUsedNonTask As Nullable(Of Decimal) = Nothing
        Private _HoursAvailable As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _HoursAppointments As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedEvent As Nullable(Of Decimal) = Nothing
        Private _HoursBalanceAvailable As Nullable(Of Decimal) = Nothing
        Private _Note As String = Nothing
        Private _IsFullDayOff As Nullable(Of Short) = Nothing
        Private _IsFirstChoice As Integer = Nothing

#End Region

#Region " Properties "

        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property StartDayOfWeek As String
            Get
                StartDayOfWeek = _StartDayOfWeek
            End Get
            Set(value As String)
                _StartDayOfWeek = value
            End Set
        End Property
        Public Property EmployeeStartTime As Nullable(Of Date)
            Get
                EmployeeStartTime = _EmployeeStartTime
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeStartTime = value
            End Set
        End Property
        Public Property EmployeeEndTime As Nullable(Of Date)
            Get
                EmployeeEndTime = _EmployeeEndTime
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeEndTime = value
            End Set
        End Property
        Public Property EmployeeDirectHoursGoalPercent As Nullable(Of Decimal)
            Get
                EmployeeDirectHoursGoalPercent = _EmployeeDirectHoursGoalPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeDirectHoursGoalPercent = value
            End Set
        End Property
        Public Property EmployeeDate As Nullable(Of Date)
            Get
                EmployeeDate = _EmployeeDate
            End Get
            Set(value As Nullable(Of Date))
                _EmployeeDate = value
            End Set
        End Property
        Public Property DayOfWeek As Nullable(Of Integer)
            Get
                DayOfWeek = _DayOfWeek
            End Get
            Set(value As Nullable(Of Integer))
                _DayOfWeek = value
            End Set
        End Property
        Public Property DayOfYear As Nullable(Of Integer)
            Get
                DayOfYear = _DayOfYear
            End Get
            Set(value As Nullable(Of Integer))
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
        Public Property MonthOfYear As Nullable(Of Integer)
            Get
                MonthOfYear = _MonthOfYear
            End Get
            Set(value As Nullable(Of Integer))
                _MonthOfYear = value
            End Set
        End Property
        Public Property Year As Nullable(Of Integer)
            Get
                Year = _Year
            End Get
            Set(value As Nullable(Of Integer))
                _Year = value
            End Set
        End Property
        Public Property StandardHoursAvailable As Nullable(Of Decimal)
            Get
                StandardHoursAvailable = _StandardHoursAvailable
            End Get
            Set(value As Nullable(Of Decimal))
                _StandardHoursAvailable = value
            End Set
        End Property
        Public Property EmployeeDirectHoursGoalHours As Nullable(Of Decimal)
            Get
                EmployeeDirectHoursGoalHours = _EmployeeDirectHoursGoalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeDirectHoursGoalHours = value
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
        Public Property HoursAssignedEvent As Nullable(Of Decimal)
            Get
                HoursAssignedEvent = _HoursAssignedEvent
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAssignedEvent = value
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
        Public Property Note As String
            Get
                Note = _Note
            End Get
            Set(value As String)
                _Note = value
            End Set
        End Property
        Public Property IsFullDayOff As Nullable(Of Short)
            Get
                IsFullDayOff = _IsFullDayOff
            End Get
            Set(value As Nullable(Of Short))
                _IsFullDayOff = value
            End Set
        End Property
        Public Property IsFirstChoice As Integer
            Get
                IsFirstChoice = _IsFirstChoice
            End Get
            Set(value As Integer)
                _IsFirstChoice = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class


End Namespace

