Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaff
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            IsAlternateEmployee
            AltEmployeeName
            EmployeeCode
            StaffName
            OfficeCode
            Office
            EmployeeTitleID
            EmployeeTitle
            DepartmentTeamCode
            DepartmentTeam
            RevenueResourcePlanStaffTypeID
            AltEmployeeMonthlyHours
            AltEmployeeDirectHoursGoal
            AltEmployeeHourlyBillableRate
            AltEmployeeHourlyCostRate
            Type
            Status
            Notes
            HoursAvailable
            DirectPercentGoal
            DirectHoursGoal
            PlanAllocatedHours
            PlanAllocatedPercentage
            UtilizationVariance
            UtilizationVariancePercentage
            EmployeeCost
            PlanRevenue
            CostRevenueVariance
            CostRevenueVariancePercentage
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property IsAlternateEmployee() As Boolean
            Get

                If String.IsNullOrWhiteSpace(Me.EmployeeCode) Then

                    IsAlternateEmployee = True

                Else

                    IsAlternateEmployee = False

                End If

            End Get
        End Property
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AltEmployeeName() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property StaffName() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Office() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeTitle() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepartmentTeam() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RevenueResourcePlanStaffTypeID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MinValue:=0)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeMonthlyHours() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MinValue:=0)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeDirectHoursGoal() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MinValue:=0)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyBillableRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MinValue:=0)>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(9, 2)>
        Public Property AltEmployeeHourlyCostRate() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Type() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property HoursAvailable() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="p0", MaxValue:=100, MinValue:=0, UseMaxValue:=True, UseMinValue:=True)>
        Public Property DirectPercentGoal() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DirectHoursGoal() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property PlanAllocatedHours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="p2")>
        Public Property PlanAllocatedPercentage() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property UtilizationVariance() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="p2")>
        Public Property UtilizationVariancePercentage() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property EmployeeCost() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property PlanRevenue() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="c2")>
        Public Property CostRevenueVariance() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="p2")>
        Public Property CostRevenueVariancePercentage() As Decimal

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.AltEmployeeName = Nothing
            Me.EmployeeCode = Nothing
            Me.StaffName = String.Empty
            Me.OfficeCode = Nothing
            Me.Office = String.Empty
            Me.EmployeeTitleID = Nothing
            Me.EmployeeTitle = String.Empty
            Me.DepartmentTeamCode = Nothing
            Me.DepartmentTeam = String.Empty
            Me.RevenueResourcePlanStaffTypeID = Nothing
            Me.AltEmployeeMonthlyHours = Nothing
            Me.AltEmployeeDirectHoursGoal = Nothing
            Me.AltEmployeeHourlyBillableRate = Nothing
            Me.AltEmployeeHourlyCostRate = Nothing
            Me.Type = String.Empty
            Me.Status = String.Empty
            Me.Notes = String.Empty
            Me.HoursAvailable = 0
            Me.DirectPercentGoal = 0
            Me.DirectHoursGoal = 0
            Me.PlanAllocatedPercentage = 0
            Me.PlanAllocatedHours = 0
            Me.UtilizationVariancePercentage = 0
            Me.EmployeeCost = 0
            Me.PlanRevenue = 0
            Me.CostRevenueVariancePercentage = 0
            Me.CostRevenueVariance = 0

        End Sub
        Public Sub New(RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            Me.ID = RevenueResourcePlanStaff.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanStaff.RevenueResourcePlanID
            Me.AltEmployeeName = RevenueResourcePlanStaff.AltEmployeeName
            Me.EmployeeCode = RevenueResourcePlanStaff.EmployeeCode
            Me.StaffName = If(String.IsNullOrWhiteSpace(RevenueResourcePlanStaff.EmployeeCode), RevenueResourcePlanStaff.AltEmployeeName, If(RevenueResourcePlanStaff.Employee IsNot Nothing, RevenueResourcePlanStaff.Employee.ToString, String.Empty))
            Me.OfficeCode = RevenueResourcePlanStaff.OfficeCode
            Me.Office = If(RevenueResourcePlanStaff.Office IsNot Nothing, RevenueResourcePlanStaff.Office.Name, String.Empty)
            Me.EmployeeTitleID = RevenueResourcePlanStaff.EmployeeTitleID
            Me.EmployeeTitle = If(RevenueResourcePlanStaff.EmployeeTitle IsNot Nothing, RevenueResourcePlanStaff.EmployeeTitle.Description, String.Empty)
            Me.DepartmentTeamCode = RevenueResourcePlanStaff.DepartmentTeamCode
            Me.DepartmentTeam = If(RevenueResourcePlanStaff.DepartmentTeam IsNot Nothing, RevenueResourcePlanStaff.DepartmentTeam.Description, String.Empty)
            Me.RevenueResourcePlanStaffTypeID = RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID
            Me.AltEmployeeMonthlyHours = RevenueResourcePlanStaff.AltEmployeeMonthlyHours
            Me.AltEmployeeDirectHoursGoal = RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal
            Me.AltEmployeeHourlyBillableRate = RevenueResourcePlanStaff.AltEmployeeHourlyBillableRate
            Me.AltEmployeeHourlyCostRate = RevenueResourcePlanStaff.AltEmployeeHourlyCostRate
            Me.Notes = RevenueResourcePlanStaff.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            RevenueResourcePlanStaff.EmployeeCode = Me.EmployeeCode
            RevenueResourcePlanStaff.OfficeCode = Me.OfficeCode
            RevenueResourcePlanStaff.EmployeeTitleID = Me.EmployeeTitleID
            RevenueResourcePlanStaff.DepartmentTeamCode = Me.DepartmentTeamCode

            If String.IsNullOrWhiteSpace(Me.EmployeeCode) Then

                RevenueResourcePlanStaff.AltEmployeeName = Me.AltEmployeeName
                RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID = Me.RevenueResourcePlanStaffTypeID
                RevenueResourcePlanStaff.AltEmployeeMonthlyHours = Me.AltEmployeeMonthlyHours
                RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal = Me.DirectPercentGoal
                RevenueResourcePlanStaff.AltEmployeeHourlyBillableRate = Me.AltEmployeeHourlyBillableRate
                RevenueResourcePlanStaff.AltEmployeeHourlyCostRate = Me.AltEmployeeHourlyCostRate

            End If

            RevenueResourcePlanStaff.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.StaffName.ToString

        End Function

#End Region

    End Class

End Namespace
