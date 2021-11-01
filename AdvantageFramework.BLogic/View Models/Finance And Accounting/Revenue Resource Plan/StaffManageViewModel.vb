Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class StaffManageViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property ManageEmployeesEnabled As Boolean
            Get
                ManageEmployeesEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0)
            End Get
        End Property
        Public ReadOnly Property AddAlternateEmployeeEnabled As Boolean
            Get
                AddAlternateEmployeeEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0)
            End Get
        End Property
        Public ReadOnly Property UpdateAlternateEmployeeEnabled As Boolean
            Get
                UpdateAlternateEmployeeEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedPlanStaff IsNot Nothing AndAlso Me.SelectedPlanStaff.IsAlternateEmployee)
            End Get
        End Property
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedPlanStaff IsNot Nothing)
            End Get
        End Property
        Public ReadOnly Property ViewDetailsEnabled As Boolean
            Get
                ViewDetailsEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedPlanStaff IsNot Nothing)
            End Get
        End Property

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan
        Public Property PlanStaffs As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)
        Public Property SelectedPlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff


#End Region

#Region " Methods "

        Public Sub New()

            Me.Plan = Nothing
            Me.PlanStaffs = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)
            Me.SelectedPlanStaff = Nothing

        End Sub

#End Region

    End Class

End Namespace
