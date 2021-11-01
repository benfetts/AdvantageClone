Namespace Reporting.Database.Classes

    <Serializable>
    Public Class EmployeeInOutBoard

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Employee
            EmployeeFirstName
            EmployeeLastName
            EmployeeTitle
            IsEmployeeFreelance
            IsActiveFreelance
            OfficeCode
            Office
            DepartmentTeamCode
            DepartmentTeam
            SupervisorCode
            Supervisor
            DefaultRoleCode
            DefaultRole
            EmployeeStatus
            Status
            InOutDate
            InOutTime
            Reason
            ExpectedReturn
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of Integer) = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _EmployeeTitle As String = Nothing
        Private _IsEmployeeFreelance As String = Nothing
        Private _IsActiveFreelance As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _Office As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeam As String = Nothing
        Private _SupervisorCode As String = Nothing
        Private _Supervisor As String = Nothing
        Private _DefaultRoleCode As String = Nothing
        Private _DefaultRole As String = Nothing
        Private _EmployeeStatus As String = Nothing
        Private _Status As String = Nothing
        Private _InOutDate As Nullable(Of DateTime) = Nothing
        Private _InOutTime As Nullable(Of DateTime) = Nothing
        Private _Reason As String = Nothing
        Private _ExpectedReturn As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of Integer)
            Get
                ID = _ID
            End Get
            Set(value As Nullable(Of Integer))
                _ID = value
            End Set
        End Property
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        Public Property Employee() As String
            Get
                Employee = _Employee
            End Get
            Set(value As String)
                _Employee = value
            End Set
        End Property
        Public Property EmployeeFirstName() As String
            Get
                EmployeeFirstName = _EmployeeFirstName
            End Get
            Set(value As String)
                _EmployeeFirstName = value
            End Set
        End Property
        Public Property EmployeeLastName() As String
            Get
                EmployeeLastName = _EmployeeLastName
            End Get
            Set(value As String)
                _EmployeeLastName = value
            End Set
        End Property
        Public Property EmployeeTitle() As String
            Get
                EmployeeTitle = _EmployeeTitle
            End Get
            Set(value As String)
                _EmployeeTitle = value
            End Set
        End Property
        Public Property IsEmployeeFreelance() As String
            Get
                IsEmployeeFreelance = _IsEmployeeFreelance
            End Get
            Set(value As String)
                _IsEmployeeFreelance = value
            End Set
        End Property
        Public Property IsActiveFreelance() As String
            Get
                IsActiveFreelance = _IsActiveFreelance
            End Get
            Set(value As String)
                _IsActiveFreelance = value
            End Set
        End Property
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        Public Property Office() As String
            Get
                Office = _Office
            End Get
            Set(value As String)
                _Office = value
            End Set
        End Property
        Public Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        Public Property DepartmentTeam() As String
            Get
                DepartmentTeam = _DepartmentTeam
            End Get
            Set(value As String)
                _DepartmentTeam = value
            End Set
        End Property
        Public Property SupervisorCode() As String
            Get
                SupervisorCode = _SupervisorCode
            End Get
            Set(ByVal value As String)
                _SupervisorCode = value
            End Set
        End Property
        Public Property Supervisor() As String
            Get
                Supervisor = _Supervisor
            End Get
            Set(ByVal value As String)
                _Supervisor = value
            End Set
        End Property
        Public Property DefaultRoleCode() As String
            Get
                DefaultRoleCode = _DefaultRoleCode
            End Get
            Set(ByVal value As String)
                _DefaultRoleCode = value
            End Set
        End Property
        Public Property DefaultRole() As String
            Get
                DefaultRole = _DefaultRole
            End Get
            Set(ByVal value As String)
                _DefaultRole = value
            End Set
        End Property
        Public Property EmployeeStatus() As String
            Get
                EmployeeStatus = _EmployeeStatus
            End Get
            Set(ByVal value As String)
                _EmployeeStatus = value
            End Set
        End Property
        Public Property Status() As String
            Get
                Status = _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property InOutDate() As Nullable(Of DateTime)
            Get
                InOutDate = _InOutDate
            End Get
            Set(value As Nullable(Of DateTime))
                _InOutDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public Property InOutTime() As Nullable(Of DateTime)
            Get
                InOutTime = _InOutTime
            End Get
            Set(value As Nullable(Of DateTime))
                _InOutTime = value
            End Set
        End Property
        Public Property Reason() As String
            Get
                Reason = _Reason
            End Get
            Set(ByVal value As String)
                _Reason = value
            End Set
        End Property
        Public Property ExpectedReturn() As Nullable(Of Date)
            Get
                ExpectedReturn = _ExpectedReturn
            End Get
            Set(value As Nullable(Of Date))
                _ExpectedReturn = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
