Namespace Database.Entities

    <Table("REVENUE_RESOURCE_PLAN_STAFF")>
    Public Class RevenueResourcePlanStaff
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            AltEmployeeName
            EmployeeCode
            OfficeCode
            EmployeeTitleID
            DepartmentTeamCode
            RevenueResourcePlanStaffTypeID
            AltEmployeeMonthlyHours
            AltEmployeeDirectHoursGoal
            AltEmployeeHourlyBillableRate
            AltEmployeeHourlyCostRate
            Notes
            RevenueResourcePlan
            Employee
            Office
            EmployeeTitle
            DepartmentTeam
            RevenueResourcePlanStaffClients
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_STAFF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("REVENUE_RESOURCE_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanID() As Integer
        <MaxLength(100)>
        <Column("ALT_EMPLOYEE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AltEmployeeName() As String
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode() As String
        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
        <Column("EMPLOYEE_TITLE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <MaxLength(4)>
        <Column("DP_TM_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepartmentTeamCode() As String
        <Column("REVENUE_RESOURCE_PLAN_STAFF_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RevenueResourcePlanStaffTypeID() As Nullable(Of Integer)
        <Column("ALT_EMPLOYEE_MONTHLY_HOURS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeMonthlyHours() As Nullable(Of Decimal)
        <Column("ALT_EMPLOYEE_DIRECT_HOURS_GOAL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeDirectHoursGoal() As Nullable(Of Decimal)
        <Column("ALT_EMPLOYEE_HOURLY_BILLABLE_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyBillableRate() As Nullable(Of Decimal)
        <Column("ALT_EMPLOYEE_HOURLY_COST_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyCostRate() As Nullable(Of Decimal)
        <Required>
        <Column("NOTES", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Notes() As String

        Public Overridable Property RevenueResourcePlan As Database.Entities.RevenueResourcePlan
        Public Overridable Property RevenueResourcePlanStaffType As Database.Entities.RevenueResourcePlanStaffType
        Public Overridable Property Employee As Database.Views.Employee
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property EmployeeTitle As Database.Entities.EmployeeTitle
        Public Overridable Property DepartmentTeam As Database.Entities.DepartmentTeam
        Public Overridable Property RevenueResourcePlanStaffClients As ICollection(Of Database.Entities.RevenueResourcePlanStaffClient)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.EmployeeCode

        End Function

#End Region

    End Class

End Namespace
