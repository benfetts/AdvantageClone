Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet7
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TotalJobDue
            StandardHoursAvailable
            AppointmentHours
            HoursOff
            HoursAssignedTask
            ShowUnassigned
        End Enum

#End Region

#Region " Variables "

        Private _TotalJobDue As Integer = Nothing
        Private _StandardHoursAvailable As Nullable(Of Decimal) = Nothing
        Private _AppointmentHours As Nullable(Of Decimal) = Nothing
        Private _HoursOff As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _ShowUnassigned As Short = Nothing

#End Region

#Region " Properties "

        Public Property TotalJobDue As Integer
            Get
                TotalJobDue = _TotalJobDue
            End Get
            Set(value As Integer)
                _TotalJobDue = value
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
        Public Property AppointmentHours As Nullable(Of Decimal)
            Get
                AppointmentHours = _AppointmentHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AppointmentHours = value
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
        Public Property HoursAssignedTask As Nullable(Of Decimal)
            Get
                HoursAssignedTask = _HoursAssignedTask
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAssignedTask = value
            End Set
        End Property
        Public Property ShowUnassigned As Short
            Get
                ShowUnassigned = _ShowUnassigned
            End Get
            Set(value As Short)
                _ShowUnassigned = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class


End Namespace

