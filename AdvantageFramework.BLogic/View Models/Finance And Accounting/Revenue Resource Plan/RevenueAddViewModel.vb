Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class RevenueAddViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property AddVisible As Boolean
            Get
                AddVisible = (PlanID > 0)
            End Get
        End Property
        Public Property CancelEnabled As Boolean

        Public Property PlanID As Integer

        Public Property PlanRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue

        Public Property Clients As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.CancelEnabled = True

            Me.PlanID = 0

            Me.PlanRevenue = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue

            Me.Clients = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace
