Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ResultSet6
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobNumber
            JobComponentNumber
            FunctionCode
            TaskDescription
            JobComponentDescription
            TaskStartDate
            JobRevisedDate
            EmployeeCode
            JobDescription
            OfficeCode
            DepartmentTeamCode
            ClientCode
            DivisionCode
            ProductCode
            Sort
            JobHours
            SequenceNumber
            EmployeeName
            IsEventTask
            TaskTotalWorkingDays
            HoursPerDay
            AdjustedJobHours
            RecType
            NonTaskID
            HoursUsedNonTask
            HoursAvailable
            HoursAssignedTask
            HoursAssignedEvent
            TotalHoursAssigned
            HoursBalanceAvailable
            Variance
            StandardHoursAvailable
            RedFlag
            HoursPerDayWithAssignment
            AdjustedJobHoursWithAssignment
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _TaskDescription As String = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _TaskStartDate As Nullable(Of DateTime) = Nothing
        Private _JobRevisedDate As Nullable(Of DateTime) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _JobDescription As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _Sort As Nullable(Of DateTime) = Nothing
        Private _JobHours As Nullable(Of Decimal) = Nothing
        Private _SequenceNumber As Nullable(Of Short) = Nothing
        Private _EmployeeName As String = Nothing
        Private _IsEventTask As Nullable(Of Short) = Nothing
        Private _TaskTotalWorkingDays As Nullable(Of Integer) = Nothing
        Private _HoursPerDay As Nullable(Of Decimal) = Nothing
        Private _AdjustedJobHours As Nullable(Of Decimal) = Nothing
        Private _RecType As String = Nothing
        Private _NonTaskID As Nullable(Of Short) = Nothing
        Private _HoursUsedNonTask As Nullable(Of Decimal) = Nothing
        Private _HoursAvailable As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedTask As Nullable(Of Decimal) = Nothing
        Private _HoursAssignedEvent As Nullable(Of Decimal) = Nothing
        Private _TotalHoursAssigned As Nullable(Of Decimal) = Nothing
        Private _HoursBalanceAvailable As Nullable(Of Decimal) = Nothing
        Private _Variance As Nullable(Of Decimal) = Nothing
        Private _StandardHoursAvailable As Nullable(Of Decimal) = Nothing
        Private _RedFlag As Nullable(Of Integer) = Nothing
        Private _HoursPerDayWithAssignment As Nullable(Of Decimal) = Nothing
        Private _AdjustedJobHoursWithAssignment As Nullable(Of Decimal) = Nothing

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
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobComponentNumber As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property TaskDescription As String
            Get
                TaskDescription = _TaskDescription
            End Get
            Set(value As String)
                _TaskDescription = value
            End Set
        End Property
        Public Property JobComponentDescription As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        Public Property TaskStartDate As Nullable(Of DateTime)
            Get
                TaskStartDate = _TaskStartDate
            End Get
            Set(value As Nullable(Of DateTime))
                _TaskStartDate = value
            End Set
        End Property
        Public Property JobRevisedDate As Nullable(Of DateTime)
            Get
                JobRevisedDate = _JobRevisedDate
            End Get
            Set(value As Nullable(Of DateTime))
                _JobRevisedDate = value
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
        Public Property JobDescription As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
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
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public Property Sort As Nullable(Of DateTime)
            Get
                Sort = _Sort
            End Get
            Set(value As Nullable(Of DateTime))
                _Sort = value
            End Set
        End Property
        Public Property JobHours As Nullable(Of Decimal)
            Get
                JobHours = _JobHours
            End Get
            Set(value As Nullable(Of Decimal))
                _JobHours = value
            End Set
        End Property
        Public Property SequenceNumber As Nullable(Of Short)
            Get
                SequenceNumber = _SequenceNumber
            End Get
            Set(value As Nullable(Of Short))
                _SequenceNumber = value
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
        Public Property IsEventTask As Nullable(Of Short)
            Get
                IsEventTask = _IsEventTask
            End Get
            Set(value As Nullable(Of Short))
                _IsEventTask = value
            End Set
        End Property
        Public Property TaskTotalWorkingDays As Nullable(Of Integer)
            Get
                TaskTotalWorkingDays = _TaskTotalWorkingDays
            End Get
            Set(value As Nullable(Of Integer))
                _TaskTotalWorkingDays = value
            End Set
        End Property
        Public Property HoursPerDay As Nullable(Of Decimal)
            Get
                HoursPerDay = _HoursPerDay
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPerDay = value
            End Set
        End Property
        Public Property AdjustedJobHours As Nullable(Of Decimal)
            Get
                AdjustedJobHours = _AdjustedJobHours
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustedJobHours = value
            End Set
        End Property
        Public Property RecType As String
            Get
                RecType = _RecType
            End Get
            Set(value As String)
                _RecType = value
            End Set
        End Property
        Public Property NonTaskID As Nullable(Of Short)
            Get
                NonTaskID = _NonTaskID
            End Get
            Set(value As Nullable(Of Short))
                _NonTaskID = value
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
        Public Property HoursAssignedEvent As Nullable(Of Decimal)
            Get
                HoursAssignedEvent = _HoursAssignedEvent
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAssignedEvent = value
            End Set
        End Property
        Public Property TotalHoursAssigned As Nullable(Of Decimal)
            Get
                TotalHoursAssigned = _TotalHoursAssigned
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalHoursAssigned = value
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
        Public Property Variance As Nullable(Of Decimal)
            Get
                Variance = _Variance
            End Get
            Set(value As Nullable(Of Decimal))
                _Variance = value
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
        Public Property RedFlag As Nullable(Of Integer)
            Get
                RedFlag = _RedFlag
            End Get
            Set(value As Nullable(Of Integer))
                _RedFlag = value
            End Set
        End Property
        Public Property HoursPerDayWithAssignment As Nullable(Of Decimal)
            Get
                HoursPerDayWithAssignment = _HoursPerDayWithAssignment
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPerDayWithAssignment = value
            End Set
        End Property
        Public Property AdjustedJobHoursWithAssignment As Nullable(Of Decimal)
            Get
                AdjustedJobHoursWithAssignment = _AdjustedJobHoursWithAssignment
            End Get
            Set(value As Nullable(Of Decimal))
                _AdjustedJobHoursWithAssignment = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace