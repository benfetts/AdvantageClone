Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class ResourceSetupViewModel

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
                DeleteEnabled = Me.HasASelectedPlanClientResource AndAlso Me.SelectedPlanClientResource.Approved = False
            End Get
        End Property
        Public Property RefreshEnabled As Boolean


        Public ReadOnly Property ResourceViewDetailsEnabled As Boolean
            Get
                ResourceViewDetailsEnabled = Me.HasASelectedPlanClientResource
            End Get
        End Property

        Public Property DashbaordEditEnabled As Boolean

        Public ReadOnly Property HasASelectedPlanClientResource As Boolean
            Get
                HasASelectedPlanClientResource = (Me.SelectedPlanClientResource IsNot Nothing AndAlso Me.PlanClientResources IsNot Nothing AndAlso Me.PlanClientResources.Count > 0)
            End Get
        End Property

        Public Property SelectedPlanClientResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property PlanClientResources As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        Public Property Dashboard As AdvantageFramework.DTO.Dashboard
        Public Property DashboardDataSource As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupFormDashboardDataSource)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.RefreshEnabled = True

            Me.DashbaordEditEnabled = True

            Me.SelectedPlanClientResource = Nothing

            Me.Plan = Nothing

            Me.PlanClientResources = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

            Me.Dashboard = Nothing
            Me.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupFormDashboardDataSource)

        End Sub

#End Region

    End Class

End Namespace
