
Public Class EmployeeUtilizationAPIReport

#Region " Constants "

#End Region

#Region " Enum "

#End Region

#Region " Variables "

#End Region

#Region " Properties "

    '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
    '    Public Property ID() As Nullable(Of Integer)

    Public Property EmployeeOffice() As String

    Public Property EmployeeOfficeName() As String

    Public Property EmployeeDepartment() As String

    Public Property EmployeeDepartmentName() As String

    Public Property EmployeeCode() As String

    Public Property EmployeeName() As String

    Public Property EmployeeFirstName() As String

    Public Property EmployeeLastName() As String

    Public Property EmploymentDate() As Nullable(Of Date)

    Public Property EmploymentDateStr() As String

    Public Property EmployeeTerminationDate() As Nullable(Of Date)

    Public Property EmployeeTerminationDateStr() As String

    Public Property SupervisorCode() As String

    Public Property Supervisor() As String

    Public Property EmployeeDate() As Nullable(Of Date)

    Public Property EmployeeDateStr() As String

    Public Property PostPeriod() As String

    Public Property Month() As String

    <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
    Public Property Year() As Nullable(Of Integer)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property StandardAnnualHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property RequiredHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property DirectHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property BillableHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property BillableHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property BillableAmount() As Nullable(Of Decimal)
    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property NonBillableHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property NonBillableAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property ClientHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property ClientAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property AgencyHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property AgencyAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property NewBusinessHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property NewBusinessAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property TotalDirectHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property TotalDirectAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property NonDirectHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property TotalHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property Variance() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentDirect() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentNonDirect() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentOfRequiredHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentOfDirectHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentOfBillableHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property BilledHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property BilledAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property WIPHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property WIPAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property WriteUpDownAmount() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentBilled() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentBilledOfDirectHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentBilledOfBillableHoursGoal() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property PercentBilledOfRequiredHours() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property AverageHourlyRateBilled() As Nullable(Of Decimal)

    <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
    Public Property AverageHourlyRateAchieved() As Nullable(Of Decimal)


#End Region

#Region " Methods "

    Public Overrides Function ToString() As String

        ToString = Me.EmployeeCode.ToString

    End Function

#End Region

    End Class


