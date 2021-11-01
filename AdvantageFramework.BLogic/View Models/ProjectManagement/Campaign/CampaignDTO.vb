Namespace ViewModels.ProjectManagement.Campaign
    'campaignDTO
    <Serializable()>
    Public Class CampaignDTO
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property Code As String
        Public Property StartDate As Date?
        Public Property EndDate As Date?
        Public Property Comment As String
        Public Property Name As String
        Public Property IsDirectResponse As Boolean
        Public Property IsMagazine As Boolean
        Public Property IsNewspaper As Boolean
        Public Property IsOutOfHome As Boolean
        Public Property IsPrint As Boolean
        Public Property IsRadio As Boolean
        Public Property IsTelevision As Boolean
        Public Property IsOther As Boolean
        Public Property OtherDescription As String
        Public Property ID As Integer
        Public Property IsClosed As Boolean
        Public Property IsActive As Boolean
        Public Property BillingBudgetAmount As Decimal?
        Public Property IncomeBudgetAmount As Decimal?
        Public Property CampaignType As Short
        Public Property OfficeCode As String
        Public Property AlertGroupCode As String
        Public Property IsInternetAds As Boolean
        Public Property AdNumber As String
        Public Property MarketCode As String
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property ClientWebsiteID As Integer?
        Public Property AdServerID As Integer?
        Public Property AdServerCampaignID As Long?
        Public Property AdServerCreatedBy As String

        Public Property CampaignDetailDTO As CampaignDetailDTO()

    End Class
End Namespace
