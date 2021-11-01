Namespace Quickbooks.Classes

    Public Class Customer

        Public Property Id As String
        Public Property DisplayName As String

        Public Property BillAddressLine1 As String
        Public Property BillAddressLine2 As String
        Public Property BillAddressCity As String
        Public Property BillAddressState As String
        Public Property BillAddressZip As String
        Public Property BillAddressCounty As String
        Public Property BillAddressCountry As String

        Public Sub New(Customer As Intuit.Ipp.Data.Customer)

            Me.Id = Customer.Id
            Me.DisplayName = Customer.DisplayName

            If Customer.BillAddr IsNot Nothing Then

                Me.BillAddressLine1 = Customer.BillAddr.Line1
                Me.BillAddressLine2 = Customer.BillAddr.Line2
                Me.BillAddressCity = Customer.BillAddr.City
                Me.BillAddressState = Customer.BillAddr.CountrySubDivisionCode
                Me.BillAddressZip = Customer.BillAddr.PostalCode
                Me.BillAddressCounty = Customer.BillAddr.County
                Me.BillAddressCountry = Customer.BillAddr.Country

            End If

        End Sub

    End Class

End Namespace
