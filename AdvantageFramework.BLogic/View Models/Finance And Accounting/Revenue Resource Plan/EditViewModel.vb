Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class EditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property AddVisible As Boolean
            Get
                AddVisible = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID = 0)
            End Get
        End Property
        Public ReadOnly Property UpdateVisible As Boolean
            Get
                UpdateVisible = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0)
            End Get
        End Property
        Public Property CancelEnabled As Boolean

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property Offices As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property Employees As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property Months As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.CancelEnabled = True

            Me.Plan = Nothing

            Me.Offices = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.Employees = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.Months = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace
