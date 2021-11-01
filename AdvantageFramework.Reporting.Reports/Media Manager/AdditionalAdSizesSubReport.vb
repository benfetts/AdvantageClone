Namespace MediaManager

    Public Class AdditionalAdSizesSubReport


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Printed As Boolean = False

#End Region

#Region " Properties "

        Public WriteOnly Property PrintedFlag As Boolean
            Set(value As Boolean)
                _Printed = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub LabelAdditionalAdSizes_AfterPrint(sender As Object, e As EventArgs) Handles LabelAdditionalAdSizes.AfterPrint

            _Printed = True

        End Sub
        Private Sub LabelAdditionalAdSizes_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelAdditionalAdSizes.BeforePrint

            If _Printed Then

                e.Cancel = True

            End If

        End Sub

#End Region

    End Class

End Namespace