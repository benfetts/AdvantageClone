Namespace ViewModels.ProjectManagement.Campaign
    <Serializable()>
    Public Class CampaignSearchDTO

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property ID As Integer
        Public Property Code As String
        Public Property Name As String
        Public Property StartDate As Date?
        Public Property EndDate As Date?
        Public Property ClientCode As String
        Public Property ClientName As String
        Public Property DivisionCode As String
        Public Property DivisionName As String
        Public Property ProductCode As String
        Public Property ProductName As String
        Public Property OfficeCode As String
        Public Property OfficeName As String
#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class
End Namespace

