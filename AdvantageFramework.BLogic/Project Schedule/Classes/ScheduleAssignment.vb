Namespace ProjectSchedule.Classes

    <Serializable()>
    Public Class ScheduleAssignment
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Key
            Title
            EmployeeCode
            EmployeeName
            IsManager
        End Enum

#End Region

#Region " Variables "

        Private _Key As String = ""
        Private _Title As String = ""
        Private _EmployeeCode As String = ""
        Private _EmployeeName As String = ""
        Private _IsManager As Boolean = False

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Key As String
            Get
                Key = _Key
            End Get
            Set(value As String)
                _Key = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property Title As String
            Get
                Title = _Title
            End Get
            Set(value As String)
                _Title = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, PropertyType:=BaseClasses.PropertyTypes.EmployeeCode, CustomColumnCaption:="Employee")>
        Public Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsreadOnlyColumn:=True, DefaultColumnType:=BaseClasses.DefaultColumnTypes.EmployeeName)>
        Public Property EmployeeName As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property IsManager As Boolean
            Get
                IsManager = _IsManager
            End Get
            Set(value As Boolean)
                _IsManager = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace