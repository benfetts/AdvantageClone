Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeUtilizationItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EmployeeOffice
            EmployeeOfficeName
            EmployeeDepartment
            EmployeeDepartmentName
            EmployeeCode
            EmployeeName
            EmployeeFirstName
            EmployeeLastName
            EmploymentDate
            RequiredHours
            DirectHoursGoal
            BillableHoursGoal
            BillableHours
            BillableAmount
            NonBillableHours
            NonBillableAmount
            ClientHours
            ClientAmount
            AgencyHours
            AgencyAmount
            NewBusinessHours
            NewBusinessAmount
            TotalDirectHours
            TotalDirectAmount
            NonDirectHours
            TotalHours
            Variance
            PercentDirect
            PercentNonDirect
            PercentOfRequiredHours
            PercentOfDirectHoursGoal
            PercentOfBillableHoursGoal
            BilledHours
            BilledAmount
            WIPHours
            WIPAmount
            WriteUpDownAmount
            PercentBilled
            PercentBilledOfDirectHoursGoal
            PercentBilledOfBillableHoursGoal
            PercentBilledOfRequiredHours
            AverageHourlyRateBilled
            AverageHourlyRateAchieved
            BillableHoursPercent
            BillableVariance
            NonBillableHoursPercent
            NewBusinessPercent
            OOOPercent
            TotalUtilization
            OOOHours
            BillablePercentGoal
            DirectPercentGoal

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property EmployeeOffice As String = String.Empty
        Public Property EmployeeOfficeName As String = String.Empty
        Public Property EmployeeDepartment As String = String.Empty
        Public Property EmployeeDepartmentName As String = String.Empty
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeName As String = String.Empty
        Public Property EmployeeFirstName As String = String.Empty
        Public Property EmployeeLastName As String = String.Empty
        Public Property EmploymentDate As Date?
        Public Property RequiredHours As Decimal?
        Public Property DirectHoursGoal As Decimal?
        Public Property BillableHoursGoal As Decimal?
        Public Property BillableHours As Decimal?
        Public Property BillableAmount As Decimal?
        Public Property NonBillableHours As Decimal?
        Public Property NonBillableAmount As Decimal?
        Public Property ClientHours As Decimal?
        Public Property ClientAmount As Decimal?
        Public Property AgencyHours As Decimal?
        Public Property AgencyAmount As Decimal?
        Public Property NewBusinessHours As Decimal?
        Public Property NewBusinessAmount As Decimal?
        Public Property TotalDirectHours As Decimal?
        Public Property TotalDirectAmount As Decimal?
        Public Property NonDirectHours As Decimal?
        Public Property TotalHours As Decimal?
        Public Property Variance As Decimal?
        Public Property PercentDirect As Decimal?
        Public Property PercentNonDirect As Decimal?
        Public Property PercentOfRequiredHours As Decimal?
        Public Property PercentOfDirectHoursGoal As Decimal?
        Public Property PercentOfBillableHoursGoal As Decimal?
        Public Property BilledHours As Decimal?
        Public Property BilledAmount As Decimal?
        Public Property WIPHours As Decimal?
        Public Property WIPAmount As Decimal?
        Public Property WriteUpDownAmount As Decimal?
        Public Property PercentBilled As Decimal?
        Public Property PercentBilledOfDirectHoursGoal As Decimal?
        Public Property PercentBilledOfBillableHoursGoal As Decimal?
        Public Property PercentBilledOfRequiredHours As Decimal?
        Public Property AverageHourlyRateBilled As Decimal?
        Public Property AverageHourlyRateAchieved As Decimal?
        Public Property BillableHoursPercent As Decimal?
        Public Property BillableVariance As Decimal?
        Public Property NonBillableHoursPercent As Decimal?
        Public Property NewBusinessPercent As Decimal?
        Public Property OOOPercent As Decimal?
        Public Property TotalUtilization As Decimal?
        Public Property OOOHours As Decimal?
        Public Property BillablePercentGoal As Decimal?
        Public Property DirectPercentGoal As Decimal?


#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
