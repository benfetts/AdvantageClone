Namespace Reporting.Database.Classes

    <Serializable>
    Public Class EmployeeHoursAllocationReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OfficeCode
            OfficeDescription
            DepartmentCode
            DepartmentName
            EmployeeCode
            EmployeeName
            SupervisorCode
            SupervisorName
            HoursAvailable
            DirectHoursGoalPercent
            DirectHoursGoal
            TotalHoursAllocated 'PercentOfDirectGoalTotals
            PercentUtilized
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            JobNumber
            JobDescription
            ComponentNumber
            ComponentDescription
            FunctionCode
            FunctionDescription
            AssignmentID
            AssignmentDescription
            StartDate
            DueDate
            HoursAllowed
            HoursPerDay
            TotalWorkingDays
            BeginningBalance
            HoursPosted
            HoursLeft
            [Date]
            [Hours]
            BillableAmount
            ActualHours
            ActualAmount
        End Enum

#End Region

#Region " Variables "


#End Region

#Region " Properties "

        <Required>
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <MaxLength(4)>
        Public Property OfficeCode() As String
        <MaxLength(30)>
        Public Property OfficeDescription() As String
        <MaxLength(6)>
        Public Property DepartmentCode() As String
        <MaxLength(40)>
        Public Property DepartmentName() As String
        <MaxLength(6)>
        Public Property EmployeeCode() As String
        <MaxLength(40)>
        Public Property EmployeeName() As String
        <MaxLength(6)>
        Public Property SupervisorCode As String
        <MaxLength(40)>
        Public Property SupervisorName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Hours Available (Adj)")>
        Public Property HoursAvailable As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectHoursGoalPercent As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DirectHoursGoal As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalHoursAllocated As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PercentUtilized As Nullable(Of Decimal)
        <MaxLength(6)>
        Public Property ClientCode() As String
        <MaxLength(40)>
        Public Property ClientName() As String
        <MaxLength(6)>
        Public Property DivisionCode() As String
        <MaxLength(40)>
        Public Property DivisionName() As String
        <MaxLength(6)>
        Public Property ProductCode As String
        <MaxLength(40)>
        Public Property ProductName As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property JobNumber As Nullable(Of Integer)
        Public Property JobDescription As String
        Public Property ComponentNumber As Nullable(Of Short)
        Public Property ComponentDescription As String
        <MaxLength(6)>
        Public Property FunctionCode As String
        <MaxLength(30)>
        Public Property FunctionDescription As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property AssignmentID As Nullable(Of Integer)
        Public Property AssignmentDescription As String
        Public Property StartDate As Nullable(Of Date)
        Public Property DueDate As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property HoursAllowed As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property HoursPerDay As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TotalWorkingDays As Nullable(Of Decimal)
        'Public Property BeginningBalance As Nullable(Of Decimal)
        'Public Property HoursPosted As Nullable(Of Decimal)
        'Public Property HoursLeft As Nullable(Of Decimal)
        Public Property [Date] As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property [Hours] As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BillableAmount As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualHours As Nullable(Of Decimal)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualAmount As Nullable(Of Decimal)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
