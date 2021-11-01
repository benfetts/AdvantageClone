
Namespace Reporting.Database.Classes

    <Serializable>
    Public Class BillingInvoiceDetail
#Region " Constants "

#End Region

#Region " Enum "
        Public Enum Properties

            HeaderPicture
            Header

            ' -----
            ClientName
            Division
            Product
            OrderNumber
            MediaType
            Market
            Station
            Vendor
            InvoiceNumber
            InvoiceDate
            EntryDate
            InvoiceMonth
            InvoiceStatus
            InvoiceFile

            '-----

            AirDate
            AirTime
            Length
            GrossRate
            Ad
            CableNetwork

            '-------
            LineGross
            LineDue
            LineSpots

        End Enum

#End Region

#Region " Variables "

        Public Property HeaderPicture As String
        Public Property Header As String

        Public Property ClientName As String
        Public Property Division As String
        Public Property Product As String
        Public Property OrderNumber As String
        Public Property MediaType As String
        Public Property Market As String
        Public Property Station As String
        Public Property Vendor As String
        Public Property InvoiceNumber As String
        Public Property InvoiceDate As Nullable(Of Date)
        Public Property EntryDate As Nullable(Of Date)
        Public Property InvoiceMonth As String
        Public Property InvoiceStatus As String
        Public Property InvoiceFile As String


        '-----

        Public Property AirDate As DateTime
        Public Property AirTime As DateTime
        Public Property Length As Integer
        Public Property GrossRate As Nullable(Of Decimal)
        Public Property Ad As String
        Public Property CableNetwork As String

        '-------
        Public Property LineGross As Decimal
        Public Property LineDue As Decimal
        Public Property LineSpots As Integer

#End Region

#Region " Properties "

#End Region

#Region " Methods "

#End Region

    End Class
End Namespace

