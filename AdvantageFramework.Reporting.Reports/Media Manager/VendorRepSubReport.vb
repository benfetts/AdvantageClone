Namespace MediaManager

    Public Class VendorRepSubReport


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _RepresentativeLabel As String = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property RepresentativeLabel As String
            Set(value As String)
                _RepresentativeLabel = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub LabelDetail_RepresentativeLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_RepresentativeLabel.BeforePrint

            If Not String.IsNullOrWhiteSpace(_RepresentativeLabel) Then

                LabelDetail_RepresentativeLabel.Text = _RepresentativeLabel

            Else

                LabelDetail_RepresentativeLabel.Text = Nothing

            End If

        End Sub
        Private Sub VendorRepSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            VendorRepresentatives = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative))

            For Each VendorRepresentative In VendorRepresentatives

                If String.IsNullOrWhiteSpace(VendorRepresentative.Address1) Then

                    VendorRepresentative.Address1 = Nothing

                End If

                If String.IsNullOrWhiteSpace(VendorRepresentative.Address2) Then

                    VendorRepresentative.Address2 = Nothing

                End If

                If String.IsNullOrWhiteSpace(VendorRepresentative.Country) Then

                    VendorRepresentative.Country = Nothing

                End If

                If String.IsNullOrWhiteSpace(VendorRepresentative.County) Then

                    VendorRepresentative.County = Nothing

                End If

                If String.IsNullOrWhiteSpace(VendorRepresentative.EmailAddress) Then

                    VendorRepresentative.EmailAddress = Nothing

                End If

            Next

            Me.DataSource = VendorRepresentatives

        End Sub

#End Region

    End Class

End Namespace