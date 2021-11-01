Namespace Database.Classes

    <Serializable()>
    Public Class AccountExecutive

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            Employee
            IsDefault
            IsInactive
            Terminated
            ManagementLevel
            ManagementLevelID
            AccountExecutive
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _IsDefault As Boolean = Nothing
        Private _IsInactive As Boolean = Nothing
        Private _Terminated As Boolean = Nothing
        Private _ManagementLevel As String = Nothing
        Private _ManagementLevelID As Integer = Nothing
        Private _AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
        Private _OfficeCode As String = Nothing
        Private _OfficeDescription As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Employee() As String
            Get
                Employee = _Employee
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property OfficeDescription() As String
            Get
                OfficeDescription = _OfficeDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDefault() As Boolean
            Get
                IsDefault = _IsDefault
            End Get
            Set(ByVal value As Boolean)
                _IsDefault = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Terminated() As Boolean
            Get
                Terminated = _Terminated
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ManagementLevel() As String
            Get
                ManagementLevel = _ManagementLevel
            End Get
            Set(ByVal value As String)
                _ManagementLevel = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IsInactive() As Boolean
            Get
                IsInactive = _IsInactive
            End Get
            Set(ByVal value As Boolean)
                _IsInactive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ManagementLevelID() As Integer
            Get
                ManagementLevelID = _ManagementLevelID
            End Get
            Set(ByVal value As Integer)
                _ManagementLevelID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive
            Get
                AccountExecutive = _AccountExecutive
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive, ByVal Employee As AdvantageFramework.Database.Core.Employee)

            _EmployeeCode = Employee.Code
            _Employee = Employee.ToString
            _Terminated = If(Employee.TerminationDate Is Nothing, False, True)

            _IsDefault = Convert.ToBoolean(AccountExecutive.IsDefaultAccountExecutive)
            _IsInactive = Convert.ToBoolean(AccountExecutive.IsInactive)
            _AccountExecutive = AccountExecutive

        End Sub
        Public Sub New(ByVal AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive)

            _EmployeeCode = AccountExecutive.EmployeeCode

            If AccountExecutive.Employee IsNot Nothing Then

                _Employee = AccountExecutive.Employee.ToString
                _Terminated = If(AccountExecutive.Employee.TerminationDate Is Nothing, False, True)
                _OfficeCode = AccountExecutive.Employee.OfficeCode

                If AccountExecutive.Employee.Office IsNot Nothing Then

                    _OfficeDescription = AccountExecutive.Employee.Office.Name

                End If

            Else

                _Terminated = False
                _Employee = AccountExecutive.EmployeeCode

            End If

            _IsDefault = Convert.ToBoolean(AccountExecutive.IsDefaultAccountExecutive)
            _IsInactive = Convert.ToBoolean(AccountExecutive.IsInactive)
            _ManagementLevel = If(AccountExecutive.ManagementLevel Is Nothing, "Account Executive", AccountExecutive.ManagementLevel.Description)
            _ManagementLevelID = If(AccountExecutive.ManagementLevelID = 0, 1, AccountExecutive.ManagementLevelID)
            _AccountExecutive = AccountExecutive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function

#End Region

    End Class

End Namespace

