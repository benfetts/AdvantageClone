Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeRole
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeCode
            RoleCode
            [Default]
        End Enum

#End Region

#Region " Variables "

        Private _EmployeeCode As String = Nothing
        Private _RoleCode As String = Nothing
        Private _RoleDescription As String = Nothing
        Private _Default As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Code", PropertyType:=BaseClasses.PropertyTypes.RoleCode)>
        Public Property RoleCode As String
            Get
                RoleCode = _RoleCode
            End Get
            Set(value As String)
                _RoleCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
        Public Property RoleDescription As String
            Get
                RoleDescription = _RoleDescription
            End Get
            Set(value As String)
                _RoleDescription = value
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
        'Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    ' Objects
        '    Dim ErrorText As String = ""

        '    If PropertyName = AdvantageFramework.Database.Classes.EmployeeRole.Properties.DepartmentTeamCode.ToString Then

        '        ErrorText = _EmployeeDepartment.ValidateEntityProperty(PropertyName, IsValid, Value)

        '    End If

        '    ValidateEntityProperty = ErrorText

        'End Function

#End Region

    End Class

End Namespace
