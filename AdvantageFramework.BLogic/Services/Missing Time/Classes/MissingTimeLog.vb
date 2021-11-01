Namespace Services.MissingTime.Classes

    Public Class MissingTimeLog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            UserCode
            EmployeeCode
            EmployeeName
            [Date]
            Day
            StandardHours
            HoursWorked
            Difference
            WeekStandardHours
            WeekHoursWorked
            WeekDifference
        End Enum

#End Region

#Region " Variables "

        Private _UserCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _Date As Date = Nothing
        Private _Day As String = Nothing
        Private _StandardHours As Decimal = Nothing
        Private _HoursWorked As Decimal = Nothing
        Private _Difference As Decimal = Nothing
        Private _WeekStandardHours As Decimal = Nothing
        Private _WeekHoursWorked As Decimal = Nothing
        Private _WeekDifference As Decimal = Nothing

#End Region

#Region " Properties "

        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(ByVal value As String)
                _UserCode = value
            End Set
        End Property
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        Public Property [Date] As Date
            Get
                [Date] = _Date
            End Get
            Set(ByVal value As Date)
                _Date = value
            End Set
        End Property
        Public Property Day() As String
            Get
                Day = _Day
            End Get
            Set(ByVal value As String)
                _Day = value
            End Set
        End Property
        Public Property StandardHours() As Decimal
            Get
                StandardHours = _StandardHours
            End Get
            Set(ByVal value As Decimal)
                _StandardHours = value
            End Set
        End Property
        Public Property HoursWorked() As Decimal
            Get
                HoursWorked = _HoursWorked
            End Get
            Set(ByVal value As Decimal)
                _HoursWorked = value
            End Set
        End Property
        Public Property Difference() As Decimal
            Get
                Difference = _Difference
            End Get
            Set(ByVal value As Decimal)
                _Difference = value
            End Set
        End Property
        Public Property WeekStandardHours() As Decimal
            Get
                WeekStandardHours = _WeekStandardHours
            End Get
            Set(ByVal value As Decimal)
                _WeekStandardHours = value
            End Set
        End Property
        Public Property WeekHoursWorked() As Decimal
            Get
                WeekHoursWorked = _WeekHoursWorked
            End Get
            Set(ByVal value As Decimal)
                _WeekHoursWorked = value
            End Set
        End Property
        Public Property WeekDifference() As Decimal
            Get
                WeekDifference = _WeekDifference
            End Get
            Set(ByVal value As Decimal)
                _WeekDifference = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal UserCode As String, _
                       ByVal EmployeeCode As String, _
                       ByVal EmployeeName As String, _
                       ByVal [Date] As Date, _
                       ByVal Day As String, _
                       ByVal StandardHours As Decimal, _
                       ByVal HoursWorked As Decimal, _
                       ByVal Difference As Decimal, _
                       ByVal WeekStandardHours As Decimal, _
                       ByVal WeekHoursWorked As Decimal, _
                       ByVal WeekDifference As Decimal)

            _UserCode = UserCode
            _EmployeeCode = EmployeeCode
            _EmployeeName = EmployeeName
            _Date = [Date]
            _Day = Day
            _StandardHours = StandardHours
            _HoursWorked = HoursWorked
            _Difference = Difference
            _WeekStandardHours = WeekStandardHours
            _WeekHoursWorked = WeekHoursWorked
            _WeekDifference = WeekDifference

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.UserCode & ", " & Me.EmployeeCode & ", " & Me.EmployeeName & ", " & _
                       Me.[Date].ToShortDateString & ", " & Me.[Date].DayOfWeek.ToString & ", " & _
                       Me.StandardHours & ", " & Me.HoursWorked & ", " & Me.Difference & ", " & _
                       Me.WeekStandardHours & ", " & Me.WeekHoursWorked & ", " & Me.WeekDifference

        End Function

#End Region

    End Class

End Namespace
