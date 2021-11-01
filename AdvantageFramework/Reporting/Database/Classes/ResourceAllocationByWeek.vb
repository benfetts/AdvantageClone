Namespace Reporting.Database.Classes

    <Serializable>
    Public Class ResourceAllocationByWeek

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Employee
            EmployeeFirstName
            EmployeeLastName
            OfficeCode
            Office
            DepartmentCode
            Department
            AssignmentDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            FunctionCode
            FunctionDescription
            HoursAllowed
            HoursAllocated
            AllocatedBalance
            HoursPosted
            HoursLeft
            BurnRate
            HoursAvailableWeek1
            HoursAllocatedWeek1
            AvailableBalanceWeek1
            HoursPostedWeek1
            HoursLeftWeek1
            BurnRateWeek1
            HoursAvailableWeek2
            HoursAllocatedWeek2
            AvailableBalanceWeek2
            HoursPostedWeek2
            HoursLeftWeek2
            BurnRateWeek2
            HoursAvailableWeek3
            HoursAllocatedWeek3
            AvailableBalanceWeek3
            HoursPostedWeek3
            HoursLeftWeek3
            BurnRateWeek3
            HoursAvailableWeek4
            HoursAllocatedWeek4
            AvailableBalanceWeek4
            HoursPostedWeek4
            HoursLeftWeek4
            BurnRateWeek4
            HoursAvailableWeek5
            HoursAllocatedWeek5
            AvailableBalanceWeek5
            HoursPostedWeek5
            HoursLeftWeek5
            BurnRateWeek5
            HoursAvailableWeek6
            HoursAllocatedWeek6
            AvailableBalanceWeek6
            HoursPostedWeek6
            HoursLeftWeek6
            BurnRateWeek6
            HoursAvailableWeek7
            HoursAllocatedWeek7
            AvailableBalanceWeek7
            HoursPostedWeek7
            HoursLeftWeek7
            BurnRateWeek7
            HoursAvailableWeek8
            HoursAllocatedWeek8
            AvailableBalanceWeek8
            HoursPostedWeek8
            HoursLeftWeek8
            BurnRateWeek8
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _EmployeeCode As String = Nothing
        Private _Employee As String = Nothing
        Private _EmployeeFirstName As String = Nothing
        Private _EmployeeLastName As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _Office As String = Nothing
        Private _DepartmentCode As String = Nothing
        Private _Department As String = Nothing
        Private _AssignmentDescription As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _HoursAllowed As Nullable(Of Decimal) = Nothing
        Private _HoursAllocated As Nullable(Of Decimal) = Nothing
        Private _AllocatedBalance As Nullable(Of Decimal) = Nothing
        Private _HoursPosted As Nullable(Of Decimal) = Nothing
        Private _HoursLeft As Nullable(Of Decimal) = Nothing
        Private _BurnRate As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek1 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek1 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek1 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek1 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek1 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek1 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek2 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek2 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek2 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek2 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek2 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek2 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek3 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek3 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek3 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek3 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek3 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek3 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek4 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek4 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek4 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek4 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek4 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek4 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek5 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek5 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek5 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek5 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek5 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek5 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek6 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek6 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek6 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek6 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek6 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek6 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek7 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek7 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek7 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek7 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek7 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek7 As Nullable(Of Decimal) = Nothing
        Private _HoursAvailableWeek8 As Nullable(Of Decimal) = Nothing
        Private _HoursAllocatedWeek8 As Nullable(Of Decimal) = Nothing
        Private _AvailableBalanceWeek8 As Nullable(Of Decimal) = Nothing
        Private _HoursPostedWeek8 As Nullable(Of Decimal) = Nothing
        Private _HoursLeftWeek8 As Nullable(Of Decimal) = Nothing
        Private _BurnRateWeek8 As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
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
        Public Property DepartmentCode() As String
            Get
                DepartmentCode = _DepartmentCode
            End Get
            Set(value As String)
                _DepartmentCode = value
            End Set
        End Property
        Public Property AssignmentDescription() As String
            Get
                AssignmentDescription = _AssignmentDescription
            End Get
            Set(value As String)
                _AssignmentDescription = value
            End Set
        End Property
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JobComponentDescription
            End Get
            Set(value As String)
                _JobComponentDescription = value
            End Set
        End Property
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(value As String)
                _FunctionCode = value
            End Set
        End Property
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(value As String)
                _FunctionDescription = value
            End Set
        End Property
        Public Property HoursAllowed() As Nullable(Of Decimal)
            Get
                HoursAllowed = _HoursAllowed
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllowed = value
            End Set
        End Property
        Public Property HoursAllocated() As Nullable(Of Decimal)
            Get
                HoursAllocated = _HoursAllocated
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocated = value
            End Set
        End Property
        Public Property AllocatedBalance() As Nullable(Of Decimal)
            Get
                AllocatedBalance = _AllocatedBalance
            End Get
            Set(value As Nullable(Of Decimal))
                _AllocatedBalance = value
            End Set
        End Property
        Public Property HoursPosted() As Nullable(Of Decimal)
            Get
                HoursPosted = _HoursPosted
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPosted = value
            End Set
        End Property
        Public Property HoursLeft() As Nullable(Of Decimal)
            Get
                HoursLeft = _HoursLeft
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeft = value
            End Set
        End Property
        Public Property BurnRate() As Nullable(Of Decimal)
            Get
                BurnRate = _BurnRate
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 1")>
        Public Property HoursAvailableWeek1() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek1 = _HoursAvailableWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 1")>
        Public Property HoursAllocatedWeek1() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek1 = _HoursAllocatedWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 1")>
        Public Property AvailableBalanceWeek1() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek1 = _AvailableBalanceWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 1")>
        Public Property HoursPostedWeek1() As Nullable(Of Decimal)
            Get
                HoursPostedWeek1 = _HoursPostedWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 1")>
        Public Property HoursLeftWeek1() As Nullable(Of Decimal)
            Get
                HoursLeftWeek1 = _HoursLeftWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 1")>
        Public Property BurnRateWeek1() As Nullable(Of Decimal)
            Get
                BurnRateWeek1 = _BurnRateWeek1
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 2")>
        Public Property HoursAvailableWeek2() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek2 = _HoursAvailableWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 2")>
        Public Property HoursAllocatedWeek2() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek2 = _HoursAllocatedWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 2")>
        Public Property AvailableBalanceWeek2() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek2 = _AvailableBalanceWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 2")>
        Public Property HoursPostedWeek2() As Nullable(Of Decimal)
            Get
                HoursPostedWeek2 = _HoursPostedWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 2")>
        Public Property HoursLeftWeek2() As Nullable(Of Decimal)
            Get
                HoursLeftWeek2 = _HoursLeftWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 2")>
        Public Property BurnRateWeek2() As Nullable(Of Decimal)
            Get
                BurnRateWeek2 = _BurnRateWeek2
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 3")>
        Public Property HoursAvailableWeek3() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek3 = _HoursAvailableWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 3")>
        Public Property HoursAllocatedWeek3() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek3 = _HoursAllocatedWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 3")>
        Public Property AvailableBalanceWeek3() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek3 = _AvailableBalanceWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 3")>
        Public Property HoursPostedWeek3() As Nullable(Of Decimal)
            Get
                HoursPostedWeek3 = _HoursPostedWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 3")>
        Public Property HoursLeftWeek3() As Nullable(Of Decimal)
            Get
                HoursLeftWeek3 = _HoursLeftWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 3")>
        Public Property BurnRateWeek3() As Nullable(Of Decimal)
            Get
                BurnRateWeek3 = _BurnRateWeek3
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 4")>
        Public Property HoursAvailableWeek4() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek4 = _HoursAvailableWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 4")>
        Public Property HoursAllocatedWeek4() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek4 = _HoursAllocatedWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 4")>
        Public Property AvailableBalanceWeek4() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek4 = _AvailableBalanceWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 4")>
        Public Property HoursPostedWeek4() As Nullable(Of Decimal)
            Get
                HoursPostedWeek4 = _HoursPostedWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 4")>
        Public Property HoursLeftWeek4() As Nullable(Of Decimal)
            Get
                HoursLeftWeek4 = _HoursLeftWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 4")>
        Public Property BurnRateWeek4() As Nullable(Of Decimal)
            Get
                BurnRateWeek4 = _BurnRateWeek4
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek4 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 5")>
        Public Property HoursAvailableWeek5() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek5 = _HoursAvailableWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 5")>
        Public Property HoursAllocatedWeek5() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek5 = _HoursAllocatedWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 5")>
        Public Property AvailableBalanceWeek5() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek5 = _AvailableBalanceWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 5")>
        Public Property HoursPostedWeek5() As Nullable(Of Decimal)
            Get
                HoursPostedWeek5 = _HoursPostedWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 5")>
        Public Property HoursLeftWeek5() As Nullable(Of Decimal)
            Get
                HoursLeftWeek5 = _HoursLeftWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 5")>
        Public Property BurnRateWeek5() As Nullable(Of Decimal)
            Get
                BurnRateWeek5 = _BurnRateWeek5
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek5 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 6")>
        Public Property HoursAvailableWeek6() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek6 = _HoursAvailableWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 6")>
        Public Property HoursAllocatedWeek6() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek6 = _HoursAllocatedWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 6")>
        Public Property AvailableBalanceWeek6() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek6 = _AvailableBalanceWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 6")>
        Public Property HoursPostedWeek6() As Nullable(Of Decimal)
            Get
                HoursPostedWeek6 = _HoursPostedWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 6")>
        Public Property HoursLeftWeek6() As Nullable(Of Decimal)
            Get
                HoursLeftWeek6 = _HoursLeftWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 6")>
        Public Property BurnRateWeek6() As Nullable(Of Decimal)
            Get
                BurnRateWeek6 = _BurnRateWeek6
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek6 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 7")>
        Public Property HoursAvailableWeek7() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek7 = _HoursAvailableWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 7")>
        Public Property HoursAllocatedWeek7() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek7 = _HoursAllocatedWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 7")>
        Public Property AvailableBalanceWeek7() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek7 = _AvailableBalanceWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 7")>
        Public Property HoursPostedWeek7() As Nullable(Of Decimal)
            Get
                HoursPostedWeek7 = _HoursPostedWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 7")>
        Public Property HoursLeftWeek7() As Nullable(Of Decimal)
            Get
                HoursLeftWeek7 = _HoursLeftWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 7")>
        Public Property BurnRateWeek7() As Nullable(Of Decimal)
            Get
                BurnRateWeek7 = _BurnRateWeek7
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek7 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Available Week 8")>
        Public Property HoursAvailableWeek8() As Nullable(Of Decimal)
            Get
                HoursAvailableWeek8 = _HoursAvailableWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAvailableWeek8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Allocated Week 8")>
        Public Property HoursAllocatedWeek8() As Nullable(Of Decimal)
            Get
                HoursAllocatedWeek8 = _HoursAllocatedWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursAllocatedWeek8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Available Balance Week 8")>
        Public Property AvailableBalanceWeek8() As Nullable(Of Decimal)
            Get
                AvailableBalanceWeek8 = _AvailableBalanceWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _AvailableBalanceWeek8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Posted Week 8")>
        Public Property HoursPostedWeek8() As Nullable(Of Decimal)
            Get
                HoursPostedWeek8 = _HoursPostedWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursPostedWeek8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Hours Left Week 8")>
        Public Property HoursLeftWeek8() As Nullable(Of Decimal)
            Get
                HoursLeftWeek8 = _HoursLeftWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _HoursLeftWeek8 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, CustomColumnCaption:="Burn Rate Week 8")>
        Public Property BurnRateWeek8() As Nullable(Of Decimal)
            Get
                BurnRateWeek8 = _BurnRateWeek8
            End Get
            Set(value As Nullable(Of Decimal))
                _BurnRateWeek8 = value
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
