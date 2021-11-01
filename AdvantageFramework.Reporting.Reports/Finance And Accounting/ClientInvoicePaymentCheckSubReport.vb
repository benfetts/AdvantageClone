Namespace FinanceAndAccounting

    Public Class ClientInvoicePaymentCheckSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientInvoicePaymentCheckSubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            If Me.DataSource Is Nothing OrElse Me.DataSource.count = 0 Then

                e.Cancel = True

            End If
            
        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
