Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BroadcastOrderBySpotReport

#Region " Constants "

#End Region

#Region " Enum "
        Public Enum Properties
            OrderID
            ClientID
            Client
            DivisionID
            Division
            ProductID
            Product
            MarketID
            Market
            VenRep
            Buyer
            StartDate
            EndDate
            Campaign
            Description
            AddressName
            Address1
            AddressCity
            AddressState
            AddressZip
            EMail
            Station
            OrderInstructions
            OrderType
            '-------
            Line
            AirDate
            Time
            Length
            Program
            Spots
            Cost
            Gross

            '---------
            PageHeaderLogoPathLand
            PageHeaderComment
        End Enum
#End Region

#Region " Variables "

#End Region

#Region " Properties "
        Public Property OrderID As Integer
        Public Property ClientID As Integer
        Public Property Client As String
        Public Property DivisionID As Integer
        Public Property Division As String
        Public Property ProductID As Integer
        Public Property Product As String
        Public Property MarketID As Integer
        Public Property Market As String
        Public Property VenRep As String
        Public Property Buyer As String
        Public Property StartDate
        Public Property EndDate
        Public Property Campaign As String
        Public Property Description As String
        Public Property AddressName As String
        Public Property Address1 As String
        Public Property AddressCity As String
        Public Property AddressState As String
        Public Property AddressZip As String
        Public Property EMail As String
        Public Property Station As String
        Public Property OrderInstructions As String

        Public Property OrderType As String
        '-------
        Public Property Line As Integer
        Public Property AirDate As String
        Public Property Time As Date
        Public Property Length As Integer
        Public Property Program As String
        Public Property Spots As Integer
        Public Property Cost As Decimal
        Public Property Gross As Decimal
        '--------
        Public Property PageHeaderLogoPathLand As String
        Public Property PageHeaderComment As String
#End Region

#Region " Methods "

#End Region

    End Class
End Namespace


