Namespace Database.Entities

    <NotMapped>
    <System.Data.Linq.Mapping.Table(Name:="dbo.MISSING_TIME_DTL")>
    Public Class MissingTimeDetail
        Inherits AdvantageFramework.BaseClasses.EntityBase

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            SupervisorEmployeeCode
            [Date]
            Day
            StartOfWeekDate
            StandardHours
            HoursWorked
            HoursDifference
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = ""
        Private _SupervisorEmployeeCode As String = ""
        Private _Date As System.Nullable(Of DateTime) = "1/1/1900"
        Private _Day As String = ""
        Private _StartOfWeekDate As System.Nullable(Of DateTime) = "1/1/1900"
        Private _StandardHours As System.Nullable(Of Decimal) = 0
        Private _HoursWorked As System.Nullable(Of Decimal) = 0
        Private _HoursDifference As System.Nullable(Of Decimal) = 0

#End Region

#Region " Properties "

		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="EMP_CODE", Storage:="_EmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Employee Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property EmployeeCode() As String
			Get
				EmployeeCode = _EmployeeCode
			End Get
			Set(ByVal value As String)
				_EmployeeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="SUPERVISOR_CODE", Storage:="_SupervisorEmployeeCode", DbType:="varchar"),
		System.ComponentModel.DisplayName("Supervisor Employee Code"),
		System.ComponentModel.DataAnnotations.MaxLength(6)>
		Public Property SupervisorEmployeeCode() As String
			Get
				SupervisorEmployeeCode = _SupervisorEmployeeCode
			End Get
			Set(ByVal value As String)
				_SupervisorEmployeeCode = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="WORKDATE", Storage:="_Date", DbType:="smalldatetime"),
		System.ComponentModel.DisplayName("Date")>
		Public Property [Date]() As System.Nullable(Of DateTime)
			Get
				[Date] = _Date
			End Get
			Set(ByVal value As System.Nullable(Of DateTime))
				_Date = value
			End Set
		End Property
		<System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="DAYOFWEEK", Storage:="_Day", DbType:="varchar"),
		System.ComponentModel.DisplayName("Day"),
		System.ComponentModel.DataAnnotations.MaxLength(3)>
		Public Property Day() As String
            Get
                Day = _Day
            End Get
            Set(ByVal value As String)
                _Day = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="WEEKOFDATE", Storage:="_StartOfWeekDate", DBType:="smalldatetime"), _
        System.ComponentModel.DisplayName("Start Of Week Date")> _
        Public Property StartOfWeekDate() As System.Nullable(Of DateTime)
            Get
                StartOfWeekDate = _StartOfWeekDate
            End Get
            Set(ByVal value As System.Nullable(Of DateTime))
                _StartOfWeekDate = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="STANDARD_HRS", Storage:="_StandardHours", DBType:="decimal"), _
        System.ComponentModel.DisplayName("Standard Hours")> _
        Public Property StandardHours() As System.Nullable(Of Decimal)
            Get
                StandardHours = _StandardHours
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _StandardHours = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="HOURS_WORKED", Storage:="_HoursWorked", DBType:="decimal"), _
        System.ComponentModel.DisplayName("Hours Worked")> _
        Public Property HoursWorked() As System.Nullable(Of Decimal)
            Get
                HoursWorked = _HoursWorked
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _HoursWorked = value
            End Set
        End Property
        <System.Data.Linq.Mapping.Column(UpdateCheck:=System.Data.Linq.Mapping.UpdateCheck.Never, Name:="VARIANCE", Storage:="_HoursDifference", DBType:="decimal"), _
        System.ComponentModel.DisplayName("Hours Difference")> _
        Public Property HoursDifference() As System.Nullable(Of Decimal)
            Get
                HoursDifference = _HoursDifference
            End Get
            Set(ByVal value As System.Nullable(Of Decimal))
                _HoursDifference = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
