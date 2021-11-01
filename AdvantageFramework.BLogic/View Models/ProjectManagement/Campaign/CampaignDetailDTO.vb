Namespace ViewModels.ProjectManagement.Campaign
    <Serializable()>
    Public Class CampaignDetailDTO
        Public Property CampaignID As Integer
        Public Property ID As Short
        Public Property SalesClassCode As String
        Public Property SalesClassDesc As String
        Public Property PostPeriodCode As String
        Public Property PostPeriodDesc As String
        Public Property CampaignDetailTypeCode As String
        Public Property CampaignDetailTypeDesc As String
        Public Property DepartmentTeamCode As String
        Public Property DepartmentTeamDesc As String
        Public Property BillingBudgetAmount As Decimal?
        Public Property IncomeBudgetAmount As Decimal?
        Public Property RevisedDate As Date?
        Public Property UserCode As String
        Public Property FunctionCode As String
        Public Property FunctionDesc As String

    End Class
End Namespace
