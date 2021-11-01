Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class RevenueSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = Me.HasASelectedPlanClientRevenue AndAlso Me.SelectedPlanClientRevenue.Approved = False
            End Get
        End Property
        Public Property RefreshEnabled As Boolean


        Public ReadOnly Property RevenueViewDetailsEnabled As Boolean
            Get
                RevenueViewDetailsEnabled = Me.HasASelectedPlanClientRevenue
            End Get
        End Property

        Public Property DashbaordEditEnabled As Boolean

        Public ReadOnly Property HasASelectedPlanClientRevenue As Boolean
            Get
                HasASelectedPlanClientRevenue = (Me.SelectedPlanClientRevenue IsNot Nothing AndAlso Me.PlanClientRevenues IsNot Nothing AndAlso Me.PlanClientRevenues.Count > 0)
            End Get
        End Property

        Public Property SelectedPlanClientRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property PlanClientRevenues As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property Dashboard As AdvantageFramework.DTO.Dashboard
        Public Property DashboardDataSource As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupFormDashboardDataSource)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.RefreshEnabled = True

            Me.DashbaordEditEnabled = True

            Me.SelectedPlanClientRevenue = Nothing

            Me.Plan = Nothing

            Me.PlanClientRevenues = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            Me.Dashboard = Nothing
            Me.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupFormDashboardDataSource)

        End Sub

#End Region

    End Class

End Namespace
