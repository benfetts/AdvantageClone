Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class ResourceAddDetailViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property RevenueResourcePlanID As Integer
        Public Property RevenueResourcePlanResourceID As Integer
        Public Property RevenueResourcePlanResourceRevisionID As Integer

        Public Property PlanResourceStaffs As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.CancelEnabled = True

            Me.Plan = Nothing

            Me.RevenueResourcePlanID = 0
            Me.RevenueResourcePlanResourceID = 0
            Me.RevenueResourcePlanResourceRevisionID = 0

            Me.PlanResourceStaffs = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff)

        End Sub

#End Region

    End Class

End Namespace
