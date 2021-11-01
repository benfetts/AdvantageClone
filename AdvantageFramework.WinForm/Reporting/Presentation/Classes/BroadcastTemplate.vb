Namespace Reporting.Presentation.Classes

    Public Class BroadcastTemplate
        Public Property TemplateID As Integer
        Public Property WorksheetID As Integer
        Public Property TemplateName As String

        Public Property RunDetail As Boolean
        Public Property RunMarket As Boolean
        Public Property RunStation As Boolean
        Public Property RunWeeklyDaily As Boolean

        Public Property Location As String

        Public Property ShowSecondary As Boolean
        Public Property ShowRatings As Boolean
        Public Property ShowComments As Boolean
        Public Property ShowSpotCosts As Boolean
        Public Property ShowImpressions As Boolean
        Public Property ShowBookends As Boolean
        Public Property ShowTotalCosts As Boolean
        Public Property ShowCPPM As Boolean
        Public Property ShowAddedValue As Boolean
        Public Property ShowRF As Boolean


        Public Property DateFrom As String
        Public Property DateTo As String
        Public Property Markets As String
        Public Property Vendors As String
        Public Property MarketList As List(Of String)
        Public Property VendorList As List(Of String)

        Public Sub New()
            'MarketList = Markets.Split("|").ToList
            'VendorList = Vendors.Split("|").ToList
        End Sub

        Public Sub New(
        TemplateID As Integer _
        , WorksheetID As Integer _
        , TemplateName As String _
        , RunDetail As Boolean _
        , RunMarket As Boolean _
        , RunStation As Boolean _
        , RunWeeklyDaily As Boolean _
        , Location As String _
        , ShowSecondary As Boolean _
        , ShowRatings As Boolean _
        , ShowComments As Boolean _
        , ShowSpotCosts As Boolean _
        , ShowImpressions As Boolean _
        , ShowBookends As Boolean _
        , ShowTotalCosts As Boolean _
        , ShowCPPM As Boolean _
        , ShowAddedValue As Boolean _
        , ShowRF As Boolean _
        , DateFrom As String _
        , DateTo As String _
        , Markets As String _
        , Vendors As String)

            Me.TemplateID = TemplateID
            Me.WorksheetID = WorksheetID
            Me.TemplateName = TemplateName
            Me.RunDetail = RunDetail
            Me.RunMarket = RunMarket
            Me.RunStation = RunStation
            Me.RunWeeklyDaily = RunWeeklyDaily

            Me.Location = Location

            Me.ShowSecondary = ShowSecondary
            Me.ShowRatings = ShowRatings
            Me.ShowComments = ShowComments
            Me.ShowSpotCosts = ShowSpotCosts
            Me.ShowImpressions = ShowImpressions
            Me.ShowBookends = ShowBookends
            Me.ShowTotalCosts = ShowTotalCosts
            Me.ShowCPPM = ShowCPPM
            Me.ShowAddedValue = ShowAddedValue
            Me.ShowRF = ShowRF

            Me.DateFrom = DateFrom
            Me.DateTo = DateTo
            Me.Markets = Markets
            Me.Vendors = Vendors
            Me.MarketList = Markets.Split("|").ToList
            Me.VendorList = Vendors.Split("|").ToList
        End Sub
    End Class

End Namespace
