Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class RevenueManageViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property ViewRevisionEnabled As Boolean
        Public Property CreateRevisionEnabled As Boolean
        Public Property DeleteRevisionEnabled As Boolean

        Public Property ApproveVisible As Boolean
        Public Property Approved As Boolean
        Public Property ApprovedBy As String
        Public Property ApprovedByDate As String

        Public Property AddDetailsEnabled As Boolean
        Public Property DeleteDetailsEnabled As Boolean

        Public Property RevenueResourcePlanID As Integer
        Public Property RevenueResourcePlanRevenueID As Integer

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan
        Public Property PlanRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue
        Public Property PlanRevenueRevisions As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision)
        Public Property SelectedPlanRevenueRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision
        Public Property PlanRevenueRevisionDetails As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevisionDetail)

        Public ReadOnly Property IsMaxRevisionNumber As Boolean
            Get
                IsMaxRevisionNumber = (Me.PlanRevenueRevisions IsNot Nothing AndAlso
                                       Me.PlanRevenueRevisions.Count > 0 AndAlso
                                       Me.SelectedPlanRevenueRevision IsNot Nothing AndAlso
                                       Me.SelectedPlanRevenueRevision.RevisionNumber = Me.PlanRevenueRevisions.Max(Function(Entity) Entity.RevisionNumber))
            End Get
        End Property

        Public ReadOnly Property HasASelectedRevision As Boolean
            Get
                HasASelectedRevision = (Me.PlanRevenueRevisions IsNot Nothing AndAlso
                                        Me.PlanRevenueRevisions.Count > 0 AndAlso
                                        Me.SelectedPlanRevenueRevision IsNot Nothing)
            End Get
        End Property

        Public Property DataTable As System.Data.DataTable
        Public Property DataView As System.Data.DataView

        Public Property DetailDates As Hashtable
        Public Property ActualDetailDates As Hashtable

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = False
            Me.CancelEnabled = False

            Me.ViewRevisionEnabled = True
            Me.CreateRevisionEnabled = False
            Me.DeleteRevisionEnabled = False

            Me.ApproveVisible = True
            Me.Approved = False
            Me.ApprovedBy = String.Empty
            Me.ApprovedByDate = String.Empty

            Me.AddDetailsEnabled = False
            Me.DeleteDetailsEnabled = False

            Me.RevenueResourcePlanID = 0
            Me.RevenueResourcePlanRevenueID = 0

            Me.Plan = Nothing
            Me.PlanRevenue = Nothing
            Me.PlanRevenueRevisions = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision)
            Me.SelectedPlanRevenueRevision = Nothing
            Me.PlanRevenueRevisionDetails = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevisionDetail)

            Me.DataTable = New System.Data.DataTable
            Me.DataView = New System.Data.DataView(Me.DataTable)

            Me.DetailDates = New Hashtable
            Me.ActualDetailDates = New Hashtable

        End Sub

#End Region

    End Class

End Namespace
