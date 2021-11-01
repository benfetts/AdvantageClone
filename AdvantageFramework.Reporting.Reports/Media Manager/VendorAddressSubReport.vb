Namespace MediaManager

    Public Class VendorAddressSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OmitEmail As Boolean = False
        Private _OmitPhone As Boolean = False
        Private _OmitFax As Boolean = False

#End Region

#Region " Properties "

        Public WriteOnly Property OmitEmail As Boolean
            Set(value As Boolean)
                _OmitEmail = value
            End Set
        End Property
        Public WriteOnly Property OmitPhone As Boolean
            Set(value As Boolean)
                _OmitPhone = value
            End Set
        End Property
        Public WriteOnly Property OmitFax As Boolean
            Set(value As Boolean)
                _OmitFax = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub VendorAddressSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Vendors = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.Vendor))

            For Each Vendor In Vendors.Where(Function(DataLine) DataLine IsNot Nothing)

                If String.IsNullOrWhiteSpace(Vendor.StreetAddressLine1) Then

                    Vendor.StreetAddressLine1 = Nothing

                End If

                If String.IsNullOrWhiteSpace(Vendor.StreetAddressLine2) Then

                    Vendor.StreetAddressLine2 = Nothing

                End If

                If String.IsNullOrWhiteSpace(Vendor.StreetAddressLine3) Then

                    Vendor.StreetAddressLine3 = Nothing

                End If

                If String.IsNullOrWhiteSpace(Vendor.Country) Then

                    Vendor.Country = Nothing

                End If

                If String.IsNullOrWhiteSpace(Vendor.County) Then

                    Vendor.County = Nothing

                End If

                If String.IsNullOrWhiteSpace(Vendor.EmailAddress) OrElse _OmitEmail Then

                    Vendor.EmailAddress = Nothing

                End If

                If _OmitPhone Then

                    Vendor.PhoneNumber = Nothing
                    Vendor.PhoneNumberExtension = Nothing

                End If

                If _OmitFax Then

                    Vendor.FaxPhoneNumber = Nothing
                    Vendor.FaxPhoneNumberExtension = Nothing

                End If

            Next

            Me.DataSource = Vendors

        End Sub

#End Region

    End Class

End Namespace