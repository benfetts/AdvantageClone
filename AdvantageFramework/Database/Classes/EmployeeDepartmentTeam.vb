Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeDepartmentTeam
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            DepartmentTeamCode
            DepartmentTeamName
            [Default]
            EmployeeDepartment
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamName As String = Nothing
        Private _Default As Boolean = Nothing
        Private _EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, PropertyType:=BaseClasses.PropertyTypes.EmployeeCode)>
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode, CustomColumnCaption:="Code")>
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
        Public Property DepartmentTeamName As String
            Get
                DepartmentTeamName = _DepartmentTeamName
            End Get
            Set(value As String)
                _DepartmentTeamName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property [Default] As Boolean
            Get
                [Default] = _Default
            End Get
            Set(value As Boolean)
                _Default = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment, ByVal IsDefault As Boolean)

            _DepartmentTeamCode = EmployeeDepartment.DepartmentTeamCode
            _EmployeeCode = EmployeeDepartment.EmployeeCode
            _DepartmentTeamName = EmployeeDepartment.DepartmentName
            _Default = IsDefault
            _EmployeeDepartment = EmployeeDepartment

        End Sub
        Public Sub SetEmployeeDepartment(ByVal EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment)

            _EmployeeDepartment = EmployeeDepartment

        End Sub
        Public Function GetEmployeeDepartment() As AdvantageFramework.Database.Entities.EmployeeDepartment

            GetEmployeeDepartment = _EmployeeDepartment

        End Function
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            ' Objects
            Dim ErrorText As String = ""

            If PropertyName = AdvantageFramework.Database.Classes.EmployeeDepartmentTeam.Properties.DepartmentTeamCode.ToString Then

                ErrorText = _EmployeeDepartment.ValidateEntityProperty(PropertyName, IsValid, Value)

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
