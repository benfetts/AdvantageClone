Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class StaffClientAssignmentsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public ReadOnly Property CDPAddEnabled As Boolean
            Get
                CDPAddEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0)
            End Get
        End Property
        Public ReadOnly Property CDPDeleteEnabled As Boolean
            Get
                CDPDeleteEnabled = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.SelectedPlanStaffClientAssignment IsNot Nothing)
            End Get
        End Property

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan
        Public Property PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff

        Public Property PlanStaffClientAssignments As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

        Public Property SelectedPlanStaffClientAssignment As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment


#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = False
            Me.CancelEnabled = False

            Me.Plan = Nothing
            Me.PlanStaff = Nothing

            Me.PlanStaffClientAssignments = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

            Me.SelectedPlanStaffClientAssignment = Nothing

        End Sub

#End Region

    End Class

End Namespace
