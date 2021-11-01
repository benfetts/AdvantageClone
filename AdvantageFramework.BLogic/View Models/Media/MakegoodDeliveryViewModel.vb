Namespace ViewModels.Media

    Public Class MakegoodDeliveryViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsValid As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property InDifferentOrderState As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property QueryString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property DatabaseName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property NetGross As Short

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaType As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property StationName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MarketDescription As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Client Name")>
        Public Property ClientName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Product")>
        Public Property ProductName As String

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DisplayName("Sales Rep")>
        Public Property SalesRep As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property SalesRepPhone As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property SalesRepEmail As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property FlightDates As String

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:000000}")>
        Public Property OrderNumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False),
         System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="{0:MM/dd/yyyy}")>
        Public Property OrderPlaced As Date

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property OrderStatus As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property AgencyName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property BuyerName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property BuyerPhone As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property BuyerEmail As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property IsOriginalOrderMode As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property VendorIsCableSystem As Boolean

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
         System.ComponentModel.DisplayName("Order Comments")>
        Public Property OrderComments As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property OriginalModeAcceptReject As String

        Public Property MakegoodDataTable As System.Data.DataTable

        Public Property SpotCount As Integer

        Public Property SpotDates As Dictionary(Of String, Integer)
        Public Property SpotDateBroadcastYearMonth As Dictionary(Of Integer, String)

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property RevisedString As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property MaxRevisionNumber As Integer

        <System.ComponentModel.DataAnnotations.Editable(False),
        System.ComponentModel.DataAnnotations.DataType(ComponentModel.DataAnnotations.DataType.MultilineText),
        System.ComponentModel.DisplayName("Terms Of Agreement")>
        Public Property TermsOfAgreement As String

        Public Property MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer)

        Public Property SuppressRatings As Boolean

        Public Property PrimaryDemographic As String
        'Public Property SecondaryDemographic As String

        Public Property MinDate As Date
        Public Property MaxDate As Date

        Public Property BroadcastCalendars As Generic.List(Of AdvantageFramework.DTO.Media.BroadcastCalendar)

        Public Property LineNumbers As IEnumerable(Of Short)

        Public Property VendorEditLocked As Boolean

        Public Property VendorName As String

        Public Property AlertID As Nullable(Of Integer)

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property WorksheetDateTypeName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property WorksheetName As String

        <System.ComponentModel.DataAnnotations.Editable(False)>
        Public Property Copyright As String

        Public Property StartDates As IEnumerable

        Public Property GridAdvantage As AdvantageFramework.DTO.GridAdvantage

        Public Property CableNetworks As Generic.List(Of Object)

#End Region

#Region " Methods "

        Public Sub New()

            Me.GridAdvantage = Nothing
            Me.CableNetworks = Nothing

        End Sub
        Public Function YearMonths() As IEnumerable(Of String)

            YearMonths = SpotDateBroadcastYearMonth.Select(Function(YM) YM.Value).Distinct.ToArray

        End Function
        Public Function GetSpotYearMonth(SpotDate As String) As String

            Dim YearMonth As String = Nothing

            If SpotDateBroadcastYearMonth.ContainsKey(SpotDate) Then

                YearMonth = SpotDateBroadcastYearMonth.Item(SpotDate)

            End If

            GetSpotYearMonth = YearMonth

        End Function

#End Region

    End Class

End Namespace
