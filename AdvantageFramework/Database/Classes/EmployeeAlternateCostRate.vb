Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeAlternateCostRate
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            LastName
            FirstName
            MiddleInitial
            StartDate
            TerminationDate
            AnnualSalary
            MonthlySalary
            CostRate
            HoursUsedForCalculation
            AlternateCostRate
            AlternateDateFrom
            AlternateDateTo
        End Enum

#End Region

#Region " Variables "

        Private _Code As String = Nothing
        Private _LastName As String = Nothing
        Private _FirstName As String = Nothing
        Private _MiddleInitial As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _TerminationDate As Nullable(Of Date) = Nothing
        Private _AnnualSalary As Nullable(Of Decimal) = Nothing
        Private _MonthlySalary As Nullable(Of Decimal) = Nothing
        Private _CostRate As Nullable(Of Decimal) = Nothing
        Private _HoursUsedForCalculation As String = Nothing
        Private _AlternateCostRate As Nullable(Of Decimal) = Nothing
        Private _AlternateDateFrom As Nullable(Of Date) = Nothing
        Private _AlternateDateTo As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property Code() As String
            Get
                Code = _Code
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property FirstName() As String
            Get
                FirstName = _FirstName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property MiddleInitial() As String
            Get
                MiddleInitial = _MiddleInitial
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property LastName() As String
            Get
                LastName = _LastName
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Employment Date")>
        Public ReadOnly Property StartDate() As Nullable(Of Date)
            Get
                StartDate = _StartDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public ReadOnly Property TerminationDate() As Nullable(Of Date)
            Get
                TerminationDate = _TerminationDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property AnnualSalary() As Nullable(Of Decimal)
            Get
                AnnualSalary = _AnnualSalary
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AnnualSalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property MonthlySalary() As Nullable(Of Decimal)
            Get
                MonthlySalary = _MonthlySalary
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _MonthlySalary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=False)>
        Public Property CostRate() As Nullable(Of Decimal)
            Get
                CostRate = _CostRate
            End Get
            Set(value As Nullable(Of Decimal))
                _CostRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, IsReadOnlyColumn:=True)>
        Public Property HoursUsedForCalculation() As String
            Get
                HoursUsedForCalculation = _HoursUsedForCalculation
            End Get
            Set(value As String)
                _HoursUsedForCalculation = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Last Alt Cost Rate", IsReadOnlyColumn:=True)>
        Public Property AlternateCostRate() As Nullable(Of Decimal)
            Get
                AlternateCostRate = _AlternateCostRate
            End Get
            Set(value As Nullable(Of Decimal))
                _AlternateCostRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Last Alt Date From", IsReadOnlyColumn:=True)>
        Public Property AlternateDateFrom() As Nullable(Of Date)
            Get
                AlternateDateFrom = _AlternateDateFrom
            End Get
            Set(value As Nullable(Of Date))
                _AlternateDateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=True, CustomColumnCaption:="Last Alt Date To", IsReadOnlyColumn:=True)>
        Public Property AlternateDateTo() As Nullable(Of Date)
            Get
                AlternateDateTo = _AlternateDateTo
            End Get
            Set(value As Nullable(Of Date))
                _AlternateDateTo = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal Employee As AdvantageFramework.Database.Views.Employee)

            _Code = Employee.Code
            _LastName = Employee.LastName
            _FirstName = Employee.FirstName
            _MiddleInitial = Employee.MiddleInitial
            _StartDate = Employee.StartDate
            _TerminationDate = Employee.TerminationDate
            _AnnualSalary = Employee.AnnualSalary
            _MonthlySalary = Employee.MonthlySalary
            _CostRate = Employee.CostRate
            _AlternateCostRate = Employee.AlternateCostRate
            _AlternateDateFrom = Employee.AlternateDateFrom
            _AlternateDateTo = Employee.AlternateDateTo

        End Sub

#End Region

    End Class

End Namespace


