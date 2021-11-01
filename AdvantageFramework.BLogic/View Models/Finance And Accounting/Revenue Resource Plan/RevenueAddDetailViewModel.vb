Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class RevenueAddDetailViewModel

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
        Public Property RevenueResourcePlanRevenueID As Integer
        Public Property RevenueResourcePlanRevenueRevisionID As Integer

        Public Property ClientSelected As Boolean
        Public Property DivisionSelected As Boolean
        Public Property ProductSelected As Boolean
        Public Property JobComponentSelected As Boolean

        Public Property Clients As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Client)
        Public Property Divisions As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division)
        Public Property Products As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product)
        Public Property JobComponents As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.CancelEnabled = True

            Me.Plan = Nothing

            Me.RevenueResourcePlanID = 0
            Me.RevenueResourcePlanRevenueID = 0
            Me.RevenueResourcePlanRevenueRevisionID = 0

            Me.ClientSelected = True
            Me.DivisionSelected = False
            Me.ProductSelected = False
            Me.JobComponentSelected = False

            Me.Clients = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Client)
            Me.Divisions = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division)
            Me.Products = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product)
            Me.JobComponents = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent)

        End Sub

#End Region

    End Class

End Namespace
