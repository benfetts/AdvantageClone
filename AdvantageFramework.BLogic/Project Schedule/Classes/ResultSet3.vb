Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet3
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            EmployeeDirectHoursGoalPercent
            StandardHoursAvailable
            EmployeeDirectHoursGoalHours
            HoursAssignedTask
            HoursAppointments
            HoursUsedNonTask
            HoursAvailable
            HoursBalanceAvailable
            PercentWorked
            OfficeCode
            OfficeName
            EmployeeFirstName
            EmployeeMiddleInitial
            EmployeeLastName
            DepartmentTeamCode
            DepartmentTeamDescription
            EmployeeName
            IsFirstChoice
            EmployeeEndTime
            EmployeeStartTime
            EmployeeSeniority
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _EmployeeDirectHoursGoalPercent As Nullable(Of Decimal) = Nothing
        Private _StandardHoursAvailable As Nullable(Of Decimal) = Nothing
        Private _EmployeeDirectHoursGoalHours As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _HoursAppointments As Nullable(Of Decimal) = Nothing
        Private _HoursUsedNonTask As Nullable(Of Decimal) = Nothing
        Private _HoursAvailable As Nullable(Of Decimal) = Nothing
        Private _HoursBalanceAvailable As Nullable(Of Decimal) = Nothing
        Private _PercentWorked As Nullable(Of Decimal) = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeName As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeMiddleInitial As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _IsFirstChoice As Short = Nothing
        Private _EmployeeEndTime As Nullable(Of DateTime) = Nothing
        Private _EmployeeStartTime As Nullable(Of DateTime) = Nothing
        Private _EmployeeSeniority As Short = Nothing
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
        Public Property EmployeeDirectHoursGoalPercent As Nullable(Of Decimal)
            Get
                EmployeeDirectHoursGoalPercent = _EmployeeDirectHoursGoalPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _EmployeeDirectHoursGoalPercent = value
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
        Public Property HoursBalanceAvailable As Nullable(Of Decimal)
            Get
                HoursBalanceAvailable = _HoursBalanceAvailable
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursBalanceAvailable = value
            End Set
        End Property
        Public Property PercentWorked As Nullable(Of Decimal)
            Get
                PercentWorked = _PercentWorked
            End Get
            Set(value As Nullable(Of Decimal))
                _PercentWorked = value
            End Set
        End Property
        Public Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property OfficeName As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        Public Property EmployeeFirstName As String
            Get
                EmployeeFirstName = _EmployeeFirstName
            End Get
            Set(value As String)
                _EmployeeFirstName = value
            End Set
        End Property
        Public Property EmployeeMiddleInitial As String
            Get
                EmployeeMiddleInitial = _EmployeeMiddleInitial
            End Get
            Set(value As String)
                _EmployeeMiddleInitial = value
            End Set
        End Property
        Public Property EmployeeLastName As String
            Get
                EmployeeLastName = _EmployeeLastName
            End Get
            Set(value As String)
                _EmployeeLastName = value
            End Set
        End Property
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        Public Property DepartmentTeamDescription As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = value
            End Set
        End Property
        Public Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
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
        Public Property EmployeeEndTime As Nullable(Of DateTime)
            Get
                EmployeeEndTime = _EmployeeEndTime
            End Get
            Set(value As Nullable(Of DateTime))
                _EmployeeEndTime = value
            End Set
        End Property
        Public Property EmployeeStartTime As Nullable(Of DateTime)
            Get
                EmployeeStartTime = _EmployeeStartTime
            End Get
            Set(value As Nullable(Of DateTime))
                _EmployeeStartTime = value
            End Set
        End Property
        Public Property EmployeeSeniority As Short
            Get
                EmployeeSeniority = _EmployeeSeniority
            End Get
            Set(value As Short)
                _EmployeeSeniority = value
            End Set
        End Property


#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace