Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class StaffAltEmployeeEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property AddVisible As Boolean
            Get
                AddVisible = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.PlanStaffAltEmployee IsNot Nothing AndAlso Me.PlanStaffAltEmployee.ID = 0)
            End Get
        End Property
        Public ReadOnly Property UpdateVisible As Boolean
            Get
                UpdateVisible = (Me.Plan IsNot Nothing AndAlso Me.Plan.ID > 0 AndAlso Me.PlanStaffAltEmployee IsNot Nothing AndAlso Me.PlanStaffAltEmployee.ID > 0)
            End Get
        End Property

        Public Property CancelEnabled As Boolean

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan

        Public Property PlanStaffAltEmployee As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee

        Public Property Offices As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property EmployeeTitles As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property DepartmentTeams As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property RevenueResourcePlanStaffTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()

            Me.CancelEnabled = True

            Me.Plan = Nothing

            Me.PlanStaffAltEmployee = Nothing

            Me.Offices = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.EmployeeTitles = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.DepartmentTeams = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
            Me.RevenueResourcePlanStaffTypes = New Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

        End Sub

#End Region

    End Class

End Namespace
