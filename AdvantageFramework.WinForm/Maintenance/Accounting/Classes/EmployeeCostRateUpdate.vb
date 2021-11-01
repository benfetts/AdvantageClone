Namespace Maintenance.Accounting.Classes

    <Serializable()>
    Public Class EmployeeCostRateUpdate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
            StartDate
            TerminationDate
            CurrentDepartmentTeamCode
            CurrentDepartmentTeamName
            CurrentAnnualSalary
            CurrentMonthlySalary
            CurrentCostRate
            [From]
            [To]
            DepartmentTeamCode
            DepartmentTeamName
            Hours
            CostRate
            AlternateCostRate
            LastDateFrom
            LastDateTo
            LastAlternateCostRate
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _Name As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _TerminationDate As Nullable(Of Date) = Nothing
        Private _CurrentDepartmentTeamCode As String = Nothing
        Private _CurrentDepartmentTeamName As String = Nothing
        Private _CurrentAnnualSalary As Nullable(Of Decimal) = Nothing
        Private _CurrentMonthlySalary As Nullable(Of Decimal) = Nothing
        Private _CurrentCostRate As Nullable(Of Decimal) = Nothing
        Private _From As Date = Nothing
        Private _To As Date = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamName As String = Nothing
        Private _Hours As Decimal = Nothing
        Private _CostRate As Nullable(Of Decimal) = Nothing
        Private _AlternateCostRate As Nullable(Of Decimal) = Nothing
        Private _LastDateFrom As Nullable(Of Date) = Nothing
        Private _LastDateTo As Nullable(Of Date) = Nothing
        Private _LastAlternateCostRate As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Code() As String
            Get
                Code = _Code
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Name() As String
            Get
                Name = _Name
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Employment Date")>
        Public ReadOnly Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property TerminationDate() As Nullable(Of Date)
            Get
                TerminationDate = _TerminationDate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property CurrentDepartmentTeamCode() As String
            Get
                CurrentDepartmentTeamCode = _CurrentDepartmentTeamCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property CurrentDepartmentTeamName() As String
            Get
                CurrentDepartmentTeamName = _CurrentDepartmentTeamName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public ReadOnly Property CurrentAnnualSalary() As Nullable(Of Decimal)
            Get
                CurrentAnnualSalary = _CurrentAnnualSalary
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public ReadOnly Property CurrentMonthlySalary() As Nullable(Of Decimal)
            Get
                CurrentMonthlySalary = _CurrentMonthlySalary
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public ReadOnly Property CurrentCostRate() As Nullable(Of Decimal)
            Get
                CurrentCostRate = _CurrentCostRate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property From() As Date
            Get
                From = _From
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property [To]() As Date
            Get
                [To] = _To
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property DepartmentTeamCode() As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property DepartmentTeamName() As String
            Get
                DepartmentTeamName = _DepartmentTeamName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public ReadOnly Property Hours() As Decimal
            Get
                Hours = _Hours
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public ReadOnly Property CostRate() As Nullable(Of Decimal)
            Get
                CostRate = _CostRate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Alt Cost Rate", IsReadOnlyColumn:=True)>
        Public ReadOnly Property AlternateCostRate() As Nullable(Of Decimal)
            Get
                AlternateCostRate = _AlternateCostRate
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property LastDateFrom() As Nullable(Of Date)
            Get
                LastDateFrom = _LastDateFrom
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property LastDateTo() As Nullable(Of Date)
            Get
                LastDateTo = _LastDateTo
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Last Alt Cost Rate", IsReadOnlyColumn:=True)>
        Public ReadOnly Property LastAlternateCostRate() As Nullable(Of Decimal)
            Get
                LastAlternateCostRate = _LastAlternateCostRate
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal EmployeeRateHistory As AdvantageFramework.Database.Entities.EmployeeRateHistory, _
                       ByVal StartDate As Date, ByVal EndDate As Date, ByVal Hours As Decimal, ByVal AlternateCostRate As Nullable(Of Decimal))

            _Code = Employee.Code
            _Name = Employee.ToString
            _StartDate = Employee.StartDate
            _TerminationDate = Employee.TerminationDate
            _CurrentDepartmentTeamCode = Employee.DepartmentTeamCode
            _CurrentDepartmentTeamName = If(Employee.DepartmentTeam Is Nothing, "", Employee.DepartmentTeam.Description)
            _CurrentAnnualSalary = Employee.AnnualSalary
            _CurrentMonthlySalary = Employee.MonthlySalary
            _CurrentCostRate = Employee.CostRate
            _From = StartDate
            _To = EndDate
            _DepartmentTeamCode = EmployeeRateHistory.DepartmentTeamCode
            _DepartmentTeamName = If(EmployeeRateHistory.DepartmentTeam Is Nothing, "", EmployeeRateHistory.DepartmentTeam.Description)
            _Hours = Hours
            _CostRate = EmployeeRateHistory.CostRate
            _AlternateCostRate = AlternateCostRate
            _LastDateFrom = Employee.AlternateDateFrom
            _LastDateTo = Employee.AlternateDateFrom
            _LastAlternateCostRate = Employee.AlternateCostRate

        End Sub
        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal StartDate As Date, ByVal EndDate As Date, ByVal Hours As Decimal, ByVal AlternateCostRate As Nullable(Of Decimal))

            _Code = Employee.Code
            _Name = Employee.ToString
            _StartDate = Employee.StartDate
            _TerminationDate = Employee.TerminationDate
            _CurrentDepartmentTeamCode = Employee.DepartmentTeamCode
            _CurrentDepartmentTeamName = If(Employee.DepartmentTeam Is Nothing, "", Employee.DepartmentTeam.Description)
            _CurrentAnnualSalary = Employee.AnnualSalary
            _CurrentMonthlySalary = Employee.MonthlySalary
            _CurrentCostRate = Employee.CostRate
            _From = StartDate
            _To = EndDate
            _DepartmentTeamCode = Employee.DepartmentTeamCode
            _DepartmentTeamName = If(Employee.DepartmentTeam Is Nothing, "", Employee.DepartmentTeam.Description)
            _Hours = Hours
            _CostRate = Employee.CostRate
            _AlternateCostRate = AlternateCostRate
            _LastDateFrom = Employee.AlternateDateFrom
            _LastDateTo = Employee.AlternateDateFrom
            _LastAlternateCostRate = Employee.AlternateCostRate

        End Sub

#End Region

    End Class

End Namespace
