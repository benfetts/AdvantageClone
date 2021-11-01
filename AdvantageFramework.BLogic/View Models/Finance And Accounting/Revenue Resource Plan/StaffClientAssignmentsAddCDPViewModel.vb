Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class StaffClientAssignmentsAddCDPViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public ReadOnly Property CDPSelectionEnabled As Boolean
            Get
                CDPSelectionEnabled = (Me.PlanStaffClientAssignmentClients IsNot Nothing AndAlso Me.PlanStaffClientAssignmentClients.All(Function(Entity) Entity.Selected = False) AndAlso
                                       Me.PlanStaffClientAssignmentDivisions IsNot Nothing AndAlso Me.PlanStaffClientAssignmentDivisions.All(Function(Entity) Entity.Selected = False) AndAlso
                                       Me.PlanStaffClientAssignmentProducts IsNot Nothing AndAlso Me.PlanStaffClientAssignmentProducts.All(Function(Entity) Entity.Selected = False))
            End Get
        End Property

        Public Property PlanID As Integer
        Public Property PlanStaffID As Integer

        Public Property PlanStaffClientAssignments As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

        Public Property PlanStaffClientAssignmentClients As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient)
        Public Property PlanStaffClientAssignmentDivisions As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentDivision)
        Public Property PlanStaffClientAssignmentProducts As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct)


#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = False
            Me.CancelEnabled = True

            Me.PlanID = 0
            Me.PlanStaffID = 0

            Me.PlanStaffClientAssignments = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

            Me.PlanStaffClientAssignmentClients = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient)
            Me.PlanStaffClientAssignmentDivisions = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentDivision)
            Me.PlanStaffClientAssignmentProducts = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct)

        End Sub

#End Region

    End Class

End Namespace
