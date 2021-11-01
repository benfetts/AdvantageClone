Namespace DTO.Media

    Public Class Invoice
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MEDIA
            CLIENT
            PRODUCT
            EST
            ESTIMATE
            MARKET
            STATION
            [DATE]
            TIME
            LEN
            InvoiceCost
            InvoiceNumber
            FILM
            SpotsInvoice
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MEDIA() As String
        Public Property CLIENT() As String
        Public Property PRODUCT() As String
        Public Property EST() As Integer
        Public Property ESTIMATE() As String
        Public Property MARKET() As String
        Public Property STATION() As String
        Public Property [DATE]() As Date
        Public Property TIME() As TimeSpan
        Public Property LEN() As Short
        Public Property InvoiceCost() As Decimal
        Public Property InvoiceNumber() As String
        Public Property FILM() As String
        Public Property SpotsInvoice() As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
