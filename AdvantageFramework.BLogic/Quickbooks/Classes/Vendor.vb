Namespace Quickbooks.Classes

    Public Class Vendor

        Public Property Id As String
        Public Property DisplayName As String

        Public Property BillAddressLine1 As String
        Public Property BillAddressLine2 As String
        Public Property BillAddressLine3 As String
        Public Property BillAddressCity As String
        Public Property BillAddressState As String
        Public Property BillAddressZip As String

        Public Property Website As String
        Public Property Email As String
        Public Property Phone As String

        Public Sub New(Vendor As Intuit.Ipp.Data.Vendor)

            Me.Id = Vendor.Id
            Me.DisplayName = Vendor.DisplayName

            If Vendor.BillAddr IsNot Nothing Then

                Me.BillAddressLine1 = Vendor.BillAddr.Line1
                Me.BillAddressLine2 = Vendor.BillAddr.Line2
                Me.BillAddressLine3 = Vendor.BillAddr.Line3
                Me.BillAddressCity = Vendor.BillAddr.City
                Me.BillAddressState = Vendor.BillAddr.CountrySubDivisionCode
                Me.BillAddressZip = Vendor.BillAddr.PostalCode

            End If

            If Vendor.WebAddr IsNot Nothing Then

                Me.Website = Vendor.WebAddr.URI

            End If

            If Vendor.PrimaryEmailAddr IsNot Nothing Then

                Me.Email = Vendor.PrimaryEmailAddr.Address

            End If

            If Vendor.PrimaryPhone IsNot Nothing Then

                Me.Phone = Vendor.PrimaryPhone.FreeFormNumber

                Me.Phone = Strings.Left(Me.Phone.Replace(" ", ""), 13)

            End If

        End Sub

    End Class

End Namespace
