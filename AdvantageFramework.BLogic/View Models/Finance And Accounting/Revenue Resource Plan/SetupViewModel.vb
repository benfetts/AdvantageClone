Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class SetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property RefreshEnabled As Boolean
        Public ReadOnly Property UpdateEnabled As Boolean
            Get
                UpdateEnabled = Me.HasASelectedPlan
            End Get
        End Property
        Public ReadOnly Property DeleteEnabled As Boolean
            Get
                DeleteEnabled = Me.HasASelectedPlan
            End Get
        End Property
        Public ReadOnly Property CopyEnabled As Boolean
            Get
                CopyEnabled = Me.HasASelectedPlan
            End Get
        End Property


        Public ReadOnly Property StaffEnabled As Boolean
            Get
                StaffEnabled = Me.HasASelectedPlan
            End Get
        End Property
        Public ReadOnly Property RevenueEnabled As Boolean
            Get
                RevenueEnabled = Me.HasASelectedPlan
            End Get
        End Property
        Public ReadOnly Property ResourcesEnabled As Boolean
            Get
                ResourcesEnabled = Me.HasASelectedPlan
            End Get
        End Property

        Public Property DashbaordEditEnabled As Boolean

        Public ReadOnly Property HasASelectedPlan As Boolean
            Get
                HasASelectedPlan = (Me.SelectedPlan IsNot Nothing AndAlso Me.Plans IsNot Nothing AndAlso Me.Plans.Count > 0)
            End Get
        End Property

        Public Property SelectedPlan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property Plans As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan)

        Public Property Dashboard As AdvantageFramework.DTO.Dashboard
        Public Property DashboardDataSource As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.SetupFormDashboardDataSource)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.RefreshEnabled = True

            Me.DashbaordEditEnabled = True

            Me.SelectedPlan = Nothing

            Me.Plans = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan)

            Me.Dashboard = Nothing
            Me.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.SetupFormDashboardDataSource)

        End Sub

#End Region

    End Class

End Namespace
