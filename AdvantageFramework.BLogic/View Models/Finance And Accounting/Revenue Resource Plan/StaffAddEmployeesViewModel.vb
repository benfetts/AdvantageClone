Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class StaffEmployeesEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property AddEnabled As Boolean
            Get
                AddEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedAvailablePlanStaffEmployees IsNot Nothing AndAlso Me.SelectedAvailablePlanStaffEmployees.Count > 0)
            End Get
        End Property
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedPlanStaffEmployees IsNot Nothing AndAlso Me.SelectedPlanStaffEmployees.Count > 0)
            End Get
        End Property

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property PlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)
        Public Property AvailablePlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

        Public Property SelectedPlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)
        Public Property SelectedAvailablePlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

#End Region

#Region " Methods "

        Public Sub New()

            Me.Plan = Nothing

            Me.PlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)
            Me.AvailablePlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

            Me.SelectedPlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)
            Me.SelectedAvailablePlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

        End Sub

#End Region

    End Class

End Namespace
