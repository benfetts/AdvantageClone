Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeAlertGroup
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            AlertGroupCode
            IncludeOnSchedule
            AlertGroup
        End Enum

#End Region

#Region " Variables "

        Private _AlertGroupCode As String = Nothing
        Private _IncludeOnSchedule As Nullable(Of Short) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Alert Group")>
        Public Property AlertGroupCode As String
            Get
                AlertGroupCode = _AlertGroupCode
            End Get
            Set(value As String)
                _AlertGroupCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IncludeOnSchedule As Nullable(Of Short)
            Get
                IncludeOnSchedule = _IncludeOnSchedule
            End Get
            Set(value As Nullable(Of Short))
                _IncludeOnSchedule = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(ByVal AlertGroup As AdvantageFramework.Database.Entities.AlertGroup)

            _AlertGroupCode = AlertGroup.Code
            _IncludeOnSchedule = AlertGroup.IncludeOnSchedule

        End Sub
        'Public Overrides Function ValidateEntityProperty(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    ' Objects
        '    Dim ErrorText As String = ""

        '    If PropertyName = AdvantageFramework.Database.Classes.EmployeeAlertGroup.Properties.DepartmentTeamCode.ToString Then

        '        ErrorText = _EmployeeDepartment.ValidateEntityProperty(PropertyName, IsValid, Value)

        '    End If

        '    ValidateEntityProperty = ErrorText

        'End Function

#End Region

    End Class

End Namespace
