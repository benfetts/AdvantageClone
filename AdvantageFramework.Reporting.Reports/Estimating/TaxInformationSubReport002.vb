Namespace Estimating

    Public Class TaxInformationSubReport002

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub XrLabelCityTax_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelCityTax.BeforePrint
            Try
                Me.XrLabelCityTax.Text = Me.XrLabelCityTax.Text & ":"
            Catch ex As Exception

            End Try
        End Sub

#End Region


    End Class

End Namespace