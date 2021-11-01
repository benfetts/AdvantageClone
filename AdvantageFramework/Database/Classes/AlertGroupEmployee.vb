Namespace Database.Classes

    <Serializable()>
    Public Class AlertGroupEmployee

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertGroupCode
            EmployeeCode
            EmployeeName
            Email
            DefaultRoleCode
            DefaultRoleDescription
            DefaultFunctionCode
            DefaultFunctionDescription
            IncludeOnSchedule
        End Enum

#End Region

#Region " Variables "

        Private _AlertGroupCode As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _Email As String = Nothing
        Private _DefaultRoleCode As String = Nothing
        Private _DefaultRoleDescription As String = Nothing
        Private _DefaultFunctionCode As String = Nothing
        Private _DefaultFunctionDescription As String = Nothing
        Private _IncludeOnSchedule As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property AlertGroupCode() As String
            Get
                AlertGroupCode = _AlertGroupCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Email() As String
            Get
                Email = _Email
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DefaultRoleCode() As String
            Get
                DefaultRoleCode = _DefaultRoleCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DefaultRoleDescription() As String
            Get
                DefaultRoleDescription = _DefaultRoleDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DefaultFunctionCode() As String
            Get
                DefaultFunctionCode = _DefaultFunctionCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property DefaultFunctionDescription() As String
            Get
                DefaultFunctionDescription = _DefaultFunctionDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IncludeOnSchedule() As Boolean
            Get
                IncludeOnSchedule = _IncludeOnSchedule
            End Get
            Set(ByVal value As Boolean)
                _IncludeOnSchedule = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _AlertGroupCode = Nothing
            _EmployeeCode = Employee.Code
            _EmployeeName = Employee.ToString()
            _Email = Employee.Email
            _DefaultFunctionDescription = If(Employee.Function IsNot Nothing, Employee.Function.Description, Nothing)
            _DefaultFunctionCode = Employee.FunctionCode
            _DefaultRoleDescription = If(Employee.Role IsNot Nothing, Employee.Role.Description, Nothing)
            _DefaultRoleCode = Employee.RoleCode
            _IncludeOnSchedule = False

        End Sub
        Public Sub New(ByVal AlertGroup As AdvantageFramework.Database.Entities.AlertGroup, ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _AlertGroupCode = AlertGroup.Code
            _EmployeeCode = Employee.Code
            _EmployeeName = Employee.ToString()
            _Email = Employee.Email
            _DefaultFunctionDescription = If(Employee.Function IsNot Nothing, Employee.Function.Description, Nothing)
            _DefaultFunctionCode = Employee.FunctionCode
            _DefaultRoleDescription = If(Employee.Role IsNot Nothing, Employee.Role.Description, Nothing)
            _DefaultRoleCode = Employee.RoleCode
            _IncludeOnSchedule = Convert.ToBoolean(AlertGroup.IncludeOnSchedule.GetValueOrDefault(0))

        End Sub
        Public Sub New(ByVal AlertGroupCode As String, ByVal EmployeeCode As String, ByVal FirstName As String, ByVal MiddleInitial As String, ByVal LastName As String, ByVal Email As String, _
                       ByVal DefaultFunctionCode As String, ByVal DefaultFunctionDescription As String, ByVal DefaultRoleCode As String, ByVal DefaultRoleDescription As String, ByVal IncludeOnSchedule As Boolean)

            _AlertGroupCode = AlertGroupCode
            _EmployeeCode = EmployeeCode

            If MiddleInitial IsNot Nothing AndAlso MiddleInitial.Trim <> "" Then

                _EmployeeName = FirstName & " " & MiddleInitial & ". " & LastName

            Else

                _EmployeeName = FirstName & " " & LastName

            End If

            _Email = Email
            _DefaultFunctionDescription = DefaultFunctionDescription
            _DefaultFunctionCode = DefaultFunctionCode
            _DefaultRoleDescription = DefaultRoleDescription
            _DefaultRoleCode = DefaultRoleCode
            _IncludeOnSchedule = IncludeOnSchedule

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EmployeeName

        End Function

#End Region

    End Class

End Namespace

