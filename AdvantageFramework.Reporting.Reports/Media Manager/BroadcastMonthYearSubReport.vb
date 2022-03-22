Namespace MediaManager

    Public Class BroadcastMonthYearSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Private Sub LabelTotalNetWhenGrossOrder_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelTotalNetWhenGrossOrder.BeforePrint

            If DirectCast(Me.GetCurrentRow, AdvantageFramework.MediaManager.Classes.BroadcastOrderYearMonth).ShowTotalNetWhenGrossOrder = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
