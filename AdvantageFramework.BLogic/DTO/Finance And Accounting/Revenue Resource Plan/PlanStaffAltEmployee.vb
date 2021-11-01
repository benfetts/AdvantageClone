Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffAltEmployee
        Inherits AdvantageFramework.DTO.BaseClass

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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property RevenueResourcePlanID() As Integer
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property AltEmployeeName() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <Required>
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RevenueResourcePlanStaffTypeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMinValue:=True, MinValue:=0, DisplayFormat:="f2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeMonthlyHours() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMinValue:=True, MinValue:=0, DisplayFormat:="p2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeDirectHoursGoal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMinValue:=True, MinValue:=0, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyBillableRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, UseMinValue:=True, MinValue:=0, DisplayFormat:="c2")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyCostRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Notes() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.AltEmployeeName = String.Empty
            Me.OfficeCode = Nothing
            Me.EmployeeTitleID = Nothing
            Me.DepartmentTeamCode = Nothing
            Me.RevenueResourcePlanStaffTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.StaffType.FullTime
            Me.AltEmployeeMonthlyHours = Nothing
            Me.AltEmployeeDirectHoursGoal = Nothing
            Me.AltEmployeeHourlyBillableRate = Nothing
            Me.AltEmployeeHourlyCostRate = Nothing
            Me.Notes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            Me.ID = RevenueResourcePlanStaff.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanStaff.RevenueResourcePlanID
            Me.AltEmployeeName = RevenueResourcePlanStaff.AltEmployeeName
            Me.OfficeCode = RevenueResourcePlanStaff.OfficeCode
            Me.EmployeeTitleID = RevenueResourcePlanStaff.EmployeeTitleID
            Me.DepartmentTeamCode = RevenueResourcePlanStaff.DepartmentTeamCode
            Me.RevenueResourcePlanStaffTypeID = RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID
            Me.AltEmployeeMonthlyHours = RevenueResourcePlanStaff.AltEmployeeMonthlyHours
            Me.AltEmployeeDirectHoursGoal = RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal
            Me.AltEmployeeHourlyBillableRate = RevenueResourcePlanStaff.AltEmployeeHourlyBillableRate
            Me.AltEmployeeHourlyCostRate = RevenueResourcePlanStaff.AltEmployeeHourlyCostRate
            Me.Notes = RevenueResourcePlanStaff.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            RevenueResourcePlanStaff.AltEmployeeName = Me.AltEmployeeName
            RevenueResourcePlanStaff.OfficeCode = Me.OfficeCode
            RevenueResourcePlanStaff.EmployeeTitleID = Me.EmployeeTitleID
            RevenueResourcePlanStaff.DepartmentTeamCode = Me.DepartmentTeamCode
            RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID = Me.RevenueResourcePlanStaffTypeID
            RevenueResourcePlanStaff.AltEmployeeMonthlyHours = Me.AltEmployeeMonthlyHours
            RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal = Me.AltEmployeeDirectHoursGoal
            RevenueResourcePlanStaff.AltEmployeeHourlyBillableRate = Me.AltEmployeeHourlyBillableRate
            RevenueResourcePlanStaff.AltEmployeeHourlyCostRate = Me.AltEmployeeHourlyCostRate
            RevenueResourcePlanStaff.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.AltEmployeeName.ToString

        End Function

#End Region

    End Class

End Namespace
