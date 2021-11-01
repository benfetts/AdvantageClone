Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class ResourceAddViewModel

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

        Public Property PlanResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResource

        Public Property Clients As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.CancelEnabled = True

            Me.PlanID = 0

            Me.PlanResource = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResource

            Me.Clients = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace
