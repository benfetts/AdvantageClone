Namespace ViewModels.FinanceAndAccounting.RevenueResourcePlan

    Public Class ResourceManageViewModel

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
        Public Property RevenueResourcePlanResourceID As Integer

        Public Property Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan
        Public Property PlanResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResource
        Public Property PlanResourceRevisions As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision)
        Public Property SelectedPlanResourceRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision
        Public Property PlanResourceRevisionDetails As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevisionDetail)

        Public ReadOnly Property IsMaxRevisionNumber As Boolean
            Get
                IsMaxRevisionNumber = (Me.PlanResourceRevisions IsNot Nothing AndAlso
                                       Me.PlanResourceRevisions.Count > 0 AndAlso
                                       Me.SelectedPlanResourceRevision IsNot Nothing AndAlso
                                       Me.SelectedPlanResourceRevision.RevisionNumber = Me.PlanResourceRevisions.Max(Function(Entity) Entity.RevisionNumber))
            End Get
        End Property

        Public ReadOnly Property HasASelectedRevision As Boolean
            Get
                HasASelectedRevision = (Me.PlanResourceRevisions IsNot Nothing AndAlso
                                        Me.PlanResourceRevisions.Count > 0 AndAlso
                                        Me.SelectedPlanResourceRevision IsNot Nothing)
            End Get
        End Property

        Public Property DataTable As System.Data.DataTable
        Public Property DataView As System.Data.DataView

        Public Property DetailDates As Hashtable

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
            Me.RevenueResourcePlanResourceID = 0

            Me.Plan = Nothing
            Me.PlanResource = Nothing
            Me.PlanResourceRevisions = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision)
            Me.SelectedPlanResourceRevision = Nothing
            Me.PlanResourceRevisionDetails = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevisionDetail)

            Me.DataTable = New System.Data.DataTable
            Me.DataView = New System.Data.DataView(Me.DataTable)

            Me.DetailDates = New Hashtable

        End Sub

#End Region

    End Class

End Namespace
