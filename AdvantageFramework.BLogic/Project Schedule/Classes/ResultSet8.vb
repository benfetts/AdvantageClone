Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet8
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            EmployeeName
            MinimumDate
            MaximumDate
            StandardHoursAvailable
            HoursOff
            AppointmentHours
            AdjustedHoursAssignedTask
            AdjustedHoursAssignedTask_OTHER
            Variance
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _MinimumDate As Nullable(Of DateTime) = Nothing
        Private _MaximumDate As Nullable(Of DateTime) = Nothing
        Private _StandardHoursAvailable As Nullable(Of Decimal) = Nothing
        Private _HoursOff As Nullable(Of Decimal) = Nothing
        Private _AppointmentHours As Nullable(Of Decimal) = Nothing
        Private _AdjustedHoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _AdjustedHoursAssignedTask_OTHER As Nullable(Of Decimal) = Nothing
        Private _Variance As Nullable(Of Decimal) = Nothing

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
        Public Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        Public Property MinimumDate As Nullable(Of DateTime)
            Get
                MinimumDate = _MinimumDate
            End Get
            Set(value As Nullable(Of DateTime))
                _MinimumDate = value
            End Set
        End Property
        Public Property MaximumDate As Nullable(Of DateTime)
            Get
                MaximumDate = _MaximumDate
            End Get
            Set(value As Nullable(Of DateTime))
                _MaximumDate = value
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
        Public Property HoursOff As Nullable(Of Decimal)
            Get
                HoursOff = _HoursOff
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursOff = value
            End Set
        End Property
        Public Property AppointmentHours As Nullable(Of Decimal)
            Get
                AppointmentHours = _AppointmentHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AppointmentHours = value
            End Set
        End Property
        Public Property AdjustedHoursAssignedTask As Nullable(Of Decimal)
            Get
                AdjustedHoursAssignedTask = _AdjustedHoursAssignedTask
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustedHoursAssignedTask = value
            End Set
        End Property
        Public Property AdjustedHoursAssignedTask_OTHER As Nullable(Of Decimal)
            Get
                AdjustedHoursAssignedTask_OTHER = _AdjustedHoursAssignedTask_OTHER
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustedHoursAssignedTask_OTHER = value
            End Set
        End Property
        Public Property Variance As Nullable(Of Decimal)
            Get
                Variance = _Variance
            End Get
            Set(value As Nullable(Of Decimal))
                _Variance = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace