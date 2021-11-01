Namespace Database.Classes

    <Serializable()>
    Public Class EmployeeTimesheet
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            JobCompNumber
            JobCompID
            JobCompDescription
            FunctionCode
            FunctionDescription
            DepartmentTeamCode
            DepartmentTeamDescription
            Day1Hours
            Day1Comments
            Day2Hours
            Day2Comments
            Day3Hours
            Day3Comments
            Day4Hours
            Day4Comments
            Day5Hours
            Day5Comments
            Day6Hours
            Day6Comments
            Day7Hours
            Day7Comments
            TotalHours
            AllowEdit
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobCompNumber As Nullable(Of Short) = Nothing
        Private _JobCompID As Nullable(Of Integer) = Nothing
        Private _JobCompDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _DepartmentTeamCode As String = Nothing
        Private _DepartmentTeamDescription As String = Nothing
        Private _Day1Hours As Nullable(Of Decimal) = Nothing
        Private _Day1Comments As String = Nothing
        Private _Day2Hours As Nullable(Of Decimal) = Nothing
        Private _Day2Comments As String = Nothing
        Private _Day3Hours As Nullable(Of Decimal) = Nothing
        Private _Day3Comments As String = Nothing
        Private _Day4Hours As Nullable(Of Decimal) = Nothing
        Private _Day4Comments As String = Nothing
        Private _Day5Hours As Nullable(Of Decimal) = Nothing
        Private _Day5Comments As String = Nothing
        Private _Day6Hours As Nullable(Of Decimal) = Nothing
        Private _Day6Comments As String = Nothing
        Private _Day7Hours As Nullable(Of Decimal) = Nothing
        Private _Day7Comments As String = Nothing
        Private _TotalHours As Nullable(Of Decimal) = Nothing
        Private _AllowEdit As Nullable(Of Boolean) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ClientName As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DivisionName As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ProductName As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job", PropertyType:=BaseClasses.PropertyTypes.JobNumber)>
        Public Property JobNumber As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property JobDescription As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property JobCompNumber As Nullable(Of Short)
            Get
                JobCompNumber = _JobCompNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobCompNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Job Comp", PropertyType:=BaseClasses.PropertyTypes.JobComponentID)>
        Public Property JobCompID As Nullable(Of Integer)
            Get
                JobCompID = _JobCompID
            End Get
            Set(value As Nullable(Of Integer))
                _JobCompID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property JobCompDescription As String
            Get
                JobCompDescription = _JobCompDescription
            End Get
            Set(value As String)
                _JobCompDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Function", PropertyType:=BaseClasses.PropertyTypes.FunctionCode)>
        Public Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property FunctionDescription As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept / Team", PropertyType:=BaseClasses.PropertyTypes.DepartmentTeamCode)>
        Public Property DepartmentTeamCode As String
            Get
                DepartmentTeamCode = _DepartmentTeamCode
            End Get
            Set(value As String)
                _DepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Dept / Team Description", IsReadOnlyColumn:=True)>
        Public Property DepartmentTeamDescription As String
            Get
                DepartmentTeamDescription = _DepartmentTeamDescription
            End Get
            Set(value As String)
                _DepartmentTeamDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day1Hours As Nullable(Of Decimal)
            Get
                Day1Hours = _Day1Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day1Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day1Comments As String
            Get
                Day1Comments = _Day1Comments
            End Get
            Set(value As String)
                _Day1Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day2Hours As Nullable(Of Decimal)
            Get
                Day2Hours = _Day2Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day2Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day2Comments As String
            Get
                Day2Comments = _Day2Comments
            End Get
            Set(value As String)
                _Day2Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day3Hours As Nullable(Of Decimal)
            Get
                Day3Hours = _Day3Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day3Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day3Comments As String
            Get
                Day3Comments = _Day3Comments
            End Get
            Set(value As String)
                _Day3Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day4Hours As Nullable(Of Decimal)
            Get
                Day4Hours = _Day4Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day4Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day4Comments As String
            Get
                Day4Comments = _Day4Comments
            End Get
            Set(value As String)
                _Day4Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day5Hours As Nullable(Of Decimal)
            Get
                Day5Hours = _Day5Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day5Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day5Comments As String
            Get
                Day5Comments = _Day5Comments
            End Get
            Set(value As String)
                _Day5Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day6Hours As Nullable(Of Decimal)
            Get
                Day6Hours = _Day6Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day6Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day6Comments As String
            Get
                Day6Comments = _Day6Comments
            End Get
            Set(value As String)
                _Day6Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day7Hours As Nullable(Of Decimal)
            Get
                Day7Hours = _Day7Hours
            End Get
            Set(value As Nullable(Of Decimal))
                _Day7Hours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Day7Comments As String
            Get
                Day7Comments = _Day7Comments
            End Get
            Set(value As String)
                _Day7Comments = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalHours As Nullable(Of Decimal)
            Get
                TotalHours = _TotalHours
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalHours = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AllowEdit As Nullable(Of Boolean)
            Get
                AllowEdit = _AllowEdit
            End Get
            Set(value As Nullable(Of Boolean))
                _AllowEdit = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace

