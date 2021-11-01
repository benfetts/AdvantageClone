Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeTimeApproval
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Employee
            EmployeeAccountNumber
            EmployeeStatus
            IsEmployeeFreelance
            OfficeCode
            OfficeName
            DepartmentTeamCode
            DepartmentTeamName
            SupervisorCode
            Supervisor
            TimesheetDate
            TimesheetStartedDate
            TimesheetEndedDate
            IndirectHours
            DirectHours
            TotalHours
            TotalHoursForWeek
            StandardHours
            Status
            Missing
            ApprovalDate
            ApprovalNote
            ApprovedBy
            IsHoliday
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _EmployeeCode As String = ""
        Private _Employee As String = ""
        Private _EmployeeAccountNumber As String = ""
        Private _EmployeeStatus As String = ""
        Private _IsEmployeeFreelance As String = ""
        Private _OfficeCode As String = ""
        Private _OfficeName As String = ""
        Private _DepartmentTeamCode As String = ""
        Private _DepartmentTeamName As String = ""
        Private _SupervisorCode As String = ""
        Private _Supervisor As String = ""
        Private _TimesheetDate As DateTime = Nothing
        Private _TimesheetStartedDate As System.Nullable(Of DateTime) = Nothing
        Private _TimesheetEndedDate As System.Nullable(Of DateTime) = Nothing
        Private _IndirectHours As System.Nullable(Of Decimal) = Nothing
        Private _DirectHours As System.Nullable(Of Decimal) = Nothing
        Private _TotalHours As System.Nullable(Of Decimal) = Nothing
        Private _TotalHoursForWeek As System.Nullable(Of Decimal) = Nothing
        Private _StandardHours As System.Nullable(Of Decimal) = Nothing
        Private _Status As String = ""
        Private _Missing As String = ""
        Private _ApprovalDate As System.Nullable(Of DateTime) = Nothing
        Private _ApprovalNote As String = ""
        Private _ApprovedBy As String = ""
        Private _IsHoliday As String = ""

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(value As String)
                _Employee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeAccountNumber() As String
            Get
                EmployeeAccountNumber = _EmployeeAccountNumber
            End Get
            Set(value As String)
                _EmployeeAccountNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeStatus() As String
            Get
                EmployeeStatus = _EmployeeStatus
            End Get
            Set(value As String)
                _EmployeeStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsEmployeeFreelance() As String
            Get
                IsEmployeeFreelance = _IsEmployeeFreelance
            End Get
            Set(ByVal value As String)
                _IsEmployeeFreelance = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeName() As String
            Get
                OfficeName = _OfficeName
            End Get
            Set(value As String)
                _OfficeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DepartmentTeamName() As String
            Get
                DepartmentTeamName = _DepartmentTeamName
            End Get
            Set(value As String)
                _DepartmentTeamName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SupervisorCode() As String
            Get
                SupervisorCode = _SupervisorCode
            End Get
            Set(value As String)
                _SupervisorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Supervisor() As String
            Get
                Supervisor = _Supervisor
            End Get
            Set(value As String)
                _Supervisor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimesheetDate() As DateTime
            Get
                TimesheetDate = _TimesheetDate
            End Get
            Set(value As DateTime)
                _TimesheetDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimesheetStartedDate() As System.Nullable(Of DateTime)
            Get
                TimesheetStartedDate = _TimesheetStartedDate
            End Get
            Set(value As System.Nullable(Of DateTime))
                _TimesheetStartedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimesheetEndedDate() As System.Nullable(Of DateTime)
            Get
                TimesheetEndedDate = _TimesheetEndedDate
            End Get
            Set(value As System.Nullable(Of DateTime))
                _TimesheetEndedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IndirectHours() As System.Nullable(Of Decimal)
            Get
                IndirectHours = _IndirectHours
            End Get
            Set(value As System.Nullable(Of Decimal))
                _IndirectHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DirectHours() As System.Nullable(Of Decimal)
            Get
                DirectHours = _DirectHours
            End Get
            Set(value As System.Nullable(Of Decimal))
                _DirectHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHours() As System.Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As System.Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TotalHoursForWeek() As System.Nullable(Of Decimal)
            Get
                TotalHoursForWeek = _TotalHoursForWeek
            End Get
            Set(value As System.Nullable(Of Decimal))
                _TotalHoursForWeek = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StandardHours() As System.Nullable(Of Decimal)
            Get
                StandardHours = _StandardHours
            End Get
            Set(value As System.Nullable(Of Decimal))
                _StandardHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Missing() As String
            Get
                Missing = _Missing
            End Get
            Set(value As String)
                _Missing = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalDate() As System.Nullable(Of DateTime)
            Get
                ApprovalDate = _ApprovalDate
            End Get
            Set(value As System.Nullable(Of DateTime))
                _ApprovalDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovalNote() As String
            Get
                ApprovalNote = _ApprovalNote
            End Get
            Set(value As String)
                _ApprovalNote = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ApprovedBy() As String
            Get
                ApprovedBy = _ApprovedBy
            End Get
            Set(value As String)
                _ApprovedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsHoliday() As String
            Get
                IsHoliday = _IsHoliday
            End Get
            Set(value As String)
                _IsHoliday = value
            End Set
        End Property

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
